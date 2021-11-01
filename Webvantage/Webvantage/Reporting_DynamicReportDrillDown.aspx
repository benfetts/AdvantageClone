<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="Reporting_DynamicReportDrillDown.aspx.vb" Inherits="Webvantage.Reporting_DynamicReportDrillDown" Title="Report Writer" %>

<asp:Content ID="ContentDynamicReports" ContentPlaceHolderID="ContentPlaceHolderMain"
    runat="server">
    <script type="text/javascript">
        function ReloadColumns(radWindowCaller) {
            __doPostBack('onclick#ReloadColumns', 'ReloadColumns');
        };
        function RefreshGrid(radWindowCaller) {
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
    </script>
    <table align="center" border="0" cellpadding="0" cellspacing="0" 
        width="100%">
        <tr>
            <td colspan="2">
                <telerik:RadTabStrip ID="RadTabStrip" runat="server" MultiPageID="RadMultiPage"
                    SelectedIndex="0" Align="Left" Width="100%">
                    <Tabs>                        
                        <telerik:RadTab Text="Printing">
                        </telerik:RadTab>
                    </Tabs>
                </telerik:RadTabStrip>
                <telerik:RadMultiPage ID="RadMultiPage" runat="server" SelectedIndex="0" Width="100%">                    
                    <telerik:RadPageView ID="RadPageViewPrinting" runat="server">
                        <telerik:RadToolBar ID="RadToolBarPrinting" runat="server" AutoPostBack="true" Width="100%">
                            <Items>
                                <telerik:RadToolBarButton ID="RadToolBarButtonPrintingFirstSeparator" runat="server"
                                    IsSeparator="true" />
                                <telerik:RadToolBarButton ID="RadToolBarButtonPrintToPDF" runat="server" Text="To PDF"
                                    Value="ToPDF" CommandName="ToPDF" ToolTip="Print To PDF" />
                                <telerik:RadToolBarButton ID="RadToolBarButtonPrintingSecondSeparator" runat="server"
                                    IsSeparator="true" />
                                <telerik:RadToolBarButton ID="RadToolBarButtonPrintToXLS" runat="server" Text="To XLS"
                                    Value="ToXLS" CommandName="ToXLS" ToolTip="Print To XLS" />
                                <telerik:RadToolBarButton ID="RadToolBarButtonPrintToXLSValue" runat="server" Text="To XLS (Value)"
                                    Value="ToXLSValue" CommandName="ToXLSValue" ToolTip="Print To XLS (Value)" />
                                <telerik:RadToolBarButton ID="RadToolBarButtonPrintingThirdSeparator" runat="server"
                                    IsSeparator="true" />
                                <telerik:RadToolBarButton ID="RadToolBarButtonPrintToXLSX" runat="server" Text="To XLSX"
                                    Value="ToXLSX" CommandName="ToXLSX" ToolTip="Print To XLSX" />
                                <telerik:RadToolBarButton ID="RadToolBarButtonPrintToXLSXValue" runat="server" Text="To XLSX (Value)"
                                    Value="ToXLSXValue" CommandName="ToXLSXValue" ToolTip="Print To XLSX (Value)" />
                                <telerik:RadToolBarButton ID="RadToolBarButtonPrintingFourthSeparator" runat="server"
                                    IsSeparator="true" />
                                <telerik:RadToolBarButton ID="RadToolBarButtonPrintToRTF" runat="server" Text="To RTF"
                                    Value="ToRTF" CommandName="ToRTF" ToolTip="Print To RTF" />
                                <telerik:RadToolBarButton ID="RadToolBarButtonPrintingFifthSeparator" runat="server"
                                    IsSeparator="true" />
                                <telerik:RadToolBarButton ID="RadToolBarButtonPrintToCSV" runat="server" Text="To CSV"
                                    Value="ToCSV" CommandName="ToCSV" ToolTip="Print To CSV" />
                                <telerik:RadToolBarButton ID="RadToolBarButtonPrintingSixthSeparator" runat="server"
                                    IsSeparator="true" />
                            </Items>
                        </telerik:RadToolBar>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <telerik:RadTabStrip ID="RadTabStripReport" runat="server" MultiPageID="RadMultiPageReport"
                    AutoPostBack="true" SelectedIndex="0" Style="z-index: 1000;">
                    <Tabs>
                        <telerik:RadTab Text="Report">
                        </telerik:RadTab>
                    </Tabs>
                </telerik:RadTabStrip>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <br />
                <telerik:RadMultiPage ID="RadMultiPageReport" runat="server" SelectedIndex="0">
                    <telerik:RadPageView ID="RadPageViewDynamicReport" runat="server">
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                            <dx:ASPxGridView ID="ASPxGridViewDynamicReport" runat="server" Width="100%" Settings-ShowHorizontalScrollBar="True"
                                Settings-ShowTitlePanel="False" Settings-ShowVerticalScrollBar="False" Settings-EnableFilterControlPopupMenuScrolling="True"
                                Settings-ShowGroupFooter="VisibleIfExpanded" EnableCallbackCompression="false" SettingsPager-PageSize="25" EnableRowsCache="true">

                                <ClientSideEvents ContextMenu="function(s, e) {if(e.objectType == 'header') 
                                                                          headerMenu.ShowAtPos(ASPxClientUtils.GetEventX(e.htmlEvent), ASPxClientUtils.GetEventY(e.htmlEvent));}" />
                                <SettingsBehavior ColumnResizeMode="Control" />
                                <SettingsDetail ExportMode="All" />
                                <Styles>
                                    <Header Font-Names="Arial" />
                                </Styles>

                            </dx:ASPxGridView>
                            <dx:ASPxGridViewExporter ID="ASPxGridViewExporter" runat="server" GridViewID="ASPxGridViewDynamicReport">
                            </dx:ASPxGridViewExporter>
                </ContentTemplate>
            </asp:UpdatePanel>
                    </telerik:RadPageView>                    
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>
