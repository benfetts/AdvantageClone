Namespace Security.Setup.Presentation

    Public Class ClientPortalUserChangePasswordDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _ClientPortalUserID As System.Guid = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByVal ClientPortalUserID As System.Guid)

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _ClientPortalUserID = ClientPortalUserID

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal ClientPortalUserID As System.Guid) As System.Windows.Forms.DialogResult

            'objects
            Dim ClientPortalUserChangePasswordDialog As AdvantageFramework.Security.Setup.Presentation.ClientPortalUserChangePasswordDialog = Nothing

            ClientPortalUserChangePasswordDialog = New AdvantageFramework.Security.Setup.Presentation.ClientPortalUserChangePasswordDialog(ClientPortalUserID)

            ShowFormDialog = ClientPortalUserChangePasswordDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub ChangePasswordDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim ClientPortalUser As AdvantageFramework.Security.Database.Entities.ClientPortalUser = Nothing

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ClientPortalUser = AdvantageFramework.Security.Database.Procedures.ClientPortalUser.LoadByClientPortalUserID(SecurityDbContext, _ClientPortalUserID)

                If ClientPortalUser IsNot Nothing Then

                    TextBoxForm_OldPassword.Text = ClientPortalUser.Password

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("The client portal user does not exist.")

                    Me.DialogResult = Windows.Forms.DialogResult.Cancel
                    Me.Close()

                End If

            End Using

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Save_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Save.Click

            'objects
            Dim ClientPortalUser As AdvantageFramework.Security.Database.Entities.ClientPortalUser = Nothing

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ClientPortalUser = AdvantageFramework.Security.Database.Procedures.ClientPortalUser.LoadByClientPortalUserID(SecurityDbContext, _ClientPortalUserID)

                If ClientPortalUser IsNot Nothing Then

                    If TextBoxForm_Password.Text = TextBoxForm_ConfirmPassword.Text Then
                        '*Password must be at least 8 characters long, has to contain letters and numbers, and one uppercase letter. 
                        If TextBoxForm_Password.Text.Length >= 8 Then

                            If AdvantageFramework.StringUtilities.RemoveAllNonNumeric(TextBoxForm_Password.Text) <> "" Then

                                If AdvantageFramework.StringUtilities.IsRegularExpressionAMatch("^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,20}$", TextBoxForm_Password.Text) Then

                                    ClientPortalUser.Password = AdvantageFramework.Security.Encryption.GenerateSHA256ManagedHash(TextBoxForm_Password.Text)

                                    If AdvantageFramework.Security.Database.Procedures.ClientPortalUser.Update(SecurityDbContext, ClientPortalUser) Then

                                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                                        Me.Close()

                                    Else

                                        AdvantageFramework.WinForm.MessageBox.Show("Failed to update client portal user password.")

                                    End If

                                Else

                                    AdvantageFramework.WinForm.MessageBox.Show("Password must contain one uppercase letter. Please retype your passwords and try again.")

                                    TextBoxForm_Password.Text = ""
                                    TextBoxForm_ConfirmPassword.Text = ""

                                End If

                            Else

                                AdvantageFramework.WinForm.MessageBox.Show("Password must contain one number. Please retype your passwords and try again.")

                                TextBoxForm_Password.Text = ""
                                TextBoxForm_ConfirmPassword.Text = ""

                            End If

                        Else

                            AdvantageFramework.WinForm.MessageBox.Show("Password is not greater than or equal to minimum length of 8. Please retype your passwords and try again.")

                            TextBoxForm_Password.Text = ""
                            TextBoxForm_ConfirmPassword.Text = ""

                        End If

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show("Passwords do not match. Please retype your passwords and try again.")

                        TextBoxForm_Password.Text = ""
                        TextBoxForm_ConfirmPassword.Text = ""

                    End If

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("The client portal user does not exist.")

                    Me.DialogResult = Windows.Forms.DialogResult.Cancel
                    Me.Close()

                End If

            End Using

        End Sub
        Private Sub ButtonForm_Cancel_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()

        End Sub

#End Region

#End Region

    End Class

End Namespace