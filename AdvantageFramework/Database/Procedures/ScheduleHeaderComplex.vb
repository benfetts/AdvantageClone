Namespace Database.Procedures.ScheduleHeaderComplex

    <HideModuleName()> _
    Public Module Methods

        Public Function Load(DbContext As AdvantageFramework.Database.DbContext, ByVal UserCode As String, Optional ByVal PhaseID As Integer? = Nothing,
                             Optional ByVal RoleCode As String = Nothing, Optional ByVal TaskCode As String = Nothing, Optional ByVal EmployeeCode As String = Nothing,
                             Optional ByVal PendingTasksOnly As Boolean = False, Optional ByVal ExcludeProjectedTasks As Boolean = False, Optional ByVal IncludeCompletedTasks As Boolean = True,
                             Optional ByVal IncludeClosedJobs As Boolean = False, Optional ByVal CutOffDate As Date? = Nothing) As System.Collections.Generic.List(Of AdvantageFramework.Database.Classes.ScheduleHeaderComplex)

            'objects
            Dim SqlParameterUserCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterPhaseID As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterRoleCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterTaskCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterEmployeeCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterPendingTasksOnly As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterExcludeProjectedTasks As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterIncludeCompletedTasks As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterIncludeClosedJobs As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterCutOffDate As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterUserCode = New System.Data.SqlClient.SqlParameter("@USER_ID", SqlDbType.VarChar)
            SqlParameterPhaseID = New System.Data.SqlClient.SqlParameter("@PHASE_ID", SqlDbType.Int)
            SqlParameterRoleCode = New System.Data.SqlClient.SqlParameter("@ROLE_CODE", SqlDbType.VarChar)
            SqlParameterTaskCode = New System.Data.SqlClient.SqlParameter("@TASK_CODE", SqlDbType.VarChar)
            SqlParameterEmployeeCode = New System.Data.SqlClient.SqlParameter("@EMP_CODE", SqlDbType.VarChar)
            SqlParameterPendingTasksOnly = New System.Data.SqlClient.SqlParameter("@PENDING_TASKS_ONLY", SqlDbType.Bit)
            SqlParameterExcludeProjectedTasks = New System.Data.SqlClient.SqlParameter("@EXCLUDE_PROJECTED_TASKS", SqlDbType.Bit)
            SqlParameterIncludeCompletedTasks = New System.Data.SqlClient.SqlParameter("@INCLUDE_COMPLETED_TASKS", SqlDbType.Bit)
            SqlParameterIncludeClosedJobs = New System.Data.SqlClient.SqlParameter("@INCLUDE_CLOSED_JOBS", SqlDbType.Bit)
            SqlParameterCutOffDate = New System.Data.SqlClient.SqlParameter("@CUT_OFF_DATE", SqlDbType.SmallDateTime)

            SqlParameterUserCode.Value = UserCode


            If PhaseID.HasValue Then

                SqlParameterPhaseID.Value = PhaseID

            End If

            If String.IsNullOrEmpty(RoleCode) = False Then

                SqlParameterRoleCode.Value = RoleCode

            End If

            If String.IsNullOrEmpty(TaskCode) = False Then

                SqlParameterTaskCode.Value = TaskCode

            End If

            If String.IsNullOrEmpty(EmployeeCode) = False Then

                SqlParameterEmployeeCode.Value = EmployeeCode

            End If

            SqlParameterPendingTasksOnly.Value = PendingTasksOnly

            SqlParameterExcludeProjectedTasks.Value = ExcludeProjectedTasks

            SqlParameterIncludeCompletedTasks.Value = IncludeCompletedTasks

            SqlParameterIncludeClosedJobs.Value = IncludeClosedJobs

            If CutOffDate.HasValue Then

                SqlParameterCutOffDate.Value = CutOffDate

            End If

            Try

                Load = DbContext.Database.SqlQuery(Of AdvantageFramework.Database.Classes.ScheduleHeaderComplex)("EXEC dbo.advsp_Traffic_Schedule_GetHeaders @USER_ID, @PHASE_ID, @ROLE_CODE, @TASK_CODE, @EMP_CODE, @PENDING_TASKS_ONLY, @EXCLUDE_PROJECTED_TASKS, @INCLUDE_COMPLETED_TASKS, @INCLUDE_CLOSED_JOBS, @CUT_OFF_DATE",
                    SqlParameterUserCode, SqlParameterPhaseID, SqlParameterRoleCode, SqlParameterTaskCode, SqlParameterEmployeeCode,
                    SqlParameterPendingTasksOnly, SqlParameterExcludeProjectedTasks, SqlParameterIncludeCompletedTasks,
                    SqlParameterIncludeClosedJobs, SqlParameterCutOffDate).ToList

            Catch ex As Exception
                Load = Nothing
            End Try

        End Function

    End Module

End Namespace


