Namespace Controller.GeneralLedger.JournalEntriesBudgets

    Public Class RecurringJournalEntrySetupController
        Inherits AdvantageFramework.Controller.BaseController

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Sub New(Session As AdvantageFramework.Security.Session)

            MyBase.New(Session)

        End Sub

        Public Function Load() As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.RecurringJournalEntrySetupViewModel

            Dim RecurringJournalEntrySetupViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.RecurringJournalEntrySetupViewModel = Nothing

            RecurringJournalEntrySetupViewModel = New AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.RecurringJournalEntrySetupViewModel

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                RefreshRecurringJournalEntries(DbContext, RecurringJournalEntrySetupViewModel)

                RecurringJournalEntrySetupViewModel.AddEnabled = True
                RecurringJournalEntrySetupViewModel.SaveEnabled = False
                RecurringJournalEntrySetupViewModel.CancelEnabled = False
                RecurringJournalEntrySetupViewModel.PrintEnabled = False

            End Using

            Load = RecurringJournalEntrySetupViewModel

        End Function
        Private Sub RefreshRecurringJournalEntries(DbContext As AdvantageFramework.Database.DbContext, ByRef RecurringJournalEntrySetupViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.RecurringJournalEntrySetupViewModel)

            RecurringJournalEntrySetupViewModel.RecurringJournalEntries = New Generic.List(Of AdvantageFramework.DTO.GeneralLedger.JournalEntry.RecurringJournalEntryItem)

            RecurringJournalEntrySetupViewModel.RecurringJournalEntries.AddRange(From GLRE In DbContext.GeneralLedgerRecurringEntries.Include("Cycle").Where(Function(Entity) Entity.IsVoided Is Nothing OrElse Entity.IsVoided = 0).ToList
                                                                                 Select New AdvantageFramework.DTO.GeneralLedger.JournalEntry.RecurringJournalEntryItem(GLRE))

        End Sub
        Public Sub RefreshRecurringJournalEntries(ByRef RecurringJournalEntrySetupViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.RecurringJournalEntrySetupViewModel)

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                RefreshRecurringJournalEntries(DbContext, RecurringJournalEntrySetupViewModel)

            End Using

        End Sub
        Public Sub RecurringJournalEntrySelectionChanged(ByRef RecurringJournalEntrySetupViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.RecurringJournalEntrySetupViewModel,
                                                         SelectedRecurringJournalEntry As AdvantageFramework.DTO.GeneralLedger.JournalEntry.RecurringJournalEntryItem)

            RecurringJournalEntrySetupViewModel.SelectedRecurringJournalEntry = SelectedRecurringJournalEntry

            RecurringJournalEntrySetupViewModel.PrintEnabled = (RecurringJournalEntrySetupViewModel.SelectedRecurringJournalEntry IsNot Nothing)

        End Sub
        Public Sub UserEntryChanged(ByRef RecurringJournalEntrySetupViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.RecurringJournalEntrySetupViewModel)

            RecurringJournalEntrySetupViewModel.SaveEnabled = True
            RecurringJournalEntrySetupViewModel.CancelEnabled = True

        End Sub
        Public Sub ClearChanged(ByRef RecurringJournalEntrySetupViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.RecurringJournalEntrySetupViewModel)

            RecurringJournalEntrySetupViewModel.SaveEnabled = False
            RecurringJournalEntrySetupViewModel.CancelEnabled = False

        End Sub

#End Region

    End Class

End Namespace
