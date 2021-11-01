<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="dtp_billing_trends.aspx.vb" Inherits="Webvantage.dtp_billing_trends" %>

<%@ Register Src="Print_Buttons.ascx" TagName="Print_Buttons" TagPrefix="webvantage" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <table align="center" cellpadding="2" cellspacing="0" width="100%">
        <tr>
            <td align="Left">
                &nbsp;&nbsp;<asp:Label   ID="lblTitle" runat="server"></asp:Label>
            </td>
            <td align="right">
                <asp:Label   ID="lblType" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <telerik:RadHtmlChart ID="RadHtmlChartBillingTrends" runat="server" Height="300" Width="500">

                </telerik:RadHtmlChart>
                <br />
            </td>
        </tr>
        <tr>
            <td align="right" colspan="2">
                <asp:Label   ID="lblDate" runat="server" Visible="false"></asp:Label>&nbsp;
            </td>
        </tr>
    </table>
    <webvantage:Print_Buttons ID="Print_Buttons1" runat="server" />
</asp:Content>