Namespace ViewModels.GeneralLedger.JournalEntriesBudgets

    Public Class JournalEntrySetupViewModel

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
        Public Property RefreshEnabled As Boolean

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

            Me.AddEnabled = True
            Me.SaveEnabled = False
            Me.CancelEnabled = False
            Me.PrintEnabled = False
            Me.RefreshEnabled = True

            Me.PostPeriodCodeFrom = Nothing
            Me.PostPeriodCodeTo = Nothing

            Me.AllPostPeriods = New Generic.List(Of AdvantageFramework.DTO.GeneralLedger.JournalEntry.PostPeriod)
            Me.JournalEntries = New Generic.List(Of AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntry)
            Me.SelectedJournalEntry = Nothing

        End Sub

#End Region

    End Class

End Namespace

