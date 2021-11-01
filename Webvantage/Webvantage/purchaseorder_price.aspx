<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="purchaseorder_price.aspx.vb"
    Inherits="Webvantage.purchaseorder_price" MasterPageFile="~/ChildPage.Master"
    Title="" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <script type="text/javascript">
        function calcTotal() {
            var rate = document.frmPriceList.txt_rate2.value;
            var qty = document.frmPriceList.txtqty.value;
            var total;

            total = qty * rate;
            if (!isNaN(total)) {
                document.frmPriceList.txt_total.value = CurrencyFormatted(total);
            }

        }
        function CurrencyFormatted(amount) {
            var i = parseFloat(amount);
            if (isNaN(i)) { i = 0.00; }
            var minus = '';
            if (i < 0) { minus = '-'; }
            i = Math.abs(i);
            i = parseInt((i + .005) * 100);
            i = i / 100;
            s = new String(i);
            if (s.indexOf('.') < 0) { s += '.00'; }
            if (s.indexOf('.') == (s.length - 2)) { s += '0'; }
            s = minus + s;
            return s;
        }

        function returnValue() {
            //Get a reference to the parent (MDI) page 
            var oWnd = GetRadWindow();
            //get a reference to the second RadWindow
            var CallingWindowName = '<%= Me.OpenerRadWindowName %>';
            //var CallingWindow = oWnd.get_windowManager().getWindowByName(CallingWindowName);
            //var windows = oWnd.get_windowManager().get_windows();
            <%--for (var i = 0; i < windows.length; i++) {
                //alert(windows[i].get_name() + ": " + windows[i].get_navigateUrl() + "\n");
                var s;
                s = windows[i].get_navigateUrl()
                var arCurr = new Array();
                arCurr = s.split('.');
                s = arCurr[0];
                //alert(s);
                if (s == 'purchaseorder_dtl') {
                    CallingWindow = windows[i]
                }
            }--%>
            // Get a reference to the first RadWindow's content
            var CallingWindowContent = oWnd.BrowserWindow.Frame.contentWindow;
            //Call the predefined function in Dialog1                
                <%= Me.ControlsToSet %>
            //Close the second RadWindow
            oWnd.BrowserWindow.Frame.contentWindow.CloseWindow();
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div id="DivContainer" style="padding: 6px;">
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
            <div id="DivJobType" style="padding-bottom: 5px;">
                <telerik:RadComboBox ID="dl_filter" runat="server" AutoPostBack="True" Width="235px">
                    <Items>
                        <telerik:RadComboBoxItem Value="1" Text="Pricing for Job Type"></telerik:RadComboBoxItem>
                        <telerik:RadComboBoxItem Value="2" Text="Full Price List"></telerik:RadComboBoxItem>
                    </Items>
                </telerik:RadComboBox>
            </div>
            <div id="DivGrid">
                <telerik:RadGrid ID="radGridVendorList" runat="server" AllowPaging="False" AllowFilteringByColumn="False" AllowSorting="True" AllowMultiRowSelection="False"
                    AutoGenerateColumns="False" GroupingSettings-GroupByFieldsSeparator="  "
                    Width="100%">
                    <PagerStyle Mode="NumericPages" Visible="False" AlwaysVisible="true" Position="Bottom"
                        Height="0px"></PagerStyle>
                    <StatusBarSettings LoadingText="Loading Data" ReadyText="Data Loaded." />
                    <SortingSettings SortedAscToolTip="Sorted ascending" SortedDescToolTip="Sorted descending" />
                    <AlternatingItemStyle VerticalAlign="Top" />
                    <FilterItemStyle HorizontalAlign="Left" Wrap="False" />
                    <ClientSettings EnablePostBackOnRowClick="False">
                        <Scrolling AllowScroll="true" EnableVirtualScrollPaging="False" ScrollHeight="385"
                            SaveScrollPosition="True" />
                        <Selecting AllowRowSelect="True" EnableDragToSelectRows="False"  />
                    </ClientSettings>
                    <GroupingSettings GroupByFieldsSeparator=" " />
                    <MasterTableView HorizontalAlign="Left" DataKeyNames="VN_PRICING_ID,VN_CODE,JT_CODE,VN_PRICING_RATE">
                        <Columns>
                            <telerik:GridTemplateColumn AllowFiltering="false">
                                <HeaderStyle CssClass="radgrid-icon-column" />
                                <ItemStyle CssClass="radgrid-icon-column" />
                                <FooterStyle CssClass="radgrid-icon-column" />
                                <ItemTemplate>
                                    <div class="icon-background background-color-sidebar">
                                        <asp:ImageButton ID="ibtn_select" runat="server" AlternateText="Select Vendor Item."
                                            CausesValidation="false" CommandName="Select" SkinID="ImageButtonNewWhite" />
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn HeaderText="Job Type" DataField="JT_DESC">
                                <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                                <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                                <FooterStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Description/Quantity" DataField="VN_PRICING_DESC" FilterControlAltText="Filter column"
                                FilterControlWidth="91%" ShowFilterIcon="True" FilterDelay="1250" CurrentFilterFunction="Contains"
                                AutoPostBackOnFilter="false">
                                <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                                <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                                <FooterStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Unit-Rate" DataField="VN_PRICING_RATE" AllowFiltering="false">
                                <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Right" Width="100px" />
                                <ItemStyle VerticalAlign="Middle" HorizontalAlign="Right" Width="100px" />
                                <FooterStyle VerticalAlign="Middle" HorizontalAlign="Right" Width="100px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Vendor" DataField="VN_NAME">
                                <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                                <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                                <FooterStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Note" DataField="VN_PRICING_NOTES">
                                <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                                <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                                <FooterStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
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
                </telerik:RadGrid>
            </div>
            <div id="DivTextboxes" style="text-align: right; margin-right: -2px; margin-top: 10px;">
                <div class="form-layout">
                    <ul>
                        <li>Quantity:</li>
                        <li><telerik:RadNumericTextBox ID="RadNumericTextBoxQuantity" runat="server" Width="100px" MinValue="0" MaxLength="15" AutoPostBack="true" FocusedStyle-HorizontalAlign="Right" EnabledStyle-HorizontalAlign="Right" HoveredStyle-HorizontalAlign="Right" DisabledStyle-HorizontalAlign="Right" EmptyMessageStyle-HorizontalAlign="Right" InvalidStyle-HorizontalAlign="Right" NegativeStyle-HorizontalAlign="Right" ReadOnlyStyle-HorizontalAlign="Right">
                            </telerik:RadNumericTextBox></li>
                    </ul>
                    <ul>
                        <li>Use Rate:</li>
                        <li><telerik:RadNumericTextBox ID="RadNumericTextBoxRate" runat="server" MaxLength="15" Width="100" ReadOnly="true" Enabled="false">
                                <EnabledStyle HorizontalAlign="right"   />
                                <NumberFormat DecimalDigits="3" />
                            </telerik:RadNumericTextBox></li>
                    </ul>
                    <ul>
                        <li>Total Amount:</li>
                        <li><telerik:RadNumericTextBox ID="RadNumericTextBoxAmount" runat="server" MaxLength="15" Width="100" ReadOnly="true" Enabled="false">
                                <EnabledStyle HorizontalAlign="right"   />
                                <NumberFormat DecimalDigits="2" />
                            </telerik:RadNumericTextBox></li>
                    </ul>
                </div>
            </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        <div id="DivButtons" style="text-align: center">
            <asp:Button ID="ButtonSelect" runat="server" Text="Select" />
            <asp:Button ID="ButtonClose" runat="server" Text="Cancel" />
        </div>
    </div>
</asp:Content>
