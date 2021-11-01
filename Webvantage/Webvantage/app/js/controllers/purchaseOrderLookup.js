app.controller('purchaseOrderLookupController', function ($scope, $rootScope, $http, $modal, $timeout, dataService) {
    $scope.searchCriteria = { JobComponent: {}, Function: {}, GeneralLedgerAccount: {}, LookupType: "", ShowInactive: false, SecurityModule: "" };
    $scope.parentRow = {};
    $scope.searchPromise = null;
    $scope.currentRadWindow = null;
    $scope.jobComponentLookupPromise = null;

    $scope.getInput = function (inputType) {
        var inputControl;
        if (inputType === 'Employee' || inputType === 'Vendor' || inputType === 'VendorContact') {
            inputControl = $('input[adv-lookup=' + inputType + ']')[0];
        } else if ($scope.parentRow) {
            inputControl = $($scope.parentRow).find('input[adv-lookup=' + inputType + ']')[0];
        } else if(!$scope.parentRow) {
            inputControl = $('input[adv-lookup=' + inputType + ']')[0];
        }
        return inputControl;
    }
    $scope.getNumericInput = function (inputType) {
        var inputControl;
        var radInput;
        if ($scope.parentRow) {
            inputControl = $($scope.parentRow).find('input[adv-calc=' + inputType + ']')[0];
        } else {
            inputControl = $(document).find('input[adv-calc=' + inputType + ']')[0];
        }
        if (inputControl) {
            radInput = $find($(inputControl).attr('id'));
        }
        return radInput;
    }
    $scope.getDescriptionInput = function (inputType) {
        var inputControl;
        if (inputType === 'Employee' || inputType === 'Vendor' || inputType === 'VendorContact') {
            inputControl = $('input[adv-desc=' + inputType + ']')[0];
        } else if ($scope.parentRow) {
            inputControl = $($scope.parentRow).find('input[adv-desc=' + inputType + ']')[0];
        }
        if (!inputControl) {
            inputControl = $('input[adv-desc=' + inputType + ']')[0];
        }
        return inputControl;
    }
    $scope.enableOrDisableInput = function (inputType, disabled) {
        var input = $scope.getInput(inputType);
        if (input) {
            $(input).prop('disabled', disabled);
        }
    }
    /*
     * Getters
     */
    $scope.getClientCode = function () {
        return $scope.getInputValue('Client');
    };
    $scope.getClientName = function () {
        return $scope.getDescriptionInputValue('Client');
    };
    $scope.getDivisionCode = function () {
        return $scope.getInputValue('Division');
    };
    $scope.getDivisionName = function () {
        return $scope.getDescriptionInputValue('Division');
    };
    $scope.getProductCode = function () {
        return $scope.getInputValue('Product');
    };
    $scope.getProductName = function () {
        return $scope.getDescriptionInputValue('Product');
    };
    $scope.getJobNumber = function () {
        return $scope.getInputValue('Job');
    };
    $scope.getJobDescription = function () {
        return $scope.getDescriptionInputValue('Job');
    };
    $scope.getJobComponentNumber = function () {
        return $scope.getInputValue('JobComponent');
    };
    $scope.getJobComponentDescription = function () {
        return $scope.getDescriptionInputValue('JobComponent');
    };
    $scope.getFunctionCode = function () {
        return $scope.getInputValue('Function');
    };
    $scope.getFunctionDescription = function () {
        return $scope.getDescriptionInputValue('Function');
    };
    $scope.getGeneralLedgerCode = function () {
        return $scope.getInputValue('GeneralLedgerAccount');
    };
    $scope.getGeneralLedgerDescription = function () {
        return $scope.getDescriptionInputValue('GeneralLedgerAccount');
    };
    $scope.getEmployeeCode = function () {
        return $('#TextBoxEmployeeCode').val();
    };
    $scope.getVendorCode = function () {
        return $('#TextBoxVendorCode').val();
    };
    $scope.getVendorContactCode = function () {
        return $('#TextBoxVendorContactCode').val();
    };
    $scope.getQuantity = function () {
        return $scope.getNumericInputValue('Quantity');
    };
    $scope.getRate = function () {
        return $scope.getNumericInputValue('Rate');
    };
    $scope.getAmount = function () {
        return $scope.getNumericInputValue('ExtendedAmount');
    };
    $scope.getCommissionPercent = function () {
        return $scope.getNumericInputValue('CommissionPercent');
    };
    $scope.getCommissionAmount = function () {
        return $scope.getNumericInputValue('ExtendedMarkupAmount');
    };
    $scope.getLineTotal = function () {
        return $scope.getNumericInputValue('LineTotal');
    };
    $scope.getIsCPM = function () {
        return $($scope.parentRow).find('div[id*=divCPM]').css('display') === "none" ? false : true;
    };
    // common
    $scope.getInputValue = function (inputType) {
        var input = $scope.getInput(inputType);
        var value;
        if (input) {
            value = $(input).val();
        }
        return value;
    };
    $scope.getNumericInputValue = function (inputType) {
        var numericInput = $scope.getNumericInput(inputType);
        var value;
        if (numericInput) {
            value = numericInput.get_value();
        }
        return value;
    }
    $scope.getDescriptionInputValue = function (inputType) {
        var descriptionInput = $scope.getDescriptionInput(inputType);
        var value;
        if (descriptionInput) {
            value = $(descriptionInput).val();
        }
        return value;
    }
    /*
     * Setters
     */
    $scope.setClientCode = function (value) {
        $scope.setInputValue('Client', value);
    };
    $scope.setClientName = function (value) {
        $scope.setDescriptionInputValue('Client', value);
    };
    $scope.setDivisionCode = function (value) {
        $scope.setInputValue('Division', value);
    };
    $scope.setDivisionName = function (value) {
        $scope.setDescriptionInputValue('Division', value);
    };
    $scope.setProductCode = function (value) {
        $scope.setInputValue('Product', value);
    };
    $scope.setProductName = function (value) {
        $scope.setDescriptionInputValue('Product', value);
    };
    $scope.setJobNumber = function (value) {
        $scope.setInputValue('Job', value);
    };
    $scope.setJobDescription = function (value) {
        $scope.setDescriptionInputValue('Job', value);
    };
    $scope.setJobComponentNumber = function (value) {
        $scope.setInputValue('JobComponent', value);
    };
    $scope.setJobComponentDescription = function (value) {
        $scope.setDescriptionInputValue('JobComponent', value);
    };
    $scope.setFunctionCode = function (value) {
        $scope.setInputValue('Function', value);
    };
    $scope.setFunctionDescription = function (value) {
        $scope.setDescriptionInputValue('Function', value);
    };
    $scope.setGeneralLedgerCode = function (value) {
        $scope.setInputValue('GeneralLedgerAccount', value);
    };
    $scope.setGeneralLedgerAccountDescription = function (value) {
        $scope.setDescriptionInputValue('GeneralLedgerAccount', value);
    };
    $scope.setQuantity = function (value) {
        $scope.setNumericInputValue('Quantity', value);
    }
    $scope.setRate = function (value) {
        $scope.setNumericInputValue('Rate', value);
    };
    $scope.setAmount = function (value) {
        $scope.setNumericInputValue('ExtendedAmount', value);
    };
    $scope.setCommissionPercent = function (value) {
        $scope.setNumericInputValue('CommissionPercent', value);
    };
    $scope.setCommissionAmount = function (value) {
        $scope.setNumericInputValue('ExtendedMarkupAmount', value);
    };
    $scope.setLineTotal = function (value) {
        $scope.setNumericInputValue('LineTotal', value);
    };
    $scope.setVendorCode = function (value) {
        $('#TextBoxVendorCode').val(value);
    };
    $scope.setVendorName = function (value) {
        $scope.setDescriptionInputValue('Vendor', value);
    };
    $scope.setVendorContactCode = function (value) {
        $('#TextBoxVendorContactCode').val(value);
    };
    $scope.setVendorContactName = function (value) {
        $scope.setDescriptionInputValue('VendorContact', value);
    };
    $scope.setVendorContactEmail = function (value) {
        $scope.setDescriptionInputValue('VendorContactEmail', value);
    };
    $scope.setEmployeeCode = function (value) {
        $('#TextBoxEmployeeCode').val(value);
    }
    $scope.setEmployeeName = function (value) {
        $scope.setDescriptionInputValue('Employee', value);
    };
    // common
    $scope.setInputValue = function (inputID, value) {
        var input = $scope.getInput(inputID);
        if (input) {
            $(input).val(value);
        }
    };
    $scope.setDescriptionInputValue = function (inputID, value) {
        var input = $scope.getDescriptionInput(inputID);
        if (input) {
            $(input).val(value);
        }
    }
    $scope.setNumericInputValue = function (inputID, value) {
        var numericInput = $scope.getNumericInput(inputID);
        if (numericInput) {
            numericInput.set_value(value);
        }
    };

    /*
     * Methods
     */
    $scope.openFilterDialog = function (element) {
        //$scope.parentRow = $(element).closest('tr');
        var lookupType = $(element).attr('adv-lookup');
         if (lookupType != null) {
            $scope.open(lookupType);
        }
    };

    $scope.getSearchCriteria = function (lookupType) {
        var SearchOptions = [];

        if (lookupType == 'Vendor') {
            SearchOptions = [{ Type: "checkbox", Name: "POInlcudeMediaVendors", ID: "POInlcudeMediaVendors", Text: "Include Media Vendors", NgChange: "POFilterVendors()"  }];
        };

        $scope.searchCriteria = {
            JobComponent: {
                ClientCode: $scope.getClientCode(),
                ClientName: $scope.getClientName(),
                DivisionCode: $scope.getDivisionCode(),
                DivisionName: $scope.getDivisionName(),
                ProductCode: $scope.getProductCode(),
                ProductName: $scope.getProductName(),
                JobNumber: $scope.getJobNumber(),
                JobDescription: $scope.getJobDescription(),
                JobComponentNumber: $scope.getJobComponentNumber(),
                JobComponentDescription: $scope.getJobComponentDescription()
            },
            Function: {
                FunctionCode: $scope.getFunctionCode(),
                FunctionDescription: $scope.getFunctionDescription()
            },
            GeneralLedgerAccount: {
                GeneralLedgerCode: $scope.getGeneralLedgerCode(),
                GeneralLedgerDescription: $scope.getGeneralLedgerDescription(),
            },
            Employee: {
                EmployeeCode: $scope.getEmployeeCode()
            },
            Vendor: {
                VendorCode: $scope.getVendorCode(),
                IncludeMediaVendors: false
            },
            VendorContact: {
                VendorContactCode: $scope.getVendorContactCode()
            },
            LookupType: lookupType,
            ShowInactive: false,
            SecurityModule: $('#HiddenFieldSecMod').val(),
            SearchOptions: SearchOptions
            };
        return $scope.searchCriteria;
    };
    
    $scope.processLookupSelection = function (selectedItem) {
        $scope.searchCriteria[selectedItem.ObjectName] = selectedItem;
        if (selectedItem.ObjectName == 'JobComponent') {
            $scope.jobComponentValuesChanged(selectedItem, true);
        }
        if (selectedItem.ObjectName == 'Function') {
            $scope.functionValuesChanged(selectedItem, true);
        }
        if (selectedItem.ObjectName == 'Employee') {
            $scope.employeeValuesChanged(selectedItem, false);
        }
        if (selectedItem.ObjectName == 'Vendor') {
            $scope.vendorValuesChanged(selectedItem, true);
        }
        if (selectedItem.ObjectName == 'VendorContact') {
            $scope.vendorContactValuesChanged(selectedItem, false);
        }
        if (selectedItem.ObjectName == 'GeneralLedgerAccount') {
            $scope.generalLedgerAccountValuesChanged(selectedItem, false);
        }
    };

    $scope.open = function (lookupType) {
        var currentCriteria = $scope.getSearchCriteria(lookupType);
        var queryString = 'LookupType=' + lookupType;
        if (lookupType == 'Function') {
            currentCriteria.Function.FunctionCode = '';
        }
        if (lookupType == 'Client') {
            currentCriteria.JobComponent.ClientCode = '';
        }
        if (lookupType == 'Division') {
            currentCriteria.JobComponent.DivisionCode = '';
        }
        if (lookupType == 'Product') {
            currentCriteria.JobComponent.ProductCode = '';
        }
        if (lookupType == 'Job') {
            currentCriteria.JobComponent.JobNumber = '';
        }
        if (lookupType == 'JobComponent') {
            currentCriteria.JobComponent.JobComponentNumber = '';
        }
        if (lookupType == 'Employee') {
            currentCriteria.Employee.EmployeeCode = '';
        }
        if (lookupType == 'Vendor') {
            currentCriteria.Vendor.VendorCode = '';
        }
        if (lookupType == 'VendorContact') {
            currentCriteria.VendorContact.VendorContactCode = '';
            queryString += "&ShowAddEdit=1";
        }
        if (lookupType == 'GeneralLedgerAccount') {
            currentCriteria.GeneralLedgerAccount.GeneralLedgerCode = '';
        }

        if ($scope.currentRadWindow === null) {
            $scope.currentRadWindow = $rootScope.getCurrentRadWindow();
        }

        OpenRadWindowLookup2("ModalFilterDialog.aspx?" + queryString, currentCriteria, $scope);

        //var oBrowserWnd = $scope.currentRadWindow.BrowserWindow;
        //var baseWindowHeight = 635;
        //baseWindowHeight = baseWindowHeight + (currentCriteria.SearchOptions.length * 20);
        //setTimeout(function () {
        //    var newWindow = oBrowserWnd.radopen("ModalFilterDialog.aspx?" + queryString, null, 540, baseWindowHeight);
        //    newWindow.set_modal(true);
        //    if (newWindow) {
        //        var contentWindow = newWindow.get_contentFrame().contentWindow;
        //        newWindow.add_pageLoad(function () {
        //            contentWindow.initialSearchResults(currentCriteria, $scope);
        //        });
        //    }
        //}, 0);
    };

    $scope.jobComponentValuesChanged = function (JobComponent, newVal) {
        $timeout.cancel($scope.jobComponentLookupPromise);
        var lookupType;
        if (newVal) {
            if (!JobComponent.ClientCode || !JobComponent.DivisionCode || !JobComponent.ProductCode || !JobComponent.JobNumber || !JobComponent.JobComponentNumber) {
                if (JobComponent.JobNumber) { //backfill job/comp fields
                    if (JobComponent.JobComponentNumber) {
                        lookupType = 'JobComponent';
                    } else if (!JobComponent.ClientCode || !JobComponent.DivisionCode || !JobComponent.ProductCode) {
                        lookupType = 'Job';
                    } else {
                        lookupType = 'JobComponent'
                    }
                } else if (!JobComponent.DivisionCode) {
                    if (!JobComponent.ClientName) {
                        lookupType = 'Client';
                    } else {
                        lookupType = 'Division';
                    }
                } else if (!JobComponent.ProductCode) {
                    if (!JobComponent.DivisionName) {
                        lookupType = 'Division';
                    } else {
                        lookupType = 'Product';
                    }
                } else if (!JobComponent.JobNumber) {
                    if (!JobComponent.ProductName) {
                        lookupType = 'Product';
                    } else {
                        lookupType = 'Job';
                    }
                } else if (!JobComponent.JobComponentNumber) {
                    if (!JobComponent.JobDescription) {
                        lookupType = 'Job';
                    } else {
                        lookupType = 'JobComponent';
                    }
                }
            } 
        }
        if (lookupType) {
            $scope.jobComponentLookupPromise = $timeout(function () {
                $scope.searchCriteria.LookupType = lookupType;
                $scope.searchCriteria.JobComponent = JobComponent;
                dataService.searchLookup($scope.searchCriteria).then(function (result) {
                    if (result.data.Results.length == 1) {
                        $scope.jobComponentValuesChanged(result.data.Results[0], true);
                    } else {
                        $scope.fillJobComponentValues(JobComponent);
                        $scope.focusNextControl('JobComponent');
                    }
                });
            }, 500);
        } else {
            $scope.fillJobComponentValues(JobComponent);
            if (newVal) {
                $scope.focusNextControl('JobComponent');
            }
        }
    }

    $scope.focusNextControl = function (level) {
        var nextControl;
        if (level === 'JobComponent' || level === 'Client' || level === 'Division' || level === 'Product' || level === 'Job') {
            if (!$scope.getClientCode()) {
                nextControl = 'Client';
            } else if (!$scope.getDivisionCode()) {
                nextControl = 'Division'; 
            } else if (!$scope.getProductCode()) {
                nextControl = 'Product';
            } else if (!$scope.getJobNumber()) {
                nextControl = 'Job';
            } else if (!$scope.getJobComponentNumber()) {
                nextControl = 'JobComponent';
            } else {
                nextControl = 'Function';
            }
        } else {
            if (!$scope.getInputValue(level)) {
                nextControl = level;
            } else {
                var input = $scope.getInput(level);
                if (input) {
                    if ($($scope.parentRow).is('tr') === true) {
                        var cell = $(input).closest('td');
                        var row = $(cell).closest('tr');
                        var tdIndex = $(cell).index();
                        var nextInput = $(row).find('td').filter(function () {
                            return $(this).index() > tdIndex;
                        }).find('input[type=text]:enabled')[0];
                        if (nextInput) {
                            setTimeout(function() { nextInput.focus() }, 100);
                        }
                    } else {
                        var tabIndex = $(input).attr('tabindex');
                        var nextInput = $('input[type=text]:enabled').filter(function () {
                            return Number($(this).attr("tabindex")) > tabIndex;
                        })[0].focus();
                    }
                }
            }
        }
        if (nextControl) {
            setTimeout(function () {
                var nxtCtrl = $scope.getInput(nextControl);
                if (nxtCtrl) {
                    nxtCtrl.focus();
                }
            }, 100);
        }
    };

    $scope.functionValuesChanged = function (newFunction, newVal) {
        var currentCriteria = $scope.getSearchCriteria();
        currentCriteria.LookupType = 'Function';
        currentCriteria.Function = newFunction;
        var selectedFunction;
        dataService.searchLookup(currentCriteria).then(function (result) {
            if (result.data.Results.length == 1) {
                var GlCode, GlDesc, CommissionPercent, Rate;
                selectedFunction = result.data.Results[0];
                if (selectedFunction) {
                    if (selectedFunction.ExtraData) {
                        if (selectedFunction.ExtraData.GeneralLedgerAccountCode) {
                            GlCode = selectedFunction.ExtraData.GeneralLedgerAccountCode;
                            GlDesc = selectedFunction.ExtraData.GeneralLedgerAccountDescription;
                        }
                        if (!angular.isUndefined(selectedFunction.ExtraData.Rate)) {
                            Rate = selectedFunction.ExtraData.Rate;
                            $scope.setRate(Rate);
                        }
                        if (!angular.isUndefined(selectedFunction.ExtraData.CommissionPercent)) {
                            CommissionPercent = selectedFunction.ExtraData.CommissionPercent;
                            $scope.setCommissionPercent(CommissionPercent);
                        }
                    }
                }
            } else {
                selectedFunction = newFunction;
            }
            $scope.setGeneralLedgerCode(GlCode);
            $scope.setGeneralLedgerAccountDescription(GlDesc);
            $scope.fillFunctionValues(selectedFunction);
            if (newVal) {
                $scope.focusNextControl('Function');
            }
        });
    };

    $scope.generalLedgerAccountValuesChanged = function (generalLedgerAccount, fetch) {
        $scope.fillGeneralLedgerAccountValues(generalLedgerAccount);
        if (fetch) {
            $scope.searchCriteria.LookupType = 'GeneralLedgerAccount';
            $scope.searchCriteria.GeneralLedgerAccount = generalLedgerAccount;
            dataService.searchLookup($scope.searchCriteria).then(function (result) {
                if (result.data.Results.length == 1) {
                    $scope.fillGeneralLedgerAccountValues(result.data.Results[0]);
                } else {
                    $scope.fillGeneralLedgerAccountValues(null);
                }
                $scope.focusNextControl('GeneralLedgerAccount');
            });
        }
    };

    $scope.employeeValuesChanged = function (employee, fetch) {
        $scope.fillEmployeeValues(employee);
        if (fetch) {
            $scope.searchCriteria.LookupType = 'Employee';
            $scope.searchCriteria.Employee = employee;
            dataService.searchLookup($scope.searchCriteria).then(function (result) {
                if (result.data.Results.length == 1) {
                    $scope.fillEmployeeValues(result.data.Results[0]);
                } else {
                    $scope.fillEmployeeValues(null);
                }
            });
        }
    };

    $scope.vendorValuesChanged = function (vendor, fetch) {
        $scope.fillVendorValues(vendor);
        if (fetch) {
            $scope.searchCriteria.LookupType = 'Vendor';
            vendor.IncludeMediaVendors = true;
            $scope.searchCriteria.Vendor = vendor;
            dataService.searchLookup($scope.searchCriteria).then(function (result) {
                if (result.data.Results.length == 1) {
                    $scope.fillVendorValues(result.data.Results[0]);
                } else {
                    $scope.fillVendorValues(null);
                }
            });
        }
    };

    $scope.vendorContactValuesChanged = function (vendorContact, fetch) {
        $scope.fillVendorContactValues(vendorContact);
        if (fetch) {
            $scope.searchCriteria.LookupType = 'VendorContact';
            $scope.searchCriteria.VendorContact = vendorContact;
            dataService.searchLookup($scope.searchCriteria).then(function (result) {
                if (result.data.Results.length == 1) {
                    $scope.fillVendorContactValues(result.data.Results[0]);
                } else {
                    $scope.fillVendorContactValues(vendorContact);
                }
            });
        }
    };

    var calcRunning = false;

    $scope.quantityRateAmountChanged = function (changed) {
        if (calcRunning === false) {
            calcRunning = true;
            try{
                var quantityChanged = changed === 'Quantity' ? true : false;
                var rateChanged = changed === 'Rate' ? true : false;
                var amountChanged = changed === 'ExtendedAmount' ? true : false;
                var quantity = $scope.getQuantity();
                var rate = $scope.getRate();
                var amount = $scope.getAmount();
                if (quantityChanged || rateChanged) {
                    if (rateChanged && !rate) {
                        //quantity = null;
                    } else if (quantityChanged && !quantity) {
                        //rate = null;
                    } else if (quantity && rate) {
                        amount = calculateAmount(quantity, rate);
                    } else if (!quantity && rate) {
                        quantity = calculateQuantity(rate, amount);
                        if (calculateAmount(quantity, rate) != amount) {
                            rate = calculateRate(quantity, amount);
                        }
                    } else if (!rate && quantity) {
                        rate = calculateRate(quantity, amount);
                    }
                } else if (amountChanged === true) {
                    if (quantity && quantity > 0) {
                        rate = calculateRate(quantity, amount);
                    } else if (rate && rate > 0) {
                        quantity = calculateQuantity(rate, amount);
                        if (calculateAmount(quantity, rate) != amount) {
                            rate = calculateRate(quantity, amount);
                        }
                    } else {
                        quantity = null;
                        rate = null;
                    }
                }
                var commissionPercent, commissionAmount, lineTotal;
                commissionPercent = $scope.getCommissionPercent();
                if (commissionPercent || !isNaN(commissionPercent)) {
                    commissionAmount = (commissionPercent / 100) * amount;
                    commissionAmount = roundNumber(commissionAmount, 2);
                }
                $scope.setQuantity(quantity);
                $scope.setRate(rate);
                $scope.setAmount(amount);
                lineTotal = amount;
                if (commissionAmount && !isNaN(commissionAmount)) {
                    lineTotal += commissionAmount;
                }
                $scope.setCommissionPercent(commissionPercent);
                $scope.setCommissionAmount(commissionAmount);
                $scope.setLineTotal(lineTotal);
                var radGrid = $find($('#purchaseOrderGridContainer').find('div.RadGrid').attr('id'));
                var total = 0;
                var pr = $scope.parentRow;
                $(radGrid.get_masterTableView().get_dataItems()).each(function () {
                    $scope.parentRow = this.get_element();
                    var value = $scope.getAmount();
                    if (value) {
                        total += value;
                    }
                });
                $find('RadNumericTextBoxPOTotal').set_value(total);
                $scope.parentRow = pr;
            } catch (ex) {
            }
            calcRunning = false;
        }
    };

    var calculateAmount = function (quantity, rate) {
        var cpm = $scope.getIsCPM();
        var realRate = rate;
        if (cpm === true) {
            realRate = realRate / 1000;
        }
        return roundNumber(quantity * realRate, 2);
    }

    var calculateQuantity = function (rate, amount) {
        var cpm = $scope.getIsCPM();
        var quantity;
        quantity = amount / rate;
        if (cpm === true) {
            quantity = quantity * 1000;
        }
        return roundNumber(quantity, 0);
    }

    var calculateRate = function (quantity, amount) {
        var rate;
        var cpm = $scope.getIsCPM();
        rate = amount / quantity;
        if (cpm === true) {
            rate = rate * 1000;
        }
        return roundNumber(rate, 3);
    }

    var roundNumber = function (number, decimals) {
        return Number(Number(number).toFixed(decimals).replace(/(\d)(?=(\d{3})+\.)/g, '$1,').replace(/,/g, ''));
    }

    $scope.fillEmployeeValues = function (employee) {
        var code, name, limit;
        if (employee) {
            code = employee.EmployeeCode;
            name = employee.FullName;
            if (employee.ExtraData) {
                limit = employee.ExtraData.PurchaseOrderLimit;
            }
        }
        if (!code) {
            name = null;
            limit = null;
        }
        $scope.setEmployeeCode(code);
        $scope.setEmployeeName(name);
        $telerik.findNumericTextBox('RadNumericTextBoxPOLimit').set_value(limit);
    };

    $scope.fillVendorContactValues = function (vendorContact) {
        var code, name, email;
        if (vendorContact) {
            code = vendorContact.VendorContactCode;
            name = vendorContact.FullName;
            email = vendorContact.EmailAddress;
        }
        if (!code) {
            name = null;
            email = null;
        }
        $scope.setVendorContactCode(code);
        $scope.setVendorContactName(name);
        $scope.setVendorContactEmail(email);
    }

    $scope.fillVendorValues = function (vendor) {
        var code, name, address1, address2, county, city, state, zip, country, defContactCode, vendorContact, stdComment, payToName;
        if (vendor) {
            code = vendor.VendorCode;
            name = vendor.VendorName;
            if (vendor.ExtraData) {
                payToName = vendor.ExtraData.PayToName;
                address1 = vendor.ExtraData.PayToAddressLine1;
                address2 = vendor.ExtraData.PayToAddressLine2;
                city = vendor.ExtraData.PayToCity;
                county = vendor.ExtraData.PayToCounty;
                state = vendor.ExtraData.PayToState;
                zip = vendor.ExtraData.PayToZipCode;
                country = vendor.ExtraData.PayToCountry;
                defContactCode = vendor.ExtraData.DefaultVendorContactCode;
                stdComment = vendor.ExtraData.StandardComment;
            }
        }
        if (!code) {
            payToName = null;
            name = null;
            address1 = null;
            address2 = null;
            county = null;
            city = null;
            state = null;
            zip = null;
            country = null;
            defContactCode = null;
            stdComment = null;
            $scope.enableOrDisableInput('VendorContact', true);
        } else {
            $scope.enableOrDisableInput('VendorContact', false);
        }
        $scope.setVendorCode(code);
        $scope.setVendorName(name);
        $('#LabelPayTo').text(payToName);
        $('#TextBoxAddress1').val(address1);
        $('#TextBoxAddress2').val(address2);
        $('#TextBoxCity').val(city);
        $('#TextBoxCounty').val(county);
        $('#TextBoxState').val(state);
        $('#TextBoxZip').val(zip);
        $('#TextBoxCountry').val(country);
        if (stdComment) {
            $('#RadTextBox_FooterComments').val(stdComment);
            $('#RadTextBox_FooterComments').attr('disabled', 'disabled');
            $('#ListItemStandard').find('input[type=radio]').prop('checked', true);
        }

        if (defContactCode) {
            vendorContact = {
                VendorContactCode: defContactCode
            };
            $scope.vendorContactValuesChanged(vendorContact, true);
        } else {
            $scope.fillVendorContactValues(null);
        }
    }
    
    $scope.fillJobComponentValues = function (JobComponent) {
        var clCode, clName, divCode, divName, prdCode, prdName, jobNum, jobDesc, compNum, compDesc;
        clCode = JobComponent.ClientCode;
        clName = JobComponent.ClientName;
        divCode = JobComponent.DivisionCode;
        divName = JobComponent.DivisionName;
        prdCode = JobComponent.ProductCode;
        prdName = JobComponent.ProductName;
        jobNum = JobComponent.JobNumber;
        jobDesc = JobComponent.JobDescription;
        compNum = JobComponent.JobComponentNumber;
        compDesc = JobComponent.JobComponentDescription;

        if (!clCode) {
            clName = null;
            divCode = null;
            divName = null;
            prdCode = null;
            prdName = null;
            jobNum = null;
            jobDesc = null;
            compNum = null;
            compDesc = null;
        } else if (!divCode) {
            divName = null;
            prdCode = null;
            prdName = null;
            jobNum = null;
            jobDesc = null;
            compNum = null;
            compDesc = null;
        } else if (!prdCode) {
            prdName = null;
            jobNum = null;
            jobDesc = null;
            compNum = null;
            compDesc = null;
        } else if (!jobNum) {
            jobDesc = null;
            compNum = null;
            compDesc = null;
        } else if (!compNum) {
            compDesc = null;
        }

        $scope.setClientCode(clCode);
        $scope.setClientName(clName);
        $scope.setDivisionCode(divCode);
        $scope.setDivisionName(divName);
        $scope.setProductCode(prdCode);
        $scope.setProductName(prdName);
        $scope.setJobNumber(jobNum);
        $scope.setJobDescription(jobDesc);
        $scope.setJobComponentNumber(compNum);
        $scope.setJobComponentDescription(compDesc);
        $scope.enableOrDisableGlAccount();

    };

    $scope.fillFunctionValues = function (newFunction) {
        var code, desc, cpm, display;
        if (newFunction) {
            code = newFunction.FunctionCode;
            desc = newFunction.FunctionDescription;
            cpm = newFunction.CPMFlag;
        }
        if (!code) {
            cpm = false;
            desc = null;
        }
        $scope.setFunctionCode(code);
        $scope.setFunctionDescription(desc);
        if (cpm === true) {
            display = 'inline-block';
        } else {
            display = 'none';
        }
        $($scope.parentRow).find('div[id*=divCPM]').css('display', display);
        $scope.quantityRateAmountChanged('Rate');
    };

    $scope.fillGeneralLedgerAccountValues = function (generalLedgerAccount) {
        var code, desc;
        if (generalLedgerAccount) {
            code = generalLedgerAccount.GeneralLedgerCode;
            desc = generalLedgerAccount.GeneralLedgerDescription;
        }
        if (!code) {
            desc = null;
        }
        $scope.setGeneralLedgerCode(code);
        $scope.setGeneralLedgerAccountDescription(desc);
    };

    $scope.enableOrDisableGlAccount = function () {
        var currentCriteria = $scope.getSearchCriteria();
        var disabled = false;
        if (currentCriteria.JobComponent.ClientCode || currentCriteria.JobComponent.DivisionCode || currentCriteria.JobComponent.ProductCode || currentCriteria.JobComponent.JobNumber || currentCriteria.JobComponent.JobComponentNumber) {
            disabled = true;
            $scope.setGeneralLedgerCode(null);
            $scope.setGeneralLedgerAccountDescription(null);
        } else {
            disabled = false;
        }
        $scope.enableOrDisableInput('GeneralLedgerAccount', disabled);
    };

    $scope.toggleAnimation = function () {
        $scope.animationsEnabled = !$scope.animationsEnabled;
    };

    $scope.initActions = function () {
        var currentCriteria = $scope.getSearchCriteria();
        if (!$scope.getVendorCode()) {
            $scope.enableOrDisableInput('VendorContact', true);
        }
        $('.rgMasterTable tbody tr').each(function () {
            $scope.parentRow = $(this);
            currentCriteria = $scope.getSearchCriteria();
            var glInput = $scope.getInput('GeneralLedgerAccount');
            if (glInput) {
                if (currentCriteria.JobComponent.ClientCode || currentCriteria.JobComponent.DivisionCode || currentCriteria.JobComponent.ProductCode || currentCriteria.JobComponent.JobNumber || currentCriteria.JobComponent.JobComponentNumber) {
                    $scope.enableOrDisableInput('GeneralLedgerAccount', true);
                }
            }
        });
    };

    $scope.initActions();

});
