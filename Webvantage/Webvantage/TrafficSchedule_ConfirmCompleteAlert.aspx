<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="TrafficSchedule_ConfirmCompleteAlert.aspx.vb" Inherits="Webvantage.TrafficSchedule_ConfirmCompleteAlert" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <h3 style="width: 90%; padding: 30px 10px 0px 40px;">
        <asp:Label ID="LabelMessage" runat="server" />
    </h3>
    <div style="width:97%; padding: 40px 0px 0px 0px;text-align:center;">
        <asp:Button ID="ButtonYes" runat="server" Text="Yes" Width="175" />
        &nbsp;&nbsp;
        <asp:Button ID="ButtonNo" runat="server" Text="No" Width="175" />
    </div>
</asp:Content>
