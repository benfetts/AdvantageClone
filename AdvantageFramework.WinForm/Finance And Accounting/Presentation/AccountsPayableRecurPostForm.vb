Namespace FinanceAndAccounting.Presentation

    Public Class AccountsPayableRecurPostForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _BatchDate As Date = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub LoadGrid()

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DataGridViewForm_APRecur.DataSource = DbContext.Database.SqlQuery(Of AdvantageFramework.AccountPayable.Classes.AccountPayableInvoiceFromRecur)(String.Format("exec advsp_ap_create_invoice_from_recur '{0}', '{1}'", ComboBoxForm_PostingPeriod.SelectedValue, ComboBoxControl_Cycle.SelectedValue)).ToList

            End Using

            DataGridViewForm_APRecur.CurrentView.BestFitColumns()

            EnableOrDisableActions()

        End Sub
        Private Function IsGridValid() As Boolean

            Dim AccountPayableInvoiceFromRecurList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableInvoiceFromRecur) = Nothing

            AccountPayableInvoiceFromRecurList = DataGridViewForm_APRecur.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.AccountPayable.Classes.AccountPayableInvoiceFromRecur)().ToList

            DataGridViewForm_APRecur.CurrentView.CloseEditorForUpdating()

            DataGridViewForm_APRecur.ValidateAllRows()

            IsGridValid = Not DataGridViewForm_APRecur.HasAnyInvalidRows

        End Function
        Private Sub EnableOrDisableActions()

            Dim AccountPayableInvoiceFromRecurList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableInvoiceFromRecur) = Nothing

            AccountPayableInvoiceFromRecurList = DataGridViewForm_APRecur.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.AccountPayable.Classes.AccountPayableInvoiceFromRecur)().ToList

            If AccountPayableInvoiceFromRecurList.Where(Function(Entity) Entity.CreateAP = 1).Count = 0 OrElse Not IsGridValid() Then

                ButtonItemActions_Post.Enabled = False

            Else

                ButtonItemActions_Post.Enabled = True

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim AccountsPayableRecurPostForm As AdvantageFramework.FinanceAndAccounting.Presentation.AccountsPayableRecurPostForm = Nothing

            AccountsPayableRecurPostForm = New AdvantageFramework.FinanceAndAccounting.Presentation.AccountsPayableRecurPostForm()

            AccountsPayableRecurPostForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub AccountsPayableRecurSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Dim PostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            _BatchDate = Now

            ButtonItemActions_Post.Image = AdvantageFramework.My.Resources.AccountsPayablePostRecurringImage
            ButtonItemActions_Print.Image = AdvantageFramework.My.Resources.PrintImage

            ComboBoxForm_PostingPeriod.SetRequired(True)
            ComboBoxControl_Cycle.SetRequired(True)
            DateTimePickerForm_InvoiceDate.SetRequired(True)
            DateTimePickerForm_InvoiceDate.ValueObject = Nothing

            ComboBoxForm_PostingPeriod.ByPassUserEntryChanged = True
            ComboBoxControl_Cycle.ByPassUserEntryChanged = True
            DateTimePickerForm_InvoiceDate.ByPassUserEntryChanged = True
            DataGridViewForm_APRecur.ByPassUserEntryChanged = True
            Me.ByPassUserEntryChanged = True

            Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ComboBoxForm_PostingPeriod.DataSource = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllActiveAPPostPeriods(DbContext).OrderByDescending(Function(Entity) Entity.Code).ToList

                PostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentAPPostPeriod(DbContext)

                If PostPeriod IsNot Nothing Then

                    ComboBoxForm_PostingPeriod.SelectedValue = PostPeriod.Code

                End If

                ComboBoxControl_Cycle.DataSource = AdvantageFramework.Database.Procedures.Cycle.LoadAllActive(DbContext)

            End Using

            LoadGrid()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ComboBoxForm_PostingPeriod_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxForm_PostingPeriod.SelectedValueChanged

            If Me.FormAction = WinForm.Presentation.FormActions.None AndAlso ComboBoxForm_PostingPeriod.HasASelectedValue Then

                LoadGrid()

            End If

        End Sub
        Private Sub ComboBoxControl_Cycle_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxControl_Cycle.SelectedValueChanged

            If Me.FormAction = WinForm.Presentation.FormActions.None AndAlso ComboBoxControl_Cycle.HasASelectedValue Then

                LoadGrid()

            End If

        End Sub
        Private Sub ButtonItemActions_Post_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Post.Click

            Dim AccountPayableInvoiceFromRecurringList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableInvoiceFromRecur) = Nothing
            Dim AccountPayable As AdvantageFramework.Database.Entities.AccountPayable = Nothing
            Dim ErrorMessage As String = Nothing
            Dim OkayToCreate As Boolean = True
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim AccountPayableRecur As AdvantageFramework.Database.Entities.AccountPayableRecur = Nothing
            Dim VendorTerm As AdvantageFramework.Database.Entities.VendorTerm = Nothing
            Dim GeneralLedger As AdvantageFramework.Database.Entities.GeneralLedger = Nothing
            Dim GeneralLedgerDetail As AdvantageFramework.Database.Entities.GeneralLedgerDetail = Nothing
            Dim Days As Double = 0
            Dim GLDescription As String = Nothing
            Dim CreditAmount As Double = Nothing
            Dim Remark As String = Nothing
            Dim AccountPayableRecurGeneralLedgerList As Generic.List(Of AdvantageFramework.Database.Entities.AccountPayableRecurGeneralLedger) = Nothing
            Dim TotalPosted As Integer = 0
            Dim SqlParameterRecurID As SqlClient.SqlParameter = Nothing
            Dim SqlParameterInvoiceDate As SqlClient.SqlParameter = Nothing
            Dim SqlParameterPostPeriod As SqlClient.SqlParameter = Nothing
            Dim SqlParameterUserID As SqlClient.SqlParameter = Nothing
            Dim GeneralLedgerAccount As AdvantageFramework.Database.Entities.GeneralLedgerAccount = Nothing
            Dim IsMultiCurrencyEnabled As Boolean = False
            Dim CurrencyCodeHome As String = Nothing
            Dim CurrencyDetail As AdvantageFramework.Database.Entities.CurrencyDetail = Nothing

            If IsGridValid() = False Then

                AdvantageFramework.WinForm.MessageBox.Show("Please correct issues in grid before proceeding.")

            ElseIf Me.Validator Then

                AccountPayableInvoiceFromRecurringList = DataGridViewForm_APRecur.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.AccountPayable.Classes.AccountPayableInvoiceFromRecur)().ToList

                Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If AccountPayableInvoiceFromRecurringList.Where(Function(Entity) Entity.CreateAP = 1 AndAlso Entity.APCreatedForPostPeriod = 1).Count > 0 Then

                        If AdvantageFramework.WinForm.MessageBox.Show("One or more recurring A/P invoices has already been posted for the posted period selected.  Do you want to continue?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.No Then

                            OkayToCreate = False

                        End If

                    End If

                    If OkayToCreate Then

                        Try

                            DbContext.Database.Connection.Open()

                            IsMultiCurrencyEnabled = AdvantageFramework.Database.Procedures.Agency.IsMultiCurrencyEnabled(DbContext)

                            DbTransaction = DbContext.Database.BeginTransaction

                            For Each AccountPayableInvoiceFromRecurring In AccountPayableInvoiceFromRecurringList.Where(Function(Recur) Recur.CreateAP = 1)

                                AccountPayableRecur = AdvantageFramework.Database.Procedures.AccountPayableRecur.LoadByID(DbContext, AccountPayableInvoiceFromRecurring.AccountPayableRecurID)

                                If AccountPayableRecur IsNot Nothing Then

                                    VendorTerm = AdvantageFramework.Database.Procedures.VendorTerm.LoadByVendorTermCode(DbContext, AccountPayableRecur.VendorTermCode)

                                    If VendorTerm IsNot Nothing Then

                                        Days = VendorTerm.DaysToPay

                                    End If

                                    AccountPayable = New AdvantageFramework.Database.Entities.AccountPayable
                                    AccountPayable.DbContext = DbContext
                                    AccountPayable.Type = "V"
                                    AccountPayable.VendorCode = AccountPayableRecur.VendorCode
                                    AccountPayable.InvoiceNumber = AccountPayableInvoiceFromRecurring.InvoiceNumber
                                    AccountPayable.InvoiceDescription = AccountPayableRecur.Description
                                    AccountPayable.InvoiceDate = DateTimePickerForm_InvoiceDate.Value
                                    AccountPayable.PaidDate = DateAdd(DateInterval.Day, Days, AccountPayable.InvoiceDate)
                                    'AccountPayable.InvoiceAmount = AccountPayableRecur.InvoiceAmount + AccountPayableRecur.ShippingAmount.GetValueOrDefault(0)
                                    'AccountPayable.ShippingAmount = 0
                                    'AccountPayable.SalesTaxAmount = AccountPayableRecur.SalesTaxAmount
                                    AccountPayable.DiscountPercentage = AccountPayableRecur.DiscountPercent.GetValueOrDefault(0)
                                    AccountPayable.GLACode = AccountPayableRecur.GLACode
                                    AccountPayable.PostPeriodCode = ComboBoxForm_PostingPeriod.SelectedValue
                                    AccountPayable.VendorTermCode = AccountPayableRecur.VendorTermCode
                                    AccountPayable.OfficeCode = AccountPayableRecur.OfficeCode
                                    AccountPayable.Is1099Invoice = AccountPayableRecur.Is1099Invoice
                                    AccountPayable.CreatedDate = Now
                                    AccountPayable.CreatedByUserCode = Me.Session.UserCode

                                    Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, AccountPayable.VendorCode)

                                    If IsMultiCurrencyEnabled Then

                                        CurrencyCodeHome = AdvantageFramework.Database.Procedures.Agency.GetHomeCurrency(DbContext)

                                        If Vendor.CurrencyCode <> CurrencyCodeHome Then

                                            CurrencyDetail = AdvantageFramework.Database.Procedures.CurrencyDetail.LoadLatestByCurrencyCodeAndCurrencyCodeComparison(DbContext, Vendor.CurrencyCode, CurrencyCodeHome)

                                            AccountPayable.InvoiceAmount = FormatNumber(AccountPayableRecur.InvoiceAmount * CurrencyDetail.ExchangeRate, 2)
                                            AccountPayable.ShippingAmount = 0
                                            AccountPayable.SalesTaxAmount = FormatNumber(AccountPayableRecur.SalesTaxAmount.GetValueOrDefault(0) * CurrencyDetail.ExchangeRate, 2)

                                            AccountPayable.CurrencyCode = Vendor.CurrencyCode
                                            AccountPayable.CurrencyRate = CurrencyDetail.ExchangeRate

                                            AccountPayable.ForeignInvoiceAmount = AccountPayableRecur.InvoiceAmount
                                            AccountPayable.ForeignSalesTaxAmount = AccountPayableRecur.SalesTaxAmount.GetValueOrDefault(0)

                                            AccountPayable.ExchangeAmount = AccountPayable.ForeignInvoiceAmount - AccountPayable.InvoiceAmount

                                        Else

                                            AccountPayable.InvoiceAmount = AccountPayableRecur.InvoiceAmount + AccountPayableRecur.ShippingAmount.GetValueOrDefault(0)
                                            AccountPayable.ShippingAmount = 0
                                            AccountPayable.SalesTaxAmount = AccountPayableRecur.SalesTaxAmount

                                        End If

                                    Else

                                        AccountPayable.InvoiceAmount = AccountPayableRecur.InvoiceAmount + AccountPayableRecur.ShippingAmount.GetValueOrDefault(0)
                                        AccountPayable.ShippingAmount = 0
                                        AccountPayable.SalesTaxAmount = AccountPayableRecur.SalesTaxAmount

                                    End If

                                    If AdvantageFramework.Database.Procedures.Agency.IsAPLimitByOfficeEnabled(DbContext) OrElse
                                            AdvantageFramework.Database.Procedures.Agency.IsInterCompanyTransactionsEnabled(DbContext) Then

                                        AccountPayable.SetRequired(AdvantageFramework.Database.Entities.AccountPayable.Properties.OfficeCode.ToString, True)

                                    End If

                                    If AccountPayable.OfficeCode Is Nothing AndAlso (AdvantageFramework.Database.Procedures.Agency.IsAPLimitByOfficeEnabled(DbContext) OrElse
                                                                                     AdvantageFramework.Database.Procedures.Agency.IsInterCompanyTransactionsEnabled(DbContext)) Then

                                        If AccountPayableRecur.GeneralLedgerAccount IsNot Nothing AndAlso AccountPayableRecur.GeneralLedgerAccount.GeneralLedgerOfficeCrossReference IsNot Nothing Then

                                            AccountPayable.OfficeCode = AccountPayableRecur.GeneralLedgerAccount.GeneralLedgerOfficeCrossReference.OfficeCode

                                        End If

                                    End If

                                    GLDescription = "VN:" & AccountPayable.VendorCode & "-" & Vendor.Name & ",Inv:" & AccountPayable.InvoiceNumber
                                    If AdvantageFramework.GeneralLedger.InsertGeneralLedger(GeneralLedger, DbContext, AccountPayable.PostPeriodCode, Me.Session.UserCode, GLDescription, "RA", _BatchDate) = False Then

                                        Throw New Exception("Problem inserting General Ledger.")

                                    End If

                                    CreditAmount = (AccountPayable.InvoiceAmount + AccountPayable.SalesTaxAmount) * -1
                                    Remark = "Vendor:" & AccountPayable.VendorCode & "-" & Vendor.Name & ", Inv: " & AdvantageFramework.AccountPayable.FormatInvoice(AccountPayable)

                                    If AdvantageFramework.GeneralLedger.InsertGeneralLedgerDetail(GeneralLedgerDetail, DbContext, GeneralLedger.Transaction, AccountPayable.GLACode, CreditAmount, Remark, "RA") = False Then

                                        Throw New Exception("Problem inserting General Ledger Detail.")

                                    End If

                                    AccountPayable.GLTransaction = GeneralLedger.Transaction
                                    AccountPayable.GLSequenceNumber = GeneralLedgerDetail.SequenceNumber

                                    If AdvantageFramework.Database.Procedures.AccountPayable.Insert(DbContext, AccountPayable) = False Then

                                        Throw New Exception("Problem inserting Account Payable.")

                                    End If

                                    AccountPayableRecurGeneralLedgerList = New Generic.List(Of AdvantageFramework.Database.Entities.AccountPayableRecurGeneralLedger)

                                    AccountPayableRecurGeneralLedgerList.AddRange(AdvantageFramework.Database.Procedures.AccountPayableRecurGeneralLedger.LoadByRecurID(DbContext, AccountPayableRecur.ID))

                                    For Each AccountPayableRecurGeneralLedger In AccountPayableRecurGeneralLedgerList

                                        If AccountPayableRecurGeneralLedger.OfficeCode Is Nothing AndAlso AdvantageFramework.Database.Procedures.Agency.IsInterCompanyTransactionsEnabled(DbContext) Then

                                            GeneralLedgerAccount = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadByGLACode(DbContext, AccountPayableRecurGeneralLedger.GLACode)

                                            If GeneralLedgerAccount IsNot Nothing AndAlso GeneralLedgerAccount.GeneralLedgerOfficeCrossReference IsNot Nothing Then

                                                AccountPayableRecurGeneralLedger.OfficeCode = GeneralLedgerAccount.GeneralLedgerOfficeCrossReference.OfficeCode

                                            Else

                                                Throw New Exception("Problem with AP Recur setup: " & AccountPayableRecur.VendorCode & "-" & AccountPayableRecur.InvoiceNumber)

                                            End If

                                        End If

                                        Remark = "Vendor:" & AccountPayable.VendorCode & "-" & Vendor.Name & ", Inv: " & AccountPayable.InvoiceNumber & " " & AccountPayableRecurGeneralLedger.Comments

                                        If IsMultiCurrencyEnabled AndAlso Vendor.CurrencyCode <> CurrencyCodeHome Then

                                            AdvantageFramework.AccountPayable.AddNonClient(DbContext, GeneralLedger.Transaction, AccountPayableRecurGeneralLedger.GLACode, FormatNumber(AccountPayableRecurGeneralLedger.Amount * CurrencyDetail.ExchangeRate, 2), Remark, "RA", Nothing, Nothing, Me.Session.UserCode, AccountPayableRecurGeneralLedger.OfficeCode, AccountPayableRecurGeneralLedger.Comments, AccountPayable, Vendor.Name, Nothing, Nothing)

                                        Else

                                            AdvantageFramework.AccountPayable.AddNonClient(DbContext, GeneralLedger.Transaction, AccountPayableRecurGeneralLedger.GLACode, AccountPayableRecurGeneralLedger.Amount, Remark, "RA", Nothing, Nothing, Me.Session.UserCode, AccountPayableRecurGeneralLedger.OfficeCode, AccountPayableRecurGeneralLedger.Comments, AccountPayable, Vendor.Name, Nothing, Nothing)

                                        End If

                                    Next

                                    If DbContext.Database.SqlQuery(Of Integer)(String.Format("exec [advsp_ap_invoice_balanced] {0}, {1}", AccountPayable.ID, GeneralLedger.Transaction)).FirstOrDefault <> 1 Then

                                        Throw New Exception("Invoice is out of balance when trying to post for vendor: " & AccountPayableRecur.VendorCode & " invoice: " & AccountPayableRecur.InvoiceNumber)

                                    End If

                                    SqlParameterRecurID = New SqlClient.SqlParameter("@RECUR_ID", SqlDbType.Int)
                                    SqlParameterRecurID.Value = AccountPayableRecur.ID

                                    SqlParameterInvoiceDate = New SqlClient.SqlParameter("@INVOICE_DATE", SqlDbType.SmallDateTime)
                                    SqlParameterInvoiceDate.Value = DateTimePickerForm_InvoiceDate.Value

                                    SqlParameterPostPeriod = New SqlClient.SqlParameter("@POST_PERIOD", SqlDbType.VarChar)
                                    SqlParameterPostPeriod.Value = ComboBoxForm_PostingPeriod.SelectedValue

                                    SqlParameterUserID = New SqlClient.SqlParameter("@USER_ID", SqlDbType.VarChar)
                                    SqlParameterUserID.Value = Me.Session.UserCode

                                    DbContext.Database.ExecuteSqlCommand("INSERT INTO AP_RECUR_LOG (RECUR_ID, INVOICE_DATE, POST_PERIOD, USER_ID, DATE_POSTED) VALUES (@RECUR_ID, @INVOICE_DATE, @POST_PERIOD, @USER_ID, getdate())", SqlParameterRecurID, SqlParameterInvoiceDate, SqlParameterPostPeriod, SqlParameterUserID)

                                    AccountPayableRecur.LastPostedDate = Now.ToShortDateString
                                    AccountPayableRecur.LastPostPeriodCode = ComboBoxForm_PostingPeriod.SelectedValue

                                    If AccountPayableRecur.TotalPosted Is Nothing Then

                                        AccountPayableRecur.TotalPosted = 1

                                    Else

                                        AccountPayableRecur.TotalPosted = AccountPayableRecur.TotalPosted + 1

                                    End If

                                    If AdvantageFramework.Database.Procedures.AccountPayableRecur.Update(DbContext, AccountPayableRecur) = False Then

                                        Throw New Exception("Problem updating AP Recur.")

                                    End If

                                    TotalPosted += 1

                                End If

                            Next

                            DbTransaction.Commit()

                            AdvantageFramework.WinForm.MessageBox.Show(String.Format("{0} Invoice(s) posted.", TotalPosted.ToString), WinForm.MessageBox.MessageBoxButtons.OK, "Post Complete")

                            LoadGrid()

                        Catch ex As Exception
                            DbTransaction.Rollback()
                            ErrorMessage = "Failed trying to save data to the database. Please contact software support."
                            ErrorMessage += vbCrLf & ex.Message
                        Finally

                            If DbContext.Database.Connection.State = ConnectionState.Open Then

                                DbContext.Database.Connection.Close()

                            End If

                        End Try

                        If ErrorMessage <> "" Then

                            AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                        End If

                    End If

                End Using

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonItemActions_Print_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Print.Click

            Dim ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing
            Dim AccountPayableBatchReportList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableBatchReport) = Nothing
            Dim BatchDate As Date = Nothing
            Dim UserCode As String = Nothing
            Dim ContinueReport As Boolean = False
            Dim ReportRange As String = Nothing
            Dim DetailPageBreak As Boolean = False
            Dim SqlParameterUserCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterBatchDate As System.Data.SqlClient.SqlParameter = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                UserCode = Me.Session.UserCode

                If AdvantageFramework.FinanceAndAccounting.Presentation.AccountsPayableBatchReportDialog.ShowFormDialog(BatchDate, UserCode, DetailPageBreak) = System.Windows.Forms.DialogResult.OK Then

                    SqlParameterUserCode = New SqlClient.SqlParameter("@user_code", SqlDbType.VarChar)
                    SqlParameterBatchDate = New SqlClient.SqlParameter("@batch_date", SqlDbType.SmallDateTime)

                    SqlParameterUserCode.Value = UserCode
                    SqlParameterBatchDate.Value = BatchDate

                    AccountPayableBatchReportList = DbContext.Database.SqlQuery(Of AdvantageFramework.AccountPayable.Classes.AccountPayableBatchReport)("exec advsp_ap_recur_batch_report @user_code, @batch_date", SqlParameterUserCode, SqlParameterBatchDate).ToList()
                    ReportRange = "Batch: " & BatchDate.ToString

                    ContinueReport = True

                End If

            End Using

            If ContinueReport Then

                ParameterDictionary = New Generic.Dictionary(Of String, Object)

                ParameterDictionary.Add("DataSource", AccountPayableBatchReportList)
                ParameterDictionary.Add("ForUser", UserCode)
                ParameterDictionary.Add("ReportRange", ReportRange)
                ParameterDictionary.Add("DetailPageBreak", DetailPageBreak)

                AdvantageFramework.Reporting.Presentation.ReportViewerForm.ShowFormDialog(Me.Session, Reporting.ReportTypes.AccountPayableRecurBatch, ParameterDictionary, Nothing, Nothing, Nothing, Nothing)

            End If

        End Sub
        Private Sub DataGridViewForm_APRecur_CellValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_APRecur.CellValueChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_APRecur_CellValueChangingEvent(ByRef Saved As Boolean, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_APRecur.CellValueChangingEvent

            Dim AccountPayableInvoiceFromRecur As AdvantageFramework.AccountPayable.Classes.AccountPayableInvoiceFromRecur = Nothing

            If e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableInvoiceFromRecur.Properties.CreateAP.ToString Then

                Try

                    AccountPayableInvoiceFromRecur = DataGridViewForm_APRecur.GetFirstSelectedRowDataBoundItem

                Catch ex As Exception
                    AccountPayableInvoiceFromRecur = Nothing
                End Try

                If AccountPayableInvoiceFromRecur IsNot Nothing Then

                    Try

                        AccountPayableInvoiceFromRecur.CreateAP = e.Value
                        DataGridViewForm_APRecur.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.AccountPayable.Classes.AccountPayableInvoiceFromRecur.Properties.CreateAP.ToString, e.Value)

                    Catch ex As Exception
                        AccountPayableInvoiceFromRecur.CreateAP = AccountPayableInvoiceFromRecur.CreateAP
                    End Try

                End If

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub DataGridViewForm_APRecur_Validating(sender As Object, e As ComponentModel.CancelEventArgs) Handles DataGridViewForm_APRecur.Validating

            EnableOrDisableActions()

        End Sub
        Private Sub DateTimePickerForm_InvoiceDate_Leave(sender As Object, e As EventArgs) Handles DateTimePickerForm_InvoiceDate.Leave

            If DateTimePickerForm_InvoiceDate.Value = #12:00:00 AM# Then

                DateTimePickerForm_InvoiceDate.Value = Now.ToShortDateString

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
