Namespace Database.Procedures.ContractReportDocument

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

        Public Function LoadCurrentByContractReportIDs(ByVal DataContext As AdvantageFramework.Database.DataContext,
                                                       ByVal ContractReportIDs As IEnumerable(Of Integer)) As IQueryable(Of AdvantageFramework.Database.Entities.ContractReportDocument)

            'objects
            Dim DocumentIDs() As Integer = Nothing

            If ContractReportIDs IsNot Nothing AndAlso ContractReportIDs.Count > 0 Then

                DocumentIDs = DataContext.ExecuteQuery(Of Integer)("SELECT DOCUMENT_ID FROM dbo.CURRENT_CONTRACT_REPORT_DOCUMENTS WHERE CONTRACT_REPORT_ID IN (" & String.Join(",", ContractReportIDs.ToArray) & ")").ToArray

            Else

                DocumentIDs = New Integer() {(0)}

            End If

            LoadCurrentByContractReportIDs = From ContractReportDocument In DataContext.ContractReportDocuments
                                             Where DocumentIDs.Contains(ContractReportDocument.DocumentID)
                                             Select ContractReportDocument

        End Function
        Public Function LoadRelated(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal ContractReportID As Integer, ByVal Filename As String) As IQueryable(Of AdvantageFramework.Database.Entities.ContractReportDocument)

            'objects
            Dim DocumentIDs() As Integer = Nothing

            DocumentIDs = DataContext.ExecuteQuery(Of Integer)(String.Format("SELECT DOCUMENT_ID FROM dbo.CONTRACT_REPORT_DOCUMENTS_ALL WHERE [CONTRACT_REPORT_ID] = '{0}' and [FILENAME] = '{1}'", ContractReportID, Filename)).ToArray

            LoadRelated = From ContractReportDocument In DataContext.ContractReportDocuments
                          Where DocumentIDs.Contains(ContractReportDocument.DocumentID)
                          Select ContractReportDocument

        End Function
        Public Function LoadByDocumentID(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal DocumentID As Integer) As AdvantageFramework.Database.Entities.ContractReportDocument

            Try

                LoadByDocumentID = (From ContractReportDocument In DataContext.ContractReportDocuments
                                    Where ContractReportDocument.DocumentID = CLng(DocumentID)
                                    Select ContractReportDocument).SingleOrDefault

            Catch ex As Exception
                LoadByDocumentID = Nothing
            End Try

        End Function
        Public Function Load(ByVal DataContext As AdvantageFramework.Database.DataContext) As IQueryable(Of AdvantageFramework.Database.Entities.ContractReportDocument)

            Load = From ContractReportDocument In DataContext.ContractReportDocuments
                   Select ContractReportDocument

        End Function
        Public Function LoadByContractReportID(ByVal DataContext As Database.DataContext, ByVal ContractReportID As Integer) As IQueryable(Of AdvantageFramework.Database.Entities.ContractReportDocument)

            LoadByContractReportID = From ContractReportDocument In DataContext.ContractReportDocuments
                                     Where ContractReportDocument.ContractReportID = CLng(ContractReportID)
                                     Select ContractReportDocument

        End Function
        Public Function Insert(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal ContractReportDocument As AdvantageFramework.Database.Entities.ContractReportDocument) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                ContractReportDocument.DataContext = DataContext

                ContractReportDocument.DatabaseAction = AdvantageFramework.Database.Action.Inserting

                DataContext.ContractReportDocuments.InsertOnSubmit(ContractReportDocument)

                ErrorText = ContractReportDocument.ValidateEntity(IsValid)

                If IsValid Then

                    DataContext.SubmitChanges()

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
        Public Function Update(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal ContractReportDocument As AdvantageFramework.Database.Entities.ContractReportDocument) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                ContractReportDocument.DataContext = DataContext

                ContractReportDocument.DatabaseAction = AdvantageFramework.Database.Action.Updating

                ErrorText = ContractReportDocument.ValidateEntity(IsValid)

                If IsValid Then

                    DataContext.SubmitChanges()

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
        Public Function Delete(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal ContractReportDocuments As IEnumerable(Of AdvantageFramework.Database.Entities.ContractReportDocument)) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""
            Dim Documents As IEnumerable(Of AdvantageFramework.Database.Entities.Document) = Nothing
            Dim DocumentIDs() As Long = Nothing
            Dim ContractReportDocument As AdvantageFramework.Database.Entities.ContractReportDocument = Nothing

            Try

                If IsValid Then

                    DocumentIDs = (From CRD In ContractReportDocuments _
                                   Select CRD.DocumentID).ToArray

                    Using DbContext As New AdvantageFramework.Database.DbContext(DataContext.Connection.ConnectionString, DataContext.UserCode)

                        Documents = (From Document In DbContext.GetQuery(Of Database.Entities.Document)
                                     Where DocumentIDs.Contains(Document.ID)
                                     Select Document).ToList

                    End Using

                    For Each ContractReportDocument In ContractReportDocuments

                        DataContext.ContractReportDocuments.DeleteOnSubmit(ContractReportDocument)

                    Next

                    DataContext.SubmitChanges()

                    If Documents.Count > 0 Then

                        Using DbContext As New AdvantageFramework.Database.DbContext(DataContext.Connection.ConnectionString, DataContext.UserCode)

                            AdvantageFramework.Database.Procedures.Document.Delete(DbContext, Documents)

                        End Using

                    End If

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
        Public Function Delete(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal DocumentID As Integer) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DataContext.ContractReportDocuments.DeleteOnSubmit(LoadByDocumentID(DataContext, DocumentID))

                    DataContext.SubmitChanges()

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