import { Drawer } from './resources/elements/drawer/drawer';
import { observable, inject, Container, NewInstance, bindable } from 'aurelia-framework';
import { ApplicationService } from 'services/application-service';
import { Application } from 'models/common/application';
import { DialogService } from 'aurelia-dialog';
import { LookupDialog } from 'modules/utilities/lookup-dialog'
import { HttpClient, RequestBuilder } from 'aurelia-http-client';
import { MiscService } from 'services/utilities/misc-service';
import { browserWindow } from 'services/utilities/browserWindow'
import { NewCampaignDlg } from 'modules/project-management/campaigns/new-campaign-dlg'
import { IframeDialog } from 'modules/utilities/iframe-dialog'
import { AlertService } from 'services/desktop/alert-service';
import { SessionTimeout } from 'services/utilities/session-timeout'
import { ModuleBase } from 'modules/base/module-base';
import { NewWorkItemTimeDialog } from 'modules/project-management/agile/new-work-item-time-dialog';
import { EventAggregator } from 'aurelia-event-aggregator';
import { AddWorkItemDialog } from 'modules/desktop/alert-view/add-work-item-dialog'
import { UserSettingService } from 'services/utilities/user-settings-service';
import { SettingsEmployee } from 'models/utilities/settings-employee';
import { ExpenseReportsService } from 'services/employee/expense-reports-service';
import { Duplex } from 'stream';

@inject(ApplicationService, DialogService, Container, NewInstance.of(browserWindow), AlertService, SessionTimeout, EventAggregator, UserSettingService)
export class Webvantage extends ModuleBase {

    @observable OpenSecurityModules: Array<Application.ApplicationMenuItem>;

    service: ApplicationService;
    eventAggregator: EventAggregator;
    dialogService: DialogService;
    BrowserWindow: browserWindow;
    alertService: AlertService;
    sessionTimeout: SessionTimeout;
    serviceUser: UserSettingService;
    settings: SettingsEmployee.SettingEmployee;

    mainMenuItems: Array<Application.MenuItem>;
    quickAccessMenuItems: Array<Application.MenuItem>;
    productivityMenuItems: Array<Application.MenuItem>;
    searchMenuItems: Array<Application.MenuItem>;
    employee: Application.EmployeeInfo;
    bookmarksDialog: kendo.ui.Dialog;
    alertsDialog: kendo.ui.Dialog;
    stopwatchbutton: kendo.ui.Button;
    openwatchbutton: kendo.ui.Button;
    isClientPortal: boolean = false;
    DatabaseName: string = '';

    leftDrawer: Drawer;
    selectedSideMenu: string = '';
    bookmarks: Array<any>;
    frame: HTMLIFrameElement;
    UiActionWindow: HTMLIFrameElement = null;
    stopwatch: boolean = false;
    showdb: boolean = false;
    jcmissingrequiredfield: boolean = false;

    notification: kendo.ui.Notification;
    alertNotifications: Array<any>;
    notificationCount: number = 0;
    notificationsVisible: boolean = false;
    notificationClicked: boolean = false;
    isGettingNotification: boolean = false;
    currentDashboard: any;
    currentPage: any;
    dashBoardLoaded: boolean = false;
    @bindable stopwatchRunningTime: string = "Running time";
    assignmentTabs: Array<any> = new Array<any>();
    refreshInboxFlag: boolean = false;       

    extendSession() {
        this.sessionTimeout.extendTimeout();
    }

    RefreshWindow(WindowURL, ForceNewURL, OpenWindowIfNotFound) {        
        
        var secModule = new Application.ApplicationMenuItem;
        var index: number = -1;
        var frame: HTMLIFrameElement;
        secModule.Url = WindowURL;
        secModule.Parameters = this.parseURLParams(WindowURL.substring(WindowURL.indexOf('?') + 1));
        secModule.Page = this.getPage(secModule.Url);        

        //Refresh the AAM if open and the Alert/Assignment has been saved.
        if (secModule.Page == "Content.aspx") {            
            for (let i = 0; i < this.OpenSecurityModules.length; i++) {
                if (this.OpenSecurityModules[i].Page == "Inbox") {
                    //refresh the Inbox if there were changes to the detail (Desktop_AlertView)
                    this.refreshInboxFlag = true;                    
                }
            }
        }
        
        index = this.findModule(secModule);
        
        if (index == -1 && secModule.Url.indexOf("Alert_View.aspx") > -1) {
            for (var i = 0; i < this.OpenSecurityModules.length; i++) {
                if (WindowURL.indexOf(this.OpenSecurityModules[i].Url) > -1) {
                    index = i;
                }
            }
        }
        if (index > -1) {
            //console.log("found")
            frame = this.OpenSecurityModules[index].Frame;
            if (frame) {
                var contentWindow = null;
                contentWindow = frame.contentWindow;
                if (contentWindow) {
                    contentWindow.RefreshPage();
                    //console.log("contentWindow.RefreshPage()");
                } else {
                    //console.log("RefreshWindow:No content window");
                }
            } else {
                if (secModule.Page = "expense-search-two") {
                    this.refreshExpenseReports();
                }
                
                //console.log("RefreshWindow:No frame");
            }
        }
        else {
            //console.log('page not found');
            if (OpenWindowIfNotFound) {
                this.OpenRadWindow('', WindowURL, 0, 0);
            }
        }
    }

    frameloaded(app: Application.ApplicationMenuItem, e) {
        let frame: HTMLIFrameElement = e.target;
        let me = this;

        me.frame = frame;
        app.Frame = frame;

        if (frame) {
            $(frame).data("myAMI", app);

            app.DocumentTitle = frame.contentDocument.title ? frame.contentDocument.title : '';

            me.frame.ownerDocument['GetRadWindow'] = function () {

                me.BrowserWindow = new browserWindow();

                me.BrowserWindow.Parent = me;
                me.BrowserWindow.Frame = me.frame;
                me.BrowserWindow.webvantage = me;


                return {
                    BrowserWindow: me.BrowserWindow
                };
            }
        }

        var foo = me.OpenSecurityModules.indexOf(app);
        me.OpenSecurityModules[foo].Frame = frame;
    }

    openLeftDrawer() {
        this.sessionTimeout.extendTimeout();
        this.leftDrawer.open();
    }
    closeMenus() {
        //$(".wv-tree-nav li").removeClass("wv-nav-expanded");

        this.mainMenuItems.forEach(function (value: Application.ApplicationMenuItem, index: number, array: Application.MenuItem[]) {
            if (array[index] instanceof Application.CategoryMenuItem) {
                //array[index].Expanded = false;

                let catMenu = <Application.CategoryMenuItem>array[index];

                catMenu.MenuItems.forEach(function (value: Application.ApplicationMenuItem, index: number, array: Application.MenuItem[]) {
                    if (array[index] instanceof Application.CategoryMenuItem) {
                        //array[index].Expanded = false;
                    }
                });
            }
        });

    }
    closeLeftDrawer() {
        try {
            if (this.sessionTimeout) {
                this.sessionTimeout.extendTimeout();
            }
        } catch (e) {
        }
        try {
            if (this.leftDrawer) {
                this.leftDrawer.close();
            }
        } catch (e) {
        }
        this.closeMenus();
    }

    CloseAlertView(AlertID: number) {
        var obj = this.OpenSecurityModules.find(o => {
            return o.Page.includes('Desktop_AlertView') && o.Parameters['AlertID'] == AlertID;
        });

        this.closeModule(obj);
    }

    menuItemClick(menuItem: Application.MenuItem) {
        this.sessionTimeout.extendTimeout();
        if (menuItem instanceof Application.CategoryMenuItem) {
            menuItem.Expanded = !menuItem.Expanded;
        } else {
            this.leftDrawer.close();
            if (menuItem instanceof Application.ApplicationMenuItem) {
                let appMenuItem = <Application.ApplicationMenuItem>menuItem;
                appMenuItem.Url = this.remapPage(appMenuItem.Url);
                appMenuItem.Page = this.getPage(appMenuItem.Url);
                var index = -1;
                //handle special cases from the menu
                if (appMenuItem.Url == 'Help') {
                    this.helpClick();
                    return;
                }
                if (appMenuItem.Url.includes('SIGNOUT')) {
                    this.signOut();
                    return;
                }
                index = this.findModule(appMenuItem)
                if (index > -1 && !this.IsDialog(appMenuItem.Url)) {
                    this.selectModule(this.OpenSecurityModules[index]);
                }
                else {
                    this.openApplication(appMenuItem);
                    //menuItem.Expanded = false;
                    this.closeMenus();
                }
            }

        }
    }

    helpClick() {
        var width = screen.width - 200;
        var height = screen.height - 200;
        var left = (screen.width - width) / 2;
        var top = (screen.height - height) / 2;
        var params = 'width=' + width + ', height=' + height;
        params += ', top=' + top + ', left=' + left;
        params += ', directories=no';
        params += ', location=no';
        params += ', menubar=no';
        params += ', resizable=no';
        params += ', scrollbars=auto';
        params += ', status=no';
        params += ', toolbar=no';
        let newwin = window.open('webhelp/webvantage.htm', 'HelpWindow', params);

        setTimeout(function () {
            newwin.focus();
        }, 1);

    }
    getPage(url) {
        var index;
        var endIndex;
        index = url.lastIndexOf('/') + 1;
        if (index < 0) { index = 0 }
        endIndex = url.indexOf('?');
        if (endIndex < index) { endIndex = url.length }
        return url.substring(index, endIndex);
    }

    CallUiAction(actionId, val, extraQS) {
        let me = this;

        //SetObjects();
        //build parameters
        var qs = "";
        if (val && val != "") {
            qs = qs + "&val=" + val;
        }
        if (extraQS && extraQS != "") {
            qs = qs + "&" + extraQS;
        }

        //build url
        var url = "";
        url = 'UI_Action.aspx?action=' + actionId + qs;

        //SetObjects();
        //look for open window
        if (this.UiActionWindow === null) {
            //open window
            me.UiActionWindow = document.createElement('iframe');
            me.UiActionWindow.src = 'UI_Action.aspx?action=0';
            me.UiActionWindow.hidden = true;
            document.body.appendChild(me.UiActionWindow);
        }

        //call 
        if (me.UiActionWindow) {
            me.UiActionWindow.src = url;
            me.UiActionWindow.hidden = true;
        }
    }
    GetActive() { 
        
        if (this.OpenSecurityModules) {
            for (var i = 0; i < this.OpenSecurityModules.length; i++) {
                if (this.OpenSecurityModules[i] && this.OpenSecurityModules[i].Active == true) {                    
                    return this.OpenSecurityModules[i];
                }
            }
        }
    }

    OpenIFrameDialog(title: string, url: string, height: number, width: number, dialogCallback?, param?) {
        let DialogCallback = dialogCallback;
        var Model = {
            title: title,
            url: url,
            height: height > 0 ? height : 600,
            width: width > 0 ? width : 950,
            webvantage: this
        }
        this.dialogService.open({ viewModel: IframeDialog, model: Model, lock: false }).whenClosed(response => {
            if (DialogCallback != null && DialogCallback !== null && typeof DialogCallback !== 'undefined') {
                if (param != null && param !== null && typeof param !== 'undefined') {
                    DialogCallback(param);
                } else {
                    DialogCallback();
                }
            }
            if (url.includes('Timesheet_Stopwatch.aspx')) {
                window.setTimeout(function () {
                    this.checkForStopwatch();
                }, 50);
            } else {
                //this.refreshDashboardAssignments();
                //this.refreshAlertNotifications();
            }
            if (!response.wasCancelled) {

            } else {

            }
        });

    }
    OpenDialog(title: string, url: string, height: number, width: number, dialogCallback?, param?) {
        let me = this;

        if (url.includes('Campaign_New.aspx')) {
            //"Campaign.aspx?Mode=open&cid=" + CampaignID + "&cmp=" + CampaignCode;
            this.dialogService.open({ viewModel: NewCampaignDlg, lock: false }).whenClosed(response => {
                if (!response.wasCancelled) {
                    me.openModule("Campaign", "Campaign.aspx?Mode=open&cid=" + response.output.CampaignId + "&cmp=" + response.output.CampaignCode);
                }
            });
        }
        else if (url.includes('Desktop_NewAssignment') || url.includes('Desktop_AddWorkItem')) {
            if (url.includes('Desktop_NewAssignment')) {
                var model = {
                    "BoardID": null,
                    "BoardHeaderID": null,
                    "BoardStateID": null,
                    "JobNumber": null,
                    "JobComponentNumber": null,
                    "ClientCode": null,
                    "ContentPage": null,
                    "caller": null,
                    "SprintID": null,
                    "Report": null,
                    "DivisionCode": null,
                    "ProductCode": null,
                    "PageType" : null
                }

                if (url.indexOf('?') > 0) {
                    var Parameters = this.parseURLParams(url.substring(url.indexOf('?') + 1));

                    model.caller = Parameters['caller'];
                    model.JobNumber = Parameters['j'];
                    model.JobComponentNumber = Parameters['jc'];
                    model.Report = Parameters['Report'];
                    model.ClientCode = Parameters['c'];
                    model.DivisionCode = Parameters['d'];
                    model.ProductCode = Parameters['p'];
                    model.PageType = Parameters['pagetype'];
                }
                let callback = dialogCallback;
                this.dialogService.open({ viewModel: AddWorkItemDialog, model: model, lock: false }).whenClosed(response => {                    
                    if (callback != null && callback !== null && typeof callback !== 'undefined') {
                        callback();
                    }
                    if (!response.wasCancelled) {                        
                    }
                });
            }
            else {
                let client = new HttpClient();
                let me = this;
                let callback = dialogCallback;

                client.get('Desktop/Alert/GetSprintInfo' + url.substring(url.indexOf('?'))).then(data => {
                    me.dialogService.open({ viewModel: AddWorkItemDialog, model: data.content, lock: false }).whenClosed(response => {
                        if (callback != null && callback !== null && typeof callback !== 'undefined') {
                            callback();
                        }
                        if (!response.wasCancelled) {
                        }
                    });

                });
            }
        }
        else {
            this.OpenIFrameDialog(title, url, height, width, dialogCallback, param);
        }
    }
    ShowProgress(toggle: boolean): void {
        
        this.showProgress(toggle);

    }
    OpenRadWindow(title, url, height, width, dialogCallback?, param?) {
        let me = this;
        let index: number = -1;
        let endIndex: number = -1;
        let secModule = new Application.ApplicationMenuItem;
        let params: any;
        
        this.sessionTimeout.extendTimeout();

        if (this.IsDialog(url)) {

            this.OpenDialog(title, url, height, width, dialogCallback, param);

        }
        else {

            if (url.includes('Reporting_DynamicReportEdit.aspx')) {

                this.showProgress(true);

            }

            if (!this.OpenSecurityModules) {
                this.OpenSecurityModules = [];
            }

            secModule.Text = title;
            secModule.Url = url;
            secModule.Parameters = this.parseURLParams(url.substring(url.indexOf('?') + 1));
            secModule.Url = this.remapPage(secModule.Url);
            secModule.Page = this.getPage(secModule.Url);

            if (secModule.Url.startsWith('module') && secModule.Url.includes('?')) {
                secModule.Url = secModule.Url.substr(0, secModule.Url.indexOf('?'));
            }

            index = this.findModule(secModule);

            if (index > -1) {
                try {
                    if (this.OpenSecurityModules[index].Url.includes("Employee/Timesheet") == true && this.OpenSecurityModules[index].Url != secModule.Url) {
                        this.OpenSecurityModules[index].Url = secModule.Url;
                    }
                    if (this.OpenSecurityModules[index].Url.includes("NewExpenseReport") == true && this.OpenSecurityModules[index].Url != secModule.Url) {
                        this.OpenSecurityModules[index].Url = secModule.Url;
                    }
                } catch (e) {
                }
                this.selectModule(this.OpenSecurityModules[index]);
            }
            else {
                this.OpenSecurityModules.push(secModule);
                this.selectModule(secModule);
            }
        }
    }

    OpenRadWindowUpdate(title, url, newurl) {
        let me = this;
        let index: number = -1;
        let endIndex: number = -1;
        let secModule = new Application.ApplicationMenuItem;
        let params: any;

        this.sessionTimeout.extendTimeout();      
        
         if (!this.OpenSecurityModules) {
             this.OpenSecurityModules = [];
         }

         secModule.Text = title;
         secModule.Url = url;
         secModule.Parameters = this.parseURLParams(url.substring(url.indexOf('?') + 1));
         secModule.Url = this.remapPage(secModule.Url);
         secModule.Page = this.getPage(secModule.Url);

         if (secModule.Url.startsWith('module') && secModule.Url.includes('?')) {
             secModule.Url = secModule.Url.substr(0, secModule.Url.indexOf('?'));
         }

         index = this.findModule(secModule);

         if (index > -1) {
             try {
                 if (this.OpenSecurityModules[index].Url.includes("Employee/Timesheet") == true && this.OpenSecurityModules[index].Url != secModule.Url) {
                     this.OpenSecurityModules[index].Url = secModule.Url;
                 }
                 if (this.OpenSecurityModules[index].Url.includes("NewExpenseReport") == true) {
                     this.OpenSecurityModules[index].Url = newurl;
                 }
             } catch (e) {
             }
             this.selectModule(this.OpenSecurityModules[index]);
         }
         else {
             this.OpenSecurityModules.push(secModule);
             this.selectModule(secModule);
         }
        
    }

    IsDialog(url: string) {
        if (url.includes('Alert_New.aspx') ||
            url.includes('Alert_AddAttachments.aspx') ||
            url.includes('Alert_Assignment.aspx') ||
            url.includes('Alert_DigitalAssetReview_AddAsset.aspx') ||
            url.includes('Alert_DigitalAssetReview_AddReviewer.aspx') ||
            url.includes('Alert_Settings.aspx') ||
            url.includes('Agile/Design') ||
            url.includes('About.aspx') ||
            url.includes('AgencySettings.aspx') ||
            url.includes('AgencySettings_Upload.aspx') ||
            url.includes('BillingApproval.aspx') ||
            url.includes('BillingApproval_Alert.aspx') ||
            url.includes('BillingApproval_AlertList.aspx') ||
            url.includes('BillingApproval_Batch.aspx') ||
            url.includes('BillingApproval_Print.aspx') ||
            (url.includes('BillingApproval_Approval_Detail.aspx') && url.includes('AID=-1')) || //should be a new one
            url.includes('BillingApproval_Approval_JobComponent_Comments.aspx') ||
            url.includes('Calendar_NewActivity.aspx') ||
            url.includes('Campaign_ChangeCode.aspx') ||
            url.includes('Campaign_New.aspx') ||
            url.includes('CreativeBrief_Print.aspx') ||
            url.includes('Desktop_AddWorkItem') ||
            url.includes('Desktop_NewAssignment') ||
            url.includes('Desktop_Reassign') ||
            url.includes('Desktop_AlertView_CopyTransfer') ||
            url.includes('DirectExpenseAlert_Detail.aspx') ||
            url.includes('Document_Edit.aspx') ||
            url.includes('Documents_List2.aspx') ||
            url.includes('Documents_AddComment.aspx') ||
            url.includes('Documents_ExcelViewer.aspx') ||
            url.includes('Documents_ImageViewer.aspx') ||
            url.includes('Documents_ImageViewer2.aspx') ||
            url.includes('Documents_MediaViewer.aspx') ||
            url.includes('Documents_MSGViewer.aspx') ||
            url.includes('Documents_PDFViewer.aspx') ||
            url.includes('Documents_ProofHQUpload.aspx') ||
            url.includes('Documents_History.aspx') ||
            url.includes('Documents_Upload.aspx') ||
            url.includes('Documents_List.aspx') ||
            url.includes('Documents_WordViewer.aspx') ||
            //url.includes('Employee/ExpenseReports/UploadReceipts') ||
            url.includes('EmployeeTimeForecast_New.aspx') ||
            //url.includes('EmployeeTimeForecast_ComparisonDashboard.aspx') ||
            url.includes('EmployeeTimeForecast_Settings.aspx') ||
            url.includes('EmployeeTimeForecast_AddJobComponents.aspx') ||
            url.includes('EmployeeTimeForecast_AddEmployees.aspx') ||
            url.includes('EmployeeTimeForecast_AddAlternateEmployees.aspx') ||
            url.includes('EmployeeTimeForecast_AddIndirectCategories.aspx') ||
            url.includes('EmployeeTimeForecast_CreateRevision.aspx') ||
            url.includes('Employee/Timesheet/Entry') ||
            url.includes('Estimating_AddNew.aspx') ||
            url.includes('Estimating_AddNewComponent.aspx') ||
            url.includes('Estimating_AddRow.aspx') ||
            url.includes('Estimating_Approval.aspx') ||
            url.includes('Estimating_CopyFrom.aspx') ||
            url.includes('Estimating_FunctionComments.aspx') ||
            url.includes('Estimating_ImportSpecs.aspx') ||
            url.includes('Estimating_JobHistory.aspx') ||
            url.includes('Estimating_JobSpecs.aspx') ||
            url.includes('Estimating_Phase.aspx') ||
            url.includes('Estimating_PrintSettings.aspx') ||
            url.includes('Estimating_QuickAdd.aspx') ||
            url.includes('Estimating_QuoteFromPS.aspx') ||
            url.includes('Estimating_Setup.aspx') ||
            url.includes('Expense_CopyExpenseReport.aspx') ||
            //url.includes('Expense_Edit_V2.aspx') ||
            //url.includes('Expense_Edit.aspx') ||
            url.includes('Expense_Paid_detail.aspx') ||
            url.includes('Expense_Phase.aspx') ||
            url.includes('Expense_Print.aspx') ||
            url.includes('Expense_SelectItems.aspx') ||
            url.includes('Expense_SubmitOptions.aspx') ||
            url.includes('GeneralLedger/Reports/GeneralLedgerReport/DetailByAccountReport') ||
            url.includes('Google_Authentication.aspx') ||
            url.includes('Help_ContactCustomerSupport.aspx') ||
            url.includes('JobComponent_Comments.aspx') ||
            url.includes('jobspecs_AddNew.aspx') ||
            url.includes('JobForecast_New.aspx') ||
            url.includes('jobVerNew.aspx') ||
            url.includes('JobVersion_Print.aspx') ||
            //(url.includes('jobVerTmplt.aspx')) ||
            url.includes('JobTemplate_Print.aspx') ||
            url.includes('JobTemplate_NewComponent.aspx') ||
            url.includes('JobForecast_AddJobComponents.aspx') ||
            url.includes('JobForecast_Allocate.aspx') ||
            (url.includes('JobForecast_Print.aspx') && url.includes('mode=4')) ||
            url.includes('JobForecast_Settings.aspx') ||
            url.includes('JobSpecs_AddNew.aspx') ||
            url.includes('JobSpecs_Print.aspx') ||
            url.includes('JobTemplate_New.aspx') ||
            url.includes('JobTemplate_Settings.aspx') ||
            url.includes('LookUp_AdNumber.aspx') || 
            url.includes('LookUp_EmailRecipients.aspx') ||
            url.includes('LocationOverride.aspx') ||
            url.includes('Maintenance_ActivitySummary.aspx') ||
            url.includes('Maintenance_AlertAssignments_StateWorkflow.aspx') ||
            url.includes('Maintenance_CalendarTime.aspx') ||
            url.includes('Maintenance_ClientContactManager.aspx') ||
            (url.includes('Maintenance_ClientEdit.aspx') && (url.includes('Mode=Copy') || url.includes('Mode=Add'))) ||
            url.includes('Maintenance_CompanyProfile.aspx') ||
            url.includes('Maintenance_ContractEdit.aspx') ||
            url.includes('Maintenance_ContractManager.aspx') ||
            url.includes('Maintenance_DiaryEdit.aspx') ||
            url.includes('Maintenance_DivisionEdit.aspx') ||
            url.includes('Maintenance_ProductEdit.aspx') ||
            url.includes('Media_ATB_OrderDetails.aspx') ||
            url.includes('Media_ATB_Print.aspx') ||
            url.includes('Media_ATB_Add.aspx') ||
            url.includes('MediaCalendar_OrderDetail.aspx') ||
            url.includes('mediavendorinfo.aspx') ||
            url.includes('popcomments.aspx') ||
            url.includes('popContacts.aspx') ||
            url.includes('popContactsAdd.aspx') ||
            url.includes('PopLookupVC') ||
            url.includes('popTime.aspx') ||
            url.includes('popup_email_alert.asp') ||
            url.includes('ProjectManagement/ProjectSchedule/Setup') ||
            url.includes('ProjectManagement/Agile/HoursByAlertID') ||
            url.includes('ProjectManagement/ProjectSchedule/QuickEdit') ||
            url.includes('ProjectManagement/ProjectSchedule/Create') ||
            url.includes('ProjectManagement/ProjectSchedule/FindAndReplace') ||
            url.includes('ProjectManagement_Agile_NewWorkItemTimeDialogFromOld') ||
            (url.includes('purchaseorder.aspx') && !url.includes('pagemode=edit')) ||
            (url.includes('PurchaseOrder_Print.aspx') && url.includes('mode=4')) ||
            url.includes('purchaseorder_approval.aspx') ||
            url.includes('PurchaseOrder_CopyWizard.aspx') ||
            url.includes('purchaseorder_dtl.aspx') ||
            url.includes('purchaseorder_dtl_add.aspx') ||
            url.includes('purchaseorder_memo_disp.aspx') ||
            url.includes('PurchaseOrderAPDetails.aspx') ||
            url.includes('Reporting/AccountsPayableBalanceByVendorReportCriteria') ||
            url.includes('Reporting/AccountsReceivableBalanceByClientReportCriteria') ||
            url.includes('Reporting/RevenueBreakdownByClientReportCriteria') ||
            url.includes('Reporting/SalesAndCostOfSalesByClientReportCriteria') ||
            url.includes('Reporting_DynamicReportColumnEdit.aspx') ||
            url.includes('Reporting_EmployeeUtilizationReportEdit.aspx') ||
            url.includes('Reporting_InitialLoading') ||
            url.includes('Reporting_InitialLoadingSaveDynamicReportTemplate.aspx') ||
            url.includes('Reporting_JobStatusReportEdit.aspx') ||
            url.includes('Reporting_JobVersionReportEdit.aspx') ||
            url.includes('Reporting_SaveDynamicJobStatusReportTemplate.aspx') ||
            url.includes('Reporting_SaveDynamicJobVersionReportTemplate.aspx') ||
            url.includes('Reporting_MediaSpecificationReportEdit.aspx') ||
            url.includes('Reporting_SaveDynamicMediaSpecificationReportTemplate.aspx') ||
            url.includes('Reporting_SaveDynamicReportTemplate.aspx') ||
            url.includes('Reporting_SaveDynamicEmployeeUtilizationReportTemplate.aspx') ||
            url.includes('Reporting_SaveDynamicSprintReportTemplate.aspx') ||
            url.includes('Reporting_FilterReport.aspx') ||
            url.includes('Reporting_UserDefinedReportEdit.aspx') ||
            url.includes('Reporting_UserDefinedReportEdit.aspx') ||
            url.includes('Resources_Emps_Find.aspx') ||
            url.includes('Schedule_QuickAdd.aspx') ||
            url.includes('Security_ChangePassword.aspx') ||
            url.includes('Security_ClientPortal_Settings.aspx') ||
            url.includes('Security_DocumentRepository.aspx') ||
            url.includes('Timesheet_CommentsView.aspx') ||
            url.includes('Timesheet_Stopwatch.aspx') ||
            url.includes('Timesheet_Template_Add.aspx') ||
            url.includes('TrafficSchedule_AddJobPred.aspx') ||
            url.includes('TrafficSchedule_CopyFrom.aspx') ||
            url.includes('TrafficSchedule_Print.aspx') ||
            url.includes('TrafficSchedule_QuickAdd.aspx') ||
            url.includes('TrafficSchedule_TaskEmployees.aspx') ||
            url.includes('TrafficSchedule_TaskComments.aspx') ||
            url.includes('TrafficSchedule_TaskContacts.aspx') ||
            url.includes('TrafficScheduleTemplate_New.aspx') ||
            url.includes('TrafficScheduleVersion.aspx') ||
            url.includes('Reporting_SprintReportEdit.aspx') ||
            url.includes('Schedule_AddFromEst.aspx') ||
            //url.includes('VendorQuote.aspx') ||
            url.includes('VendorQuote_Comments.aspx') ||
            url.includes('VendorQuote_Contacts.aspx') ||
            url.includes('VendorQuote_Functions.aspx') ||
            url.includes('VendorQuote_PrintSetup.aspx') ||
            url.includes('VendorQuote_Versions.aspx') ||
            url.includes('VendorQuote_Vendors.aspx') ||
            url.includes('Workspace_Manage.aspx')
        ) {

            return true;

        }

        return false;
    }

    openApplication(applicationMenuItem: Application.ApplicationMenuItem) {
        if (applicationMenuItem) {
            let index: number = -1;
            if (!this.OpenSecurityModules || this.OpenSecurityModules.length == 0) {
                this.OpenSecurityModules = [];
            }
            if (this.IsDialog(applicationMenuItem.Url)) {
                if (applicationMenuItem.Url.indexOf("Alert_New.aspx") > -1 && applicationMenuItem.Url.indexOf("assn=1") > -1) {
                    applicationMenuItem.Url = this.remapPage(applicationMenuItem.Url);
                }
                this.OpenDialog(applicationMenuItem.Text, applicationMenuItem.Url, 0, 0);
            }
            else {
                applicationMenuItem.Url = applicationMenuItem.Url.replace(/\/\//g, "/");
                applicationMenuItem.Page = this.getPage(applicationMenuItem.Url);
                applicationMenuItem.Url = this.remapPage(applicationMenuItem.Url);
                index = this.findModule(applicationMenuItem);
                if (index > -1) {
                    this.selectModule(this.OpenSecurityModules[index]);
                }
                else {
                    this.OpenSecurityModules.push(applicationMenuItem);
                    this.selectModule(applicationMenuItem);
                }

                //// This doesn't work for me
                //if (this.itemIsNotOpen(applicationMenuItem) === true) {
                //    this.OpenSecurityModules.push(applicationMenuItem);
                //    this.selectModule(applicationMenuItem);
                //}
            }
        }
    }
    itemIsNotOpen(module: Application.ApplicationMenuItem) {
        let allow: boolean = true;
        try {
            if (this.OpenSecurityModules && module.Url) {
                if (allow === true && module.Url.indexOf("Employee/Timesheet") > -1) {
                    allow = false;
                }
                if (allow === true && module.Url.indexOf("Desktop_Alert") > -1) {
                    allow = false;
                }
                if (allow === false) {
                    let obj = this.OpenSecurityModules.find(o => o.Url === module.Url);
                    if (obj) {
                        this.selectModule(obj);
                    } else {
                        allow = true;
                    }
                }
            }
        } catch (e) {
            allow = true;
        }
        return allow;
    }

    bookmarksClick() {
        this.bookmarksDialog.open();
    }
    editBookmarkClick() {
        alert('edit the bookmark!');
    }
    openBookmarkClick(bookmark) {        
        this.closeLeftDrawer();
        
        if (bookmark.PageURL.includes('.aspx')) {
            this.OpenRadWindow(bookmark.Name, bookmark.PageURL, 0, 0);
        }
        else {
            var s;
            s = bookmark.PageURL.substring(0, bookmark.PageURL.indexOf('?'));
            this.openModule(bookmark.Name, s);
        }
    }
    selectSideMenu(option: string) {
        this.selectedSideMenu = option;
    }
    parseURLParams(paramString: string) {
        var params = paramString.split('&');
        var nvPair = [];

        params.forEach(function (item) {
            var newp = item.split('=');

            nvPair[newp[0]] = newp[1];

        });

        return nvPair;
    }

    signOut() {
        // No need to confirm with user; if they clicked the button, it wasn't an accident and they want to sign out.
        try { //Try to sign out properly to release license
            this.service.signOut().then(response => {
                let signedOut = true;
                if (response && response.content) {
                    if (response.content.Success === false && response.content.Message !== "") {
                        signedOut = false;
                        alert(response.content.Message);
                    }
                    //if (signedOut === true) {
                    window.location.replace("SignIn.aspx");
                    //}
                }
            })
        } catch (e) {
            // SignIn.aspx will sign out if not signed out properly
            window.location.replace("SignIn.aspx");
        }
    }

    selectModule(securityModule) {        
        //if (securityModule.Page == "Inbox") {                                             
        //    for (let i = 0; i < this.OpenSecurityModules.length; i++) {                
        //        //check to see if the Alert Detail view or JJ is open
        //        if (this.OpenSecurityModules[i].Page == "Desktop_AlertView" || this.OpenSecurityModules[i].Page == "Content.aspx") {                    
        //            //this.refreshInboxModule(securityModule);                    
        //            break;
        //        }
        //    }           
        //}
        
        let paymentCenterBatchDetailTab;
        let refreshPaymentManagerFlag;     
        
        if (this.dashBoardLoaded == true && securityModule.Url == "modules/dashboard/dashboard" && this.notificationClicked == true) {
            this.refreshAlertNotifications()
        }

        if (this.OpenSecurityModules) {
            for (var i = 0; i < this.OpenSecurityModules.length; i++) {
                if (this.OpenSecurityModules[i]) {
                    this.OpenSecurityModules[i].Active = false;
                }
                
                if (securityModule.Page == "PaymentCenter") {
                    if (this.OpenSecurityModules[i].Page == "OpenBatch" || this.OpenSecurityModules[i].Page == "CreateBatch") {                        

                        if (this.OpenSecurityModules[i].Page == "OpenBatch") {
                            paymentCenterBatchDetailTab = this.OpenSecurityModules.find(function (osm) {
                                return osm.Page == "OpenBatch";
                            });
                        }

                        if (this.OpenSecurityModules[i].Page == "CreateBatch") {
                            paymentCenterBatchDetailTab = this.OpenSecurityModules.find(function (osm) {
                                return osm.Page == "CreateBatch";
                            });
                        }

                        if (paymentCenterBatchDetailTab) {
                            var win = paymentCenterBatchDetailTab.Frame.contentWindow;                            

                            if (win) {                                                                
                                refreshPaymentManagerFlag = win.GetRefreshPaymentCenterFlag();

                                if (refreshPaymentManagerFlag)
                                    win.ResetRefreshPaymentCenterFlag();
                            }
                        }
                    }
                }
            }            
        }
        if (securityModule) {
            securityModule.Active = true;
        }
        this.notificationClicked = false;

        if (securityModule.Page == "PaymentCenter" && refreshPaymentManagerFlag) {
            let paymentManagerTab = this.OpenSecurityModules.find(function (osm) {
                return osm.Page == "PaymentCenter";
            });

            win = paymentManagerTab.Frame.contentWindow;
            if (win) {
                win.refreshPage("parent");
            }
        }
    }
    openDashboardOnActivate() {
        this.openModule("Desktop", "modules/dashboard/dashboard");
        if (this.OpenSecurityModules && this.OpenSecurityModules[0]) {
            this.OpenSecurityModules[0].Active = true;
        }
        this.dashBoardLoaded = true;
    }
    closeModuleClick(securityModule) {           
        if (securityModule) {
            //console.log("closeModuleClick:securityModule", securityModule);
            if (securityModule.Url.indexOf("Proofing?dl=") > - 1) {
                var alertId: number = 0;
                try {
                    if (securityModule.Parameters.xyz) {
                        alertId = securityModule.Parameters.xyz * 1;
                    }
                } catch (e) {
                    alertId = 0;
                }
                if (alertId && alertId > 0) {
                    this.refreshAssignmentTab(alertId, 0, null, 5);
                }
                this.closeModule(securityModule);
            }
            if (securityModule.Page == "Timesheet") {
                this.checkForTimesheetCloseModule(securityModule);
            //} else if (securityModule.Page == "Desktop_AlertView") {
            //    for (let i = 0; i < this.OpenSecurityModules.length; i++) {
            //        if (this.OpenSecurityModules[i].Page == "Inbox") {
            //        //if (this.OpenSecurityModules[i].Page == "Inbox" && this.refreshInboxFlag) {
            //            //refresh the Inbox if there were changes to the detail (Desktop_AlertView)
            //            //this.refreshInboxModule(this.OpenSecurityModules[i]);
            //            this.closeModule(securityModule);
            //        } else {}
            //            this.closeModule(securityModule);                        
            //        }
            //    } 
            //} else if (securityModule.Page == "Content.aspx" && securityModule.Parameters['contaid'] === '10') {
            //    for (let i = 0; i < this.OpenSecurityModules.length; i++) {
            //        if (this.OpenSecurityModules[i].Page == "Inbox") {
            //            //this.refreshInboxModule(this.OpenSecurityModules[i]);
            //            this.closeModule(securityModule);
            //        } else {
            //            this.closeModule(securityModule);
            //        }
            //    }                
            } else if (securityModule.Page == "NewExpenseReport"){
                this.checkForExpenseReportCloseModule(securityModule);
                //this.RefreshWindow("modules/employee/expense-reports/expense-search-two", false, false);
            } else if (securityModule.Page == "Content.aspx" && securityModule.Parameters['contaid'] === '15') {
                this.checkForProjectScheduleCloseModule(securityModule);
            } else if (securityModule.Url.indexOf("conceptshare.com") > -1) {
                try {
                    var reviewPage;
                    for (var i = 0; i < this.OpenSecurityModules.length; i++) {
                        if (this.OpenSecurityModules[i]) {
                            if (this.OpenSecurityModules[i].Page.indexOf("Alert_DigitalAssetReview") > -1) {
                                let x: any;
                                x = this.OpenSecurityModules[i].Frame.contentWindow;
                                if (x) {
                                    x.refreshFromProof();
                                }
                                break;
                            }
                        }
                    }
                    this.closeModule(securityModule);
                } catch (e) {
                    this.closeModule(securityModule);
                }
            //} else if (securityModule.Page == "Desktop_AlertView") {
            //    this.checkForAssignmentCloseModule(securityModule);
            } else if (securityModule.Page == "Inbox") {                
                this.checkForInboxCloseModule(securityModule);
            } else if (securityModule.Page == "Locations") {
                this.checkForLocationsCloseModule(securityModule);
            } else {
                this.closeModule(securityModule);
            }
            if (securityModule.Page == "Estimating_Quote.aspx") {
                //console.log("close " + securityModule.Parameters['j']);
                var secModule = new Application.ApplicationMenuItem;
                var index: number = -1;
                var WindowURL: string = ""                
                if (securityModule.Parameters['j'] == undefined || securityModule.Parameters['j'] == "0") {
                    this.RefreshWindow("Estimating.aspx", false, false);
                } else {
                    WindowURL = "Content.aspx?contaid=4&e=" + securityModule.Parameters['e'] + "&ec=" + securityModule.Parameters['ec'] + "&j=" + securityModule.Parameters['j'] + "&jc=" + securityModule.Parameters['jc'];
                    secModule.Url = WindowURL;
                    secModule.Page = this.getPage(secModule.Url);
                    index = this.findModule(secModule);
                    if (this.findModule(secModule) == -1) {
                        secModule = new Application.ApplicationMenuItem;
                        WindowURL = "Content.aspx?contaid=10&j=" + securityModule.Parameters['j'] + "&jc=" + securityModule.Parameters['jc'];
                        secModule.Url = WindowURL;
                        secModule.Page = this.getPage(secModule.Url);
                        index = this.findModule(secModule);

                        if (this.findModule(secModule) != -1) {
                            this.RefreshWindow(WindowURL, false, false);
                        }

                    } else {
                        this.RefreshWindow(WindowURL, false, false);
                    }
                }               
               
            }
            if (securityModule.Page == "BillingApproval_Approval_JobComponent.aspx") {

                this.RefreshWindow("BillingApproval_Approval_Detail.aspx", false, false);

            }
            if (securityModule.Page == "BillingApproval_Batch.aspx") {

                this.RefreshWindow("BillingApproval_View.aspx", false, false);

            }
            //if (securityModule.Page == "Content.aspx" && securityModule.Url.indexOf("contaid=10") > -1) {

            //    let client = new HttpClient();
            //    let me = this;

            //    var data = {
            //        JobNumber: 338,
            //        JobComponentNumber: 1
            //    };

            //    client.post('ProjectManagement/JobTemplate/JobComponentIsMissingRequiredField', data)
            //        .then(data => {
            //           //console.log(data.content);
            //           me.jcmissingrequiredfield = data.content; 
            //            var dc = data.content;
            //            if (dc == 'true') {
            //                me.jcmissingrequiredfield = true;
            //            }    
            //            if (me.jcmissingrequiredfield == true) {
            //               var edit = false;
            //               edit = confirm("Job is missing required info!\nWould you like to edit?");
            //                if (edit == false) {
                               
            //                 }
            //            }
                       
            //        });
            //}

        } else {
            this.closeModule(securityModule);
        }
        //let dialog = $('<div></div>').appendTo(document.body);
        //let kDialog: kendo.ui.Dialog;
        //let me = this;
        //this.closeModule(securityModule);
        //kDialog = dialog.kendoDialog({
        //    buttonLayout: 'normal',
        //    title: false,
        //    closable: false,
        //    content: 'Are you sure you want to close?',
        //    actions: [
        //        {
        //            text: 'OK',
        //            primary: true,
        //            action: function (e) {
        //                me.closeModule(securityModule);
        //                return true;
        //            }
        //        },
        //        {
        //            text: 'Cancel'
        //        }
        //    ],
        //    close: function (e) {
        //        kDialog.wrapper.remove();
        //    }
        //}).data('kendoDialog');

        //kDialog.open();


    }
    closeModule(securityModule) {
        var idx = this.OpenSecurityModules.indexOf(securityModule);
        var newActive = -1;
        if (idx >= 0) {
            if (securityModule && securityModule.Active) {
                if (this.OpenSecurityModules.length > (idx + 1)) {
                    newActive = idx + 1;
                } else if (this.OpenSecurityModules.length > 1) {
                    newActive = idx - 1;
                }
            }
            if (newActive >= 0) {
                this.selectModule(this.OpenSecurityModules[newActive]);
            }
            this.OpenSecurityModules.splice(idx, 1);
        }
        this.closeMenus();
    }
    checkForAssignmentCloseModule(securityModule) {
        //this.closeModule(securityModule);
        ////try {
        ////    if (securityModule) {
        ////        if (securityModule.Frame) {
        ////            console.log("checkForAssignmentCloseModule:securityModule", securityModule);
        ////            var win = securityModule.Frame.contentWindow;
        ////            if (win) {
        ////                console.log("window", win);
        ////                console.log("win.assignmentChanged", win.assignmentChanged);
        ////            } else {
        ////                this.closeModule(securityModule);
        ////            }
        ////        } else {
        ////            this.closeModule(securityModule);
        ////        }
        ////    }
        ////} catch (e) {
        ////    this.closeModule(securityModule);
        ////}
    }

    checkForExpenseReportCloseModule(securityModule) {
        if (securityModule && securityModule.Frame) {
            var win = securityModule.Frame.contentWindow;
            let ERSearchTab: Application.ApplicationMenuItem;

            ERSearchTab = this.OpenSecurityModules.find(function (osm) {
                return osm.Page == 'expense-search-two';
            });

            if (win && win.unSavedChanges()) {
                if (confirm("Save changes?") == true) {
                    win.aureliaSave();      
                    //this.closeModule(securityModule);
                }
            }
             
            //if (ERSearchTab) {
                this.refreshExpenseReports();
                this.closeModule(securityModule);
            //}
            
            

        } 
       
        
    }

    checkForProjectScheduleCloseModule(securityModule) {
        if (securityModule && securityModule.Frame) {
            var win = securityModule.Frame.contentWindow;
            var ele = win.frames[0];
            
            if (ele && typeof ele.setSave !== 'undefined') {
                if (ele.setSave()) {
                    if (confirm("Save changes?") === true) {
                        $.when(ele.savePS()).done(() => {
                            this.closeModule(securityModule);
                        });
                    } else {
                        this.closeModule(securityModule);
                    }     
                } else {
                    this.closeModule(securityModule);
                }                
            } else {
                this.closeModule(securityModule);
            }        

        }


    }

    checkForInboxCloseModule(securityModule) {
        if (securityModule && securityModule.Frame) {

            var win = securityModule.Frame.contentWindow;
            let InboxMgrTab: Application.ApplicationMenuItem;

            InboxMgrTab = this.OpenSecurityModules.find(function (osm) {
                return osm.Page == 'Inbox';
            });

            if (win && win.unSavedChanges()) {
                if (confirm("Save changes?") == true) {
                    win.ParentContainerSave();
                }
            }
            //this.refreshExpenseReports();
            this.closeModule(securityModule);
        }

    }

    checkForLocationsCloseModule(securityModule) {
        if (securityModule && securityModule.Frame) {

            var win = securityModule.Frame.contentWindow;
            let LocationsTab: Application.ApplicationMenuItem;

            LocationsTab = this.OpenSecurityModules.find(function (osm) {
                return osm.Page == 'Locations';
            });

            if (win && win.unSavedChanges()) {
                if (confirm("Save changes?") == true) {
                    win.ParentContainerSave();
                }
            }
            //this.refreshExpenseReports();
            this.closeModule(securityModule);
        }

    }

    checkForTimesheetCloseModule(securityModule) {
        try {
            if (securityModule) {
                if (securityModule.Frame) {
                    var win = securityModule.Frame.contentWindow;
                    if (win) {
                        var timesheetUpdates = win.updates;
                        var timesheetInserts = win.inserts;
                        var timesheetDeletes = win.deletes;
                        var showConfirm = false;
                        if (timesheetUpdates || timesheetInserts || timesheetDeletes) {
                            if (timesheetUpdates && timesheetUpdates.length > 0) {
                                showConfirm = true;
                            }
                            if (showConfirm == false && timesheetInserts && timesheetInserts.length > 0) {
                                showConfirm = true;
                            }
                            if (showConfirm == false && timesheetDeletes && timesheetDeletes.length > 0) {
                                showConfirm = true;
                            }
                            if (showConfirm == true) {
                                if (confirm("Save changes?") == true) {
                                    win.saveClick();
                                    this.closeModule(securityModule);
                                } else {
                                    this.closeModule(securityModule);
                                }
                            } else {
                                this.closeModule(securityModule);
                            }
                        } else {
                            this.closeModule(securityModule);
                        }
                    } else {
                        this.closeModule(securityModule);
                    }
                } else {
                    this.closeModule(securityModule);
                }
            }
        } catch (e) {
            this.closeModule(securityModule);
        }
    }
    openDashBoard() {

        let secModule = new Application.ApplicationMenuItem;
        var index: number = 0;
        let me = this;

        secModule.Text = "Desktop";
        secModule.Url = "modules/dashboard/dashboard";
        //secModule.Parameters = me.parseURLParams(url.substring(url.indexOf('?') + 1));
        secModule.Page = "modules/dashboard/dashboard";

        index = me.findModule(secModule)
        if (index > -1) {
            me.selectModule(me.OpenSecurityModules[index]);
        }
        else {
            me.OpenSecurityModules.push(secModule);
            me.selectModule(secModule);
        }

    }
    openSettings() {
        let secModule = new Application.ApplicationMenuItem;
        var index: number = 0;
        let me = this;

        secModule.Text = "Settings";
        secModule.Url = "modules/misc/settings/settings";
        //secModule.Parameters = me.parseURLParams(url.substring(url.indexOf('?') + 1));
        secModule.Page = "modules/misc/settings/settings";

        index = me.findModule(secModule)
        if (index > -1) {
            me.selectModule(me.OpenSecurityModules[index]);
        }
        else {
            me.OpenSecurityModules.push(secModule);
            me.selectModule(secModule);
        }
    }
    changepassword() {

        this.OpenRadWindow("Change Password", "Security_ChangePassword.aspx", 0, 0);

    }
    assignments() {
        this.openDashBoard();
        setTimeout(function () {
            var tabStrip = $("#dashboard-tabs").kendoTabStrip().data("kendoTabStrip");
            tabStrip.select(0);
        }, 50)
    }
    alerts() {
        var $alertToggle = $('#alert-toggle');
        this.openDashBoard();
        var tabStrip = $("#dashboard-tabs").kendoTabStrip().data("kendoTabStrip");
        tabStrip.select(1);
    }
    calendar() {
        this.openDashBoard();
        var tabStrip = $("#dashboard-tabs").kendoTabStrip().data("kendoTabStrip");
        tabStrip.select(2);
    }
    timesheet() {
        this.openDashBoard();
        var tabStrip = $("#dashboard-tabs").kendoTabStrip().data("kendoTabStrip");
        tabStrip.select(3);
    }
    openBookmarks() {
        this.openDashBoard();
        var tabStrip = $("#dashboard-tabs").kendoTabStrip().data("kendoTabStrip");
        tabStrip.select(4);
    }
    reviews() {
        this.openDashBoard();
        var tabStrip = $("#dashboard-tabs").kendoTabStrip().data("kendoTabStrip");
        tabStrip.select(5);
    }
    systemSearch() {
        var $searchKeywords = $('#searchKeywords');
        $searchKeywords.val();
        //console.log($searchKeywords);
        this.openModule('', 'Search.aspx');
    }
    remapPage(oldURL: string) {
        var newURL: string = oldURL;
        if (oldURL.startsWith("Timesheet.aspx") === true) {
            newURL = "Employee/Timesheet";
        } else if (oldURL.indexOf("Alert_New.aspx") > -1 && oldURL.indexOf("assn=1") > -1) {
            var qs = oldURL.indexOf("?");
            if (qs && qs > -1) {
                try {
                    newURL = "Desktop_NewAssignment" + oldURL.substr(qs, oldURL.length);
                } catch (e) {
                    newURL = "Desktop_NewAssignment";
                }
            } else {
                newURL = "Desktop_NewAssignment";
            }
        }
        //else if (oldURL.indexOf("Inbox") > -1) {
        //    newURL = 'Alert_Inbox.aspx';
        //}
        else if (oldURL.indexOf("JobTemplate_Search.aspx") > -1) {
            newURL = 'modules/project-management/job-jacket/job-jacket-search';
        }
        else if (oldURL.indexOf("TrafficSchedule_Search.aspx") > -1) {
            newURL = 'modules/project-management/project-schedule/project-schedule-search';
        }
        else if (oldURL.indexOf("Expense_V2.aspx") > -1) {
            newURL = 'modules/employee/expense-reports/expense-search-two';
        }
        else if (oldURL.indexOf("Campaign_Search.aspx") > -1) {
            newURL = 'modules/project-management/campaigns/campaigns';
        }
        else if (oldURL.indexOf("Estimating_Search.aspx") > -1) {
            newURL = 'modules/project-management/estimate/estimate';
        }
        else if (oldURL.indexOf("purchaseorderlist.aspx") > -1) {
            newURL = 'modules/project-management/purchase-orders/purchase-orders';
        }
        else if (oldURL.indexOf("AcctFinanceDashboard") > -1) {
            newURL = 'modules/dashboard/acct-finance-dashboard';
        }
        if (oldURL.indexOf("AcctFinanceCashDashboard") > -1) {
            newURL = 'modules/dashboard/acct-finance-cash-dashboard';
        }
        else if (oldURL.indexOf("ExecutiveDashboard") > -1) {
            newURL = 'modules/dashboard/executive-dashboard';
        }
        else if (oldURL.indexOf("MySettings.aspx") > -1) {
            newURL = 'modules/misc/settings/settings';
        }        
        //else if (oldURL.indexOf("Expense_Edit_v2.aspx") > -1) {
        //    newURL = 'modules/employee/expense-reports/expense-edit';
        //}
        return newURL;
    }

    findModule(applicationMenuItem: Application.ApplicationMenuItem) {

        let idx: number = -1;
        let idx2: number = -1;
        let items: Array<any> = null;
        let item: Application.ApplicationMenuItem = null;
        let item2: Application.ApplicationMenuItem = null;

        //console.log(new Error().stack);

        //console.log("findModule:applicationMenuItem", applicationMenuItem);
        //console.log("findModule:OpenSecurityModules", this.OpenSecurityModules);

        if (applicationMenuItem.Page.toUpperCase() == 'campaigns'.toUpperCase() ||
            applicationMenuItem.Page.toUpperCase() == 'AgencySettings.aspx'.toUpperCase() ||
            applicationMenuItem.Page.toUpperCase() == 'MySettings.aspx'.toUpperCase() ||
            applicationMenuItem.Page.toUpperCase() == 'job-jacket-search'.toUpperCase() ||
            applicationMenuItem.Page.toUpperCase() == 'purchase-orders'.toUpperCase() ||
            applicationMenuItem.Page.toUpperCase() == 'project-schedule-search'.toUpperCase() ||
            applicationMenuItem.Page.toUpperCase() == 'document-manager'.toUpperCase() ||
            applicationMenuItem.Page.toUpperCase() == 'expense-search-two'.toUpperCase() ||
            applicationMenuItem.Page.toUpperCase() == 'JobRequest_Search.aspx'.toUpperCase() ||
            applicationMenuItem.Page.toUpperCase() == 'estimate'.toUpperCase() ||
            applicationMenuItem.Page.toUpperCase() == 'Document_AdvancedSearch.aspx'.toUpperCase() ||
            applicationMenuItem.Page.toUpperCase() == 'About.aspx'.toUpperCase() ||
            applicationMenuItem.Page.toUpperCase() == 'Help_ContactCustomerSupport.aspx'.toUpperCase() ||
            applicationMenuItem.Page.toUpperCase() == 'help'.toUpperCase() ||
            applicationMenuItem.Page.toUpperCase() == 'Timesheet_Search.aspx'.toUpperCase() ||
            applicationMenuItem.Page.toUpperCase() == 'purchaseorderlist.aspx'.toUpperCase() ||
            applicationMenuItem.Page.toUpperCase() == 'Alert_Notification.aspx'.toUpperCase() ||
            applicationMenuItem.Page.toUpperCase() == 'Alert_DigitalAssetReview.aspx'.toUpperCase() ||
            //applicationMenuItem.Page.toUpperCase() == 'Inbox'.toUpperCase() ||
            applicationMenuItem.Page.toUpperCase() == 'Calendar_MonthView.aspx'.toUpperCase()) {

            //only allow one

            item = this.OpenSecurityModules.find(function (osm) {
                return osm.Page.toUpperCase() == applicationMenuItem.Page.toUpperCase();
            });

            idx = this.OpenSecurityModules.indexOf(item);
        }
        else if (applicationMenuItem.Page.toUpperCase() == 'Chat_Room.aspx'.toUpperCase()) {
            item = this.OpenSecurityModules.find(function (osm) {
                return osm.Page.toUpperCase() == applicationMenuItem.Page.toUpperCase() &&
                    osm.Url.toUpperCase() == applicationMenuItem.Url.toUpperCase();
            });

            idx = this.OpenSecurityModules.indexOf(item);
        }
        else if (applicationMenuItem.Page.trim().toUpperCase() == "Alert_View.aspx".toUpperCase() ||
            applicationMenuItem.Page.trim().toUpperCase() == "Desktop_AlertView".toUpperCase() ||
            applicationMenuItem.Page.trim().toUpperCase() == "Campaign.aspx".toUpperCase() ||
            applicationMenuItem.Page.trim().toUpperCase() == "TrafficSchedule_TaskDetail.aspx".toUpperCase() ||
            applicationMenuItem.Page.trim().toUpperCase() == "MediaCalendar_OrderDetail.aspx".toUpperCase() ||
            applicationMenuItem.Page.trim().toUpperCase() == "jobVerTmplt.aspx".toUpperCase()) {
            //allow more then one alert if they are different subjects
            item = this.OpenSecurityModules.find(function (osm) {
                return osm.Url.toUpperCase() == applicationMenuItem.Url.toUpperCase() &&
                    osm.Text.toUpperCase() == applicationMenuItem.Text.toUpperCase();
            });

            idx = this.OpenSecurityModules.indexOf(item);
        }
        else if (applicationMenuItem.Url.toUpperCase() == "modules/dashboard/dashboard".toUpperCase() ||
            applicationMenuItem.Url.toUpperCase() == "modules/misc/settings/settings".toUpperCase() ||
            applicationMenuItem.Url.toUpperCase() == "modules/dashboard/acct-finance-dashboard".toUpperCase() ||
            applicationMenuItem.Url.toUpperCase() == "modules/dashboard/acct-finance-cash-dashboard".toUpperCase() ||
            applicationMenuItem.Url.toUpperCase() == "modules/dashboard/executive-dashboard".toUpperCase() ||
            applicationMenuItem.Page.toUpperCase() == "DesktopObjectLoadWindow.aspx".toUpperCase() ||
            applicationMenuItem.Page.trim().toUpperCase() == "Content.aspx".toUpperCase() ||
            applicationMenuItem.Page.toUpperCase() == "Estimating_Quote.aspx".toUpperCase() ||
            applicationMenuItem.Page.toUpperCase() == "Expense_Edit_V2.aspx".toUpperCase() ||
            applicationMenuItem.Page.toUpperCase() == "Alert_Inbox.aspx".toUpperCase() ||
            applicationMenuItem.Page.toUpperCase() == "QuoteVsActualSummaryPopup.aspx".toUpperCase() ||
            applicationMenuItem.Page.toUpperCase() == "Estimating.aspx".toUpperCase() ||
            applicationMenuItem.Page.toUpperCase() == "Alert_DigitalAssetReview.aspx".toUpperCase() ||
            applicationMenuItem.Page.toUpperCase() == "ServiceFeeDetail.aspx".toUpperCase()) {
            //only allow one of these pages

            if (applicationMenuItem.Page.toUpperCase() == "DesktopObjectLoadWindow.aspx".toUpperCase()) {

                item = this.OpenSecurityModules.find(function (osm) {
                    return osm.Url.replace("&bm=1", "").toUpperCase() == applicationMenuItem.Url.replace("&bm=1", "").toUpperCase();
                });

            } else {

                item = this.OpenSecurityModules.find(function (osm) {
                    return osm.Url.toUpperCase() == applicationMenuItem.Url.toUpperCase();
                });

            }          

            idx = this.OpenSecurityModules.indexOf(item);
        }
        else if (applicationMenuItem.Page.toUpperCase() == "purchaseorder.aspx".toUpperCase()) {

            item = this.OpenSecurityModules.find(function (osm) {
                return osm.Page.toUpperCase() == applicationMenuItem.Page.toUpperCase() &&
                    ((applicationMenuItem.Text && osm.Text.toUpperCase() == applicationMenuItem.Text.toUpperCase()) ||
                        (osm.Url.toUpperCase() == applicationMenuItem.Url.toUpperCase()));
            });

            idx = this.OpenSecurityModules.indexOf(item);
        }
        else if (applicationMenuItem.Page.toUpperCase() == "Reporting_ViewReport.aspx".toUpperCase() ||
                 applicationMenuItem.Page.toUpperCase() == "Reporting_JobDetailAnalysis.aspx".toUpperCase()) {

            //item = this.OpenSecurityModules.find(function (osm) {
            //    return osm.Url.toUpperCase() == applicationMenuItem.Url.toUpperCase();
            //});

            //item2 = this.OpenSecurityModules.find(function (osm) {
            //    return osm.Url.toUpperCase() == "Reporting_DynamicReportEdit.aspx".toUpperCase();
            //});

            //idx = this.OpenSecurityModules.indexOf(item);
            //idx2 = this.OpenSecurityModules.indexOf(item2);

            //if (idx < 0 && idx2 > -1) {
            //    if (applicationMenuItem.Url.includes('DynamicReportTemplateID')) {
            //        idx = idx2;
            //    }
            //}

            //idx = this.OpenSecurityModules.indexOf(item);
        }
        else if (applicationMenuItem.Page.toUpperCase() == "Reporting_DynamicReportEdit.aspx".toUpperCase()) {

            item = this.OpenSecurityModules.find(function (osm) {
                return osm.Url.toUpperCase() == applicationMenuItem.Url.toUpperCase();
            });

            item2 = this.OpenSecurityModules.find(function (osm) {
                return osm.Url.toUpperCase() == "Reporting_DynamicReportEdit.aspx".toUpperCase();
            });

            idx = this.OpenSecurityModules.indexOf(item);
            idx2 = this.OpenSecurityModules.indexOf(item2);

            if (idx < 0 && idx2 > -1) {
                if (applicationMenuItem.Url.includes('DynamicReportTemplateID')) {
                    idx = idx2;
                }
            }

            //idx = this.OpenSecurityModules.indexOf(item);
        }
        else if (applicationMenuItem.Text && applicationMenuItem.Text.toUpperCase() == "Timesheet".toUpperCase()) {
            //only allow one and reload URL of found item with new URL
            item = this.OpenSecurityModules.find(function (osm) {
                return osm.Text.toUpperCase() == applicationMenuItem.Text.toUpperCase();
            });
            idx = this.OpenSecurityModules.indexOf(item);
            if (item) {
                item.Url = applicationMenuItem.Url
            }
        }
        else if (applicationMenuItem.Url.toUpperCase() == 'modules/project-management/campaigns/new-campaign'.toUpperCase()) {
            item = this.OpenSecurityModules.find(function (osm) {
                return (osm.Url.toUpperCase() == applicationMenuItem.Url.toUpperCase() &&
                    osm.Parameters['cid'] == applicationMenuItem.Parameters['cid']);
            });

            idx = this.OpenSecurityModules.indexOf(item);
        }
        else if (applicationMenuItem.Page.toUpperCase() == 'Maintenance_ClientEdit.aspx'.toUpperCase()) {
            item = this.OpenSecurityModules.find(function (osm) {
                return (osm.Url.toUpperCase() == applicationMenuItem.Url.toUpperCase() &&
                    osm.Parameters['ClientCode'] == applicationMenuItem.Parameters['ClientCode']);
            });

            idx = this.OpenSecurityModules.indexOf(item);
        }
        else if (applicationMenuItem.Page.toUpperCase() == 'campaign-periods'.toUpperCase())
        {
            item = this.OpenSecurityModules.find(function (osm) {
                return (osm.Page.toUpperCase() == applicationMenuItem.Page.toUpperCase() &&
                    osm.Parameters['CampaignID'] == applicationMenuItem.Parameters['CampaignID']);
            });

            idx = this.OpenSecurityModules.indexOf(item);
        }

        else if (applicationMenuItem.Page.trim().toUpperCase() == "NewExpenseReport".toUpperCase()) {


            item = this.OpenSecurityModules.find(function (osm) {


                return osm.Url.toUpperCase() == applicationMenuItem.Url.toUpperCase();
            });


            idx = this.OpenSecurityModules.indexOf(item);




        }
        else {
            item = this.OpenSecurityModules.find(function (osm) {
                return osm.Page.toUpperCase() == applicationMenuItem.Page.toUpperCase();
            });

            idx = this.OpenSecurityModules.indexOf(item);
        }


        return idx;
    }
    openModule(text: string, url: string) {
        let applicationMenuItem = new Application.ApplicationMenuItem;

        applicationMenuItem.Text = text;
        applicationMenuItem.Url = url;

        //parse the params
        var params = applicationMenuItem.Url.split('?');

        if (params.length == 2) {
            if (applicationMenuItem.Url.startsWith('modules/')) {
                //if this is straight aurelia clean up the url
                applicationMenuItem.Url = params[0];
            }
            applicationMenuItem.Parameters = this.parseURLParams(params[1]);
        }

        this.openApplication(applicationMenuItem);

    }
    openDialog(title: string, url: string, height: number, width: number, dialogcallback?, param?) {
        this.OpenDialog(title, url, height, width, dialogcallback, param);
    }
    private addModuleForTest(text: string, url: string, autoOpen: boolean) {
        let applicationMenuItem = new Application.ApplicationMenuItem;
        //var help = "Help";
        //var system = "System Search";
        applicationMenuItem.Text = text;
        applicationMenuItem.Url = url;

        //this.mainMenuItems.push(applicationMenuItem);
        //this.mainMenuItems.push(help);
        //this.mainMenuItems.push(system);
        if (autoOpen) {
            this.openApplication(applicationMenuItem);
        }

    }

    dashboardActive() {
        this.selectModule(this.OpenSecurityModules[0]);
        this.closeLeftDrawer();
    }

    GetBookmarks() {
        let client = new HttpClient();
        let me = this;

        client.get('Utilities/GetBookmarks')
            .then(data => {
                //console.log(data.content);
                me.bookmarks = data.content;

                if (me.bookmarks.length > 0) {

                    var i;
                    for (i = 0; i < me.bookmarks.length; i++) {
                        if (me.bookmarks[i].OpenByDefault == true) {
                            me.openModule(me.bookmarks[i].Name, me.bookmarks[i].PageURL);
                        }
                    }
                    this.selectModule(this.OpenSecurityModules[0]);
                }
            });
    }
    //  For legacy pages(?)
    OpenAlertNotifiy() {
        this.refreshAlertNotifications();
        //var FoundWnd = this.FindWindow('Alert_Notification.aspx');
        //if (FoundWnd >= 0) {
        //    //FoundWnd.reload();
        //    this.RefreshChildPageGrid('Alert_Notification.aspx');
        //}
        //else {

        //    this.OpenRadWindow('You have new Alerts', 'Alert_Notification.aspx', 0, 0);

        //    //var mainContentHeight = $("#maincontent").height();
        //    //var mainContentWidth = $("#maincontent").width();
        //    //var w = 375;
        //    //var h = 200;
        //    //var t = 0;
        //    //var l = 0;
        //    //var buffer = 5;
        //    //t = mainContentHeight - h - buffer;
        //    //l = mainContentWidth - w - buffer;
        //    //var oWnd = manager.open('Alert_Notification.aspx', '', null, w, h);
        //    //oWnd.set_destroyOnClose(true);
        //    //oWnd.set_title('You have new Alerts');
        //    //oWnd.set_iconUrl('Images/blank.ico');
        //    //oWnd.set_behaviors(Telerik.Web.UI.WindowBehaviors.Close + Telerik.Web.UI.WindowBehaviors.Reload);
        //    //oWnd.set_height(h);
        //    //oWnd.set_width(w);
        //    //oWnd.set_top(t);
        //    //oWnd.set_left(l);
        //    //oWnd.moveTo(l, t);
        //    //oWnd.hide();
        //};
    }

    //  Notifiction pop up
    getAlertNotificationsCount() {
        let me = this;
        this.alertService.getNotificationCount().then(response => {
            if (isNaN(response.content) === false) {
                window.setTimeout(function () {
                    me.notificationCount = response.content * 1;
                }, 10);
            }
        });
    }

    getAlertNotifications() {
        let me = this;
        if (me.isGettingNotification == false) {
            me.isGettingNotification = true;
            me.alertNotificationHideAll();
            me.alertNotifications = [];
            me.alertService.getLimitedNotifications().then(response => {
                if (response && response.content) {
                    me.alertNotifications = response.content;
                }
                if (me.alertNotifications && me.alertNotifications.length > 0) {
                    //  kendo notification
                    me.alertNotifications.reverse();
                    for (var i = 0; i < me.notificationCount; i++) {
                        try {
                            if (me.alertNotifications[i]) {
                                me.notification.show({
                                    subject: me.alertNotifications[i].Subject,
                                    lastUpdated: me.formatShortDateLongTimeDisplay(me.alertNotifications[i].LastUpdated),
                                    lastUpdatedFullName: me.alertNotifications[i].LastUpdatedFullName,
                                    lastUpdatedEmployeeCode: me.alertNotifications[i].LastUpdatedEmployeeCode,
                                    priority: me.alertNotifications[i].Priority,
                                    notif: JSON.stringify(me.alertNotifications[i])
                                }, "info");
                            }
                        } catch (e) {
                            //console.log("webvantage.ts:refreshAlertNotifications:", e);
                        }
                    }
                    me.notificationsVisible = true;
                } else {
                    try {
                        me.alertNotificationHideAll();
                    } catch (e) {
                    }
                }
                me.isGettingNotification = false;
            });
        }
    }
    alertNotificationIconClick() {
        if (this.notificationsVisible === false) {
            //this.refreshAlertNotifications();
            this.getAlertNotifications();
        } else {
            this.alertNotificationHideAll();
        }
    }
    alertNotificationWindowOnClose() {
        //console.log("alertNotificationWindowOnClose");
    }
    alertNotificationHideAll() {
        if (this.notification) {
            this.notification.hide();
        }
        this.notificationsVisible = false;
    }
    alertNotificationOnShow(e) {
        let me = this;
        let element = e.element;
        if (element) {
            $(element).click(function () {
                var notif = JSON.parse(String($(element).find("#notif").val()));
                if (notif) {
                    me.alertNotificationClick(notif);
                }
            })
        }
    }
    alertNotificationClick(e) {
        let me = this;
        if (e) {
            console.log("alertNotificationClick", e);
            var sprintId = 0;
            try {
                if (!e.SprintID || e.SprintID == null || e.SprintID == undefined) {
                    sprintId = 0;
                } else {
                    sprintId = e.SprintID * 1;
                }
            } catch (e) {
                sprintId = 0;
            }
            if (e.IsWorkItem == true) {
                if (e.ConceptShareReviewID && e.ConceptShareReviewID > 0) {
                    this.openModule(e.Subject, "Alert_DigitalAssetReview.aspx?a=" + e.AlertID);
                } else {
                    this.openModule(e.Subject, "Desktop_AlertView?AlertID=" + e.AlertID + "&SprintID=" + sprintId + "&FromBoard=0");
                }
            } else {

                if (e.AlertCategoryDescription.indexOf("PO Approval") > -1) {
                    this.openModule(e.Subject, "Alert_View.aspx?AlertID=" + e.AlertID + "&openasassign=false");
                } else {
                    this.openModule(e.Subject, "Desktop_AlertView?AlertID=" + e.AlertID + "&SprintID=" + sprintId + "&FromBoard=0");
                }

                //this.openModule(e.Subject, "Desktop_AlertView?AlertID=" + e.AlertID + "&SprintID=" + sprintId + "&FromBoard=0");
            }
            this.notificationClicked = true;
        }
    }
    @bindable showActions: boolean = false;
    toggleActions() {
        this.showActions = !this.showActions;
    }
    alertNotificationMarkAllAsReadClick() {
        this.alertService.alertNotificationMarkAllAsRead().then(response => {
            //if (response && response.content) {
                this.refreshAlertNotifications();
            //}
        });
    }
    alertNotificationDismissAllAlertsClick() {
        this.alertService.alertNotificationDismissAllAlerts().then(response => {
            //if (response && response.content) {
                this.refreshAlertNotifications();
            //}
        });
    }
    refreshAlertNotifications() {
        //console.log("webvantage.ts:refreshAlertNotifications");
        this.getAlertNotificationsCount();
        this.toggleActions();
        this.refreshCurrentDashboard();
        if (this.notificationsVisible === true) {
            this.getAlertNotifications();
        }
    }

    // For refreshing dashboard from other modules; should work with Aurleia, MVC/Razor, and aspx
    // For Aurelia, if not this page, use wvbridge and the function name. If this page, you can use "this" and function name.
    // For Razor and aspx, just call the function and it should find it
    refreshCurrentDashboard() {
        try {
            let me = this;
            if (me.currentDashboard) {
                me.currentDashboard.refreshCurrentDashboard();
            }
        } catch (e) {
            //console.log("refreshCurrentDashboard error: " + e);
        }
    }
    refreshDashboardTime() {
        try {
            let me = this;
            if (me.currentDashboard) {
                me.currentDashboard.refreshDashboardTime();
            }
        } catch (e) {
            //console.log("refreshDashboardTime error: " + e);
        }
    }
    refreshDashboardAssignments() {         
        this.refreshAlertNotifications();
        try {
            let me = this;
            if (me.currentDashboard) {                
                me.currentDashboard.refreshDashboardAssignments();
            }
        } catch (e) {
            //console.log("refreshDashboardAssignments error: " + e);
        }        
        this.refreshAlertsAndAssignmentsManagerTab();

        if (this.isJobJacketOpen()) {
            this.refreshPageInsideJJ();
        } 
    }
    refreshDashboardAlerts() {           
        this.refreshAlertNotifications();
        try {
            let me = this;
            if (me.currentDashboard) {                
                me.currentDashboard.refreshDashboardAlerts();
            }
        } catch (e) {
            //console.log("refreshDashboardAlerts error: " + e);
        }
        this.refreshAlertsAndAssignmentsManagerTab();

        if (this.isJobJacketOpen()) {
            this.refreshPageInsideJJ();
        }       
    }
    isJobJacketOpen() {
        let isJobJacketOpen: boolean = false;

        let content: Application.ApplicationMenuItem;
        let jobJacket: Application.ApplicationMenuItem = new Application.ApplicationMenuItem();
        jobJacket.Page = "Content.aspx";
        content = this.OpenSecurityModules.find(function (osm) {
            return osm.Page.toUpperCase() == jobJacket.Page.toUpperCase();
        });
        if (content) {
            isJobJacketOpen = true;
        }

        return isJobJacketOpen;
    }   
    refreshDashboardAppointments() {
        try {
            let me = this;
            if (me.currentDashboard) {
                me.currentDashboard.refreshDashboardAppointments();
            }
        } catch (e) {
            //console.log("refreshDashboardAppointments error: " + e);
        }
    }
    refreshDashboardBookmarks() {
        try {
            let me = this;
            if (me.currentDashboard) {
                me.currentDashboard.refreshDashboardBookmarks();
            }
        } catch (e) {
            //console.log("refreshDashboardBookmarks error: " + e);
        }
    }
    refreshDashboardReviews() {
        try {
            let me = this;
            if (me.currentDashboard) {
                me.currentDashboard.refreshDashboardReviews();
            }
        } catch (e) {
            //console.log("refreshDashboardReviews error: " + e);
        }
    }
    refreshTimesheetTab() {
        //console.log("refreshTimesheetTab");
        try {
            let timesheetTab: Application.ApplicationMenuItem;
            let applicationMenuItem: Application.ApplicationMenuItem = new Application.ApplicationMenuItem();
            applicationMenuItem.Page = "Timesheet";
            timesheetTab = this.OpenSecurityModules.find(function (osm) {
                return osm.Page.toUpperCase() == applicationMenuItem.Page.toUpperCase();
            });
            if (timesheetTab) {
                var win;
                win = timesheetTab.Frame.contentWindow;
                if (win) {
                    win.refreshTimesheet();
                }
            }
        } catch (e) {
            //console.log("refreshTimesheetTab error: " + e);
        }
    }

    refreshAlertsAndAssignmentsManagerPMD() {           
        try {
            let alertsAndAssignmentsManagerTab: Application.ApplicationMenuItem;
            let applicationMenuItem: Application.ApplicationMenuItem = new Application.ApplicationMenuItem();
            //If the ** PMD ** is open then a refresh of the AAM is necessary.            
            applicationMenuItem.Page = "Content.aspx";
            alertsAndAssignmentsManagerTab = this.OpenSecurityModules.find(function (osm) {
                return osm.Page.toUpperCase() == applicationMenuItem.Page.toUpperCase();
            });
            if (alertsAndAssignmentsManagerTab) {
                //var contentID = 0;
                //contentID = parseInt(alertsAndAssignmentsManagerTab.Parameters["contaid"]);
                //if (contentID != 25) {
                    var win;
                    win = alertsAndAssignmentsManagerTab.Frame.contentWindow;
                    if (win) {
                        //win.refreshAlertInboxGrid();
                        win.RefreshFromAAM();
                        
                        this.refreshInboxFlag = false;
                    }
                //} else {
                //    console.log("NOT REFRESHING!");
                //}
            }
        } catch (e) {
            //console.log("refreshAlertsAndAssignmentsManagerPMD error: " + e);
        }
    }
    refreshPageInsideJJ() {
        try {
            let content: Application.ApplicationMenuItem;
            let jobJacket: Application.ApplicationMenuItem = new Application.ApplicationMenuItem();
            //If the AAM Inbox or ProjectScheduleDetail is open within the Job Jacket then a refresh is necessary.
            jobJacket.Page = "Content.aspx";
            content = this.OpenSecurityModules.find(function (osm) {                
                return osm.Page.toUpperCase() == jobJacket.Page.toUpperCase();
            });
            if (content) {
                var win;
                win = content.Frame.contentWindow[0];

                if (win.location.pathname.includes("Inbox")) {
                    if (win) {   
                        //console.log("JJAAM refreshed.")
                        win.refreshPage("parent");
                        this.refreshInboxFlag = false;
                    }                            
                }

                if (win.location.pathname.includes("ProjectScheduleDetail")) {
                    //console.log("JJPMD refreshed.")
                    //[ProjectScheduleDetail].refresPage();
                    if (win) {
                        win.refresPage();                        
                    }
                }
            }
        } catch (e) {
            //console.log("refreshTabInsideJJ error: " + e);
        }
    }    
    refreshAlertsAndAssignmentsManagerTab() {     
        try {
            let alertsAndAssignmentsManagerTab: Application.ApplicationMenuItem;
            let applicationMenuItem: Application.ApplicationMenuItem = new Application.ApplicationMenuItem();
            //If the AAM Inbox is open (as its own tab) then a refresh is necessary.
            applicationMenuItem.Page = "Inbox";
            alertsAndAssignmentsManagerTab = this.OpenSecurityModules.find(function (osm) {                 
                return osm.Page.toUpperCase() == applicationMenuItem.Page.toUpperCase();
            });
            if (alertsAndAssignmentsManagerTab) {
                var win;
                win = alertsAndAssignmentsManagerTab.Frame.contentWindow;
                if (win) {
                    //win.refreshAlertInboxGrid();
                    win.refreshPage("parent");
                    this.refreshInboxFlag = false;
                }
            }
        } catch (e) {
            //console.log("refreshAlertsAndAssignmentsManagerTab error: " + e);
        }
    }
    //refreshInboxModule(securityModule) {
    //    console.log("refreshInboxModule");
    //    if (securityModule.Frame !== undefined) {
    //        let win = securityModule.Frame.contentWindow;

    //        if (win !== 'undefined' && win !== null) {
    //            win.refreshPage("parent");
    //            this.refreshInboxFlag = false;
    //        }
    //    }
    //}
    refreshExpenseReports() {
        try {
            let me = this;
            if (me.currentPage) {
                me.currentPage.search();
            }
        } catch (e) {
            //console.log("refreshDashboardTime error: " + e);
        }
    }

    //  SignalR client functions
    refreshSprint(sprintId, sprintIsActive, sprintIsComplete, employeeName) {
        //console.log("webvantage.ts:refreshSprint", this.OpenSecurityModules);
        try {
            let item: Application.ApplicationMenuItem = null;
            let contentWindow: any;
            item = this.OpenSecurityModules.find(function (osm) {
                return osm.Page.toUpperCase() == "AGILEBOARDS";
            });
            if (item) {
                contentWindow = item.Frame.contentWindow;
                if (contentWindow) {
                    if (contentWindow.sprintId && contentWindow.sprintId == sprintId) {
                        contentWindow.pushSprintRefresh(sprintId, sprintIsActive, sprintIsComplete, employeeName);
                    }
                }
            }
            item = null;
            item = this.OpenSecurityModules.find(function (osm) {
                return osm.Page.toUpperCase() == "CONTENT.ASPX";
            });
            if (item) {
                if (item.Frame.contentWindow[0]) {
                    let frameContentWindow: any;
                    frameContentWindow = item.Frame.contentWindow[0];
                    if (frameContentWindow) {
                        if (frameContentWindow.sprintId == sprintId) {
                            frameContentWindow.pushSprintRefresh(sprintId, sprintIsActive, sprintIsComplete, employeeName);
                        }
                    }
                }
            }
        } catch (e) {
        }
    }
    refreshNewAlertView(alertId, sprintId, employeeName) {
        //console.log("webvantage.ts:refreshNewAlertView");
        this.refreshAssignmentTab(alertId, sprintId, employeeName, 0);
    }
    refreshAlertComments(alertId, employeeName) {
        //console.log("webvantage.ts:refreshAlertComments");
        this.refreshAssignmentTab(alertId, 0, employeeName, 1);
        this.refreshAlerts();
    }
    refreshAlertChecklists(alertId, employeeName) {
        //console.log("webvantage.ts:refreshAlertChecklists");
        this.refreshAssignmentTab(alertId, 0, employeeName, 2);
    }
    refreshAlertAssigneesAndCCs(alertId, employeeName) {
        //console.log("webvantage.ts:refreshAlertAssigneesAndCCs");
        this.refreshAssignmentTab(alertId, 0, employeeName, 3);
    }
    refreshAlertHours(alertId, employeeName) {
        //console.log("webvantage.ts:refreshAlertHours");
        this.refreshAssignmentTab(alertId, 0, employeeName, 4);
    }
    refreshAssignmentTab(alertId, sprintId, employeeName, updateType) {
        //console.log("webvantage.ts:refreshAssignmentTab");
        for (var i = 0; i < this.OpenSecurityModules.length; i++) {
            if (this.OpenSecurityModules[i].Page == "Desktop_AlertView") {
                if (this.OpenSecurityModules[i].Url.includes("AlertID=" + alertId) == true || this.OpenSecurityModules[i].Url.includes("a=" + alertId) == true) {
                    let contentWindow: any;
                    contentWindow = this.OpenSecurityModules[i].Frame.contentWindow;
                    if (contentWindow) {
                        try {
                            contentWindow.MvcRefreshNewAlertViewBridge(alertId, sprintId, employeeName, updateType);
                        } catch (e) {
                            //console.log("refreshAssignmentTab:error", e);
                        }
                    }
                    break;
                }
            }
        }
    }

    refreshDashboardWorkItems() {
        //console.log("webvantage.ts:refreshDashboardWorkItems");
        this.refreshAlertNotifications();
        //this.refreshDashboardAssignments();
    }
    refreshMyAssignmentsNotificationsAndCounts() {
    //    try {
    //        //console.log("webvantage.ts:refreshMyAssignmentsNotificationsAndCounts");
    //    } catch (e) {
    //        //console.log("refreshMyAssignmentsNotificationsAndCounts:error:", e);
    //    }
    }
    refreshAlerts() {
        //console.log("webvantage.ts:refreshAlerts");
        this.refreshAlertNotifications();
        //try {
        //    let me = this;
        //    if (me.currentDashboard) {
        //        me.currentDashboard.refreshAlerts();
        //    }
        //} catch (e) {
        //    //console.log("refreshAlerts error: " + e);
        //}
    }
    messageUser(userCode, message) {
        //console.log("messageUser webvantage.ts");
        let dialog = $('<div></div>').appendTo(document.body);
        let kAlert: kendo.ui.Alert;
        let options: any = {
            buttonLayout: 'normal',
            title: false,
            content: message,
            close: function (e) {
                kAlert.wrapper.remove();
            }
        };
        kAlert = dialog.kendoAlert(options).data('kendoAlert');
        kAlert.open();
    }

    RefreshChildPageGrid(page: string) {
        var applicationMenuItem;

        applicationMenuItem = this.OpenSecurityModules[this.FindWindow(page)];

        applicationMenuItem.Frame.RebindGrid();
    }
    FindWindow(page: string) {
        let applicationMenuItem: Application.ApplicationMenuItem = new Application.ApplicationMenuItem();

        applicationMenuItem.Page = page;

        return this.findModule(applicationMenuItem);
    }
    openHelp() {
        //opens help page
    }

    OpenChatWindow(chatURL) {
        var me = this;

        var applicationMenuItem: Application.ApplicationMenuItem;

        applicationMenuItem = this.FindChatWindow(chatURL);
        if (applicationMenuItem) {
            this.selectModule(applicationMenuItem);
        }
        else {
            me.OpenNewChatWindow(chatURL);
        }

        //if (chatEnabled && chatEnabled == true && chatURL) {
        //    var chatWindow;
        //    chatWindow = FindChatWindow(chatURL);
        //    if (chatWindow) {
        //        chatWindow.show();
        //        chatWindow.restore();
        //    } else {
        //        OpenNewChatWindow(chatURL);
        //    }
        //}
    }
    FindChatWindow(chatURL) {
        let applicationMenuItem: Application.ApplicationMenuItem = new Application.ApplicationMenuItem();

        applicationMenuItem.Url = chatURL;
        applicationMenuItem.Page = this.getPage(chatURL);

        return this.OpenSecurityModules[this.findModule(applicationMenuItem)];
    }
    OpenNewChatWindow(chatURL) {
        var me = this;

        me.openModule('Chat Room', chatURL);

        //if (chatEnabled && chatEnabled == true && chatURL) {
        //    var mainContentHeight = $("#maincontent").height();
        //    var mainContentWidth = $("#maincontent").width();
        //    var w = 840;
        //    var h = 555;
        //    var t = 0;
        //    var l = 0;
        //    var buffer = 5;
        //    t = mainContentHeight - h - buffer;
        //    l = mainContentWidth - w - buffer;
        //    var oWnd = manager.open(chatURL, '', null, w, h);
        //    oWnd.set_destroyOnClose(true);
        //    oWnd.set_title('Chat Room');
        //    oWnd.set_iconUrl('Images/blank.ico');
        //    oWnd.set_behaviors(Telerik.Web.UI.WindowBehaviors.Close + Telerik.Web.UI.WindowBehaviors.Move + Telerik.Web.UI.WindowBehaviors.Minimize + Telerik.Web.UI.WindowBehaviors.Resize);
        //    oWnd.set_height(h);
        //    oWnd.set_width(w);
        //} else {
        //    alert("No chat url");
        //}
    }

    dragStart(e, index) {
        e.dataTransfer.setData("text", index);

        return true;
    }
    dragDrop(e, index) {
        e.preventDefault();
        e.target.style.opacity = '';
        var data = e.dataTransfer.getData("text");

        this.move(this.OpenSecurityModules, data, index);
        this.selectModule(this.OpenSecurityModules[index]);

        return true;
    }
    dragLeave(e) {
        e.target.style.opacity = '';
    }
    dragOver(e) {
        e.preventDefault();

        e.target.style.opacity = .3;

        return true;
    }
    move(arr, old_index, new_index) {
        while (old_index < 0) {
            old_index += arr.length;
        }
        while (new_index < 0) {
            new_index += arr.length;
        }
        if (new_index >= arr.length) {
            var k = new_index - arr.length;
            while ((k--) + 1) {
                arr.push(undefined);
            }
        }
        arr.splice(new_index, 0, arr.splice(old_index, 1)[0]);
        return arr;
    }

    stopwatchDateString: string = "";
    stopwatchServerTime: any;
    stopwatchDescription: string = "";
    stopwatchCommentsRequired: boolean;
    stopwatchHasComments: boolean;
    checkForStopwatch() {
        this.alertService.hasStopwatch(this.employee.Code).then(response => {
            if (response.content) {
                this.stopwatch = response.content.StopwatchIsRunning;
                this.stopwatchCommentsRequired = response.content.CommentsRequired;
                this.stopwatchDateString = response.content.DateString;
                this.stopwatchDescription = response.content.Description;
                this.stopwatchHasComments = response.content.HasComments;
                this.stopwatchServerTime = response.content.ServerTime;
            }
        });
    }
    stopStopWatch() {
        this.alertService.stopStopwatch(this.employee.Code).then(response => {
            if (response.content.Success === true) {
                this.stopwatch = false;
                //console.log("HSW " + this.stopwatch);
                //wvbridge.OpenStopwatchNotify();
                //this.webvantage.OpenDialog("Timesheet Stopwatch", "Timesheet_Stopwatch.aspx", 475, 500);
                this.refreshTimesheetTab();
            } else if (response.content.Message) {
                this.alert(response.content.Message);
                this.OpenDialog("Timesheet Stopwatch", "Timesheet_Stopwatch.aspx", 475, 500);
            }
        });

    }
    openStopWatchDialog() {
        this.OpenDialog("Stopwatch", "Timesheet_Stopwatch.aspx", 350, 520);
    }

    testFunction() {
        //console.log("webvantage.ts:testFunction");
    }
    alert(message: string): void {

        let dialog = $('<div></div>').appendTo(document.body);
        let kAlert: kendo.ui.Alert;

        let options: any = {
            buttonLayout: 'normal',
            title: false,
            content: message,
            close: function (e) {
                kAlert.wrapper.remove();
            }
        };

        kAlert = dialog.kendoAlert(options).data('kendoAlert');

        kAlert.open();

    }

    checkForEmailLinkOrDeepLink() {
        let me = this;
        try {
            if (window.location.search) {
                var s = window.location.search;
                var page = "";
                if (!me.OpenSecurityModules || me.OpenSecurityModules.length == 0) {
                    me.OpenSecurityModules = [];
                }
                if (s.indexOf("?link=") > -1) {
                    page = s.replace("?link=", "").replace("$", "?");
                    if (page.indexOf("Alert_View.aspx") > -1) {
                        let secModule = new Application.ApplicationMenuItem;
                        secModule.Text = "Alert";
                        secModule.Url = page + "&tabLoaded=1";
                        secModule.Parameters = me.parseURLParams(page.substring(page.indexOf('?') + 1));
                        secModule.Active = true;
                        window.setTimeout(function () {
                            me.openApplication(secModule);
                        }, 100);
                    } else if (page.indexOf("Desktop_AlertView") > -1) {
                        let secModule = new Application.ApplicationMenuItem;
                        secModule.Text = "Assignment";
                        secModule.Url = page + "&tabLoaded=1";
                        secModule.Parameters = me.parseURLParams(page.substring(page.indexOf('?') + 1));
                        secModule.Active = true;
                        window.setTimeout(function () {
                            me.openApplication(secModule);
                        }, 100);
                    } else {
                        me.openDashboardOnActivate();
                    }
                } else if (s.indexOf("?dl=") > -1) {
                    var link = s.replace("?dl=", "");
                    if (link) {
                        //console.log("checkForEmailLinkOrDeepLink:link", link);
                        me.service.decryptDeepLink(link).then(response => {
                            if (response && response.content) {
                                var u = "";
                                u = response.content;
                                if (u) {
                                    try {
                                        let sm = new Application.ApplicationMenuItem;
                                        if (u.indexOf("Alert_View.aspx") > -1 || u.indexOf("Desktop_Alert") > -1) {
                                            if (u.indexOf("Alert_View.aspx") > -1) {
                                                sm.Text = "Alert";
                                                sm.Url = "Alert_View.aspx?" + u.substring(u.indexOf('?') + 1);
                                            }
                                            if (u.indexOf("Desktop_AlertView") > -1) {
                                                sm.Text = "Assignment";
                                                sm.Url = "Desktop_AlertView?" + u.substring(u.indexOf('?') + 1);
                                            }
                                            if (sm.Url.indexOf("tabLoaded=1") == -1) {
                                                sm.Url = sm.Url + "&tabLoaded=1";
                                            }
                                            sm.Parameters = this.parseURLParams(u.substring(u.indexOf('?') + 1));
                                            sm.Active = true;
                                            if (sm.Url && sm.Url.length > 0) {
                                                me.openApplication(sm);
                                            } else {
                                                me.openDashboardOnActivate();
                                            }
                                        } else {
                                            sm.Text = "";
                                            var urlHasDate = false;
                                            if (u.indexOf("Alert_DigitalAssetReview") > -1) {
                                                sm.Text = "Review";
                                            }
                                            if (u.indexOf("SupervisorApproval_Expense") > -1) {
                                                sm.Text = "Expense Approval";
                                            }
                                            sm.Url = u; //u.substr(0, u.lastIndexOf("?"));
                                            if (urlHasDate == false) {
                                            }
                                            sm.Parameters = this.parseURLParams(u.substring(u.indexOf('?') + 1));
                                            sm.Active = true;
                                            if (sm.Url && sm.Url.length > 0) {
                                                me.openApplication(sm);
                                            } else {
                                                me.openDashboardOnActivate();
                                            }
                                        }
                                    } catch (e) {
                                        //me.openDashboardOnActivate();
                                    }
                                }
                            }
                        });
                    }
                } else {
                    me.openDashboardOnActivate();
                }
            } else {
                me.openDashboardOnActivate();
            }
        } catch (e) {
            me.openDashboardOnActivate();
        }
    }
    loadSettings() {
        let me = this;
        return this.serviceUser.loadSettings().then(response => {

            this.settings = response.content;

            me.showdb = this.settings.ShowDatabaseName;

        });
    }


    activate() {
        let me = this;
        return this.service.applicationInit().then(app => {

            this.mainMenuItems = app.MainMenuItems;

            me.checkForEmailLinkOrDeepLink()

            // use below to add module to menu & auto open -- testing only
            //this.addModuleForTest('Campaign Periods', 'modules/project-management/campaigns/campaign-periods', true);

            this.quickAccessMenuItems = app.QuickAccessMenuItems;
            this.productivityMenuItems = app.ProductivityMenuItems;
            this.searchMenuItems = app.SearchMenuItems;
            this.employee = app.Employee;
            this.isClientPortal = app.IsClientPortal;
            this.DatabaseName = app.DatabaseName;

            this.GetBookmarks();
            this.getAlertNotificationsCount();
            this.checkForStopwatch();
            this.loadSettings();

            //let eventAggregatorSubscription = this.eventAggregator.subscribe("webvantage", response => {
            //    //console.log("webvantage.ts:refreshSubscription", response);
            //    if (response == "refreshDashboardTime") {
            //        this.refreshDashboardTime();
            //    } else if (response == "refreshDashboardAssignments") {
            //        this.refreshDashboardAssignments();
            //    } else if (response == "refreshDashboardAlerts") {
            //        this.refreshDashboardAlerts();
            //    } else if (response == "testFunction") {
            //        this.testFunction();
            //    }
            //});

            $(document).ready(function () {
                //$(document).one("kendo:pageUnload", function () { if (notification) { notification.hide(); } });
                //$("#notification").kendoNotification({
                //    animation: false
                //});
            });
        });
    }

    constructor(service: ApplicationService, dialogService: DialogService, container: Container, BrowserWindow: browserWindow, alertService: AlertService, sessionTimeout: SessionTimeout, eventAggregator: EventAggregator, serviceUser: UserSettingService) {

        super();

        this.service = service;
        this.eventAggregator = eventAggregator;
        this.dialogService = dialogService;
        this.BrowserWindow = BrowserWindow;
        this.alertService = alertService;
        this.sessionTimeout = sessionTimeout;
        this.serviceUser = serviceUser;

        container.registerInstance('openModule', this.openModule.bind(this));
        container.registerInstance('closeModule', this.closeModule.bind(this));
        container.registerInstance('openDialog', this.openDialog.bind(this));
        container.registerInstance('RefreshWindow', this.RefreshWindow.bind(this));
        //this.OpenSecurityModules = [{ Text: 'Dashboard', ViewModel: 'modules/dashboard/sample-dashboard' }];
        //this.selectModule(this.OpenSecurityModules[0]);
        //this.selectedSideMenu = 'Bookmarks';

        sessionTimeout.extendTimeout();
    }

}
