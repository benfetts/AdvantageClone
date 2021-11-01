<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="EmployeeTimeForecast_New.aspx.vb"
    Inherits="Webvantage.EmployeeTimeForecast_New" MasterPageFile="~/ChildPage.Master"
    Title="Add New Employee Time Forecast" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
        <telerik:RadToolBar ID="RadToolBarEmployeeTimeForecast" runat="server" AutoPostBack="true"
            Width="100%">
            <Items>
                <telerik:RadToolBarButton ID="RadToolBarButtonFirstSeparator" runat="server" IsSeparator="true" />
                <telerik:RadToolBarButton ID="RadToolBarButtonSave" runat="server" SkinID="RadToolBarButtonSave"
                    Text="" Value="Save" ToolTip="Save new Employee Time Forecast" />
                <telerik:RadToolBarButton ID="RadToolBarButtonSecondSeparator" runat="server" IsSeparator="true" />
                <telerik:RadToolBarButton ID="RadToolBarButtonCancel" runat="server" SkinID="RadToolBarButtonCancel"
                    Text="Cancel" Value="Cancel" ToolTip="Back to Employee Time Forecast" />
                <telerik:RadToolBarButton ID="RadToolBarButtonThirdSeparator" runat="server" IsSeparator="true" />
            </Items>
        </telerik:RadToolBar>
        <div class="code-description-container">
            <div class="code-description-label">
                Description:
            </div>
            <div style="display: inline-block; width: 540px; vertical-align: middle; margin: 0px 0px 0px 0px;">
                 <asp:TextBox ID="TextBoxDescription" runat="server" Text="" Width="95%" SkinID="TextBoxStandard">
                    </asp:TextBox>
            </div>
        </div>
        <div class="code-description-container">
                <div class="code-description-label">
                    Office:
                </div>
                <div style="display: inline-block; width: 540px; vertical-align: middle; margin: 0px 0px 0px 0px;">
                     <telerik:RadComboBox ID="DropDownListOffice" runat="server" AutoPostBack="true" Width="99%" SkinID="RadComboBoxStandard"
                        DataTextField="Name" DataValueField="Code">
                    </telerik:RadComboBox>
                </div>
        </div>
        <div class="code-description-container">
            <div class="code-description-label">
                Post Period:
            </div>
            <div style="display: inline-block; width: 540px; vertical-align: middle; margin: 0px 0px 0px 0px;">
                 <telerik:RadComboBox ID="DropDownListPostPeriod" runat="server" AutoPostBack="false" SkinID="RadComboBoxStandard"
                        Width="99%" DataTextField="MonthAndYear" DataValueField="Code">
                    </telerik:RadComboBox>
            </div>
        </div>
        <div class="code-description-container">
            <div class="code-description-label">
               Assigned Employee:
            </div>
            <div style="display: inline-block; width: 540px; vertical-align: middle; margin: 0px 0px 0px 0px;">
                 <telerik:RadComboBox ID="DropDownListEmployee" runat="server" AutoPostBack="false" SkinID="RadComboBoxStandard"
                        Width="99%" DataTextField="Name" DataValueField="Code">
                    </telerik:RadComboBox>
            </div>
        </div>
        <div class="code-description-container">
            <div class="code-description-label">
                <asp:CheckBox ID="CheckBoxCopyFrom" runat="server" AutoPostBack="true" Text="Copy From:"
                        Checked="false" />
            </div>
            <div style="display: inline-block; width: 540px; vertical-align: middle; margin: 0px 0px 0px 0px;">
                 <telerik:RadComboBox ID="DropDownListEmployeeTimeForecasts" runat="server" Enabled="false" SkinID="RadComboBoxStandard"
                        AutoPostBack="false" DataTextField="Description" DataValueField="ID" Width="99%">
                    </telerik:RadComboBox>
            </div>
        </div>
        <div class="code-description-container">
            <div class="code-description-label">
            </div>
            <div style="display: inline-block; width: 540px; vertical-align: middle; margin: 0px 0px 0px 0px;">
                 <asp:CheckBox ID="CheckBoxUpdateEmployeeRates" runat="server" AutoPostBack="false"
                        Text="Update Forecast with current employee rates and recalculate totals" Checked="false"
                         Enabled="false" />
            </div>
        </div>
        <div class="code-description-container">
            <div class="code-description-label">
            </div>
            <div style="display: inline-block; width: 540px; vertical-align: middle; margin: 0px 0px 0px 0px;">
                 <asp:CheckBox ID="CheckBoxUpdateRevenueAmounts" runat="server" AutoPostBack="false"
                        Text="Update Forecast with current revenue amounts based on approved estimates"
                        Checked="false"  Enabled="false" />
            </div>
        </div>
        <div class="code-description-container">
            <div class="code-description-label">
            </div>
            <div style="display: inline-block; width: 540px; vertical-align: middle; margin: 0px 0px 0px 0px;">
                 <asp:CheckBox ID="CheckBoxExcludeHoursEnteredInCopy" runat="server" AutoPostBack="false"
                        Text="Exclude hours entered in copy" Checked="false"  Enabled="false" />
            </div>
        </div>
        
                </ContentTemplate>
            </asp:UpdatePanel>
</asp:Content>
