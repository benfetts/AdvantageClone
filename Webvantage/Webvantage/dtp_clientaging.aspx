<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="dtp_clientaging.aspx.vb" Inherits="Webvantage.dtp_clientaging" %>

<%@ Register Src="Print_Buttons.ascx" TagName="Print_Buttons" TagPrefix="webvantage" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <table align="center" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td width="30%" align="left">
                &nbsp;<asp:Label   ID="lblTitle" runat="server"></asp:Label>
            </td>
            <td width="70%" align="right">
                <asp:Label   ID="lblClient" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <telerik:RadHtmlChart ID="RadHtmlChartClientAging" runat="server" Width="600" Height="385">
        

                </telerik:RadHtmlChart>
                <br />
            </td>
        </tr>
        <tr>
            <td align="right" colspan="3">
                <asp:Label   ID="lblDate" runat="server" Visible="false"></asp:Label>&nbsp;
            </td>
        </tr>
    </table>
    <webvantage:Print_Buttons ID="Print_Buttons1" runat="server" />
</asp:Content>