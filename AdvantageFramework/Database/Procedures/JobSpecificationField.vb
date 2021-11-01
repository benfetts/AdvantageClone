Namespace Database.Procedures.JobSpecificationField

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

        Public Function LoadByFieldNameAndJobSpecificationTypeCode(ByVal DbContext As Database.DbContext, ByVal FieldName As String, ByVal JobSpecificationTypeCode As String) As Database.Entities.JobSpecificationField

            Try

                LoadByFieldNameAndJobSpecificationTypeCode = (From JobSpecificationField In DbContext.GetQuery(Of Database.Entities.JobSpecificationField)
                                                              Where JobSpecificationField.JobSpecificationTypeCode = JobSpecificationTypeCode AndAlso
                                                                    JobSpecificationField.Name = FieldName
                                                              Select JobSpecificationField).SingleOrDefault

            Catch ex As Exception
                LoadByFieldNameAndJobSpecificationTypeCode = Nothing
            End Try

        End Function
        Public Function LoadByJobSpecificationCategoryID(ByVal DbContext As Database.DbContext, ByVal JobSpecificationCategoryID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.JobSpecificationField)

            LoadByJobSpecificationCategoryID = From JobSpecificationField In DbContext.GetQuery(Of Database.Entities.JobSpecificationField)
                                               Where JobSpecificationField.JobSpecificationCategoryID = JobSpecificationCategoryID
                                               Select JobSpecificationField

        End Function
        Public Function LoadByJobSpecificationTypeCode(ByVal DbContext As Database.DbContext, ByVal JobSpecificationTypeCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.JobSpecificationField)

            LoadByJobSpecificationTypeCode = From JobSpecificationField In DbContext.GetQuery(Of Database.Entities.JobSpecificationField)
                                             Where JobSpecificationField.JobSpecificationTypeCode = JobSpecificationTypeCode
                                             Select JobSpecificationField

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.JobSpecificationField)

            Load = From JobSpecificationField In DbContext.GetQuery(Of Database.Entities.JobSpecificationField)
                   Select JobSpecificationField

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobSpecificationField As AdvantageFramework.Database.Entities.JobSpecificationField) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                Try

                    JobSpecificationField.SequenceNumber = (From Entity In LoadByJobSpecificationCategoryID(DbContext, JobSpecificationField.JobSpecificationCategoryID).ToList
                                                            Select Entity.SequenceNumber).Max + 1

                Catch ex As Exception
                    JobSpecificationField.SequenceNumber = 1
                End Try

                DbContext.JobSpecificationFields.Add(JobSpecificationField)

                ErrorText = JobSpecificationField.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobSpecificationField As AdvantageFramework.Database.Entities.JobSpecificationField) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(JobSpecificationField)

                ErrorText = JobSpecificationField.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobSpecificationField As AdvantageFramework.Database.Entities.JobSpecificationField) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(JobSpecificationField)

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
