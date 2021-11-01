<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="DesktopBillingTrends.ascx.vb"
    Inherits="Webvantage.DesktopBillingTrends" %>
<div class="DO-ButtonHeader">
    <div style="float: left; width: 90%; text-align: left; vertical-align: middle">
            <asp:ImageButton ID="butPrint" runat="server" SkinID="ImageButtonPrint" />
        <asp:ImageButton ID="ImageButtonFilter" runat="server" SkinID="ImageButtonFilter" />
        <asp:ImageButton ID="butRefresh" runat="server" ImageAlign="AbsMiddle"
                 SkinID="ImageButtonRefresh" ToolTip="Refresh"  />
    </div>


</div>
<div style="clear: both;" />
<div class="DO-Container">
    <ew:CollapsablePanel ID="CollapsablePanelFilter" runat="server" SkinID="CollapsablePanelDesktopObjectFilter" Collapsed="true" Visible="false">
        <div style="font-size: larger; margin: -7px 0px 0px 0px !important;">
            Filter
        </div>
        <table id="TableFilterBillingTrends" border="0" cellspacing="2"
            cellpadding="0">
            <tr>
                <td width="50%">
                    <asp:Label ID="Label8" runat="server">Office:</asp:Label>
                </td>
                <td width="50%">
                    <asp:Label ID="Label4" runat="server">Type:</asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <telerik:RadComboBox ID="ddOffice" runat="server" AutoPostBack="true" width="220">
                    </telerik:RadComboBox>
                </td>
                <td>
                    <telerik:RadComboBox ID="ddType" runat="server" AutoPostBack="true" width="220">
                        <Items>
                            <telerik:RadComboBoxItem Value="%" Text="All"></telerik:RadComboBoxItem>
                            <telerik:RadComboBoxItem Value="P" Text="Production"></telerik:RadComboBoxItem>
                            <telerik:RadComboBoxItem Value="M" Text="Media"></telerik:RadComboBoxItem>
                        </Items>
                    </telerik:RadComboBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label6" runat="server">Client:</asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label5" runat="server">Year From:</asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <telerik:RadComboBox ID="ClientDropDownList" runat="server" AutoPostBack="true" width="220">
                    </telerik:RadComboBox>
                </td>
                <td>
                    <telerik:RadComboBox ID="RadComboBoxYearFrom" runat="server" AutoPostBack="true" width="220">
                    </telerik:RadComboBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server">Division:</asp:Label>
                </td>
                <td> 
                    <asp:Label ID="Label7" runat="server">Year To:</asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <telerik:RadComboBox ID="DivisionDropDownList" runat="server" AutoPostBack="true" width="220">
                    </telerik:RadComboBox>
                </td>
                <td>
                    <telerik:RadComboBox ID="RadComboBoxYearTo" runat="server" AutoPostBack="true" width="220">
                    </telerik:RadComboBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server">Product:</asp:Label>
                </td>
                <td>&nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <telerik:RadComboBox ID="ProductDropDownList" runat="server" AutoPostBack="true" width="220">
                    </telerik:RadComboBox>
                </td>
                <td>&nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server">Sales Class:</asp:Label>
                </td>
                <td>&nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <telerik:RadComboBox ID="SalesClassDropDownList" runat="server" AutoPostBack="true" width="220">
                    </telerik:RadComboBox>
                </td>
                <td>&nbsp;
                </td>
            </tr>
        </table>
    </ew:CollapsablePanel>
</div>
<div class="DO-Container">
    <telerik:RadHtmlChart ID="RadHtmlChartBillingTrends" runat="server" Height="300">

    </telerik:RadHtmlChart>
</div>
<telerik:RadScriptBlock ID="RadScriptBlockFooter" runat="server">
    <script type="text/javascript">
        $(window).resize(function () {
            $find('<%= RadHtmlChartBillingTrends.ClientID%>').get_kendoWidget().resize();
        });
    </script>
</telerik:RadScriptBlock>
