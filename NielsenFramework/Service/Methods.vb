Namespace Service

    <HideModuleName()>
    Public Module Methods

#Region " Constants "

        Private Const BLANK_QUALITATIVE_CODE As String = "All"

#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Sub Start(ConnectionString As String)

            Using NielsenDbContext As New NielsenFramework.Database.NielsenDbContext(ConnectionString)

                NielsenDbContext.Database.ExecuteSqlCommand("DELETE dbo.SERVICE_STATUS")

            End Using

        End Sub
        Public Sub LogEvent(ConnectionString As String, EventMessage As String)

            'objects
            Dim EventLog As NielsenFramework.Database.Entities.EventLog = Nothing

            Using NielsenDbContext As New NielsenFramework.Database.NielsenDbContext(ConnectionString)

                EventLog = New NielsenFramework.Database.Entities.EventLog
                EventLog.EventDateTime = Now
                EventLog.EventMessage = EventMessage

                NielsenDbContext.EventLogs.Add(EventLog)
                NielsenDbContext.SaveChanges()

            End Using

        End Sub
        Public Sub SaveSettings(ConnectionString As String, TVSpotPath As String, TVNationalPath As String, RadioSpotPath As String, TimerMinutes As Integer, NCCDataPath As String)

            'objects
            Dim ServiceSetting As NielsenFramework.Database.Entities.ServiceSetting = Nothing

            Using NielsenDbContext As New NielsenFramework.Database.NielsenDbContext(ConnectionString)

                ServiceSetting = NielsenFramework.Database.Procedures.ServiceSetting.LoadSingleRecord(NielsenDbContext)

                If ServiceSetting Is Nothing Then

                    ServiceSetting = New NielsenFramework.Database.Entities.ServiceSetting

                    ServiceSetting.ID = 1
                    ServiceSetting.TVSpotPath = TVSpotPath
                    ServiceSetting.TVNationalPath = TVNationalPath
                    ServiceSetting.RadioSpotPath = RadioSpotPath
                    ServiceSetting.TimerMinutes = TimerMinutes
                    ServiceSetting.NCCDataPath = NCCDataPath

                    NielsenDbContext.ServiceSettings.Add(ServiceSetting)

                Else

                    ServiceSetting.TVSpotPath = TVSpotPath
                    ServiceSetting.TVNationalPath = TVNationalPath
                    ServiceSetting.RadioSpotPath = RadioSpotPath
                    ServiceSetting.TimerMinutes = TimerMinutes
                    ServiceSetting.NCCDataPath = NCCDataPath

                    NielsenDbContext.Entry(ServiceSetting).State = Entity.EntityState.Modified

                End If

                NielsenDbContext.SaveChanges()

            End Using

        End Sub
        Public Function CanSqlConnect(ConnectionString As String) As Boolean

            'objects
            Dim CanConnect As Boolean = False
            Dim _SqlConnection As SqlClient.SqlConnection = Nothing

            Try

                _SqlConnection = New SqlClient.SqlConnection(ConnectionString)
                _SqlConnection.Open()

                CanConnect = True

            Catch ex As Exception

            End Try

            CanSqlConnect = CanConnect

        End Function
        Public Function SetServiceToRun(ConnectionString As String) As Boolean

            'objects
            Dim ServiceStatus As NielsenFramework.Database.Entities.ServiceStatus = Nothing
            Dim ServiceSet As Boolean = False

            Using NielsenDbContext As New Database.NielsenDbContext(ConnectionString)

                ServiceStatus = NielsenFramework.Database.Procedures.ServiceStatus.LoadSingleRecord(NielsenDbContext)

                If ServiceStatus IsNot Nothing AndAlso Not ServiceStatus.IsRunning Then

                    NielsenDbContext.Database.ExecuteSqlCommand("UPDATE dbo.SERVICE_STATUS SET LAST_RAN = DATEADD(d, -1, cast(getdate() as date)) WHERE IS_RUNNING = 0")

                    ServiceSet = True

                End If

            End Using

            SetServiceToRun = ServiceSet

        End Function
        Public Sub SyncFilesFromNielsen(TV_Spot_Path As String, TV_National_Path As String, Radio_Spot_Path As String, ConnectionString As String, NCC_Data_Path As String, Eastlan_Path As String)

            'objects
            Dim ServiceStatus As NielsenFramework.Database.Entities.ServiceStatus = Nothing
            Dim ProcessStartInfo As System.Diagnostics.ProcessStartInfo = Nothing
            Dim Process As System.Diagnostics.Process = Nothing
            Dim NdsClientCommand As String = Nothing
            Dim RunService As Boolean = False
            Dim ErrorMessage As String = Nothing
            Dim DownloadedFiles As Generic.List(Of String) = Nothing

            Using NielsenDbContext As New Database.NielsenDbContext(ConnectionString)

                Try

                    ServiceStatus = NielsenFramework.Database.Procedures.ServiceStatus.LoadSingleRecord(NielsenDbContext)

                    If ServiceStatus Is Nothing Then

                        ServiceStatus = New NielsenFramework.Database.Entities.ServiceStatus
                        ServiceStatus.ID = 1
                        ServiceStatus.LastRan = Now
                        ServiceStatus.IsRunning = True

                        If NielsenFramework.Database.Procedures.ServiceStatus.Insert(NielsenDbContext, ServiceStatus, ErrorMessage) = False Then

                            Throw New Exception(ErrorMessage)

                        End If

                        RunService = True

                    ElseIf ServiceStatus.IsRunning = False AndAlso DateDiff(DateInterval.Hour, ServiceStatus.LastRan, Now) >= 24 Then

                        ServiceStatus.LastRan = Now
                        ServiceStatus.IsRunning = True

                        If NielsenFramework.Database.Procedures.ServiceStatus.Update(NielsenDbContext, ServiceStatus, ErrorMessage) = False Then

                            Throw New Exception(ErrorMessage)

                        End If

                        RunService = True

                    End If

                    If RunService Then

                        'spot tv
                        'LogEvent(ConnectionString, "Syncing spot tv files with Nielsen")

                        'ProcessStartInfo = New ProcessStartInfo

                        'NdsClientCommand = "--pkcs12-cert " & If(PFX_PATH.EndsWith("\"), PFX_PATH, PFX_PATH & "\") & "AdvantageNDS.pfx --pkcs12-password NDS --auto-unzip --output-directory " & TV_Spot_Path & " https://nds.nielsenmedia.com/nds/LOCMTHLY/rss1-full.xml"

                        'LogEvent(ConnectionString, "command line parameters: " & NdsClientCommand)

                        'ProcessStartInfo.WorkingDirectory = NDS_Client_Bin_Path
                        'ProcessStartInfo.FileName = System.IO.Path.Combine(NDS_Client_Bin_Path, "nds-client.bat")
                        'ProcessStartInfo.Arguments = NdsClientCommand
                        'ProcessStartInfo.UseShellExecute = False

                        'Process = System.Diagnostics.Process.Start(ProcessStartInfo)

                        'While Not Process.HasExited

                        'End While

                        'national tv
                        'LogEvent(ConnectionString, "Syncing national tv files with Nielsen")

                        'NdsClientCommand = "--pkcs12-cert " & If(PFX_PATH.EndsWith("\"), PFX_PATH, PFX_PATH & "\") & "AdvantageNDS.pfx  --pkcs12-password NDS --auto-unzip --output-directory " & TV_National_Path & " https://nds.nielsenmedia.com/nds/MITLIB/rss1-full.xml"

                        'LogEvent(ConnectionString, "command line parameters: " & NdsClientCommand)

                        'ProcessStartInfo.WorkingDirectory = _NDS_Client_Bin_Path
                        'ProcessStartInfo.FileName = System.IO.Path.Combine(_NDS_Client_Bin_Path, "nds-client.bat")
                        'ProcessStartInfo.Arguments = NdsClientCommand
                        'ProcessStartInfo.UseShellExecute = False

                        'Process = System.Diagnostics.Process.Start(ProcessStartInfo)

                        'While Not Process.HasExited

                        'End While

                        LogEvent(ConnectionString, "Unzipping spot tv files")
                        UnzipSpotTVFiles(TV_Spot_Path)

                        LogEvent(ConnectionString, "Saving spot tv files to DOWNLOAD_FILE table")
                        SaveMonthlyFiles(NielsenDbContext, TV_Spot_Path)

                        'LogEvent(ConnectionString, "Saving national tv files to DOWNLOAD_FILE table")
                        'SaveNationalFiles(NielsenDbContext)

                        LogEvent(ConnectionString, "Unzipping spot radio files")
                        UnzipRadioFiles(Radio_Spot_Path)

                        LogEvent(ConnectionString, "Saving spot radio files to DOWNLOAD_FILE table")
                        SaveRadioFiles(NielsenDbContext, Radio_Spot_Path)

                        If System.IO.Directory.Exists(System.IO.Path.Combine(Radio_Spot_Path, "County")) Then

                            LogEvent(ConnectionString, "Saving radio county files to DOWNLOAD_FILE table")
                            SaveRadioCountyFiles(NielsenDbContext, System.IO.Path.Combine(Radio_Spot_Path, "County"))

                        End If

                        LogEvent(ConnectionString, "Downloading NCC files from FTP")
                        If Not DownloadNCCFiles(NCC_Data_Path, "ftp.spotcable.com", 21, "adsoftware", "YGV#2612", DownloadedFiles, ErrorMessage) Then

                            LogEvent(ConnectionString, ErrorMessage)

                        End If

                        'LogEvent(ConnectionString, "Unzipping NCC Survey files")
                        'UnzipNCCSurveyFiles(System.IO.Path.Combine(NCC_Data_Path, "Survey_CSV"))

                        LogEvent(ConnectionString, "Saving NCC files to DOWNLOAD_FILE table")
                        SaveNCCFiles(NielsenDbContext, NCC_Data_Path, "*.txt", True)
                        SaveNCCFiles(NielsenDbContext, NCC_Data_Path, "*.xls", True)

                        For Each Directory In System.IO.Directory.GetDirectories(System.IO.Path.Combine(NCC_Data_Path, "AIEU"))

                            SaveNCCFiles(NielsenDbContext, Directory, "*.txt", False)

                        Next

                        'For Each Directory In System.IO.Directory.GetDirectories(System.IO.Path.Combine(NCC_Data_Path, "Survey_CSV"))

                        '    SaveNCCFiles(NielsenDbContext, Directory, "*.CSV", False)

                        'Next

                        LogEvent(ConnectionString, "Saving Eastlan radio files to DOWNLOAD_FILE table")
                        SaveEastlanRadioFiles(NielsenDbContext, Eastlan_Path)

                        LogEvent(ConnectionString, "Calling ProcessFiles")
                        ProcessFiles(NielsenDbContext, ConnectionString, Radio_Spot_Path, TV_Spot_Path, TV_National_Path, NCC_Data_Path, Eastlan_Path)

                        LogEvent(ConnectionString, "Calling ReProcessTVSpotFiles")
                        ReProcessTVSpotFiles(NielsenDbContext, ConnectionString, TV_Spot_Path)

                        LogEvent(ConnectionString, "ProcessFiles complete")

                    End If

                Catch ex As Exception

                    LogEvent(ConnectionString, ex.Message & If(ex.InnerException IsNot Nothing, " Inner Exception:" & ex.InnerException.Message, ""))

                Finally

                    If RunService Then

                        NielsenDbContext.Database.ExecuteSqlCommand("UPDATE dbo.SERVICE_STATUS SET IS_RUNNING = 0")

                    End If

                End Try

            End Using

        End Sub
        Private Sub SaveMonthlyFiles(NielsenDbContext As Database.NielsenDbContext, TV_Spot_Path As String)

            'objects
            Dim DownloadFile As Database.Entities.DownloadFile = Nothing
            Dim LastWriteTime As Date = Nothing

            For Each Filename In System.IO.Directory.GetFiles(TV_Spot_Path)

                LastWriteTime = System.IO.File.GetLastWriteTime(Filename).AddMilliseconds(-System.IO.File.GetLastWriteTime(Filename).Millisecond)

                Filename = System.IO.Path.GetFileName(Filename)

                If Filename.ToLower.EndsWith(".txt") AndAlso Filename.ToUpper.StartsWith("NSI") AndAlso Not Filename.ToUpper.Contains("DPOPT") Then

                    DownloadFile = NielsenFramework.Database.Procedures.DownloadFile.LoadByFileName(NielsenDbContext, Filename)

                    If DownloadFile Is Nothing Then

                        DownloadFile = New Database.Entities.DownloadFile
                        DownloadFile.DbContext = NielsenDbContext

                        DownloadFile.FileName = Filename
                        DownloadFile.FileType = Database.Entities.Methods.DownloadFileType.TVSpot
                        DownloadFile.LastWriteTime = LastWriteTime

                        NielsenDbContext.DownloadFiles.Add(DownloadFile)

                        'ElseIf DownloadFile.LastWriteTime < LastWriteTime AndAlso Datediff(DateInterval.Second, DownloadFile.LastWriteTime, LastWriteTime) <> 0 Then

                        '    DownloadFile.LastWriteTime = LastWriteTime
                        '    DownloadFile.ProcessedTime = Nothing
                        '    NielsenDbContext.Entry(DownloadFile).State = Entity.EntityState.Modified

                    End If

                End If

            Next

            NielsenDbContext.SaveChanges()

        End Sub
        Private Sub UnzipSpotTVFiles(TV_Spot_Path As String)

            'objects
            Dim ZipFile As Ionic.Zip.ZipFile = Nothing
            Dim ZipEntry As Ionic.Zip.ZipEntry = Nothing
            Dim FileInfo As System.IO.FileInfo = Nothing

            For Each Filename In System.IO.Directory.GetFiles(TV_Spot_Path)

                Filename = System.IO.Path.GetFileName(Filename)

                If Filename.ToLower.EndsWith(".zip") Then

                    Try

                        ZipFile = Ionic.Zip.ZipFile.Read(System.IO.Path.Combine(TV_Spot_Path, Filename))

                        For Each ZipEntry In ZipFile

                            If Not System.IO.File.Exists(System.IO.Path.Combine(TV_Spot_Path, ZipEntry.FileName)) Then

                                ZipEntry.Extract(TV_Spot_Path)

                            Else

                                FileInfo = New System.IO.FileInfo(System.IO.Path.Combine(TV_Spot_Path, ZipEntry.FileName))

                                If ZipEntry.LastModified > FileInfo.LastWriteTime Then

                                    ZipEntry.Extract(TV_Spot_Path, Ionic.Zip.ExtractExistingFileAction.OverwriteSilently)

                                End If

                            End If

                        Next

                        ZipFile.Dispose()

                        System.IO.File.Delete(System.IO.Path.Combine(TV_Spot_Path, Filename))

                    Catch ex As Exception
                        Throw ex
                    Finally

                        If ZipFile IsNot Nothing Then

                            ZipFile.Dispose()
                            ZipFile = Nothing

                        End If

                    End Try

                End If

            Next

        End Sub
        Private Sub UnzipRadioFiles(Radio_Spot_Path As String)

            'objects
            Dim ZipFile As Ionic.Zip.ZipFile = Nothing
            Dim ZipEntry As Ionic.Zip.ZipEntry = Nothing
            Dim FileInfo As System.IO.FileInfo = Nothing

            For Each Filename In System.IO.Directory.GetFiles(Radio_Spot_Path)

                Filename = System.IO.Path.GetFileName(Filename)

                If Filename.ToLower.EndsWith(".zip") Then

                    Try

                        ZipFile = Ionic.Zip.ZipFile.Read(System.IO.Path.Combine(Radio_Spot_Path, Filename))

                        For Each ZipEntry In ZipFile

                            If Not System.IO.File.Exists(System.IO.Path.Combine(Radio_Spot_Path, ZipEntry.FileName)) Then

                                ZipEntry.Extract(Radio_Spot_Path)

                            Else

                                FileInfo = New System.IO.FileInfo(System.IO.Path.Combine(Radio_Spot_Path, ZipEntry.FileName))

                                If ZipEntry.LastModified > FileInfo.LastWriteTime Then

                                    ZipEntry.Extract(Radio_Spot_Path, Ionic.Zip.ExtractExistingFileAction.OverwriteSilently)

                                End If

                            End If

                        Next

                        ZipFile.Dispose()

                        System.IO.File.Delete(System.IO.Path.Combine(Radio_Spot_Path, Filename))

                    Catch ex As Exception
                        Throw ex
                    Finally

                        If ZipFile IsNot Nothing Then

                            ZipFile.Dispose()
                            ZipFile = Nothing

                        End If

                    End Try

                End If

            Next

        End Sub
        Private Sub SaveRadioFiles(NielsenDbContext As Database.NielsenDbContext, Radio_Spot_Path As String)

            'objects
            Dim DownloadFile As Database.Entities.DownloadFile = Nothing
            Dim LastWriteTime As Date = Nothing

            For Each Filename In System.IO.Directory.GetFiles(Radio_Spot_Path)

                LastWriteTime = System.IO.File.GetLastWriteTime(Filename).AddMilliseconds(-System.IO.File.GetLastWriteTime(Filename).Millisecond)

                Filename = System.IO.Path.GetFileName(Filename)

                DownloadFile = NielsenFramework.Database.Procedures.DownloadFile.LoadByFileName(NielsenDbContext, Filename)

                If DownloadFile Is Nothing Then

                    DownloadFile = New Database.Entities.DownloadFile
                    DownloadFile.DbContext = NielsenDbContext

                    DownloadFile.FileName = Filename
                    DownloadFile.FileType = Database.Entities.Methods.DownloadFileType.Radio
                    DownloadFile.LastWriteTime = LastWriteTime

                    NielsenDbContext.DownloadFiles.Add(DownloadFile)

                    'ElseIf DownloadFile.LastWriteTime < LastWriteTime AndAlso Datediff(DateInterval.Second, DownloadFile.LastWriteTime, LastWriteTime) <> 0 Then

                    '    DownloadFile.LastWriteTime = LastWriteTime
                    '    DownloadFile.ProcessedTime = Nothing
                    '    NielsenDbContext.Entry(DownloadFile).State = Entity.EntityState.Modified

                End If

            Next

            NielsenDbContext.SaveChanges()

        End Sub
        Private Sub SaveEastlanRadioFiles(NielsenDbContext As Database.NielsenDbContext, Eastlan_Path As String)

            'objects
            Dim DownloadFile As Database.Entities.DownloadFile = Nothing
            Dim LastWriteTime As Date = Nothing

            For Each Filename In System.IO.Directory.GetFiles(Eastlan_Path)

                LastWriteTime = System.IO.File.GetLastWriteTime(Filename).AddMilliseconds(-System.IO.File.GetLastWriteTime(Filename).Millisecond)

                Filename = System.IO.Path.GetFileName(Filename)

                DownloadFile = NielsenFramework.Database.Procedures.DownloadFile.LoadByFileName(NielsenDbContext, Filename)

                If DownloadFile Is Nothing Then

                    DownloadFile = New Database.Entities.DownloadFile
                    DownloadFile.DbContext = NielsenDbContext

                    DownloadFile.FileName = Filename
                    DownloadFile.FileType = Database.Entities.Methods.DownloadFileType.EastlanRadio
                    DownloadFile.LastWriteTime = LastWriteTime

                    NielsenDbContext.DownloadFiles.Add(DownloadFile)

                    'ElseIf DownloadFile.LastWriteTime < LastWriteTime AndAlso Datediff(DateInterval.Second, DownloadFile.LastWriteTime, LastWriteTime) <> 0 Then

                    '    DownloadFile.LastWriteTime = LastWriteTime
                    '    DownloadFile.ProcessedTime = Nothing
                    '    NielsenDbContext.Entry(DownloadFile).State = Entity.EntityState.Modified

                End If

            Next

            NielsenDbContext.SaveChanges()

        End Sub
        Private Sub UnzipNCCSurveyFiles(Path As String)

            'objects
            Dim ZipFile As Ionic.Zip.ZipFile = Nothing
            Dim ZipEntry As Ionic.Zip.ZipEntry = Nothing
            Dim FileInfo As System.IO.FileInfo = Nothing

            For Each Directory In System.IO.Directory.GetDirectories(Path)

                For Each Filename In System.IO.Directory.GetFiles(Directory)

                    Filename = System.IO.Path.GetFileName(Filename)

                    If Filename.ToLower.EndsWith(".zip") Then

                        Try

                            ZipFile = Ionic.Zip.ZipFile.Read(System.IO.Path.Combine(Directory, Filename))

                            For Each ZipEntry In ZipFile

                                If Not System.IO.File.Exists(System.IO.Path.Combine(Directory, ZipEntry.FileName)) Then

                                    ZipEntry.Extract(Directory)

                                Else

                                    FileInfo = New System.IO.FileInfo(System.IO.Path.Combine(Directory, ZipEntry.FileName))

                                    If ZipEntry.LastModified > FileInfo.LastWriteTime Then

                                        ZipEntry.Extract(Directory, Ionic.Zip.ExtractExistingFileAction.OverwriteSilently)

                                    End If

                                End If

                            Next

                            ZipFile.Dispose()

                        Catch ex As Exception
                            Throw ex
                        Finally

                            If ZipFile IsNot Nothing Then

                                ZipFile.Dispose()
                                ZipFile = Nothing

                            End If

                        End Try

                    End If

                Next

            Next

        End Sub
        Private Function DownloadNCCFiles(NCC_Data_Path As String, FTPHost As String, FTPPort As Integer, UserName As String, Password As String,
                                          ByRef DownloadedFiles As Generic.List(Of String),
                                          ByRef ErrorText As String) As Boolean

            'objects
            Dim Downloaded As Boolean = True
            'Dim AIEUPath As String = Nothing
            'Dim SurveyCSVPath As String = Nothing
            Dim Directories As Generic.List(Of String) = Nothing

            'AIEUPath = System.IO.Path.Combine(NCC_Data_Path, "AIEU")
            'SurveyCSVPath = System.IO.Path.Combine(NCC_Data_Path, "Survey_CSV")

            'If Not System.IO.Directory.Exists(AIEUPath) Then

            '    System.IO.Directory.CreateDirectory(AIEUPath)

            'End If

            'If Not System.IO.Directory.Exists(SurveyCSVPath) Then

            '    System.IO.Directory.CreateDirectory(SurveyCSVPath)

            'End If

            'networks and XLS files
            If Not AdvantageFramework.FTP.DownloadFilesFromFTP(FTPHost, FTPPort, Rebex.Net.SslMode.None, UserName, Password, "/adsoftware/", NCC_Data_Path, DownloadedFiles, Rebex.IO.ActionOnExistingFiles.OverwriteOlder) Then

                Downloaded = False
                ErrorText = "Error downloading file from FTP root directory !"

            End If

            'AIEU files
            'If AdvantageFramework.FTP.GetDirectoriesFromFTP(FTPHost, FTPPort, Rebex.Net.SslMode.None, UserName, Password, "/adsoftware/AIUE", AIEUPath, Directories) Then

            '    For Each Directory In Directories

            '        If Not System.IO.Directory.Exists(System.IO.Path.Combine(AIEUPath, Directory)) Then

            '            System.IO.Directory.CreateDirectory(System.IO.Path.Combine(AIEUPath, Directory))

            '        End If

            '        If Not AdvantageFramework.FTP.DownloadFilesFromFTP(FTPHost, FTPPort, Rebex.Net.SslMode.None, UserName, Password, "/adsoftware/AIUE/" & Directory, System.IO.Path.Combine(AIEUPath, Directory), DownloadedFiles, Rebex.IO.ActionOnExistingFiles.OverwriteOlder) Then

            '            Downloaded = False
            '            ErrorText = "Error downloading file from FTP directory AIUE/" & Directory & "!"

            '        End If

            '    Next

            'Else

            '    Downloaded = False
            '    ErrorText = "Error getting directories from FTP directory AIUE!"

            'End If

            'Survey_CSV Files
            'If Directories IsNot Nothing AndAlso Directories.Count > 0 Then

            '    Directories.Clear()

            'End If

            'If AdvantageFramework.FTP.GetDirectoriesFromFTP(FTPHost, FTPPort, Rebex.Net.SslMode.None, UserName, Password, "/adsoftware/Survey_CSV", SurveyCSVPath, Directories) Then

            '    For Each Directory In Directories

            '        If Not System.IO.Directory.Exists(System.IO.Path.Combine(SurveyCSVPath, Directory)) Then

            '            System.IO.Directory.CreateDirectory(System.IO.Path.Combine(SurveyCSVPath, Directory))

            '        End If

            '        If Not AdvantageFramework.FTP.DownloadFilesFromFTP(FTPHost, FTPPort, Rebex.Net.SslMode.None, UserName, Password, "/adsoftware/Survey_CSV/" & Directory, System.IO.Path.Combine(SurveyCSVPath, Directory), DownloadedFiles, Rebex.IO.ActionOnExistingFiles.OverwriteOlder) Then

            '            Downloaded = False
            '            ErrorText = "Error downloading file from FTP directory Survey_CSV/" & Directory & "!"

            '        End If

            '    Next

            'Else

            '    Downloaded = False
            '    ErrorText = "Error getting directories from FTP directory Survey_CSV!"

            'End If

            DownloadNCCFiles = Downloaded

        End Function
        Private Sub SaveNCCFiles(NielsenDbContext As Database.NielsenDbContext, Path As String, SearchPattern As String, ClearProcessed As Boolean)

            'objects
            Dim DownloadFile As Database.Entities.DownloadFile = Nothing
            Dim LastWriteTime As Date = Nothing

            For Each Filename In System.IO.Directory.GetFiles(Path, SearchPattern)

                LastWriteTime = System.IO.File.GetLastWriteTime(Filename).AddMilliseconds(-System.IO.File.GetLastWriteTime(Filename).Millisecond)

                DownloadFile = NielsenFramework.Database.Procedures.DownloadFile.LoadByFileName(NielsenDbContext, Filename)

                If DownloadFile Is Nothing Then

                    DownloadFile = New Database.Entities.DownloadFile
                    DownloadFile.DbContext = NielsenDbContext

                    DownloadFile.FileName = Filename
                    DownloadFile.FileType = Database.Entities.Methods.DownloadFileType.NCC
                    DownloadFile.LastWriteTime = LastWriteTime

                    NielsenDbContext.DownloadFiles.Add(DownloadFile)

                    'ElseIf DownloadFile.LastWriteTime < LastWriteTime AndAlso Datediff(DateInterval.Second, DownloadFile.LastWriteTime, LastWriteTime) <> 0 Then

                    '    DownloadFile.LastWriteTime = LastWriteTime
                    '    DownloadFile.ProcessedTime = Nothing
                    '    NielsenDbContext.Entry(DownloadFile).State = Entity.EntityState.Modified

                ElseIf ClearProcessed AndAlso DownloadFile IsNot Nothing Then

                    DownloadFile.ProcessedTime = Nothing

                    NielsenDbContext.Entry(DownloadFile).State = Entity.EntityState.Modified

                End If

            Next

            NielsenDbContext.SaveChanges()

        End Sub
        Private Sub ProcessFiles(NielsenDbContext As Database.NielsenDbContext, ConnectionString As String, Radio_Spot_Path As String, TV_Spot_Path As String, TV_National_Path As String, NCC_Data_Path As String, Eastlan_Path As String)

            'objects
            Dim DownloadFiles As Generic.List(Of Database.Entities.DownloadFile) = Nothing

            DownloadFiles = (From Entity In NielsenFramework.Database.Procedures.DownloadFile.LoadUnprocessed(NielsenDbContext)
                             Select Entity).OrderBy(Function(Entity) Entity.ID).ToList

            If DownloadFiles.Count > 0 Then

                For Each DownloadFile In DownloadFiles

                    Try

                        If DownloadFile.FileType = Database.Entities.Methods.DownloadFileType.Radio Then

                            If ProcessRadioFile(ConnectionString, System.IO.Path.Combine(Radio_Spot_Path, DownloadFile.FileName), AdvantageFramework.Nielsen.Database.Entities.RadioSource.Nielsen) Then

                                NielsenDbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.DOWNLOAD_FILE SET PROCESSED_TIME = getdate() WHERE DOWNLOAD_FILE_ID = {0}", DownloadFile.ID))

                            End If

                        ElseIf DownloadFile.FileType = Database.Entities.Methods.DownloadFileType.TVSpot Then

                            If ProcessFile(ConnectionString, System.IO.Path.Combine(TV_Spot_Path, DownloadFile.FileName), DownloadFile.ID) Then

                                NielsenDbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.DOWNLOAD_FILE SET PROCESSED_TIME = getdate() WHERE DOWNLOAD_FILE_ID = {0}", DownloadFile.ID))

                            End If

                        ElseIf DownloadFile.FileType = Database.Entities.Methods.DownloadFileType.NCC Then

                            If DownloadFile.FileName.ToUpper.EndsWith("SYSTEMS.TXT") AndAlso ImportNCCSyscode(ConnectionString, DownloadFile.FileName) Then

                                NielsenDbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.DOWNLOAD_FILE SET PROCESSED_TIME = getdate() WHERE DOWNLOAD_FILE_ID = {0}", DownloadFile.ID))

                            ElseIf DownloadFile.FileName.ToUpper.EndsWith("AIUE.TXT") AndAlso ImportNCCTVAIUE(ConnectionString, DownloadFile.FileName) Then

                                NielsenDbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.DOWNLOAD_FILE SET PROCESSED_TIME = getdate() WHERE DOWNLOAD_FILE_ID = {0}", DownloadFile.ID))

                            ElseIf DownloadFile.FileName.ToUpper.EndsWith("CARRIAGE.TXT") AndAlso ImportNCCTVCarriage(ConnectionString, DownloadFile.FileName) Then

                                NielsenDbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.DOWNLOAD_FILE SET PROCESSED_TIME = getdate() WHERE DOWNLOAD_FILE_ID = {0}", DownloadFile.ID))

                            ElseIf DownloadFile.FileName.ToUpper.EndsWith(".XLS") AndAlso ImportNCCTVCablenet(ConnectionString, DownloadFile.FileName) Then

                                NielsenDbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.DOWNLOAD_FILE SET PROCESSED_TIME = getdate() WHERE DOWNLOAD_FILE_ID = {0}", DownloadFile.ID))

                            End If

                        ElseIf DownloadFile.FileType = Database.Entities.Methods.DownloadFileType.EastlanRadio Then

                            If ProcessRadioFile(ConnectionString, System.IO.Path.Combine(Eastlan_Path, DownloadFile.FileName), AdvantageFramework.Nielsen.Database.Entities.RadioSource.Eastlan) Then

                                NielsenDbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.DOWNLOAD_FILE SET PROCESSED_TIME = getdate() WHERE DOWNLOAD_FILE_ID = {0}", DownloadFile.ID))

                            End If

                        ElseIf DownloadFile.FileType = Database.Entities.Methods.DownloadFileType.RadioCounty Then

                            If ProcessRadioCountyFile(ConnectionString, System.IO.Path.Combine(System.IO.Path.Combine(Radio_Spot_Path, "County"), DownloadFile.FileName)) Then

                                NielsenDbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.DOWNLOAD_FILE SET PROCESSED_TIME = getdate() WHERE DOWNLOAD_FILE_ID = {0}", DownloadFile.ID))

                            End If

                        End If

                    Catch ex As Exception
                        LogEvent(ConnectionString, ex.Message & If(ex.InnerException IsNot Nothing, " Inner Exception:" & ex.InnerException.Message, ""))
                    End Try

                Next

            End If

        End Sub
        Private Sub ReProcessTVSpotFiles(NielsenDbContext As Database.NielsenDbContext, ConnectionString As String, TV_Spot_Path As String)

            'objects
            Dim DownloadFiles As IEnumerable(Of Database.Entities.DownloadFile) = Nothing

            DownloadFiles = NielsenFramework.Database.Procedures.DownloadFile.LoadByFileType(NielsenDbContext, Database.Entities.Methods.DownloadFileType.TVSpot).ToList

            If DownloadFiles.Count > 0 Then

                For Each DownloadFile In DownloadFiles

                    ReProcessFile(ConnectionString, System.IO.Path.Combine(TV_Spot_Path, DownloadFile.FileName))

                Next

            End If

        End Sub
        <System.Runtime.CompilerServices.Extension>
        Private Function ToDataTable(Of T)(EntityList As IList(Of T)) As System.Data.DataTable

            Dim PropertyDescriptorCollection As System.ComponentModel.PropertyDescriptorCollection = Nothing
            Dim DataTable As System.Data.DataTable = Nothing
            Dim DataRow As System.Data.DataRow = Nothing

            DataTable = New System.Data.DataTable

            PropertyDescriptorCollection = System.ComponentModel.TypeDescriptor.GetProperties(GetType(T))

            For Each Prop As System.ComponentModel.PropertyDescriptor In PropertyDescriptorCollection

                DataTable.Columns.Add(Prop.Name, If(Nullable.GetUnderlyingType(Prop.PropertyType), Prop.PropertyType))

            Next

            For Each Entity As T In EntityList

                DataRow = DataTable.NewRow()

                For Each Prop As System.ComponentModel.PropertyDescriptor In PropertyDescriptorCollection

                    DataRow(Prop.Name) = If(Prop.GetValue(Entity), DBNull.Value)

                Next

                DataTable.Rows.Add(DataRow)

            Next

            Return DataTable

        End Function
        Private Sub BulkInsertNielsenTVAudienceList(DbContext As AdvantageFramework.Nielsen.Database.DbContext, DbContextTransaction As Entity.DbContextTransaction,
                                                    NielsenTVAudiences As List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenTVAudience))

            'objects
            Dim DataTable As System.Data.DataTable = Nothing

            DataTable = NielsenTVAudiences.ToDataTable

            Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(DirectCast(DbContext.Database.Connection, SqlClient.SqlConnection), SqlClient.SqlBulkCopyOptions.CheckConstraints, DirectCast(DbContextTransaction.UnderlyingTransaction, SqlClient.SqlTransaction))

                With SqlBulkCopy

                    .ColumnMappings.Add("NielsenTVBookID", "NIELSEN_TV_BOOK_ID")
                    .ColumnMappings.Add("StationCode", "STATION_CODE")
                    .ColumnMappings.Add("AudienceDatetime", "AUDIENCE_DATETIME")
                    .ColumnMappings.Add("IsExcluded", "IS_EXCLUDED")
                    .ColumnMappings.Add("MetroAHousehold", "METROA_HOUSEHOLD_AUD")
                    .ColumnMappings.Add("MetroBHousehold", "METROB_HOUSEHOLD_AUD")
                    .ColumnMappings.Add("Household", "HOUSEHOLD_AUD")
                    .ColumnMappings.Add("Children2to5", "CHILDREN_2TO5_AUD")
                    .ColumnMappings.Add("Children6to11", "CHILDREN_6TO11_AUD")
                    .ColumnMappings.Add("Males12to14", "MALES_12TO14_AUD")
                    .ColumnMappings.Add("Males15to17", "MALES_15TO17_AUD")
                    .ColumnMappings.Add("Males18to20", "MALES_18TO20_AUD")
                    .ColumnMappings.Add("Males21to24", "MALES_21TO24_AUD")
                    .ColumnMappings.Add("Males25to34", "MALES_25TO34_AUD")
                    .ColumnMappings.Add("Males35to49", "MALES_35TO49_AUD")
                    .ColumnMappings.Add("Males50to54", "MALES_50TO54_AUD")
                    .ColumnMappings.Add("Males55to64", "MALES_55TO64_AUD")
                    .ColumnMappings.Add("Males65Plus", "MALES_65PLUS_AUD")
                    .ColumnMappings.Add("Females12to14", "FEMALES_12TO14_AUD")
                    .ColumnMappings.Add("Females15to17", "FEMALES_15TO17_AUD")
                    .ColumnMappings.Add("Females18to20", "FEMALES_18TO20_AUD")
                    .ColumnMappings.Add("Females21to24", "FEMALES_21TO24_AUD")
                    .ColumnMappings.Add("Females25to34", "FEMALES_25TO34_AUD")
                    .ColumnMappings.Add("Females35to49", "FEMALES_35TO49_AUD")
                    .ColumnMappings.Add("Females50to54", "FEMALES_50TO54_AUD")
                    .ColumnMappings.Add("Females55to64", "FEMALES_55TO64_AUD")
                    .ColumnMappings.Add("Females65Plus", "FEMALES_65PLUS_AUD")
                    .ColumnMappings.Add("WorkingWomen", "WORKING_WOMEN_AUD")

                    .BulkCopyTimeout = 0
                    .BatchSize = DataTable.Rows.Count
                    .DestinationTableName = "NIELSEN_TV_AUDIENCE"
                    .WriteToServer(DataTable)

                End With

            End Using

        End Sub
        Private Sub BulkInsertNielsenTVHutputList(DbContext As AdvantageFramework.Nielsen.Database.DbContext, DbContextTransaction As Entity.DbContextTransaction,
                                                  NielsenTVHutputs As List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenTVHutput))

            'objects
            Dim DataTable As System.Data.DataTable = Nothing

            DataTable = NielsenTVHutputs.ToDataTable

            Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(DirectCast(DbContext.Database.Connection, SqlClient.SqlConnection), SqlClient.SqlBulkCopyOptions.CheckConstraints, DirectCast(DbContextTransaction.UnderlyingTransaction, SqlClient.SqlTransaction))

                With SqlBulkCopy

                    .ColumnMappings.Add("NielsenTVBookID", "NIELSEN_TV_BOOK_ID")
                    .ColumnMappings.Add("HutputDatetime", "HUTPUT_DATETIME")
                    .ColumnMappings.Add("MetroAHousehold", "METROA_HOUSEHOLD_HUT")
                    .ColumnMappings.Add("MetroBHousehold", "METROB_HOUSEHOLD_HUT")
                    .ColumnMappings.Add("Household", "HOUSEHOLD_HUT")
                    .ColumnMappings.Add("Children2to5", "CHILDREN_2TO5_PUT")
                    .ColumnMappings.Add("Children6to11", "CHILDREN_6TO11_PUT")
                    .ColumnMappings.Add("Males12to14", "MALES_12TO14_PUT")
                    .ColumnMappings.Add("Males15to17", "MALES_15TO17_PUT")
                    .ColumnMappings.Add("Males18to20", "MALES_18TO20_PUT")
                    .ColumnMappings.Add("Males21to24", "MALES_21TO24_PUT")
                    .ColumnMappings.Add("Males25to34", "MALES_25TO34_PUT")
                    .ColumnMappings.Add("Males35to49", "MALES_35TO49_PUT")
                    .ColumnMappings.Add("Males50to54", "MALES_50TO54_PUT")
                    .ColumnMappings.Add("Males55to64", "MALES_55TO64_PUT")
                    .ColumnMappings.Add("Males65Plus", "MALES_65PLUS_PUT")
                    .ColumnMappings.Add("Females12to14", "FEMALES_12TO14_PUT")
                    .ColumnMappings.Add("Females15to17", "FEMALES_15TO17_PUT")
                    .ColumnMappings.Add("Females18to20", "FEMALES_18TO20_PUT")
                    .ColumnMappings.Add("Females21to24", "FEMALES_21TO24_PUT")
                    .ColumnMappings.Add("Females25to34", "FEMALES_25TO34_PUT")
                    .ColumnMappings.Add("Females35to49", "FEMALES_35TO49_PUT")
                    .ColumnMappings.Add("Females50to54", "FEMALES_50TO54_PUT")
                    .ColumnMappings.Add("Females55to64", "FEMALES_55TO64_PUT")
                    .ColumnMappings.Add("Females65Plus", "FEMALES_65PLUS_PUT")
                    .ColumnMappings.Add("WorkingWomen", "WORKING_WOMEN_PUT")

                    .BulkCopyTimeout = 0
                    .BatchSize = DataTable.Rows.Count
                    .DestinationTableName = "NIELSEN_TV_HUTPUT"
                    .WriteToServer(DataTable)

                End With

            End Using

        End Sub
        Private Sub BulkInsertNielsenTVIntabList(DbContext As AdvantageFramework.Nielsen.Database.DbContext, DbContextTransaction As Entity.DbContextTransaction,
                                                 NielsenTVIntabs As List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenTVIntab))

            'objects
            Dim DataTable As System.Data.DataTable = Nothing

            DataTable = NielsenTVIntabs.ToDataTable

            Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(DirectCast(DbContext.Database.Connection, SqlClient.SqlConnection), SqlClient.SqlBulkCopyOptions.CheckConstraints, DirectCast(DbContextTransaction.UnderlyingTransaction, SqlClient.SqlTransaction))

                With SqlBulkCopy

                    .ColumnMappings.Add("NielsenTVBookID", "NIELSEN_TV_BOOK_ID")
                    .ColumnMappings.Add("IntabDate", "INTAB_DATE")
                    .ColumnMappings.Add("MetroAHousehold", "METROA_HOUSEHOLD_INTAB")
                    .ColumnMappings.Add("MetroBHousehold", "METROB_HOUSEHOLD_INTAB")
                    .ColumnMappings.Add("Household", "HOUSEHOLD_INTAB")
                    .ColumnMappings.Add("Children2to5", "CHILDREN_2TO5_INTAB")
                    .ColumnMappings.Add("Children6to11", "CHILDREN_6TO11_INTAB")
                    .ColumnMappings.Add("Males12to14", "MALES_12TO14_INTAB")
                    .ColumnMappings.Add("Males15to17", "MALES_15TO17_INTAB")
                    .ColumnMappings.Add("Males18to20", "MALES_18TO20_INTAB")
                    .ColumnMappings.Add("Males21to24", "MALES_21TO24_INTAB")
                    .ColumnMappings.Add("Males25to34", "MALES_25TO34_INTAB")
                    .ColumnMappings.Add("Males35to49", "MALES_35TO49_INTAB")
                    .ColumnMappings.Add("Males50to54", "MALES_50TO54_INTAB")
                    .ColumnMappings.Add("Males55to64", "MALES_55TO64_INTAB")
                    .ColumnMappings.Add("Males65Plus", "MALES_65PLUS_INTAB")
                    .ColumnMappings.Add("Females12to14", "FEMALES_12TO14_INTAB")
                    .ColumnMappings.Add("Females15to17", "FEMALES_15TO17_INTAB")
                    .ColumnMappings.Add("Females18to20", "FEMALES_18TO20_INTAB")
                    .ColumnMappings.Add("Females21to24", "FEMALES_21TO24_INTAB")
                    .ColumnMappings.Add("Females25to34", "FEMALES_25TO34_INTAB")
                    .ColumnMappings.Add("Females35to49", "FEMALES_35TO49_INTAB")
                    .ColumnMappings.Add("Females50to54", "FEMALES_50TO54_INTAB")
                    .ColumnMappings.Add("Females55to64", "FEMALES_55TO64_INTAB")
                    .ColumnMappings.Add("Females65Plus", "FEMALES_65PLUS_INTAB")
                    .ColumnMappings.Add("WorkingWomen", "WORKING_WOMEN_INTAB")

                    .BulkCopyTimeout = 0
                    .BatchSize = DataTable.Rows.Count
                    .DestinationTableName = "NIELSEN_TV_INTAB"
                    .WriteToServer(DataTable)

                End With

            End Using

        End Sub
        Private Sub BulkInsertNielsenTVProgramList(DbContext As AdvantageFramework.Nielsen.Database.DbContext, DbContextTransaction As Entity.DbContextTransaction,
                                                   NielsenTVPrograms As List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenTVProgram))

            'objects
            Dim DataTable As System.Data.DataTable = Nothing

            DataTable = NielsenTVPrograms.ToDataTable

            Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(DirectCast(DbContext.Database.Connection, SqlClient.SqlConnection), SqlClient.SqlBulkCopyOptions.CheckConstraints, DirectCast(DbContextTransaction.UnderlyingTransaction, SqlClient.SqlTransaction))

                With SqlBulkCopy

                    .ColumnMappings.Add("NielsenTVProgramBookID", "NIELSEN_TV_PROGRAM_BOOK_ID")
                    .ColumnMappings.Add("StationCode", "STATION_CODE")
                    .ColumnMappings.Add("QtrHourStartTime", "QTR_HOUR_START_DATETIME")
                    .ColumnMappings.Add("QtrHourEndTime", "QTR_HOUR_END_DATETIME")
                    .ColumnMappings.Add("ProgramName", "PROGRAM_NAME")
                    .ColumnMappings.Add("Subtitle", "SUBTITLE")
                    .ColumnMappings.Add("TrackageName", "TRACKAGE_NAME")

                    .BulkCopyTimeout = 0
                    .BatchSize = DataTable.Rows.Count
                    .DestinationTableName = "NIELSEN_TV_PROGRAM"
                    .WriteToServer(DataTable)

                End With

            End Using

        End Sub
        Private Sub BulkInsertNielsenTVUniverseList(DbContext As AdvantageFramework.Nielsen.Database.DbContext, DbContextTransaction As Entity.DbContextTransaction,
                                                    NielsenTVUniverses As List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenTVUniverse))

            'objects
            Dim DataTable As System.Data.DataTable = Nothing

            DataTable = NielsenTVUniverses.ToDataTable

            Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(DirectCast(DbContext.Database.Connection, SqlClient.SqlConnection), SqlClient.SqlBulkCopyOptions.CheckConstraints, DirectCast(DbContextTransaction.UnderlyingTransaction, SqlClient.SqlTransaction))

                With SqlBulkCopy

                    .ColumnMappings.Add("NielsenMarketNumber", "NIELSEN_MARKET_NUM")
                    .ColumnMappings.Add("Year", "YEAR")
                    .ColumnMappings.Add("Month", "MONTH")
                    .ColumnMappings.Add("IsMeteredMarket", "IS_METERED_MARKET")
                    .ColumnMappings.Add("MetroAHousehold", "METROA_HOUSEHOLD_UE")
                    .ColumnMappings.Add("MetroBHousehold", "METROB_HOUSEHOLD_UE")
                    .ColumnMappings.Add("Household", "HOUSEHOLD_UE")
                    .ColumnMappings.Add("Children2to5", "CHILDREN_2TO5_UE")
                    .ColumnMappings.Add("Children6to11", "CHILDREN_6TO11_UE")
                    .ColumnMappings.Add("Males12to14", "MALES_12TO14_UE")
                    .ColumnMappings.Add("Males15to17", "MALES_15TO17_UE")
                    .ColumnMappings.Add("Males18to20", "MALES_18TO20_UE")
                    .ColumnMappings.Add("Males21to24", "MALES_21TO24_UE")
                    .ColumnMappings.Add("Males25to34", "MALES_25TO34_UE")
                    .ColumnMappings.Add("Males35to49", "MALES_35TO49_UE")
                    .ColumnMappings.Add("Males50to54", "MALES_50TO54_UE")
                    .ColumnMappings.Add("Males55to64", "MALES_55TO64_UE")
                    .ColumnMappings.Add("Males65Plus", "MALES_65PLUS_UE")
                    .ColumnMappings.Add("Females12to14", "FEMALES_12TO14_UE")
                    .ColumnMappings.Add("Females15to17", "FEMALES_15TO17_UE")
                    .ColumnMappings.Add("Females18to20", "FEMALES_18TO20_UE")
                    .ColumnMappings.Add("Females21to24", "FEMALES_21TO24_UE")
                    .ColumnMappings.Add("Females25to34", "FEMALES_25TO34_UE")
                    .ColumnMappings.Add("Females35to49", "FEMALES_35TO49_UE")
                    .ColumnMappings.Add("Females50to54", "FEMALES_50TO54_UE")
                    .ColumnMappings.Add("Females55to64", "FEMALES_55TO64_UE")
                    .ColumnMappings.Add("Females65Plus", "FEMALES_65PLUS_UE")
                    .ColumnMappings.Add("WorkingWomen", "WORKING_WOMEN_UE")
                    .ColumnMappings.Add("SurveyStartDate", "SURVEY_START_DATE")
                    .ColumnMappings.Add("SurveyEndDate", "SURVEY_END_DATE")
                    .ColumnMappings.Add("ReportingService", "REPORTING_SERVICE")
                    .ColumnMappings.Add("Exclusion", "EXCLUSION")
                    .ColumnMappings.Add("Ethnicity", "ETHNICITY")

                    .BulkCopyTimeout = 0
                    .BatchSize = DataTable.Rows.Count
                    .DestinationTableName = "NIELSEN_TV_UNIVERSE"
                    .WriteToServer(DataTable)

                End With

            End Using

        End Sub
        Private Sub BulkInsertNielsenTVStationList(DbContext As AdvantageFramework.Nielsen.Database.DbContext, DbContextTransaction As Entity.DbContextTransaction,
                                                   NielsenTVStations As List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenTVStation))

            'objects
            Dim DataTable As System.Data.DataTable = Nothing

            DataTable = NielsenTVStations.ToDataTable

            Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(DirectCast(DbContext.Database.Connection, SqlClient.SqlConnection), SqlClient.SqlBulkCopyOptions.CheckConstraints, DirectCast(DbContextTransaction.UnderlyingTransaction, SqlClient.SqlTransaction))

                With SqlBulkCopy

                    .ColumnMappings.Add("NielsenMarketNumber", "NIELSEN_MARKET_NUM")
                    .ColumnMappings.Add("StationCode", "STATION_CODE")
                    .ColumnMappings.Add("CallLetters", "CALL_LETTERS")
                    .ColumnMappings.Add("SourceType", "SOURCE_TYPE")
                    .ColumnMappings.Add("ParentPlusIndicator", "PARENT_PLUS_INDICATOR")
                    .ColumnMappings.Add("IsParent", "IS_PARENT")
                    .ColumnMappings.Add("IsSatellite", "IS_SATELLITE")
                    .ColumnMappings.Add("Affiliation", "AFFILIATION")
                    .ColumnMappings.Add("CableName", "CABLE_NAME")
                    .ColumnMappings.Add("ChannelNum", "CHANNEL_NUM")
                    .ColumnMappings.Add("DistributorGroup", "DISTRIBUTOR_GROUP")
                    .ColumnMappings.Add("StationType", "STATION_TYPE")
                    .ColumnMappings.Add("ReportabilityStatus", "REPORTABILITY_STATUS")
                    .ColumnMappings.Add("HomeMarketNumber", "HOME_MARKET_NUM")

                    .BulkCopyTimeout = 0
                    .BatchSize = DataTable.Rows.Count
                    .DestinationTableName = "NIELSEN_TV_STATION"
                    .WriteToServer(DataTable)

                End With

            End Using

        End Sub
        Private Sub BulkInsertNielsenTVCumeDaypartImpressionList(DbContext As AdvantageFramework.Nielsen.Database.DbContext, DbContextTransaction As Entity.DbContextTransaction,
                                                                 NielsenTVCumeDaypartImpressions As List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenTVCumeDaypartImpression))

            'objects
            Dim DataTable As System.Data.DataTable = Nothing

            DataTable = NielsenTVCumeDaypartImpressions.ToDataTable

            Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(DirectCast(DbContext.Database.Connection, SqlClient.SqlConnection), SqlClient.SqlBulkCopyOptions.CheckConstraints, DirectCast(DbContextTransaction.UnderlyingTransaction, SqlClient.SqlTransaction))

                With SqlBulkCopy

                    .ColumnMappings.Add("ID", "NIELSEN_TV_CUME_DAYPART_IMPRESSION_ID")
                    .ColumnMappings.Add("Ethnicity", "ETHNICITY")
                    .ColumnMappings.Add("StationCode", "STATION_CODE")
                    .ColumnMappings.Add("NielsenTVCumeBookID", "NIELSEN_TV_CUME_BOOK_ID")
                    .ColumnMappings.Add("NielsenTVDaypartID", "NIELSEN_TV_DAYPART_ID")
                    .ColumnMappings.Add("MetroAHousehold", "METROA_HOUSEHOLD")
                    .ColumnMappings.Add("MetroBHousehold", "METROB_HOUSEHOLD")
                    .ColumnMappings.Add("Household", "HOUSEHOLD")
                    .ColumnMappings.Add("Children2to5", "CHILDREN_2TO5")
                    .ColumnMappings.Add("Children6to11", "CHILDREN_6TO11")
                    .ColumnMappings.Add("Males12to14", "MALES_12TO14")
                    .ColumnMappings.Add("Males15to17", "MALES_15TO17")
                    .ColumnMappings.Add("Males18to20", "MALES_18TO20")
                    .ColumnMappings.Add("Males21to24", "MALES_21TO24")
                    .ColumnMappings.Add("Males25to34", "MALES_25TO34")
                    .ColumnMappings.Add("Males35to49", "MALES_35TO49")
                    .ColumnMappings.Add("Males50to54", "MALES_50TO54")
                    .ColumnMappings.Add("Males55to64", "MALES_55TO64")
                    .ColumnMappings.Add("Males65Plus", "MALES_65PLUS")
                    .ColumnMappings.Add("Females12to14", "FEMALES_12TO14")
                    .ColumnMappings.Add("Females15to17", "FEMALES_15TO17")
                    .ColumnMappings.Add("Females18to20", "FEMALES_18TO20")
                    .ColumnMappings.Add("Females21to24", "FEMALES_21TO24")
                    .ColumnMappings.Add("Females25to34", "FEMALES_25TO34")
                    .ColumnMappings.Add("Females35to49", "FEMALES_35TO49")
                    .ColumnMappings.Add("Females50to54", "FEMALES_50TO54")
                    .ColumnMappings.Add("Females55to64", "FEMALES_55TO64")
                    .ColumnMappings.Add("Females65Plus", "FEMALES_65PLUS")
                    .ColumnMappings.Add("WorkingWomen", "WORKING_WOMEN")

                    .BulkCopyTimeout = 0
                    .BatchSize = DataTable.Rows.Count
                    .DestinationTableName = "NIELSEN_TV_CUME_DAYPART_IMPRESSION"
                    .WriteToServer(DataTable)

                End With

            End Using

        End Sub
        Private Sub AddNielsenUniverse(DbContext As AdvantageFramework.Nielsen.Database.DbContext, TextLineFields() As String, Year As Short, Month As Short, IsMeteredMarket As Boolean,
                                       SurveyStart As Date, SurveyEnd As Date, ReportingService As String, Exclusion As String, Ethnicity As String,
                                       ByRef NielsenTVUniverses As List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenTVUniverse))

            'objects
            Dim NielsenTVUniverse As AdvantageFramework.Nielsen.Database.Entities.NielsenTVUniverse = Nothing
            Dim NielsenMarketNumber As Integer = 0

            NielsenMarketNumber = CInt(TextLineFields(1))

            If Not (From Entity In DbContext.GetQuery(Of AdvantageFramework.Nielsen.Database.Entities.NielsenTVUniverse)
                    Where Entity.NielsenMarketNumber = NielsenMarketNumber AndAlso
                          Entity.Year = Year AndAlso
                          Entity.Month = Month AndAlso
                          Entity.ReportingService = ReportingService AndAlso
                          Entity.Exclusion = Exclusion AndAlso
                          Entity.Ethnicity = Ethnicity
                    Select Entity).Any Then

                NielsenTVUniverse = New AdvantageFramework.Nielsen.Database.Entities.NielsenTVUniverse

                NielsenTVUniverse.IsMeteredMarket = IsMeteredMarket
                NielsenTVUniverse.Year = Year
                NielsenTVUniverse.Month = Month
                NielsenTVUniverse.NielsenMarketNumber = TextLineFields(1)

                NielsenTVUniverse.MetroAHousehold = TextLineFields(5)
                NielsenTVUniverse.MetroBHousehold = TextLineFields(6)
                NielsenTVUniverse.Household = TextLineFields(7)
                NielsenTVUniverse.Children2to5 = TextLineFields(8)
                NielsenTVUniverse.Children6to11 = TextLineFields(9)
                NielsenTVUniverse.Males12to14 = TextLineFields(10)
                NielsenTVUniverse.Males15to17 = TextLineFields(11)
                NielsenTVUniverse.Males18to20 = TextLineFields(12)
                NielsenTVUniverse.Males21to24 = TextLineFields(13)
                NielsenTVUniverse.Males25to34 = TextLineFields(14)
                NielsenTVUniverse.Males35to49 = TextLineFields(15)
                NielsenTVUniverse.Males50to54 = TextLineFields(16)
                NielsenTVUniverse.Males55to64 = TextLineFields(17)
                NielsenTVUniverse.Males65Plus = TextLineFields(18)
                NielsenTVUniverse.Females12to14 = TextLineFields(19)
                NielsenTVUniverse.Females15to17 = TextLineFields(20)
                NielsenTVUniverse.Females18to20 = TextLineFields(21)
                NielsenTVUniverse.Females21to24 = TextLineFields(22)
                NielsenTVUniverse.Females25to34 = TextLineFields(23)
                NielsenTVUniverse.Females35to49 = TextLineFields(24)
                NielsenTVUniverse.Females50to54 = TextLineFields(25)
                NielsenTVUniverse.Females55to64 = TextLineFields(26)
                NielsenTVUniverse.Females65Plus = TextLineFields(27)
                NielsenTVUniverse.WorkingWomen = TextLineFields(28)

                NielsenTVUniverse.SurveyStartDate = SurveyStart
                NielsenTVUniverse.SurveyEndDate = SurveyEnd

                NielsenTVUniverse.ReportingService = ReportingService
                NielsenTVUniverse.Exclusion = Exclusion
                NielsenTVUniverse.Ethnicity = Ethnicity

                NielsenTVUniverses.Add(NielsenTVUniverse)

            End If

        End Sub
        Private Sub AddNielsenIntab(DbContext As AdvantageFramework.Nielsen.Database.DbContext, TextLineFields() As String, NielsenTVBookID As Integer,
                                    ByRef NielsenTVIntabs As List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenTVIntab))

            Dim NielsenTVIntab As AdvantageFramework.Nielsen.Database.Entities.NielsenTVIntab = Nothing
            Dim NielsenMarketNumber As Integer = 0
            Dim IntabDate As Date = Nothing

            NielsenMarketNumber = CInt(TextLineFields(1))
            IntabDate = CDate(TextLineFields(5))

            If Not (From Entity In DbContext.GetQuery(Of AdvantageFramework.Nielsen.Database.Entities.NielsenTVIntab)
                    Where Entity.NielsenTVBookID = NielsenTVBookID AndAlso
                          Entity.IntabDate = IntabDate
                    Select Entity).Any Then

                NielsenTVIntab = New AdvantageFramework.Nielsen.Database.Entities.NielsenTVIntab

                NielsenTVIntab.NielsenTVBookID = NielsenTVBookID
                NielsenTVIntab.IntabDate = TextLineFields(5)

                NielsenTVIntab.MetroAHousehold = TextLineFields(6)
                NielsenTVIntab.MetroBHousehold = TextLineFields(7)
                NielsenTVIntab.Household = TextLineFields(8)
                NielsenTVIntab.Children2to5 = TextLineFields(9)
                NielsenTVIntab.Children6to11 = TextLineFields(10)
                NielsenTVIntab.Males12to14 = TextLineFields(11)
                NielsenTVIntab.Males15to17 = TextLineFields(12)
                NielsenTVIntab.Males18to20 = TextLineFields(13)
                NielsenTVIntab.Males21to24 = TextLineFields(14)
                NielsenTVIntab.Males25to34 = TextLineFields(15)
                NielsenTVIntab.Males35to49 = TextLineFields(16)
                NielsenTVIntab.Males50to54 = TextLineFields(17)
                NielsenTVIntab.Males55to64 = TextLineFields(18)
                NielsenTVIntab.Males65Plus = TextLineFields(19)
                NielsenTVIntab.Females12to14 = TextLineFields(20)
                NielsenTVIntab.Females15to17 = TextLineFields(21)
                NielsenTVIntab.Females18to20 = TextLineFields(22)
                NielsenTVIntab.Females21to24 = TextLineFields(23)
                NielsenTVIntab.Females25to34 = TextLineFields(24)
                NielsenTVIntab.Females35to49 = TextLineFields(25)
                NielsenTVIntab.Females50to54 = TextLineFields(26)
                NielsenTVIntab.Females55to64 = TextLineFields(27)
                NielsenTVIntab.Females65Plus = TextLineFields(28)
                NielsenTVIntab.WorkingWomen = TextLineFields(29)

                NielsenTVIntabs.Add(NielsenTVIntab)

            End If

        End Sub
        Private Function AddNielsenHutput(TextLineFields() As String, NielsenTVBookID As Integer) As AdvantageFramework.Nielsen.Database.Entities.NielsenTVHutput

            Dim NielsenTVHutput As AdvantageFramework.Nielsen.Database.Entities.NielsenTVHutput = Nothing

            NielsenTVHutput = New AdvantageFramework.Nielsen.Database.Entities.NielsenTVHutput

            NielsenTVHutput.NielsenTVBookID = NielsenTVBookID
            NielsenTVHutput.HutputDatetime = TextLineFields(6)

            NielsenTVHutput.MetroAHousehold = TextLineFields(8)
            NielsenTVHutput.MetroBHousehold = TextLineFields(9)
            NielsenTVHutput.Household = TextLineFields(10)
            NielsenTVHutput.Children2to5 = TextLineFields(11)
            NielsenTVHutput.Children6to11 = TextLineFields(12)
            NielsenTVHutput.Males12to14 = TextLineFields(13)
            NielsenTVHutput.Males15to17 = TextLineFields(14)
            NielsenTVHutput.Males18to20 = TextLineFields(15)
            NielsenTVHutput.Males21to24 = TextLineFields(16)
            NielsenTVHutput.Males25to34 = TextLineFields(17)
            NielsenTVHutput.Males35to49 = TextLineFields(18)
            NielsenTVHutput.Males50to54 = TextLineFields(19)
            NielsenTVHutput.Males55to64 = TextLineFields(20)
            NielsenTVHutput.Males65Plus = TextLineFields(21)
            NielsenTVHutput.Females12to14 = TextLineFields(22)
            NielsenTVHutput.Females15to17 = TextLineFields(23)
            NielsenTVHutput.Females18to20 = TextLineFields(24)
            NielsenTVHutput.Females21to24 = TextLineFields(25)
            NielsenTVHutput.Females25to34 = TextLineFields(26)
            NielsenTVHutput.Females35to49 = TextLineFields(27)
            NielsenTVHutput.Females50to54 = TextLineFields(28)
            NielsenTVHutput.Females55to64 = TextLineFields(29)
            NielsenTVHutput.Females65Plus = TextLineFields(30)
            NielsenTVHutput.WorkingWomen = TextLineFields(31)

            AddNielsenHutput = NielsenTVHutput

        End Function
        Private Function AddNielsenAudience(TextLineFields() As String, NielsenTVBookID As Integer) As AdvantageFramework.Nielsen.Database.Entities.NielsenTVAudience

            Dim NielsenTVAudience As AdvantageFramework.Nielsen.Database.Entities.NielsenTVAudience = Nothing

            NielsenTVAudience = New AdvantageFramework.Nielsen.Database.Entities.NielsenTVAudience

            NielsenTVAudience.NielsenTVBookID = NielsenTVBookID
            NielsenTVAudience.AudienceDatetime = TextLineFields(6)

            If TextLineFields(7) = "Y" Then

                NielsenTVAudience.IsExcluded = True

            Else

                NielsenTVAudience.IsExcluded = False

            End If

            NielsenTVAudience.StationCode = TextLineFields(1)

            NielsenTVAudience.MetroAHousehold = TextLineFields(8)
            NielsenTVAudience.MetroBHousehold = TextLineFields(9)
            NielsenTVAudience.Household = TextLineFields(10)
            NielsenTVAudience.Children2to5 = TextLineFields(11)
            NielsenTVAudience.Children6to11 = TextLineFields(12)
            NielsenTVAudience.Males12to14 = TextLineFields(13)
            NielsenTVAudience.Males15to17 = TextLineFields(14)
            NielsenTVAudience.Males18to20 = TextLineFields(15)
            NielsenTVAudience.Males21to24 = TextLineFields(16)
            NielsenTVAudience.Males25to34 = TextLineFields(17)
            NielsenTVAudience.Males35to49 = TextLineFields(18)
            NielsenTVAudience.Males50to54 = TextLineFields(19)
            NielsenTVAudience.Males55to64 = TextLineFields(20)
            NielsenTVAudience.Males65Plus = TextLineFields(21)
            NielsenTVAudience.Females12to14 = TextLineFields(22)
            NielsenTVAudience.Females15to17 = TextLineFields(23)
            NielsenTVAudience.Females18to20 = TextLineFields(24)
            NielsenTVAudience.Females21to24 = TextLineFields(25)
            NielsenTVAudience.Females25to34 = TextLineFields(26)
            NielsenTVAudience.Females35to49 = TextLineFields(27)
            NielsenTVAudience.Females50to54 = TextLineFields(28)
            NielsenTVAudience.Females55to64 = TextLineFields(29)
            NielsenTVAudience.Females65Plus = TextLineFields(30)
            NielsenTVAudience.WorkingWomen = TextLineFields(31)

            AddNielsenAudience = NielsenTVAudience

        End Function
        Private Sub AddNielsenTVProgramBook(DbContext As AdvantageFramework.Nielsen.Database.DbContext, TextLineFields() As String, DownloadFileID As Integer,
                                            ByRef NielsenTVProgramBookID As Integer)

            'objects
            Dim NielsenTVProgramBook As AdvantageFramework.Nielsen.Database.Entities.NielsenTVProgramBook = Nothing
            Dim NielsenTVProgramBookRevision As AdvantageFramework.Nielsen.Database.Entities.NielsenTVProgramBookRevision = Nothing
            Dim NielsenMarketNumber As Integer = 0
            Dim Year As Short = 0
            Dim Month As Short = 0
            Dim ReportingService As String = Nothing
            Dim Exclusion As String = Nothing
            Dim Ethnicity As String = Nothing

            NielsenMarketNumber = CInt(TextLineFields(2))
            Year = CShort(TextLineFields(14))
            Month = CShort(TextLineFields(13))
            ReportingService = TextLineFields(12)
            Exclusion = ""
            Ethnicity = TextLineFields(17)

            If ReportingService <> "1" AndAlso ReportingService <> "7" Then

                Throw New Exception("TV Program Book - invalid reporting service found.")

            End If

            If Exclusion <> "" AndAlso Exclusion.ToUpper <> "SX" Then

                Throw New Exception("TV Program Book - invalid exclusion found.")

            End If

            If Ethnicity <> "" AndAlso Ethnicity.ToUpper <> "HISP" AndAlso Ethnicity.ToUpper <> "AF-AM" AndAlso Ethnicity.ToUpper <> "ASIAN" Then

                Throw New Exception("TV Program Book - invalid ethnicity found.")

            End If

            NielsenTVProgramBook = (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenTVProgramBook.Load(DbContext)
                                    Where Entity.NielsenMarketNumber = NielsenMarketNumber AndAlso
                                          Entity.Year = Year AndAlso
                                          Entity.Month = Month AndAlso
                                          Entity.ReportingService = ReportingService AndAlso
                                          Entity.Exclusion = Exclusion AndAlso
                                          Entity.Ethnicity = Ethnicity
                                    Select Entity).SingleOrDefault

            If NielsenTVProgramBook Is Nothing Then

                NielsenTVProgramBook = New AdvantageFramework.Nielsen.Database.Entities.NielsenTVProgramBook
                NielsenTVProgramBook.DbContext = DbContext

                NielsenTVProgramBook.NielsenMarketNumber = NielsenMarketNumber
                NielsenTVProgramBook.Year = Year
                NielsenTVProgramBook.Month = Month
                NielsenTVProgramBook.Validated = False
                NielsenTVProgramBook.ReportingService = ReportingService
                NielsenTVProgramBook.Exclusion = Exclusion
                NielsenTVProgramBook.Ethnicity = Ethnicity
                NielsenTVProgramBook.DownloadFileID = DownloadFileID

                DbContext.NielsenTVProgramBooks.Add(NielsenTVProgramBook)
                DbContext.SaveChanges()

            Else 'its a revision

                Throw New Exception("TV Program Book exists")

                'NielsenTVProgramBookRevision = New AdvantageFramework.Nielsen.Database.Entities.NielsenTVProgramBookRevision
                'NielsenTVProgramBookRevision.DbContext = DbContext
                'NielsenTVProgramBookRevision.OldNielsenTVProgramBookID = NielsenTVProgramBook.ID

                'DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.NIELSEN_TV_PROGRAM WHERE NIELSEN_TV_PROGRAM_BOOK_ID = {0}", NielsenTVProgramBook.ID))
                'DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.NIELSEN_TV_PROGRAM_BOOK WHERE NIELSEN_TV_PROGRAM_BOOK_ID = {0}", NielsenTVProgramBook.ID))

                'NielsenTVProgramBook = New AdvantageFramework.Nielsen.Database.Entities.NielsenTVProgramBook
                'NielsenTVProgramBook.DbContext = DbContext

                'NielsenTVProgramBook.NielsenMarketNumber = NielsenMarketNumber
                'NielsenTVProgramBook.Year = Year
                'NielsenTVProgramBook.Month = Month
                'NielsenTVProgramBook.Validated = False

                'DbContext.NielsenTVProgramBooks.Add(NielsenTVProgramBook)
                'DbContext.SaveChanges()

                'NielsenTVProgramBookRevision.NewNielsenTVProgramBookID = NielsenTVProgramBook.ID
                'DbContext.NielsenTVProgramBookRevisions.Add(NielsenTVProgramBookRevision)
                'DbContext.SaveChanges()

            End If

            NielsenTVProgramBookID = NielsenTVProgramBook.ID

        End Sub
        Private Function AddNielsenProgramName(TextLineFields() As String, NielsenTVProgramBookID As Integer) As AdvantageFramework.Nielsen.Database.Entities.NielsenTVProgram

            'objects
            Dim NielsenTVProgram As AdvantageFramework.Nielsen.Database.Entities.NielsenTVProgram = Nothing

            NielsenTVProgram = New AdvantageFramework.Nielsen.Database.Entities.NielsenTVProgram

            NielsenTVProgram.NielsenTVProgramBookID = NielsenTVProgramBookID
            NielsenTVProgram.StationCode = TextLineFields(2)
            NielsenTVProgram.QtrHourStartTime = TextLineFields(6)
            NielsenTVProgram.QtrHourEndTime = TextLineFields(7)
            NielsenTVProgram.ProgramName = TextLineFields(9)
            NielsenTVProgram.Subtitle = TextLineFields(10)

            AddNielsenProgramName = NielsenTVProgram

        End Function
        Private Sub AddNielsenTVStation(DbContext As AdvantageFramework.Nielsen.Database.DbContext, TextLineFields() As String,
                                      ByRef NielsenTVStations As List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenTVStation))

            Dim NielsenMarketNumber As Integer = 0
            Dim StationCode As Integer = 0
            Dim ExistingNielsenTVStation As AdvantageFramework.Nielsen.Database.Entities.NielsenTVStation = Nothing
            Dim NielsenTVStation As AdvantageFramework.Nielsen.Database.Entities.NielsenTVStation = Nothing
            Dim NielsenTVStationHistory As AdvantageFramework.Nielsen.Database.Entities.NielsenTVStationHistory = Nothing

            NielsenMarketNumber = TextLineFields(1)
            StationCode = TextLineFields(6)

            ExistingNielsenTVStation = (From Entity In DbContext.GetQuery(Of AdvantageFramework.Nielsen.Database.Entities.NielsenTVStation)
                                        Where Entity.NielsenMarketNumber = NielsenMarketNumber AndAlso
                                              Entity.StationCode = StationCode
                                        Select Entity).FirstOrDefault

            If ExistingNielsenTVStation Is Nothing Then

                NielsenTVStation = New AdvantageFramework.Nielsen.Database.Entities.NielsenTVStation

                NielsenTVStation.NielsenMarketNumber = NielsenMarketNumber
                NielsenTVStation.StationCode = StationCode
                NielsenTVStation.CallLetters = TextLineFields(7)
                NielsenTVStation.SourceType = TextLineFields(12)
                NielsenTVStation.ParentPlusIndicator = TextLineFields(9)

                If TextLineFields(17) = "Y" Then

                    NielsenTVStation.IsParent = True

                Else

                    NielsenTVStation.IsParent = False

                End If

                If TextLineFields(18) = "Y" Then

                    NielsenTVStation.IsSatellite = True

                Else

                    NielsenTVStation.IsSatellite = False

                End If

                NielsenTVStation.Affiliation = TextLineFields(13)
                NielsenTVStation.CableName = TextLineFields(10)
                NielsenTVStation.ChannelNum = TextLineFields(11)

                If IsNumeric(TextLineFields(16)) Then

                    NielsenTVStation.DistributorGroup = TextLineFields(16)

                End If

                NielsenTVStation.StationType = TextLineFields(20)
                NielsenTVStation.ReportabilityStatus = TextLineFields(22)

                If IsNumeric(TextLineFields(5)) Then

                    NielsenTVStation.HomeMarketNumber = CInt(TextLineFields(5))

                End If

                NielsenTVStations.Add(NielsenTVStation)

            Else

                If ExistingNielsenTVStation.CallLetters.ToUpper.Trim <> TextLineFields(7).ToUpper.Trim OrElse ExistingNielsenTVStation.CableName.ToUpper.Trim <> TextLineFields(10).ToUpper.Trim Then

                    ExistingNielsenTVStation.CallLetters = TextLineFields(7)
                    ExistingNielsenTVStation.CableName = TextLineFields(10)
                    DbContext.Entry(ExistingNielsenTVStation).State = Entity.EntityState.Modified

                    NielsenTVStationHistory = New AdvantageFramework.Nielsen.Database.Entities.NielsenTVStationHistory
                    NielsenTVStationHistory.DbContext = DbContext

                    NielsenTVStationHistory.NielsenMarketNumber = ExistingNielsenTVStation.NielsenMarketNumber
                    NielsenTVStationHistory.StationCode = ExistingNielsenTVStation.StationCode
                    NielsenTVStationHistory.CallLetters = ExistingNielsenTVStation.CallLetters
                    NielsenTVStationHistory.ChangedOn = Now

                    DbContext.NielsenTVStationHistorys.Add(NielsenTVStationHistory)
                    DbContext.SaveChanges()

                End If

            End If

        End Sub
        Private Sub AddNielsenTVBook(DbContext As AdvantageFramework.Nielsen.Database.DbContext, TextLineFields() As String, DownloadFileID As Integer,
                                     ByRef NielsenTVBookID As Integer, ByRef Year As Short, ByRef Month As Short,
                                     ByRef ReportingService As String, ByRef Exclusion As String, ByRef Ethnicity As String)

            'objects
            Dim NielsenTVBook As AdvantageFramework.Nielsen.Database.Entities.NielsenTVBook = Nothing
            Dim NielsenTVBookRevision As AdvantageFramework.Nielsen.Database.Entities.NielsenTVBookRevision = Nothing
            Dim NielsenMarketNumber As Integer = 0
            Dim LocalYear As Short = 0
            Dim LocalMonth As Short = 0
            Dim Stream As String = Nothing
            Dim LocalReportingService As String = Nothing
            Dim LocalExclusion As String = Nothing
            Dim LocalEthnicity As String = Nothing

            NielsenMarketNumber = CInt(TextLineFields(2))
            LocalYear = CShort(TextLineFields(23))
            LocalMonth = CShort(TextLineFields(22))
            LocalReportingService = TextLineFields(12)
            LocalExclusion = TextLineFields(13)
            LocalEthnicity = TextLineFields(14)

            If LocalReportingService <> "1" AndAlso LocalReportingService <> "7" Then

                Throw New Exception("TV Book - invalid reporting service found.")

            End If

            If LocalExclusion <> "" AndAlso LocalExclusion.ToUpper <> "SX" Then

                Throw New Exception("TV Book - invalid exclusion found.")

            End If

            If LocalEthnicity <> "" AndAlso LocalEthnicity.ToUpper <> "HISP" AndAlso LocalEthnicity.ToUpper <> "AF-AM" AndAlso LocalEthnicity.ToUpper <> "ASIAN" Then

                Throw New Exception("TV Book - invalid ethnicity found.")

            End If

            Select Case TextLineFields(18).Trim

                Case "O"

                    Stream = "LO"

                Case "S"

                    Stream = "LS"

                Case "1"

                    Stream = "L1"

                Case "3"

                    Stream = "L3"

                Case "7"

                    Stream = "L7"

            End Select

            NielsenTVBook = (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenTVBook.Load(DbContext)
                             Where Entity.NielsenMarketNumber = NielsenMarketNumber AndAlso
                                   Entity.Year = LocalYear AndAlso
                                   Entity.Month = LocalMonth AndAlso
                                   Entity.Stream = Stream AndAlso
                                   Entity.ReportingService = LocalReportingService AndAlso
                                   Entity.Exclusion = LocalExclusion AndAlso
                                   Entity.Ethnicity = LocalEthnicity
                             Select Entity).SingleOrDefault

            If NielsenTVBook Is Nothing Then

                NielsenTVBook = New AdvantageFramework.Nielsen.Database.Entities.NielsenTVBook
                NielsenTVBook.DbContext = DbContext

                NielsenTVBook.NielsenMarketNumber = TextLineFields(2)
                NielsenTVBook.Year = TextLineFields(23)
                NielsenTVBook.Month = TextLineFields(22)
                NielsenTVBook.Stream = Stream
                NielsenTVBook.StartDateTime = TextLineFields(7)
                NielsenTVBook.EndDateTime = TextLineFields(8)
                NielsenTVBook.MarketTimeZone = TextLineFields(24)
                NielsenTVBook.MarketClassCode = TextLineFields(25)
                NielsenTVBook.IsDaylightSavingsMarket = If(TextLineFields(27) = "Y", True, False)
                NielsenTVBook.CreateDate = Now
                NielsenTVBook.Validated = False
                NielsenTVBook.CollectionMethod = TextLineFields(20)
                NielsenTVBook.ReportingService = LocalReportingService
                NielsenTVBook.Exclusion = LocalExclusion
                NielsenTVBook.Ethnicity = LocalEthnicity
                NielsenTVBook.DownloadFileID = DownloadFileID

                DbContext.NielsenTVBooks.Add(NielsenTVBook)
                DbContext.SaveChanges()

            Else 'its a revision

                Throw New Exception("TV Book exists")

                '    NielsenTVBookRevision = New AdvantageFramework.Nielsen.Database.Entities.NielsenTVBookRevision
                '    NielsenTVBookRevision.DbContext = DbContext
                '    NielsenTVBookRevision.OldNielsenTVBookID = NielsenTVBook.ID

                '    DbContext.Database.ExecuteSqlCommand(String.Format("exec dbo.advsp_neilsen_tv_book_delete {0}", NielsenTVBook.ID))

                '    NielsenTVBook = New AdvantageFramework.Nielsen.Database.Entities.NielsenTVBook
                '    NielsenTVBook.DbContext = DbContext

                '    NielsenTVBook.NielsenMarketNumber = TextLineFields(2)
                '    NielsenTVBook.Year = TextLineFields(23)
                '    NielsenTVBook.Month = TextLineFields(22)
                '    NielsenTVBook.Stream = Stream
                '    NielsenTVBook.StartDateTime = TextLineFields(7)
                '    NielsenTVBook.EndDateTime = TextLineFields(8)
                '    NielsenTVBook.MarketTimeZone = TextLineFields(24)
                '    NielsenTVBook.MarketClassCode = TextLineFields(25)
                '    NielsenTVBook.IsDaylightSavingsMarket = If(TextLineFields(27) = "Y", True, False)
                '    NielsenTVBook.CreateDate = Now
                '    NielsenTVBook.Validated = False
                '    NielsenTVBook.CollectionMethod = TextLineFields(20)

                '    DbContext.NielsenTVBooks.Add(NielsenTVBook)
                '    DbContext.SaveChanges()

                '    NielsenTVBookRevision.NewNielsenTVBookID = NielsenTVBook.ID
                '    DbContext.NielsenTVBookRevisions.Add(NielsenTVBookRevision)
                '    DbContext.SaveChanges()

            End If

            NielsenTVBookID = NielsenTVBook.ID
            Year = NielsenTVBook.Year
            Month = NielsenTVBook.Month

            ReportingService = LocalReportingService
            Exclusion = LocalExclusion
            Ethnicity = LocalEthnicity

        End Sub
        Private Sub AddNielsenTVCumeBook(DbContext As AdvantageFramework.Nielsen.Database.DbContext, TextLineFields() As String,
                                         ByRef NielsenTVCumeBookID As Integer)

            'objects
            Dim NielsenTVCumeBook As AdvantageFramework.Nielsen.Database.Entities.NielsenTVCumeBook = Nothing
            Dim NielsenTVCumeBookRevision As AdvantageFramework.Nielsen.Database.Entities.NielsenTVCumeBookRevision = Nothing
            Dim NielsenMarketNumber As Integer = 0
            Dim Year As Short = 0
            Dim Month As Short = 0
            Dim Stream As String = Nothing

            NielsenMarketNumber = CInt(TextLineFields(2))
            Year = CShort(TextLineFields(20))
            Month = CShort(TextLineFields(19))

            If TextLineFields(16) = "1" Then

                Stream = "L1"

            ElseIf TextLineFields(16) = "7" Then

                Stream = "L7"

            End If

            NielsenTVCumeBook = (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenTVCumeBook.Load(DbContext)
                                 Where Entity.NielsenMarketNumber = NielsenMarketNumber AndAlso
                                       Entity.Year = Year AndAlso
                                       Entity.Month = Month AndAlso
                                       Entity.Stream = Stream
                                 Select Entity).SingleOrDefault

            If NielsenTVCumeBook Is Nothing Then

                NielsenTVCumeBook = New AdvantageFramework.Nielsen.Database.Entities.NielsenTVCumeBook
                NielsenTVCumeBook.DbContext = DbContext

                NielsenTVCumeBook.NielsenMarketNumber = NielsenMarketNumber
                NielsenTVCumeBook.Year = Year
                NielsenTVCumeBook.Month = Month
                NielsenTVCumeBook.Stream = Stream
                NielsenTVCumeBook.StartDateTime = TextLineFields(7)
                NielsenTVCumeBook.EndDateTime = TextLineFields(8)
                NielsenTVCumeBook.MarketTimeZone = TextLineFields(21)
                NielsenTVCumeBook.MarketClassCode = TextLineFields(22)
                NielsenTVCumeBook.IsDaylightSavingsMarket = If(TextLineFields(23) = "Y", True, False)
                NielsenTVCumeBook.CreateDate = Now
                NielsenTVCumeBook.Validated = False

                DbContext.NielsenTVCumeBooks.Add(NielsenTVCumeBook)
                DbContext.SaveChanges()

            Else 'its a revision

                Throw New Exception("TV CUME Book exists")

                'NielsenTVCumeBookRevision = New AdvantageFramework.Nielsen.Database.Entities.NielsenTVCumeBookRevision
                'NielsenTVCumeBookRevision.DbContext = DbContext
                'NielsenTVCumeBookRevision.OldNielsenTVCumeBookID = NielsenTVCumeBook.ID

                'DbContext.Database.ExecuteSqlCommand(String.Format("exec dbo.advsp_neilsen_tv_cume_book_delete {0}", NielsenTVCumeBook.ID))

                'NielsenTVCumeBook = New AdvantageFramework.Nielsen.Database.Entities.NielsenTVCumeBook
                'NielsenTVCumeBook.DbContext = DbContext

                'NielsenTVCumeBook.NielsenMarketNumber = NielsenMarketNumber
                'NielsenTVCumeBook.Year = Year
                'NielsenTVCumeBook.Month = Month
                'NielsenTVCumeBook.Stream = Stream
                'NielsenTVCumeBook.StartDateTime = TextLineFields(7)
                'NielsenTVCumeBook.EndDateTime = TextLineFields(8)
                'NielsenTVCumeBook.MarketTimeZone = TextLineFields(21)
                'NielsenTVCumeBook.MarketClassCode = TextLineFields(22)
                'NielsenTVCumeBook.IsDaylightSavingsMarket = If(TextLineFields(23) = "Y", True, False)
                'NielsenTVCumeBook.CreateDate = Now
                'NielsenTVCumeBook.Validated = False

                'DbContext.NielsenTVCumeBooks.Add(NielsenTVCumeBook)
                'DbContext.SaveChanges()

                'NielsenTVCumeBookRevision.NewNielsenTVCumeBookID = NielsenTVCumeBook.ID
                'DbContext.NielsenTVCumeBookRevisions.Add(NielsenTVCumeBookRevision)
                'DbContext.SaveChanges()

            End If

            NielsenTVCumeBookID = NielsenTVCumeBook.ID

        End Sub
        Private Sub AddNielsenTVCumeDaypartImpression(TextLineFields() As String, Ethnicity As String, TimeZone As String, NielsenTVCumeBookID As Integer,
                                                      ByRef NielsenTVCumeDaypartImpressions As List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenTVCumeDaypartImpression),
                                                      DbContext As AdvantageFramework.Nielsen.Database.DbContext)

            'objects
            Dim NielsenTVCumeDaypartImpression As AdvantageFramework.Nielsen.Database.Entities.NielsenTVCumeDaypartImpression = Nothing
            Dim NielsenDaypartID As Integer = 0
            Dim NielsenTVDaypart As AdvantageFramework.Nielsen.Database.Entities.NielsenTVDaypart = Nothing
            Dim NielsenMarketNumber As Integer = 0
            Dim IsHispanic As Boolean = False

            NielsenMarketNumber = TextLineFields(2)

            If (Ethnicity = "NSIHSP" OrElse Ethnicity = "NSIXHSP") AndAlso (NielsenMarketNumber = 403 OrElse NielsenMarketNumber = 128) Then

                IsHispanic = True

            End If

            NielsenDaypartID = TextLineFields(6)

            NielsenTVDaypart = (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenTVDaypart.Load(DbContext)
                                Where Entity.NielsenDaypartID = NielsenDaypartID AndAlso
                                      Entity.TimeZone = TimeZone AndAlso
                                      Entity.IsHispanic = IsHispanic
                                Select Entity).SingleOrDefault

            If NielsenTVDaypart Is Nothing Then

                NielsenTVDaypart = New AdvantageFramework.Nielsen.Database.Entities.NielsenTVDaypart

                NielsenTVDaypart.NielsenDaypartID = NielsenDaypartID
                NielsenTVDaypart.IsHispanic = IsHispanic
                NielsenTVDaypart.TimeZone = TimeZone

                NielsenTVDaypart.Name = ""
                NielsenTVDaypart.NumberOfQuarterhours = 0
                NielsenTVDaypart.MilitaryStartTime = 0
                NielsenTVDaypart.MilitaryEndTime = 0
                NielsenTVDaypart.StartMinute = 0
                NielsenTVDaypart.EndMinute = 0
                NielsenTVDaypart.UseSegment = False
                NielsenTVDaypart.Sunday = False
                NielsenTVDaypart.Monday = False
                NielsenTVDaypart.Tuesday = False
                NielsenTVDaypart.Wednesday = False
                NielsenTVDaypart.Thursday = False
                NielsenTVDaypart.Friday = False
                NielsenTVDaypart.Saturday = False
                NielsenTVDaypart.IsInactive = True

                DbContext.NielsenTVDayparts.Add(NielsenTVDaypart)
                DbContext.SaveChanges()

            End If

            NielsenTVCumeDaypartImpression = New AdvantageFramework.Nielsen.Database.Entities.NielsenTVCumeDaypartImpression

            NielsenTVCumeDaypartImpression.Ethnicity = Ethnicity
            NielsenTVCumeDaypartImpression.StationCode = TextLineFields(1)
            NielsenTVCumeDaypartImpression.NielsenTVCumeBookID = NielsenTVCumeBookID

            NielsenTVCumeDaypartImpression.NielsenTVDaypartID = NielsenTVDaypart.ID
            NielsenTVCumeDaypartImpression.MetroAHousehold = TextLineFields(7)
            NielsenTVCumeDaypartImpression.MetroBHousehold = TextLineFields(8)
            NielsenTVCumeDaypartImpression.Household = TextLineFields(9)
            NielsenTVCumeDaypartImpression.Children2to5 = TextLineFields(10)
            NielsenTVCumeDaypartImpression.Children6to11 = TextLineFields(11)
            NielsenTVCumeDaypartImpression.Males12to14 = TextLineFields(12)
            NielsenTVCumeDaypartImpression.Males15to17 = TextLineFields(13)
            NielsenTVCumeDaypartImpression.Males18to20 = TextLineFields(14)
            NielsenTVCumeDaypartImpression.Males21to24 = TextLineFields(15)
            NielsenTVCumeDaypartImpression.Males25to34 = TextLineFields(16)
            NielsenTVCumeDaypartImpression.Males35to49 = TextLineFields(17)
            NielsenTVCumeDaypartImpression.Males50to54 = TextLineFields(18)
            NielsenTVCumeDaypartImpression.Males55to64 = TextLineFields(19)
            NielsenTVCumeDaypartImpression.Males65Plus = TextLineFields(20)
            NielsenTVCumeDaypartImpression.Females12to14 = TextLineFields(21)
            NielsenTVCumeDaypartImpression.Females15to17 = TextLineFields(22)
            NielsenTVCumeDaypartImpression.Females18to20 = TextLineFields(23)
            NielsenTVCumeDaypartImpression.Females21to24 = TextLineFields(24)
            NielsenTVCumeDaypartImpression.Females25to34 = TextLineFields(25)
            NielsenTVCumeDaypartImpression.Females35to49 = TextLineFields(26)
            NielsenTVCumeDaypartImpression.Females50to54 = TextLineFields(27)
            NielsenTVCumeDaypartImpression.Females55to64 = TextLineFields(28)
            NielsenTVCumeDaypartImpression.Females65Plus = TextLineFields(29)
            NielsenTVCumeDaypartImpression.WorkingWomen = TextLineFields(30)

            NielsenTVCumeDaypartImpressions.Add(NielsenTVCumeDaypartImpression)

        End Sub
        Private Function ProcessFile(ConnectionString As String, ByVal Filename As String, DownloadFileID As Integer) As Boolean

            'objects
            Dim Processed As Boolean = False
            Dim StreamReader As System.IO.StreamReader = Nothing
            Dim FilenameFields() As String = Nothing
            Dim Year As Short = 0
            Dim Month As Short = 0
            Dim TextLine As String = Nothing
            Dim TextLineFields() As String = Nothing
            Dim HasRecord99 As Boolean = False
            Dim IsMeteredMarket As Boolean = False
            Dim SurveyStart As Date = Nothing
            Dim SurveyEnd As Date = Nothing
            Dim NielsenTVAudiences As List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenTVAudience) = Nothing
            Dim NielsenTVHutputs As List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenTVHutput) = Nothing
            Dim NielsenTVIntabs As List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenTVIntab) = Nothing
            Dim NielsenTVPrograms As List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenTVProgram) = Nothing
            Dim NielsenTVUniverses As List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenTVUniverse) = Nothing
            Dim NielsenTVStations As List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenTVStation) = Nothing
            Dim NielsenTVBookID As Integer = -1
            Dim NielsenTVCumeDaypartImpressions As List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenTVCumeDaypartImpression) = Nothing
            Dim TimeZone As String = Nothing
            Dim Ethnicity As String = Nothing
            Dim NielsenTVCumeBookID As Integer = -1
            Dim NielsenTVProgramBookID As Integer = -1
            Dim ReportingService As String = Nothing
            Dim Exclusion As String = Nothing
            Dim Ethnicity01 As String = Nothing

            If System.IO.File.Exists(Filename) Then

                Using DbContext As New AdvantageFramework.Nielsen.Database.DbContext(ConnectionString, Nothing)

                    Using tran = DbContext.Database.BeginTransaction()

                        Try

                            StreamReader = New System.IO.StreamReader(Filename)

                            FilenameFields = Mid(Filename.ToUpper, 1, InStr(Filename, ".") - 1).Split("_")

                            NielsenTVAudiences = New List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenTVAudience)
                            NielsenTVHutputs = New List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenTVHutput)
                            NielsenTVIntabs = New List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenTVIntab)
                            NielsenTVPrograms = New List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenTVProgram)
                            NielsenTVUniverses = New List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenTVUniverse)
                            NielsenTVStations = New List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenTVStation)
                            NielsenTVCumeDaypartImpressions = New List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenTVCumeDaypartImpression)

                            Do While StreamReader.Peek() <> -1

                                TextLine = StreamReader.ReadLine()

                                Select Case Mid(TextLine, 1, 2)

                                    Case "01"

                                        TextLineFields = TextLine.Split(ControlChars.Tab)

                                        AddNielsenTVBook(DbContext, TextLineFields, DownloadFileID, NielsenTVBookID, Year, Month, ReportingService, Exclusion, Ethnicity01)

                                        SurveyStart = TextLineFields(7)
                                        SurveyEnd = TextLineFields(8)

                                        If TextLineFields(20) = "1" OrElse TextLineFields(20) = "2" OrElse TextLineFields(20) = "3" OrElse TextLineFields(20) = "5" Then

                                            IsMeteredMarket = True

                                        End If

                                    Case "02"

                                        TextLineFields = TextLine.Split(ControlChars.Tab)

                                        AddNielsenTVStation(DbContext, TextLineFields, NielsenTVStations)

                                    Case "04"

                                        TextLineFields = TextLine.Split(ControlChars.Tab)

                                        If CStr(TextLineFields(4)) = "1" Then

                                            AddNielsenUniverse(DbContext, TextLineFields, Year, Month, IsMeteredMarket, SurveyStart, SurveyEnd, ReportingService, Exclusion, Ethnicity01, NielsenTVUniverses)

                                        End If

                                    Case "05"

                                        TextLineFields = TextLine.Split(ControlChars.Tab)

                                        If CStr(TextLineFields(4)) = "1" Then

                                            AddNielsenIntab(DbContext, TextLineFields, NielsenTVBookID, NielsenTVIntabs)

                                        End If

                                    Case "07"

                                        TextLineFields = TextLine.Split(ControlChars.Tab)

                                        If CStr(TextLineFields(4)) = "1" AndAlso TextLineFields(7) = "N" Then

                                            NielsenTVHutputs.Add(AddNielsenHutput(TextLineFields, NielsenTVBookID))

                                        End If

                                    Case "08"

                                        TextLineFields = TextLine.Split(ControlChars.Tab)

                                        If CStr(TextLineFields(4)) = "1" AndAlso TextLineFields(7) = "N" Then

                                            NielsenTVAudiences.Add(AddNielsenAudience(TextLineFields, NielsenTVBookID))

                                        End If

                                    Case "11" 'PGNAM files

                                        TextLineFields = TextLine.Split(ControlChars.Tab)

                                        AddNielsenTVProgramBook(DbContext, TextLineFields, DownloadFileID, NielsenTVProgramBookID)

                                    Case "12" 'PGNAM files

                                        TextLineFields = TextLine.Split(ControlChars.Tab)

                                        NielsenTVPrograms.Add(AddNielsenProgramName(TextLineFields, NielsenTVProgramBookID))

                                    Case "31" 'DPCUME files

                                        TextLineFields = TextLine.Split(ControlChars.Tab)

                                        AddNielsenTVCumeBook(DbContext, TextLineFields, NielsenTVCumeBookID)

                                        If TextLineFields(21) = 1 OrElse TextLineFields(21) = 4 Then

                                            TimeZone = "E"

                                        Else

                                            TimeZone = "C"

                                        End If

                                        Ethnicity = Mid(FilenameFields(0), InStrRev(FilenameFields(0), "\") + 1)

                                    Case "38" 'DPCUME files

                                        TextLineFields = TextLine.Split(ControlChars.Tab)

                                        AddNielsenTVCumeDaypartImpression(TextLineFields, Ethnicity, TimeZone, NielsenTVCumeBookID, NielsenTVCumeDaypartImpressions, DbContext)

                                    Case "99"

                                        HasRecord99 = True

                                End Select

                            Loop

                            If HasRecord99 Then

                                BulkInsertNielsenTVAudienceList(DbContext, tran, NielsenTVAudiences)

                                BulkInsertNielsenTVHutputList(DbContext, tran, NielsenTVHutputs)

                                BulkInsertNielsenTVIntabList(DbContext, tran, NielsenTVIntabs)

                                BulkInsertNielsenTVProgramList(DbContext, tran, NielsenTVPrograms)

                                BulkInsertNielsenTVUniverseList(DbContext, tran, NielsenTVUniverses)

                                BulkInsertNielsenTVStationList(DbContext, tran, NielsenTVStations)

                                BulkInsertNielsenTVCumeDaypartImpressionList(DbContext, tran, NielsenTVCumeDaypartImpressions)

                                tran.Commit()

                                Processed = True

                            ElseIf Mid(TextLine, 1, 2) <> "31" Then

                                Throw New Exception("Missing EOF 99 record in file: " & Filename)

                            End If

                        Catch ex As Exception

                            tran.Rollback()

                            LogEvent(ConnectionString, "Downloadfile ID:" & DownloadFileID.ToString & ": " & ex.Message)
                            'Throw New Exception(ex.Message)

                        Finally

                            StreamReader.Close()

                        End Try

                    End Using

                End Using

            End If

            ProcessFile = Processed

        End Function
        Private Function ReProcessFile(ConnectionString As String, Filename As String) As Boolean

            'objects
            Dim Processed As Boolean = False
            Dim StreamReader As System.IO.StreamReader = Nothing
            Dim FilenameFields() As String = Nothing
            Dim TextLine As String = Nothing
            Dim TextLineFields() As String = Nothing
            Dim NielsenMarketNumber As Integer = 0
            Dim Year As Short = 0
            Dim Month As Short = 0
            Dim NielsenTVUniverse As AdvantageFramework.Nielsen.Database.Entities.NielsenTVUniverse = Nothing
            Dim IsMeteredMarket As Boolean = False
            Dim ReportingService As String = Nothing
            Dim Exclusion As String = Nothing
            Dim Ethnicity As String = Nothing
            Dim SurveyStart As Date = Nothing
            Dim SurveyEnd As Date = Nothing

            If System.IO.File.Exists(Filename) Then

                Using DbContext As New AdvantageFramework.Nielsen.Database.DbContext(ConnectionString, Nothing)

                    Try

                        StreamReader = New System.IO.StreamReader(Filename)

                        FilenameFields = Mid(Filename.ToUpper, 1, InStr(Filename, ".") - 1).Split("_")

                        Do While StreamReader.Peek() <> -1

                            TextLine = StreamReader.ReadLine()

                            Select Case Mid(TextLine, 1, 2)

                                Case "01"

                                    TextLineFields = TextLine.Split(ControlChars.Tab)

                                    ReportingService = TextLineFields(12)
                                    Exclusion = TextLineFields(13)
                                    Ethnicity = TextLineFields(14)

                                    If ReportingService <> "1" AndAlso ReportingService <> "7" Then

                                        Throw New Exception("TV Book - invalid reporting service found.")

                                    End If

                                    If Exclusion <> "" AndAlso Exclusion.ToUpper <> "SX" Then

                                        Throw New Exception("TV Book - invalid exclusion found.")

                                    End If

                                    If Ethnicity <> "" AndAlso Ethnicity.ToUpper <> "HISP" AndAlso Ethnicity.ToUpper <> "AF-AM" AndAlso Ethnicity.ToUpper <> "ASIAN" Then

                                        Throw New Exception("TV Book - invalid ethnicity found.")

                                    End If

                                    SurveyStart = TextLineFields(7)
                                    SurveyEnd = TextLineFields(8)

                                    NielsenMarketNumber = CInt(TextLineFields(2))
                                    Year = CShort(TextLineFields(23))
                                    Month = CShort(TextLineFields(22))

                                    If TextLineFields(20) = "1" OrElse TextLineFields(20) = "2" OrElse TextLineFields(20) = "3" OrElse TextLineFields(20) = "5" Then

                                        IsMeteredMarket = True

                                    End If

                                Case "04"

                                    TextLineFields = TextLine.Split(ControlChars.Tab)

                                    NielsenTVUniverse = (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenTVUniverse.Load(DbContext)
                                                         Where Entity.NielsenMarketNumber = NielsenMarketNumber AndAlso
                                                               Entity.Year = Year AndAlso
                                                               Entity.Month = Month AndAlso
                                                               Entity.ReportingService = ReportingService AndAlso
                                                               Entity.Exclusion = Exclusion AndAlso
                                                               Entity.Ethnicity = Ethnicity
                                                         Select Entity).SingleOrDefault

                                    If NielsenTVUniverse IsNot Nothing Then

                                        NielsenTVUniverse.IsMeteredMarket = IsMeteredMarket

                                        NielsenTVUniverse.MetroAHousehold = TextLineFields(5)
                                        NielsenTVUniverse.MetroBHousehold = TextLineFields(6)
                                        NielsenTVUniverse.Household = TextLineFields(7)
                                        NielsenTVUniverse.Children2to5 = TextLineFields(8)
                                        NielsenTVUniverse.Children6to11 = TextLineFields(9)
                                        NielsenTVUniverse.Males12to14 = TextLineFields(10)
                                        NielsenTVUniverse.Males15to17 = TextLineFields(11)
                                        NielsenTVUniverse.Males18to20 = TextLineFields(12)
                                        NielsenTVUniverse.Males21to24 = TextLineFields(13)
                                        NielsenTVUniverse.Males25to34 = TextLineFields(14)
                                        NielsenTVUniverse.Males35to49 = TextLineFields(15)
                                        NielsenTVUniverse.Males50to54 = TextLineFields(16)
                                        NielsenTVUniverse.Males55to64 = TextLineFields(17)
                                        NielsenTVUniverse.Males65Plus = TextLineFields(18)
                                        NielsenTVUniverse.Females12to14 = TextLineFields(19)
                                        NielsenTVUniverse.Females15to17 = TextLineFields(20)
                                        NielsenTVUniverse.Females18to20 = TextLineFields(21)
                                        NielsenTVUniverse.Females21to24 = TextLineFields(22)
                                        NielsenTVUniverse.Females25to34 = TextLineFields(23)
                                        NielsenTVUniverse.Females35to49 = TextLineFields(24)
                                        NielsenTVUniverse.Females50to54 = TextLineFields(25)
                                        NielsenTVUniverse.Females55to64 = TextLineFields(26)
                                        NielsenTVUniverse.Females65Plus = TextLineFields(27)
                                        NielsenTVUniverse.WorkingWomen = TextLineFields(28)

                                        DbContext.Entry(NielsenTVUniverse).State = Entity.EntityState.Modified
                                        DbContext.SaveChanges()

                                    Else

                                        NielsenTVUniverse = New AdvantageFramework.Nielsen.Database.Entities.NielsenTVUniverse

                                        NielsenTVUniverse.NielsenMarketNumber = NielsenMarketNumber
                                        NielsenTVUniverse.Year = Year
                                        NielsenTVUniverse.Month = Month
                                        NielsenTVUniverse.IsMeteredMarket = IsMeteredMarket

                                        NielsenTVUniverse.MetroAHousehold = TextLineFields(5)
                                        NielsenTVUniverse.MetroBHousehold = TextLineFields(6)
                                        NielsenTVUniverse.Household = TextLineFields(7)
                                        NielsenTVUniverse.Children2to5 = TextLineFields(8)
                                        NielsenTVUniverse.Children6to11 = TextLineFields(9)
                                        NielsenTVUniverse.Males12to14 = TextLineFields(10)
                                        NielsenTVUniverse.Males15to17 = TextLineFields(11)
                                        NielsenTVUniverse.Males18to20 = TextLineFields(12)
                                        NielsenTVUniverse.Males21to24 = TextLineFields(13)
                                        NielsenTVUniverse.Males25to34 = TextLineFields(14)
                                        NielsenTVUniverse.Males35to49 = TextLineFields(15)
                                        NielsenTVUniverse.Males50to54 = TextLineFields(16)
                                        NielsenTVUniverse.Males55to64 = TextLineFields(17)
                                        NielsenTVUniverse.Males65Plus = TextLineFields(18)
                                        NielsenTVUniverse.Females12to14 = TextLineFields(19)
                                        NielsenTVUniverse.Females15to17 = TextLineFields(20)
                                        NielsenTVUniverse.Females18to20 = TextLineFields(21)
                                        NielsenTVUniverse.Females21to24 = TextLineFields(22)
                                        NielsenTVUniverse.Females25to34 = TextLineFields(23)
                                        NielsenTVUniverse.Females35to49 = TextLineFields(24)
                                        NielsenTVUniverse.Females50to54 = TextLineFields(25)
                                        NielsenTVUniverse.Females55to64 = TextLineFields(26)
                                        NielsenTVUniverse.Females65Plus = TextLineFields(27)
                                        NielsenTVUniverse.WorkingWomen = TextLineFields(28)

                                        NielsenTVUniverse.SurveyStartDate = SurveyStart
                                        NielsenTVUniverse.SurveyEndDate = SurveyEnd

                                        NielsenTVUniverse.ReportingService = ReportingService
                                        NielsenTVUniverse.Exclusion = Exclusion
                                        NielsenTVUniverse.Ethnicity = Ethnicity

                                        DbContext.NielsenTVUniverses.Add(NielsenTVUniverse)
                                        DbContext.SaveChanges()

                                    End If

                                    Exit Do

                                Case Else

                            End Select

                        Loop

                    Catch ex As Exception

                        Throw New Exception(ex.Message)

                    Finally

                        StreamReader.Close()

                    End Try

                End Using

            End If

            ReProcessFile = Processed

        End Function

#Region " National Data "

        Private Function GetLastSundayInAugust(DateToConvert As Date) As Date

            Dim LastSundayYear As Integer = 0
            Dim Found As Boolean = False
            Dim LastSundayInAugust As Date = Nothing
            Dim Day As Integer = 31

            If DateToConvert.Month <= 8 Then

                LastSundayYear = DateToConvert.Year

            Else

                LastSundayYear = DateToConvert.Year + 1

            End If

            While Not Found

                If DateSerial(LastSundayYear, 8, Day).DayOfWeek = DayOfWeek.Sunday Then

                    LastSundayInAugust = DateSerial(LastSundayYear, 8, Day)
                    Found = True

                Else

                    Day = Day - 1

                End If

            End While

            If DateToConvert > LastSundayInAugust Then

                LastSundayInAugust = GetLastSundayInAugust(LastSundayInAugust)

            End If

            GetLastSundayInAugust = LastSundayInAugust

        End Function
        Private Sub DeleteNationalTVAudience(DbContext As AdvantageFramework.Nielsen.Database.DbContext, TextLine As String)

            Dim ProgramCode As Decimal = Nothing
            Dim AudienceDate As Date = Nothing
            Dim AudienceTime As Short = Nothing

            ProgramCode = CDec(Mid(TextLine, 21, 10))

            If Mid(TextLine, 44, 1) = "1" Then

                AudienceDate = DateSerial(2000 + CInt(Mid(TextLine, 45, 2)), CInt(Mid(TextLine, 47, 2)), CInt(Mid(TextLine, 49, 2)))
                AudienceTime = Mid(TextLine, 86, 4)

            End If

            DbContext.Database.ExecuteSqlCommand("DELETE dbo.NIELSEN_NATIONAL_TV_AUDIENCE WHERE PROGRAM_CODE = @PROGRAM_CODE AND AUDIENCE_DATE = @AUDIENCE_DATE AND AUDIENCE_TIME = @AUDIENCE_TIME",
                                                     New SqlClient.SqlParameter("@PROGRAM_CODE", ProgramCode), New SqlClient.SqlParameter("@AUDIENCE_DATE", AudienceDate), New SqlClient.SqlParameter("@AUDIENCE_TIME", AudienceTime))

        End Sub
        Private Function GetDecimalValue(InputString As String) As Decimal

            Dim DecValue As Decimal = 0

            If IsNumeric(InputString) Then

                DecValue = CDec(InputString)

            End If

            GetDecimalValue = DecValue

        End Function
        'Private Sub AddNielsenNationalTVAudience(DbContext As AdvantageFramework.Nielsen.Database.DbContext, MediaMarketBreakID As Integer, TextLine As String, TextLine2 As String, TextLine3 As String,
        '                                         TextLine4 As String, TextLine5 As String,
        '                                         TimeType As String, Stream As String, FilePrefix As String, IsOvernight As Boolean,
        '                                         ByRef NielsenNationalTVAudiences As List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenNationalTVAudience))

        '    Dim Network As String = Nothing
        '    Dim SyndicatorInfo As String = Nothing
        '    Dim AudienceDate As Date = Nothing
        '    Dim AudienceTime As Short = Nothing
        '    Dim SequenceNumber As Short = 0
        '    Dim NielsenNationalTVAudience As AdvantageFramework.Nielsen.Database.Entities.NielsenNationalTVAudience = Nothing

        '    If FilePrefix = "NSS" Then

        '        Network = Mid(TextLine, 250, 4)
        '        SyndicatorInfo = Mid(TextLine, 41, 1)

        '    ElseIf FilePrefix = "NTI" OrElse FilePrefix = "NHI" Then

        '        Network = Mid(TextLine, 15, 6)
        '        SyndicatorInfo = " "

        '    End If

        '    If Mid(TextLine, 44, 1) = "1" Then

        '        AudienceDate = DateSerial(2000 + CInt(Mid(TextLine, 45, 2)), CInt(Mid(TextLine, 47, 2)), CInt(Mid(TextLine, 49, 2)))
        '        AudienceTime = Mid(TextLine, 86, 4)

        '    End If

        '    If AudienceTime = 0 Then

        '        AudienceTime = 600

        '    End If

        '    If Not (From Entity In DbContext.GetQuery(Of AdvantageFramework.Nielsen.Database.Entities.NielsenNationalTVAudience)
        '            Where Entity.MediaMarketBreakID = MediaMarketBreakID AndAlso
        '                  Entity.TimeType = TimeType AndAlso
        '                  Entity.Stream = Stream AndAlso
        '                  Entity.Network = Network AndAlso
        '                  Entity.AudienceDate = AudienceDate AndAlso
        '                  Entity.AudienceTime = AudienceTime AndAlso
        '                  Entity.SequenceNumber = SequenceNumber
        '            Select Entity).Any Then

        '        If (From Entity In NielsenNationalTVAudiences
        '            Where Entity.MediaMarketBreakID = MediaMarketBreakID AndAlso
        '                  Entity.TimeType = TimeType AndAlso
        '                  Entity.Stream = Stream AndAlso
        '                  Entity.Network = Network AndAlso
        '                  Entity.AudienceDate = AudienceDate AndAlso
        '                  Entity.AudienceTime = AudienceTime AndAlso
        '                  Entity.SequenceNumber = SequenceNumber
        '            Select Entity).Any Then

        '            SequenceNumber = (From Entity In NielsenNationalTVAudiences
        '                              Where Entity.MediaMarketBreakID = MediaMarketBreakID AndAlso
        '                                    Entity.TimeType = TimeType AndAlso
        '                                    Entity.Stream = Stream AndAlso
        '                                    Entity.Network = Network AndAlso
        '                                    Entity.AudienceDate = AudienceDate AndAlso
        '                                    Entity.AudienceTime = AudienceTime
        '                              Select Entity).AsParallel.Max(Function(Entity) Entity.SequenceNumber) + 1

        '        End If

        '        NielsenNationalTVAudience = New AdvantageFramework.Nielsen.Database.Entities.NielsenNationalTVAudience

        '        NielsenNationalTVAudience.MediaMarketBreakID = MediaMarketBreakID
        '        NielsenNationalTVAudience.TimeType = TimeType
        '        NielsenNationalTVAudience.Stream = Stream
        '        NielsenNationalTVAudience.Network = Network
        '        NielsenNationalTVAudience.AudienceDate = AudienceDate
        '        NielsenNationalTVAudience.AudienceTime = AudienceTime
        '        NielsenNationalTVAudience.SequenceNumber = SequenceNumber

        '        NielsenNationalTVAudience.ProgramDuration = CShort(Mid(TextLine, 278, 4))
        '        NielsenNationalTVAudience.ProgramTotalDuration = CInt(Mid(TextLine, 331, 6))
        '        NielsenNationalTVAudience.ProgramName = Mid(TextLine, 115, 25)
        '        NielsenNationalTVAudience.TrackageName = Mid(TextLine, 140, 25)
        '        NielsenNationalTVAudience.EpisodeName = Mid(TextLine, 180, 32)
        '        NielsenNationalTVAudience.ProgramCode = CDec(Mid(TextLine, 21, 10))
        '        NielsenNationalTVAudience.TrackageCode = If(IsNumeric(Mid(TextLine, 31, 3)), CShort(Mid(TextLine, 31, 3)), Nothing)
        '        NielsenNationalTVAudience.NielsenDaypart = Mid(TextLine, 276, 2)
        '        NielsenNationalTVAudience.ProgramType = Mid(TextLine, 216, 2)

        '        If Mid(TextLine, 11, 1) = "0" Then 'original

        '            NielsenNationalTVAudience.IsCorrection = False

        '        ElseIf Mid(TextLine, 11, 1) = "1" Then 'correction

        '            NielsenNationalTVAudience.IsCorrection = True

        '        End If

        '        NielsenNationalTVAudience.IsBreakout = CBool(Mid(TextLine, 35, 1))
        '        NielsenNationalTVAudience.IsSpecial = CBool(Mid(TextLine, 36, 1))
        '        NielsenNationalTVAudience.IsRepeat = CBool(If(Mid(TextLine, 230, 1) = "Y", 1, 0))
        '        NielsenNationalTVAudience.IsPremiere = CBool(If(Mid(TextLine, 238, 1) = "Y", 1, 0))
        '        NielsenNationalTVAudience.IsOvernight = IsOvernight
        '        NielsenNationalTVAudience.IsDNA = CBool(If(Mid(TextLine, 98, 1) = "1", 1, 0))
        '        NielsenNationalTVAudience.IsMulticast = CBool(If(Mid(TextLine, 229, 1) = "Y", 1, 0))
        '        NielsenNationalTVAudience.IsComplex = CBool(If(Mid(TextLine, 231, 1) = "Y", 1, 0))
        '        NielsenNationalTVAudience.IsShortDuration = CBool(If(Mid(TextLine, 232, 1) = "Y", 1, 0))
        '        NielsenNationalTVAudience.IsVariousMetadata = CBool(If(Mid(TextLine, 237, 1) = "Y", 1, 0))

        '        NielsenNationalTVAudience.IsVariousTimes = True 'CBool(Mid(TextLine, 319, 1))

        '        NielsenNationalTVAudience.IsGapped = CBool(If(Mid(TextLine, 42, 1) = "00", 0, 1))
        '        NielsenNationalTVAudience.IsWeeklyAverage = CBool(If(Mid(TextLine, 239, 1) = "Y", 1, 0))
        '        NielsenNationalTVAudience.SyndicatorInfo = SyndicatorInfo
        '        NielsenNationalTVAudience.TelecastNumber = CDec(Mid(TextLine, 58, 10))
        '        NielsenNationalTVAudience.CoverageSampleIdentification = CInt(Mid(TextLine, 71, 6))
        '        NielsenNationalTVAudience.MarketBreakIdentifier = CShort(Mid(TextLine, 78, 3))
        '        NielsenNationalTVAudience.TotalProgramIndicator = Mid(TextLine, 81, 2)
        '        NielsenNationalTVAudience.DaysOfWeekIndicator = Mid(TextLine, 282, 7)
        '        NielsenNationalTVAudience.StationCount = CInt(Mid(TextLine, 305, 5))
        '        NielsenNationalTVAudience.HeadendCount = CInt(Mid(TextLine, 310, 5))
        '        NielsenNationalTVAudience.CoveragePercent = CShort(Mid(TextLine, 315, 2))
        '        NielsenNationalTVAudience.DaysCount = CShort(Mid(TextLine, 328, 3))

        '        NielsenNationalTVAudience.ProgramHUT = GetDecimalValue(Mid(TextLine, 354, 9))
        '        NielsenNationalTVAudience.HouseholdAudience = GetDecimalValue(Mid(TextLine, 337, 9))
        '        NielsenNationalTVAudience.Females2to5Audience = GetDecimalValue(Mid(TextLine2, 116, 9))
        '        NielsenNationalTVAudience.Females6to8Audience = GetDecimalValue(Mid(TextLine2, 125, 9))
        '        NielsenNationalTVAudience.Females9to11Audience = GetDecimalValue(Mid(TextLine2, 134, 9))
        '        NielsenNationalTVAudience.Females12to14Audience = GetDecimalValue(Mid(TextLine2, 143, 9))
        '        NielsenNationalTVAudience.Females15to17Audience = GetDecimalValue(Mid(TextLine2, 152, 9))
        '        NielsenNationalTVAudience.Females18to20Audience = GetDecimalValue(Mid(TextLine2, 161, 9))
        '        NielsenNationalTVAudience.Females21to24Audience = GetDecimalValue(Mid(TextLine2, 170, 9))
        '        NielsenNationalTVAudience.Females25to29Audience = GetDecimalValue(Mid(TextLine2, 179, 9))
        '        NielsenNationalTVAudience.Females30to34Audience = GetDecimalValue(Mid(TextLine2, 188, 9))
        '        NielsenNationalTVAudience.Females35to39Audience = GetDecimalValue(Mid(TextLine2, 197, 9))
        '        NielsenNationalTVAudience.Females40to44Audience = GetDecimalValue(Mid(TextLine2, 206, 9))
        '        NielsenNationalTVAudience.Females45to49Audience = GetDecimalValue(Mid(TextLine2, 215, 9))
        '        NielsenNationalTVAudience.Females50to54Audience = GetDecimalValue(Mid(TextLine2, 224, 9))
        '        NielsenNationalTVAudience.Females55to64Audience = GetDecimalValue(Mid(TextLine2, 233, 9))
        '        NielsenNationalTVAudience.Females65PlusAudience = GetDecimalValue(Mid(TextLine2, 242, 9))
        '        NielsenNationalTVAudience.Males2to5Audience = GetDecimalValue(Mid(TextLine2, 251, 9))
        '        NielsenNationalTVAudience.Males6to8Audience = GetDecimalValue(Mid(TextLine2, 260, 9))
        '        NielsenNationalTVAudience.Males9to11Audience = GetDecimalValue(Mid(TextLine2, 269, 9))
        '        NielsenNationalTVAudience.Males12to14Audience = GetDecimalValue(Mid(TextLine2, 278, 9))
        '        NielsenNationalTVAudience.Males15to17Audience = GetDecimalValue(Mid(TextLine2, 287, 9))
        '        NielsenNationalTVAudience.Males18to20Audience = GetDecimalValue(Mid(TextLine3, 116, 9))
        '        NielsenNationalTVAudience.Males21to24Audience = GetDecimalValue(Mid(TextLine3, 125, 9))
        '        NielsenNationalTVAudience.Males25to29Audience = GetDecimalValue(Mid(TextLine3, 134, 9))
        '        NielsenNationalTVAudience.Males30to34Audience = GetDecimalValue(Mid(TextLine3, 143, 9))
        '        NielsenNationalTVAudience.Males35to39Audience = GetDecimalValue(Mid(TextLine3, 152, 9))
        '        NielsenNationalTVAudience.Males40to44Audience = GetDecimalValue(Mid(TextLine3, 161, 9))
        '        NielsenNationalTVAudience.Males45to49Audience = GetDecimalValue(Mid(TextLine3, 170, 9))
        '        NielsenNationalTVAudience.Males50to54Audience = GetDecimalValue(Mid(TextLine3, 179, 9))
        '        NielsenNationalTVAudience.Males55to64Audience = GetDecimalValue(Mid(TextLine3, 188, 9))
        '        NielsenNationalTVAudience.Males65PlusAudience = GetDecimalValue(Mid(TextLine3, 197, 9))
        '        NielsenNationalTVAudience.WorkingWomen18to20Audience = GetDecimalValue(Mid(TextLine3, 224, 9))
        '        NielsenNationalTVAudience.WorkingWomen21to24Audience = GetDecimalValue(Mid(TextLine3, 233, 9))
        '        NielsenNationalTVAudience.WorkingWomen25to34Audience = GetDecimalValue(Mid(TextLine3, 242, 9))
        '        NielsenNationalTVAudience.WorkingWomen35to44Audience = GetDecimalValue(Mid(TextLine3, 251, 9))
        '        NielsenNationalTVAudience.WorkingWomen45to49Audience = GetDecimalValue(Mid(TextLine3, 260, 9))
        '        NielsenNationalTVAudience.WorkingWomen50to54Audience = GetDecimalValue(Mid(TextLine3, 269, 9))
        '        NielsenNationalTVAudience.WorkingWomen55PlusAudience = GetDecimalValue(Mid(TextLine3, 278, 9))
        '        NielsenNationalTVAudience.HouseholdHUT = GetDecimalValue(Mid(TextLine, 354, 9))

        '        NielsenNationalTVAudience.Females2to5PUT = If(TextLine4 Is Nothing, 0, GetDecimalValue(Mid(TextLine4, 116, 9)))
        '        NielsenNationalTVAudience.Females6to8PUT = If(TextLine4 Is Nothing, 0, GetDecimalValue(Mid(TextLine4, 125, 9)))
        '        NielsenNationalTVAudience.Females9to11PUT = If(TextLine4 Is Nothing, 0, GetDecimalValue(Mid(TextLine4, 134, 9)))
        '        NielsenNationalTVAudience.Females12to14PUT = If(TextLine4 Is Nothing, 0, GetDecimalValue(Mid(TextLine4, 143, 9)))
        '        NielsenNationalTVAudience.Females15to17PUT = If(TextLine4 Is Nothing, 0, GetDecimalValue(Mid(TextLine4, 152, 9)))
        '        NielsenNationalTVAudience.Females18to20PUT = If(TextLine4 Is Nothing, 0, GetDecimalValue(Mid(TextLine4, 161, 9)))
        '        NielsenNationalTVAudience.Females21to24PUT = If(TextLine4 Is Nothing, 0, GetDecimalValue(Mid(TextLine4, 170, 9)))
        '        NielsenNationalTVAudience.Females25to29PUT = If(TextLine4 Is Nothing, 0, GetDecimalValue(Mid(TextLine4, 179, 9)))
        '        NielsenNationalTVAudience.Females30to34PUT = If(TextLine4 Is Nothing, 0, GetDecimalValue(Mid(TextLine4, 188, 9)))
        '        NielsenNationalTVAudience.Females35to39PUT = If(TextLine4 Is Nothing, 0, GetDecimalValue(Mid(TextLine4, 197, 9)))
        '        NielsenNationalTVAudience.Females40to44PUT = If(TextLine4 Is Nothing, 0, GetDecimalValue(Mid(TextLine4, 206, 9)))
        '        NielsenNationalTVAudience.Females45to49PUT = If(TextLine4 Is Nothing, 0, GetDecimalValue(Mid(TextLine4, 215, 9)))
        '        NielsenNationalTVAudience.Females50to54PUT = If(TextLine4 Is Nothing, 0, GetDecimalValue(Mid(TextLine4, 224, 9)))
        '        NielsenNationalTVAudience.Females55to64PUT = If(TextLine4 Is Nothing, 0, GetDecimalValue(Mid(TextLine4, 233, 9)))
        '        NielsenNationalTVAudience.Females65PlusPUT = If(TextLine4 Is Nothing, 0, GetDecimalValue(Mid(TextLine4, 242, 9)))
        '        NielsenNationalTVAudience.Males2to5PUT = If(TextLine4 Is Nothing, 0, GetDecimalValue(Mid(TextLine4, 251, 9)))
        '        NielsenNationalTVAudience.Males6to8PUT = If(TextLine4 Is Nothing, 0, GetDecimalValue(Mid(TextLine4, 260, 9)))
        '        NielsenNationalTVAudience.Males9to11PUT = If(TextLine4 Is Nothing, 0, GetDecimalValue(Mid(TextLine4, 269, 9)))
        '        NielsenNationalTVAudience.Males12to14PUT = If(TextLine4 Is Nothing, 0, GetDecimalValue(Mid(TextLine4, 278, 9)))
        '        NielsenNationalTVAudience.Males15to17PUT = If(TextLine4 Is Nothing, 0, GetDecimalValue(Mid(TextLine4, 287, 9)))

        '        NielsenNationalTVAudience.Males18to20PUT = If(TextLine5 Is Nothing, 0, GetDecimalValue(Mid(TextLine5, 116, 9)))
        '        NielsenNationalTVAudience.Males21to24PUT = If(TextLine5 Is Nothing, 0, GetDecimalValue(Mid(TextLine5, 125, 9)))
        '        NielsenNationalTVAudience.Males25to29PUT = If(TextLine5 Is Nothing, 0, GetDecimalValue(Mid(TextLine5, 134, 9)))
        '        NielsenNationalTVAudience.Males30to34PUT = If(TextLine5 Is Nothing, 0, GetDecimalValue(Mid(TextLine5, 143, 9)))
        '        NielsenNationalTVAudience.Males35to39PUT = If(TextLine5 Is Nothing, 0, GetDecimalValue(Mid(TextLine5, 152, 9)))
        '        NielsenNationalTVAudience.Males40to44PUT = If(TextLine5 Is Nothing, 0, GetDecimalValue(Mid(TextLine5, 161, 9)))
        '        NielsenNationalTVAudience.Males45to49PUT = If(TextLine5 Is Nothing, 0, GetDecimalValue(Mid(TextLine5, 170, 9)))
        '        NielsenNationalTVAudience.Males50to54PUT = If(TextLine5 Is Nothing, 0, GetDecimalValue(Mid(TextLine5, 179, 9)))
        '        NielsenNationalTVAudience.Males55to64PUT = If(TextLine5 Is Nothing, 0, GetDecimalValue(Mid(TextLine5, 188, 9)))
        '        NielsenNationalTVAudience.Males65PlusPUT = If(TextLine5 Is Nothing, 0, GetDecimalValue(Mid(TextLine5, 197, 9)))
        '        NielsenNationalTVAudience.WorkingWomen18to20PUT = If(TextLine5 Is Nothing, 0, GetDecimalValue(Mid(TextLine5, 224, 9)))
        '        NielsenNationalTVAudience.WorkingWomen21to24PUT = If(TextLine5 Is Nothing, 0, GetDecimalValue(Mid(TextLine5, 233, 9)))
        '        NielsenNationalTVAudience.WorkingWomen25to34PUT = If(TextLine5 Is Nothing, 0, GetDecimalValue(Mid(TextLine5, 242, 9)))
        '        NielsenNationalTVAudience.WorkingWomen35to44PUT = If(TextLine5 Is Nothing, 0, GetDecimalValue(Mid(TextLine5, 251, 9)))
        '        NielsenNationalTVAudience.WorkingWomen45to49PUT = If(TextLine5 Is Nothing, 0, GetDecimalValue(Mid(TextLine5, 260, 9)))
        '        NielsenNationalTVAudience.WorkingWomen50to54PUT = If(TextLine5 Is Nothing, 0, GetDecimalValue(Mid(TextLine5, 269, 9)))
        '        NielsenNationalTVAudience.WorkingWomen55PlusPUT = If(TextLine5 Is Nothing, 0, GetDecimalValue(Mid(TextLine5, 278, 9)))

        '        NielsenNationalTVAudiences.Add(NielsenNationalTVAudience)

        '    End If

        'End Sub
        'Private Sub BulkInsertNielsenNationalTVAudienceList(SqlConnection As SqlClient.SqlConnection, SqlTransaction As SqlClient.SqlTransaction,
        '                                                    NielsenNationalTVAudiences As List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenNationalTVAudience))

        '    Dim DataTable As System.Data.DataTable = Nothing

        '    DataTable = NielsenNationalTVAudiences.ToDataTable

        '    Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(SqlConnection, SqlClient.SqlBulkCopyOptions.CheckConstraints, SqlTransaction)

        '        With SqlBulkCopy

        '            .ColumnMappings.Add("MediaMarketBreakID", "MEDIA_MARKET_BREAK_ID")
        '            .ColumnMappings.Add("TimeType", "TIME_TYPE")
        '            .ColumnMappings.Add("Stream", "STREAM")
        '            .ColumnMappings.Add("Network", "NETWORK")
        '            .ColumnMappings.Add("AudienceDate", "AUDIENCE_DATE")
        '            .ColumnMappings.Add("AudienceTime", "AUDIENCE_TIME")
        '            .ColumnMappings.Add("SequenceNumber", "SEQ_NBR")
        '            .ColumnMappings.Add("ProgramDuration", "PROGRAM_DURATION")
        '            .ColumnMappings.Add("ProgramTotalDuration", "PROGRAM_TOTAL_DURATION")
        '            .ColumnMappings.Add("ProgramName", "PROGRAM_NAME")
        '            .ColumnMappings.Add("TrackageName", "TRACKAGE_NAME")
        '            .ColumnMappings.Add("EpisodeName", "EPISODE_NAME")
        '            .ColumnMappings.Add("ProgramCode", "PROGRAM_CODE")
        '            .ColumnMappings.Add("TrackageCode", "TRACKAGE_CODE")
        '            .ColumnMappings.Add("NielsenDaypart", "NIELSEN_DAYPART")
        '            .ColumnMappings.Add("ProgramType", "PROGRAM_TYPE")
        '            .ColumnMappings.Add("IsCorrection", "IS_CORRECTION")
        '            .ColumnMappings.Add("IsBreakout", "IS_BREAKOUT")
        '            .ColumnMappings.Add("IsSpecial", "IS_SPECIAL")
        '            .ColumnMappings.Add("IsRepeat", "IS_REPEAT")
        '            .ColumnMappings.Add("IsPremiere", "IS_PREMIERE")
        '            .ColumnMappings.Add("IsOvernight", "IS_OVERNIGHT")
        '            .ColumnMappings.Add("IsDNA", "IS_DNA")
        '            .ColumnMappings.Add("IsMulticast", "IS_MULTICAST")
        '            .ColumnMappings.Add("IsComplex", "IS_COMPLEX")
        '            .ColumnMappings.Add("IsShortDuration", "IS_SHORT_DURATION")
        '            .ColumnMappings.Add("IsVariousMetadata", "IS_VARIOUS_METADATA")
        '            .ColumnMappings.Add("IsVariousTimes", "IS_VARIOUS_TIMES")
        '            .ColumnMappings.Add("IsGapped", "IS_GAPPED")
        '            .ColumnMappings.Add("IsWeeklyAverage", "IS_WEEKLY_AVERAGE")
        '            .ColumnMappings.Add("SyndicatorInfo", "SYNDICATOR_INFO")
        '            .ColumnMappings.Add("TelecastNumber", "TELECAST_NUMBER")
        '            .ColumnMappings.Add("CoverageSampleIdentification", "COVERAGE_SAMPLE_IDENTIFICATION")
        '            .ColumnMappings.Add("MarketBreakIdentifier", "MARKET_BREAK_IDENTIFIER")
        '            .ColumnMappings.Add("TotalProgramIndicator", "TOTAL_PROGRAM_INDICATOR")
        '            .ColumnMappings.Add("DaysOfWeekIndicator", "DAYS_OF_WEEK_INDICATOR")
        '            .ColumnMappings.Add("StationCount", "STATION_COUNT")
        '            .ColumnMappings.Add("HeadendCount", "HEADEND_COUNT")
        '            .ColumnMappings.Add("CoveragePercent", "COVERAGE_PERCENT")
        '            .ColumnMappings.Add("DaysCount", "DAYS_COUNT")
        '            .ColumnMappings.Add("ProgramHUT", "PROGRAM_HUT")
        '            .ColumnMappings.Add("HouseholdAudience", "HOUSEHOLD_AUD")
        '            .ColumnMappings.Add("Females2to5Audience", "FEMALES_2TO5_AUD")
        '            .ColumnMappings.Add("Females6to8Audience", "FEMALES_6TO8_AUD")
        '            .ColumnMappings.Add("Females9to11Audience", "FEMALES_9TO11_AUD")
        '            .ColumnMappings.Add("Females12to14Audience", "FEMALES_12TO14_AUD")
        '            .ColumnMappings.Add("Females15to17Audience", "FEMALES_15TO17_AUD")
        '            .ColumnMappings.Add("Females18to20Audience", "FEMALES_18TO20_AUD")
        '            .ColumnMappings.Add("Females21to24Audience", "FEMALES_21TO24_AUD")
        '            .ColumnMappings.Add("Females25to29Audience", "FEMALES_25TO29_AUD")
        '            .ColumnMappings.Add("Females30to34Audience", "FEMALES_30TO34_AUD")
        '            .ColumnMappings.Add("Females35to39Audience", "FEMALES_35TO39_AUD")
        '            .ColumnMappings.Add("Females40to44Audience", "FEMALES_40TO44_AUD")
        '            .ColumnMappings.Add("Females45to49Audience", "FEMALES_45TO49_AUD")
        '            .ColumnMappings.Add("Females50to54Audience", "FEMALES_50TO54_AUD")
        '            .ColumnMappings.Add("Females55to64Audience", "FEMALES_55TO64_AUD")
        '            .ColumnMappings.Add("Females65PlusAudience", "FEMALES_65PLUS_AUD")
        '            .ColumnMappings.Add("Males2to5Audience", "MALES_2TO5_AUD")
        '            .ColumnMappings.Add("Males6to8Audience", "MALES_6TO8_AUD")
        '            .ColumnMappings.Add("Males9to11Audience", "MALES_9TO11_AUD")
        '            .ColumnMappings.Add("Males12to14Audience", "MALES_12TO14_AUD")
        '            .ColumnMappings.Add("Males15to17Audience", "MALES_15TO17_AUD")
        '            .ColumnMappings.Add("Males18to20Audience", "MALES_18TO20_AUD")
        '            .ColumnMappings.Add("Males21to24Audience", "MALES_21TO24_AUD")
        '            .ColumnMappings.Add("Males25to29Audience", "MALES_25TO29_AUD")
        '            .ColumnMappings.Add("Males30to34Audience", "MALES_30TO34_AUD")
        '            .ColumnMappings.Add("Males35to39Audience", "MALES_35TO39_AUD")
        '            .ColumnMappings.Add("Males40to44Audience", "MALES_40TO44_AUD")
        '            .ColumnMappings.Add("Males45to49Audience", "MALES_45TO49_AUD")
        '            .ColumnMappings.Add("Males50to54Audience", "MALES_50TO54_AUD")
        '            .ColumnMappings.Add("Males55to64Audience", "MALES_55TO64_AUD")
        '            .ColumnMappings.Add("Males65PlusAudience", "MALES_65PLUS_AUD")
        '            .ColumnMappings.Add("WorkingWomen18to20Audience", "WORKING_WOMEN_18TO20_AUD")
        '            .ColumnMappings.Add("WorkingWomen21to24Audience", "WORKING_WOMEN_21TO24_AUD")
        '            .ColumnMappings.Add("WorkingWomen25to34Audience", "WORKING_WOMEN_25TO34_AUD")
        '            .ColumnMappings.Add("WorkingWomen35to44Audience", "WORKING_WOMEN_35TO44_AUD")
        '            .ColumnMappings.Add("WorkingWomen45to49Audience", "WORKING_WOMEN_45TO49_AUD")
        '            .ColumnMappings.Add("WorkingWomen50to54Audience", "WORKING_WOMEN_50TO54_AUD")
        '            .ColumnMappings.Add("WorkingWomen55PlusAudience", "WORKING_WOMEN_55PLUS_AUD")
        '            .ColumnMappings.Add("HouseholdHUT", "HOUSEHOLD_HUT")
        '            .ColumnMappings.Add("Females2to5PUT", "FEMALES_2TO5_PUT")
        '            .ColumnMappings.Add("Females6to8PUT", "FEMALES_6TO8_PUT")
        '            .ColumnMappings.Add("Females9to11PUT", "FEMALES_9TO11_PUT")
        '            .ColumnMappings.Add("Females12to14PUT", "FEMALES_12TO14_PUT")
        '            .ColumnMappings.Add("Females15to17PUT", "FEMALES_15TO17_PUT")
        '            .ColumnMappings.Add("Females18to20PUT", "FEMALES_18TO20_PUT")
        '            .ColumnMappings.Add("Females21to24PUT", "FEMALES_21TO24_PUT")
        '            .ColumnMappings.Add("Females25to29PUT", "FEMALES_25TO29_PUT")
        '            .ColumnMappings.Add("Females30to34PUT", "FEMALES_30TO34_PUT")
        '            .ColumnMappings.Add("Females35to39PUT", "FEMALES_35TO39_PUT")
        '            .ColumnMappings.Add("Females40to44PUT", "FEMALES_40TO44_PUT")
        '            .ColumnMappings.Add("Females45to49PUT", "FEMALES_45TO49_PUT")
        '            .ColumnMappings.Add("Females50to54PUT", "FEMALES_50TO54_PUT")
        '            .ColumnMappings.Add("Females55to64PUT", "FEMALES_55TO64_PUT")
        '            .ColumnMappings.Add("Females65PlusPUT", "FEMALES_65PLUS_PUT")
        '            .ColumnMappings.Add("Males2to5PUT", "MALES_2TO5_PUT")
        '            .ColumnMappings.Add("Males6to8PUT", "MALES_6TO8_PUT")
        '            .ColumnMappings.Add("Males9to11PUT", "MALES_9TO11_PUT")
        '            .ColumnMappings.Add("Males12to14PUT", "MALES_12TO14_PUT")
        '            .ColumnMappings.Add("Males15to17PUT", "MALES_15TO17_PUT")
        '            .ColumnMappings.Add("Males18to20PUT", "MALES_18TO20_PUT")
        '            .ColumnMappings.Add("Males21to24PUT", "MALES_21TO24_PUT")
        '            .ColumnMappings.Add("Males25to29PUT", "MALES_25TO29_PUT")
        '            .ColumnMappings.Add("Males30to34PUT", "MALES_30TO34_PUT")
        '            .ColumnMappings.Add("Males35to39PUT", "MALES_35TO39_PUT")
        '            .ColumnMappings.Add("Males40to44PUT", "MALES_40TO44_PUT")
        '            .ColumnMappings.Add("Males45to49PUT", "MALES_45TO49_PUT")
        '            .ColumnMappings.Add("Males50to54PUT", "MALES_50TO54_PUT")
        '            .ColumnMappings.Add("Males55to64PUT", "MALES_55TO64_PUT")
        '            .ColumnMappings.Add("Males65PlusPUT", "MALES_65PLUS_PUT")
        '            .ColumnMappings.Add("WorkingWomen18to20PUT", "WORKING_WOMEN_18TO20_PUT")
        '            .ColumnMappings.Add("WorkingWomen21to24PUT", "WORKING_WOMEN_21TO24_PUT")
        '            .ColumnMappings.Add("WorkingWomen25to34PUT", "WORKING_WOMEN_25TO34_PUT")
        '            .ColumnMappings.Add("WorkingWomen35to44PUT", "WORKING_WOMEN_35TO44_PUT")
        '            .ColumnMappings.Add("WorkingWomen45to49PUT", "WORKING_WOMEN_45TO49_PUT")
        '            .ColumnMappings.Add("WorkingWomen50to54PUT", "WORKING_WOMEN_50TO54_PUT")
        '            .ColumnMappings.Add("WorkingWomen55PlusPUT", "WORKING_WOMEN_55PLUS_PUT")

        '            .BulkCopyTimeout = 0
        '            .BatchSize = DataTable.Rows.Count
        '            .DestinationTableName = "NIELSEN_NATIONAL_TV_AUDIENCE"
        '            .WriteToServer(DataTable)

        '        End With

        '    End Using

        'End Sub
        'Private Sub AddNielsenNationalTVHutput(DbContext As AdvantageFramework.Nielsen.Database.DbContext, MediaMarketBreakID As Integer, TextLine As String, TextLine2 As String, TextLine3 As String,
        '                                       TimeType As String, Stream As String,
        '                                       ByRef NielsenNationalTVHutputs As List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenNationalTVHutput))

        '    Dim NielsenNationalTVHutput As AdvantageFramework.Nielsen.Database.Entities.NielsenNationalTVHutput = Nothing
        '    Dim HutputDate As Date = Nothing
        '    Dim HutputTime As Short = Nothing

        '    If Mid(TextLine, 44, 1) = "1" Then

        '        HutputDate = DateSerial(2000 + CInt(Mid(TextLine, 45, 2)), CInt(Mid(TextLine, 47, 2)), CInt(Mid(TextLine, 49, 2)))
        '        HutputTime = Mid(TextLine, 86, 4)

        '    End If

        '    If Not (From Entity In DbContext.GetQuery(Of AdvantageFramework.Nielsen.Database.Entities.NielsenNationalTVHutput)
        '            Where Entity.MediaMarketBreakID = MediaMarketBreakID AndAlso
        '                  Entity.TimeType = TimeType AndAlso
        '                  Entity.Stream = Stream AndAlso
        '                  Entity.HutputDate = HutputDate AndAlso
        '                  Entity.HutputTime = HutputTime
        '            Select Entity).Any Then

        '        NielsenNationalTVHutput = New AdvantageFramework.Nielsen.Database.Entities.NielsenNationalTVHutput

        '        NielsenNationalTVHutput.MediaMarketBreakID = MediaMarketBreakID
        '        NielsenNationalTVHutput.TimeType = TimeType
        '        NielsenNationalTVHutput.Stream = Stream
        '        NielsenNationalTVHutput.HutputDate = HutputDate
        '        NielsenNationalTVHutput.HutputTime = HutputTime
        '        NielsenNationalTVHutput.IsCorrection = CBool(Mid(TextLine, 11, 1))
        '        NielsenNationalTVHutput.Household = CInt(Mid(TextLine, 180, 9))

        '        NielsenNationalTVHutput.Females2to5 = CInt(Mid(TextLine2, 116, 9))
        '        NielsenNationalTVHutput.Females6to8 = CInt(Mid(TextLine2, 125, 9))
        '        NielsenNationalTVHutput.Females9to11 = CInt(Mid(TextLine2, 134, 9))
        '        NielsenNationalTVHutput.Females12to14 = CInt(Mid(TextLine2, 143, 9))
        '        NielsenNationalTVHutput.Females15to17 = CInt(Mid(TextLine2, 152, 9))
        '        NielsenNationalTVHutput.Females18to20 = CInt(Mid(TextLine2, 161, 9))
        '        NielsenNationalTVHutput.Females21to24 = CInt(Mid(TextLine2, 170, 9))
        '        NielsenNationalTVHutput.Females25to29 = CInt(Mid(TextLine2, 179, 9))
        '        NielsenNationalTVHutput.Females30to34 = CInt(Mid(TextLine2, 188, 9))
        '        NielsenNationalTVHutput.Females35to39 = CInt(Mid(TextLine2, 197, 9))
        '        NielsenNationalTVHutput.Females40to44 = CInt(Mid(TextLine2, 206, 9))
        '        NielsenNationalTVHutput.Females45to49 = CInt(Mid(TextLine2, 215, 9))
        '        NielsenNationalTVHutput.Females50to54 = CInt(Mid(TextLine2, 224, 9))
        '        NielsenNationalTVHutput.Females55to64 = CInt(Mid(TextLine2, 233, 9))
        '        NielsenNationalTVHutput.Females65Plus = CInt(Mid(TextLine2, 242, 9))
        '        NielsenNationalTVHutput.Males2to5 = CInt(Mid(TextLine2, 251, 9))
        '        NielsenNationalTVHutput.Males6to8 = CInt(Mid(TextLine2, 260, 9))
        '        NielsenNationalTVHutput.Males9to11 = CInt(Mid(TextLine2, 269, 9))
        '        NielsenNationalTVHutput.Males12to14 = CInt(Mid(TextLine2, 278, 9))
        '        NielsenNationalTVHutput.Males15to17 = CInt(Mid(TextLine2, 287, 9))

        '        NielsenNationalTVHutput.Males18to20 = CInt(Mid(TextLine3, 116, 9))
        '        NielsenNationalTVHutput.Males21to24 = CInt(Mid(TextLine3, 125, 9))
        '        NielsenNationalTVHutput.Males25to29 = CInt(Mid(TextLine3, 134, 9))
        '        NielsenNationalTVHutput.Males30to34 = CInt(Mid(TextLine3, 143, 9))
        '        NielsenNationalTVHutput.Males35to39 = CInt(Mid(TextLine3, 152, 9))
        '        NielsenNationalTVHutput.Males40to44 = CInt(Mid(TextLine3, 161, 9))
        '        NielsenNationalTVHutput.Males45to49 = CInt(Mid(TextLine3, 170, 9))
        '        NielsenNationalTVHutput.Males50to54 = CInt(Mid(TextLine3, 179, 9))
        '        NielsenNationalTVHutput.Males55to64 = CInt(Mid(TextLine3, 188, 9))
        '        NielsenNationalTVHutput.Males65Plus = CInt(Mid(TextLine3, 197, 9))
        '        NielsenNationalTVHutput.WorkingWomen18to20 = CInt(Mid(TextLine3, 224, 9))
        '        NielsenNationalTVHutput.WorkingWomen21to24 = CInt(Mid(TextLine3, 233, 9))
        '        NielsenNationalTVHutput.WorkingWomen25to34 = CInt(Mid(TextLine3, 242, 9))
        '        NielsenNationalTVHutput.WorkingWomen35to44 = CInt(Mid(TextLine3, 251, 9))
        '        NielsenNationalTVHutput.WorkingWomen45to49 = CInt(Mid(TextLine3, 260, 9))
        '        NielsenNationalTVHutput.WorkingWomen50to54 = CInt(Mid(TextLine3, 269, 9))
        '        NielsenNationalTVHutput.WorkingWomen55Plus = CInt(Mid(TextLine3, 278, 9))

        '        NielsenNationalTVHutputs.Add(NielsenNationalTVHutput)

        '    End If

        'End Sub
        'Private Sub BulkInsertNielsenNationalTVHutputList(SqlConnection As SqlClient.SqlConnection, SqlTransaction As SqlClient.SqlTransaction,
        '                                                  NielsenNationalTVHutputs As List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenNationalTVHutput))

        '    Dim DataTable As System.Data.DataTable = Nothing

        '    DataTable = NielsenNationalTVHutputs.ToDataTable

        '    Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(SqlConnection, SqlClient.SqlBulkCopyOptions.CheckConstraints, SqlTransaction)

        '        With SqlBulkCopy

        '            .ColumnMappings.Add("MediaMarketBreakID", "MEDIA_MARKET_BREAK_ID")
        '            .ColumnMappings.Add("TimeType", "TIME_TYPE")
        '            .ColumnMappings.Add("Stream", "STREAM")
        '            .ColumnMappings.Add("HutputDate", "HUTPUT_DATE")
        '            .ColumnMappings.Add("HutputTime", "HUTPUT_TIME")
        '            .ColumnMappings.Add("IsCorrection", "IS_CORRECTION")
        '            .ColumnMappings.Add("Household", "HOUSEHOLD_HUT")
        '            .ColumnMappings.Add("Females2to5", "FEMALES_2TO5_PUT")
        '            .ColumnMappings.Add("Females6to8", "FEMALES_6TO8_PUT")
        '            .ColumnMappings.Add("Females9to11", "FEMALES_9TO11_PUT")
        '            .ColumnMappings.Add("Females12to14", "FEMALES_12TO14_PUT")
        '            .ColumnMappings.Add("Females15to17", "FEMALES_15TO17_PUT")
        '            .ColumnMappings.Add("Females18to20", "FEMALES_18TO20_PUT")
        '            .ColumnMappings.Add("Females21to24", "FEMALES_21TO24_PUT")
        '            .ColumnMappings.Add("Females25to29", "FEMALES_25TO29_PUT")
        '            .ColumnMappings.Add("Females30to34", "FEMALES_30TO34_PUT")
        '            .ColumnMappings.Add("Females35to39", "FEMALES_35TO39_PUT")
        '            .ColumnMappings.Add("Females40to44", "FEMALES_40TO44_PUT")
        '            .ColumnMappings.Add("Females45to49", "FEMALES_45TO49_PUT")
        '            .ColumnMappings.Add("Females50to54", "FEMALES_50TO54_PUT")
        '            .ColumnMappings.Add("Females55to64", "FEMALES_55TO64_PUT")
        '            .ColumnMappings.Add("Females65Plus", "FEMALES_65PLUS_PUT")
        '            .ColumnMappings.Add("Males2to5", "MALES_2TO5_PUT")
        '            .ColumnMappings.Add("Males6to8", "MALES_6TO8_PUT")
        '            .ColumnMappings.Add("Males9to11", "MALES_9TO11_PUT")
        '            .ColumnMappings.Add("Males12to14", "MALES_12TO14_PUT")
        '            .ColumnMappings.Add("Males15to17", "MALES_15TO17_PUT")
        '            .ColumnMappings.Add("Males18to20", "MALES_18TO20_PUT")
        '            .ColumnMappings.Add("Males21to24", "MALES_21TO24_PUT")
        '            .ColumnMappings.Add("Males25to29", "MALES_25TO29_PUT")
        '            .ColumnMappings.Add("Males30to34", "MALES_30TO34_PUT")
        '            .ColumnMappings.Add("Males35to39", "MALES_35TO39_PUT")
        '            .ColumnMappings.Add("Males40to44", "MALES_40TO44_PUT")
        '            .ColumnMappings.Add("Males45to49", "MALES_45TO49_PUT")
        '            .ColumnMappings.Add("Males50to54", "MALES_50TO54_PUT")
        '            .ColumnMappings.Add("Males55to64", "MALES_55TO64_PUT")
        '            .ColumnMappings.Add("Males65Plus", "MALES_65PLUS_PUT")
        '            .ColumnMappings.Add("WorkingWomen18to20", "WORKING_WOMEN_18TO20_PUT")
        '            .ColumnMappings.Add("WorkingWomen21to24", "WORKING_WOMEN_21TO24_PUT")
        '            .ColumnMappings.Add("WorkingWomen25to34", "WORKING_WOMEN_25TO34_PUT")
        '            .ColumnMappings.Add("WorkingWomen35to44", "WORKING_WOMEN_35TO44_PUT")
        '            .ColumnMappings.Add("WorkingWomen45to49", "WORKING_WOMEN_45TO49_PUT")
        '            .ColumnMappings.Add("WorkingWomen50to54", "WORKING_WOMEN_50TO54_PUT")
        '            .ColumnMappings.Add("WorkingWomen55Plus", "WORKING_WOMEN_55PLUS_PUT")

        '            .BulkCopyTimeout = 0
        '            .BatchSize = DataTable.Rows.Count
        '            .DestinationTableName = "NIELSEN_NATIONAL_TV_HUTPUT"
        '            .WriteToServer(DataTable)

        '        End With

        '    End Using

        'End Sub
        'Private Sub AddNielsenNationalTVUniverse(DbContext As AdvantageFramework.Nielsen.Database.DbContext, MediaMarketBreakID As Integer,
        '                                         TextLine As String, TextLine2 As String, TextLine3 As String,
        '                                         ByRef NielsenNationalTVUniverses As List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenNationalTVUniverse))

        '    Dim NielsenNationalTVUniverse As AdvantageFramework.Nielsen.Database.Entities.NielsenNationalTVUniverse = Nothing
        '    Dim EndDate As Date = Nothing
        '    Dim StartDate As Date = Nothing

        '    If Mid(TextLine, 85, 1) <> "H" Then

        '        Throw New Exception("Record 01 - Record Type does not equal H.")

        '    ElseIf Mid(TextLine, 92, 3) <> "000" Then

        '        Throw New Exception("Record 01 - Demo Group does not equal 000.")

        '    ElseIf Mid(TextLine2, 85, 1) <> "P" Then

        '        Throw New Exception("Record 01 - Record Type does not equal P.")

        '    ElseIf Mid(TextLine2, 92, 3) <> "001" Then

        '        Throw New Exception("Record 01 - Demo Group does not equal 001.")

        '    ElseIf Mid(TextLine3, 85, 1) <> "P" Then

        '        Throw New Exception("Record 01 - Record Type does not equal P.")

        '    ElseIf Mid(TextLine3, 92, 3) <> "021" Then

        '        Throw New Exception("Record 01 - Demo Group does not equal 021.")

        '    End If

        '    If Mid(TextLine, 51, 1) <> "1" Then

        '        Throw New Exception("Record 01 - Unexpectd value found for date.")

        '    End If

        '    EndDate = DateSerial(CInt(Mid(TextLine, 52, 2)), CInt(Mid(TextLine, 54, 2)), CInt(Mid(TextLine, 56, 2)))

        '    EndDate = GetLastSundayInAugust(EndDate)

        '    StartDate = GetLastSundayInAugust(EndDate.AddYears(-1)).AddDays(1)

        '    If Not (From Entity In DbContext.GetQuery(Of AdvantageFramework.Nielsen.Database.Entities.NielsenNationalTVUniverse)
        '            Where Entity.MediaMarketBreakID = MediaMarketBreakID AndAlso
        '                  Entity.EndDate = EndDate
        '            Select Entity).Any Then

        '        NielsenNationalTVUniverse = New AdvantageFramework.Nielsen.Database.Entities.NielsenNationalTVUniverse

        '        NielsenNationalTVUniverse.MediaMarketBreakID = MediaMarketBreakID
        '        NielsenNationalTVUniverse.StartDate = StartDate
        '        NielsenNationalTVUniverse.EndDate = EndDate
        '        NielsenNationalTVUniverse.IsCorrection = CBool(Mid(TextLine, 11, 1))
        '        NielsenNationalTVUniverse.Household = CInt(Mid(TextLine, 180, 9))

        '        NielsenNationalTVUniverse.Females2to5 = CInt(Mid(TextLine2, 116, 9))
        '        NielsenNationalTVUniverse.Females6to8 = CInt(Mid(TextLine2, 125, 9))
        '        NielsenNationalTVUniverse.Females9to11 = CInt(Mid(TextLine2, 134, 9))
        '        NielsenNationalTVUniverse.Females12to14 = CInt(Mid(TextLine2, 143, 9))
        '        NielsenNationalTVUniverse.Females15to17 = CInt(Mid(TextLine2, 152, 9))
        '        NielsenNationalTVUniverse.Females18to20 = CInt(Mid(TextLine2, 161, 9))
        '        NielsenNationalTVUniverse.Females21to24 = CInt(Mid(TextLine2, 170, 9))
        '        NielsenNationalTVUniverse.Females25to29 = CInt(Mid(TextLine2, 179, 9))
        '        NielsenNationalTVUniverse.Females30to34 = CInt(Mid(TextLine2, 188, 9))
        '        NielsenNationalTVUniverse.Females35to39 = CInt(Mid(TextLine2, 197, 9))
        '        NielsenNationalTVUniverse.Females40to44 = CInt(Mid(TextLine2, 206, 9))
        '        NielsenNationalTVUniverse.Females45to49 = CInt(Mid(TextLine2, 215, 9))
        '        NielsenNationalTVUniverse.Females50to54 = CInt(Mid(TextLine2, 224, 9))
        '        NielsenNationalTVUniverse.Females55to64 = CInt(Mid(TextLine2, 233, 9))
        '        NielsenNationalTVUniverse.Females65Plus = CInt(Mid(TextLine2, 242, 9))
        '        NielsenNationalTVUniverse.Males2to5 = CInt(Mid(TextLine2, 251, 9))
        '        NielsenNationalTVUniverse.Males6to8 = CInt(Mid(TextLine2, 260, 9))
        '        NielsenNationalTVUniverse.Males9to11 = CInt(Mid(TextLine2, 269, 9))
        '        NielsenNationalTVUniverse.Males12to14 = CInt(Mid(TextLine2, 278, 9))
        '        NielsenNationalTVUniverse.Males15to17 = CInt(Mid(TextLine2, 287, 9))

        '        NielsenNationalTVUniverse.Males18to20 = CInt(Mid(TextLine3, 116, 9))
        '        NielsenNationalTVUniverse.Males21to24 = CInt(Mid(TextLine3, 125, 9))
        '        NielsenNationalTVUniverse.Males25to29 = CInt(Mid(TextLine3, 134, 9))
        '        NielsenNationalTVUniverse.Males30to34 = CInt(Mid(TextLine3, 143, 9))
        '        NielsenNationalTVUniverse.Males35to39 = CInt(Mid(TextLine3, 152, 9))
        '        NielsenNationalTVUniverse.Males40to44 = CInt(Mid(TextLine3, 161, 9))
        '        NielsenNationalTVUniverse.Males45to49 = CInt(Mid(TextLine3, 170, 9))
        '        NielsenNationalTVUniverse.Males50to54 = CInt(Mid(TextLine3, 179, 9))
        '        NielsenNationalTVUniverse.Males55to64 = CInt(Mid(TextLine3, 188, 9))
        '        NielsenNationalTVUniverse.Males65Plus = CInt(Mid(TextLine3, 197, 9))
        '        NielsenNationalTVUniverse.WorkingWomen18to20 = CInt(Mid(TextLine3, 224, 9))
        '        NielsenNationalTVUniverse.WorkingWomen21to24 = CInt(Mid(TextLine3, 233, 9))
        '        NielsenNationalTVUniverse.WorkingWomen25to34 = CInt(Mid(TextLine3, 242, 9))
        '        NielsenNationalTVUniverse.WorkingWomen35to44 = CInt(Mid(TextLine3, 251, 9))
        '        NielsenNationalTVUniverse.WorkingWomen45to49 = CInt(Mid(TextLine3, 260, 9))
        '        NielsenNationalTVUniverse.WorkingWomen50to54 = CInt(Mid(TextLine3, 269, 9))
        '        NielsenNationalTVUniverse.WorkingWomen55Plus = CInt(Mid(TextLine3, 278, 9))

        '        NielsenNationalTVUniverses.Add(NielsenNationalTVUniverse)

        '    End If

        'End Sub
        'Private Sub BulkInsertNielsenNationalTVUniverseList(SqlConnection As SqlClient.SqlConnection, SqlTransaction As SqlClient.SqlTransaction,
        '                                                    NielsenNationalTVUniverses As List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenNationalTVUniverse))

        '    Dim DataTable As System.Data.DataTable = Nothing

        '    DataTable = NielsenNationalTVUniverses.ToDataTable

        '    Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(SqlConnection, SqlClient.SqlBulkCopyOptions.CheckConstraints, SqlTransaction)

        '        With SqlBulkCopy

        '            .ColumnMappings.Add("MediaMarketBreakID", "MEDIA_MARKET_BREAK_ID")
        '            .ColumnMappings.Add("IsCorrection", "IS_CORRECTION")
        '            .ColumnMappings.Add("StartDate", "START_DATE")
        '            .ColumnMappings.Add("EndDate", "END_DATE")
        '            .ColumnMappings.Add("Household", "HOUSEHOLD_UE")
        '            .ColumnMappings.Add("Females2to5", "FEMALES_2TO5_UE")
        '            .ColumnMappings.Add("Females6to8", "FEMALES_6TO8_UE")
        '            .ColumnMappings.Add("Females9to11", "FEMALES_9TO11_UE")
        '            .ColumnMappings.Add("Females12to14", "FEMALES_12TO14_UE")
        '            .ColumnMappings.Add("Females15to17", "FEMALES_15TO17_UE")
        '            .ColumnMappings.Add("Females18to20", "FEMALES_18TO20_UE")
        '            .ColumnMappings.Add("Females21to24", "FEMALES_21TO24_UE")
        '            .ColumnMappings.Add("Females25to29", "FEMALES_25TO29_UE")
        '            .ColumnMappings.Add("Females30to34", "FEMALES_30TO34_UE")
        '            .ColumnMappings.Add("Females35to39", "FEMALES_35TO39_UE")
        '            .ColumnMappings.Add("Females40to44", "FEMALES_40TO44_UE")
        '            .ColumnMappings.Add("Females45to49", "FEMALES_45TO49_UE")
        '            .ColumnMappings.Add("Females50to54", "FEMALES_50TO54_UE")
        '            .ColumnMappings.Add("Females55to64", "FEMALES_55TO64_UE")
        '            .ColumnMappings.Add("Females65Plus", "FEMALES_65PLUS_UE")
        '            .ColumnMappings.Add("Males2to5", "MALES_2TO5_UE")
        '            .ColumnMappings.Add("Males6to8", "MALES_6TO8_UE")
        '            .ColumnMappings.Add("Males9to11", "MALES_9TO11_UE")
        '            .ColumnMappings.Add("Males12to14", "MALES_12TO14_UE")
        '            .ColumnMappings.Add("Males15to17", "MALES_15TO17_UE")
        '            .ColumnMappings.Add("Males18to20", "MALES_18TO20_UE")
        '            .ColumnMappings.Add("Males21to24", "MALES_21TO24_UE")
        '            .ColumnMappings.Add("Males25to29", "MALES_25TO29_UE")
        '            .ColumnMappings.Add("Males30to34", "MALES_30TO34_UE")
        '            .ColumnMappings.Add("Males35to39", "MALES_35TO39_UE")
        '            .ColumnMappings.Add("Males40to44", "MALES_40TO44_UE")
        '            .ColumnMappings.Add("Males45to49", "MALES_45TO49_UE")
        '            .ColumnMappings.Add("Males50to54", "MALES_50TO54_UE")
        '            .ColumnMappings.Add("Males55to64", "MALES_55TO64_UE")
        '            .ColumnMappings.Add("Males65Plus", "MALES_65PLUS_UE")
        '            .ColumnMappings.Add("WorkingWomen18to20", "WORKING_WOMEN_18TO20_UE")
        '            .ColumnMappings.Add("WorkingWomen21to24", "WORKING_WOMEN_21TO24_UE")
        '            .ColumnMappings.Add("WorkingWomen25to34", "WORKING_WOMEN_25TO34_UE")
        '            .ColumnMappings.Add("WorkingWomen35to44", "WORKING_WOMEN_35TO44_UE")
        '            .ColumnMappings.Add("WorkingWomen45to49", "WORKING_WOMEN_45TO49_UE")
        '            .ColumnMappings.Add("WorkingWomen50to54", "WORKING_WOMEN_50TO54_UE")
        '            .ColumnMappings.Add("WorkingWomen55Plus", "WORKING_WOMEN_55PLUS_UE")

        '            .BulkCopyTimeout = 0
        '            .BatchSize = DataTable.Rows.Count
        '            .DestinationTableName = "NIELSEN_NATIONAL_TV_UNIVERSE"
        '            .WriteToServer(DataTable)

        '        End With

        '    End Using

        'End Sub
        Private Function ProcessNationalFile(ConnectionString As String, ByVal PathFile As String) As Boolean

            'objects
            Dim Processed As Boolean = False
            Dim Path As String = Nothing
            Dim File As String = Nothing
            Dim SqlTransaction As SqlClient.SqlTransaction = Nothing
            'Dim MediaMarketBreak As AdvantageFramework.Nielsen.Database.Entities.MediaMarketBreak = Nothing
            Dim StreamReader As System.IO.StreamReader = Nothing
            Dim FilenameFields() As String = Nothing
            Dim FilePrefix As String = Nothing
            Dim Stream As String = Nothing
            Dim TextLine As String = Nothing
            Dim TextLine2 As String = Nothing
            Dim TextLine3 As String = Nothing
            Dim TextTemp As String = Nothing
            Dim RecordSeqCode As String = Nothing
            Dim RecordType As String = Nothing
            Dim ViewingTypes As IEnumerable(Of String) = Nothing
            Dim TimeType As String = Nothing
            Dim IsOvernight As Boolean = False
            'Dim NielsenNationalTVUniverses As List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenNationalTVUniverse) = Nothing
            'Dim NielsenNationalTVHutputs As List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenNationalTVHutput) = Nothing
            'Dim NielsenNationalTVAudiences As List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenNationalTVAudience) = Nothing
            Dim NationalAudienceLines As Classes.NationalAudienceLines = Nothing

            ViewingTypes = {" ", "2", "4", "6", "8", "A"}

            Path = System.IO.Path.GetDirectoryName(PathFile)
            File = System.IO.Path.GetFileName(PathFile)

            If System.IO.File.Exists(PathFile) Then

                Using DbContext As New AdvantageFramework.Nielsen.Database.DbContext(ConnectionString, Nothing)

                    Using SqlConnection As New SqlClient.SqlConnection(ConnectionString)

                        Try

                            SqlConnection.Open()

                            SqlTransaction = SqlConnection.BeginTransaction

                            'MediaMarketBreak = DbContext.GetQuery(Of AdvantageFramework.Nielsen.Database.Entities.MediaMarketBreak).Where(Function(MMB) MMB.BroadcastTypeID = AdvantageFramework.Nielsen.Database.Entities.BroadcastTypeID.NetworkTV AndAlso
                            '                                                                                                                            MMB.RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Nielsen AndAlso
                            '                                                                                                                            MMB.Name = "All PP").SingleOrDefault

                            'If MediaMarketBreak Is Nothing Then

                            '    Throw New Exception("Cannot find expected media market break record.")

                            'End If

                            StreamReader = New System.IO.StreamReader(PathFile)

                            FilenameFields = Mid(File.ToUpper, 1, InStr(File, ".") - 1).Split("_")

                            FilePrefix = Mid(FilenameFields(0), InStrRev(FilenameFields(0), "\") + 1)

                            Stream = Mid(File.ToUpper, InStrRev(File, ".") - 2, 2)

                            TimeType = "P"

                            For Each FilenameField In FilenameFields

                                If InStr(FilenameField, "ACM") > 0 OrElse InStr(FilenameField, "CPAGENCY") > 0 Then

                                    TimeType = "C"

                                End If

                            Next

                            'NielsenNationalTVUniverses = New List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenNationalTVUniverse)
                            'NielsenNationalTVHutputs = New List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenNationalTVHutput)
                            'NielsenNationalTVAudiences = New List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenNationalTVAudience)

                            Do While StreamReader.Peek() <> -1

                                TextLine = StreamReader.ReadLine()

                                RecordSeqCode = Mid(TextLine, 1, 2)

                                Select Case RecordSeqCode

                                    Case "01"

                                        If FilePrefix = "NTI" Then

                                            TextLine2 = StreamReader.ReadLine()
                                            TextLine3 = StreamReader.ReadLine()

                                            'AddNielsenNationalTVUniverse(DbContext, MediaMarketBreak.ID, TextLine, TextLine2, TextLine3, NielsenNationalTVUniverses)

                                        End If

                                    Case "03"

                                        If FilePrefix = "NTI" Then

                                            If ViewingTypes.Contains(Mid(TextLine, 97, 1)) AndAlso Mid(TextLine, 92, 3) = "000" AndAlso Mid(TextLine, 85, 1) = "H" AndAlso Mid(TextLine, 42, 2) = "00" Then

                                                TextLine2 = Nothing
                                                TextLine3 = Nothing

                                                Do

                                                    TextTemp = StreamReader.ReadLine()

                                                    RecordSeqCode = Mid(TextTemp, 1, 2)

                                                    If ViewingTypes.Contains(Mid(TextTemp, 97, 1)) AndAlso Mid(TextTemp, 92, 3) = "001" AndAlso RecordSeqCode = "03" AndAlso Mid(TextTemp, 85, 1) = "P" AndAlso Mid(TextTemp, 42, 2) = "00" Then

                                                        TextLine2 = TextTemp

                                                    End If

                                                    If ViewingTypes.Contains(Mid(TextTemp, 97, 1)) AndAlso Mid(TextTemp, 92, 3) = "021" AndAlso RecordSeqCode = "03" AndAlso Mid(TextTemp, 85, 1) = "P" AndAlso Mid(TextTemp, 42, 2) = "00" Then

                                                        TextLine3 = TextTemp

                                                    End If

                                                Loop Until (TextLine2 IsNot Nothing AndAlso TextLine3 IsNot Nothing) OrElse StreamReader.Peek() = -1 OrElse RecordSeqCode <> "03"

                                                If TextLine IsNot Nothing AndAlso TextLine2 IsNot Nothing AndAlso TextLine3 IsNot Nothing Then

                                                    'AddNielsenNationalTVHutput(DbContext, MediaMarketBreak.ID, TextLine, TextLine2, TextLine3, TimeType, Stream, NielsenNationalTVHutputs)

                                                Else

                                                    Throw New Exception("Could not find complete sequence of record type 03.")

                                                End If

                                            End If

                                        End If

                                    Case "04"

                                        If TimeType = "P" Then

                                            If ViewingTypes.Contains(Mid(TextLine, 97, 1)) AndAlso Mid(TextLine, 37, 1) = "1" AndAlso Mid(TextLine, 42, 2) = "00" AndAlso Mid(TextLine, 81, 2) = "00" Then

                                                If Mid(TextLine, 11, 1) = "2" Then 'deletion

                                                    DeleteNationalTVAudience(DbContext, TextLine)

                                                ElseIf Mid(TextLine, 85, 1) = "D" AndAlso Mid(TextLine, 92, 3) = "000" AndAlso Mid(TextLine, 95, 1) = "0" Then

                                                    If NationalAudienceLines IsNot Nothing Then

                                                        If FilenameFields.Contains("O") Then

                                                            IsOvernight = True

                                                        End If

                                                        'AddNielsenNationalTVAudience(DbContext, MediaMarketBreak.ID, NationalAudienceLines.MainLine, NationalAudienceLines.P0010, NationalAudienceLines.P0210, NationalAudienceLines.P0011, NationalAudienceLines.P0211, TimeType, Stream, FilePrefix, IsOvernight, NielsenNationalTVAudiences)

                                                    End If

                                                    NationalAudienceLines = New Classes.NationalAudienceLines

                                                    NationalAudienceLines.MainLine = TextLine

                                                Else

                                                    If ViewingTypes.Contains(Mid(TextLine, 97, 1)) AndAlso Mid(TextLine, 37, 1) = "1" AndAlso Mid(TextLine, 42, 2) = "00" AndAlso Mid(TextLine, 81, 2) = "00" AndAlso Mid(TextLine, 85, 1) = "P" AndAlso
                                                            Mid(TextLine, 92, 3) = "001" AndAlso Mid(TextLine, 95, 1) = "0" Then

                                                        NationalAudienceLines.P0010 = TextLine

                                                    End If

                                                    If ViewingTypes.Contains(Mid(TextLine, 97, 1)) AndAlso Mid(TextLine, 37, 1) = "1" AndAlso Mid(TextLine, 42, 2) = "00" AndAlso Mid(TextLine, 81, 2) = "00" AndAlso Mid(TextLine, 85, 1) = "P" AndAlso
                                                            Mid(TextLine, 92, 3) = "021" AndAlso Mid(TextLine, 95, 1) = "0" Then

                                                        NationalAudienceLines.P0210 = TextLine

                                                    End If

                                                    If ViewingTypes.Contains(Mid(TextLine, 97, 1)) AndAlso Mid(TextLine, 37, 1) = "1" AndAlso Mid(TextLine, 42, 2) = "00" AndAlso Mid(TextLine, 81, 2) = "00" AndAlso Mid(TextLine, 85, 1) = "P" AndAlso
                                                            Mid(TextLine, 92, 3) = "001" AndAlso Mid(TextLine, 95, 1) = "1" Then

                                                        NationalAudienceLines.P0011 = TextLine

                                                    End If

                                                    If ViewingTypes.Contains(Mid(TextLine, 97, 1)) AndAlso Mid(TextLine, 37, 1) = "1" AndAlso Mid(TextLine, 42, 2) = "00" AndAlso Mid(TextLine, 81, 2) = "00" AndAlso Mid(TextLine, 85, 1) = "P" AndAlso
                                                            Mid(TextLine, 92, 3) = "021" AndAlso Mid(TextLine, 95, 1) = "1" Then

                                                        NationalAudienceLines.P0211 = TextLine

                                                    End If

                                                End If

                                            End If

                                        End If

                                    Case "06"

                                        If TimeType <> "P" Then

                                            If ViewingTypes.Contains(Mid(TextLine, 97, 1)) AndAlso Mid(TextLine, 37, 1) = "1" AndAlso Mid(TextLine, 42, 2) = "00" AndAlso Mid(TextLine, 81, 2) = "00" Then

                                                If Mid(TextLine, 11, 1) = "2" Then 'deletion

                                                    DeleteNationalTVAudience(DbContext, TextLine)

                                                ElseIf Mid(TextLine, 85, 1) = "C" AndAlso Mid(TextLine, 92, 3) = "000" AndAlso Mid(TextLine, 95, 1) = "0" Then

                                                    If NationalAudienceLines IsNot Nothing Then

                                                        If FilenameFields.Contains("O") Then

                                                            IsOvernight = True

                                                        End If

                                                        'AddNielsenNationalTVAudience(DbContext, MediaMarketBreak.ID, NationalAudienceLines.MainLine, NationalAudienceLines.P0010, NationalAudienceLines.P0210, NationalAudienceLines.P0011, NationalAudienceLines.P0211, TimeType, Stream, FilePrefix, IsOvernight, NielsenNationalTVAudiences)

                                                    End If

                                                    NationalAudienceLines = New Classes.NationalAudienceLines

                                                    NationalAudienceLines.MainLine = TextLine

                                                Else

                                                    If ViewingTypes.Contains(Mid(TextLine, 97, 1)) AndAlso Mid(TextLine, 37, 1) = "1" AndAlso Mid(TextLine, 42, 2) = "00" AndAlso Mid(TextLine, 81, 2) = "00" AndAlso Mid(TextLine, 85, 1) = "P" AndAlso
                                                            Mid(TextLine, 92, 3) = "001" AndAlso Mid(TextLine, 95, 1) = "0" Then

                                                        NationalAudienceLines.P0010 = TextLine

                                                    End If

                                                    If ViewingTypes.Contains(Mid(TextLine, 97, 1)) AndAlso Mid(TextLine, 37, 1) = "1" AndAlso Mid(TextLine, 42, 2) = "00" AndAlso Mid(TextLine, 81, 2) = "00" AndAlso Mid(TextLine, 85, 1) = "P" AndAlso
                                                            Mid(TextLine, 92, 3) = "021" AndAlso Mid(TextLine, 95, 1) = "0" Then

                                                        NationalAudienceLines.P0210 = TextLine

                                                    End If

                                                    If ViewingTypes.Contains(Mid(TextLine, 97, 1)) AndAlso Mid(TextLine, 37, 1) = "1" AndAlso Mid(TextLine, 42, 2) = "00" AndAlso Mid(TextLine, 81, 2) = "00" AndAlso Mid(TextLine, 85, 1) = "P" AndAlso
                                                            Mid(TextLine, 92, 3) = "001" AndAlso Mid(TextLine, 95, 1) = "1" Then

                                                        NationalAudienceLines.P0011 = TextLine

                                                    End If

                                                    If ViewingTypes.Contains(Mid(TextLine, 97, 1)) AndAlso Mid(TextLine, 37, 1) = "1" AndAlso Mid(TextLine, 42, 2) = "00" AndAlso Mid(TextLine, 81, 2) = "00" AndAlso Mid(TextLine, 85, 1) = "P" AndAlso
                                                            Mid(TextLine, 92, 3) = "021" AndAlso Mid(TextLine, 95, 1) = "1" Then

                                                        NationalAudienceLines.P0211 = TextLine

                                                    End If

                                                End If

                                            End If

                                        End If

                                End Select

                            Loop

                            'BulkInsertNielsenNationalTVUniverseList(SqlConnection, SqlTransaction, NielsenNationalTVUniverses)
                            'BulkInsertNielsenNationalTVHutputList(SqlConnection, SqlTransaction, NielsenNationalTVHutputs)
                            'BulkInsertNielsenNationalTVAudienceList(SqlConnection, SqlTransaction, NielsenNationalTVAudiences)

                            SqlTransaction.Commit()

                            Processed = True

                        Catch ex As Exception

                            SqlTransaction.Rollback()

                            Throw New Exception(ex.Message & " Filename:" & PathFile)

                            'WriteToEventLog("Nielsen Import: ProcessFile: " & ex.Message)

                        Finally

                            If SqlConnection.State = ConnectionState.Open Then

                                SqlConnection.Close()

                            End If

                            StreamReader.Close()

                        End Try

                    End Using

                End Using

            End If

            ProcessNationalFile = Processed

        End Function

#End Region

#Region " Radio Data "

        Private Sub BulkInsertNielsenRadioIntabList(DbContext As AdvantageFramework.Nielsen.Database.DbContext, DbContextTransaction As Entity.DbContextTransaction,
                                                    NielsenRadioIntabs As List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioIntab))

            'objects
            Dim DataTable As System.Data.DataTable = Nothing

            DataTable = NielsenRadioIntabs.ToDataTable

            Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(DirectCast(DbContext.Database.Connection, SqlClient.SqlConnection), SqlClient.SqlBulkCopyOptions.CheckConstraints, DirectCast(DbContextTransaction.UnderlyingTransaction, SqlClient.SqlTransaction))

                With SqlBulkCopy

                    .ColumnMappings.Add("SegmentParentID", "NIELSEN_RADIO_SEGMENT_PARENT_ID")
                    .ColumnMappings.Add("Females6to11", "FEMALES_6TO11_INTAB")
                    .ColumnMappings.Add("Females12to17", "FEMALES_12TO17_INTAB")
                    .ColumnMappings.Add("Females18to20", "FEMALES_18TO20_INTAB")
                    .ColumnMappings.Add("Females18to24", "FEMALES_18TO24_INTAB")
                    .ColumnMappings.Add("Females21to24", "FEMALES_21TO24_INTAB")
                    .ColumnMappings.Add("Females25to34", "FEMALES_25TO34_INTAB")
                    .ColumnMappings.Add("Females35to44", "FEMALES_35TO44_INTAB")
                    .ColumnMappings.Add("Females35to49", "FEMALES_35TO49_INTAB")
                    .ColumnMappings.Add("Females45to49", "FEMALES_45TO49_INTAB")
                    .ColumnMappings.Add("Females50to54", "FEMALES_50TO54_INTAB")
                    .ColumnMappings.Add("Females55to64", "FEMALES_55TO64_INTAB")
                    .ColumnMappings.Add("Females65Plus", "FEMALES_65PLUS_INTAB")
                    .ColumnMappings.Add("Males6to11", "MALES_6TO11_INTAB")
                    .ColumnMappings.Add("Males12to17", "MALES_12TO17_INTAB")
                    .ColumnMappings.Add("Males18to20", "MALES_18TO20_INTAB")
                    .ColumnMappings.Add("Males18to24", "MALES_18TO24_INTAB")
                    .ColumnMappings.Add("Males21to24", "MALES_21TO24_INTAB")
                    .ColumnMappings.Add("Males25to34", "MALES_25TO34_INTAB")
                    .ColumnMappings.Add("Males35to44", "MALES_35TO44_INTAB")
                    .ColumnMappings.Add("Males35to49", "MALES_35TO49_INTAB")
                    .ColumnMappings.Add("Males45to49", "MALES_45TO49_INTAB")
                    .ColumnMappings.Add("Males50to54", "MALES_50TO54_INTAB")
                    .ColumnMappings.Add("Males55to64", "MALES_55TO64_INTAB")
                    .ColumnMappings.Add("Males65Plus", "MALES_65PLUS_INTAB")

                    .BulkCopyTimeout = 0
                    .BatchSize = DataTable.Rows.Count
                    .DestinationTableName = "NIELSEN_RADIO_INTAB"
                    .WriteToServer(DataTable)

                End With

            End Using

        End Sub
        Private Sub BulkInsertNielsenRadioUniverseList(DbContext As AdvantageFramework.Nielsen.Database.DbContext, DbContextTransaction As Entity.DbContextTransaction,
                                                       NielsenRadioUniverses As List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioUniverse))

            'objects
            Dim DataTable As System.Data.DataTable = Nothing

            DataTable = NielsenRadioUniverses.ToDataTable

            Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(DirectCast(DbContext.Database.Connection, SqlClient.SqlConnection), SqlClient.SqlBulkCopyOptions.CheckConstraints, DirectCast(DbContextTransaction.UnderlyingTransaction, SqlClient.SqlTransaction))

                With SqlBulkCopy

                    .ColumnMappings.Add("SegmentParentID", "NIELSEN_RADIO_SEGMENT_PARENT_ID")
                    .ColumnMappings.Add("Females6to11", "FEMALES_6TO11_UE")
                    .ColumnMappings.Add("Females12to17", "FEMALES_12TO17_UE")
                    .ColumnMappings.Add("Females18to20", "FEMALES_18TO20_UE")
                    .ColumnMappings.Add("Females18to24", "FEMALES_18TO24_UE")
                    .ColumnMappings.Add("Females21to24", "FEMALES_21TO24_UE")
                    .ColumnMappings.Add("Females25to34", "FEMALES_25TO34_UE")
                    .ColumnMappings.Add("Females35to44", "FEMALES_35TO44_UE")
                    .ColumnMappings.Add("Females35to49", "FEMALES_35TO49_UE")
                    .ColumnMappings.Add("Females45to49", "FEMALES_45TO49_UE")
                    .ColumnMappings.Add("Females50to54", "FEMALES_50TO54_UE")
                    .ColumnMappings.Add("Females55to64", "FEMALES_55TO64_UE")
                    .ColumnMappings.Add("Females65Plus", "FEMALES_65PLUS_UE")
                    .ColumnMappings.Add("Males6to11", "MALES_6TO11_UE")
                    .ColumnMappings.Add("Males12to17", "MALES_12TO17_UE")
                    .ColumnMappings.Add("Males18to20", "MALES_18TO20_UE")
                    .ColumnMappings.Add("Males18to24", "MALES_18TO24_UE")
                    .ColumnMappings.Add("Males21to24", "MALES_21TO24_UE")
                    .ColumnMappings.Add("Males25to34", "MALES_25TO34_UE")
                    .ColumnMappings.Add("Males35to44", "MALES_35TO44_UE")
                    .ColumnMappings.Add("Males35to49", "MALES_35TO49_UE")
                    .ColumnMappings.Add("Males45to49", "MALES_45TO49_UE")
                    .ColumnMappings.Add("Males50to54", "MALES_50TO54_UE")
                    .ColumnMappings.Add("Males55to64", "MALES_55TO64_UE")
                    .ColumnMappings.Add("Males65Plus", "MALES_65PLUS_UE")

                    .BulkCopyTimeout = 0
                    .BatchSize = DataTable.Rows.Count
                    .DestinationTableName = "NIELSEN_RADIO_UNIVERSE"
                    .WriteToServer(DataTable)

                End With

            End Using

        End Sub
        Private Sub BulkInsertNielsenRadioVStagingsList(ConnectionString As String,
                                                        NielsenRadioVStagings As List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioVStaging))

            Dim DataTable As System.Data.DataTable = Nothing

            DataTable = NielsenRadioVStagings.ToDataTable

            Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(ConnectionString, SqlClient.SqlBulkCopyOptions.CheckConstraints)

                With SqlBulkCopy

                    .ColumnMappings.Add("GeoIndicator", "GEO_INDICATOR")
                    .ColumnMappings.Add("EstimateType", "ESTIMATE_TYPE")
                    .ColumnMappings.Add("Daypart", "DAYPART")
                    .ColumnMappings.Add("ListeningLocation", "LISTENING_LOCATION")
                    .ColumnMappings.Add("DemoID", "DEMO_ID")
                    .ColumnMappings.Add("StationComboType", "STATION_COMBO_TYPE")
                    .ColumnMappings.Add("StationComboID", "STATION_COMBO_ID")
                    .ColumnMappings.Add("PurAud", "PUR_AUD")
                    .ColumnMappings.Add("NielsenRadioSegmentChildID", "NIELSEN_RADIO_SEGMENT_CHILD_ID")
                    .ColumnMappings.Add("NielsenRadioDaypartID", "NIELSEN_RADIO_DAYPART_ID")

                    .BulkCopyTimeout = 0
                    .BatchSize = DataTable.Rows.Count
                    .DestinationTableName = "NIELSEN_RADIO_V_STAGING"
                    .WriteToServer(DataTable)

                End With

            End Using

        End Sub
        Private Sub CreateRadioSegmentParentRecords(DbContext As AdvantageFramework.Nielsen.Database.DbContext, NielsenRadioPeriodID As Integer, GeoIndicator As Short)

            Dim NielsenRadioQualitative As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioQualitative = Nothing
            Dim NielsenRadioSegmentParent As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioSegmentParent = Nothing

            For Each QualitativeCode In DbContext.GetQuery(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioDemographic).Select(Function(NRD) NRD.QualitativeCode).Distinct.ToList

                If String.IsNullOrWhiteSpace(QualitativeCode) Then

                    QualitativeCode = BLANK_QUALITATIVE_CODE

                End If

                NielsenRadioQualitative = DbContext.GetQuery(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioQualitative).Where(Function(Q) Q.Code = QualitativeCode).FirstOrDefault

                If NielsenRadioQualitative Is Nothing Then

                    Throw New Exception("Cannot find Nielsen Radio Qualitative code.")

                End If

                NielsenRadioSegmentParent = (From Entity In DbContext.GetQuery(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioSegmentParent)
                                             Where Entity.NielsenRadioPeriodID = NielsenRadioPeriodID AndAlso
                                                   Entity.GeoIndicator = GeoIndicator AndAlso
                                                   Entity.NielsenRadioQualitativeID = NielsenRadioQualitative.ID
                                             Select Entity).FirstOrDefault

                If NielsenRadioSegmentParent Is Nothing Then

                    NielsenRadioSegmentParent = New AdvantageFramework.Nielsen.Database.Entities.NielsenRadioSegmentParent
                    NielsenRadioSegmentParent.DbContext = DbContext

                    NielsenRadioSegmentParent.NielsenRadioPeriodID = NielsenRadioPeriodID
                    NielsenRadioSegmentParent.GeoIndicator = GeoIndicator
                    NielsenRadioSegmentParent.NielsenRadioQualitativeID = NielsenRadioQualitative.ID

                    DbContext.NielsenRadioSegmentParents.Add(NielsenRadioSegmentParent)
                    DbContext.SaveChanges()

                End If

            Next

        End Sub
        Private Function GetIntabStagingValue(RadioIntabStagingList As Generic.List(Of Classes.RadioIntabStaging),
                                              GeoIndicator As Short, DemoID As Integer) As Integer

            Dim RadioIntabStaging As Classes.RadioIntabStaging = Nothing
            Dim Intab As Integer = 0

            RadioIntabStaging = (From AH In RadioIntabStagingList.AsParallel
                                 Where AH.GeoIndicator = GeoIndicator AndAlso
                                       AH.DemoID = DemoID
                                 Select AH).SingleOrDefault

            If RadioIntabStaging IsNot Nothing Then

                Intab = RadioIntabStaging.Intab

            End If

            GetIntabStagingValue = Intab

        End Function
        Private Function GetUniverseStagingValue(RadioUniverseStagingList As Generic.List(Of Classes.RadioUniverseStaging),
                                                 GeoIndicator As Short, DemoID As Integer) As Integer

            Dim RadioUniverseStaging As Classes.RadioUniverseStaging = Nothing
            Dim Universe As Integer = 0

            RadioUniverseStaging = (From AH In RadioUniverseStagingList.AsParallel
                                    Where AH.GeoIndicator = GeoIndicator AndAlso
                                          AH.DemoID = DemoID
                                    Select AH).SingleOrDefault

            If RadioUniverseStaging IsNot Nothing Then

                Universe = RadioUniverseStaging.Universe

            End If

            GetUniverseStagingValue = Universe

        End Function
        Private Sub ProcessARecord(DbContext As AdvantageFramework.Nielsen.Database.DbContext, TextLine As String, RadioSource As AdvantageFramework.Nielsen.Database.Entities.RadioSource,
                                   ByRef NielsenRadioPeriodID As Integer)

            'objects
            Dim NielsenRadioPeriod As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioPeriod = Nothing
            Dim NielsenRadioMarket As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioMarket = Nothing
            Dim NielsenRadioPeriodRevision As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioPeriodRevision = Nothing

            'make sure file being imported matches the RadioSource - files might be manually copied to the wrong directory!
            If Mid(TextLine, 110, 36).ToUpper.Contains("EASTLAN") Then

                If RadioSource = AdvantageFramework.Nielsen.Database.Entities.RadioSource.Nielsen Then

                    Throw New Exception("Radio file is EASTLAN and connact be imported as Nielsen.  Be sure file is in the correct path.")

                End If

            ElseIf RadioSource = AdvantageFramework.Nielsen.Database.Entities.RadioSource.Eastlan Then

                Throw New Exception("Radio file is NIELSEN and connact be imported as Eastlan.  Be sure file is in the correct path.")

            End If

            NielsenRadioPeriod = (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioPeriod.Load(DbContext)
                                  Where Entity.NielsenRadioReportTypeCode = Mid(TextLine, 2, 2).Trim AndAlso
                                        Entity.NielsenPeriodID = CInt(Mid(TextLine, 4, 6)) AndAlso
                                        Entity.NielsenRadioMarketNumber = CInt(Mid(TextLine, 10, 3)) AndAlso
                                        Entity.Source = RadioSource AndAlso
                                        Entity.ShortName = Mid(TextLine, 13, 6).Trim
                                  Select Entity).SingleOrDefault

            If NielsenRadioPeriod Is Nothing Then

                NielsenRadioPeriod = New AdvantageFramework.Nielsen.Database.Entities.NielsenRadioPeriod
                NielsenRadioPeriod.DbContext = DbContext

                NielsenRadioPeriod.NielsenRadioReportTypeCode = Mid(TextLine, 2, 2).Trim
                NielsenRadioPeriod.NielsenPeriodID = Mid(TextLine, 4, 6)
                NielsenRadioPeriod.NielsenRadioMarketNumber = CInt(Mid(TextLine, 10, 3))
                NielsenRadioPeriod.ShortName = Mid(TextLine, 13, 6).Trim
                NielsenRadioPeriod.Name = Mid(TextLine, 19, 36).Trim
                NielsenRadioPeriod.StartDate = Mid(TextLine, 55, 11)
                NielsenRadioPeriod.EndDate = Mid(TextLine, 66, 11)
                NielsenRadioPeriod.StandardCondensedIndicator = Mid(TextLine, 109, 1)
                NielsenRadioPeriod.Validated = False
                NielsenRadioPeriod.Copyright = Mid(TextLine, 110, 36)
                NielsenRadioPeriod.Source = RadioSource

                DbContext.NielsenRadioPeriods.Add(NielsenRadioPeriod)
                DbContext.SaveChanges()

            Else 'its a revision

                Throw New Exception("Radio Period exists")

                'NielsenRadioPeriodRevision = New AdvantageFramework.Nielsen.Database.Entities.NielsenRadioPeriodRevision
                'NielsenRadioPeriodRevision.DbContext = DbContext
                'NielsenRadioPeriodRevision.OldNielsenRadioPeriodID = NielsenRadioPeriod.ID

                'DbContext.Database.ExecuteSqlCommand(String.Format("exec dbo.advsp_neilsen_radio_period_delete {0}", NielsenRadioPeriod.ID))

                'NielsenRadioPeriod = New AdvantageFramework.Nielsen.Database.Entities.NielsenRadioPeriod
                'NielsenRadioPeriod.DbContext = DbContext

                'NielsenRadioPeriod.NielsenRadioReportTypeCode = Mid(TextLine, 2, 2).Trim
                'NielsenRadioPeriod.NielsenPeriodID = Mid(TextLine, 4, 6)
                'NielsenRadioPeriod.NielsenRadioMarketNumber = CInt(Mid(TextLine, 10, 3))
                'NielsenRadioPeriod.ShortName = Mid(TextLine, 13, 6).Trim
                'NielsenRadioPeriod.Name = Mid(TextLine, 19, 36).Trim
                'NielsenRadioPeriod.StartDate = Mid(TextLine, 55, 11)
                'NielsenRadioPeriod.EndDate = Mid(TextLine, 66, 11)
                'NielsenRadioPeriod.StandardCondensedIndicator = Mid(TextLine, 109, 1)
                'NielsenRadioPeriod.Validated = False
                'NielsenRadioPeriod.Copyright = Mid(TextLine, 110, 36)
                'NielsenRadioPeriod.Source = RadioSource

                'DbContext.NielsenRadioPeriods.Add(NielsenRadioPeriod)
                'DbContext.SaveChanges()

                'NielsenRadioPeriodRevision.NewNielsenRadioPeriodID = NielsenRadioPeriod.ID
                'DbContext.NielsenRadioPeriodRevisions.Add(NielsenRadioPeriodRevision)
                'DbContext.SaveChanges()

            End If

            NielsenRadioPeriodID = NielsenRadioPeriod.ID

            NielsenRadioMarket = (From Entity In DbContext.GetQuery(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioMarket)
                                  Where Entity.Number = CInt(Mid(TextLine, 10, 3).Trim) AndAlso
                                        Entity.Source = RadioSource
                                  Select Entity).SingleOrDefault

            If NielsenRadioMarket Is Nothing Then

                NielsenRadioMarket = New AdvantageFramework.Nielsen.Database.Entities.NielsenRadioMarket
                NielsenRadioMarket.DbContext = DbContext

                NielsenRadioMarket.Number = CInt(Mid(TextLine, 10, 3).Trim)
                NielsenRadioMarket.Name = Mid(TextLine, 77, 32).Trim
                NielsenRadioMarket.Source = RadioSource

                DbContext.NielsenRadioMarkets.Add(NielsenRadioMarket)
                DbContext.SaveChanges()

            End If

        End Sub
        Private Sub ProcessDRecord(DbContext As AdvantageFramework.Nielsen.Database.DbContext, TextLine As String)

            Dim NielsenRadioDemographic As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioDemographic = Nothing
            Dim NielsenRadioQualitative As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioQualitative = Nothing
            Dim QualitativeCode As String = Nothing
            Dim FullName As String = Nothing

            NielsenRadioDemographic = DbContext.GetQuery(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioDemographic).Where(Function(D) D.Number = CInt(Mid(TextLine, 4, 6))).SingleOrDefault

            If NielsenRadioDemographic Is Nothing Then

                NielsenRadioDemographic = New AdvantageFramework.Nielsen.Database.Entities.NielsenRadioDemographic
                NielsenRadioDemographic.DbContext = DbContext

                NielsenRadioDemographic.Number = Mid(TextLine, 4, 6)
                NielsenRadioDemographic.Name = Mid(TextLine, 10, 50).Trim
                NielsenRadioDemographic.AgeSexCode = Mid(TextLine, 60, 10).Trim
                NielsenRadioDemographic.QualitativeCode = If(String.IsNullOrWhiteSpace(Mid(TextLine, 70, 10).Trim), BLANK_QUALITATIVE_CODE, Mid(TextLine, 70, 10).Trim)

                DbContext.NielsenRadioDemographics.Add(NielsenRadioDemographic)
                DbContext.SaveChanges()

            End If

            QualitativeCode = Mid(TextLine, 70, 10).Trim

            If String.IsNullOrWhiteSpace(QualitativeCode) Then

                QualitativeCode = BLANK_QUALITATIVE_CODE

            End If

            NielsenRadioQualitative = DbContext.GetQuery(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioQualitative).Where(Function(D) D.Code = QualitativeCode).SingleOrDefault

            If NielsenRadioQualitative Is Nothing Then

                NielsenRadioQualitative = New AdvantageFramework.Nielsen.Database.Entities.NielsenRadioQualitative
                NielsenRadioQualitative.DbContext = DbContext

                NielsenRadioQualitative.Code = QualitativeCode

                If QualitativeCode = BLANK_QUALITATIVE_CODE Then

                    NielsenRadioQualitative.Name = BLANK_QUALITATIVE_CODE

                Else

                    FullName = Mid(TextLine, 10, 50).Trim
                    NielsenRadioQualitative.Name = Mid(FullName, InStr(FullName, ", ") + 2)

                End If

                DbContext.NielsenRadioQualitatives.Add(NielsenRadioQualitative)
                DbContext.SaveChanges()

            End If

        End Sub
        Private Sub ProcessJRecord(DbContext As AdvantageFramework.Nielsen.Database.DbContext, TextLine As String, RadioSource As AdvantageFramework.Nielsen.Database.Entities.RadioSource)

            Dim NielsenRadioStation As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioStation = Nothing
            Dim NielsenRadioMarketNumber As Integer = 0
            Dim ComboID As Integer = 0
            Dim NielsenRadioStationHistory As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioStationHistory = Nothing
            Dim ErrorMessage As String = Nothing

            If Mid(TextLine, 16, 6).Trim <> "999999" Then

                NielsenRadioMarketNumber = CInt(Mid(TextLine, 10, 3))
                ComboID = CInt(Mid(TextLine, 16, 6))

                NielsenRadioStation = (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioStation.Load(DbContext)
                                       Where Entity.NielsenRadioMarketNumber = NielsenRadioMarketNumber AndAlso
                                             Entity.ComboID = ComboID AndAlso
                                             Entity.Source = RadioSource
                                       Select Entity).SingleOrDefault

                If NielsenRadioStation IsNot Nothing Then

                    If Mid(TextLine, 58, 1) = "+" Then

                        NielsenRadioStationHistory = New AdvantageFramework.Nielsen.Database.Entities.NielsenRadioStationHistory
                        NielsenRadioStationHistory.DbContext = DbContext

                        NielsenRadioStationHistory.NielsenRadioMarketNumber = NielsenRadioStation.NielsenRadioMarketNumber
                        NielsenRadioStationHistory.ComboID = NielsenRadioStation.ComboID
                        NielsenRadioStationHistory.Name = NielsenRadioStation.Name
                        NielsenRadioStationHistory.CallLetters = NielsenRadioStation.CallLetters
                        NielsenRadioStationHistory.Band = NielsenRadioStation.Band
                        NielsenRadioStationHistory.Frequency = NielsenRadioStation.Frequency
                        NielsenRadioStationHistory.ComboType = NielsenRadioStation.ComboType
                        NielsenRadioStationHistory.IsSpillin = NielsenRadioStation.IsSpillin
                        NielsenRadioStationHistory.NielsenRadioFormatCode = NielsenRadioStation.NielsenRadioFormatCode
                        NielsenRadioStationHistory.Source = RadioSource

                        DbContext.NielsenRadioStationHistorys.Add(NielsenRadioStationHistory)
                        DbContext.SaveChanges()

                    End If

                    NielsenRadioStation.NielsenRadioMarketNumber = NielsenRadioMarketNumber
                    NielsenRadioStation.ComboID = ComboID
                    NielsenRadioStation.Name = Mid(TextLine, 22, 30).Trim
                    NielsenRadioStation.CallLetters = Mid(TextLine, 52, 4).Trim
                    NielsenRadioStation.Band = Mid(TextLine, 56, 2).Trim
                    NielsenRadioStation.Frequency = Mid(TextLine, 59, 5).Trim
                    NielsenRadioStation.ComboType = CShort(Mid(TextLine, 14, 2))
                    NielsenRadioStation.IsSpillin = If(Mid(TextLine, 69, 1) = "1", True, False)
                    NielsenRadioStation.NielsenRadioFormatCode = Mid(TextLine, 64, 4).Trim
                    NielsenRadioStation.Source = RadioSource

                    If AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioStation.Update(DbContext, NielsenRadioStation, ErrorMessage) = False Then

                        Throw New Exception(ErrorMessage)

                    End If

                End If

                If NielsenRadioStation Is Nothing Then

                    NielsenRadioStation = New AdvantageFramework.Nielsen.Database.Entities.NielsenRadioStation
                    NielsenRadioStation.DbContext = DbContext

                    NielsenRadioStation.NielsenRadioMarketNumber = NielsenRadioMarketNumber
                    NielsenRadioStation.ComboID = ComboID
                    NielsenRadioStation.Name = Mid(TextLine, 22, 30).Trim
                    NielsenRadioStation.CallLetters = Mid(TextLine, 52, 4).Trim
                    NielsenRadioStation.Band = Mid(TextLine, 56, 2).Trim
                    NielsenRadioStation.Frequency = Mid(TextLine, 59, 5).Trim
                    NielsenRadioStation.ComboType = CShort(Mid(TextLine, 14, 2))
                    NielsenRadioStation.IsSpillin = If(Mid(TextLine, 69, 1) = "1", True, False)
                    NielsenRadioStation.NielsenRadioFormatCode = Mid(TextLine, 64, 4).Trim
                    NielsenRadioStation.Source = RadioSource

                    DbContext.NielsenRadioStations.Add(NielsenRadioStation)
                    DbContext.SaveChanges()

                End If

            End If

        End Sub
        'Private Sub ProcessSRecord(DbContext As AdvantageFramework.Nielsen.Database.DbContext, TextLine As String)

        '    Dim NielsenRadioDaypart As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioDaypart = Nothing
        '    Dim NielsenDaypartID As Short = 0

        '    NielsenDaypartID = CShort(Mid(TextLine, 4, 4))

        '    NielsenRadioDaypart = DbContext.GetQuery(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioDaypart).Where(Function(D) D.NielsenDaypartID = NielsenDaypartID).SingleOrDefault

        '    If NielsenRadioDaypart Is Nothing Then

        '        NielsenRadioDaypart = New AdvantageFramework.Nielsen.Database.Entities.NielsenRadioDaypart
        '        NielsenRadioDaypart.DbContext = DbContext

        '        NielsenRadioDaypart.NielsenDaypartID = NielsenDaypartID
        '        NielsenRadioDaypart.Name = Mid(TextLine, 8, 30).Trim
        '        NielsenRadioDaypart.NumberOfQuarterhours = CShort(Mid(TextLine, 38, 3))

        '        DbContext.NielsenRadioDayparts.Add(NielsenRadioDaypart)
        '        DbContext.SaveChanges()

        '    End If

        'End Sub
        Private Sub ProcessIntabStaging(DbContext As AdvantageFramework.Nielsen.Database.DbContext, NielsenRadioPeriodID As Integer, GeoIndicator As Short,
                                        RadioIntabStagingList As Generic.List(Of Classes.RadioIntabStaging),
                                        ByRef NielsenRadioIntabs As Generic.List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioIntab))

            Dim NielsenRadioQualitative As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioQualitative = Nothing
            Dim NielsenRadioSegmentParent As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioSegmentParent = Nothing
            Dim NielsenRadioIntab As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioIntab = Nothing

            For Each QualitativeCode In DbContext.GetQuery(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioDemographic).Select(Function(NRD) NRD.QualitativeCode).Distinct.ToList

                If String.IsNullOrWhiteSpace(QualitativeCode) Then

                    QualitativeCode = BLANK_QUALITATIVE_CODE

                End If

                NielsenRadioQualitative = DbContext.GetQuery(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioQualitative).Where(Function(Q) Q.Code = QualitativeCode).FirstOrDefault

                If NielsenRadioQualitative Is Nothing Then

                    Throw New Exception("Cannot find Nielsen Radio Qualitative code.")

                End If

                NielsenRadioSegmentParent = (From Entity In DbContext.GetQuery(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioSegmentParent)
                                             Where Entity.NielsenRadioPeriodID = NielsenRadioPeriodID AndAlso
                                                   Entity.GeoIndicator = GeoIndicator AndAlso
                                                   Entity.NielsenRadioQualitativeID = NielsenRadioQualitative.ID
                                             Select Entity).FirstOrDefault

                If NielsenRadioSegmentParent Is Nothing Then

                    Throw New Exception("Cannot find NielsenRadioSegmentParent record.")

                End If

                NielsenRadioIntab = New AdvantageFramework.Nielsen.Database.Entities.NielsenRadioIntab
                NielsenRadioIntab.DbContext = DbContext
                NielsenRadioIntab.ZeroAllValues()

                NielsenRadioIntab.SegmentParentID = NielsenRadioSegmentParent.ID

                Select Case QualitativeCode

                    Case BLANK_QUALITATIVE_CODE

                        NielsenRadioIntab.Males12to17 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 1)
                        NielsenRadioIntab.Males25to34 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 3)
                        NielsenRadioIntab.Males35to44 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 4)
                        NielsenRadioIntab.Males45to49 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 5)
                        NielsenRadioIntab.Males50to54 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 6)
                        NielsenRadioIntab.Males65Plus = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 7)
                        NielsenRadioIntab.Females12to17 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 8)
                        NielsenRadioIntab.Females25to34 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 10)
                        NielsenRadioIntab.Females35to44 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 11)
                        NielsenRadioIntab.Females45to49 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 12)
                        NielsenRadioIntab.Females50to54 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 13)
                        NielsenRadioIntab.Females55to64 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 14)
                        NielsenRadioIntab.Females65Plus = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 15)
                        NielsenRadioIntab.Males55to64 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 82)
                        NielsenRadioIntab.Males6to11 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 251)
                        NielsenRadioIntab.Males18to20 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 254)
                        NielsenRadioIntab.Males21to24 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 255)
                        NielsenRadioIntab.Females6to11 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 264)
                        NielsenRadioIntab.Females18to20 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 267)
                        NielsenRadioIntab.Females21to24 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 268)

                    Case "CHILDREN"

                        NielsenRadioIntab.Males18to24 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 448)
                        NielsenRadioIntab.Males25to34 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 461)
                        NielsenRadioIntab.Males35to49 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 479)
                        NielsenRadioIntab.Males50to54 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 488)
                        NielsenRadioIntab.Males55to64 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 501)
                        NielsenRadioIntab.Males65Plus = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 514)
                        NielsenRadioIntab.Females18to24 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 533)
                        NielsenRadioIntab.Females25to34 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 544)
                        NielsenRadioIntab.Females35to49 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 561)
                        NielsenRadioIntab.Females50to54 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 570)
                        NielsenRadioIntab.Females55to64 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 583)
                        NielsenRadioIntab.Females65Plus = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 596)

                    Case "COLLEGE +"

                        NielsenRadioIntab.Males18to24 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 441)
                        NielsenRadioIntab.Males25to34 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 455)
                        NielsenRadioIntab.Males35to49 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 469)
                        NielsenRadioIntab.Males50to54 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 483)
                        NielsenRadioIntab.Males55to64 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 496)
                        NielsenRadioIntab.Males65Plus = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 509)
                        NielsenRadioIntab.Females18to24 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 526)
                        NielsenRadioIntab.Females25to34 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 539)
                        NielsenRadioIntab.Females35to49 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 552)
                        NielsenRadioIntab.Females50to54 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 565)
                        NielsenRadioIntab.Females55to64 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 578)
                        NielsenRadioIntab.Females65Plus = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 591)

                    Case "HH SIZE 1"

                        NielsenRadioIntab.Males18to24 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 449)
                        NielsenRadioIntab.Males25to34 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 463)
                        NielsenRadioIntab.Males35to49 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 473)
                        NielsenRadioIntab.Males50to54 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 490)
                        NielsenRadioIntab.Males55to64 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 503)
                        NielsenRadioIntab.Males65Plus = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 516)
                        NielsenRadioIntab.Females18to24 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 534)
                        NielsenRadioIntab.Females25to34 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 546)
                        NielsenRadioIntab.Females35to49 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 556)
                        NielsenRadioIntab.Females50to54 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 572)
                        NielsenRadioIntab.Females55to64 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 585)
                        NielsenRadioIntab.Females65Plus = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 598)

                    Case "HH SIZE 2"

                        NielsenRadioIntab.Males18to24 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 450)
                        NielsenRadioIntab.Males25to34 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 464)
                        NielsenRadioIntab.Males35to49 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 474)
                        NielsenRadioIntab.Males50to54 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 491)
                        NielsenRadioIntab.Males55to64 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 504)
                        NielsenRadioIntab.Males65Plus = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 517)
                        NielsenRadioIntab.Females35to49 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 530)
                        NielsenRadioIntab.Females18to24 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 531)
                        NielsenRadioIntab.Females25to34 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 547)
                        NielsenRadioIntab.Females50to54 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 573)
                        NielsenRadioIntab.Females55to64 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 586)
                        NielsenRadioIntab.Females65Plus = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 599)

                    Case "HH SIZE 3"

                        NielsenRadioIntab.Males18to24 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 451)
                        NielsenRadioIntab.Males25to34 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 465)
                        NielsenRadioIntab.Males35to49 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 475)
                        NielsenRadioIntab.Males50to54 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 492)
                        NielsenRadioIntab.Males55to64 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 505)
                        NielsenRadioIntab.Males65Plus = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 518)
                        NielsenRadioIntab.Females18to24 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 535)
                        NielsenRadioIntab.Females25to34 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 548)
                        NielsenRadioIntab.Females35to49 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 557)
                        NielsenRadioIntab.Females50to54 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 574)
                        NielsenRadioIntab.Females55to64 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 587)
                        NielsenRadioIntab.Females65Plus = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 600)

                    Case "HH SIZE 4+"

                        NielsenRadioIntab.Males18to24 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 452)
                        NielsenRadioIntab.Males25to34 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 466)
                        NielsenRadioIntab.Males35to49 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 476)
                        NielsenRadioIntab.Males50to54 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 493)
                        NielsenRadioIntab.Males55to64 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 506)
                        NielsenRadioIntab.Males65Plus = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 519)
                        NielsenRadioIntab.Females18to24 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 536)
                        NielsenRadioIntab.Females25to34 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 549)
                        NielsenRadioIntab.Females35to49 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 558)
                        NielsenRadioIntab.Females50to54 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 575)
                        NielsenRadioIntab.Females55to64 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 588)
                        NielsenRadioIntab.Females65Plus = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 601)

                    Case "HS GRAD"

                        NielsenRadioIntab.Males25to34 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 453)
                        NielsenRadioIntab.Males35to49 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 467)
                        NielsenRadioIntab.Males50to54 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 481)
                        NielsenRadioIntab.Males55to64 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 494)
                        NielsenRadioIntab.Males65Plus = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 507)
                        NielsenRadioIntab.Males18to24 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 520)
                        NielsenRadioIntab.Females25to34 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 537)
                        NielsenRadioIntab.Females35to49 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 550)
                        NielsenRadioIntab.Females50to54 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 563)
                        NielsenRadioIntab.Females55to64 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 576)
                        NielsenRadioIntab.Females65Plus = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 589)
                        NielsenRadioIntab.Females18to24 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 602)

                    Case "INC $75K+"

                        NielsenRadioIntab.Males25to34 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 460)
                        NielsenRadioIntab.Males18to24 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 472)
                        NielsenRadioIntab.Males35to49 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 478)
                        NielsenRadioIntab.Males50to54 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 487)
                        NielsenRadioIntab.Males55to64 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 500)
                        NielsenRadioIntab.Males65Plus = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 513)
                        NielsenRadioIntab.Females25to34 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 541)
                        NielsenRadioIntab.Females18to24 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 555)
                        NielsenRadioIntab.Females35to49 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 560)
                        NielsenRadioIntab.Females50to54 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 569)
                        NielsenRadioIntab.Females55to64 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 582)
                        NielsenRadioIntab.Females65Plus = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 595)

                    Case "INC <$25K"

                        NielsenRadioIntab.Males18to24 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 442)
                        NielsenRadioIntab.Males25to34 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 456)
                        NielsenRadioIntab.Males35to49 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 470)
                        NielsenRadioIntab.Males50to54 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 484)
                        NielsenRadioIntab.Males55to64 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 497)
                        NielsenRadioIntab.Males65Plus = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 510)
                        NielsenRadioIntab.Females18to24 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 527)
                        NielsenRadioIntab.Females25to34 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 540)
                        NielsenRadioIntab.Females35to49 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 553)
                        NielsenRadioIntab.Females50to54 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 566)
                        NielsenRadioIntab.Females55to64 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 579)
                        NielsenRadioIntab.Females65Plus = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 592)

                    Case "INC 25-49K"

                        NielsenRadioIntab.Males18to24 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 443)
                        NielsenRadioIntab.Males25to34 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 458)
                        NielsenRadioIntab.Males35to49 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 471)
                        NielsenRadioIntab.Males50to54 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 485)
                        NielsenRadioIntab.Males55to64 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 498)
                        NielsenRadioIntab.Males65Plus = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 511)
                        NielsenRadioIntab.Females18to24 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 528)
                        NielsenRadioIntab.Females25to34 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 542)
                        NielsenRadioIntab.Females35to49 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 554)
                        NielsenRadioIntab.Females50to54 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 567)
                        NielsenRadioIntab.Females55to64 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 580)
                        NielsenRadioIntab.Females65Plus = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 593)

                    Case "INC 50-74K"

                        NielsenRadioIntab.Males18to24 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 444)
                        NielsenRadioIntab.Males25to34 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 459)
                        NielsenRadioIntab.Males35to49 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 477)
                        NielsenRadioIntab.Males50to54 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 486)
                        NielsenRadioIntab.Males55to64 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 499)
                        NielsenRadioIntab.Males65Plus = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 512)
                        NielsenRadioIntab.Females18to24 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 529)
                        NielsenRadioIntab.Females25to34 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 543)
                        NielsenRadioIntab.Females35to49 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 559)
                        NielsenRadioIntab.Females50to54 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 568)
                        NielsenRadioIntab.Females55to64 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 581)
                        NielsenRadioIntab.Females65Plus = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 594)

                    Case "NO CHILDRN"

                        NielsenRadioIntab.Males18to24 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 447)
                        NielsenRadioIntab.Males25to34 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 462)
                        NielsenRadioIntab.Males35to49 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 480)
                        NielsenRadioIntab.Males50to54 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 489)
                        NielsenRadioIntab.Males55to64 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 502)
                        NielsenRadioIntab.Males65Plus = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 515)
                        NielsenRadioIntab.Females18to24 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 532)
                        NielsenRadioIntab.Females25to34 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 545)
                        NielsenRadioIntab.Females35to49 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 562)
                        NielsenRadioIntab.Females50to54 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 571)
                        NielsenRadioIntab.Females55to64 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 584)
                        NielsenRadioIntab.Females65Plus = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 597)

                    Case "SOME COLL"

                        NielsenRadioIntab.Males18to24 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 440)
                        NielsenRadioIntab.Males25to34 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 454)
                        NielsenRadioIntab.Males35to49 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 468)
                        NielsenRadioIntab.Males50to54 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 482)
                        NielsenRadioIntab.Males55to64 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 495)
                        NielsenRadioIntab.Males65Plus = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 508)
                        NielsenRadioIntab.Females18to24 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 524)
                        NielsenRadioIntab.Females25to34 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 538)
                        NielsenRadioIntab.Females35to49 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 551)
                        NielsenRadioIntab.Females50to54 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 564)
                        NielsenRadioIntab.Females55to64 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 577)
                        NielsenRadioIntab.Females65Plus = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 590)

                End Select

                NielsenRadioIntabs.Add(NielsenRadioIntab)

            Next

        End Sub
        Private Sub ProcessUniverseStaging(DbContext As AdvantageFramework.Nielsen.Database.DbContext, NielsenRadioPeriodID As Integer, GeoIndicator As Short,
                                           RadioUniverseStagingList As Generic.List(Of Classes.RadioUniverseStaging),
                                           ByRef NielsenRadioUniverses As Generic.List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioUniverse))

            Dim NielsenRadioUniverse As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioUniverse = Nothing
            Dim NielsenRadioSegmentParent As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioSegmentParent = Nothing
            Dim NielsenRadioQualitative As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioQualitative = Nothing

            For Each QualitativeCode In DbContext.GetQuery(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioDemographic).Select(Function(NRD) NRD.QualitativeCode).Distinct.ToList

                If String.IsNullOrWhiteSpace(QualitativeCode) Then

                    QualitativeCode = BLANK_QUALITATIVE_CODE

                End If

                NielsenRadioQualitative = DbContext.GetQuery(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioQualitative).Where(Function(Q) Q.Code = QualitativeCode).FirstOrDefault

                If NielsenRadioQualitative Is Nothing Then

                    Throw New Exception("Cannot find Nielsen Radio Qualitative code.")

                End If

                NielsenRadioSegmentParent = (From Entity In DbContext.GetQuery(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioSegmentParent)
                                             Where Entity.NielsenRadioPeriodID = NielsenRadioPeriodID AndAlso
                                                   Entity.GeoIndicator = GeoIndicator AndAlso
                                                   Entity.NielsenRadioQualitativeID = NielsenRadioQualitative.ID
                                             Select Entity).FirstOrDefault

                If NielsenRadioSegmentParent Is Nothing Then

                    Throw New Exception("Cannot find NielsenRadioSegmentParent record.")

                End If

                NielsenRadioUniverse = New AdvantageFramework.Nielsen.Database.Entities.NielsenRadioUniverse
                NielsenRadioUniverse.DbContext = DbContext
                NielsenRadioUniverse.ZeroAllValues()

                NielsenRadioUniverse.SegmentParentID = NielsenRadioSegmentParent.ID

                Select Case QualitativeCode

                    Case BLANK_QUALITATIVE_CODE

                        NielsenRadioUniverse.Males12to17 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 1)
                        NielsenRadioUniverse.Males25to34 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 3)
                        NielsenRadioUniverse.Males35to44 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 4)
                        NielsenRadioUniverse.Males45to49 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 5)
                        NielsenRadioUniverse.Males50to54 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 6)
                        NielsenRadioUniverse.Males65Plus = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 7)
                        NielsenRadioUniverse.Females12to17 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 8)
                        NielsenRadioUniverse.Females25to34 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 10)
                        NielsenRadioUniverse.Females35to44 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 11)
                        NielsenRadioUniverse.Females45to49 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 12)
                        NielsenRadioUniverse.Females50to54 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 13)
                        NielsenRadioUniverse.Females55to64 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 14)
                        NielsenRadioUniverse.Females65Plus = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 15)
                        NielsenRadioUniverse.Males55to64 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 82)
                        NielsenRadioUniverse.Males6to11 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 251)
                        NielsenRadioUniverse.Males18to20 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 254)
                        NielsenRadioUniverse.Males21to24 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 255)
                        NielsenRadioUniverse.Females6to11 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 264)
                        NielsenRadioUniverse.Females18to20 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 267)
                        NielsenRadioUniverse.Females21to24 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 268)

                    Case "CHILDREN"

                        NielsenRadioUniverse.Males18to24 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 448)
                        NielsenRadioUniverse.Males25to34 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 461)
                        NielsenRadioUniverse.Males35to49 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 479)
                        NielsenRadioUniverse.Males50to54 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 488)
                        NielsenRadioUniverse.Males55to64 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 501)
                        NielsenRadioUniverse.Males65Plus = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 514)
                        NielsenRadioUniverse.Females18to24 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 533)
                        NielsenRadioUniverse.Females25to34 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 544)
                        NielsenRadioUniverse.Females35to49 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 561)
                        NielsenRadioUniverse.Females50to54 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 570)
                        NielsenRadioUniverse.Females55to64 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 583)
                        NielsenRadioUniverse.Females65Plus = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 596)

                    Case "COLLEGE +"

                        NielsenRadioUniverse.Males18to24 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 441)
                        NielsenRadioUniverse.Males25to34 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 455)
                        NielsenRadioUniverse.Males35to49 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 469)
                        NielsenRadioUniverse.Males50to54 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 483)
                        NielsenRadioUniverse.Males55to64 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 496)
                        NielsenRadioUniverse.Males65Plus = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 509)
                        NielsenRadioUniverse.Females18to24 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 526)
                        NielsenRadioUniverse.Females25to34 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 539)
                        NielsenRadioUniverse.Females35to49 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 552)
                        NielsenRadioUniverse.Females50to54 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 565)
                        NielsenRadioUniverse.Females55to64 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 578)
                        NielsenRadioUniverse.Females65Plus = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 591)

                    Case "HH SIZE 1"

                        NielsenRadioUniverse.Males18to24 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 449)
                        NielsenRadioUniverse.Males25to34 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 463)
                        NielsenRadioUniverse.Males35to49 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 473)
                        NielsenRadioUniverse.Males50to54 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 490)
                        NielsenRadioUniverse.Males55to64 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 503)
                        NielsenRadioUniverse.Males65Plus = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 516)
                        NielsenRadioUniverse.Females18to24 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 534)
                        NielsenRadioUniverse.Females25to34 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 546)
                        NielsenRadioUniverse.Females35to49 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 556)
                        NielsenRadioUniverse.Females50to54 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 572)
                        NielsenRadioUniverse.Females55to64 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 585)
                        NielsenRadioUniverse.Females65Plus = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 598)

                    Case "HH SIZE 2"

                        NielsenRadioUniverse.Males18to24 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 450)
                        NielsenRadioUniverse.Males25to34 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 464)
                        NielsenRadioUniverse.Males35to49 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 474)
                        NielsenRadioUniverse.Males50to54 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 491)
                        NielsenRadioUniverse.Males55to64 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 504)
                        NielsenRadioUniverse.Males65Plus = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 517)
                        NielsenRadioUniverse.Females35to49 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 530)
                        NielsenRadioUniverse.Females18to24 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 531)
                        NielsenRadioUniverse.Females25to34 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 547)
                        NielsenRadioUniverse.Females50to54 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 573)
                        NielsenRadioUniverse.Females55to64 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 586)
                        NielsenRadioUniverse.Females65Plus = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 599)

                    Case "HH SIZE 3"

                        NielsenRadioUniverse.Males18to24 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 451)
                        NielsenRadioUniverse.Males25to34 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 465)
                        NielsenRadioUniverse.Males35to49 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 475)
                        NielsenRadioUniverse.Males50to54 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 492)
                        NielsenRadioUniverse.Males55to64 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 505)
                        NielsenRadioUniverse.Males65Plus = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 518)
                        NielsenRadioUniverse.Females18to24 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 535)
                        NielsenRadioUniverse.Females25to34 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 548)
                        NielsenRadioUniverse.Females35to49 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 557)
                        NielsenRadioUniverse.Females50to54 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 574)
                        NielsenRadioUniverse.Females55to64 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 587)
                        NielsenRadioUniverse.Females65Plus = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 600)

                    Case "HH SIZE 4+"

                        NielsenRadioUniverse.Males18to24 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 452)
                        NielsenRadioUniverse.Males25to34 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 466)
                        NielsenRadioUniverse.Males35to49 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 476)
                        NielsenRadioUniverse.Males50to54 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 493)
                        NielsenRadioUniverse.Males55to64 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 506)
                        NielsenRadioUniverse.Males65Plus = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 519)
                        NielsenRadioUniverse.Females18to24 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 536)
                        NielsenRadioUniverse.Females25to34 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 549)
                        NielsenRadioUniverse.Females35to49 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 558)
                        NielsenRadioUniverse.Females50to54 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 575)
                        NielsenRadioUniverse.Females55to64 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 588)
                        NielsenRadioUniverse.Females65Plus = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 601)

                    Case "HS GRAD"

                        NielsenRadioUniverse.Males25to34 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 453)
                        NielsenRadioUniverse.Males35to49 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 467)
                        NielsenRadioUniverse.Males50to54 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 481)
                        NielsenRadioUniverse.Males55to64 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 494)
                        NielsenRadioUniverse.Males65Plus = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 507)
                        NielsenRadioUniverse.Males18to24 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 520)
                        NielsenRadioUniverse.Females25to34 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 537)
                        NielsenRadioUniverse.Females35to49 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 550)
                        NielsenRadioUniverse.Females50to54 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 563)
                        NielsenRadioUniverse.Females55to64 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 576)
                        NielsenRadioUniverse.Females65Plus = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 589)
                        NielsenRadioUniverse.Females18to24 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 602)

                    Case "INC $75K+"

                        NielsenRadioUniverse.Males25to34 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 460)
                        NielsenRadioUniverse.Males18to24 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 472)
                        NielsenRadioUniverse.Males35to49 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 478)
                        NielsenRadioUniverse.Males50to54 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 487)
                        NielsenRadioUniverse.Males55to64 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 500)
                        NielsenRadioUniverse.Males65Plus = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 513)
                        NielsenRadioUniverse.Females25to34 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 541)
                        NielsenRadioUniverse.Females18to24 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 555)
                        NielsenRadioUniverse.Females35to49 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 560)
                        NielsenRadioUniverse.Females50to54 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 569)
                        NielsenRadioUniverse.Females55to64 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 582)
                        NielsenRadioUniverse.Females65Plus = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 595)

                    Case "INC <$25K"

                        NielsenRadioUniverse.Males18to24 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 442)
                        NielsenRadioUniverse.Males25to34 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 456)
                        NielsenRadioUniverse.Males35to49 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 470)
                        NielsenRadioUniverse.Males50to54 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 484)
                        NielsenRadioUniverse.Males55to64 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 497)
                        NielsenRadioUniverse.Males65Plus = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 510)
                        NielsenRadioUniverse.Females18to24 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 527)
                        NielsenRadioUniverse.Females25to34 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 540)
                        NielsenRadioUniverse.Females35to49 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 553)
                        NielsenRadioUniverse.Females50to54 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 566)
                        NielsenRadioUniverse.Females55to64 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 579)
                        NielsenRadioUniverse.Females65Plus = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 592)

                    Case "INC 25-49K"

                        NielsenRadioUniverse.Males18to24 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 443)
                        NielsenRadioUniverse.Males25to34 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 458)
                        NielsenRadioUniverse.Males35to49 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 471)
                        NielsenRadioUniverse.Males50to54 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 485)
                        NielsenRadioUniverse.Males55to64 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 498)
                        NielsenRadioUniverse.Males65Plus = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 511)
                        NielsenRadioUniverse.Females18to24 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 528)
                        NielsenRadioUniverse.Females25to34 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 542)
                        NielsenRadioUniverse.Females35to49 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 554)
                        NielsenRadioUniverse.Females50to54 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 567)
                        NielsenRadioUniverse.Females55to64 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 580)
                        NielsenRadioUniverse.Females65Plus = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 593)

                    Case "INC 50-74K"

                        NielsenRadioUniverse.Males18to24 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 444)
                        NielsenRadioUniverse.Males25to34 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 459)
                        NielsenRadioUniverse.Males35to49 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 477)
                        NielsenRadioUniverse.Males50to54 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 486)
                        NielsenRadioUniverse.Males55to64 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 499)
                        NielsenRadioUniverse.Males65Plus = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 512)
                        NielsenRadioUniverse.Females18to24 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 529)
                        NielsenRadioUniverse.Females25to34 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 543)
                        NielsenRadioUniverse.Females35to49 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 559)
                        NielsenRadioUniverse.Females50to54 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 568)
                        NielsenRadioUniverse.Females55to64 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 581)
                        NielsenRadioUniverse.Females65Plus = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 594)

                    Case "NO CHILDRN"

                        NielsenRadioUniverse.Males18to24 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 447)
                        NielsenRadioUniverse.Males25to34 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 462)
                        NielsenRadioUniverse.Males35to49 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 480)
                        NielsenRadioUniverse.Males50to54 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 489)
                        NielsenRadioUniverse.Males55to64 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 502)
                        NielsenRadioUniverse.Males65Plus = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 515)
                        NielsenRadioUniverse.Females18to24 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 532)
                        NielsenRadioUniverse.Females25to34 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 545)
                        NielsenRadioUniverse.Females35to49 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 562)
                        NielsenRadioUniverse.Females50to54 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 571)
                        NielsenRadioUniverse.Females55to64 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 584)
                        NielsenRadioUniverse.Females65Plus = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 597)

                    Case "SOME COLL"

                        NielsenRadioUniverse.Males18to24 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 440)
                        NielsenRadioUniverse.Males25to34 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 454)
                        NielsenRadioUniverse.Males35to49 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 468)
                        NielsenRadioUniverse.Males50to54 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 482)
                        NielsenRadioUniverse.Males55to64 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 495)
                        NielsenRadioUniverse.Males65Plus = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 508)
                        NielsenRadioUniverse.Females18to24 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 524)
                        NielsenRadioUniverse.Females25to34 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 538)
                        NielsenRadioUniverse.Females35to49 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 551)
                        NielsenRadioUniverse.Females50to54 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 564)
                        NielsenRadioUniverse.Females55to64 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 577)
                        NielsenRadioUniverse.Females65Plus = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 590)

                End Select

                NielsenRadioUniverses.Add(NielsenRadioUniverse)

            Next

        End Sub
        Private Function ProcessRadioFile(ConnectionString As String, Filename As String, RadioSource As AdvantageFramework.Nielsen.Database.Entities.RadioSource) As Boolean

            'objects
            Dim Processed As Boolean = False
            Dim StreamReader As System.IO.StreamReader = Nothing
            Dim NielsenRadioIntabs As Generic.List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioIntab) = Nothing
            Dim NielsenRadioUniverses As Generic.List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioUniverse) = Nothing
            Dim NielsenRadioAudiences As Generic.List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioAudience) = Nothing
            Dim RadioIntabStagingList As Generic.List(Of Classes.RadioIntabStaging) = Nothing
            Dim RadioIntabStaging As Classes.RadioIntabStaging = Nothing
            Dim RadioUniverseStagingList As Generic.List(Of Classes.RadioUniverseStaging) = Nothing
            Dim RadioUniverseStaging As Classes.RadioUniverseStaging = Nothing
            Dim NielsenRadioVStagings As Generic.List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioVStaging) = Nothing
            Dim NielsenRadioVStaging As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioVStaging = Nothing
            Dim TextLine As String = Nothing
            Dim NielsenRadioPeriodID As Integer = 0
            Dim GeoIndicators As IEnumerable(Of Short) = Nothing

            If System.IO.File.Exists(Filename) Then

                Using DbContext As New AdvantageFramework.Nielsen.Database.DbContext(ConnectionString, Nothing)

                    DbContext.Database.ExecuteSqlCommand("TRUNCATE TABLE dbo.NIELSEN_RADIO_V_STAGING")

                    Using tran = DbContext.Database.BeginTransaction()

                        Try

                            StreamReader = New System.IO.StreamReader(Filename)

                            NielsenRadioIntabs = New Generic.List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioIntab)

                            NielsenRadioUniverses = New Generic.List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioUniverse)

                            NielsenRadioAudiences = New Generic.List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioAudience)

                            RadioIntabStagingList = New Generic.List(Of Classes.RadioIntabStaging)

                            RadioUniverseStagingList = New Generic.List(Of Classes.RadioUniverseStaging)

                            NielsenRadioVStagings = New Generic.List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioVStaging)

                            Do While StreamReader.Peek() <> -1

                                TextLine = StreamReader.ReadLine()

                                Select Case Mid(TextLine, 1, 1)

                                    Case "A"

                                        ProcessARecord(DbContext, TextLine, RadioSource, NielsenRadioPeriodID)

                                    Case "D"

                                        ProcessDRecord(DbContext, TextLine)

                                    Case "G"

                                        RadioIntabStaging = New Classes.RadioIntabStaging

                                        RadioIntabStaging.Intab = CInt(Mid(TextLine, 20, 6))
                                        RadioIntabStaging.DemoID = Mid(TextLine, 14, 6)
                                        RadioIntabStaging.GeoIndicator = CShort(Mid(TextLine, 13, 1))

                                        RadioIntabStagingList.Add(RadioIntabStaging)

                                    Case "H"

                                        RadioUniverseStaging = New Classes.RadioUniverseStaging

                                        RadioUniverseStaging.Universe = CInt(Mid(TextLine, 20, 6)) * 100
                                        RadioUniverseStaging.DemoID = Mid(TextLine, 14, 6)
                                        RadioUniverseStaging.GeoIndicator = CShort(Mid(TextLine, 13, 1))

                                        RadioUniverseStagingList.Add(RadioUniverseStaging)

                                    Case "J"

                                        ProcessJRecord(DbContext, TextLine, RadioSource)

                                'Case "S"

                                '    ProcessSRecord(DbContext, TextLine)

                                    Case "V"

                                        If CInt(Mid(TextLine, 35, 8)) <> 0 Then

                                            NielsenRadioVStaging = New AdvantageFramework.Nielsen.Database.Entities.NielsenRadioVStaging
                                            NielsenRadioVStaging.GeoIndicator = CShort(Mid(TextLine, 13, 1))
                                            NielsenRadioVStaging.EstimateType = CShort(Mid(TextLine, 14, 1))
                                            NielsenRadioVStaging.Daypart = CShort(Mid(TextLine, 15, 4))
                                            NielsenRadioVStaging.ListeningLocation = Mid(TextLine, 19, 1)
                                            NielsenRadioVStaging.DemoID = CInt(Mid(TextLine, 20, 6))
                                            NielsenRadioVStaging.StationComboType = CShort(Mid(TextLine, 26, 2))
                                            NielsenRadioVStaging.StationComboID = Mid(TextLine, 28, 6).Trim
                                            NielsenRadioVStaging.PurAud = CInt(Mid(TextLine, 35, 8))

                                            NielsenRadioVStagings.Add(NielsenRadioVStaging)

                                        End If

                                End Select

                            Loop

                            GeoIndicators = ((From Entity In RadioIntabStagingList
                                              Select Entity.GeoIndicator).Distinct.ToArray.Union(
                                        (From Entity In RadioUniverseStagingList
                                         Select Entity.GeoIndicator).Distinct.ToArray))

                            For Each GeoIndicator In GeoIndicators

                                CreateRadioSegmentParentRecords(DbContext, NielsenRadioPeriodID, GeoIndicator)

                            Next

                            For Each GeoIndicator In RadioIntabStagingList.Select(Function(F) F.GeoIndicator).Distinct.ToList

                                ProcessIntabStaging(DbContext, NielsenRadioPeriodID, GeoIndicator, RadioIntabStagingList, NielsenRadioIntabs)

                            Next

                            For Each GeoIndicator In RadioUniverseStagingList.Select(Function(F) F.GeoIndicator).Distinct.ToList

                                ProcessUniverseStaging(DbContext, NielsenRadioPeriodID, GeoIndicator, RadioUniverseStagingList, NielsenRadioUniverses)

                            Next

                            BulkInsertNielsenRadioVStagingsList(ConnectionString, NielsenRadioVStagings)

                            DbContext.Database.ExecuteSqlCommand("exec [dbo].[advsp_nielsen_radio_segment_child_insert]")

                            For Each GeoI In (From Entity In DbContext.GetQuery(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioVStaging)
                                              Where Entity.EstimateType = 1 AndAlso
                                            Entity.StationComboID = "999999"
                                              Select Entity.GeoIndicator).Distinct.ToList

                                DbContext.Database.ExecuteSqlCommand(String.Format("exec [dbo].[advsp_nielsen_radio_pur_insert] {0}, {1}", NielsenRadioPeriodID, GeoI))

                            Next

                            For Each GeoI In (From Entity In DbContext.GetQuery(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioVStaging)
                                              Where (Entity.EstimateType = 1 OrElse
                                                Entity.EstimateType = 2 OrElse
                                                Entity.EstimateType = 3 OrElse
                                                Entity.EstimateType = 4) AndAlso
                                                Entity.StationComboID <> "999999"
                                              Select Entity.GeoIndicator).Distinct.ToList

                                DbContext.Database.ExecuteSqlCommand(String.Format("exec [dbo].[advsp_nielsen_radio_audience_insert] {0}, {1}", NielsenRadioPeriodID, GeoI))

                            Next

                            BulkInsertNielsenRadioUniverseList(DbContext, tran, NielsenRadioUniverses)

                            BulkInsertNielsenRadioIntabList(DbContext, tran, NielsenRadioIntabs)

                            tran.Commit()

                            Processed = True

                        Catch ex As Exception

                            tran.Rollback()

                            Throw New Exception(ex.Message & " Filename:" & Filename)

                        Finally

                            StreamReader.Close()

                        End Try

                    End Using

                End Using

            End If

            ProcessRadioFile = Processed

        End Function
        Private Sub SaveRadioCountyFiles(NielsenDbContext As Database.NielsenDbContext, Radio_County_Path As String)

            'objects
            Dim DownloadFile As Database.Entities.DownloadFile = Nothing
            Dim LastWriteTime As Date = Nothing

            For Each Filename In System.IO.Directory.GetFiles(Radio_County_Path)

                LastWriteTime = System.IO.File.GetLastWriteTime(Filename).AddMilliseconds(-System.IO.File.GetLastWriteTime(Filename).Millisecond)

                Filename = System.IO.Path.GetFileName(Filename)

                DownloadFile = NielsenFramework.Database.Procedures.DownloadFile.LoadByFileName(NielsenDbContext, Filename)

                If DownloadFile Is Nothing Then

                    DownloadFile = New Database.Entities.DownloadFile
                    DownloadFile.DbContext = NielsenDbContext

                    DownloadFile.FileName = Filename
                    DownloadFile.FileType = Database.Entities.Methods.DownloadFileType.RadioCounty
                    DownloadFile.LastWriteTime = LastWriteTime

                    NielsenDbContext.DownloadFiles.Add(DownloadFile)

                    'ElseIf DownloadFile.LastWriteTime < LastWriteTime AndAlso Datediff(DateInterval.Second, DownloadFile.LastWriteTime, LastWriteTime) <> 0 Then

                    '    DownloadFile.LastWriteTime = LastWriteTime
                    '    DownloadFile.ProcessedTime = Nothing
                    '    NielsenDbContext.Entry(DownloadFile).State = Entity.EntityState.Modified

                End If

            Next

            NielsenDbContext.SaveChanges()

        End Sub
        Private Function GetMondayOnOrBefore(Year As Integer) As Date

            'objects
            Dim Monday As Date = Nothing

            Monday = New Date(Year, 1, 1)

            Do While Monday.DayOfWeek <> DayOfWeek.Monday

                Monday = Monday.AddDays(-1)

            Loop

            GetMondayOnOrBefore = Monday

        End Function
        Private Function GetSundayOnOrBefore(Year As Integer) As Date

            'objects
            Dim Sunday As Date = Nothing

            Sunday = New Date(Year, 12, 31)

            Do While Sunday.DayOfWeek <> DayOfWeek.Sunday

                Sunday = Sunday.AddDays(-1)

            Loop

            GetSundayOnOrBefore = Sunday

        End Function
        Private Sub ProcessRC1L1(DbContext As AdvantageFramework.Nielsen.Database.DbContext, Copyright As String, Year As Integer, TextLine As String)

            'objects
            Dim NielsenRadioMarketNumber As Integer = 0
            Dim NielsenRadioMarket As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioMarket = Nothing
            Dim NielsenRadioCountyPeriod As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioCountyPeriod = Nothing
            Dim ErrorString As String = Nothing
            Dim NielsenRadioCountyUniverse As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioCountyUniverse = Nothing
            Dim NielsenRadioCountyIntab As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioCountyIntab = Nothing

            NielsenRadioMarketNumber = Mid(TextLine, 98, 3)

            NielsenRadioMarket = (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioMarket.Load(DbContext)
                                  Where Entity.Number = NielsenRadioMarketNumber AndAlso
                                        Entity.Source = AdvantageFramework.Nielsen.Database.Entities.RadioSource.NielsenCounty
                                  Select Entity).SingleOrDefault

            If NielsenRadioMarket Is Nothing Then

                NielsenRadioMarket = New AdvantageFramework.Nielsen.Database.Entities.NielsenRadioMarket

                NielsenRadioMarket.Number = NielsenRadioMarketNumber
                NielsenRadioMarket.Name = Mid(TextLine, 66, 32).Trim
                NielsenRadioMarket.Source = AdvantageFramework.Nielsen.Database.Entities.RadioSource.NielsenCounty

                If Not AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioMarket.Insert(DbContext, NielsenRadioMarket, ErrorString) Then

                    Throw New Exception(ErrorString)

                End If

            End If

            NielsenRadioCountyPeriod = (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioCountyPeriod.Load(DbContext)
                                        Where Entity.CountyCode = CInt(Mid(TextLine, 1, 6)) AndAlso
                                              Entity.Year = Year
                                        Select Entity).SingleOrDefault

            If NielsenRadioCountyPeriod Is Nothing Then

                NielsenRadioCountyPeriod = New AdvantageFramework.Nielsen.Database.Entities.NielsenRadioCountyPeriod
                NielsenRadioCountyPeriod.NielsenRadioMarketNumber = NielsenRadioMarketNumber
                NielsenRadioCountyPeriod.CountyCode = CInt(Mid(TextLine, 1, 6))
                NielsenRadioCountyPeriod.Year = Year
                NielsenRadioCountyPeriod.StartDate = GetMondayOnOrBefore(Year)
                NielsenRadioCountyPeriod.EndDate = GetSundayOnOrBefore(Year)
                NielsenRadioCountyPeriod.IsCluster = False
                NielsenRadioCountyPeriod.Name = Mid(TextLine, 7, 22).Trim
                NielsenRadioCountyPeriod.State = Mid(TextLine, 29, 2).Trim
                NielsenRadioCountyPeriod.WeightingFlag = Mid(TextLine, 101, 1).Trim
                NielsenRadioCountyPeriod.MeasurementType = Mid(TextLine, 228, 1).Trim
                NielsenRadioCountyPeriod.Copyright = Copyright
                NielsenRadioCountyPeriod.Validated = False

                If Not AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioCountyPeriod.Insert(DbContext, NielsenRadioCountyPeriod, ErrorString) Then

                    Throw New Exception(ErrorString)

                End If

                NielsenRadioCountyUniverse = New AdvantageFramework.Nielsen.Database.Entities.NielsenRadioCountyUniverse
                NielsenRadioCountyUniverse.NielsenRadioCountyPeriodID = NielsenRadioCountyPeriod.ID
                NielsenRadioCountyUniverse.Persons12Plus = Mid(TextLine, 102, 6) * 100
                NielsenRadioCountyUniverse.Persons12to34 = Mid(TextLine, 108, 6) * 100
                NielsenRadioCountyUniverse.Persons18Plus = Mid(TextLine, 114, 6) * 100
                NielsenRadioCountyUniverse.Persons18to34 = Mid(TextLine, 120, 6) * 100
                NielsenRadioCountyUniverse.Persons25to54 = Mid(TextLine, 126, 6) * 100
                NielsenRadioCountyUniverse.Persons35Plus = Mid(TextLine, 132, 6) * 100
                NielsenRadioCountyUniverse.Persons35to64 = Mid(TextLine, 138, 6) * 100
                NielsenRadioCountyUniverse.Males18Plus = Mid(TextLine, 144, 6) * 100
                NielsenRadioCountyUniverse.Females18Plus = Mid(TextLine, 150, 6) * 100

                DbContext.NielsenRadioCountyUniverses.Add(NielsenRadioCountyUniverse)

                NielsenRadioCountyIntab = New AdvantageFramework.Nielsen.Database.Entities.NielsenRadioCountyIntab
                NielsenRadioCountyIntab.NielsenRadioCountyPeriodID = NielsenRadioCountyPeriod.ID
                NielsenRadioCountyIntab.Persons12Plus = Mid(TextLine, 156, 6)
                NielsenRadioCountyIntab.Persons12to34 = Mid(TextLine, 162, 6)
                NielsenRadioCountyIntab.Persons18Plus = Mid(TextLine, 168, 6)
                NielsenRadioCountyIntab.Persons18to34 = Mid(TextLine, 174, 6)
                NielsenRadioCountyIntab.Persons25to54 = Mid(TextLine, 180, 6)
                NielsenRadioCountyIntab.Persons35Plus = Mid(TextLine, 186, 6)
                NielsenRadioCountyIntab.Persons35to64 = Mid(TextLine, 192, 6)
                NielsenRadioCountyIntab.Males18Plus = Mid(TextLine, 198, 6)
                NielsenRadioCountyIntab.Females18Plus = Mid(TextLine, 204, 6)

                DbContext.NielsenRadioCountyIntabs.Add(NielsenRadioCountyIntab)

            End If

        End Sub
        Private Sub ProcessRC1L2(DbContext As AdvantageFramework.Nielsen.Database.DbContext, Year As Short, TextLine As String)

            'objects
            Dim NielsenRadioClusterCountyCode As Integer = 0
            Dim NielsenRadioCountyCodeWithinCluster As Integer = 0
            Dim NielsenRadioCountyPeriod As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioCountyPeriod = Nothing
            Dim NielsenRadioCountyCluster As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioCountyCluster = Nothing

            NielsenRadioClusterCountyCode = Mid(TextLine, 1, 6)
            NielsenRadioCountyCodeWithinCluster = Mid(TextLine, 7, 6)

            NielsenRadioCountyPeriod = (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioCountyPeriod.Load(DbContext)
                                        Where Entity.CountyCode = NielsenRadioClusterCountyCode AndAlso
                                              Entity.Year = Year
                                        Select Entity).SingleOrDefault

            If NielsenRadioCountyPeriod Is Nothing Then

                Throw New Exception("Could not find cluster county code:" & NielsenRadioClusterCountyCode)

            Else

                NielsenRadioCountyPeriod.IsCluster = True

                DbContext.TryAttach(NielsenRadioCountyPeriod)

                DbContext.Entry(NielsenRadioCountyPeriod).State = Entity.EntityState.Modified

                NielsenRadioCountyCluster = (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioCountyCluster.Load(DbContext)
                                             Where Entity.NielsenRadioCountyPeriodID = NielsenRadioCountyPeriod.ID AndAlso
                                                   Entity.CountyCodeWithinCluster = NielsenRadioCountyCodeWithinCluster
                                             Select Entity).SingleOrDefault

                If NielsenRadioCountyCluster Is Nothing Then

                    NielsenRadioCountyCluster = New AdvantageFramework.Nielsen.Database.Entities.NielsenRadioCountyCluster
                    NielsenRadioCountyCluster.NielsenRadioCountyPeriodID = NielsenRadioCountyPeriod.ID
                    NielsenRadioCountyCluster.CountyCodeWithinCluster = NielsenRadioCountyCodeWithinCluster
                    NielsenRadioCountyCluster.Name = Mid(TextLine, 13, 22).Trim
                    NielsenRadioCountyCluster.Pop12Plus = CInt(Mid(TextLine, 37, 6)) * 100
                    NielsenRadioCountyCluster.State = Mid(TextLine, 35, 2).Trim
                    NielsenRadioCountyCluster.ClusterMeasurementType = Mid(TextLine, 43, 1).Trim

                    DbContext.NielsenRadioCountyClusters.Add(NielsenRadioCountyCluster)

                End If

            End If

        End Sub
        Private Sub ProcessRC1L3(DbContext As AdvantageFramework.Nielsen.Database.DbContext, Year As Short, TextLine As String)

            'objects
            Dim NielsenRadioCountyStation As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioCountyStation = Nothing
            Dim Band As String = Nothing

            Band = If(Mid(TextLine, 5, 1) = "A", "AM", "FM")

            NielsenRadioCountyStation = (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioCountyStation.Load(DbContext)
                                         Where Entity.Year = Year AndAlso
                                               Entity.CallLetters = Mid(TextLine, 1, 4) AndAlso
                                               Entity.Band = Band
                                         Select Entity).SingleOrDefault

            If NielsenRadioCountyStation Is Nothing Then

                NielsenRadioCountyStation = New AdvantageFramework.Nielsen.Database.Entities.NielsenRadioCountyStation
                NielsenRadioCountyStation.Year = Year
                NielsenRadioCountyStation.CallLetters = Mid(TextLine, 1, 4).Trim
                NielsenRadioCountyStation.Band = Band
                NielsenRadioCountyStation.CityLicense = Mid(TextLine, 6, 19).Trim
                NielsenRadioCountyStation.CountyLicense = Mid(TextLine, 25, 18).Trim
                NielsenRadioCountyStation.StateLicense = Mid(TextLine, 43, 2).Trim
                NielsenRadioCountyStation.Affiliation = Mid(TextLine, 45, 2).Trim
                NielsenRadioCountyStation.OtherAffiliations = Mid(TextLine, 47, 14).Trim
                NielsenRadioCountyStation.Frequency = Mid(TextLine, 73, 5).Trim

                DbContext.NielsenRadioCountyStations.Add(NielsenRadioCountyStation)

            End If

        End Sub
        Private Sub ProcessRC1L4(DbContext As AdvantageFramework.Nielsen.Database.DbContext, NielsenRadioCountyPeriodID As Integer, NielsenRadioCountyStationID As Integer, TextLine As String,
                                 ByRef NielsenRadioCountyAudienceList As Generic.List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioCountyAudience))

            'objects
            Dim NielsenRadioDaypartID As Integer = 0
            Dim NielsenRadioCountyAudience As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioCountyAudience = Nothing

            If Mid(TextLine, 12, 1) = "1" Then

                NielsenRadioDaypartID = 84

            ElseIf Mid(TextLine, 12, 1) = "2" Then

                NielsenRadioDaypartID = 68

            End If

            NielsenRadioCountyAudience = NielsenRadioCountyAudienceList.Where(Function(NRCA) NRCA.NielsenRadioCountyPeriodID = NielsenRadioCountyPeriodID AndAlso
                                                                                             NRCA.NielsenRadioDaypartID = NielsenRadioDaypartID AndAlso
                                                                                             NRCA.NielsenRadioCountyStationID = NielsenRadioCountyStationID).SingleOrDefault

            If NielsenRadioCountyAudience Is Nothing Then

                NielsenRadioCountyAudience = New AdvantageFramework.Nielsen.Database.Entities.NielsenRadioCountyAudience
                NielsenRadioCountyAudience.NielsenRadioCountyPeriodID = NielsenRadioCountyPeriodID
                NielsenRadioCountyAudience.NielsenRadioCountyStationID = NielsenRadioCountyStationID
                NielsenRadioCountyAudience.NielsenRadioDaypartID = NielsenRadioDaypartID

                NielsenRadioCountyAudienceList.Add(NielsenRadioCountyAudience)

            End If

            If Mid(TextLine, 13, 1) = "1" AndAlso Mid(TextLine, 14, 1) = "1" Then

                NielsenRadioCountyAudience.Persons12PlusAQH = Mid(TextLine, 15, 6) * 100
                NielsenRadioCountyAudience.Persons12to34AQH = Mid(TextLine, 21, 6) * 100
                NielsenRadioCountyAudience.Persons18PlusAQH = Mid(TextLine, 27, 6) * 100
                NielsenRadioCountyAudience.Persons18to34AQH = Mid(TextLine, 33, 6) * 100
                NielsenRadioCountyAudience.Persons25to54AQH = Mid(TextLine, 39, 6) * 100
                NielsenRadioCountyAudience.Persons35PlusAQH = Mid(TextLine, 45, 6) * 100
                NielsenRadioCountyAudience.Persons35to64AQH = Mid(TextLine, 51, 6) * 100
                NielsenRadioCountyAudience.Males18PlusAQH = Mid(TextLine, 57, 6) * 100
                NielsenRadioCountyAudience.Females18PlusAQH = Mid(TextLine, 63, 6) * 100

            ElseIf Mid(TextLine, 13, 1) = "1" AndAlso Mid(TextLine, 14, 1) = "2" Then

                NielsenRadioCountyAudience.Persons12PlusRating = Mid(TextLine, 15, 6) * 0.1
                NielsenRadioCountyAudience.Persons12to34Rating = Mid(TextLine, 21, 6) * 0.1
                NielsenRadioCountyAudience.Persons18PlusRating = Mid(TextLine, 27, 6) * 0.1
                NielsenRadioCountyAudience.Persons18to34Rating = Mid(TextLine, 33, 6) * 0.1
                NielsenRadioCountyAudience.Persons25to54Rating = Mid(TextLine, 39, 6) * 0.1
                NielsenRadioCountyAudience.Persons35PlusRating = Mid(TextLine, 45, 6) * 0.1
                NielsenRadioCountyAudience.Persons35to64Rating = Mid(TextLine, 51, 6) * 0.1
                NielsenRadioCountyAudience.Males18PlusRating = Mid(TextLine, 57, 6) * 0.1
                NielsenRadioCountyAudience.Females18PlusRating = Mid(TextLine, 63, 6) * 0.1

            ElseIf Mid(TextLine, 13, 1) = "1" AndAlso Mid(TextLine, 14, 1) = "3" Then

                NielsenRadioCountyAudience.Persons12PlusSSOC = Mid(TextLine, 15, 6) * 0.1
                NielsenRadioCountyAudience.Persons12to34SSOC = Mid(TextLine, 21, 6) * 0.1
                NielsenRadioCountyAudience.Persons18PlusSSOC = Mid(TextLine, 27, 6) * 0.1
                NielsenRadioCountyAudience.Persons18to34SSOC = Mid(TextLine, 33, 6) * 0.1
                NielsenRadioCountyAudience.Persons25to54SSOC = Mid(TextLine, 39, 6) * 0.1
                NielsenRadioCountyAudience.Persons35PlusSSOC = Mid(TextLine, 45, 6) * 0.1
                NielsenRadioCountyAudience.Persons35to64SSOC = Mid(TextLine, 51, 6) * 0.1
                NielsenRadioCountyAudience.Males18PlusSSOC = Mid(TextLine, 57, 6) * 0.1
                NielsenRadioCountyAudience.Females18PlusSSOC = Mid(TextLine, 63, 6) * 0.1

            ElseIf Mid(TextLine, 13, 1) = "1" AndAlso Mid(TextLine, 14, 1) = "4" Then

                NielsenRadioCountyAudience.Persons12PlusCSOS = Mid(TextLine, 15, 6) * 0.1
                NielsenRadioCountyAudience.Persons12to34CSOS = Mid(TextLine, 21, 6) * 0.1
                NielsenRadioCountyAudience.Persons18PlusCSOS = Mid(TextLine, 27, 6) * 0.1
                NielsenRadioCountyAudience.Persons18to34CSOS = Mid(TextLine, 33, 6) * 0.1
                NielsenRadioCountyAudience.Persons25to54CSOS = Mid(TextLine, 39, 6) * 0.1
                NielsenRadioCountyAudience.Persons35PlusCSOS = Mid(TextLine, 45, 6) * 0.1
                NielsenRadioCountyAudience.Persons35to64CSOS = Mid(TextLine, 51, 6) * 0.1
                NielsenRadioCountyAudience.Males18PlusCSOS = Mid(TextLine, 57, 6) * 0.1
                NielsenRadioCountyAudience.Females18PlusCSOS = Mid(TextLine, 63, 6) * 0.1

            ElseIf Mid(TextLine, 13, 1) = "2" AndAlso Mid(TextLine, 14, 1) = "1" Then

                NielsenRadioCountyAudience.Persons12PlusCUME = Mid(TextLine, 15, 6) * 100
                NielsenRadioCountyAudience.Persons12to34CUME = Mid(TextLine, 21, 6) * 100
                NielsenRadioCountyAudience.Persons18PlusCUME = Mid(TextLine, 27, 6) * 100
                NielsenRadioCountyAudience.Persons18to34CUME = Mid(TextLine, 33, 6) * 100
                NielsenRadioCountyAudience.Persons25to54CUME = Mid(TextLine, 39, 6) * 100
                NielsenRadioCountyAudience.Persons35PlusCUME = Mid(TextLine, 45, 6) * 100
                NielsenRadioCountyAudience.Persons35to64CUME = Mid(TextLine, 51, 6) * 100
                NielsenRadioCountyAudience.Males18PlusCUME = Mid(TextLine, 57, 6) * 100
                NielsenRadioCountyAudience.Females18PlusCUME = Mid(TextLine, 63, 6) * 100

            ElseIf Mid(TextLine, 13, 1) = "2" AndAlso Mid(TextLine, 14, 1) = "2" Then

                NielsenRadioCountyAudience.Persons12PlusCUMERating = Mid(TextLine, 15, 6) * 0.1
                NielsenRadioCountyAudience.Persons12to34CUMERating = Mid(TextLine, 21, 6) * 0.1
                NielsenRadioCountyAudience.Persons18PlusCUMERating = Mid(TextLine, 27, 6) * 0.1
                NielsenRadioCountyAudience.Persons18to34CUMERating = Mid(TextLine, 33, 6) * 0.1
                NielsenRadioCountyAudience.Persons25to54CUMERating = Mid(TextLine, 39, 6) * 0.1
                NielsenRadioCountyAudience.Persons35PlusCUMERating = Mid(TextLine, 45, 6) * 0.1
                NielsenRadioCountyAudience.Persons35to64CUMERating = Mid(TextLine, 51, 6) * 0.1
                NielsenRadioCountyAudience.Males18PlusCUMERating = Mid(TextLine, 57, 6) * 0.1
                NielsenRadioCountyAudience.Females18PlusCUMERating = Mid(TextLine, 63, 6) * 0.1

            End If

        End Sub
        Private Function ProcessRadioCountyFile(ConnectionString As String, Filename As String) As Boolean

            'objects
            Dim Processed As Boolean = False
            Dim StreamReader As System.IO.StreamReader = Nothing
            Dim IsFirstRow As Boolean = True
            Dim Copyright As String = String.Empty
            Dim Year As Short = 0
            Dim TextLine As String = Nothing
            Dim NielsenRadioCountyPeriodList As Generic.List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioCountyPeriod) = Nothing
            Dim NielsenRadioCountyStationList As Generic.List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioCountyStation) = Nothing
            Dim NielsenRadioCountyPeriod As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioCountyPeriod = Nothing
            Dim NielsenRadioCountyStation As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioCountyStation = Nothing
            Dim NielsenRadioCountyAudienceList As Generic.List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioCountyAudience) = Nothing
            Dim SkipRC1L4 As Boolean = False

            If System.IO.File.Exists(Filename) Then

                Using DbContext As New AdvantageFramework.Nielsen.Database.DbContext(ConnectionString, Nothing)

                    DbContext.Database.Connection.Open()

                    Using tran = DbContext.Database.BeginTransaction()

                        Try

                            DbContext.Configuration.AutoDetectChangesEnabled = False

                            StreamReader = New System.IO.StreamReader(Filename)

                            NielsenRadioCountyAudienceList = New Generic.List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioCountyAudience)

                            Do While StreamReader.Peek() <> -1

                                TextLine = StreamReader.ReadLine()

                                If IsFirstRow Then

                                    Copyright = TextLine
                                    Year = Mid(TextLine, 11, 4)
                                    IsFirstRow = False

                                    NielsenRadioCountyPeriodList = (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioCountyPeriod.Load(DbContext)
                                                                    Where Entity.Year = Year
                                                                    Select Entity).ToList

                                    NielsenRadioCountyStationList = AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioCountyStation.Load(DbContext).ToList

                                ElseIf Len(TextLine) = 113 Then 'skip RC1L5 files

                                    'do nothing Processed will be set to True and table updated skipping file
                                    Exit Do

                                ElseIf Len(TextLine) = 234 Then

                                    ProcessRC1L1(DbContext, Copyright, Year, TextLine)

                                ElseIf Len(TextLine) = 43 Then

                                    ProcessRC1L2(DbContext, Year, TextLine)

                                ElseIf Len(TextLine) = 68 Then

                                    If Not SkipRC1L4 AndAlso Mid(TextLine, 7, 4) <> "UUUU" AndAlso Mid(TextLine, 7, 4) <> "ZZZZ" Then

                                        NielsenRadioCountyPeriod = (From Entity In NielsenRadioCountyPeriodList
                                                                    Where Entity.CountyCode = Mid(TextLine, 1, 6) AndAlso
                                                                          Entity.Year = Year
                                                                    Select Entity).SingleOrDefault

                                        If NielsenRadioCountyPeriod IsNot Nothing Then

                                            NielsenRadioCountyStation = (From Entity In NielsenRadioCountyStationList
                                                                         Where Entity.Year = Year AndAlso
                                                                               Entity.CallLetters = Mid(TextLine, 7, 4).Trim AndAlso
                                                                               Entity.Band.StartsWith(Mid(TextLine, 11, 1))
                                                                         Select Entity).SingleOrDefault

                                            If NielsenRadioCountyStation IsNot Nothing Then

                                                If NielsenRadioCountyAudienceList.Count = 0 AndAlso Not SkipRC1L4 AndAlso (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioCountyAudience.Load(DbContext)
                                                                                                                           Where Entity.NielsenRadioCountyPeriodID = NielsenRadioCountyPeriod.ID).Any Then

                                                    SkipRC1L4 = True

                                                Else

                                                    ProcessRC1L4(DbContext, NielsenRadioCountyPeriod.ID, NielsenRadioCountyStation.ID, TextLine, NielsenRadioCountyAudienceList)

                                                End If

                                            Else

                                                Throw New Exception("Could not find county station for call letters/band:" & Mid(TextLine, 7, 4).Trim & "/" & Mid(TextLine, 11, 1))

                                            End If

                                        Else

                                            Throw New Exception("Could not find county period for county code:" & Mid(TextLine, 1, 6))

                                        End If

                                    End If

                                Else

                                    ProcessRC1L3(DbContext, Year, TextLine)

                                End If

                            Loop

                            If NielsenRadioCountyAudienceList.Count > 0 Then

                                BulkInsertNielsenRadioCountyAudienceList(DbContext, tran, NielsenRadioCountyAudienceList)

                            End If

                            DbContext.SaveChanges()

                            tran.Commit()

                            Processed = True

                        Catch ex As Exception

                            tran.Rollback()

                            Throw New Exception(ex.Message & " Filename:" & Filename)

                        Finally

                            StreamReader.Close()

                            DbContext.Configuration.AutoDetectChangesEnabled = True

                        End Try

                    End Using

                End Using

            End If

            ProcessRadioCountyFile = Processed

        End Function
        Private Sub BulkInsertNielsenRadioCountyAudienceList(DbContext As AdvantageFramework.Nielsen.Database.DbContext, DbContextTransaction As Entity.DbContextTransaction,
                                                             NielsenRadioCountyAudiences As List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioCountyAudience))

            'objects
            Dim DataTable As System.Data.DataTable = Nothing

            DataTable = NielsenRadioCountyAudiences.ToDataTable

            Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(DirectCast(DbContext.Database.Connection, SqlClient.SqlConnection), SqlClient.SqlBulkCopyOptions.CheckConstraints, DirectCast(DbContextTransaction.UnderlyingTransaction, SqlClient.SqlTransaction))

                With SqlBulkCopy

                    .ColumnMappings.Add("ID", "NIELSEN_RADIO_COUNTY_AUDIENCE_ID")
                    .ColumnMappings.Add("NielsenRadioCountyPeriodID", "NIELSEN_RADIO_COUNTY_PERIOD_ID")
                    .ColumnMappings.Add("NielsenRadioDaypartID", "NIELSEN_RADIO_DAYPART_ID")
                    .ColumnMappings.Add("NielsenRadioCountyStationID", "NIELSEN_RADIO_COUNTY_STATION_ID")
                    .ColumnMappings.Add("Persons12PlusAQH", "PERSONS_12PLUS_AQH")
                    .ColumnMappings.Add("Persons12to34AQH", "PERSONS_12TO34_AQH")
                    .ColumnMappings.Add("Persons18PlusAQH", "PERSONS_18PLUS_AQH")
                    .ColumnMappings.Add("Persons18to34AQH", "PERSONS_18TO34_AQH")
                    .ColumnMappings.Add("Persons25to54AQH", "PERSONS_25TO54_AQH")
                    .ColumnMappings.Add("Persons35PlusAQH", "PERSONS_35PLUS_AQH")
                    .ColumnMappings.Add("Persons35to64AQH", "PERSONS_35TO64_AQH")
                    .ColumnMappings.Add("Males18PlusAQH", "MALES_18PLUS_AQH")
                    .ColumnMappings.Add("Females18PlusAQH", "FEMALES_18PLUS_AQH")
                    .ColumnMappings.Add("Persons12PlusRating", "PERSONS_12PLUS_RATING")
                    .ColumnMappings.Add("Persons12to34Rating", "PERSONS_12TO34_RATING")
                    .ColumnMappings.Add("Persons18PlusRating", "PERSONS_18PLUS_RATING")
                    .ColumnMappings.Add("Persons18to34Rating", "PERSONS_18TO34_RATING")
                    .ColumnMappings.Add("Persons25to54Rating", "PERSONS_25TO54_RATING")
                    .ColumnMappings.Add("Persons35PlusRating", "PERSONS_35PLUS_RATING")
                    .ColumnMappings.Add("Persons35to64Rating", "PERSONS_35TO64_RATING")
                    .ColumnMappings.Add("Males18PlusRating", "MALES_18PLUS_RATING")
                    .ColumnMappings.Add("Females18PlusRating", "FEMALES_18PLUS_RATING")
                    .ColumnMappings.Add("Persons12PlusSSOC", "PERSONS_12PLUS_SSOC")
                    .ColumnMappings.Add("Persons12to34SSOC", "PERSONS_12TO34_SSOC")
                    .ColumnMappings.Add("Persons18PlusSSOC", "PERSONS_18PLUS_SSOC")
                    .ColumnMappings.Add("Persons18to34SSOC", "PERSONS_18TO34_SSOC")
                    .ColumnMappings.Add("Persons25to54SSOC", "PERSONS_25TO54_SSOC")
                    .ColumnMappings.Add("Persons35PlusSSOC", "PERSONS_35PLUS_SSOC")
                    .ColumnMappings.Add("Persons35to64SSOC", "PERSONS_35TO64_SSOC")
                    .ColumnMappings.Add("Males18PlusSSOC", "MALES_18PLUS_SSOC")
                    .ColumnMappings.Add("Females18PlusSSOC", "FEMALES_18PLUS_SSOC")
                    .ColumnMappings.Add("Persons12PlusCSOS", "PERSONS_12PLUS_CSOS")
                    .ColumnMappings.Add("Persons12to34CSOS", "PERSONS_12TO34_CSOS")
                    .ColumnMappings.Add("Persons18PlusCSOS", "PERSONS_18PLUS_CSOS")
                    .ColumnMappings.Add("Persons18to34CSOS", "PERSONS_18TO34_CSOS")
                    .ColumnMappings.Add("Persons25to54CSOS", "PERSONS_25TO54_CSOS")
                    .ColumnMappings.Add("Persons35PlusCSOS", "PERSONS_35PLUS_CSOS")
                    .ColumnMappings.Add("Persons35to64CSOS", "PERSONS_35TO64_CSOS")
                    .ColumnMappings.Add("Males18PlusCSOS", "MALES_18PLUS_CSOS")
                    .ColumnMappings.Add("Females18PlusCSOS", "FEMALES_18PLUS_CSOS")
                    .ColumnMappings.Add("Persons12PlusCUME", "PERSONS_12PLUS_CUME")
                    .ColumnMappings.Add("Persons12to34CUME", "PERSONS_12TO34_CUME")
                    .ColumnMappings.Add("Persons18PlusCUME", "PERSONS_18PLUS_CUME")
                    .ColumnMappings.Add("Persons18to34CUME", "PERSONS_18TO34_CUME")
                    .ColumnMappings.Add("Persons25to54CUME", "PERSONS_25TO54_CUME")
                    .ColumnMappings.Add("Persons35PlusCUME", "PERSONS_35PLUS_CUME")
                    .ColumnMappings.Add("Persons35to64CUME", "PERSONS_35TO64_CUME")
                    .ColumnMappings.Add("Males18PlusCUME", "MALES_18PLUS_CUME")
                    .ColumnMappings.Add("Females18PlusCUME", "FEMALES_18PLUS_CUME")
                    .ColumnMappings.Add("Persons12PlusCUMERating", "PERSONS_12PLUS_CUME_RATING")
                    .ColumnMappings.Add("Persons12to34CUMERating", "PERSONS_12TO34_CUME_RATING")
                    .ColumnMappings.Add("Persons18PlusCUMERating", "PERSONS_18PLUS_CUME_RATING")
                    .ColumnMappings.Add("Persons18to34CUMERating", "PERSONS_18TO34_CUME_RATING")
                    .ColumnMappings.Add("Persons25to54CUMERating", "PERSONS_25TO54_CUME_RATING")
                    .ColumnMappings.Add("Persons35PlusCUMERating", "PERSONS_35PLUS_CUME_RATING")
                    .ColumnMappings.Add("Persons35to64CUMERating", "PERSONS_35TO64_CUME_RATING")
                    .ColumnMappings.Add("Males18PlusCUMERating", "MALES_18PLUS_CUME_RATING")
                    .ColumnMappings.Add("Females18PlusCUMERating", "FEMALES_18PLUS_CUME_RATING")

                    .BulkCopyTimeout = 0
                    .BatchSize = DataTable.Rows.Count
                    .DestinationTableName = "NIELSEN_RADIO_COUNTY_AUDIENCE"
                    .WriteToServer(DataTable)

                End With

            End Using

        End Sub

#End Region

#Region " NCC Data "

        Private Function GetFirstMonday(Year As Integer, Month As Integer) As Date

            'objects
            Dim Monday As Date = Nothing

            Monday = New Date(Year, Month, 1)

            Do While Monday.DayOfWeek <> DayOfWeek.Monday

                Monday = Monday.AddDays(1)

            Loop

            If Monday.Day <> 1 Then

                Monday = Monday.AddDays(-7)

            End If

            GetFirstMonday = Monday

        End Function
        Private Sub BulkInsertNCCTVAIUEList(DbContext As AdvantageFramework.Nielsen.Database.DbContext, DbContextTransaction As Entity.DbContextTransaction,
                                            NCCTVAIUEs As List(Of AdvantageFramework.Nielsen.Database.Entities.NCCTVAIUE))

            'objects
            Dim DataTable As System.Data.DataTable = Nothing

            DataTable = NCCTVAIUEs.ToDataTable

            Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(DirectCast(DbContext.Database.Connection, SqlClient.SqlConnection), SqlClient.SqlBulkCopyOptions.CheckConstraints, DirectCast(DbContextTransaction.UnderlyingTransaction, SqlClient.SqlTransaction))

                With SqlBulkCopy

                    .ColumnMappings.Add("ID", "NCC_TV_AI_UE_ID")
                    .ColumnMappings.Add("Syscode", "SYSCODE")
                    .ColumnMappings.Add("NCCTVAIUELogID", "NCC_TV_AI_UE_LOG_ID")
                    .ColumnMappings.Add("StationCode", "STATION_CODE")
                    .ColumnMappings.Add("SampleType", "SAMPLE_TYPE")
                    .ColumnMappings.Add("HHAIUE", "HH_AIUE")

                    .BulkCopyTimeout = 0
                    .BatchSize = DataTable.Rows.Count
                    .DestinationTableName = "NCC_TV_AI_UE"
                    .WriteToServer(DataTable)

                End With

            End Using

        End Sub
        Private Sub BulkInsertNCCTVCarriageUEList(DbContext As AdvantageFramework.Nielsen.Database.DbContext, DbContextTransaction As Entity.DbContextTransaction,
                                                  NCCTVCarriageUEs As List(Of AdvantageFramework.Nielsen.Database.Entities.NCCTVCarriageUE))

            'objects
            Dim DataTable As System.Data.DataTable = Nothing

            DataTable = NCCTVCarriageUEs.ToDataTable

            Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(DirectCast(DbContext.Database.Connection, SqlClient.SqlConnection), SqlClient.SqlBulkCopyOptions.CheckConstraints, DirectCast(DbContextTransaction.UnderlyingTransaction, SqlClient.SqlTransaction))

                With SqlBulkCopy

                    .ColumnMappings.Add("ID", "NCC_TV_CARRIAGE_UE_ID")
                    .ColumnMappings.Add("NielsenMarketNumber", "NIELSEN_MARKET_NUM")
                    .ColumnMappings.Add("NCCTVCarriageUELogID", "NCC_TV_CARRIAGE_UE_LOG_ID")
                    .ColumnMappings.Add("StationCode", "STATION_CODE")
                    .ColumnMappings.Add("HHCarriageUE", "HH_CARRIAGE_UE")

                    .BulkCopyTimeout = 0
                    .BatchSize = DataTable.Rows.Count
                    .DestinationTableName = "NCC_TV_CARRIAGE_UE"
                    .WriteToServer(DataTable)

                End With

            End Using

        End Sub
        'Private Sub BulkInsertNCCTVFusionHutputList(DbContext As AdvantageFramework.Nielsen.Database.DbContext, DbContextTransaction As Entity.DbContextTransaction,
        '                                            NCCTVFusionHutputs As List(Of AdvantageFramework.Nielsen.Database.Entities.NCCTVFusionHutput))

        '    'objects
        '    Dim DataTable As System.Data.DataTable = Nothing

        '    DataTable = NCCTVFusionHutputs.ToDataTable

        '    Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(DirectCast(DbContext.Database.Connection, SqlClient.SqlConnection), SqlClient.SqlBulkCopyOptions.CheckConstraints, DirectCast(DbContextTransaction.UnderlyingTransaction, SqlClient.SqlTransaction))

        '        With SqlBulkCopy

        '            .ColumnMappings.Add("ID", "NCC_TV_FUSION_HUTPUT_ID")
        '            .ColumnMappings.Add("NCCTVFusionUniverseID", "NCC_TV_FUSION_UE_ID")
        '            .ColumnMappings.Add("HutputDatetime", "HUTPUT_DATETIME")
        '            .ColumnMappings.Add("Household", "HOUSEHOLD_HUT")
        '            .ColumnMappings.Add("Children2to5", "CHILDREN_2TO5_PUT")
        '            .ColumnMappings.Add("Children6to11", "CHILDREN_6TO11_PUT")
        '            .ColumnMappings.Add("Males12to17", "MALES_12TO17_PUT")
        '            .ColumnMappings.Add("Males18to20", "MALES_18TO20_PUT")
        '            .ColumnMappings.Add("Males21to24", "MALES_21TO24_PUT")
        '            .ColumnMappings.Add("Males25to34", "MALES_25TO34_PUT")
        '            .ColumnMappings.Add("Males35to49", "MALES_35TO49_PUT")
        '            .ColumnMappings.Add("Males50to54", "MALES_50TO54_PUT")
        '            .ColumnMappings.Add("Males55to64", "MALES_55TO64_PUT")
        '            .ColumnMappings.Add("Males65Plus", "MALES_65PLUS_PUT")
        '            .ColumnMappings.Add("Females12to17", "FEMALES_12TO17_PUT")
        '            .ColumnMappings.Add("Females18to20", "FEMALES_18TO20_PUT")
        '            .ColumnMappings.Add("Females21to24", "FEMALES_21TO24_PUT")
        '            .ColumnMappings.Add("Females25to34", "FEMALES_25TO34_PUT")
        '            .ColumnMappings.Add("Females35to49", "FEMALES_35TO49_PUT")
        '            .ColumnMappings.Add("Females50to54", "FEMALES_50TO54_PUT")
        '            .ColumnMappings.Add("Females55to64", "FEMALES_55TO64_PUT")
        '            .ColumnMappings.Add("Females65Plus", "FEMALES_65PLUS_PUT")

        '            .BulkCopyTimeout = 0
        '            .BatchSize = DataTable.Rows.Count
        '            .DestinationTableName = "NCC_TV_FUSION_HUTPUT"
        '            .WriteToServer(DataTable)

        '        End With

        '    End Using

        'End Sub
        'Private Sub BulkInsertNCCTVFusionAudienceList(DbContext As AdvantageFramework.Nielsen.Database.DbContext, DbContextTransaction As Entity.DbContextTransaction,
        '                                              NCCTVFusionAudiences As List(Of AdvantageFramework.Nielsen.Database.Entities.NCCTVFusionAudience))

        '    'objects
        '    Dim DataTable As System.Data.DataTable = Nothing

        '    DataTable = NCCTVFusionAudiences.ToDataTable

        '    Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(DirectCast(DbContext.Database.Connection, SqlClient.SqlConnection), SqlClient.SqlBulkCopyOptions.CheckConstraints, DirectCast(DbContextTransaction.UnderlyingTransaction, SqlClient.SqlTransaction))

        '        With SqlBulkCopy

        '            .ColumnMappings.Add("ID", "NCC_TV_FUSION_AUDIENCE_ID")
        '            .ColumnMappings.Add("NCCTVFusionUniverseID", "NCC_TV_FUSION_UE_ID")
        '            .ColumnMappings.Add("StationCode", "STATION_CODE")
        '            .ColumnMappings.Add("AudienceDatetime", "AUDIENCE_DATETIME")
        '            .ColumnMappings.Add("Household", "HOUSEHOLD_AUD")
        '            .ColumnMappings.Add("Children2to5", "CHILDREN_2TO5_AUD")
        '            .ColumnMappings.Add("Children6to11", "CHILDREN_6TO11_AUD")
        '            .ColumnMappings.Add("Males12to17", "MALES_12TO17_AUD")
        '            .ColumnMappings.Add("Males18to20", "MALES_18TO20_AUD")
        '            .ColumnMappings.Add("Males21to24", "MALES_21TO24_AUD")
        '            .ColumnMappings.Add("Males25to34", "MALES_25TO34_AUD")
        '            .ColumnMappings.Add("Males35to49", "MALES_35TO49_AUD")
        '            .ColumnMappings.Add("Males50to54", "MALES_50TO54_AUD")
        '            .ColumnMappings.Add("Males55to64", "MALES_55TO64_AUD")
        '            .ColumnMappings.Add("Males65Plus", "MALES_65PLUS_AUD")
        '            .ColumnMappings.Add("Females12to17", "FEMALES_12TO17_AUD")
        '            .ColumnMappings.Add("Females18to20", "FEMALES_18TO20_AUD")
        '            .ColumnMappings.Add("Females21to24", "FEMALES_21TO24_AUD")
        '            .ColumnMappings.Add("Females25to34", "FEMALES_25TO34_AUD")
        '            .ColumnMappings.Add("Females35to49", "FEMALES_35TO49_AUD")
        '            .ColumnMappings.Add("Females50to54", "FEMALES_50TO54_AUD")
        '            .ColumnMappings.Add("Females55to64", "FEMALES_55TO64_AUD")
        '            .ColumnMappings.Add("Females65Plus", "FEMALES_65PLUS_AUD")

        '            .BulkCopyTimeout = 0
        '            .BatchSize = DataTable.Rows.Count
        '            .DestinationTableName = "NCC_TV_FUSION_AUDIENCE"
        '            .WriteToServer(DataTable)

        '        End With

        '    End Using

        'End Sub
        Private Function ImportNCCSyscode(ConnectionString As String, Filename As String) As Boolean

            'objects            
            Dim TextFieldParser As FileIO.TextFieldParser = Nothing
            Dim FileLineData() As String = Nothing
            Dim MVPD As String = Nothing
            Dim NCCTVMVPD As AdvantageFramework.Nielsen.Database.Entities.NCCTVMVPD = Nothing
            Dim Syscode As Short = Nothing
            Dim NCCTVSyscode As AdvantageFramework.Nielsen.Database.Entities.NCCTVSyscode = Nothing
            Dim Imported As Boolean = False

            If System.IO.File.Exists(Filename) Then

                TextFieldParser = New FileIO.TextFieldParser(Filename)

                TextFieldParser.TextFieldType = FileIO.FieldType.Delimited
                TextFieldParser.Delimiters = {","}
                TextFieldParser.HasFieldsEnclosedInQuotes = True

                Using NielsenDbContext As New AdvantageFramework.Nielsen.Database.DbContext(ConnectionString, Nothing)

                    Using tran = NielsenDbContext.Database.BeginTransaction()

                        Try

                            Do While Not TextFieldParser.EndOfData

                                FileLineData = TextFieldParser.ReadFields

                                MVPD = FileLineData(4)

                                NCCTVMVPD = AdvantageFramework.Nielsen.Database.Procedures.NCCTVMVPD.Load(NielsenDbContext).Where(Function(Entity) Entity.MVPD = MVPD).SingleOrDefault

                                If NCCTVMVPD Is Nothing Then

                                    NCCTVMVPD = New AdvantageFramework.Nielsen.Database.Entities.NCCTVMVPD
                                    NCCTVMVPD.MVPD = MVPD

                                    NielsenDbContext.NCCTVMVPDs.Add(NCCTVMVPD)
                                    NielsenDbContext.SaveChanges()

                                End If

                                If IsNumeric(FileLineData(1)) Then

                                    Syscode = FileLineData(1)

                                    NCCTVSyscode = AdvantageFramework.Nielsen.Database.Procedures.NCCTVSyscode.Load(NielsenDbContext).Where(Function(Entity) Entity.Syscode = Syscode).SingleOrDefault

                                    If NCCTVSyscode Is Nothing AndAlso IsNumeric(FileLineData(26)) Then

                                        NCCTVSyscode = New AdvantageFramework.Nielsen.Database.Entities.NCCTVSyscode
                                        NCCTVSyscode.Syscode = Syscode
                                        NCCTVSyscode.NCCTVMVPDID = NCCTVMVPD.ID
                                        NCCTVSyscode.NielsenMarketNumber = CInt(FileLineData(26)) - 400
                                        NCCTVSyscode.SystemName = FileLineData(2)
                                        NCCTVSyscode.SystemType = FileLineData(5)

                                        NielsenDbContext.NCCTVSyscodes.Add(NCCTVSyscode)

                                    ElseIf NCCTVSyscode IsNot Nothing AndAlso IsNumeric(FileLineData(26)) Then

                                        NCCTVSyscode.NCCTVMVPDID = NCCTVMVPD.ID
                                        NCCTVSyscode.NielsenMarketNumber = CInt(FileLineData(26)) - 400
                                        NCCTVSyscode.SystemName = FileLineData(2)
                                        NCCTVSyscode.SystemType = FileLineData(5)

                                        NielsenDbContext.Entry(NCCTVSyscode).State = Entity.EntityState.Modified

                                    End If

                                    NielsenDbContext.SaveChanges()

                                End If

                            Loop

                            tran.Commit()

                            Imported = True

                        Catch ex As Exception

                            tran.Rollback()

                            LogEvent(ConnectionString, "Error importing file:" & Filename & " " & ex.Message)

                        Finally

                            TextFieldParser.Close()

                        End Try

                    End Using

                End Using

            End If

            ImportNCCSyscode = Imported

        End Function
        Private Function ImportNCCTVCablenet(ConnectionString As String, Filename As String) As Boolean

            'objects
            Dim License As Aspose.Cells.License = Nothing
            Dim Workbook As Aspose.Cells.Workbook = Nothing
            Dim DataTable As System.Data.DataTable = Nothing
            Dim NetworkCode As String = Nothing
            Dim NCCTVCablenet As AdvantageFramework.Nielsen.Database.Entities.NCCTVCablenet = Nothing
            Dim Imported As Boolean = False

            If System.IO.File.Exists(Filename) Then

                Try

                    License = New Aspose.Cells.License

                    License.SetLicense("Aspose.Total.lic")

                    Workbook = New Aspose.Cells.Workbook(Filename)

                    DataTable = Workbook.Worksheets(0).Cells.ExportDataTable(0, 0, Workbook.Worksheets(0).Cells.MaxDataRow + 1, Workbook.Worksheets(0).Cells.MaxDataColumn + 1)

                Catch ex As Exception
                    LogEvent(ConnectionString, ex.Message & " in ImportNCCTVCablenet")
                End Try

                If DataTable IsNot Nothing Then

                    Using NielsenDbContext As New AdvantageFramework.Nielsen.Database.DbContext(ConnectionString, Nothing)

                        Using tran = NielsenDbContext.Database.BeginTransaction

                            Try

                                For RowNumber As Integer = 1 To DataTable.Rows.Count - 1

                                    If Not DataTable.Rows(RowNumber).Item(0).Equals(System.DBNull.Value) Then

                                        NetworkCode = CStr(DataTable.Rows(RowNumber).Item(0))

                                        NCCTVCablenet = AdvantageFramework.Nielsen.Database.Procedures.NCCTVCablenet.Load(NielsenDbContext).Where(Function(Entity) Entity.NetworkCode = NetworkCode).SingleOrDefault

                                        If NCCTVCablenet Is Nothing Then

                                            NCCTVCablenet = New AdvantageFramework.Nielsen.Database.Entities.NCCTVCablenet
                                            NCCTVCablenet.NetworkCode = NetworkCode
                                            NCCTVCablenet.NetworkName = DataTable.Rows(RowNumber).Item(1)

                                            If Not DataTable.Rows(RowNumber).Item(2).Equals(System.DBNull.Value) Then

                                                NCCTVCablenet.StationCode = CInt(DataTable.Rows(RowNumber).Item(2))

                                            Else

                                                NCCTVCablenet.StationCode = Nothing

                                            End If

                                            NielsenDbContext.NCCTVCablenets.Add(NCCTVCablenet)

                                        Else

                                            NCCTVCablenet.NetworkName = DataTable.Rows(RowNumber).Item(1)

                                            If Not DataTable.Rows(RowNumber).Item(2).Equals(System.DBNull.Value) Then

                                                NCCTVCablenet.StationCode = CInt(DataTable.Rows(RowNumber).Item(2))

                                            Else

                                                NCCTVCablenet.StationCode = Nothing

                                            End If

                                            NielsenDbContext.Entry(NCCTVCablenet).State = Entity.EntityState.Modified

                                        End If

                                        NielsenDbContext.SaveChanges()

                                    End If

                                Next

                                tran.Commit()

                                Imported = True

                            Catch ex As Exception

                                tran.Rollback()

                                LogEvent(ConnectionString, "Error importing file:" & Filename & " " & ex.Message)

                            End Try

                        End Using

                    End Using

                End If

                Workbook.Dispose()

            End If

            ImportNCCTVCablenet = Imported

        End Function
        Private Function ImportNCCTVAIUE(ConnectionString As String, Filename As String) As Boolean

            'objects
            Dim TextFieldParser As FileIO.TextFieldParser = Nothing
            Dim FileLineData() As String = Nothing
            Dim LogCheck As Boolean = False
            Dim Year As Short = 0
            Dim Month As Short = 0
            Dim NCCTVAIUELog As AdvantageFramework.Nielsen.Database.Entities.NCCTVAIUELog = Nothing
            Dim NCCTVAIUELogRevision As AdvantageFramework.Nielsen.Database.Entities.NCCTVAIUELogRevision = Nothing
            Dim NCCTVAIUEs As Generic.List(Of AdvantageFramework.Nielsen.Database.Entities.NCCTVAIUE) = Nothing
            Dim NCCTVAIUE As AdvantageFramework.Nielsen.Database.Entities.NCCTVAIUE = Nothing
            Dim Imported As Boolean = False

            If System.IO.File.Exists(Filename) Then

                TextFieldParser = New FileIO.TextFieldParser(Filename)

                TextFieldParser.TextFieldType = FileIO.FieldType.Delimited
                TextFieldParser.Delimiters = {","}
                TextFieldParser.HasFieldsEnclosedInQuotes = True

                Using DbContext As New AdvantageFramework.Nielsen.Database.DbContext(ConnectionString, Nothing)

                    Using tran = DbContext.Database.BeginTransaction()

                        Try

                            NCCTVAIUEs = New List(Of AdvantageFramework.Nielsen.Database.Entities.NCCTVAIUE)

                            Do While Not TextFieldParser.EndOfData

                                FileLineData = TextFieldParser.ReadFields

                                If FileLineData.Length = 12 And LogCheck = False Then

                                    LogCheck = True

                                    Year = CShort(FileLineData(8))
                                    Month = CShort(FileLineData(9))

                                    NCCTVAIUELog = (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NCCTVAIUELog.Load(DbContext)
                                                    Where Entity.Year = Year AndAlso
                                                          Entity.Month = Month
                                                    Select Entity).SingleOrDefault

                                    If NCCTVAIUELog Is Nothing Then

                                        NCCTVAIUELog = New AdvantageFramework.Nielsen.Database.Entities.NCCTVAIUELog
                                        NCCTVAIUELog.Year = Year
                                        NCCTVAIUELog.Month = Month

                                        DbContext.NCCTVAIUELogs.Add(NCCTVAIUELog)
                                        DbContext.SaveChanges()

                                    Else 'its a revision

                                        Throw New Exception("NCC TV AIUE exists")

                                        'NCCTVAIUELogRevision = New AdvantageFramework.Nielsen.Database.Entities.NCCTVAIUELogRevision
                                        'NCCTVAIUELogRevision.DbContext = DbContext
                                        'NCCTVAIUELogRevision.OldNCCTVAIUELogID = NCCTVAIUELog.ID

                                        'DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.NCC_TV_AI_UE WHERE NCC_TV_AI_UE_LOG_ID = {0}", NCCTVAIUELog.ID))
                                        'DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.NCC_TV_AI_UE_LOG WHERE NCC_TV_AI_UE_LOG_ID = {0}", NCCTVAIUELog.ID))

                                        'NCCTVAIUELog = New AdvantageFramework.Nielsen.Database.Entities.NCCTVAIUELog
                                        'NCCTVAIUELog.DbContext = DbContext
                                        'NCCTVAIUELog.Year = Year
                                        'NCCTVAIUELog.Month = Month

                                        'DbContext.NCCTVAIUELogs.Add(NCCTVAIUELog)
                                        'DbContext.SaveChanges()

                                        'NCCTVAIUELogRevision.NewNCCTVAIUELogID = NCCTVAIUELog.ID
                                        'DbContext.NCCTVAIUELogRevisions.Add(NCCTVAIUELogRevision)
                                        'DbContext.SaveChanges()

                                    End If

                                End If

                                If FileLineData.Length = 12 Then

                                    If CInt(FileLineData(5)) <> 0 OrElse FileLineData(6) = "SYS" Then

                                        NCCTVAIUE = New AdvantageFramework.Nielsen.Database.Entities.NCCTVAIUE
                                        NCCTVAIUE.Syscode = CShort(FileLineData(1))
                                        NCCTVAIUE.NCCTVAIUELogID = NCCTVAIUELog.ID
                                        NCCTVAIUE.StationCode = CInt(FileLineData(5))
                                        NCCTVAIUE.SampleType = FileLineData(11)
                                        NCCTVAIUE.HHAIUE = FileLineData(7)

                                        NCCTVAIUEs.Add(NCCTVAIUE)

                                    End If

                                End If

                            Loop

                            BulkInsertNCCTVAIUEList(DbContext, tran, NCCTVAIUEs)

                            tran.Commit()

                            Imported = True

                        Catch ex As Exception

                            tran.Rollback()

                            LogEvent(ConnectionString, "Error importing file:" & Filename & " " & ex.Message)

                        Finally

                            TextFieldParser.Close()
                            TextFieldParser.Dispose()

                        End Try

                    End Using

                End Using

            End If

            ImportNCCTVAIUE = Imported

        End Function
        Private Function ImportNCCTVCarriage(ConnectionString As String, Filename As String) As Boolean

            'objects
            Dim TextFieldParser As FileIO.TextFieldParser = Nothing
            Dim FileLineData() As String = Nothing
            Dim LogCheck As Boolean = False
            Dim Year As Short = 0
            Dim Month As Short = 0
            Dim NCCTVCarriageUELog As AdvantageFramework.Nielsen.Database.Entities.NCCTVCarriageUELog = Nothing
            Dim NCCTVCarriageUELogRevision As AdvantageFramework.Nielsen.Database.Entities.NCCTVCarriageUELogRevision = Nothing
            Dim NCCTVCarriageUEs As Generic.List(Of AdvantageFramework.Nielsen.Database.Entities.NCCTVCarriageUE) = Nothing
            Dim NCCTVCarriageUE As AdvantageFramework.Nielsen.Database.Entities.NCCTVCarriageUE = Nothing
            Dim Imported As Boolean = False

            If System.IO.File.Exists(Filename) Then

                TextFieldParser = New FileIO.TextFieldParser(Filename)

                TextFieldParser.TextFieldType = FileIO.FieldType.Delimited
                TextFieldParser.Delimiters = {","}
                TextFieldParser.HasFieldsEnclosedInQuotes = True

                Using DbContext As New AdvantageFramework.Nielsen.Database.DbContext(ConnectionString, Nothing)

                    Using tran = DbContext.Database.BeginTransaction()

                        Try

                            NCCTVCarriageUEs = New List(Of AdvantageFramework.Nielsen.Database.Entities.NCCTVCarriageUE)

                            Do While Not TextFieldParser.EndOfData

                                FileLineData = TextFieldParser.ReadFields

                                If FileLineData.Length = 8 And LogCheck = False Then

                                    LogCheck = True

                                    Year = CShort(FileLineData(6))
                                    Month = CShort(FileLineData(7))

                                    NCCTVCarriageUELog = (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NCCTVCarriageUELog.Load(DbContext)
                                                          Where Entity.Year = Year AndAlso
                                                                Entity.Month = Month
                                                          Select Entity).SingleOrDefault

                                    If NCCTVCarriageUELog Is Nothing Then

                                        NCCTVCarriageUELog = New AdvantageFramework.Nielsen.Database.Entities.NCCTVCarriageUELog
                                        NCCTVCarriageUELog.Year = Year
                                        NCCTVCarriageUELog.Month = Month

                                        DbContext.NCCTVCarriageUELogs.Add(NCCTVCarriageUELog)
                                        DbContext.SaveChanges()

                                    Else 'its a revision

                                        Throw New Exception("NCC TV Carriage UE exists")

                                        'NCCTVCarriageUELogRevision = New AdvantageFramework.Nielsen.Database.Entities.NCCTVCarriageUELogRevision
                                        'NCCTVCarriageUELogRevision.DbContext = DbContext
                                        'NCCTVCarriageUELogRevision.OldNCCTVCarriageUELogID = NCCTVCarriageUELog.ID

                                        'DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.NCC_TV_CARRIAGE_UE WHERE NCC_TV_CARRIAGE_UE_LOG_ID = {0}", NCCTVCarriageUELog.ID))
                                        'DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.NCC_TV_CARRIAGE_UE_LOG WHERE NCC_TV_CARRIAGE_UE_LOG_ID = {0}", NCCTVCarriageUELog.ID))

                                        'NCCTVCarriageUELog = New AdvantageFramework.Nielsen.Database.Entities.NCCTVCarriageUELog
                                        'NCCTVCarriageUELog.DbContext = DbContext
                                        'NCCTVCarriageUELog.Year = Year
                                        'NCCTVCarriageUELog.Month = Month

                                        'DbContext.NCCTVCarriageUELogs.Add(NCCTVCarriageUELog)
                                        'DbContext.SaveChanges()

                                        'NCCTVCarriageUELogRevision.NewNCCTVCarriageUELogID = NCCTVCarriageUELog.ID
                                        'DbContext.NCCTVCarriageUELogRevisions.Add(NCCTVCarriageUELogRevision)
                                        'DbContext.SaveChanges()

                                    End If

                                End If

                                If FileLineData.Length = 8 Then

                                    If CInt(FileLineData(3)) <> 0 Then

                                        NCCTVCarriageUE = New AdvantageFramework.Nielsen.Database.Entities.NCCTVCarriageUE
                                        NCCTVCarriageUE.NielsenMarketNumber = CInt(FileLineData(1)) - 400
                                        NCCTVCarriageUE.NCCTVCarriageUELogID = NCCTVCarriageUELog.ID
                                        NCCTVCarriageUE.StationCode = CInt(FileLineData(3))
                                        NCCTVCarriageUE.HHCarriageUE = FileLineData(5)

                                        NCCTVCarriageUEs.Add(NCCTVCarriageUE)

                                    End If

                                End If

                            Loop

                            BulkInsertNCCTVCarriageUEList(DbContext, tran, NCCTVCarriageUEs)

                            tran.Commit()

                            Imported = True

                        Catch ex As Exception

                            tran.Rollback()

                            LogEvent(ConnectionString, "Error importing file:" & Filename & " " & ex.Message)

                        Finally

                            TextFieldParser.Close()
                            TextFieldParser.Dispose()

                        End Try

                    End Using

                End Using

            End If

            ImportNCCTVCarriage = Imported

        End Function
        Private Sub SetFusionUniverse(FileLineData() As String, ByRef NCCTVFusionUniverse As AdvantageFramework.Nielsen.Database.Entities.NCCTVFusionUniverse)

            Select Case FileLineData(0)

                Case "HH"

                    NCCTVFusionUniverse.Household = FileLineData(1)

                Case "C 2-5"

                    NCCTVFusionUniverse.Children2to5 = FileLineData(1)

                Case "C 6-11"

                    NCCTVFusionUniverse.Children6to11 = FileLineData(1)

                Case "M 12-17"

                    NCCTVFusionUniverse.Males12to17 = FileLineData(1)

                Case "M 18-20"

                    NCCTVFusionUniverse.Males18to20 = FileLineData(1)

                Case "M 21-24"

                    NCCTVFusionUniverse.Males21to24 = FileLineData(1)

                Case "M 25-34"

                    NCCTVFusionUniverse.Males25to34 = FileLineData(1)

                Case "M 35-49"

                    NCCTVFusionUniverse.Males35to49 = FileLineData(1)

                Case "M 50-54"

                    NCCTVFusionUniverse.Males50to54 = FileLineData(1)

                Case "M 55-64"

                    NCCTVFusionUniverse.Males55to64 = FileLineData(1)

                Case "M 65+"

                    NCCTVFusionUniverse.Males65Plus = FileLineData(1)

                Case "W 12-17"

                    NCCTVFusionUniverse.Females12to17 = FileLineData(1)

                Case "W 18-20"

                    NCCTVFusionUniverse.Females18to20 = FileLineData(1)

                Case "W 21-24"

                    NCCTVFusionUniverse.Females21to24 = FileLineData(1)

                Case "W 25-34"

                    NCCTVFusionUniverse.Females25to34 = FileLineData(1)

                Case "W 35-49"

                    NCCTVFusionUniverse.Females35to49 = FileLineData(1)

                Case "W 50-54"

                    NCCTVFusionUniverse.Females50to54 = FileLineData(1)

                Case "W 55-64"

                    NCCTVFusionUniverse.Females55to64 = FileLineData(1)

                Case "W 65+"

                    NCCTVFusionUniverse.Females65Plus = FileLineData(1)

                Case Else

                    Throw New Exception("Unexpected demo value for universe (" & FileLineData(0) & ")")

            End Select

        End Sub
        Private Function AddNCCTVFusionHutput(FileLineData() As String, NCCTVFusionUniverseID As Integer,
                                              Monday As Date) As AdvantageFramework.Nielsen.Database.Entities.NCCTVFusionHutput

            'objects
            Dim NCCTVFusionHutput As AdvantageFramework.Nielsen.Database.Entities.NCCTVFusionHutput = Nothing
            Dim Time As String = Nothing

            NCCTVFusionHutput = New AdvantageFramework.Nielsen.Database.Entities.NCCTVFusionHutput
            NCCTVFusionHutput.NCCTVFusionUniverseID = NCCTVFusionUniverseID

            Time = Mid(FileLineData(0), InStr(FileLineData(0), " ") + 1)
            Time = Left(Time, InStr(Time, "-") - 1)

            If FileLineData(0).ToString.StartsWith("Monday") Then

                NCCTVFusionHutput.HutputDatetime = CDate(Monday.ToShortDateString & " " & Left(Time, Time.Length - 1) & If(Right(Time, 1) = "a", " AM", " PM"))

            ElseIf FileLineData(0).ToString.StartsWith("Tuesday") Then

                NCCTVFusionHutput.HutputDatetime = CDate(Monday.ToShortDateString & " " & Left(Time, Time.Length - 1) & If(Right(Time, 1) = "a", " AM", " PM")).AddDays(1)

            ElseIf FileLineData(0).ToString.StartsWith("Wednesday") Then

                NCCTVFusionHutput.HutputDatetime = CDate(Monday.ToShortDateString & " " & Left(Time, Time.Length - 1) & If(Right(Time, 1) = "a", " AM", " PM")).AddDays(2)

            ElseIf FileLineData(0).ToString.StartsWith("Thursday") Then

                NCCTVFusionHutput.HutputDatetime = CDate(Monday.ToShortDateString & " " & Left(Time, Time.Length - 1) & If(Right(Time, 1) = "a", " AM", " PM")).AddDays(3)

            ElseIf FileLineData(0).ToString.StartsWith("Friday") Then

                NCCTVFusionHutput.HutputDatetime = CDate(Monday.ToShortDateString & " " & Left(Time, Time.Length - 1) & If(Right(Time, 1) = "a", " AM", " PM")).AddDays(4)

            ElseIf FileLineData(0).ToString.StartsWith("Saturday") Then

                NCCTVFusionHutput.HutputDatetime = CDate(Monday.ToShortDateString & " " & Left(Time, Time.Length - 1) & If(Right(Time, 1) = "a", " AM", " PM")).AddDays(5)

            ElseIf FileLineData(0).ToString.StartsWith("Sunday") Then

                NCCTVFusionHutput.HutputDatetime = CDate(Monday.ToShortDateString & " " & Left(Time, Time.Length - 1) & If(Right(Time, 1) = "a", " AM", " PM")).AddDays(6)

            End If

            NCCTVFusionHutput.Household = FileLineData(3)
            NCCTVFusionHutput.Children2to5 = FileLineData(20)
            NCCTVFusionHutput.Children6to11 = FileLineData(21)
            NCCTVFusionHutput.Males12to17 = FileLineData(4)
            NCCTVFusionHutput.Males18to20 = FileLineData(5)
            NCCTVFusionHutput.Males21to24 = FileLineData(6)
            NCCTVFusionHutput.Males25to34 = FileLineData(7)
            NCCTVFusionHutput.Males35to49 = FileLineData(8)
            NCCTVFusionHutput.Males50to54 = FileLineData(9)
            NCCTVFusionHutput.Males55to64 = FileLineData(10)
            NCCTVFusionHutput.Males65Plus = FileLineData(11)
            NCCTVFusionHutput.Females12to17 = FileLineData(12)
            NCCTVFusionHutput.Females18to20 = FileLineData(13)
            NCCTVFusionHutput.Females21to24 = FileLineData(14)
            NCCTVFusionHutput.Females25to34 = FileLineData(15)
            NCCTVFusionHutput.Females35to49 = FileLineData(16)
            NCCTVFusionHutput.Females50to54 = FileLineData(17)
            NCCTVFusionHutput.Females55to64 = FileLineData(18)
            NCCTVFusionHutput.Females65Plus = FileLineData(19)

            AddNCCTVFusionHutput = NCCTVFusionHutput

        End Function
        Private Sub AddNCCTVFusionHutputs(ByRef NCCTVFusionHutputs As Generic.List(Of AdvantageFramework.Nielsen.Database.Entities.NCCTVFusionHutput),
                                          FileLineData() As String, Mondays() As Nullable(Of Date),
                                          NCCTVFusionUniverseID As Integer)

            NCCTVFusionHutputs.Add(AddNCCTVFusionHutput(FileLineData, NCCTVFusionUniverseID, Mondays(0).Value))
            NCCTVFusionHutputs.Add(AddNCCTVFusionHutput(FileLineData, NCCTVFusionUniverseID, Mondays(1).Value))
            NCCTVFusionHutputs.Add(AddNCCTVFusionHutput(FileLineData, NCCTVFusionUniverseID, Mondays(2).Value))
            NCCTVFusionHutputs.Add(AddNCCTVFusionHutput(FileLineData, NCCTVFusionUniverseID, Mondays(3).Value))

        End Sub
        Private Function AddNCCTVFusionAudience(FileLineData() As String, NCCTVFusionUniverseID As Integer,
                                                Monday As Date, StationCode As Integer) As AdvantageFramework.Nielsen.Database.Entities.NCCTVFusionAudience

            'objects
            Dim NCCTVFusionAudience As AdvantageFramework.Nielsen.Database.Entities.NCCTVFusionAudience = Nothing
            Dim Time As String = Nothing

            NCCTVFusionAudience = New AdvantageFramework.Nielsen.Database.Entities.NCCTVFusionAudience
            NCCTVFusionAudience.NCCTVFusionUniverseID = NCCTVFusionUniverseID
            NCCTVFusionAudience.StationCode = StationCode

            Time = Mid(FileLineData(0), InStr(FileLineData(0), " ") + 1)
            Time = Left(Time, InStr(Time, "-") - 1)

            If FileLineData(0).ToString.StartsWith("Monday") Then

                NCCTVFusionAudience.AudienceDatetime = CDate(Monday.ToShortDateString & " " & Left(Time, Time.Length - 1) & If(Right(Time, 1) = "a", " AM", " PM"))

            ElseIf FileLineData(0).ToString.StartsWith("Tuesday") Then

                NCCTVFusionAudience.AudienceDatetime = CDate(Monday.ToShortDateString & " " & Left(Time, Time.Length - 1) & If(Right(Time, 1) = "a", " AM", " PM")).AddDays(1)

            ElseIf FileLineData(0).ToString.StartsWith("Wednesday") Then

                NCCTVFusionAudience.AudienceDatetime = CDate(Monday.ToShortDateString & " " & Left(Time, Time.Length - 1) & If(Right(Time, 1) = "a", " AM", " PM")).AddDays(2)

            ElseIf FileLineData(0).ToString.StartsWith("Thursday") Then

                NCCTVFusionAudience.AudienceDatetime = CDate(Monday.ToShortDateString & " " & Left(Time, Time.Length - 1) & If(Right(Time, 1) = "a", " AM", " PM")).AddDays(3)

            ElseIf FileLineData(0).ToString.StartsWith("Friday") Then

                NCCTVFusionAudience.AudienceDatetime = CDate(Monday.ToShortDateString & " " & Left(Time, Time.Length - 1) & If(Right(Time, 1) = "a", " AM", " PM")).AddDays(4)

            ElseIf FileLineData(0).ToString.StartsWith("Saturday") Then

                NCCTVFusionAudience.AudienceDatetime = CDate(Monday.ToShortDateString & " " & Left(Time, Time.Length - 1) & If(Right(Time, 1) = "a", " AM", " PM")).AddDays(5)

            ElseIf FileLineData(0).ToString.StartsWith("Sunday") Then

                NCCTVFusionAudience.AudienceDatetime = CDate(Monday.ToShortDateString & " " & Left(Time, Time.Length - 1) & If(Right(Time, 1) = "a", " AM", " PM")).AddDays(6)

            End If

            NCCTVFusionAudience.Household = FileLineData(3)
            NCCTVFusionAudience.Children2to5 = FileLineData(20)
            NCCTVFusionAudience.Children6to11 = FileLineData(21)
            NCCTVFusionAudience.Males12to17 = FileLineData(4)
            NCCTVFusionAudience.Males18to20 = FileLineData(5)
            NCCTVFusionAudience.Males21to24 = FileLineData(6)
            NCCTVFusionAudience.Males25to34 = FileLineData(7)
            NCCTVFusionAudience.Males35to49 = FileLineData(8)
            NCCTVFusionAudience.Males50to54 = FileLineData(9)
            NCCTVFusionAudience.Males55to64 = FileLineData(10)
            NCCTVFusionAudience.Males65Plus = FileLineData(11)
            NCCTVFusionAudience.Females12to17 = FileLineData(12)
            NCCTVFusionAudience.Females18to20 = FileLineData(13)
            NCCTVFusionAudience.Females21to24 = FileLineData(14)
            NCCTVFusionAudience.Females25to34 = FileLineData(15)
            NCCTVFusionAudience.Females35to49 = FileLineData(16)
            NCCTVFusionAudience.Females50to54 = FileLineData(17)
            NCCTVFusionAudience.Females55to64 = FileLineData(18)
            NCCTVFusionAudience.Females65Plus = FileLineData(19)

            AddNCCTVFusionAudience = NCCTVFusionAudience

        End Function
        Private Sub AddNCCTVFusionAudiences(ByRef NCCTVFusionAudiences As Generic.List(Of AdvantageFramework.Nielsen.Database.Entities.NCCTVFusionAudience),
                                            FileLineData() As String, Mondays() As Nullable(Of Date),
                                            NCCTVFusionUniverseID As Integer,
                                            StationCode As Integer)

            NCCTVFusionAudiences.Add(AddNCCTVFusionAudience(FileLineData, NCCTVFusionUniverseID, Mondays(0).Value, StationCode))
            NCCTVFusionAudiences.Add(AddNCCTVFusionAudience(FileLineData, NCCTVFusionUniverseID, Mondays(1).Value, StationCode))
            NCCTVFusionAudiences.Add(AddNCCTVFusionAudience(FileLineData, NCCTVFusionUniverseID, Mondays(2).Value, StationCode))
            NCCTVFusionAudiences.Add(AddNCCTVFusionAudience(FileLineData, NCCTVFusionUniverseID, Mondays(3).Value, StationCode))

        End Sub
        'Private Function ImportNCCFusionFile(ConnectionString As String, Filename As String) As Boolean

        '    'objects
        '    Dim TextFieldParser As FileIO.TextFieldParser = Nothing
        '    Dim FilenameFields() As String = Nothing
        '    Dim FusionExcludeMarkets As IEnumerable(Of Integer) = Nothing
        '    Dim NielsenMarket As AdvantageFramework.Nielsen.Database.Entities.NielsenMarket = Nothing
        '    Dim FileLineData() As String = Nothing
        '    Dim FileLineCounter As Integer = 1
        '    Dim MarketNumber As Integer = 0
        '    Dim Year As Short = 0
        '    Dim Month As Short = 0
        '    Dim Geo As AdvantageFramework.Nielsen.Database.Entities.NCCTVGeo
        '    Dim Stream As String = Nothing
        '    Dim NCCTVFusionUniverse As AdvantageFramework.Nielsen.Database.Entities.NCCTVFusionUniverse = Nothing
        '    Dim NCCTVFusionUniverseRevision As AdvantageFramework.Nielsen.Database.Entities.NCCTVFusionUniverseRevision = Nothing
        '    Dim IsRevision As Boolean = False
        '    Dim NCCTVFusionHutputs As Generic.List(Of AdvantageFramework.Nielsen.Database.Entities.NCCTVFusionHutput) = Nothing
        '    Dim NCCTVFusionAudiences As Generic.List(Of AdvantageFramework.Nielsen.Database.Entities.NCCTVFusionAudience) = Nothing
        '    Dim Mondays(3) As Nullable(Of Date)
        '    Dim StationCode As Integer = 0
        '    Dim Imported As Boolean = False

        '    If System.IO.File.Exists(Filename) Then

        '        TextFieldParser = New FileIO.TextFieldParser(Filename)

        '        TextFieldParser.TextFieldType = FileIO.FieldType.Delimited
        '        TextFieldParser.Delimiters = {","}
        '        TextFieldParser.HasFieldsEnclosedInQuotes = True

        '        Filename = System.IO.Path.GetFileName(Filename)

        '        FilenameFields = Mid(Filename.ToUpper, 1, InStr(Filename, ".") - 1).Split("_")

        '        Using DbContext As New AdvantageFramework.Nielsen.Database.DbContext(ConnectionString, Nothing)

        '            FusionExcludeMarkets = (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NCCTVLPMMarket.Load(DbContext)
        '                                    Select Entity.NielsenMarketNumber).ToArray

        '            FileLineData = TextFieldParser.ReadFields

        '            FileLineCounter += 1

        '            NielsenMarket = AdvantageFramework.Nielsen.Database.Procedures.NielsenMarket.LoadByNielsenTVCode(DbContext, FileLineData(1))

        '            If NielsenMarket Is Nothing OrElse String.IsNullOrWhiteSpace(NielsenMarket.NielsenTVCode) Then

        '                LogEvent(ConnectionString, "Could not find tv market number for tv code: " & FileLineData(1))

        '            ElseIf FusionExcludeMarkets.Contains(CInt(NielsenMarket.NielsenTVCode)) = False Then

        '                Mondays(0) = GetFirstMonday(CInt("20" & Mid(FilenameFields(1), 1, 2)), CInt(Mid(FilenameFields(1), 3, 2)))
        '                Mondays(1) = Mondays(0).Value.AddDays(7)
        '                Mondays(2) = Mondays(0).Value.AddDays(14)
        '                Mondays(3) = Mondays(0).Value.AddDays(21)

        '                Using tran = DbContext.Database.BeginTransaction()

        '                    MarketNumber = CInt(NielsenMarket.NielsenTVCode)
        '                    Year = CShort("20" & FilenameFields(1).Substring(0, 2))
        '                    Month = CShort(FilenameFields(1).Substring(2, 2))
        '                    Geo = DirectCast(CShort(FilenameFields(2)), AdvantageFramework.Nielsen.Database.Entities.NCCTVGeo)

        '                    If FilenameFields(4) = "00000400" Then

        '                        Stream = "LS"

        '                    ElseIf FilenameFields(4) = "00000800" Then

        '                        Stream = "L7"

        '                    Else

        '                        Stream = Nothing

        '                    End If

        '                    NCCTVFusionUniverse = (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NCCTVFusionUniverse.Load(DbContext)
        '                                           Where Entity.NielsenMarketNumber = MarketNumber AndAlso
        '                                                 Entity.Year = Year AndAlso
        '                                                 Entity.Month = Month AndAlso
        '                                                 Entity.Geo = Geo AndAlso
        '                                                 Entity.Stream = Stream
        '                                           Select Entity).SingleOrDefault

        '                    If NCCTVFusionUniverse IsNot Nothing Then 'its a revision

        '                        Throw New Exception("NCC TV FUsion Universe exists")

        '                        'NCCTVFusionUniverseRevision = New AdvantageFramework.Nielsen.Database.Entities.NCCTVFusionUniverseRevision
        '                        'NCCTVFusionUniverseRevision.DbContext = DbContext
        '                        'NCCTVFusionUniverseRevision.OldNCCTVFusionUniverseID = NCCTVFusionUniverse.ID

        '                        'DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.NCC_TV_FUSION_AUDIENCE WHERE NCC_TV_FUSION_UE_ID = {0}", NCCTVFusionUniverse.ID))
        '                        'DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.NCC_TV_FUSION_HUTPUT WHERE NCC_TV_FUSION_UE_ID = {0}", NCCTVFusionUniverse.ID))
        '                        'DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.NCC_TV_FUSION_UE WHERE NCC_TV_FUSION_UE_ID = {0}", NCCTVFusionUniverse.ID))

        '                        'IsRevision = True

        '                    End If

        '                    NCCTVFusionUniverse = New AdvantageFramework.Nielsen.Database.Entities.NCCTVFusionUniverse
        '                    NCCTVFusionUniverse.DbContext = DbContext
        '                    NCCTVFusionUniverse.NielsenMarketNumber = MarketNumber
        '                    NCCTVFusionUniverse.Year = Year
        '                    NCCTVFusionUniverse.Month = Month
        '                    NCCTVFusionUniverse.Geo = Geo
        '                    NCCTVFusionUniverse.Stream = Stream

        '                    NCCTVFusionHutputs = New Generic.List(Of AdvantageFramework.Nielsen.Database.Entities.NCCTVFusionHutput)
        '                    NCCTVFusionAudiences = New Generic.List(Of AdvantageFramework.Nielsen.Database.Entities.NCCTVFusionAudience)

        '                    Try

        '                        Do While Not TextFieldParser.EndOfData

        '                            FileLineData = TextFieldParser.ReadFields

        '                            If FileLineCounter >= 2 AndAlso FileLineCounter <= 20 Then

        '                                SetFusionUniverse(FileLineData, NCCTVFusionUniverse)

        '                                If FileLineCounter = 20 Then

        '                                    DbContext.NCCTVFusionUniverses.Add(NCCTVFusionUniverse)
        '                                    DbContext.SaveChanges()

        '                                    If IsRevision Then

        '                                        NCCTVFusionUniverseRevision.NewNCCTVFusionUniverseID = NCCTVFusionUniverse.ID
        '                                        DbContext.NCCTVFusionUniverseRevisions.Add(NCCTVFusionUniverseRevision)
        '                                        DbContext.SaveChanges()

        '                                    End If

        '                                End If

        '                            ElseIf FileLineCounter >= 23 AndAlso FileLineCounter <= 694 Then

        '                                AddNCCTVFusionHutputs(NCCTVFusionHutputs, FileLineData, Mondays, NCCTVFusionUniverse.ID)

        '                            ElseIf FileLineCounter > 694 Then

        '                                If IsNumeric(FileLineData(0)) Then

        '                                    StationCode = FileLineData(0)

        '                                ElseIf FileLineData(1) = "01020304" Then

        '                                    AddNCCTVFusionAudiences(NCCTVFusionAudiences, FileLineData, Mondays, NCCTVFusionUniverse.ID, StationCode)

        '                                End If

        '                            End If

        '                            FileLineCounter += 1

        '                        Loop

        '                        BulkInsertNCCTVFusionHutputList(DbContext, tran, NCCTVFusionHutputs)

        '                        BulkInsertNCCTVFusionAudienceList(DbContext, tran, NCCTVFusionAudiences)

        '                        tran.Commit()

        '                        Imported = True

        '                    Catch ex As Exception

        '                        tran.Rollback()

        '                        LogEvent(ConnectionString, "Error importing file:" & Filename & " " & ex.Message)

        '                    Finally

        '                        TextFieldParser.Close()
        '                        TextFieldParser.Dispose()

        '                    End Try

        '                End Using

        '            End If

        '        End Using

        '    End If

        '    ImportNCCFusionFile = Imported

        'End Function

#End Region

#End Region

    End Module

End Namespace

