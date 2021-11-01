<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="TrafficSchedule_TaskDetail_UC.ascx.vb"
    Inherits="Webvantage.TrafficSchedule_TaskDetail_UC" %>
<script type="text/javascript">
    function BlockEntry(evt) {
        var charCode = (evt.which) ? evt.which : event.keyCode
        if (charCode > 0)
            return false;

        return true;
    }
</script>
<table cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td>
            <table border="0" cellpadding="0" cellspacing="2" width="810">
                <tr>
                    <td align="right" valign="middle" width="28%">
                        <span>Phase: </span>
                    </td>
                    <td width="2%">
                        &nbsp;
                    </td>
                    <td width="70%">
                        <telerik:RadComboBox ID="DropPhase" runat="server" Width="310">
                        </telerik:RadComboBox>
                        <asp:TextBox runat="server" ID="txtPhase" Visible="false" ReadOnly="true"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="middle" width="28%">
                        <asp:HyperLink ID="hlTaskCode" runat="server" href="">Task:</asp:HyperLink>
                        <span runat="server" id="aTask" visible="false">Task:</span>
                    </td>
                    <td width="2%">
                        &nbsp;
                    </td>
                    <td width="70%">
                        <asp:TextBox ID="TxtTaskCode" runat="server" SkinID="TextBoxCodeSmall" MaxLength="10" AutoPostBack="True"></asp:TextBox>&nbsp;
                        <asp:TextBox ID="TxtTaskDescription" runat="server" Text="" Width="225px" TabIndex="-1"
                            MaxLength="40"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="middle" width="28%">
                        <span>Task Status:</span>
                    </td>
                    <td width="2%">
                        &nbsp;
                    </td>
                    <td width="70%">
                        <telerik:RadComboBox ID="DropTaskStatus" runat="server">
                            <Items>
                                <telerik:RadComboBoxItem Value="P" Text="Projected"></telerik:RadComboBoxItem>
                                <telerik:RadComboBoxItem Value="A" Text="Active"></telerik:RadComboBoxItem>
                                <telerik:RadComboBoxItem Value="H" Text="High Priority"></telerik:RadComboBoxItem>
                                <telerik:RadComboBoxItem Value="L" Text="Low Priority"></telerik:RadComboBoxItem>
                            </Items>
                        </telerik:RadComboBox>
                        <asp:TextBox runat="server" ID="txtTaskStatus" Visible="false" ReadOnly="true"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="middle" width="28%">
                        <span>Start Date:</span>
                    </td>
                    <td width="2%">
                        &nbsp;
                    </td>
                    <td width="70%">
                        <telerik:RadDatePicker ID="RadDatePickerStartDate" runat="server" 
                              SkinID="RadDatePickerStandard">
                            <DateInput DateFormat="d" EmptyMessage="Start Date">
                                <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                            </DateInput>
                            <Calendar ID="CalendarStartDate" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                            </Calendar>
                        </telerik:RadDatePicker>
                        <%--&nbsp;
                        <telerik:RadTimePicker ID="radTimePickerStart" runat="server" AutoPostBack="True" SkinID="RadDatePickerStandard"
                                TimeView-HeaderText="Time Selector">
                            <TimeView ID="TimeView1" runat="server" StartTime="05:00:00" EndTime="22:31:00" Interval="00:30:00"
                                    Columns="6" HeaderText="Time Selector">
                                <HeaderTemplate>
                                        Time Selector</HeaderTemplate>
                            </TimeView>
                        </telerik:RadTimePicker>--%>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="middle" width="28%">
                        <span>Due Date:</span>
                    </td>
                    <td width="2%">
                        &nbsp;
                    </td>
                    <td width="70%">
                        <telerik:RadDatePicker ID="RadDatePickerDueDate" runat="server" 
                              SkinID="RadDatePickerStandard">
                            <DateInput DateFormat="d" EmptyMessage="">
                                <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                            </DateInput>
                            <Calendar ID="Calendar1" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                            </Calendar>
                        </telerik:RadDatePicker>
                        <%--&nbsp;
                        <telerik:RadTimePicker ID="radTimePickerEnd" runat="server" TimeView-HeaderText="Time Selector" SkinID="RadDatePickerStandard">
                            <TimeView ID="TimeView2" runat="server" StartTime="05:00:00" EndTime="22:31:00" Interval="00:30:00"
                                    Columns="6" HeaderText="Time Selector">
                                <HeaderTemplate>
                                        Time Selector</HeaderTemplate>
                            </TimeView>
                            </telerik:RadTimePicker>--%>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="middle" width="28%">
                        <span>Temp Complete (All):</span>
                    </td>
                    <td width="2%">
                        &nbsp;
                    </td>
                    <td width="70%">
                        <asp:TextBox ID="txtTempComplete" runat="server" Width="67" MaxLength="10" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="middle" width="28%">
                        <span>Time Due:</span>
                    </td>
                    <td width="2%">
                        &nbsp;
                    </td>
                    <td width="70%">
                        <asp:TextBox ID="TxtTimeDue" runat="server" Width="67" MaxLength="10"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="middle" width="28%">
                        <span>Completed Date:</span>
                    </td>
                    <td width="2%">
                        &nbsp;
                    </td>
                    <td width="70%">
                        <telerik:RadDatePicker ID="RadDatePickerDateCompleted" runat="server" 
                              SkinID="RadDatePickerStandard">
                            <DateInput DateFormat="d" EmptyMessage="">
                                <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                            </DateInput>
                            <Calendar ID="Calendar2" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                                <SpecialDays>
                                    <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="radcalendar-today">
                                    </telerik:RadCalendarDay>
                                </SpecialDays>
                            </Calendar>
                        </telerik:RadDatePicker>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="middle" width="28%">
                        <span>Task Comments:</span>
                    </td>
                    <td width="2%">
                        &nbsp;
                    </td>
                    <td width="70%">
                        <asp:TextBox ID="TxtTaskComments" runat="server" Height="64px" TextMode="MultiLine"
                            Width="100%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="middle" width="28%">
                        <span>Due Date Comments:</span>
                    </td>
                    <td width="2%">
                        &nbsp;
                    </td>
                    <td width="70%">
                        <asp:TextBox ID="TxtDueDateComments" runat="server" Height="64px" TextMode="MultiLine"
                            Width="100%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="middle" width="28%">
                        <span>Revised Due Date Comments:</span>
                    </td>
                    <td width="2%">
                        &nbsp;
                    </td>
                    <td width="70%">
                        <asp:TextBox ID="TxtRevisionDateComments" runat="server" Height="64px" TextMode="MultiLine"
                            Width="100%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="middle" width="28%">
                        <asp:LinkButton ID="LkBtnContacts" runat="server"><span>Client Contacts:</span></asp:LinkButton>
                        <span runat="server" id="aContact" visible="false">Client Contacts:</span>
                    </td>
                    <td width="2%">
                        &nbsp;
                    </td>
                    <td width="70%">
                        <asp:TextBox ID="TxtClientContacts" runat="server" Height="31px" TextMode="MultiLine"
                            Width="342px"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
