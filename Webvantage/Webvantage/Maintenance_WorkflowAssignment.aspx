<%@ Page Title="Automated Assignments" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="Maintenance_WorkflowAssignment.aspx.vb" Inherits="Webvantage.Maintenance_WorkflowAssignment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div>
        <div class="telerik-aqua-body"> 
            <div style="float:left;" >
                <telerik:RadTabStrip ID="RadTabStripWorkflowAssignmentOptions" runat="server" MultiPageID="RadMultiPageAlertGroups"
                    AutoPostBack="true" SelectedIndex="0" Width="350">
                    <Tabs>
                        <telerik:RadTab Text="Automated Assignments">
                        </telerik:RadTab>
                        <telerik:RadTab Text="Options">
                        </telerik:RadTab>
                    </Tabs>
                </telerik:RadTabStrip>
            </div>
            <div style="float: right;margin:5px;">
                <asp:ImageButton ID="ImageButtonExport" runat="server" SkinID="ImageButtonExportExcel" />
            </div>
            <telerik:RadMultiPage ID="RadMultiPageAlertGroups" runat="server" SelectedIndex="0">
        <telerik:RadPageView ID="RadPageViewAutomaticAssignments" runat="server">
            <telerik:RadToolBar ID="RadToolBarMaintenanceWorkflowAssignmentMaintenance" runat="server" Width="100%">
                <Items>
                    <telerik:RadToolBarButton SkinID="RadToolBarButtonNew" Text="Add" Value="Add" ToolTip="Add" />
                    <telerik:RadToolBarButton IsSeparator="true"></telerik:RadToolBarButton>
                    <telerik:RadToolBarButton>
                        <ItemTemplate>&nbsp;&nbsp;Group by:</ItemTemplate>
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton Value="RadToolBarButtonRadComboBoxGroupBy">
                        <ItemTemplate>
                            <telerik:RadComboBox ID="RadComboBoxGroupBy" runat="server" AutoPostBack="true" SkinID="RadComboBoxStandard">
                                <Items>
                                    <telerik:RadComboBoxItem Text="None" Value="None" ToolTip="Don't group grid" />
                                    <telerik:RadComboBoxItem Text="Template/State" Value="ViewByTemplateState" ToolTip="Group grid by Template/State" />
                                    <telerik:RadComboBoxItem Text="Action" Value="ViewByAction" ToolTip="Group grid by Action" />
                                </Items>
                            </telerik:RadComboBox>
                        </ItemTemplate>
                    </telerik:RadToolBarButton>
                </Items>
            </telerik:RadToolBar>
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                <telerik:RadGrid ID="RadGridWorkflowAssignments" runat="server" AllowFilteringByColumn="True" AllowSorting="True" AutoGenerateColumns="False" CellSpacing="0" GridLines="None"
                    AllowPaging="true" PageSize="10">
                    <GroupingSettings CaseSensitive="false" />
                    <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="True" Position="Bottom" ></PagerStyle>
                    <MasterTableView DataKeyNames="ID, WorkflowID, AlertAssignmentTemplateID, AlertStateID">
                        <Columns>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnWorkflow" HeaderText="Action" DataField="Workflow.Name"
                                CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnTemplate" HeaderText="Template" DataField="AlertAssignmentTemplate.Name" CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnState" HeaderText="State" DataField="AlertState.Name" CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnNewState" HeaderText="Change to State" DataField="EndAlertStateID" AllowFiltering="false">
                                <HeaderStyle Width="200px" />
                                <ItemTemplate>
                                    <telerik:RadComboBox ID="RadComboBoxTemplateState" runat="server" AutoPostBack="true" OnSelectedIndexChanged="RadComboBoxTemplateState_SelectedIndexChanged" AppendDataBoundItems="true" SkinID="RadComboBoxStandard">
                                    </telerik:RadComboBox>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnDelete" AllowFiltering="false">
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
                    </MasterTableView>
                </telerik:RadGrid>
                <asp:Label ID="LabelAllStatesMessage" runat="server" Text="* This will override any State-specific rules for the same Template"></asp:Label>
                </ContentTemplate>
            </asp:UpdatePanel>
        </telerik:RadPageView>
        <telerik:RadPageView ID="RadPageViewOptions" runat="server">
            <br />
            <div style="margin: 25px;">
            <asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                    <asp:CheckBox ID="CheckBoxDontChangeEmployee" runat="server" Text="When changing assignments, do not change assigned employee" AutoPostBack="true" />
                </ContentTemplate>
            </asp:UpdatePanel>
            </div>
        </telerik:RadPageView>
    </telerik:RadMultiPage>
        </div>
   
    </div>
    
</asp:Content>
