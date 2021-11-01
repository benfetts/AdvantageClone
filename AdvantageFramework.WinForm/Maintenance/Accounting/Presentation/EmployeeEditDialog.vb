Namespace Maintenance.Accounting.Presentation

    Public Class EmployeeEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _EmployeeCode As String = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property EmployeeCode As String
            Get
                EmployeeCode = _EmployeeCode
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByRef EmployeeCode As String)

            ' This call is required by the designer.
            InitializeComponent()

            _EmployeeCode = EmployeeCode

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(Optional ByRef EmployeeCode As String = Nothing) As System.Windows.Forms.DialogResult

            'objects
            Dim EmployeeEditDialog As AdvantageFramework.Maintenance.Accounting.Presentation.EmployeeEditDialog = Nothing

            EmployeeEditDialog = New AdvantageFramework.Maintenance.Accounting.Presentation.EmployeeEditDialog(EmployeeCode)

            ShowFormDialog = EmployeeEditDialog.ShowDialog()

            EmployeeCode = EmployeeEditDialog.EmployeeCode

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub EmployeeEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            If _EmployeeCode <> "" Then

                ButtonForm_Add.Visible = False
                ButtonForm_Update.Visible = True

            Else

                ButtonForm_Add.Visible = True
                ButtonForm_Update.Visible = False

            End If

            If EmployeeControlForm_Employee.LoadControl(_EmployeeCode) = False Then

                AdvantageFramework.WinForm.MessageBox.Show("The employee you are trying to edit does not exist anymore.")
                Me.Close()

            End If

        End Sub
        Private Sub EmployeeEditDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            If Me.IsFormClosing = False Then

                EmployeeControlForm_Employee.TextBoxGeneralInformation_Code.Focus()

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Add_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Add.Click

            'objects
            Dim EmployeeCode As String = ""
            Dim ErrorMessage As String = ""

            If Me.Validator Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Adding, "Adding...")

                Try

                    If EmployeeControlForm_Employee.Insert(EmployeeCode) Then

                        _EmployeeCode = EmployeeCode

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

                    EmployeeControlForm_Employee.Save()

                    Me.ClearChanged()

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()

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

#End Region

#End Region

    End Class

End Namespace