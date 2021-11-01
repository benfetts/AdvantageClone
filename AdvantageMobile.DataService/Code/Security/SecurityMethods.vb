Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Data.Services
Imports System.Data.Services.Common
Imports System.Data.Services.Providers
Imports System.Data.SqlClient
Imports System.Linq
Imports System.ServiceModel.Web
Imports System.Web
Imports System.Diagnostics
Imports System.Collections.Specialized
Imports System.Security.Principal
Imports System.Text
Imports System.Security.Cryptography
Imports Microsoft.Win32
Imports AdvantageFramework.Mobile.Classes
Imports System.Collections

Namespace AdvantageMobile.DataService.Security

    <System.Serializable()> Public Class Methods

#Region " Constants "

        Private Const RegistrySubKey As String = "Connections"

#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private Shared Hasher As HashAlgorithm = New SHA1CryptoServiceProvider()

#End Region

#Region " Properties "

        Private Property _DataEntities As DataEntities
        Private Property _ConnectionString As String = ""
        Public Property Token As String = ""

#End Region

#Region " Methods "
        Public Function IsValidDatabase() As Boolean

            Try

                Dim WebConfigVersion As String = String.Empty
                Dim DatabaseVersion As String = String.Empty

                Try

                    WebConfigVersion = System.Configuration.ConfigurationManager.AppSettings("MinimumDatabaseVersion").ToString().ToLower()

                Catch ex As Exception

                End Try

                Try

                    DatabaseVersion = Me._DataEntities.Database.SqlQuery(Of String)(String.Format("SELECT ISNULL(VERSION_ID, '') FROM ADVAN_UPDATE WITH(NOLOCK);")).FirstOrDefault()

                Catch ex As Exception
                    DatabaseVersion = String.Empty
                End Try

                If String.IsNullOrWhiteSpace(WebConfigVersion) = True OrElse String.IsNullOrWhiteSpace(DatabaseVersion) = True Then

                    Return True

                Else

                    If DatabaseVersion >= WebConfigVersion = True Then

                        Return True

                    Else

                        Return False

                    End If

                End If

            Catch ex As Exception
                Return True
            End Try

        End Function
        Public Function CreateConnectionString(ByRef DatabaseServerName As String,
                                               ByVal DatabaseName As String,
                                               ByVal UserCode As String, ByVal Password As String,
                                               ByVal IsWindowsAuth As Boolean,
                                               ByVal ChooseServer As Boolean,
                                               ByRef SSOUserCode As String) As String

            Dim ConnectionDatabaseProfile As AdvantageFramework.Database.ConnectionDatabaseProfile = Nothing
            Dim ConnectionDatabaseProfiles As Generic.List(Of AdvantageFramework.Database.ConnectionDatabaseProfile) = Nothing
            Dim ConnectionString As String = String.Empty
            Dim AdminConnectionString As String = String.Empty
            Dim ErrorMessage As String = String.Empty

            If String.IsNullOrWhiteSpace(DatabaseServerName) = True Then

                LoadRegistrySignIn(DatabaseName, DatabaseServerName, UserCode, Password)

            End If
            If String.IsNullOrWhiteSpace(DatabaseServerName) = False AndAlso
                String.IsNullOrWhiteSpace(DatabaseName) = False Then

                ConnectionDatabaseProfiles = AdvantageFramework.Database.LoadConnectionDatabaseProfiles

                If ConnectionDatabaseProfiles IsNot Nothing AndAlso ConnectionDatabaseProfiles.Count > 0 Then

                    For Each ConnectionDatabaseProfile In ConnectionDatabaseProfiles

                        If ConnectionDatabaseProfile.ServerName = DatabaseServerName AndAlso
                           ConnectionDatabaseProfile.DatabaseName = DatabaseName Then

                            SSOUserCode = ConnectionDatabaseProfile.UserName

                            ConnectionString = AdvantageFramework.Database.CreateConnectionString(ConnectionDatabaseProfile.ServerName,
                                                                                                  ConnectionDatabaseProfile.DatabaseName, False,
                                                                                                  ConnectionDatabaseProfile.UserName,
                                                                                                  ConnectionDatabaseProfile.GetDecryptPassword(),
                                                                                                  AdvantageFramework.Security.Application.Webvantage.ToString)
                            Exit For

                        End If

                    Next

                End If

            End If

            Return ConnectionString

        End Function
        Public Function GetMobileUser(ByVal DataServiceUser As DataServiceUser) As MobileUser

            Dim MobileUser As New MobileUser
            Dim DatabaseUser As SecurityUser = Nothing
            Dim Employee As Global.AdvantageMobile.Employee = Nothing
            Dim SSO_aka_NTAuth As Boolean = False

            SSO_aka_NTAuth = System.Configuration.ConfigurationManager.AppSettings("Authentication").ToString().ToLower().Contains("win")

            MobileUser.ServerName = DataServiceUser.DatabaseServer
            MobileUser.DatabaseName = DataServiceUser.DatabaseName
            MobileUser.UserCode = DataServiceUser.UserCode
            MobileUser.Password = DataServiceUser.Password

            MobileUser.IsValid = DataServiceUser.IsValid

            MobileUser.UpperCaseUser = System.Configuration.ConfigurationManager.AppSettings("UpperCaseUser").ToString().ToLower() = "true"
            MobileUser.UpperCaseDatabase = System.Configuration.ConfigurationManager.AppSettings("UpperCaseDatabase").ToString().ToLower() = "true"
            MobileUser.ChooseServer = System.Configuration.ConfigurationManager.AppSettings("ChooseServer").ToString().ToLower() = "true"
            MobileUser.SqlControlledAdmin = System.Configuration.ConfigurationManager.AppSettings("SQLControledAdmin").ToString().ToLower() = "true"
            MobileUser.NTAuthIgnoreCase = System.Configuration.ConfigurationManager.AppSettings("NTAuthIgnoreCase").ToString().ToLower() = "true"
            MobileUser.IsConfigSet = True

            If MobileUser.UpperCaseUser = True Then MobileUser.UserCode = MobileUser.UserCode.ToUpper()
            If MobileUser.UpperCaseDatabase = True Then MobileUser.DatabaseName = MobileUser.DatabaseName.ToUpper()

            MobileUser.IsValidDatabase = Me.IsValidDatabase()

            If MobileUser.IsValidDatabase = True Then




                DatabaseUser = Me.GetSecurityUser(MobileUser.UserCode, MobileUser.UpperCaseUser)

                If DatabaseUser IsNot Nothing Then

                    If SSO_aka_NTAuth = True Then

                        If DataServiceUser.IsValid = False Then

                            MobileUser.IsValid = False
                            MobileUser.IsSignedIn = False
                            If String.IsNullOrWhiteSpace(MobileUser.ThemeWin8) = True Then MobileUser.ThemeWin8 = DataServiceUser.ErrorMessage

                        Else

                            MobileUser.IsValid = True
                            MobileUser.IsSignedIn = True
                            MobileUser.ThemeWin8 = ""

                        End If

                    Else

                        If DatabaseUser.PASSWORD = AdvantageFramework.Security.Encryption.EncryptPassword(MobileUser.Password.Trim()) Then

                            MobileUser.IsValid = True

                        Else

                            MobileUser.IsValid = False
                            MobileUser.IsSignedIn = False
                            If String.IsNullOrWhiteSpace(MobileUser.ThemeWin8) = True Then MobileUser.ThemeWin8 = "Wrong password."

                        End If

                    End If

                    If MobileUser.IsValid = True Then

                        MobileUser.UserCode = DatabaseUser.UserCode

                        If MobileUser.UpperCaseUser = True Then

                            MobileUser.UserCode = MobileUser.UserCode.ToUpper()

                        End If

                        Employee = (From Entity In Me._DataEntities.Employees
                                    Where Entity.Code = DatabaseUser.EmployeeCode).FirstOrDefault()

                        If Employee IsNot Nothing Then

                            MobileUser.EmployeeCode = Employee.Code
                            MobileUser.DepartmentTeamCode = Employee.DepartmentTeamCode
                            MobileUser.DefaultFunctionCode = Employee.DefaultFunctionCode
                            MobileUser.IsValid = True
                            MobileUser.IsSignedIn = True

                        Else

                            MobileUser.IsValid = False
                            MobileUser.IsSignedIn = False
                            If String.IsNullOrWhiteSpace(MobileUser.ThemeWin8) = True Then MobileUser.ThemeWin8 = "Invalid employee associated with this user."

                        End If

                    Else

                        MobileUser.IsValid = False
                        MobileUser.IsSignedIn = False
                        If String.IsNullOrWhiteSpace(MobileUser.ThemeWin8) = True Then MobileUser.ThemeWin8 = "Invalid user."

                    End If

                Else

                    MobileUser.IsValid = False
                    MobileUser.IsSignedIn = False
                    If String.IsNullOrWhiteSpace(MobileUser.ThemeWin8) = True Then MobileUser.ThemeWin8 = "Invalid user."

                End If

            Else

                MobileUser.IsValidDatabase = False
                MobileUser.IsValid = False
                MobileUser.IsSignedIn = False
                If String.IsNullOrWhiteSpace(MobileUser.ThemeWin8) = True Then MobileUser.ThemeWin8 = "Invalid database."

            End If

            If String.IsNullOrWhiteSpace(MobileUser.ThemeWin8) = True Then MobileUser.ThemeWin8 = ""

            Return MobileUser

        End Function
        Public Function GetSecurityUser(ByVal UserCode As String, ByVal UpperCaseUser As Boolean) As SecurityUser

            Try

                If UpperCaseUser = True Then

                    GetSecurityUser = (From SecurityUser In Me._DataEntities.SecurityUsers
                                       Where SecurityUser.UserCode.ToUpper = UserCode.ToUpper Or
                                       SecurityUser.UserName.ToUpper = UserCode.ToUpper).FirstOrDefault()

                Else

                    GetSecurityUser = (From SecurityUser In Me._DataEntities.SecurityUsers
                                       Where SecurityUser.UserCode = UserCode Or
                                       SecurityUser.UserName = UserCode).FirstOrDefault()

                End If

            Catch ex As Exception
                Application.ErrorToEventLog(ex)
                Return Nothing
            End Try

        End Function
        Public Function LoadRegistrySignIn(ByRef DatabaseName As String,
                                           ByRef ServerName As String,
                                           ByRef SQLAdminUserName As String,
                                           ByRef SQLAdminPassword As String) As Boolean

            Dim Found As Boolean = False

            DatabaseName = DatabaseName.Trim()

            'Get registry values:
            Dim objRK As RegistryKey = Nothing
            Dim rkDatabaseNames As RegistryKey
            Dim rkDatabase As RegistryKey

            Try

                objRK = Registry.LocalMachine.OpenSubKey("SOFTWARE").OpenSubKey("Advantage").OpenSubKey(RegistrySubKey)

            Catch ex As Exception
                Application.AddToEventLog("Error opening Advantage registry key.", EventLogEntryType.Error)
            End Try
            Try

                Dim ServerNames() As String
                Dim DatabaseNames() As String

                Dim StrServerName As String = ""
                Dim StrDatabaseName As String = ""

                ServerNames = objRK.GetSubKeyNames

                If ServerNames IsNot Nothing Then

                    For i As Integer = 0 To ServerNames.Length - 1 'string array has all server names

                        StrServerName = ServerNames(i).ToString()
                        rkDatabaseNames = Registry.LocalMachine.OpenSubKey("SOFTWARE").OpenSubKey("Advantage").OpenSubKey(RegistrySubKey).OpenSubKey(StrServerName)
                        DatabaseNames = rkDatabaseNames.GetSubKeyNames()

                        For j As Integer = 0 To DatabaseNames.Length - 1 'string array has all databases under this server

                            StrDatabaseName = DatabaseNames(j).ToString()

                            If StrDatabaseName = DatabaseName Then 'this is the key we're looking for

                                ServerName = ServerNames(i).ToString.Replace("#", "\")
                                rkDatabase = Registry.LocalMachine.OpenSubKey("SOFTWARE").OpenSubKey("Advantage").OpenSubKey(RegistrySubKey).OpenSubKey(StrServerName).OpenSubKey(StrDatabaseName)

                                If SQLAdminUserName = String.Empty OrElse SQLAdminUserName = "" Then

                                    SQLAdminUserName = rkDatabase.GetValue("Username", "")

                                End If
                                If SQLAdminPassword = String.Empty OrElse SQLAdminPassword = "" Then

                                    SQLAdminPassword = rkDatabase.GetValue("Password", "")

                                End If

                                Found = True

                                Exit For

                            End If

                        Next

                        If Found = True Then Exit For

                    Next

                End If

            Catch ex As Exception
                Application.AddToEventLog("There has been an error getting the database name.<br />Please check System Registry.", EventLogEntryType.Error)
            End Try

            Return Found

        End Function
        Public Function SignIn(ByVal ServerName As String,
                               ByVal DatabaseName As String, ByVal UseWindowsAuthentication As Boolean,
                               ByVal UserName As String, ByVal Password As String,
                               ByVal ChooseServer As Boolean,
                               ByVal SessionID As String) As Integer

            Dim Application As AdvantageFramework.Security.Application = AdvantageFramework.Security.Application.Mobile_DataService
            Dim ErrorMessage As String = ""
            Dim LicenseSet As Boolean = False
            Dim AdvantageUserLicenseInUseID As Integer = 0
            Dim ConnectionString As String = String.Empty
            Dim SecuritySession As AdvantageFramework.Security.Session = Nothing
            Dim SSOUserCode As String = String.Empty
            Dim ClientPortalUserName As String = String.Empty
            Dim ClientPortalPassword As String = String.Empty
            Dim IPAddress As String = String.Empty

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.CreateConnectionString(ServerName,
                                                                                                  DatabaseName,
                                                                                                  UserName,
                                                                                                  Password,
                                                                                                  UseWindowsAuthentication,
                                                                                                  ChooseServer,
                                                                                                  SSOUserCode),
                                                                                                  UserName)

                LicenseSet = AdvantageFramework.Security.Login(Application, DbContext,
                                                               SecuritySession, ServerName,
                                                               DatabaseName, UseWindowsAuthentication, UserName,
                                                               Password, ClientPortalUserName, ClientPortalPassword,
                                                               SessionID, IPAddress, ConnectionString, UserName, ErrorMessage)

                If LicenseSet = True Then

                    AdvantageUserLicenseInUseID = SecuritySession.AdvantageUserLicenseInUseID

                End If

            End Using

            Return AdvantageUserLicenseInUseID

        End Function
        Public Function SignOut(ByVal ServerName As String,
                                ByVal DatabaseName As String, ByVal UseWindowsAuthentication As Boolean,
                                ByVal UserName As String, ByVal Password As String,
                                ByVal ChoosServer As Boolean,
                                ByVal AdvantageUserLicenseInUseID As Integer) As Integer

            'Me._DataEntities.Database.ExecuteSqlCommand(String.Format("DELETE FROM AULU WITH(ROWLOCK) WHERE AULU_ID = {0}; UPDATE SEC_USER WITH(ROWLOCK) SET WEB_ID = NULL WHERE USER_CODE = '{1}';", AdvantageUserLicenseInUseID, UserName))
            'Return True

            Dim SignedOut As Boolean = False

            Dim License As Global.AdvantageMobile.SecurityLicense
            License = (From Licenses In Me._DataEntities.SecurityLicenses
                       Where Licenses.ID = AdvantageUserLicenseInUseID
                       Select Licenses).SingleOrDefault()

            If License IsNot Nothing Then

                Me._DataEntities.SecurityLicenses.Attach(License)
                Me._DataEntities.SecurityLicenses.Remove(License)
                Me._DataEntities.SaveChanges()

                Dim ThisUser As Global.AdvantageMobile.SecurityUser

                ThisUser = (From Users In Me._DataEntities.SecurityUsers
                            Where Users.UserCode = UserName
                            Select Users).SingleOrDefault()

                If ThisUser IsNot Nothing Then

                    ThisUser.WebSessionID = Nothing

                    Me._DataEntities.SecurityUsers.Attach(ThisUser)
                    Dim entry = Me._DataEntities.Entry(ThisUser)
                    entry.Property("WebSessionID").IsModified = True
                    Me._DataEntities.SaveChanges()
                    SignedOut = True

                End If


            End If

            If SignedOut = True Then

                Return 0

            Else

                Return AdvantageUserLicenseInUseID

            End If

        End Function
        Private Sub UpperCaseSignInInfo(ByRef DatabaseName As String, ByRef UserName As String)

            If System.Configuration.ConfigurationManager.AppSettings("UpperCaseDatabase").ToString().ToLower() = "true" Then DatabaseName = DatabaseName.ToUpper()
            If System.Configuration.ConfigurationManager.AppSettings("UpperCaseUser").ToString().ToLower() = "true" Then UserName = UserName.ToUpper()

        End Sub
        Public Function ValidateConnectionString(ByRef Credentials As AdvantageFramework.Mobile.Classes.Credential) As Boolean

            Dim IsValid As Boolean = False
            Dim err As String = ""
            Dim SSOUserCode As String = String.Empty

            Me._ConnectionString = CreateConnectionString(Credentials.ServerName,
                                                          Credentials.DatabaseName,
                                                          Credentials.UserCode,
                                                          Credentials.Password,
                                                          Credentials.IsWindowsAuth,
                                                          Credentials.ChooseServer,
                                                          SSOUserCode)

            IsValid = AdvantageFramework.Database.TestConnectionString(Me._ConnectionString, err)

            If err <> "" Then

                AdvantageMobile.DataService.Application.AddToEventLog(err & Environment.NewLine & "Connection: " & Me._ConnectionString, EventLogEntryType.Warning)

            End If

            If IsValid = False Then

                Me._ConnectionString = ""

            End If

            Credentials.Invalid = Not IsValid

            Return IsValid

        End Function

        Sub New(ByVal DataSource As DataEntities)

            Me._DataEntities = DataSource

        End Sub

#End Region

    End Class

End Namespace
