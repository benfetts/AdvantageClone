<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="Webvantage.DefaultParent" Theme="Bootstrap" EnableEventValidation="false" %>

<%@ Register Src="DOS\DesktopCardsMySummary.ascx" TagName="SummaryCard" TagPrefix="webvantage" %>
<%@ Register Src="DOS\DesktopCardsMyCalendar.ascx" TagName="ScheduleCard" TagPrefix="webvantage" %>
<%@ Register Src="DOS\DesktopCardsMyBookmarks.ascx" TagName="BookmarkCard" TagPrefix="webvantage" %>
<%@ Register Src="DOS\DesktopCardsMyAssignments.ascx" TagName="AlertsAndAssignmentsCard" TagPrefix="webvantage" %>
<%@ Register Src="DOS\DesktopCardsMyTasks.ascx" TagName="TasksCard" TagPrefix="webvantage" %>
<!DOCTYPE html>
<html>
<head runat="server" id="ParentPageHead">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <meta name="msapplication-tap-highlight" content="no" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0" />
    <title>Aqua</title>
    <link rel="icon" href="favicon.ico" type="image/x-icon" />
    <script type="text/javascript" src="CSS/mfb/mfb.min.js"></script>
    <link type="text/css" href="CSS/mfb/mfb.min.css" rel="stylesheet" />
    <link type="text/css" rel="stylesheet" href="CSS/Material/Bootstrap.Cyan.min.css" id="MaterialCSSLink" runat="server" />
    <link type="text/css" rel="stylesheet" href="CSS/Common.css" />
    <link type="text/css" rel="stylesheet" href="CSS/UI_Styles.css" />
    <link type="text/css" rel="stylesheet" href="CSS/UI_Simple.css" />
    <link type="text/css" rel="stylesheet" href="CSS/CardLayout.css" />
    <link type="text/css" rel="stylesheet" href="CSS/CardLayout.Colors.css" />
    <script type="text/javascript" src="Scripts/jquery-3.6.0.min.js"></script>
    <script type="text/javascript" src="Jscripts/common.js"></script>
    <script type="text/javascript" src="Jscripts/UIHelper.js"></script>
    <script type="text/javascript" src="Scripts/sortable/Sortable.min.js"></script>
    <script type="text/javascript" src="Jscripts/coolclock.min.js"></script>
    <script type="text/javascript" src="Jscripts/moreskins.min.js"></script>
    <%--    <script type="text/javascript" src="Scripts/jquery.signalR-2.4.2.min.js"></script>
    <script src="signalr/hubs"></script>--%>
    <telerik:RadStyleSheetManager ID="RadStyleSheetManagerParent" runat="server" />
    <telerik:RadCodeBlock ID="RadCodeBlockParent" runat="server">
        <style type="text/css">
            .panelBackgroundColor {
                background-color: #FFFFFF !important;
            }
            .background-color {
                background-color: <%=Me.BackgroundColor%> !important;
            }
            .sidebarColor {
                background-color: <%=Me.sideBarBackgroundColor%> !important;
            }
            .card-bottom-header-bg {
                background-color: <%=Me.DarkHighlightColor%> !important;
            }
            .card-bottom-border {
                border-bottom: 4px solid #<%=Me.DarkHighlightColor%> !important;
            }
            .card-edge {
                border-bottom: 4px solid #<%=Me.DarkHighlightColor%> !important;
            }
            .sub-header-color {
                border-bottom: 1px solid <%=Me.DarkHighlightColor%> !important;
                color: <%=Me.DarkHighlightColor%> !important;
            }
            .dark-highlight-bg {
                background-color: <%=Me.DarkHighlightColor%> !important;
            }
            .dark-highlight-color {
                color: <%=Me.DarkHighlightColor%> !important;
            }
            .badge-outline-color {
                border-color: <%=Me.sideBarBackgroundColor%> !important;
            }
            .ew-title-color {
                background-color: <%=Me.DarkHighlightColor%> !important;
            }
            .bottom-shadow {
                -webkit-box-shadow: 0px 2px 2px 0px #b7b7b7;
                -moz-box-shadow: 0px 2px 2px 0px #b7b7b7;
                box-shadow: 0px 2px 2px 0px #b7b7b7;
            }
            .RadTreeView_Bootstrap .rtSelected .rtIn {
                color: #ffffff;
                background-color: <%=Me.DarkHighlightColor%> !important;
                border-color: <%=Me.DarkHighlightColor%> !important;
                font-style: italic !important;
            }

            .RadTreeView_Metro .rtSelected .rtIn {
                color: #ffffff;
                background-color: <%=Me.DarkHighlightColor%> !important;
                border-color: <%=Me.DarkHighlightColor%> !important;
                font-style: italic !important;
            }
           .rtPlus, .rtMinus
            {
            /*display: none !important;*/
            }
            .RadWindow_Bootstrap .rwControlButtons li a:hover {
                background-color: <%=Me.DarkHighlightColor%> !important;
                border-color: <%=Me.DarkHighlightColor%> !important;
            }
            .RadTreeView .rtLI {
                padding-bottom: 3px;
                font-size:16px !important;
                color: <%=Me.DarkHighlightColor%>  !important;
            }
            .RadTreeView .rtUL .rtUL {
                margin-top: 3px;
                color: <%=Me.SideBarBackgroundColor%>  !important;
                font-size: 20px !important;
            }
             .RadTreeView_Metro .rtLI {
                padding-bottom: 3px;
                font-size:16px !important;
                color: <%=Me.DarkHighlightColor%>  !important;
            }
             .RadTreeView_Metro .rtHover .rtIn {  
                color: #FFFFFF !important;                                                                    
                background-color: <%=Me.DarkHighlightColor%>  !important;
            }
            .RadTreeView_Metro .rtUL .rtUL {
                margin-top: 3px;
                color: <%=Me.SideBarBackgroundColor%>  !important;
                font-size: 20px !important;
            }
            .treeview-folder {
                background-color: <%=Me.DarkHighlightColor%> !important;
            }
            .treeview-folder-content {
                color: #FFFFFF !important;
            }
            /* Metro Override */
            .RadWindow_Metro {
                border-width: 2px 2px 2px 3px !important;
                border-style: solid !important;
                border-color: <%=Me.sideBarBackgroundColor%> !important;
            }
            .RadWindow_Metro .rwTopLeft,
            .RadWindow_Metro .rwTopRight,
            .RadWindow_Metro .rwTitlebar,
            .RadWindow_Metro .rwTopResize {
                background: <%=Me.sideBarBackgroundColor%> !important; 
            }
            .RadWindow_Metro .rwControlButtons a {
                background-image: url('App_Themes/Metro/Images/Window_CommandButtonSprites.png') !important;
                background-color: <%=Me.sideBarBackgroundColor%> !important;
                border: 1px solid <%=Me.sideBarBackgroundColor%> !important; 
            }
            hr.default-hr {
                border: 0;
                height: 1px;
                background:  <%=Me.DarkHighlightColor%> !important;
            }
            #ImageLogo {
                display: none;
            }
            .RadDock_Metro .rdMiddle .rdLeft,
            .RadDock_Metro .rdMiddle .rdRight {
                background-color: <%=Me.sideBarBackgroundColor%> !important;
                background:  <%=Me.sideBarBackgroundColor%> !important;
            }
            .RadDock_Metro .rdTop .rdLeft,
            .RadDock_Metro .rdTop .rdRight,
            .RadDock_Metro .rdTop .rdCenter,
            .RadDock_Metro .rdBottom .rdLeft,
            .RadDock_Metro .rdBottom .rdRight,
            .RadDock_Metro .rdBottom .rdCenter {
                background-color: <%=Me.sideBarBackgroundColor%> !important;
                background:  <%=Me.sideBarBackgroundColor%> !important;
            }
            .RadDock_Metro .rdCenter .rdCommands a span {
                background-image: url('App_Themes/Metro/Images/Dock_CommandSprite.png') !important;
                background-color: <%=Me.sideBarBackgroundColor%> !important;
            }
            .RadDock_Metro .rdTitleBar em {
                background:  <%=Me.sideBarBackgroundColor%> !important;
                background-color: <%=Me.sideBarBackgroundColor%> !important;
            }
            .RadNotification_Metro .rnTitleBar {
                background-color: <%=Me.sideBarBackgroundColor%> !important;
            }
            /*.RadWindow_Metro .rwCorner {
                width: 0px !important;
            }
            .RadWindow_Metro .rwBodyRight {
                width: 0px !important;
                padding-right: 0px !important;
                padding-left: 0px !important;
            }*/
        </style>
        <!-- Main Window Openers -->
        <script type="text/javascript">
            //#region MainOpeners
            function SetObjects() {
                manager = $find("RadWindowManagerParent");
                WorkspaceLogger = document.getElementById("HiddenFieldWorkspaceLogger");
                CurrentWindows = manager.get_windows();
            };
  
            function OpenRadWindow(WindowTitle, WindowURL, WindowHeight, WindowWidth, IsModal, WindowTop, WindowLeft, CenterIt, OpenerWindowName) {
                CheckSession();
                window.setTimeout(function () {
                    //console.log("OpenRadWindow", WindowURL)
                    _OpenRadWindow(WindowTitle, WindowURL, WindowHeight, WindowWidth, IsModal, WindowTop, WindowLeft, CenterIt, OpenerWindowName)
                }, 1);
            };
            function getViewport() {
                var viewPortWidth;
                var viewPortHeight;
                if (typeof window.innerWidth != "undefined") {
                    viewPortWidth = window.innerWidth,
                    viewPortHeight = window.innerHeight
                } else if (typeof document.documentElement != "undefined" && typeof document.documentElement.clientWidth != "undefined" && document.documentElement.clientWidth != 0) {
                    viewPortWidth = document.documentElement.clientWidth,
                    viewPortHeight = document.documentElement.clientHeight
                }
                else {
                    viewPortWidth = document.getElementsByTagName("body")[0].clientWidth,
                    viewPortHeight = document.getElementsByTagName("body")[0].clientHeight
                }
                return [viewPortWidth, viewPortHeight];
            }            
            function _OpenRadWindow(WindowTitle, WindowURL, WindowHeight, WindowWidth, IsModal, WindowTop, WindowLeft, CenterIt, OpenerWindowName) {
                window.setTimeout(function () {
                    //console.log("_OpenRadWindow")
                    SetObjects();
                    try {
                        var debug = '';
                        var hasHeight = false;
                        var hasWidth = false;
                        var hasTop = false;
                        var hasLeft = false;
                        var isMvcView = false;
                        debug += 'OpenRadWindow on mdi parent page called\n';
                        if (!WindowURL || WindowURL == '') {
                            alert('No page to navigate');
                            return false;
                        }
                        debug += 'WindowURL: ' + WindowURL + '\n';
                        var IsAuto = false;
                        if (WindowURL.indexOf('auto=1', 0) > -1) {
                            IsAuto = true;
                        };
                        if (typeof WindowTitle == 'undefined') {
                            WindowTitle = '';
                        };
                        if (typeof WindowHeight == 'undefined') {
                            WindowHeight = 600;
                        } else {
                            hasHeight = true;
                        };
                        if (typeof WindowWidth == 'undefined') {
                            //alert("no width");
                            WindowWidth = 1080;
                        } else {
                            hasWidth = true;
                        };
                        if (typeof WindowTop == 'undefined' || WindowTop == -1) {
                            //alert("no top")
                        } else {
                            hasTop = true;
                        };
                        if (typeof WindowLeft == 'undefined' || WindowLeft == -1) {
                            //alert("no left")
                        } else {
                            hasLeft = true;
                        };
                        if (typeof IsModal == 'undefined') {
                            IsModal = false;
                        };
                        if (typeof CenterIt == 'undefined') {
                            CenterIt = false;
                        };
                        var IsPleaseWait = false;
                        if (WindowURL.indexOf("PleaseWait.aspx", 0) > -1) {
                            IsPleaseWait = true;
                            CenterIt = true;
                        }
                        var IsCard = false;
                        if(WindowURL.toUpperCase().indexOf("DESKTOPCARD") > -1) {
                            IsCard = true;
                        };
                        var IsJobDashboard = false;
                        if(WindowURL.toUpperCase().indexOf("CONTENT.ASPX") > -1) {
                            IsJobDashboard = true;
                        };
                        var PageName;
                        var ar = new Array();
                        ar = WindowURL.split('.');
                        PageName = ar[0];
                        PageName = PageName.toUpperCase();
                        PageName = PageName.trim();
                        var IsDesktopObject = false;
                        if (PageName == 'DESKTOPOBJECTWINDOW') {
                            IsDesktopObject = true;
                        };
                        if (IsAuto == false) {
                            WindowHeight = GetWindowHeight(WindowURL, WindowHeight);
                            WindowWidth = GetWindowWidth(WindowURL, WindowWidth);
                        };
                        if (IsAuto == true && WindowHeight == 0) {
                            WindowHeight = GetWindowHeight(WindowURL, WindowHeight);
                        };
                        if (IsAuto == true && WindowWidth == 0) {
                            WindowWidth = GetWindowWidth(WindowURL, WindowWidth);
                        };
                        if (WindowHeight < 250) {
                            WindowHeight = 250;
                        };
                        if (typeof WindowTop == 'undefined') {
                            WindowTop = 0;
                        };
                        if (WindowTop == '') {
                            WindowTop = 0;
                        };
                        if (typeof WindowLeft == 'undefined') {
                            WindowLeft = ((window.innerWidth - WindowWidth) / 2);
                        };
                        if (WindowLeft == '') {
                            WindowLeft = ((window.innerWidth - WindowWidth) / 2);
                        };
                        WindowTop = WindowTop * 1;
                        WindowLeft = WindowLeft * 1;
                        if (WindowTop <= 0) {
                            WindowTop = 0;
                        };
                        if (WindowLeft <= 0) {
                            WindowLeft = ((window.innerWidth - WindowWidth) / 2);
                        };
                        if (IsCard == true && hasTop == false) {
                            WindowTop = 5;
                        };
                        if (IsCard == true && hasLeft == false) {
                            WindowLeft = 5;
                        };
                        if (WindowTop == 0) { WindowTop = 5; };
                        var HasWindowTitle;
                        if (WindowTitle.trim() == '') {
                            HasWindowTitle = false;
                        } else {
                            HasWindowTitle = true;
                        };
                        debug += 'Page name: ' + PageName + '\n';
                        var WindowIsAlreadyOpen;
                        WindowIsAlreadyOpen = false;
                        var ExistingWindowIndex;
                        ExistingWindowIndex = -1;
                        debug += 'CurrentWindows array length:  ' + CurrentWindows.length + '\n';
                        var mainContentHeight = $("#maincontent").height();
                        var mainContentWidth = $("#maincontent").width();
                        if (WindowHeight >= mainContentHeight || (IsCard == true && hasHeight == false)) {
                            WindowHeight = mainContentHeight - 10;
                        };
                        if (WindowWidth >= mainContentWidth) {
                            WindowWidth = mainContentWidth - 10;
                        };
                        if (IsDesktopObject == true) {
                            PageName = WindowURL;
                        };
                        if (OpenerWindowName != undefined) {
                            var WindowNameParam = '';
                            if (WindowURL.indexOf(".aspx?") > -1) {
                                WindowNameParam = "&opener=" + OpenerWindowName;
                            } else {
                                // handles MVC
                                if(WindowURL.indexOf('?') >-1){
                                    WindowNameParam = "&";
                                } else {
                                    WindowNameParam = "?";
                                }
                                WindowNameParam += "opener=" + OpenerWindowName;
                            };
                            WindowURL = WindowURL + WindowNameParam;
                        };
                        if (IsDesktopObject == true) {
                            if(WindowURL.toUpperCase().indexOf("DESKTOPCARDSMYBOOKMARKS") > -1) {
                                CenterIt = false;
                                WindowLeft = mainContentWidth - 370
                                WindowTop = 6
                            }
                        }
                        if (WindowURL.startsWith("/") == true) {
                            if (WindowURL.indexOf("//") > - 1) {
                                var ar = WindowURL.split("//")
                                WindowURL = ar[1];
                            }
                        }
                        if (CurrentWindows.length == 0) {
                            debug += 'Opening first window in manager\n';
                            var oWnd = manager.open(WindowURL, WindowTitle, null, WindowWidth, WindowHeight);
                            window.setTimeout(function () {
                                if (HasWindowTitle == true) {
                                    oWnd.set_title(WindowTitle);
                                };
                                if (excludeFromMaximize(WindowURL) == true) {
                                    if (WindowHeight > 0) {
                                        oWnd.set_height(WindowHeight);
                                    };
                                    if (WindowWidth > 0) {
                                        oWnd.set_width(WindowWidth);
                                    };
                                }
                                oWnd.set_modal(IsModal);
                                oWnd.setActive(true);
                                oWnd.set_destroyOnClose(true);
                                oWnd.add_beforeClose(radWindowBeforeCloseHandler);
                                //oWnd.set_behaviors(Telerik.Web.UI.WindowBehaviors.Close + Telerik.Web.UI.WindowBehaviors.Move + Telerik.Web.UI.WindowBehaviors.Resize + Telerik.Web.UI.WindowBehaviors.Minimize + Telerik.Web.UI.WindowBehaviors.Maximize);
                                if (excludeFromMaximize(WindowURL) == true) {
                                    if (CenterIt == true) {
                                        oWnd.set_top(((window.innerHeight - WindowHeight) / 2));
                                        oWnd.set_left(((window.innerWidth - WindowWidth) / 2));
                                        oWnd.moveTo(((window.innerWidth - WindowWidth) / 2), ((window.innerHeight - WindowHeight) / 2));
                                    } else {
                                        oWnd.set_top(WindowTop);
                                        oWnd.set_left(WindowLeft);
                                        oWnd.moveTo(WindowLeft, WindowTop);
                                    };
                                    oWnd.setSize(WindowWidth, WindowHeight);
                                } else {
                                    oWnd.maximize();
                                }
                                
                            }, 1);
                       } else {
                           //console.log("current page name", PageName.trim())
                            for (var i = 0; i < CurrentWindows.length; i++) {
                                var s;
                                s = CurrentWindows[i].get_navigateUrl();
                                if (IsDesktopObject == false) {
                                    if  (s.toUpperCase().indexOf("ALERT_VIEW.ASPX", 0) > -1 && s.indexOf("UI_Action.aspx", 0) == -1) {
                                        if (s.trim().toUpperCase() == WindowURL.trim().toUpperCase()){
                                            WindowIsAlreadyOpen = true;
                                            ExistingWindowIndex = i;
                                            debug += 'Window is open! Index is: ' + i + '\n';
                                            break;
                                        } else {
                                            WindowIsAlreadyOpen = false;
                                            break;
                                        }
                                    } else if (s.toUpperCase().indexOf("CHAT.ASPX", 0) > -1 && s.indexOf("UI_Action.aspx", 0) == -1) {
                                        if (s.trim().toUpperCase() == WindowURL.trim().toUpperCase()){
                                            WindowIsAlreadyOpen = true;
                                            ExistingWindowIndex = i;
                                            debug += 'Window is open! Index is: ' + i + '\n';
                                            break;
                                        } else {
                                            WindowIsAlreadyOpen = false;
                                            break;
                                        }
                                    } else {
                                        //console.log("window array url", i, s);
                                        var arCurr = new Array();
                                        arCurr = s.split('.');
                                        s = arCurr[0];
                                        s = s.toUpperCase();
                                        debug += s + '\n'
                                        if (s.toUpperCase().indexOf(PageName.trim()) > -1) {
                                            WindowIsAlreadyOpen = true;
                                            ExistingWindowIndex = i;
                                            debug += 'Window is open! Index is: ' + i + '\n';
                                            break;
                                        }
                                    }
                                } else {
                                    if (s.indexOf(PageName, 0) > -1 && s.indexOf("UI_Action.aspx", 0) == -1) {
                                        WindowIsAlreadyOpen = true;
                                        ExistingWindowIndex = i;
                                        debug += 'DO is open! Index is: ' + i + '\n';
                                        break;
                                    };
                                };
                                debug += '\n-------------------------------------------\n'
                            };
                            debug += '\n\n===============================\n\n'
                            if (WindowIsAlreadyOpen == false) {
                                debug += 'Opening a new window from default condition\n';
                                var oNewRadWindow = manager.open(WindowURL, WindowTitle, null, WindowWidth, WindowHeight);
                                window.setTimeout(function () {
                                    if (HasWindowTitle == true) {
                                        oNewRadWindow.set_title(WindowTitle);
                                    };
                                    oNewRadWindow.set_modal(IsModal);                     
                                    oNewRadWindow.setActive(true);
                                    oNewRadWindow.set_destroyOnClose(true);
                                    oNewRadWindow.add_beforeClose(radWindowBeforeCloseHandler);
                                    //oNewRadWindow.set_behaviors(Telerik.Web.UI.WindowBehaviors.Close + Telerik.Web.UI.WindowBehaviors.Move + Telerik.Web.UI.WindowBehaviors.Resize + Telerik.Web.UI.WindowBehaviors.Minimize + Telerik.Web.UI.WindowBehaviors.Maximize);
                                    if (excludeFromMaximize(WindowURL) == true) {
                                        if (CenterIt == true) {
                                            oNewRadWindow.set_top(((window.innerHeight - WindowHeight) / 2));
                                            oNewRadWindow.set_left(((window.innerWidth - WindowWidth) / 2));
                                            oNewRadWindow.moveTo(((window.innerWidth - WindowWidth) / 2), ((window.innerHeight - WindowHeight) / 2));
                                        } else {
                                            oNewRadWindow.set_top(WindowTop);
                                            oNewRadWindow.set_left(WindowLeft);
                                            oNewRadWindow.moveTo(WindowLeft, WindowTop);
                                        };
                                    } else {

                                        oNewRadWindow.maximize();
                                    }
                                    
                                }, 1);
                                ////oNewRadWindow.setSize(WindowWidth, WindowHeight);
                                
                                //oNewRadWindow.restore();
                            }
                            else if (WindowIsAlreadyOpen == true) {
                                window.setTimeout(function () {
                                    if (!CurrentWindows[ExistingWindowIndex]) {
                                        OpenRadWindow(WindowTitle, WindowURL, 0, 0, false);
                                    } else {
                                        CurrentWindows[ExistingWindowIndex].setUrl(WindowURL);
                                        CurrentWindows[ExistingWindowIndex].set_modal(IsModal);
                                        CurrentWindows[ExistingWindowIndex].setActive(true);
                                        CurrentWindows[ExistingWindowIndex].set_destroyOnClose(true);
                                        //CurrentWindows[ExistingWindowIndex].set_behaviors(Telerik.Web.UI.WindowBehaviors.Close + Telerik.Web.UI.WindowBehaviors.Move + Telerik.Web.UI.WindowBehaviors.Resize + Telerik.Web.UI.WindowBehaviors.Minimize + Telerik.Web.UI.WindowBehaviors.Maximize);
                                        if (CurrentWindows[ExistingWindowIndex].isMaximized() == true) {
                                            CurrentWindows[ExistingWindowIndex].restore();
                                            CurrentWindows[ExistingWindowIndex].moveTo(0, 0);
                                            CurrentWindows[ExistingWindowIndex].maximize();
                                        };
                                        if (CurrentWindows[ExistingWindowIndex].isMinimized() == true) {
                                            CurrentWindows[ExistingWindowIndex].restore();
                                        };
                                        if (CurrentWindows[ExistingWindowIndex].isVisible() == false) {
                                            CurrentWindows[ExistingWindowIndex].show();
                                        };
                                        CurrentWindows[ExistingWindowIndex].setActive(true);
                                        debug += 'not new window, reload window with new url\n';
                                    };
                                }, 1);
                            }
                            else {
                                debug += 'Opening a new window from else condition\n';
                                var oWnd = manager.open(WindowURL, WindowTitle, null, WindowWidth, WindowHeight);
                                window.setTimeout(function () {
                                    oWnd.set_modal(IsModal);
                                    oWnd.setActive(true);
                                    oWnd.set_destroyOnClose(true);
                                    oWnd.add_beforeClose(radWindowBeforeCloseHandler);
                                    //oWnd.set_behaviors(Telerik.Web.UI.WindowBehaviors.Close + Telerik.Web.UI.WindowBehaviors.Move + Telerik.Web.UI.WindowBehaviors.Resize + Telerik.Web.UI.WindowBehaviors.Minimize + Telerik.Web.UI.WindowBehaviors.Maximize);
                                    if (HasWindowTitle == true) {
                                        oNewRadWindow.set_title(WindowTitle);
                                    };
                                    if (excludeFromMaximize(WindowURL) == true) {
                                        if (CenterIt == true) {
                                            oWnd.set_top(((window.innerHeight - WindowHeight) / 2));
                                            oWnd.set_left(((window.innerWidth - WindowWidth) / 2));
                                            oWnd.moveTo(((window.innerWidth - WindowWidth) / 2), ((window.innerHeight - WindowHeight) / 2));
                                        } else {
                                            oWnd.set_top(WindowTop);
                                            oWnd.set_left(WindowLeft);
                                            oWnd.moveTo(WindowLeft, WindowTop);
                                        };
                                        oWnd.setSize(WindowWidth, WindowHeight);
                                        //oWnd.restore();
                                    } else {
                                        oWnd.maximize();
                                    }
                                }, 1);
                            };
                        };
                    }
                    catch (err) {
                        alert("Error opening window: " & err);
                    };
                }, 1);
            };
            function radWindowBeforeCloseHandler(sender, args) {
                if (sender.isMaximized() === true) {
                    if (sender.view) {
                        if (sender.view.resizeExtender) {
                            sender.view.resizeExtender = null;
                        }
                    }
                }
            }
            function FindWindow(WindowURL) {
                SetObjects();
                //console.log(WindowURL)
                if (CurrentWindows.length > 0) {
                    var debug = '';
                    var pageFound = false;
                    var contentPageFound = false;
                    for (var i = 0; i < CurrentWindows.length; i++) {
                        var PageName;
                        var WindowName;
                        var ar = new Array();
                        ar = WindowURL.split('.');
                        PageName = ar[0];
                        WindowName = ar[0];
                        PageName = PageName.toUpperCase();
                        var s;
                        //alert(s)
                        s = CurrentWindows[i].get_navigateUrl();
                        if (s.indexOf("Content.aspx") > -1) {
                            contentPageFound = true;
                        };
                        //console.log("s: " + s)
                        if (WindowURL.indexOf("/Sprint/") > -1 && s == "ProjectManagement/Agile/AgileBoards") {
                            pageFound = true;
                            return CurrentWindows[i];
                            break;
                        }
                        if (WindowURL.indexOf("Desktop_AlertView") > -1 && s.indexOf(WindowURL) > -1) {
                            pageFound = true;
                            return CurrentWindows[i];
                            break;
                        }
                        var arCurr = new Array();
                        arCurr = s.split('.');
                        if(arCurr.length === 1){
                            // handles MVC
                            arCurr = s.split('?') 
                            PageName = PageName.split('?')[0];
                        }
                        s = arCurr[0];
                        s = s.toUpperCase();
                        if (s.trim() == PageName.trim()) {
                            pageFound = true;
                            return CurrentWindows[i];
                            break;
                        };
                    };
                    if(pageFound == false && contentPageFound == true) {
                        ////alert("need to see if the window we're looking for is loaded into the content page iframe\n" + s);
                    };
                };
            };

            function OpenRadWindowLookup(WindowURL, OpenerWindowName, WindowHeight, WindowWidth) {
                try {
                    SetObjects();
                    if (typeof WindowURL == 'undefined') {
                        alert('No page to navigate');
                        return false;
                    };
                    if (typeof OpenerWindowName == 'undefined') {
                        OpenerWindowName = '';
                    };
                    if (typeof WindowHeight == 'undefined') {
                        WindowHeight = 0;
                    };
                    if (typeof WindowWidth == 'undefined') {
                        WindowWidth = 0;
                    };
                    //if (WindowHeight <= 0) {
                    WindowHeight = 700;
                    //};
                    //if (WindowWidth <= 0) {
                    WindowWidth = 620;
                    //};

                    //if (WindowURL.indexOf("LookUp_Recipients.aspx") > -1) {
                    //    WindowHeight = 425;
                    //}
                    //if (WindowURL.indexOf("LookUp_Vendor.aspx") > -1) {
                    //    WindowHeight = 540;
                    //}
                    if (WindowURL.indexOf("LookUp_AdNumber.aspx") > -1) {
                        WindowHeight = 600;
                        WindowWidth = 950;
                    };
                    var WindowNameParam = '';
                    if (WindowURL.indexOf(".aspx?") > -1) {
                        WindowNameParam = "&opener=" + OpenerWindowName;
                    } else {
                        if(WindowURL.indexOf("?") === -1){
                            WindowNameParam = "?";
                        } else {
                            WindowNameParam = "&";
                        }
                        WindowNameParam += "opener=" + OpenerWindowName;
                    };
                    //alert(OpenerWindowName);
                    var mainContentHeight = $("#maincontent").height();
                    var mainContentWidth = $("#maincontent").width();

                    if (WindowHeight >= mainContentHeight) {
                        WindowHeight = mainContentHeight - 10;
                    };
                    if (WindowWidth >= mainContentWidth) {
                        WindowWidth = mainContentWidth - 10;
                    };
                    
                    var oWnd = manager.open(WindowURL + WindowNameParam, "RadWindowLookup", null, WindowWidth, WindowHeight);
                    
                    window.setTimeout(function () {
                        oWnd.setActive(true);
                        oWnd.set_height(WindowHeight);
                        oWnd.set_width(WindowWidth);
                        oWnd.set_autoSizeBehaviors(Telerik.Web.UI.WindowAutoSizeBehaviors.Height);
                        oWnd.set_modal(true);
                        oWnd.set_visibleTitlebar(true);
                        oWnd.set_visibleStatusbar(true);
                        oWnd.set_behaviors(Telerik.Web.UI.WindowBehaviors.Resize + Telerik.Web.UI.WindowBehaviors.Move);
                        oWnd.set_destroyOnClose(true);
                        oWnd.moveTo(((window.innerWidth - WindowWidth) / 2), 0);

                    }, 1);
                } catch (err) {
                    alert("Error opening window\n" + err);
                }
            }

            //#endregion
        </script>
        <!-- Session Timer -->
        <script type="text/javascript">
            var extendSessionURL = '<%= Webvantage.Controllers.Utilities.ApplicationActionsController.BaseRoute %>ExtendSession';
            var sessionDuration = <%=Me.TimeoutMilliseconds%>;
            var SessionTime = 0;
            var tickDuration = 1000;
            SessionTime = sessionDuration;
            var myInterval = setInterval(function () {
                SessionTime = SessionTime - tickDuration
                try {
                    var timerLabel = document.getElementById("TimerLabel");
                    if (timerLabel && timerLabel != undefined) {
                        document.getElementById("TimerLabel").innerHTML = SessionTime;
                        if (SessionTime == 60000) {
                            extendSession();
                        }
                    }
                } catch(e){}
            }, 1000);
            var myTimeOut = setTimeout(SessionExpireEvent, SessionTime);
            function extendTimeout() {
                clearTimeout(myTimeOut);
                SessionTime = sessionDuration;
                myTimeOut = setTimeout(SessionExpireEvent, SessionTime);
            }
            function SessionExpireEvent() {
                alert('SessionExpireEvent');
                //clearInterval(myInterval);
                //SetObjects();
                //var oWnd = manager.open("SessionTimeout", "RadWindowSessionTimeout", null, 400, 210);
                //window.setTimeout(function () {
                //    oWnd.setActive(true);
                //    oWnd.set_autoSizeBehaviors(Telerik.Web.UI.WindowAutoSizeBehaviors.Height);
                //    oWnd.set_modal(true);
                //    oWnd.set_visibleTitlebar(false);
                //    oWnd.set_visibleStatusbar(false);
                //    oWnd.set_destroyOnClose(true);
                //}, 1);
            }
            function extendSession() {
                try {
                    window.setTimeout(function () {
                        $.ajax({
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            url: extendSessionURL, 
                            success: function (result) {
                                if(result) {
                                }
                            },
                            error: function (msg) {
                            }
                        });
                    }, 1);
                } catch(e) {
                }
            }
            function sessionEnded() {
                window.location.href = "SignIn.aspx";
            }
        </script>

        <!-- Alert Notification Window -->
        <script type="text/javascript">
            //#region Notify

            function OpenAlertNotifiy() {
                window.setTimeout(function () {
                    var FoundWnd = FindWindow('Alert_Notification.aspx');
                    if (FoundWnd) {
                        //FoundWnd.reload();
                        RefreshChildPageGrid('Alert_Notification.aspx');
                    }
                    else {
                        var mainContentHeight = $("#maincontent").height();
                        var mainContentWidth = $("#maincontent").width();
                        var w = 375;
                        var h = 200;
                        var t = 0;
                        var l = 0;
                        var buffer = 5;
                        t = mainContentHeight - h - buffer;
                        l = mainContentWidth - w - buffer;
                        var oWnd = manager.open('Alert_Notification.aspx', '', null, w, h);
                        oWnd.set_destroyOnClose(true);
                        oWnd.set_title('You have new Alerts');
                        oWnd.set_iconUrl('Images/blank.ico');
                        oWnd.set_behaviors(Telerik.Web.UI.WindowBehaviors.Close + Telerik.Web.UI.WindowBehaviors.Reload);
                        oWnd.set_height(h);
                        oWnd.set_width(w);
                        oWnd.set_top(t);
                        oWnd.set_left(l);
                        oWnd.moveTo(l, t);
                        oWnd.hide();
                    };
                }, 1);
            }
            function ShowAlertNotify() {
                console.log("ShowAlertNotify")
                var oWnd = FindWindow('Alert_Notification.aspx');
                oWnd.show();
            }
            function HideAlertNotify() {
                var oWnd = FindWindow('Alert_Notification.aspx');
                oWnd.hide();
            }
            function OpenStopwatchNotify() {
                window.setTimeout(function () {
                    var FoundWnd = FindWindow('Timesheet_Stopwatch.aspx');
                    if (FoundWnd) {
                        FoundWnd.reload();
                    }
                    else {
                        var mainContentHeight = $("#maincontent").height();
                        var mainContentWidth = $("#maincontent").width();
                        var w = 575;
                        var h = 475;
                        var t = 0;
                        var l = 0;
                        var buffer = 21;
                        t = 4;
                        l = mainContentWidth - w - buffer;
                        var oWnd = manager.open('Timesheet_Stopwatch.aspx', '', null, w, h);
                        oWnd.set_destroyOnClose(true);
                        oWnd.set_title('Timesheet Stopwatch');
                        oWnd.set_iconUrl('Images/blank.ico');
                        oWnd.set_behaviors(Telerik.Web.UI.WindowBehaviors.Close + Telerik.Web.UI.WindowBehaviors.Reload + Telerik.Web.UI.WindowBehaviors.Move + Telerik.Web.UI.WindowBehaviors.Minimize);
                        oWnd.set_height(h);
                        oWnd.set_width(w);
                        oWnd.set_top(t);
                        oWnd.set_left(l);
                        oWnd.moveTo(l, t);
                    };
                }, 1);
            }
            function OpenNotification() {
                try {
                    SetObjects();
                } catch (err) {
                    alert("Error opening window\n" + err);
                }
            }
            function ShowPleaseWait() {
                OpenRadWindow("", "PleaseWait.aspx", 0, 0, true);
            }
            function HidePleaseWait() {
                var oWnd = FindWindow("PleaseWait.aspx");
                if (oWnd) {
                    oWnd.close();
                }
            }

            //endregion
        </script>
        <!-- SignalR Windows -->
        <script type="text/javascript">
            function OpenChatWindow(chatURL) {
                if (chatEnabled && chatEnabled == true && chatURL) {
                    var chatWindow;
                    chatWindow = FindChatWindow(chatURL);
                    if (chatWindow) {
                        chatWindow.show();
                        chatWindow.restore();
                    } else {
                        OpenNewChatWindow(chatURL);
                    }
                }
            }
            function FindChatWindow(ChatWindowURL) {
                var chatWindow;
                if (chatEnabled && chatEnabled == true) {
                    var s = '';
                    SetObjects();
                    if (CurrentWindows.length > 0) {
                        for (var i = 0; i < CurrentWindows.length; i++) {
                            s = CurrentWindows[i].get_navigateUrl();
                            if (s && s.indexOf('Chat_Room.aspx', 0) > -1) {
                                //alert(s)
                                if (s.trim() == ChatWindowURL.trim()) {
                                    chatWindow = CurrentWindows[i];
                                    break;
                                }
                            }
                        }
                    }
                }
                return chatWindow;
            }
            function OpenNewChatWindow(chatURL) {
                if (chatEnabled && chatEnabled == true && chatURL) {
                    var mainContentHeight = $("#maincontent").height();
                    var mainContentWidth = $("#maincontent").width();
                    var w = 840;
                    var h = 555;
                    var t = 0;
                    var l = 0;
                    var buffer = 5;
                    t = mainContentHeight - h - buffer;
                    l = mainContentWidth - w - buffer;
                    var oWnd = manager.open(chatURL, '', null, w, h);
                    oWnd.set_destroyOnClose(true);
                    oWnd.set_title('Chat Room');
                    oWnd.set_iconUrl('Images/blank.ico');
                    oWnd.set_behaviors(Telerik.Web.UI.WindowBehaviors.Close + Telerik.Web.UI.WindowBehaviors.Move + Telerik.Web.UI.WindowBehaviors.Minimize + Telerik.Web.UI.WindowBehaviors.Resize);
                    oWnd.set_height(h);
                    oWnd.set_width(w);
                } else {
                    alert("No chat url");
                }
            }
            function RestoreChatWindow(chatURL) {
                if (chatEnabled && chatEnabled == true && chatURL) {
                    var chatWindow;
                    chatWindow = FindChatWindow(chatURL);
                    if (chatWindow) {
                        if(chatWindow.isMinimized() == true){
                            chatWindow.show();
                            chatWindow.restore();
                        }
                    } else {
                        OpenNewChatWindow(chatURL);
                    }
                }
            }
            // rooms
            function OpenChatRoomsWindow(show) {
                window.setTimeout(function () {
                var FoundWnd = FindWindow('Chat_Rooms.aspx');
                if (FoundWnd) {
                    if(show && show == true) {
                        FoundWnd.show();
                    } else {
                        FoundWnd.hide();
                    }
                } else {
                    var mainContentHeight = $("#maincontent").height();
                    var mainContentWidth = $("#maincontent").width();
                    var w = 636;
                    var h = 595;
                    var t = 0;
                    var l = 0;
                    var buffer = 5;
                    t = mainContentHeight - h - buffer;
                    l = mainContentWidth - w - buffer;
                    var oWnd = manager.open('Chat_Rooms.aspx', '', null, w, h);
                    oWnd.set_destroyOnClose(false);
                    oWnd.set_title('Chat');
                    oWnd.set_iconUrl('Images/blank.ico');
                    oWnd.set_behaviors(Telerik.Web.UI.WindowBehaviors.Close + Telerik.Web.UI.WindowBehaviors.Move + Telerik.Web.UI.WindowBehaviors.Resize);
                    oWnd.set_height(h);
                    oWnd.set_width(w);
                    oWnd.set_top(t);
                    oWnd.set_left(l);
                    oWnd.moveTo(l, t);
                    oWnd.set_reloadOnShow(true);
                    oWnd.set_showContentDuringLoad(false);
                    if (show != undefined) {
                        if (show == true) {
                            oWnd.show();
                        } else {
                            oWnd.hide();
                        }
                    } else {
                        oWnd.hide();
                    }
                    };
                }, 1);
            }
            function ShowChatRoomsWindow() {
                var oWnd = FindWindow('Chat_Rooms.aspx');
                if (oWnd){
                    oWnd.show();
                } else {
                    OpenChatRoomsWindow(true);
                }
            }
            function HideChatRoomsWindow() {
                var oWnd = FindWindow('Chat_Rooms.aspx');
                if (oWnd){
                    oWnd.hide();
                }
            }
            // alert comments
            function RefreshAlertCommentWindow(AlertCommentWindowURL) {
                if(AlertCommentWindowURL){
                    var AlertCommentWindow;
                    AlertCommentWindow = FindAlertCommentWindow();
                    if (AlertCommentWindow) {
                        AlertCommentWindow.show();
                        AlertCommentWindow.restore();
                    }
                }
            }
            function FindAlertCommentWindow(AlertCommentWindowURL) {
                var alertCommentWindow;
                var s = '';
                SetObjects();
                if (CurrentWindows.length > 0) {
                    for (var i = 0; i < CurrentWindows.length; i++) {
                        s = CurrentWindows[i].get_navigateUrl();
                        if (s && s.indexOf('Alert_Comments.aspx', 0) > -1) {
                            //alert(s)
                            if (s.trim() == AlertCommentWindowURL.trim()) {
                                alertCommentWindow = CurrentWindows[i];
                                break;
                            }
                        }
                    }
                }
                return alertCommentWindow;
            }
        </script>
        <!-- Page methods/Ajax -->
        <script type="text/javascript">

            var isDashboard = false;
            isDashboard = <%= Me._IsDefaultWorkspace.ToString().ToLower() %>;

            function checkForMissingDeniedTime() {
                console.log("checkForMissingDeniedTime")
                try {
                    window.setTimeout(function () {
                        $.ajax({
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            url: '<%= Webvantage.Controllers.Employee.TimesheetController.BaseRoute %>CheckForMissingDeniedTime', 
                            success: function (result) {
                                var divPanel = $("#DivTimeWarnings");
                                if(result && result != "") {
                                    var divButton = $("#DivMissingTime");
                                    var imageButton = $("#ImageButtonMissingTime");
                                    divButton.attr("title", result);
                                    imageButton.attr("title", result);
                                    divPanel.show();
                                } else {
                                    divPanel.hide();
                                }
                            },
                            error: function (msg) {
                            }
                        });
                    }, 1);
                } catch(e) {
                }
            }
            function updateAlertAssignmentTaskCount() {
               console.log("updateAlertAssignmentTaskCount")
               try {
                    //alert("updateAlertAssignmentTaskCount()")
                    window.setTimeout(function () {
                        $.ajax({
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            url: '<%= Webvantage.Controllers.Utilities.ApplicationActionsController.BaseRoute %>UpdateAlertAssignmentTaskCount', 
                            //dataType: "json",
                            //data: JSON.stringify(data),  LabelDefaultWorkspaceReviewCount
                            success: function (result) {
                                if(result) {
                                    if (isDashboard == true) {
                                        $("#LabelDefaultWorkspaceAssignmentCount").text(result.AssignmentCount);
                                        $("#LabelDefaultWorkspaceAlertCount").text(result.AlertCount);
                                        $("#LabelDefaultWorkspaceReviewCount").text(result.ReviewCount);
                                        $("#LabelDefaultWorkspaceTaskCount").text(result.TaskCount);
                                    } else {
                                        $("#LabelUserPanelAssignmentCount").text(result.AssignmentCount);
                                        $("#LabelUserPanelAlertCount").text(result.AlertCount);
                                        $("#LabelUserPanelReviewCount").text(result.ReviewCount);
                                        $("#LabelUserPanelTaskCount").text(result.TaskCount);
                                    }
                                }
                            },
                            error: function (msg) {
                            }
                        });
                    }, 1);
                } catch(e) {
                }
            }
            function updateAssignmentCount() {
                console.log("updateAssignmentCount")
                //alert("updateAssignmentCount()")
                window.setTimeout(function () {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        url: '<%= Webvantage.Controllers.Utilities.ApplicationActionsController.BaseRoute %>UpdateAssignmentCount', 
                        //dataType: "json",
                        //data: JSON.stringify(data),
                        success: function (result) {
                            if(result && isNaN(result) == false) {
                                if (isDashboard == true) {
                                    $("#LabelDefaultWorkspaceAssignmentCount").text(result);
                                } else {
                                    $("#LabelUserPanelAssignmentCount").text(result);
                                }
                                //alert(result);
                            }
                        },
                        error: function (msg) {
                        }
                    });
                }, 250);
            }
            function updateAlertCount() {
                console.log("updateAlertCount")
                window.setTimeout(function () {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        url: '<%= Webvantage.Controllers.Utilities.ApplicationActionsController.BaseRoute %>UpdateAlertCount', 
                        //dataType: "json",
                        //data: JSON.stringify(data),
                        success: function (result) {
                            if(result && isNaN(result) == false) {
                                if (isDashboard == true) {
                                    $("#LabelDefaultWorkspaceAlertCount").text(result);
                                } else {
                                    $("#LabelUserPanelAlertCount").text(result);
                                }
                            }
                            //alert(result);
                        },
                        error: function (msg) {
                        }
                    });
                }, 250);
            }
            function updateReviewCount() {
                console.log("updateReviewCount")
                window.setTimeout(function () {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        url: '<%= Webvantage.Controllers.Utilities.ApplicationActionsController.BaseRoute %>UpdateReviewCount', 
                        //dataType: "json",
                        //data: JSON.stringify(data),
                        success: function (result) {
                            if(result && isNaN(result) == false) {
                                if (isDashboard == true) {
                                    $("#LabelDefaultWorkspaceReviewCount").text(result);
                                } else {
                                    $("#LabelUserPanelReviewCount").text(result);
                                }
                            }
                            //alert(result);
                        },
                        error: function (msg) {
                        }
                    });
                }, 250);
            }
            function checkForBookmarks() {
                window.setTimeout(function () {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        url: '<%= Webvantage.Controllers.Utilities.ApplicationActionsController.BaseRoute %>CheckForBookmarks',
                        //dataType: "json",
                        //data: JSON.stringify(data),
                        success: function (result) {
                            var showBookmarkIcon = false;
                            if (result && result === true) {
                                showBookmarkIcon = true;
                            }
                            if (showBookmarkIcon) {
                                $('#ImageButtonBookmarks').show();
                            } else {
                                $('#ImageButtonBookmarks').hide();
                            }
                        },
                        error: function (msg) {
                        }
                    });
                }, 250);
            }

            function updateTaskCount() {
                //alert("updateAssignmentCount()")
               console.log("updateTaskCount")
               window.setTimeout(function () {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        url: '<%= Webvantage.Controllers.Utilities.ApplicationActionsController.BaseRoute %>UpdateTaskCount', 
                        //dataType: "json",
                        //data: JSON.stringify(data),
                        success: function (result) {
                            if(result && isNaN(result) == false) {
                                if (isDashboard == true) {
                                    $("#LabelDefaultWorkspaceTaskCount").text(result);
                                } else {
                                    $("#LabelUserPanelTaskCount").text(result);
                                }
                            }
                        },
                        error: function (msg) {
                        }
                    });
                }, 250);
            }
            function updateTimeCounts() {
                //alert("updateTimeCounts()")
               console.log("updateTimeCounts")
               window.setTimeout(function () {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        url: '<%= Webvantage.Controllers.Utilities.ApplicationActionsController.BaseRoute %>UpdateHoursCount', 
                        //dataType: "json",
                        //data: JSON.stringify(data),
                        success: function (result) {
                            if(result) {
                                if (isDashboard == true) {
                                    var radRadialGaugeHoursToday = $find("<%=RadRadialGaugeHoursToday.ClientID %>");
                                    var radRadialGaugeHoursThisWeek = $find("<%=RadRadialGaugeHoursThisWeek.ClientID %>");
                                    var kendoRadialGaugeHoursToday = radRadialGaugeHoursToday.get_kendoWidget();
                                    var kendoRadialGaugeHoursThisWeek = radRadialGaugeHoursThisWeek.get_kendoWidget();
                                    if(radRadialGaugeHoursToday && kendoRadialGaugeHoursToday) {
                                        radRadialGaugeHoursToday.set_value(result.HoursToday);
                                    }
                                    if(radRadialGaugeHoursThisWeek && kendoRadialGaugeHoursThisWeek) {
                                        radRadialGaugeHoursThisWeek.set_value(result.HoursThisWeek);
                                    }
                                } else {
                                    $("#LabelUserPanelTimeCount").text(result.HoursToday);
                                }
                                try {
                                    if(result.HasMissingOrDeniedTime != undefined && result.HasMissingOrDeniedTime == false){
                                        var divTimeWarnings = $("#DivTimeWarnings");
                                        if (divTimeWarnings != undefined) {
                                            divTimeWarnings.hide();
                                        }
                                    } else {
                                        //alert("Missing time") 
                                    }
                                } catch(e){
                                }
                            }
                        },
                        error: function (msg) {
                        }
                    });
                }, 250);
            }
        </script>
        <!-- Refresh -->
        <script type="text/javascript">
            //#region Refresh

            var isDashboard = false;
            var contentInView = '';
            var isFloatingObjects = true;

            isDashboard = <%=Me._IsDefaultWorkspace.ToString().ToLower()%>;
            contentInView = '<%=Me._CurrentDefaultContent.ToString()%>';
            isFloatingObjects = <%=Me._IsFloatingObjects.ToString().ToLower()%>;

            function RefreshPage(radWindowCaller) {
                location.reload(true);
            }
            function RefreshParentPage() {
                location.reload(true);
            }

            function BillingApprovalBatchCreated() {
                RefreshChildPageGrid("BillingApproval_View.aspx");
                RefreshChildPageGrid("BillingApproval_View_Approvals.aspx");
            }

            function realWindowUrl(url) {
                // determines MVC or aspx base page url
                if (url.toUpperCase().indexOf('.ASPX') > -1) {
                    return url.split('.')[0];
                } else {
                    return url.split('?')[0];
                }
            }
            function RefreshWindowWithNewURL(OldURL, NewURL) {
                var window = FindWindow(OldURL)
                if (window) {
                    window.setUrl(NewURL);
                }
            }
            function RefreshWindow(WindowURL, ForceNewURL, OpenWindowIfNotFound) {
                window.setTimeout(function () {
                    _RefreshWindow(WindowURL, ForceNewURL, OpenWindowIfNotFound);
                   console.log("RefreshWindow")
                }, 50);
            }
            function _RefreshWindow(WindowURL, ForceNewURL, OpenWindowIfNotFound) {
                SetObjects();
                if (typeof ForceNewURL == 'undefined') {
                    ForceNewURL = false;
                }
                if (typeof OpenWindowIfNotFound == 'undefined') {
                    OpenWindowIfNotFound = true;
                }
                var PageFound = false;
                var GoToURL = '';
                var fullURL;
                //console.log(CurrentWindows)
                //console.log(WindowURL)
                if (CurrentWindows.length > 0) {
                    var debug = '';
                    for (var i = 0; i < CurrentWindows.length; i++) {
                        console.log(CurrentWindows[i].get_navigateUrl())
                        if (WindowURL.toUpperCase().indexOf('.ASPX') == - 1 && WindowURL.toUpperCase().indexOf('.HTM') == - 1) {
                            if (CurrentWindows[i].get_navigateUrl().indexOf(WindowURL) > -1) {
                                PageFound = true;
                                fullURL = CurrentWindows[i].get_navigateUrl();
                                break;
                            }
                        } else {
                            var PageName = '';
                            var WindowName = '';
                            var RefreshFunction = null;
                            var ar = new Array();
                            if(typeof WindowURL === 'object'){
                                PageName = realWindowUrl(WindowURL.pageName); //WindowURL.pageName.split('.')[0];
                                WindowName = realWindowUrl(WindowURL.pageName); //WindowURL.pageName.split('.')[0];
                                RefreshFunction = WindowURL.refreshFunction;
                                fullURL = WindowURL.pageName;
                                if (WindowURL.query) {
                                    if (fullURL.indexOf('?') === -1 && WindowURL.query.indexOf('?') !== 0) {
                                        fullURL += '?';
                                    }
                                    fullURL += WindowURL.query;
                                }
                            } else {
                                //ar = WindowURL.split('.');
                                PageName = realWindowUrl(WindowURL); //ar[0];
                                WindowName = realWindowUrl(WindowURL); //ar[0];
                                PageName = PageName.toUpperCase();
                                fullURL = WindowURL;
                            }
                            PageName = PageName.toUpperCase();
                            var s;
                            s = CurrentWindows[i].get_navigateUrl();
                            if (s.indexOf("Content.aspx") > -1 && fullURL.indexOf("popContacts.aspx") == -1) {
                                var contentWindow = CurrentWindows[i].get_contentFrame().contentWindow;
                                if(contentWindow.CurrentContentUrl().toUpperCase().indexOf(PageName) > -1) {
                                    if(RefreshFunction) {
                                        contentWindow.CallContentFunction(RefreshFunction);
                                    } else if(ForceNewURL === true){
                                        if(fullURL.indexOf('jd=1') === -1){
                                            fullURL += '&jd=1'
                                        }
                                        contentWindow.RefreshContent(fullURL);
                                    } else {
                                        contentWindow.Refresh();
                                    }
                                }                            
                            };
                            var arCurr = new Array();
                            arCurr = s.split('.');
                            s = arCurr[0];
                            s = s.toUpperCase();
                            if (s.trim() == PageName.trim()) {
                                PageFound = true;
                                break;
                            };
                        }
                    };
                    if (PageFound == true) {
                        if (ForceNewURL == true) {
                            GoToURL = fullURL;
                        }
                        else {
                            GoToURL = CurrentWindows[i].get_navigateUrl();
                        };
                        OpenRadWindow(CurrentWindows[i].get_name(), GoToURL, CurrentWindows[i].get_height(), CurrentWindows[i].get_width(), false, 0, 0, false, "");
                    } else {

                        if (OpenWindowIfNotFound == true) {
                            OpenRadWindow('', fullURL, 650, 1000, false, 0, 0, false, "");
                        };

                    };
                } 
                else {
                    if (OpenWindowIfNotFound == true) {
                        OpenRadWindow('', WindowURL, 650, 1000, false, 0, 0, false, "");
                    };
                };
            };

            function RefreshInOutBoardObjects(CurrentObjectName) {
                if (CurrentObjectName != 'DesktopInOutBoard') {
                    RefreshDesktopObjectGrid('DesktopInOutBoard.ascx');
                };
                if (CurrentObjectName != 'DesktopInOutBoardAll') {
                    RefreshDesktopObjectGrid('DesktopInOutBoardAll.ascx');
                };
                //if (CurrentObjectName != 'DesktopAlerts') {
                //    RefreshDesktopObjectGrid('DesktopAlerts.ascx');
                //};
            };

            function RefreshJobRequestObjects(CurrentObjectName) {
                if (CurrentObjectName != 'DesktopMyJobRequests') {
                    RefreshDesktopObjectGrid('DesktopMyJobRequests.ascx');
                };
                if (CurrentObjectName != 'DesktopJobRequests') {
                    RefreshDesktopObjectGrid('DesktopJobRequests.ascx');
                };
                if (isDashboard == false){
                    if (isFloatingObjects == false) {
                        __doPostBack("UpdatePanelRadDock","");
                    }                   
                }
                RefreshChildPageGrid('JobRequest_Search.aspx');
            };

            function RefreshTimesheetWindows() {
                window.setTimeout(function () {
                    _RefreshTimesheetWindows();
                    RefreshTimesheetDTO();
                    RefreshTimesheet();
                    checkForMissingDeniedTime();
                }, 250);
            };
            function _RefreshTimesheetWindows() {
                console.log("_RefreshTimesheetWindows")
                SetObjects();
                var GoToURL = '';
                if (CurrentWindows.length > 0) {
                    var debug = '';
                    for (var i = 0; i < CurrentWindows.length; i++) {
                        var s;
                        s = CurrentWindows[i].get_navigateUrl();
                        if (
                             s.indexOf('Timesheet_Details.aspx', 0) > -1 ||
                             s.indexOf('Timesheet_CommentsView.aspx', 0) > -1
                            ) {
                            if (s.indexOf('UI_Action.aspx') == -1) {
                                GoToURL = CurrentWindows[i].get_navigateUrl();
                                OpenRadWindow(CurrentWindows[i].get_name(), GoToURL, CurrentWindows[i].get_height(), CurrentWindows[i].get_width(), false);
                            };
                        };
                    };
                };
            };
            function RefreshTimesheet() {
                RefreshChildPageGrid('Timesheet.aspx');
            };
            function RefreshTimesheetDTO() {
                RefreshDesktopObjectGrid('DesktopTimesheet.ascx');
                RefreshDesktopObjectGrid('DesktopWeeklyTimegraph.ascx');
                updateTimeCounts();
            };

            function RefreshBookmarksDTO() {
                window.setTimeout(function () {
                    _RefreshBookmarksDTO();
                }, 250);
            };
            function _RefreshBookmarksDTO() {
                SetObjects();
                var GoToURL = '';
                var OldBookmarkWindowFound = false;
                var BookmarkCardWindowFound = false;
                checkForBookmarks();
                if (CurrentWindows.length > 0) {
                    var debug = '';
                    for (var i = 0; i < CurrentWindows.length; i++) {
                        var s;
                        s = CurrentWindows[i].get_navigateUrl();
                        if (s.indexOf('DesktopBookmarks.ascx', 0) > -1) {
                            if (s.indexOf('UI_Action.aspx') == -1) {
                                GoToURL = CurrentWindows[i].get_navigateUrl();
                                OpenRadWindow("Bookmarks", GoToURL, CurrentWindows[i].get_height(), CurrentWindows[i].get_width(), false);
                                OldBookmarkWindowFound = true;
                                break;
                            };
                        };
                        //if (s.indexOf('DesktopCardsMyBookmarks.ascx', 0) > -1) {
                        //    if (s.indexOf('UI_Action.aspx') == -1) {
                        //        GoToURL = CurrentWindows[i].get_navigateUrl();
                        //        OpenRadWindow("Bookmarks", GoToURL, CurrentWindows[i].get_height(), CurrentWindows[i].get_width(), false);
                        //        BookmarkCardWindowFound = true;
                        //        break;
                        //    };
                        //};
                    };
                    //if (OldBookmarkWindowFound == false && BookmarkCardWindowFound == false) {
                    //    GoToURL = 'DesktopObjectWindow.aspx?dtoname=DesktopBookmarks.ascx';
                    //    OpenRadWindow('Bookmarks', GoToURL, 500, 275, false);
                    //};
                };
                //////////var button = $("[id$='ImageButtonRefreshDesktopCardsMyBookmarks']");
                //////////if(button){
                //////////    button.click();
                //////////}
            };

            function RefreshAlertsDTO() {
                if (isFloatingObjects == true) {
                    console.log("RefreshAlertsDTO")
                    RefreshDesktopObjectGrid('DesktopAlerts.ascx');
                }
            };
            function RefreshAlertInbox() {
                console.log("RefreshAlertInbox")
                RefreshChildPageGrid('Alert_Inbox.aspx');
            };
            function RefreshJobRequest() {
                RefreshChildPageGrid('JobRequest_Search.aspx');
            };
            function RefreshDashboardReviews() {
                if (isDashboard == true && contentInView == "MyReviews"){
                    reloadDefaultWorkspaceLeftMiddle();
                }
            }
            function RefreshAlertWindows(updateAlertDO, updateAlertInbox, updateDashboard) {
                console.log("RefreshAlertWindows")
                //OpenAlertNotifiy();
                __doPostBack("UpdatePanelUserSummary","");
                updateAssignmentCount();
                updateAlertCount();
                updateReviewCount();
                if (isDashboard == false){
                    if (isFloatingObjects == false) {
                        __doPostBack("UpdatePanelRadDock","");
                    }
                }
                if ((updateDashboard && updateDashboard == true) || updateDashboard == undefined) {
                    if (isDashboard == true && (contentInView == "MyAssignments" || contentInView == "MyAlerts" || contentInView == "MyReviews")) {
                        reloadDefaultWorkspaceLeftMiddle();
                    }
                }
                if (updateAlertInbox && updateAlertInbox == true) {
                    RefreshAlertInbox();
                }
                if (updateAlertDO && updateAlertDO == true) {
                    RefreshAlertsDTO();
                }
                RefreshChildPageGrid('Alert_List.aspx');
            };
            function RefreshAlertThingsOnAlertClose() {
                //OpenAlertNotifiy();
                if (isDashboard == false){
                    if (isFloatingObjects == false) {
                        __doPostBack("UpdatePanelRadDock","");
                    }
                }
                if (isDashboard == true && (contentInView == "MyAssignments" || contentInView == "MyAlerts" || contentInView == "MyReviews")) {
                    reloadDefaultWorkspaceLeftMiddle();
                }
                RefreshAlertInbox();
                RefreshAlertsDTO();
                RefreshChildPageGrid('Alert_List.aspx');
           }
            function RefreshProjectScheduleGrid() {
                RefreshChildPageGrid("<%= Webvantage.Controllers.ProjectManagement.ProjectScheduleController.BaseRoute %>Index");
            };
            function RefreshDesktopObjectGrid(UserControlName) {
                window.setTimeout(function () {
                    _RefreshDesktopObjectGrid(UserControlName);
                }, 250);
            };
            function _RefreshDesktopObjectGrid(UserControlName) {
                SetObjects();
                var GoToURL = '';
                var WindowFound = false;
                if (CurrentWindows.length > 0) {
                    var debug = '';
                    for (var i = 0; i < CurrentWindows.length; i++) {
                        var s;
                        s = CurrentWindows[i].get_navigateUrl();
                        if (s.indexOf(UserControlName, 0) > -1) {
                            if (s.indexOf('UI_Action.aspx') == -1) {
                                var FoundWnd = CurrentWindows[i]
                                if (FoundWnd) {
                                    FoundWnd.get_contentFrame().contentWindow.RebindGrid()
                                };
                                WindowFound = true;
                                break;
                            };
                        };
                    };
                };
            };

            function RefreshDesktopObjectPage(UserControlName) {
                SetObjects();
                var GoToURL = '';
                var WindowFound = false;
                if (CurrentWindows.length > 0) {
                    var debug = '';
                    for (var i = 0; i < CurrentWindows.length; i++) {
                        var s;
                        s = CurrentWindows[i].get_navigateUrl();
                        if (s.indexOf(UserControlName, 0) > -1) {
                            if (s.indexOf('UI_Action.aspx') == -1) {
                                var FoundWnd = CurrentWindows[i]
                                if (FoundWnd) {
                                    FoundWnd.get_contentFrame().contentWindow.ReloadPage()
                                };
                                WindowFound = true;
                                break;
                            };
                        };
                    };
                };
            };

            function RefreshChildPage(PageName) {
                window.setTimeout(function () {
                    _RefreshChildPage(PageName);
                }, 350);
            };
            function _RefreshChildPage(PageName) {
                var FoundWnd = FindWindow(PageName);
                if (FoundWnd) {
                    console.log("_RefreshChildPage")
                    FoundWnd.get_contentFrame().contentWindow.Refresh();
                };
            };

            function RefreshChildPageGrid(PageName) {
                //alert("RefreshChildPageGrid")
                window.setTimeout(function () {
                    _RefreshChildPageGrid(PageName);
                }, 350);
            };
            function _RefreshChildPageGrid(PageName) {
                //alert("_RefreshChildPageGrid")
                var FoundWnd = FindWindow(PageName);
                if (FoundWnd) {
                    //var s;
                    //s = FoundWnd.get_navigateUrl();
                    //if (s.indexOf("Content.aspx") > -1) {
                    //    var CallingWindowContent = FoundWnd.get_contentFrame().contentWindow;
                    //    alert(CallingWindowContent.location.href)
                    //    //var ContentPageHiddenField = CallingWindowContent.document.getElementById("ctl00_ContentPlaceHolderMain_ContentPageHiddenFieldLookupPassthrough");
                    //    //if (ContentPageHiddenField) {
                    //    //    //cts = controlsToSet;
                    //    //    //ContentPageHiddenField.value = cts;
                    //    //    //CallingWindowContent.setIFrameContentControls();

                    //    //};
                    //} else {
                    FoundWnd.get_contentFrame().contentWindow.RebindGrid();
                    //};
                };
            };
            function RefreshAlertRecipients() {
                var FoundWnd = FindWindow("Alert_View.aspx");
                if (FoundWnd) {
                    FoundWnd.get_contentFrame().contentWindow.RefreshAlertRecipients();
                };
            };
            function RefreshDashboardCalendar() {
                if (isDashboard == true) {
                    __doPostBack("UpdatePanelRight","");
                }
                var button = $("[id$='ImageButtonRefreshDesktopCardsMyCalendar']");
                if(button){
                    button.click();
                }
                return false;
            };
            function RefreshDefaultWorkspaceMainContent() {
                    console.log("RefreshDefaultWorkspaceMainContent")
                    reloadDefaultWorkspaceLeftMiddle();
                return false;
            };
            function RefreshContentPage() {
                var FoundWnd = FindWindow("Content.aspx");
                if (FoundWnd) {
                    var s;
                    s = FoundWnd.get_navigateUrl();
                    console.log("RefreshContentPage (PMD)")
                    FoundWnd.get_contentFrame().contentWindow.Refresh();
                };
            };
            function RefreshTasks() {
                updateTaskCount();
                if (isDashboard == true && contentInView == "MyTasks"){
                    reloadDefaultWorkspaceLeftMiddle();
                }  
                __doPostBack("UpdatePanelUserSummary","");
                var button = $("[id$='ImageButtonRefreshDesktopCardsMyTasks']");
                if(button){
                    button.click();
                }               
            };
            function refreshSprint(sprintId, sprintIsActive, sprintIsComplete, employeeName) {
                var FoundWnd = FindWindow("/Sprint/" + sprintId);
                if (FoundWnd) {
                    console.log("refreshSprint")
                    FoundWnd.get_contentFrame().contentWindow.pushSprintRefresh(sprintId, sprintIsActive, sprintIsComplete, employeeName);
                }
            }
            function refreshNewAlertView(alertId, sprintId, employeeName) {
                //console.log("refreshNewAlertView")
                var FoundWnd = FindWindow("Desktop_AlertView?AlertID=" + alertId);
                if (FoundWnd) {
                    //console.log("refreshNewAlertView: window found")
                    var content = FoundWnd.get_contentFrame().contentWindow;
                    if (content && content.MvcRefreshNewAlertViewBridge) {
                        console.log("refreshNewAlertView")
                        //console.log("refreshNewAlertView, MvcRefreshNewAlertViewBridge")
                        content.MvcRefreshNewAlertViewBridge(alertId, sprintId, employeeName)
                    }
                }
            }

            function refreshDashboardWorkItems() {
                updateAssignmentCount();
                updateTaskCount();
                if (isDashboard == true && (contentInView == "MyAssignments" || contentInView == "MyTasks")) {
                    console.log("refreshDashboardWorkItems")
                    reloadDefaultWorkspaceLeftMiddle();
                }
            }
            //endregion
        </script>
        <!-- UI Action Window -->
        <script type="text/javascript">
            //# region UIAction
            function OpenUiActionWindow() {
                window.setTimeout(function () {
                    var oWnd = manager.open('UI_Action.aspx?action=0', '');
                    oWnd.set_destroyOnClose(false);
                    oWnd.hide();
                }, 10);
            }
            function CallUiAction(actionId, val, extraQS) {
                window.setTimeout(function () {
                    SetObjects();
                    var qs = "";
                    if (val && val != "") {
                        qs = qs + "&val=" + val;
                    }
                    if (extraQS && extraQS != "") {
                        qs = qs + "&" + extraQS;
                    }
                    var url = "";
                    url = 'UI_Action.aspx?action=' + actionId + qs;
                    var UiActionWindow;
                    var s = '';
                    SetObjects();
                    if (CurrentWindows.length > 0) {
                        for (var i = 0; i < CurrentWindows.length; i++) {
                            s = CurrentWindows[i].get_navigateUrl();
                            if (s && s.indexOf('UI_Action.aspx', 0) > -1) {
                                UiActionWindow = CurrentWindows[i];
                                break;
                            }
                        }
                    }
                    if (!UiActionWindow){
                        UiActionWindow = manager.open('UI_Action.aspx?action=0', '');
                        UiActionWindow.set_destroyOnClose(false);
                        UiActionWindow.hide();
                    }
                    if (UiActionWindow){
                        UiActionWindow.setUrl(url);
                        UiActionWindow.hide();
                    }
                }, 1);
            };
            function ResetTimesheetEmpCode() {
                CallUiAction(2, "", "");
            };
            function MarkAllEmailAsRead() {
                CallUiAction(3, "", "");
            };
            function ResetTimesheetCommentView() {
                CallUiAction(4, "", "");
            };
            function ResetDynamicReportSessionVariables() {
                CallUiAction(6, "", "");
            };
            function ResetAlertInboxPageIndex() {
                CallUiAction(9, "", "");
            };
            function SetTimesheetEntryFromMainMenu() {
                CallUiAction(10, "", "");
            };
            function GetDocumentRepositoryDocument(DocumentId) {
                CallUiAction(11, DocumentId, "");
            };
            function ResetContractSessionVariables() {
                CallUiAction(12, "", "");
            };
            function ResetDivisionEditSessionVariables() {
                CallUiAction(13, "", "");
            };
            function ResetClientEditSessionVariables() {
                CallUiAction(14, "", "");
            };
            function ResetProductEditSessionVariables() {
                CallUiAction(15, "", "");
            };
            function CalendarSync(EmployeeNonTaskId, IsHoliday, IsDeleting) {
                var enti = "1=";
                var ih = "&2=";
                var id = "&3=";
                enti = enti + EmployeeNonTaskId;
                ih = ih + IsHoliday;
                id = id + IsDeleting;
                CallUiAction(16, "", enti + ih + id);
            };
            function SendEmail(guid) {
                CallUiAction(17, guid, "");
            };
            function CheckForAsyncMessage() {
                window.setTimeout(function () {
                    CallUiAction(18, "", "");
                }, 20000);
            };
            function ResetCRMCentralSessionVariables() {
                CallUiAction(19, "", "");
            };
            function ResetCalendarSessionVariables() {
                CallUiAction(28, "", "");
            };
            function ResetExpense_SelectItemsSessionVariables() {
                CallUiAction(21, "", "");
            }
            function RenewSession() {
                CallUiAction(24, "", "");
            };
            function CheckSession() {
                //window.setTimeout(function () {
                //    CallUiAction(25, "", "");
                //}, 1500);
            };
            function ReviewGenerateFeedbackSummary(projectId, reviewId) {
                if (projectId && reviewId) {
                    var review = "reviewId=" + reviewId;
                    CallUiAction(27, projectId, review);
                }
            }
            function CallPrintSendPageSilently(URL) {
                window.setTimeout(function () {
                    var oWnd = manager.open(URL, '');
                    oWnd.set_destroyOnClose(true);
                    oWnd.hide();
                }, 1);
            };
            function ResetProjectScheduleFindAndReplaceSessionVariables() {
                CallUiAction(29, "", "");
            };
            //endregion
        </script>
        <!-- Misc -->
        <script type="text/javascript">
            function TestWindows() {
                SetObjects();
                if (CurrentWindows.length > 0) {
                    var s;
                    for (var i = 0; i < CurrentWindows.length; i++) {
                        s += CurrentWindows[i].get_name() + ", " + CurrentWindows[i].get_navigateUrl() + ", " + CurrentWindows[i].get_openerElementID() + "\n";
                    };
                    alert("Window List\n\n" + s)
                };
            };
            function ShowMessage(err_msg) {
                //SetObjects();
                //radalert(err_msg, 'Uh Oh!');
                alert(err_msg);
                return false;
            };
            function ShowRadAlert(msg, ttl) {
                alert(msg);
                return false;
            };
            function DoWindowAction(action_name) {
                switch (action_name) {
                    case 'MaximizeAll':
                        manager.maximizeAll();
                        break;
                    case 'MinimizeAll':
                        manager.minimizeAll();
                        break;
                    case 'RestoreAll':
                        manager.restoreAll();
                        break;
                    case 'CloseAll':
                        manager.closeAll();
                        break;
                    case 'Cascade':
                        manager.cascade();
                        break;
                    case 'Tile':
                        manager.tile();
                        break;
                };
            };
            function PositionWorkspaceLogo() {
                var logo;
                logo = $("#ImageLogo");
                if (logo) {
                    var logoPosition = "";
                    logoPosition = logo.attr("lpos");
                    if (logoPosition) {
                        switch(logoPosition) {
                            case "TopLeft":
                                $(".workspace-logo").css({
                                    position:"absolute",
                                    zIndex: 100,
                                    left: 0,
                                    top: 0
                                });
                                break;
                            case "TopRight":
                                $(".workspace-logo").css({
                                    position:"absolute",
                                    zIndex: 100,
                                    right: 0,
                                    top: 0
                                });
                                break;
                            case "BottomRight":
                                $(".workspace-logo").css({
                                    position:"absolute",
                                    zIndex: 100,
                                    right: 0,
                                    bottom: 0
                                });
                                break;
                            case "BottomLeft":
                                $(".workspace-logo").css({
                                    position:"absolute",
                                    zIndex: 100,
                                    left: 0,
                                    bottom: 0
                                });
                                break;
                            case "Center":
                                $(".workspace-logo").css({
                                    position:"absolute",
                                    zIndex: 100,
                                    left: ($(window).width() - $(".workspace-logo").outerWidth())/2,
                                    top: ($(window).height() - $(".workspace-logo").outerHeight())/2
                                });
                                break;
                        }
                    } else {
                        $(".workspace-logo").css({
                            position:"absolute",
                            zIndex: 100,
                            left: ($(window).width() - $(".workspace-logo").outerWidth())/2,
                            top: ($(window).height() - $(".workspace-logo").outerHeight())/2
                        });
                    }
                    logo.delay(0).fadeIn(1500);
                }
            }
            function CloseThisWindow() {
                //Dummy function
            }
        </script>
        <!-- RadControls -->
        <script type="text/javascript">
            //#region Controls
            /*
            Opening a window clientside needs these array values
            0 = Type (APP or RPT)
            1 = APP_ID (if link came from db, it will have an app_id.  If not right now, substitute zero
            2 = link URL (the page to open)
            3 = window height
            4 = window width
            */
            function RadContextMenuWorkspaces_Clicked(sender, args) {
                var menuItemValue = args.get_item().get_value();
                switch (menuItemValue) {
                    case "DefaultWorkspace":
                        __doPostBack('DefaultWorkspace', '0');
                        break;
                    case "PreviousWorkspace":
                        __doPostBack('PreviousWorkspace', '');
                        break;
                    case "NextWorkspace":
                        __doPostBack('NextWorkspace', '');
                        break;
                    case "ManageWorkspaces":
                        OpenWorkspaceManager();
                        break;
                    case "DeleteWorkspace":
                        radconfirm('Are you sure you to delete?', ConfirmWorkspaceDelete, 330, 100, null, 'Delete Workspace?'); return false;
                        break;
                    case "SignOut":
                        __doPostBack('SignOut', '');
                        break;
                };
            };
            function RadPanelBar_OnClientItemClicking(sender, args) {
                var item = args.get_node();
                var itemDataKey = item.get_value();
                var itemText = item.get_text();
                if (!itemDataKey) {

                } else {
                    if (itemDataKey.indexOf("|") > -1) {
                        var arData = new Array();
                        arData = itemDataKey.split("|");
                        var WindowType;
                        var h;
                        var w;
                        WindowType = arData[0];
                        h = 0;
                        w = 0;
                        try {
                            h = arData[3];
                            h = h * 1;
                            w = arData[4];
                            w = w * 1
                        } catch (err) { h = 0; w = 0; }
                        if (WindowType == "APP" || WindowType == "RPT") {
                            var WindowTitle;
                            var WindowURL;
                            WindowTitle = itemText;
                            WindowURL = arData[2];
                            if (WindowURL.indexOf("Timesheet.aspx", 0) > -1) {
                                SetTimesheetEntryFromMainMenu();
                            };
                            if (WindowURL.indexOf("Timesheet_CommentsView.aspx", 0) > -1) {
                                ResetTimesheetCommentView();
                            };
                            if (WindowURL.indexOf("Alert_Inbox.aspx", 0) > -1) {
                                ResetAlertInboxPageIndex();
                            };
                            if (WindowURL.indexOf("DesktopBookmarks.ascx", 0) > -1) {
                                //alert("bm");
                                RefreshBookmarksDTO();
                            } else {

                                OpenRadWindow(WindowTitle, WindowURL, h, w);

                            };
                        };
                        if (WindowType == "WORKSPACE") {
                            try {
                                var WorkspaceId = 0;
                                WorkspaceId = arData[1];
                                WorkspaceId = WorkspaceId * 1
                                window.location = 'Default.aspx?click=1&w=' + WorkspaceId;
                            }
                            catch (err) {
                                alert("<strong>Error loading workspace id</strong>" + err);
                            };
                        };
                        if (WindowType == "PREV_WORKSPACE") {
                            __doPostBack('PreviousWorkspace', '');
                        };
                        if (WindowType == "NEXT_WORKSPACE") {
                            __doPostBack('NextWorkspace', '');
                        };
                        if (WindowType == "SIGNOUT") {
                            __doPostBack('SignOut', '');
                        };
                        if (WindowType == "HELP") {
                            OpenHelp(false);
                        };
                        if (WindowType == "HELPCP") {
                            OpenHelp(true);
                        };
                        if (WindowType == "NOTIFICATION") {
                            __doPostBack('Notification', '');
                        };

                    } else {
                        switch (itemDataKey) {
                            case "RadPanelBarSignOut":
                                __doPostBack('SignOut', '');
                                break;
                            case "RadPanelBarMySettings":
                                OpenRadWindow("", "MySettings.aspx", 0, 0, false, 0, 0, false);
                                break;
                            case "RadPanelItemWindowsCascade":
                                DoWindowAction('Cascade');
                                break;
                            case "RadPanelItemWindowsTile":
                                DoWindowAction('Tile');
                                break;
                            case "RadPanelItemWindowsMinimizeAll":
                                DoWindowAction('MinimizeAll');
                                break;
                            case "RadPanelItemWindowsRestoreAll":
                                DoWindowAction('RestoreAll');
                                break;
                            case "RadPanelItemWindowsCloseAll":
                                DoWindowAction('CloseAll');
                                break;

                        };
                    };
                    if (itemDataKey != "RadPanelItemNew" && itemDataKey != "RadPanelItemFind" && itemDataKey != "RadPanelItemOther") {
                        closePanel();
                    }

                };
            };
            function RadPanelExpandItem(panelbar, args) {
                if (args.get_item().get_items.Count != 0 && args.get_item().get_expanded() == false) {
                    args.get_item().set_expanded(true);
                }
                else {
                    args.get_item().set_expanded(false);
                };
            };

            function RadTreeViewClientNodeClicked(sender, eventArgs) {
                var node = eventArgs.get_node();
                node.toggle();
            }

            var limit = '';
            limit = <%=Me.FilesizeLimit%>;
            function RadAsyncUploadOnClientValidationFailed(sender, args) {
                alert("File is too large.  \n\nMaximum file size is: " + limit + "MB\n");
            };

            function RadNotificationParent_OnClientHidden(sender, args) {
                sender.set_visibleOnPageLoad(false);
            }
            function RadNotificationParentNotificationMenuOnClientItemClicked(sender, args) {
                var newAppButton = document.getElementById("<%= ImageButtonNewApplications.ClientID %>");
                var radNotificationParent = $find("<%= RadNotificationParent.ClientID %>");
                var itemValue = args.get_item().get_value();
                if (itemValue) {
                    switch(itemValue) {
                        case "Read":
                            window.setTimeout(function () {
                                CallUiAction(22, "", "");
                            }, 250);
                            if (radNotificationParent) {
                                radNotificationParent.set_visibleOnPageLoad(false);
                                radNotificationParent.hide();
                            }
                            if (newAppButton) {
                                newAppButton.style.display = "none";
                            }
                            break;
                        case "Hide":
                            if (radNotificationParent) {
                                radNotificationParent.set_visibleOnPageLoad(false);
                                radNotificationParent.hide();
                            }
                            break;
                        default:
                            break;
                    };
                }
                return false;
            }
            function RadNotificationParentShow() {
                var radNotificationParent = $find("<%= RadNotificationParent.ClientID %>");
                if (radNotificationParent) {
                    radNotificationParent.show();
                }
                return false;
            };
            var currentWorkspaceId = <%=CurrentWorkspaceId%>;
            var isFloat = <%=Me._IsFloatingObjects.ToString().ToLower()%>;
            var isDash = <%=Me._IsDefaultWorkspace.ToString().ToLower()%>;
            function RadWindowManagerParentSavePositionAndSize(sender, eventArgs) {
                if (isDash == false && isFloat == true) {
                    try {
                        SetObjects();
                        var CurrentWindow = sender;
                        if (CurrentWindow != null) {
                            var WindowURL = '';
                            WindowURL = CurrentWindow.get_navigateUrl();
                            if (WindowURL && WindowURL.indexOf("auto=1") > -1) {
                                var position = CurrentWindow.getWindowBounds();
                                var WindowTop = 0;
                                var WindowLeft = 0;
                                var WindowHeight = 0;
                                var WindowWidth = 0;
                                var OneItem = '';
                                WindowTop = position.y;
                                WindowLeft = position.x;
                                WindowHeight = position.height;
                                WindowWidth = position.width;
                                OneItem = WindowURL + '&t=' + WindowTop + '&l=' + WindowLeft + '&h=' + WindowHeight + '&w=' + WindowWidth;
                                window.setTimeout(function () {
                                    ////$.ajax({
                                    ////    type: "POST",
                                    ////    contentType: "application/json; charset=utf-8",
                                    ////    url: 'ApplicationActions/SaveWindowPositionAndSize', 
                                    ////    //dataType: "json",
                                    ////    data: JSON.stringify({"URL": WindowURL, "WorkspaceID": currentWorkspaceId, "Top": WindowTop, "Left": WindowLeft, "Height": WindowHeight, "Width": WindowWidth}),
                                    ////    success: function (result) {
                                    ////    },
                                    ////    error: function (msg) {
                                    ////    }
                                    ////});
                                    var oWnd = manager.open('UI_Action.aspx?action=1&val=' + OneItem, '');
                                    oWnd.set_destroyOnClose(true);
                                    oWnd.hide();
                                }, 500);
                            }
                        };
                    } catch(e) {
                    }
                }
                return false;
            };
            function RadWindowManagerParentOnClientShow(sender, eventArgs) {
                SetObjects();
                var WindowThatIsShowing = sender;
                if (WindowThatIsShowing != null) {
                    var s;
                    s = WindowThatIsShowing.get_navigateUrl();
                    var arCurr = new Array();
                    arCurr = s.split('.');
                    s = arCurr[0];
                    s = s.toUpperCase()
                    if (WindowThatIsShowing == FindWindow("Timesheet_Stopwatch.aspx") || s.indexOf('TIMESHEET_STOPWATCH', 0) > -1) {
                        RefreshTimesheetDTO();
                    };
                    sender.set_iconUrl(sender.get_iconUrl());
                };
            };
            function RadWindowManagerParentOnClientPageLoad(sender, eventArgs) {
                //sender.get_contentFrame().style.height = "100%";
                //sender.get_contentFrame().style.width = "100%";
                //sender.get_contentFrame().style.width = "1080px";
                //sender.set_height(height);
            };
            function RadWindowManagerParentOnClientCommand(sender, eventArgs) {
                var commandName = eventArgs.get_commandName();
               
                if (commandName == 'Restore') {
                    eventArgs.set_cancel(true);
                    sender.Maximize();
                };
            };
            function RadWindowManagerParentOnClientBeforeClose(sender, eventArgs) {
                SetObjects();
                var WindowThatIsClosing = sender;
                if (WindowThatIsClosing) {
                    var windowURL = WindowThatIsClosing.GetUrl();
                    if (windowURL.indexOf("Desktop_AlertView") > -1) {
                        RefreshAlertThingsOnAlertClose();
                        return false;
                    }
                    if (WindowThatIsClosing == FindWindow("Chat_Rooms.aspx")) {
                        WindowThatIsClosing.set_destroyOnClose(false);
                        eventArgs.set_cancel(true);
                        WindowThatIsClosing.hide();
                        return false;
                    };
                    if (WindowThatIsClosing == FindWindow("Chat.aspx")) {
                        WindowThatIsClosing.set_destroyOnClose(false);
                        return false;
                    } else {
                        WindowThatIsClosing.set_destroyOnClose(true);
                    };

                    var isDashboard = false;
                    isDashboard = isDash;
                    var s;
                    s = WindowThatIsClosing.get_navigateUrl();

                    if (s.toUpperCase().indexOf("CONCEPTSHARE.COM") > -1) {
                        RefreshWindow("Alert_DigitalAssetReview.aspx", false, false);
                        return false;
                    }

                    var arCurr = new Array();
                    arCurr = s.split('.');
                    s = arCurr[0];
                    s = s.toUpperCase()
                    if (WindowThatIsClosing == FindWindow("AgencySettings_Upload.aspx")) {
                        RefreshWindow("MySettings.aspx", false, false);
                        RefreshWindow("AgencySettings_Preview.aspx", false, false);
                        return false;
                    };
                    if(WindowThatIsClosing == FindWindow('Alert_Assignment.aspx')){
                        RefreshContentPage();
                        return false;
                    };
/*
                    if(WindowThatIsClosing == FindWindow('Alert_DigitalAssetReview_AddReviewer.aspx')){
                        RefreshWindow("Alert_DigitalAssetReview.aspx", false, false);
                        return false;
                    };
*/
                    if(WindowThatIsClosing == FindWindow('Alert_DigitalAssetReview.aspx')){
                        RefreshContentPage();
                        return false;
                    };
                    if(WindowThatIsClosing == FindWindow('Alert_New.aspx')){
                        RefreshContentPage();
                        return false;
                    };
                    if(WindowThatIsClosing == FindWindow('Alert_Settings.aspx')){
                        RefreshWindow("Alert_View.aspx", false, false);
                        return false;
                    };
                    if(WindowThatIsClosing == FindWindow('Alert_View.aspx')){
                        RefreshContentPage();
                        return false;
                    };
                    if(WindowThatIsClosing == FindWindow('AngularGantt.aspx')){
                        RefreshWindow("<%= Webvantage.Controllers.ProjectManagement.ProjectScheduleController.BaseRoute %>Index", false, false);
                        return false;
                    };
                    if (WindowThatIsClosing == FindWindow("BillingApproval_Alert.aspx")) {
                        OpenAlertNotifiy();
                        return false;
                    };
                    if (WindowThatIsClosing == FindWindow("BillingApproval_Approval.aspx")) {
                        RefreshWindow("BillingApproval_View_Approvals.aspx", false, false);
                        return false;
                    };
                    if (WindowThatIsClosing == FindWindow("BillingApproval_Approval_Detail.aspx")) {
                        RefreshWindow("BillingApproval_Approval.aspx", false, false);
                        return false;
                    };
                    if (WindowThatIsClosing == FindWindow("BillingApproval_Approval_JobComponent.aspx")) {
                        RefreshWindow("BillingApproval_Approval_Detail.aspx", false, false);
                        return false;
                    };
                    if (WindowThatIsClosing == FindWindow("BillingApproval_Batch.aspx")) {
                        RefreshWindow("BillingApproval_View.aspx", false, false);
                        return false;
                    };
                    if (WindowThatIsClosing == FindWindow("Calendar_MonthView.aspx")) {
                        RefreshDashboardCalendar();
                        ResetCalendarSessionVariables();
                        return false;
                    };
                    if (WindowThatIsClosing == FindWindow("Calendar_NewActivity.aspx")) {
                        RefreshDashboardCalendar();
                        return false;
                    };
                    if (WindowThatIsClosing == FindWindow("Calendar_NewItem.aspx")) {
                        RefreshDashboardCalendar();
                        return false;
                    };
                    if (WindowThatIsClosing == FindWindow("Chat_RoomDetails.aspx")) {
                        RefreshWindow("Chat_List.aspx", false, false);
                        return false;
                    };
                    if (WindowThatIsClosing == FindWindow("Desktop_CRMCentral.aspx")) {
                        ResetCRMCentralSessionVariables();
                        return false;
                    };
                    if (WindowThatIsClosing == FindWindow("EmployeeTimeForecast_AddAlternateEmployees.aspx")) {
                        RefreshWindow("EmployeeTimeForecast_Edit.aspx", false, false);
                        return false;
                    };
                    if (WindowThatIsClosing == FindWindow("EmployeeTimeForecast_AddEmployees.aspx")) {
                        RefreshWindow("EmployeeTimeForecast_Edit.aspx", false, false);
                        return false;
                    };
                    if (WindowThatIsClosing == FindWindow("EmployeeTimeForecast_AddIndirectCategories.aspx")) {
                        RefreshWindow("EmployeeTimeForecast_Edit.aspx", false, false);
                        return false;
                    };
                    if (WindowThatIsClosing == FindWindow("EmployeeTimeForecast_AddJobComponents.aspx")) {
                        RefreshWindow("EmployeeTimeForecast_Edit.aspx", false, false);
                        return false;
                    };
                    if (WindowThatIsClosing == FindWindow("EmployeeTimeForecast_Approve.aspx")) {
                        RefreshWindow("EmployeeTimeForecast_Edit.aspx", false, false);
                        return false;
                    };
                    if (WindowThatIsClosing == FindWindow("Estimating_Quote.aspx")) {
                        RefreshWindow("Estimating.aspx", false, false);
                        return false;
                    };
                    if (WindowThatIsClosing == FindWindow("Estimating_Setup.aspx")) {
                        RefreshWindow("Estimating_Quote.aspx", false, false);
                        return false;
                    };
                    if (WindowThatIsClosing == FindWindow("Expense_SelectItems.aspx")) {
                        ResetExpense_SelectItemsSessionVariables();
                        return false;
                    }
                    if (WindowThatIsClosing == FindWindow("Event_Detail.aspx")) {
                        RefreshWindow("Event_View.aspx", false, false);
                        RefreshWindow("Calendar_MonthView.aspx", false, false);
                        RefreshWindow("Scheduler_Events.aspx", false, false);
                        RefreshWindow("Scheduler_EventTasks.aspx", false, false);
                        return false;
                    };
                    if (WindowThatIsClosing == FindWindow("Event_Generator.aspx")) {
                        RefreshWindow("Estimating_Quote.aspx", false, false);
                        RefreshWindow("Event_View.aspx", false, false);
                        return false;
                    };
                    if(WindowThatIsClosing == FindWindow('Importing_CreateOrder.aspx')){
                        RefreshWindow('Media_ATB.aspx', false, false);
                        return false;
                    };
                    if (WindowThatIsClosing == FindWindow("JobForecast_AddJobComponents.aspx")) {
                        RefreshWindow("JobForecast_Edit.aspx", false, false);
                        return false;
                    };
                    if (WindowThatIsClosing == FindWindow("JobVerTmplt.aspx")) {
                        RefreshDesktopObjectGrid("DesktopMyJobRequests.ascx");
                        RefreshDesktopObjectGrid("DesktopJobRequests.ascx");
                        RefreshWindow("jobVersions.aspx", false, false);
                        RefreshChildPageGrid('JobRequest_Search.aspx');
                        return false;
                    };
                    if (WindowThatIsClosing == FindWindow("JobTemplate_New.aspx")) {
                        RefreshDesktopObjectGrid("DesktopMyJobRequests.ascx");
                        RefreshDesktopObjectGrid("DesktopJobRequests.ascx");
                        RefreshChildPageGrid('JobRequest_Search.aspx');
                        return false;
                    };
                    if (WindowThatIsClosing == FindWindow("JobTemplate_NewComponent.aspx")) {
                        RefreshDesktopObjectGrid("DesktopMyJobRequests.ascx");
                        RefreshDesktopObjectGrid("DesktopJobRequests.ascx");
                        RefreshChildPageGrid('JobRequest_Search.aspx');
                        return false;
                    };
                    if (WindowThatIsClosing == FindWindow("Maintenance_ClientEdit.aspx")) {
                        ResetClientEditSessionVariables();
                        return false;
                    };
                    if (WindowThatIsClosing == FindWindow("Maintenance_ContractEdit.aspx")) {
                        ResetContractSessionVariables();
                        return false;
                    };
                    if (WindowThatIsClosing == FindWindow("Maintenance_DesktopCards.aspx")) {
                        location.reload(true);
                        return false;
                    };
                    if (WindowThatIsClosing == FindWindow("Maintenance_DivisionEdit.aspx")) {
                        ResetDivisionEditSessionVariables();
                        return false;
                    };
                    if (WindowThatIsClosing == FindWindow("Maintenance_ProductEdit.aspx")) {
                        ResetProductEditSessionVariables();
                        return false;
                    };
                    if (WindowThatIsClosing == FindWindow("Maintenance_Timesheet.aspx")) {
                        SetTimesheetEntryFromMainMenu();
                        RefreshWindow("Timesheet.aspx", true, false);
                        RefreshDesktopObjectGrid('DesktopTimesheet.ascx');
                        return false;
                    };
                    if(WindowThatIsClosing == FindWindow('Maintenance_CalendarTime.aspx')){
                        RefreshWindow('Timesheet_CopyFrom.aspx', false, false);
                        return false;
                    };
                    if(WindowThatIsClosing == FindWindow('PurchaseOrder_Print.aspx')){
                        RefreshWindow('purchaseorder.aspx', false, false);
                        return false;
                    };
                    if (WindowThatIsClosing == FindWindow("Reporting_DynamicReportEdit.aspx")) {
                        if (window.confirm('Are you sure you want to exit? All unsaved work will be lost.') == false) {
                            eventArgs.set_cancel(true);
                        } else {
                            ResetDynamicReportSessionVariables();
                        };
                        RefreshWindow("Reporting_DynamicReports.aspx", false, false);
                        return false;
                    };
                    if (WindowThatIsClosing == FindWindow("Reporting_JobStatus.aspx")) {
                        if (window.confirm('Are you sure you want to exit? All unsaved work will be lost.') == false) {
                            eventArgs.set_cancel(true);
                        } else {
                            ResetDynamicReportSessionVariables();
                        };
                        return false;
                    };
                    if (WindowThatIsClosing == FindWindow("Resources_Emps_Find.aspx")) {
                        RefreshWindow("Event_View.aspx", false, false);
                        RefreshWindow("<%= Webvantage.Controllers.ProjectManagement.ProjectScheduleController.BaseRoute %>Index", false, false);
                        return false;
                    };
                    if (WindowThatIsClosing == FindWindow("Timesheet.aspx")) {
                        ResetTimesheetEmpCode();
                        RefreshTimesheetDTO();
                        return false;
                    };
                    if (WindowThatIsClosing == FindWindow("Timesheet_CommentsView.aspx")) {
                        ResetTimesheetCommentView();
                        RefreshWindow("Timesheet.aspx", false, false);
                        RefreshWindow("Timesheet_Stopwatch.aspx", false, false);
                        RefreshTimesheetDTO();
                        return false;
                    };
                    if (WindowThatIsClosing == FindWindow("Timesheet_QuickAdd.aspx")) {
                        RefreshTimesheetWindows();
                        RefreshDesktopObjectGrid("DesktopMyTasks.ascx");
                        RefreshDesktopObjectGrid("DesktopTaskList.ascx");
                        return false;
                    };
                    if (WindowThatIsClosing == FindWindow("Timesheet_Stopwatch.aspx") || s.indexOf('TIMESHEET_STOPWATCH', 0) > -1) {
                        RefreshTimesheetWindows();
                        return false;
                    };
                    if (WindowThatIsClosing == FindWindow("TrafficSchedule_TaskContacts.aspx")) {
                        RefreshWindow({ pageName: '<%= Webvantage.Controllers.ProjectManagement.ProjectScheduleController.BaseRoute %>Index', refreshFunction: 'reloadTaskList' }, false, false);
                        RefreshWindow("TrafficSchedule_TaskDetail.aspx", false, false);
                        return false;
                    };
                    if (WindowThatIsClosing == FindWindow("TrafficSchedule_TaskEmployees.aspx")) {
                        RefreshWindow({ pageName: '<%= Webvantage.Controllers.ProjectManagement.ProjectScheduleController.BaseRoute %>Index', refreshFunction: 'reloadTaskList' }, false, false);
                        //RefreshWindow("TrafficSchedule.aspx", false, false);
                        RefreshWindow("TrafficSchedule_TaskDetail.aspx", false, false);
                        return false;
                    };
                    if (WindowThatIsClosing == FindWindow("ProjectManagement/ProjectSchedule/FindAndReplace")) {
                        //console.log('FindAndReplace closing!');
                        RefreshWindow("<%= Webvantage.Controllers.ProjectManagement.ProjectScheduleController.BaseRoute %>Index", false, false);
                        RefreshWindow("TrafficSchedule_Multiview.aspx", false, false);
                        return false;
                    };
                    if (WindowThatIsClosing == FindWindow("TrafficSchedule_Setup.aspx")) {
                        //RefreshWindow("TrafficSchedule.aspx", false, false);
                        return false;
                    };
                    if (WindowThatIsClosing == FindWindow("TrafficSchedule_TaskDetail.aspx")) {
                        /*
                        if (isDashboard == false) {
                            RefreshProjectScheduleGrid();
                            RefreshWindow("TrafficSchedule_Status_Graph.aspx", false, false);
                            RefreshDefaultWorkspaceMainContent();
                            return false;
                        } else {
                            //__doPostBack("RefreshTasks","");
                            RefreshTasks();
                            return false;
                        }
                        */
                        RefreshProjectScheduleGrid();
                        RefreshWindow("TrafficSchedule_Status_Graph.aspx", false, false);
                        RefreshTasks();
                        return false;
                    };
                    if (WindowThatIsClosing == FindWindow("TrafficSchedule_QuickEdit.aspx")) {
                        RefreshWindow("<%= Webvantage.Controllers.ProjectManagement.ProjectScheduleController.BaseRoute %>Index", false, false);
                        //RefreshDefaultWorkspaceMainContent();
                        RefreshTasks();
                        return false;
                    };
                    if (WindowThatIsClosing == FindWindow("TrafficScheduleVersion_New.aspx")) {
                        RefreshWindow("TrafficScheduleVersion.aspx", false, false);
                        return false;
                    };
                    if(WindowThatIsClosing == FindWindow('Reporting_JobVersion.aspx')){
                        RefreshWindow('Reporting_JobVersionReports.aspx', false, false);
                        return false;
                    };
                    if(WindowThatIsClosing == FindWindow('JobForecast_Settings.aspx')){
                        RefreshWindow('JobForecast_Edit.aspx', false, false);
                        return false;
                    };
                    if(WindowThatIsClosing == FindWindow('JobForecast_Edit.aspx')){
                        RefreshWindow('JobForecast_Job.aspx', false, false);
                        return false;
                    };
                };
            };
            function RadWindowManagerParentOnClientClose(sender, eventArgs) {
            };
            //endregion

            function GetRadWindow() {
                var oWindow = null;
                if (window.radWindow) {
                    oWindow = window.radWindow;
                }
                else if (window.frameElement.radWindow){
                    oWindow = window.frameElement.radWindow;
                };
                return oWindow;
            }
            function GoToSignIn() {
                window.location = 'SignIn.aspx';
            };
            function OnColumnHidden(sender, eventArgs) {
                var qs = '';
                qs = eventArgs.get_gridColumn().get_owner().get_owner().get_id() + '|' + eventArgs.get_gridColumn().get_uniqueName() + '|false';
                window.setTimeout(function () {
                    var oWnd = manager.open('UI_Action.aspx?action=5&val=' + qs, '');
                    oWnd.set_destroyOnClose(true);
                    oWnd.hide();
                }, 1);
            }
            function OnColumnShown(sender, eventArgs) {
                var qs = '';
                qs = eventArgs.get_gridColumn().get_owner().get_owner().get_id() + '|' + eventArgs.get_gridColumn().get_uniqueName() + '|true'
                window.setTimeout(function () {
                    var oWnd = manager.open('UI_Action.aspx?action=5&val=' + qs, '');
                    oWnd.set_destroyOnClose(true);
                    oWnd.hide();
                }, 1);
            };
            function ConfirmWorkspaceDelete(arg) {
                if (arg == true) {
                    __doPostBack('DeleteCurrentWorkspace', '');
                }
            };
            function OpenFloatingWindow(WindowTitle, WindowURL, WindowHeight, WindowWidth, WindowTop, WindowLeft) {
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
                newwin = window.open(WindowURL, WindowTitle, params);
                if (window.focus && newwin) {
                    setTimeout(function () {
                        newwin.focus();
                    }, 1);
                };
                return false;
            }
            function OpenHelp(IsClientPortal) {
                if (typeof IsClientPortal == 'undefined') {
                    IsClientPortal = false;
                }
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
                if (IsClientPortal == true) {
                    newwin = window.open('cphelp/index.htm', 'HelpWindow', params);
                } else {
                    newwin = window.open('webhelp/webvantage.htm', 'HelpWindow', params);
                }
                setTimeout(function () {
                    newwin.focus();
                }, 1);
                return false;
            };
            function OpenWorkspaceManager() {
                var width = 800;
                var height = screen.height - 125;
                var left = 0;//(screen.width - width) / 2;
                var top = 0; //(screen.height - height) / 2;
                var params = 'width=' + width + ', height=' + height;
                params += ', top=' + top + ', left=' + left;
                params += ', directories=no';
                params += ', location=no';
                params += ', menubar=no';
                params += ', resizable=no';
                params += ', scrollbars=1';
                params += ', status=no';
                params += ', toolbar=no';
                newwin = window.open('Workspace_Manage.aspx', 'ManageWorkspaces', params);
                setTimeout(function () {
                    newwin.focus();
                }, 1);
                return false;
            };
        </script>
        <!-- document -->
    </telerik:RadCodeBlock>
</head>
<body runat="server" id="BodyTagParent" style="background-color: #FAFAFA !important; overflow-y:hidden;">
    <form id="FrmParent" runat="server" autocomplete="off">
        <telerik:RadScriptManager ID="RadScriptManagerParent" runat="server" 
            EnablePageMethods="true" EnableScriptGlobalization="true" AsyncPostBackTimeout="900" 
            EnablePartialRendering="true" EnableEmbeddedjQuery="false">
            <Scripts>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
            </Scripts>
        </telerik:RadScriptManager>
        <script type="text/javascript" src="Scripts/jquery.signalR-2.4.2.min.js"></script>
        <script src="signalr/hubs"></script>
        <div id="TimerLabel" style="display: none !important;"></div>
        <div>
            <div id="framecontentLeft" class="framecontentTextColor background-color-sidebar" runat="server">
                <div class="inner-pad" style="padding-left: 2px; width: 65px !important;">
                    <div style="margin-bottom: 8px;" runat="server" id="DivNewPanel">
                        <a id="LinkNewPanel" href="#new-panel">
                            <asp:Image ID="ImageAdvantage" runat="server" ImageUrl="~/Images/Logos/AdvantageIcon.png" CssClass="main-icons-simple-home" ToolTip="Aqua" />
                        </a>
                    </div>
                    <div style="margin-bottom: 8px;" runat="server" id="DivAppPanel">
                        <a id="LinkAppPanel" href="#app-panel">
                            <asp:Image ID="ImageApps" runat="server" ImageUrl="~/Images/Icons/White/256/app_drawer.png" CssClass="main-icons-simple-home" ToolTip="Modules" />
                        </a>
                    </div>
                    <div style="margin-bottom: 8px;" id="DivNewApp">
                        <a id="LinkNewApp" href="#new-app-panel">
                            <img ID="ImageNewApp" src="Images/blank.ico" class="main-icons-simple-home" title="Hidden link to NewApp" onclick="window.location.href='NewApp'" />
                        </a>
                    </div>
                </div>
            </div>
            <div id="framecontentRight" class="framecontentTextColor background-color-sidebar">
                <div class="inner-pad">
                    <a id="LinkUserPanel" href="#user-panel">
                        <dx:ASPxBinaryImage ID="ASPxBinaryImageEmp" runat="server" CssClass="wv-employee-img-thumbnail-lg" BinaryStorageMode="Session"
                            EmptyImage-Url="~/Images/Icons/White/256/user.png">
                        </dx:ASPxBinaryImage>
                        <div id="DivUserInitial" runat="server" class="wv-employee-img-thumbnail-lg" style="display: none !important;">
                            <div class="sidebar-user-init-init">
                                <asp:Literal ID="LiteralEmployeeInitial" runat="server"></asp:Literal>
                            </div>
                        </div>
                    </a>
                    <a id="LinkUserSchedulePanel" runat="server">
                        <div id="DivDate" runat="server" class="main-count-container">
                            <div class="main-count">
                                <asp:Literal ID="LiteralDayOfMonth" runat="server"></asp:Literal>
                            </div>
                            <div class="main-count-label">
                                <asp:Literal ID="LiteralMonth" runat="server"></asp:Literal>
                            </div>
                        </div>
                    </a>
                    <div style="padding-left: 5px;">
                        <div id="DivTimeWarnings" runat="server" style="margin: 3px 0px 8px 0px; display: none;">
                            <div id="DivMissingTime" runat="server" class="time-warning-icon-background standard-red" style="">
                                <asp:ImageButton ID="ImageButtonMissingTime" runat="server" CausesValidation="false" OnClientClick="OpenRadWindow('','Timesheet_MissingTime.aspx',0,0,false);return false;" ImageUrl="~/Images/Icons/White/256/sign_warning.png" CssClass="time-warning-icon-image" />
                            </div>
                        </div>
                        <div>
                            <asp:ImageButton ID="ImageButtonDashboard" runat="server" ToolTip="Dashboard" ImageUrl="~/Images/Icons/Color/256/dashboard.png" CssClass="main-icons-simple-home talkToTheHand" OnClientClick="__doPostBack('DefaultWorkspace','0');return false;" />
                            <asp:ImageButton ID="ImageButtonBoards" runat="server" ToolTip="Boards" ImageUrl="~/Images/Icons/Color/256/kanban.png" CssClass="main-icons-simple-home talkToTheHand" OnClientClick="OpenRadWindow('','ProjectManagement/Agile/AgileBoards');return false;" />
                            <asp:ImageButton ID="ImageButtonNextWorkspace" runat="server" ToolTip="Next Workspace" ImageUrl="~/Images/Icons/Color/256/arrow_right.png" CssClass="main-icons-simple-home talkToTheHand" OnClientClick="__doPostBack('NextWorkspace','');return false;" />
                            <asp:ImageButton ID="ImageButtonPreviousWorkspace" runat="server" ToolTip="Previous Workspace" ImageUrl="~/Images/Icons/Color/256/arrow_left.png" CssClass="main-icons-simple-home talkToTheHand" OnClientClick="__doPostBack('PreviousWorkspace','');return false;" />
                        </div>
                        <a id="LinkUserBookmarksPanel" runat="server" class="talkToTheHand" onclick="OpenRadWindow('','DesktopObjectWindow.aspx?dtoname=DesktopCardsMyBookmarks.ascx&title=My Bookmarks', 700, 280);">
                            <asp:ImageButton ID="ImageButtonBookmarks" runat="server" ToolTip="Bookmarks" ImageUrl="~/Images/Icons/Color/256/book_bookmark.png"
                                CssClass="main-icons-simple-home talkToTheHand" OnClientClick="return false;" />
                        </a>
                        <asp:ImageButton ID="ImageButtonNewApplications" runat="server" Visible="false" ToolTip="New Applications Available!"
                            ImageUrl="~/Images/Icons/Color/256/window_star.png" CssClass="main-icons-simple-home" OnClientClick="RadNotificationParentShow();return false;" />
                    </div>
                    <hr id="HrCountSeparator" runat="server" class="default-hr" />
                    <a id="LinkUserAssignmentsPanel" runat="server" onclick="OpenRadWindow('','DesktopObjectWindow.aspx?dtoname=DesktopCardsMyAssignments.ascx&title=My Assignments&card_type=2');">
                        <div id="DivUserPanelAssignmentCount" runat="server" class="main-count-container">
                            <div class="main-count">
                                <asp:Label ID="LabelUserPanelAssignmentCount" runat="server" Text="0"></asp:Label>
                            </div>
                            <div class="main-count-label">
                                <asp:Literal ID="LiteralUserPanelAssignmentCountLabel" runat="server" Text="Assgn."></asp:Literal>
                            </div>
                        </div>
                    </a>
                    <a id="LinkUserAlertsPanel" runat="server" onclick="OpenRadWindow('','DesktopObjectWindow.aspx?dtoname=DesktopCardsMyAssignments.ascx&title=My Alerts&card_type=1');">
                        <div id="DivUserPanelAlertCount" runat="server" class="main-count-container">
                            <div class="main-count">
                                <asp:Label ID="LabelUserPanelAlertCount" runat="server" Text="0"></asp:Label>
                            </div>
                            <div class="main-count-label">
                                <asp:Literal ID="LiteralUserPanelAlertCountLabel" runat="server" Text="Alerts"></asp:Literal>
                            </div>
                        </div>
                    </a>
                    <a id="LinkUserReviewsPanel" runat="server" onclick="OpenRadWindow('','DesktopObjectWindow.aspx?dtoname=DesktopCardsMyAssignments.ascx&title=My Reviews&card_type=3');">
                        <div id="DivUserPanelReviewCount" runat="server" class="main-count-container">
                            <div class="main-count">
                                <asp:Label ID="LabelUserPanelReviewCount" runat="server" Text="0"></asp:Label>
                            </div>
                            <div class="main-count-label">
                                <asp:Literal ID="LiteralUserPanelReviewCountLabel" runat="server" Text="Reviews"></asp:Literal>
                            </div>
                        </div>
                    </a>
                    <a id="LinkUserTasksPanel" runat="server" onclick="OpenRadWindow('','DesktopObjectWindow.aspx?dtoname=DesktopCardsMyTasks.ascx&title=My Tasks');">
                        <div id="DivUserPanelTaskCount" runat="server" class="main-count-container">
                            <div class="main-count">
                                <asp:Label ID="LabelUserPanelTaskCount" runat="server" Text="0"></asp:Label>
                            </div>
                            <div class="main-count-label">
                                <asp:Literal ID="LiteralUserPanelTaskCountLabel" runat="server" Text="Tasks"></asp:Literal>
                            </div>
                        </div>
                    </a>
                    <div id="DivUserPanelTimeCount" runat="server" class="main-count-container" style="font-size: 10px !important;" onclick="CallUiAction(20);">
                        <div class="main-count">
                            <asp:Label ID="LabelUserPanelTimeCount" runat="server" Text="0"></asp:Label>
                        </div>
                        <div class="main-count-label">
                            <asp:Literal ID="LiteralUserPanelTimeCountLabel" runat="server" Text="Hours Today"></asp:Literal>
                        </div>
                    </div>
                    <div id="DivChatButton" runat="server" style="padding-left: 5px; display: block !important; cursor: pointer;">
                        <asp:ImageButton ID="ImageButtonChat" runat="server" ToolTip="Chat" ImageUrl="~/Images/Icons/Color/256/chat.png" CssClass="main-icons-simple-home talkToTheHand" OnClientClick="ShowChatRoomsWindow();return false;" />
                    </div>
                    <hr id="HrSignOut" runat="server" class="default-hr" />
                    <div style="padding-left: 4px; cursor: pointer;">
                        <asp:ImageButton ID="ImageButtonSignOut" runat="server" ToolTip="Sign Out" ImageUrl="~/Images/Icons/Color/256/power.png" CssClass="main-icons-simple-home talkToTheHand" OnClientClick="__doPostBack('SignOut','');return false;" />
                    </div>
                </div>
            </div>
            <div id="maincontent" runat="server" class="main-content-dflt">
                <asp:Image ID="ImageLogo" runat="server" />
                <asp:UpdatePanel ID="UpdatePanelRadDock" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                    <ContentTemplate>
                        <telerik:RadDockLayout ID="RadDockLayoutParent" runat="server" RenderingMode="Classic">
                            <div id="DivLeftDock" runat="server" style="float: left; overflow: auto !important; width: 33%; height: 100%;">
                                <telerik:RadDockZone ID="RadDockZoneLeft" runat="server" CssClass="dockzone" BorderStyle="None">
                                </telerik:RadDockZone>
                            </div>
                            <div id="DivRightDock" runat="server" style="float: left; overflow: auto !important; width: 67%; height: 100%;">
                                <telerik:RadDockZone ID="RadDockZoneCenter" runat="server" BorderStyle="None" CssClass="dockzone">
                                </telerik:RadDockZone>
                            </div>
                        </telerik:RadDockLayout>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div id="DivDefaultWorkspace" runat="server" class="dfltws-container">
                    <div id="dfltws-left">
                        <div id="dfltws-left-top">
                            <a id="DefaultWorkspaceLinkUserAssignmentsPanel" runat="server" class="dfltws-link">
                                <div id="DivDefaultWorkspaceAssignmentsBadge" runat="server" class="dfltws-badge" style="cursor: pointer;">
                                    <div class="dfltws-badge-content">
                                        <div id="DivDefaultWorkspaceAssignmentCount" class="dfltws-badge-count">
                                            <asp:Label ID="LabelDefaultWorkspaceAssignmentCount" runat="server" Text="0"></asp:Label>
                                        </div>
                                        <div class="dfltws-badge-text">
                                            <asp:Literal ID="LiteralDefaultWorkspaceAssignmentCountLabel" runat="server" Text="Assignments"></asp:Literal>
                                        </div>
                                    </div>
                                </div>
                            </a>
                            <a id="DefaultWorkspaceLinkUserAlertsPanel" runat="server" class="dfltws-link">
                                <div id="DivDefaultWorkspaceAlertsBadge" runat="server" class="dfltws-badge">
                                    <div id="DivDefaultWorkspaceAlertCount" class="dfltws-badge-content">
                                        <div class="dfltws-badge-count">
                                            <asp:Label ID="LabelDefaultWorkspaceAlertCount" runat="server" Text="0"></asp:Label>
                                        </div>
                                        <div class="dfltws-badge-text">
                                            <asp:Literal ID="LiteralDefaultWorkspaceAlertCountLabel" runat="server" Text="Alerts"></asp:Literal>
                                        </div>
                                    </div>
                                </div>
                            </a>
                            <a id="DefaultWorkspaceLinkUserReviewsPanel" runat="server" class="dfltws-link">
                                <div id="DivDefaultWorkspaceReviewsBadge" runat="server" class="dfltws-badge">
                                    <div id="DivDefaultWorkspaceReviewCount" class="dfltws-badge-content">
                                        <div class="dfltws-badge-count">
                                            <asp:Label ID="LabelDefaultWorkspaceReviewCount" runat="server" Text="0"></asp:Label>
                                        </div>
                                        <div class="dfltws-badge-text">
                                            <asp:Literal ID="LiteralDefaultWorkspaceReviewCountLabel" runat="server" Text="Reviews"></asp:Literal>
                                        </div>
                                    </div>
                                </div>
                            </a>
                            <a id="DefaultWorkspaceLinkUserTasksPanel" runat="server" class="dfltws-link">
                                <div id="DivDefaultWorkspaceTasksBadge" runat="server" class="dfltws-badge">
                                    <div class="dfltws-badge-content">
                                        <div id="DivDefaultWorkspaceTaskCount" class="dfltws-badge-count">
                                            <asp:Label ID="LabelDefaultWorkspaceTaskCount" runat="server" Text="0"></asp:Label>
                                        </div>
                                        <div class="dfltws-badge-text">
                                            <asp:Literal ID="LiteralDefaultWorkspaceTaskCountLabel" runat="server" Text="Tasks"></asp:Literal>
                                        </div>
                                    </div>
                                </div>
                            </a>
                            <div id="DivDefaultWorkspaceRadRadialGaugeHoursToday" runat="server" class="dfltws-guage-container" style="cursor: pointer;" onclick="CallUiAction(20);">
                                <div>
                                    <telerik:RadRadialGauge runat="server" ID="RadRadialGaugeHoursToday" Width="155" Height="155" Style="cursor: pointer;">
                                        <Pointer Value="0">
                                            <Cap Size="0.1" />
                                        </Pointer>
                                        <Scale Min="0" Max="8" MajorUnit="1">
                                            <Labels Format="{0}" />
                                            <Ranges>
                                                <telerik:GaugeRange Color="#DC3545" From="0" To="2" />
                                                <telerik:GaugeRange Color="#FD7E14" From="2" To="4" />
                                                <telerik:GaugeRange Color="#FFC107" From="4" To="6" />
                                                <telerik:GaugeRange Color="#5CB85C" From="6" To="8" />
                                            </Ranges>
                                        </Scale>
                                    </telerik:RadRadialGauge>
                                </div>
                                <div style="margin-top: -20px; cursor: pointer;">
                                    Hours Today
                                </div>
                            </div>
                            <div id="DivDefaultWorkspaceRadRadialGaugeHoursThisWeek" runat="server" class="dfltws-guage-container" style="cursor: pointer;" onclick="CallUiAction(26);">
                                <div>
                                    <telerik:RadRadialGauge runat="server" ID="RadRadialGaugeHoursThisWeek" Width="155" Height="155" Style="cursor: pointer;">
                                        <Pointer Value="0">
                                            <Cap Size="0.1" />
                                        </Pointer>
                                        <Scale Min="0" Max="40" MajorUnit="10">
                                            <Labels Format="{0}" />
                                            <Ranges>
                                                <telerik:GaugeRange Color="#DC3545" From="0" To="10" />
                                                <telerik:GaugeRange Color="#FD7E14" From="10" To="20" />
                                                <telerik:GaugeRange Color="#FFC107" From="20" To="30" />
                                                <telerik:GaugeRange Color="#5CB85C" From="30" To="40" />
                                            </Ranges>
                                        </Scale>
                                    </telerik:RadRadialGauge>
                                </div>
                                <div style="margin-top: -20px; cursor: pointer;">
                                    Hours This Week
                                </div>
                            </div>
                        </div>
                        <div id="DivDefaultWorkspaceLeftMiddle" runat="server" class="dfltws-left-middle">
                            <iframe id="iFrameDefaultWorkspaceLeftMiddle" runat="server" src="Blank.htm" style="border: 0; height: 100% !important; display: block; width: 100%; padding-right: 10px !important; clear: both !important; overflow: hidden !important;"></iframe>
                        </div>
                        <div id="DivDefaultWorkspaceLeftBottom" runat="server" class="dfltws-left-bottom">
                            <asp:Repeater ID="RepeaterDefaultWorkspaceFavorites" runat="server">
                                <ItemTemplate>
                                    <div id="DivFavorite" runat="server" class="dfltws-left-bottom-bookmark" style="">
                                        <%#Eval("Description")%>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                    <div id="dfltws-right">
                        <asp:UpdatePanel ID="UpdatePanelRight" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <asp:PlaceHolder ID="PlaceHolderDefaultWorkspaceRight" runat="server"></asp:PlaceHolder>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
        <!-- aqua Panel -->
        <div id="new-panel" class="panel panelBackgroundColor left-panel-edge">
            <div style="overflow: hidden; height: 66px;" class="background-color-sidebar bottom-shadow" onclick="closePanel();">
                <div style="float: right; padding: 14px 20px 0px 0px;">
                    <div class="panel-label">aqua</div>
                </div>
            </div>
            <div>
                <telerik:RadTreeView runat="server" ID="RadTreeViewMainMenu" ShowLineImages="false" OnClientNodeClicking="RadPanelBar_OnClientItemClicking" OnClientNodeClicked="RadTreeViewClientNodeClicked">
                    <Nodes>
                        <telerik:RadTreeNode Text="New" Expanded="True" Value="RadPanelItemNew" ExpandMode="ClientSide">
                            <Nodes>
                            </Nodes>
                        </telerik:RadTreeNode>
                        <telerik:RadTreeNode Text="Find" Expanded="True" Value="RadPanelItemFind" ExpandMode="ClientSide">
                            <Nodes>
                                <telerik:RadTreeNode Text="Authorization to Buy" Value="APP|0|Media_ATB_Search.aspx|0|0">
                                </telerik:RadTreeNode>
                                <telerik:RadTreeNode Text="Campaign" Value="APP|0|Campaign_Search.aspx|0|0">
                                </telerik:RadTreeNode>
                                <telerik:RadTreeNode Text="Document" Value="APP|0|Documents_AdvancedSearch.aspx|0|0">
                                </telerik:RadTreeNode>
                                <telerik:RadTreeNode Text="Estimate" Value="APP|0|Estimating_Search.aspx|0|0">
                                </telerik:RadTreeNode>
                                <telerik:RadTreeNode Text="Job Jacket" Value="APP|0|JobTemplate_Search.aspx|0|0">
                                </telerik:RadTreeNode>
                                <telerik:RadTreeNode Text="Job Request" Value="APP|0|JobRequest_Search.aspx|0|0">
                                </telerik:RadTreeNode>
                                <telerik:RadTreeNode Text="Project Schedule" Value="APP|0|TrafficSchedule_Search.aspx|0|0">
                                </telerik:RadTreeNode>
                                <telerik:RadTreeNode Text="Purchase Order" Value="APP|0|purchaseorderlist.aspx|0|0">
                                </telerik:RadTreeNode>
                                <telerik:RadTreeNode Text="Time" Value="APP|0|Timesheet_Search.aspx|0|0">
                                </telerik:RadTreeNode>
                                <telerik:RadTreeNode Text="Find across modules" Value="APP|0|Search.aspx|0|0" />
                            </Nodes>
                        </telerik:RadTreeNode>
                        <telerik:RadTreeNode Text="Settings & Help" Expanded="True" Value="RadPanelItemOther" ExpandMode="ClientSide">
                            <Nodes>
                                <telerik:RadTreeNode Text="My Settings" Value="APP|0|MySettings.aspx|0|0" AccessKey="Y">
                                </telerik:RadTreeNode>
                                <telerik:RadTreeNode Text="Agency Settings" Value="APP|0|AgencySettings.aspx|0|0" AccessKey="A">
                                </telerik:RadTreeNode>
                                <telerik:RadTreeNode Text="Sign Out" Value="SIGNOUT|" AccessKey="S">
                                </telerik:RadTreeNode>
                                <telerik:RadTreeNode Text="Help" Value="HELP|" AccessKey="H">
                                </telerik:RadTreeNode>
                                <telerik:RadTreeNode Text="Contact Customer Service" Value="APP|0|Help_ContactCustomerSupport.aspx|0|0" AccessKey="C">
                                </telerik:RadTreeNode>
                                <telerik:RadTreeNode Text="About Webvantage" Value="APP|0|About.aspx|0|0" AccessKey="W">
                                </telerik:RadTreeNode>
                            </Nodes>
                        </telerik:RadTreeNode>
                        <telerik:RadTreeNode Text="Windows" Expanded="False" ExpandMode="ClientSide">
                            <Nodes>
                                <telerik:RadTreeNode Text="Cascade" Value="RadPanelItemWindowsCascade">
                                </telerik:RadTreeNode>
                                <telerik:RadTreeNode Text="Tile" Value="RadPanelItemWindowsTile">
                                </telerik:RadTreeNode>
                                <telerik:RadTreeNode Text="Minimize All" Value="RadPanelItemWindowsMinimizeAll">
                                </telerik:RadTreeNode>
                                <telerik:RadTreeNode Text="Restore All" Value="RadPanelItemWindowsRestoreAll">
                                </telerik:RadTreeNode>
                                <telerik:RadTreeNode Text="Close All" Value="RadPanelItemWindowsCloseAll">
                                </telerik:RadTreeNode>
                            </Nodes>
                        </telerik:RadTreeNode>
                    </Nodes>
                </telerik:RadTreeView>
            </div>
            <br />
            <br />
            <br />
        </div>
        <!-- Modules Panel -->
        <div id="app-panel" class="panel panelBackgroundColor left-panel-edge">
            <div style="overflow: hidden; height: 66px;" class="background-color-sidebar bottom-shadow" onclick="closePanel();">
                <div style="float: right; padding: 14px 20px 0px 0px;">
                    <div class="panel-label">Modules</div>
                </div>
            </div>
            <div style="display: block; position: relative; padding-top: 10px;">
                <telerik:RadTreeView runat="server" ID="RadTreeViewApps" ShowLineImages="false" OnClientNodeClicking="RadPanelBar_OnClientItemClicking" OnClientNodeClicked="RadTreeViewClientNodeClicked">
                    <Nodes>
                    </Nodes>
                </telerik:RadTreeView>
            </div>
            <br />
            <br />
            <br />
        </div>
        <!-- user Panel -->
        <div id="user-panel" class="panel panelBackgroundColor right-panel-edge">
            <div style="overflow: hidden; height: 66px;" class="dark-highlight-bg">
                <div style="float: left; padding: 13px 0px 0px 13px;">
                    <asp:Label ID="LabelEmployeeWelcome" runat="server" Text="Welcome!" CssClass="panel-label"></asp:Label>
                </div>
                <div style="float: right; padding-top: 10px; padding-right: 4px;">
                    <asp:ImageButton ID="ImageButtonSetColors" runat="server" CssClass="icon1" ImageUrl="~/Images/Icons/Color/256/painters_palette2.png" ToolTip="Set colors"
                        OnClientClick="OpenRadWindow('Colors','MySettings_Colors.aspx');return false;" Height="36" Width="36" />
                    <asp:ImageButton ID="ImageButtonTheme" runat="server" CssClass="icon1" ImageUrl="~/Images/Icons/Color/256/window_size.png" ToolTip="Switch theme" Height="36" Width="36" />
                </div>
            </div>
            <asp:UpdatePanel runat="server" ID="UpdatePanelUserSummary" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                    <div>
                        <webvantage:SummaryCard ID="UserSummary" runat="server"></webvantage:SummaryCard>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div id="DivWeather" runat="server" class="weather-panel"></div>
            <div style="margin-top: 8px; margin-left: 2px;">
                <telerik:RadTreeView runat="server" ID="RadTreeViewUser" ShowLineImages="false" OnClientNodeClicking="RadPanelBar_OnClientItemClicking" OnClientNodeClicked="RadTreeViewClientNodeClicked">
                    <Nodes>
                        <telerik:RadTreeNode Text="Workspaces" Value="RadPanelBarUserWorkspaces" ExpandMode="ClientSide" Expanded="true">
                            <Nodes>
                            </Nodes>
                        </telerik:RadTreeNode>
                        <telerik:RadTreeNode Text="Favorites" Value="RadPanelBarUserFavorites" ExpandMode="ClientSide" Expanded="true">
                            <Nodes>
                            </Nodes>
                        </telerik:RadTreeNode>
                        <telerik:RadTreeNode Text="Other" Expanded="true" Value="RadPanelBar" ExpandMode="ClientSide">
                            <Nodes>
                                <telerik:RadTreeNode Text="My Settings" Value="RadPanelBarMySettings" />
                                <telerik:RadTreeNode Text="Sign Out" Value="RadPanelBarSignOut" />
                            </Nodes>
                        </telerik:RadTreeNode>
                    </Nodes>
                </telerik:RadTreeView>
            </div>
            <div id="connection-info-panel">
                <div>Currently connected to</div>
                <div id="DivServerName" runat="server">
                    <asp:Literal ID="LiteralServer" runat="server"></asp:Literal>
                </div>
                <div>
                    <asp:Literal ID="LiteralDatabase" runat="server"></asp:Literal>
                </div>
            </div>
        </div>
        <!-- User Control Panels -->
        <div id="DivUserSchedule" runat="server" class="panel panelBackgroundColor right-panel-edge">
            <div style="overflow: hidden; height: 66px;" class="background-color-sidebar" onclick="closePanel();">
                <div style="float: left; padding: 14px 0px 0px 20px;">
                    <div class="panel-label">My Schedule</div>
                </div>
            </div>
            <asp:UpdatePanel runat="server" ID="UpdatePanelUserSchedule" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                    <asp:PlaceHolder ID="PlaceHolderUserSchedule" runat="server"></asp:PlaceHolder>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <telerik:RadScriptBlock ID="RadScriptBlockSlider" runat="server">
            <script type="text/javascript" src="Jscripts/jquery.panelslider.min.js"></script>
            <script type="text/javascript">
                $('#LinkNewPanel').panelslider({ side: 'left', clickClose: true, duration: 500 });
                $('#LinkAppPanel').panelslider({ side: 'left', clickClose: true, duration: 500 });
                $('#LinkUserPanel').panelslider({ side: 'right', clickClose: true, duration: 500 });
                $('#LinkUserSchedulePanelMySummaryCard').panelslider({ side: 'right', clickClose: false, duration: 500 });
                <%=Me.PanelScript%>
                function closePanel() {
                    $.panelslider.close();
                };
                $('#user_picture').click(function() {
                    $.panelslider.close();
                });
            </script>
        </telerik:RadScriptBlock>
        <asp:HiddenField ID="HiddenFieldWindowLogger" runat="server" Value="" />
        <asp:HiddenField ID="HiddenFieldWorkspaceLogger" runat="server" Value="" />
        <asp:HiddenField ID="HiddenFieldCurrentWorkspaceId" runat="server" Value="" />
        <asp:HiddenField ID="HiddenFieldFloatDesktopObjects" runat="server" Value="false" />
        <asp:HiddenField ID="HiddenFieldAutoOpenWindowsLoaded" runat="server" Value="false" />
        <asp:HiddenField ID="HiddenFieldChatEnabled" runat="server" Value="false" />
        <div id="empName" style="display: none !important;"><%=Session("EmployeeName")%></div>
        <telerik:RadCodeBlock ID="RadCodeBlockParentBottom" runat="server">
            <script type="text/javascript">

                <%= Me.JavascriptAlertTimer %>

                var manager = null;
                var CurrentWindows = new Array();
                var WorkspaceLogger = null;
                var chatEnabled = false;

                if ($("#HiddenFieldChatEnabled").val() == "True") {
                    chatEnabled = true;
                }
                $(document).on("keydown", function (e) {
                    if (e.which === 8 && !$(e.target).is("input, textarea")) {
                        e.preventDefault();
                    }
                });
                function pageLoad() {
                    var isLoaded = "false";
                    isLoaded = document.getElementById("HiddenFieldAutoOpenWindowsLoaded").value;
                    if (isLoaded == "false") {
                        SetObjects();
                        //OpenAlertNotifiy();
                        OpenUiActionWindow();
                        if (chatEnabled && chatEnabled == true) {
                            OpenChatRoomsWindow(false);
                        }
                        var x = 0;
                        var temp = '';
                        var WindowsToOpen = new Array();
                        var WindowsTop = new Array();
                        var WindowsLeft = new Array();
                        var WindowsHeight = new Array();
                        var WindowsWidth = new Array();
                        var WindowsTitle = new Array();
                        <%= Me.JavascriptWindowsArrays %>
                        if (WindowsToOpen.length > 0) {
                            for (x = 0; x < WindowsToOpen.length; x++) {
                                var WindowURL = '';
                                var WindowTitle = '';
                                var WindowTop = 0;
                                var WindowLeft = 0;
                                var WindowHeight = 0;
                                var WindowWidth = 0;
                                WindowURL = WindowsToOpen[x];
                                WindowTitle = WindowsTitle[x];
                                WindowTop = WindowsTop[x];
                                WindowLeft = WindowsLeft[x];
                                WindowHeight = WindowsHeight[x];
                                WindowWidth = WindowsWidth[x];
                                OpenRadWindow(WindowTitle, WindowURL, WindowHeight, WindowWidth, false, WindowTop, WindowLeft);
                            };
                        };
                    };
                    isLoaded = "true";
                    document.getElementById("HiddenFieldAutoOpenWindowsLoaded").value = isLoaded;
                };

                function reloadDefaultWorkspaceLeftMiddle() {
                    $('#iFrameDefaultWorkspaceLeftMiddle')[0].contentWindow.refreshUpdatePanel();
                    console.log("reloadDefaultWorkspaceLeftMiddle")
                }
                $(document).unbind('keydown').bind('keydown', function (event) {
                    var doPrevent = false;
                    if (event.keyCode === 8) {
                        var d = event.srcElement || event.target;
                        if ((d.tagName.toUpperCase() === 'INPUT' && 
                             (
                                 d.type.toUpperCase() === 'TEXT' ||
                                 d.type.toUpperCase() === 'PASSWORD' || 
                                 d.type.toUpperCase() === 'FILE' || 
                                 d.type.toUpperCase() === 'EMAIL' || 
                                 d.type.toUpperCase() === 'SEARCH' || 
                                 d.type.toUpperCase() === 'DATE' )
                             ) || 
                             d.tagName.toUpperCase() === 'TEXTAREA') {
                            doPrevent = d.readOnly || d.disabled;
                        }
                        else {
                            doPrevent = true;
                        };
                    };
                    if (doPrevent) {
                        event.preventDefault();
                    };
                });
                $(document).on("keydown", function (e) {
                    //extendTimeout();
                });
                $(document).on("mousemove", function (e) {
                    //extendTimeout();
                });
                $(document).on("mousedown", function (e) {
                    //extendTimeout();
                });
                $(window).resize(function(){
                    //$('.workspace-logo').css({
                    //    position:'absolute',
                    //    left: ($(window).width() - $('.workspace-logo').outerWidth())/2,
                    //    top: ($(window).height() - $('.workspace-logo').outerHeight())/2,
                    //    zIndex: 100
                    //});
                    PositionWorkspaceLogo();
                });
                $(window).resize();

                var chatActive = '<%=Session("CheckModuleAccessDesktop_Chat").ToString.ToLower%>';

                $(document).ready(function () {

                    PositionWorkspaceLogo();
                    extendTimeout();
                    updateTimeCounts();
                    updateAlertAssignmentTaskCount();
                    checkForMissingDeniedTime();

                    if (chatEnabled == false) {
                        $("#DivChatButton").hide();
                    }

                    var notifier = $.connection.notificationHub;
                    //  Helpers
                    //  Callbacks from server
                    notifier.client.sayHello = function () {
                        window.setTimeout(function () {
                            alert("Hello!");
                        }, 10);
                    };
                    notifier.client.refreshAlerts = function () {
                        window.setTimeout(function () {
                            RefreshAlertWindows(true, true);
                        }, 10);
                    };
                    notifier.client.refreshSprint = function (sprintId, sprintIsActive, sprintIsComplete, employeeName) {
                        window.setTimeout(function () {
                            refreshSprint(sprintId, sprintIsActive, sprintIsComplete, employeeName);
                        }, 10);
                    };
                    notifier.client.refreshNewAlertView = function (alertId, sprintId, employeeName) {
                        window.setTimeout(function () {
                            refreshNewAlertView(alertId, sprintId, employeeName);
                        }, 10);
                    };

                    notifier.client.refreshDashboardWorkItems = function () {
                        window.setTimeout(function () {
                            refreshDashboardWorkItems();
                        }, 10);
                    };

                    //  Connection params
                    var uc = "";
                    var ec = ""
                    var en = "";
                    var guid = "";
                    try {
                        en = $("#empName").text();
                    } catch (e) {en = ""}
                    $.connection.hub.qs = {
                        'u': "",
                        'e': "",
                        'n': "",
                        'guid': "",
                        'ca' : chatActive
                    };
                    //  Log to console
                    //$.connection.hub.logging = true;
                    if ($.connection.hub && $.connection.hub.state === $.signalR.connectionState.disconnected) {
                        $.connection.hub
                            .start({ waitForPageLoad: false }, function () {
                            })
                            .done(function () {
                            });
                    }
                });
            </script>
        </telerik:RadCodeBlock>
        <!-- Page -->
        <!-- Scripts -->
        <telerik:RadSkinManager ID="RadSkinManagerParent" runat="server" ShowChooser="false">
            <TargetControls>
                <telerik:TargetControl ControlsToApplySkin="NotSet" />
            </TargetControls>
        </telerik:RadSkinManager>
        <telerik:RadFormDecorator ID="RadFormDecoratorParent" runat="server" DecoratedControls="All"
            EnableRoundedCorners="false" EnableEmbeddedBaseStylesheet="true" EnableAjaxSkinRendering="true"
            EnableEmbeddedScripts="true" EnableEmbeddedSkins="true" RenderMode="Classic" />
        <telerik:RadContextMenu ID="RadContextMenuWorkspaces" runat="server" OnClientItemClicked="RadContextMenuWorkspaces_Clicked" EnableShadows="false">
            <Targets>
                <telerik:ContextMenuDocumentTarget />
            </Targets>
            <Items>
                <telerik:RadMenuItem Text="<strong>Dashboard</strong>" Value="DefaultWorkspace" />
                <telerik:RadMenuItem IsSeparator="true" Value="PreviousWorkspaceSeparator" />
                <telerik:RadMenuItem Text="Previous Workspace" Value="PreviousWorkspace" />
                <telerik:RadMenuItem IsSeparator="true" Value="NextWorkspaceSeparator" />
                <telerik:RadMenuItem Text="Next Workspace" Value="NextWorkspace" />
                <telerik:RadMenuItem IsSeparator="true" />
                <telerik:RadMenuItem Text="Manage Workspaces" Value="ManageWorkspaces" />
                <telerik:RadMenuItem IsSeparator="true" />
                <telerik:RadMenuItem Text="Delete current Workspace" Value="DeleteWorkspace" Visible="false" />
                <telerik:RadMenuItem IsSeparator="true" Visible="false" />
                <telerik:RadMenuItem Text="Sign Out" Value="SignOut" />
            </Items>
        </telerik:RadContextMenu>
        <telerik:RadAjaxManager ID="RadAjaxManagerParent" runat="server" EnableAJAX="true"
            UpdatePanelsRenderMode="Inline" EnableHistory="true" EnableTheming="true" DefaultLoadingPanelID="RadAjaxLoadingPanelParent">
        </telerik:RadAjaxManager>
        <telerik:RadWindowManager ID="RadWindowManagerParent" runat="server"
            IconUrl="~/Images/blank.ico"
            Animation="None"
            EnableTheming="true"
            Opacity="100"
            RestrictionZoneID="maincontent"
            OffsetElementID="maincontent"
            AnimationDuration="0"
            DestroyOnClose="true"
            EnableShadow="false"
            PreserveClientState="true"
            ShowContentDuringLoad="False"
            ShowOnTopWhenMaximized="False"
            VisibleStatusbar="false"
            VisibleTitlebar="true"
            ReloadOnShow="false"
            KeepInScreenBounds="true"
            Style="z-index: 2501;"
            CssClass="scroll"
            Behaviors="Close,Maximize,Minimize,Move,Reload,Resize"
            OnClientDragEnd="RadWindowManagerParentSavePositionAndSize"
            OnClientBeforeClose="RadWindowManagerParentOnClientBeforeClose"
            OnClientShow="RadWindowManagerParentOnClientShow"
            OnClientResizeEnd="RadWindowManagerParentSavePositionAndSize"
            OnClientClose="RadWindowManagerParentOnClientClose"
            OnClientPageLoad="RadWindowManagerParentOnClientPageLoad"
            EnableViewState="False">
        </telerik:RadWindowManager>
        <telerik:RadNotification runat="server" ID="RadNotificationLicenseKey" Width="100%"
            Height="110px" EnableRoundedCorners="true" EnableShadow="false" VisibleTitlebar="false"
            Position="TopCenter" Animation="Slide" AutoCloseDelay="0" VisibleOnPageLoad="false"
            OffsetY="25" Overlay="true">
            <ContentTemplate>
                <div style="text-align: center;">
                    <h4>
                        <asp:Label Style="font-size: 18px;" ID="LabelNotificationMessage" Text="" runat="server" />
                    </h4>
                    <telerik:RadButton runat="server" ID="RadButtonDontRemindMeAgain" Text="Don't remind me again"
                        AutoPostBack="true">
                    </telerik:RadButton>
                    <telerik:RadButton runat="server" ID="RadButtonRemindMeAgainTomorrow" Text="Remind me again tomorrow"
                        AutoPostBack="true">
                    </telerik:RadButton>
                </div>
            </ContentTemplate>
        </telerik:RadNotification>
        <telerik:RadNotification ID="RadNotificationParent" runat="server" VisibleOnPageLoad="false"
            Width="380" Height="500" Animation="Fade" EnableRoundedCorners="false" EnableShadow="false"
            Title="New Apps Available!" ShowTitleMenu="true" OffsetX="-67" OffsetY="1" TitleIcon="none" ContentIcon="none"
            Position="TopRight" ContentScrolling="Auto" AutoCloseDelay="0" ShowCloseButton="False">
            <NotificationMenu OnClientItemClicked="RadNotificationParentNotificationMenuOnClientItemClicked">
                <Items>
                    <telerik:RadMenuItem Text="Read" Value="Read">
                    </telerik:RadMenuItem>
                    <telerik:RadMenuItem Text="Hide" Value="Hide">
                    </telerik:RadMenuItem>
                </Items>
            </NotificationMenu>
        </telerik:RadNotification>
        <telerik:RadPersistenceManager ID="RadPersistenceManagerParent" runat="server">
            <PersistenceSettings>
            </PersistenceSettings>
        </telerik:RadPersistenceManager>
    </form>
</body>
</html>
