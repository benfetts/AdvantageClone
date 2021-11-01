AdvantageMobile_UI.submit_options = function (params, viewInfo) {

    var invoiceNumber = ko.observable(0);
    var employeeCode = ko.observable("");
    var employeeFullName = ko.observable("--");
    var employeeSupervisorApprovalRequired = ko.observable(false);
    var supervisorEmployeeCode = ko.observable("");
    var supervisorEmployeeFullName = ko.observable("--");
    var alternateApproverEmployeeCode = ko.observable("");
    var alternateApproverEmployeeFullName = ko.observable("--");
    var includeReceiptsInEmailAndAlert = ko.observable(false);
    var availableApprovers = ko.observable([]);
    var selectedApproverEmployeeCode = ko.observable("");
    var ddl = null;
    var loadingPanel = {
        message: "Loading",
        visible: ko.observable(false),
        shading: false
    };
    var loadPanelMessage = ko.observable("");
    var warningBlockCSS = ko.observable("");
    var headerMessage = ko.observable("");
    var loadPanelVisible = ko.observable(false);
    var loaded = false;
    var expenseReportOptionsViewModel = new AdvantageMobile_UI.ExpenseReportOptionsViewModel();
    var hasSupervisor = false;
    var hasAlternate = false;
    var submitButton = {
        text: "Submit",
        onClick: function (e) {
            loadPanelVisible(true);
            var approver = viewModel.selectedApproverEmployeeCode(); 
            var includeReciepts = $("#chkIncludeReceiptsInEmailAndAlert");
            AdvantageMobile_UI.db.get('SubmitExpenseReport', {
                EmployeeCode: AdvantageMobile_UI.CurrentUser.EmployeeCode(),
                InvoiceNumber: viewModel.invoiceNumber() * 1,
                ApproverEmployeeCode: viewModel.selectedApproverEmployeeCode(),
                IncludeReceiptsInEmailAndAlert: includeReciepts[0].checked
            }).done(function (data) {
                if (data === "" || data === "Successfully submitted expense report.") {
                    AdvantageMobile_UI.Messages.toastSuccess('Expense Report Submitted!');
                    AdvantageMobile_UI.app.navigate({
                        view: 'expenses_summary',
                        settings: {}
                    });
                } else {
                    AdvantageMobile_UI.Messages.toastWarning(data);
                }
                loadPanelVisible(false);
            }).fail(function (data) {
                loadPanelVisible(false);
                handleDataServiceError(data);
            });
        }
    };
    var cancelButton = {
        text: "Cancel",
        onClick: function (e) {
            AdvantageMobile_UI.app.back();
            //var buttonSettings;
            //buttonSettings = { source: 0 };
            //AdvantageMobile_UI.app.navigate({
            //    view: "project_list",
            //    settings: buttonSettings
            //});
        }
    };
    var approversDataSource = new DevExpress.data.DataSource({
        load: function (loadOptions) {
            var d = new $.Deferred();
            var filterOptions = loadOptions.filter ? loadOptions.filter.join(",") : "";
            var skip = loadOptions.skip;
            var take = loadOptions.take;
            var searchVal = "";
            if (loadOptions.searchValue !== null) {
                searchVal = loadOptions.searchValue;
            }
            AdvantageMobile_UI.db.get('GetApproverList', {
                EmployeeCode: AdvantageMobile_UI.CurrentUser.EmployeeCode(),
                SearchValue: searchVal,
                Skip: skip,
                Take: take
            }).done(function (data) {
                if (data) {
                    d.resolve(data);
                    availableApprovers = data;
                    if (availableApprovers) {
                        if (hasSupervisor == false || hasAlternate == false) {
                            var h;
                            for (h = 0; h < availableApprovers.length; h++) {
                                //console.log("availableApprover" + h + " :: ", availableApprovers[h]);
                                if (hasAlternate == false && availableApprovers[h].EmployeeFullName.includes("**") == true) {
                                    viewModel.alternateApproverEmployeeCode(availableApprovers[h].EmployeeCode);
                                    hasAlternate == true;
                                }
                                if (hasSupervisor == false && availableApprovers[h].EmployeeFullName.includes("*") == true) {
                                    viewModel.supervisorEmployeeCode(availableApprovers[h].EmployeeCode);
                                    hasSupervisor == true;
                                }
                            }
                        }
                        //if (viewModel.supervisorEmployeeCode() || viewModel.alternateApproverEmployeeCode()) {
                        //    var i;
                        //    for (i = 0; i < availableApprovers.length; i++) {
                        //        //text += cars[i] + "<br>";
                        //        //console.log("availableApprover" + i + " :: ", availableApprovers[i]);
                        //        if (availableApprovers[i].EmployeeCode === viewModel.supervisorEmployeeCode()) {
                        //            hasSupervisor = true;
                        //            //availableApprovers[i].EmployeeFullName = availableApprovers[i].EmployeeFullName + "*";
                        //            //console.log("super");
                        //        }
                        //        if (availableApprovers[i].EmployeeCode === viewModel.alternateApproverEmployeeCode()) {
                        //            hasAlternate = true;
                        //            //availableApprovers[i].EmployeeFullName = availableApprovers[i].EmployeeFullName + "**";
                        //            //console.log("alt");
                        //        }
                        //    }
                        //}
                        window.setTimeout(function () {
                            //console.log("viewModel.alternateApproverEmployeeCode()", viewModel.alternateApproverEmployeeCode());
                            try {
                                var valSet = false;
                                if (valSet === false && viewModel.alternateApproverEmployeeCode()) {
                                    viewModel.selectedApproverEmployeeCode(viewModel.alternateApproverEmployeeCode());
                                    valSet = true;
                                }
                                if (valSet === false && viewModel.supervisorEmployeeCode()) {
                                    viewModel.selectedApproverEmployeeCode(viewModel.supervisorEmployeeCode());
                                    valSet = true;
                                }
                            } catch (e) {
                                //
                            }
                            //console.log("viewModel.selectedApproverEmployeeCode()", viewModel.selectedApproverEmployeeCode());
                        }, 250);
                    }
                }
            }).fail(function (data) {
                handleDataServiceError(data);
            });
            return d.promise();
        }
        ,
        byKey: function (key) {
            if (key && key.toString() !== '') {
                //console.log("key?????", key);
                //console.log("?????", AdvantageMobile_UI.CurrentUser.ServicesURL() + 'Employees(\'' + key.toString() + '\')');
                //return $.getJSON(AdvantageMobile_UI.CurrentUser.ServicesURL() + 'Employees(\'' + key.toString() + '\')');
                return $.getJSON(AdvantageMobile_UI.CurrentUser.ServicesURL() + "GetApprover?Key='" + key.toString() + "'");
            }
        }
    });
    var clientsSelectBox = {
        dataSource: approversDataSource,
        displayExpr: 'EmployeeFullName',
        valueExpr: 'EmployeeCode',
        value: selectedApproverEmployeeCode,
        onValueChanged: onClientsChange,
        placeholder: localizeString('Select') + ' ' + localizeString('Approver'),
        title: localizeString('Select') + ' ' + localizeString('Approver'),
        readOnly: ko.observable(false),
        visible: ko.observable(true),
        searchEnabled: true,
        searchTimeout: 1000,
        cleanSearchOnOpening: true,
        closeOnOutsideClick: true
    };

    function onClientsChange(e) {
        //jobLookupScrolled = false;
        //if (viewShowingCompleted == true) {
        //    divisionDSLoaded = false;
        //    divisionCode(null);
        //    productCode(null);
        //    jobNumber(null);
        //    jobComponentNumber(null);
        //    viewModel.clientCode(e.value)
        //    companyCodeTemp = e.value;
        //    this.divisionsDataSource.load();
        //}
    }
    function loadSubmitOptions() {
        if (viewModel.invoiceNumber() && viewModel.invoiceNumber() > 0) {
            loadPanelVisible(true);
            var d = new $.Deferred();        
            AdvantageMobile_UI.db.get('GetExpenseReportOptions', {
                InvoiceNumber: viewModel.invoiceNumber()
            }).done(function (data) {
                d.resolve(data);
                if (data) {
                    try {
                        viewModel.invoiceNumber(data.InvoiceNumber);
                    } catch (e) {
                        console.error(e);
                    }
                    try {
                        viewModel.employeeCode(data.EmployeeCode);
                    } catch (e) {
                        console.error(e);
                    }
                    try {
                        viewModel.employeeFullName(data.EmployeeFullName);
                    } catch (e) {
                        console.error(e);
                    }
                    try {
                        viewModel.employeeSupervisorApprovalRequired(data.EmployeeSupervisorApprovalRequired);
                    } catch (e) {
                        console.error(e);
                    }
                    try {
                        viewModel.supervisorEmployeeCode(data.SupervisorEmployeeCode);
                    } catch (e) {
                        console.error(e);
                    }
                    try {
                        viewModel.supervisorEmployeeFullName(data.SupervisorEmployeeFullName);
                        if (viewModel.supervisorEmployeeFullName() == "") {
                            viewModel.supervisorEmployeeFullName("--");
                        }
                    } catch (e) {
                        console.error(e);
                    }
                    try {
                        viewModel.alternateApproverEmployeeCode(data.AlternateApproverEmployeeCode);
                    } catch (e) {
                        console.error(e);
                    }
                    try {
                        viewModel.alternateApproverEmployeeFullName(data.AlternateApproverEmployeeFullName);
                        if (viewModel.alternateApproverEmployeeFullName() == "") {
                            viewModel.alternateApproverEmployeeFullName("--");
                        }
                    } catch (e) {
                        console.error(e);
                    }
                    try {
                        viewModel.includeReceiptsInEmailAndAlert(data.IncludeReceiptsInEmailAndAlert);
                    } catch (e) {
                        console.error(e);
                    }
                }
                loadPanelVisible(false);
                approversDataSource.load();
            }).fail(function (data) {
                loadPanelVisible(false);
                handleDataServiceError(data);
            });
            return d.promise();
        }
    }
    function viewShowing(e) {
        //console.log("viewShowing", e);
        //console.log("params", params);
        //console.log("params.settings", params.settings);
        /*
            from = 0 = detail 
            from = 1 = summary
        */
        if (params && params.settings) {
            viewModel.invoiceNumber(params.settings.invoiceNumber * 1);
        }
        loadSubmitOptions();
    }
    function viewShown(e) {

    }

    var viewModel = {
        viewShowing: viewShowing,
        viewShown: viewShown,
        loadingPanel: loadingPanel,
        loadPanelVisible: loadPanelVisible,
        loadPanelMessage: loadPanelMessage,
        warningBlockCSS: warningBlockCSS,
        headerMessage: headerMessage,
        invoiceNumber: invoiceNumber,
        employeeCode: employeeCode,
        employeeFullName: employeeFullName,
        employeeSupervisorApprovalRequired: employeeSupervisorApprovalRequired,
        supervisorEmployeeCode: supervisorEmployeeCode,
        supervisorEmployeeFullName: supervisorEmployeeFullName,
        alternateApproverEmployeeCode: alternateApproverEmployeeCode,
        alternateApproverEmployeeFullName: alternateApproverEmployeeFullName,
        includeReceiptsInEmailAndAlert: includeReceiptsInEmailAndAlert,
        availableApprovers: availableApprovers,
        expenseReportOptionsViewModel: expenseReportOptionsViewModel,
        approversDataSource: approversDataSource,
        selectedApproverEmployeeCode: selectedApproverEmployeeCode,
        submitButton: submitButton,
        clientsSelectBox: clientsSelectBox,
        cancelButton: cancelButton
    };
    return viewModel;

};