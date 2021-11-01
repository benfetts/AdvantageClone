<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="dtp_currentRatio_graph_print.aspx.vb" Inherits="Webvantage.dtp_currentRatio_graph_print" %>

<%@ Register Src="Print_Buttons.ascx" TagName="Print_Buttons" TagPrefix="webvantage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <table align="center" border="0" cellpadding="2" cellspacing="0" width="100%">
        <tr>
            <td align="Left">
                <asp:Label   ID="Label1" runat="server"></asp:Label>
                &nbsp;&nbsp;
                <asp:Label   ID="lblType" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center">
                <telerik:RadHtmlChart ID="RadHtmlChartCurrentRatio" runat="server" EnableViewState="false" Width="300" Height="200">

                </telerik:RadHtmlChart>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    <webvantage:Print_Buttons ID="Print_Buttons1" runat="server" />
</asp:Content>