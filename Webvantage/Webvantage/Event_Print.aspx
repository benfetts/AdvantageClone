<%@ Page Title="Events" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="Event_Print.aspx.vb" Inherits="Webvantage.Event_Print" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div class="telerik-aqua-body">
        <asp:Literal ID="LitScript" runat="server"></asp:Literal>
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
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
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <telerik:RadComboBox ID="DropReportType" runat="server" AutoPostBack="True" TabIndex="0" SkinID="RadComboBoxStandard"
                                    Width="445px">
                                    <Items>
                                        <telerik:RadComboBoxItem Text="001 - Event Schedule by Employee" Value="evt_employee">
                                        </telerik:RadComboBoxItem>
                                        <telerik:RadComboBoxItem Text="002 - Event Schedule by Resource" Value="evt_resource">
                                        </telerik:RadComboBoxItem>
                                        <telerik:RadComboBoxItem Text="003 - Resource Usage" Value="rsc_usage"></telerik:RadComboBoxItem>
                                    </Items>
                                </telerik:RadComboBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <asp:CheckBox ID="ChkShowImages" runat="server" Text="Include images" AutoPostBack="True"
                                    Checked="True" />
                                <asp:CheckBox ID="ChkEnableEmail" runat="server" Text="Enable email" AutoPostBack="True" />
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
                                    Report Options
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
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <asp:CheckBox ID="CheckBoxPageBreak" runat="server" Text="Page break between employee/resource"
                                    Checked="False" />
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
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <asp:RadioButtonList ID="RblOffice" runat="server" RepeatDirection="Horizontal" AutoPostBack="True"
                                    RepeatLayout="Flow">
                                    <asp:ListItem Text="All Offices" Value="all"></asp:ListItem>
                                    <asp:ListItem Text="Choose Offices" Value="select" Selected="True"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <telerik:RadListBox ID="LbOfficesList" runat="server" AutoPostBack="False" AppendDataBoundItems="true"
                                    Height="75px" SelectionMode="Multiple" TabIndex="0" Width="445px">
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
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                                <td align="center" colspan="2" class="sub-header sub-header-color">
                                    Client/Division/Product Listing
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
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <asp:RadioButtonList ID="RblCDP" runat="server" RepeatDirection="Horizontal" AutoPostBack="True"
                                    RepeatLayout="Flow">
                                    <asp:ListItem Text="All Client/Division/Product" Value="all"></asp:ListItem>
                                    <asp:ListItem Text="Choose Client/Division/Product" Value="select" Selected="True"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <telerik:RadListBox ID="LbCDPList" runat="server" AutoPostBack="False" AppendDataBoundItems="true"
                                    Height="75px" SelectionMode="Multiple" TabIndex="0" Width="445px">
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
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                                <td align="center" colspan="2" class="sub-header sub-header-color">
                                    Resources Listing
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
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <asp:RadioButtonList ID="RblResource" runat="server" RepeatDirection="Horizontal"
                                    AutoPostBack="True" RepeatLayout="Flow">
                                    <asp:ListItem Text="All Resources" Value="all"></asp:ListItem>
                                    <asp:ListItem Text="Choose Resources" Value="select" Selected="True"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <telerik:RadListBox ID="LbResourcesList" runat="server" AutoPostBack="False" AppendDataBoundItems="true"
                                    Height="75px" SelectionMode="Multiple" TabIndex="0" Width="445px">
                                </telerik:RadListBox>
                                <br />
                                <asp:CheckBox ID="CheckboxIncludeInactiveResources" runat="server" Text="Include inactive Resources on the report (Report 002 only)" />
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
                                    Tasks Listing
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
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <asp:RadioButtonList ID="RblTask" runat="server" RepeatDirection="Horizontal" AutoPostBack="True"
                                    RepeatLayout="Flow">
                                    <asp:ListItem Text="All Tasks" Value="all"></asp:ListItem>
                                    <asp:ListItem Text="Choose Tasks" Value="select" Selected="True"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <telerik:RadListBox ID="LbTasksList" runat="server" AutoPostBack="False" AppendDataBoundItems="true"
                                    Height="75px" SelectionMode="Multiple" TabIndex="0" Width="445px">
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
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                                <td align="center" colspan="2" class="sub-header sub-header-color">
                                    Employee Listing
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
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <asp:RadioButtonList ID="RblEmployee" runat="server" RepeatDirection="Horizontal"
                                    AutoPostBack="True" RepeatLayout="Flow">
                                    <asp:ListItem Text="All Employees" Value="all"></asp:ListItem>
                                    <asp:ListItem Text="Choose Employees" Value="select" Selected="True"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <telerik:RadListBox ID="LbEmployeesList" runat="server" AutoPostBack="False" AppendDataBoundItems="true"
                                    Height="75px" SelectionMode="Multiple" TabIndex="0" Width="445px">
                                </telerik:RadListBox>
                                <br />
                                <asp:CheckBox ID="CheckboxIncludeTerminatedEmployees" runat="server" Text="Include terminated Employees on the report (Report 001 only)" />
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
                                    Date Range
                                </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div align="center">
                                    &nbsp;<asp:Label   ID="LblMSG" runat="server" Text="" CssClass="CssRequired"></asp:Label>&nbsp;</div>
                            </td>
                        </tr>
                        <tr>
                            <td width="150">
                                &nbsp;
                            </td>
                            <td width="500">
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
                <table cellpadding="0" cellspacing="0" width="100%" align="center" border="0">
                    <tr>
                        <td align="center">
                            <asp:Button ID="BtnView" runat="server" Text="View" TabIndex="0" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            &nbsp;
                        </td>
                    </tr>
                </table>
                </ContentTemplate>
            </asp:UpdatePanel>
    </div>
    
</asp:Content>
