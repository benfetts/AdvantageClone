<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="DesktopCardDayNavigator.ascx.vb" Inherits="Webvantage.DesktopCardDayNavigator" %>
<div style="display: block;width:100%;margin-left:5px;">
    <table style="width: 100%;">
        <tr>
            <td style="padding-top: 8px;">
                <asp:LinkButton ID="LinkButtonDate" runat="server" ToolTip="Click to refresh" CssClass="date-nav"></asp:LinkButton>
            </td>
            <td style="width: 110px;">
                <div style="display: inline-block;">
                    <asp:ImageButton ID="ImageButtonPrevious" runat="server" ImageUrl="~/Images/Icons/Grey/256/navigate_left.png" CssClass="icon-image" />
                </div>
                <div style="display: inline-block;">
                    <asp:ImageButton ID="ImageButtonToday" runat="server" ImageUrl="~/Images/Icons/Grey/256/star.png" CssClass="icon-image" />
                </div>
                <div style="display: inline-block;">
                    <asp:ImageButton ID="ImageButtonNext" runat="server" ImageUrl="~/Images/Icons/Grey/256/navigate_right.png" CssClass="icon-image" />
                </div>
            </td>
        </tr>
    </table>
</div>
