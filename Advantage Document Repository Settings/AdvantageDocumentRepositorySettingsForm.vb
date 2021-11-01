Public Class AdvantageDocumentRepositorySettingsForm

#Region " Constants "

    Public Const MB As Long = 1048576
    Public Const GB As Long = 1073741824

#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _ConnectionDatabaseProfile As Database.ConnectionDatabaseProfile = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Function LoadStartUpInformation(ByRef CommandLineArgs As System.Collections.ObjectModel.ReadOnlyCollection(Of String)) As Boolean

        'objects
        Dim LoggedIn As Boolean = False
        Dim ServerName As String = String.Empty
        Dim DatabaseName As String = String.Empty
        Dim UserName As String = String.Empty
        Dim Password As String = String.Empty
        Dim ConnectionString As String = String.Empty

        For Each CommandLine In CommandLineArgs

            If CommandLine.StartsWith("-s") Then

                ServerName = CommandLine.Replace("-s", "")

            ElseIf CommandLine.StartsWith("-d") Then

                DatabaseName = CommandLine.Replace("-d", "")

            ElseIf CommandLine.StartsWith("-u") Then

                UserName = CommandLine.Replace("-u", "")

            ElseIf CommandLine.StartsWith("-p") Then

                Password = CommandLine.Replace("-p", "")

            End If

        Next

        If String.IsNullOrWhiteSpace(ServerName) = False AndAlso String.IsNullOrWhiteSpace(DatabaseName) = False AndAlso
                String.IsNullOrWhiteSpace(UserName) = False AndAlso String.IsNullOrWhiteSpace(Password) = False Then

            ConnectionString = Database.CreateConnectionString(ServerName, DatabaseName, False, UserName, Password, "AdavantageSES")

            If Database.IsValidConnectionString(ConnectionString) Then

                LoggedIn = True

                _ConnectionDatabaseProfile = New Database.ConnectionDatabaseProfile

                _ConnectionDatabaseProfile.ServerName = ServerName
                _ConnectionDatabaseProfile.DatabaseName = DatabaseName
                _ConnectionDatabaseProfile.UserName = UserName
                _ConnectionDatabaseProfile.Password = Password

            Else

                System.Windows.Forms.MessageBox.Show("Failed to create a valid connection.  Please check your inputs.", "Invalid Connection", System.Windows.Forms.MessageBoxButtons.OK)

                If LoginDialog.ShowFormDialog(ServerName, DatabaseName, UserName, _ConnectionDatabaseProfile) = DialogResult.OK Then

                    LoggedIn = True

                Else

                    System.Windows.Forms.Application.Exit()

                End If

            End If

        Else

            If LoginDialog.ShowFormDialog(ServerName, DatabaseName, UserName, _ConnectionDatabaseProfile) = DialogResult.OK Then

                LoggedIn = True

            Else

                System.Windows.Forms.Application.Exit()

            End If

        End If

        LoadStartUpInformation = LoggedIn

    End Function
    Private Function Save() As Boolean

        Dim Saved As Boolean = False
        Dim Agency As Database.Entities.Agency = Nothing
        Dim FileSizeLimit As Long = 0
        Dim TotalRepositorySizeLimit As Long = 0
        Dim FileSizeLimitInMB As Long = 0
        Dim TotalRepositorySizeLimitInGB As Long = 0

        Using DbContext = New Database.DbContext(_ConnectionDatabaseProfile.GetConnectionString())

            Try

                Try

                    Agency = DbContext.Agencies.FirstOrDefault

                Catch ex As Exception
                    Agency = Nothing
                End Try

                If Agency IsNot Nothing Then

                    Agency.FileSystemDirectory = TextBoxForm_Path.Text
                    Agency.FileSystemDomain = TextBoxForm_Domain.Text
                    Agency.FileSystemUserName = TextBoxForm_UserName.Text
                    Agency.FileSystemPassword = Encryption.Encrypt(TextBoxForm_Password.Text)

                End If

                FileSizeLimitInMB = NumericInputForm_FileSizeLimit.Value
                TotalRepositorySizeLimitInGB = NumericInputForm_TotalRepositorySizeLimit.Value

                If FileSizeLimitInMB <> 0 Then

                    FileSizeLimit = FileSizeLimitInMB * MB

                End If

                If TotalRepositorySizeLimitInGB <> 0 Then

                    TotalRepositorySizeLimit = TotalRepositorySizeLimitInGB * GB

                End If

                Try

                    FileSizeLimit = DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.AGY_SETTINGS SET AGY_SETTINGS_VALUE = '{0}' WHERE AGY_SETTINGS_CODE = 'FILE_UPLOAD_LIMIT'", FileSizeLimit))

                Catch ex As Exception
                    FileSizeLimit = 0
                End Try

                Try

                    TotalRepositorySizeLimit = DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.AGY_SETTINGS SET AGY_SETTINGS_VALUE = {0} WHERE AGY_SETTINGS_CODE = 'REPOSITORY_LIMIT'", TotalRepositorySizeLimit))

                Catch ex As Exception
                    TotalRepositorySizeLimit = 0
                End Try

                DbContext.ChangeTracker.DetectChanges()

                DbContext.SaveChanges()

                Saved = True

            Catch ex As Exception
                Saved = False
            End Try

        End Using

        Save = Saved

    End Function
    Private Function ValidateSettings(ByRef ErrorMessage As String) As Boolean

        Dim IsValid As Boolean = True

        If String.IsNullOrWhiteSpace(TextBoxForm_Path.Text) = False Then

            If My.Computer.FileSystem.DirectoryExists(TextBoxForm_Path.Text) = False Then

                IsValid = False
                ErrorMessage = If(String.IsNullOrWhiteSpace(ErrorMessage), "", System.Environment.NewLine) & "Invalid document path."

            End If

        End If

        ValidateSettings = IsValid

    End Function

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "

    Private Sub AdvantageDocumentRepositorySettingsForm_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        Dim Agency As Database.Entities.Agency = Nothing
        Dim FileSizeLimit As Long = 0
        Dim TotalRepositorySizeLimit As Long = 0
        Dim FileSizeLimitInMB As Long = 0
        Dim TotalRepositorySizeLimitInGB As Long = 0

        If LoadStartUpInformation(My.Application.CommandLineArgs) Then

            TextBoxForm_Path.MaxLength = 100
            TextBoxForm_Domain.MaxLength = 30
            TextBoxForm_UserName.MaxLength = 50

            Using DbContext = New Database.DbContext(_ConnectionDatabaseProfile.GetConnectionString())

                Try

                    Agency = DbContext.Agencies.FirstOrDefault

                Catch ex As Exception
                    Agency = Nothing
                End Try

                If Agency IsNot Nothing Then

                    TextBoxForm_Path.Text = Agency.FileSystemDirectory
                    TextBoxForm_Domain.Text = Agency.FileSystemDomain
                    TextBoxForm_UserName.Text = Agency.FileSystemUserName
                    TextBoxForm_Password.Text = Encryption.Decrypt(Agency.FileSystemPassword)

                End If

                Try

                    FileSizeLimit = DbContext.Database.SqlQuery(Of Long)("SELECT CAST(AGY_SETTINGS_VALUE as bigint) FROM dbo.AGY_SETTINGS WHERE AGY_SETTINGS_CODE = 'FILE_UPLOAD_LIMIT'").FirstOrDefault()

                Catch ex As Exception
                    FileSizeLimit = 0
                End Try

                Try

                    TotalRepositorySizeLimit = DbContext.Database.SqlQuery(Of Long)("SELECT CAST(AGY_SETTINGS_VALUE as bigint) FROM dbo.AGY_SETTINGS WHERE AGY_SETTINGS_CODE = 'REPOSITORY_LIMIT'").FirstOrDefault()

                Catch ex As Exception
                    TotalRepositorySizeLimit = 0
                End Try

                If FileSizeLimit <> 0 Then

                    FileSizeLimitInMB = FileSizeLimit / MB

                End If

                If TotalRepositorySizeLimit <> 0 Then

                    TotalRepositorySizeLimitInGB = TotalRepositorySizeLimit / GB

                End If

                NumericInputForm_FileSizeLimit.Value = FileSizeLimitInMB
                NumericInputForm_TotalRepositorySizeLimit.Value = TotalRepositorySizeLimitInGB

            End Using

        End If

    End Sub
    Private Sub AdvantageDocumentRepositorySettingsForm_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown



    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub ButtonForm_Save_Click(sender As Object, e As EventArgs) Handles ButtonForm_Save.Click

        If Save() Then

            System.Windows.Forms.MessageBox.Show("Settings saved successfully!")

        Else

            System.Windows.Forms.MessageBox.Show("Failed saving settings... please talk to programming dept.")

        End If

    End Sub
    Private Sub ButtonForm_SaveAndClose_Click(sender As Object, e As EventArgs) Handles ButtonForm_SaveAndClose.Click

        If Save() Then

            System.Windows.Forms.MessageBox.Show("Settings saved successfully!")

            System.Windows.Forms.Application.Exit()

        Else

            System.Windows.Forms.MessageBox.Show("Failed saving settings... please talk to programming dept.")

        End If

    End Sub
    Private Sub ButtonForm_Close_Click(sender As Object, e As EventArgs) Handles ButtonForm_Close.Click

        System.Windows.Forms.Application.Exit()

    End Sub
    Private Sub ButtonForm_Browse_Click(sender As Object, e As EventArgs) Handles ButtonForm_Browse.Click

        Dim FolderBrowserDialog As System.Windows.Forms.FolderBrowserDialog = Nothing

        FolderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog

        FolderBrowserDialog.Description = "Select Document Repository Path"
        FolderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer
        FolderBrowserDialog.ShowNewFolderButton = True

        If FolderBrowserDialog.ShowDialog = DialogResult.OK Then

            TextBoxForm_Path.Text = FolderBrowserDialog.SelectedPath

        End If

    End Sub

#End Region

#End Region

End Class
