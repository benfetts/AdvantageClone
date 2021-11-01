<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="DesktopAgencyGoals.ascx.vb"
    Inherits="Webvantage.DesktopAgencyGoals" %>
<div id="DivObject" runat="server">

    <div class="DO-ButtonHeader">
        <div style="float: left; text-align: left; vertical-align: middle; display: inline-block; width: 10%;">
                <asp:ImageButton ID="ImageButtonPrint" runat="server" SkinID="ImageButtonPrint"
                    OnClientClick="window.open('dtp_agencyGoals_print.aspx', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=600,height=350,scrollbars=yes,resizable=yes,menubar=no,maximazable=no');return false;" />
        </div>
        <div style="float: left; text-align: left; vertical-align: middle; display: inline-block; width: 78%;">
            <div class="form-layout">
                <ul>
                    <li>Period Range:</li>
                    <li><telerik:RadComboBox ID="ddPPBegin" runat="server" TabIndex="2" AutoPostBack="true" SkinID="RadComboBoxPostPeriodCodeOnly">
                        </telerik:RadComboBox>&nbsp;to&nbsp;<telerik:RadComboBox ID="ddPPEnd" runat="server" TabIndex="3" Width="90" AutoPostBack="true" SkinID="RadComboBoxPostPeriodCodeOnly">
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
        <div style="float: right; text-align: right; display: inline-block; width: 10%;">
            <asp:ImageButton ID="butRefresh" runat="server" ImageAlign="AbsMiddle"
                SkinID="ImageButtonRefresh" ToolTip="Refresh" TabIndex="7" />
        </div>
</div>
<div style="clear: both;"></div>
<div class="DO-Container">
    <telerik:RadGrid ID="Radgridratio" runat="server" AllowPaging="True" AllowSorting="True"
                EnableViewState="True" Width="100%" AutoGenerateColumns="False" GridLines="None"
                EnableEmbeddedSkins="True">
                <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom" Height="20px">
                </PagerStyle>
                <MasterTableView AllowMultiColumnSorting="True" Width="100%">
                    <Columns>
                        <telerik:GridBoundColumn DataField="DESCR" HeaderText="Description" UniqueName="column1">
                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="AMT" HeaderText="Amount" DataFormatString="{0:#,##0.00}"
                            UniqueName="column2">
                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="100" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="100" />
                            <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="100" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="GOAL_PCT" HeaderText="Percent Goal" DataFormatString="{0:#,##0.00}"
                            UniqueName="column3">
                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="100" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="100" />
                            <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="100" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="ACTUAL_PCT" HeaderText="Actual Percent" DataFormatString="{0:#,##0.00}"
                            UniqueName="column4">
                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="100" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="100" />
                            <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="100" />
                        </telerik:GridBoundColumn>
                        <telerik:GridTemplateColumn UniqueName="TemplateColumn1">
                            <HeaderStyle CssClass="radgrid-icon-column" />
                            <ItemStyle CssClass="radgrid-icon-column" />
                            <FooterStyle CssClass="radgrid-icon-column" />
                            <ItemTemplate>
                                <div class="icon-background background-color-sidebar" runat="server" id="DivFlagColor">
                                    <asp:Image ID="ImageFlag" runat="server" CssClass="icon-image" ImageUrl="~/Images/Icons/White/256/signal_flag.png" />
                                </div>
                                <asp:Image ID="FlagImage" runat="server" />
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
                <ClientSettings>
                    <Scrolling UseStaticHeaders="True" />
                </ClientSettings>
            </telerik:RadGrid>
</div>
    </div>