Namespace Database.Procedures.AlertAssignmentTemplateRole

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

        'Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AlertAssignmentTemplateRole)

        '    Load = From AlertAssignmentTemplateRole In DbContext.GetQuery(Of Database.Entities.AlertAssignmentTemplateRole)  _
        '           Select AlertAssignmentTemplateRole

        'End Function
        Public Function LoadByAlertAssignmentTemplateIDAndAlertStateID(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                                       ByVal AlertAssignmentTemplateID As Integer,
                                                                       ByVal AlertStateID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.AlertAssignmentTemplateRole)

            LoadByAlertAssignmentTemplateIDAndAlertStateID = From AlertAssignmentTemplateRole In DbContext.GetQuery(Of Database.Entities.AlertAssignmentTemplateRole)
                                                             Where AlertAssignmentTemplateRole.AlertAssignmentTemplateID = AlertAssignmentTemplateID AndAlso
                                                                   AlertAssignmentTemplateRole.AlertStateID = AlertStateID
                                                             Select AlertAssignmentTemplateRole

        End Function
        Public Function LoadByAlertAssignmentTemplateIDAndAlertStateIDAndRoleCode(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                                                  ByVal AlertAssignmentTemplateID As Integer,
                                                                                  ByVal AlertStateID As Integer,
                                                                                  ByVal RoleCode As String) As AdvantageFramework.Database.Entities.AlertAssignmentTemplateRole

            LoadByAlertAssignmentTemplateIDAndAlertStateIDAndRoleCode = From AlertAssignmentTemplateRole In DbContext.GetQuery(Of Database.Entities.AlertAssignmentTemplateRole)
                                                                        Where AlertAssignmentTemplateRole.AlertAssignmentTemplateID = AlertAssignmentTemplateID AndAlso
                                                                              AlertAssignmentTemplateRole.AlertStateID = AlertStateID AndAlso
                                                                              AlertAssignmentTemplateRole.RoleCode = RoleCode
                                                                        Select AlertAssignmentTemplateRole

        End Function

        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, _
                               ByVal AlertAssignmentTemplateRole As AdvantageFramework.Database.Entities.AlertAssignmentTemplateRole) As Boolean
            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If AlertAssignmentTemplateRole.IsEntityBeingAdded() = True Then

                    DbContext.AlertAssignmentTemplateRoles.Add(AlertAssignmentTemplateRole)
                    ErrorText = AlertAssignmentTemplateRole.ValidateEntity(IsValid)

                    If IsValid Then

                        DbContext.SaveChanges()
                        Inserted = True

                    Else

                        AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                    End If

                End If

            Catch ex As Exception

                Inserted = False

            Finally

                Insert = Inserted

            End Try

        End Function
        Public Function InsertList(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                   ByVal AlertAssignmentTemplateRolesList As Collections.Generic.List(Of AdvantageFramework.Database.Entities.AlertAssignmentTemplateRole)) As Boolean
            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try
                For Each item As AdvantageFramework.Database.Entities.AlertAssignmentTemplateRole In AlertAssignmentTemplateRolesList

                    If item.IsEntityBeingAdded() = True Then

                        DbContext.AlertAssignmentTemplateRoles.Add(item)

                        If IsValid = True Then 'Make sure that if one item sets it to false, the next item doesn't set it back to true

                            ErrorText = item.ValidateEntity(IsValid)

                        End If

                    End If

                Next

                If IsValid Then

                    DbContext.SaveChanges()
                    Inserted = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception

                Inserted = False

            Finally

                InsertList = Inserted

            End Try

        End Function

        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, _
                               ByVal AlertAssignmentTemplateRole As AdvantageFramework.Database.Entities.AlertAssignmentTemplateRole) As Boolean

            'objects
            Dim Deleted As Boolean = True
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(AlertAssignmentTemplateRole)

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


                DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.ALERT_NOTIFY_ROLE WITH(ROWLOCK) WHERE ALRT_NOTIFY_HDR_ID = {0} AND ALERT_STATE_ID = {1}", AlertAssignmentTemplateID, AlertStateID))

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
