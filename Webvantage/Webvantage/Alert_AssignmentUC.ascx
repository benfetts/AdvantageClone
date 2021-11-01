<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Alert_AssignmentUC.ascx.vb" Inherits="Webvantage.Alert_AssignmentUC" %>
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
    <div id="alert-styles" style="padding: 10px 0px 10px 0px; width:99%;">
        <div>
            <asp:Label ID="LabelCompleted" runat="server" Text="Assignment is completed.<br />" CssClass="required"></asp:Label>
        </div>
        <div style="margin: 10px 0px 10px 0px;">
            Assignment:
        </div>
        <div>
            <asp:Label ID="Assignment" runat="server"></asp:Label>
        </div>
        <div style="margin: 10px 0px 10px 0px;">
            Workflow Template:
        </div>
        <div>
            <telerik:RadComboBox ID="RadComboBoxAlertNotifyHdrTemplate" runat="server" AutoPostBack="true" TabIndex="0" Width="99%" CausesValidation="false">
            </telerik:RadComboBox>
        </div>
        <div style="margin: 10px 0px 10px 0px;">
            State:
        </div>
        <div>
            <telerik:RadTreeView ID="RadTreeViewStates" runat="server" CausesValidation="False" TabIndex="1" CheckBoxes="False" ShowLineImages="False" Height="250" Width="99%">
            </telerik:RadTreeView>
        </div>
        <div style="margin: 10px 0px 10px 0px;">
            Assign To:
        </div>
        <div>
            <telerik:RadComboBox ID="RadComboBoxAssignTo" runat="server" AutoPostBack="False" TabIndex="2" Width="99%" EnableLoadOnDemand="True" ShowMoreResultsBox="true" ItemsPerRequest="7" EnableVirtualScrolling="true">
            </telerik:RadComboBox>
        </div>
        <div class="checkbox-container">
            <asp:CheckBox ID="CheckBoxShowAllAssignmentEmployees" runat="server" Text="Show all employees" AutoPostBack="true" />
        </div>
        <div style="display: none !important;" class="checkbox-container">
            <asp:CheckBox ID="CheckBoxEmailAssignmentOrigintorOverride_DontEmailMe" runat="server" TabIndex="-1" AutoPostBack="True" Text="Don't email me" />
        </div>
        <div id="DivComment" runat="server">
            <div style="margin: 10px 0px 10px 0px;">
                Comment:
            </div>
            <div>
                <asp:TextBox ID="TextBoxComment" runat="server" TextMode="MultiLine" Width="94%" Height="40" TabIndex="3"></asp:TextBox>
            </div>
        </div>
        <div id="DivSendAssignmentButton" runat="server" style="text-align: center; margin: 10px 0px 10px 0px;">
            <asp:Button ID="ButtonSendAssignment" runat="server" CausesValidation="False" TabIndex="4" Text="Send Assignment" />
        </div>
    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
