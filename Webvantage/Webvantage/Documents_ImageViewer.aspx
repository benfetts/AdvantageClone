<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Documents_ImageViewer.aspx.vb"
    Inherits="Webvantage.Documents_ImageViewer" MasterPageFile="~/ChildPage.Master"
    Title="" %>

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
            function OnClientClose(sender, EventArgs) {
                __doPostBack('onclick#Refresh', 'Refresh');
            };
            function imposeMaxLength(Object, MaxLen) {
                return (Object.value.length <= MaxLen);
            };
            function RadToolBarDocumentViewer_ButtonClicked(sender, args) {

                var button = args.get_item();
                var panel = $find("<%= RadPanelBarComments.ClientID %>");
                var items = panel.get_items();

                if (button.get_value() == "ExpandAll") {

                    for (var i = 0; i < items.get_count() ; i++) {

                        items.getItem(i).expand();

                    };

                };
                if (button.get_value() == "CollapseAll") {

                    for (var i = 0; i < items.get_count() ; i++) {

                        items.getItem(i).collapse();

                    };

                };

            };
            function OnClientToolsDialogClosed(sender, eventArgs) {
                __doPostBack("<%= RadImageEditorImage.UniqueID %>", "Refresh");
            };
        </script>
    </telerik:RadScriptBlock>
    <style type="text/css">
        #left, #right {
            position: absolute; 
            left: 0; 
            width: 320px; 
            height: 100%;
            overflow: auto; 
        }
        #right {
            left: auto;
            right: 0; 
            width: 320px; 
            overflow: auto; 
        }
        #middle {
            position: fixed; 
            left: 320px;
            right: 320px;
            overflow: auto; 
        }
    </style>
    <telerik:RadToolBar ID="RadToolBarDocumentViewer" runat="server" AutoPostBack="true"
        Width="100%" OnClientButtonClicked="RadToolBarDocumentViewer_ButtonClicked">
        <Items>
            <telerik:RadToolBarButton ID="RadToolBarButtonFirstSeparator" runat="server" IsSeparator="true" />
            <telerik:RadToolBarButton ID="RadToolBarButtonAddComment" runat="server"
                Text="Add Comment" Value="AddComment" ToolTip="Add comment to page" />
            <telerik:RadToolBarButton ID="RadToolBarButtonDeleteComment" runat="server"
                Text="Delete Comment" Value="DeleteComment" ToolTip="Delete comment" />
            <telerik:RadToolBarButton ID="RadToolBarButtonSecondSeparator" runat="server" IsSeparator="true" />
            <telerik:RadToolBarButton ID="RadToolBarButtonExpandAll" runat="server" Text="Expand All"
                Value="ExpandAll" ToolTip="Expand all comments" PostBack="false" />
            <telerik:RadToolBarButton ID="RadToolBarButtonThirdSeparator" runat="server" IsSeparator="true" />
            <telerik:RadToolBarButton ID="RadToolBarButtonCollapseAll" runat="server" Text="Collapse All"
                Value="CollapseAll" ToolTip="Collapse all comments" PostBack="false" />
            <telerik:RadToolBarButton ID="RadToolBarButtonFourthSeparator" runat="server" IsSeparator="true" />
        </Items>
    </telerik:RadToolBar>
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
        <div style="width: 100%; margin: 0px;">
            <div id="left">
                <telerik:RadPanelBar ID="RadPanelBarComments" runat="server" Width="100%"
                    PersistStateInCookie="true" ExpandMode="MultipleExpandedItems" AllowCollapseAllItems="true">
                    <CollapseAnimation Type="None"></CollapseAnimation>
                    <ExpandAnimation Type="None"></ExpandAnimation>
                </telerik:RadPanelBar>
            </div>
            <div id="middle">
                <telerik:RadImageEditor ID="RadImageEditorImage" runat="server" Width="100%" RenderMode="Lightweight" 
                    ImageCacheStorageLocation="Session" 
                    ShowAjaxLoadingPanel="True" OnClientImageChanged="OnClientToolsDialogClosed" CanvasMode="No">
                    <Tools>
                        <telerik:ImageEditorToolGroup>
                            <telerik:ImageEditorTool CommandName="AddText" />
                        </telerik:ImageEditorToolGroup>
                    </Tools>
                </telerik:RadImageEditor>


            </div>
            <div id="right">
                <telerik:RadGrid ID="RadGridImageComments" runat="server" AllowPaging="false" AllowSorting="false"
                    GridLines="None" PageSize="10" EnableEmbeddedSkins="True" ShowFooter="false" Width="90%"
                    AutoGenerateColumns="false" PagerStyle-Visible="false">
                    <MasterTableView DataKeyNames="ID,UserCode,UserCodeCP">
                        <Columns>
                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnComment" HeaderText="Comment" DataField="Comment">
                                <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                                <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                                <FooterStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                                <ItemTemplate>
                                    <%#Eval("Comment")%>
                                    <br />
                                    &nbsp;&nbsp;-&nbsp;<%#Eval("UserCode")%>&nbsp;@<%#Eval("CreatedDate")%>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnDelete">
                                <HeaderStyle CssClass="radgrid-icon-column" />
                                <ItemStyle CssClass="radgrid-icon-column" />
                                <FooterStyle CssClass="radgrid-icon-column" />
                                <ItemTemplate>
                                    <div class="icon-background background-color-delete">
                                        <asp:ImageButton ID="ImageButtonDelete" runat="server" SkinID="ImageButtonDeleteWhite"
                                            ToolTip="Click to delete this comment" CommandName="DeleteRow" />
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                        <RowIndicatorColumn>
                            <HeaderStyle Width="20px" />
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn>
                            <HeaderStyle Width="20px" />
                        </ExpandCollapseColumn>
                    </MasterTableView>
                </telerik:RadGrid>
            </div>
        </div>
                </ContentTemplate>
            </asp:UpdatePanel>
</asp:Content>
