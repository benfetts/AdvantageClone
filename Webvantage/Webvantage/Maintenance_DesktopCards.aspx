<%@ Page Title="Card Options" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="Maintenance_DesktopCards.aspx.vb" Inherits="Webvantage.Maintenance_DesktopCards" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
        <div id="DivAssignments" runat="server" style="padding: 10px;">
            <h4>Assignments
            </h4>
            <div>
                <asp:CheckBox ID="CheckBoxShowClientNameAssignments" runat="server" Text="Show Client Name" AutoPostBack="true" OnCheckedChanged="CheckBoxShow_CheckedChanged" />
            </div>
            <div>
                <asp:CheckBox ID="CheckBoxShowJobNumberAssignments" runat="server" Text="Show Job Number" AutoPostBack="true" OnCheckedChanged="CheckBoxShow_CheckedChanged" />
                <asp:CheckBox ID="CheckBoxShowJobComponentNumberAssignments" runat="server" Text="Show Job Component Number" AutoPostBack="true" OnCheckedChanged="CheckBoxShow_CheckedChanged" />
            </div>
            <div>
                <asp:CheckBox ID="CheckBoxShowJobDescriptionAssignments" runat="server" Text="Show Job Description" AutoPostBack="true" OnCheckedChanged="CheckBoxShow_CheckedChanged" />
                <asp:CheckBox ID="CheckBoxShowJobComponentDescriptionAssignments" runat="server" Text="Show Job Component Description" AutoPostBack="true" OnCheckedChanged="CheckBoxShow_CheckedChanged" />
            </div>
        </div>
        <div style="padding: 10px;">
            <h4>Alerts
            </h4>
            <div>
                <asp:CheckBox ID="CheckBoxShowClientNameAlerts" runat="server" Text="Show Client Name" AutoPostBack="true" OnCheckedChanged="CheckBoxShow_CheckedChanged" />
            </div>
            <div>
                <asp:CheckBox ID="CheckBoxShowJobNumberAlerts" runat="server" Text="Show Job Number" AutoPostBack="true" OnCheckedChanged="CheckBoxShow_CheckedChanged" />
                <asp:CheckBox ID="CheckBoxShowJobComponentNumberAlerts" runat="server" Text="Show Job Component Number" AutoPostBack="true" OnCheckedChanged="CheckBoxShow_CheckedChanged" />
            </div>
            <div>
                <asp:CheckBox ID="CheckBoxShowJobDescriptionAlerts" runat="server" Text="Show Job Description" AutoPostBack="true" OnCheckedChanged="CheckBoxShow_CheckedChanged" />
                <asp:CheckBox ID="CheckBoxShowJobComponentDescriptionAlerts" runat="server" Text="Show Job Component Description" AutoPostBack="true" OnCheckedChanged="CheckBoxShow_CheckedChanged" />
            </div>
        </div>
        <div id="DivReviewSettings" runat="server" style="padding: 10px;">
            <h4>Proofs
            </h4>
            <div>
                <asp:CheckBox ID="CheckBoxShowClientNameReviews" runat="server" Text="Show Client Name" AutoPostBack="true" OnCheckedChanged="CheckBoxShow_CheckedChanged" />
            </div>
            <div>
                <asp:CheckBox ID="CheckBoxShowJobNumberReviews" runat="server" Text="Show Job Number" AutoPostBack="true" OnCheckedChanged="CheckBoxShow_CheckedChanged" />
                <asp:CheckBox ID="CheckBoxShowJobComponentNumberReviews" runat="server" Text="Show Job Component Number" AutoPostBack="true" OnCheckedChanged="CheckBoxShow_CheckedChanged" />
            </div>
            <div>
                <asp:CheckBox ID="CheckBoxShowJobDescriptionReviews" runat="server" Text="Show Job Description" AutoPostBack="true" OnCheckedChanged="CheckBoxShow_CheckedChanged" />
                <asp:CheckBox ID="CheckBoxShowJobComponentDescriptionReviews" runat="server" Text="Show Job Component Description" AutoPostBack="true" OnCheckedChanged="CheckBoxShow_CheckedChanged" />
            </div>
            <div style="display: none;">
                <asp:CheckBox ID="CheckBoxShowReviewInstructions" runat="server" Text="Show Review Instructions" AutoPostBack="true" OnCheckedChanged="CheckBoxShow_CheckedChanged" />
            </div>
        </div>
        <div style="padding: 10px;">
            <h4>Tasks
            </h4>
            <div>
                <asp:CheckBox ID="CheckBoxShowClientNameTasks" runat="server" Text="Show Client Name" AutoPostBack="true" OnCheckedChanged="CheckBoxShow_CheckedChanged" />
            </div>
            <div>
                <asp:CheckBox ID="CheckBoxShowJobNumberTasks" runat="server" Text="Show Job Number" AutoPostBack="true" OnCheckedChanged="CheckBoxShow_CheckedChanged" />
                <asp:CheckBox ID="CheckBoxShowJobComponentNumberTasks" runat="server" Text="Show Job Component Number" AutoPostBack="true" OnCheckedChanged="CheckBoxShow_CheckedChanged" />
            </div>
            <div>
                <asp:CheckBox ID="CheckBoxShowJobDescriptionTasks" runat="server" Text="Show Job Description" AutoPostBack="true" OnCheckedChanged="CheckBoxShow_CheckedChanged" />
                <asp:CheckBox ID="CheckBoxShowJobComponentDescriptionTasks" runat="server" Text="Show Job Component Description" AutoPostBack="true" OnCheckedChanged="CheckBoxShow_CheckedChanged" />
            </div>
            <div>
                <asp:CheckBox ID="CheckBoxShowTaskCommentTasks" runat="server" Text="Show Task Comment" AutoPostBack="true" OnCheckedChanged="CheckBoxShow_CheckedChanged" />
            </div>
            <div style="padding-top: 10px">
                <asp:Label ID="Label8" runat="server" SkinID="LabelSmall">Task Status:</asp:Label> &nbsp;
                <telerik:RadComboBox ID="RadComboBoxTaskStatus" runat="server" AutoPostBack="true" EnableViewState="true" SkinID="RadComboBoxStandard"
                        Width="200">
                        <Items>
                            <telerik:RadComboBoxItem Value="A" Text="All"></telerik:RadComboBoxItem>
                            <telerik:RadComboBoxItem Value="Projected" Text="Projected"></telerik:RadComboBoxItem>
                            <telerik:RadComboBoxItem Value="Active" Text="Active"></telerik:RadComboBoxItem>
                            <telerik:RadComboBoxItem Value="H" Text="High Priority"></telerik:RadComboBoxItem>
                            <telerik:RadComboBoxItem Value="L" Text="Low Priority"></telerik:RadComboBoxItem>
                            <telerik:RadComboBoxItem Value="Event_Tasks" Text="Event Tasks"></telerik:RadComboBoxItem>
                        </Items>
               </telerik:RadComboBox>
            </div>
            <div style="padding-top: 5px">
                <asp:Label ID="Label9" runat="server" SkinID="LabelSmall">Tasks:</asp:Label> &nbsp;
                <telerik:RadComboBox ID="RadComboBoxTasks" runat="server" AutoPostBack="true" EnableViewState="true" Width="250" SkinID="RadComboBoxStandard">
                        <Items>
                            <telerik:RadComboBoxItem Value="Today" Text="Open Tasks to Start as of Today"></telerik:RadComboBoxItem>
                            <telerik:RadComboBoxItem Value="All" Text="All Open Tasks"></telerik:RadComboBoxItem>
                        </Items>
                </telerik:RadComboBox>
                <asp:CheckBox ID="CheckBoxTodayOnlyWithStartDue" runat="server" Text="Only Tasks with Start and Due Dates" AutoPostBack="true"  />
            </div>
        </div>
                </ContentTemplate>
            </asp:UpdatePanel>
</asp:Content>
