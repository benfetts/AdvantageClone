Namespace Billing.Presentation

    Public Class TransferItemDetailDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _EmployeeTimeItem As AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem = Nothing
        Private _AccountPayableProductionItem As AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem = Nothing
        Private _IncomeOnlyItem As AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem = Nothing
        Private _BillingRate As AdvantageFramework.Database.Classes.BillingRate = Nothing
        Private _BillingCommandCenterID As Integer = Nothing
        Private _BillingUser As String = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByVal TransferItem As AdvantageFramework.BaseClasses.BaseClass, ByVal BillingCommandCenterID As Integer)

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            If TypeOf TransferItem Is AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem Then

                _EmployeeTimeItem = DirectCast(TransferItem, AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem)

            ElseIf TypeOf TransferItem Is AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem Then

                _AccountPayableProductionItem = DirectCast(TransferItem, AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem)

            ElseIf TypeOf TransferItem Is AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem Then

                _IncomeOnlyItem = DirectCast(TransferItem, AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem)

            End If

            _BillingCommandCenterID = BillingCommandCenterID

            SearchableComboBoxTransferTo_Job.ErrorIconAlignment = Windows.Forms.ErrorIconAlignment.MiddleLeft
            SearchableComboBoxTransferTo_JobComponent.ErrorIconAlignment = Windows.Forms.ErrorIconAlignment.MiddleLeft
            SearchableComboBoxTransferTo_Function.ErrorIconAlignment = Windows.Forms.ErrorIconAlignment.MiddleLeft

            SearchableComboBoxTransferTo_GLAccount.ErrorIconAlignment = Windows.Forms.ErrorIconAlignment.MiddleLeft
            SearchableComboBoxTransferTo_PostPeriod.ErrorIconAlignment = Windows.Forms.ErrorIconAlignment.MiddleLeft

            For Each NumericInput In Me.GroupBoxFrom_TransferTo.Controls.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.NumericInput)()

                NumericInput.ErrorIconAlignment = Windows.Forms.ErrorIconAlignment.MiddleLeft

            Next

        End Sub
        Private Function AmountIsValid(ByRef ErrorMessage As String) As Boolean

            'objects
            Dim IsValid As Boolean = True
            Dim TransferFromAmount As Decimal = 0
            Dim TransferToAmount As Decimal = 0

            TransferFromAmount = NumericInputTransferFrom_Amount.EditValue
            TransferToAmount = NumericInputTransferTo_Amount.EditValue

            NumericInputTransferTo_Amount.ErrorText = Nothing

            If _AccountPayableProductionItem IsNot Nothing AndAlso (TransferToAmount = 0 OrElse (TransferToAmount < Math.Min(0.01, TransferFromAmount) OrElse TransferToAmount > Math.Max(0.01, TransferFromAmount))) Then

                ErrorMessage = "You cannot transfer 0 or an amount greater than the original WIP amount.  Amount should be between " & CStr(Math.Min(0.01, TransferFromAmount)) & " and " & CStr(Math.Max(0.01, TransferFromAmount)) & "."

                NumericInputTransferTo_Amount.ErrorText = ErrorMessage

                IsValid = False

            ElseIf _IncomeOnlyItem IsNot Nothing AndAlso (TransferToAmount = 0 OrElse (TransferToAmount < Math.Min(0.01, TransferFromAmount) OrElse TransferToAmount > Math.Max(0.01, TransferFromAmount))) Then

                ErrorMessage = "You cannot transfer 0 or an amount greater than the original amount.  Amount should be between " & CStr(Math.Min(0.01, TransferFromAmount)) & " and " & CStr(Math.Max(0.01, TransferFromAmount)) & "."

                NumericInputTransferTo_Amount.ErrorText = ErrorMessage

                IsValid = False

            End If

            AmountIsValid = IsValid

        End Function
        Private Function QuantityIsValid(ByRef ErrorMessage As String) As Boolean

            'objects
            Dim IsValid As Boolean = True
            Dim TransferFromQty As Decimal = 0
            Dim TransferToQty As Decimal = 0

            TransferFromQty = NumericInputTransferFrom_QtyHours.EditValue
            TransferToQty = NumericInputTransferTo_QtyHours.EditValue

            NumericInputTransferTo_QtyHours.ErrorText = Nothing

            If _EmployeeTimeItem IsNot Nothing AndAlso (TransferToQty < Math.Min(0.01, TransferFromQty) OrElse TransferToQty > Math.Max(0.01, TransferFromQty)) Then

                ErrorMessage = "Transferring hours should be between " & CStr(Math.Min(0.01, TransferFromQty)) & " and " & CStr(Math.Max(0.01, TransferFromQty)) & "."

                NumericInputTransferTo_QtyHours.ErrorText = ErrorMessage

                IsValid = False

            ElseIf _AccountPayableProductionItem IsNot Nothing AndAlso (TransferToQty < Math.Min(0.01, TransferFromQty) OrElse TransferToQty > Math.Max(0.01, TransferFromQty)) Then

                ErrorMessage = "Transferring quantity should be between " & CStr(Math.Min(0.01, TransferFromQty)) & " and " & CStr(Math.Max(0.01, TransferFromQty)) & "."

                NumericInputTransferTo_QtyHours.ErrorText = ErrorMessage

                IsValid = False

            ElseIf _IncomeOnlyItem IsNot Nothing AndAlso (TransferToQty < Math.Min(0.01, TransferFromQty) OrElse TransferToQty > Math.Max(0.01, TransferFromQty)) Then

                ErrorMessage = "Transferring quantity should be between " & CStr(Math.Min(0.01, TransferFromQty)) & " and " & CStr(Math.Max(0.01, TransferFromQty)) & "."

                NumericInputTransferTo_QtyHours.ErrorText = ErrorMessage

                IsValid = False

            End If

            QuantityIsValid = IsValid

        End Function
        'Private Function VendorTaxIsValid(ByRef ErrorMessage As String) As Boolean

        '    'objects
        '    Dim IsValid As Boolean = True

        '    If _AccountPayableProductionItem IsNot Nothing AndAlso Math.Abs(NumericInputTransferTo_VendorTax.EditValue) > NumericInputTransferFrom_VendorTax.EditValue Then

        '        ErrorMessage = "You are transferring vendor tax greater than the original vendor tax.  This is not permitted."

        '        IsValid = False

        '    End If

        '    VendorTaxIsValid = IsValid

        'End Function
        Private Sub CalculateAPTax()

            'objects
            Dim AccountPayableProduction As AdvantageFramework.Database.Entities.AccountPayableProduction = Nothing
            Dim HasVendorTax As Boolean = False

            If SearchableComboBoxTransferTo_Tax.HasASelectedValue AndAlso _BillingRate IsNot Nothing Then

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    AccountPayableProduction = New AdvantageFramework.Database.Entities.AccountPayableProduction

                    AccountPayableProduction.SalesTaxCode = SearchableComboBoxTransferTo_Tax.GetSelectedValue
                    AccountPayableProduction.TaxCommissionsOnly = _BillingRate.TAX_COMM_ONLY.GetValueOrDefault(0)
                    AccountPayableProduction.TaxCommissions = _BillingRate.TAX_COMM.GetValueOrDefault(0)

                    AccountPayableProduction.ExtendedMarkupAmount = NumericInputTransferTo_MarkupAmount.EditValue
                    AccountPayableProduction.ExtendedAmount = NumericInputTransferTo_Amount.EditValue

                    If _AccountPayableProductionItem.ExtendedNonResaleTax <> 0 Then

                        HasVendorTax = True

                    End If

                    AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.CalculateTaxForTransfer(DbContext, AccountPayableProduction.SalesTaxCode, AccountPayableProduction, HasVendorTax,
                                                                                                                                 _AccountPayableProductionItem.CityTaxPercent + _AccountPayableProductionItem.CountyTaxPercent + _AccountPayableProductionItem.StateTaxPercent)

                    NumericInputTransferTo_VendorTax.EditValue = AccountPayableProduction.ExtendedNonResaleTax
                    NumericInputTransferTo_ResaleTax.EditValue = FormatNumber(AccountPayableProduction.ExtendedStateResale.GetValueOrDefault(0) + AccountPayableProduction.ExtendedCountyResale.GetValueOrDefault(0) + AccountPayableProduction.ExtendedCityResale.GetValueOrDefault(0), 2)

                End Using

            Else

                NumericInputTransferTo_VendorTax.EditValue = 0.0
                NumericInputTransferTo_ResaleTax.EditValue = 0.0

            End If

        End Sub
        ''' <summary>
        ''' This calculates resale tax even though the tax code may be marked as vendor tax (not resale)
        ''' </summary>
        Private Sub CalculateResaleTaxForEmployeeTimeOrIncomeOnly()

            'objects
            Dim SalesTax As AdvantageFramework.Database.Entities.SalesTax = Nothing
            Dim TaxableAmount As Decimal = Nothing
            Dim StateTax As Decimal = Nothing
            Dim CountyTax As Decimal = Nothing
            Dim CityTax As Decimal = Nothing

            If SearchableComboBoxTransferTo_Tax.HasASelectedValue AndAlso SearchableComboBoxTransferTo_Tax.Enabled Then

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    SalesTax = AdvantageFramework.Database.Procedures.SalesTax.LoadBySalesTaxCode(DbContext, SearchableComboBoxTransferTo_Tax.GetSelectedValue)

                    If SalesTax IsNot Nothing Then

                        If _BillingRate IsNot Nothing Then

                            If _BillingRate.TAX_COMM_ONLY.GetValueOrDefault(0) = 1 Then

                                TaxableAmount = NumericInputTransferTo_MarkupAmount.EditValue

                            ElseIf _BillingRate.TAX_COMM.GetValueOrDefault(0) = 1 Then

                                TaxableAmount = NumericInputTransferTo_MarkupAmount.EditValue + NumericInputTransferTo_Amount.EditValue

                            Else

                                TaxableAmount = NumericInputTransferTo_Amount.EditValue

                            End If

                        End If

                        StateTax = FormatNumber(SalesTax.StatePercent.GetValueOrDefault(0) * TaxableAmount / 100, 2)
                        CountyTax = FormatNumber(SalesTax.CountyPercent.GetValueOrDefault(0) * TaxableAmount / 100, 2)
                        CityTax = FormatNumber(SalesTax.CityPercent.GetValueOrDefault(0) * TaxableAmount / 100, 2)

                        NumericInputTransferTo_ResaleTax.EditValue = FormatNumber(StateTax + CountyTax + CityTax, 2)

                    End If

                End Using

            Else

                NumericInputTransferTo_ResaleTax.EditValue = 0.0

            End If

        End Sub
        Private Sub Recalculate(Optional ByVal BypassCalculateAPTax As Boolean = False)

            If _AccountPayableProductionItem IsNot Nothing Then

                If NumericInputTransferTo_MarkupPercent.EditValue <> 0 Then

                    NumericInputTransferTo_MarkupAmount.EditValue = FormatNumber(NumericInputTransferTo_Amount.EditValue * NumericInputTransferTo_MarkupPercent.EditValue / 100, 2)

                Else

                    NumericInputTransferTo_MarkupAmount.EditValue = 0.0

                End If

                If Not BypassCalculateAPTax Then

                    CalculateAPTax()

                End If

                If _AccountPayableProductionItem.ExtendedNonResaleTax > 0 AndAlso NumericInputTransferTo_Amount.EditValue <> 0 Then

                    NumericInputTransferTo_VendorTax.EditValue = NumericInputTransferFrom_VendorTax.EditValue - FormatNumber((_AccountPayableProductionItem.ExtendedAmount - NumericInputTransferTo_Amount.EditValue) * (_AccountPayableProductionItem.CityTaxPercent + _AccountPayableProductionItem.StateTaxPercent + _AccountPayableProductionItem.CountyTaxPercent) / 100, 2)

                End If

                NumericInputTransferTo_Total.EditValue = FormatNumber(NumericInputTransferTo_Amount.EditValue + NumericInputTransferTo_VendorTax.EditValue +
                                                                      NumericInputTransferTo_ResaleTax.EditValue + NumericInputTransferTo_MarkupAmount.EditValue, 2)

            End If

            If _EmployeeTimeItem IsNot Nothing Then

                NumericInputTransferTo_Amount.EditValue = NumericInputTransferTo_QtyHours.EditValue * NumericInputTransferTo_Rate.EditValue

                If NumericInputTransferTo_Amount.EditValue <> 0 AndAlso NumericInputTransferTo_MarkupPercent.EditValue <> 0 Then

                    NumericInputTransferTo_MarkupAmount.EditValue = FormatNumber(NumericInputTransferTo_Amount.EditValue * NumericInputTransferTo_MarkupPercent.EditValue / 100, 2)

                Else

                    NumericInputTransferTo_MarkupAmount.EditValue = 0.0

                End If

                CalculateResaleTaxForEmployeeTimeOrIncomeOnly()

                NumericInputTransferTo_Total.EditValue = NumericInputTransferTo_Amount.EditValue + NumericInputTransferTo_ResaleTax.EditValue + NumericInputTransferTo_MarkupAmount.EditValue

            End If

            If _IncomeOnlyItem IsNot Nothing Then

                If NumericInputTransferTo_MarkupPercent.EditValue <> 0 Then

                    NumericInputTransferTo_MarkupAmount.EditValue = FormatNumber(NumericInputTransferTo_Amount.EditValue * NumericInputTransferTo_MarkupPercent.EditValue / 100, 2)

                Else

                    NumericInputTransferTo_MarkupAmount.EditValue = 0.0

                End If

                CalculateResaleTaxForEmployeeTimeOrIncomeOnly()

                NumericInputTransferTo_Total.EditValue = FormatNumber(NumericInputTransferTo_Amount.EditValue + NumericInputTransferTo_VendorTax.EditValue +
                                                                      NumericInputTransferTo_ResaleTax.EditValue + NumericInputTransferTo_MarkupAmount.EditValue, 2)

            End If

        End Sub
        Private Sub SetBillingRate(ByVal DbContext As AdvantageFramework.Database.DbContext)

            'objects
            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing
            Dim EmployeeCode As String = Nothing
            Dim EffectiveDate As Nullable(Of Date) = Nothing
            Dim BillingRateLevel As AdvantageFramework.Database.Entities.BillingRateLevel = Nothing

            If SearchableComboBoxTransferTo_Job.HasASelectedValue AndAlso SearchableComboBoxTransferTo_JobComponent.HasASelectedValue AndAlso SearchableComboBoxTransferTo_Function.HasASelectedValue Then

                JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, SearchableComboBoxTransferTo_Job.GetSelectedValue, SearchableComboBoxTransferTo_JobComponent.GetSelectedValue)

                If JobComponent IsNot Nothing Then

                    If _EmployeeTimeItem IsNot Nothing Then

                        EmployeeCode = _EmployeeTimeItem.EmployeeCode
                        EffectiveDate = _EmployeeTimeItem.EmployeeDate

                    End If

                    _BillingRate = AdvantageFramework.ExpenseReports.LoadBillingRate(DbContext, SearchableComboBoxTransferTo_Function.GetSelectedValue, SearchableComboBoxTransferTo_Client.GetSelectedValue,
                                                                                     SearchableComboBoxTransferTo_Division.GetSelectedValue, SearchableComboBoxTransferTo_Product.GetSelectedValue,
                                                                                     JobComponent.Job.Number, SearchableComboBoxTransferTo_JobComponent.GetSelectedValue, JobComponent.Job.SalesClassCode,
                                                                                     EmployeeCode, EffectiveDate)

                    If _BillingRate IsNot Nothing Then

                        CheckBoxTransferTo_Billable.Checked = Not CBool(_BillingRate.NOBILL_FLAG.GetValueOrDefault(0))

                    End If

                    If RadioButtonMarkup_RecalculateFromHierarchy.Checked Then

                        NumericInputTransferTo_MarkupPercent.EditValue = If(_BillingRate IsNot Nothing, _BillingRate.COMM.GetValueOrDefault(0), 0)

                    End If

                    If SearchableComboBoxTransferTo_Tax.Enabled Then

                        SearchableComboBoxTransferTo_Tax.SelectedValue = If(_BillingRate IsNot Nothing, _BillingRate.TAX_CODE, Nothing)

                    End If

                    If _EmployeeTimeItem IsNot Nothing Then

                        If RadioButtonTime_RecalculateFromHierarchy.Checked Then

                            NumericInputTransferTo_Rate.EditValue = If(_BillingRate IsNot Nothing, _BillingRate.BILLING_RATE.GetValueOrDefault(0), Nothing)

                            If _BillingRate IsNot Nothing AndAlso _BillingRate.RATE_LEVEL = 9999 Then

                                LabelTransferTo_RateFrom.Text = "Approved Estimate"

                            ElseIf _BillingRate IsNot Nothing Then

                                Try

                                    If _BillingRate.RATE_LEVEL.HasValue Then

                                        BillingRateLevel = (From Entity In AdvantageFramework.Database.Procedures.BillingRateLevel.Load(DbContext)
                                                            Where Entity.Number = _BillingRate.RATE_LEVEL.Value
                                                            Select Entity).FirstOrDefault

                                    End If

                                Catch ex As Exception
                                    BillingRateLevel = Nothing
                                End Try

                                If BillingRateLevel IsNot Nothing Then

                                    LabelTransferTo_RateFrom.Text = BillingRateLevel.Description

                                Else

                                    LabelTransferTo_RateFrom.Text = Nothing

                                End If

                            Else

                                LabelTransferTo_RateFrom.Text = Nothing

                            End If

                            LabelTransferTo_RateFrom.Tag = LabelTransferTo_RateFrom.Text

                        End If

                    End If

                    If _AccountPayableProductionItem IsNot Nothing Then

                        If _BillingRate IsNot Nothing AndAlso _BillingRate.NOBILL_FLAG.GetValueOrDefault(0) = 1 Then

                            SearchableComboBoxTransferTo_GLAccount.DataSource = AdvantageFramework.AccountPayable.GetProductionGLAccountList(DbContext, JobComponent.Job.OfficeCode, Session)
                            SearchableComboBoxTransferTo_GLAccount.SelectedValue = Nothing
                            SearchableComboBoxTransferTo_GLAccount.Properties.ReadOnly = False

                        Else

                            SearchableComboBoxTransferTo_GLAccount.DataSource = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadAllActive(DbContext)
                            SearchableComboBoxTransferTo_GLAccount.SelectedValue = JobComponent.Job.Office.ProductionWorkInProgressGLACode
                            SearchableComboBoxTransferTo_GLAccount.Properties.ReadOnly = True

                        End If

                    End If

                End If

            End If

        End Sub
        Private Function Transfer(ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Transferred As Boolean = False
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim AgencyInvoiceTaxFlag As Boolean = False
            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing

            If _EmployeeTimeItem IsNot Nothing OrElse _AccountPayableProductionItem IsNot Nothing OrElse _IncomeOnlyItem IsNot Nothing Then

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, SearchableComboBoxTransferTo_Job.GetSelectedValue, SearchableComboBoxTransferTo_JobComponent.GetSelectedValue)

                    If JobComponent IsNot Nothing AndAlso JobComponent.IsAdvanceBilling.GetValueOrDefault(0) = 1 Then

                        AdvantageFramework.WinForm.MessageBox.Show("Cannot transfer to a job that is reconciled and not billed.")
                        SearchableComboBoxTransferTo_JobComponent.SelectedValue = Nothing
                        SearchableComboBoxTransferTo_Job.SelectedValue = Nothing

                    Else

                        AgencyInvoiceTaxFlag = AdvantageFramework.Database.Procedures.Agency.InvoiceTaxFlag(DbContext)

                        Try

                            DbContext.Database.Connection.Open()

                            DbTransaction = DbContext.Database.BeginTransaction

                            AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                            If _AccountPayableProductionItem IsNot Nothing Then

                                _AccountPayableProductionItem.CommissionPercent = If(NumericInputTransferTo_MarkupPercent.EditValue Is Nothing, 0, NumericInputTransferTo_MarkupPercent.EditValue)
                                _AccountPayableProductionItem.SalesTaxCode = SearchableComboBoxTransferTo_Tax.GetSelectedValue

                                _AccountPayableProductionItem.IsNonBillable = _BillingRate.NOBILL_FLAG.GetValueOrDefault(0)
                                _AccountPayableProductionItem.TaxCommissions = _BillingRate.TAX_COMM
                                _AccountPayableProductionItem.TaxCommissionsOnly = _BillingRate.TAX_COMM_ONLY

                                _AccountPayableProductionItem.ExtendedNonResaleTax = NumericInputTransferTo_VendorTax.EditValue

                                AdvantageFramework.BillingCommandCenter.TransferAP(Session, DbContext, _BillingCommandCenterID, _AccountPayableProductionItem, SearchableComboBoxTransferTo_Client.GetSelectedValue, SearchableComboBoxTransferTo_Division.GetSelectedValue, SearchableComboBoxTransferTo_Product.GetSelectedValue,
                                                                               SearchableComboBoxTransferTo_Job.GetSelectedValue, SearchableComboBoxTransferTo_JobComponent.GetSelectedValue, SearchableComboBoxTransferTo_Function.GetSelectedValue, SearchableComboBoxTransferTo_GLAccount.GetSelectedValue,
                                                                               SearchableComboBoxTransferTo_PostPeriod.GetSelectedValue, AgencyInvoiceTaxFlag, Nothing, NumericInputTransferTo_Amount.EditValue, TextBoxForm_Comments.GetText, NumericInputTransferTo_QtyHours.EditValue,
                                                                               NumericInputTransferTo_Rate.EditValue)

                            ElseIf _EmployeeTimeItem IsNot Nothing Then

                                _EmployeeTimeItem.CommissionPercentage = If(NumericInputTransferTo_MarkupPercent.EditValue Is Nothing, 0, NumericInputTransferTo_MarkupPercent.EditValue)
                                _EmployeeTimeItem.SalesTaxCode = SearchableComboBoxTransferTo_Tax.GetSelectedValue

                                _EmployeeTimeItem.IsNonBillable = _BillingRate.NOBILL_FLAG.GetValueOrDefault(0)
                                _EmployeeTimeItem.TaxCommission = _BillingRate.TAX_COMM
                                _EmployeeTimeItem.TaxCommissionOnly = _BillingRate.TAX_COMM_ONLY

                                If RadioButtonTime_RecalculateFromHierarchy.Checked Then

                                    _EmployeeTimeItem.BillableRate = FormatNumber(_BillingRate.BILLING_RATE.GetValueOrDefault(0), 2)
                                    _EmployeeTimeItem.EmployeeRateFrom = LabelTransferTo_RateFrom.Text

                                End If

                                _EmployeeTimeItem.TaskCode = SearchableComboBoxTransferTo_Task.GetSelectedValue

                                AdvantageFramework.BillingCommandCenter.TransferEmployeeTime(DbContext, _BillingCommandCenterID, _EmployeeTimeItem, SearchableComboBoxTransferTo_Client.GetSelectedValue, SearchableComboBoxTransferTo_Division.GetSelectedValue, SearchableComboBoxTransferTo_Product.GetSelectedValue,
                                    SearchableComboBoxTransferTo_Job.GetSelectedValue, SearchableComboBoxTransferTo_JobComponent.GetSelectedValue, SearchableComboBoxTransferTo_Function.GetSelectedValue, AgencyInvoiceTaxFlag,
                                    Nothing, Nothing, NumericInputTransferTo_QtyHours.EditValue, TextBoxForm_Comments.GetText, NumericInputTransferTo_QtyHours.EditValue, NumericInputTransferTo_Rate.EditValue)

                            ElseIf _IncomeOnlyItem IsNot Nothing Then

                                _IncomeOnlyItem.CommissionPercent = If(NumericInputTransferTo_MarkupPercent.EditValue Is Nothing, 0, NumericInputTransferTo_MarkupPercent.EditValue)
                                _IncomeOnlyItem.SalesTaxCode = SearchableComboBoxTransferTo_Tax.GetSelectedValue

                                _IncomeOnlyItem.IsNonBillable = CBool(_BillingRate.NOBILL_FLAG.GetValueOrDefault(0))
                                _IncomeOnlyItem.TaxCommission = CBool(_BillingRate.TAX_COMM.GetValueOrDefault(0))
                                _IncomeOnlyItem.TaxCommissionOnly = CBool(_BillingRate.TAX_COMM_ONLY.GetValueOrDefault(0))

                                AdvantageFramework.BillingCommandCenter.TransferIncomeOnly(DbContext, _BillingCommandCenterID, _IncomeOnlyItem, SearchableComboBoxTransferTo_Client.GetSelectedValue,
                                    SearchableComboBoxTransferTo_Division.GetSelectedValue, SearchableComboBoxTransferTo_Product.GetSelectedValue,
                                    SearchableComboBoxTransferTo_Job.GetSelectedValue, SearchableComboBoxTransferTo_JobComponent.GetSelectedValue, SearchableComboBoxTransferTo_Function.GetSelectedValue, AgencyInvoiceTaxFlag,
                                    Nothing, NumericInputTransferTo_Amount.EditValue, TextBoxForm_Comments.GetText, NumericInputTransferTo_QtyHours.EditValue, NumericInputTransferTo_Rate.EditValue)

                            End If

                            DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.BILLING SET ADJUSTMENTS = 1 WHERE BILLING_USER = '{0}'", DbContext.UserCode))

                            DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.JOB_LOG SET CL_CODE = RTRIM(CL_CODE), DIV_CODE = RTRIM(DIV_CODE), PRD_CODE = RTRIM(PRD_CODE) WHERE JOB_NUMBER = {0}", JobComponent.JobNumber))

                            DbTransaction.Commit()

                            Transferred = True

                        Catch ex As Exception
                            DbTransaction.Rollback()
                            ErrorMessage = "Failed trying to save data to the database. Please contact software support."
                            ErrorMessage += vbCrLf & ex.Message
                        Finally

                            If DbContext.Database.Connection.State = ConnectionState.Open Then

                                DbContext.Database.Connection.Close()

                            End If

                            AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                        End Try

                    End If

                End Using

            End If

            Transfer = Transferred

        End Function
        Private Sub LoadEmployeeTimeToTransfer(ByVal DbContext As AdvantageFramework.Database.DbContext)

            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing

            LabelTransferFrom_Item.Text = "Employee:"

            NumericInputTransferTo_QtyHours.SetPropertySettings(AdvantageFramework.Database.Entities.EmployeeTimeDetail.Properties.Hours)

            NumericInputTransferTo_QtyHours.SetRequired(True)
            NumericInputTransferTo_QtyHours.Properties.ReadOnly = False

            NumericInputTransferTo_MarkupPercent.SetPropertySettings(AdvantageFramework.Database.Entities.EmployeeTimeDetail.Properties.CommissionPercentage)

            NumericInputTransferTo_Amount.Properties.ReadOnly = True

            SearchableComboBoxTransferFrom_Item.ControlType = WinForm.Presentation.Controls.SearchableComboBox.Type.Employee
            SearchableComboBoxTransferFrom_Item.DataSource = AdvantageFramework.Database.Procedures.EmployeeView.LoadCore(DbContext).ToList
            SearchableComboBoxTransferFrom_Item.SelectedValue = _EmployeeTimeItem.EmployeeCode

            SearchableComboBoxTransferTo_Function.DataSource = AdvantageFramework.Database.Procedures.Function.LoadCore(DbContext).Where(Function(Entity) Entity.Type = "E" AndAlso (Entity.IsInactive Is Nothing OrElse Entity.IsInactive = 0)).ToList

            NumericInputTransferFrom_QtyHours.EditValue = _EmployeeTimeItem.Hours
            NumericInputTransferFrom_Rate.EditValue = _EmployeeTimeItem.BillableRate
            NumericInputTransferFrom_Amount.EditValue = _EmployeeTimeItem.TotalBill
            NumericInputTransferFrom_VendorTax.EditValue = Nothing
            NumericInputTransferFrom_ResaleTax.EditValue = _EmployeeTimeItem.ResaleTax
            NumericInputTransferFrom_MarkupAmount.EditValue = _EmployeeTimeItem.MarkupAmount
            NumericInputTransferFrom_Total.EditValue = _EmployeeTimeItem.LineTotal

            CheckBoxTransferFrom_Billable.Checked = Not CBool(_EmployeeTimeItem.IsNonBillable.GetValueOrDefault(0))
            LabelTransferFrom_RateFrom.Text = _EmployeeTimeItem.EmployeeRateFrom

            NumericInputTransferFrom_Unbilled.EditValue = _EmployeeTimeItem.TotalBill

            NumericInputTransferFrom_Approved.EditValue = _EmployeeTimeItem.NetApprovedAmount

            Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.TS_TASK_ONLY.ToString)

                If Setting IsNot Nothing Then

                    LabelTransferTo_TaskCode.Visible = CBool(Setting.Value)
                    SearchableComboBoxTransferTo_Task.Visible = CBool(Setting.Value)

                    If CBool(Setting.Value) Then

                        SearchableComboBoxTransferTo_Task.DataSource = AdvantageFramework.Database.Procedures.Task.LoadAllActive(DbContext).ToList
                        SearchableComboBoxTransferTo_Task.SelectedValue = Nothing
                        SearchableComboBoxTransferTo_Task.Properties.ReadOnly = False

                    End If

                End If

            End Using

        End Sub
        Private Sub LoadAPItemToTransfer(ByVal DbContext As AdvantageFramework.Database.DbContext)

            Dim AllActiveAPPostPeriods As Generic.List(Of AdvantageFramework.Database.Entities.PostPeriod) = Nothing
            Dim CurrentAPPostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing

            LabelTransferFrom_Item.Text = "Vendor:"

            LabelTransferFrom_Invoice.Visible = True
            TextBoxTransferFrom_Invoice.Visible = True
            TextBoxTransferFrom_Invoice.Text = _AccountPayableProductionItem.InvoiceNumber

            NumericInputTransferTo_QtyHours.SetPropertySettings(AdvantageFramework.Database.Entities.AccountPayableProduction.Properties.Quantity)

            'NumericInputTransferTo_VendorTax.SetPropertySettings( AdvantageFramework.Database.Entities.AccountPayableProduction.Properties.ExtendedNonResaleTax)
            'NumericInputTransferTo_VendorTax.Properties.MinValue = 0
            'NumericInputTransferTo_VendorTax.Properties.ReadOnly = False
            'NumericInputTransferTo_VendorTax.BackColor = System.Drawing.Color.White

            If _AccountPayableProductionItem.Quantity.GetValueOrDefault(0) = 0 Then

                NumericInputTransferTo_QtyHours.EditValue = Nothing

            Else

                NumericInputTransferTo_QtyHours.EditValue = 0
                NumericInputTransferTo_QtyHours.Properties.ReadOnly = False
                NumericInputTransferTo_QtyHours.BackColor = System.Drawing.Color.White

                NumericInputTransferTo_Rate.EditValue = 0
                NumericInputTransferTo_Rate.Properties.ReadOnly = False
                NumericInputTransferTo_Rate.BackColor = System.Drawing.Color.White

            End If

            NumericInputTransferTo_Rate.EditValue = _AccountPayableProductionItem.Rate

            NumericInputTransferTo_MarkupPercent.SetPropertySettings(AdvantageFramework.Database.Entities.AccountPayableProduction.Properties.CommissionPercent)

            NumericInputTransferTo_Amount.SetPropertySettings(AdvantageFramework.Database.Entities.AccountPayableProduction.Properties.ExtendedAmount)
            NumericInputTransferTo_Amount.Properties.MinValue = -NumericInputTransferTo_Amount.Properties.MaxValue
            NumericInputTransferTo_Amount.SetRequired(True)

            NumericInputTransferTo_MarkupPercent.SetPropertySettings(AdvantageFramework.Database.Entities.AccountPayableProduction.Properties.CommissionPercent)

            SearchableComboBoxTransferFrom_Item.ControlType = WinForm.Presentation.Controls.SearchableComboBox.Type.Vendor
            SearchableComboBoxTransferFrom_Item.DataSource = AdvantageFramework.Database.Procedures.Vendor.LoadCore(DbContext).ToList
            SearchableComboBoxTransferFrom_Item.SelectedValue = _AccountPayableProductionItem.VendorCode

            SearchableComboBoxTransferTo_Function.DataSource = AdvantageFramework.Database.Procedures.Function.LoadCore(DbContext).Where(Function(Entity) Entity.Type = "V" AndAlso (Entity.IsInactive Is Nothing OrElse Entity.IsInactive = 0)).ToList

            If _AccountPayableProductionItem.ExtendedNonResaleTax <> 0 Then

                SearchableComboBoxTransferTo_Tax.SelectedValue = _AccountPayableProductionItem.SalesTaxCode
                SearchableComboBoxTransferTo_Tax.Enabled = False

            End If

            AllActiveAPPostPeriods = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllActiveAPPostPeriods(DbContext).ToList
            SearchableComboBoxTransferTo_PostPeriod.DataSource = AllActiveAPPostPeriods

            CurrentAPPostPeriod = AllActiveAPPostPeriods.Where(Function(PP) PP.APStatus = "C").FirstOrDefault

            If CurrentAPPostPeriod IsNot Nothing Then

                SearchableComboBoxTransferTo_PostPeriod.SelectedValue = CurrentAPPostPeriod.Code

            End If

            LabelTransferTo_GLAccount.Visible = True
            SearchableComboBoxTransferTo_GLAccount.Visible = True
            SearchableComboBoxTransferTo_GLAccount.SetRequired(True)
            SearchableComboBoxTransferTo_GLAccount.ErrorIconAlignment = Windows.Forms.ErrorIconAlignment.MiddleLeft

            LabelTransferTo_PostPeriod.Visible = True
            SearchableComboBoxTransferTo_PostPeriod.Visible = True
            SearchableComboBoxTransferTo_PostPeriod.SetRequired(True)
            SearchableComboBoxTransferTo_PostPeriod.ErrorIconAlignment = Windows.Forms.ErrorIconAlignment.MiddleLeft

            NumericInputTransferFrom_QtyHours.EditValue = _AccountPayableProductionItem.Quantity
            NumericInputTransferFrom_Rate.EditValue = _AccountPayableProductionItem.Rate
            NumericInputTransferFrom_Amount.EditValue = _AccountPayableProductionItem.ExtendedAmount
            NumericInputTransferFrom_VendorTax.EditValue = _AccountPayableProductionItem.ExtendedNonResaleTax
            NumericInputTransferFrom_ResaleTax.EditValue = _AccountPayableProductionItem.ResaleTax
            NumericInputTransferFrom_MarkupAmount.EditValue = _AccountPayableProductionItem.ExtendedMarkupAmount
            NumericInputTransferFrom_Total.EditValue = _AccountPayableProductionItem.LineTotal
            CheckBoxTransferFrom_Billable.Checked = Not CBool(_AccountPayableProductionItem.IsNonBillable.GetValueOrDefault(0))

            NumericInputTransferFrom_Unbilled.EditValue = _AccountPayableProductionItem.ExtendedAmount

            NumericInputTransferFrom_Approved.EditValue = _AccountPayableProductionItem.NetApprovedAmount

        End Sub
        Private Sub LoadIncomeOnlyItemToTransfer(ByVal DbContext As AdvantageFramework.Database.DbContext, BCCDbContext As AdvantageFramework.BillingCommandCenter.Database.DbContext)

            SearchableComboBoxTransferFrom_Item.Visible = False

            TextBoxTransferFrom_Description.Text = _IncomeOnlyItem.Description
            LabelTransferFrom_Item.Text = "Description:"

            LabelTransferFrom_Invoice.Visible = True
            TextBoxTransferFrom_Invoice.Visible = True
            TextBoxTransferFrom_Invoice.Text = _IncomeOnlyItem.InvoiceNumber

            NumericInputTransferTo_QtyHours.SetPropertySettings(AdvantageFramework.Database.Entities.IncomeOnly.Properties.Quantity)

            If _IncomeOnlyItem.Quantity.GetValueOrDefault(0) = 0 Then

                NumericInputTransferTo_QtyHours.EditValue = Nothing

            Else

                NumericInputTransferTo_QtyHours.EditValue = 0
                NumericInputTransferTo_QtyHours.Properties.ReadOnly = False
                NumericInputTransferTo_QtyHours.BackColor = System.Drawing.Color.White

                NumericInputTransferTo_Rate.EditValue = 0
                NumericInputTransferTo_Rate.Properties.ReadOnly = False
                NumericInputTransferTo_Rate.BackColor = System.Drawing.Color.White

            End If

            NumericInputTransferTo_Rate.EditValue = _IncomeOnlyItem.Rate

            NumericInputTransferTo_MarkupPercent.SetPropertySettings(AdvantageFramework.Database.Entities.IncomeOnly.Properties.CommissionPercent)

            NumericInputTransferTo_Amount.SetPropertySettings(AdvantageFramework.Database.Entities.IncomeOnly.Properties.Amount)
            NumericInputTransferTo_Amount.Properties.MinValue = -NumericInputTransferTo_Amount.Properties.MaxValue
            NumericInputTransferTo_Amount.SetRequired(True)

            NumericInputTransferTo_MarkupPercent.SetPropertySettings(AdvantageFramework.Database.Entities.IncomeOnly.Properties.CommissionPercent)

            SearchableComboBoxTransferTo_Function.DataSource = AdvantageFramework.Database.Procedures.Function.LoadCore(DbContext).Where(Function(Entity) Entity.Type = "I" AndAlso (Entity.IsInactive Is Nothing OrElse Entity.IsInactive = 0)).ToList

            NumericInputTransferFrom_QtyHours.EditValue = _IncomeOnlyItem.Quantity
            NumericInputTransferFrom_Rate.EditValue = _IncomeOnlyItem.Rate
            NumericInputTransferFrom_Amount.EditValue = _IncomeOnlyItem.Amount
            NumericInputTransferFrom_VendorTax.EditValue = Nothing
            NumericInputTransferFrom_ResaleTax.EditValue = _IncomeOnlyItem.TotalTax
            NumericInputTransferFrom_MarkupAmount.EditValue = _IncomeOnlyItem.MarkupAmount
            NumericInputTransferFrom_Total.EditValue = _IncomeOnlyItem.LineTotal
            CheckBoxTransferFrom_Billable.Checked = Not _IncomeOnlyItem.IsNonBillable

            NumericInputTransferFrom_Unbilled.EditValue = _IncomeOnlyItem.Amount

            NumericInputTransferFrom_Approved.EditValue = _IncomeOnlyItem.NetApprovedAmount

        End Sub
        Private Sub APCalculateQuantityRateAndAmount(ByVal FieldChanged As AdvantageFramework.BillingSystem.QtyRateAmount)

            Dim AccountPayableProductionDistributionDetail As AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail = Nothing

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                AccountPayableProductionDistributionDetail = New AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail(Session)

                AccountPayableProductionDistributionDetail.FunctionCode = SearchableComboBoxTransferTo_Function.GetSelectedValue

                AccountPayableProductionDistributionDetail.Quantity = NumericInputTransferTo_QtyHours.EditValue
                AccountPayableProductionDistributionDetail.Rate = NumericInputTransferTo_Rate.EditValue
                AccountPayableProductionDistributionDetail.ExtendedAmount = NumericInputTransferTo_Amount.EditValue

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.CalculateQuantityRateAndAmount(FieldChanged, AccountPayableProductionDistributionDetail, DbContext)

                    Me.FormAction = WinForm.Presentation.FormActions.Modifying

                    NumericInputTransferTo_QtyHours.EditValue = AccountPayableProductionDistributionDetail.Quantity
                    NumericInputTransferTo_Rate.EditValue = AccountPayableProductionDistributionDetail.Rate
                    NumericInputTransferTo_Amount.EditValue = AccountPayableProductionDistributionDetail.ExtendedAmount

                    Me.FormAction = WinForm.Presentation.FormActions.None

                End Using

            End If

        End Sub
        Private Sub IncomeOnlyCalculateQuantityRateAndAmount(ByVal FieldChanged As AdvantageFramework.BillingSystem.QtyRateAmount)

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                _IncomeOnlyItem.Quantity = NumericInputTransferTo_QtyHours.EditValue
                _IncomeOnlyItem.Rate = NumericInputTransferTo_Rate.EditValue
                _IncomeOnlyItem.Amount = NumericInputTransferTo_Amount.EditValue

                AdvantageFramework.BillingSystem.CalculateQuantityRateAndAmount(_IncomeOnlyItem.Quantity, _IncomeOnlyItem.Rate, _IncomeOnlyItem.Amount, FieldChanged, 2)

                Me.FormAction = WinForm.Presentation.FormActions.Modifying

                NumericInputTransferTo_QtyHours.EditValue = _IncomeOnlyItem.Quantity
                NumericInputTransferTo_Rate.EditValue = _IncomeOnlyItem.Rate
                NumericInputTransferTo_Amount.EditValue = _IncomeOnlyItem.Amount

                Me.FormAction = WinForm.Presentation.FormActions.None

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal TransferItem As AdvantageFramework.BaseClasses.BaseClass, ByVal BillingCommandCenterID As Integer) As Windows.Forms.DialogResult

            'objects
            Dim TransferItemDetailDialog As AdvantageFramework.Billing.Presentation.TransferItemDetailDialog = Nothing

            TransferItemDetailDialog = New AdvantageFramework.Billing.Presentation.TransferItemDetailDialog(TransferItem, BillingCommandCenterID)

            ShowFormDialog = TransferItemDetailDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub TransferItemDetailDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim JobNumber As Integer = Nothing
            Dim JobComponentNumber As Short = Nothing
            Dim FunctionCode As String = Nothing
            Dim Job As AdvantageFramework.Database.Entities.Job = Nothing
            Dim BillingCommandCenter As AdvantageFramework.BillingCommandCenter.Database.Entities.BillingCommandCenter = Nothing

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            CheckBoxTransferFrom_Billable.CheckBoxImageChecked = AdvantageFramework.My.Resources.SmallGreenCircleImage
            CheckBoxTransferFrom_Billable.CheckBoxImageUnChecked = AdvantageFramework.My.Resources.SmallRedCircleImage

            CheckBoxTransferTo_Billable.CheckBoxImageChecked = AdvantageFramework.My.Resources.SmallGreenCircleImage
            CheckBoxTransferTo_Billable.CheckBoxImageUnChecked = AdvantageFramework.My.Resources.SmallRedCircleImage

            GroupBoxForm_EmployeeTimeBillingRate.Enabled = False
            LabelTransferFrom_RateFrom.Visible = False
            LabelTransferTo_RateFrom.Visible = False

            If _EmployeeTimeItem IsNot Nothing Then

                JobNumber = _EmployeeTimeItem.JobNumber
                JobComponentNumber = _EmployeeTimeItem.JobComponentNumber
                FunctionCode = _EmployeeTimeItem.FunctionCode

                GroupBoxForm_EmployeeTimeBillingRate.Enabled = True
                LabelTransferFrom_RateFrom.Visible = True
                LabelTransferTo_RateFrom.Visible = True

            ElseIf _AccountPayableProductionItem IsNot Nothing Then

                JobNumber = _AccountPayableProductionItem.JobNumber
                JobComponentNumber = _AccountPayableProductionItem.JobComponentNumber
                FunctionCode = _AccountPayableProductionItem.FunctionCode

            ElseIf _IncomeOnlyItem IsNot Nothing Then

                JobNumber = _IncomeOnlyItem.JobNumber
                JobComponentNumber = _IncomeOnlyItem.JobComponentNumber
                FunctionCode = _IncomeOnlyItem.FunctionCode

            End If

            SearchableComboBoxTransferTo_Job.SetRequired(True)
            SearchableComboBoxTransferTo_Job.ErrorIconAlignment = Windows.Forms.ErrorIconAlignment.MiddleLeft

            SearchableComboBoxTransferTo_JobComponent.SetRequired(True)
            SearchableComboBoxTransferTo_JobComponent.ErrorIconAlignment = Windows.Forms.ErrorIconAlignment.MiddleLeft

            SearchableComboBoxTransferTo_Function.SetRequired(True)
            SearchableComboBoxTransferTo_Function.ErrorIconAlignment = Windows.Forms.ErrorIconAlignment.MiddleLeft

            Using BCCDbContext As New AdvantageFramework.BillingCommandCenter.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    BillingCommandCenter = AdvantageFramework.BillingCommandCenter.Database.Procedures.BillingCommandCenter.LoadByID(BCCDbContext, _BillingCommandCenterID)

                    If BillingCommandCenter IsNot Nothing Then

                        _BillingUser = BillingCommandCenter.BillingUser

                    End If

                    Job = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, JobNumber)

                    If Job IsNot Nothing Then

                        SearchableComboBoxTransferFrom_Client.DataSource = AdvantageFramework.Database.Procedures.Client.LoadCore(DbContext).ToList
                        SearchableComboBoxTransferFrom_Client.SelectedValue = Job.ClientCode

                        SearchableComboBoxTransferFrom_Division.DataSource = AdvantageFramework.Database.Procedures.Division.LoadByClientCode(DbContext, Job.ClientCode).ToList
                        SearchableComboBoxTransferFrom_Division.SelectedValue = Job.DivisionCode

                        SearchableComboBoxTransferFrom_Product.DataSource = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionCode(DbContext, Job.ClientCode, Job.DivisionCode).ToList
                        SearchableComboBoxTransferFrom_Product.SelectedValue = Job.ProductCode

                    End If

                    SearchableComboBoxTransferFrom_Job.DataSource = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, JobNumber)
                    SearchableComboBoxTransferFrom_Job.SelectedValue = JobNumber

                    SearchableComboBoxTransferFrom_JobComponent.DataSource = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, JobNumber, JobComponentNumber)
                    SearchableComboBoxTransferFrom_JobComponent.SelectedValue = JobComponentNumber

                    SearchableComboBoxTransferFrom_Function.DataSource = AdvantageFramework.Database.Procedures.Function.LoadCore(DbContext).ToList
                    SearchableComboBoxTransferFrom_Function.SelectedValue = FunctionCode

                    SearchableComboBoxTransferTo_Client.DataSource = AdvantageFramework.Database.Procedures.Client.Load(DbContext).ToList

                    If AdvantageFramework.Database.Procedures.Agency.InvoiceTaxFlag(DbContext) = True Then

                        SearchableComboBoxTransferTo_Tax.Enabled = False

                    Else

                        SearchableComboBoxTransferTo_Tax.DataSource = (From Entity In AdvantageFramework.Database.Procedures.SalesTax.LoadAllActive(DbContext)
                                                                       Select Entity.TaxCode,
                                                                              Entity.Description).ToList

                    End If

                    If _IncomeOnlyItem IsNot Nothing Then

                        LoadIncomeOnlyItemToTransfer(DbContext, BCCDbContext)

                    End If

                    If _EmployeeTimeItem IsNot Nothing Then

                        LoadEmployeeTimeToTransfer(DbContext)

                    End If

                    If _AccountPayableProductionItem IsNot Nothing Then

                        LoadAPItemToTransfer(DbContext)

                    End If

                End Using

            End Using

            Me.ShowUnsavedChangesOnFormClosing = False

            Me.FormAction = WinForm.Presentation.FormActions.None

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            'objects
            Dim ErrorMessage As String = Nothing

            If Me.Validator AndAlso AmountIsValid(ErrorMessage) AndAlso QuantityIsValid(ErrorMessage) Then

                If Transfer(ErrorMessage) Then

                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    Me.Close()

                Else

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub SearchableComboBoxTransferTo_JobComponent_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxTransferTo_JobComponent.EditValueChanged

            'objects
            Dim JobNumber As Integer = Nothing
            Dim JobComponentNumber As Short = Nothing
            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing

            If SearchableComboBoxTransferTo_Job.HasASelectedValue AndAlso SearchableComboBoxTransferTo_JobComponent.HasASelectedValue Then

                JobNumber = SearchableComboBoxTransferTo_Job.GetSelectedValue()
                JobComponentNumber = SearchableComboBoxTransferTo_JobComponent.GetSelectedValue()

                If SearchableComboBoxTransferTo_Function.HasASelectedValue = False Then

                    SearchableComboBoxTransferTo_Function.SelectedValue = SearchableComboBoxTransferFrom_Function.GetSelectedValue

                End If

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, JobNumber, JobComponentNumber)

                    If JobComponent IsNot Nothing Then

                        SetBillingRate(DbContext)

                    End If

                End Using

                Recalculate()

            End If

        End Sub
        Private Sub SearchableComboBoxTransferTo_JobComponent_Popup(sender As Object, e As EventArgs) Handles SearchableComboBoxTransferTo_JobComponent.Popup

            If DirectCast(sender, DevExpress.XtraEditors.SearchLookUpEdit).Properties.View.Columns(AdvantageFramework.Database.Entities.JobComponent.Properties.JobNumber.ToString) IsNot Nothing Then

                DirectCast(sender, DevExpress.XtraEditors.SearchLookUpEdit).Properties.View.Columns(AdvantageFramework.Database.Entities.JobComponent.Properties.JobNumber.ToString).Visible = False
                DirectCast(sender, DevExpress.XtraEditors.SearchLookUpEdit).Properties.View.OptionsFind.FindFilterColumns = AdvantageFramework.Database.Entities.JobComponent.Properties.Number.ToString

            End If

        End Sub
        Private Sub SearchableComboBoxTransferTo_JobComponent_QueryPopupNeedDataSource(ByRef DataSourceSet As Boolean) Handles SearchableComboBoxTransferTo_JobComponent.QueryPopupNeedDataSource

            'objects
            Dim JobNumber As Integer = 0

            If SearchableComboBoxTransferTo_Job.HasASelectedValue Then

                JobNumber = SearchableComboBoxTransferTo_Job.GetSelectedValue

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    SearchableComboBoxTransferTo_JobComponent.DataSource = (From JC In AdvantageFramework.Database.Procedures.JobComponent.LoadAllOpen(DbContext)
                                                                            Where JC.JobNumber = JobNumber AndAlso
                                                                                  (JC.IsAdvanceBilling Is Nothing OrElse JC.IsAdvanceBilling = 0 OrElse JC.IsAdvanceBilling = 2) AndAlso
                                                                                  (JC.BillingUserCode Is Nothing OrElse JC.BillingUserCode = _BillingUser)
                                                                            Select JC).ToList

                End Using

                DataSourceSet = True

            End If

        End Sub
        Private Sub SearchableComboBoxTransferTo_Division_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxTransferTo_Division.EditValueChanged

            'objects
            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim Products As IEnumerable(Of AdvantageFramework.Database.Entities.Product) = Nothing

            If Me.FormAction <> WinForm.Presentation.FormActions.LoadingSelectedItem Then

                SearchableComboBoxTransferTo_Job.DataSource = Nothing
                SearchableComboBoxTransferTo_Job.SelectedValue = Nothing

            End If

            If SearchableComboBoxTransferTo_Client.HasASelectedValue AndAlso SearchableComboBoxTransferTo_Division.HasASelectedValue Then

                ClientCode = SearchableComboBoxTransferTo_Client.GetSelectedValue.ToString.Trim
                DivisionCode = SearchableComboBoxTransferTo_Division.GetSelectedValue.ToString.Trim

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Products = (From Entity In AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionCode(DbContext, ClientCode, DivisionCode)
                                Select Entity).ToList

                    SearchableComboBoxTransferTo_Product.DataSource = Products

                    If Products.Count = 1 Then

                        SearchableComboBoxTransferTo_Product.SelectedValue = Products(0).Code.Trim

                    Else

                        SearchableComboBoxTransferTo_Product.SelectedValue = Nothing

                    End If

                End Using

            Else

                SearchableComboBoxTransferTo_Product.SelectedValue = Nothing
                SearchableComboBoxTransferTo_Job.SelectedValue = Nothing
                SearchableComboBoxTransferTo_JobComponent.SelectedValue = Nothing
                SearchableComboBoxTransferTo_Function.SelectedValue = Nothing
                SearchableComboBoxTransferTo_Tax.SelectedValue = Nothing

            End If

        End Sub
        Private Sub SearchableComboBoxTransferTo_Division_QueryPopupNeedDataSource(ByRef DataSourceSet As Boolean) Handles SearchableComboBoxTransferTo_Division.QueryPopupNeedDataSource

            If SearchableComboBoxTransferTo_Client.HasASelectedValue Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    SearchableComboBoxTransferTo_Division.DataSource = AdvantageFramework.Database.Procedures.Division.LoadByClientCode(DbContext, SearchableComboBoxTransferTo_Client.GetSelectedValue).ToList

                End Using

                DataSourceSet = True

            End If

        End Sub
        Private Sub SearchableComboBoxTransferTo_Product_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxTransferTo_Product.EditValueChanged

            If Me.FormAction <> WinForm.Presentation.FormActions.LoadingSelectedItem Then

                SearchableComboBoxTransferTo_Job.DataSource = Nothing
                SearchableComboBoxTransferTo_Job.SelectedValue = Nothing

            End If

            If SearchableComboBoxTransferTo_Product.EditValue Is Nothing Then

                SearchableComboBoxTransferTo_Job.SelectedValue = Nothing
                SearchableComboBoxTransferTo_JobComponent.SelectedValue = Nothing
                SearchableComboBoxTransferTo_Function.SelectedValue = Nothing
                SearchableComboBoxTransferTo_Tax.SelectedValue = Nothing

            End If

        End Sub
        Private Sub SearchableComboBoxTransferTo_Product_QueryPopupNeedDataSource(ByRef DataSourceSet As Boolean) Handles SearchableComboBoxTransferTo_Product.QueryPopupNeedDataSource

            If SearchableComboBoxTransferTo_Client.HasASelectedValue AndAlso SearchableComboBoxTransferTo_Division.HasASelectedValue Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    SearchableComboBoxTransferTo_Product.DataSource = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionCode(DbContext, SearchableComboBoxTransferTo_Client.SelectedValue, SearchableComboBoxTransferTo_Division.SelectedValue)

                End Using

                DataSourceSet = True

            End If

        End Sub
        Private Sub SearchableComboBoxTransferTo_Job_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxTransferTo_Job.EditValueChanged

            'objects
            Dim Job As AdvantageFramework.Database.Entities.Job = Nothing
            Dim JobComponents As Generic.List(Of AdvantageFramework.Database.Entities.JobComponent) = Nothing

            If SearchableComboBoxTransferTo_Job.HasASelectedValue Then

                Me.FormAction = WinForm.Presentation.FormActions.LoadingSelectedItem

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Job = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, SearchableComboBoxTransferTo_Job.GetSelectedValue)

                    If Job IsNot Nothing Then

                        SearchableComboBoxTransferTo_Client.SelectedValue = Job.ClientCode.Trim
                        SearchableComboBoxTransferTo_Division.SelectedValue = Job.DivisionCode.Trim
                        SearchableComboBoxTransferTo_Product.SelectedValue = Job.ProductCode.Trim

                        JobComponents = Job.JobComponents.Where(Function(Entity) Entity.JobProcessNumber <> 6 AndAlso Entity.JobProcessNumber <> 12 AndAlso
                                                    (Entity.IsAdvanceBilling Is Nothing OrElse Entity.IsAdvanceBilling = 0 OrElse Entity.IsAdvanceBilling = 2) AndAlso
                                                    (Entity.BillingUserCode Is Nothing OrElse Entity.BillingUserCode = _BillingUser)).ToList

                        SearchableComboBoxTransferTo_JobComponent.DataSource = JobComponents

                        If JobComponents.Count = 1 Then

                            SearchableComboBoxTransferTo_JobComponent.SelectedValue = JobComponents(0).Number

                        End If

                    End If

                End Using

                Me.FormAction = WinForm.Presentation.FormActions.None

            End If

        End Sub
        Private Sub SearchableComboBoxTransferTo_Job_MouseDown(sender As Object, e As Windows.Forms.MouseEventArgs) Handles SearchableComboBoxTransferTo_Job.MouseDown

            SearchableComboBoxTransferTo_Job.DataSource = Nothing

        End Sub
        Private Sub SearchableComboBoxTransferTo_Job_QueryPopupNeedDataSource(ByRef DataSourceSet As Boolean) Handles SearchableComboBoxTransferTo_Job.QueryPopupNeedDataSource

            'objects
            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim ProductCode As String = Nothing

            ClientCode = SearchableComboBoxTransferTo_Client.GetSelectedValue
            DivisionCode = SearchableComboBoxTransferTo_Division.GetSelectedValue
            ProductCode = SearchableComboBoxTransferTo_Product.GetSelectedValue

            SearchableComboBoxTransferTo_Job.DataSource = AdvantageFramework.Billing.Presentation.GetTransferToJobList(Session, _BillingUser, ClientCode, DivisionCode, ProductCode)

        End Sub
        Private Sub SearchableComboBoxTransferTo_Client_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxTransferTo_Client.EditValueChanged

            'objects
            Dim ClientCode As String = Nothing
            Dim Divisions As IEnumerable(Of AdvantageFramework.Database.Entities.Division) = Nothing

            If Me.FormAction <> WinForm.Presentation.FormActions.LoadingSelectedItem Then

                SearchableComboBoxTransferTo_Job.DataSource = Nothing
                SearchableComboBoxTransferTo_Job.SelectedValue = Nothing

                SearchableComboBoxTransferTo_JobComponent.DataSource = Nothing
                SearchableComboBoxTransferTo_JobComponent.SelectedValue = Nothing

            End If

            If SearchableComboBoxTransferTo_Client.HasASelectedValue Then

                ClientCode = SearchableComboBoxTransferTo_Client.GetSelectedValue.ToString.Trim

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Divisions = (From Entity In AdvantageFramework.Database.Procedures.Division.LoadByClientCode(DbContext, ClientCode)
                                 Select Entity).ToList

                    SearchableComboBoxTransferTo_Division.DataSource = Divisions

                    If Divisions.Count = 1 Then

                        SearchableComboBoxTransferTo_Division.SelectedValue = Divisions(0).Code.Trim

                    Else

                        SearchableComboBoxTransferTo_Division.SelectedValue = Nothing

                    End If

                End Using

            Else

                SearchableComboBoxTransferTo_Division.SelectedValue = Nothing
                SearchableComboBoxTransferTo_Product.SelectedValue = Nothing
                SearchableComboBoxTransferTo_Job.SelectedValue = Nothing
                SearchableComboBoxTransferTo_JobComponent.SelectedValue = Nothing
                SearchableComboBoxTransferTo_Tax.SelectedValue = Nothing

            End If

        End Sub
        Private Sub NumericInputTransferTo_Amount_EditValueChanged(sender As Object, e As EventArgs) Handles NumericInputTransferTo_Amount.EditValueChanged

            If _AccountPayableProductionItem IsNot Nothing Then

                APCalculateQuantityRateAndAmount(BillingSystem.QtyRateAmount.Amount)

            ElseIf _IncomeOnlyItem IsNot Nothing Then

                IncomeOnlyCalculateQuantityRateAndAmount(BillingSystem.QtyRateAmount.Amount)

            End If

        End Sub
        'Private Sub NumericInputTransferTo_Amount_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles NumericInputTransferTo_Amount.KeyPress

        '    If e.KeyChar = "-" Then

        '        e.Handled = True

        '    End If

        'End Sub
        Private Sub NumericInputTransferTo_Amount_Validating(sender As Object, e As ComponentModel.CancelEventArgs) Handles NumericInputTransferTo_Amount.Validating

            Recalculate()

        End Sub
        Private Sub NumericInputTransferTo_MarkupAmount_EditValueChanged(sender As Object, e As EventArgs) Handles NumericInputTransferTo_MarkupAmount.EditValueChanged

            If NumericInputTransferTo_Amount.EditValue <> 0 Then

                NumericInputTransferTo_MarkupPercent.EditValue = FormatNumber(NumericInputTransferTo_MarkupAmount.EditValue * 100 /
                                                                              NumericInputTransferTo_Amount.EditValue, 3)

            End If

        End Sub
        Private Sub NumericInputTransferTo_MarkupAmount_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles NumericInputTransferTo_MarkupAmount.KeyPress

            If e.KeyChar = "-" Then

                e.Handled = True

            End If

        End Sub
        Private Sub NumericInputTransferTo_MarkupPercent_EditValueChanged(sender As Object, e As EventArgs) Handles NumericInputTransferTo_MarkupPercent.EditValueChanged

            Recalculate()

        End Sub
        Private Sub NumericInputTransferTo_MarkupPercent_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles NumericInputTransferTo_MarkupPercent.KeyPress

            If e.KeyChar = "-" Then

                e.Handled = True

            End If

        End Sub
        Private Sub NumericInputTransferTo_QtyHours_EditValueChanged(sender As Object, e As EventArgs) Handles NumericInputTransferTo_QtyHours.EditValueChanged

            If _AccountPayableProductionItem IsNot Nothing Then

                If NumericInputTransferTo_QtyHours.EditValue = 0 Then

                    NumericInputTransferTo_QtyHours.EditValue = Nothing
                    NumericInputTransferTo_Rate.EditValue = Nothing

                End If

                APCalculateQuantityRateAndAmount(BillingSystem.QtyRateAmount.Quantity)

            ElseIf _IncomeOnlyItem IsNot Nothing Then

                If NumericInputTransferTo_QtyHours.EditValue = 0 Then

                    NumericInputTransferTo_QtyHours.EditValue = Nothing
                    NumericInputTransferTo_Rate.EditValue = Nothing

                End If

                IncomeOnlyCalculateQuantityRateAndAmount(BillingSystem.QtyRateAmount.Quantity)

            End If

        End Sub
        'Private Sub NumericInputTransferTo_QtyHours_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles NumericInputTransferTo_QtyHours.KeyPress

        '    If e.KeyChar = "-" Then

        '        e.Handled = True

        '    End If

        'End Sub
        Private Sub NumericInputTransferTo_QtyHours_Validating(sender As Object, e As ComponentModel.CancelEventArgs) Handles NumericInputTransferTo_QtyHours.Validating

            Recalculate()

        End Sub
        Private Sub NumericInputTransferTo_Rate_EditValueChanged(sender As Object, e As EventArgs) Handles NumericInputTransferTo_Rate.EditValueChanged

            If _AccountPayableProductionItem IsNot Nothing Then

                If NumericInputTransferTo_Rate.EditValue = 0 Then

                    NumericInputTransferTo_Rate.EditValue = Nothing
                    NumericInputTransferTo_QtyHours.EditValue = Nothing

                End If

                APCalculateQuantityRateAndAmount(BillingSystem.QtyRateAmount.Rate)

            ElseIf _IncomeOnlyItem IsNot Nothing Then

                If NumericInputTransferTo_Rate.EditValue = 0 Then

                    NumericInputTransferTo_Rate.EditValue = Nothing
                    NumericInputTransferTo_QtyHours.EditValue = Nothing

                End If

                IncomeOnlyCalculateQuantityRateAndAmount(BillingSystem.QtyRateAmount.Rate)

            End If

        End Sub
        'Private Sub NumericInputTransferTo_VendorTax_EditValueChanged(sender As Object, e As EventArgs) Handles NumericInputTransferTo_VendorTax.EditValueChanged

        '    NumericInputTransferTo_Total.EditValue = FormatNumber(NumericInputTransferTo_Amount.EditValue + NumericInputTransferTo_VendorTax.EditValue + _
        '                                                          NumericInputTransferTo_ResaleTax.EditValue + NumericInputTransferTo_MarkupAmount.EditValue, 2)

        'End Sub
        'Private Sub NumericInputTransferTo_VendorTax_Validating(sender As Object, e As ComponentModel.CancelEventArgs) Handles NumericInputTransferTo_VendorTax.Validating

        '    'objects
        '    Dim ErrorMessage As String = Nothing

        '    NumericInputTransferTo_VendorTax.ErrorText = Nothing

        '    If Not VendorTaxIsValid(ErrorMessage) Then

        '        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage, WinForm.MessageBox.MessageBoxButtons.OK, , Windows.Forms.MessageBoxIcon.Stop)

        '        NumericInputTransferTo_VendorTax.ErrorText = ErrorMessage

        '        e.Cancel = True

        '    Else

        '        Recalculate(True)

        '    End If

        'End Sub
        Private Sub SearchableComboBoxTransferTo_Tax_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxTransferTo_Tax.EditValueChanged

            Recalculate()

        End Sub
        Private Sub SearchableComboBoxTransferTo_Function_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxTransferTo_Function.EditValueChanged

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                SetBillingRate(DbContext)

                Recalculate()

            End Using

        End Sub
        Private Sub RadioButtonMarkup_RecalculateFromHierarchy_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonMarkup_RecalculateFromHierarchy.CheckedChanged

            If RadioButtonMarkup_RecalculateFromHierarchy.Checked Then

                NumericInputTransferTo_MarkupPercent.EditValue = If(_BillingRate IsNot Nothing, _BillingRate.COMM.GetValueOrDefault(0), 0)

            Else

                If _AccountPayableProductionItem IsNot Nothing Then

                    NumericInputTransferTo_MarkupPercent.EditValue = _AccountPayableProductionItem.CommissionPercent

                ElseIf _IncomeOnlyItem IsNot Nothing Then

                    NumericInputTransferTo_MarkupPercent.EditValue = _IncomeOnlyItem.CommissionPercent

                ElseIf _EmployeeTimeItem IsNot Nothing Then

                    NumericInputTransferTo_MarkupPercent.EditValue = _EmployeeTimeItem.CommissionPercentage

                End If

            End If

            Recalculate()

        End Sub
        Private Sub RadioButtonTime_RecalculateFromHierarchy_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonTime_RecalculateFromHierarchy.CheckedChanged

            If _EmployeeTimeItem IsNot Nothing Then

                If RadioButtonTime_RecalculateFromHierarchy.Checked Then

                    If _BillingRate IsNot Nothing Then

                        NumericInputTransferTo_Rate.EditValue = _BillingRate.BILLING_RATE.GetValueOrDefault(0)
                        LabelTransferTo_RateFrom.Text = LabelTransferTo_RateFrom.Tag

                    Else

                        NumericInputTransferTo_Rate.EditValue = 0
                        LabelTransferTo_RateFrom.Text = Nothing

                    End If

                Else

                    NumericInputTransferTo_Rate.EditValue = _EmployeeTimeItem.BillableRate

                    LabelTransferTo_RateFrom.Text = _EmployeeTimeItem.EmployeeRateFrom

                End If

            End If

            Recalculate()

        End Sub

#End Region

#End Region

    End Class

End Namespace
