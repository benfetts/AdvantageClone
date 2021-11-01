import { IframeDialog } from 'modules/utilities/iframe-dialog';
import { Application } from 'models/common/application';
import { Webvantage } from '../../webvantage'


export class browserWindow {
    Frame: HTMLIFrameElement;
    Dialog: any;
    Parent: any;
    webvantage: Webvantage;
    CloseDialog: any = null;

    OpenRadWindow(title: string, url: string, width: number, height: number, DialogCallback?: any, param?: any) {
        this.webvantage.OpenRadWindow(title, url, width, height, DialogCallback, param);
    }

    OpenRadWindowUpdate(title: string, url: string, newurl: string) {
        this.webvantage.OpenRadWindowUpdate(title, url, newurl);
    }

    OpenDialog(title: string, url: string, height: number, width: number) {
        let me = this;
        let Dialog = $("#dialogDiv");

        if (typeof Dialog !== 'undefined' && Dialog.length) {
            $("#dialogDiv").remove();
            Dialog = $('<div id="dialogDiv"></div>');
        }
        else {
            Dialog = $('<div id="dialogDiv"></div>');
        }

        var lheight = height;
        var lwidth = width;

        if (lheight == 0) lheight = 750;
        if (lwidth == 0) lwidth = 700;

        Dialog.ejDialog({
            autoOpen: false,
            modal: true,
            height: lheight,
            width: lwidth,
            title: title,
            enableResize: true,
            contentUrl: url,
            contentType: 'iframe'
        });

        Dialog.data('parentFrame', me.Frame);

        Dialog[0].ownerDocument.getElementsByClassName('e-iframe')[0].ownerDocument['GetRadWindow'] = function () {
            //let BrowserWindow = new browserWindow();

//            var foo: browserWindow = Object.getPrototypeOf(BrowserWindow);

            //BrowserWindow.Parent = me;
            //BrowserWindow.Frame = <HTMLIFrameElement>Dialog[0].ownerDocument.getElementsByClassName('e-iframe')[0];
            //this.Dialog = Dialog;


            return {
                BrowserWindow: this
            };
        }
    }

    OpenRadWindowLookup(WindowURL: string) {
        let parameters: Array<any>;
        var Title = '';
        let me = this;

        parameters = this.webvantage.parseURLParams(WindowURL.substring(WindowURL.indexOf('?') + 1));
        console.log(parameters['type']);

        switch (parameters['type']) {
            case 'coopbilling':
                Title = " Coop Billing Code";
                break;
            case 'campaign2':
                Title = " Campaign";
                break;
            case 'salesclass':
                Title = " Sales Class"
                break;
            case 'contacts':
                Title = " Contact"
                break;
            case 'jobtype':
                Title = " Job Type"
                break;
            case 'accountexec':
                Title = " Account Executive"
                break;
        }

        var Dialog = $("#LookUpDlgDiv");

        if (typeof Dialog !== 'undefined' && Dialog.length) {
            $("#LookUpDlgDiv").remove();
            Dialog = $('<div id="LookUpDlgDiv"></div>');
        }
        else {
            Dialog = $('<div id="LookUpDlgDiv"></div>');
        }


        Dialog.ejDialog({
            autoOpen: false,
            modal: true,
            height: 700,
            width: 625,
            title: "Lookup" + Title,
            enableResize: true,
            contentUrl: WindowURL,
            contentType: 'iframe'
        });

        Dialog.data('parentFrame', me.Frame);

        Dialog[0].ownerDocument.getElementsByClassName('e-iframe')[0].ownerDocument['GetRadWindow'] = function () {
            var dlgBrowserWindow = {
                parameters: parameters,
                Frame: me.Frame,
                Close: function (controlsToSet: string) {
                    var dlgDiv = $("#LookUpDlgDiv");
                    var dlgParentFrame = dlgDiv.data('parentFrame');
                    var doc = dlgParentFrame.contentDocument ? dlgParentFrame.contentDocument : dlgParentFrame.contentWindow.document;
                    var CallingWindowContent = dlgParentFrame.contentWindow;
                    controlsToSet = controlsToSet.split('CallingWindowContent.document').join('doc');
                    try {
                        eval(controlsToSet);
                    } catch (e) {
                        var frame = doc.getElementById('ctl00_ContentPlaceHolderMain_IFrameContent');

                        doc = (<HTMLIFrameElement>frame).contentDocument ? (<HTMLIFrameElement>frame).contentDocument : (<HTMLIFrameElement>frame).contentWindow.document;

                        eval(controlsToSet);
                    }
                    Dialog.ejDialog('close');
                    return;
                },
                Cancel: function () {
                    Dialog.ejDialog('close');
                    return;
                },
                ClientSetAutoCompleteEntries: function (emps) {
                    var dlgDiv = $("#LookUpDlgDiv");
                    var dlgParentFrame = dlgDiv.data('parentFrame');
                    var CallingWindowContent = dlgParentFrame.contentWindow;
                    CallingWindowContent.ClientSetAutoCompleteEntries(emps);
                    Dialog.ejDialog('close');
                    return;
                },
                ShowMessage: function (message: string) {
                    console.log("ShowMessage browserWindow.ts 1");
                    message = message.replace("\n", "<br/>");
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
            }
            return {
                BrowserWindow: dlgBrowserWindow
            };
        }
    }

    ShowMessage(message: string, title?: any) {
        message = this.webvantage.javaScriptCommentToHTML(message);
        title = this.webvantage.checkForTitle(title);
        let dialog = $('<div></div>').appendTo(document.body);
        let kAlert: kendo.ui.Alert;
        let options: any = {
            buttonLayout: 'normal',
            title: title,
            content: message,
            close: function (e) {
                kAlert.wrapper.remove();
            }
        };
        kAlert = dialog.kendoAlert(options).data('kendoAlert');
        kAlert.open();
    }
    RadToolBarConfirm(sender: any, args: any, message: string, title?: any): JQueryPromise<any> {
        args.set_cancel(true);
        //var commandName = args.get_item().get_commandName();
        var postBackReference = sender._postBackReference;
        return this._ShowKendoConfirm(message, title);
    }
    ShowKendoConfirm(message: string, title?: any): JQueryPromise<any> {
        return this._ShowKendoConfirm(message, title);
    }
    _ShowKendoConfirm(message: string, title?: any): JQueryPromise<any> {
        message = message.replace("\n", "<br/>");
        title = this.webvantage.checkForTitle(title);
        if (!message || message == "") {
            message = "Are you sure?";
        } else {
            message = this.webvantage.javaScriptCommentToHTML(message);
        }
        let dialog = $('<div></div>').appendTo(document.body);
        let kConfirm: kendo.ui.Confirm;
        let options: any = {
            buttonLayout: 'normal',
            title: title,
            content: message,
            close: function (e) {
                kConfirm.wrapper.remove();
            }
        };
        kConfirm = dialog.kendoConfirm(options).data('kendoConfirm');
        kConfirm.open();
        return kConfirm.result;
    }

    HideAlertNotify() {
        this.webvantage.closeModule(this.webvantage.OpenSecurityModules[this.webvantage.FindWindow('Alert_Notification.aspx')]);
        this.webvantage.alertNotificationHideAll();
    }

    CallPrintSendPageSilently(URL) {
        console.log('CallPrintSendPageSilently');

        var iframe = document.createElement('iframe');
        iframe.src = URL;
        document.body.appendChild(iframe);

        //me.OpenRadWindow("", URL, 0, 0);
    }

    RefreshParentPage(parent) {
        alert('RefreshParentPage not implemented');
    }

    RefreshDashboardReviews() {
        //alert('RefreshDashboardReviews not implemented');
        this.refreshDashboardReviews();
    }

    ShowProgress(toggle: boolean): void {
        
        this.webvantage.ShowProgress(toggle);

    }

    RefreshWindow(WindowURL, ForceNewURL, OpenWindowIfNotFound) {
        this.webvantage.RefreshWindow(WindowURL, ForceNewURL, OpenWindowIfNotFound);
        //console.log('RefreshWindow');
        //var secModule = new Application.ApplicationMenuItem;
        //var index: number = -1;
        //var frame: HTMLIFrameElement;
        //secModule.Url = WindowURL;
        //secModule.Parameters = this.webvantage.parseURLParams(WindowURL.substring(WindowURL.indexOf('?') + 1));
        //secModule.Page = this.webvantage.getPage(secModule.Url);
        //index = this.webvantage.findModule(secModule);
        //if (index > -1) {
        //    frame = this.webvantage.OpenSecurityModules[index].Frame;
        //    if (frame) {
        //        var contentWindow = null;
        //        contentWindow = frame.contentWindow;
        //        if (contentWindow) {
        //            contentWindow.RefreshPage();
        //        } else {
        //            console.log("browserWindow.ts:RefreshWindow:No content window");
        //        }
        //    } else {
        //        console.log("browserWindow.ts:RefreshWindow:No frame");
        //    }
        //}
        //else {
        //    //console.log('page not found');
        //    if (OpenWindowIfNotFound) {
        //        this.webvantage.OpenRadWindow('', WindowURL, 0, 0);
        //    }
        //}
    }

    RefreshInOutBoardObjects(CurrentObjectName) {
        //alert('RefreshInOutBoardObjects not implemented');
        //if (CurrentObjectName != 'DesktopInOutBoard') {
        this.RefreshDesktopObjectGrid('DesktopInOutBoard.ascx');
        //};
        //if (CurrentObjectName != 'DesktopInOutBoardAll') {
        this.RefreshDesktopObjectGrid('DesktopInOutBoardAll.ascx');
        //};
    }

    RefreshJobRequestObjects(CurrentObjectName) {
        //alert('RefreshInOutBoardObjects not implemented');
    }

    RefreshBookmarksDTO() {
        console.log('RefreshBookmarksDTO');

        this.RefreshWindow('dashboard', false, false);

    }

    RefreshAlertRecipients() {
        alert('RefreshAlertRecipients not implemented');
    }

    RefreshAlertWindows(updateAlertDO, updateAlertInbox, updateCards) {
        //Handled by SignalR
        //console.log("RefreshAlertWindows");
        //this.webvantage.OpenAlertNotifiy();
        //this.refreshDashboardAlerts();
        //if (updateAlertInbox) {
        //    this.RefreshWindow("Alert_Inbox.aspx", false, false);
        //}
    }

    RefreshAlertsDTO() {
        alert('RefreshAlertRecipients not implemented');
    }

    OnAlertNotificationClose() {
        //alert('OnAlertNotificationClose not implemented');
    }

    // For refreshing dashboard from other modules; should work with Aurleia, MVC/Razor, and aspx
    refreshCurrentDashboard() {
        this.webvantage.refreshCurrentDashboard();
    }
    refreshDashboardTime() {
        this.webvantage.refreshDashboardTime();
    }
    refreshDashboardAssignments() {
        this.webvantage.refreshDashboardAssignments();
    }
    refreshDashboardAlerts() {
        this.webvantage.refreshDashboardAlerts();
    }
    refreshDashboardAppointments() {
        this.webvantage.refreshDashboardAppointments();
    }
    refreshDashboardBookmarks() {
        this.webvantage.refreshDashboardBookmarks();
    }
    refreshDashboardReviews() {
        this.webvantage.refreshDashboardReviews();
    }
    refreshAlertNotifications() {
        this.webvantage.refreshAlertNotifications();
    }
    refreshAlertsAndAssignmentsManagerPMD() {
        this.webvantage.refreshAlertsAndAssignmentsManagerPMD();
    }
    checkForStopwatch() {
        this.webvantage.checkForStopwatch();
    }
    refreshTimesheetTab() {
        this.webvantage.refreshTimesheetTab();
    }
    openStopWatchDialog() {
        this.webvantage.openStopWatchDialog();
    }

    refreshExpenseReports() {
        this.webvantage.refreshExpenseReports();
    }
    //  SignalR client functions
    refreshSprint(sprintId, sprintIsActive, sprintIsComplete, employeeName) {
        this.webvantage.refreshSprint(sprintId, sprintIsActive, sprintIsComplete, employeeName);
    }
    refreshNewAlertView(alertId, sprintId, employeeName) {
        this.webvantage.refreshNewAlertView(alertId, sprintId, employeeName);
    }
    refreshDashboardWorkItems() {
        this.webvantage.refreshDashboardWorkItems();
    }
    refreshMyAssignmentsNotificationsAndCounts() {
        this.webvantage.refreshMyAssignmentsNotificationsAndCounts();
    }
    refreshAlerts() {
        this.webvantage.refreshAlerts();
    }
    refreshAlertComments(alertId, employeeName) {
        this.webvantage.refreshAlertComments(alertId, employeeName);
    }
    refreshAlertChecklists(alertId, employeeName) {
        this.webvantage.refreshAlertChecklists(alertId, employeeName);
    }
    refreshAlertAssigneesAndCCs(alertId, employeeName) {
        this.webvantage.refreshAlertAssigneesAndCCs(alertId, employeeName);
    }
    refreshAlertHours(alertId, employeeName) {
        this.webvantage.refreshAlertHours(alertId, employeeName);
    }
    refreshAssignmentTab(alertId, sprintId, employeeName, updateType) {
        this.webvantage.refreshAssignmentTab(alertId, sprintId, employeeName, updateType);
    }

    RefreshTimesheetWindows() {
        console.log('RefreshTimesheetWindows browserWindow.ts');
        //this.RefreshChildPageGrid('Timesheet.aspx');
    }

    messageUser(userCode, message) {
        this.webvantage.messageUser(userCode, message);
    }

    RefreshTimesheetDTO() {
        console.log('RefreshTimesheetDTO');

        this.RefreshDesktopObjectGrid('DesktopTimesheet.ascx');
        this.RefreshDesktopObjectGrid('DesktopWeeklyTimegraph.ascx');
    }

    RefreshProjectScheduleGrid() {
        console.log('RefreshProjectScheduleGrid not implemented');
    }

    RefreshTasks() {
        //alert('RefreshTasks not implemented');
    }

    RedirectParentPage(newUrl, parent) {
        alert('RedirectParentPage not implemented');
    }

    BillingApprovalBatchCreated() {
        console.log('BillingApprovalBatchCreated');

        this.webvantage.RefreshChildPageGrid("BillingApproval_View.aspx");
        this.webvantage.RefreshChildPageGrid("BillingApproval_View_Approvals.aspx");
    }

    sessionEnded() {
        alert('sessionEnded not implemented');
    }

    CalendarSync(EmployeeNonTaskId, IsHoliday, IsDeleting) {
        console.log('CalendarSync');

        var enti = "1=";
        var ih = "&2=";
        var id = "&3=";
        enti = enti + EmployeeNonTaskId;
        ih = ih + IsHoliday;
        id = id + IsDeleting;
        this.webvantage.CallUiAction(16, "", enti + ih + id);
    }

    SendEmail(guid) {
        console.log('SendEmail');
        this.webvantage.CallUiAction(17, guid, "");
    }

    CheckForAsyncMessage() {
        console.log('CheckForAsyncMessage');
        this.webvantage.CallUiAction(18, "", "");
    }

    CallFunctionOnParentPage(fnName) {
        alert('CallFunctionOnParentPage not implemented');
    }

    OpenChatWindow(chatURL) {
        console.log('OpenChatWindow')
        this.webvantage.OpenChatWindow(chatURL)
    }
    FindChatWindow(chatURL) {
        alert('FindChatWindow not implemented');
    }

    RestoreChatWindow(chatURL) {
        alert('RestoreChatWindow not implemented');
    }

    ReviewGenerateFeedbackSummary(projectId, reviewId) {
        console.log('ReviewGenerateFeedbackSummary');

        if (projectId && reviewId) {
            var review = "reviewId=" + reviewId;
            this.webvantage.CallUiAction(27, projectId, review);
        }
    }

    CallUiAction(actionId, extraQS) {
        alert('CallUiAction not implemented');
        //me.CallUiAction(actionId, extraQS);
    }

    MarkAllEmailAsRead() {
        console.log('MarkAllEmailAsRead');

        this.webvantage.CallUiAction(3, "", "");
    }

    OpenFloatingWindow(WindowTitle, WindowURL, WindowHeight, WindowWidth, WindowTop, WindowLeft) {
        if (typeof WindowURL == 'undefined') {
            alert('No page to navigate');
            return false;
        };
        if (typeof WindowTitle == 'undefined') {
            WindowTitle = '';
        };
        if (typeof WindowHeight == 'undefined') {
            WindowHeight = 0;
        };
        if (typeof WindowWidth == 'undefined') {
            WindowWidth = 0;
        };
        if (typeof WindowTop == 'undefined') {
            WindowTop = 0;
        };
        if (typeof WindowLeft == 'undefined') {
            WindowLeft = 0;
        };
        var params = '';
        params += 'width=' + WindowWidth;
        params += ', height=' + WindowHeight;
        params += ', top=' + WindowTop;
        params += ', left=' + WindowLeft;
        params += ', directories=no';
        params += ', location=no';
        params += ', menubar=no';
        params += ', scrollbars=yes';
        params += ', status=no';
        params += ', toolbar=no';
        var newwin = window.open(WindowURL, WindowTitle, params);
        if (window.focus && newwin) {
            setTimeout(function () {
                newwin.focus();
            }, 1);
        };
        return false;
    }

    GetDocumentRepositoryDocument(DocumentId) {
        let url: string = "";
        url = 'UI_Action.aspx?action=11&val=' + DocumentId;

        var link = document.createElement("a");
        link.download = name;
        link.href = url;
        document.body.appendChild(link);
        link.click();
        document.body.removeChild(link);
    }

    ShowPleaseWait() {
        alert('ShowPleaseWait not implemented');
    }

    HidePleaseWait() {
        alert('HidePleaseWait not implemented');
    }

    RadAsyncUploadOnClientValidationFailed(sender, args) {
        alert('RadAsyncUploadOnClientValidationFailed not implemented');
    }

    extendTimeout() {
        //console.log('extend timeout');
        this.webvantage.extendSession();
    }

    closePanel() {
        alert('closePanel not implemented');
    }

    CloseAlertView(AlertID : number) {
        this.webvantage.CloseAlertView(AlertID);
    }

    closeWindow() {

        var AMI = $(this.Parent.frame).data("myAMI");

        if (typeof (AMI) != "undefined") {
            this.Parent.closeModule(AMI);
        }
        else {
            if (this.Parent.Parent) {
                this.Parent.Parent.controller.close(true);
            }
            else {
                this.Parent.controller.close(true);
            }
        }

    }

    close(controlsToSet: string) {

        var dlgDiv = $("#dialogDiv");
        var dlgParentFrame = dlgDiv.data('parentFrame');
        var doc = dlgParentFrame.contentDocument ? dlgParentFrame.contentDocument : dlgParentFrame.contentWindow.document;
        var CallingWindowContent = dlgParentFrame.contentWindow;

        controlsToSet = controlsToSet.split('CallingWindowContent.document').join('doc');
        try {
            eval(controlsToSet);
        }
        catch (e) {
            var frame = doc.getElementById('ctl00_ContentPlaceHolderMain_IFrameContent');

            doc = (<HTMLIFrameElement>frame).contentDocument ? (<HTMLIFrameElement>frame).contentDocument : (<HTMLIFrameElement>frame).contentWindow.document;

            eval(controlsToSet);
        }

        this.closeWindow();
        //this.Parent.controller.close(true);
    }

    RefreshDesktopObjectGrid(UserControlName) {
        //SetObjects();
        var applicationMenuItem = null;

        applicationMenuItem = this.webvantage.OpenSecurityModules.find(o => o.Page = UserControlName);

        if (applicationMenuItem !== null) {
            applicationMenuItem.Frame.contentWindow.RebindGrid();
        }
    }

    RefreshChildPageGrid(PageName) {
        //wet
        console.log('RefreshChildPageGrid');
        //SetObjects();
        var applicationMenuItem = null;

        applicationMenuItem = this.webvantage.OpenSecurityModules.find(o => o.Page = PageName);

        if (applicationMenuItem !== null && typeof applicationMenuItem.Frame !== 'undefined') {
            applicationMenuItem.Frame.contentWindow.RebindGrid();
        }
    }

    RefreshAlertInbox() {
        console.log("RefreshAlertInbox")
        this.RefreshChildPageGrid('Alert_Inbox.aspx');
    }

    RefreshJobRequest() {
        console.log("RefreshJobRequest")
        this.RefreshChildPageGrid('JobRequest_Search.aspx');
    }

    RebindGrid() {
        console.log("RefreshAlertInbox")
    }

    ShowAlertNotify() {
        this.webvantage.refreshAlertNotifications();
    }

    CloseLookupAdNumber(controlsToSet: string) {
        var dlgParentFrame = this.webvantage.GetActive().Frame;
        var doc = dlgParentFrame.contentDocument ? dlgParentFrame.contentDocument : dlgParentFrame.contentWindow.document;
        var CallingWindowContent = dlgParentFrame.contentWindow;

        controlsToSet = controlsToSet.split('CallingWindowContent.document').join('doc');
        try {
            eval(controlsToSet);
        }
        catch (e) {
            var frame = doc.getElementById('ctl00_ContentPlaceHolderMain_IFrameContent');

            doc = (<HTMLIFrameElement>frame).contentDocument ? (<HTMLIFrameElement>frame).contentDocument : (<HTMLIFrameElement>frame).contentWindow.document;

            eval(controlsToSet);
        }

        this.closeWindow();
    }

    constructor() {
    }
}
