<%@ Page Title="Find Purchase Order" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="PurchaseOrder_Search.aspx.vb" Inherits="Webvantage.PurchaseOrder_Search1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
        <script type="text/javascript">

            function populatePOIssuedate() {
                var mydate = new Date()
                var year = mydate.getYear()
                if (year < 1000)
                    year += 1900
                var day = mydate.getDay()
                var month = mydate.getMonth() + 1
                if (month < 10)
                    month = month
                var daym = mydate.getDate()
                if (daym < 10)
                    daym = "0" + daym

                document.forms[0].ctl00_ContentPlaceHolderMain_txtIssueFromDate.value = month + "/" + daym + "/" + year
            }

            function populatePODuedate() {
                var mydate = new Date()
                var year = mydate.getYear()
                if (year < 1000)
                    year += 1900
                var day = mydate.getDay()
                var month = mydate.getMonth() + 1
                if (month < 10)
                    month = month
                var daym = mydate.getDate()
                if (daym < 10)
                    daym = "0" + daym

                document.forms[0].ctl00_ContentPlaceHolderMain_txtDueDate.value = month + "/" + daym + "/" + year
            }

            function populatePOIssueEnddate() {
                var mydate = new Date()
                var year = mydate.getYear()
                if (year < 1000)
                    year += 1900
                var day = mydate.getDay()
                var month = mydate.getMonth() + 1
                if (month < 10)
                    month = month
                var daym = mydate.getDate()
                if (daym < 10)
                    daym = "0" + daym

                document.forms[0].ctl00_ContentPlaceHolderMain_txtIssueToDate.value = month + "/" + daym + "/" + year
            }

        </script>
    </telerik:RadScriptBlock>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div >
        <telerik:RadToolBar ID="RadToolbarSearch" runat="server" AutoPostBack="true" Width="100%"
            TabIndex="-1">
            <Items>
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonFind" ToolTip="Search" Value="Search" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonNew" ToolTip="New" Value="New" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonClear" ToolTip="Clear" Value="Clear" />
                <telerik:RadToolBarButton IsSeparator="true" />
            </Items>
        </telerik:RadToolBar>
    </div>
    <div >
    </div>
    <div class="wrapper">
        <div id="DivFilter" runat="server" class="two-col-leftcolumn">
            <div class="" style="">
                <div class="filter-card">
                    <div class="card-content" style="margin-bottom: 20px;">
                        <asp:Panel ID="PnlSearch" runat="server" DefaultButton="BtnSearch">
                            <div>
                                <div>
                                    <asp:Panel ID="pnldlOptions" runat="server">
                                        <div>
                                            <telerik:RadComboBox ID="dl_options" runat="server" Width="200">
                                                <Items>
                                                    <telerik:RadComboBoxItem Value="1" Text="Any Matching Criteria"></telerik:RadComboBoxItem>
                                                    <telerik:RadComboBoxItem Value="2" Text="All Criteria Must Match"></telerik:RadComboBoxItem>
                                                </Items>
                                            </telerik:RadComboBox>
                                        </div>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlPONumber" runat="server">
                                        <div>
                                            <asp:HyperLink ID="hlPONumber" runat="server" href=""><span>PO Number:</span></asp:HyperLink>
                                        </div>
                                        <div>
                                            <asp:TextBox ID="txtPONumber" runat="server" SkinID="TextBoxCodeLarge"></asp:TextBox>
                                            <asp:HiddenField ID="hfPONumber" runat="server" />
                                        </div>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlDescription" runat="server">
                                        <div>
                                            <asp:Label ID="lblDescription" runat="server"><span>Description:</span></asp:Label>
                                        </div>
                                        <div>
                                            <asp:TextBox ID="txtDescription" runat="server" SkinID="TextBoxCodeLarge" MaxLength="40"></asp:TextBox>
                                        </div>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlJob" runat="server">
                                        <div>
                                            <asp:HyperLink ID="hlJob" runat="server" href=""><span>Job:</span></asp:HyperLink>
                                        </div>
                                        <div>
                                            <asp:TextBox ID="txtJob" runat="server" SkinID="TextBoxCodeLarge" MaxLength="6"></asp:TextBox>
                                        </div>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlComponent" runat="server">
                                        <div>
                                            <asp:HyperLink ID="hlComponent" runat="server" Text="Component:" href=""><span>Component:</span></asp:HyperLink>
                                        </div>
                                        <div>
                                            <asp:TextBox ID="txtComponent" runat="server" SkinID="TextBoxCodeLarge" MaxLength="3"></asp:TextBox>
                                        </div>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlClient" runat="server">
                                        <div>
                                            <asp:HyperLink ID="hlClient" runat="server" href=""><span>Client:</span></asp:HyperLink>
                                        </div>
                                        <div>
                                            <asp:TextBox ID="txtClient" runat="server" SkinID="TextBoxCodeLarge" MaxLength="6"></asp:TextBox>
                                        </div>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlDivision" runat="server">
                                        <div>
                                            <asp:HyperLink ID="hlDivision" runat="server" href=""><span>Division:</span></asp:HyperLink>
                                        </div>
                                        <div>
                                            <asp:TextBox ID="txtDivision" runat="server" SkinID="TextBoxCodeLarge" MaxLength="6"></asp:TextBox>
                                        </div>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlProduct" runat="server">
                                        <div>
                                            <asp:HyperLink ID="hlProduct" runat="server" href=""><span>Product:</span></asp:HyperLink>
                                        </div>
                                        <div>
                                            <asp:TextBox ID="txtProduct" runat="server" SkinID="TextBoxCodeLarge" MaxLength="6"></asp:TextBox>
                                        </div>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlIssueFromDate" runat="server">
                                        <div>
                                            <span>From Date:</span>
                                        </div>
                                        <div>
                                            <telerik:RadDatePicker ID="RadDatePickerIssueFromDate" runat="server" SkinID="RadDatePickerStandard">
                                                <DateInput DateFormat="d" EmptyMessage="">
                                                    <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                                                </DateInput>
                                                <Calendar ID="CalendarIssueFromDate" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                                                    <SpecialDays>
                                                        <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="radcalendar-today">
                                                        </telerik:RadCalendarDay>
                                                    </SpecialDays>
                                                </Calendar>
                                            </telerik:RadDatePicker>
                                        </div>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlIssueToDate" runat="server">
                                        <div>
                                            <span>To Date:</span>
                                        </div>
                                        <div>
                                            <telerik:RadDatePicker ID="RadDatePickerIssueToDate" runat="server" SkinID="RadDatePickerStandard">
                                                <DateInput DateFormat="d" EmptyMessage="">
                                                    <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                                                </DateInput>
                                                <Calendar ID="CalendarIssueToDate" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                                                    <SpecialDays>
                                                        <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="radcalendar-today">
                                                        </telerik:RadCalendarDay>
                                                    </SpecialDays>
                                                </Calendar>
                                            </telerik:RadDatePicker>
                                        </div>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlDueDate" runat="server">
                                        <div>
                                            <span>Due Date:</span>
                                        </div>
                                        <div>
                                            <telerik:RadDatePicker ID="RadDatePickerDueDate" runat="server" SkinID="RadDatePickerStandard">
                                                <DateInput DateFormat="d" EmptyMessage="">
                                                    <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                                                </DateInput>
                                                <Calendar ID="CalendarDueDate" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                                                </Calendar>
                                            </telerik:RadDatePicker>
                                        </div>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlVendor" runat="server">
                                        <div>
                                            <asp:HyperLink ID="hlVendor" runat="server" href=""><span>Vendor:</span></asp:HyperLink>
                                        </div>
                                        <div>
                                            <asp:TextBox ID="txtVendor" runat="server" SkinID="TextBoxCodeLarge" MaxLength="6"></asp:TextBox>
                                        </div>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlIssuedBy" runat="server">
                                        <div>
                                            <asp:HyperLink ID="hlIssuedBy" runat="server" href=""><span>Issued By:</span></asp:HyperLink>
                                        </div>
                                        <div>
                                            <asp:TextBox ID="txtIssuedBy" runat="server" SkinID="TextBoxCodeLarge" MaxLength="6"></asp:TextBox>
                                        </div>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlApprover" runat="server">
                                        <div>
                                            <asp:HyperLink ID="hlApprover" runat="server" href=""><span>Approver:</span></asp:HyperLink>
                                        </div>
                                        <div>
                                            <asp:TextBox ID="txtApprover" runat="server" SkinID="TextBoxCodeLarge" MaxLength="6"></asp:TextBox>
                                        </div>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlPOStatus" runat="server">
                                        <div>
                                            <asp:Label ID="lblPOStatus" runat="server"><span>PO Status:</span></asp:Label>
                                        </div>
                                        <div>
                                            <telerik:RadComboBox ID="ddPOStatus" runat="server" SkinID="TextBoxCodeLarge">
                                                <Items>
                                                    <telerik:RadComboBoxItem Text="" Value="0"></telerik:RadComboBoxItem>
                                                    <telerik:RadComboBoxItem Value="2" Text="Approved"></telerik:RadComboBoxItem>
                                                    <telerik:RadComboBoxItem Value="3" Text="Denied"></telerik:RadComboBoxItem>
                                                    <telerik:RadComboBoxItem Value="1" Text="Pending"></telerik:RadComboBoxItem>
                                                </Items>
                                            </telerik:RadComboBox>
                                        </div>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlPrinted" runat="server">
                                        <div>
                                            <asp:Label ID="lblPrinted" runat="server"><span>Printed:</span></asp:Label>
                                        </div>
                                        <div>
                                            <asp:CheckBox ID="cbPrinted" runat="server" TextAlign="Left" />
                                        </div>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlVoided" runat="server">
                                        <div>
                                            <asp:Label ID="lblOmitVoid" runat="server"><span>Omit Voided PO's:</span></asp:Label>
                                        </div>
                                        <div>
                                            <asp:CheckBox ID="cbOmitVoid" runat="server" TextAlign="Left" />
                                        </div>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlClosed" runat="server">
                                        <div>
                                            <asp:Label ID="lblOmitClosed" runat="server"><span>Omit Closed PO's:</span></asp:Label>
                                        </div>
                                        <div>
                                            <asp:CheckBox ID="cbOmitClosed" runat="server" TextAlign="Left" Checked="true" />
                                        </div>
                                    </asp:Panel>
                                </div>
                            </div>
                            <div style="display: none;">
                                <asp:Button ID="BtnSearch" runat="server" Text="Search" Visible="true" TabIndex="-1" />
                            </div>
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>
        <div id="DivGrid" runat="server" class="two-col-rightcolumn">
            <telerik:RadGrid ID="RadGridPurchaseOrderSearch" runat="server" AllowPaging="True" AllowSorting="True"
                AutoGenerateColumns="False" GridLines="None" GroupingSettings-GroupByFieldsSeparator="  "
                PageSize="15" EnableEmbeddedSkins="True">
                <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom"></PagerStyle>
                <SortingSettings SortedAscToolTip="Sorted ascending" SortedDescToolTip="Sorted descending" />
                <ClientSettings AllowColumnsReorder="False">
                    <Scrolling AllowScroll="True" ScrollHeight="100%" />
                </ClientSettings>
                <GroupingSettings GroupByFieldsSeparator=" " />
                <MasterTableView HorizontalAlign="Left">
                    <Columns>
                        <telerik:GridTemplateColumn>
                            <HeaderStyle CssClass="radgrid-icon-column" />
                            <ItemStyle CssClass="radgrid-icon-column" />
                            <FooterStyle CssClass="radgrid-icon-column" />
                            <ItemTemplate>
                                <div class="icon-background background-color-sidebar">
                                    <asp:ImageButton ID="ibtn_po" runat="server" AlternateText="Purchase Order" CausesValidation="false"
                                        CommandName="Select" SkinID="ImageButtonViewWhite" />
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn>
                            <HeaderStyle CssClass="radgrid-icon-column" />
                            <ItemStyle CssClass="radgrid-icon-column" />
                            <FooterStyle CssClass="radgrid-icon-column" />
                            <ItemTemplate>
                                <div id="DivPrint" runat="server" class="icon-background background-color-sidebar">
                                    <asp:ImageButton ID="ImgBtnPrint" runat="server" CommandName="Print" SkinID="ImageButtonPrintWhite" />
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="PO Number">
                            <ItemTemplate>
                                <asp:Label ID="lblPONumber" runat="server" Text='<%#Eval("PO_PAD").ToString%>'></asp:Label>
                                <asp:HiddenField ID="hfPONumber" runat="server" Value='<%#Eval("PO_NUMBER").ToString%>' />
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="PO Date">
                            <ItemTemplate>
                                <asp:Label ID="lblPODate" runat="server" Text='<%#Eval("PO_DATE").ToString%>'></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Vendor Code">
                            <ItemTemplate>
                                <asp:Label ID="lblVNCode" runat="server" Text='<%#Eval("VN_CODE").ToString%>'></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Vendor Name">
                            <ItemTemplate>
                                <asp:Label ID="lblVNName" runat="server" Text='<%#Eval("VN_NAME").ToString%>'></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Description">
                            <ItemTemplate>
                                <asp:Label ID="lblPODescription" runat="server" Text='<%#Eval("PO_DESCRIPTION").ToString%>'></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Due Date">
                            <ItemTemplate>
                                <asp:Label ID="lblPODueDate" runat="server" Text='<%#Eval("PO_DUE_DATE").ToString%>'></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Issued By">
                            <ItemTemplate>
                                <asp:Label ID="lblPOIssuedBy" runat="server" Text='<%#Eval("ISSUED_BY").ToString%>'></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Match">
                            <ItemTemplate>
                                <asp:Label ID="lblSearchCode" runat="server" Text='<%#Eval("SEARCH_CODE").ToString%>'></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Status">
                            <ItemTemplate>
                                <asp:Label ID="lblPOStatus" runat="server" Text='<%#Eval("PO_APPROVAL_FLAG").ToString%>'></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="left"
                            UniqueName="TemplateColumn1" HeaderText="Void">
                            <HeaderStyle CssClass="radgrid-icon-column" />
                            <ItemStyle CssClass="radgrid-icon-column" />
                            <FooterStyle CssClass="radgrid-icon-column" />
                            <ItemTemplate>
                                <div class="icon-background standard-red" runat="server" id="DivFlagColor">
                                    <asp:Image ID="ImageFlag" runat="server" CssClass="icon-image" ImageUrl="~/Images/Icons/White/256/signal_flag.png" ToolTip="Void" />
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                    </Columns>
                    <FilterItemStyle VerticalAlign="Top" Wrap="False" />
                    <ExpandCollapseColumn Visible="False">
                        <HeaderStyle Width="19px" />
                    </ExpandCollapseColumn>
                    <RowIndicatorColumn Visible="False">
                        <HeaderStyle Width="20px" />
                    </RowIndicatorColumn>
                </MasterTableView>
            </telerik:RadGrid>
        </div>
    </div>
</asp:Content>
