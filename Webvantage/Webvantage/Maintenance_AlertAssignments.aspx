<%@ Page Title="Workflow Maintenance" Language="vb" AutoEventWireup="false"
    MasterPageFile="~/ChildPage.Master" CodeBehind="Maintenance_AlertAssignments.aspx.vb"
    Inherits="Webvantage.Maintenance_AlertAssignments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <telerik:RadScriptBlock ID="RadScriptBlockMaintenanceAlertAssignments" runat="server">
        <script type="text/javascript">
            function RadGridTemplates_RowDoubleClick(sender, eventArgs) {
                RadGridTemplatesRowDoubleClick(eventArgs.get_itemIndexHierarchical());
            };
            function RadGridTemplatesRowDoubleClick(itemIndex) {
                __doPostBack("<%= RadGridTemplates.UniqueID %>", "IndexOfRowDoubleClicked:" + itemIndex);
            };
            function RadComboBoxAlertTemplateDropDownOpened(sender, eventArgs) {
                sender.get_inputDomElement().select();
            };
            function RadListBoxStatesInTemplateDoubleClick(sender, eventArgs) {
                //var item = eventArgs.get_item();
                //alert(item.get_text());
                //alert(item.get_value());
            };
        </script>
    </telerik:RadScriptBlock>
    <div class="telerik-aqua-body">
            <div class="DO-ButtonHeader">
                <div style="float: left; text-align: left; vertical-align: middle; display: inline-block;">
                    <telerik:RadTabStrip ID="RadTabStrip1" runat="server" MultiPageID="RadMultiPage1"
                        AutoPostBack="true" SelectedIndex="0" Width="100%">
                        <Tabs>
                            <telerik:RadTab Text="States">
                            </telerik:RadTab>
                            <telerik:RadTab Text="Templates">
                            </telerik:RadTab>
                            <telerik:RadTab Text="Template Detail">
                            </telerik:RadTab>
                            <telerik:RadTab Text="Assignment Settings">
                            </telerik:RadTab>
                        </Tabs>
                    </telerik:RadTabStrip>
                </div>
                <div style="float: right; text-align: right; display: inline-block;">
                    <asp:CheckBox ID="CheckBoxShowInactive" runat="server" Text="Show Inactive" AutoPostBack="True" />
                    <asp:ImageButton ID="ImageButtonExport" runat="server" SkinID="ImageButtonExportExcel" />&nbsp;&nbsp;
                </div>
            </div>
            <br />
            <telerik:RadMultiPage ID="RadMultiPage1" runat="server" SelectedIndex="0">
                <telerik:RadPageView ID="RadPageViewStates" runat="server">
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                        <br />
                        <telerik:RadGrid ID="RadGridAlertStates" runat="server" AllowPaging="True" AllowSorting="True"
                            GridLines="None" PageSize="10" EnableEmbeddedSkins="True" ShowFooter="False"
                            AutoGenerateColumns="False" Width="770">
                            <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="True" Position="Bottom"></PagerStyle>
                            <ExportSettings ExportOnlyData="True" IgnorePaging="true" OpenInNewWindow="true" HideStructureColumns="true">
                                <Excel Format="Html" />
                            </ExportSettings>
                            <MasterTableView CommandItemDisplay="None" EditMode="InPlace" DataKeyNames="ALERT_STATE_ID"
                                InsertItemDisplay="Top">
                                <CommandItemSettings AddNewRecordText="Add" RefreshText="Refresh" ShowAddNewRecordButton="false" ShowExportToExcelButton="true" />
                                <Columns>
                                    <telerik:GridTemplateColumn UniqueName="ColALERT_STATE_NAME" HeaderText="State Name" DataField="ALERT_STATE_NAME"
                                        SortExpression="ALERT_STATE_NAME">
                                        <HeaderStyle Width="500" VerticalAlign="Middle" HorizontalAlign="Left" />
                                        <ItemStyle Width="500" VerticalAlign="Middle" HorizontalAlign="Left" />
                                        <FooterStyle Width="500" VerticalAlign="Middle" HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:TextBox ID="TxtALERT_STATE_NAME" runat="server" Text='<%#Eval("ALERT_STATE_NAME") %>' SkinID="TextBoxStandard"
                                                Width="491" MaxLength="100"></asp:TextBox>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TxtALERT_STATE_NAME" runat="server" Text='<%#Eval("ALERT_STATE_NAME") %>' SkinID="TextBoxStandard"
                                                Width="491" MaxLength="100"></asp:TextBox>
                                        </EditItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn UniqueName="ColACTIVE_FLAG" HeaderText="Inactive" SortExpression="ACTIVE_FLAG" DataField="ACTIVE_FLAG">
                                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" Width="30" />
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" Width="30" />
                                        <FooterStyle VerticalAlign="Middle" HorizontalAlign="Center" Width="30" />
                                        <ItemTemplate>
                                            <asp:CheckBox ID="ChkACTIVE_FLAG" runat="server" AutoPostBack="true" OnCheckedChanged="RadGridAlertStates_ToggleInActive" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:CheckBox ID="ChkACTIVE_FLAG" runat="server" Checked="false" AutoPostBack="false" />
                                        </EditItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn UniqueName="ColDFLT_ALERT_CAT_ID" HeaderText="Default Category" DataField="DFLT_ALERT_CAT_ID"
                                        SortExpression="DFLT_ALERT_CAT_ID">
                                        <HeaderStyle Width="110" VerticalAlign="Middle" HorizontalAlign="Left" />
                                        <ItemStyle Width="110" VerticalAlign="Middle" HorizontalAlign="Left" />
                                        <FooterStyle Width="110" VerticalAlign="Middle" HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <telerik:RadComboBox ID="DropDFLT_ALERT_CAT_ID" runat="server" AutoPostBack="false" InputCssClass="no-border" SkinID="RadComboBoxStandard"
                                                Width="110">
                                            </telerik:RadComboBox>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <telerik:RadComboBox ID="DropDFLT_ALERT_CAT_ID" runat="server" AutoPostBack="false" InputCssClass="no-border" SkinID="RadComboBoxStandard"
                                                Width="110">
                                            </telerik:RadComboBox>
                                        </EditItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn UniqueName="ColSave">
                                        <HeaderStyle CssClass="radgrid-icon-column" />
                                        <ItemStyle CssClass="radgrid-icon-column" />
                                        <FooterStyle CssClass="radgrid-icon-column" />
                                        <HeaderTemplate>
                                            <asp:ImageButton ID="ImgBtnSaveAll" runat="server" SkinID="ImageButtonSaveAll"
                                                ToolTip="Click to save all rows" CommandName="SaveAll" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <div class="icon-background background-color-sidebar">
                                                <asp:ImageButton ID="ImgBtnSave" runat="server" SkinID="ImageButtonSaveWhite"
                                                    ToolTip="Click to save this row" CommandName="SaveRow" />
                                            </div>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <div class="icon-background background-color-sidebar">
                                                <asp:ImageButton ID="ImgBtnSaveNew" runat="server" SkinID="ImageButtonAddWhite" ToolTip="Click to add this row"
                                                    CommandName="SaveNewRow" />
                                            </div>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:ImageButton ID="ImgBtnSaveAllFooter" runat="server" SkinID="ImageButtonSaveAll"
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
                        <br />
                </ContentTemplate>
            </asp:UpdatePanel>
                </telerik:RadPageView>
                <telerik:RadPageView ID="RadPageViewTemplates" runat="server">
            <asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                        <br />
                        <telerik:RadGrid ID="RadGridTemplates" runat="server" AllowPaging="True" AllowSorting="True"
                            GridLines="None" PageSize="10" EnableEmbeddedSkins="True" ShowFooter="False"
                            AutoGenerateColumns="False" Width="780">
                            <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="True" Position="Bottom"></PagerStyle>
                            <MasterTableView CommandItemDisplay="None" EditMode="InPlace" DataKeyNames="ALRT_NOTIFY_HDR_ID"
                                InsertItemDisplay="Top">
                                <CommandItemSettings AddNewRecordText="Add" RefreshText="Refresh" />
                                <Columns>
                                    <telerik:GridTemplateColumn UniqueName="ColALERT_NOTIFY_NAME" HeaderText="Template Name"
                                        SortExpression="ALERT_NOTIFY_NAME">
                                        <HeaderStyle Width="600" VerticalAlign="Middle" HorizontalAlign="Left" />
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                                        <FooterStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:TextBox ID="TxtALERT_NOTIFY_NAME" runat="server" Width="634" Text='<%#Eval("ALERT_NOTIFY_NAME") %>' SkinID="TextBoxStandard"
                                                MaxLength="100"></asp:TextBox>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TxtALERT_NOTIFY_NAME" runat="server" Width="634" Text='<%#Eval("ALERT_NOTIFY_NAME") %>' SkinID="TextBoxStandard"
                                                MaxLength="100"></asp:TextBox>
                                        </EditItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn UniqueName="GridTemplateColumnForceComplete" HeaderText="Auto Route" SortExpression="AUTO_NXT_STATE">
                                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <FooterStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:CheckBox ID="CheckBoxAutoRoute" runat="server" AutoPostBack="True" OnCheckedChanged="RadGridTemplates_ToggleInActive"/>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:CheckBox ID="CheckBoxAutoRoute" runat="server" Checked="false" CommandName="SaveRow" AutoPostBack="True"/>
                                        </EditItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn UniqueName="GridTemplateColumnMultiRoute" HeaderText="Proof" SortExpression="TYPE" Visible="True">
                                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <FooterStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:CheckBox ID="CheckBoxReviewProofing" runat="server" AutoPostBack="false" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:CheckBox ID="CheckBoxReviewProofing" runat="server" Checked="false" />
                                        </EditItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn UniqueName="ColACTIVE_FLAG" HeaderText="Inactive" SortExpression="ACTIVE_FLAG">
                                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <FooterStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:CheckBox ID="ChkACTIVE_FLAG" runat="server" AutoPostBack="true" OnCheckedChanged="RadGridTemplates_ToggleInActive"/>
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
                                            <asp:ImageButton ID="ImgBtnSaveAll" runat="server" SkinID="ImageButtonSaveAll"
                                                ToolTip="Click to save all rows" CommandName="SaveAll" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <div class="icon-background background-color-sidebar">
                                                <asp:ImageButton ID="ImgBtnSave" runat="server" SkinID="ImageButtonSaveWhite"
                                                    ToolTip="Click to save this row" CommandName="SaveRow" />
                                            </div>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <div class="icon-background background-color-sidebar">
                                                <asp:ImageButton ID="ImgBtnSaveNew" runat="server" SkinID="ImageButtonAddWhite" ToolTip="Click to add this row"
                                                    CommandName="SaveNewRow" />
                                            </div>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:ImageButton ID="ImgBtnSaveAllFooter" runat="server" SkinID="ImageButtonSaveAll"
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
                                            <div class="icon-background background-color-sidebar">
                                                <asp:ImageButton ID="ImgBtnCancelNew" runat="server" SkinID="ImageButtonCancelWhite"
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
                                <ClientEvents OnRowDblClick="RadGridTemplates_RowDoubleClick" />
                            </ClientSettings>
                        </telerik:RadGrid>
                        <br />
                </ContentTemplate>
            </asp:UpdatePanel>
                </telerik:RadPageView>
                <telerik:RadPageView ID="RadPageViewTemplateDetail" runat="server">
            <asp:UpdatePanel runat="server" ID="UpdatePanel2" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                        <div style="width: 100%; margin: 0px 0px 12px 0px; border-bottom: 1px solid #CECECE; padding: 0px 0px 8px 0px;">
                            <div>
                                <div style="display: inline-block;">
                                    Template:
                                </div>
                                <div style="display: inline-block;">
                                    <telerik:RadComboBox ID="RadComboBoxAlertTemplate" runat="server" AutoPostBack="true" Width="550" Filter="Contains" OnClientDropDownOpened="RadComboBoxAlertTemplateDropDownOpened" SkinID="RadComboBoxStandard">
                                    </telerik:RadComboBox>
                                </div>
                                <div style="display: inline-block;">
                                    <asp:ImageButton ID="ImageButtonCopyTemplate" runat="server" ToolTip="Copy current template" CssClass="icon-image" ImageUrl="~/Images/Icons/Grey/256/copy.png" />
                                </div>
                            </div>
                            <div id="DivSelectedTemplateOptions" runat="server" style="margin: 0px 0px 0px 75px;">
                                <div style="display:none;">
                                    <asp:LinkButton ID="LbtnTemplateCopy" runat="server">Copy Current Template</asp:LinkButton>
                                </div>
                                <div style="display: none !important;">
                                    <asp:CheckBox ID="CheckBoxIsDigitalAsset" runat="server" Text="This is a Digital Asset Review template" Visible="false" />
                                </div>
                            </div>
                        </div>
                        <div style="width: 100%; vertical-align: top;">
                            <div style="width: 33%; display: inline-block; vertical-align: top;">
                                <div>
                                    Available States
                                </div>
                                <div>
                                    <telerik:RadListBox ID="RadListBoxAvailableStates" runat="server" Width="100%" Height="180"
                                        SelectionMode="Multiple" AllowTransfer="true" TransferToID="RadListBoxStatesInTemplate"
                                        AutoPostBackOnTransfer="true" AllowReorder="False" EnableDragAndDrop="true">
                                    </telerik:RadListBox>
                                </div>
                            </div>
                            <div style="width: 33%; display: inline-block; vertical-align: top;">
                                <div>
                                    States Currently in Template
                                </div>
                                <div>
                                    <telerik:RadListBox ID="RadListBoxStatesInTemplate" runat="server" Width="100%" AutoPostBack="true"
                                        OnClientItemDoubleClicked="RadListBoxStatesInTemplateDoubleClick"
                                        Height="180" SelectionMode="Multiple" AllowReorder="true" AutoPostBackOnReorder="true"
                                        EnableDragAndDrop="true">
                                    </telerik:RadListBox>
                                </div>
                            </div>
                            <div style="width: 33%; display: inline-block; vertical-align: top;">
                                <fieldset>
                                    <legend>Completed State*</legend>
                                    <asp:ImageButton ID="ImgBtnCompletedState" runat="server" ImageUrl="~/Images/Icons/Grey/256/checkbox.png" Height="48" Width="48"
                                        ImageAlign="AbsMiddle" />
                                    <br />
                                    <asp:Label ID="LblCompletedState" runat="server" Text="Drag State name over icon to set"></asp:Label>
                                </fieldset>
                                <fieldset>
                                    <legend>Automated Assignment**</legend>
                                    <asp:ImageButton ID="ImageButtonWorkflowState" runat="server" ImageUrl="~/Images/Icons/Grey/256/arrow_u_turn.png" Height="48" Width="48"
                                        ImageAlign="AbsMiddle" />
                                    <br />
                                    <asp:Label ID="LabelWorkflowState" runat="server" Text="Select a Template State to enable Automated Assignment"></asp:Label>
                                    <div style="display: none;">
                                        <telerik:RadComboBox ID="RadComboBoxTemplateStateWorkflow" runat="server" Width="100%" SkinID="RadComboBoxStandard"
                                            AutoPostBack="true">
                                        </telerik:RadComboBox>
                                    </div>
                                </fieldset>
                            </div>
                        </div>
                        <div style="width: 100%;">
                            <h4>Employees List Type:
                                <asp:RadioButtonList ID="RadioButtonListEmployeeListType" runat="server" RepeatDirection="Horizontal" AutoPostBack="true"
                                    RepeatLayout="Flow">
                                    <asp:ListItem Text="Manual" Value="manual" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="By Role" Value="role"></asp:ListItem>
                                    <asp:ListItem Text="By Department" Value="department"></asp:ListItem>
                                    <asp:ListItem Text="By Alert Group" Value="alertgroup"></asp:ListItem>
                                </asp:RadioButtonList>
                            </h4>
                        </div>
                        <div style="width: 100%;">
                            <div style="width: 33%; display: inline-block; vertical-align: top;">
                                <div>
                                    <asp:Label ID="LabelAvailableEmpListType" runat="server" Text="Available Employees"></asp:Label>
                                </div>
                                <div>
                                    <telerik:RadListBox ID="RadListBoxEmps_AvailableEmps" runat="server" Width="100%"
                                        Height="180" TransferToID="RadListBoxEmps_EmpsInTemplateState" SelectionMode="Multiple"
                                        AllowTransfer="True" AutoPostBackOnTransfer="true" AllowReorder="False" EnableDragAndDrop="true">
                                    </telerik:RadListBox>
                                </div>
                                <div runat="server" id="TableManualAssign">
                                    <fieldset id="FieldsetFilterEmployees" runat="server">
                                        <legend>Filter by</legend>
                                        <asp:RadioButtonList ID="RblAvailableEmployeesFilter" runat="server" RepeatDirection="Horizontal"
                                            AutoPostBack="true" RepeatLayout="Flow">
                                            <asp:ListItem Text="Role" Value="role"></asp:ListItem>
                                            <asp:ListItem Text="Alert Group" Value="alert_group"></asp:ListItem>
                                            <asp:ListItem Text="None" Value="none"></asp:ListItem>
                                        </asp:RadioButtonList>
                                        <br />
                                        <telerik:RadComboBox ID="DropAvailableEmployeesFilter" runat="server" Enabled="false" SkinID="RadComboBoxStandard"
                                            Width="210" AutoPostBack="true">
                                        </telerik:RadComboBox>
                                    </fieldset>
                                </div>
                            </div>
                            <div style="width: 33%; display: inline-block; vertical-align: top;">
                                <div>
                                    <asp:Label ID="LabelCurrentEmployees" runat="server" Text="Employees Currently in State"></asp:Label>
                                </div>
                                <div>
                                    <telerik:RadListBox ID="RadListBoxEmps_EmpsInTemplateState" runat="server" Width="100%"
                                        Height="180" SelectionMode="Multiple" AllowReorder="False" AutoPostBackOnReorder="true"
                                        EnableDragAndDrop="true">
                                    </telerik:RadListBox>
                                </div>
                                <div>
                                    <asp:LinkButton ID="LBtnCopyCurrentAssignmentTeam" runat="server">Copy current team</asp:LinkButton>
                                    <div id="DivCopyTeam" runat="server">
                                        <br />
                                        <telerik:RadListBox ID="RadListBoxStatesInTemplateToCopyTo" runat="server" Width="271px"
                                            AutoPostBack="false" Height="200px" SelectionMode="Multiple" AllowReorder="false"
                                            AutoPostBackOnReorder="false" EnableDragAndDrop="false">
                                        </telerik:RadListBox>
                                        <br />
                                        <asp:Button ID="BtnCopyCurrentAssignmentTeam" runat="server" Text="Copy" />
                                    </div>
                                </div>
                            </div>
                            <div style="width: 33%; display: inline-block; vertical-align: top;">
                                <fieldset>
                                    <legend>Default Employees*</legend>
                                    <asp:ImageButton ID="ImgBtnEmpDefaultEmp" runat="server" ImageUrl="~/Images/Icons/Grey/256/user.png" Height="48" Width="48" ImageAlign="AbsMiddle" />
                                    <br />
                                    <ul>
                                        <li>
                                            <div>
                                                To make an employee default, drag his/her name onto the icon above.
                                            </div>
                                        </li>
                                        <li>                                    
                                            <div>
                                                To remove an employee from default, drag a default employee(s) onto the icon above.
                                            </div>
                                        </li>
                                    </ul>
                                    <div style="display: none !important;">
                                        <asp:Label ID="LblEmpDefaultEmp" runat="server" Text="Drag employee name over icon to set"></asp:Label>
                                    </div>
                                </fieldset>
                            </div>
                        </div>
                </ContentTemplate>
            </asp:UpdatePanel>
                </telerik:RadPageView>
                <telerik:RadPageView ID="RadPageViewOtherSettings" runat="server">
            <asp:UpdatePanel runat="server" ID="UpdatePanel3" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                        <h4>General</h4>
                        <div class="code-description-container">
                            <div class="code-description-label">
                                Track Description Changes:
                            </div>
                            <div class="code-description-description">
                                <asp:CheckBox ID="CheckBoxTrackAlertDescriptionChanges" runat="server" AutoPostBack="true" />
                            </div>
                        </div>
                        <div class="code-description-container">
                            <div class="code-description-label-xxl">
                                Routed Assignment Default Subject:
                            </div>
                            <div class="code-description-description">
                                <telerik:RadComboBox ID="RadComboBoxAlertAssignmentDefaultSubject" runat="server" Width="300" SkinID="RadComboBoxStandard"
                                    AutoPostBack="true">
                                    <Items>
                                        <telerik:RadComboBoxItem Text="Don't Modify" Value="" />
                                        <telerik:RadComboBoxItem Text="State" Value="state" />
                                        <telerik:RadComboBoxItem Text="Template" Value="template" />
                                        <telerik:RadComboBoxItem Text="Template and State" Value="templateandstate" />
                                        <telerik:RadComboBoxItem Text="Job #, Job Name, Template, and State" Value="jjcts" />
                                    </Items>
                                </telerik:RadComboBox>
                            </div>
                        </div>
                        <div class="code-description-container">
                            <div class="code-description-label">
                                Routed proofs by default:
                            </div>
                            <div class="code-description-description">
                                <asp:CheckBox ID="CheckBoxRouteReviewsByDefault" runat="server" AutoPostBack="true" />
                            </div>
                        </div>
                        <div style="margin: 6px 0px 0px 0px; display: none !important;">
                        <h4>Time Zone Display</h4>
                            <div class="code-description-container">
                                <div class="code-description-label-xxl">
                                    Database Server Time Zone:
                                </div>
                                <div class="code-description-description">
                                    <telerik:RadComboBox ID="RadComboBoxDatabaseServerTimeZone" runat="server" Width="300" SkinID="RadComboBoxStandard"
                                        AutoPostBack="true">
                                        <Items>
                                        </Items>
                                    </telerik:RadComboBox>
                                </div>
                            </div>
                            <div class="code-description-container">
                                <div class="code-description-label-xxl">
                                    Agency Time Zone:
                                </div>
                                <div class="code-description-description">
                                    <telerik:RadComboBox ID="RadComboBoxAgencyTimeZone" runat="server" Width="300" SkinID="RadComboBoxStandard"
                                        AutoPostBack="true">
                                        <Items>
                                        </Items>
                                    </telerik:RadComboBox>
                                </div>
                            </div>
                        </div>
                </ContentTemplate>
            </asp:UpdatePanel>
                </telerik:RadPageView>
            </telerik:RadMultiPage>
    </div>

</asp:Content>
