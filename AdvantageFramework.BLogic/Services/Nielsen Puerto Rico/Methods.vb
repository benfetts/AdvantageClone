Namespace Services.NielsenPuertoRico

    <HideModuleName()>
    Public Module Methods

        Public Event EntryLogWrittenEvent(ByVal EventLogEntry As System.Diagnostics.EventLogEntry)

#Region " Constants "

        Public Const NIELSEN_PUERTO_RICO_URL = "ftp.pr.agbnielsen.com"

#End Region

#Region " Enum "

        Public Enum RegistrySetting
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\NielsenPuertoRico\", "RunAt", "01/01/2001 01:00 AM")>
            RunAt
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\NielsenPuertoRico\", "EmployeeCode", "")>
            EmployeeCode
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\NielsenPuertoRico\", "LocalFolder", "")>
            LocalFolder
        End Enum

#End Region

#Region " Variables "

        Private WithEvents _EventLog As System.Diagnostics.EventLog = Nothing
        Private _IsRunning As Boolean = False

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub _EventLog_EntryWritten(ByVal sender As Object, ByVal e As System.Diagnostics.EntryWrittenEventArgs) Handles _EventLog.EntryWritten

            RaiseEvent EntryLogWrittenEvent(e.Entry)

        End Sub
        Private Sub SendFailureEmail(DatabaseProfile As AdvantageFramework.Database.DatabaseProfile, EmployeeIsValid As Boolean, EmployeeCode As String)

            If EmployeeIsValid Then

                AdvantageFramework.AlertSystem.CreateAlertForNonHostedNielsenPuertoRicoDataImport(DatabaseProfile, EmployeeCode)

            End If

        End Sub
        Private Sub InitLog()

            If System.Diagnostics.EventLog.SourceExists("NPR Source") = False Then

                System.Diagnostics.EventLog.CreateEventSource("NPR Source", "NPR Log")

            End If

            _EventLog = New System.Diagnostics.EventLog("NPR Log", My.Computer.Name, "NPR Source")

            _EventLog.ModifyOverflowPolicy(System.Diagnostics.OverflowAction.OverwriteAsNeeded, _EventLog.MinimumRetentionDays)

            _EventLog.EnableRaisingEvents = True

        End Sub
        Public Sub ProcessDatabase(ByRef DatabaseProfile As AdvantageFramework.Database.DatabaseProfile)

            'objects
            Dim Session As AdvantageFramework.Security.Session = Nothing
            Dim EmployeeCode As String = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim EmployeeIsValid As Boolean = True
            Dim ErrorMessage As String = Nothing
            Dim LocalFolder As String = Nothing

            Try

                If DatabaseProfile IsNot Nothing AndAlso _IsRunning = False Then

                    InitLog()

                    _IsRunning = True

                    WriteToEventLog("Nielsen PR connecting to database --> " & DatabaseProfile.DatabaseName)

                    Session = New AdvantageFramework.Security.Session(Security.Application.Advantage, DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName, 0, DatabaseProfile.ConnectionString)

                    Using DataContext = New AdvantageFramework.Database.DataContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                        Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                            WriteToEventLog("Nielsen PR load service settings --> " & DatabaseProfile.DatabaseName)

                            AdvantageFramework.Services.NielsenPuertoRico.LoadSettings(DataContext, Nothing, EmployeeCode, LocalFolder)

                            WriteToEventLog("Validating Employee/User...")

                            Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode)

                            If Employee Is Nothing OrElse Employee.TerminationDate IsNot Nothing OrElse String.IsNullOrWhiteSpace(Employee.Email) Then

                                WriteToEventLog("Employee does not exist, or has been terminated or does not have email address.  EmployeeCode (" & EmployeeCode & ")")
                                EmployeeIsValid = False

                            End If

                            If System.IO.Directory.Exists(LocalFolder) = False Then

                                WriteToEventLog("Local Folder does not exist. --> " & LocalFolder)
                                Throw New Exception("Local Folder does not exist. --> " & LocalFolder)

                            Else

                                WriteToEventLog("Nielsen PR Import Data")

                                If ImportData(DbContext, LocalFolder, ErrorMessage) = False Then

                                    If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                                        WriteToEventLog("Nielsen PR Import Data failed: " & ErrorMessage)

                                    Else

                                        WriteToEventLog("Nielsen PR Import Data failed.  Contact customer support.")

                                    End If

                                Else

                                    WriteToEventLog("Nielsen PR Import Data complete")

                                End If

                            End If

                        End Using

                    End Using

                End If

            Catch ex As Exception

                If String.IsNullOrWhiteSpace(ex.Message) Then

                    WriteToEventLog("Nielsen PR Error Processing - " & ex.StackTrace & Space(1) & DatabaseProfile.DatabaseName)

                Else

                    WriteToEventLog("Nielsen PR Error Processing - " & ex.Message & " --> " & DatabaseProfile.DatabaseName)

                End If

                SendFailureEmail(DatabaseProfile, EmployeeIsValid, EmployeeCode)

            Finally

                _IsRunning = False

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

                                DateTime.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.NielsenPuertoRico.RegistrySetting.RunAt), RunAt)

                                If RunAt = CDate("01/01/2001 01:00 AM") Then

                                    RunAt = Now.ToShortDateString & " " & RunAt.ToShortTimeString

                                End If

                                If DateDiff(DateInterval.Minute, RunAt, Now) >= 0 Then

                                    RunAt = Now.AddDays(1).ToShortDateString & " " & RunAt.ToShortTimeString

                                    SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.NielsenPuertoRico.RegistrySetting.RunAt, RunAt)

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

            If System.Diagnostics.EventLog.SourceExists("NPR Source") = False Then

                System.Diagnostics.EventLog.CreateEventSource("NPR Source", "NPR Log")

            End If

            _EventLog = New System.Diagnostics.EventLog("NPR Log", My.Computer.Name, "NPR Source")

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

                AdvantageService = AdvantageFramework.Services.LoadAdvantageService(DataContext, AdvantageFramework.Services.Service.AdvantageNielsenPuertoRicoWindowsService)

            Catch ex As Exception
                AdvantageService = Nothing
            End Try

            LoadAdvantageService = AdvantageService

        End Function
        Public Function LoadAdvantageServiceSetting(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AdvantageServiceID As Integer, ByVal RegistrySetting As AdvantageFramework.Services.NielsenPuertoRico.RegistrySetting) As AdvantageFramework.Database.Entities.AdvantageServiceSetting

            'objects
            Dim AdvantageServiceSetting As AdvantageFramework.Database.Entities.AdvantageServiceSetting = Nothing

            Try

                AdvantageServiceSetting = AdvantageFramework.Services.LoadAdvantageServiceSetting(DataContext, AdvantageServiceID, RegistrySetting.ToString)

            Catch ex As Exception
                AdvantageServiceSetting = Nothing
            End Try

            LoadAdvantageServiceSetting = AdvantageServiceSetting

        End Function
        Public Function LoadAdvantageServiceSettingValue(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AdvantageServiceID As Integer, ByVal RegistrySetting As AdvantageFramework.Services.NielsenPuertoRico.RegistrySetting) As Object

            'objects
            Dim SettingValue As Object = Nothing

            Try

                SettingValue = AdvantageFramework.Services.LoadAdvantageServiceSettingValue(DataContext, AdvantageServiceID, RegistrySetting.ToString)

            Catch ex As Exception
                SettingValue = Nothing
            End Try

            LoadAdvantageServiceSettingValue = SettingValue

        End Function
        Public Function SaveAdvantageServiceSettingValue(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AdvantageServiceID As Integer, ByVal RegistrySetting As AdvantageFramework.Services.NielsenPuertoRico.RegistrySetting, ByVal SettingValue As Object) As Boolean

            'objects
            Dim Saved As Boolean = False

            Try

                Saved = AdvantageFramework.Services.SaveAdvantageServiceSettingValue(DataContext, AdvantageServiceID, RegistrySetting.ToString, SettingValue)

            Catch ex As Exception
                Saved = False
            End Try

            SaveAdvantageServiceSettingValue = Saved

        End Function
        Public Sub LoadSettings(ByVal DataContext As AdvantageFramework.Database.DataContext, ByRef RunAt As Date, ByRef EmployeeCode As String, ByRef LocalFolder As String)

            'objects
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing

            AdvantageService = LoadAdvantageService(DataContext)

            If AdvantageService IsNot Nothing Then

                DateTime.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.NielsenPuertoRico.RegistrySetting.RunAt), RunAt)

                EmployeeCode = LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.NielsenPuertoRico.RegistrySetting.EmployeeCode)

                LocalFolder = LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.NielsenPuertoRico.RegistrySetting.LocalFolder)

            End If

        End Sub
        Public Sub SaveSettings(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal RunAt As DateTime, EmployeeCode As String, LocalFolder As String)

            'objects
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing

            AdvantageService = LoadAdvantageService(DataContext)

            If AdvantageService IsNot Nothing Then

                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.NielsenPuertoRico.RegistrySetting.RunAt, RunAt)
                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.NielsenPuertoRico.RegistrySetting.EmployeeCode, EmployeeCode)
                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.NielsenPuertoRico.RegistrySetting.LocalFolder, LocalFolder)

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
        Public Function LoadEmployees(ByVal DbContext As AdvantageFramework.Database.DbContext) As Generic.List(Of AdvantageFramework.Database.Views.Employee)

            'objects
            Dim Employees As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing

            Employees = (From Employee In AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActive(DbContext)
                         Where Employee.Email IsNot Nothing AndAlso
                               Employee.Email <> ""
                         Select Employee).ToList

            LoadEmployees = Employees

        End Function

#Region " Import "

        Private Function SaveStations(DbContext As AdvantageFramework.Database.DbContext, LineParts() As String) As Generic.List(Of AdvantageFramework.Database.Entities.NPRStation)

            Dim NPRStation As AdvantageFramework.Database.Entities.NPRStation = Nothing
            Dim NPRStationNames As Generic.List(Of String) = Nothing
            Dim StationName As String = Nothing

            NPRStationNames = (From Entity In DbContext.GetQuery(Of Database.Entities.NPRStation)
                               Select Entity.Name.ToUpper).ToList

            For Each LinePart In LineParts

                StationName = LinePart.ToUpper.Trim.Replace("SELECTED CHANNEL(S):,", "").Replace(",", "")

                If String.IsNullOrWhiteSpace(StationName) = False AndAlso StationName <> "TOTAL TV" Then

                    If NPRStationNames.Contains(StationName) = False Then

                        NPRStation = New AdvantageFramework.Database.Entities.NPRStation
                        NPRStation.DbContext = DbContext
                        NPRStation.Name = StationName

                        DbContext.NPRStations.Add(NPRStation)

                    End If

                End If

            Next

            DbContext.SaveChanges()

            SaveStations = (From Entity In DbContext.GetQuery(Of Database.Entities.NPRStation)
                            Select Entity).ToList

        End Function
        Private Sub SaveHutput(DbContext As AdvantageFramework.Database.DbContext, LineParts() As String, [Date] As Date)

            Dim NPRHutput As AdvantageFramework.Database.Entities.NPRHutput = Nothing
            Dim Times As String() = Nothing
            Dim StartTime As TimeSpan = Nothing

            NPRHutput = New AdvantageFramework.Database.Entities.NPRHutput
            NPRHutput.DbContext = DbContext

            Times = LineParts(2).Split("-")

            If Times(0).ToLower.Contains("a") Then

                StartTime = TimeSpan.Parse(Times(0).ToLower.Replace("a", "").Trim)

                If StartTime.Hours = 12 Then

                    StartTime = StartTime.Add(New TimeSpan(-12, 0, 0))

                End If

            Else

                StartTime = TimeSpan.Parse(Times(0).ToLower.Replace("p", "").Trim)

                If StartTime.Hours <> 12 Then

                    StartTime = StartTime.Add(New TimeSpan(12, 0, 0))

                End If

            End If

            If StartTime.Hours = 0 OrElse StartTime.Hours = 1 Then

                NPRHutput.[Date] = [Date].AddDays(1).AddTicks(StartTime.Ticks)

            Else

                NPRHutput.[Date] = [Date].AddTicks(StartTime.Ticks)

            End If

            NPRHutput.Homes = LineParts(3).Replace("n.a.", "0")
            NPRHutput.People2Plus = LineParts(4).Replace("n.a.", "0")
            NPRHutput.Males2Plus = LineParts(5).Replace("n.a.", "0")
            NPRHutput.Males2to5 = LineParts(7).Replace("n.a.", "0")
            NPRHutput.Males6to11 = LineParts(9).Replace("n.a.", "0")
            NPRHutput.Males12to14 = LineParts(11).Replace("n.a.", "0")
            NPRHutput.Males15to17 = LineParts(13).Replace("n.a.", "0")
            NPRHutput.Males18to20 = LineParts(15).Replace("n.a.", "0")
            NPRHutput.Males21to24 = LineParts(17).Replace("n.a.", "0")
            NPRHutput.Males25to34 = LineParts(19).Replace("n.a.", "0")
            NPRHutput.Males35to44 = LineParts(21).Replace("n.a.", "0")
            NPRHutput.Males45to49 = LineParts(23).Replace("n.a.", "0")
            NPRHutput.Males50to54 = LineParts(25).Replace("n.a.", "0")
            NPRHutput.Males55to64 = LineParts(27).Replace("n.a.", "0")
            NPRHutput.Males65Plus = LineParts(29).Replace("n.a.", "0")
            NPRHutput.Females2Plus = LineParts(6).Replace("n.a.", "0")
            NPRHutput.Females2to5 = LineParts(8).Replace("n.a.", "0")
            NPRHutput.Females6to11 = LineParts(10).Replace("n.a.", "0")
            NPRHutput.Females12to14 = LineParts(12).Replace("n.a.", "0")
            NPRHutput.Females15to17 = LineParts(14).Replace("n.a.", "0")
            NPRHutput.Females18to20 = LineParts(16).Replace("n.a.", "0")
            NPRHutput.Females21to24 = LineParts(18).Replace("n.a.", "0")
            NPRHutput.Females25to34 = LineParts(20).Replace("n.a.", "0")
            NPRHutput.Females35to44 = LineParts(22).Replace("n.a.", "0")
            NPRHutput.Females45to49 = LineParts(24).Replace("n.a.", "0")
            NPRHutput.Females50to54 = LineParts(26).Replace("n.a.", "0")
            NPRHutput.Females55to64 = LineParts(28).Replace("n.a.", "0")
            NPRHutput.Females65Plus = LineParts(30).Replace("n.a.", "0")
            NPRHutput.WorkingWomen = LineParts(31).Replace("n.a.", "0")

            DbContext.NPRHutputs.Add(NPRHutput)
            DbContext.SaveChanges()

        End Sub
        Private Sub SaveAudience(DbContext As AdvantageFramework.Database.DbContext, LineParts() As String, NPRStations As Generic.List(Of AdvantageFramework.Database.Entities.NPRStation), [Date] As Date)

            Dim NPRAudience As AdvantageFramework.Database.Entities.NPRAudience = Nothing
            Dim StationName As String = Nothing
            Dim Times As String() = Nothing
            Dim StartTime As TimeSpan = Nothing

            StationName = LineParts(1).Trim.ToUpper

            NPRAudience = New AdvantageFramework.Database.Entities.NPRAudience
            NPRAudience.DbContext = DbContext
            NPRAudience.NPRStationID = (From Entity In NPRStations
                                        Where Entity.Name.ToUpper = StationName
                                        Select Entity.ID).First

            Times = LineParts(2).Split("-")

            If Times(0).ToLower.Contains("a") Then

                StartTime = TimeSpan.Parse(Times(0).ToLower.Replace("a", "").Trim)

                If StartTime.Hours = 12 Then

                    StartTime = StartTime.Add(New TimeSpan(-12, 0, 0))

                End If

            Else

                StartTime = TimeSpan.Parse(Times(0).ToLower.Replace("p", "").Trim)

                If StartTime.Hours <> 12 Then

                    StartTime = StartTime.Add(New TimeSpan(12, 0, 0))

                End If

            End If

            If StartTime.Hours = 0 OrElse StartTime.Hours = 1 Then

                NPRAudience.[Date] = [Date].AddDays(1).AddTicks(StartTime.Ticks)

            Else

                NPRAudience.[Date] = [Date].AddTicks(StartTime.Ticks)

            End If

            NPRAudience.Homes = LineParts(3).Replace("n.a.", "0")
            NPRAudience.People2Plus = LineParts(4).Replace("n.a.", "0")
            NPRAudience.Males2Plus = LineParts(5).Replace("n.a.", "0")
            NPRAudience.Males2to5 = LineParts(7).Replace("n.a.", "0")
            NPRAudience.Males6to11 = LineParts(9).Replace("n.a.", "0")
            NPRAudience.Males12to14 = LineParts(11).Replace("n.a.", "0")
            NPRAudience.Males15to17 = LineParts(13).Replace("n.a.", "0")
            NPRAudience.Males18to20 = LineParts(15).Replace("n.a.", "0")
            NPRAudience.Males21to24 = LineParts(17).Replace("n.a.", "0")
            NPRAudience.Males25to34 = LineParts(19).Replace("n.a.", "0")
            NPRAudience.Males35to44 = LineParts(21).Replace("n.a.", "0")
            NPRAudience.Males45to49 = LineParts(23).Replace("n.a.", "0")
            NPRAudience.Males50to54 = LineParts(25).Replace("n.a.", "0")
            NPRAudience.Males55to64 = LineParts(27).Replace("n.a.", "0")
            NPRAudience.Males65Plus = LineParts(29).Replace("n.a.", "0")
            NPRAudience.Females2Plus = LineParts(6).Replace("n.a.", "0")
            NPRAudience.Females2to5 = LineParts(8).Replace("n.a.", "0")
            NPRAudience.Females6to11 = LineParts(10).Replace("n.a.", "0")
            NPRAudience.Females12to14 = LineParts(12).Replace("n.a.", "0")
            NPRAudience.Females15to17 = LineParts(14).Replace("n.a.", "0")
            NPRAudience.Females18to20 = LineParts(16).Replace("n.a.", "0")
            NPRAudience.Females21to24 = LineParts(18).Replace("n.a.", "0")
            NPRAudience.Females25to34 = LineParts(20).Replace("n.a.", "0")
            NPRAudience.Females35to44 = LineParts(22).Replace("n.a.", "0")
            NPRAudience.Females45to49 = LineParts(24).Replace("n.a.", "0")
            NPRAudience.Females50to54 = LineParts(26).Replace("n.a.", "0")
            NPRAudience.Females55to64 = LineParts(28).Replace("n.a.", "0")
            NPRAudience.Females65Plus = LineParts(30).Replace("n.a.", "0")
            NPRAudience.WorkingWomen = LineParts(31).Replace("n.a.", "0")
            NPRAudience.ProgramName = Mid(LineParts(32), 1, 100)

            DbContext.NPRAudiences.Add(NPRAudience)
            DbContext.SaveChanges()

        End Sub
        Private Function ProcessFile(DbContext As AdvantageFramework.Database.DbContext, NPRFile As AdvantageFramework.Database.Entities.NPRFile) As Boolean

            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim Processed As Boolean = False
            Dim StreamReader As System.IO.StreamReader = Nothing
            Dim TextLine As String = Nothing
            Dim NPRUniverse As AdvantageFramework.Database.Entities.NPRUniverse = Nothing
            Dim NPRIntab As AdvantageFramework.Database.Entities.NPRIntab = Nothing
            Dim LineParts() As String = Nothing
            Dim LineCounter As Integer = 0
            Dim NPRStations As Generic.List(Of AdvantageFramework.Database.Entities.NPRStation) = Nothing

            If System.IO.File.Exists(NPRFile.FileName) Then

                Try

                    DbContext.Database.Connection.Open()

                    DbContext.Configuration.AutoDetectChangesEnabled = False

                    DbTransaction = DbContext.Database.BeginTransaction

                    NPRUniverse = New AdvantageFramework.Database.Entities.NPRUniverse
                    NPRUniverse.DbContext = DbContext

                    NPRIntab = New AdvantageFramework.Database.Entities.NPRIntab
                    NPRIntab.DbContext = DbContext

                    StreamReader = New System.IO.StreamReader(NPRFile.FileName)

                    Do While StreamReader.Peek() <> -1

                        TextLine = StreamReader.ReadLine()
                        LineCounter += 1

                        If LineCounter >= 47 Then

                            LineParts = TextLine.Split(",")

                            If LineParts(1).ToUpper = "TOTAL TV" Then

                                SaveHutput(DbContext, LineParts, NPRUniverse.Date)

                            Else

                                SaveAudience(DbContext, LineParts, NPRStations, NPRUniverse.Date)

                            End If

                        ElseIf TextLine.ToUpper.StartsWith("REPORTED DATE(S)") Then

                            LineParts = TextLine.Split(",")
                            NPRUniverse.Date = CDate(LineParts(1).Trim.ToUpper.Replace(";", ""))
                            NPRIntab.Date = CDate(LineParts(1).Trim.ToUpper.Replace(";", ""))

                        ElseIf TextLine.ToUpper.StartsWith("SELECTED CHANNEL(S):,") Then

                            LineParts = TextLine.Split(";")
                            NPRStations = SaveStations(DbContext, LineParts)

                        ElseIf TextLine.ToUpper.StartsWith(",TOTAL HOMES UNIVERSE") Then

                            LineParts = TextLine.Split(":")
                            NPRUniverse.Homes = CInt(LineParts(1).Trim.ToUpper.Replace("SAMPLE SIZE", ""))
                            NPRIntab.Homes = CInt(LineParts(2).Trim.ToUpper.Replace("PESS", ""))

                        ElseIf TextLine.ToUpper.StartsWith(",PEOPLE 2+") Then

                            LineParts = TextLine.Split(":")
                            NPRUniverse.People2Plus = CInt(LineParts(1).Trim.ToUpper.Replace("SAMPLE SIZE", ""))
                            NPRIntab.People2Plus = CInt(LineParts(2).Trim.ToUpper.Replace("PESS", ""))

                        ElseIf TextLine.ToUpper.StartsWith(",MALES 2+") Then

                            LineParts = TextLine.Split(":")
                            NPRUniverse.Males2Plus = CInt(LineParts(1).Trim.ToUpper.Replace("SAMPLE SIZE", ""))
                            NPRIntab.Males2Plus = CInt(LineParts(2).Trim.ToUpper.Replace("PESS", ""))

                        ElseIf TextLine.ToUpper.StartsWith(",FEMALES 2+") Then

                            LineParts = TextLine.Split(":")
                            NPRUniverse.Females2Plus = CInt(LineParts(1).Trim.ToUpper.Replace("SAMPLE SIZE", ""))
                            NPRIntab.Females2Plus = CInt(LineParts(2).Trim.ToUpper.Replace("PESS", ""))

                        ElseIf TextLine.ToUpper.StartsWith(",MALES 2-5") Then

                            LineParts = TextLine.Split(":")
                            NPRUniverse.Males2to5 = CInt(LineParts(1).Trim.ToUpper.Replace("SAMPLE SIZE", ""))
                            NPRIntab.Males2to5 = CInt(LineParts(2).Trim.ToUpper.Replace("PESS", ""))

                        ElseIf TextLine.ToUpper.StartsWith(",FEMALES 2-5") Then

                            LineParts = TextLine.Split(":")
                            NPRUniverse.Females2to5 = CInt(LineParts(1).Trim.ToUpper.Replace("SAMPLE SIZE", ""))
                            NPRIntab.Females2to5 = CInt(LineParts(2).Trim.ToUpper.Replace("PESS", ""))

                        ElseIf TextLine.ToUpper.StartsWith(",MALES 6-11") Then

                            LineParts = TextLine.Split(":")
                            NPRUniverse.Males6to11 = CInt(LineParts(1).Trim.ToUpper.Replace("SAMPLE SIZE", ""))
                            NPRIntab.Males6to11 = CInt(LineParts(2).Trim.ToUpper.Replace("PESS", ""))

                        ElseIf TextLine.ToUpper.StartsWith(",FEMALES 6-11") Then

                            LineParts = TextLine.Split(":")
                            NPRUniverse.Females6to11 = CInt(LineParts(1).Trim.ToUpper.Replace("SAMPLE SIZE", ""))
                            NPRIntab.Females6to11 = CInt(LineParts(2).Trim.ToUpper.Replace("PESS", ""))

                        ElseIf TextLine.ToUpper.StartsWith(",MALES 12-14") Then

                            LineParts = TextLine.Split(":")
                            NPRUniverse.Males12to14 = CInt(LineParts(1).Trim.ToUpper.Replace("SAMPLE SIZE", ""))
                            NPRIntab.Males12to14 = CInt(LineParts(2).Trim.ToUpper.Replace("PESS", ""))

                        ElseIf TextLine.ToUpper.StartsWith(",FEMALES 12-14") Then

                            LineParts = TextLine.Split(":")
                            NPRUniverse.Females12to14 = CInt(LineParts(1).Trim.ToUpper.Replace("SAMPLE SIZE", ""))
                            NPRIntab.Females12to14 = CInt(LineParts(2).Trim.ToUpper.Replace("PESS", ""))

                        ElseIf TextLine.ToUpper.StartsWith(",MALES 15-17") Then

                            LineParts = TextLine.Split(":")
                            NPRUniverse.Males15to17 = CInt(LineParts(1).Trim.ToUpper.Replace("SAMPLE SIZE", ""))
                            NPRIntab.Males15to17 = CInt(LineParts(2).Trim.ToUpper.Replace("PESS", ""))

                        ElseIf TextLine.ToUpper.StartsWith(",FEMALES 15-17") Then

                            LineParts = TextLine.Split(":")
                            NPRUniverse.Females15to17 = CInt(LineParts(1).Trim.ToUpper.Replace("SAMPLE SIZE", ""))
                            NPRIntab.Females15to17 = CInt(LineParts(2).Trim.ToUpper.Replace("PESS", ""))

                        ElseIf TextLine.ToUpper.StartsWith(",MALES 18-20") Then

                            LineParts = TextLine.Split(":")
                            NPRUniverse.Males18to20 = CInt(LineParts(1).Trim.ToUpper.Replace("SAMPLE SIZE", ""))
                            NPRIntab.Males18to20 = CInt(LineParts(2).Trim.ToUpper.Replace("PESS", ""))

                        ElseIf TextLine.ToUpper.StartsWith(",FEMALES 18-20") Then

                            LineParts = TextLine.Split(":")
                            NPRUniverse.Females18to20 = CInt(LineParts(1).Trim.ToUpper.Replace("SAMPLE SIZE", ""))
                            NPRIntab.Females18to20 = CInt(LineParts(2).Trim.ToUpper.Replace("PESS", ""))

                        ElseIf TextLine.ToUpper.StartsWith(",MALES 21-24") Then

                            LineParts = TextLine.Split(":")
                            NPRUniverse.Males21to24 = CInt(LineParts(1).Trim.ToUpper.Replace("SAMPLE SIZE", ""))
                            NPRIntab.Males21to24 = CInt(LineParts(2).Trim.ToUpper.Replace("PESS", ""))

                        ElseIf TextLine.ToUpper.StartsWith(",FEMALES 21-24") Then

                            LineParts = TextLine.Split(":")
                            NPRUniverse.Females21to24 = CInt(LineParts(1).Trim.ToUpper.Replace("SAMPLE SIZE", ""))
                            NPRIntab.Females21to24 = CInt(LineParts(2).Trim.ToUpper.Replace("PESS", ""))

                        ElseIf TextLine.ToUpper.StartsWith(",MALES 25-34") Then

                            LineParts = TextLine.Split(":")
                            NPRUniverse.Males25to34 = CInt(LineParts(1).Trim.ToUpper.Replace("SAMPLE SIZE", ""))
                            NPRIntab.Males25to34 = CInt(LineParts(2).Trim.ToUpper.Replace("PESS", ""))

                        ElseIf TextLine.ToUpper.StartsWith(",FEMALES 25-34") Then

                            LineParts = TextLine.Split(":")
                            NPRUniverse.Females25to34 = CInt(LineParts(1).Trim.ToUpper.Replace("SAMPLE SIZE", ""))
                            NPRIntab.Females25to34 = CInt(LineParts(2).Trim.ToUpper.Replace("PESS", ""))

                        ElseIf TextLine.ToUpper.StartsWith(",MALES 35-44") Then

                            LineParts = TextLine.Split(":")
                            NPRUniverse.Males35to44 = CInt(LineParts(1).Trim.ToUpper.Replace("SAMPLE SIZE", ""))
                            NPRIntab.Males35to44 = CInt(LineParts(2).Trim.ToUpper.Replace("PESS", ""))

                        ElseIf TextLine.ToUpper.StartsWith(",FEMALES 35-44") Then

                            LineParts = TextLine.Split(":")
                            NPRUniverse.Females35to44 = CInt(LineParts(1).Trim.ToUpper.Replace("SAMPLE SIZE", ""))
                            NPRIntab.Females35to44 = CInt(LineParts(2).Trim.ToUpper.Replace("PESS", ""))

                        ElseIf TextLine.ToUpper.StartsWith(",MALES 45-49") Then

                            LineParts = TextLine.Split(":")
                            NPRUniverse.Males45to49 = CInt(LineParts(1).Trim.ToUpper.Replace("SAMPLE SIZE", ""))
                            NPRIntab.Males45to49 = CInt(LineParts(2).Trim.ToUpper.Replace("PESS", ""))

                        ElseIf TextLine.ToUpper.StartsWith(",FEMALES 45-49") Then

                            LineParts = TextLine.Split(":")
                            NPRUniverse.Females45to49 = CInt(LineParts(1).Trim.ToUpper.Replace("SAMPLE SIZE", ""))
                            NPRIntab.Females45to49 = CInt(LineParts(2).Trim.ToUpper.Replace("PESS", ""))

                        ElseIf TextLine.ToUpper.StartsWith(",MALES 50-54") Then

                            LineParts = TextLine.Split(":")
                            NPRUniverse.Males50to54 = CInt(LineParts(1).Trim.ToUpper.Replace("SAMPLE SIZE", ""))
                            NPRIntab.Males50to54 = CInt(LineParts(2).Trim.ToUpper.Replace("PESS", ""))

                        ElseIf TextLine.ToUpper.StartsWith(",FEMALES 50-54") Then

                            LineParts = TextLine.Split(":")
                            NPRUniverse.Females50to54 = CInt(LineParts(1).Trim.ToUpper.Replace("SAMPLE SIZE", ""))
                            NPRIntab.Females50to54 = CInt(LineParts(2).Trim.ToUpper.Replace("PESS", ""))

                        ElseIf TextLine.ToUpper.StartsWith(",MALES 55-64") Then

                            LineParts = TextLine.Split(":")
                            NPRUniverse.Males55to64 = CInt(LineParts(1).Trim.ToUpper.Replace("SAMPLE SIZE", ""))
                            NPRIntab.Males55to64 = CInt(LineParts(2).Trim.ToUpper.Replace("PESS", ""))

                        ElseIf TextLine.ToUpper.StartsWith(",FEMALES 55-64") Then

                            LineParts = TextLine.Split(":")
                            NPRUniverse.Females55to64 = CInt(LineParts(1).Trim.ToUpper.Replace("SAMPLE SIZE", ""))
                            NPRIntab.Females55to64 = CInt(LineParts(2).Trim.ToUpper.Replace("PESS", ""))

                        ElseIf TextLine.ToUpper.StartsWith(",MALES 65+") Then

                            LineParts = TextLine.Split(":")
                            NPRUniverse.Males65Plus = CInt(LineParts(1).Trim.ToUpper.Replace("SAMPLE SIZE", ""))
                            NPRIntab.Males65Plus = CInt(LineParts(2).Trim.ToUpper.Replace("PESS", ""))

                        ElseIf TextLine.ToUpper.StartsWith(",FEMALES 65+") Then

                            LineParts = TextLine.Split(":")
                            NPRUniverse.Females65Plus = CInt(LineParts(1).Trim.ToUpper.Replace("SAMPLE SIZE", ""))
                            NPRIntab.Females65Plus = CInt(LineParts(2).Trim.ToUpper.Replace("PESS", ""))

                        ElseIf TextLine.ToUpper.StartsWith(",WW 30HRS+") Then

                            LineParts = TextLine.Split(":")
                            NPRUniverse.WorkingWomen = CInt(LineParts(1).Trim.ToUpper.Replace("SAMPLE SIZE", ""))
                            NPRIntab.WorkingWomen = CInt(LineParts(2).Trim.ToUpper.Replace("PESS", ""))

                        End If

                    Loop

                    DbContext.NPRUniverses.Add(NPRUniverse)
                    DbContext.NPRIntabs.Add(NPRIntab)

                    DbContext.SaveChanges()

                    DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.NPR_FILE SET PROCESSED_TIME = getdate() WHERE NPR_FILE_ID = {0}", NPRFile.ID))

                    DbTransaction.Commit()

                    Processed = True

                Catch ex As Exception
                    DbTransaction.Rollback()
                    Throw New Exception(ex.Message & " " & NPRFile.FileName)
                Finally
                    DbContext.Configuration.AutoDetectChangesEnabled = True
                    DbContext.Database.Connection.Close()
                End Try

            End If

            ProcessFile = Processed

        End Function
        Public Function ImportData(DbContext As AdvantageFramework.Database.DbContext, LocalPath As String, ByRef ErrorMessage As String) As Boolean

            Dim Downloaded As Boolean = False
            Dim Directories As Generic.List(Of String) = Nothing
            Dim AvailableFiles As Generic.List(Of String) = Nothing
            Dim DownloadedFiles As Generic.List(Of String) = Nothing
            Dim NPRFile As AdvantageFramework.Database.Entities.NPRFile = Nothing
            Dim NPRFileNames As Generic.List(Of String) = Nothing
            Dim NPRFiles As Generic.List(Of AdvantageFramework.Database.Entities.NPRFile) = Nothing
            Dim FileStream As System.IO.FileStream = Nothing
            Dim SftpExceptionStatus As Rebex.Net.SftpExceptionStatus = Nothing
            Dim SFtpExceptionMessage As String = Nothing
            Dim NPRFileHPUT As AdvantageFramework.Database.Entities.NPRFile = Nothing
            Dim NPRHutputList As Generic.List(Of AdvantageFramework.Database.Entities.NPRHutput) = Nothing

            If AdvantageFramework.FTP.GetDirectoriesFromSFTP(NIELSEN_PUERTO_RICO_URL, 22, Rebex.Net.SslMode.None, "delacruz", "d3l@1920", "data/Advantage", LocalPath, Directories) Then

                For Each Directory In Directories

                    NPRFileNames = (From Entity In DbContext.GetQuery(Of Database.Entities.NPRFile)
                                    Select Entity.FileName).ToList

                    If AdvantageFramework.FTP.DownloadFilesFromSFTP(NIELSEN_PUERTO_RICO_URL, 22, "delacruz", "d3l@1920", "data/Advantage/" & Directory, LocalPath, DownloadedFiles, SftpExceptionStatus, SFtpExceptionMessage, NPRFileNames) Then

                        Downloaded = True

                    Else

                        ErrorMessage = "Problem downloading files from SFTP site."

                    End If

                Next

            Else

                ErrorMessage = "Could not get directories from SFTP site."

            End If

            If Downloaded Then

                'add CSV files for new format change testing
                DownloadedFiles.AddRange(System.IO.Directory.GetFiles(LocalPath, "*.csv").ToList)

                For Each DownloadedFile In DownloadedFiles

                    FileStream = IO.File.Open(DownloadedFile, IO.FileMode.Open)

                    If FileStream.Length = 0 Then

                        FileStream.Close()
                        System.IO.File.Delete(DownloadedFile)

                    Else

                        NPRFile = (From Entity In DbContext.GetQuery(Of Database.Entities.NPRFile)
                                   Where Entity.FileName = DownloadedFile
                                   Select Entity).SingleOrDefault

                        If NPRFile Is Nothing Then

                            NPRFile = New Database.Entities.NPRFile
                            NPRFile.DbContext = DbContext

                            NPRFile.FileName = DownloadedFile
                            DbContext.NPRFiles.Add(NPRFile)

                        End If

                    End If

                    FileStream.Close()

                Next

                DbContext.SaveChanges()

                NPRFiles = (From Entity In DbContext.GetQuery(Of Database.Entities.NPRFile)
                            Where Entity.ProcessedTime Is Nothing
                            Select Entity).ToList

                For Each NPRFile In NPRFiles

                    Try

                        If NPRFile.FileName.ToUpper.EndsWith(".TXT") Then

                            ProcessFile(DbContext, NPRFile)

                        ElseIf NPRFile.FileName.ToUpper.EndsWith(".CSV") Then

                            If NPRFile.FileName.ToUpper.Contains("TOTAL TV") = False Then

                                If NPRFiles.Where(Function(F) F.FileName.ToUpper = NPRFile.FileName.ToUpper.Replace(".CSV", " TOTAL TV.CSV")).Count = 1 Then

                                    NPRFileHPUT = NPRFiles.Where(Function(F) F.FileName.ToUpper = NPRFile.FileName.ToUpper.Replace(".CSV", " TOTAL TV.CSV")).Single

                                    NPRHutputList = Nothing

                                    If ProcessCSVHPUT(NPRFileHPUT, NPRHutputList) Then

                                        ProcessCSVFile(DbContext, NPRFile, NPRHutputList, NPRFileHPUT)

                                    End If

                                End If

                            End If

                        End If

                    Catch ex As Exception

                        ErrorMessage = ex.Message
                        Throw New Exception(ErrorMessage)

                    End Try

                Next

            End If

            ImportData = Downloaded

        End Function
        Private Function LoadNPRStations(DbContext As AdvantageFramework.Database.DbContext) As Generic.List(Of AdvantageFramework.Database.Entities.NPRStation)

            LoadNPRStations = (From Entity In DbContext.GetQuery(Of Database.Entities.NPRStation)
                               Select Entity).ToList

        End Function
        Private Function ProcessCSVHPUT(NPRFileHPUT As AdvantageFramework.Database.Entities.NPRFile, ByRef NPRHutputList As Generic.List(Of AdvantageFramework.Database.Entities.NPRHutput)) As Boolean

            Dim Processed As Boolean = False
            Dim TextFieldParser As FileIO.TextFieldParser = Nothing
            Dim NPRHutput As AdvantageFramework.Database.Entities.NPRHutput = Nothing
            Dim FileLineData() As String = Nothing
            Dim FileDate As Date = Nothing
            Dim Times As String() = Nothing
            Dim StartTime As TimeSpan = Nothing

            If System.IO.File.Exists(NPRFileHPUT.FileName) Then

                Try

                    If NPRHutputList Is Nothing Then

                        NPRHutputList = New Generic.List(Of AdvantageFramework.Database.Entities.NPRHutput)

                    End If

                    TextFieldParser = New FileIO.TextFieldParser(NPRFileHPUT.FileName)

                    TextFieldParser.TextFieldType = FileIO.FieldType.Delimited
                    TextFieldParser.Delimiters = {","}
                    TextFieldParser.HasFieldsEnclosedInQuotes = True

                    Do While Not TextFieldParser.EndOfData

                        Try

                            FileLineData = TextFieldParser.ReadFields

                            If FileLineData(0) = "Heading" AndAlso FileLineData(1) = "Period :" Then

                                FileDate = FileLineData(2).Trim.Replace("=", "").Replace("""", "").Trim

                            ElseIf FileLineData(0) = "Heading" AndAlso FileLineData(1) = "Daypart" Then

                                If FileLineData(4) <> "Total Households" OrElse FileLineData(5) <> "Persons 2+" OrElse FileLineData(6) <> "Males 2+" OrElse FileLineData(7) <> "Females 2+" OrElse
                                        FileLineData(8) <> "Males 2-5" OrElse FileLineData(9) <> "Females 2-5" OrElse FileLineData(10) <> "Males 6-11" OrElse FileLineData(11) <> "Females 6-11" OrElse
                                        FileLineData(12) <> "Males 12-14" OrElse FileLineData(13) <> "Females 12-14" OrElse FileLineData(14) <> "Males 15-17" OrElse FileLineData(15) <> "Females 15-17" OrElse
                                        FileLineData(16) <> "Males 18-20" OrElse FileLineData(17) <> "Females 18-20" OrElse FileLineData(18) <> "Males 21-24" OrElse FileLineData(19) <> "Females 21-24" OrElse
                                        FileLineData(20) <> "Males 25-34" OrElse FileLineData(21) <> "Females 25-34" OrElse FileLineData(22) <> "Males 35-44" OrElse FileLineData(23) <> "Females 35-44" OrElse
                                        FileLineData(24) <> "Males 45-49" OrElse FileLineData(25) <> "Females 45-49" OrElse FileLineData(26) <> "Males 50-54" OrElse FileLineData(27) <> "Females 50-54" OrElse
                                        FileLineData(28) <> "Males 55-64" OrElse FileLineData(29) <> "Females 55-64" OrElse FileLineData(30) <> "Males 65+" OrElse FileLineData(31) <> "Females 65+" Then

                                    Throw New Exception("Invalid headings in file: " * NPRFileHPUT.FileName)

                                End If

                            ElseIf FileLineData(0) = "Data" AndAlso FileLineData(2) = "Total TV" Then

                                NPRHutput = New AdvantageFramework.Database.Entities.NPRHutput

                                Times = FileLineData(3).Split("-")

                                If Times(0).ToLower.Contains("am") Then

                                    StartTime = TimeSpan.Parse(Times(0).ToLower.Replace("am", "").Trim)

                                    If StartTime.Hours = 12 Then

                                        StartTime = StartTime.Add(New TimeSpan(-12, 0, 0))

                                    End If

                                Else

                                    StartTime = TimeSpan.Parse(Times(0).ToLower.Replace("pm", "").Trim)

                                    If StartTime.Hours <> 12 Then

                                        StartTime = StartTime.Add(New TimeSpan(12, 0, 0))

                                    End If

                                End If

                                If StartTime.Hours = 0 OrElse StartTime.Hours = 1 Then

                                    NPRHutput.[Date] = FileDate.AddDays(1).AddTicks(StartTime.Ticks)

                                Else

                                    NPRHutput.[Date] = FileDate.AddTicks(StartTime.Ticks)

                                End If

                                NPRHutput.Homes = CInt(FileLineData(4))
                                NPRHutput.People2Plus = CInt(FileLineData(5))
                                NPRHutput.Males2Plus = CInt(FileLineData(6))
                                NPRHutput.Females2Plus = CInt(FileLineData(7))
                                NPRHutput.Males2to5 = CInt(FileLineData(8))
                                NPRHutput.Females2to5 = CInt(FileLineData(9))
                                NPRHutput.Males6to11 = CInt(FileLineData(10))
                                NPRHutput.Females6to11 = CInt(FileLineData(11))
                                NPRHutput.Males12to14 = CInt(FileLineData(12))
                                NPRHutput.Females12to14 = CInt(FileLineData(13))
                                NPRHutput.Males15to17 = CInt(FileLineData(14))
                                NPRHutput.Females15to17 = CInt(FileLineData(15))
                                NPRHutput.Males18to20 = CInt(FileLineData(16))
                                NPRHutput.Females18to20 = CInt(FileLineData(17))
                                NPRHutput.Males21to24 = CInt(FileLineData(18))
                                NPRHutput.Females21to24 = CInt(FileLineData(19))
                                NPRHutput.Males25to34 = CInt(FileLineData(20))
                                NPRHutput.Females25to34 = CInt(FileLineData(21))
                                NPRHutput.Males35to44 = CInt(FileLineData(22))
                                NPRHutput.Females35to44 = CInt(FileLineData(23))
                                NPRHutput.Males45to49 = CInt(FileLineData(24))
                                NPRHutput.Females45to49 = CInt(FileLineData(25))
                                NPRHutput.Males50to54 = CInt(FileLineData(26))
                                NPRHutput.Females50to54 = CInt(FileLineData(27))
                                NPRHutput.Males55to64 = CInt(FileLineData(28))
                                NPRHutput.Females55to64 = CInt(FileLineData(29))
                                NPRHutput.Males65Plus = CInt(FileLineData(30))
                                NPRHutput.Females65Plus = CInt(FileLineData(31))

                                NPRHutput.WorkingWomen = 0

                                NPRHutputList.Add(NPRHutput)

                            End If

                        Catch ex As Exception
                            TextFieldParser.Close()
                            TextFieldParser.Dispose()
                            Throw ex
                        End Try

                    Loop

                    Processed = True

                Catch ex As Exception
                    Throw ex
                End Try

            End If

            ProcessCSVHPUT = Processed

        End Function
        Private Function ProcessCSVFile(DbContext As AdvantageFramework.Database.DbContext, NPRFile As AdvantageFramework.Database.Entities.NPRFile,
                                        NPRHutputList As Generic.List(Of AdvantageFramework.Database.Entities.NPRHutput),
                                        NPRFileHPUT As AdvantageFramework.Database.Entities.NPRFile) As Boolean

            Dim TextFieldParser As FileIO.TextFieldParser = Nothing
            Dim NPRUniverse As AdvantageFramework.Database.Entities.NPRUniverse = Nothing
            Dim NPRIntab As AdvantageFramework.Database.Entities.NPRIntab = Nothing
            Dim FileLineData() As String = Nothing
            Dim FileDate As Date = Nothing
            Dim HeadingSummaryFound As Boolean = False
            Dim NPRAudienceList As Generic.List(Of AdvantageFramework.Database.Entities.NPRAudience) = Nothing
            Dim NPRStations As Generic.List(Of AdvantageFramework.Database.Entities.NPRStation) = Nothing
            Dim NPRAudience As AdvantageFramework.Database.Entities.NPRAudience = Nothing
            Dim NPRStation As AdvantageFramework.Database.Entities.NPRStation = Nothing
            Dim Times As String() = Nothing
            Dim StartTime As TimeSpan = Nothing
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim Processed As Boolean = False

            If System.IO.File.Exists(NPRFile.FileName) Then

                Try

                    TextFieldParser = New FileIO.TextFieldParser(NPRFile.FileName)

                    TextFieldParser.TextFieldType = FileIO.FieldType.Delimited
                    TextFieldParser.Delimiters = {","}
                    TextFieldParser.HasFieldsEnclosedInQuotes = True

                    NPRUniverse = New AdvantageFramework.Database.Entities.NPRUniverse
                    NPRUniverse.DbContext = DbContext

                    NPRIntab = New AdvantageFramework.Database.Entities.NPRIntab
                    NPRIntab.DbContext = DbContext

                    NPRAudienceList = New Generic.List(Of AdvantageFramework.Database.Entities.NPRAudience)

                    NPRStations = LoadNPRStations(DbContext)

                    DbContext.Configuration.AutoDetectChangesEnabled = False

                    Do While Not TextFieldParser.EndOfData

                        Try

                            FileLineData = TextFieldParser.ReadFields

                            If FileLineData(0) = "Heading" AndAlso FileLineData(1) = "Period :" Then

                                FileDate = FileLineData(2).Trim.Replace("=", "").Replace("""", "").Trim

                                NPRUniverse.Date = FileDate
                                NPRIntab.Date = FileDate

                            ElseIf FileLineData(0) = "Heading" AndAlso FileLineData(1) = "Daypart" Then

                                If FileLineData(4) <> "Total Households" OrElse FileLineData(5) <> "Persons 2+" OrElse FileLineData(6) <> "Males 2+" OrElse FileLineData(7) <> "Females 2+" OrElse
                                        FileLineData(8) <> "Males 2-5" OrElse FileLineData(9) <> "Females 2-5" OrElse FileLineData(10) <> "Males 6-11" OrElse FileLineData(11) <> "Females 6-11" OrElse
                                        FileLineData(12) <> "Males 12-14" OrElse FileLineData(13) <> "Females 12-14" OrElse FileLineData(14) <> "Males 15-17" OrElse FileLineData(15) <> "Females 15-17" OrElse
                                        FileLineData(16) <> "Males 18-20" OrElse FileLineData(17) <> "Females 18-20" OrElse FileLineData(18) <> "Males 21-24" OrElse FileLineData(19) <> "Females 21-24" OrElse
                                        FileLineData(20) <> "Males 25-34" OrElse FileLineData(21) <> "Females 25-34" OrElse FileLineData(22) <> "Males 35-44" OrElse FileLineData(23) <> "Females 35-44" OrElse
                                        FileLineData(24) <> "Males 45-49" OrElse FileLineData(25) <> "Females 45-49" OrElse FileLineData(26) <> "Males 50-54" OrElse FileLineData(27) <> "Females 50-54" OrElse
                                        FileLineData(28) <> "Males 55-64" OrElse FileLineData(29) <> "Females 55-64" OrElse FileLineData(30) <> "Males 65+" OrElse FileLineData(31) <> "Females 65+" OrElse
                                        FileLineData(32) <> "Total Households" OrElse FileLineData(33) <> "Persons 2+" OrElse FileLineData(34) <> "Males 2+" OrElse FileLineData(35) <> "Females 2+" OrElse
                                        FileLineData(36) <> "Males 2-5" OrElse FileLineData(37) <> "Females 2-5" OrElse FileLineData(38) <> "Males 6-11" OrElse FileLineData(39) <> "Females 6-11" OrElse
                                        FileLineData(40) <> "Males 12-14" OrElse FileLineData(41) <> "Females 12-14" OrElse FileLineData(42) <> "Males 15-17" OrElse FileLineData(43) <> "Females 15-17" OrElse
                                        FileLineData(44) <> "Males 18-20" OrElse FileLineData(45) <> "Females 18-20" OrElse FileLineData(46) <> "Males 21-24" OrElse FileLineData(47) <> "Females 21-24" OrElse
                                        FileLineData(48) <> "Males 25-34" OrElse FileLineData(49) <> "Females 25-34" OrElse FileLineData(50) <> "Males 35-44" OrElse FileLineData(51) <> "Females 35-44" OrElse
                                        FileLineData(52) <> "Males 45-49" OrElse FileLineData(53) <> "Females 45-49" OrElse FileLineData(54) <> "Males 50-54" OrElse FileLineData(55) <> "Females 50-54" OrElse
                                        FileLineData(56) <> "Males 55-64" OrElse FileLineData(57) <> "Females 55-64" OrElse FileLineData(58) <> "Males 65+" OrElse FileLineData(59) <> "Females 65+" Then

                                    Throw New Exception("Invalid headings in file: " * NPRFile.FileName)

                                End If

                            ElseIf FileLineData(0) = "Heading" AndAlso FileLineData(1) = "Summary" Then

                                HeadingSummaryFound = True

                            ElseIf FileLineData(0) = "Data" AndAlso HeadingSummaryFound Then

                                Select Case FileLineData(1)

                                    Case "Total Households"

                                        NPRUniverse.Homes = CInt(FileLineData(3))
                                        NPRIntab.Homes = CInt(FileLineData(4))

                                    Case "Persons 2+"

                                        NPRUniverse.People2Plus = CInt(FileLineData(3))
                                        NPRIntab.People2Plus = CInt(FileLineData(4))

                                    Case "Males 2+"

                                        NPRUniverse.Males2Plus = CInt(FileLineData(3))
                                        NPRIntab.Males2Plus = CInt(FileLineData(4))

                                    Case "Females 2+"

                                        NPRUniverse.Females2Plus = CInt(FileLineData(3))
                                        NPRIntab.Females2Plus = CInt(FileLineData(4))

                                    Case "Males 2-5"

                                        NPRUniverse.Males2to5 = CInt(FileLineData(3))
                                        NPRIntab.Males2to5 = CInt(FileLineData(4))

                                    Case "Females 2-5"

                                        NPRUniverse.Females2to5 = CInt(FileLineData(3))
                                        NPRIntab.Females2to5 = CInt(FileLineData(4))

                                    Case "Males 6-11"

                                        NPRUniverse.Males6to11 = CInt(FileLineData(3))
                                        NPRIntab.Males6to11 = CInt(FileLineData(4))

                                    Case "Females 6-11"

                                        NPRUniverse.Females6to11 = CInt(FileLineData(3))
                                        NPRIntab.Females6to11 = CInt(FileLineData(4))

                                    Case "Males 12-14"

                                        NPRUniverse.Males12to14 = CInt(FileLineData(3))
                                        NPRIntab.Males12to14 = CInt(FileLineData(4))

                                    Case "Females 12-14"

                                        NPRUniverse.Females12to14 = CInt(FileLineData(3))
                                        NPRIntab.Females12to14 = CInt(FileLineData(4))

                                    Case "Males 15-17"

                                        NPRUniverse.Males15to17 = CInt(FileLineData(3))
                                        NPRIntab.Males15to17 = CInt(FileLineData(4))

                                    Case "Females 15-17"

                                        NPRUniverse.Females15to17 = CInt(FileLineData(3))
                                        NPRIntab.Females15to17 = CInt(FileLineData(4))

                                    Case "Males 18-20"

                                        NPRUniverse.Males18to20 = CInt(FileLineData(3))
                                        NPRIntab.Males18to20 = CInt(FileLineData(4))

                                    Case "Females 18-20"

                                        NPRUniverse.Females18to20 = CInt(FileLineData(3))
                                        NPRIntab.Females18to20 = CInt(FileLineData(4))

                                    Case "Males 21-24"

                                        NPRUniverse.Males21to24 = CInt(FileLineData(3))
                                        NPRIntab.Males21to24 = CInt(FileLineData(4))

                                    Case "Females 21-24"

                                        NPRUniverse.Females21to24 = CInt(FileLineData(3))
                                        NPRIntab.Females21to24 = CInt(FileLineData(4))

                                    Case "Males 25-34"

                                        NPRUniverse.Males25to34 = CInt(FileLineData(3))
                                        NPRIntab.Males25to34 = CInt(FileLineData(4))

                                    Case "Females 25-34"

                                        NPRUniverse.Females25to34 = CInt(FileLineData(3))
                                        NPRIntab.Females25to34 = CInt(FileLineData(4))

                                    Case "Males 35-44"

                                        NPRUniverse.Males35to44 = CInt(FileLineData(3))
                                        NPRIntab.Males35to44 = CInt(FileLineData(4))

                                    Case "Females 35-44"

                                        NPRUniverse.Females35to44 = CInt(FileLineData(3))
                                        NPRIntab.Females35to44 = CInt(FileLineData(4))

                                    Case "Males 45-49"

                                        NPRUniverse.Males45to49 = CInt(FileLineData(3))
                                        NPRIntab.Males45to49 = CInt(FileLineData(4))

                                    Case "Females 45-49"

                                        NPRUniverse.Females45to49 = CInt(FileLineData(3))
                                        NPRIntab.Females45to49 = CInt(FileLineData(4))

                                    Case "Males 50-54"

                                        NPRUniverse.Males50to54 = CInt(FileLineData(3))
                                        NPRIntab.Males50to54 = CInt(FileLineData(4))

                                    Case "Females 50-54"

                                        NPRUniverse.Females50to54 = CInt(FileLineData(3))
                                        NPRIntab.Females50to54 = CInt(FileLineData(4))

                                    Case "Males 55-64"

                                        NPRUniverse.Males55to64 = CInt(FileLineData(3))
                                        NPRIntab.Males55to64 = CInt(FileLineData(4))

                                    Case "Females 55-64"

                                        NPRUniverse.Females55to64 = CInt(FileLineData(3))
                                        NPRIntab.Females55to64 = CInt(FileLineData(4))

                                    Case "Males 65+"

                                        NPRUniverse.Males65Plus = CInt(FileLineData(3))
                                        NPRIntab.Males65Plus = CInt(FileLineData(4))

                                    Case "Females 65+"

                                        NPRUniverse.Females65Plus = CInt(FileLineData(3))
                                        NPRIntab.Females65Plus = CInt(FileLineData(4))

                                End Select

                            ElseIf FileLineData(0) = "Data" AndAlso FileLineData.Length > 10 Then

                                NPRAudience = New AdvantageFramework.Database.Entities.NPRAudience
                                NPRAudience.DbContext = DbContext

                                If (From Entity In NPRStations
                                    Where Entity.Name.ToUpper = FileLineData(2).ToUpper
                                    Select Entity.ID).Any Then

                                    NPRAudience.NPRStationID = (From Entity In NPRStations
                                                                Where Entity.Name.ToUpper = FileLineData(2).ToUpper
                                                                Select Entity.ID).First

                                Else

                                    NPRStation = New AdvantageFramework.Database.Entities.NPRStation
                                    NPRStation.DbContext = DbContext
                                    NPRStation.Name = FileLineData(2).ToUpper

                                    DbContext.NPRStations.Add(NPRStation)
                                    DbContext.SaveChanges()

                                    NPRAudience.NPRStationID = NPRStation.ID

                                    NPRStations = LoadNPRStations(DbContext)

                                End If

                                Times = FileLineData(3).Split("-")

                                If Times(0).ToLower.Contains("am") Then

                                    StartTime = TimeSpan.Parse(Times(0).ToLower.Replace("am", "").Trim)

                                    If StartTime.Hours = 12 Then

                                        StartTime = StartTime.Add(New TimeSpan(-12, 0, 0))

                                    End If

                                Else

                                    StartTime = TimeSpan.Parse(Times(0).ToLower.Replace("pm", "").Trim)

                                    If StartTime.Hours <> 12 Then

                                        StartTime = StartTime.Add(New TimeSpan(12, 0, 0))

                                    End If

                                End If

                                If StartTime.Hours = 0 OrElse StartTime.Hours = 1 Then

                                    NPRAudience.[Date] = FileDate.AddDays(1).AddTicks(StartTime.Ticks)

                                Else

                                    NPRAudience.[Date] = FileDate.AddTicks(StartTime.Ticks)

                                End If

                                NPRAudience.Homes = CInt(FileLineData(4))
                                NPRAudience.People2Plus = CInt(FileLineData(5))
                                NPRAudience.Males2Plus = CInt(FileLineData(6))
                                NPRAudience.Females2Plus = CInt(FileLineData(7))
                                NPRAudience.Males2to5 = CInt(FileLineData(8))
                                NPRAudience.Females2to5 = CInt(FileLineData(9))
                                NPRAudience.Males6to11 = CInt(FileLineData(10))
                                NPRAudience.Females6to11 = CInt(FileLineData(11))
                                NPRAudience.Males12to14 = CInt(FileLineData(12))
                                NPRAudience.Females12to14 = CInt(FileLineData(13))
                                NPRAudience.Males15to17 = CInt(FileLineData(14))
                                NPRAudience.Females15to17 = CInt(FileLineData(15))
                                NPRAudience.Males18to20 = CInt(FileLineData(16))
                                NPRAudience.Females18to20 = CInt(FileLineData(17))
                                NPRAudience.Males21to24 = CInt(FileLineData(18))
                                NPRAudience.Females21to24 = CInt(FileLineData(19))
                                NPRAudience.Males25to34 = CInt(FileLineData(20))
                                NPRAudience.Females25to34 = CInt(FileLineData(21))
                                NPRAudience.Males35to44 = CInt(FileLineData(22))
                                NPRAudience.Females35to44 = CInt(FileLineData(23))
                                NPRAudience.Males45to49 = CInt(FileLineData(24))
                                NPRAudience.Females45to49 = CInt(FileLineData(25))
                                NPRAudience.Males50to54 = CInt(FileLineData(26))
                                NPRAudience.Females50to54 = CInt(FileLineData(27))
                                NPRAudience.Males55to64 = CInt(FileLineData(28))
                                NPRAudience.Females55to64 = CInt(FileLineData(29))
                                NPRAudience.Males65Plus = CInt(FileLineData(30))
                                NPRAudience.Females65Plus = CInt(FileLineData(31))
                                NPRAudience.ProgramName = Mid(FileLineData(32), 1, 100)

                                NPRAudience.WorkingWomen = 0

                                NPRAudienceList.Add(NPRAudience)

                            End If

                        Catch ex As Exception
                            TextFieldParser.Close()
                            TextFieldParser.Dispose()
                            Throw ex
                        End Try

                    Loop

                    DbContext.Database.Connection.Open()

                    DbTransaction = DbContext.Database.BeginTransaction

                    DbContext.NPRUniverses.Add(NPRUniverse)
                    DbContext.NPRIntabs.Add(NPRIntab)

                    For Each NPRAudience In NPRAudienceList

                        DbContext.NPRAudiences.Add(NPRAudience)

                    Next

                    For Each NPRHutput In NPRHutputList

                        NPRHutput.DbContext = DbContext
                        DbContext.NPRHutputs.Add(NPRHutput)

                    Next

                    DbContext.SaveChanges()

                    DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.NPR_FILE SET PROCESSED_TIME = getdate() WHERE NPR_FILE_ID = {0}", NPRFile.ID))
                    DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.NPR_FILE SET PROCESSED_TIME = getdate() WHERE NPR_FILE_ID = {0}", NPRFileHPUT.ID))

                    DbTransaction.Commit()

                    Processed = True

                Catch ex As Exception
                    DbTransaction.Rollback()
                    Throw New Exception(ex.Message & " " & NPRFile.FileName)
                Finally
                    DbContext.Configuration.AutoDetectChangesEnabled = True
                    DbContext.Database.Connection.Close()
                End Try

            End If

            ProcessCSVFile = Processed

        End Function

#End Region

#End Region

    End Module

End Namespace

