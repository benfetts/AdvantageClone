Partial Public Class SignInPage
    Inherits BaseWizardPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

    Public Property ServerName As String
        Get
            ServerName = TextEditForm_Server.Text
        End Get
        Set(value As String)
            TextEditForm_Server.Text = value
        End Set
    End Property
    Public Property Database As String
        Get
            Database = TextEditForm_Database.Text
        End Get
        Set(value As String)
            TextEditForm_Database.Text = value
        End Set
    End Property
    Public Property UserName As String
        Get
            UserName = TextEditForm_UserName.Text
        End Get
        Set(value As String)
            TextEditForm_UserName.Text = value
        End Set
    End Property
    Public Property Password As String
        Get
            Password = TextEditForm_Password.Text
        End Get
        Set(value As String)
            TextEditForm_Password.Text = value
        End Set
    End Property

#End Region

#Region " Methods "

    Public Sub New()

        InitializeComponent()

    End Sub
    Public Sub SignIn()

        SimpleButtonForm_SignIn.PerformClick()

    End Sub
    Private Function VersionCheck(SecurityDbContext As AdvantageFramework.Security.Database.DbContext, ByRef ErrorMessage As String) As Boolean

        'objects
        Dim VersionCheckSuccessful As Boolean = False
        Dim DatabaseVersion As String = String.Empty

        DatabaseVersion = SecurityDbContext.Database.SqlQuery(Of String)("SELECT VERSION_ID FROM dbo.ADVAN_UPDATE").FirstOrDefault()

        If AdvantageFramework.StringUtilities.RemoveAllNonNumeric(DatabaseVersion) >= AdvantageFramework.StringUtilities.RemoveAllNonNumeric("v6.70.06.00") Then

            VersionCheckSuccessful = True

        Else

            ErrorMessage = "In order to upgrade to 6.70.07.00, you instance needs to be updated to at least v6.70.06.00."

        End If

        VersionCheck = VersionCheckSuccessful

    End Function

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "



#End Region

#Region "  Control Event Handlers "

    Private Sub SimpleButtonForm_SignIn_Click(sender As Object, e As System.EventArgs) Handles SimpleButtonForm_SignIn.Click

        Dim HasRequiredInput As Boolean = True
        Dim ConnectionString As String = String.Empty
        Dim ErrorMessage As String = String.Empty
        Dim IsSQLAdmin As Boolean = False
        Dim RestoreFailed As Boolean = False
        Dim OverlaySplayScreenHandle As DevExpress.XtraSplashScreen.IOverlaySplashScreenHandle = Nothing
        Dim SQLUserSelect As String = String.Empty
        'Dim ValidWVURL As Boolean = False
        Dim WebvantageURL As String = String.Empty
        Dim HasAUserWithEmployeeCode As Boolean = False
        Dim VersionCheckSuccessful As Boolean = False

        DxErrorProvider1.ClearErrors()

        If CType(Me.WizardViewModel, WizardViewModel).HandsFreeMode Then

            If String.IsNullOrWhiteSpace(TextEditForm_Server.Text) Then

                CType(Me.WizardViewModel, WizardViewModel).AddToErrors("SignIn", "Server is required.")
                HasRequiredInput = False

            End If

            If String.IsNullOrWhiteSpace(TextEditForm_Database.Text) Then

                CType(Me.WizardViewModel, WizardViewModel).AddToErrors("SignIn", "Database is required.")
                HasRequiredInput = False

            End If

            If String.IsNullOrWhiteSpace(TextEditForm_UserName.Text) Then

                CType(Me.WizardViewModel, WizardViewModel).AddToErrors("SignIn", "User Name is required.")
                HasRequiredInput = False

            End If

            If String.IsNullOrWhiteSpace(TextEditForm_Password.Text) Then

                CType(Me.WizardViewModel, WizardViewModel).AddToErrors("SignIn", "Password is required.")
                HasRequiredInput = False

            End If

        Else

            If String.IsNullOrWhiteSpace(TextEditForm_Server.Text) Then

                DxErrorProvider1.SetError(TextEditForm_Server, "Server is required.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical)
                HasRequiredInput = False

            End If

            If String.IsNullOrWhiteSpace(TextEditForm_Database.Text) Then

                DxErrorProvider1.SetError(TextEditForm_Database, "Database is required.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical)
                HasRequiredInput = False

            End If

            If String.IsNullOrWhiteSpace(TextEditForm_UserName.Text) Then

                DxErrorProvider1.SetError(TextEditForm_UserName, "User Name is required.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical)
                HasRequiredInput = False

            End If

            If String.IsNullOrWhiteSpace(TextEditForm_Password.Text) Then

                DxErrorProvider1.SetError(TextEditForm_Password, "Password is required.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical)
                HasRequiredInput = False

            End If

        End If

        If HasRequiredInput Then

            ConnectionString = AdvantageFramework.Database.CreateConnectionString(TextEditForm_Server.Text, TextEditForm_Database.Text, False, TextEditForm_UserName.Text, TextEditForm_Password.Text)

            If AdvantageFramework.Database.TestConnectionString(ConnectionString, ErrorMessage) = False Then

                If CType(Me.WizardViewModel, WizardViewModel).HandsFreeMode Then

                    If String.IsNullOrWhiteSpace(ErrorMessage) Then

                        CType(Me.WizardViewModel, WizardViewModel).AddToErrors("SignIn", "Failed to connect to database. Please enter valid a connection.")

                    Else

                        CType(Me.WizardViewModel, WizardViewModel).AddToErrors("SignIn", ErrorMessage & System.Environment.NewLine & System.Environment.NewLine & "Failed to connect to database. Please enter valid a connection.")

                    End If

                Else

                    If String.IsNullOrWhiteSpace(ErrorMessage) Then

                        DevExpress.XtraEditors.XtraMessageBox.Show("Failed to connect to database. Please enter valid a connection.")

                    Else

                        DevExpress.XtraEditors.XtraMessageBox.Show(ErrorMessage & System.Environment.NewLine & System.Environment.NewLine & "Failed to connect to database. Please enter valid a connection.")

                    End If

                End If

            Else

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(ConnectionString, "")

                    ErrorMessage = String.Empty

                    Try

                        IsSQLAdmin = (SecurityDbContext.Database.SqlQuery(Of Integer)("SELECT ISNULL(IS_SRVROLEMEMBER('sysadmin'), 0)").FirstOrDefault <> 0)

                    Catch ex As Exception
                        IsSQLAdmin = False
                    End Try

                    If IsSQLAdmin = False Then

                        ErrorMessage = "You must log in with a user that is a sysadmin."

                    End If

                    Try

                        HasAUserWithEmployeeCode = (SecurityDbContext.Database.SqlQuery(Of Integer)("SELECT COUNT(*) FROM dbo.SEC_USER WHERE ISNULL(EMP_CODE, '') <> ''").FirstOrDefault > 0)

                    Catch ex As Exception
                        HasAUserWithEmployeeCode = False
                    End Try

                    If HasAUserWithEmployeeCode = False Then

                        If String.IsNullOrWhiteSpace(ErrorMessage) Then

                            ErrorMessage = "The instance you selected does not have a valid user with an attached employee."

                        Else

                            ErrorMessage &= System.Environment.NewLine & "The instance you selected does not have a valid user with an attached employee."

                        End If

                    End If

                    VersionCheckSuccessful = VersionCheck(SecurityDbContext, ErrorMessage)

                    If IsSQLAdmin = False OrElse HasAUserWithEmployeeCode = False OrElse VersionCheckSuccessful = False Then

                        If CType(Me.WizardViewModel, WizardViewModel).HandsFreeMode Then

                            CType(Me.WizardViewModel, WizardViewModel).AddToErrors("SignIn", ErrorMessage)

                        Else

                            DevExpress.XtraEditors.XtraMessageBox.Show(ErrorMessage)

                        End If

                    End If

                End Using

            End If

        End If

        If IsSQLAdmin AndAlso HasAUserWithEmployeeCode AndAlso VersionCheckSuccessful Then

            Me.WizardViewModel.WizardInputs.ServerName = TextEditForm_Server.Text
            Me.WizardViewModel.WizardInputs.Database = TextEditForm_Database.Text
            Me.WizardViewModel.WizardInputs.UserName = TextEditForm_UserName.Text
            Me.WizardViewModel.WizardInputs.Password = TextEditForm_Password.Text

            Try

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(ConnectionString, "")

                    WebvantageURL = SecurityDbContext.Database.SqlQuery(Of String)("SELECT WEBVANTAGE_URL FROM dbo.AGENCY").FirstOrDefault

                    Me.WizardViewModel.WizardInputs.DatabaseHasAlreadyBeenConverted = SecurityDbContext.Database.SqlQuery(Of Integer)("SELECT ISNULL(AGY_SETTINGS_VALUE, 0) FROM dbo.AGY_SETTINGS WHERE AGY_SETTINGS_CODE = 'AUW_6700700'").FirstOrDefault()

                End Using

            Catch ex As Exception
                Me.WizardViewModel.WizardInputs.DatabaseHasAlreadyBeenConverted = False
            End Try

            If String.IsNullOrWhiteSpace(CType(Me.WizardViewModel.View.Documents(2).Control, WebvantageURLPage).WebvantageURL) Then

                CType(Me.WizardViewModel.View.Documents(2).Control, WebvantageURLPage).WebvantageURL = WebvantageURL

            End If

            If Me.WizardViewModel.WizardInputs.DatabaseHasAlreadyBeenConverted Then

                If CType(Me.WizardViewModel, WizardViewModel).HandsFreeMode Then

                    CType(Me.WizardViewModel, WizardViewModel).AddToErrors("SignIn", "Conversion is already complete on this database.")

                Else

                    DevExpress.XtraEditors.XtraMessageBox.Show("Conversion is already complete on this database.")

                End If

                CType(Me.WizardViewModel.View.Documents(9).Control, ConversionPage).SetupSkipConversion()
                CType(Me.WizardViewModel.Pages(9), ConversionPageViewModel).SetIsComplete(True)

                CType(PageViewModel, SignInPageViewModel).SetIsComplete(True)

                Me.WizardViewModel.GoToPage(10)

            Else

                CType(PageViewModel, SignInPageViewModel).SetIsComplete(True)

                Me.WizardViewModel.PageCompleted()

            End If

        Else

            Me.WizardViewModel.WizardInputs.ServerName = TextEditForm_Server.Text
            Me.WizardViewModel.WizardInputs.Database = TextEditForm_Database.Text
            Me.WizardViewModel.WizardInputs.UserName = TextEditForm_UserName.Text
            Me.WizardViewModel.WizardInputs.Password = TextEditForm_Password.Text

            If CType(Me.WizardViewModel, WizardViewModel).HandsFreeMode Then

                CType(Me.WizardViewModel.View.Documents(9).Control, ConversionPage).SetupSkipConversion()
                CType(Me.WizardViewModel.Pages(9), ConversionPageViewModel).SetIsComplete(True)

                CType(PageViewModel, SignInPageViewModel).SetIsComplete(True)

                Me.WizardViewModel.GoToPage(10)

            End If

        End If

    End Sub

#End Region

#End Region

End Class
