Namespace Database.Procedures.AccountReceivableDocument

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

        Public Function LoadCurrentByDocumentLevelSettings(ByVal DbContext As AdvantageFramework.Database.DbContext, _
                                                           ByVal DocumentLevelSettings As System.Collections.Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting)) As System.Collections.Generic.List(Of Database.Entities.AccountReceivableDocument)

            'objects
            Dim DocumentIDs() As Integer = Nothing
            Dim ARInvoices As IEnumerable(Of String) = Nothing

            ARInvoices = (From DLS In DocumentLevelSettings _
                          Where DLS.DocumentLevel = Entities.DocumentLevel.AccountReceivableInvoice _
                          Select [Code] = DLS.AccountReceivableInvoiceNumber & "|" & DLS.AccountReceivableSequenceNumber & "|" & DLS.AccountReceivableType).ToArray
            
            DocumentIDs = DbContext.Database.SqlQuery(Of Integer)("SELECT DOCUMENT_ID FROM dbo.CURRENT_ARINVOICE_DOCUMENTS WHERE CAST(AR_INV_NBR AS varchar(20)) + '|' + CAST(AR_INV_SEQ as varchar(20)) + '|' + AR_TYPE IN ('" & String.Join("','", ARInvoices.ToArray) & "')").ToArray

            LoadCurrentByDocumentLevelSettings = (From AccountReceivableDocument In DbContext.GetQuery(Of Database.Entities.AccountReceivableDocument)
                                                  Where DocumentIDs.Contains(AccountReceivableDocument.DocumentID)
                                                  Select AccountReceivableDocument).ToList

        End Function
        Public Function LoadByInvoiceNumberAndSequenceNumber(ByVal DbContext As Database.DbContext, ByVal AccountReceivableInvoiceNumber As Integer,
                                                             ByVal AccountReceivableSequenceNumber As Short) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AccountReceivableDocument)

            LoadByInvoiceNumberAndSequenceNumber = From AccountReceivableDocument In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.AccountReceivableDocument).Include("Document")
                                                   Where AccountReceivableDocument.InvoiceNumber = AccountReceivableInvoiceNumber AndAlso
                                                         AccountReceivableDocument.SequenceNumber = AccountReceivableSequenceNumber
                                                   Select AccountReceivableDocument

        End Function
        Public Function LoadRelated(ByVal DbContext As Database.DbContext, ByVal AccountReceivableInvoiceNumber As Integer, ByVal AccountReceivableSequenceNumber As Short,
                                    ByVal AccountReceivableType As String, ByVal FileName As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AccountReceivableDocument)

            LoadRelated = From AccountReceivableDocument In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.AccountReceivableDocument).Include("Document")
                          Where AccountReceivableDocument.InvoiceNumber = AccountReceivableInvoiceNumber AndAlso
                                AccountReceivableDocument.SequenceNumber = AccountReceivableSequenceNumber AndAlso
                                AccountReceivableDocument.Type = AccountReceivableType AndAlso
                                AccountReceivableDocument.Document.FileName = FileName
                          Select AccountReceivableDocument

        End Function
        Public Function LoadByDocumentID(ByVal DbContext As Database.DbContext, ByVal DocumentID As Integer) As AdvantageFramework.Database.Entities.AccountReceivableDocument

            Try

                LoadByDocumentID = (From AccountReceivableDocument In DbContext.GetQuery(Of Database.Entities.AccountReceivableDocument)
                                    Where AccountReceivableDocument.DocumentID = DocumentID
                                    Select AccountReceivableDocument).SingleOrDefault

            Catch ex As Exception
                LoadByDocumentID = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AccountReceivableDocument)

            Load = From AccountReceivableDocument In DbContext.GetQuery(Of Database.Entities.AccountReceivableDocument)
                   Select AccountReceivableDocument

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AccountReceivableDocument As AdvantageFramework.Database.Entities.AccountReceivableDocument) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.AccountReceivableDocuments.Add(AccountReceivableDocument)

                ErrorText = AccountReceivableDocument.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AccountReceivableDocument As AdvantageFramework.Database.Entities.AccountReceivableDocument) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(AccountReceivableDocument)

                ErrorText = AccountReceivableDocument.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AccountReceivableDocument As AdvantageFramework.Database.Entities.AccountReceivableDocument) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(AccountReceivableDocument)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DocumentID As Integer) As Boolean

            'objects
            Dim Deleted As Boolean = False

            Try

                Deleted = Delete(DbContext, LoadByDocumentID(DbContext, DocumentID))

            Catch ex As Exception
                Deleted = False
            Finally
                Delete = Deleted
            End Try

        End Function

#End Region

    End Module

End Namespace