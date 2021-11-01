Namespace Services.Exports

    <HideModuleName()>
    Public Module Methods

        Public Event EntryLogWrittenEvent(ByVal EventLogEntry As System.Diagnostics.EventLogEntry)

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum RegistrySetting
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\Export Template\", "RunAt", "01/01/2001 01:00 AM")>
            LastRanAtRunAt
        End Enum

        Public Enum CustomCommand As Integer
            LoadSettings = 128
        End Enum

        Public Enum ExportSettings
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("Enabled", "Enabled")>
            Enabled
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("RunAt", "Run At")>
            RunAt
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("ExportPath", "Export Path")>
            ExportPath
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("JobNumberPrependText", "Job Number Prepend Text")>
            JobNumberPrependText
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("NonJobCode", "Non-Job Code")>
            NonJobCode
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("ChangeAfter", "Change After (Days)")>
            ChangeAfter
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("NumberOfDaysOldCutoff", "Number of Days Old Cutoff")>
            NumberOfDaysOldCutoff
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("NextRunAt", "Next Run At")>
            NextRunAt
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CurrentProcessControl", "Current Process Control")>
            CurrentProcessControl
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CurrentProcessControl2", "Current Process Control (Additional)")>
            CurrentProcessControl2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("ChangeToProcessControl", "Change to Process Control")>
            ChangeToProcessControl
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("UseSSLForFTP", "Use SSL")>
            UseSSLForFTP
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("FTPAddress", "FTP Address")>
            FTPAddress
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("FTPPort", "FTP Port")>
            FTPPort
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("FTPFolder", "FTP Folder")>
            FTPFolder
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("FTPUserName", "FTP User Name")>
            FTPUserName
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("FTPPassword", "FTP Password")>
            FTPPassword
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("SSLModeForFTP", "SSL Mode")>
            SSLModeForFTP
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("EmailAddress", "Email Address")>
            EmailAddress
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("ProcessNowTransactionDate", "Process Now Transaction Date")>
            ProcessNowTransactionDate
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
        Public Sub ProcessDatabase(ByVal DatabaseProfile As AdvantageFramework.Database.DatabaseProfile, ByVal AdvantageServiceExport As AdvantageFramework.Database.Entities.AdvantageServiceExport, ProcessNow As Boolean)

            'objects
            Dim AdvantageServiceExportList As Generic.List(Of AdvantageFramework.Database.Entities.AdvantageServiceExport) = Nothing

            AdvantageServiceExportList = New Generic.List(Of AdvantageFramework.Database.Entities.AdvantageServiceExport)

            AdvantageServiceExportList.Add(AdvantageServiceExport)

            ProcessDatabase(DatabaseProfile, AdvantageServiceExportList, ProcessNow)

        End Sub
        Public Sub ProcessDatabase(ByVal DatabaseProfile As AdvantageFramework.Database.DatabaseProfile,
                                   AdvantageServiceExportList As Generic.List(Of AdvantageFramework.Database.Entities.AdvantageServiceExport), ProcessNow As Boolean)

            'objects
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing
            Dim ExportSetting As AdvantageFramework.Services.Exports.Classes.ExportSetting = Nothing
            Dim FileFilter As FileSystem.FileFilters = Nothing
            Dim JobNumberPrependText As String = Nothing
            Dim ExportFolder As String = Nothing
            Dim Session As AdvantageFramework.Security.Session = Nothing
            Dim Imported As Boolean = False
            Dim BatchName As String = Nothing
            Dim FailedLines As Generic.Dictionary(Of Integer, String) = Nothing
            Dim FileInfoList As Generic.List(Of System.IO.FileInfo) = Nothing
            Dim FileList() As String = Nothing
            Dim FilesInUse As String = Nothing
            Dim ResultMessage As String = Nothing
            Dim EmailResultMessage As String = Nothing
            Dim RunAt As DateTime = Nothing
            Dim NonJobCode As String = Nothing
            Dim ChangeAfter As Integer = Nothing
            Dim FileCreated As Boolean = False
            Dim CurrentProcessControl As Short? = Nothing
            Dim CurrentProcessControl2 As Short? = Nothing
            Dim ChangeToProcessControl As Short? = Nothing
            Dim NumberOfDaysOldCutoff As Integer? = Nothing

            Try

                If DatabaseProfile IsNot Nothing Then

                    WriteToEventLog("Connecting to database --> " & DatabaseProfile.DatabaseName)

                    Using DataContext = New AdvantageFramework.Database.DataContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                        Using DbContext = New AdvantageFramework.Database.DbContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                                WriteToEventLog("Load service settings --> " & DatabaseProfile.DatabaseName)

                                Session = New AdvantageFramework.Security.Session(Security.Application.Advantage, DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName, 0, DatabaseProfile.ConnectionString)

                                AdvantageService = LoadAdvantageService(DataContext)

                                If AdvantageService IsNot Nothing Then

                                    WriteToEventLog("Load service export template list --> " & DatabaseProfile.DatabaseName)

                                    For Each AdvantageServiceExport In AdvantageServiceExportList

                                        ExportSetting = New AdvantageFramework.Services.Exports.Classes.ExportSetting(AdvantageServiceExport, DataContext)

                                        If AdvantageServiceExport.ExportTemplate IsNot Nothing Then

                                            If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) Then

                                                ExportFolder = AdvantageFramework.Database.Procedures.Agency.LoadImportPath(DbContext)

                                                ExportFolder = AdvantageFramework.StringUtilities.AppendTrailingCharacter(ExportFolder.Trim, "\") & "Reports\"

                                            ElseIf String.IsNullOrWhiteSpace(ExportSetting.ExportPath) Then

                                                ExportFolder = AdvantageServiceExport.ExportTemplate.DefaultDirectory

                                            Else

                                                ExportFolder = ExportSetting.ExportPath

                                            End If

                                            If String.IsNullOrWhiteSpace(ExportFolder) = False Then

                                                If My.Computer.FileSystem.DirectoryExists(ExportFolder) = False Then

                                                    Try

                                                        My.Computer.FileSystem.CreateDirectory(ExportFolder)

                                                    Catch ex As Exception

                                                    End Try

                                                End If

                                                If My.Computer.FileSystem.DirectoryExists(ExportFolder) Then

                                                    RunAt = Nothing
                                                    JobNumberPrependText = Nothing
                                                    NonJobCode = Nothing
                                                    ChangeAfter = Nothing
                                                    CurrentProcessControl = Nothing
                                                    ChangeToProcessControl = Nothing

                                                    LoadSettings(DataContext, AdvantageServiceExport.ID, RunAt, JobNumberPrependText, NonJobCode, ChangeAfter, CurrentProcessControl, CurrentProcessControl2, ChangeToProcessControl, NumberOfDaysOldCutoff)

                                                    Select Case AdvantageServiceExport.ExportTemplate.Type

                                                        Case AdvantageFramework.Exporting.ExportTypes.Job

                                                            If AdvantageServiceExport.ExportTemplate.IsSystemTemplate = True AndAlso AdvantageServiceExport.ExportTemplate.Name.ToUpper = "Advantage CSV".ToUpper Then

                                                                FileCreated = ProcessDatabase_CustomJob(DbContext, DataContext, ExportFolder, JobNumberPrependText, NumberOfDaysOldCutoff)

                                                            ElseIf AdvantageServiceExport.ExportTemplate.IsSystemTemplate = True AndAlso AdvantageServiceExport.ExportTemplate.Name.ToUpper = "Export Job Info To FTP".ToUpper Then

                                                                FileCreated = ProcessDatabase_CustomJobExportToFTP(DbContext, DataContext, ExportSetting)

                                                            End If

                                                        Case AdvantageFramework.Exporting.ExportTypes.Time

                                                            FileCreated = ProcessDatabase_CustomTime(DbContext, DataContext, ExportFolder, JobNumberPrependText, NonJobCode)

                                                        Case AdvantageFramework.Exporting.ExportTypes.ArchivedJobs

                                                            FileCreated = ProcessDatabase_ArchivedJobs(DbContext, DataContext, ExportFolder, JobNumberPrependText, CurrentProcessControl, CurrentProcessControl2, ChangeToProcessControl, ChangeAfter)

                                                        Case AdvantageFramework.Exporting.ExportTypes.PurchaseOrder

                                                            FileCreated = ProcessDatabase_PurchaseOrder_Custom1(DbContext, DataContext, ExportFolder)

                                                        Case AdvantageFramework.Exporting.ExportTypes.AccountPayable

                                                            FileCreated = ProcessDatabase_AccountPayable_Custom1(DbContext, DataContext, ExportFolder)

                                                        Case AdvantageFramework.Exporting.ExportTypes.YayPayInvoiceDetails

                                                            FileCreated = ProcessDatabase_YayPayInvoiceDetails(Session, DbContext, DataContext, ExportFolder, ExportSetting, ProcessNow)

                                                            'Case AdvantageFramework.Exporting.ExportTypes.YayPayInvoiceTransactionAllocations

                                                            '    FileCreated = ProcessDatabase_YayPayInvoiceTransactionAllocations(DbContext, DataContext, ExportSetting)

                                                            'Case AdvantageFramework.Exporting.ExportTypes.YayPayInvoiceWithPayments

                                                            '    FileCreated = ProcessDatabase_YayPayInvoiceWithPayments(DbContext, DataContext, ExportSetting)

                                                        Case Else

                                                            FileCreated = False

                                                    End Select

                                                Else

                                                    WriteToEventLog("directory does not exist" & ExportFolder)

                                                End If

                                            Else

                                                WriteToEventLog("No directory specified for template --> " & AdvantageServiceExport.ExportTemplate.Name)

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
        Public Function IsServiceReadyToRun(ByVal DatabaseProfile As AdvantageFramework.Database.DatabaseProfile, ByRef AdvantageServiceExportList As Generic.List(Of AdvantageFramework.Database.Entities.AdvantageServiceExport)) As Boolean

            'objects
            Dim ServiceIsReadyToRun As Boolean = False
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing

            If DatabaseProfile IsNot Nothing Then

                Try

                    Using DataContext = New AdvantageFramework.Database.DataContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                        Using DbContext = New AdvantageFramework.Database.DbContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                            AdvantageService = LoadAdvantageService(DataContext)

                            If AdvantageService IsNot Nothing Then

                                If AdvantageService.Enabled Then

                                    AdvantageServiceExportList = New Generic.List(Of AdvantageFramework.Database.Entities.AdvantageServiceExport)

                                    For Each AdvantageServiceExport In AdvantageFramework.Database.Procedures.AdvantageServiceExport.Load(DbContext).Include("ExportTemplate").ToList

                                        If IsAdvantageServiceExportReadyToRun(DataContext, AdvantageServiceExport.ID) Then

                                            AdvantageServiceExportList.Add(AdvantageServiceExport)

                                            ServiceIsReadyToRun = True

                                        End If

                                    Next

                                End If

                            End If

                        End Using

                    End Using

                Catch ex As Exception
                    ServiceIsReadyToRun = False
                End Try

            End If

            IsServiceReadyToRun = ServiceIsReadyToRun

        End Function
        Private Function IsAdvantageServiceExportReadyToRun(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AdvantageServiceExportID As Integer) As Boolean

            'objects
            Dim AdvantageServiceExportReadyToRun As Boolean = False
            Dim NextRunAt As Date = Nothing
            Dim RunAt As Date = Nothing
            Dim Enabled As Boolean = Nothing

            DateTime.TryParse(LoadAdvantageExportServiceSettingValue(DataContext, AdvantageServiceExportID, AdvantageFramework.Services.Exports.ExportSettings.RunAt), RunAt)
            DateTime.TryParse(LoadAdvantageExportServiceSettingValue(DataContext, AdvantageServiceExportID, AdvantageFramework.Services.Exports.ExportSettings.NextRunAt), NextRunAt)
            Enabled = LoadAdvantageExportServiceSettingValue(DataContext, AdvantageServiceExportID, AdvantageFramework.Services.Exports.ExportSettings.Enabled)

            If Enabled Then

                If NextRunAt = CDate("01/01/2001 01:00 AM") OrElse NextRunAt = Date.MinValue Then

                    NextRunAt = Now.ToShortDateString

                End If

                NextRunAt = NextRunAt.ToShortDateString & " " & RunAt.ToShortTimeString

                If DateDiff(DateInterval.Minute, NextRunAt, Now) >= 0 Then

                    NextRunAt = Now.AddDays(1).ToShortDateString & " " & RunAt.ToShortTimeString

                    SaveAdvantageServiceExportSettingValue(DataContext, AdvantageServiceExportID, AdvantageFramework.Services.Exports.ExportSettings.RunAt, RunAt)
                    SaveAdvantageServiceExportSettingValue(DataContext, AdvantageServiceExportID, AdvantageFramework.Services.Exports.ExportSettings.NextRunAt, NextRunAt)

                    AdvantageServiceExportReadyToRun = True

                End If

            End If

            IsAdvantageServiceExportReadyToRun = AdvantageServiceExportReadyToRun

        End Function
        Public Sub Run(ByVal DatabaseProfile As AdvantageFramework.Database.DatabaseProfile)

            'objects
            Dim AdvantageServiceExportList As Generic.List(Of AdvantageFramework.Database.Entities.AdvantageServiceExport) = Nothing

            If DatabaseProfile IsNot Nothing Then

                Try

                    If IsServiceReadyToRun(DatabaseProfile, AdvantageServiceExportList) Then

                        If AdvantageServiceExportList IsNot Nothing AndAlso AdvantageServiceExportList.Count > 0 Then

                            ProcessDatabase(DatabaseProfile, AdvantageServiceExportList, False)

                        End If

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

            If System.Diagnostics.EventLog.SourceExists("Adv Exports Source") = False Then

                System.Diagnostics.EventLog.CreateEventSource("Adv Exports Source", "Adv Exports Log")

            End If

            _EventLog = New System.Diagnostics.EventLog("Adv Exports Log", My.Computer.Name, "Adv Exports Source")

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

                AdvantageService = AdvantageFramework.Services.LoadAdvantageService(DataContext, AdvantageFramework.Services.Service.AdvantageExportTemplateWindowsService)

            Catch ex As Exception
                AdvantageService = Nothing
            End Try

            LoadAdvantageService = AdvantageService

        End Function
        Public Function LoadAdvantageExportServiceSetting(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AdvantageServiceExportID As Integer, ByVal ExportSetting As AdvantageFramework.Services.Exports.ExportSettings) As AdvantageFramework.Database.Entities.AdvantageServiceExportSetting

            'objects
            Dim AdvantageServiceExportSetting As AdvantageFramework.Database.Entities.AdvantageServiceExportSetting = Nothing

            Try

                AdvantageServiceExportSetting = AdvantageFramework.Database.Procedures.AdvantageServiceExportSetting.LoadByAdvantageServiceExportIDAndCode(DataContext, AdvantageServiceExportID, ExportSetting.ToString)

            Catch ex As Exception
                AdvantageServiceExportSetting = Nothing
            Finally
                LoadAdvantageExportServiceSetting = AdvantageServiceExportSetting
            End Try

        End Function
        Public Function LoadAdvantageExportServiceSettingValue(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AdvantageServiceExportID As Integer, ByVal ExportSetting As AdvantageFramework.Services.Exports.ExportSettings) As Object

            'objects
            Dim SettingValue As Object = Nothing
            Dim AdvantageServiceExportSetting As AdvantageFramework.Database.Entities.AdvantageServiceExportSetting = Nothing
            Dim Code As String = Nothing

            Try

                Code = ExportSetting.ToString

                AdvantageServiceExportSetting = (From Entity In DataContext.AdvantageServiceExportSettings
                                                 Where Entity.AdvantageServiceExportID = AdvantageServiceExportID AndAlso
                                                       Entity.Code = Code
                                                 Select Entity).SingleOrDefault

            Catch ex As Exception
                AdvantageServiceExportSetting = Nothing
            End Try

            If AdvantageServiceExportSetting IsNot Nothing Then

                If IsNothing(AdvantageServiceExportSetting.Value) Then

                    SettingValue = AdvantageServiceExportSetting.DefaultValue

                Else

                    SettingValue = AdvantageServiceExportSetting.Value

                End If

            End If

            LoadAdvantageExportServiceSettingValue = SettingValue

        End Function
        Public Function SaveAdvantageServiceExportSettingValue(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AdvantageServiceExportID As Integer, ByVal ExportSetting As AdvantageFramework.Services.Exports.ExportSettings, ByVal SettingValue As Object) As Boolean

            'objects
            Dim Saved As Boolean = False
            Dim AdvantageServiceExportSetting As AdvantageFramework.Database.Entities.AdvantageServiceExportSetting = Nothing
            Dim Code As String = Nothing

            Try

                Code = ExportSetting.ToString

                AdvantageServiceExportSetting = (From Entity In DataContext.AdvantageServiceExportSettings
                                                 Where Entity.AdvantageServiceExportID = AdvantageServiceExportID AndAlso
                                                       Entity.Code = Code
                                                 Select Entity).SingleOrDefault

            Catch ex As Exception
                AdvantageServiceExportSetting = Nothing
            End Try

            If AdvantageServiceExportSetting Is Nothing Then

                Try

                    AdvantageServiceExportSetting = New AdvantageFramework.Database.Entities.AdvantageServiceExportSetting

                    AdvantageServiceExportSetting.DataContext = DataContext
                    AdvantageServiceExportSetting.AdvantageServiceExportID = AdvantageServiceExportID
                    AdvantageServiceExportSetting.Code = AdvantageFramework.EnumUtilities.LoadEnumObject(ExportSetting).Code
                    AdvantageServiceExportSetting.Description = AdvantageFramework.EnumUtilities.LoadEnumObject(ExportSetting).Description
                    AdvantageServiceExportSetting.Value = SettingValue

                    If ExportSetting = ExportSettings.NextRunAt Then

                        AdvantageServiceExportSetting.DefaultValue = CDate("01/01/2001 01:00 AM")

                    End If

                    Saved = AdvantageFramework.Database.Procedures.AdvantageServiceExportSetting.Insert(DataContext, AdvantageServiceExportSetting)

                Catch ex As Exception
                    Saved = False
                End Try

            Else

                Try

                    AdvantageServiceExportSetting.Value = SettingValue

                    Saved = AdvantageFramework.Database.Procedures.AdvantageServiceExportSetting.Update(DataContext, AdvantageServiceExportSetting)

                Catch ex As Exception
                    Saved = False
                End Try

            End If

            SaveAdvantageServiceExportSettingValue = Saved

        End Function
        Public Sub LoadSettings(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AdvantageServiceEportID As Integer, ByRef RunAt As Date, ByRef JobNumberPrependText As String,
                                ByRef NonJobCode As String, ByRef ChangeAfter As Short, ByRef CurrentProcessControl As Short?, ByRef CurrentProcessControl2 As Short?, ByRef ChangeToProcessControl As Short?,
                                ByRef NumberOfDaysOldCutoff As Integer?)

            'objects
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing

            AdvantageService = LoadAdvantageService(DataContext)

            If AdvantageService IsNot Nothing Then

                Try

                    DateTime.TryParse(LoadAdvantageExportServiceSettingValue(DataContext, AdvantageServiceEportID, AdvantageFramework.Services.Exports.ExportSettings.RunAt), RunAt)

                Catch ex As Exception

                End Try

                JobNumberPrependText = LoadAdvantageExportServiceSettingValue(DataContext, AdvantageServiceEportID, AdvantageFramework.Services.Exports.ExportSettings.JobNumberPrependText)
                NonJobCode = LoadAdvantageExportServiceSettingValue(DataContext, AdvantageServiceEportID, AdvantageFramework.Services.Exports.ExportSettings.NonJobCode)
                ChangeAfter = LoadAdvantageExportServiceSettingValue(DataContext, AdvantageServiceEportID, AdvantageFramework.Services.Exports.ExportSettings.ChangeAfter)

                Try

                    CurrentProcessControl = CShort(LoadAdvantageExportServiceSettingValue(DataContext, AdvantageServiceEportID, AdvantageFramework.Services.Exports.ExportSettings.CurrentProcessControl))

                Catch ex As Exception

                End Try

                Try

                    CurrentProcessControl2 = CShort(LoadAdvantageExportServiceSettingValue(DataContext, AdvantageServiceEportID, AdvantageFramework.Services.Exports.ExportSettings.CurrentProcessControl2))

                Catch ex As Exception

                End Try

                Try

                    ChangeToProcessControl = CShort(LoadAdvantageExportServiceSettingValue(DataContext, AdvantageServiceEportID, AdvantageFramework.Services.Exports.ExportSettings.ChangeToProcessControl))

                Catch ex As Exception

                End Try


                Try

                    NumberOfDaysOldCutoff = CInt(LoadAdvantageExportServiceSettingValue(DataContext, AdvantageServiceEportID, AdvantageFramework.Services.Exports.ExportSettings.NumberOfDaysOldCutoff))

                Catch ex As Exception

                End Try

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

#Region " Job Export "

        Private Function ProcessDatabase_CustomJob(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                             ByVal DataContext As AdvantageFramework.Database.DataContext,
                                             ByVal ExportFolder As String, ByVal JobNumberPrependText As String,
                                             ByVal NumberOfDaysOld As Integer?) As Boolean

            'objects
            Dim StringBuilder As System.Text.StringBuilder = Nothing
            Dim ExportDataLine As String = ""
            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim Employees As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing
            Dim AccountExecutiveName As String = ""
            Dim ElementCode As String = ""
            Dim JobNumberText As String = ""
            Dim WBSUserDefinedType As AdvantageFramework.Database.Entities.UserDefinedType = Nothing
            Dim WBSUserDefinedTypeValue As AdvantageFramework.Database.Entities.UserDefinedTypeValue = Nothing
            Dim WBSUserDefinedTypeValues As Generic.List(Of AdvantageFramework.Database.Entities.UserDefinedTypeValue) = Nothing
            Dim CompanyCode As String = ""
            Dim JobComponentUserDefinedValue1 As AdvantageFramework.Database.Entities.JobComponentUserDefinedValue1 = Nothing
            Dim JobComponentUserDefinedValue1s As Generic.List(Of AdvantageFramework.Database.Entities.JobComponentUserDefinedValue1) = Nothing
            Dim FileCreated As Boolean = False
            Dim CutOffDate As Date = Nothing
            Dim JobComponentList As Generic.List(Of AdvantageFramework.Database.Entities.JobComponent) = Nothing

            Try

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

                Employees = AdvantageFramework.Database.Procedures.EmployeeView.Load(DbContext).ToList
                JobComponentUserDefinedValue1s = AdvantageFramework.Database.Procedures.JobComponentUserDefinedValue1.Load(DbContext).ToList
                WBSUserDefinedTypeValues = AdvantageFramework.Database.Procedures.UserDefinedTypeValue.Load(DbContext).Where(Function(Entity) Entity.UserDefinedTypeID = WBSUserDefinedType.ID).ToList

                StringBuilder = New System.Text.StringBuilder()

                WriteToEventLog("loading job data...")

                If NumberOfDaysOld > 0 Then

                    CutOffDate = System.DateTime.Today.AddDays(-NumberOfDaysOld)

                    JobComponentList = (From Entity In AdvantageFramework.Database.Procedures.JobComponent.LoadAllOpen(DbContext).Include("Job")
                                        Where Entity.CreatedDate >= CutOffDate
                                        Order By Entity.JobNumber, Entity.Number
                                        Select Entity).ToList

                Else

                    JobComponentList = (From Entity In AdvantageFramework.Database.Procedures.JobComponent.LoadAllOpen(DbContext).Include("Job")
                                        Order By Entity.JobNumber, Entity.Number
                                        Select Entity).ToList

                End If

                For Each JobComponent In JobComponentList

                    Employee = Nothing
                    AccountExecutiveName = ""
                    ElementCode = ""
                    WBSUserDefinedTypeValue = Nothing
                    CompanyCode = ""

                    If IsNothing(JobNumberPrependText) = False AndAlso JobNumberPrependText <> "" Then

                        JobNumberText = JobNumberPrependText & JobComponent.JobNumber & "-" & JobComponent.Number

                    Else

                        JobNumberText = JobComponent.JobNumber & "-" & JobComponent.Number

                    End If

                    ExportDataLine = AdvantageFramework.StringUtilities.PadWithCharacter(JobNumberText, 10, " ", False, True)
                    ExportDataLine &= AdvantageFramework.StringUtilities.PadWithCharacter(JobComponent.Job.Description, 50, " ", False, True)

                    Try

                        Employee = Employees.SingleOrDefault(Function(Entity) Entity.Code = JobComponent.AccountExecutiveEmployeeCode)

                    Catch ex As Exception
                        Employee = Nothing
                    End Try

                    If Employee IsNot Nothing Then

                        AccountExecutiveName = Employee.LastName & " " & Employee.FirstName

                    End If

                    ExportDataLine &= AdvantageFramework.StringUtilities.PadWithCharacter(AccountExecutiveName, 20, " ", False, True)

                    If String.IsNullOrEmpty(JobComponent.JobComponentUserDefinedValue1Code) = False AndAlso JobComponent.JobComponentUserDefinedValue1Code <> "0000" Then

                        ElementCode = JobComponent.JobComponentUserDefinedValue1Code

                        Try

                            JobComponentUserDefinedValue1 = JobComponentUserDefinedValue1s.SingleOrDefault(Function(Entity) Entity.Code = JobComponent.JobComponentUserDefinedValue1Code)

                        Catch ex As Exception
                            JobComponentUserDefinedValue1 = Nothing
                        End Try

                        If JobComponentUserDefinedValue1 IsNot Nothing Then

                            If JobComponentUserDefinedValue1.Code <> "0001" Then

                                Try

                                    CompanyCode = JobComponentUserDefinedValue1.Description.Substring(0, 4)

                                Catch ex As Exception
                                    CompanyCode = ""
                                End Try

                            End If

                        End If

                    Else

                        Try

                            WBSUserDefinedTypeValue = WBSUserDefinedTypeValues.SingleOrDefault(Function(Entity) Entity.ID = CInt(JobComponent.JobComponentUserDefinedValue2Code))

                        Catch ex As Exception
                            WBSUserDefinedTypeValue = Nothing
                        End Try

                        If WBSUserDefinedTypeValue IsNot Nothing Then

                            If WBSUserDefinedTypeValue.Code <> "0000" Then

                                ElementCode = WBSUserDefinedTypeValue.Code

                                If WBSUserDefinedTypeValue.Code <> "0001" Then

                                    Try

                                        CompanyCode = WBSUserDefinedTypeValue.Description.Substring(0, 4)

                                    Catch ex As Exception
                                        CompanyCode = ""
                                    End Try

                                End If

                            End If

                        End If

                    End If

                    ExportDataLine &= AdvantageFramework.StringUtilities.PadWithCharacter(ElementCode, 24, " ", False, True)
                    ExportDataLine &= AdvantageFramework.StringUtilities.PadWithCharacter("", 3, " ", True)

                    ExportDataLine &= AdvantageFramework.StringUtilities.PadWithCharacter(CompanyCode, 4, " ", True)

                    StringBuilder.AppendLine(ExportDataLine)

                Next

                WriteToEventLog("creating file...")

                My.Computer.FileSystem.WriteAllText(AdvantageFramework.StringUtilities.AppendTrailingCharacter(ExportFolder, "\") & "JobExport_" & Now.ToString("yyyyMMddHHmmss") & ".txt", StringBuilder.ToString, False)

                WriteToEventLog("file created...")

                FileCreated = True

            Catch ex As Exception
                FileCreated = False
            Finally
                ProcessDatabase_CustomJob = FileCreated
            End Try

        End Function

#End Region

#Region " Time Export "

        Private Function ProcessDatabase_CustomTime(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                              ByVal DataContext As AdvantageFramework.Database.DataContext,
                                              ByVal ExportFolder As String, ByVal JobNumberPrependText As String,
                                              ByVal NonJobCode As String) As Boolean

            'objects
            Dim StringBuilder As System.Text.StringBuilder = Nothing
            Dim ExportDataLine As String = ""
            Dim TimeAmount As Decimal = 0
            Dim JobNumberText As String = ""
            Dim StartDate As Date = Nothing
            Dim FileCreated As Boolean = False

            Try

                StringBuilder = New System.Text.StringBuilder()

                WriteToEventLog("loading job time data...")

                StartDate = Now.AddDays(-1)

                For Each EmployeeTimeDetail In (From ETD In AdvantageFramework.Database.Procedures.EmployeeTimeDetail.Load(DbContext)
                                                Group By ETD.JobNumber Into Group).ToList.Select(Function(GroupEntity) _
                                                         New With {.[JobNumber] = GroupEntity.JobNumber,
                                                                   .[TotalTimeAmount] = GroupEntity.Group.Sum(Function(Entity) Entity.TotalBilledAmount.GetValueOrDefault(0) + Entity.MarkupAmount.GetValueOrDefault(0))}).ToList

                    Try

                        TimeAmount = EmployeeTimeDetail.TotalTimeAmount

                    Catch ex As Exception
                        TimeAmount = 0
                    End Try

                    If IsNothing(JobNumberPrependText) = False AndAlso JobNumberPrependText <> "" Then

                        JobNumberText = JobNumberPrependText & EmployeeTimeDetail.JobNumber

                    Else

                        JobNumberText = EmployeeTimeDetail.JobNumber

                    End If

                    ExportDataLine = JobNumberText & "|" & FormatNumber(TimeAmount, 2, TriState.False, TriState.False, TriState.False)

                    StringBuilder.AppendLine(ExportDataLine)

                Next

                WriteToEventLog("loading non-job time data...")

                Try

                    TimeAmount = AdvantageFramework.Database.Procedures.EmployeeTimeIndirect.Load(DbContext).Where(Function(Entity) Entity.TotalCost IsNot Nothing).Select(Function(Entity) Entity.TotalCost).Sum.GetValueOrDefault(0)

                Catch ex As Exception
                    TimeAmount = 0
                End Try

                ExportDataLine = NonJobCode & "|" & FormatNumber(TimeAmount, 2, TriState.False, TriState.False, TriState.False)

                StringBuilder.AppendLine(ExportDataLine)

                WriteToEventLog("creating file...")

                My.Computer.FileSystem.WriteAllText(AdvantageFramework.StringUtilities.AppendTrailingCharacter(ExportFolder, "\") & "TimeExport_" & Now.ToString("yyyyMMddHHmmss") & ".txt", StringBuilder.ToString, False)

                WriteToEventLog("file created...")

                FileCreated = True

            Catch ex As Exception
                FileCreated = False
            Finally
                ProcessDatabase_CustomTime = FileCreated
            End Try

        End Function

#End Region

#Region " Archived Jobs "

        Private Function ProcessDatabase_ArchivedJobs(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                      ByVal DataContext As AdvantageFramework.Database.DataContext,
                                                      ByVal ExportFolder As String, ByVal JobNumberPrependText As String,
                                                      ByVal CurrentProcessControl As Short?, ByVal CurrentProcessControl2 As Short?,
                                                      ByVal ChangeToProcessControl As Short?, ByVal ArchiveAfter As Integer) As Boolean

            'objects
            Dim StringBuilder As System.Text.StringBuilder = Nothing
            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing
            Dim CurrentJobProcessLogList As Generic.List(Of AdvantageFramework.Database.Views.CurrentJobProcessLog) = Nothing
            Dim JobProcessLog As AdvantageFramework.Database.Entities.JobProcessLog = Nothing
            Dim ExportDataLine As String = ""
            Dim JobNumberText As String = ""
            Dim FileCreated As Boolean = False
            Dim JobCompString As String = Nothing
            Dim ProcessedAfterDate As Date = Nothing
            Dim ProcessControlArray As Short() = Nothing

            Try

                StringBuilder = New System.Text.StringBuilder()

                WriteToEventLog("loading archived job data...")

                ProcessedAfterDate = System.DateTime.Today.AddDays(-ArchiveAfter).AddDays(1).AddSeconds(-1)

                ProcessControlArray = {CurrentProcessControl.GetValueOrDefault(0), CurrentProcessControl2.GetValueOrDefault(0)}

                CurrentJobProcessLogList = (From Entity In AdvantageFramework.Database.Procedures.CurrentJobProcessLog.Load(DbContext)
                                            Where ProcessControlArray.Contains(Entity.NewProcessControl) AndAlso
                                                  Entity.ProcessedDate <= ProcessedAfterDate
                                            Select Entity).ToList

                For Each CurrentJobProcessLog In CurrentJobProcessLogList

                    JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, CurrentJobProcessLog.JobNumber, CurrentJobProcessLog.JobComponentNumber)

                    If JobComponent IsNot Nothing AndAlso ProcessControlArray.Contains(JobComponent.JobProcessNumber) Then

                        JobProcessLog = New AdvantageFramework.Database.Entities.JobProcessLog
                        JobProcessLog.DbContext = DbContext
                        JobProcessLog.OriginalProcessControl = JobComponent.JobProcessNumber
                        JobProcessLog.NewProcessControl = ChangeToProcessControl
                        JobProcessLog.ProcessedByUserCode = DbContext.UserCode
                        JobProcessLog.ProcessedDate = System.DateTime.Now
                        JobProcessLog.JobNumber = JobComponent.JobNumber
                        JobProcessLog.JobComponentNumber = JobComponent.Number
                        JobProcessLog.Comments = "Updated automatically by Advantage Export Service"
                        JobComponent.JobProcessNumber = ChangeToProcessControl

                        If AdvantageFramework.Database.Procedures.JobComponent.Update(DbContext, JobComponent) Then

                            If AdvantageFramework.Database.Procedures.JobProcessLog.Insert(DbContext, JobProcessLog) Then

                                JobCompString = JobComponent.JobNumber.ToString & "-" & JobComponent.Number.ToString

                                If IsNothing(JobNumberPrependText) = False AndAlso JobNumberPrependText <> "" Then

                                    JobNumberText = JobNumberPrependText & JobCompString

                                Else

                                    JobNumberText = JobCompString

                                End If

                                ExportDataLine = JobNumberText

                                StringBuilder.AppendLine(ExportDataLine)

                            End If

                        End If

                    End If

                Next

                If StringBuilder.Length > 0 Then

                    WriteToEventLog("creating file...")

                    My.Computer.FileSystem.WriteAllText(AdvantageFramework.StringUtilities.AppendTrailingCharacter(ExportFolder, "\") & "ArchivedJobs_" & Now.ToString("yyyyMMddHHmmss") & ".txt", StringBuilder.ToString, False)

                    WriteToEventLog("file created...")

                Else

                    WriteToEventLog("no jobs to archive...")

                End If

                FileCreated = True

            Catch ex As Exception
                WriteToEventLog("error archiving jobs!")
                FileCreated = False
            Finally
                ProcessDatabase_ArchivedJobs = FileCreated
            End Try

        End Function

#End Region

#Region " Purchase Order "

        Private Function ProcessDatabase_PurchaseOrder_Custom1(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                               ByVal DataContext As AdvantageFramework.Database.DataContext,
                                                               ByVal ExportFolder As String) As Boolean

            'objects
            Dim FileCreated As Boolean = False
            Dim PurchaseOrderCustom1 As AdvantageFramework.Exporting.DataFilterClasses.PurchaseOrderCustom1 = Nothing
            Dim ExportTemplate As AdvantageFramework.Database.Entities.ExportTemplate = Nothing
            Dim DataTable As System.Data.DataTable = Nothing

            Try

                WriteToEventLog("loading purchase order custom1 data...")

                PurchaseOrderCustom1 = New AdvantageFramework.Exporting.DataFilterClasses.PurchaseOrderCustom1()

                ExportTemplate = (From ET In AdvantageFramework.Database.Procedures.ExportTemplate.LoadByType(DbContext, AdvantageFramework.Exporting.ExportTypes.PurchaseOrder)
                                  Where ET.IsSystemTemplate = True AndAlso
                                        ET.Name.ToUpper = AdvantageFramework.Exporting.PO_CUSTOM_1
                                  Select ET).SingleOrDefault

                If ExportTemplate IsNot Nothing Then

                    Using SecurityDbContext As New AdvantageFramework.Security.Database.DbContext(DbContext.ConnectionString, DbContext.UserCode)

                        If AdvantageFramework.Exporting.CreateExportDataSourceByExportTemplate(DbContext, SecurityDbContext, AdvantageFramework.Exporting.ExportTypes.PurchaseOrder, ExportTemplate.ID, PurchaseOrderCustom1, DataTable) Then

                            WriteToEventLog("creating file...")

                            FileCreated = AdvantageFramework.Exporting.CreateExportFileByExportTemplate(DbContext, SecurityDbContext, AdvantageFramework.Exporting.ExportTypes.PurchaseOrder, ExportTemplate.ID, ExportFolder, PurchaseOrderCustom1, DataTable, Nothing)

                        End If

                    End Using

                    If FileCreated Then

                        WriteToEventLog("file created...")

                    Else

                        WriteToEventLog("create file failed...")

                    End If

                End If

            Catch ex As Exception
                FileCreated = False
            Finally
                ProcessDatabase_PurchaseOrder_Custom1 = FileCreated
            End Try

        End Function

#End Region

#Region " Accounts Payable "

        Private Function LoadDataTable(DbContext As AdvantageFramework.Database.DbContext,
                                       ExportTemplate As AdvantageFramework.Database.Entities.ExportTemplate,
                                       AccountPayableCustomList As Generic.List(Of AdvantageFramework.Exporting.DataClasses.AccountPayableCustom1),
                                       ByRef DataTable As System.Data.DataTable) As Boolean

            Dim DataLoaded As Boolean = False

            DataTable.BeginLoadData()

            Try

                For Each EntityItem In AccountPayableCustomList

                    AdvantageFramework.Exporting.InsertRowIntoDataTableFromEntity(DataTable, EntityItem)

                Next

                DataLoaded = True

            Catch ex As Exception

            End Try

            DataTable.EndLoadData()

            LoadDataTable = DataLoaded

        End Function
        Private Function ProcessDatabase_AccountPayable_Custom1(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                                ByVal DataContext As AdvantageFramework.Database.DataContext,
                                                                ByVal ExportFolder As String) As Boolean

            'objects
            Dim FileCreated As Boolean = False
            Dim AccountPayableCustom1 As AdvantageFramework.Exporting.DataFilterClasses.AccountPayableCustom1 = Nothing
            Dim ExportTemplate As AdvantageFramework.Database.Entities.ExportTemplate = Nothing
            Dim DataTable As System.Data.DataTable = Nothing
            Dim AccountPayableCustom1List As Generic.List(Of AdvantageFramework.Exporting.DataClasses.AccountPayableCustom1) = Nothing
            Dim DataLoaded As Boolean = False
            Dim AllAPIDs As IEnumerable(Of Integer) = Nothing
            Dim GoodAPIDs As Generic.List(Of Integer) = Nothing
            Dim BadAPIDs As Generic.List(Of Integer) = Nothing
            Dim FullFileName As String = ""

            Try

                WriteToEventLog("loading AP custom1 data...")

                AccountPayableCustom1 = New AdvantageFramework.Exporting.DataFilterClasses.AccountPayableCustom1()

                ExportTemplate = (From ET In AdvantageFramework.Database.Procedures.ExportTemplate.LoadByType(DbContext, AdvantageFramework.Exporting.ExportTypes.AccountPayable)
                                  Where ET.IsSystemTemplate = True AndAlso
                                        ET.Name.ToUpper = AdvantageFramework.Exporting.AP_CUSTOM_1
                                  Select ET).SingleOrDefault

                If ExportTemplate IsNot Nothing Then

                    Using SecurityDbContext As New AdvantageFramework.Security.Database.DbContext(DbContext.ConnectionString, DbContext.UserCode)

                        AccountPayableCustom1List = DbContext.Database.SqlQuery(Of AdvantageFramework.Exporting.DataClasses.AccountPayableCustom1)(AccountPayableCustom1.EntityFilterString).ToList

                        If AccountPayableCustom1List IsNot Nothing Then

                            GoodAPIDs = New Generic.List(Of Integer)
                            BadAPIDs = New Generic.List(Of Integer)

                            AllAPIDs = (From APC In AccountPayableCustom1List
                                        Select APC.AccountPayableID).Distinct.ToArray

                            For Each APID In AllAPIDs

                                If AccountPayableCustom1List.Where(Function(APC) APC.AccountPayableID = APID AndAlso APC.Include = False).Any Then

                                    BadAPIDs.Add(APID)

                                Else

                                    GoodAPIDs.Add(APID)

                                End If

                            Next

                            If GoodAPIDs.Count > 0 Then

                                DataTable = AdvantageFramework.Exporting.CreateDataTableFromTemplate(DbContext, AdvantageFramework.Exporting.ExportTypes.AccountPayable, ExportTemplate.ExportTemplateDetails.ToList)

                                DataLoaded = LoadDataTable(DbContext, ExportTemplate, AccountPayableCustom1List.Where(Function(APC) GoodAPIDs.Contains(APC.AccountPayableID)).ToList, DataTable)

                                If DataLoaded Then

                                    WriteToEventLog("creating file...")

                                    FileCreated = AdvantageFramework.Exporting.CreateExportFileByExportTemplate(DbContext, SecurityDbContext, AdvantageFramework.Exporting.ExportTypes.AccountPayable, ExportTemplate.ID, ExportFolder, AccountPayableCustom1, DataTable, Nothing)

                                    If FileCreated Then

                                        DbContext.Database.ExecuteSqlCommand(String.Format("exec dbo.advsp_ap_export_custom1_mark_as_exported '{0}'", String.Join(",", GoodAPIDs.ToArray)))

                                        WriteToEventLog("file created...")

                                    Else

                                        WriteToEventLog("create file failed...")

                                    End If

                                End If

                            End If

                            System.Threading.Thread.Sleep(1000)

                            If BadAPIDs.Count > 0 Then

                                DataTable = AdvantageFramework.Exporting.CreateDataTableFromTemplate(DbContext, AdvantageFramework.Exporting.ExportTypes.AccountPayable, ExportTemplate.ExportTemplateDetails.ToList)

                                DataLoaded = LoadDataTable(DbContext, ExportTemplate, AccountPayableCustom1List.Where(Function(APC) BadAPIDs.Contains(APC.AccountPayableID)).ToList, DataTable)

                                If DataLoaded Then

                                    WriteToEventLog("creating file...")

                                    FileCreated = AdvantageFramework.Exporting.CreateExportFileByExportTemplate(DbContext, SecurityDbContext, AdvantageFramework.Exporting.ExportTypes.AccountPayable, ExportTemplate.ID, ExportFolder, AccountPayableCustom1, DataTable, FullFileName)

                                    If FileCreated Then

                                        If My.Computer.FileSystem.FileExists(FullFileName) Then

                                            My.Computer.FileSystem.RenameFile(FullFileName, My.Computer.FileSystem.GetFileInfo(FullFileName).Name & ".bad")

                                        End If

                                        WriteToEventLog("file created...")

                                    Else

                                        WriteToEventLog("create file failed...")

                                    End If

                                End If

                            End If

                        Else

                            WriteToEventLog("no data for file...")

                        End If

                    End Using

                End If

            Catch ex As Exception
                FileCreated = False
            Finally
                ProcessDatabase_AccountPayable_Custom1 = FileCreated
            End Try

        End Function

#End Region

#Region " Job Export "

        Private Function ProcessDatabase_CustomJobExportToFTP(DbContext As AdvantageFramework.Database.DbContext,
                                                              DataContext As AdvantageFramework.Database.DataContext,
                                                              ExportSetting As AdvantageFramework.Services.Exports.Classes.ExportSetting) As Boolean

            'objects
            Dim FileCreated As Boolean = False
            Dim JobInfoToFTP As AdvantageFramework.Exporting.DataFilterClasses.JobInfoToFTP = Nothing
            Dim ExportTemplate As AdvantageFramework.Database.Entities.ExportTemplate = Nothing
            Dim DataTable As System.Data.DataTable = Nothing
            Dim File As String = ""

            Try

                WriteToEventLog("loading job info data...")

                JobInfoToFTP = New AdvantageFramework.Exporting.DataFilterClasses.JobInfoToFTP()

                ExportTemplate = (From Entity In AdvantageFramework.Database.Procedures.ExportTemplate.LoadByType(DbContext, AdvantageFramework.Exporting.ExportTypes.Job)
                                  Where Entity.IsSystemTemplate = True AndAlso
                                        Entity.Name.ToUpper = AdvantageFramework.Exporting.JOB_INFO_TO_FTP_1.ToUpper
                                  Select Entity).SingleOrDefault

                If ExportTemplate IsNot Nothing Then

                    Using SecurityDbContext As New AdvantageFramework.Security.Database.DbContext(DbContext.ConnectionString, DbContext.UserCode)

                        If AdvantageFramework.Exporting.CreateExportDataSourceByExportTemplate(DbContext, SecurityDbContext, AdvantageFramework.Exporting.ExportTypes.Job, ExportTemplate.ID, JobInfoToFTP, DataTable) Then

                            WriteToEventLog("creating file...")

                            FileCreated = AdvantageFramework.Exporting.CreateExportFileByExportTemplate(DbContext, SecurityDbContext, AdvantageFramework.Exporting.ExportTypes.Job, ExportTemplate.ID, ExportSetting.ExportPath, JobInfoToFTP, DataTable, File)

                        End If

                    End Using

                    If FileCreated Then

                        WriteToEventLog("file created...")

                        WriteToEventLog("validating ftp info...")

                        If AdvantageFramework.FTP.FTPValidation(ExportSetting.UseSSLForFTP, ExportSetting.FTPAddress, ExportSetting.FTPPort, ExportSetting.FTPUserName, ExportSetting.FTPPassword, ExportSetting.SSLModeForFTP) Then

                            WriteToEventLog("validation successful...")

                            WriteToEventLog("trying to upload...")

                            If AdvantageFramework.FTP.UploadToFTP(ExportSetting.UseSSLForFTP, ExportSetting.FTPAddress, ExportSetting.FTPPort, ExportSetting.FTPFolder, ExportSetting.FTPUserName, ExportSetting.FTPPassword, ExportSetting.SSLModeForFTP, File) Then

                                WriteToEventLog("upload completed...")

                            Else

                                WriteToEventLog("upload failed...")

                            End If

                        Else

                            WriteToEventLog("validation failed...")

                        End If

                    Else

                        WriteToEventLog("create file failed...")

                    End If

                End If

            Catch ex As Exception
                FileCreated = False
            Finally
                ProcessDatabase_CustomJobExportToFTP = FileCreated
            End Try

        End Function

#End Region

#Region " YayPay Invoice Details "

        Private Function ProcessDatabase_YayPayInvoiceDetails(Session As AdvantageFramework.Security.Session,
                                                              DbContext As AdvantageFramework.Database.DbContext,
                                                              DataContext As AdvantageFramework.Database.DataContext,
                                                              ExportFolder As String,
                                                              ExportSetting As AdvantageFramework.Services.Exports.Classes.ExportSetting,
                                                              ProcessNow As Boolean) As Boolean

            'objects
            Dim FileCreated As Boolean = False
            Dim InvoiceDetailFileCreated As Boolean = False
            Dim InvoiceTransactionAllocationsFileCreated As Boolean = False
            Dim InvoiceWithPaymentsFileCreated As Boolean = False
            Dim InvoiceTransactionFileCreated As Boolean = False
            Dim InvoiceCustomerFileCreated As Boolean = False
            Dim InvoiceContactFileCreated As Boolean = False
            Dim YayPayInvoiceDetail As AdvantageFramework.Exporting.DataFilterClasses.YayPayInvoiceDetail = Nothing
            Dim YayPayInvoiceTransactionAllocation As AdvantageFramework.Exporting.DataFilterClasses.YayPayInvoiceTransactionAllocation = Nothing
            Dim YayPayInvoiceWithPayments As AdvantageFramework.Exporting.DataFilterClasses.YayPayInvoiceWithPayments = Nothing
            Dim YayPayInvoiceTransaction As AdvantageFramework.Exporting.DataFilterClasses.YayPayInvoiceTransaction = Nothing
            Dim YayPayInvoiceCustomer As AdvantageFramework.Exporting.DataFilterClasses.YayPayInvoiceCustomer = Nothing
            Dim YayPayInvoiceContact As AdvantageFramework.Exporting.DataFilterClasses.YayPayInvoiceContact = Nothing
            Dim InvoiceDetailExportTemplate As AdvantageFramework.Database.Entities.ExportTemplate = Nothing
            Dim InvoiceTransactionAllocationsExportTemplate As AdvantageFramework.Database.Entities.ExportTemplate = Nothing
            Dim InvoiceWithPaymentsExportTemplate As AdvantageFramework.Database.Entities.ExportTemplate = Nothing
            Dim InvoiceTransactionExportTemplate As AdvantageFramework.Database.Entities.ExportTemplate = Nothing
            Dim InvoiceCustomerExportTemplate As AdvantageFramework.Database.Entities.ExportTemplate = Nothing
            Dim InvoiceContactExportTemplate As AdvantageFramework.Database.Entities.ExportTemplate = Nothing
            Dim InvoiceDetailDataTable As System.Data.DataTable = Nothing
            Dim InvoiceTransactionAllocationsDataTable As System.Data.DataTable = Nothing
            Dim InvoiceWithPaymentsDataTable As System.Data.DataTable = Nothing
            Dim InvoiceTransactionDataTable As System.Data.DataTable = Nothing
            Dim InvoiceCustomerDataTable As System.Data.DataTable = Nothing
            Dim InvoiceContactDataTable As System.Data.DataTable = Nothing
            Dim InvoiceDetailFile As String = String.Empty
            Dim InvoiceTransactionAllocationsFile As String = String.Empty
            Dim InvoiceWithPaymentsFile As String = String.Empty
            Dim InvoiceTransactionFile As String = String.Empty
            Dim InvoiceCustomerFile As String = String.Empty
            Dim InvoiceContactFile As String = String.Empty
            Dim ExportPath As String = String.Empty
            Dim File As String = String.Empty

            ExportSetting.ExportPath = ExportFolder

            Try

                WriteToEventLog("loading yay pay invoice detail data...")

                YayPayInvoiceDetail = New AdvantageFramework.Exporting.DataFilterClasses.YayPayInvoiceDetail()

                If ProcessNow Then

                    YayPayInvoiceDetail.StartDate = CDate(ExportSetting.ProcessNowTransactionDate.ToShortDateString & " 12:00 AM")
                    YayPayInvoiceDetail.EndDate = CDate(ExportSetting.ProcessNowTransactionDate.ToShortDateString & " 11:59 PM")

                Else

                    YayPayInvoiceDetail.StartDate = CDate(Now.AddDays(-1).ToShortDateString & " 12:00 AM")
                    YayPayInvoiceDetail.EndDate = CDate(Now.AddDays(-1).ToShortDateString & " 11:59 PM")

                End If

                InvoiceDetailExportTemplate = (From Entity In AdvantageFramework.Database.Procedures.ExportTemplate.LoadByType(DbContext, AdvantageFramework.Exporting.ExportTypes.YayPayInvoiceDetails)
                                               Where Entity.IsSystemTemplate = True
                                               Select Entity).FirstOrDefault

                If InvoiceDetailExportTemplate IsNot Nothing Then

                    Using SecurityDbContext As New AdvantageFramework.Security.Database.DbContext(DbContext.ConnectionString, DbContext.UserCode)

                        If AdvantageFramework.Exporting.CreateExportDataSourceByExportTemplate(DbContext, SecurityDbContext, AdvantageFramework.Exporting.ExportTypes.YayPayInvoiceDetails, InvoiceDetailExportTemplate.ID, YayPayInvoiceDetail, InvoiceDetailDataTable) Then

                            WriteToEventLog("creating file...")

                            InvoiceDetailFileCreated = AdvantageFramework.Exporting.CreateExportFileByExportTemplate(DbContext, SecurityDbContext, AdvantageFramework.Exporting.ExportTypes.YayPayInvoiceDetails, InvoiceDetailExportTemplate.ID, ExportSetting.ExportPath, YayPayInvoiceDetail, InvoiceDetailDataTable, InvoiceDetailFile)

                        End If

                    End Using

                End If

                WriteToEventLog("loading yay pay invoice transaction allocation data...")

                YayPayInvoiceTransactionAllocation = New AdvantageFramework.Exporting.DataFilterClasses.YayPayInvoiceTransactionAllocation()

                If ProcessNow Then

                    YayPayInvoiceTransactionAllocation.StartDate = CDate(ExportSetting.ProcessNowTransactionDate.ToShortDateString & " 12:00 AM")
                    YayPayInvoiceTransactionAllocation.EndDate = CDate(ExportSetting.ProcessNowTransactionDate.ToShortDateString & " 11:59 PM")

                Else

                    YayPayInvoiceTransactionAllocation.StartDate = CDate(Now.AddDays(-1).ToShortDateString & " 12:00 AM")
                    YayPayInvoiceTransactionAllocation.EndDate = CDate(Now.AddDays(-1).ToShortDateString & " 11:59 PM")

                End If

                InvoiceTransactionAllocationsExportTemplate = (From Entity In AdvantageFramework.Database.Procedures.ExportTemplate.LoadByType(DbContext, AdvantageFramework.Exporting.ExportTypes.YayPayInvoiceTransactionAllocations)
                                                               Where Entity.IsSystemTemplate = True
                                                               Select Entity).SingleOrDefault

                If InvoiceTransactionAllocationsExportTemplate IsNot Nothing Then

                    Using SecurityDbContext As New AdvantageFramework.Security.Database.DbContext(DbContext.ConnectionString, DbContext.UserCode)

                        If AdvantageFramework.Exporting.CreateExportDataSourceByExportTemplate(DbContext, SecurityDbContext, AdvantageFramework.Exporting.ExportTypes.YayPayInvoiceTransactionAllocations, InvoiceTransactionAllocationsExportTemplate.ID, YayPayInvoiceTransactionAllocation, InvoiceTransactionAllocationsDataTable) Then

                            WriteToEventLog("creating file...")

                            InvoiceTransactionAllocationsFileCreated = AdvantageFramework.Exporting.CreateExportFileByExportTemplate(DbContext, SecurityDbContext, AdvantageFramework.Exporting.ExportTypes.YayPayInvoiceTransactionAllocations, InvoiceTransactionAllocationsExportTemplate.ID, ExportSetting.ExportPath, YayPayInvoiceTransactionAllocation, InvoiceTransactionAllocationsDataTable, InvoiceTransactionAllocationsFile)

                        End If

                    End Using

                End If

                WriteToEventLog("loading yay pay invoice payment data...")

                YayPayInvoiceWithPayments = New AdvantageFramework.Exporting.DataFilterClasses.YayPayInvoiceWithPayments()

                If ProcessNow Then

                    YayPayInvoiceWithPayments.StartDate = CDate(ExportSetting.ProcessNowTransactionDate.ToShortDateString & " 12:00 AM")
                    YayPayInvoiceWithPayments.EndDate = CDate(ExportSetting.ProcessNowTransactionDate.ToShortDateString & " 11:59 PM")

                Else

                    YayPayInvoiceWithPayments.StartDate = CDate(Now.AddDays(-1).ToShortDateString & " 12:00 AM")
                    YayPayInvoiceWithPayments.EndDate = CDate(Now.AddDays(-1).ToShortDateString & " 11:59 PM")

                End If

                InvoiceWithPaymentsExportTemplate = (From Entity In AdvantageFramework.Database.Procedures.ExportTemplate.LoadByType(DbContext, AdvantageFramework.Exporting.ExportTypes.YayPayInvoiceWithPayments)
                                                     Where Entity.IsSystemTemplate = True
                                                     Select Entity).SingleOrDefault

                If InvoiceWithPaymentsExportTemplate IsNot Nothing Then

                    Using SecurityDbContext As New AdvantageFramework.Security.Database.DbContext(DbContext.ConnectionString, DbContext.UserCode)

                        If AdvantageFramework.Exporting.CreateExportDataSourceByExportTemplate(DbContext, SecurityDbContext, AdvantageFramework.Exporting.ExportTypes.YayPayInvoiceWithPayments, InvoiceWithPaymentsExportTemplate.ID, YayPayInvoiceWithPayments, InvoiceWithPaymentsDataTable) Then

                            WriteToEventLog("creating file...")

                            InvoiceWithPaymentsFileCreated = AdvantageFramework.Exporting.CreateExportFileByExportTemplate(DbContext, SecurityDbContext, AdvantageFramework.Exporting.ExportTypes.YayPayInvoiceWithPayments, InvoiceWithPaymentsExportTemplate.ID, ExportSetting.ExportPath, YayPayInvoiceWithPayments, InvoiceWithPaymentsDataTable, InvoiceWithPaymentsFile)

                        End If

                    End Using

                End If

                WriteToEventLog("loading yay pay invoice transaction data...")

                YayPayInvoiceTransaction = New AdvantageFramework.Exporting.DataFilterClasses.YayPayInvoiceTransaction()

                If ProcessNow Then

                    YayPayInvoiceTransaction.StartDate = CDate(ExportSetting.ProcessNowTransactionDate.ToShortDateString & " 12:00 AM")
                    YayPayInvoiceTransaction.EndDate = CDate(ExportSetting.ProcessNowTransactionDate.ToShortDateString & " 11:59 PM")

                Else

                    YayPayInvoiceTransaction.StartDate = CDate(Now.AddDays(-1).ToShortDateString & " 12:00 AM")
                    YayPayInvoiceTransaction.EndDate = CDate(Now.AddDays(-1).ToShortDateString & " 11:59 PM")

                End If

                InvoiceTransactionExportTemplate = (From Entity In AdvantageFramework.Database.Procedures.ExportTemplate.LoadByType(DbContext, AdvantageFramework.Exporting.ExportTypes.YayPayInvoiceTransactions)
                                                    Where Entity.IsSystemTemplate = True
                                                    Select Entity).SingleOrDefault

                If InvoiceTransactionExportTemplate IsNot Nothing Then

                    Using SecurityDbContext As New AdvantageFramework.Security.Database.DbContext(DbContext.ConnectionString, DbContext.UserCode)

                        If AdvantageFramework.Exporting.CreateExportDataSourceByExportTemplate(DbContext, SecurityDbContext, AdvantageFramework.Exporting.ExportTypes.YayPayInvoiceTransactions, InvoiceTransactionExportTemplate.ID, YayPayInvoiceTransaction, InvoiceTransactionDataTable) Then

                            WriteToEventLog("creating file...")

                            InvoiceTransactionFileCreated = AdvantageFramework.Exporting.CreateExportFileByExportTemplate(DbContext, SecurityDbContext, AdvantageFramework.Exporting.ExportTypes.YayPayInvoiceTransactions, InvoiceTransactionExportTemplate.ID, ExportSetting.ExportPath, YayPayInvoiceTransaction, InvoiceTransactionDataTable, InvoiceTransactionFile)

                        End If

                    End Using

                End If

                WriteToEventLog("loading yay pay invoice customer data...")

                YayPayInvoiceCustomer = New AdvantageFramework.Exporting.DataFilterClasses.YayPayInvoiceCustomer()

                InvoiceCustomerExportTemplate = (From Entity In AdvantageFramework.Database.Procedures.ExportTemplate.LoadByType(DbContext, AdvantageFramework.Exporting.ExportTypes.YayPayInvoiceCustomers)
                                                 Where Entity.IsSystemTemplate = True
                                                 Select Entity).SingleOrDefault

                If InvoiceCustomerExportTemplate IsNot Nothing Then

                    Using SecurityDbContext As New AdvantageFramework.Security.Database.DbContext(DbContext.ConnectionString, DbContext.UserCode)

                        If AdvantageFramework.Exporting.CreateExportDataSourceByExportTemplate(DbContext, SecurityDbContext, AdvantageFramework.Exporting.ExportTypes.YayPayInvoiceCustomers, InvoiceCustomerExportTemplate.ID, YayPayInvoiceCustomer, InvoiceCustomerDataTable) Then

                            WriteToEventLog("creating file...")

                            InvoiceCustomerFileCreated = AdvantageFramework.Exporting.CreateExportFileByExportTemplate(DbContext, SecurityDbContext, AdvantageFramework.Exporting.ExportTypes.YayPayInvoiceCustomers, InvoiceCustomerExportTemplate.ID, ExportSetting.ExportPath, YayPayInvoiceCustomer, InvoiceCustomerDataTable, InvoiceCustomerFile)

                        End If

                    End Using

                End If

                WriteToEventLog("loading yay pay invoice contact data...")

                YayPayInvoiceContact = New AdvantageFramework.Exporting.DataFilterClasses.YayPayInvoiceContact()

                InvoiceContactExportTemplate = (From Entity In AdvantageFramework.Database.Procedures.ExportTemplate.LoadByType(DbContext, AdvantageFramework.Exporting.ExportTypes.YayPayInvoiceContacts)
                                                Where Entity.IsSystemTemplate = True
                                                Select Entity).SingleOrDefault

                If InvoiceContactExportTemplate IsNot Nothing Then

                    Using SecurityDbContext As New AdvantageFramework.Security.Database.DbContext(DbContext.ConnectionString, DbContext.UserCode)

                        If AdvantageFramework.Exporting.CreateExportDataSourceByExportTemplate(DbContext, SecurityDbContext, AdvantageFramework.Exporting.ExportTypes.YayPayInvoiceContacts, InvoiceContactExportTemplate.ID, YayPayInvoiceContact, InvoiceContactDataTable) Then

                            WriteToEventLog("creating file...")

                            InvoiceContactFileCreated = AdvantageFramework.Exporting.CreateExportFileByExportTemplate(DbContext, SecurityDbContext, AdvantageFramework.Exporting.ExportTypes.YayPayInvoiceContacts, InvoiceContactExportTemplate.ID, ExportSetting.ExportPath, YayPayInvoiceContact, InvoiceContactDataTable, InvoiceContactFile)

                        End If

                    End Using

                End If

                WriteToEventLog("creating zip file...")

                ExportPath = ExportSetting.ExportPath

                ExportPath = AdvantageFramework.StringUtilities.AppendTrailingCharacter(ExportPath, "\")

                If InvoiceDetailFileCreated AndAlso InvoiceTransactionAllocationsFileCreated AndAlso InvoiceWithPaymentsFileCreated AndAlso InvoiceTransactionFileCreated AndAlso InvoiceCustomerFileCreated AndAlso InvoiceContactFileCreated Then

                    File = ExportPath & "YayPay_" & String.Format("{0:yyyy-MM-dd_HH-mm-ss-fff}", DateTime.Now) & ".zip"

                    Using ZipArchive = New Rebex.IO.Compression.ZipArchive(File, Rebex.IO.Compression.ArchiveOpenMode.Create)

                        ZipArchive.AddFile(InvoiceDetailFile)
                        ZipArchive.AddFile(InvoiceTransactionAllocationsFile)
                        ZipArchive.AddFile(InvoiceWithPaymentsFile)
                        ZipArchive.AddFile(InvoiceTransactionFile)
                        ZipArchive.AddFile(InvoiceCustomerFile)
                        ZipArchive.AddFile(InvoiceContactFile)

                    End Using

                    FileCreated = True

                End If

                Try

                    If String.IsNullOrWhiteSpace(InvoiceDetailFile) = False Then

                        If System.IO.File.Exists(InvoiceDetailFile) Then

                            System.IO.File.Delete(InvoiceDetailFile)

                        End If

                    End If

                Catch ex As Exception

                End Try

                Try

                    If String.IsNullOrWhiteSpace(InvoiceTransactionAllocationsFile) = False Then

                        If System.IO.File.Exists(InvoiceTransactionAllocationsFile) Then

                            System.IO.File.Delete(InvoiceTransactionAllocationsFile)

                        End If

                    End If

                Catch ex As Exception

                End Try

                Try

                    If String.IsNullOrWhiteSpace(InvoiceWithPaymentsFile) = False Then

                        If System.IO.File.Exists(InvoiceWithPaymentsFile) Then

                            System.IO.File.Delete(InvoiceWithPaymentsFile)

                        End If

                    End If

                Catch ex As Exception

                End Try

                Try

                    If String.IsNullOrWhiteSpace(InvoiceTransactionFile) = False Then

                        If System.IO.File.Exists(InvoiceTransactionFile) Then

                            System.IO.File.Delete(InvoiceTransactionFile)

                        End If

                    End If

                Catch ex As Exception

                End Try

                Try

                    If String.IsNullOrWhiteSpace(InvoiceCustomerFile) = False Then

                        If System.IO.File.Exists(InvoiceCustomerFile) Then

                            System.IO.File.Delete(InvoiceCustomerFile)

                        End If

                    End If

                Catch ex As Exception

                End Try

                Try

                    If String.IsNullOrWhiteSpace(InvoiceContactFile) = False Then

                        If System.IO.File.Exists(InvoiceContactFile) Then

                            System.IO.File.Delete(InvoiceContactFile)

                        End If

                    End If

                Catch ex As Exception

                End Try

                If FileCreated Then

                    WriteToEventLog("file created...")

                    Try

                        If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) Then

                            WriteToEventLog("sending email...")

                            If AdvantageFramework.Email.SendASPReportDownloadEmail(Session, File, ExportSetting.EmailAddress) Then

                                WriteToEventLog("email sent sucessfully...")

                            Else

                                WriteToEventLog("failed sending email...")

                            End If

                        End If

                    Catch ex As Exception
                        WriteToEventLog("failed sending email...")
                    End Try

                    WriteToEventLog("validating ftp info...")

                    If AdvantageFramework.FTP.FTPValidation(ExportSetting.UseSSLForFTP, ExportSetting.FTPAddress, ExportSetting.FTPPort, ExportSetting.FTPUserName, ExportSetting.FTPPassword, ExportSetting.SSLModeForFTP) Then

                        WriteToEventLog("validation successful...")

                        WriteToEventLog("trying to upload...")

                        If AdvantageFramework.FTP.UploadToFTP(ExportSetting.UseSSLForFTP, ExportSetting.FTPAddress, ExportSetting.FTPPort, ExportSetting.FTPFolder, ExportSetting.FTPUserName, ExportSetting.FTPPassword, ExportSetting.SSLModeForFTP, File) Then

                            WriteToEventLog("upload completed...")

                        Else

                            WriteToEventLog("upload failed...")

                        End If

                    Else

                        WriteToEventLog("validation failed...")

                    End If

                Else

                    WriteToEventLog("create file failed...")

                End If

            Catch ex As Exception
                FileCreated = False
            Finally
                ProcessDatabase_YayPayInvoiceDetails = FileCreated
            End Try

        End Function

#End Region

        '#Region " YayPay Invoice Transaction Allocations "

        '        Private Function ProcessDatabase1_YayPayInvoiceTransactionAllocations(DbContext As AdvantageFramework.Database.DbContext,
        '                                                                             DataContext As AdvantageFramework.Database.DataContext,
        '                                                                             ExportSetting As AdvantageFramework.Services.Exports.Classes.ExportSetting) As Boolean

        '            'objects
        '            Dim FileCreated As Boolean = False
        '            Dim YayPayInvoiceTransactionAllocation As AdvantageFramework.Exporting.DataFilterClasses.YayPayInvoiceTransactionAllocation = Nothing
        '            Dim ExportTemplate As AdvantageFramework.Database.Entities.ExportTemplate = Nothing
        '            Dim DataTable As System.Data.DataTable = Nothing
        '            Dim File As String = ""

        '            Try

        '                WriteToEventLog("loading yay pay invoice data...")

        '                YayPayInvoiceTransactionAllocation = New AdvantageFramework.Exporting.DataFilterClasses.YayPayInvoiceTransactionAllocation()

        '                YayPayInvoiceTransactionAllocation.StartDate = CDate(Now.AddDays(-1).ToShortDateString & " 12:00 AM")
        '                YayPayInvoiceTransactionAllocation.EndDate = CDate(Now.AddDays(-1).ToShortDateString & " 11:59 PM")

        '                ExportTemplate = (From Entity In AdvantageFramework.Database.Procedures.ExportTemplate.LoadByType(DbContext, AdvantageFramework.Exporting.ExportTypes.YayPayInvoiceTransactionAllocations)
        '                                  Where Entity.IsSystemTemplate = True
        '                                  Select Entity).SingleOrDefault

        '                If ExportTemplate IsNot Nothing Then

        '                    Using SecurityDbContext As New AdvantageFramework.Security.Database.DbContext(DbContext.ConnectionString, DbContext.UserCode)

        '                        If AdvantageFramework.Exporting.CreateExportDataSourceByExportTemplate(DbContext, SecurityDbContext, AdvantageFramework.Exporting.ExportTypes.YayPayInvoiceTransactionAllocations, ExportTemplate.ID, YayPayInvoiceTransactionAllocation, DataTable) Then

        '                            WriteToEventLog("creating file...")

        '                            FileCreated = AdvantageFramework.Exporting.CreateExportFileByExportTemplate(DbContext, SecurityDbContext, AdvantageFramework.Exporting.ExportTypes.YayPayInvoiceTransactionAllocations, ExportTemplate.ID, ExportSetting.ExportPath, YayPayInvoiceTransactionAllocation, DataTable, File)

        '                        End If

        '                    End Using

        '                    If FileCreated Then

        '                        WriteToEventLog("file created...")

        '                        WriteToEventLog("validating ftp info...")

        '                        If AdvantageFramework.FTP.FTPValidation(ExportSetting.UseSSLForFTP, ExportSetting.FTPAddress, ExportSetting.FTPPort, ExportSetting.FTPFolder, ExportSetting.FTPUserName, ExportSetting.FTPPassword, ExportSetting.SSLModeForFTP) Then

        '                            WriteToEventLog("validation successful...")

        '                            WriteToEventLog("trying to upload...")

        '                            If AdvantageFramework.FTP.UploadToFTP(ExportSetting.UseSSLForFTP, ExportSetting.FTPAddress, ExportSetting.FTPPort, ExportSetting.FTPFolder, ExportSetting.FTPUserName, ExportSetting.FTPPassword, ExportSetting.SSLModeForFTP, File) Then

        '                                WriteToEventLog("upload completed...")

        '                            Else

        '                                WriteToEventLog("upload failed...")

        '                            End If

        '                        Else

        '                            WriteToEventLog("validation failed...")

        '                        End If

        '                    Else

        '                        WriteToEventLog("create file failed...")

        '                    End If

        '                End If

        '            Catch ex As Exception
        '                FileCreated = False
        '            Finally
        '                ProcessDatabase1_YayPayInvoiceTransactionAllocations = FileCreated
        '            End Try

        '        End Function

        '#End Region

        '#Region " YayPay Invoice With Payments "

        '        Private Function ProcessDatabase1_YayPayInvoiceWithPayments(DbContext As AdvantageFramework.Database.DbContext,
        '                                                                   DataContext As AdvantageFramework.Database.DataContext,
        '                                                                   ExportSetting As AdvantageFramework.Services.Exports.Classes.ExportSetting) As Boolean

        '            'objects
        '            Dim FileCreated As Boolean = False
        '            Dim YayPayInvoiceWithPayments As AdvantageFramework.Exporting.DataFilterClasses.YayPayInvoiceWithPayments = Nothing
        '            Dim ExportTemplate As AdvantageFramework.Database.Entities.ExportTemplate = Nothing
        '            Dim DataTable As System.Data.DataTable = Nothing
        '            Dim File As String = ""

        '            Try

        '                WriteToEventLog("loading yay pay invoice data...")

        '                YayPayInvoiceWithPayments = New AdvantageFramework.Exporting.DataFilterClasses.YayPayInvoiceWithPayments()

        '                YayPayInvoiceWithPayments.StartDate = CDate(Now.AddDays(-1).ToShortDateString & " 12:00 AM")
        '                YayPayInvoiceWithPayments.EndDate = CDate(Now.AddDays(-1).ToShortDateString & " 11:59 PM")

        '                ExportTemplate = (From Entity In AdvantageFramework.Database.Procedures.ExportTemplate.LoadByType(DbContext, AdvantageFramework.Exporting.ExportTypes.YayPayInvoiceWithPayments)
        '                                  Where Entity.IsSystemTemplate = True
        '                                  Select Entity).SingleOrDefault

        '                If ExportTemplate IsNot Nothing Then

        '                    Using SecurityDbContext As New AdvantageFramework.Security.Database.DbContext(DbContext.ConnectionString, DbContext.UserCode)

        '                        If AdvantageFramework.Exporting.CreateExportDataSourceByExportTemplate(DbContext, SecurityDbContext, AdvantageFramework.Exporting.ExportTypes.YayPayInvoiceWithPayments, ExportTemplate.ID, YayPayInvoiceWithPayments, DataTable) Then

        '                            WriteToEventLog("creating file...")

        '                            FileCreated = AdvantageFramework.Exporting.CreateExportFileByExportTemplate(DbContext, SecurityDbContext, AdvantageFramework.Exporting.ExportTypes.YayPayInvoiceWithPayments, ExportTemplate.ID, ExportSetting.ExportPath, YayPayInvoiceWithPayments, DataTable, File)

        '                        End If

        '                    End Using

        '                    If FileCreated Then

        '                        WriteToEventLog("file created...")

        '                        WriteToEventLog("validating ftp info...")

        '                        If AdvantageFramework.FTP.FTPValidation(ExportSetting.UseSSLForFTP, ExportSetting.FTPAddress, ExportSetting.FTPPort, ExportSetting.FTPFolder, ExportSetting.FTPUserName, ExportSetting.FTPPassword, ExportSetting.SSLModeForFTP) Then

        '                            WriteToEventLog("validation successful...")

        '                            WriteToEventLog("trying to upload...")

        '                            If AdvantageFramework.FTP.UploadToFTP(ExportSetting.UseSSLForFTP, ExportSetting.FTPAddress, ExportSetting.FTPPort, ExportSetting.FTPFolder, ExportSetting.FTPUserName, ExportSetting.FTPPassword, ExportSetting.SSLModeForFTP, File) Then

        '                                WriteToEventLog("upload completed...")

        '                            Else

        '                                WriteToEventLog("upload failed...")

        '                            End If

        '                        Else

        '                            WriteToEventLog("validation failed...")

        '                        End If

        '                    Else

        '                        WriteToEventLog("create file failed...")

        '                    End If

        '                End If

        '            Catch ex As Exception
        '                FileCreated = False
        '            Finally
        '                ProcessDatabase1_YayPayInvoiceWithPayments = FileCreated
        '            End Try

        '        End Function

        '#End Region

    End Module

End Namespace
