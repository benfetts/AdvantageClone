Public Class AdvantageSESForm

#Region " Constants "

    Private Const AdvantageSESTable As String = "CREATE TABLE [dbo].[ADVANTAGE_SES](
		[ADVANTAGE_SES_ID] [int] IDENTITY (1, 1) NOT NULL,
		[SMTP_AUTH_METHOD] [smallint] NOT NULL,
		[SMTP_PORT_NUMBER] [smallint] NOT NULL,
		[SMTP_SECURE_TYPE] [smallint] NOT NULL,
		[SMTP_SERVER] [varchar](100) NOT NULL,
		[SMTP_SENDER] [varchar](100) NOT NULL,
		[EMAIL_USERNAME] [varchar](100) NOT NULL,
		[EMAIL_PWD] [varchar](MAX) NOT NULL,
		[EMAIL_REPLY_TO] [varchar](100) NOT NULL,
	 CONSTRAINT [PK_ADVANTAGE_SES_ID] PRIMARY KEY CLUSTERED 
	(
		[ADVANTAGE_SES_ID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    ) ON [PRIMARY]"

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
    Private Function HasAdvantageSESTable() As Boolean

        'objects
        Dim AdvantageSESTableExists As Boolean = False

        Using DbContext = New Database.DbContext(_ConnectionDatabaseProfile.GetConnectionString())

            Try

                AdvantageSESTableExists = (DbContext.Database.SqlQuery(Of Integer)("SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'ADVANTAGE_SES'").FirstOrDefault > 0)

            Catch ex As Exception
                AdvantageSESTableExists = False
            End Try

        End Using

        HasAdvantageSESTable = AdvantageSESTableExists

    End Function
    Private Sub LoadExistingOrDefaults()


    End Sub
    Private Function Save() As Boolean

        Dim Saved As Boolean = False
        Dim AdvantageSES As Database.Entities.AdvantageSES = Nothing

        Using DbContext = New Database.DbContext(_ConnectionDatabaseProfile.GetConnectionString())

            Try

                Try

                    AdvantageSES = DbContext.AdvantageSESs.Find(1)

                Catch ex As Exception
                    AdvantageSES = Nothing
                End Try

                If AdvantageSES Is Nothing Then

                    AdvantageSES = New Database.Entities.AdvantageSES

                    DbContext.AdvantageSESs.Add(AdvantageSES)

                End If

                AdvantageSES.SMTPAuthMethod = ComboBoxForm_AuthenticationMethod.SelectedValue
                AdvantageSES.SMTPPortNumber = NumericInputForm_PortNumber.Value

                If RadioButtonForm_NoSecureProtocol.Checked Then

                    AdvantageSES.SMTPSecureType = 0

                ElseIf RadioButtonForm_UseSSL.Checked Then

                    AdvantageSES.SMTPSecureType = 1

                ElseIf RadioButtonForm_UseTLS.Checked Then

                    AdvantageSES.SMTPSecureType = 2

                End If

                AdvantageSES.SMTPServer = TextBoxForm_OutgoingServerAddress.Text
                AdvantageSES.SMTPSender = TextBoxForm_SenderAddress.Text
                AdvantageSES.EmailUsername = TextBoxForm_DefaultUserName.Text
                AdvantageSES.EmailPassword = Encryption.Encrypt(TextBoxForm_DefaultPassword.Text)
                AdvantageSES.EmailReplyTo = TextBoxForm_ReplyToAddress.Text

                DbContext.ChangeTracker.DetectChanges()

                DbContext.SaveChanges()

                Saved = True

            Catch ex As Exception
                Saved = False
            End Try

        End Using

        Save = Saved

    End Function

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "

    Private Sub AdvantageSESForm_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        Dim AdvantageSES As Database.Entities.AdvantageSES = Nothing

        If LoadStartUpInformation(My.Application.CommandLineArgs) Then

            If HasAdvantageSESTable() Then

                Using DbContext = New Database.DbContext(_ConnectionDatabaseProfile.GetConnectionString())

                    Try

                        AdvantageSES = DbContext.AdvantageSESs.FirstOrDefault

                    Catch ex As Exception
                        AdvantageSES = Nothing
                    End Try

                End Using

                PanelForm_Top.Visible = False
                PanelForm_Form.Enabled = True

            Else

                PanelForm_Top.Visible = True
                PanelForm_Form.Enabled = False

            End If

            'ComboBoxForm_AuthenticationMethod.DataSource = New System.Windows.Forms.BindingSource((From KeyValuePair In EnumUtilities.GetEnumDictionaryShort(GetType(Email.SmtpAuthenticationMethods))
            '                                                                                       Select [Code] = KeyValuePair.Key,
            '                                                                                              [Description] = KeyValuePair.Value).ToList, Nothing)
            ComboBoxForm_AuthenticationMethod.DataSource = (From KeyValuePair In EnumUtilities.GetEnumDictionaryShort(GetType(Email.SmtpAuthenticationMethods))
                                                            Select [Code] = KeyValuePair.Key,
                                                                   [Description] = KeyValuePair.Value).ToList

            ComboBoxForm_AuthenticationMethod.ValueMember = "Code"
            ComboBoxForm_AuthenticationMethod.DisplayMember = "Description"

            If AdvantageSES Is Nothing Then

                AdvantageSES = New Database.Entities.AdvantageSES

                AdvantageSES.SMTPAuthMethod = 1
                AdvantageSES.SMTPPortNumber = 587
                AdvantageSES.SMTPSecureType = 0
                AdvantageSES.SMTPServer = "mail.gotoadvantage.com"
                AdvantageSES.SMTPSender = "test.soft@gotoadvantage.com"
                AdvantageSES.EmailUsername = "test.soft"
                AdvantageSES.EmailPassword = "3Yyq85NHaR+xd9uuGiPGkGpaeAY9jXB7A2FzILocTuI="
                AdvantageSES.EmailReplyTo = "test.soft@gotoadvantage.com"

            End If

            ComboBoxForm_AuthenticationMethod.SelectedValue = AdvantageSES.SMTPAuthMethod
            NumericInputForm_PortNumber.Value = AdvantageSES.SMTPPortNumber

            Select Case AdvantageSES.SMTPSecureType

                Case 0

                    RadioButtonForm_NoSecureProtocol.Checked = True

                Case 1

                    RadioButtonForm_UseSSL.Checked = True

                Case 2

                    RadioButtonForm_UseTLS.Checked = True

            End Select

            TextBoxForm_OutgoingServerAddress.Text = AdvantageSES.SMTPServer
            TextBoxForm_SenderAddress.Text = AdvantageSES.SMTPSender
            TextBoxForm_DefaultUserName.Text = AdvantageSES.EmailUsername
            TextBoxForm_DefaultPassword.Text = Encryption.Decrypt(AdvantageSES.EmailPassword)
            TextBoxForm_ReplyToAddress.Text = AdvantageSES.EmailReplyTo

        End If

    End Sub
    Private Sub AdvantageSESForm_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown



    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub ButtonTop_CreateTable_Click(sender As Object, e As EventArgs) Handles ButtonTop_CreateTable.Click

        Using DbContext = New Database.DbContext(_ConnectionDatabaseProfile.GetConnectionString())

            Try

                DbContext.Database.ExecuteSqlCommand(AdvantageSESTable)

            Catch ex As Exception

            End Try

        End Using

        If HasAdvantageSESTable() Then

            PanelForm_Form.Enabled = True
            PanelForm_Top.Visible = False

        Else

            System.Windows.Forms.MessageBox.Show("Failed creating table... please talk to programming dept.")

        End If

    End Sub
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
    Private Sub ButtonTop_Close_Click(sender As Object, e As EventArgs) Handles ButtonTop_Close.Click

        System.Windows.Forms.Application.Exit()

    End Sub

#End Region

#End Region

End Class
