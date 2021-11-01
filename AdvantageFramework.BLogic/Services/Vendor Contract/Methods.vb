Namespace Services.VendorContract

    <HideModuleName()>
    Public Module Methods

        Public Event EntryLogWrittenEvent(ByVal EventLogEntry As System.Diagnostics.EventLogEntry)

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum RegistrySetting
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\VendorContract\", "RunAt", "01/01/2001 01:00 AM")>
            RunAt
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\VendorContract\", "ContractRenewal", "False")>
            ContractRenewal
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\VendorContract\", "ContractRenewalDaysPrior", "0")>
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
            Dim VendorContract As AdvantageFramework.Database.Entities.VendorContract = Nothing
            Dim ContractRenewalSent As Boolean = False

            Try

                If DatabaseProfile IsNot Nothing Then

                    WriteToEventLog("Vendor Contract connecting to database --> " & DatabaseProfile.DatabaseName)

                    Using DataContext = New AdvantageFramework.Database.DataContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                        Using DbContext = New AdvantageFramework.Database.DbContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                                WriteToEventLog("Vendor Contract loadsettings --> " & DatabaseProfile.DatabaseName)

                                AdvantageFramework.Services.VendorContract.LoadSettings(DataContext, RunAtTime, NotifyContractRenewal, ContractRenewalDaysPrior)

                                WriteToEventLog("Checking Upcoming Vendor Contract Renewal Setting...")

                                If NotifyContractRenewal Then

                                    WriteToEventLog("Loading Vendor Contracts for Renewal...")

                                    For Each VendorContract In AdvantageFramework.Database.Procedures.VendorContract.Load(DbContext).Where(Function(Entity) Entity.EndDate IsNot Nothing).ToList

                                        ContractRenewalSent = False

                                        If AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, VendorContract.VendorCode).ActiveFlag.GetValueOrDefault(0) = 1 Then

                                            WriteToEventLog("Checking Vendor Contract End Date: " & VendorContract.EndDate & " for " & VendorContract.ID & " - " & VendorContract.Description & " LastSent:" & VendorContract.RenewalAlertSentDate.ToString)

                                            If Now <= VendorContract.EndDate.Value AndAlso DateDiff(DateInterval.Day, CDate(Now.ToShortDateString), VendorContract.EndDate.Value) <= ContractRenewalDaysPrior AndAlso
                                                (VendorContract.RenewalAlertSentDate Is Nothing OrElse DateDiff(DateInterval.Day, VendorContract.RenewalAlertSentDate.Value, VendorContract.EndDate.Value) > ContractRenewalDaysPrior) Then

                                                WriteToEventLog("Processing Vendor Contract: " & VendorContract.ID & " - Contacts...")

                                                For Each VendorContractContact In AdvantageFramework.Database.Procedures.VendorContractContact.LoadByContractID(DbContext, VendorContract.ID).ToList

                                                    If VendorContractContact.IncludeInAlert Then

                                                        WriteToEventLog("Send Vendor Contract Renewal Alert/Email to: " & VendorContractContact.EmployeeCode & "?")

                                                        If AdvantageFramework.AlertSystem.CreateAlertForVendorContractNotification(DbContext, SecurityDbContext, VendorContractContact.EmployeeCode, AlertSystem.ContractNotificationAlertCategory.UpcomingContractRenewal, VendorContract) Then

                                                            WriteToEventLog("Vendor Contract Renewal Alert/Email SENT to: " & VendorContractContact.EmployeeCode & ".")

                                                            ContractRenewalSent = True

                                                        Else

                                                            WriteToEventLog("Vendor Contract Renewal Alert/Email NOT sent to: " & VendorContractContact.EmployeeCode & ".")

                                                        End If

                                                    Else

                                                        WriteToEventLog("Vendor Contract Contact is excluded from Alert/Email: " & VendorContractContact.EmployeeCode & ".")

                                                    End If

                                                Next

                                            Else

                                                WriteToEventLog("Vendor Contract: " & VendorContract.ID & " - not ready for renewal.")

                                            End If

                                            VendorContract.RenewalAlertSentDate = If(ContractRenewalSent, CDate(Now.ToShortDateString), VendorContract.RenewalAlertSentDate)

                                        Else

                                            WriteToEventLog("Vendor Contract cannot be renewed for inactive Vendor: " & VendorContract.ID & ".")

                                        End If

                                        AdvantageFramework.Database.Procedures.VendorContract.Update(DbContext, VendorContract, "")

                                    Next

                                    WriteToEventLog("Finished renewing Vendor Contracts.")

                                Else

                                    WriteToEventLog("Upcoming Vendor Contract Renewal Setting - NOT set.")

                                End If

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

                                DateTime.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.VendorContract.RegistrySetting.RunAt), RunAt)

                                If RunAt = CDate("01/01/2001 01:00 AM") Then

                                    RunAt = Now.ToShortDateString & " " & RunAt.ToShortTimeString

                                End If

                                If DateDiff(DateInterval.Minute, RunAt, Now) >= 0 Then

                                    RunAt = Now.AddDays(1).ToShortDateString & " " & RunAt.ToShortTimeString

                                    SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.VendorContract.RegistrySetting.RunAt, RunAt)

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

            If System.Diagnostics.EventLog.SourceExists("Vendor Contract Source") = False Then

                System.Diagnostics.EventLog.CreateEventSource("Vendor Contract Source", "Vendor Contract Log")

            End If

            _EventLog = New System.Diagnostics.EventLog("Vendor Contract Log", My.Computer.Name, "Vendor Contract Source")

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

                AdvantageService = AdvantageFramework.Services.LoadAdvantageService(DataContext, AdvantageFramework.Services.Service.AdvantageVendorContractWindowsService)

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

                DateTime.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.VendorContract.RegistrySetting.RunAt), RunAt)

                NotifyContractRenewal = LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.VendorContract.RegistrySetting.ContractRenewal)

                ContractRenewalDaysPrior = LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.VendorContract.RegistrySetting.ContractRenewalDaysPrior)

            End If

        End Sub
        Public Sub SaveSettings(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal RunAt As DateTime, ByRef NotifyContractRenewal As String, ByRef ContractRenewalDaysPrior As String)

            'objects
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing

            AdvantageService = LoadAdvantageService(DataContext)

            If AdvantageService IsNot Nothing Then

                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.VendorContract.RegistrySetting.RunAt, RunAt)
                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.VendorContract.RegistrySetting.ContractRenewal, NotifyContractRenewal)
                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.VendorContract.RegistrySetting.ContractRenewalDaysPrior, ContractRenewalDaysPrior)

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

