Imports MailBee.SmtpMail

Public Class About
    Inherits Webvantage.BaseChildPage

#Region "  Form Event Handlers "

    Private Sub About_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Not Me.IsPostBack Then

            Dim t As New UserTheme(Session("EmpCode"), Session("UserCode"), Session("ConnString"))
            t.Load()

            LoadAboutInfo()
            LoadBrowserInfo()

            Dim Application As cApplication = Nothing
            Application = New cApplication(CStr(Session("ConnString")))
            Me.LabelVersion.Text = Application.GetVersionText()
            Me.LabelVersion.Visible = True

            If Session("Admin") = True Then

                FieldsetTestEmail.Visible = True
                Me.TrDatabaseServer.Visible = True
            Else

                FieldsetTestEmail.Visible = False
                Me.TrDatabaseServer.Visible = False

            End If

            Dim ut As New UserTheme(Session("EmpCode"), Session("UserCode"), Session("ConnString"))
            ut.LoadFromDatabase()

            If ut.Settings.Agency_UseAgencyBranding = True And ut.Settings.FullPathToLogo <> "" Then

                Me.ImageLogo.ImageUrl = ut.Settings.FullPathToLogo
                Me.ImageLogo.Visible = True

                Try

                    Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
                    Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))

                        Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                        If Agency IsNot Nothing Then

                            ImageLogo.ToolTip = Agency.Name
                            ImageLogo.AlternateText = Agency.Name

                        End If

                    End Using

                Catch ex As Exception

                End Try

            Else

                'Me.ImageLogo.ImageUrl = "Images/Logos/simplifi_aqua_color.png"
                'Me.ImageLogo.Visible = True
                'Me.ImageLogo.ToolTip = "Aqua by the Advantage Software Company.  Powered by Simpli.fi."
                'Me.ImageLogo.AlternateText = Me.ImageLogo.ToolTip
                Me.ImageLogo.Visible = False

            End If

        End If

    End Sub

#End Region

#Region "  Control Event Handlers "

    Protected Sub ButtonTestEmail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonTestEmail.Click

        Try

            Dim ConnectedOrSent As Boolean = False
            Dim WebServices As New cWebServices(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"), HttpContext.Current.Session("EmpCode"))

            WebServices.GetSMPTSettingsByUser()

            If Me.TextBoxTestEmailServer.Text = "" Then

                Me.ShowMessage("Please enter an SMTP server.")
                Me.TextBoxTestEmailServer.Focus()
                Exit Sub

            End If

            If WebServices.oSMTPSettings.SMTP_AUTH_METHOD <> 0 Then

                If Me.TextBoxTestEmailUsername.Text = "" Then

                    Me.ShowMessage("Please enter an SMTP User Name.")
                    Me.TextBoxTestEmailUsername.Focus()
                    Exit Sub

                End If

                If Me.TextBoxTestEmailPassword.Text = "" Then

                    Me.ShowMessage("Please enter an SMTP Password.")
                    Me.TextBoxTestEmailPassword.Focus()
                    Exit Sub

                End If

            End If

            If Me.TextBoxTestEmailTo.Text = "" Then

                Me.ShowMessage("Please enter an email address to send to.")
                Me.TextBoxTestEmailTo.Focus()
                Exit Sub

            End If

            If AdvantageFramework.Email.IsValidEmailAddress(Me.TextBoxTestEmailTo.Text) = False Then

                Me.ShowMessage("Invalid email address to send to.")
                Me.TextBoxTestEmailTo.Focus()
                Exit Sub

            End If

            'If Page.IsValid = False Then Exit Sub
            LabelEmailResults.Text = ""
            Dim Subject As String = "Webvantage Email Test"
            Dim Body As String = "Sent on:  " & Now.ToString() & vbCrLf & vbCrLf

            Body &= "From Agency: " & Me.LabelAgencyName.Text & vbCrLf
            Body &= "From server: " & My.Computer.Name.ToString() & vbCrLf & vbCrLf

            Body &= "BROWSER INFO" & vbCrLf
            Body &= Request.Browser.Type & ", " & Request.Browser.Platform & vbCrLf
            Body &= "Type = " & Request.Browser.Type & vbCrLf
            Body &= "Name = " & Request.Browser.Browser & vbCrLf
            Body &= "Version = " & Request.Browser.Version & vbCrLf
            Body &= "Major Version = " & Request.Browser.MajorVersion & vbCrLf
            Body &= "Minor Version = " & Request.Browser.MinorVersion & vbCrLf
            Body &= "Platform = " & Request.Browser.Platform & vbCrLf
            Body &= "Is Beta = " & Request.Browser.Beta & vbCrLf
            Body &= "Is Crawler = " & Request.Browser.Crawler & vbCrLf
            Body &= "Is AOL = " & Request.Browser.AOL & vbCrLf
            Body &= "Is Win16 = " & Request.Browser.Win16 & vbCrLf
            Body &= "Is Win32 = " & Request.Browser.Win32 & vbCrLf
            Body &= "Supports Frames = " & Request.Browser.Frames & vbCrLf
            Body &= "Supports Tables = " & Request.Browser.Tables & vbCrLf
            Body &= "Supports Cookies = " & Request.Browser.Cookies & vbCrLf
            Body &= "Supports VB Script = " & Request.Browser.VBScript & vbCrLf
            Body &= "Supports JavaScript = " & Request.Browser.JavaScript & vbCrLf
            Body &= "Supports Java Applets = " & Request.Browser.JavaApplets & vbCrLf

            Dim SMTPAddress As String = String.Empty
            Dim SMTPUsername As String = String.Empty
            Dim SMTPPassword As String = String.Empty
            Dim [From] As String = String.Empty

            Try

                SMTPAddress = Me.TextBoxTestEmailServer.Text
                SMTPUsername = Me.TextBoxTestEmailUsername.Text
                SMTPPassword = Me.TextBoxTestEmailPassword.Text

                [From] = WebServices.oSMTPSettings.SMTP_SENDER

                If AdvantageFramework.Email.IsValidEmailAddress([From]) = False Then

                    [From] = [From] & "@" & SMTPAddress

                End If

            Catch ex As Exception

                With LabelEmailResults
                    .ForeColor = System.Drawing.Color.Red
                    .Text = "<H4>Error Finding SMTP settings!</H4>"
                    .Text &= ex.Message.ToString() & "<br />"
                    .Text &= ex.InnerException.Message.ToString() & "<br />"
                End With

            End Try

            Dim ToEmail As String = Me.TextBoxTestEmailTo.Text.Trim

            MailBee.Global.SafeMode = True
            MailBee.Global.LicenseKey = WebServices.oSMTPSettings.MB_LICENSE_KEY

            Dim Smtp As New MailBee.SmtpMail.Smtp

            Dim SmtpServer As New MailBee.SmtpMail.SmtpServer

            With SmtpServer
                .AuthMethods = WebServices.oSMTPSettings.SMTP_AUTH_METHOD
                .Name = SMTPAddress
                .AccountName = [SMTPUsername]
                .Password = [SMTPPassword]

                If WebServices.oSMTPSettings.SMTP_PORT_NUMBER > 0 Then

                    .Port = WebServices.oSMTPSettings.SMTP_PORT_NUMBER

                End If

                Select Case WebServices.oSMTPSettings.SMTP_SECURE_TYPE

                    Case 2

                        .SslMode = MailBee.Security.SslStartupMode.UseStartTls

                End Select

                '.SmtpOptions = ExtendedSmtpOptions.ClassicSmtpMode _
                '               And ExtendedSmtpOptions.NoChunking _
                '               And ExtendedSmtpOptions.NoDsn _
                '               And ExtendedSmtpOptions.NoSize

            End With

            SmtpServer.HelloDomain = SmtpServer.Name
            Smtp.DirectSendDefaults.HelloDomain = SmtpServer.Name

            Smtp.SmtpServers.Add(SmtpServer)

            'mbSMTP.SmtpServers.Add("mail.gotoadvantage.com", "test.ec", "Advtst1")

            ConnectedOrSent = Smtp.Connect()

            If ConnectedOrSent = False Then

                Me.ShowMessage(Smtp.GetErrorDescription)
                Exit Sub

            End If

            Smtp.Message.From.AsString = [From]
            Smtp.Message.To.AsString = ToEmail
            Smtp.Message.Subject = Subject
            Smtp.Message.BodyHtmlText = Body
            Smtp.Message.ReplyTo.AsString = WebServices.oSMTPSettings.EMAIL_REPLY_TO

            If Smtp.Message.To.AsString = "" And Smtp.Message.Cc.AsString = "" And Smtp.Bcc.AsString = "" Then

                ConnectedOrSent = True

            Else

                ConnectedOrSent = Smtp.Send()

            End If

            If ConnectedOrSent = False Then

                Me.ShowMessage(Smtp.GetErrorDescription)
                Exit Sub

            End If

            Try

                With LabelEmailResults
                    .ForeColor = System.Drawing.Color.DarkGreen
                    .Text = "<div align=""center""><H4>No  errors detected when contacting SMTP server.</H4>Please confirm receipt of test email specified in the ""Send To"" field.</div>"
                End With

            Catch ex As Exception

                With LabelEmailResults
                    .ForeColor = System.Drawing.Color.Red
                    .Text = "<H4>Error Sending Email!</H4>"
                    .Text &= ex.Message.ToString() & "<br />"
                    .Text &= ex.InnerException.Message.ToString() & "<br /><br />"
                End With

            Finally
                'msg = Nothing
            End Try

        Catch ex As Exception

            With LabelEmailResults
                .ForeColor = System.Drawing.Color.Red
                .Text = "<H4>Error Sending Email Button</H4>"
                .Text &= ex.Message.ToString() & "<br />"
                .Text &= ex.InnerException.Message.ToString() & "<br /><br />"
            End With

        End Try

    End Sub

    Private Sub RadioButtonListUseSettings_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonListUseSettings.SelectedIndexChanged

        Try
            If RadioButtonListUseSettings.SelectedIndex = 0 Then 'Use db settings

                EnableEmailFields(False)

            Else 'Use form settings

                EnableEmailFields(True)

            End If

        Catch ex As Exception
            Me.ShowMessage(ex.Message.ToString())
        End Try

    End Sub

#End Region

#Region " Methods "

    Private Sub LoadAboutInfo()

        Dim Application As cApplication = New cApplication(CStr(Session("ConnString")))
        Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
        Dim LicenseKeyDate As Date = Nothing
        Dim DaysUntilFileExpires As Integer = 0
        Dim DaysUntilKeyExpires As Integer = 0
        Dim PowerUsersQuantity As Integer = 0
        Dim WVOnlyUsersQuantity As Integer = 0
        Dim ClientPortalUsersQuantity As Integer = 0
        Dim MediaToolsUsersQuantity As Integer = 0
        Dim APIUsersQuantity As Integer = 0
        Dim EnableProofingTool As Boolean = False
        Dim AgencyName As String = ""
        Dim LicenseKey As String = ""
        Dim DatabaseID As Integer = 0
        Dim DatabaseVersion As String = ""
        Dim ErrorMessage As String = String.Empty

        Me.LabelApplicationTitle.Text = System.Configuration.ConfigurationManager.AppSettings("AppTitle")

        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

            End Using

            If Agency IsNot Nothing Then

                LicenseKey = AdvantageFramework.Security.LicenseKey.Read(Agency.LicenseKey, LicenseKeyDate, DaysUntilFileExpires, DaysUntilKeyExpires,
                                                                         PowerUsersQuantity, WVOnlyUsersQuantity, ClientPortalUsersQuantity, AgencyName, DatabaseID,
                                                                         MediaToolsUsersQuantity, APIUsersQuantity, EnableProofingTool, ErrorMessage)

                If LicenseKey <> "" Then

                    If WVOnlyUsersQuantity <> -1 AndAlso APIUsersQuantity <> 0 Then

                        WVOnlyUsersQuantity += 1

                    End If

                    LabelAgencyName.Text = AgencyName.Trim

                    LabelLKPowerUsers.Text = IIf(PowerUsersQuantity = -1, "Unlimited", PowerUsersQuantity)
                    LabelPowerUsers.Text = AdvantageFramework.Security.LicenseKey.LoadConnectedUsers(_Session, AdvantageFramework.Security.LicenseKey.Types.PowerUser).Count
                    LabelLKTimeEntryUsers.Text = IIf(WVOnlyUsersQuantity = -1, "Unlimited", WVOnlyUsersQuantity)
                    LabelTimeEntryUsers.Text = AdvantageFramework.Security.LicenseKey.LoadConnectedUsers(_Session, AdvantageFramework.Security.LicenseKey.Types.WebvantageOnly).Count
                    LabelLKClientPortalUsers.Text = IIf(ClientPortalUsersQuantity = -1, "Unlimited", ClientPortalUsersQuantity)
                    LabelClientPortalUsers.Text = AdvantageFramework.Security.LicenseKey.LoadConnectedUsers(_Session, AdvantageFramework.Security.LicenseKey.Types.ClientPortalUser).Count
                    LabelLKMediaToolsUsers.Text = IIf(MediaToolsUsersQuantity = -1, "Unlimited", MediaToolsUsersQuantity)
                    LabelLKAPIUsers.Text = IIf(APIUsersQuantity = -1, "Unlimited", APIUsersQuantity)

                    If EnableProofingTool = True Then

                        LabelProofingToolEnabled.Text = "Yes"

                    Else

                        LabelProofingToolEnabled.Text = "No"

                    End If

                End If

            End If

            Me.LabelSoftwareVersion.Text = Application.GetWebvantageVersion & "  (" & Application.GetFileDate("Webvantage.dll") & ")"

            Try

                DatabaseVersion = SecurityDbContext.Database.SqlQuery(Of String)("SELECT WEBVAN_VERSION_ID FROM dbo.ADVAN_UPDATE").FirstOrDefault()

            Catch ex As Exception
                DatabaseVersion = ""
            End Try

            Me.LabelDatabaseVersion.Text = DatabaseVersion

            Try

                DatabaseVersion = SecurityDbContext.Database.SqlQuery(Of String)("SELECT VERSION_ID FROM dbo.ADVAN_UPDATE").FirstOrDefault().Replace("v", "")

            Catch ex As Exception
                DatabaseVersion = ""
            End Try

            Me.LabelAdvantageDatabaseVersion.Text = DatabaseVersion

            Me.LabelSQLAppName.Text = _Session.Application.ToString

            Try

                Me.LabelLastADvantageUpdate.Text = SecurityDbContext.Database.SqlQuery(Of Date)("SELECT DB_UPDATE FROM dbo.ADVAN_UPDATE").FirstOrDefault()

            Catch ex As Exception
                Me.LabelLastADvantageUpdate.Text = ""
            End Try

            Me.LabelDBServer.Text = Session("DBServerName")
            Me.LabelDBName.Text = Session("DBName")
            Me.LabelLocale.Text = LoGlo.GetCultureInfo().EnglishName

        End Using

    End Sub

    Private Sub EnableEmailFields(ByVal IsEnabled As Boolean)

        Try

            Dim WebServices As New cWebServices(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"), HttpContext.Current.Session("EmpCode"))

            Me.TextBoxTestEmailServer.Enabled = IsEnabled
            'Me.TextBoxTestEmailTo.Enabled = IsEnabled
            Me.TextBoxTestEmailUsername.Enabled = IsEnabled
            Me.TextBoxTestEmailPassword.Enabled = IsEnabled

            If Me.RadioButtonListUseSettings.SelectedIndex = 0 Then

                WebServices.GetSMPTSettingsByUser()
                Me.TextBoxTestEmailServer.Text = WebServices.oSMTPSettings.SMTP_SERVER
                Me.TextBoxTestEmailUsername.Text = WebServices.oSMTPSettings.EMAIL_USERNAME
                Me.TextBoxTestEmailPassword.Text = WebServices.oSMTPSettings.EMAIL_PWD

                'Dim SMTPSettings As New vAgencySMTPSettings(Session("ConnString"))
                'SMTPSettings.Query.Load()
                'Me.TextBoxTestEmailServer.Text = SMTPSettings.s_SMTP_SERVER
                'Me.TextBoxTestEmailUsername.Text = SMTPSettings.s_EMAIL_USERNAME
                'Me.TextBoxTestEmailPassword.Text = SMTPSettings.s_EMAIL_PWD

            Else

                Me.TextBoxTestEmailServer.Text = ""
                Me.TextBoxTestEmailUsername.Text = ""
                Me.TextBoxTestEmailPassword.Text = ""

            End If

        Catch ex As Exception
            Me.ShowMessage(ex.Message.ToString())
        End Try

    End Sub

    Private Sub LoadBrowserInfo()

        Dim Body As String
        'strBody = "Application Path = " & HttpContext.Current.Request.ServerVariables("HTTP_X_FORWARDED_FOR") & "<br />"
        Body &= "Type = " & Request.Browser.Type & "<br />"
        Body &= "Name = " & Request.Browser.Browser & "<br />"
        Body &= "Version = " & Request.Browser.Version & "<br />"
        Body &= "Major Version = " & Request.Browser.MajorVersion & "<br />"
        Body &= "Minor Version = " & Request.Browser.MinorVersion & "<br /><br />"
        Body &= "Platform = " & Request.Browser.Platform & "<br /><br />"
        Body &= "Is Beta = " & Request.Browser.Beta & "<br />"
        Body &= "Is Crawler = " & Request.Browser.Crawler & "<br />"
        Body &= "Is AOL = " & Request.Browser.AOL & "<br />"
        Body &= "Is Win16 = " & Request.Browser.Win16 & "<br />"
        Body &= "Is Win32 = " & Request.Browser.Win32 & "<br /><br />"
        Body &= "Supports Frames = " & Request.Browser.Frames & "<br />"
        Body &= "Supports Tables = " & Request.Browser.Tables & "<br />"
        Body &= "Supports Cookies = " & Request.Browser.Cookies & "<br />"
        Body &= "Supports VB Script = " & Request.Browser.VBScript & "<br />"
        Body &= "Supports JavaScript = " & Request.Browser.JavaScript & "<br />"
        Body &= "Supports Java Applets = " & Request.Browser.JavaApplets & "<br />"

        Me.LabelBrowserInfo.Text = Body

    End Sub

#End Region

End Class
