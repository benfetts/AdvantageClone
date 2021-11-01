<%@ Page AutoEventWireup="false" CodeBehind="DashboardProductionDetail.aspx.vb" Inherits="Webvantage.DashboardProductionDetail"
    Language="vb" MasterPageFile="~/ChildPage.Master" Title="Employee Utilization" %>

<asp:Content ID="ContentDashboard" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
    <div class="telerik-aqua-body">
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td colspan="4">
                    <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td runat="Server" id="Td1" align="left" valign="top">
                                <telerik:RadToolBar ID="RadToolbarDashDetail" runat="server" AutoPostBack="True"
                                    Width="100%">
                                    <Items>
                                        <telerik:RadToolBarButton IsSeparator="true" />
                                        <telerik:RadToolBarButton ImageUrl="" Text="Selection" Value="Selection"
                                            ToolTip="" />
                                        <telerik:RadToolBarButton IsSeparator="true" />
                                        <telerik:RadToolBarButton ImageUrl="" Text="Realization" Value="Realization"
                                            ToolTip="" />
                                        <telerik:RadToolBarButton IsSeparator="true" />
                                        <telerik:RadToolBarButton ImageUrl="" Text="Summary" Value="Summary"
                                            ToolTip="" />
                                        <telerik:RadToolBarButton IsSeparator="true" />
                                        <telerik:RadToolBarButton ImageUrl="" Text="Detail" Value="Detail"
                                            Hidden="False" ToolTip="" />
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

        
        <style type="text/css">
            .chart-box {
                width: 50%;
                padding: 10px;
                float: left;
                box-sizing: border-box;
                -moz-box-sizing: border-box;
                -webkit-box-sizing: border-box;
                white-space: nowrap;
                text-align: center;
            }
            .chart-box > div {
                border: 1px solid #ccc;
                padding: 5px;
                position: relative;
                padding-top: 10px;
                margin: 0 auto;
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
            .telerik-aqua-body .RadToolBar {
                margin: 0 auto;
                margin-left: auto;
                margin-right: auto;
                display: block;
                
            }

        </style>

        <div style="margin: 10px;">
            <div class="chart-box">
                <div>
                    <div class="chart-box-label">Indirect Hours vs. Direct Hours</div>
                    <div>
                        <telerik:RadHtmlChart ID="RadHtmlChartIndirectHoursVsDirectPieChart" runat="server">

                        </telerik:RadHtmlChart>
                    </div>
                </div>
            </div>
            <div class="chart-box">
                <div>
                    <div class="chart-box-label">Direct Hours by Type</div>
                    <div>
                        <telerik:RadHtmlChart ID="RadHtmlChartDirectHourByTypePieChart" runat="server">

                        </telerik:RadHtmlChart>
                    </div>
                </div>
            </div>
        </div>
        <div style="clear:both;">
            <div class="chart-box">
                <div>
                    <div class="chart-box-label">Non Direct Hours by Category</div>
                    <div>
                        <telerik:RadHtmlChart ID="RadHtmlChartNonDirectHoursByCategoryPieChart" runat="server">

                        </telerik:RadHtmlChart>
                    </div>
                </div>
            </div>
            <div class="chart-box">
                <div>
                    <div class="chart-box-label">Direct Hours by Client</div>
                    <div>
                        <telerik:RadHtmlChart ID="RadHtmlChartDirectHoursByClientPieChart" runat="server">

                        </telerik:RadHtmlChart>
                    </div>
                </div>
            </div>
        </div>
    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        
    <script type="text/javascript">
        $(window).resize(function () {
            resizePieCharts();
        });
        $(document).ready(function () {
            resizePieCharts();
        });
        function resizePieCharts() {
            $('[data-role=chart]').each(function () {
                var pieChart = $find($(this).attr('id'));
                pieChart.set_height(300);
                pieChart.get_kendoWidget().resize();
                $(this).css('margin', '0 auto');
            });
        }
        function RadAjaxPanelOnResponseEnd(sender, args) {
            resizePieCharts();
        }
    </script>

</asp:Content>
