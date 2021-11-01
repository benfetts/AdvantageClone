<%@ Page Title="Open Jobs Settings" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="OpenJobs_Settings.aspx.vb" Inherits="Webvantage.OpenJobs_Settings" %>

<%@ Register Src="ReportTypeUC.ascx" TagName="reporttype" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <script type="text/javascript">
        function checkIndex(id) {
            //var objList=document.getElementById("_ctl0_ContentPlaceHolderMain_ddClientList");
            var objList = id;
            //alert(objList);
            if (objList.options[0].selected) {
                for (i = 1; i < objList.length; i++) {
                    objList.options[i].selected = false;
                    // radalert(objList.options[i].value);
                }

            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div class="telerik-aqua-body" style="margin-top: 5px!important;">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td align="center" colspan="2" class="sub-header sub-header-color">
                    Report Selection
                </td>
            </tr>
            <tr>
                <td width="150">
                    &nbsp;
                </td>
                <td width="500">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <telerik:RadListBox ID="lbReports" runat="server" Rows="3" SelectionMode="single"
                        Width="445px">
                        <Items>
                            <telerik:RadListBoxItem Selected="True" Value="OpenJobs" Text="Open Jobs"></telerik:RadListBoxItem>
                            <telerik:RadListBoxItem Value="OpenJobsSC" Text="Open Jobs with Sales Class"></telerik:RadListBoxItem>
                            <telerik:RadListBoxItem Value="OpenJobsFSN" Text="Open Jobs Flagged as Schedule Needed">
                            </telerik:RadListBoxItem>
                        </Items>
                    </telerik:RadListBox>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:CheckBox ID="cbCompSchedule" runat="server" Text="Include Jobs with Completed Schedules"
                        TabIndex="1" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
        <asp:Panel ID="PanelOffice" runat="server">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td align="center" colspan="2" class="sub-header sub-header-color">
                    Office Listing
                </td>
            </tr>
            <tr>
                <td width="150">
                    &nbsp;
                </td>
                <td width="500">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <telerik:RadListBox ID="lbOffice" runat="server" SelectionMode="Multiple" TabIndex="2"
                        Width="445px" Height="100px">
                    </telerik:RadListBox>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
        </asp:Panel>   
        <asp:Panel ID="PanelClient" runat="server">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td align="center" colspan="2" class="sub-header sub-header-color">
                    Client Listing
                </td>
            </tr>
            <tr>
                <td width="150">
                    &nbsp;
                </td>
                <td width="500">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <telerik:RadListBox ID="ddClientList" runat="server" SelectionMode="Multiple" TabIndex="3"
                        Width="445px" Height="200px">
                    </telerik:RadListBox>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
        </asp:Panel>   
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td align="center" colspan="2" class="sub-header sub-header-color">
                    Job/Component Opened Date
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <div align="center">
                        &nbsp;<asp:Label   ID="LblMSG" runat="server" Text="" CssClass="CssRequired"></asp:Label>&nbsp;</div>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2" width="500">
                    <span>Start Date:</span>&nbsp;
                    <telerik:RadDatePicker ID="RadDatePickerStartDate" runat="server" 
                            SkinID="RadDatePickerStandard">
                        <DateInput DateFormat="d" EmptyMessage="Start Date">
                            <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                        </DateInput>
                        <Calendar ID="CalendarStartDate" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                            <SpecialDays>
                                <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="radcalendar-today">
                                </telerik:RadCalendarDay>
                            </SpecialDays>
                        </Calendar>
                    </telerik:RadDatePicker>
                    &nbsp;&nbsp; <span>End Date:</span>&nbsp;
                    <telerik:RadDatePicker ID="RadDatePickerEndDate" runat="server" 
                            SkinID="RadDatePickerStandard">
                        <DateInput DateFormat="d" EmptyMessage="End Date">
                            <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                        </DateInput>
                        <Calendar ID="CalendarEndDate" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                            <SpecialDays>
                                <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="radcalendar-today">
                                </telerik:RadCalendarDay>
                            </SpecialDays>
                        </Calendar>
                    </telerik:RadDatePicker>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td align="center" colspan="2" class="sub-header sub-header-color">
                    Report Format
                </td>
            </tr>
            <tr>
                <td width="150">
                    &nbsp;
                </td>
                <td width="500">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <uc1:reporttype ID="reporttype" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    <br />
    <table width="650" border="0" cellspacing="0" cellpadding="0" align="center">
        <tr>
            <td align="center">
                <asp:Button ID="butView" runat="server" Text="View" TabIndex="6" />
            </td>
        </tr>    
    </table>
    <br />
    </div>

</asp:Content>
