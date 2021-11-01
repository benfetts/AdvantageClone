Namespace Database.Procedures.ExpenseDetailDocument

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

        Public Function LoadByDocumentIDAndExpenseDetailID(ByVal DbContext As Database.DbContext, ByVal DocumentID As Integer, ByVal ExpenseDetailID As Integer) As Database.Entities.ExpenseDetailDocument

            Try

                LoadByDocumentIDAndExpenseDetailID = (From ExpenseDetailDocument In DbContext.GetQuery(Of Database.Entities.ExpenseDetailDocument)
                                                      Where ExpenseDetailDocument.DocumentID = DocumentID AndAlso
                                                            ExpenseDetailDocument.ExpenseDetailID = ExpenseDetailID
                                                      Select ExpenseDetailDocument).SingleOrDefault

            Catch ex As Exception
                LoadByDocumentIDAndExpenseDetailID = Nothing
            End Try

        End Function
        Public Function LoadByDocumentID(ByVal DbContext As Database.DbContext, ByVal DocumentID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ExpenseDetailDocument)

            LoadByDocumentID = From ExpenseDetailDocument In DbContext.GetQuery(Of Database.Entities.ExpenseDetailDocument)
                               Where ExpenseDetailDocument.DocumentID = DocumentID
                               Select ExpenseDetailDocument

        End Function
        Public Function LoadByExpenseDetailID(ByVal DbContext As Database.DbContext, ByVal ExpenseDetailID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ExpenseDetailDocument)

            LoadByExpenseDetailID = From ExpenseDetailDocument In DbContext.GetQuery(Of Database.Entities.ExpenseDetailDocument)
                                    Where ExpenseDetailDocument.ExpenseDetailID = ExpenseDetailID
                                    Select ExpenseDetailDocument

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ExpenseDetailDocument)

            Load = From ExpenseDetailDocument In DbContext.GetQuery(Of Database.Entities.ExpenseDetailDocument)
                   Select ExpenseDetailDocument

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ExpenseDetailDocument As AdvantageFramework.Database.Entities.ExpenseDetailDocument) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.ExpenseDetailDocuments.Add(ExpenseDetailDocument)

                ErrorText = ExpenseDetailDocument.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ExpenseDetailDocument As AdvantageFramework.Database.Entities.ExpenseDetailDocument) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(ExpenseDetailDocument)

                ErrorText = ExpenseDetailDocument.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As Database.DbContext, ByVal DocumentID As Integer) As Boolean

            'objects
            Dim Deleted As Boolean = True
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM EXPENSE_DETAIL_DOCS WITH(ROWLOCK) WHERE DOCUMENT_ID = {0};", DocumentID))

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Deleted = False
            Finally
                Delete = Deleted
            End Try

        End Function
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ExpenseDetailDocument As AdvantageFramework.Database.Entities.ExpenseDetailDocument) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(ExpenseDetailDocument)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DocumentID As Integer, ByVal ExpenseDetailID As Integer) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(LoadByDocumentIDAndExpenseDetailID(DbContext, DocumentID, ExpenseDetailID))

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
