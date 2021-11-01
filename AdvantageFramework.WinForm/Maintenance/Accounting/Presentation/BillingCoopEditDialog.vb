Namespace Maintenance.Accounting.Presentation

    Public Class BillingCoopEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _BillingCoopCode As String = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property BillingCoopCode As String
            Get
                BillingCoopCode = _BillingCoopCode
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByRef BillingCoopCode As String)

            ' This call is required by the designer.
            InitializeComponent()

            _BillingCoopCode = BillingCoopCode

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(Optional ByRef BillingCoopCode As String = Nothing) As System.Windows.Forms.DialogResult

            'objects
            Dim BillingCoopEditDialog As AdvantageFramework.Maintenance.Accounting.Presentation.BillingCoopEditDialog = Nothing

            BillingCoopEditDialog = New AdvantageFramework.Maintenance.Accounting.Presentation.BillingCoopEditDialog(BillingCoopCode)

            ShowFormDialog = BillingCoopEditDialog.ShowDialog()

            BillingCoopCode = BillingCoopEditDialog.BillingCoopCode

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub BillingCoopEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            If _BillingCoopCode <> "" Then

                ButtonForm_Add.Visible = False
                ButtonForm_Update.Visible = True

            Else

                ButtonForm_Add.Visible = True
                ButtonForm_Add.Enabled = False
                ButtonForm_Update.Visible = False

            End If

            If BillingCoopControlForm_BillingCoop.LoadControl(_BillingCoopCode) = False Then

                AdvantageFramework.WinForm.MessageBox.Show("The billing coop code you are trying to edit does not exist anymore.")
                Me.Close()

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Add_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Add.Click

            'objects
            Dim BillingCoopCode As String = ""
            Dim ErrorMessage As String = ""

            If Me.Validator Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Adding, "Adding...")

                Try

                    If BillingCoopControlForm_BillingCoop.Insert(BillingCoopCode) Then

                        _BillingCoopCode = BillingCoopCode

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
        Private Sub ButtonForm_Update_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Update.Click

            'objects
            Dim ErrorMessage As String = ""

            If Me.Validator Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                Try

                    If BillingCoopControlForm_BillingCoop.Save() Then

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
        Private Sub ButtonForm_Cancel_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub BillingCoopControlForm_BillingCoop_TotalPercentChangedEvent(ByVal TotalPercent As Decimal) Handles BillingCoopControlForm_BillingCoop.TotalPercentChangedEvent

            ButtonForm_Add.Enabled = (TotalPercent = 100)

        End Sub

#End Region

#End Region

    End Class

End Namespace