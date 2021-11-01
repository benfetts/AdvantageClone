app.controller('standardLookupController', function ($scope, $rootScope, $http, $modal, $timeout, dataService) {

    $scope.employeeCode = '';
    $scope.officeCode = '';
    $scope.officeName = '';
    $scope.clientCode = '';
    $scope.clientName = '';
    $scope.divisionCode = '';
    $scope.divisionName = '';
    $scope.productCode = '';
    $scope.productDescription = '';
    $scope.jobNumber = '',
    $scope.jobDescription = '';
    $scope.jobComponentNumber = '';
    $scope.jobComponentDescription = '';
    $scope.currentSecurityModule = null
    $scope.currentRadWindow = null;
    $scope.lastLookupType = '';
    $scope.lookUpValues = {};
    $scope.validationResult = {};

    $scope.suppressDefaultDivision = false;
    $scope.suppressDefaultProduct = false;
    $scope.suppressJobComponentNumber = false;

    $scope.defaultOfficeSearchPromise = null;
    $scope.defaultClientSearchPromise = null;
    $scope.defaultDivisionCodePromise = null;
    $scope.defaultProductCodePromise = null;
    $scope.defaultJobSearchPromise = null;
    $scope.defaultJobComponentSearchPromise = null;

    $scope.getNameOrDescriptionPromise = null;

    $scope.searchActive = true;
    $scope.searchCriteria = {
        Office: {
            ClientCode: $scope.officeCode,
            ClientName: $scope.officeName,
        },
        Client: {
            ClientCode: $scope.clientCode,
            ClientName: $scope.clientName,
        },
        Division: {
            ClientCode: $scope.clientCode,
            ClientName: $scope.clientName,
            DivisionCode: $scope.divisionCode,
            DivisionName: $scope.divisionName,
        },
        Product: {
            ClientCode: $scope.clientCode,
            ClientName: $scope.clientName,
            DivisionCode: $scope.divisionCode,
            DivisionName: $scope.divisionName,
            ProductCode: $scope.productCode,
            ProductName: $scope.productDescription,
        },
        Job: {
            ClientCode: $scope.clientCode,
            ClientName: $scope.clientName,
            DivisionCode: $scope.divisionCode,
            DivisionName: $scope.divisionName,
            ProductCode: $scope.productCode,
            ProductName: $scope.productDescription,
            JobNumber: $scope.jobNumber,
            JobDescription: $scope.jobDescription,
        },
        JobComponent: {
            ClientCode: $scope.clientCode,
            ClientName: $scope.clientName,
            DivisionCode: $scope.divisionCode,
            DivisionName: $scope.divisionName,
            ProductCode: $scope.productCode,
            ProductName: $scope.productDescription,
            JobNumber: $scope.jobNumber,
            JobDescription: $scope.jobDescription,
            JobComponentNumber: $scope.jobComponentNumber,
            JobComponentDescription: $scope.jobComponentDescription,
        },
        LookupType: '',
        ShowInactive: false,
        SecurityModule: $scope.currentSecurityModule
    };
    $scope.open = function (lookupType) {
        if (!$scope.searchActive) {
            return;
        }
        if ($scope.currentRadWindow === null) {
            $scope.currentRadWindow = $rootScope.getCurrentRadWindow();
        }
        $scope.searchCriteria = {
            Office: {
                ClientCode: $scope.officeCode,
                ClientName: $scope.officeName,
            },
            Client: {
                ClientCode: $scope.clientCode,
                ClientName: $scope.clientName,
            },
            Division: {
                ClientCode: $scope.clientCode,
                ClientName: $scope.clientName,
                DivisionCode: $scope.divisionCode,
                DivisionName: $scope.divisionName,
            },
            Product: {
                ClientCode: $scope.clientCode,
                ClientName: $scope.clientName,
                DivisionCode: $scope.divisionCode,
                DivisionName: $scope.divisionName,
                ProductCode: $scope.productCode,
                ProductName: $scope.productDescription,
            },
            Job: {
                ClientCode: $scope.clientCode,
                ClientName: $scope.clientName,
                DivisionCode: $scope.divisionCode,
                DivisionName: $scope.divisionName,
                ProductCode: $scope.productCode,
                ProductName: $scope.productDescription,
                JobNumber: $scope.jobNumber,
                JobDescription: $scope.jobDescription,
            },
            JobComponent: {
                ClientCode: $scope.clientCode,
                ClientName: $scope.clientName,
                DivisionCode: $scope.divisionCode,
                DivisionName: $scope.divisionName,
                ProductCode: $scope.productCode,
                ProductName: $scope.productDescription,
                JobNumber: $scope.jobNumber,
                JobDescription: $scope.jobDescription,
                JobComponentNumber: $scope.jobComponentNumber,
                JobComponentDescription: $scope.jobComponentDescription,
            },
            LookupType: '',
            ShowInactive: false,
            SecurityModule: $scope.currentSecurityModule
        };

        $scope.lastLookupType = lookupType;

        var currentCriteria = angular.copy($scope.searchCriteria);
        currentCriteria.LookupType = lookupType;

        if (lookupType === 'Function') {
            currentCriteria.Function.FunctionCode = '';
        }
        if (lookupType === 'Client') {
            currentCriteria.JobComponent.ClientCode = '';
        }
        if (lookupType === 'Division') {
            currentCriteria.JobComponent.DivisionCode = '';
        }
        if (lookupType === 'Product') {
            currentCriteria.JobComponent.ProductCode = '';
        }
        if (lookupType === 'Job') {
            currentCriteria.JobComponent.JobNumber = '';
        }
        if (lookupType === 'JobComponent') {
            currentCriteria.JobComponent.JobComponentNumber = '';
        }
        if (lookupType === 'Employee') {
            currentCriteria.Employee.EmployeeCode = '';
        }
        if (lookupType === 'Vendor') {
            currentCriteria.Vendor.VendorCode = '';
        }
        if (lookupType === 'VendorContact') {
            currentCriteria.VendorContact.VendorContactCode = '';
        }
        var oBrowserWnd = $scope.currentRadWindow.BrowserWindow;

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
                var newWindow = oBrowserWnd.radopen("Lookup_Job?LookupType=" + lookupEnumVal + "&LookupSource=0&IncludeClosed=false" + s, null, $rootScope.initialModalDialogWidth, $rootScope.initialModalDialogHeight);
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
            setTimeout(function () {
                var newWindow = oBrowserWnd.radopen("ModalFilterDialog.aspx?LookupType=" + lookupType, null, $rootScope.initialModalDialogWidth, $rootScope.initialModalDialogHeight);
                newWindow.set_modal(true);
                if (newWindow) {
                    var contentWindow = newWindow.get_contentFrame().contentWindow;
                    newWindow.add_pageLoad(function () {
                        contentWindow.initialSearchResults(currentCriteria, $scope);
                    });
                }
            }, 0);
        }

    };
    $scope.processLookupSelection = function (selectedItem) {
        $scope.searchCriteria[selectedItem.ObjectName] = selectedItem;

        if (selectedItem.ObjectName === 'Office') {
            $scope.suppressDefaultDivision = true;
            $scope.suppressDefaultProduct = true;
            $scope.officeCode = selectedItem.OfficeCode;
            $scope.officeName = selectedItem.OfficeName;
        }
        if (selectedItem.ObjectName === 'Client') {
            //$scope.suppressDefaultDivision = true;
            //$scope.suppressDefaultProduct = true;
            $scope.clientCode = selectedItem.ClientCode;
            $scope.clientName = selectedItem.ClientName;
            if ($scope.divisionCode === null || $scope.divisionCode === undefined || $scope.divisionCode === '') {
                $scope.getDefaultDivisionCode()
            }
            if ($scope.productCode === null || $scope.productCode === undefined || $scope.productCode === '') {
                $scope.getDefaultProductCode()
            }
        }
        if (selectedItem.ObjectName === 'Division') {
            //$scope.suppressDefaultDivision = true;
            //$scope.suppressDefaultProduct = true;
            $scope.clientCode = selectedItem.ClientCode;
            $scope.clientName = selectedItem.ClientName;
            $scope.divisionCode = selectedItem.DivisionCode;
            $scope.divisionName = selectedItem.DivisionName;
            if ($scope.divisionCode === null || $scope.divisionCode === undefined || $scope.divisionCode === '') {
                $scope.getDefaultDivisionCode()
            }
            if ($scope.productCode === null || $scope.productCode === undefined || $scope.productCode === '') {
                $scope.getDefaultProductCode()
            }
        }
        if (selectedItem.ObjectName === 'Product') {
            //$scope.suppressDefaultDivision = true;
            //$scope.suppressDefaultProduct = true;
            $scope.clientCode = selectedItem.ClientCode;
            $scope.clientName = selectedItem.ClientName;
            $scope.divisionCode = selectedItem.DivisionCode;
            $scope.divisionName = selectedItem.DivisionName;
            $scope.productCode = selectedItem.ProductCode;
            $scope.productDescription = selectedItem.ProductName;
            if ($scope.divisionCode === null || $scope.divisionCode === undefined || $scope.divisionCode === '') {
                $scope.getDefaultDivisionCode()
            }

            if ($scope.productCode === null || $scope.productCode === undefined || $scope.productCode === '') {
                $scope.getDefaultProductCode()
            }
        }
        if (selectedItem.ObjectName === 'Job') {
            $scope.suppressDefaultDivision = true;
            $scope.suppressDefaultProduct = true;
            $scope.clientCode = selectedItem.ClientCode;
            $scope.clientName = selectedItem.ClientName;
            $scope.divisionCode = selectedItem.DivisionCode;
            $scope.divisionName = selectedItem.DivisionName;
            $scope.productCode = selectedItem.ProductCode;
            $scope.productDescription = selectedItem.ProductName;
            $scope.jobNumber = selectedItem.JobNumber;
            $scope.jobDescription = selectedItem.JobDescription;
            if ($scope.divisionCode === null || $scope.divisionCode === undefined || $scope.divisionCode === '') {
                $scope.getDefaultDivisionCode()
            }

            if ($scope.productCode === null || $scope.productCode === undefined || $scope.productCode === '') {
                $scope.getDefaultProductCode()
            }
        }
        if (selectedItem.ObjectName === 'JobComponent') {
            $scope.suppressDefaultDivision = true;
            $scope.suppressDefaultProduct = true;
            $scope.clientCode = selectedItem.ClientCode;
            $scope.clientName = selectedItem.ClientName;
            $scope.divisionCode = selectedItem.DivisionCode;
            $scope.divisionName = selectedItem.DivisionName;
            $scope.productCode = selectedItem.ProductCode;
            $scope.productDescription = selectedItem.ProductName;
            $scope.jobNumber = selectedItem.JobNumber;
            $scope.jobDescription = selectedItem.JobDescription;
            $scope.jobComponentNumber = selectedItem.JobComponentNumber;
            $scope.jobComponentDescription = selectedItem.JobComponentDescription;
            if ($scope.jobComponentNumber === null || $scope.jobComponentNumber === undefined || $scope.jobComponentNumber === '') {
                $scope.getDefaultJobComponentNumber()
            }

            if ($scope.divisionCode === null || $scope.divisionCode === undefined || $scope.divisionCode === '') {
                $scope.getDefaultDivisionCode()
            }

            if ($scope.productCode === null || $scope.productCode === undefined || $scope.productCode === '') {
                $scope.getDefaultProductCode()
            }
        }

        $timeout(function () {
            if ($scope.lastLookupType === 'Office') {
                if ($('#TextBoxOfficeCode') !== null) {
                    $('#TextBoxOfficeCode').focus();
                }
                if ($('#TextBox_OfficeCode') !== null) {
                    $('#TextBox_OfficeCode').focus();
                }
            }
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

            if ($scope.lastLookupType === 'Job') {
                if ($('#TextBox_JobCode') !== null) {
                    $('#TextBox_JobCode').focus();
                }
            }

            if ($scope.lastLookupType === 'JobComponent') {
                if ($('#TextBox_ComponentCode') !== null) {
                    $('#TextBox_ComponentCode').focus();
                }
            }

        }, 10)

        $scope.$apply();
    };

    $scope.validateLookUps = function () {
        $scope.lookUpValues = {
            OfficeCode: $scope.officeCode,
            ClientCode: $scope.clientCode,
            DivisionCode: $scope.divisionCode,
            ProductCode: $scope.productCode,
            JobNumber: $scope.jobNumber,
            JobComponentNumber: $scope.jobComponentNumber,
        }
        dataService.validateStandardLookUps($scope.lookUpValues).then(function (result) {
            $scope.validationResult = {
                isValid: result.data.IsValid,
                validationMessage: result.data.ValidationMessage
            }
            if ($scope.validationResult.isValid == true) {
                __doPostBack('angularjs', 'Save');
            } else {
                if ($scope.validationResult.validationMessage && $scope.validationResult.validationMessage != '') {
                    showKendoAlert($scope.validationResult.validationMessage);
                }
            }
        });
    }

    $scope.getNameOrDescription = function (lookupType) {
        //console.log("getNameOrDescription")
        var allowLookup = false;

        $timeout.cancel($scope.getNameOrDescriptionPromise);

        switch (lookupType) {
            case "Office":
                if ($scope.officeCode !== null && $scope.officeCode !== undefined && $scope.officeCode !== '') {
                    allowLookup = true;
                }
                break;
            case "Client":
                if ($scope.clientCode !== null && $scope.clientCode !== undefined && $scope.clientCode !== '') {
                    allowLookup = true;
                }
                break;
            case "Division":
                if (($scope.clientCode !== null && $scope.clientCode !== undefined && $scope.clientCode !== '') && ($scope.divisionCode !== null && $scope.divisionCode !== undefined && $scope.divisionCode !== '')) {
                    allowLookup = true;
                }
                break;
            case "Product":
                if (($scope.clientCode !== null && $scope.clientCode !== undefined && $scope.clientCode !== '') && ($scope.divisionCode !== null && $scope.divisionCode !== undefined && $scope.divisionCode !== '') && ($scope.productCode !== null && $scope.productCode !== undefined && $scope.productCode !== '')) {
                    allowLookup = true;
                }
                break;
            case "Job":
                if (isNaN($scope.jobNumber) === false) {
                    allowLookup = true;
                }
                break;
            case "JobComponent":
                if (isNaN($scope.jobNumber) === false && isNaN($scope.jobComponentNumber) === false) {
                    allowLookup = true;
                }
                break;
            default:
                allowLookup = false;
        }

        if (allowLookup === true) {

            if (lookupType === "Office") {

            } else {
                $scope.getNameOrDescriptionPromise = $timeout(function () {
                    $scope.searchCriteria = {
                        JobComponent: {
                            ClientCode: $scope.clientCode,
                            DivisionCode: $scope.divisionCode,
                            ProductCode: $scope.productCode,
                            JobNumber: $scope.jobNumber,
                            JobComponentNumber: $scope.jobComponentNumber
                        },
                        LookupType: lookupType,
                        ShowInactive: false,
                        SecurityModule: $scope.currentSecurityModule
                    };
                    dataService.searchLookup($scope.searchCriteria).then(function (result) {
                        switch (lookupType) {
                            case "Client":
                                if (result.data.Results.length === 1) {
                                    $scope.clientCode = result.data.Results[0].ClientCode;
                                    $scope.clientName = result.data.Results[0].ClientName;
                                } else {
                                    $scope.clientName = '';
                                }
                               //console.log('Cleared from search Client name')
                                $scope.divisionCode = '';
                                $scope.divisionName = '';
                                $scope.productCode = '';
                                $scope.productDescription = '';
                                $scope.jobNumber = '';
                                $scope.jobDescription = '';
                                $scope.jobComponentNumber = '';
                                $scope.jobComponentDescription = '';
                                break;
                            case "Division":
                                if (result.data.Results.length === 1) {
                                    $scope.divisionCode = result.data.Results[0].DivisionCode;
                                    $scope.divisionName = result.data.Results[0].DivisionName;
                                } else {
                                    $scope.productDescription = '';
                                }
                               //console.log('Cleared from search Division name')
                                $scope.productCode = '';
                                $scope.productDescription = '';
                                $scope.jobNumber = ''
                                $scope.jobDescription = '';
                                $scope.jobComponentNumber = '';
                                $scope.jobComponentDescription = '';
                                break;
                            case "Product":
                                if (result.data.Results.length === 1) {
                                    $scope.productCode = result.data.Results[0].ProductCode;
                                    $scope.productDescription = result.data.Results[0].ProductName;
                                } else {
                                    $scope.productDescription = '';
                                }
                               //console.log('Cleared from search Product name')
                                $scope.jobNumber = '';
                                $scope.jobComponentNumber = '';
                                break;
                            case "Job":
                               //console.log('Cleared from search Job name')
                                $scope.jobNumber = '';
                                if (result.data.Results.length === 0) {
                                    dataService.jobOrComponentClosed($scope.searchCriteria).then(function (result) {
                                        if (result.data.Closed === 'true') {
                                            $scope.jobDescription = 'Job/Component Closed';
                                        }
                                    });
                                }
                                if (result.data.Results.length === 1) {
                                    $scope.suppressJobComponentNumber = true;
                                    $scope.clientCode = result.data.Results[0].ClientCode;
                                    $scope.clientName = result.data.Results[0].ClientName;
                                    $scope.divisionCode = result.data.Results[0].DivisionCode;
                                    $scope.divisionName = result.data.Results[0].DivisionName;
                                    $scope.productCode = result.data.Results[0].ProductCode;
                                    $scope.productDescription = result.data.Results[0].ProductName;
                                    $scope.jobNumber = result.data.Results[0].JobNumber;
                                    $scope.jobDescription = result.data.Results[0].JobDescription;
                                }
                                break;
                            case "JobComponent":
                                if (result.data.Results.length === 0) {
                                    dataService.jobOrComponentClosed($scope.searchCriteria).then(function (result) {
                                        if (result.data.Closed === 'true') {
                                            $scope.jobDescription = 'Job/Component Closed';
                                        }
                                    });
                                }
                                if (result.data.Results.length === 1) {
                                    $scope.suppressJobComponentNumber = true;
                                    $scope.clientCode = result.data.Results[0].ClientCode;
                                    $scope.clientName = result.data.Results[0].ClientName;
                                    $scope.divisionCode = result.data.Results[0].DivisionCode;
                                    $scope.divisionName = result.data.Results[0].DivisionName;
                                    $scope.productCode = result.data.Results[0].ProductCode;
                                    $scope.productDescription = result.data.Results[0].ProductName;
                                    $scope.jobNumber = result.data.Results[0].JobNumber;
                                    $scope.jobDescription = result.data.Results[0].JobDescription;
                                    $scope.jobComponentNumber = result.data.Results[0].JobComponentNumber;
                                    $scope.jobComponentDescription = result.data.Results[0].JobComponentDescription;
                                }
                                break;
                        }
                    });
                }, 10);
            }
        }
    };

    $scope.fillJobAndComponent = function (jobNumber, jobComponentNumber) {
        $timeout.cancel($scope.defaultJobSearchPromise);

        $scope.suppressDefaultDivision = true;
        $scope.suppressDefaultProduct = true;

        $scope.defaultJobSearchPromise = $timeout(function () {
            $scope.searchCriteria = {
                JobComponent: {
                    ClientCode: '',
                    DivisionCode: '',
                    ProductCode: '',
                    JobNumber: jobNumber,
                    JobComponentNumber: jobComponentNumber
                },
                LookupType: 'JobComponent',
                ShowInactive: false,
                SecurityModule: $scope.currentSecurityModule
            };

            dataService.searchLookup($scope.searchCriteria).then(function (result) {
                if (result.data.Results.length === 0) {

                    dataService.jobOrComponentClosed($scope.searchCriteria).then(function (result) {
                        if (result.data.Closed === 'true') {
                            $scope.jobDescription = 'Job/Component Closed';
                        }
                    });
                }

                if (result.data.Results.length === 1) {
                    $scope.clientCode = result.data.Results[0].ClientCode;
                    $scope.clientName = result.data.Results[0].ClientName;
                    $scope.divisionCode = result.data.Results[0].DivisionCode;
                    $scope.divisionName = result.data.Results[0].DivisionName;
                    $scope.productCode = result.data.Results[0].ProductCode;
                    $scope.productDescription = result.data.Results[0].ProductName;
                    $scope.jobNumber = result.data.Results[0].JobNumber;
                    $scope.jobDescription = result.data.Results[0].JobDescription;
                    $scope.jobComponentNumber = result.data.Results[0].JobComponentNumber;
                    $scope.jobComponentDescription = result.data.Results[0].JobComponentDescription;

                }
            });
        }, 10);

    };

    $scope.getDefaultDivisionCode = function () {
        $timeout.cancel($scope.defaultDivisionCodePromise);

        if ($scope.suppressDefaultDivision) {
            $scope.suppressDefaultDivision = false;
            return;
        }
        if ($scope.clientCode !== null && $scope.clientCode !== undefined && $scope.clientCode !== '') {
            $scope.defaultDivisionCodePromise = $timeout(function () {
                $scope.searchCriteria = {
                    JobComponent: {
                        ClientCode: $scope.clientCode,
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
                        $scope.clientName = result.data.Results[0].ClientName;
                        $scope.divisionCode = result.data.Results[0].DivisionCode;
                        $scope.divisionName = result.data.Results[0].DivisionName;
                        $scope.getDefaultProductCode();
                        //$scope.productCode = result.data.Results[0].ProductCode;
                    }

                   //console.log('Cleared from default division')
                    $scope.jobNumber = ''
                    $scope.jobComponentNumber = ''

                });
            }, 10);
        }
    };
    $scope.getDefaultProductCode = function () {
        $timeout.cancel($scope.defaultProductCodePromise);
        //if ($scope.suppressDefaultProduct) {
        //    $scope.suppressDefaultProduct = false;
        //    return;
        //}
        if ($scope.divisionCode !== null && $scope.divisionCode !== undefined && $scope.divisionCode !== '') {
            $scope.defaultProductCodePromise = $timeout(function () {
                $scope.searchCriteria = {
                    JobComponent: {
                        ClientCode: $scope.clientCode,
                        DivisionCode: $scope.divisionCode,
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

                        $scope.productCode = result.data.Results[0].ProductCode;
                        $scope.productDescription = result.data.Results[0].ProductName;
                        $scope.divisionName = result.data.Results[0].DivisionName;
                        $scope.clientName = result.data.Results[0].ClientName;
                    }

                   //console.log('Cleared from default product')
                    $scope.jobNumber = ''
                    $scope.jobComponentNumber = '';

                });
            }, 10);
        }
    };
    $scope.getDefaultJobComponentNumber = function (suppressLookups) {
        $timeout.cancel($scope.defaultJobSearchPromise);

        if (suppressLookups) {
            $scope.suppressDefaultDivision = true;
            $scope.suppressDefaultProduct = true;
        }
        if (angular.isNumber(Number($scope.jobNumber)) === true && angular.isNumber($scope.jobComponentNumber) === false) {
            $scope.defaultJobSearchPromise = $timeout(function () {
                $scope.searchCriteria = {
                    JobComponent: {
                        ClientCode: '',
                        DivisionCode: '',
                        ProductCode: '',
                        JobNumber: $scope.jobNumber,
                        JobComponentNumber: ''
                    },
                    LookupType: 'JobComponent',
                    ShowInactive: false,
                    SecurityModule: $scope.currentSecurityModule
                };

                dataService.searchLookup($scope.searchCriteria).then(function (result) {
                    if (result.data.Results.length === 0) {
                        //  $scope.jobDescription = '';
                        //  $scope.jobComponentNumber = '';
                        // $scope.jobComponentDescription = '';

                        dataService.jobOrComponentClosed($scope.searchCriteria).then(function (result) {
                            if (result.data.Closed === 'true') {
                                $scope.jobDescription = 'Job/Component Closed';
                            }
                        });
                    }

                    if (result.data.Results.length === 1) {
                        $scope.clientCode = result.data.Results[0].ClientCode;
                        $scope.clientName = result.data.Results[0].ClientName;
                        $scope.divisionCode = result.data.Results[0].DivisionCode;
                        $scope.divisionName = result.data.Results[0].DivisionName;
                        $scope.productCode = result.data.Results[0].ProductCode;
                        $scope.productDescription = result.data.Results[0].ProductName;
                        $scope.jobNumber = result.data.Results[0].JobNumber;
                        $scope.jobDescription = result.data.Results[0].JobDescription;
                        $scope.jobComponentNumber = result.data.Results[0].JobComponentNumber;
                        $scope.jobComponentDescription = result.data.Results[0].JobComponentDescription;
                    }
                });
            }, 10);
        }
    };

    $scope.clearDescription = function(lookupType) {
        switch (lookupType) {
            case "Office":
                if (!$scope.officeCode || $scope.officeCode === "") {
                    $scope.officeName = "";
                }
                break;
            case "Client":
                if (!$scope.clientCode || $scope.clientCode === "") {
                    $scope.clientName = "";
                    $scope.divisionCode = "";
                    $scope.divisionName = "";
                    $scope.productCode = "";
                    $scope.productDescription = "";
                    $scope.jobNumber = "";
                    $scope.jobDescription = "";
                    $scope.jobComponentNumber = "";
                    $scope.jobComponentDescription = "";
                }
                break;
            case "Division":
                if (!$scope.divisionCode || $scope.divisionCode === "") {
                    $scope.divisionName = "";
                    $scope.productCode = "";
                    $scope.productDescription = "";
                    $scope.jobNumber = "";
                    $scope.jobDescription = "";
                    $scope.jobComponentNumber = "";
                    $scope.jobComponentDescription = "";
                }
                break;
            case "Product":
                if (!$scope.productCode || $scope.productCode === "") {
                    $scope.productDescription = "";
                    $scope.jobNumber = "";
                    $scope.jobDescription = "";
                    $scope.jobComponentNumber = "";
                    $scope.jobComponentDescription = "";
                }
                break;
            case "Job":
                if (!$scope.jobNumber || $scope.jobNumber === "") {
                    $scope.jobDescription = "";
                    $scope.jobDescription = "";
                    $scope.jobComponentNumber = "";
                    $scope.jobComponentDescription = "";
                }
                break;
            case "JobComponent":
                if (!$scope.jobComponentNumber || $scope.jobComponentNumber === "") {
                    $scope.jobComponentDescription = "";
                }
                break;
        }
    }

    $scope.$watch("OfficeCode", function (newVal, oldVal) {
        if (newVal === '' && oldVal !== '') {
            $scope.officeName = '';
            $scope.officeCode = '';
            $scope.clientName = '';
            $scope.divisionCode = '';
            $scope.divisionName = '';
            $scope.productCode = '';
            $scope.productDescription = '';
            $scope.jobNumber = '';
            $scope.jobComponentNumber = '';
            $scope.jobDescription = '';
            $scope.jobComponentDescription = '';
        }

    });
    $scope.$watch("ClientCode", function (newVal, oldVal) {
        if (newVal === '' && oldVal !== '') {
            $scope.clientName = '';
            $scope.divisionCode = '';
            $scope.divisionName = '';
            $scope.productCode = '';
            $scope.productDescription = '';
            $scope.jobNumber = '';
            $scope.jobComponentNumber = '';
            $scope.jobDescription = '';
            $scope.jobComponentDescription = '';
        }

        if (newVal !== '') {
            $scope.getDefaultDivisionCode();
        }

    });
    $scope.$watch("DivisionCode", function (newVal, oldVal) {

        if (newVal === '' && oldVal !== '') {
            $scope.divisionName = '';
            $scope.productCode = '';
            $scope.productDescription = '';
            $scope.jobNumber = '';
            $scope.jobComponentNumber = '';
            $scope.jobDescription = '';
            $scope.jobComponentDescription = '';
        }

        if (newVal !== '') {
            $scope.getDefaultProductCode();
        }

    });
    $scope.$watch("ProductCode", function (newVal, oldVal) {
        if (newVal === '' && oldVal !== '') {
            $scope.productDescription = '';
            $scope.jobNumber = '';
            $scope.jobComponentNumber = '';
            $scope.jobDescription = '';
            $scope.jobComponentDescription = '';
            $scope.divisionName = '';
            $scope.clientName = '';
        }

    });
    $scope.$watch("JobNumber", function (newVal, oldVal) {
        if (newVal === '' && oldVal !== '') {
            $scope.jobComponentNumber = '';
            $scope.jobDescription = '';
            $scope.jobComponentDescription = '';
        }

    });
    $scope.$watch("JobComponentNumber", function (newVal, oldVal) {

        if ($scope.suppressJobComponentNumber) {
            $scope.suppressJobComponentNumber = false;
            return;
        }

        if (newVal !== '' && angular.isNumber(Number($scope.jobNumber)) && angular.isNumber(Number(newVal))) {
            var componentSearchCriteria = {
                JobComponent: {
                    ClientCode: '',
                    DivisionCode: '',
                    ProductCode: '',
                    JobNumber: $scope.jobNumber,
                    JobComponentNumber: newVal
                },
                LookupType: 'JobComponent',
                ShowInactive: false
            };

            dataService.jobOrComponentClosed(componentSearchCriteria).then(function (result) {
                if (result.data.Closed === 'true') {
                    $scope.jobDescription = 'Job/Component Closed';
                }
            });
        } else {
            $scope.jobComponentDescription = '';
        }


    });

});
