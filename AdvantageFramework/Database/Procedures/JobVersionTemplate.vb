Namespace Database.Procedures.JobVersionTemplate

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

        Public Function Sync(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobVersionTemplateCode As String) As Boolean

            'objects
            Dim Syncd As Boolean = False
            Dim JobVersionIDs() As Integer = Nothing

            Try

                JobVersionIDs = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT JOB_VER_HDR_ID FROM dbo.JOB_VER_HDR WHERE JV_TMPLT_CODE = '{0}'", JobVersionTemplateCode)).ToArray

                For Each JobVersionID In JobVersionIDs

                    DbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO dbo.JOB_VER_DTL([JOB_VER_HDR_ID], [JV_TMPLT_DTL_ID], [JOB_VER_VALUE]) SELECT {0}, JV_TMPLT_DTL_ID, NULL FROM dbo.JOB_VER_TMPLT_DTL WHERE JV_TMPLT_CODE = '{1}' AND JV_TMPLT_DTL_ID NOT IN (SELECT JV_TMPLT_DTL_ID FROM dbo.JOB_VER_DTL WHERE JOB_VER_HDR_ID = {0})", JobVersionID, JobVersionTemplateCode))

                Next

                Syncd = True

            Catch ex As Exception
                Syncd = False
            Finally
                Sync = Syncd
            End Try

        End Function
        Public Function LoadAllActive(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.JobVersionTemplate)

            LoadAllActive = From JobVersionTemplate In DbContext.GetQuery(Of Database.Entities.JobVersionTemplate)
                            Where JobVersionTemplate.IsInactive = 0 OrElse
                                  JobVersionTemplate.IsInactive Is Nothing
                            Select JobVersionTemplate

        End Function
        Public Function LoadByJobVersionTemplateCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobVersionTemplateCode As String) As AdvantageFramework.Database.Entities.JobVersionTemplate

            Try

                LoadByJobVersionTemplateCode = (From JobVersionTemplate In DbContext.GetQuery(Of Database.Entities.JobVersionTemplate)
                                                Where JobVersionTemplate.Code = JobVersionTemplateCode
                                                Select JobVersionTemplate).SingleOrDefault

            Catch ex As Exception
                LoadByJobVersionTemplateCode = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.JobVersionTemplate)

            Load = From JobVersionTemplate In DbContext.GetQuery(Of Database.Entities.JobVersionTemplate)
                   Select JobVersionTemplate

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal JobVersionTemplate As AdvantageFramework.Database.Entities.JobVersionTemplate) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""
            Dim SettingValue As AdvantageFramework.Database.Entities.SettingValue = Nothing

            Try

                DbContext.JobVersionTemplates.Add(JobVersionTemplate)

                ErrorText = JobVersionTemplate.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    Inserted = True

                    Try

                        If JobVersionTemplate.IsInactive.GetValueOrDefault(0) <> 1 Then

                            SettingValue = New AdvantageFramework.Database.Entities.SettingValue

                            SettingValue.DataContext = DataContext

                            SettingValue.SettingCode = AdvantageFramework.Agency.Settings.JR_DFLT_TMPLT.ToString
                            SettingValue.DisplayText = JobVersionTemplate.Description
                            SettingValue.Value = JobVersionTemplate.Code

                            AdvantageFramework.Database.Procedures.SettingValue.Insert(DataContext, SettingValue)

                        End If

                    Catch ex As Exception

                    End Try

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal JobVersionTemplate As AdvantageFramework.Database.Entities.JobVersionTemplate) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""
            Dim SettingValue As AdvantageFramework.Database.Entities.SettingValue = Nothing
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing

            Try

                DbContext.UpdateObject(JobVersionTemplate)

                ErrorText = JobVersionTemplate.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    Updated = True

                    Try

                        If JobVersionTemplate.IsInactive.GetValueOrDefault(0) = 1 Then

                            Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.JR_DFLT_TMPLT.ToString)

                            If Setting IsNot Nothing Then

                                If Setting.Value <> JobVersionTemplate.Code Then

                                    AdvantageFramework.Database.Procedures.SettingValue.DeleteBySettingCodeAndLookupValue(DataContext, AdvantageFramework.Agency.Settings.JR_DFLT_TMPLT.ToString, JobVersionTemplate.Code)

                                End If

                            End If

                        Else

                            If AdvantageFramework.Database.Procedures.SettingValue.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.JR_DFLT_TMPLT.ToString).Any(Function(Entity) Entity.Value.ToString = JobVersionTemplate.Code) = False Then

                                SettingValue = New AdvantageFramework.Database.Entities.SettingValue

                                SettingValue.DataContext = DataContext

                                SettingValue.SettingCode = AdvantageFramework.Agency.Settings.JR_DFLT_TMPLT.ToString
                                SettingValue.DisplayText = JobVersionTemplate.Description
                                SettingValue.Value = JobVersionTemplate.Code

                                AdvantageFramework.Database.Procedures.SettingValue.Insert(DataContext, SettingValue)

                            End If

                        End If

                    Catch ex As Exception

                    End Try

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Updated = False
            Finally
                Update = Updated
            End Try

        End Function
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal JobVersionTemplate As AdvantageFramework.Database.Entities.JobVersionTemplate) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM JOB_VER_HDR WHERE JV_TMPLT_CODE ='{0}'", JobVersionTemplate.Code.Replace("'", "''"))).FirstOrDefault > 0 Then

                    ErrorText = "The job version template is in use and cannot be deleted."
                    IsValid = False

                End If

                If IsValid Then

                    For Each EntityClass In AdvantageFramework.Database.Procedures.JobVersionTemplateDetail.LoadByJobVersionTemplateCode(DbContext, JobVersionTemplate.Code).ToList

                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.JOB_VER_VALUE_LIST WHERE JV_TMPLT_DTL_ID = {0}", EntityClass.ID))

                        DbContext.DeleteEntityObject(EntityClass)

                    Next

                    DbContext.DeleteEntityObject(JobVersionTemplate)

                    DbContext.SaveChanges()

                    Deleted = True

                    Try

                        AdvantageFramework.Database.Procedures.SettingValue.DeleteBySettingCodeAndLookupValue(DataContext, AdvantageFramework.Agency.Settings.JR_DFLT_TMPLT.ToString, JobVersionTemplate.Code)

                    Catch ex As Exception

                    End Try

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

