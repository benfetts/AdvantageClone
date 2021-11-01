<%@ Page Title="Media Player" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="Documents_MediaViewer.aspx.vb" Inherits="Webvantage.Documents_MediaViewer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
        <telerik:RadMediaPlayer ID="RadMediaPlayerDocument" runat="server" Text="Media Player"></telerik:RadMediaPlayer>
                </ContentTemplate>
            </asp:UpdatePanel>
</asp:Content>
