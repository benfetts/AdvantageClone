Namespace Database.Procedures.ImportEmployeeHoursStaging

    <HideModuleName()>
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

        Public Function Load(DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ImportEmployeeHoursStaging)

            Load = From ImportEmployeeHoursStaging In DbContext.GetQuery(Of Database.Entities.ImportEmployeeHoursStaging)
                   Select ImportEmployeeHoursStaging

        End Function
        Public Function LoadByBatchName(DbContext As Database.DbContext, BatchName As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ImportEmployeeHoursStaging)

            LoadByBatchName = From ImportEmployeeHoursStaging In DbContext.GetQuery(Of Database.Entities.ImportEmployeeHoursStaging)
                              Where ImportEmployeeHoursStaging.BatchName = BatchName
                              Select ImportEmployeeHoursStaging

        End Function
        Public Function Insert(DbContext As AdvantageFramework.Database.DbContext, ImportEmployeeHoursStaging As AdvantageFramework.Database.Entities.ImportEmployeeHoursStaging) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.ImportEmployeeHoursStagings.Add(ImportEmployeeHoursStaging)

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
        Public Function Delete(DbContext As AdvantageFramework.Database.DbContext, ImportEmployeeHoursStaging As AdvantageFramework.Database.Entities.ImportEmployeeHoursStaging) As Boolean

            'objects
            Dim Deleted As Boolean = True
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(ImportEmployeeHoursStaging)

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