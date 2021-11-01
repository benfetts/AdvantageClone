Namespace Database.Procedures.MediaPlanMasterPlanDetail

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

        Public Function LoadByMediaPlanID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaPlanID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaPlanMasterPlanDetail)

            LoadByMediaPlanID = From MediaPlanMasterPlanDetail In DbContext.GetQuery(Of Database.Entities.MediaPlanMasterPlanDetail)
                                Where MediaPlanMasterPlanDetail.MediaPlanID = MediaPlanID
                                Select MediaPlanMasterPlanDetail

        End Function
        Public Function LoadByMediaPlanMasterPlanID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaPlanMasterPlanID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaPlanMasterPlanDetail)

            LoadByMediaPlanMasterPlanID = From MediaPlanMasterPlanDetail In DbContext.GetQuery(Of Database.Entities.MediaPlanMasterPlanDetail)
                                          Where MediaPlanMasterPlanDetail.MediaPlanMasterPlanID = MediaPlanMasterPlanID
                                          Select MediaPlanMasterPlanDetail

        End Function
        Public Function LoadByMediaPlanMasterPlanDetailID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaPlanMasterPlanDetailID As Integer) As AdvantageFramework.Database.Entities.MediaPlanMasterPlanDetail

            Try

                LoadByMediaPlanMasterPlanDetailID = (From MediaPlanMasterPlanDetail In DbContext.GetQuery(Of Database.Entities.MediaPlanMasterPlanDetail)
                                                     Where MediaPlanMasterPlanDetail.ID = MediaPlanMasterPlanDetailID
                                                     Select MediaPlanMasterPlanDetail).SingleOrDefault

            Catch ex As Exception
                LoadByMediaPlanMasterPlanDetailID = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaPlanMasterPlanDetail)

            Load = From MediaPlanMasterPlanDetail In DbContext.GetQuery(Of Database.Entities.MediaPlanMasterPlanDetail)
                   Select MediaPlanMasterPlanDetail

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaPlanMasterPlanDetail As AdvantageFramework.Database.Entities.MediaPlanMasterPlanDetail) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.MediaPlanMasterPlanDetails.Add(MediaPlanMasterPlanDetail)

                ErrorText = MediaPlanMasterPlanDetail.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.MediaPlanMasterPlanDetails.Add(MediaPlanMasterPlanDetail)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaPlanMasterPlanDetail As AdvantageFramework.Database.Entities.MediaPlanMasterPlanDetail) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(MediaPlanMasterPlanDetail)

                ErrorText = MediaPlanMasterPlanDetail.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaPlanMasterPlanDetail As AdvantageFramework.Database.Entities.MediaPlanMasterPlanDetail) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(MediaPlanMasterPlanDetail)

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
        Public Function DeleteByMediaPlanMasterPlanDetailID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaPlanMasterPlanDetailID As Integer) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.MEDIA_PLAN_MASTER_PLAN_DETAIL WHERE MEDIA_PLAN_MASTER_PLAN_DETAIL_ID = {0}", MediaPlanMasterPlanDetailID))

                Deleted = True

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteByMediaPlanMasterPlanDetailID = Deleted
            End Try

        End Function
        Public Function DeleteByMediaPlanMasterPlanID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaPlanMasterPlanID As Integer) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.MEDIA_PLAN_MASTER_PLAN_DETAIL WHERE MEDIA_PLAN_MASTER_PLAN_ID = {0}", MediaPlanMasterPlanID))

                Deleted = True

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteByMediaPlanMasterPlanID = Deleted
            End Try

        End Function
        Public Function DeleteByMediaPlanID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaPlanID As Integer) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.MEDIA_PLAN_MASTER_PLAN_DETAIL WHERE MEDIA_PLAN_ID = {0}", MediaPlanID))

                Deleted = True

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteByMediaPlanID = Deleted
            End Try

        End Function

#End Region

	End Module

End Namespace
