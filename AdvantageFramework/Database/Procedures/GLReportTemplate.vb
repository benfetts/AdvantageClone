Namespace Database.Procedures.GLReportTemplate

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

        Public Function LoadByGLReportTemplateID(ByVal DbContext As Database.DbContext, ByVal GLReportTemplateID As Integer) As Database.Entities.GLReportTemplate

            Try

                LoadByGLReportTemplateID = (From GLReportTemplate In DbContext.GetQuery(Of Database.Entities.GLReportTemplate)
                                            Where GLReportTemplate.ID = GLReportTemplateID
                                            Select GLReportTemplate).SingleOrDefault

            Catch ex As Exception
                LoadByGLReportTemplateID = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.GLReportTemplate)

            Load = From GLReportTemplate In DbContext.GetQuery(Of Database.Entities.GLReportTemplate)
                   Select GLReportTemplate

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GLReportTemplate As AdvantageFramework.Database.Entities.GLReportTemplate) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.GLReportTemplates.Add(GLReportTemplate)

                ErrorText = GLReportTemplate.ValidateEntity(IsValid)

                If IsValid Then

                    GLReportTemplate.CreatedByUserCode = DbContext.UserCode
                    GLReportTemplate.CreatedDate = Now

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GLReportTemplate As AdvantageFramework.Database.Entities.GLReportTemplate) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(GLReportTemplate)

                ErrorText = GLReportTemplate.ValidateEntity(IsValid)

                If IsValid Then

                    GLReportTemplate.ModifiedByUserCode = DbContext.UserCode
                    GLReportTemplate.ModifiedDate = Now

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GLReportTemplate As AdvantageFramework.Database.Entities.GLReportTemplate) As Boolean

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

                        If AdvantageFramework.Database.Procedures.GLReportTemplateDepartmentTeamPreset.DeleteByGLReportTemplateID(DbContext, GLReportTemplate.ID) Then

                            If AdvantageFramework.Database.Procedures.GLReportTemplateOfficePreset.DeleteByGLReportTemplateID(DbContext, GLReportTemplate.ID) Then

                                If AdvantageFramework.Database.Procedures.GLReportTemplateRowRelation.DeleteByGLReportTemplateID(DbContext, GLReportTemplate.ID) Then

                                    If AdvantageFramework.Database.Procedures.GLReportTemplateRow.DeleteByGLReportTemplateID(DbContext, GLReportTemplate.ID) Then

                                        If AdvantageFramework.Database.Procedures.GLReportTemplatePctOfRowColumnRelation.DeleteByGLReportTemplateID(DbContext, GLReportTemplate.ID) Then

                                            If AdvantageFramework.Database.Procedures.GLReportTemplateColumn.DeleteByGLReportTemplateID(DbContext, GLReportTemplate.ID) Then

                                                DbContext.DeleteEntityObject(GLReportTemplate)

                                                DbContext.SaveChanges()

                                                Deleted = True

                                            End If

                                        End If

                                    End If

                                End If

                            End If

                        End If

                    Catch ex As Exception
                        Deleted = False
                    End Try

                    If Deleted Then

                        DbTransaction.Commit()

                    Else

                        DbTransaction.Rollback()

                    End If

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
