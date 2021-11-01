<%@ Page Title="Project Summary" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="TrafficSchedule_ProjectSummary.aspx.vb" Inherits="Webvantage.TrafficSchedule_ProjectSummary" %>

<%@ Register Src="UnityUC.ascx" TagName="UnityContextMenu" TagPrefix="custom" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <custom:UnityContextMenu ID="MyUnityContextMenu" runat="server" />
    <h4>
        <asp:Label runat="server" ID="job1" Text="Job:"></asp:Label>
        &nbsp;&nbsp;
    <asp:Label runat="server" ID="jobNbr"></asp:Label>
        <asp:Label runat="server" ID="jobDesc"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label runat="server" ID="comp1" Text="Component:"></asp:Label>
        &nbsp;&nbsp;
    <asp:Label runat="server" ID="compNbr"></asp:Label>
        <asp:Label runat="server" ID="compDesc"></asp:Label>
    </h4>
    <fieldset>
        <legend>Alerts</legend>
        <asp:Label runat="server" ID="lblAlert"></asp:Label>
    </fieldset>
    <fieldset>
        <legend>Creative Brief</legend>
        <asp:Label runat="server" ID="lblCB"></asp:Label>
    </fieldset>
    <fieldset>
        <legend>Job Specification</legend>
        <asp:Label runat="server" ID="lblJobSpec"></asp:Label>
    </fieldset>
    <fieldset>
        <legend>
            <asp:Label ID="LabelLegendChangeOrders" runat="server" Text="Change Orders"></asp:Label></legend>
        <asp:Label runat="server" ID="lblVersion"></asp:Label>
    </fieldset>
    <fieldset>
        <legend>Estimate</legend>
        <asp:Label runat="server" ID="lblEst"></asp:Label>
    </fieldset>
    <fieldset>
        <legend>Project Schedule</legend>
        <asp:Label runat="server" ID="lblSched"></asp:Label>
    </fieldset>
    <fieldset runat="server" id="qva">
        <legend>QvA</legend>
        <asp:Label runat="server" ID="lblQvA"></asp:Label>
    </fieldset>
    <div class="centered">
        <asp:Button ID="btnPrint" runat="server" CommandName="Print" Text="Print" />
        &nbsp;&nbsp;
        <asp:Button ID="btnBack" runat="server" Text="Close" OnClientClick="CloseThisWindow();" />
    </div>
</asp:Content>