Namespace Database.Procedures.MediaPlanDetailLevelLineData

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

        Public Function LoadByMediaPlanDetailLevelLineDataID(ByVal DbContext As Database.DbContext, ByVal MediaPlanDetailLevelLineDataID As Integer) As Database.Entities.MediaPlanDetailLevelLineData

            Try

                LoadByMediaPlanDetailLevelLineDataID = (From MediaPlanDetailLevelLineData In DbContext.GetQuery(Of Database.Entities.MediaPlanDetailLevelLineData)
                                                        Where MediaPlanDetailLevelLineData.ID = MediaPlanDetailLevelLineDataID
                                                        Select MediaPlanDetailLevelLineData).SingleOrDefault

            Catch ex As Exception
                LoadByMediaPlanDetailLevelLineDataID = Nothing
            End Try

        End Function
        Public Function LoadByMediaPlanDetailIDAndRowIndex(ByVal DbContext As Database.DbContext, ByVal MediaPlanDetailID As Integer, ByVal RowIndex As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaPlanDetailLevelLineData)

            LoadByMediaPlanDetailIDAndRowIndex = From MediaPlanDetailLevelLineData In DbContext.GetQuery(Of Database.Entities.MediaPlanDetailLevelLineData)
                                                 Where MediaPlanDetailLevelLineData.MediaPlanDetailID = MediaPlanDetailID AndAlso
                                                       MediaPlanDetailLevelLineData.RowIndex = RowIndex
                                                 Select MediaPlanDetailLevelLineData

        End Function
        Public Function LoadByMediaPlanDetailID(ByVal DbContext As Database.DbContext, ByVal MediaPlanDetailID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaPlanDetailLevelLineData)

            LoadByMediaPlanDetailID = From MediaPlanDetailLevelLineData In DbContext.GetQuery(Of Database.Entities.MediaPlanDetailLevelLineData)
                                      Where MediaPlanDetailLevelLineData.MediaPlanDetailID = MediaPlanDetailID
                                      Select MediaPlanDetailLevelLineData

        End Function
        Public Function LoadByMediaPlanID(ByVal DbContext As Database.DbContext, ByVal MediaPlanID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaPlanDetailLevelLineData)

            LoadByMediaPlanID = From MediaPlanDetailLevelLineData In DbContext.GetQuery(Of Database.Entities.MediaPlanDetailLevelLineData)
                                Where MediaPlanDetailLevelLineData.MediaPlanID = MediaPlanID
                                Select MediaPlanDetailLevelLineData

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaPlanDetailLevelLineData)

            Load = From MediaPlanDetailLevelLineData In DbContext.GetQuery(Of Database.Entities.MediaPlanDetailLevelLineData)
                   Select MediaPlanDetailLevelLineData

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaPlanDetailLevelLineData As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.MediaPlanDetailLevelLineDatas.Add(MediaPlanDetailLevelLineData)

                ErrorText = MediaPlanDetailLevelLineData.ValidateEntity(IsValid)

                If IsValid Then

                    MediaPlanDetailLevelLineData.CreatedByUserCode = DbContext.UserCode
                    MediaPlanDetailLevelLineData.CreatedDate = Now

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaPlanDetailLevelLineData As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(MediaPlanDetailLevelLineData)

                ErrorText = MediaPlanDetailLevelLineData.ValidateEntity(IsValid)

                If IsValid Then

                    MediaPlanDetailLevelLineData.ModifiedByUserCode = DbContext.UserCode
                    MediaPlanDetailLevelLineData.ModifiedDate = Now

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
        Public Function UpdateRowIndexOnly(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaPlanDetailID As Integer, ByVal NewRowIndex As Integer, ByVal OldRowIndex As Integer) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.MEDIA_PLAN_DTL_LEVEL_LINE_DATA SET ROW_INDEX = {0} WHERE ROW_INDEX = {1} AND MEDIA_PLAN_DTL_ID = {2}", NewRowIndex, OldRowIndex, MediaPlanDetailID))

                Updated = True

            Catch ex As Exception
                Updated = False
            Finally
                UpdateRowIndexOnly = Updated
            End Try

        End Function
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaPlanDetailLevelLineData As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(MediaPlanDetailLevelLineData)

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
        Public Function DeleteByMediaPlanDetailID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaPlanDetailID As Integer) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.MEDIA_PLAN_DTL_LEVEL_LINE_DATA WHERE MEDIA_PLAN_DTL_ID = {0}", MediaPlanDetailID))

                Deleted = True

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteByMediaPlanDetailID = Deleted
            End Try

        End Function
        Public Function DeleteByMediaPlanDetailIDAndRowIndex(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaPlanDetailID As Integer, ByVal RowIndex As Integer) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.MEDIA_PLAN_DTL_LEVEL_LINE_DATA WHERE MEDIA_PLAN_DTL_ID = {0} AND ROW_INDEX = {1}", MediaPlanDetailID, RowIndex))

                Deleted = True

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteByMediaPlanDetailIDAndRowIndex = Deleted
            End Try

        End Function

#End Region

    End Module

End Namespace
