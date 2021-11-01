Namespace Database.Procedures.MediaPlanDetailChangeLog

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

        Public Function LoadByMediaPlanDetailID(ByVal DbContext As Database.DbContext, ByVal MediaPlanDetailID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaPlanDetailChangeLog)

            LoadByMediaPlanDetailID = From MediaPlanDetailChangeLog In DbContext.GetQuery(Of Database.Entities.MediaPlanDetailChangeLog)
                                      Where MediaPlanDetailChangeLog.MediaPlanDetailID = MediaPlanDetailID
                                      Select MediaPlanDetailChangeLog

        End Function
        Public Function LoadByMediaPlanID(ByVal DbContext As Database.DbContext, ByVal MediaPlanID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaPlanDetailChangeLog)

            LoadByMediaPlanID = From MediaPlanDetailChangeLog In DbContext.GetQuery(Of Database.Entities.MediaPlanDetailChangeLog)
                                Where MediaPlanDetailChangeLog.MediaPlanID = MediaPlanID
                                Select MediaPlanDetailChangeLog

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaPlanDetailChangeLog)

            Load = From MediaPlanDetailChangeLog In DbContext.GetQuery(Of Database.Entities.MediaPlanDetailChangeLog)
                   Select MediaPlanDetailChangeLog

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaPlanDetailChangeLog As AdvantageFramework.Database.Entities.MediaPlanDetailChangeLog) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.MediaPlanDetailChangeLogs.Add(MediaPlanDetailChangeLog)

                ErrorText = MediaPlanDetailChangeLog.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.MediaPlanDetailChangeLogs.Add(MediaPlanDetailChangeLog)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaPlanDetailChangeLog As AdvantageFramework.Database.Entities.MediaPlanDetailChangeLog) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(MediaPlanDetailChangeLog)

                ErrorText = MediaPlanDetailChangeLog.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaPlanDetailChangeLog As AdvantageFramework.Database.Entities.MediaPlanDetailChangeLog) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(MediaPlanDetailChangeLog)

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

                DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.MEDIA_PLAN_DTL_CHANGE_LOG WHERE MEDIA_PLAN_DTL_ID = {0}", MediaPlanDetailID))

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
