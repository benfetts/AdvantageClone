<%@ Page Title="Print Dashboard Project" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="DashboardProjectPrint.aspx.vb" Inherits="Webvantage.DashboardProjectPrint" %>

<%@ Register Src="Print_Buttons.ascx" TagName="Print_Buttons" TagPrefix="webvantage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
        <script type="text/javascript"><!--
            FusionCharts.printManager.enabled(true);

            //        FusionCharts.addEventListener(
            //          FusionChartsEvents.PrintReadyStateChange,
            //          function (identifier, parameter) {
            //              if (parameter.ready) {
            //                  radalert("Chart is now ready for printing.");                  
            //              }
            //          });
    // --></script>
    </telerik:RadScriptBlock>
    <table align="center" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td colspan="2" align="left" >
                &nbsp;<asp:Label   ID="lblTitle" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table>
                    <asp:Panel ID="PanelDashProjectGraph" runat="server" Visible="false">
                        <tr>
                            <td align="left">
                                <table align="left" border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="left" valign="top" colspan="2">
                                            <asp:PlaceHolder ID="PlaceHolderGraph" runat="server"></asp:PlaceHolder>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </asp:Panel>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table>
                    <asp:Panel ID="PanelDashProjectDetail" runat="server" Visible="false">
                        <tr>
                            <td valign="top">
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="center" valign="top">
                                            <telerik:RadGrid ID="RadGridComps" runat="server" AutoGenerateColumns="false" GridLines="Both"
                                                 HorizontalAlign="Center" AllowSorting="true" ShowFooter="true">
                                                <MasterTableView HorizontalAlign="Center" UseAllDataFields="true">
                                                </MasterTableView>
                                            </telerik:RadGrid>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="center" valign="top">
                                            <telerik:RadGrid ID="RadGridYear" runat="server" AutoGenerateColumns="false" GridLines="Both"
                                                AllowSorting="true"  HorizontalAlign="Center" ShowFooter="true">
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
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="center" valign="top">
                                            <telerik:RadGrid ID="RadGridMonth" runat="server" AutoGenerateColumns="false" GridLines="Both"
                                                AllowSorting="true"  HorizontalAlign="Center" ShowFooter="true">
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
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <telerik:RadGrid ID="RadGridWrapper" runat="server" ShowHeader="false" Width="550px"
                                        BorderStyle="None">
                                        <ExportSettings OpenInNewWindow="true" />
                                        <MasterTableView AutoGenerateColumns="true" BorderStyle="None">
                                            <ItemTemplate>
                                                <telerik:RadGrid ID="RadGridComps" runat="server" AutoGenerateColumns="true" GridLines="Both"
                                                    OnNeedDataSource="RadGridComp_NeedDataSource"  HorizontalAlign="Center"
                                                    ShowFooter="true" OnItemDataBound="RadGridComp_ItemDataBound">
                                                    <ExportSettings ExportOnlyData="true" OpenInNewWindow="true" />
                                                    <MasterTableView HorizontalAlign="Center" UseAllDataFields="true">
                                                    </MasterTableView>
                                                </telerik:RadGrid>
                                                <br />
                                                <telerik:RadGrid ID="RadGridMonth" runat="server" AutoGenerateColumns="true" GridLines="Both"
                                                    OnNeedDataSource="RadGridMth_NeedDataSource"  HorizontalAlign="Center"
                                                    ShowFooter="true" OnItemDataBound="RadGridMth_ItemDataBound">
                                                    <ExportSettings ExportOnlyData="true" OpenInNewWindow="true" />
                                                    <MasterTableView HorizontalAlign="Center" UseAllDataFields="true">
                                                    </MasterTableView>
                                                </telerik:RadGrid>
                                                <br />
                                                <telerik:RadGrid ID="RadGridYear" runat="server" AutoGenerateColumns="true" GridLines="Both"
                                                    OnNeedDataSource="RadGridYr_NeedDataSource"  HorizontalAlign="Center"
                                                    ShowFooter="true" OnItemDataBound="RadGridYr_ItemDataBound">
                                                    <ExportSettings ExportOnlyData="true" OpenInNewWindow="true" />
                                                    <MasterTableView HorizontalAlign="Center" UseAllDataFields="true">
                                                    </MasterTableView>
                                                </telerik:RadGrid>
                                            </ItemTemplate>
                                        </MasterTableView>
                                    </telerik:RadGrid>
                                </table>
                            </td>
                        </tr>
                    </asp:Panel>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table>
                    <asp:Panel ID="PanelDashProjectComp" runat="server" Visible="false">
                        <tr>
                            <td width="100%" valign="top">
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="left" colspan="2">
                                            &nbsp;&nbsp;<strong><asp:Label   ID="LabelByLevel" runat="server" Text="Projects"></asp:Label></strong>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" valign="top">
                                            <div style="width: 1100px; height: 500px">
                                                <telerik:RadHtmlChart ID="RadHtmlChartPieSelection" runat="server">
                                                
                                                </telerik:RadHtmlChart>
                                            </div>
                                            
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="top">
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td width="98%" valign="top">
                                            <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                                <tr>
                                                    <td align="center" valign="top">
                                                        <telerik:RadGrid ID="RadGridDashComps" runat="server" AutoGenerateColumns="false"
                                                            GridLines="Both"  HorizontalAlign="Center" AllowSorting="true"
                                                            ShowFooter="true">
                                                            <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="true">
                                                                <Selecting AllowRowSelect="True" />
                                                            </ClientSettings>
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
                    </asp:Panel>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table>
                    <asp:Panel ID="PanelDashProjectCompDetail" runat="server" Visible="false">
                        <tr>
                            <td width="60%" valign="top">
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="center" valign="top">
                                            <telerik:RadGrid ID="RadGridCompDetail" runat="server" AutoGenerateColumns="false"
                                                GridLines="Both"  HorizontalAlign="Center" AllowSorting="true"
                                                ShowFooter="true">
                                                <MasterTableView HorizontalAlign="Center" UseAllDataFields="true">
                                                </MasterTableView>
                                            </telerik:RadGrid>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </asp:Panel>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table>
                    <asp:Panel ID="PanelDashProjectYear" runat="server" Visible="false">
                        <tr>
                            <td colspan="4" align="center">
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="center" valign="top" colspan="2">
                                            <asp:PlaceHolder ID="PlaceHolderYear" runat="server"></asp:PlaceHolder>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </asp:Panel>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table>
                    <asp:Panel ID="PanelDashProjectMonth" runat="server" Visible="false">
                        <tr>
                            <td colspan="4" align="center">
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="center" valign="top" colspan="2">
                                            <asp:PlaceHolder ID="PlaceHolderGraphMonth" runat="server"></asp:PlaceHolder>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </asp:Panel>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table>
                    <asp:Panel ID="PanelDashProjectList" runat="server" Visible="false">
                        <tr>
                            <td align="center" valign="top">
                                <telerik:RadGrid ID="RadGridProjects" runat="server" AutoGenerateColumns="false"
                                    GridLines="Both"  HorizontalAlign="Center" AllowSorting="true"
                                    ShowFooter="true">
                                    <MasterTableView DataKeyNames="JOB,JOB_COMPONENT_NBR">
                                        <Columns>
                                            <telerik:GridBoundColumn DataField="JOB" HeaderText="Job" UniqueName="column1" ItemStyle-HorizontalAlign="Left"
                                                HeaderStyle-Width="50px">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="JOB_DESC" HeaderText="Description" UniqueName="column3"
                                                Visible="false">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="JOB_COMPONENT_NBR" HeaderText="Component" UniqueName="column4"
                                                Visible="false">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="JOB_COMP_DESC" HeaderText="Description" UniqueName="column11">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="SC_CODE" HeaderText="" UniqueName="column5" Visible="false">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="SC_DESCRIPTION" HeaderText="Sales Class" UniqueName="column36">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="JOB_TYPE" HeaderText="" UniqueName="column6"
                                                Visible="false">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="JT_DESC" HeaderText="Job Type" UniqueName="column26">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="DP_TM_CODE" HeaderText="" UniqueName="column6"
                                                Visible="false">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="DP_TM_DESC" HeaderText="Department" UniqueName="column6">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="TRF_CODE" HeaderText="" UniqueName="column6"
                                                Visible="false">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="TRF_DESCRIPTION" HeaderText="Status" UniqueName="column16">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="JOB_COMP_DATE" HeaderText="Opened Date" UniqueName="column15">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="JOB_FIRST_USE_DATE" HeaderText="Due Date" UniqueName="column25">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="COMPLETED_DATE" HeaderText="Completed Date" UniqueName="column35">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="JOB_COMPONENT_NBR" HeaderText="Difference" UniqueName="column35">
                                            </telerik:GridBoundColumn>
                                        </Columns>
                                    </MasterTableView>
                                </telerik:RadGrid>
                            </td>
                        </tr>
                    </asp:Panel>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table>
                    <asp:Panel ID="PanelDashClientTime" runat="server" Visible="false">
                        <tr>
                            <td width="100%" valign="top">
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="left" colspan="2">
                                            &nbsp;&nbsp;<strong><asp:Label   ID="LabelHours" runat="server" Text="Actual Hours"></asp:Label></strong>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" valign="top">
                                            <telerik:RadHtmlChart ID="RadHtmlChartHoursPieChart" runat="server" Height="400" Width="800">

                                            </telerik:RadHtmlChart>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td width="100%" valign="top">
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="left" colspan="2">
                                            &nbsp;&nbsp;<strong><asp:Label   ID="LabelDollars" runat="server" Text="Actual Dollars"></asp:Label></strong>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" valign="top">
                                            <telerik:RadHtmlChart ID="RadHtmlChartDollarsPieChart" runat="server" Height="400" Width="800">

                                            </telerik:RadHtmlChart>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </asp:Panel>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table>
                    <asp:Panel ID="PanelDashClientYear" runat="server" Visible="false">
                        <tr>
                            <td colspan="4" align="center">
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="center" valign="top" colspan="2">
                                            <asp:PlaceHolder ID="PlaceHolderClientYear" runat="server"></asp:PlaceHolder>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </asp:Panel>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table>
                    <asp:Panel ID="PanelDashClientTimeCompDetail" runat="server" Visible="false">
                        <tr>
                            <td width="60%" valign="top">
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="left" colspan="2">
                                            &nbsp;&nbsp;<strong><asp:Label   ID="Label9" runat="server" Text="Hours List"></asp:Label></strong>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" valign="top">
                                            <telerik:RadGrid ID="RadGridHours" runat="server" AutoGenerateColumns="false" GridLines="Both"
                                                Width="98%"  HorizontalAlign="Center" AllowSorting="true"
                                                ShowFooter="true">
                                                <MasterTableView HorizontalAlign="Center" UseAllDataFields="true">
                                                </MasterTableView>
                                            </telerik:RadGrid>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </asp:Panel>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table>
                    <asp:Panel ID="PanelDashClientMonth" runat="server" Visible="false">
                        <tr>
                            <td colspan="4" align="center">
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="center" valign="top" colspan="2">
                                            <asp:PlaceHolder ID="PlaceHolderClientMonth" runat="server"></asp:PlaceHolder>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </asp:Panel>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table>
                    <asp:Panel ID="PanelDashClientWeek" runat="server" Visible="false">
                        <tr>
                            <td colspan="4" align="center">
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="center" valign="top" colspan="2">
                                            <asp:PlaceHolder ID="PlaceHolderClientWeek" runat="server"></asp:PlaceHolder>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </asp:Panel>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table>
                    <asp:Panel ID="PanelDashClientDetail" runat="server" Visible="false">
                        <tr>
                            <td valign="top">
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="center" valign="top">
                                            <telerik:RadGrid ID="RadGridCompsClient" runat="server" AutoGenerateColumns="false"
                                                GridLines="Both"  HorizontalAlign="Center" AllowSorting="true"
                                                ShowFooter="true">
                                                <MasterTableView HorizontalAlign="Center" UseAllDataFields="true">
                                                </MasterTableView>
                                            </telerik:RadGrid>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="center" valign="top">
                                            <telerik:RadGrid ID="RadGridYearClient" runat="server" AutoGenerateColumns="false"
                                                GridLines="Both" AllowSorting="true"  HorizontalAlign="Center"
                                                ShowFooter="true">
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
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="center" valign="top">
                                            <telerik:RadGrid ID="RadGridMonthClient" runat="server" AutoGenerateColumns="false"
                                                GridLines="Both" AllowSorting="true"  HorizontalAlign="Center"
                                                ShowFooter="true">
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
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <telerik:RadGrid ID="RadGridWrapperClient" runat="server" ShowHeader="false" Width="550px"
                                        BorderStyle="None">
                                        <ExportSettings OpenInNewWindow="true" />
                                        <MasterTableView AutoGenerateColumns="true" BorderStyle="None">
                                            <ItemTemplate>
                                                <telerik:RadGrid ID="RadGridCompsClient" runat="server" AutoGenerateColumns="true"
                                                    GridLines="Both" OnNeedDataSource="RadGridCompClient_NeedDataSource" 
                                                    HorizontalAlign="Center" ShowFooter="true" OnItemDataBound="RadGridCompClient_ItemDataBound">
                                                    <ExportSettings ExportOnlyData="true" OpenInNewWindow="true" />
                                                    <MasterTableView HorizontalAlign="Center" UseAllDataFields="true">
                                                    </MasterTableView>
                                                </telerik:RadGrid>
                                                <br />
                                                <telerik:RadGrid ID="RadGridMonthClient" runat="server" AutoGenerateColumns="true"
                                                    GridLines="Both" OnNeedDataSource="RadGridMthClient_NeedDataSource" 
                                                    HorizontalAlign="Center" ShowFooter="true" OnItemDataBound="RadGridMthClient_ItemDataBound">
                                                    <ExportSettings ExportOnlyData="true" OpenInNewWindow="true" />
                                                    <MasterTableView HorizontalAlign="Center" UseAllDataFields="true">
                                                    </MasterTableView>
                                                </telerik:RadGrid>
                                                <br />
                                                <telerik:RadGrid ID="RadGridYearClient" runat="server" AutoGenerateColumns="true"
                                                    GridLines="Both" OnNeedDataSource="RadGridYrClient_NeedDataSource" 
                                                    HorizontalAlign="Center" ShowFooter="true" OnItemDataBound="RadGridYrClient_ItemDataBound">
                                                    <ExportSettings ExportOnlyData="true" OpenInNewWindow="true" />
                                                    <MasterTableView HorizontalAlign="Center" UseAllDataFields="true">
                                                    </MasterTableView>
                                                </telerik:RadGrid>
                                            </ItemTemplate>
                                        </MasterTableView>
                                    </telerik:RadGrid>
                                </table>
                            </td>
                        </tr>
                    </asp:Panel>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table>
                    <asp:Panel ID="PanelDashData" runat="server" Visible="false">
                        <tr>
                            <td colspan="4" align="center">
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="center" valign="top" colspan="2">
                                            <telerik:RadGrid ID="RadGridData" runat="server" AutoGenerateColumns="True" GridLines="Both"
                                                 HorizontalAlign="Center" AllowSorting="true" ShowFooter="true">
                                                <MasterTableView>
                                                    <RowIndicatorColumn Visible="False">
                                                        <HeaderStyle Width="20px" />
                                                    </RowIndicatorColumn>
                                                    <ExpandCollapseColumn Resizable="False" Visible="False">
                                                        <HeaderStyle Width="20px" />
                                                    </ExpandCollapseColumn>
                                                </MasterTableView>
                                            </telerik:RadGrid>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </asp:Panel>
                </table>
            </td>
        </tr>
    </table>
    <webvantage:Print_Buttons ID="Print_Buttons1" runat="server" />
</asp:Content>