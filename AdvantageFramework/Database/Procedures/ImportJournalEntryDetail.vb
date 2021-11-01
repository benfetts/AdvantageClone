Namespace Database.Procedures.ImportJournalEntryDetail

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

        Public Function Load(DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ImportJournalEntryDetail)

            Load = From ImportJournalEntryDetail In DbContext.ImportJournalEntryDetails
                   Select ImportJournalEntryDetail

        End Function
        Public Function LoadByID(DbContext As AdvantageFramework.Database.DbContext, ID As Integer) As AdvantageFramework.Database.Entities.ImportJournalEntryDetail

            Try

                LoadByID = (From ImportJournalEntryDetail In DbContext.ImportJournalEntryDetails
                            Where ImportJournalEntryDetail.ID = ID
                            Select ImportJournalEntryDetail).SingleOrDefault

            Catch ex As Exception
                LoadByID = Nothing
            End Try

        End Function
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ImportJournalEntryDetail As AdvantageFramework.Database.Entities.ImportJournalEntryDetail) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(ImportJournalEntryDetail)

                ErrorText = ImportJournalEntryDetail.ValidateEntity(IsValid)

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