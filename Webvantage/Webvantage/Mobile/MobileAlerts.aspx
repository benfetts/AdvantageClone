<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MobileAlerts.aspx.vb"
    Inherits="Webvantage.MobileAlerts" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Webvantage Mobile</title>
    
    
    <link href="~/CSS/MobileBB.min.css" rel="stylesheet" type="text/css" />
    <meta http-equiv="CACHE-CONTROL" content="NO-CACHE"/>
    <meta name="viewport" content="width = 320" />  
    <meta name="viewport" content="initial-scale=1, user-scalable=yes" />
</head>
<body style="width: 400px; height: 300px">
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
            <asp:Label   runat="server" ID="lblCount" Text="Alert count:" Width="90px"></asp:Label>
            <asp:DropDownList runat="server" ID="ddCount"  AutoPostBack="True" Width="87px">
                <asp:ListItem Text="5" Value="5"></asp:ListItem>
                <asp:ListItem Text="10" Value="10"></asp:ListItem>
                <asp:ListItem Text="15" Value="15"></asp:ListItem>
                <asp:ListItem Text="20" Value="20"></asp:ListItem>
            </asp:DropDownList>
            <asp:Button runat="server" ID="btnRefreshList" BorderStyle="Solid" BorderWidth="1px" Font-Size="XX-Small" Text=">" Visible="false"/>
            <asp:GridView ID="gvAlerts" runat="server" CellPadding="5" ForeColor="#333333" GridLines="both"
                AutoGenerateColumns="false">
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#999999" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:TemplateField SortExpression="" HeaderImageUrl="~/images/view-trans.png">
                        <HeaderStyle HorizontalAlign="Center" Width="15px" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="15px" />
                        <ItemTemplate>
                            <asp:HyperLink ID="ViewHyperlink" runat="server"></asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderImageUrl="~/images/bang.png" SortExpression="PRIORITY">
                        <HeaderStyle Width="15px" />
                        <ItemStyle VerticalAlign="Top" />
                        <ItemTemplate>
                            <asp:Image ID="PriorityImage" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField SortExpression="SUBJECT" ItemStyle-Wrap="true" ItemStyle-Width="150px"
                        HeaderText="Subject">
                        <HeaderStyle Width="150px" />
                        <ItemTemplate>
                            <asp:HyperLink ID="hlView" runat="server" Visible="true"></asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="TYPE" HeaderText="Type" SortExpression="TYPE" HeaderStyle-Width="75px"
                        ItemStyle-Width="75px" HtmlEncode="false" DataFormatString="{0}" />
                    <asp:BoundField DataField="Generated" HeaderText="Date" HtmlEncode="false" DataFormatString="{0:d}"
                        ItemStyle-HorizontalAlign="Right" HeaderStyle-Width="100px" ItemStyle-Width="100px" />
                    <asp:BoundField DataField="READ_ALERT" HeaderText="" Visible="false" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
