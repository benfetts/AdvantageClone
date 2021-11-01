Imports System
Imports System.Web
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports MyGeneration.dOOdads
Imports Webvantage.cGlobals
<Serializable()> Public Class cSchedule
    Private mConnString As String
    Private mUserCode As String
    Private mEmpCode As String
    Private oSQL As SqlHelper
#Region " Setup "
    Public Function GetStatusDescription(ByVal StatusCode As String) As String

        Dim StatusDescription As String = ""
        Dim SessionKey As String = "GetStatusDescription" & StatusCode

        'If HttpContext.Current.Session(SessionKey) Is Nothing Then
        Try

            Using MyConn As New SqlConnection(mConnString)

                Dim MyCommand As New SqlCommand()
                With MyCommand
                    .CommandType = CommandType.Text
                    .CommandText = "SELECT ISNULL(TRF_DESCRIPTION,'') FROM TRAFFIC WITH(NOLOCK) WHERE TRF_CODE = @TRF_CODE;"
                    .Connection = MyConn
                End With

                Dim pStatusCode As New SqlParameter("@TRF_CODE", SqlDbType.VarChar, 10)
                pStatusCode.Value = StatusCode
                MyCommand.Parameters.Add(pStatusCode)

                MyConn.Open()

                StatusDescription = CType(MyCommand.ExecuteScalar(), String)

            End Using

        Catch ex As Exception

        End Try

        '    HttpContext.Current.Session(SessionKey) = StatusDescription

        'Else

        '    StatusDescription = CType(HttpContext.Current.Session(SessionKey), String)

        'End If

        Return StatusDescription

    End Function
    Public Function GetUpdateStatusDefault() As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "GetUpdateStatusDefault"
        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Try
                Using MyConn As New SqlConnection(mConnString)
                    MyConn.Open()
                    Dim MyCmd As New SqlCommand("SELECT ISNULL(AGY_SETTINGS_VALUE,1) FROM AGY_SETTINGS WITH(NOLOCK) WHERE AGY_SETTINGS_CODE = 'TRF_UPDATE_STATUS';", MyConn)
                    Try
                        Dim i As Integer = CType(MyCmd.ExecuteScalar(), Integer)
                        If i = 0 Then
                            IsValid = False
                        Else
                            IsValid = True
                        End If
                    Catch ex As Exception
                        IsValid = True
                    Finally
                        If MyConn.State = ConnectionState.Open Then MyConn.Close()
                    End Try
                End Using
            Catch ex As Exception
                IsValid = True
            End Try
            HttpContext.Current.Session(SessionKey) = IsValid
        Else
            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        End If
        Return IsValid
    End Function
    Public Function GetScheduleColumns(ByVal HdrCode As String, ByVal ShowAll As Boolean, ByVal IsSetup As Boolean, ByVal IsAddNew As Boolean) As DataTable
        Try
            Dim arParams(4) As SqlParameter
            Dim paramHdrCode As New SqlParameter("@HDR_CODE", SqlDbType.VarChar, 6)
            paramHdrCode.Value = HdrCode
            arParams(0) = paramHdrCode
            Dim paramShowAll As New SqlParameter("@SHOW_ALL", SqlDbType.Int)
            If ShowAll = True Then
                paramShowAll.Value = -1
            Else
                paramShowAll.Value = 0
            End If
            arParams(1) = paramShowAll
            Dim paramIsSetup As New SqlParameter("@IS_SETUP", SqlDbType.Int)
            If IsSetup = True Then
                paramIsSetup.Value = 1
            Else
                paramIsSetup.Value = 0
            End If
            arParams(2) = paramIsSetup
            Dim paramIsAddNew As New SqlParameter("@IS_ADDNEW", SqlDbType.Int)
            If IsAddNew = True Then
                paramIsAddNew.Value = 1
            Else
                paramIsAddNew.Value = 0
            End If
            arParams(3) = paramIsAddNew
            Dim dt As New DataTable
            dt = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_GetScheduleUserColumns", "tbColumns", arParams)
            Return dt
        Catch ex As Exception
            Err.Raise(Err.Number, "Error GetScheduleColumns!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try
    End Function
    Public Function UpdateUserColumn(ByVal HdrCode As String, ByVal ColumnID As Integer, ByVal ShowOnGrid As Boolean, ByVal ShowOnAddNew As Boolean, ByVal Order As Short) As String
        Dim arParams(5) As SqlParameter
        Dim paramHdrCode As New SqlParameter("@HDR_CODE", SqlDbType.VarChar, 6)
        paramHdrCode.Value = HdrCode
        arParams(0) = paramHdrCode
        Dim paramColumnID As New SqlParameter("@COLUMN_ID", SqlDbType.Int)
        paramColumnID.Value = ColumnID
        arParams(1) = paramColumnID
        Dim paramShowOnGrid As New SqlParameter("@SHOW_ON_GRID", SqlDbType.SmallInt)
        If ShowOnGrid = True Then
            paramShowOnGrid.Value = 1
        Else
            paramShowOnGrid.Value = 0
        End If
        arParams(2) = paramShowOnGrid
        Dim paramShowOnAddNew As New SqlParameter("@SHOW_ON_ADDNEW", SqlDbType.SmallInt)
        If ShowOnAddNew = True Then
            paramShowOnAddNew.Value = 1
        Else
            paramShowOnAddNew.Value = 0
        End If
        arParams(3) = paramShowOnAddNew
        Dim paramColumnOrder As New SqlParameter("@ORDER", SqlDbType.SmallInt)
        paramColumnOrder.Value = Order
        arParams(4) = paramColumnOrder
        Try
            oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_Save_UserColumns", arParams)
            Return ""
        Catch ex As Exception
            Return ex.Message.ToString
        End Try
    End Function
    Public Function UpdateUserColumnShowLong(ByVal HdrCode As String, ByVal ColumnID As Integer) As String
        Dim arParams(2) As SqlParameter
        Dim paramHdrCode As New SqlParameter("@HDR_CODE", SqlDbType.VarChar, 6)
        paramHdrCode.Value = HdrCode
        arParams(0) = paramHdrCode
        Dim paramColumnID As New SqlParameter("@COLUMN_ID", SqlDbType.Int)
        paramColumnID.Value = ColumnID
        arParams(1) = paramColumnID
        Try
            oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_Save_UserColumns_ShowFullColumnText", arParams)
            Return ""
        Catch ex As Exception
            Return ex.Message.ToString
        End Try
    End Function
#End Region
#Region " Schedule "
    Public Function ScheduleSearch(ByVal ClCode As String, ByVal DivCode As String, ByVal PrdCode As String, ByVal JobNumber As Integer, ByVal JobComponentNbr As Integer, ByVal OfficeCode As String,
    ByVal SalesClassCode As String, ByVal CmpCode As String, ByVal AECode As String, ByVal UserCode As String, ByVal JobTypeCode As String) As DataTable
        Try
            Dim arParams(11) As SqlParameter
            Dim paramCliCode As New SqlParameter("@CL_CODE", SqlDbType.VarChar, 6)
            paramCliCode.Value = ClCode
            arParams(0) = paramCliCode
            Dim paramDivCode As New SqlParameter("@DIV_CODE", SqlDbType.VarChar, 6)
            paramDivCode.Value = DivCode
            arParams(1) = paramDivCode
            Dim paramProdCode As New SqlParameter("@PRD_CODE", SqlDbType.VarChar, 6)
            paramProdCode.Value = PrdCode
            arParams(2) = paramProdCode
            Dim paramJobNumber As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            paramJobNumber.Value = JobNumber
            arParams(3) = paramJobNumber
            Dim paramJobCompNumber As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
            paramJobCompNumber.Value = JobComponentNbr
            arParams(4) = paramJobCompNumber
            Dim paramOfficeCode As New SqlParameter("@OFFICE_CODE", SqlDbType.VarChar, 6)
            paramOfficeCode.Value = OfficeCode
            arParams(5) = paramOfficeCode
            Dim paramSalesClassCode As New SqlParameter("@SALES_CLASS", SqlDbType.VarChar, 6)
            paramSalesClassCode.Value = SalesClassCode
            arParams(6) = paramSalesClassCode
            Dim paramCmpCode As New SqlParameter("@CMP_CODE", SqlDbType.VarChar, 6)
            paramCmpCode.Value = CmpCode
            arParams(7) = paramCmpCode
            Dim paramAECode As New SqlParameter("@AE_CODE", SqlDbType.VarChar, 6)
            paramAECode.Value = AECode
            arParams(8) = paramAECode
            Dim paramUserCode As New SqlParameter("@USER_ID", SqlDbType.VarChar, 100)
            paramUserCode.Value = UserCode
            arParams(9) = paramUserCode
            Dim paramJobTypeCode As New SqlParameter("@JT_CODE", SqlDbType.VarChar, 10)
            paramJobTypeCode.Value = JobTypeCode
            arParams(10) = paramJobTypeCode
            Return oSQL.ExecuteDataTable(Me.mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_Search", "DtSearchResults", arParams)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function CalculateDateLocked() As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "CalculateDateLocked"
        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Try
                Dim i As Integer = -1
                i = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_CalcLocked")
                If i = 1 Then
                    IsValid = True
                Else
                    IsValid = False
                End If
            Catch ex As Exception
                IsValid = False
            End Try
            HttpContext.Current.Session(SessionKey) = IsValid
        Else
            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        End If
        Return IsValid
    End Function
    Public Function CalculateFixStartDate(ByVal TheJobNum As Integer, ByVal TheJobCompNum As Integer) As String
        If TheJobNum > 0 And TheJobCompNum > 0 Then
            Try
                Dim arParams(2) As SqlParameter
                Dim paramJobNumber As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
                paramJobNumber.Value = TheJobNum
                arParams(0) = paramJobNumber
                Dim paramJobCompNumber As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
                paramJobCompNumber.Value = TheJobCompNum
                arParams(1) = paramJobCompNumber
                oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_Calculate_FixStartDate", arParams)
                Return ""
            Catch ex As Exception
                Return ex.Message.ToString
            End Try
        End If
    End Function
    Public Function DeleteEntireSchedule(ByVal TheJobNum As Integer, ByVal TheJobCompNum As Integer) As String
        If TheJobNum > 0 And TheJobCompNum > 0 Then
            Try
                Dim arParams(2) As SqlParameter
                Dim paramJobNumber As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
                paramJobNumber.Value = TheJobNum
                arParams(0) = paramJobNumber
                Dim paramJobCompNumber As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
                paramJobCompNumber.Value = TheJobCompNum
                arParams(1) = paramJobCompNumber
                oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_DeleteEntireSchedule", arParams)
                Return ""
            Catch ex As Exception
                Return ex.Message.ToString
            End Try
        End If
    End Function
    Public Function CheckExistsClosed(ByVal JobNum As Integer, ByVal JobCompNum As Integer) As Integer
        'Dim SessionKey As String = "CheckExistsClosed" & JobNum.ToString() & JobCompNum.ToString()
        Dim ReturnInteger As Integer = -999
        'If HttpContext.Current.Session(SessionKey) Is Nothing Then
        Try
            Dim arParams(2) As SqlParameter
            Dim paramJobNumber As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            paramJobNumber.Value = JobNum
            arParams(0) = paramJobNumber
            Dim paramJobCompNumber As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
            paramJobCompNumber.Value = JobCompNum
            arParams(1) = paramJobCompNumber
            ReturnInteger = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_Check", arParams)
        Catch ex As Exception
            ReturnInteger = -999
        End Try
        '    HttpContext.Current.Session(SessionKey) = ReturnInteger
        'Else
        '    ReturnInteger = CType(HttpContext.Current.Session(SessionKey).ToString(), Integer)
        'End If
        Return ReturnInteger
    End Function
    Public Function CountHeaderComponentsOneComp(ByVal JobNum As Integer, ByVal CountFromJCTable As Boolean, Optional ByVal LoadClosedComponents As Boolean = False) As Integer
        Try
            Dim arParams(3) As SqlParameter
            Dim paramJobNumber As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            paramJobNumber.Value = JobNum
            arParams(0) = paramJobNumber
            Dim paramCountFromJCTable As New SqlParameter("@COUNT_FROM_JC_TABLE", SqlDbType.SmallInt)
            If CountFromJCTable = True Then
                paramCountFromJCTable.Value = 1
            Else
                paramCountFromJCTable.Value = 0
            End If
            arParams(1) = paramCountFromJCTable
            Dim paramLoadClosedComponents As New SqlParameter("@LOAD_CLOSED_COMPONENTS", SqlDbType.SmallInt)
            If LoadClosedComponents = True Then
                paramLoadClosedComponents.Value = 1
            Else
                paramLoadClosedComponents.Value = 0
            End If
            arParams(2) = paramLoadClosedComponents
            Dim i As Integer = 0
            i = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_CountHeaderComponents", arParams)
            Return i
        Catch ex As Exception
            Return -999
        End Try
    End Function
    Public Function GetScheduleHeader(ByVal JobNum As Integer, ByVal JobCompNum As Integer, ByVal UserCode As String, ByVal ShowOnlyOpenSchedule As Boolean, Optional ByVal CliCode As String = "",
    Optional ByVal DivCode As String = "", Optional ByVal PrdCode As String = "", Optional ByVal EmpCode As String = "", Optional ByVal AECode As String = "",
    Optional ByVal TaskCode As String = "", Optional ByVal RoleCode As String = "", Optional ByVal CutOffDate As String = "", Optional ByVal ManagerCode As String = "",
    Optional ByVal IncludeCompletedTasks As Boolean = True, Optional ByVal IncludeOnlyPendingTasks As Boolean = False, Optional ByVal ExcludeProjectedTasks As Boolean = False, Optional ByVal CampaignCode As String = "",
    Optional ByVal IncludeClosedJobs As Boolean = True, Optional ByVal MilestonesOnly As Boolean = False, Optional ByVal TrafficStatusCode As String = "", Optional ByVal Gantt As Boolean = False,
    Optional ByVal OfficeCode As String = "", Optional ByVal SalesClassCode As String = "", Optional ByVal JobTypeCode As String = "", Optional OnlyScheduleTemplates As Boolean = False, Optional PhaseID As Integer = -1) As DataSet
        Try
            Dim arParams(26) As SqlParameter
            Dim paramJobNumber As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            paramJobNumber.Value = JobNum
            arParams(0) = paramJobNumber
            Dim paramJobCompNumber As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
            paramJobCompNumber.Value = JobCompNum
            arParams(1) = paramJobCompNumber
            Dim paramUserCode As New SqlParameter("@USER_ID", SqlDbType.VarChar, 100)
            paramUserCode.Value = UserCode
            arParams(2) = paramUserCode
            Dim paramCliCode As New SqlParameter("@CL_CODE", SqlDbType.VarChar, 6)
            paramCliCode.Value = CliCode
            arParams(3) = paramCliCode
            Dim paramDivCode As New SqlParameter("@DIV_CODE", SqlDbType.VarChar, 6)
            paramDivCode.Value = DivCode
            arParams(4) = paramDivCode
            Dim paramProdCode As New SqlParameter("@PRD_CODE", SqlDbType.VarChar, 6)
            paramProdCode.Value = PrdCode
            arParams(5) = paramProdCode
            Dim paramEmpCode As New SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
            paramEmpCode.Value = EmpCode
            arParams(6) = paramEmpCode
            Dim paramAECode As New SqlParameter("@AE_CODE", SqlDbType.VarChar, 6)
            paramAECode.Value = AECode
            arParams(7) = paramAECode
            Dim paramTaskCode As New SqlParameter("@TASK_CODE", SqlDbType.VarChar, 10)
            paramTaskCode.Value = TaskCode
            arParams(8) = paramTaskCode
            Dim paramRoleCode As New SqlParameter("@ROLE_CODE", SqlDbType.VarChar, 6)
            paramRoleCode.Value = RoleCode
            arParams(9) = paramRoleCode
            Dim paramCutOffDate As New SqlParameter("@CUT_OFF_DATE", SqlDbType.SmallDateTime)
            If cGlobals.wvIsDate(CutOffDate) = True Then
                paramCutOffDate.Value = CDate(CDate(CutOffDate).ToShortDateString & " 23:59:00")
            Else
                paramCutOffDate.Value = DBNull.Value
            End If
            arParams(10) = paramCutOffDate
            Dim paramManagerCode As New SqlParameter("@MGR_CODE", SqlDbType.VarChar, 6)
            paramManagerCode.Value = ManagerCode
            arParams(11) = paramManagerCode
            Dim paramOpenScheds As New SqlParameter("@SHOW_ONLY_OPEN_SCHEDS", SqlDbType.SmallInt)
            If ShowOnlyOpenSchedule = True Then
                paramOpenScheds.Value = 1
            Else
                paramOpenScheds.Value = 0
            End If
            arParams(12) = paramOpenScheds
            Dim paramIncludeCompletedTasks As New SqlParameter("@IncludeCompletedTasks", SqlDbType.Char)
            If IncludeCompletedTasks = True Then
                paramIncludeCompletedTasks.Value = "Y"
            Else
                paramIncludeCompletedTasks.Value = "N"
            End If
            arParams(13) = paramIncludeCompletedTasks
            Dim paramIncludeOnlyPendingTasks As New SqlParameter("@IncludeOnlyPendingTasks", SqlDbType.Char)
            If IncludeOnlyPendingTasks = True Then
                paramIncludeOnlyPendingTasks.Value = "Y"
            Else
                paramIncludeOnlyPendingTasks.Value = "N"
            End If
            arParams(14) = paramIncludeOnlyPendingTasks
            Dim paramExcludeProjectedTasks As New SqlParameter("@ExcludeProjectedTasks", SqlDbType.Char)
            If ExcludeProjectedTasks = True Then
                paramExcludeProjectedTasks.Value = "Y"
            Else
                paramExcludeProjectedTasks.Value = "N"
            End If
            arParams(15) = paramExcludeProjectedTasks
            Dim paramCampaignCode As New SqlParameter("@CMP_CODE", SqlDbType.VarChar, 6)
            paramCampaignCode.Value = CampaignCode
            arParams(16) = paramCampaignCode
            Dim paramIncludeClosedJobs As New SqlParameter("@INCLUDE_CLOSE_JOBS", SqlDbType.Bit)
            If IncludeClosedJobs = True Then
                paramIncludeClosedJobs.Value = 1
            Else
                paramIncludeClosedJobs.Value = 0
            End If
            arParams(17) = paramIncludeClosedJobs
            Dim paramMilestonesOnly As New SqlParameter("@MILESTONES_ONLY", SqlDbType.Bit)
            If MilestonesOnly = True Then
                paramMilestonesOnly.Value = 1
            Else
                paramMilestonesOnly.Value = 0
            End If
            arParams(18) = paramMilestonesOnly
            Dim paramTrafficStatusCode As New SqlParameter("@TRAFFIC_STATUS_CODE", SqlDbType.VarChar, 10)
            paramTrafficStatusCode.Value = TrafficStatusCode
            arParams(19) = paramTrafficStatusCode
            Dim paramGantt As New SqlParameter("@GANTT", SqlDbType.Bit)
            If Gantt = True Then
                paramGantt.Value = 1
            Else
                paramGantt.Value = 0
            End If
            arParams(20) = paramGantt
            Dim paramOfficeCode As New SqlParameter("@OFFICE_CODE", SqlDbType.VarChar, 6)
            paramOfficeCode.Value = OfficeCode
            arParams(21) = paramOfficeCode
            Dim paramSalesClassCode As New SqlParameter("@SC_CODE", SqlDbType.VarChar, 6)
            paramSalesClassCode.Value = SalesClassCode
            arParams(22) = paramSalesClassCode
            Dim paramJobTypeCode As New SqlParameter("@JT_CODE", SqlDbType.VarChar, 10)
            paramJobTypeCode.Value = JobTypeCode
            arParams(23) = paramJobTypeCode
            Dim paramOnlyScheduleTemplates As New SqlParameter("@ONLY_SCHEDULE_TEMPLATES", SqlDbType.Bit)
            If OnlyScheduleTemplates = True Then
                paramOnlyScheduleTemplates.Value = 1
            Else
                paramOnlyScheduleTemplates.Value = 0
            End If
            arParams(24) = paramOnlyScheduleTemplates
            Dim paramPhaseID As New SqlParameter("@TRAFFIC_PHASE_ID", SqlDbType.Int)
            paramPhaseID.Value = PhaseID
            arParams(25) = paramPhaseID
            Return oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_GetScheduleHeader", arParams)
        Catch ex As Exception
            Err.Raise(Err.Number, "Error GetScheduleHeader!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try
    End Function
    Public Function GetScheduleAssignmentLabels() As DataSet
        Return oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_GetAssignmentLabels")
    End Function
    Public Function GetManagerLabel() As String
        Dim SessionKey As String = "GetManagerLabel"
        Dim ReturnString As String = ""
        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim SQL As String = "SELECT COALESCE(AGY_SETTINGS.AGY_SETTINGS_VALUE, AGY_SETTINGS.AGY_SETTINGS_DEF, 'Manager') AS AGY_SETTINGS_VALUE FROM AGY_SETTINGS WITH(NOLOCK) WHERE AGY_SETTINGS.AGY_SETTINGS_CODE = " &
            "(SELECT AGY_SETTINGS.AGY_SETTINGS_VALUE FROM AGY_SETTINGS WITH(NOLOCK) WHERE AGY_SETTINGS.AGY_SETTINGS_CODE = 'TRAFFIC_MGR_COL');"
            Try
                ReturnString = SqlHelper.ExecuteScalar(mConnString, CommandType.Text, SQL).ToString()
                If ReturnString = "" Then
                    ReturnString = "Manager"
                End If
            Catch ex As Exception
                ReturnString = "Manager"
            End Try
            HttpContext.Current.Session(SessionKey) = ReturnString
        Else
            ReturnString = HttpContext.Current.Session(SessionKey).ToString()
        End If
        Return ReturnString
    End Function
    Public Function GetManagerField() As String
        Dim SessionKey As String = "GetManagerField"
        Dim ReturnString As String = ""
        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim SQL As String = "SELECT AGY_SETTINGS.AGY_SETTINGS_VALUE FROM AGY_SETTINGS WITH(NOLOCK) WHERE AGY_SETTINGS.AGY_SETTINGS_CODE = 'TRAFFIC_MGR_COL';"
            Try
                ReturnString = SqlHelper.ExecuteScalar(mConnString, CommandType.Text, SQL).ToString()
                ReturnString = "ASSIGN_" & ReturnString.Substring(8, 1)
                If ReturnString = "" Then
                    ReturnString = "ASSIGN_1"
                End If
            Catch ex As Exception
                ReturnString = "ASSIGN_1"
            End Try
            HttpContext.Current.Session(SessionKey) = ReturnString
        Else
            ReturnString = HttpContext.Current.Session(SessionKey).ToString()
        End If
        Return ReturnString
    End Function
    Public Function UpdateScheduleComment(ByVal ScheduleJobNum As Integer, ByVal ScheduleJobComp As Integer, ByVal ScheduleComment As String) As String
        If ScheduleJobNum > 0 And ScheduleJobComp > 0 Then
            Try
                Dim jtraff As New JOB_TRAFFIC(mConnString)
                If jtraff.LoadByPrimaryKey(ScheduleJobComp, ScheduleJobNum) Then
                    With jtraff
                        .TRF_COMMENTS = ScheduleComment
                        .Save()
                    End With
                End If
                Return ""
            Catch ex As Exception
                Return "Error saving schedule comments."
            End Try
        End If
    End Function
    Public Function UpdateScheduleOtherInformation(ByVal ScheduleJobNum As Integer, ByVal ScheduleJobComp As Integer, ByVal StrDateShipped As String, ByVal StrDateDelivered As String, ByVal StrReceivedBy As String, ByVal StrReference As String) As String
        If ScheduleJobNum > 0 And ScheduleJobComp > 0 Then
            Try
                Dim arParams(6) As SqlParameter
                Dim paramJobNumber As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
                paramJobNumber.Value = ScheduleJobNum
                arParams(0) = paramJobNumber
                Dim paramJobCompNumber As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
                paramJobCompNumber.Value = ScheduleJobComp
                arParams(1) = paramJobCompNumber
                Dim paramDATE_DELIVERED As New SqlParameter("@DATE_DELIVERED", SqlDbType.SmallDateTime)
                If wvIsDate(StrDateDelivered) = False Then
                    paramDATE_DELIVERED.Value = DBNull.Value
                Else
                    paramDATE_DELIVERED.Value = wvCDate(StrDateDelivered)
                End If
                arParams(2) = paramDATE_DELIVERED
                Dim paramDATE_SHIPPED As New SqlParameter("@DATE_SHIPPED", SqlDbType.SmallDateTime)
                If wvIsDate(StrDateShipped) = False Then
                    paramDATE_SHIPPED.Value = DBNull.Value
                Else
                    paramDATE_SHIPPED.Value = wvCDate(StrDateShipped)
                End If
                arParams(3) = paramDATE_SHIPPED
                Dim paramRECEIVED_BY As New SqlParameter("@RECEIVED_BY", SqlDbType.VarChar, 40)
                paramRECEIVED_BY.Value = StrReceivedBy
                arParams(4) = paramRECEIVED_BY
                Dim paramREFERENCE As New SqlParameter("@REFERENCE", SqlDbType.VarChar, 150)
                paramREFERENCE.Value = StrReference
                arParams(5) = paramREFERENCE
                Try
                    oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_SaveOtherInfo", arParams)
                    Return ""
                Catch ex As Exception
                    Return ex.Message.ToString
                End Try
            Catch ex As Exception
                Return "Error saving schedule other information."
            End Try
        End If
    End Function
    Public Function UpdateScheduleAssignments(ByVal JobNumber As Integer, ByVal JobComponentNbr As Integer,
    ByVal NewAssignment1 As String, ByVal NewAssignment2 As String, ByVal NewAssignment3 As String, ByVal NewAssignment4 As String, ByVal NewAssignment5 As String,
    ByVal OldAssignment1 As String, ByVal OldAssignment2 As String, ByVal OldAssignment3 As String, ByVal OldAssignment4 As String, ByVal OldAssignment5 As String) As String
        If JobNumber > 0 And JobComponentNbr > 0 Then
            Try
                Dim jtraff As New JOB_TRAFFIC(mConnString)
                If jtraff.LoadByPrimaryKey(JobComponentNbr, JobNumber) Then
                    With jtraff
                        If NewAssignment1.Trim() <> OldAssignment1.Trim() Then
                            .ASSIGN_1 = NewAssignment1
                        End If
                        If NewAssignment2.Trim() <> OldAssignment2.Trim() Then
                            .ASSIGN_2 = NewAssignment2
                        End If
                        If NewAssignment3.Trim() <> OldAssignment3.Trim() Then
                            .ASSIGN_3 = NewAssignment3
                        End If
                        If NewAssignment4.Trim() <> OldAssignment4.Trim() Then
                            .ASSIGN_4 = NewAssignment4
                        End If
                        If NewAssignment5.Trim() <> OldAssignment5.Trim() Then
                            .ASSIGN_5 = NewAssignment5
                        End If
                        .Save()
                    End With
                End If
                Return ""
            Catch ex As Exception
                Return "Error saving schedule assignments."
            End Try
        End If
    End Function
    Public Function UpdateScheduleDetails(ByVal ScheduleJobNum As Integer, ByVal ScheduleJobComp As Integer, ByVal StrStartDate As String, ByVal StrDueDate As String,
    ByVal StrTrafficCode As String, ByVal AutoSaveStatus As Boolean, ByVal UseStartDateForCalc As Boolean, ByVal StrCompletedDate As String,
    ByVal percentcomplete As Decimal) As String
        If ScheduleJobNum > 0 And ScheduleJobComp > 0 Then
            Try
                Dim arP(10) As SqlParameter
                Dim pScheduleJobNum As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
                pScheduleJobNum.Value = ScheduleJobNum
                arP(0) = pScheduleJobNum
                Dim pScheduleJobComp As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
                pScheduleJobComp.Value = ScheduleJobComp
                arP(1) = pScheduleJobComp
                Dim pStartDate As New SqlParameter("@START_DATE", SqlDbType.SmallDateTime)
                If StrStartDate.Trim = "" Or cGlobals.wvIsDate(StrStartDate) = False Then
                    pStartDate.Value = DBNull.Value
                Else
                    pStartDate.Value = cGlobals.wvCDate(StrStartDate)
                End If
                arP(2) = pStartDate
                Dim pDueDate As New SqlParameter("@DUE_DATE", SqlDbType.SmallDateTime)
                If StrDueDate.Trim = "" Or cGlobals.wvIsDate(StrDueDate) = False Then
                    pDueDate.Value = DBNull.Value
                Else
                    pDueDate.Value = cGlobals.wvCDate(StrDueDate)
                End If
                arP(3) = pDueDate
                Dim pTAutoSaveStatus As New SqlParameter("@AUTO_SAVE_TRAFF_CODE", SqlDbType.SmallInt)
                If AutoSaveStatus = True Then
                    pTAutoSaveStatus.Value = 1
                Else
                    pTAutoSaveStatus.Value = 0
                End If
                arP(4) = pTAutoSaveStatus
                Dim pUseStartDateForCalc As New SqlParameter("@USE_START_DATE_FOR_CALC", SqlDbType.SmallInt)
                If UseStartDateForCalc = True Then
                    pUseStartDateForCalc.Value = 1
                Else
                    pUseStartDateForCalc.Value = 0
                End If
                arP(5) = pUseStartDateForCalc
                Dim pTrafficCode As New SqlParameter("@TRAFFIC_CODE", SqlDbType.VarChar, 10)
                pTrafficCode.Value = StrTrafficCode
                arP(6) = pTrafficCode
                Dim pCompletedDate As New SqlParameter("@JOB_TRAFFIC_COMPLETED_DATE", SqlDbType.SmallDateTime)
                If cGlobals.wvIsDate(StrCompletedDate) = True Then
                    pCompletedDate.Value = StrCompletedDate
                Else
                    pCompletedDate.Value = DBNull.Value
                End If
                arP(7) = pCompletedDate
                Dim pPercentComplete As New SqlParameter("@PERCENT_COMPLETE", SqlDbType.Decimal)
                pPercentComplete.Value = percentcomplete
                arP(8) = pPercentComplete
                Try
                    oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_SaveScheduleDetails", arP)
                Catch ex As Exception
                    Return "Error saving schedule details."
                End Try
            Catch ex As Exception
                Return "Error saving schedule details."
            End Try
        End If
    End Function
    Public Function UpdateScheduleDetailCalculate(ByVal ScheduleJobNum As Integer, ByVal ScheduleJobComp As Integer, ByVal schedulecalc As Integer) As String
        If ScheduleJobNum > 0 And ScheduleJobComp > 0 Then
            Try
                Dim arP(3) As SqlParameter
                Dim pScheduleJobNum As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
                pScheduleJobNum.Value = ScheduleJobNum
                arP(0) = pScheduleJobNum
                Dim pScheduleJobComp As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
                pScheduleJobComp.Value = ScheduleJobComp
                arP(1) = pScheduleJobComp
                Dim pSCHEDULE_CALC As New SqlParameter("@SCHEDULE_CALC", SqlDbType.Int)
                If schedulecalc = -1 Then
                    pSCHEDULE_CALC.Value = DBNull.Value
                Else
                    pSCHEDULE_CALC.Value = schedulecalc
                End If
                arP(2) = pSCHEDULE_CALC
                Try
                    oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_SaveScheduleCalculate", arP)
                Catch ex As Exception
                    Return "Error saving schedule details."
                End Try
            Catch ex As Exception
                Return "Error saving schedule details."
            End Try
        End If
    End Function
    Public Function AutoUpdateTrafficCode(ByVal JobNumber As Integer, ByVal JobComponentNbr As Integer, Optional ByRef ErrorMessage As String = "",
                                          Optional ByRef NewStatusCode As String = "", Optional ByRef NewStatusDescription As String = "") As Boolean

        Dim DoAutoUpdate As Boolean = False
        Dim UpdateStatusFromScheduleHeader As Object = Nothing
        Dim SQL As String = String.Format("SELECT JOB_TRAFFIC.AUTO_UPDATE_STATUS FROM JOB_TRAFFIC WITH(NOLOCK) WHERE JOB_NUMBER = {0} AND JOB_COMPONENT_NBR = {1};", JobNumber, JobComponentNbr)

        Try

            UpdateStatusFromScheduleHeader = SqlHelper.ExecuteScalar(Me.mConnString, CommandType.Text, SQL)

        Catch ex As Exception

            UpdateStatusFromScheduleHeader = Nothing

        End Try

        If Not UpdateStatusFromScheduleHeader Is Nothing AndAlso Not UpdateStatusFromScheduleHeader Is System.DBNull.Value Then

            DoAutoUpdate = CType(UpdateStatusFromScheduleHeader, Boolean)

        Else

            DoAutoUpdate = Me.GetUpdateStatusDefault()

        End If

        If DoAutoUpdate = True Then

            Return Me.UpdateScheduleStatus(JobNumber, JobComponentNbr, True, ErrorMessage, NewStatusCode, NewStatusDescription)

        Else

            Return False

        End If

    End Function
    Public Function UpdateScheduleStatus(ByVal JobNumber As Integer, ByVal JobComponentNbr As Integer, ByVal BoolAutoUpdateTrafficCode As Boolean, Optional ByRef ErrorMessage As String = "",
    Optional ByRef NewStatusCode As String = "", Optional ByRef NewStatusDescription As String = "") As Boolean
        Dim Updated As Boolean = False
        Try
            If BoolAutoUpdateTrafficCode = True Then
                Dim dt As New DataTable
                dt = Me.GetNextScheduleStatusCode(JobNumber, JobComponentNbr)
                Dim NextStatusCode As String = ""
                If dt.Rows.Count > 0 Then
                    If IsDBNull(dt.Rows(0)("NEXT_STATUS_CODE")) = False Then
                        NextStatusCode = dt.Rows(0)("NEXT_STATUS_CODE").ToString().Trim
                    Else
                        NextStatusCode = ""
                    End If
                    NewStatusCode = NextStatusCode
                    If IsDBNull(dt.Rows(0)("NEXT_STATUS_DESCRIPTION")) = False Then
                        NewStatusDescription = dt.Rows(0)("NEXT_STATUS_DESCRIPTION").ToString().Trim
                    Else
                        NewStatusDescription = ""
                    End If
                End If
                If NextStatusCode <> "" Then
                    Me.UpdateScheduleTrafficCode(JobNumber, JobComponentNbr, NextStatusCode)
                    'ErrorMessage = "Status code updated"
                    Updated = True
                Else
                    'ErrorMessage = "Save successful.  Status code not updated."
                    Updated = False
                End If
            End If
        Catch ex As Exception
            Updated = False
        End Try
        Return Updated
    End Function
    Public Function UpdateScheduleTrafficCode(ByVal ScheduleJobNum As Integer, ByVal ScheduleJobComp As Integer, ByVal TrafficCode As String) As String
        If ScheduleJobNum > 0 And ScheduleJobComp > 0 Then
            Try
                Dim jtraff As New JOB_TRAFFIC(mConnString)
                If jtraff.LoadByPrimaryKey(ScheduleJobComp, ScheduleJobNum) Then
                    With jtraff
                        .TRF_CODE = TrafficCode
                        .Save()
                    End With
                End If
                Return ""
            Catch ex As Exception
                Return "Error saving schedule comments."
            End Try
        End If
    End Function
    Public Function AddNewSchedule(ByVal JobNum As Integer, ByVal JobCompNum As Integer, ByVal TrafficPresetCode As String, ByVal TrafficCode As String,
                                   ByVal ScheduleStartDate As String, ByVal ScheduleDueDate As String, ByVal UserCode As String, Optional ByVal ManagerEmpCode As String = "") As String
        Try

            Dim arParams(8) As SqlParameter
            Dim paramJobNumber As New SqlParameter("@JOB_NUM", SqlDbType.Int)
            paramJobNumber.Value = JobNum
            arParams(0) = paramJobNumber
            Dim paramJobCompNumber As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.Int)
            paramJobCompNumber.Value = JobCompNum
            arParams(1) = paramJobCompNumber
            Dim paramTrafficPresetCode As New SqlParameter("@TRF_PRESET_CODE", SqlDbType.VarChar, 6)
            paramTrafficPresetCode.Value = TrafficPresetCode
            arParams(2) = paramTrafficPresetCode
            Dim paramTrafficCode As New SqlParameter("@TRF_CODE", SqlDbType.VarChar, 10)
            paramTrafficCode.Value = TrafficCode
            arParams(3) = paramTrafficCode
            Dim paramScheduleStartDate As New SqlParameter("@START_DATE", SqlDbType.SmallDateTime)
            If wvIsDate(ScheduleStartDate) = False Then
                paramScheduleStartDate.Value = DBNull.Value
            Else
                paramScheduleStartDate.Value = wvCDate(ScheduleStartDate)
            End If
            arParams(4) = paramScheduleStartDate
            Dim paramScheduleDueDate As New SqlParameter("@DUE_DATE", SqlDbType.SmallDateTime)
            If wvIsDate(ScheduleDueDate) = False Then
                paramScheduleDueDate.Value = DBNull.Value
            Else
                paramScheduleDueDate.Value = wvCDate(ScheduleDueDate)
            End If
            arParams(5) = paramScheduleDueDate

            Dim paramManagerEmpCode As New SqlParameter("@TRAFFIC_MGR_CODE", SqlDbType.VarChar, 6)
            If ManagerEmpCode = "" Then
                paramManagerEmpCode.Value = DBNull.Value
            Else
                paramManagerEmpCode.Value = ManagerEmpCode
            End If
            arParams(6) = paramManagerEmpCode

            Dim paramUserCode As New SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)
            paramUserCode.Value = UserCode
            arParams(8) = paramUserCode

            Try

                oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_AddNew_AddSchedule", arParams)
                Return ""

            Catch ex As Exception

                Return ex.Message.ToString

            End Try

        Catch ex As Exception

            Return ex.Message.ToString

        End Try

    End Function
    Public Function QuickAddScheduleHeader(ByVal JobNumber As Integer, ByVal JobComponentNbr As Integer, ByVal TrafficStatusCode As String,
    ByVal TrafficManagerEmpCode As String, ByVal UserCode As String,
    Optional ByRef ErrorMessage As String = "") As Boolean
        Try
            TrafficManagerEmpCode = TrafficManagerEmpCode.Trim()
            Dim arParams(5) As SqlParameter
            Dim paramJobNumber As New SqlParameter("@JOB_NUM", SqlDbType.Int)
            paramJobNumber.Value = JobNumber
            arParams(0) = paramJobNumber
            Dim paramJobCompNumber As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.Int)
            paramJobCompNumber.Value = JobComponentNbr
            arParams(1) = paramJobCompNumber
            Dim paramTrafficCode As New SqlParameter("@TRF_CODE", SqlDbType.VarChar, 10)
            If TrafficStatusCode = "" Then
                paramTrafficCode.Value = System.DBNull.Value
            Else
                paramTrafficCode.Value = TrafficStatusCode
            End If
            arParams(3) = paramTrafficCode
            Dim paramTrafficManagerEmpCode As New SqlParameter("@TRAFFIC_MGR_CODE", SqlDbType.VarChar, 6)
            If TrafficManagerEmpCode = "" Then
                paramTrafficManagerEmpCode.Value = System.DBNull.Value
            Else
                paramTrafficManagerEmpCode.Value = TrafficManagerEmpCode
            End If
            arParams(4) = paramTrafficManagerEmpCode
            Dim paramUserCode As New SqlParameter("@USER_CODE", SqlDbType.VarChar)
            paramUserCode.Value = UserCode
            arParams(5) = paramUserCode

            SqlHelper.ExecuteNonQuery(Me.mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_AddQuickHeader", arParams)
            ErrorMessage = ""
            Return True
        Catch ex As Exception
            ErrorMessage = AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString())
            Return False
        End Try
    End Function
    Public Function AddPresetToSchedule(ByVal JobNum As Integer, ByVal JobCompNum As Integer, ByVal TrafficPresetCode As String) As String
        Try
            Dim arParams(3) As SqlParameter
            Dim paramJobNumber As New SqlParameter("@JOB_NUM", SqlDbType.Int)
            paramJobNumber.Value = JobNum
            arParams(0) = paramJobNumber
            Dim paramJobCompNumber As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.Int)
            paramJobCompNumber.Value = JobCompNum
            arParams(1) = paramJobCompNumber
            Dim paramTrafficPresetCode As New SqlParameter("@TRF_PRESET_CODE", SqlDbType.VarChar, 6)
            paramTrafficPresetCode.Value = TrafficPresetCode
            arParams(2) = paramTrafficPresetCode
            Try
                oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_AddNew_AddFromPreset", arParams)
                Return ""
            Catch ex As Exception
                Return ex.Message.ToString
            End Try
        Catch ex As Exception
            Return ex.Message.ToString
        End Try
    End Function
    Public Function GetNextScheduleStatusCode(ByVal JobNum As Integer, ByVal JobCompNum As Integer) As DataTable
        Try
            Dim arParams(2) As SqlParameter
            Dim paramJobNumber As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            paramJobNumber.Value = JobNum
            arParams(0) = paramJobNumber
            Dim paramJobCompNumber As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
            paramJobCompNumber.Value = JobCompNum
            arParams(1) = paramJobCompNumber
            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_GetNextStatus", "dtNextCodeData", arParams)
        Catch ex As Exception
            Err.Raise(Err.Number, "Error GetNextScheduleStatusCode!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try
    End Function
    Public Function CalculateDueDates(ByVal JobNum As Integer, ByVal JobCompNum As Integer, ByVal pred As Integer) As Integer
        Try
            Dim arParams(4) As SqlParameter
            Dim paramJobNumber As New SqlParameter("@job_number", SqlDbType.Int)
            paramJobNumber.Value = JobNum
            arParams(0) = paramJobNumber
            Dim paramJobCompNumber As New SqlParameter("@job_component_nbr", SqlDbType.SmallInt)
            paramJobCompNumber.Value = JobCompNum
            arParams(1) = paramJobCompNumber
            Dim paramUsePredecessor As New SqlParameter("@use_predecessor", SqlDbType.Bit)
            paramUsePredecessor.Value = pred
            arParams(2) = paramUsePredecessor
            Dim paramRetVal As New SqlParameter("@ret_val", SqlDbType.Int)
            paramRetVal.Direction = ParameterDirection.Output
            arParams(3) = paramRetVal
            oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "advsp_calculate_schedule", arParams)
            Return paramRetVal.Value
        Catch ex As Exception
            Err.Raise(Err.Number, "Error GetNextScheduleStatusCode!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try
    End Function
    Public Function CalculateDueDatesPred(ByVal JobNum As Integer, ByVal JobCompNum As Integer, ByVal pred As Integer) As Integer
        Try
            Dim arParams(4) As SqlParameter
            Dim paramJobNumber As New SqlParameter("@job_number", SqlDbType.Int)
            paramJobNumber.Value = JobNum
            arParams(0) = paramJobNumber
            Dim paramJobCompNumber As New SqlParameter("@job_component_nbr", SqlDbType.SmallInt)
            paramJobCompNumber.Value = JobCompNum
            arParams(1) = paramJobCompNumber
            Dim paramUsePredecessor As New SqlParameter("@use_predecessor", SqlDbType.Bit)
            paramUsePredecessor.Value = pred
            arParams(2) = paramUsePredecessor
            Dim paramRetVal As New SqlParameter("@ret_val", SqlDbType.Int)
            paramRetVal.Direction = ParameterDirection.Output
            arParams(3) = paramRetVal
            oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_Calculate_Pred", arParams)
            Return paramRetVal.Value
        Catch ex As Exception
            Err.Raise(Err.Number, "Error GetNextScheduleStatusCode!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try
    End Function
    Public Function CalculateJobPreds(ByVal JobNum As Integer, ByVal JobCompNum As Integer, ByVal pred As Integer, ByVal empcode As String) As Integer
        Try
            Dim arParams(5) As SqlParameter
            Dim paramJobNumber As New SqlParameter("@job_number", SqlDbType.Int)
            paramJobNumber.Value = JobNum
            arParams(0) = paramJobNumber
            Dim paramJobCompNumber As New SqlParameter("@job_component_nbr", SqlDbType.SmallInt)
            paramJobCompNumber.Value = JobCompNum
            arParams(1) = paramJobCompNumber
            Dim paramUsePredecessor As New SqlParameter("@use_predecessor", SqlDbType.Bit)
            paramUsePredecessor.Value = pred
            arParams(2) = paramUsePredecessor
            Dim paramEmpCode As New SqlParameter("@emp_code", SqlDbType.VarChar)
            paramEmpCode.Value = empcode
            arParams(3) = paramEmpCode
            Dim paramRetVal As New SqlParameter("@ret_val", SqlDbType.Int)
            paramRetVal.Direction = ParameterDirection.Output
            arParams(4) = paramRetVal
            oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_Calculate_JobPred", arParams)
            Return paramRetVal.Value
        Catch ex As Exception
            Err.Raise(Err.Number, "Error GetNextScheduleStatusCode!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try
    End Function
    Public Sub GetPresetDays(ByVal PresetCode As String, ByRef StandardDays As Integer, ByRef RushDays As Integer)
        Dim SessionKey As String = "GetPresetDays" & PresetCode
        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Try
                Dim arP(1) As SqlParameter
                Dim pPresetCode As New SqlParameter("@TRF_PRESET_CODE", SqlDbType.VarChar, 6)
                pPresetCode.Value = PresetCode
                arP(0) = pPresetCode
                Dim r As SqlDataReader
                r = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_GetPresetDays", arP)
                If r.HasRows Then
                    Do While r.Read()
                        StandardDays = r("SUM_STD_DAYS")
                        RushDays = r("SUM_RUSH_DAYS")
                    Loop
                Else
                    StandardDays = 0
                    RushDays = 0
                End If
            Catch ex As Exception
                StandardDays = 0
                RushDays = 0
            End Try
            HttpContext.Current.Session(SessionKey & "StandardDays") = StandardDays
            HttpContext.Current.Session(SessionKey & "RushDays") = RushDays
        Else
            StandardDays = CType(HttpContext.Current.Session(SessionKey & "StandardDays").ToString(), Integer)
            RushDays = CType(HttpContext.Current.Session(SessionKey & "RushDays").ToString(), Integer)
        End If
    End Sub

    Public Function MarkTempComplete(ByVal JobNumber As Integer, ByVal JobComponentNbr As Integer) As String
        Try

            Dim arParams(2) As SqlParameter

            Dim paramJobNumber As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            paramJobNumber.Value = JobNumber
            arParams(0) = paramJobNumber

            Dim paramJobCompNumber As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
            paramJobCompNumber.Value = JobComponentNbr
            arParams(1) = paramJobCompNumber

            Try

                Dim Dt As New DataTable

                Dt = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_MarkTempComplete", "dt", arParams)

                Dim AutoAlertTaskEmployees As Boolean = False
                Dim asm As New AdvantageFramework.Web.AgencySettings.Methods(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"), HttpContext.Current)
                AutoAlertTaskEmployees = asm.GetValue(AdvantageFramework.Agency.Settings.TRF_NXT_TSK_AUTO_EML, "") = "1"

                If AutoAlertTaskEmployees = True AndAlso Not Dt Is Nothing AndAlso Dt.Rows.Count > 0 Then

                    Using DbContext As New AdvantageFramework.Database.DbContext(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"))

                        Dim ThisSeqNbr As Integer = 0

                        Dim cEmp As New Webvantage.cEmployee(HttpContext.Current.Session("ConnString"))
                        Dim EmpCodeString As String = ""
                        Dim NewAlertId As Integer = 0
                        Dim _Session As New AdvantageFramework.Security.Session(AdvantageFramework.Security.Application.Webvantage, HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"), HttpContext.Current.Session("AdvantageUserLicenseInUseID"), HttpContext.Current.Session("ConnString"))

                        For j As Integer = 0 To Dt.Rows.Count - 1

                            ThisSeqNbr = CType(Dt.Rows(j)("SEQ_NBR"), Integer)

                            NewAlertId = AdvantageFramework.ProjectSchedule.CreateTaskAlert(DbContext, JobNumber, JobComponentNbr, ThisSeqNbr, HttpContext.Current.Session("EmpCode"), EmpCodeString)

                            If NewAlertId > 0 Then

                                Dim eso As New EmailSessionObject(HttpContext.Current.Session("ConnString"),
                                                                  HttpContext.Current.Session("UserCode"),
                                                                  _Session,
                                                                  HttpContext.Current.Session("WebvantageURL"),
                                                                  HttpContext.Current.Session("ClientPortalURL"))
                                With eso

                                    .AlertId = NewAlertId
                                    .Subject = "[Alert Updated]"
                                    .EmployeeCodesToSendEmailTo = EmpCodeString
                                    .IsClientPortal = MiscFN.IsClientPortal
                                    .IncludeOriginator = False

                                End With

                                eso.SendEmailOnSeparateThread()

                            End If

                            EmpCodeString = ""
                            NewAlertId = 0

                        Next

                    End Using

                End If

                Return ""

            Catch ex As Exception

                Return ex.Message.ToString

            End Try
        Catch ex As Exception

            Return ex.Message.ToString

        End Try
    End Function

    Public Function NotifyGetTasksEmployees(ByVal JobNum As Integer, ByVal JobCompNum As Integer, Optional ByVal TaskSeqNbr As Integer = -1) As DataTable
        Try
            Dim arParams(4) As SqlParameter
            Dim paramJobNumber As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            paramJobNumber.Value = JobNum
            arParams(0) = paramJobNumber
            Dim paramJobCompNumber As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
            paramJobCompNumber.Value = JobCompNum
            arParams(1) = paramJobCompNumber
            Dim paramTaskSeqNbr As New SqlParameter("@SEQ_NBR", SqlDbType.SmallInt)
            paramTaskSeqNbr.Value = TaskSeqNbr
            arParams(2) = paramTaskSeqNbr
            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_NotifyGetTasksEmps", "dtEmpCodes", arParams)
        Catch ex As Exception
        End Try
    End Function
    Public Function NotifyGetEmailGroup(ByVal JobNum As Integer, ByVal JobCompNum As Integer, ByVal EmailGroupCode As String, ByVal GetSchedEmployees As Boolean) As DataTable
        Try
            Dim arParams(4) As SqlParameter
            Dim paramJobNumber As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            paramJobNumber.Value = JobNum
            arParams(0) = paramJobNumber
            Dim paramJobCompNumber As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
            paramJobCompNumber.Value = JobCompNum
            arParams(1) = paramJobCompNumber
            Dim paramEmailGroupCode As New SqlParameter("@EMAIL_GR_CODE", SqlDbType.VarChar, 50)
            paramEmailGroupCode.Value = EmailGroupCode
            arParams(2) = paramEmailGroupCode
            Dim paramGetSchedEmps As New SqlParameter("@GET_SCHEDULE_EMPLOYEES", SqlDbType.SmallInt)
            If GetSchedEmployees = True Then
                paramGetSchedEmps.Value = 1
            Else
                paramGetSchedEmps.Value = 0
            End If
            arParams(3) = paramGetSchedEmps
            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_NotifyGetDefaultGroup", "dtEmpCodes", arParams)
        Catch ex As Exception
        End Try
    End Function
    Public Function NotifyGetEmailEmployees(ByVal ListOfEmps As String, Optional ByVal AlertId As Integer = 0) As DataTable
        Try
            Dim arP(2) As SqlParameter
            Dim pList As New SqlParameter("@EMP_LIST", SqlDbType.VarChar)
            pList.Value = ListOfEmps
            arP(0) = pList
            Dim pAlertId As New SqlParameter("@ALERT_ID", SqlDbType.Int)
            pAlertId.Value = AlertId
            arP(1) = pAlertId
            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_EmpListFromString", "DtEmps", arP)
        Catch ex As Exception
        End Try
    End Function
    Public Function NotifyGetNextEmployeesList(ByVal JobNum As Integer, ByVal JobComp As Integer) As String
        Dim str As String
        Dim arParams(2) As SqlParameter
        Dim paramJobNum As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
        paramJobNum.Value = JobNum
        arParams(0) = paramJobNum
        Dim paramJobCompNum As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
        paramJobCompNum.Value = JobComp
        arParams(1) = paramJobCompNum
        Dim dr As SqlDataReader
        dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_NotifyGetNextEmpCodes", arParams)
        If dr.HasRows Then
            Do While dr.Read
                Try
                    str &= dr("EMP_CODE").ToString() & ", "
                Catch ex As Exception
                End Try
            Loop
            If str <> "" Then
                Return MiscFN.RemoveTrailingDelimiter(str, ",")
            End If
        Else
            Return ""
        End If
    End Function
    Public Function ApplyTeam(ByVal ByFunction As Boolean, ByVal JobNum As Integer, ByVal JobComp As Integer) As String
        Dim str As String
        Dim arParams(3) As SqlParameter
        Dim paramJobNum As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
        paramJobNum.Value = JobNum
        arParams(0) = paramJobNum
        Dim paramJobCompNum As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
        paramJobCompNum.Value = JobComp
        arParams(1) = paramJobCompNum
        Dim paramTask_UserCode As New SqlParameter("@UserCode", SqlDbType.VarChar)
        paramTask_UserCode.Value = HttpContext.Current.Session("UserCode")
        arParams(2) = paramTask_UserCode
        Dim i As Integer
        If ByFunction = True Then
            Try
                i = oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_ApplyTeam_ByFunction", arParams)
                Return ""
            Catch ex As Exception
                Return ex.Message.ToString
            End Try
        Else 'by role usp_wv_Traffic_Schedule_ApplyTeam_ByRole
            Try
                i = oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_ApplyTeam_ByRole", arParams)
                Return ""
            Catch ex As Exception
                Return ex.Message.ToString
            End Try
        End If
    End Function
    Public Function GetDistinctPhases(ByVal JobNumber As Integer, ByVal JobComponentNbr As Integer) As DataTable
        Dim arParams(2) As SqlParameter
        Dim pJobNumber As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
        pJobNumber.Value = JobNumber
        arParams(0) = pJobNumber
        Dim pJobComponentNbr As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
        pJobComponentNbr.Value = JobComponentNbr
        arParams(1) = pJobComponentNbr
        Try
            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_GetDistinctPhases", "DtDistinctPhases", arParams)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function GetAlertRequirements(ByVal JobNum As Integer, ByVal JobCompNum As Integer, ByVal Client As String, ByVal Division As String, ByVal Product As String) As DataTable
        Try
            Dim arParams(5) As SqlParameter
            Dim paramJobNumber As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            paramJobNumber.Value = JobNum
            arParams(0) = paramJobNumber
            Dim paramJobCompNumber As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.Int)
            paramJobCompNumber.Value = JobCompNum
            arParams(1) = paramJobCompNumber
            Dim paramClient As New SqlParameter("@Client", SqlDbType.VarChar)
            paramClient.Value = Client
            arParams(2) = paramClient
            Dim paramDivision As New SqlParameter("@Division", SqlDbType.VarChar)
            paramDivision.Value = Division
            arParams(3) = paramDivision
            Dim paramProduct As New SqlParameter("@Product", SqlDbType.VarChar)
            paramProduct.Value = Product
            arParams(4) = paramProduct
            Dim dt As New DataTable
            dt = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_GetAlertRequirements_ByJobAndComp", "dtAlertReqs", arParams)
            Return dt
        Catch ex As Exception
            Err.Raise(Err.Number, "Error GetAlertRequirements!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try
    End Function
#End Region
#Region " Schedule Multi View "
    Public Function UpdateMultiviewHeaders(ByVal JobNum As Integer, ByVal JobCompNum As Integer, ByVal TrafficStatusCode As String, ByVal StartDate As String, ByVal DueDate As String, ByVal CompletedDate As String, ByVal Comments As String, ByVal percentcomplete As Decimal) As String
        Try
            Dim arParams(8) As SqlParameter
            Dim paramJobNumber As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            paramJobNumber.Value = JobNum
            arParams(0) = paramJobNumber
            Dim paramJobCompNumber As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
            paramJobCompNumber.Value = JobCompNum
            arParams(1) = paramJobCompNumber
            Dim paramTRF_CODE As New SqlParameter("@TRF_CODE", SqlDbType.VarChar, 10)
            paramTRF_CODE.Value = TrafficStatusCode
            arParams(2) = paramTRF_CODE
            Dim paramSTART_DATE As New SqlParameter("@START_DATE", SqlDbType.SmallDateTime)
            If StartDate.Trim = "" Then
                paramSTART_DATE.Value = DBNull.Value
            Else
                paramSTART_DATE.Value = StartDate
            End If
            arParams(3) = paramSTART_DATE
            Dim paramJOB_FIRST_USE_DATE As New SqlParameter("@JOB_FIRST_USE_DATE", SqlDbType.SmallDateTime)
            If DueDate.Trim = "" Then
                paramJOB_FIRST_USE_DATE.Value = DBNull.Value
            Else
                paramJOB_FIRST_USE_DATE.Value = DueDate
            End If
            arParams(4) = paramJOB_FIRST_USE_DATE
            Dim paramCOMPLETED_DATE As New SqlParameter("@COMPLETED_DATE", SqlDbType.SmallDateTime)
            If CompletedDate.Trim = "" Then
                paramCOMPLETED_DATE.Value = DBNull.Value
            Else
                paramCOMPLETED_DATE.Value = CompletedDate
            End If
            arParams(5) = paramCOMPLETED_DATE
            Dim paramTRF_COMMENTS As New SqlParameter("@TRF_COMMENTS", SqlDbType.Text)
            paramTRF_COMMENTS.Value = Comments
            arParams(6) = paramTRF_COMMENTS
            Dim pPercentComplete As New SqlParameter("@PERCENT_COMPLETE", SqlDbType.Decimal)
            pPercentComplete.Value = percentcomplete
            arParams(7) = pPercentComplete
            Try
                oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_SaveHeader_Multi", arParams)
            Catch ex As Exception
                Return ex.Message.ToString
            End Try
        Catch ex As Exception
            Return ex.Message.ToString
        End Try
    End Function
#End Region
#Region " Task "
    Public Function GetScheduleTasks(ByVal JobNum As Integer, ByVal JobCompNum As Integer, ByVal Sort As String, ByVal UserCode As String,
    Optional ByVal EmpCode As String = "", Optional ByVal TaskCode As String = "", Optional ByVal RoleCode As String = "", Optional ByVal IncludeCompletedTasks As Boolean = True,
    Optional ByVal IncludeOnlyPendingTasks As Boolean = False, Optional ByVal ExcludeProjectedTasks As Boolean = False, Optional ByVal CutOffDate As String = "", Optional ByVal PhaseFilter As String = "", Optional ByVal Gantt As Boolean = False) As DataTable
        Try
            Dim arParams(13) As SqlParameter
            Dim paramJobNumber As New SqlParameter("@JobNum", SqlDbType.Int)
            paramJobNumber.Value = JobNum
            arParams(0) = paramJobNumber
            Dim paramJobCompNumber As New SqlParameter("@JobCompNum", SqlDbType.Int)
            paramJobCompNumber.Value = JobCompNum
            arParams(1) = paramJobCompNumber
            Dim paramSort As New SqlParameter("@Sort", SqlDbType.VarChar, 10)
            paramSort.Value = Sort
            arParams(2) = paramSort
            Dim paramUserCode As New SqlParameter("@USER_ID", SqlDbType.VarChar, 100)
            paramUserCode.Value = UserCode
            arParams(3) = paramUserCode
            Dim paramEmpCode As New SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
            paramEmpCode.Value = EmpCode
            arParams(4) = paramEmpCode
            Dim paramTaskCode As New SqlParameter("@TASK_CODE", SqlDbType.VarChar, 10)
            paramTaskCode.Value = TaskCode
            arParams(5) = paramTaskCode
            Dim paramRoleCode As New SqlParameter("@ROLE_CODE", SqlDbType.VarChar, 6)
            paramRoleCode.Value = RoleCode
            arParams(6) = paramRoleCode
            Dim paramIncludeCompletedTasks As New SqlParameter("@IncludeCompletedTasks", SqlDbType.Char)
            If IncludeCompletedTasks = True Then
                paramIncludeCompletedTasks.Value = "Y"
            Else
                paramIncludeCompletedTasks.Value = "N"
            End If
            arParams(7) = paramIncludeCompletedTasks
            Dim paramIncludeOnlyPendingTasks As New SqlParameter("@IncludeOnlyPendingTasks", SqlDbType.Char)
            If IncludeOnlyPendingTasks = True Then
                paramIncludeOnlyPendingTasks.Value = "Y"
            Else
                paramIncludeOnlyPendingTasks.Value = "N"
            End If
            arParams(8) = paramIncludeOnlyPendingTasks
            Dim paramExcludeProjectedTasks As New SqlParameter("@ExcludeProjectedTasks", SqlDbType.Char)
            If ExcludeProjectedTasks = True Then
                paramExcludeProjectedTasks.Value = "Y"
            Else
                paramExcludeProjectedTasks.Value = "N"
            End If
            arParams(9) = paramExcludeProjectedTasks
            Dim paramCutOffDate As New SqlParameter("@CUT_OFF_DATE", SqlDbType.SmallDateTime)
            If cGlobals.wvIsDate(CutOffDate) = True Then
                paramCutOffDate.Value = CDate(CDate(CutOffDate).ToShortDateString & " 23:59:00")
            Else
                paramCutOffDate.Value = DBNull.Value
            End If
            arParams(10) = paramCutOffDate
            Dim paramPhaseFilter As New SqlParameter("@PHASE_FILTER", SqlDbType.VarChar, 10)
            paramPhaseFilter.Value = PhaseFilter
            arParams(11) = paramPhaseFilter
            Dim paramGantt As New SqlParameter("@GANTT", SqlDbType.Bit)
            If Gantt = True Then
                paramGantt.Value = 1
            Else
                paramGantt.Value = 0
            End If
            arParams(12) = paramGantt
            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_GetTasks", "dtTasks", arParams)
        Catch ex As Exception
            Err.Raise(Err.Number, "Error GetTrafficScheduleTasks!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try
    End Function
    Public Function GetScheduleTaskswithClosed(ByVal JobNum As Integer, ByVal JobCompNum As Integer, ByVal Sort As String, ByVal UserCode As String,
    Optional ByVal EmpCode As String = "", Optional ByVal TaskCode As String = "", Optional ByVal RoleCode As String = "", Optional ByVal IncludeCompletedTasks As Boolean = True,
    Optional ByVal IncludeOnlyPendingTasks As Boolean = False, Optional ByVal ExcludeProjectedTasks As Boolean = False, Optional ByVal CutOffDate As String = "") As DataTable
        Try
            Dim arParams(11) As SqlParameter
            Dim paramJobNumber As New SqlParameter("@JobNum", SqlDbType.Int)
            paramJobNumber.Value = JobNum
            arParams(0) = paramJobNumber
            Dim paramJobCompNumber As New SqlParameter("@JobCompNum", SqlDbType.Int)
            paramJobCompNumber.Value = JobCompNum
            arParams(1) = paramJobCompNumber
            Dim paramSort As New SqlParameter("@Sort", SqlDbType.VarChar, 10)
            paramSort.Value = Sort
            arParams(2) = paramSort
            Dim paramUserCode As New SqlParameter("@USER_ID", SqlDbType.VarChar, 100)
            paramUserCode.Value = UserCode
            arParams(3) = paramUserCode
            Dim paramEmpCode As New SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
            paramEmpCode.Value = EmpCode
            arParams(4) = paramEmpCode
            Dim paramTaskCode As New SqlParameter("@TASK_CODE", SqlDbType.VarChar, 10)
            paramTaskCode.Value = TaskCode
            arParams(5) = paramTaskCode
            Dim paramRoleCode As New SqlParameter("@ROLE_CODE", SqlDbType.VarChar, 6)
            paramRoleCode.Value = RoleCode
            arParams(6) = paramRoleCode
            Dim paramIncludeCompletedTasks As New SqlParameter("@IncludeCompletedTasks", SqlDbType.Char)
            If IncludeCompletedTasks = True Then
                paramIncludeCompletedTasks.Value = "Y"
            Else
                paramIncludeCompletedTasks.Value = "N"
            End If
            arParams(7) = paramIncludeCompletedTasks
            Dim paramIncludeOnlyPendingTasks As New SqlParameter("@IncludeOnlyPendingTasks", SqlDbType.Char)
            If IncludeOnlyPendingTasks = True Then
                paramIncludeOnlyPendingTasks.Value = "Y"
            Else
                paramIncludeOnlyPendingTasks.Value = "N"
            End If
            arParams(8) = paramIncludeOnlyPendingTasks
            Dim paramExcludeProjectedTasks As New SqlParameter("@ExcludeProjectedTasks", SqlDbType.Char)
            If ExcludeProjectedTasks = True Then
                paramExcludeProjectedTasks.Value = "Y"
            Else
                paramExcludeProjectedTasks.Value = "N"
            End If
            arParams(9) = paramExcludeProjectedTasks
            Dim paramCutOffDate As New SqlParameter("@CUT_OFF_DATE", SqlDbType.VarChar, 15)
            If cGlobals.wvIsDate(CutOffDate) = True Then
                paramCutOffDate.Value = cGlobals.wvCDate(CutOffDate).ToShortDateString
            Else
                paramCutOffDate.Value = DBNull.Value
            End If
            arParams(10) = paramCutOffDate
            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_GetTasks_withClosed", "dtTasks", arParams)
        Catch ex As Exception
            Err.Raise(Err.Number, "Error GetTrafficScheduleTasks!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try
    End Function
    Public Function GetScheduleTask(ByVal Task_JobNum As Integer, ByVal Task_JobCompNum As Integer, ByVal Task_SeqNum As Integer) As DataTable
        Try
            Dim arParams(3) As SqlParameter
            Dim paramTask_JobNum As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            paramTask_JobNum.Value = Task_JobNum
            arParams(0) = paramTask_JobNum
            Dim paramTask_JobCompNum As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.Int)
            paramTask_JobCompNum.Value = Task_JobCompNum
            arParams(1) = paramTask_JobCompNum
            Dim paramTask_SeqNum As New SqlParameter("@SEQ", SqlDbType.SmallInt)
            paramTask_SeqNum.Value = Task_SeqNum
            arParams(2) = paramTask_SeqNum
            Dim ds As New DataSet
            Dim dt As New DataTable
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_GetTask", arParams)
            dt = ds.Tables(0)
            Return dt
        Catch ex As Exception
        End Try
    End Function
    Public Function GetScheduleCalendarRpt(ByVal Job As Integer, ByVal Comp As Integer, ByVal milestone As Boolean, Optional ByVal completed As Boolean = True) As DataTable
        Try
            Dim arParams(4) As SqlParameter
            Dim paramTask_JobNum As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            paramTask_JobNum.Value = Job
            arParams(0) = paramTask_JobNum
            Dim paramTask_JobCompNum As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.Int)
            paramTask_JobCompNum.Value = Comp
            arParams(1) = paramTask_JobCompNum
            Dim paramMS As New SqlParameter("@Milestone", SqlDbType.Int)
            If milestone = True Then
                paramMS.Value = 1
            Else
                paramMS.Value = 0
            End If
            arParams(2) = paramMS

            Dim paramCompleted As New SqlParameter("@Completed", SqlDbType.Int)
            If completed = True Then
                paramCompleted.Value = 1
            Else
                paramCompleted.Value = 0
            End If
            arParams(3) = paramCompleted
            Dim ds As New DataSet
            Dim dt As New DataTable
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_Calendar", arParams)
            dt = ds.Tables(0)
            Return dt
        Catch ex As Exception
        End Try
    End Function
    Public Function UpdateTaskRowLock(ByVal Task_JobNum As Integer, ByVal Task_JobCompNum As Integer, ByVal Task_SeqNum As Integer) As String
        Try
            Dim arParams(3) As SqlParameter
            Dim paramTask_JobNum As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            paramTask_JobNum.Value = Task_JobNum
            arParams(0) = paramTask_JobNum
            Dim paramTask_JobCompNum As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.Int)
            paramTask_JobCompNum.Value = Task_JobCompNum
            arParams(1) = paramTask_JobCompNum
            Dim paramTask_SeqNum As New SqlParameter("@SEQ", SqlDbType.SmallInt)
            paramTask_SeqNum.Value = Task_SeqNum
            arParams(2) = paramTask_SeqNum
            oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_SaveTask_Lock", arParams)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function GetTrafficDetComments(ByVal Task_JobNum As Integer, ByVal Task_JobCompNum As Integer, ByVal Task_SeqNum As Integer) As DataTable
        Try
            Dim arParams(3) As SqlParameter
            Dim paramTask_JobNum As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            paramTask_JobNum.Value = Task_JobNum
            arParams(0) = paramTask_JobNum
            Dim paramTask_JobCompNum As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.Int)
            paramTask_JobCompNum.Value = Task_JobCompNum
            arParams(1) = paramTask_JobCompNum
            Dim paramTask_SeqNum As New SqlParameter("@SEQ", SqlDbType.SmallInt)
            paramTask_SeqNum.Value = Task_SeqNum
            arParams(2) = paramTask_SeqNum
            Dim dt As New DataTable
            dt = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_GetDetComments", "Comments", arParams)
            Return dt
        Catch ex As Exception
        End Try
    End Function
    Public Function GetTaskComments(ByVal Task_JobNum As Integer, ByVal Task_JobCompNum As Integer, ByVal Task_SeqNum As Integer, ByRef StrDueDateComments As String, ByRef StrRevisionDateComments As String, ByRef StrFunctionComments As String, Optional ByRef StrTaskComments As String = "") As Boolean
        Try
            Dim arParams(3) As SqlParameter
            Dim paramTask_JobNum As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            paramTask_JobNum.Value = Task_JobNum
            arParams(0) = paramTask_JobNum
            Dim paramTask_JobCompNum As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.Int)
            paramTask_JobCompNum.Value = Task_JobCompNum
            arParams(1) = paramTask_JobCompNum
            Dim paramTask_SeqNum As New SqlParameter("@SEQ", SqlDbType.SmallInt)
            paramTask_SeqNum.Value = Task_SeqNum
            arParams(2) = paramTask_SeqNum
            Dim ds As New DataSet
            Dim dt As New DataTable
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_GetTask_Comments", arParams)
            dt = ds.Tables(0)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt.Rows(0)("TRF_COMMENTS")) = False Then
                    StrTaskComments = dt.Rows(0)("TRF_COMMENTS")
                Else
                    StrTaskComments = ""
                End If
                If IsDBNull(dt.Rows(0)("DUE_DATE_COMMENTS")) = False Then
                    StrDueDateComments = dt.Rows(0)("DUE_DATE_COMMENTS")
                Else
                    StrDueDateComments = ""
                End If
                If IsDBNull(dt.Rows(0)("REV_DATE_COMMENTS")) = False Then
                    StrRevisionDateComments = dt.Rows(0)("REV_DATE_COMMENTS")
                Else
                    StrRevisionDateComments = ""
                End If
                If IsDBNull(dt.Rows(0)("FNC_COMMENTS")) = False Then
                    StrFunctionComments = dt.Rows(0)("FNC_COMMENTS")
                Else
                    StrFunctionComments = ""
                End If
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function UpdateTaskComments(ByVal Task_JobNum As Integer, ByVal Task_JobCompNum As Integer, ByVal Task_SeqNum As Integer, ByVal StrDueDateComments As String, ByVal StrRevisionDateComments As String, ByVal StrFunctionComments As String, Optional ByVal StrTaskComments As String = "") As Boolean
        Try
            Dim arParams(6) As SqlParameter
            Dim paramTask_JobNum As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            paramTask_JobNum.Value = Task_JobNum
            arParams(0) = paramTask_JobNum
            Dim paramTask_JobCompNum As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.Int)
            paramTask_JobCompNum.Value = Task_JobCompNum
            arParams(1) = paramTask_JobCompNum
            Dim paramTask_SeqNum As New SqlParameter("@SEQ", SqlDbType.SmallInt)
            paramTask_SeqNum.Value = Task_SeqNum
            arParams(2) = paramTask_SeqNum
            Dim paramTaskComment As New SqlParameter("@TaskComment", SqlDbType.NText)
            paramTaskComment.Value = StrFunctionComments
            arParams(3) = paramTaskComment
            Dim paramDueDateComment As New SqlParameter("@DueDateComment", SqlDbType.NText)
            paramDueDateComment.Value = StrDueDateComments
            arParams(4) = paramDueDateComment
            Dim paramRevisionDateComment As New SqlParameter("@RevisionDateComment", SqlDbType.NText)
            paramRevisionDateComment.Value = StrRevisionDateComments
            arParams(5) = paramRevisionDateComment
            oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_SaveTask_Comments", arParams)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function AddNewTask(ByVal Task_JobNum As Integer, ByVal Task_JobCompNum As Integer,
    ByVal nJobOrder As Integer, ByVal nPhaseID As Integer, ByVal nPredString As String,
    ByVal nTaskFnCode As String, ByVal nTaskDesc As String, ByVal nMilestone As Integer, ByVal nJobDays As Integer,
    ByVal nJobHours As Decimal, ByVal nStartDate As String, ByVal nRevisedDate As String, ByVal nDueTime As String,
    ByVal nDueDate As String, ByVal nDueDateLock As Boolean, ByVal nJobCompletedDate As String, ByVal nEmpCodeString As String, ByVal nEstFunc As String, ByVal nFuncCmmt As String,
    ByVal nDueDateCmmt As String, ByVal nRevDateCmmt As String, ByVal nRoleCode As String, ByVal nClientCodeString As String, ByVal nTaskStatus As String) As String
        If Task_JobNum > 0 And Task_JobCompNum > 0 Then
            Dim arParams(25) As SqlParameter
            Dim paramTask_JobNum As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            paramTask_JobNum.Value = Task_JobNum
            arParams(0) = paramTask_JobNum
            Dim paramTask_JobCompNum As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
            paramTask_JobCompNum.Value = Task_JobCompNum
            arParams(1) = paramTask_JobCompNum
            Dim pJobOrder As SqlParameter = New SqlParameter("@JOB_ORDER", SqlDbType.SmallInt)
            If nJobOrder = 0 Then
                pJobOrder.Value = DBNull.Value
            Else
                pJobOrder.Value = nJobOrder
            End If
            arParams(2) = pJobOrder
            Dim pPhaseID As SqlParameter = New SqlParameter("@TRAFFIC_PHASE_ID", SqlDbType.Int)
            If nPhaseID = 0 Then
                pPhaseID.Value = DBNull.Value
            Else
                pPhaseID.Value = nPhaseID
            End If
            arParams(3) = pPhaseID
            Dim pTaskFnCode As SqlParameter = New SqlParameter("@FNC_CODE", SqlDbType.VarChar, 10)
            If nTaskFnCode = "" Then
                pTaskFnCode.Value = DBNull.Value
            Else
                pTaskFnCode.Value = nTaskFnCode
            End If
            arParams(4) = pTaskFnCode
            Dim pTaskDesc As SqlParameter = New SqlParameter("@TASK_DESCRIPTION", SqlDbType.VarChar, 40)
            If nTaskDesc = "" Then
                pTaskDesc.Value = DBNull.Value
            Else
                pTaskDesc.Value = nTaskDesc
            End If
            arParams(5) = pTaskDesc
            Dim pMilestone As SqlParameter = New SqlParameter("@MILESTONE", SqlDbType.SmallInt)
            If nMilestone = 0 Then
                pMilestone.Value = 0 ' DBNull.Value
            Else
                pMilestone.Value = 1
            End If
            arParams(6) = pMilestone
            Dim pJobDays As SqlParameter = New SqlParameter("@JOB_DAYS", SqlDbType.SmallInt)
            If nJobDays = 0 Then
                pJobDays.Value = 0 'DBNull.Value
            Else
                pJobDays.Value = nJobDays
            End If
            arParams(7) = pJobDays
            Dim pJobHours As SqlParameter = New SqlParameter("@JOB_HRS", SqlDbType.Decimal)
            If nJobHours = 0 Then
                pJobHours.Value = 0 'DBNull.Value
            Else
                pJobHours.Value = nJobHours
            End If
            arParams(8) = pJobHours
            Dim pStartDate As SqlParameter = New SqlParameter("@TASK_START_DATE", SqlDbType.SmallDateTime)
            If wvIsDate(nStartDate) = False Then
                pStartDate.Value = DBNull.Value
            Else
                pStartDate.Value = wvCDate(nStartDate)
            End If
            arParams(9) = pStartDate
            Dim pRevisedDate As SqlParameter = New SqlParameter("@JOB_REVISED_DATE", SqlDbType.SmallDateTime)
            If wvIsDate(nRevisedDate) = False Then
                pRevisedDate.Value = DBNull.Value
            Else
                pRevisedDate.Value = wvCDate(nRevisedDate)
            End If
            arParams(10) = pRevisedDate
            Dim pDueTime As SqlParameter = New SqlParameter("@DUE_TIME", SqlDbType.VarChar, 10)
            If nDueTime = "" Then
                pDueTime.Value = DBNull.Value
            Else
                pDueTime.Value = nDueTime
            End If
            arParams(11) = pDueTime
            Dim pDueDate As SqlParameter = New SqlParameter("@JOB_DUE_DATE", SqlDbType.SmallDateTime)
            If wvIsDate(nDueDate) = False Then
                pDueDate.Value = DBNull.Value
            Else
                pDueDate.Value = wvCDate(nDueDate)
            End If
            arParams(12) = pDueDate
            Dim pDueDateLock As SqlParameter = New SqlParameter("@DUE_DATE_LOCK", SqlDbType.SmallInt)
            If nDueDateLock = False Then
                pDueDateLock.Value = DBNull.Value
            Else
                pDueDateLock.Value = 1
            End If
            arParams(13) = pDueDateLock
            Dim pJobCompletedDate As SqlParameter = New SqlParameter("@JOB_COMPLETED_DATE", SqlDbType.SmallDateTime)
            If wvIsDate(nJobCompletedDate) = False Then
                pJobCompletedDate.Value = DBNull.Value
            Else
                pJobCompletedDate.Value = wvCDate(nJobCompletedDate)
            End If
            arParams(14) = pJobCompletedDate
            Dim pEstFunc As SqlParameter = New SqlParameter("@FNC_EST", SqlDbType.VarChar, 6)
            If nEstFunc = "" Or nEstFunc = "[None]" Then
                pEstFunc.Value = DBNull.Value
            Else
                pEstFunc.Value = nEstFunc
            End If
            arParams(15) = pEstFunc
            Dim pFuncCmmt As SqlParameter = New SqlParameter("@FNC_COMMENTS", SqlDbType.Text)
            If nFuncCmmt = "" Then
                pFuncCmmt.Value = DBNull.Value
            Else
                pFuncCmmt.Value = nFuncCmmt
            End If
            arParams(16) = pFuncCmmt
            Dim pDueDateCmmt As SqlParameter = New SqlParameter("@DUE_DATE_COMMENTS", SqlDbType.Text)
            If nDueDateCmmt = "" Then
                pDueDateCmmt.Value = DBNull.Value
            Else
                pDueDateCmmt.Value = nDueDateCmmt
            End If
            arParams(17) = pDueDateCmmt
            Dim pRevDateCmmt As SqlParameter = New SqlParameter("@REV_DATE_COMMENTS", SqlDbType.Text)
            If nRevDateCmmt = "" Then
                pRevDateCmmt.Value = DBNull.Value
            Else
                pRevDateCmmt.Value = nRevDateCmmt
            End If
            arParams(18) = pRevDateCmmt
            Dim pEmpList As SqlParameter = New SqlParameter("@EMP_LIST", SqlDbType.VarChar, 2000)
            If nEmpCodeString = "" Then
                pEmpList.Value = DBNull.Value
            Else
                pEmpList.Value = MiscFN.RemoveDuplicatesFromString(nEmpCodeString, ",")
            End If
            arParams(19) = pEmpList
            Dim pPredList As SqlParameter = New SqlParameter("@PRED_LIST", SqlDbType.VarChar, 2000)
            If nPredString = "" Then
                pPredList.Value = DBNull.Value
            Else
                pPredList.Value = nPredString
            End If
            arParams(20) = pPredList
            Dim pRoleCode As SqlParameter = New SqlParameter("@TRF_ROLE", SqlDbType.VarChar, 6)
            If nRoleCode = "" Then
                pRoleCode.Value = DBNull.Value
            Else
                pRoleCode.Value = nRoleCode
            End If
            arParams(21) = pRoleCode
            Dim paramRetVal As New SqlParameter("@ROWID", SqlDbType.Int)
            paramRetVal.Direction = ParameterDirection.Output
            arParams(22) = paramRetVal
            Dim pContactList As SqlParameter = New SqlParameter("@CONTACT_IDS", SqlDbType.VarChar, 2000)
            If nClientCodeString = "" Then
                pContactList.Value = DBNull.Value
            Else
                pContactList.Value = MiscFN.RemoveDuplicatesFromString(nClientCodeString, ",")
            End If
            arParams(23) = pContactList
            Dim pTaskStatus As SqlParameter = New SqlParameter("@TASK_STATUS", SqlDbType.VarChar, 1)
            If nTaskStatus = "" Then
                pTaskStatus.Value = DBNull.Value
            Else
                pTaskStatus.Value = nTaskStatus
            End If
            arParams(24) = pTaskStatus

            Dim paramUSERCODE As New SqlParameter("@user_id", SqlDbType.Text)
            paramUSERCODE.Value = HttpContext.Current.Session("UserCode")
            arParams(25) = paramUSERCODE

            Dim i As Integer = -1
            Try
                i = oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_Add_Task", arParams)
                Return paramRetVal.Value
            Catch ex As Exception
                Return ex.Message.ToString
            End Try
        End If
    End Function
    Public Function AddNewTaskCopyFrom(ByVal Task_JobNum As Integer, ByVal Task_JobCompNum As Integer,
    ByVal nJobOrder As Integer, ByVal nPhaseID As Integer, ByVal nPredString As String,
    ByVal nTaskFnCode As String, ByVal nTaskDesc As String, ByVal nMilestone As Integer, ByVal nJobDays As Integer,
    ByVal nJobHours As Decimal, ByVal nStartDate As String, ByVal nRevisedDate As String, ByVal nDueTime As String,
    ByVal nDueDate As String, ByVal nDueDateLock As Boolean, ByVal nJobCompletedDate As String, ByVal nEmpCodeString As String, ByVal nEstFunc As String, ByVal nFuncCmmt As String,
    ByVal nDueDateCmmt As String, ByVal nRevDateCmmt As String, ByVal nRoleCode As String, ByVal nClientCodeString As String, ByVal nTaskStatus As String, ByVal nSeqNbr As Integer, ByVal GridOrder As Short?) As String
        If Task_JobNum > 0 And Task_JobCompNum > 0 Then
            Dim arParams(27) As SqlParameter
            Dim paramTask_JobNum As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            paramTask_JobNum.Value = Task_JobNum
            arParams(0) = paramTask_JobNum
            Dim paramTask_JobCompNum As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
            paramTask_JobCompNum.Value = Task_JobCompNum
            arParams(1) = paramTask_JobCompNum
            Dim pJobOrder As SqlParameter = New SqlParameter("@JOB_ORDER", SqlDbType.SmallInt)
            If nJobOrder = 0 Then
                pJobOrder.Value = DBNull.Value
            Else
                pJobOrder.Value = nJobOrder
            End If
            arParams(2) = pJobOrder
            Dim pPhaseID As SqlParameter = New SqlParameter("@TRAFFIC_PHASE_ID", SqlDbType.Int)
            If nPhaseID = 0 Then
                pPhaseID.Value = DBNull.Value
            Else
                pPhaseID.Value = nPhaseID
            End If
            arParams(3) = pPhaseID
            Dim pTaskFnCode As SqlParameter = New SqlParameter("@FNC_CODE", SqlDbType.VarChar, 10)
            If nTaskFnCode = "" Then
                pTaskFnCode.Value = DBNull.Value
            Else
                pTaskFnCode.Value = nTaskFnCode
            End If
            arParams(4) = pTaskFnCode
            Dim pTaskDesc As SqlParameter = New SqlParameter("@TASK_DESCRIPTION", SqlDbType.VarChar, 40)
            If nTaskDesc = "" Then
                pTaskDesc.Value = DBNull.Value
            Else
                pTaskDesc.Value = nTaskDesc
            End If
            arParams(5) = pTaskDesc
            Dim pMilestone As SqlParameter = New SqlParameter("@MILESTONE", SqlDbType.SmallInt)
            If nMilestone = 0 Then
                pMilestone.Value = 0 ' DBNull.Value
            Else
                pMilestone.Value = 1
            End If
            arParams(6) = pMilestone
            Dim pJobDays As SqlParameter = New SqlParameter("@JOB_DAYS", SqlDbType.SmallInt)
            If nJobDays = 0 Then
                pJobDays.Value = 0 'DBNull.Value
            Else
                pJobDays.Value = nJobDays
            End If
            arParams(7) = pJobDays
            Dim pJobHours As SqlParameter = New SqlParameter("@JOB_HRS", SqlDbType.Decimal)
            If nJobHours = 0 Then
                pJobHours.Value = 0 'DBNull.Value
            Else
                pJobHours.Value = nJobHours
            End If
            arParams(8) = pJobHours
            Dim pStartDate As SqlParameter = New SqlParameter("@TASK_START_DATE", SqlDbType.SmallDateTime)
            If wvIsDate(nStartDate) = False Then
                pStartDate.Value = DBNull.Value
            Else
                pStartDate.Value = wvCDate(nStartDate)
            End If
            arParams(9) = pStartDate
            Dim pRevisedDate As SqlParameter = New SqlParameter("@JOB_REVISED_DATE", SqlDbType.SmallDateTime)
            If wvIsDate(nRevisedDate) = False Then
                pRevisedDate.Value = DBNull.Value
            Else
                pRevisedDate.Value = wvCDate(nRevisedDate)
            End If
            arParams(10) = pRevisedDate
            Dim pDueTime As SqlParameter = New SqlParameter("@DUE_TIME", SqlDbType.VarChar, 10)
            If nDueTime = "" Then
                pDueTime.Value = DBNull.Value
            Else
                pDueTime.Value = nDueTime
            End If
            arParams(11) = pDueTime
            Dim pDueDate As SqlParameter = New SqlParameter("@JOB_DUE_DATE", SqlDbType.SmallDateTime)
            If wvIsDate(nDueDate) = False Then
                pDueDate.Value = DBNull.Value
            Else
                pDueDate.Value = wvCDate(nDueDate)
            End If
            arParams(12) = pDueDate
            Dim pDueDateLock As SqlParameter = New SqlParameter("@DUE_DATE_LOCK", SqlDbType.SmallInt)
            If nDueDateLock = False Then
                pDueDateLock.Value = DBNull.Value
            Else
                pDueDateLock.Value = 1
            End If
            arParams(13) = pDueDateLock
            Dim pJobCompletedDate As SqlParameter = New SqlParameter("@JOB_COMPLETED_DATE", SqlDbType.SmallDateTime)
            'If wvIsDate(nJobCompletedDate) = False Then
            pJobCompletedDate.Value = DBNull.Value
            'Else
            '    pJobCompletedDate.Value = wvCDate(nJobCompletedDate)
            'End If
            arParams(14) = pJobCompletedDate
            Dim pEstFunc As SqlParameter = New SqlParameter("@FNC_EST", SqlDbType.VarChar, 6)
            If nEstFunc = "" Or nEstFunc = "[None]" Then
                pEstFunc.Value = DBNull.Value
            Else
                pEstFunc.Value = nEstFunc
            End If
            arParams(15) = pEstFunc
            Dim pFuncCmmt As SqlParameter = New SqlParameter("@FNC_COMMENTS", SqlDbType.Text)
            If nFuncCmmt = "" Then
                pFuncCmmt.Value = DBNull.Value
            Else
                pFuncCmmt.Value = nFuncCmmt
            End If
            arParams(16) = pFuncCmmt
            Dim pDueDateCmmt As SqlParameter = New SqlParameter("@DUE_DATE_COMMENTS", SqlDbType.Text)
            If nDueDateCmmt = "" Then
                pDueDateCmmt.Value = DBNull.Value
            Else
                pDueDateCmmt.Value = nDueDateCmmt
            End If
            arParams(17) = pDueDateCmmt
            Dim pRevDateCmmt As SqlParameter = New SqlParameter("@REV_DATE_COMMENTS", SqlDbType.Text)
            If nRevDateCmmt = "" Then
                pRevDateCmmt.Value = DBNull.Value
            Else
                pRevDateCmmt.Value = nRevDateCmmt
            End If
            arParams(18) = pRevDateCmmt
            Dim pEmpList As SqlParameter = New SqlParameter("@EMP_LIST", SqlDbType.VarChar, 2000)
            If nEmpCodeString = "" Then
                pEmpList.Value = DBNull.Value
            Else
                pEmpList.Value = MiscFN.RemoveDuplicatesFromString(nEmpCodeString, ",")
            End If
            arParams(19) = pEmpList
            Dim pPredList As SqlParameter = New SqlParameter("@PRED_LIST", SqlDbType.VarChar, 2000)
            If nPredString = "" Then
                pPredList.Value = DBNull.Value
            Else
                pPredList.Value = nPredString
            End If
            arParams(20) = pPredList
            Dim pRoleCode As SqlParameter = New SqlParameter("@TRF_ROLE", SqlDbType.VarChar, 6)
            If nRoleCode = "" Then
                pRoleCode.Value = DBNull.Value
            Else
                pRoleCode.Value = nRoleCode
            End If
            arParams(21) = pRoleCode
            Dim paramRetVal As New SqlParameter("@ROWID", SqlDbType.Int)
            paramRetVal.Direction = ParameterDirection.Output
            arParams(22) = paramRetVal
            Dim pContactList As SqlParameter = New SqlParameter("@CONTACT_IDS", SqlDbType.VarChar, 2000)
            If nClientCodeString = "" Then
                pContactList.Value = DBNull.Value
            Else
                pContactList.Value = MiscFN.RemoveDuplicatesFromString(nClientCodeString, ",")
            End If
            arParams(23) = pContactList
            Dim pTaskStatus As SqlParameter = New SqlParameter("@TASK_STATUS", SqlDbType.VarChar, 1)
            If nTaskStatus = "" Then
                pTaskStatus.Value = DBNull.Value
            Else
                pTaskStatus.Value = nTaskStatus
            End If
            arParams(24) = pTaskStatus
            Dim paramTask_SeqNum As New SqlParameter("@SEQ_NBR", SqlDbType.Int)
            paramTask_SeqNum.Value = nSeqNbr
            arParams(25) = paramTask_SeqNum
            Dim SqlParameterGridOrder As New SqlParameter("@GRID_ORDER", SqlDbType.SmallInt)
            If GridOrder.GetValueOrDefault(-1) >= 0 Then
                SqlParameterGridOrder.Value = GridOrder.Value
            Else
                SqlParameterGridOrder.Value = DBNull.Value
            End If
            arParams(26) = SqlParameterGridOrder

            Dim paramUSERCODE As New SqlParameter("@user_id", SqlDbType.Text)
            paramUSERCODE.Value = HttpContext.Current.Session("UserCode")
            arParams(27) = paramUSERCODE

            Dim i As Integer = -1
            Try
                i = oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_Add_Task_CopyFrom", arParams)
                Return paramRetVal.Value
            Catch ex As Exception
                Return ex.Message.ToString
            End Try
        End If
    End Function
    Public Function DeleteTask(ByVal Task_JobNum As Integer, ByVal Task_JobCompNum As Integer, ByVal Task_SeqNum As Integer) As String
        Dim arParams(3) As SqlParameter
        Dim paramTask_JobNum As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
        paramTask_JobNum.Value = Task_JobNum
        arParams(0) = paramTask_JobNum
        Dim paramTask_JobCompNum As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
        paramTask_JobCompNum.Value = Task_JobCompNum
        arParams(1) = paramTask_JobCompNum
        Dim paramTask_SeqNum As New SqlParameter("@TASK_SEQ_NBR", SqlDbType.SmallInt)
        paramTask_SeqNum.Value = Task_SeqNum
        arParams(2) = paramTask_SeqNum
        Try
            oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "advsp_project_schedule_delete_task", arParams)
        Catch ex As Exception
        End Try
    End Function
    Public Function MoveTask(ByVal Task_JobNum As Integer, ByVal Task_JobCompNum As Integer, ByVal Task_SeqNum As Integer, ByVal MoveUp As Boolean) As String
        Dim arParams(4) As SqlParameter
        Dim paramTask_JobNum As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
        paramTask_JobNum.Value = Task_JobNum
        arParams(0) = paramTask_JobNum
        Dim paramTask_JobCompNum As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
        paramTask_JobCompNum.Value = Task_JobCompNum
        arParams(1) = paramTask_JobCompNum
        Dim paramTask_SeqNum As New SqlParameter("@SEQ_NBR", SqlDbType.SmallInt)
        paramTask_SeqNum.Value = Task_SeqNum
        arParams(2) = paramTask_SeqNum
        Dim paramMoveUp As New SqlParameter("@MOVE_UP", SqlDbType.SmallInt)
        If MoveUp = True Then
            paramMoveUp.Value = 1
        Else
            paramMoveUp.Value = 0
        End If
        arParams(3) = paramMoveUp
        Try
            oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_MoveTask_UpDown", arParams)
            Return ""
        Catch ex As Exception
            Return ex.Message.ToString
        End Try
    End Function
    Public Function DragTask(ByVal Task_JobNum As Integer, ByVal Task_JobCompNum As Integer, ByVal Target_SeqNum As Integer, ByVal Drag_SeqNum As Integer, ByVal IncludePhase As Boolean, ByVal MoveUp As Boolean)
        Dim arParams(6) As SqlParameter
        Dim paramTask_JobNum As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
        paramTask_JobNum.Value = Task_JobNum
        arParams(0) = paramTask_JobNum
        Dim paramTask_JobCompNum As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
        paramTask_JobCompNum.Value = Task_JobCompNum
        arParams(1) = paramTask_JobCompNum
        Dim paramTarget_SeqNum As New SqlParameter("@TARGET_SEQ_NBR", SqlDbType.SmallInt)
        paramTarget_SeqNum.Value = Target_SeqNum
        arParams(2) = paramTarget_SeqNum
        Dim paramDrag_SeqNum As New SqlParameter("@DRAG_SEQ_NBR", SqlDbType.SmallInt)
        paramDrag_SeqNum.Value = Drag_SeqNum
        arParams(3) = paramDrag_SeqNum
        Dim paramIncludePhase As New SqlParameter("@INCLUDE_PHASE", SqlDbType.SmallInt)
        If IncludePhase = True Then
            paramIncludePhase.Value = 1
        Else
            paramIncludePhase.Value = 0
        End If
        arParams(4) = paramIncludePhase
        Dim paramMoveUp As New SqlParameter("@MOVE_UP", SqlDbType.SmallInt)
        If MoveUp = True Then
            paramMoveUp.Value = 1
        Else
            paramMoveUp.Value = 0
        End If
        arParams(5) = paramMoveUp
        Try
            oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_DragTask", arParams)
            Return ""
        Catch ex As Exception
            Return ex.Message.ToString
        End Try
    End Function
    Public Function SaveTrafficDetComment(ByVal Task_JobNum As Integer, ByVal Task_JobCompNum As Integer, ByVal Task_SeqNum As Integer, ByVal Emp_Code As String, ByVal Create_User As String, ByVal sComment As String)
        Dim arParams(8) As SqlParameter
        Dim paramTask_JobNum As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
        paramTask_JobNum.Value = Task_JobNum
        arParams(0) = paramTask_JobNum
        Dim paramTask_JobCompNum As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
        paramTask_JobCompNum.Value = Task_JobCompNum
        arParams(1) = paramTask_JobCompNum
        Dim paramTask_SeqNum As New SqlParameter("@SEQ", SqlDbType.SmallInt)
        paramTask_SeqNum.Value = Task_SeqNum
        arParams(2) = paramTask_SeqNum
        Dim paramTask_EMP_CODE As New SqlParameter("@EMP_CODE", SqlDbType.VarChar)
        paramTask_EMP_CODE.Value = Emp_Code
        arParams(3) = paramTask_EMP_CODE
        Dim paramTask_Create_User As New SqlParameter("@Create_User", SqlDbType.VarChar)
        paramTask_Create_User.Value = Create_User
        arParams(4) = paramTask_Create_User
        Dim paramTask_Create_Date As New SqlParameter("@Create_Date", SqlDbType.DateTime)
        paramTask_Create_Date.Value = Now
        arParams(5) = paramTask_Create_Date
        Dim paramTask_Create_Time As New SqlParameter("@Create_Time", SqlDbType.DateTime)
        paramTask_Create_Time.Value = Now
        arParams(6) = paramTask_Create_Time
        Dim paramTask_Comment As New SqlParameter("@COMMENT", SqlDbType.Text)
        paramTask_Comment.Value = sComment
        arParams(7) = paramTask_Comment
        Dim z As Integer = 0
        Try
            oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_SaveDetComments", arParams)
        Catch ex As Exception
            z = 1
        End Try
    End Function
    Public Function SaveTaskDetails(ByVal Task_JobNum As Integer, ByVal Task_JobCompNum As Integer, ByVal Task_SeqNum As Integer,
                                    ByVal nTaskFnCode As String, ByVal nEstFunc As String, ByVal nTaskDesc As String, ByVal nStartDate As String,
                                    ByVal nRevisedDate As String, ByVal nDueDateLock As Boolean, ByVal nJobCompletedDate As String,
                                    ByVal nJobOrder As Integer, ByVal nJobDays As Integer, ByVal nFuncCmmt As String,
                                    ByVal nDueDateCmmt As String, ByVal nRevDateCmmt As String, ByVal nJobHours As Decimal, ByVal nDueTime As String,
                                    ByVal nTaskStatus As String, ByVal nMilestone As Boolean, ByVal nPhaseID As Integer,
                                    ByVal nEmpCodeString As String, ByVal nClientContactString As String) As String
        Dim IsUncompleting As Boolean = False
        Dim arParams(20) As SqlParameter
        Dim paramTask_JobNum As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
        paramTask_JobNum.Value = Task_JobNum
        arParams(0) = paramTask_JobNum
        Dim paramTask_JobCompNum As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
        paramTask_JobCompNum.Value = Task_JobCompNum
        arParams(1) = paramTask_JobCompNum
        Dim paramTask_SeqNum As New SqlParameter("@SEQ_NBR", SqlDbType.SmallInt)
        paramTask_SeqNum.Value = Task_SeqNum
        arParams(2) = paramTask_SeqNum
        Dim pTaskFnCode As SqlParameter = New SqlParameter("@FNC_CODE", SqlDbType.VarChar, 10)
        If nTaskFnCode = "" Then
            pTaskFnCode.Value = DBNull.Value
        Else
            pTaskFnCode.Value = nTaskFnCode
        End If
        arParams(3) = pTaskFnCode
        Dim pEstFunc As SqlParameter = New SqlParameter("@FNC_EST", SqlDbType.VarChar, 6)
        If nEstFunc = "" Or nEstFunc = "[None]" Then
            pEstFunc.Value = DBNull.Value
        Else
            pEstFunc.Value = nEstFunc
        End If
        arParams(4) = pEstFunc
        Dim pTaskDesc As SqlParameter = New SqlParameter("@TASK_DESCRIPTION", SqlDbType.VarChar, 40)
        If nTaskDesc = "" Then
            pTaskDesc.Value = DBNull.Value
        Else
            pTaskDesc.Value = nTaskDesc
        End If
        arParams(5) = pTaskDesc
        Dim pStartDate As SqlParameter = New SqlParameter("@TASK_START_DATE", SqlDbType.SmallDateTime)
        If wvIsDate(nStartDate) = False Then
            pStartDate.Value = DBNull.Value
        Else
            pStartDate.Value = wvCDate(nStartDate)
        End If
        arParams(6) = pStartDate
        Dim pRevisedDate As SqlParameter = New SqlParameter("@JOB_REVISED_DATE", SqlDbType.SmallDateTime)
        If wvIsDate(nRevisedDate) = False Then
            pRevisedDate.Value = DBNull.Value
        Else
            pRevisedDate.Value = wvCDate(nRevisedDate)
        End If
        arParams(7) = pRevisedDate
        Dim pDueDateLock As SqlParameter = New SqlParameter("@DUE_DATE_LOCK", SqlDbType.SmallInt)
        If nDueDateLock = False Then
            pDueDateLock.Value = DBNull.Value
        Else
            pDueDateLock.Value = 1
        End If
        arParams(8) = pDueDateLock
        Dim pJobCompletedDate As SqlParameter = New SqlParameter("@JOB_COMPLETED_DATE", SqlDbType.SmallDateTime)
        If wvIsDate(nJobCompletedDate) = False Then
            pJobCompletedDate.Value = DBNull.Value
            IsUncompleting = True
        Else
            pJobCompletedDate.Value = wvCDate(nJobCompletedDate)
        End If
        arParams(9) = pJobCompletedDate
        Dim pJobOrder As SqlParameter = New SqlParameter("@JOB_ORDER", SqlDbType.SmallInt)
        If nJobOrder = 0 Then
            pJobOrder.Value = DBNull.Value
        Else
            pJobOrder.Value = nJobOrder
        End If
        arParams(10) = pJobOrder
        Dim pJobDays As SqlParameter = New SqlParameter("@JOB_DAYS", SqlDbType.SmallInt)
        If nJobDays = 0 Then
            pJobDays.Value = DBNull.Value
        Else
            pJobDays.Value = nJobDays
        End If
        arParams(11) = pJobDays
        Dim pFuncCmmt As SqlParameter = New SqlParameter("@FNC_COMMENTS", SqlDbType.Text)
        If nFuncCmmt = "" Then
            pFuncCmmt.Value = DBNull.Value
        Else
            pFuncCmmt.Value = nFuncCmmt
        End If
        arParams(12) = pFuncCmmt
        Dim pDueDateCmmt As SqlParameter = New SqlParameter("@DUE_DATE_COMMENTS", SqlDbType.Text)
        If nDueDateCmmt = "" Then
            pDueDateCmmt.Value = DBNull.Value
        Else
            pDueDateCmmt.Value = nDueDateCmmt
        End If
        arParams(13) = pDueDateCmmt
        Dim pRevDateCmmt As SqlParameter = New SqlParameter("@REV_DATE_COMMENTS", SqlDbType.Text)
        If nRevDateCmmt = "" Then
            pRevDateCmmt.Value = DBNull.Value
        Else
            pRevDateCmmt.Value = nRevDateCmmt
        End If
        arParams(14) = pRevDateCmmt
        Dim pJobHours As SqlParameter = New SqlParameter("@JOB_HRS", SqlDbType.Decimal)
        If nJobHours = 0 Then
            pJobHours.Value = DBNull.Value
        Else
            pJobHours.Value = nJobHours
        End If
        arParams(15) = pJobHours
        Dim pDueTime As SqlParameter = New SqlParameter("@DUE_TIME", SqlDbType.VarChar, 10)
        If nDueTime = "" Then
            pDueTime.Value = DBNull.Value
        Else
            pDueTime.Value = nDueTime
        End If
        arParams(16) = pDueTime
        Dim pTaskStatus As SqlParameter = New SqlParameter("@TASK_STATUS", SqlDbType.VarChar, 1)
        If nTaskStatus = "" Then
            pTaskStatus.Value = DBNull.Value
        Else
            pTaskStatus.Value = nTaskStatus
        End If
        arParams(17) = pTaskStatus
        Dim pMilestone As SqlParameter = New SqlParameter("@MILESTONE", SqlDbType.SmallInt)
        If nMilestone = False Then
            pMilestone.Value = DBNull.Value
        Else
            pMilestone.Value = 1
        End If
        arParams(18) = pMilestone
        Dim pPhaseID As SqlParameter = New SqlParameter("@TRAFFIC_PHASE_ID", SqlDbType.Int)
        If nPhaseID = 0 Then
            pPhaseID.Value = DBNull.Value
        Else
            pPhaseID.Value = nPhaseID
        End If
        arParams(19) = pPhaseID
        Dim z As Integer = 0
        Try
            oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_SaveTask_Details", arParams)
        Catch ex As Exception
            z = 1
        End Try
        Try

            If z = 0 AndAlso IsUncompleting = True Then

                Using DbContext = New AdvantageFramework.Database.DbContext(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"))

                    Dim TaskWorkItem As AdvantageFramework.Database.Entities.Alert = Nothing

                    TaskWorkItem = AdvantageFramework.Database.Procedures.Alert.LoadTaskWorkItem(DbContext, Task_JobNum, Task_JobCompNum, Task_SeqNum)

                    If TaskWorkItem IsNot Nothing Then

                        TaskWorkItem.AssignmentCompleted = False

                        AdvantageFramework.Database.Procedures.Alert.Update(DbContext, TaskWorkItem)

                    End If

                End Using

            End If

        Catch ex As Exception
        End Try

        Try
            Me.UpdateTaskEmployeeListFromString(Task_JobNum, Task_JobCompNum, Task_SeqNum, nEmpCodeString)
        Catch ex As Exception
            z = 2
        End Try
        Try
            Me.UpdateTaskContactListFromString(Task_JobNum, Task_JobCompNum, Task_SeqNum, nClientContactString)
        Catch ex As Exception
            z = 4
        End Try
        Select Case z
            Case 0
                Return ""
            Case 1
                Return "Error saving"
            Case 2
                Return "Error saving employees"
            Case 3
                Return "Error saving task and employees"
            Case 4
                Return "Error saving client contacts"
        End Select
    End Function
    Public Function SaveTaskDetailsSingleView(ByVal Task_JobNum As Integer, ByVal Task_JobCompNum As Integer, ByVal Task_SeqNum As Integer,
                                                ByVal nTaskFnCode As String, ByVal nEstFunc As String, ByVal nTaskDesc As String, ByVal nStartDate As String,
                                                ByVal nRevisedDate As String, ByVal nDueDateLock As Boolean, ByVal nJobCompletedDate As String,
                                                ByVal nJobOrder As Integer, ByVal nJobDays As Integer, ByVal nFuncCmmt As String,
                                                ByVal nDueDateCmmt As String, ByVal nRevDateCmmt As String, ByVal nJobHours As Decimal, ByVal nDueTime As String,
                                                ByVal nTaskStatus As String, ByVal nMilestone As Boolean, ByVal nPhaseID As Integer,
                                                ByVal nEmpCodeString As String, ByVal nClientContactString As String, ByVal nOriginalDueDate As String) As String

        Dim IsUncompleting As Boolean = False

        Dim arParams(21) As SqlParameter
        Dim paramTask_JobNum As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
        paramTask_JobNum.Value = Task_JobNum
        arParams(0) = paramTask_JobNum
        Dim paramTask_JobCompNum As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
        paramTask_JobCompNum.Value = Task_JobCompNum
        arParams(1) = paramTask_JobCompNum
        Dim paramTask_SeqNum As New SqlParameter("@SEQ_NBR", SqlDbType.SmallInt)
        paramTask_SeqNum.Value = Task_SeqNum
        arParams(2) = paramTask_SeqNum
        Dim pTaskFnCode As SqlParameter = New SqlParameter("@FNC_CODE", SqlDbType.VarChar, 10)
        If nTaskFnCode = "" Then
            pTaskFnCode.Value = DBNull.Value
        Else
            pTaskFnCode.Value = nTaskFnCode
        End If
        arParams(3) = pTaskFnCode
        Dim pEstFunc As SqlParameter = New SqlParameter("@FNC_EST", SqlDbType.VarChar, 6)
        If nEstFunc = "" Or nEstFunc = "[None]" Then
            pEstFunc.Value = DBNull.Value
        Else
            pEstFunc.Value = nEstFunc
        End If
        arParams(4) = pEstFunc
        Dim pTaskDesc As SqlParameter = New SqlParameter("@TASK_DESCRIPTION", SqlDbType.VarChar, 40)
        If nTaskDesc = "" Then
            pTaskDesc.Value = DBNull.Value
        Else
            pTaskDesc.Value = nTaskDesc
        End If
        arParams(5) = pTaskDesc
        Dim pStartDate As SqlParameter = New SqlParameter("@TASK_START_DATE", SqlDbType.SmallDateTime)
        If wvIsDate(nStartDate) = False Then
            pStartDate.Value = DBNull.Value
        Else
            pStartDate.Value = wvCDate(nStartDate)
        End If
        arParams(6) = pStartDate
        Dim pRevisedDate As SqlParameter = New SqlParameter("@JOB_REVISED_DATE", SqlDbType.SmallDateTime)
        If wvIsDate(nRevisedDate) = False Then
            pRevisedDate.Value = DBNull.Value
        Else
            pRevisedDate.Value = wvCDate(nRevisedDate)
        End If
        arParams(7) = pRevisedDate
        Dim pDueDateLock As SqlParameter = New SqlParameter("@DUE_DATE_LOCK", SqlDbType.SmallInt)
        If nDueDateLock = False Then
            pDueDateLock.Value = DBNull.Value
        Else
            pDueDateLock.Value = 1
        End If
        arParams(8) = pDueDateLock
        Dim pJobCompletedDate As SqlParameter = New SqlParameter("@JOB_COMPLETED_DATE", SqlDbType.SmallDateTime)
        If wvIsDate(nJobCompletedDate) = False Then
            pJobCompletedDate.Value = DBNull.Value
            IsUncompleting = True
        Else
            pJobCompletedDate.Value = wvCDate(nJobCompletedDate)
        End If
        arParams(9) = pJobCompletedDate
        Dim pJobOrder As SqlParameter = New SqlParameter("@JOB_ORDER", SqlDbType.SmallInt)
        If nJobOrder = 0 Then
            pJobOrder.Value = DBNull.Value
        Else
            pJobOrder.Value = nJobOrder
        End If
        arParams(10) = pJobOrder
        Dim pJobDays As SqlParameter = New SqlParameter("@JOB_DAYS", SqlDbType.SmallInt)
        If nJobDays = 0 Then
            pJobDays.Value = DBNull.Value
        Else
            pJobDays.Value = nJobDays
        End If
        arParams(11) = pJobDays
        Dim pFuncCmmt As SqlParameter = New SqlParameter("@FNC_COMMENTS", SqlDbType.Text)
        If nFuncCmmt = "" Then
            pFuncCmmt.Value = DBNull.Value
        Else
            pFuncCmmt.Value = nFuncCmmt
        End If
        arParams(12) = pFuncCmmt
        Dim pDueDateCmmt As SqlParameter = New SqlParameter("@DUE_DATE_COMMENTS", SqlDbType.Text)
        If nDueDateCmmt = "" Then
            pDueDateCmmt.Value = DBNull.Value
        Else
            pDueDateCmmt.Value = nDueDateCmmt
        End If
        arParams(13) = pDueDateCmmt
        Dim pRevDateCmmt As SqlParameter = New SqlParameter("@REV_DATE_COMMENTS", SqlDbType.Text)
        If nRevDateCmmt = "" Then
            pRevDateCmmt.Value = DBNull.Value
        Else
            pRevDateCmmt.Value = nRevDateCmmt
        End If
        arParams(14) = pRevDateCmmt
        Dim pJobHours As SqlParameter = New SqlParameter("@JOB_HRS", SqlDbType.Decimal)
        If nJobHours = 0 Then
            pJobHours.Value = DBNull.Value
        Else
            pJobHours.Value = nJobHours
        End If
        arParams(15) = pJobHours
        Dim pDueTime As SqlParameter = New SqlParameter("@DUE_TIME", SqlDbType.VarChar, 10)
        If nDueTime = "" Then
            pDueTime.Value = DBNull.Value
        Else
            pDueTime.Value = nDueTime
        End If
        arParams(16) = pDueTime
        Dim pTaskStatus As SqlParameter = New SqlParameter("@TASK_STATUS", SqlDbType.VarChar, 1)
        If nTaskStatus = "" Then
            pTaskStatus.Value = DBNull.Value
        Else
            pTaskStatus.Value = nTaskStatus
        End If
        arParams(17) = pTaskStatus
        Dim pMilestone As SqlParameter = New SqlParameter("@MILESTONE", SqlDbType.SmallInt)
        If nMilestone = False Then
            pMilestone.Value = DBNull.Value
        Else
            pMilestone.Value = 1
        End If
        arParams(18) = pMilestone
        Dim pPhaseID As SqlParameter = New SqlParameter("@TRAFFIC_PHASE_ID", SqlDbType.Int)
        If nPhaseID = 0 Then
            pPhaseID.Value = DBNull.Value
        Else
            pPhaseID.Value = nPhaseID
        End If
        arParams(19) = pPhaseID
        Dim pOriginalDueDate As SqlParameter = New SqlParameter("@ORIGINAL_DUE_DATE", SqlDbType.SmallDateTime)
        If wvIsDate(nOriginalDueDate) = False Then
            pOriginalDueDate.Value = DBNull.Value
        Else
            pOriginalDueDate.Value = wvCDate(nOriginalDueDate)
        End If
        arParams(20) = pOriginalDueDate

        Dim z As Integer = 0

        Try
            oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_SaveTask_Details_SingleView", arParams)
        Catch ex As Exception
            z = 1
        End Try
        Try

            If z = 0 AndAlso IsUncompleting = True Then

                Using DbContext = New AdvantageFramework.Database.DbContext(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"))

                    Dim TaskWorkItem As AdvantageFramework.Database.Entities.Alert = Nothing

                    TaskWorkItem = AdvantageFramework.Database.Procedures.Alert.LoadTaskWorkItem(DbContext, Task_JobNum, Task_JobCompNum, Task_SeqNum)

                    If TaskWorkItem IsNot Nothing Then

                        TaskWorkItem.AssignmentCompleted = False

                        AdvantageFramework.Database.Procedures.Alert.Update(DbContext, TaskWorkItem)

                    End If

                End Using

            End If

        Catch ex As Exception
        End Try

        Try
            Me.UpdateTaskEmployeeListFromString(Task_JobNum, Task_JobCompNum, Task_SeqNum, nEmpCodeString)
        Catch ex As Exception
            z = 2
        End Try

        Try
            Me.UpdateTaskContactListFromString(Task_JobNum, Task_JobCompNum, Task_SeqNum, nClientContactString)
        Catch ex As Exception
            z = 4
        End Try

        Select Case z
            Case 0
                Return ""
            Case 1
                Return "Error saving"
            Case 2
                Return "Error saving employees"
            Case 3
                Return "Error saving task and employees"
            Case 4
                Return "Error saving client contacts"
        End Select
    End Function
    Public Function UpdateTaskAlertsDueDate(ByVal JobNumber As Integer, ByVal JobComponentNbr As Integer,
    Optional ByVal SeqNbr As Integer = -1, Optional ByVal ErrorMessage As String = "") As Boolean
        Try
            Using MyConn As New SqlConnection(Me.mConnString)
                Dim MyCommand As New SqlCommand()
                With MyCommand
                    .CommandType = CommandType.StoredProcedure
                    .CommandText = "usp_wv_Traffic_Schedule_UpdateTaskAlertsDueDate"
                    .Connection = MyConn
                End With
                Dim pJobNumber As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
                pJobNumber.Value = JobNumber
                MyCommand.Parameters.Add(pJobNumber)
                Dim pJobComponentNbr As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
                pJobComponentNbr.Value = JobComponentNbr
                MyCommand.Parameters.Add(pJobComponentNbr)
                Dim pSeqNbr As New SqlParameter("@SEQ_NBR", SqlDbType.SmallInt)
                If SeqNbr > -1 Then
                    pSeqNbr.Value = SeqNbr
                Else
                    pSeqNbr.Value = System.DBNull.Value
                End If
                MyCommand.Parameters.Add(pSeqNbr)
                MyConn.Open()
                MyCommand.ExecuteNonQuery()
            End Using
            ErrorMessage = ""
            Return True
        Catch ex As Exception
            ErrorMessage = AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString())
            Return False
        End Try
    End Function
    Public Function SetNextTaskActive(ByVal JobNumber As Integer, ByVal JobComponentNbr As Integer,
                                      ByVal SeqNbr As Integer, Optional ByVal ErrorMessage As String = "") As DataTable
        Try
            Dim MyDatatable As New DataTable
            Using MyConn As New SqlConnection(Me.mConnString)

                Dim MyCommand As New SqlCommand()

                With MyCommand

                    .CommandType = CommandType.StoredProcedure
                    .CommandText = "usp_wv_Traffic_Schedule_SetNextTaskActive"
                    .Connection = MyConn

                End With

                Dim pJobNumber As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
                pJobNumber.Value = JobNumber
                MyCommand.Parameters.Add(pJobNumber)
                Dim pJobComponentNbr As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
                pJobComponentNbr.Value = JobComponentNbr
                MyCommand.Parameters.Add(pJobComponentNbr)
                Dim pSeqNbr As New SqlParameter("@SEQ_NBR", SqlDbType.SmallInt)
                pSeqNbr.Value = SeqNbr

                MyCommand.Parameters.Add(pSeqNbr)
                MyConn.Open()
                MyDatatable.Load(MyCommand.ExecuteReader)

            End Using

            ErrorMessage = ""
            Return MyDatatable

        Catch ex As Exception

            ErrorMessage = AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString())
            Return Nothing

        End Try
    End Function
    Public Function GetTaskDocuments(ByVal JobNumber As Integer, ByVal JobComponentNbr As Integer, ByVal SeqNbr As Integer, ByVal Filter As String, ByVal History As Short, ByVal PrivateDocs As Integer, ByVal UserCode As String) As DataTable

        'objects
        Dim DataTable As System.Data.DataTable = Nothing
        Dim JobNumberSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
        Dim JobComponentNumberSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
        Dim SequenceNumberSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
        Dim FilterSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
        Dim HistorySqlParameter As System.Data.SqlClient.SqlParameter = Nothing
        Dim PrivateDocsSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
        Dim UserCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing

        Try

            DataTable = New System.Data.DataTable

            Using SqlConnection As New System.Data.SqlClient.SqlConnection(Me.mConnString)

                Dim SqlCommand As New System.Data.SqlClient.SqlCommand()

                With SqlCommand

                    .CommandType = CommandType.StoredProcedure
                    .CommandText = "advsp_traffic_schedule_GetTaskDocuments"
                    .Connection = SqlConnection

                End With

                JobNumberSqlParameter = New System.Data.SqlClient.SqlParameter("@JobNumber", SqlDbType.Int) With {.Value = JobNumber}
                SqlCommand.Parameters.Add(JobNumberSqlParameter)

                JobComponentNumberSqlParameter = New System.Data.SqlClient.SqlParameter("@JobComponentNumber", SqlDbType.SmallInt) With {.Value = JobComponentNbr}
                SqlCommand.Parameters.Add(JobComponentNumberSqlParameter)

                SequenceNumberSqlParameter = New System.Data.SqlClient.SqlParameter("@SequenceNumber", SqlDbType.SmallInt) With {.Value = SeqNbr}
                SqlCommand.Parameters.Add(SequenceNumberSqlParameter)

                FilterSqlParameter = New System.Data.SqlClient.SqlParameter("@Filter", SqlDbType.VarChar) With {.Value = Filter}
                SqlCommand.Parameters.Add(FilterSqlParameter)

                HistorySqlParameter = New System.Data.SqlClient.SqlParameter("@History", SqlDbType.SmallInt) With {.Value = History}
                SqlCommand.Parameters.Add(HistorySqlParameter)

                PrivateDocsSqlParameter = New System.Data.SqlClient.SqlParameter("@Private", SqlDbType.Int) With {.Value = PrivateDocs}
                SqlCommand.Parameters.Add(PrivateDocsSqlParameter)

                UserCodeSqlParameter = New System.Data.SqlClient.SqlParameter("@UserCode", SqlDbType.VarChar) With {.Value = UserCode}
                SqlCommand.Parameters.Add(UserCodeSqlParameter)

                SqlConnection.Open()
                DataTable.Load(SqlCommand.ExecuteReader)

            End Using

            Return DataTable

        Catch ex As Exception

            Return Nothing

        End Try

    End Function

#End Region
#Region " Task Employees "
    Public Function GetTaskEmpListString(ByVal Task_JobNum As Integer, ByVal Task_JobCompNum As Integer, ByVal Task_SeqNum As Integer) As String
        Try
            Dim str As String
            Dim arParams(3) As SqlParameter
            Dim paramTask_JobNum As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            paramTask_JobNum.Value = Task_JobNum
            arParams(0) = paramTask_JobNum
            Dim paramTask_JobCompNum As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.Int)
            paramTask_JobCompNum.Value = Task_JobCompNum
            arParams(1) = paramTask_JobCompNum
            Dim paramTask_SeqNum As New SqlParameter("@SEQ", SqlDbType.SmallInt)
            paramTask_SeqNum.Value = Task_SeqNum
            arParams(2) = paramTask_SeqNum
            Dim dr As SqlDataReader
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_GetEmpList", arParams)
            If dr.HasRows Then
                Do While dr.Read
                    Try
                        str &= dr("EMP_CODE").ToString() & ", "
                    Catch ex As Exception
                    End Try
                Loop
                dr.Close()
                If str <> "" Then
                    Return MiscFN.RemoveTrailingDelimiter(str, ",")
                End If
            Else
                dr.Close()
                Return ""
            End If
        Catch ex As Exception
        End Try
    End Function
    Public Function GetTaskEmpListStringByRole(ByVal Task_JobNum As Integer, ByVal Task_JobCompNum As Integer, ByVal Task_SeqNum As Integer, ByVal Roles As String) As String
        Try
            Dim str As String
            Dim arParams(4) As SqlParameter
            Dim paramTask_JobNum As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            paramTask_JobNum.Value = Task_JobNum
            arParams(0) = paramTask_JobNum
            Dim paramTask_JobCompNum As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.Int)
            paramTask_JobCompNum.Value = Task_JobCompNum
            arParams(1) = paramTask_JobCompNum
            Dim paramTask_SeqNum As New SqlParameter("@SEQ", SqlDbType.SmallInt)
            paramTask_SeqNum.Value = Task_SeqNum
            arParams(2) = paramTask_SeqNum
            Dim parameterRlCodes As New SqlParameter("@Roles", SqlDbType.VarChar, 4000)
            If Roles = "" Then
                parameterRlCodes.Value = ""
            ElseIf Roles.EndsWith(",") Then
                parameterRlCodes.Value = Roles.Substring(0, Roles.Length - 1)
            Else
                parameterRlCodes.Value = Roles
            End If
            arParams(3) = parameterRlCodes
            Dim dr As SqlDataReader
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_GetEmpList_ByRole", arParams)
            If dr.HasRows Then
                Do While dr.Read
                    Try
                        str &= dr("EMP_CODE").ToString() & ", "
                    Catch ex As Exception
                    End Try
                Loop
                If str <> "" Then
                    Return MiscFN.RemoveTrailingDelimiter(str, ",")
                End If
            Else
                Return ""
            End If
        Catch ex As Exception
        End Try
    End Function
    Public Function GetTaskEmpListStringName(ByVal Task_JobNum As Integer, ByVal Task_JobCompNum As Integer, ByVal Task_SeqNum As Integer) As String
        Try
            Dim str As String
            Dim arParams(3) As SqlParameter
            Dim paramTask_JobNum As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            paramTask_JobNum.Value = Task_JobNum
            arParams(0) = paramTask_JobNum
            Dim paramTask_JobCompNum As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.Int)
            paramTask_JobCompNum.Value = Task_JobCompNum
            arParams(1) = paramTask_JobCompNum
            Dim paramTask_SeqNum As New SqlParameter("@SEQ", SqlDbType.SmallInt)
            paramTask_SeqNum.Value = Task_SeqNum
            arParams(2) = paramTask_SeqNum
            Dim dr As SqlDataReader
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_GetEmpList", arParams)
            If dr.HasRows Then
                Do While dr.Read
                    Try
                        str &= dr("EMP_NAME").ToString() & ","
                    Catch ex As Exception
                    End Try
                Loop
                If str <> "" Then
                    Return MiscFN.RemoveTrailingDelimiter(str, ",")
                End If
            Else
                Return ""
            End If
        Catch ex As Exception
        End Try
    End Function
    Public Function GetTaskTempListByID(ByVal ID As Integer, ByRef dCompletedDate As DateTime, ByRef sCompletedComment As String, ByRef iPercentCompleted As Integer) As Boolean
        Try
            Dim arParams(1) As SqlParameter
            Dim paramTask_ID As New SqlParameter("@ID", SqlDbType.Int)
            paramTask_ID.Value = ID
            arParams(0) = paramTask_ID
            Dim ds As New DataSet
            Dim dt As New DataTable
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_GetEmpListByID", arParams)
            dt = ds.Tables(0)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt.Rows(0)("TEMP_COMP_DATE")) = False Then
                    dCompletedDate = dt.Rows(0)("TEMP_COMP_DATE")
                Else
                    dCompletedDate = Date.MinValue
                End If
                If IsDBNull(dt.Rows(0)("COMPLETED_COMMENTS")) = False Then
                    sCompletedComment = dt.Rows(0)("COMPLETED_COMMENTS")
                Else
                    sCompletedComment = ""
                End If
                If IsDBNull(dt.Rows(0)("PERCENT_COMPLETE")) = False Then
                    iPercentCompleted = dt.Rows(0)("PERCENT_COMPLETE")
                Else
                    iPercentCompleted = 0
                End If
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function GetScheduleHoursPosted(ByVal JobNum As Integer, ByVal JobCompNum As Integer, ByVal FNCCode As String, ByVal EmpCode As String) As DataTable
        '[usp_wv_Traffic_Schedule_GetHoursPosted]
        Try
            Dim arParams(4) As SqlParameter
            Dim paramJobNum As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            paramJobNum.Value = JobNum
            arParams(0) = paramJobNum
            Dim paramJobCompNum As New SqlParameter("@JOB_COMP_NUMBER", SqlDbType.Int)
            paramJobCompNum.Value = JobCompNum
            arParams(1) = paramJobCompNum
            Dim paramFNCCode As New SqlParameter("@FNC_CODE", SqlDbType.VarChar)
            paramFNCCode.Value = FNCCode
            arParams(2) = paramFNCCode
            Dim paramEMPCode As New SqlParameter("@EMP_CODE", SqlDbType.VarChar)
            paramEMPCode.Value = EmpCode
            arParams(3) = paramEMPCode
            Dim dt As New DataTable
            dt = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_GetHoursPosted", "HOURS", arParams)
            Return dt
        Catch ex As Exception
        End Try
    End Function
    Public Function GetScheduleQuotedHours(ByVal JobNum As Integer, ByVal JobCompNum As Integer, ByVal FNCCode As String, ByVal EmpCode As String) As DataTable
        Try
            Dim arParams(4) As SqlParameter
            Dim paramJobNum As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            paramJobNum.Value = JobNum
            arParams(0) = paramJobNum
            Dim paramJobCompNum As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.Int)
            paramJobCompNum.Value = JobCompNum
            arParams(1) = paramJobCompNum
            Dim paramFNCCode As New SqlParameter("@FNC_CODE", SqlDbType.VarChar)
            paramFNCCode.Value = FNCCode
            arParams(2) = paramFNCCode
            Dim paramEMPCode As New SqlParameter("@EMPCODE", SqlDbType.VarChar)
            paramEMPCode.Value = EmpCode
            arParams(3) = paramEMPCode
            Dim dt As New DataTable
            dt = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_GetQuotedHours", "HOURS", arParams)
            Return dt
        Catch ex As Exception
        End Try
    End Function
    Public Function GetTaskEmpList(ByVal Task_JobNum As Integer, ByVal Task_JobCompNum As Integer, ByVal Task_SeqNum As Integer) As DataTable
        Try
            Dim arParams(3) As SqlParameter
            Dim paramTask_JobNum As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            paramTask_JobNum.Value = Task_JobNum
            arParams(0) = paramTask_JobNum
            Dim paramTask_JobCompNum As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
            paramTask_JobCompNum.Value = Task_JobCompNum
            arParams(1) = paramTask_JobCompNum
            Dim paramTask_SeqNum As New SqlParameter("@SEQ", SqlDbType.SmallInt)
            paramTask_SeqNum.Value = Task_SeqNum
            arParams(2) = paramTask_SeqNum
            Dim dt As New DataTable
            dt = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_GetEmpList", "TaskEmps", arParams)
            Return dt
        Catch ex As Exception
        End Try
    End Function
    Public Function GetAvailableEmpList(ByVal Task_JobNum As Integer, ByVal Task_JobCompNum As Integer, ByVal Task_SeqNum As Integer, ByVal FilterByTrafficCode As Boolean, ByVal Task_TrafficCode As String, ByVal UserCode As String) As DataTable
        Try
            Dim arParams(4) As SqlParameter
            Dim paramTask_JobNum As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            paramTask_JobNum.Value = Task_JobNum
            arParams(0) = paramTask_JobNum
            Dim paramTask_JobCompNum As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.Int)
            paramTask_JobCompNum.Value = Task_JobCompNum
            arParams(1) = paramTask_JobCompNum
            Dim paramTask_SeqNum As New SqlParameter("@SEQ", SqlDbType.SmallInt)
            paramTask_SeqNum.Value = Task_SeqNum
            arParams(2) = paramTask_SeqNum
            Dim paramTask_TrafficCode As New SqlParameter("@TRF_CODE", SqlDbType.VarChar, 10)
            If FilterByTrafficCode = True Then
                paramTask_TrafficCode.Value = Task_TrafficCode
            Else
                paramTask_TrafficCode.Value = ""
            End If
            arParams(3) = paramTask_TrafficCode
            Dim paramUserCode As New SqlParameter("@UserCode", SqlDbType.VarChar)
            paramUserCode.Value = UserCode
            arParams(4) = paramUserCode
            Dim dt As New DataTable
            dt = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_GetAvailableEmpList", "AvailEmps", arParams)
            Return dt
        Catch ex As Exception
        End Try
    End Function
    Public Function AddEmployeeToTask(ByVal Task_JobNum As Integer, ByVal Task_JobCompNum As Integer, ByVal Task_SeqNum As Integer, ByVal EmpCode As String, Optional ByVal TrafficRoleCode As String = "", Optional ByVal DaysAllowed As Integer = 0,
    Optional ByVal HoursAllowed As Decimal = 0.0, Optional ByVal StartDate As String = "", Optional ByVal DueDate As String = "") As String
        If Task_JobNum = 0 Or Task_JobCompNum = 0 Or Task_SeqNum = -1 Or EmpCode = "" Then

            Return "Missing key data for adding employee to task."

        Else
            Try

                Dim save As Boolean = False
                Dim RighNow As DateTime = Now

                Using DbContext = New AdvantageFramework.Database.DbContext(mConnString, HttpContext.Current.Session("UserCode"))

                    Try
                        If HoursAllowed = 0.0 Then

                            HoursAllowed = CType(oSQL.ExecuteScalar(mConnString, CommandType.Text, String.Format("SELECT ISNULL(JOB_HRS, 0.0) FROM JOB_TRAFFIC_DET WITH(NOLOCK) WHERE JOB_NUMBER = {0} AND JOB_COMPONENT_NBR = {1} AND SEQ_NBR = {2};",
                                                                                                                 Task_JobNum, Task_JobCompNum, Task_SeqNum)), Decimal)

                        End If
                    Catch ex As Exception

                    End Try

                    Dim JobComponentTaskEmployee As New AdvantageFramework.Database.Entities.JobComponentTaskEmployee

                    JobComponentTaskEmployee.JobNumber = Task_JobNum
                    JobComponentTaskEmployee.JobComponentNumber = Task_JobCompNum
                    JobComponentTaskEmployee.SequenceNumber = Task_SeqNum
                    JobComponentTaskEmployee.EmployeeCode = EmpCode
                    JobComponentTaskEmployee.Hours = HoursAllowed
                    JobComponentTaskEmployee.ReadAlert = 1

                    If AdvantageFramework.Database.Procedures.JobComponentTaskEmployee.Insert(DbContext, JobComponentTaskEmployee) = True Then

                        Dim Comment As AdvantageFramework.Database.Entities.AlertComment = Nothing
                        Dim AlertEntity As AdvantageFramework.Database.Entities.Alert = Nothing

                        AlertEntity = AdvantageFramework.Database.Procedures.Alert.LoadTaskWorkItem(DbContext,
                                                                                                    JobComponentTaskEmployee.JobNumber,
                                                                                                    JobComponentTaskEmployee.JobComponentNumber,
                                                                                                    JobComponentTaskEmployee.SequenceNumber)

                        If AlertEntity IsNot Nothing Then

                            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

                            Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmpCode)

                            If Employee IsNot Nothing Then

                                Comment = New AdvantageFramework.Database.Entities.AlertComment

                                Comment.AlertID = AlertEntity.ID
                                Comment.UserCode = DbContext.UserCode
                                Comment.GeneratedDate = RighNow
                                Comment.Comment = String.Format("{0}", Employee.ToString)
                                Comment.HasEmailBeenSent = False
                                Comment.AssignedEmployeeCode = Employee.Code
                                Comment.CustodyStart = Comment.GeneratedDate
                                Comment.IsSystem = True

                                If AdvantageFramework.Database.Procedures.AlertComment.Insert(DbContext, Comment) = True Then
                                End If

                            End If

                        End If

                    End If

                End Using

                Return ""

            Catch ex As Exception
                Return "Error adding employee to task: " & ex.Message.ToString
            End Try

        End If
    End Function
    Public Function UpdateTrafficScheduleEmployee(ByVal ID As Integer, ByVal CompletedDate As DateTime, ByVal Comments As String, ByVal PercentComplete As Decimal) As Boolean
        Try
            Dim myReturnMessage As Integer = 0
            Dim arParams(4) As SqlParameter
            Dim parmID As New SqlParameter("@ID", SqlDbType.Int)
            parmID.Value = ID
            arParams(0) = parmID
            Dim parmCOMPLETEDDATE As New SqlParameter("@COMPLETEDDATE", SqlDbType.SmallDateTime)
            If Not CompletedDate = Date.MinValue Then
                parmCOMPLETEDDATE.Value = CompletedDate
            Else
                parmCOMPLETEDDATE.Value = DBNull.Value
            End If
            arParams(1) = parmCOMPLETEDDATE
            Dim parmCOMMENTS As New SqlParameter("@COMMENTS", SqlDbType.Text)
            parmCOMMENTS.Value = Comments
            arParams(2) = parmCOMMENTS
            Dim parmPERCENTCOMPLETE As New SqlParameter("@PERCENTCOMPLETE", SqlDbType.Decimal)
            parmPERCENTCOMPLETE.Value = PercentComplete
            arParams(3) = parmPERCENTCOMPLETE
            myReturnMessage = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_UpdateEmpList", arParams)
            If myReturnMessage = 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function UpdateTaskEmployee(ByVal DataKeyValue As Integer, Optional ByVal HoursAllowed As Decimal = 0.0) As String
        If DataKeyValue = 0 Then
            Return "Missing key data for update."
        Else
            Try
                Dim TaskEmp As New JOB_TRAFFIC_DET_EMPS(mConnString)
                If TaskEmp.LoadByPrimaryKey(DataKeyValue) Then
                    With TaskEmp
                        .HOURS_ALLOWED = HoursAllowed
                        .Save()
                    End With
                    Return ""
                Else
                    Return "Can't find record for update."
                End If
            Catch ex As Exception
                Return "Error updating task employee: " & ex.Message.ToString
            End Try
        End If
    End Function
    Public Function UpdateTaskEmployeeHours(ByVal Job As Integer, ByVal Comp As Integer, ByVal Seq As Integer, Optional ByVal HoursAllowed As Decimal = 0.0) As String
        Try
            Dim TaskEmp As New JOB_TRAFFIC_DET_EMPS(mConnString)
            TaskEmp.Where.JOB_NUMBER.Value = Job
            TaskEmp.Where.JOB_COMPONENT_NBR.Value = Comp
            TaskEmp.Where.SEQ_NBR.Value = Seq
            If TaskEmp.Query.Load Then
                Do Until TaskEmp.EOF
                    With TaskEmp
                        .HOURS_ALLOWED = HoursAllowed
                        .Save()
                        .MoveNext()
                    End With
                Loop
                Return ""
            Else
                'Return "Can't find record for update."
            End If
        Catch ex As Exception
            Return "Error updating disbursed hours: " & ex.Message.ToString
        End Try
    End Function
    Public Function RemoveEmployeeFromTask(ByVal DataKeyValue As Integer) As String
        Try

            If DataKeyValue = 0 Then

                Return "Missing datakey for delete."

            Else

                Dim TaskEmp As New JOB_TRAFFIC_DET_EMPS(mConnString)

                If TaskEmp.LoadByPrimaryKey(DataKeyValue) Then

                    With TaskEmp
                        .MarkAsDeleted()
                        .Save()
                    End With

                End If

                Using DbContext = New AdvantageFramework.Database.DbContext(mConnString, HttpContext.Current.Session("UserCode"))

                    Dim JobComponentTaskEmployee As AdvantageFramework.Database.Entities.JobComponentTaskEmployee = Nothing

                    JobComponentTaskEmployee = AdvantageFramework.Database.Procedures.JobComponentTaskEmployee.LoadByID(DbContext, DataKeyValue)

                    If JobComponentTaskEmployee IsNot Nothing Then

                        If AdvantageFramework.Database.Procedures.JobComponentTaskEmployee.Delete(DbContext, JobComponentTaskEmployee) Then

                            Dim AlertEntity As AdvantageFramework.Database.Entities.Alert = Nothing

                            AlertEntity = AdvantageFramework.Database.Procedures.Alert.LoadTaskWorkItem(DbContext,
                                                                                                        JobComponentTaskEmployee.JobNumber,
                                                                                                        JobComponentTaskEmployee.JobComponentNumber,
                                                                                                        JobComponentTaskEmployee.SequenceNumber)

                            If AlertEntity IsNot Nothing Then

                                Dim RightNow As DateTime = Now

                                AdvantageFramework.AlertSystem.UpdateCustodyEnd(DbContext, AlertEntity.ID, Nothing, Nothing, JobComponentTaskEmployee.EmployeeCode, RightNow)

                            End If

                        End If

                    End If

                End Using

            End If

            Return ""

        Catch ex As Exception
            Return "Error deleting employee from task:  " & ex.Message.ToString
        End Try
    End Function
    Public Function SetDaysByDate(ByVal Task_JobNum As Integer, ByVal Task_JobCompNum As Integer, ByVal Task_SeqNum As Integer) As String
        Dim arParams(3) As SqlParameter
        Dim paramTask_JobNum As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
        paramTask_JobNum.Value = Task_JobNum
        arParams(0) = paramTask_JobNum
        Dim paramTask_JobCompNum As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
        paramTask_JobCompNum.Value = Task_JobCompNum
        arParams(1) = paramTask_JobCompNum
        Dim paramTask_SeqNum As New SqlParameter("@SEQ_NBR", SqlDbType.SmallInt)
        paramTask_SeqNum.Value = Task_SeqNum
        arParams(2) = paramTask_SeqNum
        Try
            oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_SaveTaskDaysByDate", arParams)
            Return ""
        Catch ex As Exception
            Return ex.Message.ToString
        End Try
    End Function
    Public Function UpdateTaskEmployeeListFromString(ByVal Task_JobNum As Integer, ByVal Task_JobCompNum As Integer, ByVal Task_SeqNum As Integer, ByVal TheEmpList As String) As DataTable
        Dim arParams(4) As SqlParameter
        Dim paramTask_JobNum As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
        paramTask_JobNum.Value = Task_JobNum
        arParams(0) = paramTask_JobNum
        Dim paramTask_JobCompNum As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.Int)
        paramTask_JobCompNum.Value = Task_JobCompNum
        arParams(1) = paramTask_JobCompNum
        Dim paramTask_SeqNum As New SqlParameter("@SEQ_NBR", SqlDbType.SmallInt)
        paramTask_SeqNum.Value = Task_SeqNum
        arParams(2) = paramTask_SeqNum
        Dim paramTask_EmpList As New SqlParameter("@EMP_LIST", SqlDbType.VarChar, 8000)
        paramTask_EmpList.Value = TheEmpList
        arParams(3) = paramTask_EmpList
        Dim paramTask_UserCode As New SqlParameter("@UserCode", SqlDbType.VarChar)
        paramTask_UserCode.Value = HttpContext.Current.Session("UserCode")
        arParams(4) = paramTask_UserCode
        Try
            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_SaveTask_EmpListString", "DtMessages", arParams)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function GetRolesDT(ByVal ThisTrafficCode As String) As DataTable
        Dim arP(1) As SqlParameter
        Dim pTraffCode As New SqlParameter("@TRF_CODE", SqlDbType.VarChar, 10)
        pTraffCode.Value = ThisTrafficCode
        arP(0) = pTraffCode
        Try
            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_GetTaskRoles", "dtRoles", arP)
        Catch ex As Exception
        End Try
    End Function
    Public Function CheckJobComponentTaskEmployee(ByVal JobNum As Integer, ByVal CompNum As Integer, ByVal SeqNum As Integer, ByVal EmpCode As String) As Boolean
        'objects
        Dim JobComponentTaskEmployee As AdvantageFramework.Database.Entities.JobComponentTaskEmployee = Nothing
        Dim JobComponentTaskEmployeeUpdated As Boolean = False
        Try
            Using DbContext = New AdvantageFramework.Database.DbContext(mConnString, HttpContext.Current.Session("UserCode"))
                JobComponentTaskEmployee = AdvantageFramework.Database.Procedures.JobComponentTaskEmployee.LoadByJobCompSeqEmp(DbContext, JobNum, CompNum, SeqNum, EmpCode)
                If JobComponentTaskEmployee IsNot Nothing Then
                    Return True
                Else
                    Return False
                End If
            End Using
        Catch ex As Exception
            Return False
        End Try
    End Function
#End Region
#Region " Task Predecessors "
    Public Function GetTaskPredListString(ByVal Task_JobNum As Integer, ByVal Task_JobCompNum As Integer, ByVal Task_SeqNum As Integer) As String
        Try
            Dim str As String
            Dim arParams(3) As SqlParameter
            Dim paramTask_JobNum As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            paramTask_JobNum.Value = Task_JobNum
            arParams(0) = paramTask_JobNum
            Dim paramTask_JobCompNum As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.Int)
            paramTask_JobCompNum.Value = Task_JobCompNum
            arParams(1) = paramTask_JobCompNum
            Dim paramTask_SeqNum As New SqlParameter("@SEQ", SqlDbType.SmallInt)
            paramTask_SeqNum.Value = Task_SeqNum
            arParams(2) = paramTask_SeqNum
            Dim dr As SqlDataReader
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_GetPredList", arParams)
            If dr.HasRows Then
                Do While dr.Read
                    Try
                        str &= dr("PREDECESSOR_SEQ_NBR").ToString() & ", "
                    Catch ex As Exception
                    End Try
                Loop
                dr.Close()
                If str <> "" Then
                    Return MiscFN.RemoveTrailingDelimiter(str, ",")
                End If
            Else
                dr.Close()
                Return ""
            End If
        Catch ex As Exception
            Return ex.Message.ToString
        End Try
        'Dim str As String = ""
        'Dim TaskPred As New JOB_TRAFFIC_DET_PREDS(mConnString)
        'With TaskPred
        '    .Where.JOB_NUMBER.Value = Task_JobNum
        '    .Where.JOB_NUMBER.Operator = WhereParameter.Operand.Equal
        '    .Query.AddConjunction(WhereParameter.Conj.AND_)
        '    .Where.JOB_COMPONENT_NBR.Value = Task_JobCompNum
        '    .Where.JOB_COMPONENT_NBR.Operator = WhereParameter.Operand.Equal
        '    .Query.AddConjunction(WhereParameter.Conj.AND_)
        '    .Where.SEQ_NBR.Value = Task_SeqNum
        '    .Where.SEQ_NBR.Operator = WhereParameter.Operand.Equal
        'End With
        'If TaskPred.Query.Load Then
        '    Do Until TaskPred.EOF
        '        str &= TaskPred.PREDECESSOR_SEQ_NBR.ToString()& ","
        '        TaskPred.MoveNext()
        '    Loop
        'End If
        'Return str
    End Function
    Public Function UpdateTaskPredListFromString(ByVal Task_JobNum As Integer, ByVal Task_JobCompNum As Integer, ByVal Task_SeqNum As Integer, ByVal ThePredList As String) As DataTable
        Dim arParams(4) As SqlParameter
        Dim paramTask_JobNum As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
        paramTask_JobNum.Value = Task_JobNum
        arParams(0) = paramTask_JobNum
        Dim paramTask_JobCompNum As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.Int)
        paramTask_JobCompNum.Value = Task_JobCompNum
        arParams(1) = paramTask_JobCompNum
        Dim paramTask_SeqNum As New SqlParameter("@SEQ_NBR", SqlDbType.SmallInt)
        paramTask_SeqNum.Value = Task_SeqNum
        arParams(2) = paramTask_SeqNum
        'clean the list
        'Dim TempList As String
        'If ThePredList.IndexOf(CType(",", Char)) > 0 Then
        '    Dim TempAR() As String
        '    TempAR = ThePredList.Split(CType(",", Char))
        '    For i As Integer = 0 To TempAR.Length - 1
        '        If IsNumeric(TempAR(i)) = True Then
        '            TempList &= CType(TempAR(i), Integer).ToString() & ","
        '        End If
        '    Next
        '    ThePredList = TempList
        'Else
        '    If IsNumeric(ThePredList) = False Then
        '        ThePredList = "0"
        '    End If
        'End If
        Dim paramTask_PredList As New SqlParameter("@PRED_LIST", SqlDbType.VarChar, 2000)
        paramTask_PredList.Value = ThePredList
        arParams(3) = paramTask_PredList
        Try
            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_SaveTask_PredListString", "dt", arParams)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
#End Region
#Region " Task Contacts "
    Public Function GetTaskContactListString(ByVal Task_JobNum As Integer, ByVal Task_JobCompNum As Integer, ByVal Task_SeqNum As Integer) As String
        Try
            Dim str As String
            Dim arParams(3) As SqlParameter
            Dim paramTask_JobNum As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            paramTask_JobNum.Value = Task_JobNum
            arParams(0) = paramTask_JobNum
            Dim paramTask_JobCompNum As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.Int)
            paramTask_JobCompNum.Value = Task_JobCompNum
            arParams(1) = paramTask_JobCompNum
            Dim paramTask_SeqNum As New SqlParameter("@SEQ", SqlDbType.SmallInt)
            paramTask_SeqNum.Value = Task_SeqNum
            arParams(2) = paramTask_SeqNum
            Dim dr As SqlDataReader
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_GetContactList", arParams)
            If dr.HasRows Then
                Do While dr.Read
                    Try
                        str &= dr("CONT_CODE").ToString() & ", "
                    Catch ex As Exception
                    End Try
                Loop
                dr.Close()
                If str <> "" Then
                    Return MiscFN.RemoveTrailingDelimiter(str, ",")
                End If
            Else
                dr.Close()
                Return ""
            End If
        Catch ex As Exception
        End Try
    End Function
    Public Function UpdateTaskPredListFromString(ByVal Task_JobNum As Integer, ByVal Task_JobCompNum As Integer, ByVal Task_SeqNum As Integer) As String
    End Function
    Public Function UpdateTaskContactListFromString(ByVal Task_JobNum As Integer, ByVal Task_JobCompNum As Integer, ByVal Task_SeqNum As Integer, ByVal TheContactIDList As String) As String
        Dim arParams(4) As SqlParameter
        Dim paramTask_JobNum As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
        paramTask_JobNum.Value = Task_JobNum
        arParams(0) = paramTask_JobNum
        Dim paramTask_JobCompNum As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.Int)
        paramTask_JobCompNum.Value = Task_JobCompNum
        arParams(1) = paramTask_JobCompNum
        Dim paramTask_SeqNum As New SqlParameter("@SEQ_NBR", SqlDbType.SmallInt)
        paramTask_SeqNum.Value = Task_SeqNum
        arParams(2) = paramTask_SeqNum
        Dim paramTask_TheContactIDList As New SqlParameter("@CONTACT_IDS", SqlDbType.VarChar, 2000)
        paramTask_TheContactIDList.Value = TheContactIDList
        arParams(3) = paramTask_TheContactIDList
        Try
            oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_SaveTask_ContactListString", arParams)
            Return ""
        Catch ex As Exception
            Return ex.Message.ToString
        End Try
    End Function
    Public Function GetAvailableContactList(ByVal Task_JobNum As Integer, ByVal Task_JobCompNum As Integer, ByVal Task_SeqNum As Integer,
    ByVal Task_Client As String, ByVal Task_Division As String, ByVal Task_Product As String) As DataTable
        Try
            Dim arParams(6) As SqlParameter
            Dim paramTask_JobNum As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            paramTask_JobNum.Value = Task_JobNum
            arParams(0) = paramTask_JobNum
            Dim paramTask_JobCompNum As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.Int)
            paramTask_JobCompNum.Value = Task_JobCompNum
            arParams(1) = paramTask_JobCompNum
            Dim paramTask_SeqNum As New SqlParameter("@SEQ", SqlDbType.SmallInt)
            paramTask_SeqNum.Value = Task_SeqNum
            arParams(2) = paramTask_SeqNum
            Dim paramTask_Client As New SqlParameter("@Client", SqlDbType.VarChar)
            paramTask_Client.Value = Task_Client
            arParams(3) = paramTask_Client
            Dim paramTask_Division As New SqlParameter("@Division", SqlDbType.VarChar)
            paramTask_Division.Value = Task_Division
            arParams(4) = paramTask_Division
            Dim paramTask_Product As New SqlParameter("@Product", SqlDbType.VarChar)
            paramTask_Product.Value = Task_Product
            arParams(5) = paramTask_Product
            Dim dt As New DataTable
            dt = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_GetAvailableContactList", "AvailContacts", arParams)
            Return dt
        Catch ex As Exception
        End Try
    End Function
    Public Function GetTaskContactList(ByVal Task_JobNum As Integer, ByVal Task_JobCompNum As Integer, ByVal Task_SeqNum As Integer) As DataTable
        Try
            Dim arParams(3) As SqlParameter
            Dim paramTask_JobNum As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            paramTask_JobNum.Value = Task_JobNum
            arParams(0) = paramTask_JobNum
            Dim paramTask_JobCompNum As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.Int)
            paramTask_JobCompNum.Value = Task_JobCompNum
            arParams(1) = paramTask_JobCompNum
            Dim paramTask_SeqNum As New SqlParameter("@SEQ", SqlDbType.SmallInt)
            paramTask_SeqNum.Value = Task_SeqNum
            arParams(2) = paramTask_SeqNum
            Dim dt As New DataTable
            dt = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_GetContactList", "TaskContacts", arParams)
            Return dt
        Catch ex As Exception
        End Try
    End Function
    Public Function RemoveContactFromTask(ByVal DataKeyValue As Integer) As String
        Try
            If DataKeyValue = 0 Then
                Return "Missing datakey for delete."
            Else
                Dim parameterID As New SqlParameter("@ID", SqlDbType.Int)
                parameterID.Value = DataKeyValue
                oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_RemoveContactFromTask", parameterID)
            End If
        Catch ex As Exception
            Return "Error deleting contact from task:  " & ex.Message.ToString
        End Try
    End Function
    Public Function AddContactToTask(ByVal Task_JobNum As Integer, ByVal Task_JobCompNum As Integer, ByVal Task_SeqNum As Integer, ByVal CDPID As Integer) As String
        If Task_JobNum = 0 Or Task_JobCompNum = 0 Or Task_SeqNum = -1 Or CDPID = 0 Then
            Return "Missing key data for adding contact to task."
        Else
            Try
                Dim arParams(4) As SqlParameter
                Dim paramTask_JobNum As New SqlParameter("@JobNum", SqlDbType.Int)
                paramTask_JobNum.Value = Task_JobNum
                arParams(0) = paramTask_JobNum
                Dim paramTask_JobCompNum As New SqlParameter("@JobCompNum", SqlDbType.Int)
                paramTask_JobCompNum.Value = Task_JobCompNum
                arParams(1) = paramTask_JobCompNum
                Dim paramTask_SeqNum As New SqlParameter("@SeqNum", SqlDbType.SmallInt)
                paramTask_SeqNum.Value = Task_SeqNum
                arParams(2) = paramTask_SeqNum
                Dim paramTask_CDPID As New SqlParameter("@CDPID", SqlDbType.Int)
                paramTask_CDPID.Value = CDPID
                arParams(3) = paramTask_CDPID
                oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_AddContactToTask", arParams)
            Catch ex As Exception
                Return "Error adding contact to task: " & ex.Message.ToString
            End Try
        End If
    End Function
    Public Function WVGetContactCodeID(ByVal ContactCode As String, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String) As Integer
        Dim SessionKey As String = "WVGetContactCodeID" & ContactCode & ClientCode & DivisionCode & ProductCode
        Dim ReturnInteger As Integer = 0
        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim arParams(4) As SqlParameter
            Dim parameterContactCode As New SqlParameter("@ContactCode", SqlDbType.VarChar, 6)
            parameterContactCode.Value = ContactCode.Trim
            arParams(0) = parameterContactCode
            Dim parameterClientCode As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
            parameterClientCode.Value = ClientCode
            arParams(1) = parameterClientCode
            Dim parameterDivisionCode As New SqlParameter("@DivisionCode", SqlDbType.VarChar, 6)
            parameterDivisionCode.Value = DivisionCode
            arParams(2) = parameterDivisionCode
            Dim parameterProductCode As New SqlParameter("@ProductCode", SqlDbType.VarChar, 6)
            parameterProductCode.Value = ProductCode
            arParams(3) = parameterProductCode
            Try
                ReturnInteger = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_getContactCodeID", arParams)
            Catch
                ReturnInteger = 0
            End Try
            HttpContext.Current.Session(SessionKey) = ReturnInteger
        Else
            ReturnInteger = CType(HttpContext.Current.Session(SessionKey).ToString(), Integer)
        End If
        Return ReturnInteger
    End Function
    Public Function WVCheckContactCodeIDScheduleUser(ByVal CDPID As Integer) As Integer
        Dim SessionKey As String = "WVCheckContactCodeIDScheduleUser" & CDPID.ToString()
        Dim ReturnInteger As Integer = 0
        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim arParams(2) As SqlParameter
            Dim parameterCDPID As New SqlParameter("@CDPID", SqlDbType.Int)
            parameterCDPID.Value = CDPID
            arParams(0) = parameterCDPID
            Try
                ReturnInteger = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_checkCCScheduleUser", arParams)
            Catch ex As Exception
                ReturnInteger = 0
            End Try
            HttpContext.Current.Session(SessionKey) = ReturnInteger
        Else
            ReturnInteger = CType(HttpContext.Current.Session(SessionKey).ToString(), Integer)
        End If
        Return ReturnInteger
    End Function
    Public Function WVCheckContactCodeIDInactive(ByVal CDPID As Integer) As Integer
        Dim SessionKey As String = "WVCheckContactCodeIDInactive" & CDPID.ToString()
        Dim ReturnInteger As Integer = 0
        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim arParams(2) As SqlParameter
            Dim parameterCDPID As New SqlParameter("@CDPID", SqlDbType.Int)
            parameterCDPID.Value = CDPID
            arParams(0) = parameterCDPID
            Try
                ReturnInteger = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_checkCCInactive", arParams)
            Catch ex As Exception
                ReturnInteger = 0
            End Try
            HttpContext.Current.Session(SessionKey) = ReturnInteger
        Else
            ReturnInteger = CType(HttpContext.Current.Session(SessionKey).ToString(), Integer)
        End If
        Return ReturnInteger
    End Function
    Public Sub UpdateScheduleHierarchyDates(ByVal JobNumber As Integer, ByVal JobComponentNumber As Short)

        'objects
        Dim SqlParameters As System.Data.SqlClient.SqlParameter() = Nothing

        Try

            SqlParameters = {New System.Data.SqlClient.SqlParameter("@JOB_NUMBER", System.Data.SqlDbType.Int) With {.Value = JobNumber},
                             New System.Data.SqlClient.SqlParameter("@JOB_COMPONENT_NBR", System.Data.SqlDbType.SmallInt) With {.Value = JobComponentNumber}}

            oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "advsp_traffic_schedule_UpdateDatesByHierarchy", SqlParameters)

        Catch ex As Exception

        End Try

    End Sub
    Public Sub MoveTaskHierarchy(ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal SequenceNumber As Short, ByVal ParentTaskSequenceNumber As Short?)

        'objects
        Dim SqlParameters As System.Data.SqlClient.SqlParameter() = Nothing

        Try

            SqlParameters = {New System.Data.SqlClient.SqlParameter("@JOB_NUMBER", System.Data.SqlDbType.Int) With {.Value = JobNumber},
                             New System.Data.SqlClient.SqlParameter("@JOB_COMPONENT_NBR", System.Data.SqlDbType.SmallInt) With {.Value = JobComponentNumber},
                             New System.Data.SqlClient.SqlParameter("@SEQ_NBR", System.Data.SqlDbType.SmallInt) With {.Value = SequenceNumber},
                             New System.Data.SqlClient.SqlParameter("@PARENT_TASK_SEQ", System.Data.SqlDbType.SmallInt) With {.Value = ParentTaskSequenceNumber.GetValueOrDefault(-1)}}

            oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "advsp_traffic_schedule_MoveTaskHierarchy", SqlParameters)

            UpdateScheduleHierarchyDates(JobNumber, JobComponentNumber)

        Catch ex As Exception

        End Try

    End Sub

#End Region
#Region " Tasks Add New "
    Public Function GetBaseJobAndCompInfoDT(ByVal JobNum As Integer, ByVal JobCompNum As Integer) As DataTable
        If JobNum > 0 And JobCompNum > 0 Then
            Dim arParams(2) As SqlParameter
            Dim paramTask_JobNum As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            paramTask_JobNum.Value = JobNum
            arParams(0) = paramTask_JobNum
            Dim paramTask_JobCompNum As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
            paramTask_JobCompNum.Value = JobCompNum
            arParams(1) = paramTask_JobCompNum
            Try
                Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_AddNew_GetBaseJobAndCompInfo", "DtJobDetails", arParams)
            Catch ex As Exception
            End Try
        End If
    End Function
    Public Function GetQuickAddDT(ByVal ShowAsPreset As Boolean) As DataTable
        Dim arP(1) As SqlParameter
        Dim pSHOW_PRESET As New SqlParameter("@SHOW_PRESET", SqlDbType.TinyInt)
        pSHOW_PRESET.Value = MiscFN.BoolToInt(ShowAsPreset)
        arP(0) = pSHOW_PRESET
        Try
            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_GetQuickAdd", "dtQuickAdd", arP)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetAddNewFunctionData(ByVal TrafficCode As String) As DataTable
        Dim arP(1) As SqlParameter
        Dim pTrafficCode As New SqlParameter("@TRF_CODE", SqlDbType.VarChar, 10)
        pTrafficCode.Value = TrafficCode
        arP(0) = pTrafficCode
        Try
            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_AddNew_GetFunctionData", "dtTrafficFunctionData", arP)
        Catch ex As Exception
        End Try
    End Function
    Public Function CopyEmployees(ByVal FromJobNum As Integer, ByVal FromJobComponentNbr As Integer,
    ByVal FromSeqNbr As Integer, ByVal ToJobNum As Integer, ByVal ToJobComponentNbr As Integer, ByVal ToSeqNbr As Integer, Optional ByVal hours As Decimal = 0.0) As String
        Try
            Dim arParams(7) As SqlParameter
            Dim paramFromJobNum As New SqlParameter("@FROM_JOB_NUMBER", SqlDbType.Int)
            paramFromJobNum.Value = FromJobNum
            arParams(0) = paramFromJobNum
            Dim paramFromJobComponentNbr As New SqlParameter("@FROM_JOB_COMPONENT_NBR", SqlDbType.SmallInt)
            paramFromJobComponentNbr.Value = FromJobComponentNbr
            arParams(1) = paramFromJobComponentNbr
            Dim paramFromSeqNbr As New SqlParameter("@FROM_SEQ_NBR", SqlDbType.SmallInt)
            paramFromSeqNbr.Value = FromSeqNbr
            arParams(2) = paramFromSeqNbr
            Dim paramToJobNum As New SqlParameter("@TO_JOB_NUMBER", SqlDbType.Int)
            paramToJobNum.Value = ToJobNum
            arParams(3) = paramToJobNum
            Dim paramToJobComponentNbr As New SqlParameter("@TO_JOB_COMPONENT_NBR", SqlDbType.SmallInt)
            paramToJobComponentNbr.Value = ToJobComponentNbr
            arParams(4) = paramToJobComponentNbr
            Dim paramToSeqNbr As New SqlParameter("@TO_SEQ_NBR", SqlDbType.SmallInt)
            paramToSeqNbr.Value = ToSeqNbr
            arParams(5) = paramToSeqNbr
            Dim paramHours As New SqlParameter("@HOURS", SqlDbType.SmallInt)
            paramHours.Value = hours
            arParams(6) = paramHours
            oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_CopyEmployees", arParams)
            Return ""
        Catch ex As Exception
            Return ex.Message.ToString()
        End Try
    End Function
    Public Function GetEstimateTasks(ByVal EstNum As Integer, ByVal EstCompNum As Integer, ByVal QuoteNum As Integer, ByVal RevNum As Integer) As DataTable
        Try
            Dim arParams(4) As SqlParameter
            Dim paramEstNum As New SqlParameter("@EstNo", SqlDbType.Int)
            paramEstNum.Value = EstNum
            arParams(0) = paramEstNum
            Dim paramEstCompNum As New SqlParameter("@EstCompNo", SqlDbType.Int)
            paramEstCompNum.Value = EstCompNum
            arParams(1) = paramEstCompNum
            Dim paramQuoteNum As New SqlParameter("@QuoteNo", SqlDbType.Int)
            paramQuoteNum.Value = QuoteNum
            arParams(2) = paramQuoteNum
            Dim paramRevNum As New SqlParameter("@RevNo", SqlDbType.Int)
            paramRevNum.Value = RevNum
            arParams(3) = paramRevNum
            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_GetEstimateTasks", "dtTasks", arParams)
        Catch ex As Exception
            Err.Raise(Err.Number, "Error GetEstimatingTasks!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try
    End Function
#End Region
#Region " Task WorkSheet "
    Public Function GetScheduleWSTaskData(ByVal JobNum As Integer, ByVal JobCompNum As Integer, ByVal UserCode As String, Optional ByVal CliCode As String = "",
    Optional ByVal DivCode As String = "", Optional ByVal PrdCode As String = "", Optional ByVal EmpCode As String = "", Optional ByVal AECode As String = "",
    Optional ByVal TaskCode As String = "", Optional ByVal RoleCode As String = "", Optional ByVal CutOffDate As String = "", Optional ByVal ManagerCode As String = "",
    Optional ByVal Campaign As String = "", Optional ByVal OnlyOpenScheds As Boolean = True,
    Optional ByVal IncludeCompletedTasks As Boolean = True, Optional ByVal IncludeOnlyPendingTasks As Boolean = False, Optional ByVal ExcludeProjectedTasks As Boolean = False,
    Optional ByVal PhaseFilter As String = "", Optional ByVal MilestonesOnly As Boolean = False, Optional ByVal TrafficStatusCode As String = "") As DataTable
        Try
            Dim arParams(20) As SqlParameter
            Dim paramJobNumber As New SqlParameter("@JobNumber", SqlDbType.Int)
            paramJobNumber.Value = JobNum
            arParams(0) = paramJobNumber
            Dim paramJobCompNumber As New SqlParameter("@JobCompNumber", SqlDbType.Int)
            paramJobCompNumber.Value = JobCompNum
            arParams(1) = paramJobCompNumber
            Dim paramUserCode As New SqlParameter("@USER_ID", SqlDbType.VarChar, 100)
            paramUserCode.Value = UserCode
            arParams(2) = paramUserCode
            Dim paramCliCode As New SqlParameter("@CL_CODE", SqlDbType.VarChar, 6)
            paramCliCode.Value = CliCode
            arParams(3) = paramCliCode
            Dim paramDivCode As New SqlParameter("@DIV_CODE", SqlDbType.VarChar, 6)
            paramDivCode.Value = DivCode
            arParams(4) = paramDivCode
            Dim paramProdCode As New SqlParameter("@PRD_CODE", SqlDbType.VarChar, 6)
            paramProdCode.Value = PrdCode
            arParams(5) = paramProdCode
            Dim paramEmpCode As New SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
            paramEmpCode.Value = EmpCode
            arParams(6) = paramEmpCode
            Dim paramAECode As New SqlParameter("@AE_CODE", SqlDbType.VarChar, 6)
            paramAECode.Value = AECode
            arParams(7) = paramAECode
            Dim paramTaskCode As New SqlParameter("@TASK_CODE", SqlDbType.VarChar, 10)
            paramTaskCode.Value = TaskCode
            arParams(8) = paramTaskCode
            Dim paramRoleCode As New SqlParameter("@ROLE_CODE", SqlDbType.VarChar, 6)
            paramRoleCode.Value = RoleCode
            arParams(9) = paramRoleCode
            Dim paramCutOffDate As New SqlParameter("@CUT_OFF_DATE", SqlDbType.SmallDateTime)
            If cGlobals.wvIsDate(CutOffDate) = True Then
                paramCutOffDate.Value = cGlobals.wvCDate(CutOffDate).ToShortDateString
            Else
                paramCutOffDate.Value = DBNull.Value
            End If
            arParams(10) = paramCutOffDate
            Dim paramManagerCode As New SqlParameter("@MGR_CODE", SqlDbType.VarChar, 6)
            paramManagerCode.Value = ManagerCode
            arParams(11) = paramManagerCode
            Dim paramCampaign As New SqlParameter("@CMP_CODE", SqlDbType.VarChar, 6)
            paramCampaign.Value = Campaign
            arParams(12) = paramCampaign
            Dim paramOnlyOpenScheds As New SqlParameter("@SHOW_ONLY_OPEN_SCHEDS", SqlDbType.SmallInt)
            If OnlyOpenScheds = True Then
                paramOnlyOpenScheds.Value = 1
            Else
                paramOnlyOpenScheds.Value = 0
            End If
            arParams(13) = paramOnlyOpenScheds
            Dim paramIncludeCompletedTasks As New SqlParameter("@IncludeCompletedTasks", SqlDbType.Char)
            If IncludeCompletedTasks = True Then
                paramIncludeCompletedTasks.Value = "Y"
            Else
                paramIncludeCompletedTasks.Value = "N"
            End If
            arParams(14) = paramIncludeCompletedTasks
            Dim paramIncludeOnlyPendingTasks As New SqlParameter("@IncludeOnlyPendingTasks", SqlDbType.Char)
            If IncludeOnlyPendingTasks = True Then
                paramIncludeOnlyPendingTasks.Value = "Y"
            Else
                paramIncludeOnlyPendingTasks.Value = "N"
            End If
            arParams(15) = paramIncludeOnlyPendingTasks
            Dim paramExcludeProjectedTasks As New SqlParameter("@ExcludeProjectedTasks", SqlDbType.Char)
            If ExcludeProjectedTasks = True Then
                paramExcludeProjectedTasks.Value = "Y"
            Else
                paramExcludeProjectedTasks.Value = "N"
            End If
            arParams(16) = paramExcludeProjectedTasks
            Dim paramPhaseFilter As New SqlParameter("@PHASE_FILTER", SqlDbType.VarChar, 10)
            paramPhaseFilter.Value = PhaseFilter
            arParams(17) = paramPhaseFilter
            Dim paramMilestonesOnly As New SqlParameter("@MILESTONES_ONLY", SqlDbType.Bit)
            If MilestonesOnly = True Then
                paramMilestonesOnly.Value = 1
            Else
                paramMilestonesOnly.Value = 0
            End If
            arParams(18) = paramMilestonesOnly
            Dim paramTrafficStatusCode As New SqlParameter("@TRAFFIC_STATUS_CODE", SqlDbType.VarChar, 10)
            paramTrafficStatusCode.Value = TrafficStatusCode
            arParams(19) = paramTrafficStatusCode
            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_GetWSTasksData", "dtSchedHeads", arParams)
        Catch ex As Exception
            Err.Raise(Err.Number, "Error GetTrafficScheduleWSTasksData!<br />" & ex.Message.ToString() & "<br/>" & ex.InnerException.ToString())
        End Try
    End Function
    Public Function GetScheduleWSTasks(ByVal JobNum As Integer, ByVal JobCompNum As Integer, ByVal UserCode As String, Optional ByVal EmpCode As String = "",
    Optional ByVal TaskCode As String = "", Optional ByVal RoleCode As String = "",
    Optional ByVal IncludeCompletedTasks As String = "",
    Optional ByVal IncludeOnlyPendingTasks As String = "",
    Optional ByVal ExcludeProjectedTasks As String = "",
    Optional ByVal CutOffDate As String = "", Optional ByVal PhaseFilter As String = "") As DataTable
        Try
            Dim arParams(11) As SqlParameter
            Dim paramJobNumber As New SqlParameter("@JobNumber", SqlDbType.Int)
            paramJobNumber.Value = JobNum
            arParams(0) = paramJobNumber
            Dim paramJobCompNumber As New SqlParameter("@JobCompNumber", SqlDbType.Int)
            paramJobCompNumber.Value = JobCompNum
            arParams(1) = paramJobCompNumber
            Dim paramUserCode As New SqlParameter("@USER_ID", SqlDbType.VarChar, 100)
            paramUserCode.Value = UserCode
            arParams(2) = paramUserCode
            Dim paramEmpCode As New SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
            paramEmpCode.Value = EmpCode
            arParams(3) = paramEmpCode
            Dim paramTaskCode As New SqlParameter("@TASK_CODE", SqlDbType.VarChar, 10)
            paramTaskCode.Value = TaskCode
            arParams(4) = paramTaskCode
            Dim paramRoleCode As New SqlParameter("@ROLE_CODE", SqlDbType.VarChar, 6)
            paramRoleCode.Value = RoleCode
            arParams(5) = paramRoleCode
            Dim paramIncludeCompletedTasks As New SqlParameter("@IncludeCompletedTasks", SqlDbType.Char)
            If IncludeCompletedTasks = "True" Then
                paramIncludeCompletedTasks.Value = "Y"
            Else
                paramIncludeCompletedTasks.Value = "N"
            End If
            arParams(6) = paramIncludeCompletedTasks
            Dim paramIncludeOnlyPendingTasks As New SqlParameter("@IncludeOnlyPendingTasks", SqlDbType.Char)
            If IncludeOnlyPendingTasks = "True" Then
                paramIncludeOnlyPendingTasks.Value = "Y"
            Else
                paramIncludeOnlyPendingTasks.Value = "N"
            End If
            arParams(7) = paramIncludeOnlyPendingTasks
            Dim paramExcludeProjectedTasks As New SqlParameter("@ExcludeProjectedTasks", SqlDbType.Char)
            If ExcludeProjectedTasks = "True" Then
                paramExcludeProjectedTasks.Value = "Y"
            Else
                paramExcludeProjectedTasks.Value = "N"
            End If
            arParams(8) = paramExcludeProjectedTasks
            Dim paramCutOffDate As New SqlParameter("@CUT_OFF_DATE", SqlDbType.SmallDateTime)
            If cGlobals.wvIsDate(CutOffDate) = True Then
                paramCutOffDate.Value = cGlobals.wvCDate(CutOffDate).ToShortDateString
            Else
                paramCutOffDate.Value = DBNull.Value
            End If
            arParams(9) = paramCutOffDate
            Dim paramPhaseFilter As New SqlParameter("@PHASE_FILTER", SqlDbType.VarChar, 10)
            paramPhaseFilter.Value = PhaseFilter
            arParams(10) = paramPhaseFilter
            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_GetWSTasks", "dtSchedTasks", arParams)
        Catch ex As Exception
            Err.Raise(Err.Number, "Error GetTrafficScheduleWSTasks!<br />" & ex.Message.ToString() & "<br/>" & ex.InnerException.ToString())
        End Try
    End Function
#End Region
#Region " Gantt "
    Public Function GetGanttData(ByVal JobNum As Integer, ByVal JobCompNum As Integer) As DataSet
        Try
            Dim arParams(2) As SqlParameter
            Dim paramJobNumber As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            paramJobNumber.Value = JobNum
            arParams(0) = paramJobNumber
            Dim paramJobCompNumber As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
            paramJobCompNumber.Value = JobCompNum
            arParams(1) = paramJobCompNumber
            Return oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_Gantt_GetTasks", arParams)
        Catch ex As Exception
            Err.Raise(Err.Number, "Error GetGanttData!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try
    End Function
    Public Function UpdateGanttTaskDates(ByVal Task_JobNum As Integer, ByVal Task_JobCompNum As Integer, ByVal Task_SeqNum As Integer, ByVal NewStartDate As String, ByVal NewDueDate As String, ByVal SetDays As Boolean) As Integer
        Try
            Dim arParams(6) As SqlParameter
            Dim paramTask_JobNum As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            paramTask_JobNum.Value = Task_JobNum
            arParams(0) = paramTask_JobNum
            Dim paramTask_JobCompNum As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
            paramTask_JobCompNum.Value = Task_JobCompNum
            arParams(1) = paramTask_JobCompNum
            Dim paramTask_SeqNum As New SqlParameter("@SEQ_NBR", SqlDbType.SmallInt)
            paramTask_SeqNum.Value = Task_SeqNum
            arParams(2) = paramTask_SeqNum
            Dim paramNewStartDate As New SqlParameter("@NEW_START_DATE", SqlDbType.SmallDateTime)
            paramNewStartDate.Value = cGlobals.wvCDate(NewStartDate)
            arParams(3) = paramNewStartDate
            Dim paramNewDueDate As New SqlParameter("@NEW_DUE_DATE", SqlDbType.SmallDateTime)
            paramNewDueDate.Value = cGlobals.wvCDate(NewDueDate)
            arParams(4) = paramNewDueDate
            Dim paramRetVal As New SqlParameter("@RETURN_ID", SqlDbType.SmallInt)
            paramRetVal.Direction = ParameterDirection.Output
            arParams(5) = paramRetVal
            Dim paramSetDays As New SqlParameter("@SET_DAYS", SqlDbType.SmallInt)
            If SetDays = True Then
                paramSetDays.Value = 1
            Else
                paramSetDays.Value = 0
            End If
            arParams(6) = paramSetDays
            oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_Gantt_UpdateDates", arParams)
            Dim i As Integer = CType(paramRetVal.Value, Integer)
            Return i
        Catch ex As Exception
            Return -1
        End Try
    End Function
#End Region
#Region " Workload "
    Public Function GetWorkloadEmps(ByVal JobCompList As String) As DataTable
        Try
            Dim arParams(1) As SqlParameter
            Dim paramJobCompList As New SqlParameter("@JOB_COMP_LIST", SqlDbType.VarChar, 4000)
            paramJobCompList.Value = JobCompList
            arParams(0) = paramJobCompList
            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_GetEmpList_Workload", "dtEmpList", arParams)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetProjectSummaryDates(ByVal StartPeriod As String, ByVal EndPeriod As String, ByVal CurrentPeriod As String, ByVal DisplayOption As Integer) As DataTable
        Try
            Dim arParams(4) As SqlParameter

            Dim paramStartPeriod As New SqlParameter("@START_PERIOD", SqlDbType.VarChar)
            paramStartPeriod.Value = StartPeriod
            arParams(0) = paramStartPeriod

            Dim paramEndPeriod As New SqlParameter("@END_PERIOD", SqlDbType.VarChar)
            paramEndPeriod.Value = EndPeriod
            arParams(1) = paramEndPeriod

            Dim paramCurrentPeriod As New SqlParameter("@CURRENT_PERIOD", SqlDbType.VarChar)
            paramCurrentPeriod.Value = CurrentPeriod
            arParams(2) = paramCurrentPeriod

            Dim paramDisplayOption As New SqlParameter("@DISPLAY_OPTION", SqlDbType.Int)
            paramDisplayOption.Value = DisplayOption
            arParams(3) = paramDisplayOption

            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_Revenue_Forecast_Dates", "dtDates", arParams)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

#End Region
#Region " Status "
    Public Function GetScheduleStatusTasks(ByVal JobNum As Integer, ByVal JobCompNum As Integer, ByVal Planned As String, Optional ByVal Quoted As Integer = 0) As DataSet
        Try
            Dim arParams(4) As SqlParameter
            Dim paramJobNumber As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            paramJobNumber.Value = JobNum
            arParams(0) = paramJobNumber
            Dim paramJobCompNumber As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.Int)
            paramJobCompNumber.Value = JobCompNum
            arParams(1) = paramJobCompNumber
            Dim paramPlanned As New SqlParameter("@PLANNED", SqlDbType.VarChar)
            paramPlanned.Value = Planned
            arParams(2) = paramPlanned
            Dim paramQuoted As New SqlParameter("@Quoted", SqlDbType.Int)
            paramQuoted.Value = Quoted
            arParams(3) = paramQuoted
            Return oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Project_Status_Data", arParams)
        Catch ex As Exception
            Err.Raise(Err.Number, "Error GetTrafficScheduleStatus!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try
    End Function
    Public Function GetScheduleStatusTasksWeek(ByVal JobNum As Integer, ByVal JobCompNum As Integer, Optional ByVal Quoted As Integer = 0) As DataSet
        Try
            Dim arParams(3) As SqlParameter
            Dim paramJobNumber As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            paramJobNumber.Value = JobNum
            arParams(0) = paramJobNumber
            Dim paramJobCompNumber As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.Int)
            paramJobCompNumber.Value = JobCompNum
            arParams(1) = paramJobCompNumber
            Dim paramQuoted As New SqlParameter("@Quoted", SqlDbType.Int)
            paramQuoted.Value = Quoted
            arParams(2) = paramQuoted
            Return oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Project_Status_Data_Week", arParams)
        Catch ex As Exception
            Err.Raise(Err.Number, "Error GetTrafficScheduleStatus!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try
    End Function
    Public Function GetScheduleStatusSummary(ByVal jobs As String, ByVal comps As String) As DataSet
        Try
            Dim arParams(2) As SqlParameter
            Dim paramJobNumber As New SqlParameter("@JOB_NUMBER", SqlDbType.VarChar)
            paramJobNumber.Value = jobs
            arParams(0) = paramJobNumber
            Dim paramJobCompNumber As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.VarChar)
            paramJobCompNumber.Value = comps
            arParams(1) = paramJobCompNumber
            Return oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Project_Status_Summary", arParams)
        Catch ex As Exception
            Err.Raise(Err.Number, "Error GetTrafficScheduleStatusSummary!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try
    End Function
    Public Shared Function getFCXMLData_MultiColumn3D_ProjectStatus(ByVal dsForGraph As DataSet, Optional ByVal strCaption As String = "", Optional ByVal chartoption As Integer = 0, Optional ByVal chartdata As String = "",
    Optional ByVal charthours As String = "", Optional ByVal charttype As String = "", Optional ByVal burn As String = "", Optional ByVal group As String = "") As String
        Dim strFCXMLData As String
        Dim sbFCXMLData As Text.StringBuilder = New Text.StringBuilder
        Dim dt As New DataTable
        Dim i As Integer = 0
        Dim sum As Decimal = 0
        Dim sump As Decimal = 0
        Try
            If dsForGraph.Tables(0).Rows.Count > 0 Then
                With sbFCXMLData
                    'Open chart:
                    If chartoption = 1 Then
                        .Append("<chart caption='" & strCaption.Replace("'", "") & "' XAxisName='' palette='2' animation='1' formatNumberScale='0' numberPrefix='' showValues='0' numDivLines='6' legendPosition='BOTTOM' decimals='2' labelDisplay='Rotate' slantLabels='0' yAxisMaxvalue='2' yAxisMinValue='0'>")
                    Else
                        .Append("<chart caption='" & strCaption.Replace("'", "") & "' XAxisName='' palette='2' animation='1' formatNumberScale='0' numberPrefix='' showValues='0' numDivLines='6' legendPosition='BOTTOM' decimals='2' labelDisplay='Rotate' slantLabels='0'>")
                    End If
                    'Add Clients:
                    .Append("<categories>")
                    i = 0
                    For i = 0 To dsForGraph.Tables(0).Rows.Count - 1
                        If group = "Month" Then
                            .Append("<category label='" & MonthName(dsForGraph.Tables(0).Rows(i)(2)) & "' />")
                        ElseIf group = "Week" Then
                            .Append("<category label='" & CDate(dsForGraph.Tables(0).Rows(i)("WEEK_START").ToString).ToShortDateString & "' />")
                        End If
                    Next
                    .Append("</categories>")
                    'Add columns:
                    If chartdata = "Hours" Then
                        If chartoption = 0 Then
                            i = 0
                            .Append("<dataset seriesName='Quoted'>")
                            For i = 0 To dsForGraph.Tables(0).Rows.Count - 1
                                If charttype = "Monthly" Then
                                    .Append("<set value='" & dsForGraph.Tables(0).Rows(i)(4) & "' />")
                                ElseIf charttype = "Cumulative" Then
                                    sum += CDec(dsForGraph.Tables(0).Rows(i)(4))
                                    .Append("<set value='" & sum & "' />")
                                End If
                            Next
                            .Append("</dataset>")
                            sum = 0
                            i = 0
                            .Append("<dataset seriesName='Planned/Adjusted'>")
                            For i = 0 To dsForGraph.Tables(0).Rows.Count - 1
                                If charthours = "ETF" Then
                                    If charttype = "Monthly" Then
                                        .Append("<set value='" & dsForGraph.Tables(0).Rows(i)(6) & "' />")
                                    ElseIf charttype = "Cumulative" Then
                                        sum += CDec(dsForGraph.Tables(0).Rows(i)(6))
                                        .Append("<set value='" & sum & "' />")
                                    End If
                                ElseIf charthours = "Allowed" Then
                                    If charttype = "Monthly" Then
                                        .Append("<set value='" & dsForGraph.Tables(0).Rows(i)(8) & "' />")
                                    ElseIf charttype = "Cumulative" Then
                                        sum += CDec(dsForGraph.Tables(0).Rows(i)(8))
                                        .Append("<set value='" & sum & "' />")
                                    End If
                                End If
                            Next
                            .Append("</dataset>")
                            sum = 0
                            i = 0
                            .Append("<dataset seriesName='Actual'>")
                            For i = 0 To dsForGraph.Tables(0).Rows.Count - 1
                                If charttype = "Monthly" Then
                                    .Append("<set value='" & dsForGraph.Tables(0).Rows(i)(10) & "' />")
                                ElseIf charttype = "Cumulative" Then
                                    sum += CDec(dsForGraph.Tables(0).Rows(i)(10))
                                    .Append("<set value='" & sum & "' />")
                                End If
                            Next
                            .Append("</dataset>")
                        ElseIf chartoption = 1 Then
                            i = 0
                            .Append("<dataset seriesName='Burn Rate'>")
                            For i = 0 To dsForGraph.Tables(0).Rows.Count - 1
                                If burn = "Planned" Then
                                    If charthours = "ETF" Then
                                        If charttype = "Monthly" Then
                                            .Append("<set value='" & dsForGraph.Tables(0).Rows(i)(12) & "' />")
                                        ElseIf charttype = "Cumulative" Then
                                            sum += CDec(dsForGraph.Tables(0).Rows(i)(10))
                                            sump += CDec(dsForGraph.Tables(0).Rows(i)(6))
                                            If sump > 0 Then
                                                .Append("<set value='" & String.Format("{0:#,##0.00}", sum / sump) & "' />")
                                            Else
                                                .Append("<set value='0.00' />")
                                            End If
                                        End If
                                    ElseIf charthours = "Allowed" Then
                                        If charttype = "Monthly" Then
                                            .Append("<set value='" & dsForGraph.Tables(0).Rows(i)(14) & "' />")
                                        ElseIf charttype = "Cumulative" Then
                                            sum += CDec(dsForGraph.Tables(0).Rows(i)(10))
                                            sump += CDec(dsForGraph.Tables(0).Rows(i)(8))
                                            If sump > 0 Then
                                                .Append("<set value='" & String.Format("{0:#,##0.00}", sum / sump) & "' />")
                                            Else
                                                .Append("<set value='0.00' />")
                                            End If
                                        End If
                                    End If
                                ElseIf burn = "Quoted" Then
                                    If charttype = "Monthly" Then
                                        sum = CDec(dsForGraph.Tables(0).Rows(i)(10))
                                        sump = CDec(dsForGraph.Tables(0).Rows(i)(4))
                                        If sump > 0 Then
                                            .Append("<set value='" & String.Format("{0:#,##0.00}", sum / sump) & "' />")
                                        Else
                                            .Append("<set value='0.00' />")
                                        End If
                                    ElseIf charttype = "Cumulative" Then
                                        sum += CDec(dsForGraph.Tables(0).Rows(i)(10))
                                        sump += CDec(dsForGraph.Tables(0).Rows(i)(4))
                                        If sump > 0 Then
                                            .Append("<set value='" & String.Format("{0:#,##0.00}", sum / sump) & "' />")
                                        Else
                                            .Append("<set value='0.00' />")
                                        End If
                                    End If
                                End If
                            Next
                            .Append("</dataset>")
                        End If
                    ElseIf chartdata = "Dollars" Then
                        If chartoption = 0 Then
                            i = 0
                            .Append("<dataset seriesName='Quoted'>")
                            For i = 0 To dsForGraph.Tables(0).Rows.Count - 1
                                If charttype = "Monthly" Then
                                    .Append("<set value='" & dsForGraph.Tables(0).Rows(i)(5) & "' />")
                                ElseIf charttype = "Cumulative" Then
                                    sum += CDec(dsForGraph.Tables(0).Rows(i)(5))
                                    .Append("<set value='" & sum & "' />")
                                End If
                            Next
                            .Append("</dataset>")
                            sum = 0
                            i = 0
                            .Append("<dataset seriesName='Planned/Adjusted'>")
                            For i = 0 To dsForGraph.Tables(0).Rows.Count - 1
                                If charthours = "ETF" Then
                                    If charttype = "Monthly" Then
                                        .Append("<set value='" & dsForGraph.Tables(0).Rows(i)(7) & "' />")
                                    ElseIf charttype = "Cumulative" Then
                                        sum += CDec(dsForGraph.Tables(0).Rows(i)(7))
                                        .Append("<set value='" & sum & "' />")
                                    End If
                                ElseIf charthours = "Allowed" Then
                                    If charttype = "Monthly" Then
                                        .Append("<set value='" & dsForGraph.Tables(0).Rows(i)(9) & "' />")
                                    ElseIf charttype = "Cumulative" Then
                                        sum += CDec(dsForGraph.Tables(0).Rows(i)(9))
                                        .Append("<set value='" & sum & "' />")
                                    End If
                                End If
                            Next
                            .Append("</dataset>")
                            sum = 0
                            i = 0
                            .Append("<dataset seriesName='Actual'>")
                            For i = 0 To dsForGraph.Tables(0).Rows.Count - 1
                                If charttype = "Monthly" Then
                                    .Append("<set value='" & dsForGraph.Tables(0).Rows(i)(11) & "' />")
                                ElseIf charttype = "Cumulative" Then
                                    sum += CDec(dsForGraph.Tables(0).Rows(i)(11))
                                    .Append("<set value='" & sum & "' />")
                                End If
                            Next
                            .Append("</dataset>")
                        ElseIf chartoption = 1 Then
                            i = 0
                            .Append("<dataset seriesName='Burn Rate'>")
                            For i = 0 To dsForGraph.Tables(0).Rows.Count - 1
                                If burn = "Planned" Then
                                    If charthours = "ETF" Then
                                        If charttype = "Monthly" Then
                                            .Append("<set value='" & dsForGraph.Tables(0).Rows(i)(13) & "' />")
                                        ElseIf charttype = "Cumulative" Then
                                            sum += CDec(dsForGraph.Tables(0).Rows(i)(11))
                                            sump += CDec(dsForGraph.Tables(0).Rows(i)(7))
                                            If sump > 0 Then
                                                .Append("<set value='" & String.Format("{0:#,##0.00}", sum / sump) & "' />")
                                            Else
                                                .Append("<set value='0.00' />")
                                            End If
                                        End If
                                    ElseIf charthours = "Allowed" Then
                                        If charttype = "Monthly" Then
                                            .Append("<set value='" & dsForGraph.Tables(0).Rows(i)(15) & "' />")
                                        ElseIf charttype = "Cumulative" Then
                                            sum += CDec(dsForGraph.Tables(0).Rows(i)(11))
                                            sump += CDec(dsForGraph.Tables(0).Rows(i)(9))
                                            If sump > 0 Then
                                                .Append("<set value='" & String.Format("{0:#,##0.00}", sum / sump) & "' />")
                                            Else
                                                .Append("<set value='0.00' />")
                                            End If
                                        End If
                                    End If
                                ElseIf burn = "Quoted" Then
                                    If charttype = "Monthly" Then
                                        sum = CDec(dsForGraph.Tables(0).Rows(i)(11))
                                        sump = CDec(dsForGraph.Tables(0).Rows(i)(5))
                                        If sump > 0 Then
                                            .Append("<set value='" & String.Format("{0:#,##0.00}", sum / sump) & "' />")
                                        Else
                                            .Append("<set value='0.00' />")
                                        End If
                                    ElseIf charttype = "Cumulative" Then
                                        sum += CDec(dsForGraph.Tables(0).Rows(i)(11))
                                        sump += CDec(dsForGraph.Tables(0).Rows(i)(5))
                                        If sump > 0 Then
                                            .Append("<set value='" & String.Format("{0:#,##0.00}", sum / sump) & "' />")
                                        Else
                                            .Append("<set value='0.00' />")
                                        End If
                                    End If
                                End If
                            Next
                            .Append("</dataset>")
                        End If
                    End If
                    If chartoption = 1 Then
                        .Append("<trendLines>")
                        .Append("<line startValue='1' color='FF0000' displayValue='' />")
                        .Append("</trendLines>")
                    End If
                    'Close chart:
                    .Append("<styles>")
                    .Append("<definition>")
                    .Append("<style type='font' name='CaptionFont' color='666666' size='10' />")
                    .Append("<style type='font' name='SubCaptionFont' bold='0' />")
                    .Append("</definition>")
                    .Append("<application>")
                    .Append("<apply toObject='caption' styles='CaptionFont' /> ")
                    .Append("<apply toObject='SubCaption' styles='SubCaptionFont' />")
                    .Append("</application>")
                    .Append("</styles>")
                    .Append("</chart>")
                End With
            Else
                With sbFCXMLData
                    .Append("<chart></chart>")
                End With
            End If
            Return cleanString(sbFCXMLData.ToString())
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Public Shared Function cleanString(ByVal str As String) As String
        str = str.Replace("&", " and ")
        str = str.Replace("n's", "ns")
        str = str.Replace("12:00:00 AM", "")
        Return str
    End Function
#End Region
    Public Sub New(Optional ByVal UserCode As String = "", Optional ByVal EmpCode As String = "")
        mConnString = HttpContext.Current.Session("ConnString")
        Try
            If UserCode <> "" Then
                mUserCode = UserCode
            Else
                mUserCode = HttpContext.Current.Session("UserCode")
            End If
        Catch ex As Exception
            mUserCode = ""
        End Try
        Try
            If EmpCode <> "" Then
                mEmpCode = EmpCode
            Else
                mEmpCode = HttpContext.Current.Session("EmpCode")
            End If
        Catch ex As Exception
            mEmpCode = ""
        End Try
    End Sub
End Class
