Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load

        AddHandler AdvantageFramework.Navigation.ShowMessageBoxEvent, AddressOf AdvantageFramework.WinForm.MessageBox.Show

        ButtonItem1.Image = AdvantageFramework.My.Resources.DatabaseImportImage

    End Sub
    Private Sub ButtonDatabaseSettings_Build_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonDatabaseSettings_Build.Click

        'objects
        Dim ConnectionString As String = ""
        Dim SQLConnectionStringBuilder As System.Data.SqlClient.SqlConnectionStringBuilder = Nothing
        Dim DatabaseServer As String = ""
        Dim DatabaseName As String = ""

        SQLConnectionStringBuilder = New System.Data.SqlClient.SqlConnectionStringBuilder(TextBoxDatabaseSettings_ConnectionString.Text)

        DatabaseServer = SQLConnectionStringBuilder.DataSource
        DatabaseName = SQLConnectionStringBuilder.InitialCatalog

        If AdvantageFramework.Database.Presentation.ServerSetupDialog.ShowFormDialog(ConnectionString, DatabaseServer, DatabaseName) = Windows.Forms.DialogResult.OK Then

            TextBoxDatabaseSettings_ConnectionString.Text = ConnectionString

        End If

    End Sub
    Private Sub ButtonDatabaseSettings_Test_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonDatabaseSettings_Test.Click

        If AdvantageFramework.Database.TestConnectionString(TextBoxDatabaseSettings_ConnectionString.Text) Then

            AdvantageFramework.Navigation.ShowMessageBox("Test Successful!")

        Else

            AdvantageFramework.Navigation.ShowMessageBox("Test Failed.")

        End If

    End Sub

    Private Sub ButtonItem1_Click(sender As Object, e As EventArgs) Handles ButtonItem1.Click

        'objects
        Dim File As String = ""

        If AdvantageFramework.Database.TestConnectionString(TextBoxDatabaseSettings_ConnectionString.Text) Then

            If IntegerInputUserNameColumn.Value <> IntegerInputPasswordColumn.Value Then

                File = AdvantageFramework.WinForm.Presentation.SelectFileToOpen(, AdvantageFramework.FileSystem.LoadFileFilterString(AdvantageFramework.FileSystem.FileFilters.CSV), )

                If My.Computer.FileSystem.FileExists(File) Then

                    ImportUsers(File, TextBoxDatabaseSettings_ConnectionString.Text, IntegerInputUserNameColumn.Value, IntegerInputPasswordColumn.Value, _
                                IntegerInputIsSecurityAdmin.ValueObject, IntegerInputIsAdvantageAdmin.ValueObject, TextBox1.Text, CheckBoxIsFirst.Checked, _
                                CheckBoxAddOnlyToDatabase.Checked, CheckBoxEnforcePasswordPolicy.Checked, CheckBoxMustChangeAtNextLogin.Checked)

                    AdvantageFramework.Navigation.ShowMessageBox("WHERE IS MY KISS?!?!?!?!?!" & vbNewLine & vbNewLine & "Import Complete!")

                End If

            Else

                AdvantageFramework.Navigation.ShowMessageBox("Enter valid user name and password column info.")

            End If

        Else

            AdvantageFramework.Navigation.ShowMessageBox("Enter valid connection string info.")

        End If

    End Sub
    Private Sub ImportUsers(ByVal File As String, ByVal ConnectionString As String, UserNameColumn As Integer, PasswordColumn As Integer, IsSecurityAdminColumn As Nullable(Of Integer), _
                            IsAdvantageAdminColumn As Nullable(Of Integer), ClientID As String, ByVal FirstRowHasColumnHeaders As Boolean, ByVal AddOnlyToDatabase As Boolean, ByVal EnforcePasswordPolicy As Boolean, ByVal MustChangePasswordAtNextLogin As Boolean)

        'objects
        Dim TextFieldParser As FileIO.TextFieldParser = Nothing
        Dim FileLineData() As String = Nothing
        Dim UserName As String = ""
        Dim Password As String = ""
        Dim IsSecurityAdmin As Boolean = False
        Dim IsAdvantageAdmin As Boolean = False
        Dim ErrorMessage As String = ""

        TextFieldParser = New FileIO.TextFieldParser(File)

        TextFieldParser.TextFieldType = FileIO.FieldType.Delimited
        TextFieldParser.Delimiters = New String() {","}
        TextFieldParser.HasFieldsEnclosedInQuotes = True

        Try

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(ConnectionString, "")

                Do While Not TextFieldParser.EndOfData

                    FileLineData = TextFieldParser.ReadFields

                    If TextFieldParser.LineNumber <> 2 OrElse FirstRowHasColumnHeaders = False Then

                        ErrorMessage = ""

                        Try

                            UserName = FileLineData(UserNameColumn)

                            If UserName IsNot Nothing AndAlso String.IsNullOrEmpty(UserName.Trim) = False Then

                                UserName = UserName.ToUpper

                                UserName = ClientID & UserName

                                Password = FileLineData(PasswordColumn)

                                If IsSecurityAdminColumn.HasValue Then

                                    Try

                                        IsSecurityAdmin = Convert.ToBoolean(FileLineData(IsSecurityAdminColumn.Value))

                                    Catch ex As Exception
                                        IsSecurityAdmin = False
                                    End Try

                                End If

                                If IsAdvantageAdminColumn.HasValue Then

                                    Try

                                        IsAdvantageAdmin = Convert.ToBoolean(FileLineData(IsAdvantageAdminColumn.Value))

                                    Catch ex As Exception
                                        IsAdvantageAdmin = False
                                    End Try

                                End If

                                If AddOnlyToDatabase Then

                                    AdvantageFramework.Security.Database.Procedures.DatabaseSQLUserView.CreateDatabaseSQLUser(SecurityDbContext, UserName, IsAdvantageAdmin, True)

                                Else

                                    If AdvantageFramework.Security.Database.Procedures.ServerSQLUserView.CreateServerSQLUser(SecurityDbContext, UserName, False, Password, Password, IsSecurityAdmin, EnforcePasswordPolicy, MustChangePasswordAtNextLogin, ErrorMessage) Then

                                        AdvantageFramework.Security.Database.Procedures.DatabaseSQLUserView.CreateDatabaseSQLUser(SecurityDbContext, UserName, IsAdvantageAdmin, True)

                                    Else

                                        MsgBox("Failed creating SqlUser " & UserName & " " & ErrorMessage)

                                    End If

                                End If

                            End If

                        Catch ex As Exception

                        End Try

                    End If

                Loop

            End Using

        Catch ex As Exception

        End Try

        TextFieldParser.Close()
        TextFieldParser.Dispose()

    End Sub

End Class
