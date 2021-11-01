<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Calendar_Report.aspx.vb"
    Inherits="Webvantage.Calendar_Report" MasterPageFile="~/ChildPage.Master" %>

<%@ Register Src="ReportTypeUC.ascx" TagName="reporttype" TagPrefix="uc1" %>
<%@ Register Assembly="DayPilot" Namespace="DayPilot.Web.Ui" TagPrefix="DayPilot" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain"
    EnableViewState="true">
    <telerik:RadTabStrip ID="RadTabStripTaskCalendar" runat="server" AutoPostBack="true"
        Orientation="HorizontalTop"  CausesValidation="false"
         Width="100%">
        <Tabs>
        </Tabs>
    </telerik:RadTabStrip>
    <fieldset style="display: none">
        <legend>Report Type</legend>
        <table id="Table6" cellpadding="2" cellspacing="0" width="99%">
            <tr>
                <td align="left" colspan="2">
                   Report Type:
                    <telerik:RadComboBox ID="DropDownListReportType" runat="server" AutoPostBack="True" Width="300px" SkinID="RadComboBoxStandard">
                        <Items>
                            <telerik:RadComboBoxItem Value="2" Text="002 - Calendar Month View (Standard)" Selected="True"></telerik:RadComboBoxItem>
                       </Items>
                    </telerik:RadComboBox>
                </td>
            </tr>
        </table>
    </fieldset>
    <fieldset>
        <legend>Location ID</legend>
        <table id="Table5" cellpadding="2" cellspacing="0" width="99%">
            <tr>
                <td align="left" valign="top">
                   Location ID:
                    <telerik:RadComboBox ID="ddLocation" runat="server"  Width="500px" SkinID="RadComboBoxStandard">
                    </telerik:RadComboBox>
                </td>
            </tr>
        </table>
    </fieldset>
    <fieldset>
        <legend>Report Title and Placement</legend>
        <table id="Table7" cellpadding="2" cellspacing="0" width="99%">
            <tr style="width: 40%">
                <td align="left" colspan="2">
                   Title:
                    <asp:TextBox ID="TBTitle" runat="server" Width="70%" MaxLength="60" SkinID="TextBoxStandard">Calendar Report</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 5%">
                    &nbsp;
                </td>
                <td align="left" style="width: 95%">
                    <asp:RadioButtonList ID="rbplacement" runat="server"  
                        RepeatColumns="3">
                        <asp:ListItem Selected="True" Value="left">Left</asp:ListItem>
                        <asp:ListItem Value="right">Right</asp:ListItem>
                        <asp:ListItem Value="center">Center</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
        </table>
    </fieldset>
    <div>
        <div style="width: 50%; float: left;">
            <fieldset runat="server" id="FieldsetGroupBy">
                <legend>Group by</legend>
                <table cellpadding="2" cellspacing="0" width="99%">
                    <tr>
                        <td align="left" colspan="4">
                            <asp:RadioButtonList ID="RBGroup" runat="server"  RepeatColumns="1"
                                AutoPostBack="True" CellPadding="1" >
                                <asp:ListItem Selected="True" Value="None"></asp:ListItem>
                                <asp:ListItem Value="Client"></asp:ListItem>
                                <asp:ListItem Value="Client/Division"></asp:ListItem>
                                <asp:ListItem Value="Client/Division/Product"></asp:ListItem>
                                <asp:ListItem Value="Job"></asp:ListItem>
                                <asp:ListItem Value="Job/Component"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                </table>
            </fieldset>
        </div>
        <div style="width: 50%; float: left;">
            <fieldset>
                <legend>Include Options</legend>
                <table id="Table9" cellpadding="2" cellspacing="0" width="99%">
                    <tr style="vertical-align: top">
                        <td align="left">
                            <asp:CheckBox ID="chkSchClient" runat="server" Checked="false" Enabled="false" Text="Schedule Comment" />
                            <br />
                            <asp:CheckBox ID="chkStatus" runat="server" Checked="false" Enabled="false" Text="Status" />
                            <br />
                            <asp:CheckBox ID="chkTasks" runat="server" Checked="true" Text="Include Tasks" />
                            <br />
                            <asp:CheckBox ID="chkAssignments" runat="server" Checked="true" Text="Include Assignments" />
                            <br />
                            <asp:CheckBox ID="chkHolidays" runat="server" Checked="false" Text="Include Holidays" />
                            <br />
                            <asp:CheckBox ID="chkAppts" runat="server" Checked="false" Text="Include Appointments" />
                            <br />
                            <asp:CheckBox ID="chkEvents" runat="server" Checked="false" Text="Include Events" Visible="false" />
                            <br />
                            <asp:CheckBox ID="chkEventTasks" runat="server" Checked="false" Text="Include Event Tasks" Visible="false" />
                            <br />
                        </td>
                    </tr>
                </table>
            </fieldset>
        </div>
    </div>   
    
    <fieldset style="clear: both;" class="table-fixes">
        <legend>Month/Year</legend>
        <table >
            <tr style="vertical-align: top">
                <td align="right">
                    <asp:Label   ID="Label2" TabIndex="0" runat="server" Text="Start Month:">  
                    </asp:Label>
                </td>
                <td align="left">
                    <telerik:RadComboBox ID="ddStartMonth" runat="server" SkinID="RadComboBoxStandard">
                    </telerik:RadComboBox>
                </td>
                <td align="right">
                    <asp:Label   ID="Label3" TabIndex="0" runat="server" Text="Year:">  
                    </asp:Label>
                </td>
                <td align="left">
                    <telerik:RadComboBox ID="ddStartYear" runat="server" SkinID="RadComboBoxStandard">
                    </telerik:RadComboBox>
                </td>
            </tr>
            <tr style="vertical-align: top">
                <td align="right">
                    <asp:Label   ID="Label4" TabIndex="0" runat="server" Text="End Month:">  </asp:Label>
                </td>
                <td align="left">
                    <telerik:RadComboBox ID="ddEndMonth" runat="server" SkinID="RadComboBoxStandard">
                    </telerik:RadComboBox>
                </td>
                <td align="right">
                    <asp:Label   ID="Label5" TabIndex="0" runat="server" Text="Year:">  </asp:Label>
                </td>
                <td align="left">
                    <telerik:RadComboBox ID="ddEndYear" runat="server" SkinID="RadComboBoxStandard">
                    </telerik:RadComboBox>
                    <br />
                    <br />
                </td>
            </tr>
        </table>
    </fieldset>
    <table width="95%" align="center">
        <tr>
            <td align="center" colspan="8" valign="middle">
                <br />
                <asp:Button ID="btnSubmit" runat="server" Text="View" /><br />
                <br />
                <DayPilot:DayPilotMonth ID="DayPilotMonthReport" runat="server" EventStackingMode="Row"
                    ClientObjectName="dpm" DataEndField="END_DATE" DataStartField="START_DATE" DataTagFields="TASK_NON_TASK_DISPLAY, DATA_KEY"
                    DataTextField="TASK_NON_TASK_DISPLAY" DataValueField="DATA_KEY" EventClickHandling="JavaScript"
                    EventClickJavaScript="openDetailWindow(e.value());" EventFontSize="9px" EventHeight="18"
                    EventDoubleClickHandling="JavaScript" EventDoubleClickJavaScript="openDetailWindow(e.value());"
                    EventMoveHandling="PostBack" EventResizeHandling="PostBack" OnBeforeEventRender="DayPilotMonthReport_BeforeEventRender"
                    OnTimeRangeSelected="DayPilotMonthReport_TimeRangeSelected" EventStartTime="false"
                    EventEndTime="false" ShowToolTip="False" TimeRangeSelectedHandling="PostBack"
                    EventSortExpression="CUSTOM_SORT" Width="100%" Visible="false" />
                <asp:HiddenField ID="HfTodayForeColor" runat="server" Value="#FF0000" />
                <asp:HiddenField ID="HfHolidayBackColor" runat="server" Value="#FFC68C" />
                <asp:HiddenField ID="HfAppointmentBackColor" runat="server" Value="#C1E0FF" />
                <asp:HiddenField ID="HfAppointmentAllDayBackColor" runat="server" Value="#C1E0FF" />
                <asp:HiddenField ID="HfTaskBackColor" runat="server" Value="#DDEECC" />
                <asp:HiddenField ID="HfDefaultEventColor" runat="server" Value="" />
                <asp:HiddenField ID="HfDefaultEventTaskColor" runat="server" Value="#BD9DFF" />
            </td>
        </tr>
    </table>
</asp:Content>
