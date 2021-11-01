<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="dtp_alerts.aspx.vb" Inherits="Webvantage.dtp_alerts" %>

<%@ Register Src="Print_Buttons.ascx" TagName="Print_Buttons" TagPrefix="webvantage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <asp:Repeater ID="rpAlerts" runat="server">
        <HeaderTemplate>
            <table border="0" cellpadding="2" cellspacing="0" width="100%" align="center">
                <tr>
                    <td align="left" colspan="2" >
                        &nbsp;&nbsp; Alerts&nbsp;&nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="center" class="SubHeaderStyle">
                        Date
                    </td>
                    <td align="left" class="SubHeaderStyle">
                        Subject
                    </td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr >
                <td align="center" valign="top" >
                    <span>
                        <%# Eval("Date", "{0:d}") %>
                    </span>
                </td>
                <td align="left" >
                    <span>
                        <%# Eval("Subject") %>
                    </span>
                </td>
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <tr >
                <td align="center" valign="top" >
                    <span>
                        <%# Eval("Date", "{0:d}") %>
                    </span>
                </td>
                <td align="left" >
                    <span>
                        <%# Eval("Subject") %>
                    </span>
                </td>
            </tr>
        </AlternatingItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <webvantage:Print_Buttons ID="Print_Buttons1" runat="server" />
</asp:Content>