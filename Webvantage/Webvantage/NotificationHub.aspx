<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="NotificationHub.aspx.vb" Inherits="Webvantage.NotificationHub" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
        <script type="text/javascript" src="Scripts/jquery.signalR-2.4.2.min.js"></script>
        <script src="signalr/hubs"></script>
        <div id="empName" style="display: none !important;"><%=Session("EmployeeName")%></div>
        <telerik:RadCodeBlock ID="RadCodeBlockParentBottom" runat="server">
            <script type="text/javascript">
                var manager = null;
                var CurrentWindows = new Array();
                var WorkspaceLogger = null;
                var chatEnabled = false;
                var chatActive = false;
                $(document).ready(function () {
                    var notifier = $.connection.notificationHub;
                    //  Callbacks from server
                    notifier.client.sayHello = function () {
                        window.setTimeout(function () {
                            alert("Hello!");
                        }, 10);
                    };
                    notifier.client.testMessage = function (message) {
                        //console.log("testMessage:NotificationHub.aspx:")
                        window.setTimeout(function () {
                            alert("Hello! " + message);
                        }, 10);
                    };
                   notifier.client.refreshAlerts = function () {
                        window.setTimeout(function () {
                            //RefreshAlertWindows(true, true);
                            //console.log("push refreshAlerts");
                            refreshAlerts();
                            //refreshDashboardAssignments();
                        }, 10);
                    };
                    notifier.client.refreshSprint = function (sprintId, sprintIsActive, sprintIsComplete, employeeName) {
                        window.setTimeout(function () {
                            //console.log("push refreshSprint");
                            refreshSprint(sprintId, sprintIsActive, sprintIsComplete, employeeName);
                        }, 10);
                    };
                    notifier.client.refreshNewAlertView = function (alertId, sprintId, employeeName) {
                        window.setTimeout(function () {
                            //console.log("push refreshNewAlertView");
                            refreshNewAlertView(alertId, sprintId, employeeName);
                        }, 10);
                    };
                    notifier.client.refreshDashboardWorkItems = function () {
                        window.setTimeout(function () {
                            //console.log("push refreshDashboardWorkItems");
                            refreshDashboardWorkItems();
                        }, 10);
                    };
                    notifier.client.refreshMyAssignmentsNotificationsAndCounts = function () {
                        window.setTimeout(function () {
                            //console.log("push refreshMyAssignmentsNotificationsAndCounts");
                            refreshMyAssignmentsNotificationsAndCounts();
                        }, 10);
                    };
                    notifier.client.refreshAlertComments = function (alertId, employeeName) {
                        window.setTimeout(function () {
                            //console.log("push refreshAlertComments");
                            refreshAlertComments(alertId, employeeName);
                        }, 10);
                    };
                    notifier.client.refreshAlertChecklists = function (alertId, employeeName) {
                        window.setTimeout(function () {
                            //console.log("push refreshAlertChecklists");
                            refreshAlertChecklists(alertId, employeeName);
                        }, 10);
                    };
                    notifier.client.refreshAlertAssigneesAndCCs = function (alertId, employeeName) {
                        window.setTimeout(function () {
                            //console.log("push refreshAlertAssigneesAndCCs");
                            refreshAlertAssigneesAndCCs(alertId, employeeName);
                        }, 10);
                    };
                    notifier.client.refreshAlertHours = function (alertId, employeeName) {
                        window.setTimeout(function () {
                            //console.log("push refreshAlertHours");
                            refreshAlertHours(alertId, employeeName);
                        }, 10);
                    };
                    notifier.client.refreshAssignmentTab = function (alertId, sprintId, employeeName, updateType) {
                        window.setTimeout(function () {
                            //console.log("push refreshAssignmentTab");
                            refreshAssignmentTab(alertId, sprintId, employeeName, updateType);
                        }, 10);
                    };
                    notifier.client.refreshAlertsAndAssignmentsManagerPMD = function () {
                        window.setTimeout(function () {
                            //console.log("push refreshAlertsAndAssignmentsManagerPMD");
                            refreshAlertsAndAssignmentsManagerPMD();
                        }, 10);
                    };
                    notifier.client.messageUser = function (userCode, message) {
                        window.setTimeout(function () {
                            //console.log("push messageUser");
                            messageUser(userCode, message);
                        }, 10);
                    };

                    $.connection.hub.qs = {
                    };
                    //  Log to console
                    //$.connection.hub.logging = true;
                    if ($.connection.hub && $.connection.hub.state === $.signalR.connectionState.disconnected) {
                        $.connection.hub
                            .start({ waitForPageLoad: false }, function () {
                                //console.log("Notification hub starting.");
                            })
                            .done(function () {
                                //console.log("Notification hub started.");
                                //console.log("hub?", $.connection.hub);
                            });
                    }
                });
            </script>
        </telerik:RadCodeBlock>
</asp:Content>
