Namespace Database.Procedures.JobComponentTaskDocument

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

        Public Function LoadByDocumentID(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal DocumentID As Integer) As AdvantageFramework.Database.Entities.JobComponentTaskDocument

            Try

                LoadByDocumentID = (From JobComponentTaskDocument In DataContext.JobComponentTaskDocuments
                                    Where JobComponentTaskDocument.DocumentID = DocumentID _
                                    Select JobComponentTaskDocument).SingleOrDefault

            Catch ex As Exception
                LoadByDocumentID = Nothing
            End Try

        End Function
        Public Function LoadRelated(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal SequenceNumber As Short, ByVal Filename As String) As IQueryable(Of AdvantageFramework.Database.Entities.JobComponentTaskDocument)

            'objects
            Dim DocumentIDs() As Integer = Nothing

            DocumentIDs = DataContext.ExecuteQuery(Of Integer)(String.Format("SELECT [DOCUMENT_ID] FROM dbo.V_TASK_DOCUMENTS WHERE [JOB_NUMBER] = '{0}' AND [JOB_COMPONENT_NBR] = '{1}' AND [SEQ_NBR] = '{2}' AND [FILENAME] = '{3}'", JobNumber, JobComponentNumber, SequenceNumber, Filename)).ToArray

            LoadRelated = From JobComponentTaskDocument In DataContext.JobComponentTaskDocuments
                          Where DocumentIDs.Contains(JobComponentTaskDocument.DocumentID)
                          Select JobComponentTaskDocument

        End Function
        Public Function LoadCurrentByJobComponentTask(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal SequenceNumber As Short) As IQueryable(Of AdvantageFramework.Database.Entities.JobComponentTaskDocument)

            Dim DocumentIDs As Integer() = Nothing

            Try

                DocumentIDs = DataContext.ExecuteQuery(Of Integer)(String.Format("SELECT [DOCUMENT_ID] FROM dbo.V_CURRENT_TASK_DOCUMENTS WHERE JOB_NUMBER = {0} AND JOB_COMPONENT_NBR = {1} AND SEQ_NBR = {2}", JobNumber, JobComponentNumber, SequenceNumber)).ToArray

                LoadCurrentByJobComponentTask = From JobComponentTaskDocument In DataContext.JobComponentTaskDocuments
                                                Where JobComponentTaskDocument.JobNumber = JobNumber AndAlso
                                                      JobComponentTaskDocument.JobComponentNumber = JobComponentNumber AndAlso
                                                      JobComponentTaskDocument.SequenceNumber = SequenceNumber AndAlso
                                                      DocumentIDs.Contains(JobComponentTaskDocument.DocumentID)
                                                Select JobComponentTaskDocument

            Catch ex As Exception
                LoadCurrentByJobComponentTask = Nothing
            End Try

        End Function
        Public Function LoadByJobComponentTask(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal SequenceNumber As Short) As IQueryable(Of AdvantageFramework.Database.Entities.JobComponentTaskDocument)

            LoadByJobComponentTask = From JobComponentTaskDocument In DataContext.JobComponentTaskDocuments
                                     Where JobComponentTaskDocument.JobNumber = JobNumber AndAlso
                                           JobComponentTaskDocument.JobComponentNumber = JobComponentNumber AndAlso
                                           JobComponentTaskDocument.SequenceNumber = SequenceNumber
                                     Select JobComponentTaskDocument

        End Function
        Public Function Load(ByVal DataContext As AdvantageFramework.Database.DataContext) As IQueryable(Of AdvantageFramework.Database.Entities.JobComponentTaskDocument)

            Load = From JobComponentTaskDocument In DataContext.JobComponentTaskDocuments
                   Select JobComponentTaskDocument

        End Function
        Public Function Insert(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal JobComponentTaskDocument As AdvantageFramework.Database.Entities.JobComponentTaskDocument) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                JobComponentTaskDocument.DataContext = DataContext

                JobComponentTaskDocument.DatabaseAction = AdvantageFramework.Database.Action.Inserting

                DataContext.JobComponentTaskDocuments.InsertOnSubmit(JobComponentTaskDocument)

                ErrorText = JobComponentTaskDocument.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal JobComponentTaskDocument As AdvantageFramework.Database.Entities.JobComponentTaskDocument) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                JobComponentTaskDocument.DataContext = DataContext
                JobComponentTaskDocument.DbContext = DbContext

                JobComponentTaskDocument.DatabaseAction = AdvantageFramework.Database.Action.Updating

                ErrorText = JobComponentTaskDocument.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal JobComponentTaskDocument As AdvantageFramework.Database.Entities.JobComponentTaskDocument) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DataContext.ExecuteCommand(String.Format("DELETE FROM [dbo].[JOB_TRAFFIC_VER_DET_DOCS] WHERE [DOCUMENT_ID] = {0}", JobComponentTaskDocument.DocumentID))

                    DataContext.JobComponentTaskDocuments.DeleteOnSubmit(JobComponentTaskDocument)

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