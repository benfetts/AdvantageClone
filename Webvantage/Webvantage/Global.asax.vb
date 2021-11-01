Imports System.Web
Imports System.Web.SessionState
Imports Webvantage.cGlobals.Globals
Imports System.Web.Security
Imports System.Web.Caching
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Web.Http
Imports System.Web.Mvc
Imports System.Web.Optimization
Imports System.Web.Routing
Imports MvcCodeRouting
Imports DevExpress.DashboardCommon

Public Class Global_asax
    Inherits System.Web.HttpApplication

#Region " Component Designer Generated Code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Component Designer
    'It can be modified using the Component Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container()
    End Sub

#End Region

#Region " Application Events "

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)

        'DashboardExportSettings.CompatibilityMode = DashboardExportCompatibilityMode.Restricted
        Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mjk2MzYxQDMxMzgyZTMyMmUzMGlGSTlYOVVVanlIS1k3c3NraFFWVmtUVlFZM2NLa1pFeXRFN21yM1ZqNUU9;Mjk2MzYyQDMxMzgyZTMyMmUzMENQV1NzVXRFZkpPMzZIRDQ2OWdBSUVMdGJVMlN4L2R4WnlacDROeXlIaHc9;Mjk2MzYzQDMxMzgyZTMyMmUzMEN1SWhqZDVIU3hKL2JXcW1hUllTWU12Y0o0eG5YTS83MmNLVGlFWWNXWFk9;Mjk2MzY0QDMxMzgyZTMyMmUzMFJWbXp6VFFnLzFPL01NdkIyc1EwWmk1dmFYdXRnc0ZISklFbWwvUVVJakk9;Mjk2MzY1QDMxMzgyZTMyMmUzMEJEVThqZkdmNHVsN2hla09OV3dLQ2lyZXFtTVBOOVZCdEpmYWlwZzJrVWM9;Mjk2MzY2QDMxMzgyZTMyMmUzMFhoVUZoQ0hPSFVNTEJvNXl0TDYxRnBqbEFGblF2VWozeTcrME54dlVhZVk9;Mjk2MzY3QDMxMzgyZTMyMmUzMG1HaHVlbXBzMmxRVjNZRzFlNEFWbldGZ21zYlZzSUNnVU9zZXlXanN5UTg9;Mjk2MzY4QDMxMzgyZTMyMmUzMGpLM0ZSRmZWVzYwRTlDWTAyakswbjVBQ1RGVHhWSmpZcXNwVFdGcFgrTWc9;Mjk2MzY5QDMxMzgyZTMyMmUzMEt5R1R0ZUhoeEFmWXJodTA4bWZ5Tnd2a2xiN1FHVzYzeWZ5UzJCc09zb289;NT8mJyc2IWhia31hfWN9Z2doYmF8YGJ8ampqanNiYmlmamlmanMDHmggMj59JyEyPRM0PCc8MjclMj0nMjQ2fTA8Pg==;Mjk2MzcwQDMxMzgyZTMyMmUzMFZuZ0hpTE1VcW5NRUdLU2tXQk45Ti9zUlplVllnU295MzlTQlBHd1FTdEk9")

        RegisterMVC()

        ' TP: Required for JSON / MVC Date Handling!
        System.Web.Mvc.ModelBinders.Binders.Add(GetType(DateTime), New ModelBinders.DateTimeModelBinder())
        System.Web.Mvc.ModelBinders.Binders.Add(GetType(DateTime?), New ModelBinders.NullableDateTimeModelBinder())


        SessionEndModule.SessionObjectKey = "ConnString"
        AddHandler SessionEndModule.SessionEnd, AddressOf SessionTimoutModule_SessionEnd

        DevExpress.XtraReports.Security.ScriptPermissionManager.GlobalInstance = New DevExpress.XtraReports.Security.ScriptPermissionManager(DevExpress.XtraReports.Security.ExecutionMode.Unrestricted)

    End Sub
    Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)

        If (Request.Path.IndexOf(Chr(92)) >= 0 Or
            System.IO.Path.GetFullPath(Request.PhysicalPath) <> Request.PhysicalPath) Then

            Throw New HttpException(404, "Not Found")

        End If

        ' TP: Required for JSON / MVC Date Handling!
        Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(LoGlo.UserCultureGet())

    End Sub
    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)

        Dim AppException As Exception = Server.GetLastError()

        Try

            Dim Errors As New System.Text.StringBuilder
            Dim RawURL As String = String.Empty
            Dim OriginalString As String = String.Empty
            Dim URL As String = String.Empty
            Dim AbsoluteUri As String = String.Empty
            Dim PhysicalPath As String = String.Empty

            Try

                Errors.Append("Triggered from Global.asax.vb")
                Errors.Append(Environment.NewLine)

            Catch ex As Exception
            End Try
            'Try

            '    RawURL = Request.RawUrl

            'Catch ex As Exception
            '    RawURL = String.Empty
            'End Try
            'Try

            '    OriginalString = Request.Url.OriginalString

            'Catch ex As Exception
            '    OriginalString = String.Empty
            'End Try
            'Try

            '    URL = Request.Url.ToString

            'Catch ex As Exception
            '    URL = String.Empty
            'End Try
            Try

                AbsoluteUri = Request.Url.AbsoluteUri

            Catch ex As Exception
                AbsoluteUri = String.Empty
            End Try
            Try

                PhysicalPath = Request.PhysicalPath

            Catch ex As Exception
                PhysicalPath = String.Empty
            End Try
            Try

                'If String.IsNullOrWhiteSpace(RawURL) = False Then

                '    Errors.Append("RawURL:  ")
                '    Errors.Append(RawURL)
                '    Errors.Append(Environment.NewLine)

                'End If
                'If String.IsNullOrWhiteSpace(OriginalString) = False Then

                '    Errors.Append("OriginalString:  ")
                '    Errors.Append(OriginalString)
                '    Errors.Append(Environment.NewLine)

                'End If
                'If String.IsNullOrWhiteSpace(URL) = False Then

                '    Errors.Append("URL:  ")
                '    Errors.Append(URL)
                '    Errors.Append(Environment.NewLine)

                'End If
                If String.IsNullOrWhiteSpace(AbsoluteUri) = False Then

                    Errors.Append("AbsoluteUri:  ")
                    Errors.Append(AbsoluteUri)
                    Errors.Append(Environment.NewLine)

                End If
                If String.IsNullOrWhiteSpace(PhysicalPath) = False Then

                    Errors.Append("PhysicalPath:  ")
                    Errors.Append(PhysicalPath)
                    Errors.Append(Environment.NewLine)

                End If

            Catch ex As Exception
            End Try
            Try

                Errors.Append(Environment.NewLine)
                Errors.Append(Environment.NewLine)
                Errors.Append(AdvantageFramework.StringUtilities.FullErrorToString(AppException))

            Catch ex As Exception
            End Try
            If Errors IsNot Nothing AndAlso Errors.Length > 0 Then

                Errors.Append(Environment.NewLine)
                Errors.Append(Environment.NewLine)
                Errors.Append("Contact Advantage Software".ToUpper())
                Errors.Append(Environment.NewLine)
                Errors.Append("Toll Free:   800.841.2078")
                Errors.Append(Environment.NewLine)
                Errors.Append("Local:   704.662.9980")
                Errors.Append(Environment.NewLine)
                Errors.Append("Email:   support@gotoadvantage.com")
                Errors.Append(Environment.NewLine)
                Errors.Append(Environment.NewLine)

            End If
            Try

                If Errors IsNot Nothing AndAlso Errors.Length > 0 Then

                    Dim Message As String = Errors.ToString

                    If AdvantageFramework.StringUtilities.IgnoreError(Message) = False Then

                        AdvantageFramework.Security.AddWebvantageEventLog(Message, Diagnostics.EventLogEntryType.Error)

                    End If

                End If

            Catch ex As Exception
            End Try

        Catch exException As Exception
        End Try

        'Dim err As New cErrors()
        'err.SendToEventLog()

        'Dim exception As Exception = Server.GetLastError()

        'Dim httpContext As HttpContext = sender.Context
        'httpContext.Response.Clear()
        'httpContext.ClearError()

        'ExecuteErrorController(httpContext, exception)

    End Sub

    'Function ExecuteErrorController(ByVal httpContext As HttpContext, exception As Exception)
    '    Dim routeData As RouteData = New RouteData
    '    routeData.Values("controller") = "Error"
    '    routeData.Values("action") = "ServerError"
    '    routeData.Values("exception") = exception

    '    Using controller As Controller = New Controllers.ErrorController
    '        Dim iCon As IController
    '        iCon = controller

    '        iCon.Execute(New RequestContext(New HttpContextWrapper(httpContext), routeData))
    '    End Using

    'End Function

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)

        RemoveHandler SessionEndModule.SessionEnd, AddressOf SessionTimoutModule_SessionEnd

    End Sub

#End Region

#Region " Methods "

    Protected Sub RegisterMVC()

        'Do not change the order of these calls
        AreaRegistration.RegisterAllAreas()

        WebApiConfig.Register(GlobalConfiguration.Configuration)
        FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters)
        RouteConfig.RegisterRoutes(RouteTable.Routes)
        BundleConfig.RegisterBundles(BundleTable.Bundles)
        AuthConfig.RegisterAuth()

        RegisterViewEngines(ViewEngines.Engines)

    End Sub
    Protected Sub RegisterViewEngines(ByVal ViewEngines As ViewEngineCollection)

        ViewEngines.EnableCodeRouting()

    End Sub
    Private Sub SessionTimoutModule_SessionEnd(sender As Object, e As SessionEndedEventArgs)

        'objects
        Dim SqlConnectionStringBuilder As System.Data.SqlClient.SqlConnectionStringBuilder = Nothing
        Dim SecuritySession As AdvantageFramework.Security.Session = Nothing
        Dim UserCode As String = ""
        Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
        Dim UserLoginAuditID As String = ""

        If e.SessionObject.ToString.Contains("ClientPortalUserName=") Then

            SqlConnectionStringBuilder = New System.Data.SqlClient.SqlConnectionStringBuilder(e.SessionObject.ToString.Substring(0, e.SessionObject.ToString.IndexOf("ClientPortalUserName=")))

        ElseIf e.SessionObject.ToString.Contains("AdvantageUserCode=") Then

            SqlConnectionStringBuilder = New System.Data.SqlClient.SqlConnectionStringBuilder(e.SessionObject.ToString.Substring(0, e.SessionObject.ToString.IndexOf("AdvantageUserCode=")))

        ElseIf e.SessionObject.ToString.Contains("UserLoginAuditID=") Then

            SqlConnectionStringBuilder = New System.Data.SqlClient.SqlConnectionStringBuilder(e.SessionObject.ToString.Substring(0, e.SessionObject.ToString.IndexOf("UserLoginAuditID=")))

        Else

            SqlConnectionStringBuilder = New System.Data.SqlClient.SqlConnectionStringBuilder(e.SessionObject)

        End If

        If SqlConnectionStringBuilder IsNot Nothing Then

            'If SqlConnectionStringBuilder.UserID = "" Then

            '    UserCode = My.User.Name

            '    If UserCode.Contains("\") Then

            '        UserCode = UserCode.Substring(UserCode.IndexOf("\") + 1)

            '    End If

            '    SecuritySession = New AdvantageFramework.Security.Session(AdvantageFramework.Security.Application.Webvantage, e.SessionObject, UserCode, 0)

            'Else

            If e.SessionObject.ToString.Contains("ClientPortalUserName=") Then

                UserCode = e.SessionObject.ToString.Substring(e.SessionObject.ToString.IndexOf("ClientPortalUserName=")).Replace("ClientPortalUserName=", "")

                SecuritySession = New AdvantageFramework.Security.Session(AdvantageFramework.Security.Application.Client_Portal, e.SessionObject.ToString.Substring(0, e.SessionObject.ToString.IndexOf("ClientPortalUserName=")), UserCode, 0, e.SessionObject.ToString.Substring(0, e.SessionObject.ToString.IndexOf("ClientPortalUserName=")))

            ElseIf e.SessionObject.ToString.Contains("AdvantageUserCode=") Then

                If e.SessionObject.ToString.Contains("UserLoginAuditID=") Then

                    UserCode = e.SessionObject.ToString.Substring(e.SessionObject.ToString.IndexOf("AdvantageUserCode="))

                    UserCode = UserCode.Replace("AdvantageUserCode=", "")

                    UserCode = UserCode.Replace(UserCode.Substring(UserCode.IndexOf("UserLoginAuditID=")), "")

                    UserLoginAuditID = e.SessionObject.ToString.Substring(e.SessionObject.ToString.IndexOf("UserLoginAuditID="))

                    UserLoginAuditID = UserLoginAuditID.Replace("UserLoginAuditID=", "")

                Else

                    UserCode = e.SessionObject.ToString.Substring(e.SessionObject.ToString.IndexOf("AdvantageUserCode=")).Replace("AdvantageUserCode=", "")

                End If

                UserCode = e.SessionObject.ToString.Substring(e.SessionObject.ToString.IndexOf("AdvantageUserCode=")).Replace("AdvantageUserCode=", "")

                SecuritySession = New AdvantageFramework.Security.Session(AdvantageFramework.Security.Application.Webvantage, e.SessionObject.ToString.Substring(0, e.SessionObject.ToString.IndexOf("AdvantageUserCode=")), UserCode, 0, e.SessionObject.ToString.Substring(0, e.SessionObject.ToString.IndexOf("AdvantageUserCode=")))

            Else

                If e.SessionObject.ToString.Contains("UserLoginAuditID=") Then

                    UserLoginAuditID = e.SessionObject.ToString.Substring(e.SessionObject.ToString.IndexOf("UserLoginAuditID="))

                    UserLoginAuditID = UserLoginAuditID.Replace("UserLoginAuditID=", "")

                    SecuritySession = New AdvantageFramework.Security.Session(AdvantageFramework.Security.Application.Webvantage, e.SessionObject.ToString.Substring(0, e.SessionObject.ToString.IndexOf("UserLoginAuditID=")), SqlConnectionStringBuilder.UserID, 0, e.SessionObject.ToString.Substring(0, e.SessionObject.ToString.IndexOf("UserLoginAuditID=")))

                Else

                    SecuritySession = New AdvantageFramework.Security.Session(AdvantageFramework.Security.Application.Webvantage, e.SessionObject, SqlConnectionStringBuilder.UserID, 0, e.SessionObject)

                End If

            End If

            'End If

        End If

        Dim ErrorMessage As String = ""
        Dim WebIdDeleted As Boolean = False

        If Not SecuritySession Is Nothing Then

            Using DataContext = New AdvantageFramework.Database.DataContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                If AdvantageFramework.Security.LicenseKey.Clear(SecuritySession, "", e.SessionId, True, ErrorMessage) = True Then

                    Try

                        SignalR.Classes.ChatHub.SignOut(SecuritySession, SecuritySession.UserCode, True)

                    Catch ex As Exception
                    End Try

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                            DbContext.Database.ExecuteSqlCommand("UPDATE dbo.SEC_USER WITH(ROWLOCK) SET WEB_ID = NULL WHERE SEC_USER_ID = " & SecuritySession.User.ID)

                        End Using

                        WebIdDeleted = True

                    Catch ex As Exception
                        AdvantageFramework.Security.AddWebvantageEventLog("License cleared but error clearing web id.  " & Environment.NewLine & ex.Message.ToString())
                    End Try

                    If WebIdDeleted = True Then

                        'SUCCESS!
                        AdvantageFramework.Security.AddWebvantageEventLog("SessionTimoutModule_SessionEnd cleared License Key and Web Id: " & SecuritySession.User.ID & ", " & SecuritySession.Application & ", " & e.SessionId)

                        'HttpContext.Current.Session.Clear()

                        'System.Web.Security.FormsAuthentication.SignOut()

                    End If

                Else

                    If ErrorMessage.Trim() <> "" Then AdvantageFramework.Security.AddWebvantageEventLog("SessionTimoutModule_SessionEnd error clearing License Key: " & Environment.NewLine & ErrorMessage)

                End If

                Try

                    If String.IsNullOrWhiteSpace(UserLoginAuditID) = False AndAlso IsNumeric(UserLoginAuditID) Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                            DbContext.Database.ExecuteSqlCommand("UPDATE dbo.SEC_USER_LOGIN_AUDIT SET LOGOUT_DATETIME = GETDATE() WHERE SEC_USER_LOGIN_AUDIT_ID = " & UserLoginAuditID)

                        End Using

                    End If

                Catch ex As Exception
                    'AdvantageFramework.Security.AddWebvantageEventLog("License cleared but error clearing web id.  " & Environment.NewLine & ex.Message.ToString())
                End Try

            End Using

            Try

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                    Dim UserID As Integer = 0
                    Dim ApplicationID As Integer = 0
                    Dim CreatedDate As Date = Nothing
                    Dim MACAddressOrSessionID As String = ""
                    Dim SPID As Integer = 0
                    Dim WorkstationName As String = ""

                    For Each AdvantageUserLicenseInUse In AdvantageFramework.Security.Database.Procedures.AdvantageUserLicenseInUse.Load(SecurityDbContext).ToList

                        UserID = 0
                        ApplicationID = 0
                        CreatedDate = Nothing
                        MACAddressOrSessionID = ""
                        SPID = 0
                        WorkstationName = ""

                        If AdvantageFramework.Security.LicenseKey.Methods.ReadUserLicenseKey(AdvantageUserLicenseInUse.Assigned, UserID, ApplicationID, CreatedDate, MACAddressOrSessionID, SPID, WorkstationName) <> "" Then

                            If DateDiff(DateInterval.Hour, CreatedDate.ToUniversalTime, Now.ToUniversalTime) >= 24 Then

                                Try

                                    SecurityDbContext.DeleteEntityObject(AdvantageUserLicenseInUse)
                                    AdvantageFramework.Security.AddWebvantageEventLog("AdvantageFramework.Security.Database.Procedures.AdvantageUserLicenseInUse.Delete called due to > 24.  " & UserID & ", " & ApplicationID & ", " & MACAddressOrSessionID)

                                Catch ex As Exception
                                End Try

                                Try

                                    If UserID > 0 Then

                                        Webvantage.SignalR.Classes.ChatHub.SignOutByUserID(SecuritySession, SecurityDbContext, UserID)

                                    End If

                                Catch ex As Exception
                                End Try

                            End If

                        End If

                    Next

                    Try

                        SecurityDbContext.SaveChanges()

                    Catch ex As Exception
                        AdvantageFramework.Security.AddWebvantageEventLog("Error saving changes when trying to clear licenses active for more than 24 hours." & Environment.NewLine & ex.Message.ToString())
                    End Try


                End Using

            Catch ex As Exception
                AdvantageFramework.Security.AddWebvantageEventLog("Error clearing licenses active for more than 24 hours." & Environment.NewLine & ex.Message.ToString())
            End Try

            Webvantage.SignalR.Classes.ChatHub.SignOut(SecuritySession, SecuritySession.UserCode, True)

        End If

    End Sub

#End Region

End Class
