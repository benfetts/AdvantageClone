<%@ Page Title="Search" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="Search.aspx.vb" Inherits="Webvantage.Search" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <style type="text/css">
        .search-tbl td{
            padding-right: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <telerik:RadToolBar ID="RadToolbarSearch" runat="server" AutoPostBack="true" Width="100%" Visible="false"
        TabIndex="-1">
        <Items>
            <telerik:RadToolBarButton IsSeparator="true" />
            <telerik:RadToolBarButton SkinID="RadToolBarButtonFind"
                Text="Search" Value="Search" ToolTip="Search" />
            <telerik:RadToolBarButton SkinID="RadToolBarButtonClear" Text="Clear"
                Value="Clear" ToolTip="Clear search text" />
            <telerik:RadToolBarButton SkinId="RadToolBarButtonBookmark" Text="" Value="Bookmark"
                ToolTip="Bookmark" Visible="false" />
            <telerik:RadToolBarButton IsSeparator="true" />
        </Items>
    </telerik:RadToolBar>
    <div style="margin-left: 4px !important; margin-right: 4px !important;">

        <table width="100%" border="0" cellspacing="2" cellpadding="0">
            <tr>
                <td >
                    <asp:Panel ID="Panel1" runat="server" DefaultButton="ButtonSearch">
                        <asp:CheckBox ID="CheckBoxExact" runat="server" Text="Exact" /><br />
                        <asp:TextBox ID="TextBoxSearch" runat="server" Style="width: 99%;" SkinID="TextBoxStandard"></asp:TextBox>
                        <div style="display: block; margin-top: 7px !important; margin-bottom: 4px !important;">
                            <asp:Button ID="ButtonSearch" runat="server" Text="Search" />
                            <asp:Image ID="ImageSettings" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/Icons/Grey/256/gearwheels.png" CssClass="icon-image"/>
                        </div>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td >
                    <telerik:RadGrid ID="RadGridSearch" runat="server" AutoGenerateColumns="False" CellSpacing="0" GridLines="None" ShowHeader="false" AllowSorting="true" 
                        ShowFooter="false">
                        <ClientSettings>
                            <Selecting CellSelectionMode="None"></Selecting>
                        </ClientSettings>
                        <MasterTableView GroupsDefaultExpanded="false" Width="100%">
                            <CommandItemSettings AddNewRecordText="Add" RefreshText="Refresh" />
                            <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                                <HeaderStyle Width="10px"></HeaderStyle>
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                                <HeaderStyle Width="10px"></HeaderStyle>
                            </ExpandCollapseColumn>
                            <Columns>
                                <telerik:GridHyperLinkColumn UniqueName="GridHyperLinkColumnLink" NavigateUrl="blank.htm" SortExpression="MatchingText" HeaderText="Results">
                                    <ItemStyle CssClass="talkToTheHand" />
                                </telerik:GridHyperLinkColumn>
                                <telerik:GridBoundColumn UniqueName="GridBoundColumnCategory" DataField="DateForSort" DataFormatString="{0:d}" SortExpression="DateForSort" HeaderText="Date">
                                    <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" Width="70" />
                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="70" />
                                    <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" Width="70" />
                                </telerik:GridBoundColumn>
                            </Columns>
                            <EditFormSettings>
                                <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                            </EditFormSettings>
                        </MasterTableView>
                        <FilterMenu EnableImageSprites="False"></FilterMenu>
                    </telerik:RadGrid>
                </td>
            </tr>
        </table>
    </div>
    <telerik:RadToolTip ID="RadToolTipSettings" runat="server" TargetControlID="ImageSettings" ManualClose="true" Modal="true" Position="BottomCenter">
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
            <h4>Search In</h4>
            <table border="0" cellspacing="2" cellpadding="0" class="search-tbl">
                <tr>
                    <td>Job Jacket</td>
                    <td>Alerts</td>
                    <td>Schedules</td>
                </tr>
                <tr>
                    <td valign="top">
                        <div style="margin-left: 4px;">
                            <asp:CheckBoxList ID="CheckBoxListJobJackets" runat="server" AppendDataBoundItems="true">
                            </asp:CheckBoxList>
                        </div>   
                    </td>
                    <td valign="top">
                        <div style="margin-left: 4px;">
                            <asp:CheckBoxList ID="CheckBoxListAlerts" runat="server" AppendDataBoundItems="true">
                            </asp:CheckBoxList>
                        </div>
                    </td>
                    <td valign="top">
                        <div style="margin-left: 4px;">
                            <asp:CheckBoxList ID="CheckBoxListSchedules" runat="server" AppendDataBoundItems="true">
                            </asp:CheckBoxList>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">&nbsp;</td>
                </tr>
                <asp:Panel ID="PanelEstimate" runat="server">
                <tr>
                    <td>Estimates</td>
                    <td>Purchase Orders</td>
                    <td>&nbsp;</td>
                </tr>
                </asp:Panel>
                <tr>
                    <td valign="top">
                        <div style="margin-left: 4px;">
                            <asp:CheckBoxList ID="CheckBoxListEstimates" runat="server" Enabled="True" AppendDataBoundItems="true">
                            </asp:CheckBoxList>
                        </div>
                    </td>
                    <td valign="top">
                        <div style="margin-left: 4px;">
                            <asp:CheckBoxList ID="CheckBoxListPurchaseOrders" runat="server" Enabled="True" AppendDataBoundItems="true">
                            </asp:CheckBoxList>
                        </div>
                    </td>
                    <td valign="top">
                        <div style="margin-left: 4px;">
                            &nbsp;
                            <asp:CheckBox id="CheckboxJobRequests" runat="server" Text="Include Job Requests"/><br /><br /><br />
                            <asp:CheckBoxList ID="CheckBoxListCampaigns" runat="server" Enabled="false" Visible="false" AppendDataBoundItems="true">
                            </asp:CheckBoxList>
                            <asp:Button ID="ButtonSave" runat="server" Text="Save" />
                        </div>
                    </td>
                </tr>
            </table>
                </ContentTemplate>
            </asp:UpdatePanel>
    </telerik:RadToolTip>
</asp:Content>
