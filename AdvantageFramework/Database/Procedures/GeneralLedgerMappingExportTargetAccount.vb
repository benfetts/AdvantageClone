Namespace Database.Procedures.GeneralLedgerMappingExportTargetAccount

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

        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.GeneralLedgerMappingExportTargetAccount)

            Load = From GeneralLedgerMappingExportTargetAccount In DbContext.GetQuery(Of Database.Entities.GeneralLedgerMappingExportTargetAccount)
                   Select GeneralLedgerMappingExportTargetAccount

        End Function
        Public Function LoadByID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ID As Integer) As AdvantageFramework.Database.Entities.GeneralLedgerMappingExportTargetAccount

            LoadByID = (From GeneralLedgerMappingExportTargetAccount In DbContext.GetQuery(Of Database.Entities.GeneralLedgerMappingExportTargetAccount)
                        Where GeneralLedgerMappingExportTargetAccount.ID = ID
                        Select GeneralLedgerMappingExportTargetAccount).SingleOrDefault

        End Function
        Public Function LoadByRecordSourceID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal RecordSourceID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.GeneralLedgerMappingExportTargetAccount)

            LoadByRecordSourceID = From GeneralLedgerMappingExportTargetAccount In DbContext.GetQuery(Of Database.Entities.GeneralLedgerMappingExportTargetAccount)
                                   Where GeneralLedgerMappingExportTargetAccount.RecordSourceID = RecordSourceID
                                   Select GeneralLedgerMappingExportTargetAccount

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GeneralLedgerMappingExportTargetAccount As AdvantageFramework.Database.Entities.GeneralLedgerMappingExportTargetAccount) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.GeneralLedgerMappingExportTargetAccounts.Add(GeneralLedgerMappingExportTargetAccount)

                ErrorText = GeneralLedgerMappingExportTargetAccount.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GeneralLedgerMappingExportTargetAccount As AdvantageFramework.Database.Entities.GeneralLedgerMappingExportTargetAccount) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(GeneralLedgerMappingExportTargetAccount)

                ErrorText = GeneralLedgerMappingExportTargetAccount.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GeneralLedgerMappingExportTargetAccount As AdvantageFramework.Database.Entities.GeneralLedgerMappingExportTargetAccount) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing

            Try

                If IsValid Then

                    If DbContext.Database.Connection.State <> ConnectionState.Open Then

                        DbContext.Database.Connection.Open()

                    End If

                    DbTransaction = DbContext.Database.BeginTransaction()

                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.GLACCOUNT_XREF_EXPORT_DETAIL WHERE GLACCOUNT_XREF_EXPORT_ID = {0}", GeneralLedgerMappingExportTargetAccount.ID))

                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.GLACCOUNT_XREF_EXPORT WHERE GLACCOUNT_XREF_EXPORT_ID = {0}", GeneralLedgerMappingExportTargetAccount.ID))

                    DbTransaction.Commit()

                    Deleted = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception

                Deleted = False

                If DbTransaction IsNot Nothing Then

                    DbTransaction.Rollback()

                End If

            Finally
                Delete = Deleted
            End Try

        End Function

#End Region

    End Module

End Namespace

