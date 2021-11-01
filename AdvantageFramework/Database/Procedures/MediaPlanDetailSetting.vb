Namespace Database.Procedures.MediaPlanDetailSetting

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

        Public Function LoadByMediaPlanDetailIDAndSetting(ByVal DbContext As Database.DbContext, ByVal MediaPlanDetailID As Integer, ByVal Setting As String) As Database.Entities.MediaPlanDetailSetting

            Try

                LoadByMediaPlanDetailIDAndSetting = (From MediaPlanDetailSetting In DbContext.GetQuery(Of Database.Entities.MediaPlanDetailSetting)
                                                     Where MediaPlanDetailSetting.MediaPlanDetailID = MediaPlanDetailID AndAlso
                                                           MediaPlanDetailSetting.Setting = Setting
                                                     Select MediaPlanDetailSetting).SingleOrDefault

            Catch ex As Exception
                LoadByMediaPlanDetailIDAndSetting = Nothing
            End Try

        End Function

        Public Function LoadByMediaPlanDetailID(ByVal DbContext As Database.DbContext, ByVal MediaPlanDetailID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaPlanDetailSetting)

            LoadByMediaPlanDetailID = From MediaPlanDetailSetting In DbContext.GetQuery(Of Database.Entities.MediaPlanDetailSetting)
                                      Where MediaPlanDetailSetting.MediaPlanDetailID = MediaPlanDetailID
                                      Select MediaPlanDetailSetting

        End Function
        Public Function LoadByMediaPlanID(ByVal DbContext As Database.DbContext, ByVal MediaPlanID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaPlanDetailSetting)

            LoadByMediaPlanID = From MediaPlanDetailSetting In DbContext.GetQuery(Of Database.Entities.MediaPlanDetailSetting)
                                Where MediaPlanDetailSetting.MediaPlanID = MediaPlanID
                                Select MediaPlanDetailSetting

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaPlanDetailSetting)

            Load = From MediaPlanDetailSetting In DbContext.GetQuery(Of Database.Entities.MediaPlanDetailSetting)
                   Select MediaPlanDetailSetting

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

                ErrorText = MediaPlanDetailSetting.ValidateEntity(IsValid)

                If IsValid Then

                    MediaPlanDetailSetting.CreatedByUserCode = DbContext.UserCode
                    MediaPlanDetailSetting.CreatedDate = Now

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(MediaPlanDetailSetting)

                ErrorText = MediaPlanDetailSetting.ValidateEntity(IsValid)

                If IsValid Then

                    MediaPlanDetailSetting.ModifiedByUserCode = DbContext.UserCode
                    MediaPlanDetailSetting.ModifiedDate = Now

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(MediaPlanDetailSetting)

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

                DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.MEDIA_PLAN_DTL_SETTING WHERE MEDIA_PLAN_DTL_ID = {0}", MediaPlanDetailID))

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
