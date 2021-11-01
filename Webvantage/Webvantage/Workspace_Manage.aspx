<%@ Page Title="Workspace Manager" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="Workspace_Manage.aspx.vb" Inherits="Webvantage.Workspace_Manage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <asp:HiddenField ID="HiddenFieldCurrentWorkspaceId" runat="server" />
    <div class="telerik-aqua-body" style="margin-top: 5px !important;">
        <div style="margin: 0px 0px 4px 0px;">
                <telerik:RadTabStrip ID="RadTabStripWorkspaceManager" runat="server" MultiPageID="RadMultiPageWorkspaceManager">
                    <Tabs>
                        <telerik:RadTab Text="Workspaces" Value="Workspaces" Selected="true">
                        </telerik:RadTab>
                        <telerik:RadTab Text="Templates" Value="Templates">
                        </telerik:RadTab>
                    </Tabs>
                </telerik:RadTabStrip>
            </div>
            <telerik:RadMultiPage ID="RadMultiPageWorkspaceManager" runat="server">
                <telerik:RadPageView ID="RadPageViewWorkspaces" runat="server" Selected="true">
                    <ew:CollapsablePanel ID="CollapsablePanelClientPortalWorkspaceOptions" runat="server" TitleText="Workspace Options">
                        <table>
                            <tr>
                                <td>
                                    <asp:CheckBox ID="CheckBoxFloatObjects" runat="server" Text="Float Objects" AutoPostBack="true" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:RadioButton ID="RadioButtonMenuSingleNode" runat="server" Text="Short Menu" GroupName="MainMenuType"
                                        AutoPostBack="true" />
                                    <asp:RadioButton ID="RadioButtonMenuFull" runat="server" Text="Full Menu" GroupName="MainMenuType"
                                        AutoPostBack="true" />
                                </td>
                            </tr>
                        </table>
                    </ew:CollapsablePanel>
                    <ew:CollapsablePanel ID="CollapsablePanelWorkspaces" runat="server" TitleText="Workspaces">
                        <div style="margin-top: 5px;max-width: 100%!important;width: 100%;margin: auto;float: left;display: inline-block;text-align: center;">
                           <telerik:RadToolBar ID="RadToolBarWorkspaces" runat="server" Width="100%">
                            <Items>
                                <telerik:RadToolBarButton IsSeparator="true">
                                </telerik:RadToolBarButton>
                                <telerik:RadToolBarButton Text="Save Order" Value="Save" CommandName="Save" SkinID="RadToolBarButtonSave"
                                    ToolTip="Save the order of your Workspaces">
                                </telerik:RadToolBarButton>
                                <telerik:RadToolBarButton IsSeparator="true">
                                </telerik:RadToolBarButton>
                                <telerik:RadToolBarButton Text="Add" Value="Add" CommandName="Add" SkinID="RadToolBarButtonNew"
                                    ToolTip="Add a new Workspace">
                                </telerik:RadToolBarButton>
                                <telerik:RadToolBarButton Text="Save Template" Value="SaveAsTemplate" CommandName="SaveAsTemplate" ToolTip="Save your Workspaces as a Template">
                                </telerik:RadToolBarButton>
                                <telerik:RadToolBarButton IsSeparator="true">
                                </telerik:RadToolBarButton>
                                <telerik:RadToolBarButton Value="Refresh" CommandName="Refresh" SkinID="RadToolBarButtonRefresh">
                                </telerik:RadToolBarButton>
                            </Items>
                        </telerik:RadToolBar>
                        </div>
                        <div id="DivNewWorkspace" runat="server" style="padding-bottom: 8px;">
                            <fieldset>
                                <legend>New Workspace Name</legend>
                                <table cellpadding="0" cellspacing="0" border="0">
                                    <tr>
                                        <td width="650">
                                            <asp:TextBox ID="TextBoxNewWorkspaceName" runat="server" Width="630" MaxLength="50" SkinID="TextBoxStandard"></asp:TextBox>
                                        </td>
                                        <td>
                                            <div style="padding-left: 10px; display: block;">
                                                <asp:ImageButton ID="ImageButtonSaveNewWorkspace" runat="server" ImageUrl="~/Images/Icons/Grey/256/add.png" CssClass="icon-image" ToolTip="Click to add new Workspace" />
                                            </div>
                                        </td>
                                        <td>
                                            <div style="padding-left: 4px; display: block;">
                                                <asp:ImageButton ID="ImageButtonCancelNewWorkspace" runat="server" SkinID="ImageButtonCancel"
                                                    ImageAlign="AbsMiddle" ToolTip="Cancel add Workspace" />
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>
                        </div>
                        <div id="DivNewTemplate" runat="server" style="padding-bottom: 8px;">
                            <fieldset>
                                <legend>New Template Name</legend>
                                <table cellpadding="0" cellspacing="0" border="0">
                                    <tr>
                                        <td width="650">
                                            <asp:TextBox ID="TextBoxNewTemplateName" runat="server" Width="630" MaxLength="50" SkinID="TextBoxStandard"></asp:TextBox>
                                        </td>
                                        <td>
                                            <div style="padding-left: 10px; display: block;">
                                                <asp:ImageButton ID="ImageButtonSaveNewTemplate" runat="server" ImageUrl="~/Images/Icons/Grey/256/add.png" CssClass="icon-image" ToolTip="Click to add new Workspace Template" />
                                            </div>
                                        </td>
                                        <td>
                                            <div style="padding-left: 4px; display: block;">
                                                <asp:ImageButton ID="ImageButtonCancelNewTemplate" runat="server" SkinID="ImageButtonCancel"
                                                    ImageAlign="AbsMiddle" ToolTip="Cancel add Workspace Template" />
                                            </div>
                                        </td>
                                    </tr>
                                    <tr runat="server" id="TrExistingTemplate">
                                        <td colspan="3">
                                            <asp:Label ID="LabelExistingTemplate" runat="server" Text="A Workspace Template with this name already exists; overwrite?"
                                                CssClass="required"></asp:Label>
                                            <asp:Button ID="ButtonOverwriteExistingTemplate" runat="server" Text="Yes" />
                                            <asp:Button ID="ButtonCancelOverwriteExistingTemplate" runat="server" Text="No" />
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>
                        </div>
                        <table runat="server" id="TableWorkspaces" border="0" cellspacing="5" cellpadding="6">
                            <tr>
                                <td>
                                    <telerik:RadListBox ID="RadListBoxWorkspaces" runat="server" Height="100" Width="698"
                                        AutoPostBackOnReorder="false" AutoPostBack="true" AllowReorder="true" EnableDragAndDrop="true">
                                    </telerik:RadListBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="LabelTemplate" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </ew:CollapsablePanel>
                    <ew:CollapsablePanel ID="CollapsablePanelCurrentWorkspaces" runat="server" TitleText="Current Workspace">
                        <telerik:RadScriptBlock ID="RadScriptBlock2" runat="server">
                            <script type="text/javascript">
                                function RadToolBarCurrentWorkspaceOnClientButtonClicking(sender, args) {
                                    var comandName = args.get_item().get_commandName();
                                    if (comandName == "Delete") {
                                        ////args.set_cancel(!confirm('Are you sure you want to delete?'));
                                        radToolBarConfirm(sender, args, "Are you sure you want to delete?");
                                    }
                                }
                            </script>
                        </telerik:RadScriptBlock>
                        <div style="margin-top: 5px;max-width: 100%!important;width: 100%;margin: auto;float: left;display: inline-block;text-align: center;">
                            <telerik:RadToolBar ID="RadToolBarCurrentWorkspace" runat="server" Width="100%" OnClientButtonClicking="RadToolBarCurrentWorkspaceOnClientButtonClicking">
                                <Items>
                                    <telerik:RadToolBarButton Text="" Value="Save" CommandName="Save" SkinID="RadToolBarButtonSave"
                                        ToolTip="Save the selected Workspace">
                                    </telerik:RadToolBarButton>
                                    <telerik:RadToolBarButton IsSeparator="true">
                                    </telerik:RadToolBarButton>
                                    <telerik:RadToolBarButton Text="Delete" Value="Delete" CommandName="Delete" SkinID="RadToolBarButtonDelete"
                                        ToolTip="Delete selected Workspace">
                                    </telerik:RadToolBarButton>
                                </Items>
                            </telerik:RadToolBar>
                        </div>
                        
                        <fieldset>
                            <legend>Name</legend>
                            <asp:TextBox ID="TextBoxWorkspaceName" runat="server" Width="665" MaxLength="50" SkinID="TextBoxStandard"></asp:TextBox>
                        </fieldset>
                        <fieldset runat="server" id="FieldsetPanels">
                            <legend>Panels</legend>
                            <table border="0" cellspacing="0" cellpadding="2">
                                <tr>
                                    <td valign="top">
                                        <telerik:RadListBox ID="RadListBoxLeftPanel" runat="server" Width="295" Height="100"
                                            TransferMode="Move" SelectionMode="Multiple" EnableDragAndDrop="true" AllowDelete="false"
                                            AllowReorder="true" AllowTransfer="true" AutoPostBackOnDelete="true" AutoPostBackOnReorder="true"
                                            EnableViewState="true" AutoPostBackOnTransfer="true">
                                            <ButtonSettings ShowDelete="false" ShowReorder="true" ShowTransfer="false" ShowTransferAll="false" />
                                        </telerik:RadListBox>
                                    </td>
                                    <td valign="top">
                                        <telerik:RadListBox ID="RadListBoxCenterPanel" runat="server" Width="395" Height="100"
                                            EnableViewState="true" TransferMode="Move" SelectionMode="Multiple" EnableDragAndDrop="true"
                                            AllowDelete="false" AllowReorder="true" AllowTransfer="true" AutoPostBackOnDelete="true"
                                            AutoPostBackOnReorder="true" AutoPostBackOnTransfer="true">
                                            <ButtonSettings ShowDelete="false" ShowReorder="true" ShowTransfer="false" ShowTransferAll="false" />
                                        </telerik:RadListBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <div style="margin:2px 0px 0px 0px;">
                                            <div class="workspace-checkbox-container">
                                                <asp:CheckBox ID="CheckBoxAddToLeft" runat="server" Text="<span class='workspace-checkbox'>Add Objects</span>" AutoPostBack="true" />
                                            </div>
                                            <div class="workspace-delete-link-container">
                                                <asp:ImageButton ID="ImageButtonDeleteFromLeft" runat="server" ImageAlign="AbsMiddle" Visible="false" SkinID="ImageButtonDelete" />
                                                <asp:LinkButton ID="LinkButtonDeleteFromLeft" runat="server" Text="Delete Selected Objects"></asp:LinkButton>
                                            </div>
                                        </div>
                                    </td>
                                    <td valign="top">
                                        <div style="margin: 3px 0px 0px 0px;">
                                            <div class="workspace-checkbox-container">
                                                <asp:CheckBox ID="CheckBoxAddToCenter" runat="server" Text="<span class='workspace-checkbox'>Add Objects</span>" AutoPostBack="true" />
                                            </div>
                                            <div class="workspace-delete-link-container">
                                                <asp:ImageButton ID="ImageButtonDeleteFromCenter" runat="server" ImageAlign="AbsMiddle" Visible="false" SkinID="ImageButtonDelete" />
                                                <asp:LinkButton ID="LinkButtonDeleteFromCenter" runat="server" Text="Delete Selected Objects"></asp:LinkButton>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                                <tr id="TrAvailableObjectsHeader" runat="server">
                                    <td colspan="2">Available Objects
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" id="TrRadListBoxAvailableObjects" runat="server">
                                        <telerik:RadListBox ID="RadListBoxAvailableObjects" runat="server" Width="500" EnableDragAndDrop="true"
                                            AllowTransfer="true" TransferMode="Copy" AutoPostBackOnTransfer="true" Height="193"
                                            SelectionMode="Multiple">
                                            <ButtonSettings ShowDelete="false" ShowReorder="false" ShowTransfer="false" ShowTransferAll="false" />
                                        </telerik:RadListBox>
                                        <asp:Label ID="LabelDragTip" runat="server" Text="<br />Hold down CTRL to select multiple objects.  Drag and drop to add." Font-Size="Small"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                        <fieldset runat="server" id="FieldsetQuickLaunch">
                            <legend>Favorites
                            </legend>
                            <telerik:RadTreeView ID="RadTreeViewQuickLaunch" runat="server" ShowLineImages="true" Width="100%" Height="200">
                            </telerik:RadTreeView>
                        </fieldset>
                    </ew:CollapsablePanel>
                </telerik:RadPageView>
                <telerik:RadPageView ID="RadPageViewWorkspaceTemplates" runat="server">
                    <ew:CollapsablePanel ID="CollapsablePanelWorkspaceTemplates" runat="server" TitleText="Workspace Templates">
                        <div style="margin-top: 5px;max-width: 100%!important;width: 100%;margin: auto;float: left;display: inline-block;text-align: center;">
                            <telerik:RadToolBar ID="RadToolBarTemplates" runat="server" Width="100%">
                                <Items>
                                    <telerik:RadToolBarButton Value="Refresh" CommandName="Refresh" SkinID="RadToolBarButtonRefresh">
                                    </telerik:RadToolBarButton>
                                </Items>
                            </telerik:RadToolBar>
                        </div>
                        
                        <table runat="server" id="Table1" border="0" cellspacing="5" cellpadding="6">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="RadGridWorkspaceTemplates" runat="server" ShowFooter="false"
                                        AutoGenerateColumns="False" GridLines="None" EnableEmbeddedSkins="True" Width="725">
                                        <MasterTableView AutoGenerateColumns="False" DataKeyNames="ID">
                                            <Columns>
                                                <telerik:GridTemplateColumn UniqueName="GridTemplateColumnTemplateName" HeaderText="Template Name">
                                                    <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                                                    <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                                                    <FooterStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="LabelTemplateName" runat="server" Text='<%#Eval("Name")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn UniqueName="GridTemplateColumnApplyToSelf">
                                                    <HeaderStyle CssClass="radgrid-icon-column" />
                                                    <ItemStyle CssClass="radgrid-icon-column" />
                                                    <FooterStyle CssClass="radgrid-icon-column" />
                                                    <ItemTemplate>
                                                        <div class="icon-background background-color-sidebar">
                                                            <asp:ImageButton ID="ImageButtonApplyToSelf" runat="server" AlternateText="Apply this Template to yourself"
                                                                CommandName="ApplyToSelf" ToolTip="Apply this Template to yourself" ImageUrl="~/Images/Icons/White/256/user.png" CssClass="icon-image" />
                                                        </div>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn UniqueName="GridTemplateColumnSave">
                                                    <HeaderStyle CssClass="radgrid-icon-column" />
                                                    <ItemStyle CssClass="radgrid-icon-column" />
                                                    <FooterStyle CssClass="radgrid-icon-column" />
                                                    <ItemTemplate>
                                                        <div class="icon-background background-color-sidebar">
                                                            <asp:ImageButton ID="ImageButtonSave" runat="server" AlternateText="Overwrite this Template with your current Workspaces"
                                                                CommandName="SaveRow" ToolTip="Replace this Template with your current Workspaces"
                                                                SkinID="ImageButtonSaveWhite" />
                                                        </div>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn UniqueName="GridTemplateColumnDelete">
                                                    <HeaderStyle CssClass="radgrid-icon-column" />
                                                    <ItemStyle CssClass="radgrid-icon-column" />
                                                    <FooterStyle CssClass="radgrid-icon-column" />
                                                    <ItemTemplate>
                                                        <div class="icon-background background-color-delete">
                                                            <asp:ImageButton ID="ImageButtonDelete" runat="server" CommandName="DeleteRow" AlternateText="Delete Template"
                                                                ToolTip="Delete Template" ImageAlign="AbsMiddle" SkinID="ImageButtonDeleteWhite" />
                                                        </div>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <RowIndicatorColumn Visible="False">
                                                <HeaderStyle Width="20px" />
                                            </RowIndicatorColumn>
                                            <ExpandCollapseColumn Resizable="False" Visible="False">
                                                <HeaderStyle Width="20px" />
                                            </ExpandCollapseColumn>
                                        </MasterTableView>
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                    </ew:CollapsablePanel>
                </telerik:RadPageView>
            </telerik:RadMultiPage>
            <div class="warning" style="font-size: 14px; padding: 0px 0px 0px 5px;">
                IMPORTANT NOTE:<br />
                Using the Workspace Manager will cause the main window to refresh.  This will close any open applications!  Please save your work first!
            </div>
    </div>
    
</asp:Content>
