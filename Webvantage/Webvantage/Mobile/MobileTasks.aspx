<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="MobileTasks.aspx.vb" Inherits="Webvantage.MobileTasks" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
        <table border="0" cellpadding="2" cellspacing="0">
            <tr>
                <td align="Left">
                    Type:
                    <asp:DropDownList ID="ddType" runat="server" AutoPostBack="true" EnableViewState="true">
                        <asp:ListItem Value="All">All</asp:ListItem>
                        <asp:ListItem Value="Projected">Projected</asp:ListItem>
                        <asp:ListItem Value="Active">Active</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Tasks:
                    <asp:DropDownList ID="ddTaskShow" runat="server" AutoPostBack="true" EnableViewState="true">
                        <asp:ListItem Value="Today">Open Tasks to Start as of Today</asp:ListItem>
                        <asp:ListItem Value="All">All Open Tasks </asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;
                    <asp:ImageButton ID="butRefresh" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/recycle-trans.png"
                        ToolTip="Refresh" PostBackUrl="~/Mobile/MobileTasks.aspx" />
                </td>
            </tr>
        </table>
        <asp:GridView ID="gvMyTasks" runat="server" CellPadding="1" Width="500px" ForeColor="#333333"
            GridLines="both" AutoGenerateColumns="false">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-Width="50px">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="middle" />
                    <ItemTemplate>
                        <asp:HyperLink runat="server" ID="ViewHyperlink" ImageUrl="~/Images/view-trans.png"></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="CDP" HeaderText="CDP" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="JobData" ItemStyle-HorizontalAlign="Center" HeaderText="Job/Comp Number" />
                <asp:BoundField DataField="Task" ItemStyle-HorizontalAlign="Center" HeaderText="Task" />
                <asp:BoundField DataField="HoursAllowed" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="50px"
                    HeaderText="Hours" Visible="true" />
                <asp:TemplateField HeaderText="Due Date" HeaderStyle-Width="50px">
                    <ItemTemplate>
                        <span>
                            <asp:Label runat="server" ID="LabelDueDate"></asp:Label>
                        </span>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="DueTime" HeaderStyle-Width="50px" ItemStyle-HorizontalAlign="Center"
                    HeaderText="Time Due" />
                <asp:BoundField DataField="EmpCode" Visible="false" />
            </Columns>
        </asp:GridView>
        <!-- The following code is for devices like black berry that don't do wide tables-->
        <asp:Repeater runat="server" ID="rptTasks" Visible="false">
            <HeaderTemplate>
                <table border="1" cellpadding="5">
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        <span>
                            <asp:HyperLink runat="server" ID="ViewHyperlinkBB" ImageUrl="~/Images/view-trans.png"></asp:HyperLink>
                            CDP:&nbsp;<asp:Label runat="server" ID="lblCDP"></asp:Label>
                        </span>
                    </td>
                </tr>
                <tr>
                    <td>
                        <span>Job Number/Description:&nbsp;<asp:Label runat="server" ID="lblJobData"></asp:Label>
                        </span>
                    </td>
                </tr>
                <tr>
                    <td>
                        <span>Task Description:&nbsp;
                            <asp:Label runat="server" ID="lblTask"></asp:Label>
                        </span>
                    </td>
                </tr>
                <tr>
                    <td>
                        <span>Hours Allowed:&nbsp;
                            <asp:Label runat="server" ID="lblHoursAllowed"></asp:Label>
                        </span>
                    </td>
                </tr>
                <tr>
                    <td>
                        <span>Due Date:&nbsp;<asp:Label runat="server" ID="lblDueDate"></asp:Label>
                        </span>
                    </td>
                </tr>
                <tr>
                    <td>
                        <span>Time Due:&nbsp;<asp:Label runat="server" ID="lblTimeDue"></asp:Label>
                        </span>
                    </td>
                </tr>
                <tr>
                    <td>
                        <span>
                            <%#Eval("EmpCode")%>
                        </span>
                    </td>
                </tr>
            </ItemTemplate>
            <SeparatorTemplate>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
            </SeparatorTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
    </form>
</body>
</html>