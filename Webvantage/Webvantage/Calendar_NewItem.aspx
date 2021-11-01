<%@ Page Title="New Item" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="Calendar_NewItem.aspx.vb" Inherits="Webvantage.Calendar_NewItem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
        <script type="text/javascript">
            var formattedDate;
            var olAppointmentItem = 1; //fixed for different properties of outlook object
            //EXPORT to OUTLOOK
            function ExportDataToOutlook(subject, body, date, duration, reminder, allday) {
                //var duration = 120; //number of minutes (duration in Outlook being in minutes)
                //SetTimeForAppointment();//time of appoinment was fixed 
                try {
                    var objOutlook = new ActiveXObject("Outlook.Application");
                }
                catch (e) {
                    ShowMessage("Outlook needs to be installed on the machine for data to export.");
                    return false;
                }

                var objAppointment = objOutlook.CreateItem(olAppointmentItem);

                objAppointment.Subject = subject;
                objAppointment.AllDayEvent = allday;
                objAppointment.Body = body;
                objAppointment.Start = date;
                objAppointment.Duration = duration;
                objAppointment.ReminderMinutesBeforeStart = 15;
                objAppointment.ReminderSet = reminder;
                //objAppointment.Location = '';

                //var objRecurrence = objAppointment.GetRecurrencePattern
                //objRecurrence.RecurrenceType = olRecursDaily
                //objRecurrence.PatternStartDate = #2/15/2008#
                //objRecurrence.PatternEndDate = #3/3/2008#

                objAppointment.Save();


                //alert("An appointment was exported successfully to your Outlook calendar in todays date.");
                return true;
            }

            function SetTimeForAppointment() {
                var currentDate = new Date();
                var month = currentDate.getMonth();
                var day = currentDate.getDate();
                var year = currentDate.getFullYear();
                formattedDate = (month + 1) + "/" + day + "/" + year + " 08:00AM";
            }
        </script>
    </telerik:RadScriptBlock>
    <table id="Table2" align="center" border="0" cellpadding="4" cellspacing="0" width="100%">
        <tr>
            <td rowspan="1" valign="top">
                <table id="Table1" cellpadding="2" cellspacing="0" width="100%">
                    <tr>
                        <td nowrap="nowrap" style="width: 457px">
                            <span class="required">*</span><asp:Label   ID="lblType" runat="server">Type:</asp:Label>
                            <asp:RadioButton ID="chkHoliday" runat="server" Text='Holiday' AutoPostBack="true"
                                GroupName="Task" />
                            <asp:RadioButton ID="chkAppointment" runat="server" Text='Appointment' AutoPostBack="true"
                                GroupName="task" />
                        </td>
                    </tr>
                    <tr>
                        <td nowrap="nowrap" style="width: 457px">
                            <asp:Label   ID="Label5" runat="server">Subject:</asp:Label>
                            <asp:TextBox ID="txtSubject" runat="server" Width="385px" SkinID="TextBoxStandard"></asp:TextBox>
                        </td>
                        <td nowrap="nowrap">
                            <span class="required">*</span><asp:Label   ID="Label2" runat="server">Category:<strong/></asp:Label>
                            <telerik:RadComboBox ID="ddlCategory" runat="server" SkinID="RadComboBoxStandard">
                            </telerik:RadComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td nowrap="nowrap" style="width: 457px">
                            <asp:Label   ID="Label6" runat="server">Employee:<strong/></asp:Label>
                            <telerik:RadComboBox ID="ddlEmps" runat="server" SkinID="RadComboBoxStandard">
                            </telerik:RadComboBox>
                        </td>
                    </tr>
                </table>
                <table id="Table3" cellpadding="2" cellspacing="0" width="100%">
                    <tr>
                        <td nowrap="nowrap" style="width: 64px">
                            <asp:Label   ID="Label7" runat="server">Start Time:<strong/></asp:Label>
                        </td>
                        <td style="width: 115px">
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
                        </td>
                        <td style="width: 121px">
                            <telerik:RadTimePicker ID="radTimePickerStart" runat="server" AutoPostBack="True"
                                TimeView-HeaderText="Time Selector">
                                <TimeView ID="TimeView1" runat="server" StartTime="05:00:00" EndTime="22:31:00" Interval="00:30:00"
                                    Columns="6" HeaderText="Time Selector">
                                    <HeaderTemplate>
                                        Time Selector</HeaderTemplate>
                                </TimeView>
                            </telerik:RadTimePicker>
                        </td>
                        <td nowrap="nowrap">
                            <asp:CheckBox ID="chkAllDay" runat="server" Text='All Day Event' AutoPostBack="true" />
                        </td>
                    </tr>
                    <tr>
                        <td nowrap="nowrap" style="width: 64px">
                            <asp:Label   ID="Label1" runat="server">End Time:<strong/></asp:Label>
                        </td>
                        <td style="width: 115px">
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
                        <td style="width: 121px">
                            <telerik:RadTimePicker ID="radTimePickerEnd" runat="server" TimeView-HeaderText="Time Selector">
                                <TimeView ID="TimeView2" runat="server" StartTime="05:00:00" EndTime="22:31:00" Interval="00:30:00"
                                    Columns="6" HeaderText="Time Selector">
                                    <HeaderTemplate>
                                        Time Selector</HeaderTemplate>
                                </TimeView>
                            </telerik:RadTimePicker>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="3" valign="top">
                <asp:Button ID="butSave" runat="server" Text="Save" />&nbsp;&nbsp;
                <asp:Button ID="butSaveExport" runat="server" Text="Save/Export" Visible="false" />&nbsp;&nbsp;
                <asp:Button ID="butUpdate" runat="server" Text="Update" />&nbsp;&nbsp;
                <asp:Button ID="butDelete" runat="server" Text="Delete" />
                <asp:Button ID="btnExport" runat="server" Text="Export" Visible="false" />
                <br />
                <br />
                <asp:Label   ID="lblError" runat="server" CssClass="warning"></asp:Label>
                <asp:Label   ID="lblConfirm" runat="server" CssClass="warning" Visible="false"></asp:Label>
                <input type="hidden" id="response" name="response" />
            </td>
        </tr>
    </table>
</asp:Content>
