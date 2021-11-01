Namespace Database.Procedures.JobSpecificationCategory

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

        Public Function LoadByID(ByVal DbContext As Database.DbContext, ByVal CategoryID As Integer) As Database.Entities.JobSpecificationCategory

            Try

                LoadByID = (From JobSpecificationCategory In DbContext.GetQuery(Of Database.Entities.JobSpecificationCategory)
                            Where JobSpecificationCategory.ID = CategoryID
                            Select JobSpecificationCategory).SingleOrDefault

            Catch ex As Exception
                LoadByID = Nothing
            End Try

        End Function
        Public Function LoadByJobSpecificationTypeCode(ByVal DbContext As Database.DbContext, ByVal JobSpecificationTypeCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.JobSpecificationCategory)

            LoadByJobSpecificationTypeCode = From JobSpecificationCategory In DbContext.GetQuery(Of Database.Entities.JobSpecificationCategory)
                                             Where JobSpecificationCategory.JobSpecificationTypeCode = JobSpecificationTypeCode
                                             Select JobSpecificationCategory

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.JobSpecificationCategory)

            Load = From JobSpecificationCategory In DbContext.GetQuery(Of Database.Entities.JobSpecificationCategory)
                   Select JobSpecificationCategory

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobSpecificationCategory As AdvantageFramework.Database.Entities.JobSpecificationCategory) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                Try

                    JobSpecificationCategory.SequenceNumber = (From Entity In LoadByJobSpecificationTypeCode(DbContext, JobSpecificationCategory.JobSpecificationTypeCode).ToList _
                                                               Select Entity.SequenceNumber).Max + 1

                Catch ex As Exception
                    JobSpecificationCategory.SequenceNumber = 1
                End Try

                Try

                    JobSpecificationCategory.ID = (From Entity In Load(DbContext).ToList _
                                                   Select Entity.ID).Max + 1

                Catch ex As Exception
                    JobSpecificationCategory.ID = 1
                End Try

                DbContext.JobSpecificationCategories.Add(JobSpecificationCategory)

                ErrorText = JobSpecificationCategory.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobSpecificationCategory As AdvantageFramework.Database.Entities.JobSpecificationCategory) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(JobSpecificationCategory)

                ErrorText = JobSpecificationCategory.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobSpecificationCategory As AdvantageFramework.Database.Entities.JobSpecificationCategory) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(JobSpecificationCategory)

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

#End Region

    End Module

End Namespace