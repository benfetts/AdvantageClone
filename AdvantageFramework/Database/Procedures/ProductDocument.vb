Namespace Database.Procedures.ProductDocument

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

        Public Function LoadCurrentByClientDivisionProductCodes(ByVal DataContext As AdvantageFramework.Database.DataContext,
                                                                ByVal ClientDivisionProductCodes As IEnumerable(Of String)) As IQueryable(Of AdvantageFramework.Database.Entities.ProductDocument)

            'objects
            Dim DocumentIDs() As Integer = Nothing

            DocumentIDs = DataContext.ExecuteQuery(Of Integer)("SELECT DOCUMENT_ID FROM dbo.WV_CURRENT_PRODUCT_DOCUMENTS WHERE CL_CODE + '|' + DIV_CODE + '|' + PRD_CODE IN ('" & String.Join(",'", ClientDivisionProductCodes.ToArray) & "')").ToArray

            LoadCurrentByClientDivisionProductCodes = From ProductDocument In DataContext.ProductDocuments
                                                      Where DocumentIDs.Contains(ProductDocument.DocumentID)
                                                      Select ProductDocument

        End Function
        Public Function LoadRelated(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, ByVal Filename As String) As IQueryable(Of AdvantageFramework.Database.Entities.ProductDocument)

            'objects
            Dim DocumentIDs() As Integer = Nothing

            DocumentIDs = DataContext.ExecuteQuery(Of Integer)(String.Format("SELECT DOCUMENT_ID FROM dbo.WV_PRODUCT_DOCUMENTS WHERE [CL_CODE] = '{0}' AND [DIV_CODE] = '{1}' AND [PRD_CODE] = '{2}' AND [FILENAME] = '{3}'", ClientCode, DivisionCode, ProductCode, Filename)).ToArray

            LoadRelated = From ProductDocument In DataContext.ProductDocuments
                          Where DocumentIDs.Contains(ProductDocument.DocumentID)
                          Select ProductDocument

        End Function
        Public Function LoadByDocumentID(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal DocumentID As Integer) As AdvantageFramework.Database.Entities.ProductDocument

            Try

                LoadByDocumentID = (From ProductDocument In DataContext.ProductDocuments
                                    Where ProductDocument.DocumentID = DocumentID
                                    Select ProductDocument).SingleOrDefault

            Catch ex As Exception
                LoadByDocumentID = Nothing
            End Try

        End Function
        Public Function Load(ByVal DataContext As AdvantageFramework.Database.DataContext) As IQueryable(Of AdvantageFramework.Database.Entities.ProductDocument)

            Load = From ProductDocument In DataContext.ProductDocuments
                   Select ProductDocument

        End Function
        Public Function LoadByClientAndDivisionAndProductCode(ByVal DataContext As Database.DataContext, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String) As IQueryable(Of AdvantageFramework.Database.Entities.ProductDocument)

            LoadByClientAndDivisionAndProductCode = From ProductDocument In DataContext.ProductDocuments
                                                    Where ProductDocument.ClientCode = ClientCode AndAlso
                                                          ProductDocument.DivisionCode = DivisionCode AndAlso
                                                          ProductDocument.ProductCode = ProductCode
                                                    Select ProductDocument

        End Function
        Public Function LoadByClientAndDivisionAndProductCodeAndDocumentID(ByVal DataContext As Database.DataContext, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, ByVal DocumentID As String) As Database.Entities.ProductDocument

            Try

                LoadByClientAndDivisionAndProductCodeAndDocumentID = (From ProductDocument In DataContext.ProductDocuments _
                                                                      Where ProductDocument.ClientCode = ClientCode AndAlso _
                                                                            ProductDocument.DivisionCode = DivisionCode AndAlso _
                                                                            ProductDocument.ProductCode = ProductCode AndAlso _
                                                                            ProductDocument.DocumentID = DocumentID _
                                                                      Select ProductDocument).SingleOrDefault

            Catch ex As Exception
                LoadByClientAndDivisionAndProductCodeAndDocumentID = Nothing
            End Try

        End Function
        Public Function Insert(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal ProductDocument As AdvantageFramework.Database.Entities.ProductDocument) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                ProductDocument.DataContext = DataContext

                ProductDocument.DatabaseAction = AdvantageFramework.Database.Action.Inserting

                DataContext.ProductDocuments.InsertOnSubmit(ProductDocument)

                ErrorText = ProductDocument.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal ProductDocument As AdvantageFramework.Database.Entities.ProductDocument) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                ProductDocument.DataContext = DataContext

                ProductDocument.DatabaseAction = AdvantageFramework.Database.Action.Updating

                ErrorText = ProductDocument.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal ProductDocument As AdvantageFramework.Database.Entities.ProductDocument) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DataContext.ProductDocuments.DeleteOnSubmit(ProductDocument)

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

                    DataContext.ProductDocuments.DeleteOnSubmit(LoadByDocumentID(DataContext, DocumentID))

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