<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="Quickbooks_Authentication.aspx.vb" Inherits="Webvantage.Quickbooks_Authentication" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
        <script type="text/javascript">
            
            //function CloseWindowRefreshEmailSettings() {

            //    console.debug(window.parent);

            //    window.parent.closeSettingsDialog();
            //}
            function closeThisDialog() {
                //window.parent.closeSettingsDialog();
                window.close();
            }
            function OpenQuickbooksAuthorization() {
                window.open(document.getElementById('HiddenFieldLink').value);
            }

        </script>
    </telerik:RadScriptBlock>
    <table id="FailureTable" cellpadding="0" cellspacing="0" width="100%" align="center" border="0" runat="server" >
        <tr>
            <td><br /></td>
        </tr>
        <tr>
            <td align="center">
                There was a problem obtaining an authorization token.  Please check Client ID and/or Client Secret.
            </td>
        </tr>
        <tr>
            <td><br /></td>
        </tr>
<%--        <tr>
            <td align="center">
                <telerik:RadTextBox ID="RadTextBoxAuthorizationCode" runat="server" Width="100%"></telerik:RadTextBox>
            </td>
        </tr>--%>
        <tr>
            <td><br /></td>
        </tr>
        <tr>
            <td align="center">
                <%--<asp:Button ID="ButtonOk" runat="server" CausesValidation="False" TabIndex="7" Text="Ok" /> &nbsp;&nbsp;--%>
                <asp:Button ID="ButtonCancel" runat="server" CausesValidation="False" TabIndex="8" Text="Ok" OnClientClick="closeThisDialog();" />
            </td>
        </tr>
        <tr>
            <td><br /></td>
        </tr>
<%--        <tr>
            <td align="center">
                Google Authorization page fail to open? <a href="javascript:void(0)" onclick="OpenGoogleAuthorization()">Click Here</a>
            </td>
        </tr>--%>
    </table>
    <asp:HiddenField ID="HiddenFieldLink" runat="server" ClientIDMode="Static" />

</asp:Content>
