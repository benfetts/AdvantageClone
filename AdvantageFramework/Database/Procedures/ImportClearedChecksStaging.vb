Namespace Database.Procedures.ImportClearedChecksStaging

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

        Public Function LoadByImportClearedChecksStagingID(ByVal DbContext As Database.DbContext, ByVal ImportClearedChecksStagingID As Integer) As Database.Entities.ImportClearedChecksStaging

            Try

                LoadByImportClearedChecksStagingID = (From ImportClearedChecksStaging In DbContext.GetQuery(Of Database.Entities.ImportClearedChecksStaging)
                                                      Where ImportClearedChecksStaging.ID = ImportClearedChecksStagingID
                                                      Select ImportClearedChecksStaging).SingleOrDefault

            Catch ex As Exception
                LoadByImportClearedChecksStagingID = Nothing
            End Try

        End Function
        Public Function LoadByBatchName(ByVal DbContext As Database.DbContext, ByVal BatchName As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ImportClearedChecksStaging)

            LoadByBatchName = From ImportClearedChecksStaging In DbContext.GetQuery(Of Database.Entities.ImportClearedChecksStaging)
                              Where ImportClearedChecksStaging.BatchName = BatchName
                              Select ImportClearedChecksStaging

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ImportClearedChecksStaging)

            Load = From ImportClearedChecksStaging In DbContext.GetQuery(Of Database.Entities.ImportClearedChecksStaging)
                   Select ImportClearedChecksStaging

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ImportClearedChecksStaging As AdvantageFramework.Database.Entities.ImportClearedChecksStaging) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.ImportClearedChecksStagings.Add(ImportClearedChecksStaging)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ImportClearedChecksStaging As AdvantageFramework.Database.Entities.ImportClearedChecksStaging) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(ImportClearedChecksStaging)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ImportClearedChecksStaging As AdvantageFramework.Database.Entities.ImportClearedChecksStaging) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(ImportClearedChecksStaging)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal BatchName As String) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    For Each EntityClass In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.ImportClearedChecksStaging).Where(Function(ImpCCStaging) ImpCCStaging.BatchName = BatchName).ToList

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
                Delete = Deleted
            End Try

        End Function

#End Region

    End Module

End Namespace
