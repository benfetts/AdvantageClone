<%@ Page AutoEventWireup="false" CodeBehind="TaskList_Settings.aspx.vb" Inherits="Webvantage.TaskList_Settings" Title="Task List"
    Language="vb" MasterPageFile="~/ChildPage.Master" %>

<%@ Register Src="ReportTypeUC.ascx" TagName="reporttype" TagPrefix="uc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain"
    EnableViewState="true">
    <style type="text/css">
            .rlbItem
            {
                text-align: left !important;
                
            }
    </style>
    <div class="telerik-aqua-body" style="margin-top: 5px!important;">
        <table id="Table2" align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td align="right" valign="top" style="width: 50%">
                <table id="Table3" align="center" cellpadding="2" cellspacing="0" width="100%">
                    <tr>
                        <td align="center" colspan="2" class="sub-header sub-header-color">
                            Selection Options
                        </td>
                    </tr>
                    <tr>
                        <td align="center" valign="top">
                            <asp:RadioButtonList ID="rblOffices" runat="server" Width="256px" AutoPostBack="True"
                                RepeatColumns="2">
                                <asp:ListItem Selected="True" Value="all">All Offices</asp:ListItem>
                                <asp:ListItem Value="Choose">Choose Offices</asp:ListItem>
                            </asp:RadioButtonList>
                            <br />
                            <telerik:RadListBox ID="lbOffices" runat="server" Height="50px" Width="300px">
                            </telerik:RadListBox>
                            <br />
                            <hr size="1" width="100%" />
                            <asp:RadioButtonList ID="rdlClients" runat="server" Width="256px" AutoPostBack="True"
                                RepeatColumns="2">
                                <asp:ListItem Selected="True" Value="all">All Clients</asp:ListItem>
                                <asp:ListItem Value="Choose">Choose Clients</asp:ListItem>
                            </asp:RadioButtonList>
                            <br />
                            <telerik:RadListBox ID="lstClients" runat="server" Height="50px" Width="300px">
                            </telerik:RadListBox>
                            <br />
                            <hr size="1" width="100%" />
                            <asp:RadioButtonList ID="rdlEmpRole" runat="server" Width="216px" AutoPostBack="True"
                                RepeatColumns="2">
                                <asp:ListItem Selected="True" Value="all">By Employees</asp:ListItem>
                                <asp:ListItem Value="Choose">By Roles</asp:ListItem>
                            </asp:RadioButtonList>
                            <br />
                            <asp:RadioButtonList ID="rdlEmployees" runat="server" Width="275px" AutoPostBack="True"
                                RepeatColumns="2">
                                <asp:ListItem Selected="True" Value="all">All Employees</asp:ListItem>
                                <asp:ListItem Value="Choose">Choose Employees</asp:ListItem>
                            </asp:RadioButtonList>
                            <br />
                            <telerik:RadListBox ID="lstEmployees" runat="server" Height="50px" Width="400px">
                            </telerik:RadListBox>
                            <br />
                            <hr size="1" width="100%" />
                            <asp:CheckBox ID="chkCompleted" runat="server" Text="Include Completed Tasks" /><br />
                            <hr size="1" width="100%" />
                            <asp:RadioButtonList ID="rdlAE" runat="server" Width="400" AutoPostBack="True"
                                RepeatColumns="2">
                                <asp:ListItem Selected="True" Value="all">All Account Executives</asp:ListItem>
                                <asp:ListItem Value="Choose">Choose Account Executives</asp:ListItem>
                            </asp:RadioButtonList>
                            <br />
                            <telerik:RadListBox ID="lstAEs" runat="server" Height="50px" SelectionMode="Multiple" Width="300px">
                            </telerik:RadListBox>
                            <hr size="1" width="100%" />
                            <table>
                                <tr>
                                    <td height="30px" align="center" valign="top">
                                        <asp:Label   ID="lblManager" runat="server"></asp:Label>&nbsp;&nbsp;
                                    </td>
                                    <td height="30px" align="center" valign="top">
                                        <telerik:RadComboBox
                                            ID="ddManager" runat="server" Width="275px">
                                        </telerik:RadComboBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>

                                    </td>
                                    <td align="left" valign="top">
                                        <asp:CheckBox ID="CheckBoxOnlyUnassigned" runat="server" Text="Only Unassigned Tasks" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>

                                    </td>
                                    <td align="left" valign="top">
                                        <asp:CheckBox ID="CheckBoxExcludeUnassigned" runat="server" Text="Exclude Unassigned Tasks" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
            <td align="center" rowspan="3" valign="top" style="width: 50%">
                <table id="Table6" cellpadding="2" cellspacing="0" width="100%" align="center">
                    <tr>
                        <td align="center" class="sub-header sub-header-color">
                            Display Options
                        </td>
                    </tr>
                    <tr>
                        <td>
                                <asp:CheckBox ID="chkClient" runat="server" Checked="True" Text="Client" />
                                <br />
                                <asp:CheckBox ID="chkDivision" runat="server" Checked="True" Text="Division" />
                                <br />
                                <asp:CheckBox ID="chkProduct" runat="server" Checked="True" Text="Product" />
                                <br />
                                <asp:CheckBox ID="chkJob" runat="server" Checked="True" Text="Job" />
                                <br />
                                <asp:CheckBox ID="chkComponent" runat="server" Checked="True" Text="Component" />
                                <br />
                                <asp:CheckBox ID="chkTask" runat="server" Checked="True" Enabled="False" Text="Task" />
                                <br />
                                <asp:CheckBox ID="chkEmp" runat="server" Checked="true" Text="Employee Assigned" />
                                <br />
                                <asp:CheckBox ID="chkHrsAllowed" runat="server" Checked="True" Text="Hours Allowed" />
                                <br />
                                <asp:CheckBox ID="chkRevDueDate" runat="server" Checked="True" Text="Due Date" />
                                <br />
                                <asp:CheckBox ID="chkTimeDue" runat="server" Checked="True" Text="Time Due" />
                                <br />
                                <asp:CheckBox ID="CheckBoxPhase" runat="server" Text="Phase" Visible="false" />                                
                                <asp:CheckBox ID="chkComments" runat="server" Text="Comments" />
                                <br />
                                <asp:CheckBox ID="chkJobTrafficComments" runat="server" Text="Job Schedule Comments" />
                                <br />
                                <br />
                                <br />
                            <br />
                        </td>
                    </tr>
                </table>
                <br />
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 50%; padding-top: 10px" >
                <table id="Table4" align="center" cellpadding="2" cellspacing="0" width="100%">
                    <tr>
                        <td align="center" class="sub-header sub-header-color">
                            Date Options
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table id="Table8" border="0" cellpadding="1" cellspacing="1" align="center">
                                <tr>
                                    <td align="right" style="height: 37px">
                                        <asp:RadioButton ID="rbDateRange" runat="server" AutoPostBack="True" Checked="True"
                                            GroupName="dateoptions" Text="Start Date" />
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
                                </tr>
                                <tr>
                                    <td align="right">
                                        End Date
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
                                </tr>
                                <tr>
                                    <td align="left" colspan="2">
                                        <asp:RadioButton ID="rbPastDue" runat="server" AutoPostBack="True" GroupName="dateoptions"
                                            Text="Past Due Only" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center" valign="top" style="width: 50%; padding-top: 10px">
                <table id="Table5" align="center" cellpadding="2" cellspacing="0" width="100%">
                    <tr>
                        <td align="center" class="sub-header sub-header-color">
                            Sort Options
                        </td>
                    </tr>
                    <tr>
                        <td height="61" align="center">
                            <table>
                                <tr>
                                    <td>

                                    </td>
                                </tr>
                            </table>
                            <asp:RadioButton ID="rbClient" runat="server" AutoPostBack="True" GroupName="SortOptions"
                                Text="Client" />
                            <br />
                            <asp:RadioButton ID="rbCDP" runat="server" AutoPostBack="True" Checked="True" GroupName="SortOptions"
                                Text="Client/Division/Product" />
                            <br />
                            <asp:RadioButton ID="rbJobComp" runat="server" AutoPostBack="True" GroupName="SortOptions"
                                Text="Job/Component" />
                            <br />
                            <asp:RadioButton ID="rbDueDate" runat="server" AutoPostBack="True" GroupName="SortOptions"
                                Text="Due Date" />
                            <br />
                            <asp:RadioButton ID="rbJobCompSummary" runat="server" AutoPostBack="True" GroupName="SortOptions"
                                Text="Due Date Summary" />
                            <br />
                            <asp:RadioButton ID="rbTask" runat="server" AutoPostBack="True" GroupName="SortOptions"
                                Text="Task" />
                            <br />
                            <asp:CheckBox ID="chkSubHeadings" runat="server" AutoPostBack="True" Text="Use Sub Headings"
                                Visible="False" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" valign="top">
                Type:&nbsp;<uc1:reporttype ID="reporttype" runat="server" />
                &nbsp; &nbsp;<br />
                <br />
                <asp:CheckBox ID="chkSaveSettings" runat="server" Text="Save My Options" />&nbsp;<br />
                <br />
                <asp:Button ID="butView" runat="server" Text="View" /><br />
            </td>
        </tr>
    </table>
    </div>
    
</asp:Content>
