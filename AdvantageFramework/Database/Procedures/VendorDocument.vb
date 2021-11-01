Namespace Database.Procedures.VendorDocument

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

        Public Function LoadCurrentByVendorCodes(ByVal DataContext As AdvantageFramework.Database.DataContext,
                                                 ByVal VendorCodes As IEnumerable(Of String)) As IQueryable(Of AdvantageFramework.Database.Entities.VendorDocument)

            'objects
            Dim DocumentIDs() As Integer = Nothing

            DocumentIDs = DataContext.ExecuteQuery(Of Integer)("SELECT DOCUMENT_ID FROM dbo.CURRENT_VENDOR_DOCUMENTS WHERE VN_CODE IN ('" & String.Join(",'", VendorCodes.ToArray) & "')").ToArray

            LoadCurrentByVendorCodes = From VendorDocument In DataContext.VendorDocuments
                                       Where DocumentIDs.Contains(VendorDocument.DocumentID)
                                       Select VendorDocument

        End Function
        Public Function LoadRelated(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal VendorCode As String, ByVal Filename As String) As IQueryable(Of AdvantageFramework.Database.Entities.VendorDocument)

            'objects
            Dim DocumentIDs() As Integer = Nothing

            DocumentIDs = DataContext.ExecuteQuery(Of Integer)(String.Format("SELECT DOCUMENT_ID FROM dbo.VENDOR_DOCUMENTS_ALL WHERE [VN_CODE] = '{0}' and [FILENAME] = '{1}'", VendorCode, Filename)).ToArray

            LoadRelated = From VendorDocument In DataContext.VendorDocuments
                          Where DocumentIDs.Contains(VendorDocument.DocumentID)
                          Select VendorDocument

        End Function
        Public Function LoadByDocumentID(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal DocumentID As Integer) As AdvantageFramework.Database.Entities.VendorDocument

            Try

                LoadByDocumentID = (From VendorDocument In DataContext.VendorDocuments
                                    Where VendorDocument.DocumentID = DocumentID
                                    Select VendorDocument).SingleOrDefault

            Catch ex As Exception
                LoadByDocumentID = Nothing
            End Try

        End Function
        Public Function Load(ByVal DataContext As AdvantageFramework.Database.DataContext) As IQueryable(Of AdvantageFramework.Database.Entities.VendorDocument)

            Load = From VendorDocument In DataContext.VendorDocuments
                   Select VendorDocument

        End Function
        Public Function LoadByVendorCode(ByVal DataContext As Database.DataContext, ByVal VendorCode As String) As IQueryable(Of AdvantageFramework.Database.Entities.VendorDocument)

            LoadByVendorCode = From VendorDocument In DataContext.VendorDocuments
                               Where VendorDocument.VendorCode = VendorCode
                               Select VendorDocument

        End Function
        Public Function LoadByVendorCodeAndDocumentID(ByVal DataContext As Database.DataContext, ByVal VendorCode As String, ByVal DocumentID As String) As Database.Entities.VendorDocument

            Try

                LoadByVendorCodeAndDocumentID = (From VendorDocument In DataContext.VendorDocuments _
                                                 Where VendorDocument.VendorCode = VendorCode AndAlso _
                                                       VendorDocument.DocumentID = DocumentID _
                                                 Select VendorDocument).SingleOrDefault

            Catch ex As Exception
                LoadByVendorCodeAndDocumentID = Nothing
            End Try

        End Function
        Public Function Insert(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal VendorDocument As AdvantageFramework.Database.Entities.VendorDocument) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                VendorDocument.DataContext = DataContext

                VendorDocument.DatabaseAction = AdvantageFramework.Database.Action.Inserting

                DataContext.VendorDocuments.InsertOnSubmit(VendorDocument)

                ErrorText = VendorDocument.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal VendorDocument As AdvantageFramework.Database.Entities.VendorDocument) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                VendorDocument.DataContext = DataContext

                VendorDocument.DatabaseAction = AdvantageFramework.Database.Action.Updating

                ErrorText = VendorDocument.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal VendorDocument As AdvantageFramework.Database.Entities.VendorDocument) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DataContext.VendorDocuments.DeleteOnSubmit(VendorDocument)

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

                    DataContext.VendorDocuments.DeleteOnSubmit(LoadByDocumentID(DataContext, DocumentID))

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