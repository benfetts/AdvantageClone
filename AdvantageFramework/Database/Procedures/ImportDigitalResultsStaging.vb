Namespace Database.Procedures.ImportDigitalResultsStaging

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ImportDigitalResultsStaging)

            Load = From ImportDigitalResultsStaging In DbContext.GetQuery(Of Database.Entities.ImportDigitalResultsStaging)
                   Select ImportDigitalResultsStaging

        End Function
        Public Function LoadByID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ID As Long) As AdvantageFramework.Database.Entities.ImportDigitalResultsStaging

            LoadByID = (From ImportDigitalResultsStaging In DbContext.GetQuery(Of Database.Entities.ImportDigitalResultsStaging)
                        Where ImportDigitalResultsStaging.ID = ID
                        Select ImportDigitalResultsStaging).SingleOrDefault

        End Function
        Public Function LoadByBatchName(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal BatchName As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ImportDigitalResultsStaging)

            LoadByBatchName = From ImportDigitalResultsStaging In DbContext.GetQuery(Of Database.Entities.ImportDigitalResultsStaging)
                              Where ImportDigitalResultsStaging.BatchName = BatchName
                              Select ImportDigitalResultsStaging

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ImportDigitalResultsStaging As AdvantageFramework.Database.Entities.ImportDigitalResultsStaging) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.ImportDigitalResultsStagings.Add(ImportDigitalResultsStaging)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ImportDigitalResultsStaging As AdvantageFramework.Database.Entities.ImportDigitalResultsStaging) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(ImportDigitalResultsStaging)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ImportDigitalResultsStaging As AdvantageFramework.Database.Entities.ImportDigitalResultsStaging) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(ImportDigitalResultsStaging)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, _
                               ByVal ImportDigitalResultsStagingID As Integer) As Boolean

            'objects
            Dim ImportDigitalResultsStaging As AdvantageFramework.Database.Entities.ImportDigitalResultsStaging = Nothing

            ImportDigitalResultsStaging = LoadByID(DbContext, ImportDigitalResultsStagingID)

            Delete = Delete(DbContext, ImportDigitalResultsStaging)

        End Function

#End Region

    End Module

End Namespace