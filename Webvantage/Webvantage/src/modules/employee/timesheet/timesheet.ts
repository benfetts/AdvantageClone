import { ModuleBase } from 'modules/base/module-base';
import { TimesheetService } from 'services/employee/timesheet-service';
import { EmployeeTimesheet } from 'models/employee/employee-timesheet';
import { bindable, inject } from 'aurelia-framework';
import * as moment from 'moment';
import { DialogService } from 'aurelia-dialog';
import { AddTimesheetRow } from './add-timesheet-row';
import { AddTimesheetRowDialog } from './add-timesheet-row-dialog';

@inject(TimesheetService, DialogService)
export class Timesheet extends ModuleBase {

    @bindable employeeCode: string = 'ama'
    recordsDs: kendo.data.DataSource;
    startDate: Date;
    endDate: Date;
    dayView: number = 1;
    hideWeekends: boolean = false;
    service: TimesheetService;
    records: Array<EmployeeTimesheet.Row>;
    settings: EmployeeTimesheet.Settings;
    current: Date;
    days: Array<any>;
    calendar: kendo.ui.Calendar;
    settingsDialog: kendo.ui.Dialog;
    copyToDialog: kendo.ui.Dialog;
    dialogService: DialogService;
    day1Total: number;
    day2Total: number;
    day3Total: number;
    day4Total: number;
    day5Total: number;
    day6Total: number;
    day7Total: number;

    showCommentsButtonGroup: any;
    startWeekOnButtonGroup: any;
    daysToDisplayButtonGroup: any;

    getTimesheetRows(loadNew: boolean) {
        if (loadNew) {
            //this.saveChanges();
           //console.log(this.employeeCode + '>>>' + this.startDate)
            this.service.getTimesheetRows(this.employeeCode, this.startDate).then(response => {
                var rows = response.content
                for (var i = 0; i < rows.length; i++) {
                    rows[i].Day1Date = moment(rows[i].Day1Date).toDate();
                    rows[i].Day2Date = moment(rows[i].Day2Date).toDate();
                    rows[i].Day3Date = moment(rows[i].Day3Date).toDate();
                    rows[i].Day4Date = moment(rows[i].Day4Date).toDate();
                    rows[i].Day5Date = moment(rows[i].Day5Date).toDate();
                    rows[i].Day6Date = moment(rows[i].Day6Date).toDate();
                    rows[i].Day7Date = moment(rows[i].Day7Date).toDate();
                }
                this.recordsDs = new kendo.data.DataSource({
                    data: response.content,
                    filter: {
                        logic: 'or'
                    }
                })
                this.filterRows();
            }).catch(response => {
                this.recordsDs.data([]);
                this.filterRows();
            });
        } else {
            this.filterRows();
        }
    }
    filterRows() {
        var filters = [];
        this.recordsDs.filter([]);
        for (var i = 0; i < this.days.length; i++){
            if (this.days[i].IsVisible === true) {
                filters.push({ field: 'Day' + (i + 1).toString() + 'ID', operator: 'isnotnull' });
            }
        }
        if (filters.length !== 7) {
            this.recordsDs.filter(filters);
        }
        let me = this;
        setTimeout(function () {
            me.records = <any>me.recordsDs.view();
            me.calculateTotals();
        }, 0);
    }

    setDayView(dayView: number) {
        this.dayView = dayView;
        this.setDate(0);
    }
    incrementDate() {
        this.setDate(1);
    }
    decrementDate() {
        this.setDate(-1);
    }
    resetDate() {
        this.current = new Date();
        this.setDate(0);
    }
    setDate(offset: number) {
        var isNewTimesheet = false;
        var nextDate = new Date(this.current);
        nextDate.setDate(nextDate.getDate() + (offset * this.dayView));
        if ((!this.startDate || nextDate < this.startDate) || (!this.endDate || nextDate > this.endDate)) {
            isNewTimesheet = true;
        }
        if (isNewTimesheet) {
            this.days = [];
            this.startDate = new Date(nextDate);
            if (this.startDate.getDay() !== Number(this.settings.StartTimesheetOnDayOfWeek)) {
                var c = 0;
                while (this.startDate.getDay() !== Number(this.settings.StartTimesheetOnDayOfWeek) && c < 10) {
                    this.startDate.setDate(this.startDate.getDate() - 1);
                }
            }
            this.endDate = new Date(this.startDate);
            this.endDate.setDate(this.endDate.getDate() + 6);
        }
        if (this.dayView !== 1) {
            this.current = new Date(this.startDate);
        } else {
            this.current = new Date(nextDate);
        }
        this.days = [];
        for (var i = 0; i < 7; i++) {
            var currentDate = new Date(this.startDate);
            var day = '';
            var isWeekend = false;
            var isVisible = true;
            currentDate.setDate(currentDate.getDate() + i);
            switch (currentDate.getDay()) {
                case 0:
                    isWeekend = true;
                    day = "Sunday";
                    break;
                case 1:
                    day = "Monday";
                    break;
                case 2:
                    day = "Tuesday";
                    break;
                case 3:
                    day = "Wednesday";
                    break;
                case 4:
                    day = "Thursday";
                    break;
                case 5:
                    day = "Friday";
                    break;
                case 6:
                    isWeekend = true;
                    day = "Saturday";
                    break;
            }
            if (this.dayView === 1) {
                isVisible = currentDate.getTime() === this.current.getTime() ? true : false;
            } else if (this.hideWeekends === true && isWeekend === true) {
                isVisible = false;
            } else {
                isVisible = true;
            }
            var dayObj = {
                Date: currentDate,
                Text: (currentDate.getMonth() + 1).toString() + '/' + currentDate.getDate().toString(),
                Day: day,
                IsWeekend: isWeekend,
                IsVisible: isVisible
            }
            this.days.push(dayObj);
        }
        this.getTimesheetRows(isNewTimesheet);
    }
    goToDate(date: Date) {
        var d = new Date(date);
        this.current = d;
        this.setDayView(1);
    }
    recordChanged(record: any) {
        record.changed = true;
        let me = this;
        //console.log(record);
        setTimeout(function () {
            me.calculateTotals();
        }, 100);
    }
    calculateTotals() {
        var day1total = 0, day2total = 0, day3total = 0, day4total = 0, day5total = 0, day6total = 0, day7total = 0;
        if (this.recordsDs && this.recordsDs.data().length > 0) {
            for (var i = 0; i < this.recordsDs.data().length; i++) {
                var rcd = this.recordsDs.data()[i];
                if (rcd.Day1Hours && !isNaN(rcd.Day1Hours)) {
                    day1total += Number(rcd.Day1Hours);
                }
                if (rcd.Day2Hours && !isNaN(rcd.Day2Hours)) {
                    day2total += Number(rcd.Day2Hours);
                }
                if (rcd.Day3Hours && !isNaN(rcd.Day3Hours)) {
                    day3total += Number(rcd.Day3Hours);
                }
                if (rcd.Day4Hours && !isNaN(rcd.Day4Hours)) {
                    day4total += Number(rcd.Day4Hours);
                }
                if (rcd.Day5Hours && !isNaN(rcd.Day5Hours)) {
                    day5total += Number(rcd.Day5Hours);
                }
                if (rcd.Day6Hours && !isNaN(rcd.Day6Hours)) {
                    day6total += Number(rcd.Day6Hours);
                }
                if (rcd.Day7Hours && !isNaN(rcd.Day7Hours)) {
                    day7total += Number(rcd.Day7Hours);
                }
            }
        }
        this.day1Total = day1total;
        this.day2Total = day2total;
        this.day3Total = day3total;
        this.day4Total = day4total;
        this.day5Total = day5total;
        this.day6Total = day6total;
        this.day7Total = day7total;
    }
    saveChanges() {
        var rowsToSave = [];
        if (this.recordsDs && this.recordsDs.data().length > 0) {
            for (var i = 0; i < this.recordsDs.data().length; i++) {
                var rcd: any = this.recordsDs.data()[i];
                if (rcd.changed === true) {
                    rowsToSave.push(rcd);
                }
            }
        }
        if (rowsToSave.length > 0) {
            this.service.saveTimesheetRows(this.employeeCode, rowsToSave).then(response => {
                this.showSuccessNotification('Timesheet Saved!');
                this.getTimesheetRows(true);
            });
        }
    }
    calendarOnChange() {
        this.current = this.calendar.value();
        this.setDate(0);
    }
    settingsClick() {
        this.settingsDialog.open();
    }
    addNewClick() {
        this.dialogService.open({ viewModel: AddTimesheetRowDialog, model: { EmployeeCode: this.employeeCode } }).whenClosed(response => {
            if (!response.wasCancelled) {
                
            }
        });
    }
    addNewClose() {

    }
    settingsClose() {
        this.service.saveTimesheetUserSettings(this.settings).then(response => {
            var daysToDisplay = Number(this.settings.DaysToDisplay);
            if (daysToDisplay !== 1) {
                if (daysToDisplay === 5) {
                    this.hideWeekends = true;
                } else {
                    this.hideWeekends = false;
                }
                daysToDisplay = 7;
            } else {
                this.hideWeekends = false;
            }
            var StartTimesheetOnDay = Number(this.settings.StartTimesheetOnDayOfWeek);
            if (this.startDate.getDay() !== StartTimesheetOnDay) {
                var today = new Date();
                if (today >= this.startDate && today <= this.endDate) {
                    this.current = today;
                } else {
                    while (this.current.getDay() !== 1) {
                        this.current.setDate(this.current.getDate() + 1);
                    }
                }
                this.startDate = null;
                this.endDate = null;
            }
            this.dayView = daysToDisplay;
            this.setDate(0);
        });
    }
    copyFromMyProjectsClick() {
        this.alert('copy from my projects click');
    }
    copyFromMyTimeTemplatesClick() {
        this.alert('copy from my templates click');
    }
    copyFromMyCalendarClick() {
        this.alert('copy from my calendar click');
    }
    copyToClick() {
        this.copyToDialog.open();
    }
    
    activate(params: any) {
        //console.log(params)
        if (params) {
            if (params.EmployeeCode) {
                this.employeeCode = params.EmployeeCode;
            }
            if (params.Start) {
                this.startDate = new Date();
            }
        }
    }
    attached() {
       //console.log("attached:  " + this.employeeCode + " " + this.startDate)
        this.service.initTimesheet(this.employeeCode).then(response => {
            //this.employeeCode = response.content.EmployeeCode;
            if (response.content.UserSettings) {
                if (response.content.UserSettings.DaysToDisplay !== 1) {
                    this.dayView = 7;
                    if (response.content.UserSettings.DaysToDisplay === 5) {
                        this.hideWeekends = true;
                    }
                } else {
                    this.dayView = 1;
                }

            } else {
                this.dayView = 1;
            }
            this.current = new Date(moment(response.content.StartDate).format("LLL"));
            this.settings = response.content.UserSettings;
            if (this.settings) {

                if (this.settings.DaysToDisplay === 1) {
                    this.daysToDisplayButtonGroup.select(0)
                } else if (this.settings.DaysToDisplay === 5) {
                    this.daysToDisplayButtonGroup.select(1);
                } else if (this.settings.DaysToDisplay === 7) {
                    this.daysToDisplayButtonGroup.select(2);
                } else {
                    this.daysToDisplayButtonGroup.select(0);
                }

                if (this.settings.StartTimesheetOnDayOfWeek === 6) {
                    this.startWeekOnButtonGroup.select(0) //saturday
                } else if (this.settings.StartTimesheetOnDayOfWeek === 0) {
                    this.startWeekOnButtonGroup.select(1); //sunday
                } else if (this.settings.StartTimesheetOnDayOfWeek === 1) {
                    this.startWeekOnButtonGroup.select(2); //monday
                } else {
                    this.startWeekOnButtonGroup.select(0);
                }

                if (this.settings.ShowCommentsUsing === 'none') {
                    this.showCommentsButtonGroup.select(0);
                } else if (this.settings.ShowCommentsUsing === 'icon') {
                    this.showCommentsButtonGroup.select(1)
                } else if (this.settings.ShowCommentsUsing === 'textbox') {
                    this.showCommentsButtonGroup.select(2);
                } else {
                    this.showCommentsButtonGroup.select(0);
                }

            }

            this.setDate(0);
        });
    }

    startWeekOnButtonGroupOnSelect(e) {
        if (this.settings) {
            this.settings.StartTimesheetOnDayOfWeek = Number(e.sender.current().attr('value'));
        }
    }

    showCommentsButtonGroupOnSelect(e) {
        if (this.settings) {
            this.settings.ShowCommentsUsing = e.sender.current().attr('value');
        }
    }

    daysToDisplayButtonGroupOnSelect(e) {
        if (this.settings) {
             this.settings.DaysToDisplay = Number(e.sender.current().attr('value'));
       }
    }

    constructor(service: TimesheetService, dialogService: DialogService) {
        super();
        this.recordsDs = new kendo.data.DataSource({
            filter: {
                logic: 'or'
            }
        });
        this.service = service;
        this.dialogService = dialogService;
    }

}
