<%@ Page Title="Print Media Calendar" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="MediaCalendar_Print.aspx.vb" Inherits="Webvantage.MediaCalendar_Print" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    <table align="center" border="0">
        <tr>
            <td>
                Additional Data
            </td>
        </tr>
        <tr>
            <td align="left">
                <asp:Label   ID="lblLocation" runat="server" Text='Location:'></asp:Label>
                <telerik:RadComboBox ID="ddLocations" runat="server" SkinID="RadComboBoxStandard">
                </telerik:RadComboBox>
                <br />
                <asp:Label   ID="lblAdd" runat="server" Text='Additional Text:'></asp:Label><br />
                <asp:TextBox ID="txtData" runat="server" TextMode="MultiLine" Height="70px" Width="275px" SkinID="TextBoxStandard"></asp:TextBox>
            </td>
        </tr>
    </table>
    <p align="center">
        <asp:Button ID="butSelect" runat="server" Text="Select" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</p>
    &nbsp; &nbsp;&nbsp;
    <br />
</asp:Content>
