Namespace Database.Procedures.AlertAssignmentTemplateEmployee

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

        Public Function LoadByAlertAssignmentTemplateIDAndAlertStateID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertAssignmentTemplateID As Integer, ByVal AlertStateID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.AlertAssignmentTemplateEmployee)

            LoadByAlertAssignmentTemplateIDAndAlertStateID = From AlertAssignmentTemplateEmployee In DbContext.GetQuery(Of Database.Entities.AlertAssignmentTemplateEmployee)
                                                             Where AlertAssignmentTemplateEmployee.AlertAssignmentTemplateID = AlertAssignmentTemplateID AndAlso
                                                                   AlertAssignmentTemplateEmployee.AlertStateID = AlertStateID
                                                             Select AlertAssignmentTemplateEmployee

        End Function
        Public Function LoadByAlertStateID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertStateID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.AlertAssignmentTemplateEmployee)

            LoadByAlertStateID = From AlertAssignmentTemplateEmployee In DbContext.GetQuery(Of Database.Entities.AlertAssignmentTemplateEmployee)
                                 Where AlertAssignmentTemplateEmployee.AlertStateID = AlertStateID
                                 Select AlertAssignmentTemplateEmployee

        End Function
        Public Function LoadByAlertAssignmentTemplateID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertAssignmentTemplateID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.AlertAssignmentTemplateEmployee)

            LoadByAlertAssignmentTemplateID = From AlertAssignmentTemplateEmployee In DbContext.GetQuery(Of Database.Entities.AlertAssignmentTemplateEmployee)
                                              Where AlertAssignmentTemplateEmployee.AlertAssignmentTemplateID = AlertAssignmentTemplateID
                                              Select AlertAssignmentTemplateEmployee

        End Function
        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.AlertAssignmentTemplateEmployee)

            Load = From AlertAssignmentTemplateEmployee In DbContext.GetQuery(Of Database.Entities.AlertAssignmentTemplateEmployee)
                   Select AlertAssignmentTemplateEmployee

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertAssignmentTemplateEmployee As AdvantageFramework.Database.Entities.AlertAssignmentTemplateEmployee) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.AlertAssignmentTemplateEmployees.Add(AlertAssignmentTemplateEmployee)

                ErrorText = AlertAssignmentTemplateEmployee.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertAssignmentTemplateEmployee As AdvantageFramework.Database.Entities.AlertAssignmentTemplateEmployee) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(AlertAssignmentTemplateEmployee)

                ErrorText = AlertAssignmentTemplateEmployee.ValidateEntity(IsValid)

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

        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertAssignmentTemplateEmployee As AdvantageFramework.Database.Entities.AlertAssignmentTemplateEmployee) As Boolean

            'objects
            Dim Deleted As Boolean = True
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(AlertAssignmentTemplateEmployee)

                    DbContext.SaveChanges()

                    Deleted = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Deleted = False
            Finally
                Delete = Deleted
            End Try

        End Function
        Public Function DeleteByAlertAssignmentTemplateIDAndAlertStateID(ByVal DbContext As AdvantageFramework.Database.DbContext, _
                                                         ByVal AlertAssignmentTemplateID As Integer, _
                                                         ByVal AlertStateID As Integer) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try


                DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.ALERT_NOTIFY_EMPS WITH(ROWLOCK) WHERE ALRT_NOTIFY_HDR_ID = {0} AND ALERT_STATE_ID = {1}", AlertAssignmentTemplateID, AlertStateID))

                Deleted = True


            Catch ex As Exception
                Deleted = False
            Finally
                DeleteByAlertAssignmentTemplateIDAndAlertStateID = Deleted
            End Try

        End Function

#End Region

    End Module

End Namespace
