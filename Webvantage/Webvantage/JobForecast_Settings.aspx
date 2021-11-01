<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="JobForecast_Settings.aspx.vb"
    MasterPageFile="~/ChildPage.Master" Title="Set Job Forecast Settings"
    Inherits="Webvantage.JobForecast_Settings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <telerik:RadToolBar ID="RadToolBarJobForecast" runat="server" AutoPostBack="true"
        Width="100%">
        <Items>
            <telerik:RadToolBarButton ID="RadToolBarButtonFirstSeparator" runat="server" IsSeparator="true" />
            <telerik:RadToolBarButton ID="RadToolBarButtonDone" runat="server"
                Text="Done" Value="Done" ToolTip="Done modifying settings" />
            <telerik:RadToolBarButton ID="RadToolBarButtonSecondSeparator" runat="server" IsSeparator="true" />
        </Items>
    </telerik:RadToolBar>
    <div class="form-layout" style="margin-top: 10px;">
        <ul>
            <li>Forecast:</li>
            <li><telerik:RadComboBox ID="RadComboBoxJobForecastType" runat="server" DataValueField="Code" DataTextField="Description" AutoPostBack="true" OnSelectedIndexChanged="RadComboBoxJobForecastType_SelectedIndexChanged" SkinID="RadComboBoxText20"></telerik:RadComboBox></li>
        </ul>
        <ul>
            <li></li>
            <li><asp:CheckBox ID="CheckBoxShowSalesClassColumn" runat="server" Text="Show Sales Class when grouped by Client" AutoPostBack="true" /></li>
        </ul>
        <ul>
            <li></li>
            <li><asp:CheckBox ID="CheckBoxShowApprovedEstimateColumn" runat="server" Text="Show Approved Estimate Amount" AutoPostBack="true" /></li>
        </ul>
    </div>
    <asp:PlaceHolder ID="PlaceHolderSettings" runat="server" EnableViewState="false">
    </asp:PlaceHolder>
</asp:Content>
