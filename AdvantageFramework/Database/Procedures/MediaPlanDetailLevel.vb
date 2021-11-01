Namespace Database.Procedures.MediaPlanDetailLevel

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

        Public Function LoadByMediaPlanDetailLevelID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaPlanDetailLevelID As Integer) As AdvantageFramework.Database.Entities.MediaPlanDetailLevel

            Try

                LoadByMediaPlanDetailLevelID = (From MediaPlanDetailLevel In DbContext.GetQuery(Of Database.Entities.MediaPlanDetailLevel)
                                                Where MediaPlanDetailLevel.ID = MediaPlanDetailLevelID
                                                Select MediaPlanDetailLevel).SingleOrDefault

            Catch ex As Exception
                LoadByMediaPlanDetailLevelID = Nothing
            End Try

        End Function
        Public Function LoadByMediaPlanDetailID(ByVal DbContext As Database.DbContext, ByVal MediaPlanDetailID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaPlanDetailLevel)

            LoadByMediaPlanDetailID = From MediaPlanDetailLevel In DbContext.GetQuery(Of Database.Entities.MediaPlanDetailLevel)
                                      Where MediaPlanDetailLevel.MediaPlanDetailID = MediaPlanDetailID
                                      Select MediaPlanDetailLevel

        End Function
        Public Function LoadByMediaPlanID(ByVal DbContext As Database.DbContext, ByVal MediaPlanID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaPlanDetailLevel)

            LoadByMediaPlanID = From MediaPlanDetailLevel In DbContext.GetQuery(Of Database.Entities.MediaPlanDetailLevel)
                                Where MediaPlanDetailLevel.MediaPlanID = MediaPlanID
                                Select MediaPlanDetailLevel

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaPlanDetailLevel)

            Load = From MediaPlanDetailLevel In DbContext.GetQuery(Of Database.Entities.MediaPlanDetailLevel)
                   Select MediaPlanDetailLevel

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaPlanDetailLevel As AdvantageFramework.Database.Entities.MediaPlanDetailLevel) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.MediaPlanDetailLevels.Add(MediaPlanDetailLevel)

                ErrorText = MediaPlanDetailLevel.ValidateEntity(IsValid)

                If IsValid Then

                    MediaPlanDetailLevel.CreatedByUserCode = DbContext.UserCode
                    MediaPlanDetailLevel.CreatedDate = Now

                    DbContext.MediaPlanDetailLevels.Add(MediaPlanDetailLevel)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaPlanDetailLevel As AdvantageFramework.Database.Entities.MediaPlanDetailLevel) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(MediaPlanDetailLevel)

                ErrorText = MediaPlanDetailLevel.ValidateEntity(IsValid)

                If IsValid Then

                    MediaPlanDetailLevel.ModifiedByUserCode = DbContext.UserCode
                    MediaPlanDetailLevel.ModifiedDate = Now

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaPlanDetailLevel As AdvantageFramework.Database.Entities.MediaPlanDetailLevel) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If AdvantageFramework.Database.Procedures.MediaPlanDetailLevelLine.DeleteByMediaPlanDetailLevelID(DbContext, MediaPlanDetailLevel.ID) Then

                    DbContext.DeleteEntityObject(MediaPlanDetailLevel)

                    DbContext.SaveChanges()

                    Deleted = True

                Else

                    ErrorText = "Failed deleting media plan detail level."

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Deleted = False
            Finally
                Delete = Deleted
            End Try

        End Function
        Public Function DeleteByMediaPlanDetailID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaPlanDetailID As Integer) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If AdvantageFramework.Database.Procedures.MediaPlanDetailLevelLine.DeleteByMediaPlanDetailID(DbContext, MediaPlanDetailID) Then

                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.MEDIA_PLAN_DTL_LEVEL WHERE MEDIA_PLAN_DTL_ID = {0}", MediaPlanDetailID))

                    Deleted = True

                End If

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteByMediaPlanDetailID = Deleted
            End Try

        End Function

#End Region

    End Module

End Namespace
