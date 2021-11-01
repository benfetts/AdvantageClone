Namespace Database.Procedures.WorkflowAlertState

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.WorkflowAlertState)

            Try

                Load = From WorkflowAlertState In DbContext.GetQuery(Of Database.Entities.WorkflowAlertState)
                       Join AlertAssignmentTemplateState In AlertAssignmentTemplateState.Load(DbContext)
                       On WorkflowAlertState.AlertAssignmentTemplateID Equals AlertAssignmentTemplateState.AlertAssignmentTemplateID _
                       And WorkflowAlertState.EndAlertStateID Equals AlertAssignmentTemplateState.AlertStateID
                       Order By WorkflowAlertState.Workflow.Name, WorkflowAlertState.AlertAssignmentTemplate.Name, AlertAssignmentTemplateState.SortOrder
                       Select WorkflowAlertState

            Catch ex As Exception

                Return Nothing

            End Try

        End Function
        Public Function LoadByID(ByVal DbContext As Database.DbContext,
                                 ByVal ID As Integer) As Database.Entities.WorkflowAlertState

            Try

                LoadByID = (From WorkflowAlertState In DbContext.GetQuery(Of Database.Entities.WorkflowAlertState)
                            Where WorkflowAlertState.ID = ID
                            Select WorkflowAlertState).FirstOrDefault

            Catch ex As Exception

                Return Nothing

            End Try

        End Function
        Public Function LoadByWorkflowIDAndAlertAssignmentTemplateIDAndStateID(ByVal DbContext As Database.DbContext,
                                                                                  ByVal WorkflowID As Integer,
                                                                                  ByVal AlertAssignmentTemplateID As Integer,
                                                                                  ByVal AlertStateID As Nullable(Of Integer)) As Database.Entities.WorkflowAlertState

            Try

                If AlertStateID = 0 OrElse AlertStateID Is Nothing Then

                    LoadByWorkflowIDAndAlertAssignmentTemplateIDAndStateID = (From WorkflowAlertState In DbContext.GetQuery(Of Database.Entities.WorkflowAlertState)
                                                                              Where WorkflowAlertState.WorkflowID = WorkflowID _
                                                                           AndAlso WorkflowAlertState.AlertAssignmentTemplateID = AlertAssignmentTemplateID _
                                                                           AndAlso WorkflowAlertState.AlertStateID.HasValue = False
                                                                              Select WorkflowAlertState).FirstOrDefault

                Else

                    LoadByWorkflowIDAndAlertAssignmentTemplateIDAndStateID = (From WorkflowAlertState In DbContext.GetQuery(Of Database.Entities.WorkflowAlertState)
                                                                              Where WorkflowAlertState.WorkflowID = WorkflowID _
                                                                            AndAlso WorkflowAlertState.AlertAssignmentTemplateID = AlertAssignmentTemplateID _
                                                                            AndAlso WorkflowAlertState.AlertStateID = AlertStateID
                                                                              Select WorkflowAlertState).FirstOrDefault

                End If

            Catch ex As Exception

                Return Nothing

            End Try

        End Function

        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal WorkflowAlertState As AdvantageFramework.Database.Entities.WorkflowAlertState) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.WorkflowAlertStates.Add(WorkflowAlertState)

                ErrorText = WorkflowAlertState.ValidateEntity(IsValid)

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

        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal WorkflowAlertState As AdvantageFramework.Database.Entities.WorkflowAlertState) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(WorkflowAlertState)

                ErrorText = WorkflowAlertState.ValidateEntity(IsValid)

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

        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal WorkflowAlertState As AdvantageFramework.Database.Entities.WorkflowAlertState) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(WorkflowAlertState)
                    DbContext.SaveChanges()

                    Deleted = True

                End If

            Catch ex As Exception
                Deleted = False
            Finally
                Delete = Deleted
            End Try

        End Function
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext,
                               ByVal WorkflowEventID As Integer, ByVal AlertAssignmentTemplateID As Integer, ByVal AlertStateID As Integer) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True

            Try

                If IsValid Then

                    If AlertStateID > 0 Then

                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.WORKFLOW_ALERT_STATE WHERE WORKFLOW_ID = {0} AND ALRT_NOTIFY_HDR_ID = {1} AND ALERT_STATE_ID = {2};",
                                                                        WorkflowEventID, AlertAssignmentTemplateID, AlertStateID))

                    Else

                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.WORKFLOW_ALERT_STATE WHERE WORKFLOW_ID = {0} AND ALRT_NOTIFY_HDR_ID = {1} AND ALERT_STATE_ID IS NULL;",
                                                                        WorkflowEventID, AlertAssignmentTemplateID))

                    End If

                    Deleted = True

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