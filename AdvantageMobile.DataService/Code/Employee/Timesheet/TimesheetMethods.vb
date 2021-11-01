Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Data.Services
Imports System.Data.Services.Common
Imports System.Data.Services.Providers
Imports System.Data.SqlClient
Imports System.Linq
Imports System.ServiceModel.Web
Imports System.Web
Imports AdvantageFramework.Security.Classes
Imports System.Data.Entity.Core.Objects

Namespace AdvantageMobile.DataService.Timesheet

    <System.Serializable()> Public Class Methods

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum EditFlag

            Billed = 1
            Summarized = 2
            RestrictedAB = 3
            SelectedForBilling = 4
            Pending = 5
            Approved = 6
            Denied = 7

        End Enum
        Public Enum Status

            ReadyToSubmit = 0
            Pending = 1
            Approved = 2
            Denied = 3
            NotSubmitted = 4
            Missing = 5
            AllTime = 6 'disregard approval status
            DoesNotExist = 7 'represent days that don't exist in db...
            PostPeriodClosed = 8
            Entered = 9

        End Enum
        Public Enum SummaryGrouping

            Week = 0
            Month = 1
            Year = 2

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Private Property _DataEntities As DataEntities
        Private Property _DataServiceUser As DataServiceUser
        Private Property _ConnectionString As String = ""
        Private Property _UserCode As String = ""

#End Region

#Region " Methods "

        Public Function CopyTimeEntry(ByVal EmployeeTimeID As Integer, ByVal EmployeeTimeDetailID As Integer, ByVal EmployeeCode As String, ByVal [Date] As String) As SaveTimeEntryResult

            Dim EntryToCopy As TimeEntry = GetTimeEntry(EmployeeTimeID, EmployeeTimeDetailID)
            Dim Result As New SaveTimeEntryResult

            If EntryToCopy IsNot Nothing Then

                If EntryToCopy.TimeType.Trim().ToUpper() = "D" Then

                    Result = SaveTimeEntry(0, 0, EmployeeCode, [Date], EntryToCopy.FunctionCategory, 0,
                                           EntryToCopy.JobNumber, EntryToCopy.JobComponentNumber, EntryToCopy.DepartmentTeamCode, EntryToCopy.ProductCode, Me._UserCode, "", EntryToCopy.AlertID, Nothing)

                Else

                    Result = SaveTimeEntry(0, 0, EmployeeCode, [Date], EntryToCopy.FunctionCategory, 0,
                                           0, 0, EntryToCopy.DepartmentTeamCode, EntryToCopy.ProductCode, Me._UserCode, "", EntryToCopy.AlertID, Nothing)

                End If

            End If

            Return Result

        End Function
        Public Function GetEmployeeTime(ByVal EmployeeCode As String, ByVal [Date] As String) As EmployeeTime

            Dim DateDate As Date = CType(CType([Date], Date).ToShortDateString(), Date)

            GetEmployeeTime = (From EmployeeTime In Me._DataEntities.EmployeeTimes
                               Where EmployeeTime.EmployeeCode = EmployeeCode _
                               AndAlso EmployeeTime.Date = DateDate).SingleOrDefault()

        End Function
        Public Function GetHoursThisWeek(ByVal EmployeeCode As String) As Nullable(Of Decimal)

            Dim TotalHours As Decimal = CType(0.0, Decimal)
            Dim StartDate As Date
            Dim EndDate As Date
            Dim TodaysDate As Date = Now().Date
            Dim StartWeekOn As DayOfWeek = DayOfWeek.Sunday

            Try

                If TodaysDate.DayOfWeek = StartWeekOn Then

                    StartDate = TodaysDate

                Else

                    StartDate = TodaysDate.AddDays(-TodaysDate.DayOfWeek + StartWeekOn)

                End If

                EndDate = StartDate.AddDays(6)

            Catch ex As Exception

                Return 0

            End Try
            Try

                Return Me.GetHoursForDateRange(EmployeeCode, StartDate, EndDate)

            Catch ex As Exception

                Return 0

            End Try

        End Function
        Public Function GetHoursForDay(ByVal EmployeeCode As String, ByVal [Date] As String) As Nullable(Of Decimal)

            Try

                Dim DateDate As Date = CType(CType([Date], Date).ToShortDateString(), Date)

                Return Me.GetHoursForDateRange(EmployeeCode, DateDate, DateDate)

            Catch ex As Exception

                AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
                Return 0

            End Try

        End Function
        Private Function GetHoursForDateRange(ByVal EmployeeCode As String, ByVal StartDate As Date, ByVal EndDate As Date) As Nullable(Of Decimal)

            Dim TotalHours As Nullable(Of Decimal) = CType(0.0, Decimal)
            Dim TotalHoursNP As Nullable(Of Decimal) = CType(0.0, Decimal)

            Try

                TotalHours = (From ETD In Me._DataEntities.EmployeeTimeDetails
                              Where ETD.EmployeeTime.Date >= StartDate And ETD.EmployeeTime.Date <= EndDate _
                              AndAlso ETD.EmployeeTime.EmployeeCode = EmployeeCode
                              Select ETD.Hours).Sum()

                If TotalHours Is Nothing Then

                    TotalHours = 0

                End If

            Catch ex As Exception
                If ex.Message.Contains("materialized value is null") = False Then
                    AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
                End If
                TotalHours = 0
            End Try
            Try

                TotalHoursNP = (From ETD In Me._DataEntities.EmployeeTimeIndirects
                                Where ETD.EmployeeTime.Date >= StartDate And ETD.EmployeeTime.Date <= EndDate _
                             AndAlso ETD.EmployeeTime.EmployeeCode = EmployeeCode
                                Select ETD.Hourse).Sum()

                If TotalHoursNP Is Nothing Then

                    TotalHoursNP = 0

                End If

            Catch ex As Exception
                If ex.Message.Contains("materialized value is null") = False Then
                    AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
                End If
                TotalHoursNP = 0
            End Try


            'need to add in NP time or split that into separate?

            Return TotalHours + TotalHoursNP

        End Function

        Public Function GetTimeCategories(ByVal SearchValue As String) As IQueryable(Of TimeCategory)

            Dim query As IQueryable(Of TimeCategory)

            query = (From tc In Me._DataEntities.TimeCategories
                     Where tc.IsInactive Is Nothing OrElse tc.IsInactive = 0
                     Order By tc.Description)

            SearchValue = SearchValue.Trim()

            If SearchValue <> "" Then

                query = query.Where(Function(TimeCategory) TimeCategory.Description.ToUpper().Contains(SearchValue.ToUpper()))

            End If

            Return query

        End Function
        Public Function GetTimeEntry(ByVal EmployeeTimeID As Integer, ByVal EmployeeTimeDetailID As Integer) As TimeEntry

            GetTimeEntry = (From TimeEntry In Me._DataEntities.GetTimeEntry("", Nothing, Nothing, "", "", EmployeeTimeID, EmployeeTimeDetailID)).FirstOrDefault()

        End Function

        Public Function GetTimesheetDay(ByVal EmployeeCode As String, ByVal [Date] As String, ByVal Filter As String, ByVal Sort As String, ByVal Skip As Integer, ByVal Take As Integer) As IQueryable(Of TimeEntry)

            Dim DateDate As Date = CType(CType([Date], Date).ToShortDateString(), Date)

            GetTimesheetDay = (From TimeEntry In Me._DataEntities.GetTimeEntry(EmployeeCode, DateDate, DateDate, "", _UserCode, 0, 0)
                               Order By TimeEntry.EmployeeDate, TimeEntry.JobNumber, TimeEntry.JobComponentNumber Descending, TimeEntry.FunctionCategory).Skip(Skip).Take(Take)

        End Function
        Public Function GetTimesheetMonth(ByVal EmployeeCode As String, ByVal [Date] As String) As IQueryable(Of TimeEntry)

            Dim DateDate As Date = CType(CType([Date], Date).ToShortDateString(), Date)
            Dim StartDate As Date = New DateTime(DateDate.Year, DateDate.Month, 1)
            Dim EndDate As Date = StartDate.AddMonths(1).AddDays(-1)

            GetTimesheetMonth = (From TimeEntry In Me._DataEntities.GetTimeEntry(EmployeeCode, StartDate, EndDate, "", "SYSADM", 0, 0)
                                 Order By TimeEntry.JobNumber, TimeEntry.JobComponentNumber Descending, TimeEntry.FunctionCategory, TimeEntry.EmployeeDate)

        End Function
        Public Function GetTimesheetWeek(ByVal EmployeeCode As String, ByVal [Date] As String) As IQueryable(Of TimeEntry)

            Dim StartWeekOn As DayOfWeek = DayOfWeek.Sunday
            Dim DateDate As Date = CType(CType([Date], Date).ToShortDateString(), Date)
            Dim StartDate As Date
            Dim EndDate As Date

            If DateDate.DayOfWeek = StartWeekOn Then

                StartDate = DateDate

            Else

                StartDate = DateDate.AddDays(-DateDate.DayOfWeek + StartWeekOn)

            End If

            EndDate = StartDate.AddDays(6)

            GetTimesheetWeek = (From TimeEntry In Me._DataEntities.GetTimeEntry(EmployeeCode, StartDate, EndDate, "", "SYSADM", 0, 0)
                                Order By TimeEntry.JobNumber, TimeEntry.JobComponentNumber Descending, TimeEntry.FunctionCategory, TimeEntry.EmployeeDate)

        End Function

        Public Function GetTimeSummary(ByVal EmployeeCode As String, ByVal Group As Short, ByVal [Date] As String, ByVal Filter As String, ByVal Sort As String, ByVal Skip As Integer, ByVal Take As Integer) As IEnumerable(Of TimeSummary)

            Dim DateDate As Date = CType(CType([Date], Date).ToShortDateString(), Date)
            GetTimeSummary = (From TS In Me._DataEntities.GetTimeSummaries(EmployeeCode, Group, DateDate).Skip(Skip).Take(Take))

        End Function

        Public Function GetTimeTemplate(ByVal EmployeeTimeTemplateID As Integer) As EmployeeTimeTemplate

            GetTimeTemplate = (From ETT In Me._DataEntities.EmployeeTimeTemplates
                               Where ETT.ID = EmployeeTimeTemplateID).FirstOrDefault()

        End Function
        Public Function GetTimeTemplates(ByVal EmployeeCode As String, ByVal Filter As String, ByVal Sort As String, ByVal Skip As Integer, ByVal Take As Integer) As IEnumerable(Of TimeTemplate)

            GetTimeTemplates = (From TT In Me._DataEntities.GetTimeTemplates(EmployeeCode, "").Skip(Skip).Take(Take))

        End Function

        Public Function IsApprovalActive(ByVal EmployeeCode As String) As Boolean

            Dim IsActive As Boolean = False

            IsActive = Me._DataEntities.Database.SqlQuery(Of Short)("SELECT ISNULL(TIME_APPR_ACTIVE, 0) FROM AGENCY WITH(NOLOCK);").FirstOrDefault() = 1

            If IsActive = True Then

                Dim IsNotRequiredForEmployee As Boolean = False

                IsNotRequiredForEmployee = Me._DataEntities.Database.SqlQuery(Of Boolean)(String.Format("SELECT ISNULL(TS_APPR_FLAG, 0) FROM EMPLOYEE WITH(NOLOCK) WHERE EMP_CODE = '{0}';", EmployeeCode)).FirstOrDefault() = True

                If IsNotRequiredForEmployee = True Then

                    IsActive = False

                End If

            End If

            Return IsActive

        End Function
        Public Function IsTimesheetPostPeriodClosed(ByVal [Date] As String) As Boolean

            Dim PostPeriodClosed As Boolean = False

            If IsDate([Date]) = True Then

                Dim DateDate As Date = CType(CType([Date], Date).ToShortDateString(), Date)
                Dim CheckTimesheetPostPeriod As Boolean = False

                CheckTimesheetPostPeriod = (From Agency In Me._DataEntities.Agencies
                                            Where Agency.TS_PPERIOD_CHK = 1).Count() > 0

                If CheckTimesheetPostPeriod = True Then

                    PostPeriodClosed = (From PostPeriod In Me._DataEntities.PostPeriods
                                        Where PostPeriod.StartDate <= DateDate _
                                        AndAlso PostPeriod.EndDate >= DateDate _
                                        AndAlso (PostPeriod.TECurrentMonth Is Nothing OrElse PostPeriod.TECurrentMonth = "C")).Count = 0

                End If

            End If

            Return PostPeriodClosed

        End Function
        Public Function SaveTimeEntry(ByVal EmployeeTimeID As Integer,
                                      ByVal EmployeeTimeDetailID As Integer,
                                      ByVal EmployeeCode As String,
                                      ByVal EmployeeDate As String,
                                      ByVal FunctionOrCategory As String,
                                      ByVal EmployeeHours As String,
                                      ByVal JobNumber As Integer,
                                      ByVal JobComponentNumber As Short,
                                      ByVal DepartmentTeam As String,
                                      ByVal ProductCategory As String,
                                      ByVal UserCode As String,
                                      ByVal Comments As String,
                                      ByVal AlertID As Integer?,
                                      ByVal TaskSequenceNumber As Short?) As SaveTimeEntryResult

            'Dim Sec As New AdvantageMobile.Security.Methods(Me._DataEntities)
            Dim Result As New SaveTimeEntryResult

            Dim Message As String = ""
            Dim Saved As Boolean = False
            Dim TaskCode As String = String.Empty

            Try

                Dim Execute As Boolean = True
                Dim ErrorMessageObjectParameter As ObjectParameter = Nothing

                Dim DateEmployeeDate As Nullable(Of Date)
                Dim DecimalEmployeeHours As Decimal = CDec(0.0)

                DateEmployeeDate = Nothing
                ErrorMessageObjectParameter = New ObjectParameter("error_text", "")

                'Wouldn't work when trying to pass date datatype to service, but works as string
                If IsDate(EmployeeDate) = True Then

                    DateEmployeeDate = CDate(CDate(EmployeeDate).ToShortDateString())

                Else

                    Message = "Invalid date"
                    Execute = False

                End If

                'Wouldn't work when trying to pass decimal datatype to service, but works as string
                If IsNumeric(EmployeeHours) = True Then

                    DecimalEmployeeHours = CDec(EmployeeHours)

                Else

                    Message = "Invalid hours"
                    Execute = False

                End If

                If Execute = True Then

                    Try

                        If (AlertID Is Nothing OrElse AlertID = 0) AndAlso (TaskSequenceNumber IsNot Nothing AndAlso TaskSequenceNumber > -1) AndAlso JobNumber > 0 AndAlso JobComponentNumber > 0 Then

                            Using DbContext = New AdvantageFramework.Database.DbContext(_DataServiceUser.ConnectionString, _DataServiceUser.UserCode)

                                Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing

                                Alert = (From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.Alert)
                                         Where Entity.JobNumber = JobNumber And Entity.JobComponentNumber = JobComponentNumber And Entity.TaskSequenceNumber = TaskSequenceNumber And Entity.AlertLevel = "BRD"
                                         Select Entity).SingleOrDefault

                                If Alert IsNot Nothing Then

                                    AlertID = Alert.ID

                                End If

                            End Using

                        End If


                    Catch ex As Exception
                    End Try

                End If

                If Execute = True Then

                    Saved = AdvantageFramework.EmployeeTimesheet.SaveDay(_DataServiceUser.ConnectionString, _DataServiceUser.UserCode,
                                                                         EmployeeTimeID, EmployeeTimeDetailID,
                                                                         EmployeeCode, DateEmployeeDate,
                                                                         FunctionOrCategory, "", DecimalEmployeeHours,
                                                                         JobNumber, JobComponentNumber, DepartmentTeam,
                                                                         UserCode, Message, Comments,
                                                                         EmployeeTimeID, EmployeeTimeDetailID, AlertID, False)

                End If


            Catch ex As Exception
                Saved = False
                Message = ex.InnerException.Message.ToString()
                AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Finally

                If Message.Contains("SUCCESS") = True Then

                    Saved = True

                End If

                Result.FullText = Message

                If Message.Contains("|") = True Then

                    Dim ar() As String
                    ar = Message.Split(CType("|", Char))

                    Result.Message = ar(0).ToString()
                    Result.EmployeeTimeID = CType(ar(1), Integer)
                    Result.EmployeeTimeDetailID = CType(ar(2), Short)
                    Result.EmployeeHours = CType(ar(3), Decimal)

                    If ar.Length = 8 Then

                        Result.BillingRate = ar(4)
                        Result.NoBillFlag = ar(5)
                        Result.ErrorCode = ar(6)
                        Result.WarningMessage = ar(7)

                    End If

                Else

                    Result.Message = Message

                End If

                SaveTimeEntry = Result

            End Try

        End Function
        Public Function SubmitForApproval(ByVal EmployeeCode As String, ByVal EmployeeDate As Date, ByVal Approve As Boolean) As String

            Dim Message As String = "SUCCESS"
            Dim Proceed As Boolean = True

            If AdvantageFramework.Timesheet.HasStopWatch(Me._ConnectionString, EmployeeCode, EmployeeDate, EmployeeDate) = True Then

                Message = "STOPWATCH_RUNNING" '"You have a stopwatch running.  Please stop it before proceeding."
                Proceed = False

            End If
            If Proceed = True Then

                If AdvantageFramework.Timesheet.DayIsMissingComment(Me._ConnectionString, Me._UserCode, EmployeeCode, EmployeeDate) = True AndAlso Approve = True Then

                    Message = "MISSING_COMMENT" 'EmployeeDate.DayOfWeek.ToString() & " is missing comment(s) and cannot be submitted for approval."
                    Proceed = False

                End If

            End If
            If Proceed = True Then

                Dim s As New AdvantageFramework.Security.Session(AdvantageFramework.Security.Application.Webvantage, Me._ConnectionString, Me._UserCode, 0, Me._ConnectionString)

                If s IsNot Nothing Then

                    s.User.EmployeeCode = EmployeeCode

                    If AdvantageFramework.EmployeeTimesheet.SubmitForApproval(s, EmployeeCode, EmployeeDate, Approve, True, Message) = True Then

                        Message = "SUCCESS"

                    Else

                        If Message.Trim() = "" Then Message = "ERROR"

                    End If

                End If

            End If

            Return Message

        End Function
        Function DeleteTimeEntry(ByVal EmployeeTimeID As Integer, ByVal EmployeeTimeDetailID As Integer, ByVal TimeType As String) As String

            Dim ErrStr As String = ""

            Try
                Dim ErrTxt As New ObjectParameter("error_text", ErrStr)
                Me._DataEntities.DeleteTimeEntry(EmployeeTimeID, EmployeeTimeDetailID, TimeType, ErrTxt)

                If ErrTxt.Value IsNot Nothing Then

                    If ErrTxt.Value.ToString() = "" Then

                        ErrStr = "Success|" & EmployeeTimeID & "|" & EmployeeTimeDetailID

                    Else

                        ErrStr = ErrTxt.Value.ToString()

                    End If

                End If

            Catch ex As Exception

                AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
                ErrStr = ex.Message.ToString()

            Finally

                DeleteTimeEntry = ErrStr

            End Try

        End Function

        Sub New(ByVal DataSource As DataEntities, ByVal CurrentDataServiceUser As DataServiceUser)

            Me._DataEntities = DataSource
            Me._DataServiceUser = CurrentDataServiceUser
            Me._ConnectionString = CurrentDataServiceUser.ConnectionString
            Me._UserCode = Me._DataServiceUser.UserCode

        End Sub

#End Region

    End Class

End Namespace
