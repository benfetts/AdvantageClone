Namespace Maintenance.Media.Presentation

    Public Class MediaPlanTemplateEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _MediaPlanTemplateHeaderID As Nullable(Of Integer) = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property MediaPlanTemplateHeaderID As Nullable(Of Integer)
            Get
                MediaPlanTemplateHeaderID = _MediaPlanTemplateHeaderID
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByRef MediaPlanTemplateHeaderID As Nullable(Of Integer))

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _MediaPlanTemplateHeaderID = MediaPlanTemplateHeaderID

        End Sub
        Private Sub SetupViewModel()

            MediaPlanTemplateControl_PlanTemplate.LoadControl(_MediaPlanTemplateHeaderID)

        End Sub
        Private Sub RefreshViewModel()

            ButtonItemActions_Add.Visible = MediaPlanTemplateControl_PlanTemplate.ViewModel.AddEnabled
            ButtonItemActions_Update.Visible = MediaPlanTemplateControl_PlanTemplate.ViewModel.UpdateEnabled

            ButtonItemDetails_Cancel.Enabled = MediaPlanTemplateControl_PlanTemplate.ViewModel.PlanEstimateTemplates_CancelEnabled
            ButtonItemDetails_Delete.Enabled = MediaPlanTemplateControl_PlanTemplate.ViewModel.PlanEstimateTemplates_DeleteEnabled

        End Sub
        Private Sub SetControlPropertySettings()



        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef MediaPlanTemplateHeaderID As Nullable(Of Integer)) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaPlanTemplateEditDialog As AdvantageFramework.Maintenance.Media.Presentation.MediaPlanTemplateEditDialog = Nothing

            MediaPlanTemplateEditDialog = New AdvantageFramework.Maintenance.Media.Presentation.MediaPlanTemplateEditDialog(MediaPlanTemplateHeaderID)

            ShowFormDialog = MediaPlanTemplateEditDialog.ShowDialog()

            MediaPlanTemplateHeaderID = MediaPlanTemplateEditDialog.MediaPlanTemplateHeaderID

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaPlanTemplateEditDialog_Load(sender As Object, e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Update.Image = AdvantageFramework.My.Resources.UpdateImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            ButtonItemDetails_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemDetails_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            SetControlPropertySettings()

        End Sub
        Private Sub MediaPlanTemplateEditDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

            SetupViewModel()

            RefreshViewModel()

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

            RibbonBarOptions_Actions.ResetCachedContentSize()

            RibbonBarOptions_Actions.Refresh()

            RibbonBarOptions_Actions.Width = RibbonBarOptions_Actions.GetAutoSizeWidth

            RibbonBarOptions_Actions.Refresh()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Add_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Add.Click

            'objects
            Dim ErrorMessage As String = String.Empty

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If Me.Validator Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Adding)

                    If MediaPlanTemplateControl_PlanTemplate.Add() Then

                        _MediaPlanTemplateHeaderID = MediaPlanTemplateControl_PlanTemplate.ViewModel.PlanTemplate.ID

                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()

                    End If

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                Else

                    For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                        ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                    Next

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Cancel.Click

            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ButtonItemDetails_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemDetails_Cancel.Click

            MediaPlanTemplateControl_PlanTemplate.PlanEstimateTemplates_CancelNewItemRow()

            RefreshViewModel()

        End Sub
        Private Sub ButtonItemDetails_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemDetails_Delete.Click

            MediaPlanTemplateControl_PlanTemplate.PlanEstimateTemplates_Delete()

            RefreshViewModel()

        End Sub
        Private Sub MediaPlanTemplateControl_PlanTemplate_TemplateDetails_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles MediaPlanTemplateControl_PlanTemplate.TemplateDetails_InitNewRowEvent

            RefreshViewModel()

        End Sub
        Private Sub MediaPlanTemplateControl_PlanTemplate_TemplateDetails_FocusedRowChangedEvent(sender As Object, e As EventArgs) Handles MediaPlanTemplateControl_PlanTemplate.TemplateDetails_SelectionChangedEvent

            RefreshViewModel()

        End Sub

#End Region

#End Region

    End Class

End Namespace
