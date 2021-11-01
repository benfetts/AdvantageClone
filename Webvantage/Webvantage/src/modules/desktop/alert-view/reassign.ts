import { bindable, inject, child, observable } from 'aurelia-framework';
import { ModuleBase } from 'modules/base/module-base';
import { AlertService } from 'services/desktop/alert-service';
import { AlertModel } from 'models/desktop/alert-model';
import { AlertRecipientModel } from 'models/desktop/alert-recipient-model';
import { DropDownList } from '../../../resources/elements/dropdownlist/dropdownlist';
import { DialogService } from 'aurelia-dialog';
import { EventAggregator } from 'aurelia-event-aggregator';
import { HttpClient } from 'aurelia-http-client';

@inject(AlertService, DialogService, EventAggregator)
export class Reassign extends ModuleBase {

    @bindable model: AlertModel;
    @observable Alert: AlertModel;
    dialogService: DialogService;
    service: AlertService;
    showingAllEmployees: boolean = false;

    AlertRecipients: Array<AlertRecipientModel>;
    assignees: Array<string>;
    assigneesAsItems: Array<any>;
    recipients: Array<string>;
    tempCompleteRcpts: Array<string>;

    isRouted: boolean = false;
    canUpdate: boolean = false;
    canAdd: boolean = false;
    canPrint: boolean = false;
    isTaskAlert: boolean = false;
    isJobComponentLevel: boolean = false;
    stateChanged: boolean = false;
    stateChangedFromLoadedState: boolean = false;
    assigneesChanged: boolean = false;
    loadedStateID: number;

    assignToNotRoutedAndTasks: kendo.ui.MultiSelect;
    assignToMultiSelectRouted: kendo.ui.MultiSelect;
    alertTemplateStatesListBox: kendo.ui.ListBox;
    sendAssignmentComment: kendo.ui.Editor;

    employeeDataSource: kendo.data.DataSource;
    alertRecipientDataSource: kendo.data.DataSource;
    alertTemplateStatesDataSource: kendo.data.DataSource;
    alertTemplateStateEmployeesDataSource: kendo.data.DataSource;
    alertTemplateStateEmployeesDataSourceMultiSelectRouted: kendo.data.DataSource;
    dbTempCompleteRcpts: Array<string>;
    dbAlertAssignees: Array<string>;
    dbAssignees: Array<string>;
    dbAssigneesAsItems: Array<any>;
    dbAlertStateID: number;
    dbAlertStateName: string;
    dbItemsNotInList: Array<any>;

    sendAssignmentClicked() {
        this.sendAssignment()
    }
    sendAssignment() {
        let me = this;
        try {
            if (this.sendAssignmentComment) {
                this.Alert.SendAssignmentComment = this.sendAssignmentComment.value();
            }
        } catch (e) { }
        this.service.reassign(this.Alert).then(response => {
            me.showProgress(false);
            me.assigneesChanged = false;
            me.stateChanged = false;
            me.stateChangedFromLoadedState = false;
            me.showProgress(false);
            wvbridge.CloseWindow();
        });
    }
    assigneeSelected(e) {
        //if (this.Alert.IsWorkItem == true) {
        //    if (this.Alert.AlertLevel == "BRD") { //task
        //        this.service.addAssignee(this.Alert, e.dataItem.Code).then(response => {
        //        });
        //    }
        //} else { //assignment
        //}
    }
    assigneeDeselected(e) {
        //if (this.Alert.IsWorkItem == true) {
        //    if (this.isRouted == false || (this.isRouted == true && this.stateChangedFromLoadedState == false)) {
        //        var removed: boolean;
        //        this.service.deleteAssignee(this.Alert, e.dataItem.Code).then(response => {
        //            removed = true;
        //        });
        //        if (removed == true) {
        //            var idx = this.tempCompleteRcpts.indexOf(e.dataItem.Code);
        //            if (idx > -1) {
        //                this.tempCompleteRcpts.splice(idx, 1);
        //            }
        //            this.getAlertHours();
        //        }
        //    } 
        //}
    }
    assigneeChange(e) {
        this.assigneesChanged = true;
        //this.checkForTempCompleteAssignee(e.sender);
        //this.refreshHours();
    }
    refreshHours() {
        //this.getAlertHours();
    }
    getAlertHours() {
        //let me = this;
        //this.showProgress(true);
        //return this.service.getAlertHours(me.Alert.ID).then(response => {
        //    this.showProgress(false);
        //    if (response.content) {
        //        window.setTimeout(function () {
        //            //console.log("getAlertHours", response.content)
        //            me.Alert.HoursAllowed = response.content.HoursAllowed;
        //            me.Alert.HoursPosted = response.content.HoursPosted;
        //            me.Alert.HoursAllocated = response.content.HoursAllocated;
        //            me.Alert.HoursBalance = response.content.HoursBalance;
        //            me.Alert.HoursAllocatedBalance = response.content.HoursAllocatedBalance;
        //            me.hasCalculatedHours = response.content.HasCalculatedHours;
        //            me.hasWeeklyHours = response.content.HasWeeklyHours;
        //        }, 0);
        //    }
        //}).then(() => {
        //    this.showProgress(false);
        //});
    }
    checkForTempCompleteAssignee(multiselect: kendo.ui.MultiSelect) {
        //try {
            if (multiselect.dataItems()) {
                for (var i = 0; i < multiselect.dataItems().length; i++) {
                    var item = multiselect.dataItems()[i];
                    if (this.tempCompleteRcpts.indexOf(item.Code) > -1) {
                        item.IsTempComplete = true;
                    }
                }
            }
            window.setTimeout(function () {
                for (var i = 0; i < multiselect.tagList.find('.wv-assignee-complete').length; i++) {
                    var li = $(multiselect.tagList.find('.wv-assignee-complete')[i]).closest('li');
                    if (li) {
                        li.addClass('wv-assignee-complete');
                        $(li).find(".k-i-close").hide();
                    }
                }
            }, 0);
        //} catch (e) {
            //
        //}
    }
    checkForMultiRoutedCompleteAssignee(multiselect: kendo.ui.MultiSelect) {
        try {
            if (multiselect && multiselect.dataItems()) {
                for (var i = 0; i < multiselect.dataItems().length; i++) {
                    var item = multiselect.dataItems()[i];
                    if (this.tempCompleteRcpts.indexOf(item.Code) > -1) {
                        item.IsTempComplete = true;
                    }
                }
                window.setTimeout(function () {
                    for (var i = 0; i < multiselect.tagList.find('.wv-assignee-complete').length; i++) {
                        var li = $(multiselect.tagList.find('.wv-assignee-complete')[i]).closest('li');
                        if (li) {
                            li.addClass('wv-assignee-complete');
                            $(li).find(".k-i-close").hide();
                        }
                    }
                }, 0);
            }
        } catch (e) {
        }
    }
    getAlert(alertID: number, refreshAlerts: boolean = false) {
        let me = this;
        if (!alertID || alertID == undefined || alertID == null || alertID == 0) {
            alert("No alert ID!");
            this.close();
        }
        this.showProgress(true);
        this.service.getAlertView(alertID, 0).then(response => {
            this.showProgress(false);
            if (refreshAlerts == true) {
                wvbridge.refreshDashboardAlerts();
            }
            var alertModel = new AlertModel;
            Object.assign(alertModel, response.content.Alert);
            Object.assign(this, response.content);
            this.Alert = alertModel;
            //console.log("3", this.Alert.IsCompleted);
            try {
                this.Alert.CompletedDate = this.kendoParseDate(this.Alert.CompletedDateString);
            } catch (e) {
            }
            try {
                this.Alert.DueDate = this.kendoParseDate(this.Alert.DueDateString);
            } catch (e) {
            }
            try {
                this.Alert.StartDate = this.kendoParseDate(this.Alert.StartDateString);
            } catch (e) {
            }
            this.isRouted = this.Alert.AlertAssignmentTemplateID > 0 ? true : false;
            try {
                this.canUpdate = response.content.CanUpdate;
            } catch (e) {
            }
            try {
                this.canAdd = response.content.CanAdd;
            } catch (e) {
            }
            try {
                this.canPrint = response.content.CanPrint;
            } catch (e) {
            }
            if (this.alertTemplateStatesListBox) {
                this.alertTemplateStatesListBox.enable('.k-item', !this.Alert.IsCompleted);
            }
            if (this.Alert.AlertLevel == 'BRD') {
                this.isTaskAlert = true;
            }
            if ((this.Alert.JobNumber && this.Alert.JobNumber > 0) &&
                (this.Alert.JobComponentNumber && this.Alert.JobComponentNumber > 0)) {
                this.isJobComponentLevel = true;
            } else {
                this.isJobComponentLevel = false;
            }
            //console.log("getAlert", this.isJobComponentLevel);
            if (this.Alert.AssignedEmployeeCode && this.Alert.AssignedEmployeeCode.toLowerCase() == 'unassigned') {
                this.Alert.AssignedEmployeeCode = this.Alert.AssignedEmployeeCode.toUpperCase();
            }
            //console.log("wtf", this.Alert.Build)
            //console.log("canUpdate", this.canUpdate)
            //console.log("DueDateLocked", this.Alert.DueDateLocked)
            if (this.Alert.AlertStateID) {
                this.loadedStateID = this.Alert.AlertStateID;
            }
            //console.log("state?", this.Alert.AlertStateID)
            this.stateChangedFromLoadedState = false;
            this.showProgress(false);
        }).then(() => {
            this.getAlertRecipients(false, false);
        });
    }

    getAlertRecipients(showMessage: boolean = false, updateTokens: boolean = false) {
        //console.log("getAlertRecipients", this.Alert.ID)
        let me = this;
        this.showProgress(true);
        return this.service.getAlertRecipients(this.Alert.ID).then(response => {
            this.showProgress(false);
            if (response.content) {
                this.AlertRecipients = new Array<AlertRecipientModel>();
                Object.assign(this.AlertRecipients, response.content)
            }
            //console.log("getAlertRecipients", this.AlertRecipients)
        }).then(() => {
            this.showProgress(false);
            this.setUpAlertRecipients(showMessage, updateTokens);
        });
    }
    setUpAlertRecipients(showMessage: boolean = false, updateTokens: boolean = false) {
        //console.log("setUpAlertRecipients");
        let me = this;
        this.assignees = new Array<string>();
        this.recipients = new Array<string>();
        this.Alert.Assignees = new Array<string>();
        this.tempCompleteRcpts = new Array<string>();
        this.assigneesAsItems = new Array<any>();
        if (this.AlertRecipients && this.AlertRecipients.length > 0) {
            for (var i = 0; i < this.AlertRecipients.length; i++) {
                var rcpt = new AlertRecipientModel;
                Object.assign(rcpt, this.AlertRecipients[i]);
                if (rcpt.IsCurrentNotify === true && rcpt.IsCurrentRecipient == false) {
                    //console.log("assignee" + i, rcpt);
                    if (this.isRouted == true) {
                        if (rcpt.CompletedDismissed == false && rcpt.IsCurrentAssignee == true) {
                            this.assignees.push(rcpt.Code);
                            this.Alert.Assignees.push(rcpt.Code);
                            this.assigneesAsItems.push(rcpt);
                        }
                        if (rcpt.CompletedDismissed == true && rcpt.CurrentStateCompleted == true) {
                            this.assignees.push(rcpt.Code);
                            this.Alert.Assignees.push(rcpt.Code);
                            this.assigneesAsItems.push(rcpt);
                            this.tempCompleteRcpts.push(rcpt.Code);
                        }
                    } else {
                        this.assignees.push(rcpt.Code);
                        this.Alert.Assignees.push(rcpt.Code);
                        this.assigneesAsItems.push(rcpt);
                        if (rcpt.CompletedDismissed == true) {
                            this.tempCompleteRcpts.push(rcpt.Code);
                        }
                    }
                } else if (rcpt.IsCurrentRecipient === true && rcpt.IsCurrentNotify === false) {
                    if (rcpt.Code != null) {
                        this.recipients.push(rcpt.Code);
                    } else {
                        if (isNaN(rcpt.ClientContactID) == false) {
                            this.recipients.push("CC|" + rcpt.ClientContactID);
                        }
                    }
                }
                if (rcpt.IsTaskTempComplete) {
                    this.tempCompleteRcpts.push(rcpt.Code);
                }
            }
            this.dbTempCompleteRcpts = this.tempCompleteRcpts;
            this.dbAlertAssignees = this.Alert.Assignees;
            this.dbAssigneesAsItems = this.assigneesAsItems;
            this.dbAssignees = this.assignees;
            this.dbAlertStateID = this.Alert.AlertStateID;
            this.dbAlertStateName = this.Alert.AlertStateName
        } else {
            //this.assignees.push('unassigned');
        }
        //console.log("tempCompleteRcpts", this.tempCompleteRcpts)
        //console.log("setUpAlertRecipients", this.Alert.Assignees);
        updateTokens = true;
        if (updateTokens && updateTokens == true) {
            //if (this.Alert && this.Alert.IsRouted == true) {
            if (this.Alert.IsWorkItem == true) {
                //if (me.Alert.AlertLevel == "BRD" || me.isRouted == false) {
                //    me.employeeDataSource.read();
                //    me.checkForTempCompleteAssignee(me.assignToNotRoutedAndTasks);
                //} else {
                //    me.checkForMultiRoutedCompleteAssignee(me.assignToMultiSelectRouted);
                //}
            }
            //}
        }
        if (showMessage && showMessage == true) {
            //console.log("ASSIGNESS AFTER CHANGE AND REFRESH!", me.Alert.Assignees, me.Alert.AssignedEmployeeName);
            if (me.Alert.AssignedEmployeeName && me.Alert.AssignedEmployeeName != null && me.Alert.AssignedEmployeeName != undefined) {
                if (me.Alert.AssignedEmployeeCode.toUpperCase() === 'UNASSIGNED') {
                    me.showSuccessNotification("Assignment unassigned");
                } else {
                    me.showSuccessNotification("Assignment sent to " + me.Alert.AssignedEmployeeName);
                }
            } else {
                if (me.Alert.Assignees) {
                    //console.log("me.Alert.Assignees.length:", me.Alert.Assignees.length);
                    if (me.Alert.Assignees.length == 1) {
                        me.showSuccessNotification("Assignment sent");
                    } else if (me.Alert.Assignees.length > 1) {
                        me.showSuccessNotification("Assignment sent to multiple employees");
                    }
                }
            }
        }
    }


    assignToMultiSelectDataBound(e) {
        this.checkForMultiRoutedCompleteAssignee(e.sender)
        //var items = this.assignToMultiSelectRouted.value();
        ////console.log("assignToMultiSelectDataBound", items);
        //if (items && items.length > 0) {
        //    for (var i = 0; i < items.length; i++) {
        //        var item;
        //        item = $(".k-multiselect-wrap ul li:eq(" + i + ")")
        //        //console.log("VALUE???", item);
        //        if (items[i] == "ama" && item) {
        //            //console.log(item)
        //            //console.log("found value!!!", $(item).find(".k-i-close"))
        //            item = $(item).find(".k-i-close")[0]
        //            if (item) {
        //                //$(item).prop("style", "display: none !important");
        //                $(item).removeClass("k-icon");
        //                $(item).removeClass("k-i-close");
        //            //console.log("delete?", item);
        //            }
        //            //$(item).hide();
        //            //$(item).css("background-color", "red !important")
        //        }
        //    }
        //}
    }
    assignToMultiSelectChanged(e) {
        this.assigneesChanged = true;
        var items = this.assignToMultiSelectRouted.value();
    }
    showAllEmployeesChanged() {
        if (this.Alert.AlertAssignmentTemplateID && this.Alert.AlertAssignmentTemplateID > 0 && this.Alert.AlertStateID && this.Alert.AlertStateID > 0) {
            this.alertTemplateStateEmployeesDataSourceMultiSelectRouted.read();
        } else {
            this.alertTemplateStateEmployeesDataSource.read();
        }
    }
    alertTemplateStatesDataBound(e) {
        window.setTimeout(() => {
            let listBox: kendo.ui.ListBox = e.sender;
            this.alertTemplateStatesListBox = listBox;
            //console.log("alertTemplateStatesDataBound", this.Alert)
            if (this.Alert) {
                listBox.select(null);
                for (var i = 0; i < listBox.items().length; i++) {
                    var item = listBox.items()[i];
                    var dataItem = <any>listBox.dataItem(item);
                    //console.log("AlertStateID, dataItemID", this.Alert.AlertStateID, dataItem.ID)
                    if (dataItem.ID === this.Alert.AlertStateID) {
                        listBox.select(item);
                        //console.log("selected:", item)
                    }
                }
                if (this.Alert.IsCompleted === true) {
                    this.alertTemplateStatesListBox.enable('.k-item', false);
                }
            }
        }, 10);
    }
    alertTemplateStatesChange(e) {
        let listBox: kendo.ui.ListBox = e.sender;
        if (this.Alert) {
            var item = listBox.select();
            var dataItem = <any>listBox.dataItem(item);
            if (dataItem) {
                if (this.Alert.AlertStateID !== dataItem.ID) {
                    this.stateChanged = true;
                    this.assigneesChanged = true;
                    this.Alert.AlertStateID = dataItem.ID;
                    if (this.Alert.AlertStateID != this.loadedStateID) {
                        this.stateChangedFromLoadedState = true;
                    } else {
                        this.stateChangedFromLoadedState = false;
                    }
                    this.alertTemplateStateEmployeesDataSourceMultiSelectRouted.read();
                }
            }
        }
    }
    close() {
        var AMI = $(this).data("myAMI");
        try {
            wvbridge.CloseAlertView(this.Alert.ID);
        } catch (e) {
        }
    }

    assigneeDataBound(e) {
        this.checkForTempCompleteAssignee(e.sender);
    }


    activate(params: any) {
        if (params && params.AlertID) {
            //console.log("reassign activate", params.AlertID)
            this.getAlert(params.AlertID, false);
        }
    }
    attached() {
        //console.log("reassign attached")
    }
    constructor(service: AlertService, dialogService: DialogService, private ea: EventAggregator) {

        super();

        let alertView = this;
        let me = this;

        this.dialogService = dialogService;
        this.Alert = new AlertModel;
        this.service = service;

        this.employeeDataSource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: 'Desktop/Alert/GetEmployees'
                }
            }
        });
        this.alertTemplateStatesDataSource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: 'Desktop/Alert/GetAlertTemplateStates',
                    data: function () {
                        return {
                            AlertTemplateID: alertView.Alert.AlertAssignmentTemplateID && alertView.Alert.AlertAssignmentTemplateID > 0 ? alertView.Alert.AlertAssignmentTemplateID : 0
                        }
                    }
                }
            },
            requestStart: function (e) {
                if (e.type === "read") {
                    if (!alertView.Alert.AlertAssignmentTemplateID || alertView.Alert.AlertAssignmentTemplateID == 0) {
                        e.preventDefault();
                    }
                }
            }
        });
        this.alertTemplateStateEmployeesDataSource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: 'Desktop/Alert/GetAlertTemplateStateEmployees',
                    data: function () {
                        return {
                            IncludeEmployeeCode: alertView.Alert.AssignedEmployeeCode,
                            AlertTemplateID: alertView.Alert.AlertAssignmentTemplateID,
                            AlertStateID: alertView.Alert.AlertStateID,
                            ShowAll: alertView.showingAllEmployees
                        }
                    }
                }
            },
            requestStart: function (e) {
                if (e.type === "read") {
                    if (!alertView.Alert.AlertAssignmentTemplateID || !alertView.Alert.AlertStateID) {
                        e.preventDefault();
                    }
                }
            },
            requestEnd: function (e) {
                var type = e.type;
                var items = [];
                items = e.response;
                if (items) {
                    //console.log("alertTemplateStateEmployeesDataSource:items", items);
                    //console.log("alertTemplateStateEmployeesDataSource:assigneesAsItems", me.assigneesAsItems);
                    //console.log("alertTemplateStateEmployeesDataSource:assignees", me.assignees);
                }
            }
        });
        this.alertTemplateStateEmployeesDataSourceMultiSelectRouted = service.getAlertTemplateStateEmployeesDataSource({
            transport: {
                read: {
                    data: function () {
                        //var showAll: boolean = false;
                        //if (me.stateChanged == true) {
                        //    showAll = me.showingAllEmployees ? me.showingAllEmployees : false
                        //} else {
                        //    showAll = true;
                        //}
                        //console.log("showAll??", showAll, me.showingAllEmployees)
                        return {
                            AlertID: ((me.Alert.ID && me.Alert.ID > 0) ? me.Alert.ID : 0),
                            AlertTemplateID: ((me.Alert.AlertAssignmentTemplateID && me.Alert.AlertAssignmentTemplateID > 0) ? me.Alert.AlertAssignmentTemplateID : 0),
                            AlertStateID: ((me.Alert.AlertStateID && me.Alert.AlertStateID > 0) ? me.Alert.AlertStateID : 0),
                            ShowAll: me.showingAllEmployees
                        }
                    }
                }
            },
            requestStart: function (e) {
                if (e.type === "read") {
                    if (!me.Alert.AlertAssignmentTemplateID || me.Alert.AlertAssignmentTemplateID == 0 || !me.Alert.AlertStateID || me.Alert.AlertStateID == 0 || me.isRouted == false) {
                        e.sender.data([]);
                        e.preventDefault();
                    }
                }
                //console.log("rStart", me.Alert.Assignees);
            },
            requestEnd: function (e) {
                var type = e.type;
                var items = [];
                items = e.response;
                if (me.stateChanged == true) {
                    //  On change, this replaces the Alert.Assignees with the selected state's default(s)
                    me.stateChanged = false;
                    if (items) {
                        try {
                            me.Alert.Assignees = new Array<string>();
                            me.dbItemsNotInList = new Array<any>();
                            if (me.Alert.AlertStateID == me.dbAlertStateID) {
                                for (var i = 0; i < me.dbAssigneesAsItems.length; i++) {
                                    let item: any = null;
                                    item = items.find(function (itm) { return itm.Code == me.dbAssigneesAsItems[i].EmployeeCode })
                                    if (item) {
                                        //console.log("found!", me.dbAssigneesAsItems[i])
                                    } else {
                                        var dsItem = { Code: me.dbAssigneesAsItems[i].EmployeeCode, Name: me.dbAssigneesAsItems[i].Name, IsDefault: false, IsSelected: true, IsCompleted: false }
                                        me.dbItemsNotInList.push(dsItem);
                                    }
                                }
                                me.Alert.Assignees = me.dbAlertAssignees;
                            } else {
                                for (var i = 0; i < items.length; i++) {
                                    if (items[i].IsDefault == true) {
                                        me.Alert.Assignees.push(items[i].Code);
                                    }
                                }
                            }
                        } catch (e) {
                        }
                    }
                } else {
                    if (items && me.showingAllEmployees == false) {
                        window.setTimeout(function () {
                            me.dbItemsNotInList = new Array<any>();
                            for (var i = 0; i < me.dbAssigneesAsItems.length; i++) {
                                let item: any = null;
                                item = items.find(function (itm) { return itm.Code == me.dbAssigneesAsItems[i].EmployeeCode })
                                if (item) {
                                    //console.log("found!", me.dbAssigneesAsItems[i])
                                } else {
                                    var dsItem = { Code: me.dbAssigneesAsItems[i].EmployeeCode, Name: me.dbAssigneesAsItems[i].Name, IsDefault: false, IsSelected: true, IsCompleted: false }
                                    if (dsItem) {
                                        me.dbItemsNotInList.push(dsItem);
                                    }
                                }
                            }
                            window.setTimeout(function () {
                                if (me.dbItemsNotInList && me.dbItemsNotInList.length > 0) {
                                    let itemAdded: boolean = false;
                                    for (var i = 0; i < me.dbItemsNotInList.length; i++) {
                                        me.alertTemplateStateEmployeesDataSourceMultiSelectRouted.add(me.dbItemsNotInList[i]);
                                        itemAdded = true;
                                        if (me.Alert.Assignees) {
                                            if (me.Alert.Assignees.indexOf(me.dbItemsNotInList[i]) == -1) {
                                                me.Alert.Assignees.push(me.dbItemsNotInList[i].Code);
                                            }
                                        }
                                    }
                                    if (itemAdded == true) {
                                        me.assignToMultiSelectRouted.value(me.Alert.Assignees);
                                    }
                                }
                            }, 0);
                        }, 0);
                    }
                }
            }
        });



    }
}
