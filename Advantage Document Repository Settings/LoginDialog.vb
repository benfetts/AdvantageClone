Public Class LoginDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _ConnectionDatabaseProfile As Database.ConnectionDatabaseProfile = Nothing

#End Region

#Region " Properties "

    Private ReadOnly Property ConnectionDatabaseProfile As Database.ConnectionDatabaseProfile
        Get
            ConnectionDatabaseProfile = _ConnectionDatabaseProfile
        End Get
    End Property

#End Region

#Region " Methods "

    Private Sub New(ServerName As String, DatabaseName As String, UserName As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        TextBoxForm_Server.Text = ServerName
        TextBoxForm_Database.Text = DatabaseName
        TextBoxForm_UserName.Text = UserName

    End Sub

#Region "  Show Form Methods "

    Public Shared Function ShowFormDialog(ServerName As String, DatabaseName As String, UserName As String, ByRef ConnectionDatabaseProfile As Database.ConnectionDatabaseProfile) As System.Windows.Forms.DialogResult

        'objects
        Dim LoginDialog As LoginDialog = Nothing

        LoginDialog = New LoginDialog(ServerName, DatabaseName, UserName)

        ShowFormDialog = LoginDialog.ShowDialog()

        If ShowFormDialog = DialogResult.OK Then

            ConnectionDatabaseProfile = LoginDialog.ConnectionDatabaseProfile

        End If

    End Function

#End Region

#Region "  Form Event Handlers "

    Private Sub LoginDialog_Load(sender As Object, e As System.EventArgs) Handles Me.Load



    End Sub
    Private Sub LoginDialog_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown



    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub ButtonForm_OK_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_OK.Click

        'objects
        Dim ErrorMessage As String = String.Empty
        Dim IsValid As Boolean = True
        Dim ConnectionString As String = String.Empty

        ErrorMessage = "Please enter the following fields: " & System.Environment.NewLine & System.Environment.NewLine

        If String.IsNullOrWhiteSpace(TextBoxForm_Server.Text) Then

            ErrorMessage &= "Server" & System.Environment.NewLine
            IsValid = False

        End If

        If String.IsNullOrWhiteSpace(TextBoxForm_Database.Text) Then

            ErrorMessage &= "Database" & System.Environment.NewLine
            IsValid = False

        End If

        If String.IsNullOrWhiteSpace(TextBoxForm_UserName.Text) Then

            ErrorMessage &= "User Name" & System.Environment.NewLine
            IsValid = False

        End If

        If String.IsNullOrWhiteSpace(TextBoxForm_Password.Text) Then

            ErrorMessage &= "Password" & System.Environment.NewLine
            IsValid = False

        End If

        If IsValid Then

            ConnectionString = Database.CreateConnectionString(TextBoxForm_Server.Text, TextBoxForm_Database.Text, False, TextBoxForm_UserName.Text, TextBoxForm_Password.Text, "AdavantageSES")

            If Database.IsValidConnectionString(ConnectionString) Then

                _ConnectionDatabaseProfile = New Database.ConnectionDatabaseProfile

                _ConnectionDatabaseProfile.ServerName = TextBoxForm_Server.Text
                _ConnectionDatabaseProfile.DatabaseName = TextBoxForm_Database.Text
                _ConnectionDatabaseProfile.UserName = TextBoxForm_UserName.Text
                _ConnectionDatabaseProfile.Password = TextBoxForm_Password.Text

                Me.DialogResult = DialogResult.OK
                Me.Close()

            Else

                System.Windows.Forms.MessageBox.Show("Failed to create a valid connection.  Please check your inputs.", "Invalid Connection", System.Windows.Forms.MessageBoxButtons.OK)

            End If

        Else

            System.Windows.Forms.MessageBox.Show(ErrorMessage, "Please Fix", System.Windows.Forms.MessageBoxButtons.OK)

        End If

    End Sub
    Private Sub ButtonForm_Cancel_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Cancel.Click

        Me.DialogResult = DialogResult.Cancel
        Me.Close()

    End Sub

#End Region

#End Region

End Class
