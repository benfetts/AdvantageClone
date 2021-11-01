<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="LookUp_Vendor.aspx.vb"
    MasterPageFile="~/ChildPage.Master" Title="" Inherits="Webvantage.LookUp_Vendor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <style type="text/css">
        html {
            overflow: hidden;
        }
    </style>
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
        <script type="text/javascript">
            function RadGridLookupRowDoubleClick(sender, eventArgs) {
                RowDoubleClick(eventArgs.get_itemIndexHierarchical());
            };
            function RowDoubleClick(itemIndex) {
                __doPostBack("<%= RadGridLookup.UniqueID %>", "IndexOfRowDoubleClicked:" + itemIndex);
            };
            function RadGridLookupRowClick(sender, eventArgs) {
                RowClick(eventArgs.get_itemIndexHierarchical());
            };
            function RowClick(itemIndex) {
                __doPostBack("<%= RadGridLookup.UniqueID %>", "IndexOfRowClicked:" + itemIndex);
            };
            function returnValue() {
               var oWnd = GetRadWindow();
                var CallingWindowName = '';
                if (typeof oWnd.get_windowManager !== 'undefined') {
                    var CallingWindow = null;
                    var controlsToSet = "";
                    var CallingWindowContent;
                    controlsToSet = document.getElementById("ctl00_ContentPlaceHolderMain_HiddenFieldControlsToSet").value;
                    try {
                        if (oWnd.get_windowManager()) {
                            CallingWindow = oWnd.get_windowManager().getWindowByName(CallingWindowName);
                        }
                    } catch (e) {
                        CallingWindow = null;
                    }
                    if (!CallingWindow) {
                        console.log("Browser Window?", oWnd.BrowserWindow);
                        CallingWindowContent = oWnd.BrowserWindow;
                        if (CallingWindowContent) {
                            eval(controlsToSet);
                        }                        
                    } else {
                        CallingWindowContent = CallingWindow.get_contentFrame().contentWindow;
                        var ContentPageHiddenField = CallingWindowContent.document.getElementById("ctl00_ContentPlaceHolderMain_ContentPageHiddenFieldLookupPassthrough");
                        try {
                            if (ContentPageHiddenField) {
                                cts = controlsToSet;
                                ContentPageHiddenField.value = cts;
                                CallingWindowContent.setIFrameContentControls();
                            } else {
                                eval(controlsToSet);
                            }
                        }
                        catch (e) {
                            console.log(e);
                        }
                    }
                    oWnd.close();
                }
                else {
                    controlsToSet = document.getElementById("ctl00_ContentPlaceHolderMain_HiddenFieldControlsToSet").value;
                    oWnd.BrowserWindow.Close(controlsToSet);
                }
            };
            function RadGridLookupGridCreated(sender, args) {
                try {
                    var win = GetRadWindow();
                    var clientHeight = 0;
                    if (win) {
                        clientHeight = win.get_height();
                        var scrollArea = sender.GridDataDiv;
                        clientHeight = clientHeight - 100;
                        scrollArea.style.height = clientHeight + "px";
                    }
                } catch (e) {
                }
            }
        </script>
    </telerik:RadScriptBlock>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
        <asp:HiddenField ID="HiddenFieldControlsToSet" runat="server" Value="" />
        <div id="DivAddEdit" runat="server" style="padding: 10px 6px;">
            <asp:ImageButton ID="imgbtnAdd" runat="server" SkinID="ImageButtonNew" ToolTip="Add Vendor Contact" />&nbsp;
        <asp:ImageButton ID="imgbtnEdit" runat="server" SkinID="ImageButtonEdit" ToolTip="Edit Vendor Contact" />
        </div>
        <telerik:RadGrid ID="RadGridLookup" runat="server" AllowMultiRowSelection="False"
            AllowPaging="False" AllowFilteringByColumn="true" AllowSorting="False"
            ShowStatusBar="false" ShowFooter="false" ShowHeader="True" AutoGenerateColumns="False"
            GridLines="None" EnableEmbeddedSkins="True" GroupingSettings-CaseSensitive="false"
            Width="580">
            <PagerStyle Mode="NumericPages" Visible="False" AlwaysVisible="true" Position="Bottom"
                Height="0px"></PagerStyle>
            <StatusBarSettings LoadingText="Loading Data" ReadyText="Data Loaded." />
            <ClientSettings EnablePostBackOnRowClick="False">
                <Scrolling AllowScroll="true" EnableVirtualScrollPaging="False" ScrollHeight="595"
                    SaveScrollPosition="True" />
                <Selecting AllowRowSelect="True" EnableDragToSelectRows="True" />
                <ClientEvents OnRowDblClick="RadGridLookupRowDoubleClick" OnGridCreated="RadGridLookupGridCreated" />
            </ClientSettings>
            <MasterTableView DataKeyNames="CODE1" TableLayout="auto">
                <Columns>
                    <telerik:GridBoundColumn DataField="VALUE1" UniqueName="GridBoundColumnVALUE" FilterControlWidth="480"
                        HeaderText="Search List" CurrentFilterFunction="Contains" AutoPostBackOnFilter="false"
                        ShowFilterIcon="True" FilterDelay="1250">
                        <HeaderStyle HorizontalAlign="left" />
                        <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                    </telerik:GridBoundColumn>
                </Columns>
                <ExpandCollapseColumn Visible="False">
                    <HeaderStyle Width="19px" />
                </ExpandCollapseColumn>
                <RowIndicatorColumn Visible="False">
                    <HeaderStyle Width="20px" />
                </RowIndicatorColumn>
            </MasterTableView>
        </telerik:RadGrid>
        <div style="text-align: center; margin-top: 20px;">
            <asp:Button ID="btn_Select" runat="server" Text="Select" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <input onclick="JavaScript: window.close();" type="button" value="Cancel" /><br />
        </div>
        <input id="txtCode" runat="server" name="txtCode" type="hidden" />
        <input id="txtValue" runat="server" name="txtValue" type="hidden" />
        <input id="txtValue2" runat="server" name="txtValue2" type="hidden" />
        <input id="txtValue3" runat="server" name="txtValue3" type="hidden" />
        <input id="txtValue4" runat="server" name="txtValue4" type="hidden" />
        <input id="txtValue5" runat="server" name="txtValue5" type="hidden" />
        <input id="txtValue6" runat="server" name="txtValue6" type="hidden" />
        <input id="txtValue7" runat="server" name="txtValue7" type="hidden" />
        <input id="txtValue8" runat="server" name="txtValue8" type="hidden" />
        <input id="txtValue9" runat="server" name="txtValue8" type="hidden" />
        <asp:Label ID="lbl_control" runat="server" Visible="False"></asp:Label>
                </ContentTemplate>
            </asp:UpdatePanel>
</asp:Content>
