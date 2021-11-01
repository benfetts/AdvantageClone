<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="DesktopBillableHoursGoal.ascx.vb"
    Inherits="Webvantage.DesktopBillableHoursGoal" %>
<div class="DO-ButtonHeader">
    <div style="float: left; width: 90%; text-align: left; vertical-align: middle">
        <asp:ImageButton ID="ImageButtonPrint" runat="server" SkinID="ImageButtonPrint" 
            OnClientClick="printCharts(); return false;" />
        <telerik:RadComboBox ID="ddMonth" runat="server" EnableViewState="true" SkinID="RadComboBoxMonth"
            AutoPostBack="true">
        </telerik:RadComboBox>
        <telerik:RadComboBox ID="ddYear" runat="server" EnableViewState="true" SkinID="RadComboBoxYear"
            AutoPostBack="true">
        </telerik:RadComboBox>
    </div>
    <div style="float: right; width: 10%; text-align: right;">
        <asp:ImageButton ID="butrefresh" runat="server" AlternateText="Refresh" ImageAlign="AbsMiddle"
            SkinID="ImageButtonRefresh" ToolTip="Refresh" />
    </div>
</div>
<div class="DO-Container">
    <telerik:RadRadialGauge runat="server" ID="RadRadialGaugeBillableHoursGoal" Height="300" Width="300" style="margin: 0 auto;" EnableViewState="false">
        <Pointer Value="0">
            <Cap Size="0.1" />
        </Pointer>
        <Scale Min="0" Max="160" MajorUnit="40">
            <Labels Format="{0} hours" />
            <Ranges>
                <telerik:GaugeRange Color="#DC3545" From="0" To="40" />
                <telerik:GaugeRange Color="#FD7E14" From="40" To="80" />
                <telerik:GaugeRange Color="#FFC107" From="80" To="120" />
                <telerik:GaugeRange Color="#5CB85C" From="120" To="160" />
            </Ranges>
        </Scale>
    </telerik:RadRadialGauge>
</div>
<div class="DO-Container">
    <telerik:RadGrid ID="RadGridDisplay" runat="server" ShowHeader="false" ShowFooter="false"
        EnableViewState="false" AllowSorting="true" AutoGenerateColumns="false" GridLines="None"
        EnableEmbeddedSkins="True">
        <MasterTableView>
            <Columns>
                <telerik:GridBoundColumn DataField="Description" HeaderText="&nbsp;" SortExpression="Description"
                    UniqueName="ColText">
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Value" HeaderText="&nbsp;" SortExpression="Value"
                    UniqueName="ColValue">
                    <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                    <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                </telerik:GridBoundColumn>
            </Columns>
        </MasterTableView>
    </telerik:RadGrid>
</div>

<telerik:RadScriptBlock ID="RadScriptBlockFooter" runat="server">
    <script type="text/javascript">
        function printCharts(sender, args) {
            window.open('dtp_empmonthgoal.aspx?month=' + <%= _Month%> + '&year=' + <%= _Year%>, 'PopLookup', 'screenX=150,left=150,screenY=150,top=150,width=435,height=600,scrollbars=yes,resizable=no,menubar=no,maximazable=no');
        }
    </script>
</telerik:RadScriptBlock>
