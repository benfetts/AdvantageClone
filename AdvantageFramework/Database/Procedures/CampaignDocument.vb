Namespace Database.Procedures.CampaignDocument

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

        Public Function LoadCurrentByCampaignIDs(ByVal DataContext As AdvantageFramework.Database.DataContext,
                                                 ByVal CampaignIDs As IEnumerable(Of Integer)) As IQueryable(Of AdvantageFramework.Database.Entities.CampaignDocument)

            'objects
            Dim DocumentIDs() As Integer = Nothing

            If CampaignIDs IsNot Nothing AndAlso CampaignIDs.Count > 0 Then

                DocumentIDs = DataContext.ExecuteQuery(Of Integer)("SELECT DOCUMENT_ID FROM dbo.WV_CURRENT_CAMPAIGN_DOCUMENTS WHERE CMP_IDENTIFIER IN (" & String.Join(",", CampaignIDs.ToArray) & ")").ToArray

            Else

                DocumentIDs = New Integer() {(0)}

            End If

            LoadCurrentByCampaignIDs = From CampaignDocument In DataContext.CampaignDocuments
                                       Where DocumentIDs.Contains(CampaignDocument.DocumentID)
                                       Select CampaignDocument

        End Function
        Public Function LoadRelated(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal CampaignID As Long, ByVal Filename As String) As IQueryable(Of AdvantageFramework.Database.Entities.CampaignDocument)

            'objects
            Dim DocumentIDs() As Integer = Nothing

            DocumentIDs = DataContext.ExecuteQuery(Of Integer)(String.Format("SELECT DOCUMENT_ID FROM dbo.WV_CAMPAIGN_DOCUMENTS WHERE [CMP_IDENTIFIER] = {0} AND [FILENAME] = '{1}'", CampaignID, Filename)).ToArray

            LoadRelated = From CampaignDocument In DataContext.CampaignDocuments
                          Where DocumentIDs.Contains(CampaignDocument.DocumentID)
                          Select CampaignDocument

        End Function
        Public Function LoadByDocumentID(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal DocumentID As Integer) As AdvantageFramework.Database.Entities.CampaignDocument

            Try

                LoadByDocumentID = (From CampaignDocument In DataContext.CampaignDocuments
                                    Where CampaignDocument.DocumentID = DocumentID
                                    Select CampaignDocument).SingleOrDefault

            Catch ex As Exception
                LoadByDocumentID = Nothing
            End Try

        End Function
        Public Function Load(ByVal DataContext As AdvantageFramework.Database.DataContext) As IQueryable(Of AdvantageFramework.Database.Entities.CampaignDocument)

            Load = From CampaignDocument In DataContext.CampaignDocuments
                   Select CampaignDocument

        End Function
        Public Function LoadByCampaignID(ByVal DataContext As Database.DataContext, ByVal CampaignID As String) As IQueryable(Of AdvantageFramework.Database.Entities.CampaignDocument)

            LoadByCampaignID = From CampaignDocument In DataContext.CampaignDocuments
                               Where CampaignDocument.CampaignID = CampaignID
                               Select CampaignDocument

        End Function
        Public Function LoadByCampaignIDAndDocumentID(ByVal DataContext As Database.DataContext, ByVal CampaignID As String, ByVal DocumentID As String) As Database.Entities.CampaignDocument

            Try

                LoadByCampaignIDAndDocumentID = (From CampaignDocument In DataContext.CampaignDocuments _
                                                 Where CampaignDocument.CampaignID = CampaignID AndAlso _
                                                       CampaignDocument.DocumentID = DocumentID _
                                                 Select CampaignDocument).SingleOrDefault

            Catch ex As Exception
                LoadByCampaignIDAndDocumentID = Nothing
            End Try

        End Function
        Public Function Insert(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal CampaignDocument As AdvantageFramework.Database.Entities.CampaignDocument) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                CampaignDocument.DataContext = DataContext

                CampaignDocument.DatabaseAction = AdvantageFramework.Database.Action.Inserting

                DataContext.CampaignDocuments.InsertOnSubmit(CampaignDocument)

                ErrorText = CampaignDocument.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal CampaignDocument As AdvantageFramework.Database.Entities.CampaignDocument) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                CampaignDocument.DataContext = DataContext

                CampaignDocument.DatabaseAction = AdvantageFramework.Database.Action.Updating

                ErrorText = CampaignDocument.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal CampaignDocument As AdvantageFramework.Database.Entities.CampaignDocument) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DataContext.CampaignDocuments.DeleteOnSubmit(CampaignDocument)

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

                    DataContext.CampaignDocuments.DeleteOnSubmit(LoadByDocumentID(DataContext, DocumentID))

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