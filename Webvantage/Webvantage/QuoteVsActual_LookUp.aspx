<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="QuoteVsActual_LookUp.aspx.vb" Title=""
    Inherits="Webvantage.QuoteVsActual_LookUp" MasterPageFile="~/ChildPage.Master" %>

<asp:Content ID="ContentQuoteVsActualLookUp" ContentPlaceHolderID="ContentPlaceHolderMain"
    runat="server">
        <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
    <script type="text/javascript">
        function ASPxGridViewQuoteVsActualLookUp_RowDblClick(sender, eventArgs) {
            __doPostBack("<%= ASPxGridViewQuoteVsActualLookUp.UniqueID %>", "IndexOfRowDoubleClicked:" + eventArgs.visibleIndex);
        } 
    </script>
    </telerik:RadScriptBlock>
    <div id="TdRadToolBarQuoteVsActualLookUp" style="margin-left: auto; margin-right: auto; left: 0; right: 0; text-align: center;">
        <telerik:RadToolBar ID="RadToolBarQuoteVsActualLookUp" runat="server" AutoPostBack="true"
                    Width="100%">
                    <Items>
                        <telerik:RadToolBarButton ID="RadToolBarSeparatorFirstSeparator" runat="server" IsSeparator="true" />
                        <telerik:RadToolBarButton ID="RadToolBarButtonSelect" runat="server" Text="Select"
                            Value="Select" CommandName="Select" ToolTip="Select Report Template" />
                        <telerik:RadToolBarButton ID="RadToolBarSeparatorSecondSeparator" runat="server"
                            IsSeparator="true" />
                        <telerik:RadToolBarButton SkinID="RadToolBarButtonBookmark" Text="Bookmark" Value="Bookmark" ToolTip="Bookmark" />
                        <telerik:RadToolBarButton Text="Refresh Data" Value="Data" CommandName="Data" />
                    </Items>
                </telerik:RadToolBar>
    </div>
    <div class="telerik-aqua-body">
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                    <dx:ASPxGridView ID="ASPxGridViewQuoteVsActualLookUp" runat="server" Width="100%"
                        Settings-ShowTitlePanel="false" Settings-ShowVerticalScrollBar="false" 
                        EnableCallbackCompression="false" SettingsPager-PageSize="15" >
                        <Settings ShowHeaderFilterButton="true" />
                        <SettingsBehavior ColumnResizeMode="Control" AllowSelectByRowClick="true" AllowSelectSingleRowOnly="true" />
                        <Styles>
                            <Header Font-Names="Arial" />
                        </Styles>
                        <ClientSideEvents RowDblClick="ASPxGridViewQuoteVsActualLookUp_RowDblClick" />
                    </dx:ASPxGridView>
                </ContentTemplate>
            </asp:UpdatePanel>
    </div>

                

        
    <br />
</asp:Content>
