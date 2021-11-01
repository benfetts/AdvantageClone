<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="DesktopDirectExpenseAlert.ascx.vb"
    Inherits="Webvantage.DesktopDirectExpenseAlert" %>

    <div id="DivObject" runat="server">
        <div id="hi" class="telerik-aqua-body" style="margin-top: 5px!important;">
            <div class="DO-ButtonHeader">
                <div style="float: left; text-align: left; vertical-align: middle; display: inline-block; width: 10%;">
                        <asp:ImageButton ID="ImageButtonPrint" runat="server" SkinID="ImageButtonPrint"
                            OnClientClick="window.open('dtp_directExpenseAlert.aspx?from=', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=800,height=400,scrollbars=yes,resizable=yes,menubar=no,maximazable=no');return false;" />
                        <asp:ImageButton ID="ImageButtonBookmark" runat="server" ToolTip="Bookmarks" SkinID="ImageButtonBookmark"/>
                    <asp:ImageButton ID="butRefresh" runat="server" ImageAlign="AbsMiddle"
                        SkinID="ImageButtonRefresh" ToolTip="Refresh" TabIndex="7" />
                </div>
                <div style="float: left; text-align: left; vertical-align: middle; display: inline-block; width: 78%;">
        
                    <div class="form-layout">
                        <ul>
                            <li>Period Range:</li>
                            <li><telerik:RadComboBox ID="ddPPBegin" runat="server" TabIndex="2" AutoPostBack="true" SkinID="RadComboBoxPostPeriodCodeOnly">
                                </telerik:RadComboBox>&nbsp;to&nbsp;<telerik:RadComboBox ID="ddPPEnd" runat="server" TabIndex="3"  AutoPostBack="true" SkinID="RadComboBoxPostPeriodCodeOnly">
                                        </telerik:RadComboBox></li>
                        </ul>
                    </div>
                    <div class="form-layout">
                        <ul>
                            <li>Office:</li>
                            <li><telerik:RadComboBox ID="ddOffice" runat="server"  TabIndex="4" AutoPostBack="true" SkinID="RadComboBoxOffice">
                                </telerik:RadComboBox></li>
                        </ul>
                    </div>

                </div>

            </div>
                <div style="clear:both"></div>
            <div class="DO-Container">

                <telerik:RadGrid ID="DirectExpRadGrid" runat="server" AllowPaging="True" AllowSorting="True"
                    EnableViewState="True" TabIndex="5" AutoGenerateColumns="False" GridLines="None"
                    EnableEmbeddedSkins="True" MasterTableView-ShowFooter="true">
                    <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom" Height="20px"></PagerStyle>
                    <MasterTableView AllowMultiColumnSorting="True" Width="100%" DataKeyNames="AP_INV_VCHR,VN_FRL_EMP_CODE,AP_ID">
                        <Columns>
                            <telerik:GridTemplateColumn UniqueName="TemplateColumn">
                                <HeaderStyle CssClass="radgrid-icon-column" />
                                <ItemStyle CssClass="radgrid-icon-column" />
                                <FooterStyle CssClass="radgrid-icon-column" />
                                <ItemTemplate>
                                    <div class="icon-background background-color-sidebar" id="DivViewIcon" runat="server">
                                        <asp:ImageButton ID="ImageButtonViewDetails" runat="server" ImageAlign="AbsMiddle" CssClass="icon-image"
                                            SkinID="ImageButtonViewWhite" ToolTip="View Task" />
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="GLACODE" HeaderText="GL Code" UniqueName="column1">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="65" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="65" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="65" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="GLADESC" HeaderText="GL Account" UniqueName="column2">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="VN_FRL_EMP_CODE" HeaderText="Vendor Code" UniqueName="column3">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="85" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="85" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="85" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="VN_NAME" HeaderText="Vendor Name" UniqueName="column4">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="AP_INV_VCHR" HeaderText="Invoice Number" UniqueName="column5"
                                FooterText="Total:">
                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="95" />
                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="95" />
                                <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="95" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="AMT" Aggregate="Sum" HeaderText="Net Amount"
                                DataFormatString="{0:#,##0.00}"
                                UniqueName="column6">
                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                                <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn HeaderText="&nbsp;" UniqueName="GridTemplateColumnDocuments">
                                <HeaderStyle CssClass="radgrid-icon-column" />
                                <ItemStyle CssClass="radgrid-icon-column" />
                                <FooterStyle CssClass="radgrid-icon-column" />
                                <ItemTemplate>
                                    <div class="icon-background background-color-sidebar">
                                        <asp:ImageButton ID="ImageButtonDocuments" runat="server" CommandName="Documents" ToolTip="Invoice Documents" ImageUrl="~/Images/Icons/White/256/documents_empty.png" CssClass="icon-image" />
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
                        <Scrolling UseStaticHeaders="true" />
                    </ClientSettings>
                </telerik:RadGrid>
            </div>
        </div>
    </div>


