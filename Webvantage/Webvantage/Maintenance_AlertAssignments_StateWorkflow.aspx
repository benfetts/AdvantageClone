<%@ Page Title="Automated Assignment" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="Maintenance_AlertAssignments_StateWorkflow.aspx.vb" Inherits="Webvantage.Maintenance_AlertAssignments_StateWorkflow" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <telerik:RadScriptBlock ID="RadScriptBlock2" runat="server">
        <script type="text/javascript">
            function RadToolBarMaintenanceAlertStateWorkflowOnClientButtonClicking(sender, args) {
                var comandName = args.get_item().get_commandName();
                if (comandName == "Delete") {
                    ////args.set_cancel(!confirm('Are you sure you want to delete?'));
                    radToolBarConfirm(sender, args, "Are you sure you want to delete?");
                }
            }
        </script>
    </telerik:RadScriptBlock>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
    <telerik:RadToolBar ID="RadToolBarMaintenanceAlertStateWorkflow" runat="server" Width="100%" OnClientButtonClicking="RadToolBarMaintenanceAlertStateWorkflowOnClientButtonClicking">
        <Items>
            <telerik:RadToolBarButton SkinID="RadToolBarButtonSave" Text="" CommandName="Save" Value="Save" ToolTip="Save this Automated Assignment" />
            <telerik:RadToolBarButton SkinID="RadToolBarButtonDelete" CommandName="Delete" Value="Delete" ToolTip="Delete this Automated Assignment" />
            <telerik:RadToolBarButton Text="View All Automated Assignments" CommandName="ViewAllWorkflows" Value="ViewAllWorkflows" ToolTip="View All Automated Assignments in a single window" />
        </Items>
    </telerik:RadToolBar>
        <div style="margin-left: 6px; margin-bottom: 12px; margin-top: 6px; margin-right: 6px;">
            On Action:<br />
            <telerik:RadComboBox ID="RadComboBoxOnAction" runat="server" AutoPostBack="true" Width="100%" SkinID="RadComboBoxStandard">
            </telerik:RadComboBox>
        </div>
        <div style="margin-left: 6px; margin-right: 6px;" id="DivSelectTemplateAndState" runat="server">
            Template:<br />
            <telerik:RadComboBox ID="RadComboBoxTemplate" runat="server" AutoPostBack="true" Width="100%" SkinID="RadComboBoxStandard">
            </telerik:RadComboBox>
            <br />
            <br />
            <asp:CheckBox ID="CheckBoxChangeAllStatesInTemplate" runat="server" Text="All States In Template" AutoPostBack="true" />
            <fieldset>
                <legend>Assignments with State</legend>
                <telerik:RadListBox ID="RadListBoxAssignmentsWithState" runat="server" SelectionMode="Single" Width="100%" Height="180" AutoPostBack="true">
                </telerik:RadListBox>
            </fieldset>
            <br />
        </div>
        <div style="margin-left: 6px; margin-bottom: 12px; margin-right: 6px;">
            <fieldset>
                <legend>Changes to State</legend>
                <telerik:RadListBox ID="RadListBoxChangesToState" runat="server" SelectionMode="Single" Width="100%" Height="180">
                </telerik:RadListBox>
            </fieldset>
        </div>
                </ContentTemplate>
            </asp:UpdatePanel>
    <div style="margin-left: 6px; margin-bottom: 12px; margin-right: 6px; display: none;">
        <asp:Label ID="LabelAlertTypeDisplay" runat="server" Text="For all Assignments with the Template/State"></asp:Label>:<br />
    </div>
</asp:Content>
