<%@ Page AutoEventWireup="false" CodeBehind="TrafficSchedule_SaveDialog.aspx.vb"
    MasterPageFile="~/ChildPage.Master" Title="" Inherits="Webvantage.TrafficSchedule_SaveDialog"
    Language="vb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <asp:Literal ID="LitScript" runat="server"></asp:Literal>
    <table border="0" cellpadding="2" cellspacing="2" width="100%">
        <tr>
            <td colspan="3">
                <br />
               Would you like to update the status?
            </td>
        </tr>
        <tr>
            <td width="5%">
                <asp:RadioButton ID="RblStatusChangeNextTask" runat="server" GroupName="GrpStatusChange" />
            </td>
            <td width="35%">
                <%--<span></span>--%>Status based on next task:
            </td>
            <td width="60%">
                <asp:HiddenField ID="HFNextTaskStatusCode" runat="server" />
                <asp:Label   ID="LblNextTaskStatus" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:RadioButton ID="RblStatusChangeSelect" runat="server" GroupName="GrpStatusChange" />
            </td>
            <td>
                <%--<span></span>--%>Select status:
            </td>
            <td>
                <%--<telerik:RadComboBox ID="RadComboBoxStatus" runat="server">
                    </telerik:RadComboBox>--%>
                <telerik:RadComboBox ID="DropStatus" runat="server" SkinID="RadComboBoxStandard">
                </telerik:RadComboBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:RadioButton ID="RblStatusChangeNone" runat="server" GroupName="GrpStatusChange" />
            </td>
            <td>
                <%--<span></span>--%>Save without updating status.
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3" align="center">
                <asp:Button ID="BtnSave" runat="server" Text="Save" />&nbsp;&nbsp;
                <asp:Button ID="BtnCancel" runat="server" OnClientClick="javascript:CallFunctionOnParentPage('HidePopUpWindows');return false;"
                    Text="Cancel" />
            </td>
        </tr>
    </table>
</asp:Content>
