Namespace Services.JobCompUDFImport

    <HideModuleName()> _
    Public Module Methods

        Public Event EntryLogWrittenEvent(ByVal EventLogEntry As System.Diagnostics.EventLogEntry)

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum RegistrySetting
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\JobComp UDF Import\", "RunAt", "01/01/2001 01:00 AM")> _
            RunAt
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\JobComp UDF Import\", "ImportPath", "C:\")> _
            ImportPath
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\JobComp UDF Import\", "NextRunAt", "01/01/2001 01:00 AM")> _
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
            Dim ImportFolder As String = ""
            Dim FileLineData() As String = Nothing
            Dim WBSUserDefinedType As AdvantageFramework.Database.Entities.UserDefinedType = Nothing
            Dim JobComponentUserDefinedValue1 As AdvantageFramework.Database.Entities.JobComponentUserDefinedValue1 = Nothing
            Dim WBSUserDefinedTypeValue As AdvantageFramework.Database.Entities.UserDefinedTypeValue = Nothing
            Dim JobComponentUserDefinedValue1s As Generic.List(Of AdvantageFramework.Database.Entities.JobComponentUserDefinedValue1) = Nothing
            Dim WBSUserDefinedTypeValues As Generic.List(Of AdvantageFramework.Database.Entities.UserDefinedTypeValue) = Nothing
            Dim TextFieldParser As FileIO.TextFieldParser = Nothing
            Dim IsCostCenterCode As Boolean = False
            Dim Code As String = ""
            Dim Description As String = ""
            Dim IsValid As Boolean = True
            Dim HasUpdateException As Boolean = False
            Dim UpdateException As System.Data.Entity.Core.UpdateException = Nothing
            Dim JobComponentUserDefinedValueCodeMaxLength As Integer = 0
            Dim JobComponentUserDefinedValueDescriptionMaxLength As Integer = 0

            Try

                If DatabaseProfile IsNot Nothing Then

                    WriteToEventLog("Connecting to database --> " & DatabaseProfile.DatabaseName)

                    Using DataContext = New AdvantageFramework.Database.DataContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                        Using DbContext = New AdvantageFramework.Database.DbContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                                WriteToEventLog("Load service settings --> " & DatabaseProfile.DatabaseName)

                                AdvantageFramework.Services.JobCompUDFImport.LoadSettings(DataContext, RunAtTime, ImportFolder)

                                If My.Computer.FileSystem.DirectoryExists(ImportFolder) Then

                                    JobComponentUserDefinedValueCodeMaxLength = AdvantageFramework.BaseClasses.Entity.LoadPropertyMaxLength(AdvantageFramework.BaseClasses.Entity.LoadProperty(AdvantageFramework.Database.Entities.JobComponentUserDefinedValue1.Properties.Code))
                                    JobComponentUserDefinedValueDescriptionMaxLength = AdvantageFramework.BaseClasses.Entity.LoadPropertyMaxLength(AdvantageFramework.BaseClasses.Entity.LoadProperty(AdvantageFramework.Database.Entities.JobComponentUserDefinedValue1.Properties.Description))

                                    Try

                                        WBSUserDefinedType = AdvantageFramework.Database.Procedures.UserDefinedType.Load(DbContext).Where(Function(Entity) Entity.Name = "WBS Element").SingleOrDefault

                                    Catch ex As Exception
                                        WBSUserDefinedType = Nothing
                                    End Try

                                    If WBSUserDefinedType Is Nothing Then

                                        WBSUserDefinedType = New AdvantageFramework.Database.Entities.UserDefinedType

                                        WBSUserDefinedType.DbContext = DbContext
                                        WBSUserDefinedType.Name = "WBS Element"
                                        WBSUserDefinedType.Description = "Kholer WBS Element Codes"
                                        WBSUserDefinedType.Enabled = True

                                        AdvantageFramework.Database.Procedures.UserDefinedType.Insert(DbContext, WBSUserDefinedType)

                                    End If

                                    Try

                                        DbContext.Database.ExecuteSqlCommand("UPDATE dbo.JOB_CMP_UDV1 SET INACTIVE_FLAG = 1")
                                        DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.USER_DEF_TYPE_VALUE SET [ENABLED] = 0 WHERE USER_DEF_TYPE_ID = {0}", WBSUserDefinedType.ID))

                                    Catch ex As Exception
                                        WriteToEventLog("failed saving inactive entries --> " & ex.Message)
                                    End Try

                                    JobComponentUserDefinedValue1s = AdvantageFramework.Database.Procedures.JobComponentUserDefinedValue1.Load(DbContext).ToList
                                    WBSUserDefinedTypeValues = AdvantageFramework.Database.Procedures.UserDefinedTypeValue.Load(DbContext).Where(Function(Entity) Entity.UserDefinedTypeID = WBSUserDefinedType.ID).ToList

                                    WriteToEventLog("loading import data files...")

                                    For Each FileInfo In My.Computer.FileSystem.GetDirectoryInfo(ImportFolder).GetFiles("*.txt").Select(Function(FileInfoObject) New With {.Name = FileInfoObject.Name, .FullName = FileInfoObject.FullName}).ToList

                                        WriteToEventLog("processing file --> " & FileInfo.Name)

                                        TextFieldParser = New FileIO.TextFieldParser(FileInfo.FullName)

                                        TextFieldParser.TextFieldType = FileIO.FieldType.Delimited
                                        TextFieldParser.Delimiters = New String() {"|"}
                                        TextFieldParser.HasFieldsEnclosedInQuotes = False

                                        Do While Not TextFieldParser.EndOfData

                                            IsCostCenterCode = False
                                            Code = ""
                                            Description = ""
                                            IsValid = True
                                            JobComponentUserDefinedValue1 = Nothing
                                            WBSUserDefinedTypeValue = Nothing

                                            Try

                                                FileLineData = TextFieldParser.ReadFields

                                                If FileLineData.Count > 2 Then

                                                    'WriteToEventLog("processing line --> " & Join(FileLineData, "|"))

                                                    Try

                                                        IsCostCenterCode = If(FileLineData(3).ToUpper = "Cost Centers".ToUpper, True, False)

                                                    Catch ex As Exception
                                                        IsCostCenterCode = False
                                                    End Try

                                                    Try

                                                        Code = FileLineData(4)

                                                    Catch ex As Exception
                                                        Code = ""
                                                    End Try

                                                    Try

                                                        Description = FileLineData(4) & "|" & FileLineData(2) & "|" & FileLineData(12)

                                                    Catch ex As Exception
                                                        Description = ""
                                                    End Try

                                                    If String.IsNullOrEmpty(Code) = False Then

                                                        Code = Code.Trim

                                                        If IsCostCenterCode Then

                                                            If String.IsNullOrEmpty(Code) = False AndAlso Code.Length > JobComponentUserDefinedValueCodeMaxLength Then

                                                                Code = Left(Code, JobComponentUserDefinedValueCodeMaxLength)

                                                            End If

                                                            If String.IsNullOrEmpty(Description) = False AndAlso Description.Length > JobComponentUserDefinedValueDescriptionMaxLength Then

                                                                Description = Left(Description, JobComponentUserDefinedValueDescriptionMaxLength)

                                                            End If

                                                            Try

                                                                JobComponentUserDefinedValue1 = JobComponentUserDefinedValue1s.SingleOrDefault(Function(Entity) Entity.Code = Code)

                                                            Catch ex As Exception
                                                                JobComponentUserDefinedValue1 = Nothing
                                                            End Try

                                                            If JobComponentUserDefinedValue1 Is Nothing Then

                                                                JobComponentUserDefinedValue1 = New AdvantageFramework.Database.Entities.JobComponentUserDefinedValue1

                                                                JobComponentUserDefinedValue1.DbContext = DbContext
                                                                JobComponentUserDefinedValue1.Code = Code
                                                                JobComponentUserDefinedValue1.Description = Description
                                                                JobComponentUserDefinedValue1.IsInactive = Nothing

                                                                Try

                                                                    JobComponentUserDefinedValue1.ValidateEntity(IsValid)

                                                                    If IsValid Then

                                                                        DbContext.JobComponentUserDefinedValue1.Add(JobComponentUserDefinedValue1)

                                                                        JobComponentUserDefinedValue1s.Add(JobComponentUserDefinedValue1)

                                                                    End If

                                                                Catch ex As Exception
                                                                    WriteToEventLog("failed saving UDF values " & ex.Message)
                                                                End Try

                                                            Else

                                                                DbContext.UpdateObject(JobComponentUserDefinedValue1)

                                                                JobComponentUserDefinedValue1.Description = Description
                                                                JobComponentUserDefinedValue1.IsInactive = Nothing

                                                            End If

                                                        Else

                                                            Try

                                                                WBSUserDefinedTypeValue = WBSUserDefinedTypeValues.SingleOrDefault(Function(Entity) Entity.Code = Code)

                                                            Catch ex As Exception
                                                                WBSUserDefinedTypeValue = Nothing
                                                            End Try

                                                            If WBSUserDefinedTypeValue Is Nothing Then

                                                                WBSUserDefinedTypeValue = New AdvantageFramework.Database.Entities.UserDefinedTypeValue

                                                                WBSUserDefinedTypeValue.DbContext = DbContext
                                                                WBSUserDefinedTypeValue.UserDefinedTypeID = WBSUserDefinedType.ID
                                                                WBSUserDefinedTypeValue.Code = Code
                                                                WBSUserDefinedTypeValue.Description = Description
                                                                WBSUserDefinedTypeValue.Enabled = True

                                                                Try

                                                                    WBSUserDefinedTypeValue.ValidateEntity(IsValid)

                                                                    If IsValid Then

                                                                        DbContext.UserDefinedTypeValues.Add(WBSUserDefinedTypeValue)

                                                                        WBSUserDefinedTypeValues.Add(WBSUserDefinedTypeValue)

                                                                    End If

                                                                Catch ex As Exception
                                                                    WriteToEventLog("failed saving UDF values " & ex.Message)
                                                                End Try

                                                                'If AdvantageFramework.Database.Procedures.WBSUserDefinedTypeValue.Insert(DbContext, WBSUserDefinedTypeValue) Then

                                                                '    'WriteToEventLog("processing wbs line successful! " & Code & " - " & Description)

                                                                'Else

                                                                '    ' WriteToEventLog("cannot process line --> failed inserting wbs value")

                                                                'End If

                                                            Else

                                                                DbContext.UpdateObject(WBSUserDefinedTypeValue)

                                                                WBSUserDefinedTypeValue.Enabled = True

                                                                'WriteToEventLog("cannot process line --> wbs value already exists")

                                                            End If

                                                        End If

                                                        Try

                                                            DbContext.SaveChanges()

                                                        Catch ex As System.Data.Entity.Core.UpdateException

                                                            WriteToEventLog("failed saving UDF values " & ex.Message)

                                                            UpdateException = ex
                                                            HasUpdateException = True

                                                            While HasUpdateException

                                                                For Each ObjectStateEntry In UpdateException.StateEntries

                                                                    DbContext.Detach(ObjectStateEntry.Entity)

                                                                    Try

                                                                        DbContext.SaveChanges()

                                                                        HasUpdateException = False

                                                                    Catch upex As System.Data.Entity.Core.UpdateException
                                                                        UpdateException = upex
                                                                        HasUpdateException = True
                                                                    Catch ex2 As Exception

                                                                    End Try

                                                                Next

                                                            End While

                                                        End Try

                                                    End If

                                                End If

                                            Catch ex As Exception

                                            End Try

                                        Loop

                                        Try

                                            TextFieldParser.Close()
                                            TextFieldParser.Dispose()

                                        Catch ex As Exception

                                        End Try

                                        Try

                                            My.Computer.FileSystem.RenameFile(FileInfo.FullName, FileInfo.Name.Replace(".txt", ".old"))

                                        Catch ex As Exception

                                        End Try

                                    Next

                                    Try

                                        DbContext.Database.ExecuteSqlCommand("EXEC [dbo].[advsp_user_def_value_update_job_comp_udv] " & WBSUserDefinedType.ID & ", 2")

                                    Catch ex As Exception

                                    End Try

                                    WriteToEventLog("import data files complete...")

                                Else

                                    WriteToEventLog("directory does not exist" & ImportFolder)

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
            Dim NextRunAt As DateTime = Nothing

            If DatabaseProfile IsNot Nothing Then

                Try

                    Using DataContext = New AdvantageFramework.Database.DataContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                        AdvantageService = LoadAdvantageService(DataContext)

                        If AdvantageService IsNot Nothing Then

                            If AdvantageService.Enabled Then

                                DateTime.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.JobCompUDFImport.RegistrySetting.RunAt), RunAt)
                                DateTime.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.JobCompUDFImport.RegistrySetting.NextRunAt), NextRunAt)

                                If NextRunAt = CDate("01/01/2001 01:00 AM") Then

                                    NextRunAt = Now.ToShortDateString & " " & RunAt.ToShortTimeString

                                End If

                                If DateDiff(DateInterval.Minute, NextRunAt, Now) >= 0 Then

                                    NextRunAt = Now.AddDays(1).ToShortDateString & " " & RunAt.ToShortTimeString

                                    SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.JobCompUDFImport.RegistrySetting.RunAt, RunAt)
                                    SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.JobCompUDFImport.RegistrySetting.NextRunAt, NextRunAt)

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

            If System.Diagnostics.EventLog.SourceExists("Adv JCUDFImport Source") = False Then

                System.Diagnostics.EventLog.CreateEventSource("Adv JCUDFImport Source", "Adv JCUDFImport Log")

            End If

            _EventLog = New System.Diagnostics.EventLog("Adv JCUDFImport Log", My.Computer.Name, "Adv JCUDFImport Source")

            _EventLog.ModifyOverflowPolicy(System.Diagnostics.OverflowAction.OverwriteAsNeeded, _EventLog.MinimumRetentionDays)

            _EventLog.EnableRaisingEvents = True

            If LoadEntries Then

                For Each Entry In _EventLog.Entries.OfType(Of System.Diagnostics.EventLogEntry).OrderByDescending(Function(EventLogEntry) EventLogEntry.TimeGenerated)

                    Log &= vbCrLf & Entry.TimeGenerated & " - " & Entry.Message & "...."

                Next

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

                AdvantageService = AdvantageFramework.Services.LoadAdvantageService(DataContext, AdvantageFramework.Services.Service.AdvantageJobCompUDFImportWindowsService)

            Catch ex As Exception
                AdvantageService = Nothing
            End Try

            LoadAdvantageService = AdvantageService

        End Function
        Public Function LoadAdvantageServiceSetting(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AdvantageServiceID As Integer, ByVal RegistrySetting As AdvantageFramework.Services.JobCompUDFImport.RegistrySetting) As AdvantageFramework.Database.Entities.AdvantageServiceSetting

            'objects
            Dim AdvantageServiceSetting As AdvantageFramework.Database.Entities.AdvantageServiceSetting = Nothing

            Try

                AdvantageServiceSetting = AdvantageFramework.Services.LoadAdvantageServiceSetting(DataContext, AdvantageServiceID, RegistrySetting.ToString)

            Catch ex As Exception
                AdvantageServiceSetting = Nothing
            End Try

            LoadAdvantageServiceSetting = AdvantageServiceSetting

        End Function
        Public Function LoadAdvantageServiceSettingValue(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AdvantageServiceID As Integer, ByVal RegistrySetting As AdvantageFramework.Services.JobCompUDFImport.RegistrySetting) As Object

            'objects
            Dim SettingValue As Object = Nothing

            Try

                SettingValue = AdvantageFramework.Services.LoadAdvantageServiceSettingValue(DataContext, AdvantageServiceID, RegistrySetting.ToString)

            Catch ex As Exception
                SettingValue = Nothing
            End Try

            LoadAdvantageServiceSettingValue = SettingValue

        End Function
        Public Function SaveAdvantageServiceSettingValue(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AdvantageServiceID As Integer, ByVal RegistrySetting As AdvantageFramework.Services.JobCompUDFImport.RegistrySetting, ByVal SettingValue As Object) As Boolean

            'objects
            Dim Saved As Boolean = False

            Try

                Saved = AdvantageFramework.Services.SaveAdvantageServiceSettingValue(DataContext, AdvantageServiceID, RegistrySetting.ToString, SettingValue)

            Catch ex As Exception
                Saved = False
            End Try

            SaveAdvantageServiceSettingValue = Saved

        End Function
        Public Sub LoadSettings(ByVal DataContext As AdvantageFramework.Database.DataContext, ByRef RunAt As Date, ByRef ImportPath As String, Optional ByRef NextRunAt As DateTime = Nothing)

            'objects
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing

            AdvantageService = LoadAdvantageService(DataContext)

            If AdvantageService IsNot Nothing Then

                DateTime.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.JobCompUDFImport.RegistrySetting.RunAt), RunAt)

                ImportPath = LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.JobCompUDFImport.RegistrySetting.ImportPath)

                DateTime.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.JobCompUDFImport.RegistrySetting.NextRunAt), NextRunAt)

            End If

        End Sub
        Public Sub SaveSettings(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal RunAt As DateTime, ByVal ImportPath As String, Optional ByRef NextRunAt As DateTime = Nothing)

            'objects
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing

            AdvantageService = LoadAdvantageService(DataContext)

            If AdvantageService IsNot Nothing Then

                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.JobCompUDFImport.RegistrySetting.RunAt, RunAt)

                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.JobCompUDFImport.RegistrySetting.ImportPath, ImportPath)

                If NextRunAt <> Nothing Then

                    SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.JobCompUDFImport.RegistrySetting.NextRunAt, NextRunAt)

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

