Namespace Database.Procedures.ContractDocument

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

        Public Function LoadCurrentByContractIDs(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                 ByVal ContractIDs As IEnumerable(Of Integer)) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ContractDocument)

            'objects
            Dim DocumentIDs() As Integer = Nothing

            If ContractIDs IsNot Nothing AndAlso ContractIDs.Count > 0 Then

                DocumentIDs = DbContext.Database.SqlQuery(Of Integer)("SELECT DOCUMENT_ID FROM dbo.CURRENT_CONTRACT_DOCUMENTS WHERE CONTRACT_ID IN (" & String.Join(",", ContractIDs.ToArray) & ")").ToArray

            Else

                DocumentIDs = New Integer() {(0)}

            End If

            LoadCurrentByContractIDs = From ContractDocument In DbContext.GetQuery(Of Database.Entities.ContractDocument)
                                       Where DocumentIDs.Any(Function(DocumentID) DocumentID = ContractDocument.DocumentID)
                                       Select ContractDocument

        End Function
        Public Function LoadRelated(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ContractID As Integer, ByVal Filename As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ContractDocument)

            'objects
            Dim DocumentIDs() As Integer = Nothing

            DocumentIDs = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT DOCUMENT_ID FROM dbo.CONTRACT_DOCUMENTS_ALL WHERE CONTRACT_ID = {0} and [FILENAME] = '{1}'", ContractID, Filename)).ToArray

            LoadRelated = From ContractDocument In DbContext.GetQuery(Of Database.Entities.ContractDocument)
                          Where DocumentIDs.Any(Function(DocumentID) DocumentID = ContractDocument.DocumentID)
                          Select ContractDocument

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ContractDocument)

            Load = From ContractDocument In DbContext.GetQuery(Of Database.Entities.ContractDocument)
                   Select ContractDocument

        End Function
        Public Function LoadByContractID(ByVal DbContext As Database.DbContext, ByVal ContractID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ContractDocument)

            LoadByContractID = From ContractDocument In DbContext.GetQuery(Of Database.Entities.ContractDocument)
                               Where ContractDocument.ContractID = ContractID
                               Select ContractDocument

        End Function
        Public Function LoadDocumentsByID(ByVal DbContext As Database.DbContext, ByVal ID As Integer) As IEnumerable(Of AdvantageFramework.Database.Entities.Document)

            LoadDocumentsByID = From ContractDocument In DbContext.GetQuery(Of Database.Entities.ContractDocument)
                                Where ContractDocument.ID = ID
                                Select ContractDocument.Document

        End Function
        Public Function LoadByDocumentID(ByVal DbContext As Database.DbContext, ByVal DocumentID As Integer) As Database.Entities.ContractDocument

            Try

                LoadByDocumentID = (From ContractDocument In DbContext.GetQuery(Of Database.Entities.ContractDocument)
                                    Where ContractDocument.DocumentID = DocumentID
                                    Select ContractDocument).SingleOrDefault

            Catch ex As Exception
                LoadByDocumentID = Nothing
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ContractDocument As AdvantageFramework.Database.Entities.ContractDocument) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.ContractDocuments.Add(ContractDocument)

                ErrorText = ContractDocument.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DocumentID As Integer) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(LoadByDocumentID(DbContext, DocumentID))

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ContractDocument As AdvantageFramework.Database.Entities.ContractDocument) As Boolean

            'objects
            Dim Deleted As Boolean = True
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""
            Dim Documents As IEnumerable(Of AdvantageFramework.Database.Entities.Document) = Nothing

            Try

                If IsValid Then

                    Documents = LoadDocumentsByID(DbContext, ContractDocument.ID)

                    DbContext.DeleteEntityObject(ContractDocument)

                    If Documents.Count > 0 Then

                        AdvantageFramework.Database.Procedures.Document.Delete(DbContext, Documents)

                    End If

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
