Namespace Timesheet

    <HideModuleName>
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "

        <Serializable()>
        Public Enum TimesheetEditType
            Edit = 0
            Billed = 1
            Summarized = 2
            ABFlag = 3
            Billing = 4
            PendingApproval = 5
            Approved = 6
            Denied = 7
        End Enum

        <Serializable()>
        Public Enum TimesheetApprovalType 'should prolly rename this TimesheetDayType
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

        <Serializable()>
        Public Enum TimesheetSort

            NewestFirst
            JobComponent
            Client
            Division
            Product
            FunctionCategory
            DepartmentTeam
            [Date]
            ClientAsc
            ClientDesc
            JobAsc
            JobDesc

        End Enum

        <Serializable()>
        Public Enum TimesheetGroupBy

            Client
            ClientDivision
            ClientDivisionProduct
            ClientJob
            ClientDivisionJob
            ClientDivisionProductJob
            None

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Function GetTimeSheet(ByVal ConnectionString As String, ByVal UserCode As String, ByVal EmpCode As String, ByVal StartDate As Date, ByVal EndDate As Date, _
                                     Optional ByVal [Sort] As TimesheetSort = TimesheetSort.NewestFirst, Optional ByRef ErrorMessage As String = "") As AdvantageFramework.Timesheet.TimeSheet
            Dim dr As System.Data.SqlClient.SqlDataReader

            Dim ThisTimeSheet As AdvantageFramework.Timesheet.TimeSheet = New AdvantageFramework.Timesheet.TimeSheet
            Dim ThisLine As AdvantageFramework.Timesheet.TimesheetLine

            Dim MyCmd As New System.Data.SqlClient.SqlCommand()

            Dim parameteremp_code As New System.Data.SqlClient.SqlParameter("@emp_code", SqlDbType.VarChar, 6)
            parameteremp_code.Value = EmpCode
            MyCmd.Parameters.Add(parameteremp_code)
            Dim parameterStartDate As New System.Data.SqlClient.SqlParameter("@StartDate", SqlDbType.SmallDateTime, 0)
            parameterStartDate.Value = StartDate
            MyCmd.Parameters.Add(parameterStartDate)
            Dim parameterEndDate As New System.Data.SqlClient.SqlParameter("@EndDate", SqlDbType.SmallDateTime, 0)
            parameterEndDate.Value = EndDate
            MyCmd.Parameters.Add(parameterEndDate)
            Dim parameterSortColumn As New System.Data.SqlClient.SqlParameter("@SortColumn", SqlDbType.VarChar, 35)

            Select Case Sort
                Case TimesheetSort.NewestFirst
                    parameterSortColumn.Value = System.DBNull.Value
                Case TimesheetSort.JobComponent
                    parameterSortColumn.Value = "JOB_NUMBER"
                Case TimesheetSort.Client
                    parameterSortColumn.Value = "CL_CODE"
                Case TimesheetSort.Division
                    parameterSortColumn.Value = "DIV_CODE"
                Case TimesheetSort.Product
                    parameterSortColumn.Value = "PRD_CODE"
                Case TimesheetSort.FunctionCategory
                    parameterSortColumn.Value = "FNC_CAT"
                Case TimesheetSort.DepartmentTeam
                    parameterSortColumn.Value = "DP_TM_CODE"
                Case TimesheetSort.Date
                    parameterSortColumn.Value = "EMP_DATE"
            End Select

            MyCmd.Parameters.Add(parameterSortColumn)
            Dim pUserCode As New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)
            pUserCode.Value = UserCode
            MyCmd.Parameters.Add(pUserCode)

            Using MyConn As New System.Data.SqlClient.SqlConnection(ConnectionString)

                MyConn.Open()

                Try

                    With MyCmd

                        .CommandType = CommandType.StoredProcedure
                        .CommandText = "usp_wv_ts_GetTimeSheet"
                        .Connection = MyConn

                    End With

                    dr = MyCmd.ExecuteReader()

                    With ThisTimeSheet

                        .EmpCode = EmpCode
                        .StartDate = StartDate
                        .EndDate = EndDate

                    End With

                    If dr.HasRows = True Then

                        Dim DayProcessed As Boolean = False
                        Dim ThisBaseIdentifier As String = ""

                        Do While dr.Read

                            DayProcessed = False

                            Dim ThisDay As New AdvantageFramework.Timesheet.TimesheetEntry
                            With ThisDay

                                If dr.IsDBNull(dr.GetOrdinal("EmployeeTimeID")) = False Then
                                    .ETID = dr.GetValue(dr.GetOrdinal("EmployeeTimeID"))
                                End If
                                If dr.IsDBNull(dr.GetOrdinal("EmployeeTimeDetailID")) = False Then
                                    .ETDTLID() = dr.GetValue(dr.GetOrdinal("EmployeeTimeDetailID"))
                                End If
                                If dr.IsDBNull(dr.GetOrdinal("EmployeeHours")) = False Then
                                    .Hours = CDbl(dr.GetSqlDecimal(dr.GetOrdinal("EmployeeHours")).Value)
                                End If
                                If dr.IsDBNull(dr.GetOrdinal("TimeType")) = False Then
                                    .TimeType = dr.GetString(dr.GetOrdinal("TimeType")).ToString()
                                End If
                                If dr.IsDBNull(dr.GetOrdinal("EditFlag")) = False Then
                                    .EditFlag = dr.GetValue(dr.GetOrdinal("EditFlag"))
                                End If
                                If dr.IsDBNull(dr.GetOrdinal("EmployeeDate")) = False Then
                                    .tDate = dr.GetDateTime(dr.GetOrdinal("EmployeeDate"))
                                End If
                                If dr.IsDBNull(dr.GetOrdinal("Comments")) = False Then
                                    .Comments = dr.GetString(dr.GetOrdinal("Comments")).ToString()
                                End If
                                If dr.GetValue(dr.GetOrdinal("IsLockedByProcessControl")) = 1 Then
                                    .CannotEditDueToProcessingControl = True
                                End If
                                If dr.GetValue(dr.GetOrdinal("HasStopwatch")) = 1 Then
                                    .HasStopwatch = True
                                End If
                                If dr.IsDBNull(dr.GetOrdinal("CommentsRequired")) = False Then
                                    .CommentsRequired = dr.GetValue(dr.GetOrdinal("CommentsRequired")) = 1
                                End If
                                Dim DayPostPeriodIsClosed As Boolean = False
                                If dr.IsDBNull(dr.GetOrdinal("DayPostPeriodClosed")) = False Then

                                    DayPostPeriodIsClosed = dr.GetValue(dr.GetOrdinal("DayPostPeriodClosed"))

                                End If
                                If dr.IsDBNull(dr.GetOrdinal("AlertID")) = False Then
                                    .AlertID = dr.GetValue(dr.GetOrdinal("AlertID"))
                                End If
                                If dr.IsDBNull(dr.GetOrdinal("AlertSubject")) = False Then
                                    .AlertSubject = dr.GetValue(dr.GetOrdinal("AlertSubject"))
                                End If

                                .CanDelete = False

                                If DayPostPeriodIsClosed = False And .CannotEditDueToProcessingControl = False And .HasStopwatch = False Then

                                    If .EditFlag = TimesheetEditType.Edit Or .EditFlag = TimesheetEditType.Denied Then

                                        .CanDelete = True

                                    End If

                                End If

                                'let zero hours be deleted in all instances except stopwatch
                                If .HasStopwatch = False And .Hours = 0 Then

                                    .CanDelete = True

                                End If

                            End With

                            'Create Compare String
                            Dim ClCode As String = ""
                            Dim DivCode As String = ""
                            Dim PrdCode As String = ""
                            Dim FuncCatCode As String = ""
                            Dim FuncCatDesc As String = ""
                            Dim DeptTeamCode As String = ""
                            Dim ProdCatCode As String = ""
                            Dim JobNumber As Integer = 0
                            Dim JobComponentNbr As Integer = 0
                            Dim ProcessControl As Integer = -1
                            Dim AlertID As Integer = 0

                            If dr.IsDBNull(dr.GetOrdinal("ClientCode")) = False Then
                                ClCode = dr.GetSqlString(dr.GetOrdinal("ClientCode")).ToString()
                            End If
                            If dr.IsDBNull(dr.GetOrdinal("DivisionCode")) = False Then
                                DivCode = dr.GetSqlString(dr.GetOrdinal("DivisionCode")).ToString()
                            End If
                            If dr.IsDBNull(dr.GetOrdinal("ProductCode")) = False Then
                                PrdCode = dr.GetSqlString(dr.GetOrdinal("ProductCode")).ToString()
                            End If
                            If dr.IsDBNull(dr.GetOrdinal("FunctionCategory")) = False Then
                                FuncCatCode = dr.GetSqlString(dr.GetOrdinal("FunctionCategory")).ToString()
                            End If
                            If dr.IsDBNull(dr.GetOrdinal("FunctionCategoryDescription")) = False Then
                                FuncCatDesc = dr.GetSqlString(dr.GetOrdinal("FunctionCategoryDescription")).ToString()
                            End If
                            If dr.IsDBNull(dr.GetOrdinal("DepartmentTeamCode")) = False Then
                                DeptTeamCode = dr.GetSqlString(dr.GetOrdinal("DepartmentTeamCode")).ToString()
                            End If
                            If dr.IsDBNull(dr.GetOrdinal("ProductCategoryCode")) = False Then
                                ProdCatCode = dr.GetSqlString(dr.GetOrdinal("ProductCategoryCode")).ToString()
                            End If
                            If dr.IsDBNull(dr.GetOrdinal("JobNumber")) = False Then
                                JobNumber = dr.GetValue(dr.GetOrdinal("JobNumber"))
                            End If
                            If dr.IsDBNull(dr.GetOrdinal("JobComponentNumber")) = False Then
                                JobComponentNbr = dr.GetValue(dr.GetOrdinal("JobComponentNumber"))
                            End If
                            If dr.IsDBNull(dr.GetOrdinal("JobProcessControl")) = False Then
                                ProcessControl = dr.GetValue(dr.GetOrdinal("JobProcessControl"))
                            End If
                            If dr.IsDBNull(dr.GetOrdinal("AlertID")) = False Then
                                AlertID = dr.GetValue(dr.GetOrdinal("AlertID"))
                            End If

                            Dim sb As New System.Text.StringBuilder
                            Dim HasComments As Boolean = False

                            With sb
                                .Append(EmpCode)
                                .Append("|")
                                .Append(FuncCatCode)
                                .Append("|")
                                .Append(DeptTeamCode)
                                .Append("|")
                                .Append(ProdCatCode)
                                .Append("|")
                                .Append(JobNumber.ToString())
                                .Append("|")
                                .Append(JobComponentNbr.ToString())
                                .Append("|")
                                .Append(ThisDay.ETID.ToString())
                                .Append("|")
                                .Append(ThisDay.ETDTLID.ToString())
                                .Append("|")
                                .Append(ThisDay.tDate.ToShortDateString())
                                .Append("|")
                                .Append(ThisDay.TimeType)
                                .Append("|")
                                .Append(CType(ThisDay.EditFlag, Integer).ToString())
                                .Append("|")
                                .Append(ThisDay.CommentsRequired.ToString().ToLower())
                                .Append("|")

                                If ThisDay.Comments.Trim() <> "" Then HasComments = True
                                .Append(HasComments.ToString().ToLower())
                                .Append("|")
                                .Append(ThisDay.Hours.ToString())
                                .Append("|")
                                .Append(ThisDay.AlertID.ToString())

                            End With

                            ThisDay.WebDataKey = sb.ToString()

                            sb.Clear()

                            With sb

                                .Append(ClCode)
                                .Append("|")
                                .Append(DivCode)
                                .Append("|")
                                .Append(PrdCode)
                                .Append("|")
                                .Append(JobNumber.ToString())
                                .Append("|")
                                .Append(JobComponentNbr.ToString())
                                .Append("|")
                                .Append(FuncCatCode)
                                .Append("|")
                                .Append(DeptTeamCode)
                                .Append("|")
                                .Append(ProdCatCode)
                                .Append("|")
                                .Append(ProcessControl.ToString())
                                .Append("|")
                                .Append(ThisDay.AlertID.ToString())

                            End With

                            ThisBaseIdentifier = sb.ToString()

                            ' Search For a Line 
                            '   each dtl record that has the same LineId will be put into the same TimesheetLine
                            '   UNLESS that TimesheetLine already has a dtl record for that day
                            '   in that case, a new TimesheetLine is added
                            Dim TempLine As AdvantageFramework.Timesheet.TimesheetLine
                            For Each TempLine In ThisTimeSheet
                                If TempLine.BaseLineIdentifier = ThisBaseIdentifier Then
                                    Select Case ThisDay.tDate.DayOfWeek
                                        Case DayOfWeek.Monday
                                            If TempLine.Monday Is Nothing Then
                                                TempLine.Monday = ThisDay
                                                TempLine.TotalHours = TempLine.TotalHours + ThisDay.Hours
                                                DayProcessed = True
                                                Exit For
                                            End If
                                        Case DayOfWeek.Tuesday
                                            If TempLine.Tuesday Is Nothing Then
                                                TempLine.Tuesday = ThisDay
                                                TempLine.TotalHours = TempLine.TotalHours + ThisDay.Hours
                                                DayProcessed = True
                                                Exit For
                                            End If
                                        Case DayOfWeek.Wednesday
                                            If TempLine.Wednesday Is Nothing Then
                                                TempLine.Wednesday = ThisDay
                                                TempLine.TotalHours = TempLine.TotalHours + ThisDay.Hours
                                                DayProcessed = True
                                                Exit For
                                            End If
                                        Case DayOfWeek.Thursday
                                            If TempLine.Thursday Is Nothing Then
                                                TempLine.Thursday = ThisDay
                                                TempLine.TotalHours = TempLine.TotalHours + ThisDay.Hours
                                                DayProcessed = True
                                                Exit For
                                            End If
                                        Case DayOfWeek.Friday
                                            If TempLine.Friday Is Nothing Then
                                                TempLine.Friday = ThisDay
                                                TempLine.TotalHours = TempLine.TotalHours + ThisDay.Hours
                                                DayProcessed = True
                                                Exit For
                                            End If
                                        Case DayOfWeek.Saturday
                                            If TempLine.Saturday Is Nothing Then
                                                TempLine.Saturday = ThisDay
                                                TempLine.TotalHours = TempLine.TotalHours + ThisDay.Hours
                                                DayProcessed = True
                                                Exit For
                                            End If
                                        Case DayOfWeek.Sunday
                                            If TempLine.Sunday Is Nothing Then
                                                TempLine.Sunday = ThisDay
                                                TempLine.TotalHours = TempLine.TotalHours + ThisDay.Hours
                                                DayProcessed = True
                                                Exit For
                                            End If
                                    End Select
                                End If
                            Next

                            If DayProcessed = False Then

                                ThisLine = New AdvantageFramework.Timesheet.TimesheetLine

                                With ThisLine
                                    .BaseLineIdentifier = ThisBaseIdentifier
                                    .LineIdentifier = SetLineIdentifier(ThisTimeSheet, ThisBaseIdentifier)
                                    If dr.IsDBNull(dr.GetOrdinal("ClientCode")) = False Then
                                        .ClientCode = dr.GetSqlString(dr.GetOrdinal("ClientCode")).ToString()
                                    End If
                                    If dr.IsDBNull(dr.GetOrdinal("DivisionCode")) = False Then
                                        .DivisionCode = dr.GetSqlString(dr.GetOrdinal("DivisionCode")).ToString()
                                    End If
                                    If dr.IsDBNull(dr.GetOrdinal("ProductCode")) = False Then
                                        .ProductCode = dr.GetSqlString(dr.GetOrdinal("ProductCode")).ToString()
                                    End If

                                    If dr.IsDBNull(dr.GetOrdinal("JobNumber")) = False Then
                                        .JobNumber = dr.GetValue(dr.GetOrdinal("JobNumber"))
                                    End If
                                    If dr.IsDBNull(dr.GetOrdinal("JobComponentNumber")) = False Then
                                        .JobComponentNbr = dr.GetValue(dr.GetOrdinal("JobComponentNumber"))
                                    End If
                                    If dr.IsDBNull(dr.GetOrdinal("JobDescription")) = False Then
                                        .JobDesc = dr.GetSqlString(dr.GetOrdinal("JobDescription")).Value
                                    End If
                                    If dr.IsDBNull(dr.GetOrdinal("JobComponentDescription")) = False Then
                                        .JobCompDesc = dr.GetSqlString(dr.GetOrdinal("JobComponentDescription")).ToString()
                                    End If
                                    If dr.IsDBNull(dr.GetOrdinal("ProductCategoryCode")) = False Then
                                        .ProductCategory = dr.GetSqlString(dr.GetOrdinal("ProductCategoryCode")).ToString()
                                    End If
                                    If dr.IsDBNull(dr.GetOrdinal("FunctionCategory")) = False Then
                                        .FuncCat = dr.GetSqlString(dr.GetOrdinal("FunctionCategory")).ToString()
                                    End If
                                    If dr.IsDBNull(dr.GetOrdinal("FunctionCategoryDescription")) = False Then
                                        .FuncCatDesc = dr.GetSqlString(dr.GetOrdinal("FunctionCategoryDescription")).ToString()
                                    End If
                                    If dr.IsDBNull(dr.GetOrdinal("DepartmentTeamCode")) = False Then
                                        .Dept = dr.GetSqlString(dr.GetOrdinal("DepartmentTeamCode")).ToString()
                                    End If
                                    If dr.IsDBNull(dr.GetOrdinal("ClientName")) = False Then
                                        .ClientName = dr.GetSqlString(dr.GetOrdinal("ClientName")).ToString()
                                    End If
                                    If dr.IsDBNull(dr.GetOrdinal("DivisionName")) = False Then
                                        .DivisionName = dr.GetSqlString(dr.GetOrdinal("DivisionName")).ToString()
                                    End If
                                    If dr.IsDBNull(dr.GetOrdinal("ProductDescription")) = False Then
                                        .ProductDescription = dr.GetSqlString(dr.GetOrdinal("ProductDescription")).ToString()
                                    End If
                                    If dr.IsDBNull(dr.GetOrdinal("NonEditMessage")) = False Then
                                        .NonEditMessage = dr.GetSqlString(dr.GetOrdinal("NonEditMessage")).ToString()
                                    End If
                                    If .NonEditMessage.Contains("Process Control does not allow editing") Then
                                        .CannotEditDueToProcessingControl = True
                                    End If
                                    If dr.IsDBNull(dr.GetOrdinal("JobProcessControl")) = False Then
                                        .JobProcessControl = dr.GetValue(dr.GetOrdinal("JobProcessControl"))
                                    Else
                                        .JobProcessControl = -1
                                    End If
                                    If dr.IsDBNull(dr.GetOrdinal("TimeType")) = False Then
                                        .TimeType = dr.GetString(dr.GetOrdinal("TimeType")).ToString()
                                    End If
                                    If dr.IsDBNull(dr.GetOrdinal("ClientCommentRequired")) = False Then
                                        .ClientCommentRequired = CType(dr.GetValue(dr.GetOrdinal("ClientCommentRequired")), Boolean)
                                    End If
                                    If dr.IsDBNull(dr.GetOrdinal("Quoted")) = False Then
                                        .QuotedAmount = CType(dr.GetValue(dr.GetOrdinal("Quoted")), Decimal)
                                    End If
                                    If dr.IsDBNull(dr.GetOrdinal("QuotedHours")) = False Then
                                        .QuotedHours = CType(dr.GetValue(dr.GetOrdinal("QuotedHours")), Decimal)
                                    End If
                                    If dr.IsDBNull(dr.GetOrdinal("Actual")) = False Then
                                        .ActualAmount = CType(dr.GetValue(dr.GetOrdinal("Actual")), Decimal)
                                    End If
                                    If dr.IsDBNull(dr.GetOrdinal("ActualHours")) = False Then
                                        .ActualHours = CType(dr.GetValue(dr.GetOrdinal("ActualHours")), Decimal)
                                    End If
                                    If dr.IsDBNull(dr.GetOrdinal("IsOverThreshold")) = False Then
                                        .IsOverThreshold = dr.GetValue(dr.GetOrdinal("IsOverThreshold"))
                                    End If
                                    If dr.IsDBNull(dr.GetOrdinal("ProgressIsShowingTrafficHours")) = False Then
                                        .ProgressIsShowingTrafficHours = dr.GetValue(dr.GetOrdinal("ProgressIsShowingTrafficHours"))
                                    End If
                                    If dr.IsDBNull(dr.GetOrdinal("Threshold")) = False Then
                                        .Threshold = dr.GetValue(dr.GetOrdinal("Threshold"))
                                    End If
                                    If dr.IsDBNull(dr.GetOrdinal("AlertID")) = False Then
                                        .AlertID = dr.GetValue(dr.GetOrdinal("AlertID"))
                                    End If
                                    If dr.IsDBNull(dr.GetOrdinal("AlertSubject")) = False Then
                                        .AlertSubject = dr.GetValue(dr.GetOrdinal("AlertSubject"))
                                    End If

                                    Select Case ThisDay.tDate.DayOfWeek
                                        Case DayOfWeek.Monday
                                            .Monday = ThisDay
                                        Case DayOfWeek.Tuesday
                                            .Tuesday = ThisDay
                                        Case DayOfWeek.Wednesday
                                            .Wednesday = ThisDay
                                        Case DayOfWeek.Thursday
                                            .Thursday = ThisDay
                                        Case DayOfWeek.Friday
                                            .Friday = ThisDay
                                        Case DayOfWeek.Saturday
                                            .Saturday = ThisDay
                                        Case DayOfWeek.Sunday
                                            .Sunday = ThisDay
                                    End Select

                                    .TotalHours = .TotalHours + ThisDay.Hours

                                End With

                                ThisTimeSheet.Add(ThisLine)

                            End If

                            Dim ThisColumn As New _TimesheetDay
                            ThisColumn.Date = ThisDay.tDate

                            'If ThisTimeSheet.Days.Count = 0 Then
                            'End If

                            Dim ExistingColumn As New _TimesheetDay

                            ExistingColumn = ThisTimeSheet.Days.ToList().Find(Function(value As _TimesheetDay)
                                                                                  Return value.Date = ThisDay.tDate
                                                                              End Function)

                            If ExistingColumn Is Nothing Then

                                ThisColumn.TotalHours += ThisDay.Hours
                                If dr.IsDBNull(dr.GetOrdinal("DayIsDenied")) = False Then
                                    ThisColumn.IsDenied = dr.GetValue(dr.GetOrdinal("DayIsDenied"))
                                End If
                                If dr.IsDBNull(dr.GetOrdinal("DayIsApproved")) = False Then
                                    ThisColumn.IsApproved = dr.GetValue(dr.GetOrdinal("DayIsApproved"))
                                End If
                                If dr.IsDBNull(dr.GetOrdinal("DayIsPendingApproval")) = False Then
                                    ThisColumn.IsPendingApproval = dr.GetValue(dr.GetOrdinal("DayIsPendingApproval"))
                                End If
                                If dr.IsDBNull(dr.GetOrdinal("DayPostPeriodClosed")) = False Then
                                    ThisColumn.PostPeriodIsClosed = dr.GetValue(dr.GetOrdinal("DayPostPeriodClosed"))
                                End If

                                If ThisColumn.IsApproved = True Or ThisColumn.IsPendingApproval = True Or ThisColumn.PostPeriodIsClosed = True Then
                                    ThisColumn.CanEdit = False
                                Else
                                    ThisColumn.CanEdit = True
                                End If

                                ThisTimeSheet.Days.Add(ThisColumn)

                            Else

                                If ExistingColumn.IsDenied = False AndAlso dr.IsDBNull(dr.GetOrdinal("DayIsDenied")) = False Then
                                    ExistingColumn.IsDenied = dr.GetValue(dr.GetOrdinal("DayIsDenied"))
                                End If
                                If ExistingColumn.IsApproved = False AndAlso dr.IsDBNull(dr.GetOrdinal("DayIsApproved")) = False Then
                                    ExistingColumn.IsApproved = dr.GetValue(dr.GetOrdinal("DayIsApproved"))
                                End If
                                If ExistingColumn.IsPendingApproval = False AndAlso dr.IsDBNull(dr.GetOrdinal("DayIsPendingApproval")) = False Then
                                    ExistingColumn.IsPendingApproval = dr.GetValue(dr.GetOrdinal("DayIsPendingApproval"))
                                End If
                                If ExistingColumn.PostPeriodIsClosed = False AndAlso dr.IsDBNull(dr.GetOrdinal("DayPostPeriodClosed")) = False Then
                                    ExistingColumn.PostPeriodIsClosed = dr.GetValue(dr.GetOrdinal("DayPostPeriodClosed"))
                                End If

                                If ExistingColumn.IsApproved = True Or ExistingColumn.IsPendingApproval = True Or ExistingColumn.PostPeriodIsClosed = True Then
                                    ExistingColumn.CanEdit = False
                                Else
                                    ExistingColumn.CanEdit = True
                                End If

                                ExistingColumn.TotalHours += ThisDay.Hours

                            End If

                            ThisTimeSheet.IsMissingComments = dr.GetValue(dr.GetOrdinal("TimesheetMissingComments"))

                        Loop

                    End If

                    dr.Close()

                Catch ex As Exception
                    'Throw ex
                    ErrorMessage = ex.Message.ToString()
                    Return Nothing
                Finally
                    If MyConn.State = ConnectionState.Open Then MyConn.Close()
                End Try
            End Using

            'If there is absolutely no detail records for a given date, the column is nothing, make sure it is something
            For x As Integer = 0 To 6
                Dim CurrentColumn As New _TimesheetDay
                Dim LoopValue As Integer = x
                CurrentColumn = ThisTimeSheet.Days.ToList().Find(Function(value As _TimesheetDay)
                                                                     Return value.Date = StartDate.AddDays(LoopValue)
                                                                 End Function)

                If CurrentColumn Is Nothing Then

                    CurrentColumn = New _TimesheetDay

                    CurrentColumn.Date = StartDate.AddDays(LoopValue)

                    'denied, approved,pending can't happen on a day with a total of zero hours...so only check post period!
                    CurrentColumn.PostPeriodIsClosed = PostPeriodClosed(ConnectionString, StartDate.AddDays(LoopValue))

                    If CurrentColumn.PostPeriodIsClosed = True Then
                        CurrentColumn.CanEdit = False
                    Else
                        CurrentColumn.CanEdit = True
                    End If

                    ThisTimeSheet.Days.Add(CurrentColumn)

                End If

            Next

            'Make sure each line has entry
            Dim tm As New AdvantageFramework.Timesheet.TimesheetSettings(ConnectionString, UserCode)
            Dim TsSettings As New AdvantageFramework.Timesheet.Settings.DisplaySettings
            TsSettings = tm.GetSettings(UserCode)

            For Each line As TimesheetLine In ThisTimeSheet

                CheckForAllDays(line, StartDate, EmpCode, TsSettings.StartTimesheetOnDayOfWeek)

            Next

            'Return
            Return ThisTimeSheet

        End Function
        Private Sub CheckForAllDays(ByRef TimesheetLine As TimesheetLine, ByVal StartDate As Date,
                                    ByVal EmployeeCode As String, ByVal StartTimesheetOnDayOfWeek As DayOfWeek)

            Dim BlankEntry As TimesheetEntry = Nothing
            Dim sb As New System.Text.StringBuilder

            Select Case StartTimesheetOnDayOfWeek
                Case DayOfWeek.Monday

                    Try

                        If TimesheetLine.Monday Is Nothing Then

                            TimesheetLine.Monday = NewBlankEntry(StartDate.AddDays(0), EmployeeCode, TimesheetLine)

                        End If
                        If TimesheetLine.Tuesday Is Nothing Then

                            TimesheetLine.Tuesday = NewBlankEntry(StartDate.AddDays(1), EmployeeCode, TimesheetLine)

                        End If
                        If TimesheetLine.Wednesday Is Nothing Then

                            TimesheetLine.Wednesday = NewBlankEntry(StartDate.AddDays(2), EmployeeCode, TimesheetLine)

                        End If
                        If TimesheetLine.Thursday Is Nothing Then

                            TimesheetLine.Thursday = NewBlankEntry(StartDate.AddDays(3), EmployeeCode, TimesheetLine)

                        End If
                        If TimesheetLine.Friday Is Nothing Then

                            TimesheetLine.Friday = NewBlankEntry(StartDate.AddDays(4), EmployeeCode, TimesheetLine)

                        End If
                        If TimesheetLine.Saturday Is Nothing Then

                            TimesheetLine.Saturday = NewBlankEntry(StartDate.AddDays(5), EmployeeCode, TimesheetLine)

                        End If
                        If TimesheetLine.Sunday Is Nothing Then

                            TimesheetLine.Sunday = NewBlankEntry(StartDate.AddDays(6), EmployeeCode, TimesheetLine)

                        End If

                    Catch ex As Exception
                    End Try

                Case DayOfWeek.Saturday

                    Try

                        If TimesheetLine.Saturday Is Nothing Then

                            TimesheetLine.Saturday = NewBlankEntry(StartDate.AddDays(0), EmployeeCode, TimesheetLine)

                        End If
                        If TimesheetLine.Sunday Is Nothing Then

                            TimesheetLine.Sunday = NewBlankEntry(StartDate.AddDays(1), EmployeeCode, TimesheetLine)

                        End If
                        If TimesheetLine.Monday Is Nothing Then

                            TimesheetLine.Monday = NewBlankEntry(StartDate.AddDays(2), EmployeeCode, TimesheetLine)

                        End If
                        If TimesheetLine.Tuesday Is Nothing Then

                            TimesheetLine.Tuesday = NewBlankEntry(StartDate.AddDays(3), EmployeeCode, TimesheetLine)

                        End If
                        If TimesheetLine.Wednesday Is Nothing Then

                            TimesheetLine.Wednesday = NewBlankEntry(StartDate.AddDays(4), EmployeeCode, TimesheetLine)

                        End If
                        If TimesheetLine.Thursday Is Nothing Then

                            TimesheetLine.Thursday = NewBlankEntry(StartDate.AddDays(5), EmployeeCode, TimesheetLine)

                        End If
                        If TimesheetLine.Friday Is Nothing Then

                            TimesheetLine.Friday = NewBlankEntry(StartDate.AddDays(6), EmployeeCode, TimesheetLine)

                        End If

                    Catch ex As Exception
                    End Try

                Case Else

                    Try

                        If TimesheetLine.Sunday Is Nothing Then

                            TimesheetLine.Sunday = NewBlankEntry(StartDate.AddDays(0), EmployeeCode, TimesheetLine)

                        End If
                        If TimesheetLine.Monday Is Nothing Then

                            TimesheetLine.Monday = NewBlankEntry(StartDate.AddDays(1), EmployeeCode, TimesheetLine)

                        End If
                        If TimesheetLine.Tuesday Is Nothing Then

                            TimesheetLine.Tuesday = NewBlankEntry(StartDate.AddDays(2), EmployeeCode, TimesheetLine)

                        End If
                        If TimesheetLine.Wednesday Is Nothing Then

                            TimesheetLine.Wednesday = NewBlankEntry(StartDate.AddDays(3), EmployeeCode, TimesheetLine)

                        End If
                        If TimesheetLine.Thursday Is Nothing Then

                            TimesheetLine.Thursday = NewBlankEntry(StartDate.AddDays(4), EmployeeCode, TimesheetLine)

                        End If
                        If TimesheetLine.Friday Is Nothing Then

                            TimesheetLine.Friday = NewBlankEntry(StartDate.AddDays(5), EmployeeCode, TimesheetLine)

                        End If
                        If TimesheetLine.Saturday Is Nothing Then

                            TimesheetLine.Saturday = NewBlankEntry(StartDate.AddDays(6), EmployeeCode, TimesheetLine)

                        End If

                    Catch ex As Exception
                    End Try

            End Select

        End Sub

        Private Function NewBlankEntry(ByVal EntryDate As Date, ByVal EmployeeCode As String, ByVal TimesheetLine As TimesheetLine) As TimesheetEntry

            Dim Sb As New Text.StringBuilder
            Dim BlankEntry As TimesheetEntry

            BlankEntry = New TimesheetEntry
            BlankEntry.tDate = EntryDate
            BlankEntry.TimeType = TimesheetLine.TimeType
            BlankEntry.AlertID = TimesheetLine.AlertID
            BlankEntry.AlertSubject = TimesheetLine.AlertSubject

            Sb = New Text.StringBuilder
            With Sb

                .Append(EmployeeCode)
                .Append("|")
                .Append(TimesheetLine.FuncCat)
                .Append("|")
                .Append(TimesheetLine.Dept)
                .Append("|")
                .Append(TimesheetLine.ProductCategory)
                .Append("|")
                .Append(TimesheetLine.JobNumber.ToString())
                .Append("|")
                .Append(TimesheetLine.JobComponentNbr.ToString())
                .Append("|")
                .Append("0")
                .Append("|")
                .Append("0")
                .Append("|")
                .Append(BlankEntry.tDate.ToShortDateString())
                .Append("|")
                .Append(BlankEntry.TimeType)
                .Append("|")
                .Append("0")
                .Append("|")
                .Append(TimesheetLine.ClientCommentRequired.ToString.ToLower)
                .Append("|")
                .Append("false")
                .Append("|")
                .Append("0")
                .Append("|")
                .Append(TimesheetLine.AlertID)

            End With

            BlankEntry.WebDataKey = Sb.ToString

            Sb = Nothing

            Return BlankEntry

        End Function
        Public Function GetTimesheetLine(ByVal ts As TimeSheet, ByVal LineIdentifier As String) As TimesheetLine
            For Each line As TimesheetLine In ts
                If line.LineIdentifier = LineIdentifier Then
                    Return line
                End If
            Next
            Return Nothing
        End Function

        Public Function GetTimesheetDayByDate(ByVal ts As TimeSheet, ByVal [Date] As Date, Optional ByRef ErrorMessage As String = "") As _TimesheetDay
            Try
                Return ts.Days.ToList().Find(Function(value As AdvantageFramework.Timesheet._TimesheetDay)
                                                 Return value.Date = [Date]
                                             End Function)
            Catch ex As Exception
                ErrorMessage = ex.Message.ToString()
                Return Nothing
            End Try
        End Function

        Public Function DayIsMissingComment(ByVal ConnectionString As String, ByVal UserCode As String, ByVal EmpCode As String, ByVal [Date] As Date) As Boolean
            Using MyConn As New System.Data.SqlClient.SqlConnection(ConnectionString)

                Dim MyCommand As New System.Data.SqlClient.SqlCommand()
                With MyCommand

                    .CommandType = CommandType.StoredProcedure
                    .CommandText = "usp_wv_ts_DayIsMissingCommentsByEmpDate"
                    .Connection = MyConn

                End With

                Dim pEmpCode As New System.Data.SqlClient.SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
                pEmpCode.Value = EmpCode

                Dim pDate As New System.Data.SqlClient.SqlParameter("@DATE", SqlDbType.SmallDateTime)
                pDate.Value = [Date]

                Dim pUserCode As New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)
                pUserCode.Value = UserCode

                MyCommand.Parameters.Add(pEmpCode)
                MyCommand.Parameters.Add(pDate)
                MyCommand.Parameters.Add(pUserCode)

                MyConn.Open()

                Return CType(MyCommand.ExecuteScalar(), Boolean)

            End Using
        End Function


        Public Function GetDescription(ByVal ConnectionString As String, ByVal EtId As Integer, ByVal EtDtlId As Integer, Optional ByRef ErrorMessage As String = "") As String
            Try
                Dim Description As String = ""
                Using MyConn As New System.Data.SqlClient.SqlConnection(ConnectionString)
                    Dim MyCommand As New System.Data.SqlClient.SqlCommand()
                    With MyCommand
                        .CommandType = CommandType.StoredProcedure
                        .CommandText = "usp_wv_ts_StopwatchGetDescription"
                        .Connection = MyConn
                    End With

                    Dim pEtId As New System.Data.SqlClient.SqlParameter("@ET_ID", SqlDbType.Int)
                    pEtId.Value = EtId
                    Dim pEtDtlId As New System.Data.SqlClient.SqlParameter("@ET_DTL_ID", SqlDbType.SmallInt)
                    pEtDtlId.Value = EtDtlId

                    MyCommand.Parameters.Add(pEtId)
                    MyCommand.Parameters.Add(pEtDtlId)

                    MyConn.Open()

                    Description = MyCommand.ExecuteScalar()

                    If MyConn.State = ConnectionState.Open Then
                        MyConn.Close()
                        MyConn.Dispose()
                    End If

                End Using

                Return Description

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString()
                Return ErrorMessage
            End Try
        End Function

        'This gives us a unique id for each "duplicate" line
        Private Function SetLineIdentifier(ByVal ts As TimeSheet, ByVal BaseIdentifier As String) As String
            Try
                Dim i As Integer = 0
                For Each line As TimesheetLine In ts
                    If line.BaseLineIdentifier = BaseIdentifier Then
                        i += 1
                    End If
                Next
                Return (i + 1).ToString() & "|" & BaseIdentifier
            Catch ex As Exception
                Return "-1|" & BaseIdentifier
            End Try
        End Function

        'Public Function GetDayView(ByVal EmpCode As String, ByVal [Date] As Date) As TimesheetDayView
        '    Dim ts As New AdvantageFramework.Timesheet.TimeSheet
        '    ts = GetTimeSheet(EmpCode, [Date], [Date])

        '    Dim DayView As New TimesheetDayView
        '    For i As Integer = 0 To ts.Count - 1
        '        Dim line As New TimesheetLine
        '        line = ts(i)



        '    Next


        'End Function

        Public Function TimeEntryExists(ByVal ConnectionString As String, ByVal EmpCode As System.String, ByVal EmpDate As System.DateTime, _
                                 ByVal FncCat As System.String, ByVal ProdCat As String, ByVal JobNumber As System.Int32, _
                                 ByVal JobComponentNbr As System.Int16, ByVal DeptTeam As System.String, _
                                 Optional ByRef ExistingEtId As Integer = 0, Optional ByRef ExistingEtDtlId As Integer = 0, _
                                 Optional ByRef ExistingHours As Decimal = 0.0, Optional ByRef ExistingComment As String = "", _
                                 Optional ByRef CanEditExistingEntry As Boolean = False,
                                 Optional ByRef ErrorMessage As String = "") As Boolean

            Try

                Dim MyConn As New System.Data.SqlClient.SqlConnection(ConnectionString)
                Dim MyCmd As New System.Data.SqlClient.SqlCommand("usp_wv_ts_TimeEntryExistsAndCanEdit", MyConn)
                Dim MyAdapter As New System.Data.SqlClient.SqlDataAdapter(MyCmd)

                MyCmd.CommandType = CommandType.StoredProcedure

                Dim parameteremp_code As New System.Data.SqlClient.SqlParameter("@emp_code", SqlDbType.VarChar, 6)
                parameteremp_code.Value = EmpCode
                MyCmd.Parameters.Add(parameteremp_code)

                Dim parameteremp_date As New System.Data.SqlClient.SqlParameter("@emp_date", SqlDbType.SmallDateTime, 0)
                parameteremp_date.Value = EmpDate.ToShortDateString
                MyCmd.Parameters.Add(parameteremp_date)

                Dim parameterfnc_cat As New System.Data.SqlClient.SqlParameter("@fnc_cat", SqlDbType.VarChar, 10)
                If FncCat.Trim() = "" Then
                    parameterfnc_cat.Value = DBNull.Value
                Else
                    parameterfnc_cat.Value = FncCat
                End If
                MyCmd.Parameters.Add(parameterfnc_cat)

                Dim parameterjob_nbr As New System.Data.SqlClient.SqlParameter("@job_nbr", SqlDbType.Int, 4)
                parameterjob_nbr.Value = JobNumber
                MyCmd.Parameters.Add(parameterjob_nbr)

                Dim parameterjob_cmp_nbr As New System.Data.SqlClient.SqlParameter("@job_cmp_nbr", SqlDbType.SmallInt, 2)
                parameterjob_cmp_nbr.Value = JobComponentNbr
                MyCmd.Parameters.Add(parameterjob_cmp_nbr)

                Dim parameterdp_tm As New System.Data.SqlClient.SqlParameter("@dp_tm", SqlDbType.VarChar, 4)
                If DeptTeam.Trim = "" Then
                    parameterdp_tm.Value = DBNull.Value
                Else
                    parameterdp_tm.Value = DeptTeam
                End If
                MyCmd.Parameters.Add(parameterdp_tm)

                Dim parameterProdCat As New System.Data.SqlClient.SqlParameter("@ProdCat", SqlDbType.VarChar, 10)
                If ProdCat.Trim = "" Then
                    parameterProdCat.Value = DBNull.Value
                Else
                    parameterProdCat.Value = ProdCat
                End If
                MyCmd.Parameters.Add(parameterProdCat)

                MyConn.Open()

                Dim Reader As System.Data.SqlClient.SqlDataReader
                Reader = MyCmd.ExecuteReader()

                If Reader.HasRows = True Then

                    Do While Reader.Read()

                        ExistingEtId = Reader.GetValue(Reader.GetOrdinal("EXISTING_ET_ID"))
                        ExistingEtDtlId = Reader.GetValue(Reader.GetOrdinal("EXISTING_ET_DTL_ID"))
                        ExistingHours = Reader.GetValue(Reader.GetOrdinal("EXISTING_HOURS"))
                        ExistingComment = Reader.GetValue(Reader.GetOrdinal("EXISTING_COMMENT"))

                        If Reader.GetValue(Reader.GetOrdinal("CAN_EDIT")) = 1 Then

                            CanEditExistingEntry = True

                        End If

                    Loop

                End If

                If ExistingEtId > 0 And ExistingEtDtlId > 0 Then

                    ErrorMessage = ""
                    Return True

                Else

                    ExistingEtId = 0
                    ExistingEtDtlId = 0
                    CanEditExistingEntry = False
                    Return False

                End If

            Catch ex As Exception

                ExistingEtId = 0
                ExistingEtDtlId = 0
                CanEditExistingEntry = False
                ErrorMessage = AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString())
                Return False

            End Try

            ErrorMessage = ""
            Return False

        End Function

        'ONLY USED ON ASPX PAGES THAT ARE NO LONGER IN USE!
        Public Function SaveDay(ByVal ConnectionString As String, ByVal EtId As System.Int32, ByVal EtDtlId As System.Int32, ByVal EmpCode As System.String, ByVal EmpDate As System.DateTime,
                                 ByVal FncCat As System.String, ByVal ProdCat As String, ByRef EmpHrs As System.Decimal, ByVal JobNumber As System.Int32,
                                 ByVal JobComponentNbr As System.Int16, ByVal DeptTeam As System.String, ByVal UserID As String, ByRef ErrorMessage As System.String,
                                 Optional ByVal Comments As String = "", Optional ByRef NewEt_Id As Integer = 0, Optional ByRef NewEtd_Id As Integer = 0,
                                 Optional ByVal TryToUpdateExisting As Boolean = True,
                                 Optional ByVal AlertID As Integer = 0) As Boolean

            Dim Saved As Boolean = False
            Dim NewEmployeeTimeID As Integer = 0
            Dim NewEmployeeTimeDetailID As Integer = 0

            Saved = SaveDayBL(ConnectionString, EtId, EtDtlId, EmpCode,
                            EmpDate, FncCat, ProdCat, EmpHrs, JobNumber, JobComponentNbr, DeptTeam, UserID, ErrorMessage, Comments,
                            NewEmployeeTimeID, NewEmployeeTimeDetailID, AlertID, Not TryToUpdateExisting)

            Try

                If (ErrorMessage.IndexOf("SUCCESS") > -1 OrElse ErrorMessage.IndexOf("NO_CHANGE") > -1) Then

                    ErrorMessage = AdvantageFramework.StringUtilities.RemoveTrailingDelimiter(ErrorMessage, "|")

                    If ErrorMessage.IndexOf("INSERT") > -1 AndAlso ErrorMessage.IndexOf("|") > -1 Then

                        Try

                            Dim ar() As String
                            ar = ErrorMessage.Split("|")
                            NewEt_Id = CType(ar(1), Integer)
                            NewEtd_Id = CType(ar(2), Integer)
                            EmpHrs = CType(AdvantageFramework.StringUtilities.FormatDecimal(ar(3)), Decimal)

                        Catch ex As Exception
                            NewEt_Id = 0
                            NewEtd_Id = 0
                            ErrorMessage = AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString())
                            Saved = False
                        End Try

                    End If
                    If ErrorMessage.IndexOf("UPDATE") > -1 AndAlso ErrorMessage.IndexOf("|") > -1 Then

                        Try

                            Dim ar() As String
                            ar = ErrorMessage.Split("|")
                            NewEt_Id = CType(ar(1), Integer)
                            NewEtd_Id = CType(ar(2), Integer)
                            EmpHrs = CType(AdvantageFramework.StringUtilities.FormatDecimal(ar(3)), Decimal)

                        Catch ex As Exception
                            NewEt_Id = 0
                            NewEtd_Id = 0
                            ErrorMessage = AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString())
                            Saved = False
                        End Try

                    End If
                    If ErrorMessage.IndexOf("NO_CHANGE") > -1 AndAlso ErrorMessage.IndexOf("|") > -1 Then

                        Try

                            Dim ar() As String
                            ar = ErrorMessage.Split("|")
                            NewEt_Id = CType(ar(1), Integer)
                            NewEtd_Id = CType(ar(2), Integer)
                            EmpHrs = CType(AdvantageFramework.StringUtilities.FormatDecimal(ar(3)), Decimal)

                        Catch ex As Exception
                            NewEt_Id = 0
                            NewEtd_Id = 0
                            ErrorMessage = AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString())
                            Saved = False
                        End Try

                    End If

                    Return True

                Else

                    If ErrorMessage.IndexOf("UPDATE_FAIL|") > -1 Then

                        Try

                            Dim ar() As String
                            ar = ErrorMessage.Split("|")
                            NewEt_Id = CType(ar(1), Integer)
                            NewEtd_Id = CType(ar(2), Integer)
                            EmpHrs = CType(ar(3), Decimal)

                        Catch ex As Exception
                            NewEt_Id = 0
                            NewEtd_Id = 0
                            ErrorMessage = AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString())
                            Saved = False
                        End Try

                    End If

                    Saved = False

                End If

            Catch ex As Exception
                ErrorMessage = AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString())
                Saved = False
            End Try

            Return Saved

        End Function
        'ONLY USED ON ASPX PAGES THAT ARE NO LONGER IN USE!
        Public Function SaveDayBL(ByVal ConnectionString As String, ByVal EtId As System.Int32, ByVal EtDtlId As System.Int32, ByVal EmpCode As System.String, ByVal EmpDate As System.DateTime,
                                ByVal FncCat As System.String, ByVal ProdCat As String, ByRef EmpHrs As System.Decimal, ByVal JobNumber As System.Int32,
                                ByVal JobComponentNbr As System.Int16, ByVal DeptTeam As System.String, ByVal UserID As String, ByRef ErrorMessage As System.String,
                                ByVal Comments As String, ByRef NewEt_Id As Integer, ByRef NewEtd_Id As Integer,
                                ByVal AlertID As Integer,
                                ByVal AllowDuplicate As Boolean) As Boolean



            Dim Success As Boolean = False

            '5210-1-1596 - TS:  When adding time from card or otherwise, add new row by default when a comment is added.
            If EtId = 0 AndAlso EtDtlId = 0 AndAlso String.IsNullOrWhiteSpace(Comments) = False Then

                AllowDuplicate = True

            End If

            Try

                Dim MyConn As New System.Data.SqlClient.SqlConnection(ConnectionString)
                Dim MyCmd As New System.Data.SqlClient.SqlCommand("usp_wv_ts_SaveTimeSheetDay", MyConn)
                Dim MyAdapter As New System.Data.SqlClient.SqlDataAdapter(MyCmd)

                MyCmd.CommandType = CommandType.StoredProcedure

                Dim parameteret_id As New System.Data.SqlClient.SqlParameter("@et_id", SqlDbType.Int, 4)
                parameteret_id.Value = EtId
                MyCmd.Parameters.Add(parameteret_id)

                Dim parameteretd_id As New System.Data.SqlClient.SqlParameter("@etd_id", SqlDbType.Int, 4)
                parameteretd_id.Value = EtDtlId
                MyCmd.Parameters.Add(parameteretd_id)

                Dim parameteremp_code As New System.Data.SqlClient.SqlParameter("@emp_code", SqlDbType.VarChar, 6)
                parameteremp_code.Value = EmpCode
                MyCmd.Parameters.Add(parameteremp_code)

                Dim parameteremp_date As New System.Data.SqlClient.SqlParameter("@emp_date", SqlDbType.SmallDateTime, 0)
                parameteremp_date.Value = EmpDate.ToShortDateString
                MyCmd.Parameters.Add(parameteremp_date)

                Dim parameterfnc_cat As New System.Data.SqlClient.SqlParameter("@fnc_cat", SqlDbType.VarChar, 10)
                parameterfnc_cat.Value = FncCat
                MyCmd.Parameters.Add(parameterfnc_cat)

                Dim parameteremp_hrs As New System.Data.SqlClient.SqlParameter("@emp_hrs", SqlDbType.Decimal, 8)
                parameteremp_hrs.Value = EmpHrs
                MyCmd.Parameters.Add(parameteremp_hrs)

                Dim parameterjob_nbr As New System.Data.SqlClient.SqlParameter("@job_nbr", SqlDbType.Int, 4)
                parameterjob_nbr.Value = JobNumber
                MyCmd.Parameters.Add(parameterjob_nbr)

                Dim parameterjob_cmp_nbr As New System.Data.SqlClient.SqlParameter("@job_cmp_nbr", SqlDbType.SmallInt, 2)
                parameterjob_cmp_nbr.Value = JobComponentNbr
                MyCmd.Parameters.Add(parameterjob_cmp_nbr)

                Dim parameterdp_tm As New System.Data.SqlClient.SqlParameter("@dp_tm", SqlDbType.VarChar, 4)
                If String.IsNullOrWhiteSpace(DeptTeam) Then
                    parameterdp_tm.Value = DBNull.Value
                Else
                    parameterdp_tm.Value = DeptTeam
                End If
                MyCmd.Parameters.Add(parameterdp_tm)

                Dim parameterstart_time As New System.Data.SqlClient.SqlParameter("@start_time", SqlDbType.Char, 4)
                parameterstart_time.Value = ""
                MyCmd.Parameters.Add(parameterstart_time)

                Dim parameterend_time As New System.Data.SqlClient.SqlParameter("@end_time", SqlDbType.Char, 4)
                parameterend_time.Value = ""
                MyCmd.Parameters.Add(parameterend_time)
                If ProdCat = Nothing Then
                    ProdCat = ""
                End If

                Dim parameterProdCat As New System.Data.SqlClient.SqlParameter("@ProdCat", SqlDbType.VarChar, 10)
                If String.IsNullOrWhiteSpace(ProdCat) Then
                    parameterProdCat.Value = DBNull.Value
                Else
                    parameterProdCat.Value = ProdCat
                End If
                MyCmd.Parameters.Add(parameterProdCat)

                Dim parameterUserID As New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)
                parameterUserID.Value = UserID
                MyCmd.Parameters.Add(parameterUserID)

                Dim parametererror_text As New System.Data.SqlClient.SqlParameter("@error_text", SqlDbType.VarChar)
                parametererror_text.Value = ""
                MyCmd.Parameters.Add(parametererror_text)

                Dim parameterComments As New System.Data.SqlClient.SqlParameter("@comments", SqlDbType.NText, 1073741823)
                If String.IsNullOrWhiteSpace(Comments) Then
                    parameterComments.Value = DBNull.Value
                Else
                    parameterComments.Value = Comments.Trim
                End If
                MyCmd.Parameters.Add(parameterComments)

                Dim parameterAlertID As New System.Data.SqlClient.SqlParameter("@ALERT_ID", SqlDbType.Int, 4)
                If AlertID = 0 Then
                    parameterAlertID.Value = System.DBNull.Value
                Else
                    parameterAlertID.Value = AlertID
                End If
                MyCmd.Parameters.Add(parameterAlertID)

                Dim parameterAllowDuplicate As New System.Data.SqlClient.SqlParameter("@ALLOW_DUPLICATE", SqlDbType.Bit)
                parameterAllowDuplicate.Value = AllowDuplicate
                MyCmd.Parameters.Add(parameterAllowDuplicate)

                Dim parameterCREATE_DATE As New System.Data.SqlClient.SqlParameter("@CREATE_DATE", SqlDbType.SmallDateTime)
                ' task code cannot be changed via webvantage YET.
                Dim parameterTaskCode As New System.Data.SqlClient.SqlParameter("@taskCode", SqlDbType.VarChar, 10)
                Dim TaskCode As String = Nothing

                Using DbContext = New AdvantageFramework.Database.DbContext(ConnectionString, UserID)

                    If EtId > 0 AndAlso EtDtlId > 0 Then

                        Try

                            TaskCode = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT TRF_CODE FROM dbo.EMP_TIME_DTL WHERE ET_ID = {0} AND ET_DTL_ID = {1}", EtId, EtDtlId)).FirstOrDefault

                        Catch ex As Exception
                        End Try

                    End If
                    If String.IsNullOrEmpty(TaskCode) Then

                        parameterTaskCode.Value = DBNull.Value

                    Else

                        parameterTaskCode.Value = TaskCode

                    End If

                    parameterCREATE_DATE.Value = AdvantageFramework.Database.Procedures.Generic.TimeZoneTodayForEmployee(DbContext, EmpCode)

                End Using

                MyCmd.Parameters.Add(parameterTaskCode)
                MyCmd.Parameters.Add(parameterCREATE_DATE)

                Try
                    Dim ds As New DataSet
                    Try

                        MyConn.Open()
                        MyAdapter.Fill(ds)

                    Catch ex As Exception
                        ErrorMessage = AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString())
                        Return False
                    Finally

                        If MyConn.State = ConnectionState.Open Then

                            MyConn.Close()
                            MyConn.Dispose()

                        End If

                    End Try

                    ErrorMessage = ds.Tables(ds.Tables.Count - 1).Rows(0)("RETURN_MESSAGE")

                    Try
                        If Not ds Is Nothing Then
                            ds.Dispose()
                            ds = Nothing
                        End If
                    Catch ex As Exception
                    End Try

                    If ErrorMessage.IndexOf("SUCCESS") > -1 OrElse String.IsNullOrWhiteSpace(ErrorMessage) = True Then

                        Success = True

                        If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                            ErrorMessage = AdvantageFramework.StringUtilities.RemoveTrailingDelimiter(ErrorMessage, "|")

                            If ErrorMessage.IndexOf("INSERT") > -1 And ErrorMessage.IndexOf("|") > -1 Then
                                Try
                                    Dim ar() As String
                                    ar = ErrorMessage.Split("|")
                                    'ErrorMessage = ar(0)
                                    NewEt_Id = CType(ar(1), Integer)
                                    NewEtd_Id = CType(ar(2), Integer)
                                    EmpHrs = CType(AdvantageFramework.StringUtilities.FormatDecimal(ar(3)), Decimal)
                                Catch ex As Exception
                                    NewEt_Id = 0
                                    NewEtd_Id = 0
                                    ErrorMessage = AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString())
                                    Return False
                                End Try
                            End If
                            If ErrorMessage.IndexOf("UPDATE") > -1 And ErrorMessage.IndexOf("|") > -1 Then
                                Try
                                    Dim ar() As String
                                    ar = ErrorMessage.Split("|")
                                    'ErrorMessage = ar(0)
                                    NewEt_Id = CType(ar(1), Integer)
                                    NewEtd_Id = CType(ar(2), Integer)
                                    EmpHrs = CType(AdvantageFramework.StringUtilities.FormatDecimal(ar(3)), Decimal)
                                Catch ex As Exception
                                    NewEt_Id = 0
                                    NewEtd_Id = 0
                                    ErrorMessage = AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString())
                                    Return False
                                End Try
                            End If

                        End If

                    Else

                        Success = False

                        If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                            If ErrorMessage.IndexOf("UPDATE_FAIL|") > -1 Then
                                Try
                                    Dim ar() As String
                                    ar = ErrorMessage.Split("|")
                                    NewEt_Id = CType(ar(1), Integer)
                                    NewEtd_Id = CType(ar(2), Integer)
                                    EmpHrs = CType(ar(3), Decimal)
                                Catch ex As Exception
                                    NewEt_Id = 0
                                    NewEtd_Id = 0
                                    ErrorMessage = AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString())
                                    Success = False
                                End Try
                            End If

                        End If

                    End If

                Catch ex As Exception
                    ErrorMessage = AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString())
                    Success = False
                End Try

            Catch ex As Exception
                ErrorMessage = AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString())
                Success = False
            End Try

            Return Success

        End Function

        Public Function HasStopWatch(ByVal ConnectionString As String, ByVal EmpCode As String, ByVal StartDate As Date, ByVal EndDate As Date, _
                                               Optional ByRef StopwatchEtId As Integer = 0, Optional ByRef StopwatchEtDtlId As Integer = 0, _
                                               Optional ByRef StopwatchStart As Date = Nothing, _
                                               Optional ByRef ExistingTimeComment As String = "",
                                               Optional ByRef TimeDescription As String = "",
                                               Optional ByRef CurrentServerTime As Date = Nothing) As Boolean
            Dim i As Integer = 0

            Using MyConn As New System.Data.SqlClient.SqlConnection(ConnectionString)
                Dim MyCommand As New System.Data.SqlClient.SqlCommand()
                With MyCommand
                    .CommandType = CommandType.StoredProcedure
                    .CommandText = "usp_wv_ts_HasStopwatch"
                    .Connection = MyConn
                End With

                Dim pEmpCode As New System.Data.SqlClient.SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
                pEmpCode.Value = EmpCode
                Dim pStartDate As New System.Data.SqlClient.SqlParameter("@START_DATE", SqlDbType.SmallDateTime)
                pStartDate.Value = StartDate
                Dim pEndDate As New System.Data.SqlClient.SqlParameter("@END_DATE", SqlDbType.SmallDateTime)
                pEndDate.Value = EndDate

                MyCommand.Parameters.Add(pEmpCode)
                MyCommand.Parameters.Add(pStartDate)
                MyCommand.Parameters.Add(pEndDate)

                MyConn.Open()

                Dim Reader As System.Data.SqlClient.SqlDataReader
                Reader = MyCommand.ExecuteReader()

                If Reader.HasRows = True Then
                    Do While Reader.Read()
                        i = Reader.GetValue(Reader.GetOrdinal("HAS_STOPWATCH"))
                        StopwatchEtId = Reader.GetValue(Reader.GetOrdinal("STOPWATCH_ET_ID"))
                        StopwatchEtDtlId = Reader.GetValue(Reader.GetOrdinal("STOPWATCH_ET_DTL_ID"))
                        If Reader.IsDBNull(Reader.GetOrdinal("STOPWATCH_START_TIME")) = False Then
                            StopwatchStart = Reader.GetDateTime(Reader.GetOrdinal("STOPWATCH_START_TIME"))
                        End If
                        If Reader.IsDBNull(Reader.GetOrdinal("COMMENT")) = False Then
                            ExistingTimeComment = Reader(Reader.GetOrdinal("COMMENT"))
                        End If
                        If Reader.IsDBNull(Reader.GetOrdinal("DESCRIPTION")) = False Then
                            TimeDescription = Reader(Reader.GetOrdinal("DESCRIPTION"))
                        End If
                        If Reader.IsDBNull(Reader.GetOrdinal("CURR_SERVER_TIME")) = False Then
                            CurrentServerTime = Reader(Reader.GetOrdinal("CURR_SERVER_TIME"))
                        End If
                    Loop
                End If

            End Using

            If i > 0 Then
                Return True
            Else
                Return False
            End If

        End Function
        Public Function HasStopWatch(ByVal ConnectionString As String, ByVal UserCode As String, ByVal EmpCode As String,
                                               Optional ByRef StopwatchEtId As Integer = 0, Optional ByRef StopwatchEtDtlId As Integer = 0,
                                               Optional ByRef StopwatchStart As Date = Nothing,
                                               Optional ByRef ExistingComment As String = "",
                                               Optional ByRef FuncCatDescription As String = "",
                                               Optional ByRef TimeType As String = "",
                                               Optional ByRef CurrentServerTime As Date = Nothing) As Boolean

            Dim i As Integer = 0
            Using DbContext = New AdvantageFramework.Database.DbContext(ConnectionString, UserCode)


                Using MyConn As New System.Data.SqlClient.SqlConnection(ConnectionString)
                    Dim MyCommand As New System.Data.SqlClient.SqlCommand()
                    With MyCommand
                        .CommandType = CommandType.StoredProcedure
                        .CommandText = "usp_wv_ts_HasStopwatch"
                        .Connection = MyConn
                    End With

                    Dim pEmpCode As New System.Data.SqlClient.SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
                    pEmpCode.Value = EmpCode
                    Dim pStartDate As New System.Data.SqlClient.SqlParameter("@START_DATE", SqlDbType.SmallDateTime)
                    pStartDate.Value = System.DBNull.Value
                    Dim pEndDate As New System.Data.SqlClient.SqlParameter("@END_DATE", SqlDbType.SmallDateTime)
                    pEndDate.Value = System.DBNull.Value

                    MyCommand.Parameters.Add(pEmpCode)
                    MyCommand.Parameters.Add(pStartDate)
                    MyCommand.Parameters.Add(pEndDate)

                    MyConn.Open()

                    Dim Reader As System.Data.SqlClient.SqlDataReader
                    Reader = MyCommand.ExecuteReader()

                    If Reader.HasRows = True Then

                        Do While Reader.Read()

                            i = Reader(Reader.GetOrdinal("HAS_STOPWATCH"))
                            StopwatchEtId = CType(Reader(Reader.GetOrdinal("STOPWATCH_ET_ID")), Integer)
                            StopwatchEtDtlId = CType(Reader(Reader.GetOrdinal("STOPWATCH_ET_DTL_ID")), Integer)

                            If Reader.IsDBNull(Reader.GetOrdinal("STOPWATCH_START_TIME")) = False Then
                                StopwatchStart = CType(Reader(Reader.GetOrdinal("STOPWATCH_START_TIME")), Date)
                            End If

                            If Reader.IsDBNull(Reader.GetOrdinal("COMMENT")) = False Then
                                ExistingComment = Reader(Reader.GetOrdinal("COMMENT"))
                            End If

                            If Reader.IsDBNull(Reader.GetOrdinal("DESCRIPTION")) = False Then
                                FuncCatDescription = Reader(Reader.GetOrdinal("DESCRIPTION"))
                            End If

                            If Reader.IsDBNull(Reader.GetOrdinal("TIME_TYPE")) = False Then
                                TimeType = Reader(Reader.GetOrdinal("TIME_TYPE"))
                            End If

                            If Reader.IsDBNull(Reader.GetOrdinal("CURR_SERVER_TIME")) = False Then

                                CurrentServerTime = AdvantageFramework.Database.Procedures.Generic.TimeZoneTodayForEmployee(DbContext, EmpCode)

                            End If

                        Loop

                    End If

                End Using

            End Using

            If i > 0 Then

                Return True

            Else

                Return False

            End If

        End Function

        Public Function StopwatchStart(ByVal ConnectionString As String, ByVal UserCode As String, ByVal EmpCode As String, ByVal EtId As Integer, ByVal EtDtlId As Integer, Optional ByRef ErrorMessage As String = "") As Boolean
            Try

                Dim StopwatchStarted As Boolean = False
                ErrorMessage = ""

                Using MyConn As New System.Data.SqlClient.SqlConnection(ConnectionString)

                    MyConn.Open()

                    Using MyCommand = New System.Data.SqlClient.SqlCommand()

                        With MyCommand

                            .CommandType = CommandType.StoredProcedure
                            .CommandText = "usp_wv_ts_StopwatchStart"
                            .Connection = MyConn

                        End With

                        Dim pEmpCode As New System.Data.SqlClient.SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
                        pEmpCode.Value = EmpCode

                        Dim pEtId As New System.Data.SqlClient.SqlParameter("@ET_ID", SqlDbType.Int)
                        pEtId.Value = EtId

                        Dim pEtDtlId As New System.Data.SqlClient.SqlParameter("@ET_DTL_ID", SqlDbType.SmallInt)
                        pEtDtlId.Value = EtDtlId

                        Dim pUserCode As New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)
                        pUserCode.Value = UserCode

                        Dim pCreateDate As New System.Data.SqlClient.SqlParameter("@CREATE_DATE", SqlDbType.SmallDateTime)

                        Using DbContext = New AdvantageFramework.Database.DbContext(ConnectionString, UserCode)

                            pCreateDate.Value = AdvantageFramework.Database.Procedures.Generic.TimeZoneTodayForEmployee(DbContext, EmpCode)

                        End Using

                        MyCommand.Parameters.Add(pEmpCode)
                        MyCommand.Parameters.Add(pEtId)
                        MyCommand.Parameters.Add(pEtDtlId)
                        MyCommand.Parameters.Add(pUserCode)
                        MyCommand.Parameters.Add(pCreateDate)

                        'ErrorMessage = MyCommand.ExecuteScalar()

                        Using MyAdapter = New System.Data.SqlClient.SqlDataAdapter(MyCommand)

                            Dim MyDataSet As New DataSet
                            MyAdapter.Fill(MyDataSet)

                            If MyDataSet IsNot Nothing AndAlso MyDataSet.Tables.Count > 0 Then

                                Try

                                    ErrorMessage = MyDataSet.Tables(MyDataSet.Tables.Count - 1).Rows(0)(0) 'Get last table

                                Catch ex As Exception
                                    ErrorMessage = ""
                                End Try

                            End If

                        End Using

                        If ErrorMessage <> "" AndAlso ErrorMessage.Contains("|") = True Then

                            If ErrorMessage.Contains("SUCCESS") Then

                                StopwatchStarted = True

                            Else

                                Dim ar() As String
                                ar = ErrorMessage.Split("|")

                                ErrorMessage = ar(1)

                                If IsNumeric(ar(2)) = True AndAlso CType(ar(2), Integer) = 1 Then

                                    StopwatchStarted = True

                                End If

                            End If

                        End If

                    End Using

                    If MyConn.State = ConnectionState.Open Then

                        MyConn.Close()
                        MyConn.Dispose()

                    End If

                End Using

                'DeleteZeroHours(EmpCode, Now.Date)
                Return StopwatchStarted

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString()
                Return False
            End Try
        End Function
        Public Function StopwatchStart(ByVal ConnectionString As String,
                                       ByVal UserCode As String,
                                       ByVal EmpCode As String,
                                       ByVal JobNumber As Integer,
                                       ByVal JobComponentNbr As Integer,
                                       ByVal TaskSeqNbr As Integer,
                                       ByVal AlertID As Integer,
                                       ByRef ErrorMessage As String) As Boolean
            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(ConnectionString, UserCode)

                    Dim EtId As Integer = 0
                    Dim EtDtlId As Integer = 0

                    '...what to do about validation??????

                    Dim DefaultFunction As String = ""
                    Dim DefaultDepartment As String = ""
                    Dim ProdCat As String = ""

                    Using MyConn As New System.Data.SqlClient.SqlConnection(ConnectionString)
                        Dim MyCommand As New System.Data.SqlClient.SqlCommand()
                        With MyCommand
                            .CommandType = CommandType.StoredProcedure
                            .CommandText = "usp_wv_ts_DefaultFunctionAndDept"
                            .Connection = MyConn
                        End With

                        Dim pEmpCode As New System.Data.SqlClient.SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
                        pEmpCode.Value = EmpCode

                        Dim pJobNumber As New System.Data.SqlClient.SqlParameter("@JOB_NUMBER", SqlDbType.Int)
                        pJobNumber.Value = JobNumber
                        Dim pJobComponentNbr As New System.Data.SqlClient.SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
                        pJobComponentNbr.Value = JobComponentNbr
                        Dim pSeqNbr As New System.Data.SqlClient.SqlParameter("@SEQ_NBR", SqlDbType.SmallInt)
                        pSeqNbr.Value = TaskSeqNbr

                        MyCommand.Parameters.Add(pEmpCode)
                        MyCommand.Parameters.Add(pJobNumber)
                        MyCommand.Parameters.Add(pJobComponentNbr)
                        MyCommand.Parameters.Add(pSeqNbr)

                        MyConn.Open()

                        Dim Reader As System.Data.SqlClient.SqlDataReader
                        Reader = MyCommand.ExecuteReader()

                        If Reader.HasRows = True Then
                            Do While Reader.Read()
                                If IsDBNull(Reader(Reader.GetOrdinal("FNC_CODE"))) = False Then
                                    DefaultFunction = Reader.GetString(Reader.GetOrdinal("FNC_CODE"))
                                End If
                                If IsDBNull(Reader(Reader.GetOrdinal("DP_TM_CODE"))) = False Then
                                    DefaultDepartment = Reader.GetString(Reader.GetOrdinal("DP_TM_CODE"))
                                End If
                            Loop
                        End If

                        If DefaultFunction = "" Then
                            ErrorMessage = "There is not a default function associated with this record. Please ensure that you have a default function established before continuing. Stop Watch will be cancelled."
                            Return False
                        End If

                        If DefaultDepartment = "" Then
                            ErrorMessage = "There is not a department associated with this employee. Please ensure that you have a department established before continuing. Stop Watch will be cancelled."
                            Return False
                        End If

                        If JobNumber > 0 And JobComponentNbr > 0 And DefaultFunction <> "" And DefaultDepartment <> "" Then

                            If JobCompIsEditable(ConnectionString, JobNumber, JobComponentNbr) = False Then

                                ErrorMessage = "Job/Component Process Control does not allow access."
                                Return False

                            End If

                            If FunctionIsValid(ConnectionString, EmpCode, DefaultFunction) = False Then

                                ErrorMessage = AdvantageFramework.StringUtilities.JavascriptSafe(DefaultFunction) & " is an invalid Function."
                                Return False

                            End If


                            If SaveDay(ConnectionString, 0, 0, EmpCode, AdvantageFramework.Database.Procedures.Generic.TimeZoneTodayForEmployee(DbContext, EmpCode), DefaultFunction, ProdCat, 0.0,
                                       JobNumber, JobComponentNbr, DefaultDepartment, UserCode, ErrorMessage, "", EtId, EtDtlId, True, AlertID) = True Then

                                If EtId > 0 And EtDtlId > 0 Then

                                    If StopwatchStart(ConnectionString, UserCode, EmpCode, EtId, EtDtlId, ErrorMessage) = True Then

                                        Return True

                                    Else

                                        Return False

                                    End If

                                End If

                            Else

                                Return False

                            End If

                        Else

                            ErrorMessage = "Could not get Job Component details needed to start the Stopwatch"
                            Return False

                        End If

                    End Using

                    ErrorMessage = ""
                    Return True
                End Using

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString()
                Return False
            End Try

        End Function

        Public Function StopwatchStop(ByVal ConnectionString As String, ByVal UserCode As String, ByVal EmpCode As String, ByVal EtId As Integer, ByVal EtDtlId As Integer, _
                                                ByRef HoursSaved As Double, ByVal Comment As String, Optional ByRef ErrorMessage As String = "") As Boolean
            Try

                HoursSaved = 0.0
                Dim CanEdit As Integer = 1
                Using DbContext = New AdvantageFramework.Database.DbContext(ConnectionString, UserCode)

                    Using MyConn As New System.Data.SqlClient.SqlConnection(ConnectionString)

                        Dim MyCommand As New System.Data.SqlClient.SqlCommand()
                        With MyCommand

                            .CommandType = CommandType.StoredProcedure
                            .CommandText = "usp_wv_ts_StopwatchStop"
                            .Connection = MyConn

                        End With

                        Dim pEmpCode As New System.Data.SqlClient.SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
                        pEmpCode.Value = EmpCode
                        Dim pEtId As New System.Data.SqlClient.SqlParameter("@ET_ID", SqlDbType.Int)
                        pEtId.Value = EtId
                        Dim pEtDtlId As New System.Data.SqlClient.SqlParameter("@ET_DTL_ID", SqlDbType.SmallInt)
                        pEtDtlId.Value = EtDtlId
                        Dim pComment As New System.Data.SqlClient.SqlParameter("@COMMENT", SqlDbType.Text)
                        If Comment.Trim() = "" Then
                            pComment.Value = System.DBNull.Value
                        Else
                            pComment.Value = Comment
                        End If
                        Dim pUserCode As New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)
                        pUserCode.Value = UserCode

                        Dim pCreateDate As New System.Data.SqlClient.SqlParameter("@CREATE_DATE", SqlDbType.SmallDateTime)
                        pCreateDate.Value = AdvantageFramework.Database.Procedures.Generic.TimeZoneTodayForEmployee(DbContext, EmpCode)

                        MyCommand.Parameters.Add(pEmpCode)
                        MyCommand.Parameters.Add(pEtId)
                        MyCommand.Parameters.Add(pEtDtlId)
                        MyCommand.Parameters.Add(pComment)
                        MyCommand.Parameters.Add(pUserCode)
                        MyCommand.Parameters.Add(pCreateDate)

                        Dim MyAdapter As New System.Data.SqlClient.SqlDataAdapter(MyCommand)

                        Dim ds As New DataSet
                        MyConn.Open()
                        MyAdapter.Fill(ds)

                        Dim dt As DataTable

                        If ds.Tables.Count > 0 Then

                            dt = ds.Tables(ds.Tables.Count - 1)

                            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then

                                HoursSaved = CType(dt.Rows(0)("EMP_HOURS"), Double)
                                CanEdit = CType(dt.Rows(0)("CAN_EDIT"), Integer)
                                ErrorMessage = dt.Rows(0)("RETURN_MESSAGE").ToString()

                            End If

                        End If

                        If MyConn.State = ConnectionState.Open Then

                            MyConn.Close()
                            MyConn.Dispose()

                        End If

                    End Using

                End Using

                If CanEdit = 0 Then

                    Return False

                Else

                    'DeleteZeroHours(EmpCode, Now.Date)
                    Return True

                End If
            Catch ex As Exception

                ErrorMessage = ex.Message.ToString()
                Return False

            End Try
        End Function

        Public Function StopwatchClear(ByVal ConnectionString As String, ByVal EmpCode As String, Optional ByRef ErrorMessage As String = "") As Boolean
            Try
                Using MyConn As New System.Data.SqlClient.SqlConnection(ConnectionString)
                    Dim MyCommand As New System.Data.SqlClient.SqlCommand()
                    With MyCommand
                        .CommandType = CommandType.Text
                        .CommandText = "UPDATE EMP_TIME WITH(ROWLOCK) SET STOP_WATCH_START_TIME = NULL, STOP_WATCH_ET_DTL_ID = NULL WHERE EMP_CODE = @EMP_CODE;"
                        .Connection = MyConn
                    End With

                    Dim pEmpCode As New System.Data.SqlClient.SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
                    pEmpCode.Value = EmpCode

                    MyCommand.Parameters.Add(pEmpCode)

                    MyConn.Open()

                    MyCommand.ExecuteNonQuery()

                    If MyConn.State = ConnectionState.Open Then
                        MyConn.Close()
                        MyConn.Dispose()
                    End If

                End Using

                'DeleteZeroHours(EmpCode, Now.Date)

                ErrorMessage = ""
                Return True

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString()
                Return False
            End Try
        End Function

        Public Function GetDateRange(ByVal TheDate As Date, ByRef StartDate As Date, ByRef EndDate As Date, Optional ByVal ErrorMessage As String = "") As Boolean
            Try
                If TheDate = Nothing Then TheDate = Now.Date

                If TheDate.DayOfWeek = DayOfWeek.Sunday Then
                    StartDate = TheDate
                Else
                    StartDate = TheDate.AddDays(-TheDate.DayOfWeek + DayOfWeek.Sunday)
                End If

                'HttpContext.Current.Session("TimesheetStartDate") = StartDate

                EndDate = StartDate.AddDays(6)
                'HttpContext.Current.Session("TimesheetEndDate") = EndDate

                ErrorMessage = ""
                Return True

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString()
                Return False
            End Try
        End Function

        Public Function DeleteZeroHours(ByVal ConnectionString As String, ByVal EmpCode As String, ByVal [Date] As Date, Optional ByRef ErrorMessage As String = "") As Boolean
            Return True
            'Try
            '    Using MyConn As New System.Data.SqlClient.SqlConnection(ConnectionString)
            '        Dim MyCommand As New System.Data.SqlClient.SqlCommand()
            '        With MyCommand
            '            .CommandType = CommandType.StoredProcedure
            '            .CommandText = "usp_wv_ts_DeleteZeroHours"
            '            .Connection = MyConn
            '        End With

            '        Dim pEmpCode As New System.Data.SqlClient.SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
            '        pEmpCode.Value = EmpCode
            '        Dim pDate As New System.Data.SqlClient.SqlParameter("@DATE", SqlDbType.SmallDateTime)
            '        pDate.Value = [Date]

            '        MyCommand.Parameters.Add(pEmpCode)
            '        MyCommand.Parameters.Add(pDate)

            '        MyConn.Open()

            '        MyCommand.ExecuteNonQuery()

            '        If MyConn.State = ConnectionState.Open Then
            '            MyConn.Close()
            '            MyConn.Dispose()
            '        End If

            '    End Using
            '    ErrorMessage = ""
            '    Return True
            'Catch ex As Exception
            '    ErrorMessage = ex.Message.ToString()
            '    Return False
            'End Try
        End Function
        Public Function DeletePriorZeroHours(ByVal ConnectionString As String, ByVal EmpCode As String, ByVal PriorToDate As Date, Optional ByRef ErrorMessage As String = "") As Boolean
            Return True
            'Try
            '    'if priordate is bigger than first day of current week
            '    Dim CutOffDate As Date
            '    Dim FirstDayOfThisWeek As Date
            '    If Now.Date.DayOfWeek = DayOfWeek.Sunday Then

            '        FirstDayOfThisWeek = Now.Date

            '    Else

            '        FirstDayOfThisWeek = Now.Date.AddDays(-Now.Date.DayOfWeek + DayOfWeek.Sunday)

            '    End If

            '    If PriorToDate >= FirstDayOfThisWeek Then

            '        PriorToDate = FirstDayOfThisWeek

            '    End If

            '    If PriorToDate.Date.DayOfWeek = DayOfWeek.Sunday Then

            '        CutOffDate = PriorToDate

            '    Else

            '        CutOffDate = PriorToDate.AddDays(-PriorToDate.DayOfWeek + DayOfWeek.Sunday)

            '    End If

            '    Using MyConn As New System.Data.SqlClient.SqlConnection(ConnectionString)

            '        Dim MyCommand As New System.Data.SqlClient.SqlCommand()

            '        With MyCommand

            '            .CommandType = CommandType.StoredProcedure
            '            .CommandText = "usp_wv_ts_DeletePriorZeroHours"
            '            .Connection = MyConn

            '        End With

            '        Dim pEmpCode As New System.Data.SqlClient.SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
            '        pEmpCode.Value = EmpCode

            '        Dim pDate As New System.Data.SqlClient.SqlParameter("@CUTOFF_DATE", SqlDbType.SmallDateTime)
            '        pDate.Value = CutOffDate

            '        MyCommand.Parameters.Add(pEmpCode)
            '        MyCommand.Parameters.Add(pDate)

            '        MyConn.Open()

            '        MyCommand.ExecuteNonQuery()

            '        If MyConn.State = ConnectionState.Open Then

            '            MyConn.Close()
            '            MyConn.Dispose()

            '        End If

            '    End Using

            '    ErrorMessage = ""
            '    Return True

            'Catch ex As Exception

            '    ErrorMessage = ex.Message.ToString()
            '    Return False

            'End Try
        End Function

        Public Function GetDaysByApprovalType(ByVal ConnectionString As String, ByVal EmpCode As String, ByVal StartDate As Date, ByVal EndDate As Date, ByVal ApprovalType As TimesheetApprovalType) As List(Of _TimesheetDay)
            Dim list As New List(Of _TimesheetDay)
            Using MyConn As New System.Data.SqlClient.SqlConnection(ConnectionString)
                Dim MyCommand As New System.Data.SqlClient.SqlCommand()
                With MyCommand
                    .CommandType = CommandType.StoredProcedure
                    .CommandText = "usp_wv_ts_DaysByApprovalStatus"
                    .Connection = MyConn
                End With

                Dim pStartDate As New System.Data.SqlClient.SqlParameter("@START_DATE", SqlDbType.SmallDateTime)
                pStartDate.Value = StartDate
                Dim pEndDate As New System.Data.SqlClient.SqlParameter("@END_DATE", SqlDbType.SmallDateTime)
                pEndDate.Value = EndDate
                Dim pEmpCode As New System.Data.SqlClient.SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
                pEmpCode.Value = EmpCode
                Dim pStatus As New System.Data.SqlClient.SqlParameter("@STATUS", SqlDbType.SmallInt)
                pStatus.Value = CType(ApprovalType, Integer)

                MyCommand.Parameters.Add(pStartDate)
                MyCommand.Parameters.Add(pEndDate)
                MyCommand.Parameters.Add(pEmpCode)
                MyCommand.Parameters.Add(pStatus)

                MyConn.Open()

                Dim Reader As System.Data.SqlClient.SqlDataReader
                Reader = MyCommand.ExecuteReader()

                If Reader.HasRows = True Then

                    Do While Reader.Read()
                        If Reader.IsDBNull(Reader.GetOrdinal("THE_DATE")) = False Then

                            Dim d As New _TimesheetDay

                            d.Date = Reader.GetDateTime(Reader.GetOrdinal("THE_DATE"))
                            d.Status = CType(Reader.GetValue(Reader.GetOrdinal("TIMESHEET_APPROVAL_TYPE")), TimesheetApprovalType)
                            d.TotalHours = Reader.GetValue(Reader.GetOrdinal("TOTAL_HOURS"))
                            d.DailyHours = Reader.GetValue(Reader.GetOrdinal("STD_HRS"))
                            d.PercentCompletedOfDailyHours = Reader.GetValue(Reader.GetOrdinal("PERCENT_OF_STD_HRS"))
                            If Reader.GetValue(Reader.GetOrdinal("POSTPERIOD_CLOSED")) = 1 Then
                                d.PostPeriodIsClosed = True
                            End If
                            list.Add(d)

                        End If
                    Loop
                End If

            End Using

            Return list

        End Function

        Private Function PostPeriodClosed(ByVal ConnectionString As String, ByVal [Date] As Date, Optional ByRef ErrorMessage As String = "") As Boolean
            Try
                Dim ReturnValue As Boolean = False
                Using MyConn As New System.Data.SqlClient.SqlConnection(ConnectionString)
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

        Public Sub GetTotalsFromTimesheet(ByRef ts As TimeSheet, ByRef Sunday As Double,
                                                                 ByRef Monday As Double,
                                                                 ByRef Tuesday As Double,
                                                                 ByRef Wednesday As Double,
                                                                 ByRef Thursday As Double,
                                                                 ByRef Friday As Double,
                                                                 ByRef Saturday As Double,
                                                                 ByRef Total As Double)

            Sunday = CType(0, Double)
            Monday = CType(0, Double)
            Tuesday = CType(0, Double)
            Wednesday = CType(0, Double)
            Thursday = CType(0, Double)
            Friday = CType(0, Double)
            Saturday = CType(0, Double)
            Total = CType(0, Double)

            For Each line As AdvantageFramework.Timesheet.TimesheetLine In ts

                If Not line.Sunday Is Nothing Then Sunday += line.Sunday.Hours
                If Not line.Monday Is Nothing Then Monday += line.Monday.Hours
                If Not line.Tuesday Is Nothing Then Tuesday += line.Tuesday.Hours
                If Not line.Wednesday Is Nothing Then Wednesday += line.Wednesday.Hours
                If Not line.Thursday Is Nothing Then Thursday += line.Thursday.Hours
                If Not line.Friday Is Nothing Then Friday += line.Friday.Hours
                If Not line.Saturday Is Nothing Then Saturday += line.Saturday.Hours

            Next

            Total = Sunday + Monday + Tuesday + Wednesday + Thursday + Friday + Saturday

        End Sub

#Region " Validation "

        Public Function JobCompIsEditable(ByVal ConnectionString As String, ByVal strJobNum As String, ByVal strJobCompNum As String, Optional ByVal OnlyClosedProcessControls As Boolean = False) As Boolean
            If strJobNum = "" Or strJobNum = String.Empty Or IsNumeric(strJobNum) = False Or strJobCompNum = "" Or strJobCompNum = String.Empty Or IsNumeric(strJobCompNum) = False Then

                Return False

            Else

                Dim IsValid As Boolean = False

                Dim ireturn As Integer = 0

                Try

                    Using MyConn As New System.Data.SqlClient.SqlConnection(ConnectionString)

                        Dim MyCommand As New System.Data.SqlClient.SqlCommand()
                        With MyCommand
                            .CommandType = CommandType.StoredProcedure
                            .CommandText = "usp_wv_validate_JobCompIsEditable"
                            .Connection = MyConn
                        End With

                        Dim parameterJobNum As New System.Data.SqlClient.SqlParameter("@JobNum", SqlDbType.Int)
                        parameterJobNum.Value = strJobNum
                        MyCommand.Parameters.Add(parameterJobNum)

                        Dim parameterJobCompNum As New System.Data.SqlClient.SqlParameter("@JobCompNum", SqlDbType.Int)
                        parameterJobCompNum.Value = strJobCompNum
                        MyCommand.Parameters.Add(parameterJobCompNum)

                        Dim parameterOnlyClosedProcessControls As New System.Data.SqlClient.SqlParameter("@OnlyClosedProcessControls", SqlDbType.SmallInt)
                        If OnlyClosedProcessControls = True Then
                            parameterOnlyClosedProcessControls.Value = 1
                        Else
                            parameterOnlyClosedProcessControls.Value = 0
                        End If
                        MyCommand.Parameters.Add(parameterOnlyClosedProcessControls)

                        MyConn.Open()

                        ireturn = CInt(MyCommand.ExecuteScalar())

                    End Using

                Catch

                    ireturn = 0

                End Try

                If ireturn > 0 Then

                    IsValid = True

                Else

                    IsValid = False

                End If

                Return IsValid

            End If

        End Function
        Public Function FunctionIsValid(ByVal ConnectionString As String, ByVal Empcode As String, ByVal FuncCode As String) As Boolean

            Dim IsValid As Boolean = False

            If Empcode = "" Then

                Return False

            End If
            Try

                Using MyConn As New System.Data.SqlClient.SqlConnection(ConnectionString)

                    Dim MyCommand As New System.Data.SqlClient.SqlCommand()
                    With MyCommand

                        .CommandType = CommandType.StoredProcedure
                        .CommandText = "usp_wv_validate_functioncat_ts_addnew"
                        .Connection = MyConn

                    End With

                    Dim Tparameter1 As New System.Data.SqlClient.SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
                    Tparameter1.Value = Empcode

                    Dim Tparameter2 As New System.Data.SqlClient.SqlParameter("@FuncCode", SqlDbType.VarChar, 10)
                    Tparameter2.Value = FuncCode

                    MyCommand.Parameters.Add(Tparameter1)
                    MyCommand.Parameters.Add(Tparameter2)

                    MyConn.Open()

                    IsValid = CInt(MyCommand.ExecuteScalar())

                End Using

            Catch
                IsValid = False
            End Try

            Return IsValid

        End Function

#End Region

#End Region

    End Module

End Namespace


