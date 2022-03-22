Namespace Controller.GeneralLedger.JournalEntriesBudgets

    Public Class JournalEntryController
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

        Public Function Load(Transaction As Integer) As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.JournalEntryViewModel

            Dim JournalEntryViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.JournalEntryViewModel = Nothing
            Dim GeneralLedger As AdvantageFramework.Database.Entities.GeneralLedger = Nothing
            Dim PostPeriods As Generic.List(Of AdvantageFramework.Database.Entities.PostPeriod) = Nothing
            Dim PostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                JournalEntryViewModel = New AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.JournalEntryViewModel()

                PostPeriods = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllActiveNonYearEndPostPeriods(DbContext).ToList

                PostPeriods = PostPeriods.OrderByDescending(Function(Entity) Entity.StartDate).ToList

                Try

                    PostPeriod = PostPeriods.FirstOrDefault(Function(Entity) Entity.GLStatus = "C")

                Catch ex As Exception
                    PostPeriod = Nothing
                End Try

                If PostPeriod IsNot Nothing Then

                    JournalEntryViewModel.CurrentPostPeriod = New AdvantageFramework.DTO.GeneralLedger.PostPeriod(PostPeriod)

                Else

                    Try

                        PostPeriod = PostPeriods.FirstOrDefault(Function(Entity) Entity.GLStatus <> "C")

                    Catch ex As Exception
                        PostPeriod = Nothing
                    End Try

                    If PostPeriod IsNot Nothing Then

                        JournalEntryViewModel.CurrentPostPeriod = New AdvantageFramework.DTO.GeneralLedger.PostPeriod(PostPeriod)

                    Else

                        JournalEntryViewModel.CurrentPostPeriod = New AdvantageFramework.DTO.GeneralLedger.PostPeriod()

                    End If

                End If

                If Transaction > 0 Then

                    GeneralLedger = DbContext.GeneralLedgers.Find(Transaction)

                    DbContext.Entry(GeneralLedger).Collection("GeneralLedgerDocuments").Load()

                    JournalEntryViewModel.JournalEntry = New DTO.GeneralLedger.JournalEntry.JournalEntry(GeneralLedger)

                    JournalEntryViewModel.JournalEntryDetails.AddRange(From GLD In AdvantageFramework.Database.Procedures.GeneralLedgerDetail.LoadByTransaction(DbContext, Transaction).Include("GeneralLedgerAccount").ToList
                                                                       Select New AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntryDetail(GLD))

                    JournalEntryViewModel.JournalEntryDetails = JournalEntryViewModel.JournalEntryDetails.OrderBy(Function(Entity) Entity.SequenceNumber).ToList

                    JournalEntryViewModel.CopyEnabled = (JournalEntryViewModel.JournalEntry.IsVoided = False)

                    If (JournalEntryViewModel.JournalEntry.GLSourceCode = "JE" OrElse JournalEntryViewModel.JournalEntry.GLSourceCode = "IJ" OrElse
                        JournalEntryViewModel.JournalEntry.GLSourceCode = "FA" OrElse JournalEntryViewModel.JournalEntry.GLSourceCode = "PR" OrElse
                        JournalEntryViewModel.JournalEntry.GLSourceCode = "RJ") AndAlso
                            JournalEntryViewModel.JournalEntry.IsVoided = False AndAlso
                            JournalEntryViewModel.JournalEntry.PostedDate.HasValue = False Then

                        JournalEntryViewModel.AllowEdit = True
                        JournalEntryViewModel.AddEnabled = False
                        JournalEntryViewModel.UpdateEnabled = True
                        JournalEntryViewModel.VoidEnabled = True
                        'JournalEntryViewModel.DeleteEnabled = True

                    Else

                        JournalEntryViewModel.AllowEdit = False
                        JournalEntryViewModel.AddEnabled = False
                        JournalEntryViewModel.UpdateEnabled = False
                        JournalEntryViewModel.VoidEnabled = False
                        'JournalEntryViewModel.DeleteEnabled = False

                    End If

                    If JournalEntryViewModel.AllowEdit = False AndAlso
                            JournalEntryViewModel.JournalEntry.IsVoided = False AndAlso
                            JournalEntryViewModel.JournalEntry.GLSourceCode = "JE" Then

                        JournalEntryViewModel.AllowEnteredDateEditIfPostedToSummary = True

                    End If

                    If JournalEntryViewModel.AllowEdit = False AndAlso
                            JournalEntryViewModel.JournalEntry.IsVoided = False AndAlso
                            (JournalEntryViewModel.JournalEntry.GLSourceCode = "JE" OrElse JournalEntryViewModel.JournalEntry.GLSourceCode = "IJ" OrElse
                             JournalEntryViewModel.JournalEntry.GLSourceCode = "FA" OrElse JournalEntryViewModel.JournalEntry.GLSourceCode = "PR") Then

                        JournalEntryViewModel.AllowDescriptionEditIfPostedToSummary = True

                    End If

                    If JournalEntryViewModel.JournalEntryDetails IsNot Nothing AndAlso JournalEntryViewModel.JournalEntryDetails.Count > 0 Then

                        For Each JournalEntryDetail In JournalEntryViewModel.JournalEntryDetails

                            If JournalEntryDetail.Remark = JournalEntryViewModel.JournalEntry.Description Then

                                JournalEntryDetail.RemarkIsTheSameAsHeaderDescription = True

                            End If

                        Next

                    End If

                    JournalEntryViewModel.Documents_ViewEnabled = True
                    JournalEntryViewModel.Documents_UploadEnabled = True

                    If JournalEntryViewModel.JournalEntryDetails Is Nothing OrElse
                            (JournalEntryViewModel.JournalEntryDetails IsNot Nothing AndAlso JournalEntryViewModel.JournalEntryDetails.Count = 0) Then

                        SelectedDetailChanged(JournalEntryViewModel, False, Nothing)

                    End If

                ElseIf Transaction = 0 Then

                    JournalEntryViewModel.AllowEdit = True

                    JournalEntryViewModel.JournalEntry = New DTO.GeneralLedger.JournalEntry.JournalEntry()

                    'JournalEntryViewModel.JournalEntry.Transaction = DbContext.GeneralLedgers.Select(Function(Entity) Entity.Transaction).Max + 1
                    JournalEntryViewModel.JournalEntry.PostPeriodCode = JournalEntryViewModel.CurrentPostPeriod.Code
                    JournalEntryViewModel.JournalEntry.GLSourceCode = "JE"
                    JournalEntryViewModel.JournalEntry.ReverseFlag = False
                    JournalEntryViewModel.JournalEntry.UserCode = Session.UserCode
                    JournalEntryViewModel.JournalEntry.EnteredDate = Now
                    JournalEntryViewModel.JournalEntry.CreateDate = Now

                    JournalEntryViewModel.JournalEntryDetails = New Generic.List(Of AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntryDetail)

                    JournalEntryViewModel.AllowEdit = True
                    JournalEntryViewModel.AddEnabled = True
                    JournalEntryViewModel.UpdateEnabled = False
                    JournalEntryViewModel.VoidEnabled = False
                    JournalEntryViewModel.CopyEnabled = False
                    'JournalEntryViewModel.DeleteEnabled = False
                    JournalEntryViewModel.Documents_ViewEnabled = False
                    JournalEntryViewModel.Documents_UploadEnabled = False

                Else

                    JournalEntryViewModel.JournalEntry = New DTO.GeneralLedger.JournalEntry.JournalEntry()

                    JournalEntryViewModel.JournalEntryDetails = New Generic.List(Of AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntryDetail)

                    JournalEntryViewModel.AllowEdit = False
                    JournalEntryViewModel.AddEnabled = False
                    JournalEntryViewModel.UpdateEnabled = False
                    JournalEntryViewModel.VoidEnabled = False
                    JournalEntryViewModel.CopyEnabled = False
                    'JournalEntryViewModel.DeleteEnabled = False
                    JournalEntryViewModel.Documents_ViewEnabled = False
                    JournalEntryViewModel.Documents_UploadEnabled = False

                End If

                JournalEntryViewModel.RepositoryClients = AdvantageFramework.Database.Procedures.Client.LoadAllActive(DbContext).ToList.Select(Function(Entity) New AdvantageFramework.DTO.GeneralLedger.JournalEntry.Client(Entity)).ToList
                JournalEntryViewModel.RepositoryGeneralLedgerAccounts = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadWithOfficeLimits(DbContext, Session).ToList.Where(Function(GeneralLedgerAccount) GeneralLedgerAccount.Active = "A").Select(Function(Entity) New AdvantageFramework.DTO.GeneralLedger.JournalEntry.GeneralLedgerAccount(Entity)).ToList

                If JournalEntryViewModel.RepositoryGeneralLedgerAccounts Is Nothing OrElse JournalEntryViewModel.RepositoryGeneralLedgerAccounts.Count = 0 Then

                    JournalEntryViewModel.RepositoryGeneralLedgerAccounts = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadAllActive(DbContext).Include("GeneralLedgerOfficeCrossReference").Include("GeneralLedgerOfficeCrossReference.Office").ToList.
                                                                                                                    Select(Function(Entity) New AdvantageFramework.DTO.GeneralLedger.JournalEntry.GeneralLedgerAccount(Entity)).ToList

                End If

                JournalEntryViewModel.Offices = AdvantageFramework.Database.Procedures.Office.LoadAllActiveWithOfficeLimits(DbContext, Me.Session).ToList.Select(Function(Entity) New AdvantageFramework.DTO.ComboBoxItem(Entity)).ToList

            End Using

            Load = JournalEntryViewModel

        End Function
        Public Function Add(ByRef JournalEntryViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.JournalEntryViewModel,
                            ByRef ErrorMessage As String) As Boolean

            Dim Added As Boolean = False
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim GeneralLedger As AdvantageFramework.Database.Entities.GeneralLedger = Nothing
            Dim GeneralLedgerDetail As AdvantageFramework.Database.Entities.GeneralLedgerDetail = Nothing
            Dim Transaction As Integer = 0

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                DbContext.Database.Connection.Open()
                DbContext.Configuration.AutoDetectChangesEnabled = False

                Try

                    DbTransaction = DbContext.Database.BeginTransaction

                    GeneralLedger = New AdvantageFramework.Database.Entities.GeneralLedger

                    JournalEntryViewModel.JournalEntry.SaveToEntity(GeneralLedger)

                    Transaction = DbContext.Database.SqlQuery(Of Integer)("SELECT IDSXACT FROM dbo.IDS WHERE IDSTABLE = 'GLENTHDR'").FirstOrDefault + 1

                    GeneralLedger.Transaction = Transaction
                    JournalEntryViewModel.JournalEntry.Transaction = GeneralLedger.Transaction

                    DbContext.GeneralLedgers.Add(GeneralLedger)

                    For Each JournalEntryDetail In JournalEntryViewModel.JournalEntryDetails

                        GeneralLedgerDetail = New AdvantageFramework.Database.Entities.GeneralLedgerDetail

                        If String.IsNullOrWhiteSpace(JournalEntryDetail.Remark) Then

                            JournalEntryDetail.Remark = JournalEntryViewModel.JournalEntry.Description

                        End If

                        JournalEntryDetail.SaveToEntity(GeneralLedgerDetail)

                        JournalEntryDetail.GLTransaction = GeneralLedger.Transaction
                        JournalEntryDetail.SequenceNumber = JournalEntryViewModel.JournalEntryDetails.IndexOf(JournalEntryDetail) + 1

                        GeneralLedgerDetail.GLTransaction = JournalEntryDetail.GLTransaction
                        GeneralLedgerDetail.SequenceNumber = JournalEntryDetail.SequenceNumber
                        GeneralLedgerDetail.GLSourceCode = JournalEntryViewModel.JournalEntry.GLSourceCode

                        DbContext.GeneralLedgerDetails.Add(GeneralLedgerDetail)

                    Next

                    DbContext.Configuration.AutoDetectChangesEnabled = True
                    DbContext.SaveChanges()

                    DbContext.Database.ExecuteSqlCommand("UPDATE dbo.IDS SET IDSXACT = " & Transaction & " WHERE IDSTABLE = 'GLENTHDR'")

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
        Public Function Save(ByRef JournalEntryViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.JournalEntryViewModel,
                             ByRef ErrorMessage As String) As Boolean

            Dim Saved As Boolean = False
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim GeneralLedger As AdvantageFramework.Database.Entities.GeneralLedger = Nothing
            Dim GeneralLedgerDetail As AdvantageFramework.Database.Entities.GeneralLedgerDetail = Nothing
            Dim GeneralLedgerDetails As Generic.List(Of AdvantageFramework.Database.Entities.GeneralLedgerDetail) = Nothing
            Dim NextSequenceNumber As Integer = 1
            Dim SequenceNumbers As Generic.List(Of Integer) = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                DbContext.Database.Connection.Open()
                DbContext.Configuration.AutoDetectChangesEnabled = False

                Try

                    DbTransaction = DbContext.Database.BeginTransaction

                    JournalEntryViewModel.JournalEntry.ModifiedDate = Now

                    GeneralLedger = DbContext.GeneralLedgers.Find(JournalEntryViewModel.JournalEntry.Transaction)

                    GeneralLedgerDetails = DbContext.GeneralLedgerDetails.Where(Function(Entity) Entity.GLTransaction = GeneralLedger.Transaction).ToList

                    If GeneralLedgerDetails IsNot Nothing AndAlso GeneralLedgerDetails.Count > 0 Then

                        NextSequenceNumber = GeneralLedgerDetails.Select(Function(Entity) Entity.SequenceNumber).Max + 1

                    Else

                        NextSequenceNumber = 1

                    End If

                    JournalEntryViewModel.JournalEntry.SaveToEntity(GeneralLedger)

                    SequenceNumbers = New Generic.List(Of Integer)

                    For Each JournalEntryDetail In JournalEntryViewModel.JournalEntryDetails

                        If JournalEntryDetail.GLTransaction = 0 AndAlso JournalEntryDetail.SequenceNumber.GetValueOrDefault(0) = 0 Then

                            GeneralLedgerDetail = New AdvantageFramework.Database.Entities.GeneralLedgerDetail

                            JournalEntryDetail.GLTransaction = GeneralLedger.Transaction
                            JournalEntryDetail.SequenceNumber = NextSequenceNumber

                            NextSequenceNumber += 1

                            GeneralLedgerDetail.GLTransaction = JournalEntryDetail.GLTransaction
                            GeneralLedgerDetail.SequenceNumber = JournalEntryDetail.SequenceNumber
                            GeneralLedgerDetail.GLSourceCode = JournalEntryViewModel.JournalEntry.GLSourceCode

                            DbContext.GeneralLedgerDetails.Add(GeneralLedgerDetail)

                        ElseIf JournalEntryDetail.GLTransaction > 0 AndAlso JournalEntryDetail.SequenceNumber.GetValueOrDefault(0) > 0 Then

                            Try

                                GeneralLedgerDetail = GeneralLedgerDetails.FirstOrDefault(Function(Entity) Entity.GLTransaction = JournalEntryDetail.GLTransaction AndAlso Entity.SequenceNumber = JournalEntryDetail.SequenceNumber)

                            Catch ex As Exception
                                GeneralLedgerDetail = Nothing
                            End Try

                            If GeneralLedgerDetail Is Nothing Then

                                Throw New Exception("Failed to find journal entry detail.")

                            End If

                        End If

                        JournalEntryDetail.SaveToEntity(GeneralLedgerDetail)

                        SequenceNumbers.Add(GeneralLedgerDetail.SequenceNumber)

                    Next

                    For Each GeneralLedgerDetail In GeneralLedgerDetails.ToList.Where(Function(Entity) SequenceNumbers.Contains(Entity.SequenceNumber) = False)

                        DbContext.GeneralLedgerDetails.Remove(GeneralLedgerDetail)

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
        Public Function Void(ByRef JournalEntryViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.JournalEntryViewModel,
                             ByRef ErrorMessage As String) As Boolean

            Dim Voided As Boolean = False
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim GeneralLedger As AdvantageFramework.Database.Entities.GeneralLedger = Nothing
            Dim GeneralLedgerDetail As AdvantageFramework.Database.Entities.GeneralLedgerDetail = Nothing
            Dim GeneralLedgerDetails As Generic.List(Of AdvantageFramework.Database.Entities.GeneralLedgerDetail) = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                DbContext.Database.Connection.Open()
                DbContext.Configuration.AutoDetectChangesEnabled = False

                Try

                    DbTransaction = DbContext.Database.BeginTransaction

                    GeneralLedger = DbContext.GeneralLedgers.Find(JournalEntryViewModel.JournalEntry.Transaction)

                    GeneralLedger.PostPeriodCode = Nothing
                    GeneralLedger.IsVoided = 1

                    GeneralLedgerDetails = DbContext.GeneralLedgerDetails.Where(Function(Entity) Entity.GLTransaction = GeneralLedger.Transaction).ToList

                    For Each GeneralLedgerDetail In GeneralLedgerDetails

                        DbContext.GeneralLedgerDetails.Remove(GeneralLedgerDetail)

                    Next

                    DbContext.Configuration.AutoDetectChangesEnabled = True
                    DbContext.SaveChanges()

                    DbTransaction.Commit()

                    Voided = True

                Catch ex As Exception
                    DbTransaction.Rollback()
                    ErrorMessage = "Failed trying to save data to the database. Please contact software support."
                    ErrorMessage += System.Environment.NewLine & ex.Message
                    Voided = False
                End Try

            End Using

            Void = Voided

        End Function
        Public Function Copy(ByRef JournalEntryViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.JournalEntryViewModel,
                             ByRef Transaction As Integer,
                             ByRef ErrorMessage As String) As Boolean

            Dim Copied As Boolean = False
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim GeneralLedger As AdvantageFramework.Database.Entities.GeneralLedger = Nothing
            Dim GeneralLedgerDetail As AdvantageFramework.Database.Entities.GeneralLedgerDetail = Nothing
            'Dim Transaction As Integer = 0

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                DbContext.Database.Connection.Open()
                DbContext.Configuration.AutoDetectChangesEnabled = False

                Try

                    DbTransaction = DbContext.Database.BeginTransaction

                    Transaction = DbContext.Database.SqlQuery(Of Integer)("SELECT IDSXACT FROM dbo.IDS WHERE IDSTABLE = 'GLENTHDR'").FirstOrDefault + 1

                    GeneralLedger = New AdvantageFramework.Database.Entities.GeneralLedger

                    GeneralLedger.Transaction = Transaction
                    GeneralLedger.PostPeriodCode = JournalEntryViewModel.CurrentPostPeriod.Code
                    GeneralLedger.Description = JournalEntryViewModel.JournalEntry.Description

                    GeneralLedger.ReverseFlag = If(JournalEntryViewModel.JournalEntry.ReverseFlag, "1", Nothing)

                    GeneralLedger.GLSourceCode = "JE"
                    GeneralLedger.EnteredDate = Now
                    GeneralLedger.ModifiedDate = Now
                    GeneralLedger.CreateDate = Now
                    GeneralLedger.UserCode = Me.Session.UserCode

                    DbContext.GeneralLedgers.Add(GeneralLedger)

                    For Each JournalEntryDetail In JournalEntryViewModel.JournalEntryDetails

                        GeneralLedgerDetail = New AdvantageFramework.Database.Entities.GeneralLedgerDetail

                        GeneralLedgerDetail.GLTransaction = Transaction
                        GeneralLedgerDetail.SequenceNumber = JournalEntryDetail.SequenceNumber
                        GeneralLedgerDetail.GLSourceCode = "JE"

                        JournalEntryDetail.SaveToEntity(GeneralLedgerDetail)

                        DbContext.GeneralLedgerDetails.Add(GeneralLedgerDetail)

                    Next

                    DbContext.Configuration.AutoDetectChangesEnabled = True
                    DbContext.SaveChanges()

                    DbContext.Database.ExecuteSqlCommand("UPDATE dbo.IDS SET IDSXACT = " & Transaction & " WHERE IDSTABLE = 'GLENTHDR'")

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
        Public Function Details_CopyFrom(ByRef JournalEntryViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.JournalEntryViewModel,
                                         Transaction As Integer,
                                         ByRef ErrorMessage As String) As Boolean

            Dim Copied As Boolean = False
            Dim JournalEntryDetail As AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntryDetail = Nothing
            Dim GeneralLedgerDetail As AdvantageFramework.Database.Entities.GeneralLedgerDetail = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                DbContext.Database.Connection.Open()

                Try

                    For Each GeneralLedgerDetail In AdvantageFramework.Database.Procedures.GeneralLedgerDetail.LoadByTransaction(DbContext, Transaction).Include("GeneralLedgerAccount").ToList

                        JournalEntryDetail = New AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntryDetail(GeneralLedgerDetail)

                        JournalEntryDetail.GLTransaction = 0
                        JournalEntryDetail.SequenceNumber = Nothing

                        JournalEntryViewModel.JournalEntryDetails.Add(JournalEntryDetail)

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
        Public Function ValidateEntity(DTO As AdvantageFramework.DTO.BaseClass, ByRef IsValid As Boolean) As String

            'objects
            Dim ErrorText As String = String.Empty

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ErrorText = ValidateDTO(DbContext, DataContext, DTO, IsValid)

                End Using

            End Using

            ValidateEntity = ErrorText

        End Function
        Public Function Validate(ByRef JournalEntryViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.JournalEntryViewModel,
                                 ByRef ErrorMessage As String, ByRef RefreshOnAlreadyPostedError As Boolean) As Boolean

            'objects
            Dim IsPosted As Boolean = False
            Dim CDPRequiredCheckPassed As Boolean = True
            Dim OutOfBalanceJournalEntryPassed As Boolean = False
            Dim Credits As Decimal = 0
            Dim Debits As Decimal = 0
            Dim Validated As Boolean = False

            If JournalEntryViewModel.JournalEntry IsNot Nothing AndAlso JournalEntryViewModel.JournalEntry.Transaction > 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Try

                        IsPosted = DbContext.Database.SqlQuery(Of Boolean)(String.Format("SELECT CAST(CASE WHEN GLEHPOSTSUM IS NULL THEN 0 ELSE 1 END AS bit) FROM dbo.GLENTHDR WHERE GLEHXACT = {0}", JournalEntryViewModel.JournalEntry.Transaction)).FirstOrDefault

                    Catch ex As Exception
                        IsPosted = False
                    End Try

                End Using

            End If

            If IsPosted = False Then

                If JournalEntryViewModel.JournalEntryDetails IsNot Nothing AndAlso JournalEntryViewModel.JournalEntryDetails.Count > 0 Then

                    For Each JournalEntryDetail In JournalEntryViewModel.JournalEntryDetails

                        If JournalEntryDetail.CDPRequired Then

                            If String.IsNullOrWhiteSpace(JournalEntryDetail.ClientCode) OrElse
                                    String.IsNullOrWhiteSpace(JournalEntryDetail.DivisionCode) OrElse
                                    String.IsNullOrWhiteSpace(JournalEntryDetail.ProductCode) Then

                                CDPRequiredCheckPassed = False
                                ErrorMessage = "CDP required for journal entry detail."
                                Exit For

                            End If

                        End If

                    Next

                    Try

                        Credits = JournalEntryViewModel.JournalEntryDetails.Select(Function(Entity) Entity.CreditAmount.GetValueOrDefault(0)).Sum

                    Catch ex As Exception
                        Credits = 0
                    End Try

                    Try

                        Debits = JournalEntryViewModel.JournalEntryDetails.Select(Function(Entity) Entity.DebitAmount.GetValueOrDefault(0)).Sum

                    Catch ex As Exception
                        Debits = 0
                    End Try

                    If Math.Abs(Debits) = Math.Abs(Credits) Then

                        OutOfBalanceJournalEntryPassed = True

                    Else

                        If String.IsNullOrWhiteSpace(ErrorMessage) Then

                            ErrorMessage = "Out of balance journal entry."

                        Else

                            ErrorMessage &= System.Environment.NewLine & "Out of balance journal entry."

                        End If

                    End If

                    If CDPRequiredCheckPassed AndAlso OutOfBalanceJournalEntryPassed Then

                        Validated = True

                    End If

                Else

                    ErrorMessage = "Journal Entry must have details."

                End If

            Else

                RefreshOnAlreadyPostedError = True
                ErrorMessage = "This record has been updated to summary, changes not allowed."

            End If

            Validate = Validated

        End Function
        Public Function GetInactivePostPeriod(PostPeriodCode As String) As AdvantageFramework.Database.Entities.PostPeriod

            'objects
            Dim PostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                PostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadByPostPeriodCode(DbContext, PostPeriodCode)

            End Using

            GetInactivePostPeriod = PostPeriod

        End Function
        Public Sub GetRepositoryGLDetails(ByRef JournalEntryViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.JournalEntryViewModel, GLACode As String,
                                          ByRef JournalEntryDetail As AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntryDetail)

            'objects
            Dim GeneralLedgerAccount As AdvantageFramework.DTO.GeneralLedger.JournalEntry.GeneralLedgerAccount = Nothing

            If JournalEntryViewModel.RepositoryGeneralLedgerAccounts IsNot Nothing Then

                Try

                    GeneralLedgerAccount = JournalEntryViewModel.RepositoryGeneralLedgerAccounts.Where(Function(Entity) Entity.Code = GLACode).FirstOrDefault

                Catch ex As Exception
                    GeneralLedgerAccount = Nothing
                End Try

                If GeneralLedgerAccount IsNot Nothing Then

                    JournalEntryDetail.GLAccountDescription = GeneralLedgerAccount.Description
                    JournalEntryDetail.CDPRequired = GeneralLedgerAccount.CDPRequired

                End If

            End If

        End Sub
        Public Sub JournalEntryDetailClientCodeChanged(ByRef JournalEntryViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.JournalEntryViewModel,
                                                       ClientCode As String, ByRef JournalEntryDetail As AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntryDetail)

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

                    JournalEntryDetail.DivisionCode = DivisionViews.FirstOrDefault.DivisionCode

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                            ProductViews = AdvantageFramework.Database.Procedures.ProductView.LoadByClientAndDivisionCode(DbContext, ClientCode, JournalEntryDetail.DivisionCode).ToList

                        End Using

                    Catch ex As Exception

                    End Try

                    If ProductViews IsNot Nothing AndAlso ProductViews.Count = 1 Then

                        JournalEntryDetail.ProductCode = ProductViews.FirstOrDefault.ProductCode

                    End If

                End If

            Else

                JournalEntryDetail.DivisionCode = Nothing
                JournalEntryDetail.ProductCode = Nothing

            End If

        End Sub
        Public Sub JournalEntryDetailDivisionCodeChanged(ByRef JournalEntryViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.JournalEntryViewModel,
                                                         DivisionCode As String, ByRef JournalEntryDetail As AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntryDetail)

            'objects
            Dim ProductViews As Generic.List(Of AdvantageFramework.Database.Views.ProductView) = Nothing

            If String.IsNullOrWhiteSpace(DivisionCode) = False Then

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        ProductViews = AdvantageFramework.Database.Procedures.ProductView.LoadByClientAndDivisionCode(DbContext, JournalEntryDetail.ClientCode, DivisionCode).ToList

                    End Using

                Catch ex As Exception

                End Try

                If ProductViews IsNot Nothing AndAlso ProductViews.Count = 1 Then

                    JournalEntryDetail.ProductCode = ProductViews.FirstOrDefault.ProductCode

                End If

            Else

                JournalEntryDetail.ProductCode = Nothing

            End If

        End Sub
        Public Sub LoadRepositoryDivisions(ByRef JournalEntryViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.JournalEntryViewModel,
                                           ClientCode As String)

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                JournalEntryViewModel.RepositoryDivisions = AdvantageFramework.Database.Procedures.DivisionView.LoadByClientCode(DbContext, ClientCode).ToList.Select(Function(Entity) New AdvantageFramework.DTO.GeneralLedger.JournalEntry.Division(Entity)).ToList

            End Using

        End Sub
        Public Sub LoadRepositoryProducts(ByRef JournalEntryViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.JournalEntryViewModel,
                                          ClientCode As String, DivisionCode As String)

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                JournalEntryViewModel.RepositoryProducts = AdvantageFramework.Database.Procedures.ProductView.LoadByClientAndDivisionCode(DbContext, ClientCode, DivisionCode).ToList.Select(Function(Entity) New AdvantageFramework.DTO.GeneralLedger.JournalEntry.Product(Entity)).ToList

            End Using

        End Sub
        Public Function LoadGLPostPeriods() As Generic.List(Of AdvantageFramework.DTO.GeneralLedger.JournalEntry.PostPeriod)

            'objects
            Dim PostPeriods As Generic.List(Of AdvantageFramework.DTO.GeneralLedger.JournalEntry.PostPeriod) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                PostPeriods = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllActiveGLPostPeriods(DbContext).ToList.Select(Function(Entity) New AdvantageFramework.DTO.GeneralLedger.JournalEntry.PostPeriod(Entity)).OrderByDescending(Function(Entity) Entity.Code).ToList

            End Using

            LoadGLPostPeriods = PostPeriods

        End Function
        Public Sub SelectedDetailChanged(ByRef JournalEntryViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.JournalEntryViewModel,
                                         IsNewItemRow As Boolean,
                                         JournalEntryDetails As Generic.List(Of AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntryDetail))

            JournalEntryViewModel.SelectedJournalEntryDetails = JournalEntryDetails

            JournalEntryViewModel.Details_IsNewRow = IsNewItemRow
            JournalEntryViewModel.Details_CancelEnabled = IsNewItemRow
            JournalEntryViewModel.Details_DeleteEnabled = (Not IsNewItemRow AndAlso JournalEntryViewModel.HasASelectedJournalEntryDetail AndAlso JournalEntryViewModel.AllowEdit)
            JournalEntryViewModel.Details_CopyFromEnabled = (Not IsNewItemRow AndAlso JournalEntryViewModel.AllowEdit)
            JournalEntryViewModel.Details_ReverseDebitCreditsEnabled = (Not IsNewItemRow AndAlso JournalEntryViewModel.AllowEdit)

        End Sub
        Public Sub Details_InitNewRowEvent(ByRef JournalEntryViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.JournalEntryViewModel)

            JournalEntryViewModel.Details_IsNewRow = True
            JournalEntryViewModel.Details_CancelEnabled = True
            JournalEntryViewModel.Details_DeleteEnabled = False
            JournalEntryViewModel.Details_CopyFromEnabled = False
            JournalEntryViewModel.Details_ReverseDebitCreditsEnabled = False

        End Sub
        Public Sub Details_CancelNewItemRow(ByRef JournalEntryViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.JournalEntryViewModel)

            JournalEntryViewModel.Details_IsNewRow = False
            JournalEntryViewModel.Details_CancelEnabled = False
            JournalEntryViewModel.Details_DeleteEnabled = (JournalEntryViewModel.HasASelectedJournalEntryDetail AndAlso JournalEntryViewModel.AllowEdit)
            JournalEntryViewModel.Details_CopyFromEnabled = JournalEntryViewModel.AllowEdit
            JournalEntryViewModel.Details_ReverseDebitCreditsEnabled = JournalEntryViewModel.AllowEdit

        End Sub
        Public Sub Details_Delete(ByRef JournalEntryViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.JournalEntryViewModel)

            If JournalEntryViewModel.HasASelectedJournalEntryDetail Then

                For Each JournalEntryDetail In JournalEntryViewModel.SelectedJournalEntryDetails

                    JournalEntryViewModel.JournalEntryDetails.Remove(JournalEntryDetail)

                Next

            End If

        End Sub
        Public Sub ReverseDebitCredit(ByRef JournalEntryViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.JournalEntryViewModel)

            For Each JournalEntryDetail In JournalEntryViewModel.JournalEntryDetails

                If JournalEntryDetail.CreditAmount.HasValue Then

                    JournalEntryDetail.DebitAmount = Math.Abs(JournalEntryDetail.CreditAmount.Value)
                    JournalEntryDetail.CreditAmount = Nothing

                ElseIf JournalEntryDetail.DebitAmount.HasValue Then

                    JournalEntryDetail.CreditAmount = -Math.Abs(JournalEntryDetail.DebitAmount.Value)
                    JournalEntryDetail.DebitAmount = Nothing

                End If

            Next

        End Sub
        Public Function LoadGeneralLedgerAccounts(ByRef JournalEntryViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.JournalEntryViewModel) As Generic.List(Of AdvantageFramework.DTO.GeneralLedger.JournalEntry.GeneralLedgerAccount)

            'objects
            Dim GeneralLedgerAccounts As Generic.List(Of AdvantageFramework.DTO.GeneralLedger.JournalEntry.GeneralLedgerAccount) = Nothing
            Dim SelectedOfficeCode As String = String.Empty

            'Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

            '    GeneralLedgerAccounts = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadAllActive(DbContext).Include("GeneralLedgerOfficeCrossReference").Include("GeneralLedgerOfficeCrossReference.Office").ToList.
            '                                                                                        Select(Function(Entity) New AdvantageFramework.DTO.GeneralLedger.JournalEntry.GeneralLedgerAccount(Entity)).ToList

            'End Using

            SelectedOfficeCode = JournalEntryViewModel.SelectedOfficeCode

            If String.IsNullOrWhiteSpace(SelectedOfficeCode) = False Then

                GeneralLedgerAccounts = JournalEntryViewModel.RepositoryGeneralLedgerAccounts.Where(Function(Entity) Entity.OfficeCode = SelectedOfficeCode).ToList

            Else

                GeneralLedgerAccounts = JournalEntryViewModel.RepositoryGeneralLedgerAccounts.ToList

            End If

            LoadGeneralLedgerAccounts = GeneralLedgerAccounts

        End Function
        Public Sub SelectedOfficeChanged(ByRef JournalEntryViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.JournalEntryViewModel,
                                         OfficeCode As String)

            If String.IsNullOrWhiteSpace(OfficeCode) = False Then

                JournalEntryViewModel.SelectedOfficeCode = OfficeCode

            Else

                JournalEntryViewModel.SelectedOfficeCode = ""

            End If

        End Sub
        Public Sub DescriptionChanged(ByRef JournalEntryViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.JournalEntryViewModel,
                                      Description As String)

            For Each JournalEntryDetail In JournalEntryViewModel.JournalEntryDetails

                If JournalEntryDetail.RemarkIsTheSameAsHeaderDescription Then

                    JournalEntryDetail.Remark = Description

                End If

            Next

            For Each JournalEntryDetail In JournalEntryViewModel.JournalEntryDetails

                If JournalEntryDetail.RemarkIsTheSameAsHeaderDescription = False Then

                    If JournalEntryDetail.Remark = Description Then

                        JournalEntryDetail.RemarkIsTheSameAsHeaderDescription = True

                    End If

                End If

            Next

        End Sub
        Public Sub RemarkChanged(ByRef JournalEntryViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.JournalEntryViewModel,
                                 Description As String, Remark As String,
                                 ByRef JournalEntryDetail As AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntryDetail)

            If JournalEntryViewModel.AddEnabled = False Then

                If JournalEntryDetail IsNot Nothing Then

                    If Description = Remark Then

                        JournalEntryDetail.RemarkIsTheSameAsHeaderDescription = True

                    Else

                        JournalEntryDetail.RemarkIsTheSameAsHeaderDescription = False

                    End If

                End If

            End If

        End Sub

#End Region

    End Class

End Namespace
