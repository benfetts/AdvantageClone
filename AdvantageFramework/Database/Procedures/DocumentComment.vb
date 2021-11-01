Namespace Database.Procedures.DocumentComment

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

        Public Function LoadByDocumentCommentID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DocumentCommentID As Long) As AdvantageFramework.Database.Entities.DocumentComment

            Try

                LoadByDocumentCommentID = (From DocumentComment In DbContext.GetQuery(Of Database.Entities.DocumentComment)
                                           Where DocumentComment.ID = DocumentCommentID
                                           Select DocumentComment).SingleOrDefault

            Catch ex As Exception
                LoadByDocumentCommentID = Nothing
            End Try

        End Function
        Public Function LoadByDocumentIDAndPageNumber(ByVal DbContext As Database.DbContext, ByVal DocumentID As Integer, ByVal PageNumber As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.DocumentComment)

            LoadByDocumentIDAndPageNumber = From DocumentComment In DbContext.GetQuery(Of Database.Entities.DocumentComment)
                                            Where DocumentComment.DocumentID = DocumentID AndAlso
                                                  DocumentComment.PageNumber = PageNumber
                                            Select DocumentComment

        End Function
        Public Function LoadByDocumentID(ByVal DbContext As Database.DbContext, ByVal DocumentID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.DocumentComment)

            LoadByDocumentID = From DocumentComment In DbContext.GetQuery(Of Database.Entities.DocumentComment)
                               Where DocumentComment.DocumentID = DocumentID
                               Select DocumentComment

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.DocumentComment)

            Load = From DocumentComment In DbContext.GetQuery(Of Database.Entities.DocumentComment)
                   Select DocumentComment

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DocumentID As Integer, _
                               ByVal UserCode As String, ByVal CreatedDate As Date, ByVal ModifiedDate As Date,
                               ByVal Comment As String, ByVal PageNumber As Integer, ByVal EmployeeCode As String, _
                               ByVal UserCodeCP As Integer, _
                               ByRef DocumentComment As AdvantageFramework.Database.Entities.DocumentComment) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                DocumentComment = New AdvantageFramework.Database.Entities.DocumentComment

                DocumentComment.DbContext = DbContext
                DocumentComment.DocumentID = DocumentID
                DocumentComment.UserCode = UserCode
                DocumentComment.CreatedDate = CreatedDate
                DocumentComment.ModifiedDate = ModifiedDate
                DocumentComment.Comment = Comment
                DocumentComment.PageNumber = PageNumber
                DocumentComment.EmployeeCode = EmployeeCode
                DocumentComment.UserCodeCP = UserCodeCP

                Inserted = Insert(DbContext, DocumentComment)

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DocumentComment As AdvantageFramework.Database.Entities.DocumentComment) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.DocumentComments.Add(DocumentComment)

                ErrorText = DocumentComment.ValidateEntity(IsValid)

                If IsValid Then

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DocumentComment As AdvantageFramework.Database.Entities.DocumentComment) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(DocumentComment)

                ErrorText = DocumentComment.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DocumentComment As AdvantageFramework.Database.Entities.DocumentComment) As Boolean

            'objects
            Dim Deleted As Boolean = True
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(DocumentComment)

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
