import { DashboardService } from 'services/dashboard/dashboard-service';
import { Application } from 'models/common/application';
import { inject, bindable, observable } from 'aurelia-framework'; 
import { ModuleBase } from 'modules/base/module-base';
import { TimesheetService } from 'services/employee/timesheet-service';
import { TimeSummaryModel } from 'models/employee/time-summary';
import { TimesheetDashboard } from 'models/employee/timesheet-dashboard';
import { HttpClient } from 'aurelia-http-client';
import { CardSettingsModel } from 'models/maintenance/card-settings-model';
import { BookmarkEditDialog } from 'modules/dashboard/bookmark-edit-dialog';
import { DialogService } from 'aurelia-dialog';
import { Webvantage } from '../../webvantage';
import { browserWindow } from 'services/utilities/browserWindow'
import { CardSettingsDialog } from 'modules/dashboard/card-settings-dialog';
import { CardSettingsDlgModel } from 'models/dashboard/card-settings-model';

@inject(DashboardService, TimesheetService, 'openModule', DialogService, 'openDialog', Webvantage)
export class Dashboard extends ModuleBase {
    /*
        Public Enum DashboardType

            Alerts = 0
            Assignments = 1
            Tasks = 2
            Reviews = 3
            Appointments = 4
            Bookmarks = 5
            Time = 6

        End Enum
    */
    service: DashboardService;
    dialogService: DialogService;
    timesheetService: TimesheetService;
    GroupByOptions: kendo.data.DataSource = new kendo.data.DataSource();
    cardSettingsDialog: kendo.ui.Dialog;
    assignmentDialog: kendo.ui.Dialog;
    employee: Application.EmployeeInfo;
    navTabStrip: kendo.ui.TabStrip;
    openModule;
    openDialog;

    webvantage: Webvantage;

    @bindable showSearch: boolean = true;
    @bindable assignmentCount: number = 0;
    @bindable alertCount: number = 0;
    @bindable appointmentCount: number = 0;
    @bindable reviewCount: number = 0;
    @bindable hoursToday: number = 0.00;
    @bindable hoursThisWeek: number = 0.00;
    @bindable hasMissingTime: boolean = false;
    @bindable hasDeniedTime: boolean = false;
    @bindable showTimeWarning: boolean = false;
    @bindable timeMessage: string = "";
    @bindable hoursTodayUrl: string = "";
    @bindable isProofingActive: boolean = false;
    @bindable isConceptShareActive: boolean = false;
    @bindable showProofsIcon: boolean = true;
    @bindable isTimesheetActive: boolean = true;
    @bindable isClientPortal: boolean = false;
    @bindable timeSummaries: Array<TimeSummaryModel>;
    @bindable monthlyGoal: number;
    @bindable monthlyHours: number;
    @bindable timesheetDashboard: TimesheetDashboard;
    @bindable hoursTodayString: string;
    @bindable hoursThisWeekString: string;
    @bindable cardSettings: CardSettingsModel;
    @bindable pageNumber: number = 0;
    @bindable pageNumberDisplay: number = 0;
    @bindable pageSize: number = 50;
    @bindable maxPage: number = 0;
    @bindable pagerDisplay: string = "";
    @bindable OpenByDefault: boolean = false;

    weekday: Array<any> = new Array();
    cards: Array<any>;
    cardGroups: Array<any>;
    @bindable bookmarks: Array<any>;  
    dashDate = new Date().toLocaleDateString();
    dashDay = new Date().getDay();
    autoClose = true;
    sortOption: string = '';
    allowSort: boolean = true;
    GroupBy: string = '';
    Type: number;
    Settings: any;
    searchInputExpanded = false;
    collapsed = true;
    hoursData = [];
    goalsData = [];
    dateData = [];
    search: string = "";
    searchassignment: string = "";
    searchalert: string = "";
    searchreview: string = "";
    searchbookmark: string = "";
    reviewItemText: string = "Proofs";
    reviewItemTextSingular: string = "Proof";
    ShowClientNameAssignment: boolean = false;
    ShowJobNumberAssignment: boolean = false;
    ShowJobComponentNumberAssignment: boolean = false;
    ShowJobDescriptionAssignment: boolean = false;
    ShowJobComponentDescriptionAssignment: boolean = false;
    ShowTaskCommentAssignment: boolean = false;
    ShowStateAssignment: boolean = false;
    ShowClientNameAlert: boolean = false;
    ShowJobNumberAlert: boolean = false;
    ShowJobComponentNumberAlert: boolean = false;
    ShowJobDescriptionAlert: boolean = false;
    ShowJobComponentDescriptionAlert: boolean = false;
    ShowTaskCommentAlert: boolean = false;
    ShowStateAlert: boolean = false;
    ShowClientNameReview: boolean = false;
    ShowJobNumberReview: boolean = false;
    ShowJobComponentNumberReview: boolean = false;
    ShowJobDescriptionReview: boolean = false;
    ShowJobComponentDescriptionReview: boolean = false;
    TaskStatus: boolean = false;
    StartDateasofToday: boolean = false;
    TasksOnlyWithStartAndDueDates: boolean = false;
    OpenByDefaultCount: boolean = false;
    cardSettingsOpened: boolean = false;
    Dashboards = [
        //{ Type: 0, Name: 'Assignments', ItemCount: 0 },
        //{ Type: 1, Name: 'Tasks', ItemCount: 0 }
    ]; 
    tabStripSelect(e) {
        var item = $(e.item).find('> .k-link').text();
        //console.log("tabStripSelect", item)
        //this.search = "";
        this.pagerDisplay = "";
        this.pageNumber = 0;
        this.maxPage = 0;
        if (item.toLowerCase().indexOf("assignments") > -1) {  
            this.selectDashboard(1, true);
        } else if (item.toLowerCase().indexOf("alerts") > -1) {
            this.selectDashboard(0, true);
        } else if (item.toLowerCase().indexOf("appointments") > -1) {
            //var iframe = null;
            //iframe = $('#CalendarMonthView');
            //if (iframe && iframe.contentWindow) {
            //    iframe.contentWindow.location.reload();
            //} 
            $('#CalendarMonthView').attr('src', 'Calendar_MonthView.aspx?calView=Day&from=dash');
        } else if (item.toLowerCase().indexOf("reviews") > -1 || item.toLowerCase().indexOf("proofs") > -1) {
            this.selectDashboard(3, true);
        } else if (item.toLowerCase().indexOf("hours") > -1) {
            this.selectDashboard(6);
        } else if (item.toLowerCase().indexOf("bookmarks") > -1) {
            this.selectDashboard(5);
        }
    }
    expandSearch() {
        this.searchInputExpanded = true;
    }
    collapseSearch() {
        this.searchInputExpanded = false;
    }
    scrollTopAfterPageChange() {
        try {
            if (this.Type == 0) {  //alerts
                $('#alerts-cardgroup').animate({
                    scrollTop: 0
                }, 'slow', 'swing');
            } else if (this.Type == 1) { //assignments
                $('#assignments-cardgroup').animate({
                    scrollTop: 0
                }, 'slow', 'swing');
            }
        } catch (e) {
            console.log("scrollTopAfterPageChange:error", e);
        }
    }
    setPagerDisplay() {
        try {
            if (this.pageSize > 0) {
                if (this.pageNumber < 1) {
                    this.pageNumberDisplay = 1;
                } else if (this.pageNumber > this.maxPage) {
                    this.pageNumberDisplay = this.maxPage;
                } else {
                    this.pageNumberDisplay = this.pageNumber + 1;
                }
                if (this.pageNumberDisplay > this.maxPage) {
                    this.pageNumberDisplay = this.maxPage;
                } else if (this.pageNumberDisplay < 1) {
                    this.pageNumberDisplay = 1;
                }
                this.pagerDisplay = "Page " + kendo.parseInt(this.pageNumberDisplay.toString()) + " of " + kendo.parseInt(this.maxPage.toString());
            } else {
                this.pagerDisplay = "";
            }
        } catch (e) {
        }
    }
    first() {
        try {
            this.pageNumber = 0;
            this.getCards(false, true);
            this.pagerDisplay = "Page 1 of " + kendo.parseInt(this.maxPage.toString());
            this.setPagerDisplay();
        } catch (e) {
        }
    }
    previous() {
        try {
            if (this.pageSize > 0) {
                if (this.pageNumber > 0) {
                    this.pageNumber -= 1;
                } else {
                    this.pageNumber = 0;
                }
            } else {
                this.pageNumber = 0;
            }
            this.getCards(false, true);
            this.setPagerDisplay();
        } catch (e) {
        }
    }
    next() {
        try {
            if (this.pageSize > 0) {
                this.pageNumber += 1;
            } else {
                this.pageNumber = 0;
            }
            this.getCards(false, true);
            this.setPagerDisplay();
        } catch (e) {
        }
    }
    last() {
        try {
            if (this.pageSize > 0) {
                if (this.Type == 0) {  //alerts
                    if (this.alertCount > this.pageSize) {
                        this.maxPage = this.alertCount / this.pageSize
                        this.maxPage = Math.round(this.maxPage);
                        if (this.maxPage > 1) {
                            this.pageNumber = kendo.parseInt(this.maxPage.toString());
                        } else {
                            this.pageNumber = 0;
                        }
                    } else {
                        this.pageNumber = 0;
                    }
                } else if (this.Type == 1) { //assignments
                    if (this.assignmentCount > this.pageSize) {
                        this.maxPage = this.assignmentCount / this.pageSize;
                        this.maxPage = Math.round(this.maxPage);
                        if (this.maxPage > 1) {
                            this.pageNumber = kendo.parseInt(this.maxPage.toString());
                        } else {
                            this.pageNumber = 0;
                        }
                    } else {
                        this.pageNumber = 0;
                    }
                }
            } else {
                this.pageNumber = 0;
            }
            this.getCards(false, true);
            this.setPagerDisplay();
        } catch (e) {
        }
    }
    refreshAssignmentsClick() {
        this.refreshDashboard(1, true);
        if (this.webvantage) {
            this.webvantage.refreshAlertNotifications();
        }
    }
    refreshAlertsClick() {
        this.refreshDashboard(0, true);
        if (this.webvantage) {
            this.webvantage.refreshAlertNotifications();
        }
    }
    refreshTimeClick() {
        this.refreshDashboardTime();
    }
    refreshBookmarksClick() {
        this.refreshDashboard(5);
    }
    refreshReviewsClick() {
        this.Type = 3;
        this.refreshDashboard(3);
    }
    searchdashboard(dashboardType: number) {        
        //console.log("search " + this.search);
        this.refreshDashboard(dashboardType);
    }
    switchDashboard(showProgressIndicator: boolean = false) {
       this.service.switchDashboard(this.Type).then(response => {
            if (response) {
                this.loadDashboard(response.content, false, showProgressIndicator);
            }
        });
    }
    selectDashboard(dashboardType: number, showProgressIndicator: boolean = false) {
        this.Type = dashboardType;
        if (dashboardType == 5) {
            this.getBookmarks();
        } else if (dashboardType == 6) {
            this.getTimesheetDashboard();
        } else {
            this.switchDashboard(showProgressIndicator);
        }
    }
    getCards(init: boolean = false, showProgressIndicator: boolean = false) {
        if (showProgressIndicator == true) {
            this.showProgress(true);
        }
        if (this.Type == 0) {
            this.search = this.searchalert;
        }
        if (this.Type == 1) {
            this.search = this.searchassignment;
        }
        if (this.Type == 3) {
            this.search = this.searchreview;
        }
        try {
            let me = this;
            this.service.loadCards(this.Type, this.GroupBy, this.search, this.pageSize, this.pageNumber).then(response => {
                //console.log("loadCards", response.content, this.Type);
                if (Array.isArray(response.content.cardGroups)) {
                    me.cardGroups = response.content.cardGroups;                    
                    me.alertCount = response.content.alertCount;                        
                    me.assignmentCount = response.content.assignmentCount;
                    me.reviewCount = response.content.reviewCount;                    
                } else {
                    me.cardGroups = [];
                    me.alertCount = 0;
                    me.assignmentCount = 0;
                    me.reviewCount = 0;
                }
                try {
                    if (me.pageSize > 0) {
                        if (me.Type == 0) {  //alerts
                            if (me.alertCount > me.pageSize) {
                                me.maxPage = me.alertCount / me.pageSize;
                                //me.maxPage = Math.round(me.maxPage);
                                me.maxPage = Math.ceil(me.maxPage);
                            } else {
                                me.maxPage = 0;
                            }
                        } else if (me.Type == 1) { //assignments
                            if (me.assignmentCount > me.pageSize) {
                                me.maxPage = me.assignmentCount / me.pageSize;
                                //me.maxPage = Math.round(me.maxPage);
                                me.maxPage = Math.ceil(me.maxPage);
                            } else {
                                me.maxPage = 0;
                            }
                        }
                        me.maxPage = kendo.parseInt(me.maxPage.toString());
                        me.setPagerDisplay();
                    }
                } catch (e) {
                }
                if (showProgressIndicator == true) {
                    me.scrollTopAfterPageChange();
                }
                me.showProgress(false);
                if (init === true) {
                    me.loadCounts();
                    me.getTimesheetDashboard();
                }
                //console.log("this.cardGroups", this.cardGroups);
                this.showProgress(false);
            }).then(() => {
                me.showProgress(false);
            });
        } catch (e) {
            this.showProgress(false);
        }
    }
    getBookmarks() {
        let client = new HttpClient();
        let me = this;
       
        var data = {
            Search: this.searchbookmark
        };
        //console.log("gb " + this.searchbookmark);
        client.get('Utilities/GetBookmarks', data)
            .then(data => {
                //console.log(data.content);
                me.bookmarks = data.content;
            });
    }
    sortChanged(e) {
        this.getCards();
        //console.log(this);
        this.service.saveDashboardDefaultGroupBy(this.Type, this.GroupBy).then(response => {

        });
    }
    loadDashboard(dashboard: any, init: boolean = false, showProgressIndicator: boolean = false) {
        this.GroupBy = dashboard.GroupBy;
        this.Type = dashboard.DashboardType;
        this.Settings = dashboard.Settings;
        this.GroupByOptions.data(dashboard.GroupByOptions);
        this.getCards(init, showProgressIndicator);
    }
    cardSettingsClick(dashboardType: number) {

        let csdm: CardSettingsDlgModel = new CardSettingsDlgModel();
        this.showProgress(true);
        $.when(this.service.getCardSettings(0),
            this.service.getCardSettings(1),
            this.service.getCardSettings(3),
            this.service.getTaskCardSettings(1, 'TaskStatus'),
            this.service.getTaskCardSettings(1, 'StartToday'),
            this.service.getTaskCardSettings(1, 'OnlyTasksWithDates')
        ).done(function (s1, s2, s3, s4, s5, s6) {
            var cardSettings = s1.content;
            csdm.ShowClientNameAlert = cardSettings.ShowClientName;
            csdm.ShowJobNumberAlert = cardSettings.ShowJobNumber;
            csdm.ShowJobComponentNumberAlert = cardSettings.ShowJobComponentNumber;
            csdm.ShowJobDescriptionAlert = cardSettings.ShowJobDescription;
            csdm.ShowJobComponentDescriptionAlert = cardSettings.ShowJobComponentDescription;
            csdm.ShowTaskCommentAlert = cardSettings.ShowTaskComment;
            csdm.ShowStateAlert = cardSettings.ShowState;

            cardSettings = s2.content;
            csdm.ShowClientNameAssignment = cardSettings.ShowClientName;
            csdm.ShowJobNumberAssignment = cardSettings.ShowJobNumber;
            csdm.ShowJobComponentNumberAssignment = cardSettings.ShowJobComponentNumber;
            csdm.ShowJobDescriptionAssignment = cardSettings.ShowJobDescription;
            csdm.ShowJobComponentDescriptionAssignment = cardSettings.ShowJobComponentDescription;
            csdm.ShowTaskCommentAssignment = cardSettings.ShowTaskComment;
            csdm.ShowStateAssignment = cardSettings.ShowState;

            cardSettings = s3.content;
            csdm.ShowClientNameReview = cardSettings.ShowClientName;
            csdm.ShowJobNumberReview = cardSettings.ShowJobNumber;
            csdm.ShowJobComponentNumberReview = cardSettings.ShowJobComponentNumber;
            csdm.ShowJobDescriptionReview = cardSettings.ShowJobDescription;
            csdm.ShowJobComponentDescriptionReview = cardSettings.ShowJobComponentDescription;

            csdm.TaskStatus = s4.content;

            if (s5.content == 'True') {
                csdm.StartDateasofToday = true;
            } else {
                csdm.StartDateasofToday = false;
            }

            if (s6.content == 'True') {
                csdm.TasksOnlyWithStartAndDueDates = true;
            } else {
                csdm.TasksOnlyWithStartAndDueDates = false;
            }
        }).then(() => {
            this.showProgress(false);
            if (this.cardSettingsOpened == false) {
                this.cardSettingsOpened = true;
                let me = this;
                this.dialogService.open({ viewModel: CardSettingsDialog, model: csdm }).whenClosed(response => {
                    if (!response.wasCancelled) {
                        me.propCount = csdm.PropertyCount;
                        for (let prop in response.output) {
                            if (prop.includes('Alert')) {
                                this.saveCardSettings(0, prop, response.output[prop]);
                            }
                            else if (prop.includes('Assignment')) {
                                this.saveCardSettings(1, prop, response.output[prop]);
                            }
                            else if (prop.includes('Review')) {
                                this.saveCardSettings(3, prop, response.output[prop]);
                            }
                            else if (prop == "TaskStatus") {
                                this.saveCardSettings(1, 'TaskStatus', response.output[prop]);
                            }
                            else if (prop == "StartDateasofToday") {
                                this.saveCardSettings(1, 'StartToday', response.output[prop]);
                            }
                            else if (prop == "TasksOnlyWithStartAndDueDates") {
                                this.saveCardSettings(1, 'TasksOnlyWithStartAndDueDates', response.output[prop]);
                            }
                        }
                        //this.refreshDashboard(this.Type);
                    } else {
                        this.cardSettingsOpened = false;
                    }
                });
            } else {

            }
            
        });
    }
    onClose() {
        this.refreshDashboard(this.Type);
    }
    assignmentClick() { 
        this.assignmentDialog.open();
    }
    loadCounts() {        
        let me = this;
        this.loadTimeHours();
    }
    // For refreshing dashboard from other modules; should work with Aurleia, MVC/Razor, and aspx
    refreshCurrentDashboard() {
        //console.log("refreshCurrentDashboard!", this.Type)
        if (this.Type === 6) {
            this.refreshDashboardTime();
        } else {
            this.selectDashboard(this.Type);
        }
    }
    refreshDashboardTime() {
        //console.log("refreshDashBoardTime!", this.Type)
        try {
            this.loadTimeHours();
            if (this.Type === 6) {
                this.getTimesheetDashboard();
            }
        } catch (e) {
            console.log("dashboard.ts:refreshDashboardTime:error", e);
        }
    }
    refreshDashboardAssignments() {
        try {
            this.loadCounts();
            if (this.Type === 1) {
                this.selectDashboard(this.Type); // Not sure this is best?
            }
        } catch (e) {
            console.log("dashboard.ts:refreshDashboardAssignments:error", e);
        }
    }
    refreshDashboardAlerts() {
       //console.log("dashboard.ts:refreshDashboardAlerts:", this.Type);
       try {
            this.loadCounts();
            if (this.Type === 0 || this.Type === 1) {
                this.selectDashboard(this.Type); // Not sure this is best?
            }
       } catch (e) {
            console.log("dashboard.ts:refreshDashboardAlerts:error", e);
       }
    }
    refreshDashboardAppointments() {
        try {
            if (this.Type === 4) {
                this.selectDashboard(this.Type); // Not sure this is best?
            }
        } catch (e) {
            console.log("dashboard.ts:refreshDashboardAppointments:error", e);
        }
    }
    refreshDashboardBookmarks() {
        try {
            if (this.Type === 5) {
                this.getBookmarks();
            }
        } catch (e) {
            console.log("dashboard.ts:refreshDashboardBookmarks:error", e);
        }
    }
    refreshDashboardReviews() {
        try {
            if (this.Type === 3) {
                this.selectDashboard(this.Type); // Not sure this is best?
            }
        } catch (e) {
            console.log("dashboard.ts:refreshDashboardReviews:error", e);
        }
    }
    //  SignalR 
    refreshAlerts() {
        //console.log("dashboard.ts:refreshAlerts:", this.Type);
        try {
            this.loadCounts();
            if (this.Type === 0 || this.Type === 1) {
                this.selectDashboard(this.Type); // Not sure this is best?
            }
        } catch (e) {
            console.log("dashboard.ts:refreshAlerts:error", e);
        }
    }
    loadTimeHours() {
        try {
            let me = this;
            this.service.getHoursCount().then(response => {
                if (response) {
                    try { me.hoursToday = response.content.HoursToday * 1; } catch (e) { }
                    try { me.hoursThisWeek = response.content.HoursThisWeek * 1; } catch (e) { }
                    try { me.hasDeniedTime = response.content.HasDeniedTime; } catch (e) { }
                    try { me.hasMissingTime = response.content.HasMissingTime; } catch (e) { }
                    try { me.timeMessage = response.content.TimeMessage; } catch (e) { }    
                    if (!me.timeMessage || me.timeMessage == "") { me.timeMessage = "You have missing and/or denied time."; }
                    if (me.hasMissingTime == true || me.hasDeniedTime == true) { me.showTimeWarning = true; } else { me.showTimeWarning = false; }
                }
            });
        } catch (e) {
            console.log("dashboard.ts:loadTimeHours:error", e);
        }
    }
    getTimeSummaries() {
        let me = this;
        this.dateData = [];
        this.hoursData = [];
        this.goalsData = [];
        this.timesheetService.getTimeSummary().then(response => {
            if (response) {
                me.timeSummaries = response.content;
                if (me.timeSummaries) {
                    window.setTimeout(function () {
                        var items = me.timeSummaries;
                        for (var i = 0; i < items.length; i++) {
                            me.dateData.push(items[i].ShortDate);
                            me.hoursData.push(items[i].Hours);
                            me.goalsData.push(items[i].HoursGoal);
                        }
                        /*  Chart   */
                        $("#hoursChart").kendoChart({
                            theme: "bootstrap",
                            seriesDefaults: { type: "bar"},
                            series: [{
                                name: "Hours",
                                data: me.hoursData
                                }, {
                                name: "Goal",
                                data: me.goalsData
                                }],
                            valueAxis: [{
                                max: 12,
                                line: { visible: true },
                                minorGridLines: { visible: true }
                            }],
                            categoryAxis: [{
                                categories: me.dateData,
                                majorGridLines: { visible: true}
                            }], 
                            tooltip: { visible: true, template: "#= series.name #: #= value #" },
                            zoomable: {
                                mousewheel: { lock: "y" }, selection: { lock: "y" }
                            },
                            pannable: { lock: "y"}
                        });
                        /*  End chart   */
                    }, 0);
               }
             }
        });
    }
    getMonthlyHours() {
        let me = this;
        this.timesheetService.getMonthlyHours().then(response => {
            if (response) {
                me.monthlyGoal = response.content.Goal;
                me.monthlyHours = response.content.Hours;
                window.setTimeout(function () {
                }, 0);
            }
        });
    }
    getTimesheetDashboard() {
        let me = this;
        this.timesheetService.getTimesheetDashboard().then(response => {
            if (response) {
                me.timesheetDashboard = response.content;
                if (me.timesheetDashboard) {
                    //console.log("timesheetDashboard", me.timesheetDashboard.DirectHoursToGoalThisWeekPercent.toFixed(2));
                    window.setTimeout(function () {
                        //  Dash display
                        me.hoursTodayString = me.timesheetDashboard.HoursToday.toFixed(2);
                        me.hoursThisWeekString = me.timesheetDashboard.HoursThisWeek.toFixed(2);
                        //console.log("timesheetDashboard", me.timesheetDashboard);
                        //  Required vs Posted Today
                        $("#RequiredPostedTodayChart").kendoChart({
                            theme: "bootstrap",
                            title: { visible: false },
                            legend: { visible: false },
                            chartArea: { background: "", width: 200, height:200 },
                            seriesDefaults: { type: "donut" },
                            series: [{
                                name: "Hours Today",
                                data: [{
                                    category: "Posted",
                                    value: me.timesheetDashboard.HoursToday,
                                    color: me.timesheetDashboard.DarkColor
                                }, {
                                    category: "Missing",
                                    value: me.timesheetDashboard.RequiredHoursToday,
                                    color: me.timesheetDashboard.Color
                                }],
                                startAngle: 150,
                                holeSize: 50
                            }],
                            tooltip: { visible: true, template: "#= category #: #= value #" }
                        });
                        //  Required vs Posted Week
                        $("#RequiredPostedWeekChart").kendoChart({
                            theme: "bootstrap",
                            title: { visible: false },
                            legend: { visible: false },
                            chartArea: { background: "", width: 200, height: 200 },
                            seriesDefaults: { type: "donut" },
                            series: [{
                                name: "Hours Today",
                                data: [{
                                    category: "Posted",
                                    value: me.timesheetDashboard.HoursThisWeek,
                                    color: me.timesheetDashboard.DarkColor
                                }, {
                                    category: "Missing",
                                    value: me.timesheetDashboard.RequiredHoursWeek,
                                    color: me.timesheetDashboard.Color
                                }],
                                startAngle: 150,
                                holeSize: 50
                            }],
                            tooltip: { visible: true, template: "#= category #: #= value #" }
                        });
                        //  Direct Hours To Goal
                        $("#directHoursToGoalChart").kendoChart({
                            theme: "bootstrap",
                            title: { visible: false },
                            legend: { visible: false },
                            chartArea: { background: "", width: 200, height: 200 },
                            seriesDefaults: { type: "donut" },
                            series: [{
                                name: "Hours to Goal",
                                data: [{
                                    category: "Posted",
                                    value: me.timesheetDashboard.HoursThisWeek,
                                    color: me.timesheetDashboard.DarkColor
                                }, {
                                    category: "Until Goal",
                                    value: me.timesheetDashboard.DirectHoursToGoalThisWeek,
                                    color: me.timesheetDashboard.Color
                                    }],
                                startAngle: 150,
                                holeSize: 50
                            }],
                            tooltip: { visible: true, template: "#= category #: #= value #" }
                        });
                        //  Hours by Type
                        $("#hoursByTypeChart").kendoChart({
                            theme: "bootstrap",
                            title: { visible: true },
                            legend: { visible: false },
                            chartArea: { background: "", width: 200, height: 200 },
                            seriesDefaults: { type: "donut" },
                            series: [{
                                name: "Hours by Type",
                                data: [{
                                        category: "Agency",
                                        value: me.timesheetDashboard.AgencyHoursThisWeek,
                                        color: "#616161"                                        
                                    }, {
                                        category: "New Business",
                                        value: me.timesheetDashboard.NewBusinessHoursThisWeek,
                                        color: "#FFA000"
                                    }, {
                                        category: "Client",
                                        value: me.timesheetDashboard.ClientHoursThisWeek,
                                        color: me.timesheetDashboard.DarkColor
                                    }, {
                                        category: "Indirect",
                                        value: me.timesheetDashboard.IndirectHoursThisWeek,                         
                                        color: "#C62828"
                                    }, {
                                        category: "Required",
                                        value: me.timesheetDashboard.RequiredHoursThisWeekByType,
                                        color: me.timesheetDashboard.Color
                                    }],
                                startAngle: 150,
                                holeSize: 50
                            }],
                            tooltip: { visible: true, template: "#= category #: #= value #" }
                        });
                    }, 50);
                }
            }
        });
    }
    openTodayTimesheet() {
        let me = this;
        var today = new Date();
        me.hoursTodayUrl = "Employee/Timesheet?emp=&dtd=1&nav=4&isdd=1&sd=" + kendo.toString(today, "d");
        //me.hoursTodayUrl = "Employee/Timesheet";
        this.openModule("Timesheet", me.hoursTodayUrl, 0, 0);
    }
    openMissingTime() {
        let me = this;
        this.openDialog("Find Time", "Timesheet_Search.aspx?type=missing");    
    }
    checkSize() {
        try {
            var winHeight = $(window).innerHeight();
            if (winHeight) {
                var cardContainer = $("div.card-container-height");
                var containerHeight = winHeight - 310;
                if (cardContainer) {
                    $(cardContainer).height(containerHeight);
                }
            }
        } catch (e) {
        }
    }
    refreshDashboard(dashboardType: number, showProgressIndicator: boolean = false) {
        //this.service.initDashboard().then(response => {
        //    this.loadDashboard(response.content);
        //});
        if (dashboardType == 5) {
            this.selectDashboard(dashboardType, false);
            //console.log("bookmark");
        } else if (dashboardType == 3) {
            this.selectDashboard(dashboardType, false);
            this.loadCounts();
        } else if (dashboardType == 6) {

        } else {
            this.selectDashboard(dashboardType, showProgressIndicator);
            this.loadCounts();
            //console.log("refresh");
        }
        this.cardSettingsOpened = false;
    }
    refreshAssignment(me) {
        try {
            me.loadCounts();
        } catch (e) {
        }
        try {
            me.selectDashboard(1);
        } catch (e) {
        }
    }
    refreshAlert(me) {
        try {
            me.loadCounts();
        } catch (e) {
        }
        try {
            me.selectDashboard(0);
        } catch (e) {
        }
    }
    refreshAppointments(me) {
        try {
            me.loadCounts();
        } catch (e) {
        }
        try {
            //me.selectDashboard(1);
            var iframe = null;
            iframe = $('#CalendarMonthView');
            if (iframe && iframe.contentWindow) {
                iframe.contentWindow.location.reload();
            } 
        } catch (e) {
            console.log("dashboard.ts:refreshAppointments:error", e);
        }
    }
    newAssignment() {
        let me = this;
        this.openDialog("Assignment", "Desktop_NewAssignment", null, 1145, me.refreshAssignment,me);
    }
    newAlert() {
        let me = this;
        this.openDialog("Alert", "Alert_New.aspx?f=0", null, 1145,me.refreshAlert,me);
    }
    newAppointment() {
        let me = this;
        this.openDialog("Appointment", "Calendar_NewActivity.aspx", 400, 800, me.refreshAppointments,me);        
    }
    newTimeEntry() {
        let me = this;
        var today = new Date();
        var newTimeEntryURL = "Employee/Timesheet/Entry?emp=&new=1&sd=" + kendo.toString(today, "d");
        this.openDialog("Add Time", newTimeEntryURL, 570, 680, me.refreshAppointments, me);        
    }
    newReview() {
        let me = this;
        this.openDialog("New Review", "Desktop_NewAssignment?caller=review", null, 1145, me.refreshAssignment, me);
    }
    findTime() {
        let me = this;
        
        this.openDialog("Find Time", "Timesheet_Search.aspx");        
    }
    openbookmark(bookmark) {
        //console.log("ob " + bookmark.PageURL);
        if (bookmark.PageURL.includes('.aspx')) {
            this.openModule(bookmark.Name, bookmark.PageURL, 0, 0);
            //this.webvantage.OpenRadWindow(bookmark.Name, bookmark.PageURL, 0, 0);
        }
        else {
            var s;
            if (bookmark.PageURL.startsWith("modules/")) {
                s = bookmark.PageURL;//.substring(0, bookmark.PageURL.indexOf('?'));
            } else {
                s = bookmark.PageURL;//.substring(0, bookmark.PageURL.indexOf('?'));
            }
            // console.log("ob " + s);
            this.openModule(bookmark.Name, s);

        }

    }
    deletebookmark(bookmark) {
        let client = new HttpClient();
        //console.log("db " + bookmark.Id);

        var data = {
            BookMarkID: bookmark.Id
        }

        client.post("Utilities/DeleteBookmark", data).then(data => {
            this.refreshDashboard(5);
        });

        this.refreshDashboard(5);

    }
    updatebookmark(bookmark, open) {
        let client = new HttpClient();
        
        var count = 0;
        if (open == 0) {

            var data2 = {
                BookMarkID: bookmark.Id,
                OpenByDefault: open
            }

            client.post("Utilities/UpdateBookmarkOpenByDefaultmark", data2).then(data => {
                this.refreshDashboard(5);
            });

        } else {
            client.get('Utilities/CheckOpenByDefaultCount')
                .then(data => {
                    count = data.content;
                    if (count >= 5) {
                        alert("Only five bookmarks can be set to open by default.");
                    } else {
                        var data2 = {
                            BookMarkID: bookmark.Id,
                            OpenByDefault: open
                        }

                        client.post("Utilities/UpdateBookmarkOpenByDefaultmark", data2).then(data => {
                            this.refreshDashboard(5);
                        });
                    }
                });
        }
           
        
    }
    checkopenbydefaultcount() {
        let client = new HttpClient();
        var count = 0;
        try {
            client.get('Utilities/CheckOpenByDefaultCount')
                .then(data => {
                    //console.log(data.content);
                    count = data.content;
                });
        } catch (e) {

        }
    }
    editbookmark(bookmark) {
        //console.log("db " + bookmark.Id);
        this.dialogService.open({ viewModel: BookmarkEditDialog, model: { bookmarkID: bookmark.Id } }).whenClosed(response => {
            if (!response.wasCancelled) {
                this.refreshDashboard(5);
            }
        });
    }
    activate() {
        let me = this;
        this.service.showProofingIcon().then(response => {
            if (response && response.content) {
                console.log("content", response.content);
                me.isClientPortal = response.content.ClientPortalActive;
                me.isProofingActive = response.content.ProofingActive;
                me.isConceptShareActive = response.content.ConceptShareActive;
                me.showProofsIcon = response.content.ShowIcon;
                me.isTimesheetActive = response.content.TimesheetActive;
                window.setTimeout(function () {
                    if (me.isProofingActive == false && me.isConceptShareActive == true) {
                        me.reviewItemText = "Reviews";
                        me.reviewItemTextSingular = "Review";
                    }
                    me.init();
                }, 250);
            }
        });
    }
    attached() {
        let me = this;
        $(document).ready(function () {
            me.checkSize();
        });
        $(window).on("resize", function () {
            me.checkSize();
        });
        console.log("attached")
    }
    init() {
        let me = this;
        me.service.initDashboard().then(response => {
            me.loadDashboard(response.content, true, true);
        });
        this.webvantage.currentDashboard = this;
    }
    loadCardSettings(dashboardType: number) {

        try {
            this.service.getCardSettings(dashboardType).then(response => {                
                    this.cardSettings = response.content;   
            }).then(() => {
                
            });
        } catch (e) {
           
        }

    }
    propCount: number = 0;
    propsSaved: number = 0;
    saveCardSettings(dashboardType: number, setting: string, value) {
        let me = this;
        if (setting == 'TaskStatus') {
            this.service.saveCardSettings(dashboardType, setting, value).then(response => {
                if (response.content.Success === true) {      
                } else if (response.content.Message) {
                }
                me.propsSaved += 1;
                if (me.propsSaved == me.propCount) {
                    me.completeSettingsSave();
                }
            });
            //var item = this.taskstatusDropDownList.dataItem(this.taskstatusDropDownList.select());
            //this.service.saveCardSettings(dashboardType, setting, item.value).then(response => {
            //    if (response.content.Success === true) {

            //    } else if (response.content.Message) { 

            //    }
            //});
        } else if (setting == 'StartDateasofToday') {
            //var item2 = this.tasksDropDownList.dataItem(this.tasksDropDownList.select());
            this.service.saveCardSettings(dashboardType, setting, value).then(response => {
                if (response.content.Success === true) {
                } else if (response.content.Message) {
                }
                me.propsSaved += 1;
                if (me.propsSaved == me.propCount) {
                    me.completeSettingsSave();
                }
           });
        } else {
            this.service.saveCardSettings(dashboardType, setting, value).then(response => {
                if (response.content.Success === true) {
                } else if (response.content.Message) {
                }
                me.propsSaved += 1;
                if (me.propsSaved == me.propCount) {
                    me.completeSettingsSave();
                }
            });
        }
        if (me.propsSaved == me.propCount) {
            me.completeSettingsSave();
        }
    }
    completeSettingsSave() {
        let me = this;
        me.getCards(false, true);
        me.propCount = 0;
        me.propsSaved = 0;
        me.cardSettingsOpened = false;
    }
    changeAssignmentOrder(e) {
        let client = new HttpClient();
        let me = this;
        //console.log(e.newIndex);
        //console.log(e);
        //console.log(e.item[0].au["wv-card"].viewModel.alertid);
        //console.log(e.item[0].au["wv-card"].viewModel.jobnumber);
        //console.log(e.item[0].au["wv-card"].viewModel.jobcomponentnumber);
        //console.log(e.item[0].au["wv-card"].viewModel.tasksequencenumber);
        //console.log(e.item[0].au["wv-card"].viewModel.alertcategorydescription);
        var category = e.item[0].au["wv-card"].viewModel.alertcategorydescription; 
        var alertid: number = e.item[0].au["wv-card"].viewModel.alertid
        //var jobNumber: number =  e.item[0].au["wv-card"].viewModel.jobnumber;
        //var jobComponentNumber: number = e.item[0].au["wv-card"].viewModel.jobcomponentnumber;
        var taskSequenceNumber: number = e.item[0].au["wv-card"].viewModel.tasksequencenumber;
        if (category == 'Task') {
            var taskData = {
                AlertId: alertid,
                TaskSequenceNumber: taskSequenceNumber,
                NewPosition: e.newIndex
            };
            console.log("changeTaskOrder " + taskData);
            client.post('Dashboard/UpdateTaskCardsOrder', taskData)
                .then(data => {
                    if (data && data.response && data.response != "") {
                        console.log("changeTaskOrder data?", data);
                    }
                });
        } else {
            var assignmentData = {
                AlertId: alertid,
                NewPosition: e.newIndex
            };
            console.log("changeAssignmentOrder " + assignmentData);
            client.post("Dashboard/UpdateAssignmentCardsOrder", assignmentData)
                .then(data => {
                    if (data && data.response && data.response != "") {
                        console.log("changeAssignmentOrder data?", data);
                    }
                });
        }
    }
    changeAlertOrder(e) {
        let client = new HttpClient();
        let me = this;
        //console.log(e.newIndex);
        //console.log(e.item[0].au["wv-card"].viewModel.alertid);        
        var alertid: number = e.item[0].au["wv-card"].viewModel.alertid;
        var alertData = {
            AlertId: alertid,
            NewPosition: e.newIndex
        };
        console.log("changeAlertOrder " + alertData);
        client.post("Dashboard/UpdateAlertCardsOrder", alertData)
        .then(data => {
            if (data && data.response && data.response != "") {
                console.log("changeAlertOrder data?", data);
            }
        });
    }
    changeProofOrder(e) {
        let client = new HttpClient();
        let me = this;
        //console.log(e.newIndex);
        //console.log(e.item[0].au["wv-card"].viewModel.alertid);        
        var alertid: number = e.item[0].au["wv-card"].viewModel.alertid;
        var proofingData = {
            AlertId: alertid,
            NewPosition: e.newIndex
        };
        console.log("UpdateProofingCardsOrder " + proofingData);
        client.post("Dashboard/UpdateProofingCardsOrder", proofingData)
            .then(data => {
                if (data && data.response && data.response != "") {
                    console.log("changeProofOrder data?", data);
                }
        });
    }
    searchOnEnter(event, dashId: number) {
        if (event.which == 13) {
            event.preventDefault();
            this.searchdashboard(dashId);
            return false;
        } else {
            return true;
        }
    }
    constructor(service: DashboardService, timesheetService: TimesheetService, openModule, dialogService: DialogService, openDialog, webvantage: Webvantage) {

        super();

        //for (var i = 0; i < 7; i++) {
        //    this.weekday.push(kendo.toString(new Date(2018, 10, 11 + i), "dddd")); 
        //}
        //console.log("weekday", this.weekday);
        this.weekday.push("Sunday");
        this.weekday.push("Monday");
        this.weekday.push("Tuesday");
        this.weekday.push("Wednesday");
        this.weekday.push("Thursday");
        this.weekday.push("Friday");
        this.weekday.push("Saturday");

        this.service = service;
        this.webvantage = webvantage;
        this.dialogService = dialogService;
        this.timesheetService = timesheetService;
        this.dashDate = new Date().toLocaleDateString();
        this.dashDay = this.weekday[new Date().getDay()];
        this.timesheetDashboard = new TimesheetDashboard;
        this.openModule = openModule;
        this.openDialog = openDialog;

        this.CanAdd('Dashboard/CanAddJobJacket');
        this.IsBlocked('Dashboard/HasAccessJobJacket');
        //console.log("canAdd " + this.canAdd);

        this.cardSettings = new CardSettingsModel;
        $('[data-toggle="tooltip"]').ejTooltip();
    }
    frameloaded(e) {
        let frame: HTMLIFrameElement = e.target;
        let me = this;

        if (frame) {
            frame.ownerDocument['GetRadWindow'] = function () {

                let BrowserWindow = new browserWindow();

                BrowserWindow.Parent = me;
                BrowserWindow.Frame = frame;
                BrowserWindow.webvantage = me.webvantage;


                return {
                    BrowserWindow: BrowserWindow
                };
            }
        }
    }
}
