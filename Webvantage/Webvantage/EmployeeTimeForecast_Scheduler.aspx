<%@ Page Title="ETF Scheduler" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="EmployeeTimeForecast_Scheduler.aspx.vb" Inherits="Webvantage.EmployeeTimeForecast_Scheduler" %>

<%@ Register Assembly="DayPilot" Namespace="DayPilot.Web.Ui" TagPrefix="DayPilot" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="ContentScheduler" ContentPlaceHolderID="ContentPlaceHolderMain"
    runat="server">
    <telerik:RadScriptBlock ID="RadScriptBlock" runat="server">
        <script type="text/javascript">
            function RefreshPage(radWindowCaller) {
                __doPostBack('onclick#Refresh', 'Refresh');
            };
            function SaveFromPopUp(radWindowCaller) {
                __doPostBack('onclick#Save', 'Save');
            };
            function RealPostBack(eventTarget, eventArgument) {
                __doPostBack(eventTarget, eventArgument);
            };
            function HidePopUpWindows(radWindowCaller) {
                __doPostBack('onclick#Refresh', 'HidePopups');
            };
            function OnClientClose(sender, EventArgs) {
                __doPostBack('onclick#Refresh', 'Refresh');
            };
        </script>
    </telerik:RadScriptBlock>
    <table align="center" border="0" cellpadding="0" cellspacing="0" 
        width="100%">
        <tr class="ContentHeader">
            <td align="left" class=" ContentHeaderText" valign="middle"
                colspan="2">
                &nbsp;&nbsp;Scheduler
            </td>
        </tr>
        <tr>
            <td runat="Server" id="TdRadToolbarScheduler" align="left" valign="top" colspan="2">
                <telerik:RadToolbar ID="RadToolbarScheduler" runat="server" AutoPostBack="True" Width="100%">
                    <Items>
                        <telerik:RadToolBarButton IsSeparator="true" />
                        <telerik:RadToolBarButton SkinID="RadToolBarButtonNew"
                            Text="Create" Value="Create"
                            />
                        <telerik:RadToolBarButton IsSeparator="true" />
                    </Items>
                </telerik:RadToolbar>
            </td>
        </tr>
        <tr>
            <td colspan="2">
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                    <table align="center" border="0" cellpadding="0" cellspacing="0" 
                        width="100%">
                        <tr>
                            <td width="1%">
                                &nbsp;
                            </td>
                            <td>
                                <br />
                                <table width="99%" border="0" cellspacing="2" cellpadding="0">
                                    <tr>
                                        <td align="left" valign="bottom" width="50px">
                                           Job
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="bottom" width="250px">
                                            <telerik:RadComboBox ID="DropDownListJob" runat="server" AutoPostBack="true" Width="300px" SkinID="RadComboBoxStandard"
                                                DataTextField="Description" DataValueField="Number" >
                                            </telerik:RadComboBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td width="1%">
                                &nbsp;
                            </td>
                            <td>
                                <br />
                                <asp:CheckBox runat="server" ID="CheckBoxShowDescription" AutoPostBack="false" Text="Show Description"
                                    Checked="true" Width="100%" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <table id="Table4" align="center" cellpadding="0" cellspacing="0" width="100%">
                                            <tr class="ContentHeader ContentHeaderText">
                                                <td align="center"  width="15%">
                                                    <asp:ImageButton ID="butPrevYear" runat="server" AlternateText="Previous Year" SkinID="ImageButtonNext" />
                                                    &nbsp;
                                                    <asp:ImageButton ID="butPrevMonth" runat="server" AlternateText="Previous Month"
                                                        CausesValidation="False" SkinID="ImageButtonPrevious" />
                                                </td>
                                                <td align="center" nowrap="nowrap"  width="70%">
                                                    Month:
                                                    <telerik:RadComboBox ID="ddMonth" runat="server" AutoPostBack="True" SkinID="RadComboBoxMonth">
                                                    </telerik:RadComboBox>
                                                    &nbsp;&nbsp;Year:
                                                    <telerik:RadComboBox ID="ddYear" runat="server" AutoPostBack="True" SkinID="RadComboBoxYear">
                                                    </telerik:RadComboBox>
                                                    &nbsp;&nbsp;
                                                    <asp:ImageButton ID="imgbtnRefresh" runat="server" SkinID="ImageButtonRefresh" />
                                                </td>
                                                <td align="center"   width="15%">
                                                    <asp:ImageButton ID="butNextMonth" runat="server" AlternateText="Next Month" 
                                                        ImageAlign="AbsMiddle" ImageUrl="~/Images/navigate_right-trans.png"  />
                                                    &nbsp;
                                                    <asp:ImageButton ID="butNextYear" runat="server" AlternateText="Next Year" CausesValidation="False"
                                                         ImageAlign="AbsMiddle" ImageUrl="~/Images/navigate_right2-trans.png"
                                                         />
                                                </td>
                                            </tr>
                                        </table>
                                        <table id="Table5" align="center" cellpadding="0" cellspacing="0" width="100%">
                                            <tr>
                                                <td>
                                                    <DayPilot:DayPilotMonth ID="DayPilotMonth1" runat="server" BubbleID="DayPilotBubble1"
                                                        EventStackingMode="Row" ClientObjectName="dpm" DataEndField="DueDate" DataStartField="StartDate"
                                                        DataTagFields="Description, ID" DataTextField="Description"
                                                        DataValueField="ID" EventClickHandling="JavaScript" EventClickJavaScript="openDetailWindow(e.value());"
                                                        EventFontSize="9px" EventHeight="18" EventDoubleClickHandling="JavaScript" EventDoubleClickJavaScript="openDetailWindow(e.value());"
                                                        EventMoveHandling="PostBack" EventResizeHandling="PostBack"
                                                        EventStartTime="false" EventEndTime="false" ShowToolTip="False" TimeRangeSelectedHandling="PostBack" Width="100%"  StartDate="12/01/2010"/>
                                                    <DayPilot:DayPilotBubble ID="DayPilotBubble1" runat="server" ClientObjectName="bubble" UseShadow="True" Width="325">
                                                    </DayPilot:DayPilotBubble>
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
                                                </td>
                                            </tr>
                                        </table>
                                        <asp:CheckBox ID="ChkEventStackingMode" runat="server" AutoPostBack="true" Text="Cell mode"
                                            Visible="false" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <telerik:RadBinaryImage ID="RadBinaryImageScreenShot" runat="server" />
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
