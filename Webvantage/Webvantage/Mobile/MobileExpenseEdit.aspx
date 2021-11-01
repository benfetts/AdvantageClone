<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MobileExpenseEdit.aspx.vb"
    Inherits="Webvantage.MobileExpenseEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    
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
            <br />
            <table runat="server" id="tblMain">
                <tr>
                   
                    <td>Report #:
                        <asp:Label   runat="server" ID="lblReportNum"></asp:Label>
                    </td>
                </tr>
                <tr>
                   
                    <td>Employee: 
                        <asp:Label   runat="server" ID="lblEmployee"></asp:Label>
                    </td>
                </tr>
                <tr>
                   
                    <td>Report Date:
                        <asp:TextBox runat="server" ID="txtReportDate"  
                            AutoCompleteType="Cellular" CssClass="RequiredInput"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                   
                    <td>Description:
                        <asp:TextBox runat="server" ID="txtDescription"  
                            AutoCompleteType="Cellular" CssClass="RequiredInput"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    
                    <td><b style="vertical-align: top; text-align: left">Detail:
                        <asp:TextBox runat="server" ID="txtDetail"  
                            TextMode="MultiLine" AutoCompleteType="Cellular"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <asp:LinkButton ID="lbAddItem" runat="server" Enabled="False" Visible="false">Add Item</asp:LinkButton>&nbsp;
            <asp:LinkButton ID="lbDeleteItem" runat="server" Enabled="False" Visible="false">Delete</asp:LinkButton>&nbsp;
            <asp:LinkButton ID="lbSave" runat="server" Enabled="False" Visible="false">Save</asp:LinkButton>&nbsp;
            <asp:LinkButton ID="lbSubmit" runat="server" Enabled="false" Visible="false">Submit</asp:LinkButton>&nbsp;
             <asp:LinkButton ID="lbUnSubmit" runat="server" Enabled="false" Visible="false">Un-submit</asp:LinkButton>&nbsp;
            <table runat="server" id="tblItems">
                <tr>
                    <td colspan="2">
                        Items:<br />
                        <asp:DropDownList runat="server" ID="ddItems" 
                            >
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:LinkButton ID="lbViewItem" runat="server" Enabled="False">View Selected Item</asp:LinkButton>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <br />
                        <asp:Label   ID="lblMessage" runat="server"></asp:Label><br />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Total Expense: $</td>
                    <td align="left">
                        <asp:Label   runat="server" ID="lblTotalExpense" Text="0.0"></asp:Label></td>
                </tr>
                <tr>
                    <td align="right">
                        Less Credit Card: $</td>
                    <td align="left">
                        <asp:Label   runat="server" ID="lblLessCreditCard" Text="0.0"></asp:Label></td>
                </tr>
                <tr>
                    <td align="right">
                        Total Due: $</td>
                    <td align="left">
                        <asp:Label   runat="server" ID="lblTotalDue" Text="0.0"></asp:Label></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
