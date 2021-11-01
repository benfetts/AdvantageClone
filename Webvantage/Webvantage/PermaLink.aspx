<%@ Page Title="PermaLink" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="PermaLink.aspx.vb" Inherits="Webvantage.PermaLink" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div>
        <div>
            <asp:TextBox ID="TextBoxWebvantageLink" runat="server" TextMode="MultiLine" Width="98%" Rows="20" SkinID="TextBoxStandard"></asp:TextBox>
        </div>
        <div>
            <asp:TextBox ID="TextBoxClientPortalLink" runat="server" TextMode="MultiLine" Width="98%" Rows="20" SkinID="TextBoxStandard"></asp:TextBox>
        </div>
    </div>
</asp:Content>
