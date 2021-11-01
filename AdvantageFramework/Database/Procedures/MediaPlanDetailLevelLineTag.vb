Namespace Database.Procedures.MediaPlanDetailLevelLineTag

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

        Public Function LoadByMediaPlanDetailLevelLineTagID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaPlanDetailLevelLineTagID As Integer) As Database.Entities.MediaPlanDetailLevelLineTag

            Try

                LoadByMediaPlanDetailLevelLineTagID = (From MediaPlanDetailLevelLineTag In DbContext.GetQuery(Of Database.Entities.MediaPlanDetailLevelLineTag)
                                                       Where MediaPlanDetailLevelLineTag.ID = MediaPlanDetailLevelLineTagID
                                                       Select MediaPlanDetailLevelLineTag).SingleOrDefault

            Catch ex As Exception
                LoadByMediaPlanDetailLevelLineTagID = Nothing
            End Try

        End Function
        Public Function LoadByMediaPlanDetailLevelLineID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaPlanDetailLevelLineID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaPlanDetailLevelLineTag)

            LoadByMediaPlanDetailLevelLineID = From MediaPlanDetailLevelLineTag In DbContext.GetQuery(Of Database.Entities.MediaPlanDetailLevelLineTag)
                                               Where MediaPlanDetailLevelLineTag.MediaPlanDetailLevelLineID = MediaPlanDetailLevelLineID
                                               Select MediaPlanDetailLevelLineTag

        End Function
        Public Function LoadByMediaPlanDetailID(ByVal DbContext As Database.DbContext, ByVal MediaPlanDetailID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaPlanDetailLevelLineTag)

            LoadByMediaPlanDetailID = From MediaPlanDetailLevelLineTag In DbContext.GetQuery(Of Database.Entities.MediaPlanDetailLevelLineTag)
                                      Where MediaPlanDetailLevelLineTag.MediaPlanDetailID = MediaPlanDetailID
                                      Select MediaPlanDetailLevelLineTag

        End Function
        Public Function LoadByMediaPlanID(ByVal DbContext As Database.DbContext, ByVal MediaPlanID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaPlanDetailLevelLineTag)

            LoadByMediaPlanID = From MediaPlanDetailLevelLineTag In DbContext.GetQuery(Of Database.Entities.MediaPlanDetailLevelLineTag)
                                Where MediaPlanDetailLevelLineTag.MediaPlanID = MediaPlanID
                                Select MediaPlanDetailLevelLineTag

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaPlanDetailLevelLineTag)

            Load = From MediaPlanDetailLevelLineTag In DbContext.GetQuery(Of Database.Entities.MediaPlanDetailLevelLineTag)
                   Select MediaPlanDetailLevelLineTag

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaPlanDetailLevelLineTag As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineTag) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.MediaPlanDetailLevelLineTags.Add(MediaPlanDetailLevelLineTag)

                ErrorText = MediaPlanDetailLevelLineTag.ValidateEntity(IsValid)

                If IsValid Then

                    MediaPlanDetailLevelLineTag.CreatedByUserCode = DbContext.UserCode
                    MediaPlanDetailLevelLineTag.CreatedDate = Now

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaPlanDetailLevelLineTag As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineTag) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(MediaPlanDetailLevelLineTag)

                ErrorText = MediaPlanDetailLevelLineTag.ValidateEntity(IsValid)

                If IsValid Then

                    MediaPlanDetailLevelLineTag.ModifiedByUserCode = DbContext.UserCode
                    MediaPlanDetailLevelLineTag.ModifiedDate = Now

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaPlanDetailLevelLineTag As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineTag) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(MediaPlanDetailLevelLineTag)

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
        Public Function DeleteByMediaPlanDetailLevelLineID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaPlanDetailLevelLineID As Integer) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.MEDIA_PLAN_DTL_LEVEL_LINE_TAG WHERE MEDIA_PLAN_DTL_LEVEL_LINE_ID = {0}", MediaPlanDetailLevelLineID))

                Deleted = True

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteByMediaPlanDetailLevelLineID = Deleted
            End Try

        End Function
        Public Function DeleteByMediaPlanDetailLevelID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaPlanDetailLevelID As Integer) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.MEDIA_PLAN_DTL_LEVEL_LINE_TAG WHERE MEDIA_PLAN_DTL_LEVEL_LINE_ID IN (SELECT MEDIA_PLAN_DTL_LEVEL_LINE_ID FROM dbo.MEDIA_PLAN_DTL_LEVEL_LINE WHERE MEDIA_PLAN_DTL_LEVEL_ID = {0})", MediaPlanDetailLevelID))

                Deleted = True

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteByMediaPlanDetailLevelID = Deleted
            End Try

        End Function
        Public Function DeleteByMediaPlanDetailID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaPlanDetailID As Integer) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.MEDIA_PLAN_DTL_LEVEL_LINE_TAG WHERE MEDIA_PLAN_DTL_ID = {0}", MediaPlanDetailID))

                Deleted = True

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteByMediaPlanDetailID = Deleted
            End Try

        End Function

#End Region

    End Module

End Namespace
