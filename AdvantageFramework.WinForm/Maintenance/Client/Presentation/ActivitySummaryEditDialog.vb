Namespace Maintenance.Client.Presentation

    Public Class ActivitySummaryEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _ClientCode As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _ProductCode As String = Nothing
        Private _IsNewBusiness As Boolean = False

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, ByVal IsNewBusiness As Boolean)

            ' This call is required by the designer.
            InitializeComponent()

            _ClientCode = ClientCode
            _DivisionCode = DivisionCode
            _ProductCode = ProductCode
            _IsNewBusiness = IsNewBusiness

        End Sub
        Private Sub EnableOrDisableActions()

            ButtonItemDiary_Edit.Enabled = ActivitySummaryControlForm_ActivitySummary.SelectedCRMActivityIsDiaryEntry

            ButtonItemCompetitors_Cancel.Enabled = ActivitySummaryControlForm_ActivitySummary.CompetitorsIsNewItemRow
            ButtonItemCompetitors_Delete.Enabled = ActivitySummaryControlForm_ActivitySummary.CompetitorsHasOnlyOneSelectedRow

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, ByVal IsNewBusiness As Boolean) As System.Windows.Forms.DialogResult

            'objects
            Dim ActivitySummaryEditDialog As AdvantageFramework.Maintenance.Client.Presentation.ActivitySummaryEditDialog = Nothing

            ActivitySummaryEditDialog = New AdvantageFramework.Maintenance.Client.Presentation.ActivitySummaryEditDialog(ClientCode, DivisionCode, ProductCode, IsNewBusiness)

            ShowFormDialog = ActivitySummaryEditDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub ActivitySummaryEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            ButtonItemCompetitors_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemCompetitors_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            ButtonItemDiary_Add.Image = AdvantageFramework.My.Resources.DetailAddImage
            ButtonItemDiary_Edit.Image = AdvantageFramework.My.Resources.EditImage

            ButtonItemActions_Save.SecurityEnabled = ActivitySummaryControlForm_ActivitySummary.CanUserUpdateInClientMaintenance
            ButtonItemCompetitors_Delete.SecurityEnabled = ActivitySummaryControlForm_ActivitySummary.CanUserUpdateInClientMaintenance
            ButtonItemDiary_Add.SecurityEnabled = ActivitySummaryControlForm_ActivitySummary.CanUserUpdateInClientMaintenance
            ButtonItemDiary_Edit.SecurityEnabled = ActivitySummaryControlForm_ActivitySummary.CanUserUpdateInClientMaintenance

            Me.ShowUnsavedChangesOnFormClosing = ActivitySummaryControlForm_ActivitySummary.CanUserUpdateInClientMaintenance

            ActivitySummaryControlForm_ActivitySummary.LoadControl(_ClientCode, _DivisionCode, _ProductCode, _IsNewBusiness)

            EnableOrDisableActions()

        End Sub
        Private Sub ActivitySummaryEditDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            ActivitySummaryControlForm_ActivitySummary.DateTimePickerActivitySummary_LeadDate.Focus()

        End Sub
        Private Sub ActivitySummaryEditDialog_UserEntryChangedEvent(Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub ActivitySummaryEditDialog_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = False

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim ErrorMessage As String = ""

            If Me.Validator Then

                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Saving
                Me.ShowWaitForm("Saving...")

                Try

                    If ActivitySummaryControlForm_ActivitySummary.Save() Then

                        Me.ClearChanged()

                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()

                    End If

                Catch ex As Exception
                    ErrorMessage = ex.Message
                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)
                End Try

                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None
                Me.CloseWaitForm()

            Else

                For Each LastFailedValidationResult In SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ButtonItemDiary_Add_Click(sender As Object, e As EventArgs) Handles ButtonItemDiary_Add.Click

            If AdvantageFramework.Maintenance.Client.Presentation.DiaryAddDialog.ShowFormDialog(11, 58, _ClientCode, _DivisionCode, _ProductCode) = Windows.Forms.DialogResult.OK Then

                ActivitySummaryControlForm_ActivitySummary.RefreshActivitySummary()

            End If

        End Sub
        Private Sub ButtonItemDiary_Edit_Click(sender As Object, e As EventArgs) Handles ButtonItemDiary_Edit.Click

            If AdvantageFramework.Maintenance.Client.Presentation.DiaryAddDialog.ShowFormDialog(ActivitySummaryControlForm_ActivitySummary.SelectedCRMActivityAlertID) = Windows.Forms.DialogResult.OK Then

                ActivitySummaryControlForm_ActivitySummary.RefreshActivitySummary()

            End If

        End Sub
        Private Sub ButtonItemCompetitors_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemCompetitors_Cancel.Click

            ActivitySummaryControlForm_ActivitySummary.CancelAddNewActivityCompetitor()

        End Sub
        Private Sub ButtonItemCompetitors_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemCompetitors_Delete.Click

            ActivitySummaryControlForm_ActivitySummary.DeleteSelectedActivityCompetitor()

        End Sub
        Private Sub ActivitySummaryControlForm_ActivitySummary_CRMActivitySelectionChangedEvent() Handles ActivitySummaryControlForm_ActivitySummary.CRMActivitySelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub ActivitySummaryControlForm_ActivitySummary_CompetitorInitNewRowEvent() Handles ActivitySummaryControlForm_ActivitySummary.CompetitorInitNewRowEvent

            ButtonItemCompetitors_Delete.Enabled = False
            ButtonItemCompetitors_Cancel.Enabled = True

        End Sub
        Private Sub ActivitySummaryControlForm_ActivitySummary_CompetitorSelectionChangedEvent() Handles ActivitySummaryControlForm_ActivitySummary.CompetitorSelectionChangedEvent

            EnableOrDisableActions()

        End Sub

#End Region

#End Region

    End Class

End Namespace