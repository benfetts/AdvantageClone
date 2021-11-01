<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Documents_AddComment.aspx.vb"
    Inherits="Webvantage.Documents_AddComment" Title="Add Comment" MasterPageFile="~/ChildPage.Master" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <telerik:RadToolBar ID="RadToolBarAddComment" runat="server" AutoPostBack="true" Width="100%">
        <Items>
            <telerik:RadToolBarButton ID="RadToolBarSeparatorFirstSeparator" runat="server" IsSeparator="true" />
            <telerik:RadToolBarButton ID="RadToolBarButtonSave" runat="server" Text=""
                Value="Save" CommandName="Save" ToolTip="Save comment" SkinID="RadToolBarButtonSave" />
            <telerik:RadToolBarButton ID="RadToolBarSeparatorSecondSeparator" runat="server"
                IsSeparator="true" />
            <telerik:RadToolBarButton ID="RadToolBarButtonCancel" runat="server" Text="Cancel"
                Value="Cancel" CommandName="Cancel" ToolTip="Cancel" />
            <telerik:RadToolBarButton ID="RadToolBarSeparatorThirdSeparator" runat="server" IsSeparator="true" />
        </Items>
    </telerik:RadToolBar>
    <div style="margin:10px 0px 10px 0px;">
        Enter a comment:
    </div>
    <asp:TextBox ID="TextBoxComment" runat="server" Text="" CssClass="CssTextBox" TextMode="MultiLine" Height="300" Width="95%" SkinID="TextBoxStandard">
    </asp:TextBox>
    <asp:Literal ID="LitScript" runat="server"></asp:Literal>
</asp:Content>
