Namespace Services.VCC

    <HideModuleName()>
    Public Module Methods

        Public Event EntryLogWrittenEvent(ByVal EventLogEntry As System.Diagnostics.EventLogEntry)

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum RegistrySetting
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\VCC\", "RunAt", "01/01/2001 01:00 AM")>
            RunAt
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\VCC\", "LastRanAt", "01/01/2001 01:00 AM")>
            LastRanAt
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\VCC\", "Frequency", "Daily")>
            Frequency
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\VCC\", "ProcessSunday", "True")>
            ProcessSunday
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\VCC\", "ProcessMonday", "True")>
            ProcessMonday
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\VCC\", "ProcessTuesday", "True")>
            ProcessTuesday
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\VCC\", "ProcessWednesday", "True")>
            ProcessWednesday
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\VCC\", "ProcessThursday", "True")>
            ProcessThursday
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\VCC\", "ProcessFriday", "True")>
            ProcessFriday
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\VCC\", "ProcessSaturday", "True")>
            ProcessSaturday
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\VCC\", "RepeatEvery", "360")>
            RepeatEvery
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
        Public Sub ProcessDatabase(ByRef DatabaseProfile As AdvantageFramework.Database.DatabaseProfile)

            'objects
            Dim ErrorMessage As String = ""
            Dim Session As AdvantageFramework.Security.Session = Nothing
            Dim TimezoneOffset As AdvantageFramework.VCC.Classes.TimezoneOffset = Nothing
            Dim MediaManagerReviewDetailList As Generic.List(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail) = Nothing
            Dim VCCCards As Generic.List(Of AdvantageFramework.Database.Entities.VCCCard) = Nothing
            Dim VCCOrders As Generic.List(Of AdvantageFramework.MediaManager.Classes.VCCOrder) = Nothing
            Dim VCCCard As AdvantageFramework.Database.Entities.VCCCard = Nothing

            Try

                If DatabaseProfile IsNot Nothing Then

                    WriteToEventLog("VCC connecting to database --> " & DatabaseProfile.DatabaseName)

                    Session = New AdvantageFramework.Security.Session(Security.Application.Advantage, DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName, 0, DatabaseProfile.ConnectionString)

                    Using DbContext As New AdvantageFramework.Database.DbContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                        TimezoneOffset = AdvantageFramework.VCC.GetTimezoneOffset(DbContext)

                        Try

                            VCCCards = DbContext.VCCCards.Include("VCCCardDetails").Include("VCCCardNotes").ToList

                        Catch ex As Exception
                            VCCCards = Nothing
                        End Try

                        If VCCCards IsNot Nothing Then

                            VCCOrders = New Generic.List(Of AdvantageFramework.MediaManager.Classes.VCCOrder)

                            MediaManagerReviewDetailList = AdvantageFramework.MediaManager.LoadMediaManagerReviewDetails(DbContext, Nothing, Nothing, Nothing, Nothing,
                                                                                                Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, False, Nothing, True, Nothing, False, False)

                            For Each MMRD In MediaManagerReviewDetailList

                                VCCCard = Nothing

                                Try

                                    VCCCard = VCCCards.SingleOrDefault(Function(Entity) Entity.OrderNumber = MMRD.OrderNumber AndAlso Entity.LineNumber = MMRD.LineNumber)

                                Catch ex As Exception
                                    VCCCard = Nothing
                                End Try

                                If VCCCard IsNot Nothing AndAlso DateDiff(DateInterval.Month, VCCCard.ExpirationDate, Now) <= 0 AndAlso MMRD.ProcessControl.GetValueOrDefault(0) <> 6 Then

                                    VCCOrders.Add(New AdvantageFramework.MediaManager.Classes.VCCOrder(MMRD, VCCCard, TimezoneOffset))

                                End If

                            Next

                            WriteToEventLog("VCC refreshing cards --> " & DatabaseProfile.DatabaseName)

                            If AdvantageFramework.VCC.RefreshVCCData(Session, VCCOrders, ErrorMessage) Then

                                WriteToEventLog("VCC card refresh successful --> " & DatabaseProfile.DatabaseName)

                            Else

                                WriteToEventLog("VCC card refresh had error(s): " & ErrorMessage & " --> " & DatabaseProfile.DatabaseName)

                            End If

                        End If

                    End Using

                End If

            Catch ex As Exception

                WriteToEventLog("Error Processing - " & ex.Message & " --> " & DatabaseProfile.DatabaseName)

            End Try

        End Sub
        Public Function IsServiceReadyToRun(ByVal DatabaseProfile As AdvantageFramework.Database.DatabaseProfile) As Boolean

            'objects
            Dim ServiceIsReadyToRun As Boolean = False
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing
            Dim Schedule As AdvantageFramework.Services.Classes.Schedule = Nothing

            If DatabaseProfile IsNot Nothing Then

                Try

                    Using DataContext = New AdvantageFramework.Database.DataContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                        AdvantageService = LoadAdvantageService(DataContext)

                        If AdvantageService IsNot Nothing Then

                            If AdvantageService.Enabled Then

                                Schedule = New AdvantageFramework.Services.Classes.Schedule

                                LoadSettings(DataContext, Schedule)

                                If Schedule.Frequency.ToUpper = "DAILY" Then

                                    ServiceIsReadyToRun = Schedule.ReadyToRun

                                ElseIf Schedule.Frequency.ToUpper = "WEEKLY" Then

                                        If (Now.DayOfWeek = DayOfWeek.Sunday AndAlso Schedule.ProcessSunday) OrElse
                                            (Now.DayOfWeek = DayOfWeek.Monday AndAlso Schedule.ProcessMonday) OrElse
                                            (Now.DayOfWeek = DayOfWeek.Tuesday AndAlso Schedule.ProcessTuesday) OrElse
                                            (Now.DayOfWeek = DayOfWeek.Wednesday AndAlso Schedule.ProcessWednesday) OrElse
                                            (Now.DayOfWeek = DayOfWeek.Thursday AndAlso Schedule.ProcessThursday) OrElse
                                            (Now.DayOfWeek = DayOfWeek.Friday AndAlso Schedule.ProcessFriday) OrElse
                                            (Now.DayOfWeek = DayOfWeek.Saturday AndAlso Schedule.ProcessSaturday) Then

                                        ServiceIsReadyToRun = Schedule.ReadyToRun

                                    End If

                                End If

                            End If

                        End If

                        If ServiceIsReadyToRun Then

                            SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.VCC.RegistrySetting.LastRanAt, Now)

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
                    WriteToEventLog("Error -->" & ex.Message & Space(1) & DatabaseProfile.DatabaseName)
                End Try

                WriteToEventLog("Running -->" & Space(1) & DatabaseProfile.DatabaseName)

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

            If System.Diagnostics.EventLog.SourceExists("VCC Source") = False Then

                System.Diagnostics.EventLog.CreateEventSource("VCC Source", "VCC Log")

            End If

            _EventLog = New System.Diagnostics.EventLog("VCC Log", My.Computer.Name, "VCC Source")

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

                AdvantageService = AdvantageFramework.Services.LoadAdvantageService(DataContext, AdvantageFramework.Services.Service.AdvantageVCCWindowsService)

            Catch ex As Exception
                AdvantageService = Nothing
            End Try

            LoadAdvantageService = AdvantageService

        End Function
        Public Function LoadAdvantageServiceSetting(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AdvantageServiceID As Integer, ByVal RegistrySetting As AdvantageFramework.Services.VCC.RegistrySetting) As AdvantageFramework.Database.Entities.AdvantageServiceSetting

            'objects
            Dim AdvantageServiceSetting As AdvantageFramework.Database.Entities.AdvantageServiceSetting = Nothing

            Try

                AdvantageServiceSetting = AdvantageFramework.Services.LoadAdvantageServiceSetting(DataContext, AdvantageServiceID, RegistrySetting.ToString)

            Catch ex As Exception
                AdvantageServiceSetting = Nothing
            End Try

            LoadAdvantageServiceSetting = AdvantageServiceSetting

        End Function
        Public Function LoadAdvantageServiceSettingValue(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AdvantageServiceID As Integer, ByVal RegistrySetting As AdvantageFramework.Services.VCC.RegistrySetting) As Object

            'objects
            Dim SettingValue As Object = Nothing

            Try

                SettingValue = AdvantageFramework.Services.LoadAdvantageServiceSettingValue(DataContext, AdvantageServiceID, RegistrySetting.ToString)

            Catch ex As Exception
                SettingValue = Nothing
            End Try

            LoadAdvantageServiceSettingValue = SettingValue

        End Function
        Public Function SaveAdvantageServiceSettingValue(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AdvantageServiceID As Integer, ByVal RegistrySetting As AdvantageFramework.Services.VCC.RegistrySetting, ByVal SettingValue As Object) As Boolean

            'objects
            Dim Saved As Boolean = False

            Try

                Saved = AdvantageFramework.Services.SaveAdvantageServiceSettingValue(DataContext, AdvantageServiceID, RegistrySetting.ToString, SettingValue)

            Catch ex As Exception
                Saved = False
            End Try

            SaveAdvantageServiceSettingValue = Saved

        End Function
        Public Sub LoadSettings(DataContext As AdvantageFramework.Database.DataContext,
                                ByRef Schedule As AdvantageFramework.Services.Classes.Schedule)

            'objects
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing
            Dim SettingsChanged As Boolean = False

            AdvantageService = LoadAdvantageService(DataContext)

            If AdvantageService IsNot Nothing Then

                Date.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.VCC.RegistrySetting.RunAt), Schedule.RunAt)
                Date.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.VCC.RegistrySetting.LastRanAt), Schedule.LastRanAt)

                Schedule.Frequency = LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.VCC.RegistrySetting.Frequency)

                Boolean.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.VCC.RegistrySetting.ProcessSunday), Schedule.ProcessSunday)
                Boolean.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.VCC.RegistrySetting.ProcessMonday), Schedule.ProcessMonday)
                Boolean.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.VCC.RegistrySetting.ProcessTuesday), Schedule.ProcessTuesday)
                Boolean.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.VCC.RegistrySetting.ProcessWednesday), Schedule.ProcessWednesday)
                Boolean.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.VCC.RegistrySetting.ProcessThursday), Schedule.ProcessThursday)
                Boolean.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.VCC.RegistrySetting.ProcessFriday), Schedule.ProcessFriday)
                Boolean.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.VCC.RegistrySetting.ProcessSaturday), Schedule.ProcessSaturday)

                Schedule.RepeatEvery = LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.VCC.RegistrySetting.RepeatEvery)

            End If

        End Sub
        Public Sub SaveSettings(ByVal DataContext As AdvantageFramework.Database.DataContext, Schedule As AdvantageFramework.Services.Classes.Schedule)

            'objects
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing

            AdvantageService = LoadAdvantageService(DataContext)

            If AdvantageService IsNot Nothing Then

                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.VCC.RegistrySetting.RunAt, Schedule.RunAt)

                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.VCC.RegistrySetting.Frequency, Schedule.Frequency)

                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.VCC.RegistrySetting.ProcessSunday, Schedule.ProcessSunday)
                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.VCC.RegistrySetting.ProcessMonday, Schedule.ProcessMonday)
                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.VCC.RegistrySetting.ProcessTuesday, Schedule.ProcessTuesday)
                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.VCC.RegistrySetting.ProcessWednesday, Schedule.ProcessWednesday)
                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.VCC.RegistrySetting.ProcessThursday, Schedule.ProcessThursday)
                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.VCC.RegistrySetting.ProcessFriday, Schedule.ProcessFriday)
                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.VCC.RegistrySetting.ProcessSaturday, Schedule.ProcessSaturday)

                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.VCC.RegistrySetting.RepeatEvery, Schedule.RepeatEvery)

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

