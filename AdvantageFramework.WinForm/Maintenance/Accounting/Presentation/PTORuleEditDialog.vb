Namespace Maintenance.Accounting.Presentation

    Public Class PTORuleEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _PTORuleID As Integer = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property PTORuleID As Integer
            Get
                PTORuleID = _PTORuleID
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByRef PTORuleID As Integer)

            ' This call is required by the designer.
            InitializeComponent()

            _PTORuleID = PTORuleID

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(Optional ByRef PTORuleID As Integer = Nothing) As System.Windows.Forms.DialogResult

            'objects
            Dim PTORuleEditDialog As AdvantageFramework.Maintenance.Accounting.Presentation.PTORuleEditDialog = Nothing

            PTORuleEditDialog = New AdvantageFramework.Maintenance.Accounting.Presentation.PTORuleEditDialog(PTORuleID)

            ShowFormDialog = PTORuleEditDialog.ShowDialog()

            PTORuleID = PTORuleEditDialog.PTORuleID

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub PTORuleEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            If _PTORuleID <> 0 Then

                ButtonForm_Add.Visible = False
                ButtonForm_Update.Visible = True

            Else

                ButtonForm_Add.Visible = True
                ButtonForm_Update.Visible = False

            End If

            If PTORuleControlForm_PTORule.LoadControl(_PTORuleID) = False Then

                AdvantageFramework.WinForm.MessageBox.Show("The PTO Rule you are trying to edit does not exist anymore.")
                Me.Close()

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Add.Click

            'objects
            Dim PTORuleID As Integer = Nothing
            Dim ErrorMessage As String = ""

            If Me.Validator Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Adding, "Adding...")

                Try

                    If PTORuleControlForm_PTORule.Insert(PTORuleID) Then

                        _PTORuleID = PTORuleID

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

            'objects 'objects
            Dim ErrorMessage As String = ""

            If Me.Validator Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                Try

                    If PTORuleControlForm_PTORule.Save() Then

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