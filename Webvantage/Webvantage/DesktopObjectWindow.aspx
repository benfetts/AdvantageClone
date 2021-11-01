<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="DesktopObjectWindow.aspx.vb" Inherits="Webvantage.DesktopObjectWindow" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <telerik:RadCodeBlock ID="RadScriptBlock1" runat="server">
        <script type="text/javascript">
            function OpenAlertNotifiy() {
                window.location.href = window.location.href;
            }
            <%= Me.JavascriptAlertTimer %>
            function RebindGrid() {
                __doPostBack("RebindGrid", "");
            }
            function ReloadPage() {
                __doPostBack("ReloadPage", "");
            }
        </script>
    </telerik:RadCodeBlock>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div style="width:99% !important;">
        <asp:PlaceHolder ID="PlaceHolderUserControl" runat="server"></asp:PlaceHolder>
    </div>
</asp:Content>
