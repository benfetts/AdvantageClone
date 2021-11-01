<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UnityUC.ascx.vb" Inherits="Webvantage.UnityUC" ClassName="UnityUC" %>
<asp:HiddenField ID="HiddenFieldGridClickedRowIndex" runat="server" />
<telerik:RadContextMenu ID="RadContextMenuUnity" runat="server" EnableRoundedCorners="false" EnableShadows="true" OnClientShowing="UnityOnClientShowing" CssClass="unity-menu">
    <Targets>
    </Targets>
    <Items>
        <telerik:RadMenuItem Text="" Value="RadMenuItemJobInformation" Enabled="false" Visible="false">
            <ItemTemplate>
                <div style="display:block !important;">
                    <asp:Label ID="LabelJobInformation" runat="server" Text=""></asp:Label>
                </div>
            </ItemTemplate>
        </telerik:RadMenuItem>

        <telerik:RadMenuItem IsSeparator="true" Value="RadMenuItemSeparatorJobInformation" Visible="false"></telerik:RadMenuItem>

        <telerik:RadMenuItem Text="New Alert" Value="NewAlert"></telerik:RadMenuItem>
        <telerik:RadMenuItem Text="New Assignment" Value="NewAssignment"></telerik:RadMenuItem>
        <telerik:RadMenuItem Text="New Proof" Value="NewProof"></telerik:RadMenuItem>
        <telerik:RadMenuItem Text="Link" Value="DeepLinkExternal" Visible="false"></telerik:RadMenuItem>

        <telerik:RadMenuItem IsSeparator="true" Value="RadMenuItemSeparatorAlertActions"></telerik:RadMenuItem>

        <telerik:RadMenuItem Text="New Job" Value="NewJob"></telerik:RadMenuItem>

        <telerik:RadMenuItem IsSeparator="true" Value="RadMenuItemSeparatorNewJob"></telerik:RadMenuItem>

        <telerik:RadMenuItem Text="Job Jacket" Value="JobJacket">
            <Items>
                <telerik:RadMenuItem Text="Alerts" Value="Alerts"></telerik:RadMenuItem>
                <telerik:RadMenuItem Text="Documents" Value="Documents"></telerik:RadMenuItem>
                <telerik:RadMenuItem Text="Creative Brief" Value="CreativeBrief"></telerik:RadMenuItem>
                <telerik:RadMenuItem Text="Specifications" Value="Specifications"></telerik:RadMenuItem>
                <telerik:RadMenuItem Text="Versions" Value="Versions"></telerik:RadMenuItem>
                <telerik:RadMenuItem Text="Estimates" Value="Estimates"></telerik:RadMenuItem>
                <telerik:RadMenuItem Text="Schedule" Value="Schedule"></telerik:RadMenuItem>
                <telerik:RadMenuItem Text="Boards" Value="ProjectBoard"></telerik:RadMenuItem>
                <telerik:RadMenuItem Text="QvA" Value="QvA"></telerik:RadMenuItem>
                <telerik:RadMenuItem Text="Purchase Orders" Value="PurchaseOrders"></telerik:RadMenuItem>
                <telerik:RadMenuItem Text="Events" Value="Events"></telerik:RadMenuItem>
                <telerik:RadMenuItem Text="Proofs" Value="Review"></telerik:RadMenuItem>
                <telerik:RadMenuItem Text="Snapshot" Value="Snapshot"></telerik:RadMenuItem>
            </Items>
        </telerik:RadMenuItem>

        <telerik:RadMenuItem IsSeparator="true" Value="RadMenuItemSeparatorTimesheetActions" Visible="false"></telerik:RadMenuItem>

        <telerik:RadMenuItem Text="Add Time" Value="AddTime"></telerik:RadMenuItem>
        <telerik:RadMenuItem Text="Stopwatch" Value="Stopwatch"></telerik:RadMenuItem>

        <telerik:RadMenuItem IsSeparator="true" Value="RadMenuItemSeparatorPrint"></telerik:RadMenuItem>

        <telerik:RadMenuItem Text="Chat" Value="Chat" Visible="false"></telerik:RadMenuItem>
        <telerik:RadMenuItem Text="Print" Value="Print"></telerik:RadMenuItem>
        <telerik:RadMenuItem Text="Send Alert" Value="SendAlert"></telerik:RadMenuItem>
        <telerik:RadMenuItem Text="Send Assignment" Value="SendAssignment"></telerik:RadMenuItem>
        <telerik:RadMenuItem Text="Send Email" Value="SendEmail"></telerik:RadMenuItem>
        <telerik:RadMenuItem Text="Print/Send Options" Value="PrintSendOptions"></telerik:RadMenuItem>
    </Items>
</telerik:RadContextMenu>
<asp:Literal ID="LiteralRadgridScript" runat="server"></asp:Literal>
