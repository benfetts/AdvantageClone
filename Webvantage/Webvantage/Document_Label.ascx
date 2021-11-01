<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Document_Label.ascx.vb" Inherits="Webvantage.Document_Label" %>
<div id="DivLabel" runat="server" class="document-label-containter" style="">
    <asp:Label ID="LabelLabelName" runat="server" Text="" ToolTip="" CssClass="document-label-text"></asp:Label>&nbsp;&nbsp<asp:LinkButton ID="LinkButtonRemoveLabel" runat="server" Text="X" CssClass="document-label-x"></asp:LinkButton>
    <asp:HiddenField ID="HiddenFieldLabelID" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenFieldDocumentID" runat="server" Value="0" />
</div>
