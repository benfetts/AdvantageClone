<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="DesktopObjectLoadWindow.aspx.vb" Inherits="Webvantage.DesktopObjectLoadWindow" EnableEventValidation="false" %>

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
    <style>
        .ew-css table th, .ew-css table td {
            padding: 1px 0px 1px 1px!important;
        }
        .RadForm.rfdRadio.rfdLabel label {
            line-height: 20px!important;
            font-size: 14px!important;
        }
    </style>
    <div class="" style="">
         <div style="width:100% !important;">
            <asp:PlaceHolder ID="PlaceHolderUserControl" runat="server"></asp:PlaceHolder>
        </div>
    </div>
   
</asp:Content>
