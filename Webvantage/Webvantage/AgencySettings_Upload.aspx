<%@ Page Title="Upload" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="AgencySettings_Upload.aspx.vb" Inherits="Webvantage.AgencySettings_Upload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <style type="text/css">
        input.RadUploadSubmit {
            /*margin-top: 20px;*/
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <telerik:RadProgressManager ID="Radprogressmanager1" runat="server"></telerik:RadProgressManager>
    <table cellpadding="0" cellspacing="4" border="0" width="100%">
        <tr>
            <td>
                <h4 style="margin-bottom: 4px">
                    <asp:Label ID="LabelHeader" runat="server" Text=""></asp:Label>&nbsp;<asp:ImageButton ID="ImageButtonHelpFileSelection" runat="server" SkinID="ImageButtonQuestion" OnClientClick="OpenRadWindow('Selecting files for upload','Help_FileSelection.aspx');return false;" /></h4>
                <telerik:RadAsyncUpload ID="RadUploadAgencyImage" runat="server" AutoAddFileInputs="false"
                    AllowedFileExtensions=".jpg,.jpeg,.gif,.png,.bmp"
                    ControlObjectsVisibility="None" InitialFileInputsCount="1" MultipleFileSelection="Disabled"
                    EnableFileInputSkinning="true" MaxFileInputsCount="1" InputSize="40">
                </telerik:RadAsyncUpload>
                <asp:Label ID="LabelFilesizeWarning" runat="server" Text="" CssClass="smallFont"></asp:Label>
                <br />
                <asp:Label ID="LabelFiletypes" runat="server" Text="** Allowed file types:  .jpg, .jpeg, .gif, .png, .bmp" CssClass="smallFont"></asp:Label>
                <telerik:RadProgressArea ID="RadProgressArea1" runat="server">
                </telerik:RadProgressArea>
                <br />
                <asp:Button ID="ButtonUpload" runat="server" Text="Upload" />
                <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" />
            </td>
        </tr>
    </table>
</asp:Content>