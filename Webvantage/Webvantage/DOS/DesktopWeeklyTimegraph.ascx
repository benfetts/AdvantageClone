<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="DesktopWeeklyTimegraph.ascx.vb" Inherits="Webvantage.DesktopWeeklyTimegraph" %>
<div class="DO-ButtonHeader">
    <div style="float: left; width: 90%; text-align: left; vertical-align: middle">
        <div id="DivTimeWarnings" runat="server" style="margin: 0px 0px 6px 4px;">
            <div id="DivMissingTime" runat="server" class="time-warning-icon-background standard-red" style="">
                <asp:ImageButton ID="ImageButtonMissingTime" runat="server" CausesValidation="false" ImageUrl="~/Images/Icons/White/256/sign_warning.png" CssClass="time-warning-icon-image" />
            </div>
        </div>
    </div>
    <div style="float: right; width: 10%; text-align: right;">
        <asp:ImageButton ID="ImageButtonRefresh" runat="server" SkinID="ImageButtonRefresh" ToolTip="Refresh" />
    </div>
</div>
<div class="DO-Container">
    <telerik:RadHtmlChart ID="RadHtmlChartWeeklyTimeGraph" runat="server">
        <Legend>
            <Appearance Visible="false"></Appearance>
        </Legend>
    </telerik:RadHtmlChart>
</div>

<telerik:RadScriptBlock ID="RadScriptBlockFooter" runat="server">
    <script type="text/javascript">
        $(window).resize(function () {
            $find('<%= RadHtmlChartWeeklyTimeGraph.ClientID%>').get_kendoWidget().resize();
        });
    </script>
</telerik:RadScriptBlock>