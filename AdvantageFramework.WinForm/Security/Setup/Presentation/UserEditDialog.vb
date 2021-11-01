Namespace Security.Setup.Presentation

    Public Class UserEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _UserID As Integer = 0
        Private _PowerUsersQuantity As Integer = 0
        Private _WVOnlyUsersQuantity As Integer = 0
        Private _IsAgencyASP As Boolean = False

#End Region

#Region " Properties "

        Private Property UserID As Integer
            Get
                UserID = _UserID
            End Get
            Set(ByVal value As Integer)
                _UserID = value
            End Set
        End Property

#End Region

#Region " Methods "

        Private Sub New(UserID As Integer)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _UserID = UserID

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef UserID As Integer) As System.Windows.Forms.DialogResult

            'objects
            Dim UserEditDialog As AdvantageFramework.Security.Setup.Presentation.UserEditDialog = Nothing

            UserEditDialog = New AdvantageFramework.Security.Setup.Presentation.UserEditDialog(UserID)

            ShowFormDialog = UserEditDialog.ShowDialog()

            UserID = UserEditDialog.UserID

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub UserEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim User As AdvantageFramework.Security.Database.Entities.User = Nothing
            Dim DatabaseSQLUser As AdvantageFramework.Security.Database.Views.DatabaseSQLUser = Nothing
            Dim DatabaseSQLUsersList As Generic.List(Of AdvantageFramework.Security.Database.Views.DatabaseSQLUser) = Nothing
            Dim LicenseKey As String = String.Empty
            Dim AgencyLicenseKey As String = String.Empty
            Dim LicenseKeyDate As Date = Nothing
            Dim DaysUntilFileExpires As Integer = 0
            Dim DaysUntilKeyExpires As Integer = 0
            Dim PowerUsersQuantity As Integer = 0
            Dim WVOnlyUsersQuantity As Integer = 0
            Dim ClientPortalUsersQuantity As Integer = 0
            Dim MediaToolsUsersQuantity As Integer = 0
            Dim APIUsersQuantity As Integer = 0
            Dim EnableProofingTool As Boolean = False
            Dim AgencyName As String = String.Empty
            Dim DatabaseID As Integer = 0
            Dim ErrorMessage As String = String.Empty

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ComboBoxForm_Employee.DataSource = (From Employee In AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActive(DbContext)
                                                        Select New With {.FullName = If(Employee.MiddleInitial IsNot Nothing AndAlso Employee.MiddleInitial.Trim <> "",
                                                                                        Employee.FirstName & " " & Employee.MiddleInitial & ". " & Employee.LastName,
                                                                                        Employee.FirstName & " " & Employee.LastName) & " (" & Employee.Code & ")",
                                                                         .Code = Employee.Code}).ToList

                    If _UserID = 0 Then

                        ButtonForm_Update.Visible = False
                        ButtonForm_Add.Visible = True
                        Me.Text = "Add User"

                        _IsAgencyASP = AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext)

                        AgencyLicenseKey = AdvantageFramework.Database.Procedures.Agency.LoadLicenseKey(DbContext)

                        If AgencyLicenseKey <> "" Then

                            LicenseKey = AdvantageFramework.Security.LicenseKey.Read(AgencyLicenseKey, LicenseKeyDate, DaysUntilFileExpires, DaysUntilKeyExpires,
                                                                                     PowerUsersQuantity, WVOnlyUsersQuantity, ClientPortalUsersQuantity, AgencyName,
                                                                                     DatabaseID, MediaToolsUsersQuantity, APIUsersQuantity, EnableProofingTool, ErrorMessage)

                            _PowerUsersQuantity = PowerUsersQuantity
                            _WVOnlyUsersQuantity = WVOnlyUsersQuantity

                            If _WVOnlyUsersQuantity <> -1 AndAlso APIUsersQuantity <> 0 Then

                                _WVOnlyUsersQuantity += 1

                            End If

                        Else

                            _PowerUsersQuantity = 0
                            _WVOnlyUsersQuantity = 0

                        End If

                        'If Session.IsSysAdmin OrElse Session.IsSecurityAdmin OrElse
                        '        Session.IsDBOwner OrElse Session.IsDBSecurityAdmin OrElse Session.IsDBAccessAdmin Then

                        'If Session.IsAdmin Then

                        '    'ComboBoxForm_SQLUser.DataSource = AdvantageFramework.Security.LoadSQLLogins(Me.Session).OrderBy(Function(SQLLogin) SQLLogin.Name).ToList

                        'Else

                        '    AdvantageFramework.WinForm.MessageBox.Show("You are not allowed to add a user. Please contact your IT administrator or Advantage Technical Support.")
                        '    Me.Close()

                        'End If

                    Else

                        User = AdvantageFramework.Security.Database.Procedures.User.LoadByUserID(SecurityDbContext, _UserID)

                        SecurityDbContext.Entry(User).Collection("UserSettings").Load()

                        If User IsNot Nothing Then

                            ButtonForm_Update.Visible = True
                            ButtonForm_Add.Visible = False
                            Me.Text = "Edit User"

                            CheckBoxForm_CheckForUserAccess.Checked = User.CheckForUserAccess
                            ComboBoxForm_Employee.SelectedValue = User.EmployeeCode

                            If User.UserSettings IsNot Nothing AndAlso User.UserSettings.Any(Function(Entity) Entity.SettingCode = AdvantageFramework.Security.UserSettings.TIME_ENTRY_ONLY.ToString AndAlso Entity.StringValue = "Y") Then

                                CheckBoxUserSettings_IsWebvantageUserOnly.Checked = True

                            Else

                                CheckBoxUserSettings_IsWebvantageUserOnly.Checked = False

                            End If

                            CheckBoxUserSettings_IsWebvantageUserOnly.SecurityEnabled = False

                            'DatabaseSQLUser = AdvantageFramework.Security.Database.Procedures.DatabaseSQLUserView.LoadByName(SecurityDbContext, User.UserName)

                            'If DatabaseSQLUser Is Nothing Then

                            'If Session.IsSysAdmin OrElse Session.IsSecurityAdmin OrElse
                            '        Session.IsDBOwner OrElse Session.IsDBSecurityAdmin OrElse Session.IsDBAccessAdmin Then

                            ' If Session.IsSysAdmin OrElse Session.IsSecurityAdmin Then

                            'DatabaseSQLUsersList = AdvantageFramework.Security.Database.Procedures.DatabaseSQLUserView.LoadWithNameThatEndsWith(SecurityDbContext, User.UserName).ToList

                            'If DatabaseSQLUsersList.Count > 0 Then

                            '    If AdvantageFramework.WinForm.Presentation.GenericListDialog.ShowFormDialog(WinForm.Presentation.GenericListDialog.Type.DatabaseSQLUser, DatabaseSQLUsersList, DatabaseSQLUser) = Windows.Forms.DialogResult.OK Then

                            '        If DatabaseSQLUser IsNot Nothing Then

                            '            User.UserName = DatabaseSQLUser.Name

                            '            AdvantageFramework.Security.Database.Procedures.User.Update(SecurityDbContext, User)

                            '        End If

                            '    End If

                            '   End If

                            'End If

                            'End If

                            If DatabaseSQLUser IsNot Nothing Then

                                'CheckBoxForm_IsAdvantageAdmin.Enabled = True
                                'ComboBoxForm_SQLUser.Enabled = False
                                'ButtonForm_AddSQLUser.Enabled = False

                                'ComboBoxForm_SQLUser.DataSource = AdvantageFramework.Security.Database.Procedures.ServerSQLUserView.Load(SecurityDbContext).OrderBy(Function(SQLUser) SQLUser.Name)

                                ' ComboBoxForm_SQLUser.SelectedIndex = ComboBoxForm_SQLUser.FindStringExact(DatabaseSQLUser.Name)

                                'If User.IsAdvanAdmin Then

                                '    CheckBoxForm_IsAdvantageAdmin.Checked = True

                                'Else

                                '    CheckBoxForm_IsAdvantageAdmin.Checked = False

                                'End If

                            Else

                                'ButtonForm_AddSQLUser.Enabled = (Session.IsSysAdmin OrElse Session.IsSecurityAdmin)

                                'If Session.IsAdmin Then

                                '    CheckBoxForm_IsAdvantageAdmin.Enabled = True

                                '    'ComboBoxForm_SQLUser.Enabled = True
                                '    ' ComboBoxForm_SQLUser.DataSource = AdvantageFramework.Security.LoadSQLLogins(Me.Session).OrderBy(Function(SQLLogin) SQLLogin.Name).ToList

                                'Else

                                '    CheckBoxForm_IsAdvantageAdmin.Enabled = False
                                '    ' ComboBoxForm_SQLUser.Enabled = False

                                'End If

                                'CheckBoxForm_IsAdvantageAdmin.Checked = False

                            End If

                        Else

                            AdvantageFramework.WinForm.MessageBox.Show("The user you are trying to edit does not exist anymore.")
                            Me.Close()

                        End If

                    End If

                End Using

            End Using

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Add.Click

            'objects
            Dim [Continue] As Boolean = False
            Dim User As AdvantageFramework.Security.Database.Entities.User = Nothing
            Dim IsValid As Boolean = False
            Dim UserCode As String = String.Empty
            Dim ErrorMessage As String = String.Empty
            Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing
            Dim NTAccount As System.Security.Principal.NTAccount = Nothing
            Dim SecurityIdentifier As System.Security.Principal.SecurityIdentifier = Nothing
            Dim SID As String = String.Empty

            If _IsAgencyASP Then

                If CheckBoxUserSettings_IsWebvantageUserOnly.Checked Then

                    If AdvantageFramework.Security.LicenseKey.CheckAvailableUsers(Me.Session, AdvantageFramework.Security.LicenseKey.Types.WebvantageOnly, _PowerUsersQuantity, _WVOnlyUsersQuantity) Then

                        [Continue] = True

                    Else

                        ErrorMessage = "There are not enough licenses for a new Webvantage Only user. Please contact Software Support."

                    End If

                Else

                    If AdvantageFramework.Security.LicenseKey.CheckAvailableUsers(Me.Session, AdvantageFramework.Security.LicenseKey.Types.PowerUser, _PowerUsersQuantity, _WVOnlyUsersQuantity) Then

                        [Continue] = True

                    Else

                        ErrorMessage = "There are not enough licenses for a new Power user. Please contact Software Support."

                    End If

                End If

            Else

                [Continue] = True

            End If

            If [Continue] Then

                [Continue] = False

                If String.IsNullOrWhiteSpace(TextBoxForm_UserName.Text) = False AndAlso TextBoxForm_UserName.Text.Contains("\") Then

                    Try

                        NTAccount = New System.Security.Principal.NTAccount(TextBoxForm_UserName.Text)
                        SecurityIdentifier = NTAccount.Translate(GetType(System.Security.Principal.SecurityIdentifier))

                        SID = SecurityIdentifier.Value

                        [Continue] = (String.IsNullOrWhiteSpace(SID) = False)

                    Catch ex As Exception

                        ErrorMessage = "Cannot location SID for the user entered.  Please contact software support."
                        ErrorMessage &= System.Environment.NewLine & System.Environment.NewLine & ex.Message

                        If ex.InnerException IsNot Nothing Then

                            ErrorMessage &= System.Environment.NewLine & System.Environment.NewLine & ex.InnerException.Message

                        End If

                    End Try

                Else

                    [Continue] = True

                End If

                If [Continue] Then

                    If Me.Validator Then

                        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            If TextBoxForm_UserName.Text.Contains("\") Then

                                UserCode = TextBoxForm_UserName.Text.Substring(TextBoxForm_UserName.Text.IndexOf("\") + 1)

                            Else

                                UserCode = TextBoxForm_UserName.Text

                            End If

                            Try

                                If SecurityDbContext.Users.Any(Function(Entity) Entity.UserCode.ToUpper = UserCode.ToUpper) = False Then

                                    IsValid = True

                                End If

                            Catch ex As Exception
                                IsValid = False
                            End Try

                            If IsValid Then

                                Me.ShowWaitForm("Processing...")

                                If AdvantageFramework.Security.Database.Procedures.User.Insert(SecurityDbContext, UserCode, ComboBoxForm_Employee.GetSelectedValue, TextBoxForm_UserName.Text,
                                                                                               CheckBoxForm_CheckForUserAccess.Checked, SID, User) Then

                                    If CheckBoxUserSettings_IsWebvantageUserOnly.Checked Then

                                        Try

                                            UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, User.ID, AdvantageFramework.Security.UserSettings.TIME_ENTRY_ONLY.ToString)

                                        Catch ex As Exception
                                            UserSetting = Nothing
                                        End Try

                                        If UserSetting IsNot Nothing Then

                                            UserSetting.StringValue = "Y"

                                            AdvantageFramework.Security.Database.Procedures.UserSetting.Update(SecurityDbContext, UserSetting)

                                        End If

                                    End If

                                    _UserID = User.ID

                                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                                    Me.Close()

                                End If

                                Me.CloseWaitForm()

                            Else

                                AdvantageFramework.WinForm.MessageBox.Show("Please enter in a unique user name.")

                            End If

                        End Using

                    End If

                Else

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_Update_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Update.Click

            'objects
            Dim User As AdvantageFramework.Security.Database.Entities.User = Nothing
            Dim Employee As AdvantageFramework.Security.Database.Views.Employee = Nothing
            Dim DatabaseSQLUser As AdvantageFramework.Security.Database.Views.DatabaseSQLUser = Nothing
            Dim ErrorMessage As String = String.Empty

            If Me.Validator Then

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Me.ShowWaitForm("Processing...")

                    User = AdvantageFramework.Security.Database.Procedures.User.LoadByUserID(SecurityDbContext, _UserID)

                    If User IsNot Nothing Then

                        User.Employee = AdvantageFramework.Security.Database.Procedures.EmployeeView.LoadByEmployeeCode(SecurityDbContext, ComboBoxForm_Employee.GetSelectedValue)
                        User.CheckForUserAccess = CheckBoxForm_CheckForUserAccess.Checked

                        'If ComboBoxForm_SQLUser.Enabled Then

                        '    If AdvantageFramework.Security.Database.Procedures.DatabaseSQLUserView.CreateDatabaseSQLUser(SecurityDbContext, ComboBoxForm_SQLUser.Text, CheckBoxForm_IsAdvantageAdmin.Checked, True) Then

                        '        User.UserName = ComboBoxForm_SQLUser.Text

                        '    End If

                        'End If

                        'User.IsAdvanAdmin = CheckBoxForm_IsAdvantageAdmin.Checked

                        'DatabaseSQLUser = AdvantageFramework.Security.Database.Procedures.DatabaseSQLUserView.LoadByName(SecurityDbContext, User.UserName)

                        'If DatabaseSQLUser IsNot Nothing Then

                        '    If CheckBoxForm_IsAdvantageAdmin.Checked AndAlso
                        '            AdvantageFramework.Security.Database.Procedures.DatabaseSQLUserView.IsDatabaseSQLUserAdvantageAdmin(SecurityDbContext, DatabaseSQLUser.ID) = False Then

                        '        SecurityDbContext.Database.ExecuteSqlCommand(String.Format("EXEC sp_addrolemember N'advan_admin', N'{0}'", User.UserName))

                        '    ElseIf CheckBoxForm_IsAdvantageAdmin.Checked = False AndAlso
                        '            AdvantageFramework.Security.Database.Procedures.DatabaseSQLUserView.IsDatabaseSQLUserAdvantageAdmin(SecurityDbContext, DatabaseSQLUser.ID) Then

                        '        SecurityDbContext.Database.ExecuteSqlCommand(String.Format("EXEC sp_droprolemember N'advan_admin', N'{0}'", User.UserName))

                        '    End If

                        'End If

                        If AdvantageFramework.Security.Database.Procedures.User.Update(SecurityDbContext, User) Then

                            Me.DialogResult = System.Windows.Forms.DialogResult.OK
                            Me.Close()

                        End If

                    End If

                    Me.CloseWaitForm()

                End Using

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ComboBoxForm_SQLUser_ReloadComboBox()

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If ButtonForm_Add.Visible Then

                    'ComboBoxForm_SQLUser.DataSource = AdvantageFramework.Security.Database.Procedures.ServerSQLUserView.LoadAvailableSQLUsers(SecurityDbContext).OrderBy(Function(SQLUser) SQLUser.Name)

                Else

                    'ComboBoxForm_SQLUser.DataSource = AdvantageFramework.Security.Database.Procedures.ServerSQLUserView.Load(SecurityDbContext).OrderBy(Function(SQLUser) SQLUser.Name)

                End If

            End Using

        End Sub
        Private Sub ButtonForm_AddSQLUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

            If AdvantageFramework.Database.Presentation.SQLUserEditDialog.ShowFormDialog() = System.Windows.Forms.DialogResult.OK Then

                ComboBoxForm_SQLUser_ReloadComboBox()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
