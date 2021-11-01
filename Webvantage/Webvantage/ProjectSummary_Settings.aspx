<%@ Page AutoEventWireup="false" CodeBehind="ProjectSummary_Settings.aspx.vb" Inherits="Webvantage.ProjectSummary_Settings"
    Language="vb" MasterPageFile="~/ChildPage.Master" %>

<%@ Register Src="ReportTypeUC.ascx" TagName="reporttype" TagPrefix="uc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain"
    EnableViewState="true">
    <style type="text/css">
        .rlbItem {
            text-align: left !important;
        }
    </style>
    <div class="telerik-aqua-body" style="margin-top: 5px!important;">
        <div align="center">
                <asp:Label ID="lbl_msg" runat="server" CssClass="warning"></asp:Label>
            </div>
            <table cellpadding="0" cellspacing="0" width="100%" align="center" border="0">
              <tr>
                    <td align="right" height="430" style="width: 480px" valign="top">
                        <asp:Panel ID="PanelOffice" runat="server">
                            <table id="Table3" align="center" cellpadding="2" cellspacing="0" width="100%">
                                <tr>
                                    <td align="center" colspan="2" class="sub-header sub-header-color">Office Options
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" valign="top">
                                        <asp:RadioButtonList ID="rblOffices" runat="server" AutoPostBack="True" RepeatColumns="2"
                                            Width="256px">
                                            <asp:ListItem Selected="True" Value="all">All Offices</asp:ListItem>
                                            <asp:ListItem Value="Choose">Choose Offices</asp:ListItem>
                                        </asp:RadioButtonList>
                                        <br />
                                        <telerik:RadListBox ID="lbOffices" runat="server" Height="50px" Width="300px"></telerik:RadListBox>
                                        <br />
                                        <br />
                                    </td>
                                </tr>
                            </table>
                            <br />
                        </asp:Panel>
                        <table id="Table1" align="center" cellpadding="2" cellspacing="0" width="100%">
                            <tr>
                                <td align="center" class="sub-header sub-header-color">Client Options
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:RadioButtonList ID="optCDP" runat="server" AutoPostBack="True" RepeatDirection="Horizontal">
                                        <asp:ListItem Selected="True" Value="a">All</asp:ListItem>
                                        <asp:ListItem Value="c">Client</asp:ListItem>
                                        <asp:ListItem Value="d">Division</asp:ListItem>
                                        <asp:ListItem Value="p">Product</asp:ListItem>
                                    </asp:RadioButtonList>
                                    <br />
                                    <asp:Panel ID="pnlClient" runat="server" Width="">
                                        <telerik:RadListBox ID="lstClient" runat="server" SelectionMode="Multiple" Width="300px" Height="200px"></telerik:RadListBox>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlDivision" runat="server" Width="">
                                        <telerik:RadListBox ID="lstDivision" runat="server" SelectionMode="Multiple" Width="300px" Height="200px"></telerik:RadListBox>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlProduct" runat="server" Width="">
                                        <telerik:RadListBox ID="lstProduct" runat="server" SelectionMode="Multiple" Width="300px" Height="200px"></telerik:RadListBox>
                                    </asp:Panel>
                                    <br />
                                </td>
                            </tr>
                        </table>
                        <br />
                        <table id="Table5" align="center" cellpadding="2" cellspacing="0" width="100%">
                            <tr>
                                <td align="center" class="sub-header sub-header-color">Status Options
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:RadioButtonList ID="rdlStatus" runat="server" AutoPostBack="True" RepeatColumns="2"
                                        Width="224px">
                                        <asp:ListItem Selected="True" Value="all">All Status</asp:ListItem>
                                        <asp:ListItem Value="Choose">Choose Status</asp:ListItem>
                                    </asp:RadioButtonList>
                                    <br />
                                    <telerik:RadListBox ID="lbStatus" runat="server" Height="75px" Width="300px"></telerik:RadListBox>
                                    <br />
                                </td>
                            </tr>
                        </table>
                        <br />
                        <table id="Table9" align="center" cellpadding="2" cellspacing="0" width="100%">
                            <tr>
                                <td align="center" class="sub-header sub-header-color">Account Executive Options
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:RadioButtonList ID="rdlAE" runat="server" Width="400" RepeatColumns="2" AutoPostBack="True">
                                        <asp:ListItem Selected="True" Value="all">All Account Executives</asp:ListItem>
                                        <asp:ListItem Value="Choose">Choose Account Executives</asp:ListItem>
                                    </asp:RadioButtonList>
                                    <br />
                                    <telerik:RadListBox ID="lstAEs" runat="server" Height="50px" SelectionMode="Multiple" Width="300px"></telerik:RadListBox>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <table id="Table10" align="center" cellpadding="2" cellspacing="0" width="100%">
                            <tr>
                                <td align="center" class="sub-header sub-header-color">Sales Class Options
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:RadioButtonList ID="rblSalesClass" runat="server" Width="356px" RepeatColumns="2"
                                        AutoPostBack="True">
                                        <asp:ListItem Selected="True" Value="all">All Sales Classes</asp:ListItem>
                                        <asp:ListItem Value="Choose">Choose Sales Classes</asp:ListItem>
                                    </asp:RadioButtonList>
                                    <br />
                                    <telerik:RadListBox ID="lstSalesClass" runat="server" Height="50px" SelectionMode="Multiple" Width="300px">
                                    </telerik:RadListBox>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <table id="Table7" align="center" cellpadding="2" cellspacing="0" width="100%">
                            <tr>
                                <td align="center" class="sub-header sub-header-color">Filter Options
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <br />
                                    <asp:Label ID="lblManager" runat="server"></asp:Label>&nbsp;&nbsp;<telerik:RadComboBox Width="250px"
                                        ID="ddManager" runat="server">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <br />
                                    <asp:CheckBox ID="cbIncludeCompSchedules" runat="server" Text="Include Jobs with Completed Schedules" /><br />
                                    <br />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td align="left" rowspan="3" style="width: 182px" valign="top">
                        <table id="Table6" cellpadding="2" cellspacing="0" width="100%">
                            <tr>
                                <td align="center" class="sub-header sub-header-color">Display Options
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBox ID="chkClient" runat="server" Checked="True" Enabled="False" Text="Client" />
                                    <br />
                                    <asp:CheckBox ID="chkDivision" runat="server" Checked="true" Text="Division" />
                                    <br />
                                    <asp:CheckBox ID="chkProduct" runat="server" Checked="true" Text="Product" />
                                    <br />
                                    <asp:CheckBox ID="chkAE" runat="server" Checked="true" Text="Account Executive" />
                                    <br />
                                    <asp:CheckBox ID="chkJob" runat="server" Checked="True" Enabled="false" Text="Job Number" />
                                    <br />
                                    <asp:CheckBox ID="chkJobDesc" runat="server" Checked="True" Text="Job Description" />
                                    <br />
                                    <asp:CheckBox ID="chkComponent" runat="server" Checked="True" Text="Component" />
                                    <br />
                                    <asp:CheckBox ID="chkJobCompDesc" runat="server" Checked="True" Text="Component Description" />
                                    <br />
                                    <asp:CheckBox ID="chkJobQuantity" runat="server" Checked="True" Text="Job Quantity" />
                                    <br />
                                    <asp:CheckBox ID="chkType" runat="server" Checked="True" Enabled="true" Text="Job Type" />
                                    <br />
                                    <asp:CheckBox ID="chkTypeDesc" runat="server" Checked="True" Text="Job Type Description" />
                                    <br />
                                    <asp:CheckBox ID="chkStatus" runat="server" Checked="True" Text="Status" />
                                    <br />
                                    <asp:CheckBox ID="chkRef" runat="server" Checked="True" Text="Client Reference" />
                                    <br />
                                    <asp:CheckBox ID="chkSDate" runat="server" Checked="True" Text="Start Date" />
                                    <br />
                                    <asp:CheckBox ID="chkDueDate" runat="server" Checked="True" Text="Due Date" />
                                    <br />
                                    <asp:CheckBox ID="chkComments" runat="server" Checked="True" Text="Comments" />
                                    <br />
                                    <asp:CheckBox ID="chkndue" runat="server" Checked="True" Text="Next Task Due" />
                                    <br />
                                    <asp:CheckBox ID="chknduedate" runat="server" Checked="True" Text="Next Task Due Date" />
                                    <br />
                                    <asp:CheckBox ID="chkntaskcomm" runat="server" Checked="True" Text="Next Task Comment" />
                                    <br />
                                    <asp:CheckBox ID="chkest" runat="server" Checked="True" Text="Estimate" />
                                    <br />
                                    <asp:CheckBox ID="chkestaprv" runat="server" Checked="True" Text="Estimate Approved" />
                                    <br />
                                </td>
                            </tr>
                        </table>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td align="right" colspan="2">
                        <table id="Table4" align="center" cellpadding="2" cellspacing="0" width="100%">
                            <tr>
                                <td align="center" class="sub-header sub-header-color">Date Options
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:RadioButtonList ID="rdlDueDate" runat="server" AutoPostBack="True" RepeatColumns="2"
                                        Width="250px">
                                        <asp:ListItem Selected="True" Value="all">All</asp:ListItem>
                                        <asp:ListItem Value="Choose">By Job Due Date</asp:ListItem>
                                    </asp:RadioButtonList>
                                    <br />
                                    <table id="Table8" align="center" border="0" cellpadding="1" cellspacing="1">
                                        <tr>
                                            <td align="right">Start Date:
                                            </td>
                                            <td align="left" style="height: 37px">&nbsp;
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
                                            <td align="right">End Date:
                                            </td>
                                            <td align="left">&nbsp;
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
                                </td>
                            </tr>
                        </table>
                        <br />
                        <table id="Table11" align="center" cellpadding="2" cellspacing="0" width="100%">
                            <tr>
                                <td align="center" class="sub-header sub-header-color">Sort Options
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:RadioButton ID="rbNone" runat="server" Checked="True" GroupName="SortOptions"
                                        Text="Client/Division/Product" />
                                    <br />
                                    <asp:RadioButton ID="rbCSCJDD" runat="server" GroupName="SortOptions" Text="Client/Sales Class/Job Due Date" />
                                </td>
                            </tr>
                        </table>
                        <br />
                        <table id="rpttitle" align="center" cellpadding="2" cellspacing="0" width="100%">
                            <tr>
                                <td align="center" class="sub-header sub-header-color">Report Title                            
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <br />
                                    <asp:TextBox ID="txtReportTitle" runat="server" Width="400" SkinID="TextBoxStandard">Project Summary Report</asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2" valign="top">Type:&nbsp;<uc1:reporttype ID="reporttype" runat="server" />
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
