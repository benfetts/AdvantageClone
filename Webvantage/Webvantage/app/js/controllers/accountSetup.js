app.controller('accountsetupLookupController', function ($scope, $rootScope, $http, $modal, $timeout, dataService) {
   
    $scope.defaultDivisionCodePromise = null;
    $scope.defaultProductCodePromise = null;
    $scope.accountsetupValidationPromise = null;
    $scope.searchProductNamePromise = null;
    $scope.currentSecurityModule = null
    $scope.accountsetuptValidationRequest = {};
    $scope.accountsetupValidationResult = {
        ValidationPassed: false,
        ErrorMessage: "Please fill out all required fields."
    };

    $scope.minimumHeight = 490;

    $scope.searchActive = true;

    $scope.ClientCode = '';
    $scope.ClientName = '';
    $scope.DivisionCode = '';
    $scope.DivisionName = '';
    $scope.ProductCode = '';
    $scope.ProductName = '';
    $scope.PercentSplit = '';
    $scope.JobNumber = '',
    $scope.JobComponentNumber = '';

    $scope.currentRadWindow = null;

    $scope.lastLookupType = '';

    $scope.suppressDefaultDivision = false;
    $scope.suppressDefaultProduct = false;

    $scope.searchCriteria = {
        JobComponent: {
            ClientCode: $scope.ClientCode,
            ClientName: $scope.ClientName,
            DivisionCode: $scope.DivisionCode,
            DivisionName: $scope.DivisionName,
            ProductCode: $scope.ProductCode,
            ProductName: $scope.ProductName,
            JobNumber: $scope.JobNumber,
            JobComponentNumber: $scope.JobComponentNumber,
            PercentSplit: $scope.PercentSplit,
        },
        LookupType: '',
        ShowInactive: false,
        SecurityModule: $scope.currentSecurityModule
    };

    //$scope.open = function (secModule, lookupType) {
    //    var currentCriteria = angular.copy($scope.searchCriteria);
    //    currentCriteria.LookupType = lookupType;
    //    currentCriteria.SecurityModule = secModule;

    //    var modalInstance = $modal.open({
    //        animation: true,
    //        templateUrl: 'app/templates/ModalFilterDialog.aspx?LookupType=' + lookupType,
    //        //controller: 'lookupModalController',
    //        size: 'lg',
    //        resolve: {
    //            searchCriteria: function () {
    //                return currentCriteria;
    //            }
    //        }
    //    });

    //    modalInstance.result.then(function (selectedItem) {
    //        if (selectedItem) {
    //            $scope.searchCriteria[selectedItem.ObjectName] = selectedItem;
    //        } else {
    //            $scope.searchCriteria = null;
    //        }
    //        var abc = null;
    //    }, function () {
    //        //  $log.info('Modal dismissed at: ' + new Date());
    //    });
    //};

    $scope.open = function (lookupType) {
        if (!$scope.searchActive) {
            return;
        }

        if ($scope.currentRadWindow === null) {
            $scope.currentRadWindow = $rootScope.getCurrentRadWindow();
        }

        $scope.searchCriteria = {
            JobComponent: {
                ClientCode: $scope.ClientCode,
                ClientName: $scope.ClientName,
                DivisionCode: $scope.DivisionCode,
                DivisionName: $scope.DivisionName,
                ProductCode: $scope.ProductCode,
                ProductName: $scope.ProductName,
                JobNumber: $scope.JobNumber,
                JobComponentNumber: $scope.JobComponentNumber,
                PercentSplit: $scope.PercentSplit,
            },
            LookupType: '',
            ShowInactive: false,
            SecurityModule: $scope.currentSecurityModule
        };

        $scope.lastLookupType = lookupType;

        var currentCriteria = angular.copy($scope.searchCriteria);
        currentCriteria.LookupType = lookupType;
        
        if (lookupType === 'Client') {
            currentCriteria.JobComponent.ClientCode = '';
        }
        if (lookupType === 'Division') {
            currentCriteria.JobComponent.DivisionCode = '';
        }
        if (lookupType === 'Product') {
            currentCriteria.JobComponent.ProductCode = '';
        }

        //var oBrowserWnd = $scope.currentRadWindow.BrowserWindow;
        if (lookupType === 'JobComponent' || lookupType === 'Job') {
            var lookupEnumVal = 0;
            if (lookupType === 'JobComponent') {
                lookupEnumVal = 2
            }
            if (lookupType === 'Job') {
                lookupEnumVal = 1
            }
            setTimeout(function () {
                var s = "";
                if (currentCriteria.JobComponent.ClientCode) {
                    s = s + "&c=" + currentCriteria.JobComponent.ClientCode;
                }
                if (currentCriteria.JobComponent.ClientCode) {
                    s = s + "&d=" + currentCriteria.JobComponent.DivisionCode;
                }
                if (currentCriteria.JobComponent.ClientCode) {
                    s = s + "&p=" + currentCriteria.JobComponent.ProductCode;
                }
                if (currentCriteria.JobComponent.ClientCode) {
                    s = s + "&j=" + currentCriteria.JobComponent.jobNumber;
                }
                var newWindow = oBrowserWnd.radopen("Lookup_Job?LookupType=" + lookupEnumVal + "&LookupSource=3&IncludeClosed=false" + s, null, $rootScope.initialModalDialogWidth, $rootScope.initialModalDialogHeight);
                newWindow.set_modal(true);
                if (newWindow) {
                    var contentWindow = newWindow.get_contentFrame().contentWindow;
                    if (contentWindow) {
                        newWindow.add_pageLoad(function () {
                            //contentWindow.initialSearchResults(currentCriteria, $scope);
                        });
                    }
                }
            }, 0);
        } else {
            OpenRadWindowLookup2("ModalFilterDialog.aspx?", currentCriteria, $scope);

            //setTimeout(function () {
            //    var newWindow = oBrowserWnd.radopen("ModalFilterDialog.aspx?LookupType=" + lookupType, null, $rootScope.initialModalDialogWidth, $rootScope.initialModalDialogHeight);
            //    newWindow.set_modal(true);
            //    if (newWindow) {
            //        var contentWindow = newWindow.get_contentFrame().contentWindow;
            //        newWindow.add_pageLoad(function () {
            //            contentWindow.initialSearchResults(currentCriteria, $scope);
            //        });
            //    }
            //}, 0);
        }

    };

    $scope.processLookupSelection = function (selectedItem) {
        $scope.searchCriteria[selectedItem.ObjectName] = selectedItem;
        if (selectedItem.ObjectName === 'JobComponent') {
            $scope.suppressDefaultDivision = true;
            $scope.suppressDefaultProduct = true;
            $scope.ClientCode = selectedItem.ClientCode;
            $scope.ClientName = selectedItem.ClientName;
            $scope.DivisionCode = selectedItem.DivisionCode;
            $scope.DivisionName = selectedItem.DivisionName;
            $scope.ProductCode = selectedItem.ProductCode;
            $scope.ProductName = selectedItem.ProductName;

            if ($scope.DivisionCode === null || $scope.DivisionCode === undefined || $scope.DivisionCode === '') {
                $scope.getDefaultDivisionCode()
            }

            if ($scope.ProductCode === null || $scope.ProductCode === undefined || $scope.ProductCode === '') {
                $scope.getDefaultProductCode()
            }
        }

        $timeout(function () {
            if ($scope.lastLookupType === 'Client') {
                if ($('#TextBoxClientCode') !== null) {
                    $('#TextBoxClientCode').focus();
                }
                if ($('#TextBox_ClientCode') !== null) {
                    $('#TextBox_ClientCode').focus();
                }
            }

            if ($scope.lastLookupType === 'Division') {
                if ($('#TextBoxDivisionCode') !== null) {
                    $('#TextBoxDivisionCode').focus();
                }
                if ($('#TextBox_DivisionCode') !== null) {
                    $('#TextBox_DivisionCode').focus();
                }
            }

            if ($scope.lastLookupType === 'Product') {
                if ($('#TextBoxProductCode') !== null) {
                    $('#TextBoxProductCode').focus();
                }
                if ($('#TextBox_ProductCode') !== null) {
                    $('#TextBox_ProductCode').focus();
                }
            }

        }, 500)

        $scope.$apply();
    };

    $scope.validateCurrentAccountSetupEntry = function () {
        $timeout.cancel($scope.accountsetupValidationPromise);

        var currentDepartment = '';

        $scope.accountsetupValidationPromise = $timeout(function () {
            
            if ($scope.commentsViewActive) {
                $scope.accountsetupValidationRequest = {
                    Client: $scope.ClientCode,
                    Division: $scope.DivisionCode,
                    Product: $scope.ProductCode,
                    PercentSplit: $('#TextBox_PercentSplit').val(),
                    jobNumber: $('#TextBox_JobCode').val(),
                    jobComponentNumber: $('#TextBox_ComponentCode').val()
                };
            }
            else {
                $scope.accountsetupValidationRequest = {
                    Client: $scope.ClientCode,
                    Division: $scope.DivisionCode,
                    Product: $scope.ProductCode,
                    PercentSplit: $('#TextBox_PercentSplit').val(),
                    jobNumber: $('#TextBox_JobCode').val(),
                    jobComponentNumber: $('#TextBox_ComponentCode').val()
                };
            }



            dataService.ValidateAccountSetupEntry($scope.accountsetupValidationRequest).then(function (result) {
                $scope.accountsetupValidationResult = result.data;

                if (result.data.ValidationPassed == undefined) {
                    if ($scope.currentRadWindow === null) {
                        $scope.currentRadWindow = $rootScope.getCurrentRadWindow();
                    }

                    $scope.currentRadWindow.reload();
                }
                else {
                    if ($scope.accountsetupValidationResult.ValidationPassed) {
                        __doPostBack('InsertTimesheetRow', 'angularjs');
                    } else {
                        showKendoAlert($scope.accountsetupValidationResult.ErrorMessage);
                    }
                }
            });
        }, 800);
    };

    $scope.$watch("PercentSplit", function (newVal, oldVal) {

    });

    $scope.$watch("JobNumber", function (newVal, oldVal) {

    });

    $scope.$watch("JobComponentNumber", function (newVal, oldVal) {

    });

    //$scope.getDefaultJobComponentNumber = function (suppressLookups) {
    //    $timeout.cancel($scope.defaultJobSearchPromise);

    //    if (suppressLookups) {
    //        $scope.suppressDefaultDivision = true;
    //        $scope.suppressDefaultProduct = true;
    //    }

    //    if (angular.isNumber(Number($scope.JobNumber))) {
    //        $scope.defaultJobSearchPromise = $timeout(function () {
    //            $scope.searchCriteria = {
    //                JobComponent: {
    //                    ClientCode: '',
    //                    DivisionCode: '',
    //                    ProductCode: '',
    //                    JobNumber: $scope.JobNumber,
    //                    JobComponentNumber: ''
    //                },
    //                LookupType: 'JobComponent',
    //                ShowInactive: false,
    //                SecurityModule: $scope.currentSecurityModule
    //            };

    //            dataService.searchLookup($scope.searchCriteria).then(function (result) {
    //                if (result.data.Results.length === 0) {
    //                    //  $scope.JobDescription = '';
    //                    //  $scope.JobComponentNumber = '';
    //                    // $scope.JobComponentDescription = '';

    //                    dataService.jobOrComponentClosed($scope.searchCriteria).then(function (result) {
    //                        if (result.data.Closed === 'true') {
    //                            $scope.JobDescription = 'Job/Component Closed';
    //                        }
    //                    });
    //                }

    //                if (result.data.Results.length === 1) {
    //                    $scope.ClientCode = result.data.Results[0].ClientCode;
    //                    $scope.ClientName = result.data.Results[0].ClientName;
    //                    $scope.DivisionCode = result.data.Results[0].DivisionCode;
    //                    $scope.DivisionName = result.data.Results[0].DivisionName;
    //                    $scope.ProductCode = result.data.Results[0].ProductCode;
    //                    $scope.ProductName = result.data.Results[0].ProductName;
    //                    $scope.JobNumber = result.data.Results[0].JobNumber;
    //                    $scope.JobDescription = result.data.Results[0].JobDescription;
    //                    $scope.JobComponentNumber = result.data.Results[0].JobComponentNumber;
    //                    $scope.JobComponentDescription = result.data.Results[0].JobComponentDescription;
    //                }
    //            });
    //        }, 800);
    //    }
    //};

    //$scope.getJobComponentDescription = function () {
    //    $timeout.cancel($scope.defaultJobSearchPromise);

    //    if (angular.isNumber(Number($scope.JobNumber)) && angular.isNumber(Number($scope.JobComponentNumber))) {
    //        $scope.defaultJobSearchPromise = $timeout(function () {
    //            $scope.searchCriteria = {
    //                JobComponent: {
    //                    ClientCode: '',
    //                    DivisionCode: '',
    //                    ProductCode: '',
    //                    JobNumber: $scope.JobNumber,
    //                    JobComponentNumber: $scope.JobComponentNumber
    //                },
    //                LookupType: 'JobComponent',
    //                ShowInactive: false,
    //                SecurityModule: $scope.currentSecurityModule
    //            };

    //            dataService.searchLookup($scope.searchCriteria).then(function (result) {
    //                if (result.data.Results.length === 0) {

    //                    dataService.jobOrComponentClosed($scope.searchCriteria).then(function (result) {
    //                        if (result.data.Closed === 'true') {
    //                            $scope.JobDescription = 'Job/Component Closed';
    //                        }
    //                    });
    //                }

    //                if (result.data.Results.length === 1) {
    //                    $scope.suppressJobComponentNumber = true;
    //                    $scope.ClientCode = result.data.Results[0].ClientCode;
    //                    $scope.ClientName = result.data.Results[0].ClientName;
    //                    $scope.DivisionCode = result.data.Results[0].DivisionCode;
    //                    $scope.DivisionName = result.data.Results[0].DivisionName;
    //                    $scope.ProductCode = result.data.Results[0].ProductCode;
    //                    $scope.ProductName = result.data.Results[0].ProductName;
    //                    $scope.JobNumber = result.data.Results[0].JobNumber;
    //                    $scope.JobDescription = result.data.Results[0].JobDescription;
    //                    $scope.JobComponentNumber = result.data.Results[0].JobComponentNumber;
    //                    $scope.JobComponentDescription = result.data.Results[0].JobComponentDescription;
    //                }
    //            });
    //        }, 800);
    //    }
    //};

    //$scope.fillJobAndComponent = function (jobNumber, jobComponentNumber) {
    //    $timeout.cancel($scope.defaultJobSearchPromise);

    //    $scope.suppressDefaultDivision = true;
    //    $scope.suppressDefaultProduct = true;

    //    $scope.defaultJobSearchPromise = $timeout(function () {
    //        $scope.searchCriteria = {
    //            JobComponent: {
    //                ClientCode: '',
    //                DivisionCode: '',
    //                ProductCode: '',
    //                JobNumber: jobNumber,
    //                JobComponentNumber: jobComponentNumber
    //            },
    //            LookupType: 'JobComponent',
    //            ShowInactive: false,
    //            SecurityModule: $scope.currentSecurityModule
    //        };

    //        dataService.searchLookup($scope.searchCriteria).then(function (result) {
    //            if (result.data.Results.length === 0) {

    //                dataService.jobOrComponentClosed($scope.searchCriteria).then(function (result) {
    //                    if (result.data.Closed === 'true') {
    //                        $scope.JobDescription = 'Job/Component Closed';
    //                    }
    //                });
    //            }

    //            if (result.data.Results.length === 1) {
    //                $scope.ClientCode = result.data.Results[0].ClientCode;
    //                $scope.ClientName = result.data.Results[0].ClientName;
    //                $scope.DivisionCode = result.data.Results[0].DivisionCode;
    //                $scope.DivisionName = result.data.Results[0].DivisionName;
    //                $scope.ProductCode = result.data.Results[0].ProductCode;
    //                $scope.ProductName = result.data.Results[0].ProductName;
    //                $scope.JobNumber = result.data.Results[0].JobNumber;
    //                $scope.JobDescription = result.data.Results[0].JobDescription;
    //                $scope.JobComponentNumber = result.data.Results[0].JobComponentNumber;
    //                $scope.JobComponentDescription = result.data.Results[0].JobComponentDescription;

    //            }
    //        });
    //    }, 800);

    //};

    $scope.setMinimumHeight = function () {
        var currentWindow = $rootScope.getCurrentRadWindow();

        if (currentWindow.GetHeight() < $scope.minimumHeight) {
            currentWindow.SetHeight($scope.minimumHeight);
        }
    };

    $scope.getDefaultDivisionCode = function () {
        $timeout.cancel($scope.defaultDivisionCodePromise);

        if ($scope.suppressDefaultDivision) {
            $scope.suppressDefaultDivision = false;
            return;
        }
        if ($scope.ClientCode !== null && $scope.ClientCode !== undefined && $scope.ClientCode !== '') {
            $scope.defaultDivisionCodePromise = $timeout(function () {
                $scope.searchCriteria = {
                    JobComponent: {
                        ClientCode: $scope.ClientCode,
                        DivisionCode: '',
                        ProductCode: '',
                        JobNumber: '',
                        JobComponentNumber: ''
                    },
                    LookupType: 'Division',
                    ShowInactive: false,
                    SecurityModule: $scope.currentSecurityModule
                };

                dataService.searchLookup($scope.searchCriteria).then(function (result) {
                    if (result.data.Results.length === 1) {
                        $scope.ClientName = result.data.Results[0].ClientName;
                        $scope.DivisionCode = result.data.Results[0].DivisionCode;
                        $scope.DivisionName = result.data.Results[0].DivisionName;
                        $scope.getDefaultProductCode();
                        //$scope.ProductCode = result.data.Results[0].ProductCode;
                    }

                   //console.log('Cleared from default division')
                    $scope.JobNumber = ''
                    $scope.JobComponentNumber = ''

                });
            }, 500);
        }
    };

    $scope.getDefaultProductCode = function () {
        $timeout.cancel($scope.defaultProductCodePromise);
        //if ($scope.suppressDefaultProduct) {
        //    $scope.suppressDefaultProduct = false;
        //    return;
        //}
        if ($scope.DivisionCode !== null && $scope.DivisionCode !== undefined && $scope.DivisionCode !== '') {
            $scope.defaultProductCodePromise = $timeout(function () {
                $scope.searchCriteria = {
                    JobComponent: {
                        ClientCode: $scope.ClientCode,
                        DivisionCode: $scope.DivisionCode,
                        ProductCode: '',
                        JobNumber: '',
                        JobComponentNumber: ''
                    },
                    LookupType: 'Product',
                    ShowInactive: false,
                    SecurityModule: $scope.currentSecurityModule
                };


                dataService.searchLookup($scope.searchCriteria).then(function (result) {
                    if (result.data.Results.length === 1) {

                        $scope.ProductCode = result.data.Results[0].ProductCode;
                        $scope.ProductName = result.data.Results[0].ProductName;
                        $scope.DivisionName = result.data.Results[0].DivisionName;
                        $scope.ClientName = result.data.Results[0].ClientName;
                    }

                   //console.log('Cleared from default product')
                    $scope.JobNumber = ''
                    $scope.JobComponentNumber = '';

                });
            }, 500);
        }
    };

    $scope.searchProductName = function () {
        $timeout.cancel($scope.searchProductNamePromise);

        var currentProductCodeText = $('#TextBox_ProductCode').val().trim()

        if (currentProductCodeText === '') {
            return;
        }

        if ($scope.DivisionCode !== null && $scope.DivisionCode !== undefined && $scope.DivisionCode !== '') {
            $scope.searchProductNamePromise = $timeout(function () {
                $scope.searchCriteria = {
                    JobComponent: {
                        ClientCode: $scope.ClientCode,
                        DivisionCode: $scope.ClientCode,
                        ProductCode: currentProductCodeText,
                        JobNumber: '',
                        JobComponentNumber: ''
                    },
                    LookupType: 'Product',
                    ShowInactive: false,
                    SecurityModule: $scope.currentSecurityModule
                };

                dataService.searchLookup($scope.searchCriteria).then(function (result) {
                    if (result.data.Results.length === 1) {
                        $scope.ProductName = result.data.Results[0].ProductName;
                        $scope.ProductCode = result.data.Results[0].ProductCode;
                    } else {
                        $scope.ProductName = '';
                    }

                   //console.log('Cleared from search product name')
                    $scope.JobNumber = ''
                    $scope.JobComponentNumber = '';

                });
            }, 500);
        }
    };

    $scope.$watch("ClientCode", function (newVal, oldVal) {
        if (newVal === '' && oldVal !== '') {
            $scope.ClientName = '';
            $scope.DivisionCode = '';
            $scope.DivisionName = '';
            $scope.ProductCode = '';
            $scope.ProductName = '';
            $scope.JobNumber = '';
            $scope.JobComponentNumber = '';
            $scope.JobDescription = '';
            $scope.JobComponentDescription = '';
        }

        if (newVal !== '') {
            $scope.getDefaultDivisionCode();
        }

    });

    $scope.$watch("DivisionCode", function (newVal, oldVal) {

        if (newVal === '' && oldVal !== '') {
            $scope.DivisionName = '';
            $scope.ProductCode = '';
            $scope.ProductName = '';
            $scope.JobNumber = '';
            $scope.JobComponentNumber = '';
            $scope.JobDescription = '';
            $scope.JobComponentDescription = '';
        }

    });

    $scope.$watch("ProductCode", function (newVal, oldVal) {
        if (newVal === '' && oldVal !== '') {
            $scope.ProductName = '';
            $scope.JobNumber = '';
            $scope.JobComponentNumber = '';
            $scope.JobDescription = '';
            $scope.JobComponentDescription = '';
            $scope.DivisionName = '';
            $scope.ClientName = '';
        }

    });    

    //$scope.$watch("JobComponentNumber", function (newVal, oldVal) {

    //    if ($scope.suppressJobComponentNumber) {
    //        $scope.suppressJobComponentNumber = false;
    //        return;
    //    }

    //    if (newVal !== '' && angular.isNumber(Number($scope.JobNumber)) && angular.isNumber(Number(newVal))) {
    //        var componentSearchCriteria = {
    //            JobComponent: {
    //                ClientCode: '',
    //                DivisionCode: '',
    //                ProductCode: '',
    //                JobNumber: $scope.JobNumber,
    //                JobComponentNumber: newVal
    //            },
    //            LookupType: 'JobComponent',
    //            ShowInactive: false
    //        };

    //        dataService.jobOrComponentClosed(componentSearchCriteria).then(function (result) {
    //            if (result.data.Closed === 'true') {
    //                $scope.JobDescription = 'Job/Component Closed';
    //            }
    //        });
    //    } else {
    //        $scope.JobComponentDescription = '';
    //    }


    //});
});
