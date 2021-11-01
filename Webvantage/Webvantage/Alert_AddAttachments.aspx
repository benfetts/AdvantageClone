<%@ Page Title="Add Attachments" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="Alert_AddAttachments.aspx.vb" Inherits="Webvantage.Alert_AddAttachments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div style="margin: 10px 0px 0px 0px;">
        <div id="DivUploadAttachments" runat="server" style="margin: 6px 0px 0px 0px;">
            <div style="display: none !important;">
                Add new files:
                <asp:LinkButton ID="LinkButtonHelpFileSelection" style="display:none;" runat="server" OnClientClick="OpenRadWindow('Selecting files for upload','Help_FileSelection.aspx');return false;" ToolTip="Click for upload instructions">?</asp:LinkButton>
            </div>
            <telerik:RadAsyncUpload ID="RadUploadAlertDocuments" runat="server" MultipleFileSelection="Automatic" PostbackTriggers="ButtonUploadAttachments">
            </telerik:RadAsyncUpload>
            <div>
                <asp:Label ID="LabelFileSizeLimitMessage" runat="server" Text="" style="font-size: x-small; font-style:italic;"></asp:Label>
            </div>
        </div>
        <div id="DivLinkDocuments" runat="server" style="margin: 10px 0px 0px 0px;">
            <div>
                <asp:CheckBox ID="CheckBoxLinkExistingFile" runat="server" Text="Link an existing file?" AutoPostBack="true" ToolTip="Check the checkbox to display list of available files to link" /> 
            </div>
            <div id="DivLinkDocumentsRadListBox" runat="server">
                <telerik:RadListBox ID="RadListBoxLinkableDocuments" runat="server" Width="567" SelectionMode="Multiple" Height="150"></telerik:RadListBox>
            </div>
        </div>
        <div id="DivAttachmentComment" style="margin: 10px 0px 0px 0px;">
            <div>
                Add comment to attachment:
            </div>
            <div>
                <asp:TextBox ID="TextBoxAttachmentComment" runat="server" TextMode="MultiLine" Width="97%" Height="60" SkinID="TextBoxStandard"></asp:TextBox>
            </div>
        </div>
        <div style="margin: 15px 0px 0px 0px;">
            <asp:Button ID="ButtonUploadAttachments" runat="server" Text="Add Attachment" />
            <asp:CheckBox ID="ChkUploadToRepository" runat="server" Text="Upload to Document Manager" />
            <asp:CheckBox ID="CheckBoxUploadToProofHQ" runat="server" Text="Upload to Proof HQ" Enabled="false" Visible="false" />
        </div>
    </div>
</asp:Content>
