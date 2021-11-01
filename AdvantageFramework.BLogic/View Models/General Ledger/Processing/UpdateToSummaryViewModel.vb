Namespace ViewModels.GeneralLedger.Processing

    Public Class UpdateToSummaryViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property PostPeriodsWithUnpostedEntries As Generic.List(Of AdvantageFramework.DTO.GeneralLedger.JournalEntry.PostPeriod)

        Public Property UnpostedJournalEntryList As Generic.List(Of AdvantageFramework.DTO.GeneralLedger.Processing.UnpostedJournalEntry)

        Public Property ClearablePostPeriodCodes As IEnumerable(Of String)

#End Region

#Region " Methods "

        Public Sub New()

            Me.UnpostedJournalEntryList = New Generic.List(Of AdvantageFramework.DTO.GeneralLedger.Processing.UnpostedJournalEntry)

        End Sub

#End Region

    End Class

End Namespace

