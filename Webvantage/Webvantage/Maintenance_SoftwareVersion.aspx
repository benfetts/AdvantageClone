<%@ Page Title="Software Version Maintenance" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="Maintenance_SoftwareVersion.aspx.vb" Inherits="Webvantage.Maintenance_SoftwareVersion" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <style>
        .RadGrid_Metro .rgMasterTable, .RadGrid_Metro .rgDetailTable, .RadGrid_Metro .rgGroupPanel table, .RadGrid_Metro .rgCommandRow table, .RadGrid_Metro .rgEditForm table, .RadGrid_Metro .rgPager table, .RadTabStrip_Metro .rtsLI, .RadForm.rfdTextbox input[type="text"].rfdDecorated, .RadForm.rfdTextbox input[type="password"].rfdDecorated, .RadForm.rfdTextarea textarea, .RadForm.rfdTextarea textarea[disabled].rfdDecorated:hover, .RadForm.rfdTextbox input[disabled][type="text"].rfdDecorated:hover, .RadForm.rfdTextbox input[disabled][type="password"].rfdDecorated:hover, .RadForm.rfdLabel label, .RadForm .rfdDecorated, .RadForm .rfdCheckboxChecked, .RadForm .rfdInputDisabled.rfdCheckboxChecked:hover, .RadForm .rfdCheckboxUnchecked, .RadForm .rfdInputDisabled.rfdCheckboxUnchecked:hover, .RadForm.rfdLabel .rfdAspLabel, .RadForm .rfdRadioUnchecked, .RadForm .rfdInputDisabled.rfdRadioUnchecked:hover, .RadForm .rfdRadioUnchecked:hover, .RadForm .rfdRadioChecked, .RadForm .rfdInputDisabled.rfdRadioChecked:hover, .RadForm .rfdRadioChecked:hover, .RadForm .riTextBox, .RadForm .rfdValidationSummaryControl, .RadForm .rfdLoginControl, .RadForm legend {
                font-family: "Open Sans", Calibri, Tahoma, Verdana, Arial, sans-serif !important;
        }
    </style>

    <div class="telerik-aqua-body">
        <telerik:RadScriptBlock ID="RadScriptBlockMaintenanceAlertAssignments" runat="server">
            <script type="text/javascript">
                function RadGridVersions_RowDoubleClick(sender, eventArgs) {
                    RadGridVersionsRowDoubleClick(eventArgs.get_itemIndexHierarchical());
                }
                function RadGridVersionsRowDoubleClick(itemIndex) {
                    __doPostBack("<%= RadGridVersions.UniqueID %>", "IndexOfRowDoubleClicked:" + itemIndex);
                }  
            </script>
        </telerik:RadScriptBlock>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td width="100%">
                    <telerik:RadTabStrip ID="RadTabStrip1" runat="server" MultiPageID="RadMultiPage1"
                        AutoPostBack="true" SelectedIndex="0" Width="100%">
                        <Tabs>
                            <telerik:RadTab Text="Versions">
                            </telerik:RadTab>
                            <telerik:RadTab Text="Version Detail">
                            </telerik:RadTab>
                            <telerik:RadTab Text="Software Products" Visible="false">
                            </telerik:RadTab>
                        </Tabs>
                    </telerik:RadTabStrip>
                </td>
               
            </tr>
        </table>
        <table cellpadding="0" cellspacing="0" width="100%" align="center" border="0">
            <tr>
                 <td style="margin-top: 6px;" align="right" valign="middle">
                    <asp:CheckBox ID="CheckBoxShowInactive" runat="server" Text="Show Inactive" AutoPostBack="True" />
                    <asp:ImageButton ID="ImageButtonExport" runat="server" SkinID="ImageButtonExportExcel" />&nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td align="left">
                    <telerik:RadMultiPage ID="RadMultiPage1" runat="server" SelectedIndex="0">
                        <telerik:RadPageView ID="RadPageViewVersions" runat="server">
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                                <br />
                                <telerik:RadGrid ID="RadGridVersions" runat="server" AllowPaging="True" AllowSorting="True"
                                    GridLines="None" PageSize="10" EnableEmbeddedSkins="True" ShowFooter="False"
                                    AutoGenerateColumns="False" Width="710">
                                    <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="True" Position="Bottom" Height="20px">
                                    </PagerStyle>
                                    <MasterTableView CommandItemDisplay="None" EditMode="InPlace" DataKeyNames="VERSION_ID"
                                        InsertItemDisplay="Top">
                                        <CommandItemSettings AddNewRecordText="Add" RefreshText="Refresh" />
                                        <Columns>
                                            <telerik:GridTemplateColumn UniqueName="ColVERSION" HeaderText="Version" SortExpression="VERSION">
                                                <HeaderStyle Width="120" VerticalAlign="Middle" HorizontalAlign="Left" />
                                                <ItemStyle Width="120" VerticalAlign="Middle" HorizontalAlign="Left" />
                                                <FooterStyle Width="120" VerticalAlign="Middle" HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:TextBox ID="TxtVERSION" runat="server" Width="115" Text='<%#Eval("VERSION") %>' SkinID="TextBoxStandard"
                                                        CssClass="RequiredInput" MaxLength="10"></asp:TextBox>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TxtVERSION" runat="server" Width="115" Text='<%#Eval("VERSION") %>' SkinID="TextBoxStandard"
                                                        CssClass="RequiredInput" MaxLength="10"></asp:TextBox>
                                                </EditItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn UniqueName="ColVERSION_DESC" HeaderText="Description"
                                                SortExpression="VERSION_DESC">
                                                <HeaderStyle Width="434" VerticalAlign="Middle" HorizontalAlign="Left" />
                                                <ItemStyle Width="434" VerticalAlign="Middle" HorizontalAlign="Left" />
                                                <FooterStyle Width="434" VerticalAlign="Middle" HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:TextBox ID="TxtVERSION_DESC" runat="server" Width="434" Text='<%#Eval("VERSION_DESC") %>' SkinID="TextBoxStandard"
                                                        MaxLength="100"></asp:TextBox>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TxtVERSION_DESC" runat="server" Width="434" Text='<%#Eval("VERSION_DESC") %>' SkinID="TextBoxStandard"
                                                        MaxLength="100"></asp:TextBox>
                                                </EditItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn UniqueName="ColACTIVE_FLAG" HeaderText="Inactive" SortExpression="ACTIVE_FLAG">
                                                <HeaderStyle  VerticalAlign="Middle" HorizontalAlign="Center" />
                                                <ItemStyle  VerticalAlign="Middle" HorizontalAlign="Center" />
                                                <FooterStyle  VerticalAlign="Middle" HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="ChkACTIVE_FLAG" runat="server" AutoPostBack="false" />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:CheckBox ID="ChkACTIVE_FLAG" runat="server" Checked="false" />
                                                </EditItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn UniqueName="ColSave">
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
                                            <telerik:GridTemplateColumn UniqueName="ColDelete">
                                                <HeaderStyle CssClass="radgrid-icon-column" />
                                                <ItemStyle CssClass="radgrid-icon-column" />
                                                <FooterStyle CssClass="radgrid-icon-column" />
                                                <ItemTemplate>
                                                    <div id="DivDelete" runat="server" class="icon-background background-color-delete">
                                                        <asp:ImageButton ID="ImgBtnDelete" runat="server" SkinID="ImageButtonDeleteWhite"
                                                            ToolTip="Click to delete this row" CommandName="DeleteRow" CommandArgument='<%#Eval("VERSION_ID") %>' />
                                                     </div>
                                               </ItemTemplate>
                                                <EditItemTemplate>
                                                    <div class="icon-background background-color-delete">
                                                        <asp:ImageButton ID="ImgBtnCancel" runat="server" SkinID="ImageButtonCancelWhite"
                                                            ToolTip="Cancel add row" CommandName="CancelNewRow" />
                                                    </div>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:ImageButton ID="ImgBtnSaveAll" runat="server" SkinID="ImageButtonSaveAll"
                                                        ToolTip="Click to save all rows" CommandName="SaveAll" />
                                                </FooterTemplate>
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
                                        <ClientEvents OnRowDblClick="RadGridVersions_RowDoubleClick" />
                                    </ClientSettings>
                                </telerik:RadGrid>
                                <br />
                </ContentTemplate>
            </asp:UpdatePanel>
                        </telerik:RadPageView>
                        <telerik:RadPageView ID="RadPageViewVersionDetail" runat="server">
            <asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                                <table width="750" border="0" cellspacing="2" cellpadding="0">
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <fieldset>
                                                <legend>Version:</legend>
                                                <telerik:RadComboBox ID="DropDownListVersions" runat="server" AutoPostBack="true" SkinID="RadComboBoxStandard"
                                                    Width="541">
                                                </telerik:RadComboBox>
                                            </fieldset>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <fieldset>
                                                <legend>Builds:</legend>
                                                <telerik:RadGrid ID="RadGridBuilds" runat="server" AllowPaging="True" AllowSorting="True"
                                                    GridLines="None" PageSize="10" EnableEmbeddedSkins="True" ShowFooter="False"
                                                    AutoGenerateColumns="False" Width="780">
                                                    <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="True" Position="Bottom" Height="20px">
                                                    </PagerStyle>
                                                    <MasterTableView CommandItemDisplay="None" EditMode="InPlace" DataKeyNames="BUILD_ID"
                                                        InsertItemDisplay="Top">
                                                        <CommandItemSettings AddNewRecordText="Add" RefreshText="Refresh" />
                                                        <Columns>
                                                            <telerik:GridTemplateColumn UniqueName="ColBUILD" HeaderText="Build" SortExpression="BUILD">
                                                                <HeaderStyle Width="120" VerticalAlign="Middle" HorizontalAlign="Left" />
                                                                <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                                                                <FooterStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="TxtBUILD" runat="server" Width="115" Text='<%#Eval("BUILD") %>' SkinID="TextBoxStandard"
                                                                        CssClass="RequiredInput" MaxLength="10"></asp:TextBox>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="TxtBUILD" runat="server" Width="115" Text='<%#Eval("BUILD") %>' SkinID="TextBoxStandard"
                                                                        CssClass="RequiredInput" MaxLength="10"></asp:TextBox>
                                                                </EditItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn UniqueName="ColBUILD_DESC" HeaderText="Description" SortExpression="BUILD_DESC">
                                                                <HeaderStyle Width="400" VerticalAlign="Middle" HorizontalAlign="Left" />
                                                                <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                                                                <FooterStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="TxtBUILD_DESC" runat="server" Width="434" Text='<%#Eval("BUILD_DESC") %>' SkinID="TextBoxStandard"
                                                                        MaxLength="100"></asp:TextBox>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="TxtBUILD_DESC" runat="server" Width="434" Text='<%#Eval("BUILD_DESC") %>' SkinID="TextBoxStandard"
                                                                        MaxLength="100"></asp:TextBox>
                                                                </EditItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn UniqueName="ColACTIVE_FLAG" HeaderText="Inactive" SortExpression="ACTIVE_FLAG">
                                                                <HeaderStyle  VerticalAlign="Middle" HorizontalAlign="Center" />
                                                                <ItemStyle  VerticalAlign="Middle" HorizontalAlign="Center" />
                                                                <FooterStyle  VerticalAlign="Middle" HorizontalAlign="Center" />
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="ChkACTIVE_FLAG" runat="server" AutoPostBack="false" />
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:CheckBox ID="ChkACTIVE_FLAG" runat="server" Checked="false" />
                                                                </EditItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn UniqueName="ColSave">
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
                                                            <telerik:GridTemplateColumn UniqueName="ColDelete">
                                                                <HeaderStyle CssClass="radgrid-icon-column" />
                                                                <ItemStyle CssClass="radgrid-icon-column" />
                                                                <FooterStyle CssClass="radgrid-icon-column" />
                                                                <ItemTemplate>
                                                                    <div class="icon-background background-color-delete">
                                                                        <asp:ImageButton ID="ImgBtnDelete" runat="server" SkinID="ImageButtonDeleteWhite"
                                                                            ToolTip="Click to delete this row" CommandName="DeleteRow" />
                                                                     </div>
                                                               </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <div class="icon-background background-color-delete">
                                                                        <asp:ImageButton ID="ImgBtnCancel" runat="server" SkinID="ImageButtonCancelWhite"
                                                                            ToolTip="Cancel add row" CommandName="CancelNewRow" />
                                                                    </div>
                                                                </EditItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:ImageButton ID="ImgBtnSaveAll" runat="server" SkinID="ImageButtonSaveAll"
                                                                        ToolTip="Click to save all rows" CommandName="SaveAll" />
                                                                </FooterTemplate>
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
                                                        <ClientEvents />
                                                    </ClientSettings>
                                                </telerik:RadGrid>
                                            </fieldset>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <fieldset>
                                                <legend>Version applies to:</legend>
                                                <asp:CheckBox ID="CheckBoxVersionAppliesToJobLevel" runat="server" Text="Job Level"
                                                    AutoPostBack="true" />
                                                <asp:CheckBox ID="CheckBoxVersionAppliesToJobComponentLevel" runat="server" Text="Job Component Level"
                                                    AutoPostBack="true" />
                                                <br />
                                                <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel2" runat="server" EnableEmbeddedSkins="false" CssClass="rwLoading" Height="100%" Width="100%">
                                                </telerik:RadAjaxLoadingPanel>
            <asp:UpdatePanel runat="server" ID="UpdatePanel2" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                                                    <telerik:RadGrid ID="RadGridSoftwareLevel" runat="server" ShowFooter="false" AllowMultiRowSelection="True"
                                                        AllowSorting="true" Height="300" AutoGenerateColumns="False" GridLines="None"
                                                        EnableEmbeddedSkins="True">
                                                        <StatusBarSettings LoadingText="Loading Data" ReadyText="Data Loaded." />
                                                        <ClientSettings EnablePostBackOnRowClick="True">
                                                            <Scrolling AllowScroll="true" ScrollHeight="300" />
                                                            <Selecting AllowRowSelect="True" EnableDragToSelectRows="False" />
                                                        </ClientSettings>
                                                        <MasterTableView AutoGenerateColumns="False" DataKeyNames="code,JOB_NUMBER,JOB_COMPONENT_NBR,ACTIVE_ON_THIS_VERSION">
                                                            <RowIndicatorColumn Visible="False">
                                                                <HeaderStyle Width="20px" />
                                                            </RowIndicatorColumn>
                                                            <ExpandCollapseColumn Resizable="False" Visible="False">
                                                                <HeaderStyle Width="20px" />
                                                            </ExpandCollapseColumn>
                                                            <Columns>
                                                                <telerik:GridClientSelectColumn UniqueName="ColumnClientSelect">
                                                                    <HeaderStyle HorizontalAlign="center" Width="5px" />
                                                                    <ItemStyle HorizontalAlign="center" Width="5px" />
                                                                    <FooterStyle HorizontalAlign="center" Width="5px" />
                                                                </telerik:GridClientSelectColumn>
                                                                <telerik:GridBoundColumn DataField="description" DataType="System.String" HeaderText="Description"
                                                                    ReadOnly="True" SortExpression="description" UniqueName="ColumnDescription">
                                                                    <HeaderStyle HorizontalAlign="left" />
                                                                    <ItemStyle HorizontalAlign="left" />
                                                                    <FooterStyle HorizontalAlign="left" />
                                                                </telerik:GridBoundColumn>
                                                                <telerik:GridBoundColumn DataField="CDP" DataType="System.String" HeaderText="CDP"
                                                                    ReadOnly="True" SortExpression="CDP" UniqueName="ColumnCDP">
                                                                    <HeaderStyle HorizontalAlign="left" Width="190" />
                                                                    <ItemStyle HorizontalAlign="left" Width="190" />
                                                                    <FooterStyle HorizontalAlign="left" Width="190" />
                                                                </telerik:GridBoundColumn>
                                                            </Columns>
                                                        </MasterTableView>
                                                    </telerik:RadGrid>
                </ContentTemplate>
            </asp:UpdatePanel>
                                                <br />
                                                <asp:Button ID="ButtonSaveSoftwareLevel" runat="server" Text="Save" Visible="false" />
                                            </fieldset>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                </ContentTemplate>
            </asp:UpdatePanel>
                        </telerik:RadPageView>
                        <telerik:RadPageView ID="RadPageViewSoftwareProduct" runat="server">
                            <br />
            <asp:UpdatePanel runat="server" ID="UpdatePanel3" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                                <telerik:RadGrid ID="RadGridSoftwareProduct" runat="server" AllowPaging="True" AllowSorting="True"
                                    AutoGenerateColumns="False" AllowMultiRowSelection="false" GridLines="None" PageSize="5"
                                    EnableEmbeddedSkins="True" ShowFooter="False" Width="700">
                                    <ClientSettings EnablePostBackOnRowClick="True">
                                        <Scrolling AllowScroll="false" ScrollHeight="300" />
                                        <Selecting AllowRowSelect="True" EnableDragToSelectRows="false" />
                                    </ClientSettings>
                                    <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="True" Position="Bottom" Height="20px">
                                    </PagerStyle>
                                    <MasterTableView CommandItemDisplay="None" EditMode="InPlace" DataKeyNames="PRODUCT_ID"
                                        InsertItemDisplay="Top">
                                        <CommandItemSettings AddNewRecordText="Add" RefreshText="Refresh" />
                                        <Columns>
                                            <telerik:GridClientSelectColumn UniqueName="ColumnClientSelect">
                                                <HeaderStyle HorizontalAlign="center" Width="5px" />
                                                <ItemStyle HorizontalAlign="center" Width="5px" />
                                                <FooterStyle HorizontalAlign="center" Width="5px" />
                                            </telerik:GridClientSelectColumn>
                                            <telerik:GridTemplateColumn UniqueName="ColPRODUCT_DESC" HeaderText="Product Name"
                                                SortExpression="PRODUCT_DESC">
                                                <HeaderStyle Width="500" VerticalAlign="Middle" HorizontalAlign="Left" />
                                                <ItemStyle Width="500" VerticalAlign="Middle" HorizontalAlign="Left" />
                                                <FooterStyle Width="500" VerticalAlign="Middle" HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:TextBox ID="TxtPRODUCT_DESC" runat="server" Text='<%#Eval("PRODUCT_DESC") %>' SkinID="TextBoxStandard"
                                                        Width="491" MaxLength="100"></asp:TextBox>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TxtPRODUCT_DESC" runat="server" Text='<%#Eval("PRODUCT_DESC") %>' SkinID="TextBoxStandard"
                                                        Width="491" MaxLength="100"></asp:TextBox>
                                                </EditItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn UniqueName="ColACTIVE_FLAG" HeaderText="Inactive" SortExpression="ACTIVE_FLAG">
                                                <HeaderStyle  VerticalAlign="Middle" HorizontalAlign="Center" />
                                                <ItemStyle  VerticalAlign="Middle" HorizontalAlign="Center" />
                                                <FooterStyle  VerticalAlign="Middle" HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="ChkACTIVE_FLAG" runat="server" AutoPostBack="false" />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:CheckBox ID="ChkACTIVE_FLAG" runat="server" Checked="false" AutoPostBack="false" />
                                                </EditItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn UniqueName="ColSave">
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
                                            <telerik:GridTemplateColumn UniqueName="ColDelete">
                                                <HeaderStyle  VerticalAlign="Middle" HorizontalAlign="Center" />
                                                <ItemStyle  VerticalAlign="Middle" HorizontalAlign="Center" />
                                                <FooterStyle  VerticalAlign="Middle" HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <div class="icon-background background-color-delete">
                                                        <asp:ImageButton ID="ImgBtnDelete" runat="server" SkinID="ImageButtonDeleteWhite"
                                                            ToolTip="Click to delete this row" CommandName="DeleteRow" />
                                                     </div>
                                               </ItemTemplate>
                                                <EditItemTemplate>
                                                    <div class="icon-background background-color-sidebar">
                                                        <asp:ImageButton ID="ImgBtnCancelNew" runat="server" SkinID="ImageButtonCancelWhite"
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
                                <div style="width: 706px;">
                                    <fieldset id="FieldsetSoftwareProductVersions" runat="server">
                                        <legend>Included versions:</legend>
                                        <table>
                                            <tr>
                                                <td align="left">
                                                    <telerik:RadListBox ID="RadListBoxSoftwareProductVersions" runat="server" SelectionMode="Multiple"
                                                        Width="680" Height="150">
                                                    </telerik:RadListBox>
                                                </td>
                                            </tr>
                                        </table>
                                        <br />
                                        <asp:Button ID="ButtonSoftwareProductVersionsSave" runat="server" Text="Save" />
                                    </fieldset>
                                </div>
                                <br />
                </ContentTemplate>
            </asp:UpdatePanel>
                        </telerik:RadPageView>
                    </telerik:RadMultiPage>
                </td>

            </tr>
        </table>
    </div>

</asp:Content>
