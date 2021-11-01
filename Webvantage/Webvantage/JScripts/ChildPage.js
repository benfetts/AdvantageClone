function GetRadWindow() {
    var oWindow = null;
    if (window.radWindow) {
        oWindow = window.radWindow;
    }
    else if (window.frameElement && window.frameElement.radWindow) {
        oWindow = window.frameElement.radWindow;
    }
    else if (typeof window.document.GetRadWindow === 'function') {
        oWindow = window.document.GetRadWindow();
    }
    else if (window.frameElement && window.frameElement.ownerDocument.GetRadWindow) {
        oWindow = window.frameElement.ownerDocument.GetRadWindow();
    }

    if (oWindow == undefined) {
        var iFrame = window.frameElement;
        if (window.parent.frameElement) {
            if (window.parent.frameElement.radWindow) {
                oWindow = window.parent.frameElement.radWindow;
            }
        }

    }
    if (oWindow == undefined) {
        oWindow = window.top;
    }
    return oWindow;
}

function CloseDialog() {
    var oWnd = GetRadWindow();
    if (oWnd) {
        if (oWnd.BrowserWindow && oWnd.BrowserWindow.CloseDialog) {
            oWnd.BrowserWindow.CloseDialog();
        }
    }
}

function GetRadWindowNew() {
    var oWindow = null;
    if (window.radWindow) {
        oWindow = window.radWindow;
    }
    else if (window.frameElement && window.frameElement.radWindow) {
        oWindow = window.frameElement.radWindow;
    }
    else if (typeof window.document.GetRadWindow === 'function') {
        oWindow = window.document.GetRadWindowNew();
    }
    else if (window.frameElement && window.frameElement.ownerDocument.GetRadWindowNew) {
        oWindow = window.frameElement.ownerDocument.GetRadWindowNew();
    }

    if (oWindow == undefined) {
        var iFrame = window.frameElement;
        if (window.parent.frameElement) {
            if (window.parent.frameElement.radWindow) {
                oWindow = window.parent.frameElement.radWindow;
            }
        }

    }
    if (oWindow == undefined) {
        oWindow = window.top;
    }
    return oWindow;
}

function CloseAlertView(AlertID) {
    var oWnd = GetRadWindow();
    if (oWnd) {
        if (oWnd.BrowserWindow && oWnd.BrowserWindow.CloseAlertView) {
            oWnd.BrowserWindow.CloseAlertView(AlertID);
        }
    }
}

function simpleCloseWindow() {
    var oWnd = GetRadWindow();
    if (oWnd) {
        oWnd.BrowserWindow.RefreshPage();
        if (oWnd.close) {
            oWnd.close();
        }
    }
}

function closeWindow() {
    var AMI = $(this).data("myAMI");

    var oWnd = GetRadWindow();
    if (oWnd) {
        if (oWnd.BrowserWindow && oWnd.BrowserWindow.closeWindow) {
            oWnd.BrowserWindow.closeWindow();
        }
        else if (oWnd.BrowserWindow && oWnd.BrowserWindow.Cancel) {
            oWnd.BrowserWindow.Cancel();
        }
        else {
            if (oWnd.GetRadWindow) {
                oWnd = oWnd.GetRadWindow();

                if (oWnd.BrowserWindow) {
                    if (oWnd.BrowserWindow.Cancel) {
                        oWnd.BrowserWindow.Cancel();
                    }
                    else {
                        oWnd.BrowserWindow.closeWindow();
                    }
                }
                else {
                    try {
                        oWnd.close();
                    } catch (e) {

                    }
                }
            }
            else {
                oWnd.close();
            }
        }
    }
}

function closeWindowNew() {
    var oWnd = GetRadWindowNew();
    if (oWnd) {
        if (oWnd.BrowserWindow && oWnd.BrowserWindow.closeWindow) {
            oWnd.BrowserWindow.closeWindow();
        }
        else if (oWnd.BrowserWindow && oWnd.BrowserWindow.Cancel) {
            oWnd.BrowserWindow.Cancel();
        }
        else {
            if (oWnd.GetRadWindow) {
                oWnd = oWnd.GetRadWindow();

                if (oWnd.BrowserWindow) {
                    oWnd.BrowserWindow.Cancel();
                }
                else {
                    try {
                        oWnd.close();
                    } catch (e) {

                    }
                }
            }
            else {
                oWnd.close();
            }
        }
    }
}

function CloseWindow() {
    closeWindow();
}
function CloseOnReload() {
    closeWindow();
}
function CloseThisWindow() {
    //alert('ChildPage CloseThisWindow');
    closeWindow();
}

function CloseThisWindowNew() {
    //alert('ChildPage CloseThisWindow');
    closeWindowNew();
}

function isInTab() {
    var oWnd = GetRadWindow();
    var inTab = false;
    if (oWnd) {
        if (oWnd.BrowserWindow && oWnd.BrowserWindow.webvantage) {
            inTab = true;
        }
    }
    if (inTab === false) {
        var CurrentURL = window.location.href;
        var GoURL = "";
        var ar = new Array();
        if (CurrentURL.indexOf(".aspx") > -1) {
            ar = CurrentURL.split('.aspx');
            GoURL = "NewApp?link=" + ar[0].substring(ar[0].lastIndexOf("/") + 1) + ".aspx" + ar[1].replace("?", "$");
            document.write("<div id=\"FrameLoading\" class=\"rwLoading\" style=\"width: 100%; height: 100%;\"><div style=\"text-align: center;color: #FFFFFF; font-family: segoe ui, Calibri,Tahoma, Verdana, Arial;\">Loading Workspace and requested application.</div></div>");
            window.location = GoURL;
        }
    }
    return inTab;
}
function CheckWnd() {
    //console.log("CheckWnd")
    var IsInWindow = true;
    try {
        var wnd = GetRadWindow();
        if (wnd) {
            IsInWindow = true
        }
        else {
            IsInWindow = false
        }
    } catch (e) {
        IsInWindow = false
    }
    if (IsInWindow == false) {
        var CurrentURL = window.location.href;
        //console.log("CurrentURL", CurrentURL)
        var GoURL = "";
        var ar = new Array();
        if (CurrentURL.indexOf("Desktop_AlertView") > -1) {
            ar = CurrentURL.split('?');
            GoURL = "Default.aspx?link=Desktop_AlertView$" + ar[1];
        } else {
            ar = CurrentURL.split('.aspx');
            GoURL = "Default.aspx?link=" + ar[0].substring(ar[0].lastIndexOf("/") + 1) + ".aspx" + ar[1].replace("?", "$")
            //document.write("<div style=\"text-align: center;font-family: segoe ui, Calibri,Tahoma, Verdana, Arial;\"><h2>Please Wait</h2>Loading Workspace and requested application.</div>");
            document.write("<div id=\"FrameLoading\" class=\"rwLoading\" style=\"width: 100%; height: 100%;\"><div style=\"text-align: center;color: #FFFFFF; font-family: segoe ui, Calibri,Tahoma, Verdana, Arial;\">Loading Workspace and requested application.</div></div>");
        }
        //console.log("GoURL", GoURL)
        window.location = GoURL;
    }
}
function BuildJavascriptParameters(UrlWithLocalReferences) {
    var UrlToSend = '';
    UrlToSend = UrlWithLocalReferences;
    //alert(UrlToSend);
}
function RefreshWindowWithNewURL(oldURL, NewURL) {
    var oWnd = GetRadWindow();
    if (oWnd) {
        if (oWnd.BrowserWindow) {
            oWnd.BrowserWindow.RefreshWindowWithNewURL(oldURL, NewURL);
        } else {
            oWnd.RefreshWindowWithNewURL(oldURL, NewURL);
        }
    }
}
function CallPrintSendPageSilently(URL) {
    //alert("ChildPage CallPrintSendPageSilently");
    var oWnd = GetRadWindow();
    if (oWnd) {
        if (oWnd.BrowserWindow) {
            oWnd.BrowserWindow.CallPrintSendPageSilently(URL);
        } else {
            oWnd.CallPrintSendPageSilently(URL);
        }
    }
}
function OnColumnHidden(sender, eventArgs) {
    PageMethods.ColumnChanged(eventArgs.get_gridColumn().get_owner().get_owner().get_id(), eventArgs.get_gridColumn().get_uniqueName(), false);
}
function OnColumnShown(sender, eventArgs) {
    PageMethods.ColumnChanged(eventArgs.get_gridColumn().get_owner().get_owner().get_id(), eventArgs.get_gridColumn().get_uniqueName(), true);
}
function RebindGrid() {
    __doPostBack("RebindGrid", "");
}
function ReloadPage() {
    __doPostBack("ReloadPage", "");
}
function RefreshParentPage(parent) {
    var oWnd = GetRadWindow();
    if (oWnd) {
        if (oWnd.BrowserWindow) {
            oWnd.BrowserWindow.location.reload();
        } else {
            oWnd.location.reload();
        }
    }
}
//RefreshDashboardReviews
function RefreshDashboardReviews() {
    var oWindow = GetRadWindow();
    if (oWindow) {
        if (oWindow.BrowserWindow) {
            oWindow.BrowserWindow.RefreshDashboardReviews();
        } else {
            oWindow.RefreshDashboardReviews();
        }
        //oWindow.reload();
    }
}
function ShowMessage(msg) {
    console.log("ChildPage ShowMessage")
    var oWindow = GetRadWindow();
    if (oWindow) {
        if (oWindow.BrowserWindow) {
            console.log("BrowserWindow")
            oWindow.BrowserWindow.ShowMessage(msg);
        } else {
            console.log("No BrowserWindow")
            oWindow.ShowMessage(msg);
        }
        //oWindow.reload();
    }
}
function showKendoAlert(msg) {
    console.log("ChildPage showKendoAlert")
    var oWindow = GetRadWindow();
    if (oWindow) {
        if (oWindow.BrowserWindow) {
            console.log("BrowserWindow")
            oWindow.BrowserWindow.ShowMessage(msg);
        } else {
            console.log("No BrowserWindow")
            oWindow.ShowMessage(msg);
        }
        //oWindow.reload();
    }
}
function RadToolBarConfirm(sender, args, msg) {
    var oWindow = GetRadWindow();
    if (oWindow) {
        if (oWindow.BrowserWindow) {
            return oWindow.BrowserWindow.RadToolBarConfirm(sender, args, msg);
        } else {
            return oWindow.RadToolBarConfirm(sender, args, msg);
        }
    }
}
function ShowKendoConfirm(msg) {
    //console.log("ChildPage showKendoAlert")
    var oWindow = GetRadWindow();
    if (oWindow) {
        if (oWindow.BrowserWindow) {
            //console.log("BrowserWindow")
            return oWindow.BrowserWindow.ShowKendoConfirm(msg);
        } else {
            //console.log("No BrowserWindow")
            return oWindow.ShowKendoConfirm(msg);
        }
    }
}

function RefreshThisPage() {
    var oWindow = GetRadWindow();
    if (oWindow) {
        //if (oWindow.BrowserWindow) {
        //} else {
        //}
        oWindow.reload();
    }
}
function RefreshWindow(WindowURL, ForceNewURL, OpenWindowIfNotFound) {
    //alert('ChildPage RefreshWindow');
    if (typeof ForceNewURL == 'undefined') {
        ForceNewURL = false;
    }
    if (typeof OpenWindowIfNotFound == 'undefined') {
        OpenWindowIfNotFound = true;
    }
    var oWnd = GetRadWindow();
    if (oWnd) {
        if (oWnd.BrowserWindow) {
            oWnd.BrowserWindow.RefreshWindow(WindowURL, ForceNewURL, OpenWindowIfNotFound);
        } else {
            oWnd.RefreshWindow(WindowURL, ForceNewURL, OpenWindowIfNotFound);
        }
    }
}
function ShowProgress(toogle) {
    
    var oWnd = GetRadWindow();

    if (oWnd) {

        if (oWnd.BrowserWindow) {

            oWnd.BrowserWindow.ShowProgress(toogle);

        }

    }

}
function RefreshInOutBoardObjects(CurrentObjectName) {
    //alert("ChildPage RefreshInOutBoardObjects");
    var oWnd = GetRadWindow();
    if (oWnd) {
        if (oWnd.BrowserWindow) {
            oWnd.BrowserWindow.RefreshInOutBoardObjects(CurrentObjectName);
        } else {
            oWnd.RefreshInOutBoardObjects(CurrentObjectName);
        }
    }
}
function RefreshJobRequestObjects(CurrentObjectName) {
    //alert("ChildPage RefreshInOutBoardObjects");
    var oWnd = GetRadWindow();
    if (oWnd) {
        if (oWnd.BrowserWindow) {
            oWnd.BrowserWindow.RefreshJobRequestObjects(CurrentObjectName);
        } else {
            oWnd.RefreshJobRequestObjects(CurrentObjectName);
        }
    }
}
function RefreshBookmarksDTO() {
    var oWnd = GetRadWindow();
    if (oWnd) {
        if (oWnd.BrowserWindow) {
            oWnd.BrowserWindow.RefreshBookmarksDTO();
        } else {
            oWnd.RefreshBookmarksDTO();
        }
    }
}
function RefreshAlertRecipients() {
    //alert("ChildPage_RefreshAlertRecipients");
    var oWnd = GetRadWindow();
    if (oWnd) {
        if (oWnd.BrowserWindow) {
            oWnd.BrowserWindow.RefreshAlertRecipients();
        } else {
            oWnd.RefreshAlertRecipients();
        }
    }
}
function RefreshAlertWindows(updateAlertDO, updateAlertInbox, updateCards) {
    var oWnd = GetRadWindow();
    if (oWnd) {
        if (oWnd.BrowserWindow) {
            oWnd.BrowserWindow.RefreshAlertWindows(updateAlertDO, updateAlertInbox, updateCards);
        } else {
            oWnd.RefreshAlertWindows(updateAlertDO, updateAlertInbox, updateCards);
        }
    }
}
function RefreshAlertsDTO() {
    //alert("ChildPage RefreshAlertsDTO");
    var oWnd = GetRadWindow();
    if (oWnd) {
        if (oWnd.BrowserWindow) {
            oWnd.BrowserWindow.RefreshAlertsDTO();
        } else {
            oWnd.RefreshAlertsDTO();
        }
    }
}
function OnAlertNotificationClose() {
    var oWnd = GetRadWindow();
    if (oWnd) {
        if (oWnd.BrowserWindow) {
            oWnd.BrowserWindow.RefreshAlertInbox();
            oWnd.BrowserWindow.RefreshAlertsDTO();
        } else {
            oWnd.RefreshAlertInbox();
            oWnd.RefreshAlertsDTO();
        }
    }
}
function refreshCurrentDashboard() {
    var oWnd = GetRadWindow();
    if (oWnd) {
        if (oWnd.BrowserWindow) {
            oWnd.BrowserWindow.refreshCurrentDashboard();
        } else {
            oWnd.refreshCurrentDashboard();
        }
    }
}
function refreshDashboardTime() {
    var oWnd = GetRadWindow();
    if (oWnd) {
        if (oWnd.BrowserWindow) {
            oWnd.BrowserWindow.refreshDashboardTime();
        } else {
            oWnd.refreshDashboardTime();
        }
    }
}
function refreshDashboardAssignments() {
    var oWnd = GetRadWindow();
    if (oWnd) {
        if (oWnd.BrowserWindow) {
            oWnd.BrowserWindow.refreshDashboardAssignments();
        } else {
            //oWnd.refreshDashboardAssignments();
        }
    }
}
function refreshDashboardAlerts() {
    var oWnd = GetRadWindow();
    if (oWnd) {
        if (oWnd.BrowserWindow) {
            oWnd.BrowserWindow.refreshDashboardAlerts();
        } else {
            //oWnd.refreshDashboardAlerts();
            if (window.top.location.pathname.indexOf("Desktop_AlertView") > -1) {
                window.top.location.href = "NewApp?link=Desktop_AlertView" + window.location.search.replace("?", "$");
            }
        }
    }
}
function refreshDashboardAppointments() {
    var oWnd = GetRadWindow();
    if (oWnd) {
        if (oWnd.BrowserWindow) {
            oWnd.BrowserWindow.refreshDashboardAppointments();
        } else {
            oWnd.refreshDashboardAppointments();
        }
    }
}
function refreshDashboardBookmarks() {
    var oWnd = GetRadWindow();
    if (oWnd) {
        if (oWnd.BrowserWindow) {
            oWnd.BrowserWindow.refreshDashboardBookmarks();
        } else {
            oWnd.refreshDashboardBookmarks();
        }
    }
}
function refreshDashboardReviews() {
    var oWnd = GetRadWindow();
    if (oWnd) {
        if (oWnd.BrowserWindow) {
            oWnd.BrowserWindow.refreshDashboardReviews();
        } else {
            oWnd.refreshDashboardReviews();
        }
    }
}
function refreshAlertNotifications() {
    var oWnd = GetRadWindow();
    if (oWnd) {
        if (oWnd.BrowserWindow) {
            oWnd.BrowserWindow.refreshAlertNotifications();
        } else {
            oWnd.refreshAlertNotifications();
        }
    }
}
function refreshAlertsAndAssignmentsManagerPMD() {
    var oWnd = GetRadWindow();
    if (oWnd) {
        if (oWnd.BrowserWindow) {
            oWnd.BrowserWindow.refreshAlertsAndAssignmentsManagerPMD();
        } else {
            //oWnd.refreshAlertsAndAssignmentsManagerPMD();
        }
    }
}
function checkForStopwatch() {
    var oWnd = GetRadWindow();
    if (oWnd) {
        if (oWnd.BrowserWindow) {
            oWnd.BrowserWindow.checkForStopwatch();
        } else {
            oWnd.checkForStopwatch();
        }
    }
}
function refreshTimesheetTab() {
    var oWnd = GetRadWindow();
    if (oWnd) {
        if (oWnd.BrowserWindow) {
            oWnd.BrowserWindow.refreshTimesheetTab();
        } else {
            oWnd.refreshTimesheetTab();
        }
    }
}

//  SignalR client functions
function refreshSprint(sprintId, sprintIsActive, sprintIsComplete, employeeName) {
    var oWnd = GetRadWindow();
    if (oWnd) {
        if (oWnd.BrowserWindow) {
            oWnd.BrowserWindow.refreshSprint(sprintId, sprintIsActive, sprintIsComplete, employeeName);
        } else {
            oWnd.refreshSprint(sprintId, sprintIsActive, sprintIsComplete, employeeName);
        }
    }
}
function refreshNewAlertView(alertId, sprintId, employeeName) {
    var oWnd = GetRadWindow();
    if (oWnd) {
        if (oWnd.BrowserWindow) {
            oWnd.BrowserWindow.refreshNewAlertView(alertId, sprintId, employeeName);
        } else {
            oWnd.refreshNewAlertView(alertId, sprintId, employeeName);
        }
    }
}
function refreshAlerts() {
    var oWnd = GetRadWindow();
    if (oWnd) {
        if (oWnd.BrowserWindow) {
            oWnd.BrowserWindow.refreshAlerts();
        }// else {
        //    oWnd.refreshAlerts();
        //}
    }
}
function refreshDashboardWorkItems() {
    var oWnd = GetRadWindow();
    if (oWnd) {
        if (oWnd.BrowserWindow) {
            oWnd.BrowserWindow.refreshDashboardWorkItems();
        } else {
            oWnd.refreshDashboardWorkItems();
        }
    }
}
function refreshMyAssignmentsNotificationsAndCounts() {
    var oWnd = GetRadWindow();
    if (oWnd) {
        if (oWnd.BrowserWindow) {
            oWnd.BrowserWindow.refreshMyAssignmentsNotificationsAndCounts();
        } else {
            oWnd.refreshMyAssignmentsNotificationsAndCounts();
        }
    }
}
function refreshAlertComments(alertId, employeeName) {
    var oWnd = GetRadWindow();
    if (oWnd) {
        if (oWnd.BrowserWindow) {
            oWnd.BrowserWindow.refreshAlertComments(alertId, employeeName);
        } else {
            oWnd.refreshAlertComments(alertId, employeeName);
        }
    }
}
function refreshAlertChecklists(alertId, employeeName) {
    var oWnd = GetRadWindow();
    if (oWnd) {
        if (oWnd.BrowserWindow) {
            oWnd.BrowserWindow.refreshAlertChecklists(alertId, employeeName);
        } else {
            oWnd.refreshAlertChecklists(alertId, employeeName);
        }
    }
}
function refreshAlertAssigneesAndCCs(alertId, employeeName) {
    var oWnd = GetRadWindow();
    if (oWnd) {
        if (oWnd.BrowserWindow) {
            oWnd.BrowserWindow.refreshAlertAssigneesAndCCs(alertId, employeeName);
        } else {
            oWnd.refreshAlertAssigneesAndCCs(alertId, employeeName);
        }
    }
}
function refreshAlertHours(alertId, employeeName) {
    var oWnd = GetRadWindow();
    if (oWnd) {
        if (oWnd.BrowserWindow) {
            oWnd.BrowserWindow.refreshAlertHours(alertId, employeeName);
        } else {
            oWnd.refreshAlertHours(alertId, employeeName);
        }
    }
}
function refreshAssignmentTab(alertId, sprintId, employeeName, updateType) {
    var oWnd = GetRadWindow();
    if (oWnd) {
        if (oWnd.BrowserWindow) {
            oWnd.BrowserWindow.refreshAssignmentTab(alertId, sprintId, employeeName, updateType);
        } else {
            oWnd.refreshAssignmentTab(alertId, sprintId, employeeName, updateType);
        }
    }
}


function openStopWatchDialog() {
    var oWnd = GetRadWindow();
    if (oWnd) {
        if (oWnd.BrowserWindow) {
            oWnd.BrowserWindow.openStopWatchDialog();
        } else {
            oWnd.openStopWatchDialog();
        }
    }
}
function RefreshTimesheetWindows() {
    var oWnd = GetRadWindow();
    if (oWnd) {
        if (oWnd.BrowserWindow) {
            oWnd.BrowserWindow.RefreshTimesheetWindows();
        } else {
            oWnd.RefreshTimesheetWindows();
        }
    }
}
function RefreshTimesheetDTO() {
    //alert("ChildPage RefreshTimesheetDTO");
    var oWnd = GetRadWindow();
    if (oWnd) {
        if (oWnd.BrowserWindow) {
            oWnd.BrowserWindow.RefreshTimesheetDTO();
        } else {
            oWnd.RefreshTimesheetDTO();
        }
    }
}
function RefreshProjectScheduleGrid() {
    //alert("ChildPage RefreshProjectScheduleGrid");
    var oWnd = GetRadWindow();
    if (oWnd) {
        if (oWnd.BrowserWindow) {
            oWnd.BrowserWindow.RefreshProjectScheduleGrid();
        } else {
            oWnd.RefreshProjectScheduleGrid();
        }
    }
}
function RefreshChildPageGrid(PageName) {
    //alert("ChildPage RefreshChildPageGrid");
    var oWnd = GetRadWindow();
    if (oWnd) {
        if (oWnd.BrowserWindow) {
            oWnd.BrowserWindow.RefreshChildPageGrid(PageName);
        } else {
            oWnd.RefreshChildPageGrid(PageName);
        }
    }
}
function RefreshTasks() {
    //alert("ChildPage RefreshChildPageGrid");
    var oWnd = GetRadWindow();
    if (oWnd) {
        if (oWnd.BrowserWindow) {
            oWnd.BrowserWindow.RefreshTasks();
        } else {
            oWnd.RefreshTasks();
        }
    }
}
function RedirectParentPage(newUrl, parent) {
    var oWnd = GetRadWindow();
    if (oWnd) {
        if (oWnd.BrowserWindow) {
            oWnd.BrowserWindow.BrowserWindow.document.location.href = newUrl;
        } else {
            oWnd.document.location.href = newUrl;
        }
    }
}
function BillingApprovalBatchCreated() {
    var oWnd = GetRadWindow();
    if (oWnd) {
        if (oWnd.BrowserWindow) {
            oWnd.BrowserWindow.BillingApprovalBatchCreated();
        } else {
            oWnd.BillingApprovalBatchCreated();
        }
    }
}
function sessionEnded() {
    var oWnd = GetRadWindow();
    if (oWnd) {
        if (oWnd.BrowserWindow) {
            oWnd.BrowserWindow.sessionEnded();
        } else {
            oWnd.sessionEnded();
        }
    }
}
function CalendarSync(EmployeeNonTaskId, IsHoliday, IsDeleting) {
    //alert("ChildPage CalendarSync");
    var oWnd = GetRadWindow();
    if (oWnd) {
        if (oWnd.BrowserWindow) {
            oWnd.BrowserWindow.CalendarSync(EmployeeNonTaskId, IsHoliday, IsDeleting);
        } else {
            oWnd.CalendarSync(EmployeeNonTaskId, IsHoliday, IsDeleting);
        }
    }
}
function SendEmail(guid) {
    //alert("ChildPage SendEmail");
    //alert("ChildPage guid: " + guid);
    var oWnd = GetRadWindow();
    if (oWnd) {
        if (oWnd.BrowserWindow) {
            oWnd.BrowserWindow.SendEmail(guid);
        } else {
            oWnd.SendEmail(guid);
        }
    }
}
function CheckForAsyncMessage() {
    //alert("ChildPage CheckForAsyncMessage");
    var oWnd = GetRadWindow();
    if (oWnd.BrowserWindow) {
        oWnd.BrowserWindow.CheckForAsyncMessage();
    } else {
        oWnd.CheckForAsyncMessage();
    }
}
function CallFunctionOnParentPage(fnName) {
    var oWindow = GetRadWindow();
    if (oWindow) {
        if (oWindow.BrowserWindow) {
            if (oWindow.BrowserWindow[fnName] && typeof (oWindow.BrowserWindow[fnName]) == "function") {
                oWindow.BrowserWindow[fnName](oWindow);
                oWindow.Close();
            };
        } else {
        }
    }
}
function OpenChatWindow(chatURL) {
    var oWnd = GetRadWindow();
    if (oWnd.BrowserWindow) {
        oWnd.BrowserWindow.OpenChatWindow(chatURL);
    } else {
        oWnd.OpenChatWindow(chatURL);
    }
}
function FindChatWindow(chatURL) {
    var oWnd = GetRadWindow();
    if (oWnd.BrowserWindow) {
        oWnd.BrowserWindow.FindChatWindow(chatURL);
    } else {
        oWnd.FindChatWindow(chatURL);
    }
}
function RestoreChatWindow(chatURL) {
    var oWnd = GetRadWindow();
    if (oWnd.BrowserWindow) {
        oWnd.BrowserWindow.RestoreChatWindow(chatURL);
    } else {
        oWnd.RestoreChatWindow(chatURL);
    }
}

function ReviewGenerateFeedbackSummary(projectId, reviewId) {
    //alert("ChildPage ReviewGenerateFeedbackSummary");
    var oWnd = GetRadWindow();
    if (oWnd.BrowserWindow) {
        oWnd.BrowserWindow.ReviewGenerateFeedbackSummary(projectId, reviewId);
    } else {
        oWnd.ReviewGenerateFeedbackSummary(projectId, reviewId);
    }
}

function refreshExpenseReports() {
    var oWnd = GetRadWindow();
    if (oWnd) {
        if (oWnd.BrowserWindow) {
            oWnd.BrowserWindow.refreshExpenseReports();
        } else {
            oWnd.refreshExpenseReports();
        }
    }
}


function OpenRadWindow(WindowTitle, WindowURL, WindowHeight, WindowWidth, IsModal, DialogCallback, param) {
    try {
        var oWindow;
        var qs = -1;
        if (typeof WindowURL === 'undefined') {
            alert('No page to navigate');
            return false;
        }
        if (typeof WindowTitle === 'undefined') {
            WindowTitle = '';
        }
        if (typeof WindowHeight === 'undefined') {
            WindowHeight = 0;
        }
        if (typeof WindowWidth === 'undefined') {
            WindowWidth = 0;
        }
        if (typeof IsModal === 'undefined') {
            IsModal = false;
        }
        if (WindowURL.indexOf("Alert_New.aspx") > -1) {
            if (WindowURL.indexOf("assn=1") > -1) {
                var newURL = WindowURL;
                qs = WindowURL.indexOf("?");
                if (qs && qs > -1) {
                    try {
                        newURL = "Desktop_NewAssignment" + WindowURL.substr(qs, WindowURL.length);
                    } catch (e) {
                        newURL = "Desktop_NewAssignment";
                    }
                } else {
                    newURL = "Desktop_NewAssignment";
                }
                if (newURL) {
                    WindowURL = newURL;
                }
                WindowTitle = "Assignment";
            } else if (WindowURL.indexOf("eml=1") > -1) {
                WindowTitle = "Email";
            } else {
                WindowTitle = "Alert";
            }
        }
        ////Help identify any pages with no title
        //try {
        //    if (!WindowTitle || WindowTitle.length === 0) {
        //        qs = WindowURL.indexOf("?");
        //        if (qs && qs > -1) {
        //            WindowTitle = WindowURL.substr(0, qs);
        //        } else {
        //            WindowTitle = WindowURL;
        //        }
        //    }
        //} catch (e) {
        //    //
        //}
        if (typeof window.document.GetRadWindow === 'function') {
            oWindow = window.document.GetRadWindow();
            if (oWindow) {
                oWindow.BrowserWindow.OpenRadWindow(WindowTitle, WindowURL, WindowHeight, WindowWidth, DialogCallback, param);
            }
        }
        else {
            //Use the Window Manager on the Parent page:
            oWindow = GetRadWindow();
            if (oWindow) {
                if (oWindow.BrowserWindow) {
                    if (oWindow.get_name) {
                        oWindow.BrowserWindow.OpenRadWindow(WindowTitle, WindowURL, WindowHeight, WindowWidth, DialogCallback, param);
                    }
                    else {
                        oWindow.BrowserWindow.OpenRadWindow(WindowTitle, WindowURL, WindowHeight, WindowWidth, DialogCallback, param);
                    }
                }else {
                    oWindow.OpenRadWindow(WindowTitle, WindowURL, WindowHeight, WindowWidth, IsModal, DialogCallback, param);
                }
            };
        }
    } catch (err) {
        alert("Error ChildPage OpenRadWindow\n" + err);
    };
};
function OpenRadWindowUpdate(WindowTitle, WindowURL, NewURL) {
    try {
        var oWindow;
        var qs = -1;
        if (typeof WindowURL === 'undefined') {
            alert('No page to navigate');
            return false;
        }
        if (typeof WindowTitle === 'undefined') {
            WindowTitle = '';
        }
        if (typeof WindowHeight === 'undefined') {
            WindowHeight = 0;
        }
        if (typeof WindowWidth === 'undefined') {
            WindowWidth = 0;
        }
        if (typeof IsModal === 'undefined') {
            IsModal = false;
        }
       
        
            //Use the Window Manager on the Parent page:
            oWindow = GetRadWindow();
            if (oWindow) {
                if (oWindow.BrowserWindow) {
                    if (oWindow.get_name) {
                        oWindow.BrowserWindow.OpenRadWindowUpdate(WindowTitle, WindowURL, NewURL);
                    }
                    else {
                        oWindow.BrowserWindow.OpenRadWindowUpdate(WindowTitle, WindowURL, NewURL);
                    }
                } else {
                    oWindow.OpenRadWindow(WindowTitle, WindowURL, NewURL);
                }
            };
        
    } catch (err) {
        alert("Error ChildPage OpenRadWindowUpdate\n" + err);
    };
};
//function OpenRadWindowLookup(WindowURL) {
//    console.log('OpenRadWindowLookup');
//    try {
//        if (typeof window.document.GetRadWindow === 'function') {
//            var oWindow = window.document.GetRadWindow();

//            oWindow.BrowserWindow.OpenRadWindowLookup(WindowURL);
//        }
//        else {
//            //alert("ChildPage OpenRadWindowLookup");
//            var oWnd = GetRadWindow();
//            if (oWnd) {
//                if (oWnd.BrowserWindow) {
//                    if (oWnd.get_name) {
//                        oWnd.BrowserWindow.OpenRadWindowLookup(WindowURL, oWnd.get_name());
//                    }
//                    else {
//                        oWnd.BrowserWindow.OpenRadWindowLookup(WindowURL, '');
//                    }
//                } else {
//                    oWnd.OpenRadWindowLookup(WindowURL, "");
//                }
//            }
//        }
//    } catch (err) {
//        alert("Error ChildPage OpenRadWindowLookup\n" + err);
//    }
//}
//function OpenRadWindowLookupRecipients(WindowURL) {
//    try {
//        //alert("ChildPage OpenRadWindowLookupRecipients");
//        var oWnd = GetRadWindow();
//        if (oWnd) {
//            if (oWnd.BrowserWindow) {
//                if (oWnd.get_name) {
//                    oWnd.BrowserWindow.OpenRadWindowLookup(WindowURL, oWnd.get_name(), 420, 390);
//                }
//                else {
//                    oWnd.BrowserWindow.OpenRadWindowLookup(WindowURL, '', 420, 390);
//                }
//            } else {
//                oWnd.OpenRadWindowLookup(WindowURL, "", 420, 390);
//            }
//        }
//    } catch (err) {
//        alert("Error ChildPage OpenRadWindowLookupRecipients\n" + err);
//    }
//}
function OpenRadWindowLookupEmailRecipients(WindowURL) {
    try {
        //alert("ChildPage OpenRadWindowLookupRecipients");
        var oWnd = GetRadWindow();
        if (oWnd) {
            if (oWnd.BrowserWindow) {
                if (oWnd.get_name) {
                    oWnd.BrowserWindow.OpenRadWindowLookup(WindowURL, oWnd.get_name(), 420, 390);
                }
                else {
                    oWnd.BrowserWindow.OpenRadWindowLookup(WindowURL, '', 420, 390);
                }
            } else {
                oWnd.OpenRadWindowLookup(WindowURL, "", 420, 390);
            }
        }
    } catch (err) {
        alert("Error ChildPage OpenRadWindowLookupEmailRecipients\n" + err);
    }
}
function CallUiAction(actionId, extraQS) {
    var oWnd = GetRadWindow();
    if (oWnd) {
        if (oWnd.BrowserWindow) {
            oWnd.BrowserWindow.CallUiAction(actionId, extraQS);
        } else {
            oWnd.CallUiAction(actionId, extraQS);
        }
    }
}
function ShowAlertNotify() {
    var oWnd = GetRadWindow();
    if (oWnd) {
        if (oWnd.BrowserWindow) {
            oWnd.BrowserWindow.ShowAlertNotify();
        } else {
            oWnd.ShowAlertNotify();
        }
    }
}
function HideAlertNotify() {
    var oWnd = GetRadWindow();
    if (oWnd) {
        if (oWnd.BrowserWindow) {
            oWnd.BrowserWindow.HideAlertNotify();
        } else {
            oWnd.HideAlertNotify();
        }
    }
}
function OpenStopwatchNotify() {
    var oWnd = GetRadWindow();
    if (oWnd) {
        if (oWnd.BrowserWindow) {
            oWnd.BrowserWindow.openStopWatchDialog();
        } else {
            oWnd.OpenStopwatchNotify();
        }
    }
}
function MarkAllEmailAsRead() {
    var oWnd = GetRadWindow();
    if (oWnd) {
        if (oWnd.BrowserWindow) {
            oWnd.BrowserWindow.MarkAllEmailAsRead();
        } else {
            oWnd.MarkAllEmailAsRead();
        }
    }
}
function OpenFloatingWindow(WindowTitle, WindowURL, WindowHeight, WindowWidth, WindowTop, WindowLeft) {
    var oWnd = GetRadWindow();
    if (oWnd) {
        if (oWnd.BrowserWindow) {
            oWnd.BrowserWindow.OpenFloatingWindow(WindowTitle, WindowURL, WindowHeight, WindowWidth, WindowTop, WindowLeft)
        } else {
            oWnd.OpenFloatingWindow(WindowTitle, WindowURL, WindowHeight, WindowWidth, WindowTop, WindowLeft)
        }
    }
    return false;
}
function CheckAlertNotification() {
    try {
        //alert("ChildPage CheckAlertNotification");
        var oWnd = GetRadWindow();
        if (oWnd) {
            if (oWnd.BrowserWindow) {
                oWnd.BrowserWindow.OpenNotification();
            } else {
                oWnd.OpenNotification();
            }
        }
    } catch (err) {
        alert("Error ChildPage CheckAlertNotification\n" + err);
    }
}
function GetDocumentRepositoryDocument(DocumentId) {
    try {
        var oWnd = GetRadWindow();
        if (oWnd) {
            if (oWnd.BrowserWindow) {
                oWnd.BrowserWindow.GetDocumentRepositoryDocument(DocumentId);
            } else {
                oWnd.GetDocumentRepositoryDocument(DocumentId);
            }
        }
    } catch (err) {
        alert("Error ChildPage GetDocumentRepositoryDocument\n" + err);
    }
}
function ShowPleaseWait() {
    try {
        //alert("ChildPage ShowPleaseWait");
        var oWnd = GetRadWindow();
        if (oWnd) {
            if (oWnd.BrowserWindow) {
                oWnd.BrowserWindow.ShowPleaseWait();
            } else {
                oWnd.ShowPleaseWait();
            }
        }
    } catch (err) {
        alert("Error ChildPage ShowPleaseWait\n" + err);
    }
}
function HidePleaseWait() {
    try {
        //alert("ChildPage HidePleaseWait");
        var oWnd = GetRadWindow();
        if (oWnd) {
            if (oWnd.BrowserWindow) {
                oWnd.BrowserWindow.HidePleaseWait();
            } else {
                oWnd.HidePleaseWait();
            }
        }
    } catch (err) {
        alert("Error ChildPage HidePleaseWait\n" + err);
    }
}
function RadAsyncUploadOnClientValidationFailed(sender, args) {
    try {
        //alert("ChildPage HidePleaseWait");
        var oWnd = GetRadWindow();
        if (oWnd) {
            if (oWnd.BrowserWindow) {
                oWnd.BrowserWindow.RadAsyncUploadOnClientValidationFailed(sender, args);
            } else {
                oWnd.RadAsyncUploadOnClientValidationFailed(sender, args);
            }
        }
    } catch (err) {
        alert("Error ChildPage RadAsyncUploadOnClientValidationFailed\n" + err);
    }
}
function extendTimeout() {
    try {
        //alert("ChildPage extendTimeout");
        var oWnd = GetRadWindow();
        if (oWnd) {
            if (oWnd.BrowserWindow) {
                oWnd.BrowserWindow.extendTimeout();
            } else {
                oWnd.extendTimeout();
            }
        }
    } catch (err) {
        //alert("Error ChildPage extendTimeout\n" + err);
    }
}
function closePanel() {
    try {
        //alert("ChildPage extendTimeout");
        var oWnd = GetRadWindow();
        if (oWnd) {
            if (oWnd.BrowserWindow) {
                oWnd.BrowserWindow.closePanel();
            } else {
                oWnd.closePanel();
            }
        }
    } catch (err) {
        alert("Error ChildPage extendTimeout\n" + err);
    }
};
function toggleFullScreenElement(element) {
    $(element).toggleClass('full-screen');
    if ($(document.body).find('.full-screen').length > 0) {
        //console.log('full screen');
        $(document.body).css('overflow', 'hidden');
    } else {
        //console.log('no full screen');
        $(document.body).css('overflow', 'auto');
    }
}
var notifier;
function showSuccessNotification(data) {
    showNotification(data, 'success');
}
function showInfoNotification(data) {
    showNotification(data, 'info');
}
function showWarningNotification(data) {
    showNotification(data, 'warning');
}
function showErrorNotification(data) {
    showNotification(data, 'error');
}
function showNotification(data, type) {
    if (!notifier) {
        notifier = $('<span></span>').kendoNotification({
            position: {
                pinned: true,
                top: 30,
                right: 30
            },
            stacking: "down"
        }).data('kendoNotification');
    }
    if (!type) {
        type = 'info';
    }
    if (notifier) {
        notifier.show(data, type);
    }
}

function messageUser(userCode, message) {
    try {
        //console.log("ChildPage messageUser", userCode, message);
        var oWnd = GetRadWindow();
        if (oWnd) {
            if (oWnd.BrowserWindow) {
                oWnd.BrowserWindow.messageUser(userCode, message);
            } else {
                oWnd.messageUser(userCode, message);
            }
        }
    } catch (err) {
        alert("Error ChildPage messageUser\n" + err);
    }
}

function disableWorkItemTimeSaveButton(disable) {
    var win = GetRadWindow();
    if (win) {
        win.get_contentFrame().contentWindow.disableWorkItemTimeSaveButton(disable);
    }
}
function processLookupToAngular(args) {
    var win = GetRadWindow();
    if (win) {
        if (win.BrowserWindow) {
            var tsWin = win.BrowserWindow.FindWindow("Timesheet_CommentsView");
            if (!tsWin) {
                tsWin = win.BrowserWindow.FindWindow("Timesheet");
            }
            if (!tsWin) {
                tsWin = win.BrowserWindow.FindWindow("AccountSetupForm");
            }
            if (!tsWin) {
                tsWin = win.BrowserWindow.FindWindow("Chat_RoomDetails");
            }
        } else {
            var tsWin = win.FindWindow("Timesheet_CommentsView");
            if (!tsWin) {
                tsWin = win.FindWindow("Timesheet");
            }
            if (!tsWin) {
                tsWin = win.FindWindow("AccountSetupForm");
            }
            if (!tsWin) {
                tsWin = win.FindWindow("Chat_RoomDetails");
            }
        }
        if (tsWin) {
            var contentWindow = tsWin.get_contentFrame().contentWindow;
            if (contentWindow) {
                contentWindow.processAurLookupToAngular(args);
            }
        }
    }
}
//  OLD STOPWATCH
function stopwatchCounter(JsDateString, JsServerTime, id) {
    console.log(JsDateString);
    console.log(JsServerTime);
    this.beginDate = new Date(JsDateString);
    this.serverTime = new Date(JsServerTime);
    this.countainer = document.getElementById(id);
    this.numOfDays = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];
    this.borrowed = 0, this.years = 0, this.months = 0, this.days = 0;
    this.hours = 0, this.minutes = 0, this.seconds = 0;
    var initialWorkstationDate = new Date();
    this.workstationOffset = 0;
    this.workstationOffset = initialWorkstationDate - this.serverTime;

    this.updateNumOfDays();
    this.updateCounter();
    console.log(this.serverTime);
    console.log(initialWorkstationDate);
    console.log(this.workstationOffset);
    var testDate = new Date();
    console.log(testDate.getTime() + this.workstationOffset);
    testDate = new Date(testDate.getTime() + this.workstationOffset);
    console.log(testDate);
}
stopwatchCounter.prototype.updateNumOfDays = function () {
    var dateNow = this.serverTime;
    var currYear = dateNow.getFullYear();
    if ((currYear % 4 === 0 && currYear % 100 !== 0) || currYear % 400 === 0) {
        this.numOfDays[1] = 29;
    }
    var self = this;
    setTimeout(function () { self.updateNumOfDays(); }, (new Date((currYear + 1), 1, 2) - dateNow));
};
stopwatchCounter.prototype.datePartDiff = function (then, now, MAX) {
    var diff = now - then - this.borrowed;
    this.borrowed = 0;
    if (diff > -1) return diff;
    this.borrowed = 1;
    return (MAX + diff);
};
stopwatchCounter.prototype.calculate = function () {
    var currDate = new Date();
    currDate = new Date(currDate.getTime() - this.workstationOffset);

    var prevDate = this.beginDate;
    this.seconds = this.datePartDiff(prevDate.getSeconds(), currDate.getSeconds(), 60);
    this.minutes = this.datePartDiff(prevDate.getMinutes(), currDate.getMinutes(), 60);
    this.hours = this.datePartDiff(prevDate.getHours(), currDate.getHours(), 24);
    this.days = this.datePartDiff(prevDate.getDate(), currDate.getDate(), this.numOfDays[currDate.getMonth()]);
    this.months = this.datePartDiff(prevDate.getMonth(), currDate.getMonth(), 12);
    this.years = this.datePartDiff(prevDate.getFullYear(), currDate.getFullYear(), 0);
};
stopwatchCounter.prototype.addLeadingZero = function (value) {
    return value < 10 ? ("0" + value) : value;
};
stopwatchCounter.prototype.formatTime = function () {
    this.seconds = this.addLeadingZero(this.seconds);
    this.minutes = this.addLeadingZero(this.minutes);
    this.hours = this.addLeadingZero(this.hours);
};
stopwatchCounter.prototype.updateCounter = function () {

    this.calculate();
    this.formatTime();

    var display = '';

    display = "Stopwatch has been running for: ";
    if ((this.months === 11 && this.days === 29) || (this.minutes === 0 && this.seconds <= 59)) {
        display = display + "Less than a minute.";
    }
    else {
        if (this.years > 0) {
            display = display + this.years + (this.years === 1 ? " year,  " : " years,  ");
        }
        if (this.months > 0) {
            display = display + this.months + (this.months === 1 ? " month,  " : " months,  ");
        }
        if (this.days > 0) {
            display = display + this.days + (this.days === 1 ? " day,  " : " days,  ");
        }
        if (this.hours > 0) {
            display = display + this.hours + (this.hours === 1 ? " hour,  " : " hours,  ");
        }
        if (this.minutes > 0) {
            display = display + this.minutes + (this.minutes === 1 ? " minute,  " : " minutes,  ");
        }
        if (this.seconds >= 0) {
            display = display + this.seconds + (this.seconds === 1 ? " second.  " : " seconds.  ");
        }
    }
    if (display.indexOf("11 months") > -1 || display.indexOf("30 days") > -1 || (display.indexOf("30 days") > -1 && display.indexOf("23 hours") > -1)) {
        display = "Stopwatch has been running for:<br />Less than a minute.";
    }
    var PassItThroughAgain;
    PassItThroughAgain = display;
    if (PassItThroughAgain.indexOf("11 months") > -1 || PassItThroughAgain.indexOf("30 days") > -1 || (PassItThroughAgain.indexOf("30 days") > -1 && PassItThroughAgain.indexOf("23 hours") > -1)) {
        PassItThroughAgain = "Stopwatch has been running for:<br />Less than a minute.";
    }
    this.countainer.innerHTML = display;
    var self = this;
    setTimeout(function () {
        self.updateCounter();
        return display;
    }, 1000);
};
