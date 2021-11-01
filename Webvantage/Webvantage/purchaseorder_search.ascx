<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="purchaseorder_search.ascx.vb"
    Inherits="Webvantage.purchaseorder_search" %>
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
<div class="" style="">
    <div class="filter-card">
        <div class="card-content" style="margin-bottom: 20px;">
            <div>
                <asp:Panel ID="pnldlOptions" runat="server">
                    <div>
                        <div>
                            <telerik:RadComboBox ID="dl_options" runat="server" Width="200">
                                <Items>
                                    <telerik:RadComboBoxItem Value="1" Text="Any Matching Criteria"></telerik:RadComboBoxItem>
                                    <telerik:RadComboBoxItem Value="2" Text="All Criteria Must Match"></telerik:RadComboBoxItem>
                                </Items>
                            </telerik:RadComboBox>
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlPONumber" runat="server">
                    <div>
                        <div>
                            <asp:HyperLink ID="hlPONumber" runat="server" href=""><span>PO Number:</span></asp:HyperLink>
                        </div>
                        <div>
                            <asp:TextBox ID="txtPONumber" runat="server" Width="145px"></asp:TextBox>
                            <asp:HiddenField ID="hfPONumber" runat="server" />
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlDescription" runat="server">
                    <div>
                        <div>
                            <asp:Label ID="lblDescription" runat="server"><span>Description:</span></asp:Label>
                        </div>
                        <div>
                            <asp:TextBox ID="txtDescription" runat="server" Width="145px" MaxLength="40"></asp:TextBox>
                        </div>

                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlJob" runat="server">
                    <div>
                        <div>
                            <asp:HyperLink ID="hlJob" runat="server" href=""><span>Job:</span></asp:HyperLink>
                        </div>
                        <div>
                            <asp:TextBox ID="txtJob" runat="server" Width="145px" MaxLength="6"></asp:TextBox>
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlComponent" runat="server">
                    <div>
                        <div>
                            <asp:HyperLink ID="hlComponent" runat="server" Text="Component:" href=""><span>Component:</span></asp:HyperLink>
                        </div>
                        <div>
                            <asp:TextBox ID="txtComponent" runat="server" Width="145px" MaxLength="3"></asp:TextBox>
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlClient" runat="server">
                    <div>
                        <div>
                            <asp:HyperLink ID="hlClient" runat="server" href=""><span>Client:</span></asp:HyperLink>
                        </div>
                        <div>
                            <asp:TextBox ID="txtClient" runat="server" Width="145px" MaxLength="6"></asp:TextBox>
                        </div>

                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlDivision" runat="server">
                    <div>
                        <div>
                            <asp:HyperLink ID="hlDivision" runat="server" href=""><span>Division:</span></asp:HyperLink>
                        </div>
                        <div>
                            <asp:TextBox ID="txtDivision" runat="server" Width="145px" MaxLength="6"></asp:TextBox>
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlProduct" runat="server">
                    <div>
                        <div>
                            <asp:HyperLink ID="hlProduct" runat="server" href=""><span>Product:</span></asp:HyperLink>
                        </div>
                        <div>
                            <asp:TextBox ID="txtProduct" runat="server" Width="145px" MaxLength="6"></asp:TextBox>
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlIssueFromDate" runat="server">
                    <div>
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

                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlIssueToDate" runat="server">
                    <div>
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
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlDueDate" runat="server">
                    <div>
                        <div>
                            <span>Due Date:</span>
                        </div>
                        <div>
                            <telerik:RadDatePicker ID="RadDatePickerDueDate" runat="server" SkinID="RadDatePickerStandard">
                                <DateInput DateFormat="d" EmptyMessage="">
                                    <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                                </DateInput>
                                <Calendar ID="CalendarDueDate" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                                    <SpecialDays>
                                        <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="radcalendar-today">
                                        </telerik:RadCalendarDay>
                                    </SpecialDays>
                                </Calendar>
                            </telerik:RadDatePicker>
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlVendor" runat="server">
                    <div>
                        <div>
                            <asp:HyperLink ID="hlVendor" runat="server" href=""><span>Vendor:</span></asp:HyperLink>
                        </div>
                        <div>
                            <asp:TextBox ID="txtVendor" runat="server" Width="145px" MaxLength="6"></asp:TextBox>
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlIssuedBy" runat="server">
                    <div>
                        <div>
                            <asp:HyperLink ID="hlIssuedBy" runat="server" href=""><span>Issued By:</span></asp:HyperLink>
                        </div>
                        <div>
                            <asp:TextBox ID="txtIssuedBy" runat="server" Width="145px" MaxLength="6"></asp:TextBox>
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlApprover" runat="server">
                    <div>
                        <div>
                            <asp:HyperLink ID="hlApprover" runat="server" href=""><span>Approver:</span></asp:HyperLink>
                        </div>
                        <div>
                            <asp:TextBox ID="txtApprover" runat="server" Width="145px" MaxLength="6"></asp:TextBox>
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlPOStatus" runat="server">
                    <div>
                        <div>
                            <asp:Label ID="lblPOStatus" runat="server"><span>PO Status:</span></asp:Label>
                        </div>
                        <div>
                            <telerik:RadComboBox ID="ddPOStatus" runat="server" Width="145px">
                                <Items>
                                    <telerik:RadComboBoxItem Text="" Value="0"></telerik:RadComboBoxItem>
                                    <telerik:RadComboBoxItem Value="2" Text="Approved"></telerik:RadComboBoxItem>
                                    <telerik:RadComboBoxItem Value="3" Text="Denied"></telerik:RadComboBoxItem>
                                    <telerik:RadComboBoxItem Value="1" Text="Pending"></telerik:RadComboBoxItem>
                                </Items>
                            </telerik:RadComboBox>
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlPrinted" runat="server">
                    <div>
                        <div style="display:none;">
                            <asp:Label ID="lblPrinted" runat="server"><span>Printed:</span></asp:Label>
                        </div>
                        <div>
                            <asp:CheckBox ID="cbPrinted" runat="server" TextAlign="Right" Text="Printed" />
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlVoided" runat="server">
                    <div>
                        <div style="display:none;">
                            <asp:Label ID="lblOmitVoid" runat="server"><span>Omit Voided PO's:</span></asp:Label>
                        </div>
                        <div>
                            <asp:CheckBox ID="cbOmitVoid" runat="server" TextAlign="Right" Text="Omit Voided PO's" />
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlClosed" runat="server">
                    <div>
                        <div style="display:none;">
                            <asp:Label ID="lblOmitClosed" runat="server"><span>Omit Closed PO's:</span></asp:Label>
                        </div>
                        <div>
                            <asp:CheckBox ID="cbOmitClosed" runat="server" TextAlign="Right" Checked="true" Text="Omit Closed PO's"/>
                        </div>
                    </div>
                </asp:Panel>
            </div>
        </div>
    </div>
</div>
