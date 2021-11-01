<%@ Page AutoEventWireup="false" CodeBehind="dtp_timesheet.aspx.vb" Inherits="Webvantage.dtp_timesheet"
    MasterPageFile="~/ChildPage.Master" Title="" Language="vb" %>

<%@ Register Src="Print_Buttons.ascx" TagName="Print_Buttons" TagPrefix="webvantage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <table border="0" cellpadding="2" cellspacing="0" width="100%">
        <tr>
            <td align="left" colspan="2">
                &nbsp;&nbsp;Timesheet &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label   ID="LBtnMissingTime" runat="server" CssClass="warning"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" class="SubHeaderStyle">
                Day
            </td>
            <td align="right" class="SubHeaderStyle">
                Hours
            </td>
        </tr>
        <tr>
            <td>
                <asp:HyperLink ID="hypSunday" runat="server"></asp:HyperLink>
            </td>
            <td align="right">
                <asp:Label   ID="lblSunday" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:HyperLink ID="hypMonday" runat="server"></asp:HyperLink>
            </td>
            <td align="right">
                <asp:Label   ID="lblMonday" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:HyperLink ID="hypTuesday" runat="server"></asp:HyperLink>
            </td>
            <td align="right">
                <asp:Label   ID="lblTuesday" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:HyperLink ID="hypWednesday" runat="server"></asp:HyperLink>
            </td>
            <td align="right">
                <asp:Label   ID="lblWednesday" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:HyperLink ID="hypThursday" runat="server"></asp:HyperLink>
            </td>
            <td align="right">
                <asp:Label   ID="lblThursday" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:HyperLink ID="hypFriday" runat="server"></asp:HyperLink>
            </td>
            <td align="right">
                <asp:Label   ID="lblFriday" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:HyperLink ID="hypSaturday" runat="server"></asp:HyperLink>
            </td>
            <td align="right">
                <asp:Label   ID="lblSaturday" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Total Hours
            </td>
            <td align="right">
                <asp:Label   ID="lblTotalHours" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <webvantage:Print_Buttons ID="Print_Buttons1" runat="server" />
</asp:Content>