<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="EmployeeTimeForecast_Settings.aspx.vb"
    MasterPageFile="~/ChildPage.Master" Title="Set Employee Time Forecast Settings"
    Inherits="Webvantage.EmployeeTimeForecast_Settings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <telerik:RadToolBar ID="RadToolBarEmployeeTimeForecast" runat="server" AutoPostBack="true"
        Width="100%">
        <Items>
            <telerik:RadToolBarButton ID="RadToolBarButtonFirstSeparator" runat="server" IsSeparator="true" />
            <telerik:RadToolBarButton ID="RadToolBarButtonDone" runat="server"
                Text="Done" Value="Done" ToolTip="Done modifying settings" />
            <telerik:RadToolBarButton ID="RadToolBarButtonSecondSeparator" runat="server" IsSeparator="true" />
            <telerik:RadToolBarButton ID="RadToolBarButtonLoadDefaults" runat="server" SkinID="RadToolBarButtonClear"
                Text="Load Defaults" Value="LoadDefaults" ToolTip="Load all settings default values" />
            <telerik:RadToolBarButton ID="RadToolBarButtonThirdSeparator" runat="server" IsSeparator="true" />
        </Items>
    </telerik:RadToolBar>
    <asp:PlaceHolder ID="PlaceHolderSettings" runat="server" EnableViewState="false">
    </asp:PlaceHolder>
</asp:Content>