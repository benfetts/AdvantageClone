<%@ Control AutoEventWireup="false" Codebehind="BillingApproval_Approval_JobComponent_Comments_Tooltip.ascx.vb"
    Inherits="Webvantage.BillingApproval_Approval_JobComponent_Comments_Tooltip"
    Language="vb" %>
<asp:Panel ID="PnlComments" runat="server">
    <table border="0" cellpadding="0" cellspacing="2" width="400">
        <tr>
            <td>
               Approval Comments</td>
        </tr>
        <tr>
            <td>
                <asp:Label   ID="LblApprovalComments" runat="server" Text="&nbsp;"></asp:Label>
            </td>
        </tr>
        <tr><td>&nbsp;</td></tr>
        <tr>
            <td>
               Client Comments</td>
        </tr>
        <tr>
            <td>
                <asp:Label   ID="LblClientComments" runat="server" Text="&nbsp;"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Panel>
