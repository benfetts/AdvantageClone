import { bindable, inject, customElement, BindingEngine, Disposable } from 'aurelia-framework';
import { DialogController } from 'aurelia-dialog';
import { AlertService } from 'services/desktop/alert-service';
import { ModuleBase } from 'modules/base/module-base';
import { AlertModel } from 'models/desktop/alert-model';
import { DropDownList } from '../../../resources/elements/dropdownlist/dropdownlist';
import { DialogService } from 'aurelia-dialog';
import { ExistingDocumentDialog } from 'modules/desktop/alert-view/existing-document-dialog'
import { EventAggregator } from 'aurelia-event-aggregator';
import { EmailGroupsDialog } from 'modules/desktop/alert-view/email-groups-dialog';

@inject(DialogController, AlertService, BindingEngine, DialogService, EventAggregator)
export class AddWorkItemDialog extends ModuleBase {
    controller: DialogController;
    dialogService: DialogService;
    eventAggregator: EventAggregator;

    @bindable JobComponentID: string = "";
    DivisionID: string = "";
    ProductID: string = "";

    @bindable Alert: AlertModel;
    bindingEngine: BindingEngine;
    disposables: Array<Disposable>;
    //webvantage: Webvantage;
    //dashboard: Dashboard;
    uploadProgressBar: kendo.ui.ProgressBar;
    clientsDataSource: kendo.data.DataSource;
    divisionsDataSource: kendo.data.DataSource;
    productsDataSource: kendo.data.DataSource;
    jobsDataSource: kendo.data.DataSource;
    componentsDataSource: kendo.data.DataSource;
    alertTemplatesDataSource: kendo.data.DataSource;
    alertTemplateStatesDataSource: kendo.data.DataSource;
    alertTemplateStateEmployeesDataSource: kendo.data.DataSource;
    alertCategoriesDataSource: kendo.data.DataSource;
    employeeDataSource: kendo.data.DataSource;
    versionDataSource: kendo.data.DataSource;
    buildDataSource: kendo.data.DataSource;
    officeDataSource: kendo.data.DataSource;
    alertRecipientDataSource: kendo.data.DataSource;

    alertTemplateStateEmployeesDataSourceMultiSelectRouted: kendo.data.DataSource;
    alertTemplateStateEmployeesDataSourceMultiSelectNotRouted: kendo.data.DataSource;

    taskFunctionDataSource: kendo.data.DataSource;

    boardDataSource: kendo.data.DataSource;
    sprintDataSource: kendo.data.DataSource;
    boardStateDataSource: kendo.data.DataSource;

    autoApproveRuleDropDownList: kendo.ui.DropDownList;
    clientDropDownList: kendo.ui.DropDownList;
    divisionDropDownList: kendo.ui.DropDownList;
    productDropDownList: kendo.ui.DropDownList;
    jobDropDownList: kendo.ui.DropDownList;
    jobComponentDropDownList: kendo.ui.DropDownList;
    alertTemplateStatesListBox: kendo.ui.ListBox;
    alertCategoriesDropDownList: kendo.ui.DropDownList;
    assignToDropDownList: DropDownList;
    attachmentUpload: kendo.ui.Upload;
    descriptionEditor: kendo.ui.Editor;
    alertAssignmentTemplateDropDownList: kendo.ui.DropDownList;
    startDatePicker: kendo.ui.DatePicker;
    dueDatePicker: kendo.ui.DatePicker;
    buildDropDownList: kendo.ui.DropDownList;
    officeDropDownList: kendo.ui.DropDownList;
    taskFunctionDropDownList: kendo.ui.DropDownList;

    boardDropDownList: kendo.ui.DropDownList;
    sprintDropDownList: kendo.ui.DropDownList;
    boardStateDropDownList: kendo.ui.DropDownList;

    existingDocumentDialog: kendo.ui.Dialog;
    existingDocumentDialogActions: Array<any>;
    existingDocumentsDataSource: kendo.data.DataSource;
    existingDocumentsGrid: kendo.ui.Grid;
    existingDocumentButton: HTMLElement;

    ccMultiSelect: kendo.ui.MultiSelect;
    assignToMultiSelectRouted: kendo.ui.MultiSelect;
    externalReviewerMultiSelect: kendo.ui.MultiSelect;
    externalReviewerDataSource: kendo.data.DataSource;

    @bindable progressValue: number = 0;
    pickOffice: boolean = true;
    pickClient: boolean = true;
    pickDivision: boolean = true;
    pickProduct: boolean = true;
    pickJob: boolean = true;
    pickComponent: boolean = true;
    pickTask: boolean = true;
    excludeTasks: boolean = false;
    showVersion: boolean = false;
    buildEnabled: boolean = false;
    activated: boolean = false;
    fromPreset: boolean = false;
    includeAlertGroup: boolean = false;
    includeTaskEmployees: boolean = false;
    includeContacts: boolean = false;
    fromBoard: boolean = false;

    softwareVersionLastSearched: any = { JobNumber: 0, JobComponentNumber: 0 };

    @bindable isBoardTask: boolean = false;
    @bindable isProof: boolean = false;
    @bindable taskFunctionEnabled: boolean = false;
    allowEditSubject: boolean = true;
    @bindable uploadToDocumentManager: boolean = false;
    uploadToProofHQ: boolean = false;

    message: string;
    service: AlertService;

    @bindable isRouted: boolean = true;
    @bindable showAllEmployees: boolean = false;
    @bindable autoApproveRule: string = "everyone";
    officeName: string;
    clientName: string;
    divisionName: string;
    productName: string;
    jobDescription: string;
    jobComponentDescription: string;
    taskDescription: string;
    repositoryLimitText: string;
    defaultSubjectType: string = "";
    selectedAlertAssignmentTemplateName: string = "";
    allowUpload: boolean = false;
    autoSelectJob: boolean = false;
    startDateTitle: string = "";
    dueDateTitle: string = "";
    startDateCssName: string = "";
    dueDateCssName: string = "";
    defaultAssignment: boolean = false;
    allowProofHQ: boolean = false;
    Report: string = "";
    boardStateId: number;
    @bindable enableContacts: boolean = false;
    files: Array<any> = [];
    fileNames: Array<any> = [];
    links: Array<any> = [];

    paramsSprintID: number = 0;
    paramsBoardID: number = 0;
    paramsBoardHeaderID: number = 0;
    paramsBoardStateID: number = 0;
    paramsJobNumber: number = 0;
    paramsJobComponentNumber: number = 0;

    createClick: boolean = false;

    contentpage: string = "0";

    callingPage: string = "";
    @bindable includeAttachments: boolean = false;

    priorityLevels: Array<any>;

    linkableDocuments: Array<any>;

    defaultWorkflowTemplate: any = {};

    assignees: Array<string>;

    @bindable boardDropDownListEnabled: boolean = false;
    @bindable sprintDropDownListEnabled: boolean = false;
    @bindable boardStateDropDownListEnabled: boolean = false;
    @bindable hasBoardInfo: boolean = false;
    boardInfo: any;

    paramAlertAssignmentTemplateID: number = null;
    paramAlertStateID: number = null;

    jobHasSchedule: boolean = false;

    jobRequestDefaultAssign: string = '';

    allEmployees = [];
    @bindable externalReviewers: Array<any>;
    @bindable isUploadingFile: boolean = true;
    @bindable uploadingFilePrimary: string = "k-primary";
    @bindable uploadingLinkPrimary: string = "";
    @bindable urlTitle: string;
    @bindable urlLink: string;
    focusLinkTitle: boolean = false;
    focusLinkURL: boolean = false;
    focusUploadFileButton: boolean = false;

    @bindable editorHeight: string = "460";
    @bindable editorHeightProofing: string = "346";

    setUploadToLink() {
        this.isUploadingFile = false;

        this.focusUploadFileButton = false;
        this.focusLinkTitle = true;
        this.focusLinkURL = false;

        this.uploadingLinkPrimary = "k-primary";
        this.uploadingFilePrimary = "";
    }
    setUploadToFile() {
        this.isUploadingFile = true;

        this.focusUploadFileButton = true;
        this.focusLinkTitle = false;
        this.focusLinkURL = false;

        this.uploadingLinkPrimary = "";
        this.uploadingFilePrimary = "k-primary";
    }
    uploadLink() {
        this.showProgress(true);
        if (this.urlLink && this.urlLink.trim() != "") {
            this.links.push({ Title: this.urlTitle, Link: this.urlLink, UploadDocumentManager: this.uploadToDocumentManager });
            this.urlTitle = null;
            this.urlLink = null;
            this.focusLinkTitle = true;
            this.showProgress(false);
        } else {
            this.alert("A URL is required.");
            this.focusLinkURL = true;
            this.showProgress(false);
        }
    }
    deleteLink(link: any) {
        this.links.splice($.inArray(link, this.links), 1);
    }
    keyUpLinkTitle(e) {
        if (e && e.keyCode && e.keyCode === 13) {
            this.focusLinkURL = true;
        }
    }
    keyUpLinkURL(e) {
        if (e && e.keyCode && e.keyCode === 13) {
            this.uploadLink();
        }
    }
    initAlert() {
        if (!this.Alert || this.Alert == null || this.Alert == undefined) {
            this.Alert = new AlertModel;
            this.Alert.PriorityLevel = 3;
            this.Alert.AlertCategoryID = 25;
            this.Alert.AlertTypeID = 6;
        }
    }
    constructor(controller: DialogController, service: AlertService, bindingEngine: BindingEngine, dialogService: DialogService, eventAggregator: EventAggregator) {
        super();
        
        let me = this;

        this.controller = controller;
        this.controller.settings.lock = false;
        this.controller.settings.overlayDismiss = false;
        this.bindingEngine = bindingEngine;
        this.dialogService = dialogService;
        this.eventAggregator = eventAggregator;

        this.Alert = new AlertModel;
        this.Alert.PriorityLevel = 3;
        this.Alert.AlertCategoryID = 25;
        this.Alert.AlertTypeID = 6;
        this.service = service;

        this.officeDataSource = new kendo.data.DataSource();
        this.clientsDataSource = new kendo.data.DataSource();
        this.divisionsDataSource = new kendo.data.DataSource();
        this.productsDataSource = new kendo.data.DataSource();
        this.jobsDataSource = new kendo.data.DataSource();
        this.componentsDataSource = new kendo.data.DataSource();
        this.boardDataSource = new kendo.data.DataSource();
        this.sprintDataSource = new kendo.data.DataSource();

        this.alertTemplatesDataSource = service.getAlertTemplatesDataSource({
            transport: {
                read: {
                    data: function () {
                        return {
                            IsProof: me.isProof ? me.isProof : false
                        }
                    }
                }
            },
            requestStart: function (e) {
                if (e.type === "read") {
                }
            },
            requestEnd: function (e) {
                var type = e.type;
            }
        });
        this.alertTemplateStatesDataSource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: 'Desktop/Alert/GetAlertTemplateStates',
                    data: function () {
                        return {
                            AlertTemplateID: ((me.Alert.AlertAssignmentTemplateID && me.Alert.AlertAssignmentTemplateID > 0) ? me.Alert.AlertAssignmentTemplateID : 0)
                        }
                    }
                }
            },
            requestStart: function (e) {
                if (e.type === "read") {
                    if (!me.Alert.AlertAssignmentTemplateID) {
                        e.sender.data([]);
                        e.preventDefault();
                    }
                }
            },
            requestEnd: function (e) {
                var type = e.type;
                if (!me.jobRequestDefaultAssign || me.jobRequestDefaultAssign == '') {
                    var items = [];
                    items = e.response;
                    if (items && items[0]) {
                        me.Alert.AlertStateID = items[0].ID;
                        me.Alert.AlertStateName = items[0].Name;
                    }
                }
            }
        });
        this.alertTemplateStateEmployeesDataSourceMultiSelectRouted = service.getAlertTemplateStateEmployeesDataSource({
            transport: {
                read: {
                    data: function () {
                        return {
                            AlertID: ((me.Alert.ID && me.Alert.ID > 0) ? me.Alert.ID : 0),
                            AlertTemplateID: ((me.Alert.AlertAssignmentTemplateID && me.Alert.AlertAssignmentTemplateID > 0) ? me.Alert.AlertAssignmentTemplateID : 0),
                            AlertStateID: ((me.Alert.AlertStateID && me.Alert.AlertStateID > 0) ? me.Alert.AlertStateID : 0),
                            ShowAll: me.showAllEmployees ? me.showAllEmployees : false
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
            },
            requestEnd: function (e) {
                var type = e.type;
                if (!me.jobRequestDefaultAssign || me.jobRequestDefaultAssign == '') {
                    var items = [];
                    items = e.response;
                    if (items) {
                        if (me.showAllEmployees == true) {
                            me.allEmployees = [];
                            me.allEmployees = items;
                            //console.log("All items", me.allEmployees);
                        }
                        //try {
                        //    if (!me.Alert.Assignees) {
                        //        me.Alert.Assignees = new Array<string>();
                        //    }
                        //    for (var i = 0; i < items.length; i++) {
                        //        if (items[i].IsDefault == true) {
                        //            me.removeDuplicateRoutedAssignees();
                        //            //console.log("?????", me.Alert.Assignees, items[i]);
                        //            me.Alert.Assignees.push(items[i].Code);
                        //        }
                        //    }
                        //} catch (e) {
                        //}
                        ////try {
                        ////    if (me.Alert.Assignees && me.Alert.Assignees.length > 0 && me.showAllEmployees == false) {
                        ////        me.removeDuplicateRoutedAssignees();
                        ////        for (var j = 0; j < me.Alert.Assignees.length; j++) {
                        ////            var found = false;
                        ////            for (var k = 0; k < items.length; k++) {
                        ////                if (items[k].Code == me.Alert.Assignees[j]) {
                        ////                    found = true;
                        ////                }
                        ////            }
                        ////            if (found == false) {
                        ////                for (var l = 0; l < me.allEmployees.length; l++) {
                        ////                    if (me.Alert.Assignees[j] == me.allEmployees[l].Code) {
                        ////                        console.log("NEED TO ADD", me.allEmployees[l]);
                        ////                        this.alertTemplateStateEmployeesDataSourceMultiSelectRouted.add(me.allEmployees[l]);
                        ////                        break;
                        ////                    }
                        ////                }
                        ////            }
                        ////        }
                        ////    }
                        ////} catch (e) {
                        ////}
                    }
                }
            }
        });
        this.alertTemplateStateEmployeesDataSourceMultiSelectNotRouted = service.getAlertTemplateStateEmployeesDataSource({
            transport: {
                read: {
                    data: function () {
                        return {
                            AlertID: 0,
                            AlertTemplateID: 0,
                            AlertStateID: 0,
                            ShowAll: true
                        }
                    }
                }
            },
            requestStart: function (e) {
                if (e.type === "read") {
                    //console.log("alertTemplateStateEmployeesDataSourceMultiSelectNotRouted :: request start")
                    if (me.isRouted == true) {
                        e.sender.data([]);
                        e.preventDefault();
                    }
                }
            },
            requestEnd: function (e) {
            }
        });
        this.alertCategoriesDataSource = service.getAlertCategoriesDataSource({
            transport: {
                read: {
                    data: function () {
                        return {
                            IncludeTask: (me.jobHasSchedule && !me.isRouted)
                        }
                    }
                }
            },
            requestStart: function (e) {
                if (e.type === "read") {
                    //if (!me.Alert.AlertAssignmentTemplateID || me.Alert.AlertAssignmentTemplateID == 0 || !me.Alert.AlertStateID || me.Alert.AlertStateID == 0 || me.isRouted == false) {
                    //    e.sender.data([]);
                    //    e.preventDefault();
                    //}
                }
            },
            requestEnd: function (e) {
                //console.log("REQUEST END!");
                var items = [];
                items = e.response;
                window.setTimeout(function () {
                    if (me.isProof == true) {
                        me.Alert.AlertCategoryID = 79;
                        me.checkIsProof()
                    }
                }, 10);
            }
        });
        this.officeDataSource = service.getNewAssignmentOfficeList({
            transport: {
                read: {
                    data: function () {
                        return {
                            SprintID: ((me.Alert.SprintID && me.Alert.SprintID > 0) ? me.Alert.SprintID : 0)
                        }
                    }
                }
            }
        });
        this.clientsDataSource = service.getNewAssignmentClientList({
            transport: {
                read: {
                    data: function () {
                        return {
                            SprintID: ((me.Alert.SprintID && me.Alert.SprintID > 0) ? me.Alert.SprintID : 0),
                            OfficeCode: ((me.Alert.OfficeCode && me.Alert.OfficeCode != "") ? me.Alert.OfficeCode : "")
                        }
                    }
                }
            },
            requestStart: function (e) {
                if (e.type === "read") {
                }
            },
            requestEnd: function (e) {
                var response = e.response;
                var type = e.type;
            }
        });
        this.divisionsDataSource = service.getNewAssignmentDivisionList({
            transport: {
                read: {
                    data: function () {
                        return {
                            SprintID: ((me.Alert.SprintID && me.Alert.SprintID > 0) ? me.Alert.SprintID : 0),
                            OfficeCode: ((me.Alert.OfficeCode && me.Alert.OfficeCode != "") ? me.Alert.OfficeCode : ""),
                            ClientCode: ((me.Alert.ClientCode && me.Alert.ClientCode != "") ? me.Alert.ClientCode : "")
                        }
                    }
                }
            },
            requestStart: function (e) {
                if (e.type === "read") {
                    if (!me.Alert.ClientCode || me.Alert.ClientCode == "") {
                        e.sender.data([]);
                        e.preventDefault();
                    }
                }
            },
            change: function () {
                var data = this.data(); // or this.view();
                //if (data && data.length >= 1 && me.Alert) {
                //    me.checkSingleDivision(data[0].ClientCode);
                //}
            }
        });
        this.productsDataSource = service.getNewAssignmentProductList({
            transport: {
                read: {
                    data: function () {
                        return {
                            SprintID: ((me.Alert.SprintID && me.Alert.SprintID > 0) ? me.Alert.SprintID : 0),
                            OfficeCode: ((me.Alert.OfficeCode && me.Alert.OfficeCode != "") ? me.Alert.OfficeCode : ""),
                            ClientCode: ((me.Alert.ClientCode && me.Alert.ClientCode != "") ? me.Alert.ClientCode : ""),
                            DivisionCode: ((me.Alert.ClientCode && me.Alert.DivisionCode != "") ? me.Alert.DivisionCode : "")
                        }
                    }
                }
            },
            change: function () {
                var data = this.data(); // or this.view();
                //if (data && data.length >= 1 && me.Alert) {
                //    me.checkSingleProduct(data[0].ClientCode, data[0].DivisionCode);
                //}
            },
            requestStart: function (e) {
                if (e.type === "read") {
                    if (!me.Alert.ClientCode || me.Alert.ClientCode == "" || !me.Alert.DivisionCode || me.Alert.DivisionCode == "") {
                        e.sender.data([]);
                        e.preventDefault();
                    }
                }
            },
            requestEnd: function (e) {
                var response = e.response;
                var type = e.type;
                //console.log(type);
                //console.log(response.length);
            }
        });
        this.jobsDataSource = service.getNewAssignmentJobList({
            transport: {
                read: {
                    data: function () {
                        return {
                            SprintID: ((me.Alert.SprintID && me.Alert.SprintID > 0) ? me.Alert.SprintID : 0),
                            OfficeCode: ((me.Alert.OfficeCode && me.Alert.OfficeCode != "") ? me.Alert.OfficeCode : ""),
                            ClientCode: ((me.Alert.ClientCode && me.Alert.ClientCode != "") ? me.Alert.ClientCode : ""),
                            DivisionCode: ((me.Alert.DivisionCode && me.Alert.DivisionCode != "") ? me.Alert.DivisionCode : ""),
                            ProductCode: ((me.Alert.ProductCode && me.Alert.ProductCode != "") ? me.Alert.ProductCode : "")
                        }
                    }
                }
            },
            change: function () {
                var data = this.data(); // or this.view();
                //if (data && data.length >= 1 && me.Alert) {
                //    me.checkSingleJob(data[0].ClientCode, data[0].DivisionCode, data[0].ProductCode);
                //}
            },
            requestEnd: function (e) {
                var response = e.response;
                var type = e.type;
                if (me.activated == false) {
                    //console.log("jobsDS request end", me.jobDropDownList.value(), me.Alert.JobNumber)
                    me.setDefaultsFromSprintJob();
                }
            }
        });
        this.componentsDataSource = service.getNewAssignmentComponentList({
            transport: {
                read: {
                    data: function () {
                        return {
                            SprintID: ((me.Alert.SprintID && me.Alert.SprintID > 0) ? me.Alert.SprintID : 0),
                            JobNumber: ((me.Alert.JobNumber && me.Alert.JobNumber > 0) ? me.Alert.JobNumber : 0)
                        }
                    }
                }
            },
            change: function () {
                var data = this.data(); // or this.view();
            },
            requestStart: function (e) {
                if (e.type === "read") {
                    if (!me.Alert.JobNumber || me.Alert.JobNumber == 0) {
                        e.sender.data([]);
                        e.preventDefault();
                    }
                }
            },
            requestEnd: function (e) {
                var response = e.response;
                var type = e.type;
                //console.log(type);
                //console.log("END IN CONST", response.length);
            }
        });
        this.taskFunctionDataSource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: 'Desktop/Alert/getTaskFunctions'
                }
            },
            change: function (e) {
                me.setSubjectFromSelectedTaskFunction();
            }
        });
        this.alertRecipientDataSource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: 'Desktop/Alert/GetAlertRecipientsLookup',
                    data: function () {
                        return {
                            c: ((me.Alert.ClientCode && me.Alert.ClientCode != "") ? me.Alert.ClientCode : ""),
                            d: ((me.Alert.DivisionCode && me.Alert.DivisionCode != "") ? me.Alert.DivisionCode : ""),
                            p: ((me.Alert.ProductCode && me.Alert.ProductCode != "") ? me.Alert.ProductCode : ""),
                            j: ((me.Alert.JobNumber && me.Alert.JobNumber > 0) ? me.Alert.JobNumber : 0),
                            jc: ((me.Alert.JobComponentNumber && me.Alert.JobComponentNumber > 0) ? me.Alert.JobComponentNumber : 0),
                            a: ((me.Alert.ID && me.Alert.ID > 0) ? me.Alert.ID : 0)
                        }
                    }
                }
            },
            requestStart: function (e) {
                if (e.type === "read") {
                }
            },
            requestEnd: function (e) {
                //if (e.type === "read") {
                //    if (e.response) {
                //        console.log("alertRecipientDataSource", e.response);
                //    }
                //}
            }
        });
        this.boardDataSource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: 'Desktop/Alert/GetBoardsByJob',
                    data: function () {
                        return {
                            JobNumber: ((me.Alert.JobNumber && me.Alert.JobNumber > 0) ? me.Alert.JobNumber : 0)
                        }
                    }
                }
            },
            requestStart: function (e) {
                if (e.type === "read") {
                    if (!me.Alert.JobNumber || me.Alert.JobNumber == 0) {
                        e.preventDefault();
                    }
                }
            },
            requestEnd: function (e) {
            }
        });
        this.sprintDataSource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: 'Desktop/Alert/GetBoardSprints',
                    data: function () {
                        return {
                            BoardID: ((me.Alert.BoardHeaderID && me.Alert.BoardHeaderID > 0) ? me.Alert.BoardHeaderID : 0)
                        }
                    }
                }
            },
            requestStart: function (e) {
                if (e.type === "read") {
                    if (!me.Alert.BoardHeaderID || me.Alert.BoardHeaderID == 0) {
                        e.sender.data([]);
                        e.preventDefault();
                    }
                }
            }
        });
        this.boardStateDataSource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: 'Desktop/Alert/GetBoardStates',
                    data: function () {
                        return {
                            BoardHeaderID: ((me.Alert.BoardHeaderID && me.Alert.BoardHeaderID > 0) ? me.Alert.BoardHeaderID : 0)
                        }
                    }
                }
            },
            requestStart: function (e) {
                if (e.type === "read") {
                    if (!me.Alert.BoardHeaderID || me.Alert.BoardHeaderID == 0) {
                        e.sender.data([]);
                        e.preventDefault();
                    }
                }
            },
            sort: [{ field: 'BoardColumnSequenceNumber', dir: 'asc' },
            { field: 'SequenceNumber', dir: 'asc' },
            { field: 'BoardDetailID', dir: 'asc' }]
        });
        this.existingDocumentsDataSource = new kendo.data.DataSource();
        this.versionDataSource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: 'Desktop/Alert/GetSoftwareVersionsByJobComponent',
                    data: function () {
                        return {
                            JobNumber: ((me.Alert.JobNumber && me.Alert.JobNumber > 0) ? me.Alert.JobNumber : 0),
                            JobComponentNumber: ((me.Alert.JobComponentNumber && me.Alert.JobComponentNumber > 0) ? me.Alert.JobComponentNumber : 0),
                            VersionID: (me.Alert.Version && me.Alert.Version != "") ? me.Alert.Version : "0"
                        }
                    }
                }
            },
            requestStart: function (e) {
                if (e.type === "read") {
                    if (!me.Alert.JobNumber) {
                        e.sender.data([]);
                        e.preventDefault();
                    } else {
                        me.softwareVersionLastSearched.JobNumber = me.Alert.JobNumber;
                        me.softwareVersionLastSearched.JobComponentNumber = me.Alert.JobComponentNumber;
                    }
                }
            },
            requestEnd: function (e) {
                if (e.type === "read") {
                    if (e.response) {
                        if (e.response.length > 0) {
                            me.showVersion = true;
                        } else {
                            me.showVersion = false;
                        }
                    }
                }
            }
        });
        this.buildDataSource = new kendo.data.DataSource({
            data: []
        });
        this.externalReviewerDataSource = new kendo.data.DataSource({
            data: []
        });
        this.getAlertSettings();
        this.priorityLevels = [
            { value: 1, text: 'Highest' },
            { value: 2, text: 'High' },
            { value: 3, text: 'Normal' },
            { value: 4, text: 'Low' },
            { value: 5, text: 'Lowest' }
        ];
        //this.existingDocumentDialogActions = [
        //    {
        //        text: 'Save',
        //        action: function () {
        //            me.linkExistingDocumentSaveClick();
        //        },
        //        primary: true
        //    },
        //    {
        //        text: 'Cancel',
        //        action: function () {

        //        }
        //    }
        //];

    }

    externalReviewersClick() {
        this.showErrorNotification("externalReviewersClick");
    }
    removeDuplicateRoutedAssignees() {
        let me = this;
        if (me.Alert && me.Alert.Assignees) {
            me.Alert.Assignees = me.Alert.Assignees.filter((item, index) => me.Alert.Assignees.indexOf(item) === index);
        }
    }
    clearCCs() {
        if (this.Alert) {
            this.Alert.Recipients = [];
        }
        if (this.ccMultiSelect) {
            this.ccMultiSelect.value(null);
        }
    }
    addCCRecipientsFrom(type) {
        if (this.Alert && this.Alert.JobComponentNumber && this.Alert.JobComponentNumber > 0) {
            let me = this;
            if (type == 0) {
                //if (this.includeAlertGroup == true) {
                    this.service.getCCRecipientsAvailable(type, this.Alert.ClientCode, this.Alert.JobNumber, this.Alert.JobComponentNumber, this.Alert.TaskSequenceNumber).then(response => {
                        if (response && response.content) {
                            window.setTimeout(() => {
                                if (me.ccMultiSelect) {
                                    me.ccMultiSelect.value(response.content);
                                    var items = me.ccMultiSelect.value();
                                    if (items && items.length > 0) {
                                        for (var i = 0; i < items.length; i++) {
                                            me.Alert.Recipients.push(items[i]);
                                        }
                                    }
                                } else {
                                    //console.log("no multiselect?");
                                }
                                //console.log("ccMultiSelect", me.ccMultiSelect.value());
                                //console.log("Recipients", me.Alert.Recipients);
                            }, 10);
                        }
                    }).then(() => {
                    });
                //}
            }
            //if (type == 2) {
            //    if (this.includeContacts == true) {
            //        this.service.getCCRecipientsAvailable(type, this.Alert.ClientCode, this.Alert.JobNumber, this.Alert.JobComponentNumber, this.Alert.TaskSequenceNumber).then(response => {
            //            if (response && response.content) {
            //                if (me.ccMultiSelect) {
            //                    me.ccMultiSelect.value(response.content);
            //                } else {
            //                    //console.log("no multiselect?");
            //                }
            //            }
            //        }).then(() => {
            //        });
            //    }
            //}
        } else {
            this.showInfoNotification("Select a component first.")
        }
    }
    emailGroupsClick() {
        //console.log("emailGroupsClick()");
        if (this.Alert.JobComponentNumber && this.Alert.JobComponentNumber > 0) {
            this.dialogService.open({ viewModel: EmailGroupsDialog, model: { Alert: this.Alert }, lock: false }).whenClosed(results => {
                //console.log("emailGroupsClick", results);
                if (!results.wasCancelled) {
                    if (results.output.Employees) {
                        //console.log("emailGroupsClick:response.output.Employees", results.output.Employees);
                        let selectedEmps: any;
                        selectedEmps = results.output.Employees;
                        for (let i = 0; i < selectedEmps.length; i++) {
                            if (!this.Alert.Recipients) {
                                this.Alert.Recipients = [];
                            }
                            if (selectedEmps[i].IsClientContact == false) {
                                if (this.Alert.Recipients.includes(selectedEmps[i].EmployeeCode) == false) {
                                    this.Alert.Recipients.push(selectedEmps[i].EmployeeCode);
                                }
                            } else {
                                if (this.Alert.Recipients.includes("CC|" + selectedEmps[i].EmployeeCode) == false) {
                                    this.Alert.Recipients.push("CC|" + selectedEmps[i].EmployeeCode);
                                }
                            }
                        }
                        //console.log("control", this.ccMultiSelect);
                        if (this.Alert.Recipients) {
                            this.ccMultiSelect.value(this.Alert.Recipients);
                        }
                    }
                    //console.log("this.Alert.Recipients", this.Alert.Recipients);
                    //this.checkForCCinDataSource();
                    if (this.Alert.Recipients && this.Alert.Recipients.length > 0) {

                    }
                }
            });
        } else {
            this.showInfoNotification("Select a component first.")
        }
    }
    checkForCCinDataSource() {
        //console.log("checkForCCinDataSource")
        if (this.ccMultiSelect) {
            if (this.ccMultiSelect.dataItems()) {
                for (var i = 0; i < this.ccMultiSelect.dataItems().length; i++) {
                    var item = this.ccMultiSelect.dataItems()[i];
                    //if (this.tempCompleteRcpts.indexOf(item.Code) > -1) {
                    //    item.IsTempComplete = true;
                    //} else {
                    //    item.IsTempComplete = false;
                    //}
                    //console.log("checkForCCinDataSource item", item);
                }
            }
        }
    }
    assigneeOnClose(e) {
    }
    assigneeOnChange(e) {
        let me = this;
        me.loadCCWorkaround();
    }
    assigneeSelected(e) {
    }
    assigneeDeselected(e) {
    }
    loadCCWorkaround() {
        let me = this;
        try {
            if (!me.Alert.Recipients) {
                me.Alert.Recipients = [];
            }
        } catch (e) { console.log("loadCCWorkaround:Recipients", e); }
        try {
            if (me.ccMultiSelect.items().length == 0) {
                me.alertRecipientDataSource.read();
            }
        } catch (e) { console.log("loadCCWorkaround:me.alertRecipientDataSource.read()", e); }
    }

    externalReviewerOnClose(e) {
    }
    externalReviewerOnChange(e) {
    }
    externalReviewerDeselected(e) {
    }
    externalReviewerSelected(e) {
    }

    ccOnClose(e) {
        //console.log("ccOnClose????", this.Alert.Recipients);
        ////e.preventDefault();
        //let me = this;
        //if (me.Alert.Recipients) {
        //    console.log("ccOnClose Alert.Recipients BEFORE", me.Alert.Recipients);
        //}
        //console.log("ccOnClose e", e);
        //console.log("ccOnClose dataItem", e.dataItem);
        //if (me.Alert.Recipients) {
        //    console.log("ccOnClose Alert.Recipients", me.Alert.Recipients);
        //}
    }
    ccOnChange(e) {
        //console.log("ccOnChange????", this.Alert.Recipients);
        ////e.preventDefault();
        //let me = this;
        //if (me.Alert.Recipients) {
        //    console.log("ccOnChange Alert.Recipients BEFORE", me.Alert.Recipients);
        //}
        //console.log("ccOnChange e", e);
        //console.log("ccOnChange dataItem", e.dataItem);
        //if (me.Alert.Recipients) {
        //    console.log("ccOnChange Alert.Recipients", me.Alert.Recipients);
        //}
    }
    ccSelected(e) {
        //console.log("ccSelected????", this.Alert.Recipients);
        ////e.preventDefault();
        //let me = this;
        //console.log("ccSelected e", e);
        //console.log("ccSelected dataItem", e.dataItem);
        //if (me.Alert.Recipients) {
        //    console.log("ccSelected Alert.Recipients", me.Alert.Recipients);
        //}
    }
    ccDeselected(e) {
        //console.log("ccDeselected????", this.Alert.Recipients);
        try {
            let me = this;
            window.setTimeout(function () {

                //console.log("me.ccMultiSelect", me.ccMultiSelect);

                if (e) {
                    if (e.dataItem) {
                        if (me.Alert.Recipients) {
                            var idx = me.Alert.Recipients.indexOf(e.dataItem.Code);
                            if (idx > -1) {
                                me.Alert.Recipients.splice(idx, 1);
                            }
                            //console.log("me.Alert.Recipients", me.Alert.Recipients);
                        } else {
                            //console.log("no Alert Recipients");
                        }
                    } else {
                        //console.log("no dataItem");
                    }
                } else {
                    //console.log("no e");
                }



            }, 250);
        } catch (e) {
            console.log("ccDeselected:error", e);
        }
    }
    contactsClick() {
        if (this.Alert.JobComponentNumber > 0) {
            this.openRadWindow('Contacts', 'popContacts.aspx?from=newalert&c=' + this.Alert.ClientCode + '&d=' + this.Alert.DivisionCode + '&j=' + this.Alert.JobNumber + '&jc=' + this.Alert.JobComponentNumber + '&p=' + this.Alert.ProductCode + '', 1200, 400);
        }
    }
    setAlertLevel() {
        if (this.isBoardTask === true && this.isRouted === false) {
            this.Alert.AlertLevel = "BRD";
        } else {
            try {
                if (this.Alert.OfficeCode && this.Alert.OfficeCode !== "") {
                    this.Alert.AlertLevel = "OF";
                }
                if (this.Alert.ClientCode && this.Alert.ClientCode !== "") {
                    this.Alert.AlertLevel = "CL";
                }
                if (this.Alert.ClientCode && this.Alert.ClientCode !== "" && this.Alert.DivisionCode && this.Alert.DivisionCode !== "") {
                    this.Alert.AlertLevel = "DI";
                }
                if (this.Alert.ClientCode && this.Alert.ClientCode !== "" && this.Alert.DivisionCode && this.Alert.DivisionCode !== "" && this.Alert.ProductCode && this.Alert.ProductCode !== "") {
                    this.Alert.AlertLevel = "PRD";
                }
                if (this.Alert.JobNumber && this.Alert.JobNumber > 0) {
                    this.Alert.AlertLevel = "JO";
                }
                if (this.Alert.JobNumber && this.Alert.JobNumber > 0 && this.Alert.JobComponentNumber && this.Alert.JobComponentNumber > 0) {
                    this.Alert.AlertLevel = "JC";
                }
                if (this.Alert.JobNumber && this.Alert.JobNumber > 0 && this.Alert.JobComponentNumber && this.Alert.JobComponentNumber > 0 && this.Alert.TaskSequenceNumber && this.Alert.TaskSequenceNumber > 0) {
                    this.Alert.AlertLevel = "PST";
                }
            } catch (e) {
                this.Alert.AlertLevel = "JC";
            }
        }
        if (!this.Alert.AlertLevel || this.Alert.AlertLevel === "") {
            this.Alert.AlertLevel = "JC";
        }
    }
    saveClick(notify: boolean) {
        let me = this;
        if (me.createClick == false) {
            me.createClick = true;
            if (me.dueDateIsBeforeStartDate(me.Alert.StartDate, me.Alert.DueDate) === true) {
                me.alert("Due date before start date.");
                me.createClick = false;
                return false;
            } else {
                if ((!me.Alert.OfficeCode || me.Alert.OfficeCode == "") &&
                    (!me.Alert.ClientCode || me.Alert.ClientCode == "") &&
                    (!me.Alert.DivisionCode || me.Alert.DivisionCode == "") &&
                    (!me.Alert.ProductCode || me.Alert.ProductCode == "") &&
                    (!me.Alert.JobNumber || me.Alert.JobNumber == 0) &&
                    (!me.Alert.JobComponentNumber || me.Alert.JobComponentNumber == 0)) {
                    me.alert("Please select a level.");
                    me.createClick = false;
                    return false;
                }
                if (!me.Alert.Subject || me.Alert.Subject == "") {
                    me.alert("Subject is required.");
                    me.createClick = false;
                    return false;
                }
                if (me.isProof == true) {
                    if ((me.Alert.JobNumber == null || me.Alert.JobNumber == 0 || me.Alert.JobNumber == undefined) && (me.Alert.JobComponentNumber == null || me.Alert.JobComponentNumber == 0 || me.Alert.JobComponentNumber == undefined)) {
                        me.alert("Please select a job and component for proof.");
                        me.createClick = false;
                        return false;
                    }
                    if (me.Alert.JobNumber == null || me.Alert.JobNumber == 0 || me.Alert.JobNumber == undefined) {
                        me.alert("Please select a job for proof.");
                        me.createClick = false;
                        return false;
                    }
                    if (me.Alert.JobComponentNumber == null || me.Alert.JobComponentNumber == 0 || me.Alert.JobComponentNumber == undefined) {
                        me.alert("Please select a component for proof.");
                        me.createClick = false;
                        return false;
                    }
                }
                if (me.isRouted == true) {
                    if (isNaN(me.Alert.AlertAssignmentTemplateID) == true || me.Alert.AlertAssignmentTemplateID == 0) {
                        me.alert("Please select a workflow.");
                        me.createClick = false;
                        return false;
                    }
                    if (isNaN(me.Alert.AlertStateID) == true || me.Alert.AlertStateID == 0) {
                        me.alert("Please select a state.");
                        me.createClick = false;
                        return false;
                    }
                    ////if (me.Alert.AssignedEmployeeCode == '' && me.Alert.Assignees.length == 0) {
                    ////    me.alert("Please select an assignee.");
                    ////    me.createClick = false;
                    ////    return false;
                    ////}
                } else {
                    ////if ((me.Alert.Assignees == undefined || me.Alert.Assignees.length == 0) || me.Alert.AssignedEmployeeCode == '') {
                    ////    me.alert("Please select at lease one assignee.");
                    ////    me.createClick = false;
                    ////    return false;
                    ////}
                    ////if (me.Alert.Assignees != undefined) {
                    ////    if (me.Alert.Assignees[0] == '' || me.Alert.Assignees.length == 0) {
                    ////        me.alert("Please select at lease one assignee.");
                    ////        me.createClick = false;
                    ////        return false;
                    ////    }
                    ////}
                }
                if (me.Alert.SprintID > 0) {
                    if (me.Alert.JobNumber == undefined || me.Alert.JobNumber == 0) {
                        me.alert("Please select a job when creating an assignment for a sprint.");
                        me.createClick = false;
                        return false;
                    }
                    if (me.Alert.JobComponentNumber == undefined || me.Alert.JobComponentNumber == 0) {
                        me.alert("Please select a component when creating an assignment for a sprint.");
                        me.createClick = false;
                        return false;
                    }
                }
                me.Alert.IsWorkItem = true;
                me.setAlertLevel();
                me.Alert.LinkedDocuments = [];
                if (me.linkableDocuments) {
                    for (var i = 0; i < me.linkableDocuments.length; i++) {
                        me.Alert.LinkedDocuments.push(me.linkableDocuments[i].ID);
                    }
                }
                var s = "";
                var d = "";
                if (me.Alert.StartDate) {
                    s = me.parseShortDate(me.Alert.StartDate).value;
                }
                if (me.Alert.DueDate) {
                    d = me.parseShortDate(me.Alert.DueDate).value;
                }

                let unassigned: boolean = false;
                let save: boolean = false;
                if (!me.Alert.Assignees || me.Alert.Assignees.length == 0) {
                    unassigned = true;
                }
                if (unassigned == false) {
                    save = true;
                } else {
                    if (confirm("Save as unassigned?") == true) {
                        save = true;
                    } else {
                        save = false;
                    }
                }

                if (save == true) {
                    var linksString = "";
                    if (me.links) {
                        linksString = JSON.stringify(me.links);
                    }
                    me.syncFiles();
                    me.Alert.UploadedFiles = me.fileNames;
                    me.showProgress(true);
                    me.service.createAssignmentWithDateWorkaround(me.Alert, s, d, notify, me.uploadToDocumentManager, me.uploadToProofHQ, me.Report, linksString).then(response => {
                        me.showProgress(false);
                        if (response.content.Success == true || response.content.Success == "true" || response.content.success == true || response.content.success == "true") {
                            if (me.Alert && response.content.AlertID && response.content.AlertID > 0) {
                                me.Alert.ID = response.content.AlertID;
                                me.Alert.Subject = response.content.Title;
                            }
                            if (me.attachmentUpload) {
                                me.attachmentUpload.removeAllFiles();
                                me.attachmentUpload.clearAllFiles();
                            }                            
                            me.links = [];
                            me.files = [];
                            me.fileNames = [];
                            me.syncFiles();
                            me.urlTitle = null;
                            me.urlLink = null;
                            if (me.isProof == true && response.content.AlertID && response.content.AlertID > 0) {
                                //me.refreshReviewsStuff();
                                me.openRadWindow(response.content.Title, "Desktop_AlertView?AlertID=" + response.content.AlertID + "&SprintID=0");
                            } else {
                                try {
                                    if (response.content.RefreshMe == true) {
                                        me.refreshAssignmentStuff();
                                    }
                                } catch (e) {}
                            }
                            me.controller.ok();
                        } else if (response.content.message && response.content.message != "") {
                            me.alert(response.content.message);
                        }
                        me.createClick = false;
                    })
                    .then(() => {
                        me.showProgress(false);
                    });
                }
            }
        } else {
            me.createClick = false;
        }
    }
    refreshAssignmentStuff() {
        try {
            wvbridge.refreshDashboardAssignments();
        } catch (e) {
        }
        try {
            wvbridge.refreshAlertsAndAssignmentsManagerPMD();
        } catch (e) {
        }
    }
    refreshReviewsStuff() {
        try {
            wvbridge.refreshDashboardReviews();
        } catch (e) {
        }
    }
    isBoardTaskChanged(newValue, oldValue) {
        ////this.Alert.Subject = '';
        if (this.isBoardTask === true) {
            this.isRouted = false;
        }
        this.checkTaskEnabled();
    }
    showAllEmployeesChanged(newValue, oldValue) {
        //console.log('showAllEmployeesChanged', this.Alert.Assignees);
        if (this.isRouted == true) {
            this.alertTemplateStateEmployeesDataSourceMultiSelectRouted.read();
        } else {
            this.alertTemplateStateEmployeesDataSourceMultiSelectNotRouted.read();
        }
    }
    alertStateIDChanged(newValue, oldValue) {
        //console.log('alertStateIDChanged', newValue, oldValue);
        //console.log('alertStateIDChanged', this.Alert.Assignees);
        if (this.isRouted == true) {
            this.alertTemplateStateEmployeesDataSourceMultiSelectRouted.read();
        } else {
            this.alertTemplateStateEmployeesDataSourceMultiSelectNotRouted.read();
        }
    }
    alertAssignmentTemplateIDChanged(newValue, oldValue) {

        this.eventAggregator.publish('loadlistbox');

        //this.Alert.AlertStateID = null;
        //if (this.alertTemplateStatesListBox) {
        //    this.alertTemplateStatesListBox.clearSelection();
        //    this.alertTemplateStatesListboxChange();
        //    this.alertTemplateStatesDataSource.read();
        //}
    }
    isRoutedChanged(newValue, oldValue) {
        let me = this;
        this.Alert.Assignees = [];
        this.Alert.AssignedEmployeeCode = null;
        this.Alert.AlertStateID = null;
        if (newValue === true) {
            if (this.defaultWorkflowTemplate) {
                this.Alert.AlertAssignmentTemplateID = this.defaultWorkflowTemplate.AlertAssignmentTemplateID;
            } else {
                this.Alert.AlertAssignmentTemplateID = null;
            }
        } else {
            this.Alert.AlertAssignmentTemplateID = null;
        }
        if (this.alertAssignmentTemplateDropDownList) {
            this.alertAssignmentTemplateDropDownList.value("");
        }

        me.alertCategoriesDataSource.read();

        window.setTimeout(function () {
            me.checkIsBoardTask();
            me.refreshTypes();
        }, 0);
    }
    descriptionChanged(e) {
        this.Alert.EmailBody = this.descriptionEditor.value();
    }
    taskFunctionChanged(e) {
        this.setSubjectFromSelectedTaskFunction();
    }
    setSubjectFromSelectedTaskFunction() {
        try {
            if (this.isBoardTask === true) {
                if (this.taskFunctionDropDownList) {
                    var item = this.taskFunctionDropDownList.dataItem(this.taskFunctionDropDownList.select());
                    var subject = '';
                    if (item.Code && item.Code !== '') {
                        subject = item.Description;
                        this.allowEditSubject = false;
                        this.Alert.Subject = subject;
                    } else {
                        this.allowEditSubject = true;
                    }
                }
            }
        } catch (e) {
        }
    }
    assignToMultiSelectRoutedChange(e) {
        //console.log("assignToMultiSelectRoutedChange", this.assignToMultiSelectRouted.value);
        //console.log("this.Alert.AssignedEmployeeCode", this.Alert.AssignedEmployeeCode);
        //console.log("this.Alert.Assignees", this.Alert.Assignees);
        let me = this;
        me.loadCCWorkaround();
    }
    clearBoardInfo() {
        if (this.fromBoard == false) {
            this.hasBoardInfo = false;
            this.Alert.BoardHeaderID = null;
            this.Alert.SprintID = 0;
            this.Alert.BoardStateID = null;
            if (this.boardDropDownList) {
                this.boardDropDownList.enable(false);
            }
            if (this.sprintDropDownList) {
                this.sprintDropDownList.enable(false);
            }
            if (this.boardStateDropDownList) {
                this.boardStateDropDownList.enable(false);
            }
            this.boardDropDownListEnabled = false;
            this.sprintDropDownListEnabled = false;
            this.boardStateDropDownListEnabled = false;
        }
    }
    checkForBoard() {
        let me = this;
        me.clearBoardInfo();       
        if (me.Alert.JobNumber && me.Alert.JobNumber > 0 && me.Alert.JobComponentNumber && me.Alert.JobComponentNumber > 0) {
            me.service.checkForBoard(me.Alert.JobNumber, me.Alert.JobComponentNumber).then(response => {
                if (response && response.content) {
                    me.boardInfo = response.content;
                    //console.log("boardInfo", me.boardInfo);
                    if (me.boardInfo.HasActiveBoard == true) {
                        me.hasBoardInfo = true;
                        if (me.boardDropDownList) {
                            me.boardDropDownList.enable(true);
                        }
                        me.boardDropDownListEnabled = true;
                        me.boardDataSource = new kendo.data.DataSource({
                            data: me.boardInfo.DisplayBoards
                        });
                        me.boardDropDownList.setDataSource(me.boardDataSource);
                        var items = me.boardDataSource.data();
                        if (items) {
                            if (items.length == 1) {
                                window.setTimeout(function () {
                                    me.Alert.BoardHeaderID = items[0].ID;
                                    //me.boardDropDownList.value(items[0].ID);
                                    me.getBoardSprintInfo();
                                }, 10);
                            }
                        }
                        //me.showCurrentValues(1266);
                        window.setTimeout(function () {
                            if (me.fromBoard == true) {
                                if (me.paramsBoardID && me.paramsBoardID > 0) {
                                    me.Alert.BoardHeaderID = me.paramsBoardID;
                                    me.boardDropDownList.value(me.paramsBoardID + "");
                                    me.getBoardSprintInfo();
                                }
                            }
                        }, 10);
                        //if (me.boardInfo.Sprints) {
                        //    me.sprintDataSource = new kendo.data.DataSource({
                        //        data: me.boardInfo.Sprints
                        //    });
                        //    me.sprintDropDownList.setDataSource(me.sprintDataSource);
                        //    me.sprintDropDownListEnabled = true;
                        //    if (me.boardInfo.Sprints.length == 1) {
                        //        me.Alert.SprintID = me.boardInfo.Sprints[0].ID;
                        //    }
                        //} else {
                        //    me.getBoardSprintInfo();
                        //}
                        //me.boardStateDataSource = new kendo.data.DataSource({
                        //    data: me.boardInfo.States
                        //});
                        //me.boardStateDropDownList.setDataSource(me.boardStateDataSource);
                        //me.boardStateDropDownListEnabled = true;
                        //console.log("checkForBoard", me.Alert.BoardHeaderID, me.boardDropDownList.value())
                    }
                }
            });
        }
        //me.showCurrentValues(1289);
    }
    boardDataFromLoad() {
        let me = this;
        if (this.fromBoard == true) {

        }
    }
    boardDropDownListChange(evt) {
        //console.log("boardDropDownListChanged")
        if (this.sprintDropDownList) {
            this.sprintDropDownList.value(null);
            this.sprintDropDownList.enable(false);
        }
        if (this.boardStateDropDownList) {
            this.boardStateDropDownList.value(null);
            this.boardStateDropDownList.enable(false);
        }
        this.sprintDropDownListEnabled = false;
        this.boardStateDropDownListEnabled = false;
        this.getBoardSprintInfo();
    }
    getBoardSprintInfo() {
        let me = this;
        if (me.Alert.BoardHeaderID && me.Alert.BoardHeaderID > 0) {
            window.setTimeout(function () {
                //console.log("getBoardSprintInfo", me.Alert.BoardHeaderID, me.boardDropDownList.value())
                me.service.getBoardSprints(me.Alert.BoardHeaderID).then(response => {
                    if (response) {
                        me.sprintDataSource = new kendo.data.DataSource({
                            data: response.content
                        });
                        me.sprintDropDownList.setDataSource(me.sprintDataSource);
                        me.sprintDropDownList.enable(true);
                        me.sprintDropDownListEnabled = true;
                        var items = me.sprintDataSource.data();
                        if (items) {
                            if (items.length == 1) {
                                window.setTimeout(function () {
                                    me.sprintDropDownListEnabled = true;
                                    me.Alert.SprintID = items[0].ID;
                                    me.getBoardStateInfo();
                                }, 10);
                            }
                            if (me.fromBoard == true && items.length > 1) {
                                window.setTimeout(function () {
                                    if (me.paramsSprintID && me.paramsSprintID > 0) {
                                        //console.log("????", me.Alert.BoardHeaderID, me.Alert.SprintID);
                                        me.showCurrentValues(1344);
                                        me.Alert.SprintID = me.paramsSprintID;
                                        me.sprintDropDownList.value(me.paramsSprintID + "");
                                        //me.boardStateDropDownList.enabled(true);
                                        me.getBoardStateInfo();
                                    }
                                }, 10);
                            }
                            if (items.length > 1) {
                                me.sprintDropDownList.enable(true);
                            }
                        }
                    }
                });
            }, 10);
        }
    }
    boardSprintDropDownListChange(evt) {
        if (this.boardStateDropDownList) {
            this.boardStateDropDownList.value(null);
            this.boardStateDropDownList.enable(false);
        }
        this.boardStateDropDownListEnabled = false;
        this.getBoardStateInfo();
    }
    getBoardStateInfo() {
        let me = this;
        if (me.Alert.SprintID && me.Alert.SprintID > 0) {
            me.sprintDropDownList.value(me.Alert.SprintID.toString());
            me.service.getBoardSprintStates(me.Alert.SprintID).then(response => {
                if (response && response.content) {
                    me.boardStateDataSource = new kendo.data.DataSource({
                        data: response.content
                    });
                    me.boardStateDropDownList.setDataSource(me.boardStateDataSource);
                    me.boardStateDropDownList.enable(true);
                    me.boardStateDropDownListEnabled = true;
                }
                var items = me.boardStateDataSource.data();
                if (items && items.length == 1) {
                    window.setTimeout(function () {
                        me.boardStateDropDownList.enable(true);
                        me.boardStateDropDownListEnabled = true;
                        me.Alert.BoardStateID = items[0].ID;
                    }, 10);
                }
                //me.showCurrentValues(1392)
                if (me.Alert.BoardStateID && me.Alert.BoardStateID > 0) {
                    me.boardStateDropDownList.value(me.Alert.BoardStateID.toString());
                }
                if (me.boardDropDownList.value() && me.sprintDropDownList.value()) {
                    if (me.Alert.BoardID && me.Alert.BoardID > 0) {
                        me.boardDropDownList.enable(false);
                    }
                    if (me.Alert.SprintID && me.Alert.SprintID > 0) {
                        me.sprintDropDownList.enable(false);
                    }
                }
            });
        }
    }

    didJobChangeFromLoad() {
        let me = this;
        //console.log("didJobChangeFromLoad", me.backupParams.JobNumber, me.Alert.JobNumber, me.backupParams.JobNumber == me.Alert.JobNumber);
        //if (me.backupParams.JobNumber == me.Alert.JobNumber) {
        //    return false;
        //} else {
        //    return true;
        //}
    }
    didComponentChangeFromLoad() {
        let me = this;
        //console.log("didComponentChangeFromLoad", me.backupParams.JobComponentNumber, me.Alert.JobComponentNumber, me.backupParams.JobComponentNumber == me.Alert.JobComponentNumber);
        //if (me.backupParams.JobComponentNumber == me.Alert.JobComponentNumber) {
        //    return false;
        //} else {
        //    return true;
        //}
    }

    getAlertSettings() {
        //console.log("getAlertSettings")
        return this.service.getAlertSettings().then(response => {
            if (response.content) {
                //this.AutoClose = response.content.AutoClose;
                //this.ShowChecklistsOnCards = response.content.ShowChecklistsOnCards;
               // this.DetailsExpanded = response.content.DetailsExpanded;
                this.uploadToDocumentManager = response.content.UploadDocumentManager;
               // this.WidgetLayout = new Array<string>();
               // Object.assign(this.WidgetLayout, response.content.WidgetLayout);
                //console.log(this.AutoClose)
                //console.log(this.ShowChecklistsOnCards)
                //console.log(this.DetailsExpanded)
                //console.log(this.WidgetLayout)
            }
        }).then(() => {
           // this.sortWidgets();
        });
    }

    checkSingleClient(officeCode: string) {
        if (officeCode) {
            var items = this.officeDropDownList.dataSource.data();
            let client = null;
            let multiple = false;
            for (var i = 0; i < items.length; i++) {
                if (items[i].OfficeCode === officeCode) {
                    if (!client) {
                        client = items[i];
                    } else {
                        multiple = true;
                    }
                }
            }
            if (client && !multiple) {
                this.Alert.ClientCode = client.ClientCode;
                this.Alert.ClientName = client.ClientName;
                this.clientDropDownList.value(client.ClientCode);
                this.clientDropDownList.enable(true);
                //let me = this;
                //window.setTimeout(function () {
                //    me.checkSingleDivision(client.ClientCode);
                //}, 0);
            } else {
                this.clientDropDownList.focus();
            }
        }
        this.divisionDropDownList.enable(false);
    }
    checkSingleDivision(clientCode: string) {
        //console.log("checkSingleDivision")
        if (clientCode) {
            var items = this.divisionDropDownList.dataSource.data();
            let division = null;
            let multiple = false;
            for (var i = 0; i < items.length; i++) {
                if (items[i].ClientCode === clientCode) {
                    if (!division) {
                        division = items[i];
                    } else {
                        multiple = true;
                    }
                }
            }
            if (division && !multiple) {
                this.Alert.DivisionCode = division.DivisionCode;
                this.Alert.DivisionName = division.DivisionName;
                this.divisionDropDownList.value(division.DivisionCode);
                this.divisionDropDownList.enable(true);
                //let me = this;
                //window.setTimeout(function () {
                //    me.checkSingleProduct(division.ClientCode, division.DivisionCode);
                //}, 0);
            } else {
                this.divisionDropDownList.focus();
            }
        }
    }
    checkSingleProduct(clientCode, divisionCode) {
        if (clientCode && divisionCode) {
            var items = this.productDropDownList.dataSource.data();
            let product = null;
            let multiple = false;
            for (var i = 0; i < items.length; i++) {
                if (items[i].ClientCode === clientCode && items[i].DivisionCode === divisionCode) {
                    if (!product) {
                        product = items[i];
                    } else {
                        multiple = true;
                    }
                }
            }
            if (product && !multiple) {
                this.Alert.ProductCode = product.ProductCode;
                this.Alert.ProductName = product.ProductName;
                this.productDropDownList.value(product.ProductCode);
                this.productDropDownList.enable(true);
                //let me = this;
                //window.setTimeout(function () {
                //    me.checkSingleJob(product.ClientCode, product.DivisionCode, product.ProductCode);
                //}, 0);
            } else {
                this.productDropDownList.focus();
            }
        }
    }
    checkSingleJob(clientCode: string, divisionCode: string, productCode: string) {
        if (clientCode && divisionCode && productCode) {
            var items = this.jobDropDownList.dataSource.data();
            let job = null;
            let multiple = false;
            for (var i = 0; i < items.length; i++) {
                if (items[i].ClientCode === clientCode && items[i].DivisionCode === divisionCode && items[i].ProductCode === productCode) {
                    if (!job) {
                        job = items[i];
                    } else {
                        multiple = true;
                    }
                }
            }
            if (job && job.JobNumber && job.JobNumber > 0 && !multiple) {
                this.Alert.JobNumber = job.JobNumber;
                this.Alert.JobDescription = job.JobDescription;
                this.jobDropDownList.value(job.JobNumber);
                let me = this;
                //window.setTimeout(function () {
                //    me.componentsDataSource.read();
                //}, 0);
                //window.setTimeout(function () {
                //    me.checkSingleComponent(job.JobNumber);
                //}, 0);
            } else {
                this.jobDropDownList.focus();
            }
        }
    }
    checkSingleComponent(jobNumber: number) {
        let me = this;
        if (jobNumber && jobNumber > 0) {
            var items = this.jobComponentDropDownList.dataSource.data();
            let component = null;
            let multiple = false;
            if (items) {
                this.jobComponentDropDownList.enable(true);
                for (var i = 0; i < items.length; i++) {
                    if (items[i].JobNumber === jobNumber) {
                        if (!component) {
                            component = items[i];
                        } else {
                            multiple = true;
                        }
                    }
                }
            }
            if (component && !multiple) {
                this.Alert.JobComponentNumber = component.JobComponentNumber;
                this.Alert.JobComponentDescription = component.JobComponentDescription;
                this.jobComponentDropDownList.value(component.JobComponentNumber);
                me.jobComponentNumberChanged(component.JobComponentNumber, 0);
                $('#isRouted').focus();
                window.setTimeout(function () {
                    me.componentChanged(null);
                }, 0);
            } else {
                if (this.Alert && this.Alert.JobComponentNumber && this.Alert.JobComponentDescription) {
                    this.jobComponentDropDownList.value(this.Alert.JobComponentNumber + "");
                    me.jobComponentNumberChanged(this.Alert.JobComponentNumber, 0);
                    window.setTimeout(function () {
                        me.componentChanged(null);
                    }, 0);
                } else {
                    this.jobComponentDropDownList.focus();
                }
            }
        }
    }

    checkSingleTask(jobNumber: number, jobComponentNumber: number) {

    }
    checkSingleAll() {
        //console.log("checkSingleAll", this.divisionDropDownList, this.Alert.DivisionCode)
        let me = this;
        var items: any = null;
        var versionChecked: boolean = false;
        this.setDefaultDropDownEnabled();
        if (this.officeDropDownList) {
            items = this.officeDropDownList.dataSource.data();
            if ((items && items.length == 1 && this.Alert.OfficeCode !== "")) {
                setTimeout(function () {
                    me.officeDropDownList.enable(false);
                }, 0);
            }
            items = null;
        }
        if (this.clientDropDownList) {
            items = this.clientDropDownList.dataSource.data();
            if ((items && items.length == 1 && this.Alert.ClientCode !== "") || (!this.Alert.ClientCode || this.Alert.ClientCode == "")) {
                setTimeout(function () {
                    me.clientDropDownList.enable(false);
                }, 0);
            }
            items = null;
        }
        if (this.divisionDropDownList) {
            //console.log(" this.divisionDropDownList.value()", this.divisionDropDownList.value(), this.Alert.DivisionCode);
            items = this.divisionDropDownList.dataSource.data();
            if ((items && items.length == 1 && this.Alert.DivisionCode !== "") || (!this.Alert.DivisionCode || this.Alert.DivisionCode == "")) {
                setTimeout(function () {
                    me.divisionDropDownList.enable(false);
                }, 0);
            }
            items = null;
        }
        if (this.productDropDownList) {
            items = this.productDropDownList.dataSource.data();
            if ((items && items.length == 1 && this.Alert.ProductCode !== "")) {
                setTimeout(function () {
                    me.productDropDownList.enable(false);
                }, 0);
            }
            items = null;
        }
        if (this.jobDropDownList) {
            items = this.jobDropDownList.dataSource.data();
            if ((items && items.length == 1 && this.Alert.JobNumber > 0)) {
                setTimeout(function () {
                    me.jobDropDownList.enable(false);
                }, 0);
                if (versionChecked == false) {
                    me.getSoftwareVersions();
                }
            }
            items = null;
        }
        if (this.jobComponentDropDownList) {
            items = this.jobComponentDropDownList.dataSource.data();
            if ((items && items.length == 1 && this.Alert.JobComponentNumber > 0)) {
                setTimeout(function () {
                    me.jobComponentDropDownList.enable(false);
                }, 0);
                me.getSoftwareVersions();
                versionChecked = true;
            }
            items = null;
        }
    }

    checkForSchedule() {
        var hasSchedule = false;
        if (this.jobComponentDropDownList) {
            let item = this.jobComponentDropDownList.dataItem(this.jobComponentDropDownList.select());
            if (item) {
                hasSchedule = item.HasSchedule;
            }
        }
        this.Alert.HasSchedule = hasSchedule;
    }
    checkClearJob(clientCode: string, divisionCode: string | boolean, productCode: string | boolean) {
        //try {
        //    var clearJob = true;
        //    //console.log(this.jobDropDownList.select())
        //    var job = this.jobDropDownList.dataItem(this.jobDropDownList.select());
        //    if (job) {
        //        clearJob = false;
        //        if (job.ClientCode !== clientCode) {
        //            clearJob = true;
        //        }
        //        if (divisionCode !== false) {
        //            if (job.DivisionCode !== divisionCode) {
        //                clearJob = true;
        //            }
        //        }
        //        if (productCode !== false) {
        //            if (job.ProductCode !== productCode) {
        //                clearJob = true;
        //            }
        //        }
        //    }
        //    if (clearJob) {
        //        this.Alert.JobNumber = null;
        //        this.jobDropDownList.value(null);
        //        this.Alert.JobComponentNumber = null;
        //        this.jobComponentDropDownList.value(null);
        //    }
        //} catch (e) {
        //    //console.log("checkClearJob Error: ", e)
        //}
    }

    setFilterFromOffice() {
        let filters = [], filter = {};
        let me = this;
        if (this.officeDropDownList) {
            var oCode;
            var oMatch = false;
            oCode = this.officeDropDownList.value();
            if (this.clientsDataSource.filter() && this.clientsDataSource.filter().filters.length > 0) {
                for (var i = 0; i < this.clientsDataSource.filter().filters.length; i++) {
                    var oFilter: any = this.clientsDataSource.filter().filters[i];
                    if (oFilter.field === 'OfficeCode') {
                        if (oFilter.value === oCode) {
                            oMatch = true;
                        }
                    }
                }
            }
            if (!oMatch) {
                if (oCode) {
                    try {
                        filters.push({ field: "OfficeCode", operator: "eq", value: oCode });
                    } catch (e) { }
                    if (this.clientDropDownList.value()) {
                        try {
                            filters.push({ field: "ClientCode", operator: "eq", value: this.clientDropDownList.value() });
                        } catch (e) { }
                        if (this.divisionDropDownList.value()) {
                            try {
                                filters.push({ field: "DivisionCode", operator: "eq", value: this.divisionDropDownList.value() });
                            } catch (e) { }
                            if (this.productDropDownList.value()) {
                                try {
                                    filters.push({ field: "ProductCode", operator: "eq", value: this.productDropDownList.value() });
                                } catch (e) { }
                            }
                        }
                    }
                    filter = {
                        logic: 'and',
                        filters: filters
                    };
                    //console.log("office filter", filter);
                    this.clientsDataSource.filter(filter);
                    this.clientDropDownList.setDataSource(this.clientsDataSource);
                    me.checkSingleClient(oCode);
                }
            }
        }
    }
    setJobFilters() {
        //console.log("setJobFilters");
        let filters = [], filter = {};
        if (this.clientDropDownList) {
            var cCode, dCode, pCode;
            var cMatch = false,
                dMatch = false,
                pMatch = false;
            cCode = this.clientDropDownList.value();
            dCode = this.divisionDropDownList.value();
            pCode = this.productDropDownList.value();
            if (this.jobsDataSource.filter() && this.jobsDataSource.filter().filters.length > 0) {
                for (var i = 0; i < this.jobsDataSource.filter().filters.length; i++) {
                    var cFilter: any = this.jobsDataSource.filter().filters[i];
                    if (cFilter.field === 'ClientCode') {
                        if (cFilter.value === cCode) {
                            cMatch = true;
                        }
                    }
                    if (cFilter.field === 'DivisionCode') {
                        if (cFilter.value === dCode) {
                            dMatch = true;
                        }
                    }
                    if (cFilter.field === 'ProductCode') {
                        if (cFilter.value === pCode) {
                            pMatch = true;
                        }
                    }
                }
            }
            if (!cMatch || !dMatch || !pMatch) {
                if (this.clientDropDownList.value()) {
                    filters.push({ field: "ClientCode", operator: "eq", value: this.clientDropDownList.value() });
                    if (this.divisionDropDownList.value()) {
                        filters.push({ field: "DivisionCode", operator: "eq", value: this.divisionDropDownList.value() });
                        if (this.productDropDownList.value()) {
                            filters.push({ field: "ProductCode", operator: "eq", value: this.productDropDownList.value() });
                        }
                    }
                }
                filter = {
                    logic: 'and',
                    filters: filters
                };
                this.jobsDataSource.filter(filter);
                this.jobDropDownList.setDataSource(this.jobsDataSource);
            }
        }
    }

    lastClicked: string = "";
    jobClicked: boolean = false;

    officeOnCascade(e) {
        //if (e) {
        //    //console.log("officeOnCascade");
        //    //if (typeof e.userTriggered === 'undefined') {
        //    //    if (!this.officeDropDownList) {
        //    //        return;
        //    //    }
        //    //}
        //    //var isUserTrig = false;
        //    //isUserTrig = e.userTriggered;
        //    //if (isUserTrig == undefined || isUserTrig == false) {
        //    //    return;
        //    //}
        //    let sender: kendo.ui.DropDownList = e.sender;
        //    let me = this;
        //    //window.setTimeout(function () {
        //    //    me.Alert.ClientCode = null
        //    //    if (me.clientDropDownList) {
        //    //        me.clientDropDownList.value(null);
        //    //    }
        //    //}, 0);
        //    //window.setTimeout(function () {
        //    //    me.Alert.DivisionCode = null
        //    //    if (me.divisionDropDownList) {
        //    //        me.divisionDropDownList.value(null);
        //    //        me.divisionDropDownList.enable(false);
        //    //    }
        //    //}, 0);
        //    //window.setTimeout(function () {
        //    //    me.Alert.ProductCode = null
        //    //    if (me.productDropDownList) {
        //    //        me.productDropDownList.value(null);
        //    //        me.productDropDownList.enable(false);
        //    //    }
        //    //}, 0);
        //    //if (sender.value() !== '') {
        //    //    window.setTimeout(function () {
        //    //        me.setFilterFromOffice();
        //    //    }, 0);
        //    //}
        //}
    }
    officeChanged(e) {
        let me = this;
        //console.log("officeChanged", me.Alert);
        me.Alert.ClientCode = "";
        me.Alert.DivisionCode = "";
        me.Alert.ProductCode = "";
        me.Alert.JobNumber = 0;
        me.Alert.JobComponentNumber = 0;
        me.Alert.TaskSequenceNumber = -1;
        me.Alert.ClientName = "";
        me.Alert.DivisionName = "";
        me.Alert.ProductName = "";
        me.Alert.JobDescription = "";
        me.Alert.JobComponentDescription = "";
        me.divisionDropDownList.value(null);
        me.divisionDropDownList.enable(false);
        me.productDropDownList.value(null);
        me.productDropDownList.enable(false);
        me.jobDropDownList.value(null);
        me.jobDropDownList.enable(true);
        me.jobComponentDropDownList.value(null);
        me.jobComponentDropDownList.enable(false);
        me.refreshClients();
        me.refreshJobs();
        //console.log("OFF VAL?", me.Alert.OfficeCode)
        //if (this.officeDropDownList) {
        //    //var oCode;
        //    //var oMatch = false;
        //    //oCode = this.officeDropDownList.value();
        //    //console.log("officeChanged", oCode, this.jobsDataSource.filter());
        //    //if (this.jobsDataSource.filter() && this.jobsDataSource.filter().filters.length > 0) {
        //    //    //console.log("officeChanged this.jobsDataSource.filter().filters", this.jobsDataSource.filter().filters);
        //    //}
        //    //if (oCode) {

        //    //} else {

        //    //}
        //}
    }
    officeOnOpen(e) {
        let me = this;
        me.lastClicked = "office";
        me.jobClicked = false;
    }

    clientOnCascade(e) {
        //console.log("clientOnCascade")
        if (e) {
            //if (typeof e.userTriggered === 'undefined') {
            //    if (!this.clientDropDownList) {
            //        return;
            //    }
            //}
            //var isUserTrig = false;
            //isUserTrig = e.userTriggered;
            //if (isUserTrig == undefined || isUserTrig == false) {
            //    return;
            //}
            //console.log("clientOnCascade user trig", isUserTrig)
            //console.log("clientOnCascade");
            //let sender: kendo.ui.DropDownList = e.sender;
            //let me = this;
            //window.setTimeout(function () {
            //    me.Alert.DivisionCode = null
            //    if (me.divisionDropDownList) {
            //        me.divisionDropDownList.value(null);
            //    }
            //}, 0);
            //window.setTimeout(function () {
            //    me.Alert.ProductCode = null
            //    if (me.productDropDownList) {
            //        me.productDropDownList.value(null);
            //    }
            //}, 0);
            //console.log("clientOnCascade", e.userTriggered, this.clientDropDownList, sender.value())
            //this.checkClearJob(sender.value(), false, false);
            ////this.setJobFilters();
            //if (sender.value() !== '') {
            //    window.setTimeout(function () {
            //        me.checkSingleDivision(sender.value());
            //    }, 0);
            //}

        }
    }
    clientChanged(e) {
        //console.log("clientChanged");
        let me = this;
        if (me.lastClicked == "office" || me.lastClicked == "client") {
            me.jobClicked = false;
            window.setTimeout(function () {
                me.Alert.DivisionCode = "";
                me.Alert.ProductCode = "";
                me.Alert.JobNumber = 0;
                me.Alert.JobComponentNumber = 0;
                me.Alert.TaskSequenceNumber = -1;
                me.divisionDropDownList.value(null);
                me.productDropDownList.value(null);
                me.jobDropDownList.value(null);
                me.jobComponentDropDownList.value(null);
            }, 0);
            if (me.Alert.ClientCode != "") {
                var item = this.clientDropDownList.select();
                var dataItem = <any>this.clientDropDownList.dataItem(item);
                if (dataItem && this.Alert) {
                    if (dataItem.ClientCode) {
                        this.Alert.ClientCode = dataItem.ClientCode;
                    }
                    if (dataItem.ClientName) {
                        this.Alert.ClientName = dataItem.ClientName;
                    }
                }
                me.refreshDivisions();
                me.divisionDropDownList.enable(true);
            } else {
                this.lastClicked = "";
                me.divisionDropDownList.enable(false);
                me.productDropDownList.enable(false);
                me.jobComponentDropDownList.enable(false);
                window.setTimeout(function (e) {
                    me.refreshJobs();
                }, 200);
            }
            //this.refreshRecipients();
        }
    }
    clientOnOpen(e) {
        //console.log("clientOnOpen")
        let me = this;
        me.lastClicked = "client";
        me.jobClicked = false;
    }

    divisionOnCascade(e) {
        //console.log("divisionOnCascade")
        //if (e) {
        //    if (typeof e.userTriggered === 'undefined') {
        //        if (!this.divisionDropDownList) {
        //            return;
        //        }
        //    }
        //    var isUserTrig = false;
        //    isUserTrig = e.userTriggered;
        //    if (isUserTrig == undefined || isUserTrig == false) {
        //        return;
        //    }
        //    //console.log("divisionOnCascade user trig", isUserTrig)
        //    //console.log("divisionOnCascade");
        //    let sender: kendo.ui.DropDownList = e.sender;
        //    let me = this;
        //    window.setTimeout(function () {
        //        me.Alert.ProductCode = null
        //        if (me.productDropDownList) {
        //            me.productDropDownList.value(null);
        //        }
        //    }, 0);
        //    //console.log("divisionOnCascade", e.userTriggered, this.divisionDropDownList)
        //    //this.checkClearJob(this.clientDropDownList.value(), sender.value(), false);
        //    //me.setJobFilters();
        //    if (sender.value() !== '') {
        //        window.setTimeout(function () {
        //            me.checkSingleProduct(me.clientDropDownList.value(), me.divisionDropDownList.value());
        //        }, 0);
        //    }
        //}
    }
    divisionChanged(e) {
        //console.log("divisionChanged")
        let me = this;
        //console.log("divisionChanged", me.lastClicked);
        if (me.lastClicked == "" || me.lastClicked == "client" || me.lastClicked == "division") {
            me.jobClicked = false;
            //if (me.Alert.JobNumber == 0) {
            window.setTimeout(function () {
                me.Alert.ProductCode = "";
                me.Alert.JobNumber = 0;
                me.Alert.JobComponentNumber = 0;
                me.Alert.TaskSequenceNumber = -1;
                me.productDropDownList.value(null);
                me.jobDropDownList.value(null);
                me.jobComponentDropDownList.value(null);
            }, 0);
            //}
            me.refreshProducts();
            if (me.Alert.ClientCode != "" && me.Alert.DivisionCode != "") {
                var item = me.divisionDropDownList.select();
                var dataItem = <any>me.divisionDropDownList.dataItem(item);
                if (dataItem && me.Alert) {
                    if (dataItem.DivisionCode) {
                        me.Alert.DivisionCode = dataItem.DivisionCode;
                    }
                    if (dataItem.DivisionName) {
                        me.Alert.DivisionName = dataItem.DivisionName;
                    }
                }
                me.productDropDownList.enable(true);
            } else {
                me.productDropDownList.enable(false);
                me.jobComponentDropDownList.enable(false);
            }
        }
    }
    divisionOnOpen(e) {
        let me = this;
        me.lastClicked = "division";
        me.jobClicked = false;
        //console.log("divisionOnOpen");
    }

    productOnCascade(e) {
        if (e) {
            //let sender: kendo.ui.DropDownList = e.sender;
            //let me = this;
            //var clVal;
            //var divVal;
            //if (typeof e.userTriggered === 'undefined') {
            //    if (!this.productDropDownList) {
            //        if (this.clientDropDownList) {
            //            clVal = this.clientDropDownList.value()
            //        } else {
            //            clVal = false;
            //        }
            //        if (this.divisionDropDownList) {
            //            divVal = this.divisionDropDownList.value()
            //        } else {
            //            divVal = false;
            //        }
            //        this.checkClearJob(clVal, divVal, sender.value());
            //        this.setJobFilters();
            //        return;
            //    }
            //}
            ////console.log("productOnCascade");
            //var isUserTrig = false;
            //isUserTrig = e.userTriggered;
            //if (isUserTrig == undefined || isUserTrig == false) {
            //    this.checkClearJob(this.clientDropDownList.value(), this.divisionDropDownList.value(), sender.value());
            //    this.setJobFilters();
            //    return;
            //}
            //this.checkClearJob(this.clientDropDownList.value(), this.divisionDropDownList.value(), sender.value());
            //if (sender.value() !== '') {
            //    window.setTimeout(function () {
            //        me.checkSingleJob(me.clientDropDownList.value(), me.divisionDropDownList.value(), me.productDropDownList.value());
            //    }, 0);
            //} else {
            //    if (this.jobDropDownList) {
            //        this.Alert.JobNumber = null;
            //        this.jobDropDownList.value(null);
            //    }
            //}
        }
    }
    productChanged(e) {
        let me = this;
        //console.log("productChanged");
        //if (me.jobClicked == false && (me.lastClicked == "" || me.lastClicked == "product" || me.lastClicked == "client")) {
        window.setTimeout(function () {
            me.Alert.JobNumber = 0;
            me.Alert.JobComponentNumber = 0;
            me.Alert.TaskSequenceNumber = -1;
            me.jobDropDownList.value(null);
            me.jobComponentDropDownList.value(null);
        }, 0);
        if (me.Alert.ClientCode != "" && me.Alert.DivisionCode != "" && me.Alert.ProductCode != "") {
            var item = me.productDropDownList.select();
            var dataItem = <any>me.productDropDownList.dataItem(item);
            if (dataItem && me.Alert) {
                if (dataItem.ProductCode) {
                    me.Alert.ProductCode = dataItem.ProductCode;
                }
                if (dataItem.ProductName) {
                    me.Alert.ProductName = dataItem.ProductName;
                }
            }
        } else {
            me.jobComponentDropDownList.enable(false);
        }
        me.refreshJobs();
        me.jobDropDownList.enable(true);
        //me.refreshRecipients();
        //}
    }
    productOnOpen(e) {
        let me = this;
        me.lastClicked = "product";
        me.jobClicked = false;
    }

    jobOnCascade(e) {
        //if (typeof e.userTriggered === 'undefined') {
        //    if (!this.jobDropDownList) {
        //        return;
        //    }
        //}
        //var isUserTrig = false;
        //isUserTrig = e.userTriggered;
        //if (isUserTrig == undefined || isUserTrig == false) {
        //    return;
        //}
        ////console.log("jobOnCascade");
        //let sender: kendo.ui.DropDownList = e.sender;
        //let me = this;
        //if (sender.value() !== '') {
        //    let job = sender.dataItem(sender.select());
        //    if (this.clientDropDownList) {
        //        this.clientDropDownList.value(job.ClientCode);
        //        window.setTimeout(function () {
        //            if (me.divisionDropDownList) {
        //                me.divisionDropDownList.enable(true);
        //                me.Alert.DivisionCode = job.DivisionCode;
        //                me.divisionDropDownList.value(job.DivisionCode);
        //                me.productDropDownList.dataSource.filter({ field: 'DivisionCode', operator: 'eq', value: job.DivisionCode });
        //            }
        //            window.setTimeout(function () {
        //                if (me.productDropDownList) {
        //                    me.productDropDownList.enable(true);
        //                    me.Alert.ProductCode = job.ProductCode;
        //                    me.productDropDownList.value(job.ProductCode);
        //                }
        //                window.setTimeout(function () {
        //                    if (me.jobDropDownList) {
        //                        me.Alert.JobNumber = job.JobNumber;
        //                        me.jobDropDownList.value(job.JobNumber);
        //                    }
        //                }, 0);
        //            }, 0);
        //        }, 0);
        //    }
        //}
    }
    jobChanged(e) {
        let me = this;
        //console.log("jobChanged", me.lastClicked);
        window.setTimeout(function () {
            me.Alert.JobComponentNumber = 0;
            me.Alert.TaskSequenceNumber = -1;
            me.jobComponentDropDownList.value(null);
        }, 0);
        if (me.lastClicked == "" || me.lastClicked == "job") {
            //backfill
            var item = me.jobDropDownList.select();
            if (item > 0) {
                var dataItem = <any>me.jobDropDownList.dataItem(item);

                if (me.Alert.OfficeCode != dataItem.OfficeCode) {
                    me.Alert.OfficeCode = dataItem.OfficeCode;

                    me.clientsDataSource.read().then(() => {
                        if (me.Alert.ClientCode != dataItem.ClientCode) { me.Alert.ClientCode = dataItem.ClientCode; }
                        if (me.Alert.DivisionCode != dataItem.DivisionCode) {
                            me.divisionsDataSource.read().then(() => {
                                me.Alert.DivisionCode = dataItem.DivisionCode;
                                if (me.Alert.ProductCode != dataItem.ProductCode) {
                                    me.productsDataSource.read().then(() => {
                                        me.Alert.ProductCode = dataItem.ProductCode;
                                    });
                                }
                            });
                        }
                        else if (me.Alert.ProductCode != dataItem.ProductCode) {
                            me.productsDataSource.read().then(() => {
                                me.Alert.ProductCode = dataItem.ProductCode;
                            });
                        }

                    });
                }
                else {
                    if (me.Alert.ClientCode != dataItem.ClientCode) { me.Alert.ClientCode = dataItem.ClientCode; }
                    if (me.Alert.DivisionCode != dataItem.DivisionCode) {
                        me.divisionsDataSource.read().then(() => {
                            me.Alert.DivisionCode = dataItem.DivisionCode;
                            if (me.Alert.ProductCode != dataItem.ProductCode) {
                                me.productsDataSource.read().then(() => {
                                    me.Alert.ProductCode = dataItem.ProductCode;
                                });
                            }
                        });
                    }
                    else if (me.Alert.ProductCode != dataItem.ProductCode) {
                        me.productsDataSource.read().then(() => {
                            me.Alert.ProductCode = dataItem.ProductCode;
                        });
                    }

                }

                if (me.Alert.JobNumber != parseInt(dataItem.JobNumber)) { me.Alert.JobNumber = parseInt(dataItem.JobNumber); }
                me.Alert.JobComponentNumber = 0;
                me.Alert.SprintID = 0
                me.checkForBoard();
                //me.refreshJobComponents();
                //window.setTimeout(function () {
                me.componentsDataSource.read().then(() => {
                    var data = me.componentsDataSource.data();
                    if (data && data.length == 1) {
                        me.Alert.JobComponentNumber = data[0].JobComponentNumber * 1;
                        me.Alert.JobComponentDescription = data[0].JobComponentDescription;
                        me.getDefaultWorkflowTemplate();
                        if (me.jobComponentDropDownList) {
                            try {
                                var jobComponentString: any = me.Alert.JobComponentNumber.toString;
                                me.jobComponentDropDownList.value(jobComponentString);
                                me.jobComponentDropDownList.text(me.Alert.JobComponentDescription);
                                me.jobComponentDropDownList.select(1);
                            } catch (e) {
                            }
                        }
                        me.checkForBoard();
                    }

                    me.setDivisionProductAndComponent();


                });
                //}, 10);

                //if (me.Alert.ClientCode != "" || me.Alert.DivisionCode != "" || me.Alert.ProductCode != "") {
                //    let filters = [], filter = {};
                //    if (me.Alert.ClientCode != "") {
                //        filters.push({ field: "ClientCode", operator: "eq", value: me.Alert.ClientCode });
                //        if (me.Alert.DivisionCode != "") {
                //            filters.push({ field: "DivisionCode", operator: "eq", value: me.Alert.DivisionCode });
                //            if (me.Alert.ProductCode != "") {
                //                filters.push({ field: "ProductCode", operator: "eq", value: me.Alert.ProductCode });
                //            }
                //        }
                //    }
                //    filter = {
                //        logic: 'and',
                //        filters: filters
                //    };
                //    //me.jobsDataSource.filter(filter);
                //    //me.jobDropDownList.setDataSource(me.jobsDataSource);
                //} else {
                //    me.jobsDataSource.filter({});
                //}
                //me.setJobFilters();
                ////if (me.Alert.ClientCode != "" || me.Alert.DivisionCode != "" || me.Alert.ProductCode != "") {
                ////    //console.log("RELOAD FOR FILTER!!!")
                ////    me.jobsDataSource = new kendo.data.DataSource({
                ////        transport: {
                ////            read: {
                ////                url: 'Desktop/Alert/GetNewAssignmentJobList',
                ////                data: function () {
                ////                    return {
                ////                        SprintID: ((me.Alert.SprintID && me.Alert.SprintID > 0) ? me.Alert.SprintID : 0),
                ////                        OfficeCode: ((me.Alert.OfficeCode && me.Alert.OfficeCode != "") ? me.Alert.OfficeCode : ""),
                ////                        ClientCode: ((me.Alert.ClientCode && me.Alert.ClientCode != "") ? me.Alert.ClientCode : ""),
                ////                        DivisionCode: ((me.Alert.DivisionCode && me.Alert.DivisionCode != "") ? me.Alert.DivisionCode : ""),
                ////                        ProductCode: ((me.Alert.ProductCode && me.Alert.ProductCode != "") ? me.Alert.ProductCode : "")
                ////                    }
                ////                }
                ////            }
                ////        }
                ////    });
                ////    me.jobsDataSource.fetch();
                ////    me.jobDropDownList.setDataSource(me.jobsDataSource);
                ////}
            }
        } else {
            me.refreshJobComponents();
        }
        me.getSoftwareVersions();
        me.refreshRecipients();
        if (me.Alert.JobNumber && me.Alert.JobNumber > 0) {
            //console.log("job number")
        } else {
            //console.log("no job number")
            window.setTimeout(function () {
                //me.divisionDropDownList.enable(false);
                //me.productDropDownList.enable(false);
                me.jobComponentDropDownList.enable(false);
                me.checkForSchedule();
            }, 1000);
            //me.productDropDownList.enable(false);
        }
        //console.log("jobChanged", me.lastClicked);
        //me.jobClicked = true;
        //window.setTimeout(function () {
        //    me.Alert.JobComponentNumber = 0;
        //    me.Alert.TaskSequenceNumber = -1;
        //    me.jobComponentDropDownList.value(null);
        //}, 0);
        //if (me.Alert.JobNumber && me.Alert.JobNumber > 0) {
        //    var item = me.jobDropDownList.select();
        //    var dataItem = <any>me.jobDropDownList.dataItem(item);
        //    if (dataItem && me.Alert) {
        //        window.setTimeout(function () {
        //            me.Alert.OfficeCode = dataItem.OfficeCode;
        //            me.Alert.OfficeName = dataItem.OfficeName;
        //        }, 0);
        //        window.setTimeout(function () {
        //            me.Alert.ClientCode = dataItem.ClientCode;
        //            me.Alert.ClientName = dataItem.ClientName;
        //        }, 0);
        //        window.setTimeout(function () {
        //            me.Alert.DivisionCode = dataItem.DivisionCode;
        //            me.Alert.DivisionName = dataItem.DivisionName;
        //            //console.log("me.Alert.DivisionCode", me.Alert.DivisionCode);
        //        }, 0);
        //        window.setTimeout(function () {
        //            me.Alert.ProductCode = dataItem.ProductCode;
        //            me.Alert.ProductName = dataItem.ProductName;
        //        }, 0);
        //        window.setTimeout(function () {
        //            //me.Alert.JobNumber = dataItem.JobNumber;
        //            me.Alert.JobDescription = dataItem.JobDescription;
        //        }, 0);
        //        //console.log("jobChanged", dataItem.OfficeCode, me.Alert.OfficeCode);
        //        //console.log("jobChanged", dataItem.ClientCode, me.Alert.ClientCode);
        //        //console.log("jobChanged", dataItem.DivisionCode, me.Alert.DivisionCode);
        //        //console.log("jobChanged", dataItem.ProductCode, me.Alert.ProductCode);
        //        if (dataItem.DivisionCode !== me.Alert.DivisionCode || me.Alert.DivisionCode == undefined) {
        //            me.Alert.DivisionCode = dataItem.DivisionCode;
        //            window.setTimeout(function () {
        //                //console.log("jobChanged refreshDivisions", me.lastClicked);
        //                me.refreshDivisions(me.Alert.DivisionCode);
        //            }, 500);
        //        }
        //    }
        //    me.jobComponentDropDownList.enable(true);
        //    window.setTimeout(function () {
        //        me.refreshJobComponents();
        //    }, 0);
        //    window.setTimeout(function () {
        //        me.getSoftwareVersions();
        //    }, 10);
        //} else {
        //    me.checkForBoard();
        //}
        //me.refreshRecipients();
        //me.checkForBoard();
    }
    jobOnOpen(e) {
        let me = this;
        me.lastClicked = "job";
        me.jobClicked = true;
    }

    componentOnCascade(e) {
        //console.log("componentOnCascade");
        //this.jobComponentDropDownList.enable(true);
    }
    componentChanged(e) {
        let me = this;
        if (me.lastClicked == "" || me.lastClicked == "component") {
            me.checkForSchedule();
            me.getDefaultWorkflowTemplate();
            if (me.jobComponentDropDownList) {
                var item = me.jobComponentDropDownList.select();
                var dataItem = <any>me.jobComponentDropDownList.dataItem(item);
                if (dataItem && me.Alert) {
                    //console.log("componentChanged dataItem", dataItem)
                    //if (dataItem.OfficeCode) {
                    //    me.Alert.OfficeCode = dataItem.OfficeCode;
                    //}
                    //if (dataItem.ClientCode) {
                    //    me.Alert.ClientCode = dataItem.ClientCode;
                    //}
                    //if (dataItem.ClientName) {
                    //    me.Alert.ClientName = dataItem.ClientName;
                    //}
                    //if (dataItem.DivisionCode) {
                    //    me.Alert.DivisionCode = dataItem.DivisionCode;
                    //}
                    //if (dataItem.DivisionName) {
                    //    me.Alert.DivisionName = dataItem.DivisionName;
                    //}
                    //if (dataItem.ProductCode) {
                    //    me.Alert.ProductCode = dataItem.ProductCode;
                    //}
                    //if (dataItem.ProductName) {
                    //    me.Alert.ProductName = dataItem.ProductName;
                    //}
                    //if (dataItem.JobNumber) {
                    //    me.Alert.JobNumber = dataItem.JobNumber;
                    //}
                    //if (dataItem.JobDescription) {
                    //    me.Alert.JobDescription = dataItem.JobDescription;
                    //}
                    //if (dataItem.JobComponentNumber) {
                    //    me.Alert.JobComponentNumber = dataItem.JobComponentNumber;
                    //}
                    if (dataItem.JobComponentDescription) {
                        me.Alert.JobComponentDescription = dataItem.JobComponentDescription;
                    }
                }
            }
            //me.refreshRecipients();
            me.checkForBoard();
        }

    }
    componentOnOpen(e) {
        let me = this;
        me.lastClicked = "component";
        me.jobClicked = false;
    }

    taskOnCascade(e) {
    }

    filterClientDropDownList(officeCode: string) {

    }
    filterDivisionDropDownList(clientCode: string) {

    }
    filterProductDropDownList(clientCode: string, divisionCode: string) {

    }
    filterJobDropDownList(clientCode: string, divisionCode: string, productCode: string) {

    }

    alertAssignmentTemplateChange(e) {
        if (this.alertAssignmentTemplateDropDownList) {
            var item = this.alertAssignmentTemplateDropDownList.select();
            var dataItem = <any>this.alertAssignmentTemplateDropDownList.dataItem(item);
            if (dataItem && this.Alert) {
                if (isNaN(dataItem.ID) === true) {
                    //console.log('AlertAssignmentTemplateID set to null');
                    this.Alert.AlertAssignmentTemplateID = null;
                    this.Alert.AlertAssignmentTemplateName = "N/A";
                    //console.log('alertStateID set to null');
                    this.Alert.AlertStateID = null;
                    this.Alert.AlertStateName = "N/A";
                    this.Alert.Assignees = [];
                } else {
                    this.Alert.AlertAssignmentTemplateName = dataItem.Name;
                    //console.log('alertStateID set to null');
                    this.Alert.AlertStateID = null;
                    this.Alert.AlertStateName = "N/A";
                    this.Alert.Assignees = [];
                    this.eventAggregator.publish('loadlistbox');
                }
                this.setDefaultSubject("N/A");
            }
        }
    }
    getDefaultWorkflowTemplate() {
        //console.log('getDefaultWorkflowTemplate()');
        if (this.defaultWorkflowTemplate.JobNumber !== this.Alert.JobNumber || this.defaultWorkflowTemplate.JobComponentNumber !== this.Alert.JobComponentNumber) {
            if (this.Alert.JobNumber > 0 && this.Alert.JobComponentNumber > 0) {
                this.defaultWorkflowTemplate.JobNumber = this.Alert.JobNumber;
                this.defaultWorkflowTemplate.JobComponentNumber = this.Alert.JobComponentNumber;
                this.service.getDefaultWorkflowTemplate(this.Alert.JobNumber, this.Alert.JobComponentNumber).then(response => {
                    if (!isNaN(response.content.DefaultWorkflowTemplate)) {
                        this.defaultWorkflowTemplate.AlertAssignmentTemplateID = Number(response.content.DefaultWorkflowTemplate);
                        if (this.isRouted === true) {
                            this.Alert.AlertAssignmentTemplateID = Number(response.content.DefaultWorkflowTemplate);
                            this.Alert.AlertAssignmentTemplateName = response.content.DefaultWorkflowName;
                            this.setDefaultSubject('N/A');
                        }
                    }
                });
            }
        } else {
            if (this.isRouted === true) {
                this.Alert.AlertAssignmentTemplateID = this.defaultWorkflowTemplate.AlertAssignmentTemplateID;
            } else {
                //console.log('AlertAssignmentTemplateID set to null');
                this.Alert.AlertAssignmentTemplateID = null;
            }
        }
    }
    refreshTypes() {
        if (this.alertCategoriesDropDownList) {
            this.alertCategoriesDropDownList.refresh();
        }
    }
    jobComponentNumberChanged(newValue, oldValue) {
        this.checkTaskEnabled();
        this.Alert.LinkedDocuments = [];
        this.existingDocumentsDataSource.data([]);
    }
    checkTaskEnabled() {
        this.taskFunctionEnabled = !this.excludeTasks && this.isBoardTask && this.Alert.JobNumber > 0 && this.Alert.JobComponentNumber > 0 ? true : false;
    }
    checkIsBoardTask() {
        this.isBoardTask = this.Alert.AlertCategoryID === 71 ? true : false;
    }
    checkIsProof() {
        let me = this;
        me.isProof = me.Alert.AlertCategoryID === 79 ? true : false;
    }
    filterComponents() {
        //this.componentsDataSource.filter({ field: "JobNumber", operator: "eq", value: this.Alert.JobNumber });
    }
    toolbarReady(e) {
    }
    alertTemplateStatesListboxChange() {
        var canSelectEmployee = false;
        if (this.alertTemplateStatesListBox) {
            var item = this.alertTemplateStatesListBox.select();
            var dataItem = <any>this.alertTemplateStatesListBox.dataItem(item);
            //console.log("dataItem", dataItem)
            this.Alert.AssignedEmployeeCode = '';
            //this.Alert.Recipients = [];
            if (dataItem) {
                canSelectEmployee = true;
                //if (this.Alert.AlertStateID !== dataItem.ID) {
                this.Alert.AlertStateID = dataItem.ID;
                if (this.isRouted == true) {
                    this.alertTemplateStateEmployeesDataSourceMultiSelectRouted.read().then(() => {
                        var hasAssignee = false;
                        if (this.alertTemplateStateEmployeesDataSourceMultiSelectRouted.data().length == 1) {
                            var singleEmp = this.alertTemplateStateEmployeesDataSourceMultiSelectRouted.data()[0];
                            if (singleEmp) {
                                this.Alert.Assignees = [];
                                this.Alert.Assignees[0] = singleEmp.Code;
                            }
                        } else {
                            this.Alert.Assignees = [];
                            var emp;
                            for (var i = 0; i < this.alertTemplateStateEmployeesDataSourceMultiSelectRouted.data().length; i++) {
                                emp = this.alertTemplateStateEmployeesDataSourceMultiSelectRouted.data()[i];
                                if (emp) {
                                    if (this.jobRequestDefaultAssign && this.jobRequestDefaultAssign != '' && emp.Code == this.jobRequestDefaultAssign) {
                                        this.Alert.Assignees[this.Alert.Assignees.length] = emp.Code;
                                        hasAssignee = true;
                                    } else if (emp.IsDefault == true) {
                                        this.Alert.Assignees.push(emp.Code);
                                        hasAssignee = true;
                                    }
                                }
                            }
                            if (hasAssignee == false) {
                                this.Alert.Assignees = [];
                                this.Alert.AssignedEmployeeCode = "";
                            }
                        }
                    });
                    this.setDefaultSubject(dataItem.Name);
                } else {
                    this.alertTemplateStateEmployeesDataSourceMultiSelectNotRouted.read().then(() => {
                        var doesCurrentEmpExist = false;
                        for (var i = 0; i < this.alertTemplateStateEmployeesDataSourceMultiSelectNotRouted.data().length; i++) {
                            var emp = this.alertTemplateStateEmployeesDataSourceMultiSelectNotRouted.data()[i];
                            if (emp.IsDefault === true) {
                                this.Alert.AssignedEmployeeCode = emp.Code;
                                this.Alert.Assignees[this.Alert.Assignees.length] = emp.Code;
                            }
                            if (emp.Code === this.Alert.AssignedEmployeeCode) {
                                doesCurrentEmpExist = true;
                            }
                        }
                        if (!doesCurrentEmpExist) {
                            this.Alert.Assignees = [];
                            this.Alert.AssignedEmployeeCode = '';
                        }
                    });
                    this.setDefaultSubject(dataItem.Name);
                }
            }
        } else {
            this.Alert.Assignees = [];
            this.Alert.AssignedEmployeeCode = '';
        }
        //}
        if (this.assignToMultiSelectRouted) {
            this.assignToMultiSelectRouted.enable(canSelectEmployee);
            if (canSelectEmployee == false) {
                this.Alert.Assignees = [];
                this.Alert.AssignedEmployeeCode = '';
            }
        }
        //console.log("alertTemplateStatesListboxChange:this.Alert.AssignedEmployeeCode", this.Alert.AssignedEmployeeCode);
        //console.log("alertTemplateStatesListboxChange:this.Alert.Assignees", this.Alert.Assignees);
        //console.log("alertTemplateStatesListboxChange:this.Alert.Recipients", this.Alert.Recipients);
    }
    setDefaultSubject(newState) {
        //console.log("setDefaultSubject", newState, this.Alert)
        if (this.Alert) {
            if (this.Alert.AlertAssignmentTemplateName === "[Please Select]") {
                this.Alert.AlertAssignmentTemplateName = "N/A";
            }
            var defaultSubject = "";
            if (this.defaultSubjectType == "state") {
                defaultSubject = newState;
            } else if (this.defaultSubjectType === "template") {
                defaultSubject = this.Alert.AlertAssignmentTemplateName;
            } else if (this.defaultSubjectType === "templateandstate") {
                defaultSubject = this.Alert.AlertAssignmentTemplateName + " | " + newState;
            } else if (this.defaultSubjectType === "jjcts") {
                defaultSubject = "[";
                if (this.Alert.JobNumber && this.Alert.JobNumber > 0 && this.Alert.JobComponentNumber && this.Alert.JobComponentNumber > 0) {
                    defaultSubject += this.padJobNumber(this.Alert.JobNumber);
                    defaultSubject += "/";
                    defaultSubject += this.padJobComponentNumber(this.Alert.JobComponentNumber);
                    defaultSubject += " - ";
                    defaultSubject += this.Alert.JobComponentDescription;
                    defaultSubject += " | ";
                }
                defaultSubject += this.Alert.AlertAssignmentTemplateName + " | " + newState;
                defaultSubject += "]";
            }
            if (defaultSubject != "") {
                this.Alert.Subject = defaultSubject;
            }
            //console.log("alert subject", this.Alert.Subject)
        }
    }
    alertCategoriesDataBound(e) {
        var sender: kendo.ui.DropDownList = e.sender;
        this.checkAlertCategories(sender);
    }
    checkAlertCategories(alertTypeDropDownList) {
        // 70 is story, 71 is task
        let me = this;
        if (alertTypeDropDownList) {
            for (var i = 0; i < alertTypeDropDownList.items().length; i++) {
                var item = $(alertTypeDropDownList.items()[i]);
                var dataItem = alertTypeDropDownList.dataItem(item);

                //if (!this.Alert.SprintID || this.Alert.SprintID <= 0) {
                //    if (dataItem.ID === 70 || dataItem.ID === 71) {
                //        alertTypeDropDownList.dataSource.remove(dataItem);
                //    }
                //} else {

                //if (dataItem.ID === 71) {
                //    if (this.excludeTasks === true) {
                //        alertTypeDropDownList.dataSource.remove(dataItem);
                //    }
                //    //if ((Number(this.jobDropDownList.value()) > 0 && Number(this.jobComponentDropDownList.value()) > 0 && !this.Alert.HasSchedule) || this.isRouted === true) {
                //    if ((Number(this.Alert.JobNumber) > 0 && Number(this.Alert.JobComponentNumber) > 0 && !this.Alert.HasSchedule) || this.isRouted === true) {
                //        $(item).hide();
                //        if (this.Alert.AlertCategoryID === 71) {
                //            this.Alert.AlertCategoryID = null;
                //            this.checkIsBoardTask()
                //        }
                //    } else {
                //        $(item).show();
                //    }
                //}
                ////}


            }
        }
    }
    alertCategoryChanged(e) {
        var item = this.alertCategoriesDropDownList.dataItem(this.alertCategoriesDropDownList.select());
        var alertTypeID: number = null;
        //console.log("ITREM", item);
        if (item) {
            alertTypeID = item.AlertTypeID;
        }
        //console.log("2522", this.Alert)
        this.Alert.AlertTypeID = alertTypeID;
        this.checkIsBoardTask();
        this.checkIsProof();
    }
    deleteFile(file: any) {
        this.attachmentUpload.removeFileByUid(file.uid);
        this.attachmentUpload.clearFileByUid(file.uid);
        this.syncFiles();
    }
    //syncFiles() {
    //    this.files = [];
    //    for (var i = 0; i < this.attachmentUpload.getFiles().length; i++) {
    //        var file = this.attachmentUpload.getFiles()[i];
    //        this.files.push({ name: file.name, uid: file.uid });
    //    }
    //}
    descriptionReady(e) {
        var editor: kendo.ui.Editor = e;
        editor.wrapper.find("a,span, input").attr("tabindex", -1);        
    }
    boardDataBound(e) {

    }
    boardStateDataBound(e: any) {
        let me = this;
        window.setTimeout(function () {
            if (me.boardStateId) {
                me.Alert.BoardStateID = me.boardStateId
            }
            //console.log("boardStateDataBound me.Alert", me.Alert);
            var dropDownList = <kendo.ui.DropDownList>e.sender;
            if (dropDownList) {
                if (!me.Alert.BoardStateID) {
                    dropDownList.value('-1');
                }
            }
        }, 250);
    }
    linkExistingDocumentClick() {
        this.existingDocumentDialogOpen();
    }

    unlinkDoc(doc) {
        var idx = this.linkableDocuments.indexOf(doc);
        doc.Linked = false;
        this.linkableDocuments.splice(idx, 1);
        for (var i = 0; i < this.existingDocumentsGrid.items().length; i++) {
            var item: any = this.existingDocumentsGrid.items()[i];
            var dataItem: any = this.existingDocumentsGrid.dataItem(item);
            if (dataItem.ID === doc.ID) {
                $(item).removeClass('k-state-selected');
            }
        }
    }

    existingDocumentDialogOpen() {
        let me = this;

        this.setAlertLevel();

        if (!this.linkableDocuments) {
            this.linkableDocuments = [];
        }

        this.dialogService.open({ viewModel: ExistingDocumentDialog, model: { Alert: this.Alert, linkableDocuments: this.linkableDocuments }, lock: false }).whenClosed(results => {
            if (!results.wasCancelled) {
                var dataItems = results.output;


                for (var i = 0; i < dataItems.length; i++) {
                    me.linkableDocuments.push(dataItems[i]);
                }
            }
        });

    }

    uploadDocumentManagerClick(e) {
        this.service.setUploadDocumentManager(this.uploadToDocumentManager).then(response => {
        });
    }

    startDateChange() {
        var val: any = this.startDatePicker.value();
        if (!val) {
            if (this.startDatePicker) {
                val = this.startDatePicker.element.val();
                if (val) {
                    var date: any = this.parseShortDate(val);
                    if (date && date.isValid) {
                        //timeout gives bindings time to finish
                        let me = this;
                        window.setTimeout(function () {
                            me.Alert.StartDate = date.value;
                            me.setupStartDate();
                        }, 0);
                    }
                }
            }
        }
        if (this.dueDateIsBeforeStartDate(this.Alert.StartDate, this.Alert.DueDate) === true) {
            this.alert("Due date before start date.")
        }
        this.setupStartDate();
    }
    dueDateChange() {
        var val: any = this.dueDatePicker.value();
        if (!val) {
            if (this.dueDatePicker) {
                val = this.dueDatePicker.element.val();
                if (val) {
                    var date: any = this.parseShortDate(val);
                    if (date && date.isValid) {
                        //timeout gives bindings time to finish
                        let me = this;
                        window.setTimeout(function () {
                            me.Alert.DueDate = date.value;
                            me.setupDueDate();
                        }, 0);
                    }
                }
            }
        }
        if (this.dueDateIsBeforeStartDate(this.Alert.StartDate, this.Alert.DueDate) === true) {
            this.alert("Due date before start date.")
        }
        this.setupDueDate();
    }
    setupDueDate() {
        var tooltip = this.getToolTipForDueDate(this.Alert.DueDate);
        this.getCssForDatePicker(this.Alert.DueDate, 'due');
        this.dueDateTitle = tooltip;
    }
    setupStartDate() {
        var tooltip = this.getToolTipForDueDate(this.Alert.StartDate);
        this.getCssForDatePicker(this.Alert.StartDate, 'start');
        this.startDateTitle = tooltip;
    }
    getToolTipForDueDate(theDate) {
        var tooltip = '';
        if (theDate) {
            var today = new Date(new Date().toLocaleDateString());
            var weekends = [0, 6];
            var weekOut = new Date();
            weekOut = new Date(weekOut.setDate(weekOut.getDate() + 8));
            theDate = new Date(new Date(theDate).toLocaleDateString());
            if (theDate < today) {
                tooltip = 'Overdue!';
            } else if (theDate.valueOf() === today.valueOf()) {
                tooltip = 'Due today!';
            } else if (weekends.indexOf(theDate.getDay()) > -1) {
                tooltip = 'Due date is on a weekend!';
            } else if (theDate > today && theDate < weekOut) {
                tooltip = 'Due in a week!';
            }
        }
        return tooltip;
    }
    getCssForDatePicker(theDate, startOrDue) {
        var cssClass = '';
        if (theDate) {
            var today = new Date(new Date().toLocaleDateString());
            var weekends = [0, 6];
            var weekOut = new Date();
            weekOut = new Date(weekOut.setDate(weekOut.getDate() + 8));
            theDate = new Date(new Date(theDate).toLocaleDateString());
            if (theDate < today) {
                cssClass = 'standard-red';
            } else if (theDate.valueOf() === today.valueOf()) {
                cssClass = 'standard-orange';
            } else if (weekends.indexOf(theDate.getDay()) > -1) {
                cssClass = 'standard-light-grey';
            } else if (theDate > today && theDate < weekOut) {
                cssClass = 'standard-yellow';
            }
        }
        if (startOrDue == 'due') {
            this.dueDateCssName = cssClass;
        } else {
            this.startDateCssName = cssClass;
        }
        return cssClass;
    }
    datePickerOnReady(e) {
        $(e.wrapper).removeClass('standard-red').removeClass('standard-orange').removeClass('standard-light-grey').removeClass('standard-yellow');
    }

    getSoftwareBuilds() {
        if (this.Alert.Version !== '') {
            let me = this;
            this.buildDataSource = new kendo.data.DataSource({
                transport: {
                    read: {
                        url: 'Desktop/Alert/GetSoftwareBuildsByVersion',
                        data: function () {
                            return {
                                VersionID: me.Alert.Version && me.Alert.Version !== '' ? me.Alert.Version : 0
                            }
                        }
                    }
                }
            });
        } else {
            this.buildDataSource = new kendo.data.DataSource({
                data: []
            });
        }
        if (this.buildDropDownList) {
            this.buildDropDownList.setDataSource(this.buildDataSource);
        }
    }
    getSoftwareVersions() {
        if (this.softwareVersionLastSearched.JobNumber !== this.Alert.JobNumber || this.softwareVersionLastSearched.JobComponentNumber !== this.Alert.JobComponentNumber) {
            this.versionDataSource.read();
        }
    }
    versionChanged() {
        if (!this.Alert.Version || this.Alert.Version === '') {
            this.Alert.Build = '';
        }
        this.checkBuildEnabled();
        this.getSoftwareBuilds();
    }
    checkBuildEnabled() {
        this.buildEnabled = this.Alert.Version && this.Alert.Version !== '' ? true : false;
    }
    getDefaultSubjectType() {
        let me = this;
        return this.service.getDefaultSubjectType().then(response => {
            if (response.content) {
                me.defaultSubjectType = response.content
            }
        }).then(() => {
        });
    }
    refreshClients() {
        //console.log("refreshClients");
        let me = this;
        if (me.Alert) {
            this.clientsDataSource = new kendo.data.DataSource({
                transport: {
                    read: {
                        url: 'Desktop/Alert/GetNewAssignmentClientList',
                        data: function () {
                            return {
                                SprintID: ((me.Alert.SprintID && me.Alert.SprintID > 0) ? me.Alert.SprintID : 0),
                                OfficeCode: ((me.Alert.OfficeCode && me.Alert.OfficeCode != "") ? me.Alert.OfficeCode : "")
                            }
                        }
                    }
                },
                change: function () {
                    var data = this.data();
                    if (data && data.length == 1) {
                        me.Alert.ClientCode = data[0].ClientCode;
                        me.Alert.ClientName = data[0].ClientName;
                        if (me.clientDropDownList) {
                            me.clientDropDownList.value(me.Alert.ClientCode);
                            me.clientDropDownList.text(me.Alert.ClientName);
                        }
                        //me.refreshDivisions("");
                    }
                },
                requestEnd: function (e) {
                    var response = e.response;
                    var type = e.type;
                }
            });
        } else {
            this.clientsDataSource = new kendo.data.DataSource({
                data: []
            });
        }
        if (this.clientDropDownList) {
            this.clientDropDownList.setDataSource(this.clientsDataSource);
        }
    }
    refreshDivisions() {
        let me = this;
        //console.log("refreshDivisions:me.Alert.ClientCode", me.Alert.ClientCode);
        if (me.Alert && me.Alert.ClientCode && me.Alert.ClientCode != "") {
            me.divisionsDataSource = new kendo.data.DataSource({
                transport: {
                    read: {
                        url: 'Desktop/Alert/GetNewAssignmentDivisionList',
                        data: function () {
                            return {
                                SprintID: ((me.Alert.SprintID && me.Alert.SprintID > 0) ? me.Alert.SprintID : 0),
                                OfficeCode: ((me.Alert.OfficeCode && me.Alert.OfficeCode != "") ? me.Alert.OfficeCode : ""),
                                ClientCode: ((me.Alert.ClientCode && me.Alert.ClientCode != "") ? me.Alert.ClientCode : "")
                            }
                        }
                    }
                },
                change: function () {
                    var data = this.data();
                    if (data && data.length == 1) {
                        if (me.Alert.DivisionCode != data[0].DivisionCode) {
                            me.Alert.DivisionCode = data[0].DivisionCode;
                            me.Alert.DivisionName = data[0].DivisionName;
                            if (me.divisionDropDownList) {
                                me.divisionDropDownList.value(me.Alert.DivisionCode);
                                me.divisionDropDownList.text(me.Alert.DivisionName);
                            }
                        }
                        me.refreshProducts();
                    }
                    me.divisionDropDownList.enable(true);
                },
                requestEnd: function (e) {
                    var response = e.response;
                    var type = e.type;
                }
            });
        } else {
            me.divisionsDataSource = new kendo.data.DataSource({
                data: []
            });
        }
        if (me.divisionDropDownList) {
            me.divisionDropDownList.setDataSource(me.divisionsDataSource);
            me.divisionDropDownList.value(me.Alert.DivisionCode);
        }
    }
    refreshProducts() {
        let me = this;
        //console.log("refreshProducts", me.Alert.ClientCode, me.Alert.DivisionCode, me.Alert.DivisionCode)
        if (me.Alert && me.Alert.ClientCode && me.Alert.ClientCode != "" && me.Alert.DivisionCode && me.Alert.DivisionCode != "") {
            me.productsDataSource = new kendo.data.DataSource({
                transport: {
                    read: {
                        url: 'Desktop/Alert/GetNewAssignmentProductList',
                        data: function () {
                            return {
                                SprintID: ((me.Alert.SprintID && me.Alert.SprintID > 0) ? me.Alert.SprintID : 0),
                                OfficeCode: ((me.Alert.OfficeCode && me.Alert.OfficeCode != "") ? me.Alert.OfficeCode : ""),
                                ClientCode: ((me.Alert.ClientCode && me.Alert.ClientCode != "") ? me.Alert.ClientCode : ""),
                                DivisionCode: ((me.Alert.ClientCode && me.Alert.DivisionCode != "") ? me.Alert.DivisionCode : "")
                            }
                        }
                    }
                },
                change: function () {
                    var data = this.data();
                    if (data && data.length == 1) {
                        if (me.Alert.ProductCode != data[0].ProductCode) {
                            me.Alert.ProductCode = data[0].ProductCode;
                            me.Alert.ProductName = data[0].ProductName;
                            if (me.productDropDownList) {
                                me.productDropDownList.value(me.Alert.ProductCode);
                                me.productDropDownList.text(me.Alert.ProductName);
                            }
                        }
                    }
                    me.productDropDownList.enable(true);
                },
                requestEnd: function (e) {
                    var response = e.response;
                    var type = e.type;
                }
            });
        } else {
            me.productsDataSource = new kendo.data.DataSource({
                data: []
            });
        }
        if (me.productDropDownList) {
            me.productDropDownList.setDataSource(me.productsDataSource);
            if (me.Alert.ProductCode !== "" || me.Alert.ProductCode != undefined) {
                me.productDropDownList.value(me.Alert.ProductCode);
                me.productDropDownList.enable(true);

                me.jobsDataSource.read().then(() => {
                    var data = me.jobsDataSource.data();
                    if (data && data.length == 1) {
                        me.Alert.JobNumber = data[0].JobNumber;
                        me.Alert.JobDescription = data[0].JobDescription;
                        if (me.jobDropDownList) {
                            var jobString: any = me.Alert.JobNumber.toString;
                            me.jobDropDownList.value(jobString);
                            me.jobDropDownList.text(me.Alert.JobDescription);
                        }

                        me.jobDropDownList.trigger('change');
                    }
                });

                //window.setTimeout(function () {
                //    me.refreshJobs();
                //}, 100);
            }
        }
    }
    refreshJobs() {
        let me = this;
        //console.log("refreshJobs", me.Alert.ClientCode, me.Alert.DivisionCode, me.Alert.ProductCode);
        if (me.Alert) {
            me.jobsDataSource = new kendo.data.DataSource({
                transport: {
                    read: {
                        url: 'Desktop/Alert/GetNewAssignmentJobList',
                        data: function () {
                            return {
                                SprintID: ((me.Alert.SprintID && me.Alert.SprintID > 0) ? me.Alert.SprintID : 0),
                                OfficeCode: ((me.Alert.OfficeCode && me.Alert.OfficeCode != "") ? me.Alert.OfficeCode : ""),
                                ClientCode: ((me.Alert.ClientCode && me.Alert.ClientCode != "") ? me.Alert.ClientCode : ""),
                                DivisionCode: ((me.Alert.DivisionCode && me.Alert.DivisionCode != "") ? me.Alert.DivisionCode : ""),
                                ProductCode: ((me.Alert.ProductCode && me.Alert.ProductCode != "") ? me.Alert.ProductCode : "")
                            }
                        }
                    }
                },
                change: function () {
                    var data = this.data();
                    if (data && data.length == 1) {
                        me.Alert.JobNumber = data[0].JobNumber;
                        me.Alert.JobDescription = data[0].JobDescription;
                        if (me.jobDropDownList) {
                            var jobString: any = me.Alert.JobNumber.toString;
                            me.jobDropDownList.value(jobString);
                            me.jobDropDownList.text(me.Alert.JobDescription);
                        }
                        me.refreshJobComponents();
                    }
                },
                requestEnd: function (e) {
                    var response = e.response;
                    var type = e.type;
                }
            });
        } else {
            me.jobsDataSource = new kendo.data.DataSource({
                data: []
            });
        }
        if (me.jobDropDownList) {
            me.jobDropDownList.setDataSource(me.jobsDataSource);
        }
    }
    refreshJobComponents() {
        //console.log("refreshJobComponents");
        let me = this;
        if (me.Alert && me.Alert.JobNumber && me.Alert.JobNumber > 0) {
            me.componentsDataSource = new kendo.data.DataSource({
                transport: {
                    read: {
                        url: 'Desktop/Alert/GetNewAssignmentComponentList',
                        data: function () {
                            return {
                                SprintID: ((me.Alert.SprintID && me.Alert.SprintID > 0) ? me.Alert.SprintID : 0),
                                JobNumber: ((me.Alert.JobNumber && me.Alert.JobNumber > 0) ? me.Alert.JobNumber : 0)
                            }
                        }
                    }
                },
                change: function () {
                    var data = this.data();
                    if (data && data.length == 1) {
                        me.Alert.JobComponentNumber = data[0].JobComponentNumber * 1;
                        me.Alert.JobComponentDescription = data[0].JobComponentDescription;
                        me.getDefaultWorkflowTemplate();
                        if (me.jobComponentDropDownList) {
                            try {
                                var jobComponentString: any = me.Alert.JobComponentNumber.toString;
                                me.jobComponentDropDownList.value(jobComponentString);
                                me.jobComponentDropDownList.text(me.Alert.JobComponentDescription);
                                me.jobComponentDropDownList.select(1);
                            } catch (e) {
                            }
                        }
                        me.checkForBoard();
                        //me.refreshJobComponents();
                    }
                },
                requestEnd: function (e) {
                    var response = e.response;
                    var type = e.type;
                    if (type == "read" && response) {
                        if (response.length == 1) {
                            me.Alert.JobComponentNumber = parseInt(response[0].JobComponentNumber);
                            me.getDefaultWorkflowTemplate();
                        }
                        me.jobComponentDropDownList.enable(true);
                    }
                }
            });
        } else {
            me.componentsDataSource = new kendo.data.DataSource({
                data: []
            });
        }
        if (me.jobComponentDropDownList) {
            me.jobComponentDropDownList.setDataSource(me.componentsDataSource);
            me.jobComponentDropDownList.enable(true);
        }
    }
    refreshRecipients() {
        //console.log("refreshRecipients");
        let me = this;
        if (me.Alert) {
            this.alertRecipientDataSource = new kendo.data.DataSource({
                transport: {
                    read: {
                        url: 'Desktop/Alert/GetAlertRecipientsLookup',
                        data: function () {
                            return {
                                c: ((me.Alert.ClientCode && me.Alert.ClientCode != "") ? me.Alert.ClientCode : ""),
                                d: ((me.Alert.DivisionCode && me.Alert.DivisionCode != "") ? me.Alert.DivisionCode : ""),
                                p: ((me.Alert.ProductCode && me.Alert.ProductCode != "") ? me.Alert.ProductCode : ""),
                                j: ((me.Alert.JobNumber && me.Alert.JobNumber > 0) ? me.Alert.JobNumber : 0),
                                jc: ((me.Alert.JobComponentNumber && me.Alert.JobComponentNumber > 0) ? me.Alert.JobComponentNumber : 0),
                                a: ((me.Alert.ID && me.Alert.ID > 0) ? me.Alert.ID : 0)
                            }
                        }
                    }
                }
            });
        }
    }
    setDefaultDropDownEnabled() {
        //console.log("setDefaultDropDownEnabled");
        let me = this;
        if (me.divisionDropDownList) {
            me.divisionDropDownList.enable(false);
        }
        if (me.productDropDownList) {
            me.productDropDownList.enable(false);
        }
        if (me.jobComponentDropDownList) {
            me.jobComponentDropDownList.enable(false);
        }
    }
    initSettings(response: any, paramClientCode: string, paramClientName: string, paramJobComponentNumber: number) {
        let me = this;
        try {
            if (response) {
                if (response.RepositoryLimitText) {
                    me.repositoryLimitText = response.RepositoryLimitText;
                }
                if (response.AllowUpload) {
                    me.allowUpload = response.AllowUpload;
                }
                if (response.ExcludeTasks) {
                    me.excludeTasks = response.ExcludeTasks;
                }
                if (response.DefaultSubject) {
                    me.Alert.Subject = response.DefaultSubject;
                }
                if (response.DefaultAssignment) {
                    me.defaultAssignment = response.DefaultAssignment;
                    me.isRouted = !me.defaultAssignment;
                }
                if (response.AllowProofHQ) {
                    me.allowProofHQ = response.AllowProofHQ;
                }
            }
        } catch (e) {
        }
        //console.log("initSettings!");
        me.setDefaultsFromSprintJob();
    }
    setDefaultsFromSprintJob() {
        let me = this;
        me.activated = true;
        if (me.Alert.JobNumber && me.Alert.JobNumber > 0) {
            if (me.Alert.JobComponentNumber && me.Alert.JobComponentNumber) {
                this.service.getNewAssignmentInfoFromJobComponent(me.Alert.JobNumber, me.Alert.JobComponentNumber).then(response => {
                    if (response && response.content) {
                        window.setTimeout(function (e) {
                            me.Alert.OfficeCode = response.content.OfficeCode;
                            me.Alert.OfficeName = response.content.OfficeName;
                            me.Alert.ClientCode = response.content.ClientCode;
                            me.Alert.ClientName = response.content.ClientName;
                            me.Alert.DivisionCode = response.content.DivisionCode;
                            me.Alert.DivisionName = response.content.DivisionName;
                            me.Alert.ProductCode = response.content.ProductCode;
                            me.Alert.ProductName = response.content.ProductName;
                            me.Alert.JobDescription = response.content.JobDescription;
                            me.Alert.JobComponentDescription = response.content.JobComponentDescription
                        }, 100);
                        //window.setTimeout(function (e) {
                        try {
                            me.fromPreset = true;
                            me.setDivisionProductAndComponent();
                            me.checkForBoard();
                        } catch (e) {
                        }
                        //}, 100);
                    }
                });
            }
            else {
                this.service.getNewAssignmentInfoFromJob(me.Alert.JobNumber).then(response => {
                    if (response && response.content) {
                        window.setTimeout(function (e) {
                            me.Alert.OfficeCode = response.content.OfficeCode;
                            me.Alert.OfficeName = response.content.OfficeName;
                            me.Alert.ClientCode = response.content.ClientCode;
                            me.Alert.ClientName = response.content.ClientName;
                            me.Alert.DivisionCode = response.content.DivisionCode;
                            me.Alert.DivisionName = response.content.DivisionName;
                            me.Alert.ProductCode = response.content.ProductCode;
                            me.Alert.ProductName = response.content.ProductName;
                            me.Alert.JobDescription = response.content.JobDescription;
                        }, 100);
                        //window.setTimeout(function (e) {
                        try {
                            me.fromPreset = true;
                            me.setDivisionProductAndComponent();
                            me.checkForBoard();
                        } catch (e) {
                        }
                        //}, 100);
                    }
                });
            }
        }
    }
    setDivisionProductAndComponent() {
        let me = this;
        //console.log("setDivisionProductAndComponent", me.Alert);
        me.divisionDropDownList.enable(true);
        me.divisionDropDownList.value(me.Alert.DivisionCode);
        //me.divisionDropDownList.text(me.Alert.DivisionName);
        me.productDropDownList.enable(true);
        me.productDropDownList.value(me.Alert.ProductCode);
        //me.productDropDownList.text(me.Alert.ProductName);
        me.jobComponentDropDownList.enable(true);
        me.jobComponentDropDownList.value(me.Alert.JobComponentNumber.toString())
    }
    lastRecipientClientCode: string = "";
    lastRecipientJobNumber: number = 0;
    refreshCCfromSession() {

    }
    attached() {
        //console.log("attached!")
        let me = this;
        $(document).ready(function () {
            //me.officeDropDownList.focus();
            me.attachmentUpload.wrapper.find('.k-dropzone .k-button').css('margin-right', '5px').after(me.existingDocumentButton);
            me.officeDropDownList.wrapper.keypress(function (e) {
                me.officeDropDownList.open();
                me.officeDropDownList.filterInput.val(me.officeDropDownList.filterInput.val() + e.key);
            });
            me.clientDropDownList.wrapper.keypress(function (e) {
                me.clientDropDownList.open();
                me.clientDropDownList.filterInput.val(me.clientDropDownList.filterInput.val() + e.key);
            });
            me.divisionDropDownList.wrapper.keypress(function (e) {
                me.divisionDropDownList.open();
                me.divisionDropDownList.filterInput.val(me.divisionDropDownList.filterInput.val() + e.key);
            });
            me.productDropDownList.wrapper.keypress(function (e) {
                me.productDropDownList.open();
                me.productDropDownList.filterInput.val(me.productDropDownList.filterInput.val() + e.key);
            });
            me.jobDropDownList.wrapper.keypress(function (e) {
                me.jobDropDownList.open();
                me.jobDropDownList.filterInput.val(me.jobDropDownList.filterInput.val() + e.key);
            });
            me.jobComponentDropDownList.wrapper.keypress(function (e) {
                me.jobComponentDropDownList.open();
                me.jobComponentDropDownList.filterInput.val(me.jobComponentDropDownList.filterInput.val() + e.key);
            });
            try {
                me.startDatePicker.element.change(function (e) {
                    me.startDateChange();
                });
            } catch (e) {
                //console.log("ERROR", e);
            }
            try {
                me.dueDatePicker.element.change(function (e) {
                    me.dueDateChange();
                });
            } catch (e) {
                //console.log("ERROR", e);
            }
        });
        this.disposables = new Array<Disposable>();
        var alertAssignmentTemplateIDDisposable = this.bindingEngine.propertyObserver(this.Alert, 'AlertAssignmentTemplateID').subscribe((newValue, oldValue) => {
            this.alertAssignmentTemplateIDChanged(newValue, oldValue);
        });
        var alertStateIDDisposable = this.bindingEngine.propertyObserver(this.Alert, 'AlertStateID').subscribe((newValue, oldValue) => {
            this.alertStateIDChanged(newValue, oldValue);
        });
        this.disposables.push(alertAssignmentTemplateIDDisposable);
        this.disposables.push(alertStateIDDisposable);
        this.getDefaultSubjectType();

        if ((this.Alert.JobComponentNumber && this.Alert.JobComponentNumber > 0) || (
            this.Alert.OfficeCode && this.Alert.OfficeCode !== ''
            && (!this.Alert.ClientCode || this.Alert.ClientCode === '')
        )) {
            $("#HOURS_DIV").css("visibility", "visible");
        }

        var jobComponentID = this.bindingEngine.propertyObserver(this.Alert, 'JobComponentNumber').subscribe((newValue, oldValue) => {
            let me = this;
            //console.log("jobComponentID = " + newValue);
            if ((newValue && newValue != '' && newValue != 0) || (
                this.Alert.OfficeCode && this.Alert.OfficeCode !== ''
                && (!this.Alert.ClientCode || this.Alert.ClientCode === '')
            )) {
                $("#HOURS_DIV").css("visibility", "visible");
            }
            else {
                this.clearBoardInfo();
                $("#HOURS_DIV").css("visibility", "hidden");
                this.Alert.HoursAllowed = 0;
            }

            if (this.Alert.JobNumber && this.Alert.JobComponentNumber) {
                this.service.doesJobHaveSchedule(this.Alert.JobNumber, this.Alert.JobComponentNumber).then((data) => {
                    //console.log(data);
                    me.jobHasSchedule = data.content;
                });
            }
            else {
                me.jobHasSchedule = false;
            }
        });

        this.disposables.push(jobComponentID);

        var officeCode = this.bindingEngine.propertyObserver(this.Alert, 'OfficeCode').subscribe((newValue, oldValue) => {
            let me = this;
            //console.log("jobComponentID = " + newValue);
            if ((newValue && newValue != ''
                && (!me.Alert.ClientCode || me.Alert.ClientCode === '')) ||
                (me.Alert.JobComponentNumber && me.Alert.JobComponentNumber > 0)) {
                $("#HOURS_DIV").css("visibility", "visible");
            }
            else {
                this.clearBoardInfo();
                $("#HOURS_DIV").css("visibility", "hidden");
                me.Alert.HoursAllowed = 0;
            }
        });

        this.disposables.push(officeCode);

        var refreshTypeList = this.bindingEngine.propertyObserver(this, 'jobHasSchedule').subscribe((newValue, oldValue) => {
            let me = this;

            me.alertCategoriesDataSource.read();
        });
        this.disposables.push(refreshTypeList);


        var subscriber = this.eventAggregator.subscribe('loadlistbox', () => {
            //console.log('got event');

            let me = this;

            me.alertTemplateStatesDataSource.read().then(() => {
                if (me.Alert.AlertStateID) {
                    var listBox = $('#StateListBox').data("kendoListBox");
                    var data = me.alertTemplateStatesDataSource.data();
                    //console.log(data);

                    me.alertTemplateStatesListboxChange();

                    if (listBox) {

                        var i = data.find((o) => {
                            return o['ID'] === +me.Alert.AlertStateID;
                        });

                        //console.log(i);
                        listBox.select($('#' + i.uid));
                    }
                }
            });
        });

        (<any>window).MvcRefreshNewAssignmentViewBridge = function (updateType) {
            //console.log("attached alert id, fn alertid", me.Alert.ID, alertId, sprintId, employeeName);
            //console.log("MvcRefreshNewAlertViewBridge:updateType:", updateType);
            if (updateType && updateType != undefined && updateType != null && isNaN(updateType) == false) {
                //console.log("MvcRefreshNewAlertViewBridge:updateType:", updateType);
                if (updateType == 5) {
                    return me.refreshCCfromSession();
                }
            }
        }


        this.disposables.push(subscriber);
    }
    detached() {
        if (this.disposables && this.disposables.length > 0) {
            for (var i = 0; i < this.disposables.length; i++) {
                this.disposables[i].dispose();
            }
        }
    }
    typeReady(e) {

    }
    sprintDropDownReady(e) {

    }
    listBoxReady(e) {
        this.eventAggregator.publish('loadlistbox');
    }
    showCurrentValues(desc: number) {
        let me = this;
        //console.log("showCurrentValues: ", desc);
        //console.log("SprintID", me.Alert.SprintID, me.paramsSprintID);
        //console.log("BoardID", me.Alert.BoardID, me.paramsBoardID);
        //console.log("BoardHeaderID", me.Alert.BoardHeaderID, me.paramsBoardHeaderID);
        //console.log("BoardStateID", me.Alert.BoardStateID, me.paramsBoardStateID);
        //console.log("JobNumber", me.Alert.JobNumber, me.paramsJobNumber);
        //console.log("JobComponentNumber", me.Alert.JobComponentNumber, me.paramsJobComponentNumber);
    }
    onHoursReady(e) {
        e.element.on('focusin', this.HoursFocus);
    }
    HoursFocus(e) {
        let input = $(this);

        window.setTimeout(() => {
            input.select();
        }, 100);
    }

    attachmentUploadSuccess(e) {
        this.progressValue = 0;
        this.syncFiles();
    }
    attachmentUploadError(e) {
        if (e.operation == 'upload') {
            if (e.XMLHttpRequest.responseText) {
                this.alert(JSON.parse(e.XMLHttpRequest.responseText));
            }
        }
    }
    attachmentOnUpload(e) {
    }
    attachmentOnProcess(e) {
        this.progressValue = e.percentComplete;
        if (this.uploadProgressBar) {
            this.uploadProgressBar.value(this.progressValue);
            this.uploadProgressBar.progressStatus.text(this.getFileInfo(e) + ":  " + this.progressValue + "%");
        }
    }
    syncFiles() {
        let me = this;
        window.setTimeout(() => {
            me.files = [];
            me.fileNames = [];
            if (me.attachmentUpload) {
                for (var i = 0; i < me.attachmentUpload.getFiles().length; i++) {
                    var file = me.attachmentUpload.getFiles()[i];
                    me.files.push({ name: file.name, uid: file.uid });
                    me.fileNames.push(file.name);
                }
            }
            //console.log("syncFiles this.files", this.files);
        }, 250);
    }
    getFileInfo(e) {
        return $.map(e.files, function (file) {
            var info = file.name;
            if (file.size > 0) {
                info += " (" + Math.ceil(file.size / 1024) + " KB)";
            }
            return info;
        }).join(", ");
    }

    activate(params: any) {
        //console.log("PARAMS???", params);
        setTimeout(this.slowActivate, 250, params, this);
    }
    slowActivate(params: any, that: any) {
        let me = that;
        var paramClientCode = null;
        var paramClientName = null;
        var paramJobComponentNumber = null;
        if (params.ContentPage == "1") {
            me.contentpage = "1"
        }
        //console.log("slowActivate", me.Alert)
        try {
            if (params.caller && params.caller.trim() != '') {
                me.callingPage = params.caller;
                me.Alert.CallingPage = me.callingPage;
            }
        } catch (e) {
        }
        try {
            if (me.callingPage == "review") {
                me.isProof = true;
                me.Alert.AlertCategoryID = 79;
            }
        } catch (e) {
        }
        window.setTimeout(function () {
            if (me.isProof == true) {
                me.editorHeight = me.editorHeightProofing;
            }
        }, 0);
       //board and sprint from sprint page
        if (params.BoardID && isNaN(params.BoardID) == false && params.BoardID > 0) {
            me.Alert.BoardID = params.BoardID;
            me.paramsBoardID = params.BoardID;
        }
        if (params.BoardHeaderID && isNaN(params.BoardHeaderID) == false && params.BoardHeaderID > 0) {
            me.Alert.BoardHeaderID = params.BoardHeaderID;
            me.paramsBoardHeaderID = params.BoardHeaderID;
            //console.log("has BoardHeaderID!", me.Alert.BoardHeaderID);
        }
        if (params.SprintID && isNaN(params.SprintID) == false && params.SprintID > 0) {
            me.Alert.SprintID = params.SprintID;
            me.paramsSprintID = params.SprintID;
            //console.log("has SprintID!", me.Alert.SprintID);
        }
        if (params.BoardStateID && isNaN(params.BoardStateID) == false && params.BoardStateID > 0) {
            me.Alert.BoardStateID = params.BoardStateID;
            me.paramsBoardStateID = params.BoardStateID;
            me.boardStateId = params.BoardStateID;
            // console.log("has BoardStateID!", me.Alert.BoardStateID);
        }
        if (params.sprhid && isNaN(params.sprhid) == false && params.sprhid > 0) {
            me.Alert.SprintID = params.sprhid;
            me.paramsSprintID = params.sprhid;
        }
        if (params.brdstid && isNaN(params.brdstid) == false && params.brdstid > 0) {
            me.Alert.BoardStateID = params.brdstid;
            me.paramsBoardStateID = params.brdstid;
        }
        if (params.brdid && isNaN(params.brdid) == false && params.brdid > 0) {
            me.Alert.BoardID = params.brdid;
            me.paramsBoardID = params.brdid;
        }
        if (params.brdhid && isNaN(params.brdhid) == false && params.brdhid > 0) {
            me.Alert.BoardHeaderID = params.brdhid;
            me.paramsBoardHeaderID = params.brdhid;
        }
        if (params.ClientCode && params.ClientCode.trim() != '') {
            paramClientCode = params.ClientCode;
        }
        if (params.ClientCode && params.ClientCode != "") {
            me.Alert.ClientCode = params.ClientCode;
        }
        if (params.c && params.c.trim() != '') {
            paramClientCode = params.c;
        }
        if (params.DivisionCode && params.DivisionCode != "") {
            me.DivisionID = params.ClientCode + ',' + params.DivisionCode;
            me.Alert.DivisionCode = params.DivisionCode;
        }
        if (params.ProductCode && params.ProductCode != "") {
            me.ProductID = params.ClientCode + ',' + params.DivisionCode + ',' + params.ProductCode;
            me.Alert.ProductCode = params.ProductCode;
        }
        if (params.JobNumber && isNaN(params.JobNumber) == false && params.JobNumber > 0) {
            me.Alert.JobNumber = +params.JobNumber;
            me.paramsJobNumber = +params.JobNumber;
        }
        if (params.JobComponentNumber && isNaN(params.JobComponentNumber) == false && params.JobComponentNumber) {
            me.Alert.JobComponentNumber = +params.JobComponentNumber;
            me.paramsJobComponentNumber = +params.JobComponentNumber;
            me.JobComponentID = params.JobNumber + ',' + params.JobComponentNumber;
            paramJobComponentNumber = params.JobComponentNumber;
        }
        if (params.JobComponentNumber && isNaN(params.JobComponentNumber) == false && params.JobComponentNumber > 0 && (!params.PageType || params.PageType !== "jr")) {
            me.Alert.JobComponentNumber = +params.JobComponentNumber;
            me.JobComponentID = params.JobNumber + ',' + params.JobComponentNumber;
            paramJobComponentNumber = params.JobComponentNumber;
            me.getDefaultWorkflowTemplate();
        }
        else if (params.PageType && (params.PageType == "jr" || params.PageType == "jt")) {
            me.service.GetJobVersionDefaults().then(data => {
                //console.log(data);
                var setting = data.content.find(o => {
                    return o.Code == "JR_DFLT_CONTACT";
                })
                if (setting) {
                    me.jobRequestDefaultAssign = setting.Value;
                }
                setting = data.content.find(o => {
                    return o.Code == "JR_ASSIGN_TMPLT";
                })
                //console.log(setting);
                if (setting) {
                    me.Alert.AlertAssignmentTemplateID = setting.Value;
                    me.paramAlertAssignmentTemplateID = setting.Value;
                    me.Alert.AlertAssignmentTemplateName = setting.DisplayDescription;
                    //console.log("AlertAssignmentTemplateID = " + me.Alert.AlertAssignmentTemplateID);
                }
                setting = data.content.find(o => {
                    return o.Code == "JR_ASSIGN_STATE";
                })
                //console.log(setting);
                if (setting) {
                    me.Alert.AlertStateID = setting.Value;

                    this.eventAggregator.publish('loadlistbox');
                }
                setting = data.content.find(o => {
                    return o.Code == "JR_DFLT_ALERT_GROUP";
                })
                if (setting) {
                    //console.log(setting);

                    if (setting.Value && setting.Value != '') {
                        me.service.GetAlertGroupMembers(setting.Value).then((data) => {
                            //console.log(data);

                            me.Alert.Recipients = [];

                            data.content.forEach((element, index) => {
                                me.Alert.Recipients[index] = element.Code;
                            });
                        });
                    }
                }

            });
        }
        else {
            //me.Alert.JobComponentNumber = 0;
        }
        //  Let server querystring class override
        if (params.j && isNaN(params.j) == false && parseInt(params.j) > 0) {
            me.Alert.JobNumber = parseInt(params.j);
        }
        if (params.jc && isNaN(params.jc) == false && params.jc > 0 && (!params.PageType && params.PageType !== "jr")) {
            me.Alert.JobComponentNumber = params.jc;
            paramJobComponentNumber = params.jc;
            me.getDefaultWorkflowTemplate();
        }
        if (me.Alert.JobNumber == undefined && me.Alert.JobComponentNumber == undefined) {
            window.setTimeout(function () {
                me.setDefaultDropDownEnabled();
            }, 500);
        }
        if (me.Alert.SprintID && me.Alert.SprintID > 0) {
            me.service.getSprintSetup(me.Alert.SprintID).then(response => {
                me.initSettings(response, paramClientCode, paramClientName, paramJobComponentNumber);
            });
        } else {
            me.service.initNewAssignment(me.callingPage).then(response => {
                me.initSettings(response, paramClientCode, paramClientName, paramJobComponentNumber);
            });
        }
        me.Report = params.Report;
        if ((this.JobComponentID && this.JobComponentID != '') || (this.Alert && this.Alert.BoardHeaderID && this.Alert.BoardHeaderID > 0)) {
            //this.styleObject.visibility = 'visable';
        }
        if (me.Alert.BoardHeaderID > 0 &&
            me.Alert.BoardID > 0 &&
            me.Alert.BoardStateID > 0) {
            me.hasBoardInfo = true;
            me.fromBoard = true;
        }
        me.showCurrentValues(3718);
    }
}
