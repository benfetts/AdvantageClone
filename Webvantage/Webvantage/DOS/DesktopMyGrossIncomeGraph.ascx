<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="DesktopMyGrossIncomeGraph.ascx.vb"
    Inherits="Webvantage.DesktopMyGrossIncomeGraph" %>
<div class="telerik-aqua-body" style="margin-top: 5px!important;">
    <div class="DO-ButtonHeader">
        <div style="float: left; width: 50%">
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
            <table id="TableFilterGrossIncome" border="0" cellspacing="2">
                <tr>
                    <td style="vertical-align: middle; width: 100px;">
                        <asp:Label ID="Label5" runat="server" Text="Period Range:"></asp:Label>
                    </td>
                    <td>
                        <telerik:RadComboBox ID="ddPPBegin" runat="server" TabIndex="2" Width="90" AutoPostBack="true">
                        </telerik:RadComboBox>
                        <asp:Label ID="Label1" runat="server" Text="to"></asp:Label>
                        <telerik:RadComboBox ID="ddPPEnd" runat="server" TabIndex="3" Width="90" AutoPostBack="true">
                        </telerik:RadComboBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Office:"></asp:Label>
                    </td>
                    <td>
                        <telerik:RadComboBox ID="ddOffice" runat="server" width="220" TabIndex="4" AutoPostBack="true">
                        </telerik:RadComboBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Sales Class:"></asp:Label>
                    </td>
                    <td>
                        <telerik:RadComboBox ID="RadComboBoxSalesClass" runat="server" width="220" TabIndex="4" AutoPostBack="true">
                        </telerik:RadComboBox>
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align: top;">
                        <asp:Label ID="Label9" runat="server">Group Options:</asp:Label>
                    </td>
                    <td>
                        <asp:RadioButton ID="RadioButtonClient" runat="server" Text="Client" GroupName="Client" AutoPostBack="true" /><br />
                        <asp:RadioButton ID="RadioButtonCDP" runat="server" Text="Client/Division/Product" GroupName="Client" AutoPostBack="true" />
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align: top;">
                        <asp:Label ID="Label2" runat="server">Include Options:</asp:Label>
                    </td>
                    <td>
                        <asp:CheckBox ID="CheckboxIncludeManualInvoices" runat="server" Text="Include Manual Invoices" AutoPostBack="true" /><br />
                        <asp:CheckBox ID="CheckboxIncludeGLEntries" runat="server" Text="Include GL Entries" AutoPostBack="true" />
                    </td>
                </tr>
            </table>
        </ew:CollapsablePanel>
    </div>
    <div class="DO-Container">
        <telerik:RadHtmlChart ID="RadHtmlChartGrossIncomeGraph" runat="server" Height="300">
            <ClientEvents OnSeriesClick="RadHtmlChartOnSeriesClick" />
        </telerik:RadHtmlChart>
    </div>
    <div class="DO-Container">
        <telerik:RadGrid ID="RadGridGrossIncomeClient" runat="server" AllowPaging="True" AllowSorting="True"
            AutoGenerateColumns="False" GridLines="None" EnableEmbeddedSkins="True"
            EnableHeaderContextMenu="true" ShowFooter="true">
            <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom" ></PagerStyle>
            <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="true">
                <ClientEvents OnColumnHidden="OnColumnHidden" OnColumnShown="OnColumnShown" />
                <Selecting AllowRowSelect="True" />
            </ClientSettings>
            <MasterTableView AllowMultiColumnSorting="true" DataKeyNames="ClientCode,ClientSharePercent">
                <Columns>
                    <telerik:GridBoundColumn DataField="ClientDescription" HeaderText="Client" UniqueName="cdp">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="TotalGrossIncome" HeaderText="Gross Income" UniqueName="column36" DataFormatString="{0:#,##0.00}" Aggregate="Sum">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="ClientSharePercent" HeaderText="Gross Income Percent" UniqueName="column34" DataFormatString="{0:#,##0.00}%">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    </telerik:GridBoundColumn>
                    <telerik:GridTemplateColumn UniqueName="TemplateColumn1">
                        <HeaderStyle CssClass="radgrid-icon-column" />
                        <ItemStyle CssClass="radgrid-icon-column" />
                        <FooterStyle CssClass="radgrid-icon-column" />
                        <ItemTemplate>
                            <div class="icon-background background-color-sidebar" runat="server" id="DivFlagColor">
                                <asp:Image ID="ImageFlag" runat="server" CssClass="icon-image" ImageUrl="~/Images/Icons/White/256/signal_flag.png" />
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                </Columns>
                <ExpandCollapseColumn Visible="False">
                    <HeaderStyle Width="19px" />
                </ExpandCollapseColumn>
                <RowIndicatorColumn Visible="False">
                    <HeaderStyle Width="20px" />
                </RowIndicatorColumn>
            </MasterTableView>
        </telerik:RadGrid>
        <telerik:RadGrid ID="RadGridGrossIncomeCDP" runat="server" AllowPaging="True" AllowSorting="True"
            Width="100%" AutoGenerateColumns="False" GridLines="None" EnableEmbeddedSkins="True"
            EnableHeaderContextMenu="true">
            <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom" ></PagerStyle>
            <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="true">
                <ClientEvents OnColumnHidden="OnColumnHidden" OnColumnShown="OnColumnShown" />
                <Selecting AllowRowSelect="True" />
            </ClientSettings>
            <MasterTableView AllowMultiColumnSorting="true" DataKeyNames="ClientCode,DivisionCode,ProductCode,ClientSharePercent">
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
                    <telerik:GridBoundColumn DataField="TotalGrossIncome" HeaderText="Gross Income" UniqueName="column36" DataFormatString="{0:#,##0.00}" Aggregate="Sum">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="150" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="ClientSharePercent" HeaderText="Gross Income Percent" UniqueName="column34" DataFormatString="{0:#,##0.00}%">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="75" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    </telerik:GridBoundColumn>
                    <telerik:GridTemplateColumn UniqueName="TemplateColumn1">
                        <HeaderStyle CssClass="radgrid-icon-column" />
                        <ItemStyle CssClass="radgrid-icon-column" />
                        <FooterStyle CssClass="radgrid-icon-column" />
                        <ItemTemplate>
                            <div class="icon-background background-color-sidebar" runat="server" id="DivFlagColor">
                                <asp:Image ID="ImageFlag" runat="server" CssClass="icon-image" ImageUrl="~/Images/Icons/White/256/signal_flag.png" />
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
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
        svg > g, svg > g > g:nth-child(4) > g {
            cursor: pointer;
        }
    </style>

    <telerik:RadScriptBlock ID="RadScriptBlockFooter" runat="server">
        <script type="text/javascript">
            function RadHtmlChartOnSeriesClick(e) {
                var dataItem = e.dataItem;
                if (dataItem) {
                    var url = dataItem.SeriesClickURL;
                    if (url) {
                        OpenRadWindow('', url, 800, 1200, false);
                    }
                }
            }
            $(window).resize(function () {
                $find('<%= RadHtmlChartGrossIncomeGraph.ClientID%>').get_kendoWidget().resize();
            });
        </script>
    </telerik:RadScriptBlock>
</div>

