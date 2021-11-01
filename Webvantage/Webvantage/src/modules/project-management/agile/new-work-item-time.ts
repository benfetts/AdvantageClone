import { bindable, inject } from 'aurelia-framework';
import { AgileService } from 'services/project-management/agile/agile-service';
import { ModuleBase } from 'modules/base/module-base';

@inject(AgileService)
export class NewWorkItemTime extends ModuleBase {

    @bindable alertId: number;
    @bindable showPostPeriodWarning: boolean;
    @bindable showButtonsForOldPages: boolean;
    @bindable canAdd: boolean = true;

    functionDataSource: kendo.data.DataSource;
    functionDropDownList: kendo.ui.DropDownList;
    hoursNumericTextBox: kendo.ui.NumericTextBox;
    entryDateEditor: kendo.ui.DatePicker;
    service: AgileService;

    entryDate: Date;
    comment: string;
    functionCode: string;
    hours: number;
    isCommentRequired: boolean;
    title: string;
    IsOldDash: boolean;

    entryDateEditorOnChange() {
        //console.log("entryDateEditorOnChange", this.entryDateEditor.value())
        var val: any = this.entryDateEditor.value();
        if (!val) {
            val = this.entryDateEditor.element.val();
            var date: any = this.parseShortDate(val);
            if (date && date.isValid) {
                this.entryDate = new Date(date.value);
                //console.log("reset")
            }
        }
        return this.checkIfPostPeriodIsAvailable();
    }
    checkIfPostPeriodIsAvailable() {
        let me = this;
        setTimeout(function () {
            me._checkIfPostPeriodIsAvailable()
        }, 10);
    }
    _checkIfPostPeriodIsAvailable() {
        if (this.entryDate) {
            return this.service.checkIfPostPeriodIsAvailable(this.entryDate).then(response => {
                if (response.content.PostPeriodIsAvailable == false || response.content.PostPeriodIsAvailable == "false") {
                    this.showPostPeriodWarning = true;
                    this.canAdd = false;
                } else {
                    this.showPostPeriodWarning = false;
                    this.canAdd = true;
                }
                if (this.IsOldDash == true) {
                    //console.log("IsOldDash");
                } else {
                    wvbridge.disableWorkItemTimeSaveButton(this.showPostPeriodWarning);
                }
            });
        }
    }

    save() {
        if (!this.canAdd) {
            // no message needed... should be shown on the page
            return false;
        }
        if (this.isCommentRequired === true && (!this.comment  || this.comment == undefined || this.comment == '')) {
            this.alert('Please enter a comment');
            return false;
        }
        if (!this.entryDate) {
            this.alert('Please select a date.');
            return false;
        }
        if (!this.functionCode || this.functionCode == "") {
            this.alert('Please select a function.');
            return false;
        }
        return this.service.saveHoursToAlert(this.alertId, this.entryDate, this.functionCode, this.hours, this.comment).then(response => {
            if (response.content.Success === false && response.content.Message) {
                this.alert(response.content.Message);
            } else {
                //Need to rework the refresh of the timesheet and objects when time is added.
                //wvbridge.RefreshTimesheetWindows();
            }
            return response;
        });
    }

    clear() {
        this.entryDate = new Date();
        this.entryDate.setHours(0, 0, 0, 0);
        this.checkIfPostPeriodIsAvailable();
        this.functionCode = null;
        this.hours = null;
        this.comment = null;
        this.showPostPeriodWarning = false;
    }
    addClick() {
        let result = this.save();
        if (typeof result === 'boolean') {
            if (result) {
                this.closeAndRefreshTimeWindows();
            }
        } else {
            result.then(response => {
                this.closeAndRefreshTimeWindows();
            });
        }
    }
    closeAndRefreshTimeWindows() {
        if (window.parent) {
            //try {
            //    wvbridge.RefreshTimesheetWindows();
            //} catch (ex) {
            //}
            wvbridge.CloseWindow();
        }
    }
    cancelClick() {
        wvbridge.CloseWindow();
    }
    activate(params: any) {
        if (params.AlertID) {
            this.alertId = params.AlertID;
        }
        if (params.IsOldPage) {
            this.showButtonsForOldPages = params.IsOldPage;
        }
        if (params.IsOldDash) {
            this.IsOldDash = params.IsOldDash;
            this.showButtonsForOldPages = params.IsOldDash;
       }
    }
    attached() {
        let me = this;
        this.init();
        $(document).ready(function () {
            //me.entryDateEditor.element.change(function () {
            //    me.entryDateEditorOnChange();
            //});
        });
        (<any>window).MvcSaveBridge = function() {
            return me.save();
        }
    }
    init() {
        //this.clear();
        this.functionCode = null;
        this.hours = null;
        this.comment = null;
        return this.service.initNewWorkItemTime(this.alertId).then(response => {
            this.functionCode = response.content.EmployeeDefaultFunctionCode;
            this.isCommentRequired = response.content.CommentRequired;
            this.functionDataSource.data(response.content.Functions);
            this.functionDropDownList.setDataSource(this.functionDataSource);
            this.title = response.content.Title;
            this.hoursNumericTextBox.focus();
            this.entryDateEditor.value(response.content.Date);
            this.entryDate = this.entryDateEditor.value();
            this.showPostPeriodWarning = false;
            this.checkIfPostPeriodIsAvailable();
        });
    }

    constructor(service: AgileService) {
        super();
        this.service = service;
        let me = this;
        this.functionDataSource = new kendo.data.DataSource();
    }

}
