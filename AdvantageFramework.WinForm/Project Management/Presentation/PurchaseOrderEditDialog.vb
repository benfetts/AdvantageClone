Namespace ProjectManagement.Presentation

    Public Class PurchaseOrderEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _PONumber As String = Nothing
        Private _EmployeeCode As String = Nothing
        Private _IsCopy As Boolean = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property PONumber As String
            Get
                PONumber = _PONumber
            End Get
        End Property
        Private ReadOnly Property IsCopy As Boolean
            Get
                IsCopy = _IsCopy
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByRef PONumber As String, ByRef IsCopy As Boolean)

            ' This call is required by the designer.
            InitializeComponent()

            _PONumber = PONumber
            _IsCopy = IsCopy

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(Optional ByRef PONumber As String = Nothing, Optional ByRef IsCopy As Boolean = False) As System.Windows.Forms.DialogResult

            'objects
            Dim PurchaseOrderEditDialog As AdvantageFramework.ProjectManagement.Presentation.PurchaseOrderEditDialog = Nothing

            PurchaseOrderEditDialog = New AdvantageFramework.ProjectManagement.Presentation.PurchaseOrderEditDialog(PONumber, IsCopy)

            ShowFormDialog = PurchaseOrderEditDialog.ShowDialog()

            PONumber = PurchaseOrderEditDialog.PONumber
            IsCopy = PurchaseOrderEditDialog.IsCopy

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub PurchaseOrderEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            If _PONumber <> "" Then

                If _IsCopy Then

                    ButtonForm_Add.Visible = True
                    ButtonForm_Update.Visible = False

                Else

                    ButtonForm_Add.Visible = False
                    ButtonForm_Update.Visible = True

                End If

            Else

                ButtonForm_Add.Visible = True
                ButtonForm_Update.Visible = False

            End If

            If PurchaseOrderControlForm_PurchaseOrder.LoadControl(PONumber, IsCopy) = False Then

                AdvantageFramework.WinForm.MessageBox.Show("There was a problem loading the purchase order.")
                Me.Close()

            End If

        End Sub
        Private Sub PurchaseOrderEditDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            PurchaseOrderControlForm_PurchaseOrder.TextBoxControl_Description.Focus()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Add_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Add.Click

            'objects
            Dim PONumber As Integer = Nothing
            Dim ParentControl As Object = Nothing
            Dim FailedControl As Object = Nothing
            Dim ErrorMessage As String = ""

            If Me.Validator Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Adding, "Adding...")

                Try

                    If PurchaseOrderControlForm_PurchaseOrder.Insert(PONumber) Then

                        _PONumber = PONumber

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

                FailedControl = (Me.SuperValidator.LastFailedValidationResults.ToList.FirstOrDefault).Control

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_Update_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Update.Click

            'objects
            Dim ErrorMessage As String = ""
            Dim FailedControl As Object = Nothing

            If Me.Validator Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                Try

                    If PurchaseOrderControlForm_PurchaseOrder.Save() Then

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

                FailedControl = (Me.SuperValidator.LastFailedValidationResults.ToList.FirstOrDefault).Control

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub

#End Region

#End Region

    End Class

End Namespace
