<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="purchaseorder_approval.aspx.vb"
    MasterPageFile="~/ChildPage.Master" Title="Purchase Order Approval" Inherits="Webvantage.purchaseorder_approval" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
    <asp:Label   ID="lblMSG" runat="server" CssClass="CssRequired"></asp:Label>
    <div style="margin-top: 10px; text-align:center;">
        <span>Purchase Order cannot be printed until approved.</span>
        <div>
            <asp:RadioButtonList ID="rblPriority" runat="server" RepeatDirection="Horizontal" style="margin: 0 auto;" CellSpacing="10">
                <asp:ListItem Value="1">Highest</asp:ListItem>
                <asp:ListItem Value="2">High</asp:ListItem>
                <asp:ListItem Value="3" Selected="True">Normal</asp:ListItem>
                <asp:ListItem Value="4">Low</asp:ListItem>
                <asp:ListItem Value="5">Lowest</asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <div style="text-align: right; margin-top: 20px;">
            <asp:Button ID="SaveButton" runat="server" Text="Get Approval" />&nbsp;
            <asp:Button id="CancelButton2" runat="server" Text="Cancel" />
        </div>
    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

    <asp:Literal ID="LitScript" runat="server"></asp:Literal>
</asp:Content>
