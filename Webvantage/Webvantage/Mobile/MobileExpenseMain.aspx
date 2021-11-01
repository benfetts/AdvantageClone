<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MobileExpenseMain.aspx.vb"
    Inherits="Webvantage.MobileExpenseMain" %>

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
            <br />
            <table>
                <tr>
                    <td>
                        &nbsp;&nbsp;&nbsp;&nbsp;View Expense Report:&nbsp;&nbsp; Emp Code:
                        <asp:TextBox ID="txtEmpCode" runat="server"  Width="50px" 
                            AutoCompleteType="Cellular"></asp:TextBox>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;&nbsp;Month/Year
                        <asp:DropDownList ID="ddlMonth" runat="server" AutoPostBack="true" >
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="true" >
                        </asp:DropDownList>
                        <asp:ImageButton runat="server" ID="ibRefresh" ImageUrl="~/images/recycle-trans.png"
                            AlternateText="Refresh" CommandName="Refresh" />
                        <asp:ImageButton runat="server" ID="ibNewExpense" ImageUrl="~/Images/add2.png" AlternateText="New Expense Report"
                            CommandName="NewExpense" />
                    </td>
                </tr>
                <tr>
                    <td>
                    <asp:Label   ID="lblMessage" runat="server" Text="" CssClass="warning"></asp:Label>
                    </td>
                </tr>
            </table>
            <asp:GridView ID="gvExpense" runat="server" CellPadding="5" ForeColor="#333333" GridLines="both"
                AutoGenerateColumns="false">
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#999999" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:TemplateField HeaderText="Expense #">
                        <HeaderStyle HorizontalAlign="left" VerticalAlign="middle" />
                        <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                        <ItemTemplate>
                            <asp:Literal ID="LitViewEdit" runat="server"></asp:Literal>
                        </ItemTemplate>
                    </asp:TemplateField>
                   <asp:BoundField DataField="INV_NBR" HeaderText="Expense #" Visible="false">
                                   <HeaderStyle HorizontalAlign="left" VerticalAlign="middle" />
                                   <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                               </asp:BoundField>
                    <asp:BoundField DataField="INV_DATE" HeaderText="Date">
                        <HeaderStyle HorizontalAlign="left" VerticalAlign="middle" />
                        <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="EXP_DESC"  HeaderText="Description" ItemStyle-Wrap="True">
                        <HeaderStyle HorizontalAlign="left" VerticalAlign="middle" />
                        <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="STATUS_CALC_DESC" HeaderText="Status">
                        <HeaderStyle HorizontalAlign="center" VerticalAlign="middle" />
                        <ItemStyle HorizontalAlign="center" VerticalAlign="middle" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Paid">
                        <ItemTemplate>
                            <asp:HyperLink ID="PaidImage" runat="server" Enabled="true" ImageUrl="~/Images/check2.png" />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="center" Width="25px" />
                        <ItemStyle HorizontalAlign="center" Width="25px" VerticalAlign="Middle" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
