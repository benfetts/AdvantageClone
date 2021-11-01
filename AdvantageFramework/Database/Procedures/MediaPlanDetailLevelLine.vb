Namespace Database.Procedures.MediaPlanDetailLevelLine

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

        Public Function LoadByMediaPlanDetailLevelIDAndRowIndex(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaPlanDetailLevelID As Integer, ByVal RowIndex As Integer) As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine

            Try

                LoadByMediaPlanDetailLevelIDAndRowIndex = (From MediaPlanDetailLevelLine In DbContext.GetQuery(Of Database.Entities.MediaPlanDetailLevelLine)
                                                           Where MediaPlanDetailLevelLine.MediaPlanDetailLevelID = MediaPlanDetailLevelID AndAlso
                                                                 MediaPlanDetailLevelLine.RowIndex = RowIndex
                                                           Select MediaPlanDetailLevelLine).SingleOrDefault

            Catch ex As Exception
                LoadByMediaPlanDetailLevelIDAndRowIndex = Nothing
            End Try

        End Function
        Public Function LoadByMediaPlanDetailLevelLineID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaPlanDetailLevelLineID As Integer) As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine

            Try

                LoadByMediaPlanDetailLevelLineID = (From MediaPlanDetailLevelLine In DbContext.GetQuery(Of Database.Entities.MediaPlanDetailLevelLine)
                                                    Where MediaPlanDetailLevelLine.ID = MediaPlanDetailLevelLineID
                                                    Select MediaPlanDetailLevelLine).SingleOrDefault

            Catch ex As Exception
                LoadByMediaPlanDetailLevelLineID = Nothing
            End Try

        End Function
        Public Function LoadByMediaPlanID(ByVal DbContext As Database.DbContext, ByVal MediaPlanID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaPlanDetailLevelLine)

            LoadByMediaPlanID = From MediaPlanDetailLevelLine In DbContext.GetQuery(Of Database.Entities.MediaPlanDetailLevelLine)
                                Where MediaPlanDetailLevelLine.MediaPlanID = MediaPlanID
                                Select MediaPlanDetailLevelLine

        End Function
        Public Function LoadByMediaPlanDetailID(ByVal DbContext As Database.DbContext, ByVal MediaPlanDetailID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaPlanDetailLevelLine)

            LoadByMediaPlanDetailID = From MediaPlanDetailLevelLine In DbContext.GetQuery(Of Database.Entities.MediaPlanDetailLevelLine)
                                      Where MediaPlanDetailLevelLine.MediaPlanDetailID = MediaPlanDetailID
                                      Select MediaPlanDetailLevelLine

        End Function
        Public Function LoadByMediaPlanDetailIDAndRowIndex(ByVal DbContext As Database.DbContext, ByVal MediaPlanDetailID As Integer, ByVal RowIndex As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaPlanDetailLevelLine)

            LoadByMediaPlanDetailIDAndRowIndex = From MediaPlanDetailLevelLine In DbContext.GetQuery(Of Database.Entities.MediaPlanDetailLevelLine)
                                                 Where MediaPlanDetailLevelLine.MediaPlanDetailID = MediaPlanDetailID AndAlso
                                                       MediaPlanDetailLevelLine.RowIndex = RowIndex
                                                 Select MediaPlanDetailLevelLine

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaPlanDetailLevelLine)

            Load = From MediaPlanDetailLevelLine In DbContext.GetQuery(Of Database.Entities.MediaPlanDetailLevelLine)
                   Select MediaPlanDetailLevelLine

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaPlanDetailLevelLine As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.MediaPlanDetailLevelLines.Add(MediaPlanDetailLevelLine)

                ErrorText = MediaPlanDetailLevelLine.ValidateEntity(IsValid)

                If IsValid Then

                    MediaPlanDetailLevelLine.CreatedByUserCode = DbContext.UserCode
                    MediaPlanDetailLevelLine.CreatedDate = Now

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaPlanDetailLevelLine As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(MediaPlanDetailLevelLine)

                ErrorText = MediaPlanDetailLevelLine.ValidateEntity(IsValid)

                If IsValid Then

                    MediaPlanDetailLevelLine.ModifiedByUserCode = DbContext.UserCode
                    MediaPlanDetailLevelLine.ModifiedDate = Now

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

                If AdvantageFramework.Database.Procedures.MediaPlanDetailLevelLineData.UpdateRowIndexOnly(DbContext, MediaPlanDetailID, NewRowIndex, OldRowIndex) Then

                    DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.MEDIA_PLAN_DTL_LEVEL_LINE SET ROW_INDEX = {0} WHERE ROW_INDEX = {1} AND MEDIA_PLAN_DTL_ID = {2}", NewRowIndex, OldRowIndex, MediaPlanDetailID))

                    Updated = True

                End If

            Catch ex As Exception
                Updated = False
            Finally
                UpdateRowIndexOnly = Updated
            End Try

        End Function
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaPlanDetailLevelLine As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If AdvantageFramework.Database.Procedures.MediaPlanDetailLevelLineTag.DeleteByMediaPlanDetailLevelLineID(DbContext, MediaPlanDetailLevelLine.ID) Then

                    DbContext.DeleteEntityObject(MediaPlanDetailLevelLine)

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
        Public Function DeleteByMediaPlanDetailLevelID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaPlanDetailLevelID As Integer) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If AdvantageFramework.Database.Procedures.MediaPlanDetailLevelLineTag.DeleteByMediaPlanDetailLevelID(DbContext, MediaPlanDetailLevelID) Then

                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.MEDIA_PLAN_DTL_LEVEL_LINE WHERE MEDIA_PLAN_DTL_LEVEL_ID = {0}", MediaPlanDetailLevelID))

                    Deleted = True

                End If

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

                If AdvantageFramework.Database.Procedures.MediaPlanDetailLevelLineTag.DeleteByMediaPlanDetailID(DbContext, MediaPlanDetailID) Then

                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.MEDIA_PLAN_DTL_LEVEL_LINE WHERE MEDIA_PLAN_DTL_ID = {0}", MediaPlanDetailID))

                    Deleted = True

                End If

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteByMediaPlanDetailID = Deleted
            End Try

        End Function
        Public Function DeleteByMediaPlanDetailLevelLineID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaPlanDetailLevelLineID As Integer) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If AdvantageFramework.Database.Procedures.MediaPlanDetailLevelLineTag.DeleteByMediaPlanDetailLevelLineID(DbContext, MediaPlanDetailLevelLineID) Then

                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.MEDIA_PLAN_DTL_LEVEL_LINE WHERE MEDIA_PLAN_DTL_LEVEL_LINE_ID = {0}", MediaPlanDetailLevelLineID))

                    Deleted = True

                End If

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteByMediaPlanDetailLevelLineID = Deleted
            End Try

        End Function

#End Region

    End Module

End Namespace
