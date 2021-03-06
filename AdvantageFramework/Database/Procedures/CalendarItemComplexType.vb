Namespace Database.Procedures.CalendarItemComplexType

    <HideModuleName()> _
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Function Load(DbContext As Database.DbContext, UserCode As String, EmployeeCode As String,
                             OfficeCode As String, ClientCode As String, DivCode As String, ProdCode As String,
                             JobNumber As String, JobComp As String, ROLES As String, StartDate As DateTime,
                             EndDate As DateTime, TaskStatus As String, ExcludeTempComplete As String, MilestonesOnly As String,
                             Manager As String, GrpLevel As String, Type As String, ShowTasks As Integer,
                             ShowDuration As Integer, ShowEvents As Integer, ShowEventTasks As Integer,
                             DEPTS As String, TRF_CODE As String, ShowAssignments As Integer,
                             Optional ByVal CP As Boolean = False, Optional ByVal CPID As Integer = 0,
                             Optional ByVal FuncRoles As String = "", Optional ByVal IncludeUnassigned As Boolean = False) As System.Collections.Generic.List(Of AdvantageFramework.Database.Classes.CalendarItem)

            Dim SqlParameterUserID As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterEmpCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterOfficeCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterClientCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterDivCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterProdCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterJobNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterJobComp As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterRoles As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterStartDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterEndDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterTaskStatus As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterExcludeTaskComplete As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterMilestonesOnly As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterManager As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterGroupLevel As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterType As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterShowTasks As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterShowAssignments As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterShowDuration As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterShowEvents As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterShowEventTasks As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterDepts As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterTrfCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterCP As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterCPID As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterFuncRoles As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterIncludeUnassigned As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterUserID = New System.Data.SqlClient.SqlParameter("@UserID", SqlDbType.VarChar)
            SqlParameterEmpCode = New System.Data.SqlClient.SqlParameter("@EmpCode", SqlDbType.VarChar)
            SqlParameterOfficeCode = New System.Data.SqlClient.SqlParameter("@OfficeCode", SqlDbType.VarChar)
            SqlParameterClientCode = New System.Data.SqlClient.SqlParameter("@ClientCode", SqlDbType.VarChar)
            SqlParameterDivCode = New System.Data.SqlClient.SqlParameter("@DivCode", SqlDbType.VarChar)
            SqlParameterProdCode = New System.Data.SqlClient.SqlParameter("@ProdCode", SqlDbType.VarChar)
            SqlParameterJobNumber = New System.Data.SqlClient.SqlParameter("@JobNumber", SqlDbType.VarChar)
            SqlParameterJobComp = New System.Data.SqlClient.SqlParameter("@JobComp", SqlDbType.VarChar)
            SqlParameterRoles = New System.Data.SqlClient.SqlParameter("@ROLES", SqlDbType.VarChar)
            SqlParameterStartDate = New System.Data.SqlClient.SqlParameter("@StartDate", SqlDbType.SmallDateTime)
            SqlParameterEndDate = New System.Data.SqlClient.SqlParameter("@EndDate", SqlDbType.SmallDateTime)
            SqlParameterTaskStatus = New System.Data.SqlClient.SqlParameter("@TaskStatus", SqlDbType.VarChar)
            SqlParameterExcludeTaskComplete = New System.Data.SqlClient.SqlParameter("@ExcludeTempComplete", SqlDbType.Char)
            SqlParameterMilestonesOnly = New System.Data.SqlClient.SqlParameter("@MilestonesOnly", SqlDbType.Char)
            SqlParameterManager = New System.Data.SqlClient.SqlParameter("@Manager", SqlDbType.VarChar)
            SqlParameterGroupLevel = New System.Data.SqlClient.SqlParameter("@GrpLevel", SqlDbType.VarChar)
            SqlParameterType = New System.Data.SqlClient.SqlParameter("@Type", SqlDbType.VarChar)
            SqlParameterShowTasks = New System.Data.SqlClient.SqlParameter("@ShowTasks", SqlDbType.SmallInt)
            SqlParameterShowAssignments = New System.Data.SqlClient.SqlParameter("@ShowAssignments", SqlDbType.SmallInt)
            SqlParameterShowDuration = New System.Data.SqlClient.SqlParameter("@ShowDuration", SqlDbType.SmallInt)
            SqlParameterShowEvents = New System.Data.SqlClient.SqlParameter("@Show_Events", SqlDbType.SmallInt)
            SqlParameterShowEventTasks = New System.Data.SqlClient.SqlParameter("Show_Event_Tasks", SqlDbType.SmallInt)
            SqlParameterDepts = New System.Data.SqlClient.SqlParameter("@DEPTS", SqlDbType.VarChar)
            SqlParameterTrfCode = New System.Data.SqlClient.SqlParameter("@TRF_CODE", SqlDbType.VarChar)
            SqlParameterCP = New System.Data.SqlClient.SqlParameter("@CP", SqlDbType.Int)
            SqlParameterCPID = New System.Data.SqlClient.SqlParameter("@CPID", SqlDbType.Int)
            SqlParameterFuncRoles = New System.Data.SqlClient.SqlParameter("@FuncRoles", SqlDbType.VarChar)
            SqlParameterIncludeUnassigned = New System.Data.SqlClient.SqlParameter("@IncludeUnassigned", SqlDbType.Bit)

            SqlParameterUserID.Value = UserCode
            SqlParameterEmpCode.Value = If(String.IsNullOrWhiteSpace(EmployeeCode), System.DBNull.Value, EmployeeCode)
            SqlParameterOfficeCode.Value = OfficeCode
            SqlParameterClientCode.Value = ClientCode
            SqlParameterDivCode.Value = DivCode
            SqlParameterProdCode.Value = ProdCode

            If JobNumber = "-1" Then
                SqlParameterJobNumber.Value = DBNull.Value
            Else
                SqlParameterJobNumber.Value = JobNumber
            End If

            If JobComp = "-1" Then
                SqlParameterJobComp.Value = DBNull.Value
            Else
                SqlParameterJobComp.Value = JobComp
            End If

            SqlParameterRoles.Value = ROLES
            SqlParameterStartDate.Value = StartDate
            SqlParameterEndDate.Value = EndDate
            SqlParameterTaskStatus.Value = TaskStatus
            SqlParameterExcludeTaskComplete.Value = ExcludeTempComplete
            SqlParameterMilestonesOnly.Value = MilestonesOnly
            SqlParameterManager.Value = Manager
            SqlParameterGroupLevel.Value = GrpLevel
            SqlParameterType.Value = Type
            SqlParameterShowTasks.Value = ShowTasks
            SqlParameterShowAssignments.Value = ShowAssignments
            SqlParameterShowDuration.Value = ShowDuration
            SqlParameterShowEvents.Value = ShowEvents
            SqlParameterShowEventTasks.Value = ShowEventTasks
            SqlParameterDepts.Value = DEPTS
            SqlParameterTrfCode.Value = TRF_CODE

            If CP = True Then
                SqlParameterCP.Value = 1
            Else
                SqlParameterCP.Value = 0
            End If

            SqlParameterCPID.Value = CPID
            SqlParameterFuncRoles.Value = FuncRoles
            SqlParameterIncludeUnassigned.Value = IncludeUnassigned

            Load = DbContext.Database.SqlQuery(Of AdvantageFramework.Database.Classes.CalendarItem)("EXEC dbo.usp_wv_DayPilot_GetMonth @UserID, @EmpCode, @OfficeCode, @ClientCode, @DivCode, @ProdCode, @JobNumber, @JobComp, @ROLES, @StartDate, @EndDate, @TaskStatus, @ExcludeTempComplete, @MilestonesOnly, @Manager, @GrpLevel, @Type, @ShowTasks, @ShowDuration, @Show_Events, @Show_Event_Tasks, @DEPTS, @TRF_CODE, @CP, @CPID, @FuncRoles, @ShowAssignments,@IncludeUnassigned",
                SqlParameterUserID, SqlParameterEmpCode, SqlParameterOfficeCode, SqlParameterClientCode, SqlParameterDivCode, SqlParameterProdCode, SqlParameterJobNumber, SqlParameterJobComp, SqlParameterRoles,
                SqlParameterStartDate, SqlParameterEndDate, SqlParameterTaskStatus, SqlParameterExcludeTaskComplete, SqlParameterMilestonesOnly, SqlParameterManager, SqlParameterGroupLevel, SqlParameterType,
                SqlParameterShowTasks, SqlParameterShowDuration, SqlParameterShowEvents, SqlParameterShowEventTasks, SqlParameterDepts, SqlParameterTrfCode, SqlParameterCP, SqlParameterCPID, SqlParameterFuncRoles, SqlParameterShowAssignments, SqlParameterIncludeUnassigned).ToList

        End Function

#End Region

    End Module

End Namespace
