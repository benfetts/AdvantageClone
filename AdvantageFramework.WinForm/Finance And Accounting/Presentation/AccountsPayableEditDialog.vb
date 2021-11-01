Namespace FinanceAndAccounting.Presentation

    Public Class AccountsPayableEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _VendorCode As String = Nothing
        Private _AccountPayableID As Integer = 0
        Private _SequenceNumber As Integer = 0
        Private _BatchDate As Date = Nothing
        Private _ShowGross As Boolean = False
        'Private _ShowHome As Boolean = False

#End Region

#Region " Properties "

        Private ReadOnly Property VendorCode As String
            Get
                VendorCode = _VendorCode
            End Get
        End Property
        Private ReadOnly Property AccountPayableID As Integer
            Get
                AccountPayableID = _AccountPayableID
            End Get
        End Property
        Private ReadOnly Property SequenceNumber As Integer
            Get
                SequenceNumber = _SequenceNumber
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal VendorCode As String, ByVal AccountPayableID As Integer, ByVal SequenceNumber As Integer, ByVal BatchDate As Date, ByVal ShowGross As Boolean) ',ShowHome As Boolean)

            ' This call is required by the designer.
            InitializeComponent()

            _VendorCode = VendorCode
            _AccountPayableID = AccountPayableID
            _SequenceNumber = SequenceNumber
            _BatchDate = BatchDate
            _ShowGross = ShowGross
            '_ShowHome = ShowHome

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef VendorCode As String, ByRef AccountPayableID As Integer, ByRef SequenceNumber As Integer, BatchDate As Date,
                                              ShowGross As Boolean) As System.Windows.Forms.DialogResult ', ShowHome As Boolean) As System.Windows.Forms.DialogResult

            Using AccountsPayableEditDialog As New AdvantageFramework.FinanceAndAccounting.Presentation.AccountsPayableEditDialog(VendorCode, AccountPayableID, SequenceNumber, BatchDate, ShowGross) ', ShowHome)

                ShowFormDialog = AccountsPayableEditDialog.ShowDialog()

                VendorCode = AccountsPayableEditDialog.VendorCode
                AccountPayableID = AccountsPayableEditDialog.AccountPayableID
                SequenceNumber = AccountsPayableEditDialog.SequenceNumber

            End Using

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub AccountsPayableEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            If _AccountPayableID <> 0 Then

                ButtonForm_Add.Visible = False
                ButtonForm_Update.Visible = True

            Else

                ButtonForm_Add.Visible = True
                ButtonForm_Update.Visible = False

            End If

            If AccountsPayableControlForm_AP.LoadControl(_VendorCode, _AccountPayableID, _SequenceNumber, _BatchDate, _ShowGross, False) = False Then ', _ShowHome) = False Then

                AdvantageFramework.WinForm.MessageBox.Show("The AP Invoice you are trying to edit does not exist anymore.")
                Me.Close()

            End If

        End Sub
        Private Sub AccountsPayableEditDialog_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            Me.SuperValidator.ClearFailedValidations()
            AccountsPayableControlForm_AP.TextBoxControl_InvoiceNumber.Focus()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Add.Click

            Dim ErrorMessage As String = Nothing
            Dim VendorCode As String = Nothing
            Dim AccountPayableID As Integer = Nothing
            Dim SequenceNumber As Short = Nothing

            If Me.Validator Then

                If AccountsPayableControlForm_AP.ValidateInvoiceNumber Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Adding, "Adding...")

                    Try

                        If AccountsPayableControlForm_AP.Insert(VendorCode, AccountPayableID, SequenceNumber, _BatchDate) Then

                            _VendorCode = VendorCode
                            _AccountPayableID = AccountPayableID
                            _SequenceNumber = SequenceNumber

                            Me.ClearChanged()

                            Me.DialogResult = System.Windows.Forms.DialogResult.OK
                            Me.Close()

                        End If

                    Catch ex As Exception
                        AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                End If

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    If LastFailedValidationResult.Control.Name <> "ComboBoxControl_PostPeriodForMod" Then

                        ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                    End If

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub AccountsPayableControlForm_AP_TotalsChanged(ByVal Balance As Decimal) Handles AccountsPayableControlForm_AP.TotalsChanged

            If Balance = 0 Then

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

                    If AccountsPayableControlForm_AP.Save(Nothing) Then

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