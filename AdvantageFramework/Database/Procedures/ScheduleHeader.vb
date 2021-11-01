Namespace Database.Procedures.ScheduleHeader

    <HideModuleName()> _
    Public Module Methods

        Public Function Load(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal UserID As String, Optional ByVal JobNumber As Integer = 0, Optional ByVal JobComponentNumber As Short = 0,
                             Optional ByVal ClientCode As String = "", Optional ByVal DivisionCode As String = "", Optional ByVal ProductCode As String = "", _
                             Optional ByVal EmployeeCode As String = "", Optional ByVal ManagerCode As String = "", Optional ByVal AccountExecutiveEmployeeCode As String = "", _
                             Optional ByVal TaskCode As String = "", Optional ByVal RoleCode As String = "", Optional ByVal CutOffDate As String = "", _
                             Optional ByVal ShowOnlyOpenSchedules As Boolean = True, Optional ByVal IncludeCompletedTasks As Boolean = False, Optional ByVal IncludeOnlyPendingTasks As Boolean = False, _
                             Optional ByVal ExcludedProjectedTasks As Boolean = False, Optional ByVal CampaignCode As String = "", Optional ByVal IncludeClosedJobs As Boolean = True, _
                             Optional ByVal MilestonesOnly As Boolean = False, Optional ByVal TrafficStatusCode As String = "", Optional ByVal Gantt As Boolean = False, _
                             Optional ByVal OfficeCode As String = "", Optional ByVal SalesClassCode As String = "", _
                             Optional ByRef ScheduleHeaders As IEnumerable(Of AdvantageFramework.Database.Entities.ScheduleHeader) = Nothing, _
                             Optional ByRef ScheduleAssignmentLabels As IEnumerable(Of AdvantageFramework.Database.Entities.ScheduleAssignmentLabel) = Nothing, _
                             Optional ByRef ScheduleManagerColumn As AdvantageFramework.Database.Entities.ScheduleManagerColumn = Nothing) As Boolean

            'objects
            Dim IMultipleResults As System.Data.Linq.IMultipleResults = Nothing
            Dim Loaded As Boolean = False
            Dim CutDate As Object = Nothing

            Try

                If String.IsNullOrEmpty(CutOffDate) = False Then

                    CutDate = CutOffDate

                End If

                IMultipleResults = DataContext.LoadScheduleHeader(JobNumber, JobComponentNumber, UserID, ClientCode, DivisionCode, ProductCode, EmployeeCode, _
                                                                  ManagerCode, AccountExecutiveEmployeeCode, TaskCode, RoleCode, CutDate, If(ShowOnlyOpenSchedules, 1, 0), _
                                                                  If(IncludeCompletedTasks, "Y", "N"), If(IncludeOnlyPendingTasks, "Y", "N"), If(ExcludedProjectedTasks, "Y", "N"), _
                                                                  CampaignCode, IncludeClosedJobs, MilestonesOnly, TrafficStatusCode, Gantt, OfficeCode, SalesClassCode)

            Catch ex As Exception
                IMultipleResults = Nothing
            End Try

            If IMultipleResults IsNot Nothing Then

                Loaded = True

                Try

                    ScheduleHeaders = IMultipleResults.GetResult(Of AdvantageFramework.Database.Entities.ScheduleHeader).ToList

                Catch ex As Exception
                    ScheduleHeaders = Nothing
                End Try

                Try

                    ScheduleAssignmentLabels = IMultipleResults.GetResult(Of AdvantageFramework.Database.Entities.ScheduleAssignmentLabel).ToList

                Catch ex As Exception
                    ScheduleAssignmentLabels = Nothing
                End Try

                Try

                    ScheduleManagerColumn = IMultipleResults.GetResult(Of AdvantageFramework.Database.Entities.ScheduleManagerColumn).SingleOrDefault

                Catch ex As Exception
                    ScheduleManagerColumn = Nothing
                End Try

            End If

            Load = Loaded

        End Function

    End Module

End Namespace