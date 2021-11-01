<%@ Page AutoEventWireup="false" CodeBehind="TrafficSchedule_Notify.aspx.vb" Inherits="Webvantage.TrafficSchedule_Notify"
    MasterPageFile="~/ChildPage.Master" Title="" Language="vb" %>
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
    <telerik:RadAjaxManagerProxy ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadioSendToGroup">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="AutoCompleteRecipients" />
                    <telerik:AjaxUpdatedControl ControlID="AddRecipientsButton" />
                    <telerik:AjaxUpdatedControl ControlID="RadioSendToGroup" />
                    <telerik:AjaxUpdatedControl ControlID="RadioNotifyEmployeesTask" />
                    <telerik:AjaxUpdatedControl ControlID="RadioNotifyEmployeesAll" />
                    <telerik:AjaxUpdatedControl ControlID="RadioNotifyNext" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadioNotifyEmployeesTask">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="AutoCompleteRecipients" />
                    <telerik:AjaxUpdatedControl ControlID="AddRecipientsButton" />
                    <telerik:AjaxUpdatedControl ControlID="RadioSendToGroup" />
                    <telerik:AjaxUpdatedControl ControlID="RadioNotifyEmployeesTask" />
                    <telerik:AjaxUpdatedControl ControlID="RadioNotifyEmployeesAll" />
                    <telerik:AjaxUpdatedControl ControlID="RadioNotifyNext" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadioNotifyEmployeesAll">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="AutoCompleteRecipients" />
                    <telerik:AjaxUpdatedControl ControlID="AddRecipientsButton" />
                    <telerik:AjaxUpdatedControl ControlID="RadioSendToGroup" />
                    <telerik:AjaxUpdatedControl ControlID="RadioNotifyEmployeesTask" />
                    <telerik:AjaxUpdatedControl ControlID="RadioNotifyEmployeesAll" />
                    <telerik:AjaxUpdatedControl ControlID="RadioNotifyNext" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadioNotifyNext">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="AutoCompleteRecipients" />
                    <telerik:AjaxUpdatedControl ControlID="AddRecipientsButton" />
                    <telerik:AjaxUpdatedControl ControlID="RadioSendToGroup" />
                    <telerik:AjaxUpdatedControl ControlID="RadioNotifyEmployeesTask" />
                    <telerik:AjaxUpdatedControl ControlID="RadioNotifyEmployeesAll" />
                    <telerik:AjaxUpdatedControl ControlID="RadioNotifyNext" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="AddRecipientsButton">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="AutoCompleteRecipients" />
                    <telerik:AjaxUpdatedControl ControlID="AddRecipientsButton" />
                    <telerik:AjaxUpdatedControl ControlID="RadioSendToGroup" />
                    <telerik:AjaxUpdatedControl ControlID="RadioNotifyEmployeesTask" />
                    <telerik:AjaxUpdatedControl ControlID="RadioNotifyEmployeesAll" />
                    <telerik:AjaxUpdatedControl ControlID="RadioNotifyNext" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="BtnClearRecipients">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="BtnClearRecipients" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <table border="0" cellpadding="2" cellspacing="2" width="570">
        <tr>
            <td align="left" valign="middle">
                Recipients:
            </td>
        </tr>
        <tr>
            <td align="left" valign="middle">
                <asp:RadioButton ID="RadioSendToGroup" runat="server" AutoPostBack="true" Text="Notify Alert Group"
                    GroupName="SendTo" />
                <asp:RadioButton ID="RadioNotifyEmployeesTask" runat="server" AutoPostBack="true"
                    GroupName="SendTo" Text="Notify Employees(Task)" />
                <asp:RadioButton ID="RadioNotifyEmployeesAll" runat="server" AutoPostBack="true"
                    GroupName="SendTo" Text="Notify Employees(All)" />
                <asp:RadioButton ID="RadioNotifyNext" runat="server" AutoPostBack="true" GroupName="SendTo"
                    Text="Notify Next" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="AddRecipientsButton" runat="server" CausesValidation="False" Text="Select Recipients"
                    UseSubmitBehavior="False" />
            </td>
        </tr>
        <tr>
            <td align="left" valign="middle">
                <custom:AutoCompleteAlertRecipient runat="server" ID="AutoCompleteRecipients" Visible="true" />
            </td>
        </tr>
        <tr>
            <td align="left"  valign="middle">
                Subject:
            </td>
        </tr>
        <tr>
            <td align="left" valign="middle">
                <asp:TextBox ID="TxtSubject" runat="server" Width="570px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%">
                    <tr>
                        <td align="left" valign="middle">
                            <span >Priority:</span>
                            <asp:RadioButtonList ID="RblPriority" runat="server" RepeatDirection="Horizontal"
                                RepeatLayout="Flow">
                                <asp:ListItem Value="1">Highest</asp:ListItem>
                                <asp:ListItem Value="2">High</asp:ListItem>
                                <asp:ListItem Value="3" Selected="True">Normal</asp:ListItem>
                                <asp:ListItem Value="4">Low</asp:ListItem>
                                <asp:ListItem Value="5">Lowest</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <td align="Right" valign="middle">
                            <asp:CheckBox ID="ChkIncludeReport" runat="server" Text="Include Schedule PDF" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="left" valign="middle">
                <telerik:RadEditor ID="RadEditorBody" runat="server" Width="575px" Height="200px" NewLineBr="true" NewLineMode="Br"
                    ContentAreaCssFile="~/CSS/RadEditorContentArea.css" ToolsFile="~/RadEditorToolbars.xml"
                    ToolbarMode="Default" EditModes="Design">
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
                <table>
                    <tr>
                        <td align="right" style="width: 120px" valign="top">
                           Attachment/Link:
                        </td>
                        <td valign="top">
                            <telerik:RadComboBox ID="AttachemtTypeDropDownList" runat="server" AutoPostBack="true"
                                Width="300px">
                                <Items>
                                 <telerik:RadComboBoxItem Text="Upload a document." Value="Upload">
                                </telerik:RadComboBoxItem>
                                <telerik:RadComboBoxItem Text="Link to an existing Webvantage document." Value="Link">
                                </telerik:RadComboBoxItem>
                               </Items>
                            </telerik:RadComboBox>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 120px" valign="top">
                            &nbsp;&nbsp;<asp:ImageButton ID="ImageButtonHelpFileSelection" runat="server" ImageUrl="~/Images/help_blue-trans.png" ImageAlign="AbsMiddle" OnClientClick="OpenRadWindow('Selecting files for upload','Help_FileSelection.aspx');return false;" />
                        </td>
                        <td valign="top">
                            <telerik:RadAsyncUpload ID="RadUploadTrafficScheduleNotify" runat="server" AutoAddFileInputs="true"
                                MultipleFileSelection="Disabled" MaxFileInputsCount="1"
                                InputSize="50">
                            </telerik:RadAsyncUpload>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 120px" valign="top">
                        </td>
                        <td valign="top">
                            <telerik:RadComboBox ID="LinkDropDownList" runat="server" AutoPostBack="true" Width="450px">
                                <telerik:RadComboBoxItem Text="Upload a document." Value="Upload"></telerik:RadComboBoxItem>
                                <telerik:RadComboBoxItem Text="Link to an existing Webvantage document." Value="Link"></telerik:RadComboBoxItem>
                            </telerik:RadComboBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center" valign="middle">
                <asp:HiddenField ID="HFDefaultGroupString" runat="server" />
                <asp:HiddenField ID="HFIDString" runat="server" />
                <asp:Button ID="BtnSend" runat="server" Text="Send" />&nbsp;&nbsp;
                <asp:Button ID="BtnSkip" runat="server" Text="Skip" />&nbsp;&nbsp;
                <asp:Button ID="BtnClose" runat="server" Text="Close" />
            </td>
        </tr>
    </table>
</asp:Content>