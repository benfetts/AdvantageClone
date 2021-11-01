Imports Kendo.Mvc.Extensions
Imports MvcCodeRouting.Web.Mvc
Imports Newtonsoft.Json
Imports System
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.IO
Imports System.Linq
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Text
Imports System.Threading
Imports System.Web
Imports System.Web.Configuration
Imports System.Web.Mvc
Imports System.Web.Routing
Imports Webvantage.Controllers
Imports Webvantage.ViewModels
Namespace Controllers.Account
    <Serializable()> Public Class GMController
        Inherits MVCControllerBase

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Controller As AdvantageFramework.Controller.Account.PasswordController = Nothing

#End Region

#Region " Properties "

#End Region

#Region " MVC Views "
        Public Function Actions() As System.Web.Mvc.ActionResult

            Dim ConnectionString As String = String.Empty
            Dim UserCode As String = String.Empty
            Dim UrlDate As String = String.Empty
            Dim ErrorMessage As String = String.Empty
            Dim x As String = Request.QueryString("x")
            Dim ActionsViewModel As New ActionsViewViewModel

            Try

                If DataFromQuerystring(x, ConnectionString, UrlDate, UserCode, ErrorMessage) = True Then

                    'Check date to prevent bookmarking
                    If Today.Date.ToShortDateString = UrlDate Then

                        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(ConnectionString, UserCode)

                            ActionsViewModel.PasswordUsers = AdvantageFramework.Security.LoadPasswordUsers(SecurityDbContext, ErrorMessage)

                            If ActionsViewModel.PasswordUsers IsNot Nothing AndAlso ActionsViewModel.PasswordUsers.Count > 0 Then

                                ActionsViewModel.ShowSeedForm = False

                            Else

                                ActionsViewModel.ShowSeedForm = True

                                Using DbContext = New AdvantageFramework.Database.DbContext(ConnectionString, UserCode)

                                    Try

                                        ActionsViewModel.Departments = (From Entity In AdvantageFramework.Database.Procedures.DepartmentTeam.LoadAllActive(DbContext)
                                                                        Select New ActionsViewViewModel.Department With {.Code = Entity.Code,
                                                                                                                         .Name = Entity.Description}).ToList


                                    Catch ex As Exception
                                        ActionsViewModel.Departments = Nothing
                                    End Try
                                    Try

                                        ActionsViewModel.Employees = (From Entity In AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActive(DbContext)
                                                                      Select New ActionsViewViewModel.Employee With {.Code = Entity.Code,
                                                                                                                     .Name = Entity.FirstName & " " & Entity.LastName}).ToList

                                    Catch ex As Exception
                                        ActionsViewModel.Employees = Nothing
                                    End Try

                                End Using

                            End If

                        End Using

                    Else

                        ActionsViewModel.ErrorMessage = String.Format("No longer valid.  URL expired on {0}.", UrlDate)

                    End If

                Else

                    ActionsViewModel.ErrorMessage = ErrorMessage

                End If

            Catch ex As Exception
                ActionsViewModel.ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                AdvantageFramework.Security.AddWebvantageEventLog("ActionView:  " & AdvantageFramework.StringUtilities.FullErrorToString(ex), Diagnostics.EventLogEntryType.Error)
            End Try

            If ActionsViewModel.PasswordUsers Is Nothing Then ActionsViewModel.PasswordUsers = New List(Of AdvantageFramework.Security.Classes.PasswordUser)
            If ActionsViewModel.Departments Is Nothing Then ActionsViewModel.Departments = New List(Of ActionsViewViewModel.Department)
            If ActionsViewModel.Employees Is Nothing Then ActionsViewModel.Employees = New List(Of ActionsViewViewModel.Employee)

            Return View(ActionsViewModel)

        End Function
        Public Function Index() As System.Web.Mvc.ActionResult

            Return View()

        End Function

#End Region
#Region " Methods "

#Region " API "

        <HttpPost>
        Public Function si(ByVal s As String, ByVal d As String, ByVal u As String, ByVal p As String) As JsonResult

            'Dim SignInObjectString As String = String.Empty

            'SignInObjectString = System.Convert.FromBase64String(x)

            ''Dim bytes As Byte()
            ''Dim adminObj As AdminUser
            ''Dim bf As BinaryFormatter = New BinaryFormatter

            ''bytes = System.Convert.FromBase64String(x)

            ''Using ms = New MemoryStream(bytes)

            ''    adminObj = bf.Deserialize(ms)

            ''End Using

            'Dim adminObj As AdminUser = Nothing
            ''Dim SerializedObjectJson As String = Encoding.UTF8.GetString(Convert.FromBase64String(x))

            'adminObj = Newtonsoft.Json.JsonConvert.DeserializeObject(Of AdminUser)(x)

            'If adminObj IsNot Nothing Then

            '    Dim ConnectionString As String = String.Empty

            'End If






        End Function
        <HttpPost> Public Function cp(ByVal u As Integer,
                                      ByVal p As String,
                                      ByVal x As String) As JsonResult

            Dim ConnectionString As String = String.Empty
            Dim ConnectionUser As String = String.Empty
            Dim UrlDate As String = String.Empty
            Dim User As AdvantageFramework.Security.Database.Entities.User = Nothing
            Dim UserID As Integer = u
            Dim NewPassword As String = p.Trim
            Dim PasswordChanged As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim Messages As New Generic.List(Of String)

            If DataFromQuerystring(x, ConnectionString, UrlDate, ConnectionUser, ErrorMessage) = True Then

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(ConnectionString, ConnectionUser)

                    User = AdvantageFramework.Security.Database.Procedures.User.LoadByUserID(SecurityDbContext, UserID)

                    If User IsNot Nothing Then

                        If AdvantageFramework.Security.ValidatePassword(SecurityDbContext, User.UserCode, NewPassword, Messages) Then

                            User.Password = AdvantageFramework.Security.Encryption.EncryptPassword(NewPassword)

                            If String.IsNullOrWhiteSpace(User.UserName) = True Then

                                User.UserName = User.UserCode

                            End If

                            PasswordChanged = AdvantageFramework.Security.Database.Procedures.User.Update(SecurityDbContext, User)

                            If PasswordChanged = True Then

                                AdvantageFramework.Security.Password.InsertNewPasswordHistory(SecurityDbContext, User)

                            End If

                        End If

                    End If

                End Using

            Else

                Messages.Add(ErrorMessage)

            End If

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(PasswordChanged,
                                                                            ErrorMessage,
                                                                            New With {.msgs = Messages}))


        End Function
        <HttpPost> Public Function clr(ByVal u As Integer,
                                       ByVal x As String) As JsonResult

            Dim ConnectionString As String = String.Empty
            Dim ConnectionUser As String = String.Empty
            Dim UrlDate As String = String.Empty
            Dim User As AdvantageFramework.Security.Database.Entities.User = Nothing
            Dim UserID As Integer = u
            Dim PasswordChanged As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim Messages As New Generic.List(Of String)

            If DataFromQuerystring(x, ConnectionString, UrlDate, ConnectionUser, ErrorMessage) = True Then

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(ConnectionString, ConnectionUser)

                    User = AdvantageFramework.Security.Database.Procedures.User.LoadByUserID(SecurityDbContext, UserID)

                    If User IsNot Nothing Then

                        User.Password = ""

                        If String.IsNullOrWhiteSpace(User.UserName) = True Then

                            User.UserName = Nothing

                        End If

                        PasswordChanged = AdvantageFramework.Security.Database.Procedures.User.Update(SecurityDbContext, User)

                    End If

                End Using

            Else

                Messages.Add(ErrorMessage)

            End If

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(PasswordChanged,
                                                                            ErrorMessage,
                                                                            New With {.msgs = Messages}))


        End Function
        <HttpPost> Public Function nu(ByVal u As String,
                                      ByVal up As String,
                                      ByVal dc As String,
                                      ByVal dd As String,
                                      ByVal ec As String,
                                      ByVal ef As String,
                                      ByVal em As String,
                                      ByVal el As String,
                                      ByVal x As String) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim ErrorMessages As New Generic.List(Of String)
            Dim UserCode As String = u

            Try

                Dim ConnectionString As String = String.Empty
                Dim ConnectionUser As String = String.Empty
                Dim UrlDate As String = String.Empty

                Dim UserPassword As String = up
                Dim DepartmentTeamCode As String = dc
                Dim DepartmentTeamDescription As String = dd
                Dim EmployeeCode As String = ec
                Dim EmployeeFirstName As String = ef
                Dim EmployeeMiddleInitial As String = em
                Dim EmployeeLastName As String = el

                Dim User As AdvantageFramework.Security.Database.Entities.User = Nothing
                Dim Department As AdvantageFramework.Database.Entities.DepartmentTeam = Nothing
                Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
                Dim SecurityGroups As Generic.List(Of AdvantageFramework.Security.Database.Entities.Group) = Nothing

                If DataFromQuerystring(x, ConnectionString, UrlDate, ConnectionUser, ErrorMessage) = True Then

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(ConnectionString, ConnectionUser)

                        User = AdvantageFramework.Security.Database.Procedures.User.LoadByUserCode(SecurityDbContext, UserCode)

                        If User Is Nothing Then

                            Using DbContext = New AdvantageFramework.Database.DbContext(ConnectionString, ConnectionUser)

                                Try

                                    Department = AdvantageFramework.Database.Procedures.DepartmentTeam.LoadByDepartmentTeamCode(DbContext, DepartmentTeamCode)

                                    If Department IsNot Nothing Then

                                        DepartmentTeamCode = Department.Code
                                        DepartmentTeamDescription = Department.Description
                                        ErrorMessages.Add("Existing department/team with this code found and used.")

                                    End If

                                Catch ex As Exception
                                End Try
                                Try

                                    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode)

                                    If Employee IsNot Nothing Then

                                        EmployeeCode = Employee.Code
                                        EmployeeFirstName = Employee.FirstName
                                        EmployeeMiddleInitial = Employee.MiddleInitial
                                        EmployeeLastName = Employee.LastName
                                        ErrorMessages.Add("Existing employee with this code found and used.")

                                    End If

                                Catch ex As Exception
                                End Try
                                Try

                                    SecurityGroups = AdvantageFramework.Security.Database.Procedures.Group.Load(SecurityDbContext).ToList

                                    If SecurityGroups Is Nothing OrElse SecurityGroups.Count = 1 Then

                                        Dim SecurityGroup As New AdvantageFramework.Security.Database.Entities.Group

                                        SecurityGroup.Name = "All Rights"
                                        SecurityGroup.Description = "All Rights (Created by code)"

                                        AdvantageFramework.Security.Database.Procedures.Group.Insert(SecurityDbContext, SecurityGroup)

                                    End If

                                Catch ex As Exception
                                End Try

                                Dim arParams As New List(Of SqlParameter)

                                arParams.Add(New SqlParameter("@ADV_USER_ID", UserCode))
                                arParams.Add(New SqlParameter("@ADV_USER_PWD", UserPassword))
                                arParams.Add(New SqlParameter("@DP_TM_CODE", DepartmentTeamCode))
                                arParams.Add(New SqlParameter("@DP_TM_DESC", DepartmentTeamDescription))
                                arParams.Add(New SqlParameter("@EMP_CODE", EmployeeCode))
                                arParams.Add(New SqlParameter("@F_NAME", EmployeeFirstName))
                                arParams.Add(New SqlParameter("@MI_NAME", EmployeeMiddleInitial))
                                arParams.Add(New SqlParameter("@L_NAME", EmployeeLastName))

                                SecurityDbContext.Database.ExecuteSqlCommand("EXEC [dbo].[advsp_sec_seed] @ADV_USER_ID, @ADV_USER_PWD, @EMP_CODE, @DP_TM_CODE, @DP_TM_DESC, @F_NAME, @MI_NAME, @L_NAME;", arParams.ToArray)

                                User = AdvantageFramework.Security.Database.Procedures.User.LoadByUserCode(SecurityDbContext, UserCode)

                                If User IsNot Nothing Then

                                    Success = True

                                End If

                            End Using

                        Else

                            ErrorMessage = "User already exists!"

                        End If

                    End Using

                Else

                    ErrorMessage = "No connection."

                End If

            Catch ex As Exception
                Success = False
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
            End Try

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success,
                                                                            ErrorMessage,
                                                                            New With {.u = UserCode,
                                                                                      .msgs = ErrorMessages}))

        End Function
        <HttpPost> Public Function lk(ByVal u As Integer,
                                      ByVal x As String) As JsonResult

            Dim ConnectionString As String = String.Empty
            Dim ConnectionUser As String = String.Empty
            Dim UrlDate As String = String.Empty
            Dim User As AdvantageFramework.Security.Database.Entities.User = Nothing
            Dim UserID As Integer = u
            Dim ErrorMessage As String = String.Empty
            Dim Messages As New Generic.List(Of String)
            Dim IsLocked As Boolean = False
            Dim Success As Boolean = False

            If DataFromQuerystring(x, ConnectionString, UrlDate, ConnectionUser, ErrorMessage) = True Then

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(ConnectionString, ConnectionUser)

                    User = AdvantageFramework.Security.Database.Procedures.User.LoadByUserID(SecurityDbContext, UserID)

                    If User IsNot Nothing Then

                        Try

                            IsLocked = AdvantageFramework.Security.Database.Procedures.PasswordLockout.LockUnlock(SecurityDbContext,
                                                                                                                  User.UserCode,
                                                                                                                  AdvantageFramework.Security.Database.Procedures.PasswordLockout.Methods.LockAction.Lock)

                        Catch ex As Exception
                            Success = False
                            ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                            Messages.Add(ErrorMessage)
                        End Try
                    End If

                End Using

            Else

                Messages.Add(ErrorMessage)

            End If
            If IsLocked = True Then

                Success = True

            End If

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success,
                                                                            ErrorMessage,
                                                                            New With {.msgs = Messages}))


        End Function
        <HttpPost> Public Function ulk(ByVal u As Integer,
                                       ByVal x As String) As JsonResult

            Dim ConnectionString As String = String.Empty
            Dim ConnectionUser As String = String.Empty
            Dim UrlDate As String = String.Empty
            Dim User As AdvantageFramework.Security.Database.Entities.User = Nothing
            Dim UserID As Integer = u
            Dim ErrorMessage As String = String.Empty
            Dim Messages As New Generic.List(Of String)
            Dim IsLocked As Boolean = False
            Dim Success As Boolean = False

            If DataFromQuerystring(x, ConnectionString, UrlDate, ConnectionUser, ErrorMessage) = True Then

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(ConnectionString, ConnectionUser)

                    User = AdvantageFramework.Security.Database.Procedures.User.LoadByUserID(SecurityDbContext, UserID)

                    If User IsNot Nothing Then

                        Try

                            IsLocked = AdvantageFramework.Security.Database.Procedures.PasswordLockout.LockUnlock(SecurityDbContext,
                                                                                                                  User.UserCode,
                                                                                                                  AdvantageFramework.Security.Database.Procedures.PasswordLockout.Methods.LockAction.Unlock)

                        Catch ex As Exception
                            Success = False
                            ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                            Messages.Add(ErrorMessage)
                        End Try

                    End If

                End Using

            Else

                Messages.Add(ErrorMessage)

            End If
            If IsLocked = False Then

                Success = True

            End If

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success,
                                                                            ErrorMessage,
                                                                            New With {.msgs = Messages}))


        End Function
        <HttpPost> Public Function ulka(ByVal x As String) As JsonResult

            Dim ConnectionString As String = String.Empty
            Dim ConnectionUser As String = String.Empty
            Dim UrlDate As String = String.Empty
            Dim ErrorMessage As String = String.Empty
            Dim Messages As New Generic.List(Of String)
            Dim IsLocked As Boolean = False
            Dim Success As Boolean = False

            If DataFromQuerystring(x, ConnectionString, UrlDate, ConnectionUser, ErrorMessage) = True Then

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(ConnectionString, ConnectionUser)

                    Try

                        IsLocked = AdvantageFramework.Security.Database.Procedures.PasswordLockout.BatchActions(SecurityDbContext,
                                                                                                                AdvantageFramework.Security.Database.Procedures.PasswordLockout.Methods.BatchAction.UnLockAll)

                    Catch ex As Exception
                        Success = False
                        ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                        Messages.Add(ErrorMessage)
                    End Try

                End Using

            Else

                Messages.Add(ErrorMessage)

            End If
            If IsLocked = False Then

                Success = True

            End If

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success,
                                                                            ErrorMessage,
                                                                            New With {.msgs = Messages}))


        End Function
        <HttpPost> Public Function lka(ByVal x As String) As JsonResult

            Dim ConnectionString As String = String.Empty
            Dim ConnectionUser As String = String.Empty
            Dim UrlDate As String = String.Empty
            Dim ErrorMessage As String = String.Empty
            Dim Messages As New Generic.List(Of String)
            Dim IsLocked As Boolean = False
            Dim Success As Boolean = False

            If DataFromQuerystring(x, ConnectionString, UrlDate, ConnectionUser, ErrorMessage) = True Then

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(ConnectionString, ConnectionUser)

                    Try

                        IsLocked = AdvantageFramework.Security.Database.Procedures.PasswordLockout.BatchActions(SecurityDbContext,
                                                                                                                AdvantageFramework.Security.Database.Procedures.PasswordLockout.Methods.BatchAction.LockAll)

                    Catch ex As Exception
                        Success = False
                        ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                        Messages.Add(ErrorMessage)
                    End Try

                End Using

            Else

                Messages.Add(ErrorMessage)

            End If

            If IsLocked = True Then

                Success = True

            End If

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success,
                                                                            ErrorMessage,
                                                                            New With {.msgs = Messages}))


        End Function
        <HttpPost> Public Function clra(ByVal x As String) As JsonResult

            Dim ConnectionString As String = String.Empty
            Dim ConnectionUser As String = String.Empty
            Dim UrlDate As String = String.Empty
            Dim ErrorMessage As String = String.Empty
            Dim Messages As New Generic.List(Of String)
            Dim IsLocked As Boolean = False
            Dim Success As Boolean = False

            If DataFromQuerystring(x, ConnectionString, UrlDate, ConnectionUser, ErrorMessage) = True Then

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(ConnectionString, ConnectionUser)

                    Try

                        IsLocked = AdvantageFramework.Security.Database.Procedures.PasswordLockout.BatchActions(SecurityDbContext,
                                                                                                                AdvantageFramework.Security.Database.Procedures.PasswordLockout.Methods.BatchAction.ClearAllPasswords)

                    Catch ex As Exception
                        Success = False
                        ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                        Messages.Add(ErrorMessage)
                    End Try

                End Using

            Else

                Messages.Add(ErrorMessage)

            End If
            If IsLocked = False Then

                Success = True

            End If

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success,
                                                                            ErrorMessage,
                                                                            New With {.msgs = Messages}))

        End Function

#End Region
#Region " Private "
        Private Function MissingSSL() As Boolean

            Dim IsMissingSSL As Boolean = False

            Try

                Dim WebConfig = WebConfigurationManager.OpenWebConfiguration("~")
                If WebConfig IsNot Nothing Then

                    Dim HttpCookieSetting = CType(WebConfig.GetSection("system.web/httpCookies"), System.Web.Configuration.HttpCookiesSection)

                    If HttpCookieSetting IsNot Nothing Then

                        If HttpCookieSetting.RequireSSL = True Then

                            If Request.Url.Scheme.ToLower <> "https" Then

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
        Private Function DataFromQuerystring(ByVal EncryptedValue As String,
                                             ByRef ConnectionString As String,
                                             ByRef UrlDate As String,
                                             ByRef UserCode As String,
                                             ByRef ErrorMessage As String) As Boolean

            Dim Success As Boolean = False
            Dim ar As String()
            Dim Original As String = EncryptedValue
            Dim ServerName As String = String.Empty
            Dim DatabaseName As String = String.Empty
            Dim Password As String = String.Empty

            Try

                If String.IsNullOrWhiteSpace(EncryptedValue) = False Then

                    EncryptedValue = AdvantageFramework.Web.DecryptDeepLinkString(EncryptedValue)

                    ar = Split(EncryptedValue, "__0__", Compare:=CompareMethod.Text)

                    If ar IsNot Nothing AndAlso ar.Length = 5 Then

                        ServerName = ar(0)
                        DatabaseName = ar(1)
                        UrlDate = ar(2)
                        UserCode = ar(3)
                        Password = ar(4)

                        If String.IsNullOrWhiteSpace(ServerName) = False AndAlso
                           String.IsNullOrWhiteSpace(DatabaseName) = False AndAlso
                           String.IsNullOrWhiteSpace(UserCode) = False AndAlso
                           String.IsNullOrWhiteSpace(Password) = False Then

                            ConnectionString = AdvantageFramework.Database.CreateConnectionString(ServerName,
                                                                                                  DatabaseName, False,
                                                                                                  UserCode,
                                                                                                  Password,
                                                                                                  AdvantageFramework.Security.Application.Webvantage.ToString)

                            Success = True

                        End If

                    Else

                        ErrorMessage = "Invalid URL."
                        AdvantageFramework.Security.AddWebvantageEventLog("Error parsing:  " & Original, Diagnostics.EventLogEntryType.Error)

                    End If

                Else

                    ErrorMessage = "Invalid URL."
                    AdvantageFramework.Security.AddWebvantageEventLog("No querystring to parse.", Diagnostics.EventLogEntryType.Error)

                End If

            Catch ex As Exception
                Success = False
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                AdvantageFramework.Security.AddWebvantageEventLog(ErrorMessage, Diagnostics.EventLogEntryType.Error)
            End Try

            Return Success

        End Function

#End Region

#End Region
        Protected Overrides Sub Initialize(requestContext As RequestContext)

            MyBase.Initialize(requestContext)

            'No SecuritySession because this page is accessed by a SQL User and not a user in the DB!
            _Controller = New AdvantageFramework.Controller.Account.PasswordController(Me.SecuritySession)

        End Sub

    End Class

#Region " Classes "
    <Serializable()> Public Class ActionsViewViewModel

        Public Property IsSSL As Boolean = False
        Public Property PasswordUsers As Generic.List(Of AdvantageFramework.Security.Classes.PasswordUser) = Nothing
        Public Property Departments As Generic.List(Of Department) = Nothing
        Public Property Employees As Generic.List(Of Employee) = Nothing
        Public Property ErrorMessage As String = String.Empty
        Public Property ShowSeedForm As Boolean = False
        Public ReadOnly Property HasDepartments As Boolean
            Get
                If Departments IsNot Nothing AndAlso Departments.Count > 0 Then
                    Return True
                Else
                    Return False
                End If
            End Get
        End Property
        Public ReadOnly Property HasEmployees As Boolean
            Get
                If Employees IsNot Nothing AndAlso Employees.Count > 0 Then
                    Return True
                Else
                    Return False
                End If
            End Get
        End Property
        <Serializable()> Public Class Department
            Public Property Code As String = String.Empty
            Public Property Name As String = String.Empty
            Sub New()

            End Sub
        End Class
        <Serializable()> Public Class Employee
            Public Property Code As String = String.Empty
            Public Property Name As String = String.Empty
            Sub New()

            End Sub
        End Class

        Sub New()

        End Sub

    End Class
    <Serializable()> Public Class IndexViewViewModel

        Public Property IsSSL As Boolean = False

        Sub New()

        End Sub

    End Class

#End Region

End Namespace
