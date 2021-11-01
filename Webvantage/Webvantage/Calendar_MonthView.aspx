<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="Calendar_MonthView.aspx.vb" Inherits="Webvantage.Calendar_MonthView" EnableViewState="true" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">

    <telerik:RadScriptBlock ID="RadScriptBlock" runat="server">
        <style type="text/css">
            div[id*="RadGridAvailability"].RadGrid_Bootstrap th:nth-of-type(n+8), div[id*="RadGridAvailability"].RadGrid_Bootstrap td:nth-of-type(n+8) {
                min-width: 50px !important;
                width: 50px !important;
            }
            div[id*="RadGridAvailability"].RadGrid_Metro th:nth-of-type(n+8), div[id*="RadGridAvailability"].RadGrid_Metro td:nth-of-type(n+8) {
                min-width: 40px !important;
                width: 40px !important;
            }
            html {
                overflow: hidden !important;
            }

            .RadScheduler .rsAllDayRow {
                /*height: 93px !important;*/
                padding-top: 5px !important;

            }

            .RadScheduler .rsAllDayHeader {
                padding-top: 5px !important;

            }

            .RadForm.rfdRadio.rfdLabel label, .RadForm.rfdCheckbox.rfdLabel label {
                margin-bottom: 5px !important;
            }
            
        </style>
        <script type="text/javascript">
            function RefreshPage(radWindowCaller) {
                setTimeout(function () {
                   __doPostBack('onclick#Refresh', 'Refresh');
                }, 0);                 
            };
            function SaveFromPopUp(radWindowCaller) {
                setTimeout(function () {
                   __doPostBack('onclick#Save', 'Save');
                }, 0);                                 
            };
            function RealPostBack(eventTarget, eventArgument) {
                setTimeout(function () {
                   __doPostBack(eventTarget, eventArgument);
                }, 0);   
            };
            function HidePopUpWindows(radWindowCaller) {
                setTimeout(function () {
                   __doPostBack('onclick#Refresh', 'HidePopups');
                }, 0);   
            };
            function OnClientClose(sender, EventArgs) {
                setTimeout(function () {
                   __doPostBack('onclick#Refresh', 'Refresh');
                }, 0);                   
            };

        </script>
        <script type="text/javascript">

            function JSOnClientApptContextMenuItemClicked(sender, args) {
                var comandName = args.get_item().get_value();

                if (comandName == "Calculate") {
                    args.set_cancel(!confirm('All jobs associated with this job will be calculated.  Are you sure you want to calculate?'));
                    ////radToolBarConfirm(sender, args, "All jobs associated with this job will be calculated.  Are you sure you want to calculate?");
                }
                if (comandName == "CommandDelete") {
                    args.set_cancel(!confirm('Are you sure you want to delete this appointment?'));
                    ////radToolBarConfirm(sender, args, "Are you sure you want to delete this appointment?");
                }
            }


            Telerik.Web.UI.RadScheduler.prototype._openReminderItemClicked = function (sender, eventArgs) {

                var reminder = eventArgs.get_reminders();
                var appt = reminder[0].get_owner();
                var desc = appt.get_description().toString();
                var s = desc.split('|');
                OpenRadWindow('Activity', 'Calendar_NewActivity.aspx?TaskNo=' + s[7], 1000, 1300, false);
                //this._hideReminderDialog();
            };


            function ClientAppointmentDeleting(sender, args) {
                var app = args.get_appointment();
                var desc = app.get_description().toString();
                var s = desc.split('|');
                //if (app.get_attributes().getAttribute("Delete") != null) {
                if (s[14] != ' ' || s[15] != 0) {
                    OpenRadWindow('', 'Calendar_AppointmentCheck.aspx?TaskNo=' + s[7] + '&state=delete', 200, 400, true);
                }
                else {
                    if (confirm("Are you sure you want to delete this appointment?")) {
                        //alert("now the appointment will be deleted");
                    }
                    else {
                        args.set_cancel(true);
                    }
                }

                // }
            }
        
            
        </script>
    </telerik:RadScriptBlock>
    <div id="calendar-container-old" class="telerik-aqua-body" style="margin-top: 5px!important;">
        <telerik:RadTabStrip ID="RadTabStripTaskCalendar" runat="server" AutoPostBack="true" MultiPageID="RadMultiPageCalendar"
            Orientation="HorizontalTop" CausesValidation="false"
            Width="100%">
            <Tabs>
                <telerik:RadTab Text="Calendar" PageViewID="RadPageViewCalendar" Value="0">
                </telerik:RadTab>
                <telerik:RadTab Text="List View" PageViewID="RadPageViewListView" Value="1">
                </telerik:RadTab>
                <telerik:RadTab Text="Workload" PageViewID="RadPageViewWorkload" Value="2">
                </telerik:RadTab>
                <telerik:RadTab Text="Availability" PageViewID="RadPageViewAvailability" Value="3" Visible="False">
                </telerik:RadTab>
                <telerik:RadTab Text="Availability" PageViewID="RadPageViewActualization" Value="7">
                </telerik:RadTab>
                <telerik:RadTab Text="Allocation" PageViewID="RadPageViewAllocation" Value="6">
                </telerik:RadTab>
                <telerik:RadTab Text="Filter" PageViewID="RadPageViewFilter" Value="4">
                </telerik:RadTab>
                <telerik:RadTab Text="Report" PageViewID="RadPageViewReport" Value="5">
                </telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>
        <telerik:RadMultiPage ID="RadMultiPageCalendar" runat="server" SelectedIndex="0">
            <telerik:RadPageView ID="RadPageViewCalendar" runat="server">                
                <telerik:RadScriptBlock ID="RadScriptBlock3" runat="server">
                    <script type="text/javascript">
                        function JsOnClientButtonClicking(sender, args) {
                            var commandName = args.get_item().get_commandName();
                            switch (commandName) {
                                case "NoPostBack":
                                    args.set_cancel(true);
                                    break;
                                case "IncludeTooltip":
                                    var tooltip = $find("ctl00_ContentPlaceHolderMain_RadToolTipIncludeItems");
                                    if (tooltip) {
                                        tooltip.show();
                                    }
                                    args.set_cancel(true);
                                    break;
                                case "ExportCalendar":
                                    disableAjax = true;
                                    break;
                            }
                        };
                    </script>
                </telerik:RadScriptBlock>    

            <asp:UpdatePanel runat="server" ID="UpdatePanel3" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>				
                    <div class="calendar-toolbar">
                        <telerik:RadToolBar ID="RadToolbarCalendar" runat="server" Width="100%" EnableViewState="true" OnClientButtonClicking="JsOnClientButtonClicking" CssClass="RadToolBar_Metro" AutoPostBack="true">
                            <Items>
                                <telerik:RadToolBarButton ID="RadToolBarButtonNew" SkinID="RadToolBarButtonNew" Text="New"
                                    Value="NewTask" />
                                <telerik:RadToolBarButton IsSeparator="true" />
                                <telerik:RadToolBarButton Value="RadToolBarButtonIncludeTooltip" Text="Include" CommandName="IncludeTooltip">
                                </telerik:RadToolBarButton>
                                <telerik:RadToolBarButton IsSeparator="true" />
                                <telerik:RadToolBarButton ID="RadToolBarButtonGroupBy"
                                    Group="GroupBy" Text="Group by Employee" Value="GroupBy" AllowSelfUnCheck="true"
                                    CheckOnClick="false" Visible="false" />
                                <telerik:RadToolBarButton ID="RadToolBarButtonDuration"
                                    Group="Duration" Text="Due Date View" Value="Duration" AllowSelfUnCheck="true"
                                    CheckOnClick="false" />
                                <telerik:RadToolBarButton IsSeparator="true" />
                                <telerik:RadToolBarButton>
                                    <ItemTemplate>
                                        &nbsp;&nbsp;Visible Appointments:&nbsp;
                                    </ItemTemplate>
                                </telerik:RadToolBarButton>
                                <telerik:RadToolBarButton Value="RadToolBarButtonTxtAssignments">
                                    <ItemTemplate>
                                        <asp:TextBox ID="TextboxAssignments" runat="server" AutoPostBack="true" Width="30px" SkinID="TextBoxStandard" />
                                    </ItemTemplate>
                                </telerik:RadToolBarButton>
                                <telerik:RadToolBarButton ID="RadToolBarButtonExport" Text="ICS"
                                    Value="ExportCalendar" CommandName="ExportCalendar" ToolTip="Export Calendar" />
                                <telerik:RadToolBarButton IsSeparator="true" />
                                <telerik:RadToolBarButton ID="RadToolBarButtonPrint" SkinID="RadToolBarButtonPrint"
                                    Value="PrintCalendar" ToolTip="Print Calendar" Visible="true" />
                                <telerik:RadToolBarButton IsSeparator="true" Visible="false" />
                                <telerik:RadToolBarButton ID="RadToolBarButtonPdf" Text="PDF" Value="ExportPDF" ToolTip="Export Calendar to PDF" Visible="false" />
                                <telerik:RadToolBarButton ID="RadToolBarButtonRefresh" SkinID="RadToolBarButtonRefresh"
                                    Value="RefreshCalendar" ToolTip="Refresh Calendar" />
                                <telerik:RadToolBarButton SkinID="RadToolBarButtonBookmark" Text="Bookmark" Value="Bookmark" ToolTip="Bookmark" />
                                <telerik:RadToolBarButton IsSeparator="true" />
                            </Items>
                        </telerik:RadToolBar>  
                    </div>                
                    <telerik:RadToolTip ID="RadToolTipIncludeItems" runat="server" SkinID="RadToolTipToolbarContentArea" Width="350" Height="220" TargetControlID="RadToolBarButtonIncludeTooltip">
                        <div style="width: 410px; float: left; position: relative;">
                            <div style="font-size: larger;">
                                Include these things on the calendar
                            </div>
                            <div>
                <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                    <ContentTemplate>
                                    <div style="padding: 11px 0px 0px 0px;">
                                        <asp:CheckBox ID="CheckBoxIncludeTasks" runat="server" Text="Tasks" AutoPostBack="true" />
                                    </div>
                                    <div style="padding: 11px 0px 0px 0px;">
                                        <asp:CheckBox ID="CheckBoxIncludeAssignments" runat="server" Text="Assignments" AutoPostBack="true" />
                                    </div>
                                    <div style="padding: 6px 0px 0px 0px;">
                                        <asp:CheckBox ID="CheckBoxIncludeHolidays" runat="server" Text="Holidays" AutoPostBack="true" />
                                    </div>
                                    <div style="padding: 6px 0px 0px 0px;">
                                        <asp:CheckBox ID="CheckBoxIncludeAppointments" runat="server" Text="Appointments" AutoPostBack="true" />
                                    </div>
                                    <div style="padding: 6px 0px 0px 0px;">
                                        <asp:CheckBox ID="CheckBoxIncludeEvents" runat="server" Text="Events" AutoPostBack="true" Visible="false" />
                                    </div>
                                    <div style="padding: 6px 0px 0px 0px;">
                                        <asp:CheckBox ID="CheckBoxIncludeEventTasks" runat="server" Text="Event Tasks" AutoPostBack="true" Visible="false" />
                                    </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                            </div>
                        </div>
                    </telerik:RadToolTip>        
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="RadToolbarCalendar" />
                    <asp:PostBackTrigger ControlID="CheckBoxIncludeTasks"/>
                    <asp:PostBackTrigger ControlID="CheckBoxIncludeAssignments"/>
                    <asp:PostBackTrigger ControlID="CheckBoxIncludeHolidays"/>
                    <asp:PostBackTrigger ControlID="CheckBoxIncludeAppointments"/>
                </Triggers>
            </asp:UpdatePanel>

                <div style="width:100%;text-align:center;padding:8px 0px 0px 8px;">
                    <style>
                        .normal-emp-label {
                            font-weight: normal !important;
                            font-size: 14px !important;
                        }
                   </style>
                    <telerik:RadScheduler ID="RadSchedulerProjectSchedule" runat="server" DataEndField="END_DATE" DataStartField="START_DATE"
                        DataKeyField="ID" DataSubjectField="JOB_NUMBER" AppointmentStyleMode="Default" DisplayDeleteConfirmation="false"
                        OverflowBehavior="Expand" AllowDelete="False" Localization-HeaderMultiDay="Resource" OnClientAppointmentDeleting="ClientAppointmentDeleting"
                        StartInsertingInAdvancedForm="false" ExportSettings-OpenInNewWindow="True" DataReminderField="REMINDER"
                        ToolTip='' TimeSlotContextMenuSettings-EnableEmbeddedSkins="False" ViewStateMode="Enabled"
                        OnClientAppointmentContextMenuItemClicking="JSOnClientApptContextMenuItemClicked" Width="99%"
                        Reminders-Enabled="True" StartEditingInAdvancedForm="false" EnableRecurrenceSupport="False">
                        <MultiDayView NumberOfDays="10" />
                        <TimelineView NumberOfSlots="14" ShowDateHeaders="True" ShowResourceHeaders="True" />
                        <MonthView VisibleAppointmentsPerDay="5" AdaptiveRowHeight="false" />
                        <AdvancedForm Modal="true"></AdvancedForm>
                        <ResourceHeaderTemplate>
                            <asp:Panel ID="ResourceImageWrapperEmp" runat="server">
                                <div style="text-align: center; vertical-align: middle; width: 50px; padding: 8px 0px 2px 7px;">
                                    <dx:ASPxBinaryImage ID="ASPxBinaryImageEmp" runat="server" BinaryStorageMode="Session" CssClass="wv-employee-img-thumbnail-lg" >
                                    </dx:ASPxBinaryImage>
                                    <dx:ASPxImage ID="ASPxImageEmp" runat="server" ImageUrl="Images/Icons/Grey/256/user.png" CssClass="wv-employee-img-thumbnail-lg" Visible="false">
                                    </dx:ASPxImage>
                                    <div style="text-align: center; vertical-align: middle; width: 100%;display: block;">
                                        <asp:Label ID="LabelEmployee" runat="server" CssClass="normal-emp-label"></asp:Label>
                                    </div>
                                </div>
                            </asp:Panel>
                            <asp:Panel ID="ResourceImageWrapperJob" runat="server" Width="100px" HorizontalAlign="center">
                                <div style="width: 99%; vertical-align: middle; text-align: center;">
                                    <asp:Label ID="LabelJob" runat="server" Width="90px"></asp:Label>
                                </div>
                            </asp:Panel>
                        </ResourceHeaderTemplate>
                        <ResourceStyles>
                            <telerik:ResourceStyleMapping Type="Type" Text="TA"
                                BorderColor="#76D276" /> 
                            <telerik:ResourceStyleMapping Type="Type" Text="TP"
                                BorderColor="#808080" ApplyCssClass="calendar-task-pending-calendar" />
                            <telerik:ResourceStyleMapping Type="Type" Text="TN"
                                BorderColor="#808080" />
                            <telerik:ResourceStyleMapping Type="Type" Text="TD"
                                BorderColor="#AEAEAE" />
                            <telerik:ResourceStyleMapping Type="Type" Text="M"
                                BorderColor="#F5C7A1" />
                            <telerik:ResourceStyleMapping Type="Type" Text="C"
                                BorderColor="#FF982E" />
                            <telerik:ResourceStyleMapping Type="Type" Text="A"
                                BorderColor="#17A2B8" />
                            <telerik:ResourceStyleMapping Type="Type" Text="H"
                                BorderColor="#FD7E14" />
                            <telerik:ResourceStyleMapping Type="Type" Text="E"
                                BorderColor="#E83E8C" />
                            <telerik:ResourceStyleMapping Type="Type" Text="ET"
                                BorderColor="#DC3545" />
                            <telerik:ResourceStyleMapping Type="Type" Text="EL"
                                BorderColor="#E46500" />
                            <telerik:ResourceStyleMapping Type="Type" Text="AS"
                                BorderColor="#4B7D70" />
                            <telerik:ResourceStyleMapping Type="Type" Text="ASO"
                                BorderColor="#76B9B9" />
                        </ResourceStyles>
                        <AppointmentContextMenus>
                            <telerik:RadSchedulerContextMenu runat="server" ID="SchedulerAppointmentContextMenuTask">
                                <Items>
                                    <telerik:RadMenuItem Text="Edit" Value="Edit" />
                                    <telerik:RadMenuItem IsSeparator="True" />
                                    <telerik:RadMenuItem Text="Edit Assignee" Value="EditAssignment" />
                                    <telerik:RadMenuItem IsSeparator="True" />
                                    <telerik:RadMenuItem Text="Calculate Schedule" Value="Calculate" />
                                    <telerik:RadMenuItem IsSeparator="True" />
                                    <telerik:RadMenuItem Text="Go to Job" Value="JC" />
                                    <telerik:RadMenuItem IsSeparator="True" />
                                    <telerik:RadMenuItem Text="Go to Schedule" Value="PS" />
                                </Items>
                            </telerik:RadSchedulerContextMenu>
                            <telerik:RadSchedulerContextMenu runat="server" ID="SchedulerAppointmentContextMenu">
                                <Items>
                                    <telerik:RadMenuItem Text="Edit" Value="Edit" />
                                    <telerik:RadMenuItem IsSeparator="True" />
                                    <telerik:RadMenuItem Text="Delete" Value="CommandDelete" />
                                </Items>
                            </telerik:RadSchedulerContextMenu>
                            <telerik:RadSchedulerContextMenu runat="server" ID="SchedulerAppointmentContextMenuDisabled">
                                <Items>
                                    <telerik:RadMenuItem Text="Edit" Value="Edit" Enabled="false" />
                                    <telerik:RadMenuItem IsSeparator="True" />
                                    <telerik:RadMenuItem Text="Delete" Value="CommandDelete" Enabled="false" />
                                </Items>
                            </telerik:RadSchedulerContextMenu>
                            <telerik:RadSchedulerContextMenu runat="server" ID="RadSchedulerContextMenuAssignment">
                                <Items>
                                    <telerik:RadMenuItem Text="Edit Assignment" Value="Edit" />
                                    <telerik:RadMenuItem IsSeparator="True" />
                                    <telerik:RadMenuItem Text="Go to Job" Value="JC" />
                                    <telerik:RadMenuItem IsSeparator="True" />
                                    <telerik:RadMenuItem Text="Go to Schedule" Value="PS" />
                                </Items>
                            </telerik:RadSchedulerContextMenu>
                            <telerik:RadSchedulerContextMenu runat="server" ID="RadSchedulerContextMenuOfficeAssignment">
                                <Items>
                                    <telerik:RadMenuItem Text="Edit" Value="Edit" />
                                    <telerik:RadMenuItem IsSeparator="True" />
                                </Items>
                            </telerik:RadSchedulerContextMenu>
                            <telerik:RadSchedulerContextMenu runat="server" ID="RadSchedulerContextMenuAssignmentNoJob">
                                <Items>
                                    <telerik:RadMenuItem Text="Edit" Value="Edit" />
                                    <telerik:RadMenuItem IsSeparator="True" />
                                </Items>
                            </telerik:RadSchedulerContextMenu>
                        </AppointmentContextMenus>
                        <TimeSlotContextMenus>
                            <telerik:RadSchedulerContextMenu>
                                <Items>
                                    <telerik:RadMenuItem Text="New Activity" Value="CommandAddAppointment" />
                                    <telerik:RadMenuItem Text="Go to today" Value="CommandGoToToday" />
                                </Items>
                            </telerik:RadSchedulerContextMenu>
                        </TimeSlotContextMenus>
                        <TimeSlotContextMenuSettings EnableDefault="true" />
                        <AppointmentContextMenuSettings EnableDefault="true" />
                        <ExportSettings OpenInNewWindow="True" FileName="SchedulerExport">
                            <Pdf PageTitle="Schedule" Author="Telerik" Creator="Telerik" Title="Schedule" />
                        </ExportSettings>
                    </telerik:RadScheduler>
                </div>            
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
                <telerik:RadWindowManager ID="RadWindowManagerCalendar" runat="server" EnableViewState="false" IconUrl="~/Images/blank.ico">
                    <Windows>
                    </Windows>
                </telerik:RadWindowManager>
                    <%-- <asp:GridView ID="GridViewData" runat="server" AutoGenerateColumns="True">
                    </asp:GridView>
                    <asp:GridView ID="GridViewEmp" runat="server" AutoGenerateColumns="True">
                    </asp:GridView>   --%>
            </telerik:RadPageView>
            <telerik:RadPageView ID="RadPageViewListView" runat="server">
                <asp:Panel ID="PanelTasks" runat="server">
                    <div class="CollapsablePanel-Wrap">
                        <ew:CollapsablePanel ID="CollapsablePanelListViewTasks" runat="server" TitleText="Tasks/Assignments">
                            <telerik:RadButton ID="RadButtonListViewTasksRefresh" runat="server" Text="Refresh"></telerik:RadButton>
                            <asp:ImageButton ID="ImageButtonListView" runat="server" SkinID="ImageButtonExportExcel" />
                            <div style="padding:4px 0px 0px 0px;">
                                <telerik:RadGrid ID="RadGridTasks" runat="server" AllowSorting="true"
                                    Width="100%" AutoGenerateColumns="False" ShowFooter="false" EnableEmbeddedSkins="True"
                                    Visible="true">
                                    <MasterTableView AllowMultiColumnSorting="True" DataKeyNames="DATA_KEY,CL_CODE,DIV_CODE,PRD_CODE,ALL_DAY,NUM_DAYS,HAS_TIME,START_TIME,END_TIME,ALERT_ID,SPRINT_ID,REC_TYPE"
                                        NoMasterRecordsText="No records to display">
                                        <Columns>
                                            <telerik:GridTemplateColumn UniqueName="colDetails">
                                                <HeaderStyle CssClass="radgrid-icon-column" />
                                                <ItemStyle CssClass="radgrid-icon-column" />
                                                <FooterStyle CssClass="radgrid-icon-column" />
                                                <HeaderTemplate>
                                                    &nbsp;
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <div class="icon-background background-color-sidebar">
                                                        <asp:ImageButton ID="imgbtnDetailTasks" runat="server" AlternateText="Open Detail"
                                                            CommandArgument='<%#Eval("DATA_KEY")%>' CommandName="DetailRow" SkinID="ImageButtonViewWhite" />
                                                    </div>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridBoundColumn DataField="CL_NAME" HeaderText="Client" UniqueName="colCL_NAME">
                                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="DIV_NAME" HeaderText="Division" UniqueName="colDIV_NAME">
                                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="PRD_DESCRIPTION" HeaderText="Product" UniqueName="colPRD_DESCRIPTION">
                                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="JOB_AND_COMP" HeaderText="Job/Component" UniqueName="colJOB_NUMBER">
                                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="TASK_DESCRIPTION" HeaderText="Description" UniqueName="colTask">
                                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="START_DATE" HeaderText="Start Date" UniqueName="colSTART_DATE">
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <FooterStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="TASK_HOURS_ALLOWED" DataFormatString="{0:0.00}"
                                                HeaderText="Hours" UniqueName="colTASK_HOURS_ALLOWED">
                                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="EMP_CODE_FML_NAME" HeaderText="Employee" UniqueName="colEMP_CODE_FML_NAME">
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <FooterStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                            </telerik:GridBoundColumn>
                                        </Columns>
                                        <ExpandCollapseColumn Resizable="False" Visible="False">
                                            <HeaderStyle Width="20px" />
                                        </ExpandCollapseColumn>
                                        <RowIndicatorColumn Visible="False">
                                            <HeaderStyle Width="20px" />
                                        </RowIndicatorColumn>
                                    </MasterTableView>
                                    <ClientSettings>
                                        <Scrolling UseStaticHeaders="False" />
                                    </ClientSettings>
                                </telerik:RadGrid>
                            </div>  
                        </ew:CollapsablePanel>
                    </div>
                </asp:Panel>            
                <%--<asp:Panel ID="PanelAssignments" runat="server">
                    <div class="CollapsablePanel-Wrap">
                        <ew:CollapsablePanel ID="CollapsablePanelListViewAssignments" runat="server" TitleText="Assignments">
                            <telerik:RadButton ID="RadButtonLiistViewAssignmentsRefresh" runat="server" Text="Refresh"></telerik:RadButton>
                            <asp:ImageButton ID="ImageButtonListViewAssignments" runat="server" SkinID="ImageButtonExportExcel" />
                            <div style="padding:4px 0px 0px 0px;">
                                <telerik:RadGrid ID="RadGridListViewAssignments" runat="server" AllowSorting="true"
                                    Width="100%" AutoGenerateColumns="False" ShowFooter="false" EnableEmbeddedSkins="True"
                                    Visible="true">
                                    <MasterTableView AllowMultiColumnSorting="True" DataKeyNames="DATA_KEY,CL_CODE,DIV_CODE,PRD_CODE,ALL_DAY,NUM_DAYS,HAS_TIME,START_TIME,END_TIME,ALERT_ID,SPRINT_ID"
                                        NoMasterRecordsText="No records to display">
                                        <Columns>
                                            <telerik:GridTemplateColumn UniqueName="colDetails">
                                                <HeaderStyle CssClass="radgrid-icon-column" />
                                                <ItemStyle CssClass="radgrid-icon-column" />
                                                <FooterStyle CssClass="radgrid-icon-column" />
                                                <HeaderTemplate>
                                                    &nbsp;
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <div class="icon-background background-color-sidebar">
                                                        <asp:ImageButton ID="imgbtnDetailTasks" runat="server" AlternateText="Open Detail"
                                                            CommandArgument='<%#Eval("DATA_KEY")%>' CommandName="DetailRow" SkinID="ImageButtonViewWhite" />
                                                    </div>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridBoundColumn DataField="CL_NAME" HeaderText="Client" UniqueName="colCL_NAME">
                                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="DIV_NAME" HeaderText="Division" UniqueName="colDIV_NAME">
                                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="PRD_DESCRIPTION" HeaderText="Product" UniqueName="colPRD_DESCRIPTION">
                                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="JOB_AND_COMP" HeaderText="Job/Component" UniqueName="colJOB_NUMBER">
                                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="TASK_AND_DESCRIPT" HeaderText="Task" UniqueName="colTask">
                                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="START_DATE" HeaderText="Date" UniqueName="colSTART_DATE">
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <FooterStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="TASK_HOURS_ALLOWED" DataFormatString="{0:0.00}"
                                                HeaderText="Hours" UniqueName="colTASK_HOURS_ALLOWED">
                                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="EMP_CODE_FML_NAME" HeaderText="Employee" UniqueName="colEMP_CODE_FML_NAME">
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <FooterStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                            </telerik:GridBoundColumn>
                                        </Columns>
                                        <ExpandCollapseColumn Resizable="False" Visible="False">
                                            <HeaderStyle Width="20px" />
                                        </ExpandCollapseColumn>
                                        <RowIndicatorColumn Visible="False">
                                            <HeaderStyle Width="20px" />
                                        </RowIndicatorColumn>
                                    </MasterTableView>
                                    <ClientSettings>
                                        <Scrolling UseStaticHeaders="False" />
                                    </ClientSettings>
                                </telerik:RadGrid>
                            </div>  
                        </ew:CollapsablePanel>
                    </div>
                </asp:Panel>--%>
                <asp:Panel ID="PanelEvents" runat="server">
                    <div class="CollapsablePanel-Wrap">
                        <ew:CollapsablePanel ID="CollapsablePanelListViewEvents" runat="server" TitleText="Events">
                            <asp:ImageButton ID="ImageButtonListViewEvents" runat="server" SkinID="ImageButtonExportExcel" />
                            <div style="padding: 4px 0px 0px 0px;">
                                <telerik:RadGrid ID="RadGridEvents" runat="server" AllowSorting="true"
                                    Width="100%" AutoGenerateColumns="False" ShowFooter="false" EnableEmbeddedSkins="True"
                                    Visible="true">
                                    <MasterTableView AllowMultiColumnSorting="True" DataKeyNames="DATA_KEY,CL_CODE,DIV_CODE,PRD_CODE,AD_NBR_COLOR"
                                        NoMasterRecordsText="No records to display">
                                        <Columns>
                                            <telerik:GridTemplateColumn UniqueName="colDetails">
                                                <HeaderStyle CssClass="radgrid-icon-column" />
                                                <ItemStyle CssClass="radgrid-icon-column" />
                                                <FooterStyle CssClass="radgrid-icon-column" />
                                                <HeaderTemplate>
                                                    &nbsp;
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <div class="icon-background background-color-sidebar">
                                                        <asp:ImageButton ID="imgbtnDetailEvents" runat="server" AlternateText="Open Detail"
                                                            CommandArgument='<%#Eval("DATA_KEY")%>' CommandName="DetailRow" SkinID="ImageButtonViewWhite" />
                                                    </div>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridBoundColumn DataField="CL_NAME" HeaderText="Client" UniqueName="colCL_NAME">
                                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="DIV_NAME" HeaderText="Division" UniqueName="colDIV_NAME">
                                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="PRD_DESCRIPTION" HeaderText="Product" UniqueName="colPRD_DESCRIPTION">
                                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="JOB_AND_COMP" HeaderText="Job/Component" UniqueName="colJOB_NUMBER">
                                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="EVENT_AND_DESCRIPT" HeaderText="Event" UniqueName="colEVENT_AND_DESCRIPT">
                                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="RESOURCE_AND_DESCRIPT" HeaderText="Resource"
                                                UniqueName="colRESOURCE_AND_DESCRIPT">
                                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="AD_NBR_AND_DESCRIPT" HeaderText="Ad Number" UniqueName="colAD_NBR_AND_DESCRIPT">
                                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="START_TIME" HeaderText="Start" UniqueName="colSTART_TIME">
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <FooterStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="END_TIME" HeaderText="End" UniqueName="colEND_TIME">
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <FooterStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="TASK_HOURS_ALLOWED" DataFormatString="{0:0.00}"
                                                HeaderText="Hours" UniqueName="colTASK_HOURS_ALLOWED">
                                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" />
                                            </telerik:GridBoundColumn>
                                        </Columns>
                                        <ExpandCollapseColumn Resizable="False" Visible="False">
                                            <HeaderStyle Width="20px" />
                                        </ExpandCollapseColumn>
                                        <RowIndicatorColumn Visible="False">
                                            <HeaderStyle Width="20px" />
                                        </RowIndicatorColumn>
                                    </MasterTableView>
                                    <ClientSettings>
                                        <Scrolling UseStaticHeaders="False" />
                                    </ClientSettings>
                                </telerik:RadGrid>
                            </div>
                        </ew:CollapsablePanel>
                    </div>
                </asp:Panel>
                <asp:Panel ID="PanelEventTasks" runat="server">
                    <div class="CollapsablePanel-Wrap">
                        <ew:CollapsablePanel ID="CollapsablePanelListViewEventTasks" runat="server" TitleText="Event Tasks">
                            <asp:ImageButton ID="ImageButtonListViewEventTask" runat="server" SkinID="ImageButtonExportExcel" />
                            <div style="padding: 4px 0px 0px 0px;">
                                <telerik:RadGrid ID="RadGridEventTasks" runat="server" AllowSorting="true"
                                    Width="100%" AutoGenerateColumns="False" ShowFooter="false" EnableEmbeddedSkins="True"
                                    Visible="true">
                                    <MasterTableView AllowMultiColumnSorting="True" DataKeyNames="DATA_KEY,CL_CODE,DIV_CODE,PRD_CODE"
                                        NoMasterRecordsText="No records to display">
                                        <Columns>
                                            <telerik:GridTemplateColumn UniqueName="colDetails">
                                                <HeaderStyle CssClass="radgrid-icon-column" />
                                                <ItemStyle CssClass="radgrid-icon-column" />
                                                <FooterStyle CssClass="radgrid-icon-column" />
                                                <HeaderTemplate>
                                                    &nbsp;
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <div class="icon-background background-color-sidebar">
                                                        <asp:ImageButton ID="imgbtnDetailEventTasks" runat="server" AlternateText="Open Detail"
                                                            CommandArgument='<%#Eval("DATA_KEY")%>' CommandName="DetailRow" SkinID="ImageButtonViewWhite" />
                                                    </div>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridBoundColumn DataField="CL_NAME" HeaderText="Client" UniqueName="colCL_NAME">
                                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="DIV_NAME" HeaderText="Division" UniqueName="colDIV_NAME">
                                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="PRD_DESCRIPTION" HeaderText="Product" UniqueName="colPRD_DESCRIPTION">
                                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="JOB_AND_COMP" HeaderText="Job/Component" UniqueName="colJOB_NUMBER">
                                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="TRF_AND_DESCRIPT" HeaderText="Task" UniqueName="colTRF_AND_DESCRIPT">
                                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="EMP_CODE_NAME" HeaderText="Employee" UniqueName="colEMP_CODE_NAME">
                                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="START_TIME" HeaderText="Start" UniqueName="colSTART_TIME">
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <FooterStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="END_TIME" HeaderText="End" UniqueName="colEND_TIME">
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <FooterStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="NON_TASK_HOURS" DataFormatString="{0:0.00}" HeaderText="Hours"
                                                UniqueName="colNON_TASK_HOURS">
                                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" />
                                            </telerik:GridBoundColumn>
                                        </Columns>
                                        <ExpandCollapseColumn Resizable="False" Visible="False">
                                            <HeaderStyle Width="20px" />
                                        </ExpandCollapseColumn>
                                        <RowIndicatorColumn Visible="False">
                                            <HeaderStyle Width="20px" />
                                        </RowIndicatorColumn>
                                    </MasterTableView>
                                    <ClientSettings>
                                        <Scrolling UseStaticHeaders="False" />
                                    </ClientSettings>
                                </telerik:RadGrid>
                            </div>
                        </ew:CollapsablePanel>   
                    </div>
                </asp:Panel>
                <asp:Panel ID="PanelAppointmentHolidays" runat="server">
                    <div class="CollapsablePanel-Wrap">
                        <ew:CollapsablePanel ID="CollapsablePanelListViewHolidays" runat="server" TitleText="Appointments and Holidays">
                            <asp:ImageButton ID="ImageButtonAppointments" runat="server" SkinID="ImageButtonExportExcel" />
                            <div style="padding: 4px 0px 0px 0px;">
                                <telerik:RadGrid ID="RadGridAppointmentHolidays" runat="server" AllowSorting="true"
                                    Width="100%" AutoGenerateColumns="False" ShowFooter="false"
                                    EnableEmbeddedSkins="True" Visible="true">
                                    <MasterTableView AllowMultiColumnSorting="True" DataKeyNames="DATA_KEY,NON_TASK_TYPE,ALL_DAY,NUM_DAYS,HAS_TIME,START_TIME,END_TIME,CDP_CONTACT_ID"
                                        NoMasterRecordsText="No records to display">
                                        <Columns>
                                            <telerik:GridTemplateColumn UniqueName="colDetails">
                                                <HeaderStyle CssClass="radgrid-icon-column" />
                                                <ItemStyle CssClass="radgrid-icon-column" />
                                                <FooterStyle CssClass="radgrid-icon-column" />
                                                <HeaderTemplate>
                                                    &nbsp;
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <div class="icon-background background-color-sidebar">
                                                        <asp:ImageButton ID="imgbtnDetailAppointmentHolidays" runat="server" AlternateText="Open Detail"
                                                            CommandArgument='<%#Eval("DATA_KEY")%>' CommandName="DetailRow" SkinID="ImageButtonViewWhite" />
                                                    </div>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridBoundColumn DataField="TASK_NON_TASK_DISPLAY" HeaderText="Subject" UniqueName="colTASK_NON_TASK_DISPLAY">
                                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="EMP_CODE_NAME" HeaderText="Employee" UniqueName="colEMP_CODE_NAME">
                                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="REC_TYPE" HeaderText="Type" UniqueName="colREC_TYPE">
                                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="ALL_DAY_YN" HeaderText="All Day" UniqueName="colALL_DAY_YN">
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <FooterStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="START_DATE" HeaderText="Date" UniqueName="colSTART_DATE">
                                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="NON_TASK_HOURS" DataFormatString="{0:0.00}" HeaderText="Hours"
                                                UniqueName="colNON_TASK_HOURS">
                                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="NON_TASK_CATEGORY" HeaderText="Category" UniqueName="colNON_TASK_CATEGORY">
                                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="CL_NAME" HeaderText="Client" UniqueName="colCL_NAME">
                                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="DIV_NAME" HeaderText="Division" UniqueName="colDIV_NAME">
                                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="PRD_DESCRIPTION" HeaderText="Product" UniqueName="colPRD_DESCRIPTION">
                                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="CONT_FML" HeaderText="Contact" UniqueName="colCONT_FML">
                                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridTemplateColumn UniqueName="colDetails">
                                                <HeaderTemplate>
                                                    &nbsp;
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="imgbtnContacts" runat="server" AlternateText="Open Contacts"
                                                        CommandArgument='<%#Eval("DATA_KEY")%>' CommandName="Contacts" SkinID="ImageButtonClientContact" />
                                                </ItemTemplate>
                                                <HeaderStyle VerticalAlign="bottom" HorizontalAlign="Center" />
                                                <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                            </telerik:GridTemplateColumn>
                                        </Columns>
                                        <ExpandCollapseColumn Resizable="False" Visible="False">
                                            <HeaderStyle Width="20px" />
                                        </ExpandCollapseColumn>
                                        <RowIndicatorColumn Visible="False">
                                            <HeaderStyle Width="20px" />
                                        </RowIndicatorColumn>
                                    </MasterTableView>
                                    <ClientSettings>
                                        <Scrolling UseStaticHeaders="False" />
                                    </ClientSettings>
                                </telerik:RadGrid>
                            </div>
                        </ew:CollapsablePanel>
                    </div>
                </asp:Panel>            
            </telerik:RadPageView>
            <telerik:RadPageView ID="RadPageViewWorkload" runat="server">
                <div class="CollapsablePanel-Wrap">
                    <ew:CollapsablePanel ID="CollapsablePanelWorkloadAnalysis" runat="server" TitleText="Workload Analysis for # through #">
                        <div class="code-description-container">
                            <div class="code-description-label">
                                Dates:
                            </div>
                            <div class="code-description-description">
                                <telerik:RadDatePicker ID="RadDatePickerWorkloadStartDate" runat="server" SkinID="RadDatePickerStandard">
                                    <DateInput DateFormat="d" EmptyMessage="">
                                        <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                                    </DateInput>
                                    <Calendar ID="CalendarWorkloadStartDate" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                                        <SpecialDays>
                                            <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="radcalendar-today">
                                            </telerik:RadCalendarDay>
                                        </SpecialDays>
                                    </Calendar>
                                </telerik:RadDatePicker>
                                &nbsp;
                                through
                                &nbsp;
                                <telerik:RadDatePicker ID="RadDatePickerWorkloadEndDate" runat="server" SkinID="RadDatePickerStandard">
                                    <DateInput DateFormat="d" EmptyMessage="">
                                        <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                                    </DateInput>
                                    <Calendar ID="CalendarWorkloadEndDate" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                                        <SpecialDays>
                                            <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="radcalendar-today">
                                            </telerik:RadCalendarDay>
                                        </SpecialDays>
                                    </Calendar>
                                </telerik:RadDatePicker>
                                <telerik:RadButton ID="RadButtonWorkloadRefreshDates" runat="server" Text="Refresh" CssClass="rfdSkinnedButton"></telerik:RadButton>
                            </div>
                        </div>
                        <fieldset>
                            <table id="Table6" align="left" cellpadding="0" cellspacing="0" width="450">
                                <tr>
                                    <td width="300">
                                        <asp:Label ID="lblTotalJobsDue" runat="server" Text="Total Jobs Due:"></asp:Label>
                                    </td>
                                    <td align="right" width="120">
                                        <asp:Label ID="lblTotalJobsDueNum" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblTotalJobsOpenTasks" runat="server" Text="Total Jobs with Open Tasks"></asp:Label>
                                    </td>
                                    <td align="right" width="120">
                                        <asp:Label ID="lblTotalJobsOpenTasksNum" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr style="display: none;">
                                    <td>
                                        <asp:Label ID="lblOpenTask" runat="server" Text="Assignments Due in Range:"></asp:Label>
                                    </td>
                                    <td align="right" width="120">
                                        <asp:Label ID="lblOpenTaskNum" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <br />
                                        <asp:Label ID="lblTotalHoursAvailable" runat="server" Text="Standard Hours Available:"></asp:Label>
                                    </td>
                                    <td align="right" width="120">
                                        <br />
                                        <asp:Label ID="lblTotalHoursAvailableNum" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblAppointmentHours" runat="server" Text="Appointment Hours:"></asp:Label>
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="lblAppointmentHoursNum" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblHoursOff" runat="server" Text="Hours Off:"></asp:Label>
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="lblHoursOffNum" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblHoursAllocated" runat="server" Text="Hours Assigned to Tasks:"></asp:Label>
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="lblHoursAllocatedNum" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <br />
                                        <asp:Label ID="lblTotalHoursAllocated" runat="server" Text="Hours Available Balance:"></asp:Label>
                                    </td>
                                    <td align="right">
                                        <br />
                                        <asp:Label ID="lblTotalHoursAllocatedNum" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <br />
                                        <asp:Label ID="lblTotalHoursNeeded" runat="server" Text="Task Hours Unassigned:"></asp:Label>
                                    </td>
                                    <td align="right">
                                        <br />
                                        <asp:Label ID="lblTotalHoursNeededNum" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblVariance" runat="server" Text="Variance:"></asp:Label>
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="lblVarianceNum" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                        <div style="margin-top: 10px;">
                            <telerik:RadGrid ID="RadGridWorkload" runat="server" AllowSorting="true" GridLines="None"
                                AutoGenerateColumns="False" ShowFooter="true" EnableEmbeddedSkins="True" Visible="true">
                                <MasterTableView AllowMultiColumnSorting="True" Width="100%" DataKeyNames="JOB_NUMBER,JOB_COMPONENT_NBR">
                                    <Columns>
                                        <telerik:GridBoundColumn DataField="OFFICE_CODE" HeaderText="Office" UniqueName="colOFFICE_CODE">
                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                            <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="CL_CODE" HeaderText="Client" UniqueName="colCL_CODE">
                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                            <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="DIV_CODE" HeaderText="Division" UniqueName="colDIV_CODE">
                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                            <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="PRD_CODE" HeaderText="Product" UniqueName="colPRD_CODE">
                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                            <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="JOB_NUMBER" DataFormatString="{0:D6}" HeaderText="Job Number"
                                            UniqueName="colJOB_NUMBER">
                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                            <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="JOB_DESC" HeaderText="Job Description" UniqueName="colJOB_DESC">
                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                            <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="JOB_COMPONENT_NBR" DataFormatString="{0:D3}"
                                            HeaderText="Job Component" UniqueName="colJOB_COMPONENT_NBR">
                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                            <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="JOB_COMP_DESC" HeaderText="Component Description"
                                            UniqueName="colJOB_COMP_DESC">
                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                            <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="START_DATE" DataFormatString="{0:d}"
                                            HeaderText="Start Date" ItemStyle-HorizontalAlign="Right" UniqueName="colSTART_DATE">
                                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                            <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="JOB_FIRST_USE_DATE" DataFormatString="{0:d}"
                                            HeaderText="Job Due Date" ItemStyle-HorizontalAlign="Right" UniqueName="colJOB_FIRST_USE_DATE">
                                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                            <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="TRF_DESCRIPTION" HeaderText="Current Status"
                                            UniqueName="colTRF_DESCRIPTION">
                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                            <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="TOTAL_OPEN_TASKS" HeaderStyle-HorizontalAlign="Center"
                                            Display="False" HeaderText="Assignments<br/>Due in Range" ItemStyle-HorizontalAlign="Center"
                                            UniqueName="colTOTAL_OPEN_TASKS">
                                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                            <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="TOTAL_HRS_ASSIGNED" HeaderStyle-HorizontalAlign="Center"
                                            Display="false" DataFormatString="{0:0.00}" HeaderText="Total Hours" ItemStyle-HorizontalAlign="Right"
                                            UniqueName="colTOTAL_HRS_ASSIGNED">
                                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                            <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="TOTAL_HRS_UNASSIGNED" HeaderStyle-HorizontalAlign="Center"
                                            DataFormatString="{0:0.00}" HeaderText="Task Hours<br/>Unassigned" ItemStyle-HorizontalAlign="Right"
                                            Display="false" UniqueName="colTOTAL_HRS_UNASSIGNED">
                                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                            <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="TOTAL_ADJ_JOB_HRS" HeaderStyle-HorizontalAlign="Center"
                                            Display="false" DataFormatString="{0:0.00}" HeaderText="Adjusted Hours Assigned"
                                            ItemStyle-HorizontalAlign="Right" UniqueName="colTOTAL_ADJ_JOB_HRS">
                                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                            <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="TOTAL_HOURS_PER_DAY" HeaderStyle-HorizontalAlign="Center"
                                            DataFormatString="{0:0.00}" Visible="false" HeaderText="Task Hours" ItemStyle-HorizontalAlign="Right"
                                            UniqueName="colTOTAL_HOURS_PER_DAY">
                                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                            <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridTemplateColumn Visible="True" UniqueName="ColPS">
                                            <HeaderStyle CssClass="radgrid-icon-column" />
                                            <ItemStyle CssClass="radgrid-icon-column" />
                                            <FooterStyle CssClass="radgrid-icon-column" />
                                            <ItemTemplate>
                                                <div class="icon-background background-color-sidebar">
                                                    <asp:LinkButton ID="LinkButtonSchedule" runat="server" CssClass="icon-text" CommandName="GoToSchedule" ToolTip="Go to schedule">P</asp:LinkButton>
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                    </Columns>
                                    <ExpandCollapseColumn Resizable="False" Visible="False">
                                        <HeaderStyle Width="20px" />
                                    </ExpandCollapseColumn>
                                    <RowIndicatorColumn Visible="False">
                                        <HeaderStyle Width="20px" />
                                    </RowIndicatorColumn>
                                </MasterTableView>
                                <ClientSettings>
                                    <Scrolling UseStaticHeaders="False" />
                                </ClientSettings>
                            </telerik:RadGrid>
                        </div>
                    </ew:CollapsablePanel>
                </div>
                <table id="Table1" align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td>
                        
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">
                            <asp:CheckBox ID="chkSaveSettings" runat="server" Text="Save My Options" Visible="False" />&nbsp;<br />
                            <br />
                            <asp:Button ID="butRestore" runat="server" Text="Restore Defaults" Visible="False" /><br />
                            <br />
                            <asp:Button ID="butSave" runat="server" Text="Apply" Visible="false" /><br />
                            <br />
                            <br />
                            <asp:Label ID="lblError" runat="server" CssClass="warning"></asp:Label>
                        </td>
                    </tr>
                </table>
            </telerik:RadPageView>
            <telerik:RadPageView ID="RadPageViewAvailability" runat="server">
                <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
                    <script type="text/javascript">
                        function RowContextMenu(sender, eventArgs) {
                            var menu = $find("<%= RadMenu1.ClientID %>");
                            var menu2 = $find("<%= RadMenu2.ClientID%>");

                            var evt = eventArgs.get_domEvent();

                            if (evt.target.tagName == "INPUT" || evt.target.tagName == "A") {
                                return;
                            }

                            var index = eventArgs.get_itemIndexHierarchical();
                            document.getElementById("radGridClickedRowIndex").value = index;

                            var MasterTable = sender.get_masterTableView();
                            var row = MasterTable.get_dataItems()[eventArgs.get_itemIndexHierarchical()];
                            var cell = MasterTable.getCellByColumnUniqueName(row, "columnREC");
                            var job = MasterTable.getCellByColumnUniqueName(row, "columnJob");

                            if (job.innerHTML == '&nbsp;') {
                                var menuItem = menu2.findItemByValue("Job");
                                menuItem.hide();
                                var menuItem2 = menu2.findItemByValue("PS");
                                menuItem2.hide();
                            } else {
                                var menuItem = menu2.findItemByValue("Job");
                                menuItem.show();
                                var menuItem2 = menu2.findItemByValue("PS");
                                menuItem2.show();
                            }

                            if (cell.innerHTML == 'C' || cell.innerHTML == 'M' || cell.innerHTML == 'TD' || cell.innerHTML == 'EL' || cell.innerHTML == 'A' || cell.innerHTML == 'H' || cell.innerHTML == 'ADA' || cell.innerHTML == 'AHO' || cell.innerHTML == 'ADAHO') {
                                menu2.show(evt);
                            } else {
                                menu.show(evt);
                            }

                            evt.cancelBubble = true;
                            evt.returnValue = false;

                            if (evt.stopPropagation) {
                                evt.stopPropagation();
                                evt.preventDefault();
                            }
                        }
                    </script>
                </telerik:RadScriptBlock>
                <div class="CollapsablePanel-Wrap">
                        <ew:CollapsablePanel ID="CollapsablePanelHeader" runat="server" TitleText="Job Information">
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Dates:
                        </div>
                        <div class="code-description-description">
                            <telerik:RadDatePicker ID="RadDatePickerAvailabilityStartDate" runat="server" SkinID="RadDatePickerStandard">
                                <DateInput DateFormat="d" EmptyMessage="">
                                    <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                                </DateInput>
                                <Calendar ID="CalendarAvailabilityStartDate" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                                    <SpecialDays>
                                        <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="radcalendar-today">
                                        </telerik:RadCalendarDay>
                                    </SpecialDays>
                                </Calendar>
                            </telerik:RadDatePicker>&nbsp;through&nbsp;
                            <telerik:RadDatePicker ID="RadDatePickerAvailabilityEndDate" runat="server" SkinID="RadDatePickerStandard">
                                <DateInput DateFormat="d" EmptyMessage="">
                                    <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                                </DateInput>
                                <Calendar ID="CalendarAvailabilityEndDate" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                                    <SpecialDays>
                                        <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="radcalendar-today">
                                        </telerik:RadCalendarDay>
                                    </SpecialDays>
                                </Calendar>
                            </telerik:RadDatePicker>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Employee:
                        </div>
                        <div class="code-description-description">
                            <telerik:RadComboBox ID="ddEmployee" runat="server" Width="250" SkinID="RadComboBoxStandard">
                            </telerik:RadComboBox>
                            <asp:Button ID="btnAssignments" runat="server" Text="Assignments" Visible="false" />
                            <asp:Button ID="btnAvail" runat="server" Text="Availability" Visible="false" />
                            &nbsp;&nbsp;
                            <asp:Button ID="ButtonRefresh" runat="server" Text="Refresh" />
                            &nbsp;
                            <asp:Button ID="ButtonExport" runat="server" Text="Export" Visible="False" />
                            &nbsp;
                            <asp:Button ID="ButtonAll" runat="server" Text="Show All Projects" Visible="false" />
                        </div>
                    </div>
                    <div id="DivSummaryLevel" runat="server" class="code-description-container">
                        <div class="code-description-label">
                            Summary Level:
                        </div>
                        <div class="code-description-description">
                            <asp:RadioButtonList ID="RblAvailabilitySummaryLevel" runat="server" RepeatDirection="Horizontal"
                                RepeatLayout="Flow">
                                <asp:ListItem Text="Daily" Value="daily"></asp:ListItem>
                                <asp:ListItem Text="Weekly" Value="weekly"></asp:ListItem>
                                <asp:ListItem Text="Monthly" Value="monthly"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                    <div class="code-description-container" style="display: none;">
                        <div class="code-description-label">
                        </div>
                        <div class="code-description-description">
                            <asp:CheckBox ID="CheckBox1" runat="server" Text="Actualize" Visible="False" Width="80px" />
                        </div>
                    </div>
                    <div id="DivZeroHours" runat="server" class="code-description-container">
                        <div class="code-description-label">
                            <div id="DivZeroHoursColor" runat="server" style="margin: 0px 0px 0px 137px; height: 30px; width: 30px; border-radius: 50%; border: 1px solid #cecece;">
                            </div>
                        </div>
                        <div class="code-description-description">
                            Zero hours
                        </div>
                    </div>
                    <div id="DivLessThanHours" runat="server" class="code-description-container">
                        <div class="code-description-label">
                            <div id="DivLessThanHoursColor" runat="server" style="margin: 0px 0px 0px 137px; height: 30px; width: 30px; border-radius: 50%; border: 0px solid #cecece;">
                            </div>
                        </div>
                        <div class="code-description-description">
                            Less than
                        <telerik:RadNumericTextBox ID="RadNumericTextBoxLessThanPercentage" runat="server" Width="70" MinValue="0" MaxValue="150" IncrementSettings-Step="1" NumberFormat-DecimalDigits="2">
                        </telerik:RadNumericTextBox>
                            % of the Hours Available
                        </div>
                    </div>
                    <div id="DivLessThanAndGreaterThanHours" runat="server" class="code-description-container">
                        <div class="code-description-label">
                            <div id="DivLessThanAndGreaterThanHoursColor" runat="server" style="margin: 0px 0px 0px 137px; height: 30px; width: 30px; border-radius: 50%; border: 0px solid #cecece;">
                            </div>
                        </div>
                        <div class="code-description-description">
                            Greater than or Equal to
                        <telerik:RadNumericTextBox ID="RadNumericTextBoxLessThanAndGreaterThanHours_GreaterThan" runat="server" Width="70" MinValue="0" MaxValue="150" IncrementSettings-Step="1" NumberFormat-DecimalDigits="2">
                        </telerik:RadNumericTextBox>
                            % of the Hours Available and Less than
                        <telerik:RadNumericTextBox ID="RadNumericTextBoxLessThanAndGreaterThanHours_LessThan" runat="server" Width="70" MinValue="0" MaxValue="150" IncrementSettings-Step="1" NumberFormat-DecimalDigits="2">
                        </telerik:RadNumericTextBox>
                            % of the Hours Available
                        </div>
                    </div>
                    <div id="DivGreaterThanHours" runat="server" class="code-description-container">
                        <div class="code-description-label">
                            <div id="DivGreaterThanHoursColor" runat="server" style="margin: 0px 0px 0px 137px; height: 30px; width: 30px; border-radius: 50%; border: 0px solid #cecece;">
                            </div>
                        </div>
                        <div class="code-description-description">
                            Greater than or Equal to
                        <telerik:RadNumericTextBox ID="RadNumericTextBoxGreaterThanHours" runat="server" Width="70" MinValue="0" MaxValue="150" IncrementSettings-Step="1" NumberFormat-DecimalDigits="2">
                        </telerik:RadNumericTextBox>
                            % of the Hours Available
                        </div>
                    </div>
    <%--                    <div class="code-description-container">
                        <div class="code-description-label">
                        </div>
                        <div class="code-description-description">
                            <asp:Button ID="ButtonRefresh" runat="server" Text="Refresh" />
                            &nbsp;&nbsp;
                            <asp:Button ID="ButtonExport" runat="server" Text="Export" Visible="False" />
                            &nbsp;&nbsp;
                            <asp:Button ID="ButtonAll" runat="server" Text="Show All Projects" Visible="false" />
                        </div>
                    </div>--%>
                    <telerik:RadGrid ID="RadGridAvailability" runat="server" AllowSorting="true" EnableEmbeddedSkins="True"
                        Visible="true" Width="99%" Height="600px">
                        <MasterTableView DataKeyNames="EMP_CODE" AutoGenerateColumns="true">
                            <ExpandCollapseColumn Resizable="False" Visible="False">
                                <HeaderStyle Width="20px" />
                            </ExpandCollapseColumn>
                            <RowIndicatorColumn Visible="False">
                                <HeaderStyle Width="20px" />
                            </RowIndicatorColumn>
                        </MasterTableView>
                        <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="true">
                            <Scrolling AllowScroll="true" UseStaticHeaders="true" />
                            <Selecting AllowRowSelect="True" />
                        </ClientSettings>
                        <ExportSettings Excel-Format="Html" FileName="Availability" IgnorePaging="true" OpenInNewWindow="true">
                        </ExportSettings>
                    </telerik:RadGrid>
                </ew:CollapsablePanel>
                </div>
                <table id="Table4" cellpadding="2" cellspacing="0" width="100%">
                    <tr>
                        <td style="vertical-align:middle; text-align:center;" class="sub-header sub-header-color">
                            <br />
                            <asp:Label ID="lblEmployee" runat="server"></asp:Label>&nbsp;&nbsp;
                                                    <asp:ImageButton ID="imgbtnExport" runat="server" SkinID="ImageButtonExportExcel" Visible="false" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">
                            <div id="DivEmployeePicture" runat="server">
                                <telerik:RadBinaryImage runat="server" ID="RadBinaryImage1" ImageAlign="Middle" AutoAdjustImageControlSize="false"
                                    Width="70px" Height="70px" Visible="false" CssClass="employee-picture" />
                                <asp:Label ID="LabelEmployee" runat="server" Text="" Visible="False"></asp:Label>
                            </div>
                            <fieldset>
                                <table>
                                    <tr>
                                        <td>
                                            <table id="Table5" align="left" cellpadding="2" cellspacing="0" width="400">
                                                <tr>
                                                    <td width="300">
                                                        <asp:Label ID="lblTotalHoursEmpAvailable" runat="server" Text="Standard Hours Available:"
                                                            Visible="False"></asp:Label>
                                                    </td>
                                                    <td align="right" width="120">
                                                        <asp:Label ID="lblTotalHoursEmpAvailableNum" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="300">
                                                        <asp:Label ID="lblTotalAppointmentHours" runat="server" Text="Appointment Hours:" Visible="False"></asp:Label>
                                                    </td>
                                                    <td align="right" width="120">
                                                        <asp:Label ID="lblTotalAppointmentHoursNum" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="300">
                                                        <asp:Label ID="lblTotalHoursOffEmp" runat="server" Text="Hours Off:" Visible="False"></asp:Label>
                                                    </td>
                                                    <td align="right" width="120">
                                                        <asp:Label ID="lblTotalHoursOffEmpNum" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="300">
                                                        <asp:Label ID="lblTotalHoursAssigned" runat="server" Text="Hours Assigned to Tasks:"
                                                            Visible="False"></asp:Label>
                                                    </td>
                                                    <td align="right" width="120">
                                                        <asp:Label ID="lblTotalHoursAssignedNum" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="300">
                                                        <asp:Label ID="lblVarianceEmp" runat="server" Text="Variance:" Visible="False"></asp:Label>
                                                    </td>
                                                    <td align="right" width="120">
                                                        <asp:Label ID="lblVarianceEmpNum" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="300">
                                                        <asp:Label ID="lblDirectHoursGoal" runat="server" Text="% of Direct Hours Goal:" Visible="False"></asp:Label>
                                                    </td>
                                                    <td align="right" width="120">
                                                        <asp:Label ID="lblDirectHoursGoalNum" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;
                                        </td>
                                        <td style="white-space:nowrap;">
                                            <br />
                                            <asp:TextBox ID="txtTasks" runat="server" BackColor="#CAE0DA" ReadOnly="true" Width="10px" SkinID="TextBoxStandard"></asp:TextBox>
                                            <asp:Label ID="Label1" runat="server" Text="Assigned Tasks"></asp:Label>
                                            <asp:TextBox ID="TextBox1" runat="server" BackColor="#B2C9E0" ReadOnly="true" Width="10px" SkinID="TextBoxStandard"></asp:TextBox>
                                            <asp:Label ID="Label2" runat="server" Text="Appointments"></asp:Label>
                                            <asp:TextBox ID="TextBox7" runat="server" BackColor="#F6E3BC" ReadOnly="true" Width="10px" SkinID="TextBoxStandard"></asp:TextBox>
                                            <asp:Label ID="Label19" runat="server" Text="Hours off"></asp:Label>
                                            <asp:TextBox ID="TextBox6" runat="server" BackColor="#F7D5DB" ReadOnly="true" Width="10px" Visible="false" SkinID="TextBoxStandard"></asp:TextBox>
                                            <asp:Label ID="Label11" runat="server" Text="Event Tasks" Visible="false"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>
                        </td>
                    </tr>
                </table>
                <input type="hidden" id="radGridClickedRowIndex" name="radGridClickedRowIndex" />
                <telerik:RadGrid ID="RadGridAssignments" runat="server" AllowSorting="true" GridLines="None"
                    ShowFooter="true" EnableEmbeddedSkins="True" Visible="false" Width="99%">
                    <ClientSettings>
                        <ClientEvents OnRowContextMenu="RowContextMenu" />
                    </ClientSettings>
                    <MasterTableView AllowMultiColumnSorting="true" AutoGenerateColumns="false" DataKeyNames="JOB_NUMBER,JOB_COMPONENT_NBR,CL_CODE,DIV_CODE,PRD_CODE,SEQ_NBR,NON_TASK_ID,REC_TYPE,JOB_COMP_DESC">
                        <Columns>
                            <telerik:GridBoundColumn DataField="OFFICE_CODE" HeaderText="Office" UniqueName="column10"
                                HeaderStyle-VerticalAlign="Bottom" HeaderStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Middle"
                                ItemStyle-HorizontalAlign="Left">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="DP_TM_CODE" HeaderText="Dept" UniqueName="column10"
                                HeaderStyle-VerticalAlign="Bottom" HeaderStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Middle"
                                ItemStyle-HorizontalAlign="Left">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="DEF_TRF_CODE" HeaderText="Role" UniqueName="column111"
                                HeaderStyle-VerticalAlign="Bottom" HeaderStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Middle"
                                ItemStyle-HorizontalAlign="Left">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="CL_CODE" HeaderText="Client" UniqueName="column11"
                                HeaderStyle-VerticalAlign="Bottom" HeaderStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Middle"
                                ItemStyle-HorizontalAlign="Left">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="DIV_CODE" HeaderText="Division" UniqueName="column12"
                                HeaderStyle-VerticalAlign="Bottom" HeaderStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Middle"
                                ItemStyle-HorizontalAlign="Left">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="PRD_CODE" HeaderText="Product" UniqueName="column13"
                                HeaderStyle-VerticalAlign="Bottom" HeaderStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Middle"
                                ItemStyle-HorizontalAlign="Left">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="JOB_NUMBER" DataFormatString="{0:D6}" HeaderText="Project" SortExpression="JOB_NUMBER"
                                HeaderStyle-HorizontalAlign="left" HeaderStyle-VerticalAlign="Bottom" ItemStyle-HorizontalAlign="left"
                                ItemStyle-VerticalAlign="Middle" UniqueName="columnJob">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="JOB_COMPONENT_NBR" DataFormatString="{0:D3}" Visible="false"
                                HeaderText="Job Component" HeaderStyle-HorizontalAlign="Right" HeaderStyle-VerticalAlign="Bottom"
                                ItemStyle-HorizontalAlign="Right" ItemStyle-VerticalAlign="Middle" UniqueName="column2">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="JOB_COMP_DESC" HeaderText="Job Description" UniqueName="column3" Visible="false"
                                HeaderStyle-VerticalAlign="Bottom" HeaderStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Middle" ItemStyle-CssClass="radgrid-description-column"
                                ItemStyle-HorizontalAlign="Left">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="FNC_CODE" HeaderText="Task Code" UniqueName="column4"
                                HeaderStyle-VerticalAlign="Bottom" HeaderStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Middle"
                                ItemStyle-HorizontalAlign="Left">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="TASK_DESCRIPTION" HeaderText="Task Description" 
                                HeaderStyle-VerticalAlign="Bottom" HeaderStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Middle" ItemStyle-CssClass="radgrid-description-column"
                                ItemStyle-HorizontalAlign="Left" UniqueName="column5">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="TASK_START_DATE" DataFormatString="{0:M/dd/yyyy }" ItemStyle-CssClass="radgrid-shortdate-column"
                                HeaderStyle-HorizontalAlign="Right" HeaderStyle-VerticalAlign="Bottom" ItemStyle-HorizontalAlign="Right"
                                ItemStyle-VerticalAlign="Middle" HeaderText="Start Date" UniqueName="column7">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="JOB_REVISED_DATE" DataFormatString="{0:M/dd/yyyy }" ItemStyle-CssClass="radgrid-shortdate-column"
                                HeaderStyle-HorizontalAlign="Right" HeaderStyle-VerticalAlign="Bottom" ItemStyle-HorizontalAlign="Right"
                                ItemStyle-VerticalAlign="Middle" HeaderText="Due Date" UniqueName="column8">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="JOB_HRS" HeaderText="Total Hours" HeaderStyle-HorizontalAlign="Right"
                                DataFormatString="{0:0.00}" HeaderStyle-VerticalAlign="Bottom" ItemStyle-HorizontalAlign="Right"
                                ItemStyle-VerticalAlign="Middle" FooterStyle-HorizontalAlign="Right" UniqueName="column6">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="TASK_TOTAL_WORKING_DAYS" HeaderText="Working Days"
                                HeaderStyle-HorizontalAlign="Right" HeaderStyle-VerticalAlign="Bottom" ItemStyle-HorizontalAlign="Right"
                                ItemStyle-VerticalAlign="Middle" UniqueName="ColWORKING_DAYS_IN_TASK_RANGE">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="HOURS_PER_DAY" HeaderText="Hours per<br/>Work Day"
                                HeaderStyle-HorizontalAlign="Right" DataFormatString="{0:0.00}" HeaderStyle-VerticalAlign="Bottom"
                                ItemStyle-HorizontalAlign="Right" ItemStyle-VerticalAlign="Middle" UniqueName="ColHRS_PER_DAY">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="ADJ_JOB_HRS" HeaderText="Adjusted<br/>Hours Assigned"
                                DataFormatString="{0:0.00}" HeaderStyle-HorizontalAlign="Right" HeaderStyle-VerticalAlign="Bottom"
                                ItemStyle-HorizontalAlign="Right" ItemStyle-VerticalAlign="Middle" FooterStyle-HorizontalAlign="Right"
                                UniqueName="ColADJ_JOB_HRS">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="EMP_CODE" HeaderText="Employee" UniqueName="column9"
                                HeaderStyle-VerticalAlign="Bottom" HeaderStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Middle"
                                ItemStyle-HorizontalAlign="Left" Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="SEQ_NBR" HeaderText="" UniqueName="column9" HeaderStyle-VerticalAlign="Bottom"
                                HeaderStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Left"
                                Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="REC_TYPE" HeaderText="" UniqueName="columnREC" HeaderStyle-VerticalAlign="Bottom"
                                HeaderStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Left"
                                Display="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn Visible="True" UniqueName="ColPS">
                                <HeaderStyle CssClass="radgrid-icon-column" />
                                <ItemStyle CssClass="radgrid-icon-column" />
                                <FooterStyle CssClass="radgrid-icon-column" />
                                <ItemTemplate>
                                    <div id="DivGoToSchedule" runat="server" class="icon-background background-color-sidebar">
                                        <asp:LinkButton ID="LinkButtonSchedule" runat="server" CssClass="icon-text" CommandName="GoToSchedule" ToolTip="Go to schedule">P</asp:LinkButton>
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                        <ExpandCollapseColumn Resizable="False" Visible="False">
                            <HeaderStyle Width="20px" />
                        </ExpandCollapseColumn>
                        <RowIndicatorColumn Visible="False">
                            <HeaderStyle Width="20px" />
                        </RowIndicatorColumn>
                    </MasterTableView>
                </telerik:RadGrid>
                <telerik:RadContextMenu ID="RadMenu1" runat="server" EnableRoundedCorners="false"
                    EnableShadows="true">
                    <Items>
                        <telerik:RadMenuItem Text="Edit" Value="Task" />
                        <telerik:RadMenuItem Text="Edit Assignee" Value="EditAssignment" />
                        <telerik:RadMenuItem Text="Go to Job" Value="Job" />
                        <telerik:RadMenuItem Text="Go to Schedule" Value="PS" />
                    </Items>
                </telerik:RadContextMenu>
                <telerik:RadContextMenu ID="RadMenu2" runat="server" EnableRoundedCorners="false"
                    EnableShadows="true">
                    <Items>
                        <telerik:RadMenuItem Text="Edit Activity" Value="Task" />
                        <telerik:RadMenuItem Text="Go to Job" Value="Job" />
                        <telerik:RadMenuItem Text="Go to Schedule" Value="PS" />
                    </Items>
                </telerik:RadContextMenu>
                <telerik:RadGrid ID="RadGrid2" runat="server" AllowSorting="false" AutoGenerateColumns="False"
                    EnableEmbeddedSkins="True" GridLines="None" Visible="false" Width="100%">
                    <MasterTableView>
                        <ExpandCollapseColumn Resizable="False" Visible="False">
                            <HeaderStyle Width="20px" />
                        </ExpandCollapseColumn>
                        <RowIndicatorColumn Visible="False">
                            <HeaderStyle Width="20px" />
                        </RowIndicatorColumn>
                    </MasterTableView>
                    <ClientSettings>
                        <Scrolling UseStaticHeaders="False" />
                    </ClientSettings>
                    <ExportSettings FileName="Employee Availability" IgnorePaging="True" OpenInNewWindow="True">
                    </ExportSettings>
                </telerik:RadGrid>
            </telerik:RadPageView>
            <telerik:RadPageView ID="RadPageViewFilter" runat="server" Height="1000px">
                <script type="text/javascript">

                    function CancelNonInputSelect(sender, args) {

                        var e = args.get_domEvent();
                        //IE - srcElement, Others - target  
                        var targetElement = e.srcElement || e.target;


                        //this condition is needed if multi row selection is enabled for the grid  
                        if (typeof (targetElement) != "undefined") {
                            //is the clicked element an input checkbox? <input type="checkbox"...>  
                            if (targetElement.tagName.toLowerCase() != "input" &&
                            (!targetElement.type || targetElement.type.toLowerCase() != "checkbox"))// && currentClickEvent)  
                            {

                                //cancel the event  
                                args.set_cancel(true);
                            }
                        }
                        else
                            args.set_cancel(true);
                    }
                    function ClearTBe(e, tb) {
                        try {
                            var keyval = e.keyCode;
                            if (keyval == 9) { }
                            else {
                                var thisTextbox = document.getElementById(tb);
                                thisTextbox.value = '';
                            }
                        }
                        catch (err) { }
                    }
                </script>
            <asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                    <div>
                        <div style="width: 100%; vertical-align: middle; text-align: center;">
                            <asp:Label ID="Label12" runat="server" CssClass="warning" Text="&nbsp;"></asp:Label>
                        </div>
                        <div>
                            <div style="width: 49%; display: inline-block; float: left; position: relative;">
                                <fieldset>
                                    <legend>
                                        Projects
                                    </legend>
                                    <div id="DivJobInformation" runat="server">
                                        <div id="DivOffice" runat="server" class="code-description-container">
                                            <div class="code-description-label">
                                                <asp:HyperLink ID="hlOffice" runat="server" href="" TabIndex="-1" Target="_blank"> Office: </asp:HyperLink>
                                            </div>
                                            <div class="code-description-code">
                                                <asp:TextBox ID="txtOffice" runat="server" TabIndex="1" SkinID="TextBoxCodeSmall"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div id="DivClient" runat="server" class="code-description-container">
                                            <div class="code-description-label">
                                                <asp:HyperLink ID="hlClient" runat="server" href="" TabIndex="-1" Target="_blank"> Client: </asp:HyperLink>
                                            </div>
                                            <div class="code-description-code">
                                                <asp:TextBox ID="txtClient" runat="server" TabIndex="2" SkinID="TextBoxCodeSmall"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div id="DivDivision" runat="server" class="code-description-container">
                                            <div class="code-description-label">
                                                <asp:HyperLink ID="hlDivision" runat="server" href="" TabIndex="-1" Target="_blank">  Division: </asp:HyperLink>
                                            </div>
                                            <div class="code-description-code">
                                                <asp:TextBox ID="txtDivision" runat="server" TabIndex="3" SkinID="TextBoxCodeSmall"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div id="DivProduct" runat="server" class="code-description-container">
                                            <div class="code-description-label">
                                                <asp:HyperLink ID="hlProduct" runat="server" href="" TabIndex="-1" Target="_blank">  Product: </asp:HyperLink>
                                            </div>
                                            <div class="code-description-code">
                                                <asp:TextBox ID="txtProduct" runat="server" TabIndex="4" SkinID="TextBoxCodeSmall"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div id="DivJob" runat="server" class="code-description-container">
                                            <div class="code-description-label">
                                                <asp:HyperLink ID="hlJob" runat="server" href="" TabIndex="-1" Target="_blank">  Job: </asp:HyperLink>
                                            </div>
                                            <div class="code-description-code">
                                                <asp:TextBox ID="txtJob" runat="server" TabIndex="5" SkinID="TextBoxCodeSmall"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div id="DivJobComponent" runat="server" class="code-description-container">
                                            <div class="code-description-label">
                                                <asp:HyperLink ID="hlJobComp" runat="server" href="" TabIndex="-1" Target="_blank">  Job Comp: </asp:HyperLink>
                                            </div>
                                            <div class="code-description-code">
                                                <asp:TextBox ID="txtJobComp" runat="server" TabIndex="6" SkinID="TextBoxCodeSmall"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div id="DivManager" runat="server" class="code-description-container">
                                            <div class="code-description-label">
                                                <asp:HyperLink ID="hlManager" runat="server" href="" TabIndex="-1" Target="_blank">  Managers: </asp:HyperLink>
                                            </div>
                                            <div class="code-description-code">
                                                <asp:TextBox ID="txtManager" runat="server" TabIndex="7" SkinID="TextBoxCodeSmall"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div id="DivTrafficStatus" runat="server" class="code-description-container">
                                            <div class="code-description-label">
                                                <asp:HyperLink ID="HlTrafficStatus" runat="server" href="" TabIndex="-1" Target="_blank">  Traffic Status: </asp:HyperLink>
                                            </div>
                                            <div class="code-description-code">
                                                <asp:TextBox ID="TxtTrafficStatusCode" runat="server" TabIndex="8" SkinID="TextBoxCodeSmall"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div id="DivTaskStatus" runat="server" class="code-description-container">
                                            <div class="code-description-label">
                                                Task Status:
                                            </div>
                                            <div class="code-description-code">
                                                <telerik:RadComboBox ID="ddTaskStatus" runat="server" TabIndex="9" SkinID="RadComboBoxStandard">
                                                    <Items>
                                                        <telerik:RadComboBoxItem Selected="True" Value="" Text="All"></telerik:RadComboBoxItem>
                                                        <telerik:RadComboBoxItem Value="A" Text="Active"></telerik:RadComboBoxItem>
                                                        <telerik:RadComboBoxItem Value="P" Text="Projected"></telerik:RadComboBoxItem>
                                                        <telerik:RadComboBoxItem Value="H" Text="High Priority"></telerik:RadComboBoxItem>
                                                        <telerik:RadComboBoxItem Value="L" Text="Low Priority"></telerik:RadComboBoxItem>
                                                    </Items>
                                                </telerik:RadComboBox>
                                            </div>
                                        </div>
                                        <div id="DivLengthSize" runat="server" class="code-description-container" style="display:none !important;">
                                            <div class="code-description-label">
                                                Length
                                            </div>
                                            <div class="code-description-code">
                                                <telerik:RadComboBox ID="ddSize" runat="server" SkinID="RadComboBoxStandard">
                                                </telerik:RadComboBox>
                                            </div>
                                        </div>
                                        <div class="code-description-container">
                                            <div class="code-description-label">
                                                <asp:CheckBox ID="chkExcludeTempComplete" runat="server" TabIndex="10" />
                                            </div>
                                            <div class="code-description-code">
                                                <asp:Label ID="lblExcludeTempComplete" runat="server">Exclude Temp Complete</asp:Label>
                                            </div>
                                        </div>
                                        <div id="DivDisplayClient" runat="server" class="code-description-container" style="display: none !important;">
                                            <div class="code-description-label">
                                                <asp:CheckBox ID="cbShowClient" runat="server" Visible="false" />
                                            </div>
                                            <div class="code-description-code">
                                                <asp:Label ID="lblDisplayClient" runat="server" Visible="false">Display Client</asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="code-description-container">
                                        <div class="code-description-label">
                                            <asp:CheckBox ID="chkMilestone" runat="server" TabIndex="12" />
                                        </div>
                                        <div class="code-description-code">
                                            <asp:Label ID="lblMilestone" runat="server">Display Milestones Only</asp:Label>
                                        </div>
                                    </div>
                                    <div class="code-description-container">
                                        <div class="code-description-label">
                                        </div>
                                        <div class="code-description-code">
                                            <asp:Button ID="butClear" runat="server" Text="Clear" />
                                        </div>
                                    </div>
                                </fieldset>
                                <asp:Panel ID="PanelEmployee" runat="server">
                                    <fieldset>
                                        <legend>
                                                Employees
                                        </legend>
                                        <div id="DivRoles" runat="server" class="code-description-container">
                                            <div class="code-description-label" style="vertical-align:top !important;">
                                                Employee Roles:
                                                <asp:CheckBox ID="ChkRoles" runat="server" AutoPostBack="true" />
                                            </div>
                                            <div class="code-description-code">
                                                <telerik:RadListBox ID="LbRoles" runat="server" SelectionMode="Multiple" Height="150" Width="325">
                                                </telerik:RadListBox>
                                            </div>
                                        </div>
                                        <div id="DivDepartment" runat="server" class="code-description-container">
                                            <div class="code-description-label" style="vertical-align: top !important;">
                                                Departments:
                                            </div>
                                            <div class="code-description-code">
                                                <telerik:RadListBox ID="lbDept" runat="server" Height="150" Width="325">
                                                </telerik:RadListBox>
                                            </div>
                                        </div>
                                        <div id="DivEmployeeCode" runat="server" class="code-description-container">
                                            <div class="code-description-label">
                                                <asp:Label ID="lblEmpCode" runat="server" TabIndex="0">Employee Code:</asp:Label>
                                            </div>
                                            <div class="code-description-code">
                                                <asp:TextBox ID="txtEmpCode" runat="server" AutoPostBack="true" TabIndex="8" SkinID="TextBoxCodeSmall"></asp:TextBox>
                                                <asp:ImageButton ID="butEmpCodeLookup" runat="server" AlternateText="Find Employee Link" CausesValidation="false" SkinID="ImageButtonFind" />
                                            </div>
                                        </div>
                                        <div id="Div2" runat="server" class="code-description-container">
                                            <div class="code-description-label">
                                                <asp:Label ID="LabelIncludeUnassigned" runat="server" TabIndex="0">Include Unassigned:</asp:Label>
                                            </div>
                                            <div class="code-description-code">
                                                <asp:CheckBox ID="CheckBoxIncludeUnassigned" runat="server" />  (Job Component level only)                                             
                                            </div>
                                        </div>
                                    </fieldset>
                                    <fieldset>
                                        <legend>
                                            Task Roles
                                        </legend>
                                        <asp:CheckBox ID="ChkFunctionRoles" runat="server" AutoPostBack="true" />
                                        <telerik:RadListBox ID="lbFunctionRoles" runat="server" SelectionMode="Multiple" Height="150" Width="325">
                                        </telerik:RadListBox>
                                    </fieldset>
                                </asp:Panel>
                                <fieldset id="FieldSetDateRange" runat="server" visible="false">
                                    <legend>Date Range</legend>
                                    <asp:Label ID="lblStartDate" runat="server" Text="Start Date: "></asp:Label>&nbsp;
                                    <telerik:RadDatePicker ID="RadDatePickerStartDate" runat="server" SkinID="RadDatePickerStandard">
                                        <DateInput DateFormat="d" EmptyMessage="">
                                            <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                                        </DateInput>
                                        <Calendar ID="CalendarStartDate" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                                            <SpecialDays>
                                                <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="radcalendar-today">
                                                </telerik:RadCalendarDay>
                                            </SpecialDays>
                                        </Calendar>
                                    </telerik:RadDatePicker>
                                    <asp:Label ID="lblEndDate" runat="server" Text="End Date: "></asp:Label>&nbsp;
                                    <telerik:RadDatePicker ID="RadDatePickerEndDate" runat="server" SkinID="RadDatePickerStandard">
                                        <DateInput DateFormat="d" EmptyMessage="">
                                            <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                                        </DateInput>
                                        <Calendar ID="CalendarEndDate" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                                            <SpecialDays>
                                                <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="radcalendar-today">
                                                </telerik:RadCalendarDay>
                                            </SpecialDays>
                                        </Calendar>
                                    </telerik:RadDatePicker>
                                </fieldset>
                            </div>
                            <div style="width: 49%; display: inline-block; float: left; position: relative; ">
                                <fieldset>
                                    <legend>Display Options</legend>
                                    <div style="padding: 4px 8px;">
                                        <strong>Tasks/Assignments:</strong><br />
                                        <ul class="list-unstyled calendar-list-styles">
                                            <li>
                                                                                            <asp:CheckBox ID="chkClientCode" runat="server" Text="Client Code" />

                                            </li>
                                            <li>
                                                                                            <asp:CheckBox ID="chkClientDesc" runat="server" Text="Client Description" />

                                            </li>
                                            <li>
                                                                                            <asp:CheckBox ID="chkDivisionCode" runat="server" Text="Division Code" />

                                            </li>
                                            <li>
                                                                                            <asp:CheckBox ID="chkDivisionDesc" runat="server" Text="Division Description" />

                                            </li>
                                            <li>
                                                                                            <asp:CheckBox ID="chkProductCode" runat="server" Text="Product Code" />

                                            </li>
                                            
                                            <li>
                                                                                            <asp:CheckBox ID="chkProductDesc" runat="server" Text="Product Description" />

                                            </li>
                                            <li>
                                                                                            <asp:CheckBox ID="chkJobNumber" runat="server" Text="Job Number" />

                                            </li>
                                            <li>
                                                                                            <asp:CheckBox ID="chkJobDesc" runat="server" Text="Job Description" />

                                            </li>
                                            <li>
                                                                                            <asp:CheckBox ID="chkComponentNumber" runat="server" Text="Component Number" />

                                            </li>
                                            <li>
                                                                                            <asp:CheckBox ID="chkComponentDesc" runat="server" Text="Component Description" />

                                            </li>
                                            <li>
                                                                                            <asp:CheckBox ID="chkTaskCode" runat="server" Text="Task Code" />

                                            </li>
                                            <li>
                                                                                            <asp:CheckBox ID="chkTaskDesc" runat="server" Text="Task/Assignment Description" />

                                            </li>
                                            <li>
                                                                                                <asp:CheckBox ID="chkEmpCodeDispl" runat="server" Text="Employee Code" /><br />

                                            </li>
                                            <li>
                                                                                                <asp:CheckBox ID="chkEmpDescDispl" runat="server" Text="Employee Name" /><br />

                                                 </li>
                                            <li>
                                                                                                <asp:CheckBox ID="chkHoursAllowed" runat="server" Text="Hours Allowed" /><br />

                                            </li>
                                            <li>
                                                                                                <asp:CheckBox ID="chkTimeDue" runat="server" Text="Time Due" /><br />

                                            </li>
                                        </ul>
                                            <div id="DivDisplayEmployeeOptions" runat="server">
                                                <br />
                                                <div id="DivNonClientPortalSettings" runat="server">
                                                    <strong>
                                                        Holidays/Activities:<br />
                                                    </strong>
                                                    <ul class="list-unstyled calendar-list-styles">
                                                        <li>
                                                                                                                <asp:CheckBox ID="chkEmployeeCode" runat="server" Text="Employee Code" /><br />

                                                        </li>
                                                        <li>
                                                                                                                <asp:CheckBox ID="chkEmployeeName" runat="server" Text="Employee Name" /><br />

                                                        </li>
                                                        <li>
                                                                                                                <asp:CheckBox ID="chkType" runat="server" Text="Type" /><br />

                                                        </li>
                                                        <li>
                                                                                                                <asp:CheckBox ID="chkSubject" runat="server" Text="Subject" /><br />

                                                        </li>
                                                        <li>
                                                                                                                <asp:CheckBox ID="chkTimes" runat="server" Text="Times" /><br />

                                                        </li>
                                                        <li>
                                                                                                                <asp:CheckBox ID="chkHours" runat="server" Text="Hours" /><br />

                                                        </li>
                                                        <li>
                                                                                                                <asp:CheckBox ID="chkTimeCategory" runat="server" Text="Time Category" /><br />

                                                        </li>
                                                        <li>
                                                                                                            <asp:CheckBox ID="chkClientCodeHA" runat="server" Text="Client Code" /><br />

                                                        </li>
                                                    </ul>
                                                </div>
                
                                            </div>
                                            <strong style="margin-top: 8px; margin-bottom: 8px;">
                                                <asp:Label ID="LabelEmployeeDisplayOptions" runat="server" TabIndex="0">Employee Display Options:</asp:Label><br />
                                            </strong>
                                            <asp:RadioButton ID="RadioButtonFirstName" runat="server" Text="First Name" GroupName="GroupingEmp" /><br />
                                            <asp:RadioButton ID="RadioButtonFullName" runat="server" Text="Nickname" GroupName="GroupingEmp" /><br />
                                        <ul class="calendar-list-styles">
                                            <li>
                                                                                            <asp:CheckBox ID="CheckBoxImage" runat="server" Text="Include Image" /><br />

                                            </li>
                                        </ul>
                                    </div>
                                    
                                </fieldset>
                                <div style="padding:20px 0px 0px 0px;width:100%;text-align:center;">
                                    <asp:Button ID="ButtonFilterSave" runat="server" Text="Apply" Width="300px" />
                                </div>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            </telerik:RadPageView>
            <telerik:RadPageView ID="RadPageViewReport" runat="server" ContentUrl="Calendar_Report.aspx" Height="1000px">
            </telerik:RadPageView>
            <telerik:RadPageView ID="RadPageViewAllocation" runat="server" Height="1000px">
                <telerik:RadScriptBlock ID="RadScriptBlock2" runat="server">
                    <script type="text/javascript">
                        function RowContextMenuJob(sender, eventArgs) {
                            var menu = $find("<%= RadContextMenu1.ClientID%>");
                            var evt = eventArgs.get_domEvent();

                            if (evt.target.tagName == "INPUT" || evt.target.tagName == "A") {
                                return;
                            }

                            var index = eventArgs.get_itemIndexHierarchical();
                            document.getElementById("radGridClickedRowIndex2").value = index;

                            var MasterTable = sender.get_masterTableView();
                            var row = MasterTable.get_dataItems()[eventArgs.get_itemIndexHierarchical()];
                            var job = MasterTable.getCellByColumnUniqueName(row, "Job");

                            if (job.innerHTML == '&nbsp;') {
                                var menuItem = menu.findItemByValue("Job");
                                menuItem.hide();
                                var menuItem2 = menu.findItemByValue("PS");
                                menuItem2.hide();
                            } else {
                                var menuItem = menu.findItemByValue("Job");
                                menuItem.show();
                                var menuItem2 = menu.findItemByValue("PS");
                                menuItem2.show();
                            }

                            menu.show(evt);

                            evt.cancelBubble = true;
                            evt.returnValue = false;

                            if (evt.stopPropagation) {
                                evt.stopPropagation();
                                evt.preventDefault();
                            }
                        }
                    </script>
                </telerik:RadScriptBlock>
                <table cellpadding="0" cellspacing="0" width="100%" align="center" border="0">
                    <tr>
                        <td align="center" rowspan="1" valign="top">
                            <div class="CollapsablePanel-Wrap">
                                <ew:CollapsablePanel ID="CollapsablePanel1" runat="server"
                                TitleText="Job Information">
                                <table id="Table13" cellpadding="2" cellspacing="0" width="100%" align="center">
                                    <tr>
                                        <td align="left" colspan="2" rowspan="2" valign="top">
                                            <fieldset>
                                                <div class="code-description-container">
                                                    <div class="code-description-label">
                                                        Dates:
                                                    </div>
                                                    <div class="code-description-code">
                                                        <telerik:RadDatePicker ID="RadDatePickerAllocationStartDate" runat="server" SkinID="RadDatePickerStandard">
                                                            <DateInput DateFormat="d" EmptyMessage="">
                                                                <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                                                            </DateInput>
                                                            <Calendar ID="CalendarAllocationStartDate" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                                                                <SpecialDays>
                                                                    <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="radcalendar-today">
                                                                    </telerik:RadCalendarDay>
                                                                </SpecialDays>
                                                            </Calendar>
                                                        </telerik:RadDatePicker>
                                                        through
                                                        &nbsp;
                                                        <telerik:RadDatePicker ID="RadDatePickerAllocationEndDate" runat="server" SkinID="RadDatePickerStandard">
                                                            <DateInput DateFormat="d" EmptyMessage="">
                                                                <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                                                            </DateInput>
                                                            <Calendar ID="CalendarAllocationEndDate" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                                                                <SpecialDays>
                                                                    <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="radcalendar-today">
                                                                    </telerik:RadCalendarDay>
                                                                </SpecialDays>
                                                            </Calendar>
                                                        </telerik:RadDatePicker>
                                                    </div>
                                                </div>
                                                <div class="code-description-container">
                                                    <div class="code-description-label">
                                                        Employee:
                                                    </div>
                                                    <div class="code-description-code">
                                                        <telerik:RadComboBox ID="RadComboBoxEmployeeAllocation" runat="server" Width="220px" SkinID="RadComboBoxStandard">
                                                        </telerik:RadComboBox>
                                                        <asp:Button ID="Button1" runat="server" Text="Assignments" Visible="false" />
                                                        <asp:Button ID="Button2" runat="server" Text="Availability" Visible="false" />
                                                    </div>
                                                </div>
                                                <div class="code-description-container">
                                                    <div class="code-description-label">
                                                        Summary Level:
                                                    </div>
                                                    <div class="code-description-code">
                                                        <asp:RadioButtonList ID="RadioButtonListAllocationLevel" runat="server" RepeatDirection="Horizontal"
                                                            RepeatLayout="Flow">
                                                            <asp:ListItem Text="Daily" Value="daily"></asp:ListItem>
                                                            <asp:ListItem Text="Weekly" Value="weekly"></asp:ListItem>
                                                            <asp:ListItem Text="Monthly" Value="monthly"></asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                            
                                                <div class="code-description-container">
                                                    <div class="code-description-label">                                            
                                                    </div>
                                                    <div class="code-description-code">                                            
                                                        <asp:Button ID="ButtonRefreshAllocation" runat="server" Text="Refresh" />
                                                            &nbsp;&nbsp;&nbsp;&nbsp;
                                                        <asp:Button ID="ButtonExportAllocation" runat="server" Text="Export" Visible="False" />
                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                        <asp:Button ID="ButtonAllAllocation" runat="server" Text="Show All" Visible="false" />
                                                    </div>
                                                </div>
                                            </fieldset>
                                        </td>
                                    </tr>
                                </table>
                                <table id="Table22" cellpadding="2" cellspacing="0" width="100%" align="center">
                                    <tr>
                                        <td colspan="2" rowspan="2" valign="top" align="left">
                                            <asp:Panel ID="PanelAllocation" runat="server" Visible="false">
                                                <fieldset>
                                                    <legend>FTE by Department</legend>
                                                    <asp:Label ID="LabelAllocation" runat="server" Text="No records to display"
                                                        Visible="false"></asp:Label>
                                                    <telerik:RadGrid ID="RadGridAllocationDepartment" runat="server" AllowSorting="true" EnableEmbeddedSkins="True"
                                                        Visible="true" Width="99%">
                                                        <MasterTableView DataKeyNames="Department" AutoGenerateColumns="true">
                                                            <ExpandCollapseColumn Resizable="False" Visible="False">
                                                                <HeaderStyle Width="20px" />
                                                            </ExpandCollapseColumn>
                                                            <RowIndicatorColumn Visible="False">
                                                                <HeaderStyle Width="20px" />
                                                            </RowIndicatorColumn>
                                                        </MasterTableView>
                                                        <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="true">
                                                            <Scrolling UseStaticHeaders="False" />
                                                            <Selecting AllowRowSelect="True" />
                                                        </ClientSettings>
                                                        <ExportSettings Excel-Format="Html" FileName="Allocation" IgnorePaging="true" OpenInNewWindow="true">
                                                        </ExportSettings>
                                                    </telerik:RadGrid>
                                                </fieldset>
                                            </asp:Panel>
                                            <asp:Panel ID="PanelAllocationEmployee" runat="server" Visible="false">
                                                <fieldset>
                                                    <legend>Percent Allocated by Employee</legend>
                                                    <telerik:RadGrid ID="RadGridAllocation" runat="server" AllowSorting="true" EnableEmbeddedSkins="True"
                                                        Visible="true" Width="99%">
                                                        <MasterTableView DataKeyNames="EMP_CODE" AutoGenerateColumns="true">
                                                            <ExpandCollapseColumn Resizable="False" Visible="False">
                                                                <HeaderStyle Width="20px" />
                                                            </ExpandCollapseColumn>
                                                            <RowIndicatorColumn Visible="False">
                                                                <HeaderStyle Width="20px" />
                                                            </RowIndicatorColumn>
                                                        </MasterTableView>
                                                        <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="true">
                                                            <Scrolling UseStaticHeaders="False" />
                                                            <Selecting AllowRowSelect="True" />
                                                        </ClientSettings>
                                                        <ExportSettings Excel-Format="Html" FileName="Allocation" IgnorePaging="true" OpenInNewWindow="true">
                                                        </ExportSettings>
                                                    </telerik:RadGrid>
                                                </fieldset>
                                            </asp:Panel>
                                            <asp:Panel ID="Panel1" runat="server" Visible="false">
                                                <telerik:RadGrid ID="RadGridWrapper" runat="server" ShowHeader="false" Visible="true"
                                                    BorderStyle="None">
                                                    <ExportSettings OpenInNewWindow="true" />
                                                    <MasterTableView AutoGenerateColumns="true">
                                                        <ItemTemplate>
                                                            <telerik:RadGrid ID="RadGridAllocationDepartmentGrid" runat="server" AllowSorting="true" EnableEmbeddedSkins="True" OnColumnCreated="RadGridAllDept_ColumnCreated"
                                                                Visible="true" Width="99%" OnNeedDataSource="RadGridAllDept_NeedDataSource" OnItemDataBound="RadGridAllDept_ItemDataBound" OnExportCellFormatting="RadGridAllDept_OnExportCellFormatting"
                                                                GridLines="Both">
                                                                <MasterTableView DataKeyNames="Department" AutoGenerateColumns="true">
                                                                    <Columns></Columns>
                                                                </MasterTableView>
                                                                <ExportSettings Excel-Format="Html" FileName="Allocation" IgnorePaging="true" OpenInNewWindow="true" ExportOnlyData="true">
                                                                </ExportSettings>
                                                            </telerik:RadGrid>
                                                            <br />
                                                            <telerik:RadGrid ID="RadGridAllocationGrid" runat="server" AllowSorting="true" EnableEmbeddedSkins="True" OnColumnCreated="RadGridAll_ColumnCreated"
                                                                Visible="true" Width="99%" OnNeedDataSource="RadGridAll_NeedDataSource" OnItemDataBound="RadGridAll_ItemDataBound" OnExportCellFormatting="RadGridAll_OnExportCellFormatting"
                                                                GridLines="Both">
                                                                <MasterTableView DataKeyNames="EMP_CODE" AutoGenerateColumns="true">
                                                                    <Columns></Columns>
                                                                </MasterTableView>
                                                                <ExportSettings Excel-Format="Html" FileName="Allocation" IgnorePaging="true" OpenInNewWindow="true" ExportOnlyData="true">
                                                                </ExportSettings>
                                                            </telerik:RadGrid>
                                                            <br />
                                                        </ItemTemplate>
                                                    </MasterTableView>
                                                </telerik:RadGrid>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                </table>
                            </ew:CollapsablePanel>
                            </div>
                            <table id="Table10" cellpadding="2" cellspacing="0" width="100%">
                                <tr>
                                    <td style="vertical-align:middle; text-align:center;" class="sub-header sub-header-color">
                                        <br />
                                        <asp:Label ID="lblEmployeeAllocation" runat="server"></asp:Label>
                                        &nbsp;&nbsp;
                                        <asp:ImageButton ID="ImageButtonExport" runat="server" SkinID="ImageButtonExportExcel" Visible="false" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top">
                                        <fieldset>
                                            <table>
                                                <tr>
                                                    <asp:Panel ID="PanelEmployeeAllocation" runat="server" Visible="false">
                                                        <td>
                                                            <table id="Table11" align="center" cellpadding="0" cellspacing="0" width="500">
                                                                <tr>
                                                                    <td>
                                                                        <telerik:RadBinaryImage runat="server" ID="RadBinaryImage2" ImageAlign="Middle" AutoAdjustImageControlSize="false"
                                                                            Width="70px" Height="70px" Visible="false" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="LabelEmployeeAllocation" runat="server" Text="" Visible="False"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </asp:Panel>
                                                    <td>
                                                        <table id="Table12" align="left" cellpadding="2" cellspacing="0" width="400">
                                                            <tr>
                                                                <td width="300">
                                                                    <asp:Label ID="lblTotalHoursEmpAvailableAllocation" runat="server" Text="Standard Hours Available:"
                                                                        Visible="False"></asp:Label>
                                                                </td>
                                                                <td align="right" width="120">
                                                                    <asp:Label ID="lblTotalHoursEmpAvailableAllocationNum" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td width="300">
                                                                    <asp:Label ID="lblTotalAppointmentHoursAllocation" runat="server" Text="Appointment Hours:" Visible="False"></asp:Label>
                                                                </td>
                                                                <td align="right" width="120">
                                                                    <asp:Label ID="lblTotalAppointmentHoursAllocationNum" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td width="300">
                                                                    <asp:Label ID="lblTotalHoursOffEmpAllocation" runat="server" Text="Hours Off:" Visible="False"></asp:Label>
                                                                </td>
                                                                <td align="right" width="120">
                                                                    <asp:Label ID="lblTotalHoursOffEmpAllocationNum" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td width="300">
                                                                    <asp:Label ID="lblTotalHoursAssignedAllocation" runat="server" Text="Hours Assigned to Tasks:"
                                                                        Visible="False"></asp:Label>
                                                                </td>
                                                                <td align="right" width="120">
                                                                    <asp:Label ID="lblTotalHoursAssignedAllocationNum" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td width="300">
                                                                    <asp:Label ID="lblVarianceEmpAllocation" runat="server" Text="Variance:" Visible="False"></asp:Label>
                                                                </td>
                                                                <td align="right" width="120">
                                                                    <asp:Label ID="lblVarianceEmpAllocationNum" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td width="300">
                                                                    <asp:Label ID="lblDirectHoursGoalAllocation" runat="server" Text="% of Direct Hours Goal:" Visible="False"></asp:Label>
                                                                </td>
                                                                <td align="right" width="120">
                                                                    <asp:Label ID="lblDirectHoursGoalAllocationNum" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;
                                                    </td>
                                                    <td style="white-space:nowrap;">
                                                        <br />
                                                        <asp:TextBox ID="TextBoxAllocationTasks" runat="server" BackColor="#D0ECBB" ReadOnly="true" Width="10px" Visible="false" SkinID="TextBoxStandard"></asp:TextBox>
                                                        <asp:Label ID="LabelAllocationTasks" runat="server" Text="Assigned Tasks" Visible="false"></asp:Label>
                                                        <asp:TextBox ID="TextBoxAllocationAppointments" runat="server" BackColor="#BBD0EC" ReadOnly="true" Width="10px" Visible="false" SkinID="TextBoxStandard"></asp:TextBox>
                                                        <asp:Label ID="LabelAllocationAppointments" runat="server" Text="Appointments" Visible="false"></asp:Label>
                                                        <asp:TextBox ID="TextBoxAllocationHours" runat="server" BackColor="#FFF5B7" ReadOnly="true" Width="10px" Visible="false" SkinID="TextBoxStandard"></asp:TextBox>
                                                        <asp:Label ID="LabelAllocationHours" runat="server" Text="Hours off" Visible="false"></asp:Label>
                                                        <asp:TextBox ID="TextBoxAllocationEvent" runat="server" BackColor="#ECBBBB" ReadOnly="true" Width="10px" Visible="false" SkinID="TextBoxStandard"></asp:TextBox>
                                                        <asp:Label ID="LabelAllocationEvent" runat="server" Text="Event Tasks" Visible="false"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </fieldset>
                                    </td>
                                </tr>
                            </table>
                            <input type="hidden" id="radGridClickedRowIndex2" name="radGridClickedRowIndex2" />
                            <telerik:RadGrid ID="RadGridAllocationJob" runat="server" AllowSorting="true" EnableEmbeddedSkins="True"
                                Visible="true" Width="99%" ShowFooter="true">
                                <ClientSettings>
                                    <ClientEvents OnRowContextMenu="RowContextMenuJob" />
                                </ClientSettings>
                                <MasterTableView DataKeyNames="EMP_CODE,Job,Component" AutoGenerateColumns="true">
                                    <ExpandCollapseColumn Resizable="False" Visible="False">
                                        <HeaderStyle Width="20px" />
                                    </ExpandCollapseColumn>
                                    <RowIndicatorColumn Visible="False">
                                        <HeaderStyle Width="20px" />
                                    </RowIndicatorColumn>
                                </MasterTableView>
                                <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="true">
                                    <Scrolling UseStaticHeaders="False" />
                                    <Selecting AllowRowSelect="True" />
                                </ClientSettings>
                                <ExportSettings Excel-Format="Html" FileName="Allocation" IgnorePaging="true" OpenInNewWindow="true">
                                </ExportSettings>
                            </telerik:RadGrid>
                        </td>
                    </tr>
                </table>
                <telerik:RadContextMenu ID="RadContextMenu1" runat="server" EnableRoundedCorners="false"
                    EnableShadows="true">
                    <Items>
                        <telerik:RadMenuItem Text="Go to Job" Value="Job" />
                        <telerik:RadMenuItem Text="Go to Schedule" Value="PS" />
                    </Items>
                </telerik:RadContextMenu>
            </telerik:RadPageView>
            <telerik:RadPageView ID="RadPageViewActualization" runat="server">
            <asp:UpdatePanel runat="server" ID="UpdatePanel2" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                <telerik:RadScriptBlock ID="RadScriptBlock4" runat="server">
                    <script type="text/javascript">
                        function RowContextMenu(sender, eventArgs) {
                            var menu = $find("<%= RadMenu1Act.ClientID %>");
                            var menu2 = $find("<%= RadMenu2Act.ClientID%>");
                            var menu3 = $find("<%= RadMenu3Act.ClientID%>");

                            var evt = eventArgs.get_domEvent();

                            if (evt.target.tagName == "INPUT" || evt.target.tagName == "A") {
                                return;
                            }

                            var index = eventArgs.get_itemIndexHierarchical();
                            document.getElementById("radGridClickedRowIndex").value = index;

                            var MasterTable = sender.get_masterTableView();
                            var row = MasterTable.get_dataItems()[eventArgs.get_itemIndexHierarchical()];
                            var cell = MasterTable.getCellByColumnUniqueName(row, "columnREC");
                            var job = MasterTable.getCellByColumnUniqueName(row, "columnJob");

                            if (job.innerHTML == '&nbsp;') {
                                var menuItem = menu2.findItemByValue("Job");
                                menuItem.hide();
                                var menuItem2 = menu2.findItemByValue("PS");
                                menuItem2.hide();
                            } else {
                                var menuItem = menu2.findItemByValue("Job");
                                menuItem.show();
                                var menuItem2 = menu2.findItemByValue("PS");
                                menuItem2.show();
                            }

                            if (cell.innerHTML == 'C' || cell.innerHTML == 'M' || cell.innerHTML == 'TD' || cell.innerHTML == 'EL' || cell.innerHTML == 'A' || cell.innerHTML == 'H' || cell.innerHTML == 'ADA' || cell.innerHTML == 'AHO' || cell.innerHTML == 'ADAHO') {
                                menu2.show(evt);
                            } else if (cell.innerHTML == 'AS') {
                                menu3.show(evt);
                            } else {
                                menu.show(evt);
                            }

                            evt.cancelBubble = true;
                            evt.returnValue = false;

                            if (evt.stopPropagation) {
                                evt.stopPropagation();
                                evt.preventDefault();
                            }
                        }

                        function OnRequestStart(sender, args)
                        {
                            if (args.get_eventTarget().indexOf("ButtonExportAct") >= 0)
                                args.set_enableAjax(false);

                            if (args.get_eventTarget().indexOf("imgbtnExportAct") >= 0)
                                args.set_enableAjax(false);
                        }

                    </script>
                </telerik:RadScriptBlock>
                <div class="CollapsablePanel-Wrap">
                   <ew:CollapsablePanel ID="CollapsablePanel2" runat="server" TitleText="Job Information">
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Dates:
                        </div>
                        <div class="code-description-description">
                            <telerik:RadDatePicker ID="RadDatePickerActualizationStartDate" runat="server" SkinID="RadDatePickerStandard">
                                <DateInput DateFormat="d" EmptyMessage="">
                                    <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                                </DateInput>
                                <Calendar ID="Calendar1" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                                    <SpecialDays>
                                        <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="radcalendar-today">
                                        </telerik:RadCalendarDay>
                                    </SpecialDays>
                                </Calendar>
                            </telerik:RadDatePicker>&nbsp;through&nbsp;
                            <telerik:RadDatePicker ID="RadDatePickerActualizationEndDate" runat="server" SkinID="RadDatePickerStandard">
                                <DateInput DateFormat="d" EmptyMessage="">
                                    <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                                </DateInput>
                                <Calendar ID="Calendar2" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                                    <SpecialDays>
                                        <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="radcalendar-today">
                                        </telerik:RadCalendarDay>
                                    </SpecialDays>
                                </Calendar>
                            </telerik:RadDatePicker>&nbsp;  
                            &nbsp;
                            <asp:ImageButton ID="ImageButtonBookmark" runat="server" ToolTip="Bookmarks" SkinID="ImageButtonBookmark" />
                        </div>
                    </div> 
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Employee:
                        </div>
                        <div class="code-description-description">
                            <telerik:RadComboBox ID="ddEmployeeAct" runat="server" Width="250" SkinID="RadComboBoxStandard">
                            </telerik:RadComboBox>
                            <asp:Button ID="btnAssignmentsAct" runat="server" Text="Assignments" Visible="false" />
                            <asp:Button ID="btnAvailAct" runat="server" Text="Availability" Visible="false" />
                            &nbsp;&nbsp;
                            <asp:Button ID="ButtonRefreshAct" runat="server" Text="Refresh" />
                            &nbsp;
                            <asp:Button ID="ButtonExportAct" runat="server" Text="Export" Visible="False" />
                            &nbsp;
                            <asp:Button ID="ButtonAllAct" runat="server" Text="Show All Projects" Visible="false" />
                        </div>
                    </div>
                    <div id="Div1" runat="server" class="code-description-container">
                        <div class="code-description-label">
                            Summary Level:
                        </div>
                        <div class="code-description-description">
                            <asp:RadioButtonList ID="RblActualizationSummaryLevel" runat="server" RepeatDirection="Horizontal"
                                RepeatLayout="Flow">
                                <asp:ListItem Text="Daily" Value="daily"></asp:ListItem>
                                <asp:ListItem Text="Weekly" Value="weekly" Selected="true"></asp:ListItem>
                                <asp:ListItem Text="Monthly" Value="monthly"></asp:ListItem>
                            </asp:RadioButtonList>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="CheckBoxOmit" runat="server" Text="Omit Beginning Balance" />
                            &nbsp;<asp:CheckBox ID="CheckBoxShowPercent" runat="server" Text="Show Percent" />
                        </div>
                    </div>
                    <div class="code-description-container" style="display: none;">
                        <div class="code-description-label">
                        </div>
                        <div class="code-description-description">
                            <asp:CheckBox ID="CheckBox2" runat="server" Text="Actualize" Visible="False" Width="80px" />
                        </div>
                    </div>
                    <div id="DivZeroHoursAct" runat="server" class="code-description-container">
                        <div class="code-description-label">
                            <div id="DivZeroHoursColorAct" runat="server" style="margin: 0px 0px 0px 137px; height: 30px; width: 30px; border-radius: 50%; border: 1px solid #cecece;">
                            </div>
                        </div>
                        <div class="code-description-description">
                            Zero hours
                        </div>
                    </div>
                    <div id="DivLessThanHoursAct" runat="server" class="code-description-container">
                        <div class="code-description-label">
                            <div id="DivLessThanHoursColorAct" runat="server" style="margin: 0px 0px 0px 137px; height: 30px; width: 30px; border-radius: 50%; border: 0px solid #cecece;">
                            </div>
                        </div>
                        <div class="code-description-description">
                            Less than
                        <telerik:RadNumericTextBox ID="RadNumericTextBoxLessThanPercentageAct" runat="server" Width="70" MinValue="0" MaxValue="150" IncrementSettings-Step="1" NumberFormat-DecimalDigits="2">
                        </telerik:RadNumericTextBox>
                            % of the Hours Available
                        </div>
                    </div>
                    <div id="DivLessThanAndGreaterThanHoursAct" runat="server" class="code-description-container">
                        <div class="code-description-label">
                            <div id="DivLessThanAndGreaterThanHoursColorAct" runat="server" style="margin: 0px 0px 0px 137px; height: 30px; width: 30px; border-radius: 50%; border: 0px solid #cecece;">
                            </div>
                        </div>
                        <div class="code-description-description">
                            Greater than or Equal to
                        <telerik:RadNumericTextBox ID="RadNumericTextBoxLessThanAndGreaterThanHours_GreaterThanAct" runat="server" Width="70" MinValue="0" MaxValue="150" IncrementSettings-Step="1" NumberFormat-DecimalDigits="2">
                        </telerik:RadNumericTextBox>
                            % of the Hours Available and Less than
                        <telerik:RadNumericTextBox ID="RadNumericTextBoxLessThanAndGreaterThanHours_LessThanAct" runat="server" Width="70" MinValue="0" MaxValue="150" IncrementSettings-Step="1" NumberFormat-DecimalDigits="2">
                        </telerik:RadNumericTextBox>
                            % of the Hours Available
                        </div>
                    </div>
                    <div id="DivGreaterThanHoursAct" runat="server" class="code-description-container">
                        <div class="code-description-label">
                            <div id="DivGreaterThanHoursColorAct" runat="server" style="margin: 0px 0px 0px 137px; height: 30px; width: 30px; border-radius: 50%; border: 0px solid #cecece;">
                            </div>
                        </div>
                        <div class="code-description-description">
                            Greater than or Equal to
                        <telerik:RadNumericTextBox ID="RadNumericTextBoxGreaterThanHoursAct" runat="server" Width="70" MinValue="0" MaxValue="150" IncrementSettings-Step="1" NumberFormat-DecimalDigits="2">
                        </telerik:RadNumericTextBox>
                            % of the Hours Available
                        </div>
                    </div>
                    <%--                    <div class="code-description-container">
                        <div class="code-description-label">
                        </div>
                        <div class="code-description-description">
                            <asp:Button ID="ButtonRefresh" runat="server" Text="Refresh" />
                            &nbsp;&nbsp;
                            <asp:Button ID="ButtonExport" runat="server" Text="Export" Visible="False" />
                            &nbsp;&nbsp;
                            <asp:Button ID="ButtonAll" runat="server" Text="Show All Projects" Visible="false" />
                        </div>
                    </div>--%>
                
                    <telerik:RadGrid ID="RadGridActualization" runat="server" AllowSorting="true" EnableEmbeddedSkins="True"
                        Visible="true" Width="99%" Height="600px">
                        <MasterTableView DataKeyNames="EMP_CODE" AutoGenerateColumns="true">
                            <ExpandCollapseColumn Resizable="False" Visible="False">
                                <HeaderStyle Width="20px" />
                            </ExpandCollapseColumn>
                            <RowIndicatorColumn Visible="False">
                                <HeaderStyle Width="20px" />
                            </RowIndicatorColumn>
                        </MasterTableView>
                        <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="true">
                            <Scrolling AllowScroll="true" UseStaticHeaders="false" />
                            <Selecting AllowRowSelect="True" />
                            <Resizing AllowResizeToFit="true" />
                        </ClientSettings>
                    </telerik:RadGrid>
                    </ew:CollapsablePanel>
                </div>
                <table id="Table4" cellpadding="2" cellspacing="0" width="100%">
                    <tr>
                        <td style="vertical-align:middle; text-align:center;" class="sub-header sub-header-color">
                            <br />
                            <asp:Label ID="lblEmployeeAct" runat="server"></asp:Label>&nbsp;&nbsp;
                             <asp:ImageButton ID="imgbtnExportAct" runat="server" SkinID="ImageButtonExportExcel" Visible="false" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">
                            <div id="DivEmployeePictureAct" runat="server">
                                <telerik:RadBinaryImage runat="server" ID="RadBinaryImage3" ImageAlign="Middle" AutoAdjustImageControlSize="false"
                                    Width="70px" Height="70px" Visible="false" />
                                <asp:Label ID="LabelEmployeeAct" runat="server" Text="" Visible="False"></asp:Label>
                            </div>
                            <fieldset>
                                <table>
                                    <tr>
                                        <td>
                                            <table id="Table5" align="left" cellpadding="2" cellspacing="0" width="400">
                                                <tr>
                                                    <td width="300">
                                                        <asp:Label ID="lblTotalHoursEmpAvailableAct" runat="server" Text="Standard Hours Available:"
                                                            Visible="False"></asp:Label>
                                                    </td>
                                                    <td align="right" width="120">
                                                        <asp:Label ID="lblTotalHoursEmpAvailableNumAct" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="300">
                                                        <asp:Label ID="lblTotalAppointmentHoursAct" runat="server" Text="Appointment Hours:" Visible="False"></asp:Label>
                                                    </td>
                                                    <td align="right" width="120">
                                                        <asp:Label ID="lblTotalAppointmentHoursNumAct" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="300">
                                                        <asp:Label ID="lblTotalHoursOffEmpAct" runat="server" Text="Hours Off:" Visible="False"></asp:Label>
                                                    </td>
                                                    <td align="right" width="120">
                                                        <asp:Label ID="lblTotalHoursOffEmpNumAct" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="300">
                                                        <asp:Label ID="lblTotalHoursAssignedAct" runat="server" Text="Hours Assigned:"
                                                            Visible="False"></asp:Label>
                                                    </td>
                                                    <td align="right" width="120">
                                                        <asp:Label ID="lblTotalHoursAssignedNumAct" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="300">
                                                        <asp:Label ID="lblVarianceEmpAct" runat="server" Text="Variance:" Visible="False"></asp:Label>
                                                    </td>
                                                    <td align="right" width="120">
                                                        <asp:Label ID="lblVarianceEmpNumAct" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="300">
                                                        <asp:Label ID="lblDirectHoursGoalAct" runat="server" Text="% of Direct Hours Goal:" Visible="False"></asp:Label>
                                                    </td>
                                                    <td align="right" width="120">
                                                        <asp:Label ID="lblDirectHoursGoalNumAct" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;
                                        </td>
                                        <td style="white-space:nowrap;">
                                            <br />
                                            <asp:TextBox ID="txtTasksAct" runat="server"  ReadOnly="true" Width="10px" SkinID="TextBoxStandard"></asp:TextBox>
                                            <asp:Label ID="Label20" runat="server" Text="Assigned Tasks"></asp:Label>
                                            <asp:TextBox ID="TextBox3" runat="server" BackColor="#B2C9E0" ReadOnly="true" Width="10px" SkinID="TextBoxStandard"></asp:TextBox>
                                            <asp:Label ID="Label21" runat="server" Text="Appointments"></asp:Label>
                                            <asp:TextBox ID="TextBox4" runat="server" BackColor="#F6E3BC" ReadOnly="true" Width="10px" SkinID="TextBoxStandard"></asp:TextBox>
                                            <asp:Label ID="Label22" runat="server" Text="Hours off"></asp:Label>
                                            <asp:TextBox ID="TextBox5" runat="server" BackColor="#F7D5DB" ReadOnly="true" Width="10px" Visible="false" SkinID="TextBoxStandard"></asp:TextBox>
                                            <asp:Label ID="Label23" runat="server" Text="Event Tasks" Visible="false"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>
                        </td>
                    </tr>
                </table>
                <input type="hidden" id="radGridClickedRowIndex" name="radGridClickedRowIndex" />
                <telerik:RadGrid ID="RadGridActAssignments" runat="server" AllowSorting="true" GridLines="None"
                    ShowFooter="true" EnableEmbeddedSkins="True" Visible="false" Width="99%">
                    <ClientSettings>
                        <ClientEvents OnRowContextMenu="RowContextMenu" />
                    </ClientSettings>
                    <MasterTableView AllowMultiColumnSorting="true" AutoGenerateColumns="false" DataKeyNames="JOB_NUMBER,JOB_COMPONENT_NBR,CL_CODE,DIV_CODE,PRD_CODE,SEQ_NBR,NON_TASK_ID,REC_TYPE,JOB_COMP_DESC,CL_NAME,ALERT_ID, SPRINT_ID,ALERT_CAT_ID">
                        <Columns>
                            <telerik:GridBoundColumn DataField="OFFICE_CODE" HeaderText="Office" UniqueName="column10"
                                HeaderStyle-VerticalAlign="Bottom" HeaderStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Middle"
                                ItemStyle-HorizontalAlign="Left">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="DP_TM_CODE" HeaderText="Dept" UniqueName="column10"
                                HeaderStyle-VerticalAlign="Bottom" HeaderStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Middle"
                                ItemStyle-HorizontalAlign="Left">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="DEF_TRF_CODE" HeaderText="Role" UniqueName="column111"
                                HeaderStyle-VerticalAlign="Bottom" HeaderStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Middle"
                                ItemStyle-HorizontalAlign="Left">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="CL_NAME" HeaderText="Client" UniqueName="column11"
                                HeaderStyle-VerticalAlign="Bottom" HeaderStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Middle"
                                ItemStyle-HorizontalAlign="Left">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="DIV_CODE" HeaderText="Division" UniqueName="column12" Visible="false"
                                HeaderStyle-VerticalAlign="Bottom" HeaderStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Middle"
                                ItemStyle-HorizontalAlign="Left">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="PRD_CODE" HeaderText="Product" UniqueName="column13" Visible="false"
                                HeaderStyle-VerticalAlign="Bottom" HeaderStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Middle"
                                ItemStyle-HorizontalAlign="Left">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="JOB_NUMBER" DataFormatString="{0:D6}" HeaderText="Project" SortExpression="JOB_NUMBER"
                                HeaderStyle-HorizontalAlign="left" HeaderStyle-VerticalAlign="Bottom" ItemStyle-HorizontalAlign="left"
                                ItemStyle-VerticalAlign="Middle" UniqueName="columnJob">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="JOB_COMPONENT_NBR" DataFormatString="{0:D3}" Visible="false"
                                HeaderText="Job Component" HeaderStyle-HorizontalAlign="Right" HeaderStyle-VerticalAlign="Bottom"
                                ItemStyle-HorizontalAlign="Right" ItemStyle-VerticalAlign="Middle" UniqueName="column2">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="JOB_COMP_DESC" HeaderText="Job Description" UniqueName="column3" Visible="false"
                                HeaderStyle-VerticalAlign="Bottom" HeaderStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Middle" ItemStyle-CssClass="radgrid-description-column"
                                ItemStyle-HorizontalAlign="Left">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="FNC_CODE" HeaderText="Task Code" UniqueName="column4" Display="False"
                                HeaderStyle-VerticalAlign="Bottom" HeaderStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Middle"
                                ItemStyle-HorizontalAlign="Left">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="TASK_DESCRIPTION" HeaderText="Description"
                                HeaderStyle-VerticalAlign="Bottom" HeaderStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Middle" ItemStyle-CssClass="radgrid-description-column"
                                ItemStyle-HorizontalAlign="Left" UniqueName="column5">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="TASK_START_DATE" DataFormatString="{0:M/dd/yyyy }" ItemStyle-CssClass="radgrid-shortdate-column"
                                HeaderStyle-HorizontalAlign="Right" HeaderStyle-VerticalAlign="Bottom" ItemStyle-HorizontalAlign="Right"
                                ItemStyle-VerticalAlign="Middle" HeaderText="Start Date" UniqueName="column7">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="JOB_REVISED_DATE" DataFormatString="{0:M/dd/yyyy }" ItemStyle-CssClass="radgrid-shortdate-column"
                                HeaderStyle-HorizontalAlign="Right" HeaderStyle-VerticalAlign="Bottom" ItemStyle-HorizontalAlign="Right"
                                ItemStyle-VerticalAlign="Middle" HeaderText="Due Date" UniqueName="column8">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="JB" HeaderText="Hours Allowed" HeaderStyle-HorizontalAlign="Right" HeaderTooltip="Total hours allowed for the assignment date range"
                                DataFormatString="{0:0.00}" HeaderStyle-VerticalAlign="Bottom" ItemStyle-HorizontalAlign="Right"
                                ItemStyle-VerticalAlign="Middle" FooterStyle-HorizontalAlign="Right" UniqueName="column6">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="JOB_HRS" HeaderText="Beginning Balance" HeaderStyle-HorizontalAlign="Right" HeaderTooltip="Beginning Balance up to the current date"
                                DataFormatString="{0:0.00}" HeaderStyle-VerticalAlign="Bottom" ItemStyle-HorizontalAlign="Right"
                                ItemStyle-VerticalAlign="Middle" FooterStyle-HorizontalAlign="Right" UniqueName="column6">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="HRS_POSTED" HeaderText="Hours Posted" HeaderStyle-HorizontalAlign="Right" HeaderTooltip="Hours Posted up to the current date"
                                DataFormatString="{0:0.00}" HeaderStyle-VerticalAlign="Bottom" ItemStyle-HorizontalAlign="Right"
                                ItemStyle-VerticalAlign="Middle" FooterStyle-HorizontalAlign="Right" UniqueName="column36">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="HRS_LEFT" HeaderText="Hours Left" HeaderStyle-HorizontalAlign="Right" HeaderTooltip="Hours left"
                                DataFormatString="{0:0.00}" HeaderStyle-VerticalAlign="Bottom" ItemStyle-HorizontalAlign="Right"
                                ItemStyle-VerticalAlign="Middle" FooterStyle-HorizontalAlign="Right" UniqueName="column76">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="DISTRIBUTED_HRS" HeaderText="Allocated Hours" HeaderStyle-HorizontalAlign="Right" HeaderTooltip="Allocated Hours"
                                DataFormatString="{0:0.00}" HeaderStyle-VerticalAlign="Bottom" ItemStyle-HorizontalAlign="Right"
                                ItemStyle-VerticalAlign="Middle" FooterStyle-HorizontalAlign="Right" UniqueName="column76">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="TASK_TOTAL_WORKING_DAYS" HeaderText="Working Days"
                                HeaderStyle-HorizontalAlign="Right" HeaderStyle-VerticalAlign="Bottom" ItemStyle-HorizontalAlign="Right"
                                ItemStyle-VerticalAlign="Middle" UniqueName="ColWORKING_DAYS_IN_TASK_RANGE">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="HOURS_PER_DAY" HeaderText="Hours per<br/>Work Day" 
                                HeaderStyle-HorizontalAlign="Right" DataFormatString="{0:0.00}" HeaderStyle-VerticalAlign="Bottom"
                                ItemStyle-HorizontalAlign="Right" ItemStyle-VerticalAlign="Middle" UniqueName="ColHRS_PER_DAY">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="ADJ_JOB_HRS" HeaderText="Adjusted<br/>Hours Assigned" Display="False"
                                DataFormatString="{0:0.00}" HeaderStyle-HorizontalAlign="Right" HeaderStyle-VerticalAlign="Bottom"
                                ItemStyle-HorizontalAlign="Right" ItemStyle-VerticalAlign="Middle" FooterStyle-HorizontalAlign="Right"
                                UniqueName="ColADJ_JOB_HRS">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="EMP_CODE" HeaderText="Employee" UniqueName="column9" 
                                HeaderStyle-VerticalAlign="Bottom" HeaderStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Middle"
                                ItemStyle-HorizontalAlign="Left" Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="SEQ_NBR" HeaderText="" UniqueName="column9" HeaderStyle-VerticalAlign="Bottom"
                                HeaderStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Left"
                                Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="REC_TYPE" HeaderText="" UniqueName="columnREC" HeaderStyle-VerticalAlign="Bottom"
                                HeaderStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Left"
                                Display="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn Visible="True" UniqueName="ColPS">
                                <HeaderStyle CssClass="radgrid-icon-column" />
                                <ItemStyle CssClass="radgrid-icon-column" />
                                <FooterStyle CssClass="radgrid-icon-column" />
                                <ItemTemplate>
                                    <div id="DivGoToTask" runat="server" class="icon-background background-color-sidebar">
                                        <asp:LinkButton ID="LinkButtonTask" runat="server" CssClass="icon-text" CommandName="GoToTask" ToolTip="Go to Task">T</asp:LinkButton>
                                    </div>
                                    <div id="DivGoToAssignment" runat="server" class="icon-background background-color-sidebar">
                                        <asp:LinkButton ID="LinkButtonAssignment" runat="server" CssClass="icon-text" CommandName="GoToAssignment" ToolTip="Go to Assignment">A</asp:LinkButton>
                                    </div>
                                    <div id="DivGoToActivity" runat="server" class="icon-background background-color-sidebar">
                                        <asp:LinkButton ID="LinkButtonActivity" runat="server" CssClass="icon-text" CommandName="GoToActivity" ToolTip="Go to Activity">A</asp:LinkButton>
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                        <ExpandCollapseColumn Resizable="False" Visible="False">
                            <HeaderStyle Width="20px" />
                        </ExpandCollapseColumn>
                        <RowIndicatorColumn Visible="False">
                            <HeaderStyle Width="20px" />
                        </RowIndicatorColumn>
                    </MasterTableView>
                </telerik:RadGrid>
                <telerik:RadContextMenu ID="RadMenu1Act" runat="server" EnableRoundedCorners="false"
                    EnableShadows="true">
                    <Items>
                        <telerik:RadMenuItem Text="Edit" Value="Task" />
                        <telerik:RadMenuItem Text="Edit Assignee" Value="EditAssignment" />
                        <telerik:RadMenuItem Text="Go to Job" Value="Job" />
                        <telerik:RadMenuItem Text="Go to Schedule" Value="PS" />
                    </Items>
                </telerik:RadContextMenu>
                <telerik:RadContextMenu ID="RadMenu2Act" runat="server" EnableRoundedCorners="false"
                    EnableShadows="true">
                    <Items>
                        <telerik:RadMenuItem Text="Edit Activity" Value="Task" />
                        <telerik:RadMenuItem Text="Go to Job" Value="Job" />
                        <telerik:RadMenuItem Text="Go to Schedule" Value="PS" />
                    </Items>
                </telerik:RadContextMenu>
                <telerik:RadContextMenu ID="RadMenu3Act" runat="server" EnableRoundedCorners="false"
                    EnableShadows="true">
                    <Items>
                        <telerik:RadMenuItem Text="Edit Assignment" Value="Assignment" />
                        <telerik:RadMenuItem Text="Go to Job" Value="Job" />
                        <telerik:RadMenuItem Text="Go to Schedule" Value="PS" />
                    </Items>
                </telerik:RadContextMenu>
                <telerik:RadGrid ID="RadGrid4" runat="server" AllowSorting="false" AutoGenerateColumns="False"
                    EnableEmbeddedSkins="True" GridLines="None" Visible="false" Width="100%">
                    <MasterTableView>
                        <ExpandCollapseColumn Resizable="False" Visible="False">
                            <HeaderStyle Width="20px" />
                        </ExpandCollapseColumn>
                        <RowIndicatorColumn Visible="False">
                            <HeaderStyle Width="20px" />
                        </RowIndicatorColumn>
                    </MasterTableView>
                    <ClientSettings>
                        <Scrolling UseStaticHeaders="False" />
                    </ClientSettings>
                    <ExportSettings FileName="Employee Actualization" IgnorePaging="True" OpenInNewWindow="True">
                    </ExportSettings>
                </telerik:RadGrid>
                </ContentTemplate>
            </asp:UpdatePanel>
            </telerik:RadPageView>
        </telerik:RadMultiPage>
    </div>

    <asp:GridView ID="GridView1" runat="server">
    </asp:GridView>
</asp:Content>
