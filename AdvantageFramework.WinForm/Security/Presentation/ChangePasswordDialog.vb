Namespace Security.Presentation

    Public Class ChangePasswordDialog

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum PasswordType
            All
            'EverythingButSystem
            'System
            AdAssist
            BillingApproval
            QuoteApproval
            Email
            Google
            Microsoft
            SugarCRM
            ProofHQ
            AdobeSignature
            VCC
        End Enum

#End Region

#Region " Variables "

        Private _PasswordType As PasswordType = PasswordType.All
        Private _UserID As Integer = 0
        Private _EmployeeCode As String = ""
        Private _IsAgencyASP As Boolean = False

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByVal Session As AdvantageFramework.Security.Session, ByVal PasswordType As PasswordType, ByVal UserID As Integer)

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _PasswordType = PasswordType
            _UserID = UserID

        End Sub
        'Private Sub ChangeSystemPassword()

        '    'objects
        '    Dim PasswordChanged As Boolean = False
        '    Dim ErrorMessage As String = ""
        '    Dim User As AdvantageFramework.Security.Database.Entities.User = Nothing
        '    Dim Messages As Generic.List(Of String) = Nothing
        '    Dim PasswordController As AdvantageFramework.Controller.Account.PasswordController = Nothing

        '    If TextBoxSystem_NewPassword.Text <> "" Then

        '        If TextBoxSystem_NewPassword.Text = TextBoxSystem_ConfirmNewPassword.Text Then

        '            Try

        '                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

        '                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

        '                        User = AdvantageFramework.Security.Database.Procedures.User.LoadByUserID(SecurityDbContext, Me.Session.User.ID)

        '                        If User IsNot Nothing Then

        '                            PasswordController = New AdvantageFramework.Controller.Account.PasswordController(Nothing)

        '                            If PasswordController.Validate(DbContext, TextBoxSystem_NewPassword.Text, Messages) = True Then

        '                                User.Password = AdvantageFramework.Security.LicenseKey.Encrypt(TextBoxSystem_NewPassword.Text.Trim)

        '                                PasswordChanged = AdvantageFramework.Security.Database.Procedures.User.Update(SecurityDbContext, User)

        '                            Else

        '                                If Messages IsNot Nothing AndAlso Messages.Count > 0 Then

        '                                    For Each Message As String In Messages

        '                                        If String.IsNullOrWhiteSpace(ErrorMessage) Then

        '                                            ErrorMessage = Message

        '                                        Else

        '                                            ErrorMessage &= System.Environment.NewLine & Message

        '                                        End If

        '                                    Next

        '                                End If

        '                            End If

        '                        End If

        '                    End Using

        '                End Using

        '                'System.Data.SqlClient.SqlConnection.ChangePassword(Me.Session.ConnectionString, TextBoxSystem_NewPassword.Text)

        '                'PasswordChanged = True

        '            Catch ex As Exception
        '                PasswordChanged = False
        '                ErrorMessage = ex.Message
        '            End Try

        '            If PasswordChanged Then

        '                AdvantageFramework.Navigation.ShowMessageBox("System password changed")

        '                Me.Session.SetPassword(TextBoxSystem_NewPassword.Text)

        '                TextBoxSystem_OldPassword.Text = TextBoxSystem_NewPassword.Text

        '            Else

        '                If ErrorMessage <> "" Then

        '                    AdvantageFramework.Navigation.ShowMessageBox(ErrorMessage)

        '                Else

        '                    AdvantageFramework.Navigation.ShowMessageBox("Failed to change system password")

        '                End If

        '            End If

        '        Else

        '            AdvantageFramework.Navigation.ShowMessageBox("The new passwords do not match.")

        '        End If

        '        TextBoxSystem_NewPassword.Text = ""
        '        TextBoxSystem_ConfirmNewPassword.Text = ""

        '    Else

        '        AdvantageFramework.Navigation.ShowMessageBox("Please enter a new password.")

        '    End If

        'End Sub
        Private Sub ChangeAdAssistPassword()

            'objects
            Dim PasswordChanged As Boolean = False
            Dim ErrorMessage As String = ""
            Dim ReturnValue As Integer = 0

            If TextBoxAdAssist_NewPassword.Text <> "" Then

                If TextBoxAdAssist_NewPassword.Text = TextBoxAdAssist_ConfirmNewPassword.Text Then

                    Try

                        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            If SecurityDbContext.Database.SqlQuery(Of String)("SELECT dbo.advfn_SEC_USER_AUTH(" & _UserID & ")").FirstOrDefault Is Nothing Then

                                SecurityDbContext.Database.ExecuteSqlCommand("EXEC dbo.advsp_DELETE_SEC_USER_AUTH " & _UserID & ", -2")

                                AdvantageFramework.Security.Database.Procedures.User.ChangeUserAdAssistPassword(SecurityDbContext, True, _UserID, AdvantageFramework.Security.Encryption.EncryptPassword(TextBoxAdAssist_NewPassword.Text), ReturnValue)

                            Else

                                AdvantageFramework.Security.Database.Procedures.User.ChangeUserAdAssistPassword(SecurityDbContext, False, _UserID, AdvantageFramework.Security.Encryption.EncryptPassword(TextBoxAdAssist_NewPassword.Text), ReturnValue)

                            End If

                        End Using

                        If ReturnValue > 0 Then

                            PasswordChanged = True

                        End If

                    Catch ex As Exception
                        PasswordChanged = False
                        ErrorMessage = ex.Message
                    End Try

                    If PasswordChanged Then

                        AdvantageFramework.Navigation.ShowMessageBox("AdAssist password changed")

                        TextBoxAdAssist_OldPassword.Text = TextBoxAdAssist_NewPassword.Text

                    Else

                        If ErrorMessage <> "" Then

                            AdvantageFramework.Navigation.ShowMessageBox(ErrorMessage)

                        Else

                            AdvantageFramework.Navigation.ShowMessageBox("Failed to change AdAssist password")

                        End If

                    End If

                Else

                    AdvantageFramework.Navigation.ShowMessageBox("The new passwords do not match.")

                End If

                TextBoxAdAssist_NewPassword.Text = ""
                TextBoxAdAssist_ConfirmNewPassword.Text = ""

            Else

                AdvantageFramework.Navigation.ShowMessageBox("Please enter a new password.")

            End If

        End Sub
        Private Sub ChangeBillingApprovalPassword()

            'objects
            Dim PasswordChanged As Boolean = False
            Dim ErrorMessage As String = ""

            If TextBoxBillingApproval_NewPassword.Text <> "" Then

                If TextBoxBillingApproval_NewPassword.Text = TextBoxBillingApproval_ConfirmNewPassword.Text Then

                    Try

                        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            If SecurityDbContext.Database.SqlQuery(Of Integer)("SELECT COUNT(*) FROM dbo.APPR_PASSWORD WHERE ACCT_EXEC = '" & _EmployeeCode & "'").FirstOrDefault > 0 Then

                                PasswordChanged = SecurityDbContext.Database.ExecuteSqlCommand("UPDATE dbo.APPR_PASSWORD SET PASSWORD_ID = '" & TextBoxBillingApproval_NewPassword.Text & "' WHERE ACCT_EXEC = '" & _EmployeeCode & "'") > 0

                            Else

                                PasswordChanged = SecurityDbContext.Database.ExecuteSqlCommand("INSERT INTO dbo.APPR_PASSWORD([ACCT_EXEC], [PASSWORD_ID], [USER_ID], [DATE_CREATED], [INACTIVE]) " &
                                                                                            "VALUES('" & _EmployeeCode & "', '" & TextBoxBillingApproval_NewPassword.Text & "', '" & Me.Session.UserCode & "', GETDATE(), NULL)") > 0

                            End If

                        End Using

                    Catch ex As Exception
                        PasswordChanged = False
                        ErrorMessage = ex.Message
                    End Try

                    If PasswordChanged Then

                        AdvantageFramework.Navigation.ShowMessageBox("Billing approval password changed")

                        TextBoxBillingApproval_OldPassword.Text = TextBoxBillingApproval_NewPassword.Text

                    Else

                        If ErrorMessage <> "" Then

                            AdvantageFramework.Navigation.ShowMessageBox(ErrorMessage)

                        Else

                            AdvantageFramework.Navigation.ShowMessageBox("Failed to change billing approval password")

                        End If

                    End If

                Else

                    AdvantageFramework.Navigation.ShowMessageBox("The new passwords do not match.")

                End If

                TextBoxBillingApproval_NewPassword.Text = ""
                TextBoxBillingApproval_ConfirmNewPassword.Text = ""

            Else

                AdvantageFramework.Navigation.ShowMessageBox("Please enter a new password.")

            End If

        End Sub
        Private Sub ChangeQuoteApprovalPassword()

            'objects
            Dim PasswordChanged As Boolean = False
            Dim ErrorMessage As String = ""

            'If TextBoxQuoteApproval_NewPassword.Text <> "" Then

            '	If TextBoxQuoteApproval_NewPassword.Text = TextBoxQuoteApproval_ConfirmNewPassword.Text Then

            '		Try

            '			Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

            '				PasswordChanged = SecurityDbContext.Database.ExecuteSqlCommand("EXEC [dbo].[advsp_quote_approval_password_create] '" & _EmployeeCode & "', '" & TextBoxQuoteApproval_NewPassword.Text & "'") > 0

            '			End Using

            '		Catch ex As Exception
            '			PasswordChanged = False
            '			ErrorMessage = ex.Message
            '		End Try

            '		If PasswordChanged Then

            '			AdvantageFramework.Navigation.ShowMessageBox("Quote approval password changed")

            '			TextBoxQuoteApproval_OldPassword.Text = TextBoxQuoteApproval_NewPassword.Text

            '		Else

            '			If ErrorMessage <> "" Then

            '				AdvantageFramework.Navigation.ShowMessageBox(ErrorMessage)

            '			Else

            '				AdvantageFramework.Navigation.ShowMessageBox("Failed to change quote approval password")

            '			End If

            '		End If

            '	Else

            '		AdvantageFramework.Navigation.ShowMessageBox("The new passwords do not match.")

            '	End If

            '	TextBoxQuoteApproval_NewPassword.Text = ""
            '	TextBoxQuoteApproval_ConfirmNewPassword.Text = ""

            'Else

            '	AdvantageFramework.Navigation.ShowMessageBox("Please enter a new password.")

            'End If

        End Sub
        Private Sub ChangeEmailPassword()

            'objects
            Dim PasswordChanged As Boolean = False
            Dim EmailChanged As Boolean = False
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim ErrorMessage As String = ""
            Dim ContinueSave As Boolean = True
            Dim ReauthorizeOAuth2 As Boolean = False

            If TextBoxEmail_Email.UserEntryChanged = True OrElse TextBoxEmail_NewPassword.Text <> "" Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, _EmployeeCode)

                    If Employee IsNot Nothing Then

                        If TextBoxEmail_Email.UserEntryChanged = True Then

                            EmailChanged = True

                            If String.IsNullOrWhiteSpace(Employee.GoogleToken) = False Then

                                If AdvantageFramework.Navigation.ShowMessageBox("Changing your email will require you to reauthorize Advantage OAuth2. Are you sure you want to continue?", WinForm.MessageBox.MessageBoxButtons.OKCancel) = WinForm.MessageBox.DialogResults.OK Then

                                    ReauthorizeOAuth2 = True

                                Else

                                    ContinueSave = False

                                End If

                            End If

                            Employee.Email = TextBoxEmail_Email.Text

                        End If

                        If TextBoxEmail_NewPassword.Text <> "" Then

                            If TextBoxEmail_NewPassword.Text = TextBoxEmail_ConfirmNewPassword.Text Then

                                PasswordChanged = True

                                Employee.EmailPassword = AdvantageFramework.Security.Encryption.Encrypt(TextBoxEmail_NewPassword.Text)

                            Else

                                ErrorMessage = "The new passwords do not match."

                            End If

                        End If

                        If ContinueSave Then

                            Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                                If ReauthorizeOAuth2 Then

                                    If String.IsNullOrWhiteSpace(Employee.GoogleToken) = False Then

                                        DeauthorizeGoogleServices()

                                    End If

                                End If

                                If AdvantageFramework.Database.Procedures.EmployeeView.Update(DbContext, DataContext, Employee) Then

                                    If PasswordChanged = True AndAlso EmailChanged = True Then

                                        AdvantageFramework.Navigation.ShowMessageBox("Email address and password changed")

                                    ElseIf PasswordChanged = True AndAlso EmailChanged = False Then

                                        AdvantageFramework.Navigation.ShowMessageBox("Email password changed")

                                    ElseIf PasswordChanged = False AndAlso EmailChanged = True Then

                                        AdvantageFramework.Navigation.ShowMessageBox("Email address changed")

                                    End If

                                    If PasswordChanged Then

                                        TextBoxEmail_OldPassword.Text = TextBoxEmail_NewPassword.Text

                                    End If

                                    If EmailChanged Then

                                        TextBoxEmail_Email.ClearChanged()

                                    End If

                                Else

                                    If PasswordChanged = True AndAlso EmailChanged = True Then

                                        ErrorMessage = "Failed to change email address and password"

                                    ElseIf PasswordChanged = True AndAlso EmailChanged = False Then

                                        ErrorMessage = "Failed to change email password"

                                    ElseIf PasswordChanged = False AndAlso EmailChanged = True Then

                                        ErrorMessage = "Failed to change email address"

                                    Else

                                        ErrorMessage = "Failed to change email address and password."

                                    End If

                                End If

                                If ReauthorizeOAuth2 Then

                                    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, _EmployeeCode)

                                    AuthorizeGoogleServices()
                                    LoadGoogleServicesData(Employee)

                                End If

                            End Using

                        End If

                        If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                            AdvantageFramework.Navigation.ShowMessageBox(ErrorMessage)

                        End If

                    End If

                End Using

                TextBoxEmail_NewPassword.Text = ""
                TextBoxEmail_ConfirmNewPassword.Text = ""

            Else

                AdvantageFramework.Navigation.ShowMessageBox("Please enter a new password and/or update your email address.")

            End If

        End Sub
        Private Sub ChangeSugarCRMPassword()

            'objects
            Dim PasswordChanged As Boolean = False
            Dim UserNameChanged As Boolean = False
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim ErrorMessage As String = ""

            If TextBoxSugarCRM_UserName.UserEntryChanged = True OrElse TextBoxSugarCRM_NewPassword.Text <> "" Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, _EmployeeCode)

                    If Employee IsNot Nothing Then

                        If TextBoxSugarCRM_UserName.UserEntryChanged = True Then

                            UserNameChanged = True

                            Employee.SugarCRMUserName = TextBoxSugarCRM_UserName.Text

                        End If

                        If TextBoxSugarCRM_NewPassword.Text <> "" Then

                            If TextBoxSugarCRM_NewPassword.Text = TextBoxSugarCRM_ConfirmNewPassword.Text Then

                                PasswordChanged = True

                                Employee.SugarCRMPassword = TextBoxSugarCRM_NewPassword.Text

                            Else

                                ErrorMessage = "The new passwords do not match."

                            End If

                        End If

                        If String.IsNullOrWhiteSpace(ErrorMessage) Then

                            Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                                If AdvantageFramework.Database.Procedures.EmployeeView.Update(DbContext, DataContext, Employee) Then

                                    If PasswordChanged = True AndAlso UserNameChanged = True Then

                                        AdvantageFramework.Navigation.ShowMessageBox("SugarCRM user name and password changed")

                                    ElseIf PasswordChanged = True AndAlso UserNameChanged = False Then

                                        AdvantageFramework.Navigation.ShowMessageBox("SugarCRM password changed")

                                    ElseIf PasswordChanged = False AndAlso UserNameChanged = True Then

                                        AdvantageFramework.Navigation.ShowMessageBox("SugarCRM user name changed")

                                    End If

                                    If PasswordChanged Then

                                        TextBoxSugarCRM_OldPassword.Text = TextBoxSugarCRM_NewPassword.Text

                                    End If

                                    If UserNameChanged Then

                                        TextBoxSugarCRM_UserName.ClearChanged()

                                    End If

                                Else

                                    If PasswordChanged = True AndAlso UserNameChanged = True Then

                                        ErrorMessage = "Failed to change SugarCRM user name and password"

                                    ElseIf PasswordChanged = True AndAlso UserNameChanged = False Then

                                        ErrorMessage = "Failed to change SugarCRM password"

                                    ElseIf PasswordChanged = False AndAlso UserNameChanged = True Then

                                        ErrorMessage = "Failed to change SugarCRM user name"

                                    Else

                                        ErrorMessage = "Failed to change SugarCRM user name and password"

                                    End If

                                End If

                            End Using

                        End If

                        If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                            AdvantageFramework.Navigation.ShowMessageBox(ErrorMessage)

                        End If

                    End If

                End Using

                TextBoxSugarCRM_NewPassword.Text = ""
                TextBoxSugarCRM_ConfirmNewPassword.Text = ""

            Else

                AdvantageFramework.Navigation.ShowMessageBox("Please enter a new password and/or update your user name.")

            End If

        End Sub
        Private Sub ChangeProofHQPassword()

            'objects
            Dim PasswordChanged As Boolean = False
            Dim UserNameChanged As Boolean = False
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim ErrorMessage As String = ""

            If TextBoxProofHQ_NewPassword.UserEntryChanged OrElse TextBoxProofHQ_UserName.UserEntryChanged Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Me.Session.User.EmployeeCode)

                    If Employee IsNot Nothing Then

                        If TextBoxProofHQ_UserName.UserEntryChanged Then

                            UserNameChanged = True

                            Employee.ProofHQUserName = TextBoxProofHQ_UserName.Text

                        End If

                        If TextBoxProofHQ_NewPassword.UserEntryChanged Then

                            If TextBoxProofHQ_NewPassword.Text = TextBoxProofHQ_ConfirmNewPassword.Text Then

                                PasswordChanged = True

                                Employee.ProofHQPassword = TextBoxProofHQ_NewPassword.Text

                            Else

                                PasswordChanged = False

                                ErrorMessage = "The new passwords do not match."

                            End If

                        End If

                        If String.IsNullOrWhiteSpace(ErrorMessage) Then

                            Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                                If AdvantageFramework.Database.Procedures.EmployeeView.Update(DbContext, DataContext, Employee) Then

                                    If PasswordChanged = True AndAlso UserNameChanged = True Then

                                        AdvantageFramework.Navigation.ShowMessageBox("ProofHQ user name and password changed")

                                    ElseIf PasswordChanged = True AndAlso UserNameChanged = False Then

                                        AdvantageFramework.Navigation.ShowMessageBox("ProofHQ password changed")

                                    ElseIf PasswordChanged = False AndAlso UserNameChanged = True Then

                                        AdvantageFramework.Navigation.ShowMessageBox("ProofHQ user name changed")

                                    End If

                                    If PasswordChanged Then

                                        TextBoxProofHQ_OldPassword.Text = TextBoxProofHQ_NewPassword.Text

                                    End If

                                    If UserNameChanged Then

                                        TextBoxProofHQ_UserName.Text = Employee.ProofHQUserName

                                    End If

                                Else

                                    If PasswordChanged = True AndAlso UserNameChanged = True Then

                                        ErrorMessage = "Failed to change ProofHQ user name and password"

                                    ElseIf PasswordChanged = True AndAlso UserNameChanged = False Then

                                        ErrorMessage = "Failed to change ProofHQ password"

                                    ElseIf PasswordChanged = False AndAlso UserNameChanged = True Then

                                        ErrorMessage = "Failed to change ProofHQ user name"

                                    Else

                                        ErrorMessage = "Failed to change ProofHQ user name and password"

                                    End If

                                End If

                            End Using

                        End If

                        If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                            AdvantageFramework.Navigation.ShowMessageBox(ErrorMessage)

                        End If

                    End If

                End Using

                TextBoxProofHQ_NewPassword.Text = ""
                TextBoxProofHQ_ConfirmNewPassword.Text = ""

            Else

                AdvantageFramework.Navigation.ShowMessageBox("Please enter a new password and/or update your user name.")

            End If

        End Sub
        Private Sub ChangeAdobeSignaturePassword()

            'objects
            Dim PasswordChanged As Boolean = False
            Dim UserNameChanged As Boolean = False
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim ErrorMessage As String = ""

            If TextBoxAdobeSignature_NewPassword.UserEntryChanged Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Me.Session.User.EmployeeCode)

                    If Employee IsNot Nothing Then

                        If TextBoxAdobeSignature_NewPassword.UserEntryChanged Then

                            If TextBoxAdobeSignature_NewPassword.Text = TextBoxAdobeSignature_ConfirmNewPassword.Text Then

                                PasswordChanged = True

                                Employee.AdobeSignatureFilePassword = TextBoxAdobeSignature_NewPassword.Text

                            Else

                                PasswordChanged = False

                                ErrorMessage = "The new passwords do not match."

                            End If

                        End If

                        If String.IsNullOrWhiteSpace(ErrorMessage) Then

                            Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                                If AdvantageFramework.Database.Procedures.EmployeeView.Update(DbContext, DataContext, Employee) Then

                                    AdvantageFramework.Navigation.ShowMessageBox("Adobe Signature password changed")

                                    If PasswordChanged Then

                                        TextBoxAdobeSignature_OldPassword.Text = TextBoxAdobeSignature_NewPassword.Text

                                    End If

                                Else

                                    ErrorMessage = "Failed to change Adobe Signature password"

                                End If

                            End Using

                        End If

                        If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                            AdvantageFramework.Navigation.ShowMessageBox(ErrorMessage)

                        End If

                    End If

                End Using

                TextBoxAdobeSignature_NewPassword.Text = ""
                TextBoxAdobeSignature_ConfirmNewPassword.Text = ""

            Else

                AdvantageFramework.Navigation.ShowMessageBox("Please enter a new password.")

            End If

        End Sub
        Private Sub ChangeVCCPassword()

            'objects
            Dim PasswordChanged As Boolean = False
            Dim UserNameChanged As Boolean = False
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim ErrorMessage As String = ""

            If TextBoxVCC_UserName.UserEntryChanged OrElse TextBoxVCC_NewPassword.UserEntryChanged Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Me.Session.User.EmployeeCode)

                    If Employee IsNot Nothing Then

                        If TextBoxVCC_UserName.UserEntryChanged Then

                            UserNameChanged = True

                            Employee.VCCUserName = TextBoxVCC_UserName.Text

                        End If

                        If TextBoxVCC_NewPassword.UserEntryChanged Then

                            If TextBoxVCC_NewPassword.Text = TextBoxVCC_ConfirmNewPassword.Text Then

                                PasswordChanged = True

                                Employee.VCCPassword = TextBoxVCC_NewPassword.Text

                            Else

                                PasswordChanged = False

                                ErrorMessage = "The new passwords do not match."

                            End If

                        End If

                        If String.IsNullOrWhiteSpace(ErrorMessage) Then

                            Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                                If AdvantageFramework.Database.Procedures.EmployeeView.Update(DbContext, DataContext, Employee) Then

                                    If PasswordChanged = True AndAlso UserNameChanged = True Then

                                        AdvantageFramework.Navigation.ShowMessageBox("VCC user name and password changed")

                                    ElseIf PasswordChanged = True AndAlso UserNameChanged = False Then

                                        AdvantageFramework.Navigation.ShowMessageBox("VCC password changed")

                                    ElseIf PasswordChanged = False AndAlso UserNameChanged = True Then

                                        AdvantageFramework.Navigation.ShowMessageBox("VCC user name changed")

                                    End If

                                    If PasswordChanged Then

                                        TextBoxVCC_OldPassword.Text = TextBoxVCC_NewPassword.Text

                                    End If

                                    If UserNameChanged Then

                                        TextBoxVCC_UserName.Text = Employee.VCCUserName

                                    End If

                                Else

                                    If PasswordChanged = True AndAlso UserNameChanged = True Then

                                        ErrorMessage = "Failed to change VCC user name and password"

                                    ElseIf PasswordChanged = True AndAlso UserNameChanged = False Then

                                        ErrorMessage = "Failed to change VCC password"

                                    ElseIf PasswordChanged = False AndAlso UserNameChanged = True Then

                                        ErrorMessage = "Failed to change VCC user name"

                                    Else

                                        ErrorMessage = "Failed to change VCC user name and password"

                                    End If

                                End If

                            End Using

                        End If

                        If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                            AdvantageFramework.Navigation.ShowMessageBox(ErrorMessage)

                        End If

                    End If

                End Using

                TextBoxVCC_NewPassword.Text = ""
                TextBoxVCC_ConfirmNewPassword.Text = ""

            Else

                AdvantageFramework.Navigation.ShowMessageBox("Please enter a new password and/or update your user name.")

            End If

        End Sub
        Private Sub LoadGoogleServicesData(ByVal Employee As AdvantageFramework.Database.Views.Employee)

            'objects
            Dim Current As String = Nothing
            Dim Action As String = Nothing
            Dim Link As String = String.Empty

            If Not String.IsNullOrWhiteSpace(Employee.GoogleToken) Then

                Current = "enabled"
                Action = "Disable"

            Else

                Current = "disabled"
                Action = "Enable"

            End If

            If _IsAgencyASP = False Then

                Link = String.Format(" <a name=""{0}"">{0}</a>", Action)

            Else

                Link = "  Please use Webvantage to modify this setting."

            End If

            LabelEmail_GoogleServices.Text = String.Format("Advantage Google OAuth2 are currently {0}.", Current) & Link
            LabelGoogle_GoogleServices.Text = String.Format("Advantage Google OAuth2 are currently {0}.", Current) & Link

        End Sub
        'Private Sub LoadGoogleServicesData()

        '    'objects
        '    Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

        '    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

        '        Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, _EmployeeCode)

        '    End Using

        '    If Employee IsNot Nothing Then

        '        LoadGoogleServicesData(Employee)

        '    End If

        'End Sub
        Private Sub DeauthorizeGoogleServices()

            Dim Service As AdvantageFramework.GoogleServices.Service = Nothing

            Me.ShowWaitForm("Processing...")

            Try

                Service = AdvantageFramework.GoogleServices.Service.Initialize(GoogleServices.Service.ServiceTypes.Calendar, Me.Session, _EmployeeCode, False)

                If Service IsNot Nothing Then

                    Service.Deauthorize()

                End If

            Catch ex As Exception

            End Try

            Me.CloseWaitForm()

        End Sub
        Private Sub AuthorizeGoogleServices()

            'objects
            Dim AuthorizationCode As String = Nothing
            Dim Service As AdvantageFramework.GoogleServices.Service = Nothing
            Dim ServiceType As GoogleServices.Service.ServiceTypes = GoogleServices.Service.ServiceTypes.Calendar

            Me.SetFormActionAndShowWaitForm(WinForm.Presentation.FormActions.Loading, "Launching Authorization window..." & System.Environment.NewLine & "(will time out after 2 mins)")

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If AdvantageFramework.GoogleServices.Service.GetEnabledServices(DbContext, False).Contains(AdvantageFramework.GoogleServices.Service.ServiceTypes.Gmail) Then

                        ServiceType = AdvantageFramework.GoogleServices.Service.ServiceTypes.All

                    End If

                End Using

                Service = AdvantageFramework.GoogleServices.Service.Initialize(ServiceType, Me.Session, _EmployeeCode, False)

                If Service IsNot Nothing Then

                    Service.Authorize()

                End If

            Catch ex As Exception

            End Try

            Me.SetFormActionAndShowWaitForm(WinForm.Presentation.FormActions.None)

        End Sub
        Private Sub LoadOAuthServiceData(Employee As AdvantageFramework.Database.Views.Employee)

            If Employee Is Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Me.Session.User.EmployeeCode)

                End Using

            End If

            If Employee IsNot Nothing Then

                If String.IsNullOrWhiteSpace(Employee.GoogleToken) = False Then

                    LoadGoogleServicesData(Employee)

                Else

                    LoadGoogleServicesData(Employee)

                End If

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef Session As AdvantageFramework.Security.Session, ByVal PasswordType As PasswordType) As System.Windows.Forms.DialogResult

            ShowFormDialog = ShowFormDialog(Session, PasswordType, Session.User.ID)

        End Function
        Public Shared Function ShowFormDialog(ByRef Session As AdvantageFramework.Security.Session, ByVal PasswordType As PasswordType, ByVal UserID As Integer) As System.Windows.Forms.DialogResult

            'objects
            Dim ChangePasswordDialog As AdvantageFramework.Security.Presentation.ChangePasswordDialog = Nothing

            ChangePasswordDialog = New AdvantageFramework.Security.Presentation.ChangePasswordDialog(Session, PasswordType, UserID)

            ShowFormDialog = ChangePasswordDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub ChangePasswordDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim User As AdvantageFramework.Security.Database.Entities.User = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim TabVisible As Boolean = False
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing

            TextBoxBillingApproval_OldPassword.SetDefaultPropertySettings(MaxLength:=20)
            TextBoxBillingApproval_NewPassword.SetDefaultPropertySettings(MaxLength:=20)
            TextBoxBillingApproval_ConfirmNewPassword.SetDefaultPropertySettings(MaxLength:=20)

            'TextBoxQuoteApproval_OldPassword.SetDefaultPropertySettings(MaxLength:=10)
            'TextBoxQuoteApproval_NewPassword.SetDefaultPropertySettings(MaxLength:=10)
            'TextBoxQuoteApproval_ConfirmNewPassword.SetDefaultPropertySettings(MaxLength:=10)

            TextBoxAdAssist_OldPassword.SetDefaultPropertySettings(MaxLength:=255)
            TextBoxAdAssist_NewPassword.SetDefaultPropertySettings(MaxLength:=255)
            TextBoxAdAssist_ConfirmNewPassword.SetDefaultPropertySettings(MaxLength:=255)

            TextBoxEmail_OldPassword.SetDefaultPropertySettings(MaxLength:=50)
            TextBoxEmail_NewPassword.SetDefaultPropertySettings(MaxLength:=50)
            TextBoxEmail_ConfirmNewPassword.SetDefaultPropertySettings(MaxLength:=50)

            TextBoxSugarCRM_OldPassword.SetDefaultPropertySettings(MaxLength:=100)
            TextBoxSugarCRM_NewPassword.SetDefaultPropertySettings(MaxLength:=100)
            TextBoxSugarCRM_ConfirmNewPassword.SetDefaultPropertySettings(MaxLength:=100)

            TextBoxProofHQ_UserName.SetDefaultPropertySettings(MaxLength:=100)
            TextBoxProofHQ_OldPassword.SetDefaultPropertySettings(MaxLength:=100)
            TextBoxProofHQ_NewPassword.SetDefaultPropertySettings(MaxLength:=100)
            TextBoxProofHQ_ConfirmNewPassword.SetDefaultPropertySettings(MaxLength:=100)

            TextBoxAdobeSignature_OldPassword.SetDefaultPropertySettings(MaxLength:=100)
            TextBoxAdobeSignature_NewPassword.SetDefaultPropertySettings(MaxLength:=100)
            TextBoxAdobeSignature_ConfirmNewPassword.SetDefaultPropertySettings(MaxLength:=100)

            TextBoxVCC_UserName.SetDefaultPropertySettings(MaxLength:=100)
            TextBoxVCC_OldPassword.SetDefaultPropertySettings(MaxLength:=100)
            TextBoxVCC_NewPassword.SetDefaultPropertySettings(MaxLength:=100)
            TextBoxVCC_ConfirmNewPassword.SetDefaultPropertySettings(MaxLength:=100)

            LabelEmail_GoogleServices.TextAlignment = Drawing.StringAlignment.Near

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                User = AdvantageFramework.Security.Database.Procedures.User.LoadByUserID(SecurityDbContext, _UserID)

                If User IsNot Nothing Then

                    _EmployeeCode = User.EmployeeCode

                    For Each TabItem In TabControlForm_Passwords.Tabs.OfType(Of DevComponents.DotNetBar.TabItem)

                        TabVisible = False

                        If _PasswordType = PasswordType.All Then

                            TabVisible = True

                        Else

                            Select Case _PasswordType

                                'Case PasswordType.EverythingButSystem

                                '    TabVisible = Not (TabItem Is TabItemPasswords_SystemTab)

                                'Case PasswordType.System

                                '    TabVisible = (TabItem Is TabItemPasswords_SystemTab)

                                Case PasswordType.AdAssist

                                    TabVisible = (TabItem Is TabItemPasswords_AdAssistTab)

                                Case PasswordType.BillingApproval

                                    TabVisible = (TabItem Is TabItemPasswords_BillingApprovalTab)

                                Case PasswordType.QuoteApproval

                                    'TabVisible = (TabItem Is TabItemPasswords_QuoteApprovalTab)

                                Case PasswordType.Email

                                    TabVisible = (TabItem Is TabItemPasswords_EmailTab)

                                Case PasswordType.Google

                                    TabVisible = (TabItem Is TabItemPasswords_GoogleTab)

                                Case PasswordType.SugarCRM

                                    TabVisible = (TabItem Is TabItemPasswords_SugarCRMTab)

                                Case PasswordType.ProofHQ

                                    TabVisible = (TabItem Is TabItemPasswords_ProofHQTab)

                                Case PasswordType.AdobeSignature

                                    TabVisible = (TabItem Is TabItemPasswords_AdobeSignatureTab)

                                Case PasswordType.VCC

                                    TabVisible = (TabItem Is TabItemPasswords_VCCTab)

                            End Select


                        End If

                        TabItem.Visible = TabVisible

                    Next

                    'If Me.Session.UseWindowsAuthentication Then

                    '    TabItemPasswords_SystemTab.Visible = False

                    'End If

                    'If TabItemPasswords_SystemTab.Visible Then

                    '    TextBoxSystem_OldPassword.Text = Me.Session.Password

                    'End If

                    TabItemPasswords_AdAssistTab.Visible = AdvantageFramework.Security.DoesUserHaveAccessToApplication(SecurityDbContext, New AdvantageFramework.Security.Classes.User(User), AdvantageFramework.Security.Application.Adassist)

                    If TabItemPasswords_AdAssistTab.Visible Then

                        TextBoxAdAssist_OldPassword.Text = SecurityDbContext.Database.SqlQuery(Of String)("SELECT dbo.advfn_SEC_USER_AUTH(" & User.ID & ")").FirstOrDefault

                    End If

                    If TabItemPasswords_BillingApprovalTab.Visible Then

                        TabItemPasswords_BillingApprovalTab.Visible = AdvantageFramework.Security.DoesUserHaveAccessToModule(SecurityDbContext, AdvantageFramework.Security.Application.Webvantage, AdvantageFramework.Security.Modules.Billing_BillingApproval.ToString, User.ID)

                        If TabItemPasswords_BillingApprovalTab.Visible Then

                            If SecurityDbContext.Database.SqlQuery(Of Integer)("SELECT COUNT(*) FROM dbo.APPR_PASSWORD WHERE ACCT_EXEC = '" & _EmployeeCode & "'").FirstOrDefault > 0 Then

                                TextBoxBillingApproval_OldPassword.Text = SecurityDbContext.Database.SqlQuery(Of String)("SELECT PASSWORD_ID FROM dbo.APPR_PASSWORD WHERE ACCT_EXEC = '" & _EmployeeCode & "'").FirstOrDefault

                            End If

                        End If

                    End If

                    'If TabItemPasswords_QuoteApprovalTab.Visible Then

                    '	TabItemPasswords_QuoteApprovalTab.Visible = AdvantageFramework.Security.DoesUserHaveAccessToModule(SecurityDbContext, Me.Session.Application, AdvantageFramework.Security.Modules.ProjectManagement_QuoteApproval.ToString, User.ID)

                    '	If TabItemPasswords_QuoteApprovalTab.Visible Then

                    '		If SecurityDbContext.Database.SqlQuery(Of Integer)("SELECT COUNT(*) FROM dbo.QTE_APP_PWD WHERE EMP_CODE = '" & _EmployeeCode & "'").FirstOrDefault > 0 Then

                    '			TextBoxQuoteApproval_OldPassword.Text = SecurityDbContext.Database.SqlQuery(Of String)("SELECT EMP_PWD FROM dbo.QTE_APP_PWD WHERE EMP_CODE = '" & _EmployeeCode & "'").FirstOrDefault

                    '		End If

                    '	End If

                    'End If

                    If TabItemPasswords_EmailTab.Visible OrElse TabItemPasswords_SugarCRMTab.Visible OrElse TabItemPasswords_ProofHQTab.Visible OrElse
                            TabItemPasswords_AdobeSignatureTab.Visible OrElse TabItemPasswords_VCCTab.Visible Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, _EmployeeCode)

                        End Using

                        If Employee IsNot Nothing Then

                            If TabItemPasswords_GoogleTab.Visible Then

                                LoadGoogleServicesData(Employee)

                            End If

                            If TabItemPasswords_EmailTab.Visible Then

                                LoadOAuthServiceData(Employee)

                                TextBoxEmail_Email.Text = Employee.Email

                                If String.IsNullOrWhiteSpace(Employee.EmailPassword) = False Then

                                    TextBoxEmail_OldPassword.Text = AdvantageFramework.Security.Encryption.Decrypt(Employee.EmailPassword)

                                Else

                                    TextBoxEmail_OldPassword.Text = Employee.EmailPassword

                                End If

                                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                                    Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                                    If Agency.SMTPAuthenticationMethodType = AdvantageFramework.Email.SmtpAuthenticationMethods.OAuth2 Then

                                        LabelEmail_OldPassword.Visible = False
                                        TextBoxEmail_OldPassword.Visible = False
                                        LabelEmail_NewPassword.Visible = False
                                        TextBoxEmail_NewPassword.Visible = False
                                        LabelEmail_ConfirmNewPassword.Visible = False
                                        TextBoxEmail_ConfirmNewPassword.Visible = False

                                        LabelEmail_GoogleServices.Location = New Drawing.Point(134, 30)
                                        LabelEmail_GoogleNote.Location = New Drawing.Point(512, 30)

                                    End If

                                End Using

                            End If

                            If TabItemPasswords_SugarCRMTab.Visible Then

                                TextBoxSugarCRM_UserName.Text = Employee.SugarCRMUserName
                                TextBoxSugarCRM_OldPassword.Text = Employee.SugarCRMPassword

                            End If

                            If TabItemPasswords_ProofHQTab.Visible Then

                                TextBoxProofHQ_UserName.Text = Employee.ProofHQUserName
                                TextBoxProofHQ_OldPassword.Text = Employee.ProofHQPassword

                            End If

                            If TabItemPasswords_AdobeSignatureTab.Visible Then

                                TextBoxAdobeSignature_OldPassword.Text = Employee.AdobeSignatureFilePassword

                            End If

                            If TabItemPasswords_VCCTab.Visible Then

                                TextBoxVCC_UserName.Text = Employee.VCCUserName
                                TextBoxVCC_OldPassword.Text = Employee.VCCPassword

                            End If

                        End If

                    End If

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("The user does not exist anymore in the system.")

                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    Me.Close()

                End If

            End Using

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Save_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Save.Click

            'If TabControlForm_Passwords.SelectedTab Is TabItemPasswords_SystemTab Then

            '    ChangeSystemPassword()

            If TabControlForm_Passwords.SelectedTab Is TabItemPasswords_AdAssistTab Then

                ChangeAdAssistPassword()

            ElseIf TabControlForm_Passwords.SelectedTab Is TabItemPasswords_BillingApprovalTab Then

                ChangeBillingApprovalPassword()

                'ElseIf TabControlForm_Passwords.SelectedTab Is TabItemPasswords_QuoteApprovalTab Then

                '	ChangeQuoteApprovalPassword()

            ElseIf TabControlForm_Passwords.SelectedTab Is TabItemPasswords_EmailTab Then

                ChangeEmailPassword()

            ElseIf TabControlForm_Passwords.SelectedTab Is TabItemPasswords_SugarCRMTab Then

                ChangeSugarCRMPassword()

            ElseIf TabControlForm_Passwords.SelectedTab Is TabItemPasswords_ProofHQTab Then

                ChangeProofHQPassword()

            ElseIf TabControlForm_Passwords.SelectedTab Is TabItemPasswords_AdobeSignatureTab Then

                ChangeAdobeSignaturePassword()

            ElseIf TabControlForm_Passwords.SelectedTab Is TabItemPasswords_VCCTab Then

                ChangeVCCPassword()

            End If

        End Sub
        Private Sub ButtonForm_Close_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Close.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()

        End Sub
        Private Sub LabelEmail_GoogleServices_MarkupLinkClick(sender As Object, e As DevComponents.DotNetBar.MarkupLinkClickEventArgs) Handles LabelEmail_GoogleServices.MarkupLinkClick

            If e.Name = "Enable" Then

                AuthorizeGoogleServices()

            ElseIf e.Name = "Disable" Then

                DeauthorizeGoogleServices()

            End If

            LoadOAuthServiceData(Nothing)

        End Sub
        Private Sub LabelGoogle_GoogleServices_MarkupLinkClick(sender As Object, e As DevComponents.DotNetBar.MarkupLinkClickEventArgs) Handles LabelGoogle_GoogleServices.MarkupLinkClick

            If e.Name = "Enable" Then

                AuthorizeGoogleServices()

            ElseIf e.Name = "Disable" Then

                DeauthorizeGoogleServices()

            End If

            LoadOAuthServiceData(Nothing)

        End Sub

#End Region

#End Region

    End Class

End Namespace
