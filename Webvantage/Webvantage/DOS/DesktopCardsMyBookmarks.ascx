<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="DesktopCardsMyBookmarks.ascx.vb" Inherits="Webvantage.DesktopCardsMyBookmarks" %>
<div class="DO-ButtonHeader">
    <div style="float: left; width: 90%; text-align: left;">
    </div>
    <div style="float: right; width: 10%; text-align: right;">
        <asp:ImageButton ID="ImageButtonRefreshDesktopCardsMyBookmarks" runat="server" ImageAlign="AbsMiddle" SkinID="ImageButtonRefresh" ToolTip="Refresh" />
    </div>
</div>
<div class="card-container">
    <style>
        .bm-card {
            border-bottom: 4px solid #808080 !important;
            width: 305px !important;
            min-height: 75px !important;
        }

    </style>
    <asp:DataList ID="DataListBookmarks" runat="server" GridLines="None" RepeatColumns="1" RepeatLayout="Table" DataKeyField="Id" Width="95%">
        <ItemTemplate>
            <h4 runat="server" id="HeaderFolderName" style="margin-bottom:14px; display:none !important;">
                <asp:Label ID="LabelFolderName" runat="server" Text='<%#Eval("FolderName")%>'></asp:Label>
            </h4>
            <div class="card bm-card">
                <div class="card-content" style="cursor: pointer;">
                    <div id="HeaderBookmarkName" runat="server">
                        <div style="font-weight: bold;">
                            <asp:Label ID="LabelName" runat="server" Text='<%#Eval("Name")%>'></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:Label ID="LabelDescription" runat="server" Text='<%#Eval("Description")%>&nbsp;&nbsp;'></asp:Label>
                    </div>
                </div>
                <div id="DivActionBar" runat="server" class="card-bottom-header">
                    <div class="card-action-bar">
                         <asp:ImageButton ID="ImageButtonDownload" runat="server" ToolTip="Download" CommandName="download" ImageUrl="~/Images/Icons/Color/256/arrow_down.png" CssClass="card-action-icon" Visible="false" />
                         <asp:ImageButton ID="ImageButtonEdit" runat="server" ToolTip="Edit" CommandName="edit" ImageUrl="~/Images/Icons/Color/256/edit.png" CssClass="card-action-icon" />
                   </div>
                </div>
            </div>
        </ItemTemplate>
        <EditItemTemplate>
            <h4 runat="server" id="HeaderFolderName" style="margin-bottom: 14px;">
                <asp:Label ID="LabelFolderName" runat="server" Text='<%#Eval("FolderName")%>'></asp:Label>
            </h4>
            <div class="card bm-card">
                <div class="card-content">
                    <div style="margin-top: 8px;">
                        Name:<br />
                        <asp:TextBox ID="TextBoxName" runat="server" Text='<%#Eval("Name")%>' Width="90%" MaxLength="100"></asp:TextBox>
                    </div>
                    <div style="margin-top: 6px;">
                        Description:<br />
                        <asp:TextBox ID="TextBoxDescription" runat="server" Text='<%#Eval("Description")%>' Width="90%" MaxLength="500"></asp:TextBox>
                    </div>
                </div>
                <div id="DivActionBar" runat="server" class="card-bottom-header">
                    <div class="card-action-bar">
                        <asp:HiddenField ID="HiddenFieldBookmarkID" runat="server" Value='<%#Eval("Id")%>' />
                        <asp:ImageButton ID="ImageButtonSave" runat="server" ToolTip="Save" CommandName="update" ImageUrl="~/Images/Icons/Color/256/floppy_disk.png" CssClass="card-action-icon" />
                        <asp:ImageButton ID="ImageButtonDelete" runat="server" ToolTip="Delete" CommandName="delete" ImageUrl="~/Images/Icons/Color/256/delete.png" CssClass="card-action-icon" OnClientClick="return confirm('Are you sure you want to delete?');" />
                        <asp:ImageButton ID="ImageButtonCancel" runat="server" ToolTip="Cancel" CommandName="cancel" ImageUrl="~/Images/Icons/Color/256/undo.png" CssClass="card-action-icon" />
                    </div>
                </div>
            </div>
        </EditItemTemplate>
    </asp:DataList>
</div>
