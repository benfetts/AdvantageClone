Namespace Database.Procedures.JobDocument

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

        Public Function LoadCurrentByJobNumbers(ByVal DataContext As AdvantageFramework.Database.DataContext,
                                                ByVal JobNumbers As IEnumerable(Of Integer)) As IQueryable(Of AdvantageFramework.Database.Entities.JobDocument)

            'objects
            Dim DocumentIDs() As Integer = Nothing

            If JobNumbers IsNot Nothing AndAlso JobNumbers.Count > 0 Then

                DocumentIDs = DataContext.ExecuteQuery(Of Integer)("SELECT DOCUMENT_ID FROM dbo.WV_CURRENT_JOB_DOCUMENTS WHERE JOB_NUMBER IN (" & String.Join(",", JobNumbers.ToArray) & ")").ToArray

            Else

                DocumentIDs = New Integer() {(0)}

            End If

            LoadCurrentByJobNumbers = From JobDocument In DataContext.JobDocuments
                                      Where DocumentIDs.Contains(JobDocument.DocumentID)
                                      Select JobDocument

        End Function
        Public Function LoadCurrentDocumentIDsByJobNumbers(ByVal DataContext As AdvantageFramework.Database.DataContext,
                                                           ByVal JobNumbers As IEnumerable(Of Integer)) As Integer()

            'objects
            Dim DocumentIDs() As Integer = Nothing

            If JobNumbers IsNot Nothing AndAlso JobNumbers.Count > 0 Then

                DocumentIDs = DataContext.ExecuteQuery(Of Integer)("SELECT DOCUMENT_ID FROM dbo.WV_CURRENT_JOB_DOCUMENTS WHERE JOB_NUMBER IN (" & String.Join(",", JobNumbers.ToArray) & ")").ToArray

            Else

                DocumentIDs = New Integer() {(0)}

            End If

            LoadCurrentDocumentIDsByJobNumbers = DocumentIDs

        End Function
        Public Function LoadRelated(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal JobNumber As Long, ByVal Filename As String) As IQueryable(Of AdvantageFramework.Database.Entities.JobDocument)

            'objects
            Dim DocumentIDs() As Integer = Nothing

            DocumentIDs = DataContext.ExecuteQuery(Of Integer)(String.Format("SELECT DOCUMENT_ID FROM dbo.WV_JOB_DOCUMENTS WHERE [JOB_NUMBER] = {0} AND [FILENAME] = '{1}'", JobNumber, Filename)).ToArray

            LoadRelated = From JobDocument In DataContext.JobDocuments
                          Where DocumentIDs.Contains(JobDocument.DocumentID)
                          Select JobDocument

        End Function

        Public Function LoadRelatedbyRepositoryFilename(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal Filename As String) As Integer

            'objects
            Dim DocumentIDs As Integer = Nothing

            DocumentIDs = DataContext.ExecuteQuery(Of Integer)(String.Format("SELECT COUNT(1) FROM dbo.WV_CURRENT_JOB_DOCUMENTS WHERE [REPOSITORY_FILENAME] = '{0}'", Filename)).SingleOrDefault

            LoadRelatedbyRepositoryFilename = DocumentIDs

        End Function

        Public Function LoadByDocumentID(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal DocumentID As Integer) As AdvantageFramework.Database.Entities.JobDocument

            Try

                LoadByDocumentID = (From JobDocument In DataContext.JobDocuments
                                    Where JobDocument.DocumentID = DocumentID
                                    Select JobDocument).SingleOrDefault

            Catch ex As Exception
                LoadByDocumentID = Nothing
            End Try

        End Function
        Public Function Load(ByVal DataContext As AdvantageFramework.Database.DataContext) As IQueryable(Of AdvantageFramework.Database.Entities.JobDocument)

            Load = From JobDocument In DataContext.JobDocuments
                   Select JobDocument

        End Function
        Public Function LoadByJobNumber(ByVal DataContext As Database.DataContext, ByVal JobNumber As String) As IQueryable(Of AdvantageFramework.Database.Entities.JobDocument)

            LoadByJobNumber = From JobDocument In DataContext.JobDocuments
                              Where JobDocument.JobNumber = JobNumber
                              Select JobDocument

        End Function
        Public Function LoadByJobNumberAndDocumentID(ByVal DataContext As Database.DataContext, ByVal JobNumber As String, ByVal DocumentID As String) As Database.Entities.JobDocument

            Try

                LoadByJobNumberAndDocumentID = (From JobDocument In DataContext.JobDocuments
                                                Where JobDocument.JobNumber = JobNumber AndAlso
                                                      JobDocument.DocumentID = DocumentID
                                                Select JobDocument).SingleOrDefault

            Catch ex As Exception
                LoadByJobNumberAndDocumentID = Nothing
            End Try

        End Function
        Public Function Insert(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal JobDocument As AdvantageFramework.Database.Entities.JobDocument) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                JobDocument.DataContext = DataContext

                JobDocument.DatabaseAction = AdvantageFramework.Database.Action.Inserting

                DataContext.JobDocuments.InsertOnSubmit(JobDocument)

                ErrorText = JobDocument.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal JobDocument As AdvantageFramework.Database.Entities.JobDocument) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                JobDocument.DataContext = DataContext

                JobDocument.DatabaseAction = AdvantageFramework.Database.Action.Updating

                ErrorText = JobDocument.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal JobDocument As AdvantageFramework.Database.Entities.JobDocument) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DataContext.JobDocuments.DeleteOnSubmit(JobDocument)

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
        Public Function Delete(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal DocumentID As Integer) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DataContext.JobDocuments.DeleteOnSubmit(LoadByDocumentID(DataContext, DocumentID))

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