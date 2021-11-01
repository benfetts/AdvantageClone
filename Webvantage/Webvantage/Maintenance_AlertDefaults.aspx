<%@ Page Title="Alert Defaults" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="Maintenance_AlertDefaults.aspx.vb" Inherits="Webvantage.Maintenance_AlertDefaults" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <table width="600" border="0" cellspacing="2" cellpadding="0">
        <tr>
            <td>
                <telerik:RadComboBox ID="RadComboBoxAlertLevel" runat="server" SkinID="RadComboBoxStandard">
                </telerik:RadComboBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:RadioButtonList ID="RadioButtonListStandardAlertOrAssignment" runat="server">
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <h4>
                    Default Subject</h4>
            </td>
        </tr>
        <tr>
            <td style="vertical-align:top;" valign="top">
                <asp:ListBox ID="ListBoxSubjectSource" runat="server"></asp:ListBox>
                <asp:ListBox ID="ListBoxSubjectItems" runat="server"></asp:ListBox>
                <asp:TextBox ID="TextBoxSubjectCustomText" runat="server" SkinID="TextBoxStandard"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="TextBoxSubjectSample" runat="server" ReadOnly="true" Width="90%" SkinID="TextBoxStandard"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <h4>
                    Default Filename</h4>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top;" valign="top">
                <asp:ListBox ID="ListBoxFilenameSource" runat="server"></asp:ListBox>
                <asp:ListBox ID="ListBoxFilenameItems" runat="server"></asp:ListBox>
                <asp:TextBox ID="TextBoxFilenameCustomText" runat="server" SkinID="TextBoxStandard"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="TextBoxFilenameSample" runat="server" ReadOnly="true" Width="90%" SkinID="TextBoxStandard"></asp:TextBox>
            </td>
        </tr>
    </table>
</asp:Content>
