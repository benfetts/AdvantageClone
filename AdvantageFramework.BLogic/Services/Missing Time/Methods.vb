Namespace Services.MissingTime

    <HideModuleName()> _
    Public Module Methods

        Public Event EntryLogWrittenEvent(ByVal EventLogEntry As System.Diagnostics.EventLogEntry)

#Region " Constants "

        Private MissingTimeAlertTypeID As Integer = 8

        Private MissingTimeAlertCategoryID As Integer = 47
        Private MissingTimeReportSupervisorCategoryID As Integer = 48

#End Region

#Region " Enum "

        Public Enum RegistrySetting
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\Missing Time\", "Enabled", "TRUE")> _
            Enabled
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\Missing Time\", "Changed", "FALSE")> _
            SettingsChanged
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\Missing Time\", "Sleep", "60")> _
            Sleep
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\Missing Time\", "Tick", "False")> _
            Tick
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\Missing Time\", "ProcessTime", "TRUE")> _
            ProcessTime
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\Missing Time\", "ProcessTimeValue", "1:00:00AM")> _
            ProcessTimeValue
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\Missing Time\", "ProcessTimeWeeklyDay", "Daily")> _
            ProcessTimeWeeklyDay
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\Missing Time\", "ProcessTimeDaily", "FALSE")> _
            ProcessTimeDaily
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\Missing Time\", "ProcessEveryHour", "0")> _
            ProcessEveryHour
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\Missing Time\", "ProcessEveryHourStop", "FALSE")> _
            ProcessEveryHourStop
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\Missing Time\", "ProcessEveryHourStopAfterHours", "0")> _
            ProcessEveryHourStopAfterHours
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\Missing Time\", "RangeDaysToCheck", "FALSE")> _
            RangeDaysToCheck
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\Missing Time\", "RangeDaysToCheckValue", "0")> _
            RangeDaysToCheckValue
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\Missing Time\", "SendAlertToEmployee", "TRUE")> _
            SendAlertToEmployee
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\Missing Time\", "SendAlertToSupervisor", "FALSE")> _
            SendAlertToSupervisor
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\Missing Time\", "Priority", "MEDIUM")> _
            Priority
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\Missing Time\", "DontCountWeekendsOrHolidays", "TRUE")> _
            DontCountWeekendsOrHolidays
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\Missing Time\", "MissingTimesheetsOnly", "FALSE")> _
            MissingTimesheetsOnly
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\Missing Time\", "GracePeriodDaysEmployee", "0")> _
            GracePeriodDaysEmployee
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\Missing Time\", "GracePeriodDaysSupervisor", "0")> _
            GracePeriodDaysSupervisor
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\Missing Time\", "GracePeriodDaysITContact", "0")> _
            GracePeriodDaysITContact
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\Missing Time\", "CustomMessage", "")> _
            CustomMessage
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\Missing Time\", "LogFileDirectory", "")> _
            LogFileDirectory
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\Missing Time\", "IncludeOnlyDaysThatAreLate", "FALSE")> _
            IncludeOnlyDaysThatAreLate
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\Missing Time\", "LastRanAt", "01/01/2001 01:00 AM")> _
            LastRanAt
        End Enum

        Public Enum CustomCommand As Integer

            ProfileBase = 128
            ProfileLoad = ProfileBase Or 0
            ProfileUpdated = ProfileBase Or 1
            ProfileAdded = ProfileBase Or 2
            ProfileDeleted = ProfileBase Or 4

        End Enum

        Public Enum RunDayofWeek
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("Daily", "Daily")> _
            Daily
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("Sunday", "Sunday")> _
            Sunday
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("Monday", "Monday")> _
            Monday
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("Tuesday", "Tuesday")> _
            Tuesday
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("Wednesday", "Wednesday")> _
            Wednesday
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("Thursday", "Thursday")> _
            Thursday
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("Friday", "Friday")> _
            Friday
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("Saturday", "Saturday")> _
            Saturday
        End Enum

#End Region

#Region " Variables "

        Private WithEvents _EventLog As System.Diagnostics.EventLog = Nothing

        Private _LastDateRan As Date = Nothing
        Private _FirstTimeRunningForDay As Date = Nothing
        Private _Thread As System.Threading.Thread = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub _EventLog_EntryWritten(ByVal sender As Object, ByVal e As System.Diagnostics.EntryWrittenEventArgs) Handles _EventLog.EntryWritten

            RaiseEvent EntryLogWrittenEvent(e.Entry)

        End Sub
        Private Function AdjustEndDateForGracePeriod(ByRef DbContext As AdvantageFramework.Database.DbContext, ByVal EndDate As Date, ByVal GracePeriod As Integer, ByVal RangeDaysToCheck As Boolean, ByVal DontCountWeekendsHoliday As Boolean) As Date

            'objects
            Dim AdjustedEndDate As Date = Nothing
            Dim CurrentDate As Date = Nothing
            Dim GracePeriodDays As Integer = GracePeriod

            CurrentDate = Now

            If DontCountWeekendsHoliday Then

                For DaysOfGrace = 0 To GracePeriodDays - 1

                    CurrentDate = DateAdd(DateInterval.Day, -1, CurrentDate)

                    If CurrentDate.DayOfWeek = DayOfWeek.Saturday OrElse CurrentDate.DayOfWeek = DayOfWeek.Sunday Then

                        GracePeriod += 1
                        DaysOfGrace -= 1

                    ElseIf AdvantageFramework.Database.Procedures.EmployeeNonTask.IsDateEmployeeHoliday(DbContext, CurrentDate) = True Then

                        GracePeriod += 1
                        DaysOfGrace -= 1

                    End If

                Next

            End If

            If RangeDaysToCheck Then

                AdjustedEndDate = DateAdd(DateInterval.Day, -GracePeriod, Now)
                AdjustedEndDate = AdjustedEndDate.AddDays(-1)

            Else

                If EndDate > Now Then

                    AdjustedEndDate = DateAdd(DateInterval.Day, -GracePeriod, Now)
                    AdjustedEndDate = AdjustedEndDate.AddDays(-1)

                Else

                    AdjustedEndDate = DateAdd(DateInterval.Day, -GracePeriod, EndDate)
                    AdjustedEndDate = AdjustedEndDate.AddDays(-1)

                End If

            End If

            AdjustEndDateForGracePeriod = AdjustedEndDate

        End Function
        Public Sub ProcessDatabase(ByRef DatabaseProfile As AdvantageFramework.Database.DatabaseProfile)

            'objects
            Dim RangeDaysToCheck As Boolean = False
            Dim DaysToCheck As Integer = 0
            Dim SendEmailToEmployee As Boolean = False
            Dim SendEmailToSupervisor As Boolean = False
            Dim HighPriority As Boolean = False
            Dim MediumPriority As Boolean = False
            Dim LowPriority As Boolean = False
            Dim DontCountWeekendsHoliday As Boolean = False
            Dim MissingTimeOnly As Boolean = False
            Dim EmployeeGracePeriod As Integer = 0
            Dim SupervisorGracePeriod As Integer = 0
            Dim ITContactGracePeriod As Integer = 0
            Dim CustomMessage As String = ""
            Dim LogFileDirectory As String = ""
            Dim IncludeOnlyDaysThatAreLate As Boolean = False

            Dim StartDate As Date = Nothing
            Dim EndDate As Date = Nothing
            Dim PostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim Supervisor As AdvantageFramework.Database.Views.Employee = Nothing

            Dim Priority As Integer = 0
            Dim AlertSubject As String = ""

            Dim EmployeeListByEmployeeGracePeriod As List(Of String) = Nothing
            Dim EmployeeListBySupervisorGracePeriod As List(Of String) = Nothing
            Dim EmployeeListByITGracePeriod As List(Of String) = Nothing
            Dim DistinctSupervisorList As List(Of String) = Nothing

            Dim ProcessMissingTime As Boolean = True
            Dim EmployeeEndDate As Date = Nothing
            Dim SupervisorEndDate As Date = Nothing
            Dim ITEndDate As Date = Nothing
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing

            Try

                If DatabaseProfile IsNot Nothing Then

                    WriteToEventLog("Missing Time Notify Started --> " & DatabaseProfile.DatabaseName)

                    Using DataContext = New AdvantageFramework.Database.DataContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                        Using DbContext = New AdvantageFramework.Database.DbContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                                WriteToEventLog("Loading Process Settings --> " & DatabaseProfile.DatabaseName)

                                Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                                AdvantageFramework.Services.MissingTime.LoadProcessSettings(DataContext,
                                                                                            RangeDaysToCheck, DaysToCheck,
                                                                                            SendEmailToEmployee, SendEmailToSupervisor,
                                                                                            HighPriority, MediumPriority, LowPriority,
                                                                                            DontCountWeekendsHoliday, MissingTimeOnly,
                                                                                            EmployeeGracePeriod, SupervisorGracePeriod, ITContactGracePeriod,
                                                                                            CustomMessage, LogFileDirectory, IncludeOnlyDaysThatAreLate)

                                WriteToEventLog("Loading Process Settings finished --> " & DatabaseProfile.DatabaseName)

                                If RangeDaysToCheck Then

                                    StartDate = DateAdd(DateInterval.Day, -DaysToCheck, Now)

                                    EndDate = DateAdd(DateInterval.Day, -1, Now)

                                Else

                                    Try

                                        PostPeriod = (From Entity In AdvantageFramework.Database.Procedures.PostPeriod.Load(DbContext)
                                                      Where Entity.EmployeeTimeStatus = "C"
                                                      Select Entity).FirstOrDefault

                                    Catch ex As Exception

                                        PostPeriod = Nothing

                                    Finally

                                        If PostPeriod IsNot Nothing Then

                                            StartDate = PostPeriod.StartDate
                                            EndDate = PostPeriod.EndDate

                                            If EndDate > Now Then

                                                EndDate = Now

                                            End If

                                        Else

                                            ProcessMissingTime = False

                                        End If

                                    End Try

                                End If

                                If ProcessMissingTime Then

                                    WriteToEventLog("Start Processing - <" + StartDate.ToShortDateString + " - " + EndDate.ToShortDateString + "> --> " & DatabaseProfile.DatabaseName)

                                    AdvantageFramework.Database.Procedures.MissingTimeDetail.LoadMissingTimeDetailsTable(DbContext, StartDate.ToShortDateString, EndDate.ToShortDateString, CInt(IIf(DontCountWeekendsHoliday, 1, 0)), CInt(IIf(MissingTimeOnly, 1, 0)))

                                    If HighPriority Then

                                        Priority = 2

                                    ElseIf MediumPriority Then

                                        Priority = 3

                                    Else

                                        Priority = 4

                                    End If

                                    EmployeeEndDate = AdjustEndDateForGracePeriod(DbContext, EndDate, EmployeeGracePeriod, RangeDaysToCheck, DontCountWeekendsHoliday)
                                    SupervisorEndDate = AdjustEndDateForGracePeriod(DbContext, EndDate, SupervisorGracePeriod, RangeDaysToCheck, DontCountWeekendsHoliday)
                                    ITEndDate = AdjustEndDateForGracePeriod(DbContext, EndDate, ITContactGracePeriod, RangeDaysToCheck, DontCountWeekendsHoliday)

                                    If SendEmailToEmployee Then

                                        EmployeeListByEmployeeGracePeriod = AdvantageFramework.Database.Procedures.MissingTimeDetail.LoadDistinctEmployeeCodesByLessThanOrEqualToDate(DataContext, EmployeeEndDate).ToList()

                                        If EmployeeListByEmployeeGracePeriod IsNot Nothing AndAlso EmployeeListByEmployeeGracePeriod.Count > 0 Then

                                            WriteToEventLog("Processing <" + EmployeeListByEmployeeGracePeriod.Count.ToString() + "> Employee Alerts - End Date <" + EmployeeEndDate.ToShortDateString() + "> --> " & DatabaseProfile.DatabaseName)

                                            For Each EmployeeCode In EmployeeListByEmployeeGracePeriod

                                                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode)

                                                If Employee IsNot Nothing Then

                                                    WriteToEventLog("Processing Employee --> " & EmployeeCode & " - " & Employee.ToString())

                                                    AlertSubject = "Missing Time Alert for " & Employee.ToString()

                                                    AdvantageFramework.AlertSystem.CreateAlertForMissingTimeNotification(DbContext,
                                                                                                                         DataContext,
                                                                                                                         SecurityDbContext,
                                                                                                                         Agency,
                                                                                                                         Employee,
                                                                                                                         AlertSubject,
                                                                                                                         CustomMessage,
                                                                                                                         Priority,
                                                                                                                         MissingTimeAlertTypeID,
                                                                                                                         MissingTimeAlertCategoryID,
                                                                                                                         MissingTimeOnly,
                                                                                                                         EndDate,
                                                                                                                         EmployeeEndDate,
                                                                                                                         IncludeOnlyDaysThatAreLate,
                                                                                                                         _EventLog)

                                                End If

                                            Next

                                        End If

                                    Else

                                        WriteToEventLog("Processing Employee Alerts is disabled --> " & DatabaseProfile.DatabaseName)

                                    End If

                                    If SendEmailToSupervisor Then

                                        DistinctSupervisorList = AdvantageFramework.Database.Procedures.MissingTimeDetail.LoadDistinctSupervisorEmployeeCodesByLessThanOrEqualToDate(DataContext, SupervisorEndDate).ToList

                                        If DistinctSupervisorList IsNot Nothing AndAlso DistinctSupervisorList.Count > 0 Then

                                            WriteToEventLog("Processing <" + DistinctSupervisorList.Count.ToString() + "> Distinct Supervisors - End Date <" + SupervisorEndDate.ToShortDateString() + "> --> " & DatabaseProfile.DatabaseName)

                                            For Each SupervisorCode In DistinctSupervisorList

                                                Supervisor = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, SupervisorCode)

                                                If Supervisor IsNot Nothing Then

                                                    WriteToEventLog("Processing Supervisor --> " & SupervisorCode & " - " & Supervisor.ToString())

                                                    AlertSubject = "Missing Time Report for Supervisor " & Supervisor.ToString()

                                                    AdvantageFramework.AlertSystem.CreateAlertForMissingTimeNotificationForSupervisor(DbContext,
                                                                                                                                      DataContext,
                                                                                                                                      SecurityDbContext,
                                                                                                                                      Agency,
                                                                                                                                      Supervisor,
                                                                                                                                      AlertSubject,
                                                                                                                                      CustomMessage,
                                                                                                                                      Priority,
                                                                                                                                      EndDate,
                                                                                                                                      SupervisorEndDate,
                                                                                                                                      MissingTimeAlertTypeID,
                                                                                                                                      MissingTimeReportSupervisorCategoryID,
                                                                                                                                      _EventLog,
                                                                                                                                      MissingTimeOnly,
                                                                                                                                      IncludeOnlyDaysThatAreLate)

                                                End If

                                            Next

                                        End If

                                    Else

                                        WriteToEventLog("Processing Supervisor Alerts is disabled --> " & DatabaseProfile.DatabaseName)

                                    End If

                                    WriteToEventLog("Generating Supervisor Logfile - End Date <" + SupervisorEndDate.ToShortDateString() + "> --> " & DatabaseProfile.DatabaseName)

                                    GenerateLogFile(DatabaseProfile, True, Agency, LogFileDirectory, Priority, MissingTimeOnly, EndDate, SupervisorEndDate, IncludeOnlyDaysThatAreLate)

                                    WriteToEventLog("Generating IT Logfile - End Date <" + ITEndDate.ToShortDateString() + "> --> " & DatabaseProfile.DatabaseName)

                                    GenerateLogFile(DatabaseProfile, False, Agency, LogFileDirectory, Priority, MissingTimeOnly, EndDate, ITEndDate, IncludeOnlyDaysThatAreLate)

                                    WriteToEventLog("Processing Finished --> " & DatabaseProfile.DatabaseName)

                                Else

                                    WriteToEventLog("Cannot process missing time. There is no current post period in the system." & DatabaseProfile.DatabaseName)

                                End If

                            End Using

                        End Using

                    End Using

                End If

            Catch ex As Exception

                WriteToEventLog("Error Processing - " & ex.Message & " --> " & DatabaseProfile.DatabaseName)

            End Try

        End Sub
        Private Sub AddToMissingTimeLogList(ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                            ByVal Employee As AdvantageFramework.Database.Views.Employee,
                                            ByVal IsDaily As Boolean,
                                            ByVal MissingTimeOnly As Boolean,
                                            ByVal MissingTimeList As Generic.List(Of AdvantageFramework.Database.Entities.MissingTimeDetail),
                                            ByVal MissingTimeLogList As Generic.List(Of AdvantageFramework.Services.MissingTime.Classes.MissingTimeLog))

            'objects
            Dim UserCode As String = ""
            Dim User As AdvantageFramework.Security.Database.Entities.User = Nothing
            Dim MissingTimeLog As AdvantageFramework.Services.MissingTime.Classes.MissingTimeLog = Nothing
            Dim CountOfStandardHours As Decimal = 0
            Dim CountOfHoursWorked As Decimal = 0
            Dim CountOfHoursDifference As Decimal = 0
            Dim StartOfWeekDate As Date = Nothing
            Dim PreviousStartDateOfWeek As Date = Nothing

            If MissingTimeLogList IsNot Nothing AndAlso MissingTimeList IsNot Nothing Then

                User = AdvantageFramework.Security.Database.Procedures.User.LoadFirstUserByEmployeeCode(SecurityDbContext, Employee.Code)

                If User IsNot Nothing Then

                    UserCode = User.UserCode

                End If

                If IsDaily Then

                    For Each MissingTimeDetail In MissingTimeList.OrderBy(Function(Detail) Detail.Date)

                        If PreviousStartDateOfWeek <> MissingTimeDetail.StartOfWeekDate Then

                            PreviousStartDateOfWeek = MissingTimeDetail.StartOfWeekDate

                            StartOfWeekDate = MissingTimeDetail.StartOfWeekDate

                            CountOfStandardHours = (From Entity In MissingTimeList
                                                    Where Entity.StartOfWeekDate = StartOfWeekDate
                                                    Select Entity.StandardHours.GetValueOrDefault(0)).Sum

                            CountOfHoursWorked = (From Entity In MissingTimeList
                                                  Where Entity.StartOfWeekDate = StartOfWeekDate
                                                  Select Entity.HoursWorked.GetValueOrDefault(0)).Sum

                            CountOfHoursDifference = (From Entity In MissingTimeList
                                                      Where Entity.StartOfWeekDate = StartOfWeekDate
                                                      Select Entity.HoursDifference).Sum

                        End If

                        If MissingTimeOnly Then

                            If MissingTimeDetail.StandardHours > 0 AndAlso
                                    MissingTimeDetail.StandardHours = MissingTimeDetail.HoursDifference Then

                                MissingTimeLog = New AdvantageFramework.Services.MissingTime.Classes.MissingTimeLog(UserCode, Employee.Code, Employee.ToString, CDate(MissingTimeDetail.Date.GetValueOrDefault("01/01/1900").ToShortDateString),
                                                                                                                    MissingTimeDetail.Date.GetValueOrDefault("01/01/1900").DayOfWeek.ToString, MissingTimeDetail.StandardHours,
                                                                                                                    MissingTimeDetail.HoursWorked, MissingTimeDetail.HoursDifference, CountOfStandardHours,
                                                                                                                    CountOfHoursWorked, CountOfHoursDifference)

                                If MissingTimeLogList.Any(Function(Entity) Entity.ToString = MissingTimeLog.ToString) = False Then

                                    MissingTimeLogList.Add(MissingTimeLog)

                                End If

                            End If

                        Else

                            If MissingTimeDetail.HoursDifference > 0 Then

                                MissingTimeLog = New AdvantageFramework.Services.MissingTime.Classes.MissingTimeLog(UserCode, Employee.Code, Employee.ToString, CDate(MissingTimeDetail.Date.GetValueOrDefault("01/01/1900").ToShortDateString),
                                                                                                                    MissingTimeDetail.Date.GetValueOrDefault("01/01/1900").DayOfWeek.ToString, MissingTimeDetail.StandardHours,
                                                                                                                    MissingTimeDetail.HoursWorked, MissingTimeDetail.HoursDifference, CountOfStandardHours,
                                                                                                                    CountOfHoursWorked, CountOfHoursDifference)

                                If MissingTimeLogList.Any(Function(Entity) Entity.ToString = MissingTimeLog.ToString) = False Then

                                    MissingTimeLogList.Add(MissingTimeLog)

                                End If

                            End If

                        End If

                    Next

                Else

                    For Each StartOfWeekDate In (From MissingTimeDetail In MissingTimeList.AsQueryable
                                                 Order By MissingTimeDetail.StartOfWeekDate
                                                 Select MissingTimeDetail.StartOfWeekDate.GetValueOrDefault("01/01/1900")
                                                 Distinct)

                        CountOfHoursWorked = (From MissingTimeDetail In MissingTimeList.AsQueryable
                                              Where MissingTimeDetail.StartOfWeekDate = StartOfWeekDate
                                              Select MissingTimeDetail.HoursWorked).Sum

                        CountOfStandardHours = (From MissingTimeDetail In MissingTimeList.AsQueryable
                                                Where MissingTimeDetail.StartOfWeekDate = StartOfWeekDate
                                                Select MissingTimeDetail.StandardHours).Sum

                        CountOfHoursDifference = (From MissingTimeDetail In MissingTimeList.AsQueryable
                                                  Where MissingTimeDetail.StartOfWeekDate = StartOfWeekDate
                                                  Select MissingTimeDetail.HoursDifference).Sum

                        If MissingTimeOnly Then

                            If CountOfStandardHours > 0 AndAlso
                                    CountOfStandardHours = CountOfHoursDifference Then

                                For Each MissingTimeDetail In (From Entity In MissingTimeList.AsQueryable
                                                               Where Entity.StartOfWeekDate = StartOfWeekDate
                                                               Select Entity
                                                               Order By Entity.Date)

                                    MissingTimeLog = New AdvantageFramework.Services.MissingTime.Classes.MissingTimeLog(UserCode, Employee.Code, Employee.ToString, CDate(MissingTimeDetail.Date.GetValueOrDefault("01/01/1900").ToShortDateString),
                                                                                                                        MissingTimeDetail.Date.GetValueOrDefault("01/01/1900").DayOfWeek.ToString, MissingTimeDetail.StandardHours,
                                                                                                                        MissingTimeDetail.HoursWorked, MissingTimeDetail.HoursDifference, CountOfStandardHours,
                                                                                                                        CountOfHoursWorked, CountOfHoursDifference)

                                    If MissingTimeLogList.Any(Function(Entity) Entity.ToString = MissingTimeLog.ToString) = False Then

                                        MissingTimeLogList.Add(MissingTimeLog)

                                    End If

                                Next

                            End If

                        Else

                            If CountOfHoursDifference > 0 Then

                                For Each MissingTimeDetail In (From Entity In MissingTimeList.AsQueryable
                                                               Where Entity.StartOfWeekDate = StartOfWeekDate
                                                               Select Entity
                                                               Order By Entity.Date)

                                    MissingTimeLog = New AdvantageFramework.Services.MissingTime.Classes.MissingTimeLog(UserCode, Employee.Code, Employee.ToString, CDate(MissingTimeDetail.Date.GetValueOrDefault("01/01/1900").ToShortDateString),
                                                                                                                        MissingTimeDetail.Date.GetValueOrDefault("01/01/1900").DayOfWeek.ToString, MissingTimeDetail.StandardHours,
                                                                                                                        MissingTimeDetail.HoursWorked, MissingTimeDetail.HoursDifference, CountOfStandardHours,
                                                                                                                        CountOfHoursWorked, CountOfHoursDifference)

                                    If MissingTimeLogList.Any(Function(Entity) Entity.ToString = MissingTimeLog.ToString) = False Then

                                        MissingTimeLogList.Add(MissingTimeLog)

                                    End If

                                Next

                            End If

                        End If

                    Next

                End If

            End If

        End Sub
        Public Function LoadLogEntries() As String

            'objects
            Dim Log As String = ""

            Log = AdvantageFramework.Services.LoadLogEntries(_EventLog)

            LoadLogEntries = Log

        End Function
        Public Function LoadLog(ByVal LoadEntries As Boolean, Optional ByRef LastEntryMessage As String = "") As String

            'objects
            Dim Log As String = ""
            Dim Entry As System.Diagnostics.EventLogEntry = Nothing

            If System.Diagnostics.EventLog.SourceExists("Missing Time Source") = False Then

                System.Diagnostics.EventLog.CreateEventSource("Missing Time Source", "Missing Time Log")

            End If

            _EventLog = New System.Diagnostics.EventLog("Missing Time Log", My.Computer.Name, "Missing Time Source")

            _EventLog.ModifyOverflowPolicy(System.Diagnostics.OverflowAction.OverwriteAsNeeded, _EventLog.MinimumRetentionDays)

            _EventLog.EnableRaisingEvents = True

            If LoadEntries Then

                Log = AdvantageFramework.Services.LoadLogEntries(_EventLog)

                Try

                    Entry = _EventLog.Entries.OfType(Of System.Diagnostics.EventLogEntry).OrderByDescending(Function(EventLogEntry) EventLogEntry.TimeGenerated).FirstOrDefault

                Catch ex As Exception
                    Entry = Nothing
                End Try

                If Entry IsNot Nothing Then

                    LastEntryMessage = Entry.Message & "...."

                End If

            End If

            LoadLog = Log

        End Function
        Public Function LoadAdvantageService(ByVal DataContext As AdvantageFramework.Database.DataContext) As AdvantageFramework.Database.Entities.AdvantageService

            'objects
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing

            Try

                AdvantageService = AdvantageFramework.Services.LoadAdvantageService(DataContext, AdvantageFramework.Services.Service.AdvantageMissingTimeWindowsService)

            Catch ex As Exception
                AdvantageService = Nothing
            End Try

            LoadAdvantageService = AdvantageService

        End Function
        Public Function LoadAdvantageServiceSetting(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AdvantageServiceID As Integer, ByVal RegistrySetting As AdvantageFramework.Services.MissingTime.RegistrySetting) As AdvantageFramework.Database.Entities.AdvantageServiceSetting

            'objects
            Dim AdvantageServiceSetting As AdvantageFramework.Database.Entities.AdvantageServiceSetting = Nothing

            Try

                AdvantageServiceSetting = AdvantageFramework.Services.LoadAdvantageServiceSetting(DataContext, AdvantageServiceID, RegistrySetting.ToString)

            Catch ex As Exception
                AdvantageServiceSetting = Nothing
            End Try

            LoadAdvantageServiceSetting = AdvantageServiceSetting

        End Function
        Public Function LoadAdvantageServiceSettingValue(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AdvantageServiceID As Integer, ByVal RegistrySetting As AdvantageFramework.Services.MissingTime.RegistrySetting) As Object

            'objects
            Dim SettingValue As Object = Nothing

            Try

                SettingValue = AdvantageFramework.Services.LoadAdvantageServiceSettingValue(DataContext, AdvantageServiceID, RegistrySetting.ToString)

            Catch ex As Exception
                SettingValue = Nothing
            End Try

            LoadAdvantageServiceSettingValue = SettingValue

        End Function
        Public Function SaveAdvantageServiceSettingValue(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AdvantageServiceID As Integer, ByVal RegistrySetting As AdvantageFramework.Services.MissingTime.RegistrySetting, ByVal SettingValue As Object) As Boolean

            'objects
            Dim Saved As Boolean = False

            Try

                Saved = AdvantageFramework.Services.SaveAdvantageServiceSettingValue(DataContext, AdvantageServiceID, RegistrySetting.ToString, SettingValue)

            Catch ex As Exception
                Saved = False
            End Try

            SaveAdvantageServiceSettingValue = Saved

        End Function
        Private Sub GenerateLogFile(ByRef DatabaseProfile As AdvantageFramework.Database.DatabaseProfile,
                                    ByRef EmployeeList As List(Of String),
                                    ByRef IsSupervisorLog As Boolean,
                                    ByRef Agency As AdvantageFramework.Database.Entities.Agency,
                                    ByVal LogFileDirectory As String, ByVal Priority As Integer,
                                    ByVal MissingTimeOnly As Boolean, ByVal EndDate As Date)

            'objects
            Dim LogFile As String = ""
            Dim StringBuilder As System.Text.StringBuilder = Nothing
            Dim PreviousStartDateOfWeek As Date = Nothing
            Dim PreviousEmployeeCode As String = ""
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim WeeklyHoursRequiredByEmployee As Decimal = 0
            Dim EmployeeCode As String = ""
            Dim EmployeeName As String = ""
            Dim StartDateOfWeek As Date = Nothing
            Dim WeeklyHoursWorkedByEmployee As Decimal = 0
            Dim UserCode As String = ""
            Dim SendingEmailStatus As AdvantageFramework.Email.SendingEmailStatus = Email.SendingEmailStatus.EmailSent
            Dim CurrentDate As Date = Nothing
            Dim User As AdvantageFramework.Security.Database.Entities.User = Nothing
            Dim MissingTimeList As List(Of AdvantageFramework.Database.Entities.MissingTimeDetail) = Nothing
            Dim WeeklyTimeType As Integer = 0

            Using DbContext = New AdvantageFramework.Database.DbContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                Using DataContext = New AdvantageFramework.Database.DataContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                        If LogFileDirectory = "" OrElse My.Computer.FileSystem.DirectoryExists(LogFileDirectory) = False Then

                            LogFileDirectory = My.Application.Info.DirectoryPath

                        End If

                        LogFile = AdvantageFramework.StringUtilities.AppendTrailingCharacter(LogFileDirectory, "\") & "MissingTimeLogFile_" & DatabaseProfile.DatabaseServer.Replace("\", "_") & "_" & DatabaseProfile.DatabaseName.Replace("\", "_")

                        If IsSupervisorLog Then

                            LogFile &= ".log"

                        Else

                            LogFile &= "_IT.log"

                        End If

                        StringBuilder = New System.Text.StringBuilder

                        StringBuilder.AppendLine("UserID, EmpCode, EmpName, Date, Day, StdHrs, HrsWorked, Diff, WkStdHrs, WkHrsWorked, WkDiff")

                        For Each EmployeeCode In EmployeeList

                            Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode)

                            If Employee IsNot Nothing Then

                                WeeklyTimeType = Employee.WeeklyTimeType.GetValueOrDefault(2)

                                If WeeklyTimeType = 2 Then

                                    If Agency IsNot Nothing Then

                                        WeeklyTimeType = Agency.WeeklyTimeType.GetValueOrDefault(0)

                                    Else

                                        WeeklyTimeType = 0

                                    End If

                                End If

                                MissingTimeList = (From Entity In AdvantageFramework.Database.Procedures.MissingTimeDetail.LoadByEmployeeCodeAndLessThanOrEqualToDate(DataContext, EmployeeCode, EndDate)
                                                   Select Entity
                                                   Order By Entity.EmployeeCode, Entity.Date).ToList()

                                If AdvantageFramework.AlertSystem.MissingTimeListValid(MissingTimeList, WeeklyTimeType, MissingTimeOnly) Then

                                    For Each MissingTimeDetail In MissingTimeList

                                        If PreviousStartDateOfWeek <> MissingTimeDetail.StartOfWeekDate Then

                                            PreviousStartDateOfWeek = MissingTimeDetail.StartOfWeekDate

                                            StartDateOfWeek = MissingTimeDetail.StartOfWeekDate

                                            Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, MissingTimeDetail.EmployeeCode)

                                            If Employee IsNot Nothing Then

                                                If IsSupervisorLog = False Then

                                                    If Employee.IsMissingTime Is Nothing OrElse Employee.IsMissingTime = 0 Then

                                                        Try

                                                            Employee.IsMissingTime = 1

                                                            AdvantageFramework.Database.Procedures.EmployeeView.Update(DbContext, DataContext, Employee)

                                                        Catch ex As Exception

                                                        End Try

                                                    End If

                                                End If

                                                EmployeeName = Employee.ToString()

                                            Else

                                                EmployeeName = ""

                                            End If

                                            UserCode = ""

                                            User = AdvantageFramework.Security.Database.Procedures.User.LoadFirstUserByEmployeeCode(SecurityDbContext, EmployeeCode)

                                            If User IsNot Nothing Then

                                                UserCode = User.UserCode

                                            End If

                                        End If

                                        WeeklyHoursRequiredByEmployee = (From Entity In AdvantageFramework.Database.Procedures.MissingTimeDetail.LoadByEmployeeCode(DataContext, EmployeeCode)
                                                                         Where Entity.StartOfWeekDate = StartDateOfWeek
                                                                         Select Entity.StandardHours.GetValueOrDefault(0)).Sum

                                        WeeklyHoursWorkedByEmployee = (From Entity In AdvantageFramework.Database.Procedures.MissingTimeDetail.LoadByEmployeeCode(DataContext, EmployeeCode)
                                                                       Where Entity.StartOfWeekDate = StartDateOfWeek
                                                                       Select Entity.HoursWorked.GetValueOrDefault(0)).Sum

                                        StringBuilder.AppendLine(UserCode & ", " & EmployeeCode & ", " & EmployeeName & ", " & MissingTimeDetail.Date.GetValueOrDefault("01/01/1900").ToShortDateString & ", " & MissingTimeDetail.Date.GetValueOrDefault("01/01/1900").DayOfWeek.ToString & ", " & MissingTimeDetail.StandardHours & ", " & MissingTimeDetail.HoursWorked & ", " & MissingTimeDetail.HoursDifference & ", " & WeeklyHoursRequiredByEmployee & ", " & WeeklyHoursWorkedByEmployee & ", " & (WeeklyHoursRequiredByEmployee - WeeklyHoursWorkedByEmployee))

                                    Next

                                End If

                            End If

                        Next

                        My.Computer.FileSystem.WriteAllText(LogFile, StringBuilder.ToString, False)

                        If Not IsSupervisorLog Then

                            If Agency IsNot Nothing AndAlso Agency.ITContactEmail <> "" Then

                                If AdvantageFramework.Email.Send(DbContext, SecurityDbContext, Agency, LogFile, "Missing Time log as of " & Now().ToShortDateString, "", Priority, SendingEmailStatus) Then

                                    WriteToEventLog("Email sent to IT Contact --> " & Agency.ITContactEmail)

                                Else

                                    If SendingEmailStatus = Email.SendingEmailStatus.FailedToConnect Then

                                        WriteToEventLog("Failed to connect to email server for IT Contact --> " & Agency.ITContactEmail)

                                    ElseIf SendingEmailStatus = Email.SendingEmailStatus.FailedToSend Then

                                        WriteToEventLog("Failed to send email to IT Contact --> " & Agency.ITContactEmail)

                                    ElseIf SendingEmailStatus = Email.SendingEmailStatus.FailedToLoadSettings Then

                                        WriteToEventLog("Failed to load settings to IT Contact --> " & Agency.ITContactEmail)

                                    End If

                                End If

                            End If

                        End If

                    End Using

                End Using

            End Using

        End Sub
        Private Sub GenerateLogFile(ByRef DatabaseProfile As AdvantageFramework.Database.DatabaseProfile,
                                    ByRef IsSupervisorLog As Boolean,
                                    ByRef Agency As AdvantageFramework.Database.Entities.Agency,
                                    ByVal LogFileDirectory As String, ByVal Priority As Integer,
                                    ByVal MissingTimeOnly As Boolean, ByVal EndDate As Date, ByVal LateEndDate As Date, ByVal IncludeOnlyDaysThatAreLate As Boolean)

            'objects
            Dim LogFile As String = ""
            Dim StringBuilder As System.Text.StringBuilder = Nothing
            Dim PreviousEmployeeCode As String = ""
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim SendingEmailStatus As AdvantageFramework.Email.SendingEmailStatus = Email.SendingEmailStatus.EmailSent
            Dim MissingTimeList As List(Of AdvantageFramework.Database.Entities.MissingTimeDetail) = Nothing
            Dim WeeklyTimeType As Integer = 0
            Dim MissingTimeLogList As Generic.List(Of AdvantageFramework.Services.MissingTime.Classes.MissingTimeLog) = Nothing
            Dim MissingTimeLog As AdvantageFramework.Services.MissingTime.Classes.MissingTimeLog = Nothing
            Dim EmployeeList As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing
            Dim EmployeeCode As String = ""

            Using DbContext = New AdvantageFramework.Database.DbContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                Using DataContext = New AdvantageFramework.Database.DataContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                        MissingTimeLogList = New Generic.List(Of AdvantageFramework.Services.MissingTime.Classes.MissingTimeLog)

                        If LogFileDirectory = "" OrElse My.Computer.FileSystem.DirectoryExists(LogFileDirectory) = False Then

                            LogFileDirectory = My.Application.Info.DirectoryPath

                        End If

                        LogFile = AdvantageFramework.StringUtilities.AppendTrailingCharacter(LogFileDirectory, "\") & "MissingTimeLogFile_" & DatabaseProfile.DatabaseServer.Replace("\", "_") & "_" & DatabaseProfile.DatabaseName.Replace("\", "_")

                        If IsSupervisorLog Then

                            LogFile &= ".log"

                        Else

                            LogFile &= "_IT.log"

                        End If

                        EmployeeList = AdvantageFramework.Database.Procedures.EmployeeView.Load(DbContext).ToList

                        For Each EmployeeCode In AdvantageFramework.Database.Procedures.MissingTimeDetail.Load(DataContext).Select(Function(Entity) Entity.EmployeeCode).Distinct.ToList

                            Try

                                Employee = EmployeeList.SingleOrDefault(Function(Entity) Entity.Code = EmployeeCode)

                            Catch ex As Exception
                                Employee = Nothing
                            End Try

                            If Employee IsNot Nothing Then

                                WeeklyTimeType = Employee.WeeklyTimeType.GetValueOrDefault(2)

                                If WeeklyTimeType = 2 Then

                                    If Agency IsNot Nothing Then

                                        WeeklyTimeType = Agency.WeeklyTimeType.GetValueOrDefault(0)

                                    Else

                                        WeeklyTimeType = 0

                                    End If

                                End If

                                MissingTimeList = AdvantageFramework.Database.Procedures.MissingTimeDetail.LoadByEmployeeCodeAndLessThanOrEqualToDate(DataContext, Employee.Code, LateEndDate).ToList

                                If AdvantageFramework.AlertSystem.MissingTimeListValid(MissingTimeList, WeeklyTimeType, MissingTimeOnly) Then

                                    If IncludeOnlyDaysThatAreLate Then

                                        MissingTimeList = AdvantageFramework.Database.Procedures.MissingTimeDetail.LoadByEmployeeCodeAndLessThanOrEqualToDate(DataContext, Employee.Code, LateEndDate).ToList

                                    Else

                                        MissingTimeList = AdvantageFramework.Database.Procedures.MissingTimeDetail.LoadByEmployeeCodeAndLessThanOrEqualToDate(DataContext, Employee.Code, EndDate).ToList

                                    End If

                                    AddToMissingTimeLogList(SecurityDbContext, Employee, (WeeklyTimeType = 0), MissingTimeOnly, MissingTimeList, MissingTimeLogList)

                                End If

                            End If

                        Next

                        StringBuilder = New System.Text.StringBuilder

                        StringBuilder.AppendLine("UserID, EmpCode, EmpName, Date, Day, StdHrs, HrsWorked, Diff, WkStdHrs, WkHrsWorked, WkDiff")

                        For Each MissingTimeLog In MissingTimeLogList.OrderBy(Function(Entity) Entity.EmployeeCode).ThenBy(Function(Entity) Entity.Date).ToList

                            If PreviousEmployeeCode <> MissingTimeLog.EmployeeCode Then

                                PreviousEmployeeCode = MissingTimeLog.EmployeeCode

                                If IsSupervisorLog = False Then

                                    Try

                                        Employee = EmployeeList.SingleOrDefault(Function(Entity) Entity.Code = MissingTimeLog.EmployeeCode)

                                    Catch ex As Exception
                                        Employee = Nothing
                                    End Try

                                    If Employee IsNot Nothing Then

                                        Try

                                            Employee.IsMissingTime = 1

                                            AdvantageFramework.Database.Procedures.EmployeeView.Update(DbContext, DataContext, Employee)

                                        Catch ex As Exception

                                        End Try

                                    End If

                                End If

                            End If

                            StringBuilder.AppendLine(MissingTimeLog.ToString)

                        Next

                        My.Computer.FileSystem.WriteAllText(LogFile, StringBuilder.ToString, False)

                        If Not IsSupervisorLog Then

                            If Agency IsNot Nothing AndAlso Agency.ITContactEmail <> "" Then

                                If AdvantageFramework.Email.Send(DbContext, SecurityDbContext, Agency, LogFile, "Missing Time log as of " & Now().ToShortDateString, "", Priority, SendingEmailStatus) Then

                                    WriteToEventLog("Email sent to IT Contact --> " & Agency.ITContactEmail)

                                Else

                                    If SendingEmailStatus = Email.SendingEmailStatus.FailedToConnect Then

                                        WriteToEventLog("Failed to connect to email server for IT Contact --> " & Agency.ITContactEmail)

                                    ElseIf SendingEmailStatus = Email.SendingEmailStatus.FailedToSend Then

                                        WriteToEventLog("Failed to send email to IT Contact --> " & Agency.ITContactEmail)

                                    ElseIf SendingEmailStatus = Email.SendingEmailStatus.FailedToLoadSettings Then

                                        WriteToEventLog("Failed to load settings to IT Contact --> " & Agency.ITContactEmail)

                                    End If

                                End If

                            End If

                        End If

                    End Using

                End Using

            End Using

        End Sub
        Public Function IsServiceReadyToRun(ByVal DatabaseProfile As AdvantageFramework.Database.DatabaseProfile) As Boolean

            'objects
            Dim ServiceIsReadyToRun As Boolean = False
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing
            Dim Process As Boolean = False
            Dim ProcessTime As Boolean = False
            Dim ProcessTimeValue As Date = Nothing
            Dim ProcessTimeWeekday As String = ""
            Dim ProcessTimeDaily As Boolean = False
            Dim ProcessAfterHours As Integer = 0
            Dim ProcessStopAfterHours As Boolean = False
            Dim StopAfterHours As Integer = 0
            Dim LastRanAt As Date = Nothing
            Dim RunDayofWeek As AdvantageFramework.Services.MissingTime.RunDayofWeek = RunDayofWeek.Daily
            Dim StartTime As Date = Nothing

            If DatabaseProfile IsNot Nothing Then

                Try

                    Using DataContext = New AdvantageFramework.Database.DataContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                        AdvantageService = LoadAdvantageService(DataContext)

                        If AdvantageService IsNot Nothing Then

                            If AdvantageService.Enabled Then

                                LoadServiceSettings(DataContext, ProcessTime, ProcessTimeValue, ProcessTimeWeekday, ProcessTimeDaily, ProcessAfterHours, ProcessStopAfterHours, StopAfterHours, LastRanAt)

                                Try

                                    RunDayofWeek = AdvantageFramework.EnumUtilities.GetValue(GetType(AdvantageFramework.Services.MissingTime.RunDayofWeek), ProcessTimeWeekday)

                                Catch ex As Exception
                                    RunDayofWeek = RunDayofWeek.Daily
                                End Try

                                If ProcessTimeValue <> Nothing Then

                                    ProcessTimeValue = CDate(Now.ToShortDateString & " " & ProcessTimeValue.ToShortTimeString)

                                End If

                                If ProcessTime Then

                                    StartTime = ProcessTimeValue

                                    If RunDayofWeek = AdvantageFramework.Services.MissingTime.RunDayofWeek.Daily Then

                                        If DateDiff(DateInterval.Minute, ProcessTimeValue, Now) >= 0 AndAlso DateDiff(DateInterval.Day, LastRanAt, ProcessTimeValue) > 0 Then

                                            Process = True

                                        Else

                                            Process = False

                                        End If

                                    Else

                                        If Now.DayOfWeek.ToString.ToUpper = RunDayofWeek.ToString.ToUpper Then

                                            If DateDiff(DateInterval.Minute, ProcessTimeValue, Now) >= 0 AndAlso DateDiff(DateInterval.Day, LastRanAt, ProcessTimeValue) > 0 Then

                                                Process = True

                                            Else

                                                Process = False

                                            End If

                                        Else

                                            Process = False

                                        End If

                                    End If

                                Else

                                    StartTime = CDate(Now.ToShortDateString)

                                    Process = True

                                End If

                                If Process Then

                                    Process = False

                                    If ProcessTimeDaily Then

                                        If DateDiff(DateInterval.Hour, LastRanAt, Now) >= ProcessAfterHours Then

                                            If ProcessStopAfterHours Then

                                                If DateDiff(DateInterval.Hour, StartTime, LastRanAt) < StopAfterHours Then

                                                    Process = True

                                                Else

                                                    Process = False

                                                End If

                                            Else

                                                Process = True

                                            End If

                                        Else

                                            Process = False

                                        End If

                                    Else

                                        Process = True

                                    End If

                                End If

                                If ProcessTime = False AndAlso ProcessTimeDaily = False Then

                                    Process = False

                                End If

                                If Process Then

                                    LastRanAt = Now

                                    SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, RegistrySetting.LastRanAt, LastRanAt)

                                    ServiceIsReadyToRun = True

                                End If

                            End If

                        End If

                    End Using

                Catch ex As Exception
                    ServiceIsReadyToRun = False
                End Try

            End If

            IsServiceReadyToRun = ServiceIsReadyToRun

        End Function
        Public Sub Run(ByVal DatabaseProfile As AdvantageFramework.Database.DatabaseProfile)

            If DatabaseProfile IsNot Nothing Then

                Try

                    If IsServiceReadyToRun(DatabaseProfile) Then

                        ProcessDatabase(DatabaseProfile)

                    End If

                Catch ex As Exception
                    WriteToEventLog("Error -->" & ex.Message)
                End Try

                WriteToEventLog("Running")

            End If

        End Sub
        Public Sub LoadProcessSettings(ByVal DataContext As AdvantageFramework.Database.DataContext,
                                       ByRef RangeDaysToCheck As Boolean, _
                                       ByRef DaysToCheck As Integer, _
                                       ByRef SendEmailToEmployee As Boolean, _
                                       ByRef SendEmailToSupervisor As Boolean, _
                                       ByRef HighPriority As Boolean, _
                                       ByRef MediumPriority As Boolean, _
                                       ByRef LowPriority As Boolean, _
                                       ByRef DontCountWeekendsHoliday As Boolean, _
                                       ByRef MissingTimeOnly As Boolean, _
                                       ByRef EmployeeGracePeriod As Integer, _
                                       ByRef SupervisorGracePeriod As Integer, _
                                       ByRef ITContactGracePeriod As Integer, _
                                       ByRef CustomMessage As String, _
                                       ByRef LogFileDirectory As String, _
                                       ByRef IncludeOnlyDaysThatAreLate As Boolean)

            'objects
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing

            AdvantageService = LoadAdvantageService(DataContext)

            If AdvantageService IsNot Nothing Then

                Boolean.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MissingTime.RegistrySetting.RangeDaysToCheck), RangeDaysToCheck)
                Decimal.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MissingTime.RegistrySetting.RangeDaysToCheckValue), DaysToCheck)

                Boolean.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MissingTime.RegistrySetting.SendAlertToEmployee), SendEmailToEmployee)
                Boolean.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MissingTime.RegistrySetting.SendAlertToSupervisor), SendEmailToSupervisor)

                If LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MissingTime.RegistrySetting.Priority) = "HIGH" Then

                    HighPriority = True
                    MediumPriority = False
                    LowPriority = False

                ElseIf LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MissingTime.RegistrySetting.Priority) = "MEDIUM" Then

                    MediumPriority = True
                    HighPriority = False
                    LowPriority = False

                Else

                    LowPriority = True
                    HighPriority = False
                    MediumPriority = False

                End If

                Boolean.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MissingTime.RegistrySetting.DontCountWeekendsOrHolidays), DontCountWeekendsHoliday)
                Boolean.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MissingTime.RegistrySetting.MissingTimesheetsOnly), MissingTimeOnly)

                Integer.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MissingTime.RegistrySetting.GracePeriodDaysEmployee), EmployeeGracePeriod)
                Integer.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MissingTime.RegistrySetting.GracePeriodDaysSupervisor), SupervisorGracePeriod)
                Integer.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MissingTime.RegistrySetting.GracePeriodDaysITContact), ITContactGracePeriod)

                CustomMessage = LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MissingTime.RegistrySetting.CustomMessage)

                LogFileDirectory = LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MissingTime.RegistrySetting.LogFileDirectory)

                Boolean.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MissingTime.RegistrySetting.IncludeOnlyDaysThatAreLate), IncludeOnlyDaysThatAreLate)

            End If

        End Sub
        Public Sub LoadServiceSleep(ByVal DataContext As AdvantageFramework.Database.DataContext, ByRef Sleep As Integer, ByRef Tick As Boolean)

            'objects
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing

            AdvantageService = LoadAdvantageService(DataContext)

            If AdvantageService IsNot Nothing Then

                Integer.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MissingTime.RegistrySetting.Sleep), Sleep)

                Boolean.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MissingTime.RegistrySetting.Tick), Tick)

            End If

        End Sub
        Public Sub LoadMissingTimeEnabled(ByVal DataContext As AdvantageFramework.Database.DataContext, ByRef Enabled As Boolean)

            'objects
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing

            AdvantageService = LoadAdvantageService(DataContext)

            If AdvantageService IsNot Nothing Then

                Boolean.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MissingTime.RegistrySetting.Enabled), Enabled)

            End If

        End Sub
        Public Sub LoadServiceSettingsChanged(ByVal DataContext As AdvantageFramework.Database.DataContext, ByRef SettingsChanged As Boolean)

            'objects
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing

            AdvantageService = LoadAdvantageService(DataContext)

            If AdvantageService IsNot Nothing Then

                Boolean.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MissingTime.RegistrySetting.SettingsChanged), SettingsChanged)

            End If

        End Sub
        Public Sub LoadServiceSettings(ByVal DataContext As AdvantageFramework.Database.DataContext, _
                                       ByRef ProcessTime As Boolean, _
                                       ByRef ProcessTimeValue As Date, _
                                       ByRef ProcessTimeWeekday As String, _
                                       ByRef ProcessTimeDaily As Boolean, _
                                       ByRef ProcessAfterHours As Integer, _
                                       ByRef ProcessStopAfterHours As Boolean, _
                                       ByRef StopAfterHours As Integer, _
                                       Optional ByRef LastRanAt As Date = Nothing)

            'objects
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing
            Dim SettingsChanged As Boolean = False

            AdvantageService = LoadAdvantageService(DataContext)

            If AdvantageService IsNot Nothing Then

                Boolean.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MissingTime.RegistrySetting.ProcessTime), ProcessTime)

                If Date.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MissingTime.RegistrySetting.ProcessTimeValue), ProcessTimeValue) = False Then

                    ProcessTimeValue = Now

                End If

                Boolean.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MissingTime.RegistrySetting.ProcessTimeDaily), ProcessTimeDaily)

                ProcessTimeWeekday = LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MissingTime.RegistrySetting.ProcessTimeWeeklyDay)

                Decimal.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MissingTime.RegistrySetting.ProcessEveryHour), ProcessAfterHours)

                Boolean.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MissingTime.RegistrySetting.ProcessEveryHourStop), ProcessStopAfterHours)
                Decimal.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MissingTime.RegistrySetting.ProcessEveryHourStopAfterHours), StopAfterHours)

                Date.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MissingTime.RegistrySetting.LastRanAt), LastRanAt)

                'Reset Settings Changed flag
                LoadServiceSettingsChanged(DataContext, SettingsChanged)

                If SettingsChanged Then

                    SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MissingTime.RegistrySetting.SettingsChanged, "False")

                End If

            End If

        End Sub
        Public Sub SaveProcessSettings(ByVal DataContext As AdvantageFramework.Database.DataContext, _
                                       ByRef RangeDaysToCheck As Boolean, _
                                       ByRef DaysToCheck As Integer, _
                                       ByRef SendEmailToEmployee As Boolean, _
                                       ByRef SendEmailToSupervisor As Boolean, _
                                       ByRef HighPriority As Boolean, _
                                       ByRef MediumPriority As Boolean, _
                                       ByRef LowPriority As Boolean, _
                                       ByRef DontCountWeekendsHoliday As Boolean, _
                                       ByRef MissingTimeOnly As Boolean, _
                                       ByRef EmployeeGracePeriod As Integer, _
                                       ByRef SupervisorGracePeriod As Integer, _
                                       ByRef ITContactGracePeriod As Integer, _
                                       ByRef CustomMessage As String, _
                                       ByRef LogFileDirectory As String, _
                                       ByRef IncludeOnlyDaysThatAreLate As Boolean)

            'objects
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing

            AdvantageService = LoadAdvantageService(DataContext)

            If AdvantageService IsNot Nothing Then

                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MissingTime.RegistrySetting.RangeDaysToCheck, RangeDaysToCheck)
                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MissingTime.RegistrySetting.RangeDaysToCheckValue, DaysToCheck)

                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MissingTime.RegistrySetting.SendAlertToEmployee, SendEmailToEmployee)
                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MissingTime.RegistrySetting.SendAlertToSupervisor, SendEmailToSupervisor)

                If HighPriority Then

                    SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MissingTime.RegistrySetting.Priority, "HIGH")

                ElseIf MediumPriority Then

                    SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MissingTime.RegistrySetting.Priority, "MEDIUM")

                Else

                    SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MissingTime.RegistrySetting.Priority, "LOW")

                End If

                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MissingTime.RegistrySetting.DontCountWeekendsOrHolidays, DontCountWeekendsHoliday)
                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MissingTime.RegistrySetting.MissingTimesheetsOnly, MissingTimeOnly)

                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MissingTime.RegistrySetting.GracePeriodDaysEmployee, EmployeeGracePeriod)
                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MissingTime.RegistrySetting.GracePeriodDaysSupervisor, SupervisorGracePeriod)
                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MissingTime.RegistrySetting.GracePeriodDaysITContact, ITContactGracePeriod)

                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MissingTime.RegistrySetting.CustomMessage, CustomMessage)

                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MissingTime.RegistrySetting.LogFileDirectory, LogFileDirectory)

                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MissingTime.RegistrySetting.IncludeOnlyDaysThatAreLate, IncludeOnlyDaysThatAreLate)

            End If

        End Sub
        Public Sub SaveServiceSettings(ByVal DataContext As AdvantageFramework.Database.DataContext,
                                       ByRef ProcessTime As Boolean, _
                                       ByRef ProcessTimeValue As Date, _
                                       ByRef ProcessTimeWeekday As String, _
                                       ByRef ProcessTimeDaily As Boolean, _
                                       ByRef ProcessAfterHours As Integer, _
                                       ByRef ProcessStopAfterHours As Boolean, _
                                       ByRef StopAfterHours As Integer)

            'objects
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing
            'Dim PreviousProcessTime As Boolean = False
            'Dim PreviousProcessTimeValue As Date = Nothing
            'Dim PreviousProcessTimeWeekday As String = ""
            'Dim PreviousProcessTimeDaily As Boolean = False
            'Dim PreviousProcessAfterHours As Integer = 0
            'Dim PreviousProcessStopAfterHours As Boolean = False
            'Dim PreviousStopAfterHours As Integer = 0
            'Dim ServiceController As System.ServiceProcess.ServiceController = Nothing
            'Dim ServiceReloadSettings As Boolean = False

            AdvantageService = LoadAdvantageService(DataContext)

            If AdvantageService IsNot Nothing Then

                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MissingTime.RegistrySetting.ProcessTime, ProcessTime)
                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MissingTime.RegistrySetting.ProcessTimeValue, ProcessTimeValue)
                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MissingTime.RegistrySetting.ProcessTimeWeeklyDay, ProcessTimeWeekday)
                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MissingTime.RegistrySetting.ProcessTimeDaily, ProcessTimeDaily)
                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MissingTime.RegistrySetting.ProcessEveryHour, ProcessAfterHours)
                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MissingTime.RegistrySetting.ProcessEveryHourStop, ProcessStopAfterHours)
                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MissingTime.RegistrySetting.ProcessEveryHourStopAfterHours, StopAfterHours)
                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MissingTime.RegistrySetting.SettingsChanged, "True")

            End If

            'PreviousProcessTime = AdvantageFramework.Registry.Load(AdvantageFramework.Registry.LoadMissingTimeRegistryKey(Registry.SettingsType.Service, DatabaseProfile.Name),
            '                                                       AdvantageFramework.Services.MissingTime.RegistrySetting.ProcessTime)

            'If PreviousProcessTime <> ProcessTime Then

            '    SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MissingTime.RegistrySetting.ProcessTime, ProcessTime)
            '    ServiceReloadSettings = True

            'End If

            '****************************

            'DateTime.TryParse(AdvantageFramework.Registry.Load(AdvantageFramework.Registry.LoadMissingTimeRegistryKey(Registry.SettingsType.Service, DatabaseProfile.Name),
            '                                                   AdvantageFramework.Services.MissingTime.RegistrySetting.ProcessTimeValue), PreviousProcessTimeValue)

            'If PreviousProcessTimeValue <> ProcessTimeValue Then

            '    SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MissingTime.RegistrySetting.ProcessTimeValue, ProcessTimeValue)
            '    ServiceReloadSettings = True

            'End If

            '****************************

            'PreviousProcessTimeWeekday = AdvantageFramework.Registry.Load(AdvantageFramework.Registry.LoadMissingTimeRegistryKey(Registry.SettingsType.Service, DatabaseProfile.Name),
            '                                                              AdvantageFramework.Services.MissingTime.RegistrySetting.ProcessTimeWeeklyDay)

            'If PreviousProcessTimeWeekday <> ProcessTimeWeekday Then

            '    SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MissingTime.RegistrySetting.ProcessTimeWeeklyDay, ProcessTimeWeekday)
            '    ServiceReloadSettings = True

            'End If

            '****************************

            'PreviousProcessTimeDaily = AdvantageFramework.Registry.Load(AdvantageFramework.Registry.LoadMissingTimeRegistryKey(Registry.SettingsType.Service, DatabaseProfile.Name),
            '                                                            AdvantageFramework.Services.MissingTime.RegistrySetting.ProcessTimeDaily)

            'If PreviousProcessTimeDaily <> ProcessTimeDaily Then

            '    SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MissingTime.RegistrySetting.ProcessTimeDaily, ProcessTimeDaily)
            '    ServiceReloadSettings = True

            'End If

            '****************************

            'Integer.TryParse(AdvantageFramework.Registry.Load(AdvantageFramework.Registry.LoadMissingTimeRegistryKey(Registry.SettingsType.Service, DatabaseProfile.Name),
            '                                                  AdvantageFramework.Services.MissingTime.RegistrySetting.ProcessEveryHour), PreviousProcessAfterHours)

            'If PreviousProcessAfterHours <> ProcessAfterHours Then

            '    SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MissingTime.RegistrySetting.ProcessEveryHour, ProcessAfterHours)
            '    ServiceReloadSettings = True

            'End If

            '****************************

            'PreviousProcessStopAfterHours = AdvantageFramework.Registry.Load(AdvantageFramework.Registry.LoadMissingTimeRegistryKey(Registry.SettingsType.Service, DatabaseProfile.Name),
            '                                                                 AdvantageFramework.Services.MissingTime.RegistrySetting.ProcessEveryHourStop)

            'If PreviousProcessStopAfterHours <> ProcessStopAfterHours Then

            '    SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MissingTime.RegistrySetting.ProcessEveryHourStop, ProcessStopAfterHours)
            '    ServiceReloadSettings = True

            'End If

            '****************************

            'Integer.TryParse(AdvantageFramework.Registry.Load(AdvantageFramework.Registry.LoadMissingTimeRegistryKey(Registry.SettingsType.Service, DatabaseProfile.Name),
            '                                                  AdvantageFramework.Services.MissingTime.RegistrySetting.ProcessEveryHourStopAfterHours), PreviousStopAfterHours)

            'If PreviousStopAfterHours <> StopAfterHours Then

            '    SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MissingTime.RegistrySetting.ProcessEveryHourStopAfterHours, StopAfterHours)
            '    ServiceReloadSettings = True

            'End If

            'Set Settings Changed flag
            'SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MissingTime.RegistrySetting.SettingsChanged, "True")

            'If ServiceReloadSettings Then

            '    ServiceController = AdvantageFramework.Services.Load(AdvantageFramework.Services.Service.AdvantageMissingTimeWindowsService)

            '    If ServiceController IsNot Nothing AndAlso ServiceController.Status = ServiceProcess.ServiceControllerStatus.Running Then

            '        ServiceController.ExecuteCommand(AdvantageFramework.Services.MissingTime.CustomCommand.ProfileUpdated)

            '    End If

            'End If

        End Sub
        Public Sub WriteToEventLog(Message As String)

            Try

                SyncLock _EventLog

                    _EventLog.WriteEntry(Message)

                End SyncLock

            Catch ex As Exception

            End Try

        End Sub
        Public Sub ClearLog()

            Try

                SyncLock _EventLog

                    _EventLog.Clear()

                End SyncLock

            Catch ex As Exception

            End Try

        End Sub

#End Region

    End Module

End Namespace

