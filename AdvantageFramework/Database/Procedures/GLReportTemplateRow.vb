Namespace Database.Procedures.GLReportTemplateRow

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

        Public Function LoadByGLReportTemplateID(ByVal DbContext As Database.DbContext, ByVal GLReportTemplateID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.GLReportTemplateRow)

            LoadByGLReportTemplateID = From GLReportTemplateRow In DbContext.GetQuery(Of Database.Entities.GLReportTemplateRow)
                                       Where GLReportTemplateRow.GLReportTemplateID = GLReportTemplateID
                                       Select GLReportTemplateRow

        End Function
        Public Function LoadByGLReportTemplateRowID(ByVal DbContext As Database.DbContext, ByVal GLReportTemplateRowID As Integer) As Database.Entities.GLReportTemplateRow

            Try

                LoadByGLReportTemplateRowID = (From GLReportTemplateRow In DbContext.GetQuery(Of Database.Entities.GLReportTemplateRow)
                                               Where GLReportTemplateRow.ID = GLReportTemplateRowID
                                               Select GLReportTemplateRow).SingleOrDefault

            Catch ex As Exception
                LoadByGLReportTemplateRowID = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.GLReportTemplateRow)

            Load = From GLReportTemplateRow In DbContext.GetQuery(Of Database.Entities.GLReportTemplateRow)
                   Select GLReportTemplateRow

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GLReportTemplateRow As AdvantageFramework.Database.Entities.GLReportTemplateRow) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.GLReportTemplateRows.Add(GLReportTemplateRow)

                ErrorText = GLReportTemplateRow.ValidateEntity(IsValid)

                If IsValid Then

                    GLReportTemplateRow.CreatedByUserCode = DbContext.UserCode
                    GLReportTemplateRow.CreatedDate = Now

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GLReportTemplateRow As AdvantageFramework.Database.Entities.GLReportTemplateRow) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(GLReportTemplateRow)

                ErrorText = GLReportTemplateRow.ValidateEntity(IsValid)

                If IsValid Then

                    GLReportTemplateRow.ModifiedByUserCode = DbContext.UserCode
                    GLReportTemplateRow.ModifiedDate = Now

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GLReportTemplateRow As AdvantageFramework.Database.Entities.GLReportTemplateRow) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                IsValid = AdvantageFramework.Database.Procedures.GLReportTemplateRowRelation.DeleteByGLReportTemplateRowID(DbContext, GLReportTemplateRow.ID)

                If IsValid Then

                    DbContext.DeleteEntityObject(GLReportTemplateRow)

                    DbContext.SaveChanges()

                    Deleted = True

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

                If AdvantageFramework.Database.Procedures.GLReportTemplateRowRelation.DeleteByGLReportTemplateID(DbContext, GLReportTemplateID) Then

                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.GL_REPORT_ROW WHERE GL_REPORT_ID = {0}", GLReportTemplateID))

                    Deleted = True

                End If

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteByGLReportTemplateID = Deleted
            End Try

        End Function

#End Region

	End Module

End Namespace
