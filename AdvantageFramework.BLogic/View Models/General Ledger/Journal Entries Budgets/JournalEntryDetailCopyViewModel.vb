Namespace ViewModels.GeneralLedger.JournalEntriesBudgets

    Public Class JournalEntryDetailCopyViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property CopyFrom As Boolean

        Public Property PostPeriodCodeFrom As String
        Public Property PostPeriodCodeTo As String

        Public ReadOnly Property HasASelectedJournalEntry As Boolean
            Get
                HasASelectedJournalEntry = (Me.SelectedJournalEntry IsNot Nothing)
            End Get
        End Property

        Public Property AllPostPeriods As Generic.List(Of AdvantageFramework.DTO.GeneralLedger.JournalEntry.PostPeriod)
        Public Property JournalEntries As Generic.List(Of AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntry)
        Public Property SelectedJournalEntry As AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntry

#End Region

#Region " Methods "

        Public Sub New()

            Me.CopyFrom = True

            Me.PostPeriodCodeFrom = String.Empty
            Me.PostPeriodCodeTo = String.Empty

            Me.AllPostPeriods = New Generic.List(Of AdvantageFramework.DTO.GeneralLedger.JournalEntry.PostPeriod)
            Me.JournalEntries = New Generic.List(Of AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntry)
            Me.SelectedJournalEntry = Nothing

        End Sub

#End Region

    End Class

End Namespace

