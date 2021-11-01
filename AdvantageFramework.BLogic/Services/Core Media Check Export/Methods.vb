Namespace Services.CoreMediaCheckExport

    <HideModuleName()> _
    Public Module Methods

        Public Event EntryLogWrittenEvent(ByVal EventLogEntry As System.Diagnostics.EventLogEntry)

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum RegistrySetting
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\Core Media Check Export\", "RunAt", "01/01/2001 01:00 AM")> _
            RunAt
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\Core Media Check Export\", "ExportPath", "C:\")> _
            ExportPath
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\Core Media Check Export\", "NextRunAt", "01/01/2001 01:00 AM")> _
            NextRunAt
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
            Dim ExportFolder As String = ""
            Dim StringBuilder As System.Text.StringBuilder = Nothing
            Dim ExportDataLine As String = ""
            Dim CoreMediaCheckExport As AdvantageFramework.Database.Views.CoreMediaCheckExport = Nothing

            Try

                If DatabaseProfile IsNot Nothing Then

                    WriteToEventLog("Processing database --> " & DatabaseProfile.DatabaseName)

                    Using DataContext = New AdvantageFramework.Database.DataContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                        Using DbContext = New AdvantageFramework.Database.DbContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                            AdvantageFramework.Services.CoreMediaCheckExport.LoadSettings(DataContext, RunAtTime, ExportFolder)

                            If My.Computer.FileSystem.DirectoryExists(ExportFolder) = False Then

                                WriteToEventLog("directory does not exist... attempting to create directory --> " & ExportFolder)

                                Try

                                    My.Computer.FileSystem.CreateDirectory(ExportFolder)

                                Catch ex As Exception

                                End Try

                            End If

                            If My.Computer.FileSystem.DirectoryExists(ExportFolder) Then

                                StringBuilder = New System.Text.StringBuilder()

                                WriteToEventLog("loading export data...")

                                For Each CoreMediaCheckExport In AdvantageFramework.Database.Procedures.CoreMediaCheckExportView.Load(DbContext).ToList.Where(Function(CheckExport) CheckExport.CheckDate.ToShortDateString = Now.ToShortDateString).ToList

                                    ExportDataLine = AdvantageFramework.StringUtilities.PadWithCharacter(CoreMediaCheckExport.CheckNumber, 7, " ", True)
                                    ExportDataLine &= AdvantageFramework.StringUtilities.PadWithCharacter(CoreMediaCheckExport.PayToVendorCode, 8, " ", True)
                                    ExportDataLine &= AdvantageFramework.StringUtilities.PadWithCharacter(CoreMediaCheckExport.LinkID, 8, " ", True)
                                    ExportDataLine &= AdvantageFramework.StringUtilities.PadWithCharacter(CoreMediaCheckExport.CheckDate.ToString("yyyyMMdd"), 8, " ", True)
                                    ExportDataLine &= AdvantageFramework.StringUtilities.PadWithCharacter(FormatNumber(CoreMediaCheckExport.CheckAmount.GetValueOrDefault(0), 2), 10, " ", True)
                                    ExportDataLine &= AdvantageFramework.StringUtilities.PadWithCharacter(CoreMediaCheckExport.InvoiceNumber, 12, " ", True)
                                    ExportDataLine &= AdvantageFramework.StringUtilities.PadWithCharacter(CoreMediaCheckExport.InvoiceDate.ToString("yyyyMMdd"), 8, " ", True)

                                    StringBuilder.AppendLine(ExportDataLine)

                                    WriteToEventLog("wrote check line --> " & ExportDataLine)

                                Next

                                WriteToEventLog("creating file...")

                                My.Computer.FileSystem.WriteAllText(AdvantageFramework.StringUtilities.AppendTrailingCharacter(ExportFolder, "\") & "CoreMediaCheckExport_" & Now.ToString("yyyyMMddHHmmss") & ".txt", StringBuilder.ToString, False)

                                WriteToEventLog("file created...")

                            Else

                                WriteToEventLog("directory does not exist" & ExportFolder)

                            End If

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
            Dim NextRunAt As DateTime = Nothing

            If DatabaseProfile IsNot Nothing Then

                Try

                    Using DataContext = New AdvantageFramework.Database.DataContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                        AdvantageService = LoadAdvantageService(DataContext)

                        If AdvantageService IsNot Nothing Then

                            If AdvantageService.Enabled Then

                                DateTime.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.CoreMediaCheckExport.RegistrySetting.RunAt), RunAt)
                                DateTime.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.CoreMediaCheckExport.RegistrySetting.NextRunAt), NextRunAt)

                                If NextRunAt = CDate("01/01/2001 01:00 AM") Then

                                    NextRunAt = Now.ToShortDateString & " " & RunAt.ToShortTimeString

                                End If

                                If DateDiff(DateInterval.Minute, NextRunAt, Now) >= 0 Then

                                    NextRunAt = Now.AddDays(1).ToShortDateString & " " & RunAt.ToShortTimeString

                                    SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.CoreMediaCheckExport.RegistrySetting.RunAt, RunAt)
                                    SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.CoreMediaCheckExport.RegistrySetting.NextRunAt, NextRunAt)

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

            If System.Diagnostics.EventLog.SourceExists("CMCExport Source") = False Then

                System.Diagnostics.EventLog.CreateEventSource("CMCExport Source", "CMCExport Log")

            End If

            _EventLog = New System.Diagnostics.EventLog("CMCExport Log", My.Computer.Name, "CMCExport Source")

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

                AdvantageService = AdvantageFramework.Services.LoadAdvantageService(DataContext, AdvantageFramework.Services.Service.AdvantageCoreMediaCheckExportWindowsService)

            Catch ex As Exception
                AdvantageService = Nothing
            End Try

            LoadAdvantageService = AdvantageService

        End Function
        Public Function LoadAdvantageServiceSetting(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AdvantageServiceID As Integer, ByVal RegistrySetting As AdvantageFramework.Services.CoreMediaCheckExport.RegistrySetting) As AdvantageFramework.Database.Entities.AdvantageServiceSetting

            'objects
            Dim AdvantageServiceSetting As AdvantageFramework.Database.Entities.AdvantageServiceSetting = Nothing

            Try

                AdvantageServiceSetting = AdvantageFramework.Services.LoadAdvantageServiceSetting(DataContext, AdvantageServiceID, RegistrySetting.ToString)

            Catch ex As Exception
                AdvantageServiceSetting = Nothing
            End Try

            LoadAdvantageServiceSetting = AdvantageServiceSetting

        End Function
        Public Function LoadAdvantageServiceSettingValue(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AdvantageServiceID As Integer, ByVal RegistrySetting As AdvantageFramework.Services.CoreMediaCheckExport.RegistrySetting) As Object

            'objects
            Dim SettingValue As Object = Nothing

            Try

                SettingValue = AdvantageFramework.Services.LoadAdvantageServiceSettingValue(DataContext, AdvantageServiceID, RegistrySetting.ToString)

            Catch ex As Exception
                SettingValue = Nothing
            End Try

            LoadAdvantageServiceSettingValue = SettingValue

        End Function
        Public Function SaveAdvantageServiceSettingValue(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AdvantageServiceID As Integer, ByVal RegistrySetting As AdvantageFramework.Services.CoreMediaCheckExport.RegistrySetting, ByVal SettingValue As Object) As Boolean

            'objects
            Dim Saved As Boolean = False

            Try

                Saved = AdvantageFramework.Services.SaveAdvantageServiceSettingValue(DataContext, AdvantageServiceID, RegistrySetting.ToString, SettingValue)

            Catch ex As Exception
                Saved = False
            End Try

            SaveAdvantageServiceSettingValue = Saved

        End Function
        Public Sub LoadSettings(ByVal DataContext As AdvantageFramework.Database.DataContext, ByRef RunAt As Date, ByRef ExportPath As String, Optional ByRef NextRunAt As DateTime = Nothing)

            'objects
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing

            AdvantageService = LoadAdvantageService(DataContext)

            If AdvantageService IsNot Nothing Then

                DateTime.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.CoreMediaCheckExport.RegistrySetting.RunAt), RunAt)

                ExportPath = LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.CoreMediaCheckExport.RegistrySetting.ExportPath)

                DateTime.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.CoreMediaCheckExport.RegistrySetting.NextRunAt), NextRunAt)

            End If

        End Sub
        Public Sub SaveSettings(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal RunAt As DateTime, ByVal ExportPath As String, Optional ByRef NextRunAt As DateTime = Nothing)

            'objects
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing
            'Dim PreviousExportRunAt As DateTime
            'Dim PreviousExportPath As String = ""
            'Dim ServiceController As System.ServiceProcess.ServiceController = Nothing
            'Dim ServiceReloadSettings As Boolean = False

            AdvantageService = LoadAdvantageService(DataContext)

            If AdvantageService IsNot Nothing Then

                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.CoreMediaCheckExport.RegistrySetting.RunAt, RunAt)
                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.CoreMediaCheckExport.RegistrySetting.ExportPath, ExportPath)

                If NextRunAt <> Nothing Then

                    SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.CoreMediaCheckExport.RegistrySetting.NextRunAt, NextRunAt)

                End If

            End If

            'DateTime.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.CoreMediaCheckExport.RegistrySetting.RunAt), PreviousExportRunAt)

            'If PreviousExportRunAt <> RunAt Then

            '    SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.CoreMediaCheckExport.RegistrySetting.RunAt, RunAt)
            '    ServiceReloadSettings = True

            'End If

            'PreviousExportPath = LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.CoreMediaCheckExport.RegistrySetting.ExportPath)

            'If PreviousExportPath <> ExportPath Then

            '    SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.CoreMediaCheckExport.RegistrySetting.ExportPath, ExportPath)
            '    ServiceReloadSettings = True

            'End If

            'If NextRunAt <> Nothing Then

            '    SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.CoreMediaCheckExport.RegistrySetting.NextRunAt, NextRunAt)

            'End If

            'If ServiceReloadSettings Then

            '    ServiceController = AdvantageFramework.Services.Load(AdvantageFramework.Services.Service.AdvantageCoreMediaCheckExportWindowsService)

            '    If ServiceController IsNot Nothing AndAlso ServiceController.Status = ServiceProcess.ServiceControllerStatus.Running Then

            '        ServiceController.ExecuteCommand(AdvantageFramework.Services.CoreMediaCheckExport.CustomCommand.LoadSettings)

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

