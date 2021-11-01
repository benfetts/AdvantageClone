<%@ Page Title="You have new Alerts" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="Alert_Notification.aspx.vb" Inherits="Webvantage.Alert_Notification" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <style>
        html {
            overflow: hidden !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div id="outerNotificationContainer">
        <div id="leftNotificationContainer">
            <asp:ListView ID="ListViewLinks" runat="server">
                <ItemTemplate>
                    <div id="DivAlert" runat="server" class="alert-notification-container">
                        <div id="DivDetails" runat="server" class="alert-notification" style="">
                            <asp:Literal ID="LiteralComment" runat="server"></asp:Literal>
                        </div>
                        <asp:HiddenField ID="HiddenFieldIsAssignment" runat="server" Value='<%#Eval("IsAssignment")%>' />
                    </div>
                </ItemTemplate>
            </asp:ListView>
        </div>
        <div id="rightNotificationContainer">
            <div style="margin: 0px 0px 0px 0px;">
                <asp:ImageButton ID="ImageButtonMarkAllAsRead" runat="server" ImageUrl="~/Images/Icons/Grey/256/mail_open.png" CssClass="icon-image" ToolTip="Mark all as read" OnClientClick="MarkAllEmailAsRead();HideAlertNotify();" />
            </div>
            <div style="margin: 8px 0px 0px 0px;">
                <asp:ImageButton ID="ImageButtonDismissAlerts" runat="server" ImageUrl="~/Images/Icons/Grey/256/garbage.png" CssClass="icon-image" ToolTip="Dismiss all alerts (does not complete assignments)" OnClientClick="return confirm('Dismiss alerts?\n(Does not complete assignments)');" />
            </div>
        </div>
    </div>
</asp:Content>
