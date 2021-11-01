<%@ Page Title="Documents List" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="Documents_List.aspx.vb" Inherits="Webvantage.Documents_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <style>
        .thumbnail {
            height: 100px !important;
            width: auto !important;
        }
    </style>
    <script type="text/javascript">
        function SelectAllRows(checked) {
                var radgrid = $find('<%= RadGridDocuments.ClientID %>');
                var masterTableView = radgrid.get_masterTableView()
                var detailTables = radgrid.get_detailTables();
                var allTables = new Array();

                allTables = allTables.concat(detailTables);
                allTables.splice(0, 0, masterTableView);

                for (var t = 0; t < allTables.length; t++) {
                    if (checked == true) {
                        allTables[t].selectAllItems();
                    } else {
                        allTables[t].clearSelectedItems();
                    }
                }
                var HiddenFieldSelectAll = document.getElementById('<%= HiddenFieldSelectAll.ClientID%>');
                if (checked == true) {
                    HiddenFieldSelectAll.value = '1';
                } else {
                    HiddenFieldSelectAll.value = '0';
                }
            }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <telerik:RadToolBar ID="RadToolBarDocumentViewer" runat="server" AutoPostBack="true"
        Width="100%">
        <Items>
            <telerik:RadToolBarButton IsSeparator="true" />
            <telerik:RadToolBarButton SkinID="RadToolBarButtonDownload" Text="" CommandName="Download"
                ToolTip="Download selected documents" Value="Download" />
            <telerik:RadToolBarButton IsSeparator="true" />
            <telerik:RadToolBarButton SkinID="RadToolBarButtonThumbnails" Value="ShowThumbnails" CommandName="ShowThumbnails" CheckOnClick="true" AllowSelfUnCheck="true" Checked="false" CausesValidation="false" />
        </Items>
    </telerik:RadToolBar>
    <asp:HiddenField ID="HiddenFieldSelectAll" runat="server" Value="0" />    
    <table style="width: 100%;">
        <tr>
            <td style="width: 100%;">
                <telerik:RadGrid ID="RadGridDocuments" runat="server" AutoGenerateColumns="False"
                    AllowSorting="true" ClientSettings-AllowColumnsReorder="false" EnableAJAX="False"
                    EnableAJAXLoadingTemplate="True" GridLines="None" ShowGroupPanel="False" ShowHeader="true"
                    AllowMultiRowSelection="True" Width="100%">
                        <ClientSettings AllowColumnsReorder="False" AllowDragToGroup="False">
                        <Selecting AllowRowSelect="True" EnableDragToSelectRows="true" />
                        <Resizing AllowColumnResize="False" EnableRealTimeResize="False" />
                    </ClientSettings>
                    <MasterTableView Width="100%" DataKeyNames="DOCUMENT_ID">
                        <GroupHeaderItemStyle />
                        <Columns>
                            <telerik:GridTemplateColumn HeaderText="&nbsp;" UniqueName="CheckBoxTemplateColumn">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="28" />                                
                                <HeaderTemplate>
                                    <input id="CheckBoxSelectAllRows" type="checkbox" name="CheckBoxSelectAllRows" onclick="SelectAllRows(this.checked)" />
                                </HeaderTemplate>
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="28" />
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
                            <telerik:GridBoundColumn DataField="LEVEL" HeaderText="Level" UniqueName="LevelColumn">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="120" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="120" />
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn GroupByExpression="FILENAME Filename Group By FILENAME"
                                HeaderText="Filename" SortExpression="FILENAME" UniqueName="FilenameTemplateColumn">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="140" />
                                <ItemStyle CssClass="radgrid-description-column" />
                                <ItemTemplate>
                                    <asp:Literal ID="litDocLink" runat="server"></asp:Literal>
                                    <asp:LinkButton ID="DownloadLinkButton" runat="server"></asp:LinkButton>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="DESCRIPTION" HeaderText="File Descriptions" UniqueName="UserNameColumn">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle"  />
                                <ItemStyle CssClass="radgrid-description-column" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="DOCUMENT_TYPE_DESC" HeaderText="Type" UniqueName="UserNameColumn">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="70" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="70" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="FILE_SIZE" DataFormatString="{0:#,### KB}" HeaderText="Size"
                                UniqueName="SizeColumn">
                                <HeaderStyle Width="80" HorizontalAlign="Right" VerticalAlign="Middle" />
                                <ItemStyle Width="80" HorizontalAlign="Right" VerticalAlign="Middle" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="USER_NAME" HeaderText="Uploaded By" UniqueName="UserNameColumn">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="UPLOADED_DATE" HeaderText="Date/Time" UniqueName="UploadedDateColumn">
                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="150" />
                                <ItemStyle CssClass="radgrid-datetime-column" VerticalAlign="Middle" />
                            </telerik:GridBoundColumn>
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
                            <telerik:GridTemplateColumn UniqueName="ItemsTemplateColumn" Visible="false">
                                <HeaderStyle CssClass="radgrid-icon-column" />
                                <ItemStyle CssClass="radgrid-icon-column" />
                                <FooterStyle CssClass="radgrid-icon-column" />
                                <ItemTemplate>
                                    <div class="icon-background background-color-sidebar">
                                        <asp:ImageButton ID="DocumentExpenseItems" runat="server" CommandName="ShowItems" ImageUrl="Images/Icons/White/256/documents_empty.png" CssClass="icon-image"
                                            CommandArgument='<%# Eval("DOCUMENT_ID")%>' ToolTip="Select line items for receipt" />
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="DeleteTemplateColumn" Visible="false">
                                <HeaderStyle CssClass="radgrid-icon-column" />
                                <ItemStyle CssClass="radgrid-icon-column" />
                                <FooterStyle CssClass="radgrid-icon-column" />
                                <ItemTemplate>
                                    <div class="icon-background background-color-delete">
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
                </telerik:RadGrid>

            </td>
        </tr>
    </table>
</asp:Content>
