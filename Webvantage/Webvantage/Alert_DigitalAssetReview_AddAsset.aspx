<%@ Page Title="Add Review Asset" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="Alert_DigitalAssetReview_AddAsset.aspx.vb" Inherits="Webvantage.Alert_DigitalAssetReview_AddAsset" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <style>
        .cs-asset-container {
            display: inline-block;
            margin: 8px;
            border: 1px solid #cecece;
            padding: 2px;
            text-align:center;
            min-width: 105px;
        }
        .cs-asset-thumbnail-container {
            text-align:center !important;
            width: 105px;
        }
        .cs-asset-thumbnail {
            width: 100px !important;
            height: auto !important;
        }
        .cs-asset-filename {
            text-align:center;
            font-size: x-small;
        }
    </style>
    <script>
        function fnCheckUnCheck(objId) {
            var grd = document.getElementById("DivRepositoryThumbs"); 
            var rdoArray = grd.getElementsByTagName("input");
            if (rdoArray) {
                for(i=0;i<=rdoArray.length-1;i++) { 
                    if(rdoArray[i].type == 'radio') {
                        if(rdoArray[i].id != objId) { 
                            rdoArray[i].checked = false; 
                        } 
                    }
                }
            }
        }
        function zipOptionsChanged(checkBoxProcessZip) {
            $('#DivZipOptions').toggle();
        }
        function RadToolbarReviewAddAssetOnClientButtonClicking(sender, args) {
            var commandName = args.get_item().get_commandName();
            if (commandName) {
                switch (commandName) {
                    case "ZenDeskHelp":
                        OpenFloatingWindow("Upload Asset Help", "https://conceptshare.zendesk.com/hc/en-us/articles/213246827", 768, 1024, 0, 0)
                        args.set_cancel(true);
                        break;
                }
            }
        };
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div >
        <telerik:RadToolBar ID="RadToolbarReviewAddAsset" runat="server" Width="925px" OnClientButtonClicking="RadToolbarReviewAddAssetOnClientButtonClicking">
            <Items>
                <telerik:RadToolBarButton SkinID="RadToolBarButtonSave" Text="" Value="Upload" CommandName="Upload" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonQuestion" Text="" Value="ZenDeskHelp" CommandName="ZenDeskHelp" ToolTip="Guidelines for uploading assets" />
            </Items>
        </telerik:RadToolBar>
    </div>
    <div >
    </div>
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
        <div id="DivUploadAssetPanel" style="width: 99%; border-top: 0px solid #eeeeee; padding: 0px 0px 4px 4px; margin: 8px 0px 0px 0px;">
            <div>
                <asp:RadioButtonList ID="RadioButtonListUploadType" runat="server" AutoPostBack="true" CausesValidation="false" 
                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                    <asp:ListItem Text="File" Value="File" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="Document Repository" Value="DocumentRepository"></asp:ListItem>
                    <asp:ListItem Text="Capture Web Page" Value="CaptureWebPage"></asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <asp:MultiView ID="MultiViewUploadType" runat="server">
                <asp:View ID="ViewUploadFile" runat="server">
                    <div id="DivUploadAttachments" class="row-spacer">
                        <telerik:RadAsyncUpload ID="RadUploadAssets" runat="server" MultipleFileSelection="Disabled" MaxFileInputsCount="1" EnableInlineProgress="true" InputSize="45">
                        </telerik:RadAsyncUpload>
                        <asp:LinkButton ID="LinkButtonHelpFileSelection" runat="server" Visible="false" OnClientClick="OpenRadWindow('Selecting files for upload','Help_FileSelection.aspx');return false;" ToolTip="Click for upload instructions">?</asp:LinkButton>
                        <div style="display: none !important;">
                            <asp:Label ID="LabelFileSizeLimitMessage" runat="server" Text="" Style="font-size: smaller;"></asp:Label>
                        </div>
                    </div>
                    <div class="row-spacer" style="display:none !important;">
                        <asp:CheckBox ID="CheckBoxUploadToDocumentManager" runat="server" Text="Upload to Document Manager" Enabled ="false" Visible="false" />
                    </div>
                    <div class="row-spacer">
                        <asp:CheckBox ID="CheckBoxProcessZip" runat="server" Text="Process ZIP files as HTML5 assets and convert to video" CausesValidation="false" onclick="zipOptionsChanged(this);" />
                    </div>
                    <div id="DivZipOptions" style="display: none; margin-left: 30px;">
                        <div class="row-spacer">
                            <div style="width: 135px; display: inline-block;">
                                <div class="row-spacer">
                                    Duration (sec.)
                                </div>
                                <div class="row-spacer">
                                    <telerik:RadNumericTextBox ID="RadNumericTextBoxZipOptionsDuration" runat="server" Width="130" ShowSpinButtons="true" DisplayText="Optional" MinValue="0" IncrementSettings-Step="1" NumberFormat-DecimalDigits="0"></telerik:RadNumericTextBox>
                                </div>
                            </div>
                            <div style="width: 155px; display: inline-block;">
                                <div class="row-spacer">
                                    Capture Delay (sec.)
                                </div>
                                <div class="row-spacer">
                                    <telerik:RadNumericTextBox ID="RadNumericTextBoxZipOptionsCaptureDelay" runat="server" Width="130" ShowSpinButtons="true" DisplayText="Optional" MinValue="0" IncrementSettings-Step="1" NumberFormat-DecimalDigits="0"></telerik:RadNumericTextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-spacer">
                            <div style="width: 135px; display: inline-block;">
                                <div>
                                    Width (px)
                                </div>
                                <div>
                                    <telerik:RadNumericTextBox ID="RadNumericTextBoxZipOptionsWidth" runat="server" Width="130" ShowSpinButtons="true" DisplayText="Optional" MinValue="0" IncrementSettings-Step="1" NumberFormat-DecimalDigits="0"></telerik:RadNumericTextBox>
                                </div>
                            </div>
                            <div style="width: 135px; display: inline-block;">
                                <div>
                                    Height (px)
                                </div>
                                <div>
                                    <telerik:RadNumericTextBox ID="RadNumericTextBoxZipOptionsHeight" runat="server" Width="130" ShowSpinButtons="true" DisplayText="Optional" MinValue="0" IncrementSettings-Step="1" NumberFormat-DecimalDigits="0"></telerik:RadNumericTextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </asp:View>
                <asp:View ID="ViewUploadExisting" runat="server">
                    <div id="DivRepositoryThumbs">
                        <telerik:RadListView ID="RadListViewDocRepositoryThumbs" runat="server" RenderMode="Classic" ItemPlaceholderID="DocRepositoryThumbsContainer" DataKeyNames="DocumentID">
                            <ClientSettings AllowItemsDragDrop="false">
                                <ClientEvents></ClientEvents>
                            </ClientSettings>
                            <ItemTemplate>
                                <div class="cs-asset-container">
                                    <div style="text-align: center !important; font-size: x-small !important; text-overflow:ellipsis; margin-bottom: 4px;">
                                        <asp:Literal ID="LiteralAssetFilename" runat="server"></asp:Literal>
                                    </div>
                                    <div class="cs-asset-thumbnail-container">
                                        <asp:Image ID="ImageDocumentThumb" runat="server" CssClass="cs-asset-thumbnail" />
                                        <div id="DivDocumentType" runat="server" class="icon-background background-color-sidebar" style="text-align:center !important; margin-left:34px;padding-top: 2px;">
                                            <asp:Label ID="LabelDocumentType" runat="server" Text="" ToolTip="" CssClass="icon-text"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="cs-asset-filename">
                                        <asp:RadioButton ID="RadioButtonSelect" runat="server" onclick="fnCheckUnCheck(this.id);" />
                                        <asp:Literal ID="LiteralDocumentFilename" runat="server"></asp:Literal>
                                    </div>
                                </div>
                            </ItemTemplate>
                            <LayoutTemplate>
                                <asp:PlaceHolder ID="DocRepositoryThumbsContainer" runat="server"></asp:PlaceHolder>
                            </LayoutTemplate>
                            <GroupSeparatorTemplate>
                            </GroupSeparatorTemplate>
                            <EmptyDataTemplate>
                            </EmptyDataTemplate>
                        </telerik:RadListView>
                    </div>
                </asp:View>
                <asp:View ID="ViewCaptureWebPage" runat="server">
                    <div style="margin: 8px 0px 0px 0px;">
                        <table style="width: 100%;">
                            <tr>
                                <td style="text-align: right; width: 100px;">Title
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxCaptureWebPageTitle" runat="server" Width="90%" SkinID="TextBoxStandard"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right; width: 100px;">
                                    <telerik:RadComboBox ID="RadComboBoxCaptureWebPageWebAddressPrefix" runat="server" Width="90px" SkinID="RadComboBoxStandard">
                                        <Items>
                                            <telerik:RadComboBoxItem Text="http://" Value="http://" />
                                            <telerik:RadComboBoxItem Text="https://" Value="https://" />
                                        </Items>
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxCaptureWebPageWebAddress" runat="server" Width="90%" SkinID="TextBoxStandard"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <div id="DivCaptureWebPageOptions" runat="server" style="margin: 20px 0px 0px 50px;">
                            <div>
                                Optional:
                            </div>
                            <div style="margin: 0px 0px 0px 15px;">
                                <div>
                                    <div style="width: 135px; display: inline-block;">
                                        <div>
                                            Width (px)
                                        </div>
                                        <div>
                                            <telerik:RadNumericTextBox ID="RadNumericTextBoxCaptureWebPageOptionsWidth" runat="server" Width="130" ShowSpinButtons="true" DisplayText="Optional" MinValue="0" IncrementSettings-Step="1" NumberFormat-DecimalDigits="0"></telerik:RadNumericTextBox>
                                        </div>
                                    </div>
                                    <div style="width: 135px; display: inline-block;">
                                        <div>
                                            Height (px)
                                        </div>
                                        <div>
                                            <telerik:RadNumericTextBox ID="RadNumericTextBoxCaptureWebPageOptionsHeight" runat="server" Width="130" ShowSpinButtons="true" DisplayText="Optional" MinValue="0" IncrementSettings-Step="1" NumberFormat-DecimalDigits="0"></telerik:RadNumericTextBox>
                                        </div>
                                    </div>
                                </div>
                                <div>
                                    Capture Delay (sec.)
                                </div>
                                <div>
                                    <telerik:RadNumericTextBox ID="RadNumericTextBoxCaptureWebPageOptionsCaptureDelay" runat="server" Width="130" ShowSpinButtons="true" DisplayText="Optional" MinValue="0" IncrementSettings-Step="1" NumberFormat-DecimalDigits="0"></telerik:RadNumericTextBox>
                                </div>

                            </div>
                        </div>
                    </div>
                </asp:View>
            </asp:MultiView>
        </div>
                </ContentTemplate>
            </asp:UpdatePanel>
</asp:Content>
