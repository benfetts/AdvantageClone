@ModelType AdvantageFramework.ViewModels.Employee.Timesheet.TimesheetViewModel
@Scripts.Render("~/JScripts/kendo.listview.min.js")

    <div id="day-view-refresh">
        <div style="vertical-align: top !important; clear:both; padding: 5px 10px 5px 10px;">
            <table class="centered">
                <tr>
                    <td id="CopyCell" class="copy-column" style="@Html.Raw(ViewData("PanelCSS"))">
                        <div id="copyFromPanel" class="copy-from-panel" style="width: 330px;">
                            <div style="margin-top: 0px; margin-bottom: 10px;">
                                <span style="font-weight: bold;">Copy From</span>
                            </div>
                            <div>
                                <div style="display: inline-block;">
                                    <select id='copyFrom' onchange='copyFromSelect(this)' style="width: 230px;">
                                        <option value=''>[Please select]</option>
                                        <option value='projects'>Projects</option>
                                        <option value='templates'>Time Template</option>
                                        <option value='calendar'>Calendar</option>
                                        <option value='recent-assignments'>My Recent Assignments</option>
                                        <option value='recent-jobs'>My Recent Jobs</option>
                                    </select>
                                </div>
                                <div style="display: inline-block;">
                                    <button class="k-button wv-icon-button wv-neutral" style="height: 33px;" onclick="refreshCopyFromList()"><span class='wvi wvi-refresh' title="Refresh"></span></button>
                                </div>
                                <div style="display: inline-block;">
                                    <button id="copyFromSettingsButton" class="k-button wv-icon-button wv-settings" style="height: 33px;" onclick="copyFromSettingsButtonClick()" title="No options available."><span class='wvi wvi-gearwheel'></span></button>
                                </div>
                            </div>
                            <div>
                                <div id="copyFromMyProjectsContainer" class="copy-from-container">
                                    <div class="copy-from-search-wrapper-container">
                                        <div class="input-group search-wrapper input-group-search-wrapper-spacer">
                                            <input id="copyFromMyProjectSearchInput" type="text" class="ts-search-textbox copy-from-search-input" placeholder="" onkeyup="filterCopyFromMyProjectsDataSource(this)">
                                            <div class="input-group-addon">
                                                <span class="glyphicon glyphicon-search"></span>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="copy-from-list-view-container">
                                        <div id="copyFromMyProjectsListView" class="copy-from-list"></div>
                                    </div>
                                </div>
                                <div id="copyFromRecentAssignmentsContainer" class="copy-from-container">
                                    <div class="copy-from-search-wrapper-container">
                                        <div class="input-group search-wrapper input-group-search-wrapper-spacer">
                                            <input id="copyFromRecentAssignmentsSearchInput" type="text" class="ts-search-textbox copy-from-search-input" placeholder="" 
                                                onkeyup="filterCopyFromRecentAssignmentsDataSource(this)">
                                            <div class="input-group-addon">
                                                <span class="glyphicon glyphicon-search"></span>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="copy-from-list-view-container">
                                        <div id="copyFromRecentAssignmentsListView" class="copy-from-list"></div>
                                    </div>
                                </div>
                                <div id="copyFromRecentJobsContainer" class="copy-from-container">
                                    <div class="copy-from-search-wrapper-container">
                                        <div class="input-group search-wrapper input-group-search-wrapper-spacer">
                                            <input id="copyFromRecentJobsSearchInput" type="text" class="ts-search-textbox copy-from-search-input" placeholder="" 
                                                onkeyup="filterCopyFromRecentJobsDataSource(this)">
                                            <div class="input-group-addon">
                                                <span class="glyphicon glyphicon-search"></span>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="copy-from-list-view-container">
                                        <div id="copyFromRecentJobsListView" class="copy-from-list"></div>
                                    </div>
                                </div>
                                <div id="copyFromMyTimeTemplatesContainer" class="copy-from-container">
                                    <div class="copy-from-search-wrapper-container">
                                        <div class="input-group search-wrapper input-group-search-wrapper-spacer">
                                            <input id="copyFromMyTimeTemplatesSearchInput" type="text" class="ts-search-textbox copy-from-search-input" placeholder="" 
                                                onkeyup="filterCopyFromMyTimeTemplatesDataSource(this)">
                                            <div class="input-group-addon">
                                                <span class="glyphicon glyphicon-search"></span>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="copy-from-list-view-container">
                                        <div id="copyFromMyTimeTemplatesListView" class="copy-from-list"></div>
                                    </div>
                                </div>
                                <div id="copyFromMyCalendarContainer" class="copy-from-container">
                                    <div class="copy-from-search-wrapper-container">
                                        <div class="input-group search-wrapper input-group-search-wrapper-spacer">
                                            <input id="copyFromMyCalendarSearchInput" type="text" class="ts-search-textbox copy-from-search-input" placeholder="" 
                                                onkeyup="filterCopyFromMyCalendarDataSource(this)">
                                            <div class="input-group-addon">
                                                <span class="glyphicon glyphicon-search"></span>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="copy-from-list-view-container">
                                        <div id="copyFromMyCalendarListView" class="copy-from-list"></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </td>
                    <td style="vertical-align: top;">
                        <div id="expandCollapseAllDiv" class="collapse-container" title="" onclick="expandCollapseAll()" style="display: none !important;">   
                            <span id="expandCollapseSpan" class="glyphicon glyphicon-triangle-top"></span>
                        </div>
                        <table id="employeeTimeTable" class="emp-time-table" style="min-width: 800px !important;">
                            <thead>
                                @If Model.IsApprovalActive = True AndAlso Model.Lines IsNot Nothing AndAlso Model.Lines.Count > 0 AndAlso Model.HasHours = True Then
                                    Dim PendingCount As Integer = 0
                                    Dim DeniedCount As Integer = 0
                                    Dim ApprovedCount As Integer = 0
                                    Dim DaysWithHoursCount As Integer = 0
                                    Try
                                        PendingCount = (From Entity In Model.Days
                                                        Where Entity.IsPendingApproval = True
                                                        Select Entity).Count
                                    Catch ex As Exception
                                        PendingCount = 0
                                    End Try
                                    Try
                                        DeniedCount = (From Entity In Model.Days
                                                       Where Entity.IsDenied = True
                                                       Select Entity).Count
                                    Catch ex As Exception
                                        DeniedCount = 0
                                    End Try
                                    Try
                                        ApprovedCount = (From Entity In Model.Days
                                                         Where Entity.IsApproved
                                                         Select Entity).Count
                                    Catch ex As Exception
                                        ApprovedCount = 0
                                    End Try
                                    Try
                                        DaysWithHoursCount = (From Entity In Model.Days
                                                              Where Entity.TotalHours > 0
                                                              Select Entity).Count
                                    Catch ex As Exception
                                        DaysWithHoursCount = 0
                                    End Try
                                    @<tr id="approvalRow">
                                        <td colspan = "2" style="border: 0 !important; background-color: #FFF !important; text-align: right;">
                                            <div Class="approval-header" title="Set approval" style="display:inline-block; font-weight: bold; margin-right: 15px;">
                                                <span id = "approvalOptionsSpan" Class="glyphicon glyphicon-option-vertical" style="cursor:pointer; display: none;" title="Options"></span><span>Approval</span>
                                            </div>
                                            @If DaysWithHoursCount > 0 Then
                                                @If DaysWithHoursCount - ApprovedCount <> PendingCount + DeniedCount Then
                                                    @<div Class="approval-token approval-submit" style="display: inline-block; width: 120px; text-align: center; cursor:pointer; margin-right: 16px;" onclick="submitWeekForApproval()">
                                                        Submit Week
                                                    </div>
                                                End If
                                                @If PendingCount > 0 OrElse DeniedCount > 0 Then
                                                    @<div Class="approval-token approval-submit" style="display: inline-block; width: 120px; text-align: center; margin-right: 10px; cursor:pointer;" onclick="unSubmitWeekForApproval()">
                                                        Un-submit Week
                                                    </div>
                                                End If
                                            End If
                                        </td>
                                        @Code
                                            Dim TokenClass As String = String.Empty
                                            Dim TokenTitle As String = String.Empty
                                            Dim TokenText As String = String.Empty
                                            Dim TokenActionTitle As String = String.Empty
                                            Dim DayHasApprovalStatus As Boolean = False
                                            Dim RequireHoursBeforeSubmit As Boolean = Model.RequireHoursBeforeSubmit
                                            Dim AllowSubmitForApprovalType As AdvantageFramework.Timesheet.Settings.AgencyTimeEntryOptions.AllowSubmitForApprovalType = Model.RequireHoursBeforeSubmitType
                                            Dim ShowDailySubmitApprovalButton As Boolean = True

                                            'If RequireHoursBeforeSubmit = True AndAlso
                                            '    AllowSubmitForApprovalType <> AdvantageFramework.Timesheet.Settings.AgencyTimeEntryOptions.AllowSubmitForApprovalType.ByDay Then
                                            '    ShowDailySubmitApprovalButton = False
                                            'End If
                                            If RequireHoursBeforeSubmit = True Then
                                                If AllowSubmitForApprovalType = AdvantageFramework.Timesheet.Settings.AgencyTimeEntryOptions.AllowSubmitForApprovalType.ByDay Then
                                                    ShowDailySubmitApprovalButton = True
                                                Else
                                                    ShowDailySubmitApprovalButton = False
                                                End If
                                            End If

                                            For Each Day As AdvantageFramework.ViewModels.Employee.Timesheet.TimesheetDayViewModel In Model.Days
                                                TokenClass = "approval-submit"
                                                TokenTitle = "Submit day for approval."
                                                TokenText = "Submit"
                                                TokenActionTitle = ""
                                                DayHasApprovalStatus = False
                                                If Day.IsPendingApproval Then
                                                    TokenTitle = "Day is pending approval."
                                                    TokenClass = "approval-pending"
                                                    TokenText = "Pending"
                                                    DayHasApprovalStatus = True
                                                    TokenActionTitle = "Click to un-submit."
                                                End If
                                                If Day.IsApproved Then
                                                    TokenTitle = "Day is approved."
                                                    TokenClass = "approval-approved"
                                                    TokenText = "Approved"
                                                    DayHasApprovalStatus = True
                                                End If
                                                If Day.IsDenied Then
                                                    TokenTitle = "Day is Denied."
                                                    TokenClass = "approval-denied"
                                                    TokenText = "Denied"
                                                    DayHasApprovalStatus = True
                                                    TokenActionTitle = "Click to un-submit."
                                                End If
                                                If DayHasApprovalStatus = True AndAlso ShowDailySubmitApprovalButton = False Then
                                                    ShowDailySubmitApprovalButton = True
                                                End If
                                                @<td style="width: 75px;border: 0 !important; background-color: #FFF !important;">
                                                    @If Day.TotalHours <> 0 AndAlso ShowDailySubmitApprovalButton = True Then
                                                        @<div class="approval-token @TokenClass" title="@TokenTitle" appr-status="@TokenText" appr-date="@Day.Date.ToShortDateString">
                                                        @If AllowSubmitForApprovalType = AdvantageFramework.Timesheet.Settings.AgencyTimeEntryOptions.AllowSubmitForApprovalType.ByDay Then
                                                            @<span title="@TokenActionTitle" style="cursor:pointer;" onclick="submitForApproval(this);">@TokenText</span>
                                                        Else
                                                            @<span title="@TokenTitle">@TokenText</span>
                                                        End If
                                                        @If DayHasApprovalStatus = True Then
                                                            @<span class="glyphicon glyphicon-option-vertical" style="cursor:pointer;" onclick="viewApprovalComments(this);" title="View approval comments."></span>
                                                        End If
                                                        </div>
                                                    End If
                                                 </td>
                                            Next
                                            If Model.Days.Count > 1 Then
                                                @<td style="min-width: 30px; border: 0 !important; background-color: #FFF !important;"></td>
                                            End If
                                        End Code
                                    </tr>
                                            End If
                                <tr class="day_header_row">    
                                    <td colspan="2" class="description-column" style="height: 40px;min-width: 530px;">
                                        <div style="display: inline-block;">
                                            <div class="input-group search-wrapper" style="margin-top: 5px; height: 31px;">
                                                <input type="text" class="ts-search-textbox" placeholder="Search" onkeyup="searchTimesheet(this)">
                                                <div class="input-group-addon">
                                                    <span class="glyphicon glyphicon-search"></span>
                                                </div>
                                            </div>
                                        </div>
                                        <div style="display: inline-block;">
                                            <div style="">
                                                <select id="sortDropDownList" style="margin-top: -25px !important; position:relative; width:95px;">
                                                </select>
                                            </div>                                            
                                        </div>
                                        <div style="display: inline-block;">
                                            <div style="">
                                                <select id="groupDropDownList" style="margin-top: -25px !important; position:relative; width: 180px;">
                                                </select>
                                            </div>                                            
                                        </div>
                                    </td>
                                    @Code
                                        Dim lg As New Webvantage.LoGlo()
                                        Dim DayText As String = ""
                                        Dim DateText As String = ""
                                        Dim DayID As String = ""
                                        For Each Day As AdvantageFramework.ViewModels.Employee.Timesheet.TimesheetDayViewModel In Model.Days
                                            DayText = ""
                                            DateText = ""
                                            DayID = ""
                                            lg.MvcTimesheetHeader(Day.Date, DayText, DateText)
                                            DayID = "time-col-" & Day.Date.ToShortDateString                                            @<td id="@DayID" style="text-align: @IIf(Model.Days.Count = 1, "left", "right"); width: 75px; cursor: pointer;" onclick="selectSingleDay('@Day.Date.ToShortDateString')">
                                                @If Model.Days.Count > 1 Then
                                                    @<div style="margin-right: 20px;">
                                                        @DayText<br />@DateText
                                                    </div>
                                                End If
                                            </td>
                                        Next
                                        If Model.Days.Count > 1 Then
                                            @<td style="width:20px;"></td>
                                        End If
                                    End Code
                                </tr>
                            </thead>
                            <tbody>
                                @Code
                                    If Model.Lines IsNot Nothing AndAlso Model.Lines.Count > 0 Then

                                        Dim RowCounter As Integer = 0
                                        Dim GroupCounter As Integer = 0

                                        For Each Group As AdvantageFramework.ViewModels.Employee.Timesheet.TimesheetRowGroupViewModel In Model.Groups

                                            If String.IsNullOrWhiteSpace(Group.Key) = False Then
                                                @<tr id="GRP_@GroupCounter" class="group_row" onclick="expandCollapseRow(this)" style="cursor: pointer;" data-is-collapsed="false">
                                                    <td colspan='@Html.Raw(Model.Days.Count + 3)' class="grouping-cell">
                                                        <span class="grouping-text">
                                                            @Html.Raw(Group.Key)
                                                        </span>
                                                    </td>
                                                </tr>
                                            End If

                                            GroupCounter += 1

                                            For Each Row As AdvantageFramework.ViewModels.Employee.Timesheet.TimesheetLineViewModel In Group.Rows
                                                RowCounter += 1                                            @<tr id="@Row.LineID" class="border_bottom" row-id="@RowCounter">
                                                <td style="vertical-align: top;">
                                                    <div class="hamburger_cell">
                                                        <span class="glyphicon glyphicon-option-vertical" style="cursor:pointer;" title="Options"></span>
                                                    </div>
                                                    <div title="Select row." style="display: none !important;">
                                                        <input type="checkbox" id="checkBox_@Row.LineID" row-id="@RowCounter" onchange="rowCheckedChanged(this)" />
                                                    </div>
                                                    @If (Row.CannotEditDueToProcessingControl IsNot Nothing AndAlso Row.CannotEditDueToProcessingControl = True) Then
                                                        @<div class="caution_cell">
                                                            <span Class="glyphicon glyphicon-warning-sign" style="cursor:pointer; color:#CE3C38" title="@IIf(String.IsNullOrWhiteSpace(Row.NonEditMessage) = False, Row.NonEditMessage, "Cannot edit due to process control")"></span>
                                                        </div>
                                                    End If
                                                </td>
                                                <td class="description-column" onclick="descriptionColumnClick(this)" style="cursor: pointer;">
                                                    <div style="">
                                                        @If Row.JobNumber IsNot Nothing AndAlso Row.JobNumber > 0 Then
                                                            @<div title="@Row.JobNumber.ToString.PadLeft(6, "0")/@Row.JobComponentNumber.ToString.PadLeft(3, "0") - @Row.JobDescription">
                                                                <div style="font-weight:bold;">
                                                                    @If Model.UserSettings.ShowJobAndComponentNumber = True Then
                                                                        @<div style="">
                                                                           @Row.JobDescription&nbsp;&nbsp;(@Row.JobNumber.ToString.PadLeft(6, "0")/@Row.JobComponentNumber.ToString.PadLeft(3, "0"))
                                                                        </div>  
                                                                    Else
                                                                        @<div style="">
                                                                           @Row.JobDescription 
                                                                        </div>  
                                                                    End If
                                                                </div>
                                                                @If Model.UserSettings.ShowComponentName = True AndAlso Row.JobComponentDescription <> Row.JobDescription Then
                                                                    @<div style="display: block;">
                                                                        @Row.JobComponentDescription
                                                                    </div>
                                                                End If
                                                            </div>
                                                            @<div style="white-space: nowrap; overflow: hidden; text-overflow: ellipsis;">
                                                                @If Model.UserSettings.ShowFunctionCategory = True Then
                                                                    @<div style = "display: inline-block;" >
                                                                        <span style="" title="@Row.FunctionCategoryDescription">@Row.FunctionCategoryDescription</span>
                                                                     </div>
                                                                End If
                                                                @If String.IsNullOrWhiteSpace(Row.AlertSubject) = False AndAlso Model.UserSettings.ShowAssignment Then
                                                                    @<div style="display: inline-block;" >
                                                                        @IIf(Model.UserSettings.ShowFunctionCategory = True, " | ", "")<span style="" title="@Row.AlertSubject">@Row.AlertSubject</span>
                                                                    </div>
                                                                End If
                                                            </div>
                                                            @<div title="@Row.ClientName | @Row.DivisionName | @Row.ProductDescription (@Row.ClientCode, @Row.DivisionCode, @Row.ProductCode)">
                                                                @If Model.UserSettings.ShowClientName = True Then
                                                                    @<div>
                                                                        @Row.ClientName  @IIf(Model.UserSettings.ShowDivisionName = True AndAlso Row.DivisionName <> Row.ClientName, " | " & Row.DivisionName, "")
                                                                    </div>
                                                                    @If Model.UserSettings.ShowDivisionName = True AndAlso Model.UserSettings.ShowProductName = True AndAlso Row.ProductDescription <> Row.DivisionName Then
                                                                        @<div>
                                                                            @Row.ProductDescription
                                                                        </div>
                                                                    End If
                                                                End If
                                                            </div>
                                                        Else
                                                            @<div>
                                                                <span style = "font-weight:bold;" title="Category">@Row.FunctionCategoryDescription</span>
                                                            </div>
                                                        End If
                                                        @If Model.UserSettings.ShowProgressBar = True AndAlso Row.JobNumber IsNot Nothing AndAlso Row.JobNumber > 0 Then

                                                            Dim IsOver As Boolean = False
                                                            Dim CompletePerc As Double = 0.00
                                                            Dim Color As String = "#5CB85C"
                                                            Dim Progress As Double = 0.0
                                                            Dim ToolTip As String = String.Empty
                                                            Dim QuotedOrTraffic As String = String.Empty
                                                            Dim HoursRemaining As Double = 0.00
                                                            Dim RemainingText As String = String.Empty
                                                            Dim Show As Boolean = True
                                                            Try
                                                                If Row.ProgressIsShowingTrafficHours = True Then
                                                                    QuotedOrTraffic = "traffic"
                                                                Else
                                                                    QuotedOrTraffic = "quoted"
                                                                End If
                                                                Try
                                                                    If Row.QuotedHours > 0 Then
                                                                        HoursRemaining = Row.QuotedHours - Row.ActualHours
                                                                        Progress = (Row.ActualHours / Row.QuotedHours) * 100
                                                                        If HoursRemaining > 0 Then
                                                                            RemainingText = "remaining:  " & FormatNumber(HoursRemaining, 2) & " hours"
                                                                        ElseIf HoursRemaining < 0 Then
                                                                            RemainingText = "over by:  " & FormatNumber(HoursRemaining * -1, 2) & " hours"
                                                                        End If
                                                                        ToolTip = FormatNumber(Row.ActualHours, 2) & " posted hours of " &
                                                                                  FormatNumber(Row.QuotedHours, 2) & " " & QuotedOrTraffic & " hours, " & RemainingText
                                                                        If Row.IsOverThreshold = True Then
                                                                            Color = "#C9302C"
                                                                        Else
                                                                            Color = "#449D44"
                                                                        End If
                                                                        If Row.Threshold > 0 Then
                                                                            ToolTip &= String.Format(", threshold:  {0} hours ({1}%)",
                                                                                    (Row.QuotedHours * (Row.Threshold * 0.01)), Row.Threshold)
                                                                        End If
                                                                    Else
                                                                        Progress = 100
                                                                        ToolTip = FormatNumber(Row.ActualHours, 2) & " posted hours"
                                                                        Color = "#FFD400"
                                                                    End If
                                                                Catch ex As Exception
                                                                    Show = False
                                                                End Try
                                                                If Progress > 100 Then
                                                                    Progress = 100
                                                                End If
                                                            Catch ex As Exception
                                                            End Try
                                                            If Show = True Then
                                                                @<div id='@Html.Raw("progressBar_" & RowCounter)' class="progress-bar-container progress-bar-container-@Html.Raw(Model.Days.Count)" title="@ToolTip" >
                                                                    <div class="progess-bar" style="border: 1px solid @Color" title="@ToolTip">
                                                                        <div class="progress-amount" style="background-color: @Color; width: @Progress%;">
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            End If
                                                        End If
                                                        <div style="display: none;">
                                                            <span style="margin-left: 4px; color:#808080;" class="glyphicon glyphicon-search"></span>
                                                        </div>
                                                    </div>
                                                </td>
                                                @Code
                                                    Dim Entry As AdvantageFramework.ViewModels.Employee.Timesheet.TimesheetEntryViewModel = Nothing
                                                    Dim Value As Decimal? = 0.00
                                                    Dim ID As String = String.Empty
                                                    Dim EntryDate As String = String.Empty
                                                    Dim NullFound As Boolean = False
                                                    Dim Disabled As Boolean = False
                                                    Dim DisabledText As String = String.Empty
                                                    Dim MissingComment As Boolean = False
                                                    Dim SingleClickOpen As Boolean = False
                                                    For Each Day As AdvantageFramework.ViewModels.Employee.Timesheet.TimesheetDayViewModel In Model.Days
                                                        Value = Nothing
                                                        ID = String.Empty
                                                        EntryDate = Day.Date.ToShortDateString
                                                        NullFound = False
                                                        Disabled = False
                                                        DisabledText = String.Empty
                                                        MissingComment = False
                                                        For Each RowEntry As AdvantageFramework.ViewModels.Employee.Timesheet.TimesheetEntryViewModel In Row.Entries
                                                            If RowEntry.Date.ToShortDateString = Day.Date.ToShortDateString Then
                                                                Entry = RowEntry
                                                                Exit For
                                                            End If
                                                        Next
                                                        If Entry IsNot Nothing Then
                                                            ID = Entry.WebDataKey
                                                            Value = Entry.Hours
                                                            If Entry.EditFlag = AdvantageFramework.Timesheet.Methods.TimesheetEditType.Edit OrElse
                                                                Entry.EditFlag = AdvantageFramework.Timesheet.Methods.TimesheetEditType.Denied Then
                                                                Disabled = False
                                                                If Entry.CommentsRequired = True AndAlso String.IsNullOrWhiteSpace(Entry.Comments) Then
                                                                    MissingComment = True
                                                                End If
                                                            Else
                                                                Disabled = True
                                                                DisabledText = Entry.EditFlagText
                                                            End If
                                                        Else
                                                            Entry = New AdvantageFramework.ViewModels.Employee.Timesheet.TimesheetEntryViewModel
                                                            Entry.LineID = Row.LineID
                                                            Entry.EmployeeTimeID = 0
                                                            Entry.EmployeeTimeDetailID = 0
                                                            Entry.Date = Day.Date
                                                            Entry.CannotEditDueToProcessingControl = Row.CannotEditDueToProcessingControl
                                                            Entry.Hours = Nothing
                                                            Entry.CommentsRequired = Row.ClientCommentRequired
                                                            Entry.FunctionCategoryCode = Row.FunctionCategory
                                                            NullFound = True
                                                        End If
                                                        If Entry.CommentsRequired Then
                                                            If MissingComment = True OrElse NullFound = True OrElse (Entry.Hours Is Nothing OrElse Entry.Hours = 0) Then
                                                                SingleClickOpen = True
                                                            End If
                                                            If MissingComment = False AndAlso Entry.Hours IsNot Nothing AndAlso Entry.Hours <> 0 Then
                                                                SingleClickOpen = False
                                                            End If
                                                        End If
                                                        If Model.IsViewingSingleDay = True Then
                                                            SingleClickOpen = False
                                                        End If
                                                        If Entry.CannotEditDueToProcessingControl = True OrElse Row.CannotEditDueToProcessingControl = True Then
                                                            Disabled = True
                                                            DisabledText = "Cannot Edit due to processing control."
                                                        End If
                                                        If Disabled = False AndAlso Day.IsApproved IsNot Nothing AndAlso Day.IsApproved = True Then
                                                            Disabled = True
                                                            DisabledText = "Day is approved."
                                                        End If
                                                        If Disabled = False AndAlso Day.IsPendingApproval IsNot Nothing AndAlso Day.IsPendingApproval = True Then
                                                            Disabled = True
                                                            DisabledText = "Day is pending approval."
                                                        End If
                                                        If Disabled = False AndAlso Day.IsDenied IsNot Nothing AndAlso Day.IsDenied = True Then
                                                            Disabled = True
                                                            DisabledText = "Day is denied."
                                                        End If
                                                        If Disabled = False AndAlso Day.PostPeriodIsClosed IsNot Nothing AndAlso Day.PostPeriodIsClosed = True Then
                                                            Disabled = True
                                                            DisabledText = "Post period closed for this day."
                                                        End If
                                                        If Entry.HasStopwatch IsNot Nothing AndAlso Entry.HasStopwatch = True Then
                                                            Disabled = True
                                                            DisabledText = "Stopwatch running."
                                                        End If
                                                        If Disabled = True Then
                                                            If String.IsNullOrWhiteSpace(DisabledText) = True Then
                                                                If String.IsNullOrWhiteSpace(Row.NonEditMessage) = False Then
                                                                    DisabledText = Row.NonEditMessage
                                                                Else
                                                                    DisabledText = "Cannot edit."
                                                                End If
                                                            End If
                                                        End If
                                                        @<td class="input-cell" style="text-align:right;" abbr="@Day.Date.ToShortDateString" property="@Entry.EmployeeTimeID|@Entry.EmployeeTimeDetailID">
                                                            <table style="border: 0 !important;">
                                                                <tr style="border: 0 !important;">
                                                                @If Model.Days.Count = 1 Then
                                                                    @<td class="comment-textarea-cell" data-etid="@Entry.EmployeeTimeID" data-etdid="@Entry.EmployeeTimeDetailID">
                                                                        <div>
                                                                            <textarea id="commentsInput" class="comments-textarea @IIf(Entry.CommentsRequired = True, "RequiredInput", "")" onblur="commentsChanged(this)" @IIf(Disabled = True, "disabled", "")>@Entry.Comments</textarea>
                                                                            <textarea id="commentsDefault" style="display: none !important;">@Entry.Comments</textarea>
                                                                        </div>
                                                                    </td>
                                                                End If
                                                                    <td class="hours-input-container">
                                                                        @If SingleClickOpen = True Then
                                                                            @<input id = "@ID" entry-Date="@EntryDate" class="hours-textbox" onfocus="this.select();" value="@IIf(Value Is Nothing, "", FormatNumber(Value, 2))" onblur="hoursChanged(this)" onkeyup="hoursKeyUp(this)" 
                                                                                    title = "@IIf(String.IsNullOrWhiteSpace(DisabledText) = False, DisabledText, "")"
                                                                                    onclick = "openEntryDialog(@Entry.EmployeeTimeID, @Entry.EmployeeTimeDetailID, '@Row.FunctionCategory', @Row.JobNumber, @Row.JobComponentNumber, '@Entry.Date.ToShortDateString', @Row.AlertID, '@Entry.DepartmentTeamCode');"                                                                            @IIf(Disabled = True, "disabled", "")  />
                                                                        Else
                                                                            @<input id = "@ID" entry-Date="@EntryDate" class="hours-textbox" onfocus="this.select();" value="@IIf(Value Is Nothing, "", FormatNumber(Value, 2))" onblur="hoursChanged(this)" onkeyup="hoursKeyUp(this)" 
                                                                                    title = "@IIf(String.IsNullOrWhiteSpace(DisabledText) = False, DisabledText, "")"
                                                                                    ondblclick = "openEntryDialog(@Entry.EmployeeTimeID, @Entry.EmployeeTimeDetailID, '@Row.FunctionCategory', @Row.JobNumber, @Row.JobComponentNumber, '@Entry.Date.ToShortDateString', @Row.AlertID, '@Entry.DepartmentTeamCode');"                                                                            @IIf(Disabled = True, "disabled", "")  />
                                                                        End If
                                                                    </td>
                                                                    <td style="width: 20px; border-bottom: 0 !important; text-align: left; vertical-align: top;">
                                                                        @If Model.Days.Count > 1 Then
                                                                            @If String.IsNullOrWhiteSpace(Entry.Comments) = False Then
                                                                                @<div class="comment-tooltip-container" title="This entry has comments" style="cursor:pointer;" data-etid="@Entry.EmployeeTimeID" data-etdid="@Entry.EmployeeTimeDetailID" data-tt="@Entry.TimeType" onclick="openEntryDialog(@Entry.EmployeeTimeID, @Entry.EmployeeTimeDetailID, '@Row.FunctionCategory', @Row.JobNumber, @Row.JobComponentNumber, '@Entry.Date.ToShortDateString', @Row.AlertID, '@Entry.DepartmentTeamCode');">
                                                                                    <span class="glyphicon glyphicon-comment" style="color: #337ab7;"></span>
                                                                                </div>
                                                                            Else
                                                                                If MissingComment = True AndAlso (Entry.Hours IsNot Nothing AndAlso Entry.Hours <> 0) Then
                                                                                    @<div class="comment-tooltip-container" title="This entry is missing comments" style="cursor:pointer;" data-etid="@Entry.EmployeeTimeID" data-etdid="@Entry.EmployeeTimeDetailID" data-tt="@Entry.TimeType" onclick="openEntryDialog(@Entry.EmployeeTimeID, @Entry.EmployeeTimeDetailID, '@Row.FunctionCategory', @Row.JobNumber, @Row.JobComponentNumber, '@Entry.Date.ToShortDateString', @Row.AlertID, '@Entry.DepartmentTeamCode');">
                                                                                        <span class="glyphicon glyphicon-comment" style="color: #d9534f;"></span>
                                                                                    </div>
                                                                                End If
                                                                            End If
                                                                        End If
                                                                        @If Disabled = True Then
                                                                            @<div title="@DisabledText">
                                                                                <span class="glyphicon glyphicon-lock" style="color: #d9534f;"></span>
                                                                            </div>
                                                                        End If
                                                                        @If Entry.HasStopwatch = True Then
                                                                            @<div title="Stopwatch running." style="cursor: pointer;" onclick="openStopWatchDialog()">
                                                                                <span class="wvi wvi-stopwatch" style="color: #4B7D70;"></span>
                                                                            </div>
                                                                        End If
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        Entry = Nothing
                                                    Next
                                                    @If Model.Days.Count > 1 Then
                                                        @<td style="text-align: right; padding-right: 6px; width:20px;" >
                                                            <span id="totalRowHours" style="color:#767676; font-weight:bold;">@FormatNumber(Row.TotalHours, 2)</span>
                                                        </td>
                                                    End If
                                                End Code
                                            </tr>
                                                            Next

                                                        Next

                                                    Else
                                        @<tr>
                                            <td colspan='@Html.Raw(Model.Days.Count + 1)'>
                                                <div class="wv-no-records" style="width: 100%; text-align: center; height: 193px;"  onclick="openNewEntryDialog()">
                                                    <img style="height: 128px; width: 128px; margin-top: 20px;" src="~/Images/sleep.png" title="Add time" />
                                                </div>
                                            </td>
                                        </tr>
                                                    End If
                                End Code
                            </tbody>
                            <tfoot>
                                <tr>
                                    <td></td>
                                    <td class="description-column">&nbsp;
                                    </td>
                                    @Code
                                        For Each Day As AdvantageFramework.ViewModels.Employee.Timesheet.TimesheetDayViewModel In Model.Days
                                            Dim DayGoal As Decimal = 0
                                            Select Case Day.Date.DayOfWeek
                                                Case DayOfWeek.Sunday
                                                    If Model.UserSettings.SundayHoursGoal IsNot Nothing Then DayGoal = Model.UserSettings.SundayHoursGoal
                                                Case DayOfWeek.Monday
                                                    If Model.UserSettings.MondayHoursGoal IsNot Nothing Then DayGoal = Model.UserSettings.MondayHoursGoal
                                                Case DayOfWeek.Tuesday
                                                    If Model.UserSettings.TuesdayHoursGoal IsNot Nothing Then DayGoal = Model.UserSettings.TuesdayHoursGoal
                                                Case DayOfWeek.Wednesday
                                                    If Model.UserSettings.WednesdayHoursGoal IsNot Nothing Then DayGoal = Model.UserSettings.WednesdayHoursGoal
                                                Case DayOfWeek.Thursday
                                                    If Model.UserSettings.ThursdayHoursGoal IsNot Nothing Then DayGoal = Model.UserSettings.ThursdayHoursGoal
                                                Case DayOfWeek.Friday
                                                    If Model.UserSettings.FridayHoursGoal IsNot Nothing Then DayGoal = Model.UserSettings.FridayHoursGoal
                                                Case DayOfWeek.Saturday
                                                    If Model.UserSettings.SaturdayHoursGoal IsNot Nothing Then DayGoal = Model.UserSettings.SaturdayHoursGoal
                                            End Select                                            @<td id="footerTotalCell" class="footer-total-@Html.Raw(Model.Days.Count)" title="Goal:  @FormatNumber(DayGoal, 2)">
                                                <span id="totalColHours-@Day.Date.ToShortDateString.Replace("/", "")" hours-goal="@DayGoal" >@FormatNumber(Day.TotalHours, 2)</span>                                                
                                            </td>
                                        Next
                                        If Model.Days.Count > 1 Then
                                            @<td style="text-align: right;">
                                                    @If Model.Days IsNot Nothing AndAlso Model.Days.Count > 0 Then
                                                        Dim Total As Decimal = 0.00
                                                        Total = (From Entity In Model.Days
                                                                 Select Entity.TotalHours).Sum
                                                        @<span id="totalGridHours" style="color:#767676; font-weight:bold;">@FormatNumber(Total, 2)</span>
                                                    End If
                                            </td>
                                        End If
                                    End Code
                                </tr>
                            </tfoot>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>
<div id="dateValue" style="display: none !important">@Html.Raw(Model.StartDate)</div>
<script>
    ////////var getCommentUrl = window.appBase + "Employee/Timesheet/GetTimeEntryCommentText?etid={0}&etdid={1}&tt={2}";
    $(document).ready(function () {
        ////////var commentTooltip = $("#employeeTimeTable").kendoTooltip({
        ////////    filter: "div.comment-tooltip-container",
        ////////    content: kendo.template($("#commentTemplate").html()),
        ////////    position: "right",
        ////////    requestStart: function (e) {
        ////////        e.options.url = kendo.format(getCommentUrl, e.target.data("etid"), e.target.data("etdid"), e.target.data("tt"));
        ////////    },
        ////////    contentLoad: function (e) {
        ////////    },
        ////////    autoHide: false,
        ////////    show: tooltipShow
        ////////}).data("kendoTooltip");
        ////////function tooltipShow(e) {
        ////////    var data = {
        ////////        etid: e.sender.target().first().data("etid"),
        ////////        etdid: e.sender.target().first().data("etdid"),
        ////////        tt: e.sender.target().first().data("tt")
        ////////    };
        ////////    $.get({
        ////////        url: window.appBase + "Employee/Timesheet/GetTimeEntryCommentText",
        ////////        dataType: "json",
        ////////        data: data
        ////////    }).always(function (response) {
        ////////        if (response) {
        ////////            //console.log("response", response.responseText);
        ////////            $("#commentSpan").html(response.responseText);
        ////////        }
        ////////    });
        ////////}
        //var lockedTooltip = $("#employeeTimeTable").kendoTooltip({
        //    filter: "div.comment-tooltip-container",
        //    position: "right",
        //}).data("kendoTooltip");
    });
</script>
<div style="display: none;">
@(Html.Kendo().ContextMenu().Name("rowContextMenu").Target("#employeeTimeTable").Filter("tbody > tr > td > div.hamburger_cell").Items(Sub(i)
                                                                                                                                              i.Add().Text("<span class='glyphicon glyphicon-search'></span>&nbsp;&nbsp;&nbsp;Details").Encoded(False).HtmlAttributes(New With {.id = "details", .title = "View row details"})
                                                                                                                                              i.Add().Text("<span class='glyphicon glyphicon-time'></span>&nbsp;&nbsp;&nbsp;Start stopwatch").Encoded(False).HtmlAttributes(New With {.id = "startStopwatch", .title = "Start a stopwatch for this job/function/assignment"})
                                                                                                                                              i.Add().Separator(True)
                                                                                                                                              i.Add().Text("<span class='glyphicon glyphicon-edit'></span>&nbsp;&nbsp;&nbsp;Change function").Encoded(False).HtmlAttributes(New With {.id = "changeFunction", .title = "Change function for this row"})
                                                                                                                                              i.Add().Text("<span class='glyphicon glyphicon-edit'></span>&nbsp;&nbsp;&nbsp;Add/change assignment").Encoded(False).HtmlAttributes(New With {.id = "changeAssignment", .title = "Add/change assignment for this row"})
                                                                                                                                              'i.Add().Separator(True)
                                                                                                                                              'i.Add().Text("<span class='glyphicon glyphicon-copy'></span>&nbsp;&nbsp;&nbsp;Copy row").Encoded(False).HtmlAttributes(New With {.id = "copyRow", .title = "Make a copy of this row"})
                                                                                                                                              'i.Add().Text("<span class='glyphicon glyphicon-th-list'></span>&nbsp;&nbsp;&nbsp;Row view").Encoded(False).HtmlAttributes(New With {.id = "rowView", .title = "View just this row (Comment View)"})
                                                                                                                                              i.Add().Separator(True)
                                                                                                                                              i.Add().Text("<span class='glyphicon glyphicon-remove' style='color: #D63251;'></span>&nbsp;&nbsp;&nbsp;Delete").Encoded(False).HtmlAttributes(New With {.id = "deleteRow", .title = "Delete this row"})
                                                                                                                                          End Sub).Events(Sub(evt)
                                                                                                                                                              evt.Select("lineContextMenuSelect")
                                                                                                                                                              evt.Open("lineContextMenuOpen")
                                                                                                                                                          End Sub).Animation(Sub(ani)
                                                                                                                                                                                 ani.Open(Sub(o)
                                                                                                                                                                                              o.Fade(FadeDirection.In)
                                                                                                                                                                                              o.Duration(500)
                                                                                                                                                                                          End Sub)
                                                                                                                                                                                 ani.Close(Sub(c)
                                                                                                                                                                                               c.Fade(FadeDirection.Out)
                                                                                                                                                                                               c.Duration(500)
                                                                                                                                                                                           End Sub)
                                                                                                                                                                             End Sub).Orientation(ContextMenuOrientation.Vertical).ShowOn("click"))
</div>
