<%@ Page AutoEventWireup="false" CodeBehind="Estimating_FunctionComments.aspx.vb" ValidateRequest="false"
    MasterPageFile="~/ChildPage.Master" Title="Estimate Quote Comments" Inherits="Webvantage.Estimating_FunctionComments"
    Language="vb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <asp:Panel ID="PanelDetailComments" runat="server" Width="100%">
        <div>
            Detail Comments
        </div>
        <div>
            <telerik:RadEditor ID="RadEditorDetailComment" runat="server" Height="310" ToolsFile="~/RadEditorToolbars.xml" NewLineBr="true" NewLineMode="Br" OnClientLoad="RadEditorOnClientLoad" StripFormattingOptions="MsWord"
                ContentAreaCssFile="~/CSS/RadEditorContentArea.min.css" Width="98%" EditModes="Design" ContentAreaMode="Div" OnClientCommandExecuted="RadEditorOnClientCommandExecuted">
            </telerik:RadEditor>
            <asp:HiddenField ID="HiddenField1"
                runat="server" />

        </div>
    </asp:Panel>
    <asp:Panel ID="PanelSuppliedByNotesComments" runat="server" Width="100%">
        <div>
            Supplied By Notes
        </div>
        <div>
            <telerik:RadEditor ID="RadEditorSuppliedByNotes" runat="server" Height="310" ToolsFile="~/RadEditorToolbars.xml" NewLineBr="true" NewLineMode="Br" OnClientLoad="RadEditorOnClientLoad" StripFormattingOptions="MsWord"
                ContentAreaCssFile="~/CSS/RadEditorContentArea.min.css" Width="98%" EditModes="Design" ContentAreaMode="Div" OnClientCommandExecuted="RadEditorOnClientCommandExecuted">
            </telerik:RadEditor>
        </div>
    </asp:Panel>

    <div class="bottom-buttons">
        <asp:Button ID="BtnSave" runat="server" TabIndex="0" Text="Save" />
        &nbsp;
        <asp:Button ID="BtnImportSpecs" runat="server" TabIndex="0" Text="Insert Specs" />
        &nbsp; 
        <asp:Button ID="BtnCancel" runat="server" TabIndex="0" Text="Cancel" />
    </div>
</asp:Content>
