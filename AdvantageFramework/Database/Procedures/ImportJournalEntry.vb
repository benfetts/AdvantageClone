Namespace Database.Procedures.ImportJournalEntry

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

        Public Function Load(DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ImportJournalEntry)

            Load = From ImportJournalEntry In DbContext.ImportJournalEntrys
                   Select ImportJournalEntry

        End Function
        Public Function LoadByBatchName(DbContext As AdvantageFramework.Database.DbContext, BatchName As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ImportJournalEntry)

            LoadByBatchName = From ImportJournalEntryStaging In DbContext.ImportJournalEntrys
                              Where ImportJournalEntryStaging.BatchName = BatchName
                              Select ImportJournalEntryStaging

        End Function
        Public Function LoadByID(DbContext As AdvantageFramework.Database.DbContext, ID As Integer) As AdvantageFramework.Database.Entities.ImportJournalEntry

            Try

                LoadByID = (From ImportJournalEntry In DbContext.ImportJournalEntrys
                            Where ImportJournalEntry.ID = ID
                            Select ImportJournalEntry).SingleOrDefault

            Catch ex As Exception
                LoadByID = Nothing
            End Try

        End Function
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ImportJournalEntry As AdvantageFramework.Database.Entities.ImportJournalEntry) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(ImportJournalEntry)

                ErrorText = ImportJournalEntry.ValidateEntity(IsValid)

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

#End Region

    End Module

End Namespace