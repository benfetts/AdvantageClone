<%@ Control AutoEventWireup="false" CodeBehind="DesktopCurrentRatioGraph.ascx.vb"
    Inherits="Webvantage.DesktopCurrentRatioGraph" Language="vb" %>
<div id="DivObject" runat="server">
    <div class="DO-ButtonHeader">
        <div style="float: left; text-align: left; vertical-align: middle; display: inline-block; width: 10%;">
                <asp:ImageButton ID="ImageButtonPrint" runat="server" SkinID="ImageButtonPrint"
                    OnClientClick="window.open('dtp_currentratio_graph_print.aspx', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=400,height=325,scrollbars=no,resizable=yes,menubar=no,maximazable=no');return false;" />
        </div>
        <div style="float: left; text-align: left; vertical-align: top; display: inline-block; width: 78%;">
            
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
                    <li><telerik:RadComboBox ID="ddOffice" runat="server" TabIndex="4" AutoPostBack="true" SkinID="RadComboBoxOffice">
                        </telerik:RadComboBox></li>
                </ul> 
            </div>

        </div>
        <div style="float: right; text-align: right; display: inline-block; width: 10%;">
            <asp:ImageButton ID="butRefresh" runat="server" ImageAlign="AbsMiddle"
                SkinID="ImageButtonRefresh" ToolTip="Refresh" TabIndex="7" />
        </div>
    </div>
    <div style="clear: both;" />
    <div class="DO-Container">
        <telerik:RadHtmlChart ID="RadHtmlChartCurrentRatio" runat="server" EnableViewState="false">

        </telerik:RadHtmlChart>
    </div>
</div>

<script type="text/javascript">
    $(window).resize(function () {
        resizeChart();
    });
    function resizeChart() {
        $find('<%= RadHtmlChartCurrentRatio.ClientID%>').get_kendoWidget().resize();
    }
</script>