//import { inject, bindable, BindingEngine, Disposable } from 'aurelia-framework';
//import { AlertService } from 'services/desktop/alert-service';
//import { ModuleBase } from 'modules/base/module-base';
//import { AlertModel } from 'models/desktop/alert-model';
//import { DropDownList } from '../../../resources/elements/dropdownlist/dropdownlist';
//import { Webvantage } from '../../../webvantage';
//import { Dashboard } from 'modules/dashboard/dashboard';
////import { browserWindow } from 'services/utilities/browserWindow'

//@inject(AlertService, BindingEngine, Webvantage, Dashboard)
//export class AddWorkItem extends ModuleBase {

//    Alert: AlertModel;
//    bindingEngine: BindingEngine;
//    disposables: Array<Disposable>;
//    webvantage: Webvantage;
//    dashboard: Dashboard;

//    clientsDataSource: kendo.data.DataSource;
//    divisionsDataSource: kendo.data.DataSource;
//    productsDataSource: kendo.data.DataSource;
//    jobsDataSource: kendo.data.DataSource;
//    componentsDataSource: kendo.data.DataSource;
//    alertTemplatesDataSource: kendo.data.DataSource;
//    alertTemplateStatesDataSource: kendo.data.DataSource;
//    alertTemplateStateEmployeesDataSource: kendo.data.DataSource;
//    alertCategoriesDataSource: kendo.data.DataSource;
//    employeeDataSource: kendo.data.DataSource;
//    versionDataSource: kendo.data.DataSource;
//    buildDataSource: kendo.data.DataSource;
//    officeDataSource: kendo.data.DataSource;
//    alertRecipientDataSource: kendo.data.DataSource;

//    taskFunctionDataSource: kendo.data.DataSource;

//    boardDataSource: kendo.data.DataSource;
//    sprintDataSource: kendo.data.DataSource;
//    boardStateDataSource: kendo.data.DataSource;

//    clientDropDownList: kendo.ui.DropDownList;
//    divisionDropDownList: kendo.ui.DropDownList;
//    productDropDownList: kendo.ui.DropDownList;
//    jobDropDownList: kendo.ui.DropDownList;
//    jobComponentDropDownList: kendo.ui.DropDownList;
//    alertTemplateStatesListBox: kendo.ui.ListBox;
//    alertCategoriesDropDownList: kendo.ui.DropDownList;
//    assignToDropDownList: DropDownList;
//    attachmentUpload: kendo.ui.Upload;
//    descriptionEditor: kendo.ui.Editor;
//    alertAssignmentTemplateDropDownList: kendo.ui.DropDownList;
//    startDatePicker: kendo.ui.DatePicker;
//    dueDatePicker: kendo.ui.DatePicker;
//    buildDropDownList: kendo.ui.DropDownList;
//    officeDropDownList: kendo.ui.DropDownList;
//    taskFunctionDropDownList: kendo.ui.DropDownList;

//    boardDropDownList: kendo.ui.DropDownList;
//    sprintDropDownList: kendo.ui.DropDownList;
//    boardStateDropDownList: kendo.ui.DropDownList;

//    existingDocumentDialog: kendo.ui.Dialog;
//    existingDocumentDialogActions: Array<any>;
//    existingDocumentsDataSource: kendo.data.DataSource;
//    existingDocumentsGrid: kendo.ui.Grid;
//    existingDocumentButton: HTMLElement;

//    pickOffice: boolean = true;
//    pickClient: boolean = true;
//    pickDivision: boolean = true;
//    pickProduct: boolean = true;
//    pickJob: boolean = true;
//    pickComponent: boolean = true;
//    pickTask: boolean = true;
//    excludeTasks: boolean = false;
//    showVersion: boolean = false;
//    buildEnabled: boolean = false;
//    activated: boolean = false;
//    fromPreset: boolean = false;

//    softwareVersionLastSearched: any = { JobNumber: 0, JobComponentNumber: 0 };

//    @bindable isBoardTask: boolean = false;
//    @bindable taskFunctionEnabled: boolean = false;
//    allowEditSubject: boolean = true;
//    uploadToDocumentManager: boolean = false;
//    uploadToProofHQ: boolean = false;

//    message: string;
//    service: AlertService;

//    @bindable isRouted: boolean = false;
//    @bindable showAllEmployees: boolean = false;

//    officeName: string;
//    clientName: string;
//    divisionName: string;
//    productName: string;
//    jobDescription: string;
//    jobComponentDescription: string;
//    taskDescription: string;
//    repositoryLimitText: string;
//    defaultSubjectType: string = "";
//    selectedAlertAssignmentTemplateName: string = "";
//    allowUpload: boolean = false;
//    autoSelectJob: boolean = false;
//    startDateTitle: string = "";
//    dueDateTitle: string = "";
//    startDateCssName: string = "";
//    dueDateCssName: string = "";

//    @bindable enableContacts: boolean = false;


//    contentpage: string = "0";

//    callingPage: string = "";
//    @bindable includeAttachments: boolean = false;

//    priorityLevels: Array<any>;

//    linkableDocuments: Array<any>;

//    defaultWorkflowTemplate: any = {};

//    contactsClick() {
//        if (this.Alert.JobComponentNumber > 0) {
//            this.openRadWindow('Contacts', 'popContacts.aspx?from=newalert&c=' + this.Alert.ClientCode + '&d=' + this.Alert.DivisionCode + '&j=' + this.Alert.JobNumber + '&jc=' + this.Alert.JobComponentNumber + '&p=' + this.Alert.ProductCode + '', 1200, 400);
//        }
//    }

//    setAlertLevel() {
//        if (this.isBoardTask === true && this.isRouted === false) {
//            this.Alert.AlertLevel = "BRD";
//        } else {
//            try {
//                if (this.Alert.OfficeCode && this.Alert.OfficeCode !== "") {
//                    this.Alert.AlertLevel = "OF";
//                }
//                if (this.Alert.ClientCode && this.Alert.ClientCode !== "") {
//                    this.Alert.AlertLevel = "CL";
//                }
//                if (this.Alert.ClientCode && this.Alert.ClientCode !== "" && this.Alert.DivisionCode && this.Alert.DivisionCode !== "") {
//                    this.Alert.AlertLevel = "DI";
//                }
//                if (this.Alert.ClientCode && this.Alert.ClientCode !== "" && this.Alert.DivisionCode && this.Alert.DivisionCode !== "" && this.Alert.ProductCode && this.Alert.ProductCode !== "") {
//                    this.Alert.AlertLevel = "PRD";
//                }
//                if (this.Alert.JobNumber && this.Alert.JobNumber > 0) {
//                    this.Alert.AlertLevel = "J";
//                }
//                if (this.Alert.JobNumber && this.Alert.JobNumber > 0 && this.Alert.JobComponentNumber && this.Alert.JobComponentNumber > 0) {
//                    this.Alert.AlertLevel = "JC";
//                }
//                if (this.Alert.JobNumber && this.Alert.JobNumber > 0 && this.Alert.JobComponentNumber && this.Alert.JobComponentNumber > 0 && this.Alert.TaskSequenceNumber && this.Alert.TaskSequenceNumber > 0) {
//                    this.Alert.AlertLevel = "PST";
//                }
//            } catch (e) {
//                this.Alert.AlertLevel = "JC";
//            }
//        }
//        if (!this.Alert.AlertLevel || this.Alert.AlertLevel === "") {
//            this.Alert.AlertLevel = "JC";
//        }
//    }

//    saveClick(notify: boolean) {
//        if (this.dueDateIsBeforeStartDate(this.Alert.StartDate, this.Alert.DueDate) === true) {
//            this.alert("Due date before start date.")
//        } else {
//            if (this.isRouted == true) {
//                //console.log("assigned to", this.Alert.AlertAssignmentTemplateID, this.Alert.AlertStateID, this.Alert.AssignedEmployeeCode)
//                if (isNaN(this.Alert.AlertAssignmentTemplateID) == true || this.Alert.AlertAssignmentTemplateID == 0) {
//                    this.alert("Please select a workflow.");
//                    return false;
//                }
//                if (isNaN(this.Alert.AlertStateID) == true || this.Alert.AlertStateID == 0) {
//                    this.alert("Please select a state.");
//                    return false;
//                }
//                if (this.Alert.AssignedEmployeeCode == '') {
//                    this.alert("Please select an assignee.");
//                    return false;
//                }
//            } else {

//                if (this.Alert.Assignees == undefined) {
//                    this.alert("Please select an assignee.");
//                    return false;
//                }
//                if (this.Alert.Assignees != undefined) {
//                    if (this.Alert.Assignees[0] == '' || this.Alert.Assignees.length == 0) {
//                        this.alert("Please select an assignee.");
//                        return false;
//                    }
//                }
//            }
//            if (this.Alert.SprintID > 0) {
//                if (this.Alert.JobNumber == undefined || this.Alert.JobNumber == 0) {
//                    this.alert("Please select a job when creating an assignment for a sprint.");
//                    return false;
//                }
//                if (this.Alert.JobComponentNumber == undefined || this.Alert.JobComponentNumber == 0) {
//                    this.alert("Please select a component when creating an assignment for a sprint.");
//                    return false;
//                }
//            }
//            this.Alert.IsWorkItem = true;
//            this.setAlertLevel();
//            this.Alert.LinkedDocuments = [];
//            if (this.linkableDocuments) {
//                for (var i = 0; i < this.linkableDocuments.length; i++) {
//                    this.Alert.LinkedDocuments.push(this.linkableDocuments[i].ID);
//                }
//            }
//            //this.service.createAssignment(this.Alert, notify, this.uploadToDocumentManager, this.uploadToProofHQ).then(response => {
//            //    if (response.content.Success === true) {
//                    //wvbridge.CloseWindow();
//                    //try {
//                    //    var win = this.getRadWindow();
//                    //    if (win) {
//                    //        win.close();
//                    //    }
//                    //} catch (e) {
//                    //}
//            //    } else if (response.content.Message) {
//            //        this.alert(response.content.Message);
//            //    }
//            //});
//            var s = "";
//            var d = "";
//            if (this.Alert.StartDate) {
//                s = this.parseShortDate(this.Alert.StartDate).value;
//            }
//            if (this.Alert.DueDate) {
//                d = this.parseShortDate(this.Alert.DueDate).value;
//            }
//            this.service.createAssignmentWithDateWorkaround(this.Alert, s, d, notify, this.uploadToDocumentManager, this.uploadToProofHQ, "", "").then(response => {
//                if (response.content.success === true) {
//                    //try {
//                    //    this.webvantage.refreshAlertNotifications();
//                    //} catch (e) {
//                    //}
//                    //try {
//                    //    this.webvantage.getAlertNotificationsCount();
//                    //} catch (e) {
//                    //}
//                    if (this.contentpage = "1") {
//                        try {
//                            wvbridge.CloseWindowNew();
//                        } catch (e) {
//                        }
//                    } else {
//                        try {
//                            wvbridge.CloseWindow();
//                        } catch (e) {
//                        }
//                    }
                    
//                    try {
//                        var win = this.getRadWindow();
//                        if (win) {
//                            win.close();
//                        }
//                    } catch (e) {
//                    }
//                } else if (response.content.Message) {
//                    this.alert(response.content.Message);
//                }
//            });
//        }
//    }

//    isBoardTaskChanged(newValue, oldValue) {
//        //this.Alert.Subject = '';
//        if (this.isBoardTask === true) {
//            this.isRouted = false;
//        }
//        this.checkTaskEnabled();
//    }
//    showAllEmployeesChanged(newValue, oldValue) {
//        this.alertTemplateStateEmployeesDataSource.read();
//    }
//    alertStateIDChanged(newValue, oldValue) {
//        this.alertTemplateStateEmployeesDataSource.read();
//    }
//    alertAssignmentTemplateIDChanged(newValue, oldValue) {
//        this.Alert.AlertStateID = null;
//        if (this.alertTemplateStatesListBox) {
//            this.alertTemplateStatesListBox.clearSelection();
//            this.alertTemplateStatesListboxChange();
//            this.alertTemplateStatesDataSource.read();
//        }
//    }
//    isRoutedChanged(newValue, oldValue) {
//        let me = this;
//        this.Alert.Assignees = [];
//        this.Alert.AssignedEmployeeCode = null;
//        this.Alert.AlertStateID = null;
//        if (newValue === true) {
//            if (this.defaultWorkflowTemplate) {
//                this.Alert.AlertAssignmentTemplateID = this.defaultWorkflowTemplate.AlertAssignmentTemplateID;
//            } else {
//                this.Alert.AlertAssignmentTemplateID = null;
//            }
//        } else {
//            this.Alert.AlertAssignmentTemplateID = null;
//        }
//        if (this.alertAssignmentTemplateDropDownList) {
//            this.alertAssignmentTemplateDropDownList.value("");
//        }
//        if (this.isRouted === true) {
//            if (this.Alert.AlertCategoryID === 71) {
//                this.Alert.AlertCategoryID = null;
//            }
//        }
//        window.setTimeout(function () {
//            me.checkIsBoardTask();
//            me.refreshTypes();
//        }, 0);
//    }
//    descriptionChanged(e) {
//        this.Alert.EmailBody = this.descriptionEditor.value();
//    }
//    taskFunctionChanged(e) {
//        this.setSubjectFromSelectedTaskFunction();
//    }
//    setSubjectFromSelectedTaskFunction() {
//        try {
//            if (this.isBoardTask === true) {
//                if (this.taskFunctionDropDownList) {
//                    var item = this.taskFunctionDropDownList.dataItem(this.taskFunctionDropDownList.select());
//                    var subject = '';
//                    if (item.Code && item.Code !== '') {
//                        subject = item.Description;
//                        this.allowEditSubject = false;
//                        this.Alert.Subject = subject;
//                    } else {
//                        this.allowEditSubject = true;
//                    }
//                }
//            }
//        } catch (e) {
//        }
//    }


//    @bindable boardDropDownListEnabled: boolean = false;
//    @bindable sprintDropDownListEnabled: boolean = false;
//    @bindable boardStateDropDownListEnabled: boolean = false;
//    @bindable hasBoardInfo: boolean = false;
//    boardInfo: any;

//    clearBoardInfo() {
//        if (this.boardDropDownList) {
//            this.boardDropDownList.value(null);
//            this.boardDropDownList.enable(false);
//        }
//        if (this.sprintDropDownList) {
//            this.sprintDropDownList.value(null);
//            this.sprintDropDownList.enable(false);
//        }
//        if (this.boardStateDropDownList) {
//            this.boardStateDropDownList.value(null);
//            this.boardStateDropDownList.enable(false);
//        }
//        this.boardDropDownListEnabled = false;
//        this.sprintDropDownListEnabled = false;
//        this.boardStateDropDownListEnabled = false;
//    }
//    checkForBoard() {
//        //console.log("checkForBoard");
//        let me = this;
//        me.hasBoardInfo = false;
//        me.clearBoardInfo();
//        if (me.Alert.JobNumber && me.Alert.JobNumber > 0 && me.Alert.JobComponentNumber && me.Alert.JobComponentNumber > 0) {
//            me.service.checkForBoard(me.Alert.JobNumber, me.Alert.JobComponentNumber).then(response => {
//                if (response && response.content) {
//                    me.boardInfo = response.content;
//                    if (me.boardInfo.HasActiveBoard == true) {
//                        me.hasBoardInfo = true;
//                        if (me.boardDropDownList) {
//                            me.boardDropDownList.enable(true);
//                        }
//                        me.boardDropDownListEnabled = true;
//                        me.boardDataSource = new kendo.data.DataSource({
//                            data: me.boardInfo.DisplayBoards
//                        });
//                        me.boardDropDownList.setDataSource(me.boardDataSource);
//                        var items = me.boardDataSource.data();
//                        if (items) {
//                            if (items.length == 1) {
//                                window.setTimeout(function () {
//                                    me.Alert.BoardHeaderID = items[0].ID;
//                                    me.boardDropDownList.value(items[0].ID);
//                                    me.getBoardSprintInfo();
//                                }, 10);
//                            }
//                        }
//                        //if (me.boardInfo.Sprints) {
//                        //    me.sprintDataSource = new kendo.data.DataSource({
//                        //        data: me.boardInfo.Sprints
//                        //    });
//                        //    me.sprintDropDownList.setDataSource(me.sprintDataSource);
//                        //    me.sprintDropDownListEnabled = true;
//                        //    if (me.boardInfo.Sprints.length == 1) {
//                        //        me.Alert.SprintID = me.boardInfo.Sprints[0].ID;
//                        //    }
//                        //} else {
//                        //    me.getBoardSprintInfo();
//                        //}
//                        //me.boardStateDataSource = new kendo.data.DataSource({
//                        //    data: me.boardInfo.States
//                        //});
//                        //me.boardStateDropDownList.setDataSource(me.boardStateDataSource);
//                        //me.boardStateDropDownListEnabled = true;
//                        //console.log("checkForBoard", me.Alert.BoardHeaderID, me.boardDropDownList.value())
//                    }
//                }
//            });
//        }
//    }
//    boardDropDownListChange(evt) {
//        //console.log("boardDropDownListChanged")
//        if (this.sprintDropDownList) {
//            this.sprintDropDownList.value(null);
//            this.sprintDropDownList.enable(false);
//        }
//        if (this.boardStateDropDownList) {
//            this.boardStateDropDownList.value(null);
//            this.boardStateDropDownList.enable(false);
//        }
//        this.sprintDropDownListEnabled = false;
//        this.boardStateDropDownListEnabled = false;
//        this.getBoardSprintInfo();
//    }
//    getBoardSprintInfo() {
//        let me = this;
//        if (me.Alert.BoardHeaderID && me.Alert.BoardHeaderID > 0) {
//            window.setTimeout(function () {
//                //console.log("getBoardSprintInfo", me.Alert.BoardHeaderID, me.boardDropDownList.value())
//                me.service.getBoardSprints(me.Alert.BoardHeaderID).then(response => {
//                    if (response) {
//                        me.sprintDataSource = new kendo.data.DataSource({
//                            data: response.content
//                        });
//                        me.sprintDropDownList.setDataSource(me.sprintDataSource);
//                        me.sprintDropDownList.enable(true);
//                        me.sprintDropDownListEnabled = true;
//                        var items = me.sprintDataSource.data();
//                        if (items && items.length == 1) {
//                            window.setTimeout(function () {
//                                me.sprintDropDownListEnabled = true;
//                                me.Alert.SprintID = items[0].ID;
//                                me.getBoardStateInfo();
//                            }, 10);
//                        }
//                    }
//                });
//            }, 10);
//        }
//    }
//    boardSprintDropDownListChange(evt) {
//        if (this.boardStateDropDownList) {
//            this.boardStateDropDownList.value(null);
//            this.boardStateDropDownList.enable(false);
//        }
//        this.boardStateDropDownListEnabled = false;
//        this.getBoardStateInfo();
//    }
//    getBoardStateInfo() {
//        let me = this;
//        if (me.Alert.SprintID && me.Alert.SprintID > 0) {
//            me.service.getBoardSprintStates(me.Alert.SprintID).then(response => {
//                if (response && response.content) {
//                    me.boardStateDataSource = new kendo.data.DataSource({
//                        data: response.content
//                    });
//                    me.boardStateDropDownList.setDataSource(me.boardStateDataSource);
//                    me.boardStateDropDownList.enable(true);
//                    me.boardStateDropDownListEnabled = true;
//                }
//                var items = me.boardStateDataSource.data();
//                if (items && items.length == 1) {
//                    window.setTimeout(function () {
//                        me.boardStateDropDownList.enable(true);
//                        me.boardStateDropDownListEnabled = true;
//                        me.Alert.BoardStateID = items[0].ID;
//                    }, 10);
//                }
//            });
//        }
//    }

//    checkSingleClient(officeCode: string) {
//        if (officeCode) {
//            var items = this.officeDropDownList.dataSource.data();
//            let client = null;
//            let multiple = false;
//            for (var i = 0; i < items.length; i++) {
//                if (items[i].OfficeCode === officeCode) {
//                    if (!client) {
//                        client = items[i];
//                    } else {
//                        multiple = true;
//                    }
//                }
//            }
//            if (client && !multiple) {
//                this.Alert.ClientCode = client.ClientCode;
//                this.Alert.ClientName = client.ClientName;
//                this.clientDropDownList.value(client.ClientCode);
//                this.clientDropDownList.enable(true);
//                //let me = this;
//                //window.setTimeout(function () {
//                //    me.checkSingleDivision(client.ClientCode);
//                //}, 0);
//            } else {
//                this.clientDropDownList.focus();
//            }
//        }
//        this.divisionDropDownList.enable(false);
//    }
//    checkSingleDivision(clientCode: string) {
//        console.log("checkSingleDivision")
//        if (clientCode) {
//            var items = this.divisionDropDownList.dataSource.data();
//            let division = null;
//            let multiple = false;
//            for (var i = 0; i < items.length; i++) {
//                if (items[i].ClientCode === clientCode) {
//                    if (!division) {
//                        division = items[i];
//                    } else {
//                        multiple = true;
//                    }
//                }
//            }
//            if (division && !multiple) {
//                this.Alert.DivisionCode = division.DivisionCode;
//                this.Alert.DivisionName = division.DivisionName;
//                this.divisionDropDownList.value(division.DivisionCode);
//                this.divisionDropDownList.enable(true);
//                //let me = this;
//                //window.setTimeout(function () {
//                //    me.checkSingleProduct(division.ClientCode, division.DivisionCode);
//                //}, 0);
//            } else {
//                this.divisionDropDownList.focus();
//            }
//        }
//    }
//    checkSingleProduct(clientCode, divisionCode) {
//        if (clientCode && divisionCode) {
//            var items = this.productDropDownList.dataSource.data();
//            let product = null;
//            let multiple = false;
//            for (var i = 0; i < items.length; i++) {
//                if (items[i].ClientCode === clientCode && items[i].DivisionCode === divisionCode) {
//                    if (!product) {
//                        product = items[i];
//                    } else {
//                        multiple = true;
//                    }
//                }
//            }
//            if (product && !multiple) {
//                this.Alert.ProductCode = product.ProductCode;
//                this.Alert.ProductName = product.ProductName;
//                this.productDropDownList.value(product.ProductCode);
//                this.productDropDownList.enable(true);
//                //let me = this;
//                //window.setTimeout(function () {
//                //    me.checkSingleJob(product.ClientCode, product.DivisionCode, product.ProductCode);
//                //}, 0);
//            } else {
//                this.productDropDownList.focus();
//            }
//        }
//    }
//    checkSingleJob(clientCode: string, divisionCode: string, productCode: string) {
//        if (clientCode && divisionCode && productCode) {
//            var items = this.jobDropDownList.dataSource.data();
//            let job = null;
//            let multiple = false;
//            for (var i = 0; i < items.length; i++) {
//                if (items[i].ClientCode === clientCode && items[i].DivisionCode === divisionCode && items[i].ProductCode === productCode) {
//                    if (!job) {
//                        job = items[i];
//                    } else {
//                        multiple = true;
//                    }
//                }
//            }
//            if (job && job.JobNumber && job.JobNumber > 0 && !multiple) {
//                this.Alert.JobNumber = job.JobNumber;
//                this.Alert.JobDescription = job.JobDescription;
//                this.jobDropDownList.value(job.JobNumber);
//                let me = this;
//                //window.setTimeout(function () {
//                //    me.componentsDataSource.read();
//                //}, 0);
//                //window.setTimeout(function () {
//                //    me.checkSingleComponent(job.JobNumber);
//                //}, 0);
//            } else {
//                this.jobDropDownList.focus();
//            }
//        }
//    }
//    checkSingleComponent(jobNumber: number) {
//        let me = this;
//        if (jobNumber && jobNumber > 0) {
//            var items = this.jobComponentDropDownList.dataSource.data();
//            let component = null;
//            let multiple = false;
//            if (items) {
//                this.jobComponentDropDownList.enable(true);
//                for (var i = 0; i < items.length; i++) {
//                    if (items[i].JobNumber === jobNumber) {
//                        if (!component) {
//                            component = items[i];
//                        } else {
//                            multiple = true;
//                        }
//                    }
//                }
//            }
//            if (component && !multiple) {
//                this.Alert.JobComponentNumber = component.JobComponentNumber;
//                this.Alert.JobComponentDescription = component.JobComponentDescription;
//                this.jobComponentDropDownList.value(component.JobComponentNumber);
//                me.jobComponentNumberChanged(component.JobComponentNumber, 0);
//                $('#isRouted').focus();
//                window.setTimeout(function () {
//                    me.componentChanged(null);
//                }, 0);
//            } else {
//                if (this.Alert && this.Alert.JobComponentNumber && this.Alert.JobComponentDescription) {
//                    this.jobComponentDropDownList.value(this.Alert.JobComponentNumber + "");
//                    me.jobComponentNumberChanged(this.Alert.JobComponentNumber, 0);
//                    window.setTimeout(function () {
//                        me.componentChanged(null);
//                    }, 0);
//                } else {
//                    this.jobComponentDropDownList.focus();
//                }
//            }
//        }
//    }
//    checkSingleTask(jobNumber: number, jobComponentNumber: number) {

//    }
//    checkSingleAll() {
//        console.log("checkSingleAll", this.divisionDropDownList, this.Alert.DivisionCode)
//        let me = this;
//        var items: any = null;
//        var versionChecked: boolean = false;
//        this.setDefaultDropDownEnabled();
//        if (this.officeDropDownList) {
//            items = this.officeDropDownList.dataSource.data();
//            if ((items && items.length == 1 && this.Alert.OfficeCode !== "")) {
//                setTimeout(function () {
//                    me.officeDropDownList.enable(false);
//                }, 0);
//            }
//            items = null;
//        }
//        if (this.clientDropDownList) {
//            items = this.clientDropDownList.dataSource.data();
//            if ((items && items.length == 1 && this.Alert.ClientCode !== "") || (!this.Alert.ClientCode || this.Alert.ClientCode == "")) {
//                setTimeout(function () {
//                    me.clientDropDownList.enable(false);
//                }, 0);
//            }
//            items = null;
//        }
//        if (this.divisionDropDownList) {
//            //console.log(" this.divisionDropDownList.value()", this.divisionDropDownList.value(), this.Alert.DivisionCode);
//            items = this.divisionDropDownList.dataSource.data();
//            if ((items && items.length == 1 && this.Alert.DivisionCode !== "") || (!this.Alert.DivisionCode || this.Alert.DivisionCode == "")) {
//                setTimeout(function () {
//                    me.divisionDropDownList.enable(false);
//                }, 0);
//            }
//            items = null;
//        }
//        if (this.productDropDownList) {
//            items = this.productDropDownList.dataSource.data();
//            if ((items && items.length == 1 && this.Alert.ProductCode !== "")) {
//                setTimeout(function () {
//                    me.productDropDownList.enable(false);
//                }, 0);
//            }
//            items = null;
//        }
//        if (this.jobDropDownList) {
//            items = this.jobDropDownList.dataSource.data();
//            if ((items && items.length == 1 && this.Alert.JobNumber > 0)) {
//                setTimeout(function () {
//                    me.jobDropDownList.enable(false);
//                }, 0);
//                if (versionChecked == false) {
//                    me.getSoftwareVersions();
//                }
//            }
//            items = null;
//        }
//        if (this.jobComponentDropDownList) {
//            items = this.jobComponentDropDownList.dataSource.data();
//            if ((items && items.length == 1 && this.Alert.JobComponentNumber > 0)) {
//                setTimeout(function () {
//                    me.jobComponentDropDownList.enable(false);
//                }, 0);
//                me.getSoftwareVersions();
//                versionChecked = true;
//            }
//            items = null;
//        }
//    }

//    checkForSchedule() {
//        var hasSchedule = false;
//        if (this.jobComponentDropDownList) {
//            let item = this.jobComponentDropDownList.dataItem(this.jobComponentDropDownList.select());
//            if (item) {
//                hasSchedule = item.HasSchedule;
//            }
//        }
//        this.Alert.HasSchedule = hasSchedule;
//    }
//    checkClearJob(clientCode: string, divisionCode: string | boolean, productCode: string | boolean) {
//        //try {
//        //    var clearJob = true;
//        //    //console.log(this.jobDropDownList.select())
//        //    var job = this.jobDropDownList.dataItem(this.jobDropDownList.select());
//        //    if (job) {
//        //        clearJob = false;
//        //        if (job.ClientCode !== clientCode) {
//        //            clearJob = true;
//        //        }
//        //        if (divisionCode !== false) {
//        //            if (job.DivisionCode !== divisionCode) {
//        //                clearJob = true;
//        //            }
//        //        }
//        //        if (productCode !== false) {
//        //            if (job.ProductCode !== productCode) {
//        //                clearJob = true;
//        //            }
//        //        }
//        //    }
//        //    if (clearJob) {
//        //        this.Alert.JobNumber = null;
//        //        this.jobDropDownList.value(null);
//        //        this.Alert.JobComponentNumber = null;
//        //        this.jobComponentDropDownList.value(null);
//        //    }
//        //} catch (e) {
//        //    //console.log("checkClearJob Error: ", e)
//        //}
//    }

//    setFilterFromOffice() {
//        let filters = [], filter = {};
//        let me = this;
//        if (this.officeDropDownList) {
//            var oCode;
//            var oMatch = false;
//            oCode = this.officeDropDownList.value();
//            if (this.clientsDataSource.filter() && this.clientsDataSource.filter().filters.length > 0) {
//                for (var i = 0; i < this.clientsDataSource.filter().filters.length; i++) {
//                    var oFilter: any = this.clientsDataSource.filter().filters[i];
//                    if (oFilter.field === 'OfficeCode') {
//                        if (oFilter.value === oCode) {
//                            oMatch = true;
//                        }
//                    }
//                }
//            }
//            if (!oMatch) {
//                if (oCode) {
//                    try {
//                        filters.push({ field: "OfficeCode", operator: "eq", value: oCode });
//                    } catch (e) { }
//                    if (this.clientDropDownList.value()) {
//                        try {
//                            filters.push({ field: "ClientCode", operator: "eq", value: this.clientDropDownList.value() });
//                        } catch (e) { }
//                        if (this.divisionDropDownList.value()) {
//                            try {
//                                filters.push({ field: "DivisionCode", operator: "eq", value: this.divisionDropDownList.value() });
//                            } catch (e) { }
//                            if (this.productDropDownList.value()) {
//                                try {
//                                    filters.push({ field: "ProductCode", operator: "eq", value: this.productDropDownList.value() });
//                                } catch (e) { }
//                            }
//                        }
//                    }
//                    filter = {
//                        logic: 'and',
//                        filters: filters
//                    };
//                    //console.log("office filter", filter);
//                    this.clientsDataSource.filter(filter);
//                    this.clientDropDownList.setDataSource(this.clientsDataSource);
//                    me.checkSingleClient(oCode);
//                }
//            }
//        }
//    }
//    setJobFilters() {
//        //console.log("setJobFilters");
//        let filters = [], filter = {};
//        if (this.clientDropDownList) {
//            var cCode, dCode, pCode;
//            var cMatch = false,
//                dMatch = false,
//                pMatch = false;
//            cCode = this.clientDropDownList.value();
//            dCode = this.divisionDropDownList.value();
//            pCode = this.productDropDownList.value();
//            if (this.jobsDataSource.filter() && this.jobsDataSource.filter().filters.length > 0) {
//                for (var i = 0; i < this.jobsDataSource.filter().filters.length; i++) {
//                    var cFilter: any = this.jobsDataSource.filter().filters[i];
//                    if (cFilter.field === 'ClientCode') {
//                        if (cFilter.value === cCode) {
//                            cMatch = true;
//                        }
//                    }
//                    if (cFilter.field === 'DivisionCode') {
//                        if (cFilter.value === dCode) {
//                            dMatch = true;
//                        }
//                    }
//                    if (cFilter.field === 'ProductCode') {
//                        if (cFilter.value === pCode) {
//                            pMatch = true;
//                        }
//                    }
//                }
//            }
//            if (!cMatch || !dMatch || !pMatch) {
//                if (this.clientDropDownList.value()) {
//                    filters.push({ field: "ClientCode", operator: "eq", value: this.clientDropDownList.value() });
//                    if (this.divisionDropDownList.value()) {
//                        filters.push({ field: "DivisionCode", operator: "eq", value: this.divisionDropDownList.value() });
//                        if (this.productDropDownList.value()) {
//                            filters.push({ field: "ProductCode", operator: "eq", value: this.productDropDownList.value() });
//                        }
//                    }
//                }
//                filter = {
//                    logic: 'and',
//                    filters: filters
//                };
//                this.jobsDataSource.filter(filter);
//                this.jobDropDownList.setDataSource(this.jobsDataSource);
//            }
//        }
//    }

//    lastClicked: string = "";
//    jobClicked: boolean = false;

//    officeOnCascade(e) {
//        //if (e) {
//        //    //console.log("officeOnCascade");
//        //    //if (typeof e.userTriggered === 'undefined') {
//        //    //    if (!this.officeDropDownList) {
//        //    //        return;
//        //    //    }
//        //    //}
//        //    //var isUserTrig = false;
//        //    //isUserTrig = e.userTriggered;
//        //    //if (isUserTrig == undefined || isUserTrig == false) {
//        //    //    return;
//        //    //}
//        //    let sender: kendo.ui.DropDownList = e.sender;
//        //    let me = this;
//        //    //window.setTimeout(function () {
//        //    //    me.Alert.ClientCode = null
//        //    //    if (me.clientDropDownList) {
//        //    //        me.clientDropDownList.value(null);
//        //    //    }
//        //    //}, 0);
//        //    //window.setTimeout(function () {
//        //    //    me.Alert.DivisionCode = null
//        //    //    if (me.divisionDropDownList) {
//        //    //        me.divisionDropDownList.value(null);
//        //    //        me.divisionDropDownList.enable(false);
//        //    //    }
//        //    //}, 0);
//        //    //window.setTimeout(function () {
//        //    //    me.Alert.ProductCode = null
//        //    //    if (me.productDropDownList) {
//        //    //        me.productDropDownList.value(null);
//        //    //        me.productDropDownList.enable(false);
//        //    //    }
//        //    //}, 0);
//        //    //if (sender.value() !== '') {
//        //    //    window.setTimeout(function () {
//        //    //        me.setFilterFromOffice();
//        //    //    }, 0);
//        //    //}
//        //}
//    }
//    officeChanged(e) {
//        let me = this;
//        console.log("officeChanged", me.Alert);
//        me.Alert.ClientCode = "";
//        me.Alert.DivisionCode = "";
//        me.Alert.ProductCode = "";
//        me.Alert.JobNumber = 0;
//        me.Alert.JobComponentNumber = 0;
//        me.Alert.TaskSequenceNumber = -1;
//        me.Alert.ClientName = "";
//        me.Alert.DivisionName = "";
//        me.Alert.ProductName = "";
//        me.Alert.JobDescription = "";
//        me.Alert.JobComponentDescription = "";
//        me.divisionDropDownList.value(null);
//        me.divisionDropDownList.enable(false);
//        me.productDropDownList.value(null);
//        me.productDropDownList.enable(false);
//        me.jobDropDownList.value(null);
//        me.jobDropDownList.enable(true);
//        me.jobComponentDropDownList.value(null);
//        me.jobComponentDropDownList.enable(false);
//        me.refreshClients();
//        me.refreshJobs();
//        //console.log("OFF VAL?", me.Alert.OfficeCode)
//        //if (this.officeDropDownList) {
//        //    //var oCode;
//        //    //var oMatch = false;
//        //    //oCode = this.officeDropDownList.value();
//        //    //console.log("officeChanged", oCode, this.jobsDataSource.filter());
//        //    //if (this.jobsDataSource.filter() && this.jobsDataSource.filter().filters.length > 0) {
//        //    //    //console.log("officeChanged this.jobsDataSource.filter().filters", this.jobsDataSource.filter().filters);
//        //    //}
//        //    //if (oCode) {

//        //    //} else {

//        //    //}
//        //}
//    }
//    officeOnOpen(e) {
//        let me = this;
//        me.lastClicked = "office";
//        me.jobClicked = false;
//    }

//    clientOnCascade(e) {
//        if (e) {
//            //if (typeof e.userTriggered === 'undefined') {
//            //    if (!this.clientDropDownList) {
//            //        return;
//            //    }
//            //}
//            //var isUserTrig = false;
//            //isUserTrig = e.userTriggered;
//            //if (isUserTrig == undefined || isUserTrig == false) {
//            //    return;
//            //}
//            //console.log("clientOnCascade user trig", isUserTrig)
//            //console.log("clientOnCascade");
//            //let sender: kendo.ui.DropDownList = e.sender;
//            //let me = this;
//            //window.setTimeout(function () {
//            //    me.Alert.DivisionCode = null
//            //    if (me.divisionDropDownList) {
//            //        me.divisionDropDownList.value(null);
//            //    }
//            //}, 0);
//            //window.setTimeout(function () {
//            //    me.Alert.ProductCode = null
//            //    if (me.productDropDownList) {
//            //        me.productDropDownList.value(null);
//            //    }
//            //}, 0);
//            //console.log("clientOnCascade", e.userTriggered, this.clientDropDownList, sender.value())
//            //this.checkClearJob(sender.value(), false, false);
//            ////this.setJobFilters();
//            //if (sender.value() !== '') {
//            //    window.setTimeout(function () {
//            //        me.checkSingleDivision(sender.value());
//            //    }, 0);
//            //}
          
//        }
//    }
//    clientChanged(e) {
//        console.log("clientChanged");
//        let me = this;
//        if (me.lastClicked == "office" || me.lastClicked == "client") {
//            me.jobClicked = false;
//            window.setTimeout(function () {
//                me.Alert.DivisionCode = "";
//                me.Alert.ProductCode = "";
//                me.Alert.JobNumber = 0;
//                me.Alert.JobComponentNumber = 0;
//                me.Alert.TaskSequenceNumber = -1;
//                me.divisionDropDownList.value(null);
//                me.productDropDownList.value(null);
//                me.jobDropDownList.value(null);
//                me.jobComponentDropDownList.value(null);
//            }, 0);
//            if (me.Alert.ClientCode != "") {
//                var item = this.clientDropDownList.select();
//                var dataItem = <any>this.clientDropDownList.dataItem(item);
//                if (dataItem && this.Alert) {
//                    if (dataItem.ClientCode) {
//                        this.Alert.ClientCode = dataItem.ClientCode;
//                    }
//                    if (dataItem.ClientName) {
//                        this.Alert.ClientName = dataItem.ClientName;
//                    }
//                }
//                me.refreshDivisions();
//                me.divisionDropDownList.enable(true);
//            } else {
//                this.lastClicked = "";
//                me.divisionDropDownList.enable(false);
//                me.productDropDownList.enable(false);
//                me.jobComponentDropDownList.enable(false);
//                window.setTimeout(function (e) {
//                    me.refreshJobs();
//                }, 200);
//            }
//            //this.refreshRecipients();
//        }
//    }
//    clientOnOpen(e) {
//        let me = this;
//        me.lastClicked = "client";
//        me.jobClicked = false;
//    }

//    divisionOnCascade(e) {
//        //if (e) {
//        //    if (typeof e.userTriggered === 'undefined') {
//        //        if (!this.divisionDropDownList) {
//        //            return;
//        //        }
//        //    }
//        //    var isUserTrig = false;
//        //    isUserTrig = e.userTriggered;
//        //    if (isUserTrig == undefined || isUserTrig == false) {
//        //        return;
//        //    }
//        //    //console.log("divisionOnCascade user trig", isUserTrig)
//        //    //console.log("divisionOnCascade");
//        //    let sender: kendo.ui.DropDownList = e.sender;
//        //    let me = this;
//        //    window.setTimeout(function () {
//        //        me.Alert.ProductCode = null
//        //        if (me.productDropDownList) {
//        //            me.productDropDownList.value(null);
//        //        }
//        //    }, 0);
//        //    //console.log("divisionOnCascade", e.userTriggered, this.divisionDropDownList)
//        //    //this.checkClearJob(this.clientDropDownList.value(), sender.value(), false);
//        //    //me.setJobFilters();
//        //    if (sender.value() !== '') {
//        //        window.setTimeout(function () {
//        //            me.checkSingleProduct(me.clientDropDownList.value(), me.divisionDropDownList.value());
//        //        }, 0);
//        //    }
//        //}
//    }
//    divisionChanged(e) {
//        let me = this;
//        if (me.lastClicked == "" || me.lastClicked == "client") {
//            console.log("divisionChanged");
//            me.jobClicked = false;
//            if (me.Alert.JobNumber == 0) {
//                window.setTimeout(function () {
//                    me.Alert.ProductCode = "";
//                    me.Alert.JobNumber = 0;
//                    me.Alert.JobComponentNumber = 0;
//                    me.Alert.TaskSequenceNumber = -1;
//                    me.productDropDownList.value(null);
//                    me.jobDropDownList.value(null);
//                    me.jobComponentDropDownList.value(null);
//                }, 0);
//            }
//            me.refreshProducts();
//            if (me.Alert.ClientCode != "" && me.Alert.DivisionCode != "") {
//                var item = me.divisionDropDownList.select();
//                var dataItem = <any>me.divisionDropDownList.dataItem(item);
//                if (dataItem && me.Alert) {
//                    if (dataItem.DivisionCode) {
//                        me.Alert.DivisionCode = dataItem.DivisionCode;
//                    }
//                    if (dataItem.DivisionName) {
//                        me.Alert.DivisionName = dataItem.DivisionName;
//                    }
//                }
//                me.productDropDownList.enable(true);
//            } else {
//                me.productDropDownList.enable(false);
//                me.jobComponentDropDownList.enable(false);
//            }
//        }
//    }
//    divisionOnOpen(e) {
//        let me = this;
//        me.lastClicked = "division";
//        me.jobClicked = false;
//    }

//    productOnCascade(e) {
//        if (e) {
//            //let sender: kendo.ui.DropDownList = e.sender;
//            //let me = this;
//            //var clVal;
//            //var divVal;
//            //if (typeof e.userTriggered === 'undefined') {
//            //    if (!this.productDropDownList) {
//            //        if (this.clientDropDownList) {
//            //            clVal = this.clientDropDownList.value()
//            //        } else {
//            //            clVal = false;
//            //        }
//            //        if (this.divisionDropDownList) {
//            //            divVal = this.divisionDropDownList.value()
//            //        } else {
//            //            divVal = false;
//            //        }
//            //        this.checkClearJob(clVal, divVal, sender.value());
//            //        this.setJobFilters();
//            //        return;
//            //    }
//            //}
//            ////console.log("productOnCascade");
//            //var isUserTrig = false;
//            //isUserTrig = e.userTriggered;
//            //if (isUserTrig == undefined || isUserTrig == false) {
//            //    this.checkClearJob(this.clientDropDownList.value(), this.divisionDropDownList.value(), sender.value());
//            //    this.setJobFilters();
//            //    return;
//            //}
//            //this.checkClearJob(this.clientDropDownList.value(), this.divisionDropDownList.value(), sender.value());
//            //if (sender.value() !== '') {
//            //    window.setTimeout(function () {
//            //        me.checkSingleJob(me.clientDropDownList.value(), me.divisionDropDownList.value(), me.productDropDownList.value());
//            //    }, 0);
//            //} else {
//            //    if (this.jobDropDownList) {
//            //        this.Alert.JobNumber = null;
//            //        this.jobDropDownList.value(null);
//            //    }
//            //}
//        }
//    }
//    productChanged(e) {
//        let me = this;
//        console.log("productChanged");
//        //if (me.jobClicked == false && (me.lastClicked == "" || me.lastClicked == "product" || me.lastClicked == "client")) {
//            window.setTimeout(function () {
//                me.Alert.JobNumber = 0;
//                me.Alert.JobComponentNumber = 0;
//                me.Alert.TaskSequenceNumber = -1;
//                me.jobDropDownList.value(null);
//                me.jobComponentDropDownList.value(null);
//            }, 0);
//            if (me.Alert.ClientCode != "" && me.Alert.DivisionCode != "" && me.Alert.ProductCode != "") {
//                var item = me.productDropDownList.select();
//                var dataItem = <any>me.productDropDownList.dataItem(item);
//                if (dataItem && me.Alert) {
//                    if (dataItem.ProductCode) {
//                        me.Alert.ProductCode = dataItem.ProductCode;
//                    }
//                    if (dataItem.ProductName) {
//                        me.Alert.ProductName = dataItem.ProductName;
//                    }
//                }
//            } else {
//                me.jobComponentDropDownList.enable(false);
//            }
//            me.refreshJobs();
//            me.jobDropDownList.enable(true);
//            //me.refreshRecipients();
//        //}
//    }
//    productOnOpen(e) {
//        let me = this;
//        me.lastClicked = "product";
//        me.jobClicked = false;
//    }

//    jobOnCascade(e) {
//        //if (typeof e.userTriggered === 'undefined') {
//        //    if (!this.jobDropDownList) {
//        //        return;
//        //    }
//        //}
//        //var isUserTrig = false;
//        //isUserTrig = e.userTriggered;
//        //if (isUserTrig == undefined || isUserTrig == false) {
//        //    return;
//        //}
//        ////console.log("jobOnCascade");
//        //let sender: kendo.ui.DropDownList = e.sender;
//        //let me = this;
//        //if (sender.value() !== '') {
//        //    let job = sender.dataItem(sender.select());
//        //    if (this.clientDropDownList) {
//        //        this.clientDropDownList.value(job.ClientCode);
//        //        window.setTimeout(function () {
//        //            if (me.divisionDropDownList) {
//        //                me.divisionDropDownList.enable(true);
//        //                me.Alert.DivisionCode = job.DivisionCode;
//        //                me.divisionDropDownList.value(job.DivisionCode);
//        //                me.productDropDownList.dataSource.filter({ field: 'DivisionCode', operator: 'eq', value: job.DivisionCode });
//        //            }
//        //            window.setTimeout(function () {
//        //                if (me.productDropDownList) {
//        //                    me.productDropDownList.enable(true);
//        //                    me.Alert.ProductCode = job.ProductCode;
//        //                    me.productDropDownList.value(job.ProductCode);
//        //                }
//        //                window.setTimeout(function () {
//        //                    if (me.jobDropDownList) {
//        //                        me.Alert.JobNumber = job.JobNumber;
//        //                        me.jobDropDownList.value(job.JobNumber);
//        //                    }
//        //                }, 0);
//        //            }, 0);
//        //        }, 0);
//        //    }
//        //}
//    }
//    jobChanged(e) {
//        let me = this;
//        console.log("jobChanged", me.lastClicked);
//        window.setTimeout(function () {
//            me.Alert.JobComponentNumber = 0;
//            me.Alert.TaskSequenceNumber = -1;
//            me.jobComponentDropDownList.value(null);
//        }, 0);
//        if (me.lastClicked == "" || me.lastClicked == "job") {
//            //backfill
//            var item = me.jobDropDownList.select();
//            var dataItem = <any>me.jobDropDownList.dataItem(item);

//            if (me.Alert.OfficeCode != dataItem.OfficeCode) { me.Alert.OfficeCode = dataItem.OfficeCode; }
//            if (me.Alert.ClientCode != dataItem.ClientCode) { me.Alert.ClientCode = dataItem.ClientCode; }
//            if (me.Alert.DivisionCode != dataItem.DivisionCode) { me.Alert.DivisionCode = dataItem.DivisionCode; }
//            if (me.Alert.ProductCode != dataItem.ProductCode) { me.Alert.ProductCode = dataItem.ProductCode; }
//            if (me.Alert.JobNumber != parseInt(dataItem.JobNumber)) { me.Alert.JobNumber = parseInt(dataItem.JobNumber); }
//            me.Alert.JobComponentNumber = 0;
//            me.Alert.SprintID = 0
//            me.checkForBoard();
//            me.refreshJobComponents();
//            window.setTimeout(function () {
//                me.setDivisionProductAndComponent();
//            }, 10);

//            //if (me.Alert.ClientCode != "" || me.Alert.DivisionCode != "" || me.Alert.ProductCode != "") {
//            //    let filters = [], filter = {};
//            //    if (me.Alert.ClientCode != "") {
//            //        filters.push({ field: "ClientCode", operator: "eq", value: me.Alert.ClientCode });
//            //        if (me.Alert.DivisionCode != "") {
//            //            filters.push({ field: "DivisionCode", operator: "eq", value: me.Alert.DivisionCode });
//            //            if (me.Alert.ProductCode != "") {
//            //                filters.push({ field: "ProductCode", operator: "eq", value: me.Alert.ProductCode });
//            //            }
//            //        }
//            //    }
//            //    filter = {
//            //        logic: 'and',
//            //        filters: filters
//            //    };
//            //    //me.jobsDataSource.filter(filter);
//            //    //me.jobDropDownList.setDataSource(me.jobsDataSource);
//            //} else {
//            //    me.jobsDataSource.filter({});
//            //}
//            //me.setJobFilters();
//            ////if (me.Alert.ClientCode != "" || me.Alert.DivisionCode != "" || me.Alert.ProductCode != "") {
//            ////    //console.log("RELOAD FOR FILTER!!!")
//            ////    me.jobsDataSource = new kendo.data.DataSource({
//            ////        transport: {
//            ////            read: {
//            ////                url: 'Desktop/Alert/GetNewAssignmentJobList',
//            ////                data: function () {
//            ////                    return {
//            ////                        SprintID: ((me.Alert.SprintID && me.Alert.SprintID > 0) ? me.Alert.SprintID : 0),
//            ////                        OfficeCode: ((me.Alert.OfficeCode && me.Alert.OfficeCode != "") ? me.Alert.OfficeCode : ""),
//            ////                        ClientCode: ((me.Alert.ClientCode && me.Alert.ClientCode != "") ? me.Alert.ClientCode : ""),
//            ////                        DivisionCode: ((me.Alert.DivisionCode && me.Alert.DivisionCode != "") ? me.Alert.DivisionCode : ""),
//            ////                        ProductCode: ((me.Alert.ProductCode && me.Alert.ProductCode != "") ? me.Alert.ProductCode : "")
//            ////                    }
//            ////                }
//            ////            }
//            ////        }
//            ////    });
//            ////    me.jobsDataSource.fetch();
//            ////    me.jobDropDownList.setDataSource(me.jobsDataSource);
//            ////}
//        } else {
//            me.refreshJobComponents();
//        }
//        me.getSoftwareVersions();
//        me.refreshRecipients();
//        if (me.Alert.JobNumber && me.Alert.JobNumber > 0) {
//            //console.log("job number")
//        } else {
//            //console.log("no job number")
//            window.setTimeout(function () {
//                me.divisionDropDownList.enable(false);
//                me.productDropDownList.enable(false);
//                me.jobComponentDropDownList.enable(false);
//            }, 1000);
//            me.productDropDownList.enable(false);
//        }
//        //console.log("jobChanged", me.lastClicked);
//        //me.jobClicked = true;
//        //window.setTimeout(function () {
//        //    me.Alert.JobComponentNumber = 0;
//        //    me.Alert.TaskSequenceNumber = -1;
//        //    me.jobComponentDropDownList.value(null);
//        //}, 0);
//        //if (me.Alert.JobNumber && me.Alert.JobNumber > 0) {
//        //    var item = me.jobDropDownList.select();
//        //    var dataItem = <any>me.jobDropDownList.dataItem(item);
//        //    if (dataItem && me.Alert) {
//        //        window.setTimeout(function () {
//        //            me.Alert.OfficeCode = dataItem.OfficeCode;
//        //            me.Alert.OfficeName = dataItem.OfficeName;
//        //        }, 0);
//        //        window.setTimeout(function () {
//        //            me.Alert.ClientCode = dataItem.ClientCode;
//        //            me.Alert.ClientName = dataItem.ClientName;
//        //        }, 0);
//        //        window.setTimeout(function () {
//        //            me.Alert.DivisionCode = dataItem.DivisionCode;
//        //            me.Alert.DivisionName = dataItem.DivisionName;
//        //            //console.log("me.Alert.DivisionCode", me.Alert.DivisionCode);
//        //        }, 0);
//        //        window.setTimeout(function () {
//        //            me.Alert.ProductCode = dataItem.ProductCode;
//        //            me.Alert.ProductName = dataItem.ProductName;
//        //        }, 0);
//        //        window.setTimeout(function () {
//        //            //me.Alert.JobNumber = dataItem.JobNumber;
//        //            me.Alert.JobDescription = dataItem.JobDescription;
//        //        }, 0);
//        //        //console.log("jobChanged", dataItem.OfficeCode, me.Alert.OfficeCode);
//        //        //console.log("jobChanged", dataItem.ClientCode, me.Alert.ClientCode);
//        //        //console.log("jobChanged", dataItem.DivisionCode, me.Alert.DivisionCode);
//        //        //console.log("jobChanged", dataItem.ProductCode, me.Alert.ProductCode);
//        //        if (dataItem.DivisionCode !== me.Alert.DivisionCode || me.Alert.DivisionCode == undefined) {
//        //            me.Alert.DivisionCode = dataItem.DivisionCode;
//        //            window.setTimeout(function () {
//        //                //console.log("jobChanged refreshDivisions", me.lastClicked);
//        //                me.refreshDivisions(me.Alert.DivisionCode);
//        //            }, 500);
//        //        }
//        //    }
//        //    me.jobComponentDropDownList.enable(true);
//        //    window.setTimeout(function () {
//        //        me.refreshJobComponents();
//        //    }, 0);
//        //    window.setTimeout(function () {
//        //        me.getSoftwareVersions();
//        //    }, 10);
//        //} else {
//        //    me.checkForBoard();
//        //}
//        //me.refreshRecipients();
//        //me.checkForBoard();
//    }
//    jobOnOpen(e) {
//        let me = this;
//        me.lastClicked = "job";
//        me.jobClicked = true;
//    }

//    componentOnCascade(e) {
//        //console.log("componentOnCascade");
//        //this.jobComponentDropDownList.enable(true);
//    }
//    componentChanged(e) {
//        let me = this;
//        if (me.lastClicked == "" || me.lastClicked == "component") {
//            me.checkForSchedule();
//            me.getDefaultWorkflowTemplate();
//            if (me.jobComponentDropDownList) {
//                var item = me.jobComponentDropDownList.select();
//                var dataItem = <any>me.jobComponentDropDownList.dataItem(item);
//                if (dataItem && me.Alert) {
//                    //console.log("componentChanged dataItem", dataItem)
//                    //if (dataItem.OfficeCode) {
//                    //    me.Alert.OfficeCode = dataItem.OfficeCode;
//                    //}
//                    //if (dataItem.ClientCode) {
//                    //    me.Alert.ClientCode = dataItem.ClientCode;
//                    //}
//                    //if (dataItem.ClientName) {
//                    //    me.Alert.ClientName = dataItem.ClientName;
//                    //}
//                    //if (dataItem.DivisionCode) {
//                    //    me.Alert.DivisionCode = dataItem.DivisionCode;
//                    //}
//                    //if (dataItem.DivisionName) {
//                    //    me.Alert.DivisionName = dataItem.DivisionName;
//                    //}
//                    //if (dataItem.ProductCode) {
//                    //    me.Alert.ProductCode = dataItem.ProductCode;
//                    //}
//                    //if (dataItem.ProductName) {
//                    //    me.Alert.ProductName = dataItem.ProductName;
//                    //}
//                    //if (dataItem.JobNumber) {
//                    //    me.Alert.JobNumber = dataItem.JobNumber;
//                    //}
//                    //if (dataItem.JobDescription) {
//                    //    me.Alert.JobDescription = dataItem.JobDescription;
//                    //}
//                    //if (dataItem.JobComponentNumber) {
//                    //    me.Alert.JobComponentNumber = dataItem.JobComponentNumber;
//                    //}
//                    //if (dataItem.JobComponentDescription) {
//                    //    me.Alert.JobComponentDescription = dataItem.JobComponentDescription;
//                    //}
//                }
//            }
//            //me.refreshRecipients();
//            me.checkForBoard();
//        }

//    }
//    componentOnOpen(e) {
//        let me = this;
//        me.lastClicked = "component";
//        me.jobClicked = false;
//   }

//    taskOnCascade(e) {
//    }

//    filterClientDropDownList(officeCode: string) {

//    }
//    filterDivisionDropDownList(clientCode: string) {

//    }
//    filterProductDropDownList(clientCode: string, divisionCode: string) {

//    }
//    filterJobDropDownList(clientCode: string, divisionCode: string, productCode: string) {

//    }

//    alertAssignmentTemplateChange(e) {
//        if (this.alertAssignmentTemplateDropDownList) {
//            var item = this.alertAssignmentTemplateDropDownList.select();
//            var dataItem = <any>this.alertAssignmentTemplateDropDownList.dataItem(item);
//            if (dataItem && this.Alert) {
//                if (isNaN(dataItem.ID) === true) {
//                    this.Alert.AlertAssignmentTemplateID = null;
//                    this.Alert.AlertAssignmentTemplateName = "N/A";
//                    this.Alert.AlertStateID = null;
//                    this.Alert.AlertStateName = "N/A";
//                } else {
//                    this.Alert.AlertAssignmentTemplateName = dataItem.Name;
//                    this.Alert.AlertStateID = null;
//                    this.Alert.AlertStateName = "N/A";
//                }
//                this.setDefaultSubject("N/A");
//                //console.log("alertAssignmentTemplateChange", dataItem, this.Alert);
//            }
//        }
//    }
//    getDefaultWorkflowTemplate() {
//        if (this.defaultWorkflowTemplate.JobNumber !== this.Alert.JobNumber || this.defaultWorkflowTemplate.JobComponentNumber !== this.Alert.JobComponentNumber) {
//            if (this.Alert.JobNumber > 0 && this.Alert.JobComponentNumber > 0) {
//                this.defaultWorkflowTemplate.JobNumber = this.Alert.JobNumber;
//                this.defaultWorkflowTemplate.JobComponentNumber = this.Alert.JobComponentNumber;
//                this.service.getDefaultWorkflowTemplate(this.Alert.JobNumber, this.Alert.JobComponentNumber).then(response => {
//                    if (!isNaN(response.content)) {
//                        this.defaultWorkflowTemplate.AlertAssignmentTemplateID = Number(response.content);
//                        if (this.isRouted === true) {
//                            this.Alert.AlertAssignmentTemplateID = Number(response.content);
//                        }
//                    }
//                });
//            }
//        } else {
//            if (this.isRouted === true) {
//                this.Alert.AlertAssignmentTemplateID = this.defaultWorkflowTemplate.AlertAssignmentTemplateID;
//            } else {
//                this.Alert.AlertAssignmentTemplateID = null;
//            }
//        }
//    }
//    refreshTypes() {
//        if (this.alertCategoriesDropDownList) {
//            this.alertCategoriesDropDownList.refresh();
//        }
//    }
//    jobComponentNumberChanged(newValue, oldValue) {
//        this.checkTaskEnabled();
//        this.Alert.LinkedDocuments = [];
//        this.existingDocumentsDataSource.data([]);
//    }
//    checkTaskEnabled() {
//        this.taskFunctionEnabled = !this.excludeTasks && this.isBoardTask && this.Alert.JobNumber > 0 && this.Alert.JobComponentNumber > 0 ? true : false;
//    }
//    checkIsBoardTask() {
//        this.isBoardTask = this.Alert.AlertCategoryID === 71 ? true : false;
//    }
//    filterComponents() {
//        //this.componentsDataSource.filter({ field: "JobNumber", operator: "eq", value: this.Alert.JobNumber });
//    }
//    toolbarReady(e) {

//    }
//    alertTemplateStatesListboxChange() {
//        var canSelectEmployee = false;
//        if (this.alertTemplateStatesListBox) {
//            var item = this.alertTemplateStatesListBox.select();
//            var dataItem = <any>this.alertTemplateStatesListBox.dataItem(item);
//            //console.log("dataItem", dataItem)
//            if (dataItem) {
//                canSelectEmployee = true;
//                if (this.Alert.AlertStateID !== dataItem.ID) {
//                    this.Alert.AlertStateID = dataItem.ID;
//                    this.alertTemplateStateEmployeesDataSource.read().then(() => {
//                        var doesCurrentEmpExist = false;
//                        for (var i = 0; i < this.alertTemplateStateEmployeesDataSource.data().length; i++) {
//                            var emp = this.alertTemplateStateEmployeesDataSource.data()[i];
//                            if (emp.IsDefault === true) {
//                                this.Alert.AssignedEmployeeCode = emp.Code;
//                            }
//                            if (emp.Code === this.Alert.AssignedEmployeeCode) {
//                                doesCurrentEmpExist = true;
//                            }
//                        }
//                        if (!doesCurrentEmpExist) {
//                            this.Alert.AssignedEmployeeCode = '';
//                        }
//                    });
//                    this.setDefaultSubject(dataItem.Name);
//                }
//            } else {
//                this.Alert.AssignedEmployeeCode = '';
//            }
//        }
//        if (this.assignToDropDownList) {
//            this.assignToDropDownList.enabled = canSelectEmployee;
//            //console.log("assigned to", this.Alert.AlertAssignmentTemplateID, this.Alert.AlertStateID, this.Alert.AssignedEmployeeCode)
//            if (canSelectEmployee == false) {
//                if ((isNaN(this.Alert.AlertAssignmentTemplateID) == true || this.Alert.AlertAssignmentTemplateID == 0) && (isNaN(this.Alert.AlertStateID) == true || this.Alert.AlertStateID == 0)) {
//                    this.Alert.AssignedEmployeeCode = '';
//                }
//            }
//        }
//    }
//    setDefaultSubject(newState) {
//        //console.log("setDefaultSubject", newState, this.Alert)
//        if (this.Alert) {
//            if (this.Alert.AlertAssignmentTemplateName === "[Please Select]") {
//                this.Alert.AlertAssignmentTemplateName = "N/A";
//            }
//            var defaultSubject = "";
//            if (this.defaultSubjectType == "state") {
//                defaultSubject = newState;
//            } else if (this.defaultSubjectType === "template") {
//                defaultSubject = this.Alert.AlertAssignmentTemplateName;
//            } else if (this.defaultSubjectType === "templateandstate") {
//                defaultSubject = this.Alert.AlertAssignmentTemplateName + " | " + newState;
//            } else if (this.defaultSubjectType === "jjcts") {
//                defaultSubject = "[";
//                if (this.Alert.JobNumber && this.Alert.JobNumber > 0 && this.Alert.JobComponentNumber && this.Alert.JobComponentNumber > 0) {
//                    defaultSubject += this.padJobNumber(this.Alert.JobNumber);
//                    defaultSubject += "/";
//                    defaultSubject += this.padJobComponentNumber(this.Alert.JobComponentNumber);
//                    defaultSubject += " - ";
//                    defaultSubject += this.Alert.JobComponentDescription;
//                    defaultSubject += " | ";
//                }
//                defaultSubject += this.Alert.AlertAssignmentTemplateName + " | " + newState;
//                defaultSubject += "]";
//            }
//            if (defaultSubject != "") {
//                this.Alert.Subject = defaultSubject;
//            }
//            //console.log("alert subject", this.Alert.Subject)
//        }
//    }
//    alertCategoriesDataBound(e) {
//        var sender: kendo.ui.DropDownList = e.sender;
//        this.checkAlertCategories(sender);
//    }
//    checkAlertCategories(alertTypeDropDownList) {
//        // 70 is story, 71 is task
//        let me = this;
//        if (alertTypeDropDownList) {
//            for (var i = 0; i < alertTypeDropDownList.items().length; i++) {
//                var item = $(alertTypeDropDownList.items()[i]);
//                var dataItem = alertTypeDropDownList.dataItem(item);
                
//                //if (!this.Alert.SprintID || this.Alert.SprintID <= 0) {
//                //    if (dataItem.ID === 70 || dataItem.ID === 71) {
//                //        alertTypeDropDownList.dataSource.remove(dataItem);
//                //    }
//                //} else {
//                if (dataItem.ID === 71) {
//                    if (this.excludeTasks === true) {
//                        alertTypeDropDownList.dataSource.remove(dataItem);
//                    }
//                    if ((Number(this.jobDropDownList.value()) > 0 && Number(this.jobComponentDropDownList.value()) > 0 && !this.Alert.HasSchedule) || this.isRouted === true) {
//                        $(item).hide();
//                        if (this.Alert.AlertCategoryID === 71) {
//                            this.Alert.AlertCategoryID = null;
//                            this.checkIsBoardTask()
//                        }
//                    } else {
//                        $(item).show();
//                    }
//                }
//                //}


//            }
//        }
//    }
//    attachmentUploadSuccess(e) {
//        if (!this.Alert.UploadedFiles) {
//            this.Alert.UploadedFiles = [];
//        }
//        if (e.operation == 'upload') {
//            this.Alert.UploadedFiles.push(e.files[0].name);
//        } else {
//            var idx = this.Alert.UploadedFiles.indexOf(e.files[0].name);
//            if (idx > -1) {
//                this.Alert.UploadedFiles.splice(idx, 1);
//            }
//        }
//    }
//    attachmentUploadError(e) {
//        if (e.operation == 'upload') {
//            if (e.XMLHttpRequest.responseText) {
//                this.alert(JSON.parse(e.XMLHttpRequest.responseText));
//            }
//        }
//    }
//    alertCategoryChanged(e) {
//        var item = this.alertCategoriesDropDownList.dataItem(this.alertCategoriesDropDownList.select());
//        var alertTypeID: number = null;
//        if (item) {
//            alertTypeID = item.AlertTypeID;
//        }
//        this.Alert.AlertTypeID = alertTypeID;
//        this.checkIsBoardTask();
//    }
//    descriptionReady(e) {
//        var editor: kendo.ui.Editor = e;
//        editor.wrapper.find("a,span, input").attr("tabindex", -1);
//    }
//    boardDataBound(e) {

//    }
//    boardStateDataBound(e: any) {
//        var dropDownList = <kendo.ui.DropDownList>e.sender;
//        if (dropDownList) {
//            if (!this.Alert.BoardStateID) {
//                dropDownList.value('-1');
//            }
//        }
//    }
//    getLinkableDocuments() {
//        this.setAlertLevel();
//        this.existingDocumentsDataSource.filter({ field: 'Linked', value: true, operator: 'neq' });
//        if (this.existingDocumentsDataSource.data().length === 0) {
//            this.service.getLinkableDocuments(this.Alert).then(response => {
//                if (response.content && response.content !== '') {
//                    this.existingDocumentsDataSource.data(response.content);
//                }
//            }).then(() => {
//                this.existingDocumentsGrid.setDataSource(this.existingDocumentsDataSource);
//                this.existingDocumentDialog.open();
//            });
//        } else {
//            this.existingDocumentDialog.open();
//        }
//    }
//    linkExistingDocumentClick() {
//        this.getLinkableDocuments();
//    }
//    linkExistingDocumentSaveClick() {
//        if (!this.linkableDocuments) {
//            this.linkableDocuments = [];
//        }
//        var items = this.existingDocumentsGrid.select();
//        if (items.length > 0) {
//            for (var i = 0; i < items.length; i++) {
//                var dataItem = <any>this.existingDocumentsGrid.dataItem(items[i]);
//                dataItem.Linked = true;
//                this.linkableDocuments.push(dataItem);
//            }
//        }
//    }
//    unlinkDoc(doc) {
//        var idx = this.linkableDocuments.indexOf(doc);
//        doc.Linked = false;
//        this.linkableDocuments.splice(idx, 1);
//        for (var i = 0; i < this.existingDocumentsGrid.items().length; i++) {
//            var item: any = this.existingDocumentsGrid.items()[i];
//            var dataItem: any = this.existingDocumentsGrid.dataItem(item);
//            if (dataItem.ID === doc.ID) {
//                $(item).removeClass('k-state-selected');
//            }
//        }
//    }
//    existingDocumentDialogOpen(e) {

//        if (this.existingDocumentsGrid.dataSource.view().length === 0) {
//            this.existingDocumentsGrid.element.hide();
//            $('#noLinkableDocs').show();
//        } else {
//            this.existingDocumentsGrid.element.show();
//            $('#noLinkableDocs').hide();
//        }
//    }
//    startDateChange() {
//        var val: any = this.startDatePicker.value();
//        if (!val) {
//            if (this.startDatePicker) {
//                val = this.startDatePicker.element.val();
//                if (val) {
//                    var date: any = this.parseShortDate(val);
//                    if (date && date.isValid) {
//                        //timeout gives bindings time to finish
//                        let me = this;
//                        window.setTimeout(function () {
//                            me.Alert.StartDate = date.value;
//                            me.setupStartDate();
//                        }, 0);
//                    }
//                }
//            }
//        }
//        if (this.dueDateIsBeforeStartDate(this.Alert.StartDate, this.Alert.DueDate) === true) {
//            this.alert("Due date before start date.")
//        }
//        this.setupStartDate();
//    }
//    dueDateChange() {
//        var val: any = this.dueDatePicker.value();
//        if (!val) {
//            if (this.dueDatePicker) {
//                val = this.dueDatePicker.element.val();
//                if (val) {
//                    var date: any = this.parseShortDate(val);
//                    if (date && date.isValid) {
//                        //timeout gives bindings time to finish
//                        let me = this;
//                        window.setTimeout(function () {
//                            me.Alert.DueDate = date.value;
//                            me.setupDueDate();
//                        }, 0);
//                    }
//                }
//            }
//        }
//        if (this.dueDateIsBeforeStartDate(this.Alert.StartDate, this.Alert.DueDate) === true) {
//            this.alert("Due date before start date.")
//        }
//        this.setupDueDate();
//    }
//    setupDueDate() {
//        var tooltip = this.getToolTipForDueDate(this.Alert.DueDate);
//        this.getCssForDatePicker(this.Alert.DueDate, 'due');
//        this.dueDateTitle = tooltip;
//    }
//    setupStartDate() {
//        var tooltip = this.getToolTipForDueDate(this.Alert.StartDate);
//        this.getCssForDatePicker(this.Alert.StartDate, 'start');
//        this.startDateTitle = tooltip;
//    }
//    getToolTipForDueDate(theDate) {
//        var tooltip = '';
//        if (theDate) {
//            var today = new Date(new Date().toLocaleDateString());
//            var weekends = [0, 6];
//            var weekOut = new Date();
//            weekOut = new Date(weekOut.setDate(weekOut.getDate() + 8));
//            theDate = new Date(new Date(theDate).toLocaleDateString());
//            if (theDate < today) {
//                tooltip = 'Overdue!';
//            } else if (theDate.valueOf() === today.valueOf()) {
//                tooltip = 'Due today!';
//            } else if (weekends.indexOf(theDate.getDay()) > -1) {
//                tooltip = 'Due date is on a weekend!';
//            } else if (theDate > today && theDate < weekOut) {
//                tooltip = 'Due in a week!';
//            }
//        }
//        return tooltip;
//    }
//    getCssForDatePicker(theDate, startOrDue) {
//        var cssClass = '';
//        if (theDate) {
//            var today = new Date(new Date().toLocaleDateString());
//            var weekends = [0, 6];
//            var weekOut = new Date();
//            weekOut = new Date(weekOut.setDate(weekOut.getDate() + 8));
//            theDate = new Date(new Date(theDate).toLocaleDateString());
//            if (theDate < today) {
//                cssClass = 'standard-red';
//            } else if (theDate.valueOf() === today.valueOf()) {
//                cssClass = 'standard-orange';
//            } else if (weekends.indexOf(theDate.getDay()) > -1) {
//                cssClass = 'standard-light-grey';
//            } else if (theDate > today && theDate < weekOut) {
//                cssClass = 'standard-yellow';
//            }
//        }
//        if (startOrDue == 'due') {
//            this.dueDateCssName = cssClass;
//        } else {
//            this.startDateCssName = cssClass;
//        }
//        return cssClass;
//    }
//    datePickerOnReady(e) {
//        $(e.wrapper).removeClass('standard-red').removeClass('standard-orange').removeClass('standard-light-grey').removeClass('standard-yellow');
//    }

//    getSoftwareBuilds() {
//        if (this.Alert.Version !== '') {
//            let me = this;
//            this.buildDataSource = new kendo.data.DataSource({
//                transport: {
//                    read: {
//                        url: 'Desktop/Alert/GetSoftwareBuildsByVersion',
//                        data: function () {
//                            return {
//                                VersionID: me.Alert.Version && me.Alert.Version !== '' ? me.Alert.Version : 0
//                            }
//                        }
//                    }
//                }
//            });
//        } else {
//            this.buildDataSource = new kendo.data.DataSource({
//                data: []
//            });
//        }
//        if (this.buildDropDownList) {
//            this.buildDropDownList.setDataSource(this.buildDataSource);
//        }
//    }
//    getSoftwareVersions() {
//        if (this.softwareVersionLastSearched.JobNumber !== this.Alert.JobNumber || this.softwareVersionLastSearched.JobComponentNumber !== this.Alert.JobComponentNumber) {
//            this.versionDataSource.read();
//        }
//    }
//    versionChanged() {
//        if (!this.Alert.Version || this.Alert.Version === '') {
//            this.Alert.Build = '';
//        }
//        this.checkBuildEnabled();
//        this.getSoftwareBuilds();
//    }
//    checkBuildEnabled() {
//        this.buildEnabled = this.Alert.Version && this.Alert.Version !== '' ? true : false;
//    }
//    getDefaultSubjectType() {
//        let me = this;
//        return this.service.getDefaultSubjectType().then(response => {
//            if (response.content) {
//                me.defaultSubjectType = response.content
//            }
//        }).then(() => {
//        });
//    }

//    refreshClients() {
//        console.log("refreshClients");
//        let me = this;
//        if (me.Alert) {
//            this.clientsDataSource = new kendo.data.DataSource({
//                transport: {
//                    read: {
//                        url: 'Desktop/Alert/GetNewAssignmentClientList',
//                        data: function () {
//                            return {
//                                SprintID: ((me.Alert.SprintID && me.Alert.SprintID > 0) ? me.Alert.SprintID : 0),
//                                OfficeCode: ((me.Alert.OfficeCode && me.Alert.OfficeCode != "") ? me.Alert.OfficeCode : "")
//                            }
//                        }
//                    }
//                },
//                change: function () {
//                    var data = this.data();
//                    if (data && data.length == 1) {
//                        me.Alert.ClientCode = data[0].ClientCode;
//                        me.Alert.ClientName = data[0].ClientName;
//                        if (me.clientDropDownList) {
//                            me.clientDropDownList.value(me.Alert.ClientCode);
//                            me.clientDropDownList.text(me.Alert.ClientName);
//                        }
//                        //me.refreshDivisions("");
//                    }
//                },
//                requestEnd: function (e) {
//                    var response = e.response;
//                    var type = e.type;
//                }
//            });
//        } else {
//            this.clientsDataSource = new kendo.data.DataSource({
//                data: []
//            });
//        }
//        if (this.clientDropDownList) {
//            this.clientDropDownList.setDataSource(this.clientsDataSource);
//        }
//    }
//    refreshDivisions() {
//        let me = this;
//        console.log("refreshDivisions:me.Alert.ClientCode", me.Alert.ClientCode);
//        if (me.Alert && me.Alert.ClientCode && me.Alert.ClientCode != "") {
//            me.divisionsDataSource = new kendo.data.DataSource({
//                transport: {
//                    read: {
//                        url: 'Desktop/Alert/GetNewAssignmentDivisionList',
//                        data: function () {
//                            return {
//                                SprintID: ((me.Alert.SprintID && me.Alert.SprintID > 0) ? me.Alert.SprintID : 0),
//                                OfficeCode: ((me.Alert.OfficeCode && me.Alert.OfficeCode != "") ? me.Alert.OfficeCode : ""),
//                                ClientCode: ((me.Alert.ClientCode && me.Alert.ClientCode != "") ? me.Alert.ClientCode : "")
//                            }
//                        }
//                    }
//                },
//                change: function () {
//                    var data = this.data();
//                    if (data && data.length == 1) {
//                        if (me.Alert.DivisionCode != data[0].DivisionCode) {
//                            me.Alert.DivisionCode = data[0].DivisionCode;
//                            me.Alert.DivisionName = data[0].DivisionName;
//                            if (me.divisionDropDownList) {
//                                me.divisionDropDownList.value(me.Alert.DivisionCode);
//                                me.divisionDropDownList.text(me.Alert.DivisionName);
//                            }
//                        }
//                        me.refreshProducts();
//                    }
//                    me.divisionDropDownList.enable(true);
//                },
//                requestEnd: function (e) {
//                    var response = e.response;
//                    var type = e.type;
//                }
//            });
//        } else {
//            me.divisionsDataSource = new kendo.data.DataSource({
//                data: []
//            });
//        }
//        if (me.divisionDropDownList) {
//            me.divisionDropDownList.setDataSource(me.divisionsDataSource);
//            me.divisionDropDownList.value(me.Alert.DivisionCode);
//        }
//    }
//    refreshProducts() {
//        let me = this;
//        console.log("refreshProducts", me.Alert.ClientCode, me.Alert.DivisionCode, me.Alert.DivisionCode)
//        if (me.Alert && me.Alert.ClientCode && me.Alert.ClientCode != "" && me.Alert.DivisionCode && me.Alert.DivisionCode != "") {
//            me.productsDataSource = new kendo.data.DataSource({
//                transport: {
//                    read: {
//                        url: 'Desktop/Alert/GetNewAssignmentProductList',
//                        data: function () {
//                            return {
//                                SprintID: ((me.Alert.SprintID && me.Alert.SprintID > 0) ? me.Alert.SprintID : 0),
//                                OfficeCode: ((me.Alert.OfficeCode && me.Alert.OfficeCode != "") ? me.Alert.OfficeCode : ""),
//                                ClientCode: ((me.Alert.ClientCode && me.Alert.ClientCode != "") ? me.Alert.ClientCode : ""),
//                                DivisionCode: ((me.Alert.ClientCode && me.Alert.DivisionCode != "") ? me.Alert.DivisionCode : "")
//                            }
//                        }
//                    }
//                },
//                change: function () {
//                    var data = this.data();
//                    if (data && data.length == 1) {
//                        if (me.Alert.ProductCode != data[0].ProductCode) {
//                            me.Alert.ProductCode = data[0].ProductCode;
//                            me.Alert.ProductName = data[0].ProductName;
//                            if (me.productDropDownList) {
//                                me.productDropDownList.value(me.Alert.ProductCode);
//                                me.productDropDownList.text(me.Alert.ProductName);
//                            }
//                        }
//                    }
//                    me.productDropDownList.enable(true);
//                },
//                requestEnd: function (e) {
//                    var response = e.response;
//                    var type = e.type;
//                }
//            });
//        } else {
//            me.productsDataSource = new kendo.data.DataSource({
//                data: []
//            });
//        }
//        if (me.productDropDownList) {
//            me.productDropDownList.setDataSource(me.productsDataSource);
//            if (me.Alert.ProductCode !== "" || me.Alert.ProductCode != undefined) {
//                me.productDropDownList.value(me.Alert.ProductCode);
//                me.productDropDownList.enable(true);
//                window.setTimeout(function () {
//                    me.refreshJobs();
//                }, 100);
//            }
//        }
//    }
//    refreshJobs() {
//        let me = this;
//        console.log("refreshJobs", me.Alert.ClientCode, me.Alert.DivisionCode, me.Alert.ProductCode);
//        if (me.Alert) {
//            me.jobsDataSource = new kendo.data.DataSource({
//                transport: {
//                    read: {
//                        url: 'Desktop/Alert/GetNewAssignmentJobList',
//                        data: function () {
//                            return {
//                                SprintID: ((me.Alert.SprintID && me.Alert.SprintID > 0) ? me.Alert.SprintID : 0),
//                                OfficeCode: ((me.Alert.OfficeCode && me.Alert.OfficeCode != "") ? me.Alert.OfficeCode : ""),
//                                ClientCode: ((me.Alert.ClientCode && me.Alert.ClientCode != "") ? me.Alert.ClientCode : ""),
//                                DivisionCode: ((me.Alert.DivisionCode && me.Alert.DivisionCode != "") ? me.Alert.DivisionCode : ""),
//                                ProductCode: ((me.Alert.ProductCode && me.Alert.ProductCode != "") ? me.Alert.ProductCode : "")
//                            }
//                        }
//                    }
//                },
//                change: function () {
//                    var data = this.data();
//                    if (data && data.length == 1) {
//                        me.Alert.JobNumber = data[0].JobNumber;
//                        me.Alert.JobDescription = data[0].JobDescription;
//                        if (me.jobDropDownList) {
//                            var jobString: any = me.Alert.JobNumber.toString;
//                            me.jobDropDownList.value(jobString);
//                            me.jobDropDownList.text(me.Alert.JobDescription);
//                        }
//                        me.refreshJobComponents();
//                    }
//                },
//                requestEnd: function (e) {
//                    var response = e.response;
//                    var type = e.type;
//                }
//            });
//        } else {
//            me.jobsDataSource = new kendo.data.DataSource({
//                data: []
//            });
//        }
//        if (me.jobDropDownList) {
//            me.jobDropDownList.setDataSource(me.jobsDataSource);
//        }
//    }
//    refreshJobComponents() {
//        console.log("refreshJobComponents");
//        let me = this;
//        if (me.Alert && me.Alert.JobNumber && me.Alert.JobNumber > 0) {
//            me.componentsDataSource = new kendo.data.DataSource({
//                transport: {
//                    read: {
//                        url: 'Desktop/Alert/GetNewAssignmentComponentList',
//                        data: function () {
//                            return {
//                                SprintID: ((me.Alert.SprintID && me.Alert.SprintID > 0) ? me.Alert.SprintID : 0),
//                                JobNumber: ((me.Alert.JobNumber && me.Alert.JobNumber > 0) ? me.Alert.JobNumber : 0)
//                            }
//                        }
//                    }
//                },
//                change: function () {
//                    var data = this.data();
//                    if (data && data.length == 1) {
//                        me.Alert.JobComponentNumber = data[0].JobComponentNumber * 1;
//                        me.Alert.JobComponentDescription = data[0].JobComponentDescription;
//                        me.getDefaultWorkflowTemplate();
//                        if (me.jobComponentDropDownList) {
//                            try {
//                                var jobComponentString: any = me.Alert.JobComponentNumber.toString;
//                                me.jobComponentDropDownList.value(jobComponentString);
//                                me.jobComponentDropDownList.text(me.Alert.JobComponentDescription);
//                                me.jobComponentDropDownList.select(1);
//                            } catch (e) {
//                            }
//                        }
//                        me.checkForBoard();
//                        //me.refreshJobComponents();
//                    }
//                },
//                requestEnd: function (e) {
//                    var response = e.response;
//                    var type = e.type;
//                    if (type == "read" && response) {
//                        if (response.length == 1) {
//                            me.Alert.JobComponentNumber = parseInt(response[0].JobComponentNumber);
//                            me.getDefaultWorkflowTemplate();
//                        }
//                        me.jobComponentDropDownList.enable(true);
//                    }
//                }
//            });
//        } else {
//            me.componentsDataSource = new kendo.data.DataSource({
//                data: []
//            });
//        }
//        if (me.jobComponentDropDownList) {
//            me.jobComponentDropDownList.setDataSource(me.componentsDataSource);
//            me.jobComponentDropDownList.enable(true);
//        }
//    }
//    refreshRecipients() {
//        //console.log("refreshRecipients");
//        let me = this;
//        if (me.Alert) {
//            this.alertRecipientDataSource = new kendo.data.DataSource({
//                transport: {
//                    read: {
//                        url: 'Desktop/Alert/GetAlertRecipientsLookup',
//                        data: function () {
//                            return {
//                                c: ((me.Alert.ClientCode && me.Alert.ClientCode != "") ? me.Alert.ClientCode : ""),
//                                d: ((me.Alert.DivisionCode && me.Alert.DivisionCode != "") ? me.Alert.DivisionCode : ""),
//                                p: ((me.Alert.ProductCode && me.Alert.ProductCode != "") ? me.Alert.ProductCode : ""),
//                                j: ((me.Alert.JobNumber && me.Alert.JobNumber > 0) ? me.Alert.JobNumber : 0),
//                                jc: ((me.Alert.JobComponentNumber && me.Alert.JobComponentNumber > 0) ? me.Alert.JobComponentNumber : 0),
//                                a: ((me.Alert.ID && me.Alert.ID > 0) ? me.Alert.ID : 0)
//                            }
//                        }
//                    }
//                }
//            });
//        }
//    }
//    setDefaultDropDownEnabled() {
//        console.log("setDefaultDropDownEnabled");
//        let me = this;
//        if (me.divisionDropDownList) {
//            me.divisionDropDownList.enable(false);
//        }
//        if (me.productDropDownList) {
//            me.productDropDownList.enable(false);
//        }
//        if (me.jobComponentDropDownList) {
//            me.jobComponentDropDownList.enable(false);
//       }
//    }
//    initSettings(response: any, paramClientCode: string, paramClientName: string, paramJobComponentNumber: number) {
//        let me = this;
//        try {
//            if (response) {
//                if (response.RepositoryLimitText) {
//                    me.repositoryLimitText = response.RepositoryLimitText;
//                }
//                if (response.AllowUpload) {
//                    me.allowUpload = response.AllowUpload;
//                }
//                if (response.ExcludeTasks) {
//                    me.excludeTasks = response.ExcludeTasks;
//                }
//                if (response.DefaultSubject) {
//                    me.Alert.Subject = response.DefaultSubject;
//               }
//            }
//        } catch (e) {
//        }
//        //console.log("initSettings");
//        me.setDefaultsFromSprintJob();
//    }
//    setDefaultsFromSprintJob() {
//        let me = this;
//        me.activated = true;
//        if (me.Alert.JobNumber && me.Alert.JobNumber > 0) {
//            this.service.getNewAssignmentInfoFromJob(me.Alert.JobNumber).then(response => {
//                if (response && response.content) {
//                    window.setTimeout(function (e) {
//                        me.Alert.OfficeCode = response.content.OfficeCode;
//                        me.Alert.OfficeName = response.content.OfficeName;
//                        me.Alert.ClientCode = response.content.ClientCode;
//                        me.Alert.ClientName = response.content.ClientName;
//                        me.Alert.DivisionCode = response.content.DivisionCode;
//                        me.Alert.DivisionName = response.content.DivisionName;
//                        me.Alert.ProductCode = response.content.ProductCode;
//                        me.Alert.ProductName = response.content.ProductName;
//                        me.Alert.JobDescription = response.content.JobDescription;
//                    }, 100);
//                    //window.setTimeout(function (e) {
//                        try {
//                            me.fromPreset = true;
//                            me.lastClicked = "fromPreset";
//                            me.setDivisionProductAndComponent();
//                            me.checkForBoard();
//                        } catch (e) {
//                        }
//                    //}, 100);
//                }
//            });
//        }
//    }
//    setDivisionProductAndComponent() {
//        let me = this;
//        console.log("setDivisionProductAndComponent", me.Alert);
//        me.divisionDropDownList.enable(true);
//        me.divisionDropDownList.value(me.Alert.DivisionCode);
//        //me.divisionDropDownList.text(me.Alert.DivisionName);
//        me.productDropDownList.enable(true);
//        me.productDropDownList.value(me.Alert.ProductCode);
//        //me.productDropDownList.text(me.Alert.ProductName);
//        me.jobComponentDropDownList.enable(true);
//        me.jobComponentDropDownList.value(me.Alert.JobComponentNumber.toString())
//    }
//    lastRecipientClientCode: string = "";
//    lastRecipientJobNumber: number = 0;

//    attached() {
//        //console.log("attached")
//        let me = this;
//        $(document).ready(function () {
//            me.clientDropDownList.focus();
//            me.attachmentUpload.wrapper.find('.k-dropzone .k-button').css('margin-right', '5px').after(me.existingDocumentButton);
//            me.officeDropDownList.wrapper.keypress(function (e) {
//                me.officeDropDownList.open();
//                me.officeDropDownList.filterInput.val(me.officeDropDownList.filterInput.val() + e.key);
//            });
//            me.clientDropDownList.wrapper.keypress(function (e) {
//                me.clientDropDownList.open();
//                me.clientDropDownList.filterInput.val(me.clientDropDownList.filterInput.val() + e.key);
//            });
//            me.divisionDropDownList.wrapper.keypress(function (e) {
//                me.divisionDropDownList.open();
//                me.divisionDropDownList.filterInput.val(me.divisionDropDownList.filterInput.val() + e.key);
//            });
//            me.productDropDownList.wrapper.keypress(function (e) {
//                me.productDropDownList.open();
//                me.productDropDownList.filterInput.val(me.productDropDownList.filterInput.val() + e.key);
//            });
//            me.jobDropDownList.wrapper.keypress(function (e) {
//                me.jobDropDownList.open();
//                me.jobDropDownList.filterInput.val(me.jobDropDownList.filterInput.val() + e.key);
//            });
//            me.jobComponentDropDownList.wrapper.keypress(function (e) {
//                me.jobComponentDropDownList.open();
//                me.jobComponentDropDownList.filterInput.val(me.jobComponentDropDownList.filterInput.val() + e.key);
//            });
//            try {
//                me.startDatePicker.element.change(function (e) {
//                    me.startDateChange();
//                });
//            } catch (e) {
//                //console.log("ERROR", e);
//            }
//            try {
//                me.dueDatePicker.element.change(function (e) {
//                    me.dueDateChange();
//                });
//            } catch (e) {
//                //console.log("ERROR", e);
//            }
//        });
//        this.disposables = new Array<Disposable>();
//        var alertAssignmentTemplateIDDisposable = this.bindingEngine.propertyObserver(this.Alert, 'AlertAssignmentTemplateID').subscribe((newValue, oldValue) => {
//            this.alertAssignmentTemplateIDChanged(newValue, oldValue);
//        });
//        var alertStateIDDisposable = this.bindingEngine.propertyObserver(this.Alert, 'AlertStateID').subscribe((newValue, oldValue) => {
//            this.alertStateIDChanged(newValue, oldValue);
//        });
//        this.disposables.push(alertAssignmentTemplateIDDisposable);
//        this.disposables.push(alertStateIDDisposable);
//        this.getDefaultSubjectType();
//    }
//    detached() {
//        if (this.disposables && this.disposables.length > 0) {
//            for (var i = 0; i < this.disposables.length; i++) {
//                this.disposables[i].dispose();
//            }
//        }
//    }
//    activate(params: any) {
//        let me = this;
//        var paramClientCode = null;
//        var paramClientName = null;
//        var paramJobComponentNumber = null;
//        if (params.ContentPage == "1") {
//            me.contentpage = "1"
//        }
//        if (params.SprintID && isNaN(params.SprintID) == false && params.SprintID > 0) {
//            me.Alert.SprintID = params.SprintID;
//        }
//        if (params.BoardStateID && isNaN(params.BoardStateID) == false && params.BoardStateID > 0) {
//            me.Alert.BoardStateID = params.BoardStateID;
//        }
//        if (params.JobNumber && isNaN(params.JobNumber) == false && params.JobNumber > 0) {
//            me.Alert.JobNumber = params.JobNumber;
//        }
//        if (params.JobComponentNumber && isNaN(params.JobComponentNumber) == false && params.JobComponentNumber > 0) {
//            me.Alert.JobComponentNumber = params.JobComponentNumber;
//            paramJobComponentNumber = params.JobComponentNumber;
//            me.getDefaultWorkflowTemplate();
//        }
//        if (params.BoardID && isNaN(params.BoardID) == false && params.BoardID > 0) {
//            me.Alert.BoardID = params.BoardID;
//        }
//        if (params.BoardHeaderID && isNaN(params.BoardHeaderID) == false && params.BoardHeaderID > 0) {
//            me.Alert.BoardHeaderID = params.BoardHeaderID;
//        }
//        if (params.ClientCode && params.ClientCode.trim() != '') {
//            paramClientCode = params.ClientCode;
//        }
//        //  Let server querystring class override
//        if (params.sprhid && isNaN(params.sprhid) == false && params.sprhid > 0) {
//            me.Alert.SprintID = params.sprhid;
//        }
//        if (params.brdstid && isNaN(params.brdstid) == false && params.brdstid > 0) {
//            me.Alert.BoardStateID = params.brdstid;
//        }
//        if (params.j && isNaN(params.j) == false && parseInt(params.j) > 0) {
//            me.Alert.JobNumber = parseInt(params.j);
//        }
//        if (params.jc && isNaN(params.jc) == false && params.jc > 0) {
//            me.Alert.JobComponentNumber = params.jc;
//            paramJobComponentNumber = params.jc;
//            me.getDefaultWorkflowTemplate();
//        }
//        if (params.brdid && isNaN(params.brdid) == false && params.brdid > 0) {
//            me.Alert.BoardID = params.brdid;
//        }
//        if (params.brdhid && isNaN(params.brdhid) == false && params.brdhid > 0) {
//            me.Alert.BoardHeaderID = params.brdhid;
//        }
//        if (params.c && params.c.trim() != '') {
//            paramClientCode = params.c;
//        }
//        if (me.Alert.JobNumber == undefined && me.Alert.JobComponentNumber == undefined) {
//            window.setTimeout(function () {
//                me.setDefaultDropDownEnabled();
//            }, 500);
//        }
//        if (params.caller && params.caller.trim() != '') {
//            me.callingPage = params.caller;
//            me.Alert.CallingPage = me.callingPage;
//        }
//        if (me.Alert.SprintID && me.Alert.SprintID > 0) {
//           me.service.getSprintSetup(me.Alert.SprintID).then(response => {
//                me.initSettings(response, paramClientCode, paramClientName, paramJobComponentNumber);
//            });
//        } else {
//            me.service.initNewAssignment(me.callingPage).then(response => {
//                me.initSettings(response, paramClientCode, paramClientName, paramJobComponentNumber);
//            });
//        }

//        me.Alert.JobComponentNumber = 0;
//    }
//    constructor(service: AlertService, bindingEngine: BindingEngine, webvantage: Webvantage, dashboard: Dashboard) {
//        super();
//        this.bindingEngine = bindingEngine;
//        this.Alert = new AlertModel;
//        this.Alert.PriorityLevel = 3;
//        this.Alert.AlertCategoryID = 25;
//        this.Alert.AlertTypeID = 6;
//        this.service = service;
//        let me = this;
//        this.webvantage = webvantage;
//        this.dashboard = dashboard;

//        this.officeDataSource = new kendo.data.DataSource();
//        this.clientsDataSource = new kendo.data.DataSource();
//        this.divisionsDataSource = new kendo.data.DataSource();
//        this.productsDataSource = new kendo.data.DataSource();
//        this.jobsDataSource = new kendo.data.DataSource();
//        this.componentsDataSource = new kendo.data.DataSource();
//        this.boardDataSource = new kendo.data.DataSource();
//        this.sprintDataSource = new kendo.data.DataSource();

//        this.alertTemplatesDataSource = service.getAlertTemplatesDataSource();
//        this.alertTemplateStatesDataSource = new kendo.data.DataSource({
//            transport: {
//                read: {
//                    url: 'Desktop/Alert/GetAlertTemplateStates',
//                    data: function () {
//                        return {
//                            AlertTemplateID: ((me.Alert.AlertAssignmentTemplateID && me.Alert.AlertAssignmentTemplateID > 0) ? me.Alert.AlertAssignmentTemplateID : 0)
//                        }
//                    }
//                }
//            },
//            requestStart: function (e) {
//                if (e.type === "read") {
//                    if (!me.Alert.AlertAssignmentTemplateID) {
//                        e.sender.data([]);
//                        e.preventDefault();
//                    }
//                }
//            }
//        });
//        this.alertTemplateStateEmployeesDataSource = service.getAlertTemplateStateEmployeesDataSource({
//            transport: {
//                read: {
//                    data: function () {
//                        return {
//                            AlertID: ((me.Alert.ID && me.Alert.ID > 0) ? me.Alert.ID : 0),
//                            AlertTemplateID: ((me.Alert.AlertAssignmentTemplateID && me.Alert.AlertAssignmentTemplateID > 0) ? me.Alert.AlertAssignmentTemplateID : 0),
//                            AlertStateID: ((me.Alert.AlertStateID && me.Alert.AlertStateID > 0) ? me.Alert.AlertStateID : 0),
//                            ShowAll: me.showAllEmployees ? me.showAllEmployees : false
//                        }
//                    }
//                }
//            },
//            requestStart: function (e) {
//                if (e.type === "read") {
//                    if (!me.Alert.AlertAssignmentTemplateID || me.Alert.AlertAssignmentTemplateID == 0 || !me.Alert.AlertStateID || me.Alert.AlertStateID == 0) {
//                        e.sender.data([]);
//                        e.preventDefault();
//                    }
//                }
//            }
//        });
//        this.alertCategoriesDataSource = service.getAlertCategoriesDataSource();
//        this.officeDataSource = service.getNewAssignmentOfficeList({
//            transport: {
//                read: {
//                    data: function () {
//                        return {
//                            SprintID: ((me.Alert.SprintID && me.Alert.SprintID > 0) ? me.Alert.SprintID : 0)
//                        }
//                    }
//                }
//            }
//        });
//        this.clientsDataSource = service.getNewAssignmentClientList({
//            transport: {
//                read: {
//                    data: function () {
//                        return {
//                            SprintID: ((me.Alert.SprintID && me.Alert.SprintID > 0) ? me.Alert.SprintID : 0),
//                            OfficeCode: ((me.Alert.OfficeCode && me.Alert.OfficeCode != "") ? me.Alert.OfficeCode : "")
//                        }
//                    }
//                }
//            },
//            requestStart: function (e) {
//                if (e.type === "read") {
//                }
//            },
//            requestEnd: function (e) {
//                var response = e.response;
//                var type = e.type;
//            }
//        });
//        this.divisionsDataSource = service.getNewAssignmentDivisionList({
//            transport: {
//                read: {
//                    data: function () {
//                        return {
//                            SprintID: ((me.Alert.SprintID && me.Alert.SprintID > 0) ? me.Alert.SprintID : 0),
//                            OfficeCode: ((me.Alert.OfficeCode && me.Alert.OfficeCode != "") ? me.Alert.OfficeCode : ""),
//                            ClientCode: ((me.Alert.ClientCode && me.Alert.ClientCode != "") ? me.Alert.ClientCode : "")
//                        }
//                    }
//                }
//            },
//            requestStart: function (e) {
//                if (e.type === "read") {
//                    if (!me.Alert.ClientCode || me.Alert.ClientCode == "") {
//                        e.sender.data([]);
//                        e.preventDefault();
//                    }
//                }
//            },
//            change: function () {
//                var data = this.data(); // or this.view();
//                //if (data && data.length >= 1 && me.Alert) {
//                //    me.checkSingleDivision(data[0].ClientCode);
//                //}
//            }
//        });
//        this.productsDataSource = service.getNewAssignmentProductList({
//            transport: {
//                read: {
//                    data: function () {
//                        return {
//                            SprintID: ((me.Alert.SprintID && me.Alert.SprintID > 0) ? me.Alert.SprintID : 0),
//                            OfficeCode: ((me.Alert.OfficeCode && me.Alert.OfficeCode != "") ? me.Alert.OfficeCode : ""),
//                            ClientCode: ((me.Alert.ClientCode && me.Alert.ClientCode != "") ? me.Alert.ClientCode : ""),
//                            DivisionCode: ((me.Alert.ClientCode && me.Alert.DivisionCode != "") ? me.Alert.DivisionCode : "")
//                        }
//                    }
//                }
//            },
//            change: function () {
//                var data = this.data(); // or this.view();
//                //if (data && data.length >= 1 && me.Alert) {
//                //    me.checkSingleProduct(data[0].ClientCode, data[0].DivisionCode);
//                //}
//            },
//            requestStart: function (e) {
//                if (e.type === "read") {
//                    if (!me.Alert.ClientCode || me.Alert.ClientCode == "" || !me.Alert.DivisionCode || me.Alert.DivisionCode == "") {
//                        e.sender.data([]);
//                        e.preventDefault();
//                    }
//                }
//            },
//            requestEnd: function (e) {
//                var response = e.response;
//                var type = e.type;
//                //console.log(type);
//                //console.log(response.length);
//            }
//        });
//        this.jobsDataSource = service.getNewAssignmentJobList({
//            transport: {
//                read: {
//                    data: function () {
//                        return {
//                            SprintID: ((me.Alert.SprintID && me.Alert.SprintID > 0) ? me.Alert.SprintID : 0),
//                            OfficeCode: ((me.Alert.OfficeCode && me.Alert.OfficeCode != "") ? me.Alert.OfficeCode : ""),
//                            ClientCode: ((me.Alert.ClientCode && me.Alert.ClientCode != "") ? me.Alert.ClientCode : ""),
//                            DivisionCode: ((me.Alert.DivisionCode && me.Alert.DivisionCode != "") ? me.Alert.DivisionCode : ""),
//                            ProductCode: ((me.Alert.ProductCode && me.Alert.ProductCode != "") ? me.Alert.ProductCode : "")
//                        }
//                    }
//                }
//            },
//            change: function () {
//                var data = this.data(); // or this.view();
//                //if (data && data.length >= 1 && me.Alert) {
//                //    me.checkSingleJob(data[0].ClientCode, data[0].DivisionCode, data[0].ProductCode);
//                //}
//            },
//            requestEnd: function (e) {
//                var response = e.response;
//                var type = e.type;         
//                if (me.activated == false) {
//                    //console.log("jobsDS request end", me.jobDropDownList.value(), me.Alert.JobNumber)
//                    me.setDefaultsFromSprintJob();
//                }
//            }
//        });
//        this.componentsDataSource = service.getNewAssignmentComponentList({
//            transport: {
//                read: {
//                    data: function () {
//                        return {
//                            SprintID: ((me.Alert.SprintID && me.Alert.SprintID > 0) ? me.Alert.SprintID : 0),
//                            JobNumber: ((me.Alert.JobNumber && me.Alert.JobNumber > 0) ? me.Alert.JobNumber : 0)
//                        }
//                    }
//                }
//            },
//            change: function () {
//                var data = this.data(); // or this.view();
//            },
//            requestStart: function (e) {
//                if (e.type === "read") {
//                    if (!me.Alert.JobNumber || me.Alert.JobNumber == 0) {
//                        e.sender.data([]);
//                        e.preventDefault();
//                    }
//                }
//            },
//            requestEnd: function (e) {
//                var response = e.response;
//                var type = e.type;
//                //console.log(type);
//                //console.log("END IN CONST", response.length);
//            }
//        });
//        this.taskFunctionDataSource = new kendo.data.DataSource({
//            transport: {
//                read: {
//                    url: 'Desktop/Alert/getTaskFunctions'
//                }
//            },
//            change: function (e) {
//                me.setSubjectFromSelectedTaskFunction();
//            }
//        });
//        this.employeeDataSource = new kendo.data.DataSource({
//            transport: {
//                read: {
//                    url: 'Desktop/Alert/GetEmployees'
//                }
//            }
//        });
//        this.alertRecipientDataSource = new kendo.data.DataSource({
//            transport: {
//                read: {
//                    url: 'Desktop/Alert/GetAlertRecipientsLookup',
//                    data: function () {
//                        return {
//                            c: ((me.Alert.ClientCode && me.Alert.ClientCode != "") ? me.Alert.ClientCode : ""),
//                            d: ((me.Alert.DivisionCode && me.Alert.DivisionCode != "") ? me.Alert.DivisionCode : ""),
//                            p: ((me.Alert.ProductCode && me.Alert.ProductCode != "") ? me.Alert.ProductCode : ""),
//                            j: ((me.Alert.JobNumber && me.Alert.JobNumber > 0) ? me.Alert.JobNumber : 0),
//                            jc: ((me.Alert.JobComponentNumber && me.Alert.JobComponentNumber > 0) ? me.Alert.JobComponentNumber : 0),
//                            a: ((me.Alert.ID && me.Alert.ID > 0) ? me.Alert.ID : 0)
//                        }
//                    }
//                }
//            }
//        });
//        this.boardDataSource = new kendo.data.DataSource({
//            transport: {
//                read: {
//                    url: 'Desktop/Alert/GetBoardsByJob',
//                    data: function () {
//                        return {
//                            JobNumber: ((me.Alert.JobNumber && me.Alert.JobNumber > 0) ? me.Alert.JobNumber : 0)
//                       }
//                    }
//                }
//            },
//            requestStart: function (e) {
//                if (e.type === "read") {
//                    if (!me.Alert.JobNumber || me.Alert.JobNumber == 0) {
//                        e.preventDefault();
//                    }
//                }
//            }
//        });
//        this.sprintDataSource = new kendo.data.DataSource({
//            transport: {
//                read: {
//                    url: 'Desktop/Alert/GetBoardSprints',
//                    data: function () {
//                        return {
//                            BoardID: ((me.Alert.BoardHeaderID && me.Alert.BoardHeaderID > 0) ? me.Alert.BoardHeaderID : 0)
//                        }
//                    }
//                }
//            },
//            requestStart: function (e) {
//                if (e.type === "read") {
//                    if (!me.Alert.BoardHeaderID || me.Alert.BoardHeaderID == 0) {
//                        e.sender.data([]);
//                        e.preventDefault();
//                    }
//                }
//            }
//        });
//        this.boardStateDataSource = new kendo.data.DataSource({
//            transport: {
//                read: {
//                    url: 'Desktop/Alert/GetBoardStates',
//                    data: function () {
//                        return {
//                            BoardHeaderID: ((me.Alert.BoardHeaderID && me.Alert.BoardHeaderID > 0) ? me.Alert.BoardHeaderID : 0 )
//                        }
//                    }
//                }
//            },
//            requestStart: function (e) {
//                if (e.type === "read") {
//                    if (!me.Alert.BoardHeaderID || me.Alert.BoardHeaderID == 0) {
//                        e.sender.data([]);
//                        e.preventDefault();
//                    }
//                }
//            },
//            sort: [{ field: 'BoardColumnSequenceNumber', dir: 'asc' },
//            { field: 'SequenceNumber', dir: 'asc' },
//            { field: 'BoardDetailID', dir: 'asc' }]
//        });
//        this.existingDocumentsDataSource = new kendo.data.DataSource();
//        this.versionDataSource = new kendo.data.DataSource({
//            transport: {
//                read: {
//                    url: 'Desktop/Alert/GetSoftwareVersionsByJobComponent',
//                    data: function () {
//                        return {
//                            JobNumber: ((me.Alert.JobNumber && me.Alert.JobNumber > 0) ? me.Alert.JobNumber : 0),
//                            JobComponentNumber: ((me.Alert.JobComponentNumber && me.Alert.JobComponentNumber > 0) ? me.Alert.JobComponentNumber : 0),
//                            VersionID: (me.Alert.Version && me.Alert.Version != "") ? me.Alert.Version : "0"
//                        }
//                    }
//                }
//            },
//            requestStart: function (e) {
//                if (e.type === "read") {
//                    if (!me.Alert.JobNumber) {
//                       e.sender.data([]);
//                       e.preventDefault();
//                    } else {
//                        me.softwareVersionLastSearched.JobNumber = me.Alert.JobNumber;
//                        me.softwareVersionLastSearched.JobComponentNumber = me.Alert.JobComponentNumber;
//                    }
//                }
//            },
//            requestEnd: function (e) {
//                if (e.type === "read") {
//                    if (e.response) {
//                        if (e.response.length > 0) {
//                            me.showVersion = true;
//                        } else {
//                            me.showVersion = false;
//                        }
//                    }
//                }
//            }
//        });
//        this.buildDataSource = new kendo.data.DataSource({
//            data: []
//        });

//        this.priorityLevels = [
//            { value: 1, text: 'Highest' },
//            { value: 2, text: 'High' },
//            { value: 3, text: 'Normal' },
//            { value: 4, text: 'Low' },
//            { value: 5, text: 'Lowest' }
//        ];
//        this.existingDocumentDialogActions = [
//            {
//                text: 'Save',
//                action: function () {
//                    me.linkExistingDocumentSaveClick();
//                },
//                primary: true
//            },
//            {
//                text: 'Cancel',
//                action: function () {

//                }
//            }
//        ];

//    }

//}
