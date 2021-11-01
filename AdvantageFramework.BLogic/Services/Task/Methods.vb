Namespace Services.Task

    <HideModuleName()> _
    Public Module Methods

        Public Event EntryLogWrittenEvent(ByVal EventLogEntry As System.Diagnostics.EventLogEntry)

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum RegistrySetting
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\Task\", "TaskRunAt", "01/01/2001 01:00 AM")> _
            TaskRunAt
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\Task\", "TaskRunDay", "Daily")> _
            TaskRunDay
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\Task\", "TaskNotifyPastDue", "False")> _
            TaskNotifyPastDue
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\Task\", "TaskPastDueMessage", "")> _
            TaskPastDueMessage
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\Task\", "TaskNotifyUpcoming", "False")> _
            TaskNotifyUpcoming
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\Task\", "TaskUpcomingMessage", "")> _
            TaskUpcomingMessage
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\Task\", "TaskUpcomingDays", "0,1")> _
            TaskUpcomingDays
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\Task\", "LastRanAt", "01/01/2001 01:00 AM")>
            LastRanAt
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\Task\", "UseProductName", "False")>
            UseProductName
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\Task\", "RemoveTaskComments", "False")>
            RemoveTaskComments
        End Enum

        Public Enum CustomCommand As Integer
            LoadSettings = 128
        End Enum

        Public Enum RunDayofWeek
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("Daily", "Daily")> _
            Daily
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("Sunday", "Sunday")> _
            Sunday
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("Monday", "Monday")> _
            Monday
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("Tuesday", "Tuesday")> _
            Tuesday
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("Wednesday", "Wednesday")> _
            Wednesday
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("Thursday", "Thursday")> _
            Thursday
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("Friday", "Friday")> _
            Friday
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("Saturday", "Saturday")> _
            Saturday
        End Enum

#End Region

#Region " Variables "

        Private WithEvents _EventLog As System.Diagnostics.EventLog = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub _EventLog_EntryWritten(ByVal sender As Object, ByVal e As System.Diagnostics.EntryWrittenEventArgs) Handles _EventLog.EntryWritten

            RaiseEvent EntryLogWrittenEvent(e.Entry)

        End Sub
        Public Sub ProcessDatabase(ByVal DatabaseProfile As AdvantageFramework.Database.DatabaseProfile)

            'objects
            Dim PastDueRecords As Generic.List(Of Database.Classes.NotifyTaskData) = Nothing
            Dim UpcomingRecords As Generic.List(Of Database.Classes.NotifyTaskData) = Nothing
            Dim RunAt As DateTime = Nothing
            Dim RunDay As String = ""
            Dim NotifyPastDue As Boolean = False
            Dim PastDueMessage As String = ""
            Dim NotifyUpcoming As Boolean = False
            Dim UpcomingMessage As String = ""
            Dim UpcomingDays As String = ""
            Dim SplitString() As String = Nothing
            Dim EmployeeCode As String = ""
            Dim DistinctEmployeeCodeList As List(Of String) = Nothing
            Dim EmployeeRecordList As List(Of AdvantageFramework.Database.Classes.NotifyTaskData) = Nothing
            Dim UseProductName As Boolean = False
            Dim RemoveTaskComments As Boolean = False

            Try

                If DatabaseProfile IsNot Nothing Then

                    WriteToEventLog("Task Notify Started --> " & DatabaseProfile.DatabaseName)

                    Using DataContext = New AdvantageFramework.Database.DataContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                        Using DbContext = New AdvantageFramework.Database.DbContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                                WriteToEventLog("Loading Task Notify Settings from Registry --> " & DatabaseProfile.DatabaseName)

                                AdvantageFramework.Services.Task.LoadSettings(DataContext, RunAt, RunDay, NotifyPastDue, PastDueMessage, NotifyUpcoming, UpcomingMessage, UpcomingDays, UseProductName, RemoveTaskComments)

                                If NotifyPastDue Then

                                    WriteToEventLog("Executing Stored Procedure for Past Due Tasks --> " & DatabaseProfile.DatabaseName)

                                    PastDueRecords = Database.Procedures.NotifyTaskDataComplexType.Load(DbContext, True, 0, 0).ToList

                                    DistinctEmployeeCodeList = (From PastDueRecord In PastDueRecords
                                                                Select PastDueRecord.EMP_CODE
                                                                Distinct).ToList()

                                    WriteToEventLog("Returned " + DistinctEmployeeCodeList.Count.ToString() + " Records --> " & DatabaseProfile.DatabaseName)

                                    For Each EmployeeCode In DistinctEmployeeCodeList

                                        EmployeeRecordList = (From PastDueRecord In PastDueRecords
                                                              Where PastDueRecord.EMP_CODE = EmployeeCode
                                                              Order By PastDueRecord.DATE_DIFF
                                                              Select PastDueRecord).ToList()


                                        If EmployeeRecordList.Count > 0 Then

                                            WriteToEventLog("Sending Past Due Task Alert for " + EmployeeCode + " --> " & DatabaseProfile.DatabaseName)

                                            AdvantageFramework.AlertSystem.CreateAlertForTaskNotification(DbContext, SecurityDbContext, EmployeeCode,
                                                                                                          AdvantageFramework.AlertSystem.TaskNotificationAlertCategory.PastDueTask,
                                                                                                          PastDueMessage, UseProductName, RemoveTaskComments, EmployeeRecordList)

                                        End If

                                    Next

                                End If

                                If NotifyUpcoming Then

                                    SplitString = UpcomingDays.Split(",")

                                    If SplitString.Length = 2 Then

                                        WriteToEventLog("Executing Stored Procedure for Upcoming Tasks --> " & DatabaseProfile.DatabaseName)

                                        UpcomingRecords = Database.Procedures.NotifyTaskDataComplexType.Load(DbContext, False, SplitString(0), SplitString(1)).ToList

                                        DistinctEmployeeCodeList = (From UpcomingRecord In UpcomingRecords
                                                                    Select UpcomingRecord.EMP_CODE
                                                                    Distinct).ToList()

                                        WriteToEventLog("Returned " + DistinctEmployeeCodeList.Count.ToString() + " Records --> " & DatabaseProfile.DatabaseName)

                                        For Each EmployeeCode In DistinctEmployeeCodeList

                                            EmployeeRecordList = (From UpcomingRecord In UpcomingRecords
                                                                  Where UpcomingRecord.EMP_CODE = EmployeeCode
                                                                  Select UpcomingRecord).ToList()

                                            If EmployeeRecordList.Count > 0 Then

                                                WriteToEventLog("Sending Upcoming Task Alert for " + EmployeeCode + " --> " & DatabaseProfile.DatabaseName)

                                                AdvantageFramework.AlertSystem.CreateAlertForTaskNotification(DbContext, SecurityDbContext, EmployeeCode,
                                                                                                              AdvantageFramework.AlertSystem.TaskNotificationAlertCategory.UpcomingTask,
                                                                                                              UpcomingMessage, UseProductName, RemoveTaskComments, EmployeeRecordList)

                                            End If

                                        Next

                                    End If

                                End If

                            End Using

                        End Using

                    End Using

                    WriteToEventLog("Task Notify Finished --> " & DatabaseProfile.DatabaseName)

                End If

            Catch ex As Exception
                WriteToEventLog(ex.Message)
            End Try

        End Sub
        Public Function IsServiceReadyToRun(ByVal DatabaseProfile As AdvantageFramework.Database.DatabaseProfile) As Boolean

            'objects
            Dim ServiceIsReadyToRun As Boolean = False
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing
            Dim LastRanAt As Date = Nothing
            Dim TaskRunAt As DateTime = Nothing
            Dim TaskRunDay As String = Nothing
            Dim RunDayofWeek As RunDayofWeek = AdvantageFramework.Services.Task.RunDayofWeek.Daily
            Dim Process As Boolean = False

            If DatabaseProfile IsNot Nothing Then

                Try

                    Using DataContext = New AdvantageFramework.Database.DataContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                        AdvantageService = LoadAdvantageService(DataContext)

                        If AdvantageService IsNot Nothing Then

                            If AdvantageService.Enabled Then

                                Date.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.Task.RegistrySetting.LastRanAt), LastRanAt)
                                DateTime.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.Task.RegistrySetting.TaskRunAt), TaskRunAt)
                                TaskRunDay = LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.Task.RegistrySetting.TaskRunDay)

                                If TaskRunAt <> Nothing Then

                                    Try

                                        RunDayofWeek = AdvantageFramework.EnumUtilities.GetValue(GetType(RunDayofWeek), TaskRunDay)

                                    Catch ex As Exception
                                        RunDayofWeek = AdvantageFramework.Services.Task.RunDayofWeek.Daily
                                    End Try

                                    If TaskRunAt <> Nothing Then

                                        TaskRunAt = CDate(Now.ToShortDateString & " " & TaskRunAt.ToShortTimeString)

                                    End If

                                    If RunDayofWeek = AdvantageFramework.Services.Task.RunDayofWeek.Daily Then

                                        If DateDiff(DateInterval.Minute, TaskRunAt, Now) >= 0 AndAlso DateDiff(DateInterval.Day, LastRanAt, TaskRunAt) > 0 Then

                                            Process = True

                                        Else

                                            Process = False

                                        End If

                                    Else

                                        If Now.DayOfWeek.ToString.ToUpper = RunDayofWeek.ToString.ToUpper Then

                                            If DateDiff(DateInterval.Minute, TaskRunAt, Now) >= 0 AndAlso DateDiff(DateInterval.Day, LastRanAt, TaskRunAt) > 0 Then

                                                Process = True

                                            Else

                                                Process = False

                                            End If

                                        Else

                                            Process = False

                                        End If

                                    End If

                                    If Process Then

                                        LastRanAt = Now

                                        SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, RegistrySetting.LastRanAt, LastRanAt)

                                        ServiceIsReadyToRun = True

                                    End If

                                End If

                            End If

                        End If

                    End Using

                Catch ex As Exception
                    ServiceIsReadyToRun = False
                End Try

            End If

            IsServiceReadyToRun = ServiceIsReadyToRun

        End Function
        Public Sub Run(ByVal DatabaseProfile As AdvantageFramework.Database.DatabaseProfile)

            If DatabaseProfile IsNot Nothing Then

                Try

                    If IsServiceReadyToRun(DatabaseProfile) Then

                        ProcessDatabase(DatabaseProfile)

                    End If

                Catch ex As Exception
                    WriteToEventLog("Error -->" & ex.Message)
                End Try

                WriteToEventLog("Running")

            End If

        End Sub
        Public Function LoadLogEntries() As String

            'objects
            Dim Log As String = ""

            Log = AdvantageFramework.Services.LoadLogEntries(_EventLog)

            LoadLogEntries = Log

        End Function
        Public Function LoadLog(ByVal LoadEntries As Boolean, Optional ByRef LastEntryMessage As String = "") As String

            'objects
            Dim Log As String = ""
            Dim Entry As System.Diagnostics.EventLogEntry = Nothing

            If System.Diagnostics.EventLog.SourceExists("Task Source") = False Then

                System.Diagnostics.EventLog.CreateEventSource("Task Source", "Task Log")

            End If

            _EventLog = New System.Diagnostics.EventLog("Task Log", My.Computer.Name, "Task Source")

            _EventLog.ModifyOverflowPolicy(System.Diagnostics.OverflowAction.OverwriteAsNeeded, _EventLog.MinimumRetentionDays)

            _EventLog.EnableRaisingEvents = True

            If LoadEntries Then

                Log = AdvantageFramework.Services.LoadLogEntries(_EventLog)

                Try

                    Entry = _EventLog.Entries.OfType(Of System.Diagnostics.EventLogEntry).OrderByDescending(Function(EventLogEntry) EventLogEntry.TimeGenerated).FirstOrDefault

                Catch ex As Exception
                    Entry = Nothing
                End Try

                If Entry IsNot Nothing Then

                    LastEntryMessage = Entry.Message & "...."

                End If

            End If

            LoadLog = Log

        End Function
        Public Function LoadAdvantageService(ByVal DataContext As AdvantageFramework.Database.DataContext) As AdvantageFramework.Database.Entities.AdvantageService

            'objects
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing

            Try

                AdvantageService = AdvantageFramework.Services.LoadAdvantageService(DataContext, AdvantageFramework.Services.Service.AdvantageTaskWindowsService)

            Catch ex As Exception
                AdvantageService = Nothing
            End Try

            LoadAdvantageService = AdvantageService

        End Function
        Public Function LoadAdvantageServiceSetting(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AdvantageServiceID As Integer, ByVal RegistrySetting As AdvantageFramework.Services.Task.RegistrySetting) As AdvantageFramework.Database.Entities.AdvantageServiceSetting

            'objects
            Dim AdvantageServiceSetting As AdvantageFramework.Database.Entities.AdvantageServiceSetting = Nothing

            Try

                AdvantageServiceSetting = AdvantageFramework.Services.LoadAdvantageServiceSetting(DataContext, AdvantageServiceID, RegistrySetting.ToString)

            Catch ex As Exception
                AdvantageServiceSetting = Nothing
            End Try

            LoadAdvantageServiceSetting = AdvantageServiceSetting

        End Function
        Public Function LoadAdvantageServiceSettingValue(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AdvantageServiceID As Integer, ByVal RegistrySetting As AdvantageFramework.Services.Task.RegistrySetting) As Object

            'objects
            Dim SettingValue As Object = Nothing

            Try

                SettingValue = AdvantageFramework.Services.LoadAdvantageServiceSettingValue(DataContext, AdvantageServiceID, RegistrySetting.ToString)

            Catch ex As Exception
                SettingValue = Nothing
            End Try

            LoadAdvantageServiceSettingValue = SettingValue

        End Function
        Public Function SaveAdvantageServiceSettingValue(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AdvantageServiceID As Integer, ByVal RegistrySetting As AdvantageFramework.Services.Task.RegistrySetting, ByVal SettingValue As Object) As Boolean

            'objects
            Dim Saved As Boolean = False

            Try

                Saved = AdvantageFramework.Services.SaveAdvantageServiceSettingValue(DataContext, AdvantageServiceID, RegistrySetting.ToString, SettingValue)

            Catch ex As Exception
                Saved = False
            End Try

            SaveAdvantageServiceSettingValue = Saved

        End Function
        Public Sub LoadSettings(ByVal DataContext As AdvantageFramework.Database.DataContext, ByRef TaskRunAt As DateTime, ByRef TaskRunDay As String, ByRef TaskNotifyPastDue As Boolean, ByRef TaskPastDueMessage As String,
                                ByRef TaskNotifyUpcoming As Boolean, ByRef TaskUpcomingMessage As String, ByRef TaskUpcomingDays As String, ByRef UseProductName As Boolean, ByRef RemoveTaskComments As Boolean,
                                Optional ByRef LastRanAt As Date = Nothing)

            'objects
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing
            Dim TrueFalseString As String = ""
            Dim TaskRunDayString As String = ""

            AdvantageService = LoadAdvantageService(DataContext)

            If AdvantageService IsNot Nothing Then

                DateTime.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.Task.RegistrySetting.TaskRunAt), TaskRunAt)

                TaskRunDay = LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.Task.RegistrySetting.TaskRunDay)

                TrueFalseString = LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.Task.RegistrySetting.TaskNotifyPastDue)

                If TrueFalseString = "True" Then

                    TaskNotifyPastDue = True

                Else

                    TaskNotifyPastDue = False

                End If

                TaskPastDueMessage = LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.Task.RegistrySetting.TaskPastDueMessage)

                TrueFalseString = LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.Task.RegistrySetting.TaskNotifyUpcoming)

                If TrueFalseString = "True" Then

                    TaskNotifyUpcoming = True

                Else

                    TaskNotifyUpcoming = False

                End If

                TaskUpcomingMessage = LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.Task.RegistrySetting.TaskUpcomingMessage)

                TaskUpcomingDays = LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.Task.RegistrySetting.TaskUpcomingDays)

                TrueFalseString = LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.Task.RegistrySetting.UseProductName)

                If TrueFalseString = "True" Then

                    UseProductName = True

                Else

                    UseProductName = False

                End If

                TrueFalseString = LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.Task.RegistrySetting.RemoveTaskComments)

                If TrueFalseString = "True" Then

                    RemoveTaskComments = True

                Else

                    RemoveTaskComments = False

                End If

                Date.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.Task.RegistrySetting.LastRanAt), LastRanAt)

            End If

        End Sub
        Public Sub SaveSettings(ByVal DataContext As AdvantageFramework.Database.DataContext, ByRef TaskRunAt As DateTime, ByRef TaskRunDay As String, ByRef TaskNotifyPastDue As Boolean, ByRef TaskPastDueMessage As String,
                                ByRef TaskNotifyUpcoming As Boolean, ByRef TaskUpcomingMessage As String, ByRef TaskUpcomingDays As String, ByRef UseProductName As Boolean, ByRef RemoveTaskComments As Boolean)

            'objects
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing
            'Dim PreviousTaskRunAt As DateTime
            'Dim PreviousTaskRunDay As String = ""
            'Dim PreviousTaskNotifyPastDue As String = ""
            'Dim PreviousTaskPastDueMessage As String = ""
            'Dim PreviousTaskNotifyUpcoming As String = ""
            'Dim PreviousTaskUpcomingMessage As String = ""
            'Dim PreviousTaskUpcomingDays As String = ""
            'Dim ServiceController As System.ServiceProcess.ServiceController = Nothing
            'Dim ServiceReloadSettings As Boolean = False

            AdvantageService = LoadAdvantageService(DataContext)

            If AdvantageService IsNot Nothing Then

                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.Task.RegistrySetting.TaskRunAt, TaskRunAt)
                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.Task.RegistrySetting.TaskRunDay, TaskRunDay)
                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.Task.RegistrySetting.TaskNotifyPastDue, TaskNotifyPastDue.ToString())
                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.Task.RegistrySetting.TaskPastDueMessage, TaskPastDueMessage)
                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.Task.RegistrySetting.TaskNotifyUpcoming, TaskNotifyUpcoming.ToString())
                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.Task.RegistrySetting.TaskUpcomingMessage, TaskUpcomingMessage)
                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.Task.RegistrySetting.TaskUpcomingDays, TaskUpcomingDays)
                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.Task.RegistrySetting.UseProductName, UseProductName.ToString())
                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.Task.RegistrySetting.RemoveTaskComments, RemoveTaskComments.ToString())

            End If

            'DateTime.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.Task.RegistrySetting.TaskRunAt), PreviousTaskRunAt)

            'If PreviousTaskRunAt <> TaskRunAt Then

            '    SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.Task.RegistrySetting.TaskRunAt, TaskRunAt)
            '    ServiceReloadSettings = True

            'End If

            'PreviousTaskRunDay = LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.Task.RegistrySetting.TaskRunDay)

            'If PreviousTaskRunDay <> TaskRunDay Then

            '    SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.Task.RegistrySetting.TaskRunDay, TaskRunDay)
            '    ServiceReloadSettings = True

            'End If

            'PreviousTaskNotifyPastDue = LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.Task.RegistrySetting.TaskNotifyPastDue)

            'If PreviousTaskNotifyPastDue <> TaskNotifyPastDue.ToString() Then

            '    SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.Task.RegistrySetting.TaskNotifyPastDue, TaskNotifyPastDue.ToString())
            '    ServiceReloadSettings = True

            'End If

            'PreviousTaskPastDueMessage = LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.Task.RegistrySetting.TaskPastDueMessage)

            'If PreviousTaskPastDueMessage <> TaskPastDueMessage Then

            '    SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.Task.RegistrySetting.TaskPastDueMessage, TaskPastDueMessage)
            '    ServiceReloadSettings = True

            'End If

            'PreviousTaskNotifyUpcoming = LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.Task.RegistrySetting.TaskNotifyUpcoming)

            'If PreviousTaskNotifyUpcoming <> TaskNotifyUpcoming.ToString() Then

            '    SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.Task.RegistrySetting.TaskNotifyUpcoming, TaskNotifyUpcoming.ToString())
            '    ServiceReloadSettings = True

            'End If

            'PreviousTaskUpcomingMessage = LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.Task.RegistrySetting.TaskUpcomingMessage)

            'If PreviousTaskUpcomingMessage <> TaskUpcomingMessage Then

            '    SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.Task.RegistrySetting.TaskUpcomingMessage, TaskUpcomingMessage)
            '    ServiceReloadSettings = True

            'End If

            'PreviousTaskUpcomingDays = LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.Task.RegistrySetting.TaskUpcomingDays)

            'If PreviousTaskUpcomingDays <> TaskUpcomingDays Then

            '    SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.Task.RegistrySetting.TaskUpcomingDays, TaskUpcomingDays)
            '    ServiceReloadSettings = True

            'End If

            'If ServiceReloadSettings Then

            '    ServiceController = AdvantageFramework.Services.Load(AdvantageFramework.Services.Service.AdvantageTaskWindowsService)

            '    If ServiceController IsNot Nothing AndAlso ServiceController.Status = ServiceProcess.ServiceControllerStatus.Running Then

            '        ServiceController.ExecuteCommand(AdvantageFramework.Services.Export.CustomCommand.LoadSettings)

            '    End If

            'End If

        End Sub
        Public Sub WriteToEventLog(Message As String)

            Try

                SyncLock _EventLog

                    _EventLog.WriteEntry(Message)

                End SyncLock

            Catch ex As Exception

            End Try

        End Sub
        Public Sub ClearLog()

            Try

                SyncLock _EventLog

                    _EventLog.Clear()

                End SyncLock

            Catch ex As Exception

            End Try

        End Sub

#End Region

    End Module

End Namespace

