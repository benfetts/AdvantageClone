<%@ Page AutoEventWireup="false" CodeBehind="DashboardRealizationFee.aspx.vb" Inherits="Webvantage.DashboardRealizationFee"
    Language="vb" MasterPageFile="~/ChildPage.Master" Title="Employee Utilization" %>

<asp:Content ID="ContentDashboard" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
    

    <link rel="stylesheet" href="Content/kendo/current/kendo.common.min.css" />
    <link rel="stylesheet" href="Content/kendo/current/kendo.bootstrap.min.css" />
    <script type="text/javascript" src="Scripts/kendo/current/kendo.all.min.js"></script>
    <script type="text/javascript" src="JScripts/fusion/fusioncharts.js"></script>
    <script type="text/javascript" src="JScripts/fusion/fusioncharts.charts.js"></script>
    <script type="text/javascript" src="JScripts/fusion/fusioncharts.widgets.js"></script>

            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
    <div class="telerik-aqua-body">
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td valign="top">
                    <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td colspan="4">
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%" class="no-float-menu">
                                    <tr>
                                        <td runat="Server" id="Td1" colspan="2">
                                            <telerik:RadToolBar ID="RadToolbarDash" runat="server" AutoPostBack="True" Width="100%">
                                                <Items>
                                                    <telerik:RadToolBarButton IsSeparator="true" />
                                                    <telerik:RadToolBarButton ImageUrl="" Text="Selection" Value="Selection"
                                                        ToolTip="" />
                                                    <telerik:RadToolBarButton IsSeparator="true" />
                                                    <telerik:RadToolBarButton ImageUrl="" Text="Productivity" Value="Productivity"
                                                        Hidden="False" ToolTip="" />
                                                    <telerik:RadToolBarButton IsSeparator="true" />
                                                    <telerik:RadToolBarButton ImageUrl="" Text="Summary" Value="Summary"
                                                        ToolTip="" />
                                                    <telerik:RadToolBarButton IsSeparator="true" />
                                                    <telerik:RadToolBarButton ImageUrl="" Text="Detail" Value="Detail"
                                                        Hidden="False" ToolTip="" />
                                                    <telerik:RadToolBarButton IsSeparator="true" />
                                                    <telerik:RadToolBarButton ImageUrl="" Text="Fee" Value="Fee" Hidden="False"
                                                        ToolTip="" />
                                                    <telerik:RadToolBarButton IsSeparator="true" />
                                                    <telerik:RadToolBarButton ImageUrl="" Text="Client" Value="Client"
                                                        ToolTip="" />
                                                    <telerik:RadToolBarButton IsSeparator="true" />
                                                    <telerik:RadToolBarButton ImageUrl="" Text="Employee" Value="Employee"
                                                        ToolTip="" />
                                                    <telerik:RadToolBarButton IsSeparator="true" />
                                                </Items>
                                            </telerik:RadToolBar>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td width="100%" valign="top" colspan="4">
                                <fieldset>
                                <legend style="font-size: large">&nbsp;&nbsp;<strong><asp:Label   ID="lblClient" runat="server">Client Totals (Amounts)</asp:Label></strong></legend>                                  
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" valign="middle">
                                            
                                            <div id="clientTotalsLinearGauge"></div>

                                            <asp:HiddenField ID="HiddenFieldGoodRange" runat="server" Value="0" ClientIDMode="Static" />
                                            <asp:HiddenField ID="HiddenFieldOkRange" runat="server" Value="0" ClientIDMode="Static" />
                                            <asp:HiddenField ID="HiddenFieldBadRange" runat="server" Value="0" ClientIDMode="Static" />
                                            <asp:HiddenField ID="HiddenFieldClientValue" runat="server" Value="0" ClientIDMode="Static" />

                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                                </fieldset>
                            </td>
                        </tr>
                        <tr>
                            <td width="100%" colspan="4">
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">                                    
                                    <tr colspan="2">
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" colspan="2">
                                            &nbsp;&nbsp;<strong style="font-size: large">Fee Amounts by Client</strong>&nbsp;&nbsp;
                                            <asp:CheckBox ID="cbShowProducts" runat="server" Text="Products" AutoPostBack="true" />&nbsp;&nbsp;
                                            <asp:ImageButton ID="butExport" runat="server" SkinID="ImageButtonExportExcel" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" valign="top">
                                            <telerik:RadGrid ID="RadGridFee" runat="server" AutoGenerateColumns="False" GridLines="None"
                                                AllowSorting="true" EnableEmbeddedSkins="True">
                                                <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="true">
                                                    <Selecting AllowRowSelect="True" />
                                                </ClientSettings>
                                                <MasterTableView DataKeyNames="CLIENT, CL_NAME" AllowMultiColumnSorting="true">
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="CLIENT" HeaderText="Client" UniqueName="column1"
                                                            Visible="false">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="CL_NAME" HeaderText="Client" UniqueName="column2"
                                                            ItemStyle-HorizontalAlign="Left">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="FEE_AMOUNT" HeaderText="Fee" UniqueName="column7"
                                                            DataFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Left">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="FEE_TIME_AMOUNT" HeaderText="Time" UniqueName="column8"
                                                            DataFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Left">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="VARIANCE" HeaderText="Variance" UniqueName="column10"
                                                            DataFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Left">
                                                        </telerik:GridBoundColumn>
                                                    </Columns>
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
                                            <telerik:RadGrid ID="RadGridFeePrd" runat="server" AutoGenerateColumns="False" GridLines="None"
                                                AllowSorting="true" EnableEmbeddedSkins="True">
                                                <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="true">
                                                    <Selecting AllowRowSelect="True" />
                                                </ClientSettings>
                                                <MasterTableView DataKeyNames="CLIENT,DIVISION,PRODUCT" AllowMultiColumnSorting="true">
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="CLIENT" HeaderText="Client" UniqueName="column1"
                                                            Visible="false">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="CL_NAME" HeaderText="Client" UniqueName="column2"
                                                            ItemStyle-HorizontalAlign="Left">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="DIVISION" HeaderText="Division" UniqueName="column3"
                                                            Visible="false">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="DIV_NAME" HeaderText="Division" UniqueName="column4"
                                                            ItemStyle-HorizontalAlign="Left">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="PRODUCT" HeaderText="Product" UniqueName="column5"
                                                            Visible="false">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="PRD_DESCRIPTION" HeaderText="Product" UniqueName="column9"
                                                            ItemStyle-HorizontalAlign="Left">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="FEE_AMOUNT" HeaderText="Fee" UniqueName="column7"
                                                            DataFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Left">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="FEE_TIME_AMOUNT" HeaderText="Time" UniqueName="column8"
                                                            DataFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Left">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="VARIANCE" HeaderText="Variance" UniqueName="column10"
                                                            DataFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Left">
                                                        </telerik:GridBoundColumn>
                                                    </Columns>
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
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td>
                                <table align="center" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td align="left">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        </div>
                </ContentTemplate>
            </asp:UpdatePanel>
<telerik:RadScriptBlock ID="rcdfoot" runat="server">
    <script type="text/javascript">

        function CreateChart(chartOptions) {
            var obj = JSON.parse(chartOptions);
            var ccChart = new FusionCharts(obj);
            ccChart.setTransparent(true);
            ccChart.render();
        }

    </script>
</telerik:RadScriptBlock>

</asp:Content>
