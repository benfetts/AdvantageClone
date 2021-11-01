Namespace GoogleServices

    Public Class Service

#Region " Constants "

#End Region

#Region " Enum "

        Public Enum ServiceTypes
            [All]
            Calendar
            Gmail
            DoubleClick
        End Enum

#End Region

#Region " Variables "

        Private _ConnectionString As String = Nothing
        Private _EmployeeCode As String = Nothing
        Private _EmailAddress As String = Nothing
        Private _IsWebvantage As Boolean = False
        Private _UseWindowsAuthentication As Boolean = False
        Private _Assembly As System.Reflection.Assembly = Nothing
        Private _MethodInfos As System.Reflection.MethodInfo() = Nothing
        Private _SelectedService As ServiceTypes = ServiceTypes.[All]
        Private _ClientCode As String = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property ServicesAssembly As System.Reflection.Assembly
            Get

                Try

                    If _Assembly Is Nothing Then

                        _Assembly = System.Reflection.Assembly.Load("AdvantageFramework.GoogleServices")

                    End If

                Catch ex As Exception
                    _Assembly = Nothing
                End Try

                Return _Assembly

            End Get
        End Property
        Private ReadOnly Property ServiceMethodInfos As System.Reflection.MethodInfo()
            Get

                Dim Assembly As System.Reflection.Assembly = Nothing
                Dim BaseMethodType As System.Type = Nothing

                Try

                    If _MethodInfos Is Nothing Then

                        Assembly = Me.ServicesAssembly

                        If Assembly IsNot Nothing Then

                            BaseMethodType = LoadBaseMethodType(Assembly)

                            If BaseMethodType IsNot Nothing Then

                                _MethodInfos = BaseMethodType.GetMethods()

                            End If

                        End If

                    End If

                Catch ex As Exception
                    _MethodInfos = Nothing
                End Try

                Return _MethodInfos

            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal SelectedService As ServiceTypes, ByVal ConnectionString As String, ByVal EmployeeCode As String, ByVal EmailAddress As String, ByVal IsWebvantage As Boolean, ByVal UseWindowsAuthentication As Boolean,
                        Optional ByVal ClientCode As String = Nothing)

            _SelectedService = SelectedService
            _ConnectionString = ConnectionString
            _EmployeeCode = EmployeeCode
            _EmailAddress = EmailAddress
            _IsWebvantage = IsWebvantage
            _UseWindowsAuthentication = UseWindowsAuthentication
            _ClientCode = ClientCode

        End Sub
        Private Function LoadBaseMethodType(ByVal Assembly As System.Reflection.Assembly) As System.Type

            'objects
            Dim BaseMethodType As System.Type = Nothing

            Try

                BaseMethodType = Assembly.GetTypes().Where(Function(type) type.FullName = "AdvantageFramework.GoogleServices.Methods").SingleOrDefault

            Catch ex As Exception
                BaseMethodType = Nothing
            Finally
                LoadBaseMethodType = BaseMethodType
            End Try

        End Function
        Private Function LoadCalendarService() As Object

            'objects
            Dim Assembly As System.Reflection.Assembly = Nothing
            Dim GoogleCalendar As Object = Nothing

            Try

                Assembly = Me.ServicesAssembly

                If Assembly IsNot Nothing Then

                    GoogleCalendar = System.Activator.CreateInstance(Assembly.GetType("AdvantageFramework.GoogleServices.Services.Calendar"), {_ConnectionString, _EmployeeCode, _EmailAddress, _IsWebvantage, _UseWindowsAuthentication})

                End If

            Catch ex As Exception
                GoogleCalendar = Nothing
            Finally
                LoadCalendarService = GoogleCalendar
            End Try

        End Function
        Private Function LoadDoubleClickService() As Object

            'objects
            Dim Assembly As System.Reflection.Assembly = Nothing
            Dim DoubleClick As Object = Nothing

            Try

                Assembly = Me.ServicesAssembly

                If Assembly IsNot Nothing Then

                    DoubleClick = System.Activator.CreateInstance(Assembly.GetType("AdvantageFramework.GoogleServices.Services.DoubleClick"), {_ConnectionString, _EmployeeCode, _EmailAddress, _IsWebvantage, _UseWindowsAuthentication, _ClientCode})

                End If

            Catch ex As Exception
                DoubleClick = Nothing
            Finally
                LoadDoubleClickService = DoubleClick
            End Try

        End Function
        Private Function LoadGmailService() As Object

            'objects
            Dim Assembly As System.Reflection.Assembly = Nothing
            Dim Gmail As Object = Nothing

            Try

                Assembly = Me.ServicesAssembly

                If Assembly IsNot Nothing Then

                    Gmail = System.Activator.CreateInstance(Assembly.GetType("AdvantageFramework.GoogleServices.Services.Gmail"), {_ConnectionString, _EmployeeCode, _EmailAddress, _IsWebvantage, _UseWindowsAuthentication})

                End If

            Catch ex As Exception
                Gmail = Nothing
            Finally
                LoadGmailService = Gmail
            End Try

        End Function
        Public Sub WriteToEventLog(ByVal Message As String)

            Select Case _SelectedService

                Case ServiceTypes.Calendar

                    AdvantageFramework.Services.Calendar.WriteToEventLog(Message)

            End Select

        End Sub
        Private Sub AddEventHandlerToService(ByVal GoogleCalendar As Object, ByVal EventName As String, ByVal EventHandlerName As String)

            Dim EventInfo As System.Reflection.EventInfo = Nothing
            Dim MethodInfo As System.Reflection.MethodInfo = Nothing
            Dim [Delegate] As System.Delegate = Nothing

            Try

                EventInfo = GoogleCalendar.GetType().GetEvent(EventName)

                MethodInfo = GetType(Service).GetMethod(EventHandlerName)

                [Delegate] = System.Delegate.CreateDelegate(EventInfo.EventHandlerType, Me, MethodInfo)

                EventInfo.AddEventHandler(GoogleCalendar, [Delegate])

            Catch ex As Exception

            End Try

        End Sub
        Public Function ExchangeCodeForToken(ByVal AuthorizationCode As String) As Boolean

            'objects
            Dim GoogleService As Object = Nothing
            Dim Exchanged As Boolean = False
            Dim MethodInfos As System.Reflection.MethodInfo() = Nothing

            Try

                If _SelectedService = ServiceTypes.All Then

                    MethodInfos = Me.ServiceMethodInfos

                    If MethodInfos IsNot Nothing Then

                        Exchanged = MethodInfos.Where(Function(fnc) fnc.Name = "ExchangeCodeForTokenForAllServices").SingleOrDefault.Invoke(Nothing, {_ConnectionString, _EmployeeCode, AuthorizationCode, _IsWebvantage, _UseWindowsAuthentication, _ClientCode})

                    End If

                Else

                    Select Case _SelectedService

                        Case ServiceTypes.Gmail

                            GoogleService = LoadGmailService()

                        Case ServiceTypes.Calendar

                            GoogleService = LoadCalendarService()

                        Case ServiceTypes.DoubleClick

                            GoogleService = LoadDoubleClickService()

                    End Select

                    If GoogleService IsNot Nothing Then

                        Exchanged = GoogleService.ExchangeCodeForToken(AuthorizationCode)

                    End If

                End If

            Catch ex As Exception
                Exchanged = False
            Finally
                ExchangeCodeForToken = Exchanged
            End Try

        End Function
        Public Function GetAuthorizationUri() As System.Uri

            'objects
            Dim GoogleService As Object = Nothing
            Dim AuthorizationUri As System.Uri = Nothing
            Dim MethodInfos As System.Reflection.MethodInfo() = Nothing

            Try

                If _SelectedService = ServiceTypes.All Then

                    AuthorizationUri = Me.ServiceMethodInfos.SingleOrDefault(Function(fnc) fnc.Name = "GetAuthorizationCodeUriForAllServices").Invoke(Nothing, {_EmailAddress, _IsWebvantage})

                Else

                    Select Case _SelectedService

                        Case ServiceTypes.Calendar

                            GoogleService = LoadCalendarService()

                        Case ServiceTypes.Gmail

                            GoogleService = LoadGmailService()

                        Case ServiceTypes.DoubleClick

                            GoogleService = LoadDoubleClickService()

                    End Select

                    If GoogleService IsNot Nothing Then

                        AuthorizationUri = GoogleService.GetAuthorizationUri()

                    End If

                End If

            Catch ex As Exception
                AuthorizationUri = Nothing
            Finally
                GetAuthorizationUri = AuthorizationUri
            End Try

        End Function
        Public Function Deauthorize() As Boolean

            'objects
            Dim GoogleService As Object = Nothing
            Dim Deauthorized As Boolean = False
            Dim MethodInfos As System.Reflection.MethodInfo() = Nothing

            Try

                If _SelectedService = ServiceTypes.All Then

                    MethodInfos = Me.ServiceMethodInfos

                    If MethodInfos IsNot Nothing Then

                        Deauthorized = MethodInfos.Where(Function(fnc) fnc.Name = "DeauthorizeAll").SingleOrDefault.Invoke(Nothing, {_ConnectionString, _EmployeeCode, _UseWindowsAuthentication, _ClientCode})

                    End If

                Else

                    Select Case _SelectedService

                        Case ServiceTypes.Calendar

                            GoogleService = LoadCalendarService()

                        Case ServiceTypes.Gmail

                            GoogleService = LoadGmailService()

                        Case ServiceTypes.DoubleClick

                            GoogleService = LoadDoubleClickService()

                    End Select

                    If GoogleService IsNot Nothing Then

                        Deauthorized = GoogleService.Deauthorize()

                    End If

                End If

            Catch ex As Exception
                Deauthorized = False
            Finally
                Deauthorize = Deauthorized
            End Try

        End Function
        Public Function Authorize() As Boolean

            'objects
            Dim GoogleService As Object = Nothing
            Dim Authorized As Boolean = False
            Dim MethodInfos As System.Reflection.MethodInfo() = Nothing

            Try

                If _SelectedService = ServiceTypes.All Then

                    MethodInfos = Me.ServiceMethodInfos

                    If MethodInfos IsNot Nothing Then

                        Authorized = MethodInfos.Where(Function(fnc) fnc.Name = "AuthorizeAll").SingleOrDefault.Invoke(Nothing, {_ConnectionString, _EmployeeCode, _UseWindowsAuthentication, _ClientCode})

                    End If

                Else

                    Select Case _SelectedService

                        Case ServiceTypes.Calendar

                            GoogleService = LoadCalendarService()

                        Case ServiceTypes.Gmail

                            GoogleService = LoadGmailService()

                        Case ServiceTypes.DoubleClick

                            GoogleService = LoadDoubleClickService()

                    End Select

                    If GoogleService IsNot Nothing Then

                        Authorized = GoogleService.Authorize()

                    End If

                End If

            Catch ex As Exception
                Authorized = False
            Finally
                Authorize = Authorized
            End Try

        End Function
        Private Function GetAccessTokenValue(ByVal Token As String) As String

            'objects
            Dim AccessToken As String = False
            Dim MethodInfos As System.Reflection.MethodInfo() = Nothing

            Try

                MethodInfos = Me.ServiceMethodInfos

                If MethodInfos IsNot Nothing Then

                    AccessToken = MethodInfos.Where(Function(fnc) fnc.Name = "GetAccessTokenFromToken").SingleOrDefault.Invoke(Nothing, {Token})

                End If

            Catch ex As Exception
                AccessToken = Nothing
            Finally
                GetAccessTokenValue = AccessToken
            End Try

        End Function

#Region " Shared "

        Public Shared Function SyncEmployeeNonTask(ByVal ConnectionString As String, ByVal UserCode As String, ByVal EmployeeCode As String, ByVal EmployeeNonTaskID As Integer,
                                                   ByVal Description As String, ByVal TaskType As String, ByVal IsAllDayEvent As Boolean, ByVal StartDateTime As Date,
                                                   ByVal EndDateTime As Date, ByVal GoogleID As String, ByVal IsDeleting As Boolean, ByVal IsWebvantage As Boolean,
                                                   ByVal UseWindowsAuthentication As Boolean) As Boolean

            'objects
            Dim Syncd As Boolean = False
            Dim GoogleCalendar As Object = Nothing
            Dim Service As AdvantageFramework.GoogleServices.Service = Nothing
            Dim ErrorMessage As String = Nothing

            Try

                Service = New AdvantageFramework.GoogleServices.Service(ServiceTypes.Calendar, ConnectionString, EmployeeCode, Nothing, IsWebvantage, UseWindowsAuthentication)

                GoogleCalendar = Service.LoadCalendarService()

                If GoogleCalendar IsNot Nothing Then

                    Syncd = GoogleCalendar.SyncEmployeeNonTask(EmployeeNonTaskID, Description, TaskType, IsAllDayEvent, StartDateTime, EndDateTime, GoogleID, IsDeleting, ErrorMessage)

                End If

            Catch ex As Exception
                Syncd = False
            Finally
                SyncEmployeeNonTask = Syncd
            End Try

        End Function
        Public Shared Function SyncEmployeeNonTask(ByVal ConnectionString As String, ByVal UserCode As String, ByVal EmployeeCode As String, ByVal EmployeeNonTask As AdvantageFramework.Database.Entities.EmployeeNonTask, ByVal IsDeleting As Boolean, ByVal IsWebvantage As Boolean, ByVal UseWindowsAuthentication As Boolean) As Boolean

            'objects
            Dim Syncd As Boolean = False

            Try

                Syncd = SyncEmployeeNonTask(ConnectionString, UserCode, EmployeeCode, EmployeeNonTask.ID, EmployeeNonTask.Description, EmployeeNonTask.Type, CBool(EmployeeNonTask.IsAllDay.GetValueOrDefault(0)), EmployeeNonTask.StartDateAndTime.Value, EmployeeNonTask.EndDateAndTime.Value, EmployeeNonTask.GoogleID, IsDeleting, IsWebvantage, UseWindowsAuthentication)

            Catch ex As Exception
                Syncd = False
            Finally
                SyncEmployeeNonTask = Syncd
            End Try

        End Function
        Public Shared Sub ProcessGoogleCalendar(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AgencyStandardHours As Decimal, ByVal EmployeeCode As String, ByVal IsWebvantage As Boolean, ByVal UseWindowsAuthentication As Boolean)

            'objects
            Dim GoogleCalendar As Object = Nothing
            Dim Service As AdvantageFramework.GoogleServices.Service = Nothing
            Dim ErrorMessage As String = Nothing

            Try

                Service = Initialize(ServiceTypes.Calendar, DbContext, EmployeeCode, IsWebvantage, UseWindowsAuthentication)

                GoogleCalendar = Service.LoadCalendarService()

                If GoogleCalendar IsNot Nothing Then

                    Service.AddEventHandlerToService(GoogleCalendar, "WriteToEventLogEvent", "WriteToEventLog")

                    GoogleCalendar.ProcessGoogleCalendar(AgencyStandardHours, ErrorMessage)

                End If

            Catch ex As Exception

            End Try

        End Sub
        Public Shared Sub ProcessGoogleCalendarTS(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AgencyStandardHours As Decimal, ByVal EmployeeCode As String, ByVal IsWebvantage As Boolean,
                                                  ByVal UseWindowsAuthentication As Boolean, ByVal PastDays As Integer, ByVal StartDate As DateTime, ByVal EndDate As DateTime, ByVal RTOnly As Boolean, ByRef ErrorMessage As String)

            'objects
            Dim GoogleCalendar As Object = Nothing
            Dim Service As AdvantageFramework.GoogleServices.Service = Nothing
            'Dim ErrorMessage As String = Nothing

            Try

                Service = Initialize(ServiceTypes.Calendar, DbContext, EmployeeCode, IsWebvantage, UseWindowsAuthentication)

                GoogleCalendar = Service.LoadCalendarService()

                If GoogleCalendar IsNot Nothing Then

                    Service.AddEventHandlerToService(GoogleCalendar, "WriteToEventLogEvent", "WriteToEventLog")

                    GoogleCalendar.ProcessGoogleCalendarTS(AgencyStandardHours, PastDays, StartDate, EndDate, RTOnly, ErrorMessage)

                End If

            Catch ex As Exception

            End Try

        End Sub
        Public Shared Function GetAuthorizationUri(ByVal ServiceType As ServiceTypes, ByVal Session As AdvantageFramework.Security.Session, ByVal EmployeeCode As String, ByVal IsWebvantage As Boolean, ByVal UseWindowsAuthentication As Boolean) As System.Uri

            'objects
            Dim Service As AdvantageFramework.GoogleServices.Service = Nothing
            Dim AuthorizationUri As System.Uri = Nothing

            Try

                Service = New AdvantageFramework.GoogleServices.Service(ServiceType, Session.ConnectionString, EmployeeCode, GetEmployeeOrAgencyEmailAddress(Session, EmployeeCode), IsWebvantage, UseWindowsAuthentication)

                AuthorizationUri = Service.GetAuthorizationUri()

            Catch ex As Exception
                AuthorizationUri = Nothing
            Finally
                GetAuthorizationUri = AuthorizationUri
            End Try

        End Function
        Public Shared Function GetEmployeeOrAgencyEmailAddress(ByVal Session As AdvantageFramework.Security.Session, ByVal EmployeeCode As String) As String

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                GetEmployeeOrAgencyEmailAddress = GetEmployeeOrAgencyEmailAddress(DbContext, EmployeeCode)

            End Using

        End Function
        Public Shared Function GetEmployeeOrAgencyEmailAddress(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeCode As String) As String

            Dim EmailAddress As String = Nothing

            Try

                If Not String.IsNullOrWhiteSpace(EmployeeCode) Then

                    EmailAddress = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode).Email

                Else

                    EmailAddress = AdvantageFramework.Database.Procedures.Agency.Load(DbContext).SMTPUserName

                End If

            Catch ex As Exception
                EmailAddress = Nothing
            Finally
                GetEmployeeOrAgencyEmailAddress = EmailAddress
            End Try

        End Function
        Public Shared Function InitializeDoubleClick(ByVal Session As AdvantageFramework.Security.Session, ByVal IsWebvantage As Boolean) As Service

            Return New AdvantageFramework.GoogleServices.Service(AdvantageFramework.GoogleServices.Service.ServiceTypes.DoubleClick, Session.ConnectionString, Nothing, Nothing, IsWebvantage, Session.UseWindowsAuthentication)

        End Function
        Public Shared Function InitializeDoubleClick(ByVal Session As AdvantageFramework.Security.Session, ByVal IsWebvantage As Boolean, ByVal ClientCode As String) As Service

            Return New AdvantageFramework.GoogleServices.Service(AdvantageFramework.GoogleServices.Service.ServiceTypes.DoubleClick, Session.ConnectionString, Nothing, Nothing, IsWebvantage, Session.UseWindowsAuthentication, ClientCode)

        End Function
        Public Shared Function Initialize(ByVal ServiceType As ServiceTypes, ByVal Session As AdvantageFramework.Security.Session, ByVal EmployeeCode As String, ByVal IsWebvantage As Boolean) As Service

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Initialize = Initialize(ServiceType, DbContext, EmployeeCode, IsWebvantage, Session.UseWindowsAuthentication)

            End Using

        End Function
        Public Shared Function Initialize(ByVal ServiceType As ServiceTypes, ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeCode As String, ByVal IsWebvantage As Boolean, ByVal UseWindowsAuthentication As Boolean) As Service

            'objects
            Dim AllowEmail As Boolean = False
            Dim AllowCalendar As Boolean = False
            Dim AllowedServices As ServiceTypes() = GetEnabledServices(DbContext, String.IsNullOrWhiteSpace(EmployeeCode))
            Dim InitializeService As Boolean = False

            AllowEmail = AllowedServices.Contains(ServiceTypes.Gmail)
            AllowCalendar = AllowedServices.Contains(ServiceTypes.Calendar)

            If ServiceType = ServiceTypes.All Then

                InitializeService = AllowEmail AndAlso AllowCalendar

            ElseIf ServiceType = ServiceTypes.Gmail Then

                InitializeService = AllowEmail

            ElseIf ServiceType = ServiceTypes.Calendar Then

                InitializeService = AllowCalendar

            End If

            If InitializeService Then

                Return New AdvantageFramework.GoogleServices.Service(ServiceType, DbContext.ConnectionString, EmployeeCode, GetEmployeeOrAgencyEmailAddress(DbContext, EmployeeCode), IsWebvantage, UseWindowsAuthentication)

            Else

                Return Nothing

            End If

        End Function
        ''' <summary>
        ''' Returns a list of services available at the Agency or Employee level. 
        ''' </summary>
        ''' <param name="Session"></param>
        ''' <param name="AgencyOnly">Set AgencyOnly to True to get only Agency level services. Set to False to return services available to Employees.</param>
        ''' <returns></returns>
        Public Shared Function GetEnabledServices(ByVal Session As AdvantageFramework.Security.Session, ByVal AgencyOnly As Boolean) As ServiceTypes()

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                GetEnabledServices = GetEnabledServices(DbContext, AgencyOnly)

            End Using

        End Function
        Public Shared Function GetEnabledServices(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AgencyOnly As Boolean) As ServiceTypes()

            'objects
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim EnabledServices As List(Of ServiceTypes) = Nothing

            EnabledServices = New List(Of ServiceTypes)

            Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

            If Agency IsNot Nothing Then

                If Agency.SMTPAuthenticationMethodType = AdvantageFramework.Email.SmtpAuthenticationMethods.OAuth2 Then

                    If AgencyOnly OrElse Agency.UseEmployeeEmail.GetValueOrDefault(0) = 1 Then

                        EnabledServices.Add(ServiceTypes.Gmail)

                    End If

                End If

            End If

            If Not AgencyOnly Then

                EnabledServices.Add(ServiceTypes.Calendar)

            End If

            Return EnabledServices.ToArray

        End Function
        Public Shared Function GetAccessTokenFromToken(ByVal ServiceType As ServiceTypes, ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeCode As String, ByVal Token As String, ByVal UeWindowsAuthentication As Boolean)

            'objects
            Dim AccessToken As String = Nothing

            Try

                With Initialize(ServiceType, DbContext, EmployeeCode, False, UeWindowsAuthentication) 'webvantage flag not important here

                    AccessToken = .GetAccessTokenValue(Token)

                End With

            Catch ex As Exception
                AccessToken = Nothing
            Finally
                GetAccessTokenFromToken = AccessToken
            End Try

        End Function

#Region " DoubleClick "

        Public Shared Function DoubleClickGetAdvertisersCampaignsSitesPlacements(Session As AdvantageFramework.Security.Session, IsWebvantage As Boolean, ProfileID As Long,
                                                                                 ByRef DictionaryAdvertisers As Dictionary(Of Long, String),
                                                                                 ByRef DataTable As System.Data.DataTable,
                                                                                 ByRef DictionarySites As Dictionary(Of Long, String),
                                                                                 ByRef DictionaryPlacements As Dictionary(Of Long, Boolean),
                                                                                 AdServerPlacementIDs As IEnumerable(Of String), ByRef ErrorMessage As String) As Boolean

            Dim Service As AdvantageFramework.GoogleServices.Service = Nothing
            Dim DoubleClick As Object = Nothing
            Dim Success As Boolean = False

            Try

                Service = InitializeDoubleClick(Session, IsWebvantage)

                DoubleClick = Service.LoadDoubleClickService()

                If DoubleClick IsNot Nothing Then

                    Success = DoubleClick.GetAdvertisersCampaignsSitesPlacements(ProfileID, DictionaryAdvertisers, DataTable, DictionarySites, DictionaryPlacements, AdServerPlacementIDs, ErrorMessage)

                End If

            Catch ex As Exception
                Success = False
                ErrorMessage = ex.Message
            Finally
                DoubleClickGetAdvertisersCampaignsSitesPlacements = Success
            End Try

        End Function
        Public Shared Function DoubleClickGetAdvertisers(Session As AdvantageFramework.Security.Session, IsWebvantage As Boolean, ProfileID As Long,
                                                         ByRef DictionaryAdvertisers As Dictionary(Of Long, String), ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Service As AdvantageFramework.GoogleServices.Service = Nothing
            Dim DoubleClick As Object = Nothing
            Dim Success As Boolean = False

            Try

                Service = InitializeDoubleClick(Session, IsWebvantage)

                DoubleClick = Service.LoadDoubleClickService()

                If DoubleClick IsNot Nothing Then

                    Success = DoubleClick.GetAdvertisers(ProfileID, ErrorMessage, DictionaryAdvertisers)

                End If

            Catch ex As Exception
                Success = False
                ErrorMessage = ex.Message
            Finally
                DoubleClickGetAdvertisers = Success
            End Try

        End Function
        Public Shared Function DoubleClickGetCampaigns(Session As AdvantageFramework.Security.Session, IsWebvantage As Boolean, ProfileID As Long,
                                                       ByRef DataTable As System.Data.DataTable, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Service As AdvantageFramework.GoogleServices.Service = Nothing
            Dim DoubleClick As Object = Nothing
            Dim Success As Boolean = False

            Try

                Service = InitializeDoubleClick(Session, IsWebvantage)

                DoubleClick = Service.LoadDoubleClickService()

                If DoubleClick IsNot Nothing Then

                    Success = DoubleClick.GetCampaigns(ProfileID, ErrorMessage, DataTable)

                End If

            Catch ex As Exception
                Success = False
                ErrorMessage = ex.Message
            Finally
                DoubleClickGetCampaigns = Success
            End Try

        End Function
        Public Shared Function DoubleClickGetDefaultLandingPage(Session As AdvantageFramework.Security.Session, IsWebvantage As Boolean, ProfileID As Long, DefaultLandingPageId As Long,
                                                                ByRef LandingPageName As String, ByRef LandingPageURL As String, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Service As AdvantageFramework.GoogleServices.Service = Nothing
            Dim DoubleClick As Object = Nothing
            Dim Success As Boolean = False

            Try

                Service = InitializeDoubleClick(Session, IsWebvantage)

                DoubleClick = Service.LoadDoubleClickService()

                If DoubleClick IsNot Nothing Then

                    Success = DoubleClick.GetDefaultLandingPage(ProfileID, ErrorMessage, LandingPageName, LandingPageURL, DefaultLandingPageId)

                End If

            Catch ex As Exception
                Success = False
                ErrorMessage = ex.Message
            Finally
                DoubleClickGetDefaultLandingPage = Success
            End Try

        End Function
        Public Shared Function DoubleClickGetPlacements(Session As AdvantageFramework.Security.Session, IsWebvantage As Boolean, ProfileID As Long,
                                                        AdServerAdvertiserId As IEnumerable(Of String), AdServerSiteId As IEnumerable(Of String),
                                                        ByRef DictionaryPlacements As Dictionary(Of Long, String), ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Service As AdvantageFramework.GoogleServices.Service = Nothing
            Dim DoubleClick As Object = Nothing
            Dim Success As Boolean = False

            Try

                Service = InitializeDoubleClick(Session, IsWebvantage)

                DoubleClick = Service.LoadDoubleClickService()

                If DoubleClick IsNot Nothing Then

                    Success = DoubleClick.GetPlacements(ProfileID, AdServerAdvertiserId, AdServerSiteId, DictionaryPlacements, ErrorMessage)

                End If

            Catch ex As Exception
                Success = False
                ErrorMessage = ex.Message
            Finally
                DoubleClickGetPlacements = Success
            End Try

        End Function
        Public Shared Function DoubleClickGetSites(Session As AdvantageFramework.Security.Session, IsWebvantage As Boolean, ProfileID As Long,
                                                   ByRef DictionarySites As Dictionary(Of Long, String), ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Service As AdvantageFramework.GoogleServices.Service = Nothing
            Dim DoubleClick As Object = Nothing
            Dim Success As Boolean = False

            Try

                Service = InitializeDoubleClick(Session, IsWebvantage)

                DoubleClick = Service.LoadDoubleClickService()

                If DoubleClick IsNot Nothing Then

                    Success = DoubleClick.GetSites(ProfileID, ErrorMessage, DictionarySites)

                End If

            Catch ex As Exception
                Success = False
                ErrorMessage = ex.Message
            Finally
                DoubleClickGetSites = Success
            End Try

        End Function
        Public Shared Function DoubleClickGetSizes(Session As AdvantageFramework.Security.Session, IsWebvantage As Boolean, ProfileID As Long,
                                                   ByRef DictionarySizes As Dictionary(Of Long, String), ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Service As AdvantageFramework.GoogleServices.Service = Nothing
            Dim DoubleClick As Object = Nothing
            Dim Success As Boolean = False

            Try

                Service = InitializeDoubleClick(Session, IsWebvantage)

                DoubleClick = Service.LoadDoubleClickService()

                If DoubleClick IsNot Nothing Then

                    Success = DoubleClick.GetSizes(ProfileID, ErrorMessage, DictionarySizes)

                End If

            Catch ex As Exception
                Success = False
                ErrorMessage = ex.Message
            Finally
                DoubleClickGetSizes = Success
            End Try

        End Function
        Public Shared Function DoubleClickAdvertiserAdd(Session As AdvantageFramework.Security.Session, IsWebvantage As Boolean, ProfileID As Long, ClientCode As String,
                                                        AdvertiserName As String, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Service As AdvantageFramework.GoogleServices.Service = Nothing
            Dim DoubleClick As Object = Nothing
            Dim Added As Boolean = False
            Dim AdServerAdvertiserID As Nullable(Of Long) = Nothing
            Dim ClientCrossReference As AdvantageFramework.Database.Entities.ClientCrossReference = Nothing
            Dim RecordSource As AdvantageFramework.Database.Entities.RecordSource = Nothing

            Try

                Service = InitializeDoubleClick(Session, IsWebvantage)

                DoubleClick = Service.LoadDoubleClickService()

                If DoubleClick IsNot Nothing Then

                    Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        RecordSource = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.RecordSource).Where(Function(RS) RS.Name = "DoubleClick" AndAlso RS.IsSystemSource = True).FirstOrDefault

                        If RecordSource IsNot Nothing Then

                            ClientCrossReference = (From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.ClientCrossReference)
                                                    Where Entity.RecordSourceID = RecordSource.ID AndAlso
                                                          Entity.ClientCode = ClientCode
                                                    Select Entity).FirstOrDefault

                            If ClientCrossReference Is Nothing Then

                                Added = DoubleClick.AdvertiserAdd(ProfileID, AdvertiserName, ErrorMessage, AdServerAdvertiserID)

                                If Added Then

                                    ClientCrossReference = New AdvantageFramework.Database.Entities.ClientCrossReference

                                    ClientCrossReference.DbContext = DbContext
                                    ClientCrossReference.ClientCode = ClientCode
                                    ClientCrossReference.SourceClientCode = AdServerAdvertiserID
                                    ClientCrossReference.RecordSourceID = RecordSource.ID

                                    If AdvantageFramework.Database.Procedures.ClientCrossReference.Insert(DbContext, ClientCrossReference) = False Then

                                        ErrorMessage = "Advertiser was created in DoubleClick but was not linked to Advantage client.  Advantage client:" & ClientCode

                                    End If

                                End If

                            Else

                                Added = True

                            End If

                        Else

                            ErrorMessage = "Record source for 'DoubleClick' cannot be found!"

                        End If

                    End Using

                End If

            Catch ex As Exception
                Added = False
                ErrorMessage = ex.Message
            Finally
                DoubleClickAdvertiserAdd = Added
            End Try

        End Function
        Public Shared Function DoubleClickCampaignAdd(Session As AdvantageFramework.Security.Session, IsWebvantage As Boolean, ProfileID As Long, AdvertiserID As Long, AdServerID As Integer,
                                                      CampaignID As Integer, CampaignName As String, LandingPageName As String, LandingPageURL As String,
                                                      StartDate As Date, EndDate As Date, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Service As AdvantageFramework.GoogleServices.Service = Nothing
            Dim DoubleClick As Object = Nothing
            Dim Added As Boolean = False
            Dim AdServerCampaignID As Nullable(Of Long) = Nothing
            Dim Campaign As AdvantageFramework.Database.Entities.Campaign = Nothing

            Try

                Service = InitializeDoubleClick(Session, IsWebvantage)

                DoubleClick = Service.LoadDoubleClickService()

                If DoubleClick IsNot Nothing Then

                    Added = DoubleClick.CampaignAdd(ProfileID, AdvertiserID, CampaignName, LandingPageName, LandingPageURL, StartDate, EndDate, ErrorMessage, AdServerCampaignID)

                    If Added Then

                        Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                            Campaign = AdvantageFramework.Database.Procedures.Campaign.LoadByCampaignID(DbContext, CampaignID)

                            If Campaign IsNot Nothing Then

                                Campaign.DbContext = DbContext
                                Campaign.AdServerID = AdServerID
                                Campaign.AdServerCampaignID = AdServerCampaignID

                                If AdvantageFramework.Database.Procedures.Campaign.Update(DbContext, Campaign) = False Then

                                    ErrorMessage = "Campaign was created in DoubleClick but was not linked to Advantage campaign.  Advantage campaign ID:" & CampaignID

                                End If

                            Else

                                ErrorMessage = "Campaign was created in DoubleClick but was not linked to Advantage campaign.  Advantage campaign ID:" & CampaignID

                            End If

                        End Using

                    End If

                End If

            Catch ex As Exception
                Added = False
                ErrorMessage = ex.Message
            Finally
                DoubleClickCampaignAdd = Added
            End Try

        End Function
        Public Shared Function DoubleClickPlacementAdd(Session As AdvantageFramework.Security.Session, IsWebvantage As Boolean, ProfileID As Long, OrderNumber As Integer, LineNumbers As String,
                                                       AdServerCampaignID As Long, CampaignName As String, CampaignStartDate As Date, CampaignEndDate As Date,
                                                       InternetTypeDescription As String, AdServerSiteID As Long, Name As String, MediaPlanDetailPackagePlacementNameID As Nullable(Of Integer), PaymentSource As String,
                                                       PlacementStart As Date, PlacementEnd As Date, PricingType As String, AdServerSizeID As Long, TagFormats As IList(Of String),
                                                       PlacementGroupID As Nullable(Of Long), IsNewPackage As Boolean, AdSizeCode As String, CreateByPlacementName As Boolean,
                                                       ByRef DictionaryAdServerPlacementIDNames As Dictionary(Of Long, String),
                                                       Quantity As Nullable(Of Long), Rate As Nullable(Of Decimal), Cost As Nullable(Of Decimal), ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Service As AdvantageFramework.GoogleServices.Service = Nothing
            Dim DoubleClick As Object = Nothing
            Dim Added As Boolean = False
            Dim AdServerPlacementID As Nullable(Of Long) = Nothing
            Dim InternetOrderDetail As AdvantageFramework.Database.Entities.InternetOrderDetail = Nothing
            Dim LineNumber As String() = Nothing
            Dim InternetPackageDetail As AdvantageFramework.Database.Entities.InternetPackageDetail = Nothing
            Dim SqlParameterOrderNumber As New System.Data.SqlClient.SqlParameter("@ORDER_NBR", SqlDbType.Int)
            Dim SqlParameterLineNumbersList As New System.Data.SqlClient.SqlParameter("@LINE_NUMBERS", SqlDbType.VarChar)
            Dim SqlParameterAdSizeCode As New System.Data.SqlClient.SqlParameter("@AD_SIZE_CODE", SqlDbType.VarChar)
            Dim AdditionalAdServerSizeIDs As Generic.List(Of Long) = Nothing

            Try

                Service = InitializeDoubleClick(Session, IsWebvantage)

                DoubleClick = Service.LoadDoubleClickService()

                If DoubleClick IsNot Nothing Then

                    Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        SqlParameterOrderNumber.Value = OrderNumber
                        SqlParameterLineNumbersList.Value = LineNumbers
                        SqlParameterAdSizeCode.Value = AdSizeCode

                        AdditionalAdServerSizeIDs = New Generic.List(Of Long)

                        If Not IsNewPackage Then

                            AdditionalAdServerSizeIDs.AddRange(DbContext.Database.SqlQuery(Of Long)("exec advsp_media_manager_ad_serving_additional_ad_server_size_ids @ORDER_NBR, @LINE_NUMBERS, @AD_SIZE_CODE", SqlParameterOrderNumber, SqlParameterLineNumbersList, SqlParameterAdSizeCode).ToArray)

                        Else

                            AdditionalAdServerSizeIDs.AddRange(GetAdditionalAdSizes(DbContext, OrderNumber, LineNumbers))

                        End If

                        Added = DoubleClick.PlacementAdd(ProfileID, AdServerCampaignID, CampaignName, CampaignStartDate, CampaignEndDate, InternetTypeDescription, AdServerSiteID, Name, PaymentSource,
                                                         PlacementStart, PlacementEnd, PricingType, AdServerSizeID, TagFormats, PlacementGroupID, AdditionalAdServerSizeIDs, Quantity, Rate,
                                                         Cost, ErrorMessage, AdServerPlacementID)

                        If Added Then

                            If DictionaryAdServerPlacementIDNames Is Nothing Then

                                DictionaryAdServerPlacementIDNames = New Dictionary(Of Long, String)

                            End If

                            DictionaryAdServerPlacementIDNames.Add(AdServerPlacementID, Name)

                            LineNumber = LineNumbers.Split(",")

                            For LineCounter As Integer = 0 To UBound(LineNumber)

                                InternetOrderDetail = AdvantageFramework.Database.Procedures.InternetOrderDetail.LoadActiveByOrderNumberLineNumber(DbContext, OrderNumber, CShort(LineNumber(LineCounter)))

                                If InternetOrderDetail IsNot Nothing Then

                                    If IsNewPackage Then

                                        If CreateByPlacementName Then

                                            InternetPackageDetail = (From Entity In AdvantageFramework.Database.Procedures.InternetPackageDetail.LoadByOrderLineActiveRevision(DbContext, InternetOrderDetail.InternetOrderOrderNumber, InternetOrderDetail.LineNumber)
                                                                     Where Entity.MediaPlanDetailPackagePlacementNameID = MediaPlanDetailPackagePlacementNameID
                                                                     Select Entity).SingleOrDefault

                                        Else

                                            InternetPackageDetail = (From Entity In AdvantageFramework.Database.Procedures.InternetPackageDetail.LoadByOrderLineActiveRevision(DbContext, InternetOrderDetail.InternetOrderOrderNumber, InternetOrderDetail.LineNumber)
                                                                     Where Entity.AdSizeCode = AdSizeCode
                                                                     Select Entity).SingleOrDefault

                                        End If

                                        If InternetPackageDetail IsNot Nothing Then

                                            InternetPackageDetail.DbContext = DbContext
                                            InternetPackageDetail.AdServerID = AdvantageFramework.Database.Entities.AdServerID.DoubleClick
                                            InternetPackageDetail.AdServerPlacementID = AdServerPlacementID
                                            InternetPackageDetail.AdServerCreatedBy = Session.UserCode
                                            InternetPackageDetail.AdServerCreatedDateTime = Now

                                            If AdvantageFramework.Database.Procedures.InternetPackageDetail.Update(DbContext, InternetPackageDetail, Nothing) = False Then

                                                ErrorMessage = "Placement was created in DoubleClick but was not linked to Advantage package detail.  Order/Line:" & CStr(OrderNumber & "/" & LineNumber(LineCounter).Trim)

                                            End If

                                        Else

                                            ErrorMessage = "Placement was created in DoubleClick but was not linked to Advantage package detail.  Order/Line:" & CStr(OrderNumber & "/" & LineNumber(LineCounter).Trim)

                                        End If

                                        InternetOrderDetail.DbContext = DbContext
                                        InternetOrderDetail.AdServerID = AdvantageFramework.Database.Entities.AdServerID.DoubleClick
                                        InternetOrderDetail.AdServerPlacementGroupID = PlacementGroupID

                                        If AdvantageFramework.Database.Procedures.InternetOrderDetail.Update(DbContext, InternetOrderDetail) = False Then

                                            ErrorMessage += "Placement was created in DoubleClick but was not linked to Advantage order.  Order/Line:" & CStr(OrderNumber & "/" & LineNumber(LineCounter).Trim)

                                        End If

                                    Else

                                        For Each InternetPackageDetail In (From Entity In AdvantageFramework.Database.Procedures.InternetPackageDetail.LoadByOrderLineActiveRevision(DbContext, InternetOrderDetail.InternetOrderOrderNumber, InternetOrderDetail.LineNumber)
                                                                           Select Entity).ToList

                                            InternetPackageDetail.DbContext = DbContext
                                            InternetPackageDetail.AdServerID = AdvantageFramework.Database.Entities.AdServerID.DoubleClick
                                            InternetPackageDetail.AdServerPlacementID = AdServerPlacementID
                                            InternetPackageDetail.AdServerCreatedBy = Session.UserCode
                                            InternetPackageDetail.AdServerCreatedDateTime = Now

                                            If AdvantageFramework.Database.Procedures.InternetPackageDetail.Update(DbContext, InternetPackageDetail, Nothing) = False Then

                                                ErrorMessage = "Placement was created in DoubleClick but was not linked to Advantage package detail.  Order/Line:" & CStr(OrderNumber & "/" & LineNumber(LineCounter).Trim)

                                            End If

                                        Next

                                        InternetOrderDetail.DbContext = DbContext
                                        InternetOrderDetail.AdServerID = AdvantageFramework.Database.Entities.AdServerID.DoubleClick
                                        InternetOrderDetail.AdServerPlacementID = AdServerPlacementID
                                        InternetOrderDetail.AdServerCreatedBy = Session.UserCode
                                        InternetOrderDetail.AdServerCreatedDateTime = Now
                                        InternetOrderDetail.AdServerPlacementGroupID = PlacementGroupID

                                        If AdvantageFramework.Database.Procedures.InternetOrderDetail.Update(DbContext, InternetOrderDetail) = False Then

                                            ErrorMessage = "Placement was created in DoubleClick but was not linked to Advantage order.  Order/Line:" & CStr(OrderNumber & "/" & LineNumber(LineCounter).Trim)

                                        End If

                                    End If

                                Else

                                    ErrorMessage = "Placement was created in DoubleClick but was not linked to Advantage order.  Order/Line:" & CStr(OrderNumber & "/" & LineNumber(LineCounter).Trim)

                                End If

                            Next

                        End If

                    End Using

                End If

            Catch ex As Exception
                Added = False
                ErrorMessage = ex.Message
            Finally
                DoubleClickPlacementAdd = Added
            End Try

        End Function
        Public Shared Function DoubleClickPlacementUpdate(Session As AdvantageFramework.Security.Session, IsWebvantage As Boolean, ProfileID As Long, OrderNumber As Integer, LineNumbers As String,
                                                          AdServerPlacementID As Long, Name As String, MediaPlanDetailPackagePlacementNameID As Nullable(Of Integer), PlacementStart As Date, PlacementEnd As Date, PricingType As String, AdServerSizeID As Long,
                                                          AdServerCampaignID As Long, CampaignName As String, CampaignStartDate As Date, CampaignEndDate As Date, IsNewPackage As Boolean, AdSizeCode As String,
                                                          Quantity As Nullable(Of Long), Rate As Nullable(Of Decimal), Cost As Nullable(Of Decimal), CreateByPlacementName As Boolean,
                                                          ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Service As AdvantageFramework.GoogleServices.Service = Nothing
            Dim DoubleClick As Object = Nothing
            Dim Updated As Boolean = False
            Dim InternetOrderDetail As AdvantageFramework.Database.Entities.InternetOrderDetail = Nothing
            Dim LineNumber As String() = Nothing
            Dim InternetPackageDetail As AdvantageFramework.Database.Entities.InternetPackageDetail = Nothing
            Dim SqlParameterOrderNumber As New System.Data.SqlClient.SqlParameter("@ORDER_NBR", SqlDbType.Int)
            Dim SqlParameterLineNumbersList As New System.Data.SqlClient.SqlParameter("@LINE_NUMBERS", SqlDbType.VarChar)
            Dim SqlParameterAdSizeCode As New System.Data.SqlClient.SqlParameter("@AD_SIZE_CODE", SqlDbType.VarChar)
            Dim AdditionalAdServerSizeIDs As Generic.List(Of Long) = Nothing

            Try

                Service = InitializeDoubleClick(Session, IsWebvantage)

                DoubleClick = Service.LoadDoubleClickService()

                If DoubleClick IsNot Nothing Then

                    Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        SqlParameterOrderNumber.Value = OrderNumber
                        SqlParameterLineNumbersList.Value = LineNumbers
                        SqlParameterAdSizeCode.Value = AdSizeCode

                        AdditionalAdServerSizeIDs = New Generic.List(Of Long)

                        If Not IsNewPackage Then

                            AdditionalAdServerSizeIDs.AddRange(DbContext.Database.SqlQuery(Of Long)("exec advsp_media_manager_ad_serving_additional_ad_server_size_ids @ORDER_NBR, @LINE_NUMBERS, @AD_SIZE_CODE", SqlParameterOrderNumber, SqlParameterLineNumbersList, SqlParameterAdSizeCode).ToArray)

                        Else

                            AdditionalAdServerSizeIDs.AddRange(GetAdditionalAdSizes(DbContext, OrderNumber, LineNumbers))

                        End If

                        Updated = DoubleClick.PlacementUpdate(ProfileID, AdServerPlacementID, Name, PlacementStart, PlacementEnd, PricingType, AdServerSizeID, AdServerCampaignID, CampaignName, CampaignStartDate, CampaignEndDate, AdditionalAdServerSizeIDs, Quantity, Rate, Cost, ErrorMessage)

                        If Updated Then

                            LineNumber = LineNumbers.Split(",")

                            For LineCounter As Integer = 0 To UBound(LineNumber)

                                InternetOrderDetail = AdvantageFramework.Database.Procedures.InternetOrderDetail.LoadActiveByOrderNumberLineNumber(DbContext, OrderNumber, CShort(LineNumber(LineCounter)))

                                If InternetOrderDetail IsNot Nothing Then

                                    If IsNewPackage Then

                                        If CreateByPlacementName Then

                                            InternetPackageDetail = (From Entity In AdvantageFramework.Database.Procedures.InternetPackageDetail.LoadByOrderLineActiveRevision(DbContext, InternetOrderDetail.InternetOrderOrderNumber, InternetOrderDetail.LineNumber)
                                                                     Where Entity.MediaPlanDetailPackagePlacementNameID = MediaPlanDetailPackagePlacementNameID
                                                                     Select Entity).SingleOrDefault

                                        Else

                                            InternetPackageDetail = (From Entity In AdvantageFramework.Database.Procedures.InternetPackageDetail.LoadByOrderLineActiveRevision(DbContext, InternetOrderDetail.InternetOrderOrderNumber, InternetOrderDetail.LineNumber)
                                                                     Where Entity.AdSizeCode = AdSizeCode
                                                                     Select Entity).SingleOrDefault

                                        End If

                                        If InternetPackageDetail IsNot Nothing Then

                                            InternetPackageDetail.DbContext = DbContext
                                            InternetPackageDetail.AdServerID = AdvantageFramework.Database.Entities.AdServerID.DoubleClick
                                            InternetPackageDetail.AdServerPlacementID = AdServerPlacementID

                                            If Not InternetPackageDetail.AdServerCreatedDateTime.HasValue Then

                                                InternetPackageDetail.AdServerCreatedBy = Session.UserCode
                                                InternetPackageDetail.AdServerCreatedDateTime = Now

                                            End If

                                            InternetPackageDetail.AdServerLastModifiedBy = Session.UserCode
                                            InternetPackageDetail.AdServerLastModifiedByDateTime = Now

                                            If AdvantageFramework.Database.Procedures.InternetPackageDetail.Update(DbContext, InternetPackageDetail, Nothing) = False Then

                                                ErrorMessage = "Placement was updated in DoubleClick but was not linked to Advantage package detail.  Order/Line:" & CStr(OrderNumber & "/" & LineNumber(LineCounter).Trim)

                                            End If

                                        Else

                                            ErrorMessage = "Placement was updated in DoubleClick but was not linked to Advantage package detail.  Order/Line:" & CStr(OrderNumber & "/" & LineNumber(LineCounter).Trim)

                                        End If

                                        'InternetOrderDetail.DbContext = DbContext
                                        'InternetOrderDetail.AdServerID = AdvantageFramework.Database.Entities.AdServerID.DoubleClick

                                        'If AdvantageFramework.Database.Procedures.InternetOrderDetail.Update(DbContext, InternetOrderDetail) = False Then

                                        '    ErrorMessage += "Placement was updated in DoubleClick but was not linked to Advantage order.  Order/Line:" & CStr(OrderNumber & "/" & LineNumber(LineCounter).Trim)

                                        'End If

                                    Else

                                        For Each InternetPackageDetail In (From Entity In AdvantageFramework.Database.Procedures.InternetPackageDetail.LoadByOrderLineActiveRevision(DbContext, InternetOrderDetail.InternetOrderOrderNumber, InternetOrderDetail.LineNumber)
                                                                           Select Entity).ToList

                                            InternetPackageDetail.DbContext = DbContext
                                            InternetPackageDetail.AdServerID = AdvantageFramework.Database.Entities.AdServerID.DoubleClick
                                            InternetPackageDetail.AdServerPlacementID = AdServerPlacementID
                                            InternetPackageDetail.AdServerLastModifiedBy = Session.UserCode
                                            InternetPackageDetail.AdServerLastModifiedByDateTime = Now

                                            If AdvantageFramework.Database.Procedures.InternetPackageDetail.Update(DbContext, InternetPackageDetail, Nothing) = False Then

                                                ErrorMessage = "Placement was created in DoubleClick but was not linked to Advantage package detail.  Order/Line:" & CStr(OrderNumber & "/" & LineNumber(LineCounter).Trim)

                                            End If

                                        Next

                                        InternetOrderDetail.DbContext = DbContext
                                        InternetOrderDetail.AdServerID = AdvantageFramework.Database.Entities.AdServerID.DoubleClick
                                        InternetOrderDetail.AdServerPlacementID = AdServerPlacementID

                                        If Not InternetOrderDetail.AdServerCreatedDateTime.HasValue Then

                                            InternetOrderDetail.AdServerCreatedDateTime = Now
                                            InternetOrderDetail.AdServerCreatedBy = Session.UserCode

                                        End If

                                        InternetOrderDetail.AdServerLastModifiedBy = Session.UserCode
                                        InternetOrderDetail.AdServerLastModifiedByDateTime = Now

                                        If AdvantageFramework.Database.Procedures.InternetOrderDetail.Update(DbContext, InternetOrderDetail) = False Then

                                            ErrorMessage = "Placement was updated in DoubleClick but was not updated on Advantage order.  Order/Line:" & CStr(OrderNumber & "/" & LineNumber(LineCounter).Trim)

                                        End If

                                    End If

                                Else

                                    ErrorMessage = "Placement was updated in DoubleClick but was not updated on Advantage order.  Order/Line:" & CStr(OrderNumber & "/" & LineNumber(LineCounter).Trim)

                                End If

                            Next

                        End If

                    End Using

                End If

            Catch ex As Exception
                Updated = False
                ErrorMessage = ex.Message
            Finally
                DoubleClickPlacementUpdate = Updated
            End Try

        End Function
        Public Shared Function DoubleClickSetPackageArchived(Session As AdvantageFramework.Security.Session, IsWebvantage As Boolean, ProfileID As Long,
                                                             AdServerPlacementGroupID As Long, IsArchived As Boolean,
                                                             ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Service As AdvantageFramework.GoogleServices.Service = Nothing
            Dim DoubleClick As Object = Nothing
            Dim Updated As Boolean = False

            Try

                Service = InitializeDoubleClick(Session, IsWebvantage)

                DoubleClick = Service.LoadDoubleClickService()

                If DoubleClick IsNot Nothing Then

                    Updated = DoubleClick.SetPackageArchived(ProfileID, AdServerPlacementGroupID, IsArchived, ErrorMessage)

                End If

            Catch ex As Exception
                Updated = False
                ErrorMessage = ex.Message
            Finally
                DoubleClickSetPackageArchived = Updated
            End Try

        End Function
        Public Shared Function DoubleClickSetPlacementArchived(Session As AdvantageFramework.Security.Session, IsWebvantage As Boolean, ProfileID As Long,
                                                               AdServerPlacementID As Long, IsArchived As Boolean,
                                                               ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Service As AdvantageFramework.GoogleServices.Service = Nothing
            Dim DoubleClick As Object = Nothing
            Dim Updated As Boolean = False

            Try

                Service = InitializeDoubleClick(Session, IsWebvantage)

                DoubleClick = Service.LoadDoubleClickService()

                If DoubleClick IsNot Nothing Then

                    Updated = DoubleClick.SetPlacementArchived(ProfileID, AdServerPlacementID, IsArchived, ErrorMessage)

                End If

            Catch ex As Exception
                Updated = False
                ErrorMessage = ex.Message
            Finally
                DoubleClickSetPlacementArchived = Updated
            End Try

        End Function
        Public Shared Function DoubleClickRunReport(Session As AdvantageFramework.Security.Session, IsWebvantage As Boolean, ProfileID As Long,
                                                    ReportID As Long, RelativeDateRange As String,
                                                    ByRef MemoryStream As System.IO.MemoryStream, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Service As AdvantageFramework.GoogleServices.Service = Nothing
            Dim DoubleClick As Object = Nothing
            Dim Updated As Boolean = False

            Try

                Service = InitializeDoubleClick(Session, IsWebvantage)

                DoubleClick = Service.LoadDoubleClickService()

                If DoubleClick IsNot Nothing Then

                    Updated = DoubleClick.RunReport(ProfileID, ReportID, RelativeDateRange, MemoryStream, ErrorMessage)

                End If

            Catch ex As Exception
                Updated = False
                ErrorMessage = ex.Message
            Finally
                DoubleClickRunReport = Updated
            End Try

        End Function
        Public Shared Function DoubleClickPackageAdd(Session As AdvantageFramework.Security.Session, IsWebvantage As Boolean, ProfileID As Long,
                                                     AdvertiserID As Long, AdServerSiteID As Integer, CampaignID As Integer, CampaignName As String, CampaignStartDate As Date, CampaignEndDate As Date,
                                                     PackageName As String, PricingType As String, StartDate As Date, EndDate As Date,
                                                     Quantity As Nullable(Of Long), Rate As Nullable(Of Decimal), Cost As Nullable(Of Decimal),
                                                     ByRef ErrorMessage As String, ByRef PlacementGroupID As Nullable(Of Long)) As Boolean

            'objects
            Dim Service As AdvantageFramework.GoogleServices.Service = Nothing
            Dim DoubleClick As Object = Nothing
            Dim Added As Boolean = False

            Try

                Service = InitializeDoubleClick(Session, IsWebvantage)

                DoubleClick = Service.LoadDoubleClickService()

                If DoubleClick IsNot Nothing Then

                    Added = DoubleClick.PackageAdd(ProfileID, AdvertiserID, PackageName, CampaignID, CampaignName, CampaignStartDate, CampaignEndDate, AdServerSiteID, PricingType, StartDate, EndDate, Quantity, Rate, Cost, ErrorMessage, PlacementGroupID)

                End If

            Catch ex As Exception
                Added = False
                ErrorMessage = ex.Message
            Finally
                DoubleClickPackageAdd = Added
            End Try

        End Function
        Public Shared Function DoubleClickGetNonIABStandardSizes(Session As AdvantageFramework.Security.Session, IsWebvantage As Boolean, ProfileID As Long,
                                                                 ByRef DictionarySizes As Dictionary(Of Long, String), ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Service As AdvantageFramework.GoogleServices.Service = Nothing
            Dim DoubleClick As Object = Nothing
            Dim Success As Boolean = False

            Try

                Service = InitializeDoubleClick(Session, IsWebvantage)

                DoubleClick = Service.LoadDoubleClickService()

                If DoubleClick IsNot Nothing Then

                    Success = DoubleClick.GetNonIabStandardSizes(ProfileID, ErrorMessage, DictionarySizes)

                End If

            Catch ex As Exception
                Success = False
                ErrorMessage = ex.Message
            Finally
                DoubleClickGetNonIABStandardSizes = Success
            End Try

        End Function
        Private Shared Function GetAdditionalAdSizes(DbContext As AdvantageFramework.Database.DbContext, OrderNumber As Integer, LineNumbers As String) As IEnumerable(Of Long)

            Dim LineNbrs As Generic.List(Of Short) = Nothing
            Dim AdSize As AdvantageFramework.Database.Entities.AdSize = Nothing
            Dim AdServerSizeIDs As Generic.List(Of Long) = Nothing

            LineNbrs = New Generic.List(Of Short)

            For Each LineNum In LineNumbers.Split(",")

                LineNbrs.Add(CShort(LineNum))

            Next

            AdServerSizeIDs = New Generic.List(Of Long)

            For Each AddlAdSizeCodes In (From Entity In AdvantageFramework.Database.Procedures.InternetPackageDetail.LoadActiveRevisionsByOrderLines(DbContext, OrderNumber, LineNbrs.ToArray)
                                         Select Entity.AdditionalAdSizeCodes).Distinct.ToList

                If AddlAdSizeCodes IsNot Nothing AndAlso AddlAdSizeCodes.Count > 0 Then

                    For Each AdSizeCode In AddlAdSizeCodes.Split(",")

                        AdSize = AdvantageFramework.Database.Procedures.AdSize.LoadByCodeAndMediaType(DbContext, AdSizeCode, "I")

                        If AdSize IsNot Nothing AndAlso AdSize.AdServerSizeID.HasValue Then

                            AdServerSizeIDs.Add(AdSize.AdServerSizeID.Value)

                        End If

                    Next

                End If

            Next

            GetAdditionalAdSizes = AdServerSizeIDs.ToArray

        End Function
        Public Shared Function DoubleClickPackageUpdate(Session As AdvantageFramework.Security.Session, IsWebvantage As Boolean, ProfileID As Long,
                                                        PlacementGroupID As Long, CampaignID As Integer, CampaignName As String, CampaignStartDate As Date, CampaignEndDate As Date,
                                                        PackageName As String, PricingType As String, StartDate As Date, EndDate As Date,
                                                        Quantity As Nullable(Of Long), Rate As Nullable(Of Decimal), Cost As Nullable(Of Decimal),
                                                        ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Service As AdvantageFramework.GoogleServices.Service = Nothing
            Dim DoubleClick As Object = Nothing
            Dim Updated As Boolean = False

            Try

                Service = InitializeDoubleClick(Session, IsWebvantage)

                DoubleClick = Service.LoadDoubleClickService()

                If DoubleClick IsNot Nothing Then

                    Updated = DoubleClick.PackageUpdate(ProfileID, PlacementGroupID, PackageName, CampaignID, CampaignName, CampaignStartDate, CampaignEndDate, PricingType, StartDate, EndDate, Quantity, Rate, Cost, ErrorMessage)

                End If

            Catch ex As Exception
                Updated = False
                ErrorMessage = ex.Message
            Finally
                DoubleClickPackageUpdate = Updated
            End Try

        End Function

#End Region

#End Region

#End Region

    End Class

End Namespace

