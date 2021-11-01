Namespace ProjectManagement.Agile.Classes

    <Serializable()>
    Public Class WeeklyHours

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties

            Title
            WorkItemHours
            SprintHeaderID
            AlertID
            PreviousWeeks
            FutureWeeks
            EmployeeCode
            Alert
            ShowPastWeeksSetting
            ShowFutureWeeksSetting
            GroupEmployeesSetting
            GroupWeeksSetting
            CreatePriorWeeksSetting

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property Title As String = String.Empty
        Public Property WorkItemHours As System.Collections.Generic.List(Of AdvantageFramework.ViewModels.ProjectManagement.Agile.WorkItemHoursViewModel) = Nothing
        Public Property HasWeeklyHours As Boolean = False

        Public Property SprintHeaderID As Integer = 0
        Public Property AlertID As Integer = 0
        Public Property EmployeeCode As String = String.Empty
        Public Property Alert As AdvantageFramework.Database.Entities.Alert = Nothing
        Public Property AlertHours As AdvantageFramework.Controller.Desktop.AlertController.AlertHours = Nothing

        Public Property HasStartDate As Boolean = False
        Public Property HasDueDate As Boolean = False

        Public Property ShowPastWeeksSetting As Boolean = False
        Public Property ShowFutureWeeksSetting As Boolean = False
        Public Property GroupEmployeesSetting As Boolean = False
        Public Property GroupWeeksSetting As Boolean = False
        Public Property CreatePriorWeeksSetting As Boolean = False
        Public Property ShowAvailability As Boolean = False

        Public Property Result As ResultObject = Nothing

        Private Property _SecuritySession As AdvantageFramework.Security.Session
        Private Property _AppVarApplication As String = "WEEKLY_HOURS_GRID"

#End Region

#Region " Methods "

        Public Sub SaveAllSettings()

            Using DbContext = New AdvantageFramework.Database.DbContext(Me._SecuritySession.ConnectionString, Me._SecuritySession.UserCode)

                Dim Setting As AdvantageFramework.Database.Entities.AppVars = Nothing

                'ShowPastWeeksSetting
                Setting = Nothing
                Setting = AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationNameAndVariableName(DbContext,
                                                                                                              Me._SecuritySession.UserCode,
                                                                                                              _AppVarApplication,
                                                                                                              Properties.ShowPastWeeksSetting.ToString)
                If Setting IsNot Nothing Then

                    Setting.Value = ShowPastWeeksSetting.ToString
                    AdvantageFramework.Database.Procedures.AppVars.Update(DbContext, Setting)

                Else

                    Setting = New Database.Entities.AppVars
                    Setting.UserCode = Me._SecuritySession.UserCode
                    Setting.Type = "Boolean"
                    Setting.Application = _AppVarApplication
                    Setting.Name = Properties.ShowPastWeeksSetting.ToString
                    Setting.Value = Me.ShowPastWeeksSetting.ToString

                    AdvantageFramework.Database.Procedures.AppVars.Insert(DbContext, Setting)

                End If
                'ShowFutureWeeksSetting
                Setting = Nothing
                Setting = AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationNameAndVariableName(DbContext,
                                                                                                              Me._SecuritySession.UserCode,
                                                                                                              _AppVarApplication,
                                                                                                              Properties.ShowFutureWeeksSetting.ToString)
                If Setting IsNot Nothing Then

                    Setting.Value = ShowFutureWeeksSetting.ToString
                    AdvantageFramework.Database.Procedures.AppVars.Update(DbContext, Setting)

                Else

                    Setting = New Database.Entities.AppVars
                    Setting.UserCode = Me._SecuritySession.UserCode
                    Setting.Type = "Boolean"
                    Setting.Application = _AppVarApplication
                    Setting.Name = Properties.ShowFutureWeeksSetting.ToString
                    Setting.Value = Me.ShowFutureWeeksSetting.ToString

                    AdvantageFramework.Database.Procedures.AppVars.Insert(DbContext, Setting)

                End If
                'GroupEmployeesSetting
                Setting = Nothing
                Setting = AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationNameAndVariableName(DbContext,
                                                                                                              Me._SecuritySession.UserCode,
                                                                                                              _AppVarApplication,
                                                                                                              Properties.GroupEmployeesSetting.ToString)
                If Setting IsNot Nothing Then

                    Setting.Value = GroupEmployeesSetting.ToString
                    AdvantageFramework.Database.Procedures.AppVars.Update(DbContext, Setting)

                Else

                    Setting = New Database.Entities.AppVars
                    Setting.UserCode = Me._SecuritySession.UserCode
                    Setting.Type = "Boolean"
                    Setting.Application = _AppVarApplication
                    Setting.Name = Properties.GroupEmployeesSetting.ToString
                    Setting.Value = Me.GroupEmployeesSetting.ToString

                    AdvantageFramework.Database.Procedures.AppVars.Insert(DbContext, Setting)

                End If
                'GroupWeeksSetting
                Setting = Nothing
                Setting = AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationNameAndVariableName(DbContext,
                                                                                                              Me._SecuritySession.UserCode,
                                                                                                              _AppVarApplication,
                                                                                                              Properties.GroupWeeksSetting.ToString)
                If Setting IsNot Nothing Then

                    Setting.Value = GroupWeeksSetting.ToString
                    AdvantageFramework.Database.Procedures.AppVars.Update(DbContext, Setting)

                Else

                    Setting = New Database.Entities.AppVars
                    Setting.UserCode = Me._SecuritySession.UserCode
                    Setting.Type = "Boolean"
                    Setting.Application = _AppVarApplication
                    Setting.Name = Properties.GroupWeeksSetting.ToString
                    Setting.Value = Me.GroupWeeksSetting.ToString

                    AdvantageFramework.Database.Procedures.AppVars.Insert(DbContext, Setting)

                End If
                'CreatePriorWeeksSetting
                Setting = Nothing
                Setting = AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationNameAndVariableName(DbContext,
                                                                                                              Me._SecuritySession.UserCode,
                                                                                                              _AppVarApplication,
                                                                                                              Properties.CreatePriorWeeksSetting.ToString)
                If Setting IsNot Nothing Then

                    Setting.Value = CreatePriorWeeksSetting.ToString
                    AdvantageFramework.Database.Procedures.AppVars.Update(DbContext, Setting)

                Else

                    Setting = New Database.Entities.AppVars
                    Setting.UserCode = Me._SecuritySession.UserCode
                    Setting.Type = "Boolean"
                    Setting.Application = _AppVarApplication
                    Setting.Name = Properties.CreatePriorWeeksSetting.ToString
                    Setting.Value = Me.CreatePriorWeeksSetting.ToString

                    AdvantageFramework.Database.Procedures.AppVars.Insert(DbContext, Setting)

                End If

            End Using

        End Sub

        Public Sub SaveShowPastWeeksSetting(ByVal Checked As Boolean)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me._SecuritySession.ConnectionString, Me._SecuritySession.UserCode)

                Dim Setting As AdvantageFramework.Database.Entities.AppVars = Nothing

                'ShowPastWeeksSetting
                Setting = Nothing
                Setting = AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationNameAndVariableName(DbContext,
                                                                                                              Me._SecuritySession.UserCode,
                                                                                                              _AppVarApplication,
                                                                                                              Properties.ShowPastWeeksSetting.ToString)
                If Setting IsNot Nothing Then

                    Setting.Value = Checked.ToString
                    AdvantageFramework.Database.Procedures.AppVars.Update(DbContext, Setting)

                Else

                    Setting = New Database.Entities.AppVars
                    Setting.UserCode = Me._SecuritySession.UserCode
                    Setting.Type = "Boolean"
                    Setting.Application = _AppVarApplication
                    Setting.Name = Properties.ShowPastWeeksSetting.ToString
                    Setting.Value = Checked.ToString

                    AdvantageFramework.Database.Procedures.AppVars.Insert(DbContext, Setting)

                End If

            End Using

        End Sub
        Public Sub SaveShowFutureWeeksSetting(ByVal Checked As Boolean)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me._SecuritySession.ConnectionString, Me._SecuritySession.UserCode)

                Dim Setting As AdvantageFramework.Database.Entities.AppVars = Nothing

                'ShowFutureWeeksSetting
                Setting = Nothing
                Setting = AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationNameAndVariableName(DbContext,
                                                                                                              Me._SecuritySession.UserCode,
                                                                                                              _AppVarApplication,
                                                                                                              Properties.ShowFutureWeeksSetting.ToString)
                If Setting IsNot Nothing Then

                    Setting.Value = Checked.ToString
                    AdvantageFramework.Database.Procedures.AppVars.Update(DbContext, Setting)

                Else

                    Setting = New Database.Entities.AppVars
                    Setting.UserCode = Me._SecuritySession.UserCode
                    Setting.Type = "Boolean"
                    Setting.Application = _AppVarApplication
                    Setting.Name = Properties.ShowFutureWeeksSetting.ToString
                    Setting.Value = Checked.ToString

                    AdvantageFramework.Database.Procedures.AppVars.Insert(DbContext, Setting)

                End If

            End Using

        End Sub
        Public Sub SaveGroupEmployeesSetting(ByVal Checked As Boolean)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me._SecuritySession.ConnectionString, Me._SecuritySession.UserCode)

                Dim Setting As AdvantageFramework.Database.Entities.AppVars = Nothing

                'GroupEmployeesSetting
                Setting = Nothing
                Setting = AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationNameAndVariableName(DbContext,
                                                                                                              Me._SecuritySession.UserCode,
                                                                                                              _AppVarApplication,
                                                                                                              Properties.GroupEmployeesSetting.ToString)
                If Setting IsNot Nothing Then

                    Setting.Value = Checked.ToString
                    AdvantageFramework.Database.Procedures.AppVars.Update(DbContext, Setting)

                Else

                    Setting = New Database.Entities.AppVars
                    Setting.UserCode = Me._SecuritySession.UserCode
                    Setting.Type = "Boolean"
                    Setting.Application = _AppVarApplication
                    Setting.Name = Properties.GroupEmployeesSetting.ToString
                    Setting.Value = Checked.ToString

                    AdvantageFramework.Database.Procedures.AppVars.Insert(DbContext, Setting)

                End If

            End Using

        End Sub
        Public Sub SaveGroupWeeksSetting(ByVal Checked As Boolean)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me._SecuritySession.ConnectionString, Me._SecuritySession.UserCode)

                Dim Setting As AdvantageFramework.Database.Entities.AppVars = Nothing

                'GroupWeeksSetting
                Setting = Nothing
                Setting = AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationNameAndVariableName(DbContext,
                                                                                                              Me._SecuritySession.UserCode,
                                                                                                              _AppVarApplication,
                                                                                                              Properties.GroupWeeksSetting.ToString)
                If Setting IsNot Nothing Then

                    Setting.Value = Checked
                    AdvantageFramework.Database.Procedures.AppVars.Update(DbContext, Setting)

                Else

                    Setting = New Database.Entities.AppVars
                    Setting.UserCode = Me._SecuritySession.UserCode
                    Setting.Type = "Boolean"
                    Setting.Application = _AppVarApplication
                    Setting.Name = Properties.GroupWeeksSetting.ToString
                    Setting.Value = Checked.ToString

                    AdvantageFramework.Database.Procedures.AppVars.Insert(DbContext, Setting)

                End If

            End Using

        End Sub
        Public Sub SaveCreatePriorWeeksSetting(ByVal Checked As Boolean)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me._SecuritySession.ConnectionString, Me._SecuritySession.UserCode)

                Dim Setting As AdvantageFramework.Database.Entities.AppVars = Nothing

                'CreatePriorWeeksSetting
                Setting = Nothing
                Setting = AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationNameAndVariableName(DbContext,
                                                                                                              Me._SecuritySession.UserCode,
                                                                                                              _AppVarApplication,
                                                                                                              Properties.CreatePriorWeeksSetting.ToString)
                If Setting IsNot Nothing Then

                    Setting.Value = Checked
                    AdvantageFramework.Database.Procedures.AppVars.Update(DbContext, Setting)

                Else

                    Setting = New Database.Entities.AppVars
                    Setting.UserCode = Me._SecuritySession.UserCode
                    Setting.Type = "Boolean"
                    Setting.Application = _AppVarApplication
                    Setting.Name = Properties.CreatePriorWeeksSetting.ToString
                    Setting.Value = Checked.ToString

                    AdvantageFramework.Database.Procedures.AppVars.Insert(DbContext, Setting)

                End If

            End Using

        End Sub

        Public Sub LoadSettings()

            Using DbContext = New AdvantageFramework.Database.DbContext(Me._SecuritySession.ConnectionString, Me._SecuritySession.UserCode)

                Dim Settings As Generic.List(Of AdvantageFramework.Database.Entities.AppVars) = Nothing

                Settings = AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationName(DbContext, Me._SecuritySession.UserCode, _AppVarApplication).ToList

                If Settings IsNot Nothing AndAlso Settings.Any = True Then

                    For Each Setting As AdvantageFramework.Database.Entities.AppVars In Settings

                        Select Case Setting.Name
                            Case Properties.ShowPastWeeksSetting.ToString

                                Me.ShowPastWeeksSetting = Setting.Value.ToLower = "true"

                            Case Properties.ShowFutureWeeksSetting.ToString

                                Me.ShowFutureWeeksSetting = Setting.Value.ToLower = "true"

                            Case Properties.GroupEmployeesSetting.ToString

                                Me.GroupEmployeesSetting = Setting.Value.ToLower = "true"

                            Case Properties.GroupWeeksSetting.ToString

                                Me.GroupWeeksSetting = Setting.Value.ToLower = "true"

                            Case Properties.CreatePriorWeeksSetting.ToString

                                Me.CreatePriorWeeksSetting = Setting.Value.ToLower = "true"

                        End Select

                    Next

                End If

            End Using

        End Sub
        Public Sub Load()

            If AlertID > 0 Then

                'Dim IsMultiEmployeeRouted As Boolean = False ' this is declared and set but never used.
                Dim IsTask As Boolean = False
                Dim Task As AdvantageFramework.Database.Entities.JobComponentTask = Nothing

                Using DbContext = New AdvantageFramework.Database.DbContext(_SecuritySession.ConnectionString, _SecuritySession.UserCode)

                    Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertID)

                    If Alert IsNot Nothing Then

                        Title = Alert.Subject

                        IsTask = Alert.AlertCategoryID = 71 OrElse Alert.AlertLevel = "BRD"

                        If IsTask = True Then

                            Task = AdvantageFramework.Database.Procedures.JobComponentTask.LoadByJobNumberAndJobComponentNumberAndSequenceNumber(DbContext,
                                                                                                Alert.JobNumber, Alert.JobComponentNumber, Alert.TaskSequenceNumber)

                            If Task IsNot Nothing Then

                                IsTask = True

                            Else

                                IsTask = False

                            End If

                        End If

                        If IsTask = True Then

                            Dim _AlertHours As AdvantageFramework.Controller.Desktop.AlertController.AlertHours = DbContext.Database.SqlQuery(Of AdvantageFramework.Controller.Desktop.AlertController.AlertHours) _
                                                                            (String.Format("EXEC [dbo].[advsp_alert_get_hours] {0};", Alert.ID)).SingleOrDefault

                            Alert.StartDate = _AlertHours.StartDate
                            Alert.DueDate = _AlertHours.DueDate

                            HasStartDate = Alert.StartDate IsNot Nothing
                            HasDueDate = Alert.DueDate IsNot Nothing

                        Else

                            HasStartDate = Alert.StartDate IsNot Nothing
                            HasDueDate = Alert.DueDate IsNot Nothing

                        End If

                        LoadSettings()

                        Me.HasWeeklyHours = AlertHasWeeklyHours(DbContext, AlertID)

                        'this section does nothing
                        'Try
                        '    If (Alert.AlertAssignmentTemplateID Is Nothing And Alert.AlertCategoryID = 71) Then
                        '        'this is a task so we need to look at the JOB_TRAFFIC_DET_EMPS

                        '    Else
                        '        IsMultiEmployeeRouted = DbContext.Database.SqlQuery(Of Boolean)(String.Format("SELECT CASE WHEN [TYPE] = 1 THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) END FROM ALERT_NOTIFY_HDR WHERE ALRT_NOTIFY_HDR_ID = {0};", Alert.AlertAssignmentTemplateID)).SingleOrDefault
                        '    End If

                        'Catch ex As Exception
                        '    IsMultiEmployeeRouted = False
                        'End Try

                        Try

                            Try

                                AlertHours = DbContext.Database.SqlQuery(Of Controller.Desktop.AlertController.AlertHours)(String.Format("EXEC [dbo].[advsp_alert_get_hours] {0};", AlertID)).SingleOrDefault

                            Catch ex As Exception
                                AlertHours = Nothing
                            End Try
                            If AlertHours IsNot Nothing Then

                                Me.Alert.HoursAllowed = AlertHours.HoursAllowed

                            End If

                        Catch ex As Exception
                        End Try

                    End If

                    If Me.HasWeeklyHours = False Then

                        WorkItemHours = AdvantageFramework.ProjectManagement.Agile.LoadWorkItemEmployeeHours(DbContext, AlertID, ShowAvailability)

                    Else

                        WorkItemHours = AdvantageFramework.ProjectManagement.Agile.LoadWorkItemHoursBySprintHeaderIDandAlertID(DbContext, SprintHeaderID, AlertID, ShowPastWeeksSetting, ShowFutureWeeksSetting, ShowAvailability)

                    End If

                End Using
                If WorkItemHours IsNot Nothing Then

                    If HasWeeklyHours = True Then

                        If ShowPastWeeksSetting = False OrElse ShowFutureWeeksSetting = False Then

                            Dim CurrentWeekStart As Date = AdvantageFramework.DateUtilities.FirstDayOfWeek(Today.Date)
                            Dim CurrentWeekEnd As Date = DateAdd(DateInterval.Day, 6, CurrentWeekStart)

                            If ShowPastWeeksSetting = False Then

                                WorkItemHours = WorkItemHours.Where(Function(wih) wih.WeekStart >= CurrentWeekStart).ToList

                            End If
                            If ShowFutureWeeksSetting = False Then

                                WorkItemHours = WorkItemHours.Where(Function(wih) wih.WeekStart <= CurrentWeekEnd).ToList

                            End If

                        End If

                    End If

                Else

                    WorkItemHours = New List(Of ViewModels.ProjectManagement.Agile.WorkItemHoursViewModel)

                End If

            End If

        End Sub
        Public Sub CheckAndUpdateAlertEmployeesAndHours(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                        ByVal CreatePriorWeeks As Boolean)

            Try

                Result = DbContext.Database.SqlQuery(Of ResultObject)(String.Format("EXEC [dbo].[advsp_agile_sprint_check_employee_records] {0}, NULL, {1};",
                                                                                    AlertID, If(CreatePriorWeeks = True, 1, 0))).SingleOrDefault

            Catch ex As Exception
                If Result Is Nothing Then Result = New ResultObject
                Result.Success = False
                Result.Message = ex.Message.ToString
            End Try

        End Sub

        Private Function AlertHasWeeklyHours(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                             ByVal AlertID As Integer) As Boolean

            Return AdvantageFramework.AlertSystem.AlertHasWeeklyHours(DbContext, AlertID)

        End Function
        Sub New(ByVal SecuritySession As AdvantageFramework.Security.Session)

            Me._SecuritySession = SecuritySession
            Result = New ResultObject

        End Sub
        Sub New()

            WorkItemHours = New List(Of ViewModels.ProjectManagement.Agile.WorkItemHoursViewModel)
            Result = New ResultObject

        End Sub

#End Region

        <Serializable()>
        Public Class ResultObject
            Public Property Success As Boolean = False
            Public Property Message As String = String.Empty
            Sub New()

            End Sub
        End Class

    End Class

End Namespace

