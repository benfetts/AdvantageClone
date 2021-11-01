<%@ Page Title="Documents Maintenance" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="Maintenance_Documents.aspx.vb" Inherits="Webvantage.Maintenance_Documents" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <script type="text/javascript"> 
        function selectMeOnly(objRadioButton, grdName) {
            var i, obj;
            for (i = 0; i < document.all.length; i++) {
                obj = document.all(i);
                if (obj.type == "radio") {
                    if (objRadioButton.id.substr(0, grdName.length) == grdName) {
                        if (objRadioButton.id == obj.id) {
                            obj.checked = true;
                        }
                        else {
                            obj.checked = false;
                        }
                    }
                }
            }
        }
        function RadToolbarLabelssOnClientButtonClicking(sender, args) {
            var commandName = args.get_item().get_commandName();
            if (commandName == "Delete") {
                ////args.set_cancel(!confirm("Are you sure you want to delete the label?\nThis will remove the label from any documents that use it."));
                radToolBarConfirm(sender, args, "Are you sure you want to delete the label?\nThis will remove the label from any documents that use it.");
            }
        }
    </script>
</asp:Content>
<asp:Content ID="ContentBody" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div class="DO-ButtonHeader">
        <div style="float: left; text-align: left; vertical-align: middle; display: inline-block;">
            <telerik:RadTabStrip ID="RadTabStripDocumentMaintenance" runat="server" MultiPageID="RadMultiPageDocumentMaintenance"
                AutoPostBack="true" SelectedIndex="0" Width="100%">
                <Tabs>
                    <telerik:RadTab Text="Types">
                    </telerik:RadTab>
                    <telerik:RadTab Text="Labels">
                    </telerik:RadTab>
                </Tabs>
            </telerik:RadTabStrip>
        </div>
        <div style="float: right; text-align: right; display: inline-block;">
            <asp:CheckBox ID="CheckBoxShowInactive" runat="server" Text="Show Inactive" AutoPostBack="True" />
            <asp:ImageButton ID="ImageButtonExport" runat="server" SkinID="ImageButtonExportExcel" />&nbsp;&nbsp;
        </div>
    </div>
    <telerik:RadMultiPage ID="RadMultiPageDocumentMaintenance" runat="server" SelectedIndex="0">
        <telerik:RadPageView ID="RadPageViewDocumentTypes" runat="server">
            <div style="margin: 80px 0px 0px 100px;width: 90%; text-align:center;">
                <telerik:RadGrid ID="RadGridDocumentTypes" runat="server" AllowPaging="True" AllowSorting="True"
                    GridLines="None" PageSize="10" EnableEmbeddedSkins="True" ShowFooter="False"
                    AutoGenerateColumns="False" Width="770">
                    <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="True" Position="Bottom"></PagerStyle>
                    <ExportSettings ExportOnlyData="True" IgnorePaging="true" OpenInNewWindow="true" HideStructureColumns="true">
                        <Excel Format="Html" />
                    </ExportSettings>
                    <MasterTableView CommandItemDisplay="None" EditMode="InPlace" DataKeyNames="ID" InsertItemDisplay="Top">
                        <CommandItemSettings AddNewRecordText="Add" RefreshText="Refresh" ShowAddNewRecordButton="false" ShowExportToExcelButton="true" />
                        <Columns>
                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnDescription" HeaderText="Name" DataField="Name"
                                SortExpression="Name">
                                <HeaderStyle Width="500" VerticalAlign="Middle" HorizontalAlign="Left" />
                                <ItemStyle Width="500" VerticalAlign="Middle" HorizontalAlign="Left" />
                                <FooterStyle Width="500" VerticalAlign="Middle" HorizontalAlign="Left" />
                                <ItemTemplate>
                                    <asp:TextBox ID="TextBoxDescription" runat="server" Text='<%#Eval("Name") %>' SkinID="TextBoxStandard"
                                        Width="491" MaxLength="20"></asp:TextBox>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBoxDescription" runat="server" Text='<%#Eval("Name") %>' SkinID="TextBoxStandard"
                                        Width="491" MaxLength="20"></asp:TextBox>
                                </EditItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnInActive" HeaderText="Inactive" SortExpression="IsInactive" DataField="IsInactive">
                                <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" Width="30" />
                                <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" Width="30" />
                                <FooterStyle VerticalAlign="Middle" HorizontalAlign="Center" Width="30" />
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckboxInActive" runat="server" AutoPostBack="false" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:CheckBox ID="CheckboxInActive" runat="server" Checked="false" AutoPostBack="false" />
                                </EditItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnIsDefault" HeaderText="Default" SortExpression="IsDefault" DataField="IsDefault">
                                <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" Width="30" />
                                <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" Width="30" />
                                <FooterStyle VerticalAlign="Middle" HorizontalAlign="Center" Width="30" />
                                <ItemTemplate>
                                    <asp:RadioButton ID="RadioButtonIsDefault" runat="server" />  
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:RadioButton ID="RadioButtonIsDefault" runat="server" />
                                </EditItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnSave">
                                <HeaderStyle CssClass="radgrid-icon-column" />
                                <ItemStyle CssClass="radgrid-icon-column" />
                                <FooterStyle CssClass="radgrid-icon-column" />
                                <HeaderTemplate>
                                    <asp:ImageButton ID="ImageButtonSaveAll" runat="server" SkinID="ImageButtonSaveAll" ToolTip="Click to save all rows" CommandName="SaveAll" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <div id="DivSave" runat="server" class="icon-background background-color-sidebar">
                                        <asp:ImageButton ID="ImageButtonSave" runat="server" SkinID="ImageButtonSaveWhite"
                                            ToolTip="Click to save this row" CommandName="SaveRow" />
                                    </div>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <div class="icon-background background-color-sidebar">
                                        <asp:ImageButton ID="ImageButtonSaveNew" runat="server" SkinID="ImageButtonAddWhite" ToolTip="Click to add this row" CommandName="SaveNewRow" />
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
                                    <div id="DivDelete" runat="server" class="icon-background background-color-delete">
                                        <asp:ImageButton ID="ImageButtonDelete" runat="server" SkinID="ImageButtonDeleteWhite"
                                            ToolTip="Click to delete this row" CommandName="DeleteRow" />
                                    </div>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <div class="icon-background background-color-sidebar">
                                        <asp:ImageButton ID="ImageButtonCancelNew" runat="server" SkinID="ImageButtonCancelWhite" ToolTip="Cancel add row" CommandName="CancelNewRow" />
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
            </div>
        </telerik:RadPageView>
        <telerik:RadPageView ID="RadPageViewDocumentLabels" runat="server">
            <div style="margin: 40px 0px 0px 0px;" class="no-float-menu">
                <div class="no-float-menu">
                    <telerik:RadToolBar ID="RadToolbarLabels" runat="server" AutoPostBack="True" Width="100%" OnClientButtonClicking="RadToolbarLabelssOnClientButtonClicking">
                        <Items>
                            <telerik:RadToolBarButton IsSeparator="true" />
                            <telerik:RadToolBarButton SkinID="RadToolBarButtonSave" Text="" Value="Save" ToolTip="Save" />
                            <telerik:RadToolBarButton IsSeparator="true" />
                            <telerik:RadToolBarButton SkinID="RadToolBarButtonNew" Text="New" Value="New" ToolTip="Add New" CausesValidation="false" />
                            <telerik:RadToolBarButton IsSeparator="true" />
                            <telerik:RadToolBarButton SkinID="RadToolBarButtonCancel" Value="Cancel" />
                            <telerik:RadToolBarButton SkinID="RadToolBarButtonRefresh" Value="Refresh" />
                            <telerik:RadToolBarButton SkinID="RadToolBarButtonDelete" Value="Delete" CommandName="Delete"  />
                            <telerik:RadToolBarButton IsSeparator="true" Value="LastSeparator" />
                        </Items>
                    </telerik:RadToolBar>
                </div>
                
                <div class="telerik-aqua-body">
                    <div style="display: inline-block; width: 200px; vertical-align: top;">
                                <telerik:RadTreeView ID="RadTreeViewLabels" runat="server" EnableViewState="true"></telerik:RadTreeView>
                            </div>
                            <div style="display: inline-block; left: 200px; vertical-align: top;">
                                <div id="DivEditForm" runat="server" style="padding: 20px 0px 0px 50px; width: 100%;">
                                    <div style="width:100%;border-bottom: 1px solid #cecece;font-size:48px;margin: -25px 0px 16px 0px;">
                                        <asp:Label ID="LabelFormTitle" runat="server" Text="Edit"></asp:Label>
                                    </div>
                                    <div id="DivTopLevel" runat="server" class="code-description-container">
                                        <div class="code-description-label">
                                            Top Level Label
                                        </div>
                                        <div class="code-description-description">
                                            <asp:CheckBox ID="CheckBoxIsTopLevel" runat="server" />
                                        </div>
                                    </div>
                                    <div class="code-description-container">
                                        <div class="code-description-label">
                                            Name
                                        </div>
                                        <div class="code-description-description">
                                            <asp:TextBox ID="TextBoxName" runat="server" SkinID="TextBoxCodeSingleLineDescription" MaxLength="30"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="code-description-container">
                                        <div class="code-description-label">
                                            Description
                                        </div>
                                        <div class="code-description-description">
                                            <asp:TextBox ID="TextBoxDescription" runat="server" SkinID="TextBoxCodeSingleLineDescription" MaxLength="100"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="code-description-container">
                                        <div class="code-description-label">
                                            Color
                                        </div>
                                        <div class="code-description-description">
                                            <telerik:RadColorPicker ID="RadColorPickerLabelColor" runat="server" Preset="None">
                                                <telerik:ColorPickerItem Title="" Value="#FFCDD2"></telerik:ColorPickerItem>
                                                <telerik:ColorPickerItem Title="" Value="#F8BBD0"></telerik:ColorPickerItem>
                                                <telerik:ColorPickerItem Title="" Value="#E1BEE7"></telerik:ColorPickerItem>
                                                <telerik:ColorPickerItem Title="" Value="#CE93D8"></telerik:ColorPickerItem>
                                                <telerik:ColorPickerItem Title="" Value="#D1C4E9"></telerik:ColorPickerItem>
                                                <telerik:ColorPickerItem Title="" Value="#C5CAE9"></telerik:ColorPickerItem>
                                                <telerik:ColorPickerItem Title="" Value="#BBDEFB"></telerik:ColorPickerItem>
                                                <telerik:ColorPickerItem Title="" Value="#B3E5FC"></telerik:ColorPickerItem>
                                                <telerik:ColorPickerItem Title="" Value="#B2EBF2"></telerik:ColorPickerItem>
                                                <telerik:ColorPickerItem Title="" Value="#B2DFDB"></telerik:ColorPickerItem>
                                                <telerik:ColorPickerItem Title="" Value="#C8E6C9"></telerik:ColorPickerItem>
                                                <telerik:ColorPickerItem Title="" Value="#DCEDC8"></telerik:ColorPickerItem>
                                                <telerik:ColorPickerItem Title="" Value="#F0F4C3"></telerik:ColorPickerItem>
                                                <telerik:ColorPickerItem Title="" Value="#FFF9C4"></telerik:ColorPickerItem>
                                                <telerik:ColorPickerItem Title="" Value="#FFECB3"></telerik:ColorPickerItem>
                                                <telerik:ColorPickerItem Title="" Value="#FFE0B2"></telerik:ColorPickerItem>
                                                <telerik:ColorPickerItem Title="" Value="#FFCCBC"></telerik:ColorPickerItem>
                                                <telerik:ColorPickerItem Title="" Value="#D7CCC8"></telerik:ColorPickerItem>
                                                <telerik:ColorPickerItem Title="" Value="#BDBDBD"></telerik:ColorPickerItem>
                                                <telerik:ColorPickerItem Title="" Value="#B0BEC5"></telerik:ColorPickerItem>
                                                <telerik:ColorPickerItem Title="" Value="#FFFFFF"></telerik:ColorPickerItem>
                                            </telerik:RadColorPicker>
                                        </div>
                                    </div>
                                    <div class="code-description-container">
                                        <div class="code-description-label">
                                            Active
                                        </div>
                                        <div class="code-description-description">
                                            <asp:CheckBox ID="CheckBoxIsActive" runat="server" />
                                        </div>
                                    </div>
                    <%--     
                    OnClientClick="return confirm('Are you sure you want to delete this label?\nThe label will be removed from all documents that use it!\nAll sub-labels for this label will also be deleted!');" />
                        --%>
                    </div>
                </div>
                </div>                
            </div>
     </telerik:RadPageView>
    </telerik:RadMultiPage>
</asp:Content>
