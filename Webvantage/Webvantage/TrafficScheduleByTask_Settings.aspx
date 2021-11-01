<%@ Page Title="Schedule By Task Settings" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="TrafficScheduleByTask_Settings.aspx.vb" Inherits="Webvantage.TrafficScheduleByTask_Settings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <style type="text/css">
            .rlbItem
            {
                text-align: left !important;
                
            }

            .rb {
                margin: 0 !important;
            }

    </style>
    <div class="telerik-aqua-body" style="margin-top: 5px!important;">
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="center" colspan="2" class="sub-header sub-header-color">
                           Format Selection<br />
                            <asp:Label ID="lblMSG" runat="server" CssClass="warning"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" valign="top" colspan="2">
                            <br />
                            <telerik:RadComboBox ID="ddlFormat" runat="server" AutoPostBack="true">
                                <Items>
                                    <telerik:RadComboBoxItem Text="Traffic By Task" Value="1"></telerik:RadComboBoxItem>
                                    <telerik:RadComboBoxItem Text="Completed Task Report" Value="2"></telerik:RadComboBoxItem>
                                    <telerik:RadComboBoxItem Text="Traffic By Role" Value="3"></telerik:RadComboBoxItem>
                                </Items>
                            </telerik:RadComboBox>
                            <br />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" class="sub-header sub-header-color">
                           Selection Options
                        </td>
                        <td align="center" class="sub-header sub-header-color">
                           Display Options
                        </td>
                    </tr>
                    <tr>
                        <td align="center" valign="top">
                            <asp:Panel ID="PanelOptions" runat="server">
                            <asp:RadioButtonList ID="rblOffices" runat="server" Width="200px" AutoPostBack="True">
                                <asp:ListItem Selected="True" Value="all">All Offices</asp:ListItem>
                                <asp:ListItem Value="Choose">Choose Offices</asp:ListItem>
                            </asp:RadioButtonList>
                            <br />
                            <telerik:RadListBox ID="lbOffices" runat="server" Height="75px" width="300px">
                            </telerik:RadListBox>
                            <br />
                            <hr size="1" width="100%" />
                            <asp:RadioButtonList ID="rdlClients" runat="server" Width="200px" AutoPostBack="True">
                                <asp:ListItem Selected="True" Value="all">All Clients</asp:ListItem>
                                <asp:ListItem Value="Choose">Choose Clients</asp:ListItem>
                            </asp:RadioButtonList>
                            <br />
                            <telerik:RadListBox ID="lstClients" runat="server" Height="75px" width="300px">
                            </telerik:RadListBox>
                            <br />
                            <hr size="1" width="100%" />
                            <asp:RadioButtonList ID="rdlEmployees" runat="server" Width="200px" AutoPostBack="True">
                                <asp:ListItem Selected="True" Value="all">All Roles</asp:ListItem>
                                <asp:ListItem Value="Choose">Choose Roles</asp:ListItem>
                            </asp:RadioButtonList>
                            <br />
                            <telerik:RadListBox ID="lstEmployees" runat="server" Height="75px" width="300px">
                            </telerik:RadListBox>
                            <hr size="1" width="100%" />
                            <asp:RadioButtonList ID="rdlStatus" runat="server" Width="200px" AutoPostBack="True">
                                <asp:ListItem Selected="True" Value="all">All Status</asp:ListItem>
                                <asp:ListItem Value="Choose">Choose Status</asp:ListItem>
                            </asp:RadioButtonList>
                            <br />
                            <telerik:RadListBox ID="lbStatus" runat="server" Height="75px" width="300px">
                            </telerik:RadListBox>
                            <br />
                            <hr size="1" width="100%" />
                            <asp:RadioButtonList ID="rdlAE" runat="server" Width="400" AutoPostBack="True">
                                <asp:ListItem Selected="True" Value="all">All Account Executives</asp:ListItem>
                                <asp:ListItem Value="Choose">Choose Account Executives</asp:ListItem>
                            </asp:RadioButtonList>
                            <br />
                            <telerik:RadListBox ID="lstAEs" runat="server" Height="50px" SelectionMode="Multiple" Width="300px">
                            </telerik:RadListBox>
                            <hr size="1" width="100%" />
                            </asp:Panel>
                            <asp:RadioButton ID="chkAllQualifiedJobs" runat="server" Text="All Qualified Jobs"
                                GroupName="JobsQualDate" Checked="true" AutoPostBack="true" /><br />
                            <asp:RadioButton ID="chkForJobDueDate" runat="server" Text="Job Due Date Range" GroupName="JobsQualDate"
                                AutoPostBack="true" /><br />
                            <table style="padding-right: 0px; padding-left: 0px; padding-bottom: 0px; margin: 0px;
                                padding-top: 0px;">
                                <tr>
                                    <td style="width: 113px;" align="right">
                                        For Date Range:
                                    </td>
                                    <td style="width: 130px;" align="left">
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
                                </tr>
                                <tr>
                                    <td style="width: 113px" align="right">
                                        to
                                    </td>
                                    <td style="width: 130px;" align="left">
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
                            </table>
                            <hr size="1" width="100%" />
                            <asp:CheckBox ID="chkClosedJobs" runat="server" Text="Include Completed Jobs" AutoPostBack="true" /><br />
                            <table style="padding-right: 0px; padding-left: 0px; padding-bottom: 0px; margin: 0px;
                                padding-top: 0px;">
                                <tr>
                                    <td style="width: 113px;" align="right">
                                        For Date Range:
                                    </td>
                                    <td style="width: 130px;" align="left">
                                        <telerik:RadDatePicker ID="RadDatePickerStartDateClosed" runat="server" 
                                              SkinID="RadDatePickerStandard">
                                            <DateInput DateFormat="d" EmptyMessage="">
                                                <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                                            </DateInput>
                                            <Calendar ID="Calendar1" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                                                <SpecialDays>
                                                    <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="radcalendar-today">
                                                    </telerik:RadCalendarDay>
                                                </SpecialDays>
                                            </Calendar>
                                        </telerik:RadDatePicker>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 113px" align="right">
                                        to
                                    </td>
                                    <td style="width: 130px;" align="left">
                                        <telerik:RadDatePicker ID="RadDatePickerEndDateClosed" runat="server" 
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
                            </table>
                            <asp:CheckBox ID="chkNoTasksSummaryOnly" runat="server" Text="Exclude Tasks (Summary Only)" />
                            <hr size="1" width="100%" />
                            <table>
                                <tr>
                                    <td height="30px" align="center" valign="top">
                                        <asp:Label   ID="lblManager" runat="server"></asp:Label>&nbsp;<telerik:RadComboBox
                                            ID="ddManager" runat="server">
                                        </telerik:RadComboBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td valign="top">
                            <asp:CheckBox ID="chkJobStatusFirst" runat="server" Text="Job Status" /><br />
                            <asp:CheckBox ID="chkManager" runat="server" Text="Manager" /><br />
                            <asp:CheckBox ID="chkProjectDate" runat="server" Text="Job Start Date" /><br />
                            <asp:CheckBox ID="chkJobDueDate1" runat="server" Text="Job Due Date" /><br />
                            <asp:CheckBox ID="chkCompletedDate" runat="server" Text="Job Completed Date" /><br />
                            <asp:CheckBox ID="chkClientCode" runat="server" Text="Client Code" /><br />
                            <asp:CheckBox ID="chkClientDesc" runat="server" Text="Client Description" /><br />
                            <asp:CheckBox ID="chkDivisionCode" runat="server" Text="Division Code" /><br />
                            <asp:CheckBox ID="chkDivisionDesc" runat="server" Text="Division Description" /><br />
                            <asp:CheckBox ID="chkProductCode" runat="server" Text="Product Code" /><br />
                            <asp:CheckBox ID="chkProductDesc" runat="server" Text="Product Description" /><br />
                            <asp:CheckBox ID="chkJobDesc" runat="server" Text="Job Description" /><br />
                            <asp:CheckBox ID="chkJobCompNum" runat="server" Text="Job Component" /><br />
                            <asp:CheckBox ID="chkJobCompDesc" runat="server" Text="Job Comp Description" /><br />
                            <asp:CheckBox ID="chkClientReference" runat="server" Text="Client Reference" /><br />
                            <asp:CheckBox ID="chkAccountExecutive" runat="server" Text="Account Executive" /><br />
                            <asp:CheckBox ID="chkJobType" runat="server" Text="Job Type" /><br />
                            <asp:CheckBox ID="chkJobTypeDesc" runat="server" Text="Job Type Description" /><br />
                            <asp:CheckBox ID="chkRush" runat="server" Text="Rush" /><br />
                            <asp:CheckBox ID="chkJobMarkup" runat="server" Text="Job Markup %" /><br />
                            <asp:CheckBox ID="chkJobNonBillFlag" runat="server" Text="Job Non Bill Flag" /><br />
                            <asp:CheckBox ID="chkJobDueDate2" runat="server" Text="Job Due Date" /><br />
                            <asp:CheckBox ID="chkJobStatus" runat="server" Text="Job Status" /><br />
                            <asp:CheckBox ID="chkComments" runat="server" Text="Traffic Comments" /><br />
                            <asp:CheckBox ID="ChkIncludeTaskDesc" runat="server" Text="Show Task Description" /><br />
                            <asp:CheckBox ID="chkIncludeEmpAssign" runat="server" Text="Include Employee Assignment as Row" /><br />
                            <asp:CheckBox ID="CheckBoxPhase" runat="server" Text="Include Phase as Row" /><br />
                            <asp:CheckBox ID="CheckBoxDateFormat" runat="server" Text="Use short date format (MM/DD)" /><br />
                            <hr size="1" width="100%">
                            <asp:RadioButtonList ID="rblDates" runat="server" Width="350px" AutoPostBack="true" TextAlign="Right" CssClass="rb">
                                <asp:ListItem Value="origdue">Original Due Date</asp:ListItem>
                                <asp:ListItem Value="due">Due Date</asp:ListItem>
                                <asp:ListItem Value="duetime">Due Date/Time Due</asp:ListItem>
                                <asp:ListItem Value="comp">Completed Date</asp:ListItem>
                                <asp:ListItem Value="origcomp">Original Due Date/Completed Date</asp:ListItem>
                                <asp:ListItem Value="duecomp">Due Date/Completed Date</asp:ListItem>
                                <asp:ListItem Value="dueorcomp">Due Date/Completed Date (Single Cell)</asp:ListItem>
                            </asp:RadioButtonList>
                            <hr size="1" width="100%">
                            <%--<asp:CheckBox ID="CheckBoxIncludeEmpRole" runat="server" Enabled="false"  
                                        Text="Include Employee Role" />--%>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2" class="sub-header sub-header-color">
                           Report Title
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <br />
                            <asp:TextBox ID="txtReportTitle" runat="server" Width="400" SkinID="TextBoxStandard">Schedule by Task</asp:TextBox><br />
                            <br />
                        </td>
                    </tr>
                    <asp:Panel ID="pnlFormat" runat="server">
                        <tr>
                            <td align="center" colspan="2" class="sub-header sub-header-color">
                                Options
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
                        <tr>
                            <td align="center" colspan="2">
                                <asp:Label   ID="lblTemplate" runat="server" Text="Template:"></asp:Label>&nbsp;<telerik:RadComboBox
                                    ID="ddTaskTemplate" runat="server">
                                </telerik:RadComboBox>
                                &nbsp;&nbsp;<asp:ImageButton ID="imgbtnTasks" runat="server" SkinID="ImageButtonRefresh" />&nbsp;&nbsp;
                                <asp:CheckBox ID="chkMilestone" runat="server" Text="Milestone Tasks Only" />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" valign="top">
                                <table border="0" cellpadding="0" cellspacing="2" width="100%" align="center">
                                    <tr>
                                        <td nowrap="nowrap">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <td nowrap="nowrap">
                                            <span>&nbsp;&nbsp;Task1:</span>
                                            <telerik:RadComboBox ID="ddTask1" runat="server" width="300px">
                                            </telerik:RadComboBox>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <td nowrap="nowrap">
                                            <span>&nbsp;&nbsp;Task2:</span>
                                            <telerik:RadComboBox ID="ddTask2" runat="server" width="300px">
                                            </telerik:RadComboBox>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <td nowrap="nowrap">
                                            <span>&nbsp;&nbsp;Task3:</span>
                                            <telerik:RadComboBox ID="ddTask3" runat="server" width="300px">
                                            </telerik:RadComboBox>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <td nowrap="nowrap">
                                            <span>&nbsp;&nbsp;Task4:</span>
                                            <telerik:RadComboBox ID="ddTask4" runat="server" width="300px">
                                            </telerik:RadComboBox>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <td nowrap="nowrap">
                                            <span>&nbsp;&nbsp;Task5:</span>
                                            <telerik:RadComboBox ID="ddTask5" runat="server" width="300px">
                                            </telerik:RadComboBox>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <td nowrap="nowrap">
                                            <span>&nbsp;&nbsp;Task6:</span>
                                            <telerik:RadComboBox ID="ddTask6" runat="server" width="300px">
                                            </telerik:RadComboBox>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <td nowrap="nowrap">
                                            <span>&nbsp;&nbsp;Task7:</span>
                                            <telerik:RadComboBox ID="ddTask7" runat="server" width="300px">
                                            </telerik:RadComboBox>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <td nowrap="nowrap">
                                            <span>&nbsp;&nbsp;Task8:</span>
                                            <telerik:RadComboBox ID="ddTask8" runat="server" width="300px">
                                            </telerik:RadComboBox>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <td nowrap="nowrap">
                                            <span>&nbsp;&nbsp;Task9:</span>
                                            <telerik:RadComboBox ID="ddTask9" runat="server" width="300px">
                                            </telerik:RadComboBox>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <td nowrap="nowrap">
                                            <span>Task10:</span>
                                            <telerik:RadComboBox ID="ddTask10" runat="server" width="300px">
                                            </telerik:RadComboBox>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <td nowrap="nowrap">
                                            <span>Task11:</span>
                                            <telerik:RadComboBox ID="ddTask11" runat="server" width="300px">
                                            </telerik:RadComboBox>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <td nowrap="nowrap">
                                            <span>Task12:</span>
                                            <telerik:RadComboBox ID="ddTask12" runat="server" width="300px">
                                            </telerik:RadComboBox>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <td nowrap="nowrap">
                                            <span>Task13:</span>
                                            <telerik:RadComboBox ID="ddTask13" runat="server" width="300px">
                                            </telerik:RadComboBox>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <td nowrap="nowrap">
                                            <span>Task14:</span>
                                            <telerik:RadComboBox ID="ddTask14" runat="server" width="300px">
                                            </telerik:RadComboBox>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <td nowrap="nowrap">
                                            <span>Task15:</span>
                                            <telerik:RadComboBox ID="ddTask15" runat="server" width="300px">
                                            </telerik:RadComboBox>
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                                &nbsp;
                            </td>
                            <td align="center" valign="top">
                                <table border="0" cellpadding="0" cellspacing="2" width="100%" align="center">
                                    <tr>
                                        <td nowrap="nowrap">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <td nowrap="nowrap">
                                            <span>Task16:</span>
                                            <telerik:RadComboBox ID="ddTask16" runat="server" width="300px">
                                            </telerik:RadComboBox>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <td nowrap="nowrap">
                                            <span>Task17:</span>
                                            <telerik:RadComboBox ID="ddTask17" runat="server" width="300px">
                                            </telerik:RadComboBox>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <td nowrap="nowrap">
                                            <span>Task18:</span>
                                            <telerik:RadComboBox ID="ddTask18" runat="server" width="300px">
                                            </telerik:RadComboBox>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <td nowrap="nowrap">
                                            <span>Task19:</span>
                                            <telerik:RadComboBox ID="ddTask19" runat="server" width="300px">
                                            </telerik:RadComboBox>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <td nowrap="nowrap">
                                            <span>Task20:</span>
                                            <telerik:RadComboBox ID="ddTask20" runat="server" width="300px">
                                            </telerik:RadComboBox>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <td nowrap="nowrap">
                                            <span>Task21:</span>
                                            <telerik:RadComboBox ID="ddTask21" runat="server" width="300px">
                                            </telerik:RadComboBox>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <td nowrap="nowrap">
                                            <span>Task22:</span>
                                            <telerik:RadComboBox ID="ddTask22" runat="server" width="300px">
                                            </telerik:RadComboBox>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <td nowrap="nowrap">
                                            <span>Task23:</span>
                                            <telerik:RadComboBox ID="ddTask23" runat="server" width="300px">
                                            </telerik:RadComboBox>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <td nowrap="nowrap">
                                            <span>Task24:</span>
                                            <telerik:RadComboBox ID="ddTask24" runat="server" width="300px">
                                            </telerik:RadComboBox>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <td nowrap="nowrap">
                                            <span>Task25:</span>
                                            <telerik:RadComboBox ID="ddTask25" runat="server" width="300px">
                                            </telerik:RadComboBox>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <td nowrap="nowrap">
                                            <span>Task26:</span>
                                            <telerik:RadComboBox ID="ddTask26" runat="server" width="300px">
                                            </telerik:RadComboBox>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <td nowrap="nowrap">
                                            <span>Task27:</span>
                                            <telerik:RadComboBox ID="ddTask27" runat="server" width="300px">
                                            </telerik:RadComboBox>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <td nowrap="nowrap">
                                            <span>Task28:</span>
                                            <telerik:RadComboBox ID="ddTask28" runat="server" width="300px">
                                            </telerik:RadComboBox>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <td nowrap="nowrap">
                                            <span>Task29:</span>
                                            <telerik:RadComboBox ID="ddTask29" runat="server" width="300px">
                                            </telerik:RadComboBox>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <td nowrap="nowrap">
                                            <span>Task30:</span>
                                            <telerik:RadComboBox ID="ddTask30" runat="server" width="300px">
                                            </telerik:RadComboBox>
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2" class="sub-header sub-header-color">
                               Sort&nbsp;Options
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                &nbsp;
                                <br />
                                <br />
                                <table border="0">
                                    <tr>
                                        <td align="right" style="height: 1px">
                                            <span>Primary Sort:</span>
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="ddSort1" runat="server">
                                                <Items>
                                                    <telerik:RadComboBoxItem Selected="True" Value="Manager" Text="Manager"></telerik:RadComboBoxItem>
                                                    <telerik:RadComboBoxItem Value="ProjectStartDate" Text="Job Start Date"></telerik:RadComboBoxItem>
                                                    <telerik:RadComboBoxItem Value="JobDueDate" Text="Job Due Date"></telerik:RadComboBoxItem>
                                                    <telerik:RadComboBoxItem Value="ClientCode" Text="Client Code"></telerik:RadComboBoxItem>
                                                    <telerik:RadComboBoxItem Value="ClientName" Text="Client Description"></telerik:RadComboBoxItem>
                                                    <telerik:RadComboBoxItem Value="DivisionCode" Text="Division Code"></telerik:RadComboBoxItem>
                                                    <telerik:RadComboBoxItem Value="DivisionName" Text="Division Description"></telerik:RadComboBoxItem>
                                                    <telerik:RadComboBoxItem Value="ProductCode" Text="Product Code"></telerik:RadComboBoxItem>
                                                    <telerik:RadComboBoxItem Value="ProductName" Text="Product Description"></telerik:RadComboBoxItem>
                                                    <telerik:RadComboBoxItem Value="JobNumber" Text="Job Number"></telerik:RadComboBoxItem>
                                                    <telerik:RadComboBoxItem Value="JobDescription" Text="Job Description"></telerik:RadComboBoxItem>
                                                    <telerik:RadComboBoxItem Value="JobCompNumber" Text="Component Number"></telerik:RadComboBoxItem>
                                                    <telerik:RadComboBoxItem Value="JobCompDescription" Text="Component Description">
                                                    </telerik:RadComboBoxItem>
                                                    <telerik:RadComboBoxItem Value="JobStatus" Text="Job Status"></telerik:RadComboBoxItem>
                                                </Items>
                                            </telerik:RadComboBox>
                                            <telerik:RadComboBox ID="ddSort1Direction" runat="server">
                                                <Items>
                                                    <telerik:RadComboBoxItem Value="" Text="Ascending"></telerik:RadComboBoxItem>
                                                    <telerik:RadComboBoxItem Value="DESC" Text="Descending"></telerik:RadComboBoxItem>
                                                </Items>
                                            </telerik:RadComboBox>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <span>Secondary Sort:</span>
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="ddSort2" runat="server">
                                                <Items>
                                                    <telerik:RadComboBoxItem Value="Manager" Text="Manager"></telerik:RadComboBoxItem>
                                                    <telerik:RadComboBoxItem Value="ProjectStartDate" Text="Job Start Date"></telerik:RadComboBoxItem>
                                                    <telerik:RadComboBoxItem Selected="True" Value="JobDueDate" Text="Job Due Date"></telerik:RadComboBoxItem>
                                                    <telerik:RadComboBoxItem Value="ClientCode" Text="Client Code"></telerik:RadComboBoxItem>
                                                    <telerik:RadComboBoxItem Value="ClientName" Text="Client Description"></telerik:RadComboBoxItem>
                                                    <telerik:RadComboBoxItem Value="DivisionCode" Text="Division Code"></telerik:RadComboBoxItem>
                                                    <telerik:RadComboBoxItem Value="DivisionName" Text="Division Description"></telerik:RadComboBoxItem>
                                                    <telerik:RadComboBoxItem Value="ProductCode" Text="Product Code"></telerik:RadComboBoxItem>
                                                    <telerik:RadComboBoxItem Value="ProductName" Text="Product Description"></telerik:RadComboBoxItem>
                                                    <telerik:RadComboBoxItem Value="JobNumber" Text="Job Number"></telerik:RadComboBoxItem>
                                                    <telerik:RadComboBoxItem Value="JobDescription" Text="Job Description"></telerik:RadComboBoxItem>
                                                    <telerik:RadComboBoxItem Value="JobCompNumber" Text="Component Number"></telerik:RadComboBoxItem>
                                                    <telerik:RadComboBoxItem Value="JobCompDescription" Text="Component Description">
                                                    </telerik:RadComboBoxItem>
                                                    <telerik:RadComboBoxItem Value="JobStatus" Text="Job Status"></telerik:RadComboBoxItem>
                                                </Items>
                                            </telerik:RadComboBox>
                                            <telerik:RadComboBox ID="ddSort2Direction" runat="server">
                                                <Items>
                                                    <telerik:RadComboBoxItem Value="" Text="Ascending"></telerik:RadComboBoxItem>
                                                    <telerik:RadComboBoxItem Value="DESC" Text="Descending"></telerik:RadComboBoxItem>
                                                </Items>
                                            </telerik:RadComboBox>
                                        </td>
                                    </tr>
                                </table>
                                <br />
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2" class="sub-header sub-header-color">
                               Export Options
                            </td>
                        </tr>
                    </asp:Panel>
                    <tr>
                        <td colspan="2">
                            <p align="center">
                                &nbsp;</p>
                            <p align="center">
                                <asp:CheckBox ID="chkExcel" runat="server" Text="Microsoft Excel" />&nbsp;
                            </p>
                            <p align="center">
                                <asp:CheckBox ID="chkSaveSettings" runat="server" Text="Save My Options" />
                            </p>
                            <p align="center">
                                <asp:Button ID="butView" runat="server" Text="View" />&nbsp;</p>
                            <p>
                                &nbsp;</p>
                        </td>
                    </tr>
                </table>
                </ContentTemplate>
            </asp:UpdatePanel>
    </div>
    
</asp:Content>
