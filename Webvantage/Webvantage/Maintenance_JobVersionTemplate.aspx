<%@ Page Title="Job Version Template Maintenance" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="Maintenance_JobVersionTemplate.aspx.vb" Inherits="Webvantage.Maintenance_JobVersionTemplate" %>

<asp:Content ID="ContentJobVersionTemplate" ContentPlaceHolderID="ContentPlaceHolderMain"
    runat="server">
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
        <script type="text/javascript">
            function RefreshGrid(radWindowCaller) {
                __doPostBack('onclick#Refresh', 'Refresh');
            };
            function SaveFromPopUp(radWindowCaller) {
                __doPostBack('onclick#Save', 'Save');
            };
            function RealPostBack(eventTarget, eventArgument) {
                __doPostBack(eventTarget, eventArgument);
            };
            function HidePopUpWindows(radWindowCaller) {
                __doPostBack('onclick#Refresh', 'HidePopups');
            };
            function OnClientClose(sender, EventArgs) {
                __doPostBack('onclick#Refresh', 'Refresh');
            };
            function RadGridJobVersionTemplates_RowDoubleClick(sender, eventArgs) {
                __doPostBack("<%= RadGridJobVersionTemplates.UniqueID %>", "IndexOfRowDoubleClicked:" + eventArgs.get_itemIndexHierarchical());
            };
        </script>
    </telerik:RadScriptBlock>
    <div class="telerik-aqua-body" style="margin-top: 5px!important;">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="75%">
                        <telerik:RadTabStrip ID="RadTabStripJobVersionTemplates" runat="server" MultiPageID="RadMultiPageJobVersionTemplates"
                            AutoPostBack="true" SelectedIndex="0">
                            <Tabs>
                                <telerik:RadTab Text="Job Version Templates">
                                </telerik:RadTab>
                                <telerik:RadTab Text="Job Version Template Detail">
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
            <telerik:RadMultiPage ID="RadMultiPageJobVersionTemplates" runat="server" SelectedIndex="0">
                <telerik:RadPageView ID="RadPageViewJobVersionTemplates" runat="server">
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                        <br />
                        <telerik:RadGrid ID="RadGridJobVersionTemplates" runat="server" AllowPaging="True"
                            AllowSorting="True" GridLines="None" PageSize="10" EnableEmbeddedSkins="True"
                            ShowFooter="False" AutoGenerateColumns="False" Width="780">
                            <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="True" Position="Bottom" Height="20px">
                            </PagerStyle>
                            <MasterTableView CommandItemDisplay="None" EditMode="InPlace" DataKeyNames="Code, Description, IsInactive"
                                InsertItemDisplay="Top">
                                <CommandItemSettings AddNewRecordText="Add" RefreshText="Refresh" />
                                <Columns>
                                    <telerik:GridTemplateColumn UniqueName="GridTemplateColumnJobVersionTemplateCode"
                                        HeaderText="Code" SortExpression="Code">
                                        <HeaderStyle Width="75" VerticalAlign="Middle" HorizontalAlign="Left" />
                                        <ItemStyle Width="75" VerticalAlign="Middle" HorizontalAlign="Left" />
                                        <FooterStyle Width="75" VerticalAlign="Middle" HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <%# Eval("Code")%>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBoxJobVersionTemplateCodeEditTextBox" runat="server" MaxLength="6" SkinID="TextBoxStandard"
                                                Width="75"></asp:TextBox>
                                        </EditItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn UniqueName="GridTemplateColumnJobVersionTemplateDescription"
                                        HeaderText="Description" SortExpression="Description">
                                        <HeaderStyle Width="300" VerticalAlign="Middle" HorizontalAlign="Left" />
                                        <ItemStyle Width="300" VerticalAlign="Middle" HorizontalAlign="Left" />
                                        <FooterStyle Width="300" VerticalAlign="Middle" HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:TextBox ID="TextBoxJobVersionTemplateDescription" runat="server" Text='<%#Eval("Description") %>'
                                                MaxLength="40" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBoxJobVersionTemplateDescriptionEditTextBox" runat="server"
                                                MaxLength="40" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
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
                                            <div class="icon-background background-color-sidebar">
                                                <asp:ImageButton ID="ImageButtonCancel" runat="server" SkinID="ImageButtonCancelWhite"
                                                    ToolTip="Cancel add row" CommandName="CancelNewRow" />
                                            </div>
                                        </EditItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn UniqueName="GridTemplateColumnSync">
                                        <HeaderStyle CssClass="radgrid-icon-column" />
                                        <ItemStyle CssClass="radgrid-icon-column" />
                                        <FooterStyle CssClass="radgrid-icon-column" />
                                        <ItemTemplate>
                                            <div class="icon-background background-color-sidebar">
                                                <asp:ImageButton ID="ImageButtonSync" runat="server" SkinID="ImageButtonRefreshWhite" ToolTip="Click to sync all job/comp" CommandName="Sync" />
                                            </div>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <div class="icon-background background-color-sidebar" style="display:none;">
                                                <asp:ImageButton ID="ImageButtonSyncEdit" runat="server" SkinID="ImageButtonRefreshWhite" ToolTip="Click to sync all job/comp" CommandName="Sync" Visible="false" />
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
                                <ClientEvents OnRowDblClick="RadGridJobVersionTemplates_RowDoubleClick" />
                            </ClientSettings>
                        </telerik:RadGrid>
                        <br />
                </ContentTemplate>
            </asp:UpdatePanel>
                </telerik:RadPageView>
                <telerik:RadPageView ID="RadPageViewJobVersionTemplateDetail" runat="server">
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
                                    Job Version Template:
                                    <telerik:RadComboBox ID="DropDownListJobVersionTemplates" runat="server" AutoPostBack="true" SkinID="RadComboBoxStandard"
                                        Width="541" DataTextField="Description" DataValueField="Code">
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
                                    <asp:CheckBox ID="CheckBoxJobVersionTemplateIsInactive" runat="server" Text="Inactive"
                                        AutoPostBack="True" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left" valign="bottom">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                        <br />
                        <telerik:RadGrid ID="RadGridJobVersionTemplateDetails" runat="server" AllowPaging="false"
                            AllowSorting="false" GridLines="None" EnableEmbeddedSkins="True"
                            ShowFooter="False" AutoGenerateColumns="False" Width="770">
                            <ClientSettings AllowRowsDragDrop="false">
                                <Selecting AllowRowSelect="false" EnableDragToSelectRows="false" />
                            </ClientSettings>
                            <MasterTableView CommandItemDisplay="None" EditMode="InPlace" DataKeyNames="ID" InsertItemDisplay="Top">
                                <CommandItemSettings AddNewRecordText="Add" RefreshText="Refresh" />
                                <Columns>
                                    <telerik:GridTemplateColumn UniqueName="GridTemplateColumnJobVersionTemplateDetailID" HeaderText="ID" Visible="false">
                                        <HeaderStyle Width="10" VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                                        <FooterStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <%# Eval("ID")%>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn UniqueName="GridTemplateColumnMoveUp">
                                        <HeaderStyle  VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <ItemStyle  VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <FooterStyle  VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <div class="icon-background background-color-sidebar">
                                                <asp:ImageButton ID="ImageButtonMoveUp" runat="server" ImageUrl="~/Images/Icons/White/256/arrow_up.png" CssClass="icon-image"
                                                    ToolTip="Click to move this row up" CommandName="MoveUp" />
                                            </div>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <div class="icon-background background-color-sidebar" style="display: none;">
                                                <asp:ImageButton ID="ImageButtonMoveUpEditButton" runat="server" SkinID="ImageButtonEditWhite" Visible="false">
                                                </asp:ImageButton>
                                            </div>
                                        </EditItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn UniqueName="GridTemplateColumnMoveDown">
                                        <HeaderStyle  VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <ItemStyle  VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <FooterStyle  VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <div class="icon-background background-color-sidebar">
                                                <asp:ImageButton ID="ImageButtonMoveDown" runat="server" ImageUrl="~/Images/Icons/White/256/arrow_down.png" CssClass="icon-image"
                                                    ToolTip="Click to move this row down" CommandName="MoveDown" />
                                            </div>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <div class="icon-background background-color-sidebar" style="display: none;">
                                                <asp:ImageButton ID="ImageButtonMoveDownEditButton" runat="server" SkinID="ImageButtonEditWhite" Visible="false">
                                                </asp:ImageButton>
                                            </div>
                                        </EditItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn UniqueName="GridTemplateColumnJobVersionTemplateDetailLabel"
                                        HeaderText="Label">
                                        <HeaderStyle Width="150" VerticalAlign="Middle" HorizontalAlign="Left" />
                                        <ItemStyle Width="150" VerticalAlign="Middle" HorizontalAlign="Left" />
                                        <FooterStyle Width="150" VerticalAlign="Middle" HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:TextBox ID="TextBoxJobVersionTemplateDetailLabel" runat="server" Text='<%#Eval("Label") %>' SkinID="TextBoxStandard"
                                                MaxLength="25" Width="150"></asp:TextBox>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBoxJobVersionTemplateDetailLabelEditTextBox" runat="server" SkinID="TextBoxStandard"
                                                MaxLength="25" Width="150"></asp:TextBox>
                                        </EditItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn UniqueName="GridTemplateColumnJobVersionTemplateDetailDatabaseTypeDescription"
                                        HeaderText="Database Type">
                                        <HeaderStyle Width="200" VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <ItemStyle Width="200" VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <FooterStyle Width="200" VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <telerik:RadComboBox ID="DropDownListJobVersionTemplateDetailDatabaseType" runat="server" InputCssClass="no-border" SkinID="RadComboBoxStandard"
                                                AutoPostBack="true" DataTextField="Description" DataValueField="ID" Width="200" OnSelectedIndexChanged="RadComboBoxItem_SelectedIndexChanged" >
                                            </telerik:RadComboBox>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <telerik:RadComboBox ID="DropDownListJobVersionTemplateDetailDatabaseTypeEditDropDownList" InputCssClass="no-border" SkinID="RadComboBoxStandard"
                                                runat="server" AutoPostBack="true" DataTextField="Description" DataValueField="ID" OnSelectedIndexChanged="RadComboBoxItem_SelectedIndexChanged" 
                                                Width="200">
                                            </telerik:RadComboBox>
                                        </EditItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn UniqueName="GridTemplateColumnIsInactive" HeaderText="On">
                                        <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:CheckBox ID="CheckBoxIsInactive" runat="server" AutoPostBack="false" Checked='<%#Eval("IsInactive") %>' />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:CheckBox ID="CheckBoxIsInactiveEditCheckBox" runat="server" AutoPostBack="false"
                                                Checked="false"></asp:CheckBox>
                                        </EditItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn UniqueName="GridTemplateColumnIsRequired" HeaderText="Required">
                                        <HeaderStyle Width="55" VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <ItemStyle Width="55" VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <FooterStyle Width="55" VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:CheckBox ID="CheckBoxIsRequired" runat="server" Checked='<%#Eval("IsRequired") %>' />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:CheckBox ID="CheckBoxIsRequiredEditCheckBox" runat="server" Checked="false">
                                            </asp:CheckBox>
                                        </EditItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn UniqueName="GridTemplateColumnJobVersionTemplateDetailInstructions"
                                        HeaderText="Instructions">
                                        <HeaderStyle Width="200" VerticalAlign="Middle" HorizontalAlign="Left" />
                                        <ItemStyle Width="200" VerticalAlign="Middle" HorizontalAlign="Left" />
                                        <FooterStyle Width="200" VerticalAlign="Middle" HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:TextBox ID="TextBoxJobVersionTemplateDetailInstructions" TextMode="MultiLine" runat="server" Text='<%#Eval("Instructions") %>'
                                                SkinID="TextBoxStandard" MaxLength="225" Width="200"></asp:TextBox>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBoxJobVersionTemplateDetailInstructionsEditTextBox" runat="server" TextMode="MultiLine"
                                                SkinID="TextBoxStandard" MaxLength="225" Width="200"></asp:TextBox>
                                        </EditItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn UniqueName="GridTemplateColumnJobVersionTemplateDetailJobTemplateMapping"
                                        HeaderText="Job Template Mapping">
                                        <HeaderStyle Width="200" VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <ItemStyle Width="200" VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <FooterStyle Width="200" VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <telerik:RadComboBox ID="DropDownListJobVersionTemplateDetailJobTemplateMapping" runat="server" InputCssClass="no-border" SkinID="RadComboBoxStandard"
                                                AutoPostBack="false" DataTextField="Description" DataValueField="Code" Width="200">
                                            </telerik:RadComboBox>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <telerik:RadComboBox ID="DropDownListJobVersionTemplateDetailJobTemplateMappingEditDropDownList" InputCssClass="no-border" SkinID="RadComboBoxStandard"
                                                runat="server" AutoPostBack="false" DataTextField="Description" DataValueField="Code"
                                                Width="200">
                                            </telerik:RadComboBox>
                                        </EditItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn UniqueName="GridTemplateColumnUserDefinedListValues">
                                        <HeaderStyle  VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <ItemStyle  VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <FooterStyle  VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <div id="DivUserDefinedListValues" runat="server" class="icon-background background-color-sidebar">
                                                <asp:ImageButton ID="ImageButtonUserDefinedListValues" runat="server" SkinID="ImageButtonAddWhite"
                                                    ToolTip="Click to modify list" CommandName="ModifyUserDefinedListValues" 
                                                    OnClick="UserDefinedListValues_Click" />
                                            </div>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <div class="icon-background background-color-sidebar" style="display: none;">
                                                <asp:ImageButton ID="ImageButtonUserDefinedListValuesEditButton" runat="server" SkinID="ImageButtonEditWhite"
                                                    Visible="false"></asp:ImageButton>
                                            </div>
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
                        </telerik:RadGrid>
                        <telerik:RadWindowManager ID="RadWindowManager" runat="server"  >
                        </telerik:RadWindowManager>
                        <br />
                </ContentTemplate>
            </asp:UpdatePanel>
                </telerik:RadPageView>
            </telerik:RadMultiPage>
    </div>
    
</asp:Content>
