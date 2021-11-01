<%@ Page Title="Status Maintenance" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="Maintenance_Status.aspx.vb" Inherits="Webvantage.Maintenance_Status" %>

<asp:Content ID="ContentStatus" ContentPlaceHolderID="ContentPlaceHolderMain"
    runat="server">
    
    
    <table cellpadding="0" cellspacing="0" width="100%" align="center" border="0">
        <tr>
            <td>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="75%">
                            &nbsp;
                        </td>
                        <td align="right" valign="middle">
                            <asp:CheckBox ID="CheckBoxShowInactive" runat="server" Text="Show Inactive" AutoPostBack="True" />
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
                    <telerik:RadGrid ID="RadGridStatuses" runat="server" AllowPaging="True"
                        AllowSorting="True" GridLines="None" PageSize="10" EnableEmbeddedSkins="True"
                         ShowFooter="False" AutoGenerateColumns="False" Width="780">
                        <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="True" Position="Bottom" Height="20px">
                        </PagerStyle>
                        <MasterTableView CommandItemDisplay="None" EditMode="InPlace" DataKeyNames="Code, Description, IsInactive"
                            InsertItemDisplay="Top">
                            <CommandItemSettings AddNewRecordText="Add" RefreshText="Refresh" />
                            <Columns>
                                <telerik:GridTemplateColumn UniqueName="GridTemplateColumnStatusCode" HeaderText="Code" SortExpression="Code">
                                    <HeaderStyle Width="75" VerticalAlign="Middle" HorizontalAlign="Left" />
                                    <ItemStyle Width="75" VerticalAlign="Middle" HorizontalAlign="Left" />
                                    <FooterStyle Width="75" VerticalAlign="Middle" HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <%#Eval("Code") %>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBoxStatusCodeEditTextBox" runat="server"
                                            Text='<%#Eval("Code") %>' MaxLength="10" SkinID="TextBoxCodeSmall"></asp:TextBox>
                                    </EditItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn UniqueName="GridTemplateColumnStatusDescription" HeaderText="Description"
                                    SortExpression="Description">
                                    <HeaderStyle Width="225" VerticalAlign="Middle" HorizontalAlign="Left" />
                                    <ItemStyle Width="225" VerticalAlign="Middle" HorizontalAlign="Left" />
                                    <FooterStyle Width="225" VerticalAlign="Middle" HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:TextBox ID="TextBoxStatusDescription" runat="server"  SkinID="TextBoxStandard"
                                            Text='<%#Eval("Description") %>' MaxLength="30" Width="225"></asp:TextBox>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBoxStatusDescriptionEditTextBox" runat="server"  SkinID="TextBoxStandard"
                                            Text='<%#Eval("Description") %>' MaxLength="30" Width="225"></asp:TextBox>
                                    </EditItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn UniqueName="GridTemplateColumnIsInactive" HeaderText="Inactive" SortExpression="IsInactive">
                                    <HeaderStyle  VerticalAlign="Middle" HorizontalAlign="Center" />
                                    <ItemStyle  VerticalAlign="Middle" HorizontalAlign="Center" />
                                    <FooterStyle  VerticalAlign="Middle" HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CheckBoxIsInactive" runat="server" AutoPostBack="false" Checked='<%#Eval("IsInactive") %>' />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:CheckBox ID="CheckBoxIsInactiveEditCheckBox" runat="server" Checked="false" />
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
</asp:Content>
