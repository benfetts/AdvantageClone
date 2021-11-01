<%@ Page Title="Print Calendar" Language="vb" AutoEventWireup="false" CodeBehind="Calendar_Print.aspx.vb"
    MasterPageFile="~/ChildPage.Master" Inherits="Webvantage.Calendar_Print" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="Print_Buttons.ascx" TagName="Print_Buttons" TagPrefix="webvantage" %>
<%@ Register Assembly="DayPilot" Namespace="DayPilot.Web.Ui" TagPrefix="DayPilot" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <telerik:RadScriptBlock ID="RadScriptBlockRadWindow" runat="server">
        <script type="text/javascript">
            function printWindow() {
                window.print();
            };
        </script>
    </telerik:RadScriptBlock>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <table width="955px">
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td runat="server" id="trTitle" >
                <asp:Label ID="LabelTitle" runat="server" Font-Size="X-Large" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center" valign="middle" width="955px">
                <telerik:RadBinaryImage ID="RadBinaryImageScreenShot" runat="server" AutoAdjustImageControlSize="false"
                    Width="955px" Height="710px" />
            </td>
        </tr>
        <DayPilot:DayPilotMonth ID="DayPilotMonthExport" runat="server" EventStackingMode="Row"
                                                    ClientObjectName="dpm" DataEndField="END_DATE" DataStartField="START_DATE" DataTagFields="TASK_NON_TASK_DISPLAY, DATA_KEY"
                                                    DataTextField="TASK_NON_TASK_DISPLAY" DataValueField="DATA_KEY" EventClickHandling="JavaScript"
                                                    EventClickJavaScript="openDetailWindow(e.value());" EventFontSize="7px" EventHeight="36"
                                                    EventDoubleClickHandling="JavaScript" EventDoubleClickJavaScript="openDetailWindow(e.value());"
                                                    EventMoveHandling="PostBack" EventResizeHandling="PostBack" OnBeforeCellRender="DayPilotMonth1_BeforeCellRender"
                                                    OnBeforeEventRender="DayPilotMonth1_BeforeEventRender" OnBeforeHeaderRender="DayPilotMonth1_BeforeHeaderRender"
                                                    OnEventMenuClick="DayPilotCalendar1_EventMenuClick" OnEventMove="DayPilotMonth1_EventMove"
                                                    OnEventResize="DayPilotMonth1_EventResize" 
                                                    EventStartTime="false" EventEndTime="false" ShowToolTip="False" TimeRangeSelectedHandling="PostBack"
                                                    EventSortExpression="CUSTOM_SORT" Width="100%" Visible="false" />                                        
                                                <asp:HiddenField ID="HfWeekendBackColor" runat="server" Value="" />
                                                <asp:HiddenField ID="HfWeekdayBackColor" runat="server" Value="" />
                                                <asp:HiddenField ID="HfTodayBackColor" runat="server" Value="" />
                                                <asp:HiddenField ID="HfTodayHeaderBold" runat="server" Value="True" />
                                                <asp:HiddenField ID="HfTodayForeColor" runat="server" Value="#FF0000" />
                                                <asp:HiddenField ID="HfHolidayBackColor" runat="server" Value="#FFC68C" />
                                                <asp:HiddenField ID="HfAppointmentBackColor" runat="server" Value="#C1E0FF" />
                                                <asp:HiddenField ID="HfAppointmentAllDayBackColor" runat="server" Value="#C1E0FF" />
                                                <asp:HiddenField ID="HfTaskBackColor" runat="server" Value="#DDEECC" />
                                                <asp:HiddenField ID="HfBoldSelectedDate" runat="server" Value="False" />
                                                <asp:HiddenField ID="HfShowSelectedDateImage" runat="server" Value="True" />
                                                <asp:HiddenField ID="HfDefaultEventColor" runat="server" Value="" />
                                                <asp:HiddenField ID="HfDefaultEventTaskColor" runat="server" Value="#BD9DFF" />
    </table>
</asp:Content>

