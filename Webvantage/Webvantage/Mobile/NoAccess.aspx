<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="NoAccess.aspx.vb" Inherits="Webvantage.NoAccess1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Webvantage Mobile</title>
    
    
    <link href="~/CSS/MobileBB.min.css" rel="stylesheet" type="text/css" />
    <meta http-equiv="CACHE-CONTROL" content="NO-CACHE" />
    <meta name="viewport" content="width = 320" />
    <meta name="viewport" content="initial-scale=1, user-scalable=yes" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table id="tblMobileHeader" runat="server" width="200">
                <tr>
                    <td style="width: 60px;">
                        <asp:Button runat="server" ID="btnBack" Text="Back" ForeColor="blue" BorderStyle="Solid"
                            BorderWidth="1px" Font-Size="XX-Small" />
                    </td>
                    <td style="width: 60px;">
                        <asp:Button runat="server" ID="btnLogout" Text="Logout" ToolTip="Logout" ForeColor="blue"
                            BorderStyle="Solid" BorderWidth="1px" Font-Size="XX-Small"></asp:Button>
                    </td>
                </tr>
            </table>
     <table border="0" cellpadding="0" cellspacing="0" >
                <tr>
                    <td align="center" valign="middle">
                        <p>No Access</p></td>
              </tr>
            </table>
    </div>
    </form>
</body>
</html>
