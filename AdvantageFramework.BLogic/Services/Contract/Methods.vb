Namespace Services.Contract

    <HideModuleName()> _
    Public Module Methods

        Public Event EntryLogWrittenEvent(ByVal EventLogEntry As System.Diagnostics.EventLogEntry)

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum RegistrySetting
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\Contract\", "RunAt", "01/01/2001 01:00 AM")> _
            RunAt
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\Contract\", "ContractRenewal", "False")> _
            ContractRenewal
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\Contract\", "ContractRenewalDaysPrior", "0")> _
            ContractRenewalDaysPrior
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
        Public Sub ProcessDatabase(ByVal DatabaseProfile As AdvantageFramework.Database.DatabaseProfile)

            'objects
            Dim RunAtTime As Date = Nothing
            Dim NotifyContractRenewal As Boolean = False
            Dim ContractRenewalDaysPrior As Integer = 1
            Dim Contract As AdvantageFramework.Database.Entities.Contract = Nothing
            Dim ContractReports As Generic.List(Of AdvantageFramework.Database.Entities.ContractReport) = Nothing
            Dim UpdateUpcomingReportDate As Boolean = False
            Dim UpdateReportCompleted As Boolean = False
            Dim ContractRenewalSent As Boolean = False

            Try

                If DatabaseProfile IsNot Nothing Then

                    WriteToEventLog("Contract connecting to database --> " & DatabaseProfile.DatabaseName)

                    Using DataContext = New AdvantageFramework.Database.DataContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                        Using DbContext = New AdvantageFramework.Database.DbContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                                WriteToEventLog("Contract loadsettings --> " & DatabaseProfile.DatabaseName)

                                AdvantageFramework.Services.Contract.LoadSettings(DataContext, RunAtTime, NotifyContractRenewal, ContractRenewalDaysPrior)

                                WriteToEventLog("Checking Upcoming Contract Renewal Setting...")

                                If NotifyContractRenewal Then

                                    WriteToEventLog("Loading Contracts for Renewal...")

                                    For Each Contract In AdvantageFramework.Database.Procedures.Contract.Load(DbContext).Where(Function(Entity) Entity.IsContract = True AndAlso
                                                                                                                                            Entity.Product IsNot Nothing AndAlso
                                                                                                                                            Entity.EndDate IsNot Nothing).ToList

                                        ContractRenewalSent = False

                                        If Contract.Product.IsActive.GetValueOrDefault(1) = 1 Then

                                            WriteToEventLog("Checking Contract End Date: " & Contract.EndDate & " for " & Contract.ID & " - " & Contract.Description & " LastSent:" & Contract.RenewalAlertSentDate.ToString)

                                            If Now <= Contract.EndDate.Value AndAlso DateDiff(DateInterval.Day, CDate(Now.ToShortDateString), Contract.EndDate.Value) <= ContractRenewalDaysPrior AndAlso
                                                (Contract.RenewalAlertSentDate Is Nothing OrElse DateDiff(DateInterval.Day, Contract.RenewalAlertSentDate.Value, Contract.EndDate.Value) > ContractRenewalDaysPrior) Then

                                                WriteToEventLog("Processing Contract: " & Contract.ID & " - Contacts...")

                                                For Each ContractContact In Contract.ContractContacts

                                                    If ContractContact.IncludeInAlert Then

                                                        WriteToEventLog("Send Contract Renewal Alert/Email to: " & ContractContact.EmployeeCode & "?")

                                                        If AdvantageFramework.AlertSystem.CreateAlertForContractNotification(DbContext, SecurityDbContext, ContractContact.EmployeeCode, AlertSystem.ContractNotificationAlertCategory.UpcomingContractRenewal, Contract, Nothing) Then

                                                            WriteToEventLog("Contract Renewal Alert/Email SENT to: " & ContractContact.EmployeeCode & ".")

                                                            ContractRenewalSent = True

                                                        Else

                                                            WriteToEventLog("Contract Renewal Alert/Email NOT sent to: " & ContractContact.EmployeeCode & ".")

                                                        End If

                                                    End If

                                                Next

                                            Else

                                                WriteToEventLog("Contract: " & Contract.ID & " - not ready for renewal.")

                                            End If

                                            Contract.RenewalAlertSentDate = If(ContractRenewalSent, CDate(Now.ToShortDateString), Contract.RenewalAlertSentDate)

                                        End If

                                        AdvantageFramework.Database.Procedures.Contract.Update(DbContext, Contract)

                                    Next

                                Else

                                    WriteToEventLog("Upcoming Contract Renewal Setting - NOT set.")

                                End If

                                WriteToEventLog("Loading Contracts Reports...")

                                ContractReports = (From Entity In AdvantageFramework.Database.Procedures.ContractReport.Load(DbContext).ToList
                                                   Where Entity.SendAlertUponCompletion = True OrElse
                                                         Entity.SendAlertDaysPrior = True
                                                   Select Entity).ToList

                                For Each ContractReport In ContractReports

                                    UpdateUpcomingReportDate = False
                                    UpdateReportCompleted = False

                                    If ContractReport.SendAlertDaysPrior AndAlso ContractReport.AlertDaysPrior IsNot Nothing AndAlso ContractReport.NextStartDate IsNot Nothing Then

                                        WriteToEventLog("Upcoming Required Reports check - ContractReportID:" & ContractReport.ID & " NextStartDate: " & ContractReport.NextStartDate & " UpcomingAlertSentDate: " & ContractReport.UpcomingAlertSentDate)

                                        If Now <= ContractReport.NextStartDate.Value AndAlso DateDiff(DateInterval.Day, CDate(Now.ToShortDateString), ContractReport.NextStartDate.Value) <= ContractReport.AlertDaysPrior AndAlso
                                            (ContractReport.UpcomingAlertSentDate Is Nothing OrElse DateDiff(DateInterval.Day, ContractReport.UpcomingAlertSentDate.Value, ContractReport.NextStartDate.Value) > ContractReport.AlertDaysPrior) Then

                                            If ContractReport.NotifyInternalContacts Then

                                                WriteToEventLog("Processing Report: " & ContractReport.ID & " - Contacts...")

                                                For Each Contact In ContractReport.Contract.ContractContacts

                                                    If Contact.IncludeInAlert Then

                                                        WriteToEventLog("Send Upcoming Report Alert/Email to: " & Contact.EmployeeCode & "?")

                                                        If AdvantageFramework.AlertSystem.CreateAlertForContractNotification(DbContext, SecurityDbContext, Contact.EmployeeCode, AlertSystem.ContractNotificationAlertCategory.UpcomingRequiredReport, ContractReport.Contract, ContractReport) Then

                                                            WriteToEventLog("Upcoming Report Alert/Email SENT to: " & Contact.EmployeeCode & ".")

                                                            UpdateUpcomingReportDate = True

                                                        Else

                                                            WriteToEventLog("Upcoming Report Alert/Email NOT sent to: " & Contact.EmployeeCode & ".")

                                                        End If

                                                    End If

                                                Next

                                            End If

                                            If ContractReport.EmployeeCode IsNot Nothing AndAlso ContractReport.EmployeeCode <> "" Then

                                                WriteToEventLog("Send Upcoming Report Alert/Email to: " & ContractReport.EmployeeCode & "?")

                                                If AdvantageFramework.AlertSystem.CreateAlertForContractNotification(DbContext, SecurityDbContext, ContractReport.EmployeeCode, AlertSystem.ContractNotificationAlertCategory.UpcomingRequiredReport, ContractReport.Contract, ContractReport) Then

                                                    WriteToEventLog("Upcoming Report Alert/Email SENT to: " & ContractReport.EmployeeCode & ".")

                                                    UpdateUpcomingReportDate = True

                                                Else

                                                    WriteToEventLog("Upcoming Report Alert/Email NOT sent to: " & ContractReport.EmployeeCode & ".")

                                                End If

                                            End If

                                        Else

                                            WriteToEventLog("Upcoming Required Reports ContractReportID:" & ContractReport.ID & " not ready to send.")

                                        End If

                                        ContractReport.UpcomingAlertSentDate = If(UpdateUpcomingReportDate, CDate(Now.ToShortDateString), ContractReport.UpcomingAlertSentDate)

                                    End If

                                    If ContractReport.SendAlertUponCompletion AndAlso ContractReport.LastCompletedDate IsNot Nothing Then

                                        WriteToEventLog("Required Report Completed check - ContractReportID:" & ContractReport.ID & " LastCompletedDate: " & ContractReport.LastCompletedDate & " LastCompletedAlertSentDate: " & ContractReport.LastCompletedAlertSentDate)

                                        If ContractReport.LastCompletedAlertSentDate Is Nothing OrElse ContractReport.LastCompletedDate.Value > ContractReport.LastCompletedAlertSentDate Then

                                            If ContractReport.NotifyInternalContacts Then

                                                WriteToEventLog("Processing Report: " & ContractReport.ID & " - Contacts...")

                                                For Each Contact In ContractReport.Contract.ContractContacts

                                                    If Contact.IncludeInAlert Then

                                                        WriteToEventLog("Send Report complete Alert/Email to: " & Contact.EmployeeCode & "?")

                                                        If AdvantageFramework.AlertSystem.CreateAlertForContractNotification(DbContext, SecurityDbContext, Contact.EmployeeCode, AlertSystem.ContractNotificationAlertCategory.RequiredReportCompleted, ContractReport.Contract, ContractReport) Then

                                                            WriteToEventLog("Report complete Alert/Email SENT to: " & Contact.EmployeeCode & ".")

                                                            UpdateReportCompleted = True

                                                        Else

                                                            WriteToEventLog("Report complete Alert/Email NOT sent to: " & Contact.EmployeeCode & ".")

                                                        End If

                                                    End If

                                                Next

                                            End If

                                            If ContractReport.EmployeeCode IsNot Nothing AndAlso ContractReport.EmployeeCode <> "" Then

                                                WriteToEventLog("Send Report complete Alert/Email to: " & ContractReport.EmployeeCode & "?")

                                                If AdvantageFramework.AlertSystem.CreateAlertForContractNotification(DbContext, SecurityDbContext, ContractReport.EmployeeCode, AlertSystem.ContractNotificationAlertCategory.RequiredReportCompleted, ContractReport.Contract, ContractReport) Then

                                                    WriteToEventLog("Report complete Alert/Email SENT to: " & ContractReport.EmployeeCode & ".")

                                                    UpdateReportCompleted = True

                                                Else

                                                    WriteToEventLog("Report complete Alert/Email NOT sent to: " & ContractReport.EmployeeCode & ".")

                                                End If

                                            End If

                                        Else

                                            WriteToEventLog("Required Report Completed check - ContractReportID:" & ContractReport.ID & " not ready to send.")

                                        End If

                                        ContractReport.LastCompletedAlertSentDate = If(UpdateReportCompleted, CDate(Now.ToShortDateString), ContractReport.LastCompletedAlertSentDate)

                                    End If

                                    AdvantageFramework.Database.Procedures.ContractReport.Update(DbContext, ContractReport)

                                Next

                            End Using

                        End Using

                    End Using

                End If

            Catch ex As Exception
                WriteToEventLog(ex.Message)
            End Try

        End Sub
        Public Function IsServiceReadyToRun(ByVal DatabaseProfile As AdvantageFramework.Database.DatabaseProfile) As Boolean

            'objects
            Dim ServiceIsReadyToRun As Boolean = False
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing
            Dim RunAt As Date = Nothing

            If DatabaseProfile IsNot Nothing Then

                Try

                    Using DataContext = New AdvantageFramework.Database.DataContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                        AdvantageService = LoadAdvantageService(DataContext)

                        If AdvantageService IsNot Nothing Then

                            If AdvantageService.Enabled Then

                                DateTime.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.Contract.RegistrySetting.RunAt), RunAt)

                                If RunAt = CDate("01/01/2001 01:00 AM") Then

                                    RunAt = Now.ToShortDateString & " " & RunAt.ToShortTimeString

                                End If

                                If DateDiff(DateInterval.Minute, RunAt, Now) >= 0 Then

                                    RunAt = Now.AddDays(1).ToShortDateString & " " & RunAt.ToShortTimeString

                                    SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.Contract.RegistrySetting.RunAt, RunAt)

                                    ServiceIsReadyToRun = True

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

            If System.Diagnostics.EventLog.SourceExists("Contract Source") = False Then

                System.Diagnostics.EventLog.CreateEventSource("Contract Source", "Contract Log")

            End If

            _EventLog = New System.Diagnostics.EventLog("Contract Log", My.Computer.Name, "Contract Source")

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

                AdvantageService = AdvantageFramework.Services.LoadAdvantageService(DataContext, AdvantageFramework.Services.Service.AdvantageContractWindowsService)

            Catch ex As Exception
                AdvantageService = Nothing
            End Try

            LoadAdvantageService = AdvantageService

        End Function
        Public Function LoadAdvantageServiceSetting(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AdvantageServiceID As Integer, ByVal RegistrySetting As AdvantageFramework.Services.Contract.RegistrySetting) As AdvantageFramework.Database.Entities.AdvantageServiceSetting

            'objects
            Dim AdvantageServiceSetting As AdvantageFramework.Database.Entities.AdvantageServiceSetting = Nothing

            Try

                AdvantageServiceSetting = AdvantageFramework.Services.LoadAdvantageServiceSetting(DataContext, AdvantageServiceID, RegistrySetting.ToString)

            Catch ex As Exception
                AdvantageServiceSetting = Nothing
            End Try

            LoadAdvantageServiceSetting = AdvantageServiceSetting

        End Function
        Public Function LoadAdvantageServiceSettingValue(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AdvantageServiceID As Integer, ByVal RegistrySetting As AdvantageFramework.Services.Contract.RegistrySetting) As Object

            'objects
            Dim SettingValue As Object = Nothing

            Try

                SettingValue = AdvantageFramework.Services.LoadAdvantageServiceSettingValue(DataContext, AdvantageServiceID, RegistrySetting.ToString)

            Catch ex As Exception
                SettingValue = Nothing
            End Try

            LoadAdvantageServiceSettingValue = SettingValue

        End Function
        Public Function SaveAdvantageServiceSettingValue(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AdvantageServiceID As Integer, ByVal RegistrySetting As AdvantageFramework.Services.Contract.RegistrySetting, ByVal SettingValue As Object) As Boolean

            'objects
            Dim Saved As Boolean = False

            Try

                Saved = AdvantageFramework.Services.SaveAdvantageServiceSettingValue(DataContext, AdvantageServiceID, RegistrySetting.ToString, SettingValue)

            Catch ex As Exception
                Saved = False
            End Try

            SaveAdvantageServiceSettingValue = Saved

        End Function
        Public Sub LoadSettings(ByVal DataContext As AdvantageFramework.Database.DataContext, ByRef RunAt As Date, ByRef NotifyContractRenewal As Boolean, ByRef ContractRenewalDaysPrior As Integer)

            'objects
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing

            AdvantageService = LoadAdvantageService(DataContext)

            If AdvantageService IsNot Nothing Then

                DateTime.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.Contract.RegistrySetting.RunAt), RunAt)

                NotifyContractRenewal = LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.Contract.RegistrySetting.ContractRenewal)

                ContractRenewalDaysPrior = LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.Contract.RegistrySetting.ContractRenewalDaysPrior)

            End If

        End Sub
        Public Sub SaveSettings(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal RunAt As DateTime, ByRef NotifyContractRenewal As String, ByRef ContractRenewalDaysPrior As String)

            'objects
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing
            'Dim PreviousRunAt As DateTime
            'Dim PreviousNotifyContractRenewal As String = ""
            'Dim PreviousContractRenewalDaysPrior As String = ""
            'Dim ServiceController As System.ServiceProcess.ServiceController = Nothing
            'Dim ServiceReloadSettings As Boolean = False

            AdvantageService = LoadAdvantageService(DataContext)

            If AdvantageService IsNot Nothing Then

                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.Contract.RegistrySetting.RunAt, RunAt)
                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.Contract.RegistrySetting.ContractRenewal, NotifyContractRenewal)
                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.Contract.RegistrySetting.ContractRenewalDaysPrior, ContractRenewalDaysPrior)

            End If

            'DateTime.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.Contract.RegistrySetting.RunAt), PreviousRunAt)

            'If PreviousRunAt <> RunAt Then

            '    SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.Contract.RegistrySetting.RunAt, RunAt)
            '    ServiceReloadSettings = True

            'End If

            'PreviousNotifyContractRenewal = LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.Contract.RegistrySetting.ContractRenewal)

            'If PreviousNotifyContractRenewal <> NotifyContractRenewal Then

            '    SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.Contract.RegistrySetting.ContractRenewal, NotifyContractRenewal)
            '    ServiceReloadSettings = True

            'End If

            'PreviousContractRenewalDaysPrior = LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.Contract.RegistrySetting.ContractRenewalDaysPrior)

            'If PreviousContractRenewalDaysPrior <> ContractRenewalDaysPrior Then

            '    SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.Contract.RegistrySetting.ContractRenewalDaysPrior, ContractRenewalDaysPrior)
            '    ServiceReloadSettings = True

            'End If

            'If ServiceReloadSettings Then

            '    ServiceController = AdvantageFramework.Services.Load(AdvantageFramework.Services.Service.AdvantageContractWindowsService)

            '    If ServiceController IsNot Nothing AndAlso ServiceController.Status = ServiceProcess.ServiceControllerStatus.Running Then

            '        ServiceController.ExecuteCommand(AdvantageFramework.Services.Contract.CustomCommand.LoadSettings)

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

