Namespace Database.Procedures.GLReportTemplateColumn

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

        Public Function LoadByGLReportTemplateID(ByVal DbContext As Database.DbContext, ByVal GLReportTemplateID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.GLReportTemplateColumn)

            LoadByGLReportTemplateID = From GLReportTemplateColumn In DbContext.GetQuery(Of Database.Entities.GLReportTemplateColumn)
                                       Where GLReportTemplateColumn.GLReportTemplateID = GLReportTemplateID
                                       Select GLReportTemplateColumn

        End Function
        Public Function LoadByGLReportTemplateColumnID(ByVal DbContext As Database.DbContext, ByVal GLReportTemplateColumnID As Integer) As Database.Entities.GLReportTemplateColumn

            Try

                LoadByGLReportTemplateColumnID = (From GLReportTemplateColumn In DbContext.GetQuery(Of Database.Entities.GLReportTemplateColumn)
                                                  Where GLReportTemplateColumn.ID = GLReportTemplateColumnID
                                                  Select GLReportTemplateColumn).SingleOrDefault

            Catch ex As Exception
                LoadByGLReportTemplateColumnID = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.GLReportTemplateColumn)

            Load = From GLReportTemplateColumn In DbContext.GetQuery(Of Database.Entities.GLReportTemplateColumn)
                   Select GLReportTemplateColumn

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GLReportTemplateColumn As AdvantageFramework.Database.Entities.GLReportTemplateColumn) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.GLReportTemplateColumns.Add(GLReportTemplateColumn)

                ErrorText = GLReportTemplateColumn.ValidateEntity(IsValid)

                If IsValid Then

                    GLReportTemplateColumn.CreatedByUserCode = DbContext.UserCode
                    GLReportTemplateColumn.CreatedDate = Now

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GLReportTemplateColumn As AdvantageFramework.Database.Entities.GLReportTemplateColumn) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(GLReportTemplateColumn)

                ErrorText = GLReportTemplateColumn.ValidateEntity(IsValid)

                If IsValid Then

                    GLReportTemplateColumn.ModifiedByUserCode = DbContext.UserCode
                    GLReportTemplateColumn.ModifiedDate = Now

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GLReportTemplateColumn As AdvantageFramework.Database.Entities.GLReportTemplateColumn) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(GLReportTemplateColumn)

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

                DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.GL_REPORT_COLUMN WHERE GL_REPORT_ID = {0}", GLReportTemplateID))

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
