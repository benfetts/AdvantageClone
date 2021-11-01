<%@ Page Title="Document Details" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="Document_Edit.aspx.vb" Inherits="Webvantage.Document_Edit" %>
<%@ Register Src="~/Document_Label_Tree.ascx" TagPrefix="wv" TagName="Document_Label_Tree" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div style="margin-left: auto; margin-right: auto; left: 0; right: 0; text-align: center;">
        <telerik:RadToolBar ID="RadToolbarDocumentInfo" runat="server" Width="100%">
                <Items>
                    <telerik:RadToolBarButton SkinID="RadToolBarButtonSave" Value="Save" CommandName="Save" />
                    <telerik:RadToolBarButton SkinID="RadToolBarButtonDownload" Value="Download" ToolTip="Download this document" />
                    <telerik:RadToolBarButton SkinID="RadToolBarButtonBookmark" Text="" Value="Bookmark" ToolTip="Bookmark" Visible="false" />
                    <telerik:RadToolBarButton SkinID="RadToolBarButtonCancel" Value="Cancel" CommandName="Cancel" />
                </Items>
            </telerik:RadToolBar>
    </div>
    
    <div class="telerik-aqua-body">
        <div style="margin: 10px 0px 10px 0px;">
            <div>
                <asp:Label ID="LabelFilename" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <div style="margin: 0px 0px 10px 0px;">
            <div>
                Type
            </div>
            <div>
                <telerik:RadComboBox ID="RadComboBoxDocumentType" runat="server" SkinID="RadComboBoxStandard"></telerik:RadComboBox>
            </div>
        </div>
        <div style="margin: 0px 0px 10px 0px;">
            <div>
                Description
            </div>
            <div>
                <asp:TextBox ID="TextBoxDescription" runat="server" TextMode="SingleLine" SkinID="TextBoxCodeSingleLineDescription"
                    MaxLength="200"></asp:TextBox>
                <div style="font-size: small;">Describe the file or link.</div>
            </div>
        </div>
        <div style="margin: 0px 0px 10px 0px;">
            <div>
                Keywords
            </div>
            <div>
                <asp:TextBox ID="TextBoxKeywords" runat="server" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                <div style="font-size: small;">Keywords that may help someone find this document later.</div>
            </div>
        </div>
        <div style="margin: 0px 0px 10px 0px;">
            <div>
                Labels
            </div>
            <div>
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                    <wv:Document_Label_Tree runat="server" ID="UserControlDocumentLabelTree" />
                    <div>
                        <asp:ImageButton ID="ImageButtonEditLabels" runat="server" OnClientClick="OpenRadWindow('','Maintenance_Documents.aspx?tabidx=1');" SkinID="ImageButtonEdit" ToolTip="Edit Labels" Visible="true" />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            </div>
        </div>
    </div>
</asp:Content>
