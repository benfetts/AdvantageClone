Namespace Database.Procedures.DivisionDocument

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

        Public Function LoadCurrentByClientDivisionCodes(ByVal DataContext As AdvantageFramework.Database.DataContext,
                                                         ByVal ClientDivisionCodes As IEnumerable(Of String)) As IQueryable(Of AdvantageFramework.Database.Entities.DivisionDocument)

            'objects
            Dim DocumentIDs() As Integer = Nothing

            DocumentIDs = DataContext.ExecuteQuery(Of Integer)("SELECT DOCUMENT_ID FROM dbo.WV_CURRENT_DIVISION_DOCUMENTS WHERE CL_CODE + '|' + DIV_CODE IN ('" & String.Join(",'", ClientDivisionCodes.ToArray) & "')").ToArray

            LoadCurrentByClientDivisionCodes = From DivisionDocument In DataContext.DivisionDocuments
                                               Where DocumentIDs.Contains(DivisionDocument.DocumentID)
                                               Select DivisionDocument

        End Function
        Public Function LoadRelated(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal Filename As String) As IQueryable(Of AdvantageFramework.Database.Entities.DivisionDocument)

            'objects
            Dim DocumentIDs() As Integer = Nothing

            DocumentIDs = DataContext.ExecuteQuery(Of Integer)(String.Format("SELECT DOCUMENT_ID FROM dbo.WV_DIVISION_DOCUMENTS WHERE [CL_CODE] = '{0}' AND [DIV_CODE] = '{1}' AND [FILENAME] = '{2}'", ClientCode, DivisionCode, Filename)).ToArray

            LoadRelated = From DivisionDocument In DataContext.DivisionDocuments
                          Where DocumentIDs.Contains(DivisionDocument.DocumentID)
                          Select DivisionDocument

        End Function
        Public Function LoadByDocumentID(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal DocumentID As Integer) As AdvantageFramework.Database.Entities.DivisionDocument

            Try

                LoadByDocumentID = (From DivisionDocument In DataContext.DivisionDocuments
                                    Where DivisionDocument.DocumentID = DocumentID
                                    Select DivisionDocument).SingleOrDefault

            Catch ex As Exception
                LoadByDocumentID = Nothing
            End Try


        End Function
        Public Function Load(ByVal DataContext As AdvantageFramework.Database.DataContext) As IQueryable(Of AdvantageFramework.Database.Entities.DivisionDocument)

            Load = From DivisionDocument In DataContext.DivisionDocuments
                   Select DivisionDocument

        End Function
        Public Function LoadByClientAndDivisionCode(ByVal DataContext As Database.DataContext, ByVal ClientCode As String, ByVal DivisionCode As String) As IQueryable(Of AdvantageFramework.Database.Entities.DivisionDocument)

            LoadByClientAndDivisionCode = From DivisionDocument In DataContext.DivisionDocuments
                                          Where DivisionDocument.ClientCode = ClientCode AndAlso
                                                DivisionDocument.DivisionCode = DivisionCode
                                          Select DivisionDocument

        End Function
        Public Function LoadByClientAndDivisionCodeAndDocumentID(ByVal DataContext As Database.DataContext, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal DocumentID As String) As Database.Entities.DivisionDocument

            Try

                LoadByClientAndDivisionCodeAndDocumentID = (From DivisionDocument In DataContext.DivisionDocuments _
                                                            Where DivisionDocument.ClientCode = ClientCode AndAlso _
                                                                  DivisionDocument.DivisionCode = DivisionCode AndAlso _
                                                                  DivisionDocument.DocumentID = DocumentID _
                                                            Select DivisionDocument).SingleOrDefault

            Catch ex As Exception
                LoadByClientAndDivisionCodeAndDocumentID = Nothing
            End Try

        End Function
        Public Function Insert(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal DivisionDocument As AdvantageFramework.Database.Entities.DivisionDocument) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DivisionDocument.DataContext = DataContext

                DivisionDocument.DatabaseAction = AdvantageFramework.Database.Action.Inserting

                DataContext.DivisionDocuments.InsertOnSubmit(DivisionDocument)

                ErrorText = DivisionDocument.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal DivisionDocument As AdvantageFramework.Database.Entities.DivisionDocument) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DivisionDocument.DataContext = DataContext

                DivisionDocument.DatabaseAction = AdvantageFramework.Database.Action.Updating

                ErrorText = DivisionDocument.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal DivisionDocument As AdvantageFramework.Database.Entities.DivisionDocument) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DataContext.DivisionDocuments.DeleteOnSubmit(DivisionDocument)

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

                    DataContext.DivisionDocuments.DeleteOnSubmit(LoadByDocumentID(DataContext, DocumentID))

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