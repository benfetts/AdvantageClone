<%@ Page Title="Role Maintenance" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="Maintenance_Role.aspx.vb" Inherits="Webvantage.Maintenance_Role" %>

<asp:Content ID="ContentRole" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
        <script type="text/javascript">
            function RadGridRoles_RowDoubleClick(sender, eventArgs) {
                __doPostBack("<%= RadGridRoles.UniqueID %>", "IndexOfRowDoubleClicked:" + eventArgs.get_itemIndexHierarchical());
            }  
        </script>
    </telerik:RadScriptBlock>
    <div class="telerik-aqua-body">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="75%">
                        <telerik:RadTabStrip ID="RadTabStripRoles" runat="server" MultiPageID="RadMultiPageRoles"
                            AutoPostBack="true" SelectedIndex="0" Width="350">
                            <Tabs>
                                <telerik:RadTab Text="Roles">
                                </telerik:RadTab>
                                <telerik:RadTab Text="Role Detail">
                                </telerik:RadTab>
                            </Tabs>
                        </telerik:RadTabStrip>
                    </td>
                    <td align="right" valign="middle">
                        <asp:CheckBox ID="CheckBoxShowInactive" runat="server" Text="Show Inactive" AutoPostBack="True" />
                        <asp:ImageButton ID="ImageButtonExport" runat="server" SkinID="ImageButtonExportExcel" />&nbsp;&nbsp;
                    </td>
                </tr>
            </table>
            <telerik:RadMultiPage ID="RadMultiPageRoles" runat="server" SelectedIndex="0">
                <telerik:RadPageView ID="RadPageViewRoles" runat="server">
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                        <br />
                        <telerik:RadGrid ID="RadGridRoles" runat="server" AllowPaging="True" AllowSorting="True"
                            GridLines="None" PageSize="10" EnableEmbeddedSkins="True" ShowFooter="False"
                            AutoGenerateColumns="False" Width="780">
                            <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="True" Position="Bottom" Height="20px">
                            </PagerStyle>
                            <MasterTableView CommandItemDisplay="None" EditMode="InPlace" DataKeyNames="Code, Description, IsInactive"
                                InsertItemDisplay="Top">
                                <CommandItemSettings AddNewRecordText="Add" RefreshText="Refresh" />
                                <Columns>
                                    <telerik:GridTemplateColumn UniqueName="GridTemplateColumnRoleCode" HeaderText="Role Code"
                                        SortExpression="Code">
                                        <HeaderStyle Width="75" VerticalAlign="Middle" HorizontalAlign="Left" />
                                        <ItemStyle Width="75" VerticalAlign="Middle" HorizontalAlign="Left" />
                                        <FooterStyle Width="75" VerticalAlign="Middle" HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <%# Eval("Code")%>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBoxRoleCodeEditTextBox" runat="server" MaxLength="6" SkinID="TextBoxCodeSmall"></asp:TextBox>
                                        </EditItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn UniqueName="GridTemplateColumnRoleDescription" HeaderText="Description"
                                        SortExpression="Description">
                                        <HeaderStyle Width="300" VerticalAlign="Middle" HorizontalAlign="Left" />
                                        <ItemStyle Width="300" VerticalAlign="Middle" HorizontalAlign="Left" />
                                        <FooterStyle Width="300" VerticalAlign="Middle" HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:TextBox ID="TextBoxRoleDescription" runat="server" Text='<%#Eval("Description") %>'
                                                MaxLength="40" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBoxRoleDescriptionEditTextBox" runat="server" MaxLength="40"
                                                SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                                        </EditItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn UniqueName="GridTemplateColumnIsInactive" HeaderText="Inactive"
                                        SortExpression="IsInactive">
                                        <HeaderStyle  VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <ItemStyle  VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <FooterStyle  VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:CheckBox ID="CheckBoxIsInactive" runat="server" Checked='<%#Eval("IsInactive") %>' />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:CheckBox ID="CheckBoxIsInactiveEditCheckBox" runat="server" Checked="false">
                                            </asp:CheckBox>
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
                                    <telerik:GridTemplateColumn UniqueName="GridTemplateColumnDelete">
                                        <HeaderStyle CssClass="radgrid-icon-column" />
                                        <ItemStyle CssClass="radgrid-icon-column" />
                                        <FooterStyle CssClass="radgrid-icon-column" />
                                        <ItemTemplate>
                                            <div class="icon-background background-color-delete">
                                                <asp:ImageButton ID="ImageButtonDelete" runat="server" SkinID="ImageButtonDeleteWhite"
                                                    ToolTip="Click to delete this row" CommandName="DeleteRow" />
                                             </div>
                                       </ItemTemplate>
                                        <EditItemTemplate>
                                            <div class="icon-background background-color-delete">
                                                <asp:ImageButton ID="ImageButtonCancel" runat="server" SkinID="ImageButtonCancelWhite"
                                                    ToolTip="Cancel add row" CommandName="CancelNewRow" />
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
                            <ClientSettings>
                                <ClientEvents OnRowDblClick="RadGridRoles_RowDoubleClick" />
                            </ClientSettings>
                        </telerik:RadGrid>
                        <br />
                </ContentTemplate>
            </asp:UpdatePanel>
                </telerik:RadPageView>
                <telerik:RadPageView ID="RadPageViewRoleDetail" runat="server">
            <asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                        <table width="750" border="0" cellspacing="2" cellpadding="0">
                            <tr>
                                <td align="center" valign="bottom">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="left" valign="bottom">
                                    Role:
                                    <telerik:RadComboBox ID="DropDownListRoles" runat="server" AutoPostBack="true" Width="541" SkinID="RadComboBoxStandard"
                                        DataTextField="Description" DataValueField="Code">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" valign="bottom">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="left" valign="bottom">
                                    <asp:CheckBox ID="CheckBoxIsInactive" runat="server" Text="Inactive" AutoPostBack="True" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left" valign="bottom">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                        <table width="750" border="0" cellspacing="2" cellpadding="0">
                            <tr>
                                <td align="left" valign="bottom" width="300">
                                    Available Tasks
                                </td>
                                <td width="300" align="left" valign="bottom">
                                    Current Tasks
                                </td>
                            </tr>
                            <tr>
                                <td align="left" valign="top">
                                    <telerik:RadListBox ID="RadListBoxAvailableTasks" runat="server" Width="300px" Height="200px"
                                        SelectionMode="Multiple" AllowTransfer="true" TransferToID="RadListBoxCurrentTasks"
                                        AutoPostBackOnTransfer="true" AllowReorder="False" EnableDragAndDrop="true" DataTextField="TaskDescription"
                                        DataValueField="TaskCode">
                                    </telerik:RadListBox>
                                </td>
                                <td align="left" valign="top">
                                    <telerik:RadListBox ID="RadListBoxCurrentTasks" runat="server" Width="300px" Height="200px"
                                        SelectionMode="Multiple" AllowReorder="False" AutoPostBackOnReorder="true" EnableDragAndDrop="true"
                                        DataTextField="TaskDescription" DataValueField="TaskCode">
                                    </telerik:RadListBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" valign="top" colspan="3">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="left" valign="bottom">
                                    Available Employees
                                </td>
                                <td align="left" valign="bottom">
                                    Current Employees
                                </td>
                            </tr>
                            <tr>
                                <td align="left" valign="top">
                                    <telerik:RadListBox ID="RadListBoxAvailableEmployees" runat="server" Width="300px"
                                        Height="200px" TransferToID="RadListBoxCurrentEmployees" SelectionMode="Multiple"
                                        AllowTransfer="True" AutoPostBackOnTransfer="true" AllowReorder="False" EnableDragAndDrop="true"
                                        DataTextField="EmployeeName" DataValueField="EmployeeCode">
                                    </telerik:RadListBox>
                                </td>
                                <td align="left" valign="top">
                                    <telerik:RadListBox ID="RadListBoxCurrentEmployees" runat="server" Width="300px"
                                        Height="200px" SelectionMode="Multiple" AllowReorder="False" AutoPostBackOnReorder="true"
                                        EnableDragAndDrop="true" DataTextField="EmployeeName" DataValueField="EmployeeCode">
                                    </telerik:RadListBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" valign="bottom">
                                    &nbsp;
                                </td>
                                <td align="center" valign="bottom">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                </ContentTemplate>
            </asp:UpdatePanel>
                </telerik:RadPageView>
            </telerik:RadMultiPage>
            <telerik:RadWindowManager ID="RadWindowManager" runat="server" >
            </telerik:RadWindowManager>
    </div>
    
</asp:Content>
