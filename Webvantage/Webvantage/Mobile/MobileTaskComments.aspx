<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MobileTaskComments.aspx.vb"
    Inherits="Webvantage.MobileTaskComments" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
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
            <table>
                <asp:Label   ID="lblMsg1" runat="server" CssClass="CssRequired"></asp:Label><tr>
                    <td>
                        Completion Comments:
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtComments" runat="server" TextMode="MultiLine" Width="100%" Rows="7" ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:CheckBox ID="chkMarkCompleted" runat="server" Text="Mark Completed" Checked="true" />
                        <asp:CheckBox ID="chkMarkNotCompleted" runat="server" Text="Mark Not Completed" />
                    </td>
                </tr>
                <tr >
                    <td align="center"  valign="middle">
                        <br />
                        <asp:LinkButton ID="BtnSave"  runat="server" Text="Save"></asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:LinkButton ID="btnCancel"  runat="server" CausesValidation="False"
                            CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
