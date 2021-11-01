<%@ Page Title="Print Timesheet" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="Timesheet_QuickPrintSettings.aspx.vb" Inherits="Webvantage.Timesheet_QuickPrintSettings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div style="padding-left: 2px; padding-right: 2px;">
        <h4>
            Report Type</h4>
        <asp:RadioButton ID="rbSummary" runat="server" Text="Summary" GroupName="Print" AutoPostBack="true" /><br />
        <asp:RadioButton ID="rbDetail" runat="server" Text="Detail with Comments" GroupName="Print"
            AutoPostBack="true" /><br />
        <asp:Panel ID="pnlDates" runat="server">
            <asp:Label ID="lblStartDate" runat="server" Text="Start Date: "></asp:Label>
            <telerik:RadDatePicker ID="RadDatePickerStartDate" runat="server" 
                  SkinID="RadDatePickerStandard">
                <DateInput DateFormat="d" EmptyMessage="Start Date">
                    <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                </DateInput>
                <Calendar ID="CalendarStartDate" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                </Calendar>
            </telerik:RadDatePicker>
            <asp:Label ID="lblEndDate" runat="server" Text="End Date: "></asp:Label>
            <telerik:RadDatePicker ID="RadDatePickerEndDate" runat="server" 
                  SkinID="RadDatePickerStandard">
                <DateInput DateFormat="d" EmptyMessage="End Date">
                    <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                </DateInput>
                <Calendar ID="CalendarEndDate" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                </Calendar>
            </telerik:RadDatePicker>
        </asp:Panel>
        <br />
        <h4>
            Sort By</h4>
    <div style="margin-top:4px">
        <telerik:RadComboBox ID="RadComboBoxSort" runat="server" AutoPostBack="True" Width="225">
            <Items>
            </Items>
        </telerik:RadComboBox></div>
        <h4>
            Signature</h4>
        <asp:CheckBox ID="CheckBoxExcludeEmployeeSignature" runat="server" Text="Exclude Employee Signature"
            AutoPostBack="false" Checked="false" />
        <br />
    </div>
    <div style="text-align:right; margin-top: 20px;">
        <asp:Button ID="butPrint" runat="server" Text="Print&nbsp;" />
    </div>
</asp:Content>
