<%@ Page Title="Labels" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="Document_Label_Tree.aspx.vb" Inherits="Webvantage.Document_Label_Tree_Page" %>
<%@ Register Src="~/Document_Label_Tree.ascx" TagPrefix="wv" TagName="Document_Label_Tree" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
        <wv:Document_Label_Tree runat="server" id="UserControlDocumentLabelTree" />
        <div>
            <asp:ImageButton ID="ImageButtonEditLabels" runat="server" OnClientClick="OpenRadWindow('','Maintenance_Documents.aspx?tabidx=1');" SkinID="ImageButtonEdit" ToolTip="Edit Labels" Visible="true" />
        </div>
                </ContentTemplate>
            </asp:UpdatePanel>
</asp:Content>
