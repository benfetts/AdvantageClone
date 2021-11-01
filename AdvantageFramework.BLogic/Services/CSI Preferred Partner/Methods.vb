Namespace Services.CSIPreferredPartner

    <HideModuleName()>
    Public Module Methods

        Public Event EntryLogWrittenEvent(ByVal EventLogEntry As System.Diagnostics.EventLogEntry)

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum RegistrySetting
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\CSI Preferred Partner\", "LastRanAt", "01/01/2001 01:00 AM")>
            LastRanAt
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\CSI Preferred Partner\", "DownloadFolder", "")>
            DownloadFolder
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\CSI Preferred Partner\", "UploadFolder", "")>
            UploadFolder
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\CSI Preferred Partner\", "UploadedFiles", "")>
            UploadedFiles
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\CSI Preferred Partner\", "LastVendorUploadRanAt", "01/01/2001 01:00 AM")>
            LastVendorUploadRanAt
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\CSI Preferred Partner\", "LastVendorDownloadRanAt", "01/01/2001 01:00 AM")>
            LastVendorDownloadRanAt
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
        Private Function LoadUploadedFiles(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AdvantageService As AdvantageFramework.Database.Entities.AdvantageService,
                                           ByVal AdvantageServiceSetting As AdvantageFramework.Database.Entities.AdvantageServiceSetting) As Generic.List(Of String)

            'objects
            Dim AdvantageServiceSettingLists As Generic.List(Of AdvantageFramework.Database.Entities.AdvantageServiceSettingList) = Nothing
            Dim UploadedFile As String = Nothing
            Dim UploadedFiles As Generic.List(Of String) = Nothing

            If DataContext IsNot Nothing Then

                If AdvantageService IsNot Nothing Then

                    If AdvantageServiceSetting IsNot Nothing AndAlso AdvantageServiceSetting.Code = RegistrySetting.UploadedFiles.ToString Then

                        UploadedFiles = New Generic.List(Of String)

                        AdvantageServiceSettingLists = LoadAdvantageServiceSettingList(DataContext, AdvantageServiceSetting.ID)

                        For Each AdvantageServiceSettingList In AdvantageServiceSettingLists

                            UploadedFile = Nothing

                            If IsNothing(AdvantageServiceSettingList.Value) = False Then

                                Try

                                    UploadedFile = AdvantageServiceSettingList.Value

                                Catch ex As Exception
                                    UploadedFile = Nothing
                                End Try

                                If UploadedFile IsNot Nothing Then

                                    UploadedFiles.Add(UploadedFile)

                                End If

                            End If

                        Next

                    End If

                End If

            End If

            LoadUploadedFiles = UploadedFiles

        End Function
        Private Function LoadUploadedFiles(ByVal DataContext As AdvantageFramework.Database.DataContext) As Generic.List(Of String)

            'objects
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing
            Dim AdvantageServiceSetting As AdvantageFramework.Database.Entities.AdvantageServiceSetting = Nothing
            Dim UploadedFiles As Generic.List(Of String) = Nothing

            If DataContext IsNot Nothing Then

                AdvantageService = LoadAdvantageService(DataContext)

                If AdvantageService IsNot Nothing Then

                    AdvantageServiceSetting = LoadAdvantageServiceSetting(DataContext, AdvantageService.ID, RegistrySetting.UploadedFiles)

                    If AdvantageServiceSetting IsNot Nothing Then

                        UploadedFiles = LoadUploadedFiles(DataContext, AdvantageService, AdvantageServiceSetting)

                    End If

                End If

            End If

            LoadUploadedFiles = UploadedFiles

        End Function
        Public Sub LoadFTPServer(ByVal DataContext As AdvantageFramework.Database.DataContext, ByRef FTPServer As String, ByRef FTPPort As Integer)

            'objects
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim FTPSettingValue As String = ""

            If DataContext IsNot Nothing Then

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.CSI_GVCARD_FTP.ToString)

                If Setting IsNot Nothing Then

                    FTPSettingValue = Setting.Value

                End If

                If String.IsNullOrWhiteSpace(FTPSettingValue) = False Then

                    If FTPSettingValue.Contains(":") = True Then

                        FTPServer = FTPSettingValue.Split(":")(0)

                        If IsNumeric(FTPSettingValue.Split(":")(1)) Then

                            FTPPort = FTPSettingValue.Split(":")(1)

                        End If

                    Else

                        FTPServer = FTPSettingValue

                    End If

                End If

            End If

        End Sub
        Public Sub ProcessDatabase(ByVal DatabaseProfile As AdvantageFramework.Database.DatabaseProfile, ByVal FromService As Boolean)

            'objects
            Dim ErrorMessage As String = Nothing
            Dim UploadedFiles As Generic.List(Of String) = Nothing
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing
            Dim UploadedFilesServiceSetting As AdvantageFramework.Database.Entities.AdvantageServiceSetting = Nothing
            Dim DownloadedFilesServiceSetting As AdvantageFramework.Database.Entities.AdvantageServiceSetting = Nothing
            Dim FTPFiles As Generic.List(Of String) = Nothing
            Dim Banks As Generic.List(Of AdvantageFramework.Database.Entities.Bank) = Nothing
            Dim FTPServer As String = ""
            Dim FTPPort As Integer = 0
            Dim DownloadFolder As String = ""
            Dim UploadFolder As String = ""

            Try

                If DatabaseProfile IsNot Nothing Then

                    WriteToEventLog("Connecting to database --> " & DatabaseProfile.DatabaseName)

                    Using DataContext = New AdvantageFramework.Database.DataContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                        Using DbContext = New AdvantageFramework.Database.DbContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                                WriteToEventLog("Load service settings --> " & DatabaseProfile.DatabaseName)

                                AdvantageService = LoadAdvantageService(DataContext)

                                If AdvantageService IsNot Nothing Then

                                    If AdvantageFramework.CSIPreferredPartner.HasAgreementBeenSigned(DbContext, DataContext) Then

                                        UploadedFilesServiceSetting = LoadAdvantageServiceSetting(DataContext, AdvantageService.ID, RegistrySetting.UploadedFiles)

                                        If UploadedFilesServiceSetting IsNot Nothing Then

                                            UploadedFiles = LoadUploadedFiles(DataContext, AdvantageService, UploadedFilesServiceSetting)

                                        End If

                                        AdvantageFramework.Services.CSIPreferredPartner.LoadSettings(DataContext, DownloadFolder, UploadFolder)

                                        LoadFTPServer(DataContext, FTPServer, FTPPort)

										Banks = AdvantageFramework.Database.Procedures.Bank.LoadAllActive(DbContext).Where(Function(Entity) Entity.PaymentManagerType = "CSI" OrElse Entity.PaymentManagerType = "CSI2" OrElse Entity.PaymentManagerType = "CSI3").ToList

										ProcessDatabasePaymentFiles(DbContext, DataContext, Banks, FTPFiles, UploadedFiles, FTPServer, FTPPort, AdvantageService, UploadedFilesServiceSetting, DownloadedFilesServiceSetting)

                                        ProcessDatabaseDownloadVendorFile(DbContext, DataContext, Banks, DownloadFolder, AdvantageService, FromService)

                                        ProcessDatabaseUploadVendorFile(DbContext, DataContext, Banks, UploadFolder, AdvantageService, FromService)

                                    Else

                                        WriteToEventLog("Cannot run service because agreement has not been signed.")

                                    End If

                                End If

                            End Using

                        End Using

                    End Using

                End If

            Catch ex As Exception
                WriteToEventLog(ex.Message)
            End Try

        End Sub
        Private Sub ProcessDatabasePaymentFiles(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext,
                                                ByVal Banks As Generic.List(Of AdvantageFramework.Database.Entities.Bank), ByVal FTPFiles As Generic.List(Of String),
                                                ByVal UploadedFiles As Generic.List(Of String), ByVal FTPServer As String, ByVal FTPPort As Integer,
                                                ByVal AdvantageService As AdvantageFramework.Database.Entities.AdvantageService,
                                                ByVal UploadedFilesServiceSetting As AdvantageFramework.Database.Entities.AdvantageServiceSetting,
                                                ByVal DownloadedFilesServiceSetting As AdvantageFramework.Database.Entities.AdvantageServiceSetting)

            'objects
            Dim ErrorMessage As String = ""
            Dim ProcessPaymentFiles As Boolean = True
            Dim IsASP As Boolean = False
            Dim UploadFolder As String = ""

            IsASP = AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext)

            If IsASP Then

                UploadFolder = AdvantageFramework.Database.Procedures.Agency.LoadImportPath(DbContext)

                If My.Computer.FileSystem.DirectoryExists(UploadFolder) Then

                    UploadFolder = AdvantageFramework.StringUtilities.AppendTrailingCharacter(UploadFolder, "\")

                    UploadFolder = UploadFolder & "csi\"

                    If My.Computer.FileSystem.DirectoryExists(UploadFolder) = False Then

                        WriteToEventLog("Agency import path CSI folder does not exist. --> " & UploadFolder)
                        ProcessPaymentFiles = False

                    End If

                Else

                    WriteToEventLog("Agency import path is not valid.")
                    ProcessPaymentFiles = False

                End If

            End If

            If ProcessPaymentFiles Then

                For Each Bank In Banks

                    If IsASP = False Then

                        UploadFolder = AdvantageFramework.StringUtilities.AppendTrailingCharacter(Bank.PaymentManagerDirectory, "\")

                    End If

                    If My.Computer.FileSystem.DirectoryExists(UploadFolder) Then

                        WriteToEventLog("Uploading files")

                        For Each FileInfo In My.Computer.FileSystem.GetDirectoryInfo(UploadFolder).GetFiles

                            If FileInfo.FullName.Contains("." & Bank.PaymentManagerID & ".") AndAlso FileInfo.FullName.Contains(".PS00016.") AndAlso UploadedFiles.Contains(FileInfo.FullName) = False Then

                                WriteToEventLog("Uploading file for bank (" & Bank.Description & ") --> " & FileInfo.FullName)

                                If UploadPaymentFileToSFTP(FileInfo.FullName, If(String.IsNullOrWhiteSpace(Bank.CSITargetFolder), "/", Bank.CSITargetFolder), FTPServer, FTPPort, Bank.CSIUserName, Bank.CSIPassword, ErrorMessage) Then

                                    WriteToEventLog("file uploaded for bank (" & Bank.Description & ") --> " & FileInfo.FullName)

                                    AdvantageFramework.Services.CSIPreferredPartner.InsertUploadedFile(DataContext, AdvantageService, UploadedFilesServiceSetting, FileInfo.FullName)

                                    UploadedFiles.Add(FileInfo.FullName)

                                Else

                                    WriteToEventLog("file failed to upload for bank (" & Bank.Description & ") --> " & FileInfo.FullName)
                                    WriteToEventLog("file failed error message --> " & ErrorMessage)

                                End If

                            End If

                        Next

                    Else

                        WriteToEventLog("Cannot upload files for bank (" & Bank.Description & ") --> Directory does not exist")

                    End If

                Next

            End If

        End Sub
        Private Function UploadPaymentFileToSFTP(ByVal PaymentFile As String, ByVal TargetFolder As String, FTP As String, ByVal FTPPort As Integer, UserName As String, Password As String, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Uploaded As Boolean = False
            Dim SFTP As Rebex.Net.Sftp = Nothing

            Try

                SFTP = New Rebex.Net.Sftp

                SFTP.Timeout = 30000

                SFTP.Connect(FTP, FTPPort)

                If SFTP.IsConnected Then

                    SFTP.Login(UserName, Password)

                End If

            Catch ex As Exception

                ErrorMessage = ex.Message

                If SFTP IsNot Nothing Then

                    SFTP.Dispose()

                End If

                SFTP = Nothing

            End Try

            If SFTP IsNot Nothing AndAlso SFTP.IsAuthenticated Then

                Try

                    SFTP.Upload(PaymentFile, TargetFolder)

                    Uploaded = True

                Catch ex As Exception
                    ErrorMessage = ex.Message
                    Uploaded = False
                End Try

            End If

            UploadPaymentFileToSFTP = Uploaded

        End Function
        Private Sub ProcessDatabaseDownloadVendorFile(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext,
                                                       ByVal Banks As Generic.List(Of AdvantageFramework.Database.Entities.Bank), ByVal DownloadFolder As String,
                                                       ByVal AdvantageService As AdvantageFramework.Database.Entities.AdvantageService, ByVal FromService As Boolean)

            'objects
            Dim LastVendorDownloadRanAt As Date = Nothing
            Dim RunProcess As Boolean = False

            If FromService Then

                DateTime.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.CSIPreferredPartner.RegistrySetting.LastVendorDownloadRanAt), LastVendorDownloadRanAt)

                If DateDiff(DateInterval.Day, CDate(Now.ToShortDateString), CDate(LastVendorDownloadRanAt.ToShortDateString)) < 0 Then

                    RunProcess = True

                End If

            Else

                RunProcess = True

            End If

            If RunProcess Then

                If DownloadVendorFile(DbContext, DataContext, Banks, DownloadFolder) Then

                    If FromService Then

                        LastVendorDownloadRanAt = Now

                        SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.CSIPreferredPartner.RegistrySetting.LastVendorDownloadRanAt, LastVendorDownloadRanAt)

                    End If

                End If

            End If

        End Sub
        Private Function DownloadVendorFile(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext,
                                            ByVal Banks As Generic.List(Of AdvantageFramework.Database.Entities.Bank), ByVal DownloadFolder As String) As Boolean

            'objects
            Dim FileDownloaded As Boolean = False
            Dim CSIVendorFTP As String = ""
            Dim CSIVendorFTPPort As Integer = 0
            Dim CSIAdvantageUserName As String = ""
            Dim CSIAdvantagePassword As String = ""
            Dim LocalPath As String = ""
            Dim RecordSource As AdvantageFramework.Database.Entities.RecordSource = Nothing
            Dim FullFileName As String = ""
            Dim FileName As String = ""
            Dim IsASP As Boolean = False

            IsASP = AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext)

            If IsASP Then

                LocalPath = AdvantageFramework.Database.Procedures.Agency.LoadImportPath(DbContext)

                If My.Computer.FileSystem.DirectoryExists(LocalPath) Then

                    LocalPath = AdvantageFramework.StringUtilities.AppendTrailingCharacter(LocalPath, "\")

                    LocalPath = LocalPath & "CSI\"

                    If My.Computer.FileSystem.DirectoryExists(LocalPath) = False Then

                        Try

                            My.Computer.FileSystem.CreateDirectory(LocalPath)

                        Catch ex As Exception

                        End Try

                    End If

                    If My.Computer.FileSystem.DirectoryExists(LocalPath) Then

                        LocalPath = LocalPath & "Download\"

                        If My.Computer.FileSystem.DirectoryExists(LocalPath) = False Then

                            Try

                                My.Computer.FileSystem.CreateDirectory(LocalPath)

                            Catch ex As Exception

                            End Try

                        End If

                    End If

                    If My.Computer.FileSystem.DirectoryExists(LocalPath) = False Then

                        WriteToEventLog("Agency import path CSI download folder does not exist. --> " & LocalPath)

                    End If

                Else

                    WriteToEventLog("Agency import path is not valid.")

                End If

            Else

                LocalPath = AdvantageFramework.StringUtilities.AppendTrailingCharacter(DownloadFolder, "\")

            End If

            If My.Computer.FileSystem.DirectoryExists(LocalPath) Then

                GetCSIVendorFTPInfo(DataContext, CSIVendorFTP, CSIVendorFTPPort, CSIAdvantageUserName, CSIAdvantagePassword)

                If String.IsNullOrWhiteSpace(CSIVendorFTP) = False AndAlso String.IsNullOrWhiteSpace(CSIAdvantageUserName) = False AndAlso String.IsNullOrWhiteSpace(CSIAdvantagePassword) = False Then

                    If DownloadVendorFileFromSFTP(CSIVendorFTP, CSIVendorFTPPort, CSIAdvantageUserName, CSIAdvantagePassword, LocalPath, Banks) Then

                        FileDownloaded = True

                        Try

                            RecordSource = AdvantageFramework.Database.Procedures.RecordSource.Load(DbContext).SingleOrDefault(Function(Entity) Entity.Name = "CSI")

                        Catch ex As Exception
                            RecordSource = Nothing
                        End Try

                        For Each FullFileName In My.Computer.FileSystem.GetFiles(LocalPath)

                            FileName = ""

                            Try

                                FileName = My.Computer.FileSystem.GetName(FullFileName)

                            Catch ex As Exception
                                FileName = ""
                            End Try

                            If String.IsNullOrWhiteSpace(FileName) = False Then

                                If FileName.ToUpper.EndsWith(".CSV") AndAlso Banks.Any(Function(Entity) String.IsNullOrWhiteSpace(Entity.ComDataAccountCode) = False AndAlso FileName.StartsWith(Entity.ComDataAccountCode)) Then

                                    If ProcessDownloadedVendorFile(DbContext, DataContext, FullFileName, RecordSource) Then

                                        AdvantageFramework.Importing.RenameFileAfterImport(FullFileName, DbContext.UserCode)

                                    End If

                                End If

                            End If

                        Next

                    End If

                End If

            Else

                WriteToEventLog("download path does not exist. --> " & LocalPath)

            End If

            DownloadVendorFile = FileDownloaded

        End Function
        Private Function ProcessDownloadedVendorFile(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext,
                                                     ByVal FullFileName As String, ByVal RecordSource As AdvantageFramework.Database.Entities.RecordSource) As Boolean

            'objects
            Dim FileProcessed As Boolean = False
            Dim FileLineData() As String = Nothing
            Dim CSIVendorFile As AdvantageFramework.Services.CSIPreferredPartner.Classes.CSIVendorFile = Nothing
            Dim TextFieldParser As FileIO.TextFieldParser = Nothing
            Dim LineNumber As Integer = 1

            If String.IsNullOrWhiteSpace(FullFileName) = False AndAlso My.Computer.FileSystem.FileExists(FullFileName) Then

                Try

                    TextFieldParser = New FileIO.TextFieldParser(FullFileName)

                    TextFieldParser.TextFieldType = FileIO.FieldType.Delimited
                    TextFieldParser.Delimiters = New String() {","}
                    TextFieldParser.HasFieldsEnclosedInQuotes = True

                    Do While Not TextFieldParser.EndOfData

                        Try

                            FileLineData = TextFieldParser.ReadFields

                            If FileLineData Is Nothing OrElse (FileLineData IsNot Nothing AndAlso FileLineData.Count = 0) Then

                                Exit Do

                            End If

                            If LineNumber > 1 AndAlso FileLineData IsNot Nothing AndAlso FileLineData.Count > 0 Then

                                CSIVendorFile = New AdvantageFramework.Services.CSIPreferredPartner.Classes.CSIVendorFile()

                                CSIVendorFile.VendorName = AdvantageFramework.Importing.ScrubFileData(FileLineData(AdvantageFramework.Services.CSIPreferredPartner.Classes.CSIVendorFile.Properties.VendorName), GetType(String), False, 0, 0, 0, "", Importing.FileTypes.CSV)
                                CSIVendorFile.VendorID = AdvantageFramework.Importing.ScrubFileData(FileLineData(AdvantageFramework.Services.CSIPreferredPartner.Classes.CSIVendorFile.Properties.VendorID), GetType(String), False, 0, 0, 0, "", Importing.FileTypes.CSV)
                                CSIVendorFile.Type = AdvantageFramework.Importing.ScrubFileData(FileLineData(AdvantageFramework.Services.CSIPreferredPartner.Classes.CSIVendorFile.Properties.Type), GetType(String), False, 0, 0, 0, "", Importing.FileTypes.CSV)
                                CSIVendorFile.Address1 = AdvantageFramework.Importing.ScrubFileData(FileLineData(AdvantageFramework.Services.CSIPreferredPartner.Classes.CSIVendorFile.Properties.Address1), GetType(String), False, 0, 0, 0, "", Importing.FileTypes.CSV)
                                CSIVendorFile.Address2 = AdvantageFramework.Importing.ScrubFileData(FileLineData(AdvantageFramework.Services.CSIPreferredPartner.Classes.CSIVendorFile.Properties.Address2), GetType(String), False, 0, 0, 0, "", Importing.FileTypes.CSV)
                                CSIVendorFile.City = AdvantageFramework.Importing.ScrubFileData(FileLineData(AdvantageFramework.Services.CSIPreferredPartner.Classes.CSIVendorFile.Properties.City), GetType(String), False, 0, 0, 0, "", Importing.FileTypes.CSV)
                                CSIVendorFile.State = AdvantageFramework.Importing.ScrubFileData(FileLineData(AdvantageFramework.Services.CSIPreferredPartner.Classes.CSIVendorFile.Properties.State), GetType(String), False, 0, 0, 0, "", Importing.FileTypes.CSV)
                                CSIVendorFile.Zip = AdvantageFramework.Importing.ScrubFileData(FileLineData(AdvantageFramework.Services.CSIPreferredPartner.Classes.CSIVendorFile.Properties.Zip), GetType(String), False, 0, 0, 0, "", Importing.FileTypes.CSV)
                                CSIVendorFile.Phone = AdvantageFramework.Importing.ScrubFileData(FileLineData(AdvantageFramework.Services.CSIPreferredPartner.Classes.CSIVendorFile.Properties.Phone), GetType(String), False, 0, 0, 0, "", Importing.FileTypes.CSV)
                                CSIVendorFile.Fax = AdvantageFramework.Importing.ScrubFileData(FileLineData(AdvantageFramework.Services.CSIPreferredPartner.Classes.CSIVendorFile.Properties.Fax), GetType(String), False, 0, 0, 0, "", Importing.FileTypes.CSV)
                                CSIVendorFile.Website = AdvantageFramework.Importing.ScrubFileData(FileLineData(AdvantageFramework.Services.CSIPreferredPartner.Classes.CSIVendorFile.Properties.Website), GetType(String), False, 0, 0, 0, "", Importing.FileTypes.CSV)
                                CSIVendorFile.SICCode = AdvantageFramework.Importing.ScrubFileData(FileLineData(AdvantageFramework.Services.CSIPreferredPartner.Classes.CSIVendorFile.Properties.SICCode), GetType(String), False, 0, 0, 0, "", Importing.FileTypes.CSV)
                                CSIVendorFile.Industry = AdvantageFramework.Importing.ScrubFileData(FileLineData(AdvantageFramework.Services.CSIPreferredPartner.Classes.CSIVendorFile.Properties.Industry), GetType(String), False, 0, 0, 0, "", Importing.FileTypes.CSV)
                                CSIVendorFile.Notes = AdvantageFramework.Importing.ScrubFileData(FileLineData(AdvantageFramework.Services.CSIPreferredPartner.Classes.CSIVendorFile.Properties.Notes), GetType(String), False, 0, 0, 0, "", Importing.FileTypes.CSV)
                                CSIVendorFile.Client = AdvantageFramework.Importing.ScrubFileData(FileLineData(AdvantageFramework.Services.CSIPreferredPartner.Classes.CSIVendorFile.Properties.Client), GetType(String), False, 0, 0, 0, "", Importing.FileTypes.CSV)
                                CSIVendorFile.Status = AdvantageFramework.Importing.ScrubFileData(FileLineData(AdvantageFramework.Services.CSIPreferredPartner.Classes.CSIVendorFile.Properties.Status), GetType(String), False, 0, 0, 0, "", Importing.FileTypes.CSV)
                                CSIVendorFile.AutoEnroll = AdvantageFramework.Importing.ScrubFileData(FileLineData(AdvantageFramework.Services.CSIPreferredPartner.Classes.CSIVendorFile.Properties.AutoEnroll), GetType(String), False, 0, 0, 0, "", Importing.FileTypes.CSV)
                                CSIVendorFile.AnnualPayable = AdvantageFramework.Importing.ScrubFileData(FileLineData(AdvantageFramework.Services.CSIPreferredPartner.Classes.CSIVendorFile.Properties.AnnualPayable), GetType(String), False, 0, 0, 0, "", Importing.FileTypes.CSV)
                                CSIVendorFile.EnrollmentDate = AdvantageFramework.Importing.ScrubFileData(FileLineData(AdvantageFramework.Services.CSIPreferredPartner.Classes.CSIVendorFile.Properties.EnrollmentDate), GetType(String), False, 0, 0, 0, "", Importing.FileTypes.CSV)
                                CSIVendorFile.ReasonRemoved = AdvantageFramework.Importing.ScrubFileData(FileLineData(AdvantageFramework.Services.CSIPreferredPartner.Classes.CSIVendorFile.Properties.ReasonRemoved), GetType(String), False, 0, 0, 0, "", Importing.FileTypes.CSV)
                                CSIVendorFile.EnrollmentMethod = AdvantageFramework.Importing.ScrubFileData(FileLineData(AdvantageFramework.Services.CSIPreferredPartner.Classes.CSIVendorFile.Properties.EnrollmentMethod), GetType(String), False, 0, 0, 0, "", Importing.FileTypes.CSV)
                                CSIVendorFile.AccountOwner = AdvantageFramework.Importing.ScrubFileData(FileLineData(AdvantageFramework.Services.CSIPreferredPartner.Classes.CSIVendorFile.Properties.AccountOwner), GetType(String), False, 0, 0, 0, "", Importing.FileTypes.CSV)
                                CSIVendorFile.RemittanceContactName = AdvantageFramework.Importing.ScrubFileData(FileLineData(AdvantageFramework.Services.CSIPreferredPartner.Classes.CSIVendorFile.Properties.RemittanceContactName), GetType(String), False, 0, 0, 0, "", Importing.FileTypes.CSV)
                                CSIVendorFile.RemittancePhone = AdvantageFramework.Importing.ScrubFileData(FileLineData(AdvantageFramework.Services.CSIPreferredPartner.Classes.CSIVendorFile.Properties.RemittancePhone), GetType(String), False, 0, 0, 0, "", Importing.FileTypes.CSV)
                                CSIVendorFile.ParentCompany = AdvantageFramework.Importing.ScrubFileData(FileLineData(AdvantageFramework.Services.CSIPreferredPartner.Classes.CSIVendorFile.Properties.ParentCompany), GetType(String), False, 0, 0, 0, "", Importing.FileTypes.CSV)
                                CSIVendorFile.ContactEmail = AdvantageFramework.Importing.ScrubFileData(FileLineData(AdvantageFramework.Services.CSIPreferredPartner.Classes.CSIVendorFile.Properties.ContactEmail), GetType(String), False, 0, 0, 0, "", Importing.FileTypes.CSV)
                                CSIVendorFile.RemittanceEmail = AdvantageFramework.Importing.ScrubFileData(FileLineData(AdvantageFramework.Services.CSIPreferredPartner.Classes.CSIVendorFile.Properties.RemittanceEmail), GetType(String), False, 0, 0, 0, "", Importing.FileTypes.CSV)
                                CSIVendorFile.TaxID = AdvantageFramework.Importing.ScrubFileData(FileLineData(AdvantageFramework.Services.CSIPreferredPartner.Classes.CSIVendorFile.Properties.TaxID), GetType(String), False, 0, 0, 0, "", Importing.FileTypes.CSV)
                                CSIVendorFile.Country = AdvantageFramework.Importing.ScrubFileData(FileLineData(AdvantageFramework.Services.CSIPreferredPartner.Classes.CSIVendorFile.Properties.Country), GetType(String), False, 0, 0, 0, "", Importing.FileTypes.CSV)
                                CSIVendorFile.APGLACode = AdvantageFramework.Importing.ScrubFileData(FileLineData(AdvantageFramework.Services.CSIPreferredPartner.Classes.CSIVendorFile.Properties.APGLACode), GetType(String), False, 0, 0, 0, "", Importing.FileTypes.CSV)
                                CSIVendorFile.SpecialTerms = AdvantageFramework.Importing.ScrubFileData(FileLineData(AdvantageFramework.Services.CSIPreferredPartner.Classes.CSIVendorFile.Properties.SpecialTerms), GetType(Integer), False, 0, 0, 0, "", Importing.FileTypes.CSV)
                                CSIVendorFile.CSIVendorID = AdvantageFramework.Importing.ScrubFileData(FileLineData(AdvantageFramework.Services.CSIPreferredPartner.Classes.CSIVendorFile.Properties.CSIVendorID), GetType(String), False, 0, 0, 0, "", Importing.FileTypes.CSV)

                                ProcessCSIVendorFromDownloadedFile(DbContext, DataContext, CSIVendorFile, RecordSource)

                            End If

                        Catch ex As Exception

                        End Try

                        LineNumber += 1

                    Loop

                    TextFieldParser.Close()
                    TextFieldParser.Dispose()

                    FileProcessed = True

                Catch ex As Exception
                    FileProcessed = False
                End Try

            End If

            ProcessDownloadedVendorFile = FileProcessed

        End Function
        Private Sub ProcessCSIVendorFromDownloadedFile(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext,
                                                      ByVal CSIVendorFile As AdvantageFramework.Services.CSIPreferredPartner.Classes.CSIVendorFile, ByVal RecordSource As AdvantageFramework.Database.Entities.RecordSource)

            'objects
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim VendorCrossReference As AdvantageFramework.Database.Entities.VendorCrossReference = Nothing
            Dim VCCStatus As Short = 0
            Dim HasVendorChanged As Boolean = False

            If CSIVendorFile IsNot Nothing Then

                Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, CSIVendorFile.VendorID)

                If Vendor IsNot Nothing Then

                    If String.IsNullOrWhiteSpace(Vendor.Notes) = False AndAlso String.IsNullOrWhiteSpace(CSIVendorFile.Notes) = False Then

                        If Vendor.Notes.Trim <> CSIVendorFile.Notes.Trim Then

                            Vendor.Notes = CSIVendorFile.Notes
                            HasVendorChanged = True

                        End If

                    ElseIf String.IsNullOrWhiteSpace(Vendor.Notes) = False AndAlso String.IsNullOrWhiteSpace(CSIVendorFile.Notes) Then

                        Vendor.Notes = CSIVendorFile.Notes
                        HasVendorChanged = True

                    ElseIf String.IsNullOrWhiteSpace(Vendor.Notes) AndAlso String.IsNullOrWhiteSpace(CSIVendorFile.Notes) = False Then

                        Vendor.Notes = CSIVendorFile.Notes
                        HasVendorChanged = True

                    ElseIf String.IsNullOrWhiteSpace(Vendor.Notes) AndAlso String.IsNullOrWhiteSpace(CSIVendorFile.Notes) Then

                        Vendor.Notes = CSIVendorFile.Notes

                    End If

                    Short.TryParse(CSIVendorFile.Status, VCCStatus)

                    If Vendor.VCCStatus.GetValueOrDefault(0) <> VCCStatus Then

                        Vendor.VCCStatus = CSIVendorFile.Status
                        HasVendorChanged = True

                    End If

                    If String.IsNullOrWhiteSpace(Vendor.PaymentManagerEmailAddress) = False AndAlso String.IsNullOrWhiteSpace(CSIVendorFile.RemittanceEmail) = False Then

                        If Vendor.PaymentManagerEmailAddress.Trim <> CSIVendorFile.RemittanceEmail.Trim Then

                            Vendor.PaymentManagerEmailAddress = CSIVendorFile.RemittanceEmail
                            HasVendorChanged = True

                        End If

                    ElseIf String.IsNullOrWhiteSpace(Vendor.PaymentManagerEmailAddress) = False AndAlso String.IsNullOrWhiteSpace(CSIVendorFile.RemittanceEmail) Then

                        Vendor.PaymentManagerEmailAddress = CSIVendorFile.RemittanceEmail
                        HasVendorChanged = True

                    ElseIf String.IsNullOrWhiteSpace(Vendor.PaymentManagerEmailAddress) AndAlso String.IsNullOrWhiteSpace(CSIVendorFile.RemittanceEmail) = False Then

                        Vendor.PaymentManagerEmailAddress = CSIVendorFile.RemittanceEmail
                        HasVendorChanged = True

                    ElseIf String.IsNullOrWhiteSpace(Vendor.PaymentManagerEmailAddress) AndAlso String.IsNullOrWhiteSpace(CSIVendorFile.RemittanceEmail) Then

                        Vendor.PaymentManagerEmailAddress = CSIVendorFile.RemittanceEmail

                    End If

                    If CSIVendorFile.SpecialTerms = 1 Then

                        If Vendor.HasSpecialTerms.GetValueOrDefault(False) = False Then

                            Vendor.HasSpecialTerms = True
                            HasVendorChanged = True

                        End If

                    Else

                        If Vendor.HasSpecialTerms.GetValueOrDefault(False) = True Then

                            Vendor.HasSpecialTerms = False
                            HasVendorChanged = True

                        End If

                    End If

                    If HasVendorChanged Then

                        AdvantageFramework.Database.Procedures.Vendor.Update(DbContext, Vendor)

                    End If

                    If RecordSource IsNot Nothing Then

                        If String.IsNullOrWhiteSpace(CSIVendorFile.CSIVendorID) = False Then

                            Try

                                VendorCrossReference = AdvantageFramework.Database.Procedures.VendorCrossReference.LoadByRecordSourceID(DbContext, RecordSource.ID).SingleOrDefault(Function(Entity) Entity.VendorCode = CSIVendorFile.VendorID)

                            Catch ex As Exception
                                VendorCrossReference = Nothing
                            End Try

                            If VendorCrossReference IsNot Nothing Then

                                If VendorCrossReference.SourceVendorCode <> CSIVendorFile.CSIVendorID Then

                                    VendorCrossReference.DbContext = DbContext
                                    VendorCrossReference.SourceVendorCode = CSIVendorFile.CSIVendorID

                                    AdvantageFramework.Database.Procedures.VendorCrossReference.Update(DbContext, VendorCrossReference)

                                End If

                            Else

                                VendorCrossReference = New AdvantageFramework.Database.Entities.VendorCrossReference

                                VendorCrossReference.DbContext = DbContext
                                VendorCrossReference.VendorCode = CSIVendorFile.VendorID
                                VendorCrossReference.SourceVendorCode = CSIVendorFile.CSIVendorID
                                VendorCrossReference.RecordSourceID = RecordSource.ID

                                AdvantageFramework.Database.Procedures.VendorCrossReference.Insert(DbContext, VendorCrossReference)

                            End If

                        End If

                    End If

                End If

            End If

        End Sub
        Private Function DownloadVendorFileFromSFTP(ByVal CSIVendorFTP As String, ByVal CSIVendorFTPPort As Integer,
                                                    ByVal CSIAdvantageUserName As String, ByVal CSIAdvantagePassword As String,
                                                    ByVal LocalPath As String, ByVal Banks As Generic.List(Of AdvantageFramework.Database.Entities.Bank)) As Boolean

            'objects
            Dim Downloaded As Boolean = False
            Dim SFTP As Rebex.Net.Sftp = Nothing

            Try

                SFTP = New Rebex.Net.Sftp

                SFTP.Timeout = 30000

                SFTP.Connect(CSIVendorFTP, CSIVendorFTPPort)

                If SFTP.IsConnected Then

                    SFTP.Login(CSIAdvantageUserName, CSIAdvantagePassword)

                End If

            Catch ex As Exception

                If SFTP IsNot Nothing Then

                    SFTP.Dispose()

                End If

                SFTP = Nothing

            End Try

            If SFTP IsNot Nothing AndAlso SFTP.IsAuthenticated Then

                Try

                    For Each RebexItem In SFTP.GetList("/To_Advantage")

                        If RebexItem.IsFile AndAlso RebexItem.Name.ToUpper.EndsWith(".CSV") AndAlso Banks.Where(Function(Entity) Entity.ComDataAccountCode <> "").Any(Function(Entity) RebexItem.Name.StartsWith(Entity.ComDataAccountCode)) Then

                            SFTP.Download(RebexItem.Path, LocalPath)

                            SFTP.DeleteFile(RebexItem.Path)

                        End If

                    Next

                    Downloaded = True

                Catch ex As Exception
                    Downloaded = False
                End Try

            End If

            DownloadVendorFileFromSFTP = Downloaded

        End Function
        Private Sub ProcessDatabaseUploadVendorFile(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext,
                                                    ByVal Banks As Generic.List(Of AdvantageFramework.Database.Entities.Bank), ByVal UploadFolder As String,
                                                    ByVal AdvantageService As AdvantageFramework.Database.Entities.AdvantageService, ByVal FromService As Boolean)

            'objects
            Dim LastVendorUploadRanAt As Date = Nothing
            Dim RunProcess As Boolean = False

            If FromService Then

                DateTime.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.CSIPreferredPartner.RegistrySetting.LastVendorUploadRanAt), LastVendorUploadRanAt)

                If DateDiff(DateInterval.Day, CDate(Now.ToShortDateString), CDate(LastVendorUploadRanAt.ToShortDateString)) < 0 Then

                    RunProcess = True

                End If

            Else

                RunProcess = True

            End If

            If RunProcess Then

                If UploadVendorFile(DbContext, DataContext, Banks, UploadFolder) Then

                    If FromService Then

                        LastVendorUploadRanAt = Now

                        SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.CSIPreferredPartner.RegistrySetting.LastVendorUploadRanAt, LastVendorUploadRanAt)

                    End If

                End If

            End If

        End Sub
        Private Function UploadVendorFile(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext,
                                          ByVal Banks As Generic.List(Of AdvantageFramework.Database.Entities.Bank), ByVal UploadFolder As String) As Boolean

            'objects
            Dim FileUploaded As Boolean = False
            Dim PropertyDescriptors As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing
            Dim CSIVendorFiles As Generic.List(Of AdvantageFramework.Services.CSIPreferredPartner.Classes.CSIVendorFile) = Nothing
            Dim CheckRegisters As Generic.List(Of AdvantageFramework.Database.Entities.CheckRegister) = Nothing
            Dim StringBuilder As System.Text.StringBuilder = Nothing
            Dim Data As String = ""
            Dim LineData As String = ""
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim FullFileName As String = ""
            Dim PropertyValue As Object = Nothing
            Dim AnnualPayable As Decimal = 0
            Dim StartDate As Date = Nothing
            Dim EndDate As Date = Nothing
            Dim RecordSource As AdvantageFramework.Database.Entities.RecordSource = Nothing
            Dim VendorCrossReferences As Generic.List(Of AdvantageFramework.Database.Entities.VendorCrossReference) = Nothing
            Dim VendorCrossReference As AdvantageFramework.Database.Entities.VendorCrossReference = Nothing
            Dim CSIVendorFTP As String = ""
            Dim CSIVendorFTPPort As Integer = 0
            Dim CSIAdvantageUserName As String = ""
            Dim CSIAdvantagePassword As String = ""
            Dim LocalPath As String = ""
            Dim IsASP As Boolean = False
            Dim Vendors As Generic.List(Of AdvantageFramework.Database.Entities.Vendor) = Nothing
            Dim VendorHistories As Generic.List(Of AdvantageFramework.Database.Entities.VendorHistory) = Nothing
            Dim PayToVendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim VendorHistory As AdvantageFramework.Database.Entities.VendorHistory = Nothing
            Dim NumberOfTransactions As Integer = 0

            IsASP = AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext)

            If IsASP Then

                LocalPath = AdvantageFramework.Database.Procedures.Agency.LoadImportPath(DbContext)

                If My.Computer.FileSystem.DirectoryExists(LocalPath) Then

                    LocalPath = AdvantageFramework.StringUtilities.AppendTrailingCharacter(LocalPath, "\")

                    LocalPath = LocalPath & "CSI\"

                    If My.Computer.FileSystem.DirectoryExists(LocalPath) = False Then

                        Try

                            My.Computer.FileSystem.CreateDirectory(LocalPath)

                        Catch ex As Exception

                        End Try

                    End If

                    If My.Computer.FileSystem.DirectoryExists(LocalPath) Then

                        LocalPath = LocalPath & "Upload\"

                        If My.Computer.FileSystem.DirectoryExists(LocalPath) = False Then

                            Try

                                My.Computer.FileSystem.CreateDirectory(LocalPath)

                            Catch ex As Exception

                            End Try

                        End If

                    End If

                    If My.Computer.FileSystem.DirectoryExists(LocalPath) = False Then

                        WriteToEventLog("Agency import path CSI upload folder does not exist. --> " & LocalPath)

                    End If

                Else

                    WriteToEventLog("Agency import path is not valid.")

                End If

            Else

                LocalPath = AdvantageFramework.StringUtilities.AppendTrailingCharacter(UploadFolder, "\")

            End If

            If My.Computer.FileSystem.DirectoryExists(LocalPath) Then

                Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                If Agency IsNot Nothing Then

                    PropertyDescriptors = System.ComponentModel.TypeDescriptor.GetProperties(GetType(AdvantageFramework.Services.CSIPreferredPartner.Classes.CSIVendorFile)).OfType(Of System.ComponentModel.PropertyDescriptor).ToList

                    CSIVendorFiles = New Generic.List(Of AdvantageFramework.Services.CSIPreferredPartner.Classes.CSIVendorFile)

                    StartDate = Now.AddYears(-1)
                    EndDate = Now

                    CheckRegisters = AdvantageFramework.Database.Procedures.CheckRegister.Load(DbContext).Where(Function(Entity) Entity.CheckDate >= StartDate AndAlso Entity.CheckDate <= EndDate).ToList
                    VendorHistories = AdvantageFramework.Database.Procedures.VendorHistory.Load(DbContext).Where(Function(Entity) Entity.Action = "NEW").ToList

                    Try

                        RecordSource = AdvantageFramework.Database.Procedures.RecordSource.Load(DbContext).SingleOrDefault(Function(Entity) Entity.Name = "CSI")

                        If RecordSource IsNot Nothing Then

                            VendorCrossReferences = AdvantageFramework.Database.Procedures.VendorCrossReference.LoadByRecordSourceID(DbContext, RecordSource.ID).ToList

                        End If

                    Catch ex As Exception
                        VendorCrossReferences = New Generic.List(Of AdvantageFramework.Database.Entities.VendorCrossReference)
                    End Try

                    Vendors = AdvantageFramework.Database.Procedures.Vendor.Load(DbContext).ToList

                    For Each Vendor In Vendors.Where(Function(Entity) Entity.ActiveFlag = 1).ToList

                        AnnualPayable = 0
                        VendorCrossReference = Nothing
                        VendorHistory = Nothing
                        PayToVendor = Nothing
                        NumberOfTransactions = 0

                        Try

                            AnnualPayable = CheckRegisters.Where(Function(Entity) Entity.PayToVenderCode = Vendor.Code).Select(Function(Entity) Entity.CheckAmount.GetValueOrDefault(0)).Sum

                        Catch ex As Exception
                            AnnualPayable = 0
                        End Try

                        Try

                            VendorCrossReference = VendorCrossReferences.SingleOrDefault(Function(Entity) Entity.VendorCode = Vendor.Code)

                        Catch ex As Exception
                            VendorCrossReference = Nothing
                        End Try

                        Try

                            VendorHistory = VendorHistories.SingleOrDefault(Function(Entity) Entity.Code = Vendor.Code)

                        Catch ex As Exception
                            VendorHistory = Nothing
                        End Try

                        If String.IsNullOrWhiteSpace(Vendor.PayToCode) = False AndAlso Vendor.PayToCode <> Vendor.Code Then

                            Try

                                PayToVendor = Vendors.SingleOrDefault(Function(Entity) Entity.Code = Vendor.PayToCode)

                            Catch ex As Exception
                                PayToVendor = Nothing
                            End Try

                        End If

                        Try

                            NumberOfTransactions = AdvantageFramework.Database.Procedures.AccountPayable.LoadByVendor(DbContext, Vendor.Code).Select(Function(Entity) Entity.ID).Distinct.Count

                        Catch ex As Exception
                            NumberOfTransactions = 0
                        End Try

                        CSIVendorFiles.Add(New AdvantageFramework.Services.CSIPreferredPartner.Classes.CSIVendorFile(Vendor, PayToVendor, VendorHistory, VendorCrossReference, AnnualPayable, NumberOfTransactions))

                    Next

                    For Each ComDataAccountCode In Banks.Select(Function(Entity) Entity.ComDataAccountCode).Distinct.ToList

                        If String.IsNullOrWhiteSpace(ComDataAccountCode) = False Then

                            StringBuilder = New System.Text.StringBuilder

                            LineData = ""

                            For Each PropertyDescriptor In PropertyDescriptors

                                Data = ""
                                PropertyValue = Nothing

                                Try

                                    PropertyValue = PropertyDescriptor.DisplayName

                                Catch ex As Exception
                                    PropertyValue = Nothing
                                End Try

                                If IsNothing(PropertyValue) = False Then

                                    Data = PropertyValue.ToString

                                End If

                                If Data.Contains(",") OrElse Data.Contains("""") Then

                                    Data = """" & Data.Replace("""", """""") & """"

                                End If

                                If LineData = "" Then

                                    LineData = Data

                                Else

                                    LineData = LineData & "," & Data

                                End If

                            Next

                            StringBuilder.AppendLine(LineData)

                            For Each CSIVendorFile In CSIVendorFiles

                                LineData = ""

                                For Each PropertyDescriptor In PropertyDescriptors

                                    Data = ""
                                    PropertyValue = Nothing

                                    Try

                                        PropertyValue = PropertyDescriptor.GetValue(CSIVendorFile)

                                    Catch ex As Exception
                                        PropertyValue = Nothing
                                    End Try

                                    If IsNothing(PropertyValue) = False Then

                                        Data = PropertyValue.ToString

                                    End If

                                    Data = AdvantageFramework.StringUtilities.RemoveAllLineBreaks(Data)

                                    If Data.Contains(",") OrElse Data.Contains("""") Then

                                        Data = """" & Data.Replace("""", """""") & """"

                                    End If

                                    If LineData = "" Then

                                        LineData = Data

                                    Else

                                        LineData = LineData & "," & Data

                                    End If

                                Next

                                StringBuilder.AppendLine(LineData)

                            Next

                            FullFileName = AdvantageFramework.StringUtilities.AppendTrailingCharacter(LocalPath, "\") & ComDataAccountCode & ".csv"

                            Try

                                My.Computer.FileSystem.WriteAllText(FullFileName, StringBuilder.ToString, False)

                            Catch ex As Exception

                            End Try

                            If My.Computer.FileSystem.FileExists(FullFileName) Then

                                GetCSIVendorFTPInfo(DataContext, CSIVendorFTP, CSIVendorFTPPort, CSIAdvantageUserName, CSIAdvantagePassword)

                                If String.IsNullOrWhiteSpace(CSIVendorFTP) = False AndAlso String.IsNullOrWhiteSpace(CSIAdvantageUserName) = False AndAlso String.IsNullOrWhiteSpace(CSIAdvantagePassword) = False Then

                                    FileUploaded = UploadVendorFileToSFTP(FullFileName, CSIVendorFTP, CSIVendorFTPPort, CSIAdvantageUserName, CSIAdvantagePassword)

                                End If

                            End If

                        End If

                    Next

                End If

            Else

                WriteToEventLog("upload path does not exist. --> " & LocalPath)

            End If

            UploadVendorFile = FileUploaded

        End Function
        Private Function UploadVendorFileToSFTP(ByVal VendorFile As String, CSIVendorFTP As String, ByVal CSIVendorFTPPort As Integer, CSIAdvantageUserName As String, CSIAdvantagePassword As String) As Boolean

            'objects
            Dim Uploaded As Boolean = False
            Dim SFTP As Rebex.Net.Sftp = Nothing

            Try

                SFTP = New Rebex.Net.Sftp

                SFTP.Timeout = 30000

                SFTP.Connect(CSIVendorFTP, CSIVendorFTPPort)

                If SFTP.IsConnected Then

                    SFTP.Login(CSIAdvantageUserName, CSIAdvantagePassword)

                End If

            Catch ex As Exception

                If SFTP IsNot Nothing Then

                    SFTP.Dispose()

                End If

                SFTP = Nothing

            End Try

            If SFTP IsNot Nothing AndAlso SFTP.IsAuthenticated Then

                Try

                    SFTP.Upload(VendorFile, "/uploads")

                    Uploaded = True

                Catch ex As Exception
                    Uploaded = False
                End Try

            End If

            UploadVendorFileToSFTP = Uploaded

        End Function
        Private Sub GetCSIVendorFTPInfo(ByVal DataContext As AdvantageFramework.Database.DataContext,
                                        ByRef CSIVendorFTP As String, ByRef CSIVendorFTPPort As Integer,
                                        ByRef CSIAdvantageUserName As String, ByRef CSIAdvantagePassword As String)

            'objects
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim FTPString As String = ""

            Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.CSI_VENDOR_FTP_USER.ToString)

            If Setting IsNot Nothing Then

                CSIAdvantageUserName = Setting.Value

            End If

            Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.CSI_VENDOR_FTP_PW.ToString)

            If Setting IsNot Nothing Then

                CSIAdvantagePassword = Setting.Value

            End If

            Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.CSI_VENDOR_FTP.ToString)

            If Setting IsNot Nothing Then

                FTPString = Setting.Value

                If FTPString.Contains(":") Then

                    CSIVendorFTP = FTPString.Split(":")(0)

                    If IsNumeric(FTPString.Split(":")(1)) Then

                        CSIVendorFTPPort = FTPString.Split(":")(1)

                    End If

                Else

                    CSIVendorFTP = FTPString

                End If

            End If

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

                                WriteToEventLog("Service Enabled")

                                DateTime.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.CSIPreferredPartner.RegistrySetting.LastRanAt), LastRanAt)

                                LastRanAt = LastRanAt.AddMinutes(5)

                                If DateDiff(DateInterval.Minute, LastRanAt, Now) >= 0 Then

                                    LastRanAt = Now

                                    SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.CSIPreferredPartner.RegistrySetting.LastRanAt, LastRanAt)

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

                        WriteToEventLog("Running from Service")

                        ProcessDatabase(DatabaseProfile, True)

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

            If System.Diagnostics.EventLog.SourceExists("CSI Preferred Partner Source") = False Then

                System.Diagnostics.EventLog.CreateEventSource("CSI Preferred Partner Source", "CSI Preferred Partner Log")

            End If

            _EventLog = New System.Diagnostics.EventLog("CSI Preferred Partner Log", My.Computer.Name, "CSI Preferred Partner Source")

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

                AdvantageService = AdvantageFramework.Services.LoadAdvantageService(DataContext, AdvantageFramework.Services.Service.AdvantageCSIPreferredPartnerWindowsService)

            Catch ex As Exception
                AdvantageService = Nothing
            End Try

            LoadAdvantageService = AdvantageService

        End Function
        Public Function LoadAdvantageServiceSetting(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AdvantageServiceID As Integer, ByVal RegistrySetting As AdvantageFramework.Services.CSIPreferredPartner.RegistrySetting) As AdvantageFramework.Database.Entities.AdvantageServiceSetting

            'objects
            Dim AdvantageServiceSetting As AdvantageFramework.Database.Entities.AdvantageServiceSetting = Nothing

            Try

                AdvantageServiceSetting = AdvantageFramework.Services.LoadAdvantageServiceSetting(DataContext, AdvantageServiceID, RegistrySetting.ToString)

            Catch ex As Exception
                AdvantageServiceSetting = Nothing
            End Try

            LoadAdvantageServiceSetting = AdvantageServiceSetting

        End Function
        Public Function LoadAdvantageServiceSettingValue(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AdvantageServiceID As Integer, ByVal RegistrySetting As AdvantageFramework.Services.CSIPreferredPartner.RegistrySetting) As Object

            'objects
            Dim SettingValue As Object = Nothing

            Try

                SettingValue = AdvantageFramework.Services.LoadAdvantageServiceSettingValue(DataContext, AdvantageServiceID, RegistrySetting.ToString)

            Catch ex As Exception
                SettingValue = Nothing
            End Try

            LoadAdvantageServiceSettingValue = SettingValue

        End Function
        Public Function SaveAdvantageServiceSettingValue(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AdvantageServiceID As Integer, ByVal RegistrySetting As AdvantageFramework.Services.CSIPreferredPartner.RegistrySetting, ByVal SettingValue As Object) As Boolean

            'objects
            Dim Saved As Boolean = False

            Try

                Saved = AdvantageFramework.Services.SaveAdvantageServiceSettingValue(DataContext, AdvantageServiceID, RegistrySetting.ToString, SettingValue)

            Catch ex As Exception
                Saved = False
            End Try

            SaveAdvantageServiceSettingValue = Saved

        End Function
        Public Sub LoadSettings(ByVal DataContext As AdvantageFramework.Database.DataContext, ByRef DownloadFolder As String, ByRef UploadFolder As String, Optional ByRef LastRanAt As Date = Nothing)

            'objects
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing

            AdvantageService = LoadAdvantageService(DataContext)

            If AdvantageService IsNot Nothing Then

                DateTime.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.CSIPreferredPartner.RegistrySetting.LastRanAt), LastRanAt)

                DownloadFolder = LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.CSIPreferredPartner.RegistrySetting.DownloadFolder)

                UploadFolder = LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.CSIPreferredPartner.RegistrySetting.UploadFolder)

            End If

        End Sub
        Public Sub SaveSettings(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal DownloadFolder As String, ByRef UploadFolder As String)

            'objects
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing

            AdvantageService = LoadAdvantageService(DataContext)

            If AdvantageService IsNot Nothing Then

                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.CSIPreferredPartner.RegistrySetting.DownloadFolder, DownloadFolder)
                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.CSIPreferredPartner.RegistrySetting.UploadFolder, UploadFolder)

            End If

        End Sub
        Public Function InsertUploadedFile(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal UploadedFile As String) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing
            Dim AdvantageServiceSetting As AdvantageFramework.Database.Entities.AdvantageServiceSetting = Nothing

            If DataContext IsNot Nothing Then

                AdvantageService = LoadAdvantageService(DataContext)

                If AdvantageService IsNot Nothing Then

                    AdvantageServiceSetting = LoadAdvantageServiceSetting(DataContext, AdvantageService.ID, RegistrySetting.UploadedFiles)

                    If AdvantageServiceSetting IsNot Nothing Then

                        Inserted = InsertUploadedFile(DataContext, AdvantageService, AdvantageServiceSetting, UploadedFile)

                    End If

                End If

            End If

            InsertUploadedFile = Inserted

        End Function
        Public Function InsertUploadedFile(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AdvantageService As AdvantageFramework.Database.Entities.AdvantageService,
                                           ByVal AdvantageServiceSetting As AdvantageFramework.Database.Entities.AdvantageServiceSetting, ByVal UploadedFile As String) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim AdvantageServiceSettingList As AdvantageFramework.Database.Entities.AdvantageServiceSettingList = Nothing

            If DataContext IsNot Nothing Then

                If AdvantageService IsNot Nothing Then

                    If AdvantageServiceSetting IsNot Nothing AndAlso AdvantageServiceSetting.Code = RegistrySetting.UploadedFiles.ToString Then

                        AdvantageServiceSettingList = New AdvantageFramework.Database.Entities.AdvantageServiceSettingList

                        AdvantageServiceSettingList.AdvantageServiceSettingID = AdvantageServiceSetting.ID
                        AdvantageServiceSettingList.Value = UploadedFile

                        Inserted = AdvantageFramework.Database.Procedures.AdvantageServiceSettingList.Insert(DataContext, AdvantageServiceSettingList)

                    End If

                End If

            End If

            InsertUploadedFile = Inserted

        End Function
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

