Imports System.Data.SqlClient
Imports System.Web
Imports AdvantageFramework.Timesheet.Methods
Imports System.Threading

Namespace Controller.Employee
    <Serializable> Public Class TimesheetMvcController
        Inherits AdvantageFramework.Controller.BaseController

#Region " Constants "

        Public Const AppVarKey As String = "NewTimesheet"

#End Region

#Region " Enum "

        <Serializable()>
        Public Enum Navigation

            [None] = 0
            [Today] = 1
            [Previous] = 2
            [Next] = 3

        End Enum
        <Serializable()>
        Public Enum CopyToType

            EntireTimesheet = 0
            SelectedRows = 1

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

#Region " For actual time sheet "
        Public Function GetTimeSheetGrid(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                         ByVal EmployeeCode As String,
                                         ByVal StartDate As Date,
                                         ByVal DaysToGet As Integer,
                                         ByVal Sort As TimesheetSort,
                                         ByVal GroupBy As TimesheetGroupBy,
                                         ByVal UserSettings As ViewModels.Employee.Timesheet.Settings,
                                         ByRef ErrorMessage As String)

            Dim TimeSheet As New ViewModels.Employee.Timesheet.TimesheetViewModel
            Dim Days As Generic.List(Of EmployeeTimeDay) = Nothing
            Dim Day As EmployeeTimeDay = Nothing

            TimeSheet = GetTimeSheet(DbContext, EmployeeCode, StartDate, DaysToGet, Sort, GroupBy, UserSettings, ErrorMessage)

            If TimeSheet IsNot Nothing Then

                Days = LoadEmployeeTimeIDs(DbContext, EmployeeCode, StartDate, DateAdd(DateInterval.Day, DaysToGet, StartDate))

                For Each Line In TimeSheet.Lines

                    If Line.Entries Is Nothing Then Line.Entries = New List(Of ViewModels.Employee.Timesheet.TimesheetEntryViewModel)

                    If Line.Entries.Count < DaysToGet Then

                        Dim Entry As ViewModels.Employee.Timesheet.TimesheetEntryViewModel = Nothing
                        Dim DateCounter As Integer = 0
                        Dim EntryDate As Date = StartDate

                        For i As Integer = 0 To DaysToGet - 1

                            DateCounter = i
                            EntryDate = DateAdd(DateInterval.Day, DateCounter, StartDate)
                            Day = Nothing
                            Entry = Nothing
                            Entry = (From Entity In Line.Entries
                                     Where Entity.Date = EntryDate
                                     Select Entity).SingleOrDefault

                            If Entry Is Nothing Then

                                If Days IsNot Nothing Then

                                    Try

                                        Day = (From Entity In Days
                                               Where Entity.EmployeeDate = EntryDate And Entity.EmployeeDate = EntryDate
                                               Select Entity).SingleOrDefault

                                    Catch ex As Exception
                                        Day = Nothing
                                    End Try

                                End If

                                Entry = New ViewModels.Employee.Timesheet.TimesheetEntryViewModel

                                Entry.TimeType = Line.TimeType
                                Entry.Date = EntryDate
                                Entry.CannotEditDueToProcessingControl = Line.CannotEditDueToProcessingControl
                                Entry.CommentsRequired = Line.ClientCommentRequired
                                Entry.AlertID = Line.AlertID
                                Entry.AlertSubject = Line.AlertSubject
                                Entry.NonEditMessage = Line.NonEditMessage
                                Entry.CanDelete = True
                                Entry.LineID = Line.LineID
                                Entry.WebDataKey = SetWebWebDataKey(EmployeeCode, Line.FunctionCategory, Line.DepartmentTeamCode, Line.JobNumber,
                                                                    Line.JobComponentNumber, 0, 0, EntryDate, Entry.TimeType, 0, Entry.CommentsRequired,
                                                                    False, 0, Entry.AlertID)

                                If Day IsNot Nothing AndAlso Day.EmployeeDate = Entry.Date Then

                                    Entry.EmployeeTimeID = Day.EmployeeTimeID

                                End If

                                Line.Entries.Add(Entry)

                            End If

                        Next

                        Line.Entries = Line.Entries.OrderBy(Function(p) p.Date).ToList

                    End If

                Next

            End If

            Return TimeSheet

        End Function
        Public Function GetTimeSheet(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                     ByVal EmployeeCode As String,
                                     ByVal StartDate As Date,
                                     ByVal DaysToGet As Integer,
                                     ByVal Sort As TimesheetSort,
                                     ByVal GroupBy As TimesheetGroupBy,
                                     ByVal UserSettings As ViewModels.Employee.Timesheet.Settings,
                                     ByRef ErrorMessage As String) As AdvantageFramework.ViewModels.Employee.Timesheet.TimesheetViewModel

            Dim ThisTimeSheet As New ViewModels.Employee.Timesheet.TimesheetViewModel
            Dim EndDate As Date = DateAdd(DateInterval.Day, DaysToGet - 1, StartDate)
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim DataReader As System.Data.SqlClient.SqlDataReader
            Dim ThisSqlCommand As New System.Data.SqlClient.SqlCommand()
            Dim EmployeeCodeSqlParameter As New System.Data.SqlClient.SqlParameter("@emp_code", SqlDbType.VarChar, 6)
            Dim StartDateSqlParameter As New System.Data.SqlClient.SqlParameter("@StartDate", SqlDbType.SmallDateTime)
            Dim EndDateSqlParameter As New System.Data.SqlClient.SqlParameter("@EndDate", SqlDbType.SmallDateTime)
            Dim SortColumnSqlParameter As New System.Data.SqlClient.SqlParameter("@SortColumn", SqlDbType.VarChar, 35)
            Dim UserCodeSqlParameter As New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)

            Dim RepeatRowForAllDays As Boolean = False
            Dim SingleDayStartOfWeek As Date = Nothing
            Dim SingleDayEndOfWeek As Date = Nothing
            Dim SingleDayDayToGet As Date = StartDate

            ThisTimeSheet.DaysToDisplay = DaysToGet

            If DaysToGet = 1 AndAlso UserSettings IsNot Nothing AndAlso
               UserSettings.RepeatRowForAllDays IsNot Nothing AndAlso UserSettings.RepeatRowForAllDays = True Then

                RepeatRowForAllDays = True

            End If
            If RepeatRowForAllDays = True Then

                SingleDayStartOfWeek = AdvantageFramework.EmployeeTimesheet.FirstDayOfWeek(StartDate, UserSettings, 7)
                SingleDayEndOfWeek = SingleDayStartOfWeek.AddDays(6)

                StartDateSqlParameter.Value = SingleDayStartOfWeek
                EndDateSqlParameter.Value = SingleDayEndOfWeek

            Else

                StartDateSqlParameter.Value = StartDate
                EndDateSqlParameter.Value = EndDate

            End If

            EmployeeCodeSqlParameter.Value = EmployeeCode

            ThisSqlCommand.Parameters.Add(EmployeeCodeSqlParameter)
            ThisSqlCommand.Parameters.Add(StartDateSqlParameter)
            ThisSqlCommand.Parameters.Add(EndDateSqlParameter)

            Select Case Sort
                Case TimesheetSort.NewestFirst

                    SortColumnSqlParameter.Value = System.DBNull.Value

                Case TimesheetSort.JobComponent, TimesheetSort.JobAsc, TimesheetSort.JobDesc

                    SortColumnSqlParameter.Value = "JOB_NUMBER"

                Case TimesheetSort.Client, TimesheetSort.ClientAsc, TimesheetSort.ClientDesc

                    SortColumnSqlParameter.Value = "CL_CODE"

                Case TimesheetSort.Division

                    SortColumnSqlParameter.Value = "DIV_CODE"

                Case TimesheetSort.Product

                    SortColumnSqlParameter.Value = "PRD_CODE"

                Case TimesheetSort.FunctionCategory

                    SortColumnSqlParameter.Value = "FNC_CAT"

                Case TimesheetSort.DepartmentTeam

                    SortColumnSqlParameter.Value = "DP_TM_CODE"

                Case TimesheetSort.Date

                    SortColumnSqlParameter.Value = "EMP_DATE"

                Case Else

                    SortColumnSqlParameter.Value = System.DBNull.Value

            End Select

            ThisSqlCommand.Parameters.Add(SortColumnSqlParameter)
            UserCodeSqlParameter.Value = Me.Session.UserCode
            ThisSqlCommand.Parameters.Add(UserCodeSqlParameter)

            Using MyConn As New System.Data.SqlClient.SqlConnection(Me.Session.ConnectionString)

                MyConn.Open()

                Try

                    ThisSqlCommand.CommandType = CommandType.StoredProcedure
                    ThisSqlCommand.CommandText = "usp_wv_ts_GetTimeSheet"
                    ThisSqlCommand.Connection = MyConn

                    DataReader = ThisSqlCommand.ExecuteReader()

                    ThisTimeSheet.EmployeeCode = EmployeeCode
                    ThisTimeSheet.StartDate = StartDate
                    ThisTimeSheet.EndDate = EndDate

                    If DataReader IsNot Nothing AndAlso DataReader.HasRows = True Then

                        Dim ExistingLine As ViewModels.Employee.Timesheet.TimesheetLineViewModel = Nothing
                        Dim ExistingEntry As ViewModels.Employee.Timesheet.TimesheetEntryViewModel = Nothing
                        Dim ExistingDay As ViewModels.Employee.Timesheet.TimesheetDayViewModel = Nothing
                        Dim ThisEntry As ViewModels.Employee.Timesheet.TimesheetEntryViewModel = Nothing
                        Dim RowInfo As AdvantageFramework.ViewModels.Employee.Timesheet.RowInfoViewModel = Nothing
                        Dim DayProcessed As Boolean = False
                        Dim LineID As String = String.Empty
                        Dim DayPostPeriodIsClosed As Boolean = False
                        Dim CompareStringClientCode As String = String.Empty
                        Dim CompareStringDivisionCode As String = String.Empty
                        Dim CompareStringProductCode As String = String.Empty
                        Dim CompareStringFunctionCategoryCode As String = String.Empty
                        Dim CompareStringDepartmentTeamCode As String = String.Empty
                        Dim CompareStringJobNumber As Integer = 0
                        Dim CompareStringJobComponentNumber As Integer = 0
                        Dim CompareStringJobProcessControl As Integer = -1
                        Dim CompareStringAlertID As Integer = 0
                        Dim HasComments As Boolean = False

                        Do While DataReader.Read

                            ThisEntry = Nothing
                            DayProcessed = False
                            DayPostPeriodIsClosed = False
                            HasComments = False
                            CompareStringClientCode = String.Empty
                            CompareStringDivisionCode = String.Empty
                            CompareStringProductCode = String.Empty
                            CompareStringFunctionCategoryCode = String.Empty
                            CompareStringDepartmentTeamCode = String.Empty
                            CompareStringJobNumber = 0
                            CompareStringJobComponentNumber = 0
                            CompareStringJobProcessControl = -1
                            CompareStringAlertID = 0

                            ThisEntry = New ViewModels.Employee.Timesheet.TimesheetEntryViewModel

                            ThisEntry.CanDelete = False

                            If DataReader.IsDBNull(DataReader.GetOrdinal("EmployeeTimeID")) = False Then ThisEntry.EmployeeTimeID = DataReader.GetValue(DataReader.GetOrdinal("EmployeeTimeID"))
                            If DataReader.IsDBNull(DataReader.GetOrdinal("EmployeeTimeDetailID")) = False Then ThisEntry.EmployeeTimeDetailID = DataReader.GetValue(DataReader.GetOrdinal("EmployeeTimeDetailID"))
                            If DataReader.IsDBNull(DataReader.GetOrdinal("EmployeeHours")) = False Then ThisEntry.Hours = CDbl(DataReader.GetSqlDecimal(DataReader.GetOrdinal("EmployeeHours")).Value)
                            If DataReader.IsDBNull(DataReader.GetOrdinal("TimeType")) = False Then ThisEntry.TimeType = DataReader.GetString(DataReader.GetOrdinal("TimeType")).ToString()
                            If DataReader.IsDBNull(DataReader.GetOrdinal("EditFlag")) = False Then ThisEntry.EditFlag = DataReader.GetValue(DataReader.GetOrdinal("EditFlag"))
                            If DataReader.IsDBNull(DataReader.GetOrdinal("EmployeeDate")) = False Then ThisEntry.Date = DataReader.GetDateTime(DataReader.GetOrdinal("EmployeeDate"))
                            If DataReader.IsDBNull(DataReader.GetOrdinal("Comments")) = False Then ThisEntry.Comments = DataReader.GetString(DataReader.GetOrdinal("Comments")).ToString()
                            If DataReader.GetValue(DataReader.GetOrdinal("IsLockedByProcessControl")) = 1 Then ThisEntry.CannotEditDueToProcessingControl = True
                            If DataReader.GetValue(DataReader.GetOrdinal("HasStopwatch")) = 1 Then ThisEntry.HasStopwatch = True
                            If DataReader.IsDBNull(DataReader.GetOrdinal("CommentsRequired")) = False Then ThisEntry.CommentsRequired = DataReader.GetValue(DataReader.GetOrdinal("CommentsRequired")) = 1
                            If DataReader.IsDBNull(DataReader.GetOrdinal("DayPostPeriodClosed")) = False Then DayPostPeriodIsClosed = DataReader.GetValue(DataReader.GetOrdinal("DayPostPeriodClosed"))
                            If DataReader.IsDBNull(DataReader.GetOrdinal("AlertID")) = False Then ThisEntry.AlertID = DataReader.GetValue(DataReader.GetOrdinal("AlertID"))
                            If DataReader.IsDBNull(DataReader.GetOrdinal("AlertSubject")) = False Then ThisEntry.AlertSubject = DataReader.GetValue(DataReader.GetOrdinal("AlertSubject"))
                            Try
                                If DataReader.IsDBNull(DataReader.GetOrdinal("NonEditMessage")) = False Then ThisEntry.NonEditMessage = DataReader.GetValue(DataReader.GetOrdinal("NonEditMessage"))
                            Catch ex As Exception
                            End Try
                            If String.IsNullOrWhiteSpace(ThisEntry.Comments) = False Then HasComments = True

                            If DayPostPeriodIsClosed = False AndAlso ThisEntry.CannotEditDueToProcessingControl = False AndAlso ThisEntry.HasStopwatch = False Then

                                If ThisEntry.EditFlag = TimesheetEditType.Edit OrElse ThisEntry.EditFlag = TimesheetEditType.Denied Then

                                    ThisEntry.CanDelete = True

                                End If

                            End If

                            'let zero hours be deleted in all instances except stopwatch
                            If ThisEntry.HasStopwatch = False AndAlso ThisEntry.Hours = 0 Then ThisEntry.CanDelete = True

                            If DataReader.IsDBNull(DataReader.GetOrdinal("ClientCode")) = False Then CompareStringClientCode = DataReader.GetSqlString(DataReader.GetOrdinal("ClientCode")).ToString()
                            If DataReader.IsDBNull(DataReader.GetOrdinal("DivisionCode")) = False Then CompareStringDivisionCode = DataReader.GetSqlString(DataReader.GetOrdinal("DivisionCode")).ToString()
                            If DataReader.IsDBNull(DataReader.GetOrdinal("ProductCode")) = False Then CompareStringProductCode = DataReader.GetSqlString(DataReader.GetOrdinal("ProductCode")).ToString()
                            If DataReader.IsDBNull(DataReader.GetOrdinal("FunctionCategory")) = False Then CompareStringFunctionCategoryCode = DataReader.GetSqlString(DataReader.GetOrdinal("FunctionCategory")).ToString()
                            If DataReader.IsDBNull(DataReader.GetOrdinal("DepartmentTeamCode")) = False Then CompareStringDepartmentTeamCode = DataReader.GetSqlString(DataReader.GetOrdinal("DepartmentTeamCode")).ToString()
                            If DataReader.IsDBNull(DataReader.GetOrdinal("JobNumber")) = False Then CompareStringJobNumber = DataReader.GetValue(DataReader.GetOrdinal("JobNumber"))
                            If DataReader.IsDBNull(DataReader.GetOrdinal("JobComponentNumber")) = False Then CompareStringJobComponentNumber = DataReader.GetValue(DataReader.GetOrdinal("JobComponentNumber"))
                            If DataReader.IsDBNull(DataReader.GetOrdinal("JobProcessControl")) = False Then CompareStringJobProcessControl = DataReader.GetValue(DataReader.GetOrdinal("JobProcessControl"))
                            If DataReader.IsDBNull(DataReader.GetOrdinal("AlertID")) = False Then CompareStringAlertID = DataReader.GetValue(DataReader.GetOrdinal("AlertID"))

                            ThisEntry.WebDataKey = SetWebWebDataKey(EmployeeCode, CompareStringFunctionCategoryCode, CompareStringDepartmentTeamCode,
                                                                    CompareStringJobNumber, CompareStringJobComponentNumber, ThisEntry.EmployeeTimeID,
                                                                    ThisEntry.EmployeeTimeDetailID, ThisEntry.Date, ThisEntry.TimeType,
                                                                    CType(ThisEntry.EditFlag, Integer), ThisEntry.CommentsRequired, HasComments,
                                                                    ThisEntry.Hours, ThisEntry.AlertID)

                            RowInfo = New ViewModels.Employee.Timesheet.RowInfoViewModel
                            RowInfo.ClientCode = CompareStringClientCode
                            RowInfo.DivisionCode = CompareStringDivisionCode
                            RowInfo.ProductCode = CompareStringProductCode
                            RowInfo.JobNumber = CompareStringJobNumber
                            RowInfo.JobComponentNumber = CompareStringJobComponentNumber
                            RowInfo.FunctionCategoryCode = CompareStringFunctionCategoryCode
                            RowInfo.DepartmentTeamCode = CompareStringDepartmentTeamCode
                            RowInfo.JobProcessControl = CompareStringJobProcessControl
                            RowInfo.AlertID = ThisEntry.AlertID

                            LineID = RowInfo.ToArrayString

                            RowInfo = Nothing

                            ThisEntry.LineID = LineID

                            For Each Line In ThisTimeSheet.Lines

                                If Line.LineID = ThisEntry.LineID Then

                                    ExistingEntry = (From Entity In Line.Entries
                                                     Where Entity.Date.ToShortDateString = ThisEntry.Date.ToShortDateString).FirstOrDefault

                                    If ExistingEntry Is Nothing Then

                                        Line.Entries.Add(ThisEntry)
                                        DayProcessed = True
                                        Exit For

                                    End If

                                End If

                            Next

                            If DayProcessed = False Then

                                Dim DuplicateLine As New ViewModels.Employee.Timesheet.TimesheetLineViewModel

                                DuplicateLine.LineID = LineID
                                DuplicateLine.JobProcessControl = -1

                                If DataReader.IsDBNull(DataReader.GetOrdinal("ClientCode")) = False Then DuplicateLine.ClientCode = DataReader.GetSqlString(DataReader.GetOrdinal("ClientCode")).ToString()
                                If DataReader.IsDBNull(DataReader.GetOrdinal("DivisionCode")) = False Then DuplicateLine.DivisionCode = DataReader.GetSqlString(DataReader.GetOrdinal("DivisionCode")).ToString()
                                If DataReader.IsDBNull(DataReader.GetOrdinal("ProductCode")) = False Then DuplicateLine.ProductCode = DataReader.GetSqlString(DataReader.GetOrdinal("ProductCode")).ToString()
                                If DataReader.IsDBNull(DataReader.GetOrdinal("JobNumber")) = False Then DuplicateLine.JobNumber = DataReader.GetValue(DataReader.GetOrdinal("JobNumber"))
                                If DataReader.IsDBNull(DataReader.GetOrdinal("JobComponentNumber")) = False Then DuplicateLine.JobComponentNumber = DataReader.GetValue(DataReader.GetOrdinal("JobComponentNumber"))
                                If DataReader.IsDBNull(DataReader.GetOrdinal("JobDescription")) = False Then DuplicateLine.JobDescription = DataReader.GetSqlString(DataReader.GetOrdinal("JobDescription")).Value
                                If DataReader.IsDBNull(DataReader.GetOrdinal("JobComponentDescription")) = False Then DuplicateLine.JobComponentDescription = DataReader.GetSqlString(DataReader.GetOrdinal("JobComponentDescription")).ToString()
                                If DataReader.IsDBNull(DataReader.GetOrdinal("ProductCategoryCode")) = False Then DuplicateLine.ProductCategory = DataReader.GetSqlString(DataReader.GetOrdinal("ProductCategoryCode")).ToString()
                                If DataReader.IsDBNull(DataReader.GetOrdinal("FunctionCategory")) = False Then DuplicateLine.FunctionCategory = DataReader.GetSqlString(DataReader.GetOrdinal("FunctionCategory")).ToString()
                                If DataReader.IsDBNull(DataReader.GetOrdinal("FunctionCategoryDescription")) = False Then DuplicateLine.FunctionCategoryDescription = DataReader.GetSqlString(DataReader.GetOrdinal("FunctionCategoryDescription")).ToString()
                                If DataReader.IsDBNull(DataReader.GetOrdinal("DepartmentTeamCode")) = False Then DuplicateLine.DepartmentTeamCode = DataReader.GetSqlString(DataReader.GetOrdinal("DepartmentTeamCode")).ToString()
                                If DataReader.IsDBNull(DataReader.GetOrdinal("ClientName")) = False Then DuplicateLine.ClientName = DataReader.GetSqlString(DataReader.GetOrdinal("ClientName")).ToString()
                                If DataReader.IsDBNull(DataReader.GetOrdinal("DivisionName")) = False Then DuplicateLine.DivisionName = DataReader.GetSqlString(DataReader.GetOrdinal("DivisionName")).ToString()
                                If DataReader.IsDBNull(DataReader.GetOrdinal("ProductDescription")) = False Then DuplicateLine.ProductDescription = DataReader.GetSqlString(DataReader.GetOrdinal("ProductDescription")).ToString()
                                If DataReader.IsDBNull(DataReader.GetOrdinal("NonEditMessage")) = False Then DuplicateLine.NonEditMessage = DataReader.GetSqlString(DataReader.GetOrdinal("NonEditMessage")).ToString()
                                If DuplicateLine.NonEditMessage.ToLower.Contains("does not allow editing") Then DuplicateLine.CannotEditDueToProcessingControl = True
                                If DataReader.IsDBNull(DataReader.GetOrdinal("JobProcessControl")) = False Then DuplicateLine.JobProcessControl = DataReader.GetValue(DataReader.GetOrdinal("JobProcessControl"))
                                If DataReader.IsDBNull(DataReader.GetOrdinal("TimeType")) = False Then DuplicateLine.TimeType = DataReader.GetString(DataReader.GetOrdinal("TimeType")).ToString()
                                If DataReader.IsDBNull(DataReader.GetOrdinal("ClientCommentRequired")) = False Then DuplicateLine.ClientCommentRequired = CType(DataReader.GetValue(DataReader.GetOrdinal("ClientCommentRequired")), Boolean)
                                If DataReader.IsDBNull(DataReader.GetOrdinal("Quoted")) = False Then DuplicateLine.QuotedAmount = CType(DataReader.GetValue(DataReader.GetOrdinal("Quoted")), Decimal)
                                If DataReader.IsDBNull(DataReader.GetOrdinal("QuotedHours")) = False Then DuplicateLine.QuotedHours = CType(DataReader.GetValue(DataReader.GetOrdinal("QuotedHours")), Decimal)
                                If DataReader.IsDBNull(DataReader.GetOrdinal("Actual")) = False Then DuplicateLine.ActualAmount = CType(DataReader.GetValue(DataReader.GetOrdinal("Actual")), Decimal)
                                If DataReader.IsDBNull(DataReader.GetOrdinal("ActualHours")) = False Then DuplicateLine.ActualHours = CType(DataReader.GetValue(DataReader.GetOrdinal("ActualHours")), Decimal)
                                If DataReader.IsDBNull(DataReader.GetOrdinal("IsOverThreshold")) = False Then DuplicateLine.IsOverThreshold = DataReader.GetValue(DataReader.GetOrdinal("IsOverThreshold"))
                                If DataReader.IsDBNull(DataReader.GetOrdinal("ProgressIsShowingTrafficHours")) = False Then DuplicateLine.ProgressIsShowingTrafficHours = DataReader.GetValue(DataReader.GetOrdinal("ProgressIsShowingTrafficHours"))
                                If DataReader.IsDBNull(DataReader.GetOrdinal("Threshold")) = False Then DuplicateLine.Threshold = DataReader.GetValue(DataReader.GetOrdinal("Threshold"))
                                If DataReader.IsDBNull(DataReader.GetOrdinal("AlertID")) = False Then DuplicateLine.AlertID = DataReader.GetValue(DataReader.GetOrdinal("AlertID"))
                                If DataReader.IsDBNull(DataReader.GetOrdinal("AlertSubject")) = False Then DuplicateLine.AlertSubject = DataReader.GetValue(DataReader.GetOrdinal("AlertSubject"))

                                DuplicateLine.Entries.Add(ThisEntry)
                                ThisTimeSheet.Lines.Add(DuplicateLine)

                            End If

                            ExistingDay = Nothing
                            ExistingDay = (From Entity In ThisTimeSheet.Days
                                           Where Entity.Date = ThisEntry.Date).FirstOrDefault

                            If ExistingDay Is Nothing Then

                                ExistingDay = New ViewModels.Employee.Timesheet.TimesheetDayViewModel

                                ExistingDay.CanEdit = True
                                ExistingDay.Date = ThisEntry.Date

                                If DataReader.IsDBNull(DataReader.GetOrdinal("DayIsDenied")) = False Then ExistingDay.IsDenied = DataReader.GetValue(DataReader.GetOrdinal("DayIsDenied"))
                                If DataReader.IsDBNull(DataReader.GetOrdinal("DayIsApproved")) = False Then ExistingDay.IsApproved = DataReader.GetValue(DataReader.GetOrdinal("DayIsApproved"))
                                If DataReader.IsDBNull(DataReader.GetOrdinal("DayIsPendingApproval")) = False Then ExistingDay.IsPendingApproval = DataReader.GetValue(DataReader.GetOrdinal("DayIsPendingApproval"))
                                If DataReader.IsDBNull(DataReader.GetOrdinal("DayPostPeriodClosed")) = False Then ExistingDay.PostPeriodIsClosed = DataReader.GetValue(DataReader.GetOrdinal("DayPostPeriodClosed"))
                                If ExistingDay.IsApproved = True OrElse ExistingDay.IsPendingApproval = True OrElse ExistingDay.PostPeriodIsClosed = True Then ExistingDay.CanEdit = False

                                ThisTimeSheet.Days.Add(ExistingDay)

                            End If
                            If ExistingDay IsNot Nothing Then

                                ExistingDay.Entries.Add(ThisEntry)

                            End If
                            If ThisTimeSheet.IsMissingComments Is Nothing OrElse ThisTimeSheet.IsMissingComments = False Then

                                ThisTimeSheet.IsMissingComments = DataReader.GetValue(DataReader.GetOrdinal("TimesheetMissingComments"))

                            End If

                        Loop

                    End If

                    If DataReader.IsClosed = False Then DataReader.Close()

                Catch ex As Exception
                    ErrorMessage = ex.Message.ToString()
                    Return Nothing
                Finally
                    If MyConn.State = ConnectionState.Open Then MyConn.Close()
                End Try

            End Using

            Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode)

            If Employee IsNot Nothing Then

                ThisTimeSheet.FullName = Employee.ToString

            End If

            'If there is absolutely no detail records for a given date, the column is nothing, make sure it is something
            Dim CurrentColumn As ViewModels.Employee.Timesheet.TimesheetDayViewModel = Nothing
            Dim LoopValue As Integer = 0
            For x As Integer = 0 To DaysToGet - 1

                CurrentColumn = Nothing
                LoopValue = x
                CurrentColumn = ThisTimeSheet.Days.ToList().Find(Function(value As ViewModels.Employee.Timesheet.TimesheetDayViewModel)
                                                                     Return value.Date = StartDate.AddDays(LoopValue)
                                                                 End Function)

                If CurrentColumn Is Nothing Then

                    CurrentColumn = New ViewModels.Employee.Timesheet.TimesheetDayViewModel

                    CurrentColumn.Date = StartDate.AddDays(LoopValue)

                    'denied, approved,pending can't happen on a day with a total of zero hours...so only check post period!
                    CurrentColumn.PostPeriodIsClosed = PostPeriodClosed(StartDate.AddDays(LoopValue))

                    If CurrentColumn.PostPeriodIsClosed = True Then

                        CurrentColumn.CanEdit = False

                    Else

                        CurrentColumn.CanEdit = True

                    End If

                    ThisTimeSheet.Days.Add(CurrentColumn)

                End If

            Next

            ''Make sure each line has entry
            'For Each Line As ViewModels.Employee.Timesheet.TimesheetLineViewModel In ThisTimeSheet.Lines

            '    CheckForAllDays(Line, EmployeeCode, StartDate, DaysToGet)

            'Next

            Dim SortedDays As Generic.List(Of ViewModels.Employee.Timesheet.TimesheetDayViewModel) = Nothing

            SortedDays = (From Entity In ThisTimeSheet.Days
                          Order By Entity.Date
                          Select Entity).ToList

            ThisTimeSheet.Days = SortedDays

            Dim SortedLines As Generic.List(Of ViewModels.Employee.Timesheet.TimesheetLineViewModel) = Nothing

            Select Case [Sort]
                Case TimesheetSort.ClientAsc

                    SortedLines = (From Entity In ThisTimeSheet.Lines
                                   Order By Entity.ClientName Ascending, Entity.JobNumber Descending, Entity.JobComponentNumber Ascending
                                   Select Entity).ToList

                    ThisTimeSheet.Lines = SortedLines

                Case TimesheetSort.ClientDesc

                    SortedLines = (From Entity In ThisTimeSheet.Lines
                                   Order By Entity.ClientName Descending, Entity.JobNumber Descending, Entity.JobComponentNumber Ascending
                                   Select Entity).ToList

                    ThisTimeSheet.Lines = SortedLines

                Case TimesheetSort.JobAsc

                    SortedLines = (From Entity In ThisTimeSheet.Lines
                                   Order By Entity.JobNumber Ascending, Entity.JobComponentNumber Ascending
                                   Select Entity).ToList

                    ThisTimeSheet.Lines = SortedLines

                Case TimesheetSort.JobDesc

                    SortedLines = (From Entity In ThisTimeSheet.Lines
                                   Order By Entity.JobNumber Descending, Entity.JobComponentNumber Ascending
                                   Select Entity).ToList

                    ThisTimeSheet.Lines = SortedLines

            End Select
            If RepeatRowForAllDays = True Then

                ThisTimeSheet.Days = (From Entity In ThisTimeSheet.Days
                                      Where Entity.Date = SingleDayDayToGet
                                      Select Entity).ToList

            End If
            Select Case GroupBy
                Case TimesheetGroupBy.Client

                    ThisTimeSheet.Groups = (From Line In ThisTimeSheet.Lines.OrderBy(Function(x) x.ClientName).GroupBy(Function(g) If(String.IsNullOrWhiteSpace(g.ClientName), "", g.ClientName))
                                            Select New AdvantageFramework.ViewModels.Employee.Timesheet.TimesheetRowGroupViewModel With {
                                        .Key = Line.Key,
                                        .Rows = Line.Select(Function(e) New ViewModels.Employee.Timesheet.TimesheetLineViewModel With {
                                                .ActualAmount = e.ActualAmount,
                                                .ActualHours = e.ActualHours,
                                                .AlertID = e.AlertID,
                                                .AlertSubject = e.AlertSubject,
                                                .CannotEditDueToProcessingControl = e.CannotEditDueToProcessingControl,
                                                .ClientCode = e.ClientCode,
                                                .ClientCommentRequired = e.ClientCommentRequired,
                                                .ClientName = e.ClientName,
                                                .DepartmentTeamCode = e.DepartmentTeamCode,
                                                .DivisionCode = e.DivisionCode,
                                                .DivisionName = e.DivisionName,
                                                .Entries = e.Entries,
                                                .FunctionCategory = e.FunctionCategory,
                                                .FunctionCategoryDescription = e.FunctionCategoryDescription,
                                                .IsOverThreshold = e.IsOverThreshold,
                                                .JobComponentDescription = e.JobComponentDescription,
                                                .JobComponentNumber = e.JobComponentNumber,
                                                .JobDescription = e.JobDescription,
                                                .JobNumber = e.JobNumber,
                                                .JobProcessControl = e.JobProcessControl,
                                                .LineID = e.LineID,
                                                .NonEditMessage = e.NonEditMessage,
                                                .ProductCategory = e.ProductCategory,
                                                .ProductCode = e.ProductCode,
                                                .ProductDescription = e.ProductDescription,
                                                .ProgressIsShowingOnlyEmployee = e.ProgressIsShowingOnlyEmployee,
                                                .ProgressIsShowingTrafficHours = e.ProgressIsShowingTrafficHours,
                                                .QuotedAmount = e.QuotedAmount,
                                                .QuotedHours = e.QuotedHours,
                                                .Threshold = e.Threshold,
                                                .TimeType = e.TimeType}).ToList}).ToList

                Case TimesheetGroupBy.ClientDivision

                    ThisTimeSheet.Groups = (From Line In ThisTimeSheet.Lines.OrderBy(Function(x) x.ClientName).ThenBy(Function(y) y.DivisionName).GroupBy(Function(g) If(String.IsNullOrWhiteSpace(g.ClientName), "", g.ClientName & ", " & g.DivisionName))
                                            Select New AdvantageFramework.ViewModels.Employee.Timesheet.TimesheetRowGroupViewModel With {
                                        .Key = Line.Key,
                                        .Rows = Line.Select(Function(e) New ViewModels.Employee.Timesheet.TimesheetLineViewModel With {
                                                .ActualAmount = e.ActualAmount,
                                                .ActualHours = e.ActualHours,
                                                .AlertID = e.AlertID,
                                                .AlertSubject = e.AlertSubject,
                                                .CannotEditDueToProcessingControl = e.CannotEditDueToProcessingControl,
                                                .ClientCode = e.ClientCode,
                                                .ClientCommentRequired = e.ClientCommentRequired,
                                                .ClientName = e.ClientName,
                                                .DepartmentTeamCode = e.DepartmentTeamCode,
                                                .DivisionCode = e.DivisionCode,
                                                .DivisionName = e.DivisionName,
                                                .Entries = e.Entries,
                                                .FunctionCategory = e.FunctionCategory,
                                                .FunctionCategoryDescription = e.FunctionCategoryDescription,
                                                .IsOverThreshold = e.IsOverThreshold,
                                                .JobComponentDescription = e.JobComponentDescription,
                                                .JobComponentNumber = e.JobComponentNumber,
                                                .JobDescription = e.JobDescription,
                                                .JobNumber = e.JobNumber,
                                                .JobProcessControl = e.JobProcessControl,
                                                .LineID = e.LineID,
                                                .NonEditMessage = e.NonEditMessage,
                                                .ProductCategory = e.ProductCategory,
                                                .ProductCode = e.ProductCode,
                                                .ProductDescription = e.ProductDescription,
                                                .ProgressIsShowingOnlyEmployee = e.ProgressIsShowingOnlyEmployee,
                                                .ProgressIsShowingTrafficHours = e.ProgressIsShowingTrafficHours,
                                                .QuotedAmount = e.QuotedAmount,
                                                .QuotedHours = e.QuotedHours,
                                                .Threshold = e.Threshold,
                                                .TimeType = e.TimeType}).ToList}).ToList

                Case TimesheetGroupBy.ClientDivisionProduct

                    ThisTimeSheet.Groups = (From Line In ThisTimeSheet.Lines.OrderBy(Function(x) x.ClientName).ThenBy(Function(y) y.DivisionName).ThenBy(Function(z) z.ProductDescription).GroupBy(Function(g) If(String.IsNullOrWhiteSpace(g.ClientName), "", g.ClientName & ", " & g.DivisionName & ", " & g.ProductDescription))
                                            Select New AdvantageFramework.ViewModels.Employee.Timesheet.TimesheetRowGroupViewModel With {
                                        .Key = Line.Key,
                                        .Rows = Line.Select(Function(e) New ViewModels.Employee.Timesheet.TimesheetLineViewModel With {
                                                .ActualAmount = e.ActualAmount,
                                                .ActualHours = e.ActualHours,
                                                .AlertID = e.AlertID,
                                                .AlertSubject = e.AlertSubject,
                                                .CannotEditDueToProcessingControl = e.CannotEditDueToProcessingControl,
                                                .ClientCode = e.ClientCode,
                                                .ClientCommentRequired = e.ClientCommentRequired,
                                                .ClientName = e.ClientName,
                                                .DepartmentTeamCode = e.DepartmentTeamCode,
                                                .DivisionCode = e.DivisionCode,
                                                .DivisionName = e.DivisionName,
                                                .Entries = e.Entries,
                                                .FunctionCategory = e.FunctionCategory,
                                                .FunctionCategoryDescription = e.FunctionCategoryDescription,
                                                .IsOverThreshold = e.IsOverThreshold,
                                                .JobComponentDescription = e.JobComponentDescription,
                                                .JobComponentNumber = e.JobComponentNumber,
                                                .JobDescription = e.JobDescription,
                                                .JobNumber = e.JobNumber,
                                                .JobProcessControl = e.JobProcessControl,
                                                .LineID = e.LineID,
                                                .NonEditMessage = e.NonEditMessage,
                                                .ProductCategory = e.ProductCategory,
                                                .ProductCode = e.ProductCode,
                                                .ProductDescription = e.ProductDescription,
                                                .ProgressIsShowingOnlyEmployee = e.ProgressIsShowingOnlyEmployee,
                                                .ProgressIsShowingTrafficHours = e.ProgressIsShowingTrafficHours,
                                                .QuotedAmount = e.QuotedAmount,
                                                .QuotedHours = e.QuotedHours,
                                                .Threshold = e.Threshold,
                                                .TimeType = e.TimeType}).ToList()}).ToList

                Case TimesheetGroupBy.ClientJob

                    ThisTimeSheet.Groups = (From Line In ThisTimeSheet.Lines.OrderBy(Function(x) x.ClientName).ThenBy(Function(y) y.JobNumber).GroupBy(Function(g) If(String.IsNullOrWhiteSpace(g.ClientName), "", g.ClientName & ", " & g.JobNumber.ToString.PadLeft(6, "0")))
                                            Select New AdvantageFramework.ViewModels.Employee.Timesheet.TimesheetRowGroupViewModel With {
                                        .Key = Line.Key,
                                        .Rows = Line.Select(Function(e) New ViewModels.Employee.Timesheet.TimesheetLineViewModel With {
                                                .ActualAmount = e.ActualAmount,
                                                .ActualHours = e.ActualHours,
                                                .AlertID = e.AlertID,
                                                .AlertSubject = e.AlertSubject,
                                                .CannotEditDueToProcessingControl = e.CannotEditDueToProcessingControl,
                                                .ClientCode = e.ClientCode,
                                                .ClientCommentRequired = e.ClientCommentRequired,
                                                .ClientName = e.ClientName,
                                                .DepartmentTeamCode = e.DepartmentTeamCode,
                                                .DivisionCode = e.DivisionCode,
                                                .DivisionName = e.DivisionName,
                                                .Entries = e.Entries,
                                                .FunctionCategory = e.FunctionCategory,
                                                .FunctionCategoryDescription = e.FunctionCategoryDescription,
                                                .IsOverThreshold = e.IsOverThreshold,
                                                .JobComponentDescription = e.JobComponentDescription,
                                                .JobComponentNumber = e.JobComponentNumber,
                                                .JobDescription = e.JobDescription,
                                                .JobNumber = e.JobNumber,
                                                .JobProcessControl = e.JobProcessControl,
                                                .LineID = e.LineID,
                                                .NonEditMessage = e.NonEditMessage,
                                                .ProductCategory = e.ProductCategory,
                                                .ProductCode = e.ProductCode,
                                                .ProductDescription = e.ProductDescription,
                                                .ProgressIsShowingOnlyEmployee = e.ProgressIsShowingOnlyEmployee,
                                                .ProgressIsShowingTrafficHours = e.ProgressIsShowingTrafficHours,
                                                .QuotedAmount = e.QuotedAmount,
                                                .QuotedHours = e.QuotedHours,
                                                .Threshold = e.Threshold,
                                                .TimeType = e.TimeType}).ToList}).ToList

                Case TimesheetGroupBy.ClientDivisionJob

                    ThisTimeSheet.Groups = (From Line In ThisTimeSheet.Lines.OrderBy(Function(x) x.ClientName).ThenBy(Function(y) y.DivisionName).ThenBy(Function(z) z.JobNumber).GroupBy(Function(g) If(String.IsNullOrWhiteSpace(g.ClientName), "", g.ClientName & ", " & g.DivisionName & ", " & g.JobNumber.ToString.PadLeft(6, "0")))
                                            Select New AdvantageFramework.ViewModels.Employee.Timesheet.TimesheetRowGroupViewModel With {
                                        .Key = Line.Key,
                                        .Rows = Line.Select(Function(e) New ViewModels.Employee.Timesheet.TimesheetLineViewModel With {
                                                .ActualAmount = e.ActualAmount,
                                                .ActualHours = e.ActualHours,
                                                .AlertID = e.AlertID,
                                                .AlertSubject = e.AlertSubject,
                                                .CannotEditDueToProcessingControl = e.CannotEditDueToProcessingControl,
                                                .ClientCode = e.ClientCode,
                                                .ClientCommentRequired = e.ClientCommentRequired,
                                                .ClientName = e.ClientName,
                                                .DepartmentTeamCode = e.DepartmentTeamCode,
                                                .DivisionCode = e.DivisionCode,
                                                .DivisionName = e.DivisionName,
                                                .Entries = e.Entries,
                                                .FunctionCategory = e.FunctionCategory,
                                                .FunctionCategoryDescription = e.FunctionCategoryDescription,
                                                .IsOverThreshold = e.IsOverThreshold,
                                                .JobComponentDescription = e.JobComponentDescription,
                                                .JobComponentNumber = e.JobComponentNumber,
                                                .JobDescription = e.JobDescription,
                                                .JobNumber = e.JobNumber,
                                                .JobProcessControl = e.JobProcessControl,
                                                .LineID = e.LineID,
                                                .NonEditMessage = e.NonEditMessage,
                                                .ProductCategory = e.ProductCategory,
                                                .ProductCode = e.ProductCode,
                                                .ProductDescription = e.ProductDescription,
                                                .ProgressIsShowingOnlyEmployee = e.ProgressIsShowingOnlyEmployee,
                                                .ProgressIsShowingTrafficHours = e.ProgressIsShowingTrafficHours,
                                                .QuotedAmount = e.QuotedAmount,
                                                .QuotedHours = e.QuotedHours,
                                                .Threshold = e.Threshold,
                                                .TimeType = e.TimeType}).ToList}).ToList

                Case TimesheetGroupBy.ClientDivisionProductJob

                    ThisTimeSheet.Groups = (From Line In ThisTimeSheet.Lines.OrderBy(Function(x) x.ClientName).ThenBy(Function(y) y.DivisionName).ThenBy(Function(z) z.ProductDescription).ThenBy(Function(a) a.JobNumber).GroupBy(Function(g) If(String.IsNullOrWhiteSpace(g.ClientName), "", g.ClientName & ", " & g.DivisionName & ", " & g.ProductDescription & ", " & g.JobNumber.ToString.PadLeft(6, "0")))
                                            Select New AdvantageFramework.ViewModels.Employee.Timesheet.TimesheetRowGroupViewModel With {
                                        .Key = Line.Key,
                                        .Rows = Line.Select(Function(e) New ViewModels.Employee.Timesheet.TimesheetLineViewModel With {
                                                .ActualAmount = e.ActualAmount,
                                                .ActualHours = e.ActualHours,
                                                .AlertID = e.AlertID,
                                                .AlertSubject = e.AlertSubject,
                                                .CannotEditDueToProcessingControl = e.CannotEditDueToProcessingControl,
                                                .ClientCode = e.ClientCode,
                                                .ClientCommentRequired = e.ClientCommentRequired,
                                                .ClientName = e.ClientName,
                                                .DepartmentTeamCode = e.DepartmentTeamCode,
                                                .DivisionCode = e.DivisionCode,
                                                .DivisionName = e.DivisionName,
                                                .Entries = e.Entries,
                                                .FunctionCategory = e.FunctionCategory,
                                                .FunctionCategoryDescription = e.FunctionCategoryDescription,
                                                .IsOverThreshold = e.IsOverThreshold,
                                                .JobComponentDescription = e.JobComponentDescription,
                                                .JobComponentNumber = e.JobComponentNumber,
                                                .JobDescription = e.JobDescription,
                                                .JobNumber = e.JobNumber,
                                                .JobProcessControl = e.JobProcessControl,
                                                .LineID = e.LineID,
                                                .NonEditMessage = e.NonEditMessage,
                                                .ProductCategory = e.ProductCategory,
                                                .ProductCode = e.ProductCode,
                                                .ProductDescription = e.ProductDescription,
                                                .ProgressIsShowingOnlyEmployee = e.ProgressIsShowingOnlyEmployee,
                                                .ProgressIsShowingTrafficHours = e.ProgressIsShowingTrafficHours,
                                                .QuotedAmount = e.QuotedAmount,
                                                .QuotedHours = e.QuotedHours,
                                                .Threshold = e.Threshold,
                                                .TimeType = e.TimeType}).ToList}).ToList

                    'Case TimesheetSort.FunctionCategory
                    'Case TimesheetSort.DepartmentTeam
                Case Else

                    Dim Group As New AdvantageFramework.ViewModels.Employee.Timesheet.TimesheetRowGroupViewModel

                    Group.Key = ""
                    Group.Rows = ThisTimeSheet.Lines

                    ThisTimeSheet.Groups.Add(Group)

            End Select

            'ThisTimeSheet.Lines.OrderByDescending(Function(x) x.JobNumber)

            Return ThisTimeSheet

        End Function
        Private Function LoadEmployeeTimeIDs(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                             ByVal EmployeeCode As String,
                                             ByVal StartDate As Date,
                                             ByVal EndDate As Date) As Generic.List(Of EmployeeTimeDay)

            Dim EmployeeCodeSqlParameter As New System.Data.SqlClient.SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
            Dim StartDateSqlParameter As New System.Data.SqlClient.SqlParameter("@START_DATE", SqlDbType.SmallDateTime)
            Dim EndDateSqlParameter As New System.Data.SqlClient.SqlParameter("@END_DATE", SqlDbType.SmallDateTime)
            Dim Days As Generic.List(Of EmployeeTimeDay) = Nothing

            Dim SQL As String = "	SELECT
		                                [EmployeeCode] = ET.EMP_CODE,
		                                [EmployeeTimeID] = ET.ET_ID,
		                                [EmployeeDate] = ET.EMP_DATE
	                                FROM
		                                EMP_TIME ET WITH(NOLOCK)
	                                WHERE
		                                ET.EMP_CODE = @EMP_CODE
		                                AND ET.EMP_DATE BETWEEN @START_DATE AND @END_DATE;
                                "
            EmployeeCodeSqlParameter.Value = EmployeeCode
            StartDateSqlParameter.Value = StartDate
            EndDateSqlParameter.Value = EndDate

            Try

                Days = DbContext.Database.SqlQuery(Of EmployeeTimeDay)(SQL,
                                                                       EmployeeCodeSqlParameter,
                                                                       StartDateSqlParameter,
                                                                       EndDateSqlParameter).ToList

            Catch ex As Exception
                Days = Nothing
            End Try

            If Days Is Nothing Then Days = New List(Of EmployeeTimeDay)

            Return Days

        End Function
        Private Function SetWebWebDataKey(ByVal EmployeeCode As String,
                                          ByVal FunctionCategoryCode As String,
                                          ByVal DepartmentTeamCode As String,
                                          ByVal JobNumber As Integer,
                                          ByVal JobComponentNumber As Short,
                                          ByVal EmployeeTimeID As Integer,
                                          ByVal EmployeeTimeDetailID As Integer,
                                          ByVal EntryDate As Date,
                                          ByVal TimeType As String,
                                          ByVal EditFlag As Integer,
                                          ByVal CommentsRequired As Boolean,
                                          ByVal HasComments As Boolean,
                                          ByVal Hours As Decimal,
                                          ByVal AlertID As Integer) As String

            Dim EntryInfo As New ViewModels.Employee.Timesheet.EntryInfoViewModel
            Dim WebDataKey As String = String.Empty

            EntryInfo.EmployeeCode = EmployeeCode
            EntryInfo.FunctionCategoryCode = FunctionCategoryCode
            EntryInfo.DepartmentTeamCode = DepartmentTeamCode
            EntryInfo.JobNumber = JobNumber
            EntryInfo.JobComponentNumber = JobComponentNumber
            EntryInfo.EmployeeTimeID = EmployeeTimeID
            EntryInfo.EmployeeTimeDetailID = EmployeeTimeDetailID
            EntryInfo.EntryDate = EntryDate
            EntryInfo.TimeType = TimeType
            EntryInfo.EditFlag = EditFlag
            EntryInfo.CommentsRequired = CommentsRequired
            EntryInfo.HasComments = HasComments
            EntryInfo.Hours = Hours
            EntryInfo.AlertID = AlertID
            If EntryInfo.TimeType = "N" Then EntryInfo.CommentsRequired = False

            WebDataKey = EntryInfo.ToArrayString

            EntryInfo = Nothing

            Return WebDataKey

        End Function
        Private Function SetLineIdentifier(ByVal ts As ViewModels.Employee.Timesheet.TimesheetViewModel, ByVal BaseIdentifier As String) As String
            Try
                Dim i As Integer = 0
                For Each line As ViewModels.Employee.Timesheet.TimesheetLineViewModel In ts.Lines
                    If line.LineID = BaseIdentifier Then
                        i += 1
                    End If
                Next
                Return (i + 1).ToString() & "|" & BaseIdentifier
            Catch ex As Exception
                Return "-1|" & BaseIdentifier
            End Try
        End Function
        Private Sub CheckForAllDays(ByRef TimesheetLine As ViewModels.Employee.Timesheet.TimesheetLineViewModel, ByVal EmployeeCode As String,
                                    ByVal StartDate As Date, ByVal DaysToGet As Integer)

            Dim Entry As ViewModels.Employee.Timesheet.TimesheetEntryViewModel = Nothing
            Dim LoopIteration As Integer = 0

            For i As Integer = 0 To DaysToGet - 1

                LoopIteration = i
                Entry = Nothing

                Entry = (From Entity In TimesheetLine.Entries
                         Where Entity.Date = DateAdd(DateInterval.Day, LoopIteration, StartDate)
                         Select Entity).FirstOrDefault

                If Entry Is Nothing Then

                    Entry = NewBlankEntry(DateAdd(DateInterval.Day, LoopIteration, StartDate), EmployeeCode, TimesheetLine)

                    If Entry IsNot Nothing Then

                        TimesheetLine.Entries.Add(Entry)

                    End If

                End If

            Next

        End Sub
        Private Function NewBlankEntry(ByVal EntryDate As Date, ByVal EmployeeCode As String, ByVal TimesheetLine As ViewModels.Employee.Timesheet.TimesheetLineViewModel) As ViewModels.Employee.Timesheet.TimesheetEntryViewModel

            Dim BlankEntry As New ViewModels.Employee.Timesheet.TimesheetEntryViewModel

            Try

                Dim DataKeyStringBuilder As New Text.StringBuilder
                Dim HasJobNumber As Boolean = False
                Dim HasJobComponentNumber As Boolean = False
                Dim EntryInfo As New AdvantageFramework.ViewModels.Employee.Timesheet.EntryInfoViewModel

                BlankEntry.Date = EntryDate
                BlankEntry.LineID = TimesheetLine.LineID
                BlankEntry.TimeType = TimesheetLine.TimeType
                BlankEntry.AlertID = TimesheetLine.AlertID
                BlankEntry.AlertSubject = TimesheetLine.AlertSubject

                EntryInfo.EmployeeCode = EmployeeCode
                EntryInfo.FunctionCategoryCode = TimesheetLine.FunctionCategory
                EntryInfo.DepartmentTeamCode = TimesheetLine.DepartmentTeamCode

                If TimesheetLine.JobNumber IsNot Nothing AndAlso TimesheetLine.JobNumber > 0 Then
                    EntryInfo.JobNumber = TimesheetLine.JobNumber
                    HasJobNumber = True
                Else
                    EntryInfo.JobNumber = 0
                End If
                If TimesheetLine.JobComponentNumber IsNot Nothing AndAlso TimesheetLine.JobComponentNumber > 0 Then
                    EntryInfo.JobComponentNumber = TimesheetLine.JobComponentNumber
                    HasJobComponentNumber = True
                Else
                    EntryInfo.JobComponentNumber = 0
                End If
                EntryInfo.EntryDate = EntryDate.Date

                If HasJobNumber = True AndAlso HasJobComponentNumber = True Then
                    EntryInfo.TimeType = "D"
                Else
                    EntryInfo.TimeType = "N"
                End If

                BlankEntry.WebDataKey = EntryInfo.ToArrayString

            Catch ex As Exception
                BlankEntry = Nothing
            End Try

            Return BlankEntry

        End Function

#Region " Row context menu "

        Public Function UpdateCategory(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                       ByVal Entries As String, ByVal CategoryCode As String,
                                       ByRef ErrorMessage As String) As Boolean

            Dim Success As Boolean = False

            Dim EntriesArray() As String
            EntriesArray = Entries.Split(",")

            If EntriesArray IsNot Nothing AndAlso EntriesArray.Length > 0 Then

                Dim CategoryIsValid As Boolean = False
                Dim Category As AdvantageFramework.Database.Entities.IndirectCategory = Nothing

                Category = AdvantageFramework.Database.Procedures.IndirectCategory.LoadByIndirectCategoryCode(DbContext, CategoryCode)

                If Category IsNot Nothing Then

                    If Category.IsInactive IsNot Nothing AndAlso Category.IsInactive = True Then

                        CategoryIsValid = False
                        ErrorMessage = "Inactive category."

                    Else

                        CategoryIsValid = True

                    End If

                Else

                    CategoryIsValid = False
                    ErrorMessage = "Invalid category."

                End If

                If CategoryIsValid = True Then

                    Dim CanEdit As Boolean = True
                    Dim EmployeeTimeID As Integer = 0
                    Dim EmployeeTimeDetailID As Integer = 0
                    Dim SbSQL As New System.Text.StringBuilder

                    For i As Integer = 0 To EntriesArray.Length - 1

                        EmployeeTimeID = 0
                        EmployeeTimeDetailID = 0

                        Dim EntryIDs() As String
                        EntryIDs = EntriesArray(i).Split("|")

                        If EntryIDs IsNot Nothing AndAlso EntryIDs.Length = 2 Then

                            If IsNumeric(EntryIDs(0)) = True Then

                                EmployeeTimeID = CType(EntryIDs(0), Integer)

                            Else

                                EmployeeTimeID = 0

                            End If
                            If IsNumeric(EntryIDs(1)) = True Then

                                EmployeeTimeDetailID = CType(EntryIDs(1), Integer)

                            Else

                                EmployeeTimeDetailID = 0

                            End If
                            If EmployeeTimeID > 0 AndAlso EmployeeTimeDetailID > 0 Then

                                'CanEdit = True

                                'If CanEdit = True Then

                                SbSQL.Append(String.Format("UPDATE EMP_TIME_NP WITH(ROWLOCK) SET CATEGORY = '{2}' WHERE ET_ID = {0} AND ET_DTL_ID = {1};",
                                                           EmployeeTimeID, EmployeeTimeDetailID, CategoryCode))

                                'Else

                                '    Exit For 'If one entry can't be updated, update none.

                                'End If

                            End If

                        End If

                    Next
                    'If CanEdit = True Then 'all recs in row can be edited

                    Try

                        Dim SQL As String = SbSQL.ToString

                        If String.IsNullOrWhiteSpace(SQL) = False Then

                            DbContext.Database.ExecuteSqlCommand(SbSQL.ToString)
                            Success = True

                        End If

                    Catch ex As Exception
                        ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                        Success = False
                    End Try

                    'End If

                End If

            End If

            Return Success

        End Function
        Public Function UpdateFunction(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                       ByVal SecuritySession As AdvantageFramework.Security.Session,
                                       ByVal EmployeeCode As String,
                                       ByVal Entries As String, ByVal FunctionCode As String,
                                       ByRef ErrorMessage As String) As Boolean

            Dim Success As Boolean = False
            Dim AttemptedUpdates As Integer = 0
            Dim SuccessfulUpdates As Integer = 0
            Dim FunctionDepartmentCode As String = String.Empty
            Dim DepartmentCode As String = String.Empty

            Dim EntriesArray() As String
            EntriesArray = Entries.Split(",")

            If EntriesArray IsNot Nothing AndAlso EntriesArray.Length > 0 Then

                Dim FunctionIsValid As Boolean = False
                Dim FunctionEntity As AdvantageFramework.Database.Entities.Function = Nothing
                Dim Defaults As New AdvantageFramework.Controller.Employee.EmployeeDefaults(SecuritySession, EmployeeCode)

                FunctionEntity = AdvantageFramework.Database.Procedures.Function.LoadByFunctionCode(DbContext, FunctionCode)

                If FunctionEntity IsNot Nothing Then

                    If FunctionEntity.IsInactive IsNot Nothing AndAlso FunctionEntity.IsInactive = True Then

                        FunctionIsValid = False
                        ErrorMessage = "Inactive function."

                    Else

                        FunctionIsValid = True
                        FunctionDepartmentCode = FunctionEntity.DepartmentTeamCode

                    End If
                    If String.IsNullOrWhiteSpace(FunctionDepartmentCode) = False Then

                        DepartmentCode = FunctionDepartmentCode

                    Else

                        DepartmentCode = Defaults.DepartmentCode

                    End If

                Else

                    FunctionIsValid = False
                    ErrorMessage = "Invalid function."

                End If

                If FunctionIsValid = True Then

                    Dim CanEdit As Boolean = True
                    Dim EmployeeTimeID As Integer = 0
                    Dim EmployeeTimeDetailID As Integer = 0

                    For i As Integer = 0 To EntriesArray.Length - 1

                        EmployeeTimeID = 0
                        EmployeeTimeDetailID = 0

                        Dim EntryIDs() As String
                        EntryIDs = EntriesArray(i).Split("|")

                        If EntryIDs IsNot Nothing AndAlso EntryIDs.Length = 2 Then

                            Try

                                If IsNumeric(EntryIDs(0)) = True Then

                                    EmployeeTimeID = CType(EntryIDs(0), Integer)

                                Else

                                    EmployeeTimeID = 0

                                End If

                            Catch ex As Exception
                                EmployeeTimeID = 0
                            End Try
                            Try

                                If IsNumeric(EntryIDs(1)) = True Then

                                    EmployeeTimeDetailID = CType(EntryIDs(1), Integer)

                                Else

                                    EmployeeTimeDetailID = 0

                                End If

                            Catch ex As Exception
                                EmployeeTimeDetailID = 0
                            End Try
                            If EmployeeTimeID > 0 AndAlso EmployeeTimeDetailID > 0 Then

                                CanEdit = CanEditEntry(DbContext, EmployeeTimeID, EmployeeTimeDetailID)

                                If CanEdit = True Then

                                    CanEdit = True

                                Else

                                    CanEdit = False
                                    Exit For 'If one entry can't be updated, update none.

                                End If

                            End If

                        End If

                    Next
                    If CanEdit = True Then 'all recs in row can be edited

                        Dim Entry As AdvantageFramework.Database.Entities.EmployeeTimeDetail = Nothing
                        Dim EntryComment As AdvantageFramework.Database.Entities.EmployeeTimeComment = Nothing
                        Dim Comment As String = ""
                        Dim EntryErrorMessage As String = String.Empty
                        Dim EntryNewEmployeeTimeID As Integer = 0
                        Dim EntryNewEmployeeTimeDetailID As Integer = 0

                        For i As Integer = 0 To EntriesArray.Length - 1

                            Entry = Nothing
                            EntryComment = Nothing
                            EmployeeTimeID = 0
                            EmployeeTimeDetailID = 0
                            Comment = ""
                            EntryErrorMessage = String.Empty
                            EntryNewEmployeeTimeID = 0
                            EntryNewEmployeeTimeDetailID = 0

                            Dim EntryIDs() As String
                            EntryIDs = EntriesArray(i).Split("|")

                            If EntryIDs IsNot Nothing AndAlso EntryIDs.Length = 2 Then

                                Try

                                    If IsNumeric(EntryIDs(0)) = True Then

                                        EmployeeTimeID = CType(EntryIDs(0), Integer)

                                    Else

                                        EmployeeTimeID = 0

                                    End If

                                Catch ex As Exception
                                    EmployeeTimeID = 0
                                End Try
                                Try

                                    If IsNumeric(EntryIDs(1)) = True Then

                                        EmployeeTimeDetailID = CType(EntryIDs(1), Integer)

                                    Else

                                        EmployeeTimeDetailID = 0

                                    End If

                                Catch ex As Exception
                                    EmployeeTimeDetailID = 0
                                End Try
                                If EmployeeTimeID > 0 AndAlso EmployeeTimeDetailID > 0 Then

                                    Entry = AdvantageFramework.Database.Procedures.EmployeeTimeDetail.LoadByEmployeeTimeIDAndEmployeeTimeDetailID(DbContext, EmployeeTimeID, EmployeeTimeDetailID)

                                    If Entry IsNot Nothing Then

                                        AttemptedUpdates += 1

                                        EntryComment = AdvantageFramework.Database.Procedures.EmployeeTimeComment.LoadByEmployeeTimeIDAndEmployeeTimeDetailIDAndEmployeeTimeSource(DbContext, EmployeeTimeID, EmployeeTimeDetailID, "D")

                                        If EntryComment IsNot Nothing AndAlso String.IsNullOrWhiteSpace(EntryComment.EmployeeComments) = False Then

                                            Comment = EntryComment.EmployeeComments

                                        End If
                                        If AdvantageFramework.EmployeeTimesheet.SaveDay(DbContext.ConnectionString, DbContext.UserCode, EmployeeTimeID, EmployeeTimeDetailID, Entry.EmployeeTime.EmployeeCode,
                                                                                        Entry.EmployeeTime.Date, FunctionCode, If(Entry.ProductCategoryCode Is Nothing, "", Entry.ProductCategoryCode), Entry.Hours, Entry.JobNumber,
                                                                                        Entry.JobComponentNumber, DepartmentCode, DbContext.UserCode, EntryErrorMessage, Comment,
                                                                                        EntryNewEmployeeTimeID, EntryNewEmployeeTimeDetailID, If(Entry.AlertID Is Nothing, 0, Entry.AlertID), False) = True Then

                                            SuccessfulUpdates += 1

                                        End If

                                    End If

                                End If

                            End If

                        Next

                    End If

                End If

            End If

            If AttemptedUpdates = 0 Then

                Success = True
                ErrorMessage = "No updates were attempted."

            Else

                If AttemptedUpdates = SuccessfulUpdates Then

                    Success = True
                    ErrorMessage = "All entries updated."

                ElseIf AttemptedUpdates > 0 AndAlso SuccessfulUpdates > 0 Then

                    Success = True
                    ErrorMessage = "Some but not all entries updated."

                ElseIf AttemptedUpdates > 0 AndAlso SuccessfulUpdates = 0 Then

                    Success = False
                    ErrorMessage = "No entries were updated."

                End If

            End If

            Return Success

        End Function
        Public Function UpdateAssignment(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                       ByVal Entries As String, ByVal AlertID As String,
                                       ByRef ErrorMessage As String) As Boolean

            Dim Success As Boolean = False

            Dim EntriesArray() As String
            EntriesArray = Entries.Split(",")

            If EntriesArray IsNot Nothing AndAlso EntriesArray.Length > 0 Then

                Dim AssignmentIsValid As Boolean = False
                Dim Assignment As AdvantageFramework.Database.Entities.Alert = Nothing

                Assignment = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertID)

                If Assignment IsNot Nothing Then

                    'If FunctionEntity.IsInactive IsNot Nothing AndAlso FunctionEntity.IsInactive = True Then

                    '    AssignmentIsValid = False
                    '    ErrorMessage = "Inactive assignment."

                    'Else

                    AssignmentIsValid = True

                    'End If

                Else

                    AssignmentIsValid = False
                    ErrorMessage = "Invalid assignment."

                End If
                If AssignmentIsValid = True Then

                    Dim CanEdit As Boolean = True
                    Dim EmployeeTimeID As Integer = 0
                    Dim EmployeeTimeDetailID As Integer = 0
                    Dim SbSQL As New System.Text.StringBuilder

                    For i As Integer = 0 To EntriesArray.Length - 1

                        EmployeeTimeID = 0
                        EmployeeTimeDetailID = 0

                        Dim EntryIDs() As String
                        EntryIDs = EntriesArray(i).Split("|")

                        If EntryIDs IsNot Nothing AndAlso EntryIDs.Length = 2 Then

                            If IsNumeric(EntryIDs(0)) = True Then

                                EmployeeTimeID = CType(EntryIDs(0), Integer)

                            Else

                                EmployeeTimeID = 0

                            End If
                            If IsNumeric(EntryIDs(1)) = True Then

                                EmployeeTimeDetailID = CType(EntryIDs(1), Integer)

                            Else

                                EmployeeTimeDetailID = 0

                            End If
                            If EmployeeTimeID > 0 AndAlso EmployeeTimeDetailID > 0 Then

                                CanEdit = CanEditEntry(DbContext, EmployeeTimeID, EmployeeTimeDetailID)

                                If CanEdit = True Then

                                    SbSQL.Append(String.Format("UPDATE EMP_TIME_DTL WITH(ROWLOCK) SET ALERT_ID = {2} WHERE ET_ID = {0} AND ET_DTL_ID = {1};",
                                                               EmployeeTimeID, EmployeeTimeDetailID, AlertID))

                                Else

                                    Exit For 'If one entry can't be updated, update none.

                                End If

                            End If

                        End If

                    Next
                    If CanEdit = True Then 'all recs in row can be edited

                        Try

                            Dim SQL As String = SbSQL.ToString

                            If String.IsNullOrWhiteSpace(SQL) = False Then

                                DbContext.Database.ExecuteSqlCommand(SbSQL.ToString)
                                Success = True

                            End If

                        Catch ex As Exception
                            ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                            Success = False
                        End Try

                    End If

                End If

            End If

            Return Success

        End Function
        Public Function DeleteEntry(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                    ByVal EmployeeTimeID As Integer, ByVal EmployeeTimeDetailID As Integer, ByVal TimeType As String, ByRef ErrorMessage As String) As Boolean

            Dim Deleted As Boolean = False
            Dim EntryEditType As AdvantageFramework.Timesheet.TimesheetEditType = TimesheetEditType.Edit

            EntryEditType = CheckEditStatus(DbContext, EmployeeTimeID, EmployeeTimeDetailID)

            If EntryEditType = TimesheetEditType.Edit Then

                Dim MyReturn As String = ""
                Dim MyCmd As New SqlCommand()

                Dim parameteret_id As New SqlParameter("@et_id", SqlDbType.Int, 4)
                parameteret_id.Value = EmployeeTimeID

                Dim parameteretd_id As New SqlParameter("@etd_id", SqlDbType.Int, 4)
                parameteretd_id.Value = EmployeeTimeDetailID

                Dim parameterTimeType As New SqlParameter("@time_type", SqlDbType.Char, 1)
                parameterTimeType.Value = TimeType.ToUpper

                Dim parametererror_text As New SqlParameter("@error_text", SqlDbType.VarChar, 254)
                parametererror_text.Direction = ParameterDirection.Output

                MyCmd.Parameters.Add(parameteret_id)
                MyCmd.Parameters.Add(parameteretd_id)
                MyCmd.Parameters.Add(parameterTimeType)
                MyCmd.Parameters.Add(parametererror_text)

                Try

                    Using MyConn As New SqlConnection(DbContext.ConnectionString)

                        Dim MyTrans As SqlTransaction

                        MyConn.Open()
                        MyTrans = MyConn.BeginTransaction

                        Try

                            With MyCmd

                                .CommandText = "usp_wv_ts_delete"
                                .CommandType = CommandType.StoredProcedure
                                .Connection = MyConn
                                .Transaction = MyTrans

                                .ExecuteNonQuery()

                            End With

                            MyTrans.Commit()

                            If parametererror_text IsNot Nothing AndAlso parametererror_text.Value IsNot Nothing Then

                                ErrorMessage = (parametererror_text.Value.ToString)

                            End If

                            Deleted = True

                        Catch ex As Exception
                            ErrorMessage = ex.Message.ToString
                            MyTrans.Rollback()
                        Finally
                            If MyConn.State = ConnectionState.Open Then MyConn.Close()
                        End Try

                    End Using

                Catch ex As Exception
                    ErrorMessage = ex.Message.ToString
                End Try

            Else

                ErrorMessage = EntryEditType.ToString
                Deleted = False

            End If

            Return Deleted

        End Function
        Public Function CopyRow(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                ByVal EmployeeCode As String, ByVal StartDate As Date,
                                ByVal JobNumber As Integer, ByVal JobComponentNumber As Short,
                                ByVal FunctionCategoryCode As String, ByVal AlertID As Integer,
                                ByRef ErrorMessage As String) As Boolean

            Dim Copied As Boolean = False

            Try

                Dim TimeType As String = String.Empty
                Dim DepartmentTeamCode As String = ""
                Dim NewEmployeeTimeID As Integer = 0
                Dim NewEmployeeTimeDetailID As Integer = 0
                Dim DayCopied As Boolean = False

                StartDate = AdvantageFramework.EmployeeTimesheet.FirstDayOfWeekUser(DbContext, StartDate)

                Copied = AdvantageFramework.EmployeeTimesheet.SaveDay(DbContext.ConnectionString, DbContext.UserCode, 0, 0,
                                                                      EmployeeCode, StartDate, FunctionCategoryCode, "", 0, JobNumber, JobComponentNumber, DepartmentTeamCode,
                                                                      DbContext.UserCode, ErrorMessage, "", NewEmployeeTimeID, NewEmployeeTimeDetailID, AlertID, True)
                'For i = 0 To 6

                '    DayCopied = AdvantageFramework.EmployeeTimesheet.SaveDay(DbContext.ConnectionString, 0, 0,
                '                                                             EmployeeCode, DateAdd(DateInterval.Day, i, StartDate), FunctionCategoryCode, "", 0, JobNumber, JobComponentNumber, DepartmentTeamCode,
                '                                                             DbContext.UserCode, ErrorMessage, "", NewEmployeeTimeID, NewEmployeeTimeDetailID, AlertID, True)

                '    If Copied = False Then Copied = DayCopied

                '    i += 1

                'Next

            Catch ex As Exception
                Copied = False
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
            End Try

            Return Copied

        End Function

#End Region

#Region " Approval "

        Public Function SubmitForApproval(ByVal Session As AdvantageFramework.Security.Session,
                                          ByVal EmployeeCode As String, ByVal EmployeeDate As Date,
                                          ByVal Approve As Boolean, ByVal SendEmail As Boolean,
                                          ByRef ErrorMessage As String) As Boolean

            Return AdvantageFramework.EmployeeTimesheet.SubmitForApproval(Session, EmployeeCode, EmployeeDate, Approve, SendEmail, ErrorMessage)

        End Function

#End Region

#End Region

#Region " For grid view "


#End Region

#Region " For new entry "

        Public Function LoadClientsForEmployee(ByVal SecuritySession As AdvantageFramework.Security.Session,
                                               ByVal EmployeeCode As String,
                                               ByVal SearchText As String,
                                               ByVal ClientCode_ As String,
                                               ByVal DivisionCode_ As String,
                                               ByVal ProductCode_ As String) As Generic.List(Of AdvantageFramework.Controller.Employee.ClientDivisionProductLookupItem)

            Dim Results As Generic.List(Of AdvantageFramework.Controller.Employee.ClientDivisionProductLookupItem) = Nothing
            Dim ResultQuery As Generic.List(Of AdvantageFramework.Database.Views.ProductView) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                    ResultQuery = AdvantageFramework.Database.Procedures.ProductView.LoadByUserCodeWithOfficeLimits(SecuritySession, DbContext, SecurityDbContext, True)

                    If Not String.IsNullOrWhiteSpace(ClientCode_) Then ResultQuery = ResultQuery.Where(Function(Prod) Prod.ClientCode = ClientCode_).ToList
                    If Not String.IsNullOrWhiteSpace(DivisionCode_) Then ResultQuery = ResultQuery.Where(Function(Prod) Prod.DivisionCode = DivisionCode_).ToList
                    If Not String.IsNullOrWhiteSpace(ProductCode_) Then ResultQuery = ResultQuery.Where(Function(Prod) Prod.ProductCode = ProductCode_).ToList

                End Using

            End Using
            Try

                Results = (From Item In ResultQuery
                           Select Item.[DivisionCode],
                                  Item.DivisionName,
                                  Item.[ClientCode],
                                  Item.ClientName,
                                  Item.[ProductCode],
                                  Item.ProductDescription).Select(Function(Prd) New AdvantageFramework.Controller.Employee.ClientDivisionProductLookupItem With {.Key = Prd.ClientCode & "|" & Prd.DivisionCode & "|" & Prd.ProductCode,
                                                                                                                                                                 .CDP = AdvantageFramework.Database.Procedures.Product.BuildClientDivisionProductDisplay(Prd.ClientName, Prd.DivisionName, Prd.ProductDescription)}).Distinct.ToList

            Catch ex As Exception
                Results = Nothing
            End Try

            If Results Is Nothing Then Results = New List(Of AdvantageFramework.Controller.Employee.ClientDivisionProductLookupItem)

            Return Results

        End Function
        Private Function GetUserCodeFromEmployeeCode(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                     ByVal SecuritySession As AdvantageFramework.Security.Session,
                                                     ByVal EmployeeCode As String) As String

            Dim UserCode As String = SecuritySession.UserCode

            Try

                If EmployeeCode <> SecuritySession.User.EmployeeCode Then

                    UserCode = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT TOP 1 USER_CODE FROM SEC_USER WITH(NOLOCK) WHERE SEC_USER.EMP_CODE = '{0}' ORDER BY USER_CODE DESC;", EmployeeCode)).SingleOrDefault

                End If

            Catch ex As Exception
                UserCode = SecuritySession.UserCode
            End Try

            Return UserCode

        End Function

        Public Function LoadClients(ByVal SecuritySession As AdvantageFramework.Security.Session,
                                    ByVal EmployeeCode As String,
                                    ByVal SearchText As String,
                                    ByVal ClientCode As String,
                                    ByVal OfficeCode As String) As Generic.List(Of AdvantageFramework.Controller.Employee.ClientDivisionProductLookupItem)

            Dim Results As Generic.List(Of AdvantageFramework.Controller.Employee.ClientDivisionProductLookupItem) = Nothing
            Dim OldClientLookups As Generic.List(Of OldClientLookup) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                Dim Clients As IEnumerable = Nothing

                Dim arParams As New List(Of SqlParameter)

                arParams.Add(New SqlParameter("@UserID", Me.GetUserCodeFromEmployeeCode(DbContext, SecuritySession, EmployeeCode)))
                arParams.Add(New SqlParameter("@FromApp", "ts"))
                arParams.Add(New SqlParameter("@OfficeCode", If(String.IsNullOrWhiteSpace(OfficeCode) = False, OfficeCode, System.DBNull.Value)))
                arParams.Add(New SqlParameter("@SprintID", 0))
                arParams.Add(New SqlParameter("@Text", SearchText))

                OldClientLookups = DbContext.Database.SqlQuery(Of OldClientLookup)("EXEC [dbo].[usp_wv_dd_GetClients] @UserID, @FromApp, @OfficeCode, @SprintID, @Text;", arParams.ToArray).ToList

                If Not String.IsNullOrWhiteSpace(ClientCode) Then OldClientLookups = OldClientLookups.Where(Function(Cl) Cl.Code = ClientCode).ToList

            End Using

            Try

                If OldClientLookups IsNot Nothing Then

                    Results = (From Item In OldClientLookups
                               Select Item.Code,
                                      Item.Name).Select(Function(Cl) New _
                                          AdvantageFramework.Controller.Employee.ClientDivisionProductLookupItem With
                                          {.Key = Cl.Code & "|" & "" & "|" & "",
                                           .CDP = Cl.Name & " (" + Cl.Code + ")"}).Distinct.ToList

                End If

            Catch ex As Exception
                Results = Nothing
            End Try

            If Results Is Nothing Then Results = New List(Of AdvantageFramework.Controller.Employee.ClientDivisionProductLookupItem)

            Return Results

        End Function
        <Serializable()>
        Public Class OldClientLookup
            Public Property Code As String = String.Empty
            Public Property Description As String = String.Empty
            Public Property Name As String = String.Empty
            Sub New()

            End Sub
        End Class
        Public Function LoadDivisions(ByVal SecuritySession As AdvantageFramework.Security.Session,
                                      ByVal EmployeeCode As String,
                                      ByVal SearchText As String,
                                      ByVal ClientCode_ As String,
                                      ByVal DivisionCode_ As String) As Generic.List(Of AdvantageFramework.Controller.Employee.ClientDivisionProductLookupItem)

            Dim Results As Generic.List(Of AdvantageFramework.Controller.Employee.ClientDivisionProductLookupItem) = Nothing
            Dim OldDivisionLookups As Generic.List(Of OldDivisionLookup) = Nothing

            If String.IsNullOrWhiteSpace(ClientCode_) = False Then

                Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                        OldDivisionLookups = DbContext.Database.SqlQuery(Of OldDivisionLookup)(String.Format("EXEC [dbo].[usp_wv_dd_GetDivisions] '{0}', '{1}', 'ts', NULL, 0, '';", Me.GetUserCodeFromEmployeeCode(DbContext, SecuritySession, EmployeeCode), ClientCode_)).ToList

                        If Not String.IsNullOrWhiteSpace(DivisionCode_) Then OldDivisionLookups = OldDivisionLookups.Where(Function(Div) Div.Code = DivisionCode_).ToList

                    End Using

                End Using

            End If

            Try

                If OldDivisionLookups IsNot Nothing Then

                    Results = (From Item In OldDivisionLookups
                               Select Item.Code,
                                      Item.Name, Item.CL_CODE).Select(Function(Div) New _
                                          AdvantageFramework.Controller.Employee.ClientDivisionProductLookupItem With
                                          {.Key = Div.CL_CODE & "|" & Div.Code & "|" & "",
                                           .CDP = Div.Name & If(Div.Code = Div.CL_CODE, " (" & Div.CL_CODE + ")", " (" & Div.CL_CODE + "/" & Div.Code & ")")}).Distinct.ToList

                End If

            Catch ex As Exception
                Results = Nothing
            End Try

            If Results Is Nothing Then Results = New List(Of AdvantageFramework.Controller.Employee.ClientDivisionProductLookupItem)

            Return Results

        End Function
        <Serializable()>
        Public Class OldDivisionLookup
            Public Property Code As String = String.Empty
            Public Property DESCRIPTION As String = String.Empty
            Public Property Name As String = String.Empty
            Public Property CL_CODE As String = String.Empty
            Sub New()

            End Sub
        End Class

        Public Function LoadProducts(ByVal SecuritySession As AdvantageFramework.Security.Session,
                                     ByVal EmployeeCode As String,
                                     ByVal SearchText As String,
                                     ByVal ClientCode_ As String,
                                     ByVal DivisionCode_ As String,
                                     ByVal ProductCode_ As String) As Generic.List(Of AdvantageFramework.Controller.Employee.ClientDivisionProductLookupItem)

            Dim Results As Generic.List(Of AdvantageFramework.Controller.Employee.ClientDivisionProductLookupItem) = Nothing
            Dim OldProductLookups As Generic.List(Of OldProductLookup) = Nothing
            Dim Load As Boolean = False

            If (String.IsNullOrWhiteSpace(ClientCode_) = False AndAlso String.IsNullOrWhiteSpace(DivisionCode_) = False) Then

                Load = True

            End If
            If Load = True Then

                Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                        OldProductLookups = DbContext.Database.SqlQuery(Of OldProductLookup)(String.Format("EXEC [dbo].[usp_wv_dd_GetProducts] '{0}', '{1}', '{2}', 'ts', 0, '';", Me.GetUserCodeFromEmployeeCode(DbContext, SecuritySession, EmployeeCode), ClientCode_, DivisionCode_)).ToList

                        If Not String.IsNullOrWhiteSpace(ClientCode_) Then OldProductLookups = OldProductLookups.Where(Function(Prod) Prod.ClientCode = ClientCode_).ToList
                        If Not String.IsNullOrWhiteSpace(DivisionCode_) Then OldProductLookups = OldProductLookups.Where(Function(Prod) Prod.DivisionCode = DivisionCode_).ToList
                        If Not String.IsNullOrWhiteSpace(ProductCode_) Then OldProductLookups = OldProductLookups.Where(Function(Prod) Prod.Code = ProductCode_).ToList

                    End Using

                End Using

            End If

            Try

                If OldProductLookups IsNot Nothing Then

                    Results = (From Item In OldProductLookups
                               Select Item.[DivisionCode],
                                      Item.[ClientCode],
                                      Item.[Code],
                                      Item.[Name]).Select(Function(Prd) New _
                                          AdvantageFramework.Controller.Employee.ClientDivisionProductLookupItem With
                                          {.Key = Prd.ClientCode & "|" & Prd.DivisionCode & "|" & Prd.Code,
                                           .CDP = Prd.Name & " (" + Prd.ClientCode & If(Prd.ClientCode = Prd.DivisionCode, "", "/" & Prd.DivisionCode) & If(Prd.DivisionCode = Prd.Code, "", "/" & Prd.Code) + ")"}).Distinct.ToList

                End If


            Catch ex As Exception
                Results = Nothing
            End Try

            If Results Is Nothing Then Results = New List(Of AdvantageFramework.Controller.Employee.ClientDivisionProductLookupItem)

            Return Results

        End Function
        <Serializable()>
        Public Class OldProductLookup
            Public Property Code As String = String.Empty
            Public Property DESCRIPTION As String = String.Empty
            Public Property Name As String = String.Empty
            Public Property DivisionCode As String = String.Empty
            Public Property ClientCode As String = String.Empty
            Public Property OfficeCode As String = String.Empty
            Sub New()

            End Sub
        End Class

        Public Function LoadJobsForEmployeeFast(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                ByVal EmployeeCode As String,
                                                ByVal ClientCode As String,
                                                ByVal DivisionCode As String,
                                                ByVal ProductCode As String,
                                                ByVal JobNumber As Integer,
                                                ByVal SearchText As String) As Generic.List(Of LookupItem)

            Dim Results As Generic.List(Of LookupItem) = Nothing
            Dim UserCode As String = String.Empty

            If String.IsNullOrWhiteSpace(EmployeeCode) = True OrElse EmployeeCode = Me.Session.User.EmployeeCode Then

                UserCode = Me.Session.UserCode

            Else

                Try

                    UserCode = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT TOP 1 USER_CODE FROM SEC_USER WHERE EMP_CODE = '{0}' ORDER BY USER_CODE DESC;", EmployeeCode)).SingleOrDefault

                Catch ex As Exception
                    UserCode = Me.Session.UserCode
                End Try

            End If

            Dim arParams As New List(Of SqlParameter)

            arParams.Add(New SqlParameter("@CL_CODE", If(String.IsNullOrWhiteSpace(ClientCode) = False, ClientCode, System.DBNull.Value)))
            arParams.Add(New SqlParameter("@DIV_CODE", If(String.IsNullOrWhiteSpace(DivisionCode) = False, DivisionCode, System.DBNull.Value)))
            arParams.Add(New SqlParameter("@PRD_CODE", If(String.IsNullOrWhiteSpace(ProductCode) = False, ProductCode, System.DBNull.Value)))
            arParams.Add(New SqlParameter("@JOB_NUMBER", If(JobNumber > 0, JobNumber, System.DBNull.Value)))
            arParams.Add(New SqlParameter("@USER_CODE", If(String.IsNullOrWhiteSpace(UserCode) = False, UserCode, System.DBNull.Value)))
            arParams.Add(New SqlParameter("@COUNT", False))
            arParams.Add(New SqlParameter("@SEARCH_TEXT", SearchText))

            Try

                Results = DbContext.Database.SqlQuery(Of LookupItem)("EXEC [dbo].[advsp_timesheet_new_entry_get_jobs] @CL_CODE, @DIV_CODE, " &
                                                                                   "@PRD_CODE, @JOB_NUMBER, @USER_CODE, @COUNT, @SEARCH_TEXT;", arParams.ToArray).ToList

            Catch ex As Exception
                Results = Nothing
            End Try

            If Results Is Nothing Then Results = New List(Of LookupItem)

            Return Results

        End Function
        Public Function LoadJobsForEmployeeFastCount(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                    ByVal EmployeeCode As String,
                                                    ByVal ClientCode As String,
                                                    ByVal DivisionCode As String,
                                                    ByVal ProductCode As String,
                                                    ByVal JobNumber As Integer) As Integer

            Dim Results As Long = 0
            Dim UserCode As String = String.Empty

            If String.IsNullOrWhiteSpace(EmployeeCode) = True OrElse EmployeeCode = Me.Session.User.EmployeeCode Then

                UserCode = Me.Session.UserCode

            Else

                Try

                    UserCode = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT TOP 1 USER_CODE FROM SEC_USER WHERE EMP_CODE = '{0}';", EmployeeCode)).SingleOrDefault

                Catch ex As Exception
                    UserCode = Me.Session.UserCode
                End Try

            End If
            If String.IsNullOrWhiteSpace(ClientCode) = True Then

                ClientCode = "NULL"

            Else

                ClientCode = String.Format("'{0}'", ClientCode)

            End If
            If String.IsNullOrWhiteSpace(DivisionCode) = True Then

                DivisionCode = "NULL"

            Else

                DivisionCode = String.Format("'{0}'", DivisionCode)

            End If
            If String.IsNullOrWhiteSpace(ProductCode) = True Then

                ProductCode = "NULL"

            Else

                ProductCode = String.Format("'{0}'", ProductCode)

            End If

            Try

                Results = DbContext.Database.SqlQuery(Of Integer)(String.Format("EXEC [dbo].[advsp_timesheet_new_entry_get_jobs] @CL_CODE = {0}, @DIV_CODE = {1}, " &
                                                                                   "@PRD_CODE = {2}, @JOB_NUMBER = {3}, @USER_CODE = '{4}', @COUNT = 1, @SEARCH_TEXT = '';",
                                                                                   ClientCode,
                                                                                   DivisionCode,
                                                                                   ProductCode,
                                                                                   JobNumber,
                                                                                   UserCode)).SingleOrDefault

            Catch ex As Exception
                Results = 0
            End Try

            Return Results

        End Function

        Public Function LoadJobsForEmployee(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                            ByVal EmployeeCode As String,
                                            ByVal SearchText As String,
                                            ByVal ClientCode As String,
                                            ByVal DivisionCode As String,
                                            ByVal ProductCode As String,
                                            ByVal JobNumber As Integer,
                                            ByVal Skip As Integer,
                                            ByVal Take As Integer) As Generic.List(Of AdvantageFramework.ViewModels.Lookup.LookupViewModel)

            Dim Results As Generic.List(Of AdvantageFramework.ViewModels.Lookup.LookupViewModel) = Nothing
            Dim UserCode As String = String.Empty

            If String.IsNullOrWhiteSpace(EmployeeCode) = True OrElse EmployeeCode = Me.Session.User.EmployeeCode Then

                UserCode = Me.Session.UserCode

            Else

                Try

                    UserCode = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT TOP 1 USER_CODE FROM SEC_USER WHERE EMP_CODE = '{0}';", EmployeeCode)).SingleOrDefault

                Catch ex As Exception
                    UserCode = Me.Session.UserCode
                End Try

            End If
            If String.IsNullOrWhiteSpace(ClientCode) = True Then

                ClientCode = "NULL"

            Else

                ClientCode = String.Format("'{0}'", ClientCode)

            End If
            If String.IsNullOrWhiteSpace(DivisionCode) = True Then

                DivisionCode = "NULL"

            Else

                DivisionCode = String.Format("'{0}'", DivisionCode)

            End If
            If String.IsNullOrWhiteSpace(ProductCode) = True Then

                ProductCode = "NULL"

            Else

                ProductCode = String.Format("'{0}'", ProductCode)

            End If

            Try

                Results = DbContext.Database.SqlQuery(Of AdvantageFramework.ViewModels.Lookup.LookupViewModel)(String.Format("EXEC [dbo].[advsp_job_component_load_by_user] @CL_CODE = {2}, @DIV_CODE = {3}, " &
                                                                                                                             "@PRD_CODE = {4}, @JOB_NUMBER = {5}, @OPEN_COMP_ONLY = {0}, " &
                                                                                                                             "@ALLOWED_PROC_CONTROLS = 'timesheet', @USER_CODE = '{1}', @SKIP = {6}, @TAKE = {7};",
                                                                                                                             0,
                                                                                                                             UserCode,
                                                                                                                             ClientCode,
                                                                                                                             DivisionCode,
                                                                                                                             ProductCode,
                                                                                                                             JobNumber,
                                                                                                                             Skip,
                                                                                                                             Take)).ToList

            Catch ex As Exception
                Results = Nothing
            End Try

            If Results Is Nothing Then Results = New List(Of ViewModels.Lookup.LookupViewModel)

            Return Results

        End Function
        Public Function GetFunctionsAndCategories(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                  ByVal EmployeeCode As String,
                                                  ByVal IncludeFunctions As Boolean, ByVal IncludeCategories As Boolean,
                                                  ByVal SearchText As String) As Generic.List(Of AdvantageFramework.ViewModels.Employee.Timesheet.NewEntryViewModel.FunctionCategory)

            Dim FunctionCategories As New Generic.List(Of AdvantageFramework.ViewModels.Employee.Timesheet.NewEntryViewModel.FunctionCategory)
            Dim FunctionCategory As AdvantageFramework.ViewModels.Employee.Timesheet.NewEntryViewModel.FunctionCategory = Nothing

            Try

                If IncludeCategories = True Then

                    For Each Ct As AdvantageFramework.Database.Entities.IndirectCategory In AdvantageFramework.Database.Procedures.IndirectCategory.LoadAllActive(DbContext)

                        FunctionCategory = New AdvantageFramework.ViewModels.Employee.Timesheet.NewEntryViewModel.FunctionCategory

                        FunctionCategory.Code = Ct.Code
                        FunctionCategory.Description = Ct.Description
                        FunctionCategory.IsFunction = False

                        FunctionCategories.Add(FunctionCategory)

                        FunctionCategory = Nothing

                    Next

                End If
                If IncludeFunctions = True Then

                    'Dim ClientCode As String = String.Empty
                    'Dim LimitFunctionsByBillingRate As Boolean = False
                    'Dim BillingRestrictedFunctionCodes As Generic.List(Of String) = Nothing

                    'Try

                    '    ClientCode = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT CL_CODE FROM JOB_LOG WHERE JOB_NUMBER = {0};", JobNumber)).SingleOrDefault

                    'Catch ex As Exception
                    '    ClientCode = String.Empty
                    'End Try
                    'If String.IsNullOrWhiteSpace(ClientCode) = False Then

                    '    Try

                    '        LimitFunctionsByBillingRate = DbContext.Database.SqlQuery(Of Boolean)(String.Format("SELECT CAST(ISNULL(LIMIT_TIME_FUNCTIONS_TO_BILLING_HIERARCHY, 0) AS BIT) FROM CLIENT WHERE CL_CODE = '{0}';", ClientCode)).SingleOrDefault

                    '    Catch ex As Exception
                    '        LimitFunctionsByBillingRate = False
                    '    End Try

                    'End If
                    'If LimitFunctionsByBillingRate = True Then

                    '    Try

                    '        BillingRestrictedFunctionCodes = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT FNC_CODE FROM BILLING_RATE WHERE CL_CODE = '{0}' AND NOT FNC_CODE IS NULL;", ClientCode)).ToList

                    '    Catch ex As Exception
                    '        BillingRestrictedFunctionCodes = Nothing
                    '    End Try

                    '    If BillingRestrictedFunctionCodes Is Nothing Then BillingRestrictedFunctionCodes = New List(Of String)

                    'End If
                    For Each Fn In AdvantageFramework.Database.Procedures.Function.LoadForEmployeeDirectTime(DbContext, EmployeeCode)

                        'If LimitFunctionsByBillingRate = False Then

                        AddFunctionToList(FunctionCategories, Fn.Code, Fn.Description)

                        'Else

                        '    If BillingRestrictedFunctionCodes.Contains(Fn.Code) = True Then

                        '        AddFunctionToList(FunctionCategories, Fn.Code, Fn.Description)

                        '    End If

                        'End If

                    Next

                End If

            Catch ex As Exception
                FunctionCategories = Nothing
            End Try

            If FunctionCategories Is Nothing Then FunctionCategories = New List(Of AdvantageFramework.ViewModels.Employee.Timesheet.NewEntryViewModel.FunctionCategory)

            Return FunctionCategories

        End Function
        Private Sub AddFunctionToList(ByRef FunctionCategories As Generic.List(Of AdvantageFramework.ViewModels.Employee.Timesheet.NewEntryViewModel.FunctionCategory),
                                      ByVal Code As String, ByVal Description As String)

            Dim FunctionCategory = New AdvantageFramework.ViewModels.Employee.Timesheet.NewEntryViewModel.FunctionCategory

            FunctionCategory.Code = Code
            FunctionCategory.Description = Description
            FunctionCategory.IsFunction = True

            FunctionCategories.Add(FunctionCategory)

            FunctionCategory = Nothing

        End Sub

#End Region

#Region " For Copy From "

        Public Function GetProjectsForEmployee(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                               ByVal EmployeeCode As String) As Generic.List(Of ViewModels.Employee.Timesheet.CopyFrom.MyProject)

            Dim MyProjects As Generic.List(Of ViewModels.Employee.Timesheet.CopyFrom.MyProject) = Nothing

            Try

                MyProjects = DbContext.Database.SqlQuery(Of ViewModels.Employee.Timesheet.CopyFrom.MyProject)(String.Format("EXEC [dbo].[usp_wv_ts_select_tasks] '{0}', '{1}';",
                                                                                                                            Me.Session.UserCode, EmployeeCode)).ToList

            Catch ex As Exception
                MyProjects = Nothing
            End Try

            If MyProjects Is Nothing Then MyProjects = New List(Of ViewModels.Employee.Timesheet.CopyFrom.MyProject)

            Return MyProjects

        End Function
        Public Function GetCalendarItems(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                         ByVal EmployeeCode As String) As Generic.List(Of AdvantageFramework.EmployeeCalendarTime.Classes.EmployeeTimeStaging)

            Dim MyCalendarItems As Generic.List(Of AdvantageFramework.EmployeeCalendarTime.Classes.EmployeeTimeStaging) = Nothing

            Try

                MyCalendarItems = AdvantageFramework.EmployeeCalendarTime.LoadEmployeeTimeStaging(DbContext, EmployeeCode).ToList

            Catch ex As Exception
                MyCalendarItems = Nothing
            End Try

            If MyCalendarItems Is Nothing Then MyCalendarItems = New List(Of AdvantageFramework.EmployeeCalendarTime.Classes.EmployeeTimeStaging)

            Return MyCalendarItems

        End Function
        Public Function GetTemplateItems(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                         ByVal EmployeeCode As String) As Generic.List(Of AdvantageFramework.ViewModels.Employee.Timesheet.CopyFrom.MyTemplate)

            Dim MyTemplates As Generic.List(Of AdvantageFramework.ViewModels.Employee.Timesheet.CopyFrom.MyTemplate) = Nothing

            Try

            Catch ex As Exception
                MyTemplates = Nothing
            End Try

            If MyTemplates Is Nothing Then MyTemplates = New List(Of ViewModels.Employee.Timesheet.CopyFrom.MyTemplate)

            Return MyTemplates

        End Function

#End Region

#Region " For Copy To"
        Public Function CopyTimesheet(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                      ByVal Type As CopyToType, ByVal EmployeeCode As String, ByVal SourceDate As Date, ByVal TargetDate As Date,
                                      ByVal IncludeHours As Boolean, ByVal IncludeComments As Boolean, ByVal IsSingleDay As Boolean,
                                      ByRef ReturnMessage As String, ByRef RowsSaved As Integer, ByRef RowsFailed As Integer) As Boolean

            Dim Copied As Boolean = False
            Dim UserStartWeekOn As DayOfWeek = AdvantageFramework.EmployeeTimesheet.GetUserStartWeekOn(DbContext)
            Dim Messages As New Generic.List(Of String)

            SourceDate = AdvantageFramework.EmployeeTimesheet.FirstDayOfWeek(SourceDate, UserStartWeekOn)
            TargetDate = AdvantageFramework.EmployeeTimesheet.FirstDayOfWeek(TargetDate, UserStartWeekOn)

            If SourceDate = TargetDate Then

                ReturnMessage = "Cannot copy timesheet to itself"
                Copied = False

            Else

                Dim DayOffSet As Long = 0
                Dim Timesheet As AdvantageFramework.ViewModels.Employee.Timesheet.TimesheetViewModel = Nothing
                Dim UserSettings As AdvantageFramework.ViewModels.Employee.Timesheet.Settings = Nothing

                UserSettings = GetUserSettings(DbContext)
                Timesheet = GetTimeSheet(DbContext, EmployeeCode, SourceDate, 7, TimesheetSort.NewestFirst, TimesheetGroupBy.None, UserSettings, ReturnMessage)

                DayOffSet = DateDiff(DateInterval.Day, SourceDate, TargetDate)

                If Timesheet IsNot Nothing Then

                    'Dim SbError As New System.Text.StringBuilder
                    Timesheet.UserSettings = UserSettings

                    Select Case Type
                        Case CopyToType.EntireTimesheet

                            For Each Row As AdvantageFramework.ViewModels.Employee.Timesheet.TimesheetLineViewModel In Timesheet.Lines

                                If CopyTimesheetRow(DbContext, Row, EmployeeCode, DayOffSet, IncludeHours, IncludeComments, ReturnMessage) = True Then

                                    RowsSaved += 1

                                Else

                                    RowsFailed += 1

                                    If String.IsNullOrWhiteSpace(ReturnMessage) = False Then

                                        Messages.Add(ReturnMessage)

                                    End If

                                End If

                            Next

                        Case CopyToType.SelectedRows

                    End Select

                    If RowsSaved > 0 Then

                        Copied = True
                        DeleteMissingTimeDetail(DbContext, EmployeeCode)
                        AdvantageFramework.EmployeeTimesheet.ProcessMissingTime(Session, EmployeeCode, TargetDate)

                    End If
                    If Messages.Count > 0 Then

                        Try

                            Dim ar() As String

                            ar = (From Entity In Messages
                                  Select Entity).Distinct.ToArray

                            ReturnMessage = String.Join(", ", ar)

                        Catch ex As Exception
                            ReturnMessage = "Error copying time."
                        End Try

                    End If

                End If

            End If

            Return Copied

        End Function
        Private Function CopyTimesheetRow(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                          ByVal Row As AdvantageFramework.ViewModels.Employee.Timesheet.TimesheetLineViewModel,
                                          ByVal EmployeeCode As String, ByVal OffSet As Long,
                                          ByVal IncludeHours As Boolean, ByVal IncludeComments As Boolean,
                                          ByRef ErrorMessage As String) As Boolean

            Dim ErrorsStringBuilder As New System.Text.StringBuilder
            Dim FailCounter As Integer = 0
            Dim SuccessCounter As Integer = 0
            Dim RowCopied As Boolean = True
            Dim JobNumber As Integer = 0
            Dim JobComponentNumber As Short = 0
            Dim FunctionCategoryCode As String = String.Empty
            Dim DepartmentTeamCode As String = String.Empty
            Dim TimeType As String = String.Empty
            Dim AlertID As Integer = 0

            Dim Hours As Decimal = 0.00
            Dim Comment As String = String.Empty
            Dim NewEmployeeTimeID As Integer = 0
            Dim NewEmployeeTimeDetailID As Integer = 0
            Dim Success As Boolean = False
            Dim ProductCategory As String = "" 'Do we need this anymore?

            If Row.JobNumber IsNot Nothing Then JobNumber = Row.JobNumber
            If Row.JobComponentNumber IsNot Nothing Then JobComponentNumber = Row.JobComponentNumber
            ErrorMessage = String.Empty

            If JobNumber > 0 AndAlso JobComponentNumber > 0 Then

                TimeType = "D"

            Else

                TimeType = "N"

            End If
            If String.IsNullOrWhiteSpace(Row.FunctionCategory) = False Then

                FunctionCategoryCode = Row.FunctionCategory

            End If
            If String.IsNullOrWhiteSpace(Row.DepartmentTeamCode) = False Then

                DepartmentTeamCode = Row.DepartmentTeamCode

            End If
            If IncludeComments = False AndAlso Row.ClientCommentRequired IsNot Nothing AndAlso Row.ClientCommentRequired = True Then

                IncludeComments = True

            End If
            For Each Entry As AdvantageFramework.ViewModels.Employee.Timesheet.TimesheetEntryViewModel In Row.Entries

                Try

                    If AdvantageFramework.EmployeeTimesheet.CopyTimeEntry(DbContext, Session.UserCode, Entry.EmployeeTimeID, Entry.EmployeeTimeDetailID, TimeType, DateAdd(DateInterval.Day, OffSet, Entry.Date),
                                                                          EmployeeCode, IncludeHours, ErrorMessage) = False Then

                        If ErrorsStringBuilder.ToString().Contains(ErrorMessage) = False Then

                            ErrorsStringBuilder.Append(ErrorMessage)
                            ErrorsStringBuilder.Append(Environment.NewLine)

                        End If

                        FailCounter += 1

                    Else

                        SuccessCounter += 1

                    End If

                Catch ex As Exception
                End Try

            Next

            RowCopied = SuccessCounter > 0

            Return RowCopied

        End Function

#End Region

#Region " Entry edit "
        Public Function GetTimeEntry(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal IsDirectTime As Boolean,
                                     ByVal EmployeeTimeID As Integer, ByVal EmployeeTimeDetailID As Integer) As AdvantageFramework.ViewModels.Employee.Timesheet.TimesheetEntryViewModel

            Dim Entry As New AdvantageFramework.ViewModels.Employee.Timesheet.TimesheetEntryViewModel
            Dim Comments As AdvantageFramework.Database.Entities.EmployeeTimeComment = Nothing

            'STORED PROC???
            'Need to load CanDelete ?
            'Need to load CannotEditDueToProcessingControl ?
            'Need to load Comments ?
            'Need to load CommentsRequired ?
            'Need to load HasStopwatch ?

            Entry.EditFlag = CheckEditStatus(DbContext, EmployeeTimeID, EmployeeTimeDetailID)

            If IsDirectTime = True Then

                Dim EmployeeTimeDetail As AdvantageFramework.Database.Entities.EmployeeTimeDetail = Nothing

                EmployeeTimeDetail = AdvantageFramework.Database.Procedures.EmployeeTimeDetail.LoadByEmployeeTimeIDAndEmployeeTimeDetailID(DbContext, EmployeeTimeID, EmployeeTimeDetailID)

                If EmployeeTimeDetail IsNot Nothing Then

                    Entry.EmployeeCode = EmployeeTimeDetail.EmployeeTime.EmployeeCode
                    Entry.Date = EmployeeTimeDetail.EmployeeTime.Date
                    Entry.EmployeeTimeID = EmployeeTimeID
                    Entry.EmployeeTimeDetailID = EmployeeTimeDetailID
                    Entry.SequenceNumber = EmployeeTimeDetail.SequenceNumber
                    Entry.Hours = EmployeeTimeDetail.Hours
                    Entry.AlertID = EmployeeTimeDetail.AlertID
                    Entry.JobNumber = EmployeeTimeDetail.JobNumber
                    Entry.JobComponentNumber = EmployeeTimeDetail.JobComponentNumber
                    Entry.FunctionCategoryCode = EmployeeTimeDetail.FunctionCode
                    Entry.TimeType = "D"

                    If Entry.JobNumber IsNot Nothing AndAlso Entry.JobComponentNumber IsNot Nothing AndAlso
                    Entry.JobNumber > 0 AndAlso Entry.JobComponentNumber > 0 Then

                        Try

                            Dim Job As AdvantageFramework.Database.Entities.Job = Nothing
                            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing

                            Job = (From Entity In DbContext.GetQuery(Of Database.Entities.Job).Include("Client").Include("Division").Include("Product")
                                   Where Entity.Number = Entry.JobNumber).SingleOrDefault

                            If Job IsNot Nothing Then

                                JobComponent = (From Entity In DbContext.GetQuery(Of Database.Entities.JobComponent)
                                                Where Entity.JobNumber = Entry.JobNumber AndAlso
                                                              Entity.Number = Entry.JobComponentNumber
                                                Select Entity).SingleOrDefault

                                If JobComponent IsNot Nothing Then

                                    If Job.Description = JobComponent.Description Then

                                        Entry.JobDisplay = Entry.JobNumber.ToString.PadLeft(6, "0") & "/" & Entry.JobComponentNumber.ToString.PadLeft(3, "0") & " - " & JobComponent.Description

                                    Else

                                        Entry.JobDisplay = Entry.JobNumber.ToString.PadLeft(6, "0") & "/" & Entry.JobComponentNumber.ToString.PadLeft(3, "0") & " - " & Job.Description & " | " & JobComponent.Description

                                    End If

                                End If
                                If Job.Client IsNot Nothing AndAlso Job.Division IsNot Nothing AndAlso Job.Product IsNot Nothing Then

                                    Entry.ClientDisplay = AdvantageFramework.Database.Procedures.Product.BuildClientDivisionProductDisplay(Job.Client.Name, Job.Division.Name, Job.Product.Name)
                                    Entry.ClientName = Job.Client.Name
                                    Entry.DivisionName = Job.Division.Name
                                    Entry.ProductName = Job.Product.Name

                                End If

                            End If

                        Catch ex As Exception
                        End Try

                    End If
                    If Entry.AlertID IsNot Nothing AndAlso Entry.AlertID > 0 Then

                        Try

                            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing

                            Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, Entry.AlertID)

                            If Alert IsNot Nothing Then

                                Entry.AssignmentDisplay = Alert.Subject
                                Entry.AlertSubject = Alert.Subject

                            End If

                        Catch ex As Exception
                        End Try

                    End If
                    If String.IsNullOrWhiteSpace(Entry.FunctionCategoryCode) = False Then

                        Try

                            Dim FunctionEntity As AdvantageFramework.Database.Entities.Function = Nothing

                            FunctionEntity = AdvantageFramework.Database.Procedures.Function.LoadByFunctionCode(DbContext, Entry.FunctionCategoryCode)

                            If FunctionEntity IsNot Nothing Then

                                Entry.FunctionCategoryDisplay = FunctionEntity.Description

                            End If

                        Catch ex As Exception
                        End Try

                    End If

                End If

            Else

                Dim EmployeeTimeIndirect As AdvantageFramework.Database.Entities.EmployeeTimeIndirect = Nothing

                EmployeeTimeIndirect = AdvantageFramework.Database.Procedures.EmployeeTimeIndirect.LoadByEmployeeTimeIDAndEmployeeTimeIndirectID(DbContext, EmployeeTimeID, EmployeeTimeDetailID)

                If EmployeeTimeIndirect IsNot Nothing Then

                    Entry.EmployeeCode = EmployeeTimeIndirect.EmployeeTime.EmployeeCode
                    Entry.Date = EmployeeTimeIndirect.EmployeeTime.Date
                    Entry.EmployeeTimeID = EmployeeTimeID
                    Entry.EmployeeTimeDetailID = EmployeeTimeDetailID
                    Entry.SequenceNumber = EmployeeTimeIndirect.SequenceNumber
                    Entry.Hours = EmployeeTimeIndirect.Hours
                    Entry.FunctionCategoryCode = EmployeeTimeIndirect.Category
                    Entry.TimeType = "N"

                    If String.IsNullOrWhiteSpace(Entry.FunctionCategoryCode) = False Then

                        Try

                            Dim TimeCategory As AdvantageFramework.Database.Entities.IndirectCategory = Nothing

                            TimeCategory = AdvantageFramework.Database.Procedures.IndirectCategory.LoadByIndirectCategoryCode(DbContext, Entry.FunctionCategoryCode)

                            If TimeCategory IsNot Nothing Then

                                Entry.FunctionCategoryDisplay = TimeCategory.Description

                            End If

                        Catch ex As Exception
                        End Try

                    End If

                End If

            End If

            Return Entry

        End Function
        Public Function GetTimeEntryComment(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal IsDirectTime As Boolean,
                                            ByVal EmployeeTimeID As Integer, ByVal EmployeeTimeDetailID As Integer) As AdvantageFramework.Database.Entities.EmployeeTimeComment

            Dim EmployeeTimeComment As AdvantageFramework.Database.Entities.EmployeeTimeComment = Nothing
            Dim TimeType As String = "D"

            If IsDirectTime = False Then TimeType = "N"

            EmployeeTimeComment = AdvantageFramework.Database.Procedures.EmployeeTimeComment.LoadByEmployeeTimeIDAndEmployeeTimeDetailIDAndEmployeeTimeSource(DbContext,
                                                                                                                                                              EmployeeTimeID,
                                                                                                                                                              EmployeeTimeDetailID,
                                                                                                                                                              TimeType)

            If EmployeeTimeComment Is Nothing Then

                EmployeeTimeComment = New Database.Entities.EmployeeTimeComment

                EmployeeTimeComment.EmployeeTimeID = EmployeeTimeID
                EmployeeTimeComment.EmployeeTimeDetailID = EmployeeTimeDetailID
                EmployeeTimeComment.SequenceNumber = EmployeeTimeDetailID
                EmployeeTimeComment.EmployeeTimeSource = TimeType

            End If

            Return EmployeeTimeComment

        End Function

#End Region

#Region " Settings "
        Public Function GetUserSettings(ByVal DbContext As AdvantageFramework.Database.DbContext) As AdvantageFramework.ViewModels.Employee.Timesheet.Settings

            Return AdvantageFramework.EmployeeTimesheet.GetUserSettings(DbContext)

        End Function
        Public Function SaveUserSettings(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                         ByVal UserSettings As AdvantageFramework.ViewModels.Employee.Timesheet.Settings) As Boolean

            Return AdvantageFramework.EmployeeTimesheet.SaveUserSettings(DbContext, UserSettings)

        End Function
        Public Function GetAgencySettings(ByVal DbContext As AdvantageFramework.Database.DbContext) As AdvantageFramework.ViewModels.Employee.Timesheet.AgencySettings

            Return AdvantageFramework.EmployeeTimesheet.GetAgencySettings(DbContext)

        End Function

#End Region

#Region " Helpers "
        Public Function IsCommentRequiredClient(ByRef DbContext As AdvantageFramework.Database.DbContext, ByVal ClientCode As String) As Boolean

            Try

                Return DbContext.Database.SqlQuery(Of Boolean)(String.Format("SELECT [CommentIsRequired] = CAST(ISNULL(C.REQ_TIME_COMMENT, 0) AS BIT) FROM CLIENT C WITH(NOLOCK) WHERE C.CL_CODE = '{0}';",
                                                                             ClientCode)).SingleOrDefault

            Catch ex As Exception
                Return False
            End Try

        End Function
        Public Function IsCommentRequiredJob(ByRef DbContext As AdvantageFramework.Database.DbContext, ByVal JobNumber As Integer) As Boolean

            Try

                Return DbContext.Database.SqlQuery(Of Boolean)(String.Format("EXEC [dbo].[usp_wv_ts_DetailRequireComment] {0}, NULL, NULL;", JobNumber)).SingleOrDefault

            Catch ex As Exception
                Return False
            End Try

        End Function
        Private Function PostPeriodClosed(ByVal [Date] As Date, Optional ByRef ErrorMessage As String = "") As Boolean
            Try
                Dim ReturnValue As Boolean = False
                Using MyConn As New System.Data.SqlClient.SqlConnection(Me.Session.ConnectionString)
                    Dim MyCommand As New System.Data.SqlClient.SqlCommand()
                    With MyCommand
                        .CommandType = CommandType.StoredProcedure
                        .CommandText = "usp_wv_ts_check_postperiod"
                        .Connection = MyConn
                    End With

                    Dim pThisDate As New System.Data.SqlClient.SqlParameter("@ThisDate", SqlDbType.SmallDateTime)
                    pThisDate.Value = [Date]
                    Dim pReturn As New System.Data.SqlClient.SqlParameter("@Return", SqlDbType.Int)
                    pReturn.Direction = ParameterDirection.Output
                    pReturn.Value = [Date]

                    MyCommand.Parameters.Add(pThisDate)
                    MyCommand.Parameters.Add(pReturn)

                    MyConn.Open()

                    MyCommand.ExecuteNonQuery()

                    If pReturn.Value = 0 Then
                        ReturnValue = True
                    Else
                        ReturnValue = False
                    End If

                    If MyConn.State = ConnectionState.Open Then
                        MyConn.Close()
                        MyConn.Dispose()
                    End If

                End Using
                ErrorMessage = ""
                Return ReturnValue
            Catch ex As Exception
                ErrorMessage = ex.Message.ToString()
                Return False
            End Try
        End Function
        Private Function DeleteMissingTimeDetail(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                 ByVal EmployeeCode As String) As Boolean

            Dim Success As Boolean = True

            Try

                DbContext.Database.ExecuteSqlCommand(String.Format("EXEC [dbo].[usp_wv_delete_missing_time_dtl] '(0)';"))

            Catch ex As Exception
                Success = False
            End Try

            Return Success

        End Function
        Private Function IsInWeek(ByVal TheDate As Date, ByRef CurrentWeekStart As Date, ByRef CurrentWeekEnd As Date) As Boolean
            Try

                Dim TheDateWeekStart As Date
                Dim TheDateWeekEnd As Date

                GetDateRange(TheDate, TheDateWeekStart, TheDateWeekEnd)

                If TheDateWeekStart = CurrentWeekStart AndAlso TheDateWeekEnd = CurrentWeekEnd Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                Return False
            End Try
        End Function
        Public Function GetMyEmployees(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext, ByVal EmployeeCode As String) As Generic.List(Of SearchResult)

            Dim Results As New Generic.List(Of SearchResult)
            Dim Employees As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing
            Dim ResultQuery As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Views.Employee) = Nothing
            Dim HasSelf As Boolean = False

            Try

                Employees = AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActiveEmployeesByUser(DbContext, SecurityDbContext, DbContext.UserCode).ToList

                If Employees IsNot Nothing Then

                    Dim Result As SearchResult = Nothing

                    For Each Employee As AdvantageFramework.Database.Views.Employee In Employees

                        Try

                            If Employee.Code = EmployeeCode Then HasSelf = True

                            Result = New SearchResult

                            Result.Code = Employee.Code
                            Result.Description = Employee.ToString

                            Results.Add(Result)

                            Result = Nothing

                        Catch ex As Exception
                            Result = Nothing
                        End Try

                    Next

                    If HasSelf = False Then

                        Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

                        Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode)

                        If Employee IsNot Nothing Then

                            Try

                                Result = New SearchResult

                                Result.Code = Employee.Code
                                Result.Description = Employee.ToString

                                Results.Add(Result)

                                Result = Nothing

                            Catch ex As Exception
                                Result = Nothing
                            End Try

                        End If

                    End If

                End If

            Catch ex As Exception
                Results = Nothing
            End Try

            If Results Is Nothing Then Results = New List(Of SearchResult)

            Return Results

        End Function
        Public Function CanEditEntry(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                     ByVal EmployeeTimeID As Integer, ByVal EmployeeTimeDetailID As Integer) As Boolean

            Dim CanEdit As Boolean = False
            Dim CheckEditStatus As Integer = 0

            CheckEditStatus = DbContext.Database.SqlQuery(Of Integer)(String.Format("EXEC [dbo].[usp_wv_ts_Check_Edit_Status] {0}, {1};", EmployeeTimeID, EmployeeTimeDetailID)).SingleOrDefault

            If CheckEditStatus = 0 OrElse CheckEditStatus = 1 Then

                CanEdit = True

            End If

            Return CanEdit

        End Function
        Public Function GetJobDisplay(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short) As String

            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing
            Dim Sb As New System.Text.StringBuilder

            JobComponent = (From Entity In DbContext.GetQuery(Of Database.Entities.JobComponent).Include("Job")
                            Where Entity.JobNumber = JobNumber And Entity.Number = JobComponentNumber
                            Select Entity).SingleOrDefault

            If JobComponent IsNot Nothing Then

                Sb.Append(JobComponent.JobNumber.ToString.PadLeft(6, "0"))
                Sb.Append("/")
                Sb.Append(JobComponent.Number.ToString.PadLeft(2, "0"))
                Sb.Append(" - ")
                If JobComponent.Job.Description <> JobComponent.Description Then
                    Sb.Append(JobComponent.Job.Description)
                    Sb.Append(" | ")
                End If
                Sb.Append(JobComponent.Description)

            End If

            Return Sb.ToString

        End Function
        Public Function GetClientDivisionProductDisplay(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobNumber As Integer,
                                                        ByRef ClientName As String,
                                                        ByRef DivisionName As String,
                                                        ByRef ProductName As String) As String

            Dim Job As AdvantageFramework.Database.Entities.Job = Nothing
            Dim Sb As New System.Text.StringBuilder

            Job = (From Entity In DbContext.GetQuery(Of Database.Entities.Job).Include("Client").Include("Division").Include("Product")
                   Where Entity.Number = JobNumber
                   Select Entity).SingleOrDefault

            If Job IsNot Nothing Then

                ClientName = Job.Client.Name
                DivisionName = Job.Division.Name
                ProductName = Job.Product.Name

                Sb.Append(Job.Client.Name)

                If Job.Division.Name <> Job.Client.Name Then

                    Sb.Append(" | ")
                    Sb.Append(Job.Division.Name)

                End If
                If Job.Division.Name <> Job.Product.Name Then

                    Sb.Append(" | ")
                    Sb.Append(Job.Product.Name)

                End If

            End If

            Return Sb.ToString

        End Function
        'Public Function GetClientDivisionProductDisplay(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String) As String

        'End Function
        Public Function GetFunctionCategoryDescription(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal FunctionCategoryCode As String, ByVal IsFunction As Boolean) As String

            Dim Description As String = String.Empty

            If IsFunction = True Then

                Dim Fn As AdvantageFramework.Database.Entities.Function = Nothing

                Fn = AdvantageFramework.Database.Procedures.Function.LoadByFunctionCode(DbContext, FunctionCategoryCode)

                If Fn IsNot Nothing Then

                    Description = Fn.Description

                End If

            Else

                Dim TimeCategory As AdvantageFramework.Database.Entities.IndirectCategory = Nothing

                TimeCategory = AdvantageFramework.Database.Procedures.IndirectCategory.LoadByIndirectCategoryCode(DbContext, FunctionCategoryCode)

                If TimeCategory IsNot Nothing Then

                    Description = TimeCategory.Description

                End If

            End If

            Return Description

        End Function
        Public Function GetAssignmentSubject(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertID As Integer) As String

            Dim Subject As String = String.Empty
            Dim Assignment As AdvantageFramework.Database.Entities.Alert = Nothing

            Assignment = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertID)

            If Assignment IsNot Nothing Then

                Subject = Assignment.Subject

            End If

            Return Subject

        End Function
        Private Function CheckEditStatus(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                        ByVal EmployeeTimeID As Integer, ByVal EmployeeTimeDetailID As Integer) As AdvantageFramework.Timesheet.TimesheetEditType

            If EmployeeTimeID = 0 Or EmployeeTimeDetailID = 0 Then

                Return AdvantageFramework.Timesheet.TimesheetEditType.Edit

            Else

                Dim ReturnInteger As Integer = 0

                Try

                    ReturnInteger = DbContext.Database.SqlQuery(Of Integer)(String.Format("EXEC [dbo].[usp_wv_ts_Check_Edit_Status] {0}, {1}", EmployeeTimeID, EmployeeTimeDetailID)).SingleOrDefault

                Catch ex As Exception
                    ReturnInteger = 0
                End Try

                Return CType(ReturnInteger, AdvantageFramework.Timesheet.TimesheetEditType)

            End If

        End Function

#End Region

#Region " Summaries "
        Public Function GetTimeSummary(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                       ByVal EmployeeCode As String, ByVal DaysToDisplay As Short, ByVal StartDate As Date?) As Generic.List(Of AdvantageFramework.ViewModels.Employee.Timesheet.TimeSummaryViewModel)

            Dim Summaries As Generic.List(Of AdvantageFramework.ViewModels.Employee.Timesheet.TimeSummaryViewModel) = Nothing
            Dim SqlParameterEmployeeCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterDaysToDisplay As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterStartDate As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterEmployeeCode = New System.Data.SqlClient.SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
            SqlParameterDaysToDisplay = New System.Data.SqlClient.SqlParameter("@DAYS_TO_DISPLAY", SqlDbType.SmallInt)
            SqlParameterStartDate = New System.Data.SqlClient.SqlParameter("@START_DATE", SqlDbType.SmallDateTime)

            SqlParameterEmployeeCode.Value = EmployeeCode
            SqlParameterDaysToDisplay.Value = If(DaysToDisplay > 0, DaysToDisplay, System.DBNull.Value)
            SqlParameterStartDate.Value = If(StartDate IsNot Nothing, StartDate, Now.Date)

            Try

                Summaries = DbContext.Database.SqlQuery(Of AdvantageFramework.ViewModels.Employee.Timesheet.TimeSummaryViewModel)("EXEC [dbo].[usp_wv_dto_Get_Current_Weekly_Time_Total] @EMP_CODE, @DAYS_TO_DISPLAY, @START_DATE;",
                                                                                                                                   SqlParameterEmployeeCode, SqlParameterDaysToDisplay, SqlParameterStartDate).ToList

            Catch ex As Exception
                Summaries = Nothing
            End Try

            If Summaries Is Nothing Then Summaries = New List(Of ViewModels.Employee.Timesheet.TimeSummaryViewModel)

            Return Summaries

        End Function
        Public Function GetMonthlyHours(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeCode As String) As AdvantageFramework.ViewModels.Employee.Timesheet.MonthlyHoursViewModel

            Dim MonthlyHours As New AdvantageFramework.ViewModels.Employee.Timesheet.MonthlyHoursViewModel
            Dim WeeklyGoals As New AdvantageFramework.ViewModels.Employee.Timesheet.WeeklyGoalsViewModel
            Dim FirstOfMonth As New Date(Now.Year, Now.Month, 1)
            Dim LastOfMonth As New Date(Now.Year, Now.Month, DateTime.DaysInMonth(Now.Year, Now.Month))
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

            Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode)

            If Employee IsNot Nothing Then

                Try

                    WeeklyGoals.SundayGoal = Employee.SundayHours
                    WeeklyGoals.MondayGoal = Employee.MondayHours
                    WeeklyGoals.TuesdayGoal = Employee.TuesdayHours
                    WeeklyGoals.WednesdayGoal = Employee.WednesdayHours
                    WeeklyGoals.ThursdayGoal = Employee.ThursdayHours
                    WeeklyGoals.FridayGoal = Employee.FridayHours
                    WeeklyGoals.SauturdayGoal = Employee.SaturdayHours

                    MonthlyHours.Goal = WeeklyGoals.Total * 4

                Catch ex As Exception
                    MonthlyHours.Goal = -1
                End Try

                Try

                    MonthlyHours.Hours = (From Entity In AdvantageFramework.Database.Procedures.EmployeeTime.LoadByEmployeeCodeAndDateRange(DbContext, EmployeeCode, FirstOfMonth, LastOfMonth)
                                          Select Entity.TotalDirectHours).Sum

                Catch ex As Exception
                    MonthlyHours.Hours = -1
                End Try

            End If


            Return MonthlyHours

        End Function

#End Region

#End Region
        Public Sub New(ByVal Session As AdvantageFramework.Security.Session)

            MyBase.New(Session)

        End Sub

    End Class
    <Serializable()> Public Class TimesheetController
        Inherits AdvantageFramework.Controller.BaseController

        Public Sub New(ByVal Session As AdvantageFramework.Security.Session)

            MyBase.New(Session)

        End Sub

        Public Function GetTimesheetRows(ByVal Timesheet As AdvantageFramework.DTO.Employee.Timesheet) As Generic.List(Of AdvantageFramework.DTO.Employee.Timesheet.Row)

            GetTimesheetRows = GetTimesheetRows(Timesheet.EmployeeCode, Timesheet.StartDate)

        End Function
        Public Function GetTimesheetRows(ByVal EmployeeCode As String, ByVal StartDate As Date)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                GetTimesheetRows = GetTimesheetRows(DbContext, EmployeeCode, StartDate)

            End Using

        End Function
        Private Function GetTimesheetRows(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeCode As String, ByVal StartDate As Date) As Generic.List(Of AdvantageFramework.DTO.Employee.Timesheet.Row)

            'objects
            Dim TimesheetRows As Generic.List(Of AdvantageFramework.DTO.Employee.Timesheet.Row) = Nothing
            Dim EmployeeCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim StartDateSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim UserCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing

            Try

                EmployeeCodeSqlParameter = New System.Data.SqlClient.SqlParameter("EmployeeCode", EmployeeCode)
                StartDateSqlParameter = New System.Data.SqlClient.SqlParameter("StartDate", StartDate)
                UserCodeSqlParameter = New System.Data.SqlClient.SqlParameter("UserCode", Me.Session.UserCode)

                TimesheetRows = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Employee.Timesheet.Row)("EXEC [dbo].[advsp_timesheet_load_by_employee] @EmployeeCode, @StartDate, @UserCode", EmployeeCodeSqlParameter, StartDateSqlParameter, UserCodeSqlParameter).ToList

            Catch ex As Exception
                TimesheetRows = Nothing
            Finally
                GetTimesheetRows = TimesheetRows
            End Try

        End Function

        Public Function SaveTimesheetRows(ByVal SecuritySession As AdvantageFramework.Security.Session,
                                          ByVal EmployeeCode As String, ByVal Rows As Generic.List(Of AdvantageFramework.DTO.Employee.Timesheet.Row)) As Boolean

            If Rows IsNot Nothing AndAlso Rows.Count > 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                    For Each Row As AdvantageFramework.DTO.Employee.Timesheet.Row In Rows

                        SaveTimesheetRow(DbContext, SecuritySession, EmployeeCode, Row)

                    Next

                End Using

            End If

            Return True

        End Function
        Public Function SaveTimesheetRow(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SecuritySession As AdvantageFramework.Security.Session,
                                         ByVal EmployeeCode As String, ByVal TimesheetRow As AdvantageFramework.DTO.Employee.Timesheet.Row) As Boolean

            Dim EtID As Integer = 0
            Dim EtDtlID As Integer = 0
            Dim EntryDate As Date? = Nothing
            Dim Hours As Decimal = 0
            Dim AlertID As Integer = 0
            Dim FunctionCategory As String = String.Empty
            Dim DepartmentTeamCode As String = String.Empty
            Dim ProductCategory As String = String.Empty
            Dim JobNumber As Integer = 0
            Dim JobComponentNumber As Short = 0
            Dim Comments As String = String.Empty

            FunctionCategory = TimesheetRow.FunctionCode
            AlertID = If(TimesheetRow.AlertID IsNot Nothing, TimesheetRow.AlertID, 0)
            JobNumber = If(TimesheetRow.JobNumber IsNot Nothing, TimesheetRow.JobNumber, 0)
            JobComponentNumber = If(TimesheetRow.JobComponentNumber IsNot Nothing, TimesheetRow.JobComponentNumber, 0)
            DepartmentTeamCode = TimesheetRow.DepartmentTeamCode

            'Day 1
            EtID = 0
            EtDtlID = 0
            EntryDate = Nothing
            Hours = 0

            EtID = If(TimesheetRow.Day1ID IsNot Nothing, TimesheetRow.Day1ID, 0)
            EtDtlID = If(TimesheetRow.Day1DetailID IsNot Nothing, TimesheetRow.Day1DetailID, 0)

            EntryDate = TimesheetRow.Day1Date
            Hours = If(TimesheetRow.Day1Hours IsNot Nothing, TimesheetRow.Day1Hours, 0)

            If (EtDtlID = 0) AndAlso (Hours = 0) Then
                'need to save new zero hour??
            Else

                AdvantageFramework.EmployeeTimesheet.SaveTimesheetDay(SecuritySession, DbContext, EtID, EtDtlID, EmployeeCode, EntryDate, FunctionCategory,
                                                                      Hours, JobNumber, JobComponentNumber, DepartmentTeamCode, ProductCategory,
                                                                      SecuritySession.UserCode, Comments, AlertID, Nothing)

            End If
            'Day 2
            EtID = 0
            EtDtlID = 0
            EntryDate = Nothing
            Hours = 0

            EtID = If(TimesheetRow.Day2ID IsNot Nothing, TimesheetRow.Day2ID, 0)
            EtDtlID = If(TimesheetRow.Day2DetailID IsNot Nothing, TimesheetRow.Day2DetailID, 0)

            EntryDate = TimesheetRow.Day2Date
            Hours = If(TimesheetRow.Day2Hours IsNot Nothing, TimesheetRow.Day2Hours, 0)

            If (EtDtlID = 0) AndAlso (Hours = 0) Then
                'need to save new zero hour??
            Else

                AdvantageFramework.EmployeeTimesheet.SaveTimesheetDay(SecuritySession, DbContext, EtID, EtDtlID, EmployeeCode, EntryDate, FunctionCategory,
                                                                      Hours, JobNumber, JobComponentNumber, DepartmentTeamCode, ProductCategory,
                                                                      SecuritySession.UserCode, Comments, AlertID, Nothing)

            End If
            'Day 3
            EtID = 0
            EtDtlID = 0
            EntryDate = Nothing
            Hours = 0

            EtID = If(TimesheetRow.Day3ID IsNot Nothing, TimesheetRow.Day3ID, 0)
            EtDtlID = If(TimesheetRow.Day3DetailID IsNot Nothing, TimesheetRow.Day3DetailID, 0)

            EntryDate = TimesheetRow.Day3Date
            Hours = If(TimesheetRow.Day3Hours IsNot Nothing, TimesheetRow.Day3Hours, 0)

            If (EtDtlID = 0) AndAlso (Hours = 0) Then
                'need to save new zero hour??
            Else

                AdvantageFramework.EmployeeTimesheet.SaveTimesheetDay(SecuritySession, DbContext, EtID, EtDtlID, EmployeeCode, EntryDate, FunctionCategory,
                                                                      Hours, JobNumber, JobComponentNumber, DepartmentTeamCode, ProductCategory,
                                                                      SecuritySession.UserCode, Comments, AlertID, Nothing)

            End If
            'Day 4
            EtID = 0
            EtDtlID = 0
            EntryDate = Nothing
            Hours = 0

            EtID = If(TimesheetRow.Day4ID IsNot Nothing, TimesheetRow.Day4ID, 0)
            EtDtlID = If(TimesheetRow.Day4DetailID IsNot Nothing, TimesheetRow.Day4DetailID, 0)

            EntryDate = TimesheetRow.Day4Date
            Hours = If(TimesheetRow.Day4Hours IsNot Nothing, TimesheetRow.Day4Hours, 0)

            If (EtDtlID = 0) AndAlso (Hours = 0) Then
                'need to save new zero hour??
            Else

                AdvantageFramework.EmployeeTimesheet.SaveTimesheetDay(SecuritySession, DbContext, EtID, EtDtlID, EmployeeCode, EntryDate, FunctionCategory,
                                                                      Hours, JobNumber, JobComponentNumber, DepartmentTeamCode, ProductCategory,
                                                                      SecuritySession.UserCode, Comments, AlertID, Nothing)

            End If
            'Day 5
            EtID = 0
            EtDtlID = 0
            EntryDate = Nothing
            Hours = 0

            EtID = If(TimesheetRow.Day5ID IsNot Nothing, TimesheetRow.Day5ID, 0)
            EtDtlID = If(TimesheetRow.Day5DetailID IsNot Nothing, TimesheetRow.Day5DetailID, 0)

            EntryDate = TimesheetRow.Day5Date
            Hours = If(TimesheetRow.Day5Hours IsNot Nothing, TimesheetRow.Day5Hours, 0)

            If (EtDtlID = 0) AndAlso (Hours = 0) Then
                'need to save new zero hour??
            Else

                AdvantageFramework.EmployeeTimesheet.SaveTimesheetDay(SecuritySession, DbContext, EtID, EtDtlID, EmployeeCode, EntryDate, FunctionCategory,
                                                                      Hours, JobNumber, JobComponentNumber, DepartmentTeamCode, ProductCategory,
                                                                      SecuritySession.UserCode, Comments, AlertID, Nothing)

            End If
            'Day 6
            EtID = 0
            EtDtlID = 0
            EntryDate = Nothing
            Hours = 0

            EtID = If(TimesheetRow.Day6ID IsNot Nothing, TimesheetRow.Day6ID, 0)
            EtDtlID = If(TimesheetRow.Day6DetailID IsNot Nothing, TimesheetRow.Day6DetailID, 0)

            EntryDate = TimesheetRow.Day6Date
            Hours = If(TimesheetRow.Day6Hours IsNot Nothing, TimesheetRow.Day6Hours, 0)

            If (EtDtlID = 0) AndAlso (Hours = 0) Then
                'need to save new zero hour??
            Else

                AdvantageFramework.EmployeeTimesheet.SaveTimesheetDay(SecuritySession, DbContext, EtID, EtDtlID, EmployeeCode, EntryDate, FunctionCategory,
                                                                      Hours, JobNumber, JobComponentNumber, DepartmentTeamCode, ProductCategory,
                                                                      SecuritySession.UserCode, Comments, AlertID, Nothing)

            End If
            'Day 7
            EtID = 0
            EtDtlID = 0
            EntryDate = Nothing
            Hours = 0

            EtID = If(TimesheetRow.Day7ID IsNot Nothing, TimesheetRow.Day7ID, 0)
            EtDtlID = If(TimesheetRow.Day7DetailID IsNot Nothing, TimesheetRow.Day7DetailID, 0)

            EntryDate = TimesheetRow.Day7Date
            Hours = If(TimesheetRow.Day7Hours IsNot Nothing, TimesheetRow.Day7Hours, 0)

            If (EtDtlID = 0) AndAlso (Hours = 0) Then
                'need to save new zero hour??
            Else

                AdvantageFramework.EmployeeTimesheet.SaveTimesheetDay(SecuritySession, DbContext, EtID, EtDtlID, EmployeeCode, EntryDate, FunctionCategory,
                                                                      Hours, JobNumber, JobComponentNumber, DepartmentTeamCode, ProductCategory,
                                                                      SecuritySession.UserCode, Comments, AlertID, Nothing)

            End If


            'Try

            '    Dim PostActions As New AdvantageFramework.Controller.Employee.PostTimeSaveActions(SecuritySession, EmployeeCode, EntryDate)
            '    PostActions.Run()

            'Catch ex As Exception
            'End Try

            Return True

        End Function

        Public Function GetFunctionsAndCategories(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeCode As String, ByVal Functions As Boolean, ByVal Categories As Boolean) As IEnumerable

            Dim SearchResults As New Generic.List(Of SearchResult)
            Dim Entry As SearchResult = Nothing

            If Functions = False AndAlso Categories = False Then Functions = True

            If Functions = True Then

                For Each Fn In AdvantageFramework.Database.Procedures.Function.LoadForEmployeeDirectTime(DbContext, EmployeeCode)

                    Entry = New SearchResult

                    Entry.Code = Fn.Code
                    Entry.Description = Fn.Description

                    SearchResults.Add(Entry)

                    Entry = Nothing

                Next

            End If
            If Categories = True Then

                For Each Ct As AdvantageFramework.Database.Entities.IndirectCategory In AdvantageFramework.Database.Procedures.IndirectCategory.LoadAllActive(DbContext)

                    Entry = New SearchResult

                    Entry.Code = Ct.Code
                    Entry.Description = Ct.Description

                    SearchResults.Add(Entry)

                    Entry = Nothing

                Next

            End If

            Return AdvantageFramework.Database.Procedures.Function.LoadForEmployeeDirectTime(DbContext, EmployeeCode)

        End Function

    End Class
    <Serializable()> Public Class SearchResult

        Public Property Code As String = String.Empty
        Public Property Description As String = String.Empty

        Sub New()

        End Sub

    End Class
    <Serializable()> Public Class Recents

        Private _Context As HttpContextBase
        Public Property [List] As Generic.List(Of AdvantageFramework.ViewModels.Employee.Timesheet.RecentViewModel)

        Public Enum [Type]

            Assignments
            Jobs

        End Enum

        Public Sub ToCookie()

        End Sub
        Public Sub FromCookie()

        End Sub
        Public Sub Add()

        End Sub
        Private Sub Remove()

        End Sub

        Sub New(ByRef Context As HttpContextBase, ByVal Type As Recents.Type, ByVal UserCode As String)

            Me._Context = Context

        End Sub

    End Class
    <Serializable()> Public Class EmployeeDefaults

        Public Property FunctionCode As String = String.Empty
        Public Property DepartmentCode As String = String.Empty
        'Public Property FNC_CODE As String = String.Empty
        'Public Property DP_TM_CODE As String = String.Empty

        Private Sub Load(ByVal SecuritySession As AdvantageFramework.Security.Session,
                         ByVal EmployeeCode As String,
                         ByVal JobNumber As Integer,
                         ByVal JobComponentNumber As Short,
                         ByVal TaskSequenceNumber As Short)

            If SecuritySession IsNot Nothing AndAlso String.IsNullOrWhiteSpace(EmployeeCode) = False Then

                Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                    Dim ThisDefaults As EmployeeDefaults = Nothing

                    Try

                        ThisDefaults = DbContext.Database.SqlQuery(Of EmployeeDefaults)(String.Format("EXEC [dbo].[usp_wv_ts_DefaultFunctionAndDept] '{0}', {1}, {2}, {3};",
                                                                                                      EmployeeCode, JobNumber, JobComponentNumber, TaskSequenceNumber)).SingleOrDefault

                    Catch ex As Exception
                        ThisDefaults = Nothing
                    End Try


                    If ThisDefaults IsNot Nothing Then

                        Me.FunctionCode = ThisDefaults.FunctionCode
                        Me.DepartmentCode = ThisDefaults.DepartmentCode

                    Else

                        Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

                        Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode)

                        If Employee IsNot Nothing Then

                            Me.FunctionCode = Employee.FunctionCode
                            Me.DepartmentCode = Employee.DepartmentTeamCode

                        End If

                    End If

                End Using

            End If

        End Sub

        Sub New()

        End Sub
        Sub New(ByVal SecuritySession As AdvantageFramework.Security.Session,
                ByVal EmployeeCode As String,
                ByVal JobNumber As Integer,
                ByVal JobComponentNumber As Short,
                ByVal TaskSequenceNumber As Short)

            Me.Load(SecuritySession, EmployeeCode, JobNumber, JobComponentNumber, TaskSequenceNumber)

        End Sub
        Sub New(ByVal SecuritySession As AdvantageFramework.Security.Session,
                ByVal EmployeeCode As String,
                ByVal JobNumber As Integer,
                ByVal JobComponentNumber As Short)

            Me.Load(SecuritySession, EmployeeCode, JobNumber, JobComponentNumber, 0)

        End Sub
        Sub New(ByVal SecuritySession As AdvantageFramework.Security.Session,
                ByVal EmployeeCode As String)

            Me.Load(SecuritySession, EmployeeCode, 0, 0, 0)

        End Sub

    End Class
    <Serializable()> Public Class PostTimeSaveActions

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        'Private Property _SecuritySession As AdvantageFramework.Security.Session
        'Private Property _DbContext As AdvantageFramework.Database.DbContext
        Private Property _ConnectionString = String.Empty
        Private Property _UserCode = String.Empty
        Private Property _EmployeeCode As String
        Private Property _Date As Date

#End Region

#Region " Methods "

        Public Sub Run()

            Dim SyncThreadStart As New ThreadStart(AddressOf _Run)
            Dim SyncThread As New Thread(SyncThreadStart)
            SyncThread.Start()

        End Sub
        Private Sub _Run()

            Using DbContext = New AdvantageFramework.Database.DbContext(_ConnectionString, _UserCode)

                AdvantageFramework.EmployeeTimesheet.DeleteMissingTimeDetail(DbContext, _EmployeeCode)
                AdvantageFramework.EmployeeTimesheet.ProcessMissingTime(_ConnectionString, _UserCode, _EmployeeCode, _Date)

            End Using

        End Sub

        Sub New(ByVal ConnectionString As String, ByVal UserCode As String,
                ByVal EmployeeCode As String, ByVal DateToProcess As Date)

            Me._ConnectionString = ConnectionString
            Me._UserCode = UserCode
            Me._EmployeeCode = EmployeeCode
            Me._Date = DateToProcess

        End Sub

#End Region

    End Class
    <Serializable()> Public Class LookupItem

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "
        Public Property Key As String = String.Empty
        Public Property Description As String = String.Empty
        Public Property C As String = String.Empty
        Public Property D As String = String.Empty
        Public Property P As String = String.Empty
        Public ReadOnly Property CDP As String
            Get
                'If String.IsNullOrWhiteSpace(C) OrElse String.IsNullOrWhiteSpace(D) OrElse String.IsNullOrWhiteSpace(P) Then

                Return " (" & AdvantageFramework.Database.Procedures.Product.BuildClientDivisionProductDisplay(C, D, P) & ")"

                'Else

                '    Return ""

                'End If

            End Get
        End Property
#End Region

#Region " Methods "
        Sub New()

        End Sub

#End Region

    End Class
    <Serializable()> Public Class ClientDivisionProductLookupItem

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property Key As String = String.Empty
        Public Property CDP As String = String.Empty
        'Public Property C As String = String.Empty
        'Public Property D As String = String.Empty
        'Public Property P As String = String.Empty
        'Public ReadOnly Property CDP As String
        '    Get
        '        Return AdvantageFramework.Database.Procedures.Product.BuildClientDivisionProductDisplay(C, D, P)
        '    End Get
        'End Property

#End Region

#Region " Methods "

        Sub New()

        End Sub

#End Region

    End Class
    <Serializable()> Public Class EmployeeTimeDay

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property EmployeeCode As String = String.Empty
        Public Property EmployeeTimeID As Integer = 0
        Public Property EmployeeDate As Date

#End Region

#Region " Methods "
        Sub New()

        End Sub

#End Region

    End Class

End Namespace


