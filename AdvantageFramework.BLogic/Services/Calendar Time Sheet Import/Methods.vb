Namespace Services.CalendarTimeSheetImport

    <HideModuleName()>
    Public Module Methods

        Public Event EntryLogWrittenEvent(ByVal EventLogEntry As System.Diagnostics.EventLogEntry)

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum RegistrySetting
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\Calendar Time Sheet Import\", "RunAtEvery", "1")>
            RunAtEvery
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\Calendar Time Sheet Import\", "LastRanAt", "01/01/2001 01:00 AM")>
            LastRanAt
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\Calendar Time Sheet Import\", "PastDays", "1")>
            PastDays
        End Enum

        Public Enum CustomCommand As Integer
            LoadSettings = 128
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
        Public Sub ProcessGoogleCalendarTS(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext,
                                            ByVal Agency As AdvantageFramework.Database.Entities.Agency, ByVal LastRanAt As Date, ByVal Employee As AdvantageFramework.Database.Views.Employee,
                                           ByVal UseWindowsAuthentication As Boolean, ByVal PastDays As Integer, ByVal StartDate As DateTime, ByVal EndDate As DateTime, ByVal RTOnly As Boolean, ByRef ErrorMessage As String)

            AdvantageFramework.GoogleServices.Service.ProcessGoogleCalendarTS(DbContext, Agency.StandardHours.GetValueOrDefault(0), Employee.Code, False, UseWindowsAuthentication, PastDays, StartDate, EndDate, RTOnly, ErrorMessage)

        End Sub

        Public Sub ProcessDatabase(ByVal DatabaseProfile As AdvantageFramework.Database.DatabaseProfile)

            'objects
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim RunAtEvery As Integer = 0
            Dim PastDays As Integer = 1
            Dim LastRanAt As Date = Nothing
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing
            Dim SyncWithOutlook As Boolean = False
            Dim UseOutlookExchangeServer As Boolean = False
            Dim SyncWithGoogleCalendar As Boolean = False
            Dim SyncWithSugarCRM As Boolean = False
            Dim ErrorMessage As String = ""

            If DatabaseProfile IsNot Nothing Then

                WriteToEventLog("Processing database --> " & DatabaseProfile.DatabaseName)

                Using DataContext = New AdvantageFramework.Database.DataContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                    Using DbContext = New AdvantageFramework.Database.DbContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                        LoadSettings(DataContext, RunAtEvery, PastDays, LastRanAt)

                        Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                        AdvantageService = LoadAdvantageService(DataContext)

                        For Each Employee In AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActive(DbContext).ToList

                            WriteToEventLog("Processing employee --> " & Employee.ToString)

                            If Employee.CalendarTimeType = 1 Then

                                If String.IsNullOrWhiteSpace(Employee.CalendarTimeEmailAddress) = False AndAlso String.IsNullOrWhiteSpace(Employee.GoogleToken) = False Then

                                    WriteToEventLog("Processing Google Calendar --> " & Employee.ToString)

                                    ProcessGoogleCalendarTS(DbContext, DataContext, Agency, LastRanAt, Employee, DatabaseProfile.UseWindowsAuthentication, PastDays, Nothing, Nothing, False, ErrorMessage)

                                End If

                            End If

                            'If SyncWithSugarCRM Then

                            '    If String.IsNullOrWhiteSpace(Employee.SugarCRMUserName) = False AndAlso String.IsNullOrWhiteSpace(Employee.SugarCRMPassword) = False Then

                            '        WriteToEventLog("Processing Sugar Calendar --> " & Employee.ToString)

                            '        ProcessSugarCalendar(DbContext, DataContext, Agency, LastRanAt, Employee)

                            '    End If

                            'End If

                            'If SyncWithOutlook AndAlso UseOutlookExchangeServer Then

                            '    If String.IsNullOrWhiteSpace(Employee.Email) = False AndAlso String.IsNullOrWhiteSpace(Employee.EmailPassword) = False AndAlso Employee.IgnoreCalendarSync = False Then

                            '        WriteToEventLog("Processing Outlook Calendar --> " & Employee.ToString)

                            '        ProcessOutlookCalendar(DbContext, DataContext, Agency, LastRanAt, Employee)

                            '    End If

                            'End If

                        Next

                    End Using

                End Using

            End If

        End Sub
        Public Function IsServiceReadyToRun(ByVal DatabaseProfile As AdvantageFramework.Database.DatabaseProfile) As Boolean

            'objects
            Dim ServiceIsReadyToRun As Boolean = False
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing
            Dim RunAtEvery As Integer = 0
            Dim LastRanAt As Date = Nothing

            If DatabaseProfile IsNot Nothing Then

                Try

                    Using DataContext = New AdvantageFramework.Database.DataContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                        AdvantageService = LoadAdvantageService(DataContext)

                        WriteToEventLog("Advantage Service Grab --> ")

                        If AdvantageService IsNot Nothing Then

                            WriteToEventLog("Advantage Service enabled --> " & AdvantageService.Enabled)

                            If AdvantageService.Enabled Then

                                Integer.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.CalendarTimeSheetImport.RegistrySetting.RunAtEvery), RunAtEvery)
                                DateTime.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.CalendarTimeSheetImport.RegistrySetting.LastRanAt), LastRanAt)

                                LastRanAt = LastRanAt.AddMinutes(RunAtEvery)

                                If DateDiff(DateInterval.Minute, LastRanAt, Now) >= 0 Then

                                    LastRanAt = Now

                                    SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.CalendarTimeSheetImport.RegistrySetting.LastRanAt, LastRanAt)

                                    ServiceIsReadyToRun = True

                                End If

                            End If

                        End If

                    End Using

                Catch ex As Exception
                    ServiceIsReadyToRun = False
                    WriteToEventLog("Advantage Service failed --> " & AdvantageService.Enabled)
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

            If System.Diagnostics.EventLog.SourceExists("Adv CalTime Import Source") = False Then

                System.Diagnostics.EventLog.CreateEventSource("Adv CalTime Import Source", "Adv CalTime Import Log")

            End If

            _EventLog = New System.Diagnostics.EventLog("Adv CalTime Import Log", My.Computer.Name, "Adv CalTime Import Source")

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

                AdvantageService = AdvantageFramework.Services.LoadAdvantageService(DataContext, AdvantageFramework.Services.Service.AdvantageCalendarTimeSheetImportService)

            Catch ex As Exception
                AdvantageService = Nothing
            End Try

            LoadAdvantageService = AdvantageService

        End Function
        Public Function LoadAdvantageServiceSetting(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AdvantageServiceID As Integer, ByVal RegistrySetting As AdvantageFramework.Services.CalendarTimeSheetImport.RegistrySetting) As AdvantageFramework.Database.Entities.AdvantageServiceSetting

            'objects
            Dim AdvantageServiceSetting As AdvantageFramework.Database.Entities.AdvantageServiceSetting = Nothing

            Try

                AdvantageServiceSetting = AdvantageFramework.Services.LoadAdvantageServiceSetting(DataContext, AdvantageServiceID, RegistrySetting.ToString)

            Catch ex As Exception
                AdvantageServiceSetting = Nothing
            End Try

            LoadAdvantageServiceSetting = AdvantageServiceSetting

        End Function
        Public Function LoadAdvantageServiceSettingValue(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AdvantageServiceID As Integer, ByVal RegistrySetting As AdvantageFramework.Services.CalendarTimeSheetImport.RegistrySetting) As Object

            'objects
            Dim SettingValue As Object = Nothing

            Try

                SettingValue = AdvantageFramework.Services.LoadAdvantageServiceSettingValue(DataContext, AdvantageServiceID, RegistrySetting.ToString)

            Catch ex As Exception
                SettingValue = Nothing
            End Try

            LoadAdvantageServiceSettingValue = SettingValue

        End Function
        Public Function SaveAdvantageServiceSettingValue(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AdvantageServiceID As Integer, ByVal RegistrySetting As AdvantageFramework.Services.CalendarTimeSheetImport.RegistrySetting, ByVal SettingValue As Object) As Boolean

            'objects
            Dim Saved As Boolean = False

            Try

                Saved = AdvantageFramework.Services.SaveAdvantageServiceSettingValue(DataContext, AdvantageServiceID, RegistrySetting.ToString, SettingValue)

            Catch ex As Exception
                Saved = False
            End Try

            SaveAdvantageServiceSettingValue = Saved

        End Function
        Public Sub LoadSettings(ByVal DataContext As AdvantageFramework.Database.DataContext, ByRef RunAtEvery As Integer, ByRef PastDays As Integer, Optional ByRef LastRanAt As Date = Nothing)

            'objects
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing

            AdvantageService = LoadAdvantageService(DataContext)

            If AdvantageService IsNot Nothing Then

                Integer.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.CalendarTimeSheetImport.RegistrySetting.RunAtEvery), RunAtEvery)

                Integer.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.CalendarTimeSheetImport.RegistrySetting.PastDays) * -1, PastDays)

                DateTime.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.CalendarTimeSheetImport.RegistrySetting.LastRanAt), LastRanAt)

            End If

        End Sub
        Public Sub SaveSettings(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal RunAtEvery As Integer, ByVal PastDays As Integer, Optional ByVal LastRanAt As Date = Nothing)

            'objects
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing
            'Dim PreviousRunAtEvery As Integer = 0
            'Dim ServiceController As System.ServiceProcess.ServiceController = Nothing

            AdvantageService = LoadAdvantageService(DataContext)

            If AdvantageService IsNot Nothing Then

                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.CalendarTimeSheetImport.RegistrySetting.RunAtEvery, RunAtEvery)
                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.CalendarTimeSheetImport.RegistrySetting.PastDays, PastDays * -1)

                If LastRanAt <> Nothing Then

                    SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.CalendarTimeSheetImport.RegistrySetting.LastRanAt, LastRanAt)

                End If

            End If

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

