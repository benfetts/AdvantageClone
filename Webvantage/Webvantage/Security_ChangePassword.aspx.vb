Public Class Security_ChangePassword
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "

    Public Enum PasswordType
        All
        System
        AdAssist
        BillingApproval
        QuoteApproval
        Email
        SugarCRM
        ProofHQ
        AdobeSignature
        VCC
    End Enum

#End Region

#Region " Variables "

    Private _PasswordType As PasswordType = PasswordType.All

#End Region

#Region " Properties "

    'Store viewstate in session instead of on the page...
    'This doesn't work on the base page
    Dim _pers As PageStatePersister

    Protected Overrides ReadOnly Property PageStatePersister() As PageStatePersister
        Get
            If _pers Is Nothing Then
                _pers = New SessionPageStatePersister(Me)
            End If
            Return _pers
        End Get
    End Property

    'Private _OldValues As Values = New Values
    Private Property Vals As Values
        Get
            If ViewState("LOLT") Is Nothing Then ViewState("LOLT") = New Values
            Return CType(ViewState("LOLT"), Values)
        End Get
        Set(value As Values)
            If value Is Nothing Then value = New Values
            ViewState("LOLT") = value
        End Set
    End Property

#End Region

#Region " Methods "

    Private Sub ChangeTabs()

        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            'objects
            Dim OriginalValue As String = Nothing
            Dim IsCalendarSyncEnabled As Boolean = False

            Select Case RadTabStripChangePassword.SelectedIndex

                'Case 0

                '    Me.Vals.SetValue(Values.Type.SystemOld, _Session.Password)
                '    'Me.Vals.SetValue(Values.Type.SystemOld, AdvantageFramework.Security.Encryption.Decrypt(SecurityDbContext.Database.SqlQuery(Of String)(String.Format("SELECT TOP 1 PASSWORD FROM SEC_USER WITH(NOLOCK) WHERE SEC_USER_ID = {0} ORDER BY SEC_USER_ID DESC;", _Session.User.ID)).First))

                Case 0

                    Me.Vals.SetValue(Values.Type.AdAssistOld, SecurityDbContext.Database.SqlQuery(Of String)("SELECT [dbo].[advfn_SEC_USER_AUTH] (" & _Session.User.ID & ")").First)

                Case 1

                    If SecurityDbContext.Database.SqlQuery(Of String)("SELECT PASSWORD_ID FROM [dbo].[APPR_PASSWORD] WITH(NOLOCK) WHERE ACCT_EXEC = '" & _Session.User.EmployeeCode & "'").Count > 0 Then
                        Me.Vals.SetValue(Values.Type.BillingApprovalOld, SecurityDbContext.Database.SqlQuery(Of String)("SELECT PASSWORD_ID FROM [dbo].[APPR_PASSWORD] WITH(NOLOCK) WHERE ACCT_EXEC = '" & _Session.User.EmployeeCode & "'").First)
                    End If

                'Case 3

                '    Me.Vals.SetValue(Values.Type.QuoteApprovalOld, SecurityDbContext.Database.SqlQuery(Of String)("SELECT EMP_PWD FROM [dbo].[QTE_APP_PWD] WITH(NOLOCK) WHERE EMP_CODE = '" & _Session.User.EmployeeCode & "'").First)

                Case 2

                    OriginalValue = SecurityDbContext.Database.SqlQuery(Of String)("SELECT EMP_EMAIL FROM dbo.EMPLOYEE WHERE EMP_CODE = '" & _Session.User.EmployeeCode & "'").First

                    If String.IsNullOrWhiteSpace(SecurityDbContext.Database.SqlQuery(Of String)("SELECT GOOGLE_TOKEN FROM [dbo].[EMPLOYEE] WITH(NOLOCK) WHERE EMP_CODE = '" & _Session.User.EmployeeCode & "'").First) = False Then

                        IsCalendarSyncEnabled = True

                    End If

                    Me.Vals.SetValue(Values.Type.EmailOld, SecurityDbContext.Database.SqlQuery(Of String)("SELECT EMAIL_PWD FROM [dbo].[EMPLOYEE] WITH(NOLOCK) WHERE EMP_CODE = '" & _Session.User.EmployeeCode & "'").First)

                    TextBoxEmailAddress.Text = OriginalValue
                    HiddenFieldOriginalEmailAddress.Value = OriginalValue

                    LoadOAuthServiceData()

                Case 3

                    OriginalValue = SecurityDbContext.Database.SqlQuery(Of String)("SELECT SUGAR_USERNAME FROM [dbo].[EMPLOYEE] WHERE EMP_CODE = '" & _Session.User.EmployeeCode & "'").First

                    Me.Vals.SetValue(Values.Type.SugarCRMOld, SecurityDbContext.Database.SqlQuery(Of String)("SELECT SUGAR_PASSWORD FROM [dbo].[EMPLOYEE] WITH(NOLOCK) WHERE EMP_CODE = '" & _Session.User.EmployeeCode & "'").First)

                    TextBoxSugarCRMUserName.Text = OriginalValue
                    HiddenFieldOriginalSugarCRMUserName.Value = OriginalValue

                Case 4

                    OriginalValue = SecurityDbContext.Database.SqlQuery(Of String)("SELECT PROOFHQ_USERNAME FROM [dbo].[EMPLOYEE] WITH(NOLOCK) WHERE EMP_CODE = '" & _Session.User.EmployeeCode & "'").First

                    Me.Vals.SetValue(Values.Type.ProofHQOld, SecurityDbContext.Database.SqlQuery(Of String)("SELECT PROOFHQ_PASSWORD FROM [dbo].[EMPLOYEE] WITH(NOLOCK) WHERE EMP_CODE = '" & _Session.User.EmployeeCode & "'").First)

                    TextBoxProofHQUserName.Text = OriginalValue
                    HiddenFieldOriginalProofHQUserName.Value = OriginalValue

                Case 5

                    Me.Vals.SetValue(Values.Type.AdobeSignatureOld, SecurityDbContext.Database.SqlQuery(Of String)("SELECT ADOBE_SIGNATURE_FILE_PASSWORD FROM [dbo].[EMPLOYEE] WITH(NOLOCK) WHERE EMP_CODE = '" & _Session.User.EmployeeCode & "'").First)

                Case 6

                    OriginalValue = SecurityDbContext.Database.SqlQuery(Of String)("SELECT VCC_USERNAME FROM [dbo].[EMPLOYEE] WITH(NOLOCK) WHERE EMP_CODE = '" & _Session.User.EmployeeCode & "'").First

                    Me.Vals.SetValue(Values.Type.VCCOld, SecurityDbContext.Database.SqlQuery(Of String)("SELECT VCC_PASSWORD FROM [dbo].[EMPLOYEE] WITH(NOLOCK) WHERE EMP_CODE = '" & _Session.User.EmployeeCode & "'").First)

                    TextBoxVCCUserName.Text = OriginalValue
                    HiddenFieldOriginalVCCUserName.Value = OriginalValue

            End Select

        End Using

    End Sub
    'Private Sub ChangeSystemPassword()

    '    'objects
    '    Dim PasswordChanged As Boolean = False
    '    Dim ErrorMessage As String = ""
    '    Dim User As AdvantageFramework.Security.Database.Entities.User = Nothing
    '    Dim Messages As Generic.List(Of String) = Nothing
    '    Dim PasswordController As AdvantageFramework.Controller.Account.PasswordController = Nothing

    '    If TextBoxSystemOldPassword.Text <> Me.Vals.GetValue(Values.Type.SystemOld) Then

    '        Me.ShowMessage(MiscFN.JavascriptSafe("Invalid old password"))
    '        Exit Sub

    '    End If

    '    If TextBoxSystemNewPassword.Text <> "" Then

    '        If TextBoxSystemNewPassword.Text = TextBoxSystemConfirmNewPassword.Text Then

    '            Try

    '                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

    '                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

    '                        User = AdvantageFramework.Security.Database.Procedures.User.LoadByUserID(SecurityDbContext, _Session.User.ID)

    '                        If User IsNot Nothing Then

    '                            PasswordController = New AdvantageFramework.Controller.Account.PasswordController(Nothing)

    '                            If PasswordController.Validate(DbContext, TextBoxSystemNewPassword.Text, Messages) = True Then

    '                                User.Password = AdvantageFramework.Security.LicenseKey.Encrypt(TextBoxSystemNewPassword.Text.Trim)

    '                                PasswordChanged = AdvantageFramework.Security.Database.Procedures.User.Update(SecurityDbContext, User)

    '                                If PasswordChanged = True Then

    '                                    AdvantageFramework.Security.Password.InsertNewPasswordHistory(SecurityDbContext, User)

    '                                End If

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

    '                'System.Data.SqlClient.SqlConnection.ChangePassword(_Session.ConnectionString, TextBoxSystemNewPassword.Text)

    '                'PasswordChanged = True

    '            Catch ex As Exception
    '                PasswordChanged = False
    '                ErrorMessage = ex.Message
    '            End Try

    '            If PasswordChanged Then

    '                Me.ShowMessage(MiscFN.JavascriptSafe("System password changed"))

    '                _Session.SetPassword(TextBoxSystemNewPassword.Text)

    '                Me.Vals.SetValue(Values.Type.SystemOld, TextBoxSystemNewPassword.Text)

    '                Session("ConnString") = _Session.ConnectionString

    '            Else

    '                If ErrorMessage <> "" Then

    '                    Me.ShowMessage(MiscFN.JavascriptSafe(ErrorMessage))

    '                Else

    '                    Me.ShowMessage(MiscFN.JavascriptSafe("Failed to change system password"))

    '                End If

    '            End If

    '        Else

    '            Me.ShowMessage(MiscFN.JavascriptSafe("The new passwords do not match."))

    '        End If

    '        TextBoxSystemNewPassword.Text = ""
    '        TextBoxSystemConfirmNewPassword.Text = ""

    '    Else

    '        Me.ShowMessage(MiscFN.JavascriptSafe("Please enter a new password."))

    '    End If

    'End Sub
    Private Sub ChangeAdAssistPassword()

        'objects
        Dim PasswordChanged As Boolean = False
        Dim ErrorMessage As String = ""
        Dim UserIDObjectParameter As System.Data.Entity.Core.Objects.ObjectParameter = Nothing
        Dim ReturnValue As Integer = 0

        If AdvantageFramework.Security.Encryption.EncryptPassword(TextBoxAdAssistOldPassword.Text) <> Me.Vals.GetValue(Values.Type.AdAssistOld) Then

            Me.ShowMessage(MiscFN.JavascriptSafe("Invalid old password"))
            Exit Sub

        End If

        If TextBoxAdAssistNewPassword.Text <> "" Then

            If TextBoxAdAssistNewPassword.Text = TextBoxAdAssistConfirmNewPassword.Text Then

                Try

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        If SecurityDbContext.Database.SqlQuery(Of String)("SELECT dbo.advfn_SEC_USER_AUTH(" & _Session.User.ID & ")").First Is Nothing Then

                            SecurityDbContext.Database.ExecuteSqlCommand("EXEC dbo.advsp_DELETE_SEC_USER_AUTH " & _Session.User.ID & ", -2")


                            AdvantageFramework.Security.Database.Procedures.User.ChangeUserAdAssistPassword(SecurityDbContext, True, _Session.User.ID, AdvantageFramework.Security.Encryption.EncryptPassword(TextBoxAdAssistNewPassword.Text), ReturnValue)

                        Else

                            AdvantageFramework.Security.Database.Procedures.User.ChangeUserAdAssistPassword(SecurityDbContext, False, _Session.User.ID, AdvantageFramework.Security.Encryption.EncryptPassword(TextBoxAdAssistNewPassword.Text), ReturnValue)

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

                    Me.ShowMessage(MiscFN.JavascriptSafe("AdAssist password changed"))

                    Me.Vals.SetValue(Values.Type.AdAssistOld, TextBoxAdAssistNewPassword.Text)

                Else

                    If ErrorMessage <> "" Then

                        Me.ShowMessage(MiscFN.JavascriptSafe(ErrorMessage))

                    Else

                        Me.ShowMessage(MiscFN.JavascriptSafe("Failed to change AdAssist password"))

                    End If

                End If

            Else

                Me.ShowMessage(MiscFN.JavascriptSafe("The new passwords do not match."))

            End If

            TextBoxAdAssistNewPassword.Text = ""
            TextBoxAdAssistConfirmNewPassword.Text = ""

        Else

            Me.ShowMessage(MiscFN.JavascriptSafe("Please enter a new password."))

        End If

    End Sub
    Private Sub ChangeBillingApprovalPassword()

        'objects
        Dim PasswordChanged As Boolean = False
        Dim ErrorMessage As String = ""

        If TextBoxBillingApprovalOldPassword.Text <> Me.Vals.GetValue(Values.Type.BillingApprovalOld) Then

            Me.ShowMessage(MiscFN.JavascriptSafe("Invalid old password"))
            Exit Sub

        End If
        If TextBoxBillingApprovalNewPassword.Text <> "" Then

            If TextBoxBillingApprovalNewPassword.Text = TextBoxBillingApprovalConfirmNewPassword.Text Then

                Try

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        If SecurityDbContext.Database.SqlQuery(Of Integer)("SELECT COUNT(*) FROM dbo.APPR_PASSWORD WHERE ACCT_EXEC = '" & _Session.User.EmployeeCode & "'").First > 0 Then

                            PasswordChanged = SecurityDbContext.Database.ExecuteSqlCommand("UPDATE dbo.APPR_PASSWORD SET PASSWORD_ID = '" & TextBoxBillingApprovalNewPassword.Text & "' WHERE ACCT_EXEC = '" & _Session.User.EmployeeCode & "'") > 0

                        Else

                            PasswordChanged = SecurityDbContext.Database.ExecuteSqlCommand("INSERT INTO dbo.APPR_PASSWORD([ACCT_EXEC], [PASSWORD_ID], [USER_ID], [DATE_CREATED], [INACTIVE]) " &
                                                                                        "VALUES('" & _Session.User.EmployeeCode & "', '" & TextBoxBillingApprovalNewPassword.Text & "', '" & _Session.UserCode & "', GETDATE(), NULL)") > 0

                        End If

                    End Using

                Catch ex As Exception
                    PasswordChanged = False
                    ErrorMessage = ex.Message
                End Try

                If PasswordChanged Then

                    Me.ShowMessage(MiscFN.JavascriptSafe("Billing approval password changed"))

                    Me.Vals.SetValue(Values.Type.BillingApprovalOld, TextBoxBillingApprovalNewPassword.Text)

                Else

                    If ErrorMessage <> "" Then

                        Me.ShowMessage(MiscFN.JavascriptSafe(ErrorMessage))

                    Else

                        Me.ShowMessage(MiscFN.JavascriptSafe("Failed to change billing approval password"))

                    End If

                End If

            Else

                Me.ShowMessage(MiscFN.JavascriptSafe("The new passwords do not match."))

            End If

            TextBoxBillingApprovalNewPassword.Text = ""
            TextBoxBillingApprovalConfirmNewPassword.Text = ""

        Else

            Me.ShowMessage(MiscFN.JavascriptSafe("Please enter a new password."))

        End If

    End Sub
    Private Sub ChangeQuoteApprovalPassword()

        'objects
        Dim PasswordChanged As Boolean = False
        Dim ErrorMessage As String = ""

        'If TextBoxQuoteApprovalOldPassword.Text <> Me.Vals.GetValue(Values.Type.QuoteApprovalOld) Then

        '    Me.ShowMessage(MiscFN.JavascriptSafe("Invalid old password"))
        '    Exit Sub

        'End If
        'If TextBoxBillingApprovalNewPassword.Text <> "" Then

        '    If TextBoxQuoteApprovalNewPassword.Text = TextBoxQuoteApprovalConfirmNewPassword.Text Then

        '        Try

        '            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

        '                PasswordChanged = SecurityDbContext.Database.ExecuteSqlCommand("EXEC [dbo].[advsp_quote_approval_password_create] '" & _Session.User.EmployeeCode & "', '" & TextBoxQuoteApprovalNewPassword.Text & "'") > 0

        '            End Using

        '        Catch ex As Exception
        '            PasswordChanged = False
        '            ErrorMessage = ex.Message
        '        End Try

        '        If PasswordChanged Then

        '            Me.ShowMessage(MiscFN.JavascriptSafe("Quote approval password changed"))

        '            Me.Vals.SetValue(Values.Type.QuoteApprovalOld, TextBoxQuoteApprovalNewPassword.Text)

        '        Else

        '            If ErrorMessage <> "" Then

        '                Me.ShowMessage(MiscFN.JavascriptSafe(ErrorMessage))

        '            Else

        '                Me.ShowMessage(MiscFN.JavascriptSafe("Failed to change quote approval password"))

        '            End If

        '        End If

        '    Else

        '        Me.ShowMessage(MiscFN.JavascriptSafe("The new passwords do not match."))

        '    End If

        '    TextBoxQuoteApprovalNewPassword.Text = ""
        '    TextBoxQuoteApprovalConfirmNewPassword.Text = ""

        'Else

        '    Me.ShowMessage(MiscFN.JavascriptSafe("Please enter a new password."))

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

        If TextBoxEmailOldPassword.Text <> Me.Vals.GetValue(Values.Type.EmailOld) Then

            Me.ShowMessage(MiscFN.JavascriptSafe("Invalid old password"))
            Exit Sub

        End If
        If TextBoxEmailNewPassword.Text <> "" Then

            PasswordChanged = True

        End If
        If HiddenFieldOriginalEmailAddress.Value <> TextBoxEmailAddress.Text Then

            EmailChanged = True

        End If
        If EmailChanged = True OrElse PasswordChanged = True Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, _Session.User.EmployeeCode)

                If Employee IsNot Nothing Then

                    If EmailChanged = True Then

                        If String.IsNullOrWhiteSpace(Employee.GoogleToken) = False Then

                            ReauthorizeOAuth2 = True

                        End If

                        Employee.Email = TextBoxEmailAddress.Text

                    End If

                    If PasswordChanged = True Then

                        If TextBoxEmailNewPassword.Text = TextBoxEmailConfirmNewPassword.Text Then

                            Employee.EmailPassword = AdvantageFramework.Security.Encryption.Encrypt(TextBoxEmailNewPassword.Text)

                        Else

                            PasswordChanged = False
                            ContinueSave = False
                            ErrorMessage = "The new passwords do not match."

                        End If

                    End If

                    If ContinueSave Then

                        Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                            If ReauthorizeOAuth2 Then

                                If String.IsNullOrWhiteSpace(Employee.GoogleToken) = False Then

                                    DeauthorizeGoogleCalendarSync()

                                End If

                            End If

                            If AdvantageFramework.Database.Procedures.EmployeeView.Update(DbContext, DataContext, Employee) Then

                                If PasswordChanged = True AndAlso EmailChanged = True Then

                                    Me.ShowMessage(MiscFN.JavascriptSafe("Email address and password changed"))

                                ElseIf PasswordChanged = True AndAlso EmailChanged = False Then

                                    Me.ShowMessage(MiscFN.JavascriptSafe("Email password changed"))

                                ElseIf PasswordChanged = False AndAlso EmailChanged = True Then

                                    Me.ShowMessage(MiscFN.JavascriptSafe("Email address changed"))

                                End If

                                If PasswordChanged Then

                                    Me.Vals.SetValue(Values.Type.EmailOld, TextBoxEmailNewPassword.Text)

                                End If

                                If EmailChanged Then

                                    HiddenFieldOriginalEmailAddress.Value = TextBoxEmailAddress.Text

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

                                AuthorizeGoogleCalendarSync()
                                LoadGoogleCalendarSyncData()

                            End If

                        End Using

                    End If

                    If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                        Me.ShowMessage(MiscFN.JavascriptSafe(ErrorMessage))

                    End If

                End If

            End Using

            TextBoxEmailNewPassword.Text = ""
            TextBoxEmailConfirmNewPassword.Text = ""

        Else

            Me.ShowMessage(MiscFN.JavascriptSafe("Please enter a new password and/or update your email address."))

        End If

    End Sub
    Private Sub ChangeSugarCRMPassword()

        'objects
        Dim PasswordChanged As Boolean = False
        Dim UserNameChanged As Boolean = False
        Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
        Dim ErrorMessage As String = ""

        If TextBoxSugarCRMOldPassword.Text <> Me.Vals.GetValue(Values.Type.SugarCRMOld) Then

            Me.ShowMessage(MiscFN.JavascriptSafe("Invalid old password"))
            Exit Sub

        End If
        If TextBoxSugarCRMNewPassword.Text <> "" Then

            PasswordChanged = True

        End If
        If HiddenFieldOriginalSugarCRMUserName.Value <> TextBoxSugarCRMUserName.Text Then

            UserNameChanged = True

        End If
        If UserNameChanged = True OrElse PasswordChanged = True Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, _Session.User.EmployeeCode)

                If Employee IsNot Nothing Then

                    If UserNameChanged = True Then

                        Employee.SugarCRMUserName = TextBoxSugarCRMUserName.Text

                    End If

                    If PasswordChanged Then

                        If TextBoxSugarCRMNewPassword.Text = TextBoxSugarCRMConfirmNewPassword.Text Then

                            PasswordChanged = True

                            Employee.SugarCRMPassword = TextBoxSugarCRMNewPassword.Text

                        Else

                            PasswordChanged = False

                            ErrorMessage = "The new passwords do not match."

                        End If

                    End If

                    If String.IsNullOrWhiteSpace(ErrorMessage) Then

                        Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                            If AdvantageFramework.Database.Procedures.EmployeeView.Update(DbContext, DataContext, Employee) Then

                                If PasswordChanged = True AndAlso UserNameChanged = True Then

                                    Me.ShowMessage(MiscFN.JavascriptSafe("SugarCRM user name and password changed"))

                                ElseIf PasswordChanged = True AndAlso UserNameChanged = False Then

                                    Me.ShowMessage(MiscFN.JavascriptSafe("SugarCRM password changed"))

                                ElseIf PasswordChanged = False AndAlso UserNameChanged = True Then

                                    Me.ShowMessage(MiscFN.JavascriptSafe("SugarCRM user name changed"))

                                End If

                                If PasswordChanged Then

                                    Me.Vals.SetValue(Values.Type.SugarCRMOld, TextBoxSugarCRMNewPassword.Text)

                                End If

                                If UserNameChanged Then

                                    HiddenFieldOriginalSugarCRMUserName.Value = Employee.Email

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

                        Me.ShowMessage(MiscFN.JavascriptSafe(ErrorMessage))

                    End If

                End If

            End Using

            TextBoxSugarCRMNewPassword.Text = ""
            TextBoxSugarCRMConfirmNewPassword.Text = ""

        Else

            Me.ShowMessage(MiscFN.JavascriptSafe("Please enter a new password and/or update your user name."))

        End If

    End Sub
    Private Sub ChangeProofHQPassword()

        'objects
        Dim PasswordChanged As Boolean = False
        Dim UserNameChanged As Boolean = False
        Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
        Dim ErrorMessage As String = ""

        If TextBoxProofHQOldPassword.Text <> Me.Vals.GetValue(Values.Type.ProofHQOld) Then

            Me.ShowMessage(MiscFN.JavascriptSafe("Invalid old password"))
            Exit Sub

        End If
        If TextBoxProofHQNewPassword.Text <> "" Then

            PasswordChanged = True

        End If
        If HiddenFieldOriginalProofHQUserName.Value <> TextBoxProofHQUserName.Text Then

            UserNameChanged = True

        End If
        If UserNameChanged = True OrElse PasswordChanged = True Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, _Session.User.EmployeeCode)

                If Employee IsNot Nothing Then

                    If UserNameChanged = True Then

                        Employee.ProofHQUserName = TextBoxProofHQUserName.Text

                    End If

                    If PasswordChanged Then

                        If TextBoxProofHQNewPassword.Text = TextBoxProofHQConfirmNewPassword.Text Then

                            PasswordChanged = True

                            Employee.ProofHQPassword = TextBoxProofHQNewPassword.Text

                        Else

                            PasswordChanged = False

                            ErrorMessage = "The new passwords do not match."

                        End If

                    End If

                    If String.IsNullOrWhiteSpace(ErrorMessage) Then

                        Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                            If AdvantageFramework.Database.Procedures.EmployeeView.Update(DbContext, DataContext, Employee) Then

                                If PasswordChanged = True AndAlso UserNameChanged = True Then

                                    Me.ShowMessage(MiscFN.JavascriptSafe("ProofHQ user name and password changed"))

                                ElseIf PasswordChanged = True AndAlso UserNameChanged = False Then

                                    Me.ShowMessage(MiscFN.JavascriptSafe("ProofHQ password changed"))

                                ElseIf PasswordChanged = False AndAlso UserNameChanged = True Then

                                    Me.ShowMessage(MiscFN.JavascriptSafe("ProofHQ user name changed"))

                                End If

                                If PasswordChanged Then

                                    Me.Vals.SetValue(Values.Type.ProofHQOld, TextBoxProofHQNewPassword.Text)

                                End If

                                If UserNameChanged Then

                                    HiddenFieldOriginalProofHQUserName.Value = Employee.ProofHQUserName

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

                        Me.ShowMessage(MiscFN.JavascriptSafe(ErrorMessage))

                    End If

                End If

            End Using

            TextBoxProofHQNewPassword.Text = ""
            TextBoxProofHQConfirmNewPassword.Text = ""

        Else

            Me.ShowMessage(MiscFN.JavascriptSafe("Please enter a new password and/or update your user name."))

        End If

    End Sub
    Private Sub ChangeAdobeSignaturePassword()

        'objects
        Dim PasswordChanged As Boolean = False
        Dim UserNameChanged As Boolean = False
        Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
        Dim ErrorMessage As String = ""

        If TextBoxAdobeSignatureOldPassword.Text <> Me.Vals.GetValue(Values.Type.AdobeSignatureOld) Then

            Me.ShowMessage(MiscFN.JavascriptSafe("Invalid old password"))
            Exit Sub

        End If
        If TextBoxAdobeSignatureNewPassword.Text <> "" Then

            PasswordChanged = True

        End If
        If PasswordChanged = True Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, _Session.User.EmployeeCode)

                If Employee IsNot Nothing Then

                    If PasswordChanged Then

                        If TextBoxAdobeSignatureNewPassword.Text = TextBoxAdobeSignatureConfirmNewPassword.Text Then

                            PasswordChanged = True

                            Employee.AdobeSignatureFilePassword = TextBoxAdobeSignatureNewPassword.Text

                        Else

                            PasswordChanged = False

                            ErrorMessage = "The new passwords do not match."

                        End If

                    End If

                    If String.IsNullOrWhiteSpace(ErrorMessage) Then

                        Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                            If AdvantageFramework.Database.Procedures.EmployeeView.Update(DbContext, DataContext, Employee) Then

                                Me.ShowMessage(MiscFN.JavascriptSafe("Adobe Signature password changed"))

                                If PasswordChanged Then

                                    Me.Vals.SetValue(Values.Type.AdobeSignatureOld, TextBoxAdobeSignatureNewPassword.Text)

                                End If

                            Else

                                ErrorMessage = "Failed to change Adobe Signature password"

                            End If

                        End Using

                    End If

                    If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                        Me.ShowMessage(MiscFN.JavascriptSafe(ErrorMessage))

                    End If

                End If

            End Using

            TextBoxAdobeSignatureNewPassword.Text = ""
            TextBoxAdobeSignatureConfirmNewPassword.Text = ""

        Else

            Me.ShowMessage(MiscFN.JavascriptSafe("Please enter a new password."))

        End If

    End Sub
    Private Sub ChangeVCCPassword()

        'objects
        Dim PasswordChanged As Boolean = False
        Dim UserNameChanged As Boolean = False
        Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
        Dim ErrorMessage As String = ""

        If TextBoxVCCOldPassword.Text <> Me.Vals.GetValue(Values.Type.VCCOld) Then

            Me.ShowMessage(MiscFN.JavascriptSafe("Invalid old password"))
            Exit Sub

        End If
        If TextBoxVCCNewPassword.Text <> "" Then

            PasswordChanged = True

        End If
        If HiddenFieldOriginalVCCUserName.Value <> TextBoxVCCUserName.Text Then

            UserNameChanged = True

        End If
        If UserNameChanged = True OrElse PasswordChanged = True Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, _Session.User.EmployeeCode)

                If Employee IsNot Nothing Then

                    If UserNameChanged = True Then

                        Employee.VCCUserName = TextBoxVCCUserName.Text

                    End If

                    If PasswordChanged Then

                        If TextBoxVCCNewPassword.Text = TextBoxVCCConfirmNewPassword.Text Then

                            PasswordChanged = True

                            Employee.VCCPassword = TextBoxVCCNewPassword.Text

                        Else

                            PasswordChanged = False

                            ErrorMessage = "The new passwords do not match."

                        End If

                    End If

                    If String.IsNullOrWhiteSpace(ErrorMessage) Then

                        Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                            If AdvantageFramework.Database.Procedures.EmployeeView.Update(DbContext, DataContext, Employee) Then

                                If PasswordChanged = True AndAlso UserNameChanged = True Then

                                    Me.ShowMessage(MiscFN.JavascriptSafe("VCC user name and password changed"))

                                ElseIf PasswordChanged = True AndAlso UserNameChanged = False Then

                                    Me.ShowMessage(MiscFN.JavascriptSafe("VCC password changed"))

                                ElseIf PasswordChanged = False AndAlso UserNameChanged = True Then

                                    Me.ShowMessage(MiscFN.JavascriptSafe("VCC user name changed"))

                                End If

                                If PasswordChanged Then

                                    Me.Vals.SetValue(Values.Type.VCCOld, TextBoxVCCNewPassword.Text)

                                End If

                                If UserNameChanged Then

                                    HiddenFieldOriginalVCCUserName.Value = Employee.VCCUserName

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

                        Me.ShowMessage(MiscFN.JavascriptSafe(ErrorMessage))

                    End If

                End If

            End Using

            TextBoxVCCNewPassword.Text = ""
            TextBoxVCCConfirmNewPassword.Text = ""

        Else

            Me.ShowMessage(MiscFN.JavascriptSafe("Please enter a new password and/or update your user name."))

        End If

    End Sub
    Private Sub LoadGoogleCalendarSyncData(ByVal Employee As AdvantageFramework.Database.Views.Employee)

        'objects
        Dim CalendarSyncMain As String = Nothing

        CalendarSyncMain = "Advantage Google OAuth2 is currently "

        If String.IsNullOrWhiteSpace(Employee.GoogleToken) = False Then

            RadButtonDisableGoogleCalendarSync.Visible = True
            RadButtonEnableGoogleCalendarSync.Visible = False
            CalendarSyncMain &= "enabled. "

        Else

            RadButtonDisableGoogleCalendarSync.Visible = False
            RadButtonEnableGoogleCalendarSync.Visible = True
            CalendarSyncMain &= "disabled. "

        End If

        LabelGoogleCalendarSync.Text = CalendarSyncMain

    End Sub
    Private Sub LoadGoogleCalendarSyncData()

        'objects
        Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, _Session.User.EmployeeCode)

        End Using

        If Employee IsNot Nothing Then

            LoadGoogleCalendarSyncData(Employee)

        End If

    End Sub
    Private Sub DeauthorizeGoogleCalendarSync()

        'objects
        Dim Service As AdvantageFramework.GoogleServices.Service = Nothing

        Try

            Service = AdvantageFramework.GoogleServices.Service.Initialize(AdvantageFramework.GoogleServices.Service.ServiceTypes.Calendar, _Session, _Session.User.EmployeeCode, True)

            If Service IsNot Nothing Then

                Service.Deauthorize()

            End If

        Catch ex As Exception

        End Try

    End Sub
    Private Sub AuthorizeGoogleCalendarSync()

        Me.OpenWindow("", "Google_Authentication.aspx?ServiceType=ChangePassword", 300, 500, False, True)

    End Sub
    Private Sub LoadOAuthServiceData()

        'objects
        Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, _Session.User.EmployeeCode)

        End Using

        If Employee IsNot Nothing Then

            If String.IsNullOrWhiteSpace(Employee.GoogleToken) = False Then

                DivGoogleOAuth2.Visible = True

                LoadGoogleCalendarSyncData(Employee)

            Else

                DivGoogleOAuth2.Visible = True

                LoadGoogleCalendarSyncData(Employee)

            End If

        End If

    End Sub

#Region "  Form Event Handlers "

    Private Sub Security_ChangePassword_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'objects
        Dim SelectedTab As Integer = -1
        Dim TabVisible As Boolean = False
        Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing

        Try

            If Request.QueryString("PasswordType") IsNot Nothing Then

                _PasswordType = CType(Request.QueryString("PasswordType"), Integer)

            End If

        Catch ex As Exception
            _PasswordType = 0
        End Try

        Try

            If Request.QueryString("SelectedTab") IsNot Nothing Then

                SelectedTab = CType(Request.QueryString("SelectedTab"), Integer)

            End If

        Catch ex As Exception
            SelectedTab = -1
        End Try

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            For TabIndex = 0 To RadTabStripChangePassword.Tabs.Count - 1

                TabVisible = False

                If _PasswordType = PasswordType.All Then

                    TabVisible = True

                Else

                    Select Case _PasswordType

                        'Case PasswordType.System

                        '    TabVisible = (TabIndex = 0)

                        Case PasswordType.AdAssist

                            TabVisible = (TabIndex = 0)

                        Case PasswordType.BillingApproval

                            TabVisible = (TabIndex = 1)

                        'Case PasswordType.QuoteApproval

                        '    TabVisible = (TabIndex = 3)

                        Case PasswordType.Email

                            TabVisible = (TabIndex = 2)

                        Case PasswordType.SugarCRM

                            TabVisible = (TabIndex = 3)

                        Case PasswordType.ProofHQ

                            TabVisible = (TabIndex = 4)

                        Case PasswordType.AdobeSignature

                            TabVisible = (TabIndex = 5)

                        Case PasswordType.VCC

                            TabVisible = (TabIndex = 6)

                    End Select

                End If

                RadTabStripChangePassword.Tabs(TabIndex).Visible = TabVisible

            Next

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                If Agency.SMTPAuthenticationMethodType = AdvantageFramework.Email.SmtpAuthenticationMethods.OAuth2 Then

                    DivEmailNewPassword.Visible = False
                    DivEmailOldPassword.Visible = False
                    DivEmailConfirmNewPassword.Visible = False

                End If

            End Using

            If _Session.UseWindowsAuthentication Then

                RadTabStripChangePassword.Tabs(0).Visible = False
                RadTabStripChangePassword.SelectedIndex = 1

            End If

            If SelectedTab >= 0 Then

                RadTabStripChangePassword.SelectedIndex = SelectedTab
                RadMultiPageChangePassword.SelectedIndex = SelectedTab

            End If

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Dim UserClass As AdvantageFramework.Security.Classes.User

                UserClass = Nothing
                UserClass = New AdvantageFramework.Security.Classes.User(AdvantageFramework.Security.Database.Procedures.User.LoadByUserID(SecurityDbContext, _Session.User.ID))

                RadTabStripChangePassword.Tabs(0).Visible = AdvantageFramework.Security.DoesUserHaveAccessToApplication(SecurityDbContext, UserClass,
                                                                                                                        AdvantageFramework.Security.Application.Adassist)

                If RadTabStripChangePassword.Tabs(1).Visible AndAlso
                        AdvantageFramework.Security.DoesUserHaveAccessToModule(SecurityDbContext, _Session.Application, AdvantageFramework.Security.Modules.Billing_BillingApproval.ToString, _Session.User.ID) Then

                    RadTabStripChangePassword.Tabs(1).Visible = True

                Else

                    RadTabStripChangePassword.Tabs(1).Visible = False

                End If

                'If RadTabStripChangePassword.Tabs(3).Visible AndAlso
                '        AdvantageFramework.Security.DoesUserHaveAccessToModule(SecurityDbContext, _Session.Application, AdvantageFramework.Security.Modules.ProjectManagement_QuoteApproval.ToString, _Session.User.ID) Then

                '    RadTabStripChangePassword.Tabs(3).Visible = True

                'Else

                '    RadTabStripChangePassword.Tabs(3).Visible = False

                'End If

            End Using

            ChangeTabs()

        End If

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub RadToolBarChangePassword_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarChangePassword.ButtonClick

        'objects
        Dim PasswordChanged As Boolean = False
        Dim ErrorMessage As String = ""

        Select Case e.Item.Value

            Case RadToolBarButtonSave.Value

                Select Case RadTabStripChangePassword.SelectedIndex

                    'Case 0

                        'ChangeSystemPassword()

                    Case 0

                        ChangeAdAssistPassword()

                    Case 1

                        ChangeBillingApprovalPassword()

                    'Case 3

                    '    ChangeQuoteApprovalPassword()

                    Case 2

                        ChangeEmailPassword()

                    Case 3

                        ChangeSugarCRMPassword()

                    Case 4

                        ChangeProofHQPassword()

                    Case 5

                        ChangeAdobeSignaturePassword()

                    Case 6
                        ChangeVCCPassword()

                End Select

            Case RadToolBarButtonClose.Value

                Me.CloseThisWindow()

        End Select

    End Sub
    Private Sub RadTabStripChangePassword_TabClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadTabStripEventArgs) Handles RadTabStripChangePassword.TabClick

        ChangeTabs()

    End Sub
    Private Sub RadButtonDisableGoogleCalendarSync_Click(sender As Object, e As EventArgs) Handles RadButtonDisableGoogleCalendarSync.Click

        DeauthorizeGoogleCalendarSync()

        LoadOAuthServiceData()

    End Sub
    Private Sub RadButtonEnableGoogleCalendarSync_Click(sender As Object, e As EventArgs) Handles RadButtonEnableGoogleCalendarSync.Click

        AuthorizeGoogleCalendarSync()

        LoadOAuthServiceData()

    End Sub

#End Region

#End Region

    <Serializable()>
    Public Class Values

        Public Enum Type

            SystemOld
            AdAssistOld
            BillingApprovalOld
            QuoteApprovalOld
            EmailOld
            SugarCRMOld
            ProofHQOld
            AdobeSignatureOld
            VCCOld

        End Enum

        Public Property SystemOldPassword As String = String.Empty
        Public Property AdAssistOldPassword As String = String.Empty
        Public Property BillingApprovalOldPassword As String = String.Empty
        Public Property QuoteApprovalOldPassword As String = String.Empty
        Public Property EmailOldPassword As String = String.Empty
        Public Property SugarCRMOldPassword As String = String.Empty
        Public Property ProofHQOldPassword As String = String.Empty
        Public Property AdobeSignatureOldPassword As String = String.Empty
        Public Property VCCOldPassword As String = String.Empty

        Public Sub SetValue(ByVal ValueType As Type, ByVal Value As String)

            Select Case ValueType
                Case Type.SystemOld

                    Me.SystemOldPassword = Value

                Case Type.AdAssistOld

                    Me.AdAssistOldPassword = Value

                Case Type.BillingApprovalOld

                    Me.BillingApprovalOldPassword = Value

                Case Type.QuoteApprovalOld

                    Me.QuoteApprovalOldPassword = Value

                Case Type.SugarCRMOld

                    Me.SugarCRMOldPassword = Value

                Case Type.ProofHQOld

                    Me.ProofHQOldPassword = Value

                Case Type.AdobeSignatureOld

                    Me.AdobeSignatureOldPassword = Value

                Case Type.VCCOld

                    Me.VCCOldPassword = Value

            End Select

        End Sub
        Public Function GetValue(ByVal ValueType As Type) As String

            Select Case ValueType
                Case Type.SystemOld

                    Return Me.SystemOldPassword

                Case Type.AdAssistOld

                    Return Me.AdAssistOldPassword

                Case Type.BillingApprovalOld

                    Return Me.BillingApprovalOldPassword

                Case Type.QuoteApprovalOld

                    Return Me.QuoteApprovalOldPassword

                Case Type.SugarCRMOld

                    Return Me.SugarCRMOldPassword

                Case Type.ProofHQOld

                    Return Me.ProofHQOldPassword

                Case Type.AdobeSignatureOld

                    Return Me.AdobeSignatureOldPassword

                Case Type.VCCOld

                    Return Me.VCCOldPassword

            End Select

        End Function

        Sub New()

        End Sub

    End Class

End Class
