Namespace Database.Procedures.SprintDetail

    <HideModuleName()>
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

        'Public Function LoadByJobComponentAndBoardID(ByVal DbContext As AdvantageFramework.Database.DbContext,
        '                                            ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal BoardID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.SprintDetail)

        '    LoadByJobComponentAndBoardID = From SprintDetail In DbContext.GetQuery(Of Database.Entities.SprintDetail).Include("SprintDetailEmployees")
        '                                   Where SprintDetail.JobNumber = JobNumber And SprintDetail.JobComponentNumber = JobComponentNumber And SprintDetail.BoardID = BoardID
        '                                   Select SprintDetail

        'End Function

        Public Function CheckForExistingEmployee(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                 ByVal SprintHeaderID As Integer, ByVal TaskSequenceNumber As Short, ByVal EmployeeCode As String) As AdvantageFramework.Database.Entities.SprintDetail

            'CheckForExistingEmployee = (From SprintDetail In DbContext.GetQuery(Of Database.Entities.SprintDetail).Include("SprintDetailEmployees")
            '                            Where SprintDetail.SprintHeaderID = SprintHeaderID And
            '                                  SprintDetail.TaskSequenceNumber = TaskSequenceNumber And
            '                                  SprintDetail.EmployeeCode = EmployeeCode
            '                            Select SprintDetail).SingleOrDefault
            Return Nothing
        End Function
        'Public Function LoadBySprintHeaderAndAlertID(ByVal DbContext As AdvantageFramework.Database.DbContext,
        '                                             ByVal SprintHeaderID As Integer,
        '                                             ByVal AlertID As Integer) As AdvantageFramework.Database.Entities.SprintDetail


        'End Function
        Public Function LoadBySprintIDAlertID(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                              ByVal SprintID As Integer,
                                              ByVal AlertID As Integer) As AdvantageFramework.Database.Entities.SprintDetail

            LoadBySprintIDAlertID = (From SprintDetail In DbContext.GetQuery(Of Database.Entities.SprintDetail)
                                     Where SprintDetail.AlertID = AlertID And SprintDetail.SprintHeaderID = SprintID
                                     Select SprintDetail).SingleOrDefault

        End Function
        Public Function LoadByAlertID(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                             ByVal AlertID As Integer) As AdvantageFramework.Database.Entities.SprintDetail

            LoadByAlertID = (From SprintDetail In DbContext.GetQuery(Of Database.Entities.SprintDetail)
                             Where SprintDetail.AlertID = AlertID
                             Select SprintDetail).SingleOrDefault

        End Function
        Public Function LoadBySprintDetailID(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                             ByVal SprintDetailID As Integer) As AdvantageFramework.Database.Entities.SprintDetail

            LoadBySprintDetailID = (From SprintDetail In DbContext.GetQuery(Of Database.Entities.SprintDetail).Include("SprintDetailEmployees")
                                    Where SprintDetail.ID = SprintDetailID
                                    Select SprintDetail).SingleOrDefault

        End Function
        Public Function LoadAllForEmployee(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                           ByVal EmployeeCode As String) As System.Collections.Generic.List(Of AdvantageFramework.Database.Entities.SprintDetail)

            LoadAllForEmployee = DbContext.Database.SqlQuery(Of AdvantageFramework.Database.Entities.SprintDetail)(String.Format("EXEC [dbo].[advsp_agile_get_sprint_details] NULL, '{0}', 0;", EmployeeCode)).ToList

        End Function
        Public Function LoadWithAvailableBySprintID(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                    ByVal SprintID As Integer) As System.Collections.Generic.List(Of AdvantageFramework.Database.Entities.SprintDetail)

            LoadWithAvailableBySprintID = DbContext.Database.SqlQuery(Of AdvantageFramework.Database.Entities.SprintDetail)(String.Format("EXEC [dbo].[advsp_agile_get_sprint_details] {0}, NULL, 0;", SprintID)).ToList

        End Function

        Public Function LoadBySprintID(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                       ByVal SprintID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.SprintDetail)

            LoadBySprintID = From SprintDetail In DbContext.GetQuery(Of Database.Entities.SprintDetail).Include("SprintDetailEmployees")
                             Where SprintDetail.SprintHeaderID = SprintID
                             Select SprintDetail

        End Function

        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SprintDetail As AdvantageFramework.Database.Entities.SprintDetail) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                Try

                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM SPRINT_DTL WITH(ROWLOCK) WHERE ALERT_ID = {0};", SprintDetail.AlertID))

                Catch ex As Exception
                End Try

                DbContext.SprintDetails.Add(SprintDetail)

                ErrorText = SprintDetail.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    Inserted = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SprintDetail As AdvantageFramework.Database.Entities.SprintDetail) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(SprintDetail)

                ErrorText = SprintDetail.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    Updated = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Updated = False
            Finally
                Update = Updated
            End Try

        End Function
        Public Function DeleteSprintDetailByAlertID(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                    ByVal AlertID As Integer) As Boolean

            Dim Deleted As Boolean = False

            Try

                DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM SPRINT_EMPLOYEE WHERE SPRINT_DTL_ID IN (SELECT ID FROM SPRINT_DTL WHERE ALERT_ID = {0});DELETE FROM SPRINT_DTL WHERE ALERT_ID = {0};", AlertID))

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteSprintDetailByAlertID = Deleted
            End Try

        End Function

        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext,
                               ByVal SprintDetail As AdvantageFramework.Database.Entities.SprintDetail) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If SprintDetail IsNot Nothing Then

                    Try

                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM SPRINT_EMPLOYEE WHERE SPRINT_DTL_ID = {0}", SprintDetail.ID))

                    Catch ex As Exception
                        IsValid = False
                    End Try

                    If IsValid Then

                        DbContext.DeleteEntityObject(SprintDetail)
                        DbContext.SaveChanges()

                        Deleted = True

                    Else

                        AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                    End If

                Else

                    IsValid = True

                End If

            Catch ex As Exception
                Deleted = False
            Finally
                Delete = Deleted
            End Try

        End Function

#End Region

    End Module

End Namespace
