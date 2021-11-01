<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="EmployeeTimeForecast_CreateRevision.aspx.vb"
    MasterPageFile="~/ChildPage.Master" Title="Create Employee Time Forecast Office Detail Revision"
    Inherits="Webvantage.EmployeeTimeForecast_CreateRevision" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
        <telerik:RadToolBar ID="RadToolBarEmployeeTimeForecast" runat="server" AutoPostBack="true"
            Width="100%">
            <Items>
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton Text="Create Revision" Value="CreateRevision"
                    runat="server" id="RadToolBarButtonCreateRevision" ToolTip="Proceed with creating revision" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonCancel" Text="Cancel" Value="Cancel"
                    ToolTip="Cancel creating revision" />
                <telerik:RadToolBarButton IsSeparator="true" />
            </Items>
        </telerik:RadToolBar>
        <table width="100%" border="0" cellspacing="2" cellpadding="0">
            <tr>
                <td width="100%">
                    <asp:CheckBox ID="CheckBoxUpdateEmployeeRates" runat="server" AutoPostBack="false"
                        Text="Update Forecast with current employee rates and recalculate totals" Checked="false"
                        Width="100%" />
                </td>
            </tr>
            <tr>
                <td width="100%">
                    <asp:CheckBox ID="CheckBoxUpdateRevenueAmounts" runat="server" AutoPostBack="false"
                        Text="Update Forecast with current revenue amounts based on approved estimates"
                        Checked="false" Width="100%" />
                </td>
            </tr>
            <tr>
                <td width="100%">
                    <asp:CheckBox ID="CheckBoxExcludeHoursEnteredInCopy" runat="server" AutoPostBack="false"
                        Text="Exclude hours entered in copy" Checked="false" Width="100%" />
                </td>
            </tr>
        </table>
                </ContentTemplate>
            </asp:UpdatePanel>
</asp:Content>
