Namespace Maintenance.Media.Presentation

    Public Class RateCardContractEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _RateCardID As Integer = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property RateCardID As Integer
            Get
                RateCardID = _RateCardID
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByRef RateCardID As Integer)

            ' This call is required by the designer.
            InitializeComponent()

            _RateCardID = RateCardID

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(Optional ByRef RateCardID As Integer = Nothing) As System.Windows.Forms.DialogResult

            'objects
            Dim RateCardContractEditDialog As AdvantageFramework.Maintenance.Media.Presentation.RateCardContractEditDialog = Nothing

            RateCardContractEditDialog = New AdvantageFramework.Maintenance.Media.Presentation.RateCardContractEditDialog(RateCardID)

            ShowFormDialog = RateCardContractEditDialog.ShowDialog()

            RateCardID = RateCardContractEditDialog.RateCardID

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub RateCardContractEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            If _RateCardID <> 0 Then

                ButtonForm_Add.Visible = False
                ButtonForm_Update.Visible = True

            Else

                ButtonForm_Add.Visible = True
                ButtonForm_Update.Visible = False

            End If

            If RateCardContractForm_RateCardContract.LoadControl(_RateCardID) = False Then

                AdvantageFramework.WinForm.MessageBox.Show("The rate card/contract you are trying to edit does not exist anymore.")
                Me.Close()

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Add.Click

            Dim RateCardID As Integer = Nothing
            Dim ErrorMessage As String = Nothing

            If Me.Validator Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Adding, "Adding...")

                Try

                    If RateCardContractForm_RateCardContract.Insert(RateCardID) Then

                        _RateCardID = RateCardID

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
            Dim RateCard As AdvantageFramework.Database.Entities.RateCard = Nothing
            Dim ErrorMessage As String = Nothing

            If Me.Validator Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                Try

                    If RateCardContractForm_RateCardContract.Save() Then

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