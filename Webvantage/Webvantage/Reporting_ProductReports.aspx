<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Reporting_ProductReports.aspx.vb"
    MasterPageFile="~/ChildPage.Master" Title="Product Reports" Inherits="Webvantage.Reporting_ProductReports" %>

<asp:Content ID="ContentProductReports" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div >
        <telerik:RadToolBar ID="RadToolbarProductReports" runat="server" AutoPostBack="True" Width="100%">
            <Items>
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton runat="server" ID="RadToolBarButtonPrint" SkinID="RadToolBarButtonPrint" Text="Print" Value="Print"
                    ToolTip="Print Selected Report" />
                <telerik:RadToolBarButton IsSeparator="true" />
            </Items>
        </telerik:RadToolBar>
    </div>
    <div >
    </div>
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
        <table width="99%" border="0" cellspacing="2" cellpadding="0">
            <tr>
                <td align="left" valign="bottom" width="100%">Report Formats
                </td>
            </tr>
            <tr>
                <td align="left" valign="top">
                    <telerik:RadListBox ID="RadListBoxReportFormats" runat="server" Width="100%"
                        AutoPostBack="false"  SelectionMode="Single" AllowTransfer="false"
                        AllowReorder="false" EnableDragAndDrop="false" DataValueField="Code" DataTextField="Description">
                    </telerik:RadListBox>
                </td>
            </tr>
        </table>
                </ContentTemplate>
            </asp:UpdatePanel>
</asp:Content>
