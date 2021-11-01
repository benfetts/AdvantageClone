Namespace Database.Procedures.MediaTrafficDetailDocument

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

        Public Function LoadByMediaTrafficDetailID(DbContext As Database.DbContext, MediaTrafficDetailID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaTrafficDetailDocument)

            LoadByMediaTrafficDetailID = From MediaTrafficDetailDocument In DbContext.GetQuery(Of Database.Entities.MediaTrafficDetailDocument)
                                         Where MediaTrafficDetailDocument.MediaTrafficDetailID = MediaTrafficDetailID
                                         Select MediaTrafficDetailDocument

        End Function
        Public Function Load(DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaTrafficDetailDocument)

            Load = From MediaTrafficDetailDocument In DbContext.GetQuery(Of Database.Entities.MediaTrafficDetailDocument)
                   Select MediaTrafficDetailDocument

        End Function
        Public Function LoadByDocumentIDMediaTrafficDetailID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DocumentID As Integer, ByVal MediaTrafficDetailID As Integer) As AdvantageFramework.Database.Entities.MediaTrafficDetailDocument

            LoadByDocumentIDMediaTrafficDetailID = (From MediaTrafficDetailDocument In DbContext.GetQuery(Of Database.Entities.MediaTrafficDetailDocument)
                                                    Where MediaTrafficDetailDocument.DocumentID = DocumentID AndAlso
                                                          MediaTrafficDetailDocument.MediaTrafficDetailID = MediaTrafficDetailID
                                                    Select MediaTrafficDetailDocument).SingleOrDefault

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaTrafficDetailDocument As AdvantageFramework.Database.Entities.MediaTrafficDetailDocument,
                               ByRef ErrorText As String) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True

            Try

                DbContext.MediaTrafficDetailDocuments.Add(MediaTrafficDetailDocument)

                ErrorText = MediaTrafficDetailDocument.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaTrafficDetailDocument As AdvantageFramework.Database.Entities.MediaTrafficDetailDocument) As Boolean

            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.Entry(MediaTrafficDetailDocument).State = Entity.EntityState.Deleted

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DocumentID As Integer, ByVal MediaTrafficDetailID As Integer) As Boolean

            Delete = Delete(DbContext, LoadByDocumentIDMediaTrafficDetailID(DbContext, DocumentID, MediaTrafficDetailID))

        End Function

#End Region

    End Module

End Namespace
