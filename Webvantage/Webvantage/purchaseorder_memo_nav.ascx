<%@ Control AutoEventWireup="false" CodeBehind="purchaseorder_memo_nav.ascx.vb" Inherits="Webvantage.purchaseorder_memo_nav"
    Language="vb" %>
<telerik:RadToolBar ID="RadToolbarPOMemo" runat="server" AutoPostBack="True" Width="100%">
    <Items>
        <telerik:RadToolBarButton Text="Add Line" Value="SelAddRow"
            ToolTip="Add Another Line (Row) to this Purchase Order" Visible="False" />
        <telerik:RadToolBarButton IsSeparator="true" />
        <telerik:RadToolBarButton Text="PO Detail" Value="SelPODetail"
            ToolTip="Purchase Order List" />
        <telerik:RadToolBarButton IsSeparator="true" />
        <telerik:RadToolBarButton Text="Main Instructions"
            Value="SelMainInstruct" Hidden="False" ToolTip="View or Change Main Instructions for this Purchase Order" />
        <telerik:RadToolBarButton IsSeparator="true" />
        <telerik:RadToolBarButton  Text="Delivery Instructions"
            Value="SelDelivery" Hidden="False" ToolTip="View or change Delivery Instructions for the Purcahse Order" />
        <telerik:RadToolBarButton IsSeparator="true" />
        <telerik:RadToolBarButton Text="Footer Comments"
            Value="SelFooter" Hidden="False" ToolTip="View or change Footer Comments for this Purchase Order" />
        <telerik:RadToolBarButton IsSeparator="true" />
    </Items>
</telerik:RadToolBar>
<asp:Label   ID="lbl_current_tab" runat="server" Text="PO" Visible="False"></asp:Label>
