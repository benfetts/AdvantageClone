Namespace CalendarImportServices.Outlook

    <HideModuleName()>
    Public Module Methods

#Region " Constants "

        Public ExtendedPropertyGUID As Guid = New Guid("{C11FF724-AA03-4555-9952-8FA248A11C3E}")
        Public Const ExtendedPropertyName As String = "BillingInformation"

#End Region

#Region " Enum "

        Public Enum EmailSubjects
            AdvantageCalendarSyncEmail
            AdvantageTaskSyncEmail
        End Enum

#End Region

#Region " Variables "

        Private startingchars As Char() = New Char() {"<", "&"}

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Function RedirectionCallback(URL As String) As Boolean

            If URL IsNot Nothing Then

                RedirectionCallback = URL.ToLower().Equals("https://autodiscover-s.outlook.com/autodiscover/autodiscover.xml")

            Else

                RedirectionCallback = False

            End If

        End Function
        Public Function ProcessOutlookExchangeTS(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal UserCode As String, ByVal Employee As AdvantageFramework.Database.Views.Employee, ByVal IsDeleting As Boolean,
                                                 AgencyStandardHours As Decimal, PastDays As Integer, ByVal StartDate As DateTime, ByVal EndDate As DateTime, ByVal RTOnly As Boolean, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Syncd As Boolean = False
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim FileStream As System.IO.FileStream = Nothing
            Dim FileBytes() As Byte = Nothing
            Dim FileName As String = ""
            'Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim ExchangeService As Microsoft.Exchange.WebServices.Data.ExchangeService = Nothing
            Dim CalendarFolder As Microsoft.Exchange.WebServices.Data.CalendarFolder = Nothing
            Dim CalendarView As Microsoft.Exchange.WebServices.Data.CalendarView = Nothing
            Dim Appointments As Microsoft.Exchange.WebServices.Data.FindItemsResults(Of Microsoft.Exchange.WebServices.Data.Appointment) = Nothing
            Dim Appointment As Microsoft.Exchange.WebServices.Data.Appointment = Nothing
            Dim ExtendedProperty As Microsoft.Exchange.WebServices.Data.ExtendedProperty = Nothing
            Dim EmployeeTimeStaging As AdvantageFramework.Database.Entities.EmployeeTimeStaging = Nothing
            Dim EmployeeTimeStagingIDs As AdvantageFramework.Database.Entities.EmployeeTimeStagingIDs = Nothing
            Dim IsUpdating As Boolean = False
            Dim DayDifference As Integer = Nothing
            Dim StartDateCutoff As Date = Nothing
            Dim EndDateCutoff As Date = Nothing
            Dim TimeZoneOffset As Integer = 0
            Dim AgencyTimeZoneOffset As Integer = 0
            Dim IsAllDay As Integer = 0
            Dim _matchIndex As Integer = 0

            Try

                If DbContext IsNot Nothing Then

                    Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                    'Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeNonTask.EmployeeCode)

                    If Employee IsNot Nothing AndAlso String.IsNullOrWhiteSpace(Employee.CalendarTimeEmailAddress) = False Then

                        TimeZoneOffset = LoadTimeZoneOffsetForEmployee(DataContext, Employee.Code)
                        AgencyTimeZoneOffset = LoadTimeZoneOffsetForEmployee(DataContext, String.Empty)

                        ExchangeService = New Microsoft.Exchange.WebServices.Data.ExchangeService(Microsoft.Exchange.WebServices.Data.ExchangeVersion.Exchange2007_SP1)

                        ExchangeService.Credentials = New Microsoft.Exchange.WebServices.Data.WebCredentials(Employee.CalendarTimeEmailAddress, Employee.CalendarTimePassword)
                        ExchangeService.AutodiscoverUrl(Employee.CalendarTimeEmailAddress, AddressOf RedirectionCallback)

                        CalendarFolder = Microsoft.Exchange.WebServices.Data.CalendarFolder.Bind(ExchangeService, Microsoft.Exchange.WebServices.Data.WellKnownFolderName.Calendar)
                        CalendarView = New Microsoft.Exchange.WebServices.Data.CalendarView(StartDate, EndDate)

                        Appointments = CalendarFolder.FindAppointments(CalendarView)

                        For Each CalAppt In Appointments

                            EmployeeTimeStaging = Nothing
                            ExtendedProperty = Nothing

                            Try

                                ExtendedProperty = CalAppt.ExtendedProperties.SingleOrDefault(Function(EP) EP.PropertyDefinition.Name = ExtendedPropertyName)

                            Catch ex As Exception
                                ExtendedProperty = Nothing
                            End Try

                            EmployeeTimeStaging = AdvantageFramework.Database.Procedures.EmployeeTimeStaging.LoadByOutLookID(DbContext, CalAppt.Id.UniqueId)

                            If EmployeeTimeStaging Is Nothing Then

                                EmployeeTimeStagingIDs = AdvantageFramework.Database.Procedures.EmployeeTimeStagingIDs.LoadByOutlookID(DbContext, CalAppt.Id.UniqueId)

                                If EmployeeTimeStagingIDs IsNot Nothing Then
                                    Continue For
                                End If

                                EmployeeTimeStaging = New AdvantageFramework.Database.Entities.EmployeeTimeStaging

                                EmployeeTimeStaging.OutlookID = CalAppt.Id.UniqueId

                                'WriteToEventLog("inserting appointment --> " & [Event].Summary)

                                IsUpdating = False

                            Else

                                'WriteToEventLog("updating appointment --> " & [Event].Summary)
                                IsUpdating = True

                            End If

                            Dim count As Integer = 0
                            Dim stringIndex As Integer

                            If EmployeeTimeStaging IsNot Nothing Then

                                If CalAppt.Subject IsNot Nothing AndAlso CalAppt.Subject.Contains("[RT]") AndAlso IsDangerousString(CalAppt.Subject, _matchIndex) = False Then

                                    For i As Integer = 0 To CalAppt.Subject.Length - 1
                                        If CalAppt.Subject(i) = ":" Then
                                            count += 1
                                            If count = 3 Then
                                                stringIndex = i
                                            End If
                                        End If
                                    Next

                                    EmployeeTimeStaging.Comments = CalAppt.Subject.Substring(stringIndex + 1).Trim

                                ElseIf CalAppt.Subject IsNot Nothing AndAlso IsDangerousString(CalAppt.Subject, _matchIndex) = False Then

                                    EmployeeTimeStaging.Comments = CalAppt.Subject

                                ElseIf CalAppt.Body.Text.Contains("[RT]") AndAlso IsDangerousString(CalAppt.Body, _matchIndex) = False Then

                                    For i As Integer = 0 To CalAppt.Body.Text.Length - 1
                                        If CalAppt.Body.Text(i) = ":" Then
                                            count += 1
                                            If count = 3 Then
                                                stringIndex = i
                                            End If
                                        End If
                                    Next

                                    EmployeeTimeStaging.Comments = CalAppt.Body.Text.Substring(stringIndex + 1).Trim

                                ElseIf IsDangerousString(CalAppt.Body, _matchIndex) = False Then

                                    EmployeeTimeStaging.Comments = CalAppt.Body.Text

                                End If

                                EmployeeTimeStaging.OutlookID = CalAppt.Id.UniqueId

                                If CalAppt.Start.Date.ToShortDateString <> "" Then

                                    If CalAppt.IsAllDayEvent Then

                                        IsAllDay = 1

                                        EmployeeTimeStaging.StartDate = CDate(CalAppt.Start.Date).ToShortDateString
                                        EmployeeTimeStaging.EndDate = CDate(CalAppt.Start.Date).ToShortDateString

                                        EmployeeTimeStaging.StartTime = CDate(CalAppt.Start.Date).ToShortDateString & " " & CDate(CalAppt.Start.Date).ToLongTimeString
                                        EmployeeTimeStaging.EndTime = CDate(CalAppt.Start.Date).ToShortDateString & " 11:59 PM"

                                    Else

                                        IsAllDay = 0

                                        EmployeeTimeStaging.StartDate = CDate(CalAppt.Start.Date).ToShortDateString
                                        EmployeeTimeStaging.EndDate = CDate(CalAppt.End.Date).ToShortDateString

                                        EmployeeTimeStaging.StartTime = CDate(DateAdd(DateInterval.Minute, (AgencyTimeZoneOffset * 60) + ((AgencyTimeZoneOffset - AgencyTimeZoneOffset) * 60), CalAppt.Start)).ToShortDateString & " " & CDate(DateAdd(DateInterval.Minute, (AgencyTimeZoneOffset * 60) + ((AgencyTimeZoneOffset - AgencyTimeZoneOffset) * 60), CalAppt.Start)).ToLongTimeString
                                        EmployeeTimeStaging.EndTime = CDate(DateAdd(DateInterval.Minute, (AgencyTimeZoneOffset * 60) + ((AgencyTimeZoneOffset - AgencyTimeZoneOffset) * 60), CalAppt.End)).ToShortDateString & " " & CDate(DateAdd(DateInterval.Minute, (AgencyTimeZoneOffset * 60) + ((AgencyTimeZoneOffset - AgencyTimeZoneOffset) * 60), CalAppt.End)).ToLongTimeString

                                    End If

                                    'DayDifference = Math.Abs(DateDiff(DateInterval.Day, CDate(EmployeeTimeStaging.StartTime), CDate(EmployeeTimeStaging.EndTime)))
                                    DayDifference = CalAppt.Duration.Days

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

                                    EmployeeTimeStaging.EmployeeCode = Employee.Code
                                    EmployeeTimeStaging.CalendarID = ""
                                    EmployeeTimeStaging.GoogleID = ""

                                    If IsUpdating Then

                                        'If AdvantageFramework.Database.Procedures.EmployeeTimeStaging.Update(DbContext, EmployeeTimeStaging) Then

                                        '    ' WriteToEventLog("appointment updated --> " & [Event].Summary)

                                        'Else

                                        '    ' WriteToEventLog("failed to update appointment --> " & [Event].Summary)

                                        'End If

                                    Else

                                        If AdvantageFramework.Database.Procedures.EmployeeTimeStaging.Insert(DbContext, EmployeeTimeStaging) Then

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
                                                'WriteToEventLog("failed to insert appointment --> " & [Event].Summary & " --> " & ex.Message)
                                            End Try

                                        Else

                                            'WriteToEventLog("failed to insert appointment --> " & [Event].Summary)

                                        End If

                                    End If

                                Else

                                    ' WriteToEventLog("failed sync appointment --> " & [Event].Summary & " --> no time entries were available from google")

                                End If

                            Else

                                'If IsValidExtendedProperty(ExtendedProperty) Then

                                '    Try

                                '        [Event].ExtendedProperties.Shared.Remove(ExtendedProperty.Key)

                                '        UpdateEvent(CalendarService, [Event], CalendarID)

                                '    Catch ex As Exception

                                '    End Try

                                'End If

                                'WriteToEventLog("failed sync appointment --> " & [Event].Summary & " --> google entry had invalid advantage information")

                            End If

                            'If ExtendedProperty IsNot Nothing AndAlso IsNothing(ExtendedProperty.Value) AndAlso IsNumeric(ExtendedProperty.Value) Then

                            '    If ExtendedProperty.Value = EmployeeNonTask.ID Then

                            '        Appointment = CalAppt
                            '        Exit For

                            '    End If

                            'End If

                        Next

                    End If

                End If

            Catch ex As Exception
                ErrorMessage = "Unable to retrieve calendar time.  Please check all calendar settings."
                Syncd = False
            Finally
                ProcessOutlookExchangeTS = Syncd
            End Try

        End Function
        Public Function RemoveAllNonNumeric(ByVal SourceText As String, Optional ByVal DefaultReturn As String = "") As String

            Try

                If String.IsNullOrEmpty(SourceText) = False Then

                    RemoveAllNonNumeric = System.Text.RegularExpressions.Regex.Replace(SourceText, "[^0-9]", "")

                Else

                    RemoveAllNonNumeric = DefaultReturn

                End If

            Catch ex As Exception
                RemoveAllNonNumeric = DefaultReturn
            End Try

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

#End Region

    End Module

End Namespace
