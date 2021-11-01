<%@ Page Title="Alert Comment" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="Alert_Comment.aspx.vb" Inherits="Webvantage.Alert_Comment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div style="margin-right: 7px; margin-left: 10px; margin-bottom: 12px;">
        <h4>
            <asp:Label   ID="LabelEmployeeName" runat="server" Text=""></asp:Label>&nbsp;,
            <asp:Label   ID="LabelGeneratedDate" runat="server" Text=""></asp:Label>
        </h4>
        <div>
            <asp:Label   ID="LabelComment" runat="server" Text=""></asp:Label>
        </div>
    </div>
    <div class="centered" style="padding-top: 3px;">
        <asp:Button ID="ButtonClose" runat="server" Text="Close" Visible="True" TabIndex="0" />
    </div>
</asp:Content>
