Namespace Database.Procedures.OfficeDocument

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

        Public Function LoadCurrentByOfficeCodes(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                 ByVal OfficeCodes As IEnumerable(Of String)) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.OfficeDocument)

            'objects
            Dim DocumentIDs() As Integer = Nothing

            DocumentIDs = DbContext.Database.SqlQuery(Of Integer)("SELECT DOCUMENT_ID FROM dbo.WV_CURRENT_OFFICE_DOCUMENTS WHERE OFFICE_CODE IN ('" & String.Join(",'", OfficeCodes.ToArray) & "')").ToArray

            LoadCurrentByOfficeCodes = From OfficeDocument In DbContext.GetQuery(Of Database.Entities.OfficeDocument)
                                       Where DocumentIDs.Any(Function(DocumentID) DocumentID = OfficeDocument.DocumentID)
                                       Select OfficeDocument

        End Function
        Public Function LoadRelated(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal OfficeCode As String, ByVal Filename As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.OfficeDocument)

            'objects
            Dim DocumentIDs() As Integer = Nothing

            DocumentIDs = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT DOCUMENT_ID FROM dbo.WV_OFFICE_DOCUMENTS WHERE OFFICE_CODE = '{0}' and [FILENAME] = '{1}'", OfficeCode, Filename)).ToArray

            LoadRelated = From OfficeDocument In DbContext.GetQuery(Of Database.Entities.OfficeDocument)
                          Where DocumentIDs.Any(Function(DocumentID) DocumentID = OfficeDocument.DocumentID)
                          Select OfficeDocument

        End Function
        Public Function LoadByOfficeCode(ByVal DbContext As Database.DbContext, ByVal OfficeCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.OfficeDocument)

            LoadByOfficeCode = From OfficeDocument In DbContext.GetQuery(Of Database.Entities.OfficeDocument)
                               Where OfficeDocument.OfficeCode = OfficeCode
                               Select OfficeDocument

        End Function
        Public Function LoadByDocumentID(ByVal DbContext As Database.DbContext, ByVal DocumentID As Integer) As Database.Entities.OfficeDocument

            Try

                LoadByDocumentID = (From OfficeDocument In DbContext.GetQuery(Of Database.Entities.OfficeDocument)
                                    Where OfficeDocument.DocumentID = DocumentID
                                    Select OfficeDocument).SingleOrDefault

            Catch ex As Exception
                LoadByDocumentID = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.OfficeDocument)

            Load = From OfficeDocument In DbContext.GetQuery(Of Database.Entities.OfficeDocument)
                   Select OfficeDocument

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal OfficeDocument As AdvantageFramework.Database.Entities.OfficeDocument) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.OfficeDocuments.Add(OfficeDocument)

                ErrorText = OfficeDocument.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal OfficeDocument As AdvantageFramework.Database.Entities.OfficeDocument) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(OfficeDocument)

                    DbContext.SaveChanges()

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DocumentID As Integer) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(LoadByDocumentID(DbContext, DocumentID))

                    DbContext.SaveChanges()

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
