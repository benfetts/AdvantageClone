Namespace Controller.GeneralLedger.JournalEntriesBudgets

    Public Class JournalEntryDetailCopyController
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

        Public Function Load(CopyFrom As Boolean) As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.JournalEntryDetailCopyViewModel

            Dim JournalEntryDetailCopyViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.JournalEntryDetailCopyViewModel = Nothing
            Dim CurrenctGLPostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                JournalEntryDetailCopyViewModel = New AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.JournalEntryDetailCopyViewModel()

                JournalEntryDetailCopyViewModel.CopyFrom = CopyFrom

                JournalEntryDetailCopyViewModel.AllPostPeriods = AdvantageFramework.Database.Procedures.PostPeriod.Load(DbContext).OrderByDescending(Function(PP) PP.Code).ToList.Select(Function(Entity) New AdvantageFramework.DTO.GeneralLedger.JournalEntry.PostPeriod(Entity)).ToList

                CurrenctGLPostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentGLPostPeriod(DbContext)

                If CurrenctGLPostPeriod IsNot Nothing Then

                    JournalEntryDetailCopyViewModel.PostPeriodCodeFrom = CurrenctGLPostPeriod.Code

                    JournalEntryDetailCopyViewModel.PostPeriodCodeTo = CurrenctGLPostPeriod.Code

                End If

                RefreshJournalEntries(DbContext, JournalEntryDetailCopyViewModel)

            End Using

            Load = JournalEntryDetailCopyViewModel

        End Function
        Private Sub RefreshJournalEntries(DbContext As AdvantageFramework.Database.DbContext, ByRef JournalEntryDetailCopyViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.JournalEntryDetailCopyViewModel)

            JournalEntryDetailCopyViewModel.JournalEntries = New Generic.List(Of AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntry)

            JournalEntryDetailCopyViewModel.JournalEntries.AddRange(From GeneralLedger In AdvantageFramework.Database.Procedures.GeneralLedger.LoadNonVoidedByPostPeriod(DbContext, JournalEntryDetailCopyViewModel.PostPeriodCodeFrom, JournalEntryDetailCopyViewModel.PostPeriodCodeTo).Include("GeneralLedgerDocuments").OrderByDescending(Function(GL) GL.Transaction).ToList
                                                                    Select New AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntry(GeneralLedger))

        End Sub
        Public Sub RefreshJournalEntries(ByRef JournalEntryDetailCopyViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.JournalEntryDetailCopyViewModel)

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                RefreshJournalEntries(DbContext, JournalEntryDetailCopyViewModel)

            End Using

        End Sub
        Public Sub JournalEntrySelectionChanged(ByRef JournalEntryDetailCopyViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.JournalEntryDetailCopyViewModel,
                                                SelectedJournalEntry As AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntry)

            JournalEntryDetailCopyViewModel.SelectedJournalEntry = SelectedJournalEntry

        End Sub
        Public Sub SetPostPeriodFrom(ByRef JournalEntryDetailCopyViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.JournalEntryDetailCopyViewModel, PostPeriodCode As String)

            JournalEntryDetailCopyViewModel.PostPeriodCodeFrom = PostPeriodCode

            RefreshJournalEntries(JournalEntryDetailCopyViewModel)

        End Sub
        Public Sub SetPostPeriodTo(ByRef JournalEntryDetailCopyViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.JournalEntryDetailCopyViewModel, PostPeriodCode As String)

            JournalEntryDetailCopyViewModel.PostPeriodCodeTo = PostPeriodCode

            RefreshJournalEntries(JournalEntryDetailCopyViewModel)

        End Sub

#End Region

    End Class

End Namespace
