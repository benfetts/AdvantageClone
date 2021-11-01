Namespace WinForm.Presentation

    Public Class LoginDialog

#Region " Constants "

        Private Const _ConstConnectionStringBaseSQLAuthentication As String = "Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}"

#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _SqlConnection As SqlClient.SqlConnection = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property SqlConnection As SqlClient.SqlConnection
            Get
                SqlConnection = _SqlConnection
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ServerName As String, DatabaseName As String)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

            TextBoxForm_Server.Text = ServerName
            TextBoxForm_Database.Text = DatabaseName

        End Sub
        Private Function Login(Server As String, Database As String, UserName As String, Password As String) As Boolean

            'objects
            Dim IsLoggedIn As Boolean = False
            Dim ConnectionString As String = ""

            If String.IsNullOrWhiteSpace(Server) OrElse String.IsNullOrWhiteSpace(Database) OrElse String.IsNullOrWhiteSpace(UserName) OrElse String.IsNullOrWhiteSpace(Password) Then

                MsgBox("Please enter Server, Database, User ID and Password.",, "")

            Else

                ConnectionString = String.Format(_ConstConnectionStringBaseSQLAuthentication, Server, Database, UserName, Password)

                Try

                    _SqlConnection = New SqlClient.SqlConnection(ConnectionString)
                    _SqlConnection.Open()

                    IsLoggedIn = True

                Catch ex As Exception
                    MsgBox(ex.Message,, "")
                    IsLoggedIn = False
                End Try
            End If

            Login = IsLoggedIn

        End Function

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ServerName As String, DatabaseName As String, ByRef SqlConnection As SqlClient.SqlConnection) As System.Windows.Forms.DialogResult

            'objects
            Dim LoginDialog As WinForm.Presentation.LoginDialog = Nothing

            LoginDialog = New WinForm.Presentation.LoginDialog(ServerName, DatabaseName)

            ShowFormDialog = LoginDialog.ShowDialog()

            SqlConnection = LoginDialog.SqlConnection

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub LoginDialog_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            Me.Activate()

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

            If Login(TextBoxForm_Server.Text, TextBoxForm_Database.Text, TextBoxForm_UserName.Text, TextBoxForm_Password.Text) Then

                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub

#End Region

#End Region

    End Class

End Namespace
