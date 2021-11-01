Imports System.Web.Mvc
Imports System.Collections.Generic
Imports Webvantage.ViewModels
Imports Webvantage.ViewModels.LookupObjects
Imports System.Web.Routing
Imports AdvantageFramework.ViewModels.Employee
Imports System.Data.SqlClient
Imports Kendo.Mvc.Extensions
Imports MvcCodeRouting.Web.Mvc
Imports Newtonsoft.Json
Imports Webvantage.Controllers
Imports System.Threading
Imports System.Globalization
Imports System.IO

Namespace Controllers.Employee

    Public Class ExpenseApprovalController
        Inherits MVCControllerBase

#Region " Constants "

        Public Const BaseRoute As String = "Employee/ExpenseApproval/"

#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _ControllerExpenseApproval As AdvantageFramework.Controller.Employee.ExpenseApprovalController = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

#Region " MVC Views "

        Public Function Index() As ActionResult

            Return View()

        End Function
        <AllowAnonymous>
        Public Function Invoice() As ActionResult

            Dim ExpenseReport As New AdvantageFramework.ViewModels.Employee.ExpenseApproval.ExpenseReportViewModel

            If String.IsNullOrWhiteSpace(Me.CurrentQueryString.Get("x")) = False Then

                Dim InvoiceNumber As Integer = 0
                Dim ExpenseReportUserCode As String = String.Empty 'Expense report employee user code; not "current" user user code
                Dim ExpenseReportEmployeeCode As String = String.Empty 'Expense report employee
                Dim ApproverEmployeeCode As String = String.Empty 'Approver
                Dim ApproverUserCode As String = String.Empty 'Approver user code
                Dim SentDateTime As DateTime? = Nothing
                Dim UserKey As String = String.Empty
                Dim ErrorMessage As String = String.Empty
                Dim UserCode As String
                Dim DatabaseName As String
                Dim Approver As AdvantageFramework.Database.Views.Employee = Nothing
                Dim ValidApprover As Boolean = False

                If Init(InvoiceNumber, ApproverEmployeeCode, UserCode, SentDateTime, UserKey, DatabaseName, ErrorMessage) Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                        Approver = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, ApproverEmployeeCode)

                        If Approver IsNot Nothing AndAlso Approver.TerminationDate Is Nothing Then

                            ValidApprover = True

                        End If
                        If ValidApprover = True Then

                            ExpenseReport = AdvantageFramework.ExpenseApproval.LoadExpenseReportByInvoiceNumber(DbContext, InvoiceNumber)

                            If ExpenseReport IsNot Nothing Then


                            End If

                            ViewData("ID") = AdvantageFramework.Security.Encryption.Encrypt(InvoiceNumber)
                            ViewData("ID2") = AdvantageFramework.Security.Encryption.Encrypt(ApproverEmployeeCode)

                        Else

                            ExpenseReport = New ExpenseApproval.ExpenseReportViewModel

                            ExpenseReport.Message = "Invalid approver."
                            ExpenseReport.ExpenseReportStatusDisplay = ""
                            ViewData("ID") = ExpenseReport.Message
                            ViewData("ID2") = ExpenseReport.Message

                        End If

                    End Using

                End If

            End If

            Return View(ExpenseReport)

        End Function
        <AllowAnonymous>
        Public Function Approve() As ActionResult

            Dim ExpenseReport As New AdvantageFramework.ViewModels.Employee.ExpenseApproval.ExpenseReportViewModel
            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty

            If String.IsNullOrWhiteSpace(Me.CurrentQueryString.Get("x")) = False Then

                Dim InvoiceNumber As Integer = 0
                Dim ExpenseReportUserCode As String = String.Empty 'Expense report employee user code; not "current" user user code
                Dim ExpenseReportEmployeeCode As String = String.Empty 'Expense report employee
                Dim ApproverEmployeeCode As String = String.Empty 'Approver
                Dim ApproverUserCode As String = String.Empty 'Approver user code
                Dim SentDateTime As DateTime? = Nothing
                Dim UserKey As String = String.Empty
                Dim UserCode As String
                Dim ReturnObject As Object = Nothing
                Dim DatabaseName As String

                If Init(InvoiceNumber, ApproverEmployeeCode, UserCode, SentDateTime, UserKey, DatabaseName, ErrorMessage) Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                        If InvoiceNumber > 0 Then

                            ExpenseReport = AdvantageFramework.ExpenseApproval.LoadExpenseReportByInvoiceNumber(DbContext, InvoiceNumber)

                            If ExpenseReport IsNot Nothing Then

                                Success = AdvantageFramework.ExpenseReports.ApproveInvoice(DbContext, InvoiceNumber, ApproverEmployeeCode, "", ErrorMessage)

                                If Success = True Then

                                    AdvantageFramework.ExpenseReports.CreateAlertAndSendEmail(Me.SecuritySession, DbContext, InvoiceNumber,
                                                                                              ApproverEmployeeCode, "",
                                                                                              AdvantageFramework.ExpenseReports.Methods.EmailAlertType.Approved,
                                                                                              ErrorMessage)
                                End If

                            End If

                        End If

                    End Using

                End If

            End If

            ViewData("Success") = Success
            ViewData("ErrorMessage") = ErrorMessage

            Return View(ExpenseReport)

        End Function
        <AllowAnonymous>
        Public Function Deny() As ActionResult

            Dim ExpenseReport As New AdvantageFramework.ViewModels.Employee.ExpenseApproval.ExpenseReportViewModel
            Dim ErrorMessage As String = String.Empty
            Dim DenySuccess As Boolean = False

            If String.IsNullOrWhiteSpace(Me.CurrentQueryString.Get("x")) = False Then

                Dim InvoiceNumber As Integer = 0
                Dim ExpenseReportUserCode As String = String.Empty 'Expense report employee user code; not "current" user user code
                Dim ExpenseReportEmployeeCode As String = String.Empty 'Expense report employee
                Dim ApproverEmployeeCode As String = String.Empty 'Approver
                Dim ApproverUserCode As String = String.Empty 'Approver user code
                Dim SentDateTime As DateTime? = Nothing
                Dim UserKey As String = String.Empty
                Dim UserCode As String
                Dim DatabaseName As String

                If Init(InvoiceNumber, ApproverEmployeeCode, UserCode, SentDateTime, UserKey, DatabaseName, ErrorMessage) Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                        If InvoiceNumber > 0 Then

                            ExpenseReport = AdvantageFramework.ExpenseApproval.LoadExpenseReportByInvoiceNumber(DbContext, InvoiceNumber)

                            If ExpenseReport IsNot Nothing Then

                                DenySuccess = AdvantageFramework.ExpenseReports.DenyInvoice(DbContext, InvoiceNumber, ApproverEmployeeCode, "", ErrorMessage)

                                If DenySuccess = True Then

                                    AdvantageFramework.ExpenseReports.CreateAlertAndSendEmail(Me.SecuritySession, DbContext, InvoiceNumber,
                                                                                              ApproverEmployeeCode, "",
                                                                                              AdvantageFramework.ExpenseReports.Methods.EmailAlertType.Denied,
                                                                                              ErrorMessage)
                                End If

                            End If

                        End If

                    End Using

                End If

            End If

            ViewData("DenySuccess") = DenySuccess
            ViewData("ErrorMessage") = ErrorMessage

            Return View(ExpenseReport)

        End Function

#End Region
#Region " API "


#End Region
#Region " Public "

        <AcceptVerbs("POST")>
        Public Function Approve(ByVal x As String,
                                ByVal inv As String,
                                ByVal emp As String,
                                ByVal c As String) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim ReturnObject As Object = Nothing
            Dim ApprovedFullName As String = String.Empty
            Dim ApprovedDateDisplay As String = String.Empty
            Dim InvoiceNumber As String = String.Empty
            Dim ApproverEmployeeCode As String = String.Empty
            Dim ApprovalComments As String = String.Empty
            Dim ExpenseHeader As AdvantageFramework.Database.Entities.ExpenseReport = Nothing
            InvoiceNumber = AdvantageFramework.Security.Encryption.Decrypt(inv)
            ApproverEmployeeCode = AdvantageFramework.Security.Encryption.Decrypt(emp)
            ApprovalComments = c

            Try

                If VerifySession(AdvantageFramework.Security.Encryption.Decrypt(x)) = True Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                        Success = AdvantageFramework.ExpenseReports.ApproveInvoice(DbContext, InvoiceNumber, ApproverEmployeeCode, ApprovalComments, ErrorMessage)

                        If Success = True Then

                            AdvantageFramework.ExpenseReports.CreateAlertAndSendEmail(Me.SecuritySession, DbContext, InvoiceNumber,
                                                                                      ApproverEmployeeCode,
                                                                                      ApprovalComments,
                                                                                      AdvantageFramework.ExpenseReports.Methods.EmailAlertType.Approved,
                                                                                      ErrorMessage)

                            ExpenseHeader = AdvantageFramework.Database.Procedures.ExpenseReport.LoadByInvoiceNumber(DbContext, InvoiceNumber)

                            If ExpenseHeader IsNot Nothing Then

                                If String.IsNullOrWhiteSpace(ExpenseHeader.ApprovedBy) = False Then

                                    Dim Sup As AdvantageFramework.Database.Views.Employee = Nothing

                                    Sup = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, ExpenseHeader.ApprovedBy)

                                    If Sup IsNot Nothing Then

                                        ApprovedFullName = Sup.ToString

                                    End If

                                End If
                                If ExpenseHeader.ApprovedDate IsNot Nothing AndAlso IsDate(ExpenseHeader.ApprovedDate) Then

                                    ApprovedDateDisplay = CType(ExpenseHeader.ApprovedDate, Date).ToString

                                End If

                            End If

                        End If

                    End Using

                End If

            Catch ex As Exception
                Success = False
                ErrorMessage = ex.Message.ToString
            End Try

            Dim FullApprovalMessage As String = String.Empty

            If String.IsNullOrWhiteSpace(ApprovedFullName) = False AndAlso
                String.IsNullOrWhiteSpace(ApprovedDateDisplay) = False Then

                FullApprovalMessage = String.Format("Approved by {0} at {1}", ApprovedFullName, ApprovedDateDisplay)

            End If

            ReturnObject = New With {.approverFullName = ApprovedFullName,
                                     .approvedDateDisplay = ApprovedDateDisplay,
                                     .fullApprovalMessage = FullApprovalMessage}

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, ReturnObject))

        End Function
        <AcceptVerbs("POST")>
        Public Function Deny(ByVal x As String,
                             ByVal inv As String,
                             ByVal emp As String,
                             ByVal c As String) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim ReturnObject As Object = Nothing

            Dim InvoiceNumber As String = String.Empty
            Dim ApproverEmployeeCode As String = String.Empty
            Dim ApprovalComments As String = String.Empty

            InvoiceNumber = AdvantageFramework.Security.Encryption.Decrypt(inv)
            ApproverEmployeeCode = AdvantageFramework.Security.Encryption.Decrypt(emp)
            ApprovalComments = c

            Try

                If VerifySession(AdvantageFramework.Security.Encryption.Decrypt(x)) = True Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                        Success = AdvantageFramework.ExpenseReports.DenyInvoice(DbContext, InvoiceNumber, ApproverEmployeeCode, ApprovalComments, ErrorMessage)

                        If Success = True Then

                            AdvantageFramework.ExpenseReports.CreateAlertAndSendEmail(Me.SecuritySession, DbContext, InvoiceNumber,
                                                                                      ApproverEmployeeCode,
                                                                                      ApprovalComments,
                                                                                      AdvantageFramework.ExpenseReports.Methods.EmailAlertType.Denied,
                                                                                      ErrorMessage)

                        End If

                    End Using

                End If

            Catch ex As Exception
                Success = False
                ErrorMessage = ex.Message.ToString
            End Try

            ReturnObject = New With {.inv = inv}

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, ReturnObject))

        End Function
        <AcceptVerbs("POST")>
        Public Function Pend(ByVal x As String,
                             ByVal inv As String,
                             ByVal emp As String,
                             ByVal c As String) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim ReturnObject As Object = Nothing

            Dim InvoiceNumber As String = String.Empty
            Dim ApproverEmployeeCode As String = String.Empty
            Dim ApprovalComments As String = String.Empty

            InvoiceNumber = AdvantageFramework.Security.Encryption.Decrypt(inv)
            ApproverEmployeeCode = AdvantageFramework.Security.Encryption.Decrypt(emp)
            ApprovalComments = c

            Try

                If VerifySession(AdvantageFramework.Security.Encryption.Decrypt(x)) = True Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                        Success = AdvantageFramework.ExpenseReports.PendInvoice(DbContext, InvoiceNumber, ApproverEmployeeCode, ApprovalComments)

                    End Using

                End If

            Catch ex As Exception
                Success = False
                ErrorMessage = ex.Message.ToString
            End Try

            ReturnObject = New With {.inv = inv}

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, ReturnObject))

        End Function

#End Region
#Region " Private "

        Private Function Init(ByRef InvoiceNumber As Integer,
                              ByRef ApproverEmployeeCode As String,
                              ByRef UserCode As String,
                              ByRef SentDateTime As DateTime?,
                              ByRef UserKey As String,
                              ByRef DatabaseName As String,
                              ByRef ErrorMessage As String) As Boolean

            'Dim InvoiceNumber As Integer = 0
            Dim ExpenseReportUserCode As String = String.Empty 'Expense report employee user code; not "current" user user code
            Dim ExpenseReportEmployeeCode As String = String.Empty 'Expense report employee
            'Dim ApproverEmployeeCode As String = String.Empty 'Approver
            Dim ApproverUserCode As String = String.Empty 'Approver user code
            'Dim SentDateTime As DateTime? = Nothing
            'Dim UserKey As String = String.Empty
            Dim ExpenseReportEntity As AdvantageFramework.Database.Entities.ExpenseReport = Nothing
            Dim Loaded As Boolean = False

            If AdvantageFramework.ExpenseReports.ExpenseApprovalOptionsFromQueryString(Me.CurrentQueryString.Get("x"),
                                                                                           InvoiceNumber,
                                                                                           ApproverEmployeeCode,
                                                                                           ExpenseReportUserCode,
                                                                                           SentDateTime,
                                                                                           UserKey,
                                                                                           DatabaseName,
                                                                                           ErrorMessage) = True Then

                If VerifySession(DatabaseName) = True Then

                    ViewData("DB") = AdvantageFramework.Security.Encryption.Encrypt(DatabaseName)
                    Loaded = True

                End If

            End If

            Return Loaded

        End Function

        Private Function VerifySession(ByVal DatabaseName As String) As Boolean

            If Me.SecuritySession Is Nothing AndAlso String.IsNullOrWhiteSpace(DatabaseName) = False Then

                Dim SqlConnectionStringBuilder As System.Data.SqlClient.SqlConnectionStringBuilder = Nothing

                SqlConnectionStringBuilder = New System.Data.SqlClient.SqlConnectionStringBuilder()

                GetServerName(DatabaseName,
                              SqlConnectionStringBuilder.DataSource,
                              SqlConnectionStringBuilder.UserID,
                              SqlConnectionStringBuilder.Password)

                SqlConnectionStringBuilder.InitialCatalog = DatabaseName

                If String.IsNullOrWhiteSpace(SqlConnectionStringBuilder.DataSource) = False AndAlso
                   String.IsNullOrWhiteSpace(SqlConnectionStringBuilder.InitialCatalog) = False AndAlso
                   String.IsNullOrWhiteSpace(SqlConnectionStringBuilder.UserID) = False AndAlso
                   String.IsNullOrWhiteSpace(SqlConnectionStringBuilder.Password) = False Then

                    Me.SecuritySession = New AdvantageFramework.Security.Session(AdvantageFramework.Security.Application.Webvantage,
                                                                                 SqlConnectionStringBuilder.ConnectionString,
                                                                                 SqlConnectionStringBuilder.UserID,
                                                                                 0,
                                                                                 SqlConnectionStringBuilder.ConnectionString)

                End If

            End If

            Return Me.SecuritySession IsNot Nothing

        End Function
        'Private Function GetRegistryKey(ByVal RegPath As String) As Microsoft.Win32.RegistryKey

        '    Dim RegistryKey As Microsoft.Win32.RegistryKey = Nothing

        '    If System.Environment.Is64BitOperatingSystem AndAlso System.Environment.Is64BitProcess Then

        '        RegistryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\Advantage\" & RegPath, False)

        '    Else

        '        RegistryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\Wow6432Node\Advantage\" & RegPath, False)

        '    End If

        '    GetRegistryKey = RegistryKey

        'End Function
        Private Function GetSqlConnectionStringBuilder(DatabaseName As String) As System.Data.SqlClient.SqlConnectionStringBuilder

            'objects
            Dim SqlConnectionStringBuilder As System.Data.SqlClient.SqlConnectionStringBuilder = Nothing

            SqlConnectionStringBuilder = New System.Data.SqlClient.SqlConnectionStringBuilder()

            GetServerName(DatabaseName, SqlConnectionStringBuilder.DataSource, SqlConnectionStringBuilder.UserID, SqlConnectionStringBuilder.Password)

            SqlConnectionStringBuilder.InitialCatalog = DatabaseName

            GetSqlConnectionStringBuilder = SqlConnectionStringBuilder

        End Function
        Private Sub GetServerName(ByVal DatabaseName As String, ByRef ServerName As String, ByRef UserName As String, ByRef Password As String)

            Dim ConnectionDatabaseProfile As AdvantageFramework.Database.ConnectionDatabaseProfile = Nothing
            Dim ConnectionDatabaseProfiles As Generic.List(Of AdvantageFramework.Database.ConnectionDatabaseProfile) = Nothing

            ConnectionDatabaseProfiles = AdvantageFramework.Database.LoadConnectionDatabaseProfiles

            If ConnectionDatabaseProfiles IsNot Nothing AndAlso ConnectionDatabaseProfiles.Count > 0 Then

                For Each CDP In ConnectionDatabaseProfiles

                    If CDP.DatabaseName = DatabaseName Then

                        ConnectionDatabaseProfile = CDP
                        Exit For

                    End If

                Next

            End If

            If ConnectionDatabaseProfile IsNot Nothing Then

                ServerName = ConnectionDatabaseProfile.ServerName.Replace("#", "\")
                UserName = ConnectionDatabaseProfile.UserName
                Password = ConnectionDatabaseProfile.GetDecryptPassword()

            End If

        End Sub
        'Private Sub GetServerName(ByVal DatabaseName As String, ByRef ServerName As String, ByRef UserName As String, ByRef Password As String)

        '    Dim RegistryKey As Microsoft.Win32.RegistryKey = Nothing
        '    Dim RegistryAttribute As AdvantageFramework.Registry.Attributes.RegistryAttribute = Nothing
        '    Dim ServerFound As Boolean = False

        '    RegistryKey = GetRegistryKey("Servers")

        '    If RegistryKey IsNot Nothing Then

        '        For Each ServerSubKeyName In RegistryKey.GetSubKeyNames

        '            RegistryKey = GetRegistryKey("Servers\" & ServerSubKeyName)

        '            If RegistryKey IsNot Nothing Then

        '                For Each SubKeyNameDB In RegistryKey.GetSubKeyNames

        '                    If SubKeyNameDB.ToUpper = DatabaseName.ToUpper Then

        '                        ServerName = ServerSubKeyName.Replace("#", "\")

        '                        ServerFound = True

        '                        RegistryKey = GetRegistryKey("Servers\" & ServerSubKeyName & "\" & SubKeyNameDB)

        '                        If RegistryKey IsNot Nothing Then

        '                            UserName = RegistryKey.GetValue("CPUsername")

        '                            Password = AdvantageFramework.Security.Encryption.Decrypt(RegistryKey.GetValue("CPPassword"))

        '                        End If

        '                        Exit For

        '                    End If

        '                Next

        '                If ServerFound Then

        '                    Exit For

        '                End If

        '            End If

        '        Next

        '    End If

        'End Sub

#End Region

        Protected Overrides Sub Initialize(requestContext As RequestContext)

            MyBase.Initialize(requestContext)

            _ControllerExpenseApproval = New AdvantageFramework.Controller.Employee.ExpenseApprovalController(Me.SecuritySession)

        End Sub

#End Region

    End Class

End Namespace
