<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="DesktopMyARCashForecast.ascx.vb"
    Inherits="Webvantage.DesktopMyARCashForecast" %>
<div class="telerik-aqua-body" style="margin-top: 5px!important;">
    <div class="DO-ButtonHeader">
        <div style="float: left; width: 90%; text-align: left; vertical-align: middle">
            <asp:ImageButton ID="PrintImageButton" runat="server" SkinID="ImageButtonPrint" />
            <asp:ImageButton ID="butExport" runat="server" SkinID="ImageButtonExportExcel" ToolTip="Export to Excel" />
            <asp:ImageButton ID="ImageButtonFilter" runat="server" SkinID="ImageButtonFilter" />
            <asp:ImageButton ID="ImageButtonBookmark" runat="server" ToolTip="Bookmarks" SkinID="ImageButtonBookmark"/>
            <asp:ImageButton ID="ImgBtnRefresh" runat="server" AlternateText="Refresh"
                SkinID="ImageButtonRefresh" ToolTip="Refresh" />
        </div>

    </div>

    <div class="DO-Container">
        <ew:CollapsablePanel ID="CollapsablePanelFilter" runat="server" SkinID="CollapsablePanelDesktopObjectFilter" Collapsed="true" Visible="false">
            <div style="font-size: larger; margin: -7px 0px 0px 0px !important;">
                Filter
            </div>
            <table id="TableFilterMyARCashForecast" width="100%" border="0" cellspacing="2" cellpadding="0">
                <tr>
                    <td>
                        <asp:Label ID="Label8" runat="server">Office:</asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <telerik:RadComboBox ID="ddOffice" runat="server" AutoPostBack="true" width="220">
                        </telerik:RadComboBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server">Client:</asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <telerik:RadComboBox ID="ClientDropDownList" runat="server" AutoPostBack="true" width="220">
                        </telerik:RadComboBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server">Division:</asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <telerik:RadComboBox ID="DivisionDropDownList" runat="server" AutoPostBack="true" width="220">
                        </telerik:RadComboBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server">Product:</asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <telerik:RadComboBox ID="ProductDropDownList" runat="server" AutoPostBack="true" width="220">
                        </telerik:RadComboBox>
                    </td>
                </tr>
            </table>
        </ew:CollapsablePanel>
        <telerik:RadGrid ID="ARForcastRG" runat="server" AllowPaging="True" AllowSorting="True"
            EnableViewState="True" AutoGenerateColumns="False" EnableAJAX="false" GridLines="None"
            EnableEmbeddedSkins="True">
            <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom"></PagerStyle>
            <MasterTableView PageSize="10" Width="100%">
                <ExpandCollapseColumn Visible="False">
                    <HeaderStyle Width="19px" />
                </ExpandCollapseColumn>
                <RowIndicatorColumn Visible="False">
                    <HeaderStyle Width="20px" />
                </RowIndicatorColumn>
                <Columns>
                    <telerik:GridBoundColumn DataField="Client" HeaderText="Client" UniqueName="column">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Division" HeaderText="Division" UniqueName="column">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Product" HeaderText="Product" UniqueName="column">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="AvgDays" HeaderText="Avg. No. of Days" UniqueName="column1">
                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                        <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="TotalARAmt" DataType="System.Decimal" HeaderText="Open AR Amount"
                        DataFormatString="{0:#,###.00}" UniqueName="column2">
                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                        <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Month1" HeaderText="M1" DataFormatString="{0:#,###.00}"
                        UniqueName="column3">
                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                        <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Month2" HeaderText="M2" DataFormatString="{0:#,###.00}"
                        UniqueName="column4">
                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                        <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Month3" HeaderText="M3" DataFormatString="{0:#,###.00}"
                        UniqueName="column5">
                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                        <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Month4" HeaderText="M4" DataFormatString="{0:#,###.00}"
                        UniqueName="column6">
                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                        <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" />
                    </telerik:GridBoundColumn>
                </Columns>
            </MasterTableView>
        </telerik:RadGrid>
    </div>
</div>

