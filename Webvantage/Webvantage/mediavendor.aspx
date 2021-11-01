<%@ Page AutoEventWireup="false" CodeBehind="mediavendor.aspx.vb" Inherits="Webvantage.mediavendor"
    MasterPageFile="~/ChildPage.Master" Title="" Language="vb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <asp:Panel runat="server" ID="apnlVendor" Width="100%">
        <div align="center">
            <asp:LinkButton ID="lbMediaInfo" runat="server" Text='Media Information' Css></asp:LinkButton><br />
            <asp:LinkButton ID="lbMediaDelivery" runat="server" Text='Media Delivery Information'
                Css></asp:LinkButton><br />
            <asp:LinkButton ID="lbMediaSpecs" runat="server" Text='Media Specifications' Css></asp:LinkButton>
            <br />
            <br />
        </div>
    </asp:Panel>
    <div align="center">
        <asp:Button ID="btnClose" runat="server" Text="Close" />&nbsp;
        <asp:Button ID="btnCancel" runat="server" Text="Close" />
    </div>
</asp:Content>