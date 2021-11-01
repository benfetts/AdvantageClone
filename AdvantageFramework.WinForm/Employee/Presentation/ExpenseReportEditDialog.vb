Namespace Employee.Presentation

    Public Class ExpenseReportEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _InvoiceNumber As String = Nothing
        Private _EmployeeCode As String = Nothing
        Private _IsCopy As Boolean = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property InvoiceNumber As String
            Get
                InvoiceNumber = _InvoiceNumber
            End Get
        End Property
        Private ReadOnly Property EmployeeCode As String
            Get
                EmployeeCode = _EmployeeCode
            End Get
        End Property
        Private ReadOnly Property IsCopy As Boolean
            Get
                IsCopy = _IsCopy
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByRef InvoiceNumber As String, ByRef EmployeeCode As String, ByRef IsCopy As Boolean)

            ' This call is required by the designer.
            InitializeComponent()

            _InvoiceNumber = InvoiceNumber
            _EmployeeCode = EmployeeCode
            _IsCopy = IsCopy

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(Optional ByRef InvoiceNumber As String = Nothing, Optional ByRef EmployeeCode As String = Nothing, Optional ByRef IsCopy As Boolean = False) As System.Windows.Forms.DialogResult

            'objects
            Dim ExpenseReportEditDialog As AdvantageFramework.Employee.Presentation.ExpenseReportEditDialog = Nothing

            ExpenseReportEditDialog = New AdvantageFramework.Employee.Presentation.ExpenseReportEditDialog(InvoiceNumber, EmployeeCode, IsCopy)

            ShowFormDialog = ExpenseReportEditDialog.ShowDialog()

            InvoiceNumber = ExpenseReportEditDialog.InvoiceNumber
            EmployeeCode = ExpenseReportEditDialog.EmployeeCode
            IsCopy = ExpenseReportEditDialog.IsCopy

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub ExpenseReportEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            If _InvoiceNumber <> "" Then

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

            If ExpenseReportControlForm_ExpenseReport.LoadControl(InvoiceNumber:=_InvoiceNumber, EmployeeCode:=EmployeeCode, IsCopy:=_IsCopy) = False Then

                AdvantageFramework.WinForm.MessageBox.Show("Their was a problem loading the expense report.")
                Me.Close()

            End If

        End Sub
        Private Sub ExpenseReportEditDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            If Me.IsFormClosing = False Then

                If _EmployeeCode <> "" Then

                    ExpenseReportControlForm_ExpenseReport.TextBoxGeneral_Description.Focus()

                End If

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Add_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Add.Click

            'objects
            Dim InvoiceNumber As Integer = Nothing
            Dim ParentControl As Object = Nothing
            Dim FailedControl As Object = Nothing
            Dim ErrorMessage As String = ""

            If Me.Validator Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Adding, "Adding...")

                Try

                    If ExpenseReportControlForm_ExpenseReport.Insert(InvoiceNumber) Then

                        _InvoiceNumber = InvoiceNumber

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

                If FailedControl IsNot Nothing Then

                    ExpenseReportControlForm_ExpenseReport.SetFocusOnFailedControl(FailedControl)

                End If

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

                    If ExpenseReportControlForm_ExpenseReport.Save(False, ErrorMessage) Then

                        Me.ClearChanged()

                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()

                    End If

                Catch ex As Exception
                    ErrorMessage = ex.Message
                End Try

                If ErrorMessage <> "" Then

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                FailedControl = (Me.SuperValidator.LastFailedValidationResults.ToList.FirstOrDefault).Control

                If FailedControl IsNot Nothing Then

                    ExpenseReportControlForm_ExpenseReport.SetFocusOnFailedControl(FailedControl)

                End If

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