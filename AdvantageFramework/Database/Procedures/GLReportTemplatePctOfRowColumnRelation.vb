Namespace Database.Procedures.GLReportTemplatePctOfRowColumnRelation

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

        Public Function LoadByGLReportTemplateColumnID(ByVal DbContext As Database.DbContext, ByVal GLReportTemplateColumnID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.GLReportTemplatePctOfRowColumnRelation)

            LoadByGLReportTemplateColumnID = From GLReportTemplatePctOfRowColumnRelation In DbContext.GetQuery(Of Database.Entities.GLReportTemplatePctOfRowColumnRelation)
                                             Where GLReportTemplatePctOfRowColumnRelation.GLReportTemplateColumnID = GLReportTemplateColumnID
                                             Select GLReportTemplatePctOfRowColumnRelation

        End Function
        Public Function LoadByGLReportTemplateID(ByVal DbContext As Database.DbContext, ByVal GLReportTemplateID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.GLReportTemplatePctOfRowColumnRelation)

            LoadByGLReportTemplateID = From GLReportTemplatePctOfRowColumnRelation In DbContext.GetQuery(Of Database.Entities.GLReportTemplatePctOfRowColumnRelation)
                                       Where GLReportTemplatePctOfRowColumnRelation.GLReportTemplateID = GLReportTemplateID
                                       Select GLReportTemplatePctOfRowColumnRelation

        End Function
        Public Function LoadByGLReportTemplatePctOfRowColumnRelationID(ByVal DbContext As Database.DbContext, ByVal GLReportTemplatePctOfRowColumnRelationID As Integer) As Database.Entities.GLReportTemplatePctOfRowColumnRelation

            Try

                LoadByGLReportTemplatePctOfRowColumnRelationID = (From GLReportTemplatePctOfRowColumnRelation In DbContext.GetQuery(Of Database.Entities.GLReportTemplatePctOfRowColumnRelation)
                                                                  Where GLReportTemplatePctOfRowColumnRelation.ID = GLReportTemplatePctOfRowColumnRelationID
                                                                  Select GLReportTemplatePctOfRowColumnRelation).SingleOrDefault

            Catch ex As Exception
                LoadByGLReportTemplatePctOfRowColumnRelationID = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.GLReportTemplatePctOfRowColumnRelation)

            Load = From GLReportTemplatePctOfRowColumnRelation In DbContext.GetQuery(Of Database.Entities.GLReportTemplatePctOfRowColumnRelation)
                   Select GLReportTemplatePctOfRowColumnRelation

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GLReportTemplatePctOfRowColumnRelation As AdvantageFramework.Database.Entities.GLReportTemplatePctOfRowColumnRelation) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.GLReportTemplatePctOfRowColumnRelations.Add(GLReportTemplatePctOfRowColumnRelation)

                ErrorText = GLReportTemplatePctOfRowColumnRelation.ValidateEntity(IsValid)

                If IsValid Then

                    GLReportTemplatePctOfRowColumnRelation.CreatedByUserCode = DbContext.UserCode
                    GLReportTemplatePctOfRowColumnRelation.CreatedDate = Now

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GLReportTemplatePctOfRowColumnRelation As AdvantageFramework.Database.Entities.GLReportTemplatePctOfRowColumnRelation) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(GLReportTemplatePctOfRowColumnRelation)

                ErrorText = GLReportTemplatePctOfRowColumnRelation.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GLReportTemplatePctOfRowColumnRelation As AdvantageFramework.Database.Entities.GLReportTemplatePctOfRowColumnRelation) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(GLReportTemplatePctOfRowColumnRelation)

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
        Public Function DeleteByGLReportTemplateID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GLReportTemplateID As Integer) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.GL_REPORT_PCT_ROW_COL_RELATION WHERE GL_REPORT_ID = {0}", GLReportTemplateID))

                Deleted = True

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteByGLReportTemplateID = Deleted
            End Try

        End Function

#End Region

    End Module

End Namespace
