<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="DesktopBookmarks.ascx.vb"
    Inherits="Webvantage.DesktopBookmarks" %>
<script type="text/javascript">
    function onClientContextMenuShowing(sender, args) {
        var treeNode = args.get_node();
        treeNode.set_selected(true);
        //enable/disable menu items
        setMenuItemsState(args.get_menu().get_items(), treeNode);
    }
    function onClientContextMenuItemClicking(sender, args) {

        var menuItem = args.get_menuItem();
        var treeNode = args.get_node();
        menuItem.get_menu().hide();
        //alert(menuItem.get_value());
        switch (menuItem.get_value()) {
            case "Copy":
                break;
            case "Rename":
                treeNode.startEdit();
                break;
            case "NewFolder":
                break;
            case "Delete":

                var NodeItemTypeString = "item";
                var ExtraText = "";
                var ActionVerb = "";
                var NodeCategory = treeNode.get_category();
                var ParentNode = treeNode.get_parent();

                if (NodeCategory) {

                    NodeItemTypeString = NodeCategory;

                }

                //alert(NodeCategory);
                //alert(ParentNode.get_value());

                if (NodeCategory == "Bookmark" && ParentNode.get_value() == "-1") {

                    ActionVerb = "delete"
                    ExtraText = "Bookmark will be permanently deleted."

                }
                if (NodeCategory == "Bookmark" && ParentNode.get_value() != "-1") {

                    ActionVerb = "remove"
                    ExtraText = "Bookmark will move back to the \"Uncategorized\" Folder.";

                }
                if (NodeCategory == "Folder") {

                    ActionVerb = "delete"
                    ExtraText = "All Bookmarks will move back to the \"Uncategorized\" Folder.";

                }

                var result = confirm("Are you sure you want to " + ActionVerb + " the " + NodeItemTypeString + ": \"" + treeNode.get_text() + "\"?\n" + ExtraText);
                args.set_cancel(!result);

                break;

        }

    }
    function onClientNodeEdited(sender, args) {
        var treeNode = args.get_node();
        if (treeNode) {
            var nodeText = treeNode.get_text();
            nodeText = nodeText.toUpperCase();
            if (nodeText.indexOf("New Folder".toUpperCase(), 0) > -1) {
                alert("Folder name cannot include \"New Folder\".\nPlease try again.");
                RefreshThisPage();
            }
        }
    }
    //this method disables the appropriate context menu items
    function setMenuItemsState(menuItems, treeNode) {

        for (var i = 0; i < menuItems.get_count() ; i++) {

            var menuItem = menuItems.getItem(i);

            switch (menuItem.get_value()) {
                case "Rename":

                    formatMenuItem(menuItem, treeNode, 'Rename "{0}"');
                    break;

                case "Delete":

                    var ActionVerb = "";
                    var NodeCategory = treeNode.get_category();
                    var ParentNode = treeNode.get_parent();

                    if (NodeCategory == "Bookmark" && ParentNode.get_value() == "-1") {

                        ActionVerb = "Delete"

                    }
                    if (NodeCategory == "Bookmark" && ParentNode.get_value() != "-1") {

                        ActionVerb = "Remove"

                    }
                    if (NodeCategory == "Folder") {

                        ActionVerb = "Delete"

                    }


                    formatMenuItem(menuItem, treeNode, ActionVerb + ' "{0}"');
                    break;

                case "NewFolder":

                    if (treeNode.get_parent() == treeNode.get_treeView() && treeNode.get_value() == "-1") {

                        menuItem.set_enabled(true);

                    }
                    else {

                        menuItem.set_enabled(false);

                    }

                    break;

            }

        }

    }
    //formats the Text of the menu item
    function formatMenuItem(menuItem, treeNode, formatString) {
        var nodeValue = treeNode.get_value();
        var menuItemValue = menuItem.get_value();

        menuItem.set_enabled(true);

        if (nodeValue == "-1" && (menuItemValue.indexOf("Rename") > -1 || menuItemValue.indexOf("Delete") > -1)) {
            menuItem.set_enabled(false);
        }

        var newText = String.format(formatString, formatText(treeNode));
        menuItem.set_text(newText);

    }
    //checks if the text contains (digit)
    function hasNodeMails(treeNode) {
        return treeNode.get_text().match(/\([\d]+\)/ig);
    }
    function formatText(treeNode) {
        return treeNode.get_text();
    }
</script>
<table cellpadding="0" cellspacing="2" border="0" width="100%">
    <tr>
        <td align="right" valign="middle">
            <asp:RadioButton ID="RadioButtonShowAsTree" runat="server" GroupName="GridOrTree"
                Text="Folders" AutoPostBack="true" Checked="true" Visible="false" />
            <asp:RadioButton ID="RadioButtonShowAsGrid" runat="server" GroupName="GridOrTree"
                Text="Grid" AutoPostBack="true" Visible="false" />
            &nbsp;&nbsp;
                <asp:CheckBox ID="CheckBoxGroup" runat="server" Text="Group" AutoPostBack="true"
                    Visible="false" />
            &nbsp;&nbsp;
                <asp:CheckBox ID="CheckBoxShowEdit" runat="server" Text="Edit" AutoPostBack="true"
                    Visible="false" />
            &nbsp;&nbsp;
                <asp:ImageButton ID="ImageButtonRefresh" runat="server" ImageAlign="AbsMiddle" SkinID="ImageButtonRefresh" ToolTip="Refresh" />
        </td>
    </tr>
    <tr id="TrShowAsGrid" runat="Server">
        <td>
            <telerik:RadGrid ID="RadGridBookmarks" runat="server" ShowHeader="False" BorderStyle="None"
                GridLines="None" AutoGenerateColumns="False" CellSpacing="0" Width="100%">
                <MasterTableView AutoGenerateColumns="False" CommandItemDisplay="None" DataKeyNames="Id">
                    <CommandItemSettings ExportToPdfText="Export to PDF" ShowRefreshButton="true" ShowAddNewRecordButton="false"></CommandItemSettings>
                    <RowIndicatorColumn Visible="False">
                        <HeaderStyle Width="20px" />
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn Resizable="False" Visible="False">
                        <HeaderStyle Width="20px" />
                    </ExpandCollapseColumn>
                    <Columns>
                        <telerik:GridTemplateColumn DataField="Name" DataType="System.String" HeaderText=""
                            UniqueName="GridTemplateColumnBookmarkName">
                            <ItemTemplate>
                                <asp:HyperLink ID="HyperLinkBookmarkName" runat="server" Text='<%# Eval("Name") %>'
                                    ToolTip='<%# Eval("Description") %>' href=""></asp:HyperLink>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <div style="position: relative; float: right; margin-bottom: 4px;">
                                    Name:&nbsp;<asp:TextBox ID="TextBoxBookmarkName" runat="server" Text='<%# Eval("Name") %>'
                                        MaxLength="100"></asp:TextBox>
                                </div>
                                <div style="position: relative; float: right;">
                                    Desc:&nbsp;<asp:TextBox ID="TextBoxDescription" runat="server" Text='<%# Eval("Description") %>'
                                        MaxLength="500"></asp:TextBox>
                                </div>
                                <br />
                            </EditItemTemplate>
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="left" />
                            <FooterStyle HorizontalAlign="right" />
                        </telerik:GridTemplateColumn>
                        <telerik:GridEditCommandColumn ButtonType="ImageButton" UniqueName="EditCommandColumn">
                            <HeaderStyle CssClass="radgrid-icon-column" />
                            <ItemStyle CssClass="radgrid-icon-column" />
                            <FooterStyle CssClass="radgrid-icon-column" />
                        </telerik:GridEditCommandColumn>
                        <telerik:GridButtonColumn ConfirmText="Delete this record?" ConfirmDialogType="RadWindow"
                            ConfirmTitle="Delete" ButtonType="ImageButton" CommandName="Delete" Text="Delete"
                            UniqueName="DeleteColumn">
                            <HeaderStyle CssClass="radgrid-icon-column" />
                            <ItemStyle CssClass="radgrid-icon-column" />
                            <FooterStyle CssClass="radgrid-icon-column" />
                        </telerik:GridButtonColumn>
                    </Columns>
                    <EditFormSettings>
                        <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                        </EditColumn>
                    </EditFormSettings>
                </MasterTableView>
                <FilterMenu EnableImageSprites="False">
                </FilterMenu>
            </telerik:RadGrid>
        </td>
    </tr>
    <tr id="TrShowAsTree" runat="Server">
        <td>
            <telerik:RadTreeView ID="RadTreeViewBookmarks" runat="server"
                AllowNodeEditing="true"
                EnableDragAndDrop="true"
                EnableDragAndDropBetweenNodes="true"
                OnClientNodeEdited="onClientNodeEdited"
                OnClientContextMenuItemClicking="onClientContextMenuItemClicking"
                OnClientContextMenuShowing="onClientContextMenuShowing" ShowLineImages="false">
                <ContextMenus>
                    <telerik:RadTreeViewContextMenu ID="MainContextMenu" runat="server">
                        <Items>
                            <telerik:RadMenuItem Value="Rename" Text="Rename" Enabled="false" PostBack="false">
                            </telerik:RadMenuItem>
                            <telerik:RadMenuItem Value="Delete" Text="Delete">
                            </telerik:RadMenuItem>
                            <telerik:RadMenuItem IsSeparator="true">
                            </telerik:RadMenuItem>
                            <telerik:RadMenuItem Value="NewFolder" Text="New Folder">
                            </telerik:RadMenuItem>
                        </Items>
                        <CollapseAnimation Type="none" />
                    </telerik:RadTreeViewContextMenu>
                    <telerik:RadTreeViewContextMenu ID="EmptyFolderContextMenu" runat="server">
                        <Items>
                            <telerik:RadMenuItem Value="NewFolder" Text="New Folder">
                            </telerik:RadMenuItem>
                        </Items>
                        <CollapseAnimation Type="none" />
                    </telerik:RadTreeViewContextMenu>
                </ContextMenus>
            </telerik:RadTreeView>
        </td>
    </tr>
</table>