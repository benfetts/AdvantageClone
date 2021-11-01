<%@ Page Title="Schedule By Task" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="TrafficScheduleByTask_Render.aspx.vb" Inherits="Webvantage.TrafficScheduleByTask_Render" %>

<%@ Register Src="Print_Buttons.ascx" TagName="Print_Buttons" TagPrefix="webvantage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <table id="Table1" border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr >
            <td >
                <p align="left">
                    <asp:Label   ID="lblTitle" runat="server" Width="500px">Schedule Report</asp:Label></p>
            </td>
            <td >
                <p align="right">
                    <asp:Label   ID="lblDate" runat="server" Width="200px">Date</asp:Label></p>
            </td>
        </tr>
    </table>
        <asp:DataGrid ID="gridReport" runat="server" CellPadding="0" GridLines="None" Width="99%">
            <HeaderStyle CssClass="SubHeaderStyle" />
        </asp:DataGrid>
        <webvantage:Print_Buttons ID="Print_Buttons1" runat="server" />
</asp:Content>
