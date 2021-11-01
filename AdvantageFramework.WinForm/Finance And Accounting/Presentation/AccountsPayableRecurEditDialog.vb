Namespace FinanceAndAccounting.Presentation

    Public Class AccountsPayableRecurEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _VendorCode As String = Nothing
        Private _AccountPayableRecurID As Integer = 0

#End Region

#Region " Properties "

        Private ReadOnly Property VendorCode As String
            Get
                VendorCode = _VendorCode
            End Get
        End Property
        Private ReadOnly Property AccountPayableRecurID As Integer
            Get
                AccountPayableRecurID = _AccountPayableRecurID
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByRef VendorCode As String, ByRef AccountPayableRecurID As Integer)

            ' This call is required by the designer.
            InitializeComponent()

            _VendorCode = VendorCode
            _AccountPayableRecurID = AccountPayableRecurID

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef VendorCode As String, ByRef AccountPayableRecurID As Integer) As System.Windows.Forms.DialogResult

            'objects
            Dim AccountsPayableRecurEditDialog As AdvantageFramework.FinanceAndAccounting.Presentation.AccountsPayableRecurEditDialog = Nothing

            AccountsPayableRecurEditDialog = New AdvantageFramework.FinanceAndAccounting.Presentation.AccountsPayableRecurEditDialog(VendorCode, AccountPayableRecurID)

            ShowFormDialog = AccountsPayableRecurEditDialog.ShowDialog()

            VendorCode = AccountsPayableRecurEditDialog.VendorCode
            AccountPayableRecurID = AccountsPayableRecurEditDialog.AccountPayableRecurID

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub AccountsPayableRecurEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            If _AccountPayableRecurID <> 0 Then

                ButtonForm_Add.Visible = False
                ButtonForm_Update.Visible = True

            Else

                ButtonForm_Add.Visible = True
                ButtonForm_Update.Visible = False

            End If


            If AccountsPayableRecurControlForm_APRecur.LoadControl(_VendorCode, _AccountPayableRecurID) = False Then

                AdvantageFramework.WinForm.MessageBox.Show("The AP Invoice you are trying to edit does not exist anymore.")
                Me.Close()

            End If

        End Sub
        Private Sub AccountsPayableRecurEditDialog_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            Me.SuperValidator.ClearFailedValidations()
            AccountsPayableRecurControlForm_APRecur.TextBoxControl_InvoiceNumber.Focus()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Add.Click

            Dim ErrorMessage As String = Nothing
            Dim AccountPayableRecurID As Integer = Nothing

            If Me.Validator Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Adding, "Adding...")

                Try

                    If AccountsPayableRecurControlForm_APRecur.Insert(AccountPayableRecurID) Then

                        _AccountPayableRecurID = AccountPayableRecurID

                        Me.ClearChanged()

                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                        Me.Close()

                    End If

                Catch ex As Exception
                    AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                End Try

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub AccountsPayableRecurControlForm_APRecur_TotalsChanged(ByVal Balance As Decimal, ByVal DetailRecordsExist As Boolean) Handles AccountsPayableRecurControlForm_APRecur.TotalsChanged

            If Balance = 0 And DetailRecordsExist Then

                ButtonForm_Add.Enabled = True

            Else

                ButtonForm_Add.Enabled = False

            End If

        End Sub
        Private Sub ButtonForm_Update_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Update.Click

            'objects
            Dim ErrorMessage As String = ""

            If Me.Validator Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                Try

                    If AccountsPayableRecurControlForm_APRecur.Save() Then

                        Me.ClearChanged()

                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()

                    End If

                Catch ex As Exception
                    AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                End Try

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

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

#End Region

#End Region

    End Class

End Namespace