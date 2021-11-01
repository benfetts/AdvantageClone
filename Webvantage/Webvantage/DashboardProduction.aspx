<%@ Page AutoEventWireup="false" CodeBehind="DashboardProduction.aspx.vb" Inherits="Webvantage.DashboardProduction"
    Language="vb" MasterPageFile="~/ChildPage.Master" Title="Employee Utilization" %>

<asp:Content ID="ContentDashboard" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
    <div class="telerik-aqua-body">
        <div class="">
             <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td colspan="4">
                        <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%" class="no-float-menu">
                            <tr>
                                <td runat="Server" id="Td1" align="left" valign="top">
                                    <telerik:RadToolBar ID="RadToolbarDash" runat="server" AutoPostBack="True" Width="100%">
                                        <Items>
                                            <telerik:RadToolBarButton IsSeparator="true" />
                                            <telerik:RadToolBarButton ImageUrl="" Text="Selection" CommandName="Selection"
                                                ToolTip="" Value="Selection" />
                                            <telerik:RadToolBarButton IsSeparator="true" />
                                            <telerik:RadToolBarButton ImageUrl="" Text="Realization" CommandName="Realization"
                                                ToolTip="" Value="Realization" />
                                            <telerik:RadToolBarButton IsSeparator="true" />
                                            <telerik:RadToolBarButton ImageUrl="" Text="Summary" CommandName="Summary"
                                                ToolTip="" Value="Summary" />
                                            <telerik:RadToolBarButton IsSeparator="true" />
                                            <telerik:RadToolBarButton ImageUrl="" Text="Detail" CommandName="Detail"
                                                Hidden="False" ToolTip="" Value="Detail" />
                                            <telerik:RadToolBarButton IsSeparator="true" />
                                            <telerik:RadToolBarButton ImageUrl="" Text="Employee" CommandName="Employee"
                                                ToolTip="" Value="Employee" />
                                            <telerik:RadToolBarButton IsSeparator="true" />
                                        </Items>
                                    </telerik:RadToolBar>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
       
        
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

            .telerik-aqua-body .RadToolBar {
                margin: 0 auto;
                margin-left: auto;
                margin-right: auto;
                display: block;
                
            }

        </style>

        <div style="margin-top:10px;">
            <div class="chart-box">
                <div>
                    <div class="chart-box-label">Required Hours (Goal) vs. Total Hours</div>
                    <div>
                        <telerik:RadRadialGauge ID="RadRadialGaugeRequiredHoursVsTotalHoursGauge" runat="server">

                        </telerik:RadRadialGauge>
                    </div>
                    <div>
                        <telerik:RadHtmlChart ID="RadHtmlChartRequiredHoursVsTotalHoursChart" runat="server">

                        </telerik:RadHtmlChart>
                    </div>
                </div>
            </div>
            <div class="chart-box">
                <div>
                    <div class="chart-box-label">Direct Hours Goal vs. Direct Hours</div>
                    <div>
                        <telerik:RadRadialGauge ID="RadRadialGaugeDirectHoursGoalVsDirectHoursGauge" runat="server">

                        </telerik:RadRadialGauge>
                    </div>
                    <div>
                        <telerik:RadHtmlChart ID="RadHtmlChartDirectHoursGoalVsDirectHoursChart" runat="server">

                        </telerik:RadHtmlChart>
                    </div>
                </div>
            </div>
            <div class="chart-box">
                <div>
                    <div class="chart-box-label">Billable Hours Goal vs. Billable Hours</div>
                    <div>
                        <telerik:RadRadialGauge ID="RadRadialGaugeBillableHoursGoalVsBillableHoursGauge" runat="server">

                        </telerik:RadRadialGauge>
                    </div>
                    <div>
                        <telerik:RadHtmlChart ID="RadHtmlChartBillableHoursGoalVsBillableHoursChart" runat="server">

                        </telerik:RadHtmlChart>
                    </div>
                </div>
            </div>
            <div class="chart-box">
                <div>
                    <div class="chart-box-label">Direct Hours vs. Billable Hours</div>
                    <div>
                        <telerik:RadRadialGauge ID="RadRadialGaugeDirectHoursVsBillableHoursGauge" runat="server">

                        </telerik:RadRadialGauge>
                    </div>
                    <div>
                        <telerik:RadHtmlChart ID="RadHtmlChartDirectHoursVsBillableHoursChart" runat="server">

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
