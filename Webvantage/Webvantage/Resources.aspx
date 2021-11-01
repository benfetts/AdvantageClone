<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Resources.aspx.vb" Inherits="Webvantage.ResourcesPage"
    MasterPageFile="~/ChildPage.Master" Title="" %>

<%@ Register Src="Resources.ascx" TagName="Resources" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <asp:Literal ID="LitScript" runat="server"></asp:Literal>
    <table width="600" border="0" cellspacing="2" cellpadding="0">
        <tr>
            <td>
                <asp:Label   ID="LblMSG" runat="server" CssClass="CssRequired" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <uc1:Resources runat="server" ID="UcResources" Visible="True" ShowRefreshTaskGridButton="False" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="BtnSelect" runat="server"  Text="Select" />&nbsp;&nbsp;
                <input  onclick="CloseThisWindow();" type="button" value="Cancel" />
            </td>
        </tr>
    </table>
</asp:Content>