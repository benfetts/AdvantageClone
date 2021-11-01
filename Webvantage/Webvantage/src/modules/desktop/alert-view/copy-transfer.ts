import { bindable, inject, child, observable, BindingEngine, Disposable  } from 'aurelia-framework';
import { ModuleBase } from 'modules/base/module-base';
import { AlertService } from 'services/desktop/alert-service';
import { AlertModel } from 'models/desktop/alert-model';
import { DropDownList } from '../../../resources/elements/dropdownlist/dropdownlist';
import { DialogService } from 'aurelia-dialog';
import { AlertView } from './alert-view';
import { AlertRecipientModel } from 'models/desktop/alert-recipient-model';

@inject(AlertService, DialogService, BindingEngine)
export class CopyTransfer extends ModuleBase {

    dialogService: DialogService;
    service: AlertService;
    bindingEngine: BindingEngine;
    disposables: Array<Disposable>;

    AlertRecipients: Array<AlertRecipientModel>;
    assignees: Array<string>;
    assigneesAsItems: Array<any>;
    recipients: Array<string>;
    tempCompleteRcpts: Array<string>;

    @bindable isCopy: boolean = true;
    @bindable saveButtonText: string = 'Copy';
    @bindable copyComments: boolean = false;
    @bindable copyAttachments: boolean = false;
    @bindable isRouted: boolean = false;
    @bindable formType: number = 1; // Type 1 = Copy, 2 = Move, 3 = Routed Copy, 4 = Routed Move
    @bindable showAllEmployees: boolean = false;
    @bindable isProof: boolean = false;

    @bindable hasBoardInfo: boolean = false;

    Alert: AlertModel;

    boardID: number;
    callingAlertId: number;
    callingSprintId: number;
    stateChanged: boolean = false;
    stateChangedFromLoadedState: boolean = false;
    showingAllEmployees: boolean = false;
    loadedStateID: number;

    clientsDataSource: kendo.data.DataSource;
    divisionsDataSource: kendo.data.DataSource;
    productsDataSource: kendo.data.DataSource;
    jobsDataSource: kendo.data.DataSource;
    componentsDataSource: kendo.data.DataSource;
    alertTemplatesDataSource: kendo.data.DataSource;
    alertTemplateStatesDataSource: kendo.data.DataSource;
    alertTemplateStateEmployeesDataSource: kendo.data.DataSource;
    alertTemplateStateEmployeesDataSourceMultiSelectRouted: kendo.data.DataSource;

    boardDataSource: kendo.data.DataSource;
    boardSprintDataSource: kendo.data.DataSource;
    boardStateDataSource: kendo.data.DataSource;

    clientDropDownList: kendo.ui.DropDownList;
    divisionDropDownList: kendo.ui.DropDownList;
    productDropDownList: kendo.ui.DropDownList;
    jobDropDownList: kendo.ui.DropDownList;
    jobComponentDropDownList: kendo.ui.DropDownList;
    alertTemplatesDropDownList: kendo.ui.DropDownList;
    alertTemplateStatesDropDownList: kendo.ui.DropDownList;
    boardDropDownList: kendo.ui.DropDownList;
    boardSprintDropDownList: kendo.ui.DropDownList;
    boardStateDropDownList: kendo.ui.DropDownList;
    assignToMultiSelectRouted: kendo.ui.MultiSelect;

    @bindable boardDropDownListEnabled: boolean = false;
    @bindable boardSprintDropDownListEnabled: boolean = false;
    @bindable boardStateDropDownListEnabled: boolean = false;

    pickClient: boolean = true;
    pickDivision: boolean = true;
    pickProduct: boolean = true;
    pickJob: boolean = true;
    pickComponent: boolean = true;
    assigneesChanged: boolean = false;

    clientName: string;
    divisionName: string;
    productName: string;
    jobDescription: string;
    jobComponentDescription: string;

    jobHasSchedule: boolean = false;

    defaultWorkflowTemplate: any = {};

    boardInfo: any;

    checkSingleDivision(clientCode: string) {
        try {
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
                    this.divisionDropDownList.value(division.DivisionCode);
                    this.divisionDropDownList.enable(true);
                    let me = this;
                    window.setTimeout(function () {
                        me.checkSingleProduct(division.ClientCode, division.DivisionCode);
                    }, 0);
                } else {
                    this.divisionDropDownList.focus();
                }
            }
        } catch (e) {
            console.log("", e);
        }
    }
    checkSingleProduct(clientCode, divisionCode) {
        try {
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
                    this.productDropDownList.value(product.ProductCode);
                    let me = this;
                    this.productDropDownList.enable(true);
                    window.setTimeout(function () {
                        me.checkSingleJob(product.ClientCode, product.DivisionCode, product.ProductCode);
                    }, 0);
                } else {
                    this.productDropDownList.focus();
                }
            }
        } catch (e) {
            console.log("", e);
        }
    }
    checkSingleJob(clientCode: string, divisionCode: string, productCode: string) {
        try {
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
                if (job && !multiple) {
                    this.Alert.JobNumber = job.JobNumber;
                    this.jobDropDownList.value(job.JobNumber);
                    let me = this;
                    window.setTimeout(function () {
                        me.checkSingleComponent(job.JobNumber);
                    }, 0);
                } else {
                    this.jobDropDownList.focus();
                }
            }
        } catch (e) {
            console.log("", e);
        }
    }
    checkSingleComponent(jobNumber: number) {
        try {
            if (jobNumber > 0) {
                var items = this.jobComponentDropDownList.dataSource.data();
                let component = null;
                let multiple = false;
                for (var i = 0; i < items.length; i++) {
                    if (items[i].JobNumber === jobNumber) {
                        if (!component) {
                            component = items[i];
                        } else {
                            multiple = true;
                        }
                    }
                }
                if (component && !multiple) {
                    this.Alert.JobComponentNumber = component.JobComponentNumber;
                    this.jobComponentDropDownList.value(component.JobComponentNumber);
                    let me = this;
                    me.jobComponentNumberChanged(component.JobComponentNumber, 0);
                    $('#isRouted').focus();
                    window.setTimeout(function () {
                        me.componentChanged(null);
                    }, 0);
                } else {
                    this.jobComponentDropDownList.focus();
                }
            }
        } catch (e) {
            console.log("", e);
        }
    }

    checkClearJob(clientCode: string, divisionCode: string | boolean, productCode: string | boolean) {
        var clearJob = true;
        var job = this.jobDropDownList.dataItem(this.jobDropDownList.select());
        if (job) {
            clearJob = false;
            if (job.ClientCode !== clientCode) {
                clearJob = true;
            }
            if (divisionCode !== false) {
                if (job.DivisionCode !== divisionCode) {
                    clearJob = true;
                }
            }
            if (productCode !== false) {
                if (job.ProductCode !== productCode) {
                    clearJob = true;
                }
            }
        }
        if (clearJob) {

            this.Alert.JobNumber = null;
            this.jobDropDownList.value(null);
            this.Alert.JobComponentNumber = null;
            this.jobComponentDropDownList.value(null);

            this.clearBoardInfo();

        }
    }
    setJobFilters() {
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
    clientOnCascade(e) {
        if (e) {
            if (typeof e.userTriggered === 'undefined') {
                if (!this.clientDropDownList) {
                    return;
                }
            }
            let sender: kendo.ui.DropDownList = e.sender;
            let me = this;
            window.setTimeout(function () {
                me.Alert.DivisionCode = null
                if (me.divisionDropDownList) {
                    me.divisionDropDownList.value(null);
                }
            }, 0);
            window.setTimeout(function () {
                me.Alert.ProductCode = null
                if (me.productDropDownList) {
                    me.productDropDownList.value(null);
                }
            }, 0);
            this.checkClearJob(sender.value(), false, false);
            this.setJobFilters();
            if (sender.value() !== '') {
                window.setTimeout(function () {
                    me.checkSingleDivision(sender.value());
                }, 0);
            }
        }
    }
    divisionOnCascade(e) {
        if (e) {
            if (typeof e.userTriggered === 'undefined') {
                if (!this.divisionDropDownList) {
                    return;
                }
            }
            let sender: kendo.ui.DropDownList = e.sender;
            let me = this;
            window.setTimeout(function () {
                me.Alert.ProductCode = null
                if (me.productDropDownList) {
                    me.productDropDownList.value(null);
                }
            }, 0);
            this.checkClearJob(this.clientDropDownList.value(), sender.value(), false);
            me.setJobFilters();
            if (sender.value() !== '') {
                window.setTimeout(function () {
                    me.checkSingleProduct(me.clientDropDownList.value(), me.divisionDropDownList.value());
                }, 0);
            }
        }
    }
    productOnCascade(e) {
        if (e) {
            if (typeof e.userTriggered === 'undefined') {
                if (!this.productDropDownList) {
                    return;
                }
            }
            let sender: kendo.ui.DropDownList = e.sender;
            let me = this;
            this.checkClearJob(this.clientDropDownList.value(), this.divisionDropDownList.value(), sender.value());
            this.setJobFilters();
            if (sender.value() !== '') {
                window.setTimeout(function () {
                    me.checkSingleJob(me.clientDropDownList.value(), me.divisionDropDownList.value(), me.productDropDownList.value());
                }, 0);
            } else {
                if (this.jobDropDownList) {
                    this.Alert.JobNumber = null;
                    this.jobDropDownList.value(null);
                }
            }
        }
    }
    jobOnCascade(e) {
        try {
            if (e && e.userTriggered !== false) {
                let sender: kendo.ui.DropDownList = e.sender;
                let me = this;
                if (sender.value() !== '') {
                    let job = sender.dataItem(sender.select());
                    if (this.clientDropDownList) {
                        this.clientDropDownList.value(job.ClientCode);
                        window.setTimeout(function () {
                            if (me.divisionDropDownList) {
                                me.divisionDropDownList.enable(true);
                                me.Alert.DivisionCode = job.DivisionCode;
                                me.divisionDropDownList.value(job.DivisionCode);
                                me.productDropDownList.dataSource.filter({ field: 'DivisionCode', operator: 'eq', value: job.DivisionCode });
                            }
                            window.setTimeout(function () {
                                if (me.productDropDownList) {
                                    me.productDropDownList.enable(true);
                                    me.Alert.ProductCode = job.ProductCode;
                                    me.productDropDownList.value(job.ProductCode);
                                }
                                window.setTimeout(function () {
                                    if (me.jobDropDownList) {
                                        me.Alert.JobNumber = job.JobNumber;
                                        me.jobDropDownList.value(job.JobNumber);
                                    }
                                }, 0);
                            }, 0);
                        }, 0);
                    }
                    window.setTimeout(function () {
                        me.checkSingleComponent(job.JobNumber);
                    }, 0);
                }
                window.setTimeout(function () {
                    me.setJobFilters();
                }, 300);
            }
        } catch (e) {
            console.log("", e);
        }
    }
    componentChanged(e) {
        this.getDefaultWorkflowTemplate();
        //this.checkSingleAll();
   }
    jobComponentNumberChanged(newValue, oldValue) {
        try {
            let me = this;
            this.service.doesJobHaveSchedule(this.Alert.JobNumber, this.Alert.JobComponentNumber).then((data) => {
                me.jobHasSchedule = data.content;
            });
        } catch (e) {
            console.log("", e);
        }
    }

    showAllEmployeesChanged() {
        if (this.Alert.AlertAssignmentTemplateID && this.Alert.AlertAssignmentTemplateID > 0 && this.Alert.AlertStateID && this.Alert.AlertStateID > 0) {
            this.alertTemplateStateEmployeesDataSourceMultiSelectRouted.read();
        } else {
            this.alertTemplateStateEmployeesDataSource.read();
        }
    }
    assignToMultiSelectDataBound(e) {
        //this.checkForMultiRoutedCompleteAssignee(e.sender)
    }
    assignToMultiSelectChanged(e) {
        this.assigneesChanged = true;
        var items = this.assignToMultiSelectRouted.value();
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
    alertStateIDChanged(newValue, oldValue) {
        this.alertTemplateStateEmployeesDataSource.read();
    }
    alertAssignmentTemplateIDChanged(newValue, oldValue) {
        this.Alert.AlertStateID = null;
        this.Alert.AssignedEmployeeCode = '';
        if (this.alertTemplateStatesDropDownList) {
            this.alertTemplateStatesDropDownList.element.val("");
            this.alertTemplateStatesDropDownListChange(null);
            this.alertTemplateStatesDataSource.read();
        }
        ////////////if (this.alertTemplateStateEmployeesDropDownList) {
        ////////////    this.alertTemplateStateEmployeesDropDownList.value = "";
        ////////////}
    }

    alertTemplateStatesDropDownListChange(e) {
        var canSelectEmployee = false;
        if (this.alertTemplateStatesDropDownList) {
            var item = this.alertTemplateStatesDropDownList.select();
            var dataItem = <any>this.alertTemplateStatesDropDownList.dataItem(item);
            if (dataItem) {
                this.stateChanged = true;
                this.assigneesChanged = true;
                this.Alert.AlertStateID = dataItem.ID;
                if (this.Alert.AlertStateID != this.loadedStateID) {
                    this.stateChangedFromLoadedState = true;
                } else {
                    this.stateChangedFromLoadedState = false;
                }
                this.alertTemplateStateEmployeesDataSourceMultiSelectRouted.read();
                canSelectEmployee = true;
                //canSelectEmployee = true;
                //this.Alert.AlertStateID = dataItem.ID;
                //this.alertTemplateStateEmployeesDataSource.read().then(() => {
                //    var doesCurrentEmpExist = false;
                //    for (var i = 0; i < this.alertTemplateStateEmployeesDataSource.data().length; i++) {
                //        var emp = this.alertTemplateStateEmployeesDataSource.data()[i];
                //        if (emp.IsDefault === true) {
                //            this.Alert.AssignedEmployeeCode = emp.Code;
                //        }
                //        if (emp.Code === this.Alert.AssignedEmployeeCode) {
                //            doesCurrentEmpExist = true;
                //        }
                //    }
                //    if (!doesCurrentEmpExist) {
                //        this.Alert.AssignedEmployeeCode = '';
                //    }
                //});
                ////////////if (this.alertTemplateStateEmployeesDropDownList) {
                ////////////    this.alertTemplateStateEmployeesDropDownList.enabled = true;
                ////////////}
           } else {
                //this.Alert.AssignedEmployeeCode = '';
            }
        }
        ////////////if (this.alertTemplateStateEmployeesDropDownList) {
        ////////////    if (canSelectEmployee == false) {
        ////////////        if ((isNaN(this.Alert.AlertAssignmentTemplateID) == true || this.Alert.AlertAssignmentTemplateID == 0) && (isNaN(this.Alert.AlertStateID) == true || this.Alert.AlertStateID == 0)) {
        ////////////            this.Alert.AssignedEmployeeCode = '';
        ////////////        }
        ////////////    }
        ////////////}
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
        if (this.alertTemplatesDropDownList) {
            this.alertTemplatesDropDownList.value("");
        }
        if (this.isRouted === true) {
            if (this.Alert.AlertCategoryID === 71) {
                this.Alert.AlertCategoryID = null;
            }
        }
        window.setTimeout(function () {
        }, 0);
    }
    getDefaultWorkflowTemplate() {
        if (this.defaultWorkflowTemplate.JobNumber !== this.Alert.JobNumber || this.defaultWorkflowTemplate.JobComponentNumber !== this.Alert.JobComponentNumber) {
            if (this.Alert.JobNumber > 0 && this.Alert.JobComponentNumber > 0) {
                //console.log("getDefaultWorkflowTemplate", this.Alert.JobNumber, this.Alert.JobComponentNumber)
                this.defaultWorkflowTemplate.JobNumber = this.Alert.JobNumber;
                this.defaultWorkflowTemplate.JobComponentNumber = this.Alert.JobComponentNumber;
                this.service.getDefaultWorkflowTemplate(this.Alert.JobNumber, this.Alert.JobComponentNumber).then(response => {
                    if (!isNaN(response.content)) {
                        this.defaultWorkflowTemplate.AlertAssignmentTemplateID = Number(response.content);
                        if (this.isRouted === true) {
                            this.Alert.AlertAssignmentTemplateID = Number(response.content);
                        }
                    }
                });
                this.checkForBoard();
            }
        } else {
            if (this.isRouted === true) {
                this.Alert.AlertAssignmentTemplateID = this.defaultWorkflowTemplate.AlertAssignmentTemplateID;
            } else {
                this.Alert.AlertAssignmentTemplateID = null;
            }
        }
    }

    clearBoardInfo() {
        if (this.boardDropDownList) {
            this.boardDropDownList.value(null);
            this.boardDropDownList.enable(false);
        }
        if (this.boardSprintDropDownList) {
            this.boardSprintDropDownList.value(null);
            this.boardSprintDropDownList.enable(false);
        }
        if (this.boardStateDropDownList) {
            this.boardStateDropDownList.value(null);
            this.boardStateDropDownList.enable(false);
        }
        this.boardDropDownListEnabled = false;
        this.boardSprintDropDownListEnabled = false;
        this.boardStateDropDownListEnabled = false;
    }
    checkForBoard() {
        let me = this;
        var isNoTaskBoard: boolean = false;
        me.hasBoardInfo = false;
        me.clearBoardInfo();
        if (me.Alert.JobNumber && me.Alert.JobNumber > 0 && me.Alert.JobComponentNumber && me.Alert.JobComponentNumber > 0) {
            me.service.jobIsNoTaskBoard(me.Alert.JobNumber, me.Alert.JobComponentNumber).then(response => {
                if (response && response.content) {
                    isNoTaskBoard = response.content.NoTaskBoard;
                    if (isNoTaskBoard == false) {
                        me.service.checkForBoard(me.Alert.JobNumber, me.Alert.JobComponentNumber).then(response => {
                            if (response && response.content) {
                                me.boardInfo = response.content;
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
                                        var id = 0;
                                        for (var i = 0; i < items.length; i++) {
                                            if (items.length == 1) {
                                                id = items[i].ID * 1;
                                            }
                                        }
                                        if (id && id > 0) {
                                            me.boardDropDownList.value(id + "");
                                            me.Alert.BoardID = id;
                                            me.getBoardSprintInfo();
                                        }
                                    }
                                    me.boardSprintDataSource = new kendo.data.DataSource({
                                        data: me.boardInfo.Sprints
                                    });
                                    me.boardSprintDropDownList.setDataSource(me.boardSprintDataSource);

                                    me.boardStateDataSource = new kendo.data.DataSource({
                                        data: me.boardInfo.States
                                    });
                                    me.boardStateDropDownList.setDataSource(me.boardStateDataSource);
                                }
                            }
                        });
                    }
                }
            });
        }
    }
    boardDropDownListChange(evt) {
        if (this.boardSprintDropDownList) {
            this.boardSprintDropDownList.value(null);
            this.boardSprintDropDownList.enable(false);
        }
        if (this.boardStateDropDownList) {
            this.boardStateDropDownList.value(null);
            this.boardStateDropDownList.enable(false);
        }
        this.boardSprintDropDownListEnabled = false;
        this.boardStateDropDownListEnabled = false;
        this.getBoardSprintInfo();
    }
    getBoardSprintInfo() {
        let me = this;
        if (this.Alert.BoardID && this.Alert.BoardID > 0) {
            this.boardID = me.Alert.BoardID;
            this.service.getBoardSprints(me.Alert.BoardID).then(response => {
                if (response) {
                    me.Alert.BoardID = me.boardID;
                    this.boardSprintDataSource = new kendo.data.DataSource({
                        data: response.content
                    });
                    this.boardSprintDropDownList.setDataSource(this.boardSprintDataSource);
                    this.boardSprintDropDownList.enable(true);
                    this.boardSprintDropDownListEnabled = true;
                    var items = this.boardSprintDataSource.data();
                    if (items) {
                        var id = 0;
                        for (var i = 0; i < items.length; i++) {
                            if (items.length == 1 || items[i].IsActive == true) {
                                id = items[i].ID * 1;
                            }
                        }
                        if (id && id > 0) {
                            me.boardSprintDropDownList.value(id + "");
                            me.Alert.SprintID = id;
                            me.getBoardStateInfo();
                        }
                    }
                }
            });
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
       if (this.Alert.SprintID && this.Alert.SprintID > 0) {
            this.service.getBoardSprintStates(this.Alert.SprintID).then(response => {
                if (response && response.content) {
                    this.boardStateDataSource = new kendo.data.DataSource({
                        data: response.content
                    });
                    this.boardStateDropDownList.setDataSource(this.boardStateDataSource);
                    this.boardStateDropDownList.enable(true);
                    this.boardStateDropDownListEnabled = true;
                }
                var items = this.boardStateDataSource.data();
                if (items) {
                    var id = 0;
                    for (var i = 0; i < items.length; i++) {
                        if (items.length == 1) {
                            id = items[i].ID * 1;
                        }
                    }
                    if (id && id > 0) {
                        this.boardStateDropDownList.value(id + "");
                        me.Alert.BoardStateID = id;
                    }
                }
           });
        }
    }
    checkSingleAll() {
        let me = this;
        var items: any = null;
        if (this.clientDropDownList) {
            items = this.clientDropDownList.dataSource.data();
            if (items && items.length == 1 && this.Alert.ClientCode !== "") {
                setTimeout(function () {
                    //me.clientDropDownList.enable(false);
                }, 0);
            }
            items = null;
        }
        if (this.divisionDropDownList) {
            items = this.divisionDropDownList.dataSource.data();
            if (items && items.length == 1 && this.Alert.DivisionCode !== "") {
                setTimeout(function () {
                    //me.divisionDropDownList.enable(false);
                }, 0);
            }
            items = null;
        }
        if (this.productDropDownList) {
            items = this.productDropDownList.dataSource.data();
            if (items && items.length == 1 && this.Alert.ProductCode !== "") {
                setTimeout(function () {
                    //me.productDropDownList.enable(false);
                }, 0);
            }
            items = null;
        }
        if (this.jobDropDownList) {
            items = this.jobDropDownList.dataSource.data();
            if (items && items.length == 1 && this.Alert.JobNumber > 0) {
                setTimeout(function () {
                    //me.jobDropDownList.enable(false);
                }, 0);
            }
            items = null;
        }
        if (this.jobComponentDropDownList) {
            items = this.jobComponentDropDownList.dataSource.data();
            if (items && items.length == 1 && this.Alert.JobComponentNumber > 0) {
                setTimeout(function () {
                    //me.jobComponentDropDownList.enable(false);
                }, 0);
            }
            items = null;
        }
    }
    checkSingleBoard() {
        let me = this;
        var items: any = null;
        if (this.boardDropDownList) {
            items = this.boardDropDownList.dataSource.data();
            if (items && items.length == 1 && this.Alert.BoardID > 0) {
                setTimeout(function () {
                    //me.jobComponentDropDownList.enable(false);
                }, 0);
            }
            items = null;
        }
        if (this.boardSprintDropDownList) {
            items = this.boardSprintDropDownList.dataSource.data();
            if (items && items.length == 1 && this.Alert.SprintID > 0) {
                setTimeout(function () {
                    //me.jobComponentDropDownList.enable(false);
                }, 0);
            }
            items = null;
        }
        if (this.boardStateDropDownList) {
            items = this.boardStateDropDownList.dataSource.data();
            if (items && items.length == 1 && this.Alert.BoardStateID > 0) {
                setTimeout(function () {
                    //me.jobComponentDropDownList.enable(false);
                }, 0);
            }
            items = null;
        }
    }
    saveClick() {
        this.save();
    }
    cancelClick() {
        this.cancel();
    }
    save() {
        if (!this.Alert.JobNumber || this.Alert.JobNumber == 0) {
            this.showErrorNotification("Select a job.");
            return false;
        }
        if (!this.Alert.JobComponentNumber || this.Alert.JobComponentNumber == 0) {
            this.showErrorNotification("Select a component.");
            return false;
       }
        if (this.isCopy == true) {
            this.copy();
        } else {
            this.transfer();
        }
    }
    cancel() {
        wvbridge.CloseWindow();
    }
    copy() {

        if (this.formType == 3) {
            var hasTemplate = false;
            var hasState = false;
            //var hasEmployee = false;
            if (this.Alert.AlertAssignmentTemplateID && isNaN(this.Alert.AlertAssignmentTemplateID) == false && this.Alert.AlertAssignmentTemplateID > 0) {
                hasTemplate = true;
            }
            if (this.Alert.AlertStateID && isNaN(this.Alert.AlertStateID) == false && this.Alert.AlertStateID > 0) {
                hasState = true;
            }
            //if (this.Alert.AssignedEmployeeCode && this.Alert.AssignedEmployeeCode != '') {
            //    hasEmployee = true;
            //}
            if (hasTemplate == true && hasState == false) {
                this.showErrorNotification("Select a state.");
                return false;
            }
            //if (hasTemplate == true && hasState == true && hasEmployee == false) {
            //    this.showErrorNotification("Select an employee or select unassigned.");
            //    return false;
            //}
            if (this.Alert.AlertCategoryID === 71 && !this.jobHasSchedule) {
                this.showErrorNotification("Job does not have a schedule.");
                return false;
            }
        }
        this.showProgress(true);
        if (!this.Alert.BoardID || this.Alert.BoardID == undefined || this.Alert.BoardID == null) {
            this.Alert.BoardID = 0;
        }
        if (!this.Alert.SprintID || this.Alert.SprintID == undefined || this.Alert.SprintID == null) {
            this.Alert.SprintID = 0;
        }
        if (!this.Alert.BoardStateID || this.Alert.BoardStateID == undefined || this.Alert.BoardStateID == null) {
            this.Alert.BoardStateID = 0;
        }
        this.Alert.BoardID = this.Alert.BoardID
        this.Alert.SprintID = this.Alert.SprintID;
        this.Alert.BoardStateID = this.Alert.BoardStateID;
        let me = this;

        this.service.copyAlert(this.Alert, this.copyComments, this.copyAttachments)
            .then(response => {
                if (response && response.content) {
                   //console.log(response.content)
                    if (response.content.Success == true) {
                        var subject: string = "";
                        if (response.content.Data.Subject) {
                            subject = decodeURI(response.content.Data.Subject);
                            console.log("subject?", subject)
                        }
                        if (response.content.Data && response.content.Data.NewAlertID > 0) {
                            wvbridge.OpenRadWindow(subject, 'Desktop_AlertView?AlertID=' + response.content.Data.NewAlertID + '&SprintID=0', 0, 0, false);
                            wvbridge.CloseWindow();
                        }
                    } else {
                        if (response.content.Message != '') {
                            this.alert(response.content.Message);
                        }
                    }
                }
            })
            .then(() => {
                this.showProgress(false);
            });
    }
    transfer() {
        this.showProgress(true);
        if (!this.Alert.BoardID || this.Alert.BoardID == undefined || this.Alert.BoardID == null) {
            this.Alert.BoardID = 0;
        }
        if (!this.Alert.SprintID || this.Alert.SprintID == undefined || this.Alert.SprintID == null) {
            this.Alert.SprintID = 0;
        }
        if (!this.Alert.BoardStateID || this.Alert.BoardStateID == undefined || this.Alert.BoardStateID == null) {
            this.Alert.BoardStateID = 0;
        }
        this.service.transferAlert(this.Alert.ID, this.Alert.JobNumber, this.Alert.JobComponentNumber,  this.Alert.BoardID, this.Alert.SprintID, this.Alert.BoardStateID)
            .then(response => {
                if (response && response.content) {
                    if (response.content.Success == true) {
                        if (!this.Alert.SprintID || this.Alert.SprintID == undefined || this.Alert.SprintID == null) {
                            this.Alert.SprintID = 0;
                        }
                        var oldUrl = 'Desktop_AlertView?AlertID=' + this.callingAlertId + '&SprintID=' + this.callingSprintId;
                        var newUrl = 'Desktop_AlertView?AlertID=' + this.Alert.ID + '&SprintID=' + this.Alert.SprintID;
                        //console.log("open URL:", url)
                        setTimeout(function () {
                            //this will not work on an aurelia page, use callback on iframedialog
                            //wvbridge.RefreshWindowWithNewURL(oldUrl, newUrl)
                            wvbridge.CloseWindow();
                        }, 10);
                    } else {
                        if (response.content.Message != '') {
                            this.alert(response.content.Message);
                        }
                    }
                }
            })
            .then(() => {
                this.showProgress(false);
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
        //        }
        //    }
        //}
    }
    assigneeChange(e) {
        this.assigneesChanged = true;
    }

    init() {
        this.service.initCopyTransfer(this.Alert.ID, this.Alert.SprintID).then(response => {
            var clients = [];
            var divisions = [];
            var products = [];
            var jobs = [];
            var components = [];
            var dataSource = new kendo.data.DataSource({
                data: response.content.JobComponents
            });
            if (response.content.JobComponents.length <= 1) {
                this.pickComponent = false;
                this.Alert.JobComponentNumber = response.content.JobComponents[0].JobComponentNumber;
                this.jobComponentDescription = response.content.JobComponents[0].JobComponentDescription;
            }
            for (var i = 0; i < response.content.JobComponents.length; i++) {
                response.content.JobComponents[i].Text = response.content.JobComponents[i].JobComponentNumber.toString().padStart(3, '0') + ' - ' + response.content.JobComponents[i].JobComponentDescription;
                if (this.Alert.JobNumber > 0 && this.Alert.JobComponentNumber > 0) {
                    if (response.content.JobComponents[i].JobNumber === this.Alert.JobNumber) {
                        this.Alert.ClientCode = response.content.JobComponents[i].ClientCode;
                        this.Alert.DivisionCode = response.content.JobComponents[i].DivisionCode;
                        this.Alert.ProductCode = response.content.JobComponents[i].ProductCode;
                    }
                }
            }
            this.componentsDataSource.data(response.content.JobComponents);
            dataSource.group({ field: "ClientCode" });
            var view = dataSource.view();
            for (var i = 0; i < view.length; i++) {
                var client = {
                    ClientCode: view[i].items[0].ClientCode,
                    ClientName: view[i].items[0].ClientName
                }
                clients.push(client);
            }
            if (clients.length <= 1) {
                this.pickClient = false;
                this.Alert.ClientCode = clients[0].ClientCode;
                this.clientName = clients[0].ClientName;
            }
            this.clientsDataSource.data(clients);
            dataSource.group([{ field: "ClientCode" }, { field: "DivisionCode" }]);
            view = dataSource.view();
            for (var i = 0; i < view.length; i++) {
                for (var c = 0; c < view[i].items.length; c++) {
                    var division = {
                        ID: divisions.length + 1,
                        ClientCode: view[i].items[c].items[0].ClientCode,
                        DivisionCode: view[i].items[c].items[0].DivisionCode,
                        DivisionName: view[i].items[c].items[0].DivisionName
                    }
                    divisions.push(division);
                }
            }
            if (divisions.length <= 1) {
                this.pickDivision = false;
                this.Alert.DivisionCode = divisions[0].DivisionCode;
                this.divisionName = divisions[0].DivisionName;
            }
            this.divisionsDataSource.data(divisions);
            dataSource.group([{ field: "ClientCode" }, { field: "DivisionCode" }, { field: "ProductCode" }]);
            view = dataSource.view();
            for (var i = 0; i < view.length; i++) {
                for (var c = 0; c < view[i].items.length; c++) {
                    for (var n = 0; n < view[i].items[c].items.length; n++) {
                        var product = {
                            ID: products.length + 1,
                            ClientCode: view[i].items[c].items[n].items[0].ClientCode,
                            DivisionCode: view[i].items[c].items[n].items[0].DivisionCode,
                            ProductCode: view[i].items[c].items[n].items[0].ProductCode,
                            ProductName: view[i].items[c].items[n].items[0].ProductName
                        }
                        products.push(product);
                    }
                }
            }
            if (products.length <= 1) {
                this.pickProduct = false;
                this.Alert.ProductCode = products[0].ProductCode;
                this.productName = products[0].ProductName;
            }
            this.productsDataSource.data(products);
            dataSource.group({ field: "JobNumber" });
            view = dataSource.view();
            for (var i = 0; i < view.length; i++) {
                var job = {
                    ClientCode: view[i].items[0].ClientCode,
                    DivisionCode: view[i].items[0].DivisionCode,
                    ProductCode: view[i].items[0].ProductCode,
                    JobNumber: view[i].items[0].JobNumber,
                    JobDescription: view[i].items[0].JobDescription,
                    Text: view[i].items[0].JobNumber.toString().padStart(6, '0') + ' - ' + view[i].items[0].JobDescription
                }
                if (this.Alert.JobNumber > 0) {
                    if (job.JobNumber === this.Alert.JobNumber) {
                        this.Alert.ClientCode = job.ClientCode;
                        this.Alert.DivisionCode = job.DivisionCode;
                        this.Alert.ProductCode = job.ProductCode;
                    }
                }
                jobs.push(job);
            }
            if (jobs.length <= 1) {
                this.pickJob = false;
                this.Alert.JobNumber = jobs[0].JobNumber;
                this.jobDescription = jobs[0].JobDescription;
            }
            jobs.reverse();
            this.jobsDataSource.data(jobs);
            this.checkForBoard();
        });
    }

    activate(params: any) {
        let me = this;
        if (params) {
            // Type 1 = Copy, 2 = Move, 3 = Routed Copy, 4 = Routed Move
            if (params.Type && isNaN(params.Type) == false) {
                this.formType = params.Type * 1;
            }
            if (this.formType == 1) { // Type 1 = Copy

            }
            if (this.formType == 2) { // Type 2 = Move
                this.isCopy = false;
                this.saveButtonText = 'Move'
            }
            if (this.formType == 3) { // Type 3 = Routed Copy
                this.isRouted = true;
            }
            if (this.formType == 4) { // Type 4 = Routed Move
                this.isRouted = true;
                this.isCopy = false;
                this.saveButtonText = 'Move'
            }
            //console.log("formType", this.formType)
            if (params.AlertID) {
                this.Alert.ID = params.AlertID;
            }
            if (params.SprintID) {
                this.Alert.SprintID = this.Alert.SprintID;
            }
            if (params.IsProof) {
                this.isProof = params.IsProof;
            }
            //console.log("proof", this.isProof);
        //    if (params.IsRouted) {
        //        this.isRouted = params.IsRouted;
        //    }
        }
        //console.log(this.formType)
        this.init();
    }
    attached() {
        let me = this;
        $(document).ready(function () {
            me.clientDropDownList.focus();
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

            //me.alertTemplatesDropDownList.wrapper.keypress(function (e) {
            //    me.alertTemplatesDropDownList.open();
            //    me.alertTemplatesDropDownList.filterInput.val(me.alertTemplatesDropDownList.filterInput.val() + e.key);
            //});
            //me.alertTemplateStatesDropDownList.wrapper.keypress(function (e) {
            //    me.alertTemplateStatesDropDownList.open();
            //    me.alertTemplateStatesDropDownList.filterInput.val(me.alertTemplateStatesDropDownList.filterInput.val() + e.key);
            //});
            //me.alertTemplateStatesDropDownList.wrapper.keypress(function (e) {
            //    me.alertTemplateStatesDropDownList.open();
            //    me.alertTemplateStatesDropDownList.filterInput.val(me.alertTemplateStatesDropDownList.filterInput.val() + e.key);
            //});
            //me.boardDropDownList.wrapper.keypress(function (e) {
            //    me.boardDropDownList.open();
            //    me.boardDropDownList.filterInput.val(me.boardDropDownList.filterInput.val() + e.key);
            //});
            //me.boardSprintDropDownList.wrapper.keypress(function (e) {
            //    me.boardSprintDropDownList.open();
            //    me.boardSprintDropDownList.filterInput.val(me.boardSprintDropDownList.filterInput.val() + e.key);
            //});
            //me.boardStateDropDownList.wrapper.keypress(function (e) {
            //    me.boardStateDropDownList.open();
            //    me.boardStateDropDownList.filterInput.val(me.boardStateDropDownList.filterInput.val() + e.key);
            //});

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
        //this.checkSingleAll();
    }
    detached() {
        if (this.disposables && this.disposables.length > 0) {
            for (var i = 0; i < this.disposables.length; i++) {
                this.disposables[i].dispose();
            }
        }
    }

    constructor(service: AlertService, dialogService: DialogService, bindingEngine: BindingEngine) {
        super();

        this.bindingEngine = bindingEngine;
        this.Alert = new AlertModel;
        this.service = service;
        this.dialogService = dialogService;

        this.clientsDataSource = new kendo.data.DataSource();
        this.divisionsDataSource = new kendo.data.DataSource();
        this.productsDataSource = new kendo.data.DataSource();
        this.jobsDataSource = new kendo.data.DataSource();
        this.componentsDataSource = new kendo.data.DataSource();

        this.boardDataSource = new kendo.data.DataSource();
        this.boardSprintDataSource = new kendo.data.DataSource();
        this.boardStateDataSource = new kendo.data.DataSource();

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
                            AlertTemplateID: me.Alert.AlertAssignmentTemplateID
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
            }
        });
        this.alertTemplateStateEmployeesDataSource = service.getAlertTemplateStateEmployeesDataSource({
            transport: {
                read: {
                    data: function () {
                        return {
                            AlertID: ((me.Alert.ID && me.Alert.ID > 0) ? me.Alert.ID : 0),
                            AlertTemplateID: me.Alert.AlertAssignmentTemplateID,
                            AlertStateID: me.Alert.AlertStateID,
                            ShowAll: me.showAllEmployees
                        }
                    }
                }
            }
        });
        this.alertTemplateStateEmployeesDataSourceMultiSelectRouted = service.getAlertTemplateStateEmployeesDataSource({
            transport: {
                read: {
                    data: function () {
                        var showAll: boolean = false;
                        if (me.stateChanged == true) {
                            showAll = me.showingAllEmployees ? me.showingAllEmployees : false
                        } else {
                            showAll = true;
                        }
                        return {
                            AlertID: ((me.Alert.ID && me.Alert.ID > 0) ? me.Alert.ID : 0),
                            AlertTemplateID: ((me.Alert.AlertAssignmentTemplateID && me.Alert.AlertAssignmentTemplateID > 0) ? me.Alert.AlertAssignmentTemplateID : 0),
                            AlertStateID: ((me.Alert.AlertStateID && me.Alert.AlertStateID > 0) ? me.Alert.AlertStateID : 0),
                            ShowAll: showAll
                        }
                    }
                }
            },
            requestStart: function (e) {
                //console.log("request start", me.Alert.AlertAssignmentTemplateID, me.Alert.AlertStateID, me.isRouted)
                if (e.type === "read") {
                    if (!me.Alert.AlertAssignmentTemplateID || me.Alert.AlertAssignmentTemplateID == 0 || !me.Alert.AlertStateID || me.Alert.AlertStateID == 0 || me.isRouted == false) {
                        e.sender.data([]);
                        e.preventDefault();
                        //console.log("hello")
                    }
                }
                //console.log("rStart", me.Alert.Assignees);
            },
            requestEnd: function (e) {
                //console.log("request end")
                var type = e.type;
                var items = [];
                items = e.response;
                if (me.stateChanged == true) {
                    //  On change, this replaces the Alert.Assignees with the selected state's default(s)
                    me.stateChanged = false;
                    if (items) {
                        try {
                            me.Alert.Assignees = new Array<string>();
                            for (var i = 0; i < items.length; i++) {
                                if (items[i].IsDefault == true) {
                                    me.Alert.Assignees.push(items[i].Code);
                                }
                            }
                        } catch (e) {
                        }
                    }
                } else {
                    if (items) {
                    }
                }
            }
        });

        let me = this;


    }

}
