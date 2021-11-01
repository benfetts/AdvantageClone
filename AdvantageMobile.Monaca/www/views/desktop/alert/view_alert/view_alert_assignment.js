AdvantageMobile_UI.view_alert_assignment = function (params, viewInfo) {

    var alertId = ko.observable(0);
    var loadPanelVisible = ko.observable(false);
    var templatesLoaded = false;
    var statesLoaded = false;
    var assignToLoaded = false;
    var alertSource = 0; // 0 = details, 1 = assignment list
    var getDefaultEmployee = false;
    var templateId = ko.observable();
    var stateId = ko.observable();
    var currentAssignedEmployeeCode = ko.observable();
    var assignToEmployeeCode = ko.observable();
    var defaultEmployeeCode = ko.observable();

    var templateName = ko.observable();
    var stateName = ko.observable();
    var assignedToListData = ko.observable([]);
    var comment = ko.observable();
    var hideShowSingle = ko.observable("");
    var hideShowMulti = ko.observable("hide");
    var assignedToList = {
        dataSource: assignedToListData
    };

    var templatesDataSource = new DevExpress.data.DataSource({
        load: function () {
            if (templatesLoaded == false) {
                var d = new $.Deferred();
                AdvantageMobile_UI.db.get('GetAssignmentTemplates', {
                }).done(function (data) {
                    d.resolve(data);
                    templatesLoaded = true;
                }).fail(function (data) {
                    handleDataServiceError(data);
                });
                return d.promise();
            }
        },
        map: function (item) {
            return new AdvantageMobile_UI.AlertAssignmentTemplateViewModel(item);
        },
        byKey: function (key) {
            if (key && isNaN(key) == false) {
                templateId(key);
                return $.getJSON(AdvantageMobile_UI.CurrentUser.ServicesURL() + 'AlertAssignmentTemplates(' + key + ')');
            }
        }
    });
    var statesDataSource = new DevExpress.data.DataSource({
        load: function () {
            if (statesLoaded == false && templateId()) {
                var d = new $.Deferred();
                AdvantageMobile_UI.db.get('GetAssignmentTemplateStates', {
                    AssignmentTemplateID: templateId()
                }).done(function (data) {
                    d.resolve(data);
                    statesLoaded = true;
                }).fail(function (data) {
                    handleDataServiceError(data);
                });
                return d.promise();
            }
        },
        map: function (item) {
            return new AdvantageMobile_UI.AlertAssignmentStateViewModel(item);
        },
        byKey: function (key) {
            if (key && isNaN(key) == false) {
                return $.getJSON(AdvantageMobile_UI.CurrentUser.ServicesURL() + 'AlertAssignmentStates(' + key + ')');
            }
        }
    });
    var employeesDataSource = new DevExpress.data.DataSource({
        load: function () {
            if (assignToLoaded == false && templateId() && stateId()) {
                var d = new $.Deferred();
                AdvantageMobile_UI.db.get('GetAssignmentTemplateStateEmployees', {
                    AssignmentTemplateID: templateId(),
                    AssignmentStateID: stateId(),
                    ShowAllActive: showAllEmployeesCheckBox.value()
                }).done(function (data) {
                    d.resolve(data);
                    if (getDefaultEmployee == true) {
                        getAssignmentTemplateStateDetails();
                    }
                    assignToLoaded = true;
                }).fail(function (data) {
                    handleDataServiceError(data);
                });
                return d.promise();
            }
        },
        map: function (item) {
            //workaround for full name and byKey display
            var emp = new AdvantageMobile_UI.EmployeeViewModel(item);
            var empName = "";
            empName = item.FirstName + " ";
            if (item.MiddleInitial != undefined && item.MiddleInitial != "") {
                empName = empName + item.MiddleInitial + ". ";
            }
            empName = empName + item.LastName;
            emp.FirstName = empName;
            return emp;
        },
        byKey: function (key) {
            if (key && key.toString() != '') {
                return $.getJSON(AdvantageMobile_UI.CurrentUser.ServicesURL() + 'Employees(\'' + key + '\')');
            }
        }
    });
    var templatesSelectBox = {
        dataSource: templatesDataSource,
        displayExpr: 'Name',
        valueExpr: 'ID',
        value: templateId,
        onItemClick: onTemplatesChange,
        disabled: ko.observable(false),
        visible: ko.observable(true)
    };
    var statesSelectBox = {
        dataSource: statesDataSource,
        displayExpr: 'Name',
        valueExpr: 'ID',
        value: stateId,
        onItemClick: onStatesChange,
        disabled: ko.observable(false),
        visible: ko.observable(true)
    };
    var employeesSelectBox = {
        dataSource: employeesDataSource,
        displayExpr: 'FirstName',
        valueExpr: 'Code',
        value: assignToEmployeeCode,
        onItemClick: onEmployeessChange,
        disabled: ko.observable(false),
        visible: ko.observable(true)
    };
    var showAllEmployeesCheckBox = {
        value: ko.observable(false),
        visible: ko.observable(true),
        onValueChanged: onShowAllEmployeesCheckChange
    };
    var commentsTextArea = {
        value: ko.observable()
    };
    var isMultiAssignee = false;

    function getAssignedEmployee() {
        AdvantageMobile_UI.db.get('GetAlertAssignedEmployee', { AlertID: alertId() })
            .done(function (data) {
                currentAssignedEmployeeCode(data.Code);
                assignToEmployeeCode(currentAssignedEmployeeCode());
                //alert("getAssignedEmployee " + assignToEmployeeCode())
            })
            .fail(function (data) {
                handleDataServiceError(data);
            });
    }
    function getAssignmentTemplateStateDetails() {
        AdvantageMobile_UI.db.get('GetAssignmentTemplateStateDetails', {
            AssignmentTemplateID: templateId(),
            AssignmentStateID: stateId()
        })
            .done(function (data) {
            if (data.DefaultEmployeeCode != null) {
                defaultEmployeeCode(data.DefaultEmployeeCode);
                assignToEmployeeCode(data.DefaultEmployeeCode);
            } else {
                assignToEmployeeCode(null);
            }
            getDefaultEmployee = false;
        })
        .fail(function (data) {
            //handleDataServiceError(data);
        });
    }
    function getAlertAssignees() {
        loadPanelVisible(true);
        AdvantageMobile_UI.db.get('GetAlertAssignees', { AlertID: alertId() })
            .done(function (data) {
                viewModel.assignedToListData(data);
                if (data && data.length > 1) {
                    viewModel.isMultiAssignee = true;
                } else {
                    viewModel.isMultiAssignee = false;
                }
                if (viewModel.isMultiAssignee === true) {
                    viewModel.hideShowSingle("hide");
                    viewModel.hideShowMulti("");
                    viewModel.statesSelectBox.disabled(true);
                } else {
                    viewModel.hideShowSingle("");
                    viewModel.hideShowMulti("hide");
                    viewModel.statesSelectBox.disabled(false);
                }
                if (data && data.length == 1) {
                    currentAssignedEmployeeCode(data[0].EmployeeCode);
                    assignToEmployeeCode(currentAssignedEmployeeCode());
                }
                console.log("viewModel.assignedToListData", viewModel.assignedToListData());
                loadPanelVisible(false);
            })
            .fail(function (data) {
                loadPanelVisible(false);
                handleDataServiceError(data);
            });
    }

    function onTemplatesChange(e) {
        statesLoaded = false;
        statesDataSource.load();
    }
    function onStatesChange(e) {
        getDefaultEmployee = true;
        reloadEmployees();
    }
    function onEmployeessChange(e) {
    }
    function onShowAllEmployeesCheckChange() {
        reloadEmployees();
    }
    function reloadEmployees() {
        assignToLoaded = false;
        employeesDataSource.load();
    }
    function handleSave() {
        var comment = "";
        if (commentsTextArea.value() !== undefined) {
            comment = commentsTextArea.value();
        }
        var inputData = {
            AlertID: alertId(),
            AlertTemplateID: templatesSelectBox.value(),
            AlertStateID: statesSelectBox.value(),
            EmployeeCode: employeesSelectBox.value(),
            UserCode: AdvantageMobile_UI.CurrentUser.UserCode(),
            Comments: comment,
            IsUnassigned: false,
            IsNewAssignment: false
        };
        var commentInputData = {
            AlertID: alertId(),
            Comment: comment
        };
        if (viewModel.isMultiAssignee === true) {
            AdvantageMobile_UI.db.get('SaveAlertComment', commentInputData)
                .done(function (data) {
                    if (data && data === true) {
                        commentsTextArea.value("");
                        AdvantageMobile_UI.Messages.toastSuccess();
                        AdvantageMobile_UI.app.navigate(viewInfo.previousViewInfo.uri, { target: "back" });
                    }
                })
                .fail(function (data) {
                    handleDataServiceError(data);
                });
        } else {
            AdvantageMobile_UI.db.get('SaveAlertAssignment', inputData)
            .done(function (data) {
                if (data && data === true) {
                    AdvantageMobile_UI.Messages.toastSuccess();
                    AdvantageMobile_UI.app.navigate(viewInfo.previousViewInfo.uri, { target: "back" });
                }
            })
            .fail(function (data) {
                handleDataServiceError(data);
            });
        }

    }

    function viewShowing(e) {
        if (params.settings) {
            if (params.settings.alertId) {
                viewModel.alertId(params.settings.alertId);
            }
            if (params.settings.templateId) {
                viewModel.templateId(params.settings.templateId);
            }
            if (params.settings.stateId) {
                viewModel.stateId(params.settings.stateId);
            }
            if (params.settings.source) {
                alertSource = params.settings.source;
            }
            templatesSelectBox.disabled(true);
            statesLoaded = false;
            statesDataSource.load();
            reloadEmployees();
            //getAssignedEmployee();
            getAlertAssignees();

        }
    }
    function viewShown(e) {
    }
    function viewDisposing() {
    }

    var viewModel = {
        viewShown: viewShown,
        viewShowing: viewShowing,
        viewDisposing: viewDisposing,
        loadPanelVisible: loadPanelVisible,
        alertId: alertId,
        templateId: templateId,
        stateId: stateId,
        currentAssignedEmployeeCode: currentAssignedEmployeeCode,
        defaultEmployeeCode: defaultEmployeeCode,
        handleSave: handleSave,

        templatesDataSource: templatesDataSource,
        templatesSelectBox: templatesSelectBox,
        onTemplatesChange: onTemplatesChange,

        statesDataSource: statesDataSource,
        statesSelectBox: statesSelectBox,
        onStatesChange: onStatesChange,

        employeesDataSource: employeesDataSource,
        employeesSelectBox: employeesSelectBox,
        onEmployeessChange: onEmployeessChange,

        showAllEmployeesCheckBox: showAllEmployeesCheckBox,
        onShowAllEmployeesCheckChange: onShowAllEmployeesCheckChange,
        reloadEmployees: reloadEmployees,

        templateName: templateName,
        stateName: stateName,
        assignedToList: assignedToList,
        assignedToListData: assignedToListData,
        comment: comment,
        hideShowSingle: hideShowSingle,
        hideShowMulti: hideShowMulti,

        isMultiAssignee: isMultiAssignee,

       commentsTextArea: commentsTextArea

    };

    return viewModel;

};