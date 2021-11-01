app.controller('timeSheetLookupController', function ($scope, $rootScope, $http, $modal, $timeout, dataService) {
    $scope.FunctionCategory = "";
    $scope.FunctionCategoryDescription = "Sample Value";
    $scope.EmployeeCode = '';
    $scope.defaultJobSearchPromise = null;
    $scope.employeeFunctionSearchPromise = null;
    $scope.defaultDivisionCodePromise = null;
    $scope.defaultProductCodePromise = null;
    $scope.timesheetValidationPromise = null;
    $scope.searchProductNamePromise = null;
    $scope.currentSecurityModule = null
    $scope.timesheetValidationRequest = {};
    $scope.timesheetValidationResult = {
        ValidationPassed: false,
        ErrorMessage: "Please fill out all required fields."
    };
    $scope.TimesheetSettings = {
        CommentsDisplayMode: 'none',
        CommentsRequired: false,
        CommentsRequiredForJob: false,
        CommentsRequiredForApproval: false,
        CommentsRequiredAgencyLevel: false
    };
    $scope.searchAssignmentPromise = null;

    $scope.minimumHeight = 490;
    $scope.firstDayOfWeek = null;

    $scope.searchActive = true;

    $scope.ClientCode = '';
    $scope.ClientName = '';
    $scope.DivisionCode = '';
    $scope.DivisionName = '';
    $scope.ProductCode = '';
    $scope.ProductName = '';
    $scope.JobNumber = '',
    $scope.JobComponentNumber = '';
    $scope.JobDescription = '';
    $scope.JobComponentDescription = '';

    $scope.ProductCategory = '';

    $scope.AlertID = '';
    $scope.AlertSubject = '';

    $scope.SundayComments = '';
    $scope.MondayComments = '';
    $scope.TuesdayComments = '';
    $scope.WednesdayComments = '';
    $scope.ThursdayComments = '';
    $scope.FridayComments = '';
    $scope.SaturdayComments = '';

    $scope.SundayDate = null;
    $scope.SundayHours = 0;
    $scope.MondayHours = 0;
    $scope.TuesdayHours = 0;
    $scope.WednesdayHours = 0;
    $scope.ThursdayHours = 0;
    $scope.FridayHours = 0;
    $scope.SaturdayHours = 0;

    $scope.SundayActive = true;
    $scope.MondayActive = true;
    $scope.TuesdayActive = true;
    $scope.WednesdayActive = true;
    $scope.ThursdayActive = true;
    $scope.FridayActive = true;
    $scope.SaturdayActive = true;

    $scope.currentRadWindow = null;

    $scope.commentsViewActive = false;

    $scope.lastLookupType = '';

    $scope.suppressDefaultDivision = false;
    $scope.suppressDefaultProduct = false;
    $scope.suppressJobComponentNumber = false;

    $scope.searchCriteria = {
        JobComponent: {
            ClientCode: $scope.ClientCode,
            ClientName: $scope.ClientName,
            DivisionCode: $scope.DivisionCode,
            DivisionName: $scope.DivisionName,
            ProductCode: $scope.ProductCode,
            ProductName: $scope.ProductName,
            JobNumber: $scope.JobNumber,
            JobDescription: $scope.JobDescription,
            JobComponentNumber: $scope.JobComponentNumber,
            JobComponentDescription: $scope.JobComponentDescription,
        },
        Function: {
            FunctionCode: '',
            FunctionDescription: '',
        },
        GeneralLedgerAccount: {
            GeneralLedgerCode: '',
            GeneralLedgerDescription: '',
        },
        Employee: {
            EmployeeCode: $scope.EmployeeCode,
        },
        Vendor: {
            VendorCode: '',
        },
        VendorContact: {
            VendorContactCode: '',
        },
        Assignment: {
            JobNumber: $scope.JobNumber,
            JobDescription: $scope.JobDescription,
            JobComponentNumber: $scope.JobComponentNumber,
            JobComponentDescription: $scope.JobComponentDescription,
            AlertID: $scope.AlertID,
            AlertSubject: $scope.AlertSubject,
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
        //console.log("open", $scope.JobNumber)
        $scope.searchCriteria = {
            JobComponent: {
                ClientCode: $scope.ClientCode,
                ClientName: $scope.ClientName,
                DivisionCode: $scope.DivisionCode,
                DivisionName: $scope.DivisionName,
                ProductCode: $scope.ProductCode,
                ProductName: $scope.ProductName,
                JobNumber: $scope.JobNumber,
                JobDescription: $scope.JobDescription,
                JobComponentNumber: $scope.JobComponentNumber,
                JobComponentDescription: $scope.JobComponentDescription,
            },
            Function: {
                FunctionCode: '',
                FunctionDescription: '',
            },
            FunctionCategory: {
                JobCode: $scope.JobNumber
            },
            GeneralLedgerAccount: {
                GeneralLedgerCode: '',
                GeneralLedgerDescription: '',
            },
            Employee: {
                EmployeeCode: $scope.EmployeeCode,
            },
            Vendor: {
                VendorCode: '',
            },
            VendorContact: {
                VendorContactCode: '',
            },
            Assignment: {
                JobNumber: $scope.JobNumber,
                JobDescription: $scope.JobDescription,
                JobComponentNumber: $scope.JobComponentNumber,
                JobComponentDescription: $scope.JobComponentDescription,
                AlertID: $scope.AlertID,
                AlertSubject: $scope.AlertSubject,
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
        if (lookupType === 'Assignment') {
            currentCriteria.Assignment.AlertID = '';
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
                if (currentCriteria.JobComponent.DivisionCode) {
                    s = s + "&d=" + currentCriteria.JobComponent.DivisionCode;
                }
                if (currentCriteria.JobComponent.ProductCode) {
                    s = s + "&p=" + currentCriteria.JobComponent.ProductCode;
                }
                if (currentCriteria.JobComponent.jobNumber) {
                    s = s + "&j=" + currentCriteria.JobComponent.jobNumber;
                } else {
                    s = s + "&j=" + $scope.JobNumber;
                }
                //console.log("ang",s)
                var newWindow = oBrowserWnd.radopen("Lookup_Job?LookupType=" + lookupEnumVal + "&LookupSource=1&IncludeClosed=false" + s, null, $rootScope.initialModalDialogWidth, $rootScope.initialModalDialogHeight);
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
        if (selectedItem.ObjectName === 'JobComponent') {
            $scope.suppressDefaultDivision = true;
            $scope.suppressDefaultProduct = true;
            $scope.ClientCode = selectedItem.ClientCode;
            $scope.ClientName = selectedItem.ClientName;
            $scope.DivisionCode = selectedItem.DivisionCode;
            $scope.DivisionName = selectedItem.DivisionName;
            $scope.ProductCode = selectedItem.ProductCode;
            $scope.ProductName = selectedItem.ProductName;
            $scope.JobNumber = selectedItem.JobNumber;
            $scope.JobDescription = selectedItem.JobDescription;
            $scope.JobComponentNumber = selectedItem.JobComponentNumber;
            $scope.JobComponentDescription = selectedItem.JobComponentDescription;
            if ($scope.JobComponentNumber === null || $scope.JobComponentNumber === undefined || $scope.JobComponentNumber === '') {
                $scope.getDefaultJobComponentNumber()
            }

            if ($scope.DivisionCode === null || $scope.DivisionCode === undefined || $scope.DivisionCode === '') {
                $scope.getDefaultDivisionCode()
            }

            if ($scope.ProductCode === null || $scope.ProductCode === undefined || $scope.ProductCode === '') {
                $scope.getDefaultProductCode()
            }
        }

        if (selectedItem.ObjectName === 'Employee') {
            $('#txtEmpCode').val(selectedItem.EmployeeCode)
            $scope.EmployeeCode = selectedItem.EmployeeCode;
            //$scope.getEmployeeDefaultFunction();
        }

        if (selectedItem.ObjectName === 'FunctionCategory') {
            $scope.FunctionCategory = selectedItem.FunctionCode;
            $scope.FunctionCategoryDescription = selectedItem.FunctionDescription;
        }
        if (selectedItem.ObjectName === 'Assignment') {
            $scope.AlertID = selectedItem.AlertID;
            $scope.AlertSubject = selectedItem.AlertSubject;
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

            if ($scope.lastLookupType === 'FunctionCategory') {
                if ($('#TextBoxFunctionCategoryCode') !== null) {
                    $('#TextBoxFunctionCategoryCode').focus();
                }
                if ($('#TextBox_FunctionCategory') !== null) {
                    $('#TextBox_FunctionCategory').focus();
                }
            }

            if ($scope.lastLookupType === 'Employee') {
                $('#txtEmpCode').focus();
            }

            if ($scope.lastLookupType === 'Assignment') {
                $('#TextBox_Assignment').focus();
            }


        }, 500)
        $scope.$apply();
    };

    $scope.getDefaultJobComponentNumber = function (suppressLookups) {
        $timeout.cancel($scope.defaultJobSearchPromise);

        if (suppressLookups) {
            $scope.suppressDefaultDivision = true;
            $scope.suppressDefaultProduct = true;
        }

        if (angular.isNumber(Number($scope.JobNumber))) {
            $scope.defaultJobSearchPromise = $timeout(function () {
                $scope.searchCriteria = {
                    JobComponent: {
                        ClientCode: '',
                        DivisionCode: '',
                        ProductCode: '',
                        JobNumber: $scope.JobNumber,
                        JobComponentNumber: ''
                    },
                    LookupType: 'JobComponent',
                    ShowInactive: false,
                    SecurityModule: $scope.currentSecurityModule
                };

                dataService.searchLookup($scope.searchCriteria).then(function (result) {
                    if (result.data.Results.length === 0) {
                        //  $scope.JobDescription = '';
                        //  $scope.JobComponentNumber = '';
                        // $scope.JobComponentDescription = '';

                        dataService.jobOrComponentClosed($scope.searchCriteria).then(function (result) {
                            if (result.data.Closed === 'true') {
                                $scope.JobDescription = 'Job/Component Closed';
                            }
                        });
                    }

                    if (result.data.Results.length === 1) {
                        $scope.ClientCode = result.data.Results[0].ClientCode;
                        $scope.ClientName = result.data.Results[0].ClientName;
                        $scope.DivisionCode = result.data.Results[0].DivisionCode;
                        $scope.DivisionName = result.data.Results[0].DivisionName;
                        $scope.ProductCode = result.data.Results[0].ProductCode;
                        $scope.ProductName = result.data.Results[0].ProductName;
                        $scope.JobNumber = result.data.Results[0].JobNumber;
                        $scope.JobDescription = result.data.Results[0].JobDescription;
                        $scope.JobComponentNumber = result.data.Results[0].JobComponentNumber;
                        $scope.JobComponentDescription = result.data.Results[0].JobComponentDescription;
                    }
                });
            }, 800);
        }
    };


    $scope.getJobComponentDescription = function () {
        $timeout.cancel($scope.defaultJobSearchPromise);
        if (angular.isNumber(Number($scope.JobNumber)) && angular.isNumber(Number($scope.JobComponentNumber))) {
            $scope.defaultJobSearchPromise = $timeout(function () {
                $scope.searchCriteria = {
                    JobComponent: {
                        ClientCode: '',
                        DivisionCode: '',
                        ProductCode: '',
                        JobNumber: $scope.JobNumber,
                        JobComponentNumber: $scope.JobComponentNumber
                    },
                    LookupType: 'JobComponent',
                    ShowInactive: false,
                    SecurityModule: $scope.currentSecurityModule
                };

                dataService.searchLookup($scope.searchCriteria).then(function (result) {
                    if (result.data.Results.length === 0) {

                        dataService.jobOrComponentClosed($scope.searchCriteria).then(function (result) {
                            if (result.data.Closed === 'true') {
                                $scope.JobDescription = 'Job/Component Closed';
                            }
                        });
                    }

                    if (result.data.Results.length === 1) {
                        $scope.suppressJobComponentNumber = true;
                        $scope.ClientCode = result.data.Results[0].ClientCode;
                        $scope.ClientName = result.data.Results[0].ClientName;
                        $scope.DivisionCode = result.data.Results[0].DivisionCode;
                        $scope.DivisionName = result.data.Results[0].DivisionName;
                        $scope.ProductCode = result.data.Results[0].ProductCode;
                        $scope.ProductName = result.data.Results[0].ProductName;
                        $scope.JobNumber = result.data.Results[0].JobNumber;
                        $scope.JobDescription = result.data.Results[0].JobDescription;
                        $scope.JobComponentNumber = result.data.Results[0].JobComponentNumber;
                        $scope.JobComponentDescription = result.data.Results[0].JobComponentDescription;
                    }
                });
            }, 800);
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
                            $scope.JobDescription = 'Job/Component Closed';
                        }
                    });
                }

                if (result.data.Results.length === 1) {
                    $scope.ClientCode = result.data.Results[0].ClientCode;
                    $scope.ClientName = result.data.Results[0].ClientName;
                    $scope.DivisionCode = result.data.Results[0].DivisionCode;
                    $scope.DivisionName = result.data.Results[0].DivisionName;
                    $scope.ProductCode = result.data.Results[0].ProductCode;
                    $scope.ProductName = result.data.Results[0].ProductName;
                    $scope.JobNumber = result.data.Results[0].JobNumber;
                    $scope.JobDescription = result.data.Results[0].JobDescription;
                    $scope.JobComponentNumber = result.data.Results[0].JobComponentNumber;
                    $scope.JobComponentDescription = result.data.Results[0].JobComponentDescription;

                }
            });
        }, 800);

    };

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

    $scope.getEmployeeDefaultFunction = function () {
        $timeout.cancel($scope.employeeFunctionSearchPromise);

        if ($scope.EmployeeCode !== null && $scope.EmployeeCode !== undefined && $scope.EmployeeCode !== '') {
            $scope.employeeFunctionSearchPromise = $timeout(function () {
                dataService.searchEmployeeDefaultFunction($scope.EmployeeCode).then(function (result) {
                    $scope.FunctionCategory = result.data.EmployeeDefaultFunction;
                    if ($scope.FunctionCategory && $scope.FunctionCategory !== '') {

                        dataService.searchTimeSheetFunctionCategories({ SearchText: '', JobCode: $scope.JobNumber }).then(function (result) {
                            $scope.employeeFunctionCategories = result.data;
                            for (var i = 0; i < result.data.length; i++) {
                                if (result.data[i].Code === $scope.FunctionCategory) {
                                    $scope.FunctionCategoryDescription = result.data[i].Description;
                                    break;
                                }
                            }
                        });
                    } else {
                        $scope.FunctionCategory = "";
                        $scope.FunctionCategoryDescription = "";
                    }
                });
            }, 250);
        }
    };

    $scope.refreshEmployeeFunctionCategory = function () {
        $timeout.cancel($scope.employeeFunctionSearchPromise);
        if ($scope.EmployeeCode !== null && $scope.EmployeeCode !== undefined && $scope.EmployeeCode !== '') {
            $scope.employeeFunctionSearchPromise = $timeout(function () {
                dataService.searchTimeSheetFunctionCategories({ SearchText: $scope.FunctionCategory, JobCode: $scope.JobNumber }).then(function (result) {
                    $scope.employeeFunctionCategories = result.data;
                    var matchNotFound = true;
                    for (var i = 0; i < result.data.length; i++) {
                        if (result.data[i].Code === $scope.FunctionCategory) {
                            $scope.FunctionCategoryDescription = result.data[i].Description;
                            matchNotFound = false;
                            break;
                        }
                    }

                    if (matchNotFound) {
                        dataService.searchTimeSheetFunctionCategories({ SearchText: $scope.FunctionCategory, JobCode: null }).then(function (result) {
                            for (var j = 0; j < result.data.length; j++) {
                                if (result.data[j].Code === $scope.FunctionCategory) {
                                    $scope.FunctionCategoryDescription = result.data[j].Description;
                                    break;
                                }
                            }
                        });
                    }
                });

            }, 800);
        }
    };

    $scope.openFunctionCategory = function () {
        if (!$scope.searchActive) {
            return;
        }
        var empCode = $("#txtEmpCode").val();
        var jobCode = null;
        if ($scope.searchCriteria.JobComponent !== undefined && $scope.searchCriteria.JobComponent.JobNumber !== undefined) {
            jobCode = $scope.searchCriteria.JobComponent.JobNumber;
        }
        var currentCriteria = { EmployeeCode: empCode, JobCode: jobCode }
        // currentCriteria.SearchLevel = searchLevel;

        var modalInstance = $modal.open({
            animation: true,
            templateUrl: 'app/templates/FunctionCategoryLookupModal.html',
            controller: 'FunctionCategoryLookupModalController',
            size: 'lg',
            resolve: {
                searchCriteria: function () {
                    return currentCriteria;
                }
            }
        });

        modalInstance.result.then(function (selectedItem) {
            $scope.FunctionCategory = selectedItem.Code;
            $scope.FunctionCategoryDescription = selectedItem.Description;
            $scope.EmployeeCode = empCode;
        }, function () {
            //  $log.info('Modal dismissed at: ' + new Date());
        });
    };

    $scope.setDayVisibility = function () {
        try {
            if ($scope.SundayActive === false && $("#TextBox_NewItemSunday").length > 0) {
                $("#TextBox_NewItemSunday").data("kendoNumericTextBox").enable(false);
                $("#TextBox_SundayComments").prop("disabled", true).css("background-color", '#E1E1E1');
            }
        } catch (e) {
        }
        try {
            if ($scope.MondayActive === false && $("#TextBox_NewItemMonday").length > 0) {
                $("#TextBox_NewItemMonday").data("kendoNumericTextBox").enable(false);
                $("#TextBox_MondayComments").prop("disabled", true).css("background-color", '#E1E1E1');
            }
        } catch (e) {
        }
        try {
            if ($scope.TuesdayActive === false && $("#TextBox_NewItemTuesday").length > 0) {
                $("#TextBox_NewItemTuesday").data("kendoNumericTextBox").enable(false);
                $("#TextBox_TuesdayComments").prop("disabled", true).css("background-color", '#E1E1E1');
            }
        } catch (e) {
        }
        try {
            if ($scope.WednesdayActive === false && $("#TextBox_NewItemWednesday").length > 0) {
                $("#TextBox_NewItemWednesday").data("kendoNumericTextBox").enable(false);
                $("#TextBox_WednesdayComments").prop("disabled", true).css("background-color", '#E1E1E1');
            }
        } catch (e) {
        }
        try {
            if ($scope.ThursdayActive === false && $("#TextBox_NewItemThursday").length > 0) {
                $("#TextBox_NewItemThursday").data("kendoNumericTextBox").enable(false);
                $("#TextBox_ThursdayComments").prop("disabled", true).css("background-color", '#E1E1E1');
            }
        } catch (e) {
        }
        try {
            if ($scope.FridayActive === false && $("#TextBox_NewItemFriday").length > 0) {
                $("#TextBox_NewItemFriday").data("kendoNumericTextBox").enable(false);
                $("#TextBox_FridayComments").prop("disabled", true).css("background-color", '#E1E1E1');
            }
        } catch (e) {
        }
        try {
            if ($scope.SaturdayActive === false && $("#TextBox_NewItemSaturday").length > 0) {
                $("#TextBox_NewItemSaturday").data("kendoNumericTextBox").enable(false);
                $("#TextBox_SaturdayComments").prop("disabled", true).css("background-color", '#E1E1E1');
            }
        } catch (e) {
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

    $scope.$watch("JobNumber", function (newVal, oldVal) {
        if (newVal === '' && oldVal !== '') {
            $scope.JobComponentNumber = '';
            $scope.JobDescription = '';
            $scope.JobComponentDescription = '';
        }

        if (newVal !== '') {
            $scope.getTimesheetSettings();
        }

    });

    $scope.$watch("JobComponentNumber", function (newVal, oldVal) {

        if ($scope.suppressJobComponentNumber) {
            $scope.suppressJobComponentNumber = false;
            return;
        }

        if (newVal !== '' && angular.isNumber(Number($scope.JobNumber)) && angular.isNumber(Number(newVal))) {
            var componentSearchCriteria = {
                JobComponent: {
                    ClientCode: '',
                    DivisionCode: '',
                    ProductCode: '',
                    JobNumber: $scope.JobNumber,
                    JobComponentNumber: newVal
                },
                LookupType: 'JobComponent',
                ShowInactive: false
            };

            dataService.jobOrComponentClosed(componentSearchCriteria).then(function (result) {
                if (result.data.Closed === 'true') {
                    $scope.JobDescription = 'Job/Component Closed';
                }
            });
        } else {
            $scope.JobComponentDescription = '';
        }


    });

    $scope.$watch("EmployeeCode", function (newVal, oldVal) {
        if (newVal !== '') {
            //  $scope.getEmployeeDefaultFunction();
        }

    });

    $scope.$watch("FunctionCategory", function (newVal, oldVal) {
        if (newVal === '') {
            $scope.FunctionCategoryDescription = '';
        }

    });
    $scope.$watch("Assignment", function (newVal, oldVal) {

    });

    $scope.$watch("SundayHours", function (newVal, oldVal) {

    });

    $scope.$watch("SundayComments", function (newVal, oldVal) {

    });

    $scope.$watch("MondayHours", function (newVal, oldVal) {

    });

    $scope.$watch("MondayComments", function (newVal, oldVal) {

    });

    $scope.$watch("TuesdayHours", function (newVal, oldVal) {

    });

    $scope.$watch("TuesdayComments", function (newVal, oldVal) {

    });

    $scope.$watch("WednesdayHours", function (newVal, oldVal) {

    });

    $scope.$watch("WednesdayComments", function (newVal, oldVal) {

    });

    $scope.$watch("ThursdayHours", function (newVal, oldVal) {

    });

    $scope.$watch("ThursdayComments", function (newVal, oldVal) {

    });

    $scope.$watch("FridayHours", function (newVal, oldVal) {

    });

    $scope.$watch("FridayComments", function (newVal, oldVal) {

    });

    $scope.$watch("SaturdayHours", function (newVal, oldVal) {

    });

    $scope.$watch("SaturdayComments", function (newVal, oldVal) {

    });

    $scope.validateCurrentTimesheetEntry = function () {
        $timeout.cancel($scope.timesheetValidationPromise);

        var currentDepartment = '';

        $scope.timesheetValidationPromise = $timeout(function () {
            currentDepartment = $("[id$='ComboBox_Department'] > select").val();
            if ($scope.commentsViewActive) {
                $scope.timesheetValidationRequest = {
                    EmployeeCode: $scope.EmployeeCode,
                    Department: currentDepartment,
                    Client: $scope.ClientCode,
                    Division: $scope.DivisionCode,
                    Product: $scope.ProductCode,
                    Job: $scope.JobNumber,
                    JobComponent: $scope.JobComponentNumber,
                    FunctionCategory: $scope.FunctionCategory,
                    ProductCategory: $('#TextBoxProductCategory').val(),
                    ProductCategoryVisible: $('#TextBoxProductCategory').length > 0,
                    AlertID: $scope.AlertID,
                    MondayHours: $('#TxtMondayHours').val(),
                    TuesdayHours: $('#TxtTuesdayHours').val(),
                    WednesdayHours: $('#TxtWednesdayHours').val(),
                    ThursdayHours: $('#TxtThursdayHours').val(),
                    FridayHours: $('#TxtFridayHours').val(),
                    SaturdayHours: $('#TxtSaturdayHours').val(),
                    SundayHours: $('#TxtSundayHours').val(),
                    SundayDate: $scope.SundayDate,
                    MondayComments: $('#TxtMondayComments').val(),
                    TuesdayComments: $('#TxtTuesdayComments').val(),
                    WednesdayComments: $('#TxtWednesdayComments').val(),
                    ThursdayComments: $('#TxtThursdayComments').val(),
                    FridayComments: $('#TxtFridayComments').val(),
                    SaturdayComments: $('#TxtSaturdayComments').val(),
                    SundayComments: $('#TxtSundayComments').val()
                };
                if ($scope.timesheetValidationRequest.SundayDate === '' || $scope.timesheetValidationRequest.SundayDate === null) {
                    $scope.timesheetValidationRequest.SundayDate = $scope.firstDayOfWeek;
                }
            }
            else {
                $scope.timesheetValidationRequest = {
                    EmployeeCode: $scope.EmployeeCode,
                    Department: currentDepartment,
                    Client: $scope.ClientCode,
                    Division: $scope.DivisionCode,
                    Product: $scope.ProductCode,
                    Job: $scope.JobNumber,
                    JobComponent: $scope.JobComponentNumber,
                    FunctionCategory: $scope.FunctionCategory,
                    ProductCategory: $('#TextBox_ProductCategory').val(),
                    ProductCategoryVisible: $('#TextBox_ProductCategory').length > 0,
                    AlertID: $scope.AlertID,
                    MondayHours: $('#TextBox_NewItemMonday').val(),
                    TuesdayHours: $('#TextBox_NewItemTuesday').val(),
                    WednesdayHours: $('#TextBox_NewItemWednesday').val(),
                    ThursdayHours: $('#TextBox_NewItemThursday').val(),
                    FridayHours: $('#TextBox_NewItemFriday').val(),
                    SaturdayHours: $('#TextBox_NewItemSaturday').val(),
                    SundayHours: $('#TextBox_NewItemSunday').val(),
                    SundayDate: $("input[id$='RadDatePickerStartDate_dateInput']").val(),
                    MondayComments: $scope.MondayComments,
                    TuesdayComments: $scope.TuesdayComments,
                    WednesdayComments: $scope.WednesdayComments,
                    ThursdayComments: $scope.ThursdayComments,
                    FridayComments: $scope.FridayComments,
                    SaturdayComments: $scope.SaturdayComments,
                    SundayComments: $scope.SundayComments,
                };
            }



            dataService.validateTimesheetEntry($scope.timesheetValidationRequest).then(function (result) {
                $scope.timesheetValidationResult = result.data;

                if (result.data.ValidationPassed == undefined) {
                    if ($scope.currentRadWindow === null) {
                        $scope.currentRadWindow = $rootScope.getCurrentRadWindow();
                    }

                    $scope.currentRadWindow.reload();
                }
                else {
                    if ($scope.timesheetValidationResult.ValidationPassed) {
                        __doPostBack('InsertTimesheetRow', 'angularjs');
                    } else {
                        showKendoAlert($scope.timesheetValidationResult.ErrorMessage);
                    }
                }
            });
        }, 800);
    };

    $scope.getTimesheetSettings = function () {
        var timesheetSearchCriteria = {
            JobComponent: {
                ClientCode: $scope.ClientCode,
                ClientName: $scope.ClientName,
                DivisionCode: $scope.DivisionCode,
                DivisionName: $scope.DivisionName,
                ProductCode: $scope.ProductCode,
                ProductName: $scope.ProductName,
                JobNumber: $scope.JobNumber,
                JobDescription: $scope.JobDescription,
                JobComponentNumber: $scope.JobComponentNumber,
                JobComponentDescription: $scope.JobComponentDescription,
            },
            Function: {
                FunctionCode: '',
                FunctionDescription: '',
            },
            GeneralLedgerAccount: {
                GeneralLedgerCode: '',
                GeneralLedgerDescription: '',
            },
            Employee: {
                EmployeeCode: $scope.EmployeeCode,
            },
            Vendor: {
                VendorCode: '',
            },
            VendorContact: {
                VendorContactCode: '',
            },
            Assignment: {
                AlertID: '',
                AlertSubject: '',
            },
            LookupType: '',
            ShowInactive: false,
            SecurityModule: $scope.currentSecurityModule
        };
        dataService.timesheetSettings(timesheetSearchCriteria).then(function (result) {
            $scope.TimesheetSettings = result.data;
        });
    };

    $scope.showCommentBoxes = function () {
        return $scope.TimesheetSettings.CommentsDisplayMode == 'textbox' || ($scope.TimesheetSettings.CommentsRequired)
    };

    $scope.filterRange = function (lineItem) {
        if (lineItem < -24) {
            return 0;
        }

        if (lineItem > 24) {
            return 24
        }

        return lineItem;
    }

    $scope.refreshGridTotals = function (callingElement) {

        if ($scope.commentsViewActive) {
            return;
        }

        //var SundayTextBoxes = $(".timesheet-day-hours-textbox[id$='Sunday']")
        //var SundayTotal = 0;
        //for (var textBoxIndex = 0; textBoxIndex < SundayTextBoxes.length; textBoxIndex++) {
        //    if (isNaN($(SundayTextBoxes[textBoxIndex]).val()) === false) {
        //        var currentLineItem = parseFloat($(SundayTextBoxes[textBoxIndex]).val());
        //        SundayTotal += $scope.filterRange(currentLineItem);
        //    }
        //}

        //$('#SundayFooterTotal').text(SundayTotal.toFixed(2));

        //var MondayTextBoxes = $(".timesheet-day-hours-textbox[id$='Monday']")
        //var MondayTotal = 0;
        //for (var textBoxIndex = 0; textBoxIndex < MondayTextBoxes.length; textBoxIndex++) {
        //    if (isNaN($(MondayTextBoxes[textBoxIndex]).val()) === false) {
        //        var currentLineItem = parseFloat($(MondayTextBoxes[textBoxIndex]).val());
        //        MondayTotal += $scope.filterRange(currentLineItem);
        //    }
        //}

        //$('#MondayFooterTotal').text(MondayTotal.toFixed(2));

        //var TuesdayTextBoxes = $(".timesheet-day-hours-textbox[id$='Tuesday']")
        //var TuesdayTotal = 0;
        //for (var textBoxIndex = 0; textBoxIndex < TuesdayTextBoxes.length; textBoxIndex++) {
        //    if (isNaN($(TuesdayTextBoxes[textBoxIndex]).val()) === false) {
        //        var currentLineItem = parseFloat($(TuesdayTextBoxes[textBoxIndex]).val());
        //        TuesdayTotal += $scope.filterRange(currentLineItem);
        //    }
        //}

        //$('#TuesdayFooterTotal').text(TuesdayTotal.toFixed(2));
        
        //var WednesdayTextBoxes = $(".timesheet-day-hours-textbox[id$='Wednesday']")
        //var WednesdayTotal = 0;
        //for (var textBoxIndex = 0; textBoxIndex < WednesdayTextBoxes.length; textBoxIndex++) {
        //    if (isNaN($(WednesdayTextBoxes[textBoxIndex]).val()) === false) {
        //        var currentLineItem = parseFloat($(WednesdayTextBoxes[textBoxIndex]).val());
        //        WednesdayTotal += $scope.filterRange(currentLineItem);
        //    }
        //}

        //$('#WednesdayFooterTotal').text(WednesdayTotal.toFixed(2));

        //var ThursdayTextBoxes = $(".timesheet-day-hours-textbox[id$='Thursday']")
        //var ThursdayTotal = 0;
        //for (var textBoxIndex = 0; textBoxIndex < ThursdayTextBoxes.length; textBoxIndex++) {
        //    if (isNaN($(ThursdayTextBoxes[textBoxIndex]).val()) === false) {
        //        var currentLineItem = parseFloat($(ThursdayTextBoxes[textBoxIndex]).val());
        //        ThursdayTotal += $scope.filterRange(currentLineItem);
        //    }
        //}

        //$('#ThursdayFooterTotal').text(ThursdayTotal.toFixed(2));

        //var FridayTextBoxes = $(".timesheet-day-hours-textbox[id$='Friday']")
        //var FridayTotal = 0;
        //for (var textBoxIndex = 0; textBoxIndex < FridayTextBoxes.length; textBoxIndex++) {
        //    if (isNaN($(FridayTextBoxes[textBoxIndex]).val()) === false) {
        //        var currentLineItem = parseFloat($(FridayTextBoxes[textBoxIndex]).val());
        //        FridayTotal += $scope.filterRange(currentLineItem);
        //    }
        //}

        //$('#FridayFooterTotal').text(FridayTotal.toFixed(2));

        //var SaturdayTextBoxes = $(".timesheet-day-hours-textbox[id$='Saturday']")
        //var SaturdayTotal = 0;
        //for (var textBoxIndex = 0; textBoxIndex < SaturdayTextBoxes.length; textBoxIndex++) {
        //    if (isNaN($(SaturdayTextBoxes[textBoxIndex]).val()) === false) {
        //        var currentLineItem = parseFloat($(SaturdayTextBoxes[textBoxIndex]).val());
        //        SaturdayTotal += $scope.filterRange(currentLineItem);
        //    }
        //}

        //$('#SaturdayFooterTotal').text(SaturdayTotal.toFixed(2));

        //var GrandTotal = SundayTotal + MondayTotal + TuesdayTotal + WednesdayTotal + ThursdayTotal + FridayTotal + SaturdayTotal;

        //$('#WeekGrandTotal').text(GrandTotal.toFixed(2));

        //if (callingElement !== null && $(callingElement).attr('class').indexOf('timesheet-day-hours-textbox') > -1) {
        //    //  alert($(callingElement).val());
        //    var parentRow = $(callingElement).closest('tr');

        //    var matchingBoxes = $(parentRow).find('.k-formatted-value');
        //    var hoursTotal = 0.0
        //    for (var boxIndex = 0; boxIndex < matchingBoxes.length; boxIndex++) {
        //        if (isNaN($(matchingBoxes[boxIndex]).val()) === false) {
        //            var currentEntry = parseFloat($(matchingBoxes[boxIndex]).val());
        //            hoursTotal += $scope.filterRange(currentEntry);
        //        }
        //    }

        //    $(parentRow).find("span[id*='lblTotalHours']").text(hoursTotal.toFixed(2));
        //}
    };

    $scope.refreshGridTotals(null);
    $scope.refreshEmployeeFunctionCategory();
    $scope.getTimesheetSettings();
});
