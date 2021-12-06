Imports System.Web.Mvc
Imports AdvantageFramework.Database.Entities
Imports System.Collections.Generic
Imports Webvantage.ViewModels
Imports System
Imports System.Linq
Imports System.Web
Imports Newtonsoft.Json
Imports Microsoft.AspNet.SignalR

Public Class MVCControllerBase
    Inherits Controller

#Region " Constants "


#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _SecuritySession As AdvantageFramework.Security.Session = Nothing
    Private _CurrentEmployeeCode As String = String.Empty
    Private _CurrentUserCode As String = String.Empty
    Private _CurrentClientPortalUserID As Integer = 0
    'Private _hubContext As IHubContext '(Of Webvantage.SignalR.Classes.NotificationHub)

    'Public Sub New(ByVal hubContext As IHubContext(Of Webvantage.SignalR.Classes.NotificationHub))
    '    _hubContext = hubContext
    'End Sub

#End Region

#Region " Properties "

    'Public Property NotificationHub() As IHubContext '(Of Webvantage.SignalR.Classes.NotificationHub)
    '    Get
    '        If _hubContext Is Nothing Then

    '            Try

    '                _hubContext = GlobalHost.ConnectionManager.GetHubContext(Of Webvantage.SignalR.Classes.NotificationHub)()

    '            Catch ex As Exception
    '            End Try

    '        End If

    '        Return _hubContext

    '    End Get
    '    Set(value As IHubContext)

    '        _hubContext = value

    '    End Set
    'End Property
    Public Property SecuritySession() As AdvantageFramework.Security.Session
        Get
            Return _SecuritySession
        End Get
        Set(ByVal value As AdvantageFramework.Security.Session)
            _SecuritySession = value
        End Set
    End Property
    Public Property CurrentEmployeeCode As String
        Get
            Return _CurrentEmployeeCode
        End Get
        Set(value As String)
            _CurrentEmployeeCode = value
        End Set
    End Property
    Public Property CurrentUserCode As String
        Get
            Return _CurrentUserCode
        End Get
        Set(value As String)
            _CurrentUserCode = value
        End Set
    End Property
    Public Property CurrentClientPortalUserID As Integer
        Get
            Return _CurrentClientPortalUserID
        End Get
        Set(value As Integer)
            _CurrentClientPortalUserID = value
        End Set
    End Property
    Private Property _Locale As String
    Public ReadOnly Property Locale As String
        Get
            Return _Locale
        End Get
    End Property
    Public ReadOnly Property CurrentQueryString As AdvantageFramework.Web.QueryString
        Get
            Dim QueryString As AdvantageFramework.Web.QueryString = New AdvantageFramework.Web.QueryString
            QueryString = QueryString.FromCurrent
            Return QueryString
        End Get
    End Property
    Public ReadOnly Property TimeZoneOffset As Decimal
        Get
            Return cEmployee.GetTimeZoneOffset()
        End Get
    End Property
    Public ReadOnly Property TimeZoneToday As DateTime
        Get
            Try

                Dim Offset As Decimal = cEmployee.GetTimeZoneOffset()

                If Offset <> 0 Then

                    Return DateAdd(DateInterval.Hour, Offset, CType(Now, DateTime))

                Else

                    Return Now.Date

                End If

            Catch ex As Exception
                Return Now.Date
            End Try
        End Get
    End Property
    Public Function HasAccessToTimesheet() As Boolean

        Dim HasAccess As Boolean = False
        Dim SessionKey As String = "HasAccessToTimesheet"

        If Session(SessionKey) Is Nothing Then

            Try

                If MiscFN.IsClientPortal = False Then

                    HasAccess = AdvantageFramework.Security.DoesUserHaveAccessToModule(SecuritySession,
                                                                                       AdvantageFramework.Security.Modules.Employee_Timesheet.ToString,
                                                                                       SecuritySession.User)

                End If

            Catch ex As Exception
                HasAccess = False
            End Try

            Session(SessionKey) = HasAccess

        Else

            HasAccess = CType(Session(SessionKey), Boolean)

        End If

        Return HasAccess

    End Function

    Public Function IsClientPortalActive() As Boolean

        Dim ClientPortalIsActive As Boolean = False

        If Session(AdvantageFramework.Proofing.IsClientPortalSessionKey) Is Nothing Then

            If SecuritySession IsNot Nothing Then

                Try

                    Dim Version As String = String.Empty
                    Dim VersionKeys() As String = Nothing

                    Version = System.Configuration.ConfigurationManager.AppSettings("VCtrl")

                    If Version <> "##DEV##" Then

                        Version = AdvantageFramework.Security.DecryptVersionKey("VersionEncryptor2007", Version)
                        VersionKeys = Version.Split("|")

                        If VersionKeys(4).ToString = "1" Then

                            ClientPortalIsActive = True

                        Else

                            ClientPortalIsActive = False

                        End If

                    End If
                Catch ex As Exception
                    ClientPortalIsActive = False
                End Try

            End If

            Session(AdvantageFramework.Proofing.IsClientPortalSessionKey) = ClientPortalIsActive

        Else

            ClientPortalIsActive = CType(Session(AdvantageFramework.Proofing.IsClientPortalSessionKey), Boolean)

        End If

        Return ClientPortalIsActive


    End Function
    Public Function IsProofingToolActive(ByRef SecuritySession As AdvantageFramework.Security.Session) As Boolean

        Dim ProofingIsActive As Boolean = False

        If Session(AdvantageFramework.Proofing.ProofingSessionKey) Is Nothing Then

            If SecuritySession IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                    Try

                        ProofingIsActive = AdvantageFramework.Proofing.IsProofingToolActive(SecuritySession, DbContext, MiscFN.IsClientPortal)

                    Catch ex As Exception
                        ProofingIsActive = False
                    End Try

                End Using

            End If

            Session(AdvantageFramework.Proofing.ProofingSessionKey) = ProofingIsActive

        Else

            ProofingIsActive = CType(Session(AdvantageFramework.Proofing.ProofingSessionKey), Boolean)

        End If

        Return ProofingIsActive

    End Function
    Public Function IsConceptShareToolActive(ByRef SecuritySession As AdvantageFramework.Security.Session) As Boolean

        Dim ConceptShareIsActive As Boolean = False

        If Session(AdvantageFramework.Proofing.ConceptShareSessionKey) Is Nothing Then

            If SecuritySession IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                    Try

                        ConceptShareIsActive = AdvantageFramework.Proofing.IsConceptShareActive(SecuritySession, DbContext, MiscFN.IsClientPortal)

                    Catch ex As Exception
                        ConceptShareIsActive = False
                    End Try

                End Using

            End If

            Session(AdvantageFramework.Proofing.ConceptShareSessionKey) = ConceptShareIsActive

        Else

            ConceptShareIsActive = CType(Session(AdvantageFramework.Proofing.ConceptShareSessionKey), Boolean)

        End If

        Return ConceptShareIsActive

    End Function

#End Region

#Region " Methods "

    <AcceptVerbs("POST")>
    Public Function ExtendSession() As JsonResult

        Dim Success As Boolean = False
        Dim ErrorMessage As String = String.Empty

        Try

            If Me.SecuritySession IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Success = True

                End Using

            End If

        Catch ex As Exception
            ErrorMessage = ex.Message.ToString
        End Try

        Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, Nothing))

    End Function
    'Public Sub ThrowError()

    '    Throw New Exception("TEST ERROR:  " & DateTime.Now.ToString())

    'End Sub

    '    Throw New Exception("TEST ERROR:  " & DateTime.Now.ToString())

    'End Sub

    Protected Overrides Sub OnException(filterContext As ExceptionContext)

        filterContext.ExceptionHandled = True

        Dim Errors As New System.Text.StringBuilder
        Dim RawURL As String = String.Empty
        Dim OriginalString As String = String.Empty
        Dim URL As String = String.Empty
        Dim AbsoluteUri As String = String.Empty
        Dim PhysicalPath As String = String.Empty
        Dim WriteMessage As Boolean = False
        Dim FullErrorString As String = String.Empty
        Try

            Errors.Append("Triggered from MVCControllerBase.vb")
            Errors.Append(Environment.NewLine)

        Catch ex As Exception
        End Try
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

            FullErrorString = AdvantageFramework.StringUtilities.FullErrorToString(filterContext.Exception)
            Errors.Append(FullErrorString)

        Catch ex As Exception
        End Try
        If Errors IsNot Nothing AndAlso Errors.Length > 0 Then

            Errors.Append(Environment.NewLine)
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

                Dim Message As String = Errors.ToString()

                If AdvantageFramework.StringUtilities.IgnoreError(Message) = False Then

                    AdvantageFramework.Security.AddWebvantageEventLog(Message, Diagnostics.EventLogEntryType.Error)

                End If

            End If

        Catch ex As Exception
        End Try

        MyBase.OnException(filterContext)

    End Sub
    Protected Overrides Sub Initialize(requestContext As System.Web.Routing.RequestContext)

        If requestContext.HttpContext.Session("Security_Session") Is Nothing AndAlso Not requestContext.HttpContext.Session("ConnString") Is Nothing AndAlso Not requestContext.HttpContext.Session("UserCode") Is Nothing Then

            If IsNothing(requestContext.HttpContext.Session("UserGUID")) Then

                _SecuritySession = New AdvantageFramework.Security.Session(AdvantageFramework.Security.Application.Webvantage, requestContext.HttpContext.Session("ConnString"), requestContext.HttpContext.Session("UserCode"), CInt(requestContext.HttpContext.Session("AdvantageUserLicenseInUseID")), requestContext.HttpContext.Session("ConnString"))
                requestContext.HttpContext.Session("Security_Session") = _SecuritySession

            Else

                _SecuritySession = New AdvantageFramework.Security.Session(AdvantageFramework.Security.Application.Client_Portal, requestContext.HttpContext.Session("ConnString"), requestContext.HttpContext.Session("UserCode"), CInt(requestContext.HttpContext.Session("AdvantageUserLicenseInUseID")), requestContext.HttpContext.Session("ConnString"))
                requestContext.HttpContext.Session("Security_Session") = _SecuritySession

            End If

        Else

            _SecuritySession = requestContext.HttpContext.Session("Security_Session")

        End If
        If requestContext.HttpContext.Session("EmpCode") IsNot Nothing Then

            _CurrentEmployeeCode = requestContext.HttpContext.Session("EmpCode")

        End If
        If requestContext.HttpContext.Session("UserCode") IsNot Nothing Then

            _CurrentUserCode = requestContext.HttpContext.Session("UserCode")

        End If
        If requestContext.HttpContext.Session("UserID") IsNot Nothing Then

            _CurrentClientPortalUserID = requestContext.HttpContext.Session("UserID")

        End If

        _Locale = "en-US"

        Try

            If requestContext.HttpContext IsNot Nothing AndAlso requestContext.HttpContext.Request IsNot Nothing Then

                If Not requestContext.HttpContext.Request.Cookies("LoGloCode") Is Nothing AndAlso
                    Not requestContext.HttpContext.Request.Cookies("LoGloCode").Value Is Nothing Then

                    _Locale = requestContext.HttpContext.Request.Cookies("LoGloCode").Value

                Else

                    _Locale = "en-US"

                End If
            End If

        Catch ex As Exception
            _Locale = "en-US"
        End Try

        'Try

        '    _hubContext = GlobalHost.ConnectionManager.GetHubContext(Of Webvantage.SignalR.Classes.NotificationHub)()

        'Catch ex As Exception
        'End Try

        ' TP: this is needed for Kendo MVC Helpers to render correctly!
        Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo(_Locale)

        MyBase.Initialize(requestContext)

    End Sub
    Public Sub LogError(ExceptionToLog As Exception)

        'Dim LogRepo As Repositories.EventLogRepository = Nothing
        'LogRepo = New Repositories.EventLogRepository()
        'LogRepo.SendToEventLog(ExceptionToLog)

    End Sub
    Public Function FullErrorMessageToString(ByVal Ex As Exception) As String

        Try

            If Ex IsNot Nothing Then

                Dim ErrorMessage As New Text.StringBuilder

                If String.IsNullOrWhiteSpace(Ex.Message) = False Then

                    ErrorMessage.AppendLine(Ex.Message)

                End If

                If Ex.InnerException IsNot Nothing AndAlso String.IsNullOrWhiteSpace(Ex.InnerException.Message) = False Then

                    ErrorMessage.AppendLine(Environment.NewLine)
                    ErrorMessage.AppendLine("  INNER:  ")
                    ErrorMessage.AppendLine(Environment.NewLine)
                    ErrorMessage.AppendLine(Ex.InnerException.Message)

                End If

                Return ErrorMessage.ToString

            Else

                Return String.Empty

            End If

        Catch ex1 As Exception
            Return "ERROR IN FullErrorMessageToString"
        End Try

    End Function

#Region " -- Helpers -- "

    Public Function LoadUserGroupSettingAccess(ByVal GroupSetting As AdvantageFramework.Security.GroupSettings) As Integer
        Dim i As Integer = 0
        Dim SessionKey As String = "LoadUserGroupSettingAccess" & GroupSetting.ToString()
        If HttpContext.Session(SessionKey) Is Nothing Then
            i = Convert.ToInt32(AdvantageFramework.Security.LoadUserGroupSetting(Me.SecuritySession, GroupSetting).Any(Function(SettingValue) SettingValue = True))
            HttpContext.Session(SessionKey) = i
        Else
            i = CType(HttpContext.Session(SessionKey), Integer)
        End If
        Return i
    End Function

    Public Function Lookup(ByVal LookupModel As Webvantage.Models.LookupModel) As ViewResult

        Return View("~/Views/Shared/Lookup.vbhtml", LookupModel)

    End Function
    Public Function Aurelia(ByVal Model As Webvantage.ViewModels.AureliaModel) As ViewResult

        Return View("~/Views/Shared/Aurelia.vbhtml", Model)

    End Function
    Public Function ImageResult(ByVal Image As System.Drawing.Image, ByVal ImageFormat As System.Drawing.Imaging.ImageFormat) As ImageResult

        'objects
        Dim Result As ImageResult = Nothing

        Try

            If Image IsNot Nothing Then

                Result = New ImageResult

                Result.Image = Image
                Result.ImageFormat = ImageFormat

            End If

        Catch ex As Exception
            Result = Nothing
        End Try

        Return Result

    End Function
    Public Function MaxJson(ByVal Data As Object, ByVal Behavior As JsonRequestBehavior) As JsonResult

        'Objects
        Dim Result As JsonResult = Nothing

        Result = MaxJson(Data)
        Result.JsonRequestBehavior = Behavior

        Return Result

    End Function
    Public Function MaxJson(ByVal Data As Object) As JsonResult

        'Objects
        Dim Result As JsonResult = Nothing

        Result = Json(Data)

        Result.MaxJsonLength = Int32.MaxValue

        Return Result

    End Function

#End Region

#End Region

End Class
