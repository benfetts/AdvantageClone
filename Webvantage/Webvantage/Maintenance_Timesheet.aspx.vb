Imports Webvantage.wvTimeSheet

Public Class Maintenance_Timesheet
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private IsUserSettings As Boolean = False
    Private DaysToShow As Integer = 0
    Private StartWeekOn As String = ""
    Private ShowCommentUsing As String = ""
    Private DivisionLabel As String = ""
    Private ProductLabel As String = ""
    Private ProductCategoryLabel As String = ""
    Private JobLabel As String = ""
    Private JobComponentLabel As String = ""
    Private FunctionCategoryLabel As String = ""

#End Region

#Region " Properties "



#End Region

#Region " Methods "

#Region " Controls "

    Private Sub RadComboBoxDaysToDisplay_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxDaysToDisplay.SelectedIndexChanged

        If IsUserSettings = True Then

            Dim av As New cAppVars(cAppVars.Application.TIMESHEET)
            av.getAllAppVars()
            av.setAppVar("DAYS_TO_DISPLAY", Me.RadComboBoxDaysToDisplay.SelectedValue, "Integer")
            av.SaveAllAppVars()

            Select Case Me.RadComboBoxDaysToDisplay.SelectedItem.Value
                Case "1"
                    Session("TimesheetMain_UserHasMadeASelection") = Nothing
                Case "5"
                    Session("TimesheetMain_UserHasMadeASelection") = "all5"
                    Session("TimesheetMain_SingleViewDayOfWeek") = Nothing
                Case "7"
                    Session("TimesheetMain_UserHasMadeASelection") = "all7"
                    Session("TimesheetMain_SingleViewDayOfWeek") = Nothing
            End Select

        Else

            Dim ts As New AdvantageFramework.Timesheet.TimesheetSettings(Session("ConnString"), Session("UserCode"))
            Dim s As String = ""

            If ts.SaveAgencySettings(CType(RadComboBoxDaysToDisplay.SelectedValue, Integer), s) = False Then

                Me.ShowMessage(MiscFN.JavascriptSafe(s))

            End If

        End If

        Dim c As New cTimeSheet(Session("ConnString"))
        c.ClearSessionTimesheetSettings(Session("UserCode"))

        'Session("TimesheetMain_UserHasMadeASelection") = Nothing

    End Sub
    Private Sub RadComboBoxShowComments_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxShowComments.SelectedIndexChanged
        If IsUserSettings = True Then
            Dim av As New cAppVars(cAppVars.Application.TIMESHEET)
            av.getAllAppVars()
            av.setAppVar("SHOW_CMNT_USING", Me.RadComboBoxShowComments.SelectedValue, "String")
            av.SaveAllAppVars()
        Else
        End If
        Dim c As New cTimeSheet(Session("ConnString"))
        c.ClearSessionTimesheetSettings(Session("UserCode"))
    End Sub
    Private Sub RadComboBoxStartWeekOn_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxStartWeekOn.SelectedIndexChanged
        If IsUserSettings = True Then

            Dim av As New cAppVars(cAppVars.Application.TIMESHEET)

            av.getAllAppVars()
            av.setAppVar("START_WEEK_ON", Me.RadComboBoxStartWeekOn.SelectedValue, "Integer")
            av.SaveAllAppVars()

        Else

            Dim s As String = ""
            Dim EntryOptions As New AdvantageFramework.Timesheet.Settings.AgencyTimeEntryOptions(Session("ConnString"))

            If EntryOptions.Load(s) = False Then

                Me.ShowMessage(AdvantageFramework.StringUtilities.JavascriptSafe(s))

            Else

                EntryOptions.StartTimesheetOnDayOfWeek = Me.RadComboBoxStartWeekOn.SelectedValue

                If EntryOptions.Save(s) = False Then

                    Me.ShowMessage(AdvantageFramework.StringUtilities.JavascriptSafe(s))

                End If

            End If

        End If

        Dim c As New cTimeSheet(Session("ConnString"))
        c.ClearSessionTimesheetSettings(Session("UserCode"))

    End Sub
    Private Sub CheckBoxDisablePagingOnMainGrid_CheckedChanged(sender As Object, e As System.EventArgs) Handles CheckBoxDisablePagingOnMainGrid.CheckedChanged
        If IsUserSettings = True Then
            Dim av As New cAppVars(cAppVars.Application.TIMESHEET)
            av.getAllAppVars()
            av.setAppVar("MAIN_TS_NO_PAGING", Me.CheckBoxDisablePagingOnMainGrid.Checked.ToString(), "Boolean")
            av.SaveAllAppVars()
        Else
        End If
        Dim c As New cTimeSheet(Session("ConnString"))
        c.ClearSessionTimesheetSettings(Session("UserCode"))
    End Sub
    Private Sub ButtonSaveLabels_Click(sender As Object, e As System.EventArgs) Handles ButtonSaveLabels.Click
        Try

            Dim s As String = ""
            Dim NewSettings As New AdvantageFramework.Timesheet.Settings.DisplaySettings

            With NewSettings

                .DaysToDisplay = CType(Me.RadComboBoxDaysToDisplay.SelectedValue, Integer)
                .ShowCommentsUsing = Me.RadComboBoxShowComments.SelectedValue
                .StartTimesheetOnDayOfWeek = Me.RadComboBoxStartWeekOn.SelectedValue
                .DisablePagingOnMainGrid = Me.CheckBoxDisablePagingOnMainGrid.Checked
                .RepeatRowForAllDays = Me.CheckBoxRepeatRowForAllDays.Checked
                .OnlyShowMyProgress = Me.CheckBoxOnlyShowMyProgress.Checked

                .Labels.Division = Me.TextBoxDivisionLabel.Text
                .Labels.Product = Me.TextBoxProductLabel.Text
                .Labels.ProdCat = Me.TextBoxProductCategoryLabel.Text
                .Labels.Job = Me.TextBoxJobLabel.Text
                .Labels.JobComponent = Me.TextBoxComponentLabel.Text
                .Labels.FuncCat = Me.TextBoxFunctionCategoryLabel.Text

            End With

            If IsUserSettings = True Then

                Dim av As New cAppVars(cAppVars.Application.TIMESHEET)
                av.getAllAppVars()
                av.setAppVar("DAYS_TO_DISPLAY", NewSettings.DaysToDisplay, "Integer")
                av.setAppVar("SHOW_CMNT_USING", NewSettings.ShowCommentsUsing, "String")
                av.setAppVar("START_WEEK_ON", NewSettings.StartTimesheetOnDayOfWeek, "Integer")
                av.setAppVar("MAIN_TS_NO_PAGING", NewSettings.DisablePagingOnMainGrid.ToString(), "Boolean")
                av.setAppVar("REPEAT_ROWS", NewSettings.RepeatRowForAllDays.ToString(), "Boolean")
                av.setAppVar("ONLY_SHOW_MY_PROGRESS", NewSettings.OnlyShowMyProgress.ToString(), "Boolean")

                av.setAppVar("DIVISION", NewSettings.Labels.Division, "String")
                av.setAppVar("PRODUCT", NewSettings.Labels.Product, "String")
                av.setAppVar("PROD_CAT", NewSettings.Labels.ProdCat, "String")
                av.setAppVar("JOB", NewSettings.Labels.Job, "String")
                av.setAppVar("JOB_COMP", NewSettings.Labels.JobComponent, "String")
                av.setAppVar("FUNC_CAT", NewSettings.Labels.FuncCat, "String")

                av.SaveAllAppVars()

            Else

                Dim ts As New AdvantageFramework.Timesheet.TimesheetSettings(Session("ConnString"), Session("UserCode"))

                If ts.SaveAgencySettings(NewSettings, s) = False Then

                    Me.ShowMessage(MiscFN.JavascriptSafe(s))

                End If

            End If

            Dim c As New cTimeSheet(Session("ConnString"))
            c.ClearSessionTimesheetSettings(Session("UserCode"))

            'reload
            If IsUserSettings = True Then

                MiscFN.ResponseRedirect("Maintenance_Timesheet.aspx?my=1")

            Else

                MiscFN.ResponseRedirect("Maintenance_Timesheet.aspx")

            End If

        Catch ex As Exception

            Me.ShowMessage(MiscFN.JavascriptSafe(ex.Message.ToString()))

        End Try
    End Sub
    Private Sub ButtonSaveTimeEntryOptions_Click(sender As Object, e As EventArgs) Handles ButtonSaveTimeEntryOptions.Click

        Dim EntryOptions As New AdvantageFramework.Timesheet.Settings.AgencyTimeEntryOptions(_Session.ConnectionString, _Session.UserCode)
        Dim s As String = ""

        If EntryOptions.Load(s) = False Then

            Me.ShowMessage(AdvantageFramework.StringUtilities.JavascriptSafe(s))

        Else

            EntryOptions.AllTimeEntryMinimumTime = Me.RadComboBoxAllTimeEntryMinimumTime.SelectedItem.Value
            EntryOptions.AllTimeEntryRoundToNextIncrement = Me.RadComboBoxAllTimeEntryRoundToNextIncrement.SelectedItem.Value
            EntryOptions.StopwatchMinimumTime = Me.RadComboBoxStopwatchMinimumTime.SelectedItem.Value
            EntryOptions.StopwatchRoundToNextIncrement = Me.RadComboBoxStopwatchRoundToNextIncrement.SelectedItem.Value
            EntryOptions.CommentsRequiredWhenSubmittingForApproval = Me.CheckBoxCommentsRequiredWhenSubmittingForApproval.Checked
            EntryOptions.StartTimesheetOnDayOfWeek = Me.RadComboBoxStartWeekOn.SelectedValue
            EntryOptions.RequireAssignment = Me.CheckBoxRequireTimeEntryByAssignment.Checked
            EntryOptions.RequiredHoursMetBeforeAllowSubmitForApproval = Me.CheckBoxRequiredHoursMetBeforeAllowSubmitForApproval.Checked

            If Me.RadioButtonByDay.Checked = True Then

                EntryOptions.RequiredHoursMetBeforeAllowSubmitForApprovalType = AdvantageFramework.Timesheet.Settings.AgencyTimeEntryOptions.AllowSubmitForApprovalType.ByDay

            ElseIf Me.RadioButtonByWeek.Checked = True Then

                EntryOptions.RequiredHoursMetBeforeAllowSubmitForApprovalType = AdvantageFramework.Timesheet.Settings.AgencyTimeEntryOptions.AllowSubmitForApprovalType.ByWeek

            Else

                EntryOptions.RequiredHoursMetBeforeAllowSubmitForApprovalType = AdvantageFramework.Timesheet.Settings.AgencyTimeEntryOptions.AllowSubmitForApprovalType.ByDay
                Me.RadioButtonByDay.Checked = True

            End If

            If EntryOptions.Save(s) = False Then

                Me.ShowMessage(AdvantageFramework.StringUtilities.JavascriptSafe(s))

            End If

        End If

        Dim c As New cTimeSheet(Session("ConnString"))
        c.ClearSessionTimesheetSettings(Session("UserCode"))

    End Sub
    Private Sub CheckBoxRepeatRowForAllDays_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxRepeatRowForAllDays.CheckedChanged
        If IsUserSettings = True Then
            Dim av As New cAppVars(cAppVars.Application.TIMESHEET)
            av.getAllAppVars()
            av.setAppVar("REPEAT_ROWS", Me.CheckBoxRepeatRowForAllDays.Checked.ToString(), "Boolean")
            av.SaveAllAppVars()
        End If
        Dim c As New cTimeSheet(Session("ConnString"))
        c.ClearSessionTimesheetSettings(Session("UserCode"))
    End Sub
    Private Sub CheckBoxOnlyShowMyProgress_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxOnlyShowMyProgress.CheckedChanged
        If IsUserSettings = True Then
            Dim av As New cAppVars(cAppVars.Application.TIMESHEET)
            av.getAllAppVars()
            av.setAppVar("ONLY_SHOW_MY_PROGRESS", Me.CheckBoxOnlyShowMyProgress.Checked.ToString(), "Boolean")
            av.SaveAllAppVars()
        End If
        Dim c As New cTimeSheet(Session("ConnString"))
        c.ClearSessionTimesheetSettings(Session("UserCode"))
    End Sub

#End Region
#Region " Page "

    Private Sub Maintenance_Timesheet_Init(sender As Object, e As System.EventArgs) Handles Me.Init
        Try
            If Not Request.QueryString("my") Is Nothing Then
                Me.IsUserSettings = CType(Request.QueryString("my"), Integer) = 1
            End If
        Catch ex As Exception
            Me.ShowMessage(MiscFN.JavascriptSafe(ex.Message.ToString()))
        End Try
    End Sub
    Protected Sub Maintenance_Timesheet_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.IsPostBack And Not Me.IsCallback Then

            Dim c As New cTimeSheet(Session("ConnString"))

            If IsUserSettings = True Then

                Me.PageTitle = "My Timesheet Settings"

            Else

                Me.PageTitle = "Agency Timesheet Settings"
                Me.TrDisablePagingOnMainGrid.Visible = False
                Me.TrRepeatRowForAllDays.Visible = False

            End If

            Me.TrOnlyShowMyProgress.Visible = False

            Dim s As String = ""

            Dim UserCode As String = Session("UserCode")
            If IsUserSettings = False Then UserCode = ""

            Me.TableAgencyOptions.Visible = Not IsUserSettings
            'Me.DivStartWeekOn.Visible = Not IsUserSettings

            Me.LoadStartOfWeek()

            Dim tm As New AdvantageFramework.Timesheet.TimesheetSettings(Session("ConnString"), Session("UserCode"))
            Dim TsSettings As New AdvantageFramework.Timesheet.Settings.DisplaySettings

            TsSettings = tm.GetSettings(UserCode, s)

            If TsSettings Is Nothing Then

                Me.ShowMessage(s)
                Exit Sub

            Else

                With TsSettings

                    Me.DaysToShow = .DaysToDisplay
                    Me.StartWeekOn = .StartTimesheetOnDayOfWeek
                    Me.ShowCommentUsing = .ShowCommentsUsing
                    Me.DivisionLabel = .Labels.Division
                    Me.ProductLabel = .Labels.Product
                    Me.ProductCategoryLabel = .Labels.ProdCat
                    Me.JobLabel = .Labels.Job
                    Me.JobComponentLabel = .Labels.JobComponent
                    Me.FunctionCategoryLabel = .Labels.FuncCat
                    Me.CheckBoxDisablePagingOnMainGrid.Checked = .DisablePagingOnMainGrid
                    Me.CheckBoxRepeatRowForAllDays.Checked = .RepeatRowForAllDays
                    Me.CheckBoxOnlyShowMyProgress.Checked = .OnlyShowMyProgress
                    Me.CheckBoxAgencyOverride.Checked = .AgencyOverride

                End With

                MiscFN.RadComboBoxSetIndex(Me.RadComboBoxDaysToDisplay, Me.DaysToShow, False)
                MiscFN.RadComboBoxSetIndex(Me.RadComboBoxShowComments, Me.ShowCommentUsing, False)
                MiscFN.RadComboBoxSetIndex(Me.RadComboBoxStartWeekOn, Me.StartWeekOn, False)

                Me.TextBoxDivisionLabel.Text = Me.DivisionLabel
                Me.TextBoxProductLabel.Text = Me.ProductLabel
                Me.TextBoxProductCategoryLabel.Text = Me.ProductCategoryLabel
                Me.TextBoxJobLabel.Text = Me.JobLabel
                Me.TextBoxComponentLabel.Text = Me.JobComponentLabel
                Me.TextBoxFunctionCategoryLabel.Text = Me.FunctionCategoryLabel

            End If

            If Me.IsUserSettings = False Then

                Dim EntryOptions As New AdvantageFramework.Timesheet.Settings.AgencyTimeEntryOptions(Session("ConnString"))

                s = ""
                If EntryOptions.Load(s) = False Then

                    Me.ShowMessage(AdvantageFramework.StringUtilities.JavascriptSafe(s))

                Else

                    MiscFN.RadComboBoxSetIndex(Me.RadComboBoxAllTimeEntryMinimumTime, CType(EntryOptions.AllTimeEntryMinimumTime, Integer), False)
                    MiscFN.RadComboBoxSetIndex(Me.RadComboBoxAllTimeEntryRoundToNextIncrement, CType(EntryOptions.AllTimeEntryRoundToNextIncrement, Integer), False)

                    MiscFN.RadComboBoxSetIndex(Me.RadComboBoxStopwatchMinimumTime, CType(EntryOptions.StopwatchMinimumTime, Integer), False)
                    MiscFN.RadComboBoxSetIndex(Me.RadComboBoxStopwatchRoundToNextIncrement, CType(EntryOptions.StopwatchRoundToNextIncrement, Integer), False)

                    MiscFN.RadComboBoxSetIndex(Me.RadComboBoxStartWeekOn, CType(EntryOptions.StartTimesheetOnDayOfWeek, Integer), False)

                    Me.CheckBoxCommentsRequiredWhenSubmittingForApproval.Checked = EntryOptions.CommentsRequiredWhenSubmittingForApproval
                    Me.CheckBoxRequireTimeEntryByAssignment.Checked = EntryOptions.RequireAssignment

                    Me.CheckBoxRequiredHoursMetBeforeAllowSubmitForApproval.Checked = EntryOptions.RequiredHoursMetBeforeAllowSubmitForApproval
                    Me.RadioButtonByDay.Checked = False
                    Me.RadioButtonByWeek.Checked = False

                    Select Case EntryOptions.RequiredHoursMetBeforeAllowSubmitForApprovalType
                        Case AdvantageFramework.Timesheet.Settings.AgencyTimeEntryOptions.AllowSubmitForApprovalType.ByDay

                            Me.RadioButtonByDay.Checked = True

                        Case AdvantageFramework.Timesheet.Settings.AgencyTimeEntryOptions.AllowSubmitForApprovalType.ByWeek

                            Me.RadioButtonByWeek.Checked = True

                    End Select

                    RequiredHoursMetBeforeAllowSubmitForApprovalEnable()

                End If

            End If

        End If

    End Sub

#End Region

    Private Sub LoadStartOfWeek()

        Me.RadComboBoxStartWeekOn.Items.Clear()

        Dim item As Telerik.Web.UI.RadComboBoxItem

        item = New Telerik.Web.UI.RadComboBoxItem
        item.Value = CType(DayOfWeek.Saturday, Integer)
        item.Text = DayOfWeek.Saturday.ToString()
        Me.RadComboBoxStartWeekOn.Items.Add(item)
        item = Nothing

        item = New Telerik.Web.UI.RadComboBoxItem
        item.Value = CType(DayOfWeek.Sunday, Integer)
        item.Text = DayOfWeek.Sunday.ToString()
        Me.RadComboBoxStartWeekOn.Items.Add(item)
        item = Nothing

        item = New Telerik.Web.UI.RadComboBoxItem
        item.Value = CType(DayOfWeek.Monday, Integer)
        item.Text = DayOfWeek.Monday.ToString()
        Me.RadComboBoxStartWeekOn.Items.Add(item)
        item = Nothing

    End Sub

    Private Sub CheckBoxRequiredHoursMetBeforeAllowSubmitForApproval_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxRequiredHoursMetBeforeAllowSubmitForApproval.CheckedChanged

        RequiredHoursMetBeforeAllowSubmitForApprovalEnable()

    End Sub
    Private Sub RequiredHoursMetBeforeAllowSubmitForApprovalEnable()

        Me.RadioButtonByDay.Visible = CheckBoxRequiredHoursMetBeforeAllowSubmitForApproval.Checked
        Me.RadioButtonByWeek.Visible = CheckBoxRequiredHoursMetBeforeAllowSubmitForApproval.Checked

    End Sub

    Private Sub ButtonClearAllUserSettings_Click(sender As Object, e As EventArgs) Handles ButtonClearAllUserSettings.Click

        Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

            AdvantageFramework.EmployeeTimesheet.ClearUserTimesheetSettings(DbContext, "")

        End Using

    End Sub

    Private Sub CheckBoxAgencyOverride_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxAgencyOverride.CheckedChanged

        Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

            Dim SQL As String = String.Empty

            If Me.CheckBoxAgencyOverride.Checked = True Then

                SQL = String.Format("UPDATE AGY_SETTINGS SET AGY_SETTINGS_VALUE = 1 WHERE AGY_SETTINGS_CODE = '{0}';",
                                     AdvantageFramework.Agency.Settings.TS_AGY_OVRRDE.ToString)

            Else

                SQL = String.Format("UPDATE AGY_SETTINGS SET AGY_SETTINGS_VALUE = 0 WHERE AGY_SETTINGS_CODE = '{0}';",
                                     AdvantageFramework.Agency.Settings.TS_AGY_OVRRDE.ToString)

            End If

            DbContext.Database.ExecuteSqlCommand(SQL)

        End Using

    End Sub

#End Region

End Class
