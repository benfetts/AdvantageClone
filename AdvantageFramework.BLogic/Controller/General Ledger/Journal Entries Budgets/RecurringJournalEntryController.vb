Namespace Controller.GeneralLedger.JournalEntriesBudgets

    Public Class RecurringJournalEntryController
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

        Public Function Load(ControlNumber As Integer) As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.RecurringJournalEntryViewModel

            Dim RecurringJournalEntryViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.RecurringJournalEntryViewModel = Nothing
            Dim GeneralLedgerRecurringEntry As AdvantageFramework.Database.Entities.GeneralLedgerRecurringEntry = Nothing
            Dim PostPeriods As Generic.List(Of AdvantageFramework.DTO.GeneralLedger.JournalEntry.PostPeriod) = Nothing
            Dim Cycles As Generic.List(Of AdvantageFramework.DTO.GeneralLedger.JournalEntry.Cycle) = Nothing
            Dim CurrentPostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                RecurringJournalEntryViewModel = New AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.RecurringJournalEntryViewModel()

                If ControlNumber > 0 Then

                    GeneralLedgerRecurringEntry = DbContext.GeneralLedgerRecurringEntries.Find(ControlNumber)

                    RecurringJournalEntryViewModel.RecurringJournalEntry = New DTO.GeneralLedger.JournalEntry.RecurringJournalEntry(GeneralLedgerRecurringEntry)

                    RecurringJournalEntryViewModel.RecurringJournalEntryDetails.AddRange(From GLRED In DbContext.GeneralLedgerRecurringEntryDetails.Include("GeneralLedgerAccount").Where(Function(Entity) Entity.ControlNumber = ControlNumber).ToList
                                                                                         Select New AdvantageFramework.DTO.GeneralLedger.JournalEntry.RecurringJournalEntryDetail(GLRED))

                    RecurringJournalEntryViewModel.RecurringJournalEntryDetails = RecurringJournalEntryViewModel.RecurringJournalEntryDetails.OrderBy(Function(Entity) Entity.SequenceNumber).ToList

                    If RecurringJournalEntryViewModel.RecurringJournalEntryDetails IsNot Nothing AndAlso RecurringJournalEntryViewModel.RecurringJournalEntryDetails.Count > 0 Then

                        For Each RecurringJournalEntryDetail In RecurringJournalEntryViewModel.RecurringJournalEntryDetails

                            If RecurringJournalEntryDetail.Remark = RecurringJournalEntryViewModel.RecurringJournalEntry.Description Then

                                RecurringJournalEntryDetail.RemarkIsTheSameAsHeaderDescription = True

                            End If

                        Next

                    End If

                    RecurringJournalEntryViewModel.AddEnabled = False
                    RecurringJournalEntryViewModel.UpdateEnabled = True
                    RecurringJournalEntryViewModel.CopyEnabled = True

                ElseIf ControlNumber = 0 Then

                    RecurringJournalEntryViewModel.RecurringJournalEntry = New DTO.GeneralLedger.JournalEntry.RecurringJournalEntry()

                    Cycles = AdvantageFramework.Database.Procedures.Cycle.LoadAllActive(DbContext).ToList.Select(Function(Entity) New AdvantageFramework.DTO.GeneralLedger.JournalEntry.Cycle(Entity)).ToList

                    If Cycles IsNot Nothing Then

                        Cycles = Cycles.OrderBy(Function(Cycle) Cycle.Code).ToList

                        If Cycles.Any(Function(Entity) Entity.Code = "glmth") Then

                            RecurringJournalEntryViewModel.RecurringJournalEntry.CycleCode = Cycles.FirstOrDefault(Function(Entity) Entity.Code = "glmth").Code

                        ElseIf Cycles.Count > 0 Then

                            RecurringJournalEntryViewModel.RecurringJournalEntry.CycleCode = Cycles.First.Code

                        End If

                    End If

                    PostPeriods = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllActiveGLPostPeriods(DbContext).ToList.Select(Function(Entity) New AdvantageFramework.DTO.GeneralLedger.JournalEntry.PostPeriod(Entity)).ToList

                    If PostPeriods IsNot Nothing Then

                        PostPeriods = PostPeriods.OrderByDescending(Function(PP) PP.Code).ToList

                        CurrentPostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentGLPostPeriod(DbContext)

                        If CurrentPostPeriod IsNot Nothing Then

                            RecurringJournalEntryViewModel.RecurringJournalEntry.StartingPostPeriodCode = CurrentPostPeriod.Code

                        Else

                            If PostPeriods.Count > 0 Then

                                RecurringJournalEntryViewModel.RecurringJournalEntry.StartingPostPeriodCode = PostPeriods.First.Code

                            End If

                        End If

                    End If

                    RecurringJournalEntryViewModel.RecurringJournalEntry.ReverseFlag = False
                    RecurringJournalEntryViewModel.RecurringJournalEntry.UserCode = Session.UserCode
                    RecurringJournalEntryViewModel.RecurringJournalEntry.EnteredDate = Now

                    RecurringJournalEntryViewModel.RecurringJournalEntryDetails = New Generic.List(Of AdvantageFramework.DTO.GeneralLedger.JournalEntry.RecurringJournalEntryDetail)

                    RecurringJournalEntryViewModel.AddEnabled = True
                    RecurringJournalEntryViewModel.UpdateEnabled = False
                    RecurringJournalEntryViewModel.CopyEnabled = False

                Else

                    RecurringJournalEntryViewModel.RecurringJournalEntry = New DTO.GeneralLedger.JournalEntry.RecurringJournalEntry()

                    RecurringJournalEntryViewModel.RecurringJournalEntryDetails = New Generic.List(Of AdvantageFramework.DTO.GeneralLedger.JournalEntry.RecurringJournalEntryDetail)

                    RecurringJournalEntryViewModel.AddEnabled = False
                    RecurringJournalEntryViewModel.UpdateEnabled = False
                    RecurringJournalEntryViewModel.CopyEnabled = False

                End If

                RecurringJournalEntryViewModel.RepositoryClients = AdvantageFramework.Database.Procedures.Client.LoadAllActive(DbContext).ToList.Select(Function(Entity) New AdvantageFramework.DTO.GeneralLedger.JournalEntry.Client(Entity)).ToList
                RecurringJournalEntryViewModel.RepositoryGeneralLedgerAccounts = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadWithOfficeLimits(DbContext, Session).ToList.Where(Function(GeneralLedgerAccount) GeneralLedgerAccount.Active = "A").Select(Function(Entity) New AdvantageFramework.DTO.GeneralLedger.JournalEntry.GeneralLedgerAccount(Entity)).ToList

                If RecurringJournalEntryViewModel.RepositoryGeneralLedgerAccounts Is Nothing OrElse RecurringJournalEntryViewModel.RepositoryGeneralLedgerAccounts.Count = 0 Then

                    RecurringJournalEntryViewModel.RepositoryGeneralLedgerAccounts = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadAllActive(DbContext).Include("GeneralLedgerOfficeCrossReference").Include("GeneralLedgerOfficeCrossReference.Office").ToList.
                                                                                                                                             Select(Function(Entity) New AdvantageFramework.DTO.GeneralLedger.JournalEntry.GeneralLedgerAccount(Entity)).ToList

                End If

            End Using

            Load = RecurringJournalEntryViewModel

        End Function
        Public Function Add(ByRef RecurringJournalEntryViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.RecurringJournalEntryViewModel,
                            ByRef ErrorMessage As String) As Boolean

            Dim Added As Boolean = False
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim GeneralLedgerRecurringEntry As AdvantageFramework.Database.Entities.GeneralLedgerRecurringEntry = Nothing
            Dim GeneralLedgerRecurringEntryDetail As AdvantageFramework.Database.Entities.GeneralLedgerRecurringEntryDetail = Nothing
            Dim ControlNumber As Integer = 0

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                DbContext.Database.Connection.Open()
                DbContext.Configuration.AutoDetectChangesEnabled = False

                Try

                    DbTransaction = DbContext.Database.BeginTransaction

                    GeneralLedgerRecurringEntry = New AdvantageFramework.Database.Entities.GeneralLedgerRecurringEntry

                    RecurringJournalEntryViewModel.RecurringJournalEntry.SaveToEntity(GeneralLedgerRecurringEntry)

                    ControlNumber = DbContext.Database.SqlQuery(Of Integer)("SELECT IDSXACT FROM dbo.IDS WHERE IDSTABLE = 'GLRJEHDR'").FirstOrDefault + 1

                    GeneralLedgerRecurringEntry.ControlNumber = ControlNumber
                    RecurringJournalEntryViewModel.RecurringJournalEntry.ControlNumber = GeneralLedgerRecurringEntry.ControlNumber

                    DbContext.GeneralLedgerRecurringEntries.Add(GeneralLedgerRecurringEntry)

                    For Each RecurringJournalEntryDetail In RecurringJournalEntryViewModel.RecurringJournalEntryDetails

                        GeneralLedgerRecurringEntryDetail = New AdvantageFramework.Database.Entities.GeneralLedgerRecurringEntryDetail

                        If String.IsNullOrWhiteSpace(RecurringJournalEntryDetail.Remark) Then

                            RecurringJournalEntryDetail.Remark = RecurringJournalEntryViewModel.RecurringJournalEntry.Description

                        End If

                        RecurringJournalEntryDetail.SaveToEntity(GeneralLedgerRecurringEntryDetail)

                        RecurringJournalEntryDetail.ControlNumber = GeneralLedgerRecurringEntry.ControlNumber
                        RecurringJournalEntryDetail.SequenceNumber = RecurringJournalEntryViewModel.RecurringJournalEntryDetails.IndexOf(RecurringJournalEntryDetail) + 1

                        GeneralLedgerRecurringEntryDetail.ControlNumber = RecurringJournalEntryDetail.ControlNumber
                        GeneralLedgerRecurringEntryDetail.SequenceNumber = RecurringJournalEntryDetail.SequenceNumber

                        DbContext.GeneralLedgerRecurringEntryDetails.Add(GeneralLedgerRecurringEntryDetail)

                    Next

                    DbContext.Configuration.AutoDetectChangesEnabled = True
                    DbContext.SaveChanges()

                    DbContext.Database.ExecuteSqlCommand("UPDATE dbo.IDS SET IDSXACT = " & ControlNumber & " WHERE IDSTABLE = 'GLRJEHDR'")

                    DbTransaction.Commit()

                    Added = True

                Catch ex As Exception
                    DbTransaction.Rollback()
                    ErrorMessage = "Failed trying to save data to the database. Please contact software support."
                    ErrorMessage += System.Environment.NewLine & ex.Message
                    Added = False
                End Try

            End Using

            Add = Added

        End Function
        Public Function Save(ByRef RecurringJournalEntryViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.RecurringJournalEntryViewModel,
                             ByRef ErrorMessage As String) As Boolean

            Dim Saved As Boolean = False
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim GeneralLedgerRecurringEntry As AdvantageFramework.Database.Entities.GeneralLedgerRecurringEntry = Nothing
            Dim GeneralLedgerRecurringEntryDetail As AdvantageFramework.Database.Entities.GeneralLedgerRecurringEntryDetail = Nothing
            Dim GeneralLedgerRecurringEntryDetails As Generic.List(Of AdvantageFramework.Database.Entities.GeneralLedgerRecurringEntryDetail) = Nothing
            Dim NextSequenceNumber As Integer = 1
            Dim SequenceNumbers As Generic.List(Of Integer) = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                DbContext.Database.Connection.Open()
                DbContext.Configuration.AutoDetectChangesEnabled = False

                Try

                    DbTransaction = DbContext.Database.BeginTransaction

                    RecurringJournalEntryViewModel.RecurringJournalEntry.ModifiedDate = Now
                    RecurringJournalEntryViewModel.RecurringJournalEntry.ModifiedFlag = True

                    GeneralLedgerRecurringEntry = DbContext.GeneralLedgerRecurringEntries.Find(RecurringJournalEntryViewModel.RecurringJournalEntry.ControlNumber)

                    GeneralLedgerRecurringEntryDetails = DbContext.GeneralLedgerRecurringEntryDetails.Where(Function(Entity) Entity.ControlNumber = GeneralLedgerRecurringEntry.ControlNumber).ToList

                    If GeneralLedgerRecurringEntryDetails IsNot Nothing AndAlso GeneralLedgerRecurringEntryDetails.Count > 0 Then

                        NextSequenceNumber = GeneralLedgerRecurringEntryDetails.Select(Function(Entity) Entity.SequenceNumber).Max + 1

                    Else

                        NextSequenceNumber = 1

                    End If

                    RecurringJournalEntryViewModel.RecurringJournalEntry.SaveToEntity(GeneralLedgerRecurringEntry)

                    SequenceNumbers = New Generic.List(Of Integer)

                    For Each RecurringJournalEntryDetail In RecurringJournalEntryViewModel.RecurringJournalEntryDetails

                        If RecurringJournalEntryDetail.ControlNumber = 0 AndAlso RecurringJournalEntryDetail.SequenceNumber.GetValueOrDefault(0) = 0 Then

                            GeneralLedgerRecurringEntryDetail = New AdvantageFramework.Database.Entities.GeneralLedgerRecurringEntryDetail

                            RecurringJournalEntryDetail.ControlNumber = GeneralLedgerRecurringEntry.ControlNumber
                            RecurringJournalEntryDetail.SequenceNumber = NextSequenceNumber

                            NextSequenceNumber += 1

                            GeneralLedgerRecurringEntryDetail.ControlNumber = RecurringJournalEntryDetail.ControlNumber
                            GeneralLedgerRecurringEntryDetail.SequenceNumber = RecurringJournalEntryDetail.SequenceNumber

                            DbContext.GeneralLedgerRecurringEntryDetails.Add(GeneralLedgerRecurringEntryDetail)

                        ElseIf RecurringJournalEntryDetail.ControlNumber > 0 AndAlso RecurringJournalEntryDetail.SequenceNumber.GetValueOrDefault(0) > 0 Then

                            Try

                                GeneralLedgerRecurringEntryDetail = GeneralLedgerRecurringEntryDetails.FirstOrDefault(Function(Entity) Entity.ControlNumber = RecurringJournalEntryDetail.ControlNumber AndAlso Entity.SequenceNumber = RecurringJournalEntryDetail.SequenceNumber)

                            Catch ex As Exception
                                GeneralLedgerRecurringEntryDetail = Nothing
                            End Try

                            If GeneralLedgerRecurringEntryDetail Is Nothing Then

                                Throw New Exception("Failed to find journal entry detail.")

                            End If

                        End If

                        RecurringJournalEntryDetail.SaveToEntity(GeneralLedgerRecurringEntryDetail)

                        SequenceNumbers.Add(GeneralLedgerRecurringEntryDetail.SequenceNumber)

                    Next

                    For Each GeneralLedgerRecurringEntryDetail In GeneralLedgerRecurringEntryDetails.ToList.Where(Function(Entity) SequenceNumbers.Contains(Entity.SequenceNumber) = False)

                        DbContext.GeneralLedgerRecurringEntryDetails.Remove(GeneralLedgerRecurringEntryDetail)

                    Next

                    DbContext.Configuration.AutoDetectChangesEnabled = True
                    DbContext.SaveChanges()

                    DbTransaction.Commit()

                    Saved = True

                Catch ex As Exception
                    DbTransaction.Rollback()
                    ErrorMessage = "Failed trying to save data to the database. Please contact software support."
                    ErrorMessage += System.Environment.NewLine & ex.Message
                    Saved = False
                End Try

            End Using

            Save = Saved

        End Function
        Public Function Copy(ByRef RecurringJournalEntryViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.RecurringJournalEntryViewModel,
                             ByRef ControlNumber As Integer,
                             ByRef ErrorMessage As String) As Boolean

            Dim Copied As Boolean = False
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim GeneralLedgerRecurringEntry As AdvantageFramework.Database.Entities.GeneralLedgerRecurringEntry = Nothing
            Dim GeneralLedgerRecurringEntryDetail As AdvantageFramework.Database.Entities.GeneralLedgerRecurringEntryDetail = Nothing
            Dim CurrentPostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                DbContext.Database.Connection.Open()
                DbContext.Configuration.AutoDetectChangesEnabled = False

                Try

                    DbTransaction = DbContext.Database.BeginTransaction

                    ControlNumber = DbContext.Database.SqlQuery(Of Integer)("SELECT IDSXACT FROM dbo.IDS WHERE IDSTABLE = 'GLRJEHDR'").FirstOrDefault + 1

                    If RecurringJournalEntryViewModel.RecurringJournalEntry.LegacyEntry Then

                        CurrentPostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentGLPostPeriod(DbContext)

                    End If

                    GeneralLedgerRecurringEntry = New AdvantageFramework.Database.Entities.GeneralLedgerRecurringEntry

                    GeneralLedgerRecurringEntry.ControlNumber = ControlNumber
                    GeneralLedgerRecurringEntry.Description = RecurringJournalEntryViewModel.RecurringJournalEntry.Description
                    GeneralLedgerRecurringEntry.EnteredDate = RecurringJournalEntryViewModel.RecurringJournalEntry.EnteredDate
                    GeneralLedgerRecurringEntry.CycleCode = RecurringJournalEntryViewModel.RecurringJournalEntry.CycleCode
                    GeneralLedgerRecurringEntry.ReverseFlag = If(RecurringJournalEntryViewModel.RecurringJournalEntry.ReverseFlag, "1", Nothing)

                    GeneralLedgerRecurringEntry.IsInactive = If(RecurringJournalEntryViewModel.RecurringJournalEntry.IsInactive, 1, 0)
                    GeneralLedgerRecurringEntry.IsVoided = If(RecurringJournalEntryViewModel.RecurringJournalEntry.IsVoided, 1, Nothing)
                    GeneralLedgerRecurringEntry.StartingPostPeriodCode = RecurringJournalEntryViewModel.RecurringJournalEntry.StartingPostPeriodCode
                    GeneralLedgerRecurringEntry.NumberOfPostings = RecurringJournalEntryViewModel.RecurringJournalEntry.NumberOfPostings
                    GeneralLedgerRecurringEntry.UnlimitedPostings = RecurringJournalEntryViewModel.RecurringJournalEntry.UnlimitedPostings

                    GeneralLedgerRecurringEntry.EnteredDate = Now
                    GeneralLedgerRecurringEntry.UserCode = Me.Session.UserCode
                    GeneralLedgerRecurringEntry.LastPostPeriodCode = Nothing
                    GeneralLedgerRecurringEntry.LastPostingDate = Nothing
                    GeneralLedgerRecurringEntry.LastPostingUserCode = Nothing
                    GeneralLedgerRecurringEntry.ModifiedFlag = Nothing
                    GeneralLedgerRecurringEntry.ModifiedDate = Now

                    If RecurringJournalEntryViewModel.RecurringJournalEntry.LegacyEntry Then

                        If CurrentPostPeriod IsNot Nothing Then

                            GeneralLedgerRecurringEntry.StartingPostPeriodCode = CurrentPostPeriod.Code

                        End If

                        GeneralLedgerRecurringEntry.NumberOfPostings = Nothing
                        GeneralLedgerRecurringEntry.UnlimitedPostings = True

                    End If

                    DbContext.GeneralLedgerRecurringEntries.Add(GeneralLedgerRecurringEntry)

                    For Each RecurringJournalEntryDetail In RecurringJournalEntryViewModel.RecurringJournalEntryDetails

                        GeneralLedgerRecurringEntryDetail = New AdvantageFramework.Database.Entities.GeneralLedgerRecurringEntryDetail

                        GeneralLedgerRecurringEntryDetail.ControlNumber = ControlNumber
                        GeneralLedgerRecurringEntryDetail.SequenceNumber = RecurringJournalEntryDetail.SequenceNumber

                        RecurringJournalEntryDetail.SaveToEntity(GeneralLedgerRecurringEntryDetail)

                        DbContext.GeneralLedgerRecurringEntryDetails.Add(GeneralLedgerRecurringEntryDetail)

                    Next

                    DbContext.Configuration.AutoDetectChangesEnabled = True
                    DbContext.SaveChanges()

                    DbContext.Database.ExecuteSqlCommand("UPDATE dbo.IDS SET IDSXACT = " & ControlNumber & " WHERE IDSTABLE = 'GLRJEHDR'")

                    DbTransaction.Commit()

                    Copied = True

                Catch ex As Exception
                    DbTransaction.Rollback()
                    ErrorMessage = "Failed trying to save data to the database. Please contact software support."
                    ErrorMessage += System.Environment.NewLine & ex.Message
                    Copied = False
                End Try

            End Using

            Copy = Copied

        End Function
        Public Function Details_CopyFrom(ByRef RecurringJournalEntryViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.RecurringJournalEntryViewModel,
                                         ControlNumber As Integer,
                                         ByRef ErrorMessage As String) As Boolean

            Dim Copied As Boolean = False
            Dim RecurringJournalEntryDetail As AdvantageFramework.DTO.GeneralLedger.JournalEntry.RecurringJournalEntryDetail = Nothing
            Dim GeneralLedgerRecurringEntryDetail As AdvantageFramework.Database.Entities.GeneralLedgerRecurringEntryDetail = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                DbContext.Database.Connection.Open()

                Try

                    For Each GeneralLedgerRecurringEntryDetail In (From Entity In DbContext.GeneralLedgerRecurringEntryDetails.Include("GeneralLedgerAccount")
                                                                   Where Entity.ControlNumber = ControlNumber
                                                                   Select Entity).ToList

                        RecurringJournalEntryDetail = New AdvantageFramework.DTO.GeneralLedger.JournalEntry.RecurringJournalEntryDetail(GeneralLedgerRecurringEntryDetail)

                        RecurringJournalEntryDetail.ControlNumber = 0
                        RecurringJournalEntryDetail.SequenceNumber = Nothing

                        RecurringJournalEntryViewModel.RecurringJournalEntryDetails.Add(RecurringJournalEntryDetail)

                    Next

                    Copied = True

                Catch ex As Exception
                    ErrorMessage = "Failed trying to copy details. Please contact software support."
                    ErrorMessage += System.Environment.NewLine & ex.Message
                    Copied = False
                End Try

            End Using

            Details_CopyFrom = Copied

        End Function
        Public Function Validate(ByRef RecurringJournalEntryViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.RecurringJournalEntryViewModel,
                                 ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Credits As Decimal = 0
            Dim Debits As Decimal = 0
            Dim Validated As Boolean = False

            If RecurringJournalEntryViewModel.RecurringJournalEntryDetails IsNot Nothing AndAlso RecurringJournalEntryViewModel.RecurringJournalEntryDetails.Count > 0 Then

                For Each RecurringJournalEntryDetail In RecurringJournalEntryViewModel.RecurringJournalEntryDetails

                    If RecurringJournalEntryDetail.CDPRequired Then

                        If String.IsNullOrWhiteSpace(RecurringJournalEntryDetail.ClientCode) OrElse
                                String.IsNullOrWhiteSpace(RecurringJournalEntryDetail.DivisionCode) OrElse
                                String.IsNullOrWhiteSpace(RecurringJournalEntryDetail.ProductCode) Then

                            ErrorMessage = "CDP required for journal entry detail."
                            Exit For

                        End If

                    End If

                Next

                Try

                    Credits = RecurringJournalEntryViewModel.RecurringJournalEntryDetails.Select(Function(Entity) Entity.CreditAmount.GetValueOrDefault(0)).Sum

                Catch ex As Exception
                    Credits = 0
                End Try

                Try

                    Debits = RecurringJournalEntryViewModel.RecurringJournalEntryDetails.Select(Function(Entity) Entity.DebitAmount.GetValueOrDefault(0)).Sum

                Catch ex As Exception
                    Debits = 0
                End Try

                If Math.Abs(Debits) = Math.Abs(Credits) Then

                    Validated = True

                Else

                    If String.IsNullOrWhiteSpace(ErrorMessage) Then

                        ErrorMessage = "Out of balance journal entry."

                    Else

                        ErrorMessage &= System.Environment.NewLine & "Out of balance journal entry."

                    End If

                End If

            Else

                ErrorMessage = "Journal Entry must have details."

            End If

            Validate = Validated

        End Function
        Public Sub GetRepositoryGLDetails(ByRef RecurringJournalEntryViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.RecurringJournalEntryViewModel, GLACode As String,
                                          ByRef RecurringJournalEntryDetail As AdvantageFramework.DTO.GeneralLedger.JournalEntry.RecurringJournalEntryDetail)

            'objects
            Dim GeneralLedgerAccount As AdvantageFramework.DTO.GeneralLedger.JournalEntry.GeneralLedgerAccount = Nothing

            If RecurringJournalEntryViewModel.RepositoryGeneralLedgerAccounts IsNot Nothing Then

                Try

                    GeneralLedgerAccount = RecurringJournalEntryViewModel.RepositoryGeneralLedgerAccounts.Where(Function(Entity) Entity.Code = GLACode).FirstOrDefault

                Catch ex As Exception
                    GeneralLedgerAccount = Nothing
                End Try

                If GeneralLedgerAccount IsNot Nothing Then

                    RecurringJournalEntryDetail.GLAccountDescription = GeneralLedgerAccount.Description
                    RecurringJournalEntryDetail.CDPRequired = GeneralLedgerAccount.CDPRequired

                End If

            End If

        End Sub
        Public Function GetRepositoryGLDescription(ByRef RecurringJournalEntryViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.RecurringJournalEntryViewModel, GLACode As String) As String

            'objects
            Dim GLDescription As String = Nothing
            Dim GeneralLedgerAccount As AdvantageFramework.DTO.GeneralLedger.JournalEntry.GeneralLedgerAccount = Nothing

            If RecurringJournalEntryViewModel.RepositoryGeneralLedgerAccounts IsNot Nothing Then

                Try

                    GeneralLedgerAccount = RecurringJournalEntryViewModel.RepositoryGeneralLedgerAccounts.Where(Function(Entity) Entity.Code = GLACode).FirstOrDefault

                Catch ex As Exception
                    GeneralLedgerAccount = Nothing
                End Try

                If GeneralLedgerAccount IsNot Nothing Then

                    GLDescription = GeneralLedgerAccount.Description

                End If

            End If

            GetRepositoryGLDescription = GLDescription

        End Function
        Public Sub RecurringJournalEntryDetailClientCodeChanged(ByRef RecurringJournalEntryViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.RecurringJournalEntryViewModel,
                                                                ClientCode As String, ByRef RecurringJournalEntryDetail As AdvantageFramework.DTO.GeneralLedger.JournalEntry.RecurringJournalEntryDetail)

            'objects
            Dim DivisionViews As Generic.List(Of AdvantageFramework.Database.Views.DivisionView) = Nothing
            Dim ProductViews As Generic.List(Of AdvantageFramework.Database.Views.ProductView) = Nothing

            If String.IsNullOrWhiteSpace(ClientCode) = False Then

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        DivisionViews = AdvantageFramework.Database.Procedures.DivisionView.LoadByClientCode(DbContext, ClientCode).ToList

                    End Using

                Catch ex As Exception

                End Try

                If DivisionViews IsNot Nothing AndAlso DivisionViews.Count = 1 Then

                    RecurringJournalEntryDetail.DivisionCode = DivisionViews.FirstOrDefault.DivisionCode

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                            ProductViews = AdvantageFramework.Database.Procedures.ProductView.LoadByClientAndDivisionCode(DbContext, ClientCode, RecurringJournalEntryDetail.DivisionCode).ToList

                        End Using

                    Catch ex As Exception

                    End Try

                    If ProductViews IsNot Nothing AndAlso ProductViews.Count = 1 Then

                        RecurringJournalEntryDetail.ProductCode = ProductViews.FirstOrDefault.ProductCode

                    End If

                End If

            Else

                RecurringJournalEntryDetail.DivisionCode = Nothing
                RecurringJournalEntryDetail.ProductCode = Nothing

            End If

        End Sub
        Public Sub RecurringJournalEntryDetailDivisionCodeChanged(ByRef RecurringJournalEntryViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.RecurringJournalEntryViewModel,
                                                                  DivisionCode As String, ByRef RecurringJournalEntryDetail As AdvantageFramework.DTO.GeneralLedger.JournalEntry.RecurringJournalEntryDetail)

            'objects
            Dim ProductViews As Generic.List(Of AdvantageFramework.Database.Views.ProductView) = Nothing

            If String.IsNullOrWhiteSpace(DivisionCode) = False Then

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        ProductViews = AdvantageFramework.Database.Procedures.ProductView.LoadByClientAndDivisionCode(DbContext, RecurringJournalEntryDetail.ClientCode, DivisionCode).ToList

                    End Using

                Catch ex As Exception

                End Try

                If ProductViews IsNot Nothing AndAlso ProductViews.Count = 1 Then

                    RecurringJournalEntryDetail.ProductCode = ProductViews.FirstOrDefault.ProductCode

                End If

            Else

                RecurringJournalEntryDetail.ProductCode = Nothing

            End If

        End Sub
        Public Sub LoadRepositoryDivisions(ByRef RecurringJournalEntryViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.RecurringJournalEntryViewModel,
                                           ClientCode As String)

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                RecurringJournalEntryViewModel.RepositoryDivisions = AdvantageFramework.Database.Procedures.DivisionView.LoadByClientCode(DbContext, ClientCode).ToList.Select(Function(Entity) New AdvantageFramework.DTO.GeneralLedger.JournalEntry.Division(Entity)).ToList

            End Using

        End Sub
        Public Sub LoadRepositoryProducts(ByRef RecurringJournalEntryViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.RecurringJournalEntryViewModel,
                                          ClientCode As String, DivisionCode As String)

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                RecurringJournalEntryViewModel.RepositoryProducts = AdvantageFramework.Database.Procedures.ProductView.LoadByClientAndDivisionCode(DbContext, ClientCode, DivisionCode).ToList.Select(Function(Entity) New AdvantageFramework.DTO.GeneralLedger.JournalEntry.Product(Entity)).ToList

            End Using

        End Sub
        Public Sub SelectedDetailChanged(ByRef RecurringJournalEntryViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.RecurringJournalEntryViewModel,
                                         IsNewItemRow As Boolean,
                                         RecurringJournalEntryDetails As Generic.List(Of AdvantageFramework.DTO.GeneralLedger.JournalEntry.RecurringJournalEntryDetail))

            RecurringJournalEntryViewModel.SelectedRecurringJournalEntryDetails = RecurringJournalEntryDetails

            RecurringJournalEntryViewModel.Details_IsNewRow = IsNewItemRow
            RecurringJournalEntryViewModel.Details_CancelEnabled = IsNewItemRow
            RecurringJournalEntryViewModel.Details_DeleteEnabled = (Not IsNewItemRow AndAlso RecurringJournalEntryViewModel.HasASelectedRecurringJournalEntryDetail)
            RecurringJournalEntryViewModel.Details_CopyFromEnabled = (Not IsNewItemRow)
            RecurringJournalEntryViewModel.Details_ReverseDebitCreditsEnabled = (Not IsNewItemRow)

        End Sub
        Public Sub Details_InitNewRowEvent(ByRef RecurringJournalEntryViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.RecurringJournalEntryViewModel)

            RecurringJournalEntryViewModel.Details_IsNewRow = True
            RecurringJournalEntryViewModel.Details_CancelEnabled = True
            RecurringJournalEntryViewModel.Details_DeleteEnabled = False
            RecurringJournalEntryViewModel.Details_CopyFromEnabled = False
            RecurringJournalEntryViewModel.Details_ReverseDebitCreditsEnabled = False

        End Sub
        Public Sub Details_CancelNewItemRow(ByRef RecurringJournalEntryViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.RecurringJournalEntryViewModel)

            RecurringJournalEntryViewModel.Details_IsNewRow = False
            RecurringJournalEntryViewModel.Details_CancelEnabled = False
            RecurringJournalEntryViewModel.Details_DeleteEnabled = RecurringJournalEntryViewModel.HasASelectedRecurringJournalEntryDetail
            RecurringJournalEntryViewModel.Details_CopyFromEnabled = True
            RecurringJournalEntryViewModel.Details_ReverseDebitCreditsEnabled = True

        End Sub
        Public Sub Details_Delete(ByRef RecurringJournalEntryViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.RecurringJournalEntryViewModel)

            If RecurringJournalEntryViewModel.HasASelectedRecurringJournalEntryDetail Then

                For Each RecurringJournalEntryDetail In RecurringJournalEntryViewModel.SelectedRecurringJournalEntryDetails

                    RecurringJournalEntryViewModel.RecurringJournalEntryDetails.Remove(RecurringJournalEntryDetail)

                Next

            End If

        End Sub
        Public Sub ReverseDebitCredit(ByRef RecurringJournalEntryViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.RecurringJournalEntryViewModel)

            For Each RecurringJournalEntryDetail In RecurringJournalEntryViewModel.RecurringJournalEntryDetails

                If RecurringJournalEntryDetail.CreditAmount.HasValue Then

                    RecurringJournalEntryDetail.DebitAmount = Math.Abs(RecurringJournalEntryDetail.CreditAmount.Value)
                    RecurringJournalEntryDetail.CreditAmount = Nothing

                ElseIf RecurringJournalEntryDetail.DebitAmount.HasValue Then

                    RecurringJournalEntryDetail.CreditAmount = -Math.Abs(RecurringJournalEntryDetail.DebitAmount.Value)
                    RecurringJournalEntryDetail.DebitAmount = Nothing

                End If

            Next

        End Sub
        Public Function LoadCycles() As Generic.List(Of AdvantageFramework.DTO.GeneralLedger.JournalEntry.Cycle)

            'objects
            Dim Cycles As Generic.List(Of AdvantageFramework.DTO.GeneralLedger.JournalEntry.Cycle) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Cycles = AdvantageFramework.Database.Procedures.Cycle.LoadAllActive(DbContext).ToList.Select(Function(Entity) New AdvantageFramework.DTO.GeneralLedger.JournalEntry.Cycle(Entity)).ToList

            End Using

            LoadCycles = Cycles

        End Function
        Public Function LoadPostPeriods() As Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)

            'objects
            Dim ComboBoxItems As Generic.List(Of AdvantageFramework.DTO.ComboBoxItem) = Nothing
            Dim PostPeriods As Generic.List(Of AdvantageFramework.DTO.GeneralLedger.JournalEntry.PostPeriod) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                PostPeriods = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllActiveNonYearEndPostPeriods(DbContext).ToList.Select(Function(Entity) New AdvantageFramework.DTO.GeneralLedger.JournalEntry.PostPeriod(Entity)).ToList

            End Using

            If PostPeriods IsNot Nothing Then

                ComboBoxItems = (From PostPeriod In PostPeriods.OrderByDescending(Function(PP) PP.Code)
                                 Select New AdvantageFramework.DTO.ComboBoxItem With {.Display = PostPeriod.Code & " - " & PostPeriod.Description,
                                                                                      .Value = PostPeriod.Code}).ToList

            Else

                ComboBoxItems = New Generic.List(Of DTO.ComboBoxItem)

            End If

            LoadPostPeriods = ComboBoxItems

        End Function
        Public Function LoadTotalNumberOfPosted(ByRef RecurringJournalEntryViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.RecurringJournalEntryViewModel) As Integer

            'objects
            Dim TotalNumberOfPosted As Integer = 0
            Dim ControlNumber As Integer = 0

            If RecurringJournalEntryViewModel.RecurringJournalEntry IsNot Nothing Then

                ControlNumber = RecurringJournalEntryViewModel.RecurringJournalEntry.ControlNumber

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    TotalNumberOfPosted = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.GLRJELOG WHERE GLRLCNTRL = {0}", ControlNumber)).First

                End Using

            End If

            LoadTotalNumberOfPosted = TotalNumberOfPosted

        End Function
        Public Function GetInactiveCycle(CycleCode As String) As AdvantageFramework.Database.Entities.Cycle

            'objects
            Dim Cycle As AdvantageFramework.Database.Entities.Cycle = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Cycle = AdvantageFramework.Database.Procedures.Cycle.LoadByCode(DbContext, CycleCode)

            End Using

            GetInactiveCycle = Cycle

        End Function
        Public Sub DescriptionChanged(ByRef RecurringJournalEntryViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.RecurringJournalEntryViewModel,
                                      Description As String)

            For Each RecurringJournalEntryDetail In RecurringJournalEntryViewModel.RecurringJournalEntryDetails

                If RecurringJournalEntryDetail.RemarkIsTheSameAsHeaderDescription Then

                    RecurringJournalEntryDetail.Remark = Description

                End If

            Next

            For Each RecurringJournalEntryDetail In RecurringJournalEntryViewModel.RecurringJournalEntryDetails

                If RecurringJournalEntryDetail.RemarkIsTheSameAsHeaderDescription = False Then

                    If RecurringJournalEntryDetail.Remark = Description Then

                        RecurringJournalEntryDetail.RemarkIsTheSameAsHeaderDescription = True

                    End If

                End If

            Next

        End Sub
        Public Sub RemarkChanged(ByRef RecurringJournalEntryViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.RecurringJournalEntryViewModel,
                                 Description As String, Remark As String,
                                 ByRef RecurringJournalEntryDetail As AdvantageFramework.DTO.GeneralLedger.JournalEntry.RecurringJournalEntryDetail)

            If RecurringJournalEntryViewModel.AddEnabled = False Then

                If RecurringJournalEntryDetail IsNot Nothing Then

                    If Description = Remark Then

                        RecurringJournalEntryDetail.RemarkIsTheSameAsHeaderDescription = True

                    Else

                        RecurringJournalEntryDetail.RemarkIsTheSameAsHeaderDescription = False

                    End If

                End If

            End If

        End Sub

#End Region

    End Class

End Namespace
