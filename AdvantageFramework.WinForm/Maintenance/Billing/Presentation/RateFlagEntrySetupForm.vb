Namespace Maintenance.Billing.Presentation

    Public Class RateFlagEntrySetupForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub LoadGrid()

            RateFlagEntryControlForm_RateFlagEntry.ClearControl()

            RateFlagEntryControlForm_RateFlagEntry.Enabled = RateFlagEntryControlForm_RateFlagEntry.LoadControl(BillingRateLevelID:=-1)

            Me.ClearChanged()

        End Sub
        Private Sub EnableOrDisableActions()

            ButtonItemActions_Delete.Enabled = If(RateFlagEntryControlForm_RateFlagEntry.ViewingAll, False, RateFlagEntryControlForm_RateFlagEntry.HasASelectedBillingRateDetail)
            ButtonItemActions_Copy.Enabled = If(RateFlagEntryControlForm_RateFlagEntry.ViewingAll = False AndAlso RateFlagEntryControlForm_RateFlagEntry.AllowBillingRateDetailCopy AndAlso RateFlagEntryControlForm_RateFlagEntry.HasOnlyOneSelectedBillingRateDetail, True, False)
            ButtonItemActions_Cancel.Enabled = RateFlagEntryControlForm_RateFlagEntry.IsSelectedDetailNewItemRow
            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub CheckForUnsavedChanges()

            If Me.CheckUserEntryChangedSetting Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    If Me.Validator Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                        Try

                            RateFlagEntryControlForm_RateFlagEntry.Save()

                            Me.ClearChanged()

                        Catch ex As Exception
                            AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                        End Try

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        Me.ClearValidations()

                    End If

                End If

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim RateFlagEntrySetupForm As AdvantageFramework.Maintenance.Billing.Presentation.RateFlagEntrySetupForm = Nothing

            RateFlagEntrySetupForm = New AdvantageFramework.Maintenance.Billing.Presentation.RateFlagEntrySetupForm()

            RateFlagEntrySetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub RateFlagEntrySetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemActions_Calculate.Image = AdvantageFramework.My.Resources.CalculatorImage
            ButtonItemActions_Copy.Image = AdvantageFramework.My.Resources.CopyImage

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            Try

                LoadGrid()

            Catch ex As Exception

            End Try

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            'RateFlagEntryControlForm_RateFlagEntry.ViewAll()

            EnableOrDisableActions()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim ErrorMessage As String = ""

            If Me.Validator Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                Try

                    RateFlagEntryControlForm_RateFlagEntry.Save()

                    Me.ClearChanged()

                    EnableOrDisableActions()

                Catch ex As Exception
                    ErrorMessage = ex.Message
                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)
                End Try

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            If RateFlagEntryControlForm_RateFlagEntry.HasASelectedBillingRateDetail Then

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

                    Try

                        RateFlagEntryControlForm_RateFlagEntry.Delete()

                    Catch ex As Exception
                        AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select a billing rate detail to delete.")

            End If

            'RateFlagEntryControlForm_RateFlagEntry.DeleteSelectedBillingRateDetail()

        End Sub
        Private Sub ButtonItemActions_Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Export.Click

            RateFlagEntryControlForm_RateFlagEntry.ExportBillingRateDetails()

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

            RateFlagEntryControlForm_RateFlagEntry.CancelNewItemRow()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemActions_Calculate_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_Calculate.Click

            If AdvantageFramework.Maintenance.Billing.Presentation.RateFlagTesterDialog.ShowFormDialog = Windows.Forms.DialogResult.OK Then

                'do nothing

            End If

        End Sub
        Private Sub ButtonItemActions_Copy_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemActions_Copy.Click

            RateFlagEntryControlForm_RateFlagEntry.CopySelectedRateFlag()

        End Sub
        Private Sub RateFlagEntryControlForm_RateFlagEntry_BillingRateDetailInitNewRow() Handles RateFlagEntryControlForm_RateFlagEntry.BillingRateDetailInitNewRow

            EnableOrDisableActions()

        End Sub
        Private Sub RateFlagEntryControlForm_RateFlagEntry_SelectedBillingRateDetailChanged() Handles RateFlagEntryControlForm_RateFlagEntry.SelectedBillingRateDetailChanged

            EnableOrDisableActions()

        End Sub
        Private Sub RateFlagEntryControlForm_RateFlagEntry_SelectedBillingRateLevelChanged() Handles RateFlagEntryControlForm_RateFlagEntry.SelectedBillingRateLevelChanged

            EnableOrDisableActions()

        End Sub
        Private Sub RateFlagEntryControlForm_RateFlagEntry_SelectedBillingRateLevelChanging() Handles RateFlagEntryControlForm_RateFlagEntry.SelectedBillingRateLevelChanging

            CheckForUnsavedChanges()

        End Sub

#End Region

#End Region

    End Class

End Namespace