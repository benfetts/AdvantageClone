Imports Kendo.Mvc.Extensions
Imports MvcCodeRouting.Web.Mvc
Imports Newtonsoft.Json
Imports System
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.IO
Imports System.Linq
Imports System.Threading
Imports System.Web
Imports System.Web.Mvc
Imports System.Web.Routing
Imports Webvantage.Controllers
Imports Webvantage.ViewModels

Namespace Controllers.Account

    <Serializable()>
    Public Class PasswordController
        Inherits MVCControllerBase

#Region " Constants "

        Public Const SessionKey As String = "PBTTLOLT20152100703211002"

#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Controller As AdvantageFramework.Controller.Account.PasswordController = Nothing

#End Region

#Region " Properties "



#End Region

#Region " MVC Views"

        <AllowAnonymous>
        Public Function Index() As System.Web.Mvc.ActionResult

            Dim IndexViewModel As New AdvantageFramework.ViewModels.UserAccount.PasswordIndexViewModel
            Dim ErrorMessage As String = String.Empty
            Dim ConnectionString As String = String.Empty
            Dim ConnectionStringUserName As String = String.Empty
            Dim SqlConnectionStringBuilder As System.Data.SqlClient.SqlConnectionStringBuilder = Nothing
            'Dim Admin As MiscFN.Admin = Nothing
            Dim User As AdvantageFramework.Security.Database.Entities.User = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim P As AdvantageFramework.Security.Classes.Password = Nothing
            Dim ConnectionDatabaseProfile As AdvantageFramework.Database.ConnectionDatabaseProfile = Nothing
            Dim ConnectionDatabaseProfiles As Generic.List(Of AdvantageFramework.Database.ConnectionDatabaseProfile) = Nothing
            Dim HasPassword As Boolean = False
            Dim WriteDebugMessageToEventLog As Boolean = False
            Dim HasConnectionString As Boolean = False

            Try

                If String.IsNullOrWhiteSpace(Me.CurrentQueryString.Get("dl")) = False Then

                    P = AdvantageFramework.Security.Password.PasswordObjectFromQueryString(Me.CurrentQueryString, ErrorMessage)

                    If P IsNot Nothing AndAlso P.IsValid = True Then

                        If String.IsNullOrWhiteSpace(P.ConnectionString) = True OrElse String.IsNullOrWhiteSpace(P.ConnectionUserName) = True Then

                            ConnectionDatabaseProfiles = AdvantageFramework.Database.LoadConnectionDatabaseProfiles

                            If ConnectionDatabaseProfiles IsNot Nothing AndAlso ConnectionDatabaseProfiles.Count > 0 Then

                                For Each ConnectionDatabaseProfile In ConnectionDatabaseProfiles

                                    If ConnectionDatabaseProfile.ServerName.ToUpper = P.ServerName.ToUpper AndAlso ConnectionDatabaseProfile.DatabaseName = P.DatabaseName Then

                                        ConnectionString = ConnectionDatabaseProfile.GetConnectionString(AdvantageFramework.Security.Application.Webvantage)
                                        ConnectionStringUserName = ConnectionDatabaseProfile.UserName
                                        HasConnectionString = True
                                        Exit For

                                    End If

                                Next

                            End If

                        Else

                            ConnectionString = P.ConnectionString
                            ConnectionStringUserName = P.ConnectionUserName
                            HasConnectionString = True

                        End If
                        If HasConnectionString = True Then

                            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(ConnectionString, ConnectionStringUserName)

                                If SecurityDbContext IsNot Nothing Then

                                    User = AdvantageFramework.Security.Database.Procedures.User.LoadByUserCode(SecurityDbContext, P.UserCode)

                                    If User IsNot Nothing Then

                                        Using DbContext = New AdvantageFramework.Database.DbContext(ConnectionString, ConnectionStringUserName)

                                            If DbContext IsNot Nothing Then

                                                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByUserCode(DbContext, P.UserCode)

                                                If Employee IsNot Nothing Then

                                                    IndexViewModel.FirstName = Employee.FirstName
                                                    IndexViewModel.LastName = Employee.LastName
                                                    IndexViewModel.FullName = Employee.ToString

                                                    If String.IsNullOrWhiteSpace(Employee.ReplyToEmail) = False Then

                                                        IndexViewModel.EmailAddress = Employee.ReplyToEmail

                                                    Else

                                                        IndexViewModel.EmailAddress = Employee.Email

                                                    End If

                                                    IndexViewModel.IsValid = True
                                                    IndexViewModel.Message = String.Empty

                                                Else

                                                    IndexViewModel.IsValid = False
                                                    IndexViewModel.Message = "Invalid employee!"

                                                End If

                                            Else

                                                IndexViewModel.IsValid = False
                                                IndexViewModel.Message = "Invalid connection!"

                                            End If

                                        End Using

                                        If String.IsNullOrWhiteSpace(User.Password) = False Then

                                            HasPassword = True

                                        End If

                                    Else

                                        IndexViewModel.IsValid = False
                                        IndexViewModel.Message = "Invalid user!"
                                        WriteDebugMessageToEventLog = True

                                    End If

                                Else

                                    IndexViewModel.IsValid = False
                                    IndexViewModel.Message = "Invalid connection!"

                                End If

                            End Using

                        Else

                            IndexViewModel.IsValid = False
                            IndexViewModel.Message = "No connection!"

                        End If

                    Else

                        IndexViewModel.IsValid = False
                        IndexViewModel.Message = "Invalid data!"

                    End If

                Else

                    IndexViewModel.IsValid = False
                    IndexViewModel.Message = "No data!"

                End If

                WriteDebugMessageToEventLog = False
                If WriteDebugMessageToEventLog = True Then

                    Try

                        Dim ConnectionDatabaseProfile_Conn As String = String.Empty
                        Dim ConnectionDatabaseProfile_User As String = String.Empty
                        Dim P_ServerName As String = String.Empty
                        Dim P_DatabaseName As String = String.Empty
                        Dim P_UserCode As String = String.Empty
                        Dim DebugMessage As String = String.Empty
                        Dim MatchCount As Integer = 0

                        If ConnectionDatabaseProfile IsNot Nothing Then

                            ConnectionDatabaseProfile_Conn = AdvantageFramework.Security.Encryption.Encrypt(ConnectionDatabaseProfile.GetConnectionString(AdvantageFramework.Security.Application.Webvantage))
                            ConnectionDatabaseProfile_User = AdvantageFramework.Security.Encryption.Encrypt(ConnectionDatabaseProfile.UserName)

                        End If

                        P_ServerName = AdvantageFramework.Security.Encryption.Encrypt(P.ServerName)
                        P_DatabaseName = AdvantageFramework.Security.Encryption.Encrypt(P.DatabaseName)
                        P_UserCode = AdvantageFramework.Security.Encryption.Encrypt(P.UserCode)

                        DebugMessage = ":: FAIL AUDIT :: PASSWORD FAILURE :: " & vbCrLf & vbCrLf
                        DebugMessage &= "DEBUG :: ONE: " & ConnectionDatabaseProfile_Conn & vbCrLf
                        DebugMessage &= "DEBUG :: TWO: " & ConnectionDatabaseProfile_User & vbCrLf
                        DebugMessage &= "DEBUG :: THREE: " & P_ServerName & vbCrLf
                        DebugMessage &= "DEBUG :: FOUR: " & P_DatabaseName & vbCrLf
                        DebugMessage &= "DEBUG :: FIVE: " & P_UserCode & vbCrLf
                        DebugMessage &= "DEBUG :: SIX: " & AdvantageFramework.Security.Encryption.Encrypt(ConnectionString) & vbCrLf
                        DebugMessage &= "DEBUG :: SEVEN: " & AdvantageFramework.Security.Encryption.Encrypt(ConnectionStringUserName) & vbCrLf

                        If HasDuplicateRegistryEntry(ConnectionDatabaseProfiles, P.ServerName, P.DatabaseName, MatchCount, DebugMessage) = True Then

                            IndexViewModel.IsValid = False
                            IndexViewModel.Message = String.Format("Registry error. {0} databases found with same name.", MatchCount.ToString)

                        End If

                        AdvantageFramework.Security.AddWebvantageEventLog(DebugMessage, Diagnostics.EventLogEntryType.Error)

                    Catch ex As Exception
                        AdvantageFramework.Security.AddWebvantageEventLog("ERROR WRITING TO EVENT LOG:" & vbCrLf &
                                                                          AdvantageFramework.StringUtilities.FullErrorToString(ex),
                                                                          Diagnostics.EventLogEntryType.Error)
                    End Try

                End If

            Catch ex As Exception
                IndexViewModel.IsValid = False
                IndexViewModel.Message = AdvantageFramework.StringUtilities.FullErrorToString(ex)
            End Try

            ViewData("HasPassword") = HasPassword
            IndexViewModel.HasPassword = HasPassword

            Return View(IndexViewModel)

        End Function
        <AllowAnonymous> Public Function Verify() As System.Web.Mvc.ActionResult

            Return View()

        End Function

#End Region
#Region " API "

        'Validate key
        <HttpPost>
        Public Function vk(ByVal k As String, ByVal v As String) As JsonResult

            Dim IsValid As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim Key2 As String = String.Empty

            IsValid = AdvantageFramework.Security.Password.ValidateUserKey(k, v, Key2, ErrorMessage)

            If IsValid = True Then

                Session(Key2) = Key2

            End If

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(IsValid, ErrorMessage, New With {.k = Key2,
                                                                                                             .e = ErrorMessage}))

        End Function
        <HttpPost>
        Public Function cp(ByVal w As String,
                           ByVal k As String,
                           ByVal x As String) As JsonResult

            Dim NewPassword As String = String.Empty
            Dim Key2 As String = String.Empty
            Dim ErrorMessage As String = String.Empty
            Dim SqlConnectionStringBuilder As System.Data.SqlClient.SqlConnectionStringBuilder = Nothing
            'Dim Admin As MiscFN.Admin = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim P As AdvantageFramework.Security.Classes.Password = Nothing
            Dim User As AdvantageFramework.Security.Database.Entities.User = Nothing
            Dim PasswordChanged As Boolean = False
            Dim PasswordValid As Boolean = True 'False
            Dim WebvantageURL As String = ""
            Dim Messages As New Generic.List(Of String)
            Dim ConnectionDatabaseProfile As AdvantageFramework.Database.ConnectionDatabaseProfile = Nothing
            Dim ConnectionDatabaseProfiles As Generic.List(Of AdvantageFramework.Database.ConnectionDatabaseProfile) = Nothing

            NewPassword = w
            Key2 = k

            Try

                If Session(Key2) IsNot Nothing Then

                    x = AdvantageFramework.Web.DecryptDeepLinkString(x)
                    P = AdvantageFramework.Security.Password.PasswordObjectFromQueryString(x, ErrorMessage)

                    If P IsNot Nothing AndAlso P.IsValid = True Then

                        ConnectionDatabaseProfiles = AdvantageFramework.Database.LoadConnectionDatabaseProfiles

                        If ConnectionDatabaseProfiles IsNot Nothing AndAlso ConnectionDatabaseProfiles.Count > 0 Then

                            For Each ConnectionDatabaseProfile In ConnectionDatabaseProfiles

                                If ConnectionDatabaseProfile.ServerName = P.ServerName AndAlso ConnectionDatabaseProfile.DatabaseName = P.DatabaseName Then

                                    Exit For

                                End If

                            Next

                        End If

                        If ConnectionDatabaseProfile IsNot Nothing Then

                            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(ConnectionDatabaseProfile.GetConnectionString(AdvantageFramework.Security.Application.Webvantage), ConnectionDatabaseProfile.UserName)

                                User = AdvantageFramework.Security.Database.Procedures.User.LoadByUserCode(SecurityDbContext, P.UserCode)

                                If User IsNot Nothing Then

                                    PasswordValid = Me._Controller.Validate(SecurityDbContext, User.UserCode, NewPassword, Messages)

                                    If PasswordValid = True Then

                                        User.Password = AdvantageFramework.Security.Encryption.EncryptPassword(NewPassword)

                                        If String.IsNullOrWhiteSpace(User.UserName) = True Then

                                            User.UserName = User.UserCode

                                        End If

                                        PasswordChanged = AdvantageFramework.Security.Database.Procedures.User.Update(SecurityDbContext, User)

                                        If PasswordChanged = True Then

                                            AdvantageFramework.Security.Password.InsertNewPasswordHistory(SecurityDbContext, User)
                                            WebvantageURL = AdvantageFramework.Security.Password.LoadWebvantageURLFromSecurityContext(SecurityDbContext)

                                        End If

                                    Else

                                        PasswordChanged = False

                                    End If

                                End If

                            End Using

                        End If

                    Else

                        Messages.Add("Invalid querystring.")

                    End If

                Else

                    Messages.Add("Request has expired.")

                End If

            Catch ex As Exception
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
            End Try

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(PasswordChanged,
                                                                            ErrorMessage,
                                                                            New With {.k = Key2,
                                                                                      .url = WebvantageURL,
                                                                                      .msgs = Messages}))

        End Function
        <HttpPost>
        Public Function cx(ByVal x As String) As JsonResult

            Dim ErrorMessage As String = String.Empty
            Dim SqlConnectionStringBuilder As System.Data.SqlClient.SqlConnectionStringBuilder = Nothing
            'Dim Admin As MiscFN.Admin = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim P As AdvantageFramework.Security.Classes.Password = Nothing
            Dim WebvantageURL As String = ""
            Dim Messages As New Generic.List(Of String)
            Dim ConnectionDatabaseProfile As AdvantageFramework.Database.ConnectionDatabaseProfile = Nothing
            Dim ConnectionDatabaseProfiles As Generic.List(Of AdvantageFramework.Database.ConnectionDatabaseProfile) = Nothing

            Try

                x = AdvantageFramework.Web.DecryptDeepLinkString(x)
                P = AdvantageFramework.Security.Password.PasswordObjectFromQueryString(x, ErrorMessage)

                If P IsNot Nothing AndAlso P.IsValid = True Then

                    ConnectionDatabaseProfiles = AdvantageFramework.Database.LoadConnectionDatabaseProfiles

                    If ConnectionDatabaseProfiles IsNot Nothing AndAlso ConnectionDatabaseProfiles.Count > 0 Then

                        For Each ConnectionDatabaseProfile In ConnectionDatabaseProfiles

                            If ConnectionDatabaseProfile.ServerName = P.ServerName AndAlso ConnectionDatabaseProfile.DatabaseName = P.DatabaseName Then

                                Exit For

                            End If

                        Next

                    End If
                    If ConnectionDatabaseProfile IsNot Nothing Then

                        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(ConnectionDatabaseProfile.GetConnectionString(AdvantageFramework.Security.Application.Webvantage), ConnectionDatabaseProfile.UserName)

                            WebvantageURL = AdvantageFramework.Security.Password.LoadWebvantageURLFromSecurityContext(SecurityDbContext)

                        End Using

                    End If

                Else

                    ErrorMessage = "Invalid querystring."

                End If

            Catch ex As Exception
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
            End Try

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(True,
                                                                            ErrorMessage,
                                                                            New With {.url = WebvantageURL}))

        End Function

#End Region
#Region " Private "
        Private Function HasDuplicateRegistryEntry(ByVal ConnectionDatabaseProfiles As Generic.List(Of AdvantageFramework.Database.ConnectionDatabaseProfile),
                                                   ByVal ServerName As String, ByVal DatabaseName As String,
                                                   ByRef MatchCount As Integer,
                                                   ByRef DebugMessage As String) As Boolean

            Try

                Dim Counter As Integer = 0
                Dim TempDebugMessage As String = String.Empty

                MatchCount = 0

                If ConnectionDatabaseProfiles IsNot Nothing AndAlso ConnectionDatabaseProfiles.Count > 0 Then

                    TempDebugMessage &= vbCrLf

                    For Each ConnectionDatabaseProfile In ConnectionDatabaseProfiles

                        Counter += 1

                        If ConnectionDatabaseProfile.ServerName = ServerName AndAlso ConnectionDatabaseProfile.DatabaseName = DatabaseName Then

                            TempDebugMessage &= "*" & Counter.ToString & ":  "
                            TempDebugMessage &= AdvantageFramework.Security.Encryption.Encrypt(ConnectionDatabaseProfile.ServerName) & " : " &
                                            AdvantageFramework.Security.Encryption.Encrypt(ConnectionDatabaseProfile.DatabaseName) & vbCrLf

                            MatchCount += 1

                        Else

                            TempDebugMessage &= Counter.ToString & ":  "
                            TempDebugMessage &= AdvantageFramework.Security.Encryption.Encrypt(ConnectionDatabaseProfile.ServerName) & " : " &
                                            AdvantageFramework.Security.Encryption.Encrypt(ConnectionDatabaseProfile.DatabaseName) & vbCrLf


                        End If

                    Next

                    TempDebugMessage &= vbCrLf
                    TempDebugMessage &= "=============================================================" & vbCrLf
                    TempDebugMessage &= ":: TOTAL MATCHES :: " & MatchCount.ToString & vbCrLf
                    TempDebugMessage &= "=============================================================" & vbCrLf

                    If MatchCount > 1 Then

                        DebugMessage &= "*************************** MULTIPLE REGISTRY MATCHES FOUND ***************************"
                        DebugMessage &= TempDebugMessage

                    End If

                End If

                Return MatchCount > 1

            Catch ex As Exception
                Return False
            End Try

        End Function

        'Private Function Validate() As Boolean

        '    Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

        '        Me._Controller.Validate(DbContext

        '    End Using


        'End Function

#End Region

        Protected Overrides Sub Initialize(requestContext As RequestContext)

            MyBase.Initialize(requestContext)

            _Controller = New AdvantageFramework.Controller.Account.PasswordController(Me.SecuritySession)

        End Sub

    End Class

End Namespace

