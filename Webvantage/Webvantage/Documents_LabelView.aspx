<%@ Page Title="Documents" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="Documents_LabelView.aspx.vb" Inherits="Webvantage.Documents_LabelView" %>

<%@ Register Src="~/Document_Label.ascx" TagPrefix="wv" TagName="Document_Label" %>
<%@ Register Src="~/Document_Label_Tree.ascx" TagPrefix="wv" TagName="Document_Label_Tree" %>
<%@ Register Src="UnityUC.ascx" TagName="UnityContextMenu" TagPrefix="custom" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <telerik:RadCodeBlock ID="RadCodeBlockHead" runat="server">
        <style type="text/css">
            #wrapper {
                width: 100%;
                margin: 0 auto;
            }

            #contentliquid {
                float: left;
                width: 100%;
            }

            #content {
                margin-left: 250px;
            }

            #leftcolumn {
                float: left;
                width: 250px;
                margin-left: -100%;
            }
             .thumbnail {
                height: 100px !important;
                width: auto !important;
            }
       </style>
    </telerik:RadCodeBlock>
</asp:Content>
<asp:Content ID="ContentBody" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div id="wrapper">
        <div id="contentliquid">
            <div id="content">
                <telerik:RadToolBar ID="RadToolbarDocumentManager" runat="server" Width="100%">
                    <Items>
                        <telerik:RadToolBarButton Text="Standard View" Value="StandardView" CommandName="StandardView" ToolTip="Standard View" Visible="False" />
                        <telerik:RadToolBarButton IsSeparator="true" />
                        <telerik:RadToolBarButton SkinID="RadToolBarButtonUpload" Value="Upload" ToolTip="Upload a document" Visible="false" />
                        <telerik:RadToolBarButton SkinID="RadToolBarButtonDownload" Value="Download" ToolTip="Download this document" />
                        <telerik:RadToolBarButton IsSeparator="true" />
                        <telerik:RadToolBarButton SkinID="RadToolBarButtonRefresh" Value="Refresh" ToolTip="Refresh file list" />
                        <telerik:RadToolBarButton IsSeparator="true" />
                        <telerik:RadToolBarButton Text="Advanced Search" Value="AdvancedSearch" CommandName="AdvancedSearch" ToolTip="Go to Advanced Search" Visible="true" />
                        <telerik:RadToolBarButton IsSeparator="true" Value="ProofHQDownloadSeparator" Visible="false" />
                        <telerik:RadToolBarButton Text="Upload to Proof HQ" Value="ProofHQUpload" ToolTip="Upload document to Proof HQ" Visible="false" Enabled="false" />
                        <telerik:RadToolBarButton Text="Download From Proof HQ" Value="ProofHQDownload" ToolTip="Download document from Proof HQ" Visible="false" />
                        <telerik:RadToolBarButton IsSeparator="true" />
                        <telerik:RadToolBarButton SkinID="RadToolBarButtonThumbnails" Value="ShowThumbnails" CommandName="ShowThumbnails" CheckOnClick="true" AllowSelfUnCheck="true" Checked="false" CausesValidation="false" />
                        <telerik:RadToolBarButton SkinID="RadToolBarButtonBookmark" Text="" Value="Bookmark" ToolTip="Bookmark" Visible="false" />
                        <telerik:RadToolBarButton IsSeparator="true" Value="ProofHQDownloadSeparator" Visible="false" />
                        <telerik:RadToolBarButton Text="Upload to Proof HQ" Value="ProofHQUpload" ToolTip="Upload document to Proof HQ" Visible="false" Enabled="false" />
                        <telerik:RadToolBarButton Text="Download From Proof HQ" Value="ProofHQDownload" ToolTip="Download document from Proof HQ" Visible="false" />
                        <telerik:RadToolBarButton IsSeparator="true" />
                    </Items>
                </telerik:RadToolBar>
                <telerik:RadGrid ID="RadGridDocuments" runat="server" AutoGenerateColumns="false" AllowMultiRowSelection="true" AllowAutomaticInserts="False"
                    AllowSorting="true" EnableHeaderContextMenu="true" EnableEmbeddedSkins="True" EnableViewState="true" GridLines="None" GroupingSettings-GroupByFieldsSeparator="&nbsp;&nbsp;|&nbsp;&nbsp;"
                    AllowPaging="True" PageSize="10" ShowFooter="True">
                    <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom"></PagerStyle>
                    <ClientSettings AllowColumnsReorder="False" AllowDragToGroup="False">
                        <Resizing AllowColumnResize="false" EnableRealTimeResize="False" />
                        <Selecting AllowRowSelect="true" />
                    </ClientSettings>
                    <MasterTableView AllowMultiColumnSorting="true" EnableLinqGrouping="false" DataKeyNames="ID">
                        <Columns>
                            <telerik:GridClientSelectColumn>
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </telerik:GridClientSelectColumn>
                            <telerik:GridTemplateColumn HeaderText="&nbsp;" UniqueName="GridTemplateColumnThumbnail" HeaderAbbr="FIXED">
                                <HeaderStyle Width="100" />
                                <ItemStyle Width="100" />
                                <FooterStyle Width="100" />
                                <HeaderTemplate>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImageButtonThumbnail" runat="server" CssClass="thumbnail" Visible="false" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="&nbsp;" UniqueName="TemplateColumn">
                                <HeaderStyle CssClass="radgrid-icon-column" />
                                <ItemStyle CssClass="radgrid-icon-column" />
                                <FooterStyle CssClass="radgrid-icon-column" />
                                <ItemTemplate>
                                    <div id="DivDocumentType" runat="server" class="icon-background background-color-sidebar">
                                        <asp:LinkButton ID="LinkButtonDocumentType" runat="server" Text="" ToolTip="" CommandName="Download" CssClass="icon-text" CommandArgument='<%# Eval("ID")%>'></asp:LinkButton>
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="" UniqueName="GridTemplateColumnDisplay">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <ItemTemplate>
                                    <div>
                                        <asp:LinkButton ID="LinkButtonDownload" runat="server"></asp:LinkButton>
                                    </div>
                                    <div id="DivDescription" runat="server" style="font-size: small;">
                                        Description:&nbsp;&nbsp;<%# Eval("Description") %>
                                    </div>
                                    <div id="DivKeywords" runat="server" style="font-size: small;">
                                        Keywords:&nbsp;&nbsp;<%# Eval("Keywords") %>
                                    </div>
                                    <div id="DivSize" runat="server" style="font-size: small;">
                                        Size:&nbsp;&nbsp;<asp:Literal ID="LiteralSize" runat="server"></asp:Literal>
                                    </div>
                                    <div id="DivLabels" runat="server">
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Private" UniqueName="GridTemplateColumnIsPrivate">
                                <HeaderStyle CssClass="radgrid-icon-column" />
                                <ItemStyle CssClass="radgrid-icon-column" />
                                <FooterStyle CssClass="radgrid-icon-column" />
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBoxIsPrivate" runat="server" Enabled="false" Checked='<%# Eval("IsPrivate")%>' />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnAddComments">
                                <HeaderStyle CssClass="radgrid-icon-column" />
                                <ItemStyle CssClass="radgrid-icon-column" />
                                <FooterStyle CssClass="radgrid-icon-column" />
                                <ItemTemplate>
                                    <div id="DivAddComments" runat="server" class="icon-background background-color-sidebar">
                                        <asp:ImageButton ID="ImageButtonAddComments" runat="server" SkinID="ImageButtonCommentWhite" ToolTip="Click to add comment to this document" Visible="false" />
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnHistory">
                                <HeaderStyle CssClass="radgrid-icon-column" />
                                <ItemStyle CssClass="radgrid-icon-column" />
                                <FooterStyle CssClass="radgrid-icon-column" />
                                <ItemTemplate>
                                    <div id="DivDocumentHistory" runat="server" class="icon-background background-color-sidebar">
                                        <asp:LinkButton ID="LinkButtonDocumentHistory" runat="server" Text="H" ToolTip="Show document history" CommandName="ShowHistory" CssClass="icon-text" CommandArgument='<%# Eval("ID")%>'></asp:LinkButton>
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
                        </Columns>
                        <ExpandCollapseColumn Resizable="False" Visible="False">
                            <HeaderStyle Width="20px" />
                        </ExpandCollapseColumn>
                        <RowIndicatorColumn Visible="False">
                            <HeaderStyle Width="20px" />
                        </RowIndicatorColumn>
                    </MasterTableView>
                </telerik:RadGrid>
            </div>
        </div>
        <div id="leftcolumn">
            <div>
                <wv:Document_Label_Tree runat="server" ID="DocumentLabelTree" />
            </div>
            <div>
                <asp:ImageButton ID="ImageButtonEditLabels" runat="server" SkinID="ImageButtonEdit" ToolTip="Edit Labels" Visible="true" />
            </div>
        </div>
    </div>
    <custom:UnityContextMenu ID="MyUnityContextMenu" runat="server" />
</asp:Content>
