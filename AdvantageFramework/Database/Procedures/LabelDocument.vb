Namespace Database.Procedures.LabelDocument

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

        Public Function LoadByDocumentIDs(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal DocumentIDs() As Long) As IQueryable(Of Database.Entities.LabelDocument)

            LoadByDocumentIDs = From LabelDocument In DataContext.LabelDocuments
                                Where DocumentIDs.Contains(LabelDocument.DocumentID)
                                Select LabelDocument

        End Function
        Public Function LoadByDocumentID(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal DocumentID As Long) As IQueryable(Of Database.Entities.LabelDocument)

            LoadByDocumentID = From LabelDocument In DataContext.LabelDocuments
                               Where LabelDocument.DocumentID = DocumentID
                               Select LabelDocument

        End Function
        Public Function LoadByLabelID(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal LabelID As Long) As IQueryable(Of Database.Entities.LabelDocument)

            LoadByLabelID = From LabelDocument In DataContext.LabelDocuments
                            Where LabelDocument.LabelID = LabelID
                            Select LabelDocument

        End Function
        Public Function LoadByLabelIDAndDocumentID(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal LabelID As Long, ByVal DocumentID As Long) As AdvantageFramework.Database.Entities.LabelDocument

            LoadByLabelIDAndDocumentID = (From LabelDocument In DataContext.LabelDocuments
                                          Where LabelDocument.LabelID = LabelID AndAlso LabelDocument.DocumentID = DocumentID
                                          Select LabelDocument).FirstOrDefault

        End Function
        Public Function Load(ByVal DataContext As AdvantageFramework.Database.DataContext) As IQueryable(Of Database.Entities.LabelDocument)

            Load = From LabelDocument In DataContext.LabelDocuments
                   Select LabelDocument

        End Function

        Public Function Insert(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal LabelDocument As AdvantageFramework.Database.Entities.LabelDocument) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                Inserted = DataContext.ExecuteCommand(String.Format("INSERT INTO LABEL_DOCUMENT (LABEL_ID, DOCUMENT_ID) VALUES ({0}, {1});", LabelDocument.LabelID, LabelDocument.DocumentID)) = 1

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Delete(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal LabelDocument As AdvantageFramework.Database.Entities.LabelDocument) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    'DataContext.LabelDocuments.DeleteOnSubmit(LabelDocument)

                    'DataContext.SubmitChanges()
                    DeleteByLabelIDAndDocumentID(DataContext, LabelDocument.LabelID, LabelDocument.DocumentID)

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
        Public Function DeleteByLabelID(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal LabelID As Long) As Boolean

            Try

                DataContext.ExecuteCommand(String.Format("DELETE FROM LABEL_DOCUMENT WITH(ROWLOCK) WHERE LABEL_ID = {0};", LabelID))
                Return True

            Catch ex As Exception

                Return False

            End Try

        End Function
        Public Function DeleteByDocumentID(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal DocumentID As Long) As Boolean

            Try

                DataContext.ExecuteCommand(String.Format("DELETE FROM LABEL_DOCUMENT WITH(ROWLOCK) WHERE DOCUMENT_ID = {0};", DocumentID))
                Return True

            Catch ex As Exception

                Return False

            End Try

        End Function
        Public Function DeleteByLabelIDAndDocumentID(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal LabelID As Long, ByVal DocumentID As Long) As Boolean

            Try

                DataContext.ExecuteCommand(String.Format("DELETE FROM LABEL_DOCUMENT WITH(ROWLOCK) WHERE LABEL_ID = {0} AND DOCUMENT_ID = {1};", LabelID, DocumentID))
                Return True

            Catch ex As Exception

                Return False

            End Try

        End Function

#End Region

    End Module

End Namespace

