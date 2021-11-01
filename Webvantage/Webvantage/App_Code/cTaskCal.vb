Imports System.Data
Imports System.Data.SqlClient
Imports System.text
Namespace TaskCalendar
    <Serializable()> Public Class Week
        Private mSun As String
        Private mMon As String
        Private mTue As String
        Private mWed As String
        Private mThu As String
        Private mFri As String
        Private mSat As String
        Private mLink As String


        Public Property Sunday() As String
            Get
                Return mSun
            End Get
            Set(ByVal Value As String)
                mSun = Value
            End Set
        End Property
        Public Property Monday() As String
            Get
                Return mMon
            End Get
            Set(ByVal Value As String)
                mMon = Value
            End Set
        End Property
        Public Property Tuesday() As String
            Get
                Return mTue
            End Get
            Set(ByVal Value As String)
                mTue = Value
            End Set
        End Property
        Public Property Wednesday() As String
            Get
                Return mWed
            End Get
            Set(ByVal Value As String)
                mWed = Value
            End Set
        End Property
        Public Property Thursday() As String
            Get
                Return mThu
            End Get
            Set(ByVal Value As String)
                mThu = Value
            End Set
        End Property
        Public Property Friday() As String
            Get
                Return mFri
            End Get
            Set(ByVal Value As String)
                mFri = Value
            End Set
        End Property
        Public Property Saturday() As String
            Get
                Return mSat
            End Get
            Set(ByVal Value As String)
                mSat = Value
            End Set
        End Property
        Public Property WeekLink() As String
            Get
                Return mLink
            End Get
            Set(ByVal Value As String)
                mLink = Value
            End Set
        End Property

        Public Sub Clear()
            mSun = ""
            mMon = ""
            mTue = ""
            mWed = ""
            mThu = ""
            mFri = ""
            mSat = ""

        End Sub
    End Class
    <Serializable()> Public Class Month
        Inherits CollectionBase
        Default Public Property Item(ByVal index As Integer) As Week
            Get
                Return CType(List(index), Week)
            End Get
            Set(ByVal Value As Week)
                List(index) = Value
            End Set
        End Property
        Public Function Add(ByVal value As Week) As Integer
            Return List.Add(value)
        End Function
        Public Function IndexOf(ByVal value As Week) As Integer
            Return List.IndexOf(value)
        End Function
        Public Sub Insert(ByVal index As Integer, ByVal value As Week)
            List.Insert(index, value)
        End Sub
        Public Sub Remove(ByVal value As Week)
            List.Remove(value)
        End Sub
        Public Function Contains(ByVal value As Week) As Boolean
            Return List.Contains(value)
        End Function
    End Class
    <Serializable()> Public Class DayMonthYear
        Public _day As Integer
        Public _month As Integer
        Public _year As Integer
        Public _task As String
    End Class

    <Serializable()> Public Class _Month
        Public _month As Integer
        Public _dayTasks(31) As String
    End Class

    <Serializable()> Public Class TaskDate
        Public _year As Integer
        Public _month As New _Month
        Public dayCt As Integer

        Public Sub initMonth()
            Dim idx As Int16
            Dim tempDate As Date
            Dim dateStr As String

            dateStr = _month._month.ToString() & "/1/" & _year.ToString
            tempDate = CType(dateStr, Date)
            dayCt = tempDate.DaysInMonth(_year, _month._month)

            For idx = 0 To dayCt 'init 0 but do not use
                _month._dayTasks(idx) = ""
            Next
        End Sub
    End Class

    <Serializable()> Public Class CDPJCTaskDates
        Public clCode As String
        Public divCode As String
        Public prdCode As String
        Public jobCode As Integer
        Public compCode As Int16
        Public clDesc As String
        Public divDesc As String
        Public prdDesc As String
        Public jobDesc As String
        Public compDesc As String
        Public trfDesc As String
        Public grouping As String
        Public TaskDates(12) As TaskDate
    End Class

    <Serializable()> Public Class cCalendar
        Private mConnString As String
        Dim oSQL As SqlHelper
        Private TaskDates(13) As TaskDate
        Private cdpjcCount As Integer
        Private _CDPJCTaskDates(1000) As CDPJCTaskDates
        Public InsertKey As Integer

        Public Function TaskDatesIDX(ByVal month As Integer, ByVal year As Integer) As Integer
            Try
                Dim idx As Int16
                For idx = 0 To 12
                    If Me.TaskDates(idx)._year = year Then
                        If Me.TaskDates(idx)._month._month = month Then
                            Return idx
                        End If
                    End If
                Next
                Return 0
            Catch ex As Exception
                Return -1
            End Try
        End Function

        Public Function CDPJCGroupIDX(ByVal cl As String, ByVal div As String, ByVal prd As String, ByVal job As Integer, ByVal comp As Int16, ByVal month As Integer, ByVal year As Integer, ByVal grpLvl As String, ByRef IDX_CDPJC As Int16, ByRef IDX_Month As Int16) As Integer
            Dim GrpIDX, mthIDX As Int16
            For GrpIDX = 1 To cdpjcCount
                If _CDPJCTaskDates(GrpIDX).clCode = cl Then
                    If grpLvl = "1" Then
                        IDX_CDPJC = GrpIDX
                        Exit For
                    End If

                    If _CDPJCTaskDates(GrpIDX).divCode = div Then
                        If grpLvl = "2" Then
                            IDX_CDPJC = GrpIDX
                            Exit For
                        End If

                        If _CDPJCTaskDates(GrpIDX).prdCode = prd Then
                            If grpLvl = "3" Then
                                IDX_CDPJC = GrpIDX
                                Exit For
                            End If

                            If _CDPJCTaskDates(GrpIDX).jobCode = job Then
                                If grpLvl = "4" Then
                                    IDX_CDPJC = GrpIDX
                                    Exit For
                                End If

                                If _CDPJCTaskDates(GrpIDX).compCode = comp Then
                                    If grpLvl = "5" Then
                                        IDX_CDPJC = GrpIDX
                                        Exit For
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            Next

            For mthIDX = 0 To 12
                If _CDPJCTaskDates(IDX_CDPJC).TaskDates(mthIDX)._year = year Then
                    If _CDPJCTaskDates(IDX_CDPJC).TaskDates(mthIDX)._month._month = month Then
                        IDX_Month = mthIDX
                        Exit For
                    End If
                End If
            Next

        End Function

        Public Function CDPJCMonthIDX(ByVal IDX_CDPJC As Integer, ByVal month As Integer, ByVal year As Integer) As Integer
            Dim mthIDX As Integer

            For mthIDX = 0 To 12
                If _CDPJCTaskDates(IDX_CDPJC).TaskDates(mthIDX)._year = year Then
                    If _CDPJCTaskDates(IDX_CDPJC).TaskDates(mthIDX)._month._month = month Then
                        Return mthIDX
                    End If
                End If
            Next

        End Function

        Private Function BoolToYN(ByVal input As Boolean) As String
            If input = True Then
                Return "Y"
            Else
                Return "N"

            End If
        End Function

        Public Function getTrfComment(ByVal job As Integer, ByVal comp As Integer) As String
            Dim SQL_STRING As String
            Dim dr As SqlDataReader
            Dim oSQL As SqlHelper
            Dim comment As String


            SQL_STRING = "SELECT TRF_COMMENTS FROM JOB_TRAFFIC "
            SQL_STRING += " WHERE JOB_NUMBER = " & CStr(job) & " AND JOB_COMPONENT_NBR = " & CStr(comp)

            Try
                dr = oSQL.ExecuteReader(mConnString, CommandType.Text, SQL_STRING)
            Catch
                Err.Raise(Err.Number, "Class:cTaskCal.vb Routine:getTrfComment", Err.Description)
            Finally

            End Try

            comment = ""
            If dr.HasRows Then
                dr.Read()
                If IsDBNull(dr(0)) = False Then
                    comment = dr.GetString(0)
                End If
            End If

            Return comment

        End Function

        Public Function GetTaskCalendarReportCDPJCGroup3(ByVal StartDate As String,
                                       ByVal EndDate As String,
                                       ByVal UserID As String,
                                       ByVal GroupOption As String,
                                       Optional ByVal EmpCode As String = "",
                                       Optional ByVal Office As String = "",
                                       Optional ByVal Client As String = "",
                                       Optional ByVal Division As String = "",
                                       Optional ByVal Product As String = "",
                                       Optional ByVal Job As String = "",
                                       Optional ByVal JobComp As String = "",
                                       Optional ByVal ROLES As String = "",
                                       Optional ByVal CellLength As Integer = 50,
                                       Optional ByVal TaskStatus As String = "",
                                       Optional ByVal ExcludeTempComplete As Boolean = False,
                                       Optional ByVal TaskDuration As Boolean = False,
                                       Optional ByVal tClientCode As Boolean = True,
                                       Optional ByVal tClientDesc As Boolean = False,
                                       Optional ByVal tDivisionCode As Boolean = False,
                                       Optional ByVal tDivisionDesc As Boolean = False,
                                       Optional ByVal tProductCode As Boolean = False,
                                       Optional ByVal tProductDesc As Boolean = False,
                                       Optional ByVal tJobNumber As Boolean = False,
                                       Optional ByVal tJobDesc As Boolean = False,
                                       Optional ByVal tCompNumber As Boolean = False,
                                       Optional ByVal tCompDesc As Boolean = False,
                                       Optional ByVal tTaskCode As Boolean = False,
                                       Optional ByVal tTaskDesc As Boolean = False,
                                       Optional ByVal haEmployeeCode As Boolean = False,
                                       Optional ByVal haEmployeeName As Boolean = False,
                                       Optional ByVal haType As Boolean = False,
                                       Optional ByVal haSubject As Boolean = False,
                                       Optional ByVal haTimes As Boolean = False,
                                       Optional ByVal haHours As Boolean = False,
                                       Optional ByVal haTimeCat As Boolean = False,
                                       Optional ByVal showTasks As Boolean = True,
                                       Optional ByVal showHolidays As Boolean = True,
                                       Optional ByVal showAppointments As Boolean = True,
                                       Optional ByVal tcal_milestone As Boolean = False,
                                       Optional ByVal tcal_empcodedispl As Boolean = False,
                                       Optional ByVal tcal_empdescdispl As Boolean = False,
                                       Optional ByVal tcal_manager As String = "",
                                       Optional ByVal showEvents As Boolean = False,
                                       Optional ByVal showEventTasks As Boolean = False,
                                       Optional ByVal DEPTS As String = "",
                                       Optional ByVal fromapp As String = "") As DataTable

            'This function will create a calendar report for multiple months with a Cl/Div/Prd/Job/Comp/Month grouping
            'Depending on the GroupOption - jtg
            Dim intDaysInMonth As Integer
            Dim ThisMonth As Month
            Dim ThisWeek As Week
            Dim ThisDay As Date
            Dim ThisDayLink As String
            Dim dr As SqlClient.SqlDataReader
            Dim dr2 As SqlClient.SqlDataReader
            Dim drEvents As SqlClient.SqlDataReader
            Dim drEventTasks As SqlClient.SqlDataReader
            Dim I As Integer
            Dim tempDate, tempDateEnd As Date
            Dim arIDX As Integer = 0
            Dim TaskDateIDX As Integer = 0
            Dim SORT As Integer

            Dim strShow As String
            Dim strTask As String
            Dim arParams(20) As SqlParameter
            Dim arParamsNonTask(15) As SqlParameter
            Dim arEventParams(9) As SqlParameter
            'Dim arEventTaskParams(1) As SqlParameter

            Dim strCompleted As String
            Dim taskLink As String
            Dim day As Integer
            Dim maxDate As Date = CType(EndDate, Date)

            Dim months_ct, month_idx As Int16
            Dim SDate, EDate, currentDate As Date
            Dim currentMonth, currentYear, rowCount As Integer
            Dim cdpjcIDX As Integer = 0
            Dim IDX_CDPJC As Int16
            Dim IDX_Month As Int16
            Dim incr_idx As Boolean = False
            Dim dayIdx, days As Integer

            Dim _cl, _div, _prd As String
            Dim prevcl, prevdiv, prevprd As String
            Dim _job, prevjob, _month, prevmonth As Integer
            Dim _comp, prevcomp As Int16

            Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
            parameterUserID.Value = UserID
            arParams(0) = parameterUserID

            Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
            parameterEmpCode.Value = EmpCode
            arParams(1) = parameterEmpCode

            Dim parameterOffice As New SqlParameter("@OfficeCode", SqlDbType.VarChar, 6)
            parameterOffice.Value = Office
            arParams(2) = parameterOffice

            Dim parameterClient As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
            parameterClient.Value = Client
            arParams(3) = parameterClient

            Dim parameterDivision As New SqlParameter("@DivCode", SqlDbType.VarChar, 6)
            parameterDivision.Value = Division
            arParams(4) = parameterDivision

            Dim parameterProduct As New SqlParameter("@ProdCode", SqlDbType.VarChar, 6)
            parameterProduct.Value = Product
            arParams(5) = parameterProduct

            Dim parameterJob As New SqlParameter("@JobNumber", SqlDbType.VarChar, 6)
            parameterJob.Value = Job
            arParams(6) = parameterJob

            Dim parameterJobComp As New SqlParameter("@JobComp", SqlDbType.VarChar, 6)
            parameterJobComp.Value = JobComp
            arParams(7) = parameterJobComp

            Dim parameterRole As New SqlParameter("@ROLES", SqlDbType.VarChar, 8000)
            ' ROLES already comes in format 'role1','role2', plus algorithm does not work -jtg
            '***********************************************************************************
            'Dim sr As String = ""
            'Try
            '    If ROLES.Trim() <> "" Then
            '        sr = ROLES.Trim.Replace("'", "")
            '        If sr.IndexOf(",") > -1 Then
            '            ROLES = ""
            '            Dim ar() As String
            '            ar = sr.Split(",")
            '            For x As Integer = 0 To sr.Length - 1
            '                ROLES &= ROLES & "'" & ar(x) & "',"
            '            Next
            '            ROLES = Me.RemoveTrailingDelimiter(ROLES, ",")
            '        Else
            '            ROLES = "'" & sr & "'"
            '        End If
            '    End If
            'Catch ex As Exception
            '    ROLES = ""
            'End Try
            parameterRole.Value = ROLES
            arParams(8) = parameterRole

            Dim parameterStartDate As New SqlParameter("@StartDate", SqlDbType.VarChar, 10)
            parameterStartDate.Value = StartDate
            arParams(9) = parameterStartDate

            Dim parameterEndDate As New SqlParameter("@EndDate", SqlDbType.VarChar, 10)
            parameterEndDate.Value = EndDate
            arParams(10) = parameterEndDate

            Dim parameterTaskStatus As New SqlParameter("@TaskStatus", SqlDbType.VarChar, 1)
            parameterTaskStatus.Value = TaskStatus
            arParams(11) = parameterTaskStatus

            Dim parameterExcludeTempComplete As New SqlParameter("@ExcludeTempComplete", SqlDbType.Char, 1)
            If ExcludeTempComplete = True Then
                parameterExcludeTempComplete.Value = "Y"
            Else
                parameterExcludeTempComplete.Value = "N"
            End If
            arParams(12) = parameterExcludeTempComplete

            Dim parameterMilestone As New SqlParameter("@MilestonesOnly", SqlDbType.VarChar, 1)
            parameterMilestone.Value = BoolToYN(tcal_milestone)
            arParams(13) = parameterMilestone

            Dim parameterManager As New SqlParameter("@Manager", SqlDbType.VarChar, 6)
            parameterManager.Value = tcal_manager
            arParams(14) = parameterManager

            Dim parameterGroupLevel As New SqlParameter("@GrpLevel", SqlDbType.VarChar, 1)
            parameterGroupLevel.Value = GroupOption
            arParams(15) = parameterGroupLevel

            Dim parameterShowTasks As New SqlParameter("@showTasks", SqlDbType.VarChar, 1)
            If showTasks = True Then
                parameterShowTasks.Value = "1"
            Else
                parameterShowTasks.Value = "0"
            End If
            arParams(16) = parameterShowTasks

            Dim parameterShowEvents As New SqlParameter("@showEvents", SqlDbType.VarChar, 1)
            If showEvents = True Then
                parameterShowEvents.Value = "1"
            Else
                parameterShowEvents.Value = "0"
            End If
            arParams(17) = parameterShowEvents

            Dim parameterShowEventTasks As New SqlParameter("@showEventTasks", SqlDbType.VarChar, 1)
            If showEventTasks = True Then
                parameterShowEventTasks.Value = "1"
            Else
                parameterShowEventTasks.Value = "0"
            End If
            arParams(18) = parameterShowEventTasks

            Dim parameterLevel As New SqlParameter("@Level", SqlDbType.VarChar, 1)
            parameterLevel.Value = ""

            Dim parameterGrouping As New SqlParameter("@Grouping", SqlDbType.VarChar, 10)
            parameterGrouping.Value = ""

            Dim parameterFromApp As New SqlParameter("@FromApp", SqlDbType.VarChar, 10)
            parameterFromApp.Value = fromapp


            Dim parameterType As New SqlParameter("@Type", SqlDbType.Char, 2)
            If showHolidays = True And showAppointments = True Then
                parameterType.Value = ""
            ElseIf showHolidays = True And showAppointments = False Then
                parameterType.Value = "H"
            ElseIf showHolidays = False And showAppointments = True Then
                parameterType.Value = "A"
            Else
                parameterType.Value = "N"
            End If

            arParamsNonTask(0) = parameterStartDate
            arParamsNonTask(1) = parameterEndDate
            If EmpCode = "" Then
                arParamsNonTask(2) = parameterEmpCode
            Else
                arParamsNonTask(2) = parameterEmpCode
            End If
            arParamsNonTask(3) = parameterType
            arParamsNonTask(4) = parameterUserID
            arParamsNonTask(5) = parameterRole

            Dim parameterDEPTS As New SqlParameter("@DEPTS", SqlDbType.VarChar, 8000)
            ' DEPTS already comes in format 'role1','role2', plus algorithm does not work -jtg
            '***********************************************************************************
            'Try
            '    Dim sd As String = ""
            '    If DEPTS.Trim() <> "" Then
            '        sd = DEPTS.Trim.Replace("'", "")
            '        If sd.IndexOf(",") > -1 Then
            '            DEPTS = ""
            '            Dim ar() As String
            '            ar = sd.Split(",")
            '            For x As Integer = 0 To sd.Length - 1
            '                DEPTS &= DEPTS & "'" & ar(x) & "',"
            '            Next
            '            DEPTS = Me.RemoveTrailingDelimiter(DEPTS, ",")
            '        Else
            '            DEPTS = "'" & sd & "'"
            '        End If
            '    End If
            'Catch ex As Exception
            '    DEPTS = ""
            'End Try
            parameterDEPTS.Value = DEPTS
            arParamsNonTask(6) = parameterDEPTS
            arParamsNonTask(7) = parameterClient
            arParamsNonTask(8) = parameterDivision
            arParamsNonTask(9) = parameterProduct
            arParamsNonTask(10) = parameterJob
            arParamsNonTask(11) = parameterJobComp
            arParamsNonTask(12) = parameterLevel
            arParamsNonTask(13) = parameterGrouping
            arParamsNonTask(14) = parameterFromApp
            arParams(19) = parameterDEPTS

            Try
                dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_calendar_task_month_rpt2", arParams)
            Catch
                Err.Raise(Err.Number, "Class:cTaskCal Routine:GetTaskCalendarReportCDPJCGroup", Err.Description)
            End Try


            'Calculate the number of "Month" pages that will be needed
            prevcl = ""
            prevdiv = ""
            prevprd = ""
            prevjob = 0
            prevcomp = 0
            prevmonth = 0

            cdpjcCount = 0
            Do While dr.Read
                _cl = dr.GetString(0)
                _div = dr.GetString(1)
                _prd = dr.GetString(2)
                _job = dr.GetInt32(3)
                _comp = dr.GetInt16(5)
                tempDate = dr.GetDateTime(17) 'revisedDate
                _month = tempDate.Month

                Select Case GroupOption 'will either be 1,2,3,4,5 

                    Case 1
                        If _cl <> prevcl Then
                            cdpjcCount = cdpjcCount + 1
                            prevcl = _cl
                        End If
                    Case 2
                        If _cl <> prevcl Or _div <> prevdiv Then
                            cdpjcCount = cdpjcCount + 1
                            prevcl = _cl
                            prevdiv = _div
                        End If
                    Case 3
                        If _cl <> prevcl Or _div <> prevdiv Or _prd <> prevprd Then
                            cdpjcCount = cdpjcCount + 1
                            prevcl = _cl
                            prevdiv = _div
                            prevprd = _prd
                        End If
                    Case 4
                        If _cl <> prevcl Or _div <> prevdiv Or _prd <> prevprd Or _job <> prevjob Then
                            cdpjcCount = cdpjcCount + 1
                            prevcl = _cl
                            prevdiv = _div
                            prevprd = _prd
                            prevjob = _job
                        End If
                    Case 5
                        If _cl <> prevcl Or _div <> prevdiv Or _prd <> prevprd Or _job <> prevjob Or _comp <> prevcomp Then
                            cdpjcCount = cdpjcCount + 1
                            prevcl = _cl
                            prevdiv = _div
                            prevprd = _prd
                            prevjob = _job
                            prevcomp = _comp
                        End If
                End Select
            Loop
            dr.Close()

            'Init the _CDPJCTaskDates array structure
            SDate = CType(StartDate, Date)
            EDate = CType(EndDate, Date)
            months_ct = DateDiff(DateInterval.Month, SDate, EDate)

            If cdpjcCount = 0 Then
                cdpjcCount = 1  'May not have records
            End If

            For cdpjcIDX = 0 To cdpjcCount - 1
                _CDPJCTaskDates(cdpjcIDX) = New CDPJCTaskDates

                _CDPJCTaskDates(cdpjcIDX).clCode = ""
                _CDPJCTaskDates(cdpjcIDX).divCode = ""
                _CDPJCTaskDates(cdpjcIDX).prdCode = ""
                _CDPJCTaskDates(cdpjcIDX).jobCode = 0
                _CDPJCTaskDates(cdpjcIDX).compCode = 0
                _CDPJCTaskDates(cdpjcIDX).clDesc = ""
                _CDPJCTaskDates(cdpjcIDX).divDesc = ""
                _CDPJCTaskDates(cdpjcIDX).prdDesc = ""
                _CDPJCTaskDates(cdpjcIDX).jobDesc = ""
                _CDPJCTaskDates(cdpjcIDX).compDesc = ""
                _CDPJCTaskDates(cdpjcIDX).trfDesc = ""
                _CDPJCTaskDates(cdpjcIDX).grouping = ""

                currentDate = SDate
                For month_idx = 0 To months_ct
                    If month_idx > 0 Then
                        currentDate = DateAdd(DateInterval.Month, 1, currentDate)
                    End If
                    currentMonth = currentDate.Month
                    currentYear = currentDate.Year

                    _CDPJCTaskDates(cdpjcIDX).TaskDates(month_idx) = New TaskDate
                    _CDPJCTaskDates(cdpjcIDX).TaskDates(month_idx)._month._month = currentMonth
                    _CDPJCTaskDates(cdpjcIDX).TaskDates(month_idx)._year = currentYear
                    _CDPJCTaskDates(cdpjcIDX).TaskDates(month_idx).initMonth()
                Next
            Next


            Try
                dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_calendar_task_month_rpt2", arParams)
            Catch
                Err.Raise(Err.Number, "Class:cTaskCal Routine:GetTaskCalendarReportCDPJCGroup", Err.Description)
            End Try

            prevcl = ""
            prevdiv = ""
            prevprd = ""
            prevjob = 0
            prevcomp = 0
            prevmonth = 0

            IDX_CDPJC = -1
            Do While dr.Read
                strShow = ""
                incr_idx = False
                _cl = dr.GetString(0)
                _div = dr.GetString(1)
                _prd = dr.GetString(2)
                _job = CStr(dr.GetInt32(3))
                _comp = CStr(dr.GetInt16(5))
                tempDate = dr.GetDateTime(17)
                _month = tempDate.Month
                SORT = dr.GetInt32(23)

                Select Case GroupOption 'will either be 1,2,3,4,5 

                    Case 1
                        If _cl <> prevcl Then
                            IDX_CDPJC = IDX_CDPJC + 1
                            prevcl = _cl
                            incr_idx = True
                        End If
                    Case 2
                        If _cl <> prevcl Or _div <> prevdiv Then
                            IDX_CDPJC = IDX_CDPJC + 1
                            prevcl = _cl
                            prevdiv = _div
                            incr_idx = True
                        End If
                    Case 3
                        If _cl <> prevcl Or _div <> prevdiv Or _prd <> prevprd Then
                            IDX_CDPJC = IDX_CDPJC + 1
                            prevcl = _cl
                            prevdiv = _div
                            prevprd = _prd
                            incr_idx = True
                        End If
                    Case 4
                        If _cl <> prevcl Or _div <> prevdiv Or _prd <> prevprd Or _job <> prevjob Then
                            IDX_CDPJC = IDX_CDPJC + 1
                            prevcl = _cl
                            prevdiv = _div
                            prevprd = _prd
                            prevjob = _job
                            incr_idx = True
                        End If
                    Case 5
                        If _cl <> prevcl Or _div <> prevdiv Or _prd <> prevprd Or _job <> prevjob Or _comp <> prevcomp Then
                            IDX_CDPJC = IDX_CDPJC + 1
                            prevcl = _cl
                            prevdiv = _div
                            prevprd = _prd
                            prevjob = _job
                            prevcomp = _comp
                            incr_idx = True
                        End If
                End Select

                Select Case SORT
                    Case 1  'Tasks
                        If tClientCode = True Then
                            strShow = strShow & dr.GetString(0) & "|"
                        End If

                        If tClientDesc = True Then
                            strShow = strShow & dr.GetString(13) & "|"
                        End If
                        If tDivisionCode = True Then
                            strShow = strShow & dr.GetString(1) & "|"
                        End If

                        If tDivisionDesc = True Then
                            strShow = strShow & dr.GetString(14) & "|"
                        End If
                        If tProductCode = True Then
                            strShow = strShow & dr.GetString(2) & "|"
                        End If

                        If tProductDesc = True Then
                            strShow = strShow & dr.GetString(15) & "|"
                        End If
                        If tJobNumber = True Then
                            strShow = strShow & dr.GetInt32(3) & "|"
                        End If

                        If tJobDesc = True Then
                            strShow = strShow & dr.GetString(4) & "|"
                        End If
                        If tCompNumber = True Then
                            strShow = strShow & dr.GetInt16(5) & "|"
                        End If

                        If tCompDesc = True Then
                            strShow = strShow & dr.GetString(6) & "|"
                        End If
                        If tTaskCode = True Then
                            strShow = strShow & dr.GetString(16) & "|"
                        End If
                        If tTaskDesc = True Then
                            strShow = strShow & dr.GetString(8) & "|"
                        End If
                        If tcal_empcodedispl = True And dr.GetString(19) <> "" Then
                            strShow = strShow & dr.GetString(19) & "|"
                        End If
                        If tcal_empdescdispl = True Then
                            strShow = strShow & dr.GetString(20)
                        End If
                        If strShow.EndsWith("|") Then
                            strShow = strShow.Substring(0, strShow.Length - 1)
                        End If

                    Case 2  'Event
                        strShow = strShow & dr.GetString(0) & "|"
                        strShow = strShow & dr.GetString(16) & "|"
                        strShow = strShow & dr.GetDateTime(17).ToShortTimeString & "|"
                        strShow = strShow & dr.GetDateTime(18).ToShortTimeString

                    Case 3  'Event Task
                        strShow = strShow & dr.GetString(8) & "|"
                        strShow = strShow & dr.GetString(16) & "|"
                        strShow = strShow & dr.GetDateTime(17).ToShortTimeString & "|"
                        strShow = strShow & dr.GetDateTime(18).ToShortTimeString

                End Select


                day = CInt(dr.GetInt32(7))
                tempDate = dr.GetDateTime(17)
                IDX_Month = CDPJCMonthIDX(IDX_CDPJC, tempDate.Month, tempDate.Year)
                _CDPJCTaskDates(IDX_CDPJC).TaskDates(IDX_Month)._month._dayTasks(day) = _CDPJCTaskDates(IDX_CDPJC).TaskDates(IDX_Month)._month._dayTasks(day) & strShow & vbCrLf & vbCrLf
                _CDPJCTaskDates(IDX_CDPJC).clCode = _cl
                _CDPJCTaskDates(IDX_CDPJC).clDesc = dr.GetString(13)
                _CDPJCTaskDates(IDX_CDPJC).divCode = _div
                _CDPJCTaskDates(IDX_CDPJC).divDesc = dr.GetString(14)
                _CDPJCTaskDates(IDX_CDPJC).prdCode = _prd
                _CDPJCTaskDates(IDX_CDPJC).prdDesc = dr.GetString(15)
                _CDPJCTaskDates(IDX_CDPJC).jobCode = _job
                _CDPJCTaskDates(IDX_CDPJC).jobDesc = dr.GetString(4)
                _CDPJCTaskDates(IDX_CDPJC).compCode = _comp
                _CDPJCTaskDates(IDX_CDPJC).compDesc = dr.GetString(6)
                _CDPJCTaskDates(IDX_CDPJC).trfDesc = dr.GetString(21)
                _CDPJCTaskDates(IDX_CDPJC).grouping = dr.GetString(22)

                strShow = ""

                'Holiday/Appointment 
                Dim oCalendar As TaskCalendar.cCalendar = New TaskCalendar.cCalendar(mConnString)
                Dim ds As DataSet
                Dim strEmps As String

                If showAppointments = True Or showHolidays = True Then
                    If incr_idx = True Then

                        Try
                            dr2 = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_nontask_GetTasks", arParamsNonTask)
                        Catch
                            Err.Raise(Err.Number, "Class:cTaskCal Routine:GetTaskCalendarReportCDPJCGroup", Err.Description)
                        End Try

                        strTask = ""
                        Do While dr2.Read
                            strEmps = ""
                            day = CInt(dr2.GetString(7))
                            ds = oCalendar.GetNonTaskDataDS(dr2("NON_TASK_ID"), UserID)
                            If haEmployeeCode = True And (dr2.GetString(1) = "A" Or dr2.GetString(1) = "C" Or dr2.GetString(1) = "M" Or dr2.GetString(1) = "TD" Or dr2.GetString(1) = "EL") Then
                                If ds.Tables(1).Rows.Count > 0 Then
                                    For w As Integer = 0 To ds.Tables(1).Rows.Count - 1
                                        strEmps += (ds.Tables(1).Rows(w)("EMP_CODE").ToString) & ","
                                    Next
                                End If
                                If strEmps <> "" Then
                                    strTask = strTask & strEmps.Substring(0, strEmps.Length - 1) & "|"
                                End If
                            End If
                            If haEmployeeName = True And (dr2.GetString(1) = "A" Or dr2.GetString(1) = "C" Or dr2.GetString(1) = "M" Or dr2.GetString(1) = "TD" Or dr2.GetString(1) = "EL") Then
                                If ds.Tables(1).Rows.Count > 0 Then
                                    For x As Integer = 0 To ds.Tables(1).Rows.Count - 1
                                        strEmps += (ds.Tables(1).Rows(x)("EMP_NAME").ToString) & ","
                                    Next
                                End If
                                If strEmps <> "" Then
                                    strTask = strTask & strEmps.Substring(0, strEmps.Length - 1) & "|"
                                End If
                            End If
                            If haType = True Then
                                strTask = strTask & dr2.GetString(1) & "|"
                            End If
                            If haSubject = True Then
                                strTask = strTask & dr2.GetString(2) & "|"
                            End If
                            If haTimes = True And (dr2.GetString(1) = "A" Or dr2.GetString(1) = "C" Or dr2.GetString(1) = "M" Or dr2.GetString(1) = "TD" Or dr2.GetString(1) = "EL") And dr2.GetInt32(9) = 0 Then
                                strTask = strTask & dr2.GetDateTime(3).ToShortTimeString & " - " & dr2.GetDateTime(4).ToShortTimeString & "|"
                            End If
                            If haHours = True And (dr2.GetString(1) = "A" Or dr2.GetString(1) = "C" Or dr2.GetString(1) = "M" Or dr2.GetString(1) = "TD" Or dr2.GetString(1) = "EL") Then
                                strTask = strTask & dr2.GetDecimal(5) & "|"
                            End If
                            If haTimeCat = True Then
                                strTask = strTask & dr2.GetString(6)
                            End If

                            If strTask.EndsWith("|") Then
                                strTask = strTask.Substring(0, strTask.Length - 1)
                            End If

                            tempDate = dr2.GetDateTime(10)

                            'Calculate and display range
                            'Don't let date range go past report endDate
                            tempDateEnd = CType(dr2.GetDateTime(11), Date)
                            If tempDateEnd > maxDate Then
                                tempDateEnd = maxDate
                            End If

                            days = DateDiff(DateInterval.Day, tempDate, tempDateEnd)

                            For dayIdx = 0 To days
                                IDX_Month = CDPJCMonthIDX(IDX_CDPJC, tempDate.Month, tempDate.Year)
                                _CDPJCTaskDates(IDX_CDPJC).TaskDates(IDX_Month)._month._dayTasks(day) = _CDPJCTaskDates(IDX_CDPJC).TaskDates(IDX_Month)._month._dayTasks(day) & strTask & vbCrLf & vbCrLf

                                tempDate = DateAdd(DateInterval.Day, 1, tempDate)
                                day = tempDate.Day
                            Next

                            strTask = ""
                        Loop
                        incr_idx = False
                    End If
                End If
            Loop

            Dim dt As DataTable
            Dim row As DataRow
            dt = New DataTable("taskMonth")
            Dim sunday As DataColumn = New DataColumn("Sunday")
            Dim monday As DataColumn = New DataColumn("Monday")
            Dim tuesday As DataColumn = New DataColumn("Tuesday")
            Dim wednesday As DataColumn = New DataColumn("Wednesday")
            Dim thursday As DataColumn = New DataColumn("Thursday")
            Dim friday As DataColumn = New DataColumn("Friday")
            Dim saturday As DataColumn = New DataColumn("Saturday")
            Dim dtlmonth As DataColumn = New DataColumn("dtlmonth")
            Dim dtlyear As DataColumn = New DataColumn("dtlyear")
            Dim dtlclient As DataColumn = New DataColumn("dtlclient")
            Dim dtlclientdesc As DataColumn = New DataColumn("dtlclientdesc")
            Dim dtldiv As DataColumn = New DataColumn("dtldiv")
            Dim dtldivdesc As DataColumn = New DataColumn("dtldivdesc")
            Dim dtlprd As DataColumn = New DataColumn("dtlprd")
            Dim dtlprddesc As DataColumn = New DataColumn("dtlprddesc")
            Dim dtljob As DataColumn = New DataColumn("dtljob")
            Dim dtljobdesc As DataColumn = New DataColumn("dtljobdesc")
            Dim dtlcomp As DataColumn = New DataColumn("dtlcomp")
            Dim dtlcompdesc As DataColumn = New DataColumn("dtlcompdesc")
            Dim dtltrfdesc As DataColumn = New DataColumn("dtltrfdesc")
            Dim grouping As DataColumn = New DataColumn("grouping")
            Dim month1, month2 As Integer

            dt.Columns.Add(sunday)
            dt.Columns.Add(monday)
            dt.Columns.Add(tuesday)
            dt.Columns.Add(wednesday)
            dt.Columns.Add(thursday)
            dt.Columns.Add(friday)
            dt.Columns.Add(saturday)
            dt.Columns.Add(dtlmonth)
            dt.Columns.Add(dtlyear)
            dt.Columns.Add(dtlclient)
            dt.Columns.Add(dtlclientdesc)
            dt.Columns.Add(dtldiv)
            dt.Columns.Add(dtldivdesc)
            dt.Columns.Add(dtlprd)
            dt.Columns.Add(dtlprddesc)
            dt.Columns.Add(dtljob)
            dt.Columns.Add(dtljobdesc)
            dt.Columns.Add(dtlcomp)
            dt.Columns.Add(dtlcompdesc)
            dt.Columns.Add(dtltrfdesc)
            dt.Columns.Add(grouping)
            row = dt.NewRow

            SDate = CType(StartDate, Date)
            EDate = CType(EndDate, Date)
            months_ct = DateDiff(DateInterval.Month, SDate, EDate)

            currentDate = SDate
            arIDX = 0

            Dim monthEmpty As Boolean
            Dim ls_str As String

            For cdpjcIDX = 0 To cdpjcCount - 1

                For month_idx = 0 To months_ct
                    currentMonth = _CDPJCTaskDates(cdpjcIDX).TaskDates(month_idx)._month._month
                    currentYear = _CDPJCTaskDates(cdpjcIDX).TaskDates(month_idx)._year

                    monthEmpty = True
                    For day = 1 To _CDPJCTaskDates(cdpjcIDX).TaskDates(month_idx).dayCt
                        If _CDPJCTaskDates(cdpjcIDX).TaskDates(month_idx)._month._dayTasks(day).Length > 0 Then
                            monthEmpty = False
                            Exit For
                        End If
                    Next

                    If monthEmpty = False Then
                        For day = 1 To _CDPJCTaskDates(cdpjcIDX).TaskDates(month_idx).dayCt

                            row.Item("dtlmonth") = currentMonth
                            row.Item("dtlyear") = currentYear

                            row.Item("dtlclient") = _CDPJCTaskDates(cdpjcIDX).clCode
                            row.Item("dtlclientdesc") = _CDPJCTaskDates(cdpjcIDX).clDesc
                            row.Item("dtldiv") = _CDPJCTaskDates(cdpjcIDX).divCode
                            row.Item("dtldivdesc") = _CDPJCTaskDates(cdpjcIDX).divDesc
                            row.Item("dtlprd") = _CDPJCTaskDates(cdpjcIDX).prdCode
                            row.Item("dtlprddesc") = _CDPJCTaskDates(cdpjcIDX).prdDesc
                            row.Item("dtljob") = _CDPJCTaskDates(cdpjcIDX).jobCode
                            row.Item("dtljobdesc") = _CDPJCTaskDates(cdpjcIDX).jobDesc
                            row.Item("dtlcomp") = _CDPJCTaskDates(cdpjcIDX).compCode
                            row.Item("dtlcompdesc") = _CDPJCTaskDates(cdpjcIDX).compDesc
                            row.Item("dtltrfdesc") = _CDPJCTaskDates(cdpjcIDX).trfDesc
                            row.Item("grouping") = _CDPJCTaskDates(cdpjcIDX).grouping & CStr(_CDPJCTaskDates(cdpjcIDX).TaskDates(month_idx)._month._month)

                            ThisDay = CDate(currentMonth & "/" & CStr(day) & "/" & currentYear)

                            Select Case ThisDay.DayOfWeek
                                Case DayOfWeek.Sunday
                                    If _CDPJCTaskDates(cdpjcIDX).TaskDates(month_idx)._month._dayTasks(day).Length > 0 Then
                                        row.Item("Sunday") = day & vbCrLf & _CDPJCTaskDates(cdpjcIDX).TaskDates(month_idx)._month._dayTasks(day)
                                    Else
                                        row.Item("Sunday") = day
                                    End If
                                Case DayOfWeek.Monday
                                    If _CDPJCTaskDates(cdpjcIDX).TaskDates(month_idx)._month._dayTasks(day).Length > 0 Then
                                        row.Item("Monday") = day & vbCrLf & _CDPJCTaskDates(cdpjcIDX).TaskDates(month_idx)._month._dayTasks(day)
                                    Else
                                        row.Item("Monday") = day
                                    End If
                                Case DayOfWeek.Tuesday
                                    If _CDPJCTaskDates(cdpjcIDX).TaskDates(month_idx)._month._dayTasks(day).Length > 0 Then
                                        row.Item("Tuesday") = day & vbCrLf & _CDPJCTaskDates(cdpjcIDX).TaskDates(month_idx)._month._dayTasks(day)
                                    Else
                                        row.Item("Tuesday") = day
                                    End If
                                Case DayOfWeek.Wednesday
                                    If _CDPJCTaskDates(cdpjcIDX).TaskDates(month_idx)._month._dayTasks(day).Length > 0 Then
                                        row.Item("Wednesday") = day & vbCrLf & _CDPJCTaskDates(cdpjcIDX).TaskDates(month_idx)._month._dayTasks(day)
                                    Else
                                        row.Item("Wednesday") = day
                                    End If
                                Case DayOfWeek.Thursday
                                    If _CDPJCTaskDates(cdpjcIDX).TaskDates(month_idx)._month._dayTasks(day).Length > 0 Then
                                        row.Item("Thursday") = day & vbCrLf & _CDPJCTaskDates(cdpjcIDX).TaskDates(month_idx)._month._dayTasks(day)
                                    Else
                                        row.Item("Thursday") = day
                                    End If
                                Case DayOfWeek.Friday
                                    If _CDPJCTaskDates(cdpjcIDX).TaskDates(month_idx)._month._dayTasks(day).Length > 0 Then
                                        row.Item("Friday") = day & vbCrLf & _CDPJCTaskDates(cdpjcIDX).TaskDates(month_idx)._month._dayTasks(day)
                                    Else
                                        row.Item("Friday") = day
                                    End If
                                Case DayOfWeek.Saturday
                                    If _CDPJCTaskDates(cdpjcIDX).TaskDates(month_idx)._month._dayTasks(day).Length > 0 Then
                                        row.Item("Saturday") = day & vbCrLf & _CDPJCTaskDates(cdpjcIDX).TaskDates(month_idx)._month._dayTasks(day)
                                    Else
                                        row.Item("Saturday") = day
                                    End If
                            End Select

                            If ThisDay.DayOfWeek = DayOfWeek.Saturday Or ThisDay.Day = _CDPJCTaskDates(cdpjcIDX).TaskDates(month_idx).dayCt Then
                                dt.Rows.Add(row)
                                row = dt.NewRow
                            End If
                        Next
                    End If
                Next
            Next

            dr.Close()

            Return dt

        End Function

        Public Function GetTaskCalendarReport(ByVal StartDate As DateTime,
                                       ByVal EndDate As DateTime,
                                       ByVal UserID As String,
                                       ByVal GroupOption As String,
                                       Optional ByVal EmpCode As String = "",
                                       Optional ByVal Office As String = "",
                                       Optional ByVal Client As String = "",
                                       Optional ByVal Division As String = "",
                                       Optional ByVal Product As String = "",
                                       Optional ByVal Job As String = "",
                                       Optional ByVal JobComp As String = "",
                                       Optional ByVal ROLES As String = "",
                                       Optional ByVal CellLength As Integer = 50,
                                       Optional ByVal TaskStatus As String = "",
                                       Optional ByVal ExcludeTempComplete As Boolean = False,
                                       Optional ByVal TaskDuration As Boolean = False,
                                       Optional ByVal tClientCode As Boolean = True,
                                       Optional ByVal tClientDesc As Boolean = False,
                                       Optional ByVal tDivisionCode As Boolean = False,
                                       Optional ByVal tDivisionDesc As Boolean = False,
                                       Optional ByVal tProductCode As Boolean = False,
                                       Optional ByVal tProductDesc As Boolean = False,
                                       Optional ByVal tJobNumber As Boolean = False,
                                       Optional ByVal tJobDesc As Boolean = False,
                                       Optional ByVal tCompNumber As Boolean = False,
                                       Optional ByVal tCompDesc As Boolean = False,
                                       Optional ByVal tTaskCode As Boolean = False,
                                       Optional ByVal tTaskDesc As Boolean = False,
                                       Optional ByVal haEmployeeCode As Boolean = False,
                                       Optional ByVal haEmployeeName As Boolean = False,
                                       Optional ByVal haType As Boolean = False,
                                       Optional ByVal haSubject As Boolean = False,
                                       Optional ByVal haTimes As Boolean = False,
                                       Optional ByVal haHours As Boolean = False,
                                       Optional ByVal haTimeCat As Boolean = False,
                                       Optional ByVal showTasks As Boolean = True,
                                       Optional ByVal showHolidays As Boolean = True,
                                       Optional ByVal showAppointments As Boolean = True,
                                       Optional ByVal tcal_milestone As Boolean = False,
                                       Optional ByVal tcal_empcodedispl As Boolean = False,
                                       Optional ByVal tcal_empdescdispl As Boolean = False,
                                       Optional ByVal tcal_manager As String = "",
                                       Optional ByVal showEvents As Boolean = False,
                                       Optional ByVal showEventTasks As Boolean = False,
                                       Optional ByVal DEPTS As String = "",
                                       Optional ByVal fromapp As String = "",
                                       Optional ByVal jobcomps As String = "") As DataTable

            'This function will create a calendar report for multiple months with a Month/Year grouping
            Dim intDaysInMonth As Integer
            Dim ThisMonth As Month
            Dim ThisWeek As Week
            Dim ThisDay As Date
            Dim ThisDayLink As String
            Dim dt3 As DataTable
            Dim dr As SqlClient.SqlDataReader
            Dim dr2 As SqlClient.SqlDataReader
            Dim drEvents As SqlClient.SqlDataReader
            Dim drEventTasks As SqlClient.SqlDataReader
            Dim I As Integer
            Dim arTasks(365) As String
            Dim arMonths(365) As Integer
            Dim arYears(365) As Integer
            Dim tempDate As Date
            Dim ls_str As String
            Dim arclientCode(1000) As String
            Dim arclientDesc(1000) As String
            Dim ardivCode(1000) As String
            Dim ardivDesc(1000) As String
            Dim arprdCode(1000) As String
            Dim arprdDesc(1000) As String
            Dim arjobCode(1000) As String
            Dim arjobDesc(1000) As String
            Dim arcompCode(1000) As String
            Dim arcompDesc(1000) As String
            Dim arTrfDesc(1000) As String
            Dim arIDX As Integer = 0
            Dim TaskDateIDX As Integer = 0

            Dim strShow As String
            Dim strTask As String
            Dim arParams(17) As SqlParameter
            Dim arParamsNonTask(15) As SqlParameter
            Dim arEventParams(9) As SqlParameter
            'Dim arEventTaskParams(1) As SqlParameter
            Dim strCompleted As String
            Dim taskLink As String
            Dim day As Integer

            Dim months_ct, month_idx As Int16
            Dim SDate, EDate, currentDate As Date
            Dim currentMonth, currentYear As Integer

            Dim maxDate As Date = CType(EndDate, Date)
            Dim tempDateEnd As Date
            Dim dayIdx, days As Integer

            Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
            parameterUserID.Value = UserID
            arParams(0) = parameterUserID

            Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
            parameterEmpCode.Value = EmpCode
            arParams(1) = parameterEmpCode

            Dim parameterOffice As New SqlParameter("@OfficeCode", SqlDbType.VarChar, 6)
            parameterOffice.Value = Office
            arParams(2) = parameterOffice

            Dim parameterClient As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
            parameterClient.Value = Client
            arParams(3) = parameterClient

            Dim parameterDivision As New SqlParameter("@DivCode", SqlDbType.VarChar, 6)
            parameterDivision.Value = Division
            arParams(4) = parameterDivision

            Dim parameterProduct As New SqlParameter("@ProdCode", SqlDbType.VarChar, 6)
            parameterProduct.Value = Product
            arParams(5) = parameterProduct

            Dim parameterJob As New SqlParameter("@JobNumber", SqlDbType.VarChar, 6)
            parameterJob.Value = Job
            arParams(6) = parameterJob

            Dim parameterJobComp As New SqlParameter("@JobComp", SqlDbType.VarChar, 6)
            parameterJobComp.Value = JobComp
            arParams(7) = parameterJobComp

            Dim parameterRoles As New SqlParameter("@ROLES", SqlDbType.VarChar, 8000)
            ' ROLES already comes in format 'role1','role2'
            '**************************************************
            'Dim sr As String = ""
            'Try
            '    If ROLES.Trim() <> "" Then
            '        sr = ROLES.Trim.Replace("'", "")
            '        If sr.IndexOf(",") > -1 Then
            '            ROLES = ""
            '            Dim ar() As String
            '            ar = sr.Split(",")
            '            'For x As Integer = 0 To sr.Length - 1
            '            For x As Integer = 0 To ar.Count - 1
            '                ROLES &= "'" & ar(x) & "',"
            '            Next
            '            ROLES = Me.RemoveTrailingDelimiter(ROLES, ",")
            '        Else
            '            ROLES = "'" & sr & "'"
            '        End If
            '    End If
            'Catch ex As Exception
            '    ROLES = ""
            'End Try
            parameterRoles.Value = ROLES
            arParams(8) = parameterRoles

            Dim parameterStartDate As New SqlParameter("@StartDate", SqlDbType.SmallDateTime)
            parameterStartDate.Value = StartDate
            arParams(9) = parameterStartDate

            Dim parameterEndDate As New SqlParameter("@EndDate", SqlDbType.SmallDateTime)
            parameterEndDate.Value = EndDate
            arParams(10) = parameterEndDate

            Dim parameterTaskStatus As New SqlParameter("@TaskStatus", SqlDbType.VarChar, 1)
            parameterTaskStatus.Value = TaskStatus
            arParams(11) = parameterTaskStatus

            Dim parameterExcludeTempComplete As New SqlParameter("@ExcludeTempComplete", SqlDbType.Char, 1)
            If ExcludeTempComplete = True Then
                parameterExcludeTempComplete.Value = "Y"
            Else
                parameterExcludeTempComplete.Value = "N"
            End If
            arParams(12) = parameterExcludeTempComplete

            Dim parameterMilestone As New SqlParameter("@MilestonesOnly", SqlDbType.VarChar, 1)
            parameterMilestone.Value = BoolToYN(tcal_milestone)
            arParams(13) = parameterMilestone

            Dim parameterManager As New SqlParameter("@Manager", SqlDbType.VarChar, 6)
            parameterManager.Value = tcal_manager
            arParams(14) = parameterManager

            Dim parameterGroupLevel As New SqlParameter("@GrpLevel", SqlDbType.VarChar, 1)
            parameterGroupLevel.Value = GroupOption
            arParams(15) = parameterGroupLevel

            Dim parameterLevel As New SqlParameter("@Level", SqlDbType.VarChar, 1)
            parameterLevel.Value = ""

            Dim parameterGrouping As New SqlParameter("@Grouping", SqlDbType.VarChar, 10)
            parameterGrouping.Value = ""

            Dim parameterFromApp As New SqlParameter("@FromApp", SqlDbType.VarChar, 10)
            parameterFromApp.Value = fromapp


            Dim parameterType As New SqlParameter("@Type", SqlDbType.Char, 2)
            If showHolidays = True And showAppointments = True Then
                parameterType.Value = ""
            ElseIf showHolidays = True And showAppointments = False Then
                parameterType.Value = "H"
            ElseIf showHolidays = False And showAppointments = True Then
                parameterType.Value = "A"
            Else
                parameterType.Value = "N"
            End If

            arParamsNonTask(0) = parameterStartDate
            arParamsNonTask(1) = parameterEndDate
            If EmpCode = "" Then
                arParamsNonTask(2) = parameterEmpCode
            Else
                arParamsNonTask(2) = parameterEmpCode
            End If
            arParamsNonTask(3) = parameterType
            arParamsNonTask(4) = parameterUserID
            arParamsNonTask(5) = parameterRoles

            Dim parameterDEPTS As New SqlParameter("@DEPTS", SqlDbType.VarChar, 8000)
            ' DEPTS already comes in format 'role1','role2', plus algorithm does not work -jtg
            '***********************************************************************************
            'Try
            '    Dim sd As String = ""
            '    If DEPTS.Trim() <> "" Then
            '        sd = DEPTS.Trim.Replace("'", "")
            '        If sd.IndexOf(",") > -1 Then
            '            DEPTS = ""
            '            Dim ar() As String
            '            ar = sd.Split(",")
            '            For x As Integer = 0 To sd.Length - 1
            '                DEPTS &= DEPTS & "'" & ar(x) & "',"
            '            Next
            '            DEPTS = Me.RemoveTrailingDelimiter(DEPTS, ",")
            '        Else
            '            DEPTS = "'" & sd & "'"
            '        End If
            '    End If
            'Catch ex As Exception
            '    DEPTS = ""
            'End Try
            parameterDEPTS.Value = DEPTS
            arParamsNonTask(6) = parameterDEPTS
            arParamsNonTask(7) = parameterClient
            arParamsNonTask(8) = parameterDivision
            arParamsNonTask(9) = parameterProduct
            arParamsNonTask(10) = parameterJob
            arParamsNonTask(11) = parameterJobComp
            arParamsNonTask(12) = parameterLevel
            arParamsNonTask(13) = parameterGrouping
            arParamsNonTask(14) = parameterFromApp
            arParams(16) = parameterDEPTS

            'Event Parms
            arEventParams(0) = parameterUserID
            arEventParams(1) = parameterOffice
            arEventParams(2) = parameterClient
            arEventParams(3) = parameterDivision
            arEventParams(4) = parameterProduct
            arEventParams(5) = parameterJob
            arEventParams(6) = parameterJobComp
            arEventParams(7) = parameterStartDate
            arEventParams(8) = parameterEndDate
            arEventParams(9) = parameterGroupLevel

            'Event Task Parms
            'arEventTaskParams(0) = parameterStartDate
            'arEventTaskParams(1) = parameterEndDate

            Try
                dt3 = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_calendar_task_month_rpt", "dt", arParams)
                dr2 = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_nontask_GetTasks", arParamsNonTask)
                drEvents = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_calendar_events", arEventParams)
                drEventTasks = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_calendar_event_tasks", arEventParams)
            Catch
                Err.Raise(Err.Number, "Class:cTaskCal Routine:GetTaskCalendar", Err.Description)
            End Try

            'Initial Array
            For I = 0 To 365
                arclientCode(I) = ""
                arclientDesc(I) = ""
                ardivCode(I) = ""
                ardivDesc(I) = ""
                arprdCode(I) = ""
                arprdDesc(I) = ""
                arjobCode(I) = ""
                arjobDesc(I) = ""
                arcompCode(I) = ""
                arcompDesc(I) = ""
                arTrfDesc(I) = ""
            Next

            'Init the TaskDates array
            SDate = StartDate
            EDate = EndDate
            months_ct = DateDiff(DateInterval.Month, SDate, EDate)

            currentDate = SDate
            For month_idx = 0 To months_ct
                If month_idx > 0 Then
                    currentDate = DateAdd(DateInterval.Month, 1, currentDate)
                End If
                currentMonth = currentDate.Month
                currentYear = currentDate.Year
                Me.TaskDates(month_idx) = New TaskDate
                Me.TaskDates(month_idx)._month._month = currentMonth
                Me.TaskDates(month_idx)._year = currentYear
                Me.TaskDates(month_idx).initMonth()
            Next

            Dim dv As DataView = New DataView(dt3)
            Dim dt2 As DataTable
            If fromapp = "PSMV" Then
                Dim JCs() As String
                Dim strfilter As String = ""
                Dim count As Integer = 0
                If jobcomps <> "" Then
                    JCs = jobcomps.Split("|")
                    If JCs.Length > 0 Then
                        For k As Integer = 0 To JCs.Length - 1
                            Dim strJC() As String = JCs(k).Split(",")
                            If strJC(0) <> "" Then
                                If count > 0 Then
                                    strfilter &= " OR (JobNum = " & CInt(strJC(0)) & " AND CompNum = " & CInt(strJC(1)) & ")"
                                Else
                                    strfilter = "(JobNum = " & CInt(strJC(0)) & " AND CompNum = " & CInt(strJC(1)) & ")"
                                    count += 1
                                End If
                            End If
                        Next
                    End If
                    dv.RowFilter = strfilter
                    dt2 = dv.ToTable
                End If
            Else
                dt2 = dv.ToTable
            End If

            If showTasks = True Then
                strShow = ""
                For x As Integer = 0 To dt2.Rows.Count - 1

                    Try
                        Try
                            If tClientCode = True Then
                                strShow = strShow & dt2.Rows(x)("CCode") & "|"
                            End If
                            arclientCode(arIDX) = dt2.Rows(x)("CCode")
                        Catch ex As Exception

                        End Try
                        Try

                            If tClientDesc = True Then
                                strShow = strShow & dt2.Rows(x)("CL_NAME") & "|"
                            End If
                            arclientDesc(arIDX) = dt2.Rows(x)("CL_NAME")
                        Catch ex As Exception

                        End Try
                        Try

                            If tDivisionCode = True Then
                                strShow = strShow & dt2.Rows(x)("DCode") & "|"
                            End If
                            ardivCode(arIDX) = dt2.Rows(x)("DCode")
                        Catch ex As Exception

                        End Try

                        Try
                            If tDivisionDesc = True Then
                                strShow = strShow & dt2.Rows(x)("DIV_NAME") & "|"
                            End If
                            ardivDesc(arIDX) = dt2.Rows(x)("DIV_NAME")
                        Catch ex As Exception

                        End Try
                        Try

                            If tProductCode = True Then
                                strShow = strShow & dt2.Rows(x)("PCode") & "|"
                            End If
                            arprdCode(arIDX) = dt2.Rows(x)("PCode")
                        Catch ex As Exception

                        End Try
                        Try

                            If tProductDesc = True Then
                                strShow = strShow & dt2.Rows(x)("PRD_DESCRIPTION") & "|"
                            End If
                            arprdDesc(arIDX) = dt2.Rows(x)("PRD_DESCRIPTION")
                        Catch ex As Exception

                        End Try
                        Try

                            If tJobNumber = True Then
                                strShow = strShow & dt2.Rows(x)("JobNum") & "|"
                            End If
                            arjobCode(arIDX) = dt2.Rows(x)("JobNum")
                        Catch ex As Exception

                        End Try
                        Try

                            If tJobDesc = True Then
                                strShow = strShow & dt2.Rows(x)("JobDesc") & "|"
                            End If
                            arjobDesc(arIDX) = dt2.Rows(x)("JobDesc")
                        Catch ex As Exception

                        End Try
                        Try

                            If tCompNumber = True Then
                                strShow = strShow & dt2.Rows(x)("CompNum") & "|"
                            End If
                            arcompCode(arIDX) = dt2.Rows(x)("CompNum")
                        Catch ex As Exception

                        End Try
                        Try

                            If tCompDesc = True Then
                                strShow = strShow & dt2.Rows(x)("CompDesc") & "|"
                            End If
                            arcompDesc(arIDX) = dt2.Rows(x)("CompDesc")
                        Catch ex As Exception

                        End Try
                        Try

                            If tTaskCode = True Then
                                strShow = strShow & dt2.Rows(x)("TRF_CODE") & "|"
                            End If
                        Catch ex As Exception

                        End Try
                        Try

                            If tTaskDesc = True Then
                                strShow = strShow & dt2.Rows(x)("Task") & "|"
                            End If
                        Catch ex As Exception

                        End Try
                        Try

                            If tcal_empcodedispl = True And dt2.Rows(x)("empcodedispl") <> "" Then
                                strShow = strShow & dt2.Rows(x)("empcodedispl") & "|"
                            End If
                        Catch ex As Exception

                        End Try
                        Try

                            If tcal_empdescdispl = True Then
                                strShow = strShow & dt2.Rows(x)("empdescdispl")
                            End If
                        Catch ex As Exception

                        End Try
                        Try

                            If strShow.EndsWith("|") Then
                                strShow = strShow.Substring(0, strShow.Length - 1)
                            End If
                        Catch ex As Exception

                        End Try
                    Catch ex As Exception

                    End Try


                    arTrfDesc(arIDX) = dt2.Rows(x)("TRF_DESCRIPTION")

                    'TaskDays array
                    day = CInt(dt2.Rows(x)("ThisDay"))
                    tempDate = dt2.Rows(x)("RevisedDate")
                    TaskDateIDX = TaskDatesIDX(tempDate.Month, tempDate.Year)
                    If TaskDateIDX > -1 Then
                        Me.TaskDates(TaskDateIDX)._month._dayTasks(day) = Me.TaskDates(TaskDateIDX)._month._dayTasks(day) & strShow & vbCrLf & vbCrLf
                    End If

                    arIDX = arIDX + 1
                    strShow = ""
                Next
            End If

            Dim oCalendar As TaskCalendar.cCalendar = New TaskCalendar.cCalendar(mConnString)
            Dim ds As DataSet
            Dim strEmps As String

            If showAppointments = True Or showHolidays = True Then
                strTask = ""
                Do While dr2.Read
                    strEmps = ""
                    day = CInt(dr2.GetString(7))
                    ds = oCalendar.GetNonTaskDataDS(dr2("NON_TASK_ID"), UserID)
                    If haEmployeeCode = True And (dr2.GetString(1) = "A" Or dr2.GetString(1) = "C" Or dr2.GetString(1) = "M" Or dr2.GetString(1) = "TD" Or dr2.GetString(1) = "EL") Then
                        If ds.Tables(1).Rows.Count > 0 Then
                            For w As Integer = 0 To ds.Tables(1).Rows.Count - 1
                                strEmps += (ds.Tables(1).Rows(w)("EMP_CODE").ToString) & ","
                            Next
                        End If
                        strTask = strTask & strEmps.Substring(0, strEmps.Length - 1) & "|"
                    End If
                    If haEmployeeName = True And (dr2.GetString(1) = "A" Or dr2.GetString(1) = "C" Or dr2.GetString(1) = "M" Or dr2.GetString(1) = "TD" Or dr2.GetString(1) = "EL") Then
                        If ds.Tables(1).Rows.Count > 0 Then
                            For x As Integer = 0 To ds.Tables(1).Rows.Count - 1
                                strEmps += (ds.Tables(1).Rows(x)("EMP_NAME").ToString) & ","
                            Next
                        End If
                        strTask = strTask & strEmps.Substring(0, strEmps.Length - 1) & "|"
                    End If
                    If haType = True Then
                        strTask = strTask & dr2.GetString(1) & "|"
                    End If
                    If haSubject = True Then
                        strTask = strTask & dr2.GetString(2) & "|"
                    End If
                    If haTimes = True And (dr2.GetString(1) = "A" Or dr2.GetString(1) = "C" Or dr2.GetString(1) = "M" Or dr2.GetString(1) = "TD" Or dr2.GetString(1) = "EL") And dr2.GetInt32(9) = 0 Then
                        strTask = strTask & dr2.GetDateTime(3).ToShortTimeString & " - " & dr2.GetDateTime(4).ToShortTimeString & "|"
                    End If
                    If haHours = True And (dr2.GetString(1) = "A" Or dr2.GetString(1) = "C" Or dr2.GetString(1) = "M" Or dr2.GetString(1) = "TD" Or dr2.GetString(1) = "EL") Then
                        strTask = strTask & dr2.GetDecimal(5) & "|"
                    End If
                    If haTimeCat = True Then
                        strTask = strTask & dr2.GetString(6)
                    End If

                    If strTask.EndsWith("|") Then
                        strTask = strTask.Substring(0, strTask.Length - 1)
                    End If

                    tempDate = dr2.GetDateTime(10)

                    'Calculate and display range
                    'Don't let date range go past report endDate
                    tempDateEnd = CType(dr2.GetDateTime(11), Date)
                    If tempDateEnd > maxDate Then
                        tempDateEnd = maxDate
                    End If

                    days = DateDiff(DateInterval.Day, tempDate, tempDateEnd)

                    For dayIdx = 0 To days
                        arIDX = TaskDatesIDX(tempDate.Month, tempDate.Year)
                        If arIDX > -1 Then
                            Me.TaskDates(arIDX)._month._dayTasks(day) = Me.TaskDates(arIDX)._month._dayTasks(day) & strTask & vbCrLf & vbCrLf
                        End If

                        tempDate = DateAdd(DateInterval.Day, 1, tempDate)
                        day = tempDate.Day
                    Next

                    strTask = ""
                Loop
            End If

            If showEvents = True Then
                Dim strEvent As String = ""

                Do While drEvents.Read
                    day = CInt(drEvents.GetString(4))
                    tempDate = drEvents.GetDateTime(3)

                    strEvent = strEvent & drEvents.GetString(5) & "|"                       'Client Code
                    strEvent = strEvent & drEvents.GetString(0) & "|"                       'Resource Code
                    strEvent = strEvent & drEvents.GetDateTime(1).ToShortTimeString & "|"   'Start Time
                    strEvent = strEvent & drEvents.GetDateTime(2).ToShortTimeString         'End Time

                    If arIDX > -1 Then
                        arIDX = TaskDatesIDX(tempDate.Month, tempDate.Year)
                    End If
                    Me.TaskDates(arIDX)._month._dayTasks(day) = Me.TaskDates(arIDX)._month._dayTasks(day) & strEvent & vbCrLf & vbCrLf
                    strEvent = ""
                Loop
            End If

            If showEventTasks = True Then
                Dim strEventTask As String = ""

                Do While drEventTasks.Read
                    tempDate = drEventTasks.GetDateTime(2)
                    day = CInt(drEventTasks.GetString(4))

                    strEventTask = strEventTask & drEventTasks.GetString(0) & "|"                       'Resource Code
                    strEventTask = strEventTask & drEventTasks.GetString(1) & "|"                       'Task Code
                    strEventTask = strEventTask & drEventTasks.GetDateTime(2).ToShortTimeString & "|"   'Start Time
                    strEventTask = strEventTask & drEventTasks.GetDateTime(3).ToShortTimeString         'End Time

                    If arIDX > -1 Then
                        arIDX = TaskDatesIDX(tempDate.Month, tempDate.Year)
                    End If
                    Me.TaskDates(arIDX)._month._dayTasks(day) = Me.TaskDates(arIDX)._month._dayTasks(day) & strEventTask & vbCrLf & vbCrLf
                    strEventTask = ""
                Loop
            End If

            Dim dt As DataTable
            Dim row As DataRow
            dt = New DataTable("taskMonth")
            Dim sunday As DataColumn = New DataColumn("Sunday")
            Dim monday As DataColumn = New DataColumn("Monday")
            Dim tuesday As DataColumn = New DataColumn("Tuesday")
            Dim wednesday As DataColumn = New DataColumn("Wednesday")
            Dim thursday As DataColumn = New DataColumn("Thursday")
            Dim friday As DataColumn = New DataColumn("Friday")
            Dim saturday As DataColumn = New DataColumn("Saturday")
            Dim dtlmonth As DataColumn = New DataColumn("dtlmonth")
            Dim dtlyear As DataColumn = New DataColumn("dtlyear")
            Dim dtlclient As DataColumn = New DataColumn("dtlclient")
            Dim dtlclientdesc As DataColumn = New DataColumn("dtlclientdesc")
            Dim dtldiv As DataColumn = New DataColumn("dtldiv")
            Dim dtldivdesc As DataColumn = New DataColumn("dtldivdesc")
            Dim dtlprd As DataColumn = New DataColumn("dtlprd")
            Dim dtlprddesc As DataColumn = New DataColumn("dtlprddesc")
            Dim dtljob As DataColumn = New DataColumn("dtljob")
            Dim dtljobdesc As DataColumn = New DataColumn("dtljobdesc")
            Dim dtlcomp As DataColumn = New DataColumn("dtlcomp")
            Dim dtlcompdesc As DataColumn = New DataColumn("dtlcompdesc")
            Dim dtltrfdesc As DataColumn = New DataColumn("dtltrfdesc")
            Dim month1, month2, dataCount As Integer
            Dim monthEmpty As Boolean

            dt.Columns.Add(sunday)
            dt.Columns.Add(monday)
            dt.Columns.Add(tuesday)
            dt.Columns.Add(wednesday)
            dt.Columns.Add(thursday)
            dt.Columns.Add(friday)
            dt.Columns.Add(saturday)
            dt.Columns.Add(dtlmonth)
            dt.Columns.Add(dtlyear)
            dt.Columns.Add(dtlclient)
            dt.Columns.Add(dtlclientdesc)
            dt.Columns.Add(dtldiv)
            dt.Columns.Add(dtldivdesc)
            dt.Columns.Add(dtlprd)
            dt.Columns.Add(dtlprddesc)
            dt.Columns.Add(dtljob)
            dt.Columns.Add(dtljobdesc)
            dt.Columns.Add(dtlcomp)
            dt.Columns.Add(dtlcompdesc)
            dt.Columns.Add(dtltrfdesc)
            row = dt.NewRow

            SDate = CType(StartDate, Date)
            EDate = CType(EndDate, Date)
            months_ct = DateDiff(DateInterval.Month, SDate, EDate)

            currentDate = SDate
            arIDX = 0
            dataCount = 0

            For month_idx = 0 To months_ct
                currentMonth = Me.TaskDates(month_idx)._month._month
                currentYear = Me.TaskDates(month_idx)._year

                monthEmpty = True
                For day = 1 To Me.TaskDates(month_idx).dayCt
                    If Me.TaskDates(month_idx)._month._dayTasks(day).Length > 0 Then
                        monthEmpty = False
                        Exit For
                    End If
                Next
                Dim ci As System.Globalization.CultureInfo = System.Globalization.CultureInfo.GetCultureInfo("en-US")
                If monthEmpty = False Then
                    dataCount = dataCount + 1
                    For day = 1 To Me.TaskDates(month_idx).dayCt

                        row.Item("dtlmonth") = currentMonth
                        row.Item("dtlyear") = currentYear

                        row.Item("dtlclient") = arclientCode(arIDX)
                        row.Item("dtlclientdesc") = arclientDesc(arIDX)
                        row.Item("dtldiv") = ardivCode(arIDX)
                        row.Item("dtldivdesc") = ardivDesc(arIDX)
                        row.Item("dtlprd") = arprdCode(arIDX)
                        row.Item("dtlprddesc") = arprdDesc(arIDX)
                        row.Item("dtljob") = arjobCode(arIDX)
                        row.Item("dtljobdesc") = arjobDesc(arIDX)
                        row.Item("dtlcomp") = arcompCode(arIDX)
                        row.Item("dtlcompdesc") = arcompDesc(arIDX)
                        row.Item("dtltrfdesc") = arTrfDesc(arIDX)

                        If day > 12 Then
                            ThisDay = CDate(ActiveReportsAssembly.ReportFunctions.FormatDate(currentMonth & "/" & CStr(day) & "/" & currentYear))
                        Else
                            If ActiveReportsAssembly.ReportFunctions.UserCultureGet <> "en-US" Then
                                ThisDay = String.Format(ci, "{0:d}", CDate(currentMonth & "/" & CStr(day) & "/" & currentYear))
                            Else
                                ThisDay = currentMonth & "/" & CStr(day) & "/" & currentYear
                            End If
                        End If

                        Select Case ThisDay.DayOfWeek
                            Case DayOfWeek.Sunday
                                If Me.TaskDates(month_idx)._month._dayTasks(day).Length > 0 Then
                                    row.Item("Sunday") = day & vbCrLf & Me.TaskDates(month_idx)._month._dayTasks(day)
                                    arIDX = arIDX + 1
                                Else
                                    row.Item("Sunday") = day
                                End If
                            Case DayOfWeek.Monday
                                If Me.TaskDates(month_idx)._month._dayTasks(day).Length > 0 Then
                                    row.Item("Monday") = day & vbCrLf & Me.TaskDates(month_idx)._month._dayTasks(day)
                                    arIDX = arIDX + 1
                                Else
                                    row.Item("Monday") = day
                                End If
                            Case DayOfWeek.Tuesday
                                If Me.TaskDates(month_idx)._month._dayTasks(day).Length > 0 Then
                                    row.Item("Tuesday") = day & vbCrLf & Me.TaskDates(month_idx)._month._dayTasks(day)
                                    arIDX = arIDX + 1
                                Else
                                    row.Item("Tuesday") = day
                                End If
                            Case DayOfWeek.Wednesday
                                If Me.TaskDates(month_idx)._month._dayTasks(day).Length > 0 Then
                                    row.Item("Wednesday") = day & vbCrLf & Me.TaskDates(month_idx)._month._dayTasks(day)
                                    arIDX = arIDX + 1
                                Else
                                    row.Item("Wednesday") = day
                                End If
                            Case DayOfWeek.Thursday
                                If Me.TaskDates(month_idx)._month._dayTasks(day).Length > 0 Then
                                    row.Item("Thursday") = day & vbCrLf & Me.TaskDates(month_idx)._month._dayTasks(day)
                                    arIDX = arIDX + 1
                                Else
                                    row.Item("Thursday") = day
                                End If
                            Case DayOfWeek.Friday
                                If Me.TaskDates(month_idx)._month._dayTasks(day).Length > 0 Then
                                    row.Item("Friday") = day & vbCrLf & Me.TaskDates(month_idx)._month._dayTasks(day)
                                    arIDX = arIDX + 1
                                Else
                                    row.Item("Friday") = day
                                End If
                            Case DayOfWeek.Saturday
                                If Me.TaskDates(month_idx)._month._dayTasks(day).Length > 0 Then
                                    row.Item("Saturday") = day & vbCrLf & Me.TaskDates(month_idx)._month._dayTasks(day)
                                    arIDX = arIDX + 1
                                Else
                                    row.Item("Saturday") = day
                                End If
                        End Select

                        If ThisDay.DayOfWeek = DayOfWeek.Saturday Or ThisDay.Day = Me.TaskDates(month_idx).dayCt Then
                            dt.Rows.Add(row)
                            row = dt.NewRow
                        End If
                    Next
                End If
            Next

            'dr.Close()
            dr2.Close()
            drEvents.Close()
            drEventTasks.Close()

            Return dt

        End Function

        Public Function GetNewTaskCalendarReportCDPJCGroup3(ByVal StartDate As String, ByVal EndDate As String, ByVal UserID As String, ByVal GroupOption As String,
                                                            Optional ByVal EmpCode As String = "", Optional ByVal Office As String = "", Optional ByVal Client As String = "",
                                                            Optional ByVal Division As String = "", Optional ByVal Product As String = "", Optional ByVal Job As String = "",
                                                            Optional ByVal JobComp As String = "", Optional ByVal ROLES As String = "", Optional ByVal CellLength As Integer = 50,
                                                            Optional ByVal TaskStatus As String = "", Optional ByVal ExcludeTempComplete As Boolean = False, Optional ByVal TaskDuration As Boolean = False,
                                                            Optional ByVal tClientCode As Boolean = True, Optional ByVal tClientDesc As Boolean = False, Optional ByVal tDivisionCode As Boolean = False,
                                                            Optional ByVal tDivisionDesc As Boolean = False, Optional ByVal tProductCode As Boolean = False, Optional ByVal tProductDesc As Boolean = False,
                                                            Optional ByVal tJobNumber As Boolean = False, Optional ByVal tJobDesc As Boolean = False, Optional ByVal tCompNumber As Boolean = False,
                                                            Optional ByVal tCompDesc As Boolean = False, Optional ByVal tTaskCode As Boolean = False, Optional ByVal tTaskDesc As Boolean = False,
                                                            Optional ByVal haEmployeeCode As Boolean = False, Optional ByVal haEmployeeName As Boolean = False, Optional ByVal haType As Boolean = False,
                                                            Optional ByVal haSubject As Boolean = False, Optional ByVal haTimes As Boolean = False, Optional ByVal haHours As Boolean = False,
                                                            Optional ByVal haTimeCat As Boolean = False, Optional ByVal showTasks As Boolean = True, Optional ByVal showAssignments As Boolean = True, Optional ByVal showHolidays As Boolean = True,
                                                            Optional ByVal showAppointments As Boolean = True, Optional ByVal tcal_milestone As Boolean = False, Optional ByVal tcal_empcodedispl As Boolean = False,
                                                            Optional ByVal tcal_empdescdispl As Boolean = False, Optional ByVal tcal_manager As String = "", Optional ByVal showEvents As Boolean = False,
                                                            Optional ByVal showEventTasks As Boolean = False, Optional ByVal DEPTS As String = "", Optional ByVal fromapp As String = "",
                                                            Optional ByVal ShowHoursAllowed As Boolean = False, Optional ByVal Comps As String = "", Optional ByVal cpid As Integer = 0, Optional ByVal IsClientPortal As Boolean = False) As AdvantageFramework.Reporting.Classes.CalendarReport

            'This function will create a calendar report for multiple months with a Cl/Div/Prd/Job/Comp/Month grouping
            Dim Sort As Integer = 0
            Dim UserIDSqlParameter As SqlParameter = Nothing
            Dim EmpCodeSqlParameter As SqlParameter = Nothing
            Dim OfficeSqlParameter As SqlParameter = Nothing
            Dim ClientSqlParameter As SqlParameter = Nothing
            Dim DivisionSqlParameter As SqlParameter = Nothing
            Dim ProductSqlParameter As SqlParameter = Nothing
            Dim JobSqlParameter As SqlParameter = Nothing
            Dim JobCompSqlParameter As SqlParameter = Nothing
            Dim RoleSqlParameter As SqlParameter = Nothing
            Dim StartDateSqlParameter As SqlParameter = Nothing
            Dim EndDateSqlParameter As SqlParameter = Nothing
            Dim TaskStatusSqlParameter As SqlParameter = Nothing
            Dim ExcludeTempCompleteSqlParameter As SqlParameter = Nothing
            Dim MilestoneSqlParameter As SqlParameter = Nothing
            Dim ManagerSqlParameter As SqlParameter = Nothing
            Dim GroupLevelSqlParameter As SqlParameter = Nothing
            Dim ShowTasksSqlParameter As SqlParameter = Nothing
            Dim ShowAssignmentsSqlParameter As SqlParameter = Nothing
            Dim ShowEventsSqlParameter As SqlParameter = Nothing
            Dim ShowEventTasksSqlParameter As SqlParameter = Nothing
            Dim LevelSqlParameter As SqlParameter = Nothing
            Dim GroupingSqlParameter As SqlParameter = Nothing
            Dim FromAppSqlParameter As SqlParameter = Nothing
            Dim TypeSqlParameter As SqlParameter = Nothing
            Dim DeptsSqlParameter As SqlParameter = Nothing
            Dim CPIDSqlParameter As SqlParameter = Nothing
            Dim TaskSqlParameters As SqlParameter() = Nothing
            Dim NonTaskSqlParameters As SqlParameter() = Nothing
            Dim TaskDataTable As System.Data.DataTable = Nothing
            Dim NonTaskDataTable As System.Data.DataTable = Nothing
            Dim TaskSqlDataReader As System.Data.SqlClient.SqlDataReader = Nothing
            Dim NonTaskSqlDataReader As System.Data.SqlClient.SqlDataReader = Nothing
            Dim TaskDataRow As System.Data.DataRow = Nothing
            Dim NonTaskDataRow As System.Data.DataRow = Nothing
            Dim CalendarReport As AdvantageFramework.Reporting.Classes.CalendarReport = Nothing
            Dim CalendarItem As AdvantageFramework.Reporting.Classes.CalendarReport.CalendarItem = Nothing
            Dim CalendarWorksheet As AdvantageFramework.Reporting.Classes.CalendarReport.Worksheet = Nothing
            Dim NonTaskDataSet As DataSet = Nothing
            Dim WorksheetKeys As String() = Nothing
            Dim WorksheetKey As String = Nothing
            Dim DescriptionList As Generic.List(Of String) = Nothing
            Dim oCalendar As TaskCalendar.cCalendar = New TaskCalendar.cCalendar(mConnString)
            Dim AddNonTask As Boolean = False
            Dim NonTaskClientCode As String = Nothing
            Dim NonTaskDivisionCode As String = Nothing
            Dim NonTaskProductCode As String = Nothing
            Dim NonTaskJobNumber As Integer? = Nothing
            Dim NonTaskJobComponentNumber As Short? = Nothing
            Dim NonTaskKey As String = Nothing
            Dim NonTaskPassesClient As Boolean = False
            Dim NonTaskPassesDivision As Boolean = False
            Dim NonTaskPassesProduct As Boolean = False
            Dim NonTaskPassesJob As Boolean = False
            Dim NonTaskPassesJobComponent As Boolean = False
            Dim FilterString As String = ""
            Dim JobCompArray As String() = Nothing

            CalendarReport = New AdvantageFramework.Reporting.Classes.CalendarReport

            UserIDSqlParameter = New SqlParameter("@UserID", SqlDbType.VarChar, 100)
            EmpCodeSqlParameter = New SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
            OfficeSqlParameter = New SqlParameter("@OfficeCode", SqlDbType.VarChar, 6)
            ClientSqlParameter = New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
            DivisionSqlParameter = New SqlParameter("@DivCode", SqlDbType.VarChar, 6)
            ProductSqlParameter = New SqlParameter("@ProdCode", SqlDbType.VarChar, 6)
            JobSqlParameter = New SqlParameter("@JobNumber", SqlDbType.VarChar, 6)
            JobCompSqlParameter = New SqlParameter("@JobComp", SqlDbType.VarChar, 6)
            RoleSqlParameter = New SqlParameter("@ROLES", SqlDbType.VarChar, 8000)
            StartDateSqlParameter = New SqlParameter("@StartDate", SqlDbType.VarChar, 10)
            EndDateSqlParameter = New SqlParameter("@EndDate", SqlDbType.VarChar, 10)
            TaskStatusSqlParameter = New SqlParameter("@TaskStatus", SqlDbType.VarChar, 1)
            ExcludeTempCompleteSqlParameter = New SqlParameter("@ExcludeTempComplete", SqlDbType.Char, 1)
            MilestoneSqlParameter = New SqlParameter("@MilestonesOnly", SqlDbType.VarChar, 1)
            ManagerSqlParameter = New SqlParameter("@Manager", SqlDbType.VarChar, 6)
            GroupLevelSqlParameter = New SqlParameter("@GrpLevel", SqlDbType.VarChar, 1)
            ShowTasksSqlParameter = New SqlParameter("@showTasks", SqlDbType.VarChar, 1)
            ShowAssignmentsSqlParameter = New SqlParameter("@showAssignments", SqlDbType.VarChar, 1)
            ShowEventsSqlParameter = New SqlParameter("@showEvents", SqlDbType.VarChar, 1)
            ShowEventTasksSqlParameter = New SqlParameter("@showEventTasks", SqlDbType.VarChar, 1)
            LevelSqlParameter = New SqlParameter("@Level", SqlDbType.VarChar, 1)
            GroupingSqlParameter = New SqlParameter("@Grouping", SqlDbType.VarChar, 10)
            FromAppSqlParameter = New SqlParameter("@FromApp", SqlDbType.VarChar, 10)
            TypeSqlParameter = New SqlParameter("@Type", SqlDbType.Char, 2)
            DeptsSqlParameter = New SqlParameter("@DEPTS", SqlDbType.VarChar, 8000)
            CPIDSqlParameter = New SqlParameter("@CDPID", SqlDbType.Int)

            UserIDSqlParameter.Value = UserID
            EmpCodeSqlParameter.Value = EmpCode
            OfficeSqlParameter.Value = Office
            ClientSqlParameter.Value = Client
            DivisionSqlParameter.Value = Division
            ProductSqlParameter.Value = Product
            JobSqlParameter.Value = Job
            JobCompSqlParameter.Value = JobComp
            RoleSqlParameter.Value = ROLES
            StartDateSqlParameter.Value = StartDate
            EndDateSqlParameter.Value = EndDate
            TaskStatusSqlParameter.Value = TaskStatus
            ManagerSqlParameter.Value = tcal_manager
            GroupLevelSqlParameter.Value = GroupOption
            CPIDSqlParameter.Value = cpid

            If ExcludeTempComplete = True Then

                ExcludeTempCompleteSqlParameter.Value = "Y"

            Else

                ExcludeTempCompleteSqlParameter.Value = "N"

            End If

            MilestoneSqlParameter.Value = BoolToYN(tcal_milestone)

            If showTasks = True Then

                ShowTasksSqlParameter.Value = "1"

            Else

                ShowTasksSqlParameter.Value = "0"

            End If

            If showAssignments = True Then

                ShowAssignmentsSqlParameter.Value = "1"

            Else

                ShowAssignmentsSqlParameter.Value = "0"

            End If

            If showEvents = True Then

                ShowEventsSqlParameter.Value = "1"

            Else

                ShowEventsSqlParameter.Value = "0"

            End If

            If showEventTasks = True Then

                ShowEventTasksSqlParameter.Value = "1"

            Else

                ShowEventTasksSqlParameter.Value = "0"

            End If

            LevelSqlParameter.Value = ""
            GroupingSqlParameter.Value = ""
            FromAppSqlParameter.Value = fromapp

            If showHolidays = True AndAlso showAppointments = True Then

                TypeSqlParameter.Value = ""

            ElseIf showHolidays = True AndAlso showAppointments = False Then

                TypeSqlParameter.Value = "H"

            ElseIf showHolidays = False AndAlso showAppointments = True Then

                TypeSqlParameter.Value = "A"

            Else

                TypeSqlParameter.Value = "N"

            End If

            DeptsSqlParameter.Value = DEPTS


            If IsClientPortal Then

                TaskSqlParameters = {UserIDSqlParameter, EmpCodeSqlParameter, OfficeSqlParameter, ClientSqlParameter, DivisionSqlParameter, ProductSqlParameter, JobSqlParameter, JobCompSqlParameter,
                                 RoleSqlParameter, StartDateSqlParameter, EndDateSqlParameter, TaskStatusSqlParameter, ExcludeTempCompleteSqlParameter, MilestoneSqlParameter, ManagerSqlParameter,
                                 GroupLevelSqlParameter, ShowTasksSqlParameter, ShowAssignmentsSqlParameter, ShowEventsSqlParameter, ShowEventTasksSqlParameter, DeptsSqlParameter, CPIDSqlParameter}


            Else

                TaskSqlParameters = {UserIDSqlParameter, EmpCodeSqlParameter, OfficeSqlParameter, ClientSqlParameter, DivisionSqlParameter, ProductSqlParameter, JobSqlParameter, JobCompSqlParameter,
                                 RoleSqlParameter, StartDateSqlParameter, EndDateSqlParameter, TaskStatusSqlParameter, ExcludeTempCompleteSqlParameter, MilestoneSqlParameter, ManagerSqlParameter,
                                 GroupLevelSqlParameter, ShowTasksSqlParameter, ShowAssignmentsSqlParameter, ShowEventsSqlParameter, ShowEventTasksSqlParameter, DeptsSqlParameter}


            End If


            NonTaskSqlParameters = {StartDateSqlParameter, EndDateSqlParameter, EmpCodeSqlParameter, TypeSqlParameter, UserIDSqlParameter, RoleSqlParameter, DeptsSqlParameter, ClientSqlParameter,
                                    DivisionSqlParameter, ProductSqlParameter, JobSqlParameter, JobCompSqlParameter, LevelSqlParameter, GroupingSqlParameter, FromAppSqlParameter}

            Try

                If IsClientPortal Then

                    TaskSqlDataReader = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_cp_calendar_task_month_rpt2", TaskSqlParameters)

                Else

                    TaskSqlDataReader = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_calendar_task_month_rpt2", TaskSqlParameters)

                End If

            Catch
                Err.Raise(Err.Number, "Class:cTaskCal Routine:GetTaskCalendarReportCDPJCGroup", Err.Description)
            End Try

            If showAppointments = True Or showHolidays = True And IsClientPortal = False Then

                Try

                    NonTaskSqlDataReader = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_nontask_GetTasks", NonTaskSqlParameters)

                Catch
                    Err.Raise(Err.Number, "Class:cTaskCal Routine:GetTaskCalendarReportCDPJCGroup", Err.Description)
                End Try

                If NonTaskSqlDataReader IsNot Nothing Then

                    NonTaskDataTable = New DataTable
                    NonTaskDataTable.Load(NonTaskSqlDataReader)

                End If

            End If

            TaskDataTable = New DataTable
            TaskDataTable.Load(TaskSqlDataReader)

            If fromapp = "PSMV" Then

                If Not String.IsNullOrWhiteSpace(Comps) Then

                    JobCompArray = Comps.Split("|")

                    If JobCompArray.Length > 0 Then

                        For CompIdx As Integer = 0 To JobCompArray.Length - 1

                            If Not String.IsNullOrWhiteSpace(JobCompArray(CompIdx).Split(",")(0)) Then

                                If String.IsNullOrWhiteSpace(FilterString) Then

                                    FilterString = "(JOB_NUMBER = " & CInt(JobCompArray(CompIdx).Split(",")(0)) & " AND JOB_COMPONENT_NBR = " & CInt(JobCompArray(CompIdx).Split(",")(1)) & ")"

                                Else

                                    FilterString &= " OR (JOB_NUMBER = " & CInt(JobCompArray(CompIdx).Split(",")(0)) & " AND JOB_COMPONENT_NBR = " & CInt(JobCompArray(CompIdx).Split(",")(1)) & ")"

                                End If

                            End If

                        Next

                    End If

                End If

            End If

            With New DataView(TaskDataTable)

                If Not String.IsNullOrWhiteSpace(FilterString) Then

                    .RowFilter = FilterString

                End If

                TaskDataTable = .ToTable

            End With

            Dim JobComponentViews As Generic.List(Of AdvantageFramework.Database.Views.JobComponentView) = Nothing

            JobComponentViews = (From Item In TaskDataTable.Rows.OfType(Of System.Data.DataRow)
                                 Select New AdvantageFramework.Database.Views.JobComponentView With {
                                     .ClientCode = Item("CL_CODE"),
                                     .ClientName = Item("CL_NAME"),
                                     .DivisionCode = Item("DIV_CODE"),
                                     .DivisionName = Item("DIV_NAME"),
                                     .ProductCode = Item("PRD_CODE"),
                                     .ProductDescription = Item("PRD_DESCRIPTION"),
                                     .JobNumber = Item("JOB_NUMBER"),
                                     .JobDescription = Item("JOB_DESC"),
                                     .JobComponentNumber = Item("JOB_COMPONENT_NBR"),
                                     .JobComponentDescription = Item("JOB_COMP_DESC")}).ToList

            WorksheetKeys = (From Item In TaskDataTable.Rows.OfType(Of System.Data.DataRow)
                             Let TheKey = Item("CL_CODE") & "|" & Item("CL_NAME") &
                                          If(GroupOption >= 2, "|" & Item("DIV_CODE").ToString, "") &
                                          If(GroupOption >= 3, "|" & Item("PRD_CODE").ToString, "") &
                                          If(GroupOption >= 4, "|" & Item("JOB_NUMBER").ToString, "") &
                                          If(GroupOption >= 5, "|" & Item("JOB_COMPONENT_NBR").ToString, "")
                             Select [k] = TheKey.ToString).Distinct.ToArray

            DescriptionList = New Generic.List(Of String)


            For Each JobComponentView As IGrouping(Of String, AdvantageFramework.Database.Views.JobComponentView) In JobComponentViews.GroupBy(Function(jc)
                                                                                                                                                   Dim Keys As Generic.List(Of String) = New Generic.List(Of String)
                                                                                                                                                   Keys.Add(jc.ClientCode)
                                                                                                                                                   If GroupOption >= 2 Then
                                                                                                                                                       Keys.Add(jc.DivisionCode)
                                                                                                                                                   End If
                                                                                                                                                   If GroupOption >= 3 Then
                                                                                                                                                       Keys.Add(jc.ProductCode)
                                                                                                                                                   End If
                                                                                                                                                   If GroupOption >= 4 Then
                                                                                                                                                       Keys.Add(jc.JobNumber.ToString)
                                                                                                                                                   End If
                                                                                                                                                   If GroupOption >= 5 Then
                                                                                                                                                       Keys.Add(jc.JobComponentNumber.ToString)
                                                                                                                                                   End If
                                                                                                                                                   Return String.Join("|", Keys)
                                                                                                                                               End Function)

                CalendarWorksheet = New AdvantageFramework.Reporting.Classes.CalendarReport.Worksheet

                CalendarWorksheet.Name = JobComponentView.Key

                If GroupOption = 1 Then

                    CalendarWorksheet.Subtitle = New AdvantageFramework.Database.Entities.Client With {
                        .Code = JobComponentView.First.ClientCode,
                        .Name = JobComponentView.First.ClientName}

                ElseIf GroupOption = 2 Then

                    CalendarWorksheet.Subtitle = New AdvantageFramework.Database.Views.DivisionView With {
                        .ClientCode = JobComponentView.First.ClientCode,
                        .ClientName = JobComponentView.First.ClientName,
                        .DivisionCode = JobComponentView.First.DivisionCode,
                        .DivisionName = JobComponentView.First.DivisionName}

                ElseIf GroupOption = 3 Then

                    CalendarWorksheet.Subtitle = New AdvantageFramework.Database.Views.ProductView With {
                        .ClientCode = JobComponentView.First.ClientCode,
                        .ClientName = JobComponentView.First.ClientName,
                        .DivisionCode = JobComponentView.First.DivisionCode,
                        .DivisionName = JobComponentView.First.DivisionName,
                        .ProductCode = JobComponentView.First.ProductCode,
                        .ProductDescription = JobComponentView.First.ProductDescription}

                ElseIf GroupOption = 4 Then

                    CalendarWorksheet.Subtitle = New AdvantageFramework.Database.Views.JobView With {
                        .ClientCode = JobComponentView.First.ClientCode,
                        .ClientName = JobComponentView.First.ClientName,
                        .DivisionCode = JobComponentView.First.DivisionCode,
                        .DivisionName = JobComponentView.First.DivisionName,
                        .ProductCode = JobComponentView.First.ProductCode,
                        .ProductDescription = JobComponentView.First.ProductDescription,
                        .JobNumber = JobComponentView.First.JobNumber,
                        .JobDescription = JobComponentView.First.JobDescription}

                ElseIf GroupOption = 5 Then

                    CalendarWorksheet.Subtitle = JobComponentView.First

                End If

                For Each TaskDataRow In (From Item In TaskDataTable.Rows.OfType(Of System.Data.DataRow)
                                         Let TheKey = Item("CL_CODE") & If(GroupOption >= 2, "|" & Item("DIV_CODE").ToString, "") & If(GroupOption >= 3, "|" & Item("PRD_CODE").ToString, "") & If(GroupOption >= 4, "|" & Item("JOB_NUMBER").ToString, "") & If(GroupOption >= 5, "|" & Item("JOB_COMPONENT_NBR").ToString, "")
                                         Where TheKey = JobComponentView.Key
                                         Select Item).ToList

                    CalendarItem = New AdvantageFramework.Reporting.Classes.CalendarReport.CalendarItem
                    DescriptionList.Clear()

                    CalendarItem.JobNumber = TaskDataRow("JOB_NUMBER")
                    CalendarItem.JobComponentNumber = TaskDataRow("JOB_COMPONENT_NBR")

                    If IsDBNull(TaskDataRow("START_DATE")) = False Then
                        CalendarItem.StartDate = CDate(TaskDataRow("START_DATE"))
                    End If
                    If IsDBNull(TaskDataRow("REVISED_DATE")) = False Then
                        CalendarItem.EndDate = CDate(TaskDataRow("REVISED_DATE"))
                    Else
                        If IsDBNull(TaskDataRow("START_DATE")) = False Then
                            CalendarItem.EndDate = CDate(TaskDataRow("START_DATE"))
                        End If
                    End If

                    Select Case CShort(TaskDataRow("SORT"))

                        Case 1  'Tasks

                            If tClientCode = True Then

                                DescriptionList.Add(TaskDataRow("CL_CODE"))

                            End If

                            If tClientDesc = True Then

                                DescriptionList.Add(TaskDataRow("CL_NAME"))

                            End If

                            If tDivisionCode = True Then

                                DescriptionList.Add(TaskDataRow("DIV_CODE"))

                            End If

                            If tDivisionDesc = True Then

                                DescriptionList.Add(TaskDataRow("DIV_NAME"))

                            End If

                            If tProductCode = True Then

                                DescriptionList.Add(TaskDataRow("PRD_CODE"))

                            End If

                            If tProductDesc = True Then

                                DescriptionList.Add(TaskDataRow("PRD_DESCRIPTION"))

                            End If

                            If tJobNumber = True Then

                                DescriptionList.Add(TaskDataRow("JOB_NUMBER"))

                            End If

                            If tJobDesc = True Then

                                DescriptionList.Add(TaskDataRow("JOB_DESC"))

                            End If

                            If tCompNumber = True Then

                                DescriptionList.Add(TaskDataRow("JOB_COMPONENT_NBR"))

                            End If

                            If tCompDesc = True Then

                                DescriptionList.Add(TaskDataRow("JOB_COMP_DESC"))

                            End If

                            If tTaskCode = True Then

                                DescriptionList.Add(TaskDataRow("TRF_CODE"))

                            End If

                            If tTaskDesc = True Then

                                DescriptionList.Add(TaskDataRow("TASK"))

                            End If

                            If tcal_empcodedispl = True AndAlso TaskDataRow("EMP_CODE_DISPL") <> "" Then

                                If ShowHoursAllowed Then

                                    DescriptionList.Add(TaskDataRow("EMP_CODE_HOURS_DISPL"))

                                Else

                                    DescriptionList.Add(TaskDataRow("EMP_CODE_DISPL"))

                                End If

                            End If

                            If tcal_empdescdispl = True AndAlso TaskDataRow("EMP_DESC_DISPL") <> "" Then

                                If ShowHoursAllowed Then

                                    DescriptionList.Add(TaskDataRow("EMP_DESC_HOURS_DISPL"))

                                Else

                                    DescriptionList.Add(TaskDataRow("EMP_DESC_DISPL"))

                                End If

                            End If

                        Case 2  'Event

                            DescriptionList.Add(TaskDataRow("CL_CODE"))
                            DescriptionList.Add(TaskDataRow("TRF_CODE"))
                            DescriptionList.Add(CDate(TaskDataRow("REVISED_DATE")).ToShortTimeString)
                            DescriptionList.Add(CDate(TaskDataRow("START_DATE")).ToShortTimeString)

                        Case 3  'Event Task

                            DescriptionList.Add(TaskDataRow("TASK"))
                            DescriptionList.Add(TaskDataRow("TRF_CODE"))
                            DescriptionList.Add(CDate(TaskDataRow("REVISED_DATE")).ToShortTimeString)
                            DescriptionList.Add(CDate(TaskDataRow("START_DATE")).ToShortTimeString)

                    End Select

                    CalendarItem.Description = String.Join(" | ", DescriptionList)

                    CalendarWorksheet.CalendarItems.Add(CalendarItem)

                Next

                If showAppointments = True OrElse showHolidays = True And IsClientPortal = False Then

                    For Each NonTaskDataRow In NonTaskDataTable.Rows.OfType(Of System.Data.DataRow)

                        AddNonTask = True
                        NonTaskClientCode = Nothing
                        NonTaskDivisionCode = Nothing
                        NonTaskProductCode = Nothing
                        NonTaskJobNumber = Nothing
                        NonTaskJobComponentNumber = Nothing

                        If Not IsDBNull(NonTaskDataRow("CL_CODE")) Then

                            NonTaskClientCode = NonTaskDataRow("CL_CODE")

                        End If

                        If Not IsDBNull(NonTaskDataRow("DIV_CODE")) Then

                            NonTaskDivisionCode = NonTaskDataRow("DIV_CODE")

                        End If

                        If Not IsDBNull(NonTaskDataRow("PRD_CODE")) Then

                            NonTaskProductCode = NonTaskDataRow("PRD_CODE")

                        End If

                        If Not IsDBNull(NonTaskDataRow("JOB_NUMBER")) Then

                            NonTaskJobNumber = NonTaskDataRow("JOB_NUMBER")

                        End If

                        If Not IsDBNull(NonTaskDataRow("JOB_COMPONENT_NBR")) Then

                            NonTaskJobComponentNumber = NonTaskDataRow("JOB_COMPONENT_NBR")

                        End If

                        NonTaskPassesClient = False
                        NonTaskPassesDivision = False
                        NonTaskPassesProduct = False
                        NonTaskPassesJob = False
                        NonTaskPassesJobComponent = False

                        If String.IsNullOrWhiteSpace(NonTaskClientCode) OrElse JobComponentView.First.ClientCode = NonTaskClientCode Then

                            NonTaskPassesClient = True

                        End If

                        If String.IsNullOrWhiteSpace(NonTaskDivisionCode) OrElse JobComponentView.First.DivisionCode = NonTaskDivisionCode Then

                            NonTaskPassesDivision = NonTaskPassesClient

                        End If

                        If String.IsNullOrWhiteSpace(NonTaskProductCode) OrElse JobComponentView.First.ProductCode = NonTaskProductCode Then

                            NonTaskPassesProduct = NonTaskPassesDivision

                        End If

                        If NonTaskJobNumber.HasValue = False OrElse JobComponentView.First.JobNumber = NonTaskJobNumber Then

                            NonTaskPassesJob = True

                        End If

                        If NonTaskJobComponentNumber.HasValue = False OrElse JobComponentView.First.JobComponentNumber = NonTaskJobComponentNumber Then

                            NonTaskPassesJobComponent = NonTaskPassesJob

                        End If

                        If GroupOption = 1 Then

                            AddNonTask = NonTaskPassesClient

                        ElseIf GroupOption = 2 Then

                            AddNonTask = NonTaskPassesDivision

                        ElseIf GroupOption = 3 Then

                            AddNonTask = NonTaskPassesProduct

                        ElseIf GroupOption = 4 Then

                            AddNonTask = NonTaskPassesJob

                        ElseIf GroupOption = 5 Then

                            AddNonTask = NonTaskPassesJobComponent

                        Else

                            AddNonTask = False

                        End If

                        If AddNonTask Then

                            DescriptionList.Clear()

                            CalendarItem = New AdvantageFramework.Reporting.Classes.CalendarReport.CalendarItem

                            CalendarItem.StartDate = CDate(NonTaskDataRow("START_DATE"))
                            CalendarItem.EndDate = CDate(NonTaskDataRow("END_DATE"))

                            If (haEmployeeCode = True OrElse haEmployeeName) AndAlso ({"A", "C", "M", "TD", "EL"}.Contains(NonTaskDataRow("TYPE"))) Then

                                NonTaskDataSet = oCalendar.GetNonTaskDataDS(NonTaskDataRow("NON_TASK_ID"), UserID)

                                If NonTaskDataSet.Tables(1).Rows.Count > 0 Then

                                    If haEmployeeCode = True Then

                                        DescriptionList.Add(String.Join(", ", (From Item In NonTaskDataSet.Tables(1).Rows
                                                                               Select Item("EMP_CODE")).ToList))

                                    End If

                                    If haEmployeeName = True Then

                                        DescriptionList.Add(String.Join(", ", (From Item In NonTaskDataSet.Tables(1).Rows
                                                                               Select Item("EMP_NAME")).ToList))

                                    End If

                                End If

                            End If

                            If haType = True Then

                                DescriptionList.Add(NonTaskDataRow("TYPE"))

                            End If

                            If haSubject = True Then

                                DescriptionList.Add(NonTaskDataRow("NON_TASK_DESC"))

                            End If

                            If haTimes = True AndAlso {"A", "C", "M", "TD", "EL"}.Contains(NonTaskDataRow("TYPE")) And NonTaskDataRow("ALL_DAY") = 0 Then

                                DescriptionList.Add(CDate(NonTaskDataRow("START_TIME")).ToShortTimeString & " - " & CDate(NonTaskDataRow("END_TIME")).ToShortTimeString)

                            End If

                            If haHours = True AndAlso {"A", "C", "M", "TD", "EL"}.Contains(NonTaskDataRow("TYPE")) Then

                                DescriptionList.Add(NonTaskDataRow("HOURS"))

                            End If

                            If haTimeCat = True Then

                                DescriptionList.Add(NonTaskDataRow(6))

                            End If

                            CalendarItem.Description = String.Join(" | ", DescriptionList)

                            CalendarWorksheet.CalendarItems.Add(CalendarItem)

                        End If

                    Next

                End If

                If CalendarWorksheet.CalendarItems IsNot Nothing AndAlso CalendarWorksheet.CalendarItems.Count > 0 Then

                    CalendarReport.AddWorksheet(CalendarWorksheet)

                End If

            Next

            If TaskSqlDataReader IsNot Nothing Then

                TaskSqlDataReader.Close()

            End If

            If NonTaskSqlDataReader IsNot Nothing Then

                NonTaskSqlDataReader.Close()

            End If

            Return CalendarReport

        End Function
        Public Function GetNewTaskCalendarReport(ByVal StartDate As DateTime, ByVal EndDate As DateTime, ByVal UserID As String, ByVal GroupOption As String, Optional ByVal EmployeeCode As String = "", Optional ByVal Office As String = "", Optional ByVal Client As String = "",
                                                 Optional ByVal Division As String = "", Optional ByVal Product As String = "", Optional ByVal Job As String = "", Optional ByVal JobComponent As String = "", Optional ByVal Roles As String = "", Optional ByVal CellLength As Integer = 50,
                                                 Optional ByVal TaskStatus As String = "", Optional ByVal ExcludeTempComplete As Boolean = False, Optional ByVal TaskDuration As Boolean = False, Optional ByVal tClientCode As Boolean = True, Optional ByVal tClientDesc As Boolean = False,
                                                 Optional ByVal tDivisionCode As Boolean = False, Optional ByVal tDivisionDesc As Boolean = False, Optional ByVal tProductCode As Boolean = False, Optional ByVal tProductDesc As Boolean = False, Optional ByVal tJobNumber As Boolean = False,
                                                 Optional ByVal tJobDesc As Boolean = False, Optional ByVal tCompNumber As Boolean = False, Optional ByVal tCompDesc As Boolean = False, Optional ByVal tTaskCode As Boolean = False, Optional ByVal tTaskDesc As Boolean = False,
                                                 Optional ByVal haEmployeeCode As Boolean = False, Optional ByVal haEmployeeName As Boolean = False, Optional ByVal haType As Boolean = False, Optional ByVal haSubject As Boolean = False, Optional ByVal haTimes As Boolean = False,
                                                 Optional ByVal haHours As Boolean = False, Optional ByVal haTimeCat As Boolean = False, Optional ByVal showTasks As Boolean = True, Optional ByVal showAssignments As Boolean = True, Optional ByVal showHolidays As Boolean = True, Optional ByVal showAppointments As Boolean = True,
                                                 Optional ByVal tcal_milestone As Boolean = False, Optional ByVal tcal_empcodedispl As Boolean = False, Optional ByVal tcal_empdescdispl As Boolean = False, Optional ByVal tcal_manager As String = "", Optional ByVal showEvents As Boolean = False,
                                                 Optional ByVal showEventTasks As Boolean = False, Optional ByVal DEPTS As String = "", Optional ByVal fromapp As String = "", Optional ByVal jobcomps As String = "", Optional ByVal ShowHoursAllowed As Boolean = False, Optional ByVal IncludeUnassigned As Boolean = False,
                                                 Optional ByVal cpid As Integer = 0, Optional ByVal IsClientPortal As Boolean = False) As AdvantageFramework.Reporting.Classes.CalendarReport

            'This function will create a calendar report for multiple months with a Month/Year grouping
            Dim TaskString As String = Nothing
            Dim TaskParameters As SqlParameter() = Nothing
            Dim AssignmentsParameters As SqlParameter() = Nothing
            Dim NonTaskParameters As SqlParameter() = Nothing
            Dim EventParameters As SqlParameter() = Nothing
            Dim UserIDSqlParameter As SqlParameter = Nothing
            Dim EmployeeCodeSqlParameter As SqlParameter = Nothing
            Dim OfficeCodeSqlParameter As SqlParameter = Nothing
            Dim ClientCodeSqlParameter As SqlParameter = Nothing
            Dim DivisionCodeSqlParameter As SqlParameter = Nothing
            Dim ProductCodeSqlParameter As SqlParameter = Nothing
            Dim JobNumberSqlParameter As SqlParameter = Nothing
            Dim JobComponentSqlParameter As SqlParameter = Nothing
            Dim RolesSqlParameter As SqlParameter = Nothing
            Dim StartDateSqlParameter As SqlParameter = Nothing
            Dim EndDateSqlParameter As SqlParameter = Nothing
            Dim TaskStatusSqlParameter As SqlParameter = Nothing
            Dim ExcludeTempCompleteSqlParameter As SqlParameter = Nothing
            Dim MilestonesOnlySqlParameter As SqlParameter = Nothing
            Dim ManagerSqlParameter As SqlParameter = Nothing
            Dim GroupLevelSqlParameter As SqlParameter = Nothing
            Dim LevelSqlParameter As SqlParameter = Nothing
            Dim GroupingSqlParameter As SqlParameter = Nothing
            Dim FromAppSqlParameter As SqlParameter = Nothing
            Dim TypeSqlParameter As SqlParameter = Nothing
            Dim DepartmentsSqlParameter As SqlParameter = Nothing
            Dim IncludeUnassignedSqlParameter As SqlParameter = Nothing
            Dim CPIDSqlParameter As SqlParameter = Nothing
            Dim JobCompArray As String() = Nothing
            Dim JobCompArrayVal As String = Nothing
            Dim FilterString As String = Nothing
            Dim TasksDataTable As DataTable = Nothing
            Dim FilteredTasksDataTable As DataTable = Nothing
            Dim AssignmentssDataTable As DataTable = Nothing
            Dim NonTaskDataReader As SqlDataReader = Nothing
            Dim EventsDataReader As SqlDataReader = Nothing
            Dim EventTasksDataReader As SqlDataReader = Nothing
            Dim TaskDataRow As DataRow = Nothing
            Dim CalendarReport As AdvantageFramework.Reporting.Classes.CalendarReport = Nothing
            Dim CalendarItem As AdvantageFramework.Reporting.Classes.CalendarReport.CalendarItem = Nothing
            Dim CalendarWorksheet As AdvantageFramework.Reporting.Classes.CalendarReport.Worksheet = Nothing
            Dim DescriptionList As Generic.List(Of String) = Nothing
            Dim oCalendar As TaskCalendar.cCalendar = New TaskCalendar.cCalendar(mConnString)
            Dim EmployeesString As String = Nothing
            Dim NonTaskDataset As DataSet = Nothing

            CalendarReport = New AdvantageFramework.Reporting.Classes.CalendarReport
            CalendarWorksheet = CalendarReport.AddWorksheet()

            UserIDSqlParameter = New SqlParameter("@UserID", SqlDbType.VarChar, 100)
            EmployeeCodeSqlParameter = New SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
            OfficeCodeSqlParameter = New SqlParameter("@OfficeCode", SqlDbType.VarChar, 6)
            ClientCodeSqlParameter = New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
            DivisionCodeSqlParameter = New SqlParameter("@DivCode", SqlDbType.VarChar, 6)
            ProductCodeSqlParameter = New SqlParameter("@ProdCode", SqlDbType.VarChar, 6)
            JobNumberSqlParameter = New SqlParameter("@JobNumber", SqlDbType.VarChar, 6)
            JobComponentSqlParameter = New SqlParameter("@JobComp", SqlDbType.VarChar, 6)
            RolesSqlParameter = New SqlParameter("@ROLES", SqlDbType.VarChar, 8000)
            StartDateSqlParameter = New SqlParameter("@StartDate", SqlDbType.SmallDateTime)
            EndDateSqlParameter = New SqlParameter("@EndDate", SqlDbType.SmallDateTime)
            TaskStatusSqlParameter = New SqlParameter("@TaskStatus", SqlDbType.VarChar, 1)
            ExcludeTempCompleteSqlParameter = New SqlParameter("@ExcludeTempComplete", SqlDbType.VarChar, 1)
            MilestonesOnlySqlParameter = New SqlParameter("@MilestonesOnly", SqlDbType.VarChar, 1)
            ManagerSqlParameter = New SqlParameter("@Manager", SqlDbType.VarChar, 6)
            GroupLevelSqlParameter = New SqlParameter("@GrpLevel", SqlDbType.VarChar, 1)
            LevelSqlParameter = New SqlParameter("@Level", SqlDbType.VarChar, 1)
            GroupingSqlParameter = New SqlParameter("@Grouping", SqlDbType.VarChar, 10)
            FromAppSqlParameter = New SqlParameter("@FromApp", SqlDbType.VarChar, 10)
            TypeSqlParameter = New SqlParameter("@Type", SqlDbType.VarChar, 2)
            IncludeUnassignedSqlParameter = New SqlParameter("@IncludeUnassigned", SqlDbType.Bit)
            CPIDSqlParameter = New SqlParameter("@CDPID", SqlDbType.Int)

            UserIDSqlParameter.Value = UserID
            EmployeeCodeSqlParameter.Value = EmployeeCode
            OfficeCodeSqlParameter.Value = Office
            ClientCodeSqlParameter.Value = Client
            DivisionCodeSqlParameter.Value = Division
            ProductCodeSqlParameter.Value = Product
            JobNumberSqlParameter.Value = Job
            JobComponentSqlParameter.Value = JobComponent
            RolesSqlParameter.Value = Roles
            StartDateSqlParameter.Value = StartDate
            EndDateSqlParameter.Value = EndDate
            TaskStatusSqlParameter.Value = TaskStatus
            ExcludeTempCompleteSqlParameter.Value = If(ExcludeTempComplete = True, "Y", "N")
            MilestonesOnlySqlParameter.Value = BoolToYN(tcal_milestone)
            ManagerSqlParameter.Value = tcal_manager
            GroupLevelSqlParameter.Value = GroupOption
            LevelSqlParameter.Value = ""
            GroupingSqlParameter.Value = ""
            FromAppSqlParameter.Value = fromapp
            DepartmentsSqlParameter = New SqlParameter("@DEPTS", SqlDbType.VarChar, 8000)
            IncludeUnassignedSqlParameter.Value = IncludeUnassigned
            CPIDSqlParameter.Value = cpid

            If showHolidays = True And showAppointments = True Then

                TypeSqlParameter.Value = ""

            ElseIf showHolidays = True And showAppointments = False Then

                TypeSqlParameter.Value = "H"

            ElseIf showHolidays = False And showAppointments = True Then

                TypeSqlParameter.Value = "A"

            Else

                TypeSqlParameter.Value = "N"

            End If

            DepartmentsSqlParameter.Value = DEPTS

            If IsClientPortal Then

                TaskParameters = {UserIDSqlParameter, EmployeeCodeSqlParameter, OfficeCodeSqlParameter, ClientCodeSqlParameter,
                              DivisionCodeSqlParameter, ProductCodeSqlParameter, JobNumberSqlParameter, JobComponentSqlParameter,
                              RolesSqlParameter, StartDateSqlParameter, EndDateSqlParameter, TaskStatusSqlParameter,
                              ExcludeTempCompleteSqlParameter, MilestonesOnlySqlParameter, ManagerSqlParameter, GroupLevelSqlParameter, DepartmentsSqlParameter, IncludeUnassignedSqlParameter, CPIDSqlParameter}

            Else

                TaskParameters = {UserIDSqlParameter, EmployeeCodeSqlParameter, OfficeCodeSqlParameter, ClientCodeSqlParameter,
                              DivisionCodeSqlParameter, ProductCodeSqlParameter, JobNumberSqlParameter, JobComponentSqlParameter,
                              RolesSqlParameter, StartDateSqlParameter, EndDateSqlParameter, TaskStatusSqlParameter,
                              ExcludeTempCompleteSqlParameter, MilestonesOnlySqlParameter, ManagerSqlParameter, GroupLevelSqlParameter, DepartmentsSqlParameter, IncludeUnassignedSqlParameter}

            End If



            AssignmentsParameters = {UserIDSqlParameter, EmployeeCodeSqlParameter, OfficeCodeSqlParameter, ClientCodeSqlParameter,
                              DivisionCodeSqlParameter, ProductCodeSqlParameter, JobNumberSqlParameter, JobComponentSqlParameter,
                              RolesSqlParameter, StartDateSqlParameter, EndDateSqlParameter, TaskStatusSqlParameter,
                              ExcludeTempCompleteSqlParameter, MilestonesOnlySqlParameter, ManagerSqlParameter, GroupLevelSqlParameter, DepartmentsSqlParameter, IncludeUnassignedSqlParameter}

            NonTaskParameters = {StartDateSqlParameter, EndDateSqlParameter, EmployeeCodeSqlParameter, TypeSqlParameter,
                                 UserIDSqlParameter, RolesSqlParameter, DepartmentsSqlParameter, ClientCodeSqlParameter,
                                 DivisionCodeSqlParameter, ProductCodeSqlParameter, JobNumberSqlParameter, JobComponentSqlParameter,
                                 LevelSqlParameter, GroupingSqlParameter, FromAppSqlParameter}

            EventParameters = {UserIDSqlParameter, OfficeCodeSqlParameter, ClientCodeSqlParameter, DivisionCodeSqlParameter,
                               ProductCodeSqlParameter, JobNumberSqlParameter, JobComponentSqlParameter, StartDateSqlParameter,
                               EndDateSqlParameter, GroupLevelSqlParameter}

            Try

                If IsClientPortal Then

                    TasksDataTable = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_cp_calendar_task_month_rpt", "dt", TaskParameters)

                Else

                    TasksDataTable = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_calendar_task_month_rpt", "dt", TaskParameters)
                    AssignmentssDataTable = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_calendar_assign_month_rpt", "dt", AssignmentsParameters)
                    NonTaskDataReader = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_nontask_GetTasks", NonTaskParameters)
                    EventsDataReader = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_calendar_events", EventParameters)
                    EventTasksDataReader = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_calendar_event_tasks", EventParameters)

                End If

            Catch
                Err.Raise(Err.Number, "Class:cTaskCal Routine:GetTaskCalendar", Err.Description)
            End Try

            If fromapp = "PSMV" Then

                If Not String.IsNullOrWhiteSpace(jobcomps) Then

                    JobCompArray = jobcomps.Split("|")

                    If JobCompArray.Length > 0 Then

                        For CompIdx As Integer = 0 To JobCompArray.Length - 1

                            If Not String.IsNullOrWhiteSpace(JobCompArray(CompIdx).Split(",")(0)) Then

                                If String.IsNullOrWhiteSpace(FilterString) Then

                                    FilterString = "(JobNum = " & CInt(JobCompArray(CompIdx).Split(",")(0)) & " AND CompNum = " & CInt(JobCompArray(CompIdx).Split(",")(1)) & ")"

                                Else

                                    FilterString &= " OR (JobNum = " & CInt(JobCompArray(CompIdx).Split(",")(0)) & " AND CompNum = " & CInt(JobCompArray(CompIdx).Split(",")(1)) & ")"

                                End If

                            End If

                        Next

                    End If

                End If

            End If

            With New DataView(TasksDataTable)

                If Not String.IsNullOrWhiteSpace(FilterString) Then

                    .RowFilter = FilterString

                End If

                FilteredTasksDataTable = .ToTable

            End With

            DescriptionList = New Generic.List(Of String)

            If showTasks Then

                For Each TaskDataRow In FilteredTasksDataTable.Rows.OfType(Of System.Data.DataRow)

                    DescriptionList.Clear()

                    CalendarItem = New AdvantageFramework.Reporting.Classes.CalendarReport.CalendarItem

                    CalendarItem.JobNumber = TaskDataRow("JobNum")
                    CalendarItem.JobComponentNumber = TaskDataRow("CompNum")

                    CalendarItem.StartDate = TaskDataRow("StartDate")
                    CalendarItem.EndDate = TaskDataRow("RevisedDate")

                    If tClientCode Then

                        DescriptionList.Add(TaskDataRow("CCode"))

                    End If

                    If tClientDesc Then

                        DescriptionList.Add(TaskDataRow("CL_NAME"))

                    End If

                    If tDivisionCode Then

                        DescriptionList.Add(TaskDataRow("DCode"))

                    End If

                    If tDivisionDesc Then

                        DescriptionList.Add(TaskDataRow("DIV_NAME"))

                    End If

                    If tProductCode Then

                        DescriptionList.Add(TaskDataRow("PCode"))

                    End If

                    If tProductDesc Then

                        DescriptionList.Add(TaskDataRow("PRD_DESCRIPTION"))

                    End If

                    If tJobNumber Then

                        DescriptionList.Add(TaskDataRow("JobNum"))

                    End If

                    If tJobDesc Then

                        DescriptionList.Add(TaskDataRow("JobDesc"))

                    End If

                    If tCompNumber Then

                        DescriptionList.Add(TaskDataRow("CompNum"))

                    End If

                    If tCompDesc Then

                        DescriptionList.Add(TaskDataRow("CompDesc"))

                    End If

                    If tTaskCode = True Then

                        DescriptionList.Add(TaskDataRow("TRF_CODE"))

                    End If

                    If tTaskDesc Then

                        DescriptionList.Add(TaskDataRow("Task"))

                    End If

                    If tcal_empcodedispl Then

                        If ShowHoursAllowed Then

                            DescriptionList.Add(TaskDataRow("EmployeeCodeAndHours"))

                        Else

                            DescriptionList.Add(TaskDataRow("empcodedispl"))

                        End If

                    End If

                    If tcal_empdescdispl Then

                        If ShowHoursAllowed Then

                            DescriptionList.Add(TaskDataRow("EmployeeNameAndHours"))

                        Else

                            DescriptionList.Add(TaskDataRow("empdescdispl"))

                        End If

                    End If

                    DescriptionList = DescriptionList.Where(Function(d) Not String.IsNullOrWhiteSpace(d)).ToList

                    CalendarItem.Description = String.Join(" | ", DescriptionList)

                    CalendarWorksheet.CalendarItems.Add(CalendarItem)

                Next

            End If

            If showAssignments And IsClientPortal = False Then

                For Each TaskDataRow In AssignmentssDataTable.Rows.OfType(Of System.Data.DataRow)

                    DescriptionList.Clear()

                    CalendarItem = New AdvantageFramework.Reporting.Classes.CalendarReport.CalendarItem

                    If IsDBNull(TaskDataRow("JobNum")) = False Then
                        CalendarItem.JobNumber = TaskDataRow("JobNum")
                    End If
                    If IsDBNull(TaskDataRow("CompNum")) = False Then
                        CalendarItem.JobComponentNumber = TaskDataRow("CompNum")
                    End If

                    CalendarItem.StartDate = TaskDataRow("StartDate")
                    CalendarItem.EndDate = TaskDataRow("RevisedDate")

                    If tClientCode Then

                        If IsDBNull(TaskDataRow("CCode")) = False Then
                            DescriptionList.Add(TaskDataRow("CCode"))
                        End If

                    End If

                    If tClientDesc Then

                        DescriptionList.Add(TaskDataRow("CL_NAME"))

                    End If

                    If tDivisionCode Then

                        If IsDBNull(TaskDataRow("DCode")) = False Then
                            DescriptionList.Add(TaskDataRow("DCode"))
                        End If

                    End If

                    If tDivisionDesc Then

                        DescriptionList.Add(TaskDataRow("DIV_NAME"))

                    End If

                    If tProductCode Then

                        If IsDBNull(TaskDataRow("PCode")) = False Then
                            DescriptionList.Add(TaskDataRow("PCode"))
                        End If

                    End If

                    If tProductDesc Then

                        DescriptionList.Add(TaskDataRow("PRD_DESCRIPTION"))

                    End If

                    If tJobNumber Then

                        If IsDBNull(TaskDataRow("JobNum")) = False Then
                            DescriptionList.Add(TaskDataRow("JobNum"))
                        End If

                    End If

                    If tJobDesc Then

                        If IsDBNull(TaskDataRow("JobDesc")) = False Then
                            DescriptionList.Add(TaskDataRow("JobDesc"))
                        End If

                    End If

                    If tCompNumber Then

                        If IsDBNull(TaskDataRow("CompNum")) = False Then
                            DescriptionList.Add(TaskDataRow("CompNum"))
                        End If

                    End If

                    If tCompDesc Then

                        If IsDBNull(TaskDataRow("CompDesc")) = False Then
                            DescriptionList.Add(TaskDataRow("CompDesc"))
                        End If

                    End If

                    If tTaskCode = True Then

                        DescriptionList.Add(TaskDataRow("TRF_CODE"))

                    End If

                    If tTaskDesc Then

                        DescriptionList.Add(TaskDataRow("Task"))

                    End If

                    If tcal_empcodedispl Then

                        If ShowHoursAllowed Then

                            If IsDBNull(TaskDataRow("EmployeeCodeAndHours")) = False Then
                                DescriptionList.Add(TaskDataRow("EmployeeCodeAndHours"))
                            End If

                        Else

                            DescriptionList.Add(TaskDataRow("empcodedispl"))

                        End If

                    End If

                    If tcal_empdescdispl Then

                        If ShowHoursAllowed Then

                            DescriptionList.Add(TaskDataRow("EmployeeNameAndHours"))

                        Else

                            DescriptionList.Add(TaskDataRow("empdescdispl"))

                        End If

                    End If

                    DescriptionList = DescriptionList.Where(Function(d) Not String.IsNullOrWhiteSpace(d)).ToList

                    CalendarItem.Description = String.Join(" | ", DescriptionList)

                    CalendarWorksheet.CalendarItems.Add(CalendarItem)

                Next

            End If

            If showAppointments = True OrElse showHolidays = True And IsClientPortal = False Then

                Do While NonTaskDataReader.Read

                    CalendarItem = New AdvantageFramework.Reporting.Classes.CalendarReport.CalendarItem

                    EmployeesString = ""

                    DescriptionList.Clear()

                    NonTaskDataset = oCalendar.GetNonTaskDataDS(NonTaskDataReader("NON_TASK_ID"), UserID)

                    If {"A", "C", "M", "TD", "EL"}.Contains(NonTaskDataReader("TYPE").ToString) Then

                        If haEmployeeCode Then

                            If NonTaskDataset.Tables(1).Rows.Count > 0 Then

                                EmployeesString += String.Join(", ", NonTaskDataset.Tables(1).Rows.OfType(Of System.Data.DataRow).Select(Function(r) r("EMP_CODE")).ToList)

                            End If

                            DescriptionList.Add(TaskString & EmployeesString)

                        End If

                        If haEmployeeName Then

                            If NonTaskDataset.Tables(1).Rows.Count > 0 Then

                                EmployeesString += String.Join(", ", NonTaskDataset.Tables(1).Rows.OfType(Of System.Data.DataRow).Select(Function(r) r("EMP_NAME")).ToList)

                            End If

                            DescriptionList.Add(TaskString & EmployeesString)

                        End If

                    End If

                    If haType Then

                        DescriptionList.Add(NonTaskDataReader("TYPE"))

                    End If

                    If haSubject Then

                        DescriptionList.Add(NonTaskDataReader("NON_TASK_DESC"))

                    End If

                    If haTimes AndAlso ({"A", "C", "M", "TD", "EL"}.Contains(NonTaskDataReader.GetString(1))) AndAlso NonTaskDataReader.GetInt32(9) = 0 Then

                        DescriptionList.Add(CDate(NonTaskDataReader("START_TIME")).ToShortTimeString & " - " & CDate(NonTaskDataReader("END_TIME")).ToShortTimeString)

                    End If

                    If haHours AndAlso ({"A", "C", "M", "TD", "EL"}.Contains(NonTaskDataReader.GetString(1))) Then

                        DescriptionList.Add(CDec(NonTaskDataReader("HOURS")))

                    End If

                    If haTimeCat Then

                        DescriptionList.Add(NonTaskDataReader.GetString(6))

                    End If

                    DescriptionList = DescriptionList.Where(Function(d) Not String.IsNullOrWhiteSpace(d)).ToList

                    CalendarItem.StartDate = NonTaskDataReader("START_DATE")
                    CalendarItem.EndDate = NonTaskDataReader("END_DATE")
                    CalendarItem.Description = String.Join(" | ", DescriptionList)

                    If IsDBNull(NonTaskDataReader("JOB_NUMBER")) AndAlso Not IsDBNull(NonTaskDataReader("JOB_COMPONENT_NBR")) Then

                        CalendarItem.JobNumber = NonTaskDataReader("JOB_NUMBER")
                        CalendarItem.JobNumber = NonTaskDataReader("JOB_COMPONENT_NBR")

                    End If

                    CalendarWorksheet.CalendarItems.Add(CalendarItem)

                Loop

            End If

            If showEvents Then

                Do While EventsDataReader.Read

                    DescriptionList.Clear()

                    CalendarItem = New AdvantageFramework.Reporting.Classes.CalendarReport.CalendarItem

                    DescriptionList.Add(EventsDataReader("CCode"))
                    DescriptionList.Add(EventsDataReader.GetString(0))
                    DescriptionList.Add(CDate(EventsDataReader("START_TIME")).ToShortTimeString)
                    DescriptionList.Add(CDate(EventsDataReader("END_TIME")).ToShortTimeString)

                    DescriptionList = DescriptionList.Where(Function(d) Not String.IsNullOrWhiteSpace(d)).ToList

                    If Not IsDBNull(EventsDataReader("JobNum")) AndAlso Not IsDBNull(EventsDataReader("CompNum")) Then

                        CalendarItem.JobNumber = EventsDataReader("JobNum")
                        CalendarItem.JobComponentNumber = EventsDataReader("CompNum")

                    End If

                    CalendarItem.StartDate = CDate(EventsDataReader("START_TIME"))
                    CalendarItem.EndDate = CDate(EventsDataReader("END_TIME"))
                    CalendarItem.Description = String.Join(" | ", DescriptionList)

                    CalendarWorksheet.CalendarItems.Add(CalendarItem)

                Loop

            End If

            If showEventTasks Then

                Do While EventTasksDataReader.Read

                    DescriptionList.Clear()

                    CalendarItem = New AdvantageFramework.Reporting.Classes.CalendarReport.CalendarItem

                    DescriptionList.Add(EventTasksDataReader.GetString(0))
                    DescriptionList.Add(EventTasksDataReader("TASK_CODE"))
                    DescriptionList.Add(CDate(EventTasksDataReader("START_TIME")).ToShortTimeString)
                    DescriptionList.Add(CDate(EventTasksDataReader("END_TIME")).ToShortTimeString)

                    DescriptionList = DescriptionList.Where(Function(d) Not String.IsNullOrWhiteSpace(d)).ToList

                    If Not IsDBNull(EventTasksDataReader("JobNum")) AndAlso Not IsDBNull(EventTasksDataReader("CompNum")) Then

                        CalendarItem.JobNumber = EventTasksDataReader("JobNum")
                        CalendarItem.JobComponentNumber = EventTasksDataReader("CompNum")

                    End If

                    CalendarItem.StartDate = CDate(EventTasksDataReader("START_TIME"))
                    CalendarItem.EndDate = CDate(EventTasksDataReader("END_TIME"))
                    CalendarItem.Description = String.Join(" | ", DescriptionList)

                    CalendarWorksheet.CalendarItems.Add(CalendarItem)

                Loop

            End If

            Return CalendarReport

        End Function

        Public Function GetNonTaskData(ByVal TaskID As Integer, ByVal UserId As String) As SqlDataReader

            Dim dr As SqlClient.SqlDataReader

            Dim arP(2) As SqlParameter

            Dim pUserId As New SqlParameter("@USER_ID", SqlDbType.VarChar, 100)
            pUserId.Value = UserId ' HttpContext.Current.Session("UserCode")
            arP(0) = pUserId

            Dim parameterTaskID As New SqlParameter("@TaskID", SqlDbType.Int, 10)
            parameterTaskID.Value = TaskID
            arP(1) = parameterTaskID

            Try
                dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_nontask_GetTaskData", arP)
            Catch
                Err.Raise(Err.Number, "Class:cTaskCal Routine:GetNonTaskDay", Err.Description)
            End Try


            Return dr

        End Function
        Public Function GetNonTaskDataDS(ByVal TaskID As Integer, ByVal UserId As String) As DataSet

            Dim dr As DataSet

            Dim arP(2) As SqlParameter

            Dim pUserId As New SqlParameter("@USER_ID", SqlDbType.VarChar, 100)
            pUserId.Value = UserId ' HttpContext.Current.Session("UserCode")
            arP(0) = pUserId

            Dim parameterTaskID As New SqlParameter("@TaskID", SqlDbType.Int, 10)
            parameterTaskID.Value = TaskID
            arP(1) = parameterTaskID

            Try
                dr = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_nontask_GetTaskData", arP)
            Catch
                Err.Raise(Err.Number, "Class:cTaskCal Routine:GetNonTaskDay", Err.Description)
            End Try


            Return dr

        End Function
        Public Function GetNonTaskAvailableEmps(ByVal includeall As Boolean, ByVal empcode As String, ByVal role As String, ByVal alertgroup As String, Optional ByVal TaskNo As Integer = 0, Optional ByVal usercode As String = "") As SqlDataReader
            Dim dr As SqlDataReader
            Dim arParams(6) As SqlParameter
            Dim paramIncludeAll As New SqlParameter("@IncludeAll", SqlDbType.Int)
            If includeall = False Then
                paramIncludeAll.Value = 0
            Else
                paramIncludeAll.Value = 1
            End If
            arParams(0) = paramIncludeAll

            Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
            parameterEmpCode.Value = empcode
            arParams(1) = parameterEmpCode

            Dim pRoleCode As New SqlParameter("@ROLE_CODE", SqlDbType.VarChar, 6)
            pRoleCode.Value = role
            arParams(2) = pRoleCode

            Dim pAlertGrpCode As New SqlParameter("@EMAIL_GR_CODE", SqlDbType.VarChar, 50)
            pAlertGrpCode.Value = alertgroup
            arParams(3) = pAlertGrpCode

            Dim pTaskNo As New SqlParameter("@TaskNo", SqlDbType.Int)
            pTaskNo.Value = TaskNo
            arParams(4) = pTaskNo

            Dim pUserCode As New SqlParameter("@USER_CODE", SqlDbType.VarChar)
            pUserCode.Value = usercode
            arParams(5) = pUserCode

            Try
                dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_nontask_GetAvailableEmps", arParams)
            Catch
                Err.Raise(Err.Number, "Class:cEmployee Routine:GetEmailRecipientsInternal", Err.Description)
            End Try

            Return dr

        End Function

        Public Function GetMediaCalendar(ByVal Month As Integer,
                                        ByVal Year As Integer,
                                        ByVal UserID As String,
                                        Optional ByVal Client As String = "",
                                        Optional ByVal Division As String = "",
                                        Optional ByVal Product As String = "",
                                        Optional ByVal MediaType As String = "",
                                        Optional ByVal Campaign As String = "",
                                        Optional ByVal ClientPO As String = "",
                                        Optional ByVal Vendor As String = "",
                                        Optional ByVal Buyer As String = "",
                                        Optional ByVal Magazine As Boolean = False,
                                        Optional ByVal NewsPaper As Boolean = False,
                                        Optional ByVal Internet As Boolean = False,
                                        Optional ByVal OutOfHome As Boolean = False,
                                        Optional ByVal Television As Boolean = False,
                                        Optional ByVal Radio As Boolean = False,
                                        Optional ByVal AcceptedOrdersOnly As Boolean = False,
                                        Optional ByVal CancelledOrders As Boolean = False,
                                        Optional ByVal ClientCode As Boolean = False,
                                        Optional ByVal DivisionCode As Boolean = False,
                                        Optional ByVal ProductCode As Boolean = False,
                                        Optional ByVal Type As Boolean = False,
                                        Optional ByVal MType As Boolean = False,
                                        Optional ByVal InsertionLine As Boolean = False,
                                        Optional ByVal VendorCode As Boolean = False,
                                        Optional ByVal VendorName As Boolean = False,
                                        Optional ByVal JobComp As Boolean = False,
                                        Optional ByVal CampaignCode As Boolean = False,
                                        Optional ByVal CampaignName As Boolean = False,
                                        Optional ByVal MarketCode As Boolean = False,
                                        Optional ByVal MarketName As Boolean = False,
                                        Optional ByVal AdSizeLength As Boolean = False,
                                        Optional ByVal HeadlineProg As Boolean = False,
                                        Optional ByVal ExtMatDate As Boolean = False,
                                        Optional ByVal CloseDate As Boolean = False,
                                        Optional ByVal ExtCloseDate As Boolean = False,
                                        Optional ByVal RunDate As Boolean = False,
                                        Optional ByVal BillingAmount As Boolean = False,
                                        Optional ByVal Spots As Boolean = False,
                                        Optional ByVal MatDueDate As Boolean = False,
                                        Optional ByVal ExtMatDueDate As Boolean = False,
                                        Optional ByVal CloseDate2 As Boolean = False,
                                        Optional ByVal ExtCloseDate2 As Boolean = False,
                                        Optional ByVal RunInsertionDate As Boolean = False,
                                        Optional ByVal DisplayFlight As Boolean = False,
                                        Optional ByVal Print As Boolean = False) As Month

            Dim intDaysInMonth As Integer
            Dim ThisMonth As Month
            Dim ThisWeek As Week
            Dim ThisDay As Date
            Dim ThisDayLink As String
            Dim dr As SqlClient.SqlDataReader
            Dim I As Integer
            Dim arTasks(31) As String
            Dim strShow As String
            Dim arParams(26) As SqlParameter
            Dim strCompleted As String
            Dim taskLink As String
            Dim printCal As Boolean

            Dim parameterMagazine As New SqlParameter("@MagazineInc", SqlDbType.Char, 1)
            If Magazine = True Then
                parameterMagazine.Value = "Y"
            Else
                parameterMagazine.Value = "N"
            End If
            arParams(0) = parameterMagazine

            Dim parameterNewspaper As New SqlParameter("@NewspaperInc", SqlDbType.Char, 1)
            If NewsPaper = True Then
                parameterNewspaper.Value = "Y"
            Else
                parameterNewspaper.Value = "N"
            End If
            arParams(1) = parameterNewspaper

            Dim parameterInternet As New SqlParameter("@InternetInc", SqlDbType.Char, 1)
            If Internet = True Then
                parameterInternet.Value = "Y"
            Else
                parameterInternet.Value = "N"
            End If
            arParams(2) = parameterInternet

            Dim parameterOutOfHome As New SqlParameter("@OutOfHomeInc", SqlDbType.Char, 1)
            If OutOfHome = True Then
                parameterOutOfHome.Value = "Y"
            Else
                parameterOutOfHome.Value = "N"
            End If
            arParams(3) = parameterOutOfHome

            Dim parameterTelevision As New SqlParameter("@TelevisionInc", SqlDbType.Char, 1)
            If Television = True Then
                parameterTelevision.Value = "Y"
            Else
                parameterTelevision.Value = "N"
            End If
            arParams(4) = parameterTelevision

            Dim parameterRadio As New SqlParameter("@RadioInc", SqlDbType.Char, 1)
            If Radio = True Then
                parameterRadio.Value = "Y"
            Else
                parameterRadio.Value = "N"
            End If
            arParams(5) = parameterRadio

            Dim parameterAcceptedOrdersOnly As New SqlParameter("@AcceptedOrdersOnly", SqlDbType.Char, 1)
            If AcceptedOrdersOnly = True Then
                parameterAcceptedOrdersOnly.Value = "Y"
            Else
                parameterAcceptedOrdersOnly.Value = "N"
            End If
            arParams(6) = parameterAcceptedOrdersOnly

            Dim parameterClient As New SqlParameter("@ClientCode", SqlDbType.VarChar, 10)
            parameterClient.Value = Client
            arParams(7) = parameterClient

            Dim parameterDivision As New SqlParameter("@DivCode", SqlDbType.VarChar, 10)
            parameterDivision.Value = Division
            arParams(8) = parameterDivision

            Dim parameterProduct As New SqlParameter("@ProdCode", SqlDbType.VarChar, 10)
            parameterProduct.Value = Product
            arParams(9) = parameterProduct

            Dim parameterMediaType As New SqlParameter("@MediaType", SqlDbType.VarChar, 10)
            parameterMediaType.Value = MediaType
            arParams(10) = parameterMediaType

            Dim parameterCampaign As New SqlParameter("@Campaign", SqlDbType.VarChar, 100)
            parameterCampaign.Value = Campaign
            arParams(11) = parameterCampaign

            Dim parameterClientPO As New SqlParameter("@ClientPO", SqlDbType.VarChar, 100)
            parameterClientPO.Value = ClientPO
            arParams(12) = parameterClientPO

            Dim parameterVendor As New SqlParameter("@VendorID", SqlDbType.VarChar, 100)
            parameterVendor.Value = Vendor
            arParams(13) = parameterVendor

            Dim parameterBuyer As New SqlParameter("@BuyerID", SqlDbType.VarChar, 100)
            parameterBuyer.Value = Buyer
            arParams(14) = parameterBuyer

            Dim parameterStartDate As New SqlParameter("@StartDate", SqlDbType.VarChar, 10)
            parameterStartDate.Value = CStr(Month) & "/" & CStr(1) & "/" & CStr(Year)
            arParams(15) = parameterStartDate

            intDaysInMonth = Date.DaysInMonth(Year, Month)
            Dim parameterEndDate As New SqlParameter("@EndDate", SqlDbType.VarChar, 10)
            parameterEndDate.Value = CStr(Month) & "/" & CStr(intDaysInMonth) & "/" & CStr(Year)
            arParams(16) = parameterEndDate

            Dim parameterMatDueDate As New SqlParameter("@MatDueDate", SqlDbType.Char, 1)
            If MatDueDate = True Then
                parameterMatDueDate.Value = "Y"
            Else
                parameterMatDueDate.Value = "N"
            End If
            arParams(17) = parameterMatDueDate

            Dim parameterExtMatDueDate As New SqlParameter("@ExtMatDueDate", SqlDbType.Char, 1)
            If ExtMatDueDate = True Then
                parameterExtMatDueDate.Value = "Y"
            Else
                parameterExtMatDueDate.Value = "N"
            End If
            arParams(18) = parameterExtMatDueDate

            Dim parameterCloseDate As New SqlParameter("@CloseDate", SqlDbType.Char, 1)
            If CloseDate2 = True Then
                parameterCloseDate.Value = "Y"
            Else
                parameterCloseDate.Value = "N"
            End If
            arParams(19) = parameterCloseDate

            Dim parameterExtCloseDate As New SqlParameter("@ExtCloseDate", SqlDbType.Char, 1)
            If ExtCloseDate2 = True Then
                parameterExtCloseDate.Value = "Y"
            Else
                parameterExtCloseDate.Value = "N"
            End If
            arParams(20) = parameterExtCloseDate

            Dim parameterRunInsertionDate As New SqlParameter("@RunInsertionDate", SqlDbType.Char, 1)
            If RunInsertionDate = True Then
                parameterRunInsertionDate.Value = "Y"
            Else
                parameterRunInsertionDate.Value = "N"
            End If
            arParams(21) = parameterRunInsertionDate

            Dim parameterMonth As New SqlParameter("@MediaMonth", SqlDbType.VarChar, 6)
            parameterMonth.Value = getMonthName(Month)
            arParams(22) = parameterMonth

            Dim parameterYear As New SqlParameter("@MediaYear", SqlDbType.Int, 6)
            parameterYear.Value = Year
            arParams(23) = parameterYear

            Dim parameterCancelledOrders As New SqlParameter("@LineCancelled", SqlDbType.Char, 1)
            If CancelledOrders = True Then
                parameterCancelledOrders.Value = "Y"
            Else
                parameterCancelledOrders.Value = "N"
            End If
            arParams(24) = parameterCancelledOrders

            Dim parameterDebug As New SqlParameter("@debug", SqlDbType.Bit, 6)
            parameterDebug.Value = 0
            arParams(25) = parameterDebug

            Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
            parameterUserID.Value = UserID
            arParams(26) = parameterUserID

            Try
                dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_calendar_GetMediaData", arParams)
            Catch
                Err.Raise(Err.Number, "Class:cTaskCal Routine:GetMediaCalendar", Err.Description)
            End Try

            'Initial Array
            For I = 1 To 31
                arTasks(I) = ""
            Next

            Do While dr.Read
                If ClientCode = True And dr.GetString(6) <> "" Then
                    strShow = strShow & dr.GetString(6) & "|"
                End If
                If DivisionCode = True And dr.GetString(7) <> "" Then
                    strShow = strShow & dr.GetString(7) & "|"
                End If
                If ProductCode = True And dr.GetString(8) <> "" Then
                    strShow = strShow & dr.GetString(8) & "|"
                End If
                If Type = True And dr.GetString(0) <> "" Then
                    strShow = strShow & dr.GetString(0) & "|"
                End If
                If MType = True And dr.GetString(5) <> "" Then
                    strShow = strShow & dr.GetString(5) & "|"
                End If
                If InsertionLine = True Then
                    strShow = strShow & Convert.ToString(dr.GetInt32(3)) & "-" & Convert.ToString(dr.GetInt32(19)) & "|"
                End If
                If VendorCode = True And dr.GetString(12) <> "" Then
                    strShow = strShow & dr.GetString(12) & "|"
                End If
                If VendorName = True And dr.GetString(13) <> "" Then
                    strShow = strShow & dr.GetString(13) & "|"
                End If
                If JobComp = True Then
                    strShow = strShow & dr.GetInt32(48) & "-" & dr.GetInt16(49) & "|"
                End If
                If CampaignCode = True And dr.GetString(10) <> "" Then
                    strShow = strShow & dr.GetString(10) & "|"
                End If
                If CampaignName = True And dr.GetString(11) <> "" Then
                    strShow = strShow & dr.GetString(11) & "|"
                End If
                If MarketCode = True And dr.GetString(16) <> "" Then
                    strShow = strShow & dr.GetString(16) & "|"
                End If
                If MarketName = True And dr.GetString(17) <> "" Then
                    strShow = strShow & dr.GetString(17) & "|"
                End If
                If AdSizeLength = True And dr.GetString(0) = "R" And dr.GetString(43) <> "" Or AdSizeLength = True And dr.GetString(0) = "T" And dr.GetString(43) <> "" Then
                    strShow = strShow & dr.GetString(43) & "|"
                ElseIf AdSizeLength = True And dr.GetString(30) <> "" Then
                    strShow = strShow & dr.GetString(30) & "|"
                End If
                If HeadlineProg = True And dr.GetString(0) = "R" And dr.GetString(45) <> "" Or HeadlineProg = True And dr.GetString(0) = "T" And dr.GetString(45) <> "" Then
                    strShow = strShow & dr.GetString(45) & "|"
                ElseIf HeadlineProg = True And dr.GetString(35) <> "" Then
                    strShow = strShow & dr.GetString(35) & "|"
                End If
                If ExtMatDate = True And dr.GetDateTime(29).Date.ToShortDateString <> "1/1/1900" Then
                    strShow = strShow & dr.GetDateTime(29).Date.Month.ToString() & "/" & dr.GetDateTime(29).Date.Day.ToString() & "/" & dr.GetDateTime(29).Date.Year.ToString.Substring(2) & "|"
                End If
                If CloseDate = True And dr.GetDateTime(26).Date.ToShortDateString <> "1/1/1900" Then
                    strShow = strShow & dr.GetDateTime(26).Date.Month.ToString() & "/" & dr.GetDateTime(26).Date.Day.ToString() & "/" & dr.GetDateTime(26).Date.Year.ToString.Substring(2) & "|"
                End If
                If ExtCloseDate = True And dr.GetDateTime(28).Date.ToShortDateString <> "1/1/1900" Then
                    strShow = strShow & dr.GetDateTime(28).Date.Month.ToString() & "/" & dr.GetDateTime(28).Date.Day.ToString() & "/" & dr.GetDateTime(28).Date.Year.ToString.Substring(2) & "|"
                End If
                If RunDate = True And dr.GetString(0) = "R" And dr.GetString(21) <> "" Or RunDate = True And dr.GetString(0) = "T" And dr.GetString(21) <> "" Then
                    strShow = strShow & dr.GetString(21) & "|"
                ElseIf RunDate = True And dr.GetDateTime(22).Date.ToShortDateString <> "1/1/1900" Then
                    strShow = strShow & dr.GetDateTime(22).Date.Month.ToString() & "/" & dr.GetDateTime(22).Date.Day.ToString() & "/" & dr.GetDateTime(22).Date.Year.ToString.Substring(2) & "|"
                End If
                If BillingAmount = True Then
                    strShow = strShow & dr.GetString(56) & "|"
                End If
                If Spots = True And dr.GetString(0) = "R" Or Spots = True And dr.GetString(0) = "T" Then
                    strShow = strShow & dr.GetString(57) & "|"
                End If
                If MatDueDate = True Or ExtMatDueDate = True Or CloseDate2 = True Or ExtCloseDate2 = True Then
                    Dim day As Integer
                    If MatDueDate = True Then
                        day = dr.GetDateTime(27).Day
                    End If
                    If ExtMatDueDate = True Then
                        day = dr.GetDateTime(29).Day
                    End If
                    If CloseDate2 = True Then
                        day = dr.GetDateTime(26).Day
                    End If
                    If ExtCloseDate2 = True Then
                        day = dr.GetDateTime(28).Day
                    End If
                    If strShow.Length > 0 Then
                        strShow = strShow.Substring(0, strShow.Length - 1)
                    End If
                    'If strShow.Length > 15 Then
                    '    arTasks(day) = arTasks(day) & "<span class='" & strCompleted & "'>" & strShow.Substring(0, 16) & vbCrLf & "&nbsp;" & strShow.Substring(16, 16) & vbCrLf & "&nbsp;" & strShow.Substring(32) & "</span>" & "<br />"
                    'Else
                    'arTasks(day) = arTasks(day) & "<span class='" & strCompleted & "'>" & strShow & "</span>" & "<br />"
                    If dr.GetString(0) = "M" And dr.GetInt32(57) = 1 Then
                        arTasks(day) = arTasks(day) & "<span class='" & strCompleted & "' style='color: Maroon;'><img border=""0"" height=""16"" src=""images/book_open2-trans.png"" width=""16"" />" & strShow & "</span>" & "<br />"
                    ElseIf dr.GetString(0) = "M" And dr.GetDateTime(62) <> "1/1/1900" Then
                        arTasks(day) = arTasks(day) & "<span class='calendarPending'><img border=""0"" height=""16"" src=""images/book_open2-trans.png"" width=""16"" />" & strShow & "</span>" & "<br />"
                    ElseIf dr.GetString(0) = "M" Then
                        arTasks(day) = arTasks(day) & "<span class='" & strCompleted & "'><img border=""0"" height=""16"" src=""images/book_open2-trans.png"" width=""16"" />" & strShow & "</span>" & "<br />"
                    End If
                    If dr.GetString(0) = "N" And dr.GetInt32(57) = 1 Then
                        arTasks(day) = arTasks(day) & "<span class='" & strCompleted & "' style='color: Maroon;'><img border=""0"" height=""16"" src=""images/newspaper.png"" width=""16"" />" & strShow & "</span>" & "<br />"
                    ElseIf dr.GetString(0) = "N" And dr.GetDateTime(62) <> "1/1/1900" Then
                        arTasks(day) = arTasks(day) & "<span class='calendarPending'><img border=""0"" height=""16"" src=""images/newspaper.png"" width=""16"" />" & strShow & "</span>" & "<br />"
                    ElseIf dr.GetString(0) = "N" Then
                        arTasks(day) = arTasks(day) & "<span class='" & strCompleted & "'><img border=""0"" height=""16"" src=""images/newspaper.png"" width=""16"" />" & strShow & "</span>" & "<br />"
                    End If
                    If dr.GetString(0) = "I" And dr.GetInt32(57) = 1 Then
                        arTasks(day) = arTasks(day) & "<span class='" & strCompleted & "' style='color: Maroon;'><img border=""0"" height=""16"" src=""images/monitor.png"" width=""16"" />" & strShow & "</span>" & "<br />"
                    ElseIf dr.GetString(0) = "I" And dr.GetDateTime(62) <> "1/1/1900" Then
                        arTasks(day) = arTasks(day) & "<span class='calendarPending'><img border=""0"" height=""16"" src=""images/monitor.png"" width=""16"" />" & strShow & "</span>" & "<br />"
                    ElseIf dr.GetString(0) = "I" Then
                        arTasks(day) = arTasks(day) & "<span class='" & strCompleted & "'><img border=""0"" height=""16"" src=""images/monitor.png"" width=""16"" />" & strShow & "</span>" & "<br />"
                    End If
                    If dr.GetString(0) = "O" And dr.GetInt32(57) = 1 Then
                        arTasks(day) = arTasks(day) & "<span class='" & strCompleted & "' style='color: Maroon;'><img border=""0"" height=""16"" src=""images/house2.png"" width=""16"" />" & strShow & "</span>" & "<br />"
                    ElseIf dr.GetString(0) = "O" And dr.GetDateTime(62) <> "1/1/1900" Then
                        arTasks(day) = arTasks(day) & "<span class='calendarPending'><img border=""0"" height=""16"" src=""images/house2.png"" width=""16"" />" & strShow & "</span>" & "<br />"
                    ElseIf dr.GetString(0) = "O" Then
                        arTasks(day) = arTasks(day) & "<span class='" & strCompleted & "'><img border=""0"" height=""16"" src=""images/house2.png"" width=""16"" />" & strShow & "</span>" & "<br />"
                    End If
                    If dr.GetString(0) = "R" And dr.GetInt32(57) = 1 Then
                        arTasks(day) = arTasks(day) & "<span class='" & strCompleted & "' style='color: Maroon;'><img border=""0"" height=""16"" src=""images/radio-trans.png"" width=""16"" />" & strShow & "</span>" & "<br />"
                    ElseIf dr.GetString(0) = "R" And dr.GetDateTime(62) <> "1/1/1900" Then
                        arTasks(day) = arTasks(day) & "<span class='calendarNormal'><img border=""0"" height=""16"" src=""images/radio-trans.png"" width=""16"" />" & strShow & "</span>" & "<br />"
                    ElseIf dr.GetString(0) = "R" Then
                        arTasks(day) = arTasks(day) & "<span class='" & strCompleted & "'><img border=""0"" height=""16"" src=""images/radio-trans.png"" width=""16"" />" & strShow & "</span>" & "<br />"
                    End If
                    If dr.GetString(0) = "T" And dr.GetInt32(57) = 1 Then
                        arTasks(day) = arTasks(day) & "<span class='" & strCompleted & "' style='color: Maroon;'><img border=""0"" height=""16"" src=""images/plasma-tv-trans.png"" width=""16"" />" & strShow & "</span>" & "<br />"
                    ElseIf dr.GetString(0) = "T" And dr.GetDateTime(62) <> "1/1/1900" Then
                        arTasks(day) = arTasks(day) & "<span class='calendarNormal'><img border=""0"" height=""16"" src=""images/plasma-tv-trans.png"" width=""16"" />" & strShow & "</span>" & "<br />"
                    ElseIf dr.GetString(0) = "T" Then
                        arTasks(day) = arTasks(day) & "<span class='" & strCompleted & "'><img border=""0"" height=""16"" src=""images/plasma-tv-trans.png"" width=""16"" />" & strShow & "</span>" & "<br />"
                    End If

                    'End If

                End If

                If RunInsertionDate = True And DisplayFlight = True And dr.GetDateTime(22) >= Convert.ToDateTime(parameterStartDate.Value).Date And dr.GetDateTime(22) <= Convert.ToDateTime(parameterEndDate.Value).Date Then
                    If dr.GetString(0) = "M" And dr.GetInt32(57) = 1 Then
                        arTasks(dr.GetDateTime(22).Day) = arTasks(dr.GetDateTime(22).Day) & "<span class='" & strCompleted & "' style='color: red;'><img border=""0"" height=""16"" src=""images/book_open2-trans.png"" width=""16"" />" & strShow & "</span>" & "<br />"
                    ElseIf dr.GetString(0) = "M" Then
                        arTasks(dr.GetDateTime(22).Day) = arTasks(dr.GetDateTime(22).Day) & "<span class='" & strCompleted & "'><img border=""0"" height=""16"" src=""images/book_open2-trans.png"" width=""16"" />" & strShow & "</span>" & "<br />"
                    End If
                    If dr.GetString(0) = "N" And dr.GetInt32(57) = 1 Then
                        arTasks(dr.GetDateTime(22).Day) = arTasks(dr.GetDateTime(22).Day) & "<span class='" & strCompleted & "' style='color: red;'><img border=""0"" height=""16"" src=""images/newspaper.png"" width=""16"" />" & strShow & "</span>" & "<br />"
                    ElseIf dr.GetString(0) = "N" Then
                        arTasks(dr.GetDateTime(22).Day) = arTasks(dr.GetDateTime(22).Day) & "<span class='" & strCompleted & "'><img border=""0"" height=""16"" src=""images/newspaper.png"" width=""16"" />" & strShow & "</span>" & "<br />"
                    End If
                    If dr.GetString(0) = "I" And dr.GetInt32(57) = 1 Then
                        arTasks(dr.GetDateTime(22).Day) = arTasks(dr.GetDateTime(22).Day) & "<span class='" & strCompleted & "' style='color: red;'><img border=""0"" height=""16"" src=""images/monitor.png"" width=""16"" />" & strShow & "</span>" & "<br />"
                    ElseIf dr.GetString(0) = "I" Then
                        arTasks(dr.GetDateTime(22).Day) = arTasks(dr.GetDateTime(22).Day) & "<span class='" & strCompleted & "'><img border=""0"" height=""16"" src=""images/monitor.png"" width=""16"" />" & strShow & "</span>" & "<br />"
                    End If
                    If dr.GetString(0) = "O" And dr.GetInt32(57) = 1 Then
                        arTasks(dr.GetDateTime(22).Day) = arTasks(dr.GetDateTime(22).Day) & "<span class='" & strCompleted & "' style='color: red;'><img border=""0"" height=""16"" src=""images/house2.png"" width=""16"" />" & strShow & "</span>" & "<br />"
                    ElseIf dr.GetString(0) = "O" Then
                        arTasks(dr.GetDateTime(22).Day) = arTasks(dr.GetDateTime(22).Day) & "<span class='" & strCompleted & "'><img border=""0"" height=""16"" src=""images/house2.png"" width=""16"" />" & strShow & "</span>" & "<br />"
                    End If
                    If dr.GetString(0) = "R" And dr.GetInt32(57) = 1 Then
                        arTasks(dr.GetDateTime(22).Day) = arTasks(dr.GetDateTime(22).Day) & "<span class='" & strCompleted & "' style='color: red;'><img border=""0"" height=""16"" src=""images/radio-trans.png"" width=""16"" />" & strShow & "</span>" & "<br />"
                    ElseIf dr.GetString(0) = "R" Then
                        arTasks(dr.GetDateTime(22).Day) = arTasks(dr.GetDateTime(22).Day) & "<span class='calendarNormal'><img border=""0"" height=""16"" src=""images/radio-trans.png"" width=""16"" />" & strShow & "</span>" & "<br />"
                    End If
                    If dr.GetString(0) = "T" And dr.GetInt32(57) = 1 Then
                        arTasks(dr.GetDateTime(22).Day) = arTasks(dr.GetDateTime(22).Day) & "<span class='" & strCompleted & "' style='color: red;'><img border=""0"" height=""16"" src=""images/plasma-tv-trans.png"" width=""16"" />" & strShow & "</span>" & "<br />"
                    ElseIf dr.GetString(0) = "T" Then
                        arTasks(dr.GetDateTime(22).Day) = arTasks(dr.GetDateTime(22).Day) & "<span class='calendarNormal'><img border=""0"" height=""16"" src=""images/plasma-tv-trans.png"" width=""16"" />" & strShow & "</span>" & "<br />"
                    End If
                ElseIf RunInsertionDate = True And DisplayFlight = False Then
                    Dim days As String = dr.GetString(21)
                    Dim startday As DateTime = dr.GetDateTime(22)
                    Dim endday As DateTime = dr.GetDateTime(23)
                    Dim j As Integer
                    If startday.Month.ToString() = Month And startday.Year.ToString() = Year And endday.Month.ToString() = Month And endday.Year.ToString() = Year Then
                        For j = startday.Day To endday.Day
                            'arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "'>" & strShow & "</span>" & "<br />"
                            If dr.GetString(0) = "M" And dr.GetInt32(57) = 1 And j = endday.Day Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "' style='color: Maroon;'><img border=""0"" height=""16"" src=""images/book_open2-trans.png"" width=""16"" />" & strShow & "</span>" & "<br />"
                            ElseIf dr.GetString(0) = "M" And j = endday.Day Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "'><img border=""0"" height=""16"" src=""images/book_open2-trans.png"" width=""16"" />" & strShow & "</span>" & "<br />"
                            ElseIf dr.GetString(0) = "M" And dr.GetInt32(57) = 1 Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "' style='color: Maroon;'><img border=""0"" height=""16"" src=""images/book_open2-trans.png"" width=""16"" />" & strShow & "</span><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" />" & "<br />"
                            ElseIf dr.GetString(0) = "M" Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "'><img border=""0"" height=""16"" src=""images/book_open2-trans.png"" width=""16"" />" & strShow & "</span><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" />" & "<br />"
                            End If
                            If dr.GetString(0) = "N" And dr.GetInt32(57) = 1 And j = endday.Day Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "' style='color: Maroon;'><img border=""0"" height=""16"" src=""images/newspaper.png"" width=""16"" />" & strShow & "</span>" & "<br />"
                            ElseIf dr.GetString(0) = "N" And j = endday.Day Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "'><img border=""0"" height=""16"" src=""images/newspaper.png"" width=""16"" />" & strShow & "</span>" & "<br />"
                            ElseIf dr.GetString(0) = "N" And dr.GetInt32(57) = 1 Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "' style='color: Maroon;'><img border=""0"" height=""16"" src=""images/newspaper.png"" width=""16"" />" & strShow & "</span><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" />" & "<br />"
                            ElseIf dr.GetString(0) = "N" Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "'><img border=""0"" height=""16"" src=""images/newspaper.png"" width=""16"" />" & strShow & "</span><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" />" & "<br />"
                            End If
                            If dr.GetString(0) = "I" And dr.GetInt32(57) = 1 And j = endday.Day Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "' style='color: Maroon;'><img border=""0"" height=""16"" src=""images/monitor.png"" width=""16"" />" & strShow & "</span>" & "<br />"
                            ElseIf dr.GetString(0) = "I" And j = endday.Day Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "'><img border=""0"" height=""16"" src=""images/monitor.png"" width=""16"" />" & strShow & "</span>" & "<br />"
                            ElseIf dr.GetString(0) = "I" And dr.GetInt32(57) = 1 Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "' style='color: Maroon;'><img border=""0"" height=""16"" src=""images/monitor.png"" width=""16"" />" & strShow & "</span><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" />" & "<br />"
                            ElseIf dr.GetString(0) = "I" Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "'><img border=""0"" height=""16"" src=""images/monitor.png"" width=""16"" />" & strShow & "</span><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" />" & "<br />"
                            End If
                            If dr.GetString(0) = "O" And dr.GetInt32(57) = 1 And j = endday.Day Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "' style='color: Maroon;'><img border=""0"" height=""16"" src=""images/house2.png"" width=""16"" />" & strShow & "</span>" & "<br />"
                            ElseIf dr.GetString(0) = "O" And j = endday.Day Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "'><img border=""0"" height=""16"" src=""images/house2.png"" width=""16"" />" & strShow & "</span>" & "<br />"
                            ElseIf dr.GetString(0) = "O" And dr.GetInt32(57) = 1 Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "' style='color: Maroon;'><img border=""0"" height=""16"" src=""images/house2.png"" width=""16"" />" & strShow & "</span><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" />" & "<br />"
                            ElseIf dr.GetString(0) = "O" Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "'><img border=""0"" height=""16"" src=""images/house2.png"" width=""16"" />" & strShow & "</span><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" />" & "<br />"
                            End If
                            If dr.GetString(0) = "R" And dr.GetInt32(57) = 1 And j = endday.Day Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "' style='color: Maroon;'><img border=""0"" height=""16"" src=""images/radio-trans.png"" width=""16"" />" & strShow & "</span>" & "<br />"
                            ElseIf dr.GetString(0) = "R" And j = endday.Day Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "'><img border=""0"" height=""16"" src=""images/radio-trans.png"" width=""16"" />" & strShow & "</span>" & "<br />"
                            ElseIf dr.GetString(0) = "R" And dr.GetInt32(57) = 1 Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "' style='color: Maroon;'><img border=""0"" height=""16"" src=""images/radio-trans.png"" width=""16"" />" & strShow & "</span><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" />" & "<br />"
                            ElseIf dr.GetString(0) = "R" Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "'><img border=""0"" height=""16"" src=""images/radio-trans.png"" width=""16"" />" & strShow & "</span><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" />" & "<br />"
                            End If
                            If dr.GetString(0) = "T" And dr.GetInt32(57) = 1 And j = endday.Day Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "' style='color: Maroon;'><img border=""0"" height=""16"" src=""images/plasma-tv-trans.png"" width=""16"" />" & strShow & "</span>" & "<br />"
                            ElseIf dr.GetString(0) = "T" And j = endday.Day Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "'><img border=""0"" height=""16"" src=""images/plasma-tv-trans.png"" width=""16"" />" & strShow & "</span>" & "<br />"
                            ElseIf dr.GetString(0) = "T" And dr.GetInt32(57) = 1 Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "' style='color: Maroon;'><img border=""0"" height=""16"" src=""images/plasma-tv-trans.png"" width=""16"" />" & strShow & "</span><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" />" & "<br />"
                            ElseIf dr.GetString(0) = "T" Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "'><img border=""0"" height=""16"" src=""images/plasma-tv-trans.png"" width=""16"" />" & strShow & "</span><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" />" & "<br />"
                            End If
                        Next
                    ElseIf startday.Month.ToString() = Month And startday.Year.ToString() = Year And endday.Month.ToString() <> Month Then
                        For j = startday.Day To intDaysInMonth
                            ' arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "'>" & strShow & "</span>" & "<br />"
                            If dr.GetString(0) = "M" And dr.GetInt32(57) = 1 And j = endday.Day Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "' style='color: Maroon;'><img border=""0"" height=""16"" src=""images/book_open2-trans.png"" width=""16"" />" & strShow & "</span>" & "<br />"
                            ElseIf dr.GetString(0) = "M" And j = endday.Day Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "'><img border=""0"" height=""16"" src=""images/book_open2-trans.png"" width=""16"" />" & strShow & "</span>" & "<br />"
                            ElseIf dr.GetString(0) = "M" And dr.GetInt32(57) = 1 Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "' style='color: Maroon;'><img border=""0"" height=""16"" src=""images/book_open2-trans.png"" width=""16"" />" & strShow & "</span><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" />" & "<br />"
                            ElseIf dr.GetString(0) = "M" Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "'><img border=""0"" height=""16"" src=""images/book_open2-trans.png"" width=""16"" />" & strShow & "</span><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" />" & "<br />"
                            End If
                            If dr.GetString(0) = "N" And dr.GetInt32(57) = 1 And j = endday.Day Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "' style='color: Maroon;'><img border=""0"" height=""16"" src=""images/newspaper.png"" width=""16"" />" & strShow & "</span>" & "<br />"
                            ElseIf dr.GetString(0) = "N" And j = endday.Day Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "'><img border=""0"" height=""16"" src=""images/newspaper.png"" width=""16"" />" & strShow & "</span>" & "<br />"
                            ElseIf dr.GetString(0) = "N" And dr.GetInt32(57) = 1 Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "' style='color: Maroon;'><img border=""0"" height=""16"" src=""images/newspaper.png"" width=""16"" />" & strShow & "</span><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" />" & "<br />"
                            ElseIf dr.GetString(0) = "N" Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "'><img border=""0"" height=""16"" src=""images/newspaper.png"" width=""16"" />" & strShow & "</span><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" />" & "<br />"
                            End If
                            If dr.GetString(0) = "I" And dr.GetInt32(57) = 1 And j = endday.Day Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "' style='color: Maroon;'><img border=""0"" height=""16"" src=""images/monitor.png"" width=""16"" />" & strShow & "</span>" & "<br />"
                            ElseIf dr.GetString(0) = "I" And j = endday.Day Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "'><img border=""0"" height=""16"" src=""images/monitor.png"" width=""16"" />" & strShow & "</span>" & "<br />"
                            ElseIf dr.GetString(0) = "I" And dr.GetInt32(57) = 1 Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "' style='color: Maroon;'><img border=""0"" height=""16"" src=""images/monitor.png"" width=""16"" />" & strShow & "</span><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" />" & "<br />"
                            ElseIf dr.GetString(0) = "I" Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "'><img border=""0"" height=""16"" src=""images/monitor.png"" width=""16"" />" & strShow & "</span><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" />" & "<br />"
                            End If
                            If dr.GetString(0) = "O" And dr.GetInt32(57) = 1 And j = endday.Day Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "' style='color: Maroon;'><img border=""0"" height=""16"" src=""images/house2.png"" width=""16"" />" & strShow & "</span>" & "<br />"
                            ElseIf dr.GetString(0) = "O" And j = endday.Day Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "'><img border=""0"" height=""16"" src=""images/house2.png"" width=""16"" />" & strShow & "</span>" & "<br />"
                            ElseIf dr.GetString(0) = "O" And dr.GetInt32(57) = 1 Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "' style='color: Maroon;'><img border=""0"" height=""16"" src=""images/house2.png"" width=""16"" />" & strShow & "</span><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" />" & "<br />"
                            ElseIf dr.GetString(0) = "O" Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "'><img border=""0"" height=""16"" src=""images/house2.png"" width=""16"" />" & strShow & "</span><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" />" & "<br />"
                            End If
                            If dr.GetString(0) = "R" And dr.GetInt32(57) = 1 And j = endday.Day Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "' style='color: Maroon;'><img border=""0"" height=""16"" src=""images/radio-trans.png"" width=""16"" />" & strShow & "</span>" & "<br />"
                            ElseIf dr.GetString(0) = "R" And j = endday.Day Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "'><img border=""0"" height=""16"" src=""images/radio-trans.png"" width=""16"" />" & strShow & "</span>" & "<br />"
                            ElseIf dr.GetString(0) = "R" And dr.GetInt32(57) = 1 Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "' style='color: Maroon;'><img border=""0"" height=""16"" src=""images/radio-trans.png"" width=""16"" />" & strShow & "</span><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" />" & "<br />"
                            ElseIf dr.GetString(0) = "R" Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "'><img border=""0"" height=""16"" src=""images/radio-trans.png"" width=""16"" />" & strShow & "</span><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" />" & "<br />"
                            End If
                            If dr.GetString(0) = "T" And dr.GetInt32(57) = 1 And j = endday.Day Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "' style='color: Maroon;'><img border=""0"" height=""16"" src=""images/plasma-tv-trans.png"" width=""16"" />" & strShow & "</span>" & "<br />"
                            ElseIf dr.GetString(0) = "T" And j = endday.Day Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "'><img border=""0"" height=""16"" src=""images/plasma-tv-trans.png"" width=""16"" />" & strShow & "</span>" & "<br />"
                            ElseIf dr.GetString(0) = "T" And dr.GetInt32(57) = 1 Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "' style='color: Maroon;'><img border=""0"" height=""16"" src=""images/plasma-tv-trans.png"" width=""16"" />" & strShow & "</span><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" />" & "<br />"
                            ElseIf dr.GetString(0) = "T" Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "'><img border=""0"" height=""16"" src=""images/plasma-tv-trans.png"" width=""16"" />" & strShow & "</span><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" />" & "<br />"
                            End If
                        Next
                    ElseIf startday.Month.ToString() <> Month And endday.Month.ToString() = Month Then
                        For j = 1 To intDaysInMonth
                            'arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "'>" & strShow & "</span>" & "<br />"
                            If dr.GetString(0) = "M" And dr.GetInt32(57) = 1 And j = endday.Day Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "' style='color: Maroon;'><img border=""0"" height=""16"" src=""images/book_open2-trans.png"" width=""16"" />" & strShow & "</span>" & "<br />"
                            ElseIf dr.GetString(0) = "M" And j = endday.Day Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "'><img border=""0"" height=""16"" src=""images/book_open2-trans.png"" width=""16"" />" & strShow & "</span>" & "<br />"
                            ElseIf dr.GetString(0) = "M" And dr.GetInt32(57) = 1 Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "' style='color: Maroon;'><img border=""0"" height=""16"" src=""images/book_open2-trans.png"" width=""16"" />" & strShow & "</span><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" />" & "<br />"
                            ElseIf dr.GetString(0) = "M" Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "'><img border=""0"" height=""16"" src=""images/book_open2-trans.png"" width=""16"" />" & strShow & "</span><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" />" & "<br />"
                            End If
                            If dr.GetString(0) = "N" And dr.GetInt32(57) = 1 And j = endday.Day Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "' style='color: Maroon;'><img border=""0"" height=""16"" src=""images/newspaper.png"" width=""16"" />" & strShow & "</span>" & "<br />"
                            ElseIf dr.GetString(0) = "N" And j = endday.Day Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "'><img border=""0"" height=""16"" src=""images/newspaper.png"" width=""16"" />" & strShow & "</span>" & "<br />"
                            ElseIf dr.GetString(0) = "N" And dr.GetInt32(57) = 1 Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "' style='color: Maroon;'><img border=""0"" height=""16"" src=""images/newspaper.png"" width=""16"" />" & strShow & "</span><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" />" & "<br />"
                            ElseIf dr.GetString(0) = "N" Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "'><img border=""0"" height=""16"" src=""images/newspaper.png"" width=""16"" />" & strShow & "</span><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" />" & "<br />"
                            End If
                            If dr.GetString(0) = "I" And dr.GetInt32(57) = 1 And j = endday.Day Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "' style='color: Maroon;'><img border=""0"" height=""16"" src=""images/monitor.png"" width=""16"" />" & strShow & "</span>" & "<br />"
                            ElseIf dr.GetString(0) = "I" And j = endday.Day Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "'><img border=""0"" height=""16"" src=""images/monitor.png"" width=""16"" />" & strShow & "</span>" & "<br />"
                            ElseIf dr.GetString(0) = "I" And dr.GetInt32(57) = 1 Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "' style='color: Maroon;'><img border=""0"" height=""16"" src=""images/monitor.png"" width=""16"" />" & strShow & "</span><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" />" & "<br />"
                            ElseIf dr.GetString(0) = "I" Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "'><img border=""0"" height=""16"" src=""images/monitor.png"" width=""16"" />" & strShow & "</span><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" />" & "<br />"
                            End If
                            If dr.GetString(0) = "O" And dr.GetInt32(57) = 1 And j = endday.Day Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "' style='color: Maroon;'><img border=""0"" height=""16"" src=""images/house2.png"" width=""16"" />" & strShow & "</span>" & "<br />"
                            ElseIf dr.GetString(0) = "O" And j = endday.Day Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "'><img border=""0"" height=""16"" src=""images/house2.png"" width=""16"" />" & strShow & "</span>" & "<br />"
                            ElseIf dr.GetString(0) = "O" And dr.GetInt32(57) = 1 Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "' style='color: Maroon;'><img border=""0"" height=""16"" src=""images/house2.png"" width=""16"" />" & strShow & "</span><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" />" & "<br />"
                            ElseIf dr.GetString(0) = "O" Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "'><img border=""0"" height=""16"" src=""images/house2.png"" width=""16"" />" & strShow & "</span><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" />" & "<br />"
                            End If
                            If dr.GetString(0) = "R" And dr.GetInt32(57) = 1 And j = endday.Day Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "' style='color: Maroon;'><img border=""0"" height=""16"" src=""images/radio-trans.png"" width=""16"" />" & strShow & "</span>" & "<br />"
                            ElseIf dr.GetString(0) = "R" And j = endday.Day Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "'><img border=""0"" height=""16"" src=""images/radio-trans.png"" width=""16"" />" & strShow & "</span>" & "<br />"
                            ElseIf dr.GetString(0) = "R" And dr.GetInt32(57) = 1 Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "' style='color: Maroon;'><img border=""0"" height=""16"" src=""images/radio-trans.png"" width=""16"" />" & strShow & "</span><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" />" & "<br />"
                            ElseIf dr.GetString(0) = "R" Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "'><img border=""0"" height=""16"" src=""images/radio-trans.png"" width=""16"" />" & strShow & "</span><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" />" & "<br />"
                            End If
                            If dr.GetString(0) = "T" And dr.GetInt32(57) = 1 And j = endday.Day Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "' style='color: Maroon;'><img border=""0"" height=""16"" src=""images/plasma-tv-trans.png"" width=""16"" />" & strShow & "</span>" & "<br />"
                            ElseIf dr.GetString(0) = "T" And j = endday.Day Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "'><img border=""0"" height=""16"" src=""images/plasma-tv-trans.png"" width=""16"" />" & strShow & "</span>" & "<br />"
                            ElseIf dr.GetString(0) = "T" And dr.GetInt32(57) = 1 Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "' style='color: Maroon;'><img border=""0"" height=""16"" src=""images/plasma-tv-trans.png"" width=""16"" />" & strShow & "</span><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" />" & "<br />"
                            ElseIf dr.GetString(0) = "T" Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "'><img border=""0"" height=""16"" src=""images/plasma-tv-trans.png"" width=""16"" />" & strShow & "</span><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" />" & "<br />"
                            End If
                        Next
                    ElseIf Convert.ToDateTime(parameterStartDate.Value).Date >= startday.Date And Convert.ToDateTime(parameterEndDate.Value).Date <= endday.Date Then
                        For j = 1 To endday.Day
                            'arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "'>" & strShow & "</span>" & "<br />"
                            If dr.GetString(0) = "M" And dr.GetInt32(57) = 1 And j = endday.Day Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "' style='color: Maroon;'><img border=""0"" height=""16"" src=""images/book_open2-trans.png"" width=""16"" />" & strShow & "</span>" & "<br />"
                            ElseIf dr.GetString(0) = "M" And j = endday.Day Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "'><img border=""0"" height=""16"" src=""images/book_open2-trans.png"" width=""16"" />" & strShow & "</span>" & "<br />"
                            ElseIf dr.GetString(0) = "M" And dr.GetInt32(57) = 1 Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "' style='color: Maroon;'><img border=""0"" height=""16"" src=""images/book_open2-trans.png"" width=""16"" />" & strShow & "</span><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" />" & "<br />"
                            ElseIf dr.GetString(0) = "M" Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "'><img border=""0"" height=""16"" src=""images/book_open2-trans.png"" width=""16"" />" & strShow & "</span><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" />" & "<br />"
                            End If
                            If dr.GetString(0) = "N" And dr.GetInt32(57) = 1 And j = endday.Day Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "' style='color: Maroon;'><img border=""0"" height=""16"" src=""images/newspaper.png"" width=""16"" />" & strShow & "</span>" & "<br />"
                            ElseIf dr.GetString(0) = "N" And j = endday.Day Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "'><img border=""0"" height=""16"" src=""images/newspaper.png"" width=""16"" />" & strShow & "</span>" & "<br />"
                            ElseIf dr.GetString(0) = "N" And dr.GetInt32(57) = 1 Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "' style='color: Maroon;'><img border=""0"" height=""16"" src=""images/newspaper.png"" width=""16"" />" & strShow & "</span><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" />" & "<br />"
                            ElseIf dr.GetString(0) = "N" Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "'><img border=""0"" height=""16"" src=""images/newspaper.png"" width=""16"" />" & strShow & "</span><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" />" & "<br />"
                            End If
                            If dr.GetString(0) = "I" And dr.GetInt32(57) = 1 And j = endday.Day Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "' style='color: Maroon;'><img border=""0"" height=""16"" src=""images/monitor.png"" width=""16"" />" & strShow & "</span>" & "<br />"
                            ElseIf dr.GetString(0) = "I" And j = endday.Day Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "'><img border=""0"" height=""16"" src=""images/monitor.png"" width=""16"" />" & strShow & "</span>" & "<br />"
                            ElseIf dr.GetString(0) = "I" And dr.GetInt32(57) = 1 Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "' style='color: Maroon;'><img border=""0"" height=""16"" src=""images/monitor.png"" width=""16"" />" & strShow & "</span><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" />" & "<br />"
                            ElseIf dr.GetString(0) = "I" Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "'><img border=""0"" height=""16"" src=""images/monitor.png"" width=""16"" />" & strShow & "</span><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" />" & "<br />"
                            End If
                            If dr.GetString(0) = "O" And dr.GetInt32(57) = 1 And j = endday.Day Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "' style='color: Maroon;'><img border=""0"" height=""16"" src=""images/house2.png"" width=""16"" />" & strShow & "</span>" & "<br />"
                            ElseIf dr.GetString(0) = "O" And j = endday.Day Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "'><img border=""0"" height=""16"" src=""images/house2.png"" width=""16"" />" & strShow & "</span>" & "<br />"
                            ElseIf dr.GetString(0) = "O" And dr.GetInt32(57) = 1 Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "' style='color: Maroon;'><img border=""0"" height=""16"" src=""images/house2.png"" width=""16"" />" & strShow & "</span><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" />" & "<br />"
                            ElseIf dr.GetString(0) = "O" Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "'><img border=""0"" height=""16"" src=""images/house2.png"" width=""16"" />" & strShow & "</span><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" />" & "<br />"
                            End If
                            If dr.GetString(0) = "R" And dr.GetInt32(57) = 1 And j = endday.Day Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "' style='color: Maroon;'><img border=""0"" height=""16"" src=""images/radio-trans.png"" width=""16"" />" & strShow & "</span>" & "<br />"
                            ElseIf dr.GetString(0) = "R" And j = endday.Day Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "'><img border=""0"" height=""16"" src=""images/radio-trans.png"" width=""16"" />" & strShow & "</span>" & "<br />"
                            ElseIf dr.GetString(0) = "R" And dr.GetInt32(57) = 1 Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "' style='color: Maroon;'><img border=""0"" height=""16"" src=""images/radio-trans.png"" width=""16"" />" & strShow & "</span><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" />" & "<br />"
                            ElseIf dr.GetString(0) = "R" Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "'><img border=""0"" height=""16"" src=""images/radio-trans.png"" width=""16"" />" & strShow & "</span><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" />" & "<br />"
                            End If
                            If dr.GetString(0) = "T" And dr.GetInt32(57) = 1 And j = endday.Day Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "' style='color: Maroon;'><img border=""0"" height=""16"" src=""images/plasma-tv-trans.png"" width=""16"" />" & strShow & "</span>" & "<br />"
                            ElseIf dr.GetString(0) = "T" And j = endday.Day Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "'><img border=""0"" height=""16"" src=""images/plasma-tv-trans.png"" width=""16"" />" & strShow & "</span>" & "<br />"
                            ElseIf dr.GetString(0) = "T" And dr.GetInt32(57) = 1 Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "' style='color: Maroon;'><img border=""0"" height=""16"" src=""images/plasma-tv-trans.png"" width=""16"" />" & strShow & "</span><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" />" & "<br />"
                            ElseIf dr.GetString(0) = "T" Then
                                arTasks(j) = arTasks(j) & "<span class='" & strCompleted & "'><img border=""0"" height=""16"" src=""images/plasma-tv-trans.png"" width=""16"" />" & strShow & "</span><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" /><img border=""0"" height=""8"" src=""images/arrow_right_blue-trans.png"" width=""12"" />" & "<br />"
                            End If
                        Next
                    End If
                End If
                strShow = ""
            Loop

            ThisWeek = New Week
            ThisMonth = New Month

            For I = 1 To intDaysInMonth
                ThisDay = CDate(Month & "/" & CStr(I) & "/" & Year)
                'ThisDayLink = "<table valign=""top"" cellspacing=""0"" width=""14%"" height=""100""><tr><td colspan=""1"" rowspan=""4"" align=""center"" valign=""top"" width=""5%"" height=""100"" style=""border-right: #A5A4E5 1px solid; background-color: #A5A4E5;""><asp:Label EnableViewState="false"  ID=""lblNum"" runat=""server""><A href='Calendar_DayView.aspx?ThisDate=" & ThisDay & "'><b>" & CStr(I) & "</b></A></asp:Label></td></tr>"
                ThisDayLink = "<table valign=""top"" cellspacing=""0""><tr><td colspan=""1"" rowspan=""4"" align=""center"" valign=""top"" style=""border-right: #A5A4E5 1px solid; background-color: #A5A4E5;""><div style=""width: 15px; height: 100px; overflow: visible; padding-right: 0px; padding-left: 0px; padding-bottom: 0px; margin: 0px; padding-top: 0px;""><A href='MediaCalendar_Day.aspx?ThisDate=" & ThisDay & "&Tab=2'><b>" & CStr(I) & "</b></A></div></td></tr>"
                If Print = True Then
                    taskLink = "<tr><td><div id=""topMenu" & ThisDay.Day & """ style=""padding-right: 0px; padding-left: 0px; padding-bottom: 0px; margin: 0px; padding-top: 0px;""><A href='MediaCalendar_Day.aspx?ThisDate=" & ThisDay & "&Tab=2'>" & arTasks(I)
                Else
                    taskLink = "<tr><td><div id=""topMenu" & ThisDay.Day & """ style=""height: 100px; width: 125px; overflow-x: auto; overflow-y: auto; padding-right: 0px; padding-left: 0px; padding-bottom: 0px; margin: 0px; padding-top: 0px;""><A href='MediaCalendar_Day.aspx?ThisDate=" & ThisDay & "&Tab=2'>" & arTasks(I)
                End If
                Select Case ThisDay.DayOfWeek
                    Case DayOfWeek.Sunday
                        If arTasks(I).Length > 0 Then
                            ThisWeek.Sunday = ThisDayLink & taskLink & "</A></div><asp:Literal ID=""Literal1"" runat=""server""></asp:Literal></td></tr></table>"
                            '" & writeFloatEntry(ThisDay, arTasks(I)) & "
                        Else
                            ThisWeek.Sunday = ThisDayLink & "</table>"
                        End If
                    Case DayOfWeek.Monday
                        If arTasks(I).Length > 0 Then
                            ThisWeek.Monday = ThisDayLink & taskLink & "</A></div><asp:Literal ID=""Literal1"" runat=""server""></asp:Literal></td></tr></table>"
                        Else
                            ThisWeek.Monday = ThisDayLink & "</table>"
                        End If
                    Case DayOfWeek.Tuesday
                        If arTasks(I).Length > 0 Then
                            ThisWeek.Tuesday = ThisDayLink & taskLink & "</A></div><asp:Literal ID=""Literal1"" runat=""server""></asp:Literal></td></tr></table>"
                        Else
                            ThisWeek.Tuesday = ThisDayLink & "</table>"
                        End If
                    Case DayOfWeek.Wednesday
                        If arTasks(I).Length > 0 Then
                            ThisWeek.Wednesday = ThisDayLink & taskLink & "</A></div><asp:Literal ID=""Literal1"" runat=""server""></asp:Literal></td></tr></table>"
                        Else
                            ThisWeek.Wednesday = ThisDayLink & "</table>"
                        End If
                    Case DayOfWeek.Thursday
                        If arTasks(I).Length > 0 Then
                            ThisWeek.Thursday = ThisDayLink & taskLink & "</A></div><asp:Literal ID=""Literal1"" runat=""server""></asp:Literal></td></tr></table>"
                        Else
                            ThisWeek.Thursday = ThisDayLink & "</table>"
                        End If
                    Case DayOfWeek.Friday
                        If arTasks(I).Length > 0 Then
                            ThisWeek.Friday = ThisDayLink & taskLink & "</A></div><asp:Literal ID=""Literal1"" runat=""server""></asp:Literal></td></tr></table>"
                        Else
                            ThisWeek.Friday = ThisDayLink & "</table>"
                        End If
                    Case DayOfWeek.Saturday
                        If arTasks(I).Length > 0 Then
                            ThisWeek.Saturday = ThisDayLink & taskLink & "</A></div><asp:Literal ID=""Literal1"" runat=""server""></asp:Literal></td></tr></table>"
                        Else
                            ThisWeek.Saturday = ThisDayLink & "</table>"
                        End If
                End Select
                If ThisWeek.Sunday Is Nothing Then
                    ThisWeek.Sunday = "&nbsp;"
                End If
                If ThisWeek.Monday Is Nothing Then
                    ThisWeek.Monday = "&nbsp;"
                End If
                If ThisWeek.Tuesday Is Nothing Then
                    ThisWeek.Tuesday = "&nbsp;"
                End If
                If ThisWeek.Wednesday Is Nothing Then
                    ThisWeek.Wednesday = "&nbsp;"
                End If
                If ThisWeek.Thursday Is Nothing Then
                    ThisWeek.Thursday = "&nbsp;"
                End If
                If ThisWeek.Friday Is Nothing Then
                    ThisWeek.Friday = "&nbsp;"
                End If
                If ThisWeek.Saturday Is Nothing Then
                    ThisWeek.Saturday = "&nbsp;"
                End If
                If ThisDay.DayOfWeek = DayOfWeek.Saturday Or ThisDay.Day = intDaysInMonth Then
                    ThisWeek.WeekLink = "<a href='MediaCalendar_Week.aspx?thisdate=" & ThisDay.AddDays(-ThisDay.DayOfWeek) & "&Tab=1'><img src=""Images/Icons/Grey/256/magnifying_glass.png"" class=""icon-image"" /></a>"
                    ThisMonth.Add(ThisWeek)
                    ThisWeek = New Week
                End If
            Next I

            dr.Close()

            Return ThisMonth

        End Function
        Public Function GetMediaDay(ByVal startDate As Date,
                                        ByVal UserID As String,
                                        Optional ByVal Client As String = "",
                                        Optional ByVal Division As String = "",
                                        Optional ByVal Product As String = "",
                                        Optional ByVal MediaType As String = "",
                                        Optional ByVal Campaign As String = "",
                                        Optional ByVal ClientPO As String = "",
                                        Optional ByVal Vendor As String = "",
                                        Optional ByVal Buyer As String = "",
                                        Optional ByVal Magazine As Boolean = False,
                                        Optional ByVal NewsPaper As Boolean = False,
                                        Optional ByVal Internet As Boolean = False,
                                        Optional ByVal OutOfHome As Boolean = False,
                                        Optional ByVal Television As Boolean = False,
                                        Optional ByVal Radio As Boolean = False,
                                        Optional ByVal AcceptedOrdersOnly As Boolean = False,
                                        Optional ByVal CancelledOrders As Boolean = False,
                                        Optional ByVal ClientCode As Boolean = False,
                                        Optional ByVal DivisionCode As Boolean = False,
                                        Optional ByVal ProductCode As Boolean = False,
                                        Optional ByVal Type As Boolean = False,
                                        Optional ByVal MType As Boolean = False,
                                        Optional ByVal InsertionLine As Boolean = False,
                                        Optional ByVal VendorCode As Boolean = False,
                                        Optional ByVal VendorName As Boolean = False,
                                        Optional ByVal JobComp As Boolean = False,
                                        Optional ByVal CampaignCode As Boolean = False,
                                        Optional ByVal CampaignName As Boolean = False,
                                        Optional ByVal MarketCode As Boolean = False,
                                        Optional ByVal MarketName As Boolean = False,
                                        Optional ByVal AdSizeLength As Boolean = False,
                                        Optional ByVal HeadlineProg As Boolean = False,
                                        Optional ByVal ExtMatDate As Boolean = False,
                                        Optional ByVal CloseDate As Boolean = False,
                                        Optional ByVal ExtCloseDate As Boolean = False,
                                        Optional ByVal RunDate As Boolean = False,
                                        Optional ByVal BillingAmount As Boolean = False,
                                        Optional ByVal Spots As Boolean = False,
                                        Optional ByVal MatDueDate As Boolean = False,
                                        Optional ByVal ExtMatDueDate As Boolean = False,
                                        Optional ByVal CloseDate2 As Boolean = False,
                                        Optional ByVal ExtCloseDate2 As Boolean = False,
                                        Optional ByVal RunInsertionDate As Boolean = False,
                                        Optional ByVal DisplayFlight As Boolean = False,
                                        Optional ByVal Office As String = "") As DataTable

            Dim ThisMonth As Month
            Dim ThisWeek As Week
            Dim ThisDay As Date
            Dim ThisDayLink As String
            Dim dr As SqlClient.SqlDataReader
            Dim dr2 As SqlClient.SqlDataReader
            Dim I As Integer
            Dim arTasks(31) As String
            Dim strShow As String
            Dim arParams(27) As SqlParameter
            Dim strCompleted As String
            Dim taskLink As String

            'Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
            'parameterUserID.Value = UserID
            'arParams(0) = parameterUserID

            Dim parameterMagazine As New SqlParameter("@MagazineInc", SqlDbType.Char, 1)
            If Magazine = True Then
                parameterMagazine.Value = "Y"
            Else
                parameterMagazine.Value = "N"
            End If
            arParams(0) = parameterMagazine

            Dim parameterNewspaper As New SqlParameter("@NewspaperInc", SqlDbType.Char, 1)
            If NewsPaper = True Then
                parameterNewspaper.Value = "Y"
            Else
                parameterNewspaper.Value = "N"
            End If
            arParams(1) = parameterNewspaper

            Dim parameterInternet As New SqlParameter("@InternetInc", SqlDbType.Char, 1)
            If Internet = True Then
                parameterInternet.Value = "Y"
            Else
                parameterInternet.Value = "N"
            End If
            arParams(2) = parameterInternet

            Dim parameterOutOfHome As New SqlParameter("@OutOfHomeInc", SqlDbType.Char, 1)
            If OutOfHome = True Then
                parameterOutOfHome.Value = "Y"
            Else
                parameterOutOfHome.Value = "N"
            End If
            arParams(3) = parameterOutOfHome

            Dim parameterTelevision As New SqlParameter("@TelevisionInc", SqlDbType.Char, 1)
            If Television = True Then
                parameterTelevision.Value = "Y"
            Else
                parameterTelevision.Value = "N"
            End If
            arParams(4) = parameterTelevision

            Dim parameterRadio As New SqlParameter("@RadioInc", SqlDbType.Char, 1)
            If Radio = True Then
                parameterRadio.Value = "Y"
            Else
                parameterRadio.Value = "N"
            End If
            arParams(5) = parameterRadio

            Dim parameterAcceptedOrdersOnly As New SqlParameter("@AcceptedOrdersOnly", SqlDbType.Char, 1)
            If AcceptedOrdersOnly = True Then
                parameterAcceptedOrdersOnly.Value = "Y"
            Else
                parameterAcceptedOrdersOnly.Value = "N"
            End If
            arParams(6) = parameterAcceptedOrdersOnly

            Dim parameterClient As New SqlParameter("@ClientCode", SqlDbType.VarChar, 10)
            parameterClient.Value = Client
            arParams(7) = parameterClient

            Dim parameterDivision As New SqlParameter("@DivCode", SqlDbType.VarChar, 10)
            parameterDivision.Value = Division
            arParams(8) = parameterDivision

            Dim parameterProduct As New SqlParameter("@ProdCode", SqlDbType.VarChar, 10)
            parameterProduct.Value = Product
            arParams(9) = parameterProduct

            Dim parameterMediaType As New SqlParameter("@MediaType", SqlDbType.VarChar, 10)
            parameterMediaType.Value = MediaType
            arParams(10) = parameterMediaType

            Dim parameterCampaign As New SqlParameter("@Campaign", SqlDbType.VarChar, 100)
            parameterCampaign.Value = Campaign
            arParams(11) = parameterCampaign

            Dim parameterClientPO As New SqlParameter("@ClientPO", SqlDbType.VarChar, 100)
            parameterClientPO.Value = ClientPO
            arParams(12) = parameterClientPO

            Dim parameterVendor As New SqlParameter("@VendorID", SqlDbType.VarChar, 100)
            parameterVendor.Value = Vendor
            arParams(13) = parameterVendor

            Dim parameterBuyer As New SqlParameter("@BuyerID", SqlDbType.VarChar, 100)
            parameterBuyer.Value = Buyer
            arParams(14) = parameterBuyer

            Dim parameterStartDate As New SqlParameter("@StartDate", SqlDbType.VarChar, 10)
            parameterStartDate.Value = startDate.ToShortDateString
            arParams(15) = parameterStartDate

            Dim parameterEndDate As New SqlParameter("@EndDate", SqlDbType.VarChar, 10)
            parameterEndDate.Value = startDate.ToShortDateString
            arParams(16) = parameterEndDate

            Dim parameterMatDueDate As New SqlParameter("@MatDueDate", SqlDbType.Char, 1)
            If MatDueDate = True Then
                parameterMatDueDate.Value = "Y"
            Else
                parameterMatDueDate.Value = "N"
            End If
            arParams(17) = parameterMatDueDate

            Dim parameterExtMatDueDate As New SqlParameter("@ExtMatDueDate", SqlDbType.Char, 1)
            If ExtMatDueDate = True Then
                parameterExtMatDueDate.Value = "Y"
            Else
                parameterExtMatDueDate.Value = "N"
            End If
            arParams(18) = parameterExtMatDueDate

            Dim parameterCloseDate As New SqlParameter("@CloseDate", SqlDbType.Char, 1)
            If CloseDate2 = True Then
                parameterCloseDate.Value = "Y"
            Else
                parameterCloseDate.Value = "N"
            End If
            arParams(19) = parameterCloseDate

            Dim parameterExtCloseDate As New SqlParameter("@ExtCloseDate", SqlDbType.Char, 1)
            If ExtCloseDate2 = True Then
                parameterExtCloseDate.Value = "Y"
            Else
                parameterExtCloseDate.Value = "N"
            End If
            arParams(20) = parameterExtCloseDate

            Dim parameterRunInsertionDate As New SqlParameter("@RunInsertionDate", SqlDbType.Char, 1)
            If RunInsertionDate = True Then
                parameterRunInsertionDate.Value = "Y"
            Else
                parameterRunInsertionDate.Value = "N"
            End If
            arParams(21) = parameterRunInsertionDate

            Dim parameterMonth As New SqlParameter("@MediaMonth", SqlDbType.VarChar, 6)
            parameterMonth.Value = getMonthName(11)
            arParams(22) = parameterMonth

            Dim parameterYear As New SqlParameter("@MediaYear", SqlDbType.Int, 6)
            parameterYear.Value = startDate.Year
            arParams(23) = parameterYear

            Dim parameterCancelledOrders As New SqlParameter("@LineCancelled", SqlDbType.Char, 1)
            If CancelledOrders = True Then
                parameterCancelledOrders.Value = "Y"
            Else
                parameterCancelledOrders.Value = "N"
            End If
            arParams(24) = parameterCancelledOrders

            Dim parameterDebug As New SqlParameter("@debug", SqlDbType.Bit, 6)
            parameterDebug.Value = 0
            arParams(25) = parameterDebug

            Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
            parameterUserID.Value = UserID
            arParams(26) = parameterUserID

            Dim parameterOffice As New SqlParameter("@OfficeCode", SqlDbType.VarChar, 10)
            parameterOffice.Value = Office
            arParams(27) = parameterOffice

            Try
                dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_calendar_GetMediaData", arParams)
                dr2 = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_calendar_GetMediaData", arParams)
            Catch
                Err.Raise(Err.Number, "Class:cTaskCal Routine:GetTaskCalendar", Err.Description)
            End Try

            Dim dt As DataTable
            Dim row As DataRow
            Dim dt2 As DataTable
            Dim row2 As DataRow
            dt = New DataTable("mediaMonth")
            dt2 = New DataTable("mediaMonth2")
            Dim clientdc As DataColumn = New DataColumn("CL_CODE")
            Dim clientnamedc As DataColumn = New DataColumn("CL_NAME")
            Dim divisiondc As DataColumn = New DataColumn("DIV_CODE")
            Dim divisionnamedc As DataColumn = New DataColumn("DIV_NAME")
            Dim productdc As DataColumn = New DataColumn("PRD_CODE")
            Dim productnamedc As DataColumn = New DataColumn("PRD_DESCRIPTION")
            Dim typedc As DataColumn = New DataColumn("TYPE")
            Dim orderdc As DataColumn = New DataColumn("ORDER_NBR")
            Dim linedc As DataColumn = New DataColumn("LINE_NBR")
            Dim revisiondc As DataColumn = New DataColumn("REV_NBR")
            Dim vendorcodedc As DataColumn = New DataColumn("VN_CODE")
            Dim vendornamedc As DataColumn = New DataColumn("VN_NAME")
            Dim orderdescdc As DataColumn = New DataColumn("ORDER_DESC")
            Dim buyerdc As DataColumn = New DataColumn("BUYER")
            Dim closedatedc As DataColumn = New DataColumn("CLOSE_DATE")
            Dim linecanceleddc As DataColumn = New DataColumn("LINE_CANCELLED")
            Dim mediayeardc As DataColumn = New DataColumn("MEDIA_YEAR")
            Dim matcompdc As DataColumn = New DataColumn("MAT_COMP")

            Dim clientdc2 As DataColumn = New DataColumn("CL_CODE")
            Dim clientnamedc2 As DataColumn = New DataColumn("CL_NAME")
            Dim divisiondc2 As DataColumn = New DataColumn("DIV_CODE")
            Dim divisionnamedc2 As DataColumn = New DataColumn("DIV_NAME")
            Dim productdc2 As DataColumn = New DataColumn("PRD_CODE")
            Dim productnamedc2 As DataColumn = New DataColumn("PRD_DESCRIPTION")
            Dim typedc2 As DataColumn = New DataColumn("TYPE")
            Dim orderdc2 As DataColumn = New DataColumn("ORDER_NBR")
            Dim linedc2 As DataColumn = New DataColumn("LINE_NBR")
            Dim revisiondc2 As DataColumn = New DataColumn("REV_NBR")
            Dim vendorcodedc2 As DataColumn = New DataColumn("VN_CODE")
            Dim vendornamedc2 As DataColumn = New DataColumn("VN_NAME")
            Dim orderdescdc2 As DataColumn = New DataColumn("ORDER_DESC")
            Dim buyerdc2 As DataColumn = New DataColumn("BUYER")
            Dim closedatedc2 As DataColumn = New DataColumn("CLOSE_DATE")
            Dim linecanceleddc2 As DataColumn = New DataColumn("LINE_CANCELLED")
            Dim mediayeardc2 As DataColumn = New DataColumn("MEDIA_YEAR")
            Dim matcompdc2 As DataColumn = New DataColumn("MAT_COMP")

            dt.Columns.Add(clientdc)
            dt.Columns.Add(clientnamedc)
            dt.Columns.Add(divisiondc)
            dt.Columns.Add(divisionnamedc)
            dt.Columns.Add(productdc)
            dt.Columns.Add(productnamedc)
            dt.Columns.Add(typedc)
            dt.Columns.Add(orderdc)
            dt.Columns.Add(linedc)
            dt.Columns.Add(revisiondc)
            dt.Columns.Add(vendorcodedc)
            dt.Columns.Add(vendornamedc)
            dt.Columns.Add(orderdescdc)
            dt.Columns.Add(buyerdc)
            dt.Columns.Add(closedatedc)
            dt.Columns.Add(linecanceleddc)
            dt.Columns.Add(mediayeardc)
            dt.Columns.Add(matcompdc)

            dt2.Columns.Add(clientdc2)
            dt2.Columns.Add(clientnamedc2)
            dt2.Columns.Add(divisiondc2)
            dt2.Columns.Add(divisionnamedc2)
            dt2.Columns.Add(productdc2)
            dt2.Columns.Add(productnamedc2)
            dt2.Columns.Add(typedc2)
            dt2.Columns.Add(orderdc2)
            dt2.Columns.Add(linedc2)
            dt2.Columns.Add(revisiondc2)
            dt2.Columns.Add(vendorcodedc2)
            dt2.Columns.Add(vendornamedc2)
            dt2.Columns.Add(orderdescdc2)
            dt2.Columns.Add(buyerdc2)
            dt2.Columns.Add(closedatedc2)
            dt2.Columns.Add(linecanceleddc2)
            dt2.Columns.Add(mediayeardc2)
            dt2.Columns.Add(matcompdc2)
            row = dt.NewRow
            row2 = dt2.NewRow
            Do While dr.Read
                If RunInsertionDate = True And DisplayFlight = True And dr.GetDateTime(22).Date = startDate.Date Then
                    row.Item("CL_CODE") = dr.GetString(6)
                    row.Item("CL_NAME") = dr.GetString(58)
                    row.Item("DIV_CODE") = dr.GetString(7)
                    row.Item("DIV_NAME") = dr.GetString(59)
                    row.Item("PRD_CODE") = dr.GetString(8)
                    row.Item("PRD_DESCRIPTION") = dr.GetString(60)
                    row.Item("TYPE") = dr.GetString(0)
                    row.Item("ORDER_NBR") = dr.GetInt32(3)
                    row.Item("LINE_NBR") = dr.GetInt32(19)
                    row.Item("REV_NBR") = dr.GetInt32(61)
                    row.Item("VN_CODE") = dr.GetString(12)
                    row.Item("VN_NAME") = dr.GetString(13)
                    row.Item("ORDER_DESC") = dr.GetString(4)
                    row.Item("BUYER") = dr.GetString(14)
                    row.Item("CLOSE_DATE") = dr.GetDateTime(26)
                    row.Item("LINE_CANCELLED") = dr.GetInt32(57)
                    row.Item("MEDIA_YEAR") = dr.GetString(25)
                    row.Item("MAT_COMP") = dr.GetDateTime(62)
                    dt.Rows.Add(row)
                    row = dt.NewRow
                End If
                row2.Item("CL_CODE") = dr.GetString(6)
                row2.Item("CL_NAME") = dr.GetString(58)
                row2.Item("DIV_CODE") = dr.GetString(7)
                row2.Item("DIV_NAME") = dr.GetString(59)
                row2.Item("PRD_CODE") = dr.GetString(8)
                row2.Item("PRD_DESCRIPTION") = dr.GetString(60)
                row2.Item("TYPE") = dr.GetString(0)
                row2.Item("ORDER_NBR") = dr.GetInt32(3)
                row2.Item("LINE_NBR") = dr.GetInt32(19)
                row2.Item("REV_NBR") = dr.GetInt32(61)
                row2.Item("VN_CODE") = dr.GetString(12)
                row2.Item("VN_NAME") = dr.GetString(13)
                row2.Item("ORDER_DESC") = dr.GetString(4)
                row2.Item("BUYER") = dr.GetString(14)
                row2.Item("CLOSE_DATE") = dr.GetDateTime(26)
                row2.Item("LINE_CANCELLED") = dr.GetInt32(57)
                row2.Item("MEDIA_YEAR") = dr.GetString(25)
                row2.Item("MAT_COMP") = dr.GetDateTime(62)
                dt2.Rows.Add(row2)
                row2 = dt2.NewRow

            Loop
            dr.Close()
            dr2.Close()
            If RunInsertionDate = True And DisplayFlight = True Then
                Return dt
            Else
                Return dt2
            End If



        End Function
        Public Function GetMediaWeek(ByVal startDate As Date,
                                        ByVal UserID As String,
                                        Optional ByVal Client As String = "",
                                        Optional ByVal Division As String = "",
                                        Optional ByVal Product As String = "",
                                        Optional ByVal MediaType As String = "",
                                        Optional ByVal Campaign As String = "",
                                        Optional ByVal ClientPO As String = "",
                                        Optional ByVal Vendor As String = "",
                                        Optional ByVal Buyer As String = "",
                                        Optional ByVal Magazine As Boolean = False,
                                        Optional ByVal NewsPaper As Boolean = False,
                                        Optional ByVal Internet As Boolean = False,
                                        Optional ByVal OutOfHome As Boolean = False,
                                        Optional ByVal Television As Boolean = False,
                                        Optional ByVal Radio As Boolean = False,
                                        Optional ByVal AcceptedOrdersOnly As Boolean = False,
                                        Optional ByVal CancelledOrders As Boolean = False,
                                        Optional ByVal ClientCode As Boolean = False,
                                        Optional ByVal DivisionCode As Boolean = False,
                                        Optional ByVal ProductCode As Boolean = False,
                                        Optional ByVal Type As Boolean = False,
                                        Optional ByVal MType As Boolean = False,
                                        Optional ByVal InsertionLine As Boolean = False,
                                        Optional ByVal VendorCode As Boolean = False,
                                        Optional ByVal VendorName As Boolean = False,
                                        Optional ByVal JobComp As Boolean = False,
                                        Optional ByVal CampaignCode As Boolean = False,
                                        Optional ByVal CampaignName As Boolean = False,
                                        Optional ByVal MarketCode As Boolean = False,
                                        Optional ByVal MarketName As Boolean = False,
                                        Optional ByVal AdSizeLength As Boolean = False,
                                        Optional ByVal HeadlineProg As Boolean = False,
                                        Optional ByVal ExtMatDate As Boolean = False,
                                        Optional ByVal CloseDate As Boolean = False,
                                        Optional ByVal ExtCloseDate As Boolean = False,
                                        Optional ByVal RunDate As Boolean = False,
                                        Optional ByVal BillingAmount As Boolean = False,
                                        Optional ByVal Spots As Boolean = False,
                                        Optional ByVal MatDueDate As Boolean = False,
                                        Optional ByVal ExtMatDueDate As Boolean = False,
                                        Optional ByVal CloseDate2 As Boolean = False,
                                        Optional ByVal ExtCloseDate2 As Boolean = False,
                                        Optional ByVal RunInsertionDate As Boolean = False,
                                        Optional ByVal DisplayFlight As Boolean = False,
                                        Optional ByVal Office As String = "") As DataTable

            Dim ThisMonth As Month
            Dim ThisWeek As Week
            Dim ThisDay As Date
            Dim ThisDayLink As String
            Dim dr As SqlClient.SqlDataReader
            Dim dr2 As SqlClient.SqlDataReader
            Dim I As Integer
            Dim arTasks(31) As String
            Dim strShow As String
            Dim arParams(27) As SqlParameter
            Dim strCompleted As String
            Dim taskLink As String

            'Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
            'parameterUserID.Value = UserID
            'arParams(0) = parameterUserID

            Dim parameterMagazine As New SqlParameter("@MagazineInc", SqlDbType.Char, 1)
            If Magazine = True Then
                parameterMagazine.Value = "Y"
            Else
                parameterMagazine.Value = "N"
            End If
            arParams(0) = parameterMagazine

            Dim parameterNewspaper As New SqlParameter("@NewspaperInc", SqlDbType.Char, 1)
            If NewsPaper = True Then
                parameterNewspaper.Value = "Y"
            Else
                parameterNewspaper.Value = "N"
            End If
            arParams(1) = parameterNewspaper

            Dim parameterInternet As New SqlParameter("@InternetInc", SqlDbType.Char, 1)
            If Internet = True Then
                parameterInternet.Value = "Y"
            Else
                parameterInternet.Value = "N"
            End If
            arParams(2) = parameterInternet

            Dim parameterOutOfHome As New SqlParameter("@OutOfHomeInc", SqlDbType.Char, 1)
            If OutOfHome = True Then
                parameterOutOfHome.Value = "Y"
            Else
                parameterOutOfHome.Value = "N"
            End If
            arParams(3) = parameterOutOfHome

            Dim parameterTelevision As New SqlParameter("@TelevisionInc", SqlDbType.Char, 1)
            If Television = True Then
                parameterTelevision.Value = "Y"
            Else
                parameterTelevision.Value = "N"
            End If
            arParams(4) = parameterTelevision

            Dim parameterRadio As New SqlParameter("@RadioInc", SqlDbType.Char, 1)
            If Radio = True Then
                parameterRadio.Value = "Y"
            Else
                parameterRadio.Value = "N"
            End If
            arParams(5) = parameterRadio

            Dim parameterAcceptedOrdersOnly As New SqlParameter("@AcceptedOrdersOnly", SqlDbType.Char, 1)
            If AcceptedOrdersOnly = True Then
                parameterAcceptedOrdersOnly.Value = "Y"
            Else
                parameterAcceptedOrdersOnly.Value = "N"
            End If
            arParams(6) = parameterAcceptedOrdersOnly

            Dim parameterClient As New SqlParameter("@ClientCode", SqlDbType.VarChar, 10)
            parameterClient.Value = Client
            arParams(7) = parameterClient

            Dim parameterDivision As New SqlParameter("@DivCode", SqlDbType.VarChar, 10)
            parameterDivision.Value = Division
            arParams(8) = parameterDivision

            Dim parameterProduct As New SqlParameter("@ProdCode", SqlDbType.VarChar, 10)
            parameterProduct.Value = Product
            arParams(9) = parameterProduct

            Dim parameterMediaType As New SqlParameter("@MediaType", SqlDbType.VarChar, 10)
            parameterMediaType.Value = MediaType
            arParams(10) = parameterMediaType

            Dim parameterCampaign As New SqlParameter("@Campaign", SqlDbType.VarChar, 100)
            parameterCampaign.Value = Campaign
            arParams(11) = parameterCampaign

            Dim parameterClientPO As New SqlParameter("@ClientPO", SqlDbType.VarChar, 100)
            parameterClientPO.Value = ClientPO
            arParams(12) = parameterClientPO

            Dim parameterVendor As New SqlParameter("@VendorID", SqlDbType.VarChar, 100)
            parameterVendor.Value = Vendor
            arParams(13) = parameterVendor

            Dim parameterBuyer As New SqlParameter("@BuyerID", SqlDbType.VarChar, 100)
            parameterBuyer.Value = Buyer
            arParams(14) = parameterBuyer

            Dim parameterStartDate As New SqlParameter("@StartDate", SqlDbType.VarChar, 10)
            parameterStartDate.Value = startDate.ToShortDateString
            arParams(15) = parameterStartDate

            Dim parameterEndDate As New SqlParameter("@EndDate", SqlDbType.VarChar, 10)
            parameterEndDate.Value = startDate.ToShortDateString
            arParams(16) = parameterEndDate

            Dim parameterMatDueDate As New SqlParameter("@MatDueDate", SqlDbType.Char, 1)
            If MatDueDate = True Then
                parameterMatDueDate.Value = "Y"
            Else
                parameterMatDueDate.Value = "N"
            End If
            arParams(17) = parameterMatDueDate

            Dim parameterExtMatDueDate As New SqlParameter("@ExtMatDueDate", SqlDbType.Char, 1)
            If ExtMatDueDate = True Then
                parameterExtMatDueDate.Value = "Y"
            Else
                parameterExtMatDueDate.Value = "N"
            End If
            arParams(18) = parameterExtMatDueDate

            Dim parameterCloseDate As New SqlParameter("@CloseDate", SqlDbType.Char, 1)
            If CloseDate2 = True Then
                parameterCloseDate.Value = "Y"
            Else
                parameterCloseDate.Value = "N"
            End If
            arParams(19) = parameterCloseDate

            Dim parameterExtCloseDate As New SqlParameter("@ExtCloseDate", SqlDbType.Char, 1)
            If ExtCloseDate2 = True Then
                parameterExtCloseDate.Value = "Y"
            Else
                parameterExtCloseDate.Value = "N"
            End If
            arParams(20) = parameterExtCloseDate

            Dim parameterRunInsertionDate As New SqlParameter("@RunInsertionDate", SqlDbType.Char, 1)
            If RunInsertionDate = True Then
                parameterRunInsertionDate.Value = "Y"
            Else
                parameterRunInsertionDate.Value = "N"
            End If
            arParams(21) = parameterRunInsertionDate

            Dim parameterMonth As New SqlParameter("@MediaMonth", SqlDbType.VarChar, 6)
            parameterMonth.Value = getMonthName(11)
            arParams(22) = parameterMonth

            Dim parameterYear As New SqlParameter("@MediaYear", SqlDbType.Int, 6)
            parameterYear.Value = startDate.Year
            arParams(23) = parameterYear

            Dim parameterCancelledOrders As New SqlParameter("@LineCancelled", SqlDbType.Char, 1)
            If CancelledOrders = True Then
                parameterCancelledOrders.Value = "Y"
            Else
                parameterCancelledOrders.Value = "N"
            End If
            arParams(24) = parameterCancelledOrders

            Dim parameterDebug As New SqlParameter("@debug", SqlDbType.Bit, 6)
            parameterDebug.Value = 0
            arParams(25) = parameterDebug

            Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
            parameterUserID.Value = UserID
            arParams(26) = parameterUserID

            Dim parameterOffice As New SqlParameter("@OfficeCode", SqlDbType.VarChar, 10)
            parameterOffice.Value = Office
            arParams(27) = parameterOffice

            Try
                dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_calendar_GetMediaData", arParams)
                dr2 = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_calendar_GetMediaData", arParams)
            Catch
                Err.Raise(Err.Number, "Class:cTaskCal Routine:GetTaskCalendar", Err.Description)
            End Try

            Dim dt As DataTable
            Dim row As DataRow
            Dim dt2 As DataTable
            Dim row2 As DataRow
            dt = New DataTable("mediaMonth")
            dt2 = New DataTable("mediaMonth2")
            Dim clientdc As DataColumn = New DataColumn("CL_CODE")
            Dim clientnamedc As DataColumn = New DataColumn("CL_NAME")
            Dim divisiondc As DataColumn = New DataColumn("DIV_CODE")
            Dim divisionnamedc As DataColumn = New DataColumn("DIV_NAME")
            Dim productdc As DataColumn = New DataColumn("PRD_CODE")
            Dim productnamedc As DataColumn = New DataColumn("PRD_DESCRIPTION")
            Dim typedc As DataColumn = New DataColumn("TYPE")
            Dim orderdc As DataColumn = New DataColumn("ORDER_NBR")
            Dim linedc As DataColumn = New DataColumn("LINE_NBR")
            Dim revisiondc As DataColumn = New DataColumn("REV_NBR")
            Dim vendorcodedc As DataColumn = New DataColumn("VN_CODE")
            Dim vendornamedc As DataColumn = New DataColumn("VN_NAME")
            Dim orderdescdc As DataColumn = New DataColumn("ORDER_DESC")
            Dim buyerdc As DataColumn = New DataColumn("BUYER")
            Dim closedatedc As DataColumn = New DataColumn("CLOSE_DATE")
            Dim linecanceleddc As DataColumn = New DataColumn("LINE_CANCELLED")
            Dim mediayeardc As DataColumn = New DataColumn("MEDIA_YEAR")
            Dim matcompdc As DataColumn = New DataColumn("MAT_COMP")

            Dim clientdc2 As DataColumn = New DataColumn("CL_CODE")
            Dim clientnamedc2 As DataColumn = New DataColumn("CL_NAME")
            Dim divisiondc2 As DataColumn = New DataColumn("DIV_CODE")
            Dim divisionnamedc2 As DataColumn = New DataColumn("DIV_NAME")
            Dim productdc2 As DataColumn = New DataColumn("PRD_CODE")
            Dim productnamedc2 As DataColumn = New DataColumn("PRD_DESCRIPTION")
            Dim typedc2 As DataColumn = New DataColumn("TYPE")
            Dim orderdc2 As DataColumn = New DataColumn("ORDER_NBR")
            Dim linedc2 As DataColumn = New DataColumn("LINE_NBR")
            Dim revisiondc2 As DataColumn = New DataColumn("REV_NBR")
            Dim vendorcodedc2 As DataColumn = New DataColumn("VN_CODE")
            Dim vendornamedc2 As DataColumn = New DataColumn("VN_NAME")
            Dim orderdescdc2 As DataColumn = New DataColumn("ORDER_DESC")
            Dim buyerdc2 As DataColumn = New DataColumn("BUYER")
            Dim closedatedc2 As DataColumn = New DataColumn("CLOSE_DATE")
            Dim linecanceleddc2 As DataColumn = New DataColumn("LINE_CANCELLED")
            Dim mediayeardc2 As DataColumn = New DataColumn("MEDIA_YEAR")
            Dim matcompdc2 As DataColumn = New DataColumn("MAT_COMP")

            dt.Columns.Add(clientdc)
            dt.Columns.Add(clientnamedc)
            dt.Columns.Add(divisiondc)
            dt.Columns.Add(divisionnamedc)
            dt.Columns.Add(productdc)
            dt.Columns.Add(productnamedc)
            dt.Columns.Add(typedc)
            dt.Columns.Add(orderdc)
            dt.Columns.Add(linedc)
            dt.Columns.Add(revisiondc)
            dt.Columns.Add(vendorcodedc)
            dt.Columns.Add(vendornamedc)
            dt.Columns.Add(orderdescdc)
            dt.Columns.Add(buyerdc)
            dt.Columns.Add(closedatedc)
            dt.Columns.Add(linecanceleddc)
            dt.Columns.Add(mediayeardc)
            dt.Columns.Add(matcompdc)

            dt2.Columns.Add(clientdc2)
            dt2.Columns.Add(clientnamedc2)
            dt2.Columns.Add(divisiondc2)
            dt2.Columns.Add(divisionnamedc2)
            dt2.Columns.Add(productdc2)
            dt2.Columns.Add(productnamedc2)
            dt2.Columns.Add(typedc2)
            dt2.Columns.Add(orderdc2)
            dt2.Columns.Add(linedc2)
            dt2.Columns.Add(revisiondc2)
            dt2.Columns.Add(vendorcodedc2)
            dt2.Columns.Add(vendornamedc2)
            dt2.Columns.Add(orderdescdc2)
            dt2.Columns.Add(buyerdc2)
            dt2.Columns.Add(closedatedc2)
            dt2.Columns.Add(linecanceleddc2)
            dt2.Columns.Add(mediayeardc2)
            dt2.Columns.Add(matcompdc2)
            row = dt.NewRow
            row2 = dt2.NewRow
            Do While dr.Read
                If RunInsertionDate = True And DisplayFlight = True And dr.GetDateTime(22).Date = startDate.Date Then
                    row.Item("CL_CODE") = dr.GetString(6)
                    row.Item("CL_NAME") = dr.GetString(58)
                    row.Item("DIV_CODE") = dr.GetString(7)
                    row.Item("DIV_NAME") = dr.GetString(59)
                    row.Item("PRD_CODE") = dr.GetString(8)
                    row.Item("PRD_DESCRIPTION") = dr.GetString(60)
                    row.Item("TYPE") = dr.GetString(0)
                    row.Item("ORDER_NBR") = dr.GetInt32(3)
                    row.Item("LINE_NBR") = dr.GetInt32(19)
                    row.Item("REV_NBR") = dr.GetInt32(61)
                    row.Item("VN_CODE") = dr.GetString(12)
                    row.Item("VN_NAME") = dr.GetString(13)
                    row.Item("ORDER_DESC") = dr.GetString(4)
                    row.Item("BUYER") = dr.GetString(14)
                    row.Item("CLOSE_DATE") = dr.GetDateTime(26)
                    row.Item("LINE_CANCELLED") = dr.GetInt32(57)
                    row.Item("MEDIA_YEAR") = dr.GetString(25)
                    row.Item("MAT_COMP") = dr.GetDateTime(62)
                    dt.Rows.Add(row)
                    row = dt.NewRow
                End If
                row2.Item("CL_CODE") = dr.GetString(6)
                row2.Item("CL_NAME") = dr.GetString(58)
                row2.Item("DIV_CODE") = dr.GetString(7)
                row2.Item("DIV_NAME") = dr.GetString(59)
                row2.Item("PRD_CODE") = dr.GetString(8)
                row2.Item("PRD_DESCRIPTION") = dr.GetString(60)
                row2.Item("TYPE") = dr.GetString(0)
                row2.Item("ORDER_NBR") = dr.GetInt32(3)
                row2.Item("LINE_NBR") = dr.GetInt32(19)
                row2.Item("REV_NBR") = dr.GetInt32(61)
                row2.Item("VN_CODE") = dr.GetString(12)
                row2.Item("VN_NAME") = dr.GetString(13)
                row2.Item("ORDER_DESC") = dr.GetString(4)
                row2.Item("BUYER") = dr.GetString(14)
                row2.Item("CLOSE_DATE") = dr.GetDateTime(26)
                row2.Item("LINE_CANCELLED") = dr.GetInt32(57)
                row2.Item("MEDIA_YEAR") = dr.GetString(25)
                row2.Item("MAT_COMP") = dr.GetDateTime(62)
                dt2.Rows.Add(row2)
                row2 = dt2.NewRow

            Loop
            dr.Close()
            dr2.Close()
            If RunInsertionDate = True And DisplayFlight = True Then
                Return dt
            Else
                Return dt2
            End If

        End Function
        Public Function GetMediaMonthPrint(ByVal Month As Integer,
                                        ByVal Year As Integer,
                                        ByVal UserID As String,
                                        Optional ByVal Client As String = "",
                                        Optional ByVal Division As String = "",
                                        Optional ByVal Product As String = "",
                                        Optional ByVal MediaType As String = "",
                                        Optional ByVal Campaign As String = "",
                                        Optional ByVal ClientPO As String = "",
                                        Optional ByVal Vendor As String = "",
                                        Optional ByVal Buyer As String = "",
                                        Optional ByVal Magazine As Boolean = False,
                                        Optional ByVal NewsPaper As Boolean = False,
                                        Optional ByVal Internet As Boolean = False,
                                        Optional ByVal OutOfHome As Boolean = False,
                                        Optional ByVal Television As Boolean = False,
                                        Optional ByVal Radio As Boolean = False,
                                        Optional ByVal AcceptedOrdersOnly As Boolean = False,
                                        Optional ByVal CancelledOrders As Boolean = False,
                                        Optional ByVal ClientCode As Boolean = False,
                                        Optional ByVal DivisionCode As Boolean = False,
                                        Optional ByVal ProductCode As Boolean = False,
                                        Optional ByVal Type As Boolean = False,
                                        Optional ByVal MType As Boolean = False,
                                        Optional ByVal InsertionLine As Boolean = False,
                                        Optional ByVal VendorCode As Boolean = False,
                                        Optional ByVal VendorName As Boolean = False,
                                        Optional ByVal JobComp As Boolean = False,
                                        Optional ByVal CampaignCode As Boolean = False,
                                        Optional ByVal CampaignName As Boolean = False,
                                        Optional ByVal MarketCode As Boolean = False,
                                        Optional ByVal MarketName As Boolean = False,
                                        Optional ByVal AdSizeLength As Boolean = False,
                                        Optional ByVal HeadlineProg As Boolean = False,
                                        Optional ByVal ExtMatDate As Boolean = False,
                                        Optional ByVal CloseDate As Boolean = False,
                                        Optional ByVal ExtCloseDate As Boolean = False,
                                        Optional ByVal RunDate As Boolean = False,
                                        Optional ByVal BillingAmount As Boolean = False,
                                        Optional ByVal Spots As Boolean = False,
                                        Optional ByVal MatDueDate As Boolean = False,
                                        Optional ByVal ExtMatDueDate As Boolean = False,
                                        Optional ByVal CloseDate2 As Boolean = False,
                                        Optional ByVal ExtCloseDate2 As Boolean = False,
                                        Optional ByVal RunInsertionDate As Boolean = False,
                                        Optional ByVal DisplayFlight As Boolean = False,
                                        Optional ByVal Print As Boolean = False,
                                        Optional ByVal Office As String = "") As DataTable

            Dim intDaysInMonth As Integer
            Dim ThisMonth As Month
            Dim ThisWeek As Week
            Dim ThisDay As Date
            Dim ThisDayLink As String
            Dim dr As SqlClient.SqlDataReader
            Dim I As Integer
            Dim arTasks(31) As String
            Dim strShow As String
            Dim arParams(28) As SqlParameter
            Dim strCompleted As String
            Dim taskLink As String
            Dim printCal As Boolean

            Dim parameterMagazine As New SqlParameter("@MagazineInc", SqlDbType.Char, 1)
            If Magazine = True Then
                parameterMagazine.Value = "Y"
            Else
                parameterMagazine.Value = "N"
            End If
            arParams(0) = parameterMagazine

            Dim parameterNewspaper As New SqlParameter("@NewspaperInc", SqlDbType.Char, 1)
            If NewsPaper = True Then
                parameterNewspaper.Value = "Y"
            Else
                parameterNewspaper.Value = "N"
            End If
            arParams(1) = parameterNewspaper

            Dim parameterInternet As New SqlParameter("@InternetInc", SqlDbType.Char, 1)
            If Internet = True Then
                parameterInternet.Value = "Y"
            Else
                parameterInternet.Value = "N"
            End If
            arParams(2) = parameterInternet

            Dim parameterOutOfHome As New SqlParameter("@OutOfHomeInc", SqlDbType.Char, 1)
            If OutOfHome = True Then
                parameterOutOfHome.Value = "Y"
            Else
                parameterOutOfHome.Value = "N"
            End If
            arParams(3) = parameterOutOfHome

            Dim parameterTelevision As New SqlParameter("@TelevisionInc", SqlDbType.Char, 1)
            If Television = True Then
                parameterTelevision.Value = "Y"
            Else
                parameterTelevision.Value = "N"
            End If
            arParams(4) = parameterTelevision

            Dim parameterRadio As New SqlParameter("@RadioInc", SqlDbType.Char, 1)
            If Radio = True Then
                parameterRadio.Value = "Y"
            Else
                parameterRadio.Value = "N"
            End If
            arParams(5) = parameterRadio

            Dim parameterAcceptedOrdersOnly As New SqlParameter("@AcceptedOrdersOnly", SqlDbType.Char, 1)
            If AcceptedOrdersOnly = True Then
                parameterAcceptedOrdersOnly.Value = "Y"
            Else
                parameterAcceptedOrdersOnly.Value = "N"
            End If
            arParams(6) = parameterAcceptedOrdersOnly

            Dim parameterClient As New SqlParameter("@ClientCode", SqlDbType.VarChar, 10)
            parameterClient.Value = Client
            arParams(7) = parameterClient

            Dim parameterDivision As New SqlParameter("@DivCode", SqlDbType.VarChar, 10)
            parameterDivision.Value = Division
            arParams(8) = parameterDivision

            Dim parameterProduct As New SqlParameter("@ProdCode", SqlDbType.VarChar, 10)
            parameterProduct.Value = Product
            arParams(9) = parameterProduct

            Dim parameterMediaType As New SqlParameter("@MediaType", SqlDbType.VarChar, 10)
            parameterMediaType.Value = MediaType
            arParams(10) = parameterMediaType

            Dim parameterCampaign As New SqlParameter("@Campaign", SqlDbType.VarChar, 100)
            parameterCampaign.Value = Campaign
            arParams(11) = parameterCampaign

            Dim parameterClientPO As New SqlParameter("@ClientPO", SqlDbType.VarChar, 100)
            parameterClientPO.Value = ClientPO
            arParams(12) = parameterClientPO

            Dim parameterVendor As New SqlParameter("@VendorID", SqlDbType.VarChar, 100)
            parameterVendor.Value = Vendor
            arParams(13) = parameterVendor

            Dim parameterBuyer As New SqlParameter("@BuyerID", SqlDbType.VarChar, 100)
            parameterBuyer.Value = Buyer
            arParams(14) = parameterBuyer

            Dim parameterStartDate As New SqlParameter("@StartDate", SqlDbType.VarChar, 10)
            parameterStartDate.Value = CStr(Month) & "/" & CStr(1) & "/" & CStr(Year)
            arParams(15) = parameterStartDate

            intDaysInMonth = Date.DaysInMonth(Year, Month)
            Dim parameterEndDate As New SqlParameter("@EndDate", SqlDbType.VarChar, 10)
            parameterEndDate.Value = CStr(Month) & "/" & CStr(intDaysInMonth) & "/" & CStr(Year)
            arParams(16) = parameterEndDate

            Dim parameterMatDueDate As New SqlParameter("@MatDueDate", SqlDbType.Char, 1)
            If MatDueDate = True Then
                parameterMatDueDate.Value = "Y"
            Else
                parameterMatDueDate.Value = "N"
            End If
            arParams(17) = parameterMatDueDate

            Dim parameterExtMatDueDate As New SqlParameter("@ExtMatDueDate", SqlDbType.Char, 1)
            If ExtMatDueDate = True Then
                parameterExtMatDueDate.Value = "Y"
            Else
                parameterExtMatDueDate.Value = "N"
            End If
            arParams(18) = parameterExtMatDueDate

            Dim parameterCloseDate As New SqlParameter("@CloseDate", SqlDbType.Char, 1)
            If CloseDate2 = True Then
                parameterCloseDate.Value = "Y"
            Else
                parameterCloseDate.Value = "N"
            End If
            arParams(19) = parameterCloseDate

            Dim parameterExtCloseDate As New SqlParameter("@ExtCloseDate", SqlDbType.Char, 1)
            If ExtCloseDate2 = True Then
                parameterExtCloseDate.Value = "Y"
            Else
                parameterExtCloseDate.Value = "N"
            End If
            arParams(20) = parameterExtCloseDate

            Dim parameterRunInsertionDate As New SqlParameter("@RunInsertionDate", SqlDbType.Char, 1)
            If RunInsertionDate = True Then
                parameterRunInsertionDate.Value = "Y"
            Else
                parameterRunInsertionDate.Value = "N"
            End If
            arParams(21) = parameterRunInsertionDate

            Dim parameterMonth As New SqlParameter("@MediaMonth", SqlDbType.VarChar, 6)
            parameterMonth.Value = getMonthName(Month)
            arParams(22) = parameterMonth

            Dim parameterYear As New SqlParameter("@MediaYear", SqlDbType.Int, 6)
            parameterYear.Value = Year
            arParams(23) = parameterYear

            Dim parameterCancelledOrders As New SqlParameter("@LineCancelled", SqlDbType.Char, 1)
            If CancelledOrders = True Then
                parameterCancelledOrders.Value = "Y"
            Else
                parameterCancelledOrders.Value = "N"
            End If
            arParams(24) = parameterCancelledOrders

            Dim parameterDebug As New SqlParameter("@debug", SqlDbType.Bit, 6)
            parameterDebug.Value = 0
            arParams(25) = parameterDebug

            Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
            parameterUserID.Value = UserID
            arParams(26) = parameterUserID

            Dim parameterOfficeCode As New SqlParameter("@OfficeCode", SqlDbType.VarChar, 100)
            parameterOfficeCode.Value = Office
            arParams(27) = parameterOfficeCode

            Try
                dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_calendar_GetMediaData", arParams)
            Catch
                Err.Raise(Err.Number, "Class:cTaskCal Routine:GetTaskCalendar", Err.Description)
            End Try

            'Initial Array
            For I = 1 To 31
                arTasks(I) = ""
            Next

            Do While dr.Read
                If ClientCode = True And dr.GetString(6) <> "" Then
                    strShow = strShow & dr.GetString(6) & "|"
                End If
                If DivisionCode = True And dr.GetString(7) <> "" Then
                    strShow = strShow & dr.GetString(7) & "|"
                End If
                If ProductCode = True And dr.GetString(8) <> "" Then
                    strShow = strShow & dr.GetString(8) & "|"
                End If
                If Type = True And dr.GetString(0) <> "" Then
                    strShow = strShow & dr.GetString(0) & "|"
                End If
                If MType = True And dr.GetString(5) <> "" Then
                    strShow = strShow & dr.GetString(5) & "|"
                End If
                If InsertionLine = True Then
                    strShow = strShow & Convert.ToString(dr.GetInt32(3)) & "-" & Convert.ToString(dr.GetInt32(19)) & "|"
                End If
                If VendorCode = True And dr.GetString(12) <> "" Then
                    strShow = strShow & dr.GetString(12) & "|"
                End If
                If VendorName = True And dr.GetString(13) <> "" Then
                    strShow = strShow & dr.GetString(13) & "|"
                End If
                If JobComp = True Then
                    strShow = strShow & dr.GetString(48) & "-" & dr.GetString(49) & "|"
                End If
                If CampaignCode = True And dr.GetString(10) <> "" Then
                    strShow = strShow & dr.GetString(10) & "|"
                End If
                If CampaignName = True And dr.GetString(11) <> "" Then
                    strShow = strShow & dr.GetString(11) & "|"
                End If
                If MarketCode = True And dr.GetString(16) <> "" Then
                    strShow = strShow & dr.GetString(16) & "|"
                End If
                If MarketName = True And dr.GetString(17) <> "" Then
                    strShow = strShow & dr.GetString(17) & "|"
                End If
                If AdSizeLength = True And dr.GetString(0) = "R" And dr.GetString(43) <> "" Or AdSizeLength = True And dr.GetString(0) = "T" And dr.GetString(43) <> "" Then
                    strShow = strShow & dr.GetString(43) & "|"
                ElseIf AdSizeLength = True And dr.GetString(30) <> "" Then
                    strShow = strShow & dr.GetString(30) & "|"
                End If
                If HeadlineProg = True And dr.GetString(0) = "R" And dr.GetString(45) <> "" Or HeadlineProg = True And dr.GetString(0) = "T" And dr.GetString(45) <> "" Then
                    strShow = strShow & dr.GetString(45) & "|"
                ElseIf HeadlineProg = True And dr.GetString(35) <> "" Then
                    strShow = strShow & dr.GetString(35) & "|"
                End If
                If ExtMatDate = True And dr.GetDateTime(29).Date.ToShortDateString <> "" Then
                    strShow = strShow & dr.GetDateTime(29).Date.ToShortDateString & "|"
                End If
                If CloseDate = True And dr.GetDateTime(26).Date.ToShortDateString <> "" Then
                    strShow = strShow & dr.GetDateTime(26).Date.ToShortDateString & "|"
                End If
                If ExtCloseDate = True And dr.GetDateTime(28).Date.ToShortDateString <> "" Then
                    strShow = strShow & dr.GetDateTime(28).Date.ToShortDateString & "|"
                End If
                If RunDate = True And dr.GetString(0) = "R" And dr.GetString(21) <> "" Or RunDate = True And dr.GetString(0) = "T" And dr.GetString(21) <> "" Then
                    strShow = strShow & dr.GetString(21) & "|"
                ElseIf RunDate = True And dr.GetDateTime(22).Date.ToShortDateString <> "" Then
                    strShow = strShow & dr.GetDateTime(22).Date.ToShortDateString & "|"
                End If
                If BillingAmount = True Then
                    strShow = strShow & dr.GetString(56) & "|"
                End If
                If Spots = True And dr.GetString(0) = "R" Or Spots = True And dr.GetString(0) = "T" Then
                    strShow = strShow & dr.GetString(57) & "|"
                End If
                If MatDueDate = True Or ExtMatDueDate = True Or CloseDate2 = True Or ExtCloseDate2 = True Then
                    Dim day As Integer
                    If MatDueDate = True Then
                        day = dr.GetDateTime(27).Day
                    End If
                    If ExtMatDueDate = True Then
                        day = dr.GetDateTime(29).Day
                    End If
                    If CloseDate2 = True Then
                        day = dr.GetDateTime(26).Day
                    End If
                    If ExtCloseDate2 = True Then
                        day = dr.GetDateTime(28).Day
                    End If
                    strShow = strShow.Substring(0, strShow.Length - 1)
                    'If strShow.Length > 15 Then
                    '    arTasks(day) = arTasks(day) & "<span class='" & strCompleted & "'>" & strShow.Substring(0, 16) & vbCrLf & "&nbsp;" & strShow.Substring(16, 16) & vbCrLf & "&nbsp;" & strShow.Substring(32) & "</span>" & "<br />"

                    'arTasks(day) = arTasks(day) & "<span class='" & strCompleted & "'>" & strShow & "</span>" & "<br />"
                    If dr.GetString(0) = "M" And dr.GetInt32(57) = 1 Then
                        arTasks(day) = arTasks(day) & strShow & "(CANCELLED)" & vbCrLf
                    ElseIf dr.GetString(0) = "M" And dr.GetDateTime(62) <> "1/1/1900" Then
                        arTasks(day) = arTasks(day) & strShow & "(COMPLETE)" & vbCrLf
                    ElseIf dr.GetString(0) = "M" Then
                        arTasks(day) = arTasks(day) & strShow & vbCrLf
                    End If
                    If dr.GetString(0) = "N" And dr.GetInt32(57) = 1 Then
                        arTasks(day) = arTasks(day) & strShow & "(CANCELLED)" & vbCrLf
                    ElseIf dr.GetString(0) = "N" And dr.GetDateTime(62) <> "1/1/1900" Then
                        arTasks(day) = arTasks(day) & strShow & "(COMPLETE)" & vbCrLf
                    ElseIf dr.GetString(0) = "N" Then
                        arTasks(day) = arTasks(day) & strShow & vbCrLf
                    End If
                    If dr.GetString(0) = "I" And dr.GetInt32(57) = 1 Then
                        arTasks(day) = arTasks(day) & strShow & "(CANCELLED)" & vbCrLf
                    ElseIf dr.GetString(0) = "I" And dr.GetDateTime(62) <> "1/1/1900" Then
                        arTasks(day) = arTasks(day) & strShow & "(COMPLETE)" & vbCrLf
                    ElseIf dr.GetString(0) = "I" Then
                        arTasks(day) = arTasks(day) & strShow & vbCrLf
                    End If
                    If dr.GetString(0) = "O" And dr.GetInt32(57) = 1 Then
                        arTasks(day) = arTasks(day) & strShow & "(CANCELLED)" & vbCrLf
                    ElseIf dr.GetString(0) = "O" And dr.GetDateTime(62) <> "1/1/1900" Then
                        arTasks(day) = arTasks(day) & strShow & "(COMPLETE)" & vbCrLf
                    ElseIf dr.GetString(0) = "O" Then
                        arTasks(day) = arTasks(day) & strShow & vbCrLf
                    End If
                    If dr.GetString(0) = "R" And dr.GetInt32(57) = 1 Then
                        arTasks(day) = arTasks(day) & strShow & "(CANCELLED)" & vbCrLf
                    ElseIf dr.GetString(0) = "R" And dr.GetDateTime(62) <> "1/1/1900" Then
                        arTasks(day) = arTasks(day) & strShow & "(COMPLETE)" & vbCrLf
                    ElseIf dr.GetString(0) = "R" Then
                        arTasks(day) = arTasks(day) & strShow & vbCrLf
                    End If
                    If dr.GetString(0) = "T" And dr.GetInt32(57) = 1 Then
                        arTasks(day) = arTasks(day) & strShow & "(CANCELLED)" & vbCrLf
                    ElseIf dr.GetString(0) = "T" And dr.GetDateTime(62) <> "1/1/1900" Then
                        arTasks(day) = arTasks(day) & strShow & "(COMPLETE)" & vbCrLf
                    ElseIf dr.GetString(0) = "T" Then
                        arTasks(day) = arTasks(day) & strShow & vbCrLf
                    End If

                    'End If

                End If

                If RunInsertionDate = True And DisplayFlight = True And dr.GetDateTime(22) >= Convert.ToDateTime(parameterStartDate.Value).Date And dr.GetDateTime(22) <= Convert.ToDateTime(parameterEndDate.Value).Date Then
                    If dr.GetString(0) = "M" And dr.GetInt32(57) = 1 Then
                        arTasks(dr.GetDateTime(22).Day) = arTasks(dr.GetDateTime(22).Day) & strShow & "(CANCELLED)" & vbCrLf
                    ElseIf dr.GetString(0) = "M" Then
                        arTasks(dr.GetDateTime(22).Day) = arTasks(dr.GetDateTime(22).Day) & strShow & vbCrLf
                    End If
                    If dr.GetString(0) = "N" And dr.GetInt32(57) = 1 Then
                        arTasks(dr.GetDateTime(22).Day) = arTasks(dr.GetDateTime(22).Day) & strShow & "(CANCELLED)" & vbCrLf
                    ElseIf dr.GetString(0) = "N" Then
                        arTasks(dr.GetDateTime(22).Day) = arTasks(dr.GetDateTime(22).Day) & strShow & vbCrLf
                    End If
                    If dr.GetString(0) = "I" And dr.GetInt32(57) = 1 Then
                        arTasks(dr.GetDateTime(22).Day) = arTasks(dr.GetDateTime(22).Day) & strShow & "(CANCELLED)" & vbCrLf
                    ElseIf dr.GetString(0) = "I" Then
                        arTasks(dr.GetDateTime(22).Day) = arTasks(dr.GetDateTime(22).Day) & strShow & vbCrLf
                    End If
                    If dr.GetString(0) = "O" And dr.GetInt32(57) = 1 Then
                        arTasks(dr.GetDateTime(22).Day) = arTasks(dr.GetDateTime(22).Day) & strShow & "(CANCELLED)" & vbCrLf
                    ElseIf dr.GetString(0) = "O" Then
                        arTasks(dr.GetDateTime(22).Day) = arTasks(dr.GetDateTime(22).Day) & strShow & vbCrLf
                    End If
                    If dr.GetString(0) = "R" And dr.GetInt32(57) = 1 Then
                        arTasks(dr.GetDateTime(22).Day) = arTasks(dr.GetDateTime(22).Day) & strShow & "(CANCELLED)" & vbCrLf
                    ElseIf dr.GetString(0) = "R" Then
                        arTasks(dr.GetDateTime(22).Day) = arTasks(dr.GetDateTime(22).Day) & strShow & vbCrLf
                    End If
                    If dr.GetString(0) = "T" And dr.GetInt32(57) = 1 Then
                        arTasks(dr.GetDateTime(22).Day) = arTasks(dr.GetDateTime(22).Day) & strShow & "(CANCELLED)" & vbCrLf
                    ElseIf dr.GetString(0) = "T" Then
                        arTasks(dr.GetDateTime(22).Day) = arTasks(dr.GetDateTime(22).Day) & strShow & vbCrLf
                    End If
                ElseIf RunInsertionDate = True And DisplayFlight = False Then
                    Dim days As String = dr.GetString(21)
                    Dim startday As DateTime = dr.GetDateTime(22)
                    Dim endday As DateTime = dr.GetDateTime(23)
                    Dim j As Integer
                    If startday.Month.ToString() = Month And startday.Year.ToString() = Year And endday.Month.ToString() = Month And endday.Year.ToString() = Year Then
                        For j = startday.Day To endday.Day
                            'arTasks(j) = arTasks(j) & "" & strShow & vbCrLf
                            If dr.GetString(0) = "M" And dr.GetInt32(57) = 1 And j = endday.Day Then
                                arTasks(j) = arTasks(j) & strShow & "(CANCELLED)" & vbCrLf
                            ElseIf dr.GetString(0) = "M" And j = endday.Day Then
                                arTasks(j) = arTasks(j) & strShow & vbCrLf
                            ElseIf dr.GetString(0) = "M" And dr.GetInt32(57) = 1 Then
                                arTasks(j) = arTasks(j) & strShow & "(CANCELLED)" & vbCrLf
                            ElseIf dr.GetString(0) = "M" Then
                                arTasks(j) = arTasks(j) & strShow & vbCrLf
                            End If
                            If dr.GetString(0) = "N" And dr.GetInt32(57) = 1 And j = endday.Day Then
                                arTasks(j) = arTasks(j) & strShow & "(CANCELLED)" & vbCrLf
                            ElseIf dr.GetString(0) = "N" And j = endday.Day Then
                                arTasks(j) = arTasks(j) & strShow & vbCrLf
                            ElseIf dr.GetString(0) = "N" And dr.GetInt32(57) = 1 Then
                                arTasks(j) = arTasks(j) & strShow & "(CANCELLED)" & vbCrLf
                            ElseIf dr.GetString(0) = "N" Then
                                arTasks(j) = arTasks(j) & strShow & vbCrLf
                            End If
                            If dr.GetString(0) = "I" And dr.GetInt32(57) = 1 And j = endday.Day Then
                                arTasks(j) = arTasks(j) & strShow & "(CANCELLED)" & vbCrLf
                            ElseIf dr.GetString(0) = "I" And j = endday.Day Then
                                arTasks(j) = arTasks(j) & strShow & vbCrLf
                            ElseIf dr.GetString(0) = "I" And dr.GetInt32(57) = 1 Then
                                arTasks(j) = arTasks(j) & strShow & "(CANCELLED)" & vbCrLf
                            ElseIf dr.GetString(0) = "I" Then
                                arTasks(j) = arTasks(j) & strShow & vbCrLf
                            End If
                            If dr.GetString(0) = "O" And dr.GetInt32(57) = 1 And j = endday.Day Then
                                arTasks(j) = arTasks(j) & strShow & "(CANCELLED)" & vbCrLf
                            ElseIf dr.GetString(0) = "O" And j = endday.Day Then
                                arTasks(j) = arTasks(j) & strShow & vbCrLf
                            ElseIf dr.GetString(0) = "O" And dr.GetInt32(57) = 1 Then
                                arTasks(j) = arTasks(j) & strShow & "(CANCELLED)" & vbCrLf
                            ElseIf dr.GetString(0) = "O" Then
                                arTasks(j) = arTasks(j) & strShow & vbCrLf
                            End If
                            If dr.GetString(0) = "R" And dr.GetInt32(57) = 1 And j = endday.Day Then
                                arTasks(j) = arTasks(j) & strShow & "(CANCELLED)" & vbCrLf
                            ElseIf dr.GetString(0) = "R" And j = endday.Day Then
                                arTasks(j) = arTasks(j) & strShow & vbCrLf
                            ElseIf dr.GetString(0) = "R" And dr.GetInt32(57) = 1 Then
                                arTasks(j) = arTasks(j) & strShow & "(CANCELLED)" & vbCrLf
                            ElseIf dr.GetString(0) = "R" Then
                                arTasks(j) = arTasks(j) & strShow & vbCrLf
                            End If
                            If dr.GetString(0) = "T" And dr.GetInt32(57) = 1 And j = endday.Day Then
                                arTasks(j) = arTasks(j) & strShow & "(CANCELLED)" & vbCrLf
                            ElseIf dr.GetString(0) = "T" And j = endday.Day Then
                                arTasks(j) = arTasks(j) & strShow & vbCrLf
                            ElseIf dr.GetString(0) = "T" And dr.GetInt32(57) = 1 Then
                                arTasks(j) = arTasks(j) & strShow & "(CANCELLED)" & vbCrLf
                            ElseIf dr.GetString(0) = "T" Then
                                arTasks(j) = arTasks(j) & strShow & vbCrLf
                            End If
                        Next
                    ElseIf startday.Month.ToString() = Month And startday.Year.ToString() = Year And endday.Month.ToString() <> Month Then
                        For j = startday.Day To intDaysInMonth
                            ' arTasks(j) = arTasks(j) & "" & strShow & vbCrLf
                            If dr.GetString(0) = "M" And dr.GetInt32(57) = 1 And j = endday.Day Then
                                arTasks(j) = arTasks(j) & strShow & "(CANCELLED)" & vbCrLf
                            ElseIf dr.GetString(0) = "M" And j = endday.Day Then
                                arTasks(j) = arTasks(j) & strShow & vbCrLf
                            ElseIf dr.GetString(0) = "M" And dr.GetInt32(57) = 1 Then
                                arTasks(j) = arTasks(j) & strShow & "(CANCELLED)" & vbCrLf
                            ElseIf dr.GetString(0) = "M" Then
                                arTasks(j) = arTasks(j) & strShow & vbCrLf
                            End If
                            If dr.GetString(0) = "N" And dr.GetInt32(57) = 1 And j = endday.Day Then
                                arTasks(j) = arTasks(j) & strShow & "(CANCELLED)" & vbCrLf
                            ElseIf dr.GetString(0) = "N" And j = endday.Day Then
                                arTasks(j) = arTasks(j) & strShow & vbCrLf
                            ElseIf dr.GetString(0) = "N" And dr.GetInt32(57) = 1 Then
                                arTasks(j) = arTasks(j) & strShow & "(CANCELLED)" & vbCrLf
                            ElseIf dr.GetString(0) = "N" Then
                                arTasks(j) = arTasks(j) & strShow & vbCrLf
                            End If
                            If dr.GetString(0) = "I" And dr.GetInt32(57) = 1 And j = endday.Day Then
                                arTasks(j) = arTasks(j) & strShow & "(CANCELLED)" & vbCrLf
                            ElseIf dr.GetString(0) = "I" And j = endday.Day Then
                                arTasks(j) = arTasks(j) & strShow & vbCrLf
                            ElseIf dr.GetString(0) = "I" And dr.GetInt32(57) = 1 Then
                                arTasks(j) = arTasks(j) & strShow & "(CANCELLED)" & vbCrLf
                            ElseIf dr.GetString(0) = "I" Then
                                arTasks(j) = arTasks(j) & strShow & vbCrLf
                            End If
                            If dr.GetString(0) = "O" And dr.GetInt32(57) = 1 And j = endday.Day Then
                                arTasks(j) = arTasks(j) & strShow & "(CANCELLED)" & vbCrLf
                            ElseIf dr.GetString(0) = "O" And j = endday.Day Then
                                arTasks(j) = arTasks(j) & strShow & vbCrLf
                            ElseIf dr.GetString(0) = "O" And dr.GetInt32(57) = 1 Then
                                arTasks(j) = arTasks(j) & strShow & "(CANCELLED)" & vbCrLf
                            ElseIf dr.GetString(0) = "O" Then
                                arTasks(j) = arTasks(j) & strShow & vbCrLf
                            End If
                            If dr.GetString(0) = "R" And dr.GetInt32(57) = 1 And j = endday.Day Then
                                arTasks(j) = arTasks(j) & strShow & "(CANCELLED)" & vbCrLf
                            ElseIf dr.GetString(0) = "R" And j = endday.Day Then
                                arTasks(j) = arTasks(j) & strShow & vbCrLf
                            ElseIf dr.GetString(0) = "R" And dr.GetInt32(57) = 1 Then
                                arTasks(j) = arTasks(j) & strShow & "(CANCELLED)" & vbCrLf
                            ElseIf dr.GetString(0) = "R" Then
                                arTasks(j) = arTasks(j) & strShow & vbCrLf
                            End If
                            If dr.GetString(0) = "T" And dr.GetInt32(57) = 1 And j = endday.Day Then
                                arTasks(j) = arTasks(j) & strShow & "(CANCELLED)" & vbCrLf
                            ElseIf dr.GetString(0) = "T" And j = endday.Day Then
                                arTasks(j) = arTasks(j) & strShow & vbCrLf
                            ElseIf dr.GetString(0) = "T" And dr.GetInt32(57) = 1 Then
                                arTasks(j) = arTasks(j) & strShow & "(CANCELLED)" & vbCrLf
                            ElseIf dr.GetString(0) = "T" Then
                                arTasks(j) = arTasks(j) & strShow & vbCrLf
                            End If
                        Next
                    ElseIf startday.Month.ToString() <> Month And endday.Month.ToString() = Month Then
                        For j = 1 To intDaysInMonth
                            'arTasks(j) = arTasks(j) & "" & strShow & vbCrLf
                            If dr.GetString(0) = "M" And dr.GetInt32(57) = 1 And j = endday.Day Then
                                arTasks(j) = arTasks(j) & strShow & "(CANCELLED)" & vbCrLf
                            ElseIf dr.GetString(0) = "M" And j = endday.Day Then
                                arTasks(j) = arTasks(j) & strShow & vbCrLf
                            ElseIf dr.GetString(0) = "M" And dr.GetInt32(57) = 1 Then
                                arTasks(j) = arTasks(j) & strShow & "(CANCELLED)" & vbCrLf
                            ElseIf dr.GetString(0) = "M" Then
                                arTasks(j) = arTasks(j) & strShow & vbCrLf
                            End If
                            If dr.GetString(0) = "N" And dr.GetInt32(57) = 1 And j = endday.Day Then
                                arTasks(j) = arTasks(j) & strShow & "(CANCELLED)" & vbCrLf
                            ElseIf dr.GetString(0) = "N" And j = endday.Day Then
                                arTasks(j) = arTasks(j) & strShow & vbCrLf
                            ElseIf dr.GetString(0) = "N" And dr.GetInt32(57) = 1 Then
                                arTasks(j) = arTasks(j) & strShow & "(CANCELLED)" & vbCrLf
                            ElseIf dr.GetString(0) = "N" Then
                                arTasks(j) = arTasks(j) & strShow & vbCrLf
                            End If
                            If dr.GetString(0) = "I" And dr.GetInt32(57) = 1 And j = endday.Day Then
                                arTasks(j) = arTasks(j) & strShow & "(CANCELLED)" & vbCrLf
                            ElseIf dr.GetString(0) = "I" And j = endday.Day Then
                                arTasks(j) = arTasks(j) & strShow & vbCrLf
                            ElseIf dr.GetString(0) = "I" And dr.GetInt32(57) = 1 Then
                                arTasks(j) = arTasks(j) & strShow & "(CANCELLED)" & vbCrLf
                            ElseIf dr.GetString(0) = "I" Then
                                arTasks(j) = arTasks(j) & strShow & vbCrLf
                            End If
                            If dr.GetString(0) = "O" And dr.GetInt32(57) = 1 And j = endday.Day Then
                                arTasks(j) = arTasks(j) & strShow & "(CANCELLED)" & vbCrLf
                            ElseIf dr.GetString(0) = "O" And j = endday.Day Then
                                arTasks(j) = arTasks(j) & strShow & vbCrLf
                            ElseIf dr.GetString(0) = "O" And dr.GetInt32(57) = 1 Then
                                arTasks(j) = arTasks(j) & strShow & "(CANCELLED)" & vbCrLf
                            ElseIf dr.GetString(0) = "O" Then
                                arTasks(j) = arTasks(j) & strShow & vbCrLf
                            End If
                            If dr.GetString(0) = "R" And dr.GetInt32(57) = 1 And j = endday.Day Then
                                arTasks(j) = arTasks(j) & strShow & "(CANCELLED)" & vbCrLf
                            ElseIf dr.GetString(0) = "R" And j = endday.Day Then
                                arTasks(j) = arTasks(j) & strShow & vbCrLf
                            ElseIf dr.GetString(0) = "R" And dr.GetInt32(57) = 1 Then
                                arTasks(j) = arTasks(j) & strShow & "(CANCELLED)" & vbCrLf
                            ElseIf dr.GetString(0) = "R" Then
                                arTasks(j) = arTasks(j) & strShow & vbCrLf
                            End If
                            If dr.GetString(0) = "T" And dr.GetInt32(57) = 1 And j = endday.Day Then
                                arTasks(j) = arTasks(j) & strShow & "(CANCELLED)" & vbCrLf
                            ElseIf dr.GetString(0) = "T" And j = endday.Day Then
                                arTasks(j) = arTasks(j) & strShow & vbCrLf
                            ElseIf dr.GetString(0) = "T" And dr.GetInt32(57) = 1 Then
                                arTasks(j) = arTasks(j) & strShow & "(CANCELLED)" & vbCrLf
                            ElseIf dr.GetString(0) = "T" Then
                                arTasks(j) = arTasks(j) & strShow & vbCrLf
                            End If
                        Next
                    ElseIf Convert.ToDateTime(parameterStartDate.Value).Date >= startday.Date And Convert.ToDateTime(parameterEndDate.Value).Date <= endday.Date Then
                        For j = 1 To endday.Day
                            'arTasks(j) = arTasks(j) & "" & strShow & vbCrLf
                            If dr.GetString(0) = "M" And dr.GetInt32(57) = 1 And j = endday.Day Then
                                arTasks(j) = arTasks(j) & strShow & "(CANCELLED)" & vbCrLf
                            ElseIf dr.GetString(0) = "M" And j = endday.Day Then
                                arTasks(j) = arTasks(j) & strShow & vbCrLf
                            ElseIf dr.GetString(0) = "M" And dr.GetInt32(57) = 1 Then
                                arTasks(j) = arTasks(j) & strShow & "(CANCELLED)" & vbCrLf
                            ElseIf dr.GetString(0) = "M" Then
                                arTasks(j) = arTasks(j) & strShow & vbCrLf
                            End If
                            If dr.GetString(0) = "N" And dr.GetInt32(57) = 1 And j = endday.Day Then
                                arTasks(j) = arTasks(j) & strShow & "(CANCELLED)" & vbCrLf
                            ElseIf dr.GetString(0) = "N" And j = endday.Day Then
                                arTasks(j) = arTasks(j) & strShow & vbCrLf
                            ElseIf dr.GetString(0) = "N" And dr.GetInt32(57) = 1 Then
                                arTasks(j) = arTasks(j) & strShow & "(CANCELLED)" & vbCrLf
                            ElseIf dr.GetString(0) = "N" Then
                                arTasks(j) = arTasks(j) & strShow & vbCrLf
                            End If
                            If dr.GetString(0) = "I" And dr.GetInt32(57) = 1 And j = endday.Day Then
                                arTasks(j) = arTasks(j) & strShow & "(CANCELLED)" & vbCrLf
                            ElseIf dr.GetString(0) = "I" And j = endday.Day Then
                                arTasks(j) = arTasks(j) & strShow & vbCrLf
                            ElseIf dr.GetString(0) = "I" And dr.GetInt32(57) = 1 Then
                                arTasks(j) = arTasks(j) & strShow & "(CANCELLED)" & vbCrLf
                            ElseIf dr.GetString(0) = "I" Then
                                arTasks(j) = arTasks(j) & strShow & vbCrLf
                            End If
                            If dr.GetString(0) = "O" And dr.GetInt32(57) = 1 And j = endday.Day Then
                                arTasks(j) = arTasks(j) & strShow & "(CANCELLED)" & vbCrLf
                            ElseIf dr.GetString(0) = "O" And j = endday.Day Then
                                arTasks(j) = arTasks(j) & strShow & vbCrLf
                            ElseIf dr.GetString(0) = "O" And dr.GetInt32(57) = 1 Then
                                arTasks(j) = arTasks(j) & strShow & "(CANCELLED)" & vbCrLf
                            ElseIf dr.GetString(0) = "O" Then
                                arTasks(j) = arTasks(j) & strShow & vbCrLf
                            End If
                            If dr.GetString(0) = "R" And dr.GetInt32(57) = 1 And j = endday.Day Then
                                arTasks(j) = arTasks(j) & strShow & "(CANCELLED)" & vbCrLf
                            ElseIf dr.GetString(0) = "R" And j = endday.Day Then
                                arTasks(j) = arTasks(j) & strShow & vbCrLf
                            ElseIf dr.GetString(0) = "R" And dr.GetInt32(57) = 1 Then
                                arTasks(j) = arTasks(j) & strShow & "(CANCELLED)" & vbCrLf
                            ElseIf dr.GetString(0) = "R" Then
                                arTasks(j) = arTasks(j) & strShow & vbCrLf
                            End If
                            If dr.GetString(0) = "T" And dr.GetInt32(57) = 1 And j = endday.Day Then
                                arTasks(j) = arTasks(j) & strShow & "(CANCELLED)" & vbCrLf
                            ElseIf dr.GetString(0) = "T" And j = endday.Day Then
                                arTasks(j) = arTasks(j) & strShow & vbCrLf
                            ElseIf dr.GetString(0) = "T" And dr.GetInt32(57) = 1 Then
                                arTasks(j) = arTasks(j) & strShow & "(CANCELLED)" & vbCrLf
                            ElseIf dr.GetString(0) = "T" Then
                                arTasks(j) = arTasks(j) & strShow & vbCrLf
                            End If
                        Next
                    End If
                End If
                strShow = ""
            Loop

            Dim dt As DataTable
            Dim row As DataRow
            dt = New DataTable("mediaMonth")
            Dim sunday As DataColumn = New DataColumn("Sunday")
            Dim monday As DataColumn = New DataColumn("Monday")
            Dim tuesday As DataColumn = New DataColumn("Tuesday")
            Dim wednesday As DataColumn = New DataColumn("Wednesday")
            Dim thursday As DataColumn = New DataColumn("Thursday")
            Dim friday As DataColumn = New DataColumn("Friday")
            Dim saturday As DataColumn = New DataColumn("Saturday")
            dt.Columns.Add(sunday)
            dt.Columns.Add(monday)
            dt.Columns.Add(tuesday)
            dt.Columns.Add(wednesday)
            dt.Columns.Add(thursday)
            dt.Columns.Add(friday)
            dt.Columns.Add(saturday)
            row = dt.NewRow

            For I = 1 To intDaysInMonth
                ThisDay = CDate(Month & "/" & CStr(I) & "/" & Year)
                Select Case ThisDay.DayOfWeek
                    Case DayOfWeek.Sunday
                        If arTasks(I).Length > 0 Then
                            row.Item("Sunday") = I & vbCrLf & arTasks(I)
                        Else
                            row.Item("Sunday") = I
                        End If
                    Case DayOfWeek.Monday
                        If arTasks(I).Length > 0 Then
                            row.Item("Monday") = I & vbCrLf & arTasks(I)
                        Else
                            row.Item("Monday") = I
                        End If
                    Case DayOfWeek.Tuesday
                        If arTasks(I).Length > 0 Then
                            row.Item("Tuesday") = I & vbCrLf & arTasks(I)
                        Else
                            row.Item("Tuesday") = I
                        End If
                    Case DayOfWeek.Wednesday
                        If arTasks(I).Length > 0 Then
                            row.Item("Wednesday") = I & vbCrLf & arTasks(I)
                        Else
                            row.Item("Wednesday") = I
                        End If
                    Case DayOfWeek.Thursday
                        If arTasks(I).Length > 0 Then
                            row.Item("Thursday") = I & vbCrLf & arTasks(I)
                        Else
                            row.Item("Thursday") = I
                        End If
                    Case DayOfWeek.Friday
                        If arTasks(I).Length > 0 Then
                            row.Item("Friday") = I & vbCrLf & arTasks(I)
                        Else
                            row.Item("Friday") = I
                        End If
                    Case DayOfWeek.Saturday
                        If arTasks(I).Length > 0 Then
                            row.Item("Saturday") = I & vbCrLf & arTasks(I)
                        Else
                            row.Item("Saturday") = I
                        End If
                End Select
                If ThisDay.DayOfWeek = DayOfWeek.Saturday Or ThisDay.Day = intDaysInMonth Then
                    dt.Rows.Add(row)
                    row = dt.NewRow
                End If
            Next I

            dr.Close()
            Dim c As Integer = dt.Rows.Count
            Dim d As String = dt.Rows(0).Item(5).ToString
            Dim f As String = dt.Rows.Count

            Return dt

        End Function

        Public Function AddNewTask(ByVal holiday As Boolean, ByVal appointment As Boolean, ByVal subject As String, ByVal allday As Boolean, ByVal startdate As Date, ByVal enddate As Date, ByVal starttime As DateTime, ByVal endtime As DateTime, ByVal EmpCode As String, ByVal Category As String, ByVal indicator As String, ByVal standardHours As Decimal) As Boolean

            Dim arParams(13) As SqlParameter

            Dim parameterType As New SqlParameter("@Type", SqlDbType.VarChar, 6)
            If holiday = True Then
                parameterType.Value = "H"
            ElseIf appointment = True Then
                parameterType.Value = "A"
            End If
            arParams(0) = parameterType

            Dim parameterDate As New SqlParameter("@StartDate", SqlDbType.DateTime, 12)
            parameterDate.Value = startdate.Date
            arParams(1) = parameterDate

            Dim parameterEnddate As New SqlParameter("@EndDate", SqlDbType.DateTime, 12)
            parameterEnddate.Value = enddate.Date
            arParams(2) = parameterEnddate

            Dim parameterAllDay As New SqlParameter("@Allday", SqlDbType.Int, 2)
            If allday = True Then
                parameterAllDay.Value = 1
            Else
                parameterAllDay.Value = 0
            End If
            arParams(3) = parameterAllDay

            Dim parameterSubject As New SqlParameter("@Nontaskdesc", SqlDbType.VarChar, 100)
            parameterSubject.Value = subject
            arParams(4) = parameterSubject

            Dim parameterStarttime As New SqlParameter("@Starttime", SqlDbType.DateTime, 26)
            If appointment = True And allday = True Then
                parameterStarttime.Value = Convert.ToDateTime(startdate.Date.ToShortDateString & " 12:00:00 AM")
            Else
                parameterStarttime.Value = Convert.ToDateTime(startdate.Date.ToShortDateString & " " & starttime.Hour.ToString() & ":" & starttime.Minute.ToString() & ":" & starttime.Second.ToString())
            End If

            arParams(5) = parameterStarttime

            Dim parameterEndtime As New SqlParameter("@Endtime", SqlDbType.DateTime, 26)
            If appointment = True And allday = True Then
                parameterEndtime.Value = Convert.ToDateTime(enddate.Date.ToShortDateString & " 11:59:00 PM")
            Else
                parameterEndtime.Value = Convert.ToDateTime(enddate.Date.ToShortDateString & " " & endtime.Hour.ToString() & ":" & endtime.Minute.ToString() & ":" & endtime.Second.ToString())
            End If
            arParams(6) = parameterEndtime

            Dim days As Integer
            Dim hrs As Decimal
            If startdate.Date <> enddate.Date And allday = True And appointment = True Then
                hrs = getHoursOverDuration(startdate, enddate, EmpCode)
            ElseIf startdate.Date <> enddate.Date And allday = False And appointment = True Then
                'Dim start As DateTime = Convert.ToDateTime(startdate.Date.ToShortDateString & " " & starttime.Hour.ToString()& ":" & starttime.Minute.ToString()& ":" & starttime.Second.ToString())
                'Dim endd As DateTime = Convert.ToDateTime(enddate.Date.ToShortDateString & " " & endtime.Hour.ToString()& ":" & endtime.Minute.ToString()& ":" & endtime.Second.ToString())
                'hrs = getHoursOverDuration(start, endd, EmpCode)
                hrs = getHoursOverDuration(startdate, enddate, EmpCode)
            ElseIf holiday = True And allday = True Then
                hrs = 0.0
            ElseIf startdate.Date = enddate.Date And allday = True And appointment = True Then
                hrs = standardHours
            Else
                hrs = endtime.Subtract(starttime).TotalHours
                If hrs > standardHours Then
                    hrs = standardHours
                End If
            End If

            Dim parameterHours As New SqlParameter("@Hours", SqlDbType.Decimal, 15)
            parameterHours.Value = hrs
            arParams(7) = parameterHours

            Dim parameterEmpCode As New SqlParameter("@Empcode", SqlDbType.VarChar, 6)
            parameterEmpCode.Value = EmpCode
            arParams(8) = parameterEmpCode

            Dim parameterCategory As New SqlParameter("@Category", SqlDbType.VarChar, 10)
            parameterCategory.Value = Category
            arParams(9) = parameterCategory

            Dim parameterJob As New SqlParameter("@JobNumber", SqlDbType.Int, 2)
            parameterJob.Value = Nothing
            arParams(10) = parameterJob

            Dim parameterJobComp As New SqlParameter("@JobCompNumber", SqlDbType.SmallInt, 2)
            parameterJobComp.Value = Nothing
            arParams(11) = parameterJobComp

            Dim parameterFunc As New SqlParameter("@Fnccode", SqlDbType.VarChar, 6)
            parameterFunc.Value = Nothing
            arParams(12) = parameterFunc


            Try
                InsertKey = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_nontask_new", arParams)
            Catch
                Err.Raise(Err.Number, "Class:cTaskCal Routine:TaskNew", Err.Description)
                Return False
            End Try

            Return True
        End Function
        Public Function AddNewActivity(ByVal type As String,
                                       ByVal subject As String,
                                       ByVal allday As Boolean,
                                       ByVal startdate As Date,
                                       ByVal enddate As Date,
                                       ByVal starttime As DateTime,
                                       ByVal endtime As DateTime,
                                       ByVal EmpCode As String,
                                       ByVal Category As String,
                                       ByVal indicator As String,
                                       ByVal standardHours As Decimal,
                                       ByVal clientcode As String,
                                       ByVal divisioncode As String,
                                       ByVal productcode As String,
                                       ByVal jobnumber As Integer,
                                       ByVal compnumber As Integer,
                                       ByVal priority As Integer,
                                       ByVal reminder As String,
                                       ByVal recurrence As String,
                                       ByVal taskcode As String,
                                       ByVal description As String,
                                       ByVal functioncode As String,
                                       ByVal recurrenceParent As Integer,
                                       ByVal cdpcontactid As Integer,
                                       ByVal descriptionHTML As String)

            Dim arParams(24) As SqlParameter

            Dim parameterType As New SqlParameter("@Type", SqlDbType.VarChar, 6)
            parameterType.Value = type
            arParams(0) = parameterType

            Dim parameterDate As New SqlParameter("@StartDate", SqlDbType.DateTime, 12)
            parameterDate.Value = startdate.Date
            arParams(1) = parameterDate

            Dim parameterEnddate As New SqlParameter("@EndDate", SqlDbType.DateTime, 12)
            parameterEnddate.Value = enddate.Date
            arParams(2) = parameterEnddate

            Dim parameterAllDay As New SqlParameter("@Allday", SqlDbType.Int, 2)
            If allday = True Then
                parameterAllDay.Value = 1
            Else
                parameterAllDay.Value = 0
            End If
            arParams(3) = parameterAllDay

            Dim parameterSubject As New SqlParameter("@Nontaskdesc", SqlDbType.VarChar, 100)
            parameterSubject.Value = subject
            arParams(4) = parameterSubject

            Dim parameterStarttime As New SqlParameter("@Starttime", SqlDbType.DateTime, 26)
            If type <> "H" And allday = True Then
                parameterStarttime.Value = Convert.ToDateTime(startdate.Date.ToShortDateString & " 12:00:00 AM")
            Else
                parameterStarttime.Value = Convert.ToDateTime(startdate.Date.ToShortDateString & " " & starttime.Hour.ToString() & ":" & starttime.Minute.ToString() & ":" & starttime.Second.ToString())
            End If

            arParams(5) = parameterStarttime

            Dim parameterEndtime As New SqlParameter("@Endtime", SqlDbType.DateTime, 26)
            If type <> "H" And allday = True Then
                parameterEndtime.Value = Convert.ToDateTime(enddate.Date.ToShortDateString & " 11:59:00 PM")
            Else
                parameterEndtime.Value = Convert.ToDateTime(enddate.Date.ToShortDateString & " " & endtime.Hour.ToString() & ":" & endtime.Minute.ToString() & ":" & endtime.Second.ToString())
            End If
            arParams(6) = parameterEndtime

            Dim days As Integer
            Dim hrs As Decimal
            Dim stdhrs As Decimal

            If startdate.Date <> enddate.Date And allday = True And type <> "H" Then
                hrs = getHoursOverDuration(startdate, enddate, EmpCode)
            ElseIf startdate.Date <> enddate.Date And allday = False And type <> "H" Then
                'Dim start As DateTime = Convert.ToDateTime(startdate.Date.ToShortDateString & " " & starttime.Hour.ToString()& ":" & starttime.Minute.ToString()& ":" & starttime.Second.ToString())
                'Dim endd As DateTime = Convert.ToDateTime(enddate.Date.ToShortDateString & " " & endtime.Hour.ToString()& ":" & endtime.Minute.ToString()& ":" & endtime.Second.ToString())
                'hrs = getHoursOverDuration(start, endd, EmpCode)
                hrs = getHoursOverDuration(startdate, enddate, EmpCode)
            ElseIf type = "H" And allday = True Then
                hrs = 0.0
            ElseIf startdate.Date = enddate.Date And allday = True And type <> "H" Then
                hrs = getHoursOverDuration(startdate, enddate, EmpCode)
            Else
                stdhrs = getHoursOverDuration(startdate, enddate, EmpCode)
                hrs = endtime.Subtract(starttime).TotalHours
                If hrs > stdhrs Then
                    hrs = stdhrs
                End If
            End If

            Dim parameterHours As New SqlParameter("@Hours", SqlDbType.Decimal, 15)
            parameterHours.Value = hrs
            arParams(7) = parameterHours

            Dim parameterEmpCode As New SqlParameter("@Empcode", SqlDbType.VarChar, 6)
            If EmpCode = "" Then
                parameterEmpCode.Value = DBNull.Value
            Else
                parameterEmpCode.Value = EmpCode
            End If
            arParams(8) = parameterEmpCode

            Dim parameterCategory As New SqlParameter("@Category", SqlDbType.VarChar, 10)
            parameterCategory.Value = Category
            arParams(9) = parameterCategory

            Dim parameterJob As New SqlParameter("@JobNumber", SqlDbType.Int)
            If jobnumber = 0 Then
                parameterJob.Value = DBNull.Value
            Else
                parameterJob.Value = jobnumber
            End If
            arParams(10) = parameterJob

            Dim parameterJobComp As New SqlParameter("@JobCompNumber", SqlDbType.SmallInt)
            If compnumber = 0 Then
                parameterJobComp.Value = DBNull.Value
            Else
                parameterJobComp.Value = compnumber
            End If
            arParams(11) = parameterJobComp

            Dim parameterFunc As New SqlParameter("@Fnccode", SqlDbType.VarChar, 6)
            If functioncode = "" Then
                parameterFunc.Value = DBNull.Value
            Else
                parameterFunc.Value = functioncode
            End If
            arParams(12) = parameterFunc

            Dim parameterClient As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
            parameterClient.Value = clientcode
            arParams(13) = parameterClient

            Dim parameterDivision As New SqlParameter("@DivisionCode", SqlDbType.VarChar, 6)
            parameterDivision.Value = divisioncode
            arParams(14) = parameterDivision

            Dim parameterProduct As New SqlParameter("@ProductCode", SqlDbType.VarChar, 6)
            parameterProduct.Value = productcode
            arParams(15) = parameterProduct

            Dim parameterPriority As New SqlParameter("@Priority", SqlDbType.Int)
            parameterPriority.Value = priority
            arParams(16) = parameterPriority

            Dim parameterReminder As New SqlParameter("@Reminder", SqlDbType.NVarChar)
            'If reminder = 0 Then
            '    parameterReminder.Value = DBNull.Value
            'Else
            parameterReminder.Value = reminder
            'End If
            arParams(17) = parameterReminder

            Dim parameterRecurrence As New SqlParameter("@Recurrence", SqlDbType.NVarChar)
            parameterRecurrence.Value = recurrence
            arParams(18) = parameterRecurrence

            Dim parameterTaskCode As New SqlParameter("@TaskCode", SqlDbType.VarChar)
            parameterTaskCode.Value = taskcode
            arParams(19) = parameterTaskCode

            Dim parameterDescription As New SqlParameter("@Description", SqlDbType.Text)
            parameterDescription.Value = description
            arParams(20) = parameterDescription

            Dim parameterRecurrenceParent As New SqlParameter("@RecurrenceParent", SqlDbType.Int)
            If recurrenceParent = 0 Then
                parameterRecurrenceParent.Value = DBNull.Value
            Else
                parameterRecurrenceParent.Value = recurrenceParent
            End If
            arParams(21) = parameterRecurrenceParent

            Dim parameterCDPContactID As New SqlParameter("@CDPContactID", SqlDbType.Int)
            If cdpcontactid = 0 Then
                parameterCDPContactID.Value = DBNull.Value
            Else
                parameterCDPContactID.Value = cdpcontactid
            End If
            arParams(22) = parameterCDPContactID

            Dim parameterDescriptionHTML As New SqlParameter("@DescriptionHTML", SqlDbType.Text)
            parameterDescriptionHTML.Value = descriptionHTML
            arParams(23) = parameterDescriptionHTML


            Try
                InsertKey = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_nontask_new", arParams)
            Catch
                Err.Raise(Err.Number, "Class:cTaskCal Routine:TaskNew", Err.Description)
                Return -1
            End Try

            Return InsertKey
        End Function
        Public Function AddNewActivityEmp(ByVal ID As Integer,
                                       ByVal EmpCode As String,
                                       ByVal Email As String)

            Dim arParams(3) As SqlParameter

            Dim parameterID As New SqlParameter("@ID", SqlDbType.Int)
            parameterID.Value = ID
            arParams(0) = parameterID

            Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
            parameterEmpCode.Value = EmpCode
            arParams(1) = parameterEmpCode

            Dim parameterEmail As New SqlParameter("@Email", SqlDbType.VarChar, 50)
            parameterEmail.Value = Email
            arParams(2) = parameterEmail

            Try
                InsertKey = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_nontask_AddEmp", arParams)
            Catch
                Err.Raise(Err.Number, "Class:cTaskCal Routine:TaskNewEmp", Err.Description)
                Return -1
            End Try

            Return InsertKey
        End Function
        Public Function UpdateTask(ByVal holiday As Boolean, ByVal appointment As Boolean, ByVal subject As String, ByVal allday As Boolean, ByVal startdate As Date, ByVal enddate As Date, ByVal starttime As DateTime, ByVal endtime As DateTime, ByVal EmpCode As String, ByVal Category As String, ByVal indicator As String, ByVal taskid As Integer, ByVal standardHours As Decimal) As Boolean
            Dim arParams(14) As SqlParameter

            Dim parameterType As New SqlParameter("@Type", SqlDbType.VarChar, 6)
            If holiday = True Then
                parameterType.Value = "H"
            ElseIf appointment = True Then
                parameterType.Value = "A"
            End If
            arParams(0) = parameterType

            Dim parameterDate As New SqlParameter("@StartDate", SqlDbType.DateTime, 12)
            parameterDate.Value = startdate.Date
            arParams(1) = parameterDate

            Dim parameterEnddate As New SqlParameter("@EndDate", SqlDbType.DateTime, 12)
            parameterEnddate.Value = enddate.Date
            arParams(2) = parameterEnddate

            Dim parameterAllDay As New SqlParameter("@Allday", SqlDbType.Int, 2)
            If allday = True Then
                parameterAllDay.Value = 1
            Else
                parameterAllDay.Value = 0
            End If
            arParams(3) = parameterAllDay

            Dim parameterSubject As New SqlParameter("@Nontaskdesc", SqlDbType.VarChar, 100)
            parameterSubject.Value = subject
            arParams(4) = parameterSubject

            Dim parameterStarttime As New SqlParameter("@Starttime", SqlDbType.DateTime, 26)
            If appointment = True And allday = True Then
                parameterStarttime.Value = Convert.ToDateTime(startdate.Date.ToShortDateString & " 12:00:00 AM")
            Else
                parameterStarttime.Value = Convert.ToDateTime(startdate.Date.ToShortDateString & " " & starttime.Hour.ToString() & ":" & starttime.Minute.ToString() & ":" & starttime.Second.ToString())
            End If

            arParams(5) = parameterStarttime

            Dim parameterEndtime As New SqlParameter("@Endtime", SqlDbType.DateTime, 26)
            If appointment = True And allday = True Then
                parameterEndtime.Value = Convert.ToDateTime(enddate.Date.ToShortDateString & " 11:59:00 PM")
            Else
                parameterEndtime.Value = Convert.ToDateTime(enddate.Date.ToShortDateString & " " & endtime.Hour.ToString() & ":" & endtime.Minute.ToString() & ":" & endtime.Second.ToString())
            End If
            arParams(6) = parameterEndtime

            Dim days As Integer
            Dim hrs As Decimal
            If startdate.Date <> enddate.Date And allday = True And appointment = True Then
                hrs = getHoursOverDuration(startdate, enddate, EmpCode)
            ElseIf startdate.Date <> enddate.Date And allday = False And appointment = True Then
                'Dim start As DateTime = Convert.ToDateTime(startdate.Date.ToShortDateString & " " & starttime.Hour.ToString()& ":" & starttime.Minute.ToString()& ":" & starttime.Second.ToString())
                'Dim endd As DateTime = Convert.ToDateTime(enddate.Date.ToShortDateString & " " & endtime.Hour.ToString()& ":" & endtime.Minute.ToString()& ":" & endtime.Second.ToString())
                'hrs = getHoursOverDuration(start, endd, EmpCode)
                hrs = getHoursOverDuration(startdate, enddate, EmpCode)
            ElseIf holiday = True And allday = True Then
                hrs = 0.0
            ElseIf startdate.Date = enddate.Date And allday = True And appointment = True Then
                hrs = standardHours
            Else
                hrs = endtime.Subtract(starttime).TotalHours
                If hrs > standardHours Then
                    hrs = standardHours
                End If
            End If

            Dim parameterHours As New SqlParameter("@Hours", SqlDbType.Decimal, 15)
            parameterHours.Value = hrs
            arParams(7) = parameterHours

            Dim parameterEmpCode As New SqlParameter("@Empcode", SqlDbType.VarChar, 6)
            parameterEmpCode.Value = EmpCode
            arParams(8) = parameterEmpCode

            Dim parameterCategory As New SqlParameter("@Category", SqlDbType.VarChar, 10)
            parameterCategory.Value = Category
            arParams(9) = parameterCategory

            Dim parameterJob As New SqlParameter("@JobNumber", SqlDbType.Int, 2)
            parameterJob.Value = Nothing
            arParams(10) = parameterJob

            Dim parameterJobComp As New SqlParameter("@JobCompNumber", SqlDbType.SmallInt, 2)
            parameterJobComp.Value = Nothing
            arParams(11) = parameterJobComp

            Dim parameterFunc As New SqlParameter("@Fnccode", SqlDbType.VarChar, 6)
            parameterFunc.Value = Nothing
            arParams(12) = parameterFunc

            Dim parameterTaskID As New SqlParameter("@TaskID", SqlDbType.Int, 2)
            parameterTaskID.Value = taskid
            arParams(13) = parameterTaskID

            Try
                oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_nontask_update", arParams)
            Catch
                Err.Raise(Err.Number, "Class:cTaskCal Routine:TaskNew", Err.Description)
                Return False
            End Try

            Return True
        End Function
        Public Function UpdateActivity(ByVal type As String,
                                       ByVal subject As String,
                                       ByVal allday As Boolean,
                                       ByVal startdate As Date,
                                       ByVal enddate As Date,
                                       ByVal starttime As DateTime,
                                       ByVal endtime As DateTime,
                                       ByVal EmpCode As String,
                                       ByVal Category As String,
                                       ByVal indicator As String,
                                       ByVal taskid As Integer,
                                       ByVal standardHours As Decimal,
                                       ByVal clientcode As String,
                                       ByVal divisioncode As String,
                                       ByVal productcode As String,
                                       ByVal jobnumber As Integer,
                                       ByVal compnumber As Integer,
                                       ByVal priority As Integer,
                                       ByVal reminder As String,
                                       ByVal recurrence As String,
                                       ByVal taskcode As String,
                                       ByVal description As String,
                                       ByVal functioncode As String,
                                       ByVal recurrenceParent As Integer,
                                       ByVal cdpcontactid As Integer,
                                       ByVal descriptionHTML As String) As Boolean
            Dim arParams(25) As SqlParameter

            Dim parameterType As New SqlParameter("@Type", SqlDbType.VarChar, 6)
            parameterType.Value = type
            arParams(0) = parameterType

            Dim parameterDate As New SqlParameter("@StartDate", SqlDbType.DateTime, 12)
            parameterDate.Value = startdate.Date
            arParams(1) = parameterDate

            Dim parameterEnddate As New SqlParameter("@EndDate", SqlDbType.DateTime, 12)
            parameterEnddate.Value = enddate.Date
            arParams(2) = parameterEnddate

            Dim parameterAllDay As New SqlParameter("@Allday", SqlDbType.Int, 2)
            If allday = True Then
                parameterAllDay.Value = 1
            Else
                parameterAllDay.Value = 0
            End If
            arParams(3) = parameterAllDay

            Dim parameterSubject As New SqlParameter("@Nontaskdesc", SqlDbType.VarChar, 100)
            parameterSubject.Value = subject
            arParams(4) = parameterSubject

            Dim parameterStarttime As New SqlParameter("@Starttime", SqlDbType.DateTime, 26)
            If type <> "H" And allday = True Then
                parameterStarttime.Value = Convert.ToDateTime(startdate.Date.ToShortDateString & " 12:00:00 AM")
            Else
                parameterStarttime.Value = Convert.ToDateTime(startdate.Date.ToShortDateString & " " & starttime.Hour.ToString() & ":" & starttime.Minute.ToString() & ":" & starttime.Second.ToString())
            End If

            arParams(5) = parameterStarttime

            Dim parameterEndtime As New SqlParameter("@Endtime", SqlDbType.DateTime, 26)
            If type <> "H" And allday = True Then
                parameterEndtime.Value = Convert.ToDateTime(enddate.Date.ToShortDateString & " 11:59:00 PM")
            Else
                parameterEndtime.Value = Convert.ToDateTime(enddate.Date.ToShortDateString & " " & endtime.Hour.ToString() & ":" & endtime.Minute.ToString() & ":" & endtime.Second.ToString())
            End If
            arParams(6) = parameterEndtime

            Dim days As Integer
            Dim hrs As Decimal
            Dim stdhrs As Decimal

            If startdate.Date <> enddate.Date And allday = True And type <> "H" Then
                hrs = getHoursOverDuration(startdate, enddate, EmpCode)
            ElseIf startdate.Date <> enddate.Date And allday = False And type <> "H" Then
                hrs = getHoursOverDuration(startdate, enddate, EmpCode)
            ElseIf type = "H" And allday = True Then
                hrs = 0.0
            ElseIf startdate.Date = enddate.Date And allday = True And type <> "H" Then
                hrs = getHoursOverDuration(startdate, enddate, EmpCode)
            Else
                stdhrs = getHoursOverDuration(startdate, enddate, EmpCode)
                hrs = CDate(enddate.ToShortDateString & " " & endtime.ToShortTimeString).Subtract(CDate(startdate.ToShortDateString & " " & starttime.ToShortTimeString)).TotalHours
                If hrs > stdhrs Then
                    hrs = stdhrs
                End If
            End If

            Dim parameterHours As New SqlParameter("@Hours", SqlDbType.Decimal, 15)
            parameterHours.Value = hrs
            arParams(7) = parameterHours

            Dim parameterEmpCode As New SqlParameter("@Empcode", SqlDbType.VarChar, 6)
            If EmpCode = "" Then
                parameterEmpCode.Value = DBNull.Value
            Else
                parameterEmpCode.Value = EmpCode
            End If
            arParams(8) = parameterEmpCode

            Dim parameterCategory As New SqlParameter("@Category", SqlDbType.VarChar, 10)
            parameterCategory.Value = Category
            arParams(9) = parameterCategory

            Dim parameterJob As New SqlParameter("@JobNumber", SqlDbType.Int)
            If jobnumber = 0 Then
                parameterJob.Value = DBNull.Value
            Else
                parameterJob.Value = jobnumber
            End If
            arParams(10) = parameterJob

            Dim parameterJobComp As New SqlParameter("@JobCompNumber", SqlDbType.SmallInt)
            If compnumber = 0 Then
                parameterJobComp.Value = DBNull.Value
            Else
                parameterJobComp.Value = compnumber
            End If
            arParams(11) = parameterJobComp

            Dim parameterFunc As New SqlParameter("@Fnccode", SqlDbType.VarChar, 6)
            If functioncode = "" Then
                parameterFunc.Value = DBNull.Value
            Else
                parameterFunc.Value = functioncode
            End If
            arParams(12) = parameterFunc

            Dim parameterTaskID As New SqlParameter("@TaskID", SqlDbType.Int, 2)
            parameterTaskID.Value = taskid
            arParams(13) = parameterTaskID

            Dim parameterClient As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
            parameterClient.Value = clientcode
            arParams(14) = parameterClient

            Dim parameterDivision As New SqlParameter("@DivisionCode", SqlDbType.VarChar, 6)
            parameterDivision.Value = divisioncode
            arParams(15) = parameterDivision

            Dim parameterProduct As New SqlParameter("@ProductCode", SqlDbType.VarChar, 6)
            parameterProduct.Value = productcode
            arParams(16) = parameterProduct

            Dim parameterPriority As New SqlParameter("@Priority", SqlDbType.Int)
            parameterPriority.Value = priority
            arParams(17) = parameterPriority

            Dim parameterReminder As New SqlParameter("@Reminder", SqlDbType.NVarChar)
            'If reminder = 0 Then
            '    parameterReminder.Value = DBNull.Value
            'Else
            parameterReminder.Value = reminder
            'end If
            arParams(18) = parameterReminder

            Dim parameterRecurrence As New SqlParameter("@Recurrence", SqlDbType.NVarChar)
            parameterRecurrence.Value = recurrence
            arParams(19) = parameterRecurrence

            Dim parameterTaskCode As New SqlParameter("@TaskCode", SqlDbType.VarChar)
            parameterTaskCode.Value = taskcode
            arParams(20) = parameterTaskCode

            Dim parameterDescription As New SqlParameter("@Description", SqlDbType.Text)
            parameterDescription.Value = description
            arParams(21) = parameterDescription

            Dim parameterRecurrenceParent As New SqlParameter("@RecurrenceParent", SqlDbType.Int)
            If recurrenceParent = 0 Then
                parameterRecurrenceParent.Value = DBNull.Value
            Else
                parameterRecurrenceParent.Value = recurrenceParent
            End If
            arParams(22) = parameterRecurrenceParent

            Dim parameterCDPContactID As New SqlParameter("@CDPContactID", SqlDbType.Int)
            If cdpcontactid = 0 Then
                parameterCDPContactID.Value = DBNull.Value
            Else
                parameterCDPContactID.Value = cdpcontactid
            End If
            arParams(23) = parameterCDPContactID

            Dim parameterDescriptionHTML As New SqlParameter("@DescriptionHTML", SqlDbType.Text)
            parameterDescriptionHTML.Value = descriptionHTML
            arParams(24) = parameterDescriptionHTML

            Try
                oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_nontask_update", arParams)
            Catch
                Err.Raise(Err.Number, "Class:cTaskCal Routine:TaskNew", Err.Description)
                Return False
            End Try

            Return True
        End Function
        Public Function DeleteTask(ByVal taskid As Integer) As Boolean

            Dim parameterTaskID As New SqlParameter("@TaskID", SqlDbType.Int, 2)
            parameterTaskID.Value = taskid

            Try
                oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_nontask_delete", parameterTaskID)
            Catch
                Err.Raise(Err.Number, "Class:cTaskCal Routine:TaskDelete", Err.Description)
                Return False
            End Try

            Return True
        End Function
        Public Function DeleteTaskEmps(ByVal taskid As Integer) As Boolean

            Dim parameterTaskID As New SqlParameter("@TaskID", SqlDbType.Int, 2)
            parameterTaskID.Value = taskid

            Try
                oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_nontask_DeleteEmps", parameterTaskID)
            Catch
                Err.Raise(Err.Number, "Class:cTaskCal Routine:TaskDelete", Err.Description)
                Return False
            End Try

            Return True
        End Function
        Public Function GetGroupID() As SqlDataReader
            'Return oSQL.ExecuteReader(mConnString, CommandType.Text, "SELECT ID,LOGO_PATH FROM LOCATIONS")
        End Function

        Public Function GetStandardHours()
            Return oSQL.ExecuteReader(mConnString, CommandType.Text, "SELECT ISNULL(TRF_HRS,0) FROM AGENCY")
        End Function

        Private Function getHoursOverDuration(ByVal StartDate As DateTime, ByVal EndDate As DateTime, ByVal EmpCode As String)
            Dim dt As DataTable
            Dim dr As SqlDataReader
            Dim arParams(4) As SqlParameter

            Dim parameteruserid As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
            parameteruserid.Value = ""
            arParams(0) = parameteruserid

            Dim parameterempcode As New SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
            parameterempcode.Value = EmpCode
            arParams(1) = parameterempcode

            Dim parameterdepts As New SqlParameter("@DeptCodes", SqlDbType.VarChar, 4000)
            parameterdepts.Value = DBNull.Value
            arParams(2) = parameterdepts

            Dim parameterRole As New SqlParameter("@ROLES", SqlDbType.VarChar, 8000)
            parameterRole.Value = ""
            arParams(3) = parameterRole

            Try
                dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_calendar_workload_hours", arParams)
            Catch
                Err.Raise(Err.Number, "Class:cTasks Routine:GetWorkload2", Err.Description)
            End Try

            Dim totalhours As Decimal
            Dim i As Integer
            Dim mon As Integer
            Dim tue As Integer
            Dim wed As Integer
            Dim thu As Integer
            Dim fri As Integer
            Dim sat As Integer
            Dim sun As Integer
            Dim time As Integer
            Dim ts As TimeSpan = EndDate.Subtract(StartDate)
            time = ts.Days

            For i = 0 To time
                If StartDate <= EndDate Then
                    If StartDate.DayOfWeek = DayOfWeek.Monday Then
                        mon += 1
                        StartDate = StartDate.AddDays(1)
                    ElseIf StartDate.DayOfWeek = DayOfWeek.Tuesday Then
                        tue += 1
                        StartDate = StartDate.AddDays(1)
                    ElseIf StartDate.DayOfWeek = DayOfWeek.Wednesday Then
                        wed += 1
                        StartDate = StartDate.AddDays(1)
                    ElseIf StartDate.DayOfWeek = DayOfWeek.Thursday Then
                        thu += 1
                        StartDate = StartDate.AddDays(1)
                    ElseIf StartDate.DayOfWeek = DayOfWeek.Friday Then
                        fri += 1
                        StartDate = StartDate.AddDays(1)
                    ElseIf StartDate.DayOfWeek = DayOfWeek.Saturday Then
                        sat += 1
                        StartDate = StartDate.AddDays(1)
                    ElseIf StartDate.DayOfWeek = DayOfWeek.Sunday Then
                        sun += 1
                        StartDate = StartDate.AddDays(1)
                    End If
                Else
                    Exit For
                End If
            Next

            Do While dr.Read
                If dr.GetDecimal(1) <> 0 Then
                    totalhours += dr.GetDecimal(1) * mon
                End If
                If dr.GetDecimal(2) <> 0 Then
                    totalhours += dr.GetDecimal(2) * tue
                End If
                If dr.GetDecimal(3) <> 0 Then
                    totalhours += dr.GetDecimal(3) * wed
                End If
                If dr.GetDecimal(4) <> 0 Then
                    totalhours += dr.GetDecimal(4) * thu
                End If
                If dr.GetDecimal(5) <> 0 Then
                    totalhours += dr.GetDecimal(5) * fri
                End If
                If dr.GetDecimal(6) <> 0 Then
                    totalhours += dr.GetDecimal(6) * sat
                End If
                If dr.GetDecimal(7) <> 0 Then
                    totalhours += dr.GetDecimal(7) * sun
                End If
            Loop

            Return totalhours

        End Function

        Public Function checkHolidays(ByVal startDate As DateTime, ByVal endDate As DateTime, ByVal allday As Boolean) As Boolean
            Dim arParams(2) As SqlParameter
            Dim count As Integer

            Dim parameterStartDate As New SqlParameter("@StartDate", SqlDbType.DateTime, 16)
            parameterStartDate.Value = startDate.Date
            arParams(0) = parameterStartDate

            Dim parameterEnddate As New SqlParameter("@EndDate", SqlDbType.DateTime, 16)
            parameterEnddate.Value = endDate.Date
            arParams(1) = parameterEnddate

            Try
                count = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_calendar_check_holidays", arParams)
            Catch
                Err.Raise(Err.Number, "Class:cTaskCal Routine:checkholidays", Err.Description)
                Return False
            End Try

            If count > 0 Then
                Return True
            Else
                Return False
            End If

        End Function

        Public Function checkAppointments(ByVal startDate As DateTime, ByVal endDate As DateTime, ByVal startTime As DateTime, ByVal endTime As DateTime, ByVal allday As Boolean, ByVal empcode As String, Optional ByVal ThisTaskID As Integer = 0) As Boolean
            Dim arParams(7) As SqlParameter
            Dim count As Integer

            Dim parameterStartDate As New SqlParameter("@StartDate", SqlDbType.DateTime, 16)
            parameterStartDate.Value = startDate.Date
            arParams(0) = parameterStartDate

            Dim parameterEnddate As New SqlParameter("@EndDate", SqlDbType.DateTime, 16)
            parameterEnddate.Value = endDate.Date
            arParams(1) = parameterEnddate

            Dim parameterStartTime As New SqlParameter("@StartTime", SqlDbType.DateTime, 24)
            If allday = True Then
                parameterStartTime.Value = Convert.ToDateTime(startDate.Date.ToShortDateString & " 12:00:00 AM")
            Else
                parameterStartTime.Value = Convert.ToDateTime(startDate.Date.ToShortDateString & " " & startTime.Hour.ToString() & ":" & startTime.Minute.ToString() & ":" & startTime.Second.ToString())
            End If
            arParams(2) = parameterStartTime

            Dim parameterEndTime As New SqlParameter("@EndTime", SqlDbType.DateTime, 24)
            If allday = True Then
                parameterEndTime.Value = Convert.ToDateTime(endDate.Date.ToShortDateString & " 11:59:00 PM")
            Else
                parameterEndTime.Value = Convert.ToDateTime(endDate.Date.ToShortDateString & " " & endTime.Hour.ToString() & ":" & endTime.Minute.ToString() & ":" & endTime.Second.ToString())
            End If
            arParams(3) = parameterEndTime

            Dim parameterAllDay As New SqlParameter("@Allday", SqlDbType.Int, 2)
            If allday = True Then
                parameterAllDay.Value = 1
            Else
                parameterAllDay.Value = 0
            End If
            arParams(4) = parameterAllDay

            Dim parameterEmpcode As New SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
            parameterEmpcode.Value = empcode
            arParams(5) = parameterEmpcode

            Dim parameterTaskID As New SqlParameter("@TaskID", SqlDbType.Int)
            parameterTaskID.Value = ThisTaskID
            arParams(6) = parameterTaskID


            Try
                count = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_calendar_check_appointments", arParams)
            Catch
                Err.Raise(Err.Number, "Class:cTaskCal Routine:checkappointments", Err.Description)
                Return False
            End Try

            If count > 0 Then
                Return True
            Else
                Return False
            End If
        End Function

        Private Function dayMenu(ByVal tasks As String)
            Dim arTasks() As String = tasks.Split("<br />")
            Dim i As Integer
            Dim sb As StringBuilder
            For i = 0 To arTasks.Length - 1

            Next


        End Function

        Private Function getMonthName(ByVal month As Integer)
            If month = 1 Then
                Return "JAN"
            End If
            If month = 2 Then
                Return "FEB"
            End If
            If month = 3 Then
                Return "MAR"
            End If
            If month = 4 Then
                Return "APR"
            End If
            If month = 5 Then
                Return "MAY"
            End If
            If month = 6 Then
                Return "JUN"
            End If
            If month = 7 Then
                Return "JUL"
            End If
            If month = 8 Then
                Return "AUG"
            End If
            If month = 9 Then
                Return "SEP"
            End If
            If month = 10 Then
                Return "OCT"
            End If
            If month = 11 Then
                Return "NOV"
            End If
            If month = 12 Then
                Return "DEC"
            End If

        End Function

        Public Sub New(ByVal ConnectionString As String)
            mConnString = ConnectionString
        End Sub

    End Class

    'Public Class CalendarItem

    '    Public Property Description As String
    '    Public Property StartDate As Date
    '    Public Property EndDate As Date

    '    Public Sub New()


    '    End Sub

    'End Class

End Namespace
