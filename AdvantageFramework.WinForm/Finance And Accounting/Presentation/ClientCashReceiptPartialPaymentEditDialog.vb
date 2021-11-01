Namespace FinanceAndAccounting.Presentation

    Public Class ClientCashReceiptPartialPaymentEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _ClientCashReceiptPaymentDetailList As Generic.List(Of AdvantageFramework.CashReceipts.Classes.ClientCashReceiptPaymentDetail) = Nothing
        Private _BalanceToAmount As Nullable(Of Decimal) = Nothing
        Private _CurrentBalance As Decimal = Nothing

#End Region

#Region " Properties "

        Public ReadOnly Property ClientCashReceiptPaymentDetailList As Generic.List(Of AdvantageFramework.CashReceipts.Classes.ClientCashReceiptPaymentDetail)
            Get
                ClientCashReceiptPaymentDetailList = _ClientCashReceiptPaymentDetailList
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal ClientCashReceiptPaymentDetailList As Generic.List(Of AdvantageFramework.CashReceipts.Classes.ClientCashReceiptPaymentDetail),
                        ByVal BalanceToAmount As Nullable(Of Decimal),
                        ByVal CurrentBalance As Decimal)

            ' This call is required by the designer.
            InitializeComponent()

            _ClientCashReceiptPaymentDetailList = ClientCashReceiptPaymentDetailList
            _BalanceToAmount = BalanceToAmount
            _CurrentBalance = CurrentBalance

        End Sub
        Private Sub LoadGrid()

            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            DataGridViewPanel_PaymentDetail.DataSource = _ClientCashReceiptPaymentDetailList

            For Each GridColumn In DataGridViewPanel_PaymentDetail.Columns

                If GridColumn.FieldName <> AdvantageFramework.CashReceipts.Classes.ClientCashReceiptPaymentDetail.Properties.PaymentAmount.ToString Then

                    GridColumn.OptionsColumn.AllowFocus = False

                End If

            Next

            DataGridViewPanel_PaymentDetail.CurrentView.BestFitColumns()

        End Sub
        Private Sub EnableOrDisableActions()

            'objects
            Dim ClientCashReceiptPaymentDetailList As Generic.List(Of AdvantageFramework.CashReceipts.Classes.ClientCashReceiptPaymentDetail) = Nothing
            Dim PaymentSum As Decimal = Nothing

            ClientCashReceiptPaymentDetailList = DataGridViewPanel_PaymentDetail.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.CashReceipts.Classes.ClientCashReceiptPaymentDetail)().ToList

            PaymentSum = ClientCashReceiptPaymentDetailList.Sum(Function(CCRPD) CCRPD.PaymentAmount.GetValueOrDefault(0))

            If _BalanceToAmount IsNot Nothing Then

                NumericInputPanel_Remaining.Value = _BalanceToAmount - PaymentSum

                ButtonItemActions_Save.Enabled = DataGridViewPanel_PaymentDetail.UserEntryChanged AndAlso (PaymentSum = _BalanceToAmount)

            Else

                ButtonItemActions_Save.Enabled = DataGridViewPanel_PaymentDetail.UserEntryChanged AndAlso (PaymentSum <= _CurrentBalance)

            End If

        End Sub
        Private Function ValidateForm(ByRef ErrorText As String) As Boolean

            Dim IsValid As Boolean = True
            Dim TotalPayments As Decimal = Nothing

            DataGridViewPanel_PaymentDetail.CurrentView.CloseEditorForUpdating()

            TotalPayments = DataGridViewPanel_PaymentDetail.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.CashReceipts.Classes.ClientCashReceiptPaymentDetail)().ToList.Sum(Function(CCRPD) CCRPD.PaymentAmount.GetValueOrDefault(0))

            If _BalanceToAmount IsNot Nothing Then

                If TotalPayments > _BalanceToAmount Then

                    ErrorText = "Total payments exceed balance to payment amount."

                    IsValid = False

                End If

            ElseIf TotalPayments > _CurrentBalance Then

                ErrorText = "Total payments exceed current balance."

                IsValid = False

            End If

            ValidateForm = IsValid

        End Function

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal ClientCashReceiptPaymentDetailList As Generic.List(Of AdvantageFramework.CashReceipts.Classes.ClientCashReceiptPaymentDetail),
                                              ByVal PaymentAmount As Nullable(Of Decimal),
                                              ByVal CurrentBalance As Decimal) As System.Windows.Forms.DialogResult

            'objects
            Dim ClientCashReceiptPartialPaymentEditDialog As AdvantageFramework.FinanceAndAccounting.Presentation.ClientCashReceiptPartialPaymentEditDialog = Nothing

            ClientCashReceiptPartialPaymentEditDialog = New AdvantageFramework.FinanceAndAccounting.Presentation.ClientCashReceiptPartialPaymentEditDialog(ClientCashReceiptPaymentDetailList, PaymentAmount, CurrentBalance)

            ShowFormDialog = ClientCashReceiptPartialPaymentEditDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                ClientCashReceiptPaymentDetailList = ClientCashReceiptPartialPaymentEditDialog.ClientCashReceiptPaymentDetailList

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub ClientCashReceiptPartialPaymentEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage

            ButtonItemPayment_Apply.Image = AdvantageFramework.My.Resources.CheckAttachImage
            ButtonItemPayment_Undo.Image = AdvantageFramework.My.Resources.UndoImage

            NumericInputPanel_BalanceToPaymentAmount.ByPassUserEntryChanged = True
            NumericInputPanel_Remaining.ByPassUserEntryChanged = True

            LoadGrid()

            LabelItemBalance_CurrentBalance.Text = FormatNumber(_CurrentBalance, 2)

            If _BalanceToAmount Is Nothing Then

                DataGridViewPanel_PaymentDetail.Dock = Windows.Forms.DockStyle.Fill

                LabelPanel_BalanceToPaymentAmount.Visible = False
                LabelPanel_Remaining.Visible = False

                NumericInputPanel_BalanceToPaymentAmount.Visible = False
                NumericInputPanel_Remaining.Visible = False

            Else

                NumericInputPanel_BalanceToPaymentAmount.Value = _BalanceToAmount

            End If

            Me.ClearChanged()

        End Sub
        Private Sub ClientCashReceiptPartialPaymentEditDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            EnableOrDisableActions()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ButtonItemActions_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim ErrorMessage As String = ""

            If ValidateForm(ErrorMessage) Then

                _ClientCashReceiptPaymentDetailList = DataGridViewPanel_PaymentDetail.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.CashReceipts.Classes.ClientCashReceiptPaymentDetail).ToList

                Me.ClearChanged()

                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()

            Else

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub DataGridViewPanel_PaymentDetail_CellValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewPanel_PaymentDetail.CellValueChangedEvent

            If e.Column.FieldName = AdvantageFramework.CashReceipts.Classes.ClientCashReceiptPaymentDetail.Properties.PaymentAmount.ToString Then

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonItemPayment_Apply_Click(sender As Object, e As EventArgs) Handles ButtonItemPayment_Apply.Click

            Dim ClientCashReceiptPaymentDetailList As Generic.List(Of AdvantageFramework.CashReceipts.Classes.ClientCashReceiptPaymentDetail) = Nothing

            DataGridViewPanel_PaymentDetail.CurrentView.CloseEditorForUpdating()

            ClientCashReceiptPaymentDetailList = DataGridViewPanel_PaymentDetail.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.CashReceipts.Classes.ClientCashReceiptPaymentDetail)().ToList

            For Each ClientCashReceiptPaymentDetail In DataGridViewPanel_PaymentDetail.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.CashReceipts.Classes.ClientCashReceiptPaymentDetail)()

                If _BalanceToAmount IsNot Nothing Then

                    If ClientCashReceiptPaymentDetail.TotalBill.GetValueOrDefault(0) < NumericInputPanel_Remaining.EditValue Then

                        ClientCashReceiptPaymentDetail.PaymentAmount = ClientCashReceiptPaymentDetail.TotalBill

                    Else

                        ClientCashReceiptPaymentDetail.PaymentAmount = NumericInputPanel_Remaining.EditValue

                    End If

                    NumericInputPanel_Remaining.Value = _BalanceToAmount - ClientCashReceiptPaymentDetailList.Sum(Function(CCRPD) CCRPD.PaymentAmount.GetValueOrDefault(0))

                Else

                    If ClientCashReceiptPaymentDetail.TotalBill.GetValueOrDefault(0) < (_CurrentBalance - ClientCashReceiptPaymentDetailList.Sum(Function(CCRPD) CCRPD.PaymentAmount.GetValueOrDefault(0))) Then

                        ClientCashReceiptPaymentDetail.PaymentAmount = ClientCashReceiptPaymentDetail.TotalBill

                    Else

                        ClientCashReceiptPaymentDetail.PaymentAmount = (_CurrentBalance - ClientCashReceiptPaymentDetailList.Sum(Function(CCRPD) CCRPD.PaymentAmount.GetValueOrDefault(0)))

                    End If

                End If

            Next

            DataGridViewPanel_PaymentDetail.CurrentView.RefreshData()
            DataGridViewPanel_PaymentDetail.SetUserEntryChanged()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemPayment_Undo_Click(sender As Object, e As EventArgs) Handles ButtonItemPayment_Undo.Click

            Dim ClientCashReceiptPaymentDetail As AdvantageFramework.CashReceipts.Classes.ClientCashReceiptPaymentDetail = Nothing

            DataGridViewPanel_PaymentDetail.CurrentView.CloseEditorForUpdating()

            For Each ClientCashReceiptPaymentDetail In DataGridViewPanel_PaymentDetail.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.CashReceipts.Classes.ClientCashReceiptPaymentDetail)()

                ClientCashReceiptPaymentDetail.PaymentAmount = Nothing

            Next

            DataGridViewPanel_PaymentDetail.CurrentView.RefreshData()
            DataGridViewPanel_PaymentDetail.SetUserEntryChanged()

            EnableOrDisableActions()

        End Sub

#End Region

#End Region

    End Class

End Namespace