<%@ Page Title="Saved Chats" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="Chat_List.aspx.vb" Inherits="Webvantage.Chat_List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <script type="text/javascript" src="Scripts/jquery.signalR-2.4.2.min.js"></script>
    <script src="signalr/hubs"></script>
    <style>
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div class="telerik-aqua-body" style= "margin-top: 5px!important; max-width: 96%!important;">
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
            <div style="margin: 4px 0px 6px 0px;">
                <telerik:RadComboBox ID="RadComboBoxChatType" runat="server" AutoPostBack="true" Width="200">
                    <Items>
                        <telerik:RadComboBoxItem Text="Chats I started" Value="started" />
                        <telerik:RadComboBoxItem Text="Chats I took part in" Value="participated" />
                    </Items>
                </telerik:RadComboBox>
            </div>
            <div style="width:100%;">
                <telerik:RadGrid ID="RadGridChatList" runat="server" AllowMultiRowSelection="True" AllowSorting="True" AutoGenerateColumns="False" GridLines="None" ShowGroupPanel="False">
                    <ClientSettings AllowColumnsReorder="False" AllowDragToGroup="False">
                        <Resizing AllowColumnResize="True" EnableRealTimeResize="True" />
                        <Selecting AllowRowSelect="False" />
                    </ClientSettings>
                    <MasterTableView AllowMultiColumnSorting="true" DataKeyNames="ID, RoomID">
                        <Columns>
                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnViewDetails">
                                <HeaderStyle CssClass="radgrid-icon-column" />
                                <ItemStyle CssClass="radgrid-icon-column" />
                                <FooterStyle CssClass="radgrid-icon-column" />
                                <ItemTemplate>
                                    <div class="icon-background background-color-sidebar">
                                        <asp:ImageButton ID="ImageButtonViewDetails" runat="server" ImageAlign="AbsMiddle" CssClass="icon-image" SkinID="ImageButtonViewWhite" ToolTip="View Chat Room Log" />
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnContinueChat">
                                <HeaderStyle CssClass="radgrid-icon-column" />
                                <ItemStyle CssClass="radgrid-icon-column" />
                                <FooterStyle CssClass="radgrid-icon-column" />
                                <ItemTemplate>
                                    <div class="icon-background background-color-sidebar">
                                        <asp:ImageButton ID="ImageButtonContinueChat" runat="server" ImageAlign="AbsMiddle" CssClass="icon-image" ImageUrl="~/Images/Icons/White/256/chat.png" ToolTip="Continue Chat" CommandName="ContinueChat" />
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnRoomName" DataField="Name" HeaderText="Room" SortExpression="Name">
                                <HeaderStyle Width="400" />
                                <ItemStyle Width="400" />
                                <FooterStyle Width="400" />
                                <ItemTemplate>
                                    <div style="width:100%;">
                                        <asp:Label ID="LabelRoomName" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div id="DivRoomDescription" runat="server" style="font-size: small; width: 100%;">
                                        <asp:Label ID="LabelRoomDescription" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div id="DivJobAndComponent" runat="server" style="font-size: small; width: 100%;">
                                        <asp:Label ID="LabelJobAndComponent" runat="server" Text=""></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="StartedByUserCode" HeaderText="By" UniqueName="GridBoundColumnStartedByUserCode" SortExpression="StartedByUserCode">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="radgrid-usercode-column" />
                                <ItemStyle CssClass="radgrid-usercode-column" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="CreateDate" HeaderText="Started On" UniqueName="GridBoundColumnCreateDate" DataFormatString="{0:G}" SortExpression="CreateDate">
                                <HeaderStyle VerticalAlign="Middle" HorizontalAlign="right" CssClass="radgrid-datetime-column"  />
                                <ItemStyle VerticalAlign="Middle" HorizontalAlign="right" CssClass="radgrid-datetime-column"  />
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnDelete">
                                <HeaderStyle CssClass="radgrid-icon-column" />
                                <ItemStyle CssClass="radgrid-icon-column" />
                                <FooterStyle CssClass="radgrid-icon-column" />
                                <ItemTemplate>
                                    <div id="DivDeleteButton" runat="server" class="icon-background background-color-delete">
                                        <asp:ImageButton ID="ImageButtonDelete" runat="server" SkinID="ImageButtonDeleteWhite" ToolTip="Click to delete this row" CommandName="DeleteRow" />
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
                </ContentTemplate>
            </asp:UpdatePanel>
    </div>

</asp:Content>
