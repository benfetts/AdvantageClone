

Imports System.IO
Imports iCal


Namespace CalendarImportServices

    Public Module CalendarApp
        ' Global convienience class used to allow the connection use accross the application
        ' It provides global variables for the convience of the example program/test harness

        Public Sub ProcessOutlookTS(ByVal Host As String, ByVal ssl As Boolean, ByVal UserName As String, ByVal Password As String,
                                           ByVal Session As AdvantageFramework.Security.Session, ByVal Employee As AdvantageFramework.Database.Views.Employee,
                                           ByVal AgencyStandardHours As Decimal, ByVal StartD As DateTime, ByVal EndD As DateTime, ByVal Port As Integer, ByRef ErrorMessage As String)

            Dim Service As Service = Nothing

            Service = New Service

            Service.ProcessOutlookTS(Host, ssl, UserName, Password, Session, Employee, AgencyStandardHours, StartD, EndD, Port, ErrorMessage)

            Service = Nothing

        End Sub
    End Module

    Public Class Service

#Region " Constants "

#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _ConnectionString As String = Nothing
        Private _EmployeeCode As String = Nothing
        Private _EmailAddress As String = Nothing
        Private _IsWebvantage As Boolean = False
        Private _UseWindowsAuthentication As Boolean = False
        Private _Assembly As System.Reflection.Assembly = Nothing
        Private _MethodInfos As System.Reflection.MethodInfo() = Nothing
        Private _bUseRichFetch As Boolean = True
        Private _EventLog As System.Diagnostics.EventLog = Nothing
        Private _calendarClient As CalendarClient 'Client Connection
        Private _cCalendar As CalendarContainer 'DAV Folder for Calendar
        Private startingchars As Char() = New Char() {"<", "&"}

#End Region

#Region " Properties "

        Private ReadOnly Property ServicesAssembly As System.Reflection.Assembly
            Get

                Try

                    If _Assembly Is Nothing Then

                        _Assembly = System.Reflection.Assembly.Load("AdvantageFramework.CalendarImport")

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

        Private Function LoadBaseMethodType(ByVal Assembly As System.Reflection.Assembly) As System.Type

            'objects
            Dim BaseMethodType As System.Type = Nothing

            Try

                BaseMethodType = Assembly.GetTypes().Where(Function(type) type.FullName = "AdvantageFramework.CalendarImport.Methods").SingleOrDefault

            Catch ex As Exception
                BaseMethodType = Nothing
            Finally
                LoadBaseMethodType = BaseMethodType
            End Try

        End Function

        Public Function BindClientConnection(ByVal Host As String, ByVal ssl As Boolean, ByVal UserName As String, ByVal Password As String, ByVal Port As Integer) As CalendarResult

            Dim CalendarStatusResult As CalendarResult = CalendarResult.Success 'Used to store the status of DAV operations
            ' Create a DAV Connection
            If _calendarClient Is Nothing Then
                ' We need to connect (if we have no connection object already)
                If Port = 0 Then
                    _calendarClient = New CalendarImportServices.CalendarClient(Host, ssl, UserName, Password)
                Else
                    _calendarClient = New CalendarImportServices.CalendarClient(Host, Port, ssl, UserName, Password)
                End If
            End If
            Return CalendarStatusResult

        End Function
        Public Function BindCalendarResource(ByVal Host As String, ByVal ssl As Boolean, ByVal UserName As String, ByVal Password As String, ByVal Port As Integer) As CalendarResult

            BindClientConnection(Host, ssl, UserName, Password, Port)

            Dim CalendarStatusResult As CalendarResult = CalendarResult.Success 'Used to store the status of DAV operations
            If _cCalendar Is Nothing Then
                _cCalendar = New AdvantageFramework.CalendarImportServices.CalendarContainer()
                ' Locate the desired resource by ContainerType (in this case Calendar Folder)
                CalendarStatusResult = _calendarClient.discoverResource(_cCalendar, CalendarContainerType.Calendar)
                If CalendarStatusResult <> CalendarResult.Success Then
                    _cCalendar = Nothing
                End If
            End If
            Return CalendarStatusResult

        End Function


        Public Sub ProcessOutlookTS(ByVal Host As String, ByVal ssl As Boolean, ByVal UserName As String, ByVal Password As String,
                                           ByVal Session As AdvantageFramework.Security.Session, ByVal Employee As AdvantageFramework.Database.Views.Employee,
                                           ByVal AgencyStandardHours As Decimal, ByVal StartD As DateTime, ByVal EndD As DateTime, ByVal Port As Integer, ByRef ErrorMessage As String)

            Try
                Dim EmployeeTimeStaging As AdvantageFramework.Database.Entities.EmployeeTimeStaging = Nothing
                Dim EmployeeTimeStagingIDs As AdvantageFramework.Database.Entities.EmployeeTimeStagingIDs = Nothing
                Dim AgencyTimeZoneOffset As Integer = 0
                Dim TimeZoneOffset As Integer = 0
                Dim _matchIndex As Integer = 0

                If BindCalendarResource(Host, ssl, UserName, Password, Port) <> CalendarResult.Success Then
                    ErrorMessage = "Unable to retrieve calendar time.  Please check all calendar settings."
                    Exit Sub
                End If

                Dim CalendarStatusResult As CalendarResult

                CalendarStatusResult = _calendarClient.getCalendarItems(_cCalendar, StartD, EndD, Nothing, _bUseRichFetch) ' Get all items from the folder
                If CalendarStatusResult = CalendarResult.Success Then
                    ' List the items 
                    Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                            Dim StartDate As DateTime
                            Dim EndDate As DateTime
                            Dim comments As String = ""
                            Dim IsAllDay As Integer = 0
                            Dim DayDifference As Integer = Nothing
                            Dim isRecurrence As Boolean = False
                            Dim RecurrenceID As String = ""

                            If Employee IsNot Nothing Then

                                TimeZoneOffset = LoadTimeZoneOffsetForEmployee(DataContext, Employee.Code)
                                AgencyTimeZoneOffset = LoadTimeZoneOffsetForEmployee(DataContext, String.Empty)

                                For Each calItem In _cCalendar.Items

                                    'Dim calstr As String = calItem.Data
                                    isRecurrence = False
                                    Dim eventstart As Integer = 0
                                    Dim countevent As Integer = 0
                                    Dim calstr() As String = calItem.Data.Split(vbCr)
                                    For i As Integer = 0 To calstr.Length - 1

                                        Dim sr As StringReader = New StringReader(calstr(i))

                                        If calstr(i).Contains("BEGIN:VEVENT") Then
                                            eventstart = 1
                                            countevent += 1
                                        End If
                                        If calstr(i).Contains("END:VEVENT") Then
                                            eventstart = 0
                                        End If
                                        If calstr(i).Contains("RECURRENCE-ID") Then
                                            isRecurrence = True
                                        End If
                                        If eventstart = 1 Then
                                            If calstr(i).Contains("DTSTART;VALUE=DATE:") Then
                                                StartDate = calendarDateSimple(calstr(i).Substring(19))
                                                IsAllDay = 1
                                            ElseIf calstr(i).Contains("DTSTART;TZID=") Then
                                                StartDate = calendarDate(calstr(i).Substring(calstr(i).IndexOf(":") + 1))
                                                IsAllDay = 0
                                            ElseIf calstr(i).Contains("DTSTART:") Then
                                                StartDate = calendarDate(calstr(i).Substring(calstr(i).IndexOf(":") + 1))
                                                IsAllDay = 0
                                            End If
                                            If calstr(i).Contains("DTEND;VALUE=DATE:") Then
                                                EndDate = calendarDateSimple(calstr(i).Substring(17))
                                                IsAllDay = 1
                                            ElseIf calstr(i).Contains("DTEND;TZID=") Then
                                                EndDate = calendarDate(calstr(i).Substring(calstr(i).IndexOf(":") + 1))
                                                IsAllDay = 0
                                            ElseIf calstr(i).Contains("DTEND:") Then
                                                EndDate = calendarDate(calstr(i).Substring(calstr(i).IndexOf(":") + 1))
                                                IsAllDay = 0
                                            End If

                                            If calstr(i).Contains("SUMMARY;") Then
                                                comments = calstr(i).Substring(calstr(i).IndexOf(":") + 1)
                                            ElseIf calstr(i).Contains("SUMMARY:") Then
                                                comments = calstr(i).Substring(calstr(i).IndexOf(":") + 1)
                                            End If

                                            If isRecurrence = True And calstr(i).Contains("RECURRENCE-ID") Then
                                                RecurrenceID = calstr(i).Substring(calstr(i).IndexOf(":") + 1)
                                                If StartDate >= StartD And StartDate <= EndD Then

                                                    EmployeeTimeStaging = AdvantageFramework.Database.Procedures.EmployeeTimeStaging.LoadByOutLookID(DbContext, RecurrenceID & calItem.ItemId)

                                                    If EmployeeTimeStaging Is Nothing Then

                                                        EmployeeTimeStagingIDs = AdvantageFramework.Database.Procedures.EmployeeTimeStagingIDs.LoadByOutlookID(DbContext, RecurrenceID & calItem.ItemId)

                                                        If EmployeeTimeStagingIDs IsNot Nothing Then
                                                            Continue For
                                                        End If

                                                        EmployeeTimeStaging = New AdvantageFramework.Database.Entities.EmployeeTimeStaging

                                                        If isRecurrence = True Then
                                                            EmployeeTimeStaging.OutlookID = RecurrenceID & calItem.ItemId
                                                        Else
                                                            EmployeeTimeStaging.OutlookID = calItem.ItemId
                                                        End If
                                                        EmployeeTimeStaging.StartDate = StartDate.ToShortDateString
                                                        EmployeeTimeStaging.EndDate = EndDate.ToShortDateString
                                                        EmployeeTimeStaging.StartTime = CDate(DateAdd(DateInterval.Minute, (AgencyTimeZoneOffset * 60) + ((AgencyTimeZoneOffset - AgencyTimeZoneOffset) * 60), StartDate)).ToShortDateString & " " & CDate(DateAdd(DateInterval.Minute, (AgencyTimeZoneOffset * 60) + ((AgencyTimeZoneOffset - AgencyTimeZoneOffset) * 60), StartDate)).ToLongTimeString
                                                        EmployeeTimeStaging.EndTime = CDate(DateAdd(DateInterval.Minute, (AgencyTimeZoneOffset * 60) + ((AgencyTimeZoneOffset - AgencyTimeZoneOffset) * 60), EndDate)).ToShortDateString & " " & CDate(DateAdd(DateInterval.Minute, (AgencyTimeZoneOffset * 60) + ((AgencyTimeZoneOffset - AgencyTimeZoneOffset) * 60), EndDate)).ToLongTimeString
                                                        If (IsDangerousString(comments, _matchIndex)) = False Then
                                                            EmployeeTimeStaging.Comments = comments
                                                        Else
                                                            EmployeeTimeStaging.Comments = ""
                                                        End If
                                                        EmployeeTimeStaging.EmployeeCode = Employee.Code
                                                        EmployeeTimeStaging.CalendarID = ""
                                                        EmployeeTimeStaging.GoogleID = ""

                                                        DayDifference = Math.Abs(DateDiff(DateInterval.Day, CDate(EmployeeTimeStaging.StartTime), CDate(EmployeeTimeStaging.EndTime)))

                                                        If IsAllDay = 1 Then

                                                            If DayDifference = 0 Then

                                                                EmployeeTimeStaging.Hours = CDec(FormatNumber(AgencyStandardHours, 2))

                                                            Else

                                                                EmployeeTimeStaging.Hours = CDec(FormatNumber(AgencyStandardHours * DayDifference, 2))

                                                            End If

                                                        Else

                                                            If DayDifference = 0 Then

                                                                EmployeeTimeStaging.Hours = CDec(FormatNumber(CDate(EmployeeTimeStaging.EndTime).Subtract(CDate(EmployeeTimeStaging.StartTime)).TotalHours, 2))

                                                                If EmployeeTimeStaging.Hours > AgencyStandardHours Then

                                                                    EmployeeTimeStaging.Hours = CDec(FormatNumber(AgencyStandardHours, 2))

                                                                End If

                                                            Else

                                                                EmployeeTimeStaging.Hours = CDec(FormatNumber(LoadTotalHoursWorked(Employee, CDate(EmployeeTimeStaging.StartTime), CDate(EmployeeTimeStaging.EndTime)), 2))

                                                            End If

                                                        End If

                                                        If AdvantageFramework.Database.Procedures.EmployeeTimeStaging.Insert(DbContext, EmployeeTimeStaging) Then

                                                        End If

                                                        'WriteToEventLog("inserting appointment --> " & [Event].Summary)

                                                        'IsUpdating = False

                                                    End If
                                                End If
                                            End If

                                            'ElseIf countevent > 1 Then
                                            '    Exit For
                                        End If

                                    Next

                                    If isRecurrence = False Then
                                        EmployeeTimeStaging = AdvantageFramework.Database.Procedures.EmployeeTimeStaging.LoadByOutLookID(DbContext, calItem.ItemId)

                                        If EmployeeTimeStaging Is Nothing Then

                                            EmployeeTimeStagingIDs = AdvantageFramework.Database.Procedures.EmployeeTimeStagingIDs.LoadByOutlookID(DbContext, calItem.ItemId)

                                            If EmployeeTimeStagingIDs IsNot Nothing Then
                                                Continue For
                                            End If

                                            EmployeeTimeStaging = New AdvantageFramework.Database.Entities.EmployeeTimeStaging


                                            EmployeeTimeStaging.OutlookID = calItem.ItemId
                                            EmployeeTimeStaging.StartDate = StartDate.ToShortDateString
                                            EmployeeTimeStaging.EndDate = EndDate.ToShortDateString
                                            EmployeeTimeStaging.StartTime = CDate(DateAdd(DateInterval.Minute, (AgencyTimeZoneOffset * 60) + ((AgencyTimeZoneOffset - AgencyTimeZoneOffset) * 60), StartDate)).ToShortDateString & " " & CDate(DateAdd(DateInterval.Minute, (AgencyTimeZoneOffset * 60) + ((AgencyTimeZoneOffset - AgencyTimeZoneOffset) * 60), StartDate)).ToLongTimeString
                                            EmployeeTimeStaging.EndTime = CDate(DateAdd(DateInterval.Minute, (AgencyTimeZoneOffset * 60) + ((AgencyTimeZoneOffset - AgencyTimeZoneOffset) * 60), EndDate)).ToShortDateString & " " & CDate(DateAdd(DateInterval.Minute, (AgencyTimeZoneOffset * 60) + ((AgencyTimeZoneOffset - AgencyTimeZoneOffset) * 60), EndDate)).ToLongTimeString
                                            If (IsDangerousString(comments, _matchIndex)) = False Then
                                                EmployeeTimeStaging.Comments = comments
                                            Else
                                                EmployeeTimeStaging.Comments = ""
                                            End If
                                            EmployeeTimeStaging.EmployeeCode = Employee.Code
                                            EmployeeTimeStaging.CalendarID = ""
                                            EmployeeTimeStaging.GoogleID = ""

                                            DayDifference = Math.Abs(DateDiff(DateInterval.Day, CDate(EmployeeTimeStaging.StartTime), CDate(EmployeeTimeStaging.EndTime)))

                                            If IsAllDay = 1 Then

                                                If DayDifference = 0 Then

                                                    EmployeeTimeStaging.Hours = CDec(FormatNumber(AgencyStandardHours, 2))

                                                Else

                                                    EmployeeTimeStaging.Hours = CDec(FormatNumber(AgencyStandardHours * DayDifference, 2))

                                                End If

                                            Else

                                                If DayDifference = 0 Then

                                                    EmployeeTimeStaging.Hours = CDec(FormatNumber(CDate(EmployeeTimeStaging.EndTime).Subtract(CDate(EmployeeTimeStaging.StartTime)).TotalHours, 2))

                                                    If EmployeeTimeStaging.Hours > AgencyStandardHours Then

                                                        EmployeeTimeStaging.Hours = CDec(FormatNumber(AgencyStandardHours, 2))

                                                    End If

                                                Else

                                                    EmployeeTimeStaging.Hours = CDec(FormatNumber(LoadTotalHoursWorked(Employee, CDate(EmployeeTimeStaging.StartTime), CDate(EmployeeTimeStaging.EndTime)), 2))

                                                End If

                                            End If

                                            If AdvantageFramework.Database.Procedures.EmployeeTimeStaging.Insert(DbContext, EmployeeTimeStaging) Then

                                            End If

                                            'WriteToEventLog("inserting appointment --> " & [Event].Summary)

                                            'IsUpdating = False

                                        End If

                                    End If

                                Next
                            End If

                        End Using

                    End Using
                Else
                    If _bUseRichFetch Then
                        'MsgBox("The server returned an invalid response. The server will now be configured with basic fetch support")
                        _bUseRichFetch = False
                    Else
                        'MsgBox("Operation Failed")
                    End If
                End If

            Catch ex As Exception

            End Try

        End Sub

        Public Sub WriteToEventLog(ByVal Message As String)

            If _EventLog IsNot Nothing Then

                _EventLog.WriteEntry(Message)

            End If

        End Sub

        Public Function calendarDate(ByVal icaldatestring As String)

            Try
                Dim strYear As String = icaldatestring.Substring(0, 4)
                Dim strMonth As String = CInt(icaldatestring.Substring(4, 2))
                Dim strDay As String = icaldatestring.Substring(6, 2)
                Dim strHour As String = icaldatestring.Substring(9, 2)
                Dim strMin As String = icaldatestring.Substring(11, 2)
                Dim strSec As String = icaldatestring.Substring(13, 2)

                Dim oDate = New Date(strYear, strMonth, strDay, strHour, strMin, strSec)

                Return oDate

            Catch ex As Exception
                Return Nothing
            End Try

        End Function

        Public Function calendarDateSimple(ByVal icaldatestring As String)

            Try
                Dim strYear As String = icaldatestring.Substring(0, 4)
                Dim strMonth As String = CInt(icaldatestring.Substring(4, 2))
                Dim strDay As String = icaldatestring.Substring(6, 2)

                Dim oDate = New Date(strYear, strMonth, strDay)

                Return oDate

            Catch ex As Exception
                Return Nothing
            End Try

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

        Public Function LoadTotalHoursWorked(ByVal Employee As AdvantageFramework.Database.Views.Employee, ByVal StartDate As Date, ByVal EndDate As Date) As Decimal

            'objects
            Dim TotalHoursWorked As Decimal = 0
            Dim [Date] As Date = Nothing
            Dim Monday As Integer = 0
            Dim Tuesday As Integer = 0
            Dim Wednesday As Integer = 0
            Dim Thursday As Integer = 0
            Dim Friday As Integer = 0
            Dim Saturday As Integer = 0
            Dim Sunday As Integer = 0

            Try

                [Date] = StartDate

                For Days = 0 To EndDate.Subtract(StartDate).Days

                    If [Date] <= EndDate Then

                        If [Date].DayOfWeek = DayOfWeek.Monday Then

                            Monday += 1
                            [Date] = [Date].AddDays(1)

                        ElseIf [Date].DayOfWeek = DayOfWeek.Tuesday Then

                            Tuesday += 1
                            [Date] = [Date].AddDays(1)

                        ElseIf [Date].DayOfWeek = DayOfWeek.Wednesday Then

                            Wednesday += 1
                            [Date] = [Date].AddDays(1)

                        ElseIf [Date].DayOfWeek = DayOfWeek.Thursday Then

                            Thursday += 1
                            [Date] = [Date].AddDays(1)

                        ElseIf [Date].DayOfWeek = DayOfWeek.Friday Then

                            Friday += 1
                            [Date] = [Date].AddDays(1)

                        ElseIf [Date].DayOfWeek = DayOfWeek.Saturday Then

                            Saturday += 1
                            [Date] = [Date].AddDays(1)

                        ElseIf [Date].DayOfWeek = DayOfWeek.Sunday Then

                            Sunday += 1
                            [Date] = [Date].AddDays(1)

                        End If

                    Else

                        Exit For

                    End If

                Next

                If Employee.MondayHours.GetValueOrDefault(0) <> 0 Then

                    TotalHoursWorked += Employee.MondayHours * Monday

                End If

                If Employee.TuesdayHours.GetValueOrDefault(0) <> 0 Then

                    TotalHoursWorked += Employee.TuesdayHours * Tuesday

                End If

                If Employee.WednesdayHours.GetValueOrDefault(0) <> 0 Then

                    TotalHoursWorked += Employee.WednesdayHours * Wednesday

                End If

                If Employee.ThursdayHours.GetValueOrDefault(0) <> 0 Then

                    TotalHoursWorked += Employee.ThursdayHours * Thursday

                End If

                If Employee.FridayHours.GetValueOrDefault(0) <> 0 Then

                    TotalHoursWorked += Employee.FridayHours * Friday

                End If

                If Employee.SaturdayHours.GetValueOrDefault(0) <> 0 Then

                    TotalHoursWorked += Employee.SaturdayHours * Saturday

                End If

                If Employee.SundayHours.GetValueOrDefault(0) <> 0 Then

                    TotalHoursWorked += Employee.SundayHours * Sunday

                End If

            Catch ex As Exception
                TotalHoursWorked = 0
            Finally
                LoadTotalHoursWorked = TotalHoursWorked
            End Try

        End Function

        Public Function IsDangerousString(ByVal comments As String, ByRef matchIndex As Integer)
            Try
                matchIndex = 0
                Dim startIndex As Integer = 0

                While (True)
                    Dim num2 As Integer = comments.IndexOfAny(startingchars, startIndex)

                    If num2 < 0 Then
                        Return False
                    End If

                    If num2 = comments.Length - 1 Then
                        Return False
                    End If

                    matchIndex = num2
                    Dim ch As Char = comments(num2)

                    If ch <> "&" Then
                        If ((ch = "<") And ((IsAtoZ(comments(num2 + 1)) Or (comments(num2 + 1) = "!")) Or ((comments(num2 + 1) = "/") Or (comments(num2 + 1) = "?")))) Then
                            Return True
                        End If
                    ElseIf comments(num2 + 1) = "#" Then
                        Return True
                    End If
                    startIndex = num2 + 1

                End While
                Return False
            Catch ex As Exception
                Return False
            End Try
        End Function
        Public Function IsAtoZ(ByVal c As Char)
            Try
                Return (((c >= "a") And (c <= "z")) Or ((c >= "A") And (c <= "Z")))
            Catch ex As Exception
                Return False
            End Try
        End Function


#End Region

    End Class

End Namespace

