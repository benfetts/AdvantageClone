<%@ Page Title="New Chat Room" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="Chat_NewRoomCreator.aspx.vb" Inherits="Webvantage.Chat_NewRoomCreator" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div>
        <telerik:RadToolBar ID="RadToolbarNewChatRoom" runat="server" Width="100%">
            <Items>
                <telerik:RadToolBarButton SkinID="RadToolBarButtonChat" Text="" Value="Chat" CommandName="Chat"></telerik:RadToolBarButton>
            </Items>
        </telerik:RadToolBar>
        <div style="width: 95%; padding: 8px;">
            <div>
                Who should be in the room:
            </div>
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                <div>
                    <asp:RadioButtonList ID="RadioButtonListEmployeeType" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" RepeatLayout="Flow" CausesValidation="false">
                    </asp:RadioButtonList>
                </div>
                <div>
                    <telerik:RadListBox ID="RadListBoxEmployees" runat="server" SelectionMode="Multiple" Width="100%" Height="300" CheckBoxes="false">
                        <ItemTemplate>
                            <div style="height: 50px;">
                                <div style="display: inline-block; height: 50px;">
                                    <dx:ASPxBinaryImage ID="ASPxBinaryImage1" runat="server" Value='<%#Eval("Picture")%>' BinaryStorageMode="Session"
                                        CssClass="wv-employee-img-thumbnail" ViewStateMode="Enabled" StoreContentBytesInViewState="true" EmptyImage-Url="~/Images/Icons/Grey/256/user.png">
                                    </dx:ASPxBinaryImage>
                                </div>
                                <div style="display: inline-block; height: 50px; vertical-align: middle; margin-top: 2px;">
                                    <%#Eval("FullName")%>
                                </div>
                            </div>
                        </ItemTemplate>
                    </telerik:RadListBox>
                </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div style="margin: 8px 0px 0px 0px;">
                Room Name: <asp:RequiredFieldValidator ID="RequiredFieldValidatorRoomName" runat="server" ErrorMessage="Room name is required" ControlToValidate="TextBoxRoomName"></asp:RequiredFieldValidator>

            </div>
            <div>
                <asp:TextBox ID="TextBoxRoomName" runat="server" Width="96%" ToolTip="The name of your room/conversation" MaxLength="100"></asp:TextBox>
            </div>
            <div style="margin: 8px 0px 0px 0px;">
                Description:
            </div>
            <div>
                <asp:TextBox ID="TextBoxRoomDescription" runat="server" Width="96%" TextMode="MultiLine" ToolTip="A description for your room/conversation"></asp:TextBox>
            </div>
            <div style="margin: 8px 0px 0px 0px;">
                <div>
                    <asp:CheckBox ID="CheckBoxIsPrivate" runat="server" Text="Private" Checked="true" ToolTip="Make room visible to those not selected from above" />
                </div>
                <div>
                    <asp:CheckBox ID="CheckBoxSaveRoom" runat="server" Text="Save initial room" Checked="true" ToolTip="This saves the room even if everyone leaves" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
