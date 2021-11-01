Namespace Database.Procedures.MediaPlanDetailField

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

        Public Function LoadByMediaPlanDetailID(ByVal DbContext As Database.DbContext, ByVal MediaPlanDetailID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaPlanDetailField)

            LoadByMediaPlanDetailID = From MediaPlanDetailField In DbContext.GetQuery(Of Database.Entities.MediaPlanDetailField)
                                      Where MediaPlanDetailField.MediaPlanDetailID = MediaPlanDetailID
                                      Select MediaPlanDetailField

        End Function
        Public Function LoadByMediaPlanID(ByVal DbContext As Database.DbContext, ByVal MediaPlanID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaPlanDetailField)

            LoadByMediaPlanID = From MediaPlanDetailField In DbContext.GetQuery(Of Database.Entities.MediaPlanDetailField)
                                Where MediaPlanDetailField.MediaPlanID = MediaPlanID
                                Select MediaPlanDetailField

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaPlanDetailField)

            Load = From MediaPlanDetailField In DbContext.GetQuery(Of Database.Entities.MediaPlanDetailField)
                   Select MediaPlanDetailField

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaPlanDetailField As AdvantageFramework.Database.Entities.MediaPlanDetailField) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.MediaPlanDetailFields.Add(MediaPlanDetailField)

                ErrorText = MediaPlanDetailField.ValidateEntity(IsValid)

                If IsValid Then

                    MediaPlanDetailField.CreatedByUserCode = DbContext.UserCode
                    MediaPlanDetailField.CreatedDate = Now

                    DbContext.MediaPlanDetailFields.Add(MediaPlanDetailField)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaPlanDetailField As AdvantageFramework.Database.Entities.MediaPlanDetailField) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(MediaPlanDetailField)

                ErrorText = MediaPlanDetailField.ValidateEntity(IsValid)

                If IsValid Then

                    MediaPlanDetailField.ModifiedByUserCode = DbContext.UserCode
                    MediaPlanDetailField.ModifiedDate = Now

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaPlanDetailField As AdvantageFramework.Database.Entities.MediaPlanDetailField) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(MediaPlanDetailField)

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

                DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.MEDIA_PLAN_DTL_FIELD WHERE MEDIA_PLAN_DTL_ID = {0}", MediaPlanDetailID))

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
