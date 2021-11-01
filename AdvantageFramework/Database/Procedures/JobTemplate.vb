Namespace Database.Procedures.JobTemplate

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

        Public Function LoadByJobTemplateCode(ByVal DbContext As Database.DbContext, ByVal JobTemplateCode As String) As Database.Entities.JobTemplate

            Try

                LoadByJobTemplateCode = (From JobTemplate In DbContext.GetQuery(Of Database.Entities.JobTemplate)
                                         Where JobTemplate.Code = JobTemplateCode
                                         Select JobTemplate).SingleOrDefault

            Catch ex As Exception
                LoadByJobTemplateCode = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.JobTemplate)

            Load = From JobTemplate In DbContext.GetQuery(Of Database.Entities.JobTemplate)
                   Select JobTemplate

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobTemplate As AdvantageFramework.Database.Entities.JobTemplate) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.JobTemplates.Add(JobTemplate)

                ErrorText = JobTemplate.ValidateEntity(IsValid)

                If IsValid Then

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobTemplate As AdvantageFramework.Database.Entities.JobTemplate) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(JobTemplate)

                ErrorText = JobTemplate.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobTemplate As AdvantageFramework.Database.Entities.JobTemplate) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""
            Dim JobCount As Integer = Nothing

            Try

                If JobTemplate.Code.ToUpper = "DFLT" Then

                    IsValid = False
                    ErrorText = "The Default Template cannot be deleted."

                Else

                    Try

                        JobCount = (From Entity In DbContext.GetQuery(Of Database.Entities.JobComponent)
                                    Where Entity.JobTemplateCode = JobTemplate.Code
                                    Select Entity).Count

                    Catch ex As Exception
                        JobCount = Nothing
                    End Try

                    If JobCount > 0 Then

                        IsValid = False
                        ErrorText = String.Format("This template is used on {0} job(s). It cannot be deleted.", JobCount.ToString)

                    End If

                End If

                If IsValid Then

                    If AdvantageFramework.Database.Procedures.JobTemplateDetail.DeleteByJobTemplateCode(DbContext, JobTemplate.Code) Then

                        DbContext.DeleteEntityObject(JobTemplate)

                        DbContext.SaveChanges()

                        Deleted = True

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
