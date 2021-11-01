<%@ Page AutoEventWireup="false" CodeBehind="BillingApproval_Alert.aspx.vb" Inherits="Webvantage.BillingApproval_Alert" 
    Language="vb" MasterPageFile="~/ChildPage.Master" Title="Billing Approval Alert" %>
<%@ Register Src="Alert_RecipientUC.ascx" TagName="AutoCompleteAlertRecipient" TagPrefix="custom" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
        <script type="text/javascript">
            function ClientSetAutoCompleteEntries(str) {
                var autoCompleteBox = $find("<%= AutoCompleteRecipients.GetClientID%>");
                if (autoCompleteBox) {
                    var entries = new Array();
                    entries = str.split("|");
                    for (var i = 0; i < entries.length; i++) {
                        var emp = new Array();
                        emp = entries[i].split(",");
                        if (emp[0] != "") {
                            var entry = new Telerik.Web.UI.AutoCompleteBoxEntry();
                            entry.set_value(emp[0]);
                            entry.set_text(emp[1]);
                            autoCompleteBox.get_entries().add(entry);
                        }
                    }
                }
            }
        </script>
    </telerik:RadScriptBlock>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <asp:Literal ID="LitScript" runat="server"></asp:Literal>
    <table border="0" cellpadding="2" cellspacing="2" width="570">
        <tr>
            <td>
               Recipients:
            </td>
        </tr>
        <tr>
            <td>
                <asp:RadioButton ID="RadioSendToGroup" runat="server" AutoPostBack="true" GroupName="SendTo"
                    Text="Notify Alert Group" />
                <asp:RadioButton ID="RadioNotifyEmployee" runat="server" AutoPostBack="true" GroupName="SendTo"
                    Text="Notify Assigned Employee" />
                <asp:RadioButton ID="RadioNotifyBatchCreator" runat="server" AutoPostBack="true"
                    GroupName="SendTo" Text="Notify Batch Creator" />
                <asp:HiddenField ID="HfEmpCode" runat="server" />
                <asp:HiddenField ID="HfCreateUserEmpCode" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="AddRecipientsButton" runat="server" CausesValidation="False" Text="Select Recipients"
                    UseSubmitBehavior="False" />
            </td>
        </tr>
        <tr>
            <td>
                <custom:AutoCompleteAlertRecipient runat="server" ID="AutoCompleteRecipients" Visible="true" Width="800" />
            </td>
        </tr>
        <tr>
            <td>
               Subject:
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="TxtSubject" runat="server" Width="800" CssClass="RequiredInput" SkinID="TextBoxStandard"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
               Priority:
                <asp:RadioButtonList ID="RblPriority" runat="server" RepeatDirection="Horizontal"
                    RepeatLayout="Flow">
                    <asp:ListItem Value="1">Highest</asp:ListItem>
                    <asp:ListItem Value="2">High</asp:ListItem>
                    <asp:ListItem Selected="True" Value="3">Normal</asp:ListItem>
                    <asp:ListItem Value="4">Low</asp:ListItem>
                    <asp:ListItem Value="5">Lowest</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>
               Body:
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadEditor ID="RadEditorBody" runat="server" Width="800" Height="400px" NewLineBr="true" NewLineMode="Br" OnClientLoad="RadEditorOnClientLoad" StripFormattingOptions="MsWord"
                    ContentAreaCssFile="~/CSS/RadEditorContentArea.min.css" ToolsFile="~/RadEditorToolbars.xml" OnClientCommandExecuted="RadEditorOnClientCommandExecuted"
                    ToolbarMode="Default" EditModes="Design">
                        <CssFiles>
                            <telerik:EditorCssFile Value="~/CSS/RadEditorContentArea.css" />
                        </CssFiles>
                </telerik:RadEditor>
                <script type="text/javascript">
                    Telerik.Web.UI.Editor.Utils.containsHtmlAtClipboard = function (event) {
                        return false;
                    }
                </script>
            </td>
        </tr>
        <tr>
            <td>
                <asp:CheckBox ID="ChkIncludeReport" runat="server" Text="Include Schedule PDF" Visible="false" />&nbsp;
            </td>
        </tr>
        <tr>
            <td align="center" valign="middle">
                <asp:Button ID="BtnSend" runat="server" Text="Send" />&nbsp;&nbsp;
                <asp:Button ID="BtnClose" runat="server" Text="Close" />
            </td>
        </tr>
    </table>
</asp:Content>
