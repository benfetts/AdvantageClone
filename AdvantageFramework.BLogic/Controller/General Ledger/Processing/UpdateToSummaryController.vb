Namespace Controller.GeneralLedger.Processing

    Public Class UpdateToSummaryController
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

        Private Sub LoadLists(DbContext As AdvantageFramework.Database.DbContext, ByRef ViewModel As AdvantageFramework.ViewModels.GeneralLedger.Processing.UpdateToSummaryViewModel)

            ViewModel.UnpostedJournalEntryList = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.GeneralLedger.Processing.UnpostedJournalEntry)("exec advsp_gl_processing_load_unposted_journal_entry").ToList

        End Sub

#Region " Public "

        Public Sub New(Session As AdvantageFramework.Security.Session)

            MyBase.New(Session)

        End Sub
        Public Function Load() As AdvantageFramework.ViewModels.GeneralLedger.Processing.UpdateToSummaryViewModel

            Dim ViewModel As AdvantageFramework.ViewModels.GeneralLedger.Processing.UpdateToSummaryViewModel = Nothing
            Dim PostPeriodCodes As IEnumerable(Of String) = Nothing

            ViewModel = New AdvantageFramework.ViewModels.GeneralLedger.Processing.UpdateToSummaryViewModel

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                PostPeriodCodes = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllActiveGLPostPeriods(DbContext).Select(Function(PP) PP.Code).ToArray

                ViewModel.PostPeriodsWithUnpostedEntries = (From Entity In AdvantageFramework.Database.Procedures.GeneralLedger.Load(DbContext)
                                                            Where Entity.PostedDate Is Nothing AndAlso
                                                                  (Entity.IsVoided Is Nothing OrElse Entity.IsVoided = 0) AndAlso
                                                                  Entity.PostPeriodCode IsNot Nothing
                                                            Select Entity.PostPeriod).Distinct.ToList.Select(Function(Entity) New AdvantageFramework.DTO.GeneralLedger.JournalEntry.PostPeriod(Entity)).ToList

                ViewModel.PostPeriodsWithUnpostedEntries = ViewModel.PostPeriodsWithUnpostedEntries.Where(Function(PP) PostPeriodCodes.Contains(PP.Code)).ToList

                LoadLists(DbContext, ViewModel)

                ViewModel.ClearablePostPeriodCodes = (From Entity In AdvantageFramework.Database.Procedures.GLASummaryData.Load(DbContext)
                                                      Where PostPeriodCodes.Contains(Entity.PostPeriodCode)
                                                      Select Entity.PostPeriodCode).Distinct.ToArray

            End Using

            Load = ViewModel

        End Function
        Public Function Save(PostPeriodCode As String, SourceTypes As IEnumerable(Of String), ViewModel As AdvantageFramework.ViewModels.GeneralLedger.Processing.UpdateToSummaryViewModel,
                             ByRef ErrorMessage As String) As Boolean

            Dim Saved As Boolean = False
            Dim GeneralLedgerDetails As Generic.List(Of AdvantageFramework.Database.Entities.GeneralLedgerDetail) = Nothing
            Dim GLASummaryData As AdvantageFramework.Database.Entities.GLASummaryData = Nothing
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim GeneralLedger As AdvantageFramework.Database.Entities.GeneralLedger = Nothing
            Dim GeneralLedgerReversal As AdvantageFramework.Database.Entities.GeneralLedger = Nothing
            Dim PostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing
            'Dim Month As Short = 0
            'Dim Year As Integer = 0
            Dim GeneralLedgerDetailReversal As AdvantageFramework.Database.Entities.GeneralLedgerDetail = Nothing
            Dim ErrorOccurred As Boolean = False
            Dim NowDate As Date = Now
            Dim PPMonth As Short = 0
            Dim PPYear As Integer = 0
            'Dim Transactions As IEnumerable(Of Integer) = Nothing
            'Dim GLACodes As IEnumerable(Of String) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                DbContext.Database.Connection.Open()

                For Each SourceType In SourceTypes

                    DbTransaction = DbContext.Database.BeginTransaction

                    Try

                        For Each UnpostedJournalEntry In ViewModel.UnpostedJournalEntryList.Where(Function(JEL) JEL.PostPeriodCode = PostPeriodCode AndAlso JEL.Source = SourceType).ToList

                            GeneralLedger = AdvantageFramework.Database.Procedures.GeneralLedger.LoadByTransaction(DbContext, UnpostedJournalEntry.Transaction)

                            If GeneralLedger IsNot Nothing AndAlso GeneralLedger.ReverseFlag = "1" AndAlso GeneralLedger.ReversalTransaction.HasValue = False Then

                                PPMonth = GeneralLedger.PostPeriod.Code.Substring(4, 2)
                                PPYear = GeneralLedger.PostPeriod.Code.Substring(0, 4)

                                PPMonth += 1

                                If PPMonth > 12 Then

                                    PPMonth = 1
                                    PPYear += 1

                                End If

                                'If GeneralLedger.PostPeriod.Month.Value = 12 OrElse GeneralLedger.PostPeriod.Month.Value = 99 Then

                                '    Month = 1
                                '    Year = CInt(GeneralLedger.PostPeriod.Year) + 1

                                'Else

                                '    Month = GeneralLedger.PostPeriod.Month.Value + 1
                                '    Year = CInt(GeneralLedger.PostPeriod.Year)

                                'End If

                                PostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadByPostPeriodCode(DbContext, PPYear.ToString & PPMonth.ToString.PadLeft(2, "0"))

                                If PostPeriod Is Nothing Then

                                    Throw New Exception("Cannot create reversing entry for posting period: " & PPYear.ToString & PPMonth.ToString.PadLeft(2, "0") & " and transaction: " & UnpostedJournalEntry.Transaction.ToString.PadLeft(6, "0") & ".  Posting period not on file.")

                                End If

                                GeneralLedgerReversal = New AdvantageFramework.Database.Entities.GeneralLedger
                                GeneralLedgerReversal.EnteredDate = NowDate
                                GeneralLedgerReversal.ModifiedDate = NowDate
                                GeneralLedgerReversal.PostPeriodCode = PostPeriod.Code
                                GeneralLedgerReversal.UserCode = GeneralLedger.UserCode
                                GeneralLedgerReversal.Description = Mid(GeneralLedger.Description, 1, 77) & " - Reversal From:" & GeneralLedger.Transaction.ToString.PadLeft(6, "0")

                                GeneralLedgerReversal.GLSourceCode = GeneralLedger.GLSourceCode
                                GeneralLedgerReversal.IsReversalEntry = 1
                                GeneralLedgerReversal.ReversalTransaction = GeneralLedger.Transaction
                                GeneralLedgerReversal.CreateDate = NowDate

                                If AdvantageFramework.Database.Procedures.GeneralLedger.Insert(DbContext, GeneralLedgerReversal) = False Then

                                    Throw New Exception("Error inserting reversing entry header into the database.")

                                End If

                                GeneralLedger.Description = Mid(GeneralLedger.Description, 1, 75) & " - Reversing Entry:" & GeneralLedgerReversal.Transaction.ToString.PadLeft(6, "0")

                                GeneralLedger.ReversalTransaction = GeneralLedgerReversal.Transaction

                                DbContext.TryAttach(GeneralLedger)

                                DbContext.UpdateObject(GeneralLedger)

                                GeneralLedgerDetails = AdvantageFramework.Database.Procedures.GeneralLedgerDetail.LoadByTransaction(DbContext, UnpostedJournalEntry.Transaction).ToList

                                For Each GeneralLedgerDetail In GeneralLedgerDetails.OrderBy(Function(GLD) GLD.SequenceNumber)

                                    GeneralLedgerDetailReversal = New AdvantageFramework.Database.Entities.GeneralLedgerDetail
                                    GeneralLedgerDetailReversal.GLTransaction = GeneralLedgerReversal.Transaction
                                    GeneralLedgerDetailReversal.GLACode = GeneralLedgerDetail.GLACode
                                    GeneralLedgerDetailReversal.DebitAmount = GeneralLedgerDetail.DebitAmount * -1
                                    GeneralLedgerDetailReversal.CreditAmount = GeneralLedgerDetail.CreditAmount * -1
                                    GeneralLedgerDetailReversal.Remark = Mid(GeneralLedgerDetail.Remark, 1, 127) & " - Reversal From:" & GeneralLedgerDetail.GLTransaction.ToString.PadLeft(6, "0")

                                    GeneralLedgerDetailReversal.GLSourceCode = GeneralLedgerDetail.GLSourceCode
                                    GeneralLedgerDetailReversal.ClientCode = GeneralLedgerDetail.ClientCode
                                    GeneralLedgerDetailReversal.DivisionCode = GeneralLedgerDetail.DivisionCode
                                    GeneralLedgerDetailReversal.ProductCode = GeneralLedgerDetail.ProductCode

                                    If AdvantageFramework.Database.Procedures.GeneralLedgerDetail.Insert(DbContext, GeneralLedgerDetailReversal) = False Then

                                        Throw New Exception("Error inserting reversing entry detail into the database.")

                                    End If

                                    GeneralLedgerDetail.Remark = Mid(GeneralLedgerDetail.Remark, 1, 125) & " - Reversing Entry:" & GeneralLedgerDetailReversal.GLTransaction.ToString.PadLeft(6, "0")

                                    DbContext.TryAttach(GeneralLedgerDetail)

                                    DbContext.UpdateObject(GeneralLedgerDetail)

                                    DbContext.SaveChanges()

                                Next

                            End If

                        Next

                        DbContext.Database.ExecuteSqlCommand(String.Format("exec advsp_gl_update_to_summary '{0}', '{1}'", SourceType, PostPeriodCode))

                        'Transactions = (From Entity In ViewModel.UnpostedJournalEntryList
                        '                Where Entity.PostPeriodCode = PostPeriodCode AndAlso
                        '                      Entity.Source = SourceType
                        '                Select Entity.Transaction).ToArray

                        'GLACodes = (From Entity In AdvantageFramework.Database.Procedures.GeneralLedgerDetail.Load(DbContext)
                        '            Where Transactions.Contains(Entity.GLTransaction)
                        '            Select Entity.GLACode).Distinct.ToArray

                        'For Each GLACode In GLACodes

                        '    GeneralLedgerDetails = (From Entity In AdvantageFramework.Database.Procedures.GeneralLedgerDetail.Load(DbContext)
                        '                            Where Transactions.Contains(Entity.GLTransaction) AndAlso
                        '                                  Entity.GLACode = GLACode
                        '                            Select Entity).ToList

                        '    GLASummaryData = (From Entity In AdvantageFramework.Database.Procedures.GLASummaryData.Load(DbContext)
                        '                      Where Entity.GLACode = GLACode AndAlso
                        '                            Entity.PostPeriodCode = PostPeriodCode
                        '                      Select Entity).SingleOrDefault

                        '    If GLASummaryData IsNot Nothing Then

                        '        GLASummaryData.Debit += GeneralLedgerDetails.Where(Function(GLD) GLD.DebitAmount > 0).Sum(Function(GLD) GLD.DebitAmount)
                        '        GLASummaryData.Credit += GeneralLedgerDetails.Where(Function(GLD) GLD.DebitAmount < 0).Sum(Function(GLD) GLD.DebitAmount)

                        '        DbContext.Entry(GLASummaryData).State = Entity.EntityState.Modified

                        '    Else

                        '        GLASummaryData = New Database.Entities.GLASummaryData
                        '        GLASummaryData.DbContext = DbContext
                        '        GLASummaryData.GLACode = GLACode
                        '        GLASummaryData.PostPeriodCode = PostPeriodCode
                        '        GLASummaryData.Quantity = 0
                        '        GLASummaryData.Budget1 = 0
                        '        GLASummaryData.Mod = 0

                        '        GLASummaryData.Debit = GeneralLedgerDetails.Where(Function(GLD) GLD.DebitAmount > 0).Sum(Function(GLD) GLD.DebitAmount)
                        '        GLASummaryData.Credit = GeneralLedgerDetails.Where(Function(GLD) GLD.DebitAmount < 0).Sum(Function(GLD) GLD.DebitAmount)

                        '        DbContext.GLASummaryDatas.Add(GLASummaryData)

                        '    End If

                        '    DbContext.SaveChanges()

                        'Next

                        'For Each Transaction In Transactions

                        '    DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.GLENTHDR SET GLEHPOSTSUM = getdate() WHERE GLEHXACT = {0}", Transaction))

                        'Next

                        DbTransaction.Commit()

                    Catch ex As Exception
                        ErrorMessage = ex.Message
                        DbTransaction.Rollback()
                        ErrorOccurred = True
                    End Try

                    If ErrorOccurred Then

                        Exit For

                    End If

                    If ErrorOccurred Then

                        Exit For

                    End If

                Next

                If ErrorOccurred = False Then

                    Saved = True

                End If

            End Using

            Save = Saved

        End Function
        Public Function Clear(PostPeriodCode As String, ByRef ErrorMessage As String) As Boolean

            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim Cleared As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                DbContext.Database.Connection.Open()

                DbTransaction = DbContext.Database.BeginTransaction

                Try

                    DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.GLENTHDR SET GLEHREVFLG = NULL WHERE GLEHREVFLG ='1' AND GLEHPP = '{0}' AND GLEHPOSTSUM IS NOT NULL", PostPeriodCode))

                    DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.GLENTHDR SET GLEHPOSTSUM = NULL WHERE GLEHPP = '{0}'", PostPeriodCode))

                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.GLSUMMARY WHERE GLSUMMARY.GLSPP = '{0}'", PostPeriodCode))

                    DbTransaction.Commit()

                    Cleared = True

                Catch ex As Exception
                    DbTransaction.Rollback()
                    ErrorMessage = ex.Message
                End Try

            End Using

            Clear = Cleared

        End Function

#End Region

#End Region

    End Class

End Namespace
