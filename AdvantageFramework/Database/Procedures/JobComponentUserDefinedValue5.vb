Namespace Database.Procedures.JobComponentUserDefinedValue5

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.JobComponentUserDefinedValue5)

            Load = From JobComponentUserDefinedValue5 In DbContext.JobComponentUserDefinedValue5
                   Select JobComponentUserDefinedValue5

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobComponentUserDefinedValue5 As AdvantageFramework.Database.Entities.JobComponentUserDefinedValue5) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.JobComponentUserDefinedValue5.Add(JobComponentUserDefinedValue5)

                ErrorText = JobComponentUserDefinedValue5.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobComponentUserDefinedValue5 As AdvantageFramework.Database.Entities.JobComponentUserDefinedValue5) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(JobComponentUserDefinedValue5)

                ErrorText = JobComponentUserDefinedValue5.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobComponentUserDefinedValue5 As AdvantageFramework.Database.Entities.JobComponentUserDefinedValue5) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(JobComponentUserDefinedValue5)

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
        Public Function DeleteAll(ByVal DbContext As AdvantageFramework.Database.DbContext) As Boolean

            'objects
            Dim Deleted As Boolean = False

            Try

                DbContext.Database.ExecuteSqlCommand("DELETE FROM dbo.JOB_CMP_UDV5")

                Deleted = True

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteAll = Deleted
            End Try

        End Function

#End Region

    End Module

End Namespace
