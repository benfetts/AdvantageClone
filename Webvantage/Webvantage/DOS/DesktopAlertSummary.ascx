<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="DesktopAlertSummary.ascx.vb"
    Inherits="Webvantage.DesktopAlertSummary" EnableViewState="true" %>
<div style="width: 100%; text-align: center;">
    <asp:Label   ID="AlertSummaryLabel" runat="server" Text="Checking alerts..."></asp:Label>
    <br />
    <br />
    <asp:LinkButton ID="InboxLinkButton" runat="server" Text="Click here"></asp:LinkButton>
    to go to your alert inbox.
</div>
