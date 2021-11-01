<%@ Control AutoEventWireup="false" CodeBehind="DesktopCurrentRatio.ascx.vb" Inherits="Webvantage.DesktopCurrentRatio"
    Language="vb" %>
<div id="DivObject" runat="server">
    <div class="DO-ButtonHeader">
        <div style="float: left; text-align: left; vertical-align: middle; display: inline-block; width: 10%;">
                <asp:ImageButton ID="ImageButtonPrint" runat="server" SkinID="ImageButtonPrint"
                    OnClientClick="window.open('dtp_currentratio_print.aspx', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=600,height=250,scrollbars=yes,resizable=yes,menubar=no,maximazable=no');return false;" />
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
    <div style="clear: both;"></div>
    <div class="DO-Container">
        <telerik:RadGrid ID="CurRatioRadGrid" runat="server" AllowPaging="True" AutoGenerateColumns="False"
            EnableViewState="True" GridLines="None" EnableEmbeddedSkins="True">
            <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom" Height="20px"></PagerStyle>
            <MasterTableView AllowMultiColumnSorting="True" Width="100%">
                <Columns>
                    <telerik:GridBoundColumn DataField="OFFICE_NAME" HeaderText="Office" UniqueName="column1">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="ASSETS" HeaderText="Assets" DataFormatString="{0:#,###.00}"
                        UniqueName="column2">
                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                        <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="LIAB" HeaderText="Liabilities" DataFormatString="{0:#,###.00}"
                        UniqueName="column2">
                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                        <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="RATIO" DataFormatString="{0:F2}" HeaderText="Ratio"
                        UniqueName="column6">
                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                        <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" />
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
                <ExpandCollapseColumn Visible="False" Resizable="False">
                    <HeaderStyle Width="20px" />
                </ExpandCollapseColumn>
                <RowIndicatorColumn Visible="False">
                    <HeaderStyle Width="20px" />
                </RowIndicatorColumn>
            </MasterTableView>
            <ClientSettings>
                <Scrolling UseStaticHeaders="True" />
            </ClientSettings>
        </telerik:RadGrid>
    </div>
</div>
