Namespace ViewModels.GeneralLedger.JournalEntriesBudgets

    Public Class RecurringJournalEntryPostViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property PostEnabled As Boolean
        Public Property PrintEnabled As Boolean

        Public Property SelectedPostPeriodCode As String
        Public Property SelectedCycleCode As String
        Public Property SelectedTransactionDate As Date

        Public Property RecurringJournalEntryPosts As Generic.List(Of AdvantageFramework.DTO.GeneralLedger.JournalEntry.RecurringJournalEntryPost)

        Public Property CurrentPostPeriodCode As String
        Public Property PostPeriods As Generic.List(Of AdvantageFramework.DTO.GeneralLedger.JournalEntry.PostPeriod)
        Public Property Cycles As Generic.List(Of AdvantageFramework.DTO.GeneralLedger.JournalEntry.Cycle)

#End Region

#Region " Methods "

        Public Sub New()

            Me.PostEnabled = False
            Me.PrintEnabled = False

            Me.SelectedPostPeriodCode = String.Empty
            Me.SelectedCycleCode = String.Empty
            Me.SelectedTransactionDate = CDate(Now.ToShortDateString)

            Me.RecurringJournalEntryPosts = New Generic.List(Of AdvantageFramework.DTO.GeneralLedger.JournalEntry.RecurringJournalEntryPost)

            Me.PostPeriods = New Generic.List(Of AdvantageFramework.DTO.GeneralLedger.JournalEntry.PostPeriod)
            Me.Cycles = New Generic.List(Of AdvantageFramework.DTO.GeneralLedger.JournalEntry.Cycle)

        End Sub

#End Region

    End Class

End Namespace

