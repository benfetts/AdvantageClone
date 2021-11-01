<%@ Page Title="My Task List" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="MyTaskList_Settings.aspx.vb" Inherits="Webvantage.MyTaskList_Settings" %>

<%@ Register Src="ReportTypeUC.ascx" TagName="reporttype" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div class="telerik-aqua-body">
        <table id="Table2" align="center" border="0" cellpadding="0" cellspacing="0" width="100%" >
        <tr>
            <td align="right" valign="top" style="width: 50%">
                <table id="Table3" align="center" cellpadding="2" cellspacing="0" width="100%">
                    <tr>
                        <td align="center" class="sub-header sub-header-color">
                           Selection Options
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <table id="Table7" align="center" border="0" cellpadding="2" cellspacing="0" width="100%">
                                <tr>
                                    <td align="right" style="padding-top: 5px; width: 40%">
                                        Client:&nbsp;
                                    </td>
                                    <td align="left" style="padding-top: 5px">
                                        <telerik:RadComboBox ID="ddClientList" runat="server" AutoPostBack="True" Width="300px">
                                        </telerik:RadComboBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="padding-top: 5px;">
                                        Division:&nbsp;
                                    </td>
                                    <td align="left" style="padding-top: 5px;">
                                        <telerik:RadComboBox ID="ddDivList" runat="server" AutoPostBack="True" Width="300px">
                                        </telerik:RadComboBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="padding-top: 5px;">
                                        Product:&nbsp;
                                    </td>
                                    <td align="left" style="padding-top: 5px;">
                                        <telerik:RadComboBox ID="ddProductList" runat="server" Width="300px">
                                        </telerik:RadComboBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="padding-top: 5px;">
                                        &nbsp;
                                    </td>
                                    <td align="left" nowrap="nowrap" style="padding-top: 5px;">
                                        <asp:CheckBox ID="chkCompleted" runat="server" Text="Include Completed Tasks" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <br />
                <br />
            </td>
            <td align="left" rowspan="3" valign="top" style="width: 50%">
                <table id="Table6" cellpadding="2" cellspacing="0" width="100%">
                    <tr>
                        <td align="center" class="sub-header sub-header-color">
                            Display Options
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-left: 10px">
                            <p>
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
                                <asp:CheckBox ID="chkHrsAllowed" runat="server" Checked="True" Text="Hours Allowed" />
                                <br />
                                <asp:CheckBox ID="chkDueDate" runat="server" Checked="True" Text="Original Due Date" />
                                <br />
                                <asp:CheckBox ID="chkRevDueDate" runat="server" Checked="True" Text="Due Date" />
                                <br />
                                <asp:CheckBox ID="chkTimeDue" runat="server" Checked="True" Text="Time Due" />
                                <br />
                                <asp:CheckBox ID="chkComments" runat="server" Text="Comments" />
                                <br />
                                <br />
                                <br />
                            </p>
                            <br />
                        </td>
                    </tr>
                </table>
                <br />
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 50%">
                <table id="Table4" align="center" cellpadding="2" cellspacing="0" width="100%">
                    <tr >
                        <td align="center" class="sub-header sub-header-color">
                            Date Options
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table id="Table8" border="0" cellpadding="1" cellspacing="1" align="center">
                                <tr>
                                    <td align="right" style="height: 37px;">
                                        <asp:RadioButton ID="rbDateRange" runat="server" AutoPostBack="True" Checked="True"
                                            GroupName="dateoptions" Text="Start Date:" />
                                    </td>
                                    <td align="left" style="height: 37px;">
                                        &nbsp;
                                        <telerik:RadDatePicker ID="RadDatePickerStartDate" runat="server" SkinID="RadDatePickerStandard">
                                            <DateInput DateFormat="d" EmptyMessage="Start Date">
                                                <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                                            </DateInput>
                                            <Calendar ID="CalendarStartDate" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                                                <SpecialDays>
                                                    <telerik:RadCalendarDay Repeatable="Today" ItemStyle-BackColor="LightSalmon">
                                                    </telerik:RadCalendarDay>
                                                </SpecialDays>
                                            </Calendar>
                                        </telerik:RadDatePicker>
                                    </td>
                                </tr>
                                <tr>
                                    <td  align="right">
                                        End Date:
                                    </td>
                                    <td  align="left">
                                        &nbsp;
                                        <telerik:RadDatePicker ID="RadDatePickerEndDate" runat="server" SkinID="RadDatePickerStandard">
                                            <DateInput DateFormat="d" EmptyMessage="End Date">
                                                <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                                            </DateInput>
                                            <Calendar ID="CalendarEndDate" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                                                <SpecialDays>
                                                    <telerik:RadCalendarDay Repeatable="Today" ItemStyle-BackColor="LightSalmon">
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
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td align="center" valign="top" style="width: 50%">
                <table id="Table5" align="center" cellpadding="2" cellspacing="0" width="100%">
                    <tr>
                        <td align="center" class="sub-header sub-header-color">
                            Sort Options
                        </td>
                    </tr>
                    <tr>
                        <td height="61" align="center">
                            <asp:RadioButton ID="rbCDP" runat="server" AutoPostBack="True" Checked="True" GroupName="SortOptions"
                                Text="Client/Division/Product" />
                            <br />
                            <asp:RadioButton ID="rbDueDate" runat="server" AutoPostBack="True" GroupName="SortOptions"
                                Text="Due Date" />
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
                <br />
                <br />
                <asp:Label   ID="lblError" runat="server" CssClass="warning"></asp:Label>
            </td>
        </tr>
    </table>
    </div>
    
</asp:Content>
