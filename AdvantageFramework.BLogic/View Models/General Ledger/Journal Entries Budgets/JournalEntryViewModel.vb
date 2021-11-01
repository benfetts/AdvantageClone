Namespace ViewModels.GeneralLedger.JournalEntriesBudgets

    Public Class JournalEntryViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property JournalEntry As AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntry
        Public Property JournalEntryDetails As Generic.List(Of AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntryDetail)

        Public Property AllowEdit As Boolean
        Public Property AddEnabled As Boolean
        Public Property UpdateEnabled As Boolean
        Public Property VoidEnabled As Boolean
        Public Property CopyEnabled As Boolean
        Public Property AllowDescriptionEditIfPostedToSummary As Boolean
        Public Property AllowEnteredDateEditIfPostedToSummary As Boolean
        'Public Property DeleteEnabled As Boolean

        Public Property Details_IsNewRow As Boolean
        Public Property Details_DeleteEnabled As Boolean
        Public Property Details_CancelEnabled As Boolean
        Public Property Details_CopyFromEnabled As Boolean
        Public Property Details_ReverseDebitCreditsEnabled As Boolean

        Public Property Documents_ViewEnabled As Boolean
        Public Property Documents_UploadEnabled As Boolean

        Public Property SelectedJournalEntryDetails As Generic.List(Of AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntryDetail)

        Public ReadOnly Property HasASelectedJournalEntryDetail As Boolean
            Get
                HasASelectedJournalEntryDetail = (Me.SelectedJournalEntryDetails IsNot Nothing AndAlso Me.SelectedJournalEntryDetails.Count > 0)
            End Get
        End Property

        Public Property SelectedOfficeCode As String

        Public Property Offices As Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)
        Public Property PostPeriods As Generic.List(Of AdvantageFramework.DTO.GeneralLedger.JournalEntry.PostPeriod)
        Public Property RepositoryClients As Generic.List(Of AdvantageFramework.DTO.GeneralLedger.JournalEntry.Client)
        Public Property RepositoryDivisions As Generic.List(Of AdvantageFramework.DTO.GeneralLedger.JournalEntry.Division)
        Public Property RepositoryProducts As Generic.List(Of AdvantageFramework.DTO.GeneralLedger.JournalEntry.Product)
        Public Property RepositoryGeneralLedgerAccounts As Generic.List(Of AdvantageFramework.DTO.GeneralLedger.JournalEntry.GeneralLedgerAccount)
        Public Property CurrentPostPeriod As AdvantageFramework.DTO.GeneralLedger.PostPeriod

#End Region

#Region " Methods "

        Public Sub New()

            Me.JournalEntry = Nothing
            Me.JournalEntryDetails = New Generic.List(Of AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntryDetail)

            Me.AllowEdit = True
            Me.AddEnabled = False
            Me.UpdateEnabled = False
            Me.VoidEnabled = False
            Me.CopyEnabled = False
            Me.AllowDescriptionEditIfPostedToSummary = False
            Me.AllowEnteredDateEditIfPostedToSummary = False
            'Me.DeleteEnabled = False

            Me.Details_IsNewRow = False
            Me.Details_DeleteEnabled = False
            Me.Details_CancelEnabled = False
            Me.Details_CopyFromEnabled = True
            Me.Details_ReverseDebitCreditsEnabled = True

            Me.Documents_ViewEnabled = True
            Me.Documents_UploadEnabled = True

            Me.SelectedJournalEntryDetails = Nothing

            Me.SelectedOfficeCode = String.Empty

            Me.Offices = New Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)
            Me.PostPeriods = New Generic.List(Of AdvantageFramework.DTO.GeneralLedger.JournalEntry.PostPeriod)
            Me.RepositoryClients = New Generic.List(Of AdvantageFramework.DTO.GeneralLedger.JournalEntry.Client)
            Me.RepositoryDivisions = New Generic.List(Of AdvantageFramework.DTO.GeneralLedger.JournalEntry.Division)
            Me.RepositoryProducts = New Generic.List(Of AdvantageFramework.DTO.GeneralLedger.JournalEntry.Product)
            Me.RepositoryGeneralLedgerAccounts = New Generic.List(Of AdvantageFramework.DTO.GeneralLedger.JournalEntry.GeneralLedgerAccount)
            Me.CurrentPostPeriod = Nothing

        End Sub

#End Region

    End Class

End Namespace

