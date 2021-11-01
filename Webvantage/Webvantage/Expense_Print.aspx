<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" 
    CodeBehind="Expense_Print.aspx.vb" Inherits="Webvantage.Expense_Print" %>
<asp:Content ID="ContentMain" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <table cellpadding="0" cellspacing="0" width="100%" align="center" border="0">
        <tr>
            <td>
                <telerik:RadToolBar ID="RadToolbarOptions" runat="server" AutoPostBack="True" Width="100%">
                    <Items>
                        <telerik:RadToolBarButton ID="RadToolBarButtonFirstSeparator" runat="server" IsSeparator="true" />
                        <telerik:RadToolBarButton ID="RadToolBarButtonPrint" runat="server" Text="Print" Value="Print" SkinID="RadToolBarButtonPrint"
                            CommandName="Print" ToolTip="Print Expense Report" />
                        <telerik:RadToolBarButton ID="RadToolBarButtonSecondSeparator" runat="server" IsSeparator="true" />
                    </Items>
                </telerik:RadToolBar>
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%" cellpadding="0" cellspacing="5">
                    <tr>
                        <td height="5px" colspan="3">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width:10px;"></td>
                        <td style="width: 400px;">
                            <asp:CheckBox ID="CheckBoxPrintSupervisorName" runat="server" AutoPostBack="false" Text="Print Supervisor Name Below Signature Line" /><br />
                            <asp:CheckBox ID="CheckBoxExcludeEmployeeSignature" runat="server" AutoPostBack="false" Text="Exclude Employee Signature" /><br />
                            <asp:CheckBox ID="CheckBoxIncludeReceipts" runat="server" AutoPostBack="false" Text="Include Receipts" />
                        </td>
                        <td style="width:10px;"></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>

</asp:Content>
