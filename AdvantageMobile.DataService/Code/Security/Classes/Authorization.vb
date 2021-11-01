Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Collections.Specialized
Imports System.DirectoryServices.AccountManagement
Imports System.Linq
Imports System.Security.Cryptography
Imports System.Security.Principal
Imports System.Text
Imports System.Web

Namespace AdvantageMobile.DataService.Security

    <System.Serializable()> Public Class Authorization

#Region " Constants "

        Private Const _Salt As String = "narTteyuhTmartreBrekarP"
        Private Const _DataServiceUserSessionKey As String = "DSUSKDSUSK"

#End Region

#Region " Enum "

        Public Enum Type

            None = 0
            Basic = 1

        End Enum

#End Region

#Region " Variables "

        Private _Hasher As HashAlgorithm = New SHA1CryptoServiceProvider()
        Private _Roles As String() = New String() {"User", "Admin"}

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Function Authorize(ByRef context As HttpContext,
                                  ByRef DataServiceUser As DataServiceUser,
                                  ByRef ErrorMessage As String) As Boolean

            Dim IsAuthenticated As Boolean = context.User.Identity.IsAuthenticated
            Dim Credentials As New AdvantageFramework.Mobile.Classes.Credential(context.Request.Headers("PBTT20071002"))
            Dim sec As New AdvantageMobile.DataService.Security.Methods(Nothing)

            If Credentials.IsConfigSet = False Then

                Credentials.UpperCaseUser = System.Configuration.ConfigurationManager.AppSettings("UpperCaseUser").ToString().ToLower() = "true"
                Credentials.UpperCaseDatabase = System.Configuration.ConfigurationManager.AppSettings("UpperCaseDatabase").ToString().ToLower() = "true"
                Credentials.ChooseServer = System.Configuration.ConfigurationManager.AppSettings("ChooseServer").ToString().ToLower() = "true"
                Credentials.SqlControlledAdmin = System.Configuration.ConfigurationManager.AppSettings("SQLControledAdmin").ToString().ToLower() = "true"
                Credentials.NTAuthIgnoreCase = System.Configuration.ConfigurationManager.AppSettings("NTAuthIgnoreCase").ToString().ToLower() = "true"

                Credentials.IsConfigSet = True

            End If

            If Credentials.UpperCaseUser = True Then Credentials.UserCode = Credentials.UserCode.ToUpper()
            If Credentials.UpperCaseDatabase = True Then Credentials.DatabaseName = Credentials.DatabaseName.ToUpper()

            context.User = GetPrincipalFromCredentials(Credentials)

            If LoadDataServiceUser(Credentials, DataServiceUser) Then

                If Credentials.IsWindowsAuth = False Then

                    Try

                        IsAuthenticated = context.User.Identity.IsAuthenticated

                    Catch ex As Exception
                        IsAuthenticated = False
                    End Try

                Else

                    Dim DomainName As String = String.Empty
                    Dim UserName As String = String.Empty

                    If Credentials.UserCode.Contains("\") = True Then

                        Dim ar As String()

                        ar = Credentials.UserCode.Split("\")

                        If ar.Length = 2 Then

                            DomainName = ar(0)
                            UserName = ar(1)

                        End If

                        Using pc = New PrincipalContext(ContextType.Domain, DomainName)

                            IsAuthenticated = pc.ValidateCredentials(UserName, DataServiceUser.Password)

                            DataServiceUser.IsValid = IsAuthenticated

                            If IsAuthenticated = False Then

                                ErrorMessage = "Invalid domain credentials"

                            End If

                        End Using

                    Else

                        'Need to include domain
                        ErrorMessage = "Please include domain name"
                        IsAuthenticated = False

                    End If

                End If

                DataServiceUser.IsValid = IsAuthenticated
                DataServiceUser.ErrorMessage = ErrorMessage

            End If

            Return DataServiceUser.IsValid

        End Function
        Private Function LoadDataServiceUser(ByVal CurrentCredentials As AdvantageFramework.Mobile.Classes.Credential,
                                             ByRef DataServiceUser As DataServiceUser) As Boolean

            Dim sec As New AdvantageMobile.DataService.Security.Methods(Nothing)
            Dim ValidConnection As Boolean = True

            ValidConnection = sec.ValidateConnectionString(CurrentCredentials)

            If ValidConnection = True Then

                DataServiceUser.DatabaseServer = CurrentCredentials.ServerName
                DataServiceUser.DatabaseName = CurrentCredentials.DatabaseName
                DataServiceUser.UserCode = CurrentCredentials.UserCode

                If DataServiceUser.UserCode.Contains("\") = True Then

                    DataServiceUser.UserCode = DataServiceUser.UserCode.Substring(DataServiceUser.UserCode.IndexOf("\") + 1)

                End If

                DataServiceUser.Password = CurrentCredentials.Password
                DataServiceUser.ConnectionString = sec.CreateConnectionString(CurrentCredentials.ServerName,
                                                                              CurrentCredentials.DatabaseName,
                                                                              CurrentCredentials.UserCode,
                                                                              CurrentCredentials.Password,
                                                                              CurrentCredentials.IsWindowsAuth,
                                                                              CurrentCredentials.ChooseServer,
                                                                              DataServiceUser.SSOUserCode)

                If String.IsNullOrWhiteSpace(DataServiceUser.DatabaseServer) = True AndAlso String.IsNullOrWhiteSpace(CurrentCredentials.ServerName) = False Then

                    DataServiceUser.DatabaseServer = CurrentCredentials.ServerName

                End If

                DataServiceUser.IsValid = True

                HttpContext.Current.Session(_DataServiceUserSessionKey) = DataServiceUser

            Else

                DataServiceUser.IsValid = False

            End If

            Return DataServiceUser.IsValid

        End Function
        Private Function GetPrincipalFromCredentials(ByVal CurrentCredentials As AdvantageFramework.Mobile.Classes.Credential) As IPrincipal

            Try

                Dim Identity As New System.Security.Principal.GenericIdentity(CurrentCredentials.GenericIdentity)
                Dim Principal As New GenericPrincipal(Identity, _Roles)

                Return Principal

            Catch ex As Exception
                Return Nothing
            End Try

        End Function
        Private Function ParseAuthHeader(ByVal header As String) As String()

            If String.IsNullOrEmpty(header) Then

                Return Nothing

            End If

            Dim cred = Encoding.ASCII.GetString(Convert.FromBase64String(header)).Split(":"c)

            If cred.Length <> 11 Then

                Return Nothing

            Else

                Return cred

            End If

        End Function

        Public Function Base64Encode(ByVal [String] As String) As String
            Dim bytesToEncode As Byte()
            bytesToEncode = Encoding.ASCII.GetBytes([String])
            Return Convert.ToBase64String(bytesToEncode)
        End Function
        Public Function Base64Decode(ByVal EncodedString As String) As String
            Dim decodedBytes As Byte()
            decodedBytes = Convert.FromBase64String(EncodedString)
            Return Encoding.ASCII.GetString(decodedBytes)
        End Function
        Private Function GetSaltedHash(ByVal password As String) As String

            Return Convert.ToBase64String(_Hasher.ComputeHash(Encoding.ASCII.GetBytes(password & _Salt)))

        End Function

        Sub New()

        End Sub

#End Region

    End Class

End Namespace
