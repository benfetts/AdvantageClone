Namespace Database.Procedures.GLReportTemplateRowRelation

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

        Public Function LoadByGLReportTemplateRowID(ByVal DbContext As Database.DbContext, ByVal GLReportTemplateRowID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.GLReportTemplateRowRelation)

            LoadByGLReportTemplateRowID = From GLReportTemplateRowRelation In DbContext.GetQuery(Of Database.Entities.GLReportTemplateRowRelation)
                                          Where GLReportTemplateRowRelation.GLReportTemplateRowID = GLReportTemplateRowID
                                          Select GLReportTemplateRowRelation

        End Function
        Public Function LoadByGLReportTemplateID(ByVal DbContext As Database.DbContext, ByVal GLReportTemplateID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.GLReportTemplateRowRelation)

            LoadByGLReportTemplateID = From GLReportTemplateRowRelation In DbContext.GetQuery(Of Database.Entities.GLReportTemplateRowRelation)
                                       Where GLReportTemplateRowRelation.GLReportTemplateID = GLReportTemplateID
                                       Select GLReportTemplateRowRelation

        End Function
        Public Function LoadByGLReportTemplateRowRelationID(ByVal DbContext As Database.DbContext, ByVal GLReportTemplateRowRelationID As Integer) As Database.Entities.GLReportTemplateRowRelation

            Try

                LoadByGLReportTemplateRowRelationID = (From GLReportTemplateRowRelation In DbContext.GetQuery(Of Database.Entities.GLReportTemplateRowRelation)
                                                       Where GLReportTemplateRowRelation.ID = GLReportTemplateRowRelationID
                                                       Select GLReportTemplateRowRelation).SingleOrDefault

            Catch ex As Exception
                LoadByGLReportTemplateRowRelationID = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.GLReportTemplateRowRelation)

            Load = From GLReportTemplateRowRelation In DbContext.GetQuery(Of Database.Entities.GLReportTemplateRowRelation)
                   Select GLReportTemplateRowRelation

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GLReportTemplateRowRelation As AdvantageFramework.Database.Entities.GLReportTemplateRowRelation) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.GLReportTemplateRowRelations.Add(GLReportTemplateRowRelation)

                ErrorText = GLReportTemplateRowRelation.ValidateEntity(IsValid)

                If IsValid Then

                    GLReportTemplateRowRelation.CreatedByUserCode = DbContext.UserCode
                    GLReportTemplateRowRelation.CreatedDate = Now

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GLReportTemplateRowRelation As AdvantageFramework.Database.Entities.GLReportTemplateRowRelation) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(GLReportTemplateRowRelation)

                ErrorText = GLReportTemplateRowRelation.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GLReportTemplateRowRelation As AdvantageFramework.Database.Entities.GLReportTemplateRowRelation) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(GLReportTemplateRowRelation)

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

                DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.GL_REPORT_ROW_RELATION WHERE GL_REPORT_ID = {0}", GLReportTemplateID))

                Deleted = True

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteByGLReportTemplateID = Deleted
            End Try

        End Function
        Public Function DeleteByGLReportTemplateRowID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GLReportTemplateRowID As Integer) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.GL_REPORT_ROW_RELATION WHERE GL_REPORT_ROW_ID = {0}", GLReportTemplateRowID))

                Deleted = True

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteByGLReportTemplateRowID = Deleted
            End Try

        End Function

#End Region

    End Module

End Namespace
