<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Documents_ExcelViewer.aspx.vb" Inherits="Webvantage.Documents_ExcelViewer" MasterPageFile="~/ChildPage.Master" Title="" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="ContentDocumentViewer" ContentPlaceHolderID="ContentPlaceHolderMain"
    runat="server">
    <telerik:RadScriptBlock ID="RadScriptBlock" runat="server">
        <script type="text/javascript">
            function RefreshPage(radWindowCaller) {
                __doPostBack('onclick#Refresh', 'Refresh');
            };
            function SaveFromPopUp(radWindowCaller) {
                __doPostBack('onclick#Save', 'Save');
            };
            function RealPostBack(eventTarget, eventArgument) {
                __doPostBack(eventTarget, eventArgument);
            };
            function HidePopUpWindows(radWindowCaller) {
                __doPostBack('onclick#Refresh', 'HidePopups');
            };
            function imposeMaxLength(Object, MaxLen) {
                return (Object.value.length <= MaxLen);
            };
            function RadToolBarDocumentViewer_ButtonClicked(sender, args) {

                var button = args.get_item();
                var panel = $find("<%= RadPanelBarComments.ClientID %>");
                var items = panel.get_items();

                if (button.get_value() == "ExpandAll") {

                    for (var i = 0; i < items.get_count(); i++) {

                        items.getItem(i).expand();

                    }

                }
                if (button.get_value() == "CollapseAll") {

                    for (var i = 0; i < items.get_count(); i++) {

                        items.getItem(i).collapse();

                    }

                }

            } 
        </script>
    </telerik:RadScriptBlock>
    <telerik:RadToolBar ID="RadToolBarDocumentViewer" runat="server" AutoPostBack="true"
        Width="100%" OnClientButtonClicked="RadToolBarDocumentViewer_ButtonClicked">
        <Items>
            <telerik:RadToolBarButton ID="RadToolBarButtonFirstSeparator" runat="server" IsSeparator="true" />
            <telerik:RadToolBarButton ID="RadToolBarButtonGoToFirstPage" runat="server" Text="<<"
                Value="<<" ToolTip="Go to first page" />
            <telerik:RadToolBarButton ID="RadToolBarButtonSecondSeparator" runat="server" IsSeparator="true" />
            <telerik:RadToolBarButton ID="RadToolBarButtonGoToPreviousPage" runat="server" Text="<"
                Value="<" ToolTip="Go to previous page" />
            <telerik:RadToolBarButton ID="RadToolBarButtonThirdSeparator" runat="server" IsSeparator="true" />
            <telerik:RadToolBarButton ID="RadToolBarButtonGoToNextPage" runat="server" Text=">"
                Value=">" ToolTip="Go to next page" />
            <telerik:RadToolBarButton ID="RadToolBarButtonFourthSeparator" runat="server" IsSeparator="true" />
            <telerik:RadToolBarButton ID="RadToolBarButtonGoToLastPage" runat="server" Text=">>"
                Value=">>" ToolTip="Go to last page" />
            <telerik:RadToolBarButton ID="RadToolBarButtonFifthSeparator" runat="server" IsSeparator="true" />
            <telerik:RadToolBarButton ID="RadToolBarButtonAddComment" runat="server" 
                Text="Add Comment" Value="AddComment" ToolTip="Add comment to page" />
            <telerik:RadToolBarButton ID="RadToolBarButtonDeleteComment" runat="server"
                Text="Delete Comment" Value="DeleteComment" ToolTip="Delete comment" />
            <telerik:RadToolBarButton ID="RadToolBarButtonSixthSeparator" runat="server" IsSeparator="true" />
            <telerik:RadToolBarButton ID="RadToolBarButtonExpandAll" runat="server" Text="Expand All"
                Value="ExpandAll" ToolTip="Expand all comments"  PostBack="false"/>
            <telerik:RadToolBarButton ID="RadToolBarButtonSeventhSeparator" runat="server" IsSeparator="true" />
            <telerik:RadToolBarButton ID="RadToolBarButtonCollapseAll" runat="server" Text="Collapse All"
                Value="CollapseAll" ToolTip="Collapse all comments" PostBack="false"/>
            <telerik:RadToolBarButton ID="RadToolBarButtonEighthSeparator" runat="server" IsSeparator="true" />
        </Items>
    </telerik:RadToolBar>
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
        <table border="0" cellpadding="0" cellspacing="1" width="100%">
            <tr>
                <td width="25%" align="left" valign="top">
                    <telerik:RadPanelBar ID="RadPanelBarComments" runat="server" Width="100%" Height="100%"
                        PersistStateInCookie="true" ExpandMode="MultipleExpandedItems" AllowCollapseAllItems="true">
                        <CollapseAnimation Type="None"></CollapseAnimation>
                        <ExpandAnimation Type="None"></ExpandAnimation>
                    </telerik:RadPanelBar>
                </td>
                <td>
                    &nbsp;
                </td>
                <td width="75%">
                    <telerik:RadBinaryImage ID="RadBinaryImagePage" runat="server" ResizeMode="Fit" Width="98%"
                        Height="100%" BorderStyle="Solid" BorderColor="LightBlue" BorderWidth="2" />
                </td>
            </tr>
        </table>
                </ContentTemplate>
            </asp:UpdatePanel>
</asp:Content>
