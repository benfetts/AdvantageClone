Namespace Database.Procedures.JobComponentDocument

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

        Public Function LoadCurrentByJobNumberComponents(ByVal DataContext As AdvantageFramework.Database.DataContext,
                                                         ByVal JobNumberComponents As IEnumerable(Of String)) As IQueryable(Of AdvantageFramework.Database.Entities.JobComponentDocument)

            'objects
            Dim DocumentIDs() As Integer = Nothing

            DocumentIDs = DataContext.ExecuteQuery(Of Integer)("SELECT DOCUMENT_ID FROM dbo.WV_CURRENT_JOB_COMPONENT_DOCUMENTS WHERE CAST(JOB_NUMBER AS varchar(20)) + '|' + CAST(JOB_COMPONENT_NUMBER as varchar(20)) IN ('" & String.Join("','", JobNumberComponents.ToArray) & "')").ToArray

            LoadCurrentByJobNumberComponents = From JobComponentDocument In DataContext.JobComponentDocuments
                                               Where DocumentIDs.Contains(JobComponentDocument.DocumentID)
                                               Select JobComponentDocument

        End Function
        Public Function LoadCurrentDocumentIDsByJobNumberComponents(DataContext As AdvantageFramework.Database.DataContext,
                                                                    JobNumberComponents As IEnumerable(Of String)) As Integer()

            'objects
            Dim DocumentIDs() As Integer = Nothing

            If JobNumberComponents IsNot Nothing AndAlso JobNumberComponents.Count > 0 Then

                DocumentIDs = DataContext.ExecuteQuery(Of Integer)("SELECT DOCUMENT_ID FROM dbo.WV_CURRENT_JOB_COMPONENT_DOCUMENTS WHERE CAST(JOB_NUMBER AS varchar(20)) + '|' + CAST(JOB_COMPONENT_NUMBER as varchar(20)) IN ('" & String.Join("','", JobNumberComponents.ToArray) & "')").ToArray

            Else

                DocumentIDs = New Integer() {(0)}

            End If

            LoadCurrentDocumentIDsByJobNumberComponents = DocumentIDs

        End Function
        Public Function LoadRelated(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal JobNumber As Long, ByVal JobComponentNumber As Short, ByVal Filename As String) As IQueryable(Of AdvantageFramework.Database.Entities.JobComponentDocument)

            'objects
            Dim DocumentIDs() As Integer = Nothing

            DocumentIDs = DataContext.ExecuteQuery(Of Integer)(String.Format("SELECT DOCUMENT_ID FROM dbo.WV_JOB_COMPONENT_DOCUMENTS WHERE [JOB_NUMBER] = {0} AND [JOB_COMPONENT_NUMBER] = {1} AND [FILENAME] = '{2}'", JobNumber, JobComponentNumber, Filename)).ToArray

            LoadRelated = From JobComponentDocument In DataContext.JobComponentDocuments
                          Where DocumentIDs.Contains(JobComponentDocument.DocumentID)
                          Select JobComponentDocument

        End Function
        Public Function LoadRelatedbyRepositoryFilename(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal Filename As String) As Integer

            'objects
            Dim DocumentIDs As Integer = Nothing

            DocumentIDs = DataContext.ExecuteQuery(Of Integer)(String.Format("SELECT COUNT(1) FROM dbo.WV_CURRENT_JOB_COMPONENT_DOCUMENTS WHERE [REPOSITORY_FILENAME] = '{0}'", Filename)).SingleOrDefault

            LoadRelatedbyRepositoryFilename = DocumentIDs

        End Function
        Public Function LoadByDocumentID(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal DocumentID As Integer) As AdvantageFramework.Database.Entities.JobComponentDocument

            Try

                LoadByDocumentID = (From JobComponentDocument In DataContext.JobComponentDocuments
                                    Where JobComponentDocument.DocumentID = DocumentID
                                    Select JobComponentDocument).SingleOrDefault

            Catch ex As Exception
                LoadByDocumentID = Nothing
            End Try

        End Function
        Public Function Load(ByVal DataContext As AdvantageFramework.Database.DataContext) As IQueryable(Of AdvantageFramework.Database.Entities.JobComponentDocument)

            Load = From JobComponentDocument In DataContext.JobComponentDocuments
                   Select JobComponentDocument

        End Function
        Public Function LoadByJobNumberAndJobComponentNumber(ByVal DataContext As Database.DataContext, ByVal JobNumber As String, ByVal JobComponentNumber As String) As IQueryable(Of AdvantageFramework.Database.Entities.JobComponentDocument)

            LoadByJobNumberAndJobComponentNumber = From JobComponentDocument In DataContext.JobComponentDocuments
                                                   Where JobComponentDocument.JobNumber = JobNumber AndAlso
                                                         JobComponentDocument.JobComponentNumber = JobComponentNumber
                                                   Select JobComponentDocument

        End Function
        Public Function LoadByJobNumberAndJobComponentNumberAndDocumentID(ByVal DataContext As Database.DataContext, ByVal JobNumber As String, ByVal JobComponentNumber As String, ByVal DocumentID As String) As Database.Entities.JobComponentDocument

            Try

                LoadByJobNumberAndJobComponentNumberAndDocumentID = (From JobComponentDocument In DataContext.JobComponentDocuments _
                                                                     Where JobComponentDocument.JobNumber = JobNumber AndAlso _
                                                                            JobComponentDocument.JobComponentNumber = JobComponentNumber AndAlso _
                                                                            JobComponentDocument.DocumentID = DocumentID _
                                                                     Select JobComponentDocument).SingleOrDefault

            Catch ex As Exception
                LoadByJobNumberAndJobComponentNumberAndDocumentID = Nothing
            End Try

        End Function
        Public Function Insert(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal JobComponentDocument As AdvantageFramework.Database.Entities.JobComponentDocument) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                JobComponentDocument.DataContext = DataContext

                JobComponentDocument.DatabaseAction = AdvantageFramework.Database.Action.Inserting

                DataContext.JobComponentDocuments.InsertOnSubmit(JobComponentDocument)

                ErrorText = JobComponentDocument.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal JobComponentDocument As AdvantageFramework.Database.Entities.JobComponentDocument) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                JobComponentDocument.DataContext = DataContext

                JobComponentDocument.DatabaseAction = AdvantageFramework.Database.Action.Updating

                ErrorText = JobComponentDocument.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal JobComponentDocument As AdvantageFramework.Database.Entities.JobComponentDocument) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DataContext.JobComponentDocuments.DeleteOnSubmit(JobComponentDocument)

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

                    DataContext.JobComponentDocuments.DeleteOnSubmit(LoadByDocumentID(DataContext, DocumentID))

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