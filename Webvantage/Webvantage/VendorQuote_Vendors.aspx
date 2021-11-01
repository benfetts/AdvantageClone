<%@ Page AutoEventWireup="false" CodeBehind="VendorQuote_Vendors.aspx.vb" Inherits="Webvantage.VendorQuote_Vendors"
    MasterPageFile="~/ChildPage.Master" Title="" Language="vb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <script type="text/javascript">
        var selected = {};
        function RadGrid1_RowSelected(sender, args) {
            var mailID = args.getDataKeyValue("Code");
            if (!selected[mailID]) {
                selected[mailID] = true;
            }
        }
        function RadGrid1_RowDeselected(sender, args) {
            var mailID = args.getDataKeyValue("Code");
            if (selected[mailID]) {
                selected[mailID] = null;
            }
        }
        function RadGrid1_RowCreated(sender, args) {
            var mailID = args.getDataKeyValue("Code");
            if (selected[mailID]) {
                args.get_gridDataItem().set_selected(true);
            }
        }
        function GridCreated(sender, eventArgs) {
            var masterTable = sender.get_masterTableView();
            //check whether all items on the active page are selected
            if (masterTable.get_selectedItems().length == masterTable.get_pageSize()) {
                //find the checkbox in the header of the GridClientSelectColumn and set checked state for it - will work with AllowMultiRowSelection = true only!
                var gridHeader = masterTable.get_element().getElementsByTagName("TH")[0];
                for (var i = 0; i < gridHeader.childNodes.length; i++) {
                    if (gridHeader.childNodes[i].id.indexOf("columnSelectCheckBox") > -1) {
                        gridHeader.childNodes[i].checked = "true";
                    }
                }
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                <telerik:RadGrid ID="RadGridVendor" runat="server" AutoGenerateColumns="False" GridLines="None"
                    AllowFilteringByColumn="true" EnableEmbeddedSkins="True" AllowMultiRowSelection="true"
                    AllowSorting="true" EnableLinqExpressions="false" GroupingSettings-CaseSensitive="false">
                    <ClientSettings AllowColumnHide="True" AllowExpandCollapse="True">
                        <Scrolling AllowScroll="false" SaveScrollPosition="true" UseStaticHeaders="False" />
                        <Selecting AllowRowSelect="True" EnableDragToSelectRows="False" />
                        <ClientEvents OnRowCreated="RadGrid1_RowCreated" OnRowSelected="RadGrid1_RowSelected"
                            OnRowDeselected="RadGrid1_RowDeselected" OnGridCreated="GridCreated" />
                    </ClientSettings>
                    <MasterTableView DataKeyNames="Code" AllowFilteringByColumn="true" ClientDataKeyNames="Code">
                        <Columns>
                            <telerik:GridClientSelectColumn UniqueName="ColumnClientSelect">
                                <HeaderStyle HorizontalAlign="center" />
                                <ItemStyle HorizontalAlign="center" />
                            </telerik:GridClientSelectColumn>
                            <telerik:GridBoundColumn DataField="Code" HeaderText="Vendor" UniqueName="colVN_CODE"
                                SortExpression="Code" CurrentFilterFunction="Contains" AutoPostBackOnFilter="false"
                                FilterDelay="1250" ShowFilterIcon="True">
                                <HeaderStyle HorizontalAlign="left" />
                                <ItemStyle HorizontalAlign="left" VerticalAlign="middle" Width="100" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Description" HeaderText="Description" UniqueName="colVN_DESCRIPTION"
                                SortExpression="Description" CurrentFilterFunction="Contains" AutoPostBackOnFilter="false"
                                FilterDelay="1250" ShowFilterIcon="True">
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
            </td>
        </tr>
        <tr>
            <td>
                <asp:CheckBox ID="cbDefault" runat="server" Text='Show only vendors with default functions for those selected'
                    AutoPostBack="true" />
            </td>
        </tr>
        <tr>
            <td align="center">
                <br />
                <br />
                <asp:Button ID="BtnRefresh" runat="server" Text="Refresh" Visible="false" />
                &nbsp;&nbsp;
                <asp:Button ID="BtnCopy" runat="server" Text="Add Vendors" /><br />
                <br />
            </td>
        </tr>
    </table>
    <asp:Literal ID="LitScript" runat="server"></asp:Literal>
</asp:Content>
