Namespace Database.Procedures.GeneralLedgerDocument

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

        Public Function LoadByGLTransaction(DbContext As Database.DbContext, GLTransaction As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.GeneralLedgerDocument)

            LoadByGLTransaction = From GeneralLedgerDocument In DbContext.GetQuery(Of Database.Entities.GeneralLedgerDocument)
                                  Where GeneralLedgerDocument.GLTransaction = GLTransaction
                                  Select GeneralLedgerDocument

        End Function
        Public Function Load(DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.GeneralLedgerDocument)

            Load = From GeneralLedgerDocument In DbContext.GetQuery(Of Database.Entities.GeneralLedgerDocument)
                   Select GeneralLedgerDocument

        End Function
        Public Function LoadByDocumentID(DbContext As AdvantageFramework.Database.DbContext, DocumentID As Integer) As AdvantageFramework.Database.Entities.GeneralLedgerDocument

            Try

                LoadByDocumentID = (From GeneralLedgerDocument In DbContext.GetQuery(Of Database.Entities.GeneralLedgerDocument)
                                    Where GeneralLedgerDocument.DocumentID = DocumentID
                                    Select GeneralLedgerDocument).SingleOrDefault

            Catch ex As Exception
                LoadByDocumentID = Nothing
            End Try

        End Function
        Public Function Insert(DbContext As AdvantageFramework.Database.DbContext, GeneralLedgerDocument As AdvantageFramework.Database.Entities.GeneralLedgerDocument,
                               ByRef ErrorText As String) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True

            Try

                DbContext.GeneralLedgerDocuments.Add(GeneralLedgerDocument)

                ErrorText = GeneralLedgerDocument.ValidateEntity(IsValid)

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
        Public Function Delete(DbContext As AdvantageFramework.Database.DbContext, GeneralLedgerDocument As AdvantageFramework.Database.Entities.GeneralLedgerDocument) As Boolean

            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.Entry(GeneralLedgerDocument).State = Entity.EntityState.Deleted

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
