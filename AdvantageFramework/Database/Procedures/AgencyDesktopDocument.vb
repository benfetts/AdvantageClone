Namespace Database.Procedures.AgencyDesktopDocument

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

        Public Function LoadCurrent(DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.AgencyDesktopDocument)

            'objects
            Dim DocumentIDs() As Integer = Nothing

            DocumentIDs = DbContext.Database.SqlQuery(Of Integer)("SELECT DOCUMENT_ID FROM dbo.WV_CURRENT_AGENCY_DESKTOP_DOCUMENTS WHERE OFFICE_CODE IS NULL AND DP_TM_CODE IS NULL").ToArray

            LoadCurrent = From AgencyDesktopDocument In DbContext.GetQuery(Of Database.Entities.AgencyDesktopDocument)
                          Where DocumentIDs.Contains(AgencyDesktopDocument.DocumentID)
                          Select AgencyDesktopDocument

        End Function
        Public Function LoadCurrentByOfficeCode(DbContext As Database.DbContext, OfficeCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.AgencyDesktopDocument)

            'objects
            Dim DocumentIDs() As Integer = Nothing

            DocumentIDs = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT DOCUMENT_ID FROM dbo.WV_CURRENT_AGENCY_DESKTOP_DOCUMENTS WHERE OFFICE_CODE = '{0}' AND DP_TM_CODE IS NULL", OfficeCode)).ToArray

            LoadCurrentByOfficeCode = From AgencyDesktopDocument In DbContext.GetQuery(Of Database.Entities.AgencyDesktopDocument)
                                      Where DocumentIDs.Contains(AgencyDesktopDocument.DocumentID)
                                      Select AgencyDesktopDocument

        End Function
        Public Function LoadCurrentByDepartmentTeamCode(DbContext As Database.DbContext, DepartmentTeamCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.AgencyDesktopDocument)

            'objects
            Dim DocumentIDs() As Integer = Nothing

            DocumentIDs = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT DOCUMENT_ID FROM dbo.WV_CURRENT_AGENCY_DESKTOP_DOCUMENTS WHERE OFFICE_CODE IS NULL AND DP_TM_CODE = '{0}'", DepartmentTeamCode)).ToArray

            LoadCurrentByDepartmentTeamCode = From AgencyDesktopDocument In DbContext.GetQuery(Of Database.Entities.AgencyDesktopDocument)
                                              Where DocumentIDs.Contains(AgencyDesktopDocument.DocumentID)
                                              Select AgencyDesktopDocument

        End Function
        Public Function LoadCurrentByOfficeCodeAndDepartmentTeamCode(DbContext As Database.DbContext, OfficeCode As String, DepartmentTeamCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.AgencyDesktopDocument)

            'objects
            Dim DocumentIDs() As Integer = Nothing

            DocumentIDs = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT DOCUMENT_ID FROM dbo.WV_CURRENT_AGENCY_DESKTOP_DOCUMENTS WHERE OFFICE_CODE = '{0}' AND DP_TM_CODE = '{1}'", OfficeCode, DepartmentTeamCode)).ToArray

            LoadCurrentByOfficeCodeAndDepartmentTeamCode = From AgencyDesktopDocument In DbContext.GetQuery(Of Database.Entities.AgencyDesktopDocument)
                                                           Where DocumentIDs.Contains(AgencyDesktopDocument.DocumentID)
                                                           Select AgencyDesktopDocument

        End Function
        Public Function LoadRelated(DbContext As Database.DbContext, Filename As String, OfficeCode As String, DepartmentTeamCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.AgencyDesktopDocument)

            'objects
            Dim DocumentIDs() As Integer = Nothing

            If String.IsNullOrWhiteSpace(OfficeCode) = True AndAlso String.IsNullOrWhiteSpace(DepartmentTeamCode) = True Then

                DocumentIDs = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT DOCUMENT_ID FROM dbo.WV_AGENCY_DESKTOP_DOCUMENTS WHERE [FILENAME] = '{0}' AND OFFICE_CODE IS NULL AND DP_TM_CODE IS NULL", Filename)).ToArray

            ElseIf String.IsNullOrWhiteSpace(OfficeCode) = True AndAlso String.IsNullOrWhiteSpace(DepartmentTeamCode) = False Then

                DocumentIDs = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT DOCUMENT_ID FROM dbo.WV_AGENCY_DESKTOP_DOCUMENTS WHERE [FILENAME] = '{0}' AND OFFICE_CODE IS NULL AND DP_TM_CODE = '{1}'", Filename, DepartmentTeamCode)).ToArray

            ElseIf String.IsNullOrWhiteSpace(OfficeCode) = False AndAlso String.IsNullOrWhiteSpace(DepartmentTeamCode) = True Then

                DocumentIDs = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT DOCUMENT_ID FROM dbo.WV_AGENCY_DESKTOP_DOCUMENTS WHERE [FILENAME] = '{0}' AND OFFICE_CODE = '{1}' AND DP_TM_CODE IS NULL", Filename, OfficeCode)).ToArray

            ElseIf String.IsNullOrWhiteSpace(OfficeCode) = False AndAlso String.IsNullOrWhiteSpace(DepartmentTeamCode) = False Then

                DocumentIDs = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT DOCUMENT_ID FROM dbo.WV_AGENCY_DESKTOP_DOCUMENTS WHERE [FILENAME] = '{0}' AND OFFICE_CODE = '{1}' AND DP_TM_CODE = '{2}'", Filename, OfficeCode, DepartmentTeamCode)).ToArray

            End If

            LoadRelated = From AgencyDesktopDocument In DbContext.GetQuery(Of Database.Entities.AgencyDesktopDocument)
                          Where DocumentIDs.Contains(AgencyDesktopDocument.DocumentID)
                          Select AgencyDesktopDocument

        End Function
        Public Function LoadRelated(DbContext As Database.DbContext, ClientCode As String, Filename As String) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.AgencyDesktopDocument)

            'objects
            Dim DocumentIDs() As Integer = Nothing

            DocumentIDs = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT DOCUMENT_ID FROM dbo.WV_CLIENT_DOCUMENTS WHERE [CL_CODE] = '{0}' and [FILENAME] = '{1}'", ClientCode, Filename)).ToArray

            LoadRelated = From AgencyDesktopDocument In DbContext.GetQuery(Of Database.Entities.AgencyDesktopDocument)
                          Where DocumentIDs.Contains(AgencyDesktopDocument.DocumentID)
                          Select AgencyDesktopDocument

        End Function
        Public Function LoadByDocumentID(DbContext As Database.DbContext, DocumentID As Integer) As AdvantageFramework.Database.Entities.AgencyDesktopDocument

            Try

                LoadByDocumentID = (From AgencyDesktopDocument In DbContext.GetQuery(Of Database.Entities.AgencyDesktopDocument)
                                    Where AgencyDesktopDocument.DocumentID = DocumentID
                                    Select AgencyDesktopDocument).SingleOrDefault

            Catch ex As Exception
                LoadByDocumentID = Nothing
            End Try

        End Function
        Public Function Load(DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AgencyDesktopDocument)

            Load = From AgencyDesktopDocument In DbContext.GetQuery(Of Database.Entities.AgencyDesktopDocument)
                   Select AgencyDesktopDocument

        End Function
        Public Function Insert(DbContext As AdvantageFramework.Database.DbContext, AgencyDesktopDocument As AdvantageFramework.Database.Entities.AgencyDesktopDocument) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.AgencyDesktopDocuments.Add(AgencyDesktopDocument)

                ErrorText = AgencyDesktopDocument.ValidateEntity(IsValid)

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
        Public Function Update(DbContext As AdvantageFramework.Database.DbContext, AgencyDesktopDocument As AdvantageFramework.Database.Entities.AgencyDesktopDocument) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(AgencyDesktopDocument)

                ErrorText = AgencyDesktopDocument.ValidateEntity(IsValid)

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
        Public Function Delete(DbContext As AdvantageFramework.Database.DbContext, AgencyDesktopDocument As AdvantageFramework.Database.Entities.AgencyDesktopDocument) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(AgencyDesktopDocument)

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
