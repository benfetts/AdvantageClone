<%@ Page AutoEventWireup="false" CodeBehind="Documents_JobComponent.aspx.vb" Inherits="Webvantage.Documents_JobComponent" Title="Job Documents"
    Language="vb" MasterPageFile="~/ChildPage.Master" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <telerik:RadCodeBlock ID="RadCodeBlockHead" runat="server">
        <script type="text/javascript">
            function RadToolbarDocumentManagerJsOnClientButtonClicking(sender, args) {
                var comandName = args.get_item().get_commandName();
                if (comandName == "Delete") {
                    ////args.set_cancel(!confirm('Are you sure you want to delete?'));
                    radToolBarConfirm(sender, args, "Are you sure you want to delete?");
                }
            }
            function RefreshFileGrid(radWindowCaller) {
                __doPostBack('onclick#Refresh', 'Refresh');
            }
            function HidePopUpWindows(radWindowCaller) {
                __doPostBack('onclick#Refresh', 'HidePopups');
            }
            function HidePopUpRefresh(radWindowCaller) {
                __doPostBack('onclick#Refresh', 'HidePopUpRefresh');
            }
            function realPostBack(eventTarget, eventArgument) {
                __doPostBack(eventTarget, eventArgument);
            }
        </script>
        <style>
            .thumbnail {
                height: 100px !important;
                width: auto !important;
            }
        </style>
    </telerik:RadCodeBlock>
</asp:Content>
<asp:Content ID="Content" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain" EnableViewState="true">
    <div style="margin-left: auto; margin-right: auto; left: 0; right: 0; text-align: center;">
        <telerik:RadToolBar ID="FilesRadToolbar" runat="server" AutoPostBack="True" Width="100%" OnClientButtonClicking="RadToolbarDocumentManagerJsOnClientButtonClicking">
                    <Items>
                        <telerik:RadToolBarButton Text="Label View" Value="LabelView" CommandName="LabelView" ToolTip="Label View" Visible="True" />
                        <telerik:RadToolBarButton IsSeparator="true" Value="LabelViewSeparator" />
                        <telerik:RadToolBarButton Value="RadToolBarButtonLevel">
                            <ItemTemplate>
                                <telerik:RadComboBox ID="RadComboBoxDocLevel" runat="server" Width="150px" AutoPostBack="true" SkinID="RadComboBoxStandard">
                                    <Items>
                                        <telerik:RadComboBoxItem Text="Please Select" Value=""></telerik:RadComboBoxItem>
                                        <telerik:RadComboBoxItem Text="Job" Value="JO"></telerik:RadComboBoxItem>
                                        <telerik:RadComboBoxItem Text="Job/Component" Value="JC"></telerik:RadComboBoxItem>
                                    </Items>
                                </telerik:RadComboBox>
                            </ItemTemplate>
                        </telerik:RadToolBarButton>
                        <telerik:RadToolBarButton IsSeparator="true" />
                        <telerik:RadToolBarButton ID="UploadToolbarButton" runat="server" SkinID="RadToolBarButtonUpload"
                            Text="" Value="Upload" CommandName="Upload" ToolTip="Upload a document" />
                        <telerik:RadToolBarButton ID="DownloadToolbarButton" runat="server" SkinID="RadToolBarButtonDownload"
                            Text="" Value="Download" CommandName="Download" ToolTip="Download this document" />
                        <telerik:RadToolBarButton IsSeparator="true" />
                        <telerik:RadToolBarButton SkinID="RadToolBarButtonDelete" Text="Delete" Value="Delete" CommandName="Delete" Enabled="false" ToolTip="Delete selected file" />
                        <telerik:RadToolBarButton ID="RefreshToolbarButton" runat="server" SkinID="RadToolBarButtonRefresh" Value="Refresh" CommandName="Refresh" ToolTip="Refresh file list" />
                        <telerik:RadToolBarButton IsSeparator="true" />
                        <telerik:RadToolBarButton ID="SearchArea" runat="server">
                            <ItemTemplate>
                                <asp:TextBox ID="SearchCriteriaTextBox" runat="server" Width="125px" SkinID="TextBoxStandard"></asp:TextBox>
                            </ItemTemplate>
                        </telerik:RadToolBarButton>
                        <telerik:RadToolBarButton ID="SearchRadToolbarButton" runat="server" SkinID="RadToolBarButtonFind"
                            Text="Search" Value="Search" CommandName="Search" ToolTip="Search" />
                        <telerik:RadToolBarButton ID="RadToolbarButton1" runat="server" SkinID="RadToolBarButtonClear"
                            Text="Clear" Value="ClearSearch" CommandName="ClearSearch" ToolTip="Clears the search text box" />
                        <telerik:RadToolBarButton SkinID="RadToolBarButtonThumbnails" Value="ShowThumbnails" CommandName="ShowThumbnails" CheckOnClick="true" AllowSelfUnCheck="true" Checked="false" CausesValidation="false" />
                        <telerik:RadToolBarButton SkinID="RadToolBarButtonBookmark" Text="" Value="Bookmark"
                            ToolTip="Bookmark" Visible="false" />
                        <telerik:RadToolBarButton IsSeparator="true" Value="ProofHQDownloadSeparator" Visible="false" />
                        <telerik:RadToolBarButton Text="Upload to Proof HQ" Value="ProofHQUpload"
                            ToolTip="Upload document to Proof HQ" Visible="false" Enabled="false" />
                        <telerik:RadToolBarButton Text="Download From Proof HQ" Value="ProofHQDownload"
                            ToolTip="Download document from Proof HQ" Visible="false" />
                        <telerik:RadToolBarButton IsSeparator="true" />
                    </Items>
                </telerik:RadToolBar>
    </div>
    <div class="telerik-aqua-body">
        <telerik:RadGrid ID="RadGridJobComponentDocuments" runat="server" AllowMultiRowSelection="True" AllowSorting="True"
                    AutoGenerateColumns="False" EnableAJAXLoadingTemplate="True" GridLines="None"
                    Width="100%" ShowGroupPanel="False" EnableAJAX="False">
                    <MasterTableView AllowMultiColumnSorting="true" Width="100%" DataKeyNames="DOCUMENT_ID">
                        <Columns>
                            <telerik:GridTemplateColumn HeaderText="&nbsp;" UniqueName="CheckBoxTemplateColumn">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemTemplate>
                                    <asp:CheckBox ID="SelectCheckBox" runat="server" AutoPostBack="True" OnCheckedChanged="ToggleRowSelection" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
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
                            <telerik:GridTemplateColumn HeaderText="&nbsp;" UniqueName="GridTemplateColumnLabels" Visible="true">
                                <HeaderStyle CssClass="radgrid-icon-column" />
                                <ItemStyle CssClass="radgrid-icon-column" />
                                <FooterStyle CssClass="radgrid-icon-column" />
                                <ItemTemplate>
                                    <div id="DivDocumentLabels" runat="server" class="icon-background background-color-sidebar">
                                        <asp:ImageButton ID="ImageButtonEditDetails" runat="server" SkinID="ImageButtonEditWhite" />
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="&nbsp;" UniqueName="TemplateColumn">
                                <HeaderStyle CssClass="radgrid-icon-column" />
                                <ItemStyle CssClass="radgrid-icon-column" />
                                <FooterStyle CssClass="radgrid-icon-column" />
                                <ItemTemplate>
                                    <div id="DivDocumentType" runat="server" class="icon-background background-color-sidebar">
                                        <asp:LinkButton ID="LinkButtonDocumentType" runat="server" Text="" ToolTip="" CommandName="Download" CssClass="icon-text" CommandArgument='<%# Eval("DOCUMENT_ID")%>'></asp:LinkButton>
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="LEVEL" HeaderText="Level" UniqueName="GridBoundColumnLevel">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100" />
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn GroupByExpression="FILENAME Filename Group By FILENAME"
                                HeaderText="Filename" SortExpression="FILENAME" UniqueName="FilenameTemplateColumn">
                                <HeaderStyle CssClass="radgrid-description-column" />
                                <ItemStyle CssClass="radgrid-description-column" />
                                <FooterStyle CssClass="radgrid-description-column" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButtonDownload" runat="server"></asp:LinkButton>
                                    <div id="DivDescription" runat="server" style="font-size: small;">
                                        Description:&nbsp;&nbsp;<%# Eval("DESCRIPTION") %>
                                    </div>
                                    <div id="DivKeywords" runat="server" style="font-size: small;">
                                        Keywords:&nbsp;&nbsp;<%# Eval("KEYWORDS") %>
                                    </div>
                                    <div id="DivLabels" runat="server">
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="DESCRIPTION" HeaderText="Description" UniqueName="DescriptionColumn" Visible="false">
                                <HeaderStyle CssClass="radgrid-description-column" />
                                <ItemStyle CssClass="radgrid-description-column" />
                                <FooterStyle CssClass="radgrid-description-column" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="DOCUMENT_TYPE_DESC" HeaderText="Type" UniqueName="DocumentTypeDescColumn">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="70" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="70" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="FILE_SIZE" DataFormatString="{0:#,### KB}" HeaderText="Size"
                                UniqueName="SizeColumn">
                                <HeaderStyle Width="70" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle Width="70" HorizontalAlign="Center" VerticalAlign="Middle" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="USER_CODE" HeaderText="Uploaded By" UniqueName="UserNameColumn">
                                <HeaderStyle Width="90" HorizontalAlign="Right" VerticalAlign="Middle" />
                                <ItemStyle Width="90" HorizontalAlign="Right" VerticalAlign="Middle" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="UPLOADED_DATE" HeaderText="Date/Time" UniqueName="UploadedDateColumn">
                                <HeaderStyle Width="140" HorizontalAlign="Right" VerticalAlign="Middle" />
                                <ItemStyle CssClass="radgrid-datetime-column" VerticalAlign="Middle" />
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn HeaderText="Private" UniqueName="colChkPrivate">
                                <HeaderStyle CssClass="radgrid-icon-column" />
                                <ItemStyle CssClass="radgrid-icon-column" />
                                <FooterStyle CssClass="radgrid-icon-column" />
                                <ItemTemplate>
                                    <telerik:RadButton ID="RadButtonPrivate" runat="server" ButtonType="ToggleButton" ToggleType="CheckBox" AutoPostBack="false" Checked='<%#SetCheckBox(Eval("PRIVATE_FLAG"))%>' ReadOnly="true">
                                    </telerik:RadButton>
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
                            <telerik:GridTemplateColumn UniqueName="HistoryTemplateColumn">
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
                                    <div id="DivDelete" runat="server" class="icon-background background-color-delete">
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
                        <NoRecordsTemplate>
                            There are no files in this folder.
                        </NoRecordsTemplate>
                    </MasterTableView>
                    <ClientSettings AllowColumnsReorder="True" AllowDragToGroup="False">
                        <Resizing AllowColumnResize="false" EnableRealTimeResize="True" />
                    </ClientSettings>
                </telerik:RadGrid>
                <br />
                <br />
                <br />
                <br />
                <br />
                <telerik:RadWindowManager ID="RadWindowManager" runat="server">
                    <Windows>
                        <telerik:RadWindow ID="FileUploadWindow" runat="server" InitialBehavior="None" Modal="true" OnClientClose=""
                            ReloadOnShow="true" VisibleOnPageLoad="false" />
                        <telerik:RadWindow ID="DocumentHistoryRadWindow" runat="server" InitialBehavior="None" Modal="true"
                            OnClientClose="" ReloadOnShow="true" VisibleOnPageLoad="false" />
                    </Windows>
                </telerik:RadWindowManager>
    </div>    
        
</asp:Content>
