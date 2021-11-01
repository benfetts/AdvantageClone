Namespace Database.Procedures.MediaPlanDetail

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

        Public Function LoadByMediaPlanID(ByVal DbContext As Database.DbContext, ByVal MediaPlanID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaPlanDetail)

            LoadByMediaPlanID = From MediaPlanDetail In DbContext.GetQuery(Of Database.Entities.MediaPlanDetail)
                                Where MediaPlanDetail.MediaPlanID = MediaPlanID
                                Select MediaPlanDetail

        End Function
        Public Function LoadByMediaPlanDetailID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaPlanDetailID As Integer, Optional ByVal IncludeLevelLineData As Boolean = False) As AdvantageFramework.Database.Entities.MediaPlanDetail

            If IncludeLevelLineData Then

                Try

                    LoadByMediaPlanDetailID = (From MediaPlanDetail In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.MediaPlanDetail).Include("MediaPlanDetailLevelLineDatas").Include("MediaPlanDetailLevelLines").Include("MediaPlanDetailLevels")
                                               Where MediaPlanDetail.ID = MediaPlanDetailID
                                               Select MediaPlanDetail).SingleOrDefault

                Catch ex As Exception
                    LoadByMediaPlanDetailID = Nothing
                End Try

            Else

                Try

                    LoadByMediaPlanDetailID = (From MediaPlanDetail In DbContext.GetQuery(Of Database.Entities.MediaPlanDetail)
                                               Where MediaPlanDetail.ID = MediaPlanDetailID
                                               Select MediaPlanDetail).SingleOrDefault

                Catch ex As Exception
                    LoadByMediaPlanDetailID = Nothing
                End Try

            End If

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaPlanDetail)

            Load = From MediaPlanDetail In DbContext.GetQuery(Of Database.Entities.MediaPlanDetail)
                   Select MediaPlanDetail

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaPlanDetail As AdvantageFramework.Database.Entities.MediaPlanDetail) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.MediaPlanDetails.Add(MediaPlanDetail)

                ErrorText = MediaPlanDetail.ValidateEntity(IsValid)

                If IsValid Then

                    MediaPlanDetail.CreatedByUserCode = DbContext.UserCode
                    MediaPlanDetail.CreatedDate = Now

                    DbContext.MediaPlanDetails.Add(MediaPlanDetail)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaPlanDetail As AdvantageFramework.Database.Entities.MediaPlanDetail) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(MediaPlanDetail)

                ErrorText = MediaPlanDetail.ValidateEntity(IsValid)

                If IsValid Then

                    MediaPlanDetail.ModifiedByUserCode = DbContext.UserCode
                    MediaPlanDetail.ModifiedDate = Now

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaPlanDetail As AdvantageFramework.Database.Entities.MediaPlanDetail) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = False
            Dim ErrorText As String = ""

            Try

                If AdvantageFramework.Database.Procedures.MediaPlanDetailLevel.DeleteByMediaPlanDetailID(DbContext, MediaPlanDetail.ID) Then

                    If AdvantageFramework.Database.Procedures.MediaPlanDetailField.DeleteByMediaPlanDetailID(DbContext, MediaPlanDetail.ID) Then

                        If AdvantageFramework.Database.Procedures.MediaPlanDetailLevelLineData.DeleteByMediaPlanDetailID(DbContext, MediaPlanDetail.ID) Then

                            If AdvantageFramework.Database.Procedures.MediaPlanDetailSetting.DeleteByMediaPlanDetailID(DbContext, MediaPlanDetail.ID) Then

                                If AdvantageFramework.Database.Procedures.MediaPlanDetailChangeLog.DeleteByMediaPlanDetailID(DbContext, MediaPlanDetail.ID) Then

                                    IsValid = True

                                Else

                                    ErrorText = "Failed deleting media plan detail. Please contact Software support."

                                End If

                            Else

                                ErrorText = "Failed deleting media plan detail. Please contact Software support."

                            End If

                        Else

                            ErrorText = "Failed deleting media plan detail. Please contact Software support."

                        End If

                    Else

                        ErrorText = "Failed deleting media plan detail. Please contact Software support."

                    End If

                Else

                    ErrorText = "Failed deleting media plan detail. Please contact Software support."

                End If

                If IsValid Then

                    DbContext.DeleteEntityObject(MediaPlanDetail)

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

#End Region

    End Module

End Namespace
