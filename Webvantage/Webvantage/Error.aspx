<%@ Page Title="Error" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="Error.aspx.vb" Inherits="Webvantage.ErrorPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    
    <script>
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div style="margin: 10px 18px 0px 18px;">
        <h1 class="alert alert-danger" role="alert">Error</h1>
        <h3 style="margin: 0px 20px 0px 20px;"><asp:Label ID="LabelMessage" runat="server" Text=""></asp:Label></h3>
    </div>                  
</asp:Content>
