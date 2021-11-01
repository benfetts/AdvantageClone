Namespace Database.Presentation

    Public Class DatabaseProfileDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _DatabaseProfile As AdvantageFramework.Database.DatabaseProfile = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property DatabaseProfile As AdvantageFramework.Database.DatabaseProfile
            Get
                DatabaseProfile = _DatabaseProfile
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByRef DatabaseProfile As AdvantageFramework.Database.DatabaseProfile)

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _DatabaseProfile = DatabaseProfile

        End Sub
        Private Sub RefreshEmailSettings()

            'objects
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim DatabaseProfile As AdvantageFramework.Database.DatabaseProfile = Nothing
            Dim ClearEmailSettings As Boolean = False

            DatabaseProfile = New AdvantageFramework.Database.DatabaseProfile()

            DatabaseProfile.DatabaseServer = TextBoxForm_Server.Text
            DatabaseProfile.DatabaseName = TextBoxForm_Database.Text
            DatabaseProfile.DatabaseUserName = TextBoxForm_UserName.Text
            DatabaseProfile.DatabasePassword = TextBoxForm_Password.Text

            If AdvantageFramework.Database.TestConnectionString(DatabaseProfile.ConnectionString) Then

                Using DbContext = New AdvantageFramework.Database.DbContext(DatabaseProfile.ConnectionString, "SYSTEM")

                    Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                    If Agency IsNot Nothing Then

                        TextBoxEmailSettings_EmailServer.Text = Agency.POP3Server
                        TextBoxEmailSettings_UserName.Text = Agency.POP3UserName

                        If String.IsNullOrWhiteSpace(Agency.POP3Password) = False Then

                            TextBoxEmailSettings_Password.Text = AdvantageFramework.Security.Encryption.Decrypt(Agency.POP3Password)

                        Else

                            TextBoxEmailSettings_Password.Text = Agency.POP3Password

                        End If

                        If Agency.POP3PortNumber Is Nothing Then

                            TextBoxEmailSettings_Port.Text = ""

                        Else

                            TextBoxEmailSettings_Port.Text = Agency.POP3PortNumber

                        End If

                        If Agency.POP3DeleteMessages.GetValueOrDefault(0) = 1 Then

                            CheckBoxEmailSettings_DeleteMessages.Checked = True

                        Else

                            CheckBoxEmailSettings_DeleteMessages.Checked = False

                        End If

                    Else

                        ClearEmailSettings = True

                    End If

                End Using

            Else

                ClearEmailSettings = True

            End If

            If ClearEmailSettings Then

                TextBoxEmailSettings_EmailServer.Text = ""
                TextBoxEmailSettings_UserName.Text = ""
                TextBoxEmailSettings_Password.Text = ""
                TextBoxEmailSettings_Port.Text = ""
                CheckBoxEmailSettings_DeleteMessages.Checked = False

            End If

        End Sub
        Private Sub EnableOrDisableActions()

            If String.IsNullOrEmpty(TextBoxForm_Server.Text) = False AndAlso
                    String.IsNullOrEmpty(TextBoxForm_Database.Text) = False AndAlso
                    String.IsNullOrEmpty(TextBoxForm_UserName.Text) = False AndAlso
                    String.IsNullOrEmpty(TextBoxForm_Password.Text) = False Then

                ButtonForm_TestAdmin.Enabled = True
                ButtonForm_RefreshEmailSettings.Enabled = True

            Else

                ButtonForm_TestAdmin.Enabled = False
                ButtonForm_RefreshEmailSettings.Enabled = False

            End If

            If String.IsNullOrEmpty(TextBoxForm_Server.Text) = False AndAlso
                    String.IsNullOrEmpty(TextBoxForm_Database.Text) = False AndAlso
                    String.IsNullOrEmpty(TextBoxForm_CPUserName.Text) = False AndAlso
                    String.IsNullOrEmpty(TextBoxForm_CPPassword.Text) = False Then

                ButtonForm_TestCP.Enabled = True

            Else

                ButtonForm_TestCP.Enabled = False

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef DatabaseProfile As AdvantageFramework.Database.DatabaseProfile) As System.Windows.Forms.DialogResult

            'objects
            Dim DatabaseProfileDialog As AdvantageFramework.Database.Presentation.DatabaseProfileDialog = Nothing

            DatabaseProfileDialog = New AdvantageFramework.Database.Presentation.DatabaseProfileDialog(DatabaseProfile)

            ShowFormDialog = DatabaseProfileDialog.ShowDialog()

            DatabaseProfile = DatabaseProfileDialog.DatabaseProfile

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub DatabaseProfileDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            TextBoxForm_Server.SetDefaultPropertySettings(DisplayName:="Server", IsRequired:=True)
            TextBoxForm_Database.SetDefaultPropertySettings(DisplayName:="Database", IsRequired:=True)
            TextBoxForm_CPUserName.SetDefaultPropertySettings(DisplayName:="UserName")
            TextBoxForm_CPPassword.SetDefaultPropertySettings(DisplayName:="Password")

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            Try

                If _DatabaseProfile IsNot Nothing Then

                    Me.Text = "Edit Database Profile"
                    ButtonForm_Update.Visible = True
                    ButtonForm_Add.Visible = False

                    TextBoxForm_Server.Text = _DatabaseProfile.DatabaseServer
                    TextBoxForm_Database.Text = _DatabaseProfile.DatabaseName
                    TextBoxForm_UserName.Text = _DatabaseProfile.DatabaseUserName
                    TextBoxForm_Password.Text = _DatabaseProfile.DatabasePassword
                    TextBoxForm_CPUserName.Text = _DatabaseProfile.CPDatabaseUserName
                    TextBoxForm_CPPassword.Text = _DatabaseProfile.CPDatabasePassword

                    If String.IsNullOrEmpty(TextBoxForm_Server.Text) = False AndAlso
                            String.IsNullOrEmpty(TextBoxForm_Database.Text) = False AndAlso
                            String.IsNullOrEmpty(TextBoxForm_UserName.Text) = False AndAlso
                            String.IsNullOrEmpty(TextBoxForm_Password.Text) = False Then

                        RefreshEmailSettings()

                    End If

                Else

                    Me.Text = "Add Database Profile"
                    ButtonForm_Update.Visible = False
                    ButtonForm_Add.Visible = True

                End If

            Catch ex As Exception

            End Try

            Me.FormAction = WinForm.Presentation.FormActions.None

            EnableOrDisableActions()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_TestAdmin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_TestAdmin.Click
            
            'objects
            Dim DatabaseProfile As AdvantageFramework.Database.DatabaseProfile = Nothing
            Dim ErrorMessage As String = ""

            DatabaseProfile = New AdvantageFramework.Database.DatabaseProfile()

            DatabaseProfile.DatabaseServer = TextBoxForm_Server.Text
            DatabaseProfile.DatabaseName = TextBoxForm_Database.Text
            DatabaseProfile.DatabaseUserName = TextBoxForm_UserName.Text
            DatabaseProfile.DatabasePassword = TextBoxForm_Password.Text

            If AdvantageFramework.Database.TestConnectionString(DatabaseProfile.ConnectionString, ErrorMessage) Then

                AdvantageFramework.Navigation.ShowMessageBox("Test Successful!")

            Else

                AdvantageFramework.Navigation.ShowMessageBox("Test Failed." & vbNewLine & vbNewLine & ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_TestCP_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_TestCP.Click

            'objects
            Dim DatabaseProfile As AdvantageFramework.Database.DatabaseProfile = Nothing
            Dim ErrorMessage As String = ""

            DatabaseProfile = New AdvantageFramework.Database.DatabaseProfile()

            DatabaseProfile.DatabaseServer = TextBoxForm_Server.Text
            DatabaseProfile.DatabaseName = TextBoxForm_Database.Text
            DatabaseProfile.CPDatabaseUserName = TextBoxForm_CPUserName.Text
            DatabaseProfile.CPDatabasePassword = TextBoxForm_CPPassword.Text

            If AdvantageFramework.Database.TestConnectionString(DatabaseProfile.CPConnectionString, ErrorMessage) Then

                AdvantageFramework.Navigation.ShowMessageBox("Test Successful!")

            Else

                AdvantageFramework.Navigation.ShowMessageBox("Test Failed." & vbNewLine & vbNewLine & ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_Update_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Update.Click

            'objects
            Dim DatabaseProfile As AdvantageFramework.Database.DatabaseProfile = Nothing
            Dim ErrorMessage As String = ""

            If Me.Validator Then

                DatabaseProfile = New AdvantageFramework.Database.DatabaseProfile()

                DatabaseProfile.DatabaseServer = TextBoxForm_Server.Text
                DatabaseProfile.DatabaseName = TextBoxForm_Database.Text
                DatabaseProfile.DatabaseUserName = TextBoxForm_UserName.Text
                DatabaseProfile.DatabasePassword = TextBoxForm_Password.Text
                DatabaseProfile.CPDatabaseUserName = TextBoxForm_CPUserName.Text
                DatabaseProfile.CPDatabasePassword = TextBoxForm_CPPassword.Text

                DatabaseProfile.DatabaseServer = DatabaseProfile.DatabaseServer.Replace("\", "#")

                If AdvantageFramework.Database.SaveDatabaseProfile(DatabaseProfile, True) Then

                    _DatabaseProfile = DatabaseProfile

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()

                End If

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Add.Click

            'objects
            Dim DatabaseProfile As AdvantageFramework.Database.DatabaseProfile = Nothing
            Dim ErrorMessage As String = ""

            If Me.Validator Then

                DatabaseProfile = New AdvantageFramework.Database.DatabaseProfile()

                DatabaseProfile.DatabaseServer = TextBoxForm_Server.Text
                DatabaseProfile.DatabaseName = TextBoxForm_Database.Text
                DatabaseProfile.DatabaseUserName = TextBoxForm_UserName.Text
                DatabaseProfile.DatabasePassword = TextBoxForm_Password.Text
                DatabaseProfile.CPDatabaseUserName = TextBoxForm_CPUserName.Text
                DatabaseProfile.CPDatabasePassword = TextBoxForm_CPPassword.Text

                DatabaseProfile.DatabaseServer = DatabaseProfile.DatabaseServer.Replace("\", "#")

                If AdvantageFramework.Database.SaveDatabaseProfile(DatabaseProfile, False) Then

                    _DatabaseProfile = DatabaseProfile

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()

                End If

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ButtonForm_RefreshEmailSettings_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_RefreshEmailSettings.Click

            RefreshEmailSettings()

        End Sub
        Private Sub TextBoxForm_Server_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxForm_Server.TextChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                EnableOrDisableActions()

            End If
            
        End Sub
        Private Sub TextBoxForm_Database_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxForm_Database.TextChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub TextBoxForm_UserName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxForm_UserName.TextChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub TextBoxForm_Password_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxForm_Password.TextChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub TextBoxForm_CPUserName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxForm_CPUserName.TextChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub TextBoxForm_CPPassword_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxForm_CPPassword.TextChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                EnableOrDisableActions()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace