app.controller('estimateController', function ($scope, $rootScope, $http, $modal, $timeout, dataService) {
    $scope.searchCriteria = { JobComponent: {}, Function: {}, GeneralLedgerAccount: {}, LookupType: "", ShowInactive: false, SecurityModule: "" };
    $scope.parentRow = {};
    $scope.searchPromise = null;
    $scope.currentRadWindow = null;

    $scope.getInput = function (inputType) {
        var inputControl;
        if ($scope.parentRow) {
            inputControl = $($scope.parentRow).find('input[adv-lookup=' + inputType + ']')[0];
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
        //if (inputControl) {
        //    //radInput = $find($(inputControl).attr('id'));
        //    inputControl = $('input[adv-calc=' + inputType + ']')[0];
        //}
        return inputControl;
    }
    $scope.getDescriptionInput = function (inputType) {
        var inputControl;
        if ($scope.parentRow) {
            inputControl = $($scope.parentRow).find('input[adv-desc=' + inputType + ']')[0];
        }
        return inputControl;
    }
    $scope.getDescriptionLabel = function (inputType) {
        var labelControl;
        if ($scope.parentRow) {
            labelControl = $($scope.parentRow).find('span[adv-desc=' + inputType + ']')[0];
        }
        return labelControl;
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
    $scope.getFunctionType = function () {
        return $scope.getInputValue('FunctionType');
    };
    $scope.getFunctionDescription = function () {
        return $scope.getDescriptionInputValue('Function');
    };
    $scope.getNonBillFlag = function () {
        return $scope.getInputValue('NonBillFlag');
    };
    $scope.getSuppliedBy = function () {
        return $scope.getDescriptionInputValue('SuppliedBy');
    };
    $scope.getTaxCommOnly = function () {
        return $scope.getInputValue('TaxCommOnly');
    };
    $scope.getTaxComm = function () {
        return $scope.getInputValue('TaxComm');
    };
    $scope.getFunctionSeq = function () {
        return $scope.getInputValue('FunctionSeq');
    };
    $scope.getTaxCode = function () {
        return $scope.getInputValue('TaxCode');
    };
    $scope.getTaxStatePct = function () {
        return $scope.getInputValue('TaxStatePct');
    };
    $scope.getTaxCountyPct = function () {
        return $scope.getInputValue('TaxCountyPct');
    };
    $scope.getTaxCityPct = function () {
        return $scope.getInputValue('TaxCityPct');
    };
    $scope.getTaxAmount = function () {
        return $scope.getInputValue('TaxAmount');
    };
    $scope.getTaxResale = function () {
        return $scope.getInputValue('TaxResale');
    };
    $scope.getGeneralLedgerCode = function () {
        return $scope.getInputValue('GeneralLedgerAccount');
    };
    $scope.getGeneralLedgerDescription = function () {
        return $scope.getDescriptionInputValue('GeneralLedgerAccount');
    };
    $scope.getEmployeeCode = function () {
        //return $('#TextBoxEmployeeCode').val();
        return $scope.getInputValue('Employee');
    };
    $scope.getEmployeeTitleName = function () {
        //return $('#TextBoxEmployeeCode').val();
        return $scope.getDescriptionInputValue('Employee');
    };
    $scope.getEmployeeTitle = function () {
        //return $('#TextBoxEmployeeCode').val();
        return $scope.getInputValue('EmployeeTitle');
    };
    $scope.getEmployeeTitleID = function () {
        //return $('#TextBoxEmployeeCode').val();
        return $scope.getInputValue('EmployeeTitleID');
    };
    $scope.getVendorCode = function () {
        //return $('#TextBoxVendorCode').val();
        return $scope.getInputValue('Vendor');
    };
    $scope.getVendorContactCode = function () {
        return $('#TextBoxVendorContactCode').val();
    };
    $scope.getQuantity = function () {
        return $scope.getNumericInputValue('Quantity');
    };
    $scope.getEstimateQuantity = function () {
        return $scope.getInputValue('EstimateQuantity');
    };
    $scope.getEstimateRate = function () {
        return $scope.getInputValue('EstimateRate');
    };
    $scope.getEstimateCommissionPercent = function () {
        return $scope.getInputValue('EstimateCommissionPercent');
    };
    $scope.getEstimateCommissionAmount = function () {
        return $scope.getInputValue('EstimateCommissionAmount');
    };
    $scope.getEstimateContingencyPct = function () {
        return $scope.getInputValue('EstimateContingencyPct');
    };
    $scope.getEstimateAmount = function () {
        return $scope.getInputValue('EstimateAmount');
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
        return $scope.getNumericInputValue('CommissionAmount');
    };
    $scope.getCommissionAmount = function () {
        return $scope.getNumericInputValue('ExtendedMarkupAmount');
    };
    $scope.getContingencyPercent = function () {
        return $scope.getNumericInputValue('ContingencyPercent');
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
    $scope.setFunctionType = function (value) {
        $scope.setInputValue('FunctionType', value);
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
    $scope.setEstimateQuantity = function (value) {
        $scope.setInputValue('EstimateQuantity');
    };
    $scope.setEstimateCommissionPercent = function (value) {
        $scope.setInputValue('EstimateCommissionPercent');
    };
    $scope.setEstimateCommissionAmount = function (value) {
        $scope.setInputValue('EstimateCommissionAmount');
    };
    $scope.setEstimateContingencyPct = function (value) {
        $scope.setInputValue('EstimateContingencyPct');
    };
    $scope.setEstimateAmount = function (value) {
        $scope.setInputValue('EstimateAmount');
    };
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
        $scope.setNumericInputValue('CommissionAmount', value);
    };
    $scope.setContingencyPercent = function (value) {
        $scope.setNumericInputValue('ContingencyPercent', value);
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
        //$('#TextBoxEmployeeCode').val(value);
        $scope.setInputValue('Employee', value);
    }
    $scope.setEmployeeName = function (value) {
        $scope.setDescriptionInputValue('Employee', value);
    };
    $scope.setEmployeeTitleName = function (value) {
        $scope.setDescriptionInputValue('Employee', value);
    };
    $scope.setEmployeeTitle = function (value) {
        $scope.setInputValue('EmployeeTitle', value);
    };
    $scope.setEmployeeTitleID = function (value) {
        $scope.setInputValue('EmployeeTitleID', value);
    };
    $scope.setNonBillFlag = function (value) {
        $scope.setNumericInputValue('NonBillFlag', value);
    };
    $scope.setSuppliedBy = function (value) {
        $scope.setDescriptionInputValue('SuppliedBy', value);
    };
    $scope.setTaxCommOnly = function (value) {
        $scope.setNumericInputValue('TaxCommOnly', value);
    };
    $scope.setTaxComm = function (value) {
        $scope.setNumericInputValue('TaxComm', value);
    };
    $scope.setTaxCode = function (value) {
        $scope.setNumericInputValue('TaxCode', value);
    };
    $scope.setTaxStatePct = function (value) {
        $scope.setNumericInputValue('TaxStatePct', value);
    };
    $scope.setTaxCountyPct = function (value) {
        $scope.setNumericInputValue('TaxCountyPct', value);
    };
    $scope.setTaxCityPct = function (value) {
        $scope.setNumericInputValue('TaxCityPct', value);
    };
    $scope.setTaxAmount = function (value) {
        $scope.setNumericInputValue('TaxAmount', value);
    };
    $scope.setLineTotal = function (value) {
        $scope.setNumericInputValue('LineTotal', value);
    };
    $scope.setContingencyAmount = function (value) {
        $scope.setNumericInputValue('ContingencyAmount', value);
    };
    $scope.setTaxAmount = function (value) {
        $scope.setNumericInputValue('TaxAmount', value);
    };
    $scope.setCommission = function (value) {
        $scope.setNumericInputValue('Commission', value);
    };
    $scope.setTaxResale = function (value) {
        $scope.setNumericInputValue('TaxResale', value);
    };
    $scope.setCPMFlag = function (value) {
        $scope.setNumericInputValue('CPM', value);
    };
    $scope.setFunctionSeq = function (value) {
        $scope.setInputValue('FunctionSeq');
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
            $(numericInput).val(value);
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

    function getRealLookupType(lookupType, functionType) {

        var realLookupType = lookupType;

        if (lookupType == 'Vendor' || lookupType == 'Employee') {
            if (functionType.toUpperCase() == 'V') {
                realLookupType = 'Vendor';
            } else if (functionType.toUpperCase() == 'E') {
                realLookupType = 'Employee';
            } 
        }
        return realLookupType;

    }

    $scope.getSearchCriteria = function (lookupType) {
        var SearchOptions = [];

        if (lookupType == 'Vendor') {
            SearchOptions = [{ Type: "checkbox", Name: "EstimateLimitVendors", ID: "EstimateLimitVendors", Text: "Limit to vendors with default function code '" + $scope.getFunctionCode() + "'", NgChange: "EstimateFilterVendors()" },
                             { Type: "checkbox", Name: "EstimateMediaVendors", ID: "EstimateMediaVendors", Text: "Show Media Vendors", NgChange: "EstimateFilterVendors()" }];
        };

        $scope.searchCriteria = {
            JobComponent: {
                ClientCode: $('[id*=hfClientCode]').val(),
                DivisionCode: $('[id*=hfDivisionCode]').val(),
                ProductCode: $('[id*=hfProductCode]').val(),
                SalesClass: $('[id*=hfSalesClass]').val(),
                JobNumber: $('[id*=TxtJobNum]').val(),
                JobComponentNumber: $('[id*=TxtJobCompNum]').val(),
                JobNumber: $('[id*=TxtJobNum]').val(),
                JobComponentNumber: $('[id*=TxtJobCompNum]').val()
            },

            Estimate: {
                EstimateNumber: $('[id*=TxtEstimate]').val(),
                EstimateComponentNumber: $('[id*=TxtEstimateComponent]').val(),
                EstimateQuoteNumber: $('[id*=TxtQuoteNum]').val(),
                EstimateRevisionNumber: $('[id*=hfRev]').val(),                
                EstimateSequenceNumber: $scope.getFunctionSeq(),
                EstimateQuantity: $scope.getEstimateQuantity(),
                EstimateCommissionPercent: $scope.getEstimateCommissionPercent(),
                EstimateCommissionAmount: $scope.getEstimateCommissionAmount(),
                EstimateContingencyPct: $scope.getEstimateContingencyPct(),
                EstimateAmount: $scope.getEstimateAmount()
            },

            Function: {
                FunctionCode: $scope.getFunctionCode(),
                FunctionDescription: $scope.getFunctionDescription(),
                FunctionType: $scope.getFunctionType()
            },
            GeneralLedgerAccount: {
                GeneralLedgerCode: $scope.getGeneralLedgerCode(),
                GeneralLedgerDescription: $scope.getGeneralLedgerDescription(),
            },
            Employee: {
                EmployeeCode: $scope.getEmployeeCode(),
                EmployeeTitle: $scope.getEmployeeTitleName()
            },
            EmployeeTitle: {
                EmployeeTitleID: $scope.getEmployeeTitleID(),
                EmployeeTitle: $scope.getEmployeeTitle()
            },
            Vendor: {
                VendorCode: $scope.getVendorCode(),
                IncludeMediaVendors: false,
                LimitbyDefaultFunction: false
            },
            VendorContact: {
                VendorContactCode: $scope.getVendorContactCode()
            },
            Tax: {
                TaxCode: $scope.getTaxCode(),
                TaxStatePct: $scope.getTaxStatePct(),
                TaxCountyPct: $scope.getTaxCountyPct(),
                TaxCityPct: $scope.getTaxCityPct(),
                TaxResale: $scope.getTaxResale()
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
            $scope.employeeValuesChanged(selectedItem, true);
        }
        if (selectedItem.ObjectName == 'EmployeeTitle') {
            $scope.employeeTitleValuesChanged(selectedItem, true);
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
        if (selectedItem.ObjectName == 'Tax') {
            $scope.taxValuesChanged(selectedItem, true);
        }
    };

    $scope.open = function (lookupType) {

        lookupType = getRealLookupType(lookupType, $scope.getFunctionType());

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
            queryString += "&Functiontype=" + currentCriteria.Function.FunctionType;
            queryString += "&Functioncode=" + currentCriteria.Function.FunctionCode;
        }
        if (lookupType == 'Vendor') {
            currentCriteria.Vendor.VendorCode = '';
        }
        if (lookupType == 'TaxCode') {
            currentCriteria.Tax.TaxCode = '';
        }
        if (lookupType == 'VendorContact') {
            currentCriteria.VendorContact.VendorContactCode = '';
            queryString += "&ShowAddEdit=1";
        }
        if (lookupType == 'GeneralLedgerAccount') {
            currentCriteria.GeneralLedgerAccount.GeneralLedgerCode = '';
        }

        OpenRadWindowLookup2("ModalFilterDialog.aspx?" + queryString, currentCriteria, $scope);

        //if ($scope.currentRadWindow === null) {
        //    $scope.currentRadWindow = $rootScope.getCurrentRadWindow();
        //}

        //var oBrowserWnd = $scope.currentRadWindow.BrowserWindow;
        //var baseWindowHeight = 650;
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

    $scope.getCurrentRadWindow = function () {
        return this;
    }

    $scope.jobComponentValuesChanged = function (JobComponent, newVal) {
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
            setTimeout(function () { $scope.getInput(nextControl).focus(); }, 100);
        }
    };

    $scope.functionValuesChanged = function (newFunction, newVal) {
        var currentCriteria = $scope.getSearchCriteria();
        currentCriteria.LookupType = 'Function';
        currentCriteria.Function = newFunction;
        var selectedFunction;
        var parentRow = $scope.parentRow;
        dataService.searchLookup(currentCriteria).then(function (result) {
            var currentParentRow = $scope.parentRow;
            $scope.parentRow = parentRow;
            if (result.data.Results.length == 1) {
                var GlCode, GlDesc, CommissionPercent, Rate, NoBillFlag, TaxCommOnly, TaxComm, TaxCode, TaxState, TaxCounty, TaxCity, TaxResale, Cpm, ContingencyPercent, SuppliedBy;
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
                        if (!angular.isUndefined(selectedFunction.ExtraData.NoBilSYlFlag)) {
                            NoBillFlag = selectedFunction.ExtraData.NoBillFlag;
                            $scope.setNonBillFlag(NoBillFlag);
                        }
                        if (!angular.isUndefined(selectedFunction.ExtraData.SuppliedBy)) {
                            SuppliedBy = selectedFunction.ExtraData.SuppliedBy;
                            $scope.setSuppliedBy(SuppliedBy);
                        }
                        if (!angular.isUndefined(selectedFunction.ExtraData.EmployeeTitle)) {
                            EmployeeTitle = selectedFunction.ExtraData.EmployeeTitle;
                            $scope.setEmployeeTitle(EmployeeTitle);
                        }
                        if (!angular.isUndefined(selectedFunction.ExtraData.TaxCommOnly)) {
                            TaxCommOnly = selectedFunction.ExtraData.TaxCommOnly;
                            $scope.setTaxCommOnly(TaxCommOnly);
                        }
                        if (!angular.isUndefined(selectedFunction.ExtraData.TaxComm)) {
                            TaxComm = selectedFunction.ExtraData.TaxComm;
                            $scope.setTaxComm(TaxComm);
                        }
                        if (!angular.isUndefined(selectedFunction.ExtraData.TaxCode)) {
                            TaxCode = selectedFunction.ExtraData.TaxCode;
                            $scope.setTaxCode(TaxCode);
                        }
                        if (!angular.isUndefined(selectedFunction.ExtraData.TaxState)) {
                            TaxState = selectedFunction.ExtraData.TaxState;
                            $scope.setTaxStatePct(TaxState);
                        }
                        if (!angular.isUndefined(selectedFunction.ExtraData.TaxCounty)) {
                            TaxCounty = selectedFunction.ExtraData.TaxCounty;
                            $scope.setTaxCountyPct(TaxCounty);
                        }
                        if (!angular.isUndefined(selectedFunction.ExtraData.TaxCity)) {
                            TaxCity = selectedFunction.ExtraData.TaxCity;
                            $scope.setTaxCityPct(TaxCity);
                        }
                        if (!angular.isUndefined(selectedFunction.ExtraData.TaxResale)) {
                            TaxResale = selectedFunction.ExtraData.TaxResale;
                            $scope.setTaxResale(TaxResale);
                        }
                        if (!angular.isUndefined(selectedFunction.ExtraData.CPM)) {
                            cpm = selectedFunction.ExtraData.CPM;
                            $scope.setCPMFlag(cpm);
                        }
                        if (!angular.isUndefined(selectedFunction.ExtraData.ContingencyPercent)) {
                            ContingencyPercent = selectedFunction.ExtraData.ContingencyPercent;
                            $scope.setContingencyPercent(ContingencyPercent);
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
            $scope.parentRow = currentParentRow;
        });
    };

    $scope.taxValuesChanged = function (newTax, newVal) {
        var currentCriteria = $scope.getSearchCriteria();
        currentCriteria.LookupType = 'TaxCode';
        currentCriteria.Tax = newTax;
        var selectedTax;
        var parentRow = $scope.parentRow;
        dataService.searchLookup(currentCriteria).then(function (result) {
            var currentParentRow = $scope.parentRow;
            $scope.parentRow = parentRow;
            if (result.data.Results.length == 1) {
                var GlCode, GlDesc, CommissionPercent, Rate, NoBillFlag, TaxCommOnly, TaxComm, TaxCode, TaxState, TaxCounty, TaxCity, TaxResale, TaxAmount, LineTotal, ContingencyAmount, ContingencyPercent;
                selectedTax = result.data.Results[0];
                if (selectedTax) {
                    if (selectedTax.ExtraData) {
                        if (selectedTax.ExtraData.GeneralLedgerAccountCode) {
                            GlCode = selectedTax.ExtraData.GeneralLedgerAccountCode;
                            GlDesc = selectedTax.ExtraData.GeneralLedgerAccountDescription;
                        }
                        if (!angular.isUndefined(selectedTax.ExtraData.Rate)) {
                            Rate = selectedTax.ExtraData.Rate;
                            $scope.setRate(Rate);
                        }
                        if (!angular.isUndefined(selectedTax.ExtraData.CommissionPercent)) {
                            CommissionPercent = selectedTax.ExtraData.CommissionPercent;
                            $scope.setCommissionPercent(CommissionPercent);
                        }
                        if (!angular.isUndefined(selectedTax.ExtraData.NoBillFlag)) {
                            NoBillFlag = selectedTax.ExtraData.NoBillFlag;
                            $scope.setNonBillFlag(NoBillFlag);
                        }
                        if (!angular.isUndefined(selectedTax.ExtraData.TaxCommOnly)) {
                            TaxCommOnly = selectedTax.ExtraData.TaxCommOnly;
                            $scope.setTaxCommOnly(TaxCommOnly);
                        }
                        if (!angular.isUndefined(selectedTax.ExtraData.TaxComm)) {
                            TaxComm = selectedTax.ExtraData.TaxComm;
                            $scope.setTaxComm(TaxComm);
                        }
                        if (!angular.isUndefined(selectedTax.ExtraData.TaxCode)) {
                            TaxCode = selectedTax.ExtraData.TaxCode;
                            $scope.setTaxCode(TaxCode);
                        }
                        if (!angular.isUndefined(selectedTax.ExtraData.TaxState)) {
                            TaxState = selectedTax.ExtraData.TaxState;
                            $scope.setTaxStatePct(TaxState);
                        }
                        if (!angular.isUndefined(selectedTax.ExtraData.TaxCounty)) {
                            TaxCounty = selectedTax.ExtraData.TaxCounty;
                            $scope.setTaxCountyPct(TaxCounty);
                        }
                        if (!angular.isUndefined(selectedTax.ExtraData.TaxCity)) {
                            TaxCity = selectedTax.ExtraData.TaxCity;
                            $scope.setTaxCityPct(TaxCity);
                        }
                        if (!angular.isUndefined(selectedTax.ExtraData.TaxResale)) {
                            TaxResale = selectedTax.ExtraData.TaxResale;
                            $scope.setTaxResale(TaxResale);
                        }
                        if (!angular.isUndefined(selectedTax.ExtraData.TaxAmount)) {
                            TaxAmount = selectedTax.ExtraData.TaxAmount;
                            $scope.setTaxAmount(TaxAmount);
                        }
                        if (!angular.isUndefined(selectedTax.ExtraData.LineTotal)) {
                            LineTotal = selectedTax.ExtraData.LineTotal;
                            $scope.setLineTotal(LineTotal);
                        }
                        if (!angular.isUndefined(selectedTax.ExtraData.ContingencyAmount)) {
                            ContingencyAmount = selectedTax.ExtraData.ContingencyAmount;
                            $scope.setContingencyAmount(ContingencyAmount);
                        }
                        if (!angular.isUndefined(selectedTax.ExtraData.ContingencyPercent)) {
                            ContingencyPercent = selectedTax.ExtraData.ContingencyPercent;
                            $scope.setContingencyPercent(ContingencyPercent);
                        }
                    }
                }
            } else {
                selectedTax = newTax;
            }
            $scope.setGeneralLedgerCode(GlCode);
            $scope.setGeneralLedgerAccountDescription(GlDesc);
            $scope.fillTaxValues(selectedTax);
            if (newVal) {
                $scope.focusNextControl('Tax');
            }
            $scope.parentRow = currentParentRow;
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

    //$scope.employeeValuesChanged = function (employee, fetch) {
    //    $scope.fillEmployeeValues(employee);
    //    if (fetch) {
    //        $scope.searchCriteria.LookupType = 'Employee';
    //        $scope.searchCriteria.Employee = employee;
    //        dataService.searchLookup($scope.searchCriteria).then(function (result) {
    //            if (result.data.Results.length == 1) {
    //                $scope.fillEmployeeValues(result.data.Results[0]);
    //            } else {
    //                $scope.fillEmployeeValues(null);
    //            }
    //        });
    //    }
    //};
    $scope.employeeValuesChanged = function (employee, newVal) {
        var currentCriteria = $scope.getSearchCriteria();
        currentCriteria.LookupType = 'Employee';
        currentCriteria.Employee = employee;
        var selectedEmployee;
        var parentRow = $scope.parentRow;
        dataService.searchLookup(currentCriteria).then(function (result) {
            var currentParentRow = $scope.parentRow;
            $scope.parentRow = parentRow;
            if (result.data.Results.length == 1) {
                var GlCode, GlDesc, CommissionPercent, Rate, NoBillFlag, TaxCommOnly, TaxComm, TaxCode, TaxState, TaxCounty, TaxCity, TaxResale, TaxAmount, LineTotal, ContingencyAmount, Amount, Commission, EmployeeTitle, ContingencyPercent;
                selectedEmployee = result.data.Results[0];
                if (selectedEmployee) {
                    if (selectedEmployee.ExtraData) {
                        if (selectedEmployee.ExtraData.GeneralLedgerAccountCode) {
                            GlCode = selectedEmployee.ExtraData.GeneralLedgerAccountCode;
                            GlDesc = selectedEmployee.ExtraData.GeneralLedgerAccountDescription;
                        }
                        if (!angular.isUndefined(selectedEmployee.ExtraData.Rate)) {
                            Rate = selectedEmployee.ExtraData.Rate;
                            $scope.setRate(Rate);
                        }
                        if (!angular.isUndefined(selectedEmployee.ExtraData.CommissionPercent)) {
                            CommissionPercent = selectedEmployee.ExtraData.CommissionPercent;
                            $scope.setCommissionPercent(CommissionPercent);
                        }
                        if (!angular.isUndefined(selectedEmployee.ExtraData.NoBillFlag)) {
                            NoBillFlag = selectedEmployee.ExtraData.NoBillFlag;
                            $scope.setNonBillFlag(NoBillFlag);
                        }
                        if (!angular.isUndefined(selectedEmployee.ExtraData.TaxCommOnly)) {
                            TaxCommOnly = selectedEmployee.ExtraData.TaxCommOnly;
                            $scope.setTaxCommOnly(TaxCommOnly);
                        }
                        if (!angular.isUndefined(selectedEmployee.ExtraData.TaxComm)) {
                            TaxComm = selectedEmployee.ExtraData.TaxComm;
                            $scope.setTaxComm(TaxComm);
                        }
                        if (!angular.isUndefined(selectedEmployee.ExtraData.TaxCode)) {
                            TaxCode = selectedEmployee.ExtraData.TaxCode;
                            $scope.setTaxCode(TaxCode);
                        }
                        if (!angular.isUndefined(selectedEmployee.ExtraData.TaxState)) {
                            TaxState = selectedEmployee.ExtraData.TaxState;
                            $scope.setTaxStatePct(TaxState);
                        }
                        if (!angular.isUndefined(selectedEmployee.ExtraData.TaxCounty)) {
                            TaxCounty = selectedEmployee.ExtraData.TaxCounty;
                            $scope.setTaxCountyPct(TaxCounty);
                        }
                        if (!angular.isUndefined(selectedEmployee.ExtraData.TaxCity)) {
                            TaxCity = selectedEmployee.ExtraData.TaxCity;
                            $scope.setTaxCityPct(TaxCity);
                        }
                        if (!angular.isUndefined(selectedEmployee.ExtraData.TaxResale)) {
                            TaxResale = selectedEmployee.ExtraData.TaxResale;
                            $scope.setTaxResale(TaxResale);
                        }
                        if (!angular.isUndefined(selectedEmployee.ExtraData.TaxAmount)) {
                            TaxAmount = selectedEmployee.ExtraData.TaxAmount;
                            $scope.setTaxAmount(TaxAmount);
                        }
                        if (!angular.isUndefined(selectedEmployee.ExtraData.LineTotal)) {
                            LineTotal = selectedEmployee.ExtraData.LineTotal;
                            $scope.setLineTotal(LineTotal);
                        }
                        if (!angular.isUndefined(selectedEmployee.ExtraData.ContingencyAmount)) {
                            ContingencyAmount = selectedEmployee.ExtraData.ContingencyAmount;
                            $scope.setContingencyAmount(ContingencyAmount);
                        }
                        if (!angular.isUndefined(selectedEmployee.ExtraData.ExtendedAmount)) {
                            Amount = selectedEmployee.ExtraData.ExtendedAmount;
                            $scope.setAmount(Amount);
                        }
                        if (!angular.isUndefined(selectedEmployee.ExtraData.Commission)) {
                            Commission = selectedEmployee.ExtraData.Commission;
                            $scope.setCommission(Commission);
                        }
                        if (!angular.isUndefined(selectedEmployee.ExtraData.EmployeeTitle)) {
                            EmployeeTitle = selectedEmployee.ExtraData.EmployeeTitle;
                            $scope.setEmployeeTitleName(EmployeeTitle);
                        }
                        if (!angular.isUndefined(selectedEmployee.ExtraData.ContingencyPercent)) {
                            ContingencyPercent = selectedEmployee.ExtraData.ContingencyPercent;
                            $scope.setContingencyPercent(ContingencyPercent);
                        }
                    }
                }
            } else {
                if (currentCriteria.Function != '') {
                    var GlCode, GlDesc, CommissionPercent, Rate, NoBillFlag, TaxCommOnly, TaxComm, TaxCode, TaxState, TaxCounty, TaxCity, TaxResale, TaxAmount, LineTotal, ContingencyAmount, Amount, Commission, EmployeeTitle, ContingencyPercent;
                    selectedEmployee = result.data.Results[0];
                    if (selectedEmployee) {
                        if (selectedEmployee.ExtraData) {
                            if (selectedEmployee.ExtraData.GeneralLedgerAccountCode) {
                                GlCode = selectedEmployee.ExtraData.GeneralLedgerAccountCode;
                                GlDesc = selectedEmployee.ExtraData.GeneralLedgerAccountDescription;
                            }
                            if (!angular.isUndefined(selectedEmployee.ExtraData.Rate)) {
                                Rate = selectedEmployee.ExtraData.Rate;
                                $scope.setRate(Rate);
                            }
                            if (!angular.isUndefined(selectedEmployee.ExtraData.CommissionPercent)) {
                                CommissionPercent = selectedEmployee.ExtraData.CommissionPercent;
                                $scope.setCommissionPercent(CommissionPercent);
                            }
                            if (!angular.isUndefined(selectedEmployee.ExtraData.NoBillFlag)) {
                                NoBillFlag = selectedEmployee.ExtraData.NoBillFlag;
                                $scope.setNonBillFlag(NoBillFlag);
                            }
                            if (!angular.isUndefined(selectedEmployee.ExtraData.TaxCommOnly)) {
                                TaxCommOnly = selectedEmployee.ExtraData.TaxCommOnly;
                                $scope.setTaxCommOnly(TaxCommOnly);
                            }
                            if (!angular.isUndefined(selectedEmployee.ExtraData.TaxComm)) {
                                TaxComm = selectedEmployee.ExtraData.TaxComm;
                                $scope.setTaxComm(TaxComm);
                            }
                            if (!angular.isUndefined(selectedEmployee.ExtraData.TaxCode)) {
                                TaxCode = selectedEmployee.ExtraData.TaxCode;
                                $scope.setTaxCode(TaxCode);
                            }
                            if (!angular.isUndefined(selectedEmployee.ExtraData.TaxState)) {
                                TaxState = selectedEmployee.ExtraData.TaxState;
                                $scope.setTaxStatePct(TaxState);
                            }
                            if (!angular.isUndefined(selectedEmployee.ExtraData.TaxCounty)) {
                                TaxCounty = selectedEmployee.ExtraData.TaxCounty;
                                $scope.setTaxCountyPct(TaxCounty);
                            }
                            if (!angular.isUndefined(selectedEmployee.ExtraData.TaxCity)) {
                                TaxCity = selectedEmployee.ExtraData.TaxCity;
                                $scope.setTaxCityPct(TaxCity);
                            }
                            if (!angular.isUndefined(selectedEmployee.ExtraData.TaxResale)) {
                                TaxResale = selectedEmployee.ExtraData.TaxResale;
                                $scope.setTaxResale(TaxResale);
                            }
                            if (!angular.isUndefined(selectedEmployee.ExtraData.TaxAmount)) {
                                TaxAmount = selectedEmployee.ExtraData.TaxAmount;
                                $scope.setTaxAmount(TaxAmount);
                            }
                            if (!angular.isUndefined(selectedEmployee.ExtraData.LineTotal)) {
                                LineTotal = selectedEmployee.ExtraData.LineTotal;
                                $scope.setLineTotal(LineTotal);
                            }
                            if (!angular.isUndefined(selectedEmployee.ExtraData.ContingencyAmount)) {
                                ContingencyAmount = selectedEmployee.ExtraData.ContingencyAmount;
                                $scope.setContingencyAmount(ContingencyAmount);
                            }
                            if (!angular.isUndefined(selectedEmployee.ExtraData.ExtendedAmount)) {
                                Amount = selectedEmployee.ExtraData.ExtendedAmount;
                                $scope.setAmount(Amount);
                            }
                            if (!angular.isUndefined(selectedEmployee.ExtraData.Commission)) {
                                Commission = selectedEmployee.ExtraData.Commission;
                                $scope.setCommission(Commission);
                            }
                            if (!angular.isUndefined(selectedEmployee.ExtraData.EmployeeTitle)) {
                                EmployeeTitle = selectedEmployee.ExtraData.EmployeeTitle;
                                $scope.setEmployeeTitleName(EmployeeTitle);
                            }
                            if (!angular.isUndefined(selectedEmployee.ExtraData.ContingencyPercent)) {
                                ContingencyPercent = selectedEmployee.ExtraData.ContingencyPercent;
                                $scope.setContingencyPercent(ContingencyPercent);
                            }
                        }
                    }
                }
                selectedEmployee = newEmployee;
            }
            $scope.setGeneralLedgerCode(GlCode);
            $scope.setGeneralLedgerAccountDescription(GlDesc);
            $scope.fillEmployeeValues(selectedEmployee);
            if (newVal) {
                $scope.focusNextControl('Employee');
            }
            $scope.parentRow = currentParentRow;
        });
    };

    $scope.employeeTitleValuesChanged = function (employeeTitle, newVal) {
        var currentCriteria = $scope.getSearchCriteria();
        currentCriteria.LookupType = 'EmployeeTitle';
        currentCriteria.EmployeeTitle = employeeTitle;
        var selectedEmployeeTitle;
        var parentRow = $scope.parentRow;
        dataService.searchLookup(currentCriteria).then(function (result) {
            var currentParentRow = $scope.parentRow;
            $scope.parentRow = parentRow;
            if (result.data.Results.length == 1) {
                var GlCode, GlDesc, CommissionPercent, Rate, NoBillFlag, TaxCommOnly, TaxComm, TaxCode, TaxState, TaxCounty, TaxCity, TaxResale, TaxAmount, LineTotal, ContingencyAmount, Amount, Commission, EmployeeTitleID, ContingencyPercent;
                selectedEmployeeTitle = result.data.Results[0];
                if (selectedEmployeeTitle) {
                    if (selectedEmployeeTitle.ExtraData) {
                        if (selectedEmployeeTitle.ExtraData.GeneralLedgerAccountCode) {
                            GlCode = selectedEmployeeTitle.ExtraData.GeneralLedgerAccountCode;
                            GlDesc = selectedEmployeeTitle.ExtraData.GeneralLedgerAccountDescription;
                        }
                        if (!angular.isUndefined(selectedEmployeeTitle.ExtraData.Rate)) {
                            Rate = selectedEmployeeTitle.ExtraData.Rate;
                            $scope.setRate(Rate);
                        }
                        if (!angular.isUndefined(selectedEmployeeTitle.ExtraData.CommissionPercent)) {
                            CommissionPercent = selectedEmployeeTitle.ExtraData.CommissionPercent;
                            $scope.setCommissionPercent(CommissionPercent);
                        }
                        if (!angular.isUndefined(selectedEmployeeTitle.ExtraData.NoBillFlag)) {
                            NoBillFlag = selectedEmployeeTitle.ExtraData.NoBillFlag;
                            $scope.setNonBillFlag(NoBillFlag);
                        }
                        if (!angular.isUndefined(selectedEmployeeTitle.ExtraData.TaxCommOnly)) {
                            TaxCommOnly = selectedEmployeeTitle.ExtraData.TaxCommOnly;
                            $scope.setTaxCommOnly(TaxCommOnly);
                        }
                        if (!angular.isUndefined(selectedEmployeeTitle.ExtraData.TaxComm)) {
                            TaxComm = selectedEmployeeTitle.ExtraData.TaxComm;
                            $scope.setTaxComm(TaxComm);
                        }
                        if (!angular.isUndefined(selectedEmployeeTitle.ExtraData.TaxCode)) {
                            TaxCode = selectedEmployeeTitle.ExtraData.TaxCode;
                            $scope.setTaxCode(TaxCode);
                        }
                        if (!angular.isUndefined(selectedEmployeeTitle.ExtraData.TaxState)) {
                            TaxState = selectedEmployeeTitle.ExtraData.TaxState;
                            $scope.setTaxStatePct(TaxState);
                        }
                        if (!angular.isUndefined(selectedEmployeeTitle.ExtraData.TaxCounty)) {
                            TaxCounty = selectedEmployeeTitle.ExtraData.TaxCounty;
                            $scope.setTaxCountyPct(TaxCounty);
                        }
                        if (!angular.isUndefined(selectedEmployeeTitle.ExtraData.TaxCity)) {
                            TaxCity = selectedEmployeeTitle.ExtraData.TaxCity;
                            $scope.setTaxCityPct(TaxCity);
                        }
                        if (!angular.isUndefined(selectedEmployeeTitle.ExtraData.TaxResale)) {
                            TaxResale = selectedEmployeeTitle.ExtraData.TaxResale;
                            $scope.setTaxResale(TaxResale);
                        }
                        if (!angular.isUndefined(selectedEmployeeTitle.ExtraData.TaxAmount)) {
                            TaxAmount = selectedEmployeeTitle.ExtraData.TaxAmount;
                            $scope.setTaxAmount(TaxAmount);
                        }
                        if (!angular.isUndefined(selectedEmployeeTitle.ExtraData.LineTotal)) {
                            LineTotal = selectedEmployeeTitle.ExtraData.LineTotal;
                            $scope.setLineTotal(LineTotal);
                        }
                        if (!angular.isUndefined(selectedEmployeeTitle.ExtraData.ContingencyAmount)) {
                            ContingencyAmount = selectedEmployeeTitle.ExtraData.ContingencyAmount;
                            $scope.setContingencyAmount(ContingencyAmount);
                        }
                        if (!angular.isUndefined(selectedEmployeeTitle.ExtraData.ExtendedAmount)) {
                            Amount = selectedEmployeeTitle.ExtraData.ExtendedAmount;
                            $scope.setAmount(Amount);
                        }
                        if (!angular.isUndefined(selectedEmployeeTitle.ExtraData.Commission)) {
                            Commission = selectedEmployeeTitle.ExtraData.Commission;
                            $scope.setCommission(Commission);
                        }
                        if (!angular.isUndefined(selectedEmployeeTitle.ExtraData.EmployeeTitleID)) {
                            EmployeeTitleID = selectedEmployeeTitle.ExtraData.EmployeeTitleID;
                            $scope.setEmployeeTitleID(EmployeeTitleID);
                        }
                        if (!angular.isUndefined(selectedEmployeeTitle.ExtraData.ContingencyPercent)) {
                            ContingencyPercent = selectedEmployeeTitle.ExtraData.ContingencyPercent;
                            $scope.setContingencyPercent(ContingencyPercent);
                        }
                    }
                }
            } else {
                if (currentCriteria.Function != '') {
                    var GlCode, GlDesc, CommissionPercent, Rate, NoBillFlag, TaxCommOnly, TaxComm, TaxCode, TaxState, TaxCounty, TaxCity, TaxResale, TaxAmount, LineTotal, ContingencyAmount, Amount, Commission, EmployeeTitleID, ContingencyPercent;
                    selectedEmployeeTitle = result.data.Results[0];
                    if (selectedEmployeeTitle) {
                        if (selectedEmployeeTitle.ExtraData) {
                            if (selectedEmployeeTitle.ExtraData.GeneralLedgerAccountCode) {
                                GlCode = selectedEmployeeTitle.ExtraData.GeneralLedgerAccountCode;
                                GlDesc = selectedEmployeeTitle.ExtraData.GeneralLedgerAccountDescription;
                            }
                            if (!angular.isUndefined(selectedEmployeeTitle.ExtraData.Rate)) {
                                Rate = selectedEmployeeTitle.ExtraData.Rate;
                                $scope.setRate(Rate);
                            }
                            if (!angular.isUndefined(selectedEmployeeTitle.ExtraData.CommissionPercent)) {
                                CommissionPercent = selectedEmployeeTitle.ExtraData.CommissionPercent;
                                $scope.setCommissionPercent(CommissionPercent);
                            }
                            if (!angular.isUndefined(selectedEmployeeTitle.ExtraData.NoBillFlag)) {
                                NoBillFlag = selectedEmployeeTitle.ExtraData.NoBillFlag;
                                $scope.setNonBillFlag(NoBillFlag);
                            }
                            if (!angular.isUndefined(selectedEmployeeTitle.ExtraData.TaxCommOnly)) {
                                TaxCommOnly = selectedEmployeeTitle.ExtraData.TaxCommOnly;
                                $scope.setTaxCommOnly(TaxCommOnly);
                            }
                            if (!angular.isUndefined(selectedEmployeeTitle.ExtraData.TaxComm)) {
                                TaxComm = selectedEmployeeTitle.ExtraData.TaxComm;
                                $scope.setTaxComm(TaxComm);
                            }
                            if (!angular.isUndefined(selectedEmployeeTitle.ExtraData.TaxCode)) {
                                TaxCode = selectedEmployeeTitle.ExtraData.TaxCode;
                                $scope.setTaxCode(TaxCode);
                            }
                            if (!angular.isUndefined(selectedEmployeeTitle.ExtraData.TaxState)) {
                                TaxState = selectedEmployeeTitle.ExtraData.TaxState;
                                $scope.setTaxStatePct(TaxState);
                            }
                            if (!angular.isUndefined(selectedEmployeeTitle.ExtraData.TaxCounty)) {
                                TaxCounty = selectedEmployeeTitle.ExtraData.TaxCounty;
                                $scope.setTaxCountyPct(TaxCounty);
                            }
                            if (!angular.isUndefined(selectedEmployeeTitle.ExtraData.TaxCity)) {
                                TaxCity = selectedEmployeeTitle.ExtraData.TaxCity;
                                $scope.setTaxCityPct(TaxCity);
                            }
                            if (!angular.isUndefined(selectedEmployeeTitle.ExtraData.TaxResale)) {
                                TaxResale = selectedEmployeeTitle.ExtraData.TaxResale;
                                $scope.setTaxResale(TaxResale);
                            }
                            if (!angular.isUndefined(selectedEmployeeTitle.ExtraData.TaxAmount)) {
                                TaxAmount = selectedEmployeeTitle.ExtraData.TaxAmount;
                                $scope.setTaxAmount(TaxAmount);
                            }
                            if (!angular.isUndefined(selectedEmployeeTitle.ExtraData.LineTotal)) {
                                LineTotal = selectedEmployeeTitle.ExtraData.LineTotal;
                                $scope.setLineTotal(LineTotal);
                            }
                            if (!angular.isUndefined(selectedEmployeeTitle.ExtraData.ContingencyAmount)) {
                                ContingencyAmount = selectedEmployeeTitle.ExtraData.ContingencyAmount;
                                $scope.setContingencyAmount(ContingencyAmount);
                            }
                            if (!angular.isUndefined(selectedEmployeeTitle.ExtraData.ExtendedAmount)) {
                                Amount = selectedEmployeeTitle.ExtraData.ExtendedAmount;
                                $scope.setAmount(Amount);
                            }
                            if (!angular.isUndefined(selectedEmployeeTitle.ExtraData.Commission)) {
                                Commission = selectedEmployeeTitle.ExtraData.Commission;
                                $scope.setCommission(Commission);
                            }
                            if (!angular.isUndefined(selectedEmployeeTitle.ExtraData.EmployeeTitleID)) {
                                EmployeeTitleID = selectedEmployeeTitle.ExtraData.EmployeeTitleID;
                                $scope.setEmployeeTitleID(EmployeeTitleID);
                            }
                            if (!angular.isUndefined(selectedEmployeeTitle.ExtraData.ContingencyPercent)) {
                                ContingencyPercent = selectedEmployeeTitle.ExtraData.ContingencyPercent;
                                $scope.setContingencyPercent(ContingencyPercent);
                            }
                        }
                    }
                }
                selectedEmployeeTitle = newEmployeeTitle;
            }
            $scope.setGeneralLedgerCode(GlCode);
            $scope.setGeneralLedgerAccountDescription(GlDesc);
            $scope.fillEmployeeTitleValues(selectedEmployeeTitle);
            if (newVal) {
                $scope.focusNextControl('EmployeeTitle');
            }
            $scope.parentRow = currentParentRow;
        });
    };

    $scope.vendorValuesChanged = function (vendor, fetch) {
        $scope.fillVendorValues(vendor);
        if (fetch) {
            $scope.searchCriteria.LookupType = 'Vendor';
            vendor.IncludeMediaVendors = true;
            $scope.searchCriteria.Vendor = vendor;
            var selectedVendor;
            var parentRow = $scope.parentRow;
            dataService.searchLookup($scope.searchCriteria).then(function (result) {
                var currentParentRow = $scope.parentRow;
                $scope.parentRow = parentRow;
                if (result.data.Results.length == 1) {
                    var CommissionPercent, Rate, NoBillFlag, TaxCommOnly, TaxComm, TaxCode, TaxState, TaxCounty, TaxCity, TaxResale;
                    selectedVendor = result.data.Results[0];
                    if (selectedVendor) {
                        if (selectedVendor.ExtraData) {
                            if (!angular.isUndefined(selectedVendor.ExtraData.Rate)) {
                                Rate = selectedVendor.ExtraData.Rate;
                                $scope.setRate(Rate);
                            }
                            if (!angular.isUndefined(selectedVendor.ExtraData.CommissionPercent)) {
                                CommissionPercent = selectedVendor.ExtraData.CommissionPercent;
                                $scope.setCommissionPercent(CommissionPercent);
                            }
                            if (!angular.isUndefined(selectedVendor.ExtraData.NoBillFlag)) {
                                NoBillFlag = selectedVendor.ExtraData.NoBillFlag;
                                $scope.setNonBillFlag(NoBillFlag);
                            }
                            if (!angular.isUndefined(selectedVendor.ExtraData.TaxCommOnly)) {
                                TaxCommOnly = selectedVendor.ExtraData.TaxCommOnly;
                                $scope.setTaxCommOnly(TaxCommOnly);
                            }
                            if (!angular.isUndefined(selectedVendor.ExtraData.TaxComm)) {
                                TaxComm = selectedVendor.ExtraData.TaxComm;
                                $scope.setTaxComm(TaxComm);
                            }
                            if (!angular.isUndefined(selectedVendor.ExtraData.TaxCode)) {
                                TaxCode = selectedVendor.ExtraData.TaxCode;
                                $scope.setTaxCode(TaxCode);
                            }
                            if (!angular.isUndefined(selectedVendor.ExtraData.TaxState)) {
                                TaxState = selectedVendor.ExtraData.TaxState;
                                $scope.setTaxStatePct(TaxState);
                            }
                            if (!angular.isUndefined(selectedVendor.ExtraData.TaxCounty)) {
                                TaxCounty = selectedVendor.ExtraData.TaxCounty;
                                $scope.setTaxCountyPct(TaxCounty);
                            }
                            if (!angular.isUndefined(selectedVendor.ExtraData.TaxCity)) {
                                TaxCity = selectedVendor.ExtraData.TaxCity;
                                $scope.setTaxCityPct(TaxCity);
                            }
                            if (!angular.isUndefined(selectedVendor.ExtraData.TaxResale)) {
                                TaxResale = selectedVendor.ExtraData.TaxResale;
                                $scope.setTaxResale(TaxResale);
                            }
                        }
                    }
                    $scope.fillVendorValues(result.data.Results[0]);
                } else {
                    $scope.fillVendorValues(null);
                }
                $scope.parentRow = currentParentRow;
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
                var quantity = $scope.getEstimateQuantity();
                var rate = $scope.getEstimateRate();
                var amount = $scope.getEstimateAmount();
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
        var code, name, limit, title;
        if (employee) {
            code = employee.EmployeeCode;
            name = employee.FullName;
            title = employee.EmployeeTitle;
        }
        if (!code) {
            name = null;
            limit = null;
            title = null;
        }
        $scope.setEmployeeCode(code);
        $scope.setEmployeeName(name);
        $scope.setEmployeeTitleName(title);
        $scope.quantityRateAmountChanged('Rate');
        
    };

    $scope.fillEmployeeTitleValues = function (employee) {
        var code, name, limit, title;
        if (employee) {
            title = employee.EmployeeTitle;
            code = employee.EmployeeTitleID;

        } 
        if (!code) {
            title = null;
        }
        $scope.setEmployeeTitle(title);
        $scope.setEmployeeTitleID(code);
        $scope.quantityRateAmountChanged('Rate');

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
        $scope.setEmployeeCode(code);
        //$scope.setEmployeeName(name);
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
        var code, desc, cpm, display, type;
        if (newFunction) {
            code = newFunction.FunctionCode;
            desc = newFunction.FunctionDescription;
            cpm = newFunction.CPMFlag;
            type = newFunction.FunctionType;
        }
        if (!code) {
            cpm = false;
            desc = null;
        }
        $scope.setFunctionCode(code);
        $scope.setFunctionDescription(desc);
        $scope.setFunctionType(type);
        if (cpm === true) {
            display = 'inline-block';
        } else {
            display = 'none';
        }
        $($scope.parentRow).find('div[id*=divCPM]').css('display', display);
        $scope.quantityRateAmountChanged('Rate');
    };

    $scope.fillTaxValues = function (newTax) {
        var code, state, county, city, resale;
        if (newTax) {
            code = newTax.TaxCode;
            state = newTax.TaxStatePct;
            county = newTax.TaxCountyPct;
            city = newTax.TaxCityPct;
            resale = newTax.TaxResale;
        }
        if (!code) {
            code = null;
            state = null;
            county = null;
            city = null;
            resale = null;
        }
        $scope.setTaxCode(code);

        $scope.setTaxStatePct(state);
        $scope.setTaxCountyPct(county);
        $scope.setTaxCityPct(city);
        $scope.setTaxResale(resale);
        //if (cpm === true) {
        //    display = 'inline-block';
        //} else {
        //    display = 'none';
        //}
        //$($scope.parentRow).find('div[id*=divCPM]').css('display', display);
        //$scope.quantityRateAmountChanged('Tax');
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
