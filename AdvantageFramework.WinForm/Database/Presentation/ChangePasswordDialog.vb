Namespace Database.Presentation

    Public Class ChangePasswordDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _ConnectionString As String = String.Empty
        Private _UserName As String = ""
        Private _Password As String = ""
        Private _IgnoreBlankPasswordRequirement As Boolean = False
        Private _HideOldPassword As Boolean = False

#End Region

#Region " Properties "

        Private ReadOnly Property Password As String
            Get
                Password = _Password
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ConnectionString As String, UserName As String, Password As String, IgnoreBlankPasswordRequirement As Boolean, HideOldPassword As Boolean)

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _ConnectionString = ConnectionString
            _UserName = UserName
            _Password = Password
            _IgnoreBlankPasswordRequirement = IgnoreBlankPasswordRequirement
            _HideOldPassword = HideOldPassword

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowFormDialog(ConnectionString As String, UserName As String, ByRef Password As String, ByRef DialogResult As AdvantageFramework.WinForm.MessageBox.DialogResults)

            DialogResult = ShowFormDialog(ConnectionString, UserName, Password)

        End Sub
        Public Shared Function ShowFormDialog(ConnectionString As String, UserName As String, ByRef Password As String, Optional IgnoreBlankPasswordRequirement As Boolean = False, Optional HideOldPassword As Boolean = False) As System.Windows.Forms.DialogResult

            'objects
            Dim ChangePasswordDialog As AdvantageFramework.Database.Presentation.ChangePasswordDialog = Nothing

            ChangePasswordDialog = New AdvantageFramework.Database.Presentation.ChangePasswordDialog(ConnectionString, UserName, Password, IgnoreBlankPasswordRequirement, HideOldPassword)

            ShowFormDialog = ChangePasswordDialog.ShowDialog()

            Password = ChangePasswordDialog.Password

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub ChangePasswordDialog_Load(sender As Object, e As System.EventArgs) Handles Me.Load

            TextBoxForm_OldPassword.Text = _Password

            TextBoxForm_OldPassword.Visible = Not _HideOldPassword
            LabelForm_OldPassword.Visible = Not _HideOldPassword

            If _HideOldPassword Then

                LabelForm_NewPassword.Location = New System.Drawing.Point(LabelForm_NewPassword.Location.X, LabelForm_NewPassword.Location.Y - 20)
                TextBoxForm_NewPassword.Location = New System.Drawing.Point(TextBoxForm_NewPassword.Location.X, TextBoxForm_NewPassword.Location.Y - 20)

                LabelForm_ConfirmNewPassword.Location = New System.Drawing.Point(LabelForm_ConfirmNewPassword.Location.X, LabelForm_ConfirmNewPassword.Location.Y - 20)
                TextBoxForm_ConfirmNewPassword.Location = New System.Drawing.Point(TextBoxForm_ConfirmNewPassword.Location.X, TextBoxForm_ConfirmNewPassword.Location.Y - 20)

            End If

        End Sub
        Private Sub ChangePasswordDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            If _IgnoreBlankPasswordRequirement Then

                TextBoxForm_NewPassword.Focus()

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_OK.Click

            'objects
            Dim PasswordChanged As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim User As AdvantageFramework.Security.Database.Entities.User = Nothing
            Dim Messages As Generic.List(Of String) = Nothing
            Dim PasswordController As AdvantageFramework.Controller.Account.PasswordController = Nothing
            Dim OldPasswordOk As Boolean = False

            If TextBoxForm_NewPassword.Text = TextBoxForm_ConfirmNewPassword.Text Then

                Try

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_ConnectionString, _UserName)

                        Using DbContext = New AdvantageFramework.Database.DbContext(_ConnectionString, _UserName)

                            'System.Data.SqlClient.SqlConnection.ChangePassword(AdvantageFramework.Database.CreateConnectionString(_ServerName, _DatabaseName, False, _UserName, _Password), TextBoxForm_NewPassword.Text)
                            User = AdvantageFramework.Security.Database.Procedures.User.LoadByUserCode(SecurityDbContext, _UserName)

                            If User IsNot Nothing Then

                                If User.IsInactive = False Then

                                    If _IgnoreBlankPasswordRequirement OrElse String.IsNullOrWhiteSpace(User.Password) = False Then

                                        If _HideOldPassword Then

                                            OldPasswordOk = True

                                        Else

                                            OldPasswordOk = (User.Password = AdvantageFramework.Security.Encryption.EncryptPassword(TextBoxForm_OldPassword.Text.Trim))

                                        End If

                                        If OldPasswordOk Then

                                            PasswordController = New AdvantageFramework.Controller.Account.PasswordController(Nothing)

                                            If PasswordController.Validate(SecurityDbContext, User.UserCode, TextBoxForm_NewPassword.Text, Messages) = True Then

                                                User.Password = AdvantageFramework.Security.Encryption.EncryptPassword(TextBoxForm_NewPassword.Text.Trim)

                                                PasswordChanged = AdvantageFramework.Security.Database.Procedures.User.Update(SecurityDbContext, User)

                                                If PasswordChanged = True Then

                                                    AdvantageFramework.Security.Password.InsertNewPasswordHistory(SecurityDbContext, User)

                                                End If

                                            Else

                                                If Messages IsNot Nothing AndAlso Messages.Count > 0 Then

                                                    For Each Message As String In Messages

                                                        If String.IsNullOrWhiteSpace(ErrorMessage) Then

                                                            ErrorMessage = Message

                                                        Else

                                                            ErrorMessage &= System.Environment.NewLine & Message

                                                        End If

                                                    Next

                                                End If

                                            End If

                                        Else

                                            ErrorMessage = AdvantageFramework.Security.Password.IncorrectOldPasswordMessage

                                        End If

                                    Else

                                        ErrorMessage = AdvantageFramework.Security.Password.NoChangeForNewUserMessage

                                    End If

                                Else

                                    ErrorMessage = AdvantageFramework.Security.Password.InactiveUserMessage

                                End If

                            End If

                        End Using

                    End Using

                Catch ex As Exception
                    PasswordChanged = False
                    ErrorMessage = ex.Message
                End Try

                If PasswordChanged Then

                    _Password = TextBoxForm_NewPassword.Text

                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    Me.Close()

                Else

                    If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                        ErrorMessage = AdvantageFramework.StringUtilities.CheckForEndingPunctuation(ErrorMessage)
                        AdvantageFramework.Navigation.ShowMessageBox(ErrorMessage)

                    End If

                End If

            Else

                AdvantageFramework.Navigation.ShowMessageBox("The new passwords do not match.")

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub

#End Region

#End Region

    End Class

End Namespace