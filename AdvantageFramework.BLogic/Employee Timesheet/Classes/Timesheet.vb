Namespace EmployeeTimesheet.Classes

    <Serializable()>
    Public Class Timesheet

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            StartDate
            EndDate
            EmployeeCode
            TimeSheetEntries
            TimesheetDays
            DefaultEmployeeFunctionCode
            SupervisorApprovalActive
            CanEditDay1
            CanEditDay2
            CanEditDay3
            CanEditDay4
            CanEditDay5
            CanEditDay6
            CanEditDay7
        End Enum

#End Region

#Region " Variables "

        Private _StartDate As Date = Nothing
        Private _EndDate As Date = Nothing
        Private _EmployeeCode As String = ""
        Private _DefaultEmployeeFunctionCode As String = Nothing
        Private _DefaultEmployeeDepartmentTeam As String = Nothing
        Private _SupervisorApprovalActive As Boolean = False
        Private _TimeSheetEntries As Generic.List(Of AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry) = Nothing
        Private _TimesheetDays As Generic.List(Of AdvantageFramework.EmployeeTimesheet.Classes.TimesheetDay) = Nothing
        Private _Day1Status As AdvantageFramework.EmployeeTimesheet.DayStatus = Nothing
        Private _Day2Status As AdvantageFramework.EmployeeTimesheet.DayStatus = Nothing
        Private _Day3Status As AdvantageFramework.EmployeeTimesheet.DayStatus = Nothing
        Private _Day4Status As AdvantageFramework.EmployeeTimesheet.DayStatus = Nothing
        Private _Day5Status As AdvantageFramework.EmployeeTimesheet.DayStatus = Nothing
        Private _Day6Status As AdvantageFramework.EmployeeTimesheet.DayStatus = Nothing
        Private _Day7Status As AdvantageFramework.EmployeeTimesheet.DayStatus = Nothing
        Private _ReportMissingTime As AdvantageFramework.Database.Entities.ReportMissingTime = Nothing
        Private _AllowQvAQuery As Boolean = False

#End Region

#Region " Properties "

        Public ReadOnly Property StartDate As Date
            Get
                StartDate = _StartDate
            End Get
        End Property
        Public ReadOnly Property EndDate As Date
            Get
                EndDate = _EndDate
            End Get
        End Property
        Public ReadOnly Property EmployeeCode As String
            Get
                EmployeeCode = _EmployeeCode
            End Get
        End Property
        Public ReadOnly Property TimeSheetEntries As Generic.List(Of AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry)
            Get
                TimeSheetEntries = _TimeSheetEntries
            End Get
        End Property
        Public ReadOnly Property TimesheetDays As Generic.List(Of AdvantageFramework.EmployeeTimesheet.Classes.TimesheetDay)
            Get
                TimesheetDays = _TimesheetDays
            End Get
        End Property
        Public ReadOnly Property DefaultEmployeeFunctionCode As String
            Get
                DefaultEmployeeFunctionCode = _DefaultEmployeeFunctionCode
            End Get
        End Property
        Public ReadOnly Property DefaultEmployeeDepartmentTeam As String
            Get
                DefaultEmployeeDepartmentTeam = _DefaultEmployeeDepartmentTeam
            End Get
        End Property
        Public ReadOnly Property SupervisorApprovalActive As Boolean
            Get
                SupervisorApprovalActive = _SupervisorApprovalActive
            End Get
        End Property
        Public ReadOnly Property AllowQvAQuery As Boolean
            Get
                AllowQvAQuery = _AllowQvAQuery
            End Get
        End Property
        Public ReadOnly Property Day1Status As AdvantageFramework.EmployeeTimesheet.DayStatus
            Get
                Day1Status = _Day1Status
            End Get
        End Property
        Public ReadOnly Property Day2Status As AdvantageFramework.EmployeeTimesheet.DayStatus
            Get
                Day2Status = _Day2Status
            End Get
        End Property
        Public ReadOnly Property Day3Status As AdvantageFramework.EmployeeTimesheet.DayStatus
            Get
                Day3Status = _Day3Status
            End Get
        End Property
        Public ReadOnly Property Day4Status As AdvantageFramework.EmployeeTimesheet.DayStatus
            Get
                Day4Status = _Day4Status
            End Get
        End Property
        Public ReadOnly Property Day5Status As AdvantageFramework.EmployeeTimesheet.DayStatus
            Get
                Day5Status = _Day5Status
            End Get
        End Property
        Public ReadOnly Property Day6Status As AdvantageFramework.EmployeeTimesheet.DayStatus
            Get
                Day6Status = _Day6Status
            End Get
        End Property
        Public ReadOnly Property Day7Status As AdvantageFramework.EmployeeTimesheet.DayStatus
            Get
                Day7Status = _Day7Status
            End Get
        End Property
        Public ReadOnly Property Day1Hours As Decimal
            Get

                Try

                    Day1Hours = (From Entity In Me.TimeSheetEntries _
                                 Select Entity.Day1Hours.GetValueOrDefault(0)).Sum

                Catch ex As Exception
                    Day1Hours = 0
                End Try

            End Get
        End Property
        Public ReadOnly Property Day2Hours As Decimal
            Get

                Try

                    Day2Hours = (From Entity In Me.TimeSheetEntries _
                                 Select Entity.Day2Hours.GetValueOrDefault(0)).Sum

                Catch ex As Exception
                    Day2Hours = 0
                End Try

            End Get
        End Property
        Public ReadOnly Property Day3Hours As Decimal
            Get

                Try

                    Day3Hours = (From Entity In Me.TimeSheetEntries _
                                 Select Entity.Day3Hours.GetValueOrDefault(0)).Sum

                Catch ex As Exception
                    Day3Hours = 0
                End Try

            End Get
        End Property
        Public ReadOnly Property Day4Hours As Decimal
            Get

                Try

                    Day4Hours = (From Entity In Me.TimeSheetEntries _
                                 Select Entity.Day4Hours.GetValueOrDefault(0)).Sum

                Catch ex As Exception
                    Day4Hours = 0
                End Try

            End Get
        End Property
        Public ReadOnly Property Day5Hours As Decimal
            Get

                Try

                    Day5Hours = (From Entity In Me.TimeSheetEntries _
                                 Select Entity.Day5Hours.GetValueOrDefault(0)).Sum

                Catch ex As Exception
                    Day5Hours = 0
                End Try

            End Get
        End Property
        Public ReadOnly Property Day6Hours As Decimal
            Get

                Try

                    Day6Hours = (From Entity In Me.TimeSheetEntries _
                                 Select Entity.Day6Hours.GetValueOrDefault(0)).Sum

                Catch ex As Exception
                    Day6Hours = 0
                End Try

            End Get
        End Property
        Public ReadOnly Property Day7Hours As Decimal
            Get

                Try

                    Day7Hours = (From Entity In Me.TimeSheetEntries _
                                 Select Entity.Day7Hours.GetValueOrDefault(0)).Sum

                Catch ex As Exception
                    Day7Hours = 0
                End Try

            End Get
        End Property
        Public ReadOnly Property ReportMissingTime As AdvantageFramework.Database.Entities.ReportMissingTime
            Get
                ReportMissingTime = _ReportMissingTime
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeCode As String,
                       ByVal StartDate As Date, ByVal EndDate As Date, ByVal SortColumn As String, ByVal UserCode As String)

            'objects
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim EmployeeTimeComplexList As Generic.List(Of AdvantageFramework.Database.Classes.EmployeeTimeComplex) = Nothing
            Dim EmployeeTimeComplex As AdvantageFramework.Database.Classes.EmployeeTimeComplex = Nothing
            Dim TimesheetEntry As AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry = Nothing
            Dim AssociatedTimesheetEntryList As Generic.List(Of AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry) = Nothing
            Dim EmployeeTimeComments As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeTimeComment) = Nothing
            Dim TimesheetDay As AdvantageFramework.EmployeeTimesheet.Classes.TimesheetDay = Nothing
            Dim DayStatus As AdvantageFramework.EmployeeTimesheet.DayStatus = Nothing
            Dim EmployeeComment As String
            Dim CurrentDate As Date = Nothing
            Dim EmployeeTimeIDs As Integer() = Nothing
            Dim CreateNew As Boolean = False

            _StartDate = StartDate
            _EndDate = EndDate
            _EmployeeCode = EmployeeCode
            _Day1Status = AdvantageFramework.EmployeeTimesheet.DayStatus.Open
            _Day2Status = AdvantageFramework.EmployeeTimesheet.DayStatus.Open
            _Day3Status = AdvantageFramework.EmployeeTimesheet.DayStatus.Open
            _Day4Status = AdvantageFramework.EmployeeTimesheet.DayStatus.Open
            _Day5Status = AdvantageFramework.EmployeeTimesheet.DayStatus.Open
            _Day6Status = AdvantageFramework.EmployeeTimesheet.DayStatus.Open
            _Day7Status = AdvantageFramework.EmployeeTimesheet.DayStatus.Open

            Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, _EmployeeCode)

            If Employee.WeeklyTimeType.HasValue Then

                Try

                    _ReportMissingTime = DirectCast(CInt(Employee.WeeklyTimeType.Value), AdvantageFramework.Database.Entities.ReportMissingTime)

                Catch ex As Exception

                End Try

            Else

                Try

                    _ReportMissingTime = DirectCast(CInt(AdvantageFramework.Database.Procedures.Agency.Load(DbContext).WeeklyTimeType.GetValueOrDefault(0)), AdvantageFramework.Database.Entities.ReportMissingTime)

                Catch ex As Exception

                End Try

            End If

            _SupervisorApprovalActive = False

            If AdvantageFramework.Database.Procedures.Agency.Load(DbContext).SupervisorApprovalActive.GetValueOrDefault(0) = 1 Then

                If Employee.TimesheetApprovalFlag.GetValueOrDefault(False) = False Then

                    _SupervisorApprovalActive = True

                End If

            End If

            _AllowQvAQuery = CBool(AdvantageFramework.Database.Procedures.Agency.Load(DbContext).QVAQuery.GetValueOrDefault(0))
            _DefaultEmployeeFunctionCode = Employee.FunctionCode
            _DefaultEmployeeDepartmentTeam = Employee.DepartmentTeamCode

            EmployeeTimeComplexList = AdvantageFramework.Database.Procedures.EmployeeTimeComplex.Load(DbContext, EmployeeCode, StartDate, EndDate, SortColumn, UserCode).ToList

            Try

                EmployeeTimeIDs = (From Entity In EmployeeTimeComplexList
                                   Order By Entity.CreateDate Ascending
                                   Select Entity.EmployeeTimeID).Distinct.ToArray

            Catch ex As Exception
                EmployeeTimeIDs = Nothing
            End Try

            _TimeSheetEntries = New Generic.List(Of AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry)
            _TimesheetDays = New Generic.List(Of AdvantageFramework.EmployeeTimesheet.Classes.TimesheetDay)

            If EmployeeTimeIDs IsNot Nothing Then

                Try

                    EmployeeTimeComments = (From Entity In AdvantageFramework.Database.Procedures.EmployeeTimeComment.Load(DbContext)
                                            Where EmployeeTimeIDs.Contains(Entity.EmployeeTimeID) = True
                                            Select Entity).ToList

                Catch ex As Exception
                    EmployeeTimeComments = Nothing
                End Try

                For Each EmployeeTimeID In EmployeeTimeIDs

                    For Each EmployeeTimeComplex In EmployeeTimeComplexList.Where(Function(EmpTimeComplex) EmpTimeComplex.EmployeeTimeID = EmployeeTimeID)

                        TimesheetEntry = Nothing
                        CreateNew = False
                        TimesheetDay = Nothing

                        Try

                            AssociatedTimesheetEntryList = (From Entry In _TimeSheetEntries
                                                            Where Entry.ClientCode = EmployeeTimeComplex.ClientCode AndAlso
                                                                  Entry.DivisionCode = EmployeeTimeComplex.DivisionCode AndAlso
                                                                  Entry.ProductCode = EmployeeTimeComplex.ProductCode AndAlso
                                                                  Entry.JobNumber.GetValueOrDefault(0) = EmployeeTimeComplex.JobNumber.GetValueOrDefault(0) AndAlso
                                                                  Entry.JobCompNumber.GetValueOrDefault(0) = EmployeeTimeComplex.JobComponentNumber.GetValueOrDefault(0) AndAlso
                                                                  Entry.FunctionCode = EmployeeTimeComplex.FunctionCategory AndAlso
                                                                  Entry.DepartmentTeamCode = EmployeeTimeComplex.DepartmentTeamCode
                                                            Select Entry).ToList

                        Catch ex As Exception
                            AssociatedTimesheetEntryList = Nothing
                        End Try

                        If AssociatedTimesheetEntryList Is Nothing OrElse AssociatedTimesheetEntryList.Count = 0 Then

                            CreateNew = True

                        Else

                            For Each AssociatedTimesheetEntry In AssociatedTimesheetEntryList

                                If EmployeeTimeComplex.EmployeeDate = StartDate Then

                                    If AssociatedTimesheetEntry.Day1Hours.HasValue = False Then

                                        TimesheetEntry = AssociatedTimesheetEntry

                                        Exit For

                                    End If

                                ElseIf EmployeeTimeComplex.EmployeeDate = StartDate.AddDays(1) Then

                                    If AssociatedTimesheetEntry.Day2Hours.HasValue = False Then

                                        TimesheetEntry = AssociatedTimesheetEntry

                                        Exit For

                                    End If

                                ElseIf EmployeeTimeComplex.EmployeeDate = StartDate.AddDays(2) Then

                                    If AssociatedTimesheetEntry.Day3Hours.HasValue = False Then

                                        TimesheetEntry = AssociatedTimesheetEntry

                                        Exit For

                                    End If

                                ElseIf EmployeeTimeComplex.EmployeeDate = StartDate.AddDays(3) Then

                                    If AssociatedTimesheetEntry.Day4Hours.HasValue = False Then

                                        TimesheetEntry = AssociatedTimesheetEntry

                                        Exit For

                                    End If

                                ElseIf EmployeeTimeComplex.EmployeeDate = StartDate.AddDays(4) Then

                                    If AssociatedTimesheetEntry.Day5Hours.HasValue = False Then

                                        TimesheetEntry = AssociatedTimesheetEntry

                                        Exit For

                                    End If

                                ElseIf EmployeeTimeComplex.EmployeeDate = StartDate.AddDays(5) Then

                                    If AssociatedTimesheetEntry.Day6Hours.HasValue = False Then

                                        TimesheetEntry = AssociatedTimesheetEntry

                                        Exit For

                                    End If

                                ElseIf EmployeeTimeComplex.EmployeeDate = StartDate.AddDays(6) Then

                                    If AssociatedTimesheetEntry.Day7Hours.HasValue = False Then

                                        TimesheetEntry = AssociatedTimesheetEntry

                                        Exit For

                                    End If

                                End If

                            Next

                        End If

                        If CreateNew OrElse TimesheetEntry Is Nothing Then

                            TimesheetEntry = CreateTimesheetRecord(EmployeeTimeComplex)
                            TimesheetEntry.SetStartDate(_StartDate)

                        End If

                        Try

                            EmployeeComment = (From Entity In EmployeeTimeComments
                                               Where Entity.EmployeeTimeID = EmployeeTimeComplex.EmployeeTimeID AndAlso
                                                     Entity.EmployeeTimeDetailID = EmployeeTimeComplex.EmployeeTimeDetailID AndAlso
                                                     Entity.SequenceNumber = EmployeeTimeComplex.MaxSequence AndAlso
                                                     Entity.EmployeeTimeSource = If(EmployeeTimeComplex.JobNumber.HasValue, "D", "N")
                                               Select Entity).SingleOrDefault.EmployeeComments

                        Catch ex As Exception
                            EmployeeComment = Nothing
                        End Try

                        TimesheetEntry.SetEntryDayProperties(EmployeeTimeComplex, EmployeeTimeComplex.EmployeeDate.Value.Subtract(StartDate).Days + 1, EmployeeComment)

                        TimesheetEntry.ProductCategoryCode = EmployeeTimeComplex.ProductCategoryCode
                        TimesheetEntry.ProductCategoryDescription = EmployeeTimeComplex.ProductCategoryDescription
                        TimesheetEntry.QuotedHours = EmployeeTimeComplex.QuotedHours.GetValueOrDefault(0)
                        TimesheetEntry.ActualHours = EmployeeTimeComplex.ActualHours.GetValueOrDefault(0)
                        TimesheetEntry.IsOverThreshold = EmployeeTimeComplex.IsOverThreshold
                        TimesheetEntry.ProgressIsShowingTrafficHours = EmployeeTimeComplex.ProgressIsShowingTrafficHours
                        TimesheetEntry.CommentsRequired = CBool(EmployeeTimeComplex.CommentsRequired.GetValueOrDefault(0)) OrElse CBool(EmployeeTimeComplex.ClientCommentRequired.GetValueOrDefault(0))
                        'TimesheetEntry.EstimateHours = EmployeeTimeComplex.EstimateHours
                        'TimesheetEntry.EstimateHoursAll = EmployeeTimeComplex.EstimateHoursAll
                        'TimesheetEntry.ScheduleHours = EmployeeTimeComplex.ScheduleHours
                        'TimesheetEntry.ScheduleHoursAll = EmployeeTimeComplex.ScheduleHoursAll
                        'TimesheetEntry.EstimateVariance = EmployeeTimeComplex.EstimateVariance
                        'TimesheetEntry.EstimateVarianceAll = EmployeeTimeComplex.EstimateVarianceAll
                        'TimesheetEntry.ScheduleVariance = EmployeeTimeComplex.ScheduleVariance
                        'TimesheetEntry.ScheduleVarianceAll = EmployeeTimeComplex.ScheduleVarianceAll

                    Next

                Next

                For Each EmployeeTimeComplex In EmployeeTimeComplexList

                    TimesheetDay = Nothing

                    Try

                        TimesheetDay = (From Entity In _TimesheetDays
                                        Where Entity.DayDate = EmployeeTimeComplex.EmployeeDate
                                        Select Entity).SingleOrDefault

                    Catch ex As Exception
                        TimesheetDay = Nothing
                    End Try

                    If TimesheetDay Is Nothing Then

                        TimesheetDay = New AdvantageFramework.EmployeeTimesheet.Classes.TimesheetDay
                        TimesheetDay.DayDate = EmployeeTimeComplex.EmployeeDate
                        _TimesheetDays.Add(TimesheetDay)

                    End If

                    TimesheetDay.TotalHours = TimesheetDay.TotalHours.GetValueOrDefault(0) + EmployeeTimeComplex.EmployeeHours
                    TimesheetDay.IsDenied = EmployeeTimeComplex.DayIsDenied.GetValueOrDefault(False)
                    TimesheetDay.IsApproved = EmployeeTimeComplex.DayIsApproved.GetValueOrDefault(False)
                    TimesheetDay.IsPendingApproval = EmployeeTimeComplex.DayIsPendingApproval.GetValueOrDefault(False)
                    TimesheetDay.PostPeriodIsClosed = EmployeeTimeComplex.DayPostPeriodClosed.GetValueOrDefault(False)

                Next

                CurrentDate = _StartDate

                While CurrentDate <= _EndDate

                    DayStatus = Methods.DayStatus.Open

                    Try

                        EmployeeTimeComplex = (From EmpTimeComplex In EmployeeTimeComplexList
                                               Where EmpTimeComplex.EmployeeDate = CurrentDate
                                               Select EmpTimeComplex).FirstOrDefault

                    Catch ex As Exception
                        EmployeeTimeComplex = Nothing
                    End Try

                    If EmployeeTimeComplex IsNot Nothing Then

                        If EmployeeTimeComplex.DayPostPeriodClosed.GetValueOrDefault(False) = True Then

                            DayStatus = AdvantageFramework.EmployeeTimesheet.DayStatus.PostPeriodClosed

                        ElseIf EmployeeTimeComplex.DayIsPendingApproval.GetValueOrDefault(False) = True Then

                            DayStatus = AdvantageFramework.EmployeeTimesheet.DayStatus.Pending

                        ElseIf EmployeeTimeComplex.DayIsApproved.GetValueOrDefault(False) = True Then

                            DayStatus = AdvantageFramework.EmployeeTimesheet.DayStatus.Approved

                        ElseIf EmployeeTimeComplex.DayIsDenied.GetValueOrDefault(False) = True Then

                            DayStatus = AdvantageFramework.EmployeeTimesheet.DayStatus.Denied

                        Else

                            DayStatus = AdvantageFramework.EmployeeTimesheet.DayStatus.Open

                        End If

                    Else

                        If AdvantageFramework.EmployeeTimesheet.CheckIfPostPeriodIsAvailable(DbContext, CurrentDate) = False Then

                            DayStatus = AdvantageFramework.EmployeeTimesheet.DayStatus.PostPeriodClosed

                        End If

                    End If

                    Select Case CurrentDate

                        Case _StartDate

                            _Day1Status = DayStatus

                        Case _StartDate.AddDays(1)

                            _Day2Status = DayStatus

                        Case _StartDate.AddDays(2)

                            _Day3Status = DayStatus

                        Case _StartDate.AddDays(3)

                            _Day4Status = DayStatus

                        Case _StartDate.AddDays(4)

                            _Day5Status = DayStatus

                        Case _StartDate.AddDays(5)

                            _Day6Status = DayStatus

                        Case _StartDate.AddDays(6)

                            _Day7Status = DayStatus

                    End Select

                    CurrentDate = CurrentDate.AddDays(1)

                End While

            End If

        End Sub
        Public Function CreateTimesheetRecord(ByVal EmployeeTimeComplex As AdvantageFramework.Database.Classes.EmployeeTimeComplex) As AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry

            'objects
            Dim TimesheetEntry As AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry = Nothing

            Try

                If EmployeeTimeComplex IsNot Nothing Then

                    TimesheetEntry = New AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry(EmployeeTimeComplex)

                    _TimeSheetEntries.Add(TimesheetEntry)

                End If

            Catch ex As Exception

            End Try

            CreateTimesheetRecord = TimesheetEntry

        End Function

#End Region

    End Class

    <Serializable()>
    Public Class DailyHours

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property DayDisplay As Date
        Public Property Hours As Decimal? = 0.0
        Public Property StandardHoursGoal As Decimal? = 0.0
        Public Property HoursGoal As Decimal? = 0.0
        Public Property HolidayHours As Decimal? = 0.0
        Public Property IsAllDayHoliday As Boolean? = False
        Public Property HasStopwatch As Boolean? = False
        Public Property StopwatchEmployeeTimeID As Integer? = 0
        Public Property StopwatchEmployeeTimeDetailID As Short? = 0

#End Region

#Region " Methods "

        Sub New()

        End Sub

#End Region

    End Class

End Namespace


