app.controller('expenseReportController', function ($scope, $rootScope, $http, $modal, $timeout, dataService) {
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
        if (inputControl) {
            radInput = $find($(inputControl).attr('id'));
        }
        return radInput;
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
    $scope.getFunctionDescription = function () {
        return $scope.getDescriptionInputValue('Function');
    };
    $scope.getQuantity = function () {
        return $scope.getNumericInputValue('Quantity');
    };
    $scope.getRate = function () {
        return $scope.getNumericInputValue('Rate');
    };
    $scope.getAmount = function () {
        return $scope.getNumericInputValue('Amount');
    };
    $scope.getEffectiveDate = function () {
        var inputControl, radInput, effectiveDate;
        if ($scope.parentRow) {
            inputControl = $($scope.parentRow).find('input[name*=RadDatePickerItemTemplate_ItemDate]')[0];
        }
        if (inputControl) {
            radInput = $find($(inputControl).attr('id'));
            effectiveDate = radInput.get_selectedDate();
        }
        return effectiveDate;
    };
    $scope.getNonBillable = function () {
        var iconDiv, isNonBillable = false;
        if ($scope.parentRow) {
            iconDiv = $($scope.parentRow).find('div[id*=DivFlagColor]')[0];
        }
        if (iconDiv) {
            isNonBillable = !$(iconDiv).hasClass('hidden');
        }
        return isNonBillable;
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
    $scope.getDescriptionLabelValue = function (inputType) {
        var descriptionLabel = $scope.getDescriptionLabel(inputType);
        var value;
        if (descriptionLabel) {
            value = $(descriptionLabel).val();
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
        $scope.setDescriptionLabelValue('Job', value);
    };
    $scope.setJobComponentNumber = function (value) {
        $scope.setInputValue('JobComponent', value);
    };
    $scope.setJobComponentDescription = function (value) {
        $scope.setDescriptionLabelValue('JobComponent', value);
    };
    $scope.setFunctionCode = function (value) {
        $scope.setInputValue('Function', value);
    };
    $scope.setFunctionDescription = function (value) {
        $scope.setDescriptionInputValue('Function', value);
    };
    $scope.setQuantity = function (value) {
        $scope.setNumericInputValue('Quantity', value);
    }
    $scope.setRate = function (value) {
        $scope.setNumericInputValue('Rate', value);
    };
    $scope.setAmount = function (value) {
        $scope.setNumericInputValue('Amount', value);
    };
    $scope.setNonBillable = function (value) {
        var visibleClass = 'icon-background standard-green',
            hiddenClass = 'hidden',
            classToAdd = hiddenClass,
            classToRemove = visibleClass;
        if (value === true) {
            classToAdd = visibleClass;
            classToRemove = hiddenClass;
        };
        $($scope.parentRow).find('div[id*=DivFlagColor]').removeClass(classToRemove).addClass(classToAdd);
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
    $scope.setDescriptionLabelValue = function (inputID, value) {
        var label = $scope.getDescriptionLabel(inputID);
        if (label) {
            $(label).html(value);
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
                FunctionDescription: $scope.getFunctionDescription(),
                ExtraData: { EffectiveDate: $scope.getEffectiveDate() }
            },
            LookupType: lookupType,
            ShowInactive: false,
            SecurityModule: $('#HiddenFieldSecMod').val()
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

        if ($scope.currentRadWindow === null) {
            $scope.currentRadWindow = $rootScope.getCurrentRadWindow();
        }

        //$scope.OpenRadWindowLookup("ModalFilterDialog.aspx?" + queryString,"", 0,0,1);

        OpenRadWindowLookup2("ModalFilterDialog.aspx?" + queryString, currentCriteria, $scope);

        //var oBrowserWnd = $scope.currentRadWindow.BrowserWindow;
        //setTimeout(function () {
        //    var newWindow = oBrowserWnd.radopen("ModalFilterDialog.aspx?" + queryString, null, 540, 635);
        //    newWindow.set_modal(true);
        //    if (newWindow) {
        //        var contentWindow = newWindow.get_contentFrame().contentWindow;
        //        newWindow.add_pageLoad(function () {
        //            contentWindow.initialSearchResults(currentCriteria, $scope);
        //        });
        //    }
        //}, 0);
    };

    $scope.OpenRadWindowLookup = function (url, onCloseCallback) {
        //alert("Angular dialog");

        let Dialog = $("#LookUpDlgDiv");

        if (typeof Dialog !== 'undefined' && Dialog.length) {
            $("#LookUpDlgDiv").remove();
            Dialog = $('<div id="LookUpDlgDiv"></div>');
        }
        else {
            Dialog = $('<div id="LookUpDlgDiv"></div>');
        }

        var Title = '';

        Dialog.ejDialog({
            autoOpen: false,
            modal: true,
            height: 700,
            width: 625,
            title: "Lookup" + Title,
            enableResize: false,
            contentUrl: url,
            contentType: "iframe"
        });

        var iFrame = Dialog[0].ownerDocument.getElementsByClassName('e-iframe')[0];

        iFrame.contentWindow.Close = function (selectedItem) {

            if (onCloseCallback) {
                onCloseCallback(selectedItem);
            }

            Dialog.ejDialog('close');
        }
    }


    $scope.jobComponentValuesChanged = function (JobComponent, newVal) {
        var lookupType;
        if (newVal) {
            if (!JobComponent.ClientCode || !JobComponent.DivisionCode || !JobComponent.ProductCode || !JobComponent.JobNumber || !JobComponent.JobComponentNumber || !JobComponent.JobComponentDescription) {
                if (JobComponent.JobNumber) { //backfill job/comp fields
                    if (JobComponent.JobComponentNumber) {
                        lookupType = 'JobComponent';
                    } else if (!JobComponent.ClientCode || !JobComponent.DivisionCode || !JobComponent.ProductCode) {
                        lookupType = 'Job';
                    } else {
                        lookupType = 'JobComponent';
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
                } else if (!JobComponent.JobComponentDescription){
                    lookupType = 'JobComponent';
                }
            }
        }
        if (lookupType) {
            $scope.searchCriteria.LookupType = lookupType;
            $scope.searchCriteria.JobComponent = JobComponent;
            dataService.searchLookup($scope.searchCriteria).then(function (result) {
                if (result.data.Results.length === 1) {
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

        if (level === 'JobComponent' || level === 'Client' || level === 'Division' || level === 'Product' || level === 'Job') {
            if (!$scope.getClientCode()) {
                $scope.getInput('Client').focus();
            } else if (!$scope.getDivisionCode()) {
                $scope.getInput('Division').focus();
            } else if (!$scope.getProductCode()) {
                $scope.getInput('Product').focus();
            } else if (!$scope.getJobNumber()) {
                $scope.getInput('Job').focus();
            } else if (!$scope.getJobComponentNumber()) {
                $scope.getInput('JobComponent').focus();
            } else {
                $scope.getInput('Function').focus();
            }
        } else {
            if (!$scope.getInputValue(level)) {
                $scope.getInput(level).focus();
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
                            nextInput.focus();
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
    };

    $scope.functionValuesChanged = function (newFunction, newVal) {
        var currentCriteria = $scope.getSearchCriteria();
        currentCriteria.LookupType = 'Function';
        currentCriteria.Function = newFunction;
        currentCriteria.Function.ExtraData = { EffectiveDate: $scope.getEffectiveDate() }
        var selectedFunction;
        dataService.searchLookup(currentCriteria).then(function (result) {
            if (result.data.Results.length == 1) {
                var Rate;
                var NonBillable = false;
                selectedFunction = result.data.Results[0];
                if (selectedFunction) {
                    if (selectedFunction.ExtraData) {
                        if (selectedFunction.ExtraData.Rate) {
                            Rate = selectedFunction.ExtraData.Rate;
                            $scope.setRate(Rate);
                        }
                        if (selectedFunction.ExtraData.NonBillable != null) {
                            NonBillable = selectedFunction.ExtraData.NonBillable;
                        }
                        $scope.setNonBillable(NonBillable);
                    }
                }
            } else {
                selectedFunction = newFunction;
            }
            $scope.fillFunctionValues(selectedFunction);
            if (newVal) {
                $scope.focusNextControl('Function');
            }
        });
    };

    var calcRunning = false;

    $scope.quantityRateAmountChanged = function (changed) {
        if (calcRunning === false) {
            calcRunning = true;
            try{
                var quantityChanged = changed === 'Quantity' ? true : false;
                var rateChanged = changed === 'Rate' ? true : false;
                var amountChanged = changed === 'Amount' ? true : false;
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
                $scope.setQuantity(quantity);
                $scope.setRate(rate);
                $scope.setAmount(amount);
                //$find('RadNumericTextBoxPOTotal').set_value(total);
                $scope.parentRow = pr;
            } catch (ex) {
            }
            calcRunning = false;
        }
    };

    var calculateAmount = function (quantity, rate) {
        return roundNumber(quantity * rate, 2);
    }

    var calculateQuantity = function (rate, amount) {
        var quantity;
        quantity = amount / rate;
        return roundNumber(quantity, 0);
    }

    var calculateRate = function (quantity, amount) {
        rate = amount / quantity;
        return roundNumber(rate, 4);
    }

    var roundNumber = function (number, decimals) {
        return Number(Number(number).toFixed(decimals).replace(/(\d)(?=(\d{3})+\.)/g, '$1,').replace(/,/g, ''));
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
        } else if (!compNum || compNum === '' || compNum === 0) {
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

    };

    $scope.fillFunctionValues = function (newFunction) {
        var code, desc, display;
        if (newFunction) {
            code = newFunction.FunctionCode;
            desc = newFunction.FunctionDescription;
        }
        if (!code) {
            desc = null;
        }
        $scope.setFunctionCode(code);
        $scope.setFunctionDescription(desc);
        $scope.quantityRateAmountChanged('Rate');
    };

    $scope.toggleAnimation = function () {
        $scope.animationsEnabled = !$scope.animationsEnabled;
    };

    $scope.initActions = function () {
        var currentCriteria = $scope.getSearchCriteria();
        
    };

    $scope.initActions();

});
