<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Print_Buttons.ascx.vb"
    Inherits="Webvantage.Print_Buttons" %>
<p align="center">
    <asp:Button ID="BtnPrint" runat="server" Text="Print" />&nbsp;
    <asp:Button ID="BtnClose" runat="server" Text="Close" OnClientClick="window.close();" />
</p>
