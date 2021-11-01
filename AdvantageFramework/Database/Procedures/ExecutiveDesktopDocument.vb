Namespace Database.Procedures.ExecutiveDesktopDocument

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

        Public Function LoadCurrent(DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.ExecutiveDesktopDocument)

            'objects
            Dim DocumentIDs() As Integer = Nothing

            DocumentIDs = DbContext.Database.SqlQuery(Of Integer)("SELECT DOCUMENT_ID FROM dbo.WV_CURRENT_EXEC_DESKTOP_DOCUMENTS WHERE OFFICE_CODE IS NULL AND EMP_CODE IS NULL").ToArray

            LoadCurrent = From ExecutiveDesktopDocument In DbContext.GetQuery(Of Database.Entities.ExecutiveDesktopDocument)
                          Where DocumentIDs.Contains(ExecutiveDesktopDocument.DocumentID)
                          Select ExecutiveDesktopDocument

        End Function
        Public Function LoadCurrentByOfficeCode(DbContext As Database.DbContext, OfficeCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.ExecutiveDesktopDocument)

            'objects
            Dim DocumentIDs() As Integer = Nothing

            DocumentIDs = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT DOCUMENT_ID FROM dbo.WV_CURRENT_EXEC_DESKTOP_DOCUMENTS WHERE OFFICE_CODE = '{0}' AND EMP_CODE IS NULL", OfficeCode)).ToArray

            LoadCurrentByOfficeCode = From ExecutiveDesktopDocument In DbContext.GetQuery(Of Database.Entities.ExecutiveDesktopDocument)
                                      Where DocumentIDs.Contains(ExecutiveDesktopDocument.DocumentID)
                                      Select ExecutiveDesktopDocument

        End Function
        Public Function LoadCurrentByEmployeeCode(DbContext As Database.DbContext, EmployeeCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.ExecutiveDesktopDocument)

            'objects
            Dim DocumentIDs() As Integer = Nothing

            DocumentIDs = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT DOCUMENT_ID FROM dbo.WV_CURRENT_EXEC_DESKTOP_DOCUMENTS WHERE OFFICE_CODE IS NULL AND EMP_CODE = '{0}'", EmployeeCode)).ToArray

            LoadCurrentByEmployeeCode = From ExecutiveDesktopDocument In DbContext.GetQuery(Of Database.Entities.ExecutiveDesktopDocument)
                                        Where DocumentIDs.Contains(ExecutiveDesktopDocument.DocumentID)
                                        Select ExecutiveDesktopDocument

        End Function
        Public Function LoadCurrentByOfficeCodeAndEmployeeCode(DbContext As Database.DbContext, OfficeCode As String, EmployeeCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.ExecutiveDesktopDocument)

            'objects
            Dim DocumentIDs() As Integer = Nothing

            DocumentIDs = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT DOCUMENT_ID FROM dbo.WV_CURRENT_EXEC_DESKTOP_DOCUMENTS WHERE OFFICE_CODE = '{0}' AND EMP_CODE = '{1}'", OfficeCode, EmployeeCode)).ToArray

            LoadCurrentByOfficeCodeAndEmployeeCode = From ExecutiveDesktopDocument In DbContext.GetQuery(Of Database.Entities.ExecutiveDesktopDocument)
                                                     Where DocumentIDs.Contains(ExecutiveDesktopDocument.DocumentID)
                                                     Select ExecutiveDesktopDocument

        End Function
        Public Function LoadRelated(DbContext As Database.DbContext, Filename As String, OfficeCode As String, EmployeeCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.ExecutiveDesktopDocument)

            'objects
            Dim DocumentIDs() As Integer = Nothing

            If String.IsNullOrWhiteSpace(OfficeCode) = True AndAlso String.IsNullOrWhiteSpace(EmployeeCode) = True Then

                DocumentIDs = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT DOCUMENT_ID FROM dbo.WV_EXEC_DESKTOP_DOCUMENTS WHERE [FILENAME] = '{0}' AND OFFICE_CODE IS NULL AND EMP_CODE IS NULL", Filename)).ToArray

            ElseIf String.IsNullOrWhiteSpace(OfficeCode) = True AndAlso String.IsNullOrWhiteSpace(EmployeeCode) = False Then

                DocumentIDs = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT DOCUMENT_ID FROM dbo.WV_EXEC_DESKTOP_DOCUMENTS WHERE [FILENAME] = '{0}' AND OFFICE_CODE IS NULL AND EMP_CODE = '{1}'", Filename, EmployeeCode)).ToArray

            ElseIf String.IsNullOrWhiteSpace(OfficeCode) = False AndAlso String.IsNullOrWhiteSpace(EmployeeCode) = True Then

                DocumentIDs = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT DOCUMENT_ID FROM dbo.WV_EXEC_DESKTOP_DOCUMENTS WHERE [FILENAME] = '{0}' AND OFFICE_CODE = '{1}' AND EMP_CODE IS NULL", Filename, OfficeCode)).ToArray

            ElseIf String.IsNullOrWhiteSpace(OfficeCode) = False AndAlso String.IsNullOrWhiteSpace(EmployeeCode) = False Then

                DocumentIDs = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT DOCUMENT_ID FROM dbo.WV_EXEC_DESKTOP_DOCUMENTS WHERE [FILENAME] = '{0}' AND OFFICE_CODE = '{1}' AND EMP_CODE = '{2}'", Filename, OfficeCode, EmployeeCode)).ToArray

            End If

            LoadRelated = From ExecutiveDesktopDocument In DbContext.GetQuery(Of Database.Entities.ExecutiveDesktopDocument)
                          Where DocumentIDs.Contains(ExecutiveDesktopDocument.DocumentID)
                          Select ExecutiveDesktopDocument

        End Function
        Public Function LoadRelated(DbContext As Database.DbContext, ClientCode As String, Filename As String) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.ExecutiveDesktopDocument)

            'objects
            Dim DocumentIDs() As Integer = Nothing

            DocumentIDs = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT DOCUMENT_ID FROM dbo.WV_CLIENT_DOCUMENTS WHERE [CL_CODE] = '{0}' and [FILENAME] = '{1}'", ClientCode, Filename)).ToArray

            LoadRelated = From ExecutiveDesktopDocument In DbContext.GetQuery(Of Database.Entities.ExecutiveDesktopDocument)
                          Where DocumentIDs.Contains(ExecutiveDesktopDocument.DocumentID)
                          Select ExecutiveDesktopDocument

        End Function
        Public Function LoadByDocumentID(DbContext As Database.DbContext, DocumentID As Integer) As AdvantageFramework.Database.Entities.ExecutiveDesktopDocument

            Try

                LoadByDocumentID = (From ExecutiveDesktopDocument In DbContext.GetQuery(Of Database.Entities.ExecutiveDesktopDocument)
                                    Where ExecutiveDesktopDocument.DocumentID = DocumentID
                                    Select ExecutiveDesktopDocument).SingleOrDefault

            Catch ex As Exception
                LoadByDocumentID = Nothing
            End Try

        End Function
        Public Function Load(DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ExecutiveDesktopDocument)

            Load = From ExecutiveDesktopDocument In DbContext.GetQuery(Of Database.Entities.ExecutiveDesktopDocument)
                   Select ExecutiveDesktopDocument

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext,
                               ByVal DocumentID As Integer,
                               ByVal OfficeCode As String, ByVal EmployeeCode As String,
                               ByRef ExecutiveDesktopDocument As AdvantageFramework.Database.Entities.ExecutiveDesktopDocument) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                ExecutiveDesktopDocument = New AdvantageFramework.Database.Entities.ExecutiveDesktopDocument

                ExecutiveDesktopDocument.DbContext = DbContext
                ExecutiveDesktopDocument.DocumentID = DocumentID
                ExecutiveDesktopDocument.OfficeCode = OfficeCode
                ExecutiveDesktopDocument.EmployeeCode = EmployeeCode

                Inserted = Insert(DbContext, ExecutiveDesktopDocument)

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ExecutiveDesktopDocument As AdvantageFramework.Database.Entities.ExecutiveDesktopDocument) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.ExecutiveDesktopDocuments.Add(ExecutiveDesktopDocument)

                ErrorText = ExecutiveDesktopDocument.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ExecutiveDesktopDocument As AdvantageFramework.Database.Entities.ExecutiveDesktopDocument) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(ExecutiveDesktopDocument)

                ErrorText = ExecutiveDesktopDocument.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ExecutiveDesktopDocument As AdvantageFramework.Database.Entities.ExecutiveDesktopDocument) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(ExecutiveDesktopDocument)

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
        Public Function Delete(DbContext As AdvantageFramework.Database.DbContext, DocumentID As Integer) As Boolean

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
