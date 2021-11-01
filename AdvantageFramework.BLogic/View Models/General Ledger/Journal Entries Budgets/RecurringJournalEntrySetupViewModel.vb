Namespace ViewModels.GeneralLedger.JournalEntriesBudgets

    Public Class RecurringJournalEntrySetupViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property AddEnabled As Boolean
        Public Property SaveEnabled As Boolean
        Public Property CancelEnabled As Boolean
        Public Property PrintEnabled As Boolean

        Public ReadOnly Property HasASelectedRecurringJournalEntry As Boolean
            Get
                HasASelectedRecurringJournalEntry = (Me.SelectedRecurringJournalEntry IsNot Nothing)
            End Get
        End Property

        Public Property RecurringJournalEntries As Generic.List(Of AdvantageFramework.DTO.GeneralLedger.JournalEntry.RecurringJournalEntryItem)
        Public Property SelectedRecurringJournalEntry As AdvantageFramework.DTO.GeneralLedger.JournalEntry.RecurringJournalEntryItem

#End Region

#Region " Methods "

        Public Sub New()

            Me.AddEnabled = True
            Me.SaveEnabled = False
            Me.CancelEnabled = False
            Me.PrintEnabled = False

            Me.RecurringJournalEntries = New Generic.List(Of AdvantageFramework.DTO.GeneralLedger.JournalEntry.RecurringJournalEntryItem)
            Me.SelectedRecurringJournalEntry = Nothing

        End Sub

#End Region

    End Class

End Namespace

