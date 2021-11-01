<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="EmployeeIndirectTime_Settings.aspx.vb" Title="Indirect Time"
    Inherits="Webvantage.EmployeeIndirectTime_Settings" MasterPageFile="~/ChildPage.Master" %>

<%@ Register Src="ReportTypeUC.ascx" TagName="reporttype" TagPrefix="uc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain"
    EnableViewState="true">
    <div class="telerik-aqua-body">
        <table id="Table3" align="center" cellpadding="2" cellspacing="0" width="100%">
        <tr>
            <td align="center" colspan="2" class="sub-header sub-header-color">
                Selection Options
            </td>
        </tr>
        <tr>
            <td align="right" colspan="2">
                <table id="Table7" align="center" border="0" cellpadding="2" cellspacing="0" width="100%">
                    <tr>
                        <td style="vertical-align: top; text-align: left">
                            Offices
                        </td>
                        <td style="vertical-align: top; text-align: left">
                            Supervisors
                        </td>
                        <td style="vertical-align: top; text-align: left">
                            Departments
                        </td>
                        <td style="vertical-align: top; text-align: left">
                            Employees
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top; text-align: left">
                            <telerik:RadListBox ID="lboffice" runat="server" SelectionMode="Multiple" Width="155"
                                Height="120">
                            </telerik:RadListBox>
                        </td>
                        <td style="vertical-align: top; text-align: left">
                            <telerik:RadListBox ID="lbsupervisors" runat="server" SelectionMode="Multiple" Width="155"
                                Height="120">
                            </telerik:RadListBox>
                        </td>
                        <td style="vertical-align: top; text-align: left">
                            <telerik:RadListBox ID="lbdepartments" runat="server" SelectionMode="Multiple" Width="155"
                                Height="120">
                            </telerik:RadListBox>
                        </td>
                        <td style="vertical-align: top; text-align: left">
                            <telerik:RadListBox ID="lbemployees" runat="server" SelectionMode="Multiple" Width="155"
                                Height="120">
                            </telerik:RadListBox><br />
                            <asp:CheckBox ID="chkTerminated" runat="server" Text="Include Terminated Employees" /><br />
                            <asp:CheckBox ID="CheckBoxFreelance" runat="server" Text="Exclude Freelance Employees" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" nowrap="nowrap" colspan="4">
                            
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table id="Table1" align="center" cellpadding="2" cellspacing="0" width="100%">
        <tr>
            <td align="center" colspan="4" class="sub-header sub-header-color">
                Date Options
            </td>
        </tr>
        <tr>
            <td>
                <table id="Table8" border="0" cellpadding="1" cellspacing="1" align="left">
                    <tr>
                        <td align="left">
                            Start Date:
                        </td>
                        <td align="left" style="height: 37px">
                            &nbsp;
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
                        <td align="left">
                            &nbsp;&nbsp;&nbsp;&nbsp; End Date:
                        </td>
                        <td align="left">
                            &nbsp;
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
                        <td>
                            &nbsp;&nbsp;&nbsp;&nbsp;[For Other Indirect Time]
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table id="Table2" align="center" cellpadding="2" cellspacing="0" width="100%">
        <tr>
            <td align="center" class="sub-header sub-header-color">
                Group Options
            </td>
        </tr>
        <tr>
            <td height="61" align="left">
                <asp:CheckBox ID="CheckBoxByType" runat="server" Text="By Type" Checked="true" />
            </td>
        </tr>
    </table>
    <table id="Table5" align="center" cellpadding="2" cellspacing="0" width="100%">
        <tr>
            <td align="center" class="sub-header sub-header-color">
                Sort Options
            </td>
        </tr>
        <tr>
            <td height="61" align="left">
                <asp:RadioButton ID="rbOE" runat="server" Checked="True" GroupName="SortOptions"
                    Text="Office Code, Employee Code"  />
                <br />
                <asp:RadioButton ID="rbOELFM" runat="server" GroupName="SortOptions" Text="Office Code, Employee Name"
                     />
                <br />
                <asp:RadioButton ID="rbLFM" runat="server" GroupName="SortOptions" Text="Employee Name"
                    />
                <br />
                <asp:RadioButton ID="rbempcode" runat="server" GroupName="SortOptions" Text="Employee Code"
                     />
            </td>
        </tr>
        <tr>
            <td align="center">
                Type:&nbsp;<uc1:reporttype ID="reporttype" runat="server" />
                &nbsp; &nbsp;
                <br />
                <br />
                <asp:CheckBox ID="chkSaveSettings" runat="server" Text="Save My Options" />
                &nbsp;<br />
                <br />
                <asp:Button ID="butView" runat="server" Text="View" /><br />
                <br />
                <br />
                <asp:Label   ID="lblError" runat="server" CssClass="warning"></asp:Label>
            </td>
        </tr>
    </table>
    <span>
        
    </span>
    </div>
    
</asp:Content>
