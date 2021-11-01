<%@ Page AutoEventWireup="false" CodeBehind="DashboardRealizationDetail.aspx.vb"
    Inherits="Webvantage.DashboardRealizationDetail" Language="vb" MasterPageFile="~/ChildPage.Master"
    Title="Employee Utilization" %>

<asp:Content ID="ContentDashboard" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
    <div class="telerik-aqua-body">
        <div class="no-float-menu">
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td valign="top">
                        <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td colspan="4">
                                    <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
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
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        

        <style type="text/css">
            .chart-box {
                width: 50%;
                padding: 10px;
                float: left;
                box-sizing: border-box;
                -moz-box-sizing: border-box;
                -webkit-box-sizing: border-box;
            }
            .chart-box > div {
                border: 1px solid #ccc;
                padding: 5px;
                position: relative;
                padding-top: 10px;
            }
            .chart-box .chart-box-label {
                font-weight: bold; 
                position:absolute; 
                top: -10px; 
                left: 10px; 
                background: white; 
                padding-left: 5px; 
                padding-right: 5px;
            }

        </style>

        <div style="margin-top:10px;">
            <div class="chart-box">
                <div>
                    <div class="chart-box-label"><asp:Label ID="lblClient" runat="server">Client Totals (Amounts)</asp:Label></div>
                    <div>
                        <telerik:RadHtmlChart ID="RadHtmlChartClientTotalsChart" runat="server">

                        </telerik:RadHtmlChart>
                    </div>
                </div>
            </div>
            <div class="chart-box">
                <div>
                    <div class="chart-box-label">Percent Billed by Client</div>
                    <div>
                        <telerik:RadHtmlChart ID="RadHtmlChartPercentBilledByClientPieChart" runat="server">
                            <ClientEvents OnSeriesClick="RadHtmlChartOnSeriesClick" />

                        </telerik:RadHtmlChart>
                    </div>
                    <asp:HiddenField ID="HiddenFieldMonth" runat="server" ClientIDMode="Static" />
                    <asp:HiddenField ID="HiddenFieldMonth2" runat="server" ClientIDMode="Static" />
                    <asp:HiddenField ID="HiddenFieldYear" runat="server" ClientIDMode="Static" />
                    <asp:HiddenField ID="HiddenFieldEmployeeCode" runat="server" ClientIDMode="Static" />
                    <asp:HiddenField ID="HiddenFieldPeriod" runat="server" ClientIDMode="Static" />
                </div>
            </div>
        </div>
        <div style="clear:both;">
            <div class="chart-box" style="width:100%; clear:both; float:none;">
                <div>
                    <div class="chart-box-label">Realization by Client&nbsp;&nbsp;<asp:CheckBox ID="cbShowProducts" runat="server" Text="Products" AutoPostBack="true" />&nbsp;&nbsp;<asp:ImageButton ID="butExport" runat="server" SkinID="ImageButtonExportExcel" /></div>
                    <div style="margin-top:30px;">
                        <telerik:RadGrid ID="RadGridAvgHourly" runat="server" AutoGenerateColumns="False"
                            GridLines="None" AllowSorting="true" EnableEmbeddedSkins="True">
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
                                    <telerik:GridBoundColumn DataField="PERCENT_WRITE" HeaderText="Percent Write Up/Down"
                                        UniqueName="column7" DataFormatString="{0:#,##0.00}%" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="PERCENT_BILLED" HeaderText="Percent Billed" UniqueName="column8"
                                        DataFormatString="{0:#,##0.00}%" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="AVG_RATE_BILLED" HeaderText="Average Hourly Rate Billed"
                                        UniqueName="column10" DataFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="AVG_RATE_ACHIEVED" HeaderText="Average Hourly Rate Achieved"
                                        UniqueName="column9" DataFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
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
                        <telerik:RadGrid ID="RadGridAvgHourlyPrd" runat="server" AutoGenerateColumns="False"
                            GridLines="None" AllowSorting="true" EnableEmbeddedSkins="True">
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
                                    <telerik:GridBoundColumn DataField="PRD_DESCRIPTION" HeaderText="Product" UniqueName="column6"
                                        ItemStyle-HorizontalAlign="Left">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="PERCENT_WRITE" HeaderText="Percent Write Up/Down"
                                        UniqueName="column7" DataFormatString="{0:#,##0.00}%" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="PERCENT_BILLED" HeaderText="Percent Billed" UniqueName="column8"
                                        DataFormatString="{0:#,##0.00}%" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="AVG_RATE_BILLED" HeaderText="Average Hourly Rate Billed"
                                        UniqueName="column10" DataFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="AVG_RATE_ACHIEVED" HeaderText="Average Hourly Rate Achieved"
                                        UniqueName="column9" DataFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
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
                    </div>
                </div>
            </div>
        </div>
    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
    <script type="text/javascript">
        function RadHtmlChartOnSeriesClick(e) {
            var client = e.dataItem.CLIENT;
            var month = $('#HiddenFieldMonth').val();
            var month2 = $('#HiddenFieldMonth2').val();
            var year = $('#HiddenFieldYear').val();
            var emp = $('#HiddenFieldEmployeeCode').val();
            var period = $('#HiddenFieldPeriod').val();
            
            ClickURL = 'DashboardRealizationClient.aspx?Group=0&client=' + client + '&month=' + month + '&year=' + year + '&emp=' + emp + '&month2=' + month2 + '&billed=' + period;
            window.location.assign(ClickURL);

        }
        $(window).resize(function () {
            resizeCharts();
        });
        $(document).ready(function () {
            resizeCharts();
        });
        function resizeCharts() {
            $('[data-role=chart]').each(function () {
                var pieChart = $find($(this).attr('id'));
                pieChart.get_kendoWidget().resize();
            });
        }
        function RadAjaxPanelOnResponseEnd(sender, args) {
            resizeCharts();
        }
    </script>
    <style type="text/css">
        g text {
            cursor: pointer;
        }
    </style>
</asp:Content>
