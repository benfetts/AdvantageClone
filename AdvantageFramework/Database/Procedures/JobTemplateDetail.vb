Namespace Database.Procedures.JobTemplateDetail

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

        Public Function LoadByJobTemplateCode(ByVal DbContext As Database.DbContext, ByVal JobTemplateCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.JobTemplateDetail)

            LoadByJobTemplateCode = From JobTemplateDetail In DbContext.GetQuery(Of Database.Entities.JobTemplateDetail)
                                    Where JobTemplateDetail.JobTemplateCode = JobTemplateCode
                                    Select JobTemplateDetail

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.JobTemplateDetail)

            Load = From JobTemplateDetail In DbContext.GetQuery(Of Database.Entities.JobTemplateDetail)
                   Select JobTemplateDetail

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobTemplateDetail As AdvantageFramework.Database.Entities.JobTemplateDetail) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.JobTemplateDetails.Add(JobTemplateDetail)

                ErrorText = JobTemplateDetail.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobTemplateDetail As AdvantageFramework.Database.Entities.JobTemplateDetail) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(JobTemplateDetail)

                ErrorText = JobTemplateDetail.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobTemplateDetail As AdvantageFramework.Database.Entities.JobTemplateDetail) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(JobTemplateDetail)

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
        Public Function DeleteByJobTemplateCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobTemplateCode As String) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    For Each EntityClass In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.JobTemplateDetail).Where(Function(JobTempDtl) JobTempDtl.JobTemplateCode = JobTemplateCode)

                        DbContext.DeleteEntityObject(EntityClass)

                    Next

                    DbContext.SaveChanges()

                    Deleted = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteByJobTemplateCode = Deleted
            End Try

        End Function

#End Region

    End Module

End Namespace
