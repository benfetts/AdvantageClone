<%@ Page Title="ETF Print Scheduler" Language="vb" AutoEventWireup="false" CodeBehind="EmployeeTimeForecast_SchedulerPrint.aspx.vb"
    Inherits="Webvantage.EmployeeTimeForecast_SchedulerPrint" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="Print_Buttons.ascx" TagName="Print_Buttons" TagPrefix="webvantage" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head" runat="server">
    <title>Job Schedule</title>
    <link href="CSS/Common.min.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        body
        {
            margin-left: 0px;
            margin-top: 0px;
            margin-right: 0px;
            margin-bottom: 0px;
            background-color: #FFFFFF;
        }
    </style>
</head>
<body>
    <form id="Form" runat="server">
    <telerik:RadScriptBlock ID="RadScriptBlockRadWindow" runat="server">
        <script type="text/javascript">
            function GetRadWindow() {

                var RadWindow = null;

                if (window.radWindow)
                    RadWindow = window.radWindow;
                else if (window.frameElement.radWindow)
                    RadWindow = window.frameElement.radWindow;

                return RadWindow;

            }
            function CloseOnReload() {
                GetRadWindow().Close();
            }
            function RefreshParentPage() {
                GetRadWindow().BrowserWindow.location.reload();
            }
            function RedirectParentPage(newUrl) {
                GetRadWindow().BrowserWindow.document.location.href = newUrl;
            }
            function CallFunctionOnParentPage(fnName) {

                var RadWindow = GetRadWindow();

                if (RadWindow.BrowserWindow[fnName] && typeof (RadWindow.BrowserWindow[fnName]) == "function") {

                    RadWindow.BrowserWindow[fnName](RadWindow);
                    RadWindow.Close();

                }

            }
        </script>
    </telerik:RadScriptBlock>
     <telerik:RadBinaryImage ID="RadBinaryImageScreenShot" runat="server" />
    <webvantage:Print_Buttons ID="PrintButtonsPrintOrClose" runat="server" />
    </form>
</body>
</html>
