Namespace Controller.GeneralLedger.JournalEntriesBudgets

    Public Class RecurringJournalEntryPostController
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
        Public Function Load() As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.RecurringJournalEntryPostViewModel

            Dim RecurringJournalEntryPostViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.RecurringJournalEntryPostViewModel = Nothing
            Dim CurrentPostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing

            RecurringJournalEntryPostViewModel = New AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.RecurringJournalEntryPostViewModel

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                RecurringJournalEntryPostViewModel.PostEnabled = False
                RecurringJournalEntryPostViewModel.PrintEnabled = False

                RecurringJournalEntryPostViewModel.SelectedTransactionDate = CDate(Now.ToShortDateString)

                RecurringJournalEntryPostViewModel.Cycles = AdvantageFramework.Database.Procedures.Cycle.LoadAllActive(DbContext).ToList.Select(Function(Entity) New AdvantageFramework.DTO.GeneralLedger.JournalEntry.Cycle(Entity)).ToList

                RecurringJournalEntryPostViewModel.Cycles = RecurringJournalEntryPostViewModel.Cycles.OrderBy(Function(Cycle) Cycle.Code).ToList

                If RecurringJournalEntryPostViewModel.Cycles IsNot Nothing AndAlso RecurringJournalEntryPostViewModel.Cycles.Count > 0 Then

                    If RecurringJournalEntryPostViewModel.Cycles.Any(Function(Entity) Entity.Code = "glmth") Then

                        RecurringJournalEntryPostViewModel.SelectedCycleCode = RecurringJournalEntryPostViewModel.Cycles.FirstOrDefault(Function(Entity) Entity.Code = "glmth").Code

                    ElseIf RecurringJournalEntryPostViewModel.Cycles.Count > 0 Then

                        RecurringJournalEntryPostViewModel.SelectedCycleCode = RecurringJournalEntryPostViewModel.Cycles.First.Code

                    End If

                End If

                RecurringJournalEntryPostViewModel.PostPeriods = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllActiveGLPostPeriods(DbContext).ToList.Select(Function(Entity) New AdvantageFramework.DTO.GeneralLedger.JournalEntry.PostPeriod(Entity)).ToList

                RecurringJournalEntryPostViewModel.PostPeriods = RecurringJournalEntryPostViewModel.PostPeriods.OrderByDescending(Function(PP) PP.Code).ToList

                CurrentPostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentGLPostPeriod(DbContext)

                If CurrentPostPeriod IsNot Nothing Then

                    RecurringJournalEntryPostViewModel.CurrentPostPeriodCode = CurrentPostPeriod.Code

                Else

                    RecurringJournalEntryPostViewModel.CurrentPostPeriodCode = String.Empty

                End If

                If String.IsNullOrWhiteSpace(RecurringJournalEntryPostViewModel.CurrentPostPeriodCode) = False Then

                    RecurringJournalEntryPostViewModel.SelectedPostPeriodCode = RecurringJournalEntryPostViewModel.CurrentPostPeriodCode

                Else

                    If RecurringJournalEntryPostViewModel.PostPeriods IsNot Nothing AndAlso RecurringJournalEntryPostViewModel.PostPeriods.Count > 0 Then

                        RecurringJournalEntryPostViewModel.SelectedPostPeriodCode = RecurringJournalEntryPostViewModel.PostPeriods.First.Code

                    Else

                        RecurringJournalEntryPostViewModel.SelectedPostPeriodCode = String.Empty

                    End If

                End If

                LoadRecurringJournalEntries(RecurringJournalEntryPostViewModel)

                EnableDisableActions(RecurringJournalEntryPostViewModel)

            End Using

            Load = RecurringJournalEntryPostViewModel

        End Function
        Public Function Post(ByRef RecurringJournalEntryPostViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.RecurringJournalEntryPostViewModel, ByRef ErrorMessage As String) As Boolean

            Dim Posted As Boolean = False
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim RecurringJournalEntryController As AdvantageFramework.Controller.GeneralLedger.JournalEntriesBudgets.RecurringJournalEntryController = Nothing
            Dim RecurringJournalEntryViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.RecurringJournalEntryViewModel = Nothing
            Dim JournalEntryController As AdvantageFramework.Controller.GeneralLedger.JournalEntriesBudgets.JournalEntryController = Nothing
            Dim JournalEntryViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.JournalEntryViewModel = Nothing
            Dim JournalEntryDetail As AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntryDetail = Nothing
            Dim RecurringJournalEntryPosts As Generic.List(Of AdvantageFramework.DTO.GeneralLedger.JournalEntry.RecurringJournalEntryPost) = Nothing
            Dim JournalEntryErrorMessage As String = String.Empty
            Dim RecurringJournalEntryErrorMessage As String = String.Empty
            Dim PostCounter As Integer = 0
            Dim PostUpdated As Boolean = False

            Try

                RecurringJournalEntryController = New AdvantageFramework.Controller.GeneralLedger.JournalEntriesBudgets.RecurringJournalEntryController(Me.Session)
                JournalEntryController = New AdvantageFramework.Controller.GeneralLedger.JournalEntriesBudgets.JournalEntryController(Me.Session)

                RecurringJournalEntryPosts = RecurringJournalEntryPostViewModel.RecurringJournalEntryPosts.Where(Function(Entity) Entity.CreateJournalEntry = True).ToList

                For Each RecurringJournalEntryPost In RecurringJournalEntryPosts

                    JournalEntryErrorMessage = String.Empty

                    Try

                        RecurringJournalEntryViewModel = RecurringJournalEntryController.Load(RecurringJournalEntryPost.ControlNumber)
                        JournalEntryViewModel = JournalEntryController.Load(0)

                        JournalEntryViewModel.JournalEntry.Description = RecurringJournalEntryPost.Description
                        JournalEntryViewModel.JournalEntry.EnteredDate = CDate(RecurringJournalEntryPostViewModel.SelectedTransactionDate.ToShortDateString)
                        JournalEntryViewModel.JournalEntry.ModifiedDate = CDate(Now.ToShortDateString)
                        JournalEntryViewModel.JournalEntry.CreateDate = Now
                        JournalEntryViewModel.JournalEntry.PostPeriodCode = RecurringJournalEntryPostViewModel.SelectedPostPeriodCode
                        JournalEntryViewModel.JournalEntry.ReverseFlag = RecurringJournalEntryViewModel.RecurringJournalEntry.ReverseFlag
                        JournalEntryViewModel.JournalEntry.UserCode = Me.Session.UserCode
                        JournalEntryViewModel.JournalEntry.GLSourceCode = "RJ"

                        For Each RecurringJournalEntryDetail In RecurringJournalEntryViewModel.RecurringJournalEntryDetails

                            JournalEntryDetail = New AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntryDetail

                            JournalEntryDetail.GLACode = RecurringJournalEntryDetail.GLACode
                            JournalEntryDetail.CreditAmount = RecurringJournalEntryDetail.CreditAmount
                            JournalEntryDetail.DebitAmount = RecurringJournalEntryDetail.DebitAmount
                            JournalEntryDetail.Remark = RecurringJournalEntryDetail.Remark & "-" & RecurringJournalEntryDetail.SequenceNumber
                            JournalEntryDetail.ClientCode = RecurringJournalEntryDetail.ClientCode
                            JournalEntryDetail.DivisionCode = RecurringJournalEntryDetail.DivisionCode
                            JournalEntryDetail.ProductCode = RecurringJournalEntryDetail.ProductCode

                            JournalEntryViewModel.JournalEntryDetails.Add(JournalEntryDetail)

                        Next

                        If JournalEntryController.Add(JournalEntryViewModel, JournalEntryErrorMessage) Then

                            PostUpdated = False

                            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                                DbContext.Database.Connection.Open()
                                DbContext.Configuration.AutoDetectChangesEnabled = False

                                Try

                                    DbTransaction = DbContext.Database.BeginTransaction

                                    DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.GLRJEHDR SET GLRHLASTBY = '{0}', GLRHLASTDATE = '{1}', GLRHLASTPP = '{2}' WHERE GLRHCNTRL = '{3}'", Me.Session.UserCode, Now.ToString("MM/dd/yyyy"), RecurringJournalEntryPostViewModel.SelectedPostPeriodCode, RecurringJournalEntryPost.ControlNumber))

                                    DbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO dbo.GLRJELOG(GLRLCNTRL, GLRLDATE, GLRLPP, GLRLUSER, GLEHXACT) VALUES({0}, '{1}', '{2}', '{3}', {4})", RecurringJournalEntryPost.ControlNumber, RecurringJournalEntryPostViewModel.SelectedTransactionDate.ToString("MM/dd/yyyy"), RecurringJournalEntryPostViewModel.SelectedPostPeriodCode, Me.Session.UserCode, JournalEntryViewModel.JournalEntry.Transaction))

                                    DbTransaction.Commit()

                                    PostCounter += 1

                                    PostUpdated = True

                                Catch ex As Exception
                                    DbTransaction.Rollback()
                                    ErrorMessage = ex.Message
                                End Try

                            End Using

                            If PostUpdated Then

                                If RecurringJournalEntryPost.NumberRemaining = 1 Then

                                    RecurringJournalEntryViewModel.RecurringJournalEntry.IsInactive = True

                                    RecurringJournalEntryController.Save(RecurringJournalEntryViewModel, RecurringJournalEntryErrorMessage)

                                End If

                            End If

                        Else

                            ErrorMessage = JournalEntryErrorMessage

                        End If

                    Catch ex As Exception
                        ErrorMessage = ex.Message
                    End Try

                    If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                        Exit For

                    End If

                Next

            Catch ex As Exception
                ErrorMessage = ex.Message
            End Try

            If PostCounter = RecurringJournalEntryPosts.Count Then

                Posted = True

            End If

            Post = Posted

        End Function
        Public Sub EnableDisableActions(ByRef RecurringJournalEntryPostViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.RecurringJournalEntryPostViewModel)

            If RecurringJournalEntryPostViewModel.RecurringJournalEntryPosts IsNot Nothing AndAlso RecurringJournalEntryPostViewModel.RecurringJournalEntryPosts.Count > 0 Then

                RecurringJournalEntryPostViewModel.PostEnabled = RecurringJournalEntryPostViewModel.RecurringJournalEntryPosts.Any(Function(Entity) Entity.CreateJournalEntry = True)

                RecurringJournalEntryPostViewModel.PrintEnabled = True

            Else

                RecurringJournalEntryPostViewModel.PostEnabled = False
                RecurringJournalEntryPostViewModel.PrintEnabled = False

            End If

        End Sub
        Public Sub LoadRecurringJournalEntries(ByRef RecurringJournalEntryPostViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.RecurringJournalEntryPostViewModel)

            Dim PostPeriod As AdvantageFramework.DTO.GeneralLedger.JournalEntry.PostPeriod = Nothing
            Dim SelectedPostPeriodCode As String = String.Empty
            Dim SelectedCycleCode As String = String.Empty

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                If String.IsNullOrWhiteSpace(RecurringJournalEntryPostViewModel.SelectedPostPeriodCode) = False AndAlso
                        String.IsNullOrWhiteSpace(RecurringJournalEntryPostViewModel.SelectedCycleCode) = False Then

                    SelectedPostPeriodCode = RecurringJournalEntryPostViewModel.SelectedPostPeriodCode
                    SelectedCycleCode = RecurringJournalEntryPostViewModel.SelectedCycleCode

                    PostPeriod = RecurringJournalEntryPostViewModel.PostPeriods.SingleOrDefault(Function(Entity) Entity.Code = SelectedPostPeriodCode)

                    RecurringJournalEntryPostViewModel.RecurringJournalEntryPosts = DbContext.GeneralLedgerRecurringEntries.Include("GeneralLedgerRecurringEntryDetails").Include("LastPostPeriod").Include("Cycle").
                                                                                                                            Where(Function(Entity) Entity.CycleCode = SelectedCycleCode AndAlso
                                                                                                                                                   (Entity.IsVoided Is Nothing OrElse Entity.IsVoided = 0) AndAlso
                                                                                                                                                   (Entity.IsInactive Is Nothing OrElse Entity.IsInactive = 0)).ToList.
                                                                                                                            Select(Function(Entity) New AdvantageFramework.DTO.GeneralLedger.JournalEntry.RecurringJournalEntryPost(Entity, DbContext, PostPeriod)).ToList

                    RecurringJournalEntryPostViewModel.RecurringJournalEntryPosts = RecurringJournalEntryPostViewModel.RecurringJournalEntryPosts.Where(Function(Entity) Entity.NumberRemaining > 0 AndAlso Entity.Show = True).ToList

                    RecurringJournalEntryPostViewModel.RecurringJournalEntryPosts = RecurringJournalEntryPostViewModel.RecurringJournalEntryPosts.Where(Function(Entity) SelectedPostPeriodCode >= Entity.StartingPostPeriodCode).ToList

                Else

                    RecurringJournalEntryPostViewModel.RecurringJournalEntryPosts = New Generic.List(Of AdvantageFramework.DTO.GeneralLedger.JournalEntry.RecurringJournalEntryPost)

                End If

            End Using

        End Sub
        Public Sub PostPeriodChanged(ByRef RecurringJournalEntryPostViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.RecurringJournalEntryPostViewModel,
                                     PostPeriodCode As String)

            RecurringJournalEntryPostViewModel.SelectedPostPeriodCode = PostPeriodCode

        End Sub
        Public Sub CycleChanged(ByRef RecurringJournalEntryPostViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.RecurringJournalEntryPostViewModel,
                                CycleCode As String)

            RecurringJournalEntryPostViewModel.SelectedCycleCode = CycleCode

        End Sub
        Public Sub TransactionDateChanged(ByRef RecurringJournalEntryPostViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.RecurringJournalEntryPostViewModel,
                                          TransactionDate As Date)

            RecurringJournalEntryPostViewModel.SelectedTransactionDate = TransactionDate

        End Sub
        Public Sub CreateJournalEntryChanged(ByRef RecurringJournalEntryPostViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.RecurringJournalEntryPostViewModel,
                                             ByRef RecurringJournalEntryPost As AdvantageFramework.DTO.GeneralLedger.JournalEntry.RecurringJournalEntryPost, CreateJournalEntry As Boolean)

            RecurringJournalEntryPost.CreateJournalEntry = CreateJournalEntry

        End Sub

#End Region

    End Class

End Namespace
