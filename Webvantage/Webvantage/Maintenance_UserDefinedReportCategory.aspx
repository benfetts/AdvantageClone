<%@ Page Title="UserDefinedReportCategory Maintenance" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="Maintenance_UserDefinedReportCategory.aspx.vb" Inherits="Webvantage.Maintenance_UserDefinedReportCategory" %>

<asp:Content ID="conUserDefinedReportCategoryContent" ContentPlaceHolderID="ContentPlaceHolderMain"
    runat="server">
    <div class="telerik-aqua-body">
        <table cellpadding="0" cellspacing="0" width="100%" align="center" border="0">
                <tr>
                    <td>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="75%">
                                  &nbsp;
                                </td>
                                <td align="right" valign="middle">
                                    <asp:ImageButton ID="ImageButtonExport" runat="server" SkinID="ImageButtonExportExcel" />&nbsp;&nbsp;
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                            <br />
                            <telerik:RadGrid ID="RadGridUserDefinedReportCategories" runat="server" AllowPaging="True"
                                AllowSorting="True" GridLines="None" PageSize="10" EnableEmbeddedSkins="True"
                                 ShowFooter="False" AutoGenerateColumns="False" Width="780">
                                <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="True" Position="Bottom" Height="20px">
                                </PagerStyle>
                                <MasterTableView CommandItemDisplay="None" EditMode="InPlace" DataKeyNames="ID, Description"
                                    InsertItemDisplay="Top">
                                    <CommandItemSettings AddNewRecordText="Add" RefreshText="Refresh" />
                                    <Columns>
                                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumnUserDefinedReportCategoryID" HeaderText="ID" Visible="false">
                                            <HeaderStyle Width="10" VerticalAlign="Middle" HorizontalAlign="Left" />
                                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                                            <FooterStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <%# Eval("ID")%>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumnUserDefinedReportCategoryDescription" HeaderText="Description"
                                            SortExpression="Description">
                                            <HeaderStyle Width="680" VerticalAlign="Middle" HorizontalAlign="Left" />
                                            <ItemStyle Width="680" VerticalAlign="Middle" HorizontalAlign="Left" />
                                            <FooterStyle Width="680" VerticalAlign="Middle" HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="TextBoxUserDefinedReportCategoryDescription" runat="server"  Text='<%#Eval("Description") %>' SkinID="TextBoxStandard"
                                                    MaxLength="100" Width="680"></asp:TextBox>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBoxUserDefinedReportCategoryDescriptionEditTextBox" runat="server"  SkinID="TextBoxStandard"
                                                    Text='<%#Eval("Description") %>' MaxLength="100" Width="680"></asp:TextBox>
                                            </EditItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumnSave">
                                            <HeaderStyle CssClass="radgrid-icon-column" />
                                            <ItemStyle CssClass="radgrid-icon-column" />
                                            <FooterStyle CssClass="radgrid-icon-column" />
                                            <HeaderTemplate>
                                                    <asp:ImageButton ID="ImageButtonSaveAll" runat="server" SkinID="ImageButtonSaveAll"
                                                        ToolTip="Click to save all rows" CommandName="SaveAll" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <div class="icon-background background-color-sidebar">
                                                    <asp:ImageButton ID="ImageButtonSave" runat="server" SkinID="ImageButtonSaveWhite"
                                                        ToolTip="Click to save this row" CommandName="SaveRow" />
                                                </div>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <div class="icon-background background-color-sidebar">
                                                    <asp:ImageButton ID="ImageButtonSaveNew" runat="server" SkinID="ImageButtonNewWhite"
                                                        ToolTip="Click to add this row" CommandName="SaveNewRow" />
                                                </div>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                    <asp:ImageButton ID="ImageButtonSaveAllFooter" runat="server" SkinID="ImageButtonSaveAll"
                                                        ToolTip="Click to save all rows" CommandName="SaveAll" />
                                            </FooterTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumnCancel">
                                            <HeaderStyle CssClass="radgrid-icon-column" />
                                            <ItemStyle CssClass="radgrid-icon-column" />
                                            <FooterStyle CssClass="radgrid-icon-column" />
                                            <ItemTemplate>
                                                <div class="icon-background background-color-delete">
                                                    <asp:ImageButton ID="ImageButtonDelete" runat="server" SkinID="ImageButtonDeleteWhite" ToolTip="Click to delete this row"
                                                        CommandName="DeleteRow" />
                                                </div>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <div class="icon-background background-color-sidebar">
                                                    <asp:ImageButton ID="ImageButtonCancel" runat="server" SkinID="ImageButtonCancelWhite"
                                                        ToolTip="Cancel add row" CommandName="CancelAddRow" />
                                                </div>
                                            </EditItemTemplate>
                                        </telerik:GridTemplateColumn>
                                    </Columns>
                                    <RowIndicatorColumn>
                                        <HeaderStyle Width="20px" />
                                    </RowIndicatorColumn>
                                    <ExpandCollapseColumn>
                                        <HeaderStyle Width="20px" />
                                    </ExpandCollapseColumn>
                                </MasterTableView>
                            </telerik:RadGrid>
                            <br />
                </ContentTemplate>
            </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
    </div>
</asp:Content>
