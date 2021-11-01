Namespace Database.Procedures.ExportTemplate

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

        Public Function LoadByType(ByVal DbContext As Database.DbContext, ByVal [Type] As Short) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ExportTemplate)

            LoadByType = From ExportTemplate In DbContext.GetQuery(Of Database.Entities.ExportTemplate)
                         Where ExportTemplate.[Type] = [Type]
                         Select ExportTemplate

        End Function
        Public Function LoadByExportTemplateID(ByVal DbContext As Database.DbContext, ByVal ExportTemplateID As Integer) As Database.Entities.ExportTemplate

            Try

                LoadByExportTemplateID = (From ExportTemplate In DbContext.GetQuery(Of Database.Entities.ExportTemplate)
                                          Where ExportTemplate.ID = ExportTemplateID
                                          Select ExportTemplate).SingleOrDefault

            Catch ex As Exception
                LoadByExportTemplateID = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ExportTemplate)

            Load = From ExportTemplate In DbContext.GetQuery(Of Database.Entities.ExportTemplate)
                   Select ExportTemplate

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ExportTemplate As AdvantageFramework.Database.Entities.ExportTemplate) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.ExportTemplates.Add(ExportTemplate)

                ErrorText = ExportTemplate.ValidateEntity(IsValid)

                If IsValid Then

                    ExportTemplate.CreatedByUserCode = DbContext.UserCode
                    ExportTemplate.CreatedDate = Now

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ExportTemplate As AdvantageFramework.Database.Entities.ExportTemplate) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(ExportTemplate)

                ErrorText = ExportTemplate.ValidateEntity(IsValid)

                If IsValid Then

                    ExportTemplate.ModifiedByUserCode = DbContext.UserCode
                    ExportTemplate.ModifiedDate = Now

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ExportTemplate As AdvantageFramework.Database.Entities.ExportTemplate) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing

            Try

                If IsValid Then

                    DbContext.Database.Connection.Open()

                    DbTransaction = DbContext.Database.BeginTransaction

                    Try

                        If AdvantageFramework.Database.Procedures.ExportTemplateDetail.DeleteByExportTemplateID(DbContext, ExportTemplate.ID) Then

                            DbContext.DeleteEntityObject(ExportTemplate)

                            DbContext.SaveChanges()

                            Deleted = True

                        End If

                    Catch ex As Exception
                        Deleted = False
                    End Try

                    If Deleted Then

                        DbTransaction.Commit()

                    Else

                        DbTransaction.Rollback()

                    End If

                    DbContext.Database.Connection.Close()

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
