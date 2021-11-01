<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="DesktopMyServiceFee.ascx.vb"
    Inherits="Webvantage.DesktopMyServiceFee" %>
<div class="telerik-aqua-body" style="margin-top: 5px!important;">
    <div class="DO-ButtonHeader">
        <div style="float: left; width: 90%">
            <asp:ImageButton ID="ImageButtonPrint" runat="server" SkinID="ImageButtonPrint" />
            <asp:ImageButton ID="ImageButtonExportExcel" runat="server" SkinID="ImageButtonExportExcel" ToolTip="Export to Excel" />
            <asp:ImageButton ID="ImageButtonFilter" runat="server" SkinID="ImageButtonFilter" />
            <asp:ImageButton ID="ImageButtonBookmark" runat="server" ToolTip="Bookmarks" SkinID="ImageButtonBookmark"/>
            <asp:ImageButton ID="ImageButtonRefresh" runat="server" SkinID="ImageButtonRefresh" ToolTip="Refresh" />

        </div>

    </div>
    <div class="DO-Container">
        <ew:CollapsablePanel ID="CollapsablePanelFilter" runat="server" SkinID="CollapsablePanelDesktopObjectFilter" Collapsed="true" Visible="false">
            <div style="font-size: larger; margin: -7px 0px 0px 0px !important;">
                Filter
            </div>
            <table id="TableFilterServiceFee" border="0" cellspacing="2">
                <tr>
                    <td align="left" valign="top" width="100">
                        <asp:Label ID="Label5" runat="server" Text="Period Range:"></asp:Label>
                    </td>
                    <td align="left">
                        <telerik:RadComboBox ID="ddPPBegin" runat="server" TabIndex="2" Width="90" AutoPostBack="true">
                        </telerik:RadComboBox>
                        <asp:Label ID="Label3" runat="server" Text="to"></asp:Label>
                        <telerik:RadComboBox ID="ddPPEnd" runat="server" TabIndex="3" Width="90" AutoPostBack="true">
                        </telerik:RadComboBox>
                    </td>
                </tr>
                <tr>
                    <td align="left" valign="top" width="200">
                        <asp:Label ID="Label2" runat="server">Option for Fee Time:</asp:Label>
                    </td>
                    <td align="left">
                        <asp:RadioButton ID="RadioButtonNone" runat="server" Text="None" GroupName="Fee" AutoPostBack="true" /><br />
                        <asp:RadioButton ID="RadioButtonEmployeeDefault" runat="server" Text="Employee Default Department" GroupName="Fee" AutoPostBack="true" /><br />
                        <asp:RadioButton ID="RadioButtonEmployeeTimeEntry" runat="server" Text="Employee Time Entry Department" GroupName="Fee" AutoPostBack="true" /><br />
                        <asp:RadioButton ID="RadioButtonJobComponent" runat="server" Text="Job/Component" GroupName="Fee" AutoPostBack="true" />
                    </td>
                </tr>
                <tr>
                    <td align="left" valign="top" width="200">
                        <asp:Label ID="Label9" runat="server">Group Options:</asp:Label>
                    </td>
                    <td align="left">
                        <asp:RadioButton ID="RadioButtonClient" runat="server" Text="Client" GroupName="Client" AutoPostBack="true" /><br />
                        <asp:RadioButton ID="RadioButtonCDP" runat="server" Text="Client/Division/Product" GroupName="Client" AutoPostBack="true" /><br />
                        <asp:CheckBox ID="CheckboxFeeType" runat="server" Text="Fee Type" AutoPostBack="true" />
                    </td>
                </tr>
            </table>
        </ew:CollapsablePanel>
    </div>
    <div class="DO-Container">
        <telerik:RadHtmlChart ID="RadHtmlChartMyServiceFees" runat="server">
            <ClientEvents OnSeriesClick="RadHtmlChartOnSeriesClick" />
            <PlotArea>
                <YAxis>
                    <LabelsAppearance DataFormatString="{0:N0}"></LabelsAppearance>
                </YAxis>
            </PlotArea>
        </telerik:RadHtmlChart>
    </div>
    <div class="DO-Container">
        <telerik:RadGrid ID="RadGridServiceFeeClient" runat="server" AllowPaging="True" AllowSorting="True"
            Width="100%" AutoGenerateColumns="False" GridLines="None" EnableEmbeddedSkins="True"
            EnableHeaderContextMenu="true" ShowFooter="true">
            <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom" ></PagerStyle>
            <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="true">
                <ClientEvents OnColumnHidden="OnColumnHidden" OnColumnShown="OnColumnShown" />
                <Selecting AllowRowSelect="True" />
            </ClientSettings>
            <MasterTableView AllowMultiColumnSorting="true" Width="100%" DataKeyNames="ClientCode">
                <Columns>
                    <telerik:GridBoundColumn DataField="ClientDescription" HeaderText="Client" UniqueName="cdp">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="ServiceFeeTypeDescription" HeaderText="Fee Type" UniqueName="fee" Display="false">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="FeeAmount" HeaderText="Fee Billed" UniqueName="column36" DataFormatString="{0:#,##0.00}" Aggregate="Sum">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Hours" HeaderText="Actual Hours" UniqueName="column34" DataFormatString="{0:#,##0.00}" Aggregate="Sum">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Amount" HeaderText="Actual Amount" UniqueName="column35" DataFormatString="{0:#,##0.00}" Aggregate="Sum">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="VarianceAmount" HeaderText="Variance" UniqueName="taskcolumn" DataFormatString="{0:#,##0.00}">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    </telerik:GridBoundColumn>
                </Columns>
                <ExpandCollapseColumn Visible="False">
                    <HeaderStyle Width="19px" />
                </ExpandCollapseColumn>
                <RowIndicatorColumn Visible="False">
                    <HeaderStyle Width="20px" />
                </RowIndicatorColumn>
            </MasterTableView>
        </telerik:RadGrid>
        <telerik:RadGrid ID="RadGridServiceFeeCDP" runat="server" AllowPaging="True" AllowSorting="True"
            Width="100%" AutoGenerateColumns="False" GridLines="None" EnableEmbeddedSkins="True"
            EnableHeaderContextMenu="true" ShowFooter="true">
            <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom" ></PagerStyle>
            <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="true">
                <ClientEvents OnColumnHidden="OnColumnHidden" OnColumnShown="OnColumnShown" />
                <Selecting AllowRowSelect="True" />
            </ClientSettings>
            <MasterTableView AllowMultiColumnSorting="true" Width="100%" DataKeyNames="ClientCode,DivisionCode,ProductCode">
                <Columns>
                    <telerik:GridBoundColumn DataField="ClientDescription" HeaderText="Client" UniqueName="c">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="DivisionDescription" HeaderText="Division" UniqueName="cd">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="ProductDescription" HeaderText="Product" UniqueName="cdp">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="ServiceFeeTypeDescription" HeaderText="Fee Type" UniqueName="fee" Display="false">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="FeeAmount" HeaderText="Fee Billed" UniqueName="column36" DataFormatString="{0:#,##0.00}" Aggregate="Sum">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Font-Bold="true" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Hours" HeaderText="Actual Hours" UniqueName="column34" DataFormatString="{0:#,##0.00}" Aggregate="Sum">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Font-Bold="true" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Amount" HeaderText="Actual Amount" UniqueName="column35" DataFormatString="{0:#,##0.00}" Aggregate="Sum">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Font-Bold="true" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="VarianceAmount" HeaderText="Variance" UniqueName="taskcolumn" DataFormatString="{0:#,##0.00}" Aggregate="Sum">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Font-Bold="true" />
                    </telerik:GridBoundColumn>
                </Columns>
                <ExpandCollapseColumn Visible="False">
                    <HeaderStyle Width="19px" />
                </ExpandCollapseColumn>
                <RowIndicatorColumn Visible="False">
                    <HeaderStyle Width="20px" />
                </RowIndicatorColumn>
            </MasterTableView>
        </telerik:RadGrid>
    </div>

    <style type="text/css">
        svg > g > g:nth-child(3) > g:nth-child(4) > g {
            cursor: pointer;
        }
    </style>

    <telerik:RadScriptBlock ID="RadScriptBlockFooter" runat="server">

        <script type="text/javascript">
            function RadHtmlChartOnSeriesClick(e) {
                var url = e.sender.element[0].attributes['SERIES_CLICK_URL'];
                if (url) {
                    OpenRadWindow('', url.value, 800, 1200, false);
                }
            }
           <%-- $(window).resize(function () {
                $find('<%= RadHtmlChartMyServiceFees.ClientID%>').get_kendoWidget().resize();
            });--%>
        </script>

    </telerik:RadScriptBlock>
</div>

