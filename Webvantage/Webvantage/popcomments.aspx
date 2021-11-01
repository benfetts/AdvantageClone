<%@ Page Title="Comments" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="popcomments.aspx.vb" Inherits="Webvantage.popcomments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <asp:TextBox ID="txtType" runat="server" Visible="False" SkinID="TextBoxStandard"></asp:TextBox>
    <asp:TextBox ID="txtID" runat="server" Visible="False" SkinID="TextBoxStandard"></asp:TextBox>
    <div style="padding: 10px 0px 20px 5px;">
        <asp:TextBox ID="TxtComment" runat="server" Enabled="true" TextMode="MultiLine" Height="300" Width="95%" TabIndex="0" SkinID="TextBoxStandard"></asp:TextBox>
        <telerik:RadEditor ID="RadEditorComment" runat="server" ToolsFile="~/RadEditorToolbars.xml" NewLineBr="true" NewLineMode="Br" OnClientLoad="RadEditorOnClientLoad" StripFormattingOptions="MsWord" OnClientCommandExecuted="RadEditorOnClientCommandExecuted"
            ContentAreaCssFile="~/CSS/RadEditorContentArea.min.css" EditModes="Design" ContentAreaMode="Div" Width="98%" Height="320" AutoResizeHeight="True" Visible="false">
        </telerik:RadEditor>
    </div>
    <div class="centered">
        <asp:Button ID="butSave" runat="server" Text="Save" TabIndex="2" />&nbsp;&nbsp;
        <asp:Button ID="butClose" runat="server" Text="Close" TabIndex="3" />
    </div>
</asp:Content>
