Namespace Database.Procedures.EmployeeDocument

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

        Public Function LoadCurrentByEmployeeCodes(ByVal DataContext As AdvantageFramework.Database.DataContext,
                                                   ByVal EmployeeCodes As IEnumerable(Of String)) As IQueryable(Of AdvantageFramework.Database.Entities.EmployeeDocument)

            'objects
            Dim DocumentIDs() As Integer = Nothing

            DocumentIDs = DataContext.ExecuteQuery(Of Integer)("SELECT DOCUMENT_ID FROM dbo.CURRENT_EMPLOYEE_DOCUMENTS WHERE EMP_CODE IN ('" & String.Join(",'", EmployeeCodes.ToArray) & "')").ToArray

            LoadCurrentByEmployeeCodes = From EmployeeDocument In DataContext.EmployeeDocuments
                                         Where DocumentIDs.Contains(EmployeeDocument.DocumentID)
                                         Select EmployeeDocument

        End Function
        Public Function LoadRelated(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal EmployeeCode As String, ByVal Filename As String) As IQueryable(Of AdvantageFramework.Database.Entities.EmployeeDocument)

            'objects
            Dim DocumentIDs() As Integer = Nothing

            DocumentIDs = DataContext.ExecuteQuery(Of Integer)(String.Format("SELECT DOCUMENT_ID FROM dbo.EMPLOYEE_DOCUMENTS_ALL WHERE [EMP_CODE] = '{0}' and [FILENAME] = '{1}'", EmployeeCode, Filename)).ToArray

            LoadRelated = From EmployeeDocument In DataContext.EmployeeDocuments
                          Where DocumentIDs.Contains(EmployeeDocument.DocumentID)
                          Select EmployeeDocument

        End Function
        Public Function LoadByDocumentID(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal DocumentID As Integer) As AdvantageFramework.Database.Entities.EmployeeDocument

            Try

                LoadByDocumentID = (From EmployeeDocument In DataContext.EmployeeDocuments
                                    Where EmployeeDocument.DocumentID = DocumentID
                                    Select EmployeeDocument).SingleOrDefault

            Catch ex As Exception
                LoadByDocumentID = Nothing
            End Try

        End Function
        Public Function Load(ByVal DataContext As AdvantageFramework.Database.DataContext) As IQueryable(Of AdvantageFramework.Database.Entities.EmployeeDocument)

            Load = From EmployeeDocument In DataContext.EmployeeDocuments
                   Select EmployeeDocument

        End Function
        Public Function LoadByEmployeeCode(ByVal DataContext As Database.DataContext, ByVal EmployeeCode As String) As IQueryable(Of AdvantageFramework.Database.Entities.EmployeeDocument)

            LoadByEmployeeCode = From EmployeeDocument In DataContext.EmployeeDocuments
                                 Where EmployeeDocument.EmployeeCode = EmployeeCode
                                 Select EmployeeDocument

        End Function
        Public Function LoadByEmployeeCodeAndDocumentID(ByVal DataContext As Database.DataContext, ByVal EmployeeCode As String, ByVal DocumentID As String) As Database.Entities.EmployeeDocument

            Try

                LoadByEmployeeCodeAndDocumentID = (From EmployeeDocument In DataContext.EmployeeDocuments _
                                                 Where EmployeeDocument.EmployeeCode = EmployeeCode AndAlso _
                                                       EmployeeDocument.DocumentID = DocumentID _
                                                 Select EmployeeDocument).SingleOrDefault

            Catch ex As Exception
                LoadByEmployeeCodeAndDocumentID = Nothing
            End Try

        End Function
        Public Function Insert(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal EmployeeDocument As AdvantageFramework.Database.Entities.EmployeeDocument) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                EmployeeDocument.DataContext = DataContext

                EmployeeDocument.DatabaseAction = AdvantageFramework.Database.Action.Inserting

                DataContext.EmployeeDocuments.InsertOnSubmit(EmployeeDocument)

                ErrorText = EmployeeDocument.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal EmployeeDocument As AdvantageFramework.Database.Entities.EmployeeDocument) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                EmployeeDocument.DataContext = DataContext

                EmployeeDocument.DatabaseAction = AdvantageFramework.Database.Action.Updating

                ErrorText = EmployeeDocument.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal EmployeeDocument As AdvantageFramework.Database.Entities.EmployeeDocument) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DataContext.EmployeeDocuments.DeleteOnSubmit(EmployeeDocument)

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

                    DataContext.EmployeeDocuments.DeleteOnSubmit(LoadByDocumentID(DataContext, DocumentID))

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