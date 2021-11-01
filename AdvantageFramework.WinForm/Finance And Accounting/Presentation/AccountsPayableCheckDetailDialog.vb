Namespace FinanceAndAccounting.Presentation

    Public Class AccountsPayableCheckDetailDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _CheckNumber As Integer = Nothing
        Protected _BankCode As String = Nothing
        Protected _AccountPayableID As Integer = Nothing
        'Protected _CurrencySymbol As String = Nothing
        Dim NewCulture As System.Globalization.CultureInfo = System.Globalization.CultureInfo.CurrentUICulture.Clone()

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByVal CheckNumber As Integer, BankCode As String, AccountPayableID As Integer)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _CheckNumber = CheckNumber
            _BankCode = BankCode
            _AccountPayableID = AccountPayableID

        End Sub
        Private Sub LoadCheckDetail()

            Dim CheckRegister As AdvantageFramework.Database.Entities.CheckRegister = Nothing
            Dim AccountPayablePayment As AdvantageFramework.Database.Entities.AccountPayablePayment = Nothing
            Dim AccountPayablePaymentList As Generic.List(Of AdvantageFramework.Database.Classes.AccountsPayablePaymentHistory) = Nothing
            Dim Currency_Code As String = Nothing
            Dim CurrencySymbol As String = Nothing
            Dim CurrencyFormat As String = Nothing
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
            Dim AccountsPayablePaymentHistoryList As Generic.List(Of AdvantageFramework.Database.Classes.AccountsPayablePaymentHistory) = Nothing
            Dim SqlParameterBankCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterAccountPayableID As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterCheckNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterCheckDateCutoff As System.Data.SqlClient.SqlParameter = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Try

                    CheckRegister = (From Entity In AdvantageFramework.Database.Procedures.CheckRegister.Load(DbContext).Include("AccountPayablePayments")
                                     Where Entity.BankCode = _BankCode AndAlso
                                           Entity.CheckNumber = _CheckNumber).SingleOrDefault

                Catch ex As Exception
                    CheckRegister = Nothing
                End Try

                If CheckRegister IsNot Nothing Then

                    If CheckRegister.GLTransaction IsNot Nothing Then

                        TextBoxPanel_GLTransaction.Text = CheckRegister.GLTransaction

                        SqlParameterBankCode = New System.Data.SqlClient.SqlParameter("@bk_code", SqlDbType.VarChar)
                        SqlParameterCheckNumber = New System.Data.SqlClient.SqlParameter("@chk_nbr", SqlDbType.Int)
                        SqlParameterAccountPayableID = New System.Data.SqlClient.SqlParameter("@ap_id", SqlDbType.Int)
                        SqlParameterCheckDateCutoff = New System.Data.SqlClient.SqlParameter("@ap_chk_date", SqlDbType.SmallDateTime)

                        SqlParameterBankCode.Value = _BankCode
                        SqlParameterCheckNumber.Value = _CheckNumber
                        SqlParameterAccountPayableID.Value = _AccountPayableID
                        SqlParameterCheckDateCutoff.Value = DBNull.Value

                        AccountPayablePaymentList = DbContext.Database.SqlQuery(Of AdvantageFramework.Database.Classes.AccountsPayablePaymentHistory) _
                            ("exec advsp_ap_pmt_hist_base @bk_code, @chk_nbr, @ap_id, @ap_chk_date",
                             SqlParameterBankCode, SqlParameterCheckNumber, SqlParameterAccountPayableID, SqlParameterCheckDateCutoff).ToList

                        DataGridViewPanel_TransactionDetails.DataSource = AccountPayablePaymentList

                        If AccountPayablePaymentList IsNot Nothing AndAlso AccountPayablePaymentList.Count > 0 AndAlso AccountPayablePaymentList.FirstOrDefault.HomeCurrencyCode Is Nothing Then

                            DataGridViewPanel_TransactionDetails.Columns(AdvantageFramework.Database.Classes.AccountsPayablePaymentHistory.Properties.HomeCurrencyCode.ToString).Visible = False
                            DataGridViewPanel_TransactionDetails.Columns(AdvantageFramework.Database.Classes.AccountsPayablePaymentHistory.Properties.CurrencyRate.ToString).Visible = False
                            DataGridViewPanel_TransactionDetails.Columns(AdvantageFramework.Database.Classes.AccountsPayablePaymentHistory.Properties.CurrencyExchangeAmount.ToString).Visible = False

                        End If

                        DataGridViewPanel_TransactionDetails.CurrentView.BestFitColumns()

                    End If

                    Try

                        AccountPayablePayment = CheckRegister.AccountPayablePayments.FirstOrDefault()

                    Catch ex As Exception
                        AccountPayablePayment = Nothing
                    End Try

                    If AccountPayablePayment IsNot Nothing Then

                        'Get CURRENCY_SYMBOL from CURRENCY_CODES table
                        AdvantageFramework.Currency.GetBankCurrencyCodeByBankCode(DbContext, AccountPayablePayment.BankCode, Currency_Code, CurrencySymbol)

                        'Found CurrentRegion does not give a full list. It won't work in all cases
                        '_CurrencySymbol = Globalization.RegionInfo.CurrentRegion.CurrencySymbol 'Hold the original value for BeforeFormClosing event

                        'System.Threading.Thread.CurrentThread.CurrentCulture = NewCulture
                        'CurrencySymbol = AdvantageFramework.Currency.GetCurrencySymbolByCurrencyCode(Currency_Code)
                        'NewCulture.NumberFormat.CurrencySymbol = CurrencySymbol

                        'If CurrencySymbol = Nothing Then
                        '    CurrencySymbol = ""
                        'End If

                        If Currency_Code = Nothing Then
                            Currency_Code = ""
                        Else
                            Currency_Code = Currency_Code + " "
                        End If

                        CurrencySymbol = Currency_Code 'Use Code for  Symbol

                        TextBoxPanel_PostPeriod.Text = CheckRegister.PostPeriodCode

                        TextBoxPanel_PaidTo.Text = CheckRegister.PayToVenderCode & " - " & CheckRegister.PayToVender

                        TextBoxCheck_Number.Text = CheckRegister.CheckNumber
                        TextBoxCheck_Date.Text = CheckRegister.CheckDate
                        NumericInputCheck_Amount.EditValue = CheckRegister.CheckAmount.GetValueOrDefault(0)
                        CurrencyFormat = CurrencySymbol + "###,###,###,###,##0.00"
                        NumericInputCheck_Amount.SetFormat(CurrencyFormat)
                        CheckBoxCheck_Cleared.Checked = If(CheckRegister.IsCleared.GetValueOrDefault(0) = 1, True, False)

                        TextBoxVoided_By.Text = CheckRegister.VoidedByUserCode
                        TextBoxVoided_On.Text = If(CheckRegister.VoidDate IsNot Nothing, CheckRegister.VoidDate, "")
                        TextBoxVoided_PostPeriod.Text = CheckRegister.VoidPostPeriodCode

                        If AccountPayablePayment.Bank IsNot Nothing Then

                            TextBoxPanel_Bank.Text = AccountPayablePayment.Bank.ToString

                        End If

                        If AccountPayablePayment.CashGeneralLedgerAccount IsNot Nothing Then

                            TextBoxPanel_CashAccount.Text = AccountPayablePayment.CashGeneralLedgerAccount.ToString

                        End If

                        If AccountPayablePayment.AccountPayableDiscountGeneralLedgerAccount IsNot Nothing Then

                            TextBoxPanel_DiscountAccount.Text = AccountPayablePayment.AccountPayableDiscountGeneralLedgerAccount.ToString

                        End If

                    End If

                End If

            End Using

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal CheckNumber As Integer, BankCode As String, AccountPayableID As Integer) As System.Windows.Forms.DialogResult

            'objects
            Dim AccountsPayableCheckDetailDialog As AdvantageFramework.FinanceAndAccounting.Presentation.AccountsPayableCheckDetailDialog = Nothing

            AccountsPayableCheckDetailDialog = New AdvantageFramework.FinanceAndAccounting.Presentation.AccountsPayableCheckDetailDialog(CheckNumber, BankCode, AccountPayableID)

            ShowFormDialog = AccountsPayableCheckDetailDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub AccountsPayableCheckDetailDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            DataGridViewPanel_TransactionDetails.MultiSelect = False

            CheckBoxCheck_Cleared.Enabled = False

            NumericInputCheck_Amount.Properties.ReadOnly = True

            LoadCheckDetail()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonForm_Close.Click

            Me.Close()

        End Sub

        Private Sub NumericInputCheck_Amount_EditValueChanged(sender As Object, e As EventArgs) Handles NumericInputCheck_Amount.EditValueChanged

        End Sub

        Private Sub AccountsPayableCheckDetailDialog_BeforeFormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.BeforeFormClosing
            'NewCulture.NumberFormat.CurrencySymbol = _CurrencySymbol 'Set it back tp original
        End Sub

#End Region

#End Region

    End Class

End Namespace