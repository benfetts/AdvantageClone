Namespace Security.Setup.Presentation

    Public Class UserSetupForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _LoadUserModuleAccess As Boolean = False
        Private _LoadUserUserSettings As Boolean = False
        Private _LoadUserDetails As Boolean = False
        Private _SavingUserSettings As Boolean = False
        Private _UserList As Generic.List(Of AdvantageFramework.Security.Database.Entities.User) = Nothing
        Private _MediaToolsUsersQuantity As Integer = 0
        Private _AvailableMediaToolsUsers As Integer = 0
        Private _PowerUsersQuantity As Integer = 0
        Private _WVOnlyUsersQuantity As Integer = 0
        Private _APIUsersQuantity As Integer = 0
        'Private _ClientPortalUsersQuantity As Integer = 0
        Private _DisableInactiveCheckedChanged As Boolean = False
        Private _IsAgencyASP As Boolean = False

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub LoadUsers(ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext)

            Dim IsActiveFilterString As Boolean = False

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            IsActiveFilterString = DataGridViewLeftSection_Users.CurrentView.ActiveFilterEnabled

            DataGridViewLeftSection_Users.CurrentView.ActiveFilterEnabled = False

            'If ButtonItemEmployees_Terminated.Checked Then

            '    DataGridViewLeftSection_Users.DataSource = AdvantageFramework.Security.Database.Procedures.User.Load(SecurityDbContext).Include("Employee").Include("Employee.Department").OrderBy(Function(User) User.UserCode).ToList

            'Else

            '    DataGridViewLeftSection_Users.DataSource = AdvantageFramework.Security.Database.Procedures.User.Load(SecurityDbContext).Include("Employee").Include("Employee.Department").Where(Function(User) User.Employee.TerminationDate Is Nothing).OrderBy(Function(User) User.UserCode).ToList

            'End If

            DataGridViewLeftSection_Users.ItemDescription = "User(s)"

            DataGridViewLeftSection_Users.DataSource = LoadUsers(SecurityDbContext, ButtonItemEmployees_Terminated.Checked)

            If IsActiveFilterString Then

                DataGridViewLeftSection_Users.CurrentView.ActiveFilterEnabled = True

            End If

            'DataGridViewLeftSection_Users.RemoveColumnFromUser("IsEmployeeTerminated")
            DataGridViewLeftSection_Users.RemoveColumnFromUser("MediaToolUserSetting")

            DataGridViewLeftSection_Users.CurrentView.BestFitColumns()

            If DataGridViewLeftSection_Users.HasRows = False Then

                ClearUserDetail()

            End If

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

        End Sub
        Private Function LoadUsers(SecurityDbContext As AdvantageFramework.Security.Database.DbContext, LoadTerminatedEmployees As Boolean) As Generic.List(Of AdvantageFramework.Security.Classes.UserWithLicenseKeyInfo)

            Dim Users As Generic.List(Of AdvantageFramework.Security.Classes.UserWithLicenseKeyInfo) = Nothing

            Try

                Users = SecurityDbContext.Database.SqlQuery(Of AdvantageFramework.Security.Classes.UserWithLicenseKeyInfo)("SELECT 
	                                                                                                                                [ID] = SU.SEC_USER_ID,
	                                                                                                                                [UserCode] = SU.USER_CODE,
	                                                                                                                                [UserName] = SU.USER_NAME,
	                                                                                                                                [Inactive] = SU.IS_INACTIVE,
	                                                                                                                                [EmployeeCode] = SU.EMP_CODE,
	                                                                                                                                [EmployeeName] = COALESCE(RTRIM(E.EMP_FNAME) + ' ', '') + COALESCE(E.EMP_MI + '. ', '') + COALESCE(E.EMP_LNAME, ''),
	                                                                                                                                [IsEmployeeTerminated] = CAST(CASE WHEN E.EMP_TERM_DATE IS NULL THEN 0 ELSE 1 END AS bit),
	                                                                                                                                [IsPowerUser] = CAST(CASE WHEN ISNULL(SUS.STRING_VALUE, 'N') = 'N' THEN 1 ELSE 0 END AS bit),
                                                                                                                                    [IsWVOnlyUser] = CAST(CASE WHEN ISNULL(SUS.STRING_VALUE, 'N') = 'N' THEN 0 ELSE 1 END AS bit),
	                                                                                                                                [MediaToolUserSetting] = ISNULL(SUSMT.STRING_VALUE, ''),
	                                                                                                                                [OfficeCode] = E.OFFICE_CODE,
	                                                                                                                                [OfficeName] = O.OFFICE_NAME,
	                                                                                                                                [DepartmentCode] = E.DP_TM_CODE,
	                                                                                                                                [DepartmentName] = DT.DP_TM_DESC
                                                                                                                                FROM
	                                                                                                                                dbo.SEC_USER AS SU 
	                                                                                                                                INNER JOIN dbo.EMPLOYEE AS E ON E.EMP_CODE = SU.EMP_CODE
	                                                                                                                                INNER JOIN dbo.DEPT_TEAM AS DT ON DT.DP_TM_CODE = E.DP_TM_CODE
	                                                                                                                                LEFT OUTER JOIN dbo.OFFICE AS O ON O.OFFICE_CODE = E.OFFICE_CODE
	                                                                                                                                LEFT OUTER JOIN dbo.SEC_USER_SETTING AS SUS ON SUS.SEC_USER_ID = SU.SEC_USER_ID 
												                                                                                                                                   AND SUS.SETTING_CODE = 'TIME_ENTRY_ONLY'
	                                                                                                                                LEFT OUTER JOIN dbo.SEC_USER_SETTING AS SUSMT ON SUSMT.SEC_USER_ID = SU.SEC_USER_ID 
													                                                                                                                                 AND SUSMT.SETTING_CODE = 'IsMediaToolsUser'").ToList

            Catch ex As Exception
                Users = New Generic.List(Of AdvantageFramework.Security.Classes.UserWithLicenseKeyInfo)
            End Try

            If LoadTerminatedEmployees = False Then

                Users = Users.Where(Function(Entity) Entity.IsEmployeeTerminated = False).ToList

            End If

            LoadUsers = Users

        End Function
        Private Sub LoadUsers()

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                LoadUsers(SecurityDbContext)

            End Using

        End Sub
        Private Sub LoadUserReportAccess()

            If _UserList IsNot Nothing AndAlso _UserList.Count > 0 Then

                DataGridViewReportAccess_Reports.Enabled = True

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    DataGridViewReportAccess_Reports.DataSource = (From Report In AdvantageFramework.Security.Database.Procedures.Report.LoadAllActive(SecurityDbContext).OrderBy(Function(Rpt) Rpt.Type).ThenBy(Function(Rpt) Rpt.Number).ThenBy(Function(Rpt) Rpt.Category).ThenBy(Function(Rpt) Rpt.Name).ToList
                                                                   Select New AdvantageFramework.Security.Database.Classes.ReportAccess(Report, Me.Session, _UserList)).ToList

                End Using

            Else

                DataGridViewReportAccess_Reports.Enabled = False

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    DataGridViewReportAccess_Reports.DataSource = (From Report In AdvantageFramework.Security.Database.Procedures.Report.LoadAllActive(SecurityDbContext).OrderBy(Function(Rpt) Rpt.Type).ThenBy(Function(Rpt) Rpt.Number).ThenBy(Function(Rpt) Rpt.Category).ThenBy(Function(Rpt) Rpt.Name).ToList
                                                                   Select New AdvantageFramework.Security.Database.Classes.ReportAccess(Report)).ToList

                End Using

            End If

            DataGridViewReportAccess_Reports.CurrentView.BestFitColumns()

            TabItemUserDetails_ReportAccessTab.Tag = True

        End Sub
        Private Sub CreateNewUserSetting(UserID As Integer,
                                         SettingCode As String, StringValue As String,
                                         NumericValue As System.Nullable(Of Decimal), DateValue As System.Nullable(Of Date),
                                         ByRef UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting)

            UserSetting = New AdvantageFramework.Security.Database.Entities.UserSetting

            UserSetting.UserID = UserID
            UserSetting.SettingCode = SettingCode
            UserSetting.StringValue = StringValue
            UserSetting.NumericValue = NumericValue
            UserSetting.DateValue = DateValue

        End Sub
        Private Sub SaveUserSettings(ByVal CheckBox As AdvantageFramework.WinForm.Presentation.Controls.CheckBox)

            'objects
            Dim AllUserSettingList As Generic.List(Of AdvantageFramework.Security.Database.Entities.UserSetting) = Nothing
            Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing
            Dim AllowSavingWebvantageOnlySetting As Boolean = False
            Dim UserIDs() As Integer = Nothing
            Dim UserInfos As Generic.List(Of AdvantageFramework.Security.Classes.UserWithLicenseKeyInfo) = Nothing
            Dim UserInfo As AdvantageFramework.Security.Classes.UserWithLicenseKeyInfo = Nothing
            Dim RefreshUserData As Boolean = False

            If _SavingUserSettings = False AndAlso _LoadUserUserSettings = False AndAlso _LoadUserDetails = False AndAlso _UserList IsNot Nothing AndAlso _UserList.Count > 0 Then

                _SavingUserSettings = True

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    SecurityDbContext.Database.Connection.Open()

                    UserIDs = _UserList.Select(Function(Entity) Entity.ID).ToArray

                    UserInfos = DataGridViewLeftSection_Users.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Security.Classes.UserWithLicenseKeyInfo).ToList

                    If CheckBox.Name <> CheckBoxUserSettings_CheckForUserAccess.Name Then

                        AllUserSettingList = (From Entity In SecurityDbContext.UserSettings
                                              Where UserIDs.Contains(Entity.UserID)
                                              Select Entity).ToList

                        For Each User In _UserList

                            AllowSavingWebvantageOnlySetting = False

                            If CheckBox.Name <> CheckBoxUserSettings_CheckForUserAccess.Name Then

                                Try

                                    UserSetting = AllUserSettingList.SingleOrDefault(Function(Entity) Entity.UserID = User.ID AndAlso Entity.SettingCode = CheckBox.Tag)

                                Catch ex As Exception
                                    UserSetting = Nothing
                                End Try

                            End If

                            Select Case CheckBox.Name

                                Case CheckBoxUserSettings_LimitPOsToEmployeeCodeAttached.Name

                                    If UserSetting Is Nothing Then

                                        'AdvantageFramework.Security.Database.Procedures.UserSetting.Insert(SecurityDbContext, User.ID, AdvantageFramework.Security.UserSettings.PR_PO_DO_OWN.ToString, IIf(CheckBoxUserSettings_LimitPOsToEmployeeCodeAttached.Checked, "Y", "N"), Nothing, Nothing, UserSetting)
                                        CreateNewUserSetting(User.ID, AdvantageFramework.Security.UserSettings.PR_PO_DO_OWN.ToString, IIf(CheckBoxUserSettings_LimitPOsToEmployeeCodeAttached.Checked, "Y", "N"), Nothing, Nothing, UserSetting)

                                        SecurityDbContext.UserSettings.Add(UserSetting)

                                    Else

                                        UserSetting.StringValue = IIf(CheckBoxUserSettings_LimitPOsToEmployeeCodeAttached.Checked, "Y", "N")

                                        'AdvantageFramework.Security.Database.Procedures.UserSetting.Update(SecurityDbContext, UserSetting)

                                    End If

                                Case CheckBoxUserSettings_LimitTimeEntryToEmployeeCodeAttached.Name

                                    If UserSetting Is Nothing Then

                                        CreateNewUserSetting(User.ID, AdvantageFramework.Security.UserSettings.SI_DO_OWN_TS.ToString, IIf(CheckBoxUserSettings_LimitTimeEntryToEmployeeCodeAttached.Checked, "Y", "N"), Nothing, Nothing, UserSetting)

                                        SecurityDbContext.UserSettings.Add(UserSetting)

                                    Else

                                        UserSetting.StringValue = IIf(CheckBoxUserSettings_LimitTimeEntryToEmployeeCodeAttached.Checked, "Y", "N")

                                        'AdvantageFramework.Security.Database.Procedures.UserSetting.Update(SecurityDbContext, UserSetting)

                                    End If

                                Case CheckBoxUserSettings_LimitTimesheetFunctionsForEmployee.Name

                                    If UserSetting Is Nothing Then

                                        CreateNewUserSetting(User.ID, AdvantageFramework.Security.UserSettings.EMP_TS_FNC.ToString, IIf(CheckBoxUserSettings_LimitTimesheetFunctionsForEmployee.Checked, "Y", "N"), Nothing, Nothing, UserSetting)

                                        SecurityDbContext.UserSettings.Add(UserSetting)

                                    Else

                                        UserSetting.StringValue = IIf(CheckBoxUserSettings_LimitTimesheetFunctionsForEmployee.Checked, "Y", "N")

                                        'AdvantageFramework.Security.Database.Procedures.UserSetting.Update(SecurityDbContext, UserSetting)

                                    End If

                                Case CheckBoxUserSettings_IsWebvantageUserOnly.Name

                                    If CheckBoxUserSettings_IsWebvantageUserOnly.Checked Then

                                        'If User.IsAdvanAdmin Then

                                        '    AllowSavingWebvantageOnlySetting = False

                                        '    If _UserList.Count = 1 Then

                                        '        CheckBoxUserSettings_IsWebvantageUserOnly.Checked = False
                                        '        AdvantageFramework.WinForm.MessageBox.Show("A user cannot be marked Webvantage Only when that user is an Advantage Admin.")

                                        '    End If

                                        'Else

                                        '    AllowSavingWebvantageOnlySetting = True

                                        'End If

                                        AllowSavingWebvantageOnlySetting = True

                                    Else

                                        AllowSavingWebvantageOnlySetting = True

                                    End If

                                    If AllowSavingWebvantageOnlySetting Then

                                        If UserSetting Is Nothing Then

                                            CreateNewUserSetting(User.ID, AdvantageFramework.Security.UserSettings.TIME_ENTRY_ONLY.ToString, IIf(CheckBoxUserSettings_IsWebvantageUserOnly.Checked, "Y", "N"), Nothing, Nothing, UserSetting)

                                            SecurityDbContext.UserSettings.Add(UserSetting)

                                            AdvantageFramework.Security.LicenseKey.ClearUser(Me.Session, User.ID, "")

                                        Else

                                            UserSetting.StringValue = IIf(CheckBoxUserSettings_IsWebvantageUserOnly.Checked, "Y", "N")

                                            'If AdvantageFramework.Security.Database.Procedures.UserSetting.Update(SecurityDbContext, UserSetting) Then

                                            AdvantageFramework.Security.LicenseKey.ClearUser(Me.Session, User.ID, "")

                                            'End If

                                        End If

                                        Try

                                            UserInfo = UserInfos.SingleOrDefault(Function(Entity) Entity.ID = User.ID)

                                        Catch ex As Exception
                                            UserInfo = Nothing
                                        End Try

                                        If UserInfo IsNot Nothing Then

                                            If CheckBoxUserSettings_IsWebvantageUserOnly.Checked Then

                                                UserInfo.IsWVOnlyUser = True
                                                UserInfo.IsPowerUser = False

                                            Else

                                                UserInfo.IsWVOnlyUser = False
                                                UserInfo.IsPowerUser = True

                                            End If

                                            RefreshUserData = True

                                        End If

                                    End If

                                Case CheckBoxUserSettings_AllowProfileUpdate.Name

                                    If UserSetting Is Nothing Then

                                        CreateNewUserSetting(User.ID, AdvantageFramework.Security.UserSettings.AllowProfileUpdate.ToString, IIf(CheckBoxUserSettings_AllowProfileUpdate.Checked, "Y", "N"), Nothing, Nothing, UserSetting)

                                        SecurityDbContext.UserSettings.Add(UserSetting)

                                    Else

                                        UserSetting.StringValue = IIf(CheckBoxUserSettings_AllowProfileUpdate.Checked, "Y", "N")

                                        'AdvantageFramework.Security.Database.Procedures.UserSetting.Update(SecurityDbContext, UserSetting)

                                    End If

                                Case CheckBoxUserSettings_CheckForUserAccess.Name

                                    'Try

                                    '    If CheckBoxRightSection_CheckForUserAccess.Checked <> CheckBoxUserSettings_CheckForUserAccess.Checked Then

                                    '        CheckBoxRightSection_CheckForUserAccess.Checked = CheckBoxUserSettings_CheckForUserAccess.Checked

                                    '    End If

                                    'Catch ex As Exception

                                    'End Try

                                    'User.CheckForUserAccess = CheckBoxUserSettings_CheckForUserAccess.Checked

                                    'SecurityDbContext.UpdateObject(User)

                                    ''If SecurityDbContext.Entry(User).State = Entity.EntityState.Detached Then

                                    ''    SecurityDbContext.Users.Attach(User)

                                    ''End If

                                    ''AdvantageFramework.Security.Database.Procedures.User.Update(SecurityDbContext, User)

                                    'CheckToShowModuleAccessTab()

                                Case CheckBoxUserSettings_IsCRMUser.Name

                                    If UserSetting Is Nothing Then

                                        CreateNewUserSetting(User.ID, AdvantageFramework.Security.UserSettings.IsCRMUser.ToString, IIf(CheckBoxUserSettings_IsCRMUser.Checked, "Y", "N"), Nothing, Nothing, UserSetting)

                                        SecurityDbContext.UserSettings.Add(UserSetting)

                                    Else

                                        UserSetting.StringValue = IIf(CheckBoxUserSettings_IsCRMUser.Checked, "Y", "N")

                                        'AdvantageFramework.Security.Database.Procedures.UserSetting.Update(SecurityDbContext, UserSetting)

                                    End If

                            Case CheckBoxUserSettings_CRMAddEditViewNewBusinessClientsOnly.Name

                                If UserSetting Is Nothing Then

                                    AdvantageFramework.Security.Database.Procedures.UserSetting.Insert(SecurityDbContext, User.ID, AdvantageFramework.Security.UserSettings.CRMAddEditViewNewBusinessClientsOnly.ToString, IIf(CheckBoxUserSettings_CRMAddEditViewNewBusinessClientsOnly.Checked, "Y", "N"), Nothing, Nothing, UserSetting)

                                Else

                                    UserSetting.StringValue = IIf(CheckBoxUserSettings_CRMAddEditViewNewBusinessClientsOnly.Checked, "Y", "N")

                                    AdvantageFramework.Security.Database.Procedures.UserSetting.Update(SecurityDbContext, UserSetting)

                                End If

                        End Select

                        Next

                        SecurityDbContext.SaveChanges()

                    Else

                        Try

                            If CheckBoxRightSection_CheckForUserAccess.Checked <> CheckBoxUserSettings_CheckForUserAccess.Checked Then

                                CheckBoxRightSection_CheckForUserAccess.Checked = CheckBoxUserSettings_CheckForUserAccess.Checked

                            End If

                        Catch ex As Exception

                        End Try

                        SecurityDbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.SEC_USER SET CHECK_USER_ACCESS = {0} WHERE SEC_USER_ID IN ({1})",
                                                                                   If(CheckBoxUserSettings_CheckForUserAccess.Checked, 1, 0),
                                                                                   Join(UserIDs.Select(Function(ID) ID.ToString).ToArray, ",")))

                        For Each User In _UserList

                            User.CheckForUserAccess = CheckBoxUserSettings_CheckForUserAccess.Checked

                        Next

                        CheckToShowModuleAccessTab()

                    End If

                End Using

                If RefreshUserData Then

                    DataGridViewLeftSection_Users.CurrentView.RefreshData()

                End If

                _SavingUserSettings = False

            End If

        End Sub
        Private Sub SaveIsMediaToolsUserSetting()

            'objects
            Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing
            Dim StringValue As String = ""
            Dim UserInfos As Generic.List(Of AdvantageFramework.Security.Classes.UserWithLicenseKeyInfo) = Nothing
            Dim UserInfo As AdvantageFramework.Security.Classes.UserWithLicenseKeyInfo = Nothing

            If _LoadUserUserSettings = False AndAlso _LoadUserDetails = False AndAlso _UserList IsNot Nothing AndAlso _UserList.Count > 0 Then

                If (CheckBoxUserSettings_IsMediaToolsUser.Checked AndAlso _UserList.Count <= _AvailableMediaToolsUsers) OrElse CheckBoxUserSettings_IsMediaToolsUser.Checked = False Then

                    UserInfos = DataGridViewLeftSection_Users.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Security.Classes.UserWithLicenseKeyInfo).ToList

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        For Each User In _UserList

                            Try

                                UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, User.ID, AdvantageFramework.Security.UserSettings.IsMediaToolsUser.ToString)

                            Catch ex As Exception
                                UserSetting = Nothing
                            End Try

                            If CheckBoxUserSettings_IsMediaToolsUser.Checked Then

                                StringValue = AdvantageFramework.Security.Encryption.Encrypt(User.UserCode)

                            Else

                                StringValue = Nothing

                            End If

                            If UserSetting Is Nothing Then

                                AdvantageFramework.Security.Database.Procedures.UserSetting.Insert(SecurityDbContext, User.ID, AdvantageFramework.Security.UserSettings.IsMediaToolsUser.ToString, StringValue, Nothing, Nothing, UserSetting)

                            Else

                                UserSetting.StringValue = StringValue

                                AdvantageFramework.Security.Database.Procedures.UserSetting.Update(SecurityDbContext, UserSetting)

                            End If

                            Try

                                UserInfo = UserInfos.SingleOrDefault(Function(Entity) Entity.ID = User.ID)

                            Catch ex As Exception
                                UserInfo = Nothing
                            End Try

                            If UserInfo IsNot Nothing Then

                                UserInfo.MediaToolUserSetting = StringValue
                                UserInfo.ResetMediaToolUserCheck()

                            End If

                        Next

                    End Using

                    DataGridViewLeftSection_Users.CurrentView.RefreshData()

                    CheckMeidaToolsUserSettingAvailability()

                Else

                    _LoadUserUserSettings = True
                    CheckBoxUserSettings_IsMediaToolsUser.Checked = False
                    _LoadUserUserSettings = False

                    AdvantageFramework.WinForm.MessageBox.Show("You do not have enough media tools licenses. Please contact Software Support.")

                End If

            End If

        End Sub
        Private Sub LoadUserSettings()

            'objects
            Dim AllUserSettingList As Generic.List(Of AdvantageFramework.Security.Database.Entities.UserSetting) = Nothing
            Dim UserSettingList As Generic.List(Of AdvantageFramework.Security.Database.Entities.UserSetting) = Nothing
            Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing
            Dim UserIDs() As Integer = Nothing

            _LoadUserUserSettings = True

            CheckBoxUserSettings_LimitPOsToEmployeeCodeAttached.Checked = True
            CheckBoxUserSettings_LimitTimeEntryToEmployeeCodeAttached.Checked = True
            CheckBoxUserSettings_LimitTimesheetFunctionsForEmployee.Checked = True
            CheckBoxUserSettings_IsWebvantageUserOnly.Checked = True
            CheckBoxUserSettings_AllowProfileUpdate.Checked = True
            CheckBoxRightSection_CheckForUserAccess.Checked = True
            CheckBoxUserSettings_IsCRMUser.Checked = True
            CheckBoxUserSettings_CRMAddEditViewNewBusinessClientsOnly.Checked = True

            If _UserList IsNot Nothing AndAlso _UserList.Count > 0 Then

                UserIDs = _UserList.Select(Function(Entity) Entity.ID).ToArray

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    AllUserSettingList = (From Entity In SecurityDbContext.UserSettings.Include("User")
                                          Where UserIDs.Contains(Entity.UserID)
                                          Select Entity).ToList

                    CheckBoxUserSettings_LimitPOsToEmployeeCodeAttached.Enabled = True
                    CheckBoxUserSettings_LimitTimeEntryToEmployeeCodeAttached.Enabled = True
                    CheckBoxUserSettings_LimitTimesheetFunctionsForEmployee.Enabled = True
                    CheckBoxUserSettings_IsWebvantageUserOnly.Enabled = True
                    CheckBoxUserSettings_AllowProfileUpdate.Enabled = True
                    CheckBoxUserSettings_CheckForUserAccess.Enabled = True
                    CheckBoxUserSettings_IsCRMUser.Enabled = True
                    CheckBoxUserSettings_CRMAddEditViewNewBusinessClientsOnly.Enabled = True
                    '-----------------------------------------------------------------------------------------------
                    '-----------------------------------------------------------------------------------------------
                    '-----------------------------------------------------------------------------------------------
                    UserSettingList = New Generic.List(Of AdvantageFramework.Security.Database.Entities.UserSetting)

                    For Each UserSetting In AllUserSettingList.Where(Function(UsrSetting) UsrSetting.SettingCode = AdvantageFramework.Security.UserSettings.PR_PO_DO_OWN.ToString).ToList

                        UserSettingList.Add(UserSetting)

                        If UserSetting.StringValue = "N" OrElse UserSetting.StringValue = Nothing Then

                            CheckBoxUserSettings_LimitPOsToEmployeeCodeAttached.Checked = False

                        End If

                    Next

                    If UserSettingList.Count = 0 Then

                        CheckBoxUserSettings_LimitPOsToEmployeeCodeAttached.Checked = False

                    End If

                    CheckBoxUserSettings_LimitPOsToEmployeeCodeAttached.Tag = AdvantageFramework.Security.UserSettings.PR_PO_DO_OWN.ToString
                    '-----------------------------------------------------------------------------------------------
                    '-----------------------------------------------------------------------------------------------
                    '-----------------------------------------------------------------------------------------------
                    UserSettingList = New Generic.List(Of AdvantageFramework.Security.Database.Entities.UserSetting)

                    For Each UserSetting In AllUserSettingList.Where(Function(UsrSetting) UsrSetting.SettingCode = AdvantageFramework.Security.UserSettings.SI_DO_OWN_TS.ToString).ToList

                        UserSettingList.Add(UserSetting)

                        If UserSetting.StringValue = "N" OrElse UserSetting.StringValue = Nothing Then

                            CheckBoxUserSettings_LimitTimeEntryToEmployeeCodeAttached.Checked = False

                        End If

                    Next

                    If UserSettingList.Count = 0 Then

                        CheckBoxUserSettings_LimitTimeEntryToEmployeeCodeAttached.Checked = False

                    End If

                    CheckBoxUserSettings_LimitTimeEntryToEmployeeCodeAttached.Tag = AdvantageFramework.Security.UserSettings.SI_DO_OWN_TS.ToString
                    '-----------------------------------------------------------------------------------------------
                    '-----------------------------------------------------------------------------------------------
                    '-----------------------------------------------------------------------------------------------
                    UserSettingList = New Generic.List(Of AdvantageFramework.Security.Database.Entities.UserSetting)

                    For Each UserSetting In AllUserSettingList.Where(Function(UsrSetting) UsrSetting.SettingCode = AdvantageFramework.Security.UserSettings.EMP_TS_FNC.ToString).ToList

                        UserSettingList.Add(UserSetting)

                        If UserSetting.StringValue = "N" OrElse UserSetting.StringValue = Nothing Then

                            CheckBoxUserSettings_LimitTimesheetFunctionsForEmployee.Checked = False

                        End If

                    Next

                    If UserSettingList.Count = 0 Then

                        CheckBoxUserSettings_LimitTimesheetFunctionsForEmployee.Checked = False

                    End If

                    CheckBoxUserSettings_LimitTimesheetFunctionsForEmployee.Tag = AdvantageFramework.Security.UserSettings.EMP_TS_FNC.ToString
                    '-----------------------------------------------------------------------------------------------
                    '-----------------------------------------------------------------------------------------------
                    '-----------------------------------------------------------------------------------------------
                    UserSettingList = New Generic.List(Of AdvantageFramework.Security.Database.Entities.UserSetting)

                    For Each UserSetting In AllUserSettingList.Where(Function(UsrSetting) UsrSetting.SettingCode = AdvantageFramework.Security.UserSettings.TIME_ENTRY_ONLY.ToString).ToList

                        UserSettingList.Add(UserSetting)

                        If UserSetting.StringValue = "N" OrElse UserSetting.StringValue = Nothing Then

                            CheckBoxUserSettings_IsWebvantageUserOnly.Checked = False

                        End If

                    Next

                    If UserSettingList.Count = 0 Then

                        CheckBoxUserSettings_IsWebvantageUserOnly.Checked = False

                    End If

                    CheckBoxUserSettings_IsWebvantageUserOnly.Tag = AdvantageFramework.Security.UserSettings.TIME_ENTRY_ONLY.ToString
                    '-----------------------------------------------------------------------------------------------
                    '-----------------------------------------------------------------------------------------------
                    '-----------------------------------------------------------------------------------------------
                    UserSettingList = New Generic.List(Of AdvantageFramework.Security.Database.Entities.UserSetting)

                    For Each UserSetting In AllUserSettingList.Where(Function(UsrSetting) UsrSetting.SettingCode = AdvantageFramework.Security.UserSettings.AllowProfileUpdate.ToString).ToList

                        UserSettingList.Add(UserSetting)

                        If UserSetting.StringValue = "N" OrElse UserSetting.StringValue = Nothing Then

                            CheckBoxUserSettings_AllowProfileUpdate.Checked = False

                        End If

                    Next

                    If UserSettingList.Count = 0 Then

                        CheckBoxUserSettings_AllowProfileUpdate.Checked = False

                    End If

                    CheckBoxUserSettings_AllowProfileUpdate.Tag = AdvantageFramework.Security.UserSettings.AllowProfileUpdate.ToString
                    '-----------------------------------------------------------------------------------------------
                    '-----------------------------------------------------------------------------------------------
                    '-----------------------------------------------------------------------------------------------
                    UserSettingList = New Generic.List(Of AdvantageFramework.Security.Database.Entities.UserSetting)

                    For Each UserSetting In AllUserSettingList.Where(Function(UsrSetting) UsrSetting.SettingCode = AdvantageFramework.Security.UserSettings.IsCRMUser.ToString).ToList

                        UserSettingList.Add(UserSetting)

                        If UserSetting.StringValue = "N" OrElse UserSetting.StringValue = Nothing Then

                            CheckBoxUserSettings_IsCRMUser.Checked = False

                        End If

                    Next

                    If UserSettingList.Count = 0 Then

                        CheckBoxUserSettings_IsCRMUser.Checked = False

                    End If

                    CheckBoxUserSettings_IsCRMUser.Tag = AdvantageFramework.Security.UserSettings.IsCRMUser.ToString
                    '-----------------------------------------------------------------------------------------------
                    '-----------------------------------------------------------------------------------------------
                    '-----------------------------------------------------------------------------------------------
                    UserSettingList = New Generic.List(Of AdvantageFramework.Security.Database.Entities.UserSetting)

                    For Each UserSetting In AllUserSettingList.Where(Function(UsrSetting) UsrSetting.SettingCode = AdvantageFramework.Security.UserSettings.CRMAddEditViewNewBusinessClientsOnly.ToString).ToList

                        UserSettingList.Add(UserSetting)

                        If UserSetting.StringValue = "N" OrElse UserSetting.StringValue = Nothing Then

                            CheckBoxUserSettings_CRMAddEditViewNewBusinessClientsOnly.Checked = False

                        End If

                    Next

                    If UserSettingList.Count = 0 Then

                        CheckBoxUserSettings_CRMAddEditViewNewBusinessClientsOnly.Checked = False

                    End If

                    CheckBoxUserSettings_CRMAddEditViewNewBusinessClientsOnly.Tag = AdvantageFramework.Security.UserSettings.CRMAddEditViewNewBusinessClientsOnly.ToString
                    '-----------------------------------------------------------------------------------------------
                    '-----------------------------------------------------------------------------------------------
                    '-----------------------------------------------------------------------------------------------
                    For Each User In _UserList

                        If User.CheckForUserAccess = False Then

                            CheckBoxRightSection_CheckForUserAccess.Checked = False

                        End If

                    Next

                    If _UserList.Count = 0 Then

                        CheckBoxRightSection_CheckForUserAccess.Checked = False

                    End If

                End Using

            Else

                CheckBoxUserSettings_LimitPOsToEmployeeCodeAttached.Enabled = False
                CheckBoxUserSettings_LimitTimeEntryToEmployeeCodeAttached.Enabled = False
                CheckBoxUserSettings_LimitTimesheetFunctionsForEmployee.Enabled = False
                CheckBoxUserSettings_IsWebvantageUserOnly.Enabled = False
                CheckBoxUserSettings_AllowProfileUpdate.Enabled = False
                CheckBoxUserSettings_CheckForUserAccess.Enabled = False
                CheckBoxUserSettings_IsCRMUser.Enabled = False
                CheckBoxUserSettings_CRMAddEditViewNewBusinessClientsOnly.Enabled = False

            End If

            LoadIsMediaToolsUserSetting(AllUserSettingList)

            TabItemUserDetails_UserSettingsTab.Tag = True

            _LoadUserUserSettings = False

        End Sub
        Private Sub LoadIsMediaToolsUserSetting(AllUserSettingList As Generic.List(Of AdvantageFramework.Security.Database.Entities.UserSetting))

            'objects
            Dim UserSettingList As Generic.List(Of AdvantageFramework.Security.Database.Entities.UserSetting) = Nothing
            Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing

            CheckBoxUserSettings_IsMediaToolsUser.Checked = True

            If _UserList IsNot Nothing AndAlso _UserList.Count > 0 Then

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)
                    '-----------------------------------------------------------------------------------------------
                    '-----------------------------------------------------------------------------------------------
                    '-----------------------------------------------------------------------------------------------
                    CheckBoxUserSettings_IsMediaToolsUser.Enabled = True
                    '-----------------------------------------------------------------------------------------------
                    '-----------------------------------------------------------------------------------------------
                    '-----------------------------------------------------------------------------------------------
                    UserSettingList = New Generic.List(Of AdvantageFramework.Security.Database.Entities.UserSetting)

                    For Each UserSetting In AllUserSettingList.Where(Function(UsrSetting) UsrSetting.SettingCode = AdvantageFramework.Security.UserSettings.IsMediaToolsUser.ToString).ToList

                        UserSettingList.Add(UserSetting)

                        If AdvantageFramework.Security.IsMediaToolUser(UserSetting.User.UserCode, UserSetting.StringValue) = False Then

                            CheckBoxUserSettings_IsMediaToolsUser.Checked = False

                        End If

                    Next

                    If UserSettingList.Count = 0 Then

                        CheckBoxUserSettings_IsMediaToolsUser.Checked = False

                    End If

                    CheckBoxUserSettings_IsMediaToolsUser.Tag = AdvantageFramework.Security.UserSettings.IsMediaToolsUser.ToString

                End Using

            Else

                CheckBoxUserSettings_IsMediaToolsUser.Checked = False
                CheckBoxUserSettings_IsMediaToolsUser.Enabled = False

            End If

        End Sub
        Private Sub SaveUserModuleAccess(ByVal UserModuleAccessProperty As AdvantageFramework.Security.Database.Entities.UserModuleAccess.Properties, ByVal NewValue As Boolean)

            'objects
            Dim [Module] As AdvantageFramework.Security.Database.Views.ModuleView = Nothing
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
            Dim UserModuleAccessList As Generic.List(Of AdvantageFramework.Security.Database.Entities.UserModuleAccess) = Nothing
            Dim UserModuleAccess As AdvantageFramework.Security.Database.Entities.UserModuleAccess = Nothing
            Dim UserIDs() As Integer = Nothing
            Dim ModuleIDs() As Integer = Nothing

            If _LoadUserModuleAccess = False AndAlso _UserList IsNot Nothing AndAlso _UserList.Count > 0 Then

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    SecurityDbContext.Database.Connection.Open()
                    SecurityDbContext.Configuration.AutoDetectChangesEnabled = False

                    Try

                        PropertyDescriptor = (From [Property] In System.ComponentModel.TypeDescriptor.GetProperties(GetType(AdvantageFramework.Security.Database.Entities.UserModuleAccess)).OfType(Of System.ComponentModel.PropertyDescriptor)()
                                              Where [Property].Name = UserModuleAccessProperty.ToString
                                              Select [Property]).SingleOrDefault

                    Catch ex As Exception
                        PropertyDescriptor = Nothing
                    End Try

                    UserIDs = _UserList.Select(Function(Entity) Entity.ID).ToArray

                    ModuleIDs = AdvTreeModuleAccess_Modules.SelectedNodes.OfType(Of DevComponents.AdvTree.Node).Where(Function(Node) TypeOf Node.Tag Is AdvantageFramework.Security.Database.Views.ModuleView).
                                                                                                                Select(Function(Node) CType(Node.Tag, AdvantageFramework.Security.Database.Views.ModuleView).ModuleID).ToArray

                    UserModuleAccessList = (From Entity In SecurityDbContext.UserModuleAccesses
                                            Where ModuleIDs.Contains(Entity.ModuleID) AndAlso UserIDs.Contains(Entity.UserID)
                                            Select Entity).ToList

                    For Each SelectedNode In AdvTreeModuleAccess_Modules.SelectedNodes

                        Try

                            [Module] = SelectedNode.Tag

                        Catch ex As Exception
                            [Module] = Nothing
                        End Try

                        If [Module] IsNot Nothing Then

                            If [Module].IsCategory = False Then

                                For Each User In _UserList

                                    Try

                                        UserModuleAccess = UserModuleAccessList.SingleOrDefault(Function(Entity) Entity.ModuleID = [Module].ModuleID AndAlso Entity.UserID = User.ID)

                                    Catch ex As Exception
                                        UserModuleAccess = Nothing
                                    End Try

                                    If UserModuleAccess Is Nothing Then

                                        Try

                                            UserModuleAccess = UserModuleAccessList.FirstOrDefault(Function(Entity) Entity.ModuleID = [Module].ModuleID AndAlso Entity.UserID = User.ID)

                                        Catch ex As Exception
                                            UserModuleAccess = Nothing
                                        End Try

                                        If UserModuleAccess IsNot Nothing Then

                                            UserModuleAccessList.Remove(UserModuleAccess)
                                            SecurityDbContext.UserModuleAccesses.Remove(UserModuleAccess)
                                            UserModuleAccess = Nothing

                                            Try

                                                UserModuleAccess = UserModuleAccessList.SingleOrDefault(Function(Entity) Entity.ModuleID = [Module].ModuleID AndAlso Entity.UserID = User.ID)

                                            Catch ex As Exception
                                                UserModuleAccess = Nothing
                                            End Try

                                            'If AdvantageFramework.Security.Database.Procedures.UserModuleAccess.Delete(SecurityDbContext, UserModuleAccess) Then

                                            '    Try

                                            '        UserModuleAccess = AdvantageFramework.Security.Database.Procedures.UserModuleAccess.LoadByModuleIDAndUserID(SecurityDbContext, [Module].ModuleID, User.ID)

                                            '    Catch ex As Exception
                                            '        UserModuleAccess = Nothing
                                            '    End Try

                                            'End If

                                        Else

                                            UserModuleAccess = New AdvantageFramework.Security.Database.Entities.UserModuleAccess

                                            UserModuleAccess.UserID = User.ID
                                            UserModuleAccess.ModuleID = [Module].ModuleID
                                            UserModuleAccess.IsBlocked = True
                                            UserModuleAccess.CanPrint = True
                                            UserModuleAccess.CanUpdate = True
                                            UserModuleAccess.CanAdd = True
                                            UserModuleAccess.Custom1 = True
                                            UserModuleAccess.Custom2 = True

                                            SecurityDbContext.UserModuleAccesses.Add(UserModuleAccess)

                                        End If

                                    End If

                                    If UserModuleAccess IsNot Nothing Then

                                        If PropertyDescriptor IsNot Nothing Then

                                            PropertyDescriptor.SetValue(UserModuleAccess, NewValue)

                                        End If

                                        'AdvantageFramework.Security.Database.Procedures.UserModuleAccess.Update(SecurityDbContext, UserModuleAccess)

                                    End If

                                Next

                            End If

                        End If

                    Next

                    SecurityDbContext.Configuration.AutoDetectChangesEnabled = True

                    SecurityDbContext.SaveChanges()

                End Using

            End If

        End Sub
        Private Sub LoadUserApplicationAccess()

            'objects
            Dim ApplicationID As Integer = 0
            Dim UserApplicationAccess As AdvantageFramework.Security.Database.Entities.UserApplicationAccess = Nothing

            If _UserList IsNot Nothing AndAlso _UserList.Count > 0 AndAlso ComboBoxModuleAccess_Application.HasASelectedValue Then

                _LoadUserModuleAccess = True

                Try

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        ApplicationID = ComboBoxModuleAccess_Application.GetSelectedValue

                        If _UserList.Count = 1 Then

                            Try

                                UserApplicationAccess = AdvantageFramework.Security.Database.Procedures.UserApplicationAccess.LoadByApplicationIDAndUserID(SecurityDbContext, ApplicationID, _UserList(0).ID)

                            Catch ex As Exception
                                UserApplicationAccess = Nothing
                            End Try

                            If UserApplicationAccess IsNot Nothing Then

                                CheckBoxModuleAccess_IsApplicationBlocked.Checked = UserApplicationAccess.IsBlocked

                            Else

                                CheckBoxModuleAccess_IsApplicationBlocked.Checked = False

                            End If

                        Else

                            If AdvantageFramework.Security.Database.Procedures.UserApplicationAccess.LoadByUserIDs(SecurityDbContext, _UserList.Select(Function(Entity) Entity.ID).ToArray).Any(Function(GrpAppAccess) GrpAppAccess.ApplicationID = ApplicationID AndAlso GrpAppAccess.IsBlocked = True) Then

                                CheckBoxModuleAccess_IsApplicationBlocked.Checked = True

                            Else

                                CheckBoxModuleAccess_IsApplicationBlocked.Checked = False

                            End If

                        End If

                    End Using

                Catch ex As Exception

                End Try

                _LoadUserModuleAccess = False

            End If

        End Sub
        Private Sub SaveUserApplicationAccess()

            'objects
            Dim ApplicationID As Integer = 0
            Dim UserApplicationAccess As AdvantageFramework.Security.Database.Entities.UserApplicationAccess = Nothing

            If _LoadUserModuleAccess = False AndAlso _UserList IsNot Nothing AndAlso _UserList.Count > 0 AndAlso ComboBoxModuleAccess_Application.HasASelectedValue Then

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ApplicationID = ComboBoxModuleAccess_Application.GetSelectedValue

                    For Each User In _UserList

                        Try

                            UserApplicationAccess = AdvantageFramework.Security.Database.Procedures.UserApplicationAccess.LoadByApplicationIDAndUserID(SecurityDbContext, ApplicationID, User.ID)

                        Catch ex As Exception
                            UserApplicationAccess = Nothing
                        End Try

                        If UserApplicationAccess Is Nothing Then

                            Try

                                UserApplicationAccess = AdvantageFramework.Security.Database.Procedures.UserApplicationAccess.LoadByUserID(SecurityDbContext, User.ID).FirstOrDefault(Function(Entity) Entity.ApplicationID = ApplicationID)

                            Catch ex As Exception
                                UserApplicationAccess = Nothing
                            End Try

                            If UserApplicationAccess IsNot Nothing Then

                                If AdvantageFramework.Security.Database.Procedures.UserApplicationAccess.Delete(SecurityDbContext, UserApplicationAccess) Then

                                    Try

                                        UserApplicationAccess = AdvantageFramework.Security.Database.Procedures.UserApplicationAccess.LoadByApplicationIDAndUserID(SecurityDbContext, ApplicationID, User.ID)

                                    Catch ex As Exception
                                        UserApplicationAccess = Nothing
                                    End Try

                                End If

                            End If

                        End If

                        If UserApplicationAccess IsNot Nothing Then

                            UserApplicationAccess.IsBlocked = CheckBoxModuleAccess_IsApplicationBlocked.Checked

                            AdvantageFramework.Security.Database.Procedures.UserApplicationAccess.Update(SecurityDbContext, UserApplicationAccess)

                        Else

                            UserApplicationAccess = New AdvantageFramework.Security.Database.Entities.UserApplicationAccess

                            UserApplicationAccess.DbContext = SecurityDbContext

                            UserApplicationAccess.ApplicationID = ApplicationID
                            UserApplicationAccess.UserID = User.ID
                            UserApplicationAccess.IsBlocked = CheckBoxModuleAccess_IsApplicationBlocked.Checked
                            UserApplicationAccess.CanPrint = True
                            UserApplicationAccess.CanUpdate = True
                            UserApplicationAccess.CanAdd = True
                            UserApplicationAccess.Custom1 = False
                            UserApplicationAccess.Custom2 = False

                            AdvantageFramework.Security.Database.Procedures.UserApplicationAccess.Insert(SecurityDbContext, UserApplicationAccess)

                        End If

                    Next

                End Using

                Me.ClearChanged()

            End If

        End Sub
        Private Sub LoadUserModuleAccess()

            'objects
            Dim [Module] As AdvantageFramework.Security.Database.Views.ModuleView = Nothing
            Dim UserModuleAccess As AdvantageFramework.Security.Database.Entities.UserModuleAccess = Nothing
            Dim AllSelectedModulesHaveSameOptions As Boolean = True
            Dim FirstSelectedModule As AdvantageFramework.Security.Database.Views.ModuleView = Nothing
            Dim AllUserModuleAccess As Generic.List(Of AdvantageFramework.Security.Database.Entities.UserModuleAccess) = Nothing
            Dim UserModuleAccessList As Generic.List(Of AdvantageFramework.Security.Database.Entities.UserModuleAccess) = Nothing
            Dim UserIDs() As Integer = Nothing

            For Each SelectedNode In AdvTreeModuleAccess_Modules.SelectedNodes

                Try

                    [Module] = SelectedNode.Tag

                Catch ex As Exception
                    [Module] = Nothing
                Finally

                    If [Module] IsNot Nothing Then

                        If [Module].IsCategory = False Then

                            If FirstSelectedModule Is Nothing Then

                                FirstSelectedModule = [Module]

                            Else

                                If FirstSelectedModule.HasCustomPermission <> [Module].HasCustomPermission Then

                                    AllSelectedModulesHaveSameOptions = False

                                End If

                            End If

                        End If

                    End If

                End Try

                If AllSelectedModulesHaveSameOptions = False Then

                    Exit For

                End If

            Next

            _LoadUserModuleAccess = True

            If FirstSelectedModule IsNot Nothing Then

                CheckBoxModuleAccess_IsBlocked.Visible = True

                If AllSelectedModulesHaveSameOptions Then

                    CheckBoxModuleAccess_CanPrint.Visible = FirstSelectedModule.HasCustomPermission
                    CheckBoxModuleAccess_CanUpdate.Visible = FirstSelectedModule.HasCustomPermission
                    CheckBoxModuleAccess_CanAdd.Visible = FirstSelectedModule.HasCustomPermission
                    CheckBoxModuleAccess_Custom1.Visible = FirstSelectedModule.HasCustomPermission
                    CheckBoxModuleAccess_Custom2.Visible = FirstSelectedModule.HasCustomPermission

                Else

                    CheckBoxModuleAccess_CanPrint.Visible = False
                    CheckBoxModuleAccess_CanUpdate.Visible = False
                    CheckBoxModuleAccess_CanAdd.Visible = False
                    CheckBoxModuleAccess_Custom1.Visible = False
                    CheckBoxModuleAccess_Custom2.Visible = False

                End If

                If AdvTreeModuleAccess_Modules.SelectedNodes.Count = 1 Then

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        UserIDs = _UserList.Select(Function(Entity) Entity.ID).ToArray

                        UserModuleAccessList = (From Entity In SecurityDbContext.UserModuleAccesses
                                                Where FirstSelectedModule.ModuleID = Entity.ModuleID AndAlso UserIDs.Contains(Entity.UserID)
                                                Select Entity).ToList

                        If _UserList IsNot Nothing AndAlso _UserList.Count = 1 Then

                            Try

                                UserModuleAccess = UserModuleAccessList.SingleOrDefault(Function(UsrModAccess) UsrModAccess.UserID = _UserList(0).ID)

                            Catch ex As Exception
                                UserModuleAccess = Nothing
                            End Try

                            If UserModuleAccess IsNot Nothing Then

                                CheckBoxModuleAccess_IsBlocked.Checked = UserModuleAccess.IsBlocked
                                CheckBoxModuleAccess_CanPrint.Checked = UserModuleAccess.CanPrint
                                CheckBoxModuleAccess_CanUpdate.Checked = UserModuleAccess.CanUpdate
                                CheckBoxModuleAccess_CanAdd.Checked = UserModuleAccess.CanAdd
                                CheckBoxModuleAccess_Custom1.Checked = UserModuleAccess.Custom1
                                CheckBoxModuleAccess_Custom2.Checked = UserModuleAccess.Custom2

                            End If

                        ElseIf _UserList IsNot Nothing AndAlso _UserList.Count > 1 Then

                            CheckBoxModuleAccess_IsBlocked.Checked = True
                            CheckBoxModuleAccess_CanPrint.Checked = True
                            CheckBoxModuleAccess_CanUpdate.Checked = True
                            CheckBoxModuleAccess_CanAdd.Checked = True
                            CheckBoxModuleAccess_Custom1.Checked = True
                            CheckBoxModuleAccess_Custom2.Checked = True

                            For Each User In _UserList

                                Try

                                    UserModuleAccess = UserModuleAccessList.SingleOrDefault(Function(UsrModAccess) UsrModAccess.UserID = User.ID)

                                Catch ex As Exception
                                    UserModuleAccess = Nothing
                                End Try

                                If UserModuleAccess IsNot Nothing Then

                                    If UserModuleAccess.IsBlocked = False Then

                                        CheckBoxModuleAccess_IsBlocked.Checked = False

                                    End If

                                    If UserModuleAccess.CanPrint = False Then

                                        CheckBoxModuleAccess_CanPrint.Checked = False

                                    End If

                                    If UserModuleAccess.CanUpdate = False Then

                                        CheckBoxModuleAccess_CanUpdate.Checked = False

                                    End If

                                    If UserModuleAccess.CanAdd = False Then

                                        CheckBoxModuleAccess_CanAdd.Checked = False

                                    End If

                                    If UserModuleAccess.Custom1 = False Then

                                        CheckBoxModuleAccess_Custom1.Checked = False

                                    End If

                                    If UserModuleAccess.Custom2 = False Then

                                        CheckBoxModuleAccess_Custom2.Checked = False

                                    End If

                                End If

                            Next

                        Else

                            CheckBoxModuleAccess_IsBlocked.Visible = False
                            CheckBoxModuleAccess_CanPrint.Visible = False
                            CheckBoxModuleAccess_CanUpdate.Visible = False
                            CheckBoxModuleAccess_CanAdd.Visible = False
                            CheckBoxModuleAccess_Custom1.Visible = False
                            CheckBoxModuleAccess_Custom2.Visible = False

                        End If

                    End Using

                Else

                    If _UserList IsNot Nothing AndAlso _UserList.Count > 0 Then

                        CheckBoxModuleAccess_IsBlocked.Checked = False
                        CheckBoxModuleAccess_CanPrint.Checked = False
                        CheckBoxModuleAccess_CanUpdate.Checked = False
                        CheckBoxModuleAccess_CanAdd.Checked = False
                        CheckBoxModuleAccess_Custom1.Checked = False
                        CheckBoxModuleAccess_Custom2.Checked = False

                    Else

                        CheckBoxModuleAccess_IsBlocked.Visible = False
                        CheckBoxModuleAccess_CanPrint.Visible = False
                        CheckBoxModuleAccess_CanUpdate.Visible = False
                        CheckBoxModuleAccess_CanAdd.Visible = False
                        CheckBoxModuleAccess_Custom1.Visible = False
                        CheckBoxModuleAccess_Custom2.Visible = False

                    End If

                End If

            Else

                CheckBoxModuleAccess_IsBlocked.Visible = False
                CheckBoxModuleAccess_CanPrint.Visible = False
                CheckBoxModuleAccess_CanUpdate.Visible = False
                CheckBoxModuleAccess_CanAdd.Visible = False
                CheckBoxModuleAccess_Custom1.Visible = False
                CheckBoxModuleAccess_Custom2.Visible = False

            End If

            TabItemUserDetails_ModuleAccessTab.Tag = True

            _LoadUserModuleAccess = False

        End Sub
        Private Sub LoadUserClientDivisionProductAccess()

            UserCDPLimitClientDivisionProduct_CDPLimits.ClearControl()

            UserCDPLimitClientDivisionProduct_CDPLimits.Enabled = (_UserList IsNot Nothing AndAlso _UserList.Count > 0)

            If UserCDPLimitClientDivisionProduct_CDPLimits.Enabled Then

                UserCDPLimitClientDivisionProduct_CDPLimits.Enabled = UserCDPLimitClientDivisionProduct_CDPLimits.LoadControl(_UserList.Select(Function(Entity) Entity.UserCode).ToList)

            End If

            TabItemUserDetails_ClientDivisionProductTab.Tag = True

        End Sub
        Private Sub LoadUserEmployeeAccess()

            UserEmployeeLimitEmployees_EmployeeLimits.ClearControl()

            UserEmployeeLimitEmployees_EmployeeLimits.Enabled = (_UserList IsNot Nothing AndAlso _UserList.Count > 0)

            If UserEmployeeLimitEmployees_EmployeeLimits.Enabled Then

                UserEmployeeLimitEmployees_EmployeeLimits.Enabled = UserEmployeeLimitEmployees_EmployeeLimits.LoadControl(_UserList.Select(Function(Entity) Entity.UserCode).ToList)

            End If

            TabItemUserDetails_EmployeesTab.Tag = True

        End Sub
        Private Sub LoadEmployeeOfficeLimits()

            EmployeeOfficeLimitControlEmployeeOfficeLimits_EmployeeOfficeLimits.ClearControl()

            EmployeeOfficeLimitControlEmployeeOfficeLimits_EmployeeOfficeLimits.Enabled = (_UserList IsNot Nothing AndAlso _UserList.Count > 0)

            If EmployeeOfficeLimitControlEmployeeOfficeLimits_EmployeeOfficeLimits.Enabled Then

                EmployeeOfficeLimitControlEmployeeOfficeLimits_EmployeeOfficeLimits.Enabled = EmployeeOfficeLimitControlEmployeeOfficeLimits_EmployeeOfficeLimits.LoadControl(_UserList.Select(Function(Entity) Entity.EmployeeCode).Distinct.ToList)

            End If

            TabItemUserDetails_EmployeeOfficeLimitsTab.Tag = True

        End Sub
        Private Sub LoadEmployeeTimesheetFunctionLimits()

            Dim FunctionCode As String = String.Empty

            If _UserList IsNot Nothing AndAlso _UserList.Count > 0 Then

                SearchableComboBoxTimesheetFunctionLimits_DefaultFunction.Enabled = True

                Try

                    FunctionCode = _UserList.FirstOrDefault().Employee.FunctionCode

                Catch ex As Exception
                    FunctionCode = String.Empty
                End Try

                If String.IsNullOrWhiteSpace(FunctionCode) = False Then

                    If _UserList.All(Function(Entity) Entity.Employee.FunctionCode = FunctionCode) Then

                        SearchableComboBoxTimesheetFunctionLimits_DefaultFunction.SelectedValue = FunctionCode

                    Else

                        SearchableComboBoxTimesheetFunctionLimits_DefaultFunction.SelectedValue = Nothing

                    End If

                Else

                    SearchableComboBoxTimesheetFunctionLimits_DefaultFunction.SelectedValue = Nothing

                End If

            Else

                SearchableComboBoxTimesheetFunctionLimits_DefaultFunction.Enabled = False
                SearchableComboBoxTimesheetFunctionLimits_DefaultFunction.SelectedValue = Nothing

            End If

            SearchableComboBoxTimesheetFunctionLimits_DefaultFunction.ClearChanged()

            If CheckBoxRightSection_Inactive.UserEntryChanged = False AndAlso ComboBoxRightSection_Employee.UserEntryChanged = False Then

                Me.ClearChanged()

            End If

            EmployeeTimesheetFunctionLimitsControlEmployeeTimesheetFunctionLimits_EmployeeTimesheetFunctionLimits.ClearControl()

            EmployeeTimesheetFunctionLimitsControlEmployeeTimesheetFunctionLimits_EmployeeTimesheetFunctionLimits.Enabled = (_UserList IsNot Nothing AndAlso _UserList.Count > 0)

            If EmployeeTimesheetFunctionLimitsControlEmployeeTimesheetFunctionLimits_EmployeeTimesheetFunctionLimits.Enabled Then

                EmployeeTimesheetFunctionLimitsControlEmployeeTimesheetFunctionLimits_EmployeeTimesheetFunctionLimits.Enabled = EmployeeTimesheetFunctionLimitsControlEmployeeTimesheetFunctionLimits_EmployeeTimesheetFunctionLimits.LoadControl(_UserList.Select(Function(Entity) Entity.EmployeeCode).Distinct.ToList)

            End If

            TabItemUserDetails_EmployeeTimesheetFunctionLimitsTab.Tag = True

        End Sub
        Private Sub LoadUserGroup()

            'objects
            Dim UserGroupsList As Generic.List(Of AdvantageFramework.Security.Database.Entities.GroupUser) = Nothing
            Dim AvailableGroupsList As Generic.List(Of AdvantageFramework.Security.Database.Entities.Group) = Nothing
            Dim Group As AdvantageFramework.Security.Database.Entities.Group = Nothing
            Dim AllUserGroupsList As Generic.List(Of Generic.List(Of AdvantageFramework.Security.Database.Entities.Group)) = Nothing
            Dim AddUserGroup As Boolean = True
            Dim FinalUserGroupsList As Generic.List(Of AdvantageFramework.Security.Database.Entities.Group) = Nothing
            Dim GroupsList As Generic.List(Of AdvantageFramework.Security.Database.Entities.Group) = Nothing
            Dim UserIDs() As Integer = Nothing

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If _UserList IsNot Nothing AndAlso _UserList.Count > 0 Then

                    UserIDs = _UserList.Select(Function(Entity) Entity.ID).ToArray

                    UserGroupsList = AdvantageFramework.Security.Database.Procedures.GroupUser.Load(SecurityDbContext).Where(Function(Entity) UserIDs.Contains(Entity.UserID)).Select(Function(Entity) Entity).ToList

                    'For Each User In _UserList

                    '    UserGroupsList = User.GroupUsers.Select(Function(GroupUser) GroupUser.Group).ToList

                    '    AllUserGroupsList.Add()

                    'Next

                    FinalUserGroupsList = New Generic.List(Of AdvantageFramework.Security.Database.Entities.Group)

                    GroupsList = AdvantageFramework.Security.Database.Procedures.Group.Load(SecurityDbContext).ToList '.Include("GroupUsers").ToList

                    For Each Group In GroupsList

                        AddUserGroup = True

                        For Each UserID In UserIDs

                            If UserGroupsList.Any(Function(UserGroup) UserGroup.UserID = UserID AndAlso UserGroup.GroupID = Group.ID) = False Then

                                AddUserGroup = False
                                Exit For

                            End If

                        Next

                        If AddUserGroup Then

                            FinalUserGroupsList.Add(Group)

                        End If

                    Next

                    AvailableGroupsList = New Generic.List(Of AdvantageFramework.Security.Database.Entities.Group)

                    For Each Group In GroupsList

                        If FinalUserGroupsList.Any(Function(UserGroup) UserGroup.ID = Group.ID) = False Then

                            AvailableGroupsList.Add(Group)

                        End If

                    Next

                    ButtonRightSection_AddToUser.Enabled = True
                    ButtonRightSection_RemoveFromUser.Enabled = True

                Else

                    FinalUserGroupsList = New Generic.List(Of AdvantageFramework.Security.Database.Entities.Group)

                    AvailableGroupsList = AdvantageFramework.Security.Database.Procedures.Group.Load(SecurityDbContext).ToList

                    ButtonRightSection_AddToUser.Enabled = False
                    ButtonRightSection_RemoveFromUser.Enabled = False

                End If

                DataGridViewRightSection_UserGroups.DataSource = FinalUserGroupsList
                DataGridViewLeftSection_AvailableGroups.DataSource = AvailableGroupsList

                DataGridViewLeftSection_AvailableGroups.CurrentView.BestFitColumns()
                DataGridViewRightSection_UserGroups.CurrentView.BestFitColumns()

                TabItemUserDetails_GroupsTab.Tag = True

            End Using

        End Sub
        Private Sub LoadUserDetails(ByVal TabItem As DevComponents.DotNetBar.TabItem)

            'objects
            Dim ClearUserDetails As Boolean = False
            Dim UserIDArray() As Integer = Nothing
            Dim DatabaseSQLUser As AdvantageFramework.Security.Database.Views.DatabaseSQLUser = Nothing
            Dim DatabaseSQLUsersList As Generic.List(Of AdvantageFramework.Security.Database.Views.DatabaseSQLUser) = Nothing
            Dim EmployeeCode As String = ""
            Dim SQLLogins As Generic.List(Of AdvantageFramework.Security.Database.Classes.SQLLogin) = Nothing
            'Dim StartTime As Date = Date.MinValue
            'Dim TotalTime As TimeSpan = TimeSpan.MinValue

            'StartTime = Now

            If _LoadUserDetails = False Then

                _LoadUserDetails = True

                If DataGridViewLeftSection_Users.HasASelectedRow Then

                    If TabItem Is Nothing Then

                        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            UserIDArray = DataGridViewLeftSection_Users.GetAllSelectedRowsBookmarkValues().OfType(Of Integer).ToArray

                            '_UserList = AdvantageFramework.Security.Database.Procedures.User.LoadByUserIDs(SecurityDbContext, UserIDArray).Include("Employee").Include("Employee.Department").Include("GroupUsers").Include("GroupUsers.Group").Include("UserModuleAccesses").Include("UserSettings").Include("UserApplicationAccesses").ToList
                            _UserList = AdvantageFramework.Security.Database.Procedures.User.LoadByUserIDs(SecurityDbContext, UserIDArray).Include("Employee").Include("Employee.Department").Include("GroupUsers").Include("UserSettings").ToList

                        End Using

                        For Each TabItem In TabControlRightSection_UserDetails.Tabs.OfType(Of DevComponents.DotNetBar.TabItem)()

                            TabItem.Tag = False

                        Next

                        'TotalTime = Now - StartTime

                        'Console.WriteLine("LoadUserDetails 1 - " & TotalTime.TotalSeconds)

                        TabItem = TabControlRightSection_UserDetails.SelectedTab

                        ComboBoxRightSection_Employee.RemoveAddedItemsFromDataSource()

                        CheckToShowModuleAccessTab()

                        If _UserList.Count = 1 Then

                            TabItemUserDetails_ClientDivisionProductTab.Visible = True

                            CheckBoxRightSection_CheckForUserAccess.Checked = _UserList(0).CheckForUserAccess
                            CheckBoxUserSettings_CheckForUserAccess.Checked = _UserList(0).CheckForUserAccess
                            ComboBoxRightSection_Employee.SelectedValue = _UserList(0).EmployeeCode
                            CheckBoxRightSection_Inactive.Checked = _UserList(0).IsInactive
                            CheckBoxRightSection_Inactive.Enabled = True
                            'CheckBoxRightSection_IsAdvantageAdmin.Enabled = True
                            'CheckBoxRightSection_IsAdvantageAdmin.Checked = _UserList(0).IsAdvanAdmin

                            'ButtonRightSection_SelectUser.Enabled = False

                            'Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            '    'SecurityDbContext.Database.Connection.Open()

                            '    'DatabaseSQLUser = AdvantageFramework.Security.Database.Procedures.DatabaseSQLUserView.LoadByName(SecurityDbContext, _UserList(0).UserName)

                            '    'If Session.IsSysAdmin OrElse Session.IsSecurityAdmin OrElse
                            '    '        Session.IsDBOwner OrElse Session.IsDBSecurityAdmin OrElse Session.IsDBAccessAdmin Then

                            '    '    If DatabaseSQLUser Is Nothing Then

                            '    '        DatabaseSQLUsersList = AdvantageFramework.Security.Database.Procedures.DatabaseSQLUserView.LoadWithNameThatEndsWith(SecurityDbContext, _UserList(0).UserName).ToList

                            '    '        If DatabaseSQLUsersList.Count > 0 Then

                            '    '            ButtonRightSection_SelectUser.Enabled = True

                            '    '        End If

                            '    '    End If

                            '    'End If

                            '    'If DatabaseSQLUser IsNot Nothing Then

                            '    '    'ComboBoxRightSection_SQLUser.Enabled = True
                            '    '    'ButtonRightSection_AddSQLUser.Enabled = True

                            '    '    'SQLLogins = AdvantageFramework.Security.LoadSQLLogins(Me.Session)

                            '    '    'If SQLLogins.Any(Function(Entity) Entity.Name = DatabaseSQLUser.Name) = False Then

                            '    '    '    SQLLogins.Add(New AdvantageFramework.Security.Database.Classes.SQLLogin(DatabaseSQLUser))

                            '    '    'End If

                            '    '    'SQLLogins = SQLLogins.OrderBy(Function(SQLLogin) SQLLogin.Name).ToList

                            '    '    'ComboBoxRightSection_SQLUser.DataSource = SQLLogins

                            '    '    'ComboBoxRightSection_SQLUser.SelectedIndex = ComboBoxRightSection_SQLUser.FindStringExact(DatabaseSQLUser.Name)

                            '    '    'If ComboBoxRightSection_SQLUser.SelectedIndex = -1 Then

                            '    '    '    ComboBoxRightSection_SQLUser.SelectedIndex = 0
                            '    '    CheckBoxRightSection_Inactive.Enabled = True

                            '    '    'Else

                            '    '    '    CheckBoxRightSection_Inactive.Enabled = False

                            '    '    'End If

                            '    '    If AdvantageFramework.Security.Database.Procedures.DatabaseSQLUserView.IsDatabaseSQLUserAdvantageAdmin(SecurityDbContext, DatabaseSQLUser.ID) Then

                            '    '        CheckBoxRightSection_IsAdvantageAdmin.Checked = True

                            '    '    Else

                            '    '        CheckBoxRightSection_IsAdvantageAdmin.Checked = False

                            '    '    End If

                            '    'Else

                            '    '    CheckBoxRightSection_Inactive.Enabled = True
                            '    '    ButtonRightSection_AddSQLUser.Enabled = (Session.IsSysAdmin OrElse Session.IsSecurityAdmin)

                            '    '    If Session.IsSysAdmin OrElse Session.IsSecurityAdmin OrElse
                            '    '            Session.IsDBOwner OrElse Session.IsDBSecurityAdmin OrElse Session.IsDBAccessAdmin Then

                            '    '        CheckBoxRightSection_IsAdvantageAdmin.Enabled = True

                            '    '        ComboBoxRightSection_SQLUser.Enabled = True
                            '    '        ComboBoxRightSection_SQLUser.DataSource = AdvantageFramework.Security.LoadSQLLogins(Me.Session).OrderBy(Function(SQLLogin) SQLLogin.Name).ToList

                            '    '    Else

                            '    '        CheckBoxRightSection_IsAdvantageAdmin.Enabled = False

                            '    '        ComboBoxRightSection_SQLUser.Enabled = False

                            '    '    End If

                            '    '    CheckBoxRightSection_IsAdvantageAdmin.Checked = False

                            '    'End If

                            'End Using

                        Else

                            TabItemUserDetails_ModuleAccessTab.Visible = False

                            If TabItem Is TabItemUserDetails_ModuleAccessTab Then

                                TabItem = TabControlRightSection_UserDetails.SelectedTab

                            End If

                            'ButtonRightSection_SelectUser.Enabled = False
                            'ButtonRightSection_AddSQLUser.Enabled = False

                            'ComboBoxRightSection_SQLUser.Enabled = False
                            'ComboBoxRightSection_SQLUser.DataSource = New Generic.List(Of AdvantageFramework.Security.Database.Classes.SQLLogin)

                            CheckBoxRightSection_Inactive.Enabled = True
                            CheckBoxRightSection_Inactive.Checked = _UserList.All(Function(User) User.IsInactive = True)

                            'CheckBoxRightSection_IsAdvantageAdmin.Enabled = True
                            'CheckBoxRightSection_IsAdvantageAdmin.Checked = True

                            'If Session.IsSysAdmin OrElse Session.IsSecurityAdmin OrElse
                            '        Session.IsDBOwner OrElse Session.IsDBSecurityAdmin OrElse Session.IsDBAccessAdmin Then

                            '    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            '        For Each User In _UserList

                            '            DatabaseSQLUser = AdvantageFramework.Security.Database.Procedures.DatabaseSQLUserView.LoadByName(SecurityDbContext, User.UserName)

                            '            If DatabaseSQLUser Is Nothing Then

                            '                CheckBoxRightSection_IsAdvantageAdmin.Checked = False
                            '                CheckBoxRightSection_IsAdvantageAdmin.Enabled = False
                            '                Exit For

                            '            Else

                            '                If AdvantageFramework.Security.Database.Procedures.DatabaseSQLUserView.IsDatabaseSQLUserAdvantageAdmin(SecurityDbContext, DatabaseSQLUser.ID) = False Then

                            '                    CheckBoxRightSection_IsAdvantageAdmin.Checked = False
                            '                    Exit For

                            '                End If

                            '            End If

                            '        Next

                            '    End Using

                            'Else

                            '    CheckBoxRightSection_IsAdvantageAdmin.Checked = False
                            '    CheckBoxRightSection_IsAdvantageAdmin.Enabled = False

                            'End If

                            For Each User In _UserList

                                If EmployeeCode = "" Then

                                    EmployeeCode = User.EmployeeCode

                                Else

                                    If User.EmployeeCode <> EmployeeCode Then

                                        ComboBoxRightSection_Employee.SelectedIndex = 0
                                        EmployeeCode = ""

                                        Exit For

                                    End If

                                End If

                            Next

                            If EmployeeCode <> "" Then

                                ComboBoxRightSection_Employee.SelectedValue = EmployeeCode

                            Else

                                ComboBoxRightSection_Employee.SelectedIndex = 0

                            End If

                            CheckBoxRightSection_CheckForUserAccess.Checked = Not _UserList.Any(Function(User) User.CheckForUserAccess = False)
                            CheckBoxUserSettings_CheckForUserAccess.Checked = Not _UserList.Any(Function(User) User.CheckForUserAccess = False)

                        End If

                        'If ComboBoxRightSection_Employee.HasASelectedValue = False AndAlso _UserList IsNot Nothing AndAlso _UserList.Count > 0 Then

                        '    ComboBoxRightSection_Employee.AddComboItemToExistingDataSource(_UserList(0).Employee.ToString, _UserList(0).EmployeeCode, False)
                        '    ComboBoxRightSection_Employee.SelectedValue = _UserList(0).EmployeeCode

                        '    If ComboBoxRightSection_Employee.HasASelectedValue = False Then

                        '        ComboBoxRightSection_Employee.SelectedIndex = 0

                        '    End If

                        'End If

                        Me.ClearChanged()

                    End If

                    'TotalTime = Now - StartTime

                    'Console.WriteLine("LoadUserDetails 2 - " & TotalTime.TotalSeconds)

                    If TabItem Is TabItemUserDetails_GroupsTab AndAlso TabItem.Tag = False Then

                        LoadUserGroup()

                    ElseIf TabItem Is TabItemUserDetails_ClientDivisionProductTab AndAlso TabItemUserDetails_ClientDivisionProductTab.Visible Then

                        LoadUserClientDivisionProductAccess()

                    ElseIf TabItem Is TabItemUserDetails_EmployeesTab Then

                        LoadUserEmployeeAccess()

                    ElseIf TabItem Is TabItemUserDetails_ModuleAccessTab AndAlso TabItem.Tag = False Then

                        LoadUserApplicationAccess()

                        LoadUserModuleAccess()

                    ElseIf TabItem Is TabItemUserDetails_ReportAccessTab AndAlso TabItem.Tag = False Then

                        LoadUserReportAccess()

                    ElseIf TabItem Is TabItemUserDetails_UserSettingsTab AndAlso TabItem.Tag = False Then

                        LoadUserSettings()

                    ElseIf TabItem Is TabItemUserDetails_WorkspacesTab AndAlso TabItem.Tag = False Then

                        LoadUserAppliedWorkspaceTemplate()

                    ElseIf TabItem Is TabItemUserDetails_EmployeeOfficeLimitsTab AndAlso TabItem.Tag = False Then

                        LoadEmployeeOfficeLimits()

                    ElseIf TabItem Is TabItemUserDetails_EmployeeTimesheetFunctionLimitsTab AndAlso TabItem.Tag = False Then

                        LoadEmployeeTimesheetFunctionLimits()

                    End If

                Else


                    'ButtonRightSection_SelectUser.Enabled = False
                    'ButtonRightSection_AddSQLUser.Enabled = False

                    'ComboBoxRightSection_SQLUser.Enabled = False

                    'CheckBoxRightSection_IsAdvantageAdmin.Enabled = False

                    _UserList = Nothing

                    ClearUserDetails = True

                End If

                If ClearUserDetails Then

                    ClearUserDetail()

                End If

                _LoadUserDetails = False

            End If

            'TotalTime = Now - StartTime

            'Console.WriteLine("LoadUserDetails 3 - " & TotalTime.TotalSeconds)

        End Sub
        Private Sub LoadUserAppliedWorkspaceTemplate()

            'objects
            Dim AppliedWorkspaceTemplate As Integer = 0

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If _UserList IsNot Nothing AndAlso _UserList.Count > 0 Then

                    For Each User In _UserList

                        If _UserList.IndexOf(User) = 0 Then

                            AppliedWorkspaceTemplate = User.Employee.WorkspaceTemplateID.GetValueOrDefault(0)

                        Else

                            If AppliedWorkspaceTemplate <> User.Employee.WorkspaceTemplateID.GetValueOrDefault(0) Then

                                AppliedWorkspaceTemplate = 0
                                Exit For

                            End If

                        End If

                    Next

                End If

                ComboBoxWorkspaces_WorkspaceTemplates.SelectedValue = AppliedWorkspaceTemplate

                TabItemUserDetails_WorkspacesTab.Tag = True

            End Using

        End Sub
        Private Sub ClearUserDetail()

            DataGridViewRightSection_UserGroups.DataSource = Nothing
            DataGridViewLeftSection_AvailableGroups.DataSource = Nothing

            UserEmployeeLimitEmployees_EmployeeLimits.ClearControl()

            UserCDPLimitClientDivisionProduct_CDPLimits.ClearControl()

            AdvTreeModuleAccess_Modules.SelectedNode = Nothing

            CheckBoxModuleAccess_IsApplicationBlocked.Checked = False

            CheckBoxModuleAccess_IsBlocked.Checked = False
            CheckBoxModuleAccess_CanPrint.Checked = False
            CheckBoxModuleAccess_CanUpdate.Checked = False
            CheckBoxModuleAccess_CanAdd.Checked = False
            CheckBoxModuleAccess_Custom1.Checked = False
            CheckBoxModuleAccess_Custom2.Checked = False

            If Me.Session IsNot Nothing Then

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    DataGridViewReportAccess_Reports.DataSource = (From Report In AdvantageFramework.Security.Database.Procedures.Report.LoadAllActive(SecurityDbContext).OrderBy(Function(Rpt) Rpt.Type).ThenBy(Function(Rpt) Rpt.Number).ThenBy(Function(Rpt) Rpt.Category).ThenBy(Function(Rpt) Rpt.Name).ToList
                                                                   Select New AdvantageFramework.Security.Database.Classes.ReportAccess(Report)).ToList

                End Using

            End If

            CheckBoxUserSettings_LimitPOsToEmployeeCodeAttached.Checked = False
            CheckBoxUserSettings_LimitTimeEntryToEmployeeCodeAttached.Checked = False
            CheckBoxUserSettings_LimitTimesheetFunctionsForEmployee.Checked = False
            CheckBoxUserSettings_IsWebvantageUserOnly.Checked = False
            CheckBoxUserSettings_AllowProfileUpdate.Checked = False
            CheckBoxRightSection_CheckForUserAccess.Checked = False
            CheckBoxUserSettings_IsCRMUser.Checked = False
            CheckBoxUserSettings_CRMAddEditViewNewBusinessClientsOnly.Checked = False
            CheckBoxUserSettings_IsMediaToolsUser.Checked = False

            EmployeeOfficeLimitControlEmployeeOfficeLimits_EmployeeOfficeLimits.ClearControl()

            EmployeeTimesheetFunctionLimitsControlEmployeeTimesheetFunctionLimits_EmployeeTimesheetFunctionLimits.ClearControl()

            'ComboBoxRightSection_SQLUser.DataSource = New Generic.List(Of AdvantageFramework.Security.Database.Classes.SQLLogin)

            If ComboBoxRightSection_Employee.Items.Count > 0 Then

                ComboBoxRightSection_Employee.SelectedIndex = 0

            End If

        End Sub
        Private Sub LoadModules()

            'objects
            Dim Node As DevComponents.AdvTree.Node = Nothing
            Dim ApplicationID As Integer = 0
            Dim [Module] As AdvantageFramework.Security.Database.Views.ModuleView = Nothing

            If ComboBoxModuleAccess_Application.HasASelectedValue Then

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    AdvTreeModuleAccess_Modules.Nodes.Clear()

                    ApplicationID = ComboBoxModuleAccess_Application.GetSelectedValue

                    For Each [Module] In SecurityDbContext.GetQuery(Of AdvantageFramework.Security.Database.Views.ModuleView).Where(Function(ModView) ModView.ApplicationID = ApplicationID AndAlso ModView.ParentModuleID Is Nothing AndAlso ModView.IsInactive = False).OrderBy(Function(ModView) ModView.SortOrder)

                        Node = New DevComponents.AdvTree.Node

                        Node.Text = [Module].ModuleDescription
                        Node.Tag = [Module]

                        AdvTreeModuleAccess_Modules.Nodes.Add(Node)

                        LoadSubModule(ApplicationID, [Module], Node)

                    Next

                End Using

            End If

        End Sub
        Private Sub LoadSubModule(ByVal ApplicationID As Integer, ByVal ModuleView As AdvantageFramework.Security.Database.Views.ModuleView, ByRef ParentNode As DevComponents.AdvTree.Node)

            'objects
            Dim Node As DevComponents.AdvTree.Node = Nothing

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                For Each [SubModule] In SecurityDbContext.GetQuery(Of AdvantageFramework.Security.Database.Views.ModuleView).Where(Function(ModView) ModView.ApplicationID = ApplicationID AndAlso ModView.ParentModuleID = ModuleView.ModuleID AndAlso ModView.IsInactive = False).OrderBy(Function(ModView) ModView.SortOrder)

                    Node = New DevComponents.AdvTree.Node

                    Node.Text = AdvantageFramework.Security.LoadDescriptionForModule(SecurityDbContext, SubModule)
                    Node.Tag = SubModule

                    ParentNode.Nodes.Add(Node)

                    If SubModule.IsCategory Then

                        LoadSubModule(ApplicationID, SubModule, Node)

                    End If

                Next

            End Using

        End Sub
        Private Sub Save(ByVal Reload As Boolean)

            'objects
            Dim ErrorMessage As String = String.Empty
            Dim UserCode As String = String.Empty
            Dim FunctionCode As String = String.Empty
            Dim EmployeeCode As String = String.Empty

            If DataGridViewLeftSection_Users.HasASelectedRow Then

                If Me.Validator Then

                    FunctionCode = SearchableComboBoxTimesheetFunctionLimits_DefaultFunction.SelectedValue
                    EmployeeCode = ComboBoxRightSection_Employee.GetSelectedValue

                    Me.ShowWaitForm("Processing...")

                    Try

                        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            SecurityDbContext.Database.Connection.Open()
                            SecurityDbContext.Configuration.AutoDetectChangesEnabled = False

                            For Each User In _UserList

                                If String.IsNullOrWhiteSpace(EmployeeCode) = False Then

                                    User.EmployeeCode = EmployeeCode
                                    User.Employee = AdvantageFramework.Security.Database.Procedures.EmployeeView.LoadByEmployeeCode(SecurityDbContext, EmployeeCode)

                                End If

                                User.IsInactive = CheckBoxRightSection_Inactive.Checked

                                SecurityDbContext.UpdateObject(User)

                                If SearchableComboBoxTimesheetFunctionLimits_DefaultFunction.UserEntryChanged Then

                                    If String.IsNullOrWhiteSpace(FunctionCode) Then

                                        SecurityDbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.EMPLOYEE SET DEF_FNC_CODE = NULL WHERE EMP_CODE = '{0}'", User.EmployeeCode))

                                    Else

                                        SecurityDbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.EMPLOYEE SET DEF_FNC_CODE = '{0}' WHERE EMP_CODE = '{1}'", FunctionCode, User.EmployeeCode))

                                    End If

                                End If

                                'AdvantageFramework.Security.Database.Procedures.User.Update(SecurityDbContext, User)

                            Next

                            SecurityDbContext.Configuration.AutoDetectChangesEnabled = True

                            SecurityDbContext.SaveChanges()

                            Me.ClearChanged()

                            If Reload Then

                                LoadUsers()

                            End If

                        End Using

                    Catch ex As Exception

                    End Try

                    Me.CloseWaitForm()

                Else

                    For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                        ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                    Next

                End If

            Else

                ErrorMessage = "Please select a valid user."

            End If

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

        End Sub
        Private Sub CheckToShowModuleAccessTab()

            If _UserList.Count = 1 Then

                If _UserList(0).CheckForUserAccess = False AndAlso _UserList(0).GroupUsers.Count > 0 Then

                    TabItemUserDetails_ModuleAccessTab.Visible = False

                Else

                    TabItemUserDetails_ModuleAccessTab.Visible = True

                End If

            Else

                If TabControlRightSection_UserDetails.SelectedTab Is TabItemUserDetails_ModuleAccessTab Then

                    TabControlRightSection_UserDetails.SelectNextTab()

                End If

                TabItemUserDetails_ModuleAccessTab.Visible = False

            End If

        End Sub
        Private Sub CheckMeidaToolsUserSettingAvailability()

            'objects
            Dim MediaToolUsersAmount As Integer = 0

            If _MediaToolsUsersQuantity > 0 Then

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    For Each UserSetting In AdvantageFramework.Security.Database.Procedures.UserSetting.LoadBySettingCode(SecurityDbContext, AdvantageFramework.Security.UserSettings.IsMediaToolsUser.ToString).Include("User").ToList

                        If UserSetting.User.IsInactive = False Then

                            If String.IsNullOrEmpty(UserSetting.StringValue) = False AndAlso AdvantageFramework.Security.Encryption.Decrypt(UserSetting.StringValue) = UserSetting.User.UserCode Then

                                MediaToolUsersAmount += 1

                            End If

                        End If

                    Next

                End Using

                If MediaToolUsersAmount = _MediaToolsUsersQuantity Then

                    _AvailableMediaToolsUsers = 0

                Else

                    _AvailableMediaToolsUsers = _MediaToolsUsersQuantity - MediaToolUsersAmount

                End If

            ElseIf _MediaToolsUsersQuantity = 0 Then

                _AvailableMediaToolsUsers = 0

            Else

                _AvailableMediaToolsUsers = Integer.MaxValue

            End If

            LabelItemUserLicenseInfo_MediaToolUsersAvailable.Text = If(_AvailableMediaToolsUsers = Integer.MaxValue, "Available: ULTD", String.Format("Available: {0}", _AvailableMediaToolsUsers))

        End Sub
        Private Sub EnableOrDisableActions()

            ButtonItemOfficeCopy_CopyTo.Enabled = EmployeeOfficeLimitControlEmployeeOfficeLimits_EmployeeOfficeLimits.HasLimitedOffices
            ButtonItemEmployeeCopy_CopyTo.Enabled = UserEmployeeLimitEmployees_EmployeeLimits.HasLimitedEmployees
            ButtonItemTimesheetFunctionCopy_CopyTo.Enabled = EmployeeTimesheetFunctionLimitsControlEmployeeTimesheetFunctionLimits_EmployeeTimesheetFunctionLimits.HasLimitedFunctions
            ButtonItemCDPCopy_CopyTo.Enabled = UserCDPLimitClientDivisionProduct_CDPLimits.HasLimitedCDPs

        End Sub
        Private Sub CalculateAvailableUserQuantities()

            Dim AvailablePowerUsers As Integer = 0
            Dim AvailableWVOnlyUsers As Integer = 0

            AdvantageFramework.Security.LicenseKey.CalculateAvailableUserQuantities(Session, _PowerUsersQuantity, _WVOnlyUsersQuantity, AvailablePowerUsers, AvailableWVOnlyUsers)

            LabelItemUserLicenseInfo_PowerUsersAvailable.Text = If(AvailablePowerUsers = Integer.MaxValue, "Available: ULTD", String.Format("Available: {0}", AvailablePowerUsers))
            LabelItemUserLicenseInfo_StandardUsersAvailable.Text = If(AvailableWVOnlyUsers = Integer.MaxValue, "Available: ULTD", String.Format("Available: {0}", AvailableWVOnlyUsers))
            'LabelItemUserLicenseInfo_ClientPortalUsersAvailable.Text = If(_ClientPortalUsersQuantity = -1, "Available: ULTD", String.Format("Available: {0}", _ClientPortalUsersQuantity))

        End Sub
        Public Sub RefreshData()

            If TabControlRightSection_UserDetails.SelectedTab Is TabItemUserDetails_ClientDivisionProductTab AndAlso TabItemUserDetails_ClientDivisionProductTab.Visible Then

                LoadUserClientDivisionProductAccess()

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim UserSetupForm As AdvantageFramework.Security.Setup.Presentation.UserSetupForm = Nothing

            UserSetupForm = New AdvantageFramework.Security.Setup.Presentation.UserSetupForm()

            UserSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub UserSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim LicenseKey As String = ""
            Dim AgencyLicenseKey As String = ""
            Dim LicenseKeyDate As Date = Nothing
            Dim DaysUntilFileExpires As Integer = 0
            Dim DaysUntilKeyExpires As Integer = 0
            Dim PowerUsersQuantity As Integer = 0
            Dim WVOnlyUsersQuantity As Integer = 0
            Dim ClientPortalUsersQuantity As Integer = 0
            Dim MediaToolsUsersQuantity As Integer = 0
            Dim APIUsersQuantity As Integer = 0
            Dim EnableProofingTool As Boolean = False
            Dim AgencyName As String = ""
            Dim DatabaseID As Integer = 0
            Dim ErrorMessage As String = String.Empty

            AdvantageFramework.WinForm.Presentation.Controls.SetByPassUserEntryChanged(Me, True)

            Me.ByPassUserEntryChanged = False
            'ComboBoxRightSection_SQLUser.ByPassUserEntryChanged = False
            ComboBoxRightSection_Employee.ByPassUserEntryChanged = False

            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_ChangePassword.Image = AdvantageFramework.My.Resources.ChangePasswordImage
            ButtonItemEmployees_Terminated.Image = AdvantageFramework.My.Resources.ShowInactiveImage

            ButtonItemOffice_OfficeCopy.Image = AdvantageFramework.My.Resources.CopyImage
            ButtonItemOfficeCopy_CopyFrom.Icon = AdvantageFramework.My.Resources.CopyIcon
            ButtonItemOfficeCopy_CopyTo.Icon = AdvantageFramework.My.Resources.CopyIcon
            ButtonItemEmployee_EmployeeCopy.Image = AdvantageFramework.My.Resources.CopyImage
            ButtonItemEmployeeCopy_CopyFrom.Icon = AdvantageFramework.My.Resources.CopyIcon
            ButtonItemEmployeeCopy_CopyTo.Icon = AdvantageFramework.My.Resources.CopyIcon
            ButtonItemTimesheetFunction_TimesheetFunctionCopy.Image = AdvantageFramework.My.Resources.CopyImage
            ButtonItemTimesheetFunctionCopy_CopyFrom.Icon = AdvantageFramework.My.Resources.CopyIcon
            ButtonItemTimesheetFunctionCopy_CopyTo.Icon = AdvantageFramework.My.Resources.CopyIcon
            ButtonItemCDP_CDPCopy.Image = AdvantageFramework.My.Resources.CopyImage
            ButtonItemCDPCopy_CopyFrom.Icon = AdvantageFramework.My.Resources.CopyIcon
            ButtonItemCDPCopy_CopyTo.Icon = AdvantageFramework.My.Resources.CopyIcon

            'ButtonItemActions_Delete.Visible = False

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    SearchableComboBoxTimesheetFunctionLimits_DefaultFunction.ByPassUserEntryChanged = False

                    SearchableComboBoxTimesheetFunctionLimits_DefaultFunction.DataSource = AdvantageFramework.Database.Procedures.Function.LoadCore(AdvantageFramework.Database.Procedures.Function.LoadAllActiveEmployeeFunctions(DbContext)).ToList

                    _IsAgencyASP = AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext)

                    AgencyLicenseKey = AdvantageFramework.Database.Procedures.Agency.LoadLicenseKey(DbContext)

                    If AgencyLicenseKey <> "" Then

                        LicenseKey = AdvantageFramework.Security.LicenseKey.Read(AgencyLicenseKey, LicenseKeyDate, DaysUntilFileExpires, DaysUntilKeyExpires,
                                                                                 PowerUsersQuantity, WVOnlyUsersQuantity, ClientPortalUsersQuantity, AgencyName,
                                                                                 DatabaseID, MediaToolsUsersQuantity, APIUsersQuantity, EnableProofingTool, ErrorMessage)

                        _PowerUsersQuantity = PowerUsersQuantity
                        _WVOnlyUsersQuantity = WVOnlyUsersQuantity
                        _APIUsersQuantity = APIUsersQuantity

                        _MediaToolsUsersQuantity = MediaToolsUsersQuantity
                        CheckMeidaToolsUserSettingAvailability()

                        '_ClientPortalUsersQuantity = ClientPortalUsersQuantity

                        If _WVOnlyUsersQuantity <> -1 AndAlso _APIUsersQuantity <> 0 Then

                            _WVOnlyUsersQuantity += 1

                        End If

                        If _APIUsersQuantity <> 0 Then

                            LabelItemUserLicenseInfo_StandardUsers.Text &= "*"
                            LabelItemUserLicenseInfo_StandardUserAstrisk.Visible = True

                        End If

                    Else

                        _PowerUsersQuantity = 0
                        _WVOnlyUsersQuantity = 0
                        ButtonItemActions_Add.SecurityEnabled = False

                        _AvailableMediaToolsUsers = 0
                        CheckBoxUserSettings_IsMediaToolsUser.SecurityEnabled = False

                        _LoadUserUserSettings = True
                        CheckBoxUserSettings_IsMediaToolsUser.Checked = False
                        _LoadUserUserSettings = False

                        '_ClientPortalUsersQuantity = 0

                    End If

                    LabelItemUserLicenseInfo_PowerUsersTotal.Text = If(_PowerUsersQuantity = -1, "Total: ULTD", String.Format("Total: {0}", _PowerUsersQuantity))
                    LabelItemUserLicenseInfo_StandardUsersTotal.Text = If(_WVOnlyUsersQuantity = -1, "Total: ULTD", String.Format("Total: {0}", _WVOnlyUsersQuantity))
                    'LabelItemUserLicenseInfo_ClientPortalUsersTotal.Text = If(_ClientPortalUsersQuantity = -1, "Total: ULTD", String.Format("Total: {0}", _ClientPortalUsersQuantity))
                    LabelItemUserLicenseInfo_MediaToolUsersTotal.Text = If(_MediaToolsUsersQuantity = -1, "Total: ULTD", String.Format("Total: {0}", _MediaToolsUsersQuantity))

                    CalculateAvailableUserQuantities()

                    ComboBoxModuleAccess_Application.DataSource = AdvantageFramework.Security.Database.Procedures.Application.Load(SecurityDbContext).Where(Function(Application) Application.ID = AdvantageFramework.Security.Application.Advantage OrElse Application.ID = AdvantageFramework.Security.Application.Webvantage)

                    ComboBoxWorkspaces_WorkspaceTemplates.DataSource = AdvantageFramework.Security.Database.Procedures.WorkspaceTemplate.LoadNonClientPortalWorkspaceTemplates(SecurityDbContext)

                    ComboBoxRightSection_Employee.DataSource = AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActive(DbContext)

                    DataGridViewReportAccess_Reports.DataSource = (From Report In AdvantageFramework.Security.Database.Procedures.Report.LoadAllActive(SecurityDbContext).OrderBy(Function(Rpt) Rpt.Type).ThenBy(Function(Rpt) Rpt.Number).ThenBy(Function(Rpt) Rpt.Category).ThenBy(Function(Rpt) Rpt.Name).ToList
                                                                   Select New AdvantageFramework.Security.Database.Classes.ReportAccess(Report)).ToList

                    DataGridViewReportAccess_Reports.CurrentView.BestFitColumns()

                End Using

            End Using

            'LoadDBLogins()

        End Sub
        Private Sub UserSetupForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            LoadUsers()

            DataGridViewLeftSection_Users.CurrentView.AFActiveFilterString = "[Inactive] = False"

            ButtonItemActions_Delete.Enabled = DataGridViewLeftSection_Users.HasOnlyOneSelectedRow
            ButtonItemActions_Save.Enabled = DataGridViewLeftSection_Users.HasOnlyOneSelectedRow

            TabControlRightSection_UserDetails.Enabled = DataGridViewLeftSection_Users.HasASelectedRow

            CheckBoxRightSection_CheckForUserAccess.Enabled = DataGridViewLeftSection_Users.HasASelectedRow

            ComboBoxRightSection_Employee.Enabled = DataGridViewLeftSection_Users.HasASelectedRow

            'ComboBoxRightSection_SQLUser.SelectionLength = 0
            ComboBoxRightSection_Employee.SelectionLength = 0

            Me.ClearChanged()

        End Sub
        Private Sub UserSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub UserSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub UserSetupForm_BeforeFormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.BeforeFormClosing

            _LoadUserDetails = True

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ComboBoxModuleAccess_Application_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxModuleAccess_Application.SelectedValueChanged

            LoadModules()

            LoadUserApplicationAccess()

        End Sub
        Private Sub AdvTreeModuleAccess_Modules_SelectedNodeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles AdvTreeModuleAccess_Modules.SelectionChanged

            LoadUserModuleAccess()

        End Sub
        Private Sub DataGridViewLeftSection_Users_BeforeSelectionChangedEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles DataGridViewLeftSection_Users.BeforeSelectionChangedEvent

            If Me.IsFormClosing = False AndAlso Me.CheckUserEntryChangedSetting Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Try

                        Save(False)

                    Catch ex As Exception
                        AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                    End Try

                    Me.ClearValidations()
                End If

            End If

        End Sub
        Private Sub DataGridViewLeftSection_Users_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewLeftSection_Users.SelectionChangedEvent

            Dim UserName As String = String.Empty

            LoadUserDetails(Nothing)

            ButtonItemActions_Delete.Enabled = DataGridViewLeftSection_Users.HasASelectedRow
            ButtonItemActions_Save.Enabled = DataGridViewLeftSection_Users.HasOnlyOneSelectedRow

            If DataGridViewLeftSection_Users.HasOnlyOneSelectedRow Then

                If DataGridViewLeftSection_Users.GetFirstSelectedRowCellValue("IsEmployeeTerminated") = False AndAlso DataGridViewLeftSection_Users.GetFirstSelectedRowCellValue("Inactive") = False Then

                    UserName = DataGridViewLeftSection_Users.GetFirstSelectedRowCellValue("UserName")

                    If String.IsNullOrWhiteSpace(UserName) OrElse UserName.Contains("\") = False Then

                        ButtonItemActions_ChangePassword.Enabled = True

                    Else

                        ButtonItemActions_ChangePassword.Enabled = False

                    End If

                Else

                    ButtonItemActions_ChangePassword.Enabled = False

                End If

            Else

                ButtonItemActions_ChangePassword.Enabled = False

            End If

            TabControlRightSection_UserDetails.Enabled = DataGridViewLeftSection_Users.HasASelectedRow

            CheckBoxRightSection_CheckForUserAccess.Enabled = DataGridViewLeftSection_Users.HasASelectedRow

            ComboBoxRightSection_Employee.Enabled = DataGridViewLeftSection_Users.HasASelectedRow

            Me.ClearChanged()

        End Sub
        Private Sub ButtonRightSection_AddToUser_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonRightSection_AddToUser.Click

            'objects
            Dim GroupID As Integer = 0
            Dim GroupIDList As Generic.List(Of Integer) = Nothing

            If DataGridViewLeftSection_Users.HasASelectedRow AndAlso DataGridViewLeftSection_AvailableGroups.HasASelectedRow Then

                GroupIDList = DataGridViewLeftSection_AvailableGroups.GetAllSelectedRowsBookmarkValues.OfType(Of Integer).ToList

                Me.ShowWaitForm()
                Me.ShowWaitForm("Processing...")

                Try

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        For Each User In _UserList

                            For Each GroupID In GroupIDList

                                If AdvantageFramework.Security.Database.Procedures.GroupUser.LoadByGroupIDAndUserID(SecurityDbContext, GroupID, User.ID) Is Nothing Then

                                    AdvantageFramework.Security.Database.Procedures.GroupUser.Insert(SecurityDbContext, GroupID, User.ID, Nothing)

                                End If

                            Next

                        Next

                    End Using

                Catch ex As Exception

                End Try

                Me.ShowWaitForm("Loading...")

                Try

                    LoadUserDetails(Nothing)

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonRightSection_RemoveFromUser_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonRightSection_RemoveFromUser.Click

            'objects
            Dim GroupID As Integer = 0
            Dim GroupUser As AdvantageFramework.Security.Database.Entities.GroupUser = Nothing
            Dim GroupIDList As Generic.List(Of Integer) = Nothing

            If DataGridViewLeftSection_Users.HasASelectedRow AndAlso DataGridViewRightSection_UserGroups.HasASelectedRow Then

                GroupIDList = DataGridViewRightSection_UserGroups.GetAllSelectedRowsBookmarkValues.OfType(Of Integer).ToList

                Me.ShowWaitForm()
                Me.ShowWaitForm("Processing...")

                Try

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        For Each User In _UserList

                            For Each GroupID In GroupIDList

                                GroupUser = AdvantageFramework.Security.Database.Procedures.GroupUser.LoadByGroupIDAndUserID(SecurityDbContext, GroupID, User.ID)

                                If GroupUser IsNot Nothing Then

                                    AdvantageFramework.Security.Database.Procedures.GroupUser.Delete(SecurityDbContext, GroupUser)

                                End If

                            Next

                        Next

                    End Using

                Catch ex As Exception

                End Try

                Me.ShowWaitForm("Loading...")

                Try

                    LoadUserDetails(Nothing)

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonItemActions_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Add.Click

            'objects
            Dim UserID As Integer = 0

            If _IsAgencyASP = False OrElse AdvantageFramework.Security.LicenseKey.CheckAvailableUsers(Me.Session, AdvantageFramework.Security.LicenseKey.Types.All, _PowerUsersQuantity, _WVOnlyUsersQuantity) Then

                If AdvantageFramework.Security.Setup.Presentation.UserEditDialog.ShowFormDialog(UserID) = System.Windows.Forms.DialogResult.OK Then

                    CalculateAvailableUserQuantities()

                    LoadUsers()

                    DataGridViewLeftSection_Users.SelectRow(UserID)

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("There are not enough licenses to add a new user. Please contact software support.")

            End If

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            Try

                Save(True)

            Catch ex As Exception
                AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
            End Try

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim User As AdvantageFramework.Security.Database.Entities.User = Nothing
            Dim AllUsersDeleted As Boolean = True

            If AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to delete this user(s) from Security?  If you continue, the user will be removed and they will no longer have access to any module.", WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                If _UserList IsNot Nothing AndAlso _UserList.Count > 0 Then

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        For Each User In _UserList

                            Try

                                If AdvantageFramework.Security.Database.Procedures.User.Delete(SecurityDbContext, User) = False Then

                                    AllUsersDeleted = False

                                End If

                            Catch ex As Exception
                                AllUsersDeleted = False
                            End Try

                        Next

                    End Using

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                    If AllUsersDeleted = False Then

                        AdvantageFramework.WinForm.MessageBox.Show("One or more users failed to delete.")

                    End If

                    CheckMeidaToolsUserSettingAvailability()

                    CalculateAvailableUserQuantities()

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        LoadUsers(SecurityDbContext)

                    End Using

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_ChangePassword_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_ChangePassword.Click

            'objects
            Dim User As AdvantageFramework.Security.Database.Entities.User = Nothing

            If DataGridViewLeftSection_Users.HasOnlyOneSelectedRow Then

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    User = AdvantageFramework.Security.Database.Procedures.User.LoadByUserID(SecurityDbContext, DataGridViewLeftSection_Users.CurrentView.GetRowCellValue(DataGridViewLeftSection_Users.CurrentView.FocusedRowHandle, AdvantageFramework.Security.Database.Entities.User.Properties.ID.ToString))

                    AdvantageFramework.Database.Presentation.ChangePasswordDialog.ShowFormDialog(Me.Session.ConnectionString, User.UserCode, User.Password, True, True)

                End Using

            End If

        End Sub
        Private Sub CheckBoxModuleAccess_CanAdd_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxModuleAccess_CanAdd.CheckedChanged

            SaveUserModuleAccess(Database.Entities.UserModuleAccess.Properties.CanAdd, CheckBoxModuleAccess_CanAdd.Checked)

        End Sub
        Private Sub CheckBoxModuleAccess_CanPrint_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxModuleAccess_CanPrint.CheckedChanged

            SaveUserModuleAccess(Database.Entities.UserModuleAccess.Properties.CanPrint, CheckBoxModuleAccess_CanPrint.Checked)

        End Sub
        Private Sub CheckBoxModuleAccess_CanUpdate_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxModuleAccess_CanUpdate.CheckedChanged

            SaveUserModuleAccess(Database.Entities.UserModuleAccess.Properties.CanUpdate, CheckBoxModuleAccess_CanUpdate.Checked)

        End Sub
        Private Sub CheckBoxModuleAccess_Custom1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxModuleAccess_Custom1.CheckedChanged

            SaveUserModuleAccess(Database.Entities.UserModuleAccess.Properties.Custom1, CheckBoxModuleAccess_Custom1.Checked)

        End Sub
        Private Sub CheckBoxModuleAccess_Custom2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxModuleAccess_Custom2.CheckedChanged

            SaveUserModuleAccess(Database.Entities.UserModuleAccess.Properties.Custom2, CheckBoxModuleAccess_Custom2.Checked)

        End Sub
        Private Sub CheckBoxModuleAccess_IsBlocked_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxModuleAccess_IsBlocked.CheckedChanged

            SaveUserModuleAccess(Database.Entities.UserModuleAccess.Properties.IsBlocked, CheckBoxModuleAccess_IsBlocked.Checked)

        End Sub
        Private Sub CheckBoxUserSettings_LimitPOsToEmployeeCodeAttached_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxUserSettings_LimitPOsToEmployeeCodeAttached.CheckedChanged

            SaveUserSettings(sender)

        End Sub
        Private Sub CheckBoxUserSettings_LimitTimeEntryToEmployeeCodeAttached_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxUserSettings_LimitTimeEntryToEmployeeCodeAttached.CheckedChanged

            SaveUserSettings(sender)

        End Sub
        Private Sub CheckBoxUserSettings_LimitTimesheetFunctionsForEmployee_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxUserSettings_LimitTimesheetFunctionsForEmployee.CheckedChanged

            SaveUserSettings(sender)

        End Sub
        Private Sub CheckBoxUserSettings_IsWebvantageUserOnly_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxUserSettings_IsWebvantageUserOnly.CheckedChanged

            Dim EnoughUsersAvailable As Boolean = False
            Dim AvailablePowerUsers As Integer = 0
            Dim AvailableWVOnlyUsers As Integer = 0
            Dim ErrorMessage As String = String.Empty

            If _IsAgencyASP Then

                If _SavingUserSettings = False AndAlso _LoadUserUserSettings = False AndAlso _LoadUserDetails = False AndAlso _UserList IsNot Nothing AndAlso _UserList.Count > 0 Then

                    AdvantageFramework.Security.LicenseKey.CalculateAvailableUserQuantities(Session, _PowerUsersQuantity, _WVOnlyUsersQuantity, AvailablePowerUsers, AvailableWVOnlyUsers)

                    If CheckBoxUserSettings_IsWebvantageUserOnly.Checked Then

                        If _UserList.Count <= AvailableWVOnlyUsers Then

                            EnoughUsersAvailable = True

                        Else

                            ErrorMessage = "There are not enough Webvantage Only user licenses available. Please contact software support."

                        End If

                    Else

                        If _UserList.Count <= AvailablePowerUsers Then

                            EnoughUsersAvailable = True

                        Else

                            ErrorMessage = "There are not enough Power user licenses available. Please contact software support."

                        End If

                    End If

                    If EnoughUsersAvailable Then

                        SaveUserSettings(sender)

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                        _SavingUserSettings = True

                        CheckBoxUserSettings_IsWebvantageUserOnly.Checked = Not CheckBoxUserSettings_IsWebvantageUserOnly.Checked

                        _SavingUserSettings = False

                    End If

                End If

            Else

                SaveUserSettings(sender)

            End If

            If _SavingUserSettings = False AndAlso _LoadUserUserSettings = False AndAlso _LoadUserDetails = False Then

                CalculateAvailableUserQuantities()

            End If

        End Sub
        Private Sub CheckBoxUserSettings_AllowProfileUpdate_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxUserSettings_AllowProfileUpdate.CheckedChanged

            SaveUserSettings(sender)

        End Sub
        Private Sub CheckBoxUserSettings_CheckForUserAccess_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxUserSettings_CheckForUserAccess.CheckedChanged

            SaveUserSettings(sender)

        End Sub
        Private Sub CheckBoxUserSettings_IsCRMUser_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxUserSettings_IsCRMUser.CheckedChanged

            SaveUserSettings(sender)

            CheckBoxUserSettings_CRMAddEditViewNewBusinessClientsOnly.Enabled = CheckBoxUserSettings_IsCRMUser.Checked

            If CheckBoxUserSettings_IsCRMUser.Checked = False Then

                CheckBoxUserSettings_CRMAddEditViewNewBusinessClientsOnly.Checked = False

            End If

        End Sub
        Private Sub CheckBoxUserSettings_IsMediaToolsUser_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxUserSettings_IsMediaToolsUser.CheckedChanged

            SaveIsMediaToolsUserSetting()

        End Sub
        'Private Sub ButtonRightSection_AddClientDivisionProductAccess_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        '    'objects
        '    Dim CDPList As IEnumerable(Of Object) = Nothing

        '    If DataGridViewLeftSection_Users.HasASelectedRow AndAlso DataGridViewLeftSection_ClientDivisionProducts.HasASelectedRow Then

        '        CDPList = DataGridViewLeftSection_ClientDivisionProducts.CurrentView.GetSelectedRows.Select(Function(RowHandle) New With {.ProductCode = DataGridViewLeftSection_ClientDivisionProducts.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Security.Database.Entities.SecurityProduct.Properties.Code.ToString),
        '                                                                                                                                  .DivisionCode = DataGridViewLeftSection_ClientDivisionProducts.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Security.Database.Entities.SecurityProduct.Properties.DivisionCode.ToString),
        '                                                                                                                                  .ClientCode = DataGridViewLeftSection_ClientDivisionProducts.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Security.Database.Entities.SecurityProduct.Properties.ClientCode.ToString)}).ToList

        '        Me.ShowWaitForm()
        '        Me.ShowWaitForm("Processing...")

        '        Try

        '            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

        '                For Each User In _UserList

        '                    For Each CDP In CDPList

        '                        AdvantageFramework.Security.Database.Procedures.UserClientDivisionProductAccess.Insert(SecurityDbContext, User.UserCode, CDP.ProductCode, CDP.DivisionCode, CDP.ClientCode, Nothing, Nothing)

        '                    Next

        '                Next

        '            End Using

        '        Catch ex As Exception

        '        End Try

        '        Me.ShowWaitForm("Loading...")

        '        Try

        '            LoadUserClientDivisionProductAccess()

        '        Catch ex As Exception

        '        End Try

        '        Me.CloseWaitForm()

        '    End If

        'End Sub
        'Private Sub ButtonRightSection_RemoveClientDivisionProductAccess_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        '    'objects
        '    Dim UserClientDivisionProductAccess As AdvantageFramework.Security.Database.Entities.UserClientDivisionProductAccess = Nothing
        '    Dim CDPList As IEnumerable(Of Object) = Nothing

        '    If DataGridViewLeftSection_Users.HasASelectedRow AndAlso DataGridViewRightSection_LimitedClientDivisionProducts.HasASelectedRow Then

        '        CDPList = DataGridViewRightSection_LimitedClientDivisionProducts.CurrentView.GetSelectedRows.Select(Function(RowHandle) New With {.ProductCode = DataGridViewRightSection_LimitedClientDivisionProducts.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Security.Database.Entities.UserClientDivisionProductAccess.Properties.ProductCode.ToString),
        '                                                                                                                                          .DivisionCode = DataGridViewRightSection_LimitedClientDivisionProducts.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Security.Database.Entities.UserClientDivisionProductAccess.Properties.DivisionCode.ToString),
        '                                                                                                                                          .ClientCode = DataGridViewRightSection_LimitedClientDivisionProducts.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Security.Database.Entities.UserClientDivisionProductAccess.Properties.ClientCode.ToString)}).ToList

        '        Me.ShowWaitForm()
        '        Me.ShowWaitForm("Processing...")

        '        Try

        '            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

        '                For Each User In _UserList

        '                    For Each CDP In CDPList

        '                        UserClientDivisionProductAccess = AdvantageFramework.Security.Database.Procedures.UserClientDivisionProductAccess.LoadByUserCodeAndProductCodeAndDivisionCodeAndClientCode(SecurityDbContext, User.UserCode, CDP.ProductCode, CDP.DivisionCode, CDP.ClientCode)

        '                        If UserClientDivisionProductAccess IsNot Nothing Then

        '                            AdvantageFramework.Security.Database.Procedures.UserClientDivisionProductAccess.Delete(SecurityDbContext, UserClientDivisionProductAccess)

        '                        End If

        '                    Next

        '                Next

        '            End Using

        '        Catch ex As Exception

        '        End Try

        '        Me.ShowWaitForm("Loading...")

        '        Try

        '            LoadUserClientDivisionProductAccess()

        '        Catch ex As Exception

        '        End Try

        '        Me.CloseWaitForm()

        '    End If

        'End Sub
        'Private Sub DataGridViewRightSection_LimitedClientDivisionProducts_CellValueChangingEvent(ByRef Saved As Boolean, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs)

        '    'objects
        '    Dim UserClientDivisionProductAccess As AdvantageFramework.Security.Database.Entities.UserClientDivisionProductAccess = Nothing
        '    Dim UserClDivProdAccess As AdvantageFramework.Security.Database.Classes.UserClientDivisionProductAccess = Nothing

        '    UserClDivProdAccess = DataGridViewRightSection_LimitedClientDivisionProducts.CurrentView.GetRow(e.RowHandle)

        '    If UserClDivProdAccess IsNot Nothing Then

        '        Me.ShowWaitForm()
        '        Me.ShowWaitForm("Processing...")

        '        Try

        '            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

        '                For Each User In _UserList

        '                    UserClientDivisionProductAccess = AdvantageFramework.Security.Database.Procedures.UserClientDivisionProductAccess.LoadByUserCodeAndProductCodeAndDivisionCodeAndClientCode(SecurityDbContext, User.UserCode, UserClDivProdAccess.ProductCode, UserClDivProdAccess.DivisionCode, UserClDivProdAccess.ClientCode)

        '                    If UserClientDivisionProductAccess IsNot Nothing Then

        '                        If e.Value = True Then

        '                            UserClientDivisionProductAccess.AllowTimeEntryOnly = 1

        '                        Else

        '                            UserClientDivisionProductAccess.AllowTimeEntryOnly = 0

        '                        End If

        '                        AdvantageFramework.Security.Database.Procedures.UserClientDivisionProductAccess.Update(SecurityDbContext, UserClientDivisionProductAccess)

        '                    End If

        '                Next

        '            End Using

        '        Catch ex As Exception

        '        End Try

        '        Me.CloseWaitForm()

        '    End If

        'End Sub
        Private Sub ButtonItemView_ExpandAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemView_ExpandAll.Click

            AdvTreeModuleAccess_Modules.ExpandAll()

        End Sub
        Private Sub ButtonItemView_CollapseAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemView_CollapseAll.Click

            AdvTreeModuleAccess_Modules.CollapseAll()

        End Sub
        Private Sub DataGridViewReportAccess_Reports_CellValueChangingEvent(ByRef Saved As Boolean, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewReportAccess_Reports.CellValueChangingEvent

            'objects
            Dim ReportAccess As AdvantageFramework.Security.Database.Entities.ReportAccess = Nothing
            Dim RptAccess As AdvantageFramework.Security.Database.Classes.ReportAccess = Nothing

            RptAccess = DataGridViewReportAccess_Reports.CurrentView.GetRow(e.RowHandle)

            If RptAccess IsNot Nothing Then

                Me.ShowWaitForm()
                Me.ShowWaitForm("Processing...")

                Try

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        For Each User In _UserList

                            ReportAccess = AdvantageFramework.Security.Database.Procedures.ReportAccess.LoadByUserCodeAndReportCode(SecurityDbContext, User.UserCode, RptAccess.ReportCode)

                            If ReportAccess IsNot Nothing Then

                                If e.Value = True Then

                                    ReportAccess.Enabled = Nothing

                                Else

                                    ReportAccess.Enabled = "N"

                                End If

                                AdvantageFramework.Security.Database.Procedures.ReportAccess.Update(SecurityDbContext, ReportAccess)

                            Else

                                AdvantageFramework.Security.Database.Procedures.ReportAccess.Insert(SecurityDbContext, User.UserCode, RptAccess.ReportCode, IIf(e.Value = True, Nothing, "N"), Nothing)

                            End If

                        Next

                    End Using

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonWorkspaces_Apply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonWorkspaces_Apply.Click

            'objects
            Dim WorkspaceTemplate As AdvantageFramework.Security.Database.Entities.WorkspaceTemplate = Nothing
            Dim User As AdvantageFramework.Security.Database.Entities.User = Nothing
            Dim UserWorkspace As AdvantageFramework.Security.Database.Entities.UserWorkspace = Nothing
            Dim AskToOverrideWorkspaces As Boolean = False
            Dim WorkspaceTemplateDetailsList As Generic.List(Of AdvantageFramework.Security.Database.Entities.WorkspaceTemplateDetail) = Nothing

            If DataGridViewLeftSection_Users.HasASelectedRow Then

                If ComboBoxWorkspaces_WorkspaceTemplates.HasASelectedValue Then

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        WorkspaceTemplate = AdvantageFramework.Security.Database.Procedures.WorkspaceTemplate.LoadByWorkspaceTemplateID(SecurityDbContext, ComboBoxWorkspaces_WorkspaceTemplates.GetSelectedValue)

                        If WorkspaceTemplate IsNot Nothing Then

                            For Each User In _UserList

                                If AdvantageFramework.Security.Database.Procedures.UserWorkspace.LoadByUserCode(SecurityDbContext, User.UserCode).Any Then

                                    AskToOverrideWorkspaces = True
                                    Exit For

                                End If

                            Next

                            If AskToOverrideWorkspaces Then

                                If AdvantageFramework.WinForm.MessageBox.Show("Do you want to replace existing workspaces with the ones in the selected template?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                                    Me.ShowWaitForm()
                                    Me.ShowWaitForm("Processing...")
                                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                                    Try

                                        For Each User In _UserList

                                            For Each UserWorkspace In AdvantageFramework.Security.Database.Procedures.UserWorkspace.LoadByUserCode(SecurityDbContext, User.UserCode).ToList

                                                AdvantageFramework.Security.Database.Procedures.UserWorkspace.Delete(SecurityDbContext, UserWorkspace)

                                            Next

                                        Next

                                    Catch ex As Exception

                                    End Try

                                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False
                                    Me.CloseWaitForm()

                                    AskToOverrideWorkspaces = True

                                Else

                                    AskToOverrideWorkspaces = False

                                End If

                            Else

                                AskToOverrideWorkspaces = True

                            End If

                            If AskToOverrideWorkspaces Then

                                Me.ShowWaitForm()
                                Me.ShowWaitForm("Processing...")
                                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                                Try

                                    For Each User In _UserList

                                        SecurityDbContext.Database.ExecuteSqlCommand("UPDATE dbo.EMPLOYEE SET WV_TMPLT_HDR_ID = " & WorkspaceTemplate.ID & " WHERE EMP_CODE = '" & User.EmployeeCode & "'")

                                        WorkspaceTemplateDetailsList = WorkspaceTemplate.WorkspaceTemplateDetails.ToList

                                        For Each WorkspaceTemplateDetail In WorkspaceTemplateDetailsList

                                            If AdvantageFramework.Security.Database.Procedures.UserWorkspace.Insert(SecurityDbContext, User.UserCode, WorkspaceTemplateDetail.Name, WorkspaceTemplateDetail.Description, WorkspaceTemplateDetail.SortOrder, 0, UserWorkspace) Then

                                                For Each WorkspaceTemplateItem In WorkspaceTemplateDetail.WorkspaceTemplateItems

                                                    If AdvantageFramework.Security.DoesUserHaveAccessToModule(SecurityDbContext, AdvantageFramework.Security.Application.Webvantage, WorkspaceTemplateItem.ModuleID, User.ID) Then

                                                        AdvantageFramework.Security.Database.Procedures.WorkspaceObject.Insert(SecurityDbContext, UserWorkspace.ID, WorkspaceTemplateItem.ModuleID, WorkspaceTemplateItem.ZoneID, WorkspaceTemplateItem.Height, WorkspaceTemplateItem.Width, WorkspaceTemplateItem.TopCoordinate, WorkspaceTemplateItem.LeftCoordinate, WorkspaceTemplateItem.SortOrder, Nothing)

                                                    End If

                                                Next

                                                If WorkspaceTemplateDetailsList.IndexOf(WorkspaceTemplateDetail) = 0 Then

                                                    SecurityDbContext.Database.ExecuteSqlCommand("UPDATE dbo.APP_VARS SET VARIABLE_VALUE = '" & UserWorkspace.ID & "' WHERE USERID = '" & User.UserCode & "' AND [APPLICATION] = 'MY_SETTINGS' AND VARIABLE_NAME = 'CURRENT_WORKSPACE'")

                                                End If

                                            End If

                                        Next

                                    Next

                                Catch ex As Exception

                                End Try

                                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False
                                Me.CloseWaitForm()

                                AdvantageFramework.WinForm.MessageBox.Show("Process Complete")

                            End If

                        Else

                            AdvantageFramework.WinForm.MessageBox.Show("Please select a valid workspace template")

                        End If

                    End Using

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Please select a workspace template")

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select a User")

            End If

        End Sub
        Private Sub TabControlRightSection_UserDetails_SelectedTabChanging(ByVal sender As Object, ByVal e As DevComponents.DotNetBar.TabStripTabChangingEventArgs) Handles TabControlRightSection_UserDetails.SelectedTabChanging

            LoadUserDetails(e.NewTab)

            RibbonBarOptions_View.Visible = (e.NewTab Is TabItemUserDetails_ModuleAccessTab)
            RibbonBarOptions_UserSettings.Visible = (e.NewTab Is TabItemUserDetails_UserSettingsTab)
            RibbonBarOptions_CDP.Visible = (e.NewTab Is TabItemUserDetails_ClientDivisionProductTab)
            RibbonBarOptions_Employee.Visible = (e.NewTab Is TabItemUserDetails_EmployeesTab)
            RibbonBarOptions_Office.Visible = (e.NewTab Is TabItemUserDetails_EmployeeOfficeLimitsTab)
            RibbonBarOptions_TimesheetFunction.Visible = (e.NewTab Is TabItemUserDetails_EmployeeTimesheetFunctionLimitsTab)

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemUserSettings_CheckAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemUserSettings_CheckAll.Click

            Me.ShowWaitForm()
            Me.ShowWaitForm("Processing...")

            Try

                CheckBoxUserSettings_LimitPOsToEmployeeCodeAttached.Checked = True
                CheckBoxUserSettings_LimitTimeEntryToEmployeeCodeAttached.Checked = True
                CheckBoxUserSettings_LimitTimesheetFunctionsForEmployee.Checked = True
                CheckBoxUserSettings_IsWebvantageUserOnly.Checked = True
                CheckBoxUserSettings_AllowProfileUpdate.Checked = True
                CheckBoxRightSection_CheckForUserAccess.Checked = True
                CheckBoxUserSettings_IsCRMUser.Checked = True
                CheckBoxUserSettings_CRMAddEditViewNewBusinessClientsOnly.Checked = True

            Catch ex As Exception

            End Try

            Me.CloseWaitForm()

        End Sub
        Private Sub ButtonItemUserSettings_UncheckAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemUserSettings_UncheckAll.Click

            Me.ShowWaitForm()
            Me.ShowWaitForm("Processing...")

            Try

                CheckBoxUserSettings_LimitPOsToEmployeeCodeAttached.Checked = False
                CheckBoxUserSettings_LimitTimeEntryToEmployeeCodeAttached.Checked = False
                CheckBoxUserSettings_LimitTimesheetFunctionsForEmployee.Checked = False
                CheckBoxUserSettings_IsWebvantageUserOnly.Checked = False
                CheckBoxUserSettings_AllowProfileUpdate.Checked = False
                CheckBoxRightSection_CheckForUserAccess.Checked = False
                CheckBoxUserSettings_IsCRMUser.Checked = False
                CheckBoxUserSettings_CRMAddEditViewNewBusinessClientsOnly.Checked = False

            Catch ex As Exception

            End Try

            Me.CloseWaitForm()

        End Sub
        Private Sub ComboBoxWorkspaces_WorkspaceTemplates_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxWorkspaces_WorkspaceTemplates.SelectedValueChanged

            ButtonWorkspaces_Apply.Enabled = ComboBoxWorkspaces_WorkspaceTemplates.HasASelectedValue

        End Sub
        Private Sub CheckBoxModuleAccess_IsApplicationBlocked_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxModuleAccess_IsApplicationBlocked.CheckedChanged

            SaveUserApplicationAccess()

        End Sub
        'Private Sub ButtonRightSection_AddSQLUser_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        '    If AdvantageFramework.Database.Presentation.SQLUserEditDialog.ShowFormDialog() = System.Windows.Forms.DialogResult.OK Then

        '        ComboBoxRightSection_SQLUser_ReloadComboBox()

        '    End If

        'End Sub
        'Private Sub ButtonRightSection_SelectUser_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        '    'objects
        '    Dim DatabaseSQLUser As AdvantageFramework.Security.Database.Views.DatabaseSQLUser = Nothing
        '    Dim DatabaseSQLUsersList As Generic.List(Of AdvantageFramework.Security.Database.Views.DatabaseSQLUser) = Nothing

        '    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

        '        DatabaseSQLUsersList = AdvantageFramework.Security.Database.Procedures.DatabaseSQLUserView.LoadWithNameThatEndsWith(SecurityDbContext, _UserList(0).UserName).ToList

        '        If DatabaseSQLUsersList.Count > 0 Then

        '            If AdvantageFramework.WinForm.Presentation.GenericListDialog.ShowFormDialog(WinForm.Presentation.GenericListDialog.Type.DatabaseSQLUser, DatabaseSQLUsersList, DatabaseSQLUser) = Windows.Forms.DialogResult.OK Then

        '                If DatabaseSQLUser IsNot Nothing Then

        '                    _UserList(0).UserName = DatabaseSQLUser.Name

        '                    AdvantageFramework.Security.Database.Procedures.User.Update(SecurityDbContext, _UserList(0))

        '                    LoadUserDetails(Nothing)

        '                End If

        '            End If

        '        End If

        '    End Using

        'End Sub
        'Private Sub ComboBoxRightSection_SQLUser_ReloadComboBox()

        '    'objects
        '    Dim SQLLogins As Generic.List(Of AdvantageFramework.Security.Database.Classes.SQLLogin) = Nothing
        '    Dim DatabaseSQLUser As AdvantageFramework.Security.Database.Views.DatabaseSQLUser = Nothing

        '    If _UserList.Count = 1 Then

        '        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

        '            SecurityDbContext.Database.Connection.Open()

        '            DatabaseSQLUser = AdvantageFramework.Security.Database.Procedures.DatabaseSQLUserView.LoadByName(SecurityDbContext, _UserList(0).UserName)

        '        End Using

        '    End If

        '    SQLLogins = AdvantageFramework.Security.LoadSQLLogins(Me.Session)

        '    If DatabaseSQLUser IsNot Nothing AndAlso SQLLogins.Any(Function(Entity) Entity.Name = DatabaseSQLUser.Name) = False Then

        '        SQLLogins.Add(New AdvantageFramework.Security.Database.Classes.SQLLogin(DatabaseSQLUser))

        '    End If

        '    SQLLogins = SQLLogins.OrderBy(Function(SQLLogin) SQLLogin.Name).ToList

        '    ComboBoxRightSection_SQLUser.DataSource = SQLLogins

        'End Sub
        'Private Sub ComboBoxRightSection_SQLUser_SelectedValueChanged(sender As Object, e As EventArgs)

        '    If Me.FormShown AndAlso _LoadUserDetails = False Then

        '        AdvantageFramework.WinForm.MessageBox.Show("By changing the SQL User you are also changing the User Code and SQL User Name. " & System.Environment.NewLine &
        '                                                   "This process removes the original User Code from the database. " & System.Environment.NewLine &
        '                                                   "Existing Security settings are not changed, but some user-level settings unrelated to security will need to be re-established in various areas of the system.", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.OK, "Warning")

        '        If ComboBoxRightSection_SQLUser.GetSelectedValue = Nothing Then

        '            CheckBoxRightSection_Inactive.Enabled = True

        '        Else

        '            CheckBoxRightSection_Inactive.Enabled = False

        '        End If

        '    End If

        'End Sub
        Private Sub CheckBoxRightSection_CheckForUserAccess_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxRightSection_CheckForUserAccess.CheckedChanged

            If _LoadUserDetails = False Then

                CheckBoxUserSettings_CheckForUserAccess.Checked = CheckBoxRightSection_CheckForUserAccess.Checked

            End If

        End Sub
        'Private Sub CheckBoxRightSection_IsAdvantageAdmin_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        '    'objects
        '    Dim DatabaseSQLUser As AdvantageFramework.Security.Database.Views.DatabaseSQLUser = Nothing

        '    If _LoadUserDetails = False Then

        '        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

        '            Me.ShowWaitForm("Processing...")

        '            Try

        '                For Each User In _UserList

        '                    ' User.UserName = User.UserCode
        '                    User.IsAdvanAdmin = CheckBoxRightSection_IsAdvantageAdmin.Checked

        '                    SecurityDbContext.UpdateObject(User)

        '                    'AdvantageFramework.Security.Database.Procedures.User.Update(SecurityDbContext, User)

        '                    'If ComboBoxRightSection_SQLUser.Enabled AndAlso ComboBoxRightSection_SQLUser.HasASelectedValue Then

        '                    '    If AdvantageFramework.Security.Database.Procedures.DatabaseSQLUserView.CreateDatabaseSQLUser(SecurityDbContext, ComboBoxRightSection_SQLUser.Text, CheckBoxRightSection_IsAdvantageAdmin.Checked, False) Then

        '                    '        User.UserName = ComboBoxRightSection_SQLUser.Text

        '                    '    End If

        '                    'End If

        '                    'DatabaseSQLUser = AdvantageFramework.Security.Database.Procedures.DatabaseSQLUserView.LoadByName(SecurityDbContext, User.UserName)

        '                    'If DatabaseSQLUser IsNot Nothing Then

        '                    '    If CheckBoxRightSection_IsAdvantageAdmin.Checked AndAlso
        '                    '            AdvantageFramework.Security.Database.Procedures.DatabaseSQLUserView.IsDatabaseSQLUserAdvantageAdmin(SecurityDbContext, DatabaseSQLUser.ID) = False Then

        '                    '        SecurityDbContext.Database.ExecuteSqlCommand(String.Format("EXEC sp_addrolemember N'advan_admin', N'{0}'", User.UserName))

        '                    '    ElseIf CheckBoxRightSection_IsAdvantageAdmin.Checked = False AndAlso
        '                    '            AdvantageFramework.Security.Database.Procedures.DatabaseSQLUserView.IsDatabaseSQLUserAdvantageAdmin(SecurityDbContext, DatabaseSQLUser.ID) Then

        '                    '        SecurityDbContext.Database.ExecuteSqlCommand(String.Format("EXEC sp_droprolemember N'advan_admin', N'{0}'", User.UserName))

        '                    '    End If

        '                    'End If

        '                Next

        '                SecurityDbContext.SaveChanges()

        '            Catch ex As Exception

        '            End Try

        '            Me.CloseWaitForm()

        '        End Using

        '    End If

        'End Sub
        Private Sub ButtonItemEmployees_Terminated_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemEmployees_Terminated.CheckedChanged

            If Me.FormShown Then

                LoadUsers()

            End If

        End Sub
        Private Sub ButtonItemOfficeCopy_CopyFrom_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemOfficeCopy_CopyFrom.Click

            EmployeeOfficeLimitControlEmployeeOfficeLimits_EmployeeOfficeLimits.CopyOfficeLimits(False)

        End Sub
        Private Sub ButtonItemOfficeCopy_CopyTo_Click(sender As Object, e As System.EventArgs) Handles ButtonItemOfficeCopy_CopyTo.Click

            EmployeeOfficeLimitControlEmployeeOfficeLimits_EmployeeOfficeLimits.CopyOfficeLimits(True)

        End Sub
        Private Sub ButtonItemCDPCopy_CopyFrom_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemCDPCopy_CopyFrom.Click

            UserCDPLimitClientDivisionProduct_CDPLimits.CopyCDPLimits(False)

        End Sub
        Private Sub ButtonItemCDPCopy_CopyTo_Click(sender As Object, e As System.EventArgs) Handles ButtonItemCDPCopy_CopyTo.Click

            UserCDPLimitClientDivisionProduct_CDPLimits.CopyCDPLimits(True)

        End Sub
        Private Sub ButtonItemEmployeeCopy_CopyFrom_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemEmployeeCopy_CopyFrom.Click

            UserEmployeeLimitEmployees_EmployeeLimits.CopyEmployeeLimits(False)

        End Sub
        Private Sub ButtonItemEmployeeCopy_CopyTo_Click(sender As Object, e As System.EventArgs) Handles ButtonItemEmployeeCopy_CopyTo.Click

            UserEmployeeLimitEmployees_EmployeeLimits.CopyEmployeeLimits(True)

        End Sub
        Private Sub ButtonItemTimesheetFunctionCopy_CopyFrom_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemTimesheetFunctionCopy_CopyFrom.Click

            EmployeeTimesheetFunctionLimitsControlEmployeeTimesheetFunctionLimits_EmployeeTimesheetFunctionLimits.CopyFunctionLimits(False)

        End Sub
        Private Sub ButtonItemTimesheetFunctionCopy_CopyTo_Click(sender As Object, e As System.EventArgs) Handles ButtonItemTimesheetFunctionCopy_CopyTo.Click

            EmployeeTimesheetFunctionLimitsControlEmployeeTimesheetFunctionLimits_EmployeeTimesheetFunctionLimits.CopyFunctionLimits(True)

        End Sub
        Private Sub UserCDPLimitClientDivisionProduct_CDPLimits_CDPsChangedEvent() Handles UserCDPLimitClientDivisionProduct_CDPLimits.CDPsChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub UserEmployeeLimitEmployees_EmployeeLimits_EmployeesChangedEvent() Handles UserEmployeeLimitEmployees_EmployeeLimits.EmployeesChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub EmployeeOfficeLimitControlEmployeeOfficeLimits_EmployeeOfficeLimits_OfficesChangedEvent() Handles EmployeeOfficeLimitControlEmployeeOfficeLimits_EmployeeOfficeLimits.OfficesChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub EmployeeTimesheetFunctionLimitsControlEmployeeTimesheetFunctionLimits_EmployeeTimesheetFunctionLimits_FunctionsChangedEvent() Handles EmployeeTimesheetFunctionLimitsControlEmployeeTimesheetFunctionLimits_EmployeeTimesheetFunctionLimits.FunctionsChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub CheckBoxRightSection_Inactive_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxRightSection_Inactive.CheckedChanged

            Dim EnoughPowerUsersAvailable As Boolean = False
            Dim EnoughWVOnlyUsersAvailable As Boolean = False
            Dim AvailablePowerUsers As Integer = 0
            Dim AvailableWVOnlyUsers As Integer = 0
            Dim OneOrMoreUserCannotBeActivated As Boolean = False

            If _LoadUserDetails = False AndAlso _DisableInactiveCheckedChanged = False Then

                If CheckBoxRightSection_Inactive.Checked Then

                    If AdvantageFramework.WinForm.MessageBox.Show("Deactivating the selected User(s) removes the User(s) from all Security Groups.  Are you sure you want to continue?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                        Me.ShowWaitForm("Processing...")

                        Try

                            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                                SecurityDbContext.Database.Connection.Open()

                                For Each User In _UserList

                                    User.IsInactive = CheckBoxRightSection_Inactive.Checked

                                    'User.UserName = String.Empty
                                    User.Password = String.Empty

                                    For Each GroupUser In AdvantageFramework.Security.Database.Procedures.GroupUser.LoadByUserID(SecurityDbContext, User.ID).ToList

                                        SecurityDbContext.DeleteEntityObject(GroupUser)

                                    Next

                                    SecurityDbContext.UpdateObject(User)

                                    SecurityDbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.SEC_USER_SETTING SET STRING_VALUE = '' WHERE SEC_USER_ID = {0} AND SETTING_CODE = 'IsMediaToolsUser'", User.ID))

                                Next

                                SecurityDbContext.SaveChanges()

                            End Using

                        Catch ex As Exception

                        End Try

                        If Me.UserEntryChanged = False Then

                            LoadUsers()

                        End If

                        CheckMeidaToolsUserSettingAvailability()

                        CalculateAvailableUserQuantities()

                        Me.CloseWaitForm()

                    Else

                        _DisableInactiveCheckedChanged = True

                        CheckBoxRightSection_Inactive.Checked = Not CheckBoxRightSection_Inactive.Checked

                        _DisableInactiveCheckedChanged = False

                    End If

                Else

                    If _IsAgencyASP Then

                        AdvantageFramework.Security.LicenseKey.CalculateAvailableUserQuantities(Session, _PowerUsersQuantity, _WVOnlyUsersQuantity, AvailablePowerUsers, AvailableWVOnlyUsers)

                        If _UserList.Where(Function(Entity) Entity.UserSettings.Any(Function(UserSetting) UserSetting.SettingCode = AdvantageFramework.Security.UserSettings.TIME_ENTRY_ONLY.ToString AndAlso
                                                                                                          UserSetting.StringValue = "Y") = False).Count <= AvailablePowerUsers Then

                            EnoughPowerUsersAvailable = True

                        End If

                        If _UserList.Where(Function(Entity) Entity.UserSettings.Any(Function(UserSetting) UserSetting.SettingCode = AdvantageFramework.Security.UserSettings.TIME_ENTRY_ONLY.ToString AndAlso
                                                                                                          UserSetting.StringValue = "Y") = True).Count <= AvailableWVOnlyUsers Then

                            EnoughWVOnlyUsersAvailable = True

                        End If

                    Else

                        EnoughPowerUsersAvailable = True
                        EnoughWVOnlyUsersAvailable = True
                        AvailablePowerUsers = 9999
                        AvailableWVOnlyUsers = 9999

                    End If

                    If EnoughPowerUsersAvailable OrElse EnoughWVOnlyUsersAvailable Then

                        Me.ShowWaitForm("Processing...")

                        Try

                            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                                SecurityDbContext.Database.Connection.Open()

                                For Each User In _UserList

                                    If User.UserSettings.Any(Function(UserSetting) UserSetting.SettingCode = AdvantageFramework.Security.UserSettings.TIME_ENTRY_ONLY.ToString AndAlso UserSetting.StringValue = "Y") = False Then

                                        If AvailablePowerUsers > 0 Then

                                            User.IsInactive = CheckBoxRightSection_Inactive.Checked

                                            SecurityDbContext.UpdateObject(User)

                                            SecurityDbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.SEC_USER_SETTING SET STRING_VALUE = '' WHERE SEC_USER_ID = {0} AND SETTING_CODE = 'IsMediaToolsUser'", User.ID))

                                            AvailablePowerUsers -= 1

                                        Else

                                            OneOrMoreUserCannotBeActivated = True

                                        End If

                                    Else

                                        If AvailableWVOnlyUsers > 0 Then

                                            User.IsInactive = CheckBoxRightSection_Inactive.Checked

                                            SecurityDbContext.UpdateObject(User)

                                            SecurityDbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.SEC_USER_SETTING SET STRING_VALUE = '' WHERE SEC_USER_ID = {0} AND SETTING_CODE = 'IsMediaToolsUser'", User.ID))

                                            AvailableWVOnlyUsers -= 1

                                        Else

                                            OneOrMoreUserCannotBeActivated = True

                                        End If

                                    End If

                                Next

                                SecurityDbContext.SaveChanges()

                            End Using

                        Catch ex As Exception

                        End Try

                        If OneOrMoreUserCannotBeActivated AndAlso _IsAgencyASP Then

                            If _UserList.Count > 1 Then

                                AdvantageFramework.WinForm.MessageBox.Show("One or more users cannot be activated because of insufficient licenses.")

                            Else

                                AdvantageFramework.WinForm.MessageBox.Show("User cannot be activated because of insufficient licenses.")

                            End If

                        End If

                        If Me.UserEntryChanged = False Then

                            LoadUsers()

                        End If

                        CalculateAvailableUserQuantities()

                        Me.CloseWaitForm()

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show("There are not enough licenses to activate selected user(s). Please contact software support.")

                        _DisableInactiveCheckedChanged = True

                        CheckBoxRightSection_Inactive.Checked = Not CheckBoxRightSection_Inactive.Checked

                        _DisableInactiveCheckedChanged = False

                    End If

                End If

            End If

        End Sub
        Private Sub CheckBoxUserSettings_CRMAddEditViewNewBusinessClientsOnly_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxUserSettings_CRMAddEditViewNewBusinessClientsOnly.CheckedChanged

            SaveUserSettings(sender)

        End Sub

#End Region

#End Region

    End Class

End Namespace
