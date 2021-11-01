<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Incompatible.aspx.vb"
    Inherits="Webvantage.Incompatible" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Incompatible Browser Detected</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <style type="text/css">
        body,td,th {
	        font-family: Verdana, Geneva, sans-serif;
	        font-size: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table width="600" border="0" cellspacing="4" cellpadding="4" align="center">
        <tr>
            <td colspan="2">
                <h2>
                    Incompatible Browser Detected</h2>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                Please contact your System Administator or choose from the following browsers.<br />
            </td>
        </tr>
        <tr>
            <td>
                <a href="http://www.mozilla.org/en-US/firefox/new/" target="_blank">Mozilla FireFox</a>&copy;
            </td>
            <td>
                <a href="http://www.mozilla.org/en-US/firefox/new/" target="_blank">
                    <img src="Images/logo_ff.png" alt="Download FireFox" width="168" height="168" border="0" /></a>
            </td>
        </tr>
        <tr>
            <td>
                <a href="https://www.google.com/intl/en/chrome/browser/" target="_blank">Google Chrome</a>&copy;
            </td>
            <td>
                <a href="https://www.google.com/intl/en/chrome/browser/" target="_blank">
                    <img src="Images/logo_chrome.png" alt="Download Chrome Browser" width="168" height="168"
                        border="0" /></a>
            </td>
        </tr>
        <tr>
            <td>
                <a href="http://www.apple.com/safari/" target="_blank">Safari</a>&copy;
            </td>
            <td>
                <a href="http://www.apple.com/safari/" target="_blank">
                    <img src="Images/logo_safari.png" alt="Download Safari Browser" width="168" height="168"
                        border="0" /></a>
            </td>
        </tr>
        <tr>
            <td width="343">
                <a href="http://windows.microsoft.com/en-us/internet-explorer/products/ie/home/"
                    target="_blank">Microsoft Internet Explorer</a>&copy;
                    <br />
                    <div style="font-size:10px !important;">
                         Version 9 or higher.  Do <strong>not</strong> use "Compatibility" view feature.
                    </div>
            </td>
            <td width="229">
                <a href="http://windows.microsoft.com/en-us/internet-explorer/products/ie/home/"
                    target="_blank">
                    <img src="Images/logo_ie.png" alt="Download Internet Explorer" width="168" height="168"
                        border="0" /></a>
            </td>
        </tr>
        <tr>
            <td align="right" valign="middle">
                Your Browser:
            </td>
            <td valign="middle">
                <asp:Label ID="LabelBrowserType" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" valign="middle">
                Version:
            </td>
            <td valign="middle">
                <asp:Label ID="LabelBrowserVersion" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
    </table>

    <asp:Panel ID="PanelYouShouldNotBeHere" runat="server" Visible="false">
        <div style="margin:20px;border: 2px solid red; background-color:LightGray; padding:5px; padding-left:10px;">
            Your browser is compatible.<br />
            Please 
            <asp:HyperLink ID="HyperLinkBackToSignIn" runat="server" Text="go to the Sign In page" NavigateUrl="SignIn.aspx"></asp:HyperLink>.<br />
            If you are re-directed back to this page again, please contact your System Administrator.
            <br />
        </div>
    </asp:Panel>
                 
  </form>
</body>

</html>
