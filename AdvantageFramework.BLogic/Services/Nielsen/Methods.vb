Namespace Services.Nielsen

    <HideModuleName()>
    Public Module Methods

        Public Event EntryLogWrittenEvent(ByVal EventLogEntry As System.Diagnostics.EventLogEntry)

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum RegistrySetting
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\Nielsen\", "RunAt", "01/01/2001 01:00 AM")>
            RunAt
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\Nielsen\", "EmployeeCode", "")>
            EmployeeCode
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

                AdvantageFramework.AlertSystem.CreateAlertForNonHostedNielsenDataImport(DatabaseProfile, EmployeeCode)

            End If

        End Sub
        Public Sub ProcessDatabase(ByRef DatabaseProfile As AdvantageFramework.Database.DatabaseProfile)

            'objects
            Dim Session As AdvantageFramework.Security.Session = Nothing
            Dim ClientCode As String = Nothing
            Dim EmployeeCode As String = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim EmployeeIsValid As Boolean = True
            'Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim Timeout As Integer = 0
            Dim NielsenTVBookRevisions As Generic.List(Of AdvantageFramework.DTO.Nielsen.NielsenTVBookRevision) = Nothing
            Dim NielsenRadioPeriodRevisions As Generic.List(Of AdvantageFramework.DTO.Nielsen.NielsenRadioPeriodRevision) = Nothing

            Try

                If DatabaseProfile IsNot Nothing AndAlso _IsRunning = False Then

                    _IsRunning = True

                    WriteToEventLog("Nielsen connecting to database --> " & DatabaseProfile.DatabaseName)

                    Session = New AdvantageFramework.Security.Session(Security.Application.Advantage, DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName, 0, DatabaseProfile.ConnectionString)

                    Using DataContext = New AdvantageFramework.Database.DataContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                        Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                            WriteToEventLog("Nielsen load service settings --> " & DatabaseProfile.DatabaseName)

                            AdvantageFramework.Services.Nielsen.LoadSettings(DataContext, Nothing, EmployeeCode)

                            WriteToEventLog("Validating Employee/User...")

                            Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode)

                            If Employee Is Nothing OrElse Employee.TerminationDate IsNot Nothing OrElse String.IsNullOrWhiteSpace(Employee.Email) Then

                                WriteToEventLog("Employee does not exist, or has been terminated or does not have email address.  EmployeeCode (" & EmployeeCode & ")")
                                EmployeeIsValid = False

                            End If

                            'Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.NIELSEN_SVC_TIMEOUT.ToString)

                            'If Setting IsNot Nothing AndAlso IsNumeric(Setting.Value) Then

                            '    Timeout = CInt(Setting.Value)

                            'End If

                            WriteToEventLog("Timeout set to " & Timeout.ToString & " milliseconds")

                            If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) Then

                                Using NielsenDBContext = New AdvantageFramework.Nielsen.Database.DbContext(Session.NielsenConnectionString, Nothing)

                                    WriteToEventLog("Nielsen --> load tv book revisions.")

                                    Try

                                        NielsenTVBookRevisions = NielsenDBContext.Database.SqlQuery(Of AdvantageFramework.DTO.Nielsen.NielsenTVBookRevision)("EXEC dbo.advsp_hosted_tv_books_revisions_load").ToList

                                    Catch ex As Exception
                                        NielsenTVBookRevisions = Nothing
                                    End Try

                                    If NielsenTVBookRevisions IsNot Nothing Then

                                        For Each NielsenTVBookRevision In NielsenTVBookRevisions

                                            DbContext.Database.ExecuteSqlCommand(String.Format("exec dbo.advsp_nielsen_tv_book_replace {0}, {1}", NielsenTVBookRevision.OldNielsenTVBookID, NielsenTVBookRevision.NewNielsenTVBookID))

                                        Next

                                    Else

                                        WriteToEventLog("Nielsen --> no tv book revisions.")

                                    End If

                                    WriteToEventLog("Nielsen --> load radio period revisions.")

                                    Try

                                        NielsenRadioPeriodRevisions = NielsenDBContext.Database.SqlQuery(Of AdvantageFramework.DTO.Nielsen.NielsenRadioPeriodRevision)("EXEC dbo.advsp_hosted_radio_period_revisions_load").ToList

                                    Catch ex As Exception
                                        NielsenRadioPeriodRevisions = Nothing
                                    End Try

                                    If NielsenRadioPeriodRevisions IsNot Nothing Then

                                        For Each NielsenRadioPeriodRevision In NielsenRadioPeriodRevisions

                                            DbContext.Database.ExecuteSqlCommand(String.Format("exec dbo.advsp_nielsen_radio_period_replace {0}, {1}", NielsenRadioPeriodRevision.OldNielsenRadioPeriodID, NielsenRadioPeriodRevision.NewNielsenRadioPeriodID))

                                        Next

                                    Else

                                        WriteToEventLog("Nielsen --> no radio period revisions.")

                                    End If

                                End Using

                            ElseIf Session.NielsenConnectionString.ToUpper.Contains("NIELSENHOSTED") Then

                                WriteToEventLog("Nielsen --> Cannot update data for database NIELSENHOSTED.")

                            Else

                                WriteToEventLog("Nielsen getting client code")

                                ClientCode = Session.GetNielsenClientCodeForNonHosted(DbContext)

                                If String.IsNullOrWhiteSpace(ClientCode) Then

                                    WriteToEventLog("Nielsen - Could not find authorized client code.")

                                    SendFailureEmail(DatabaseProfile, EmployeeIsValid, EmployeeCode)

                                Else

                                    WriteToEventLog("Nielsen GetData")

                                    AdvantageFramework.NielsenWebService.GetData(Session.NielsenConnectionString, ClientCode, DatabaseProfile, EmployeeCode, Timeout)

                                    WriteToEventLog("Nielsen GetData complete")

                                End If

                            End If

                        End Using

                    End Using

                End If

            Catch ex As Exception

                If String.IsNullOrWhiteSpace(ex.Message) Then

                    WriteToEventLog("Nielsen Error Processing - TIMEOUT --> " & ex.StackTrace & ":" & DatabaseProfile.DatabaseName)

                Else

                    WriteToEventLog("Nielsen Error Processing - " & ex.Message & " --> " & DatabaseProfile.DatabaseName)

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

                                DateTime.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.Nielsen.RegistrySetting.RunAt), RunAt)

                                If RunAt = CDate("01/01/2001 01:00 AM") Then

                                    RunAt = Now.ToShortDateString & " " & RunAt.ToShortTimeString

                                End If

                                If DateDiff(DateInterval.Minute, RunAt, Now) >= 0 Then

                                    RunAt = Now.AddDays(1).ToShortDateString & " " & RunAt.ToShortTimeString

                                    SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.Nielsen.RegistrySetting.RunAt, RunAt)

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

            If System.Diagnostics.EventLog.SourceExists("Nielsen Source") = False Then

                System.Diagnostics.EventLog.CreateEventSource("Nielsen Source", "Nielsen Log")

            End If

            _EventLog = New System.Diagnostics.EventLog("Nielsen Log", My.Computer.Name, "Nielsen Source")

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

                AdvantageService = AdvantageFramework.Services.LoadAdvantageService(DataContext, AdvantageFramework.Services.Service.AdvantageNielsenWindowsService)

            Catch ex As Exception
                AdvantageService = Nothing
            End Try

            LoadAdvantageService = AdvantageService

        End Function
        Public Function LoadAdvantageServiceSetting(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AdvantageServiceID As Integer, ByVal RegistrySetting As AdvantageFramework.Services.Nielsen.RegistrySetting) As AdvantageFramework.Database.Entities.AdvantageServiceSetting

            'objects
            Dim AdvantageServiceSetting As AdvantageFramework.Database.Entities.AdvantageServiceSetting = Nothing

            Try

                AdvantageServiceSetting = AdvantageFramework.Services.LoadAdvantageServiceSetting(DataContext, AdvantageServiceID, RegistrySetting.ToString)

            Catch ex As Exception
                AdvantageServiceSetting = Nothing
            End Try

            LoadAdvantageServiceSetting = AdvantageServiceSetting

        End Function
        Public Function LoadAdvantageServiceSettingValue(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AdvantageServiceID As Integer, ByVal RegistrySetting As AdvantageFramework.Services.Nielsen.RegistrySetting) As Object

            'objects
            Dim SettingValue As Object = Nothing

            Try

                SettingValue = AdvantageFramework.Services.LoadAdvantageServiceSettingValue(DataContext, AdvantageServiceID, RegistrySetting.ToString)

            Catch ex As Exception
                SettingValue = Nothing
            End Try

            LoadAdvantageServiceSettingValue = SettingValue

        End Function
        Public Function SaveAdvantageServiceSettingValue(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AdvantageServiceID As Integer, ByVal RegistrySetting As AdvantageFramework.Services.Nielsen.RegistrySetting, ByVal SettingValue As Object) As Boolean

            'objects
            Dim Saved As Boolean = False

            Try

                Saved = AdvantageFramework.Services.SaveAdvantageServiceSettingValue(DataContext, AdvantageServiceID, RegistrySetting.ToString, SettingValue)

            Catch ex As Exception
                Saved = False
            End Try

            SaveAdvantageServiceSettingValue = Saved

        End Function
        Public Sub LoadSettings(ByVal DataContext As AdvantageFramework.Database.DataContext, ByRef RunAt As Date, ByRef EmployeeCode As String)

            'objects
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing

            AdvantageService = LoadAdvantageService(DataContext)

            If AdvantageService IsNot Nothing Then

                DateTime.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.Nielsen.RegistrySetting.RunAt), RunAt)

                EmployeeCode = LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.Nielsen.RegistrySetting.EmployeeCode)

            End If

        End Sub
        Public Sub SaveSettings(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal RunAt As DateTime, EmployeeCode As String)

            'objects
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing

            AdvantageService = LoadAdvantageService(DataContext)

            If AdvantageService IsNot Nothing Then

                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.Nielsen.RegistrySetting.RunAt, RunAt)
                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.Nielsen.RegistrySetting.EmployeeCode, EmployeeCode)

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

#End Region

    End Module

End Namespace

