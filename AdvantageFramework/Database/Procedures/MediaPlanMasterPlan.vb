Namespace Database.Procedures.MediaPlanMasterPlan

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

        Public Function LoadByMediaPlanMasterPlanID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaPlanMasterPlanID As Integer) As AdvantageFramework.Database.Entities.MediaPlanMasterPlan

            Try

                LoadByMediaPlanMasterPlanID = (From MediaPlanMasterPlan In DbContext.GetQuery(Of Database.Entities.MediaPlanMasterPlan)
                                               Where MediaPlanMasterPlan.ID = MediaPlanMasterPlanID
                                               Select MediaPlanMasterPlan).SingleOrDefault

            Catch ex As Exception
                LoadByMediaPlanMasterPlanID = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaPlanMasterPlan)

            Load = From MediaPlanMasterPlan In DbContext.GetQuery(Of Database.Entities.MediaPlanMasterPlan)
                   Select MediaPlanMasterPlan

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaPlanMasterPlan As AdvantageFramework.Database.Entities.MediaPlanMasterPlan) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.MediaPlanMasterPlans.Add(MediaPlanMasterPlan)

                ErrorText = MediaPlanMasterPlan.ValidateEntity(IsValid)

                If IsValid Then

                    MediaPlanMasterPlan.CreatedByUserCode = DbContext.UserCode
                    MediaPlanMasterPlan.CreatedDate = Now

                    DbContext.MediaPlanMasterPlans.Add(MediaPlanMasterPlan)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaPlanMasterPlan As AdvantageFramework.Database.Entities.MediaPlanMasterPlan) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(MediaPlanMasterPlan)

                ErrorText = MediaPlanMasterPlan.ValidateEntity(IsValid)

                If IsValid Then

                    MediaPlanMasterPlan.ModifiedByUserCode = DbContext.UserCode
                    MediaPlanMasterPlan.ModifiedDate = Now

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaPlanMasterPlan As AdvantageFramework.Database.Entities.MediaPlanMasterPlan) As Boolean

            'objects
            Dim Deleted As Boolean = False

            Try

                Deleted = DeleteByMediaPlanMasterPlanID(DbContext, MediaPlanMasterPlan.ID)
                
            Catch ex As Exception
                Deleted = False
            Finally
                Delete = Deleted
            End Try

        End Function
        Public Function DeleteByMediaPlanMasterPlanID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaPlanMasterPlanID As Integer) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If AdvantageFramework.Database.Procedures.MediaPlanMasterPlanDetail.DeleteByMediaPlanMasterPlanID(DbContext, MediaPlanMasterPlanID) Then

                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.MEDIA_PLAN_MASTER_PLAN WHERE MEDIA_PLAN_MASTER_PLAN_ID = {0}", MediaPlanMasterPlanID))

                    Deleted = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox("Failed deleting master plan. Please contact Software support.")

                End If

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteByMediaPlanMasterPlanID = Deleted
            End Try

        End Function

#End Region

	End Module

End Namespace
