Imports Newtonsoft.Json
Imports System.Collections.Generic
Imports System.Web.Mvc
Imports Webvantage.ViewModels
Imports Kendo.Mvc.Extensions
Imports MvcCodeRouting.Web.Mvc
Imports Webvantage.Controllers

Namespace Controllers.ProjectManagement

    <Serializable()>
    Public Class TaskController
        Inherits MVCControllerBase

#Region " Constants "

        Public Const BaseRoute As String = "ProjectManagement/Task/"

#End Region

#Region " Views "

        <AuthorizationFilter(SecurityModuleCode:="ProjectManagement_ProjectSchedule")>
        Public Function Index(<FromRoute()> ByVal JobNumber As Integer, <FromRoute()> ByVal JobComponentNumber As Short, <FromRoute()> ByVal TaskSequenceNumber As Short) As ActionResult

            Return View()

        End Function
        <AuthorizationFilter(SecurityModuleCode:="ProjectManagement_ProjectSchedule")>
        Public Function Employees(<FromRoute()> ByVal JobNumber As Integer, <FromRoute()> ByVal JobComponentNumber As Short, <FromRoute()> ByVal TaskSequenceNumber As Short) As ActionResult

            Dim TaskEmployeesEmployeesViewModel As New ViewModels.EmployeesViewModel

            TaskEmployeesEmployeesViewModel.List = Nothing

            Try

                Using DbContext As New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                    Dim SqlParameterUserCode As New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar, 10)
                    Dim SqlParameterEmployeeCode As New System.Data.SqlClient.SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
                    Dim SqlParameterDepartmentTeamCode As New System.Data.SqlClient.SqlParameter("@DP_TM_CODE", SqlDbType.VarChar, 6)
                    Dim SqlParameterEmailGroupCode As New System.Data.SqlClient.SqlParameter("@EMAIL_GR_CODE", SqlDbType.VarChar, 50)
                    Dim SqlParameterJobNumber As New System.Data.SqlClient.SqlParameter("@JOB_NUMBER", SqlDbType.Int)
                    Dim SqlParameterJobComponentNumber As New System.Data.SqlClient.SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
                    Dim SqlParameterTaskSequenceNumber As New System.Data.SqlClient.SqlParameter("@SEQ_NBR", SqlDbType.SmallInt)
                    Dim SqlParameterIsLookingUpAccountExecutive As New System.Data.SqlClient.SqlParameter("@IS_AE", SqlDbType.Bit)
                    Dim SqlParameterFilterByTaskRoles As New System.Data.SqlClient.SqlParameter("@IS_ROLE", SqlDbType.Bit)
                    Dim SqlParameterFilterByJobEmailGroup As New System.Data.SqlClient.SqlParameter("@IS_EMAIL_GROUP", SqlDbType.Bit)
                    Dim SqlParameterOnlyShowActive As New System.Data.SqlClient.SqlParameter("@ONLY_ACTIVE", SqlDbType.Bit)
                    Dim EmployeeCode As String = String.Empty
                    Dim DepartmentTeamCode As String = String.Empty
                    Dim EmailGroupCode As String = String.Empty
                    Dim IsLookingUpAccountExecutive As Boolean = False
                    Dim FilterByTaskRoles As Boolean = False
                    Dim FilterByJobEmailGroup As Boolean = False
                    Dim OnlyShowActive As Boolean = False

                    SqlParameterUserCode.Value = SecuritySession.UserCode

                    If String.IsNullOrWhiteSpace(EmployeeCode) = True Then

                        SqlParameterEmployeeCode.Value = System.DBNull.Value

                    Else

                        SqlParameterEmployeeCode.Value = EmployeeCode

                    End If
                    If String.IsNullOrWhiteSpace(DepartmentTeamCode) = True Then

                        SqlParameterDepartmentTeamCode.Value = System.DBNull.Value

                    Else

                        SqlParameterDepartmentTeamCode.Value = DepartmentTeamCode

                    End If
                    If String.IsNullOrWhiteSpace(EmailGroupCode) = True Then

                        SqlParameterEmailGroupCode.Value = System.DBNull.Value

                    Else

                        SqlParameterEmailGroupCode.Value = EmailGroupCode

                    End If
                    If JobNumber = 0 Then

                        SqlParameterJobNumber.Value = System.DBNull.Value

                    Else

                        SqlParameterJobNumber.Value = JobNumber

                    End If
                    If JobComponentNumber = 0 Then

                        SqlParameterJobComponentNumber.Value = System.DBNull.Value

                    Else

                        SqlParameterJobComponentNumber.Value = JobComponentNumber

                    End If
                    If TaskSequenceNumber = -1 Then

                        SqlParameterTaskSequenceNumber.Value = System.DBNull.Value

                    Else

                        SqlParameterTaskSequenceNumber.Value = TaskSequenceNumber

                    End If

                    SqlParameterIsLookingUpAccountExecutive.Value = IsLookingUpAccountExecutive
                    SqlParameterFilterByTaskRoles.Value = FilterByTaskRoles
                    SqlParameterFilterByJobEmailGroup.Value = FilterByJobEmailGroup
                    SqlParameterOnlyShowActive.Value = OnlyShowActive

                    TaskEmployeesEmployeesViewModel.List = DbContext.Database.SqlQuery(Of AdvantageFramework.Database.Entities.EmployeeSimple)("EXEC advsp_load_employee_simple @USER_CODE, @EMP_CODE, @DP_TM_CODE, @EMAIL_GR_CODE, @JOB_NUMBER, @JOB_COMPONENT_NBR, @SEQ_NBR, @IS_AE, @IS_ROLE, @IS_EMAIL_GROUP, @ONLY_ACTIVE",
                                                                                                                       SqlParameterUserCode,
                                                                                                                       SqlParameterEmployeeCode,
                                                                                                                       SqlParameterDepartmentTeamCode,
                                                                                                                       SqlParameterEmailGroupCode,
                                                                                                                       SqlParameterJobNumber,
                                                                                                                       SqlParameterJobComponentNumber,
                                                                                                                       SqlParameterTaskSequenceNumber,
                                                                                                                       SqlParameterIsLookingUpAccountExecutive,
                                                                                                                       SqlParameterFilterByTaskRoles,
                                                                                                                       SqlParameterFilterByJobEmailGroup,
                                                                                                                       SqlParameterOnlyShowActive).ToList

                    If TaskEmployeesEmployeesViewModel.List IsNot Nothing Then

                        Dim TaskEmployees As Generic.List(Of AdvantageFramework.Database.Entities.JobComponentTaskEmployee) = Nothing

                        TaskEmployees = AdvantageFramework.Database.Procedures.JobComponentTaskEmployee.LoadByJobCompSeq(DbContext,
                                                                                                                         JobNumber,
                                                                                                                         JobComponentNumber,
                                                                                                                         TaskSequenceNumber).ToList()

                        If TaskEmployees IsNot Nothing Then

                            Dim SelectedEmployee As AdvantageFramework.Database.Entities.EmployeeSimple = Nothing

                            For Each TaskEmployee As AdvantageFramework.Database.Entities.JobComponentTaskEmployee In TaskEmployees

                                SelectedEmployee = Nothing

                                Try

                                    SelectedEmployee = TaskEmployeesEmployeesViewModel.List.Find(Function(x) x.Code = TaskEmployee.EmployeeCode)

                                Catch ex As Exception
                                    SelectedEmployee = Nothing
                                End Try

                                If SelectedEmployee IsNot Nothing Then SelectedEmployee.Selected = True

                            Next

                        End If

                    End If

                End Using

            Catch ex As Exception
                TaskEmployeesEmployeesViewModel.List = Nothing
            End Try

            If TaskEmployeesEmployeesViewModel.List Is Nothing Then TaskEmployeesEmployeesViewModel.List = New List(Of AdvantageFramework.Database.Entities.EmployeeSimple)

            Return View(TaskEmployeesEmployeesViewModel)

        End Function
        <AuthorizationFilter(SecurityModuleCode:="ProjectManagement_ProjectSchedule")>
        Public Function Employee(<FromRoute()> ByVal JobNumber As Integer, <FromRoute()> ByVal JobComponentNumber As Short, <FromRoute()> ByVal TaskSequenceNumber As Short,
                                 <FromRoute()> ByVal EmployeeCode As String) As ActionResult

            Return View()

        End Function


#Region " -- Partials -- "

        <AuthorizationFilter(SecurityModuleCode:="ProjectManagement_ProjectSchedule")>
        Public Function _Employees() As ActionResult

            Return PartialView()

        End Function
        <AuthorizationFilter(SecurityModuleCode:="ProjectManagement_ProjectSchedule")>
        Public Function _Employee() As ActionResult

            Return PartialView()

        End Function

#End Region

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace
