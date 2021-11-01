Namespace Database.Procedures.Document

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

        Public Function LoadCurrentAPDocuments(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AccountPayableID As Long) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Document)

            'objects
            Dim DocumentIDs As Integer() = Nothing

            Try

                DocumentIDs = DbContext.Database.SqlQuery(Of Integer)(String.Format("EXEC [advsp_get_current_ap_document_ids] {0} ", AccountPayableID)).ToArray

                LoadCurrentAPDocuments = From Document In DbContext.GetQuery(Of Database.Entities.Document)
                                         Where DocumentIDs.Contains(Document.ID)
                                         Select Document

            Catch ex As Exception
                LoadCurrentAPDocuments = Nothing
            End Try

        End Function
        Public Function LoadCurrentJobComponentDocuments(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Document)

            'objects
            Dim DocumentIDs As Integer() = Nothing

            Try

                DocumentIDs = DbContext.Database.SqlQuery(Of Integer)(String.Format("EXEC [advsp_get_current_job_comp_document_ids] {0}, {1} ", JobNumber, JobComponentNumber)).ToArray

                LoadCurrentJobComponentDocuments = From Document In DbContext.GetQuery(Of Database.Entities.Document)
                                                   Where DocumentIDs.Contains(Document.ID)
                                                   Select Document

            Catch ex As Exception
                LoadCurrentJobComponentDocuments = Nothing
            End Try

        End Function
        Public Function LoadCurrentJobDocuments(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobNumber As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Document)

            'objects
            Dim DocumentIDs As Integer() = Nothing

            Try

                DocumentIDs = DbContext.Database.SqlQuery(Of Integer)(String.Format("EXEC [advsp_get_current_job_document_ids] {0} ", JobNumber)).ToArray

                LoadCurrentJobDocuments = From Document In DbContext.GetQuery(Of Database.Entities.Document)
                                          Where DocumentIDs.Contains(Document.ID)
                                          Select Document

            Catch ex As Exception
                LoadCurrentJobDocuments = Nothing
            End Try

        End Function
        Public Function LoadCurrentLabelDocuments(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                  ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal LabelID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Document)

            'objects
            Dim DocumentIDs As Long() = Nothing

            Try

                DocumentIDs = (From Entity In AdvantageFramework.Database.Procedures.LabelDocument.LoadByLabelID(DataContext, LabelID)
                               Select Entity.DocumentID).ToArray()

                LoadCurrentLabelDocuments = From Document In DbContext.GetQuery(Of Database.Entities.Document)
                                            Where DocumentIDs.Contains(Document.ID)
                                            Select Document

            Catch ex As Exception
                LoadCurrentLabelDocuments = Nothing
            End Try

        End Function
        Public Function LoadByDocumentID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DocumentID As Long) As AdvantageFramework.Database.Entities.Document

            Try

                LoadByDocumentID = (From Document In DbContext.GetQuery(Of Database.Entities.Document)
                                    Where Document.ID = DocumentID
                                    Select Document).SingleOrDefault

            Catch ex As Exception
                LoadByDocumentID = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Document)

            Load = From Document In DbContext.GetQuery(Of Database.Entities.Document)
                   Select Document

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Document As AdvantageFramework.Database.Entities.Document) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.Documents.Add(Document)

                ErrorText = Document.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Document As AdvantageFramework.Database.Entities.Document) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(Document)

                ErrorText = Document.ValidateEntity(IsValid)

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

        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Document As AdvantageFramework.Database.Entities.Document) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(Document)

                    Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                    If Agency IsNot Nothing Then

                        Try

                            'When deleting main doc record, make sure doc is not being used as an attachment
                            'For Each DocumentAlertAttachment As AdvantageFramework.Database.Entities.AlertAttachment In AdvantageFramework.Database.Procedures.AlertAttachment.LoadByDocumentID(DbContext, Document.ID)

                            '    AdvantageFramework.Database.Procedures.AlertAttachment.Delete(DbContext, DocumentAlertAttachment)

                            'Next
                            DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM ALERT_ATTACHMENT WITH(ROWLOCK) WHERE DOCUMENT_ID = {0};", Document.ID))

                        Catch ex As Exception
                        End Try

                        AdvantageFramework.FileSystem.Delete(Agency, Document.FileSystemFileName)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Documents As IEnumerable(Of AdvantageFramework.Database.Entities.Document)) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim Document As AdvantageFramework.Database.Entities.Document = Nothing

            Try

                If IsValid Then

                    Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                    For Each Document In Documents

                        Try

                            DbContext.DeleteEntityObject(Document)

                            If Agency IsNot Nothing Then

                                AdvantageFramework.FileSystem.Delete(Agency, Document.FileSystemFileName)

                            End If

                        Catch ex As Exception

                        End Try

                    Next

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
