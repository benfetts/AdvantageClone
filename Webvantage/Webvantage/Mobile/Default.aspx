<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="Webvantage._MobileDefault" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Webvantage Mobile</title>
    
    
    <link href="~/CSS/MobileBB.min.css" rel="stylesheet" type="text/css" />
    <meta http-equiv="CACHE-CONTROL" content="NO-CACHE" />
    <meta name="viewport" content="width = 320" />
    <meta name="viewport" content="initial-scale=1, user-scalable=yes" />
</head>
<body style="width: 200px; height: 300px">
    <form id="form1" runat="server">
    <div>
        <table id="tblMobileHeader" runat="server" width="200">
            <tr>
                <td>
                </td>
                <td>
                    <asp:Button runat="server" ID="btnLogout" Text="Logout" ToolTip="Logout" ForeColor="blue"
                        BorderStyle="Solid" BorderWidth="1px" Font-Size="XX-Small"></asp:Button>
                </td>
            </tr>
        </table>
       
        <table id="tblWebApplications" runat="server" border="0" width="200px">
            <thead>
                <tr>
                    <th style="background-color: #d8e4f8;">
                        Select Mobile Application
                    </th>
                </tr>
            </thead>
            <tr>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:HyperLink runat="server" ID="hlAlerts" NavigateUrl="~/mobile/mobilealerts.aspx"
                        Text="Alerts" ToolTip="Mobile Alerts" />
                </td>
            </tr>
            <tr>
                <td>&nbsp;
                </td>
            </tr>
            <tr>
                <td style="height: 21px">
                    <asp:HyperLink runat="server" ID="hlTasks" NavigateUrl="~/mobile/mobiletasks.aspx"
                        Text="My Tasks" ToolTip="Mobile Tasks" />
                </td>
            </tr>
            <tr>
                <td>&nbsp;
                </td>
            </tr>
            <tr>
                <td style="height: 21px">
                    <asp:HyperLink runat="server" ID="hlMobileExpenses" NavigateUrl="~/mobile/MobileExpenseMain.aspx"
                        Text="Expenses" ToolTip="Mobile Expenses" />
                </td>
            </tr>
            <tr>
                <td>&nbsp;
                </td>
            </tr>
            <tr>
                <td style="height: 21px">
                    <asp:HyperLink runat="server" ID="hlMobileTime" NavigateUrl="~/mobile/MobileBasicTime.aspx"
                        Text="Time Entry" ToolTip="Mobile Time Entry" />
                </td>
            </tr>
            <tr>
                <td>&nbsp;
                </td>
            </tr>
            <tr>
                <td style="height: 21px">
                    <asp:HyperLink runat="server" ID="hlBrowserInfo" NavigateUrl="~/mobile/MobileBTest.aspx"
                        Text="Browser Check" ToolTip="Browser Info" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
