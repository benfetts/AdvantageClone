Namespace ViewModels.GeneralLedger.JournalEntriesBudgets

    Public Class RecurringJournalEntryViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property RecurringJournalEntry As AdvantageFramework.DTO.GeneralLedger.JournalEntry.RecurringJournalEntry
        Public Property RecurringJournalEntryDetails As Generic.List(Of AdvantageFramework.DTO.GeneralLedger.JournalEntry.RecurringJournalEntryDetail)

        Public Property AddEnabled As Boolean
        Public Property UpdateEnabled As Boolean
        Public Property CopyEnabled As Boolean

        Public Property Details_IsNewRow As Boolean
        Public Property Details_DeleteEnabled As Boolean
        Public Property Details_CancelEnabled As Boolean
        Public Property Details_CopyFromEnabled As Boolean
        Public Property Details_ReverseDebitCreditsEnabled As Boolean

        Public Property SelectedRecurringJournalEntryDetails As Generic.List(Of AdvantageFramework.DTO.GeneralLedger.JournalEntry.RecurringJournalEntryDetail)

        Public ReadOnly Property HasASelectedRecurringJournalEntryDetail As Boolean
            Get
                HasASelectedRecurringJournalEntryDetail = (Me.SelectedRecurringJournalEntryDetails IsNot Nothing AndAlso Me.SelectedRecurringJournalEntryDetails.Count > 0)
            End Get
        End Property

        Public Property RepositoryCycles As Generic.List(Of AdvantageFramework.DTO.GeneralLedger.JournalEntry.Cycle)
        Public Property RepositoryClients As Generic.List(Of AdvantageFramework.DTO.GeneralLedger.JournalEntry.Client)
        Public Property RepositoryDivisions As Generic.List(Of AdvantageFramework.DTO.GeneralLedger.JournalEntry.Division)
        Public Property RepositoryProducts As Generic.List(Of AdvantageFramework.DTO.GeneralLedger.JournalEntry.Product)
        Public Property RepositoryGeneralLedgerAccounts As Generic.List(Of AdvantageFramework.DTO.GeneralLedger.JournalEntry.GeneralLedgerAccount)

#End Region

#Region " Methods "

        Public Sub New()

            Me.RecurringJournalEntry = Nothing
            Me.RecurringJournalEntryDetails = New Generic.List(Of AdvantageFramework.DTO.GeneralLedger.JournalEntry.RecurringJournalEntryDetail)

            Me.AddEnabled = False
            Me.UpdateEnabled = False
            Me.CopyEnabled = False

            Me.Details_IsNewRow = False
            Me.Details_DeleteEnabled = False
            Me.Details_CancelEnabled = False
            Me.Details_CopyFromEnabled = True
            Me.Details_ReverseDebitCreditsEnabled = True

            Me.RepositoryCycles = New Generic.List(Of AdvantageFramework.DTO.GeneralLedger.JournalEntry.Cycle)
            Me.RepositoryClients = New Generic.List(Of AdvantageFramework.DTO.GeneralLedger.JournalEntry.Client)
            Me.RepositoryDivisions = New Generic.List(Of AdvantageFramework.DTO.GeneralLedger.JournalEntry.Division)
            Me.RepositoryProducts = New Generic.List(Of AdvantageFramework.DTO.GeneralLedger.JournalEntry.Product)
            Me.RepositoryGeneralLedgerAccounts = New Generic.List(Of AdvantageFramework.DTO.GeneralLedger.JournalEntry.GeneralLedgerAccount)

        End Sub

#End Region

    End Class

End Namespace

