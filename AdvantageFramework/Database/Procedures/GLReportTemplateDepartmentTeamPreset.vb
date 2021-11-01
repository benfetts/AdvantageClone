Namespace Database.Procedures.GLReportTemplateDepartmentTeamPreset

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

        Public Function LoadByGLReportTemplateID(ByVal DbContext As Database.DbContext, ByVal GLReportTemplateID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.GLReportTemplateDepartmentTeamPreset)

            LoadByGLReportTemplateID = From GLReportTemplateDepartmentTeamPreset In DbContext.GetQuery(Of Database.Entities.GLReportTemplateDepartmentTeamPreset)
                                       Where GLReportTemplateDepartmentTeamPreset.GLReportTemplateID = GLReportTemplateID
                                       Select GLReportTemplateDepartmentTeamPreset

        End Function
        Public Function LoadByGLReportTemplateDepartmentTeamPresetID(ByVal DbContext As Database.DbContext, ByVal GLReportTemplateDepartmentTeamPresetID As Integer) As Database.Entities.GLReportTemplateDepartmentTeamPreset

            Try

                LoadByGLReportTemplateDepartmentTeamPresetID = (From GLReportTemplateDepartmentTeamPreset In DbContext.GetQuery(Of Database.Entities.GLReportTemplateDepartmentTeamPreset)
                                                                Where GLReportTemplateDepartmentTeamPreset.ID = GLReportTemplateDepartmentTeamPresetID
                                                                Select GLReportTemplateDepartmentTeamPreset).SingleOrDefault

            Catch ex As Exception
                LoadByGLReportTemplateDepartmentTeamPresetID = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.GLReportTemplateDepartmentTeamPreset)

            Load = From GLReportTemplateDepartmentTeamPreset In DbContext.GetQuery(Of Database.Entities.GLReportTemplateDepartmentTeamPreset)
                   Select GLReportTemplateDepartmentTeamPreset

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GLReportTemplateDepartmentTeamPreset As AdvantageFramework.Database.Entities.GLReportTemplateDepartmentTeamPreset) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.GLReportTemplateDepartmentTeamPresets.Add(GLReportTemplateDepartmentTeamPreset)

                ErrorText = GLReportTemplateDepartmentTeamPreset.ValidateEntity(IsValid)

                If IsValid Then

                    GLReportTemplateDepartmentTeamPreset.CreatedByUserCode = DbContext.UserCode
                    GLReportTemplateDepartmentTeamPreset.CreatedDate = Now

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GLReportTemplateDepartmentTeamPreset As AdvantageFramework.Database.Entities.GLReportTemplateDepartmentTeamPreset) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(GLReportTemplateDepartmentTeamPreset)

                ErrorText = GLReportTemplateDepartmentTeamPreset.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GLReportTemplateDepartmentTeamPreset As AdvantageFramework.Database.Entities.GLReportTemplateDepartmentTeamPreset) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(GLReportTemplateDepartmentTeamPreset)

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

                DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.GL_REPORT_PRESET_DEPT WHERE GL_REPORT_ID = {0}", GLReportTemplateID))

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
