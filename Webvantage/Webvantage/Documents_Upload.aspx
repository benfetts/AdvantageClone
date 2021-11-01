<%@ Page Title="Upload a New Document" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="Documents_Upload.aspx.vb" Inherits="Webvantage.Documents_Upload" %>

<%@ Register Src="Alert_RecipientUC.ascx" TagName="AutoCompleteAlertRecipient" TagPrefix="custom" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
        <script type="text/javascript">

            function RadUploadDocumentOnClientFileSelected(sender, args) {

                var toolBar = $find("<%= RadToolbarDocumentUpload.ClientID%>");
                var button = toolBar.findItemByText("Upload");
                button.disable();

            };

            function RadUploadDocumentOnClientFileUploaded(sender, args) {

                var toolBar = $find("<%= RadToolbarDocumentUpload.ClientID%>");
                var button = toolBar.findItemByText("Upload");
                button.enable();

            };

            function RadUploadNumberOfFilesChanged() {
                var radUpload = $find("<%= RadUploadDocument.ClientID%>");
                var inputs = radUpload.getUploadedFiles();
                var descriptionReadOnly = true;
                var descriptionInput;
                if (inputs.length > 0) {
                    $("#DocOptions").show();
                    if ($("#<%= RadioButtonListDocOptions.ClientID%> input[type=radio]:checked").val() == 'Description') {
                        descriptionReadOnly = false;
                    }
                } else {
                    $("#DocOptions").hide();
                    descriptionReadOnly = false;
                }
                descriptionInput = document.getElementById("<%= TextBoxDescription.ClientID%>");
                descriptionInput.readOnly = descriptionReadOnly;
                if (descriptionReadOnly == true) {
                    descriptionInput.value = "";
                }
            };

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
                } else {
                    return false;
                }
            };

            function OnDocumentUploadButtonClientClick(sender, args) {
                var commandName = args.get_item().get_commandName();
                if (commandName == 'Upload') {
                    var uploadButton = args._item;
                    var combo = $find('<%=RadComboBoxDocumentType.ClientID %>');
                    if (combo.get_selectedItem().get_value() == 0) {
                        args.set_cancel(true);
                        ShowMessage("Please select a type");
                        return false;
                    } else {
                        uploadButton.disable();
                    }
                }
            };
        </script>
    </telerik:RadScriptBlock>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div class="no-float-menu">
        <telerik:RadToolBar ID="RadToolbarDocumentUpload" runat="server" Width="100%" OnClientButtonClicking="OnDocumentUploadButtonClientClick">
            <Items>
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonUpload" Text="Upload" Value="Upload" CommandName="Upload"
                    ToolTip="Upload this document" />
                <telerik:RadToolBarButton Text="Clear" SkinID="RadToolBarButtonClear" Value="Clear" CommandName="Clear"
                    ToolTip="Clear the upload form" />
                <telerik:RadToolBarButton IsSeparator="true" />
            </Items>
        </telerik:RadToolBar>
    </div>
   
    <div class="upload-container">
        <div class="code-description-container">
            <div class="code-description-label">
                I want to upload a:
            </div>
            <div class="code-description-description">
                <telerik:RadComboBox ID="RadComboBoxFileOrLink" runat="server" AutoPostBack="True" Width="175" SkinID="RadComboBoxStandard">
                    <Items>
                        <telerik:RadComboBoxItem Value="File" Text="File/Document"></telerik:RadComboBoxItem>
                        <telerik:RadComboBoxItem Value="Link" Text="Link"></telerik:RadComboBoxItem>
                    </Items>
                </telerik:RadComboBox>
            </div>
        </div>
        <div id="DivFile" runat="server" class="code-description-container">
            <div class="code-description-label" style="vertical-align:top !important;">
                File Details*:<asp:ImageButton ID="ImageButtonHelpFileSelection" runat="server" SkinID="ImageButtonQuestion" OnClientClick="OpenRadWindow('Selecting files for upload','Help_FileSelection.aspx');return false;" />
            </div>
            <div style="display:inline-block;">
                <telerik:RadAsyncUpload ID="RadUploadDocument" runat="server" PostbackTriggers="RadToolbarDocumentUpload"
                    MultipleFileSelection="Automatic"
                    InputSize="52" OnClientFileUploaded="RadUploadNumberOfFilesChanged" OnClientFileUploadRemoved="RadUploadNumberOfFilesChanged">
                </telerik:RadAsyncUpload>
                <div style="font-size: small;">Browse to a file on your local hard drive or a network folder.</div>
                <div style="font-size: small;">
                    <asp:Label ID="LabelFileSizeLimitMessage" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </div>
        <div id="DivLinkName" runat="server" class="code-description-container">
            <div class="code-description-label">
                Link Name:
            </div>
            <div class="code-description-description">
                <asp:TextBox ID="TextBoxLinkName" runat="server" SkinID="TextBoxCodeSingleLineDescription" CssClass="RequiredInput"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorLinkName" runat="server" ControlToValidate="TextBoxLinkName"
                    ErrorMessage="<br/>Required" SetFocusOnError="True" ValidationGroup="Link"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div id="DivLinkURL" runat="server" class="code-description-container">
            <div class="code-description-label" style="vertical-align: top !important;">
                Link URL:
            </div>
            <div class="code-description-description">
                <asp:TextBox ID="TextBoxURL" runat="server" SkinID="TextBoxCodeSingleLineDescription" CssClass="RequiredInput"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RequiredFieldValidatorLinkURL" runat="server" ControlToValidate="TextBoxURL"
                    ErrorMessage="Required" SetFocusOnError="True" ValidationGroup="Link"></asp:RequiredFieldValidator>
                <div style="font-size: small;">Copy and Paste a URL here to create a link.</div>
            </div>
        </div>
        <div class="code-description-container">
            <div class="code-description-label">
                File Type:
            </div>
            <div class="code-description-description">
                <telerik:RadComboBox ID="RadComboBoxDocumentType" runat="server" Width="395" CssClass="RequiredInput" SkinID="RadComboBoxStandard">
                </telerik:RadComboBox>
            </div>
        </div>
        <div class="code-description-container">
            <div class="code-description-label">
                Private?
            </div>
            <div class="code-description-description">
                <asp:CheckBox ID="cbPrivate" runat="server" Text="" />
            </div>
        </div>
        <div id="DocOptions" style="display: none;" class="code-description-container">
            <div class="code-description-label">
            </div>
            <div class="code-description-description">
                <asp:RadioButtonList ID="RadioButtonListDocOptions" runat="server" Visible="true" RepeatDirection="Vertical" onclick="RadUploadNumberOfFilesChanged()">
                    <asp:ListItem Value="FileName" Text="Use file name for the description" Selected="True" />
                    <asp:ListItem Value="Description" Text="Use same description for all files" Selected="False" />
                </asp:RadioButtonList>
            </div>
        </div>
        <div class="code-description-container">
            <div class="code-description-label" style="vertical-align: top !important;">
                Description:
            </div>
            <div class="code-description-description">
                <asp:TextBox ID="TextBoxDescription" runat="server" TextMode="SingleLine" SkinID="TextBoxCodeSingleLineDescription"
                    MaxLength="200"></asp:TextBox>
                <p style="font-size:small; padding: 4px 0; margin: 0;">Describe the file or link you are adding.</p>
            </div>
        </div>
        <div class="code-description-container">
            <div class="code-description-label" style="vertical-align: top !important;">
                Keywords:
            </div>
            <div class="code-description-description">
                <asp:TextBox ID="TextBoxKeywords" runat="server" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                <p style="font-size: small; padding: 4px 0; margin: 0;">Add any keywords that may help someone find this document later.</p>
            </div>
        </div>
        <div class="code-description-container">
            <div class="code-description-label" style="vertical-align: top !important;">
                Labels:
            </div>
            <div class="code-description-description">
                <telerik:RadComboBox ID="RadComboBoxLabels" runat="server" CheckBoxes="true" AllowCustomText="false" MarkFirstMatch="false" Width="395" SkinID="RadComboBoxStandard"></telerik:RadComboBox>
                <p style="font-size: small; padding: 4px 0; margin: 0;">Organize your upload with labels.</p>
            </div>
        </div>
        <div class="code-description-container">
            <div class="code-description-label">
            </div>
            <div class="code-description-description">
            </div>
        </div>
        <div id="DivSendAlert" runat="server">
            <div style="border-bottom: 1px solid #cecece;margin-bottom:15px;">
                Send Alert
            </div>
            <div class="code-description-container">
                <div class="code-description-label">
                </div>
                <div class="code-description-description">
                    <asp:Button ID="ButtonAddRecipients" runat="server" CausesValidation="False" Text="Select Recipients"
                        UseSubmitBehavior="False" />
                    <asp:Button ID="ButtonClearRecipients" runat="server" CausesValidation="False" Text="Clear Recipients"
                        UseSubmitBehavior="False" />
                </div>
            </div>
            <div class="code-description-container">
                <div class="code-description-label">
                    Recipients:
                </div>
                <div class="code-description-description">
                    <custom:AutoCompleteAlertRecipient runat="server" ID="AutoCompleteRecipients" Visible="true" />
                </div>
            </div>
            <div class="code-description-container">
                <div class="code-description-label">
                    Subject:
                </div>
                <div class="code-description-description">
                    <asp:TextBox ID="TextBoxSubject" runat="server" MaxLength="254" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                </div>
            </div>
            <div class="code-description-container">
                <div class="code-description-label">
                    Category:
                </div>
                <div class="code-description-description">
                    <telerik:RadComboBox ID="DropDownListCategory" runat="server" Width="110" SkinID="RadComboBoxStandard">
                    </telerik:RadComboBox>
                    &nbsp;&nbsp;Priority:
                    <telerik:RadComboBox ID="DropDownListPriority" runat="server" Width="100px" SkinID="RadComboBoxStandard">
                    </telerik:RadComboBox>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
