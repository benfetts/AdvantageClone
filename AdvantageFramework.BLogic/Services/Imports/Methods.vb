Namespace Services.Imports

    <HideModuleName()> _
    Public Module Methods

        Public Event EntryLogWrittenEvent(ByVal EventLogEntry As System.Diagnostics.EventLogEntry)

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum RegistrySetting
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\Imports\", "LastRanAt", "01/01/2001 01:00 AM")> _
            LastRanAt
        End Enum

        Public Enum CustomCommand As Integer
            LoadSettings = 128
        End Enum

        Public Enum ImportSettings
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("Enabled", "Enabled")>
            Enabled
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("AutoTrimOverflowData", "Auto Trim Overflow Data")>
            AutoTrimOverflowData
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("FirstLineContainsColumnHeaders", "First Line Contains Column Headers")>
            FirstLineContainsColumnHeaders
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("OverrideDefaultDirectory", "Override Default Directory")>
            OverrideDefaultDirectory
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("OverridePath", "Override Path")>
            OverridePath
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("EmployeeCode", "Employee Code")>
            EmployeeCode
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
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing
            Dim AdvantageServiceImportList As Generic.List(Of AdvantageFramework.Database.Entities.AdvantageServiceImport) = Nothing
            Dim ImportSetting As AdvantageFramework.Services.Imports.Classes.ImportSetting = Nothing
            Dim FileFilter As FileSystem.FileFilters = Nothing
            Dim Directory As String = Nothing
            Dim Session As AdvantageFramework.Security.Session = Nothing
            Dim Imported As Boolean = False
            Dim BatchName As String = Nothing
            Dim FailedLines As Generic.Dictionary(Of Integer, String) = Nothing
            Dim FileInfoList As Generic.List(Of System.IO.FileInfo) = Nothing
            Dim FileList() As String = Nothing
            Dim FilesInUse As String = Nothing
            Dim ResultMessage As String = Nothing
            Dim EmailResultMessage As String = Nothing
            Dim PDFFileInfoList As Generic.List(Of System.IO.FileInfo) = Nothing

            Try

                If DatabaseProfile IsNot Nothing Then

                    WriteToEventLog("Connecting to database --> " & DatabaseProfile.DatabaseName)

                    Using DataContext = New AdvantageFramework.Database.DataContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                        Using DbContext = New AdvantageFramework.Database.DbContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                                WriteToEventLog("Load service settings --> " & DatabaseProfile.DatabaseName)

                                AdvantageService = LoadAdvantageService(DataContext)

                                If AdvantageService IsNot Nothing Then

                                    WriteToEventLog("Load service import template list --> " & DatabaseProfile.DatabaseName)

                                    AdvantageServiceImportList = AdvantageFramework.Database.Procedures.AdvantageServiceImport.Load(DbContext).Include("ImportTemplate").ToList

                                    For Each AdvantageServiceImport In AdvantageServiceImportList

                                        ImportSetting = New AdvantageFramework.Services.Imports.Classes.ImportSetting(AdvantageServiceImport.ID, DataContext)

                                        If ImportSetting.Enabled AndAlso AdvantageServiceImport.ImportTemplate IsNot Nothing Then

                                            Session = New AdvantageFramework.Security.Session(Security.Application.Advantage, DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName, 0, DatabaseProfile.ConnectionString)

                                            FileFilter = AdvantageFramework.Importing.SetFileFilterByImportTemplate(AdvantageServiceImport.ImportTemplate)

                                            If ImportSetting.OverrideDefaultDirectory AndAlso ImportSetting.OverridePath IsNot Nothing Then

                                                Directory = ImportSetting.OverridePath

                                            Else

                                                Directory = AdvantageServiceImport.ImportTemplate.DefaultDirectory

                                            End If

                                            If Directory IsNot Nothing Then

                                                FilesInUse = Nothing

                                                FileInfoList = AdvantageFramework.Importing.GetImportFileList(Directory, FileFilter, FilesInUse)

                                                If FilesInUse IsNot Nothing Then

                                                    WriteToEventLog("One or more files are in use, please close and retry --> " & FilesInUse)

                                                Else

                                                    If AdvantageServiceImport.ImportTemplate.Type = AdvantageFramework.Importing.ImportTemplateTypes.AccountsPayable_StrataFixedPrint Then

                                                        FileInfoList = FileInfoList.Where(Function(F) Mid(F.Name.ToString.ToUpper, 1, 3) <> "INT").ToList

                                                    ElseIf AdvantageServiceImport.ImportTemplate.Type = AdvantageFramework.Importing.ImportTemplateTypes.AccountsPayable_StrataFixedInternet Then

                                                        FileInfoList = FileInfoList.Where(Function(F) Mid(F.Name.ToString.ToUpper, 1, 3) = "INT").ToList

                                                    ElseIf AdvantageServiceImport.ImportTemplate.Type = AdvantageFramework.Importing.ImportTemplateTypes.AccountsPayable_Generic Then

                                                        FileInfoList = FileInfoList.Where(Function(F) Mid(F.Name.ToString.ToUpper, 1, 6) <> "BC_ORD").ToList
                                                        FileInfoList = FileInfoList.Where(Function(F) Mid(F.Name.ToString.ToUpper, 1, 8) <> "MAGAZINE").ToList
                                                        FileInfoList = FileInfoList.Where(Function(F) Mid(F.Name.ToString.ToUpper, 1, 9) <> "NEWSPAPER").ToList
                                                        FileInfoList = FileInfoList.Where(Function(F) Mid(F.Name.ToString.ToUpper, 1, 7) <> "OUTDOOR").ToList
                                                        FileInfoList = FileInfoList.Where(Function(F) Mid(F.Name.ToString.ToUpper, 1, 8) <> "INTERNET").ToList

                                                    ElseIf AdvantageServiceImport.ImportTemplate.Type = AdvantageFramework.Importing.ImportTemplateTypes.DigitalResults_Default AndAlso
                                                            AdvantageServiceImport.ImportTemplate.IsSystemTemplate AndAlso AdvantageServiceImport.ImportTemplate.Name = "Advantage DoubleClick Results" Then


                                                    ElseIf AdvantageServiceImport.ImportTemplate.Type = AdvantageFramework.Importing.ImportTemplateTypes.AccountsPayable_4AsBroadcast Then

                                                        If FileInfoList IsNot Nothing AndAlso FileInfoList.Count > 0 Then

                                                            PDFFileInfoList = AdvantageFramework.Importing.GetImportFileList(Directory, FileSystem.Methods.FileFilters.PDF, FilesInUse)

                                                            If PDFFileInfoList IsNot Nothing AndAlso PDFFileInfoList.Count > 0 Then

                                                                PDFFileInfoList = (From PDFFile In PDFFileInfoList
                                                                                   Where FileInfoList.Select(Function(f) f.Name).ToList.Contains(System.IO.Path.GetFileNameWithoutExtension(PDFFile.Name))
                                                                                   Select PDFFile).ToList

                                                                If PDFFileInfoList IsNot Nothing AndAlso PDFFileInfoList.Count > 0 Then

                                                                    FileInfoList.AddRange(PDFFileInfoList)

                                                                End If

                                                            End If

                                                        End If

                                                    End If

                                                    FileList = (From File In FileInfoList
                                                                Select File.FullName).ToArray

                                                    If FileList.Count > 0 Then

                                                        WriteToEventLog("Importing file list --> " & String.Join(",", FileList))

                                                        BatchName = Nothing

                                                        Imported = AdvantageFramework.Importing.ImportFileByImportTemplate(Session, AdvantageServiceImport.ImportTemplateID, FileList,
                                                                                                                           ImportSetting.AutoTrimOverflowData, ImportSetting.FirstLineContainsColumnHeaders,
                                                                                                                           Nothing, BatchName, FailedLines, _EventLog)

                                                        If Imported Then

                                                            If FailedLines IsNot Nothing AndAlso FailedLines.Count > 0 Then

                                                                ResultMessage = "Importing File(s) Completed but with errors.  BatchName " & BatchName

                                                            Else

                                                                ResultMessage = "Importing File(s) Completed.  BatchName " & BatchName

                                                            End If

                                                        Else

                                                            ResultMessage = "Importing File(s) Failed. --> " & String.Join(",", FileList)

                                                        End If

                                                        WriteToEventLog(ResultMessage)

                                                        If ImportSetting.EmployeeCode IsNot Nothing Then

                                                            AdvantageFramework.AlertSystem.CreateAlertForImportTemplateResult(DatabaseProfile, SecurityDbContext, ImportSetting.EmployeeCode, AdvantageServiceImport.ImportTemplate, ResultMessage, EmailResultMessage)

                                                            If EmailResultMessage IsNot Nothing Then

                                                                WriteToEventLog(EmailResultMessage)

                                                            End If

                                                        End If

                                                    Else

                                                        WriteToEventLog("No files to import.")

                                                    End If

                                                End If

                                            Else

                                                WriteToEventLog("No directory specified for template --> " & AdvantageServiceImport.ImportTemplate.Name)

                                            End If

                                        End If

                                    Next

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
            Dim LastRanAt As Date = Nothing

            If DatabaseProfile IsNot Nothing Then

                Try

                    Using DataContext = New AdvantageFramework.Database.DataContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                        AdvantageService = LoadAdvantageService(DataContext)

                        If AdvantageService IsNot Nothing Then

                            If AdvantageService.Enabled Then
                                
                                DateTime.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.Imports.RegistrySetting.LastRanAt), LastRanAt)

                                LastRanAt = LastRanAt.AddMinutes(5)

                                If DateDiff(DateInterval.Minute, LastRanAt, Now) >= 0 Then

                                    LastRanAt = Now

                                    SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.Imports.RegistrySetting.LastRanAt, LastRanAt)

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

            If System.Diagnostics.EventLog.SourceExists("Adv Imports Source") = False Then

                System.Diagnostics.EventLog.CreateEventSource("Adv Imports Source", "Adv Imports Log")

            End If

            _EventLog = New System.Diagnostics.EventLog("Adv Imports Log", My.Computer.Name, "Adv Imports Source")

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

                AdvantageService = AdvantageFramework.Services.LoadAdvantageService(DataContext, AdvantageFramework.Services.Service.AdvantageImportTemplateWindowsService)

            Catch ex As Exception
                AdvantageService = Nothing
            End Try

            LoadAdvantageService = AdvantageService

        End Function
        Public Function LoadAdvantageServiceSetting(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AdvantageServiceID As Integer, ByVal RegistrySetting As AdvantageFramework.Services.Imports.RegistrySetting) As AdvantageFramework.Database.Entities.AdvantageServiceSetting

            'objects
            Dim AdvantageServiceSetting As AdvantageFramework.Database.Entities.AdvantageServiceSetting = Nothing

            Try

                AdvantageServiceSetting = AdvantageFramework.Services.LoadAdvantageServiceSetting(DataContext, AdvantageServiceID, RegistrySetting.ToString)

            Catch ex As Exception
                AdvantageServiceSetting = Nothing
            End Try

            LoadAdvantageServiceSetting = AdvantageServiceSetting

        End Function
        Public Function LoadAdvantageServiceSettingValue(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AdvantageServiceID As Integer, ByVal RegistrySetting As AdvantageFramework.Services.Imports.RegistrySetting) As Object

            'objects
            Dim SettingValue As Object = Nothing

            Try

                SettingValue = AdvantageFramework.Services.LoadAdvantageServiceSettingValue(DataContext, AdvantageServiceID, RegistrySetting.ToString)

            Catch ex As Exception
                SettingValue = Nothing
            End Try

            LoadAdvantageServiceSettingValue = SettingValue

        End Function
        Public Function SaveAdvantageServiceSettingValue(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AdvantageServiceID As Integer, ByVal RegistrySetting As AdvantageFramework.Services.Imports.RegistrySetting, ByVal SettingValue As Object) As Boolean

            'objects
            Dim Saved As Boolean = False

            Try

                Saved = AdvantageFramework.Services.SaveAdvantageServiceSettingValue(DataContext, AdvantageServiceID, RegistrySetting.ToString, SettingValue)

            Catch ex As Exception
                Saved = False
            End Try

            SaveAdvantageServiceSettingValue = Saved

        End Function
        Public Sub LoadSettings(ByVal DataContext As AdvantageFramework.Database.DataContext, Optional ByRef LastRanAt As Date = Nothing)

            'objects
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing

            AdvantageService = LoadAdvantageService(DataContext)

            If AdvantageService IsNot Nothing Then

                DateTime.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.Imports.RegistrySetting.LastRanAt), LastRanAt)

            End If

        End Sub
        Public Sub SaveSettings(ByVal DataContext As AdvantageFramework.Database.DataContext)

            'objects
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing

            AdvantageService = LoadAdvantageService(DataContext)

            If AdvantageService IsNot Nothing Then

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

