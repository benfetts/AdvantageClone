Namespace Security.Presentation

    Public Class LoginDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _Session As AdvantageFramework.Security.Session = Nothing
        Protected _DbContext As AdvantageFramework.Database.DbContext = Nothing
        Protected _Application As AdvantageFramework.Security.Application = Application.Advantage
        Protected Friend _SuperValidator As DevComponents.DotNetBar.Validator.SuperValidator = Nothing
        Protected Friend _ErrorProvider As System.Windows.Forms.ErrorProvider = Nothing
        Protected Friend _Highlighter As DevComponents.DotNetBar.Validator.Highlighter = Nothing
        Protected _UpperCaseDatabaseAndUserName As Boolean = False
        Protected _ConnectionDatabaseProfiles As Generic.List(Of AdvantageFramework.Database.ConnectionDatabaseProfile) = Nothing
        Protected _AdvantageConfigurator As AdvantageFramework.WinForm.AdvantageConfigurator = Nothing
        Protected _FormShown As Boolean = False

#End Region

#Region " Properties "

        Private ReadOnly Property Session As AdvantageFramework.Security.Session
            Get
                Session = _Session
            End Get
        End Property
        Private ReadOnly Property DbContext As AdvantageFramework.Database.DbContext
            Get
                DbContext = _DbContext
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal Application As AdvantageFramework.Security.Application, ByVal ServerName As String, ByVal DatabaseName As String,
                        ByVal UseWindowsAuthentication As Boolean, ByVal UserName As String, ByVal UpperCaseDatabaseAndUserName As Boolean)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _Application = Application

            TextBoxForm_Server.Text = ServerName
            TextBoxForm_Database.Text = DatabaseName
            TextBoxForm_UserName.Text = UserName
            CheckBoxForm_UseWindowsAuthentication.Checked = UseWindowsAuthentication
            _UpperCaseDatabaseAndUserName = UpperCaseDatabaseAndUserName

            SetupValidatorAndHighlighControls()

        End Sub
        Private Sub SetupValidatorAndHighlighControls()

            Me.SuspendLayout()

            _SuperValidator = New DevComponents.DotNetBar.Validator.SuperValidator
            _ErrorProvider = New System.Windows.Forms.ErrorProvider
            _Highlighter = New DevComponents.DotNetBar.Validator.Highlighter

            _SuperValidator.CancelValidatingOnControl = False
            _SuperValidator.ContainerControl = Me
            _SuperValidator.Enabled = True
            _SuperValidator.ErrorProvider = _ErrorProvider
            _SuperValidator.Highlighter = _Highlighter
            _SuperValidator.SteppedValidation = True
            _SuperValidator.ValidationType = DevComponents.DotNetBar.Validator.eValidationType.Manual
            _SuperValidator.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"

            _ErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
            _ErrorProvider.ContainerControl = Me

            _Highlighter.ContainerControl = Me
            _Highlighter.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"

            Me.ResumeLayout(True)

        End Sub
        Protected Sub ClearValidations()

            If _SuperValidator IsNot Nothing Then

                _SuperValidator.ClearFailedValidations()

            End If

        End Sub
        Protected Function Validator() As Boolean

            'objects
            Dim IsValid As Boolean = True

            If _SuperValidator IsNot Nothing Then

                IsValid = _SuperValidator.Validate()

            End If

            Validator = IsValid

        End Function
        Private Sub EnableDisablePasswordLinks()

            Dim ConnectionDatabaseProfile As AdvantageFramework.Database.ConnectionDatabaseProfile = Nothing

            If _Application <> Application.Advantage Then

                LabelForm_ChangePassword.Visible = False
                LabelForm_ResetPassword.Visible = False

            Else

                If String.IsNullOrWhiteSpace(TextBoxForm_Database.Text) = False AndAlso
                        String.IsNullOrWhiteSpace(TextBoxForm_UserName.Text) = False Then

                    If _ConnectionDatabaseProfiles IsNot Nothing AndAlso _ConnectionDatabaseProfiles.Count > 0 Then

                        Try

                            ConnectionDatabaseProfile = _ConnectionDatabaseProfiles.FirstOrDefault(Function(Entity) Entity.DatabaseName = TextBoxForm_Database.Text)

                        Catch ex As Exception
                            ConnectionDatabaseProfile = Nothing
                        End Try

                        If ConnectionDatabaseProfile IsNot Nothing Then

                            LabelForm_ChangePassword.Visible = Not CheckBoxForm_UseWindowsAuthentication.Checked
                            LabelForm_ResetPassword.Visible = Not CheckBoxForm_UseWindowsAuthentication.Checked

                        Else

                            LabelForm_ChangePassword.Visible = False
                            LabelForm_ResetPassword.Visible = False

                        End If

                    Else

                        LabelForm_ChangePassword.Visible = False
                        LabelForm_ResetPassword.Visible = False

                    End If

                Else

                    LabelForm_ChangePassword.Visible = False
                    LabelForm_ResetPassword.Visible = False

                End If

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowFormDialog(ByVal Application As AdvantageFramework.Security.Application, ByRef DbContext As AdvantageFramework.Database.DbContext,
                                         ByRef Session As AdvantageFramework.Security.Session, ByVal ServerName As String, ByVal DatabaseName As String,
                                         ByVal UseWindowsAuthentication As Boolean, ByVal UserName As String, ByVal UpperCaseDatabaseAndUserName As Boolean,
                                         ByRef DialogResult As AdvantageFramework.WinForm.MessageBox.DialogResults)

            DialogResult = ShowFormDialog(Application, DbContext, Session, ServerName, DatabaseName, UseWindowsAuthentication, UserName, UpperCaseDatabaseAndUserName)

        End Sub
        Public Shared Function ShowFormDialog(ByVal Application As AdvantageFramework.Security.Application, ByRef DbContext As AdvantageFramework.Database.DbContext,
                                              ByRef Session As AdvantageFramework.Security.Session, ByVal ServerName As String, ByVal DatabaseName As String,
                                              ByVal UseWindowsAuthentication As Boolean, ByVal UserName As String, ByVal UpperCaseDatabaseAndUserName As Boolean) As System.Windows.Forms.DialogResult

            'objects
            Dim LoginDialog As AdvantageFramework.Security.Presentation.LoginDialog = Nothing

            LoginDialog = New AdvantageFramework.Security.Presentation.LoginDialog(Application, ServerName, DatabaseName, UseWindowsAuthentication, UserName, UpperCaseDatabaseAndUserName)

            ShowFormDialog = LoginDialog.ShowDialog()

            Session = LoginDialog.Session
            DbContext = LoginDialog.DbContext

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub LoginDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            _AdvantageConfigurator = AdvantageFramework.WinForm.AdvantageConfigurator.Load

            _ConnectionDatabaseProfiles = AdvantageFramework.Database.LoadConnectionDatabaseProfileForAdvantage()

        End Sub
        Private Sub LoginDialog_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            Me.Activate()

            _FormShown = True

            If _ConnectionDatabaseProfiles IsNot Nothing AndAlso _ConnectionDatabaseProfiles.Count > 0 Then

                'If AdvantageFramework.Database.LoadSimpleDatabaseProfileList.Any Then

                '    TextBoxForm_Server.Enabled = False
                '    TextBoxForm_Server.UseSystemPasswordChar = True
                '    TextBoxForm_Server.Visible = False
                '    LabelForm_Server.Visible = False

                '    If TextBoxForm_Database.Text <> "" Then

                '        Try

                '            TextBoxForm_Server.Text = AdvantageFramework.Database.LoadSimpleDatabaseProfileList.SingleOrDefault(Function(SimpleDatabaseProfile) SimpleDatabaseProfile.DatabaseName = TextBoxForm_Database.Text).ServerName

                '        Catch ex As Exception
                '            TextBoxForm_Server.Text = ""
                '        End Try

                '    End If

                'End If

                If (_Application = Security.Application.Advantage_Nielsen_Database_Update OrElse
                    _Application = Security.Application.Advantage_Database_Update OrElse
                    _Application = Security.Application.Advantage_Update) Then

                    TextBoxForm_Server.Enabled = True
                    TextBoxForm_Server.UseSystemPasswordChar = False
                    TextBoxForm_Server.Visible = True
                    LabelForm_Server.Visible = True

                    If TextBoxForm_Server.Text = "" Then

                        TextBoxForm_Server.Focus()

                    ElseIf TextBoxForm_Database.Text = "" Then

                        TextBoxForm_Database.Focus()

                    ElseIf TextBoxForm_UserName.Text = "" Then

                        TextBoxForm_UserName.Focus()

                    ElseIf TextBoxForm_Password.Text = "" Then

                        TextBoxForm_Password.Focus()

                    End If

                Else

                    TextBoxForm_Server.Enabled = False
                    TextBoxForm_Server.UseSystemPasswordChar = True
                    TextBoxForm_Server.Visible = False
                    LabelForm_Server.Visible = False

                    If TextBoxForm_Database.Text = "" Then

                        TextBoxForm_Database.Focus()

                    ElseIf TextBoxForm_UserName.Text = "" Then

                        TextBoxForm_UserName.Focus()

                    ElseIf TextBoxForm_Password.Text = "" Then

                        TextBoxForm_Password.Focus()

                    End If

                End If

                EnableDisablePasswordLinks()

                If _AdvantageConfigurator.NTAuthAutoEnable Then

                    CheckBoxForm_UseWindowsAuthentication.Checked = True

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Advantage connections settings are not complete. Please contact software support.")

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            'objects
            Dim ConnectionString As String = ""
            Dim SecurityDbContext As AdvantageFramework.Security.Database.DbContext = Nothing
            Dim Application As AdvantageFramework.Security.Database.Entities.Application = Nothing
            Dim User As AdvantageFramework.Security.Database.Entities.User = Nothing
            Dim UserApplicationAccess As AdvantageFramework.Security.Database.Entities.UserApplicationAccess = Nothing
            Dim LoginSuccessful As Boolean = False
            Dim ErrorMessage As String = ""
            Dim ConnectionDatabaseProfile As AdvantageFramework.Database.ConnectionDatabaseProfile = Nothing
            Dim ValidLogin As Boolean = False
            Dim TwoFactor As AdvantageFramework.Security.Password.TwoFactorAuthentication = Nothing
            Dim AllowSignIn As Boolean = False
            Dim TwoFactorValidated As Boolean = False

            _SuperValidator.ClearFailedValidations()

            _SuperValidator.Highlighter.SetHighlightColor(TextBoxForm_Server, DevComponents.DotNetBar.Validator.eHighlightColor.None)
            _SuperValidator.ErrorProvider.SetError(TextBoxForm_Server, "")

            _SuperValidator.Highlighter.SetHighlightColor(TextBoxForm_Database, DevComponents.DotNetBar.Validator.eHighlightColor.None)
            _SuperValidator.ErrorProvider.SetError(TextBoxForm_Database, "")

            _SuperValidator.Highlighter.SetHighlightColor(TextBoxForm_UserName, DevComponents.DotNetBar.Validator.eHighlightColor.None)
            _SuperValidator.ErrorProvider.SetError(TextBoxForm_UserName, "")

            _SuperValidator.Highlighter.SetHighlightColor(TextBoxForm_AuthenticationCode, DevComponents.DotNetBar.Validator.eHighlightColor.None)
            _SuperValidator.ErrorProvider.SetError(TextBoxForm_AuthenticationCode, "")

            'If Debugger.IsAttached() Then

            '    _ConnectionDatabaseProfiles = AdvantageFramework.Database.LoadConnectionDatabaseProfileForAdvantage(True)

            'End If

            Try

                ConnectionDatabaseProfile = _ConnectionDatabaseProfiles.FirstOrDefault(Function(Entity) Entity.DatabaseName = TextBoxForm_Database.Text)

            Catch ex As Exception
                ConnectionDatabaseProfile = Nothing
            End Try

            If (_Application = Security.Application.Advantage_Nielsen_Database_Update OrElse _Application = Security.Application.Advantage_Database_Update OrElse _Application = Security.Application.Advantage_Update) OrElse
                    ConnectionDatabaseProfile IsNot Nothing Then

                If (_Application = Security.Application.Advantage_Nielsen_Database_Update OrElse
                        _Application = Security.Application.Advantage_Database_Update OrElse
                        _Application = Security.Application.Advantage_Update) Then

                    ValidLogin = AdvantageFramework.Security.Login(_Application, Nothing, _Session, TextBoxForm_Server.Text, TextBoxForm_Database.Text, CheckBoxForm_UseWindowsAuthentication.Checked,
                                                                   TextBoxForm_UserName.Text, TextBoxForm_Password.Text, AdvantageFramework.Security.GetMACAddress, AdvantageFramework.Security.GetIPAddress,
                                                                   "", "",
                                                                   ErrorMessage)

                ElseIf ConnectionDatabaseProfile IsNot Nothing Then

                    ConnectionString = AdvantageFramework.Database.CreateConnectionString(ConnectionDatabaseProfile.ServerName, ConnectionDatabaseProfile.DatabaseName, False, ConnectionDatabaseProfile.UserName, AdvantageFramework.Security.Encryption.Decrypt(ConnectionDatabaseProfile.Password))

                    TwoFactor = New AdvantageFramework.Security.Password.TwoFactorAuthentication(ConnectionString, TextBoxForm_UserName.Text)

                    If TwoFactor.Mode = AdvantageFramework.Security.Password.TwoFactorAuthentication.Type.None Then

                        AllowSignIn = True

                    Else

                        Select Case TwoFactor.Mode

                            Case AdvantageFramework.Security.Password.TwoFactorAuthentication.Type.Email

                                If LabelForm_AccessCodeMessage.Visible = True Then

                                    If String.IsNullOrWhiteSpace(TextBoxForm_AuthenticationCode.Text.Trim) = True Then

                                        ErrorMessage = "Please enter authentication code."

                                    Else

                                        If TwoFactor.HasValidUserCode = True Then

                                            If TwoFactor.Validate(TextBoxForm_AuthenticationCode.Text.Trim) = True Then

                                                AllowSignIn = True
                                                TwoFactorValidated = True

                                            End If

                                        Else

                                            ErrorMessage = "User ID not found."

                                        End If

                                    End If

                                Else

                                    AdvantageFramework.WinForm.Presentation.ShowWaitForm("Sending Email...")

                                    If TwoFactor.SendTwoFactorAuthenticationEmail = True Then

                                        LabelForm_AccessCodeMessage.Text = String.Format("An authentication code was sent to {0}. <br></br>Please enter it below.", TwoFactor.ObfuscatedEmailAddress)

                                        LabelForm_AccessCodeMessage.Visible = True
                                        LabelForm_AuthenticationCode.Visible = True
                                        TextBoxForm_AuthenticationCode.Visible = True

                                        TextBoxForm_AuthenticationCode.TabIndex = 8
                                        CheckBoxForm_UseWindowsAuthentication.TabIndex = 9
                                        ButtonForm_OK.TabIndex = 10
                                        ButtonForm_Cancel.TabIndex = 11

                                        LabelForm_ResendAuthenticationCode.Visible = True

                                        AdvantageFramework.WinForm.Presentation.CloseWaitForm()

                                        Me.Height = "353"

                                        Me.Refresh()

                                        TextBoxForm_AuthenticationCode.Focus()

                                    Else

                                        AdvantageFramework.WinForm.Presentation.CloseWaitForm()

                                    End If

                                End If

                            Case AdvantageFramework.Security.Password.TwoFactorAuthentication.Type.SecurityQuestion

                                AllowSignIn = True

                        End Select

                    End If

                    If AllowSignIn Then

                        ValidLogin = AdvantageFramework.Security.Login(_Application, Nothing, _Session, ConnectionDatabaseProfile.ServerName, TextBoxForm_Database.Text, CheckBoxForm_UseWindowsAuthentication.Checked,
                                                                       TextBoxForm_UserName.Text, TextBoxForm_Password.Text, AdvantageFramework.Security.GetMACAddress, AdvantageFramework.Security.GetIPAddress,
                                                                       ConnectionString, ConnectionDatabaseProfile.UserName, ErrorMessage)

                    End If

                End If

                If ValidLogin Then

                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    Me.Close()

                    'If String.IsNullOrEmpty(ErrorMessage) = False Then

                    '    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                    'End If

                Else

                    If ErrorMessage = "Access denied" OrElse ErrorMessage.Contains("Login failed") Then

                        _SuperValidator.ErrorProvider.SetIconAlignment(TextBoxForm_UserName, Windows.Forms.ErrorIconAlignment.MiddleLeft)

                        _SuperValidator.ErrorProvider.SetError(TextBoxForm_UserName, ErrorMessage)

                        _SuperValidator.Highlighter.SetHighlightColor(TextBoxForm_UserName, DevComponents.DotNetBar.Validator.eHighlightColor.Red)

                    ElseIf ErrorMessage = "User ID not found." Then

                        _SuperValidator.ErrorProvider.SetIconAlignment(TextBoxForm_UserName, Windows.Forms.ErrorIconAlignment.MiddleLeft)

                        _SuperValidator.ErrorProvider.SetError(TextBoxForm_UserName, ErrorMessage)

                        _SuperValidator.Highlighter.SetHighlightColor(TextBoxForm_UserName, DevComponents.DotNetBar.Validator.eHighlightColor.Red)

                    ElseIf ErrorMessage = "Please verify that you are connecting to the correct server and database and that your login username and password is correct." Then

                        _SuperValidator.ErrorProvider.SetIconAlignment(TextBoxForm_Server, Windows.Forms.ErrorIconAlignment.MiddleLeft)
                        _SuperValidator.ErrorProvider.SetIconAlignment(TextBoxForm_Database, Windows.Forms.ErrorIconAlignment.MiddleLeft)

                        _SuperValidator.ErrorProvider.SetError(TextBoxForm_Server, "Please verify that you are connecting to the correct server and database and that your login username and password is correct.")
                        _SuperValidator.ErrorProvider.SetError(TextBoxForm_Database, "Please verify that you are connecting to the correct server and database and that your login username and password is correct.")

                        _SuperValidator.Highlighter.SetHighlightColor(TextBoxForm_Server, DevComponents.DotNetBar.Validator.eHighlightColor.Red)
                        _SuperValidator.Highlighter.SetHighlightColor(TextBoxForm_Database, DevComponents.DotNetBar.Validator.eHighlightColor.Red)

                    ElseIf ErrorMessage = "Please enter authentication code." Then

                        _SuperValidator.ErrorProvider.SetIconAlignment(TextBoxForm_AuthenticationCode, Windows.Forms.ErrorIconAlignment.MiddleLeft)

                        _SuperValidator.ErrorProvider.SetError(TextBoxForm_AuthenticationCode, ErrorMessage)

                        _SuperValidator.Highlighter.SetHighlightColor(TextBoxForm_AuthenticationCode, DevComponents.DotNetBar.Validator.eHighlightColor.Red)

                    ElseIf TwoFactor IsNot Nothing AndAlso String.IsNullOrWhiteSpace(TwoFactor.ErrorMessage) = False Then

                        _SuperValidator.ErrorProvider.SetIconAlignment(TextBoxForm_AuthenticationCode, Windows.Forms.ErrorIconAlignment.MiddleLeft)

                        _SuperValidator.ErrorProvider.SetError(TextBoxForm_AuthenticationCode, TwoFactor.ErrorMessage)

                        _SuperValidator.Highlighter.SetHighlightColor(TextBoxForm_AuthenticationCode, DevComponents.DotNetBar.Validator.eHighlightColor.Red)

                    Else

                        _SuperValidator.ErrorProvider.SetIconAlignment(TextBoxForm_Server, Windows.Forms.ErrorIconAlignment.MiddleLeft)
                        _SuperValidator.ErrorProvider.SetIconAlignment(TextBoxForm_Database, Windows.Forms.ErrorIconAlignment.MiddleLeft)

                        If ErrorMessage.Contains("server") Then

                            _SuperValidator.ErrorProvider.SetError(TextBoxForm_Server, ErrorMessage)
                            _SuperValidator.Highlighter.SetHighlightColor(TextBoxForm_Server, DevComponents.DotNetBar.Validator.eHighlightColor.Red)

                        ElseIf String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                            _SuperValidator.ErrorProvider.SetError(TextBoxForm_Database, ErrorMessage)
                            _SuperValidator.Highlighter.SetHighlightColor(TextBoxForm_Database, DevComponents.DotNetBar.Validator.eHighlightColor.Red)

                        End If

                    End If

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("No advantage connections setup for that server/database. Please contact software support.")

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub CheckBoxForm_UseWindowsAuthentication_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBoxForm_UseWindowsAuthentication.CheckedChanged

            TextBoxForm_UserName.Enabled = Not CheckBoxForm_UseWindowsAuthentication.Checked
            LabelForm_Password.Visible = Not CheckBoxForm_UseWindowsAuthentication.Checked
            TextBoxForm_Password.Visible = Not CheckBoxForm_UseWindowsAuthentication.Checked

            TextBoxForm_UserName.Text = IIf(CheckBoxForm_UseWindowsAuthentication.Checked, My.User.Name, "")
            TextBoxForm_Password.Text = ""

            LabelForm_ChangePassword.Visible = Not CheckBoxForm_UseWindowsAuthentication.Checked
            LabelForm_ResetPassword.Visible = Not CheckBoxForm_UseWindowsAuthentication.Checked

        End Sub
        Private Sub TextBoxForm_UserName_TextChanged(sender As Object, e As System.EventArgs) Handles TextBoxForm_UserName.TextChanged

            'objects
            Dim SelectionStart As Integer = 0
            Dim SelectionLength As Integer = 0

            If _UpperCaseDatabaseAndUserName Then

                SelectionStart = TextBoxForm_UserName.SelectionStart
                SelectionLength = TextBoxForm_UserName.SelectionLength

                TextBoxForm_UserName.Text = TextBoxForm_UserName.Text.ToUpper

                TextBoxForm_UserName.SelectionStart = SelectionStart
                TextBoxForm_UserName.SelectionLength = SelectionLength

            End If

            If _FormShown Then

                EnableDisablePasswordLinks()

            End If

        End Sub
        Private Sub TextBoxForm_Database_TextChanged(sender As Object, e As System.EventArgs) Handles TextBoxForm_Database.TextChanged

            'objects
            Dim SelectionStart As Integer = 0
            Dim SelectionLength As Integer = 0

            If _UpperCaseDatabaseAndUserName Then

                SelectionStart = TextBoxForm_Database.SelectionStart
                SelectionLength = TextBoxForm_Database.SelectionLength

                TextBoxForm_Database.Text = TextBoxForm_Database.Text.ToUpper

                TextBoxForm_Database.SelectionStart = SelectionStart
                TextBoxForm_Database.SelectionLength = SelectionLength

            End If

            If _FormShown Then

                EnableDisablePasswordLinks()

            End If

        End Sub
        Private Sub TextBoxForm_Server_TextChanged(sender As Object, e As EventArgs) Handles TextBoxForm_Server.TextChanged

            If _FormShown Then

                EnableDisablePasswordLinks()

            End If

        End Sub
        Private Sub LabelForm_ChangePassword_MarkupLinkClick(sender As Object, e As DevComponents.DotNetBar.MarkupLinkClickEventArgs) Handles LabelForm_ChangePassword.MarkupLinkClick

            Dim ConnectionDatabaseProfile As AdvantageFramework.Database.ConnectionDatabaseProfile = Nothing
            Dim User As AdvantageFramework.Security.Classes.User = Nothing
            Dim ErrorMessage As String = String.Empty

            If String.IsNullOrWhiteSpace(TextBoxForm_Database.Text) = False AndAlso
                    String.IsNullOrWhiteSpace(TextBoxForm_UserName.Text) = False Then

                If _ConnectionDatabaseProfiles IsNot Nothing AndAlso _ConnectionDatabaseProfiles.Count > 0 Then

                    Try

                        ConnectionDatabaseProfile = _ConnectionDatabaseProfiles.FirstOrDefault(Function(Entity) Entity.DatabaseName = TextBoxForm_Database.Text)

                    Catch ex As Exception
                        ConnectionDatabaseProfile = Nothing
                    End Try

                    If ConnectionDatabaseProfile IsNot Nothing Then

                        If AdvantageFramework.Security.ValidateLoginConnectionString(Application.Advantage,
                                                                                     ConnectionDatabaseProfile.GetConnectionString(Application.Advantage),
                                                                                     ErrorMessage) = True Then

                            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(ConnectionDatabaseProfile.GetConnectionString(Application.Advantage), ConnectionDatabaseProfile.UserName)

                                User = New AdvantageFramework.Security.Classes.User(AdvantageFramework.Security.Database.Procedures.User.LoadByUserCode(SecurityDbContext, TextBoxForm_UserName.Text))

                                If User IsNot Nothing AndAlso String.IsNullOrWhiteSpace(User.SID) Then

                                    If AdvantageFramework.Security.UserHasGroupMembership(SecurityDbContext, User.ID, User.CheckForUserAccess) = True Then

                                        If AdvantageFramework.Database.Presentation.ChangePasswordDialog.ShowFormDialog(ConnectionDatabaseProfile.GetConnectionString(Application.Advantage), TextBoxForm_UserName.Text, TextBoxForm_Password.Text) = Windows.Forms.DialogResult.OK Then

                                            TextBoxForm_Password.Text = String.Empty
                                            TextBoxForm_Password.Focus()

                                        End If

                                    Else

                                        AdvantageFramework.WinForm.MessageBox.Show(AdvantageFramework.Security.Password.NoGroupMembershipMessage)

                                    End If

                                Else

                                    AdvantageFramework.WinForm.MessageBox.Show("Invalid user.")

                                End If

                            End Using

                        Else

                            If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                                ErrorMessage = AdvantageFramework.StringUtilities.CheckForEndingPunctuation(ErrorMessage)
                                AdvantageFramework.WinForm.MessageBox.Show("Invalid connection.")

                            Else

                                ErrorMessage = AdvantageFramework.StringUtilities.CheckForEndingPunctuation(ErrorMessage)
                                AdvantageFramework.WinForm.MessageBox.Show("Invalid connection.  " & ErrorMessage)

                            End If

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub LabelForm_ResetPassword_MarkupLinkClick(sender As Object, e As DevComponents.DotNetBar.MarkupLinkClickEventArgs) Handles LabelForm_ResetPassword.MarkupLinkClick

            Dim DatabaseProfile As AdvantageFramework.Database.DatabaseProfile = Nothing
            Dim ConnectionDatabaseProfile As AdvantageFramework.Database.ConnectionDatabaseProfile = Nothing
            Dim ErrorMessage As String = String.Empty
            Dim HasPassword As Boolean = False
            Dim User As AdvantageFramework.Security.Classes.User = Nothing

            If String.IsNullOrWhiteSpace(TextBoxForm_Database.Text) = False AndAlso
                    String.IsNullOrWhiteSpace(TextBoxForm_UserName.Text) = False Then

                If _ConnectionDatabaseProfiles IsNot Nothing AndAlso _ConnectionDatabaseProfiles.Count > 0 Then

                    Try

                        ConnectionDatabaseProfile = _ConnectionDatabaseProfiles.FirstOrDefault(Function(Entity) Entity.DatabaseName = TextBoxForm_Database.Text)

                    Catch ex As Exception
                        ConnectionDatabaseProfile = Nothing
                    End Try

                    If ConnectionDatabaseProfile IsNot Nothing Then

                        If AdvantageFramework.Security.ValidateLoginConnectionString(Application.Advantage,
                                                                                     ConnectionDatabaseProfile.GetConnectionString(Application.Advantage),
                                                                                     ErrorMessage) = True Then

                            DatabaseProfile = New AdvantageFramework.Database.DatabaseProfile

                            DatabaseProfile.DatabaseServer = ConnectionDatabaseProfile.ServerName
                            DatabaseProfile.DatabaseName = ConnectionDatabaseProfile.DatabaseName
                            DatabaseProfile.DatabaseUserName = TextBoxForm_UserName.Text
                            DatabaseProfile.DatabasePassword = TextBoxForm_Password.Text

                            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(ConnectionDatabaseProfile.GetConnectionString(Application.Advantage),
                                                                                                         ConnectionDatabaseProfile.UserName)

                                User = New AdvantageFramework.Security.Classes.User(AdvantageFramework.Security.Database.Procedures.User.LoadByUserCode(SecurityDbContext, DatabaseProfile.DatabaseUserName))

                                If User IsNot Nothing AndAlso String.IsNullOrWhiteSpace(User.SID) Then

                                    Using DbContext = New AdvantageFramework.Database.DbContext(ConnectionDatabaseProfile.GetConnectionString(Application.Advantage), DatabaseProfile.DatabaseUserName)

                                        If AdvantageFramework.Security.UserHasGroupMembership(SecurityDbContext, User.ID, User.CheckForUserAccess) = True Then

                                            If AdvantageFramework.Security.Password.SendPasswordChangeEmail(DbContext, SecurityDbContext, DatabaseProfile.DatabaseServer,
                                                                                                            DatabaseProfile.DatabaseName, DatabaseProfile.DatabaseUserName,
                                                                                                            HasPassword, ErrorMessage) = True Then

                                                If HasPassword = False Then

                                                    AdvantageFramework.WinForm.MessageBox.Show(AdvantageFramework.Security.Password.NewPasswordMessage &
                                                                                               "Check your email for further instructions.")

                                                Else

                                                    AdvantageFramework.WinForm.MessageBox.Show("Check your email for further instructions.")

                                                End If

                                            Else

                                                If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                                                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                                                Else

                                                    AdvantageFramework.WinForm.MessageBox.Show("Something went wrong!")

                                                End If

                                            End If

                                        Else

                                            AdvantageFramework.WinForm.MessageBox.Show(AdvantageFramework.Security.Password.NoGroupMembershipMessage)

                                        End If

                                    End Using

                                Else

                                    AdvantageFramework.WinForm.MessageBox.Show("Invalid user.")

                                End If

                            End Using

                        Else

                            If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                                ErrorMessage = AdvantageFramework.StringUtilities.CheckForEndingPunctuation(ErrorMessage)
                                AdvantageFramework.WinForm.MessageBox.Show("Invalid connection.")

                            Else

                                ErrorMessage = AdvantageFramework.StringUtilities.CheckForEndingPunctuation(ErrorMessage)
                                AdvantageFramework.WinForm.MessageBox.Show("Invalid connection.  " & ErrorMessage)

                            End If

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub LabelForm_ResendAuthenticationCode_MarkupLinkClick(sender As Object, e As DevComponents.DotNetBar.MarkupLinkClickEventArgs) Handles LabelForm_ResendAuthenticationCode.MarkupLinkClick

            Dim DatabaseProfile As AdvantageFramework.Database.DatabaseProfile = Nothing
            Dim ConnectionDatabaseProfile As AdvantageFramework.Database.ConnectionDatabaseProfile = Nothing
            Dim TwoFactor As AdvantageFramework.Security.Password.TwoFactorAuthentication = Nothing
            Dim ConnectionString As String = String.Empty
            Dim ErrorMessage As String = String.Empty
            Dim HasPassword As Boolean = False
            Dim User As AdvantageFramework.Security.Classes.User = Nothing

            If String.IsNullOrWhiteSpace(TextBoxForm_Database.Text) = False AndAlso
                    String.IsNullOrWhiteSpace(TextBoxForm_UserName.Text) = False Then

                If _ConnectionDatabaseProfiles IsNot Nothing AndAlso _ConnectionDatabaseProfiles.Count > 0 Then

                    Try

                        ConnectionDatabaseProfile = _ConnectionDatabaseProfiles.FirstOrDefault(Function(Entity) Entity.DatabaseName = TextBoxForm_Database.Text)

                    Catch ex As Exception
                        ConnectionDatabaseProfile = Nothing
                    End Try

                    If ConnectionDatabaseProfile IsNot Nothing Then

                        ConnectionString = AdvantageFramework.Database.CreateConnectionString(ConnectionDatabaseProfile.ServerName, ConnectionDatabaseProfile.DatabaseName, False, ConnectionDatabaseProfile.UserName, ConnectionDatabaseProfile.GetDecryptPassword())

                        TwoFactor = New AdvantageFramework.Security.Password.TwoFactorAuthentication(ConnectionString, TextBoxForm_UserName.Text)

                        If TwoFactor.SendTwoFactorAuthenticationEmail() Then

                            AdvantageFramework.WinForm.MessageBox.Show("New Authentication code has been sent.")

                        Else

                            AdvantageFramework.WinForm.MessageBox.Show("Failed sending new Authentication code.  Please contact software support.")

                        End If

                        TextBoxForm_AuthenticationCode.Focus()

                    End If

                End If

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
