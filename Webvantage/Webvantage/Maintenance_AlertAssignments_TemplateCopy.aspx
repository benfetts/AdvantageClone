<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Maintenance_AlertAssignments_TemplateCopy.aspx.vb"
    MasterPageFile="~/ChildPage.Master" Title="" Inherits="Webvantage.Maintenance_AlertAssignments_TemplateCopy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <table width="100%" border="0" cellspacing="2" cellpadding="0">
        <tr>
            <td width="15">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td >
                &nbsp;
            </td>
            <td>
                Template Name
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:TextBox ID="TxtAlertNotifyName" runat="server" Width="500" MaxLength="100" SkinID="TextBoxStandard"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:CheckBox ID="ChkCopyTeam" runat="server" Text="Copy Team?" Checked="true" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:Button ID="BtnCopy" runat="server" Text="Copy" />&nbsp;&nbsp;
                <asp:Button ID="BtnCancel" runat="server" Text="Cancel" OnClientClick="CloseThisWindow();" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
