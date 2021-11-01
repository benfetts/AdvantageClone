<%@ Page AutoEventWireup="false" CodeBehind="DashboardClientTimeDetail.aspx.vb" Inherits="Webvantage.DashboardClientTimeDetail"
    Language="vb" MasterPageFile="~/ChildPage.Master" Title="Dashboard" %>

<asp:Content ID="ContentDashboard" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left">
                            <table align="left" border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td align="left" valign="top" width="5%">
                                        <telerik:RadToolBar ID="RadToolbarData" runat="server" AutoPostBack="True" Width="100%">
                                            <Items>
                                            </Items>
                                        </telerik:RadToolBar>
                                    </td>
                                    <td align="left" valign="top" width="45%">
                                        <telerik:RadToolBar ID="RadToolbarDashProject" runat="server" AutoPostBack="True"
                                            Width="100%">
                                            <Items>
                                                <telerik:RadToolBarButton IsSeparator="true" />
                                                <telerik:RadToolBarButton Text="Year to Date" Value="YeartoDate" ToolTip="Calculate Data year to Date"
                                                    CheckOnClick="true" Checked="true" AllowSelfUnCheck="true" />
                                                <telerik:RadToolBarButton IsSeparator="true" />
                                                <telerik:RadToolBarButton Text="Month" Value="Month" ToolTip="Calculate Data by Month"
                                                    CheckOnClick="true" Checked="true" AllowSelfUnCheck="true" />
                                                <telerik:RadToolBarButton IsSeparator="true" />
                                                <telerik:RadToolBarButton runat="server">
                                                    <ItemTemplate>
                                                        &nbsp;Month:
                                                        <telerik:RadComboBox ID="DropDownListMonth" runat="server" AutoPostBack="true" SkinID="RadComboBoxStandard">
                                                        </telerik:RadComboBox>
                                                        &nbsp;
                                                    </ItemTemplate>
                                                </telerik:RadToolBarButton>
                                                <telerik:RadToolBarButton IsSeparator="true" />
                                                <telerik:RadToolBarButton runat="server">
                                                    <ItemTemplate>
                                                        &nbsp;Week:
                                                        <telerik:RadComboBox ID="DropDownListWeek" runat="server" AutoPostBack="true" SkinID="RadComboBoxStandard">
                                                        </telerik:RadComboBox>
                                                        &nbsp;
                                                    </ItemTemplate>
                                                </telerik:RadToolBarButton>
                                                <telerik:RadToolBarButton IsSeparator="true" />
                                            </Items>
                                        </telerik:RadToolBar>
                                    </td>
                                    <td align="left" valign="top" width="50%">
                                        <telerik:RadToolBar ID="RadToolbarPE" runat="server" Width="100%">
                                            <Items>
                                                <telerik:RadToolBarButton IsSeparator="true" />
                                                <telerik:RadToolBarButton runat="server">
                                                    <ItemTemplate>
                                                        &nbsp;Summary Level:
                                                        <telerik:RadComboBox ID="DropDownListLevel" runat="server" AutoPostBack="true" SkinID="RadComboBoxText25" >
                                                            <Items>
                                                              <telerik:RadComboBoxItem Value="C" Text="Client">
                                                            </telerik:RadComboBoxItem>
                                                            <telerik:RadComboBoxItem Value="CD" Text="Client/Division">
                                                            </telerik:RadComboBoxItem>
                                                            <telerik:RadComboBoxItem Value="CDP" Text="Client/Division/Product">
                                                            </telerik:RadComboBoxItem>
                                                            <telerik:RadComboBoxItem Value="AE" Text="Account Executive">
                                                            </telerik:RadComboBoxItem>
                                                            <telerik:RadComboBoxItem Value="dept" Text="Department">
                                                            </telerik:RadComboBoxItem>
                                                            <telerik:RadComboBoxItem Value="SC" Text="Sales Class">
                                                            </telerik:RadComboBoxItem>
                                                            <telerik:RadComboBoxItem Value="JT" Text="Job Type">
                                                            </telerik:RadComboBoxItem>
                                                          </Items>
                                                        </telerik:RadComboBox>
                                                        &nbsp;
                                                    </ItemTemplate>
                                                </telerik:RadToolBarButton>
                                                <telerik:RadToolBarButton IsSeparator="true" />
                                                <telerik:RadToolBarButton Text="" Value="Print" SkinID="RadToolBarButtonPrint" />
                                                <telerik:RadToolBarButton IsSeparator="true" />
                                                <telerik:RadToolBarButton SkinID="RadToolBarButtonExportExcel" ToolTip="Export to Excel" Value="Export" />
                                                <telerik:RadToolBarButton IsSeparator="true" />
                                                <telerik:RadToolBarButton runat="server">
                                                    <ItemTemplate>
                                                        &nbsp;<asp:CheckBox ID="CheckBoxExport" runat="server" Text="Export By Column" Visible="false" />&nbsp;
                                                    </ItemTemplate>
                                                </telerik:RadToolBarButton>
                                            </Items>
                                        </telerik:RadToolBar>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top" colspan="2">
                                        <telerik:RadToolBar ID="RadToolbarDataType" runat="server" AutoPostBack="True" Width="100%">
                                            <Items>
                                                <telerik:RadToolBarButton IsSeparator="true" />
                                                <telerik:RadToolBarButton Text="Hours" Value="Hours" ToolTip="Hours" CheckOnClick="true"
                                                    Checked="true" AllowSelfUnCheck="true" />
                                                <telerik:RadToolBarButton IsSeparator="true" />
                                                <telerik:RadToolBarButton Text="Dollars" Value="Dollars" ToolTip="Dollars" CheckOnClick="true"
                                                    Checked="true" AllowSelfUnCheck="true" />
                                                <telerik:RadToolBarButton IsSeparator="true" />
                                            </Items>
                                        </telerik:RadToolBar>
                                    </td>
                                    <td align="left" valign="top">
                                        <telerik:RadToolBar ID="RadToolbarNav" runat="server" AutoPostBack="True" Width="100%">
                                            <Items>
                                                <telerik:RadToolBarButton Text="Selection" Value="Filter" ToolTip="Selection" />
                                                <telerik:RadToolBarButton IsSeparator="true" />
                                                <telerik:RadToolBarButton Text="Summary" Value="Summary" ToolTip="Summary" />
                                                <telerik:RadToolBarButton IsSeparator="true" />
                                                <telerik:RadToolBarButton Text="Year" Value="Year" ToolTip="Year" />
                                                <telerik:RadToolBarButton IsSeparator="true" />
                                                <telerik:RadToolBarButton Text="Month" Value="Month" ToolTip="Month" />
                                                <telerik:RadToolBarButton IsSeparator="true" />
                                                <telerik:RadToolBarButton Text="Week" Value="Week" ToolTip="Week" />
                                                <telerik:RadToolBarButton IsSeparator="true" />
                                            </Items>
                                        </telerik:RadToolBar>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
            <tr>
                <td valign="top">
                    <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td valign="top">
                                <telerik:RadGrid ID="RadGridMonth" runat="server" AutoGenerateColumns="false" GridLines="None"
                                     HorizontalAlign="Center" ShowFooter="true">
                                    <ClientSettings EnableRowHoverStyle="true">
                                        <%--<Selecting AllowRowSelect="True" />--%>
                                    </ClientSettings>
                                    <MasterTableView AllowMultiColumnSorting="true" HorizontalAlign="Center" UseAllDataFields="true">
                                        <RowIndicatorColumn Visible="False">
                                            <HeaderStyle Width="20px" />
                                        </RowIndicatorColumn>
                                        <ExpandCollapseColumn Resizable="False" Visible="False">
                                            <HeaderStyle Width="20px" />
                                        </ExpandCollapseColumn>
                                        <EditFormSettings>
                                            <PopUpSettings ScrollBars="None" />
                                        </EditFormSettings>                                        
                                        <%--<DetailTables>
                                            <telerik:GridTableView AllowSorting="True" Caption="Employees" Name="EmpGrid" AutoGenerateColumns="false"
                                                 NoDetailRecordsText="No Records to Display" Width="99%" PagerStyle-Visible="False" ShowFooter="true">
                                            </telerik:GridTableView>
                                        </DetailTables>--%>
                                    </MasterTableView>
                                </telerik:RadGrid>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <telerik:RadGrid ID="RadGridYear" runat="server" AutoGenerateColumns="false" GridLines="None"
                                     HorizontalAlign="Center" ShowFooter="true">
                                    <ClientSettings EnableRowHoverStyle="true">
                                        <%--<Selecting AllowRowSelect="True" />--%>
                                    </ClientSettings>
                                    <MasterTableView AllowMultiColumnSorting="true" HorizontalAlign="Center" UseAllDataFields="true">
                                        <RowIndicatorColumn Visible="False">
                                            <HeaderStyle Width="20px" />
                                        </RowIndicatorColumn>
                                        <ExpandCollapseColumn Resizable="False" Visible="False">
                                            <HeaderStyle Width="20px" />
                                        </ExpandCollapseColumn>
                                        <EditFormSettings>
                                            <PopUpSettings ScrollBars="None" />
                                        </EditFormSettings>
                                    </MasterTableView>
                                </telerik:RadGrid>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" align="center">
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="center" valign="top">
                                            <telerik:RadGrid ID="RadGridComps" runat="server" AutoGenerateColumns="false" GridLines="None"
                                                Width="1500px" Height="500px"  HorizontalAlign="Center"
                                                ShowFooter="true">
                                                <MasterTableView HorizontalAlign="Center" UseAllDataFields="true">
                                                </MasterTableView>
                                                <ClientSettings EnableRowHoverStyle="true">
                                                    <%--<Selecting AllowRowSelect="True" />--%>
                                                    <Scrolling AllowScroll="True" UseStaticHeaders="True" SaveScrollPosition="True">
                                                    </Scrolling>
                                                </ClientSettings>
                                            </telerik:RadGrid>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
                </ContentTemplate>
            </asp:UpdatePanel>
    </table>
</asp:Content>
