Namespace Database.Procedures.AccountPayableDocument

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

        Public Function LoadCurrentByAPIDs(ByVal DataContext As AdvantageFramework.Database.DataContext,
                                           ByVal AccountPayableIDs As IEnumerable(Of Integer)) As IQueryable(Of AdvantageFramework.Database.Entities.AccountPayableDocument)

            'objects
            Dim DocumentIDs() As Integer = Nothing

            If AccountPayableIDs IsNot Nothing AndAlso AccountPayableIDs.Count > 0 Then

                DocumentIDs = DataContext.ExecuteQuery(Of Integer)("SELECT DOCUMENT_ID FROM dbo.WV_CURRENT_AP_DOCUMENTS WHERE AP_ID IN (" & String.Join(",", AccountPayableIDs.ToArray) & ")").ToArray

            Else

                DocumentIDs = New Integer() {(0)}

            End If

            LoadCurrentByAPIDs = From AccountPayableDocument In DataContext.AccountPayableDocuments
                                 Where DocumentIDs.Contains(AccountPayableDocument.DocumentID)
                                 Select AccountPayableDocument

        End Function
        Public Function LoadRelated(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AccountPayableID As Long, ByVal Filename As String) As IQueryable(Of AdvantageFramework.Database.Entities.AccountPayableDocument)

            'objects
            Dim DocumentIDs() As Integer = Nothing

            DocumentIDs = DataContext.ExecuteQuery(Of Integer)(String.Format("SELECT DOCUMENT_ID FROM dbo.WV_AP_DOCUMENTS WHERE [AP_ID] = {0} AND [FILENAME] = '{1}'", AccountPayableID, Filename)).ToArray

            LoadRelated = From AccountPayableDocument In DataContext.AccountPayableDocuments
                          Where DocumentIDs.Contains(AccountPayableDocument.DocumentID)
                          Select AccountPayableDocument

        End Function
        Public Function LoadByDocumentID(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal DocumentID As Integer) As AdvantageFramework.Database.Entities.AccountPayableDocument

            Try

                LoadByDocumentID = (From AccountPayableDocument In DataContext.AccountPayableDocuments
                                    Where AccountPayableDocument.DocumentID = DocumentID
                                    Select AccountPayableDocument).SingleOrDefault

            Catch ex As Exception
                LoadByDocumentID = Nothing
            End Try

        End Function
        Public Function Load(ByVal DataContext As AdvantageFramework.Database.DataContext) As IQueryable(Of AdvantageFramework.Database.Entities.AccountPayableDocument)

            Load = From AccountPayableDocument In DataContext.AccountPayableDocuments
                   Select AccountPayableDocument

        End Function
        Public Function LoadByAccountPayableID(ByVal DataContext As Database.DataContext, ByVal AccountPayableID As String) As IQueryable(Of AdvantageFramework.Database.Entities.AccountPayableDocument)

            LoadByAccountPayableID = From AccountPayableDocument In DataContext.AccountPayableDocuments
                                     Where AccountPayableDocument.AccountPayableID = AccountPayableID
                                     Select AccountPayableDocument

        End Function
        Public Function LoadByAccountPayableIDAndDocumentID(ByVal DataContext As Database.DataContext, ByVal AccountPayableID As String, ByVal DocumentID As String) As Database.Entities.AccountPayableDocument

            Try

                LoadByAccountPayableIDAndDocumentID = (From AccountPayableDocument In DataContext.AccountPayableDocuments _
                                                        Where AccountPayableDocument.AccountPayableID = AccountPayableID AndAlso _
                                                              AccountPayableDocument.DocumentID = DocumentID _
                                                        Select AccountPayableDocument).SingleOrDefault

            Catch ex As Exception
                LoadByAccountPayableIDAndDocumentID = Nothing
            End Try

        End Function
        Public Function Insert(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AccountPayableDocument As AdvantageFramework.Database.Entities.AccountPayableDocument) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                AccountPayableDocument.DataContext = DataContext

                AccountPayableDocument.DatabaseAction = AdvantageFramework.Database.Action.Inserting

                DataContext.AccountPayableDocuments.InsertOnSubmit(AccountPayableDocument)

                ErrorText = AccountPayableDocument.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AccountPayableDocument As AdvantageFramework.Database.Entities.AccountPayableDocument) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                AccountPayableDocument.DataContext = DataContext

                AccountPayableDocument.DatabaseAction = AdvantageFramework.Database.Action.Updating

                ErrorText = AccountPayableDocument.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AccountPayableDocument As AdvantageFramework.Database.Entities.AccountPayableDocument) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DataContext.AccountPayableDocuments.DeleteOnSubmit(AccountPayableDocument)

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

                    DataContext.AccountPayableDocuments.DeleteOnSubmit(LoadByDocumentID(DataContext, DocumentID))

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