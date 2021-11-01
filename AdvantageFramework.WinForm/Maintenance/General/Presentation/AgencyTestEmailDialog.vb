Namespace Maintenance.General.Presentation

    Public Class AgencyTestEmailDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Agency As AdvantageFramework.Database.Entities.Agency = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(Agency As AdvantageFramework.Database.Entities.Agency)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _Agency = Agency

        End Sub
        Private Function SendEmail(MailBeeLicenseKey As String, SMTPAuthenticationMethodType As Integer, SMTPServer As String,
                                   SMTPPortNumber As Integer, UserName As String, Password As String, From As String,
                                   ReplyTo As String, [To] As String, Subject As String,
                                   IsHTML As Boolean, Body As String, Priority As Integer,
                                   SMTPSecureType As Integer, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim EmailSent As Boolean = False
            Dim SMTP As MailBee.SmtpMail.Smtp = Nothing

            Try

                SMTP = AdvantageFramework.Email.CreateMailBeeSMTP(MailBeeLicenseKey, SMTPAuthenticationMethodType, SMTPServer, SMTPPortNumber, UserName, Password, SMTPSecureType)

                If SMTP.Connect Then

                    SMTP.Message.From.AsString = From
                    SMTP.Message.ReplyTo.AsString = ReplyTo

                    SMTP.Message.To.AsString = [To]

                    SMTP.Message.Subject = Subject

                    If IsHTML Then

                        SMTP.Message.BodyHtmlText = Body

                    Else

                        SMTP.Message.BodyPlainText = Body

                    End If

                    Try

                        SMTP.Send()

                        EmailSent = True

                    Catch ex As MailBee.SmtpMail.MailBeeSmtpNegativeResponseException

                        ErrorMessage = "Exception message: " & ex.Message & System.Environment.NewLine & System.Environment.NewLine

                        ErrorMessage &= "MailBee.NET error code: " & ex.ErrorCode.ToString & System.Environment.NewLine & System.Environment.NewLine

                        ErrorMessage &= "SMTP response code: " & ex.ResponseCode.ToString & System.Environment.NewLine & System.Environment.NewLine

                        ErrorMessage &= "SMTP reply: " & ex.ResponseString

                    Catch ex As MailBee.MailBeeException

                        ErrorMessage = "Exception message: " & ex.Message & System.Environment.NewLine & System.Environment.NewLine

                        ErrorMessage &= "MailBee.NET error code: " & ex.ErrorCode.ToString

                    Catch ex As Exception

                        ErrorMessage = "Exception message: " & ex.Message

                    End Try

                Else

                    ErrorMessage = "Failed to connect to SMTP server."

                End If

            Catch ex As Exception

                ErrorMessage = "Exception message: " & ex.Message

                EmailSent = False

            End Try

            Try

                If SMTP IsNot Nothing Then

                    Try

                        SMTP.Disconnect()

                    Catch ex As Exception

                    End Try

                    SMTP.Dispose()
                    SMTP = Nothing

                End If

            Catch ex As Exception

            End Try

            SendEmail = EmailSent

        End Function

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(Agency As AdvantageFramework.Database.Entities.Agency) As System.Windows.Forms.DialogResult

            'objects
            Dim AgencyTestEmailDialog As AdvantageFramework.Maintenance.General.Presentation.AgencyTestEmailDialog = Nothing

            AgencyTestEmailDialog = New AdvantageFramework.Maintenance.General.Presentation.AgencyTestEmailDialog(Agency)

            ShowFormDialog = AgencyTestEmailDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub AgencyTestEmailDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.ByPassUserEntryChanged = True
            Me.ShowUnsavedChangesOnFormClosing = False

            TextBoxForm_Email.SetRequired(True)

            CheckBoxForm_UseCurrent.Checked = True

            If _Agency IsNot Nothing AndAlso _Agency.IsASP.GetValueOrDefault(0) = 1 Then

                CheckBoxForm_UseSES.Enabled = True

            Else

                CheckBoxForm_UseSES.Enabled = False

            End If

            ComboBoxForm_Employee.SetRequired(False)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ComboBoxForm_Employee.DataSource = (From Employee In AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActive(DbContext)
                                                    Where Employee.Code <> Me.Session.User.EmployeeCode
                                                    Select New With {.FullName = If(Employee.MiddleInitial IsNot Nothing AndAlso Employee.MiddleInitial.Trim <> "",
                                                                                    Employee.FirstName & " " & Employee.MiddleInitial & ". " & Employee.LastName,
                                                                                    Employee.FirstName & " " & Employee.LastName) & " (" & Employee.Code & ")",
                                                                     .Code = Employee.Code}).ToList

            End Using

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Send_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Send.Click

            'objects
            Dim ErrorMessage As String = String.Empty
            Dim UserCode As String = String.Empty
            Dim UserName As String = String.Empty
            Dim Password As String = String.Empty
            Dim [From] As String = String.Empty
            Dim ReplyTo As String = String.Empty
            Dim SMTPSettings As AdvantageFramework.Email.Classes.SMTPSettings = Nothing
            Dim User As AdvantageFramework.Security.Database.Entities.User = Nothing

            If Me.Validator Then

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If CheckBoxForm_UseCurrent.Checked Then

                        UserCode = Me.Session.UserCode

                    Else

                        User = AdvantageFramework.Security.Database.Procedures.User.LoadFirstUserByEmployeeCode(SecurityDbContext, ComboBoxForm_Employee.SelectedValue)

                        If User IsNot Nothing Then

                            UserCode = User.UserCode

                        End If

                    End If

                End Using

                If String.IsNullOrWhiteSpace(UserCode) = False Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, UserCode)

                        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, UserCode)

                            SMTPSettings = New AdvantageFramework.Email.Classes.SMTPSettings(DbContext, _Agency, CheckBoxForm_UseSES.Checked)

                            If AdvantageFramework.Email.LoadSMTPSettings(DbContext, SecurityDbContext, SMTPSettings, UserName, Password, [From], ReplyTo) Then

                                If SendEmail(_Agency.MailBeeLicenseKey, SMTPSettings.SMTPAuthMethod, SMTPSettings.SMTPServer, SMTPSettings.SMTPPortNumber,
                                             UserName, Password, [From], ReplyTo, TextBoxForm_Email.Text,
                                             "Advantage TEST Email", False, "Advantage TEST Email Body", 3,
                                             SMTPSettings.SMTPSecureType, ErrorMessage) Then

                                    AdvantageFramework.WinForm.MessageBox.Show("Email was sent!")

                                Else

                                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                                End If

                            Else

                                AdvantageFramework.WinForm.MessageBox.Show("Failed to load SMTP settings properly.")

                            End If

                        End Using

                    End Using

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("A user cannot be found for employee " & ComboBoxForm_Employee.Text & ".")

                End If

                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                Me.Close()

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
        Private Sub CheckBoxForm_UseCurrent_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxForm_UseCurrent.CheckedChanged

            ComboBoxForm_Employee.Enabled = Not CheckBoxForm_UseCurrent.Checked

            If ComboBoxForm_Employee.Enabled Then

                ComboBoxForm_Employee.SetRequired(True)

            Else

                ComboBoxForm_Employee.SetRequired(False)

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
