var validator = {

    validation: $('body').kendoValidator({
        validateOnBlur: false,
        // please try to keep these rules in alphabetical order!
        rules: {
            // date, numeric, string, etc....

            numeric: function (element) {
                if (validator.checkApplyRuleToElement(element, 'numeric') === true) {
                    var isValid = true;
                    if (element.val() !== '') {
                        if (isNaN($(element).val())) {
                            return false;
                        };
                    }
                    validator.raiseValidated(element, isValid, status);
                    return isValid;
                }
                return true;
            },

            shortdate: function (element) {
                if (validator.checkApplyRuleToElement(element, 'shortdate') === true) {
                    var isValid = true;
                    if (element.val() !== '') {
                        var dateParseResponse = parseShortDate(element.val());
                        isValid = dateParseResponse.isValid;
                        if (isValid === true) {
                            var kendoDatePicker = element.data('kendoDatePicker');
                            if (kendoDatePicker) {
                                kendoDatePicker.value(kendo.parseDate(dateParseResponse.value));
                            } else {
                                element.val(dateParseResponse.value);
                            }
                        }
                    }
                    validator.raiseValidated(element, isValid, status);
                    return isValid;
                }
                return true;
            },

            // server
            employee: function (element) {
                var settings = {
                    url: validator.ruleSettings.employee.url,
                    data: validator.ruleSettings.employee.data(element)
                };
                return validator.ajaxHandler(element, 'employee', settings);
            },
            estimateFunction: function (element) {
                var settings = {
                    url: validator.ruleSettings.estimateFunction.url,
                    data: validator.ruleSettings.estimateFunction.data(element)
                };
                return validator.ajaxHandler(element, 'estimateFunction', settings);
            },
            phase: function (element) {
                var settings = {
                    url: validator.ruleSettings.phase.url,
                    data: validator.ruleSettings.phase.data(element)
                };
                return validator.ajaxHandler(element, 'phase', settings);
            },
            task: function (element) {
                var settings = {
                    url: validator.ruleSettings.task.url,
                    data: validator.ruleSettings.task.data(element)
                };
                return validator.ajaxHandler(element, 'task', settings);
            },
            taskStatus: function (element) {
                if (validator.checkApplyRuleToElement(element, 'taskStatus') === true) {
                    var isValid = true;
                    if (element.val() !== '') {
                        var statusList = [
                            { Code: 'P', Description: 'Projected' },
                            { Code: 'A', Description: 'Active' },
                            { Code: 'L', Description: 'Low Priority' },
                            { Code: 'H', Description: 'High Priority' }];
                        var status;
                        $(statusList).each(function () {
                            if (this.Code.toUpperCase() === element.val().toUpperCase() || this.Description.toUpperCase() === element.val().toUpperCase()) {
                                status = this;
                                return false;
                            }
                        });
                        if (!status) {
                            isValid = false;
                        }
                    }
                    validator.raiseValidated(element, isValid, status);
                    return isValid;
                }
                return true;
            },
            trafficStatus: function (element) {
                var settings = {
                    url: validator.ruleSettings.trafficStatus.url,
                    data: validator.ruleSettings.trafficStatus.data(element)
                };
                return validator.ajaxHandler(element, 'trafficStatus', settings);
            },
        },
        messages: {
            shortdate: "Please enter a valid date.",
            date: "Please enter a valid date.",
            employee: "Please enter a valid employee code.",
            estimateFunction: "Please enter a valid function code.",
            numeric: "Please enter a valid number.",
            phase: "Please enter a valid phase.",
            task: "Please enter a valid task code.",
            taskStatus: "Please enter a valid status.",
            trafficStatus: "Please enter a valid status."
        }
    }).data('kendoValidator'),

    errors: function () {
        return this.validation.errors();
    },

    clearErrors: function(){
        this.validation._errors = {};
    },

    validateInput: function(element){
        return this.validation.validateInput(element);
    },

    validate: function(){validator.validation.validateInput(element);
        return this.validation.validate();
    },

    raiseValidated: function(element, isValid, results){
        var event = $.Event('validated');
        event.isValid = isValid;
        event.results = results;
        $(element).trigger(event);
    },

    checkApplyRuleToElement: function (element, rule) {
        var validate = element.data(rule.toLowerCase());
        if (typeof validate !== 'undefined' && validate !== false) {
            return true;
        }
        return false;
    },

    ajaxValidator: {
        cache: {},
        validate: function (element, settings) {
            var id = element.attr('id');
            var cache = this.cache[id] = this.cache[id] || {};
            $.ajax({
                url: settings.url,
                data: settings.data,
                dataType: 'json',
                success: function (data) {
                    cache.valid = data.Success;
                    cache.data = data;
                    cache.value = element.val();
                    validator.validation.validateInput(element);
                },
                failure: function (data) {
                    // ajax call failed
                    cache.valid = true;
                    cache.data = data;
                    validator.validation.validateInput(element);
                },
                complete: function () {
                    cache.value = element.val();
                }
            });

        }
    },

    ajaxHandler: function (element, rule, settings) {
        if (this.checkApplyRuleToElement(element, rule) === true) {
            if (validator.pickedHandler(element) === true) {
                return true;
            }
            if (element.val() !== '') {
                var id = element.attr('id');
                var cache = validator.ajaxValidator.cache[id] = validator.ajaxValidator.cache[id] || {};
                cache.checking = true;
                if (cache.value === element.val() && cache.valid === true) {
                    validator.raiseValidated(element, true, cache.data);
                    return true;
                }
                if (cache.value === element.val() && !cache.valid === true) {
                    cache.checking = false;
                    validator.raiseValidated(element, false, cache.data);
                    return false;
                }
                validator.ajaxValidator.validate(element, settings);
                return true;
            } else {
                validator.raiseValidated(element, true, {});
                return true;
            }
        }
        return true;
    },
    pickedHandler: function (element) {
        var picked = element.attr('picked');
        if (typeof picked !== 'undefined') {
            element.removeAttr('picked');
            return true;
        }
        return false;
    },
    ruleSettings: {
        employee: {
            url: window.appBase + 'ProjectManagement/ProjectSchedule/ValidateAssignment',
            data: function (element) {
                return { EmployeeCode: element.val() };
            }
        },
        estimateFunction: {
            url: window.appBase + 'ProjectManagement/ProjectSchedule/ValidateFunction',
            data: function (element) {
                return { FunctionCode: element.val() };
            }
        },
        phase: {
            url: window.appBase + 'ProjectManagement/ProjectSchedule/ValidatePhase',
            data: function (element) {
                return { PhaseDescription: element.val() };
            }
        },
        task: {
            url: window.appBase + 'ProjectManagement/ProjectSchedule/ValidateTask',
            data: function (element) {
                return { TaskCode: element.val() };
            }
        },
        trafficStatus: {
            url: window.appBase + 'ProjectManagement/ProjectSchedule/ValidateStatus',
            data: function (element) {
                return { StatusCode: element.val() };
            }
        }
    }
};

$('body').on('keypress', '[data-numeric]', function (e) {
    var allowDecimals = !($(this).attr('data-numeric').toUpperCase() === 'integer'.toUpperCase());
    if (!isNumeric(e, allowDecimals)) {
        return false;
    }
}).on('change', '[data-numeric]', function (e) {
    validator.validateInput(this);
}).on('validated', '[data-numeric][data-format], [data-numeric=""][data-format]', function () {
    $(this).trigger('formatValue');
}).on('formatValue', '[data-format]', function () {
    var format = $(this).attr('data-format');
    if ($(this).val() !== '' && format !== '') {
        if (validator.checkApplyRuleToElement($(this), 'numeric')) {
            $(this).val(kendo.toString(Number($(this).val()), format));
        } else {
            $(this).val(kendo.toString($(this).val(), format));
        }
    }
}).on('change', '[data-shortdate][data-role="datepicker"]', function () {
    var val = $(this).val();
    var response = parseShortDate(val);
    if (response.isValid === true) {
        $(this).data('kendoDatePicker').value(new kendo.parseDate(response.value));
    }
    validator.validateInput(this);
});

function isNumeric(evt, allowDecimals) {
    var e = evt || window.event;
    var key = e.keyCode || e.which;
    key = String.fromCharCode(key);
    var regex = /[0-9]|\./;
    if (allowDecimals === false) {
        regex = /[0-9]/;
    }
    if (!regex.test(key)) {
        e.returnValue = false;
        if (e.preventDefault) e.preventDefault();
        return false;
    }
    return true;
}

function parseDate(formats, value) {
    var isValid = false;
    var parsedDate = kendo.parseDate(value);
    if (!parsedDate) {
        $.each(formats, function () {
            parsedDate = kendo.parseDate(value, this);
            if (parsedDate) {
                return false;
            }
        });
    };
    if (parsedDate) {
        parsedDate = kendo.toString(parsedDate, 'd');
        isValid = true;
    }
    return {
        isValid: isValid,
        value: parsedDate
    }
}

function parseShortDate(value) {
    var formats = ["MM/dd/yyyy", "MM/dd/yy", "MMddyyyy", "MMddyy"];
    return parseDate(formats, value);
}