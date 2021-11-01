Namespace GeneralLedger.ReportWriter.Presentation

    Public Class GLReportAccountGroupEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _AccountGroupCode As String = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property AccountGroupCode As String
            Get
                AccountGroupCode = _AccountGroupCode
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByRef AccountGroupCode As String)

            ' This call is required by the designer.
            InitializeComponent()

            _AccountGroupCode = AccountGroupCode

        End Sub
        Private Sub EnableOrDisableActions()

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged
            ButtonItemDetails_Cancel.Enabled = AccountGroupControlForm_AccountGroup.DetailsDataGridView.IsNewItemRow
            ButtonItemDetails_Delete.Enabled = AccountGroupControlForm_AccountGroup.DetailsDataGridView.HasASelectedRow

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(Optional ByRef AccountGroupCode As String = Nothing) As System.Windows.Forms.DialogResult

            'objects
            Dim GLReportAccountGroupEditDialog As AdvantageFramework.GeneralLedger.ReportWriter.Presentation.GLReportAccountGroupEditDialog = Nothing

            GLReportAccountGroupEditDialog = New AdvantageFramework.GeneralLedger.ReportWriter.Presentation.GLReportAccountGroupEditDialog(AccountGroupCode)

            ShowFormDialog = GLReportAccountGroupEditDialog.ShowDialog()

            AccountGroupCode = GLReportAccountGroupEditDialog.AccountGroupCode

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub GLReportAccountGroupEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            ButtonItemDetails_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemDetails_Cancel.Image = AdvantageFramework.My.Resources.DetailCancelImage

            ButtonItemFilter_ShowInactive.Image = AdvantageFramework.My.Resources.FilterImage

            If _AccountGroupCode <> "" Then

                ButtonItemActions_Add.Visible = False
                ButtonItemActions_Save.Visible = True

            Else

                ButtonItemActions_Add.Visible = True
                ButtonItemActions_Save.Visible = False

            End If

            If AccountGroupControlForm_AccountGroup.LoadControl(_AccountGroupCode) = False Then

                AdvantageFramework.WinForm.MessageBox.Show("The account group you are trying to edit does not exist anymore.")
                Me.Close()

            End If

            EnableOrDisableActions()

        End Sub
        Private Sub GLReportAccountGroupEditDialog_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub GLReportAccountGroupEditDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            If Me.IsFormClosing = False Then

                AccountGroupControlForm_AccountGroup.TextBoxControl_Code.Focus()

            End If

        End Sub
        Private Sub GLReportAccountGroupEditDialog_UserEntryChangedEvent(Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Add_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Add.Click

            'objects
            Dim AccountGroupCode As String = ""
            Dim ErrorMessage As String = ""
            Dim DetailsValid As Boolean = True

            ErrorMessage = AccountGroupControlForm_AccountGroup.ValidateDetails(DetailsValid)

            If Me.Validator AndAlso DetailsValid Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Adding, "Adding...")

                Try

                    If AccountGroupControlForm_AccountGroup.Insert(AccountGroupCode) Then

                        _AccountGroupCode = AccountGroupCode

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
        Private Sub ButtonItemActions_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim ErrorMessage As String = ""
            Dim DetailsValid As Boolean = True

            ErrorMessage = AccountGroupControlForm_AccountGroup.ValidateDetails(DetailsValid)

            If Me.Validator AndAlso DetailsValid Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                Try

                    If AccountGroupControlForm_AccountGroup.Save() Then

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
        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub AccountGroupControlForm_AccountGroup_SelectedAccountGroupDetailChangedEvent() Handles AccountGroupControlForm_AccountGroup.SelectedAccountGroupDetailChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemDetails_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemDetails_Cancel.Click

            AccountGroupControlForm_AccountGroup.DetailsDataGridView.CancelNewItemRow()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemDetails_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemDetails_Delete.Click

            AccountGroupControlForm_AccountGroup.DeleteSelectedDetail()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemFilter_ShowInactive_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemFilter_ShowInactive.CheckedChanged

            AccountGroupControlForm_AccountGroup.ShowInactiveAccounts = ButtonItemFilter_ShowInactive.Checked

        End Sub

#End Region

#End Region

    End Class

End Namespace