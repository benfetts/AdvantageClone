<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="DesktopProjectViewpoint_Details.ascx.vb" Inherits="Webvantage.DesktopProjectViewpoint_Details" %>
<div id="DivAllTooltipInfo">
    <h3>
        <asp:Label runat="server" ID="jobNbr"></asp:Label>&nbsp;-&nbsp;
         <asp:Label runat="server" ID="jobDesc"></asp:Label><br />
       <asp:Label runat="server" ID="compNbr"></asp:Label>&nbsp;-&nbsp;
        <asp:Label runat="server" ID="compDesc"></asp:Label>
    </h3>
    <strong>Alerts</strong>
    <br />
    <asp:Label runat="server" ID="lblAlert"></asp:Label>
    <br />
    <br />
    <strong>Creative Brief</strong>
    <br />
    <asp:Label runat="server" ID="lblCB"></asp:Label>
    <br />
    <br />
    <strong>Job Specification</strong>
    <br />
    <asp:Label runat="server" ID="lblJobSpec"></asp:Label>
    <br />
    <br />
    <strong>
        <asp:Label ID="LabelLegendChangeOrders" runat="server" Text="Change Orders"></asp:Label>
    </strong>
    <br />
    <asp:Label runat="server" ID="lblVersion"></asp:Label>
    <br />
    <br />
    <strong>Estimate</strong>
    <br />
    <asp:Label runat="server" ID="lblEst"></asp:Label>
    <br />
    <br />
    <strong>Project Schedule</strong>
    <br />
    <asp:Label runat="server" ID="lblSched"></asp:Label>
    <br />
    <br />
    <asp:Panel ID="PanelQVA" runat="server">
        <strong>QvA</strong>
        <br />
        <asp:Label runat="server" ID="lblQvA"></asp:Label>
        <br />
        <br />
    </asp:Panel>
</div>
<div class="centered">
    <asp:Button ID="ButtonPrint" runat="server" OnClientClick="PrintContent();return false;" Text="Print" />
    <br />
</div>