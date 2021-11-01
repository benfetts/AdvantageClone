<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="DesktopAgencyGoalsGraph.ascx.vb"
    Inherits="Webvantage.DesktopAgencyGoalsGraph" %>
<div id="DivObject" runat="server">
<div class="telerik-aqua-body" style="margin-top: 5px!important">
    <div class="DO-ButtonHeader">
            <div style="float: left; text-align: left; vertical-align: middle; display: inline-block; width: 10%;">
                <asp:ImageButton ID="ImageButtonPrint" runat="server" SkinID="ImageButtonPrint"
                    OnClientClick="window.open('dtp_agencyGoals_graph_print.aspx', 'PopLookup','screenX=0,left=0,screenY=0,top=0,width=800,height=600,scrollbars=no,resizable=yes,menubar=no,maximazable=no');return false;" />
                <asp:ImageButton ID="ImageButtonBookmark" runat="server" ToolTip="Bookmarks" SkinID="ImageButtonBookmark"/>
                <asp:ImageButton ID="butRefresh" runat="server" ImageAlign="AbsMiddle"
                    SkinID="ImageButtonRefresh" ToolTip="Refresh" TabIndex="7" />
            </div>
            <div style="float: left; text-align: left; vertical-align: middle; display: inline-block; width: 78%;">
            
                <div class="form-layout">
                    <ul>
                        <li>Period Range:</li>
                        <li><telerik:RadComboBox ID="ddPPBegin" runat="server" TabIndex="2" AutoPostBack="true" SkinID="RadComboBoxPostPeriodCodeOnly">
                            </telerik:RadComboBox>&nbsp;to&nbsp;<telerik:RadComboBox ID="ddPPEnd" runat="server" TabIndex="3" AutoPostBack="true" SkinID="RadComboBoxPostPeriodCodeOnly">
                            </telerik:RadComboBox></li>
                    </ul>
                </div>
                <div class="form-layout">
                    <ul>
                        <li>Office:</li>
                        <li><telerik:RadComboBox ID="ddOffice" runat="server" Width="220" TabIndex="4" AutoPostBack="true" SkinID="RadComboBoxOffice">
                        </telerik:RadComboBox></li>
                    </ul>
                </div>

            </div>

        </div>
        <div class="DO-Container" style="clear: both;">
    <%--        <telerik:RadHtmlChart ID="RadHtmlChartAgencyGoals" runat="server" Width="90%" Height="500" Transitions="true" Visible="True">
                <PlotArea>
                    <Series>
                    </Series>
                    <Appearance>
                        <FillStyle BackgroundColor="Transparent"></FillStyle>
                    </Appearance>
                    <XAxis AxisCrossingValue="0" Color="black" MajorTickType="Outside" MinorTickType="Outside"
                        Reversed="false">
                        <Items>
                        </Items>
                        <LabelsAppearance DataFormatString="Q{0}" RotationAngle="0" Skip="0" Step="1"></LabelsAppearance>
                        <TitleAppearance Position="Center" RotationAngle="0" Text="">
                        </TitleAppearance>
                    </XAxis>
                    <YAxis AxisCrossingValue="0" Color="black" MajorTickSize="1" MajorTickType="Outside"
                        MinorTickType="None" Reversed="false">
                        <LabelsAppearance DataFormatString="{0} M" RotationAngle="0" Skip="0" Step="1"></LabelsAppearance>
                        <TitleAppearance Position="Center" RotationAngle="0" Text="Millions">
                        </TitleAppearance>
                    </YAxis>
                </PlotArea>
                <Appearance>
                    <FillStyle BackgroundColor="Transparent"></FillStyle>
                </Appearance>
                <ChartTitle Text="Agency Goals">
                    <Appearance Align="Center" BackgroundColor="Transparent" Position="Top">
                    </Appearance>
                </ChartTitle>
                <Legend>
                    <Appearance BackgroundColor="Transparent" Position="Bottom">
                    </Appearance>
                </Legend>
            </telerik:RadHtmlChart>--%>

            <telerik:RadHtmlChart runat="server" ID="RadHtmlChartAgencyGoals" Transitions="true" Visible="true" EnableViewState="false">
                <PlotArea>
                    <XAxis>
                        <Items>
                        </Items>
                    </XAxis>
                    <YAxis>
                        <LabelsAppearance DataFormatString="{0:C0} M"></LabelsAppearance>
                    </YAxis>
                    <Series>
                        <telerik:ColumnSeries Name="">
                            <SeriesItems>
                            </SeriesItems>
                            <TooltipsAppearance Color="White">
                                <ClientTemplate>
                                    #=category#, #= kendo.format(\'{0:C2}\', value)# M 
                                </ClientTemplate>
                            </TooltipsAppearance>
                            <LabelsAppearance DataFormatString="{0:C} M" />
                        </telerik:ColumnSeries>
                    </Series>
                </PlotArea>
            </telerik:RadHtmlChart>
        </div>
</div>
    
</div>

<script type="text/javascript">
    $(window).resize(function () {
        resizeChart();
    });
    function resizeChart() {
        $find('<%= RadHtmlChartAgencyGoals.ClientID%>').get_kendoWidget().resize();
    }
</script>
