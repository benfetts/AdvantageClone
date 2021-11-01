<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Reporting_InitialLoadingRefreshData.aspx.vb"
    Inherits="Webvantage.Reporting_InitialLoadingRefreshData" Title="Save Report Template"
    MasterPageFile="~/ChildPage.Master" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <table align="center" border="0" cellpadding="0" cellspacing="0" 
        width="100%">
        <tr>
            <td runat="server" id="TdRadToolBarDynamicReportTemplates" align="left" valign="top"
                colspan="2">
                <telerik:RadToolBar ID="RadToolBarDynamicReportTemplates" runat="server" AutoPostBack="true"
                    Width="100%">
                    <Items>
                        <telerik:RadToolBarButton ID="RadToolBarSeparatorFirstSeparator" runat="server" IsSeparator="true" />
                        <telerik:RadToolBarButton ID="RadToolBarButtonYes" runat="server" Text="Yes" Value="Yes"
                            CommandName="Yes" ToolTip="Refresh Data" SkinID="RadToolBarButtonRefresh" />
                        <telerik:RadToolBarButton ID="RadToolBarSeparatorSecondSeparator" runat="server"
                            IsSeparator="true" />
                        <telerik:RadToolBarButton ID="RadToolBarButtonNo" runat="server" Text="No" Value="No"
                            CommandName="No" ToolTip="No" SkinID="RadToolBarButtonCancel" />
                        <telerik:RadToolBarButton ID="RadToolBarSeparatorThirdSeparator" runat="server" IsSeparator="true" />
                    </Items>
                </telerik:RadToolBar>
            </td>
        </tr>
        <tr>
            <td width="1%">
                &nbsp;
            </td>
            <td>
                <br />
            </td>
        </tr>
        <tr>
            <td width="1%">
                &nbsp;
            </td>
            <td>
                <asp:Label ID="LabelQuestion" runat="server" Text="" Width="100%"></asp:Label>
                <asp:Label ID="LabelQuestion1" runat="server" Text="" Width="100%"></asp:Label>
            </td>
        </tr>        
    </table>
    <br />
</asp:Content>
