Namespace Database.Procedures.ImportTemplate

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

        Public Function LoadByImportTemplateID(ByVal DbContext As Database.DbContext, ByVal ImportTemplateID As Short) As Database.Entities.ImportTemplate

            Try

                LoadByImportTemplateID = (From ImportTemplate In DbContext.GetQuery(Of Database.Entities.ImportTemplate)
                                          Where ImportTemplate.ID = ImportTemplateID
                                          Select ImportTemplate).SingleOrDefault

            Catch ex As Exception
                LoadByImportTemplateID = Nothing
            End Try

        End Function
        Public Function LoadByImportType(ByVal DbContext As Database.DbContext, ByVal ImportType As Short) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ImportTemplate)

            LoadByImportType = From ImportTemplate In DbContext.GetQuery(Of Database.Entities.ImportTemplate)
                               Where ImportTemplate.Type = ImportType
                               Select ImportTemplate

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ImportTemplate)

            Load = From ImportTemplate In DbContext.GetQuery(Of Database.Entities.ImportTemplate)
                   Select ImportTemplate

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ImportTemplate As AdvantageFramework.Database.Entities.ImportTemplate) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                ImportTemplate.CreatedBy = DbContext.UserCode
                ImportTemplate.CreatedDate = System.DateTime.Now

                DbContext.ImportTemplates.Add(ImportTemplate)

                ErrorText = ImportTemplate.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    DbContext.Database.ExecuteSqlCommand(String.Format("INSERT dbo.ADV_SERVICE_IMPORT (TEMPLATE_ID) VALUES ({0})", ImportTemplate.ID))

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ImportTemplate As AdvantageFramework.Database.Entities.ImportTemplate) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                ImportTemplate.ModifiedBy = DbContext.UserCode
                ImportTemplate.ModifiedDate = System.DateTime.Now

                DbContext.UpdateObject(ImportTemplate)

                ErrorText = ImportTemplate.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ImportTemplate As AdvantageFramework.Database.Entities.ImportTemplate) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""
            Dim ImportTemplateDetail As AdvantageFramework.Database.Entities.ImportTemplateDetail = Nothing
            Dim AdvantageServiceImport As AdvantageFramework.Database.Entities.AdvantageServiceImport = Nothing

            Try

                If IsValid Then

                    For Each ImportTemplateDetail In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.ImportTemplateDetail).Where(Function(ImpTempDtl) ImpTempDtl.TemplateID = ImportTemplate.ID)

                        DbContext.DeleteEntityObject(ImportTemplateDetail)

                    Next

                    Try

                        AdvantageServiceImport = (From Entity In AdvantageFramework.Database.Procedures.AdvantageServiceImport.Load(DbContext) _
                                                  Where Entity.ImportTemplateID = ImportTemplate.ID
                                                  Select Entity).SingleOrDefault

                    Catch ex As Exception
                        AdvantageServiceImport = Nothing
                    End Try

                    If AdvantageServiceImport IsNot Nothing Then

                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.ADV_SERVICE_IMPORT_SETTING WHERE ADV_SERVICE_IMPORT_ID = {0}", AdvantageServiceImport.ID))

                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.ADV_SERVICE_IMPORT WHERE TEMPLATE_ID = {0}", ImportTemplate.ID))

                    End If

                    DbContext.DeleteEntityObject(ImportTemplate)

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
