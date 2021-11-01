Namespace FinanceAndAccounting.Presentation

    Public Class ClientCashReceiptEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _ClientCode As String = Nothing
        Private _ClientCashReceiptID As Integer = 0
        Private _SequenceNumber As Integer = 0
        Private _BatchDate As Date = Nothing
        Private _BankCode As String = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property ClientCode As String
            Get
                ClientCode = _ClientCode
            End Get
        End Property
        Private ReadOnly Property ClientCashReceiptID As Integer
            Get
                ClientCashReceiptID = _ClientCashReceiptID
            End Get
        End Property
        Private ReadOnly Property SequenceNumber As Integer
            Get
                SequenceNumber = _SequenceNumber
            End Get
        End Property
        Private ReadOnly Property BankCode As String
            Get
                BankCode = _BankCode
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal ClientCode As String, ByVal ClientCashReceiptID As Integer, ByVal SequenceNumber As Integer, ByVal BatchDate As Date, ByVal BankCode As String)

            ' This call is required by the designer.
            InitializeComponent()

            _ClientCode = ClientCode
            _ClientCashReceiptID = ClientCashReceiptID
            _SequenceNumber = SequenceNumber
            _BatchDate = BatchDate
            _BankCode = BankCode

        End Sub
        Private Sub EnableOrDisableActions()

            ButtonItemPayment_Apply.Enabled = ClientCashReceiptControlForm_CCR.DataGridViewPanel_ClientInvoices.HasRows
            ButtonItemPayment_Partial.Enabled = ClientCashReceiptControlForm_CCR.ClientCashReceiptsPartialPaymentEnabled AndAlso
                                                    ClientCashReceiptControlForm_CCR.DataGridViewPanel_ClientInvoices.HasOnlyOneSelectedRow AndAlso
                                                    Not ClientCashReceiptControlForm_CCR.SelectedInvoiceIsManual

            ButtonItemPayment_Undo.Enabled = ClientCashReceiptControlForm_CCR.DataGridViewPanel_ClientInvoices.HasRows

            ButtonItemWriteoff_Apply.Enabled = ClientCashReceiptControlForm_CCR.DataGridViewPanel_ClientInvoices.HasRows
            ButtonItemWriteoff_Undo.Enabled = ClientCashReceiptControlForm_CCR.DataGridViewPanel_ClientInvoices.HasRows

            If ClientCashReceiptControlForm_CCR.NumericInputDisbursedTo_Balance.Value = 0 Then

                ButtonItemActions_Add.Enabled = True

            Else

                ButtonItemActions_Add.Enabled = False

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef ClientCode As String, ByRef ClientCashReceiptID As Integer, ByRef SequenceNumber As Integer, ByVal BatchDate As Date, _
                                              ByRef BankCode As String) As System.Windows.Forms.DialogResult

            'objects
            Dim ClientCashReceiptEditDialog As AdvantageFramework.FinanceAndAccounting.Presentation.ClientCashReceiptEditDialog = Nothing

            ClientCashReceiptEditDialog = New AdvantageFramework.FinanceAndAccounting.Presentation.ClientCashReceiptEditDialog(ClientCode, ClientCashReceiptID, SequenceNumber, BatchDate, BankCode)

            ShowFormDialog = ClientCashReceiptEditDialog.ShowDialog()

            ClientCode = ClientCashReceiptEditDialog.ClientCode
            ClientCashReceiptID = ClientCashReceiptEditDialog.ClientCashReceiptID
            SequenceNumber = ClientCashReceiptEditDialog.SequenceNumber
            BankCode = ClientCashReceiptEditDialog.BankCode

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub ClientCashReceiptEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            ButtonItemPayment_Apply.Image = AdvantageFramework.My.Resources.CheckAttachImage
            ButtonItemPayment_Partial.Image = AdvantageFramework.My.Resources.MediaDateToBillImage
            ButtonItemPayment_Undo.Image = AdvantageFramework.My.Resources.UndoImage

            ButtonItemWriteoff_Apply.Image = AdvantageFramework.My.Resources.WriteoffImage
            ButtonItemWriteoff_Undo.Image = AdvantageFramework.My.Resources.UndoImage

            ButtonItemOnAccount_Apply.Image = AdvantageFramework.My.Resources.WriteoffImage
            ButtonItemOnAccount_Undo.Image = AdvantageFramework.My.Resources.UndoImage

        End Sub
        Private Sub ClientCashReceiptEditDialog_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            Me.ShowWaitForm()

            If ClientCashReceiptControlForm_CCR.LoadControl(_ClientCode, _ClientCashReceiptID, _SequenceNumber, _BatchDate, True, _BankCode) = False Then

                AdvantageFramework.WinForm.MessageBox.Show("The Client Cash Receipt you are trying to edit does not exist anymore.")
                Me.Close()

            Else

                EnableOrDisableActions()

                Me.SuperValidator.ClearFailedValidations()

                If ClientCashReceiptControlForm_CCR.SearchableComboBoxPanel_Client.HasASelectedValue Then

                    ClientCashReceiptControlForm_CCR.TextBoxPanel_CheckNumber.Focus()

                Else

                    ClientCashReceiptControlForm_CCR.SearchableComboBoxPanel_Client.Focus()

                End If

            End If

            Me.CloseWaitForm()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ClientCashReceiptControlForm_CCR_ClientCheckNumberChanged() Handles ClientCashReceiptControlForm_CCR.ClientCheckNumberChanged

            EnableOrDisableActions()

        End Sub
        Private Sub ClientCashReceiptControlForm_CCR_ClientInvoiceSelectionChangedEvent(sender As Object, e As EventArgs) Handles ClientCashReceiptControlForm_CCR.ClientInvoiceSelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub ClientCashReceiptControlForm_CCR_TotalsChanged() Handles ClientCashReceiptControlForm_CCR.TotalsChanged

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemActions_Add_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Add.Click

            Dim ErrorMessage As String = Nothing
            Dim ClientCode As String = Nothing
            Dim ClientCashReceiptID As Integer = Nothing
            Dim SequenceNumber As Short = Nothing
            Dim BankCode As String = Nothing

            If Me.Validator Then

                If ClientCashReceiptControlForm_CCR.ValidateCheckNumber Then

                    Me.ShowWaitForm("Adding...")
                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Adding

                    Try

                        If ClientCashReceiptControlForm_CCR.Insert(ClientCode, ClientCashReceiptID, SequenceNumber, _BatchDate, BankCode) Then

                            _ClientCode = ClientCode
                            _ClientCashReceiptID = ClientCashReceiptID
                            _SequenceNumber = SequenceNumber
                            _BankCode = BankCode

                            Me.ClearChanged()

                            Me.DialogResult = System.Windows.Forms.DialogResult.OK
                            Me.Close()

                        End If

                    Catch ex As Exception
                        AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                    End Try

                    Me.CloseWaitForm()
                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                End If

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    If LastFailedValidationResult.Control.Name <> "ComboBoxPanel_PostPeriodForMod" Then

                        ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                    End If

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ButtonItemPayment_Apply_Click(sender As Object, e As EventArgs) Handles ButtonItemPayment_Apply.Click

            ClientCashReceiptControlForm_CCR.ApplyPaymentsUptoCheckAmountToSelectedInvoices()

        End Sub
        Private Sub ButtonItemPayment_Partial_Click(sender As Object, e As EventArgs) Handles ButtonItemPayment_Partial.Click

            ClientCashReceiptControlForm_CCR.LaunchPartialPaymentDialog(True)

        End Sub
        Private Sub ButtonItemPayment_Undo_Click(sender As Object, e As EventArgs) Handles ButtonItemPayment_Undo.Click

            ClientCashReceiptControlForm_CCR.UndoPaymentsOnSelectedInvoices()

        End Sub
        Private Sub ButtonItemWriteoff_Apply_Click(sender As Object, e As EventArgs) Handles ButtonItemWriteoff_Apply.Click

            ClientCashReceiptControlForm_CCR.ApplyWriteoffsToSelectedInvoices()

        End Sub
        Private Sub ButtonItemWriteoff_Undo_Click(sender As Object, e As EventArgs) Handles ButtonItemWriteoff_Undo.Click

            ClientCashReceiptControlForm_CCR.UndoWriteoffsOnSelectedInvoices()

        End Sub
        Private Sub ButtonItemOnAccount_Apply_Click(sender As Object, e As EventArgs) Handles ButtonItemOnAccount_Apply.Click

            ClientCashReceiptControlForm_CCR.ApplyToOnAccount()

        End Sub
        Private Sub ButtonItemOnAccount_Undo_Click(sender As Object, e As EventArgs) Handles ButtonItemOnAccount_Undo.Click

            ClientCashReceiptControlForm_CCR.UndoOnAccount()

        End Sub

#End Region

#End Region

    End Class

End Namespace