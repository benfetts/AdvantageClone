Namespace Calendar.SugarCRM

    <HideModuleName()> _
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum ActivityTypes
            Calls
            Meetings
        End Enum

        Public Enum CallProperties
            id
            name
            date_entered
            date_modified
            modified_user_id
            created_by
            description
            deleted
            assigned_user_id
            duration_hours
            duration_minutes
            date_start
            date_end
            parent_type
            status
            direction
            parent_id
            reminder_time
            email_reminder_time
            email_reminder_sent
            outlook_id
            repeat_type
            repeat_interval
            repeat_dow
            repeat_until
            repeat_count
            repeat_parent_id
            recurring_source
            advantage_id_c
        End Enum

        Public Enum CallUserProperties
            id
            call_id
            user_id
            required
            accept_status
            date_modified
            deleted
        End Enum

        Public Enum MeetingProperties
            id
            name
            date_entered
            date_modified
            modified_user_id
            created_by
            description
            deleted
            assigned_user_id
            location
            password
            join_url
            host_url
            displayed_url
            creator
            external_id
            duration_hours
            duration_minutes
            date_start
            date_end
            parent_type
            status
            type
            parent_id
            reminder_time
            email_reminder_time
            email_reminder_sent
            outlook_id
            sequence
            repeat_type
            repeat_interval
            repeat_dow
            repeat_until
            repeat_count
            repeat_parent_id
            recurring_source
            advantage_id_c
        End Enum

        Public Enum MeetingUserProperties
            id
            meeting_id
            user_id
            required
            accept_status
            date_modified
            deleted
        End Enum

        Public Enum UserProperties
            id
            user_name
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Function SyncEmployeeNonTask(ByVal ConnectionString As String, ByVal UserCode As String, ByVal EmployeeNonTaskID As Integer, ByVal IsDeleting As Boolean) As Boolean

            'objects
            Dim Syncd As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(ConnectionString, UserCode)

                    Using DataContext = New AdvantageFramework.Database.DataContext(ConnectionString, UserCode)

                        Syncd = SyncEmployeeNonTask(DbContext, DataContext, UserCode, AdvantageFramework.Database.Procedures.EmployeeNonTask.LoadByEmployeeNonTaskID(DbContext, EmployeeNonTaskID), IsDeleting)

                    End Using

                End Using

            Catch ex As Exception
                Syncd = False
            Finally
                SyncEmployeeNonTask = Syncd
            End Try

        End Function
        Public Function SyncEmployeeNonTask(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext,
                                            ByVal UserCode As String, ByVal EmployeeNonTask As AdvantageFramework.Database.Entities.EmployeeNonTask, ByVal IsDeleting As Boolean) As Boolean

            'objects
            Dim Syncd As Boolean = False
            Dim SugarCRMUrl As String = ""
            Dim AssignedToEmployee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim Employees As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing
            Dim SugarClient As SugarCRMRef.sugarsoap = Nothing
            Dim SugarUser As SugarCRMRef.user_auth = Nothing
            Dim LoginResult As SugarCRMRef.entry_value = Nothing
            Dim PropertyNames As Generic.List(Of String) = Nothing
            Dim SugarCRMNonTask As SugarCRMRef.entry_value = Nothing
            Dim SugarCRMNonTaskProperty As SugarCRMRef.name_value = Nothing
            Dim SugarActivityRelationship As SugarCRMRef.link_list2 = Nothing
            Dim ActivityType As ActivityTypes = ActivityTypes.Calls
            Dim SugarCRMResponse As SugarCRMRef.new_set_entry_result = Nothing
            Dim UserPropertyNames As Generic.List(Of String) = Nothing
            Dim SugarUsers As Generic.List(Of SugarCRMRef.entry_value) = Nothing
            Dim EmployeeCodes As Generic.List(Of String) = Nothing
            Dim SugarCRMNonTaskProperties As Generic.List(Of SugarCRMRef.name_value) = Nothing
            Dim SugarCRMSetRelationshipResponse As SugarCRMRef.new_set_relationship_list_result = Nothing
            Dim SugarCRMUserRelationship As SugarCRMRef.link_name_to_fields_array = Nothing
            'Dim SugarCRMEntry As SugarCRMRef.get_entry_result_version2 = Nothing
            Dim SugarCRMEntryList As SugarCRMRef.get_entry_list_result_version2 = Nothing
            'Dim SugarCRMUserRelationships() As SugarCRMRef.link_list2 = Nothing
            Dim SugarActivities As SugarCRMRef.get_entry_list_result_version2 = Nothing
            Dim SugarUserID As String = Nothing
            Dim TimeSpan As TimeSpan = Nothing

            Try

                If DbContext IsNot Nothing AndAlso DataContext IsNot Nothing AndAlso
                        EmployeeNonTask IsNot Nothing AndAlso (EmployeeNonTask.Type = "C" OrElse EmployeeNonTask.Type = "M") Then

                    Try

                        SugarCRMUrl = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.SYNC_SUGARCRM_URL.ToString).Value

                    Catch ex As Exception
                        SugarCRMUrl = ""
                    End Try

                    If String.IsNullOrEmpty(SugarCRMUrl) = False Then

                        Employees = AdvantageFramework.Database.Procedures.EmployeeView.Load(DbContext).ToList

                        If Employees IsNot Nothing Then

                            Try

                                AssignedToEmployee = Employees.SingleOrDefault(Function(Entity) Entity.Code = EmployeeNonTask.EmployeeCode)

                            Catch ex As Exception
                                AssignedToEmployee = Nothing
                            End Try

                            If AssignedToEmployee IsNot Nothing Then

                                If String.IsNullOrEmpty(AssignedToEmployee.SugarCRMUserName) = False AndAlso String.IsNullOrEmpty(AssignedToEmployee.SugarCRMPassword) = False Then

                                    If EmployeeNonTask.Type = "C" Then

                                        ActivityType = ActivityTypes.Calls

                                    Else

                                        ActivityType = ActivityTypes.Meetings

                                    End If

                                    SugarClient = New SugarCRMRef.sugarsoap()
                                    SugarClient.Timeout = 900000
                                    SugarClient.Url = SugarCRMUrl
                                    'SugarClient.Url = "http://localhost/ADVSugar/service/v4/soap.php"

                                    SugarUser = New SugarCRMRef.user_auth

                                    SugarUser.user_name = AssignedToEmployee.SugarCRMUserName
                                    SugarUser.password = CreateMD5Password(AssignedToEmployee.SugarCRMPassword)

                                    LoginResult = SugarClient.login(SugarUser, "Advantage", New SugarCRMRef.name_value() {New SugarCRMRef.name_value})

                                    If LoginResult.id <> "" Then

                                        PropertyNames = LoadSugarCRMPropertyNames(EmployeeNonTask.Type)
                                        UserPropertyNames = AdvantageFramework.EnumUtilities.GetEnumNameList(GetType(UserProperties), False)

                                        SugarCRMUserRelationship = New SugarCRMRef.link_name_to_fields_array
                                        SugarCRMUserRelationship.name = "users"
                                        SugarCRMUserRelationship.value = New String() {UserProperties.id.ToString, UserProperties.user_name.ToString}

                                        TimeSpan = (EmployeeNonTask.EndDateAndTime.Value - EmployeeNonTask.StartDateAndTime.Value)

                                        If String.IsNullOrEmpty(EmployeeNonTask.SugarCRMID) = False Then

                                            Try

                                                SugarActivities = SugarClient.get_entry_list(LoginResult.id, ActivityType.ToString, "assigned_user_id = '" & SugarClient.get_user_id(LoginResult.id) & "' AND date_start >= '" & AdvantageFramework.Calendar.SugarCRM.GetDateValue(EmployeeNonTask.StartDate) & "'", "", 0, PropertyNames.ToArray, New SugarCRMRef.link_name_to_fields_array() {SugarCRMUserRelationship}, 0, 1, False)

                                            Catch ex As Exception
                                                SugarActivities = Nothing
                                            End Try

                                            If SugarActivities IsNot Nothing Then

                                                Try

                                                    For Each SA In SugarActivities.entry_list

                                                        If SA.id = EmployeeNonTask.SugarCRMID Then

                                                            SugarCRMNonTask = SA
                                                            Exit For

                                                        End If

                                                    Next

                                                Catch ex As Exception
                                                    SugarCRMNonTask = Nothing
                                                End Try

                                                Try

                                                    SugarActivityRelationship = SugarActivities.relationship_list.ToList(SugarActivities.entry_list.ToList.IndexOf(SugarCRMNonTask))

                                                Catch ex As Exception
                                                    SugarActivityRelationship = Nothing
                                                End Try

                                            End If

                                        Else

                                            Try

                                                SugarCRMEntryList = SugarClient.get_entry_list(LoginResult.id, ActivityType.ToString, "advantage_id_c = '" & EmployeeNonTask.ID & "'", "", 0, PropertyNames.ToArray, New SugarCRMRef.link_name_to_fields_array() {SugarCRMUserRelationship}, 0, 0, False)

                                            Catch ex As Exception
                                                SugarCRMEntryList = Nothing
                                            End Try

                                            If SugarCRMEntryList IsNot Nothing Then

                                                Try

                                                    SugarCRMNonTask = SugarCRMEntryList.entry_list.SingleOrDefault

                                                Catch ex As Exception
                                                    SugarCRMNonTask = Nothing
                                                End Try

                                                'Try

                                                '    SugarCRMUserRelationships = SugarCRMEntryList.relationship_list

                                                'Catch ex As Exception
                                                '    SugarCRMUserRelationships = Nothing
                                                'End Try

                                            End If

                                        End If

                                        If SugarCRMNonTask IsNot Nothing Then

                                            If IsDeleting Then

                                                If EmployeeNonTask.Type = "C" Then

                                                    SetEntryValue(SugarCRMNonTask, CallProperties.deleted.ToString, 1)

                                                Else

                                                    SetEntryValue(SugarCRMNonTask, MeetingProperties.deleted.ToString, 1)

                                                End If

                                            Else

                                                If EmployeeNonTask.Type = "C" Then

                                                    SetEntryValue(SugarCRMNonTask, CallProperties.name.ToString, EmployeeNonTask.Description)
                                                    SetEntryValue(SugarCRMNonTask, CallProperties.description.ToString, EmployeeNonTask.NontaskDescription)
                                                    SetEntryValue(SugarCRMNonTask, CallProperties.duration_hours.ToString, Math.Abs(TimeSpan.Hours))
                                                    SetEntryValue(SugarCRMNonTask, CallProperties.duration_minutes.ToString, Math.Abs(TimeSpan.Minutes))
                                                    SetEntryValue(SugarCRMNonTask, CallProperties.date_start.ToString, GetDateValue(EmployeeNonTask.StartDateAndTime.Value))
                                                    SetEntryValue(SugarCRMNonTask, CallProperties.date_end.ToString, GetDateValue(EmployeeNonTask.EndDateAndTime.Value))
                                                    SetEntryValue(SugarCRMNonTask, CallProperties.assigned_user_id.ToString, SugarClient.get_user_id(LoginResult.id))
                                                    SetEntryValue(SugarCRMNonTask, CallProperties.advantage_id_c.ToString, EmployeeNonTask.ID)

                                                Else

                                                    SetEntryValue(SugarCRMNonTask, MeetingProperties.name.ToString, EmployeeNonTask.Description)
                                                    SetEntryValue(SugarCRMNonTask, MeetingProperties.description.ToString, EmployeeNonTask.NontaskDescription)
                                                    SetEntryValue(SugarCRMNonTask, MeetingProperties.duration_hours.ToString, Math.Abs(TimeSpan.Hours))
                                                    SetEntryValue(SugarCRMNonTask, MeetingProperties.duration_minutes.ToString, Math.Abs(TimeSpan.Minutes))
                                                    SetEntryValue(SugarCRMNonTask, MeetingProperties.date_start.ToString, GetDateValue(EmployeeNonTask.StartDateAndTime.Value))
                                                    SetEntryValue(SugarCRMNonTask, MeetingProperties.date_end.ToString, GetDateValue(EmployeeNonTask.EndDateAndTime.Value))
                                                    SetEntryValue(SugarCRMNonTask, MeetingProperties.assigned_user_id.ToString, SugarClient.get_user_id(LoginResult.id))
                                                    SetEntryValue(SugarCRMNonTask, MeetingProperties.advantage_id_c.ToString, EmployeeNonTask.ID)

                                                End If

                                            End If

                                            SugarCRMResponse = SugarClient.set_entry(LoginResult.id, ActivityType.ToString, SugarCRMNonTask.name_value_list)

                                            If SugarCRMResponse IsNot Nothing AndAlso String.IsNullOrEmpty(SugarCRMResponse.id) = False Then

                                                EmployeeNonTask.SugarCRMID = SugarCRMNonTask.id

                                                If AdvantageFramework.Database.Procedures.EmployeeNonTask.Update(DbContext, EmployeeNonTask) Then

                                                    If IsDeleting = False Then

                                                        If IsUserOnSugarActivity(AssignedToEmployee.SugarCRMUserName, SugarCRMNonTask, SugarActivityRelationship) = False Then

                                                            If ActivityType = ActivityTypes.Calls Then

                                                                SugarCRMNonTaskProperties = New Generic.List(Of SugarCRMRef.name_value)
                                                                SugarCRMNonTaskProperties.Add(New SugarCRMRef.name_value() With {.name = CallUserProperties.required.ToString, .value = "1"})
                                                                SugarCRMNonTaskProperties.Add(New SugarCRMRef.name_value() With {.name = CallUserProperties.accept_status.ToString, .value = "accept"})
                                                                SugarCRMNonTaskProperties.Add(New SugarCRMRef.name_value() With {.name = CallUserProperties.date_modified.ToString, .value = GetDateValue(Now)})
                                                                SugarCRMNonTaskProperties.Add(New SugarCRMRef.name_value() With {.name = CallUserProperties.deleted.ToString, .value = "0"})

                                                            Else

                                                                SugarCRMNonTaskProperties = New Generic.List(Of SugarCRMRef.name_value)
                                                                SugarCRMNonTaskProperties.Add(New SugarCRMRef.name_value() With {.name = MeetingUserProperties.required.ToString, .value = "1"})
                                                                SugarCRMNonTaskProperties.Add(New SugarCRMRef.name_value() With {.name = MeetingUserProperties.accept_status.ToString, .value = "accept"})
                                                                SugarCRMNonTaskProperties.Add(New SugarCRMRef.name_value() With {.name = MeetingUserProperties.date_modified.ToString, .value = GetDateValue(Now)})
                                                                SugarCRMNonTaskProperties.Add(New SugarCRMRef.name_value() With {.name = MeetingUserProperties.deleted.ToString, .value = "0"})

                                                            End If

                                                            SugarUserID = SugarClient.get_user_id(LoginResult.id)

                                                            SugarCRMSetRelationshipResponse = SugarClient.set_relationship(LoginResult.id, ActivityType.ToString, SugarCRMNonTask.id, "users", New String() {SugarUserID}, SugarCRMNonTaskProperties.ToArray, 0)

                                                        Else

                                                            SugarCRMSetRelationshipResponse = New SugarCRMRef.new_set_relationship_list_result
                                                            SugarCRMSetRelationshipResponse.failed = 0

                                                        End If

                                                        If SugarCRMSetRelationshipResponse IsNot Nothing AndAlso SugarCRMSetRelationshipResponse.failed = 0 Then

                                                            Syncd = True

                                                            Try

                                                                EmployeeCodes = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT EMP_CODE FROM dbo.EMP_NON_TASKS_EMPS WHERE NON_TASK_ID = {0}", EmployeeNonTask.ID)).ToList

                                                            Catch ex As Exception
                                                                EmployeeCodes = Nothing
                                                            End Try

                                                            Try

                                                                SugarUsers = GetSugarUsers(SugarClient, LoginResult, UserPropertyNames)

                                                            Catch ex As Exception
                                                                SugarUsers = Nothing
                                                            End Try

                                                            If EmployeeCodes IsNot Nothing AndAlso SugarUsers IsNot Nothing Then

                                                                For Each Employee In Employees.Where(Function(Entity) Entity.Code <> AssignedToEmployee.Code AndAlso Entity.SugarCRMUserName <> "").ToList

                                                                    SugarUserID = ""

                                                                    If DoesSugarUserExist(Employee.SugarCRMUserName, SugarUsers, SugarUserID) Then

                                                                        If IsUserOnSugarActivity(Employee.SugarCRMUserName, SugarCRMNonTask, SugarActivityRelationship) = False AndAlso EmployeeCodes.Contains(Employee.Code) Then

                                                                            If ActivityType = ActivityTypes.Calls Then

                                                                                SugarCRMNonTaskProperties = New Generic.List(Of SugarCRMRef.name_value)
                                                                                SugarCRMNonTaskProperties.Add(New SugarCRMRef.name_value() With {.name = CallUserProperties.required.ToString, .value = "1"})
                                                                                SugarCRMNonTaskProperties.Add(New SugarCRMRef.name_value() With {.name = CallUserProperties.accept_status.ToString, .value = "accept"})
                                                                                SugarCRMNonTaskProperties.Add(New SugarCRMRef.name_value() With {.name = CallUserProperties.date_modified.ToString, .value = GetDateValue(Now)})
                                                                                SugarCRMNonTaskProperties.Add(New SugarCRMRef.name_value() With {.name = CallUserProperties.deleted.ToString, .value = "0"})

                                                                            Else

                                                                                SugarCRMNonTaskProperties = New Generic.List(Of SugarCRMRef.name_value)
                                                                                SugarCRMNonTaskProperties.Add(New SugarCRMRef.name_value() With {.name = MeetingUserProperties.required.ToString, .value = "1"})
                                                                                SugarCRMNonTaskProperties.Add(New SugarCRMRef.name_value() With {.name = MeetingUserProperties.accept_status.ToString, .value = "accept"})
                                                                                SugarCRMNonTaskProperties.Add(New SugarCRMRef.name_value() With {.name = MeetingUserProperties.date_modified.ToString, .value = GetDateValue(Now)})
                                                                                SugarCRMNonTaskProperties.Add(New SugarCRMRef.name_value() With {.name = MeetingUserProperties.deleted.ToString, .value = "0"})

                                                                            End If

                                                                            SugarCRMSetRelationshipResponse = SugarClient.set_relationship(LoginResult.id, ActivityType.ToString, SugarCRMNonTask.id, "users", New String() {SugarUserID}, SugarCRMNonTaskProperties.ToArray, 0)

                                                                        ElseIf IsUserOnSugarActivity(Employee.SugarCRMUserName, SugarCRMNonTask, SugarActivityRelationship) AndAlso EmployeeCodes.Contains(Employee.Code) = False Then

                                                                            SugarCRMNonTaskProperties = New Generic.List(Of SugarCRMRef.name_value)

                                                                            SugarCRMSetRelationshipResponse = SugarClient.set_relationship(LoginResult.id, ActivityType.ToString, SugarCRMNonTask.id, "users", New String() {SugarUserID}, SugarCRMNonTaskProperties.ToArray, 1)

                                                                        End If

                                                                    End If

                                                                Next

                                                            End If

                                                        End If

                                                    Else

                                                        Syncd = True

                                                    End If

                                                End If

                                            End If

                                        Else

                                            If IsDeleting = False AndAlso String.IsNullOrEmpty(EmployeeNonTask.SugarCRMID) Then

                                                SugarCRMNonTask = New SugarCRMRef.entry_value

                                                SugarCRMNonTask.name_value_list = CreateNewNameValueList(PropertyNames)

                                                If EmployeeNonTask.Type = "C" Then

                                                    SetEntryValue(SugarCRMNonTask, CallProperties.name.ToString, EmployeeNonTask.Description)
                                                    SetEntryValue(SugarCRMNonTask, CallProperties.description.ToString, EmployeeNonTask.NontaskDescription)
                                                    SetEntryValue(SugarCRMNonTask, CallProperties.duration_hours.ToString, Math.Abs(TimeSpan.Hours))
                                                    SetEntryValue(SugarCRMNonTask, CallProperties.duration_minutes.ToString, Math.Abs(TimeSpan.Minutes))
                                                    SetEntryValue(SugarCRMNonTask, CallProperties.date_start.ToString, GetDateValue(EmployeeNonTask.StartDateAndTime.Value))
                                                    SetEntryValue(SugarCRMNonTask, CallProperties.date_end.ToString, GetDateValue(EmployeeNonTask.EndDateAndTime.Value))
                                                    SetEntryValue(SugarCRMNonTask, CallProperties.parent_type.ToString, "Accounts")
                                                    SetEntryValue(SugarCRMNonTask, CallProperties.direction.ToString, "Inbound")
                                                    SetEntryValue(SugarCRMNonTask, CallProperties.parent_id.ToString, "")
                                                    SetEntryValue(SugarCRMNonTask, CallProperties.assigned_user_id.ToString, SugarClient.get_user_id(LoginResult.id))
                                                    SetEntryValue(SugarCRMNonTask, CallProperties.advantage_id_c.ToString, EmployeeNonTask.ID)

                                                Else

                                                    SetEntryValue(SugarCRMNonTask, MeetingProperties.name.ToString, EmployeeNonTask.Description)
                                                    SetEntryValue(SugarCRMNonTask, MeetingProperties.description.ToString, EmployeeNonTask.NontaskDescription)
                                                    SetEntryValue(SugarCRMNonTask, MeetingProperties.duration_hours.ToString, Math.Abs(TimeSpan.Hours))
                                                    SetEntryValue(SugarCRMNonTask, MeetingProperties.duration_minutes.ToString, Math.Abs(TimeSpan.Minutes))
                                                    SetEntryValue(SugarCRMNonTask, MeetingProperties.date_start.ToString, GetDateValue(EmployeeNonTask.StartDateAndTime.Value))
                                                    SetEntryValue(SugarCRMNonTask, MeetingProperties.date_end.ToString, GetDateValue(EmployeeNonTask.EndDateAndTime.Value))
                                                    SetEntryValue(SugarCRMNonTask, MeetingProperties.assigned_user_id.ToString, SugarClient.get_user_id(LoginResult.id))
                                                    SetEntryValue(SugarCRMNonTask, MeetingProperties.advantage_id_c.ToString, EmployeeNonTask.ID)

                                                End If

                                                SugarCRMResponse = SugarClient.set_entry(LoginResult.id, ActivityType.ToString, SugarCRMNonTask.name_value_list)

                                                If SugarCRMResponse IsNot Nothing AndAlso String.IsNullOrEmpty(SugarCRMResponse.id) = False Then

                                                    EmployeeNonTask.SugarCRMID = SugarCRMResponse.id

                                                    If AdvantageFramework.Database.Procedures.EmployeeNonTask.Update(DbContext, EmployeeNonTask) Then

                                                        If ActivityType = ActivityTypes.Calls Then

                                                            SugarCRMNonTaskProperties = New Generic.List(Of SugarCRMRef.name_value)
                                                            SugarCRMNonTaskProperties.Add(New SugarCRMRef.name_value() With {.name = CallUserProperties.required.ToString, .value = "1"})
                                                            SugarCRMNonTaskProperties.Add(New SugarCRMRef.name_value() With {.name = CallUserProperties.accept_status.ToString, .value = "accept"})
                                                            SugarCRMNonTaskProperties.Add(New SugarCRMRef.name_value() With {.name = CallUserProperties.date_modified.ToString, .value = GetDateValue(Now)})
                                                            SugarCRMNonTaskProperties.Add(New SugarCRMRef.name_value() With {.name = CallUserProperties.deleted.ToString, .value = "0"})

                                                        Else

                                                            SugarCRMNonTaskProperties = New Generic.List(Of SugarCRMRef.name_value)
                                                            SugarCRMNonTaskProperties.Add(New SugarCRMRef.name_value() With {.name = MeetingUserProperties.required.ToString, .value = "1"})
                                                            SugarCRMNonTaskProperties.Add(New SugarCRMRef.name_value() With {.name = MeetingUserProperties.accept_status.ToString, .value = "accept"})
                                                            SugarCRMNonTaskProperties.Add(New SugarCRMRef.name_value() With {.name = MeetingUserProperties.date_modified.ToString, .value = GetDateValue(Now)})
                                                            SugarCRMNonTaskProperties.Add(New SugarCRMRef.name_value() With {.name = MeetingUserProperties.deleted.ToString, .value = "0"})

                                                        End If

                                                        SugarUserID = SugarClient.get_user_id(LoginResult.id)

                                                        SugarCRMSetRelationshipResponse = SugarClient.set_relationship(LoginResult.id, ActivityType.ToString, SugarCRMResponse.id, "users", New String() {SugarUserID}, SugarCRMNonTaskProperties.ToArray, 0)

                                                        If SugarCRMSetRelationshipResponse IsNot Nothing AndAlso SugarCRMSetRelationshipResponse.failed = 0 Then

                                                            Syncd = True

                                                            Try

                                                                EmployeeCodes = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT EMP_CODE FROM dbo.EMP_NON_TASKS_EMPS WHERE NON_TASK_ID = {0}", EmployeeNonTask.ID)).ToList

                                                            Catch ex As Exception
                                                                EmployeeCodes = Nothing
                                                            End Try

                                                            Try

                                                                SugarUsers = GetSugarUsers(SugarClient, LoginResult, UserPropertyNames)

                                                            Catch ex As Exception
                                                                SugarUsers = Nothing
                                                            End Try

                                                            If EmployeeCodes IsNot Nothing AndAlso SugarUsers IsNot Nothing Then

                                                                For Each Employee In Employees.Where(Function(Entity) EmployeeCodes.Contains(Entity.Code) AndAlso Entity.Code <> AssignedToEmployee.Code AndAlso Entity.SugarCRMUserName <> "").ToList

                                                                    SugarUserID = ""

                                                                    If DoesSugarUserExist(Employee.SugarCRMUserName, SugarUsers, SugarUserID) Then

                                                                        If ActivityType = ActivityTypes.Calls Then

                                                                            SugarCRMNonTaskProperties = New Generic.List(Of SugarCRMRef.name_value)
                                                                            SugarCRMNonTaskProperties.Add(New SugarCRMRef.name_value() With {.name = CallUserProperties.required.ToString, .value = "1"})
                                                                            SugarCRMNonTaskProperties.Add(New SugarCRMRef.name_value() With {.name = CallUserProperties.accept_status.ToString, .value = "accept"})
                                                                            SugarCRMNonTaskProperties.Add(New SugarCRMRef.name_value() With {.name = CallUserProperties.date_modified.ToString, .value = GetDateValue(Now)})
                                                                            SugarCRMNonTaskProperties.Add(New SugarCRMRef.name_value() With {.name = CallUserProperties.deleted.ToString, .value = "0"})

                                                                        Else

                                                                            SugarCRMNonTaskProperties = New Generic.List(Of SugarCRMRef.name_value)
                                                                            SugarCRMNonTaskProperties.Add(New SugarCRMRef.name_value() With {.name = MeetingUserProperties.required.ToString, .value = "1"})
                                                                            SugarCRMNonTaskProperties.Add(New SugarCRMRef.name_value() With {.name = MeetingUserProperties.accept_status.ToString, .value = "accept"})
                                                                            SugarCRMNonTaskProperties.Add(New SugarCRMRef.name_value() With {.name = MeetingUserProperties.date_modified.ToString, .value = GetDateValue(Now)})
                                                                            SugarCRMNonTaskProperties.Add(New SugarCRMRef.name_value() With {.name = MeetingUserProperties.deleted.ToString, .value = "0"})

                                                                        End If

                                                                        SugarCRMSetRelationshipResponse = SugarClient.set_relationship(LoginResult.id, ActivityType.ToString, SugarCRMResponse.id, "users", New String() {SugarUserID}, SugarCRMNonTaskProperties.ToArray, 0)

                                                                    End If

                                                                Next

                                                            End If

                                                        End If

                                                    End If

                                                End If

                                            End If

                                        End If

                                        SugarClient.logout(LoginResult.id)

                                    End If

                                End If

                            End If

                        End If

                    End If

                End If

            Catch ex As Exception
                Syncd = False
            Finally
                SyncEmployeeNonTask = Syncd
            End Try

        End Function
        Public Function GetSugarUsers(ByVal SugarClient As SugarCRMRef.sugarsoap, ByVal LoginResult As SugarCRMRef.entry_value, ByVal UserPropertyNames As Generic.List(Of String)) As Generic.List(Of SugarCRMRef.entry_value)

            'objects
            Dim SugarUsers As Generic.List(Of SugarCRMRef.entry_value) = Nothing
            Dim SugarUsersEntryList As SugarCRMRef.get_entry_list_result_version2 = Nothing
            Dim TotalCount As Integer = 0
            Dim Count As Integer = 0

            Try

                TotalCount = SugarClient.get_entries_count(LoginResult.id, "Users", "", 0).result_count

            Catch ex As Exception
                TotalCount = 0
            End Try

            Count = 0
            SugarUsers = New Generic.List(Of SugarCRMRef.entry_value)

            If TotalCount > 0 Then

                Do While Count < TotalCount

                    Try

                        SugarUsersEntryList = SugarClient.get_entry_list(LoginResult.id, "Users", "", "", Count, UserPropertyNames.ToArray, Nothing, 0, 0, False)

                    Catch ex As Exception
                        SugarUsersEntryList = Nothing
                    End Try

                    If SugarUsersEntryList IsNot Nothing Then

                        Count += SugarUsersEntryList.result_count

                        SugarUsers.AddRange(SugarUsersEntryList.entry_list.ToList)

                    Else

                        Exit Do

                    End If

                Loop

            End If

            GetSugarUsers = SugarUsers

        End Function
        Public Function IsUserOnSugarActivity(ByVal SugarCRMUserName As String, ByVal SugarCRMNonTask As SugarCRMRef.entry_value, ByVal SugarCRMUserRelationships As SugarCRMRef.link_list2) As Boolean

            'objects
            Dim SugarUserExists As Boolean = False
            Dim NameValue As SugarCRMRef.name_value = Nothing

            Try

                For Each LinkValue In SugarCRMUserRelationships.link_list

                    For Each Record In LinkValue.records

                        For Each RecordLinkValue In Record.link_value

                            If RecordLinkValue.name = UserProperties.user_name.ToString AndAlso RecordLinkValue.value = SugarCRMUserName Then

                                SugarUserExists = True
                                Exit For

                            End If

                        Next

                        If SugarUserExists Then

                            Exit For

                        End If

                    Next

                    If SugarUserExists Then

                        Exit For

                    End If

                Next

            Catch ex As Exception
                SugarUserExists = False
            Finally
                IsUserOnSugarActivity = SugarUserExists
            End Try

        End Function
        Public Function DoesSugarUserExist(ByVal SugarCRMUserName As String, ByVal SugarUsers As Generic.List(Of SugarCRMRef.entry_value), ByRef SugarUserID As String) As Boolean

            'objects
            Dim SugarUserExists As Boolean = False
            Dim NameValue As SugarCRMRef.name_value = Nothing

            Try

                For Each EntryValue In SugarUsers

                    NameValue = Nothing

                    Try

                        NameValue = EntryValue.name_value_list.SingleOrDefault(Function(NV) NV.name = UserProperties.user_name.ToString)

                    Catch ex As Exception
                        NameValue = Nothing
                    End Try

                    If NameValue IsNot Nothing Then

                        If NameValue.value = SugarCRMUserName Then

                            SugarUserID = EntryValue.id
                            SugarUserExists = True
                            Exit For

                        End If

                    End If

                Next

            Catch ex As Exception
                SugarUserExists = False
            Finally
                DoesSugarUserExist = SugarUserExists
            End Try

        End Function
        Public Function GetDateValue(ByVal DateValue As Date) As String

            'objects
            Dim EntryValue As String = ""
            Dim DateUTC As Date = Nothing

            DateUTC = DateValue.ToUniversalTime

            EntryValue = Format(DateUTC.Year, "####") & "-" & Format(DateUTC.Month, "0#") & "-" & Format(DateUTC.Day, "0#") & " " & Format(DateUTC.Hour, "0#") & ":" & Format(DateUTC.Minute, "0#") & ":" & Format(DateUTC.Second, "0#")

            GetDateValue = EntryValue

        End Function
        Public Function GetEntryValue(ByVal SugarCRMNonTask As SugarCRMRef.entry_value, ByVal Name As String) As String

            'objects
            Dim EntryValue As String = ""
            Dim SugarCRMNonTaskProperty As SugarCRMRef.name_value = Nothing

            Try

                SugarCRMNonTaskProperty = SugarCRMNonTask.name_value_list.SingleOrDefault(Function(NV) NV.name = Name)

            Catch ex As Exception
                SugarCRMNonTaskProperty = Nothing
            End Try

            If SugarCRMNonTaskProperty IsNot Nothing Then

                EntryValue = SugarCRMNonTaskProperty.value

            End If

            GetEntryValue = EntryValue

        End Function
        Public Function SetEntryValue(ByVal SugarCRMNonTask As SugarCRMRef.entry_value, ByVal Name As String, ByVal Value As String) As Boolean

            'objects
            Dim EntryValueSet As Boolean = False
            Dim SugarCRMNonTaskProperty As SugarCRMRef.name_value = Nothing

            Try

                SugarCRMNonTaskProperty = SugarCRMNonTask.name_value_list.SingleOrDefault(Function(NV) NV.name = Name)

            Catch ex As Exception
                SugarCRMNonTaskProperty = Nothing
            End Try

            If SugarCRMNonTaskProperty IsNot Nothing Then

                SugarCRMNonTaskProperty.value = Value

                EntryValueSet = True

            End If

            SetEntryValue = EntryValueSet

        End Function
        Public Function CreateNewNameValueList(ByVal PropertyNames As Generic.List(Of String)) As SugarCRMRef.name_value()

            'objects
            Dim NameValueList As Generic.List(Of SugarCRMRef.name_value) = Nothing
            Dim NameValue As SugarCRMRef.name_value = Nothing

            NameValueList = New Generic.List(Of SugarCRMRef.name_value)

            For Each PropertyName In PropertyNames

                NameValue = New SugarCRMRef.name_value

                NameValue.name = PropertyName

                NameValueList.Add(NameValue)

            Next

            CreateNewNameValueList = NameValueList.ToArray

        End Function
        Public Function LoadSugarCRMPropertyNames(ByVal EmployeeNonTaskType As String) As Generic.List(Of String)

            'objects
            Dim PropertyNames As Generic.List(Of String) = Nothing

            PropertyNames = New Generic.List(Of String)

            If EmployeeNonTaskType = "C" Then

                PropertyNames = AdvantageFramework.EnumUtilities.GetEnumNameList(GetType(CallProperties), False)

            ElseIf EmployeeNonTaskType = "M" Then

                PropertyNames = AdvantageFramework.EnumUtilities.GetEnumNameList(GetType(MeetingProperties), False)

            End If

            LoadSugarCRMPropertyNames = PropertyNames

        End Function
        Public Function LoadMeetings() As Boolean

            'objects
            Dim Syncd As Boolean = False

            Try

                Dim SugarClient As SugarCRMRef.sugarsoap = Nothing
                Dim SugarUser As SugarCRMRef.user_auth = Nothing
                Dim LoginList As SugarCRMRef.name_value = Nothing
                Dim LoginResult As SugarCRMRef.entry_value = Nothing
                Dim PropertyNames As Generic.List(Of String) = Nothing

                SugarClient = New SugarCRMRef.sugarsoap()
                SugarClient.Timeout = 900000
                SugarClient.Url = "http://localhost/ADVSugar/service/v4/soap.php"

                SugarUser = New SugarCRMRef.user_auth

                SugarUser.user_name = "admin"
                SugarUser.password = CreateMD5Password("Advantage!1")

                LoginList = New SugarCRMRef.name_value()

                LoginResult = SugarClient.login(SugarUser, "SoapTest", New SugarCRMRef.name_value() {LoginList})

                If LoginResult.id <> "" Then

                    PropertyNames = LoadSugarCRMPropertyNames("C")

                    For Each EntryValue In SugarClient.get_entry_list(LoginResult.id, "Calls", "assigned_user_id = '" & SugarClient.get_user_id(LoginResult.id) & "' AND advantage_id_c = '114'", "", 0, PropertyNames.ToArray, Nothing, 0, 0, False).entry_list

                        For Each NameValue In SugarClient.get_entry(LoginResult.id, "Calls", EntryValue.id, PropertyNames.ToArray, Nothing, True).entry_list

                            For Each NameValueField In NameValue.name_value_list

                                If NameValueField.name = CallProperties.advantage_id_c.ToString Then

                                    NameValueField.value = ""

                                ElseIf NameValueField.name = CallProperties.id.ToString Then

                                    NameValueField.value = ""

                                ElseIf NameValueField.name = CallProperties.name.ToString Then

                                    NameValueField.value = "Copy Test"

                                End If

                            Next

                            NameValue.id = ""

                            SugarClient.set_entry(LoginResult.id, "Calls", NameValue.name_value_list)

                        Next

                    Next

                    For Each EntryValue In SugarClient.get_entry_list(LoginResult.id, "Calls", "assigned_user_id = '" & SugarClient.get_user_id(LoginResult.id) & "'", "", 0, PropertyNames.ToArray, Nothing, 0, 0, False).entry_list

                        For Each NameValue In SugarClient.get_entry(LoginResult.id, "Calls", EntryValue.id, PropertyNames.ToArray, Nothing, True).entry_list

                            For Each NameValueField In NameValue.name_value_list

                                If NameValueField.name = CallProperties.advantage_id_c.ToString Then

                                    Console.WriteLine(NameValueField.name & "    " & NameValueField.value)

                                End If

                            Next

                        Next

                    Next

                End If

            Catch ex As Exception
                Syncd = False
            Finally
                LoadMeetings = Syncd
            End Try

        End Function
        Public Function CreateMD5Password(ByVal Password As String) As String

            'objects
            Dim MD5Password As String = ""
            Dim MD5 As System.Security.Cryptography.MD5 = Nothing
            Dim InputBuffer() As Byte = Nothing
            Dim OutputBuffer() As Byte = Nothing
            Dim StringBuilder As System.Text.StringBuilder = Nothing

            MD5 = System.Security.Cryptography.MD5.Create()

            InputBuffer = System.Text.Encoding.ASCII.GetBytes(Password)
            OutputBuffer = MD5.ComputeHash(InputBuffer)

            StringBuilder = New System.Text.StringBuilder(OutputBuffer.Length)

            For Index As Integer = 0 To OutputBuffer.Length - 1 Step 1

                StringBuilder.Append(OutputBuffer(Index).ToString("X2"))

            Next Index

            MD5Password = StringBuilder.ToString

            CreateMD5Password = MD5Password

        End Function
        Public Function IsSyncWithSugarCRMEnabled(ByVal DataContext As AdvantageFramework.Database.DataContext) As Boolean

            'objects
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim SugarCRMEnabled As Boolean = True

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.SYNC_SUGARCRM.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing Then

                If IsNumeric(Setting.Value) Then

                    If Setting.Value = 0 Then

                        SugarCRMEnabled = False

                    End If

                End If

            End If

            IsSyncWithSugarCRMEnabled = SugarCRMEnabled

        End Function

#End Region

    End Module

End Namespace
