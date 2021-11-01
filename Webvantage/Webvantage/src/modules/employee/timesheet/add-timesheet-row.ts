import { bindable, inject } from 'aurelia-framework';
import { TimesheetService } from 'services/employee/timesheet-service';
import { ModuleBase } from 'modules/base/module-base';

@inject(TimesheetService)
export class AddTimesheetRow extends ModuleBase{

    @bindable employeeTimeId: number;
    @bindable employeeTimeDetailId: number;
    @bindable employeeCode: string;
    @bindable showPostPeriodWarning: boolean;
    @bindable canAdd: boolean = true;

    jobsDataSource: kendo.data.DataSource;
    jobsDropDownList: kendo.ui.DropDownList;
    functionDataSource: kendo.data.DataSource;
    functionDropDownList: kendo.ui.DropDownList;
    functionAutoComplete: kendo.ui.AutoComplete;
    hoursNumericTextBox: kendo.ui.NumericTextBox;
    entryDateEditor: kendo.ui.DatePicker;
    service: TimesheetService;

    entryDate: Date;
    comment: string;
    functionCode: string;
    hours: number;
    isCommentRequired: boolean;
    title: string;

    entryDateEditorOnChange() {
        var val: any = this.entryDateEditor.value();
        if (!val) {
            val = this.entryDateEditor.element.val();
            var date: any = this.parseShortDate(val);
            if (date && date.isValid) {
                this.entryDate = new Date(date.value);
            }
        } else {
            return this.checkIfPostPeriodIsAvailable();
        }
    }
    checkIfPostPeriodIsAvailable() {
        if (this.entryDate) {
            return this.service.checkIfPostPeriodIsAvailable(this.entryDate).then(response => {
                if (response.content.PostPeriodIsAvailable == false || response.content.PostPeriodIsAvailable == "false") {
                    this.showPostPeriodWarning = true;
                    this.canAdd = false;
                } else {
                    this.showPostPeriodWarning = false;
                    this.canAdd = true;
                }
            });
        }
    }

    save() {
        if (!this.canAdd) {
            // no message needed... should be shown on the page
            return false;
        }
        if (this.isCommentRequired === true && (!this.comment || this.comment == undefined || this.comment == '')) {
            this.alert('Please enter a comment');
            return false;
        }
        if (!this.entryDate) {
            this.alert('Please select a date.');
            return false;
        }
        //return this.service.saveHoursToAlert(this.alertId, this.entryDate, this.functionCode, this.hours, this.comment).then(response => {
        //    if (response.content.Success === false && response.content.Message) {
        //        this.alert(response.content.Message);
        //    } else {
        //        wvbridge.RefreshTimesheetWindows();
        //    }
        //    return response;
        //});

    }
    clear() {
        this.entryDate = new Date();
        this.entryDate.setHours(0, 0, 0, 0);
        this.functionCode = null;
        this.hours = null;
        this.comment = null;
        this.showPostPeriodWarning = false;
        //this.checkIfPostPeriodIsAvailable();
   }
   activate(params: any) {
       if (params.employeeCode) {
           this.employeeCode = params.employeeCode;
       }
       if (params.et_id) {
           this.employeeTimeId = params.et_id;
       }
       if (params.etd_id) {
           this.employeeTimeDetailId = params.etd_id;
       }
    }
    attached() {
        let me = this;
        this.init();
        $(document).ready(function () {
            me.entryDateEditor.element.change(function () {
                me.entryDateEditorOnChange();
            });
        });
        (<any>window).MvcSaveBridge = function () {
            return me.save();
        }
    }
    loadFunctionsAndCategories() {
        this.employeeCode = 'ama'
        return this.service.getFunctionsAndCategories(this.employeeCode, true, false).then(response => {
            this.functionDataSource.data(response.content);
            this.functionDropDownList.setDataSource(this.functionDataSource);
        });
    }
    init() {
        this.clear();
        this.loadFunctionsAndCategories()
        //return this.service.initNewWorkItemTime(this.alertId).then(response => {
        //    this.functionCode = response.content.EmployeeDefaultFunctionCode;
        //    this.isCommentRequired = response.content.CommentRequired;
        //    this.functionDataSource.data(response.content.Functions);
        //    this.functionDropDownList.setDataSource(this.functionDataSource);
        //    this.title = response.content.Title;
        //    this.hoursNumericTextBox.focus();
        //});
    }

    constructor(service: TimesheetService) {
        super();
        this.service = service;
        let me = this;
        this.functionDataSource = new kendo.data.DataSource();
        this.jobsDataSource = new kendo.data.DataSource();
    }

}
