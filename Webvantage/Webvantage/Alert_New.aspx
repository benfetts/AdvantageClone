<%@ Page Title="New Alert" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="Alert_New.aspx.vb" Inherits="Webvantage.Alert_New" %>

<%@ Register Src="Alert_RecipientUC.ascx" TagName="AutoCompleteAlertRecipient" TagPrefix="custom" %>
<asp:Content ID="ContentHead" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
        <script type="text/javascript">
            function OnClientRequesting(sender, eventArgs) {
                var context = eventArgs.get_context();
                var client = $("#<%=Me.txtClient.ClientID%>")
                if (client && client.val() != "") {
                    context["ClientCode"] = client.val();
                }

                var division = $("#<%=Me.txtDivision.ClientID%>")
                if (division && division.val() != "") {
                    context["DivisionCode"] = division.val();
                }

                var product = $("#<%=Me.txtProduct.ClientID%>")
                if (product && product.val() != "") {
                    context["ProductCode"] = product.val();
                }

                var job = $("#<%=Me.txtJob.ClientID%>")
                if (job && job.val() != "") {
                    context["JobNumber"] = job.val();
                }
                var comp = $("#<%=Me.txtComponent.ClientID%>")
                if (comp && comp.val() != "") {
                    context["JobComponentNumber"] = comp.val();
                }
                console.log(context)
            }
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
            function GetDefaultAssignment() {
                __doPostBack('<%=UpdatePanel.ClientID%>', 'GetDefaultAssignment');
            }
            function ReloadAutoRecipientControl() {
                __doPostBack('<%=UpdatePanel.ClientID%>', 'ReloadAutoRecipientControl');
            }
            function RadToolbarAlertNewOnClientButtonClicking(sender, args) {
                var commandName = args.get_item().get_commandName();
                if (commandName === "DeleteDraft") {
                    ////args.set_cancel(!confirm("Are you sure you want to delete this draft?"));
                    radToolBarConfirm(sender, args, "Are you sure you want to delete this draft?");
                }
                if (commandName === "Send") {
                    var isValid = Page_ClientValidate(); //parameter is the validation group - thanks @Jeff
                    if (isValid){
                        disableSend();
                    }
                }
                if (commandName === "Clear") {
                    enableSend();
                }
                if (commandName === "DeleteDraft") {
                    ////args.set_cancel(!confirm("Are you sure you want to delete this draft?"));
                    radToolBarConfirm(sender, args, "Are you sure you want to delete this draft?");
                    enableSend();
                }
                 if (commandName === "SaveDraft") {
                    ////args.set_cancel(!confirm("This assignment is being saved into your drafts folder and will not appear on dashboards.  To finalize and send emails, click the Send button.\n\nContinue saving as draft?"));
                     radToolBarConfirm(sender, args, "This assignment is being saved into your drafts folder and will not appear on dashboards.  To finalize and send emails, click the Send button.\n\nContinue saving as draft?");
                }
           }
            function enableSend() {
                var toolBar = $find("<%=RadToolbarAlertNew.ClientID %>");
                var button = toolBar.findItemByValue("Send");
                button.enable();    
            }
            function disableSend() {
                var toolBar = $find("<%=RadToolbarAlertNew.ClientID %>");
                var button = toolBar.findItemByValue("Send");
                button.disable();    
            }
        </script>
        <style>
            .active-item {
                font-style: italic !important;
            }
        </style>
    </telerik:RadScriptBlock>
</asp:Content>
<asp:Content ID="ContentBody" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain" EnableViewState="true">
    <div style="margin-left: auto; margin-right: auto; left: 0; right: 0; text-align: center;">
        <telerik:RadToolBar ID="RadToolbarAlertNew" runat="server" AutoPostBack="True" Width="100%" OnClientButtonClicking="RadToolbarAlertNewOnClientButtonClicking">
            <Items>
                <telerik:RadToolBarButton SkinID="RadToolBarButtonSend" Text="Send" Value="Send" CommandName="Send" CausesValidation="false" ToolTip="Send Email and Alert Assignees"/>
                <telerik:RadToolBarButton SkinID="RadToolBarButtonSave" CommandName="SaveDraft" Text="Save Draft" Value="SaveDraft" CausesValidation="false" ToolTip="Save as Draft and do not send Email" />
                <telerik:RadToolBarButton CommandName="DeleteDraft" Text="Delete Draft" Value="DeleteDraft" CausesValidation="false" ToolTip="Delete this draft" Visible ="false" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonClear" Text="Clear" Value="Clear" CausesValidation="false" ToolTip="Clear" CommandName="Clear" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonCancel" Text="Cancel" CausesValidation="false" Value="Cancel" ToolTip="Cancel" CommandName="Cancel" />
            </Items>
        </telerik:RadToolBar>
    </div>
    <div class="telerik-aqua-body">
        <asp:RequiredFieldValidator ID="SubjectRequiredFieldValidator" runat="server" ControlToValidate="txtSubject" 
                ErrorMessage="Please enter a subject." EnableClientScript="true" SetFocusOnError="True"
                Enabled="True" Display="None"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="BodyRequiredFieldValidator" runat="server" ControlToValidate="BodyRadEditor"
                Display="None" ErrorMessage="Please enter a description." SetFocusOnError="True"
                Enabled="false"></asp:RequiredFieldValidator>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                ShowSummary="False" />
            <div style="width: 100%; vertical-align: top;">
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                    <div style="width: 49%; vertical-align: top; display: inline-block;">
                        <fieldset runat="server" id="FsAllowEmail">
                            <legend>Send</legend>
                            <table width="375" border="0" cellspacing="0" cellpadding="2">
                                <tr>
                                    <td>
                                        <asp:RadioButton ID="RadioEmail" runat="server" GroupName="EmailOrAlert" Text="Email"
                                            AutoPostBack="true" />
                                        <asp:RadioButton ID="RadioAlert" runat="server" GroupName="EmailOrAlert" Text="Alert"
                                            Checked="true" AutoPostBack="true" />
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                        <fieldset runat="server" id="FsAlertLevel">
                            <legend>Alert Level</legend>
                            <table width="550" border="0" cellspacing="0" cellpadding="2">
                                <tr>
                                    <td width="65">
                                        <asp:Label ID="Label2" runat="server" Text="Level:"></asp:Label>
                                    </td>
                                    <td colspan="2" style="padding-bottom: 3px">
                                        <telerik:RadComboBox ID="RadComboBoxAlertLevel" runat="server" AutoPostBack="true" SkinID="RadComboBoxStandard"
                                            TabIndex="-1" Width="200" CausesValidation="false">
                                            <Items>
                                            </Items>
                                        </telerik:RadComboBox>
                                        <asp:CheckBox ID="ChkIsAlertAssignment" runat="server" AutoPostBack="true" Text="Assignment"
                                            TabIndex="-1" />
                                        <asp:RequiredFieldValidator ID="AlertLevelRequiredFieldValidator" runat="server"
                                            ControlToValidate="RadComboBoxAlertLevel" Display="None" ErrorMessage="Please select a level to attach this alert to."
                                            SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr runat="Server" id="TrOffice">
                                    <td width="65">
                                        <asp:HyperLink ID="hlOffice" runat="server" href="" TabIndex="-1">Office:</asp:HyperLink>
                                    </td>
                                    <td width="100">
                                        <asp:TextBox ID="txtOffice" runat="server" Width="95px"></asp:TextBox>
                                    </td>
                                    <td width="310">
                                        <asp:TextBox ID="TxtOfficeDescription" runat="server" ReadOnly="true" TabIndex="-1" Text="" Width="270px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="OfficeRequiredFieldValidator" runat="server" ControlToValidate="txtOffice"
                                            Display="None" ErrorMessage="Please select an office." SetFocusOnError="True"></asp:RequiredFieldValidator>                               
                                    </td>
                                </tr>
                                <tr id="TrClient" runat="Server">
                                    <td width="65">
                                        <asp:HyperLink ID="hlClient" runat="server" href="" TabIndex="-1">Client:</asp:HyperLink>
                                    </td>
                                    <td width="100">
                                        <asp:TextBox ID="txtClient" runat="server" Width="95px"></asp:TextBox>
                                    </td>
                                    <td width="310">
                                        <asp:TextBox ID="TextBoxClientDescription" runat="server" ReadOnly="true" TabIndex="-1" Text="" Width="270px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="ClientRequiredFieldValidator" runat="server" ControlToValidate="txtClient"
                                            Display="None" ErrorMessage="Please select a client." SetFocusOnError="True"></asp:RequiredFieldValidator>                             
                                    </td>
                                </tr>
                                <tr id="TrDivision" runat="Server">
                                    <td width="65">
                                        <asp:HyperLink ID="hlDivision" runat="server" href="" TabIndex="-1">Division:</asp:HyperLink>
                                    </td>
                                    <td width="100">
                                        <asp:TextBox ID="txtDivision" runat="server" Width="95px"></asp:TextBox>
                                    </td>
                                    <td width="310">
                                        <asp:TextBox ID="TextBoxDivisionDescription" runat="server" ReadOnly="true" TabIndex="-1" Text="" Width="270px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="DivisionRequiredFieldValidator" runat="server" ControlToValidate="txtDivision"
                                            Display="None" ErrorMessage="Please select a division" SetFocusOnError="True"></asp:RequiredFieldValidator>  
                                    </td>
                                </tr>
                                <tr runat="Server" id="TrProduct">
                                    <td>
                                        <asp:HyperLink ID="hlProduct" runat="server" href="" TabIndex="-1">Product:</asp:HyperLink>
                                    </td>
                                    <td width="100">
                                        <asp:TextBox ID="txtProduct" runat="server" Width="95px"></asp:TextBox>
                                    </td>
                                    <td width="310">
                                        <asp:TextBox ID="TextBoxProductDescription" runat="server" ReadOnly="true" TabIndex="-1" Text="" Width="270px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="ProductRequiredFieldValidator" runat="server" ControlToValidate="txtProduct"
                                            Display="None" ErrorMessage="Please select a product." SetFocusOnError="True"></asp:RequiredFieldValidator>        
                                    </td>
                                </tr>
                                <tr id="TrCampaign" runat="Server">
                                    <td width="65">
                                        <asp:HyperLink ID="hlCampaign" runat="server" href="" TabIndex="-1">Campaign:</asp:HyperLink>
                                    </td>
                                    <td width="100">
                                        <asp:TextBox ID="txtCampaign" runat="server" Width="95px"></asp:TextBox>
                                    </td>
                                    <td width="310">
                                        <asp:TextBox ID="TextBoxCampaignDescription" runat="server" ReadOnly="true" TabIndex="-1" Text="" Width="270px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="CampaignRequiredFieldValidator" runat="server" ControlToValidate="txtCampaign"
                                            Display="None" ErrorMessage="Please select a campaign." SetFocusOnError="True"></asp:RequiredFieldValidator>    
                                    </td>
                                </tr>
                                <tr id="TrJob" runat="Server">
                                    <td width="65">
                                        <asp:HyperLink ID="hlJob" runat="server" href="" TabIndex="-1">Job:</asp:HyperLink>
                                    </td>
                                    <td width="100">
                                        <asp:TextBox ID="txtJob" runat="server" Width="95px"></asp:TextBox>
                                    </td>
                                    <td width="310">
                                        <asp:TextBox ID="TextBoxJobDescription" runat="server" ReadOnly="true" TabIndex="-1" Text="" Width="270px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="JobRequiredFieldValidator" runat="server" ControlToValidate="txtJob"
                                            Display="None" ErrorMessage="Please select a job." SetFocusOnError="True"></asp:RequiredFieldValidator>                  
                                    </td>
                                </tr>
                                <tr id="TrComponent" runat="Server">
                                    <td width="65">
                                        <asp:HyperLink ID="hlComponent" runat="server" href="" TabIndex="-1">Component:</asp:HyperLink>
                                    </td>
                                    <td width="100">
                                        <asp:TextBox ID="txtComponent" runat="server" Width="95px" OnBlur="GetDefaultAssignment();"></asp:TextBox>
                                    </td>
                                    <td width="310">
                                        <asp:TextBox ID="TextBoxComponentDescription" runat="server" ReadOnly="true" TabIndex="-1" Text="" Width="270px"></asp:TextBox>
                                        <asp:ImageButton ID="ImageButtonContacts" runat="server" SkinID="ImageButtonClientContact" TabIndex="-1"
                                            CausesValidation="False" />
                                        <asp:RequiredFieldValidator ID="ComponentRequiredFieldValidator" runat="server" ControlToValidate="txtComponent"
                                            Display="None" ErrorMessage="Please select a job component." SetFocusOnError="True"></asp:RequiredFieldValidator>                        
                                    </td>
                                </tr>
                                <tr id="TrEstimateNumber" runat="Server">
                                    <td width="65">
                                        <asp:HyperLink ID="HlEstimateNumber" runat="server" href="" TabIndex="-1">Estimate:</asp:HyperLink>
                                    </td>
                                    <td width="100">
                                        <asp:TextBox ID="TxtEstimateNumber" runat="server" Width="95px" ReadOnly="true"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBoxEstimateDescription" runat="server" ReadOnly="true" TabIndex="-1" Text="" Width="270px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr id="TrEstimateComponentNbr" runat="Server">
                                    <td width="65">
                                        <asp:HyperLink ID="HlEstimateComponentNbr" runat="server" href="" TabIndex="-1">Component:</asp:HyperLink>
                                    </td>
                                    <td width="100">
                                        <asp:TextBox ID="TxtEstimateComponentNbr" runat="server" Width="95px" ReadOnly="true"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBoxEstimateComponentDescription" runat="server" ReadOnly="true" TabIndex="-1" Text="" Width="270px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr id="TrPurchaseOrder" runat="Server">
                                    <td width="65">PO Number:
                                    </td>
                                    <td width="100">
                                        <asp:Label ID="LblPoNumber" runat="server" Text="&nbsp;"></asp:Label>&nbsp;-&nbsp;
                                        <asp:Label ID="LblPoDescription" runat="server" Text="&nbsp;"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label4" runat="server" Text="&nbsp;"></asp:Label>
                                    </td>
                                </tr>
                                <tr id="TrMediaATB" runat="Server">
                                    <td width="65">
                                        <asp:HyperLink ID="hlMediaATB" runat="server" href="" TabIndex="-1">ATB:</asp:HyperLink>
                                    </td>
                                    <td width="100">
                                        <asp:TextBox ID="txtMediaATB" runat="server" Width="95px" CssClass="RequiredInput" ReadOnly="true"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBoxATBDescription" runat="server" ReadOnly="true" TabIndex="-1" Text="" Width="270px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="MediaATBRequiredFieldValidator" runat="server" ControlToValidate="txtMediaATB"
                                            Display="None" ErrorMessage="Please select an ATB" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr id="TrMediaATBRev" runat="Server">
                                    <td width="65">
                                        <asp:HyperLink ID="hlMediaATBRev" runat="server" href="" TabIndex="-1">Revision:</asp:HyperLink>
                                    </td>
                                    <td width="100">
                                        <asp:TextBox ID="txtMediaATBRev" runat="server" Width="95px" CssClass="RequiredInput" ReadOnly="true"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBoxATBRevDescription" runat="server" ReadOnly="true" TabIndex="-1" Text="" Width="270px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="MediaATBRevRequiredFieldValidator" runat="server" ControlToValidate="txtMediaATBRev"
                                            Display="None" ErrorMessage="Please enter a revision." SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                        <fieldset runat="server" id="FieldsetBoardSprint" visible="false" style="margin-top: 8px;">
                            <legend></legend>
                            <table style="width: 100%;">
                                    <tr>
                                        <td style="width: 65px; padding: 2px;">Board:</td>
                                        <td style="padding: 2px;">
                                            <telerik:RadComboBox ID="RadComboBoxBoard" runat="server" Width="100%" AutoPostBack="true" CausesValidation="false" SkinID="RadComboBoxStandard"></telerik:RadComboBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 65px; padding: 2px;">Sprint:</td>
                                        <td style="padding: 2px;">
                                            <telerik:RadComboBox ID="RadComboBoxSprint" runat="server" Width="100%" AutoPostBack="true" CausesValidation="false" SkinID="RadComboBoxStandard"></telerik:RadComboBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 65px; padding: 2px;">State:</td>
                                        <td style="padding: 2px;">
                                            <telerik:RadComboBox ID="RadComboBoxBoardState" runat="server" Width="100%" CausesValidation="false" SkinID="RadComboBoxStandard"></telerik:RadComboBox>
                                        </td>
                                    </tr>
                                </table>
                        </fieldset>
                        <fieldset runat="server" id="FsAlertRecipients">
                            <legend>
                                <asp:Label ID="LabelRecipients" runat="server" Text="Alert Recipients:"></asp:Label></legend>
                                <div style="width: 100%;">
                                    <div id="TrButtons" runat="Server" style="margin-bottom:5px;">
                                        <asp:Button ID="BtnSelectRecipients" runat="server" CausesValidation="False" Text="Select" />
                                        <asp:Button ID="BtnClearSelections" runat="server" CausesValidation="False" Text="Clear" />
                                    </div>
                                    <div id="TrRadioNotify" runat="Server" style="margin-bottom: 5px;">
                                        <asp:RadioButton ID="RadioNotifyAlertGroup" runat="server" AutoPostBack="true" Text="Notify Alert Group"
                                            Checked="false" GroupName="SendTo" />
                                        <asp:RadioButton ID="RadioNotifyEmployeesTask" runat="server" AutoPostBack="True"
                                            Text="Notify Employees(Task)" Checked="false" GroupName="SendTo" />
                                        <asp:RadioButton ID="RadioNotifyEmployeesAssigned" runat="server" AutoPostBack="true"
                                            Checked="false" GroupName="SendTo" Text="Notify Assigned" />
                                        <br />
                                        <asp:RadioButton ID="RadioNotifyNext" runat="server" AutoPostBack="true" GroupName="SendTo"
                                            Checked="false" Text="Notify Next" />
                                    </div>
                                    <div id="TrRecipients" runat="Server">
                                        <custom:AutoCompleteAlertRecipient runat="server" ID="AutoCompleteRecipients" Visible="true" />
                                    </div>
                                </div>
                        </fieldset>
                        <fieldset runat="server" id="FieldsetCopyOptions" visible="false">
                            <legend>Copy Options:</legend>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr id="trCopyOptions" runat="Server">
                                    <td valign="top">
                                        <asp:CheckBox ID="CheckBoxCopyComments" runat="server" Text="Copy Comments" />
                                        <asp:CheckBox ID="CheckBoxCopyAttachments" runat="server" Text="Copy Attachments" />
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                    </div>
                    <div style="width: 49%; vertical-align: top; display: inline-block;">
                        <fieldset runat="server" id="FsAlertAssignments">
                            <legend>Assignment:</legend>
                            <table align="center" width="100%" border="0" cellspacing="2" cellpadding="0">
                                <tr>
                                    <td align="left" valign="bottom">Workflow Template:
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top">
                                        <telerik:RadComboBox ID="RadComboBoxAlertAssignmentTemplate" runat="server" AutoPostBack="true" SkinID="RadComboBoxStandard"
                                            TabIndex="990" Width="375" CausesValidation="false">
                                            <Items>
                                            </Items>
                                        </telerik:RadComboBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="bottom">State:
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top">
                                        <telerik:RadTreeView ID="RadTreeViewStates" runat="server" autopostback="True" CausesValidation="False"
                                            TabIndex="991" CheckBoxes="False" ShowLineImages="False" Height="250" Width="375">
                                            <Nodes>
                                            </Nodes>
                                        </telerik:RadTreeView>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="bottom">Assign To:
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top">
                                        <telerik:RadComboBox ID="RadComboBoxAssignTo" runat="server" AutoPostBack="false" SkinID="RadComboBoxStandard"
                                            TabIndex="992" Width="375" CausesValidation="false" EnableLoadOnDemand="True"
                                            ShowMoreResultsBox="true" ItemsPerRequest="7"
                                            EnableVirtualScrolling="true">
                                            <Items>
                                            </Items>
                                        </telerik:RadComboBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:CheckBox ID="CheckBoxShowAllAssignmentEmployees" runat="server" Text="Show all employees" AutoPostBack="true" />
                                    </td>
                                </tr>
                                <tr style="display: none !important;">
                                    <td align="left" valign="top">
                                        <asp:CheckBox ID="CheckBoxEmailAssignmentOrigintorOverride_DontEmailMe" runat="server"
                                            AutoPostBack="True" Text="Don't email me" />
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                        <fieldset runat="server" id="FsEmailRecipients">
                            <legend>Email Recipients:</legend>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr id="TrEmailTo" runat="Server">
                                    <td valign="top">
                                        <asp:LinkButton ID="LinkButtonEmailRecipientsTO" runat="server" Text="To:"></asp:LinkButton><br />
                                        <asp:TextBox ID="TxtEmailTo" runat="server" TextMode="MultiLine" Width="350px" Height="50px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr id="TrEmailCC" runat="Server">
                                    <td valign="top">
                                        <asp:LinkButton ID="LinkButtonEmailRecipientsCC" runat="server" Text="Cc:"></asp:LinkButton><br />
                                        <asp:TextBox ID="TxtEmailCC" runat="server" TextMode="MultiLine" Width="350px" Height="50px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr id="TrEmalBCC" runat="Server">
                                    <td valign="top">
                                        <asp:LinkButton ID="LinkButtonEmailRecipientsBCC" runat="server" Text="Bcc:"></asp:LinkButton><br />
                                        <asp:TextBox ID="TxtEmailBCC" runat="server" TextMode="MultiLine" Width="350px" Height="50px"></asp:TextBox>
                                        <br />
                                        *&nbsp;&nbsp;Separate email addresses with a comma (,)
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                    </div>
                    <div>
                        <fieldset runat="server" id="FsHeaderDetails">
                            <legend>Details
                                <asp:ImageButton ID="ImageButtonRefreshDetails" runat="server" SkinID="ImageButtonRefresh" CausesValidation="false" />
                            </legend>
                            <table id="Table1" border="0" cellpadding="2" cellspacing="2" width="100%">
                                <tr>
                                    <td width="15%" align="right" valign="top" style="width: 100px;">
                                        <asp:Label ID="LblCategory" runat="server" Text="Category: "></asp:Label>
                                    </td>
                                    <td width="10%" valign="top" style="vertical-align: top;">
                                        <telerik:RadComboBox ID="RadComboBoxCategory" runat="server" Width="150" CausesValidation="false" SkinID="RadComboBoxStandard">
                                            <Items>
                                            </Items>
                                        </telerik:RadComboBox>
                                    </td>
                                    <td width="75%" valign="top" style="vertical-align: top;">
                                        <asp:CheckBox ID="ChkExcludeAttachmentFromEmail" runat="server" Text="Exclude attachment from Email" />
                                        <asp:CheckBox ID="CheckBoxUploadDocumentsToJob" runat="server" Text="Upload Documents to Job" Visible="false" />
                                        <asp:CheckBox ID="ChkIncludeProjectScheduleReport" runat="server" Text="Include Schedule PDF"
                                            Visible="false" />
                                        <asp:CheckBox ID="CheckBoxIncludeProjectScheduleInHTML" runat="server" Text="Include Schedule in email"
                                            Visible="false" />
                                        <asp:CheckBox ID="CheckBoxIncludeEstimateHtml" runat="server" Text="Include HTML Info in Email?"
                                            Visible="false" />

                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 100px;" valign="top">Priority:
                                    </td>
                                    <td colspan="2" valign="top">
                                        <telerik:RadComboBox ID="RadComboBoxPriority" runat="server" Width="100" CausesValidation="false" SkinID="RadComboBoxStandard">
                                            <Items>
                                            </Items>
                                        </telerik:RadComboBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 100px;" valign="top">Start Date:
                                    </td>
                                    <td colspan="2" valign="top">
                                        <telerik:RadDatePicker ID="RadDatePickerStartDate" runat="server"
                                            SkinID="RadDatePickerStandard">
                                            <DateInput DateFormat="d" EmptyMessage="Start Date">
                                                <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                                            </DateInput>
                                            <Calendar ID="CalendarStartDate" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                                            </Calendar>
                                        </telerik:RadDatePicker>
                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Label ID="LblDueDate" runat="server" Text="Due Date: "></asp:Label>
                                       <telerik:RadDatePicker ID="RadDatePickerDueDate" runat="server"
                                            SkinID="RadDatePickerStandard">
                                            <DateInput DateFormat="d" EmptyMessage="Due Date">
                                                <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                                            </DateInput>
                                            <Calendar ID="CalendarDueDate" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                                            </Calendar>
                                        </telerik:RadDatePicker>
                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Label ID="LblTimeDue" runat="server" Text="Time Due: "></asp:Label>
                                        <asp:TextBox ID="TxtTimeDue" runat="server" TabIndex="0" Enabled="true" MaxLength="10"
                                            Text="" SkinID="TextBoxCodeSmall"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr runat="server" id="TrVersionAndBuild">
                                    <td align="right" style="width: 100px;" valign="middle">Version:
                                    </td>
                                    <td colspan="2" valign="middle">
                                        <telerik:RadComboBox ID="RadComboBoxVersion" runat="server" AutoPostBack="true" CausesValidation="false" SkinID="RadComboBoxStandard"
                                            Width="200">
                                        </telerik:RadComboBox>
                                        &nbsp;&nbsp;&nbsp;&nbsp;Build:&nbsp;&nbsp;
                                        <telerik:RadComboBox ID="RadComboBoxBuild" Width="200" CausesValidation="false" runat="server" SkinID="RadComboBoxStandard">
                                        </telerik:RadComboBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 100px; padding-top: 2px" valign="top">Subject:
                                    </td>
                                    <td colspan="2" valign="top"  style="padding-top: 2px">
                                        <asp:TextBox ID="txtSubject" runat="server" AutoCompleteType="Disabled" CssClass="RequiredInput"
                                            Width="90%"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                        <fieldset runat="server" id="FsDescription">
                            <legend>Description</legend>
                            <telerik:RadEditor ID="BodyRadEditor" runat="server" Height="310" ToolsFile="~/RadEditorToolbars.xml" NewLineBr="true" NewLineMode="Br" OnClientLoad="RadEditorOnClientLoad" StripFormattingOptions="MsWord"
                                ContentAreaCssFile="~/CSS/RadEditorContentArea.min.css" Width="90%" EditModes="Design" ToolbarMode="ShowOnFocus" OnClientCommandExecuted="RadEditorOnClientCommandExecuted">
                            </telerik:RadEditor>
                            <script type="text/javascript">
                                Telerik.Web.UI.Editor.Utils.containsHtmlAtClipboard = function (event) {
                                    return false;
                                }
                            </script>
                        </fieldset>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
                <fieldset runat="server" id="FsAttachmentsAndLinks">
                    <legend>
                        <asp:Label ID="LabelAttachment" runat="server">Add Attachments/Link&nbsp;</asp:Label><asp:ImageButton ID="ImageButtonHelpFileSelection" runat="server" SkinID="ImageButtonQuestion" OnClientClick="OpenRadWindow('Selecting files for upload','Help_FileSelection.aspx');return false;" />
                    </legend>
                    <div id="DivDraftAttachments" runat="server">
                        <telerik:RadGrid ID="RadGridDraftAttachemnts" runat="server" AllowPaging="False" AllowSorting="True"
                            AutoGenerateColumns="False" GridLines="None" PageSize="25" EnableEmbeddedSkins="True"
                            Width="100%">
                            <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom"></PagerStyle>
                            <MasterTableView DataKeyNames="ATTACHMENT_ID">
                                <Columns>
                                    <telerik:GridTemplateColumn UniqueName="TemplateColumn">
                                        <HeaderStyle CssClass="radgrid-icon-column" />
                                        <ItemStyle CssClass="radgrid-icon-column" />
                                        <FooterStyle CssClass="radgrid-icon-column" />
                                        <ItemTemplate>
                                            <div id="DivDocumentType" runat="server" class="icon-background background-color-sidebar">
                                                <asp:LinkButton ID="LinkButtonDocumentType" runat="server" Text="" ToolTip="" CommandName="Download" CssClass="icon-text" CommandArgument='<%# Eval("DOCUMENT_ID")%>'></asp:LinkButton>
                                            </div>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Filename" SortExpression="FILENAME" UniqueName="FilenameTemplateColumn">
                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                        <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButtonDownload" runat="server"></asp:LinkButton>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn DataField="FILE_SIZE_KB" SortExpression="FILE_SIZE" HeaderText="Size"
                                        UniqueName="SizeColumn">
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="55" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="55" />
                                        <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="55" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="USER_NAME" SortExpression="USER_NAME" HeaderText="Added By" Visible="false"
                                        UniqueName="column1">
                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="120" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="120" />
                                        <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="120" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="GENERATED_DATE" DataFormatString="{0:g}" HeaderText="Added"
                                        SortExpression="GENERATED_DATE" UniqueName="column2">
                                        <HeaderStyle CssClass="radgrid-datetime-column" />
                                        <ItemStyle CssClass="radgrid-datetime-column" />
                                        <FooterStyle CssClass="radgrid-datetime-column" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="USER_CODE" UniqueName="column11" Visible="False">
                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="20" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="20" />
                                        <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="20" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn HeaderText="Private" UniqueName="colChkPrivate" SortExpression="PRIVATE_FLAG" Visible="false">
                                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <FooterStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkPrivate" runat="server" Checked='<%# Eval("PRIVATE_FLAG") %>'
                                                Enabled="false" />
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn UniqueName="GridTemplateColumnAddComments" Visible="false">
                                        <HeaderStyle CssClass="radgrid-icon-column" />
                                        <ItemStyle CssClass="radgrid-icon-column" />
                                        <FooterStyle CssClass="radgrid-icon-column" />
                                        <ItemTemplate>
                                            <div id="DivAddComments" runat="server" class="icon-background background-color-sidebar">
                                                <asp:ImageButton ID="ImageButtonAddComments" runat="server" SkinID="ImageButtonCommentWhite" ToolTip="Click to add comment to this document" />
                                            </div>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn UniqueName="GridTemplateColumnDigitallySign" Visible="false">
                                        <HeaderStyle CssClass="radgrid-icon-column" />
                                        <ItemStyle CssClass="radgrid-icon-column" />
                                        <FooterStyle CssClass="radgrid-icon-column" />
                                        <ItemTemplate>
                                            <div id="DivDigitallySign" runat="server" class="icon-background background-color-sidebar">
                                                <asp:LinkButton ID="LinkButtonDigitallySign" runat="server" Text="S" ToolTip="Click to digitally sign this PDF" CssClass="icon-text" CommandName="SignDocument" CommandArgument='<%# Eval("DOCUMENT_ID")%>' />
                                            </div>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn UniqueName="HistoryTemplateColumn" Visible="false">
                                        <HeaderStyle CssClass="radgrid-icon-column" />
                                        <ItemStyle CssClass="radgrid-icon-column" />
                                        <FooterStyle CssClass="radgrid-icon-column" />
                                        <ItemTemplate>
                                            <div id="DivDocumentHistory" runat="server" class="icon-background background-color-sidebar">
                                                <asp:LinkButton ID="LinkButtonDocumentHistory" runat="server" Text="H" ToolTip="Show document history" CommandName="ShowHistory" CssClass="icon-text" CommandArgument='<%# Eval("DOCUMENT_ID")%>'></asp:LinkButton>
                                            </div>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn UniqueName="GridTemplateColumnProofHQ" Visible="false">
                                        <HeaderStyle CssClass="radgrid-icon-column" />
                                        <ItemStyle CssClass="radgrid-icon-column" />
                                        <FooterStyle CssClass="radgrid-icon-column" />
                                        <ItemTemplate>
                                            <div id="DivProofHQ" runat="server" class="icon-background background-color-sidebar">
                                                <asp:LinkButton ID="LinkButtonProofHQ" runat="server" Text="PHQ" ToolTip="Proof HQ" CssClass="icon-text-three"></asp:LinkButton>
                                            </div>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn UniqueName="GridTemplateColumnDelete">
                                        <HeaderStyle CssClass="radgrid-icon-column" />
                                        <ItemStyle CssClass="radgrid-icon-column" />
                                        <FooterStyle CssClass="radgrid-icon-column" />
                                        <ItemTemplate>
                                            <div class="icon-background background-color-delete">
                                                <asp:ImageButton ID="ImageButtonDelete" runat="server" SkinID="ImageButtonDeleteWhite" ToolTip="Click to delete this row" CommandName="DeleteRow" />
                                            </div>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                </Columns>
                                <ExpandCollapseColumn Visible="False">
                                    <HeaderStyle Width="19px" />
                                </ExpandCollapseColumn>
                                <RowIndicatorColumn Visible="False">
                                    <HeaderStyle Width="20px" />
                                </RowIndicatorColumn>
                            </MasterTableView>
                        </telerik:RadGrid>
                    </div>
                    <div id="DivRepositoryAndProofHQCheckBoxes" runat="server">
            <asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                            <asp:CheckBox ID="ChkUploadToRepository" Text="Upload to Document Manager" runat="server" />
                            <asp:CheckBox ID="CheckBoxUploadToProofHQ" runat="server" Text="Upload to Proof HQ" Enabled="false" Visible="false" />
                </ContentTemplate>
            </asp:UpdatePanel>
                    </div>
                    <div>
                        <telerik:RadAsyncUpload ID="RadUploadAlertDocuments" runat="server"
                            MultipleFileSelection="Automatic" InputSize="40">
                        </telerik:RadAsyncUpload>
                        <br />
                        <asp:Label ID="LabelFileSizeLimitMessage" runat="server" Text=""></asp:Label>
                    </div>
                    <div id="TrLinkDocuments" runat="server">
                        <hr />
            <asp:UpdatePanel runat="server" ID="UpdatePanel2" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                            To link an already uploaded file from the Document Manager, select from the list below.
                                <asp:ImageButton ID="ImageButtonRefreshLinkDocumentsListBox" runat="server" SkinID="ImageButtonRefresh" ToolTip="Click to fresh existing files list."
                                    CausesValidation="false" /><br />
                            <telerik:RadListBox ID="RadListBoxLinkableDocuments" runat="server" Width="500" SelectionMode="Multiple" Height="100"></telerik:RadListBox>
                </ContentTemplate>
            </asp:UpdatePanel>
                    </div>
                </fieldset>
            </div>
    </div>
    
</asp:Content>
