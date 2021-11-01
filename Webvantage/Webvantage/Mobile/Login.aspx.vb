Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Security
Imports Microsoft.Win32
Imports Webvantage.cGlobals.Globals
Imports Webvantage.MiscFN
Imports System.Web.Mobile
Imports System.Web.UI.MobileControls

Partial Public Class Login1
    Inherits System.Web.UI.Page

    Private IsUsingTrustedConn As Boolean
    Private strSQLAdminUserName As String = String.Empty
    Private strSQLAdminPassword As String = String.Empty
    Private ChooseServer As Boolean
    Private NTAuthUserIgnoreCase As Boolean = False

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try

            System.Web.Mobile.MobileFormsAuthentication.SignOut()

            Me.TrTrusted.Visible = False
            If MiscFN.IsNTAuth = True Then
                chkTrusted.Checked = True
                IsUsingTrustedConn = True
                TrUserID.Visible = False
                TrPassword.Visible = False
            Else
                chkTrusted.Checked = False
                IsUsingTrustedConn = False
                TrUserID.Visible = True
                TrPassword.Visible = True
            End If

            ChooseServer = CType(System.Configuration.ConfigurationManager.AppSettings("ChooseServer"), Boolean)
            Me.trSQLServer.Visible = ChooseServer

            If Page.IsPostBack = False Then
                Session.Abandon()
                FormsAuthentication.SignOut()
                Try
                    If Not Request.Cookies("Server") Is Nothing Then
                        Me.txtSQLServer.Text = Request.Cookies("Server").Value
                    End If
                    If Not Request.Cookies("DataBase") Is Nothing Then
                        Me.txtDataBase.Text = Request.Cookies("DataBase").Value
                    End If
                    ''Remove per Scott
                    'If Not Request.Cookies("UserCode") Is Nothing And Not Request.Cookies("UserCode").Value Is Nothing Then
                    '    Me.txtUserID.Text = Decrypt(Request.Cookies("UserCode").Value)
                    'End If
                    If Not Request.Cookies("Remember") Is Nothing And Not Request.Cookies("Remember").Value Is Nothing Then
                        Me.chkRemember.Checked = Request.Cookies("Remember").Value
                    End If
                Catch ex As Exception
                End Try
            End If

            Try
                If Me.txtSQLServer.Visible = True And Me.txtSQLServer.Text.Trim = "" Then
                    MiscFN.SetFocus(Me.txtSQLServer)
                Else
                    If Me.txtPassword.Visible = True Then
                        MiscFN.SetFocus(Me.txtPassword)
                    End If
                End If
            Catch ex As Exception
            End Try

        Catch ex As Exception
            lblMessage.Text = "Error:  " & ex.Message.ToString
        Finally
        End Try

        Try
            strSQLAdminUserName = System.Configuration.ConfigurationManager.AppSettings("SQLAdminUserName")
            strSQLAdminPassword = System.Configuration.ConfigurationManager.AppSettings("SQLAdminPassword")
            'Can't do this with mobile controls
            ' Me.txtPassword.Attributes.Add("onkeypress", "capLock(event)")
        Catch ex As Exception
        End Try

    End Sub

    Private Sub btnLogin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogin.Click

        'objects
        Dim DbContext As AdvantageFramework.Database.DbContext = Nothing
        Dim SecuritySession As AdvantageFramework.Security.Session = Nothing
        Dim ErrorMessage As String = ""
        Dim ntUser As System.Security.Principal.WindowsIdentity = System.Security.Principal.WindowsIdentity.GetCurrent
        Dim strUser As String
        Dim oUser As cUser
        Dim oSecurity As cSecurity
        Dim strConnString As String
        Dim CookieArray As Array
        Dim strDBName As String
        Dim sPassword As String
        Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing

        sPassword = Me.txtPassword.Text

        Try
            If IsUsingTrustedConn = True Then
                Me.NTAuthUserIgnoreCase = CType(System.Configuration.ConfigurationManager.AppSettings("NTAuthIgnoreCase").ToString(), Boolean)
            End If
        Catch ex As Exception
            Me.NTAuthUserIgnoreCase = False
        End Try

        Try
            If System.Configuration.ConfigurationManager.AppSettings("UpperCaseDatabase").ToString.ToLower = "true" Then
                strDBName = txtDataBase.Text.Trim.ToUpper
            Else
                strDBName = txtDataBase.Text.Trim
            End If
        Catch ex As Exception
            Me.lblMessage.Text = "Error uppercasing database."
        End Try

        Try
            If System.Configuration.ConfigurationManager.AppSettings("UpperCaseUser").ToString.ToLower = "true" Then
                Me.txtUserID.Text = Me.txtUserID.Text.ToUpper
            End If

        Catch ex As Exception
            Me.lblMessage.Text = "Error uppercasing user id."
        End Try

        If System.Configuration.ConfigurationManager.AppSettings("ChooseServer").ToString.ToLower = "true" Then
            Try
                Response.Cookies("Server").Value = Me.txtSQLServer.Text
                Response.Cookies("Server").Expires = DateTime.Now.AddDays(30)
                Response.Cookies("DataBase").Value = strDBName
                Response.Cookies("DataBase").Expires = DateTime.Now.AddDays(30)
            Catch ex As Exception
                Me.lblMessage.Text = "Error setting server and database cookie."
            End Try
        Else
            Try
                Response.Cookies("Server").Expires = DateTime.Now.AddDays(-1)
                Response.Cookies("DataBase").Expires = DateTime.Now.AddDays(-1)
            Catch ex As Exception
                Me.lblMessage.Text = "Error clearing server and database cookie."
            End Try
            'Get registry values:
            Dim objRK As RegistryKey
            Dim ThisServer As String
            Dim rkDatabaseNames As RegistryKey
            Dim rkDatabase As RegistryKey
            Try
                objRK = Registry.LocalMachine.OpenSubKey("SOFTWARE").OpenSubKey("Advantage").OpenSubKey("Servers")
            Catch ex As Exception
                Me.lblMessage.Text = "Error opening Advantage registry key.<br />Please verify the DBRegEditor has been properly run."
            End Try
            Try
                'loop through subkeys under server node
                'if subkey name is same as me.txtdatabase.text, then keep parent subkey name as servername
                'get username/password for sqladmin key
                Dim StrArServerNames() As String
                Dim StrArDatabaseNames() As String
                Dim StrServerName As String = String.Empty
                Dim StrDatabaseName As String = String.Empty

                StrArServerNames = objRK.GetSubKeyNames
                For i As Integer = 0 To StrArServerNames.Length - 1 'string array has all server names
                    StrServerName = StrArServerNames(i).ToString() '.Replace("#", "\")
                    rkDatabaseNames = Registry.LocalMachine.OpenSubKey("SOFTWARE").OpenSubKey("Advantage").OpenSubKey("Servers").OpenSubKey(StrServerName)
                    StrArDatabaseNames = rkDatabaseNames.GetSubKeyNames
                    For j As Integer = 0 To StrArDatabaseNames.Length - 1 'string array has all databases under this server
                        StrDatabaseName = StrArDatabaseNames(j).ToString
                        If StrDatabaseName = Me.txtDataBase.Text.Trim Then 'this is the key we're looking for
                            Me.txtSQLServer.Text = StrArServerNames(i).ToString.Replace("#", "\")
                            rkDatabase = Registry.LocalMachine.OpenSubKey("SOFTWARE").OpenSubKey("Advantage").OpenSubKey("Servers").OpenSubKey(StrServerName).OpenSubKey(StrDatabaseName)
                            If strSQLAdminUserName = String.Empty Or strSQLAdminUserName = "" Then
                                strSQLAdminUserName = rkDatabase.GetValue("Username", "")
                            End If
                            If strSQLAdminPassword = String.Empty Or strSQLAdminPassword = "" Then
                                strSQLAdminPassword = rkDatabase.GetValue("Password", "")
                            End If
                        End If
                    Next
                Next
            Catch ex As Exception
                Me.lblMessage.Text = "There has been an error getting the database name.<br />Please check System Registry.<br />Webvantage is currently set to use the new registry key structure."
                Exit Sub
            End Try

        End If

        Try
            If IsUsingTrustedConn = True Then
                strConnString = "Persist Security Info=False;Data Source=" & Me.txtSQLServer.Text
                strConnString &= ";Initial Catalog=" & strDBName
                strConnString &= ";Trusted_Connection=yes;Application Name=Webvantage;"
                'strConnString &= "Pooling=False;Connect Timeout=1200;Connection Lifetime=15;Connection Reset=False;Max Pool Size=1;"
                strUser = ntUser.Name.Substring(ntUser.Name.IndexOf("\") + 1)
            Else
                strConnString = "Persist Security Info=False;Data Source=" & Me.txtSQLServer.Text
                strConnString &= ";Initial Catalog=" & strDBName
                strConnString &= ";User ID=" & Me.txtUserID.Text & ";Password=" & sPassword
                'strConnString &= ";Pooling=False;Application Name=Webvantage;Connect Timeout=120;Connection Lifetime=15;Connection Reset=True;Max Pool Size=1;"
                strUser = Me.txtUserID.Text.Trim
            End If

        Catch ex As Exception
            Me.lblMessage.Text = "Error setting connection string."
        End Try

        If IsUsingTrustedConn = True Then
            Dim objRK As RegistryKey
            Dim ThisServer As String
            Dim rkDatabaseNames As RegistryKey
            Dim rkDatabase As RegistryKey
            Try
                objRK = Registry.LocalMachine.OpenSubKey("SOFTWARE").OpenSubKey("Advantage").OpenSubKey("Servers")

            Catch ex As Exception
                Me.lblMessage.Text = "Error opening Advantage registry key.<br />Please verify the DBRegEditor has been properly run."
            End Try

            Try
                'loop through subkeys under server node
                'if subkey name is same as me.txtdatabase.text, then keep parent subkey name as servername
                'get username/password for sqladmin key
                Dim StrArServerNames() As String
                Dim StrArDatabaseNames() As String
                Dim StrServerName As String = String.Empty
                Dim StrDatabaseName As String = String.Empty

                StrArServerNames = objRK.GetSubKeyNames
                For i As Integer = 0 To StrArServerNames.Length - 1 'string array has all server names
                    StrServerName = StrArServerNames(i).ToString() '.Replace("#", "\")
                    rkDatabaseNames = Registry.LocalMachine.OpenSubKey("SOFTWARE").OpenSubKey("Advantage").OpenSubKey("Servers").OpenSubKey(StrServerName)
                    StrArDatabaseNames = rkDatabaseNames.GetSubKeyNames
                    For j As Integer = 0 To StrArDatabaseNames.Length - 1 'string array has all databases under this server
                        StrDatabaseName = StrArDatabaseNames(j).ToString
                        If StrDatabaseName = Me.txtDataBase.Text.Trim Then 'this is the key we're looking for

                            Me.txtSQLServer.Text = StrArServerNames(i).ToString.Replace("#", "\")

                            rkDatabase = Registry.LocalMachine.OpenSubKey("SOFTWARE").OpenSubKey("Advantage").OpenSubKey("Servers").OpenSubKey(StrServerName).OpenSubKey(StrDatabaseName)
                            If strSQLAdminUserName = String.Empty Or strSQLAdminUserName = "" Then
                                strSQLAdminUserName = rkDatabase.GetValue("Username", "")
                            End If
                            If strSQLAdminPassword = String.Empty Or strSQLAdminPassword = "" Then
                                strSQLAdminPassword = rkDatabase.GetValue("Password", "")
                            End If
                        End If
                    Next
                Next
            Catch ex As Exception
                Me.lblMessage.Text = "Error building admin connection string using Windows Authentication and Registry.<br/>Please check System Registry."
                Exit Sub
            End Try
        End If

        Try

            If AdvantageFramework.Security.Login(AdvantageFramework.Security.Application.Webvantage, DbContext, SecuritySession, txtSQLServer.Text,
                                                 strDBName, IsUsingTrustedConn, txtUserID.Text, txtPassword.Text, HttpContext.Current.Session.SessionID, "", ErrorMessage) Then

                Try

                    If IsUsingTrustedConn = True Then

                        strConnString = "Persist Security Info=False;Data Source=" & Me.txtSQLServer.Text
                        strConnString &= ";Initial Catalog=" & strDBName
                        strConnString &= ";Trusted_Connection=yes;Application Name=Webvantage;"
                        'strConnString &= "Pooling=False;Connect Timeout=1200;Connection Lifetime=15;Connection Reset=False;Max Pool Size=1;"
                        strUser = ntUser.Name.Substring(ntUser.Name.IndexOf("\") + 1)

                    Else

                        strConnString = "Persist Security Info=False;Data Source=" & Me.txtSQLServer.Text
                        strConnString &= ";Initial Catalog=" & strDBName
                        strConnString &= ";User ID=" & Me.txtUserID.Text & ";Password=" & sPassword
                        'strConnString &= ";Pooling=False;Application Name=Webvantage;Connect Timeout=120;Connection Lifetime=15;Connection Reset=True;Max Pool Size=1;"

                        strUser = Me.txtUserID.Text.Trim

                    End If

                Catch ex As Exception
                    Me.lblMessage.Text = "Error setting connection string."
                End Try

                Try
                    Dim strAdminConnString As String = String.Empty
                    If strSQLAdminUserName = "" Or strSQLAdminPassword = "" Then
                        Session("AdminConnString") = ""
                    Else
                        strAdminConnString = "Persist Security Info=False;Data Source=" & Me.txtSQLServer.Text
                        strAdminConnString &= ";Initial Catalog=" & strDBName
                        strAdminConnString &= ";User ID=" & strSQLAdminUserName & ";Password=" & strSQLAdminPassword
                        'strAdminConnString &= ";Pooling=False;Application Name=Webvantage;Connect Timeout=120;Connection Lifetime=60;Connection Reset=True;Max Pool Size=1;"

                        Session("AdminConnString") = strAdminConnString
                    End If

                Catch ex As Exception
                End Try

                Try
                    Session("DBServerName") = Me.txtSQLServer.Text
                    Session("DBName") = strDBName
                Catch ex As Exception
                End Try

                Try
                    If System.Configuration.ConfigurationManager.AppSettings("SQLControledAdmin").ToString.ToLower = "true" Then
                        Session("Admin") = oUser.Admin
                    Else
                        If Me.txtUserID.Text.ToUpper = "SYSADM" Then
                            Session("Admin") = True
                            strSQLAdminUserName = Me.txtUserID.Text.ToUpper
                            strSQLAdminPassword = sPassword
                        Else
                            Session("Admin") = False
                        End If
                    End If

                Catch ex As Exception
                    Me.lblMessage.Text = "Error setting admin."
                End Try

                If strUser.ToUpper() = "SYSADM" Or txtUserID.Text.ToUpper = "SYSADM" Then
                    Session("Admin") = True
                    strSQLAdminUserName = txtUserID.Text.ToUpper
                    strSQLAdminPassword = txtPassword.Text
                End If

                Try
                    Session("ConnString") = strConnString

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                        Session("EmployeeName") = AdvantageFramework.Security.Database.Procedures.EmployeeView.LoadByEmployeeCode(SecurityDbContext, SecuritySession.User.EmployeeCode).ToString

                    End Using

                    Session("EmpCode") = SecuritySession.User.EmployeeCode
                    Session("UserCode") = SecuritySession.User.UserCode
                    Session("SecUserId") = SecuritySession.User.ID

                Catch ex As Exception
                    Response.Write("Error setting primary sessions.")
                    Exit Sub
                End Try

                Try

                    Using DataContext = New AdvantageFramework.Database.DataContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                        Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.NEW_LICENSE_KEY.ToString)

                    End Using

                    Dim CurrentSessionId = HttpContext.Current.Session.SessionID

                    If Setting Is Nothing OrElse Setting.Value = 0 Then

                        Session("NewLicenseKey") = False

                        If SecuritySession.RegisterSecuritySession(CurrentSessionId) = False Then
                            Session("CurrentSessionId") = ""
                            Me.txtPassword.Focus()
                            Me.lblMessage.Text = SecuritySession.RegisterSecuritySessionMessage
                            Exit Sub
                        Else
                            Session("CurrentSessionId") = CurrentSessionId
                        End If

                    Else

                        Session("NewLicenseKey") = True

                        Session("CurrentSessionId") = CurrentSessionId

                        Session("AdvantageUserLicenseInUseID") = SecuritySession.AdvantageUserLicenseInUseID

                    End If

                Catch ex As Exception
                End Try

                If Me.chkRemember.Checked = True Then
                    Try
                        With Response
                            .Cookies("Server").Value = Me.txtSQLServer.Text
                            .Cookies("Server").Expires = DateTime.Now.AddDays(14)

                            .Cookies("Database").Value = Me.txtDataBase.Text
                            .Cookies("Database").Expires = DateTime.Now.AddDays(14)

                            .Cookies("UserName").Value = Encrypt(oUser.EmployeeName)
                            .Cookies("UserName").Expires = DateTime.Now.AddDays(14)

                            ''Remove per Scott
                            '.Cookies("UserCode").Value = Encrypt(strUser)
                            '.Cookies("UserCode").Expires = DateTime.Now.AddDays(14)

                            .Cookies("EmpCode").Value = Encrypt(oUser.EmployeeCode)
                            .Cookies("EmpCode").Expires = DateTime.Now.AddDays(14)

                            .Cookies("Admin").Value = Encrypt(Session("Admin"))
                            .Cookies("Admin").Expires = DateTime.Now.AddDays(14)

                            .Cookies("SQLConn2").Expires = DateTime.Now.AddDays(14)

                            .Cookies("Remember").Value = "True"
                            .Cookies("Remember").Expires = DateTime.Now.AddDays(14)

                        End With
                    Catch ex As Exception

                    End Try
                    'Auto remember mobile 
                Else
                    Try
                        With Response
                            .Cookies("Server").Expires = DateTime.Now.AddDays(-1)
                            .Cookies("Database").Expires = DateTime.Now.AddDays(-1)
                            .Cookies("UserName").Expires = DateTime.Now.AddDays(-1)
                            ''Remove per Scott
                            '.Cookies("UserCode").Expires = DateTime.Now.AddDays(-1)
                            .Cookies("EmpCode").Expires = DateTime.Now.AddDays(-1)
                            .Cookies("Admin").Expires = DateTime.Now.AddDays(-1)
                            .Cookies("SQLConn").Expires = DateTime.Now.AddDays(-1)
                            .Cookies("SQLConn2").Expires = DateTime.Now.AddDays(-1)
                            .Cookies("Remember").Value = "True"
                            .Cookies("Remember").Expires = DateTime.Now.AddDays(-1)
                            .Cookies("MobilePassword").Expires = DateTime.Now.AddDays(-1)
                        End With
                    Catch ex As Exception

                    End Try
                End If

                FormsAuthentication.SetAuthCookie(Me.txtUserID.Text, Me.chkRemember.Checked)
                Dim oCookie As HttpCookie = HttpContext.Current.Response.Cookies(FormsAuthentication.FormsCookieName)
                oCookie.Expires = DateTime.Now.AddYears(1) 'set cookie to 1 year (pain to retype login on handheld each time asp.net 2.0 attaches persistant to page timeout so we need to set this manually
                MiscFN.ResponseRedirect("~/mobile/default.aspx")

            Else

                lblMessage.Text = ErrorMessage

            End If

        Catch ex As Exception
        End Try
    End Sub
End Class
