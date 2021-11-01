<%@ Page AutoEventWireup="false" CodeBehind="DashboardClientTimeCompDetail.aspx.vb"
    Inherits="Webvantage.DashboardClientTimeCompDetail" Language="vb" MasterPageFile="~/ChildPage.Master"
    Title="Dashboard" %>

<asp:Content ID="ContentDashboard" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td>
                    <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td align="left">
                                <table align="left" border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="left" valign="top" width="50%">
                                            <telerik:RadToolBar ID="RadToolbarDashProject" runat="server" 
                                                 AutoPostBack="True" Width="100%">
                                                <Items>
                                                    <telerik:RadToolBarButton IsSeparator="true" />
                                                    <telerik:RadToolBarButton Text="Month" Value="Month" ToolTip="Calculate Data by Month"
                                                        CheckOnClick="true" Checked="true" AllowSelfUnCheck="true" />
                                                    <telerik:RadToolBarButton IsSeparator="true" />
                                                    <telerik:RadToolBarButton Text="Year to Date" Value="YeartoDate" ToolTip="Calculate Data year to Date"
                                                        CheckOnClick="true" Checked="true" AllowSelfUnCheck="true" />
                                                    <telerik:RadToolBarButton IsSeparator="true" />
                                                    <telerik:RadToolBarButton runat="server">
                                                        <ItemTemplate>
                                                            &nbsp;Month Ending:
                                                            <telerik:RadComboBox ID="DropDownListMonth" runat="server" AutoPostBack="true" SkinID="RadComboBoxStandard">
                                                            </telerik:RadComboBox>
                                                            &nbsp;
                                                        </ItemTemplate>
                                                    </telerik:RadToolBarButton>
                                                    <telerik:RadToolBarButton IsSeparator="true" />
                                                    <telerik:RadToolBarButton runat="server">
                                                        <ItemTemplate>
                                                            &nbsp;Week Ending:
                                                            <telerik:RadComboBox ID="DropDownListWeek" runat="server" AutoPostBack="true" SkinID="RadComboBoxStandard">
                                                            </telerik:RadComboBox>
                                                            &nbsp;
                                                        </ItemTemplate>
                                                    </telerik:RadToolBarButton>
                                                    <telerik:RadToolBarButton IsSeparator="true" />
                                                    <telerik:RadToolBarButton runat="server">
                                                        <ItemTemplate>
                                                            &nbsp;Summary Level:
                                                            <telerik:RadComboBox ID="DropDownListLevel" runat="server" AutoPostBack="true" SkinID="RadComboBoxText25" >
                                                                <Items>
                                                                 <telerik:RadComboBoxItem Value="C" Text="Client"></telerik:RadComboBoxItem>
                                                                <telerik:RadComboBoxItem Value="CD" Text="Client/Division"></telerik:RadComboBoxItem>
                                                                <telerik:RadComboBoxItem Value="CDP" Text="Client/Division/Product"></telerik:RadComboBoxItem>
                                                                <telerik:RadComboBoxItem Value="AE" Text="AE"></telerik:RadComboBoxItem>
                                                                <telerik:RadComboBoxItem Value="dept" Text="Department"></telerik:RadComboBoxItem>
                                                                <telerik:RadComboBoxItem Value="SC" Text="Sales Class"></telerik:RadComboBoxItem>
                                                                <telerik:RadComboBoxItem Value="JT" Text="Job Type"></telerik:RadComboBoxItem>
                                                               </Items>
                                                            </telerik:RadComboBox>
                                                            &nbsp;
                                                        </ItemTemplate>
                                                    </telerik:RadToolBarButton>
                                                    <telerik:RadToolBarButton IsSeparator="true" />
                                                </Items>
                                            </telerik:RadToolBar>
                                        </td>
                                        <td align="left" valign="top" width="50%">
                                            <telerik:RadToolBar ID="RadToolbarData" runat="server"  
                                                AutoPostBack="True" Width="100%">
                                                <Items>
                                                    <telerik:RadToolBarButton IsSeparator="true" />
                                                    <telerik:RadToolBarButton Text="" Value="Print" SkinID="RadToolBarButtonPrint" />
                                                    <telerik:RadToolBarButton IsSeparator="true" />
                                                    <telerik:RadToolBarButton SkinID="RadToolBarButtonExportExcel" ToolTip="Export to Excel" Value="Export" />
                                                </Items>
                                            </telerik:RadToolBar>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top" colspan="2">
                                            <telerik:RadToolBar ID="RadToolbarNav" runat="server"  
                                                AutoPostBack="True" Width="100%">
                                                <Items>
                                                    <telerik:RadToolBarButton Text="Filter" Value="Filter" ToolTip="Filter" />
                                                    <telerik:RadToolBarButton IsSeparator="true" />
                                                    <telerik:RadToolBarButton Text="Summary" Value="Summary" ToolTip="Summary" />
                                                    <telerik:RadToolBarButton IsSeparator="true" />
                                                    <telerik:RadToolBarButton Text="Graphs" Value="Graphs" ToolTip="Graphs" />
                                                    <telerik:RadToolBarButton IsSeparator="true" />
                                                    <telerik:RadToolBarButton Text="Detail" Value="Detail" ToolTip="Detail" />
                                                    <telerik:RadToolBarButton IsSeparator="true" />
                                                    <telerik:RadToolBarButton Text="Time Detail" Value="ProjectDetail" ToolTip="Detail" />
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
            <tr>
                <td align="left" valign="top">
                    <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td width="60%" valign="top">
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="center" valign="top">
                                            <telerik:RadGrid ID="RadGridComps" runat="server" AutoGenerateColumns="false" GridLines="None"
                                                EnableEmbeddedSkins="True" HorizontalAlign="Center" AllowSorting="true" ShowFooter="true">
                                                <MasterTableView HorizontalAlign="Center" UseAllDataFields="true">
                                                </MasterTableView>
                                            </telerik:RadGrid>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
                </ContentTemplate>
            </asp:UpdatePanel>
</asp:Content>
