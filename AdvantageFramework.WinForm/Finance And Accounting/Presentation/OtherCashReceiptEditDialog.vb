Namespace FinanceAndAccounting.Presentation

    Public Class OtherCashReceiptEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _OtherCashReceiptID As Integer = 0
        Private _SequenceNumber As Integer = 0
        Private _BatchDate As Date = Nothing
        Private _BankCode As String = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property OtherCashReceiptID As Integer
            Get
                OtherCashReceiptID = _OtherCashReceiptID
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

        Private Sub New(ByVal OtherCashReceiptID As Integer, ByVal SequenceNumber As Integer, ByVal BatchDate As Date, ByVal BankCode As String)

            ' This call is required by the designer.
            InitializeComponent()

            _OtherCashReceiptID = OtherCashReceiptID
            _SequenceNumber = SequenceNumber
            _BatchDate = BatchDate
            _BankCode = BankCode

        End Sub
        Private Sub EnableOrDisableActions()

            If OtherCashReceiptControlForm_OCR.NumericInputDisbursedTo_Balance.EditValue = 0 Then

                ButtonForm_Add.Enabled = True

            Else

                ButtonForm_Add.Enabled = False

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef OtherCashReceiptID As Integer, ByRef SequenceNumber As Integer, ByVal BatchDate As Date, ByRef BankCode As String) As System.Windows.Forms.DialogResult

            'objects
            Dim OtherCashReceiptEditDialog As AdvantageFramework.FinanceAndAccounting.Presentation.OtherCashReceiptEditDialog = Nothing

            OtherCashReceiptEditDialog = New AdvantageFramework.FinanceAndAccounting.Presentation.OtherCashReceiptEditDialog(OtherCashReceiptID, SequenceNumber, BatchDate, BankCode)

            ShowFormDialog = OtherCashReceiptEditDialog.ShowDialog()

            OtherCashReceiptID = OtherCashReceiptEditDialog.OtherCashReceiptID
            SequenceNumber = OtherCashReceiptEditDialog.SequenceNumber
            BankCode = OtherCashReceiptEditDialog.BankCode

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub OtherCashReceiptEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            If OtherCashReceiptControlForm_OCR.LoadControl(_OtherCashReceiptID, _SequenceNumber, _BatchDate, _BankCode) = False Then

                AdvantageFramework.WinForm.MessageBox.Show("The Other Cash Receipt you are trying to edit does not exist anymore.")
                Me.Close()

            End If

        End Sub
        Private Sub OtherCashReceiptEditDialog_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            Me.SuperValidator.ClearFailedValidations()
            OtherCashReceiptControlForm_OCR.TextBoxPanel_CheckNumber.Focus()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub OtherCashReceiptControlForm_OCR_TotalsChanged() Handles OtherCashReceiptControlForm_OCR.TotalsChanged

            EnableOrDisableActions()
            
        End Sub
        Private Sub ButtonForm_Add_Click(sender As Object, e As EventArgs) Handles ButtonForm_Add.Click

            Dim ErrorMessage As String = Nothing
            Dim ClientCode As String = Nothing
            Dim OtherCashReceiptID As Integer = Nothing
            Dim SequenceNumber As Short = Nothing
            Dim BankCode As String = Nothing

            If Me.Validator Then

                'If OtherCashReceiptControlForm_OCR.ValidateCheckNumber Then

                Me.ShowWaitForm("Adding...")
                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Adding

                Try

                    If OtherCashReceiptControlForm_OCR.Insert(OtherCashReceiptID, SequenceNumber, _BatchDate, BankCode) Then

                        _OtherCashReceiptID = OtherCashReceiptID
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

                'End If

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    If LastFailedValidationResult.Control.Name <> "ComboBoxPanel_PostPeriodForMod" Then

                        ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                    End If

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub

#End Region

#End Region

    End Class

End Namespace