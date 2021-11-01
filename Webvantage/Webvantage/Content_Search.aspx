<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="Content_Search.aspx.vb" Inherits="Webvantage.Content_Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <telerik:RadAutoCompleteBox ID="RadAutoCompleteBoxSearch" runat="server"></telerik:RadAutoCompleteBox>
</asp:Content>