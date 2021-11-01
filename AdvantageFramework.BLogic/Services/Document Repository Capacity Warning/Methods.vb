Namespace Services.DocumentRepositoryCapacityWarning

    <HideModuleName()>
    Public Module Methods

        Public Event EntryLogWrittenEvent(ByVal EventLogEntry As System.Diagnostics.EventLogEntry)

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum RegistrySetting
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\DocumentRepositoryCapacityWarning\", "RunAt", "01/01/2001 01:00 AM")>
            RunAt
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\DocumentRepositoryCapacityWarning\", "Email", "")>
            Email
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\DocumentRepositoryCapacityWarning\", "Threshold", "0.9")>
            Threshold
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
            Dim Email As String = String.Empty
            Dim Threshold As Decimal = 0.9
            Dim DocumentRepositoryLimit As Long = -1
            Dim DocumentRepositorySize As Long = 0
            Dim DocumentRepositoryUsagePercentage As Decimal = 0
            Dim SendingEmailStatus As AdvantageFramework.Email.SendingEmailStatus = AdvantageFramework.Email.SendingEmailStatus.EmailSent
            Dim SendingEmailErrorMessage As String = String.Empty

            Try

                If DatabaseProfile IsNot Nothing Then

                    WriteToEventLog("Document Repository Capacity Warning connecting to database --> " & DatabaseProfile.DatabaseName)

                    Using DataContext = New AdvantageFramework.Database.DataContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                        WriteToEventLog("Document Repository Capacity Warning load service settings --> " & DatabaseProfile.DatabaseName)

                        AdvantageFramework.Services.DocumentRepositoryCapacityWarning.LoadSettings(DataContext, Nothing, Email, Threshold)

                    End Using

                    Using DbContext = New AdvantageFramework.Database.DbContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                            DbContext.Database.Connection.Open()
                            SecurityDbContext.Database.Connection.Open()

                            If String.IsNullOrWhiteSpace(Email) = False Then

                                WriteToEventLog("load repository limit and size --> " & DatabaseProfile.DatabaseName)

                                DocumentRepositoryLimit = AdvantageFramework.FileSystem.GetDocumentRepositoryLimit(DbContext)
                                DocumentRepositorySize = AdvantageFramework.FileSystem.GetDocumentRepositorySize(DbContext)

                                If DocumentRepositoryLimit > 0 Then

                                    DocumentRepositoryUsagePercentage = (DocumentRepositorySize / DocumentRepositoryLimit)

                                    If DocumentRepositoryUsagePercentage > Threshold Then

                                        WriteToEventLog("threshold met and sending email --> " & DatabaseProfile.DatabaseName)

                                        If AdvantageFramework.Email.Send(DbContext, SecurityDbContext, Email, "Document Repository Capacity Limit Approaching",
                                                                         "The repository is " & FormatPercent(DocumentRepositoryUsagePercentage, 0) & " full.",
                                                                         3, Nothing, SendingEmailStatus, SendingEmailErrorMessage, "", "") Then

                                            WriteToEventLog("email sent --> " & DatabaseProfile.DatabaseName)

                                        Else

                                            If SendingEmailStatus <> AdvantageFramework.Email.SendingEmailStatus.EmailSent AndAlso
                                                    SendingEmailStatus <> AdvantageFramework.Email.SendingEmailStatus.EmailSentWithoutAttachment Then

                                                If String.IsNullOrWhiteSpace(SendingEmailErrorMessage) = False Then

                                                    WriteToEventLog("failed to send email (" & SendingEmailErrorMessage & ")(" & AdvantageFramework.StringUtilities.GetNameAsWords(SendingEmailStatus.ToString) & ") --> " & DatabaseProfile.DatabaseName)

                                                Else

                                                    WriteToEventLog("failed to send email (" & AdvantageFramework.StringUtilities.GetNameAsWords(SendingEmailStatus.ToString) & ") --> " & DatabaseProfile.DatabaseName)

                                                End If

                                            Else

                                                WriteToEventLog("failed to send email --> " & DatabaseProfile.DatabaseName)

                                            End If

                                        End If

                                    Else

                                        WriteToEventLog("Less than threshold --> " & DatabaseProfile.DatabaseName)

                                    End If

                                Else

                                    WriteToEventLog("repository limit not configured --> " & DatabaseProfile.DatabaseName)

                                End If

                            Else

                                WriteToEventLog("no valid email --> " & DatabaseProfile.DatabaseName)

                            End If

                        End Using

                    End Using

                End If

            Catch ex As Exception

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

                                DateTime.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.DocumentRepositoryCapacityWarning.RegistrySetting.RunAt), RunAt)

                                If RunAt = CDate("01/01/2001 01:00 AM") Then

                                    RunAt = Now.ToShortDateString & " " & RunAt.ToShortTimeString

                                End If

                                If DateDiff(DateInterval.Minute, RunAt, Now) >= 0 Then

                                    RunAt = Now.AddDays(1).ToShortDateString & " " & RunAt.ToShortTimeString

                                    SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.DocumentRepositoryCapacityWarning.RegistrySetting.RunAt, RunAt)

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

            If System.Diagnostics.EventLog.SourceExists("Document Repository Capacity Warning Source") = False Then

                System.Diagnostics.EventLog.CreateEventSource("Document Repository Capacity Warning Source", "Document Repository Capacity Warning Log")

            End If

            _EventLog = New System.Diagnostics.EventLog("Document Repository Capacity Warning Log", My.Computer.Name, "Document Repository Capacity Warning Source")

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

                AdvantageService = AdvantageFramework.Services.LoadAdvantageService(DataContext, AdvantageFramework.Services.Service.AdvantageDocumentRepositoryCapacityWarningWindowsService)

            Catch ex As Exception
                AdvantageService = Nothing
            End Try

            LoadAdvantageService = AdvantageService

        End Function
        Public Function LoadAdvantageServiceSetting(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AdvantageServiceID As Integer, ByVal RegistrySetting As AdvantageFramework.Services.DocumentRepositoryCapacityWarning.RegistrySetting) As AdvantageFramework.Database.Entities.AdvantageServiceSetting

            'objects
            Dim AdvantageServiceSetting As AdvantageFramework.Database.Entities.AdvantageServiceSetting = Nothing

            Try

                AdvantageServiceSetting = AdvantageFramework.Services.LoadAdvantageServiceSetting(DataContext, AdvantageServiceID, RegistrySetting.ToString)

            Catch ex As Exception
                AdvantageServiceSetting = Nothing
            End Try

            LoadAdvantageServiceSetting = AdvantageServiceSetting

        End Function
        Public Function LoadAdvantageServiceSettingValue(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AdvantageServiceID As Integer, ByVal RegistrySetting As AdvantageFramework.Services.DocumentRepositoryCapacityWarning.RegistrySetting) As Object

            'objects
            Dim SettingValue As Object = Nothing

            Try

                SettingValue = AdvantageFramework.Services.LoadAdvantageServiceSettingValue(DataContext, AdvantageServiceID, RegistrySetting.ToString)

            Catch ex As Exception
                SettingValue = Nothing
            End Try

            LoadAdvantageServiceSettingValue = SettingValue

        End Function
        Public Function SaveAdvantageServiceSettingValue(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AdvantageServiceID As Integer, ByVal RegistrySetting As AdvantageFramework.Services.DocumentRepositoryCapacityWarning.RegistrySetting, ByVal SettingValue As Object) As Boolean

            'objects
            Dim Saved As Boolean = False

            Try

                Saved = AdvantageFramework.Services.SaveAdvantageServiceSettingValue(DataContext, AdvantageServiceID, RegistrySetting.ToString, SettingValue)

            Catch ex As Exception
                Saved = False
            End Try

            SaveAdvantageServiceSettingValue = Saved

        End Function
        Public Sub LoadSettings(ByVal DataContext As AdvantageFramework.Database.DataContext, ByRef RunAt As Date, ByRef Email As String, ByRef Threshold As Decimal)

            'objects
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing

            AdvantageService = LoadAdvantageService(DataContext)

            If AdvantageService IsNot Nothing Then

                DateTime.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.DocumentRepositoryCapacityWarning.RegistrySetting.RunAt), RunAt)

                If RunAt.Year = 1 Then

                    RunAt = New Date(Now.Year, Now.Month, Now.Day, 1, 0, 0)

                End If

                Email = LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.DocumentRepositoryCapacityWarning.RegistrySetting.Email)

                Threshold = LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.DocumentRepositoryCapacityWarning.RegistrySetting.Threshold)

            End If

        End Sub
        Public Sub SaveSettings(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal RunAt As DateTime, Email As String, Threshold As Decimal)

            'objects
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing

            AdvantageService = LoadAdvantageService(DataContext)

            If AdvantageService IsNot Nothing Then

                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.DocumentRepositoryCapacityWarning.RegistrySetting.RunAt, RunAt)
                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.DocumentRepositoryCapacityWarning.RegistrySetting.Email, Email)
                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.DocumentRepositoryCapacityWarning.RegistrySetting.Threshold, Threshold)

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

