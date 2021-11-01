Namespace Database.Procedures.AccountReceivableImportStaging

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

        Public Function LoadLegacyUnprocessedEntries(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AccountReceivableImportStaging)

            LoadLegacyUnprocessedEntries = From AccountReceivableImportStaging In DbContext.GetQuery(Of Database.Entities.AccountReceivableImportStaging)
                                           Where AccountReceivableImportStaging.BatchName Is Nothing AndAlso
                                                 AccountReceivableImportStaging.PostFlag Is Nothing
                                           Select AccountReceivableImportStaging

        End Function
        Public Function LoadByBatchName(ByVal DbContext As Database.DbContext, ByVal BatchName As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AccountReceivableImportStaging)

            LoadByBatchName = From AccountReceivableImportStaging In DbContext.GetQuery(Of Database.Entities.AccountReceivableImportStaging)
                              Where AccountReceivableImportStaging.BatchName = BatchName
                              Select AccountReceivableImportStaging

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AccountReceivableImportStaging)

            Load = From AccountReceivableImportStaging In DbContext.GetQuery(Of Database.Entities.AccountReceivableImportStaging)
                   Select AccountReceivableImportStaging

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AccountReceivableImportStaging As AdvantageFramework.Database.Entities.AccountReceivableImportStaging) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.AccountReceivableImportStagings.Add(AccountReceivableImportStaging)

                ErrorText = AccountReceivableImportStaging.ValidateEntity(IsValid)

                If IsValid Then

                    Try

                        AccountReceivableImportStaging.RecordNumber = (From Entity In Load(DbContext) _
                                                                       Select Entity.RecordNumber).Max + 1

                    Catch ex As Exception
                        AccountReceivableImportStaging.RecordNumber = 1
                    End Try
                    
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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AccountReceivableImportStaging As AdvantageFramework.Database.Entities.AccountReceivableImportStaging) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(AccountReceivableImportStaging)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AccountReceivableImportStaging As AdvantageFramework.Database.Entities.AccountReceivableImportStaging) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(AccountReceivableImportStaging)

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
