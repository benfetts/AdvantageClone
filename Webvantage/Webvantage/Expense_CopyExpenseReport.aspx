<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Expense_CopyExpenseReport.aspx.vb"
    MasterPageFile="~/ChildPage.Master" Title="" Inherits="Webvantage.Expense_CopyExpenseReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <table width="100%" border="0" cellspacing="2" cellpadding="0">
        <tr>
            <td width="15">
                &nbsp;
            </td>
            <td width="90">
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
                Employee:
            </td>
            <td>
                <telerik:RadComboBox ID="RadCombobox_Employee" DataValueField="Code" DataTextField="Name" runat="server" SkinID="RadComboboxEmployee" >
                </telerik:RadComboBox>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                Report Date:
            </td>
            <td>
                <telerik:RadDatePicker ID="RadDatePicker_ReportDate" runat="server" CssClass="RequiredInput" SkinID="RadDatePickerStandard" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                Description:
            </td>
            <td>
                <telerik:RadTextBox runat="server" Width="70%" TextMode="SingleLine" ID="RadTextBox_Description" CssClass="RequiredInput" MaxLength="30"></telerik:RadTextBox>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                Details:
            </td>
            <td>
                <telerik:RadTextBox runat="server" Width="90%" TextMode="MultiLine" ID="RadTextBox_Details"></telerik:RadTextBox>
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
        <tr>
            <td>
                &nbsp;
            </td>
            <td colspan="2">
                <asp:Button ID="Button_Copy" runat="server" Text="Copy" />&nbsp;&nbsp;
                <asp:Button ID="Button_Cancel" runat="server" Text="Cancel" OnClientClick="CloseThisWindow();" />
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