Namespace Controller.GeneralLedger.JournalEntriesBudgets

    Public Class JournalEntrySetupController
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

        Public Function Load() As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.JournalEntrySetupViewModel

            Dim JournalEntrySetupViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.JournalEntrySetupViewModel = Nothing
            Dim CurrenctGLPostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing

            JournalEntrySetupViewModel = New AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.JournalEntrySetupViewModel

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                JournalEntrySetupViewModel.AllPostPeriods = AdvantageFramework.Database.Procedures.PostPeriod.Load(DbContext).OrderByDescending(Function(PP) PP.Code).ToList.Select(Function(Entity) New AdvantageFramework.DTO.GeneralLedger.JournalEntry.PostPeriod(Entity)).ToList

                CurrenctGLPostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentGLPostPeriod(DbContext)

                If CurrenctGLPostPeriod IsNot Nothing Then

                    JournalEntrySetupViewModel.PostPeriodCodeFrom = CurrenctGLPostPeriod.Code

                    JournalEntrySetupViewModel.PostPeriodCodeTo = CurrenctGLPostPeriod.Code

                ElseIf JournalEntrySetupViewModel.AllPostPeriods.Count > 0 Then

                    JournalEntrySetupViewModel.PostPeriodCodeFrom = JournalEntrySetupViewModel.AllPostPeriods(0).Code

                    JournalEntrySetupViewModel.PostPeriodCodeTo = JournalEntrySetupViewModel.AllPostPeriods(0).Code

                End If

                RefreshJournalEntries(DbContext, JournalEntrySetupViewModel)

                JournalEntrySetupViewModel.AddEnabled = True
                JournalEntrySetupViewModel.SaveEnabled = False
                JournalEntrySetupViewModel.CancelEnabled = False
                JournalEntrySetupViewModel.PrintEnabled = False
                JournalEntrySetupViewModel.RefreshEnabled = True

            End Using

            Load = JournalEntrySetupViewModel

        End Function
        Private Sub RefreshJournalEntries(DbContext As AdvantageFramework.Database.DbContext, ByRef JournalEntrySetupViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.JournalEntrySetupViewModel)

            JournalEntrySetupViewModel.JournalEntries = New Generic.List(Of AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntry)

            JournalEntrySetupViewModel.JournalEntries.AddRange(From GL In AdvantageFramework.Database.Procedures.GeneralLedger.LoadByPostPeriod(DbContext, JournalEntrySetupViewModel.PostPeriodCodeFrom, JournalEntrySetupViewModel.PostPeriodCodeTo).Include("GeneralLedgerDocuments").OrderByDescending(Function(GL) GL.Transaction).ToList
                                                               Select New AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntry(GL))

        End Sub
        Public Sub RefreshJournalEntries(ByRef JournalEntrySetupViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.JournalEntrySetupViewModel)

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                RefreshJournalEntries(DbContext, JournalEntrySetupViewModel)

            End Using

        End Sub
        Public Sub RefreshSelectedJournalEntry(ByRef JournalEntrySetupViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.JournalEntrySetupViewModel)

            Dim GeneralLedger As AdvantageFramework.Database.Entities.GeneralLedger = Nothing
            Dim Transaction As Integer = 0

            If JournalEntrySetupViewModel.SelectedJournalEntry IsNot Nothing Then

                Transaction = JournalEntrySetupViewModel.SelectedJournalEntry.Transaction

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        GeneralLedger = (From Entity In DbContext.GetQuery(Of Database.Entities.GeneralLedger).Include("GeneralLedgerDocuments")
                                         Where Entity.Transaction = Transaction
                                         Select Entity).SingleOrDefault

                    End Using

                Catch ex As Exception
                    GeneralLedger = Nothing
                End Try

                If GeneralLedger IsNot Nothing Then

                    JournalEntrySetupViewModel.SelectedJournalEntry.Refresh(GeneralLedger)

                End If

            End If

        End Sub
        Public Sub JournalEntrySelectionChanged(ByRef JournalEntrySetupViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.JournalEntrySetupViewModel,
                                                SelectedJournalEntry As AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntry)

            JournalEntrySetupViewModel.SelectedJournalEntry = SelectedJournalEntry

            JournalEntrySetupViewModel.PrintEnabled = (JournalEntrySetupViewModel.SelectedJournalEntry IsNot Nothing)

        End Sub
        Public Sub SetPostPeriodFrom(ByRef JournalEntrySetupViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.JournalEntrySetupViewModel, PostPeriodCode As String)

            JournalEntrySetupViewModel.PostPeriodCodeFrom = PostPeriodCode

            RefreshJournalEntries(JournalEntrySetupViewModel)

        End Sub
        Public Sub SetPostPeriodTo(ByRef JournalEntrySetupViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.JournalEntrySetupViewModel, PostPeriodCode As String)

            JournalEntrySetupViewModel.PostPeriodCodeTo = PostPeriodCode

            RefreshJournalEntries(JournalEntrySetupViewModel)

        End Sub
        Public Sub UserEntryChanged(ByRef JournalEntrySetupViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.JournalEntrySetupViewModel)

            JournalEntrySetupViewModel.SaveEnabled = True
            JournalEntrySetupViewModel.CancelEnabled = True

        End Sub
        Public Sub ClearChanged(ByRef JournalEntrySetupViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.JournalEntrySetupViewModel)

            JournalEntrySetupViewModel.SaveEnabled = False
            JournalEntrySetupViewModel.CancelEnabled = False

        End Sub
        Public Function LoadSingleTransaction(ByRef JournalEntrySetupViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.JournalEntrySetupViewModel, Transaction As Integer,
                                              ByRef IsVoided As Boolean) As Boolean

            Dim GeneralLedger As AdvantageFramework.Database.Entities.GeneralLedger = Nothing
            Dim Loaded As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                GeneralLedger = AdvantageFramework.Database.Procedures.GeneralLedger.LoadByTransaction(DbContext, Transaction)

                If GeneralLedger IsNot Nothing Then

                    If GeneralLedger.GLSourceCode <> "VI" Then

                        JournalEntrySetupViewModel.PostPeriodCodeFrom = GeneralLedger.PostPeriodCode
                        JournalEntrySetupViewModel.PostPeriodCodeTo = GeneralLedger.PostPeriodCode

                        RefreshJournalEntries(DbContext, JournalEntrySetupViewModel)

                        Loaded = True

                    Else

                        IsVoided = True

                    End If

                End If

            End Using

            LoadSingleTransaction = Loaded

        End Function

#End Region

    End Class

End Namespace
