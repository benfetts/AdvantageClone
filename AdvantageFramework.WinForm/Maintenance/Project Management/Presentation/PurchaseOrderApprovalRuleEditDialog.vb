Namespace Maintenance.ProjectManagement.Presentation

    Public Class PurchaseOrderApprovalRuleEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _PurchaseOrderApprovalRuleCode As String = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property PurchaseOrderApprovalRuleCode As String
            Get
                PurchaseOrderApprovalRuleCode = _PurchaseOrderApprovalRuleCode
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByRef PurchaseOrderApprovalRuleCode As String)

            ' This call is required by the designer.
            InitializeComponent()

            _PurchaseOrderApprovalRuleCode = PurchaseOrderApprovalRuleCode

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef PurchaseOrderApprovalRuleCode As String) As System.Windows.Forms.DialogResult

            'objects
            Dim PurchaseOrderApprovalRuleEditDialog As AdvantageFramework.Maintenance.ProjectManagement.Presentation.PurchaseOrderApprovalRuleEditDialog = Nothing

            PurchaseOrderApprovalRuleEditDialog = New AdvantageFramework.Maintenance.ProjectManagement.Presentation.PurchaseOrderApprovalRuleEditDialog(PurchaseOrderApprovalRuleCode)

            ShowFormDialog = PurchaseOrderApprovalRuleEditDialog.ShowDialog()

            PurchaseOrderApprovalRuleCode = PurchaseOrderApprovalRuleEditDialog.PurchaseOrderApprovalRuleCode

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub PurchaseOrderApprovalRuleEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            If _PurchaseOrderApprovalRuleCode <> "" Then

                ButtonForm_Add.Visible = False
                ButtonForm_Update.Visible = True

            Else

                ButtonForm_Add.Visible = True
                ButtonForm_Update.Visible = False

            End If

            If PurchaseOrderApprovalRuleControl_FormPOApprovalRule.LoadControl(_PurchaseOrderApprovalRuleCode) = False Then

                AdvantageFramework.WinForm.MessageBox.Show("The Purchase Order Approval Rule you are trying to edit does not exist anymore.")
                Me.Close()

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Add.Click

            Dim PurchaseOrderApprovalRuleCode As String = Nothing
            Dim ErrorMessage As String = Nothing

            If Me.Validator Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Adding, "Adding...")

                Try

                    If PurchaseOrderApprovalRuleControl_FormPOApprovalRule.Insert(PurchaseOrderApprovalRuleCode) Then

                        _PurchaseOrderApprovalRuleCode = PurchaseOrderApprovalRuleCode

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
        Private Sub ButtonForm_Update_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Update.Click

            'objects
            Dim PurchaseOrderApprovalRule As AdvantageFramework.Database.Entities.PurchaseOrderApprovalRule = Nothing
            Dim ErrorMessage As String = Nothing

            If Me.Validator Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                Try

                    If PurchaseOrderApprovalRuleControl_FormPOApprovalRule.Save() Then

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