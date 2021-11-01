Namespace Database.Procedures.MediaPlanDocument

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

        Public Function LoadByMediaPlanID(DbContext As Database.DbContext, MediaPlanID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaPlanDocument)

            LoadByMediaPlanID = From MediaPlanDocument In DbContext.GetQuery(Of Database.Entities.MediaPlanDocument)
                                Where MediaPlanDocument.MediaPlanID = MediaPlanID
                                Select MediaPlanDocument

        End Function
        Public Function Load(DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaPlanDocument)

            Load = From MediaPlanDocument In DbContext.GetQuery(Of Database.Entities.MediaPlanDocument)
                   Select MediaPlanDocument

        End Function
        Public Function LoadByDocumentID(DbContext As AdvantageFramework.Database.DbContext, DocumentID As Integer) As AdvantageFramework.Database.Entities.MediaPlanDocument

            Try

                LoadByDocumentID = (From MediaPlanDocument In DbContext.GetQuery(Of Database.Entities.MediaPlanDocument)
                                    Where MediaPlanDocument.DocumentID = DocumentID
                                    Select MediaPlanDocument).SingleOrDefault

            Catch ex As Exception
                LoadByDocumentID = Nothing
            End Try

        End Function
        Public Function Insert(DbContext As AdvantageFramework.Database.DbContext, MediaPlanDocument As AdvantageFramework.Database.Entities.MediaPlanDocument,
                               ByRef ErrorText As String) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True

            Try

                DbContext.MediaPlanDocuments.Add(MediaPlanDocument)

                ErrorText = MediaPlanDocument.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    Inserted = True

                End If

            Catch ex As Exception
                Inserted = False
                ErrorText = ex.Message
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Delete(DbContext As AdvantageFramework.Database.DbContext, MediaPlanDocument As AdvantageFramework.Database.Entities.MediaPlanDocument) As Boolean

            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.Entry(MediaPlanDocument).State = Entity.EntityState.Deleted

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
        Public Function Delete(DbContext As AdvantageFramework.Database.DbContext, DocumentID As Integer) As Boolean

            Delete = Delete(DbContext, LoadByDocumentID(DbContext, DocumentID))

        End Function

#End Region

    End Module

End Namespace
