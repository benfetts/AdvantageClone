Namespace Employee.Presentation

    Public Class EmployeeTimesheetForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _LastSearchedEmployeeCode As String = Nothing
        Private _LastSearchedMonth As String = Nothing
        Private _LastSearchedYear As String = Nothing
        Private _SelectedDateWeekStart As Date = Nothing
        Private _SelectedDateWeekEnd As Date = Nothing
        Private _DayStatusList As Generic.List(Of AdvantageFramework.EmployeeTimesheet.Classes.DayStatus) = Nothing

#End Region

#Region " Properties "


#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub LoadEmployees()

            'objects
            Dim EmployeeVendors As Generic.List(Of AdvantageFramework.Database.Entities.Vendor) = Nothing
            Dim Employees As Generic.List(Of AdvantageFramework.Database.Classes.Employee) = Nothing
            Dim LimitEmployeeToSelf As Boolean = False
            Dim LimitedEmployees As String() = Nothing
            Dim UserSettings As Generic.List(Of AdvantageFramework.Security.Database.Entities.UserSetting) = Nothing

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Try

                    LimitedEmployees = (From Employee In AdvantageFramework.Security.Database.Procedures.UserEmployeeAccess.LoadByUserCode(SecurityDbContext, Me.Session.UserCode)
                                        Select Employee.EmployeeCode).ToArray

                Catch ex As Exception
                    LimitedEmployees = Nothing
                End Try

                Try

                    UserSettings = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserID(SecurityDbContext, Me.Session.User.ID.ToString).ToList

                Catch ex As Exception
                    UserSettings = Nothing
                End Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Try

                        If (From UserSetting In UserSettings
                            Where UserSetting.SettingCode = AdvantageFramework.Security.UserSettings.SI_DO_OWN_TS.ToString AndAlso
                                  UserSetting.StringValue IsNot Nothing AndAlso
                                  UserSetting.StringValue = "Y"
                            Select UserSetting).Any Then

                            LimitEmployeeToSelf = True

                        End If

                    Catch ex As Exception
                        LimitEmployeeToSelf = False
                    End Try

                    Try

                        If LimitEmployeeToSelf Then

                            Employees = (From Employee In AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActive(DbContext)
                                         Where Employee.Code = Me.Session.User.EmployeeCode
                                         Select New With {Employee.Code, Employee.FirstName, Employee.LastName, Employee.MiddleInitial}).ToList _
                                        .Select(Function(e) New AdvantageFramework.Database.Classes.Employee With {.Code = e.Code,
                                                                                                                   .Name = e.FirstName & " " & If(e.MiddleInitial <> "", e.MiddleInitial & ". ", "") & e.LastName}).ToList

                            SearchableComboBoxSearch_Employees.DataSource = Employees
                            SearchableComboBoxSearch_Employees.SelectedValue = Me.Session.User.EmployeeCode
                            SearchableComboBoxSearch_Employees.Enabled = False

                        Else

                            If LimitedEmployees.Any Then

                                Employees = (From Employee In AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActive(DbContext)
                                             Where LimitedEmployees.Contains(Employee.Code)
                                             Select New With {Employee.Code, Employee.FirstName, Employee.LastName, Employee.MiddleInitial}).ToList _
                                             .Select(Function(e) New AdvantageFramework.Database.Classes.Employee With {.Code = e.Code,
                                                                                                                        .Name = e.FirstName & " " & If(e.MiddleInitial <> "", e.MiddleInitial & ". ", "") & e.LastName}).ToList

                            Else

                                If AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, Session.User.EmployeeCode).Count > 0 Then

                                    Employees = (From Employee In AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActiveByUserCodeWithOfficeLimitsAndIncludeCurrentUser(Session, DbContext, SecurityDbContext)
                                                 Select New With {Employee.Code, Employee.FirstName, Employee.LastName, Employee.MiddleInitial}).ToList _
                                            .Select(Function(e) New AdvantageFramework.Database.Classes.Employee With {.Code = e.Code,
                                                                                                                       .Name = e.FirstName & " " & If(e.MiddleInitial <> "", e.MiddleInitial & ". ", " ") & e.LastName}).ToList

                                Else

                                    Employees = (From Employee In AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActive(DbContext)
                                                 Select New With {Employee.Code, Employee.FirstName, Employee.LastName, Employee.MiddleInitial}).ToList _
                                            .Select(Function(e) New AdvantageFramework.Database.Classes.Employee With {.Code = e.Code,
                                                                                                                       .Name = e.FirstName & " " & If(e.MiddleInitial <> "", e.MiddleInitial & ". ", " ") & e.LastName}).ToList

                                End If



                            End If

                            SearchableComboBoxSearch_Employees.DataSource = Employees
                            SearchableComboBoxSearch_Employees.Enabled = True

                        End If

                        If Employees.Count = 1 Then

                            _LastSearchedEmployeeCode = Employees.FirstOrDefault.Code
                            SearchableComboBoxSearch_Employees.SelectedValue = _LastSearchedEmployeeCode

                        ElseIf (From Emp In Employees
                                Where Emp.Code = Me.Session.User.EmployeeCode
                                Select Emp).Any Then

                            _LastSearchedEmployeeCode = Me.Session.User.EmployeeCode
                            SearchableComboBoxSearch_Employees.SelectedValue = _LastSearchedEmployeeCode

                        End If

                    Catch ex As Exception

                    End Try

                End Using
            End Using

        End Sub
        Private Sub LoadTimesheet()

            'objects
            Dim StartDate As Date = Nothing
            Dim EndDate As Date = Nothing
            Dim ItemDescription As String = Nothing

            If SearchableComboBoxSearch_Employees.HasASelectedValue Then

                If Me.FormShown = True Then

                    Me.ShowWaitForm()

                End If

                If MonthCalendarControl_TimesheetDates.MultiSelect = True Then

                    StartDate = MonthCalendarControl_TimesheetDates.SelectionStart
                    EndDate = MonthCalendarControl_TimesheetDates.SelectionEnd

                Else

                    StartDate = MonthCalendarControl_TimesheetDates.SelectedDate
                    EndDate = MonthCalendarControl_TimesheetDates.SelectedDate

                End If

                TimesheetControlForm_Timesheet.ClearControl()

                TimesheetControlForm_Timesheet.Enabled = TimesheetControlForm_Timesheet.LoadControl(SearchableComboBoxSearch_Employees.GetSelectedValue, StartDate, EndDate)

                If Me.FormShown = True Then

                    Me.CloseWaitForm()

                End If

            End If

        End Sub
        Private Sub EnableOrDisableActions()

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

            RibbonBarOptions_Options.Visible = (TimesheetControlForm_Timesheet.Enabled AndAlso TimesheetControlForm_Timesheet.ExpandablePanelControl_Options.Expanded)

            If TimesheetControlForm_Timesheet.Enabled Then

                ButtonItemActions_Cancel.Enabled = TimesheetControlForm_Timesheet.TimeEntriesDataGridView.IsNewItemRow()
                ButtonItemActions_Delete.Enabled = TimesheetControlForm_Timesheet.CanDeleteEntry
                ButtonItemActions_Print.Enabled = True

                ButtonItemOptions_Copy.Enabled = TimesheetControlForm_Timesheet.CurrentCopyFromDataGridView.HasASelectedRow
                ButtonItemOptions_Cancel.Enabled = TimesheetControlForm_Timesheet.CurrentCopyFromDataGridView.IsNewItemRow
                ButtonItemOptions_Refresh.Enabled = True

                If TimesheetControlForm_Timesheet.CurrentCopyFromDataGridView Is TimesheetControlForm_Timesheet.DataGridViewCopyFromTemplate_Templates Then

                    ButtonItemOptions_Cancel.Visible = True
                    ButtonItemOptions_Delete.Visible = True
                    ButtonItemOptions_Delete.Enabled = TimesheetControlForm_Timesheet.CurrentCopyFromDataGridView.HasASelectedRow

                Else

                    ButtonItemOptions_Cancel.Visible = False
                    ButtonItemOptions_Delete.Visible = False
                    ButtonItemOptions_Delete.Enabled = False

                End If

                AdvantageFramework.WinForm.Presentation.Controls.ResetRibbonBar(RibbonBarOptions_Options)

                If ButtonItemActions_Info.Visible Then

                    ButtonItemActions_Info.Enabled = TimesheetControlForm_Timesheet.IsDirectTimeSelected

                End If

                If ButtonItemActions_Approval.Visible Then

                    ButtonItemActions_Approval.Enabled = TimesheetControlForm_Timesheet.TimeEntriesDataGridView.HasRows

                End If

            Else

                ButtonItemActions_Print.Enabled = False
                ButtonItemActions_Cancel.Enabled = False
                ButtonItemActions_Delete.Enabled = False
                ButtonItemActions_Info.Enabled = False
                ButtonItemOptions_Copy.Enabled = False
                ButtonItemOptions_Delete.Visible = False
                ButtonItemOptions_Cancel.Visible = False
                ButtonItemOptions_Refresh.Enabled = False
                ButtonItemActions_Approval.Enabled = False

            End If

            RibbonBarMergeContainerForm_Options.ResumeLayout(True)

        End Sub
        Private Function CheckForUnsavedChanges() As Boolean

            'objects
            Dim IsOkay As Boolean = True

            If Me.CheckUserEntryChangedSetting Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    IsOkay = Me.Validator

                    If IsOkay Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                        Try

                            IsOkay = TimesheetControlForm_Timesheet.Save()

                        Catch ex As Exception
                            IsOkay = False
                        End Try

                        If IsOkay = False AndAlso AdvantageFramework.Navigation.ShowMessageBox("Saving failed. Would you like to continue without saving?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                            IsOkay = True

                        End If

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        Me.ClearValidations()

                    End If

                End If

            End If

            CheckForUnsavedChanges = IsOkay

        End Function
        Private Function Search() As Boolean

            'objects
            Dim Searched As Boolean = False

            If CheckForUnsavedChanges() Then

                Me.ClearChanged()

                Me.FormAction = WinForm.Presentation.FormActions.Loading

                _LastSearchedEmployeeCode = SearchableComboBoxSearch_Employees.GetSelectedValue

                LoadTimesheet()

                Me.ClearChanged()

                EnableOrDisableActions()

                Me.FormAction = WinForm.Presentation.FormActions.None

                Searched = True

            End If

            Search = Searched

        End Function
        Private Function Save() As Boolean

            'objects
            Dim ErrorMessage As String = ""
            Dim Saved As Boolean = False

            If Me.Validator Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                Try

                    If TimesheetControlForm_Timesheet.Save() Then

                        Me.ClearChanged()

                        LoadEmployeeCalendarData()

                        Saved = True

                    End If

                Catch ex As Exception
                    ErrorMessage = ex.Message
                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)
                End Try

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                If ErrorMessage = "" Then

                    LoadTimesheet()

                End If

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

            Save = Saved

        End Function
        Private Sub LoadEmployeeCalendarData()

            'objects
            Dim EmployeeCode As String = Nothing
            Dim CurrentMonth As Date = Nothing
            Dim DisplayedStartDate As Date = Nothing
            Dim DisplayedEndDate As Date = Nothing

            MonthCalendarControl_TimesheetDates.RemoveAllMarkedDates()

            If SearchableComboBoxSearch_Employees.HasASelectedValue Then

                CurrentMonth = MonthCalendarControl_TimesheetDates.DisplayMonth

                If CurrentMonth.Day <> 1 Then

                    Do Until CurrentMonth.Day = 1

                        CurrentMonth = CurrentMonth.AddDays(-1)

                    Loop

                End If

                DisplayedStartDate = CurrentMonth

                If DisplayedStartDate.DayOfWeek <> DayOfWeek.Sunday Then

                    Do Until DisplayedStartDate.DayOfWeek = DayOfWeek.Sunday

                        DisplayedStartDate = DisplayedStartDate.AddDays(-1)

                    Loop

                End If

                DisplayedEndDate = CurrentMonth.AddMonths(1).AddDays(-1)

                EmployeeCode = SearchableComboBoxSearch_Employees.GetSelectedValue

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    'get 1 week before & 2 weeks after to accomodate for trailing days

                    Try

                        _DayStatusList = AdvantageFramework.EmployeeTimesheet.LoadDaysByApprovalStatus(DbContext, EmployeeCode, DisplayedStartDate.AddDays(-7), DisplayedEndDate.AddDays(14), "")

                    Catch ex As Exception
                        _DayStatusList = Nothing
                    End Try

                End Using

            End If

            MonthCalendarControl_TimesheetDates.UpdateMarkedDates()

        End Sub
        Private Sub LoadEmployeeApprovalData()

            'objects
            Dim EmployeeCode As String = Nothing
            Dim ApprovalRequired As Boolean = False

            If SearchableComboBoxSearch_Employees.HasASelectedValue Then

                EmployeeCode = SearchableComboBoxSearch_Employees.GetSelectedValue

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ApprovalRequired = AdvantageFramework.EmployeeTimesheet.CheckIfApprovalRequired(DbContext, EmployeeCode)

                End Using

            End If

            If ApprovalRequired Then

                ButtonItemActions_Approval.Visible = True

            Else

                ButtonItemActions_Approval.Visible = False

            End If

            AdvantageFramework.WinForm.Presentation.Controls.ResetRibbonBar(RibbonBarOptions_Actions)

        End Sub
        Private Sub SetupSearchByProperties()

            'objects
            Dim SelectedDate As Date = Nothing
            Dim SelectionStart As Date = Nothing
            Dim SelectionEnd As Date = Nothing

            SelectedDate = MonthCalendarControl_TimesheetDates.SelectedDate
            SelectionStart = MonthCalendarControl_TimesheetDates.SelectionStart
            SelectionEnd = MonthCalendarControl_TimesheetDates.SelectionEnd

            SetupCalendarProperties()

            If RadioButtonControlForm_SelectedDateOnly.Checked = True Then

                MonthCalendarControl_TimesheetDates.SelectedDate = SelectionStart

            ElseIf RadioButtonControlForm_CustomDateRange.Checked = True Then

                MonthCalendarControl_TimesheetDates.SetSelectionRange(SelectionStart, SelectionEnd)

            Else

                If SelectedDate = Nothing Then

                    SetCalendarSelection(SelectionStart)

                Else

                    SetCalendarSelection(SelectedDate)

                End If

            End If

            MonthCalendarControl_TimesheetDates.Refresh()

        End Sub
        Private Sub SetupCalendarProperties()

            'objects
            Dim IsMultiSelect As Boolean = False
            Dim MaxSelectionCount As Integer = Nothing
            Dim WeekendDaysSelectable As Boolean = False

            If RadioButtonControlForm_CustomDateRange.Checked Then

                IsMultiSelect = True
                MaxSelectionCount = 6
                WeekendDaysSelectable = True

            ElseIf RadioButtonControlForm_FullWeek.Checked Then

                IsMultiSelect = True
                MaxSelectionCount = 6
                WeekendDaysSelectable = True

            ElseIf RadioButtonControlForm_SelectedDateOnly.Checked Then

                IsMultiSelect = False
                MaxSelectionCount = 0
                WeekendDaysSelectable = True

            ElseIf RadioButtonControlForm_WeekDay.Checked Then

                IsMultiSelect = True
                MaxSelectionCount = 4
                WeekendDaysSelectable = False

            End If

            MonthCalendarControl_TimesheetDates.MultiSelect = IsMultiSelect
            MonthCalendarControl_TimesheetDates.MaxSelectionCount = MaxSelectionCount
            MonthCalendarControl_TimesheetDates.WeekendDaysSelectable = WeekendDaysSelectable

        End Sub
        Private Sub SetCalendarSelection(ByVal SelectedDate As Date)

            'objects
            Dim FirstDayOfWeek As Date = Nothing

            MonthCalendarControl_TimesheetDates.BeginUpdate()

            If RadioButtonControlForm_FullWeek.Checked Then

                FirstDayOfWeek = GetFirstDayOfWeek(SelectedDate, MonthCalendarControl_TimesheetDates.FirstDayOfWeek, False)

                MonthCalendarControl_TimesheetDates.SetSelectionRange(FirstDayOfWeek, FirstDayOfWeek.AddDays(MonthCalendarControl_TimesheetDates.MaxSelectionCount))

            ElseIf RadioButtonControlForm_WeekDay.Checked Then

                FirstDayOfWeek = GetFirstDayOfWeek(SelectedDate, MonthCalendarControl_TimesheetDates.FirstDayOfWeek, True)

                MonthCalendarControl_TimesheetDates.SetSelectionRange(FirstDayOfWeek, FirstDayOfWeek.AddDays(MonthCalendarControl_TimesheetDates.MaxSelectionCount))

            End If

            MonthCalendarControl_TimesheetDates.EndUpdate()

        End Sub
        Private Function GetFirstDayOfWeek(ByVal SelectedWeekDate As Date, ByVal FirstDayOfWeek As System.DayOfWeek, ByVal IsWorkWeek As Boolean) As Date

            'objects
            Dim StartOfSelectedDate As Date = Nothing
            Dim DayList As Generic.Dictionary(Of Short, System.DayOfWeek) = Nothing
            Dim DaysToSubtract As Short = Nothing

            Try

                StartOfSelectedDate = SelectedWeekDate

                DayList = New Generic.Dictionary(Of Short, System.DayOfWeek)

                For I = FirstDayOfWeek To (FirstDayOfWeek + 6)

                    If I > 6 Then

                        DayList.Add(I - FirstDayOfWeek, DirectCast(I - 7, System.DayOfWeek))

                    Else

                        DayList.Add(I - FirstDayOfWeek, DirectCast(I, System.DayOfWeek))

                    End If

                Next

                DaysToSubtract = (From CustomDay In DayList
                                  Where CustomDay.Value = StartOfSelectedDate.DayOfWeek
                                  Select CustomDay.Key).SingleOrDefault()

                If DaysToSubtract > 0 Then

                    StartOfSelectedDate = StartOfSelectedDate.AddDays(-DaysToSubtract)

                End If

                If IsWorkWeek Then

                    If StartOfSelectedDate.DayOfWeek = DayOfWeek.Saturday OrElse StartOfSelectedDate.DayOfWeek = DayOfWeek.Sunday Then

                        Do Until StartOfSelectedDate.DayOfWeek = DayOfWeek.Monday

                            StartOfSelectedDate = StartOfSelectedDate.AddDays(1)

                        Loop

                    End If

                End If

            Catch ex As Exception
                StartOfSelectedDate = SelectedWeekDate
            End Try

            GetFirstDayOfWeek = StartOfSelectedDate

        End Function
        Private Function GetSelectedDateRange() As System.Windows.Forms.SelectionRange

            'objects
            Dim SelectionRange As System.Windows.Forms.SelectionRange = Nothing

            If MonthCalendarControl_TimesheetDates.MultiSelect = True Then

                SelectionRange = MonthCalendarControl_TimesheetDates.SelectionRange

            Else

                SelectionRange = New System.Windows.Forms.SelectionRange(MonthCalendarControl_TimesheetDates.SelectedDate, MonthCalendarControl_TimesheetDates.SelectedDate)

            End If

            GetSelectedDateRange = SelectionRange

        End Function
        Private Sub SaveDefaultDisplayDays()

            'objects
            Dim AppVar As AdvantageFramework.Database.Entities.AppVars = Nothing
            Dim IsNew As Boolean = False

            If RadioButtonControlForm_CustomDateRange.Checked = False Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Try

                        AppVar = (From Entity In AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationName(DbContext, Me.Session.UserCode, "TIMESHEET")
                                  Where Entity.Name = "DAYS_TO_DISPLAY"
                                  Select Entity).SingleOrDefault

                    Catch ex As Exception
                        AppVar = Nothing
                    End Try

                    If AppVar Is Nothing Then

                        IsNew = True

                        AppVar = New AdvantageFramework.Database.Entities.AppVars
                        AppVar.DbContext = DbContext
                        AppVar.Application = "TIMESHEET"
                        AppVar.UserCode = Me.Session.UserCode
                        AppVar.Group = "0"
                        AppVar.Name = "DAYS_TO_DISPLAY"

                    End If

                    If RadioButtonControlForm_FullWeek.Checked Then

                        AppVar.Value = "7"

                    ElseIf RadioButtonControlForm_SelectedDateOnly.Checked Then

                        AppVar.Value = "1"

                    ElseIf RadioButtonControlForm_WeekDay.Checked Then

                        AppVar.Value = "5"

                    End If

                    If IsNew = True Then

                        AdvantageFramework.Database.Procedures.AppVars.Insert(DbContext, AppVar)

                    Else

                        AdvantageFramework.Database.Procedures.AppVars.Update(DbContext, AppVar)

                    End If

                End Using

            End If

        End Sub
        Private Function LoadAppVar(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AppVarName As String) As AdvantageFramework.Database.Entities.AppVars

            'objects
            Dim AppVar As AdvantageFramework.Database.Entities.AppVars = Nothing

            Try

                AppVar = (From Entity In AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationName(DbContext, Me.Session.UserCode, "TIMESHEET")
                          Where Entity.Name = AppVarName
                          Select Entity).SingleOrDefault

            Catch ex As Exception
                AppVar = Nothing
            Finally
                LoadAppVar = AppVar
            End Try

        End Function
        Private Sub LoadSettings()

            'objects
            Dim DaysToDisplayAppVar As AdvantageFramework.Database.Entities.AppVars = Nothing
            Dim StartWeekOnAppVar As AdvantageFramework.Database.Entities.AppVars = Nothing
            Dim DaysToDisplay As Short = Nothing
            Dim FirstDayOfWeek As System.DayOfWeek = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DaysToDisplayAppVar = LoadAppVar(DbContext, AdvantageFramework.EmployeeTimesheet.Settings.DAYS_TO_DISPLAY.ToString)

                If DaysToDisplayAppVar IsNot Nothing Then

                    Try

                        DaysToDisplay = CShort(DaysToDisplayAppVar.Value)

                    Catch ex As Exception
                        DaysToDisplay = 7
                    End Try

                    If DaysToDisplay = 1 Then

                        RadioButtonControlForm_SelectedDateOnly.Checked = True

                    ElseIf DaysToDisplay = 5 Then

                        RadioButtonControlForm_WeekDay.Checked = True

                    Else

                        RadioButtonControlForm_FullWeek.Checked = True

                    End If

                Else

                    RadioButtonControlForm_FullWeek.Checked = True

                End If

                StartWeekOnAppVar = LoadAppVar(DbContext, AdvantageFramework.EmployeeTimesheet.Settings.START_WEEK_ON.ToString)

                If StartWeekOnAppVar IsNot Nothing Then

                    Select Case CStr(StartWeekOnAppVar.Value)

                        Case "0"

                            FirstDayOfWeek = DayOfWeek.Sunday

                        Case "1"

                            FirstDayOfWeek = DayOfWeek.Monday

                        Case "6"

                            FirstDayOfWeek = DayOfWeek.Saturday

                        Case Else

                            FirstDayOfWeek = DayOfWeek.Sunday

                    End Select

                Else

                    FirstDayOfWeek = DayOfWeek.Sunday

                End If

                MonthCalendarControl_TimesheetDates.FirstDayOfWeek = FirstDayOfWeek

            End Using

        End Sub
        Private Sub SetGroupByButtons()

            If TimesheetControlForm_Timesheet.TimesheetGroupByOption <> EmployeeTimesheet.TimesheetGroupByOptions.None Then

                ButtonItemGroupBy_Client.Checked = True

                Select Case TimesheetControlForm_Timesheet.TimesheetGroupByOption

                    Case EmployeeTimesheet.TimesheetGroupByOptions.Client

                        ButtonItemGroupBy_Division.Checked = False
                        ButtonItemGroupBy_Product.Checked = False
                        ButtonItemGroupBy_Job.Checked = False

                    Case EmployeeTimesheet.TimesheetGroupByOptions.ClientDivision

                        ButtonItemGroupBy_Division.Checked = True
                        ButtonItemGroupBy_Product.Checked = False
                        ButtonItemGroupBy_Job.Checked = False

                    Case EmployeeTimesheet.TimesheetGroupByOptions.ClientDivisionProduct

                        ButtonItemGroupBy_Division.Checked = True
                        ButtonItemGroupBy_Product.Checked = True
                        ButtonItemGroupBy_Job.Checked = False

                    Case EmployeeTimesheet.TimesheetGroupByOptions.ClientJob

                        ButtonItemGroupBy_Division.Checked = False
                        ButtonItemGroupBy_Product.Checked = False
                        ButtonItemGroupBy_Job.Checked = True

                    Case EmployeeTimesheet.TimesheetGroupByOptions.ClientDivisionJob

                        ButtonItemGroupBy_Division.Checked = True
                        ButtonItemGroupBy_Product.Checked = False
                        ButtonItemGroupBy_Job.Checked = True

                    Case EmployeeTimesheet.TimesheetGroupByOptions.ClientDivisionProductJob

                        ButtonItemGroupBy_Division.Checked = True
                        ButtonItemGroupBy_Product.Checked = True
                        ButtonItemGroupBy_Job.Checked = True

                End Select

            Else

                ButtonItemGroupBy_Client.Checked = False
                ButtonItemGroupBy_Division.Checked = False
                ButtonItemGroupBy_Product.Checked = False
                ButtonItemGroupBy_Job.Checked = False

            End If

        End Sub
        Private Sub HandleGroupByOption(ByVal SelectedOption As AdvantageFramework.EmployeeTimesheet.TimesheetGroupByOptions, ByVal Checked As Boolean)

            'objects
            Dim NewGroupByOption As AdvantageFramework.EmployeeTimesheet.TimesheetGroupByOptions = Nothing

            Select Case SelectedOption

                Case EmployeeTimesheet.TimesheetGroupByOptions.Client

                    If Checked Then

                        NewGroupByOption = EmployeeTimesheet.TimesheetGroupByOptions.Client

                    Else

                        NewGroupByOption = EmployeeTimesheet.TimesheetGroupByOptions.None

                    End If

                Case EmployeeTimesheet.TimesheetGroupByOptions.ClientDivision

                    If Checked Then

                        NewGroupByOption = EmployeeTimesheet.TimesheetGroupByOptions.ClientDivision

                    Else

                        NewGroupByOption = EmployeeTimesheet.TimesheetGroupByOptions.Client

                    End If

                Case EmployeeTimesheet.TimesheetGroupByOptions.ClientDivisionProduct

                    If Checked Then

                        NewGroupByOption = EmployeeTimesheet.TimesheetGroupByOptions.ClientDivisionProduct

                    Else

                        NewGroupByOption = EmployeeTimesheet.TimesheetGroupByOptions.ClientDivision

                    End If

                Case EmployeeTimesheet.TimesheetGroupByOptions.ClientJob

                    If ButtonItemGroupBy_Division.Checked Then

                        If ButtonItemGroupBy_Product.Checked Then

                            NewGroupByOption = EmployeeTimesheet.TimesheetGroupByOptions.ClientDivisionProduct

                        Else

                            NewGroupByOption = EmployeeTimesheet.TimesheetGroupByOptions.ClientDivision

                        End If

                    Else

                        NewGroupByOption = EmployeeTimesheet.TimesheetGroupByOptions.Client

                    End If

                Case Else

                    NewGroupByOption = EmployeeTimesheet.TimesheetGroupByOptions.None

            End Select

            If NewGroupByOption <> EmployeeTimesheet.TimesheetGroupByOptions.None Then

                If ButtonItemGroupBy_Job.Checked Then

                    Select Case NewGroupByOption

                        Case EmployeeTimesheet.TimesheetGroupByOptions.Client

                            NewGroupByOption = EmployeeTimesheet.TimesheetGroupByOptions.ClientJob

                        Case EmployeeTimesheet.TimesheetGroupByOptions.ClientDivision

                            NewGroupByOption = EmployeeTimesheet.TimesheetGroupByOptions.ClientDivisionJob

                        Case EmployeeTimesheet.TimesheetGroupByOptions.ClientDivisionProduct

                            NewGroupByOption = EmployeeTimesheet.TimesheetGroupByOptions.ClientDivisionProductJob

                    End Select

                End If

            End If

            TimesheetControlForm_Timesheet.TimesheetGroupByOption = NewGroupByOption

            SetGroupByButtons()
            EnableOrDisableActions()

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim EmployeeTimesheetForm As AdvantageFramework.Employee.Presentation.EmployeeTimesheetForm = Nothing

            EmployeeTimesheetForm = New AdvantageFramework.Employee.Presentation.EmployeeTimesheetForm()

            EmployeeTimesheetForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub EmployeeTimesheetForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            ButtonItemActions_AddCV.Visible = False

            RadioButtonControlForm_CustomDateRange.ByPassUserEntryChanged = True
            RadioButtonControlForm_FullWeek.ByPassUserEntryChanged = True
            RadioButtonControlForm_SelectedDateOnly.ByPassUserEntryChanged = True
            RadioButtonControlForm_WeekDay.ByPassUserEntryChanged = True

            ButtonItemActions_Search.Image = AdvantageFramework.My.Resources.DashboardAndQueryImage32x32
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Settings.Image = AdvantageFramework.My.Resources.LogAndSettingsImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemActions_AddCV.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Info.Image = AdvantageFramework.My.Resources.RowInfoImage
            ButtonItemActions_Settings.Image = AdvantageFramework.My.Resources.LogAndSettingsImage
            ButtonItemActions_Approval.Image = AdvantageFramework.My.Resources.TimesheetApprovalImage
            ButtonItemActions_Print.Image = AdvantageFramework.My.Resources.PrintImage

            ButtonItemOptions_Cancel.Image = AdvantageFramework.My.Resources.DetailCancelImage
            ButtonItemOptions_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemOptions_Copy.Image = AdvantageFramework.My.Resources.CopyImage
            ButtonItemOptions_Refresh.Image = AdvantageFramework.My.Resources.RefreshImage

            SearchableComboBoxSearch_Employees.ByPassUserEntryChanged = True
            SearchableComboBoxSearch_Employees.BringToFront()

            MonthCalendarControl_TimesheetDates.MaxSelectionCount = 6
            RadioButtonControlForm_CustomDateRange.Checked = True

            MonthCalendarControl_TimesheetDates.SelectionStart = System.DateTime.Today
            MonthCalendarControl_TimesheetDates.SelectionEnd = System.DateTime.Today
            MonthCalendarControl_TimesheetDates.DisplayMonth = System.DateTime.Today

            ButtonItemGroupBy_Client.Tag = AdvantageFramework.EmployeeTimesheet.TimesheetGroupByOptions.Client
            ButtonItemGroupBy_Division.Tag = AdvantageFramework.EmployeeTimesheet.TimesheetGroupByOptions.ClientDivision
            ButtonItemGroupBy_Product.Tag = AdvantageFramework.EmployeeTimesheet.TimesheetGroupByOptions.ClientDivisionProduct
            ButtonItemGroupBy_Job.Tag = AdvantageFramework.EmployeeTimesheet.TimesheetGroupByOptions.ClientJob

            'MonthCalendarControl_TimesheetDates.Colors.Selection.BackColor = System.Drawing.Color.FromArgb(48, 153, 255)
            'MonthCalendarControl_TimesheetDates.Colors.Selection.BackColor2 = System.Drawing.Color.FromArgb(48, 153, 255)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ButtonItemActions_Info.Visible = CBool(AdvantageFramework.Database.Procedures.Agency.Load(DbContext).QVAQuery.GetValueOrDefault(0))

            End Using

            LoadSettings()

            SetupSearchByProperties()

            Try

                LoadEmployees()

            Catch ex As Exception

            End Try

            Try

                LoadTimesheet()

            Catch ex As Exception

            End Try

            Try

                LoadEmployeeApprovalData()

            Catch ex As Exception

            End Try

            Try

                SetGroupByButtons()

            Catch ex As Exception

            End Try

            Try

                LoadEmployeeCalendarData()

            Catch ex As Exception

            End Try

            AddHandler TimesheetControlForm_Timesheet.ExpandablePanelControl_Options.ExpandedChanged, AddressOf ExpandablePanel_ExpandedChanged

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            EnableOrDisableActions()

        End Sub
        Private Sub EmployeeTimesheetForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub EmployeeTimesheetForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub MonthCalendarControl_TimesheetDates_PaintLabel(sender As Object, e As DevComponents.Editors.DateTimeAdv.DayPaintEventArgs) Handles MonthCalendarControl_TimesheetDates.PaintLabel

            'objects
            Dim DayLabel As DevComponents.Editors.DateTimeAdv.DayLabel = Nothing
            Dim DayStatus As AdvantageFramework.EmployeeTimesheet.Classes.DayStatus = Nothing
            Dim ToolTip As String = Nothing
            Dim MissingHours As Decimal = 0
            Dim DayApprovalType As AdvantageFramework.EmployeeTimesheet.DayApprovalType = Nothing
            Dim BackColor As System.Drawing.Color = Nothing
            Dim BackColor2 As System.Drawing.Color = Nothing
            Dim Status As String = Nothing
            Dim WeekStart As Date = Nothing
            Dim WeekEnd As Date = Nothing
            Dim RequiredHours As Decimal = 0
            Dim ActualHours As Decimal = 0
            Dim StringBuilder As System.Text.StringBuilder = Nothing
            Dim MissingHoursString As String = ""
            Dim SuperTooltipInfo As DevComponents.DotNetBar.SuperTooltipInfo = Nothing
            Dim Alpha As Integer = 0
            Dim ShowMissingTimeIndicator As Boolean = False

            If TypeOf sender Is DevComponents.Editors.DateTimeAdv.DayLabel Then

                Try

                    DayLabel = DirectCast(sender, DevComponents.Editors.DateTimeAdv.DayLabel)

                Catch ex As Exception
                    DayLabel = Nothing
                End Try

                If DayLabel IsNot Nothing Then

                    If DayLabel.Date <> Nothing Then

                        If _DayStatusList IsNot Nothing Then

                            Try

                                DayStatus = (From Entity In _DayStatusList
                                             Where Entity.DayDate = DayLabel.Date
                                             Select Entity).SingleOrDefault

                            Catch ex As Exception
                                DayStatus = Nothing
                            End Try

                            If DayStatus IsNot Nothing Then

                                StringBuilder = New System.Text.StringBuilder

                                DayApprovalType = DayStatus.Status

                                If DayApprovalType = EmployeeTimesheet.DayApprovalType.Pending Then

                                    'orange
                                    BackColor = System.Drawing.Color.FromArgb(255, 205, 168)
                                    BackColor2 = System.Drawing.Color.FromArgb(255, 106, 0)
                                    Status = "Pending"

                                ElseIf DayApprovalType = EmployeeTimesheet.DayApprovalType.Approved Then

                                    'green
                                    BackColor = System.Drawing.Color.FromArgb(0, 255, 33)
                                    BackColor2 = System.Drawing.Color.FromArgb(0, 127, 14)
                                    Status = "Approved"

                                ElseIf DayApprovalType = EmployeeTimesheet.DayApprovalType.Denied Then

                                    'purple
                                    BackColor = System.Drawing.Color.FromArgb(255, 168, 247)
                                    BackColor2 = System.Drawing.Color.FromArgb(178, 0, 255)
                                    Status = "Denied"

                                ElseIf DayApprovalType = EmployeeTimesheet.DayApprovalType.Entered Then

                                    'blue
                                    BackColor = System.Drawing.Color.FromArgb(147, 217, 255)
                                    BackColor2 = System.Drawing.Color.FromArgb(0, 148, 255)
                                    Status = "Entered"

                                ElseIf DayApprovalType = AdvantageFramework.EmployeeTimesheet.DayApprovalType.PostPeriodClosed Then

                                    'gray
                                    BackColor = System.Drawing.Color.FromArgb(192, 192, 192)
                                    BackColor2 = System.Drawing.Color.FromArgb(128, 128, 128)
                                    Status = "Post Period Closed"

                                Else

                                    If DayApprovalType = EmployeeTimesheet.DayApprovalType.ReadyToSubmit Then

                                        'aqua
                                        BackColor = System.Drawing.Color.FromArgb(196, 255, 255)
                                        BackColor2 = System.Drawing.Color.FromArgb(0, 255, 255)
                                        Status = "Ready to Submit"

                                    ElseIf DayApprovalType = EmployeeTimesheet.DayApprovalType.NotSubmitted Then

                                        'yellow
                                        BackColor = System.Drawing.Color.FromArgb(255, 243, 118)
                                        BackColor2 = System.Drawing.Color.FromArgb(255, 216, 0)
                                        Status = "Not Submitted"

                                    ElseIf DayApprovalType = EmployeeTimesheet.DayApprovalType.Missing Then

                                        'red
                                        If DayLabel.Date <= System.DateTime.Today Then

                                            ShowMissingTimeIndicator = True

                                        ElseIf TimesheetControlForm_Timesheet.ReportMissingTime = Database.Entities.ReportMissingTime.ByWeek Then

                                            WeekStart = System.DateTime.Today

                                            If WeekStart.DayOfWeek <> MonthCalendarControl_TimesheetDates.FirstDayOfWeek Then

                                                While WeekStart.DayOfWeek <> MonthCalendarControl_TimesheetDates.FirstDayOfWeek

                                                    WeekStart = WeekStart.AddDays(-1)

                                                End While

                                            End If

                                            WeekEnd = WeekStart.AddDays(6)

                                            If DayLabel.Date >= WeekStart AndAlso DayLabel.Date <= WeekEnd Then

                                                ShowMissingTimeIndicator = True

                                            End If

                                        End If

                                        If ShowMissingTimeIndicator Then

                                            'red
                                            BackColor = System.Drawing.Color.FromArgb(253, 41, 39)
                                            BackColor2 = System.Drawing.Color.FromArgb(153, 27, 26)
                                            Status = "Missing"

                                        End If

                                    Else

                                        BackColor = Nothing
                                        BackColor2 = Nothing
                                        Status = Nothing

                                    End If

                                    If TimesheetControlForm_Timesheet.SupervisorApprovalRequired Then

                                        If TimesheetControlForm_Timesheet.ReportMissingTime = Database.Entities.ReportMissingTime.ByWeek Then

                                            WeekStart = DayLabel.Date

                                            If WeekStart.DayOfWeek <> MonthCalendarControl_TimesheetDates.FirstDayOfWeek Then

                                                While WeekStart.DayOfWeek <> MonthCalendarControl_TimesheetDates.FirstDayOfWeek

                                                    WeekStart = WeekStart.AddDays(-1)

                                                End While

                                            End If

                                            WeekEnd = WeekStart.AddDays(6)

                                            For Each WeekDayStatus In (From Entity In _DayStatusList
                                                                       Where Entity.DayDate >= WeekStart AndAlso
                                                                             Entity.DayDate <= WeekEnd
                                                                       Select Entity).ToList

                                                RequiredHours = RequiredHours + WeekDayStatus.StandardHours
                                                ActualHours = ActualHours + WeekDayStatus.TotalHours

                                            Next

                                            If RequiredHours > ActualHours Then

                                                MissingHours = RequiredHours - ActualHours

                                                MissingHoursString = MissingHours.ToString & " from " & WeekStart.ToShortDateString & " to " & WeekEnd.ToShortDateString

                                                If ActualHours > 0 Then

                                                    BackColor = Drawing.Color.Red
                                                    BackColor2 = Drawing.Color.Yellow

                                                End If

                                            End If

                                        Else

                                            If DayStatus.MissingHours > 0 AndAlso DayStatus.DayDate <= System.DateTime.Today Then

                                                MissingHours = DayStatus.MissingHours

                                                MissingHoursString = MissingHours.ToString

                                                If DayStatus.TotalHours > 0 Then

                                                    BackColor = Drawing.Color.Red
                                                    BackColor2 = Drawing.Color.Yellow

                                                End If

                                            End If

                                        End If

                                    End If

                                End If

                                If String.IsNullOrWhiteSpace(Status) = False Then

                                    If DayLabel.Date.Month <> MonthCalendarControl_TimesheetDates.DisplayMonth.Month Then

                                        Alpha = 50

                                    Else

                                        Alpha = 255

                                    End If

                                    DayLabel.BackgroundStyle.MarginTop = 1
                                    DayLabel.BackgroundStyle.MarginLeft = 1
                                    DayLabel.BackgroundStyle.MarginRight = 1
                                    DayLabel.BackgroundStyle.MarginBottom = 1
                                    DayLabel.BackgroundStyle.BackColorGradientAngle = 90
                                    DayLabel.BackgroundStyle.BackColorGradientType = DevComponents.DotNetBar.eGradientType.Linear

                                    DayLabel.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(Alpha, BackColor)
                                    DayLabel.BackgroundStyle.BackColor2 = System.Drawing.Color.FromArgb(Alpha, BackColor2)

                                    SuperTooltipInfo = New DevComponents.DotNetBar.SuperTooltipInfo

                                    SuperTooltipInfo.BodyText = "<strong>Status:</strong> " & Status & "<br/>" &
                                                                "<strong>Standard Hours:</strong> " & DayStatus.StandardHours.ToString("N2") & "<br/>" &
                                                                "<strong>Total Hours:</strong> " & DayStatus.TotalHours.ToString("N2") & "<br/>"

                                    If String.IsNullOrWhiteSpace(MissingHoursString) = False Then

                                        SuperTooltipInfo.BodyText &= "<strong>Missing Hours:</strong> " & MissingHoursString

                                    End If

                                    SuperTooltipForm_ToolTip.SetSuperTooltip(DayLabel, SuperTooltipInfo)

                                End If

                            End If

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub MonthCalendarControl_TimesheetDates_MonthChanged(sender As Object, e As EventArgs) Handles MonthCalendarControl_TimesheetDates.MonthChanged

            If Me.FormShown = True Then

                If Me.FormAction = WinForm.Presentation.FormActions.None Then

                    Me.FormAction = WinForm.Presentation.FormActions.Modifying

                    LoadEmployeeCalendarData()

                    Me.FormAction = WinForm.Presentation.FormActions.None

                End If

            End If

        End Sub
        Private Sub MonthCalendarControl_TimesheetDates_DateSelected(sender As Object, e As Windows.Forms.DateRangeEventArgs) Handles MonthCalendarControl_TimesheetDates.DateSelected

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                SetCalendarSelection(MonthCalendarControl_TimesheetDates.SelectionStart)
                Search()

            End If

        End Sub
        Private Sub RadioButtonHandler_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonControlForm_CustomDateRange.CheckedChangedEx,
                                                                                                                                                  RadioButtonControlForm_FullWeek.CheckedChangedEx,
                                                                                                                                                  RadioButtonControlForm_SelectedDateOnly.CheckedChangedEx,
                                                                                                                                                  RadioButtonControlForm_WeekDay.CheckedChangedEx

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                If e.EventSource <> DevComponents.DotNetBar.eEventSource.Code AndAlso e.NewChecked.Checked = True Then

                    If CheckForUnsavedChanges() Then

                        Me.FormAction = WinForm.Presentation.FormActions.Loading

                        SetupSearchByProperties()

                        SaveDefaultDisplayDays()

                        LoadTimesheet()

                        Me.ClearChanged()

                        Me.FormAction = WinForm.Presentation.FormActions.None

                        EnableOrDisableActions()

                    Else

                        Me.FormAction = WinForm.Presentation.FormActions.Modifying

                        e.NewChecked.Checked = False
                        e.OldChecked.Checked = True
                        e.OldChecked.Focus()

                        Me.FormAction = WinForm.Presentation.FormActions.None

                    End If

                End If

            End If

        End Sub

#Region "  Ribbon Bar Control Events "

        Private Sub ButtonItemActions_AddCV_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_AddCV.Click

            'objects
            Dim ErrorMessage As String = Nothing

            If CheckForUnsavedChanges() Then

                Try

                    If TimesheetControlForm_Timesheet.AddNewCommentView() Then

                        Me.ClearChanged()

                        LoadTimesheet()

                    End If

                Catch ex As Exception
                    AdvantageFramework.Navigation.ShowMessageBox(ex.Message)
                End Try

            End If

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemActions_Settings_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Settings.Click

            'objects
            Dim ErrorMessage As String = Nothing

            If CheckForUnsavedChanges() Then

                Try

                    If TimesheetControlForm_Timesheet.OpenTimesheetSettings() Then

                        Me.ClearChanged()

                        LoadSettings()
                        SetupSearchByProperties()
                        LoadTimesheet()

                    End If

                Catch ex As Exception
                    AdvantageFramework.Navigation.ShowMessageBox(ex.Message)
                End Try

            End If

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            Save()

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Cancel.Click

            TimesheetControlForm_Timesheet.TimeEntriesDataGridView.CancelNewItemRow()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemActions_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Delete.Click

            TimesheetControlForm_Timesheet.Delete()

            LoadEmployeeCalendarData()

            EnableOrDisableActions()

        End Sub
        Private Sub SearchableComboBoxSearch_Employees_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxSearch_Employees.EditValueChanged

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                LoadEmployeeApprovalData()

                If Search() Then

                    LoadEmployeeCalendarData()

                End If

            End If

        End Sub
        Private Sub ButtonItemOptions_Copy_Click(sender As Object, e As EventArgs) Handles ButtonItemOptions_Copy.Click

            'objects
            Dim ContinueCopy As Boolean = False

            ContinueCopy = CheckForUnsavedChanges()

            If ContinueCopy Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading, "Loading...")

                Try

                    If TimesheetControlForm_Timesheet.CopyItem() Then

                        Me.ClearChanged()

                        LoadTimesheet()

                        LoadEmployeeCalendarData()

                    End If

                Catch ex As Exception
                    AdvantageFramework.Navigation.ShowMessageBox(ex.Message)
                End Try

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

            End If

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemOptions_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemOptions_Delete.Click

            Try

                TimesheetControlForm_Timesheet.DeleteCopyItem()

            Catch ex As Exception
                AdvantageFramework.Navigation.ShowMessageBox(ex.Message)
            End Try

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemOptions_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemOptions_Cancel.Click

            TimesheetControlForm_Timesheet.CurrentCopyFromDataGridView.CancelNewItemRow()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemOptions_Refresh_Click(sender As Object, e As EventArgs) Handles ButtonItemOptions_Refresh.Click

            TimesheetControlForm_Timesheet.ResetCopyOptions()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemActions_Approval_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Approval.Click

            If CheckForUnsavedChanges() Then

                Try

                    If TimesheetControlForm_Timesheet.SetApproval() Then

                        Me.ClearChanged()

                        LoadEmployeeCalendarData()

                        LoadTimesheet()

                    End If

                Catch ex As Exception
                    AdvantageFramework.Navigation.ShowMessageBox(ex.Message)
                End Try

            End If

        End Sub
        Private Sub ButtonItemActions_Info_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Info.Click

            TimesheetControlForm_Timesheet.ViewDirectTimeDetails()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemActions_Print_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Print.Click

            TimesheetControlForm_Timesheet.Print()

        End Sub
        Private Sub ButtonItemActions_Search_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Search.Click

            'objects
            Dim ErrorMessage As String = Nothing
            Dim EmployeeCode As String = Nothing
            Dim DateToSelect As Date = Nothing

            If CheckForUnsavedChanges() Then

                Try

                    EmployeeCode = SearchableComboBoxSearch_Employees.GetSelectedValue

                    If AdvantageFramework.Employee.Presentation.TimesheetSearchDialog.ShowFormDialog(EmployeeCode, DateToSelect) = Windows.Forms.DialogResult.OK Then

                        Me.FormAction = WinForm.Presentation.FormActions.Loading

                        RadioButtonControlForm_SelectedDateOnly.Checked = True

                        SetupSearchByProperties()

                        Me.FormAction = WinForm.Presentation.FormActions.None

                        MonthCalendarControl_TimesheetDates.SelectedDate = DateToSelect

                        EnableOrDisableActions()

                    End If

                Catch ex As Exception
                    AdvantageFramework.Navigation.ShowMessageBox(ex.Message)
                End Try

            End If

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemGroupBy_Client_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemGroupBy_Client.CheckedChanged, ButtonItemGroupBy_Division.CheckedChanged, _
                                                                                                      ButtonItemGroupBy_Product.CheckedChanged, ButtonItemGroupBy_Job.CheckedChanged

            'objects
            Dim ButtonItem As DevComponents.DotNetBar.ButtonItem = Nothing

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                Me.FormAction = WinForm.Presentation.FormActions.Loading

                ButtonItem = DirectCast(sender, DevComponents.DotNetBar.ButtonItem)

                HandleGroupByOption(ButtonItem.Tag, ButtonItem.Checked)

                Me.FormAction = WinForm.Presentation.FormActions.None

            End If

        End Sub

#End Region

#Region "  Timesheet Control Events "

        Private Sub TimesheetControlForm_Timesheet_RecordAddedEvent() Handles TimesheetControlForm_Timesheet.RecordAddedEvent

            LoadEmployeeCalendarData()

            EnableOrDisableActions()

        End Sub
        Private Sub TimesheetControlForm_Timesheet_SelectedEntryChangedEvent() Handles TimesheetControlForm_Timesheet.SelectedEntryChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub TimesheetControlForm_Timesheet_SelectedCopyOptionChangedEvent() Handles TimesheetControlForm_Timesheet.SelectedCopyOptionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub ExpandablePanel_ExpandedChanged(ByVal sender As Object, ByVal e As DevComponents.DotNetBar.ExpandedChangeEventArgs)

            EnableOrDisableActions()

        End Sub

#End Region

#End Region

#End Region

    End Class

End Namespace