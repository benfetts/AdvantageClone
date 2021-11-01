<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Documents_History.aspx.vb"
    MasterPageFile="~/ChildPage.Master" Title="Document History" Inherits="Webvantage.Documents_History" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <table cellpadding="0" cellspacing="2" border="0" width="100%">
        <tr>
            <td>
                <telerik:RadGrid ID="DocumentHistoryRadGrid" runat="server" AutoGenerateColumns="false"
                    AllowSorting="true" Width="100%">
                    <MasterTableView>
                        <ExpandCollapseColumn Visible="False">
                            <HeaderStyle Width="19px" />
                        </ExpandCollapseColumn>
                        <RowIndicatorColumn Visible="False">
                            <HeaderStyle Width="20px" />
                        </RowIndicatorColumn>
                        <Columns>
                            <telerik:GridTemplateColumn UniqueName="TemplateColumn">
                                <HeaderStyle CssClass="radgrid-icon-column" />
                                <ItemStyle CssClass="radgrid-icon-column" />
                                <FooterStyle CssClass="radgrid-icon-column" />
                                <ItemTemplate>
                                    <div id="DivDocumentType" runat="server" class="icon-background background-color-sidebar">
                                        <asp:LinkButton ID="LinkButtonDocumentType" runat="server" Text="" ToolTip="" CommandName="Download" CssClass="icon-text" CommandArgument='<%# Eval("DOCUMENT_ID")%>'></asp:LinkButton>
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn Groupable="true" GroupByExpression="FILENAME Filename Group By FILENAME"
                                HeaderText="Filename" SortExpression="FILENAME" UniqueName="FilenameTemplateColumn">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButtonDownload" runat="server"></asp:LinkButton>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="DESCRIPTION" HeaderText="File Description" UniqueName="UserNameColumn">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="FILE_SIZE" DataFormatString="{0:#,### KB}" HeaderText="Size"
                                UniqueName="GridBoundColumnFileSize">
                                <HeaderStyle Width="70" HorizontalAlign="Right" />
                                <ItemStyle Width="70" HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="USER_NAME" HeaderText="Uploaded By" UniqueName="UserNameColumn">
                                <HeaderStyle Width="110px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="UPLOADED_DATE" HeaderText="Date/Time" UniqueName="UploadedDateColumn">
                                <HeaderStyle Width="160" HorizontalAlign="Right" />
                                <ItemStyle Width="160" HorizontalAlign="Right" />
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
                    </MasterTableView>
                    <ClientSettings>
                        <Scrolling AllowScroll="false"  />
                    </ClientSettings>
                </telerik:RadGrid>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label   ID="InjectScriptLabel" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
