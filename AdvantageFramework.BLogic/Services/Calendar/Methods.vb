Namespace Services.Calendar

    <HideModuleName()>
    Public Module Methods

        Public Event EntryLogWrittenEvent(ByVal EventLogEntry As System.Diagnostics.EventLogEntry)

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum RegistrySetting
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\Calendar\", "RunAtEvery", "5")>
            RunAtEvery
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\Calendar\", "LastRanAt", "01/01/2001 01:00 AM")>
            LastRanAt
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
        Public Sub ProcessGoogleCalendar(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext,
                                            ByVal Agency As AdvantageFramework.Database.Entities.Agency, ByVal LastRanAt As Date, ByVal Employee As AdvantageFramework.Database.Views.Employee, ByVal UseWindowsAuthentication As Boolean)

            AdvantageFramework.GoogleServices.Service.ProcessGoogleCalendar(DbContext, Agency.StandardHours.GetValueOrDefault(0), Employee.Code, False, UseWindowsAuthentication)

        End Sub
        Public Sub ProcessGoogleCalendarTS(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext,
                                            ByVal Agency As AdvantageFramework.Database.Entities.Agency, ByVal LastRanAt As Date, ByVal Employee As AdvantageFramework.Database.Views.Employee, ByVal UseWindowsAuthentication As Boolean, ByVal PastDays As Integer, ByVal StartDate As DateTime, ByVal EndDate As DateTime, ByVal RTOnly As Boolean, ByRef ErrorMessage As String)

            AdvantageFramework.GoogleServices.Service.ProcessGoogleCalendarTS(DbContext, Agency.StandardHours.GetValueOrDefault(0), Employee.Code, False, UseWindowsAuthentication, PastDays, StartDate, EndDate, RTOnly, ErrorMessage)

        End Sub
        Public Sub ProcessSugarCalendar(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext,
                                        ByVal Agency As AdvantageFramework.Database.Entities.Agency, ByVal LastRanAt As Date, ByVal Employee As AdvantageFramework.Database.Views.Employee)

            'objects
            Dim SugarCRMUrl As String = ""
            Dim SugarClient As SugarCRMRef.sugarsoap = Nothing
            Dim SugarUser As SugarCRMRef.user_auth = Nothing
            Dim LoginResult As SugarCRMRef.entry_value = Nothing
            Dim PropertyNames As Generic.List(Of String) = Nothing
            Dim StartDate As Date = Nothing
            Dim SugarCRMUserRelationship As SugarCRMRef.link_name_to_fields_array = Nothing
            Dim SugarCalls As SugarCRMRef.get_entry_list_result_version2 = Nothing
            Dim SugarMeetings As SugarCRMRef.get_entry_list_result_version2 = Nothing
            Dim TotalCount As Integer = 0
            Dim Count As Integer = 0

            Try

                If String.IsNullOrWhiteSpace(Employee.SugarCRMUserName) = False AndAlso String.IsNullOrWhiteSpace(Employee.SugarCRMPassword) = False Then

                    Try

                        SugarCRMUrl = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.SYNC_SUGARCRM_URL.ToString).Value

                    Catch ex As Exception
                        SugarCRMUrl = ""
                    End Try

                    If String.IsNullOrEmpty(SugarCRMUrl) = False Then

                        SugarClient = New SugarCRMRef.sugarsoap()
                        SugarClient.Timeout = 900000
                        SugarClient.Url = SugarCRMUrl
                        'SugarClient.Url = "http://localhost/ADVSugar/service/v4/soap.php"

                        SugarUser = New SugarCRMRef.user_auth

                        SugarUser.user_name = Employee.SugarCRMUserName
                        SugarUser.password = AdvantageFramework.Calendar.SugarCRM.CreateMD5Password(Employee.SugarCRMPassword)

                        LoginResult = SugarClient.login(SugarUser, "Advantage", New SugarCRMRef.name_value() {New SugarCRMRef.name_value})

                        If LoginResult.id <> "" Then

                            PropertyNames = AdvantageFramework.Calendar.SugarCRM.LoadSugarCRMPropertyNames("C")
                            StartDate = Now.AddMonths(-2)

                            SugarCRMUserRelationship = New SugarCRMRef.link_name_to_fields_array
                            SugarCRMUserRelationship.name = "users"
                            SugarCRMUserRelationship.value = New String() {AdvantageFramework.Calendar.SugarCRM.UserProperties.id.ToString, AdvantageFramework.Calendar.SugarCRM.UserProperties.user_name.ToString}

                            Try

                                TotalCount = SugarClient.get_entries_count(LoginResult.id, AdvantageFramework.Calendar.SugarCRM.ActivityTypes.Calls.ToString, "assigned_user_id = '" & SugarClient.get_user_id(LoginResult.id) & "' AND date_start >= '" & AdvantageFramework.Calendar.SugarCRM.GetDateValue(StartDate) & "'", 1).result_count

                            Catch ex As Exception
                                TotalCount = 0
                            End Try

                            Count = 0

                            If TotalCount > 0 Then

                                Do While Count < TotalCount

                                    SugarCalls = SugarClient.get_entry_list(LoginResult.id, AdvantageFramework.Calendar.SugarCRM.ActivityTypes.Calls.ToString, "assigned_user_id = '" & SugarClient.get_user_id(LoginResult.id) & "' AND date_start >= '" & AdvantageFramework.Calendar.SugarCRM.GetDateValue(StartDate) & "'", "", Count, PropertyNames.ToArray, New SugarCRMRef.link_name_to_fields_array() {SugarCRMUserRelationship}, 0, 1, False)

                                    ProcessSugarCalls(DbContext, Agency, LastRanAt, Employee, SugarCalls)

                                    Count += SugarCalls.result_count

                                Loop

                            End If

                            PropertyNames = AdvantageFramework.Calendar.SugarCRM.LoadSugarCRMPropertyNames("M")

                            Try

                                TotalCount = SugarClient.get_entries_count(LoginResult.id, AdvantageFramework.Calendar.SugarCRM.ActivityTypes.Meetings.ToString, "assigned_user_id = '" & SugarClient.get_user_id(LoginResult.id) & "' AND date_start >= '" & AdvantageFramework.Calendar.SugarCRM.GetDateValue(StartDate) & "'", 1).result_count

                            Catch ex As Exception
                                TotalCount = 0
                            End Try

                            Count = 0

                            If TotalCount > 0 Then

                                Do While Count < TotalCount

                                    SugarMeetings = SugarClient.get_entry_list(LoginResult.id, AdvantageFramework.Calendar.SugarCRM.ActivityTypes.Meetings.ToString, "assigned_user_id = '" & SugarClient.get_user_id(LoginResult.id) & "' AND date_start >= '" & AdvantageFramework.Calendar.SugarCRM.GetDateValue(StartDate) & "'", "", Count, PropertyNames.ToArray, New SugarCRMRef.link_name_to_fields_array() {SugarCRMUserRelationship}, 0, 1, False)

                                    ProcessSugarMeetings(DbContext, Agency, LastRanAt, Employee, SugarMeetings)

                                    Count += SugarMeetings.result_count

                                Loop

                            End If

                        Else

                            WriteToEventLog("failed loading employee calendar --> " & Employee.ToString & " --> employee does not have valid sugarCRM settings")

                        End If

                    Else

                        WriteToEventLog("failed loading employee calendar --> " & Employee.ToString & " --> employee does not have valid sugarCRM settings")

                    End If

                Else

                    WriteToEventLog("failed loading employee calendar --> " & Employee.ToString & " --> employee does not have valid sugarCRM settings")

                End If

            Catch ex As Exception
                WriteToEventLog("Error processing employee --> " & Employee.ToString & " --> " & ex.Message)
            End Try

        End Sub
        Private Sub ProcessSugarCalls(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Agency As AdvantageFramework.Database.Entities.Agency,
                                      ByVal LastRanAt As Date, ByVal Employee As AdvantageFramework.Database.Views.Employee, ByVal SugarCalls As SugarCRMRef.get_entry_list_result_version2)

            'objects
            Dim EmployeeNonTask As AdvantageFramework.Database.Entities.EmployeeNonTask = Nothing
            Dim DateModified As Date = Nothing
            Dim IsDeleted As Boolean = False
            Dim StartDate As Date = Nothing
            Dim EndDate As Date = Nothing
            Dim DayDifference As Integer = 0
            Dim EmployeeNonTaskID As Integer = 0
            Dim Description As String = ""
            Dim SugarActivityRelationship As SugarCRMRef.link_list2 = Nothing
            Dim SugarCRMNonTask As SugarCRMRef.entry_value = Nothing
            Dim ActivityEmployee As AdvantageFramework.Database.Views.Employee = Nothing

            For Each SugarCRMNonTask In SugarCalls.entry_list

                EmployeeNonTask = Nothing
                DateModified = LastRanAt
                IsDeleted = False
                Description = ""
                EmployeeNonTaskID = 0

                Try

                    Description = AdvantageFramework.Calendar.SugarCRM.GetEntryValue(SugarCRMNonTask, AdvantageFramework.Calendar.SugarCRM.CallProperties.name.ToString)

                Catch ex As Exception
                    Description = ""
                End Try

                Try

                    IsDeleted = (AdvantageFramework.Calendar.SugarCRM.GetEntryValue(SugarCRMNonTask, AdvantageFramework.Calendar.SugarCRM.CallProperties.deleted.ToString) = "1")

                Catch ex As Exception
                    IsDeleted = False
                End Try

                Try

                    DateModified = Convert.ToDateTime(AdvantageFramework.Calendar.SugarCRM.GetEntryValue(SugarCRMNonTask, AdvantageFramework.Calendar.SugarCRM.CallProperties.date_modified.ToString))

                Catch ex As Exception
                    DateModified = LastRanAt
                End Try

                Try

                    Integer.TryParse(AdvantageFramework.Calendar.SugarCRM.GetEntryValue(SugarCRMNonTask, AdvantageFramework.Calendar.SugarCRM.CallProperties.advantage_id_c.ToString), EmployeeNonTaskID)

                Catch ex As Exception
                    EmployeeNonTaskID = 0
                End Try

                WriteToEventLog("checking call --> " & Description)

                If EmployeeNonTaskID > 0 Then

                    Try

                        EmployeeNonTask = AdvantageFramework.Database.Procedures.EmployeeNonTask.LoadByEmployeeNonTaskID(DbContext, EmployeeNonTaskID)

                    Catch ex As Exception
                        EmployeeNonTask = Nothing
                    End Try

                End If

                If EmployeeNonTask Is Nothing Then

                    EmployeeNonTask = AdvantageFramework.Database.Procedures.EmployeeNonTask.Load(DbContext).SingleOrDefault(Function(Entity) Entity.SugarCRMID = SugarCRMNonTask.id)

                End If

                If EmployeeNonTask Is Nothing AndAlso IsDeleted = False Then

                    WriteToEventLog("processing call --> " & Description)

                    EmployeeNonTask = New AdvantageFramework.Database.Entities.EmployeeNonTask

                    EmployeeNonTask.DbContext = DbContext
                    EmployeeNonTask.Type = "C"

                    EmployeeNonTask.Description = AdvantageFramework.Calendar.SugarCRM.GetEntryValue(SugarCRMNonTask, AdvantageFramework.Calendar.SugarCRM.CallProperties.name.ToString)
                    EmployeeNonTask.NontaskDescription = AdvantageFramework.Calendar.SugarCRM.GetEntryValue(SugarCRMNonTask, AdvantageFramework.Calendar.SugarCRM.CallProperties.description.ToString)

                    Try

                        StartDate = Convert.ToDateTime(AdvantageFramework.Calendar.SugarCRM.GetEntryValue(SugarCRMNonTask, AdvantageFramework.Calendar.SugarCRM.CallProperties.date_start.ToString)).ToLocalTime

                    Catch ex As Exception
                        StartDate = Now
                    End Try

                    Try

                        EndDate = Convert.ToDateTime(AdvantageFramework.Calendar.SugarCRM.GetEntryValue(SugarCRMNonTask, AdvantageFramework.Calendar.SugarCRM.CallProperties.date_end.ToString)).ToLocalTime

                    Catch ex As Exception
                        EndDate = Now
                    End Try

                    EmployeeNonTask.IsAllDay = 0

                    EmployeeNonTask.StartDate = StartDate.ToShortDateString
                    EmployeeNonTask.EndDate = EndDate.ToShortDateString

                    EmployeeNonTask.StartDateAndTime = StartDate.ToShortDateString & " " & StartDate.ToLongTimeString
                    EmployeeNonTask.EndDateAndTime = EndDate.ToShortDateString & " " & EndDate.ToLongTimeString

                    DayDifference = Math.Abs(DateDiff(DateInterval.Day, CDate(EmployeeNonTask.StartDateAndTime), CDate(EmployeeNonTask.EndDateAndTime)))

                    If DayDifference = 0 Then

                        EmployeeNonTask.Hours = CDec(FormatNumber(CDate(EmployeeNonTask.EndDateAndTime).Subtract(CDate(EmployeeNonTask.StartDateAndTime)).TotalHours, 2))

                        If EmployeeNonTask.Hours > Agency.StandardHours.GetValueOrDefault(0) Then

                            EmployeeNonTask.Hours = CDec(FormatNumber(Agency.StandardHours.GetValueOrDefault(0), 2))

                        End If

                    Else

                        EmployeeNonTask.Hours = CDec(FormatNumber(AdvantageFramework.EmployeeUtilities.LoadTotalHoursWorked(Employee, CDate(EmployeeNonTask.StartDateAndTime), CDate(EmployeeNonTask.EndDateAndTime)), 2))

                    End If

                    EmployeeNonTask.EmployeeCode = Employee.Code
                    EmployeeNonTask.SugarCRMID = SugarCRMNonTask.id

                    If AdvantageFramework.Database.Procedures.EmployeeNonTask.Insert(DbContext, EmployeeNonTask) Then

                        Try

                            DbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO [dbo].[EMP_NON_TASKS_EMPS]([NON_TASK_ID],[EMP_CODE],[EMAIL_ADDRESS]) VALUES ({0}, '{1}', '{2}')", EmployeeNonTask.ID, Employee.Code, Employee.Email))

                        Catch ex As Exception
                            'WriteToEventLog("failed to insert call --> " & Description & " --> " & ex.Message)
                        End Try

                        Try

                            SugarActivityRelationship = SugarCalls.relationship_list.ToList(SugarCalls.entry_list.ToList.IndexOf(SugarCRMNonTask))

                        Catch ex As Exception
                            SugarActivityRelationship = Nothing
                        End Try

                        If SugarActivityRelationship IsNot Nothing Then

                            For Each LinkValue In SugarActivityRelationship.link_list

                                For Each Record In LinkValue.records

                                    For Each RecordLinkValue In Record.link_value

                                        If RecordLinkValue.name = AdvantageFramework.Calendar.SugarCRM.UserProperties.user_name.ToString Then

                                            Try

                                                ActivityEmployee = (From Entity In AdvantageFramework.Database.Procedures.EmployeeView.Load(DbContext)
                                                                    Where Entity.SugarCRMUserName = RecordLinkValue.value
                                                                    Select Entity).SingleOrDefault

                                            Catch ex As Exception
                                                ActivityEmployee = Nothing
                                            End Try

                                            If ActivityEmployee IsNot Nothing Then

                                                Try

                                                    If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM [dbo].[EMP_NON_TASKS_EMPS] WHERE [NON_TASK_ID] = {0} AND [EMP_CODE] = '{1}'", EmployeeNonTask.ID, ActivityEmployee.Code)).FirstOrDefault = 0 Then

                                                        DbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO [dbo].[EMP_NON_TASKS_EMPS]([NON_TASK_ID],[EMP_CODE],[EMAIL_ADDRESS]) VALUES ({0}, '{1}', '{2}')", EmployeeNonTask.ID, ActivityEmployee.Code, ActivityEmployee.Email))

                                                    End If

                                                Catch ex As Exception

                                                End Try

                                            End If

                                        End If

                                    Next

                                Next

                            Next

                        End If

                        'AdvantageFramework.Calendar.SugarCRM.SetEntryValue(SugarCRMNonTask, AdvantageFramework.Calendar.SugarCRM.CallProperties.advantage_id_c.ToString, EmployeeNonTask.ID)

                        'SugarClient.set_entry(LoginResult.id, ActivityType.ToString, SugarCRMNonTask.name_value_list)

                        WriteToEventLog("call inserted --> " & Description)

                    Else

                        WriteToEventLog("failed to insert call --> " & Description)

                    End If

                Else

                    If EmployeeNonTask IsNot Nothing AndAlso IsDeleted = False AndAlso DateModified > LastRanAt Then

                        WriteToEventLog("processing call --> " & Description)

                        EmployeeNonTask.Description = AdvantageFramework.Calendar.SugarCRM.GetEntryValue(SugarCRMNonTask, AdvantageFramework.Calendar.SugarCRM.CallProperties.name.ToString)
                        EmployeeNonTask.NontaskDescription = AdvantageFramework.Calendar.SugarCRM.GetEntryValue(SugarCRMNonTask, AdvantageFramework.Calendar.SugarCRM.CallProperties.description.ToString)

                        Try

                            StartDate = Convert.ToDateTime(AdvantageFramework.Calendar.SugarCRM.GetEntryValue(SugarCRMNonTask, AdvantageFramework.Calendar.SugarCRM.CallProperties.date_start.ToString)).ToLocalTime

                        Catch ex As Exception
                            StartDate = Now
                        End Try

                        Try

                            EndDate = Convert.ToDateTime(AdvantageFramework.Calendar.SugarCRM.GetEntryValue(SugarCRMNonTask, AdvantageFramework.Calendar.SugarCRM.CallProperties.date_end.ToString)).ToLocalTime

                        Catch ex As Exception
                            EndDate = Now
                        End Try

                        EmployeeNonTask.IsAllDay = 0

                        EmployeeNonTask.StartDate = StartDate.ToShortDateString
                        EmployeeNonTask.EndDate = EndDate.ToShortDateString

                        EmployeeNonTask.StartDateAndTime = StartDate.ToShortDateString & " " & StartDate.ToLongTimeString
                        EmployeeNonTask.EndDateAndTime = EndDate.ToShortDateString & " " & EndDate.ToLongTimeString

                        DayDifference = Math.Abs(DateDiff(DateInterval.Day, CDate(EmployeeNonTask.StartDateAndTime), CDate(EmployeeNonTask.EndDateAndTime)))

                        If DayDifference = 0 Then

                            EmployeeNonTask.Hours = CDec(FormatNumber(CDate(EmployeeNonTask.EndDateAndTime).Subtract(CDate(EmployeeNonTask.StartDateAndTime)).TotalHours, 2))

                            If EmployeeNonTask.Hours > Agency.StandardHours.GetValueOrDefault(0) Then

                                EmployeeNonTask.Hours = CDec(FormatNumber(Agency.StandardHours.GetValueOrDefault(0), 2))

                            End If

                        Else

                            EmployeeNonTask.Hours = CDec(FormatNumber(AdvantageFramework.EmployeeUtilities.LoadTotalHoursWorked(Employee, CDate(EmployeeNonTask.StartDateAndTime), CDate(EmployeeNonTask.EndDateAndTime)), 2))

                        End If

                        EmployeeNonTask.EmployeeCode = Employee.Code
                        EmployeeNonTask.SugarCRMID = SugarCRMNonTask.id

                        If AdvantageFramework.Database.Procedures.EmployeeNonTask.Update(DbContext, EmployeeNonTask) Then

                            Try

                                DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM [dbo].[EMP_NON_TASKS_EMPS] WHERE [NON_TASK_ID] = {0} AND [EMP_CODE] IN (SELECT EMP_CODE FROM dbo.EMPLOYEE E WHERE ISNULL(E.SUGAR_USERNAME, '') <> '' AND ISNULL(E.SUGAR_PASSWORD, '') <> '')", EmployeeNonTask.ID))

                            Catch ex As Exception

                            End Try

                            Try

                                If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM [dbo].[EMP_NON_TASKS_EMPS] WHERE [NON_TASK_ID] = {0} AND [EMP_CODE] = '{1}'", EmployeeNonTask.ID, Employee.Code)).FirstOrDefault = 0 Then

                                    DbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO [dbo].[EMP_NON_TASKS_EMPS]([NON_TASK_ID],[EMP_CODE],[EMAIL_ADDRESS]) VALUES ({0}, '{1}', '{2}')", EmployeeNonTask.ID, Employee.Code, Employee.Email))

                                End If

                            Catch ex As Exception

                            End Try

                            Try

                                SugarActivityRelationship = SugarCalls.relationship_list.ToList(SugarCalls.entry_list.ToList.IndexOf(SugarCRMNonTask))

                            Catch ex As Exception
                                SugarActivityRelationship = Nothing
                            End Try

                            If SugarActivityRelationship IsNot Nothing Then

                                For Each LinkValue In SugarActivityRelationship.link_list

                                    For Each Record In LinkValue.records

                                        For Each RecordLinkValue In Record.link_value

                                            If RecordLinkValue.name = AdvantageFramework.Calendar.SugarCRM.UserProperties.user_name.ToString Then

                                                Try

                                                    ActivityEmployee = (From Entity In AdvantageFramework.Database.Procedures.EmployeeView.Load(DbContext)
                                                                        Where Entity.SugarCRMUserName = RecordLinkValue.value
                                                                        Select Entity).SingleOrDefault

                                                Catch ex As Exception
                                                    ActivityEmployee = Nothing
                                                End Try

                                                If ActivityEmployee IsNot Nothing Then

                                                    Try

                                                        If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM [dbo].[EMP_NON_TASKS_EMPS] WHERE [NON_TASK_ID] = {0} AND [EMP_CODE] = '{1}'", EmployeeNonTask.ID, ActivityEmployee.Code)).FirstOrDefault = 0 Then

                                                            DbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO [dbo].[EMP_NON_TASKS_EMPS]([NON_TASK_ID],[EMP_CODE],[EMAIL_ADDRESS]) VALUES ({0}, '{1}', '{2}')", EmployeeNonTask.ID, ActivityEmployee.Code, ActivityEmployee.Email))

                                                        End If

                                                    Catch ex As Exception

                                                    End Try

                                                End If

                                            End If

                                        Next

                                    Next

                                Next

                            End If

                            'AdvantageFramework.Calendar.SugarCRM.SetEntryValue(SugarCRMNonTask, AdvantageFramework.Calendar.SugarCRM.CallProperties.advantage_id_c.ToString, EmployeeNonTask.ID)

                            'SugarClient.set_entry(LoginResult.id, ActivityType.ToString, SugarCRMNonTask.name_value_list)

                            WriteToEventLog("call updated --> " & Description)

                        Else

                            WriteToEventLog("failed to update call --> " & Description)

                        End If

                    ElseIf EmployeeNonTask IsNot Nothing AndAlso IsDeleted Then

                        WriteToEventLog("processing call --> " & Description)

                        If AdvantageFramework.Database.Procedures.EmployeeNonTask.Delete(DbContext, EmployeeNonTask) Then

                            WriteToEventLog("call deleted --> " & Description)

                        Else

                            WriteToEventLog("failed to delete call --> " & Description)

                        End If

                        'AdvantageFramework.Calendar.SugarCRM.SetEntryValue(SugarCRMNonTask, AdvantageFramework.Calendar.SugarCRM.CallProperties.advantage_id_c.ToString, "")

                        'SugarClient.set_entry(LoginResult.id, ActivityType.ToString, SugarCRMNonTask.name_value_list)

                    End If

                End If

            Next

        End Sub
        Private Sub ProcessSugarMeetings(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Agency As AdvantageFramework.Database.Entities.Agency,
                                         ByVal LastRanAt As Date, ByVal Employee As AdvantageFramework.Database.Views.Employee, ByVal SugarMeetings As SugarCRMRef.get_entry_list_result_version2)

            'objects
            Dim EmployeeNonTask As AdvantageFramework.Database.Entities.EmployeeNonTask = Nothing
            Dim DateModified As Date = Nothing
            Dim IsDeleted As Boolean = False
            Dim StartDate As Date = Nothing
            Dim EndDate As Date = Nothing
            Dim DayDifference As Integer = 0
            Dim EmployeeNonTaskID As Integer = 0
            Dim Description As String = ""
            Dim SugarActivityRelationship As SugarCRMRef.link_list2 = Nothing
            Dim SugarCRMNonTask As SugarCRMRef.entry_value = Nothing
            Dim ActivityEmployee As AdvantageFramework.Database.Views.Employee = Nothing

            For Each SugarCRMNonTask In SugarMeetings.entry_list

                EmployeeNonTask = Nothing
                DateModified = LastRanAt
                IsDeleted = False
                Description = ""
                EmployeeNonTaskID = 0

                Try

                    Description = AdvantageFramework.Calendar.SugarCRM.GetEntryValue(SugarCRMNonTask, AdvantageFramework.Calendar.SugarCRM.MeetingProperties.name.ToString)

                Catch ex As Exception
                    Description = ""
                End Try

                Try

                    IsDeleted = (AdvantageFramework.Calendar.SugarCRM.GetEntryValue(SugarCRMNonTask, AdvantageFramework.Calendar.SugarCRM.MeetingProperties.deleted.ToString) = "1")

                Catch ex As Exception
                    IsDeleted = False
                End Try

                Try

                    DateModified = Convert.ToDateTime(AdvantageFramework.Calendar.SugarCRM.GetEntryValue(SugarCRMNonTask, AdvantageFramework.Calendar.SugarCRM.MeetingProperties.date_modified.ToString))

                Catch ex As Exception
                    DateModified = LastRanAt
                End Try

                Try

                    Integer.TryParse(AdvantageFramework.Calendar.SugarCRM.GetEntryValue(SugarCRMNonTask, AdvantageFramework.Calendar.SugarCRM.CallProperties.advantage_id_c.ToString), EmployeeNonTaskID)

                Catch ex As Exception
                    EmployeeNonTaskID = 0
                End Try

                WriteToEventLog("checking meeting --> " & Description)

                If EmployeeNonTaskID > 0 Then

                    Try

                        EmployeeNonTask = AdvantageFramework.Database.Procedures.EmployeeNonTask.LoadByEmployeeNonTaskID(DbContext, EmployeeNonTaskID)

                    Catch ex As Exception
                        EmployeeNonTask = Nothing
                    End Try

                End If

                If EmployeeNonTask Is Nothing Then

                    EmployeeNonTask = AdvantageFramework.Database.Procedures.EmployeeNonTask.Load(DbContext).SingleOrDefault(Function(Entity) Entity.SugarCRMID = SugarCRMNonTask.id)

                End If

                If EmployeeNonTask Is Nothing AndAlso IsDeleted = False Then

                    WriteToEventLog("processing meeting --> " & Description)

                    EmployeeNonTask = New AdvantageFramework.Database.Entities.EmployeeNonTask

                    EmployeeNonTask.DbContext = DbContext
                    EmployeeNonTask.Type = "M"

                    EmployeeNonTask.Description = AdvantageFramework.Calendar.SugarCRM.GetEntryValue(SugarCRMNonTask, AdvantageFramework.Calendar.SugarCRM.MeetingProperties.name.ToString)
                    EmployeeNonTask.NontaskDescription = AdvantageFramework.Calendar.SugarCRM.GetEntryValue(SugarCRMNonTask, AdvantageFramework.Calendar.SugarCRM.MeetingProperties.description.ToString)

                    Try

                        StartDate = Convert.ToDateTime(AdvantageFramework.Calendar.SugarCRM.GetEntryValue(SugarCRMNonTask, AdvantageFramework.Calendar.SugarCRM.MeetingProperties.date_start.ToString)).ToLocalTime

                    Catch ex As Exception
                        StartDate = Now
                    End Try

                    Try

                        EndDate = Convert.ToDateTime(AdvantageFramework.Calendar.SugarCRM.GetEntryValue(SugarCRMNonTask, AdvantageFramework.Calendar.SugarCRM.MeetingProperties.date_end.ToString)).ToLocalTime

                    Catch ex As Exception
                        EndDate = Now
                    End Try

                    EmployeeNonTask.IsAllDay = 0

                    EmployeeNonTask.StartDate = StartDate.ToShortDateString
                    EmployeeNonTask.EndDate = EndDate.ToShortDateString

                    EmployeeNonTask.StartDateAndTime = StartDate.ToShortDateString & " " & StartDate.ToLongTimeString
                    EmployeeNonTask.EndDateAndTime = EndDate.ToShortDateString & " " & EndDate.ToLongTimeString

                    DayDifference = Math.Abs(DateDiff(DateInterval.Day, CDate(EmployeeNonTask.StartDateAndTime), CDate(EmployeeNonTask.EndDateAndTime)))

                    If DayDifference = 0 Then

                        EmployeeNonTask.Hours = CDec(FormatNumber(CDate(EmployeeNonTask.EndDateAndTime).Subtract(CDate(EmployeeNonTask.StartDateAndTime)).TotalHours, 2))

                        If EmployeeNonTask.Hours > Agency.StandardHours.GetValueOrDefault(0) Then

                            EmployeeNonTask.Hours = CDec(FormatNumber(Agency.StandardHours.GetValueOrDefault(0), 2))

                        End If

                    Else

                        EmployeeNonTask.Hours = CDec(FormatNumber(AdvantageFramework.EmployeeUtilities.LoadTotalHoursWorked(Employee, CDate(EmployeeNonTask.StartDateAndTime), CDate(EmployeeNonTask.EndDateAndTime)), 2))

                    End If

                    EmployeeNonTask.EmployeeCode = Employee.Code
                    EmployeeNonTask.SugarCRMID = SugarCRMNonTask.id

                    If AdvantageFramework.Database.Procedures.EmployeeNonTask.Insert(DbContext, EmployeeNonTask) Then

                        Try

                            DbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO [dbo].[EMP_NON_TASKS_EMPS]([NON_TASK_ID],[EMP_CODE],[EMAIL_ADDRESS]) VALUES ({0}, '{1}', '{2}')", EmployeeNonTask.ID, Employee.Code, Employee.Email))

                        Catch ex As Exception
                            'WriteToEventLog("failed to insert meeting --> " & Description & " --> " & ex.Message)
                        End Try

                        Try

                            SugarActivityRelationship = SugarMeetings.relationship_list.ToList(SugarMeetings.entry_list.ToList.IndexOf(SugarCRMNonTask))

                        Catch ex As Exception
                            SugarActivityRelationship = Nothing
                        End Try

                        If SugarActivityRelationship IsNot Nothing Then

                            For Each LinkValue In SugarActivityRelationship.link_list

                                For Each Record In LinkValue.records

                                    For Each RecordLinkValue In Record.link_value

                                        If RecordLinkValue.name = AdvantageFramework.Calendar.SugarCRM.UserProperties.user_name.ToString Then

                                            Try

                                                ActivityEmployee = (From Entity In AdvantageFramework.Database.Procedures.EmployeeView.Load(DbContext)
                                                                    Where Entity.SugarCRMUserName = RecordLinkValue.value
                                                                    Select Entity).SingleOrDefault

                                            Catch ex As Exception
                                                ActivityEmployee = Nothing
                                            End Try

                                            If ActivityEmployee IsNot Nothing Then

                                                Try

                                                    If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM [dbo].[EMP_NON_TASKS_EMPS] WHERE [NON_TASK_ID] = {0} AND [EMP_CODE] = '{1}'", EmployeeNonTask.ID, ActivityEmployee.Code)).FirstOrDefault = 0 Then

                                                        DbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO [dbo].[EMP_NON_TASKS_EMPS]([NON_TASK_ID],[EMP_CODE],[EMAIL_ADDRESS]) VALUES ({0}, '{1}', '{2}')", EmployeeNonTask.ID, ActivityEmployee.Code, ActivityEmployee.Email))

                                                    End If

                                                Catch ex As Exception

                                                End Try

                                            End If

                                        End If

                                    Next

                                Next

                            Next

                        End If

                        'AdvantageFramework.Calendar.SugarCRM.SetEntryValue(SugarCRMNonTask, AdvantageFramework.Calendar.SugarCRM.MeetingProperties.advantage_id_c.ToString, EmployeeNonTask.ID)

                        'SugarClient.set_entry(LoginResult.id, ActivityType.ToString, SugarCRMNonTask.name_value_list)

                        WriteToEventLog("meeting inserted --> " & Description)

                    Else

                        WriteToEventLog("failed to insert meeting --> " & Description)

                    End If

                Else

                    If EmployeeNonTask IsNot Nothing AndAlso IsDeleted = False AndAlso DateModified > LastRanAt Then

                        WriteToEventLog("processing meeting --> " & Description)

                        EmployeeNonTask.Description = AdvantageFramework.Calendar.SugarCRM.GetEntryValue(SugarCRMNonTask, AdvantageFramework.Calendar.SugarCRM.MeetingProperties.name.ToString)
                        EmployeeNonTask.NontaskDescription = AdvantageFramework.Calendar.SugarCRM.GetEntryValue(SugarCRMNonTask, AdvantageFramework.Calendar.SugarCRM.MeetingProperties.description.ToString)

                        Try

                            StartDate = Convert.ToDateTime(AdvantageFramework.Calendar.SugarCRM.GetEntryValue(SugarCRMNonTask, AdvantageFramework.Calendar.SugarCRM.MeetingProperties.date_start.ToString)).ToLocalTime

                        Catch ex As Exception
                            StartDate = Now
                        End Try

                        Try

                            EndDate = Convert.ToDateTime(AdvantageFramework.Calendar.SugarCRM.GetEntryValue(SugarCRMNonTask, AdvantageFramework.Calendar.SugarCRM.MeetingProperties.date_end.ToString)).ToLocalTime

                        Catch ex As Exception
                            EndDate = Now
                        End Try

                        EmployeeNonTask.IsAllDay = 0

                        EmployeeNonTask.StartDate = StartDate.ToShortDateString
                        EmployeeNonTask.EndDate = EndDate.ToShortDateString

                        EmployeeNonTask.StartDateAndTime = StartDate.ToShortDateString & " " & StartDate.ToLongTimeString
                        EmployeeNonTask.EndDateAndTime = EndDate.ToShortDateString & " " & EndDate.ToLongTimeString

                        DayDifference = Math.Abs(DateDiff(DateInterval.Day, CDate(EmployeeNonTask.StartDateAndTime), CDate(EmployeeNonTask.EndDateAndTime)))

                        If DayDifference = 0 Then

                            EmployeeNonTask.Hours = CDec(FormatNumber(CDate(EmployeeNonTask.EndDateAndTime).Subtract(CDate(EmployeeNonTask.StartDateAndTime)).TotalHours, 2))

                            If EmployeeNonTask.Hours > Agency.StandardHours.GetValueOrDefault(0) Then

                                EmployeeNonTask.Hours = CDec(FormatNumber(Agency.StandardHours.GetValueOrDefault(0), 2))

                            End If

                        Else

                            EmployeeNonTask.Hours = CDec(FormatNumber(AdvantageFramework.EmployeeUtilities.LoadTotalHoursWorked(Employee, CDate(EmployeeNonTask.StartDateAndTime), CDate(EmployeeNonTask.EndDateAndTime)), 2))

                        End If

                        EmployeeNonTask.EmployeeCode = Employee.Code
                        EmployeeNonTask.SugarCRMID = SugarCRMNonTask.id

                        If AdvantageFramework.Database.Procedures.EmployeeNonTask.Update(DbContext, EmployeeNonTask) Then

                            Try

                                DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM [dbo].[EMP_NON_TASKS_EMPS] WHERE [NON_TASK_ID] = {0} AND [EMP_CODE] IN (SELECT EMP_CODE FROM dbo.EMPLOYEE E WHERE ISNULL(E.SUGAR_USERNAME, '') <> '' AND ISNULL(E.SUGAR_PASSWORD, '') <> '')", EmployeeNonTask.ID))

                            Catch ex As Exception

                            End Try

                            Try

                                If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM [dbo].[EMP_NON_TASKS_EMPS] WHERE [NON_TASK_ID] = {0} AND [EMP_CODE] = '{1}'", EmployeeNonTask.ID, Employee.Code)).FirstOrDefault = 0 Then

                                    DbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO [dbo].[EMP_NON_TASKS_EMPS]([NON_TASK_ID],[EMP_CODE],[EMAIL_ADDRESS]) VALUES ({0}, '{1}', '{2}')", EmployeeNonTask.ID, Employee.Code, Employee.Email))

                                End If

                            Catch ex As Exception

                            End Try

                            Try

                                SugarActivityRelationship = SugarMeetings.relationship_list.ToList(SugarMeetings.entry_list.ToList.IndexOf(SugarCRMNonTask))

                            Catch ex As Exception
                                SugarActivityRelationship = Nothing
                            End Try

                            If SugarActivityRelationship IsNot Nothing Then

                                For Each LinkValue In SugarActivityRelationship.link_list

                                    For Each Record In LinkValue.records

                                        For Each RecordLinkValue In Record.link_value

                                            If RecordLinkValue.name = AdvantageFramework.Calendar.SugarCRM.UserProperties.user_name.ToString Then

                                                Try

                                                    ActivityEmployee = (From Entity In AdvantageFramework.Database.Procedures.EmployeeView.Load(DbContext)
                                                                        Where Entity.SugarCRMUserName = RecordLinkValue.value
                                                                        Select Entity).SingleOrDefault

                                                Catch ex As Exception
                                                    ActivityEmployee = Nothing
                                                End Try

                                                If ActivityEmployee IsNot Nothing Then

                                                    Try

                                                        If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM [dbo].[EMP_NON_TASKS_EMPS] WHERE [NON_TASK_ID] = {0} AND [EMP_CODE] = '{1}'", EmployeeNonTask.ID, ActivityEmployee.Code)).FirstOrDefault = 0 Then

                                                            DbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO [dbo].[EMP_NON_TASKS_EMPS]([NON_TASK_ID],[EMP_CODE],[EMAIL_ADDRESS]) VALUES ({0}, '{1}', '{2}')", EmployeeNonTask.ID, ActivityEmployee.Code, ActivityEmployee.Email))

                                                        End If

                                                    Catch ex As Exception

                                                    End Try

                                                End If

                                            End If

                                        Next

                                    Next

                                Next

                            End If

                            'AdvantageFramework.Calendar.SugarCRM.SetEntryValue(SugarCRMNonTask, AdvantageFramework.Calendar.SugarCRM.MeetingProperties.advantage_id_c.ToString, EmployeeNonTask.ID)

                            'SugarClient.set_entry(LoginResult.id, ActivityType.ToString, SugarCRMNonTask.name_value_list)

                            WriteToEventLog("meeting updated --> " & Description)

                        Else

                            WriteToEventLog("failed to update meeting --> " & Description)

                        End If

                    ElseIf EmployeeNonTask IsNot Nothing AndAlso IsDeleted Then

                        WriteToEventLog("processing meeting --> " & Description)

                        If AdvantageFramework.Database.Procedures.EmployeeNonTask.Delete(DbContext, EmployeeNonTask) Then

                            WriteToEventLog("meeting deleted --> " & Description)

                        Else

                            WriteToEventLog("failed to delete meeting --> " & Description)

                        End If

                        'AdvantageFramework.Calendar.SugarCRM.SetEntryValue(SugarCRMNonTask, AdvantageFramework.Calendar.SugarCRM.MeetingProperties.advantage_id_c.ToString, "")

                        'SugarClient.set_entry(LoginResult.id, ActivityType.ToString, SugarCRMNonTask.name_value_list)

                    End If

                End If

            Next

        End Sub
        Public Sub ProcessOutlookCalendar(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext,
                                            ByVal Agency As AdvantageFramework.Database.Entities.Agency, ByVal LastRanAt As Date, ByVal Employee As AdvantageFramework.Database.Views.Employee)

            'objects
            Dim ExchangeService As Microsoft.Exchange.WebServices.Data.ExchangeService = Nothing
            Dim CalendarFolder As Microsoft.Exchange.WebServices.Data.CalendarFolder = Nothing
            Dim CalendarView As Microsoft.Exchange.WebServices.Data.CalendarView = Nothing
            Dim ExtendedProperty As Microsoft.Exchange.WebServices.Data.ExtendedProperty = Nothing
            Dim EmployeeNonTask As AdvantageFramework.Database.Entities.EmployeeNonTask = Nothing
            Dim AppointmentIDs As Generic.List(Of String) = Nothing
            Dim DayDifference As Integer = 0
            Dim StartDateConverted As Date = Date.MinValue
            Dim EndDateConverted As Date = Date.MinValue
            Dim UTCOffset As String = String.Empty
            Dim TimeZoneInfo As TimeZoneInfo = Nothing
            Dim DescriptionMaxLength As Integer = -1

            Try

                If String.IsNullOrWhiteSpace(Employee.Email) = False AndAlso String.IsNullOrWhiteSpace(Employee.EmailPassword) = False Then

                    Try

                        DescriptionMaxLength = AdvantageFramework.BaseClasses.Entity.LoadPropertyMaxLength(GetType(AdvantageFramework.Database.Entities.EmployeeNonTask), AdvantageFramework.Database.Entities.EmployeeNonTask.Properties.Description.ToString)

                    Catch ex As Exception
                        DescriptionMaxLength = -1
                    End Try

                    WriteToEventLog("Attempting to login employee --> " & Employee.ToString)

                    ExchangeService = New Microsoft.Exchange.WebServices.Data.ExchangeService(Microsoft.Exchange.WebServices.Data.ExchangeVersion.Exchange2007_SP1)

                    ExchangeService.Credentials = New Microsoft.Exchange.WebServices.Data.WebCredentials(Employee.Email, AdvantageFramework.Security.Encryption.Decrypt(Employee.EmailPassword))
                    ExchangeService.AutodiscoverUrl(Employee.Email, AddressOf AdvantageFramework.Calendar.Outlook.RedirectionCallback)

                    CalendarFolder = Microsoft.Exchange.WebServices.Data.CalendarFolder.Bind(ExchangeService, Microsoft.Exchange.WebServices.Data.WellKnownFolderName.Calendar)
                    CalendarView = New Microsoft.Exchange.WebServices.Data.CalendarView(Now.AddDays(-30), Now.AddMonths(2))

                    AppointmentIDs = New Generic.List(Of String)

                    TimeZoneInfo = LoadTimeZoneInfo(DbContext, Employee.Code)

                    For Each Appointment In CalendarFolder.FindAppointments(CalendarView)

                        EmployeeNonTask = Nothing
                        ExtendedProperty = Nothing

                        WriteToEventLog("checking appointment --> " & Appointment.Subject)

                        AppointmentIDs.Add(Appointment.Id.UniqueId)

                        If Appointment.LastModifiedTime > LastRanAt Then

                            'Try

                            '    ExtendedProperty = Appointment.ExtendedProperties.SingleOrDefault(Function(EP) EP.PropertyDefinition.Name = AdvantageFramework.Calendar.Outlook.ExtendedPropertyName)

                            'Catch ex As Exception
                            '    ExtendedProperty = Nothing
                            'End Try

                            'If ExtendedProperty IsNot Nothing Then

                            '    Try

                            '        EmployeeNonTask = AdvantageFramework.Database.Procedures.EmployeeNonTask.LoadByEmployeeNonTaskID(DbContext, ExtendedProperty.Value)

                            '    Catch ex As Exception
                            '        EmployeeNonTask = Nothing
                            '    End Try

                            'End If

                            If EmployeeNonTask Is Nothing Then

                                EmployeeNonTask = AdvantageFramework.Database.Procedures.EmployeeNonTask.Load(DbContext).FirstOrDefault(Function(Entity) Entity.OutlookID = Appointment.Id.UniqueId)

                            End If

                            If EmployeeNonTask Is Nothing Then

                                EmployeeNonTask = New AdvantageFramework.Database.Entities.EmployeeNonTask

                                EmployeeNonTask.DbContext = DbContext
                                EmployeeNonTask.Type = "A"

                            End If

                        Else

                            Try

                                EmployeeNonTask = AdvantageFramework.Database.Procedures.EmployeeNonTask.Load(DbContext).FirstOrDefault(Function(Entity) Entity.OutlookID = Appointment.Id.UniqueId)

                            Catch ex As Exception
                                EmployeeNonTask = Nothing
                            End Try

                            If EmployeeNonTask Is Nothing Then

                                EmployeeNonTask = New AdvantageFramework.Database.Entities.EmployeeNonTask

                                EmployeeNonTask.DbContext = DbContext
                                EmployeeNonTask.Type = "A"

                            Else

                                EmployeeNonTask = Nothing

                            End If

                        End If

                        If EmployeeNonTask IsNot Nothing Then

                            WriteToEventLog("processing appointment --> " & Appointment.Subject)

                            EmployeeNonTask.Description = Appointment.Subject

                            If DescriptionMaxLength > 0 AndAlso String.IsNullOrWhiteSpace(EmployeeNonTask.Description) = False AndAlso EmployeeNonTask.Description.Length > DescriptionMaxLength Then

                                EmployeeNonTask.Description = EmployeeNonTask.Description.Substring(0, DescriptionMaxLength)

                            End If

                            EmployeeNonTask.OutlookID = Appointment.Id.UniqueId

                            If Appointment.IsAllDayEvent Then

                                EmployeeNonTask.IsAllDay = 1

                                EmployeeNonTask.StartDate = Appointment.Start.ToShortDateString
                                EmployeeNonTask.EndDate = Appointment.End.ToShortDateString

                                EmployeeNonTask.StartDateAndTime = Appointment.Start.ToShortDateString & " " & Appointment.Start.ToLongTimeString
                                EmployeeNonTask.EndDateAndTime = Appointment.End.ToShortDateString & " 11:59 PM"

                            Else

                                EmployeeNonTask.IsAllDay = 0

                                If TimeZoneInfo IsNot Nothing AndAlso TimeZoneInfo.Local IsNot Nothing AndAlso TimeZoneInfo.Id <> TimeZoneInfo.Local.Id Then

                                    Try

                                        StartDateConverted = TimeZoneInfo.ConvertTime(Appointment.Start, TimeZoneInfo)

                                    Catch ex As Exception
                                        StartDateConverted = Appointment.Start
                                    End Try

                                    Try

                                        EndDateConverted = TimeZoneInfo.ConvertTime(Appointment.End, TimeZoneInfo)

                                    Catch ex As Exception
                                        EndDateConverted = Appointment.End
                                    End Try

                                    'If Appointment.TimeZone.StartsWith("(UTC") AndAlso Appointment.TimeZone.StartsWith("(UTC)") = False Then

                                    '    UTCOffset = Appointment.TimeZone.Substring(4, 6)

                                    'Else

                                    '    StartDateConverted = Appointment.Start
                                    '    EndDateConverted = Appointment.End

                                    'End If

                                Else

                                    StartDateConverted = Appointment.Start
                                    EndDateConverted = Appointment.End

                                End If

                                EmployeeNonTask.StartDate = StartDateConverted.ToShortDateString
                                EmployeeNonTask.EndDate = EndDateConverted.ToShortDateString

                                EmployeeNonTask.StartDateAndTime = StartDateConverted.ToShortDateString & " " & StartDateConverted.ToLongTimeString
                                EmployeeNonTask.EndDateAndTime = EndDateConverted.ToShortDateString & " " & EndDateConverted.ToLongTimeString

                            End If

                            DayDifference = Math.Abs(DateDiff(DateInterval.Day, CDate(EmployeeNonTask.StartDateAndTime), CDate(EmployeeNonTask.EndDateAndTime)))

                            If EmployeeNonTask.IsAllDay = 1 Then

                                If DayDifference = 0 Then

                                    EmployeeNonTask.Hours = CDec(FormatNumber(Agency.StandardHours.GetValueOrDefault(0), 2))

                                Else

                                    EmployeeNonTask.Hours = CDec(FormatNumber(Agency.StandardHours.GetValueOrDefault(0) * DayDifference, 2))

                                End If

                            Else

                                If DayDifference = 0 Then

                                    EmployeeNonTask.Hours = CDec(FormatNumber(CDate(EmployeeNonTask.EndDateAndTime).Subtract(CDate(EmployeeNonTask.StartDateAndTime)).TotalHours, 2))

                                    If EmployeeNonTask.Hours > Agency.StandardHours.GetValueOrDefault(0) Then

                                        EmployeeNonTask.Hours = CDec(FormatNumber(Agency.StandardHours.GetValueOrDefault(0), 2))

                                    End If

                                Else

                                    EmployeeNonTask.Hours = CDec(FormatNumber(AdvantageFramework.EmployeeUtilities.LoadTotalHoursWorked(Employee, CDate(EmployeeNonTask.StartDateAndTime), CDate(EmployeeNonTask.EndDateAndTime)), 2))

                                End If

                            End If

                            EmployeeNonTask.EmployeeCode = Employee.Code

                            If EmployeeNonTask.IsEntityBeingAdded() = False Then

                                If AdvantageFramework.Database.Procedures.EmployeeNonTask.Update(DbContext, EmployeeNonTask) Then

                                    'If ExtendedProperty Is Nothing Then

                                    '    Appointment.SetExtendedProperty(New Microsoft.Exchange.WebServices.Data.ExtendedPropertyDefinition(AdvantageFramework.Calendar.Outlook.ExtendedPropertyGUID, AdvantageFramework.Calendar.Outlook.ExtendedPropertyName, Microsoft.Exchange.WebServices.Data.MapiPropertyType.Integer), EmployeeNonTask.ID)

                                    'End If

                                    Try

                                        If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM [dbo].[EMP_NON_TASKS_EMPS] WHERE [NON_TASK_ID] = {0} AND [EMP_CODE] = '{1}'", EmployeeNonTask.ID, Employee.Code)).FirstOrDefault = 0 Then

                                            DbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO [dbo].[EMP_NON_TASKS_EMPS]([NON_TASK_ID],[EMP_CODE],[EMAIL_ADDRESS]) VALUES ({0}, '{1}', '{2}')", EmployeeNonTask.ID, Employee.Code, Employee.Email))

                                        End If

                                    Catch ex As Exception

                                    End Try

                                    'Appointment.Update(Microsoft.Exchange.WebServices.Data.ConflictResolutionMode.AlwaysOverwrite, Microsoft.Exchange.WebServices.Data.SendInvitationsOrCancellationsMode.SendToNone)

                                    WriteToEventLog("appointment updated --> " & Appointment.Subject)

                                Else

                                    WriteToEventLog("failed to update appointment --> " & Appointment.Subject)

                                End If

                            Else

                                If AdvantageFramework.Database.Procedures.EmployeeNonTask.Insert(DbContext, EmployeeNonTask) Then

                                    Try

                                        'Appointment.SetExtendedProperty(New Microsoft.Exchange.WebServices.Data.ExtendedPropertyDefinition(AdvantageFramework.Calendar.Outlook.ExtendedPropertyGUID, AdvantageFramework.Calendar.Outlook.ExtendedPropertyName, Microsoft.Exchange.WebServices.Data.MapiPropertyType.Integer), EmployeeNonTask.ID)

                                        'Appointment.Update(Microsoft.Exchange.WebServices.Data.ConflictResolutionMode.AlwaysOverwrite, Microsoft.Exchange.WebServices.Data.SendInvitationsOrCancellationsMode.SendToNone)

                                        DbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO [dbo].[EMP_NON_TASKS_EMPS]([NON_TASK_ID],[EMP_CODE],[EMAIL_ADDRESS]) VALUES ({0}, '{1}', '{2}')", EmployeeNonTask.ID, Employee.Code, Employee.Email))

                                    Catch ex As Exception
                                        WriteToEventLog("failed to insert appointment --> " & Appointment.Subject & " --> " & ex.Message)
                                    End Try

                                Else

                                    WriteToEventLog("failed to insert appointment --> " & Appointment.Subject)

                                End If

                            End If

                        End If

                    Next

                    For Each EmployeeNonTask In AdvantageFramework.Database.Procedures.EmployeeNonTask.LoadByEmployeeCode(DbContext, Employee.Code).Where(Function(Entity) Entity.OutlookID IsNot Nothing).ToList.Where(Function(Entity) AppointmentIDs.Contains(Entity.OutlookID) = False).ToList

                        If AdvantageFramework.Database.Procedures.EmployeeNonTask.Delete(DbContext, EmployeeNonTask) Then

                            WriteToEventLog("deleted appointment --> " & EmployeeNonTask.Description)

                        Else

                            WriteToEventLog("failed to deleted appointment --> " & EmployeeNonTask.Description)

                        End If

                    Next

                Else

                    WriteToEventLog("failed loading employee calendar --> " & Employee.ToString & " --> employee does not have valid outlook settings")

                End If

            Catch ex As Exception
                WriteToEventLog("Error processing employee --> " & Employee.ToString & " --> " & ex.Message)
            End Try

        End Sub
        Private Function LoadDatabaseTimeZoneID(DbContext As AdvantageFramework.Database.DbContext) As String

            'objects
            Dim DatabaseTimeZoneID As String = String.Empty

            Try

                DatabaseTimeZoneID = DbContext.Database.SqlQuery(Of String)("SELECT ISNULL(DB_TIMEZONE_ID, '') FROM dbo.AGENCY WITH(NOLOCK);").FirstOrDefault

            Catch ex As Exception
                DatabaseTimeZoneID = String.Empty
            End Try

            LoadDatabaseTimeZoneID = DatabaseTimeZoneID

        End Function
        Private Function LoadAgencyTimeZoneID(DbContext As AdvantageFramework.Database.DbContext) As String

            'objects
            Dim AgencyTimeZoneID As String = String.Empty

            Try

                AgencyTimeZoneID = DbContext.Database.SqlQuery(Of String)("SELECT ISNULL(TIMEZONE_ID, '') FROM dbo.AGENCY WITH(NOLOCK);").FirstOrDefault

            Catch ex As Exception
                AgencyTimeZoneID = String.Empty
            End Try

            LoadAgencyTimeZoneID = AgencyTimeZoneID

        End Function
        Private Function LoadEmployeeTimeZoneID(DbContext As AdvantageFramework.Database.DbContext, EmployeeCode As String) As String

            'objects
            Dim EmployeeTimeZoneID As String = String.Empty

            Try

                EmployeeTimeZoneID = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT ISNULL(TIME_ZONE_ID, '') FROM EMPLOYEE WITH(NOLOCK) WHERE EMP_CODE = '{0}';", EmployeeCode)).FirstOrDefault

            Catch ex As Exception
                EmployeeTimeZoneID = String.Empty
            End Try

            LoadEmployeeTimeZoneID = EmployeeTimeZoneID

        End Function
        Private Function LoadSQLHoursOffset(DbContext As AdvantageFramework.Database.DbContext) As Decimal

            'objects
            Dim SQLHoursOffset As Decimal = 0.0
            Dim DatabaseTimeZoneID As String = String.Empty

            DatabaseTimeZoneID = LoadDatabaseTimeZoneID(DbContext)

            SQLHoursOffset = GetOffsetFromSystemTimeZone(DatabaseTimeZoneID)

            LoadSQLHoursOffset = SQLHoursOffset

        End Function
        Private Function LoadAgencyHoursOffset(DbContext As AdvantageFramework.Database.DbContext) As Decimal

            'objects
            Dim AgencyHoursOffset As Decimal = 0.0
            Dim AgencyTimeZoneID As String = String.Empty

            AgencyTimeZoneID = LoadAgencyTimeZoneID(DbContext)

            AgencyHoursOffset = GetOffsetFromSystemTimeZone(AgencyTimeZoneID)

            LoadAgencyHoursOffset = AgencyHoursOffset

        End Function
        Private Function LoadEmployeeHoursOffset(DbContext As AdvantageFramework.Database.DbContext, EmployeeCode As String) As Decimal

            'objects
            Dim EmployeeHoursOffset As Decimal = 0.0
            Dim EmployeeTimeZoneID As String = String.Empty

            EmployeeTimeZoneID = LoadEmployeeTimeZoneID(DbContext, EmployeeCode)

            EmployeeHoursOffset = GetOffsetFromSystemTimeZone(EmployeeTimeZoneID)

            LoadEmployeeHoursOffset = EmployeeHoursOffset

        End Function
        Private Function LoadTimeZoneOffsetForEmployee(DbContext As AdvantageFramework.Database.DbContext, EmployeeCode As String) As Decimal

            Dim Offset As Decimal = CType(0.0, Decimal)
            Dim DatabaseOffset As Decimal = CType(0.0, Decimal)
            Dim AgencyOffset As Decimal = CType(0.0, Decimal)
            Dim EmployeeOffset As Decimal = CType(0.0, Decimal)

            Try

                DatabaseOffset = LoadSQLHoursOffset(DbContext)

            Catch ex As Exception
                DatabaseOffset = 0
            End Try

            If DatabaseOffset <> 0 Then 'if not using UTC zero then must have a database setting to act as anchor for the offset!

                Try

                    AgencyOffset = LoadAgencyHoursOffset(DbContext)

                Catch ex As Exception
                    AgencyOffset = 0.0
                End Try
                Try

                    If String.IsNullOrWhiteSpace(EmployeeCode) = False Then

                        EmployeeOffset = LoadEmployeeHoursOffset(DbContext, EmployeeCode)

                    End If

                Catch ex As Exception
                    EmployeeOffset = 0.0
                End Try

                If EmployeeOffset = 0 Then

                    Offset = (AgencyOffset - DatabaseOffset) * -1

                Else

                    Offset = (EmployeeOffset - DatabaseOffset) * -1

                End If

            End If

            LoadTimeZoneOffsetForEmployee = Offset

        End Function
        Private Function LoadTimeZoneOffsetForEmployeeForceUtcZero(DbContext As AdvantageFramework.Database.DbContext, EmployeeCode As String) As Decimal

            Dim Offset As Decimal = CType(0.0, Decimal)
            Dim DatabaseOffset As Decimal = CType(0.0, Decimal)
            Dim AgencyOffset As Decimal = CType(0.0, Decimal)
            Dim EmployeeOffset As Decimal = CType(0.0, Decimal)

            Try

                If String.IsNullOrWhiteSpace(EmployeeCode) = False Then

                    EmployeeOffset = LoadEmployeeHoursOffset(DbContext, EmployeeCode)

                End If

                Offset = EmployeeOffset

            Catch ex As Exception
                EmployeeOffset = 0.0
            End Try

            If Offset = 0 Then

                Try

                    AgencyOffset = LoadAgencyHoursOffset(DbContext)

                Catch ex As Exception
                    AgencyOffset = 0.0
                End Try

                Offset = AgencyOffset

            End If

            If Offset = 0 Then

                Try

                    DatabaseOffset = LoadSQLHoursOffset(DbContext)

                Catch ex As Exception
                    DatabaseOffset = 0
                End Try

                Offset = DatabaseOffset

            End If

            LoadTimeZoneOffsetForEmployeeForceUtcZero = Offset

        End Function
        Private Function GetOffsetFromSystemTimeZone(TimeZoneID As String) As Decimal

            Dim Offset As Decimal = 0.0
            Dim TimeZone As TimeZoneInfo = Nothing

            If String.IsNullOrWhiteSpace(TimeZoneID) = False Then

                Try

                    TimeZone = TimeZoneInfo.FindSystemTimeZoneById(TimeZoneID)

                    If TimeZone IsNot Nothing Then

                        Offset = CType(TimeZone.BaseUtcOffset.Hours + (TimeZone.BaseUtcOffset.Minutes / 60), Decimal)

                        If TimeZone.IsDaylightSavingTime(Now.Date) = True Then

                            Offset += 1

                        End If

                    End If

                Catch ex As Exception
                    Offset = 0.0
                End Try

            End If

            GetOffsetFromSystemTimeZone = Offset

        End Function
        Private Function LoadTimeZoneInfo(DbContext As AdvantageFramework.Database.DbContext, EmployeeCode As String) As TimeZoneInfo

            Dim TimeZoneInfo As TimeZoneInfo = Nothing
            Dim Offset As Decimal = CType(0.0, Decimal)
            Dim DatabaseOffset As Decimal = CType(0.0, Decimal)
            Dim AgencyOffset As Decimal = CType(0.0, Decimal)
            Dim EmployeeOffset As Decimal = CType(0.0, Decimal)
            Dim DatabaseTimeZone As TimeZoneInfo = Nothing
            Dim AgencyTimeZone As TimeZoneInfo = Nothing
            Dim EmployeeTimeZone As TimeZoneInfo = Nothing
            Dim DatabaseTimeZoneID As String = String.Empty
            Dim AgencyTimeZoneID As String = String.Empty
            Dim EmployeeTimeZoneID As String = String.Empty

            Try

                DatabaseTimeZoneID = LoadDatabaseTimeZoneID(DbContext)

                DatabaseTimeZone = GetTimeZoneInfo(DatabaseTimeZoneID)

                DatabaseOffset = GetOffsetFromSystemTimeZone(DatabaseTimeZoneID)

            Catch ex As Exception
                DatabaseOffset = 0
            End Try

            If DatabaseOffset <> 0 Then 'if not using UTC zero then must have a database setting to act as anchor for the offset!

                Try

                    AgencyTimeZoneID = LoadAgencyTimeZoneID(DbContext)

                    AgencyTimeZone = GetTimeZoneInfo(AgencyTimeZoneID)

                    AgencyOffset = GetOffsetFromSystemTimeZone(AgencyTimeZoneID)

                Catch ex As Exception
                    AgencyOffset = 0.0
                End Try

                Try

                    If String.IsNullOrWhiteSpace(EmployeeCode) = False Then

                        EmployeeTimeZoneID = LoadEmployeeTimeZoneID(DbContext, EmployeeCode)

                        EmployeeTimeZone = GetTimeZoneInfo(EmployeeTimeZoneID)

                        EmployeeOffset = GetOffsetFromSystemTimeZone(EmployeeTimeZoneID)

                    End If

                Catch ex As Exception
                    EmployeeOffset = 0.0
                End Try

                If EmployeeOffset = 0 Then

                    TimeZoneInfo = AgencyTimeZone

                    Offset = (AgencyOffset - DatabaseOffset) * -1

                Else

                    TimeZoneInfo = EmployeeTimeZone

                    Offset = (EmployeeOffset - DatabaseOffset) * -1

                End If

            End If

            LoadTimeZoneInfo = TimeZoneInfo

        End Function
        Private Function GetTimeZoneInfo(TimeZoneID As String) As TimeZoneInfo

            Dim TimeZone As TimeZoneInfo = Nothing

            If String.IsNullOrWhiteSpace(TimeZoneID) = False Then

                Try

                    TimeZone = TimeZoneInfo.FindSystemTimeZoneById(TimeZoneID)

                Catch ex As Exception
                    TimeZone = Nothing
                End Try

            End If

            GetTimeZoneInfo = TimeZone

        End Function

        Public Sub ProcessOutlookCalendarTS(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext,
                                            ByVal Agency As AdvantageFramework.Database.Entities.Agency, ByVal LastRanAt As Date, ByVal Employee As AdvantageFramework.Database.Views.Employee)

            'objects
            Dim ExchangeService As Microsoft.Exchange.WebServices.Data.ExchangeService = Nothing
            Dim CalendarFolder As Microsoft.Exchange.WebServices.Data.CalendarFolder = Nothing
            Dim CalendarView As Microsoft.Exchange.WebServices.Data.CalendarView = Nothing
            Dim ExtendedProperty As Microsoft.Exchange.WebServices.Data.ExtendedProperty = Nothing
            Dim EmployeeTimeStaging As AdvantageFramework.Database.Entities.EmployeeTimeStaging = Nothing
            Dim AppointmentIDs As Generic.List(Of String) = Nothing
            Dim DayDifference As Integer = 0

            Try

                If String.IsNullOrWhiteSpace(Employee.Email) = False AndAlso String.IsNullOrWhiteSpace(Employee.EmailPassword) = False Then

                    WriteToEventLog("Attempting to login employee --> " & Employee.ToString)

                    ExchangeService = New Microsoft.Exchange.WebServices.Data.ExchangeService(Microsoft.Exchange.WebServices.Data.ExchangeVersion.Exchange2007_SP1)

                    ExchangeService.Credentials = New Microsoft.Exchange.WebServices.Data.WebCredentials(Employee.Email, AdvantageFramework.Security.Encryption.Decrypt(Employee.EmailPassword))
                    ExchangeService.AutodiscoverUrl(Employee.Email, AddressOf AdvantageFramework.Calendar.Outlook.RedirectionCallback)

                    CalendarFolder = Microsoft.Exchange.WebServices.Data.CalendarFolder.Bind(ExchangeService, Microsoft.Exchange.WebServices.Data.WellKnownFolderName.Calendar)
                    CalendarView = New Microsoft.Exchange.WebServices.Data.CalendarView(Now.AddDays(-30), Now.AddMonths(2))

                    AppointmentIDs = New Generic.List(Of String)

                    For Each Appointment In CalendarFolder.FindAppointments(CalendarView)

                        EmployeeTimeStaging = Nothing
                        ExtendedProperty = Nothing

                        WriteToEventLog("checking appointment --> " & Appointment.Subject)

                        AppointmentIDs.Add(Appointment.Id.UniqueId)

                        If Appointment.LastModifiedTime > LastRanAt Then

                            Try

                                ExtendedProperty = Appointment.ExtendedProperties.SingleOrDefault(Function(EP) EP.PropertyDefinition.Name = AdvantageFramework.Calendar.Outlook.ExtendedPropertyName)

                            Catch ex As Exception
                                ExtendedProperty = Nothing
                            End Try

                            If ExtendedProperty IsNot Nothing Then

                                Try

                                    EmployeeTimeStaging = AdvantageFramework.Database.Procedures.EmployeeTimeStaging.LoadByID(DbContext, ExtendedProperty.Value)

                                Catch ex As Exception
                                    EmployeeTimeStaging = Nothing
                                End Try

                            End If

                            If EmployeeTimeStaging Is Nothing Then

                                EmployeeTimeStaging = AdvantageFramework.Database.Procedures.EmployeeTimeStaging.Load(DbContext).SingleOrDefault(Function(Entity) Entity.OutlookID = Appointment.Id.UniqueId)

                            End If

                            If EmployeeTimeStaging Is Nothing Then

                                EmployeeTimeStaging = New AdvantageFramework.Database.Entities.EmployeeTimeStaging

                                EmployeeTimeStaging.DbContext = DbContext

                            End If

                        Else

                            Try

                                EmployeeTimeStaging = AdvantageFramework.Database.Procedures.EmployeeTimeStaging.Load(DbContext).SingleOrDefault(Function(Entity) Entity.OutlookID = Appointment.Id.UniqueId)

                            Catch ex As Exception
                                EmployeeTimeStaging = Nothing
                            End Try

                            If EmployeeTimeStaging Is Nothing Then

                                EmployeeTimeStaging = New AdvantageFramework.Database.Entities.EmployeeTimeStaging

                                EmployeeTimeStaging.DbContext = DbContext

                            Else

                                EmployeeTimeStaging = Nothing

                            End If

                        End If

                        If EmployeeTimeStaging IsNot Nothing Then

                            WriteToEventLog("processing appointment --> " & Appointment.Subject)

                            EmployeeTimeStaging.Comments = Appointment.Subject

                            EmployeeTimeStaging.OutlookID = Appointment.Id.UniqueId

                            If Appointment.IsAllDayEvent Then

                                'EmployeeNonTask.IsAllDay = 1

                                EmployeeTimeStaging.StartDate = Appointment.Start.ToShortDateString
                                EmployeeTimeStaging.EndDate = Appointment.End.ToShortDateString

                                EmployeeTimeStaging.StartTime = Appointment.Start.ToShortDateString & " " & Appointment.Start.ToLongTimeString
                                EmployeeTimeStaging.EndTime = Appointment.End.ToShortDateString & " 11:59 PM"

                            Else

                                'EmployeeNonTask.IsAllDay = 0

                                EmployeeTimeStaging.StartDate = Appointment.Start.ToShortDateString
                                EmployeeTimeStaging.EndDate = Appointment.End.ToShortDateString

                                EmployeeTimeStaging.StartTime = Appointment.Start.ToShortDateString & " " & Appointment.Start.ToLongTimeString
                                EmployeeTimeStaging.EndTime = Appointment.End.ToShortDateString & " " & Appointment.End.ToLongTimeString

                            End If

                            DayDifference = Math.Abs(DateDiff(DateInterval.Day, CDate(EmployeeTimeStaging.StartTime), CDate(EmployeeTimeStaging.EndTime)))

                            'If EmployeeNonTask.IsAllDay = 1 Then

                            '    If DayDifference = 0 Then

                            '        EmployeeNonTask.Hours = CDec(FormatNumber(Agency.StandardHours.GetValueOrDefault(0), 2))

                            '    Else

                            '        EmployeeNonTask.Hours = CDec(FormatNumber(Agency.StandardHours.GetValueOrDefault(0) * DayDifference, 2))

                            '    End If

                            'Else

                            If DayDifference = 0 Then

                                EmployeeTimeStaging.Hours = CDec(FormatNumber(CDate(EmployeeTimeStaging.EndTime).Subtract(CDate(EmployeeTimeStaging.StartTime)).TotalHours, 2))

                                If EmployeeTimeStaging.Hours > Agency.StandardHours.GetValueOrDefault(0) Then

                                    EmployeeTimeStaging.Hours = CDec(FormatNumber(Agency.StandardHours.GetValueOrDefault(0), 2))

                                End If

                            Else

                                EmployeeTimeStaging.Hours = CDec(FormatNumber(AdvantageFramework.EmployeeUtilities.LoadTotalHoursWorked(Employee, CDate(EmployeeTimeStaging.StartTime), CDate(EmployeeTimeStaging.EndTime)), 2))

                            End If

                            'End If

                            EmployeeTimeStaging.EmployeeCode = Employee.Code

                            If EmployeeTimeStaging.IsEntityBeingAdded() = False Then

                                If AdvantageFramework.Database.Procedures.EmployeeTimeStaging.Update(DbContext, EmployeeTimeStaging) Then

                                    If ExtendedProperty Is Nothing Then

                                        Appointment.SetExtendedProperty(New Microsoft.Exchange.WebServices.Data.ExtendedPropertyDefinition(AdvantageFramework.Calendar.Outlook.ExtendedPropertyGUID, AdvantageFramework.Calendar.Outlook.ExtendedPropertyName, Microsoft.Exchange.WebServices.Data.MapiPropertyType.Integer), EmployeeTimeStaging.ID)

                                    End If

                                    Appointment.Update(Microsoft.Exchange.WebServices.Data.ConflictResolutionMode.AlwaysOverwrite)

                                    WriteToEventLog("appointment updated --> " & Appointment.Subject)

                                Else

                                    WriteToEventLog("failed to update appointment --> " & Appointment.Subject)

                                End If

                            Else

                                If AdvantageFramework.Database.Procedures.EmployeeTimeStaging.Insert(DbContext, EmployeeTimeStaging) Then

                                    Try

                                        Appointment.SetExtendedProperty(New Microsoft.Exchange.WebServices.Data.ExtendedPropertyDefinition(AdvantageFramework.Calendar.Outlook.ExtendedPropertyGUID, AdvantageFramework.Calendar.Outlook.ExtendedPropertyName, Microsoft.Exchange.WebServices.Data.MapiPropertyType.Integer), EmployeeTimeStaging.ID)

                                        Appointment.Update(Microsoft.Exchange.WebServices.Data.ConflictResolutionMode.AlwaysOverwrite)

                                    Catch ex As Exception
                                        WriteToEventLog("failed to insert appointment --> " & Appointment.Subject & " --> " & ex.Message)
                                    End Try

                                Else

                                    WriteToEventLog("failed to insert appointment --> " & Appointment.Subject)

                                End If

                            End If

                        End If

                    Next

                    For Each EmployeeTimeStaging In AdvantageFramework.Database.Procedures.EmployeeTimeStaging.LoadByEmployeeCode(DbContext, Employee.Code).Where(Function(Entity) Entity.OutlookID IsNot Nothing).ToList.Where(Function(Entity) AppointmentIDs.Contains(Entity.OutlookID) = False).ToList

                        If AdvantageFramework.Database.Procedures.EmployeeTimeStaging.Delete(DbContext, EmployeeTimeStaging) Then

                            WriteToEventLog("deleted appointment --> " & EmployeeTimeStaging.Comments)

                        Else

                            WriteToEventLog("failed to deleted appointment --> " & EmployeeTimeStaging.Comments)

                        End If

                    Next

                Else

                    WriteToEventLog("failed loading employee calendar --> " & Employee.ToString & " --> employee does not have valid outlook settings")

                End If

            Catch ex As Exception
                WriteToEventLog("Error processing employee --> " & Employee.ToString & " --> " & ex.Message)
            End Try

        End Sub
        Public Sub ProcessDatabase(ByVal DatabaseProfile As AdvantageFramework.Database.DatabaseProfile)

            'objects
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim RunAtEvery As Integer = 0
            Dim LastRanAt As Date = Nothing
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing
            Dim SyncWithOutlook As Boolean = False
            Dim UseOutlookExchangeServer As Boolean = False
            Dim SyncWithGoogleCalendar As Boolean = False
            Dim SyncWithSugarCRM As Boolean = False

            If DatabaseProfile IsNot Nothing Then

                WriteToEventLog("Processing database --> " & DatabaseProfile.DatabaseName)

                Using DataContext = New AdvantageFramework.Database.DataContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                    Using DbContext = New AdvantageFramework.Database.DbContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                        LoadSettings(DataContext, RunAtEvery, LastRanAt)

                        Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                        AdvantageService = LoadAdvantageService(DataContext)

                        SyncWithOutlook = AdvantageFramework.Calendar.Outlook.IsSyncWithOutlookEnabled(DataContext)
                        UseOutlookExchangeServer = AdvantageFramework.Calendar.Outlook.OutlookExchangeServerEnabled(DataContext)
                        SyncWithGoogleCalendar = AdvantageFramework.Calendar.GoogleCal.IsSyncWithGoogleCalendarEnabled(DataContext)
                        SyncWithSugarCRM = AdvantageFramework.Calendar.SugarCRM.IsSyncWithSugarCRMEnabled(DataContext)

                        For Each Employee In AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActive(DbContext).ToList

                            WriteToEventLog("Processing employee --> " & Employee.ToString)

                            If SyncWithGoogleCalendar Then

                                If String.IsNullOrWhiteSpace(Employee.Email) = False AndAlso String.IsNullOrWhiteSpace(Employee.GoogleToken) = False AndAlso Employee.IgnoreCalendarSync = False Then

                                    WriteToEventLog("Processing Google Calendar --> " & Employee.ToString)

                                    ProcessGoogleCalendar(DbContext, DataContext, Agency, LastRanAt, Employee, DatabaseProfile.UseWindowsAuthentication)

                                End If

                            End If

                            If SyncWithSugarCRM Then

                                If String.IsNullOrWhiteSpace(Employee.SugarCRMUserName) = False AndAlso String.IsNullOrWhiteSpace(Employee.SugarCRMPassword) = False Then

                                    WriteToEventLog("Processing Sugar Calendar --> " & Employee.ToString)

                                    ProcessSugarCalendar(DbContext, DataContext, Agency, LastRanAt, Employee)

                                End If

                            End If

                            If SyncWithOutlook AndAlso UseOutlookExchangeServer Then

                                If String.IsNullOrWhiteSpace(Employee.Email) = False AndAlso String.IsNullOrWhiteSpace(Employee.EmailPassword) = False AndAlso Employee.IgnoreCalendarSync = False Then

                                    WriteToEventLog("Processing Outlook Calendar --> " & Employee.ToString)

                                    ProcessOutlookCalendar(DbContext, DataContext, Agency, LastRanAt, Employee)

                                End If

                            End If

                        Next

                        If AdvantageService IsNot Nothing Then

                            LastRanAt = Now

                            SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.Calendar.RegistrySetting.LastRanAt, LastRanAt)

                        End If

                    End Using

                End Using

            End If

        End Sub
        Public Function IsServiceReadyToRun(ByVal DatabaseProfile As AdvantageFramework.Database.DatabaseProfile) As Boolean

            'objects
            Dim ServiceIsReadyToRun As Boolean = False
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing
            Dim RunAtEvery As Integer = 0
            Dim LastRanAt As Date = Nothing

            If DatabaseProfile IsNot Nothing Then

                Try

                    Using DataContext = New AdvantageFramework.Database.DataContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                        AdvantageService = LoadAdvantageService(DataContext)

                        If AdvantageService IsNot Nothing Then

                            If AdvantageService.Enabled Then

                                Integer.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.Calendar.RegistrySetting.RunAtEvery), RunAtEvery)
                                DateTime.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.Calendar.RegistrySetting.LastRanAt), LastRanAt)

                                LastRanAt = LastRanAt.AddMinutes(RunAtEvery)

                                If DateDiff(DateInterval.Minute, LastRanAt, Now) >= 0 Then

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

            If System.Diagnostics.EventLog.SourceExists("Adv GoogleCal Source") = False Then

                System.Diagnostics.EventLog.CreateEventSource("Adv GoogleCal Source", "Adv GoogleCal Log")

            End If

            _EventLog = New System.Diagnostics.EventLog("Adv GoogleCal Log", My.Computer.Name, "Adv GoogleCal Source")

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

                AdvantageService = AdvantageFramework.Services.LoadAdvantageService(DataContext, AdvantageFramework.Services.Service.AdvantageCalendarWindowsService)

            Catch ex As Exception
                AdvantageService = Nothing
            End Try

            LoadAdvantageService = AdvantageService

        End Function
        Public Function LoadAdvantageServiceSetting(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AdvantageServiceID As Integer, ByVal RegistrySetting As AdvantageFramework.Services.Calendar.RegistrySetting) As AdvantageFramework.Database.Entities.AdvantageServiceSetting

            'objects
            Dim AdvantageServiceSetting As AdvantageFramework.Database.Entities.AdvantageServiceSetting = Nothing

            Try

                AdvantageServiceSetting = AdvantageFramework.Services.LoadAdvantageServiceSetting(DataContext, AdvantageServiceID, RegistrySetting.ToString)

            Catch ex As Exception
                AdvantageServiceSetting = Nothing
            End Try

            LoadAdvantageServiceSetting = AdvantageServiceSetting

        End Function
        Public Function LoadAdvantageServiceSettingValue(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AdvantageServiceID As Integer, ByVal RegistrySetting As AdvantageFramework.Services.Calendar.RegistrySetting) As Object

            'objects
            Dim SettingValue As Object = Nothing

            Try

                SettingValue = AdvantageFramework.Services.LoadAdvantageServiceSettingValue(DataContext, AdvantageServiceID, RegistrySetting.ToString)

            Catch ex As Exception
                SettingValue = Nothing
            End Try

            LoadAdvantageServiceSettingValue = SettingValue

        End Function
        Public Function SaveAdvantageServiceSettingValue(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AdvantageServiceID As Integer, ByVal RegistrySetting As AdvantageFramework.Services.Calendar.RegistrySetting, ByVal SettingValue As Object) As Boolean

            'objects
            Dim Saved As Boolean = False

            Try

                Saved = AdvantageFramework.Services.SaveAdvantageServiceSettingValue(DataContext, AdvantageServiceID, RegistrySetting.ToString, SettingValue)

            Catch ex As Exception
                Saved = False
            End Try

            SaveAdvantageServiceSettingValue = Saved

        End Function
        Public Sub LoadSettings(ByVal DataContext As AdvantageFramework.Database.DataContext, ByRef RunAtEvery As Integer, ByRef LastRanAt As Date)

            'objects
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing

            AdvantageService = LoadAdvantageService(DataContext)

            If AdvantageService IsNot Nothing Then

                Integer.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.Calendar.RegistrySetting.RunAtEvery), RunAtEvery)

                DateTime.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.Calendar.RegistrySetting.LastRanAt), LastRanAt)

            End If

        End Sub
        Public Sub SaveSettings(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal RunAtEvery As Integer, Optional ByVal LastRanAt As Date = Nothing)

            'objects
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing
            'Dim PreviousRunAtEvery As Integer = 0
            'Dim ServiceController As System.ServiceProcess.ServiceController = Nothing

            AdvantageService = LoadAdvantageService(DataContext)

            If AdvantageService IsNot Nothing Then

                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.Calendar.RegistrySetting.RunAtEvery, RunAtEvery)

                If LastRanAt <> Nothing Then

                    SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.Calendar.RegistrySetting.LastRanAt, LastRanAt)

                End If

            End If

            'Integer.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.Calendar.RegistrySetting.RunAtEvery), PreviousRunAtEvery)

            'SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.Calendar.RegistrySetting.RunAtEvery, RunAtEvery)

            'If LastRanAt <> Nothing Then

            '    SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.Calendar.RegistrySetting.LastRanAt, LastRanAt)

            'End If

            'If PreviousRunAtEvery <> RunAtEvery Then

            '    ServiceController = AdvantageFramework.Services.Load(AdvantageFramework.Services.Service.AdvantageGoogleCalendarWindowsService)

            '    If ServiceController IsNot Nothing AndAlso ServiceController.Status = ServiceProcess.ServiceControllerStatus.Running Then

            '        ServiceController.ExecuteCommand(AdvantageFramework.Services.Calendar.CustomCommand.LoadSettings)

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
