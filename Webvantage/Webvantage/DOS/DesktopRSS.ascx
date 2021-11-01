<%@ Control AutoEventWireup="false" CodeBehind="DesktopRSS.ascx.vb" Inherits="Webvantage.DesktopRSS"
    Language="vb" %>
<%@ Register Assembly="RssToolkit" Namespace="RssToolkit.Web.WebControls" TagPrefix="cc1" %>
<table border="0" cellpadding="2" cellspacing="0" width="100%">
    <tr id="TrSource" runat="server">
        <td align="left">
            <telerik:RadComboBox ID="DropFeedSource" runat="server" AutoPostBack="True" Width="90%">
                <Items>
                    <telerik:RadComboBoxItem Value="http://www.feedzilla.com/rss/business/advertising"
                        Text="Advertising News"></telerik:RadComboBoxItem>
                    <telerik:RadComboBoxItem Value="http://adsoftheworld.com/node/feed" Text="Ads From Around the World">
                    </telerik:RadComboBoxItem>
                    <telerik:RadComboBoxItem Value="http://rss.adobe.com/en/design_center_tutorials.rss"
                        Text="Adobe - Design Center"></telerik:RadComboBoxItem>
                    <telerik:RadComboBoxItem Value="http://rss.macworld.com/macworld/feeds/main" Text="MacWorld">
                    </telerik:RadComboBoxItem>
                    <telerik:RadComboBoxItem Value="http://feeds.newsweek.com/newsweek/TopNews" Text="Newsweek - Top News">
                    </telerik:RadComboBoxItem>
                    <telerik:RadComboBoxItem Value="http://www.nytimes.com/services/xml/rss/nyt/HomePage.xml"
                        Text="NY Times - Headlines"></telerik:RadComboBoxItem>
                    <telerik:RadComboBoxItem Value="http://feeds.reuters.com/reuters/oddlyEnoughNews?format=xml"
                        Text="Reuters - Oddly Enough"></telerik:RadComboBoxItem>
                </Items>
            </telerik:RadComboBox>
        </td>
        <td align="right" width="20px">
            <asp:ImageButton ID="BtnRefresh" runat="server" ImageAlign="AbsMiddle" SkinID="ImageButtonRefresh" ToolTip="Refresh" />
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:PlaceHolder ID="PlaceHolder1" runat="server">
                
            </asp:PlaceHolder>
            <div style="margin-left: 1px; margin-right: 4px;">
                <telerik:RadGrid ID="RadGridNewsFeed" runat="server" GridLines="None" Width="100%"
                    AllowPaging="true" PageSize="5">
                    <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom" Height="20px">
                    </PagerStyle>
                    <MasterTableView AutoGenerateColumns="False" ShowFooter="false" ShowHeader="false">
                        <RowIndicatorColumn Visible="False">
                            <HeaderStyle Width="20px" />
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn Resizable="False" Visible="False">
                            <HeaderStyle Width="20px" />
                        </ExpandCollapseColumn>
                        <Columns>
                            <telerik:GridTemplateColumn DataField="title" UniqueName="ColArticle">
                                <ItemTemplate>
                                    <asp:HyperLink ID="HlArticle" runat="server" NavigateUrl='<%# Eval("link") %>' Target="_blank"
                                        Text='<%# Eval("title") %>' ToolTip='<%# Eval("description") %>'></asp:HyperLink>
                                    <br />
                                    <asp:Label ID="LblDate" runat="server" Text='<%# Eval("pubDate") %>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
                <asp:Literal ID="LitMSG" runat="server"></asp:Literal>
            </div>
            <asp:LinkButton ID="LinkButtonDisclaimer" runat="server" Text="Disclaimer" ToolTip="Disclaimer" OnClientClick="OpenRadWindow('','Disclaimer.aspx?disclaimer=1', 500, 500); return false;"></asp:LinkButton>
        </td>
    </tr>
</table>
