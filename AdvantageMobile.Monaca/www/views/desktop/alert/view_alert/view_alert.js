AdvantageMobile_UI.view_alert = function (params, viewInfo) {

    "use strict";

    var alertId = ko.observable(0);
    var thisAlert = new AdvantageMobile_UI.AlertViewModel();
    var loaded = false;
    var commentHasHTML = false;
    var isViewingAssignment = false;
    var editor = null;

    var alertPriorities = [
            { id: 1, name: "Highest" },
            { id: 2, name: "High" },
            { id: 3, name: '--' },
            { id: 4, name: "Low" },
            { id: 5, name: "Lowest" },
    ];
    var prioritySelectBox = {
        dataSource: alertPriorities,
        displayExpr: 'name',
        valueExpr: 'id',
        value: ko.observable(),
        onItemClick: onPrioritySelectBoxChange
    };
    var isAssignment = ko.observable(false);
    var idDisplay = ko.observable(0);
    var alertDetailsTab = {
        onItemClick: function (e) {
            alertDetailsTab.selectedIndex(-1);
            AdvantageMobile_UI.app.navigate({
                view: e.itemData.view,
                settings: { alertId: viewModel.alertId(), isAssignment: viewModel.isAssignment(), templateId: viewModel.templateId(), stateId: viewModel.stateId() }
            });
        },
        items: ko.observable(),
        selectedIndex: ko.observable(-1)
    };
    var alertTabItems = [];
    var loadingPanel = {
        message: "Loading",
        visible: ko.observable(false),
        shading: false
    }
    var templateId = ko.observable();
    var stateId = ko.observable();

    var dismissCompleteButton = {
        text: ko.observable("dismissCompleteButton"),
        onClick: function (e) {
            dismissCompleteAlert(viewModel.alertId(), viewModel.isAssignment());

            //var iSource = 0;
            //if (viewModel.isViewingAssignment == false) {
            //    iSource = 1;
            //};
            //AdvantageMobile_UI.app.navigate({
            //    view: "alert_list",
            //    settings: { source: iSource }
            //}, { target: "current" });
            AdvantageMobile_UI.app.navigate(viewInfo.previousViewInfo.uri, { target: "back" });

        }
    };

    /******************** TEMP ****************************/
    /*
        For some reason this function which is on data.js doesn't work on first time using app!!!!
    */
    function dismissCompleteAlert(alertId, forceAssignmentComplete) {
        loadingPanel.visible(true); // since fn is here, might as well show loading panel since when it's on data.js it is async
        var d = new $.Deferred();
        AdvantageMobile_UI.db.get('DismissCompleteAlert', {
            AlertID: alertId,
            EmployeeCode: AdvantageMobile_UI.CurrentUser.EmployeeCode(),
            ForceAssignmentComplete: forceAssignmentComplete,
        }).done(function (data) {
            d.resolve(data);
            //AdvantageMobile_UI.Messages.toastSuccess();
            loadingPanel.visible(false); // since fn is here, might as well show loading panel since when it's on data.js it is async
        }).fail(function (data) {
            loadingPanel.visible(false); // since fn is here, might as well show loading panel since when it's on data.js it is async
            handleDataServiceError(data);
        })
        return d.promise();
    };
    /******************** TEMP ****************************/

    var hasJobAndComponent = false;
    var jobNumber = ko.observable(0);
    var jobComponentNumber = ko.observable(0);
    var jobAndComponentCSS = ko.observable("hide");
    var jobAndComponentText = ko.observable("");
    var clientDisplayCSS = ko.observable("hide");
    var clientDisplay = ko.observable("");
    var htmlDesc = "";

    function load() {
        if (loaded == false) {
            loadingPanel.visible(true);
            alertDetailsTab.items(null);
            AdvantageMobile_UI.db.Alerts.byKey(viewModel.alertId())
                .done(function (data) {
                    thisAlert.fromJS(data);
                    prioritySelectBox.value(thisAlert.Priority());
                    if ((thisAlert.AlertAssignmentTemplateID() && thisAlert.AlertAssignmentTemplateID() > 0) && (thisAlert.AlertAssignmentStateID() && thisAlert.AlertAssignmentStateID() > 0)) {
                        isAssignment(true);
                        templateId(thisAlert.AlertAssignmentTemplateID());
                        stateId(thisAlert.AlertAssignmentStateID());
                    };
                    if ((thisAlert.SequenceNumber() && thisAlert.SequenceNumber() > 0)) {
                        idDisplay(thisAlert.SequenceNumber());
                    } else {
                        idDisplay(thisAlert.ID());
                    };
                    if ((thisAlert.JobNumber() != undefined && thisAlert.JobNumber() > 0) && (thisAlert.JobComponentNumber() != undefined && thisAlert.JobComponentNumber() > 0)) {
                        hasJobAndComponent = true;
                        jobNumber(thisAlert.JobNumber());
                        jobComponentNumber(thisAlert.JobComponentNumber());
                        getComponentDescription(thisAlert.JobNumber(), thisAlert.JobComponentNumber());
                    };
                    if (thisAlert.ClientCode() != undefined) {
                        getClientDisplay(thisAlert.ClientCode(), thisAlert.DivisionCode(), thisAlert.ProductCode());
                    };
                    loaded = true;
                    var hasAssignmentTab = false;
                    if (isAssignment() == true) {
                        alertTabItems.push({ text: "Assignment", value: "assignment", view: "view_alert_assignment" });
                        hasAssignmentTab = true;
                    };
                    if (isViewingAssignment == true) {
                        if (hasAssignmentTab == false) {
                            alertTabItems.push({ text: "Assignment", value: "assignment", view: "view_alert_assignment" });
                        };
                        dismissCompleteButton.text("Complete Assignment");
                    } else {
                        dismissCompleteButton.text("Dismiss Alert");
                    };
                    alertTabItems.push({ text: "Recipients", value: "recipients", view: "view_alert_recipients" },
                        { text: "Comments", value: "comments", view: "view_alert_comments" });//,
                        //{ text: "Attachments", value: "attachments", view: "view_alert_attachments" });
                    alertDetailsTab.items(alertTabItems);
                    alertDetailsTab.selectedIndex(null);

                    //if (thisAlert.Body != undefined) {
                    //    var s = "";
                    //    s = thisAlert.Body;
                    //    var match = /sample/.test("Sample text")
                    //};
                    htmlDesc = thisAlert.BodyHtml();
                    loadingPanel.visible(false);
                })
                .fail(function (data) {
                    loadingPanel.visible(false);
                    handleDataServiceError(data);
                });
        };
    };

    function getComponentDescription(j, jc) {
        AdvantageMobile_UI.db.get('GetJobComponent', {
            JobNumber: j,
            JobComponentNumber: jc
        })
            .done(function (data) {
                jobAndComponentCSS("");
                jobAndComponentText(jobDisplay(j, jc, data.Description));
            })
            .fail(function (data) {
                handleDataServiceError(data);
            });
    };
    function getClientDisplay(clientCode, divisionCode, productCode) {
        var client = new AdvantageMobile_UI.ClientViewModel();
        AdvantageMobile_UI.db.Clients.byKey(clientCode).done(function (data) {
            client.fromJS(data);
            clientDisplay("");
            var clientName = "";
            clientName = client.Name();
            clientDisplayCSS("");
            clientDisplay(client.Name() + " - [" + clientCode);
            if (divisionCode != undefined) {
                clientDisplay(clientDisplay() + " | " + divisionCode);
                if (productCode != undefined) {
                    clientDisplay(clientDisplay() + " | " + productCode);
                };
            };
            clientDisplay(clientDisplay() + "]");
        });
    };
    function onPrioritySelectBoxChange(e) {
        if (loaded == true) {
            thisAlert.Priority(prioritySelectBox.value());
        };
    };
    function update() {
        var editor = $("#editor").data("kendoEditor");
        thisAlert.BodyHtml(editor.value());
        thisAlert.Body(editor.value());
        AdvantageMobile_UI.db.Alerts.update(viewModel.alertId(), thisAlert.toJS())
            .done(function () {
                AdvantageMobile_UI.Messages.toastSuccess();
                AdvantageMobile_UI.app.navigate(viewInfo.previousViewInfo.uri, { target: "back" });
            })
            .fail(function (data) {
                handleDataServiceError(data);
            });
    };
    function handleSave() {
        if (loaded == true) {
            update();
        };
    };
    function viewShowing(e) {
        if (params && params.settings) {
            viewModel.alertId(params.settings.alertId);
            isViewingAssignment = params.settings.isAssignment;
        };
        load();
    };
    function viewShown(e) {
        editor = $("#editor").data("kendoEditor");
        if (!editor) {
            $("#editor").kendoEditor({
                value: htmlDesc,
                resizable: {
                    content: true,
                    toolbar: true
                }
            });
        }
    };
    var descriptionPopup = {
        height: "auto",
        visible: ko.observable(false),
        showTitle: true,
        title: "Add Comments"
    };
    function descriptionClicked() {
        //AdvantageMobile_UI.app.navigate({
        //    view: "rich_editor",
        //    settings: { source: 0 }
        //}, { target: "current" });
        ////descriptionPopup.visible(true);
    };
    var saveDescriptionButton = {
        text: "Save",
        onClick: function (e) {
            if (commentsTextArea.value() == null || commentsTextArea.value() == "") {
                AdvantageMobile_UI.Messages.toastWarning(localizeString("Please Enter A Comment"));
                return;
            } else {
                var newComment = new AdvantageMobile_UI.AlertCommentViewModel();
                newComment.AlertID(alertId());
                newComment.UserCode(AdvantageMobile_UI.CurrentUser.UserCode());
                newComment.GeneratedDate(new Date());
                newComment.Comment(commentsTextArea.value());
                AdvantageMobile_UI.db.AlertComments.insert(newComment.toJS())
                    .done(function () {
                        commentsTextArea.value("");
                        showAddCommentPopUp();
                        commentsList.dataSource.load();
                        notifyAlertRecipients(alertId(), false, true);
                    })
                    .fail(function (data) {
                        handleDataServiceError(data);
                    });
            };
        }
    };
    var cancelSaveDescriptionButton = {
        text: "Cancel",
        onClick: function (e) {
            descriptionPopup.visible(false);
        }
    };
    function notifyAlertRecipients(alertId, isNew, includeOriginator) {
        var d = new $.Deferred();
        AdvantageMobile_UI.db.get('NotifiyAlertRecipients', {
            AlertID: alertId,
            IsNew: isNew,
            IncludeOriginator: includeOriginator,
        }).done(function (data) {
            d.resolve(data);
        }).fail(function (data) {
            handleDataServiceError(data);
        })
        return d.promise();
    };

    var viewModel = {
        loadingPanel: loadingPanel,
        alertId: alertId,
        isAssignment: isAssignment,
        thisAlert: thisAlert,
        viewShowing: viewShowing,
        viewShown: viewShown,
        handleSave: handleSave,
        alertPriorities: alertPriorities,
        prioritySelectBox: prioritySelectBox,
        idDisplay: idDisplay,
        alertDetailsTab: alertDetailsTab,
        templateId: templateId,
        stateId: stateId,
        dismissCompleteButton: dismissCompleteButton,
        jobAndComponentCSS: jobAndComponentCSS,
        jobAndComponentText: jobAndComponentText,
        jobNumber: jobNumber,
        jobComponentNumber: jobComponentNumber,
        descriptionClicked: descriptionClicked,
        descriptionPopup: descriptionPopup,
        saveDescriptionButton: saveDescriptionButton,
        cancelSaveDescriptionButton: cancelSaveDescriptionButton,
        clientDisplayCSS: clientDisplayCSS,
        clientDisplay: clientDisplay
    };

    return viewModel;

};