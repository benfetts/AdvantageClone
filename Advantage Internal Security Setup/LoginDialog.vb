Public Class LoginDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Protected _Session As AdvantageFramework.Security.Session = Nothing
    Protected _DbContext As AdvantageFramework.Database.DbContext = Nothing
    Protected _Application As AdvantageFramework.Security.Application = AdvantageFramework.Security.Application.Advantage
    Protected Friend _SuperValidator As DevComponents.DotNetBar.Validator.SuperValidator = Nothing
    Protected Friend _ErrorProvider As System.Windows.Forms.ErrorProvider = Nothing
    Protected Friend _Highlighter As DevComponents.DotNetBar.Validator.Highlighter = Nothing

#End Region

#Region " Properties "

    Private ReadOnly Property Session As AdvantageFramework.Security.Session
        Get
            Session = _Session
        End Get
    End Property

#End Region

#Region " Methods "

    Private Sub New(ByVal ServerName As String, ByVal DatabaseName As String, ByVal UseWindowsAuthentication As Boolean, ByVal UserName As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        TextBoxForm_Server.Text = ServerName
        TextBoxForm_Database.Text = DatabaseName
        TextBoxForm_UserName.Text = UserName
        CheckBoxForm_UseWindowsAuthentication.Checked = UseWindowsAuthentication

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
    Friend Shared Function Login(ByVal Application As AdvantageFramework.Security.Application, ByRef DbContext As AdvantageFramework.Database.DbContext,
                          ByRef Session As AdvantageFramework.Security.Session, ByVal ServerName As String,
                          ByVal DatabaseName As String, ByVal UseWindowsAuthentication As Boolean, ByVal UserName As String,
                          ByVal Password As String, ByRef ErrorMessage As String) As Boolean

        'objects
        Dim ConnectionString As String = ""
        Dim SecurityObjectContext As AdvantageFramework.Security.Database.DbContext = Nothing
        Dim ApplicationEntity As AdvantageFramework.Security.Database.Entities.Application = Nothing
        Dim User As AdvantageFramework.Security.Database.Entities.User = Nothing
        Dim UserApplicationAccess As AdvantageFramework.Security.Database.Entities.UserApplicationAccess = Nothing
        Dim LoginSuccessful As Boolean = False

        'If ServerName = "" AndAlso DatabaseName <> "" Then

        '    Try

        '        ServerName = AdvantageFramework.Database.LoadSimpleDatabaseProfileList.Single(Function(SimpleDatabaseProfile) SimpleDatabaseProfile.DatabaseName = DatabaseName).ServerName

        '    Catch ex As Exception
        '        ServerName = ""
        '    End Try

        'End If

        'If AdvantageFramework.Database.ValidateServerAndDatabase(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, Application.ToString, True, ErrorMessage) Then

        '    ConnectionString = AdvantageFramework.Database.CreateConnectionString(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, Application.ToString)

        '    If AdvantageFramework.Database.TestConnectionString(ConnectionString, ErrorMessage) Then

        '        If UseWindowsAuthentication Then

        '            If UserName.Contains("\") Then

        '                UserName = UserName.Substring(UserName.IndexOf("\") + 1)

        '            End If

        '        End If

        '        Try

        '            SecurityObjectContext = New AdvantageFramework.Security.Database.DbContext(ConnectionString, UserName)

        '        Catch ex As Exception
        '            ErrorMessage = ex.Message
        '            SecurityObjectContext = Nothing
        '        End Try

        '        If SecurityObjectContext IsNot Nothing Then

        '            If SecurityObjectContext.ExecuteStoreQuery(Of Integer)("SELECT ISNULL(IS_MEMBER('db_datareader'), 0)").First = 0 Then

        '                ErrorMessage = "User trying to login is not apart of the database role db_datareader"
        '                DbContext = Nothing

        '            ElseIf SecurityObjectContext.DatabaseSQL(Of Integer)("SELECT ISNULL(IS_MEMBER('db_datawriter'), 0)").First = 0 Then

        '                ErrorMessage = "User trying to login is not apart of the database role db_datawriter"
        '                DbContext = Nothing

        '            Else

        '                LoginSuccessful = True

        '                Session = New AdvantageFramework.Security.Session(Application, ConnectionString, UserName, 0, ConnectionString)

        '            End If

        '        Else

        '            ErrorMessage = "Please verify that you are connecting to the correct server and database and that your login username and password is correct."

        '        End If

        '    End If

        'End If

        Login = LoginSuccessful

    End Function

#Region "  Show Form Methods "

    Public Shared Function ShowFormDialog(ByRef Session As AdvantageFramework.Security.Session, ByVal ServerName As String, ByVal DatabaseName As String,
                                          ByVal UseWindowsAuthentication As Boolean, ByVal UserName As String) As System.Windows.Forms.DialogResult

        'objects
        Dim LoginDialog As LoginDialog = Nothing

        LoginDialog = New LoginDialog(ServerName, DatabaseName, UseWindowsAuthentication, UserName)

        ShowFormDialog = LoginDialog.ShowDialog()

        Session = LoginDialog.Session

    End Function

#End Region

#Region "  Form Event Handlers "

    Private Sub LoginDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load



    End Sub
    Private Sub LoginDialog_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

        Me.Activate()

        If AdvantageFramework.Database.LoadSimpleDatabaseProfileList.Any Then

            TextBoxForm_Server.Enabled = False
            TextBoxForm_Server.UseSystemPasswordChar = True
            TextBoxForm_Server.Visible = False
            LabelForm_Server.Visible = False

            If TextBoxForm_Database.Text <> "" Then

                Try

                    TextBoxForm_Server.Text = AdvantageFramework.Database.LoadSimpleDatabaseProfileList.Single(Function(SimpleDatabaseProfile) SimpleDatabaseProfile.DatabaseName = TextBoxForm_Database.Text).ServerName

                Catch ex As Exception
                    TextBoxForm_Server.Text = ""
                End Try

            End If

        End If

        If TextBoxForm_Server.Text = "" Then

            TextBoxForm_Server.Focus()

        ElseIf TextBoxForm_Database.Text = "" Then

            TextBoxForm_Database.Focus()

        ElseIf TextBoxForm_UserName.Text = "" Then

            TextBoxForm_UserName.Focus()

        ElseIf TextBoxForm_Password.Text = "" Then

            TextBoxForm_Password.Focus()

        End If

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

        'objects
        Dim ConnectionString As String = ""
        Dim SecurityObjectContext As AdvantageFramework.Security.Database.DbContext = Nothing
        Dim Application As AdvantageFramework.Security.Database.Entities.Application = Nothing
        Dim User As AdvantageFramework.Security.Database.Entities.User = Nothing
        Dim UserApplicationAccess As AdvantageFramework.Security.Database.Entities.UserApplicationAccess = Nothing
        Dim LoginSuccessful As Boolean = False
        Dim ErrorMessage As String = ""

        _SuperValidator.ClearFailedValidations()

        _SuperValidator.Highlighter.SetHighlightColor(TextBoxForm_Server, DevComponents.DotNetBar.Validator.eHighlightColor.None)
        _SuperValidator.ErrorProvider.SetError(TextBoxForm_Server, "")

        _SuperValidator.Highlighter.SetHighlightColor(TextBoxForm_Database, DevComponents.DotNetBar.Validator.eHighlightColor.None)
        _SuperValidator.ErrorProvider.SetError(TextBoxForm_Database, "")

        _SuperValidator.Highlighter.SetHighlightColor(TextBoxForm_UserName, DevComponents.DotNetBar.Validator.eHighlightColor.None)
        _SuperValidator.ErrorProvider.SetError(TextBoxForm_UserName, "")

        'If Login(_Application, _ObjectContext, _Session, TextBoxForm_Server.Text, TextBoxForm_Database.Text, CheckBoxForm_UseWindowsAuthentication.Checked, TextBoxForm_UserName.Text, TextBoxForm_Password.Text, ErrorMessage) Then

        '    Me.DialogResult = System.Windows.Forms.DialogResult.OK
        '    Me.Close()

        'Else

        '    If ErrorMessage = "Access denied" OrElse ErrorMessage.Contains("Login failed") Then

        '        _SuperValidator.ErrorProvider.SetIconAlignment(TextBoxForm_UserName, Windows.Forms.ErrorIconAlignment.MiddleLeft)

        '        _SuperValidator.ErrorProvider.SetError(TextBoxForm_UserName, ErrorMessage)

        '        _SuperValidator.Highlighter.SetHighlightColor(TextBoxForm_UserName, DevComponents.DotNetBar.Validator.eHighlightColor.Red)

        '    ElseIf ErrorMessage = "Please verify that you are connecting to the correct server and database and that your login username and password is correct." Then

        '        _SuperValidator.ErrorProvider.SetIconAlignment(TextBoxForm_Server, Windows.Forms.ErrorIconAlignment.MiddleLeft)
        '        _SuperValidator.ErrorProvider.SetIconAlignment(TextBoxForm_Database, Windows.Forms.ErrorIconAlignment.MiddleLeft)

        '        _SuperValidator.ErrorProvider.SetError(TextBoxForm_Server, "Please verify that you are connecting to the correct server and database and that your login username and password is correct.")
        '        _SuperValidator.ErrorProvider.SetError(TextBoxForm_Database, "Please verify that you are connecting to the correct server and database and that your login username and password is correct.")

        '        _SuperValidator.Highlighter.SetHighlightColor(TextBoxForm_Server, DevComponents.DotNetBar.Validator.eHighlightColor.Red)
        '        _SuperValidator.Highlighter.SetHighlightColor(TextBoxForm_Database, DevComponents.DotNetBar.Validator.eHighlightColor.Red)

        '    Else

        '        _SuperValidator.ErrorProvider.SetIconAlignment(TextBoxForm_Server, Windows.Forms.ErrorIconAlignment.MiddleLeft)
        '        _SuperValidator.ErrorProvider.SetIconAlignment(TextBoxForm_Database, Windows.Forms.ErrorIconAlignment.MiddleLeft)

        '        If ErrorMessage.Contains("server") Then

        '            _SuperValidator.ErrorProvider.SetError(TextBoxForm_Server, ErrorMessage)
        '            _SuperValidator.Highlighter.SetHighlightColor(TextBoxForm_Server, DevComponents.DotNetBar.Validator.eHighlightColor.Red)

        '        Else

        '            _SuperValidator.ErrorProvider.SetError(TextBoxForm_Database, ErrorMessage)
        '            _SuperValidator.Highlighter.SetHighlightColor(TextBoxForm_Database, DevComponents.DotNetBar.Validator.eHighlightColor.Red)

        '        End If

        '    End If

        'End If

    End Sub
    Private Sub ButtonForm_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub
    Private Sub CheckBoxForm_UseWindowsAuthentication_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBoxForm_UseWindowsAuthentication.CheckedChanged

        TextBoxForm_UserName.Enabled = Not CheckBoxForm_UseWindowsAuthentication.Checked
        TextBoxForm_Password.Enabled = Not CheckBoxForm_UseWindowsAuthentication.Checked

        TextBoxForm_UserName.Text = IIf(CheckBoxForm_UseWindowsAuthentication.Checked, My.User.Name, "")
        TextBoxForm_Password.Text = ""

    End Sub

#End Region

#End Region

End Class

