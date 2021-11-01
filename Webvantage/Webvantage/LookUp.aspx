<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="LookUp.aspx.vb" Inherits="Webvantage.LookUp" %>

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
            }
            function RowDoubleClick(itemIndex) {
                __doPostBack("<%= RadGridLookup.UniqueID %>", "IndexOfRowDoubleClicked:" + itemIndex);
            }
            function RadGridLookupRowClick(sender, eventArgs) {
                RowClick(eventArgs.get_itemIndexHierarchical());
            }
            function RowClick(itemIndex) {
                __doPostBack("<%= RadGridLookup.UniqueID %>", "IndexOfRowClicked:" + itemIndex);
            }
            function returnValue() {
                var oWnd = GetRadWindow();
                var CallingWindowName = '<%= Me.OpenerRadWindowName %>';
                if (typeof oWnd.get_windowManager !== 'undefined') {
                    var CallingWindow = null;
                    var controlsToSet = "";
                    var CallingWindowContent;
                    controlsToSet = document.getElementById("<%= HiddenFieldControlsToSet.ClientID%>").value;
                    try {
                        if (oWnd.get_windowManager()) {
                            CallingWindow = oWnd.get_windowManager().getWindowByName(CallingWindowName);
                        }
                    } catch (e) {
                        CallingWindow = null;
                    }
                    if (!CallingWindow) {
                        //console.log("Browser Window?", oWnd.BrowserWindow);
                        CallingWindowContent = oWnd.BrowserWindow;
                        if (CallingWindowContent) {
                            try {
                                eval(controlsToSet);
                            } catch(e){}
                            cancelClick();
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
                    controlsToSet = document.getElementById("<%= HiddenFieldControlsToSet.ClientID%>").value;
                    oWnd.BrowserWindow.Close(controlsToSet);
                }
                //Close the second RadWindow
            }
            function cancelClick() {
                try {
                    //CloseThisWindow();
                } catch (e) {
                    console.log(e);
                }
                try {
                    var oWnd = GetRadWindow();
                    if (oWnd) {
                        oWnd.close();
                    }
                } catch (e) {
                    console.log(e);
                }
            }
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
                    console.log(e);
                }
            }

        </script>
    </telerik:RadScriptBlock>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
        <asp:HiddenField ID="HiddenFieldLookupType" runat="server" Value="" />
        <asp:HiddenField ID="HiddenFieldControlsToSet" runat="server" Value="" />
        <table width="100%" border="0" cellspacing="2" cellpadding="0">
            <tr>
                <td align="center" valign="top">
                    <telerik:RadGrid ID="RadGridLookup" runat="server" AllowMultiRowSelection="False"
                        AllowPaging="False" AllowFilteringByColumn="true" AllowSorting="False"
                        ShowStatusBar="false" ShowFooter="false" ShowHeader="True" AutoGenerateColumns="False"
                        GridLines="None" EnableEmbeddedSkins="True" GroupingSettings-CaseSensitive="false"
                        Width="580">
                        <PagerStyle Mode="NumericPages" Visible="False" AlwaysVisible="true" Position="Bottom"
                            Height="0px"></PagerStyle>
                        <StatusBarSettings LoadingText="Loading Data" ReadyText="Data Loaded." />
                        <ClientSettings EnablePostBackOnRowClick="False">
                            <Scrolling AllowScroll="true" EnableVirtualScrollPaging="False" ScrollHeight="580"
                                SaveScrollPosition="True" />
                            <Selecting AllowRowSelect="True" EnableDragToSelectRows="True" />
                            <ClientEvents OnRowDblClick="RadGridLookupRowDoubleClick" OnGridCreated="RadGridLookupGridCreated" />
                        </ClientSettings>
                        <MasterTableView DataKeyNames="code" TableLayout="auto">
                            <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                                <HeaderStyle Width="20px"></HeaderStyle>
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                                <HeaderStyle Width="20px"></HeaderStyle>
                            </ExpandCollapseColumn>
                            <Columns>
                                <telerik:GridBoundColumn DataField="description" UniqueName="GridBoundColumnDescription"
                                    FilterControlAltText="Filter column"
                                    FilterControlWidth="480" HeaderText="Search List" CurrentFilterFunction="Contains"
                                    AutoPostBackOnFilter="false" ShowFilterIcon="True" FilterDelay="1250">
                                    <HeaderStyle HorizontalAlign="left" />
                                    <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                                </telerik:GridBoundColumn>
                            </Columns>
                            <ExpandCollapseColumn Visible="False">
                            </ExpandCollapseColumn>
                            <RowIndicatorColumn Visible="False">
                            </RowIndicatorColumn>
                        </MasterTableView>
                    </telerik:RadGrid>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="CheckboxClosedJobs" runat="server" AutoPostBack="True" Checked="False"
                        EnableViewState="True" Text="Show closed/archived jobs?" />
                    <asp:CheckBox ID="CheckBoxMediaVendors" runat="server" AutoPostBack="True" Checked="False"
                        EnableViewState="True" Text="Show Media Vendors" />
                </td>
            </tr>
            <tr>
                <td align="center" valign="top">
                    <asp:Button ID="ButtonSelect" runat="server" Text="Select" />&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" OnClientClick="cancelClick();" />
                </td>
            </tr>
        </table>
                </ContentTemplate>
            </asp:UpdatePanel>
</asp:Content>
