Imports System.Data.SqlClient

Namespace Services

    Public Class Calendar
        Inherits Base.ServiceBase

#Region " Constants "

        Public Const ExtendedPropertyName As String = "BillingInformation"

#End Region

#Region " Enum "


#End Region

#Region " Variables "

#End Region

#Region " Properties "

        Public Shared ReadOnly Property Scope As String
            Get
                Return "https://www.googleapis.com/auth/calendar.events.owned"
            End Get
        End Property

#End Region

#Region " Methods "

#Region " -- Time Zone --"

        Public Function DisplayLocalDate([Date] As Date, TimeZoneOffset As Integer) As Nullable(Of Date)

            Dim LocalDate As Nullable(Of Date) = Nothing
            Dim Offset As Decimal = Nothing

            'If DatabaseDate.HasValue AndAlso TimeZoneOffset.AgencyOffset <> 99 AndAlso
            '		TimeZoneOffset.DatabaseOffset <> 99 AndAlso TimeZoneOffset.AgencyOffset <> TimeZoneOffset.DatabaseOffset Then

            '	Offset = (TimeZoneOffset.DatabaseOffset - TimeZoneOffset.AgencyOffset) * -1

            '	LocalDate = DateAdd(DateInterval.Minute, (CType(Offset, Integer) * 60) + ((Offset - CType(Offset, Integer)) * 60), DatabaseDate.Value)

            'Else

            '	LocalDate = DatabaseDate

            'End If

            DisplayLocalDate = LocalDate

        End Function
        Public Function LoadDatabaseTimeZoneID(DataContext As Database.DataContext) As String

            'objects
            Dim DatabaseTimeZoneID As String = String.Empty

            Try

                DatabaseTimeZoneID = DataContext.ExecuteQuery(Of String)("SELECT ISNULL(DB_TIMEZONE_ID, '') FROM dbo.AGENCY WITH(NOLOCK);").FirstOrDefault

            Catch ex As Exception
                DatabaseTimeZoneID = String.Empty
            End Try

            LoadDatabaseTimeZoneID = DatabaseTimeZoneID

        End Function
        Public Function LoadAgencyTimeZoneID(DataContext As Database.DataContext) As String

            'objects
            Dim AgencyTimeZoneID As String = String.Empty

            Try

                AgencyTimeZoneID = DataContext.ExecuteQuery(Of String)("SELECT ISNULL(TIMEZONE_ID, '') FROM dbo.AGENCY WITH(NOLOCK);").FirstOrDefault

            Catch ex As Exception
                AgencyTimeZoneID = String.Empty
            End Try

            LoadAgencyTimeZoneID = AgencyTimeZoneID

        End Function
        Public Function LoadEmployeeTimeZoneID(DataContext As Database.DataContext, EmployeeCode As String) As String

            'objects
            Dim EmployeeTimeZoneID As String = String.Empty

            Try

                EmployeeTimeZoneID = DataContext.ExecuteQuery(Of String)(String.Format("SELECT ISNULL(TIME_ZONE_ID, '') FROM EMPLOYEE WITH(NOLOCK) WHERE EMP_CODE = '{0}';", EmployeeCode)).FirstOrDefault

            Catch ex As Exception
                EmployeeTimeZoneID = String.Empty
            End Try

            LoadEmployeeTimeZoneID = EmployeeTimeZoneID

        End Function
        Public Function LoadSQLHoursOffset(DataContext As Database.DataContext) As Decimal

            'objects
            Dim SQLHoursOffset As Decimal = 0.0
            Dim DatabaseTimeZoneID As String = String.Empty

            DatabaseTimeZoneID = LoadDatabaseTimeZoneID(DataContext)

            SQLHoursOffset = GetOffsetFromSystemTimeZone(DatabaseTimeZoneID)

            LoadSQLHoursOffset = SQLHoursOffset

        End Function
        Public Function LoadAgencyHoursOffset(DataContext As Database.DataContext) As Decimal

            'objects
            Dim AgencyHoursOffset As Decimal = 0.0
            Dim AgencyTimeZoneID As String = String.Empty

            AgencyTimeZoneID = LoadAgencyTimeZoneID(DataContext)

            AgencyHoursOffset = GetOffsetFromSystemTimeZone(AgencyTimeZoneID)

            LoadAgencyHoursOffset = AgencyHoursOffset

        End Function
        Public Function LoadEmployeeHoursOffset(DataContext As Database.DataContext, EmployeeCode As String) As Decimal

            'objects
            Dim EmployeeHoursOffset As Decimal = 0.0
            Dim EmployeeTimeZoneID As String = String.Empty

            EmployeeTimeZoneID = LoadEmployeeTimeZoneID(DataContext, EmployeeCode)

            EmployeeHoursOffset = GetOffsetFromSystemTimeZone(EmployeeTimeZoneID)

            LoadEmployeeHoursOffset = EmployeeHoursOffset

        End Function
        Public Function LoadTimeZoneOffsetForEmployee(DataContext As Database.DataContext, EmployeeCode As String) As Decimal

            Dim Offset As Decimal = CType(0.0, Decimal)
            Dim DatabaseOffset As Decimal = CType(0.0, Decimal)
            Dim AgencyOffset As Decimal = CType(0.0, Decimal)
            Dim EmployeeOffset As Decimal = CType(0.0, Decimal)

            Try

                DatabaseOffset = LoadSQLHoursOffset(DataContext)

            Catch ex As Exception
                DatabaseOffset = 0
            End Try

            If DatabaseOffset <> 0 Then 'if not using UTC zero then must have a database setting to act as anchor for the offset!

                Try

                    AgencyOffset = LoadAgencyHoursOffset(DataContext)

                Catch ex As Exception
                    AgencyOffset = 0.0
                End Try
                Try

                    If String.IsNullOrWhiteSpace(EmployeeCode) = False Then

                        EmployeeOffset = LoadEmployeeHoursOffset(DataContext, EmployeeCode)

                    End If

                Catch ex As Exception
                    EmployeeOffset = 0.0
                End Try

                If EmployeeOffset = 0 Then

                    Offset = (AgencyOffset - DatabaseOffset) * -1

                Else

                    Offset = (EmployeeOffset - DatabaseOffset) * -1

                End If

            End If

            LoadTimeZoneOffsetForEmployee = Offset

        End Function
        Public Function LoadTimeZoneOffsetForEmployeeForceUtcZero(DataContext As Database.DataContext, EmployeeCode As String) As Decimal

            Dim Offset As Decimal = CType(0.0, Decimal)
            Dim DatabaseOffset As Decimal = CType(0.0, Decimal)
            Dim AgencyOffset As Decimal = CType(0.0, Decimal)
            Dim EmployeeOffset As Decimal = CType(0.0, Decimal)

            Try

                If String.IsNullOrWhiteSpace(EmployeeCode) = False Then

                    EmployeeOffset = LoadEmployeeHoursOffset(DataContext, EmployeeCode)

                End If

                Offset = EmployeeOffset

            Catch ex As Exception
                EmployeeOffset = 0.0
            End Try

            If Offset = 0 Then

                Try

                    AgencyOffset = LoadAgencyHoursOffset(DataContext)

                Catch ex As Exception
                    AgencyOffset = 0.0
                End Try

                Offset = AgencyOffset

            End If

            If Offset = 0 Then

                Try

                    DatabaseOffset = LoadSQLHoursOffset(DataContext)

                Catch ex As Exception
                    DatabaseOffset = 0
                End Try

                Offset = DatabaseOffset

            End If

            LoadTimeZoneOffsetForEmployeeForceUtcZero = Offset

        End Function
        Public Function GetOffsetFromSystemTimeZone(TimeZoneID As String) As Decimal

            Dim Offset As Decimal = 0.0
            Dim TimeZone As TimeZoneInfo = Nothing

            If String.IsNullOrWhiteSpace(TimeZoneID) = False Then

                Try

                    TimeZone = TimeZoneInfo.FindSystemTimeZoneById(TimeZoneID)

                    If TimeZone IsNot Nothing Then

                        Offset = CType(TimeZone.BaseUtcOffset.Hours + (TimeZone.BaseUtcOffset.Minutes / 60), Decimal)

                        If TimeZone.IsDaylightSavingTime(Now.Date) = True Then

                            Offset += 1

                        End If

                    End If

                Catch ex As Exception
                    Offset = 0.0
                End Try

            End If

            GetOffsetFromSystemTimeZone = Offset

        End Function
        Public Function GetOffsetFromSystemTimeZone(TimeZone As TimeZoneInfo) As TimeSpan

            Dim Offset As TimeSpan = Nothing

            Offset = New TimeSpan(0)

            If TimeZone IsNot Nothing Then

                Try

                    Offset = TimeZone.BaseUtcOffset

                    If TimeZone.IsDaylightSavingTime(Now.Date) = True Then

                        Offset = Offset.Add(TimeSpan.FromHours(1))

                    End If

                Catch ex As Exception
                    Offset = New TimeSpan(0)
                End Try

            End If

            GetOffsetFromSystemTimeZone = Offset

        End Function
        Public Function LoadTimeZoneInfo(DataContext As Database.DataContext, EmployeeCode As String) As TimeZoneInfo

            Dim TimeZoneInfo As TimeZoneInfo = Nothing
            Dim Offset As Decimal = CType(0.0, Decimal)
            Dim DatabaseOffset As Decimal = CType(0.0, Decimal)
            Dim AgencyOffset As Decimal = CType(0.0, Decimal)
            Dim EmployeeOffset As Decimal = CType(0.0, Decimal)
            Dim DatabaseTimeZone As TimeZoneInfo = Nothing
            Dim AgencyTimeZone As TimeZoneInfo = Nothing
            Dim EmployeeTimeZone As TimeZoneInfo = Nothing
            Dim DatabaseTimeZoneID As String = String.Empty
            Dim AgencyTimeZoneID As String = String.Empty
            Dim EmployeeTimeZoneID As String = String.Empty

            Try

                DatabaseTimeZoneID = LoadDatabaseTimeZoneID(DataContext)

                DatabaseTimeZone = GetTimeZoneInfo(DatabaseTimeZoneID)

                DatabaseOffset = GetOffsetFromSystemTimeZone(DatabaseTimeZoneID)

            Catch ex As Exception
                DatabaseOffset = 0
            End Try

            If DatabaseOffset <> 0 Then 'if not using UTC zero then must have a database setting to act as anchor for the offset!

                Try

                    AgencyTimeZoneID = LoadAgencyTimeZoneID(DataContext)

                    AgencyTimeZone = GetTimeZoneInfo(AgencyTimeZoneID)

                    AgencyOffset = GetOffsetFromSystemTimeZone(AgencyTimeZoneID)

                Catch ex As Exception
                    AgencyOffset = 0.0
                End Try

                Try

                    If String.IsNullOrWhiteSpace(EmployeeCode) = False Then

                        EmployeeTimeZoneID = LoadEmployeeTimeZoneID(DataContext, EmployeeCode)

                        EmployeeTimeZone = GetTimeZoneInfo(EmployeeTimeZoneID)

                        EmployeeOffset = GetOffsetFromSystemTimeZone(EmployeeTimeZoneID)

                    End If

                Catch ex As Exception
                    EmployeeOffset = 0.0
                End Try

                If EmployeeOffset = 0 Then

                    TimeZoneInfo = AgencyTimeZone

                    Offset = (AgencyOffset - DatabaseOffset) * -1

                Else

                    TimeZoneInfo = EmployeeTimeZone

                    Offset = (EmployeeOffset - DatabaseOffset) * -1

                End If

            End If

            LoadTimeZoneInfo = TimeZoneInfo

        End Function
        Public Function GetTimeZoneInfo(TimeZoneID As String) As TimeZoneInfo

            Dim TimeZone As TimeZoneInfo = Nothing

            If String.IsNullOrWhiteSpace(TimeZoneID) = False Then

                Try

                    TimeZone = TimeZoneInfo.FindSystemTimeZoneById(TimeZoneID)

                Catch ex As Exception
                    TimeZone = Nothing
                End Try

            End If

            GetTimeZoneInfo = TimeZone

        End Function
        Private Function BuildRFC3339DateString([Date] As Date, TimeZoneInfo As TimeZoneInfo) As String

            Dim RFC3339DateString As String = String.Empty
            Dim UseTimeZoneInfo As TimeZoneInfo = Nothing
            Dim Offset As TimeSpan = Nothing

            If TimeZoneInfo Is Nothing Then

                UseTimeZoneInfo = System.TimeZoneInfo.Local

            Else

                UseTimeZoneInfo = TimeZoneInfo

            End If

            Offset = GetOffsetFromSystemTimeZone(UseTimeZoneInfo)

            RFC3339DateString = [Date].Year.ToString("0000") & "-" & [Date].Month.ToString("00") & "-" & [Date].Day.ToString("00") & "T" & [Date].Hour.ToString("00") & ":" & [Date].Minute.ToString("00") & ":" & [Date].Second.ToString("00")

            If Offset.Hours < 0 Then

                RFC3339DateString &= "-" & Math.Abs(Offset.Hours).ToString("00") & ":" & Math.Abs(Offset.Minutes).ToString("00")

            Else

                RFC3339DateString &= "+" & Math.Abs(Offset.Hours).ToString("00") & ":" & Math.Abs(Offset.Minutes).ToString("00")

            End If

            BuildRFC3339DateString = RFC3339DateString

        End Function

#End Region

#Region "  -- Authorization -- "

        Private Function IsServiceAuthorized(CalendarService As Google.Apis.Calendar.v3.CalendarService, CalendarID As String) As Boolean

            'objects
            Dim IsAuthorized As Boolean = False
            Dim ListRequest As Google.Apis.Calendar.v3.EventsResource.ListRequest = Nothing

            Try

                ListRequest = CalendarService.Events.List(CalendarID) 'call errors if not authorized

                ListRequest.MaxResults = 1

                ListRequest.Execute()

                IsAuthorized = True

            Catch ex As Exception
                IsAuthorized = False
            Finally
                IsServiceAuthorized = IsAuthorized
            End Try

        End Function
        Private Function LoadService(DataContext As AdvantageFramework.GoogleServices.Database.DataContext,
                                     Employee As AdvantageFramework.GoogleServices.Database.Entities.Employee,
                                     ByRef ErrorMessage As String) As Google.Apis.Calendar.v3.CalendarService

            'objects
            Dim CalendarService As Google.Apis.Calendar.v3.CalendarService = Nothing
            Dim Initializer As Google.Apis.Services.BaseClientService.Initializer = Nothing
            Dim IsAuthorized As Boolean = False

            Try

                Initializer = CreateInitializer(DataContext, Employee)

                If Initializer IsNot Nothing Then

                    CalendarService = New Google.Apis.Calendar.v3.CalendarService(Initializer)

                    IsAuthorized = IsServiceAuthorized(CalendarService, Employee.Email)

                End If

                If IsAuthorized = False Then

                    ErrorMessage = "Advantage Calendar Sync is not authorized to access your calendar."

                End If

            Catch ex As Exception
                ErrorMessage = "Advantage Calendar Sync failed. Please contact software support."
                CalendarService = Nothing
            Finally
                LoadService = CalendarService
            End Try

        End Function
        Private Function LoadServiceCalendarTime(DataContext As AdvantageFramework.GoogleServices.Database.DataContext,
                                     Employee As AdvantageFramework.GoogleServices.Database.Entities.Employee,
                                     ByRef ErrorMessage As String) As Google.Apis.Calendar.v3.CalendarService

            'objects
            Dim CalendarService As Google.Apis.Calendar.v3.CalendarService = Nothing
            Dim Initializer As Google.Apis.Services.BaseClientService.Initializer = Nothing
            Dim IsAuthorized As Boolean = False

            Try

                Initializer = CreateInitializer(DataContext, Employee)

                If Initializer IsNot Nothing Then

                    CalendarService = New Google.Apis.Calendar.v3.CalendarService(Initializer)

                    IsAuthorized = IsServiceAuthorized(CalendarService, Employee.CalendarTimeEmail)

                End If

                If IsAuthorized = False Then

                    ErrorMessage = "Webvantage Calendar Sync is not authorized to access your calendar. Please check Google email, User ID, and password."

                End If

            Catch ex As Exception
                ErrorMessage = "Webvantage Calendar Sync failed. Please contact software support."
                CalendarService = Nothing
            Finally
                LoadServiceCalendarTime = CalendarService
            End Try

        End Function
        Private Function LoadService(DataContext As AdvantageFramework.GoogleServices.Database.DataContext, EmployeeCode As String, ByRef ErrorMessage As String) As Google.Apis.Calendar.v3.CalendarService

            'objects
            Dim CalendarService As Google.Apis.Calendar.v3.CalendarService = Nothing
            Dim Employee As AdvantageFramework.GoogleServices.Database.Entities.Employee = Nothing
            Dim IsAuthorized As Boolean = False

            Try

                Employee = AdvantageFramework.GoogleServices.Database.Procedures.Employee.LoadByEmployeeCode(DataContext, EmployeeCode)

                If Employee IsNot Nothing Then

                    CalendarService = LoadService(DataContext, Employee, ErrorMessage)

                End If

            Catch ex As Exception
                ErrorMessage = "Advantage Calendar Sync failed. Please contact software support."
                CalendarService = Nothing
            Finally
                LoadService = CalendarService
            End Try

        End Function

#End Region

#Region "  -- Data Access -- "

        Private Function GetEvent(CalendarService As Google.Apis.Calendar.v3.CalendarService, EventID As String, CalendarID As String) As Google.Apis.Calendar.v3.Data.Event

            'objects
            Dim [Event] As Google.Apis.Calendar.v3.Data.Event = Nothing

            Try

                [Event] = CalendarService.Events.Get(CalendarID, EventID).Execute()

            Catch ex As Exception
                [Event] = Nothing
            Finally
                GetEvent = [Event]
            End Try

        End Function
        Private Function GetEventList(CalendarService As Google.Apis.Calendar.v3.CalendarService, CalendarID As String,
                                      Optional StartDate As Date? = Nothing,
                                      Optional EndDate As Date? = Nothing,
                                      Optional ShowDeleted As Boolean = False,
                                      Optional SingleEvents As Boolean = False,
                                      Optional ShowHiddenInvitations As Boolean = False,
                                      Optional MaxToRetrieve As Integer? = 250) As Google.Apis.Calendar.v3.Data.Events

            'objects
            Dim Events As Google.Apis.Calendar.v3.Data.Events = Nothing
            Dim ListRequest As Google.Apis.Calendar.v3.EventsResource.ListRequest = Nothing

            Try

                ListRequest = CalendarService.Events.List(CalendarID)

                If StartDate.HasValue Then

                    ListRequest.TimeMin = StartDate

                End If

                If EndDate.HasValue Then

                    ListRequest.TimeMax = EndDate

                End If

                If MaxToRetrieve.HasValue Then

                    ListRequest.MaxResults = MaxToRetrieve

                End If

                ListRequest.ShowDeleted = ShowDeleted
                ListRequest.SingleEvents = SingleEvents
                ListRequest.ShowHiddenInvitations = ShowHiddenInvitations

                Events = ListRequest.Execute()

            Catch ex As Exception
                Events = Nothing
            Finally
                GetEventList = Events
            End Try

        End Function
        Private Function CreateEvent(CalendarService As Google.Apis.Calendar.v3.CalendarService, CalendarID As String, Description As String, [Start] As Date, [End] As Date, IsAllDayEvent As Boolean, TimeZoneInfo As TimeZoneInfo) As Google.Apis.Calendar.v3.Data.Event

            'objects
            Dim [Event] As Google.Apis.Calendar.v3.Data.Event = Nothing
            Dim InsertedEvent As Google.Apis.Calendar.v3.Data.Event = Nothing

            Try

                [Event] = New Google.Apis.Calendar.v3.Data.Event

                FillEventObject([Event], Description, Start, [End], IsAllDayEvent, TimeZoneInfo)

                InsertedEvent = CalendarService.Events.Insert([Event], CalendarID).Execute()

            Catch ex As Exception
                InsertedEvent = Nothing
            Finally
                CreateEvent = InsertedEvent
            End Try

        End Function
        Private Function UpdateEvent(CalendarService As Google.Apis.Calendar.v3.CalendarService, [Event] As Google.Apis.Calendar.v3.Data.Event, CalendarID As String, Description As String,
                                     [Start] As Date, [End] As Date, IsAllDayEvent As Boolean, TimeZoneInfo As TimeZoneInfo) As Boolean

            'objects
            Dim Updated As Boolean = False

            Try

                FillEventObject([Event], Description, Start, [End], IsAllDayEvent, TimeZoneInfo)

                Updated = UpdateEvent(CalendarService, [Event], CalendarID)

            Catch ex As Exception
                Updated = False
            Finally
                UpdateEvent = Updated
            End Try

        End Function
        Private Function UpdateEvent(CalendarService As Google.Apis.Calendar.v3.CalendarService, [Event] As Google.Apis.Calendar.v3.Data.Event, CalendarID As String) As Boolean

            'objects
            Dim Updated As Boolean = False

            Try

                CalendarService.Events.Update([Event], CalendarID, [Event].Id).Execute()

                Updated = True

            Catch ex As Exception
                Updated = False
            Finally
                UpdateEvent = Updated
            End Try

        End Function
        Private Function DeleteEvent(CalendarService As Google.Apis.Calendar.v3.CalendarService, [Event] As Google.Apis.Calendar.v3.Data.Event, CalendarID As String) As Boolean

            'objects
            Dim Deleted As Boolean = False

            Try

                CalendarService.Events.Delete(CalendarID, [Event].Id).Execute()

                Deleted = True

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteEvent = Deleted
            End Try

        End Function
        Private Sub FillEventObject(ByRef [Event] As Google.Apis.Calendar.v3.Data.Event, Description As String, [Start] As Date, [End] As Date,
                                     IsAllDayEvent As Boolean, TimeZoneInfo As TimeZoneInfo)

            [Event].Summary = Description ' summary = title

            'If IsAllDayEvent Then

            '             [Event].Start = New Google.Apis.Calendar.v3.Data.EventDateTime() With {.DateTime = CDate([Start].Date.ToShortDateString)}
            '             [Event].End = New Google.Apis.Calendar.v3.Data.EventDateTime() With {.DateTime = CDate([End].Date.ToShortDateString)}

            '         Else

            '[Event].Start = New Google.Apis.Calendar.v3.Data.EventDateTime() With {.DateTime = DateAdd(DateInterval.Minute, (TimeZoneOffset * 60) + ((TimeZoneOffset - TimeZoneOffset) * 60), [Start])}
            '[Event].End = New Google.Apis.Calendar.v3.Data.EventDateTime() With {.DateTime = DateAdd(DateInterval.Minute, (TimeZoneOffset * 60) + ((TimeZoneOffset - TimeZoneOffset) * 60), [End])}

            If [Event].Start Is Nothing Then

                [Event].Start = New Google.Apis.Calendar.v3.Data.EventDateTime() With {.DateTimeRaw = BuildRFC3339DateString([Start], TimeZoneInfo)}

            Else

                [Event].Start.DateTimeRaw = BuildRFC3339DateString([Start], TimeZoneInfo)

            End If

            If [Event].End Is Nothing Then

                [Event].End = New Google.Apis.Calendar.v3.Data.EventDateTime() With {.DateTimeRaw = BuildRFC3339DateString([End], TimeZoneInfo)}

            Else

                [Event].End.DateTimeRaw = BuildRFC3339DateString([End], TimeZoneInfo)

            End If

            'If TimeZoneInfo IsNot Nothing AndAlso System.TimeZoneInfo.Local.Id <> TimeZoneInfo.Id Then

            '    [Event].Start.DateTimeRaw = BuildRFC3339DateString([Start], TimeZoneInfo)
            '    [Event].End.DateTimeRaw = BuildRFC3339DateString([End], TimeZoneInfo)

            'Else

            '    [Event].Start = New Google.Apis.Calendar.v3.Data.EventDateTime() With {.DateTime = [Start]}
            '    [Event].End = New Google.Apis.Calendar.v3.Data.EventDateTime() With {.DateTime = [End]}

            'End If

            'End If

        End Sub
        Private Function IsValidExtendedProperty(ExtendedProperty As KeyValuePair(Of String, String)) As Boolean

            'objects
            Dim IsValid As Boolean = False

            If IsNothing(ExtendedProperty) = False Then

                IsValid = Not IsNothing(ExtendedProperty.Key)

            End If

            IsValidExtendedProperty = IsValid

        End Function

#End Region

#Region " Public "

        Public Function SyncEmployeeNonTask(EmployeeNonTaskID As Integer, Description As String, TaskType As String, IsAllDayEvent As Boolean, StartDateTime As Date,
                                            EndDateTime As Date, GoogleID As String, IsDeleting As Boolean, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Employee As AdvantageFramework.GoogleServices.Database.Entities.Employee = Nothing
            Dim CalendarService As Google.Apis.Calendar.v3.CalendarService = Nothing
            Dim Syncd As Boolean = False
            Dim TimeZoneInfo As TimeZoneInfo = Nothing

            Try

                If String.IsNullOrWhiteSpace(Me.EmployeeCode) = False Then

                    Using DataContext = New AdvantageFramework.GoogleServices.Database.DataContext(Me.ConnectionString, Me.UseWindowsAuthentication)

                        Employee = AdvantageFramework.GoogleServices.Database.Procedures.Employee.LoadByEmployeeCode(DataContext, Me.EmployeeCode)

                        If Employee IsNot Nothing Then

                            TimeZoneInfo = LoadTimeZoneInfo(DataContext, Me.EmployeeCode)

                            CalendarService = LoadService(DataContext, Employee, ErrorMessage)

                            If CalendarService IsNot Nothing Then

                                Syncd = SyncEmployeeNonTask(DataContext, CalendarService, Employee, EmployeeNonTaskID, Description, TaskType, IsAllDayEvent, StartDateTime, EndDateTime, GoogleID, IsDeleting, TimeZoneInfo, ErrorMessage)

                            Else

                                If String.IsNullOrWhiteSpace(ErrorMessage) Then

                                    ErrorMessage = "Error loading Advantage Calendar Sync. Please contact software support."

                                End If

                            End If

                        End If

                    End Using

                End If

            Catch ex As Exception
                Syncd = False
            Finally
                SyncEmployeeNonTask = Syncd
            End Try

            SyncEmployeeNonTask = True

        End Function
        Private Function SyncEmployeeNonTask(DataContext As AdvantageFramework.GoogleServices.Database.DataContext,
                                             CalendarService As Google.Apis.Calendar.v3.CalendarService,
                                             Employee As AdvantageFramework.GoogleServices.Database.Entities.Employee,
                                             EmployeeNonTaskID As Integer, Description As String, TaskType As String, IsAllDayEvent As Boolean, StartDateTime As Date,
                                             EndDateTime As Date, GoogleID As String, IsDeleting As Boolean,
                                             TimeZoneInfo As TimeZoneInfo, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim CalendarID As String = Nothing
            Dim [Event] As Google.Apis.Calendar.v3.Data.Event = Nothing
            Dim Syncd As Boolean = False
            Dim ExtendedProperty As KeyValuePair(Of String, String) = Nothing
            Dim InsertedEvent As Google.Apis.Calendar.v3.Data.Event = Nothing

            Try

                CalendarID = Employee.Email

                If String.IsNullOrEmpty(GoogleID) = False Then

                    [Event] = GetEvent(CalendarService, GoogleID, CalendarID)

                End If

                If [Event] IsNot Nothing Then

                    If GoogleID IsNot Nothing AndAlso GoogleID = [Event].Id Then

                        Try

                            If IsDeleting Then

                                DeleteEvent(CalendarService, [Event], CalendarID)

                            Else

                                UpdateEvent(CalendarService, [Event], CalendarID, Description, StartDateTime, EndDateTime, IsAllDayEvent, TimeZoneInfo)

                            End If

                            Syncd = True

                        Catch ex As Exception
                            Syncd = False
                        End Try

                    End If

                End If

                If Syncd = False AndAlso [Event] IsNot Nothing Then

                    Try

                        ExtendedProperty = [Event].ExtendedProperties.Shared.FirstOrDefault(Function(ExtProp) ExtProp.Key = ExtendedPropertyName AndAlso ExtProp.Value = TaskType & EmployeeNonTaskID.ToString)

                    Catch ex As Exception
                        ExtendedProperty = Nothing
                    End Try

                    If IsValidExtendedProperty(ExtendedProperty) Then

                        Try

                            If IsDeleting Then

                                DeleteEvent(CalendarService, [Event], CalendarID)

                            Else

                                UpdateEvent(CalendarService, [Event], CalendarID, Description, StartDateTime, EndDateTime, IsAllDayEvent, TimeZoneInfo)

                            End If

                            Syncd = True

                        Catch ex As Exception
                            Syncd = False
                        End Try

                    End If

                End If

                If Syncd = False AndAlso (GoogleID Is Nothing OrElse GoogleID = "") Then

                    InsertedEvent = CreateEvent(CalendarService, CalendarID, Description, StartDateTime, EndDateTime, IsAllDayEvent, TimeZoneInfo)

                    'EventQuery = New Google.GData.Calendar.EventQuery

                    'EventQuery.Uri = New Uri(String.Format("https://www.google.com/calendar/feeds/{0}/private/full", Employee.Email))

                    'InsertedEvent = CalendarService.Insert(EventQuery.Uri, [Event])

                    If InsertedEvent IsNot Nothing Then

                        Syncd = True

                        Try

                            DataContext.ExecuteCommand(String.Format("UPDATE [dbo].[EMP_NON_TASKS] SET [GOOGLE_ID] = '{0}' WHERE [NON_TASK_ID] = {1}", InsertedEvent.Id, EmployeeNonTaskID))

                        Catch ex As Exception

                        End Try

                        Try

                            If InsertedEvent.ExtendedProperties Is Nothing Then

                                InsertedEvent.ExtendedProperties = New Google.Apis.Calendar.v3.Data.Event.ExtendedPropertiesData

                            End If

                            If InsertedEvent.ExtendedProperties.Shared Is Nothing Then

                                InsertedEvent.ExtendedProperties.Shared = New Generic.Dictionary(Of String, String)

                            End If

                            InsertedEvent.ExtendedProperties.Shared.Add(ExtendedPropertyName, TaskType & EmployeeNonTaskID.ToString)

                            UpdateEvent(CalendarService, InsertedEvent, CalendarID, Description, StartDateTime, EndDateTime, IsAllDayEvent, TimeZoneInfo)

                        Catch ex As Exception

                        End Try

                    End If

                End If

            Catch ex As Exception
                Syncd = False
            Finally
                SyncEmployeeNonTask = Syncd
            End Try

        End Function
        Public Sub ProcessGoogleCalendar(AgencyStandardHours As Decimal, ByRef ErrorMessage As String)

            'objects
            Dim CalendarService As Google.Apis.Calendar.v3.CalendarService = Nothing
            Dim Events As Google.Apis.Calendar.v3.Data.Events = Nothing
            Dim [Event] As Google.Apis.Calendar.v3.Data.Event = Nothing
            Dim ExtendedProperty As KeyValuePair(Of String, String) = Nothing
            Dim EmployeeNonTask As AdvantageFramework.GoogleServices.Database.Entities.EmployeeNonTask = Nothing
            Dim Employee As AdvantageFramework.GoogleServices.Database.Entities.Employee = Nothing
            Dim CalendarID As String = Nothing
            Dim IsUpdating As Boolean = False
            Dim DayDifference As Integer = Nothing
            Dim EventsDictionary As Generic.Dictionary(Of Google.Apis.Calendar.v3.Data.Event, AdvantageFramework.GoogleServices.Database.Entities.EmployeeNonTask) = Nothing
            Dim StartDateCutoff As Date = Nothing
            Dim EndDateCutoff As Date = Nothing
            Dim TimeZoneInfo As TimeZoneInfo = Nothing
            Dim AgencyTimeZoneOffset As Integer = 0
            Dim StartDateTimeOffset As DateTimeOffset = Nothing
            Dim EndDateTimeOffset As DateTimeOffset = Nothing
            Dim StartDateAndTime As Date = Date.MinValue
            Dim EndDateAndTime As Date = Date.MinValue
            Dim StdHours As Decimal = 0

            Try

                Using DataContext = New AdvantageFramework.GoogleServices.Database.DataContext(Me.ConnectionString, Me.UseWindowsAuthentication)

                    Employee = AdvantageFramework.GoogleServices.Database.Procedures.Employee.LoadByEmployeeCode(DataContext, Me.EmployeeCode)

                    If Employee IsNot Nothing Then

                        TimeZoneInfo = LoadTimeZoneInfo(DataContext, Me.EmployeeCode)
                        AgencyTimeZoneOffset = LoadTimeZoneOffsetForEmployee(DataContext, String.Empty)

                        WriteToEventLog("Attempting to login employee --> " & Employee.ToString)

                        Try

                            CalendarService = LoadService(DataContext, Employee, ErrorMessage)

                        Catch ex As Exception
                            CalendarService = Nothing
                        End Try

                        If CalendarService IsNot Nothing Then

                            CalendarID = Employee.Email

                            WriteToEventLog("login employee sucessful --> " & Employee.ToString)

                            StartDateCutoff = Now.AddDays(-30)
                            EndDateCutoff = Now.AddMonths(2)

                            For Each EmployeeNonTask In (From ent In AdvantageFramework.GoogleServices.Database.Procedures.EmployeeNonTask.Load(DataContext)
                                                         Where ent.EmployeeCode = Employee.EmployeeCode AndAlso
                                                               (ent.GoogleID Is Nothing OrElse ent.GoogleID = "") AndAlso
                                                               ent.Type <> "H" AndAlso
                                                               ent.StartDate >= StartDateCutoff AndAlso
                                                               ent.EndDate <= EndDateCutoff
                                                         Select ent).ToList

                                Try

                                    WriteToEventLog("adding appointment to google calendar --> " & EmployeeNonTask.Description)

                                    SyncEmployeeNonTask(DataContext, CalendarService, Employee, EmployeeNonTask.ID, EmployeeNonTask.Description, EmployeeNonTask.Type, EmployeeNonTask.IsAllDay,
                                                        EmployeeNonTask.StartDateAndTime, EmployeeNonTask.EndDateAndTime, EmployeeNonTask.GoogleID, False, TimeZoneInfo, "")

                                    WriteToEventLog("appointment added to google calendar --> " & EmployeeNonTask.Description)

                                Catch ex As Exception
                                    WriteToEventLog("failed to add appointment to google calendar --> " & EmployeeNonTask.Description)
                                End Try

                            Next

                            EventsDictionary = New Generic.Dictionary(Of Google.Apis.Calendar.v3.Data.Event, AdvantageFramework.GoogleServices.Database.Entities.EmployeeNonTask)

                            Events = GetEventList(CalendarService, CalendarID, Now.AddDays(-30), Now.AddMonths(2), True, True, True, 100000)

                            For Each [Event] In Events.Items.Where(Function(TheEvent) (TheEvent.Recurrence Is Nothing OrElse TheEvent.Recurrence.Count = 0) OrElse (TheEvent.Start.DateTime >= StartDateCutoff AndAlso TheEvent.End.DateTime <= EndDateCutoff)).ToList

                                EmployeeNonTask = Nothing
                                ExtendedProperty = Nothing

                                WriteToEventLog("checking appointment --> " & [Event].Summary)

                                Try

                                    If [Event].ExtendedProperties IsNot Nothing Then

                                        ExtendedProperty = [Event].ExtendedProperties.Shared.FirstOrDefault(Function(ExtProp) ExtProp.Key = ExtendedPropertyName AndAlso ExtProp.Value <> "")

                                    End If

                                Catch ex As Exception
                                    ExtendedProperty = Nothing
                                End Try

                                If [Event].Status <> "cancelled" Then

                                    EmployeeNonTask = AdvantageFramework.GoogleServices.Database.Procedures.EmployeeNonTask.LoadByGoogleIDandEmployeeCode(DataContext, [Event].Id, Me.EmployeeCode)

                                    If EmployeeNonTask Is Nothing AndAlso [Event].RecurringEventId IsNot Nothing Then

                                        EmployeeNonTask = AdvantageFramework.GoogleServices.Database.Procedures.EmployeeNonTask.LoadByGoogleIDandEmployeeCode(DataContext, [Event].RecurringEventId, Me.EmployeeCode)

                                    End If

                                    If EmployeeNonTask Is Nothing Then

                                        EmployeeNonTask = New AdvantageFramework.GoogleServices.Database.Entities.EmployeeNonTask

                                        EmployeeNonTask.GoogleID = [Event].Id
                                        EmployeeNonTask.Type = "A"

                                        WriteToEventLog("inserting appointment --> " & [Event].Summary)

                                        IsUpdating = False

                                    Else

                                        WriteToEventLog("updating appointment --> " & [Event].Summary)
                                        IsUpdating = True

                                    End If

                                    If EmployeeNonTask IsNot Nothing Then

                                        If String.IsNullOrWhiteSpace([Event].Summary) = False AndAlso [Event].Summary.Length > 100 Then

                                            EmployeeNonTask.Description = [Event].Summary.Substring(0, 100)

                                        Else

                                            EmployeeNonTask.Description = [Event].Summary

                                        End If

                                        EmployeeNonTask.GoogleID = [Event].Id
                                        'EmployeeNonTask.Type = "A"

                                        If [Event].Start.DateTime.HasValue OrElse [Event].Start.Date <> "" Then

                                            If [Event].Start.DateTime.HasValue = False Then

                                                EmployeeNonTask.IsAllDay = 1

                                                EmployeeNonTask.StartDate = CDate([Event].Start.Date).ToShortDateString
                                                EmployeeNonTask.EndDate = CDate([Event].Start.Date).ToShortDateString

                                                EmployeeNonTask.StartDateAndTime = CDate([Event].Start.Date).ToShortDateString & " " & CDate([Event].Start.Date).ToLongTimeString
                                                EmployeeNonTask.EndDateAndTime = CDate([Event].Start.Date).ToShortDateString & " 11:59 PM"

                                            Else

                                                EmployeeNonTask.IsAllDay = 0

                                                StartDateTimeOffset = DateTimeOffset.MinValue
                                                EndDateTimeOffset = DateTimeOffset.MinValue
                                                StartDateAndTime = Date.MinValue
                                                EndDateAndTime = Date.MinValue

                                                If String.IsNullOrWhiteSpace([Event].Start.DateTimeRaw) = False Then

                                                    Try

                                                        StartDateTimeOffset = DateTimeOffset.Parse([Event].Start.DateTimeRaw)

                                                    Catch ex As Exception
                                                        StartDateTimeOffset = DateTimeOffset.MinValue
                                                    End Try

                                                End If

                                                If String.IsNullOrWhiteSpace([Event].Start.DateTimeRaw) = False Then

                                                    Try

                                                        EndDateTimeOffset = DateTimeOffset.Parse([Event].End.DateTimeRaw)

                                                    Catch ex As Exception
                                                        EndDateTimeOffset = DateTimeOffset.MinValue
                                                    End Try

                                                End If

                                                If StartDateTimeOffset <> DateTimeOffset.MinValue AndAlso EndDateTimeOffset <> DateTimeOffset.MinValue Then

                                                    StartDateAndTime = New Date(StartDateTimeOffset.Date.Year, StartDateTimeOffset.Date.Month, StartDateTimeOffset.Date.Day, StartDateTimeOffset.TimeOfDay.Hours, StartDateTimeOffset.TimeOfDay.Minutes, StartDateTimeOffset.TimeOfDay.Seconds)
                                                    EndDateAndTime = New Date(EndDateTimeOffset.Date.Year, EndDateTimeOffset.Date.Month, EndDateTimeOffset.Date.Day, EndDateTimeOffset.TimeOfDay.Hours, EndDateTimeOffset.TimeOfDay.Minutes, EndDateTimeOffset.TimeOfDay.Seconds)

                                                Else

                                                    StartDateAndTime = CDate(DateAdd(DateInterval.Minute, (AgencyTimeZoneOffset * 60) + ((AgencyTimeZoneOffset - AgencyTimeZoneOffset) * 60), [Event].Start.DateTime.Value)).ToShortDateString & " " & CDate(DateAdd(DateInterval.Minute, (AgencyTimeZoneOffset * 60) + ((AgencyTimeZoneOffset - AgencyTimeZoneOffset) * 60), [Event].Start.DateTime.Value)).ToLongTimeString
                                                    EndDateAndTime = CDate(DateAdd(DateInterval.Minute, (AgencyTimeZoneOffset * 60) + ((AgencyTimeZoneOffset - AgencyTimeZoneOffset) * 60), [Event].End.DateTime.Value)).ToShortDateString & " " & CDate(DateAdd(DateInterval.Minute, (AgencyTimeZoneOffset * 60) + ((AgencyTimeZoneOffset - AgencyTimeZoneOffset) * 60), [Event].End.DateTime.Value)).ToLongTimeString

                                                End If

                                                EmployeeNonTask.StartDate = StartDateAndTime.ToShortDateString
                                                EmployeeNonTask.EndDate = EndDateAndTime.ToShortDateString

                                                EmployeeNonTask.StartDateAndTime = StartDateAndTime
                                                EmployeeNonTask.EndDateAndTime = EndDateAndTime

                                            End If

                                            DayDifference = Math.Abs(DateDiff(DateInterval.Day, CDate(EmployeeNonTask.StartDateAndTime), CDate(EmployeeNonTask.EndDateAndTime)))

                                            If EmployeeNonTask.IsAllDay = 1 Then

                                                If DayDifference = 0 Then

                                                    EmployeeNonTask.Hours = CDec(FormatNumber(AdvantageFramework.GoogleServices.Utilities.LoadTotalHoursWorked(Employee, CDate(EmployeeNonTask.StartDateAndTime), CDate(EmployeeNonTask.EndDateAndTime)), 2))

                                                Else

                                                    EmployeeNonTask.Hours = CDec(FormatNumber(AdvantageFramework.GoogleServices.Utilities.LoadTotalHoursWorked(Employee, CDate(EmployeeNonTask.StartDateAndTime), CDate(EmployeeNonTask.EndDateAndTime)), 2))

                                                End If

                                            Else

                                                If DayDifference = 0 Then

                                                    StdHours = AdvantageFramework.GoogleServices.Utilities.LoadTotalHoursWorked(Employee, CDate(EmployeeNonTask.StartDateAndTime), CDate(EmployeeNonTask.EndDateAndTime))

                                                    EmployeeNonTask.Hours = CDec(FormatNumber(CDate(EmployeeNonTask.EndDateAndTime).Subtract(CDate(EmployeeNonTask.StartDateAndTime)).TotalHours, 2))

                                                    If EmployeeNonTask.Hours > StdHours Then

                                                        EmployeeNonTask.Hours = CDec(FormatNumber(StdHours, 2))

                                                    End If

                                                Else

                                                    EmployeeNonTask.Hours = CDec(FormatNumber(AdvantageFramework.GoogleServices.Utilities.LoadTotalHoursWorked(Employee, CDate(EmployeeNonTask.StartDateAndTime), CDate(EmployeeNonTask.EndDateAndTime)), 2))

                                                End If

                                            End If

                                            EmployeeNonTask.EmployeeCode = Me.EmployeeCode

                                            If IsUpdating Then

                                                If AdvantageFramework.GoogleServices.Database.Procedures.EmployeeNonTask.Update(DataContext, EmployeeNonTask) Then

                                                    Try

                                                        If DataContext.ExecuteQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM [dbo].[EMP_NON_TASKS_EMPS] WHERE [NON_TASK_ID] = {0} AND [EMP_CODE] = '{1}'", EmployeeNonTask.ID, Me.EmployeeCode)).FirstOrDefault = 0 Then

                                                            DataContext.ExecuteCommand(String.Format("INSERT INTO [dbo].[EMP_NON_TASKS_EMPS]([NON_TASK_ID],[EMP_CODE],[EMAIL_ADDRESS]) VALUES ({0}, '{1}', '{2}')", EmployeeNonTask.ID, Me.EmployeeCode, Employee.Email))

                                                        End If

                                                    Catch ex As Exception

                                                    End Try

                                                    WriteToEventLog("appointment updated --> " & [Event].Summary)

                                                Else

                                                    WriteToEventLog("failed to update appointment --> " & [Event].Summary)

                                                End If

                                            Else

                                                If AdvantageFramework.GoogleServices.Database.Procedures.EmployeeNonTask.Insert(DataContext, EmployeeNonTask) Then

                                                    Try

                                                        If [Event].ExtendedProperties Is Nothing Then

                                                            [Event].ExtendedProperties = New Google.Apis.Calendar.v3.Data.Event.ExtendedPropertiesData()

                                                        End If

                                                        If [Event].ExtendedProperties.Shared Is Nothing Then

                                                            [Event].ExtendedProperties.Shared = New Generic.Dictionary(Of String, String)()

                                                        End If

                                                        [Event].ExtendedProperties.Shared.Add(ExtendedPropertyName, EmployeeNonTask.Type & EmployeeNonTask.ID)

                                                        ' 
                                                        ' ???
                                                        '
                                                        '[Event].BatchData = New Google.GData.Client.GDataBatchEntryData(Google.GData.Client.GDataBatchOperationType.update)

                                                        EventsDictionary([Event]) = EmployeeNonTask

                                                        DataContext.ExecuteCommand(String.Format("INSERT INTO [dbo].[EMP_NON_TASKS_EMPS]([NON_TASK_ID],[EMP_CODE],[EMAIL_ADDRESS]) VALUES ({0}, '{1}', '{2}')", EmployeeNonTask.ID, Me.EmployeeCode, Employee.Email))

                                                    Catch ex As Exception
                                                        WriteToEventLog("failed to insert appointment --> " & [Event].Summary & " --> " & ex.Message)
                                                    End Try

                                                Else

                                                    WriteToEventLog("failed to insert appointment --> " & [Event].Summary)

                                                End If

                                            End If

                                        Else

                                            WriteToEventLog("failed sync appointment --> " & [Event].Summary & " --> no time entries were available from google")

                                        End If

                                    Else

                                        If IsValidExtendedProperty(ExtendedProperty) Then

                                            Try

                                                [Event].ExtendedProperties.Shared.Remove(ExtendedProperty.Key)

                                                UpdateEvent(CalendarService, [Event], CalendarID)

                                            Catch ex As Exception

                                            End Try

                                        End If

                                        WriteToEventLog("failed sync appointment --> " & [Event].Summary & " --> google entry had invalid advantage information")

                                    End If

                                ElseIf [Event].Status = "cancelled" Then

                                    If IsValidExtendedProperty(ExtendedProperty) Then

                                        If String.IsNullOrWhiteSpace(ExtendedProperty.Value) = False Then

                                            EmployeeNonTask = AdvantageFramework.GoogleServices.Database.Procedures.EmployeeNonTask.LoadByEmployeeNonTaskID(DataContext, AdvantageFramework.GoogleServices.Utilities.RemoveAllNonNumeric(ExtendedProperty.Value))

                                        End If

                                    End If

                                    If EmployeeNonTask Is Nothing Then

                                        EmployeeNonTask = AdvantageFramework.GoogleServices.Database.Procedures.EmployeeNonTask.LoadByGoogleID(DataContext, [Event].Id)

                                    End If

                                    WriteToEventLog("deleting appointment --> " & [Event].Summary)

                                    If EmployeeNonTask IsNot Nothing Then

                                        If AdvantageFramework.GoogleServices.Database.Procedures.EmployeeNonTask.Delete(DataContext, EmployeeNonTask) Then

                                            WriteToEventLog("appointment deleted --> " & [Event].Summary)

                                        Else

                                            WriteToEventLog("failed to delete appointment --> " & [Event].Summary)

                                        End If

                                    Else

                                        If IsValidExtendedProperty(ExtendedProperty) Then

                                            Try

                                                [Event].ExtendedProperties.Shared.Remove(ExtendedProperty.Key)

                                                UpdateEvent(CalendarService, [Event], CalendarID)

                                            Catch ex As Exception

                                            End Try

                                        End If

                                        'WriteToEventLog("failed sync appointment --> " & [Event].Title.Text & " --> google entry had invalid advantage information")

                                    End If

                                End If

                            Next

                            If EventsDictionary.Count > 0 Then

                                'BatchFeed = New Google.GData.Client.AtomFeed(EventFeed)

                                'For Each KeyValuePair In EventsDictionary

                                '    BatchFeed.Entries.Add(KeyValuePair.Key)

                                'Next

                                'BatchResultFeed = CalendarService.Batch(BatchFeed, New Uri(EventFeed.Batch))

                                'For Each [Event] In BatchResultFeed.Entries.OfType(Of Google.GData.Calendar.EventEntry)()

                                '    If [Event].BatchData.Status.Code = 200 Then

                                '        WriteToEventLog("appointment inserted --> " & [Event].Title.Text)

                                '    Else

                                '        If EventsDictionary.ContainsKey([Event]) Then

                                '            Try

                                '                AdvantageFramework.Database.Procedures.EmployeeNonTask.Delete(DbContext, EventsDictionary([Event]))

                                '            Catch ex As Exception

                                '            End Try

                                '            WriteToEventLog("failed to insert appointment --> " & [Event].Title.Text)

                                '        End If

                                '    End If

                                'Next

                            End If

                        Else

                            WriteToEventLog("failed loading employee calendar --> " & Employee.ToString & " --> employee has invalid user credentials")

                            If String.IsNullOrWhiteSpace(ErrorMessage) Then

                                ErrorMessage = "Error loading Advantage Calendar Sync. Please contact software support."

                            End If

                        End If

                    End If

                End Using

            Catch ex As Exception

                If Employee IsNot Nothing Then

                    WriteToEventLog("Error processing employee --> " & Employee.ToString & " --> " & ex.Message)

                Else

                    WriteToEventLog("Error processing employee --> Code: " & Me.EmployeeCode & " --> " & ex.Message)

                End If

            End Try

        End Sub
        Public Sub ProcessGoogleCalendarTS(AgencyStandardHours As Decimal, PastDays As Integer, ByVal StartDate As DateTime, ByVal EndDate As DateTime, ByVal RTOnly As Boolean, ByRef ErrorMessage As String)

            'objects
            Dim CalendarService As Google.Apis.Calendar.v3.CalendarService = Nothing
            Dim Events As Google.Apis.Calendar.v3.Data.Events = Nothing
            Dim [Event] As Google.Apis.Calendar.v3.Data.Event = Nothing
            Dim ExtendedProperty As KeyValuePair(Of String, String) = Nothing
            Dim EmployeeTimeStaging As AdvantageFramework.GoogleServices.Database.Entities.EmployeeTimeStaging = Nothing
            Dim EmployeeTimeStagingIDs As AdvantageFramework.GoogleServices.Database.Entities.EmployeeTimeStagingIDs = Nothing
            Dim Employee As AdvantageFramework.GoogleServices.Database.Entities.Employee = Nothing
            Dim CalendarID As String = Nothing
            Dim IsUpdating As Boolean = False
            Dim DayDifference As Integer = Nothing
            Dim EventsDictionary As Generic.Dictionary(Of Google.Apis.Calendar.v3.Data.Event, AdvantageFramework.GoogleServices.Database.Entities.EmployeeTimeStaging) = Nothing
            Dim StartDateCutoff As Date = Nothing
            Dim EndDateCutoff As Date = Nothing
            Dim TimeZoneOffset As Integer = 0
            Dim AgencyTimeZoneOffset As Integer = 0
            Dim IsAllDay As Integer = 0
            Dim _matchIndex As Integer = 0
            Dim StartDateTimeOffset As DateTimeOffset = Nothing
            Dim EndDateTimeOffset As DateTimeOffset = Nothing
            Dim StartDateAndTime As Date = Date.MinValue
            Dim EndDateAndTime As Date = Date.MinValue
            Dim StdHours As Decimal = 0

            Try

                Using DataContext = New AdvantageFramework.GoogleServices.Database.DataContext(Me.ConnectionString, Me.UseWindowsAuthentication)

                    Employee = AdvantageFramework.GoogleServices.Database.Procedures.Employee.LoadByEmployeeCode(DataContext, Me.EmployeeCode)

                    If Employee IsNot Nothing Then

                        TimeZoneOffset = LoadTimeZoneOffsetForEmployee(DataContext, Me.EmployeeCode)
                        AgencyTimeZoneOffset = LoadTimeZoneOffsetForEmployee(DataContext, String.Empty)

                        WriteToEventLog("Attempting to login employee --> " & Employee.ToString)

                        Try

                            CalendarService = LoadServiceCalendarTime(DataContext, Employee, ErrorMessage)

                        Catch ex As Exception
                            CalendarService = Nothing
                        End Try

                        If CalendarService IsNot Nothing And ErrorMessage = "" Then

                            CalendarID = Employee.CalendarTimeEmail

                            WriteToEventLog("login employee sucessful --> " & Employee.ToString)

                            StartDateCutoff = Now.AddDays(-30)
                            EndDateCutoff = Now.AddMonths(2)

                            EventsDictionary = New Generic.Dictionary(Of Google.Apis.Calendar.v3.Data.Event, AdvantageFramework.GoogleServices.Database.Entities.EmployeeTimeStaging)

                            If StartDate <> Nothing And EndDate <> Nothing Then
                                Events = GetEventList(CalendarService, CalendarID, StartDate, EndDate, True, True, True, 100000)
                            Else
                                Events = GetEventList(CalendarService, CalendarID, Now.AddDays(PastDays * -1), Now, True, True, True, 100000)
                            End If

                            For Each [Event] In Events.Items.Where(Function(TheEvent) (TheEvent.Recurrence Is Nothing OrElse TheEvent.Recurrence.Count = 0) OrElse (TheEvent.Start.DateTime >= StartDateCutoff AndAlso TheEvent.End.DateTime <= EndDateCutoff)).ToList

                                EmployeeTimeStaging = Nothing
                                ExtendedProperty = Nothing

                                WriteToEventLog("checking appointment --> " & [Event].Summary)

                                Try

                                    If [Event].ExtendedProperties IsNot Nothing Then

                                        ExtendedProperty = [Event].ExtendedProperties.Shared.FirstOrDefault(Function(ExtProp) ExtProp.Key = ExtendedPropertyName AndAlso ExtProp.Value <> "")

                                    End If

                                Catch ex As Exception
                                    ExtendedProperty = Nothing
                                End Try

                                If [Event].Status <> "cancelled" Then

                                    If ([Event].Summary.Contains("[RT]") = False And RTOnly = True) Then
                                        Continue For
                                    End If

                                    EmployeeTimeStaging = AdvantageFramework.GoogleServices.Database.Procedures.EmployeeTimeStaging.LoadByGoogleID(DataContext, [Event].Id)

                                    If EmployeeTimeStaging Is Nothing AndAlso [Event].RecurringEventId IsNot Nothing Then

                                        EmployeeTimeStaging = AdvantageFramework.GoogleServices.Database.Procedures.EmployeeTimeStaging.LoadByGoogleID(DataContext, [Event].RecurringEventId)

                                    End If

                                    If EmployeeTimeStaging Is Nothing Then

                                        EmployeeTimeStagingIDs = AdvantageFramework.GoogleServices.Database.Procedures.EmployeeTimeStagingIDs.LoadByGoogleID(DataContext, [Event].Id)

                                        If EmployeeTimeStagingIDs IsNot Nothing Then
                                            Continue For
                                        End If

                                        EmployeeTimeStaging = New AdvantageFramework.GoogleServices.Database.Entities.EmployeeTimeStaging

                                        EmployeeTimeStaging.GoogleID = [Event].Id

                                        WriteToEventLog("inserting appointment --> " & [Event].Summary)

                                        IsUpdating = False

                                    Else

                                        WriteToEventLog("updating appointment --> " & [Event].Summary)
                                        IsUpdating = True

                                    End If

                                    Dim count As Integer = 0
                                    Dim stringIndex As Integer

                                    If EmployeeTimeStaging IsNot Nothing Then

                                        If [Event].Description IsNot Nothing AndAlso [Event].Description.Contains("[RT]") AndAlso IsDangerousString([Event].Description, _matchIndex) = False Then

                                            For i As Integer = 0 To [Event].Description.Length - 1
                                                If [Event].Description(i) = ":" Then
                                                    count += 1
                                                    If count = 3 Then
                                                        stringIndex = i
                                                    End If
                                                End If
                                            Next

                                            EmployeeTimeStaging.Comments = [Event].Description.Substring(stringIndex + 1).Trim

                                        ElseIf [Event].Description IsNot Nothing AndAlso IsDangerousString([Event].Description, _matchIndex) = False Then

                                            EmployeeTimeStaging.Comments = [Event].Description

                                        ElseIf [Event].Summary.Contains("[RT]") AndAlso IsDangerousString([Event].Summary, _matchIndex) = False Then

                                            For i As Integer = 0 To [Event].Summary.Length - 1
                                                If [Event].Summary(i) = ":" Then
                                                    count += 1
                                                    If count = 3 Then
                                                        stringIndex = i
                                                    End If
                                                End If
                                            Next

                                            EmployeeTimeStaging.Comments = [Event].Summary.Substring(stringIndex + 1).Trim

                                        ElseIf IsDangerousString([Event].Summary, _matchIndex) = False Then

                                            EmployeeTimeStaging.Comments = [Event].Summary

                                        End If

                                        EmployeeTimeStaging.GoogleID = [Event].Id

                                        If [Event].Start.DateTime.HasValue OrElse [Event].Start.Date <> "" Then

                                            If [Event].Start.DateTime.HasValue = False Then

                                                IsAllDay = 1

                                                EmployeeTimeStaging.StartDate = CDate([Event].Start.Date).ToShortDateString
                                                EmployeeTimeStaging.EndDate = CDate([Event].Start.Date).ToShortDateString

                                                EmployeeTimeStaging.StartTime = CDate([Event].Start.Date).ToShortDateString & " " & CDate([Event].Start.Date).ToLongTimeString
                                                EmployeeTimeStaging.EndTime = CDate([Event].Start.Date).ToShortDateString & " 11:59 PM"

                                            Else

                                                IsAllDay = 0

                                                StartDateTimeOffset = DateTimeOffset.MinValue
                                                EndDateTimeOffset = DateTimeOffset.MinValue
                                                StartDateAndTime = Date.MinValue
                                                EndDateAndTime = Date.MinValue

                                                If String.IsNullOrWhiteSpace([Event].Start.DateTimeRaw) = False Then

                                                    Try

                                                        StartDateTimeOffset = DateTimeOffset.Parse([Event].Start.DateTimeRaw)

                                                    Catch ex As Exception
                                                        StartDateTimeOffset = DateTimeOffset.MinValue
                                                    End Try

                                                End If

                                                If String.IsNullOrWhiteSpace([Event].Start.DateTimeRaw) = False Then

                                                    Try

                                                        EndDateTimeOffset = DateTimeOffset.Parse([Event].End.DateTimeRaw)

                                                    Catch ex As Exception
                                                        EndDateTimeOffset = DateTimeOffset.MinValue
                                                    End Try

                                                End If

                                                If StartDateTimeOffset <> DateTimeOffset.MinValue AndAlso EndDateTimeOffset <> DateTimeOffset.MinValue Then

                                                    StartDateAndTime = New Date(StartDateTimeOffset.Date.Year, StartDateTimeOffset.Date.Month, StartDateTimeOffset.Date.Day, StartDateTimeOffset.TimeOfDay.Hours, StartDateTimeOffset.TimeOfDay.Minutes, StartDateTimeOffset.TimeOfDay.Seconds)
                                                    EndDateAndTime = New Date(EndDateTimeOffset.Date.Year, EndDateTimeOffset.Date.Month, EndDateTimeOffset.Date.Day, EndDateTimeOffset.TimeOfDay.Hours, EndDateTimeOffset.TimeOfDay.Minutes, EndDateTimeOffset.TimeOfDay.Seconds)

                                                Else

                                                    StartDateAndTime = CDate(DateAdd(DateInterval.Minute, (AgencyTimeZoneOffset * 60) + ((AgencyTimeZoneOffset - AgencyTimeZoneOffset) * 60), [Event].Start.DateTime.Value)).ToShortDateString & " " & CDate(DateAdd(DateInterval.Minute, (AgencyTimeZoneOffset * 60) + ((AgencyTimeZoneOffset - AgencyTimeZoneOffset) * 60), [Event].Start.DateTime.Value)).ToLongTimeString
                                                    EndDateAndTime = CDate(DateAdd(DateInterval.Minute, (AgencyTimeZoneOffset * 60) + ((AgencyTimeZoneOffset - AgencyTimeZoneOffset) * 60), [Event].End.DateTime.Value)).ToShortDateString & " " & CDate(DateAdd(DateInterval.Minute, (AgencyTimeZoneOffset * 60) + ((AgencyTimeZoneOffset - AgencyTimeZoneOffset) * 60), [Event].End.DateTime.Value)).ToLongTimeString

                                                End If

                                                EmployeeTimeStaging.StartDate = StartDateAndTime.ToShortDateString
                                                EmployeeTimeStaging.EndDate = EndDateAndTime.ToShortDateString

                                                EmployeeTimeStaging.StartTime = StartDateAndTime
                                                EmployeeTimeStaging.EndTime = EndDateAndTime

                                            End If

                                            DayDifference = Math.Abs(DateDiff(DateInterval.Day, CDate(EmployeeTimeStaging.StartTime), CDate(EmployeeTimeStaging.EndTime)))

                                            If IsAllDay = 1 Then

                                                If DayDifference = 0 Then

                                                    EmployeeTimeStaging.Hours = CDec(FormatNumber(AdvantageFramework.GoogleServices.Utilities.LoadTotalHoursWorked(Employee, CDate(EmployeeTimeStaging.StartTime), CDate(EmployeeTimeStaging.EndTime)), 2))

                                                Else

                                                    EmployeeTimeStaging.Hours = CDec(FormatNumber(AdvantageFramework.GoogleServices.Utilities.LoadTotalHoursWorked(Employee, CDate(EmployeeTimeStaging.StartTime), CDate(EmployeeTimeStaging.EndTime)), 2))

                                                End If

                                            Else

                                                If DayDifference = 0 Then

                                                    StdHours = AdvantageFramework.GoogleServices.Utilities.LoadTotalHoursWorked(Employee, CDate(EmployeeTimeStaging.StartTime), CDate(EmployeeTimeStaging.EndTime))

                                                    EmployeeTimeStaging.Hours = CDec(FormatNumber(CDate(EmployeeTimeStaging.EndTime).Subtract(CDate(EmployeeTimeStaging.StartTime)).TotalHours, 2))

                                                    If EmployeeTimeStaging.Hours > StdHours Then

                                                        EmployeeTimeStaging.Hours = CDec(FormatNumber(StdHours, 2))

                                                    End If

                                                Else

                                                    EmployeeTimeStaging.Hours = CDec(FormatNumber(AdvantageFramework.GoogleServices.Utilities.LoadTotalHoursWorked(Employee, CDate(EmployeeTimeStaging.StartTime), CDate(EmployeeTimeStaging.EndTime)), 2))

                                                End If

                                            End If

                                            EmployeeTimeStaging.EmployeeCode = Me.EmployeeCode
                                            EmployeeTimeStaging.CalendarID = ""
                                            EmployeeTimeStaging.OutlookID = ""

                                            If IsUpdating Then

                                                'If AdvantageFramework.GoogleServices.Database.Procedures.EmployeeTimeStaging.Update(DataContext, EmployeeTimeStaging) Then

                                                '    WriteToEventLog("appointment updated --> " & [Event].Summary)

                                                'Else

                                                '    WriteToEventLog("failed to update appointment --> " & [Event].Summary)

                                                'End If

                                            Else

                                                If AdvantageFramework.GoogleServices.Database.Procedures.EmployeeTimeStaging.Insert(DataContext, EmployeeTimeStaging) Then

                                                    Try

                                                        'If [Event].ExtendedProperties Is Nothing Then

                                                        '    [Event].ExtendedProperties = New Google.Apis.Calendar.v3.Data.Event.ExtendedPropertiesData()

                                                        'End If

                                                        'If [Event].ExtendedProperties.Shared Is Nothing Then

                                                        '    [Event].ExtendedProperties.Shared = New Generic.Dictionary(Of String, String)()

                                                        'End If

                                                        '[Event].ExtendedProperties.Shared.Add(ExtendedPropertyName, EmployeeTimeStaging.Type & EmployeeTimeStaging.ID)

                                                        '' 
                                                        '' ???
                                                        ''
                                                        ''[Event].BatchData = New Google.GData.Client.GDataBatchEntryData(Google.GData.Client.GDataBatchOperationType.update)

                                                        'EventsDictionary([Event]) = EmployeeNonTask

                                                        'DataContext.ExecuteCommand(String.Format("INSERT INTO [dbo].[EMP_NON_TASKS_EMPS]([NON_TASK_ID],[EMP_CODE],[EMAIL_ADDRESS]) VALUES ({0}, '{1}', '{2}')", EmployeeNonTask.ID, Me.EmployeeCode, Employee.Email))

                                                    Catch ex As Exception
                                                        WriteToEventLog("failed to insert appointment --> " & [Event].Summary & " --> " & ex.Message)
                                                    End Try

                                                Else

                                                    WriteToEventLog("failed to insert appointment --> " & [Event].Summary)

                                                End If

                                            End If

                                        Else

                                            WriteToEventLog("failed sync appointment --> " & [Event].Summary & " --> no time entries were available from google")

                                        End If

                                    Else

                                        If IsValidExtendedProperty(ExtendedProperty) Then

                                            Try

                                                [Event].ExtendedProperties.Shared.Remove(ExtendedProperty.Key)

                                                UpdateEvent(CalendarService, [Event], CalendarID)

                                            Catch ex As Exception

                                            End Try

                                        End If

                                        WriteToEventLog("failed sync appointment --> " & [Event].Summary & " --> google entry had invalid advantage information")

                                    End If

                                ElseIf [Event].Status = "cancelled" Then

                                    If IsValidExtendedProperty(ExtendedProperty) Then

                                        If String.IsNullOrWhiteSpace(ExtendedProperty.Value) = False Then

                                            EmployeeTimeStaging = AdvantageFramework.GoogleServices.Database.Procedures.EmployeeTimeStaging.LoadByEmployeeTimeStagingID(DataContext, AdvantageFramework.GoogleServices.Utilities.RemoveAllNonNumeric(ExtendedProperty.Value))

                                        End If

                                    End If

                                    If EmployeeTimeStaging Is Nothing Then

                                        EmployeeTimeStaging = AdvantageFramework.GoogleServices.Database.Procedures.EmployeeTimeStaging.LoadByGoogleID(DataContext, [Event].Id)

                                    End If

                                    WriteToEventLog("deleting appointment --> " & [Event].Summary)

                                    If EmployeeTimeStaging IsNot Nothing Then

                                        If AdvantageFramework.GoogleServices.Database.Procedures.EmployeeTimeStaging.Delete(DataContext, EmployeeTimeStaging) Then

                                            WriteToEventLog("appointment deleted --> " & [Event].Summary)

                                        Else

                                            WriteToEventLog("failed to delete appointment --> " & [Event].Summary)

                                        End If

                                    Else

                                        'If IsValidExtendedProperty(ExtendedProperty) Then

                                        '    Try

                                        '        [Event].ExtendedProperties.Shared.Remove(ExtendedProperty.Key)

                                        '        UpdateEvent(CalendarService, [Event], CalendarID)

                                        '    Catch ex As Exception

                                        '    End Try

                                        'End If

                                        'WriteToEventLog("failed sync appointment --> " & [Event].Title.Text & " --> google entry had invalid advantage information")

                                    End If

                                End If

                            Next

                            If EventsDictionary.Count > 0 Then

                                'BatchFeed = New Google.GData.Client.AtomFeed(EventFeed)

                                'For Each KeyValuePair In EventsDictionary

                                '    BatchFeed.Entries.Add(KeyValuePair.Key)

                                'Next

                                'BatchResultFeed = CalendarService.Batch(BatchFeed, New Uri(EventFeed.Batch))

                                'For Each [Event] In BatchResultFeed.Entries.OfType(Of Google.GData.Calendar.EventEntry)()

                                '    If [Event].BatchData.Status.Code = 200 Then

                                '        WriteToEventLog("appointment inserted --> " & [Event].Title.Text)

                                '    Else

                                '        If EventsDictionary.ContainsKey([Event]) Then

                                '            Try

                                '                AdvantageFramework.Database.Procedures.EmployeeNonTask.Delete(DbContext, EventsDictionary([Event]))

                                '            Catch ex As Exception

                                '            End Try

                                '            WriteToEventLog("failed to insert appointment --> " & [Event].Title.Text)

                                '        End If

                                '    End If

                                'Next

                            End If

                        Else

                            WriteToEventLog("failed loading employee calendar --> " & Employee.ToString & " --> employee has invalid user credentials")

                            If String.IsNullOrWhiteSpace(ErrorMessage) Then

                                ErrorMessage = "Error loading Advantage Calendar Sync. Please contact software support."

                            End If

                        End If

                    End If

                End Using

            Catch ex As Exception

                If Employee IsNot Nothing Then

                    WriteToEventLog("Error processing employee --> " & Employee.ToString & " --> " & ex.Message)

                Else

                    WriteToEventLog("Error processing employee --> Code: " & Me.EmployeeCode & " --> " & ex.Message)

                End If

            End Try

        End Sub

        Public Sub New(ConnectionString As String, EmployeeCode As String, EmailAddress As String, IsWebvantage As Boolean, UseWindowsAuthentication As Boolean)

            MyBase.New(ConnectionString, EmployeeCode, EmailAddress, IsWebvantage, UseWindowsAuthentication)

        End Sub
        Public Overrides Function GetScope() As IEnumerable(Of String)

            Return {Scope}

        End Function

#End Region

#End Region

    End Class

End Namespace
