<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Lookup_VendorPrice.aspx.vb"
    Inherits="Webvantage.Lookup_VendorPrice" MasterPageFile="~/ChildPage.Master"
    Title="" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <style type="text/css">
        html {
            overflow: hidden;
        }
    </style>
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
        <script type="text/javascript">
            function RadGridVendorPriceListRowDoubleClick(sender, eventArgs) {
                RowDoubleClick(eventArgs.get_itemIndexHierarchical());
            }
            function RowDoubleClick(itemIndex) {
                __doPostBack("<%= RadGridVendorPriceList.UniqueID%>", "IndexOfRowDoubleClicked:" + itemIndex);
            }
            function RadGridVendorPriceListRowClick(sender, eventArgs) {
                RowClick(eventArgs.get_itemIndexHierarchical());
            }
            function RowClick(itemIndex) {
                __doPostBack("<%= RadGridVendorPriceList.UniqueID%>", "IndexOfRowClicked:" + itemIndex);
            }
            <%--function returnValue() {
                //Get a reference to the parent (MDI) page 
                var oWnd = GetRadWindow();
                //get a reference to the second RadWindow
                var CallingWindowName = '<%= Me.OpenerRadWindowName %>';
                var CallingWindow = oWnd.get_windowManager().getWindowByName(CallingWindowName);
                // Get a reference to the first RadWindow's content
                var CallingWindowContent = CallingWindow.get_contentFrame().contentWindow;
                //Call the predefined function in Dialog1
                var controlsToSet = "";
                controlsToSet = document.getElementById("<%= HiddenFieldControlsToSet.ClientID%>").value;
                var ContentPageHiddenField = CallingWindowContent.document.getElementById("ctl00_ContentPlaceHolderMain_ContentPageHiddenFieldLookupPassthrough");

                if (ContentPageHiddenField) {
                    cts = controlsToSet;
                    ContentPageHiddenField.value = cts;
                    CallingWindowContent.setIFrameContentControls();
                } else {
                    eval(controlsToSet);
                };
                RefreshWindow('<%= Me.caller%>', false, false);
                //Close the second RadWindow
                oWnd.close();
            }--%>

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
                }
            }
        </script>
    </telerik:RadScriptBlock>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
        <asp:HiddenField ID="HiddenFieldControlsToSet" runat="server" Value="" />

        <table width="100%" border="0" cellspacing="2" cellpadding="0">
            <tr>
                <td align="center" valign="top">
                    <telerik:RadGrid ID="RadGridVendorPriceList" runat="server" AllowPaging="False" AllowSorting="True" 
                        AutoGenerateColumns="False" GridLines="None" GroupingSettings-GroupByFieldsSeparator="  " Width="99%">
                        <PagerStyle Mode="NextPrevAndNumeric" NextPageText="&amp;gt;" PrevPageText="&amp;lt;" Visible="False" AlwaysVisible="true" />
                        <ClientSettings EnablePostBackOnRowClick="False" AllowColumnsReorder="true">
                            <Scrolling AllowScroll="True" EnableVirtualScrollPaging="False" ScrollHeight="100%"
                                SaveScrollPosition="True" />
                            <Selecting AllowRowSelect="True" EnableDragToSelectRows="True" />
                            <ClientEvents OnRowDblClick="RadGridVendorPriceListRowDoubleClick" OnGridCreated="RadGridLookupGridCreated" />
                        </ClientSettings>
                        <MasterTableView HorizontalAlign="Left" DataKeyNames="VendorCode,JobTypeCode,Rate">
                            <GroupByExpressions>
                                <telerik:GridGroupByExpression>
                                    <SelectFields>
                                        <telerik:GridGroupByField FieldAlias="Type" FieldName="JobTypeDescription" FormatString=""
                                            HeaderText="" />
                                    </SelectFields>
                                    <GroupByFields>
                                        <telerik:GridGroupByField FieldName="JobTypeCode" FieldAlias="JobTypeCode" FormatString=""
                                            HeaderText="" />
                                    </GroupByFields>
                                </telerik:GridGroupByExpression>
                            </GroupByExpressions>
                            <Columns>
                                <telerik:GridBoundColumn DataField="Description" HeaderText="Description" UniqueName="Description"></telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Rate" HeaderText="Rate" UniqueName="Rate"></telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Notes" HeaderText="Comments" UniqueName="Comments"></telerik:GridBoundColumn>
                            </Columns>
                            <FilterItemStyle VerticalAlign="Top" Wrap="False" />
                            <ExpandCollapseColumn Visible="False">
                                <HeaderStyle Width="19px" />
                            </ExpandCollapseColumn>
                            <PagerStyle Mode="NextPrevAndNumeric" />
                            <RowIndicatorColumn Visible="False">
                                <HeaderStyle Width="20px" />
                            </RowIndicatorColumn>
                        </MasterTableView>
                        <SortingSettings SortedAscToolTip="Sorted ascending" SortedDescToolTip="Sorted descending" />
                        <AlternatingItemStyle VerticalAlign="Top" />
                        <FilterItemStyle HorizontalAlign="Left" Wrap="False" />
                        <GroupingSettings GroupByFieldsSeparator=" " />
                    </telerik:RadGrid>
                </td>
            </tr>
            <tr>
                <td align="center" valign="top">
                    <asp:Button ID="ButtonSelect" runat="server" Text="Select" />&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="ButtonClose" runat="server" Text="Cancel" OnClientClick="cancelClick();" />
                </td>
            </tr>
        </table>

                </ContentTemplate>
            </asp:UpdatePanel>

</asp:Content>
