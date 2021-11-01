Namespace Database.Procedures.ClientDocument

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

        Public Function LoadCurrentByClientCodes(ByVal DataContext As AdvantageFramework.Database.DataContext,
                                                 ByVal ClientCodes As IEnumerable(Of String)) As IQueryable(Of AdvantageFramework.Database.Entities.ClientDocument)

            'objects
            Dim DocumentIDs() As Integer = Nothing

            DocumentIDs = DataContext.ExecuteQuery(Of Integer)("SELECT DOCUMENT_ID FROM dbo.WV_CURRENT_CLIENT_DOCUMENTS WHERE CL_CODE IN ('" & String.Join(",'", ClientCodes.ToArray) & "')").ToArray

            LoadCurrentByClientCodes = From ClientDocument In DataContext.ClientDocuments
                                       Where DocumentIDs.Contains(ClientDocument.DocumentID)
                                       Select ClientDocument

        End Function
        Public Function LoadRelated(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal ClientCode As String, ByVal Filename As String) As IQueryable(Of AdvantageFramework.Database.Entities.ClientDocument)

            'objects
            Dim DocumentIDs() As Integer = Nothing

            DocumentIDs = DataContext.ExecuteQuery(Of Integer)(String.Format("SELECT DOCUMENT_ID FROM dbo.WV_CLIENT_DOCUMENTS WHERE [CL_CODE] = '{0}' and [FILENAME] = '{1}'", ClientCode, Filename)).ToArray

            LoadRelated = From ClientDocument In DataContext.ClientDocuments
                          Where DocumentIDs.Contains(ClientDocument.DocumentID)
                          Select ClientDocument

        End Function
        Public Function LoadByDocumentID(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal DocumentID As Integer) As AdvantageFramework.Database.Entities.ClientDocument

            Try

                LoadByDocumentID = (From ClientDocument In DataContext.ClientDocuments
                                    Where ClientDocument.DocumentID = DocumentID
                                    Select ClientDocument).SingleOrDefault

            Catch ex As Exception
                LoadByDocumentID = Nothing
            End Try

        End Function
        Public Function Load(ByVal DataContext As AdvantageFramework.Database.DataContext) As IQueryable(Of AdvantageFramework.Database.Entities.ClientDocument)

            Load = From ClientDocument In DataContext.ClientDocuments
                   Select ClientDocument

        End Function
        Public Function LoadByClientCode(ByVal DataContext As Database.DataContext, ByVal ClientCode As String) As IQueryable(Of AdvantageFramework.Database.Entities.ClientDocument)

            LoadByClientCode = From ClientDocument In DataContext.ClientDocuments
                               Where ClientDocument.ClientCode = ClientCode
                               Select ClientDocument

        End Function
        Public Function LoadByClientCodeAndDocumentID(ByVal DataContext As Database.DataContext, ByVal ClientCode As String, ByVal DocumentID As String) As Database.Entities.ClientDocument

            Try

                LoadByClientCodeAndDocumentID = (From ClientDocument In DataContext.ClientDocuments _
                                                 Where ClientDocument.ClientCode = ClientCode AndAlso _
                                                       ClientDocument.DocumentID = DocumentID _
                                                 Select ClientDocument).SingleOrDefault

            Catch ex As Exception
                LoadByClientCodeAndDocumentID = Nothing
            End Try

        End Function
        Public Function Insert(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal ClientDocument As AdvantageFramework.Database.Entities.ClientDocument) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                ClientDocument.DataContext = DataContext

                ClientDocument.DatabaseAction = AdvantageFramework.Database.Action.Inserting

                DataContext.ClientDocuments.InsertOnSubmit(ClientDocument)

                ErrorText = ClientDocument.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal ClientDocument As AdvantageFramework.Database.Entities.ClientDocument) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                ClientDocument.DataContext = DataContext

                ClientDocument.DatabaseAction = AdvantageFramework.Database.Action.Updating

                ErrorText = ClientDocument.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal ClientDocument As AdvantageFramework.Database.Entities.ClientDocument) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DataContext.ClientDocuments.DeleteOnSubmit(ClientDocument)

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

                    DataContext.ClientDocuments.DeleteOnSubmit(LoadByDocumentID(DataContext, DocumentID))

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