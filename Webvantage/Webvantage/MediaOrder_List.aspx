<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="MediaOrder_List.aspx.vb" Inherits="Webvantage.MediaOrder_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">

    <telerik:RadCodeBlock ID="RadCodeBlockMain" runat="server">
        <script src="Scripts/js.cookie.min.js"></script>
        <script type="text/javascript">

            var currentTextBox = null;
            var currentDatePicker = null;
            var currentDataKey = "";

            function setDataKey(datakey) {
                currentDataKey = datakey;
            };
            function dataChangeRadGridMediaOrderLines(RowDataKey, ControlType, ControlName, ControlValue, dataChangeSucceeded, dataChangeFailed) {
                try {
                    PageMethods.SaveMediaOrderLinesRow(RowDataKey, ControlType, ControlName, ControlValue, dataChangeSucceeded, dataChangeFailed);
                    return false;
                } catch (err) {
                };
            };
            function dataChangeCheckBoxIsOrder(ChkRowDataKey, ControlClientId) {
                try {
                    var val = 0;
                    if (document.getElementById(ControlClientId).checked) {
                        val = 1;
                    };
                    PageMethods.SaveMediaOrderLinesRow(ChkRowDataKey, "chk", "CheckBoxIsOrder", val, dataChangeSucceeded, dataChangeFailed);
                    return false;
                } catch (err) {
                };
            };
            function setOrderProcessingControlEdit(IsOrderCheckbox, OrderProcessingControlRadComboBox, CanEdit) {
                var chk = document.getElementById(IsOrderCheckbox); //$find(IsOrderCheckbox);
                var cbo = $find(OrderProcessingControlRadComboBox);
                if (CanEdit == true) {
                    if (chk && cbo) {
                        if (chk.checked === false) {
                            //alert("allow cbo edit");
                            cbo.enable();
                        } else {
                            cbo.disable();
                        };
                    };
                };
                return false;
            };
            function dataChangeSucceeded(result) {
                //if (result == "REBIND") {
                //    __doPostBack("UpdatePanelMediaOrderList", "");
                //};
                //return false;
            };
            function dataChangeFailed(error) {
                ShowMessage("Failed to load data\n" + error);
                return false;
            };
            function RadGridMediaOrdersColumnHeaderMenu(ev) {
                var grid = $find("<%= RadGridMediaOrderLines.ClientID %>");
                grid.get_masterTableView().get_columns()[0].showHeaderMenu(ev, 30, 40);
            };
            //This method is called to handle the onclick and onfocus client side events for the texbox
            function showPopup(sender, e) {
                currentTextBox = sender.tagName == "INPUT" ? sender : $telerik.getPreviousHtmlNode(sender);
                var datePicker = $find("<%=RadDatePickerForGrid.ClientID%>");
                currentDatePicker = datePicker;
                datePicker.set_selectedDate(currentDatePicker.get_dateInput().parseDate(currentTextBox.value));
                var position = $telerik.getLocation(currentTextBox);
                datePicker.showPopup(position.x, position.y + currentTextBox.offsetHeight);
                return false;
                //alert("showPopup")
            };
            //this handler is used to set the text of the TextBox to the value of selected from the popup
            function dateSelected(sender, args) {
                if (currentTextBox != null) {
                    currentTextBox.value = args.get_newValue();
                    //dataChange(currentDataKey, "txt", currentTextBox.name, currentTextBox.value);
                    PageMethods.SaveMediaOrderLinesRow(currentDataKey, "txt", currentTextBox.name, currentTextBox.value, dataChangeSucceeded, dataChangeFailed);
                    return false;
                };
            };
            //this function is used to parse the date entered or selected by the user
            function parseDate(sender, e) {
                if (currentDatePicker != null) {
                    var date = currentDatePicker.get_dateInput().parseDate(sender.value);
                    var dateInput = currentDatePicker.get_dateInput();
                    if (date == null) {
                        date = currentDatePicker.get_selectedDate();
                    };
                    var formattedDate = dateInput.get_dateFormatInfo().FormatDate(date, dateInput.get_displayDateFormat());
                    sender.value = formattedDate;
                };
            };
            //$(document).ready(function () {
            //    if (Cookies.get("mediaorderlist_scroll")) {
            //        $(document).scrollTop(Cookies.get("mediaorderlist_scroll"));
            //    };
            //    $(window).scroll(function () {
            //        Cookies.set("mediaorderlist_scroll", $(document).scrollTop())
            //    });
            //});

        </script>
    </telerik:RadCodeBlock>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div class="telerik-aqua-body" style="margin-top: 5px!important; max-width: 96%!important;">
            <div class="more-info">
                <div style="display: inline-block; margin: 0px 0px 0px 0px;">
                    <asp:CheckBox ID="CheckBoxIncludeAvailableMedia" runat="server" AutoPostBack="true" Text="Show available media" />
                </div>
                <div style="display: none; margin: 0px 0px 0px 20px;">
                    Include:
                    <asp:CheckBox ID="CheckBoxIncludeInternet" runat="server" AutoPostBack="true" Text="Internet" ToolTip="Include Internet" Checked="true" />
                    <asp:CheckBox ID="CheckBoxIncludeMagazine" runat="server" AutoPostBack="true" Text="Magazine" ToolTip="Include Magazine" Checked="true" />
                    <asp:CheckBox ID="CheckBoxIncludeNewspaper" runat="server" AutoPostBack="true" Text="Newspaper" ToolTip="Include Newspaper" Checked="true" />
                    <asp:CheckBox ID="CheckBoxIncludeOutOfHome" runat="server" AutoPostBack="true" Text="Out of Home" ToolTip="Include Out of Home" Checked="true" />
                    <asp:CheckBox ID="CheckBoxIncludeRadio" runat="server" AutoPostBack="true" Text="Radio" ToolTip="Include Radio" />
                    <asp:CheckBox ID="CheckBoxIncludeTV" runat="server" AutoPostBack="true" Text="TV" ToolTip="Include TV" Checked="true" />
                </div>
                <div style="display: inline-block; margin: 0px 0px 0px 20px;">
                    Group By:
                    <telerik:RadComboBox ID="RadComboBoxGroupBy" runat="server" AutoPostBack="true">
                    </telerik:RadComboBox>
                </div>
            </div>
            <telerik:RadDatePicker ID="RadDatePickerForGrid" Style="display: none;" SkinID="RadDatePickerStandard" runat="server">
                <ClientEvents OnDateSelected="dateSelected" />
            </telerik:RadDatePicker>
            <div style="margin: 0px 0px 80px 0px;">
                <telerik:RadGrid ID="RadGridMediaOrderLines" runat="server" AllowFilteringByColumn="True" AllowPaging="true" AllowSorting="true" AllowMultiRowSelection="true"
                    AutoGenerateColumns="False" EnableViewState="True" GroupPanelPosition="Top" ShowGroupPanel="False" PageSize="15">
                    <ItemStyle Wrap="false"></ItemStyle>
                    <GroupingSettings CaseSensitive="false" />
                    <ClientSettings AllowDragToGroup="False" AllowColumnsReorder="False">
                        <Scrolling SaveScrollPosition="true" />
                        <Selecting AllowRowSelect="true" EnableDragToSelectRows="true" />
                        <ClientEvents OnColumnHidden="OnColumnHidden" OnColumnShown="OnColumnShown"></ClientEvents>
                    </ClientSettings>
                    <MasterTableView AllowMultiColumnSorting="true" Caption="" EnableHeaderContextMenu="true" HeaderStyle-VerticalAlign="Bottom" NoMasterRecordsText=""
                        DataKeyNames="OrderType, OrderNumber, LineNumber, RevisionNumber, SequenceNumber, JobNumber, JobComponentNumber, IsInJob">
                        <ColumnGroups>
                            <telerik:GridColumnGroup HeaderText="Vendor" Name="GridColumnGroupVendor" HeaderStyle-HorizontalAlign="Left">
                            </telerik:GridColumnGroup>
                            <telerik:GridColumnGroup HeaderText="Ad Size" Name="GridColumnGroupAdSize" HeaderStyle-HorizontalAlign="Left">
                            </telerik:GridColumnGroup>
                            <telerik:GridColumnGroup HeaderText="Order Line" Name="GridColumnGroupOrderLine" HeaderStyle-HorizontalAlign="Left">
                            </telerik:GridColumnGroup>
                        </ColumnGroups>
                        <Columns>
                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnAddToThisJob" HeaderText="Add" HeaderTooltip="Move available media into job" AllowFiltering="false">
                                <HeaderStyle CssClass="radgrid-icon-column" />
                                <ItemStyle CssClass="radgrid-icon-column" />
                                <FooterStyle CssClass="radgrid-icon-column" />
                                <HeaderTemplate>
                                    <asp:ImageButton ID="ImageButtonAddSelectedToThisJob" runat="server" CssClass="icon-image" ImageUrl="~/Images/Icons/Grey/256/arrow_into.png" ToolTip="Move selected available media rows into this job" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <div id="DivAddToThisJob" runat="server" class="icon-background background-color-sidebar">
                                        <asp:ImageButton ID="ImageButtonAddToThisJob" runat="server" CssClass="icon-image" ImageUrl="~/Images/Icons/White/256/arrow_into.png" ToolTip="Move into this job" />
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnRemoveFromThisJob" HeaderText="Remove" HeaderTooltip="Move media out of this job" AllowFiltering="false">
                                <HeaderStyle CssClass="radgrid-icon-column" />
                                <ItemStyle CssClass="radgrid-icon-column" />
                                <FooterStyle CssClass="radgrid-icon-column" />
                                <HeaderTemplate>
                                    <asp:ImageButton ID="ImageButtonRemoveSelectedFromThisJob" runat="server" ToolTip="Move selected media rows out of this job" CssClass="icon-image" ImageUrl="~/Images/Icons/Grey/256/arrow_out.png" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <div id="DivRemoveFromThisJob" runat="server" class="icon-background background-color-sidebar">
                                        <asp:ImageButton ID="ImageButtonRemoveFromThisJob" runat="server" ToolTip="Move out of this job" CssClass="icon-image" ImageUrl="~/Images/Icons/White/256/arrow_out.png" />
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnViewDetails" HeaderAbbr="FIXED" AllowFiltering="true" FilterControlWidth="40"  DataField="OrderType" SortExpression="OrderType"
                                CurrentFilterFunction="StartsWith" ShowFilterIcon="False" FilterDelay="1250" AutoPostBackOnFilter="false">
                                <HeaderStyle CssClass="radgrid-icon-column" VerticalAlign="Middle" HorizontalAlign="Left" />
                                <ItemStyle CssClass="radgrid-icon-column" VerticalAlign="Middle" HorizontalAlign="Left" />
                                <FooterStyle CssClass="radgrid-icon-column" VerticalAlign="Middle" HorizontalAlign="Left" />
                                <HeaderTemplate>
                                    <asp:ImageButton ID="ImageButtonColumnPreferences" runat="server" ImageAlign="AbsMiddle" CssClass="column-prefs-icon"
                                        ImageUrl="~/Images/Icons/Grey/256/table_selection_column.png" ToolTip="Column Preferences" OnClientClick="RadGridMediaOrdersColumnHeaderMenu(event);" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <div class="icon-background background-color-sidebar" style="display: none !important;">
                                        <asp:ImageButton ID="ImageButtonViewDetails" runat="server" CommandName="ViewDetails" ToolTip="View details" AlternateText="View details" SkinID="ImageButtonViewWhite" />
                                    </div>
                                    <asp:Label ID="LabelOrderType" runat="server" Text='<%# If(Eval("IsInJob") = True, Eval("OrderType"), Eval("OrderType") & "*")%>'
                                        ToolTip='<%#If(Eval("IsInJob") = True,Eval("OrderTypeName") & " order",Eval("OrderTypeName") & " order (Not in this job)")%>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnOrderNumber" DataField="OrderNumber" DataType="System.Int32" HeaderText="Order Number" SortExpression="OrderNumber"
                                FilterControlWidth="200" CurrentFilterFunction="EqualTo" ShowFilterIcon="False" FilterDelay="1250" AutoPostBackOnFilter="false">
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                                <FooterStyle HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnOrderDescription" DataField="OrderDescription" DataType="System.String" HeaderText="Order Description" SortExpression="OrderDescription"
                                FilterControlWidth="60" CurrentFilterFunction="Contains" ShowFilterIcon="False" FilterDelay="1250" AutoPostBackOnFilter="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnOrderDate" DataField="OrderDate" DataType="System.DateTime" DataFormatString="{0:d}" HeaderText="Order Date" SortExpression="OrderDate" AllowFiltering="false">
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                                <FooterStyle HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnIsOrder" DataField="IsOrder" DataType="System.Boolean" HeaderText="Type" SortExpression="IsOrder" AllowFiltering="false">
                                <ItemTemplate>
                                    <telerik:RadComboBox ID="RadComboBoxIsOrder" runat="server" OnSelectedIndexChanged="RadComboBoxIsOrder_SelectedIndexChanged" Width="85" AutoPostBack="true" Enabled="true" SkinID="RadComboBoxStandard">
                                        <Items>
                                            <telerik:RadComboBoxItem Text="Order" Value="0" />
                                            <telerik:RadComboBoxItem Text="Quote" Value="1" />
                                        </Items>
                                    </telerik:RadComboBox>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnOrderProcessingControl" DataField="OrderProcessingControl" DataType="System.Int16" HeaderText="Processing Control" SortExpression="OrderProcessingControl" AllowFiltering="false">
                                <HeaderStyle HorizontalAlign="Right" Width="145" />
                                <ItemStyle HorizontalAlign="Right" Width="145" />
                                <FooterStyle HorizontalAlign="Right" Width="145" />
                                <ItemTemplate>
                                    <telerik:RadComboBox ID="RadComboBoxOrderProcessingControl" runat="server" OnSelectedIndexChanged="RadComboBoxOrderProcessingControl_SelectedIndexChanged" Width="145" AutoPostBack="true" Enabled="true" SkinID="RadComboBoxStandard">
                                    </telerik:RadComboBox>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnVendorCode" DataField="VendorCode" DataType="System.String" HeaderText="Vendor Code" SortExpression="VendorCode"
                                FilterControlWidth="85" CurrentFilterFunction="Contains" ShowFilterIcon="False" FilterDelay="1250" AutoPostBackOnFilter="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnVendorName" DataField="VendorName" DataType="System.String" HeaderText="Vendor Name" SortExpression="VendorName"
                                FilterControlWidth="200" CurrentFilterFunction="Contains" ShowFilterIcon="False" FilterDelay="1250" AutoPostBackOnFilter="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnLineNumber" DataField="LineNumber" DataType="System.Int32" HeaderText="Line" SortExpression="LineNumber" AllowFiltering="false">
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                                <FooterStyle HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnRevisionNumber" DataField="RevisionNumber" DataType="System.Int32" HeaderText="Revision" SortExpression="RevisionNumber" AllowFiltering="false">
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                                <FooterStyle HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnLineIsCancelled" DataField="LineIsCancelled" DataType="System.Boolean" HeaderText="Cancelled" SortExpression="LineIsCancelled" AllowFiltering="false">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                                <FooterStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <div class="icon-background standard-green" style='<%# If(Eval("LineIsCancelled") = True, "display:block;", "display:none;")%>'>
                                        <asp:Image ID="ImageLineIsCancelled" runat="server" ImageUrl="~/Images/Icons/White/256/check.png" CssClass="icon-image" ToolTip="Yes" />
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnOrderLineStatus" DataField="OrderLineStatusDescription" DataType="System.String" HeaderText="Status" SortExpression="OrderLineStatusDescription" AllowFiltering="false">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButtonOrderLineStatus" runat="server" Text='<%#Eval("OrderLineStatusDescription")%>' Visible="true" ToolTip="Click to view status history"></asp:LinkButton>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnOrderLineStartDate" DataField="StartDate" DataType="System.DateTime" DataFormatString="{0:d}" HeaderText="Start" SortExpression="StartDate" AllowFiltering="false">
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                                <FooterStyle HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnOrderLineEndDate" DataField="EndDate" DataType="System.DateTime" DataFormatString="{0:d}" HeaderText="End" SortExpression="EndDate" AllowFiltering="false">
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                                <FooterStyle HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnAdSizeCode" DataField="AdSizeCode" DataType="System.String" HeaderText="Ad Size Code" SortExpression="AdSizeCode"
                                FilterControlWidth="85" CurrentFilterFunction="Contains" ShowFilterIcon="False" FilterDelay="1250" AutoPostBackOnFilter="false">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButtonAdSizeCode" runat="server" Text='<%#Eval("AdSizeCode")%>' Visible="false"></asp:LinkButton>
                                    <asp:Label ID="LabelAdSizeCode" runat="server" Text='<%#Eval("AdSizeCode")%>' Visible="true"></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnAdSizeDescription" DataField="AdSizeDescription" DataType="System.String" HeaderText="Ad Size Description" SortExpression="AdSizeDescription"
                                FilterControlWidth="200" CurrentFilterFunction="Contains" ShowFilterIcon="False" FilterDelay="1250" AutoPostBackOnFilter="false">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButtonAdSizeDescription" runat="server" Text='<%#Eval("AdSizeDescription")%>' Visible="false"></asp:LinkButton>
                                    <asp:Label ID="LabelAdSizeDescription" runat="server" Text='<%#Eval("AdSizeDescription")%>' Visible="true"></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnDateToBill" DataField="DateToBill" DataType="System.DateTime" HeaderText="Date To  Bill" SortExpression="DateToBill" AllowFiltering="false">
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                                <FooterStyle HorizontalAlign="Right" />
                                <ItemTemplate>
                                    <asp:TextBox ID="TextBoxDateToBill" runat="server" SkinID="TextBoxShortDate" MaxLength="10" Text='<%#String.Format("{0:d}", Eval("DateToBill"))%>' ReadOnly="false"></asp:TextBox>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnNetAmount" DataField="NetAmount" DataType="System.Decimal" DataFormatString="{0:C}" HeaderText="Net" SortExpression="NetAmount" AllowFiltering="false">
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                                <FooterStyle HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnGrossAmount" DataField="GrossAmount" DataType="System.Decimal" DataFormatString="{0:C}" HeaderText="Gross" SortExpression="GrossAmount" AllowFiltering="false">
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                                <FooterStyle HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnBillingAmount" DataField="BillingAmount" DataType="System.Decimal" DataFormatString="{0:C}" HeaderText="Billing" SortExpression="BillingAmount" AllowFiltering="false">
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                                <FooterStyle HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
            </div>

    </div>

</asp:Content>
