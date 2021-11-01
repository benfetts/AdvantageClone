Namespace Database.Procedures.JobSpecificationType

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

        Public Function LoadByJobSpecificationTypeCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobSpecificationTypeCode As String) As AdvantageFramework.Database.Entities.JobSpecificationType

            Try

                LoadByJobSpecificationTypeCode = (From JobSpecificationType In DbContext.GetQuery(Of Database.Entities.JobSpecificationType)
                                                  Where JobSpecificationType.Code = JobSpecificationTypeCode
                                                  Select JobSpecificationType).SingleOrDefault

            Catch ex As Exception
                LoadByJobSpecificationTypeCode = Nothing
            End Try

        End Function
        Public Function LoadAllActive(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.JobSpecificationType)

            LoadAllActive = From JobSpecificationType In DbContext.GetQuery(Of Database.Entities.JobSpecificationType)
                            Where JobSpecificationType.IsInactive = 0
                            Select JobSpecificationType

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.JobSpecificationType)

            Load = From JobSpecificationType In DbContext.GetQuery(Of Database.Entities.JobSpecificationType)
                   Select JobSpecificationType

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobSpecificationType As AdvantageFramework.Database.Entities.JobSpecificationType) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.JobSpecificationTypes.Add(JobSpecificationType)

                ErrorText = JobSpecificationType.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobSpecificationType As AdvantageFramework.Database.Entities.JobSpecificationType) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(JobSpecificationType)

                ErrorText = JobSpecificationType.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobSpecificationType As AdvantageFramework.Database.Entities.JobSpecificationType) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.JOB_SPECS WHERE SPEC_TYPE_CODE = '{0}'", JobSpecificationType.Code)).SingleOrDefault > 0 Then

                        'ErrorText = "Code is in use and cannot be deleted."
                        IsValid = False

                    End If

                    If IsValid Then

                        For Each EntityClass In AdvantageFramework.Database.Procedures.JobSpecificationField.LoadByJobSpecificationTypeCode(DbContext, JobSpecificationType.Code).ToList

                            DbContext.DeleteEntityObject(EntityClass)

                        Next

                        For Each EntityClass In AdvantageFramework.Database.Procedures.JobSpecificationCategory.LoadByJobSpecificationTypeCode(DbContext, JobSpecificationType.Code).ToList

                            DbContext.DeleteEntityObject(EntityClass)

                        Next

                        DbContext.DeleteEntityObject(JobSpecificationType)

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
