Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Security
Imports Microsoft.Win32
Imports Webvantage.cGlobals.Globals
Imports Webvantage.MiscFN
Imports System.Web.Configuration

Public Class SignIn
    Inherits Page

    Private Const NoConnectionMessage As String = "No webvantage connections setup for that server/database. Please contact software support."

#Region " Variables "

    Private _IsUsingTrustedConn As Boolean = False
    Private _SQLAdminUserName As String = String.Empty
    Private _SQLAdminPassword As String = String.Empty
    Private _NTAuthUserIgnoreCase As Boolean = False
    Private _ChangingPassword As Boolean = False
    Private _IsClientPortal As Boolean = MiscFN.IsClientPortal()
    Private _IsServerAdmin As Boolean = False
    Public BackgroundCSS As String = ""
    Public SideBarColor As String = ""
    Public BackgroundColor As String = ""
    Public DarkModeScript As String = ""
    Private Property _IsServerSignIn As Boolean
        Get
            If ViewState("IsAdminSignIn") Is Nothing Then ViewState("IsAdminSignIn") = False
            Return CType(ViewState("IsAdminSignIn"), Boolean)
        End Get
        Set(value As Boolean)
            ViewState("IsAdminSignIn") = value
        End Set
    End Property
    Private Property TwoFactorEmailSent As Boolean
        Get
            If ViewState("TwoFactorEmailSent") Is Nothing Then ViewState("TwoFactorEmailSent") = False
            Return CType(ViewState("TwoFactorEmailSent"), Boolean)
        End Get
        Set(value As Boolean)
            ViewState("TwoFactorEmailSent") = value
        End Set
    End Property

#End Region

    Private ReadOnly Property ChooseServer As Boolean
        Get
            Return System.Configuration.ConfigurationManager.AppSettings("ChooseServer").ToString.ToLower = "true"
        End Get
    End Property

#Region "  Form Event Handlers "

    Private Sub SignIn_PreInit(sender As Object, e As System.EventArgs) Handles Me.PreInit

        If HttpContext.Current.Request.QueryString("ReturnUrl") IsNot Nothing Then

            If HttpContext.Current.Request.QueryString("ReturnUrl").ToLower().Contains(".aspx") = False AndAlso
                HttpContext.Current.Response.IsRequestBeingRedirected = False Then

                HttpContext.Current.Response.Redirect("SignIn.aspx", True)

            End If

        End If

        'Dim s As String = HttpContext.Current.Request.Url.AbsolutePath
        'If s.Contains("SignIn.aspx/") = True Then

        '    If Session("123") = Nothing Then

        '        Session("123") = True
        '        HttpContext.Current.Response.Redirect("SignIn.aspx", True)

        '    End If

        'Else

        '    Session("123") = Nothing

        'End If

        Dim MajorVersion As Integer = CType(Request.Browser.MajorVersion.ToString().Trim(), Integer)

        If Request.Browser.Browser.ToString().Trim().ToUpper() = "IE" AndAlso MajorVersion < 9 Then

            MiscFN.ResponseRedirect("Incompatible.aspx", True)

        End If

        If Page.IsPostBack = False Then

            If MissingSSL() = True Then

                Me.PanelNoSSL.Visible = True
                Me.PanelSignIn.Visible = False
                Me.LiteralSignInHeader.Text = ""

            Else

                Me.PanelNoSSL.Visible = False
                Me.PanelSignIn.Visible = True

            End If

            Me.gmWindowCell.Visible = False
            Me.DivTwoFactorEmailVisible(False)

        End If

        Dim t As New UserTheme(Session("EmpCode"), Session("UserCode"), Session("ConnString"))
        t.LoadFromCookie()
        t.Reload()

        Me.Theme = t.Settings.AppTheme
        Me.RadSkinManagerSignIn.Skin = t.Settings.TelerikTheme

        Me.SetWallpaper(t)
        Me.SetLogo(t)

        Me.MaterialCSSLink.Attributes.Remove("href")
        Me.MaterialCSSLink.Attributes.Add("href", "CSS/Material/" & t.Settings.CssFile)

        Me.TrFooter.Visible = Not t.Settings.Agency_UseAgencyBranding

    End Sub
    Private Sub DivTwoFactorEmailVisible(ByVal Visible As Boolean)

        Me.DivTwoFactorEmail.Visible = Visible
        Me.DivTwoFactorEmailLink.Visible = Visible

    End Sub
    Private Function MissingSSL() As Boolean

        Dim IsMissingSSL As Boolean = False

        Try

            Dim WebConfig = WebConfigurationManager.OpenWebConfiguration("~")
            If WebConfig IsNot Nothing Then

                Dim HttpCookieSetting = CType(WebConfig.GetSection("system.web/httpCookies"), System.Web.Configuration.HttpCookiesSection)

                If HttpCookieSetting IsNot Nothing Then

                    If HttpCookieSetting.RequireSSL = True Then

                        If HttpContext.Current.Request.Url.Scheme.ToLower <> "https" Then

                            IsMissingSSL = True

                        End If

                    End If

                End If

            End If

        Catch ex As Exception
            IsMissingSSL = False
        End Try

        Return IsMissingSSL

    End Function
    Private Sub SignIn_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        If Me.ChooseServer = False Then

            Me.TextBoxSQLServer.Text = ""
            Me.TextBoxSQLServer1.Text = ""

        End If

    End Sub
    Protected Sub SignIn_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'objects
        Dim Security As cSecurity = Nothing
        Dim Application As cApplication = Nothing
        Dim AppInfo As cApplicationInfo = Nothing
        Dim ErrorMessage As String = ""
        Dim Password As String = String.Empty

        Try

            AddHandler AdvantageFramework.Navigation.ShowChangePasswordWithMessageEvent, AddressOf ShowChangePasswordWithMessage
            AddHandler AdvantageFramework.Navigation.ShowMessageEvent, AddressOf ShowMessage

            If (Not IsNothing(Request.Headers("User-Agent"))) Then

                'If Request.Browser("isMobileDevice") = "true" Or Request.Browser("BlackBerry") = "true" Or Request.UserAgent.ToUpper.Contains("MIDP") Or
                '        Request.UserAgent.ToUpper.Contains("CLDC") Or Request.UserAgent.ToLower.Contains("iphone") Or Request.UserAgent.ToUpper.Contains("BLACKBERRY") Or
                '        Request.UserAgent.ToUpper.Contains("ANDROID") Then
                '    Me.DivGoToMobileApp.Visible = True
                'Else
                '    Me.DivGoToMobileApp.Visible = False
                'End If

            End If

            AppInfo = New cApplicationInfo

            With Me.LabelVersion
                .Text = cApplication.GetVersionText()
                .Visible = True
            End With

            With Me.LabelCopyright
                .Text = cApplication.GetCopyrightText()
                .Visible = True
            End With

            AdvantageFramework.Security.WriteToWebvantageEventLog = cApplication.WriteToWebvantageEventLog

            Me.DivTrusted.Visible = False

            If MiscFN.IsNTAuth = True Then

                CheckBoxUseTrustedConnection.Checked = True
                _IsUsingTrustedConn = True

                TextBoxUserID.Visible = False
                'DivUserID.Visible = False
                DivPassword.Visible = False
                DivChangePassword.Visible = False

            Else

                CheckBoxUseTrustedConnection.Checked = False
                _IsUsingTrustedConn = False
                DivUserID.Visible = True
                DivPassword.Visible = True
                DivChangePassword.Visible = True

            End If

            Me.DivSqlServer.Visible = Me.ChooseServer

            If System.Configuration.ConfigurationManager.AppSettings("UpperCaseUser").ToString.ToLower = "true" Then

                If TextBoxUserID.Visible = True And _IsClientPortal = False Then

                    TextBoxUserID.Attributes.Add("onkeyup", "UpperCaseTheText('" & Me.TextBoxUserID.ClientID & "');showPasswordLinks();")

                End If

            Else

                If TextBoxUserID.Visible = True Then

                    TextBoxUserID.Attributes.Add("onkeyup", "showPasswordLinks();")

                End If

            End If
            If TextBoxUserID.Visible = True Then

                TextBoxUserID.Attributes.Add("onblur", "showPasswordLinks()")

            End If
            If System.Configuration.ConfigurationManager.AppSettings("UpperCaseDatabase").ToString.ToLower = "true" Then

                TextBoxDataBase.Attributes.Add("onkeyup", "UpperCaseTheText('" & Me.TextBoxDataBase.ClientID & "');")

            End If

            If _IsClientPortal Then
                Me.LinkButtonChangePassword.Visible = False
                Me.LinkButtonLostPassword.Visible = False
            End If

            If Page.IsPostBack = False Then

                Me.ShowCell(CellType.defaultSignIn)

                Try

                    Session.Abandon()
                    FormsAuthentication.SignOut()

                Catch ex As Exception
                End Try

                If cApplication.GetSignInCookie(Me.TextBoxSQLServer.Text,
                                                Me.TextBoxDataBase.Text,
                                                Me.TextBoxUserID.Text,
                                                Me.TextBoxPassword.Text,
                                                Me.CheckBoxRememberMe.Checked,
                                                ErrorMessage) = False Then

                    Me.ShowMessage(ErrorMessage)

                End If

                If _IsUsingTrustedConn = True Then

                    TextBoxUserID.Visible = True
                    TextBoxUserID.Text = My.User.Name
                    TextBoxUserID.Enabled = False

                End If

                Try
                    MiscFN.RadComboBoxSetIndex(RadComboBoxLanguage, LoGlo.UserCultureGet, False)
                Catch ex As Exception
                End Try


                Try
                    _SQLAdminUserName = System.Configuration.ConfigurationManager.AppSettings("SQLAdminUserName")
                    _SQLAdminPassword = System.Configuration.ConfigurationManager.AppSettings("SQLAdminPassword")
                    TextBoxPassword.Attributes.Add("onkeypress", "capLock(event)")
                Catch ex As Exception
                End Try

            Else

                Select Case Me.Page.Request.Form("__EVENTARGUMENT").ToString().Replace("onclick#", "")

                    Case "SignInNewApp"

                        Me.SignIn(True)

                        If Me.TwoFactorEmailSent = True Then

                            Password = TextBoxPassword.Text

                            TextBoxPassword.Attributes.Add("value", Password)

                        End If

                    Case "CloseAdminWindow"

                        Try
                            Session.Abandon()
                            FormsAuthentication.SignOut()
                        Catch ex As Exception
                        End Try

                        Me.ShowCell(CellType.defaultSignIn)

                    Case "admin"

                        Me.ShowCell(CellType.adminSignIn)

                End Select

            End If

        Catch ex As Exception
            Me.ShowMessage(ex.Message.ToString())
        End Try
        If Not Me.IsPostBack And Not Me.IsCallback Then
            Try
                If Not Request.QueryString("m") Is Nothing Then
                    Dim Message As AdvantageFramework.Security.ErrorMessages.SystemMessageType = CType(CType(Request.QueryString("m"), Integer), AdvantageFramework.Security.ErrorMessages.SystemMessageType)
                    If Message <> AdvantageFramework.Security.ErrorMessages.SystemMessageType.DefaultMessage Then
                        Select Case Message
                            Case AdvantageFramework.Security.ErrorMessages.SystemMessageType.SessionIdMismatch
                                Dim sb As New System.Text.StringBuilder
                                With sb
                                    '.Append("Your current Session ID does not match the Session ID when you signed in.")
                                    '.Append("\n")
                                    '.Append("Sign in ID:  ")
                                    'If Not Request.QueryString("d") Is Nothing Then
                                    '    .Append(Request.QueryString("d").ToString())
                                    'End If
                                    '.Append("\n")
                                    '.Append("Current ID: ")
                                    'If Not Request.QueryString("c") Is Nothing Then
                                    '    .Append(Request.QueryString("c").ToString())
                                    'End If
                                    '.Append("\n")
                                    .Append("Another browser session has signed in with this User ID.")
                                End With
                                Me.ShowMessage(sb.ToString())
                            Case AdvantageFramework.Security.ErrorMessages.SystemMessageType.TimeOut
                                Me.ShowMessage("You have timed out.")
                            Case AdvantageFramework.Security.ErrorMessages.SystemMessageType.NoConnString
                                'Me.ShowMessage("Previous session ended.")
                            Case Else
                                Me.ShowMessage(AdvantageFramework.Security.ErrorMessages.System(Message))
                        End Select
                    End If
                End If
            Catch ex As Exception
            End Try

        End If

    End Sub
    Private Sub SignIn_LoadComplete(sender As Object, e As System.EventArgs) Handles Me.LoadComplete

        Me.LabelCopyright.Visible = True
        Me.LabelVersion.Visible = True

    End Sub
    Private Sub SignIn_Unload(sender As Object, e As System.EventArgs) Handles Me.Unload

        RemoveHandler AdvantageFramework.Navigation.ShowChangePasswordWithMessageEvent, AddressOf ShowChangePasswordWithMessage
        RemoveHandler AdvantageFramework.Navigation.ShowMessageEvent, AddressOf ShowMessage

    End Sub

#End Region

#Region "  Control Event Handlers "
    Private Sub ButtonLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonLogin.Click

        SignIn(True)

    End Sub
    Private Sub ButtonChangePasswordOK_Click(sender As Object, e As EventArgs) Handles ButtonChangePasswordOK.Click

        Dim ConnectionString As String = String.Empty
        Dim PasswordChanged As Boolean = False
        Dim ErrorMessage As String = ""
        Dim SqlConnectionStringBuilder As System.Data.SqlClient.SqlConnectionStringBuilder = Nothing
        Dim User As AdvantageFramework.Security.Database.Entities.User = Nothing
        Dim Messages As Generic.List(Of String) = Nothing
        Dim PasswordController As AdvantageFramework.Controller.Account.PasswordController = Nothing
        Me.LiteralMessages.Text = ""

        If TextBoxNewPassword.Text = TextBoxConfirmNewPassword.Text Then

            ConnectionString = LoadConnectionString()

            If String.IsNullOrWhiteSpace(ConnectionString) = False Then

                Try

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(ConnectionString, TextBoxUserID.Text)

                        User = AdvantageFramework.Security.Database.Procedures.User.LoadByUserCode(SecurityDbContext, TextBoxUserID.Text)

                        If User IsNot Nothing Then

                            If User.IsInactive = False Then

                                If String.IsNullOrWhiteSpace(User.Password) = False Then

                                    If User.Password = AdvantageFramework.Security.Encryption.EncryptPassword(TextBoxOldPassword.Text.Trim) Then

                                        PasswordController = New AdvantageFramework.Controller.Account.PasswordController(Nothing)

                                        If PasswordController.Validate(SecurityDbContext, User.UserCode, TextBoxNewPassword.Text, Messages) = True Then

                                            User.Password = AdvantageFramework.Security.Encryption.EncryptPassword(TextBoxNewPassword.Text.Trim)
                                            PasswordChanged = AdvantageFramework.Security.Database.Procedures.User.Update(SecurityDbContext, User)

                                            If PasswordChanged = True Then

                                                AdvantageFramework.Security.Password.InsertNewPasswordHistory(SecurityDbContext, User)

                                            End If

                                        Else

                                            If Messages IsNot Nothing AndAlso Messages.Count > 0 Then

                                                For Each Message As String In Messages

                                                    Me.AddListItem(Message)

                                                Next

                                            End If

                                        End If

                                    Else

                                        Me.AddListItem(AdvantageFramework.Security.Password.IncorrectOldPasswordMessage)

                                    End If

                                Else

                                    ErrorMessage = AdvantageFramework.Security.Password.NoChangeForNewUserMessage

                                End If

                            Else

                                ErrorMessage = AdvantageFramework.Security.Password.InactiveUserMessage

                            End If

                        End If

                    End Using

                Catch ex As Exception
                    PasswordChanged = False
                    ErrorMessage = ex.Message
                End Try
                If PasswordChanged = True Then

                    TextBoxPassword.Text = TextBoxNewPassword.Text
                    TextBoxPassword.Attributes.Add("value", TextBoxNewPassword.Text)

                    SignIn(True)

                Else

                    If ErrorMessage <> "" Then

                        Me.ShowMessage(MiscFN.JavascriptSafe(ErrorMessage))

                    End If

                End If

            Else

                Me.ShowMessage(Me.NoConnectionMessage)

            End If

        Else

            Me.AddListItem("The new passwords do not match.")

        End If

    End Sub
    Private Sub ButtonChangePasswordCancel_Click(sender As Object, e As EventArgs) Handles ButtonChangePasswordCancel.Click

        Me.ShowCell(CellType.defaultSignIn)
        Me.ShowSignInWindow()

    End Sub
    Private Sub AddListItem(Message)

        Me.LiteralMessages.Text &= String.Format("<li>{0}</li>", Message)

    End Sub

#End Region

#Region " Methods "
    Private Function LoadConnectionString() As String

        Dim ConnectionString As String = String.Empty

        If String.IsNullOrWhiteSpace(Me.TextBoxDataBase.Text) = False Then

            Dim ConnectionDatabaseProfile As AdvantageFramework.Database.ConnectionDatabaseProfile = Nothing
            Dim ConnectionDatabaseProfiles As Generic.List(Of AdvantageFramework.Database.ConnectionDatabaseProfile) = Nothing
            Dim AdminConnectionString As String = String.Empty
            Dim ErrorMessage As String = String.Empty
            Dim ChooseServer As Boolean = Me.ChooseServer()
            Dim ServerName As String = String.Empty

            ConnectionDatabaseProfiles = AdvantageFramework.Database.LoadConnectionDatabaseProfiles

            If ConnectionDatabaseProfiles IsNot Nothing AndAlso ConnectionDatabaseProfiles.Count > 0 Then

                For Each ConnectionDatabaseProfile In ConnectionDatabaseProfiles

                    If ChooseServer = True Then

                        If String.IsNullOrWhiteSpace(Me.TextBoxSQLServer.Text) = False Then

                            If ConnectionDatabaseProfile.ServerName = TextBoxSQLServer.Text AndAlso
                               ConnectionDatabaseProfile.DatabaseName = TextBoxDataBase.Text Then

                                ConnectionString = AdvantageFramework.Database.CreateConnectionString(ConnectionDatabaseProfile.ServerName,
                                                                                                      ConnectionDatabaseProfile.DatabaseName, False,
                                                                                                      ConnectionDatabaseProfile.UserName,
                                                                                                      ConnectionDatabaseProfile.GetDecryptPassword(),
                                                                                                      AdvantageFramework.Security.Application.Webvantage.ToString)

                                Me._SQLAdminUserName = ConnectionDatabaseProfile.UserName
                                Me._SQLAdminPassword = ConnectionDatabaseProfile.GetDecryptPassword()

                                Exit For

                            End If

                        Else

                            Me.ShowMessage("Please enter server.")

                        End If

                    Else

                        If ConnectionDatabaseProfile.DatabaseName = TextBoxDataBase.Text Then

                            ConnectionString = AdvantageFramework.Database.CreateConnectionString(ConnectionDatabaseProfile.ServerName,
                                                                                                  ConnectionDatabaseProfile.DatabaseName, False,
                                                                                                  ConnectionDatabaseProfile.UserName,
                                                                                                  ConnectionDatabaseProfile.GetDecryptPassword(),
                                                                                                  AdvantageFramework.Security.Application.Webvantage.ToString)

                            Me._SQLAdminUserName = ConnectionDatabaseProfile.UserName
                            Me._SQLAdminPassword = ConnectionDatabaseProfile.GetDecryptPassword()

                            Exit For

                        End If

                    End If

                Next

            End If

        Else

            Me.ShowMessage("Please enter database.")

        End If

        Return ConnectionString

    End Function
    Private Sub ShowSignInWindow()

        Me.PanelSignIn.Visible = True
        Me.PanelChangePassword.Visible = False
        Me.PanelLostPassword.Visible = False
        Me.LiteralSignInHeader.Text = "Sign In"
        Me.gmSignIn.Visible = False
        Me.gmWindowCell.Visible = False
        Me.DivTwoFactorEmailVisible(False)

    End Sub
    Public Function ShowChangePasswordWindow() As Boolean

        Dim ConnectionString As String = String.Empty
        Dim User As AdvantageFramework.Security.Classes.User = Nothing
        Dim Success As Boolean = False

        ConnectionString = Me.LoadConnectionString

        If String.IsNullOrWhiteSpace(ConnectionString) = False Then

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(ConnectionString, TextBoxUserID.Text)

                User = New AdvantageFramework.Security.Classes.User(AdvantageFramework.Security.Database.Procedures.User.LoadByUserCode(SecurityDbContext, TextBoxUserID.Text))

                If User IsNot Nothing AndAlso String.IsNullOrWhiteSpace(User.SID) Then

                    If AdvantageFramework.Security.UserHasGroupMembership(SecurityDbContext, User.ID, User.CheckForUserAccess) = True Then

                        Success = True
                        Me.PanelSignIn.Visible = False
                        Me.PanelChangePassword.Visible = True
                        Me.PanelLostPassword.Visible = False
                        Me.gmSignIn.Visible = False
                        Me.gmWindowCell.Visible = False
                        Me.DivTwoFactorEmailVisible(False)
                        Me.LiteralSignInHeader.Text = "Change Password"
                        Me.LiteralMessages.Text = ""

                    Else

                        Me.ShowMessage(AdvantageFramework.Security.Password.NoGroupMembershipMessage)

                    End If

                End If

            End Using

        Else

            Me.ShowMessage(Me.NoConnectionMessage)

        End If

        Return Success

    End Function
    Public Function ShowLostPasswordWindow() As Boolean

        Dim ConnectionString As String = String.Empty
        Dim User As AdvantageFramework.Security.Classes.User = Nothing
        Dim Success = False

        ConnectionString = Me.LoadConnectionString

        If String.IsNullOrWhiteSpace(ConnectionString) = False Then

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(ConnectionString, TextBoxUserID.Text)

                User = New AdvantageFramework.Security.Classes.User(AdvantageFramework.Security.Database.Procedures.User.LoadByUserCode(SecurityDbContext, TextBoxUserID.Text))

                If User IsNot Nothing AndAlso String.IsNullOrWhiteSpace(User.SID) Then

                    If AdvantageFramework.Security.UserHasGroupMembership(SecurityDbContext, User.ID, User.CheckForUserAccess) = True Then

                        Success = True
                        Me.PanelSignIn.Visible = False
                        Me.PanelChangePassword.Visible = False
                        Me.gmSignIn.Visible = False
                        Me.gmWindowCell.Visible = False
                        Me.PanelLostPassword.Visible = True
                        Me.LiteralSignInHeader.Text = "Reset Password"

                    Else

                        Me.ShowMessage(AdvantageFramework.Security.Password.NoGroupMembershipMessage)

                    End If

                End If

            End Using

        Else

            Me.ShowMessage(Me.NoConnectionMessage)

        End If

        Return Success

    End Function
    Private Sub ShowChangePasswordWithMessage(ByVal ConnectionString As String, ByVal UserName As String, ByRef Password As String, ByVal Message As String, ByRef DialogResult As AdvantageFramework.WinForm.MessageBox.DialogResults)

        If _ChangingPassword = False Then

            _ChangingPassword = True

            Me.RadAjaxManagerSignIn.ResponseScripts.Add("ShowMessage('" & HttpUtility.HtmlEncode(Message) & "');")
            TextBoxOldPassword.Attributes.Add("value", Password)

            Me.ShowChangePasswordWindow()

        End If

    End Sub
    Private Sub SetLogo(ByVal CurrentTheme As UserTheme)
        Try
            Select Case CurrentTheme.Settings.Logo

                Case "Light"

                    Me.ImageLogo.ImageUrl = "Images/Logos/aqualogo_FFFFFF.png"
                    'Me.ImageLongLiveTheAgency.ImageUrl = "Images/Logos/llta_FFFFFF.png"

                Case "Dark"

                    Me.ImageLogo.ImageUrl = "Images/Logos/aqualogo_252525.png"
                    'Me.ImageLongLiveTheAgency.ImageUrl = "Images/Logos/llta_252525.png"

                Case "Themed"

                    Me.ImageLogo.ImageUrl = "Images/Logos/aqualogo_" & CurrentTheme.Settings.SimpleLayoutSideBarColor.Replace("#", "") & ".png"
                    ' Me.ImageLongLiveTheAgency.ImageUrl = "Images/Logos/llta_" & CurrentTheme.Settings.SimpleLayoutSideBarColor.Replace("#", "") & ".png"

                Case Else

                    If CurrentTheme.Settings.FullPathToLogo <> "" Then

                        'Me.ImageLogo.ImageUrl = "Images/Logos/aqualogo_FFFFFF.png"
                        Me.ImageLogo.ImageUrl = CurrentTheme.Settings.FullPathToLogo
                        'Me.ImageLongLiveTheAgency.ImageUrl = CurrentTheme.Settings.FullPathToLogo.Replace("aqualogo_", "llta_")

                    Else

                        Me.ImageLogo.ImageUrl = "Images/Logos/aqualogo_FFFFFF.png"
                        'Me.ImageLongLiveTheAgency.ImageUrl = "Images/Logos/llta_FFFFFF.png"

                    End If

            End Select

            Me.ImageLongLiveTheAgency.ImageUrl = "Images/Logos/llta_" & CurrentTheme.Settings.SimpleLayoutSideBarColor.Replace("#", "") & ".png"

        Catch ex As Exception

            Me.ImageLongLiveTheAgency.ImageUrl = "Images/Logos/llta_FFFFFF.png"
            Me.ImageLogo.ImageUrl = "Images/Logos/aqualogo_FFFFFF.png"

        End Try
    End Sub
    Private Sub SetWallpaper(ByRef uTheme As UserTheme)

        Me.UseSolidColorBackground(uTheme.Settings.BackgroundColor)

        If uTheme.Settings.Agency_UseAgencyBranding = True Then

            If _IsClientPortal = True Then

                Me.UseSolidColorBackground(uTheme.Settings.BackgroundColor)
                Me.SideBarColor = uTheme.Settings.SimpleLayoutSideBarColor
                Me.BackgroundColor = uTheme.Settings.SimpleLayoutBackgroundColor

            Else

                Me.UseSolidColorBackground(uTheme.Settings.Agency_BackgroundColor)
                Me.SideBarColor = uTheme.Settings.Agency_SimpleLayoutSideBarColor
                Me.BackgroundColor = uTheme.Settings.Agency_SimpleLayoutBackgroundColor

            End If

        Else

            Me.UseSolidColorBackground(uTheme.Settings.BackgroundColor)
            Me.SideBarColor = uTheme.Settings.SimpleLayoutSideBarColor
            Me.BackgroundColor = uTheme.Settings.BackgroundColor

        End If
        If uTheme.Settings.Agency_UseAgencyBranding = False AndAlso
            uTheme.Settings.UseBackgroundColorOnSignInPage = False AndAlso
            String.IsNullOrWhiteSpace(Me.BackgroundColor) Then

            Me.UseDefaultBackground()

        End If
        If uTheme.Settings.IsDarkMode = True Then

            Me.DarkModeScript = "enableDarkMode();"

        End If
    End Sub
    Private Sub UseDefaultBackground()
        Dim sb As New System.Text.StringBuilder
        With sb
            .Append("background-color: #2196F3;")
            .Append(Environment.NewLine())
        End With
        Me.BackgroundCSS = sb.ToString()
    End Sub
    Private Sub UseSolidColorBackground(ByVal HtmlColor As String)
        If String.IsNullOrWhiteSpace(HtmlColor) = True Then
            HtmlColor = "#2196F3"
        End If
        Dim sb As New System.Text.StringBuilder
        With sb
            .Append("background-color: " & HtmlColor & ";")
        End With
        Me.BackgroundCSS = sb.ToString()
    End Sub
    Private Sub SignIn(ByVal ToNewApp As Boolean)

        Dim DbContext As AdvantageFramework.Database.DbContext = Nothing
        Dim SecuritySession As AdvantageFramework.Security.Session = Nothing
        Dim ErrorMessage As String = ""
        Dim WindowsIdentity As System.Security.Principal.WindowsIdentity = Nothing
        Dim User As String = ""
        Dim ConnectionString As String = ""
        Dim DatabaseName As String = ""
        Dim DatabaseNameCP As String = ""
        Dim AdminConnectionString As String = String.Empty
        Dim Application As AdvantageFramework.Security.Application = AdvantageFramework.Security.Application.Webvantage
        Dim ClientPortalUserName As String = ""
        Dim ClientPortalPassword As String = ""
        Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
        Dim SqlConnectionStringBuilder As System.Data.SqlClient.SqlConnectionStringBuilder = Nothing
        Dim SingleSignOnConnectionString As String = String.Empty

        If _IsClientPortal Then

            Application = AdvantageFramework.Security.Application.Client_Portal

            Try

                For Each ConnectionDatabaseProfile In AdvantageFramework.Database.LoadConnectionDatabaseProfiles()

                    If ConnectionDatabaseProfile.DatabaseName = TextBoxDataBase.Text.Trim Then

                        TextBoxSQLServer.Text = ConnectionDatabaseProfile.ServerName.Replace("#", "\")

                        ClientPortalUserName = ConnectionDatabaseProfile.UserName
                        ClientPortalPassword = ConnectionDatabaseProfile.GetDecryptPassword()

                        DatabaseNameCP = ConnectionDatabaseProfile.DatabaseName

                        Exit For

                    End If

                Next

            Catch ex As Exception
                Me.gmWindowCell.Visible = False
                Me.DivTwoFactorEmailVisible(False)
                Me.ShowMessage("There has been an error getting the database name.<br />Please check System Registry.<br />Client Portal is currently set to use the new registry key structure.")
                Exit Sub
            End Try

        Else

            WindowsIdentity = System.Security.Principal.WindowsIdentity.GetCurrent

            Try
                If _IsUsingTrustedConn = True Then

                    Me._NTAuthUserIgnoreCase = CType(System.Configuration.ConfigurationManager.AppSettings("NTAuthIgnoreCase").ToString(), Boolean)

                End If
            Catch ex As Exception
                Me._NTAuthUserIgnoreCase = False
            End Try

            DatabaseName = TextBoxDataBase.Text.Trim.ToUpper

            If _IsUsingTrustedConn = False Then

                Try
                    If System.Configuration.ConfigurationManager.AppSettings("UpperCaseUser").ToString.ToLower = "true" Then

                        TextBoxUserID.Text = TextBoxUserID.Text.ToUpper

                    End If
                Catch ex As Exception
                    Me.gmWindowCell.Visible = False
                    Me.DivTwoFactorEmailVisible(False)
                    Me.ShowMessage("Error uppercasing user id.")
                End Try

            End If

            If Me.ChooseServer = False Then

                Try

                    For Each ConnectionDatabaseProfile In AdvantageFramework.Database.LoadConnectionDatabaseProfiles()

                        If ConnectionDatabaseProfile.DatabaseName = TextBoxDataBase.Text.Trim Then

                            TextBoxSQLServer.Text = ConnectionDatabaseProfile.ServerName.Replace("#", "\")

                            _SQLAdminUserName = ConnectionDatabaseProfile.UserName
                            _SQLAdminPassword = ConnectionDatabaseProfile.GetDecryptPassword()

                            Exit For

                        End If

                    Next

                Catch ex As Exception
                    Me.gmWindowCell.Visible = False
                    Me.DivTwoFactorEmailVisible(False)
                    Me.ShowMessage("There has been an error getting the database name.<br />Please check System Registry.<br />Webvantage is currently set to use the new registry key structure.")
                    Exit Sub
                End Try

            Else

                If String.IsNullOrWhiteSpace(Me.TextBoxSQLServer.Text) = True Then

                    Me.ShowMessage("Please enter server.")
                    Exit Sub

                End If

            End If

            If _IsUsingTrustedConn = True Then

                TextBoxUserID.Text = My.User.Name

                If System.Configuration.ConfigurationManager.AppSettings("NewRegistryStructure").ToString.ToLower = "true" Then
                    Try
                        'loop through subkeys under server node
                        'if subkey name is same as me.txtdatabase.text, then keep parent subkey name as servername
                        'get username/password for sqladmin key
                        Dim StrArServerNames() As String
                        Dim StrArDatabaseNames() As String
                        Dim StrServerName As String = String.Empty
                        Dim StrDatabaseName As String = String.Empty

                        For Each ConnectionDatabaseProfile In AdvantageFramework.Database.LoadConnectionDatabaseProfiles()

                            If ConnectionDatabaseProfile.DatabaseName = TextBoxDataBase.Text.Trim Then

                                TextBoxSQLServer.Text = ConnectionDatabaseProfile.ServerName.Replace("#", "\")

                                If _SQLAdminUserName = String.Empty Or _SQLAdminUserName = "" Then

                                    _SQLAdminUserName = ConnectionDatabaseProfile.UserName

                                End If

                                If _SQLAdminPassword = String.Empty Or _SQLAdminPassword = "" Then

                                    _SQLAdminPassword = ConnectionDatabaseProfile.GetDecryptPassword()

                                End If

                                Exit For

                            End If

                        Next

                    Catch ex As Exception
                        Me.gmWindowCell.Visible = False
                        Me.DivTwoFactorEmailVisible(False)
                        Me.ShowMessage("Error building admin connection string using Windows Authentication and Registry.<br/>Please check System Registry.")
                        Exit Sub
                    End Try

                End If

            End If

        End If

        SingleSignOnConnectionString = Me.LoadConnectionString()

        If String.IsNullOrWhiteSpace(SingleSignOnConnectionString) = False Then

            Try

                Dim TwoFactor As New AdvantageFramework.Security.Password.TwoFactorAuthentication(SingleSignOnConnectionString, TextBoxUserID.Text)
                Dim AllowSignIn As Boolean = False
                Dim TwoFactorValidated As Boolean = False

                If TwoFactor.Mode = AdvantageFramework.Security.Password.TwoFactorAuthentication.Type.None Then

                    AllowSignIn = True

                Else

                    Select Case TwoFactor.Mode
                        Case AdvantageFramework.Security.Password.TwoFactorAuthentication.Type.Email

                            If Me.DivTwoFactorEmail.Visible = False Then

                                Me.DivTwoFactorEmailVisible(True)

                            End If
                            If Me.TwoFactorEmailSent = True Then

                                If String.IsNullOrWhiteSpace(Me.TextBoxTwoFactorEmailCode.Text.Trim) = True Then

                                    Me.ShowMessage("Please enter authentication code.")

                                Else

                                    If TwoFactor.HasValidUserCode = True Then

                                        If TwoFactor.Validate(Me.TextBoxTwoFactorEmailCode.Text.Trim) = True Then

                                            AllowSignIn = True
                                            TwoFactorValidated = True

                                        Else

                                            If String.IsNullOrWhiteSpace(TwoFactor.ErrorMessage) = False Then

                                                Me.ShowMessage(TwoFactor.ErrorMessage)
                                                Me.HideGodModeWindows()

                                            End If

                                        End If

                                    Else

                                        Me.ShowMessage("User ID not found.")
                                        Me.HideGodModeWindows()

                                        Me.TextBoxUserID.Focus()

                                    End If

                                End If

                            Else

                                If TwoFactor.SendTwoFactorAuthenticationEmail = True Then

                                    Me.HideGodModeWindows()

                                    Me.LabelTwoFactorEmailAddress.Text = TwoFactor.ObfuscatedEmailAddress

                                    Me.TwoFactorEmailSent = True
                                    Me.TextBoxTwoFactorEmailCode.Focus()

                                End If

                            End If

                        Case AdvantageFramework.Security.Password.TwoFactorAuthentication.Type.SecurityQuestion

                    End Select

                End If

                If AllowSignIn = True Then

                    Dim Success As Boolean = False
                    Dim RedirectURL As String = String.Empty

                    Success = AdvantageFramework.Security.Login(Application, DbContext, SecuritySession,
                                                                TextBoxSQLServer.Text, TextBoxDataBase.Text, _IsUsingTrustedConn,
                                                                TextBoxUserID.Text, TextBoxPassword.Text,
                                                                ClientPortalUserName,
                                                                ClientPortalPassword,
                                                                HttpContext.Current.Session.SessionID,
                                                                HttpContext.Current.Request.UserHostAddress,
                                                                SingleSignOnConnectionString, Me._SQLAdminUserName, ErrorMessage)

                    If Success = True Then

                        If TwoFactor.Mode = AdvantageFramework.Security.Password.TwoFactorAuthentication.Type.Email AndAlso TwoFactorValidated = True Then

                            TwoFactor.Clear()

                        End If

                        Session("CurrentSessionId") = HttpContext.Current.Session.SessionID

                        Try

                            LoGlo.UserCultureSet(RadComboBoxLanguage.SelectedValue)

                        Catch ex As Exception
                        End Try
                        Try

                            RedirectURL = FormsAuthentication.GetRedirectUrl(TextBoxUserID.Text, CheckBoxRememberMe.Checked)

                        Catch ex As Exception
                            Me.gmWindowCell.Visible = False
                            Me.DivTwoFactorEmailVisible(False)
                            RedirectURL = String.Empty
                        End Try
                        If _IsClientPortal Then

                            'ConnectionString = AdvantageFramework.Web.Security.Methods.BuildConnectionString(Me.TextBoxSQLServer.Text, DatabaseNameCP, ClientPortalUserName, ClientPortalPassword)
                            ConnectionString = SingleSignOnConnectionString
                            Session("ConnString") = ConnectionString
                            Session("EmpCode") = ""

                            If SecuritySession IsNot Nothing Then

                                Session("UserName") = SecuritySession.UserName
                                Session("UserID") = SecuritySession.ClientPortalUser.ClientContactID
                                Session("CL_CODE") = SecuritySession.ClientPortalUser.ClientCode
                                Session("UserGUID") = SecuritySession.ClientPortalUser.ID
                                Session("Admin") = SecuritySession.ClientPortalUser.IsAdminUser
                                Session("ContactName") = SecuritySession.ClientPortalUser.FullName
                                Session("DefaultContactCP") = SecuritySession.ClientPortalUser.AgencyContactEmployeeCode
                                Session("UserCode") = SecuritySession.UserCode
                                Response.Cookies("CookieCPClientCode").Expires = DateTime.Now.AddDays(90)
                                Response.Cookies("CookieCPClientCode").Value = SecuritySession.ClientPortalUser.ClientCode

                            End If
                            Try

                                Session("DBServerName") = TextBoxSQLServer.Text
                                Session("DBName") = DatabaseNameCP

                            Catch ex As Exception
                                Me.gmWindowCell.Visible = False
                                Me.DivTwoFactorEmailVisible(False)
                            End Try
                            Try

                                Using DataContext = New AdvantageFramework.Database.DataContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                                    Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.NEW_LICENSE_KEY.ToString)

                                End Using
                                If Setting Is Nothing OrElse Setting.Value = 0 Then

                                    Session("NewLicenseKey") = False

                                    If SecuritySession.RegisterSecuritySession(Session("CurrentSessionId").ToString()) = False Then

                                        Session("CurrentSessionId") = ""
                                        Me.TextBoxPassword.Focus()
                                        Me.ShowMessage(SecuritySession.RegisterSecuritySessionMessage)
                                        Exit Sub

                                    End If

                                Else

                                    Session("NewLicenseKey") = True
                                    Session("AdvantageUserLicenseInUseID") = SecuritySession.AdvantageUserLicenseInUseID

                                End If

                            Catch ex As Exception
                                Me.gmWindowCell.Visible = False
                                Me.DivTwoFactorEmailVisible(False)
                                Me.ShowMessage(ex.Message)
                                Exit Sub
                            End Try

                        Else 'webvantage

                            Session("UserLoginAuditID") = SecuritySession.UserLoginAuditID

                            Dim WebAppSettings As New AdvantageFramework.Web.Settings()

                            Try

                                ConnectionString = SingleSignOnConnectionString

                                If _IsUsingTrustedConn = True Then

                                    'ConnectionString = AdvantageFramework.Web.Security.Methods.BuildConnectionString(Me.TextBoxSQLServer.Text,
                                    '                                                                                 DatabaseName,
                                    '                                                                                 "", "")

                                    User = WindowsIdentity.Name.Substring(WindowsIdentity.Name.IndexOf("\") + 1)

                                Else

                                    'ConnectionString = AdvantageFramework.Web.Security.Methods.BuildConnectionString(Me.TextBoxSQLServer.Text,
                                    '                                                                                 DatabaseName,
                                    '                                                                                 TextBoxUserID.Text, TextBoxPassword.Text)

                                    User = TextBoxUserID.Text.Trim

                                End If

                            Catch ex As Exception
                                Me.gmWindowCell.Visible = False
                                Me.DivTwoFactorEmailVisible(False)
                                Me.ShowMessage("Error setting connection string.")
                            End Try
                            Try

                                If _SQLAdminUserName = "" Or _SQLAdminPassword = "" Then

                                    Session("AdminConnString") = Nothing

                                Else

                                    AdminConnectionString = AdvantageFramework.Web.Security.Methods.BuildAdminConnectionString(TextBoxSQLServer.Text,
                                                                                                                     DatabaseName,
                                                                                                                     _SQLAdminUserName, _SQLAdminPassword)

                                    Session("AdminConnString") = AdminConnectionString

                                End If

                            Catch ex As Exception
                                Me.gmWindowCell.Visible = False
                                Me.DivTwoFactorEmailVisible(False)
                            End Try
                            Try

                                Session("DBServerName") = TextBoxSQLServer.Text
                                Session("DBName") = DatabaseName

                            Catch ex As Exception
                                Me.gmWindowCell.Visible = False
                                Me.DivTwoFactorEmailVisible(False)
                            End Try

                            Dim oSecurity As cSecurity
                            oSecurity = New cSecurity(ConnectionString)

                            Try

                                If System.Configuration.ConfigurationManager.AppSettings("SQLControledAdmin").ToString.ToLower = "true" Then
                                    If TextBoxUserID.Text.ToUpper = "SYSADM" Then

                                        Session("Admin") = True
                                        _SQLAdminUserName = TextBoxUserID.Text.ToUpper
                                        _SQLAdminPassword = TextBoxPassword.Text

                                    Else

                                        Session("Admin") = False

                                    End If
                                Else
                                    If TextBoxUserID.Text.ToUpper = "SYSADM" Then

                                        Session("Admin") = True
                                        _SQLAdminUserName = TextBoxUserID.Text.ToUpper
                                        _SQLAdminPassword = TextBoxPassword.Text

                                    Else

                                        Session("Admin") = False

                                    End If
                                End If
                            Catch ex As Exception
                                Me.gmWindowCell.Visible = False
                                Me.DivTwoFactorEmailVisible(False)
                                Me.ShowMessage("Error setting admin.")
                            End Try
                            If User.ToUpper() = "SYSADM" Or TextBoxUserID.Text.ToUpper = "SYSADM" Then

                                Session("Admin") = True
                                _SQLAdminUserName = TextBoxUserID.Text.ToUpper
                                _SQLAdminPassword = TextBoxPassword.Text

                            End If

                            Try

                                Session("ConnString") = ConnectionString

                                If SecuritySession IsNot Nothing Then

                                    Session("Security_Session") = SecuritySession

                                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                                        Session("EmployeeName") = AdvantageFramework.Security.Database.Procedures.EmployeeView.LoadByEmployeeCode(SecurityDbContext, SecuritySession.User.EmployeeCode).ToString

                                    End Using

                                    Session("EmpCode") = SecuritySession.User.EmployeeCode
                                    Session("UserCode") = SecuritySession.User.UserCode
                                    Session("SecUserId") = SecuritySession.User.ID

                                End If

                            Catch ex As Exception
                                Me.gmWindowCell.Visible = False
                                Me.DivTwoFactorEmailVisible(False)
                                Me.ShowMessage("Error setting primary sessions.")
                                Exit Sub
                            End Try
                            Try

                                If SecuritySession IsNot Nothing Then

                                    Using DataContext = New AdvantageFramework.Database.DataContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                                        Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.NEW_LICENSE_KEY.ToString)

                                        If Setting Is Nothing OrElse Setting.Value = 0 Then

                                            Session("NewLicenseKey") = False

                                            If SecuritySession.RegisterSecuritySession(Session("CurrentSessionId").ToString()) = False Then

                                                Session("CurrentSessionId") = ""
                                                Me.TextBoxPassword.Focus()
                                                Me.ShowMessage(SecuritySession.RegisterSecuritySessionMessage)

                                                Exit Sub

                                            End If

                                        Else

                                            Session("NewLicenseKey") = True
                                            Session("AdvantageUserLicenseInUseID") = SecuritySession.AdvantageUserLicenseInUseID

                                        End If

                                        ''Try

                                        ''    DataContext.ExecuteCommand(String.Format("DELETE FROM CHAT_ACTIVE_USER WITH(ROWLOCK) WHERE USER_CODE = '{0}';", SecuritySession.UserCode))

                                        ''Catch ex As Exception
                                        ''End Try

                                    End Using

                                End If

                            Catch ex As Exception
                                Me.gmWindowCell.Visible = False
                                Me.DivTwoFactorEmailVisible(False)
                            End Try

                        End If
                        If cApplication.SetSignInCookie(Me.TextBoxSQLServer.Text, Me.TextBoxDataBase.Text, Me.TextBoxUserID.Text, Me.TextBoxPassword.Text,
                                                        Me.CheckBoxRememberMe.Checked, ErrorMessage) = False Then

                            Me.ShowMessage(ErrorMessage)

                        End If
                        If ToNewApp = False Then

                            Dim ar As String()

                            If IsNTAuth() = False Then

                                If RedirectURL.ToLower.Contains("alert_view") = True OrElse RedirectURL.ToLower.Contains("alertview") Then

                                    Try

                                        ar = RedirectURL.Split("?")

                                        If ar IsNot Nothing AndAlso ar.Length >= 2 Then

                                            FormsAuthentication.SetAuthCookie(TextBoxUserID.Text, CheckBoxRememberMe.Checked)
                                            RedirectURL = String.Format("Default.aspx?link=Desktop_AlertView${0}", ar(1))
                                            Response.Redirect(RedirectURL.Replace("alert=", "AlertID="), False)
                                            'RadAjaxManagerSignIn.ResponseScripts.Add(String.Format("goToPage('{0}');", RedirectURL))
                                            Exit Sub

                                        Else

                                            FormsAuthentication.RedirectFromLoginPage(TextBoxUserID.Text, CheckBoxRememberMe.Checked)

                                        End If

                                    Catch ex As Exception
                                        Me.gmWindowCell.Visible = False
                                        Me.DivTwoFactorEmailVisible(False)
                                        FormsAuthentication.RedirectFromLoginPage(TextBoxUserID.Text, CheckBoxRememberMe.Checked)
                                    End Try

                                Else

                                    FormsAuthentication.RedirectFromLoginPage(TextBoxUserID.Text, CheckBoxRememberMe.Checked)

                                End If

                            Else

                                If String.IsNullOrWhiteSpace(RedirectURL) = True OrElse RedirectURL.ToLower.Contains("signin.aspx") = True Then

                                    RedirectURL = "Default.aspx"

                                End If
                                If RedirectURL.Contains("Alert_View") = True OrElse RedirectURL.Contains("Desktop_AlertView") Then

                                    Try

                                        ar = RedirectURL.Split("?")

                                        If ar IsNot Nothing AndAlso ar.Length >= 2 Then

                                            RedirectURL = String.Format("Default.aspx?link=Desktop_AlertView${0}", ar(1))

                                        End If

                                    Catch ex As Exception
                                    End Try

                                End If

                                Response.Redirect(RedirectURL, False)
                                Exit Sub

                            End If

                        Else

                            FormsAuthentication.SetAuthCookie(TextBoxUserID.Text, CheckBoxRememberMe.Checked)
                            RedirectURL = String.Format("NewApp")
                            Response.Redirect(RedirectURL, True)

                        End If

                    Else

                        If _ChangingPassword = False Then

                            Me.ShowCell(CellType.defaultSignIn)

                            If TwoFactor.Mode = AdvantageFramework.Security.Password.TwoFactorAuthentication.Type.Email Then

                                If Me.DivTwoFactorEmail.Visible = False Then

                                    Me.DivTwoFactorEmailVisible(True)

                                End If

                            End If

                            If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                                If ErrorMessage.Contains("Failed creating user license") = True OrElse
                               ErrorMessage.Contains("Another browser session") = True Then

                                    Me.SignIn(False)

                                ElseIf ErrorMessage.Contains(AdvantageFramework.Security.Password.NewPasswordMessage) = True Then

                                    ErrorMessage = ErrorMessage.Replace(AdvantageFramework.Security.Password.NewPasswordMessage,
                                                                    AdvantageFramework.Security.Password.NewPasswordMessage & "<br/>")


                                End If

                                Me.ShowMessage(ErrorMessage)


                            End If

                        End If

                    End If

                End If

            Catch ex As Exception
                Me.gmWindowCell.Visible = False
                Me.DivTwoFactorEmailVisible(False)
                Me.ShowMessage(AdvantageFramework.StringUtilities.FullErrorToString(ex))
            End Try

        Else

            Me.gmWindowCell.Visible = False
            Me.DivTwoFactorEmailVisible(False)
            Me.ShowMessage(Me.NoConnectionMessage)

        End If

    End Sub
    Private Sub LinkButtonResendTwoFactorEmail_Click(sender As Object, e As EventArgs) Handles LinkButtonResendTwoFactorEmail.Click

        Dim SingleSignOnConnectionString As String = String.Empty
        Dim Password As String = String.Empty

        SingleSignOnConnectionString = Me.LoadConnectionString()

        If String.IsNullOrWhiteSpace(SingleSignOnConnectionString) = False Then

            Dim TwoFactor As New AdvantageFramework.Security.Password.TwoFactorAuthentication(SingleSignOnConnectionString, TextBoxUserID.Text)

            If Me.DivTwoFactorEmail.Visible = False Then

                Me.DivTwoFactorEmailVisible(True)

            End If

            'Me.TextBoxPassword.Text = ""
            Me.TextBoxTwoFactorEmailCode.Text = ""

            If TwoFactor.SendTwoFactorAuthenticationEmail = True Then

                Password = TextBoxPassword.Text

                TextBoxPassword.Attributes.Add("value", Password)

                Me.TextBoxTwoFactorEmailCode.Focus()

                Me.ShowMessage("New authorization code has been sent.")

            Else

                Me.ShowMessage("Failed sending new authorization code.  Please contact software support.")

            End If

        End If

    End Sub

    Private LastMessage As String = String.Empty
    Public Sub ShowMessage(ByVal ErrorMessage As String)

        Dim IsLastMessage As Boolean = False

        Me.CheckForBadEmailForgotPasswordMessage(ErrorMessage)

        If String.IsNullOrWhiteSpace(LastMessage) = False Then

            If ErrorMessage.ToLower().Contains(LastMessage.ToLower()) = True Then

                IsLastMessage = True

            End If

        End If

        If IsLastMessage = False Then

            LastMessage = ErrorMessage

            ErrorMessage = HttpUtility.JavaScriptStringEncode(ErrorMessage)

            Me.RadAjaxManagerSignIn.ResponseScripts.Add("ShowMessage('" & ErrorMessage & "');")
            Me.RadAjaxManagerSignIn.ResponseScripts.Add("enableButton();")

        End If

    End Sub
    Private Sub LinkButtonChangePassword_Click(sender As Object, e As EventArgs) Handles LinkButtonChangePassword.Click

        Me.ShowChangePasswordWindow()

    End Sub
    Private Sub LinkButtonLostPassword_Click(sender As Object, e As EventArgs) Handles LinkButtonLostPassword.Click

        If Me.ShowLostPasswordWindow() = True Then

            Me.DivLostPasswordEmailForm.Visible = False
            Me.DivLostPasswordSuccess.Visible = False
            Me.DivLostPasswordFail.Visible = False
            Me.LiteralEmailAddress.Text = ""
            Me.LiteralLostPasswordSuccess.Text = ""
            Me.LiteralLostPasswordFail.Text = ""

            Dim EmailAddress As String = String.Empty
            Dim ErrorMessage As String = String.Empty
            Dim ConnectionDatabaseProfile As AdvantageFramework.Database.ConnectionDatabaseProfile = Nothing
            Dim ConnectionDatabaseProfiles As Generic.List(Of AdvantageFramework.Database.ConnectionDatabaseProfile) = Nothing
            Dim HasPassword As Boolean = False

            'If String.IsNullOrWhiteSpace(Me.TextBoxSQLServer.Text) = True Then

            '    ErrorMessage = "Server is required."

            'End If
            If String.IsNullOrWhiteSpace(ErrorMessage) = True AndAlso String.IsNullOrWhiteSpace(Me.TextBoxDataBase.Text) = True Then

                ErrorMessage = "Database is required."

            End If
            If String.IsNullOrWhiteSpace(ErrorMessage) = True AndAlso String.IsNullOrWhiteSpace(Me.TextBoxUserID.Text) = True Then

                ErrorMessage = "User ID is required."

            End If
            Try

                If String.IsNullOrWhiteSpace(ErrorMessage) = True Then

                    ConnectionDatabaseProfiles = AdvantageFramework.Database.LoadConnectionDatabaseProfiles

                    If ConnectionDatabaseProfiles IsNot Nothing AndAlso ConnectionDatabaseProfiles.Count > 0 Then

                        For Each ConnectionDatabaseProfile In ConnectionDatabaseProfiles

                            If ConnectionDatabaseProfile.DatabaseName = TextBoxDataBase.Text Then

                                Exit For

                            End If

                        Next

                    End If

                    If ConnectionDatabaseProfile IsNot Nothing Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(ConnectionDatabaseProfile.GetConnectionString(AdvantageFramework.Security.Application.Webvantage), ConnectionDatabaseProfile.UserName)

                            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(ConnectionDatabaseProfile.GetConnectionString(AdvantageFramework.Security.Application.Webvantage), ConnectionDatabaseProfile.UserName)

                                Dim User As AdvantageFramework.Security.Database.Entities.User = Nothing

                                User = AdvantageFramework.Security.Database.Procedures.User.LoadByUserCode(SecurityDbContext, TextBoxUserID.Text.Trim)

                                If User IsNot Nothing AndAlso String.IsNullOrWhiteSpace(User.SID) Then

                                    EmailAddress = AdvantageFramework.Security.Database.Procedures.User.LoadEmailAddressByUserCode(SecurityDbContext, TextBoxUserID.Text.Trim)

                                    If String.IsNullOrWhiteSpace(EmailAddress) = False Then

                                        Me.LiteralEmailAddress.Text = AdvantageFramework.Security.Password.ObfuscateEmailAddress(EmailAddress)

                                    Else

                                        ErrorMessage = AdvantageFramework.Security.Password.NoEmailAddressMessage

                                    End If

                                Else

                                    ErrorMessage = "Invalid user."

                                End If

                            End Using

                        End Using

                    Else

                        ErrorMessage = "No connection."

                    End If

                End If

            Catch ex As Exception
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
            End Try

            If String.IsNullOrWhiteSpace(ErrorMessage) = True Then

                Me.DivLostPasswordEmailForm.Visible = True

            Else

                Me.DivLostPasswordFail.Visible = True
                Me.LiteralLostPasswordFail.Text = ErrorMessage

            End If

        End If

    End Sub
    Private Sub ButtonLostPasswordYes_Click(sender As Object, e As EventArgs) Handles ButtonLostPasswordYes.Click

        LostPasswordSend()

    End Sub
    Private Sub LostPasswordSend()

        Me.DivLostPasswordEmailForm.Visible = False

        Dim Message As String = String.Empty
        Dim ConnectionString As String = Me.LoadConnectionString

        Using DbContext = New AdvantageFramework.Database.DbContext(ConnectionString, Me._SQLAdminUserName)



        End Using

        If SendLostPasswordEmail(Message) = True Then

            Me.DivLostPasswordFail.Visible = False
            Me.DivLostPasswordSuccess.Visible = True

        Else

            Me.DivLostPasswordFail.Visible = True

            If String.IsNullOrWhiteSpace(Message) = False Then

                Me.CheckForBadEmailForgotPasswordMessage(Message)

                Me.LiteralLostPasswordFail.Text = Message

            End If

        End If

    End Sub
    Private Sub CheckForBadEmailForgotPasswordMessage(ByRef Message As String)

        If Message.ToLower().Contains("FailedToSend".ToLower()) = True Then

            Message = AdvantageFramework.Security.Password.BadEmailAddressMessage

        ElseIf Message.Contains("550 5.1.1") Then

            'Message &= "<br/>" & "Please contact"

        End If

    End Sub
    Private Sub ButtonLostPasswordNo_Click(sender As Object, e As EventArgs) Handles ButtonLostPasswordNo.Click

        Me.ShowCell(CellType.defaultSignIn)
        Me.ShowSignInWindow()

    End Sub
    Private Sub ButtonLostPasswordFailOK_Click(sender As Object, e As EventArgs) Handles ButtonLostPasswordFailOK.Click

        Me.ShowCell(CellType.defaultSignIn)
        Me.ShowSignInWindow()

    End Sub
    Private Sub ButtonLostPasswordSuccessOK_Click(sender As Object, e As EventArgs) Handles ButtonLostPasswordSuccessOK.Click

        Me.ShowCell(CellType.defaultSignIn)
        Me.ShowSignInWindow()

    End Sub
    Private Sub ButtonLostPasswordSuccessResend_Click(sender As Object, e As EventArgs) Handles ButtonLostPasswordSuccessResend.Click

        LostPasswordSend()

    End Sub
    Private Function SendLostPasswordEmail(ByRef Message As String) As Boolean

        Dim Sent As Boolean = True
        Dim EmailAddress As String = String.Empty
        Dim ErrorMessage As String = String.Empty
        Dim ConnectionDatabaseProfile As AdvantageFramework.Database.ConnectionDatabaseProfile = Nothing
        Dim HasPassword As Boolean = False
        Dim HasEmail As Boolean = False

        If Sent = False AndAlso String.IsNullOrWhiteSpace(Me.TextBoxDataBase.Text) = True Then

            Message = "Database is required."
            Sent = False

        End If
        If Sent = False AndAlso String.IsNullOrWhiteSpace(Me.TextBoxUserID.Text) = True Then

            Message = "User ID is required."
            Sent = False

        End If
        If Sent = True Then

            Try

                ConnectionDatabaseProfile = AdvantageFramework.Database.LoadConnectionDatabaseProfile(TextBoxDataBase.Text)

                If ConnectionDatabaseProfile IsNot Nothing Then

                    Dim ConnectionDatabaseProfile_UserName As String = ConnectionDatabaseProfile.UserName
                    Dim ConnectionDatabaseProfile_ConnectionString As String = ConnectionDatabaseProfile.GetConnectionString(AdvantageFramework.Security.Application.Webvantage)

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(ConnectionDatabaseProfile_ConnectionString,
                                                                                                 ConnectionDatabaseProfile_UserName)

                        Dim User As AdvantageFramework.Security.Database.Entities.User = Nothing

                        User = AdvantageFramework.Security.Database.Procedures.User.LoadByUserCode(SecurityDbContext, Me.TextBoxUserID.Text.Trim)

                        If User IsNot Nothing Then

                            Using DbContext = New AdvantageFramework.Database.DbContext(ConnectionDatabaseProfile_ConnectionString,
                                                                                        ConnectionDatabaseProfile_UserName)

                                If AdvantageFramework.Security.Password.SendPasswordChangeEmail(DbContext,
                                                                                                SecurityDbContext,
                                                                                                ConnectionDatabaseProfile.ServerName,
                                                                                                Me.TextBoxDataBase.Text,
                                                                                                Me.TextBoxUserID.Text,
                                                                                                HasPassword,
                                                                                                ErrorMessage) = True Then

                                    If HasPassword = False Then

                                        Message = AdvantageFramework.Security.Password.NewPasswordMessage &
                                                   "Check your email for further instructions."

                                    Else

                                        Message = "Check your email for further instructions."

                                    End If

                                    Sent = True

                                Else

                                    If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                                        Message = ErrorMessage

                                    Else

                                        Message = "Something went wrong."

                                    End If

                                    Sent = False

                                End If

                            End Using

                        Else

                            Message = "Cannot find user."
                            Sent = False

                        End If

                    End Using

                Else

                    Message = "No connection."
                    Sent = False

                End If

            Catch ex As Exception
                Sent = False
                Message = AdvantageFramework.StringUtilities.FullErrorToString(ex)
            End Try

            If String.IsNullOrWhiteSpace(ErrorMessage) = False AndAlso ErrorMessage.Contains("550 5.1.1") Then

                ErrorMessage = AdvantageFramework.Security.Password.BadEmailAddressMessage

            End If

        End If

        Return Sent

    End Function
    Private Enum CellType
        defaultSignIn = 0
        adminSignIn = 1
        adminForm = 2
    End Enum
    Private Sub ShowCell(ByVal c As CellType)
        Select Case c
            Case CellType.defaultSignIn

                Me.signInWindowsCell.Visible = True
                Me.gmSignIn.Visible = False
                Me.gmWindowCell.Visible = False
                Me._IsServerSignIn = False
                Me.DivTwoFactorEmailVisible(False)

            Case CellType.adminSignIn

                Me.TextBoxDataBase1.Text = Me.TextBoxDataBase.Text

                Me.PanelAdminSignInServerInput.Visible = Me.ChooseServer

                Me.signInWindowsCell.Visible = False
                Me.gmSignIn.Visible = True
                Me.gmWindowCell.Visible = False
                Me._IsServerSignIn = True
                Me.DivTwoFactorEmailVisible(False)

            Case CellType.adminForm

                Me.signInWindowsCell.Visible = False
                Me.gmSignIn.Visible = False
                Me.gmWindowCell.Visible = True
                Me._IsServerSignIn = True
                Me.DivTwoFactorEmailVisible(False)

        End Select

    End Sub
    Private Sub HideGodModeWindows()

        Me.gmSignIn.Visible = False
        Me.gmWindowCell.Visible = False

    End Sub
    Private Sub ButtonLogin1_Click(sender As Object, e As EventArgs) Handles ButtonLogin1.Click

        Dim ConnectionString As String = String.Empty
        Dim RedirectURL As String = String.Empty
        Dim o As String = Today.Date.ToShortDateString
        Dim ErrorMessage As String = String.Empty
        Dim ServerName As String = String.Empty

        If ChooseServer = False Then

            For Each ConnectionDatabaseProfile In AdvantageFramework.Database.LoadConnectionDatabaseProfiles()

                If ConnectionDatabaseProfile.DatabaseName = TextBoxDataBase1.Text.Trim Then

                    ServerName = ConnectionDatabaseProfile.ServerName.Replace("#", "\")

                    _SQLAdminUserName = ConnectionDatabaseProfile.UserName
                    _SQLAdminPassword = ConnectionDatabaseProfile.GetDecryptPassword()

                    Exit For

                End If

            Next

        Else

            If String.IsNullOrWhiteSpace(Me.TextBoxSQLServer1.Text) = True Then

                Me.ShowMessage("Please enter server.")
                Exit Sub

            Else

                ServerName = Me.TextBoxSQLServer1.Text

            End If

        End If
        If String.IsNullOrWhiteSpace(Me.TextBoxDataBase1.Text) = True Then

            Me.ShowMessage("Please enter database.")
            Exit Sub

        End If
        If String.IsNullOrWhiteSpace(Me.TextBoxUserID1.Text) = True Then

            Me.ShowMessage("Please enter User ID.")
            Exit Sub

        End If
        If String.IsNullOrWhiteSpace(Me.TextBoxPassword1.Text) = True Then

            Me.ShowMessage("Please enter password.")
            Exit Sub

        End If

        ConnectionString = AdvantageFramework.Database.CreateConnectionString(ServerName,
                                                                              Me.TextBoxDataBase1.Text,
                                                                              False,
                                                                              Me.TextBoxUserID1.Text,
                                                                              Me.TextBoxPassword1.Text,
                                                                              AdvantageFramework.Security.Application.Webvantage_Password_Admin.ToString)

        If String.IsNullOrWhiteSpace(ConnectionString) = False Then

            If AdvantageFramework.Security.ValidateLoginConnectionString(AdvantageFramework.Security.Application.Webvantage_Password_Admin,
                                                                         ConnectionString,
                                                                         ErrorMessage) = True Then

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(ConnectionString, Me.TextBoxUserID1.Text)

                    Me._IsServerAdmin = AdvantageFramework.Security.IsUserSqlServerServerAdmin(SecurityDbContext,
                                                                                               Me.TextBoxUserID1.Text,
                                                                                               ErrorMessage)

                    If Me._IsServerAdmin = False Then

                        ConnectionString = String.Empty

                    End If

                End Using

            Else

                ConnectionString = String.Empty

            End If

        End If
        If String.IsNullOrWhiteSpace(ConnectionString) = False Then

            Me._IsServerSignIn = True
            FormsAuthentication.SetAuthCookie(TextBoxUserID.Text, False)

            Dim s As String = String.Empty

            s = AdvantageFramework.Web.EncryptDeepLinkQueryString(ServerName &
                                                                "__0__" &
                                                                TextBoxDataBase1.Text &
                                                                "__0__" &
                                                                Today.Date.ToShortDateString &
                                                                "__0__" &
                                                                TextBoxUserID1.Text &
                                                                "__0__" &
                                                                TextBoxPassword1.Text)


            RedirectURL = String.Format("Account/GM/Actions?x={0}", s)

            FormsAuthentication.SetAuthCookie(TextBoxUserID1.Text, False)

            Me.adminIframe.Src = RedirectURL

            Me.ShowCell(CellType.adminForm)

        Else

            If String.IsNullOrWhiteSpace(ErrorMessage) = True Then

                ErrorMessage = "<strong>Invalid admin</strong><br/><br/>Please check you User ID and Password."

            End If

            If ErrorMessage.Contains("Could not open a connection to SQL Server") = True Then

                ErrorMessage = ErrorMessage.Replace(" (provider: Named Pipes Provider, error: 40 - Could not open a connection to SQL Server)", "")

            End If

            ErrorMessage = ErrorMessage.Replace(".", ".<br/>")

            Me.ShowMessage(ErrorMessage)

        End If

    End Sub

#End Region

End Class
