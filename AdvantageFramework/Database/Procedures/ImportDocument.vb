Namespace Database.Procedures.ImportDocument

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

        Public Function LoadByDocumentID(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal DocumentID As Integer) As AdvantageFramework.Database.Entities.ImportDocument

            Try

                LoadByDocumentID = (From ImportDocument In DataContext.ImportDocuments
                                    Where ImportDocument.DocumentID = DocumentID
                                    Select ImportDocument).SingleOrDefault

            Catch ex As Exception
                LoadByDocumentID = Nothing
            End Try

        End Function
        Public Function Load(ByVal DataContext As AdvantageFramework.Database.DataContext) As IQueryable(Of AdvantageFramework.Database.Entities.ImportDocument)

            Load = From ImportDocument In DataContext.ImportDocuments
                   Select ImportDocument

        End Function
        Public Function LoadByImportIDAndTemplateID(ByVal DataContext As Database.DataContext, ByVal ImportID As Integer, ByVal TemplateID As Integer) As IQueryable(Of AdvantageFramework.Database.Entities.ImportDocument)

            LoadByImportIDAndTemplateID = From ImportDocument In DataContext.ImportDocuments
                                          Where ImportDocument.ImportID = ImportID AndAlso
                                                ImportDocument.ImportTemplateID = TemplateID
                                          Select ImportDocument

        End Function
        Public Function LoadByImportIDAndDocumentID(ByVal DataContext As Database.DataContext, ByVal ImportID As Integer, ByVal DocumentID As Integer) As Database.Entities.ImportDocument

            Try

                LoadByImportIDAndDocumentID = (From ImportDocument In DataContext.ImportDocuments
                                               Where ImportDocument.ImportID = ImportID AndAlso
                                                     ImportDocument.DocumentID = DocumentID
                                               Select ImportDocument).SingleOrDefault

            Catch ex As Exception
                LoadByImportIDAndDocumentID = Nothing
            End Try

        End Function
        Public Function Insert(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal ImportDocument As AdvantageFramework.Database.Entities.ImportDocument) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                ImportDocument.DataContext = DataContext

                ImportDocument.DatabaseAction = AdvantageFramework.Database.Action.Inserting

                DataContext.ImportDocuments.InsertOnSubmit(ImportDocument)

                ErrorText = ImportDocument.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal ImportDocument As AdvantageFramework.Database.Entities.ImportDocument) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                ImportDocument.DataContext = DataContext

                ImportDocument.DatabaseAction = AdvantageFramework.Database.Action.Updating

                ErrorText = ImportDocument.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal ImportDocument As AdvantageFramework.Database.Entities.ImportDocument) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DataContext.ImportDocuments.DeleteOnSubmit(ImportDocument)

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

                    DataContext.ImportDocuments.DeleteOnSubmit(LoadByDocumentID(DataContext, DocumentID))

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
        Public Function Delete(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal ImportID As Integer, ByVal TemplateID As Integer) As Boolean

            'objects
            Dim Deleted As Boolean = False

            Try



                DataContext.ExecuteCommand(String.Format("DELETE FROM dbo.IMPORT_DOCUMENTS WHERE IMPORT_ID = {0} AND TEMPLATE_ID = {1}", ImportID, TemplateID))

                Deleted = True

            Catch ex As Exception
                Deleted = False
            Finally
                Delete = Deleted
            End Try

        End Function

#End Region

    End Module

End Namespace