<%@ Control AutoEventWireup="false" Codebehind="BillingApproval_Approval_Tooltip.ascx.vb"
    Inherits="Webvantage.BillingApproval_Approval_Tooltip" Language="vb" %>

<table border="0" cellpadding="0" cellspacing="2" width="100%">
    <tr>
        <td>
            <asp:Image ID="ImgStatus" runat="server" AlternateText=""  ImageUrl="~/Images/spacer.gif"
                ToolTip="" Visible="true"  />
        </td>
        <td >
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
        <td align="right" valign="middle">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td width="100">
           Create Date:</td>
        <td width="200px">
            <asp:Label   ID="LblCreated" runat="server" Text=""></asp:Label></td>
        <td width="116">
           Modified Date:</td>
        <td width="300">
            <asp:Label   ID="LblModified" runat="server" Text=""></asp:Label></td>
    </tr>
    <tr>
        <td>
           Create User:</td>
        <td >
            <asp:Label   ID="LblUserID" runat="server" Text=""></asp:Label></td>
        <td>
           Modified User:</td>
        <td>
            <asp:Label   ID="LblModifiedUser" runat="server" Text=""></asp:Label></td>
    </tr>
    <tr>
        <td>
           Batch Date:</td>
        <td >
            &nbsp;<asp:Label   ID="LblBatchDate" runat="server"></asp:Label></td>
        <td>
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td>
           Description:</td>
        <td colspan="3">
            <asp:Label   ID="LblBatchDescription" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="4">
           Assigned Employee:&nbsp;&nbsp;<asp:Label   ID="LblAssigendEmp" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td>
           Date Cutoff:</td>
        <td >
            <asp:Label   ID="LblDateCutoff" runat="server"></asp:Label></td>
        <td>
           Period Cutoff:</td>
        <td>
            <asp:Label   ID="LblPeriodCutoff" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td colspan="4">
           Selected Account Executives:</td>
    </tr>
    <tr>
        <td colspan="4">
            <asp:Label   ID="LblAEs" runat="server" Text=""></asp:Label></td>
    </tr>
    <tr>
        <td colspan="4">
           Selection Level:&nbsp;&nbsp;<asp:Label   ID="LblLOAD_LEVEL" runat="server"
                Text=""></asp:Label></td>
    </tr>
    <tr>
        <td colspan="4">
           Selections:</td>
    </tr>
    <tr>
        <td colspan="4">
            <asp:Label   ID="LblSelections" runat="server" Text=""></asp:Label></td>
    </tr>
    <tr>
        <td colspan="4"><br />
           Include Options</td>
    </tr>
    <tr>
        <td colspan="2">
           Production:</td>
        <td colspan="2">
            &nbsp;</td>
    </tr>
    <tr>
        <td colspan="2">
            Non Billable Records:&nbsp;&nbsp;<asp:Label   ID="LblNonBillableRecs" runat="server"
                Text=""></asp:Label></td>
        <td colspan="2">
            &nbsp;</td>
    </tr>
    <tr>
        <td colspan="2">
            Fee Time Records:&nbsp;&nbsp;<asp:Label   ID="LblFeeTimeRecs" runat="server" Text=""></asp:Label></td>
        <td colspan="2">
            &nbsp;</td>
    </tr>
</table>
