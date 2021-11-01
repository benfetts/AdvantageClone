Namespace Database.Procedures.VendorContractDocument

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

        Public Function LoadCurrentByVendorContractIDs(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                       ByVal VendorContractIDs As IEnumerable(Of Integer)) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.VendorContractDocument)

            'objects
            Dim DocumentIDs() As Integer = Nothing

            If VendorContractIDs IsNot Nothing AndAlso VendorContractIDs.Count > 0 Then

                DocumentIDs = DbContext.Database.SqlQuery(Of Integer)("SELECT DOCUMENT_ID FROM dbo.CURRENT_VENDOR_CONTRACT_DOCUMENTS WHERE VENDOR_CONTRACT_ID IN (" & String.Join(",", VendorContractIDs.ToArray) & ")").ToArray

            Else

                DocumentIDs = New Integer() {(0)}

            End If

            LoadCurrentByVendorContractIDs = From VendorContractDocument In DbContext.GetQuery(Of Database.Entities.VendorContractDocument)
                                             Where DocumentIDs.Contains(VendorContractDocument.DocumentID)
                                             Select VendorContractDocument

        End Function
        Public Function LoadRelated(ByVal DataContext As AdvantageFramework.Database.DbContext, ByVal VendorContractID As Integer, ByVal Filename As String) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.VendorContractDocument)

            'objects
            Dim DocumentIDs() As Integer = Nothing

            DocumentIDs = DataContext.Database.SqlQuery(Of Integer)(String.Format("SELECT DOCUMENT_ID FROM dbo.VENDOR_CONTRACT_DOCUMENTS_ALL WHERE [VENDOR_CONTRACT_ID] = '{0}' and [FILENAME] = '{1}'", VendorContractID, Filename)).ToArray

            LoadRelated = From VendorContractDocument In DataContext.VendorContractDocuments
                          Where DocumentIDs.Contains(VendorContractDocument.DocumentID)
                          Select VendorContractDocument

        End Function
        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.VendorContractDocument)

            Load = DbContext.GetQuery(Of Database.Entities.VendorContractDocument)

        End Function
        Public Function LoadByID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ID As Integer) As AdvantageFramework.Database.Entities.VendorContractDocument

            Try

                LoadByID = (From VendorContractDocument In DbContext.GetQuery(Of Database.Entities.VendorContractDocument)
                            Where VendorContractDocument.ID = ID
                            Select VendorContractDocument).SingleOrDefault

            Catch ex As Exception
                LoadByID = Nothing
            End Try

        End Function
        Public Function LoadByContractID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ContractID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.VendorContractDocument)

            Try

                LoadByContractID = From VendorContractDocument In DbContext.GetQuery(Of Database.Entities.VendorContractDocument)
                                   Where VendorContractDocument.ContractID = ContractID
                                   Select VendorContractDocument

            Catch ex As Exception
                LoadByContractID = Nothing
            End Try

        End Function
        Public Function LoadByDocumentID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DocumentID As Integer) As AdvantageFramework.Database.Entities.VendorContractDocument

            Try

                LoadByDocumentID = (From VendorContractDocument In DbContext.GetQuery(Of Database.Entities.VendorContractDocument)
                                    Where VendorContractDocument.DocumentID = DocumentID
                                    Select VendorContractDocument).SingleOrDefault

            Catch ex As Exception
                LoadByDocumentID = Nothing
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal VendorContractDocument As AdvantageFramework.Database.Entities.VendorContractDocument, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True

            Try

                DbContext.VendorContractDocuments.Add(VendorContractDocument)

                ErrorMessage = VendorContractDocument.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    Inserted = True

                End If

            Catch ex As Exception

                Inserted = False

                ErrorMessage = ex.Message

                If ex.InnerException IsNot Nothing Then

                    ErrorMessage &= System.Environment.NewLine & System.Environment.NewLine & ex.InnerException.Message

                End If

            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal VendorContractDocument As AdvantageFramework.Database.Entities.VendorContractDocument, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True

            Try

                DbContext.Entry(VendorContractDocument).State = Entity.EntityState.Modified

                ErrorMessage = VendorContractDocument.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    Updated = True

                End If

            Catch ex As Exception

                Updated = False

                ErrorMessage = ex.Message

                If ex.InnerException IsNot Nothing Then

                    ErrorMessage &= System.Environment.NewLine & System.Environment.NewLine & ex.InnerException.Message

                End If

            Finally
                Update = Updated
            End Try

        End Function
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal VendorContractDocument As AdvantageFramework.Database.Entities.VendorContractDocument) As Boolean

            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.Entry(VendorContractDocument).State = Entity.EntityState.Deleted

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

            Delete = Delete(DbContext, LoadByDocumentID(DbContext, DocumentID))

        End Function

#End Region

    End Module

End Namespace
