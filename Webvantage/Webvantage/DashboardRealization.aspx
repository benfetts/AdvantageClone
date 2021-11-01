<%@ Page AutoEventWireup="false" CodeBehind="DashboardRealization.aspx.vb" Inherits="Webvantage.DashboardRealization"
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
                            <td runat="Server" id="Td1" colspan="2" class="no-float-menu">
                                <telerik:RadToolBar ID="RadToolbarDash" runat="server" AutoPostBack="True" Width="100%">
                                    <Items>
                                        <telerik:RadToolBarButton IsSeparator="true" />
                                        <telerik:RadToolBarButton ImageUrl="" Text="Selection" Value="Selection"
                                            ToolTip="" />
                                        <telerik:RadToolBarButton IsSeparator="true" />
                                        <telerik:RadToolBarButton ImageUrl="" Text="Productivity" Value="Productivity"
                                            Hidden="False" />                                            
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
               
        <style type="text/css">
            .chart-box {
                width: 25%;
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
                    <div class="chart-box-label">Direct Hours Goal vs. Billed Hours</div>
                    <div>
                        <telerik:RadRadialGauge ID="RadRadialGaugeDirectHoursGoalVsBilledHoursGauge" runat="server">

                        </telerik:RadRadialGauge>
                    </div>
                    <div>
                        <telerik:RadHtmlChart ID="RadHtmlChartDirectHoursGoalVsBilledHoursChart" runat="server">

                        </telerik:RadHtmlChart>
                    </div>
                </div>
            </div>
            <div class="chart-box">
                <div>
                    <div class="chart-box-label">Direct Hours vs. Billed Hours</div>
                    <div>
                        <telerik:RadRadialGauge ID="RadRadialGaugeDirectHoursVsBilledHoursGauge" runat="server">

                        </telerik:RadRadialGauge>
                    </div>
                    <div>
                        <telerik:RadHtmlChart ID="RadHtmlChartDirectHoursVsBilledHoursChart" runat="server">

                        </telerik:RadHtmlChart>
                    </div>
                </div>
            </div>
            <div class="chart-box">
                <div>
                    <div class="chart-box-label">Billable Hours Goal vs. Billed Hours</div>
                    <div>
                        <telerik:RadRadialGauge ID="RadRadialGaugeBillableHoursGoalVsBilledHoursGauge" runat="server">

                        </telerik:RadRadialGauge>
                    </div>
                    <div>
                        <telerik:RadHtmlChart ID="RadHtmlChartBillableHoursGoalVsBilledHoursChart" runat="server">

                        </telerik:RadHtmlChart>
                    </div>
                </div>
            </div>
            <div class="chart-box">
                <div>
                    <div class="chart-box-label">Billable Hours vs. Billed Hours</div>
                    <div>
                        <telerik:RadRadialGauge ID="RadRadialGaugeBillableHoursVsBilledHoursGauge" runat="server">

                        </telerik:RadRadialGauge>
                    </div>
                    <div>
                        <telerik:RadHtmlChart ID="RadHtmlChartBillableHoursVsBilledHoursChart" runat="server">

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
            $('[data-role=chart], [data-role=radialgauge]').each(function () {
                $find($(this).attr('id')).get_kendoWidget().resize()
            });
        });
    </script>

</asp:Content>
