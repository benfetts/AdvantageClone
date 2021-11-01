<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Alert_Html.aspx.vb" Inherits="Webvantage.Alert_Html" %>

<%@ Register Src="Print_Buttons.ascx" TagName="Print_Buttons" TagPrefix="webvantage" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="CSS/Print.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <table width="98%" border="0" cellspacing="0" cellpadding="2" align="center">
        <tr>
            <td colspan="4" class="HeaderStyle2">
                <asp:Label ID="LblHeader" runat="server" Text="Alert"></asp:Label>
            </td>
        </tr>
        <tr id="TrRecipientsHdr" runat="server">
            <td colspan="4" style="font-weight:bold;">
                Recipients
            </td>
        </tr>
        <tr id="TrRecipients" runat="server">
            <td align="right" valign="middle">
                &nbsp;
            </td>
            <td colspan="3">
                <asp:Label ID="LblRecipients" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr id="TrAlertAssignmentHdr" runat="server">
            <td colspan="4" style="font-weight: bold;">
                Assignment
            </td>
        </tr>
        <tr id="TrWorkflowTemplate" runat="server">
            <td align="right" valign="middle">
                Workflow Template:
            </td>
            <td colspan="3">
                <asp:Label ID="LblWorkflowTemplate" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr id="TrState" runat="server">
            <td align="right" valign="middle">
                State:
            </td>
            <td colspan="3">
                <asp:Label ID="LblState" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr id="TrAssignTo" runat="server">
            <td align="right" valign="middle">
                Assign To:
            </td>
            <td colspan="3">
                <asp:Label ID="LblAssignTo" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="4" style="font-weight: bold;">
                Details
            </td>
        </tr>
        <tr id="TrAlertType" runat="server">
            <td align="right" valign="middle">
                Alert Type:
            </td>
            <td colspan="3">
                <asp:Label ID="LblAlertType" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr id="TrGenerated" runat="server">
            <td align="right" valign="middle">
                Generated:
            </td>
            <td colspan="3">
                <asp:Label ID="LblGenerated" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr id="TrDismissed" runat="server">
            <td align="right" valign="middle">
                Dismissed:
            </td>
            <td colspan="3">
                <asp:Label ID="LblDismissed" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr id="TrOffice" runat="server">
            <td align="right" valign="middle">
                Office:
            </td>
            <td colspan="3">
                <asp:Label ID="LblOffice" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr id="TrClient" runat="server">
            <td align="right" valign="middle">
                Client:
            </td>
            <td colspan="3">
                <asp:Label ID="LblClient" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr id="TrDivision" runat="server">
            <td align="right" valign="middle">
                Division:
            </td>
            <td colspan="3">
                <asp:Label ID="LblDivision" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr id="TrProduct" runat="server">
            <td align="right" valign="middle">
                Product:
            </td>
            <td colspan="3">
                <asp:Label ID="LblProduct" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr id="TrEstimate" runat="server">
            <td align="right" valign="middle">
                Estimate:
            </td>
            <td colspan="3">
                <asp:Label ID="LblEstimate" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr id="TrEstimateComponent" runat="server">
            <td align="right" valign="middle">
                Component:
            </td>
            <td colspan="3">
                <asp:Label ID="LblEstimateComponent" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr id="TrCampaign" runat="server">
            <td align="right" valign="middle">
                Campaign:
            </td>
            <td colspan="3">
                <asp:Label ID="LblCampaign" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr id="TrJob" runat="server">
            <td align="right" valign="middle">
                Job:
            </td>
            <td colspan="3">
                <asp:Label ID="LblJob" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr id="TrComponent" runat="server">
            <td align="right" valign="middle">
                Component:
            </td>
            <td colspan="3">
                <asp:Label ID="LblComponent" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr id="TrTask" runat="server">
            <td align="right" valign="middle">
                Task:
            </td>
            <td colspan="3">
                <asp:Label ID="LblTask" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="4" style="font-weight: bold;">
                Information
            </td>
        </tr>
        <tr id="TrCategory" runat="server">
            <td align="right" valign="middle">
                Category:
            </td>
            <td>
                <asp:Label ID="LblCategory" runat="server" Text=""></asp:Label>
            </td>
            <td align="right" valign="middle">
                ID:
            </td>
            <td>
                <asp:Label ID="LabelAlertID" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr id="TrPriority" runat="server">
            <td align="right" valign="middle">
                Priority:
            </td>
            <td colspan="3">
                <asp:Label ID="LblPriority" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr id="TrDueDate" runat="server">
            <td align="right" valign="middle">
                Due Date:
            </td>
            <td colspan="3">
                <asp:Label ID="LblDueDate" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr id="TrTimeDue" runat="server">
            <td align="right" valign="middle">
                Time Due:
            </td>
            <td colspan="3">
                <asp:Label ID="LblTimeDue" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <!-- -->
        <tr id="TrVersion" runat="server">
            <td align="right" valign="middle">
                Version:
            </td>
            <td colspan="3">
                <asp:Label ID="LabelVersion" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr id="TrBuild" runat="server">
            <td align="right" valign="middle">
                Build:
            </td>
            <td colspan="3">
                <asp:Label ID="LabelBuild" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <!-- -->
        <tr id="TrSubject" runat="server">
            <td align="right" valign="top">
                Subject:
            </td>
            <td colspan="3" valign="top" align="justify">
                <asp:Label ID="LblSubject" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr id="TrDescription" runat="server">
            <td align="right" valign="top">
                Description:
            </td>
            <td colspan="3" valign="top" align="justify">
                <asp:Label ID="LblDescription" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr id="TrComments" runat="server">
            <td colspan="4" style="font-weight: bold;">
                Comments
            </td>
        </tr>
        <tr id="TrCommentsTable" runat="server">
            <td colspan="4">
                <table id="TblComments" runat="server" width="100%" border="0" cellspacing="0" cellpadding="2">
                </table>
            </td>
        </tr>
        <tr id="TrAttachmentsHdr" runat="server">
            <td colspan="4" style="font-weight: bold;">
                Attachments
            </td>
        </tr>
        <tr id="TrAttachmentsTable" runat="server">
            <td colspan="4">
                <table id="TblAttachments" runat="server" width="100%" border="0" cellspacing="0"
                    cellpadding="4">
                    <tr>
                        <td width="5">
                            &nbsp;
                        </td>
                        <td class="TableBorderBottom">
                            Filename
                        </td>
                        <td width="60" align="right" valign="middle" class="TableBorderBottom">
                            Size
                        </td>
                        <td width="120" class="TableBorderBottom">
                            Added By
                        </td>
                        <td width="105" align="right" valign="middle" class="TableBorderBottom">
                            Added
                        </td>
                        <td width="40" align="center" valign="middle" class="TableBorderBottom">
                            Private
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td width="100">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td width="100">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <webvantage:Print_Buttons ID="Print_Buttons1" runat="server" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>