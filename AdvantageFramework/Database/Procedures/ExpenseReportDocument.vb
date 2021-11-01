Namespace Database.Procedures.ExpenseReportDocument

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

        Public Function LoadCurrentByInvoiceNumbers(DbContext As AdvantageFramework.Database.DbContext, InvoiceNumbers As IEnumerable(Of String)) As IQueryable(Of AdvantageFramework.Database.Entities.ExpenseReportDocument)

            'objects
            Dim DocumentIDs() As Integer = Nothing

            DocumentIDs = DbContext.Database.SqlQuery(Of Integer)("SELECT DOCUMENT_ID FROM dbo.CURRENT_EXPENSE_DOCUMENTS WHERE INV_NBR IN ('" & String.Join(",'", InvoiceNumbers.ToArray) & "')").ToArray

            LoadCurrentByInvoiceNumbers = From VendorDocument In DbContext.ExpenseReportDocuments
                                          Where DocumentIDs.Contains(VendorDocument.DocumentID)
                                          Select VendorDocument

        End Function
        Public Function LoadRelated(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal InvoiceNumber As String, ByVal Filename As String) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.ExpenseReportDocument)

            'objects
            Dim DocumentIDs() As Integer = Nothing

            DocumentIDs = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT DOCUMENT_ID FROM dbo.EXPENSE_DOCUMENTS_ALL WHERE [INV_NBR] = {0} and [FILENAME] = '{1}'", InvoiceNumber, Filename)).ToArray

            LoadRelated = From ExpenseReportDocument In DbContext.GetQuery(Of Database.Entities.ExpenseReportDocument)
                          Where DocumentIDs.Contains(ExpenseReportDocument.DocumentID)
                          Select ExpenseReportDocument

        End Function
        Public Function LoadByDocumentID(ByVal DbContext As Database.DbContext, ByVal DocumentID As Long) As Database.Entities.ExpenseReportDocument

            Try

                LoadByDocumentID = (From ExpenseReportDocument In DbContext.GetQuery(Of Database.Entities.ExpenseReportDocument)
                                    Where ExpenseReportDocument.DocumentID = DocumentID
                                    Select ExpenseReportDocument).SingleOrDefault

            Catch ex As Exception
                LoadByDocumentID = Nothing
            End Try

        End Function
        Public Function LoadByInvoiceNumber(ByVal DbContext As Database.DbContext, ByVal InvoiceNumber As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ExpenseReportDocument)

            LoadByInvoiceNumber = From ExpenseReportDocument In DbContext.GetQuery(Of Database.Entities.ExpenseReportDocument)
                                  Where ExpenseReportDocument.InvoiceNumber = InvoiceNumber
                                  Select ExpenseReportDocument

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ExpenseReportDocument)

            Load = From ExpenseReportDocument In DbContext.GetQuery(Of Database.Entities.ExpenseReportDocument)
                   Select ExpenseReportDocument

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ExpenseReportDocument As AdvantageFramework.Database.Entities.ExpenseReportDocument) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.ExpenseReportDocuments.Add(ExpenseReportDocument)

                ErrorText = ExpenseReportDocument.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ExpenseReportDocument As AdvantageFramework.Database.Entities.ExpenseReportDocument) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(ExpenseReportDocument)

                ErrorText = ExpenseReportDocument.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As Database.DbContext, ByVal ExpenseReportDocument As AdvantageFramework.Database.Entities.ExpenseReportDocument) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    For Each DetailDocument In AdvantageFramework.Database.Procedures.ExpenseDetailDocument.LoadByDocumentID(DbContext, ExpenseReportDocument.DocumentID).ToList

                        DbContext.DeleteEntityObject(DetailDocument)

                    Next

                    DbContext.DeleteEntityObject(ExpenseReportDocument)

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
        Public Function Delete(ByVal DbContext As Database.DbContext, ByVal DocumentID As Integer) As Boolean

            'objects
            Dim Deleted As Boolean = True
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM EXPENSE_DETAIL_DOCS WITH(ROWLOCK) WHERE DOCUMENT_ID = {0};DELETE FROM EXPENSE_DOCS WITH(ROWLOCK) WHERE DOCUMENT_ID = {0};", DocumentID))

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
