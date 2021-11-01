Namespace Database.Procedures.GLReportTemplateOfficePreset

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

        Public Function LoadByGLReportTemplateID(ByVal DbContext As Database.DbContext, ByVal GLReportTemplateID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.GLReportTemplateOfficePreset)

            LoadByGLReportTemplateID = From GLReportTemplateOfficePreset In DbContext.GetQuery(Of Database.Entities.GLReportTemplateOfficePreset)
                                       Where GLReportTemplateOfficePreset.GLReportTemplateID = GLReportTemplateID
                                       Select GLReportTemplateOfficePreset

        End Function
        Public Function LoadByGLReportTemplateOfficePresetID(ByVal DbContext As Database.DbContext, ByVal GLReportTemplateOfficePresetID As Integer) As Database.Entities.GLReportTemplateOfficePreset

            Try

                LoadByGLReportTemplateOfficePresetID = (From GLReportTemplateOfficePreset In DbContext.GetQuery(Of Database.Entities.GLReportTemplateOfficePreset)
                                                        Where GLReportTemplateOfficePreset.ID = GLReportTemplateOfficePresetID
                                                        Select GLReportTemplateOfficePreset).SingleOrDefault

            Catch ex As Exception
                LoadByGLReportTemplateOfficePresetID = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.GLReportTemplateOfficePreset)

            Load = From GLReportTemplateOfficePreset In DbContext.GetQuery(Of Database.Entities.GLReportTemplateOfficePreset)
                   Select GLReportTemplateOfficePreset

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GLReportTemplateOfficePreset As AdvantageFramework.Database.Entities.GLReportTemplateOfficePreset) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.GLReportTemplateOfficePresets.Add(GLReportTemplateOfficePreset)

                ErrorText = GLReportTemplateOfficePreset.ValidateEntity(IsValid)

                If IsValid Then

                    GLReportTemplateOfficePreset.CreatedByUserCode = DbContext.UserCode
                    GLReportTemplateOfficePreset.CreatedDate = Now

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GLReportTemplateOfficePreset As AdvantageFramework.Database.Entities.GLReportTemplateOfficePreset) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(GLReportTemplateOfficePreset)

                ErrorText = GLReportTemplateOfficePreset.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GLReportTemplateOfficePreset As AdvantageFramework.Database.Entities.GLReportTemplateOfficePreset) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(GLReportTemplateOfficePreset)

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

                DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.GL_REPORT_PRESET_OFFICE WHERE GL_REPORT_ID = {0}", GLReportTemplateID))

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
