<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="JobInfo.ascx.vb" Inherits="Webvantage.JobInfo_Tooltip" %>
<style>
.info-row-spacer {
    margin: 0px 0px 8px 0px !important;
}
</style>
<div id="DivJobInfo" runat="server" style="width: 100%; padding: 10px 10px 10px 10px; display: block;">
    <div style="position: relative; width: 49%; display: inline-block; vertical-align: top;">
        <div id="DivOffice" runat="server" class="info-row-spacer">
            <div style="display: inline-block;">
                Office:&nbsp;
            </div>
            <div style="display: inline-block;">
                <asp:Label ID="LabelOffice" runat="server"></asp:Label>
            </div>
        </div>
        <div id="DivClient" runat="server" class="info-row-spacer">
            <div style="display: inline-block;">
                Client:&nbsp;
            </div>
            <div style="display: inline-block;">
                <asp:Label ID="LabelClient" runat="server"></asp:Label>
            </div>
        </div>
        <div id="DivDivision" runat="server" class="info-row-spacer">
            <div style="display: inline-block;">
                Division:&nbsp;
            </div>
            <div style="display: inline-block;">
                <asp:Label ID="LabelDivision" runat="server"></asp:Label>
            </div>
        </div>
        <div id="DivProduct" runat="server" class="info-row-spacer">
            <div style="display: inline-block;">
                Product:&nbsp;
            </div>
            <div style="display: inline-block;">
                <asp:Label ID="LabelProduct" runat="server"></asp:Label>
            </div>
        </div>
    </div>
    <div style="position: relative; width: 50%; display: inline-block; vertical-align: top;">
        <div id="DivCampaign" runat="server" class="info-row-spacer">
            <div style="display: inline-block;">
                Campaign:
            </div>
            <div style="display: inline-block;">
                <asp:Label ID="LabelCampaign" runat="server"></asp:Label>
            </div>
        </div>
        <div id="DivJob" runat="server" class="info-row-spacer">
            <div style="display: inline-block;">
                Job:
            </div>
            <div style="display: inline-block;">
                <asp:LinkButton ID="LinkButtonJob" runat="server"></asp:LinkButton>
            </div>
        </div>
        <div id="DivJobComponent" runat="server" class="info-row-spacer">
            <div style="display: inline-block;">
                Component:
            </div>
            <div style="display: inline-block;">
                <asp:LinkButton ID="LinkButtonJobComponent" runat="server"></asp:LinkButton>
            </div>
        </div>
    </div>
</div>