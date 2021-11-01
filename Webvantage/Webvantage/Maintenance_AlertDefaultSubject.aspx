<%@ Page Title="Alert Default Subject Maintenance" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="Maintenance_AlertDefaultSubject.aspx.vb" Inherits="Webvantage.Maintenance_AlertDefaultSubject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
        <table width="600" border="0" cellspacing="2" cellpadding="0">
            <tr>
                <td colspan="2">
                    <telerik:RadComboBox ID="RadComboBoxAlertLevel" runat="server" AutoPostBack="true" SkinID="RadComboBoxStandard">
                    </telerik:RadComboBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:RadioButtonList ID="RadioButtonListStandardAlertOrAssignment" runat="server" AutoPostBack="true">
                        <asp:ListItem Text="Standard Alerts" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Assignments" Value="2"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td colspan="2">&nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <h4>Default Subject</h4>
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top;" valign="top">
                    <telerik:RadListBox ID="RadListBoxSubjectSource" runat="server" Width="100%" Height="180"
                        SelectionMode="Multiple" AllowTransfer="true" TransferToID="RadListBoxSubjectItems"
                        AutoPostBackOnTransfer="true" AllowReorder="False" EnableDragAndDrop="true">
                    </telerik:RadListBox>
                </td>
                <td style="vertical-align: top;" valign="top">
                    <telerik:RadListBox ID="RadListBoxSubjectItems" runat="server" Width="100%" AutoPostBack="true"
                        Height="180" SelectionMode="Multiple" AllowReorder="true" AutoPostBackOnReorder="true"
                        EnableDragAndDrop="true">
                    </telerik:RadListBox>
                    <asp:TextBox ID="TextBoxSubjectCustomText" runat="server" SkinID="TextBoxStandard"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:TextBox ID="TextBoxSubjectSample" runat="server" ReadOnly="true" Width="90%" SkinID="TextBoxStandard"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="ButtonSave" runat="server" Text="Save" />
                </td>
            </tr>
        </table>
                </ContentTemplate>
            </asp:UpdatePanel>
</asp:Content>
