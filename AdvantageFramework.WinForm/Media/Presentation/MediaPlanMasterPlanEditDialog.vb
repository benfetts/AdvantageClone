Namespace Media.Presentation

	Public Class MediaPlanMasterPlanEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

		Private _MediaPlanMasterPlanID As Integer = 0
		Private _MediaPlanMasterPlan As AdvantageFramework.Database.Entities.MediaPlanMasterPlan = Nothing
		Private _MediaPlanMasterPlanChanged As Boolean = False

#End Region

#Region " Properties "

		Private ReadOnly Property MediaPlanMasterPlanID As Integer
			Get
				MediaPlanMasterPlanID = _MediaPlanMasterPlanID
			End Get
		End Property

#End Region

#Region " Methods "

		Private Sub New(ByVal MediaPlanMasterPlanID As Integer)

            ' This call is required by the designer.
            InitializeComponent()

			_MediaPlanMasterPlanID = MediaPlanMasterPlanID

		End Sub
		Private Sub EnableOrDisableActions()

			RibbonBarOptions_Dashboard.Visible = (MediaPlanMasterPlanForm_MasterPlan.TabControlControl_MasterPlanDetails.SelectedTab Is MediaPlanMasterPlanForm_MasterPlan.TabItemMasterPlanDetails_DashboardTab AndAlso MediaPlanMasterPlanForm_MasterPlan.Enabled)

			ButtonItemPrintingOptions_AddColumnsHeadersToAllEstimates.Enabled = MediaPlanMasterPlanForm_MasterPlan.AddColumnsHeadersToAllEstimatesEnabled

			If ButtonItemPrintingOptions_AddColumnsHeadersToAllEstimates.Enabled = False Then

				ButtonItemPrintingOptions_AddColumnsHeadersToAllEstimates.Checked = False

			End If

		End Sub

#Region "  Show Form Methods "

		Public Shared Function ShowFormDialog(ByRef MediaPlanMasterPlanID As Integer) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaPlanMasterPlanEditDialog As AdvantageFramework.Media.Presentation.MediaPlanMasterPlanEditDialog = Nothing

			MediaPlanMasterPlanEditDialog = New AdvantageFramework.Media.Presentation.MediaPlanMasterPlanEditDialog(MediaPlanMasterPlanID)

			ShowFormDialog = MediaPlanMasterPlanEditDialog.ShowDialog()

			If ShowFormDialog = System.Windows.Forms.DialogResult.OK Then

				MediaPlanMasterPlanID = MediaPlanMasterPlanEditDialog.MediaPlanMasterPlanID

			End If

		End Function

#End Region

#Region "  Form Event Handlers "

		Private Sub MediaPlanMasterPlanEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

			ButtonItemActions_Add.Image = My.Resources.AddImage
			ButtonItemActions_Save.Image = My.Resources.SaveImage
			ButtonItemActions_Cancel.Image = My.Resources.CancelImage
			ButtonItemActions_Print.Image = My.Resources.PrintImage

			ButtonItemDashboard_Edit.Image = My.Resources.EditImage

			ButtonItemPrintingOptions_ShowHiatusDates.Image = My.Resources.SetHiatusImage
			ButtonItemPrintingOptions_AddColumnsHeadersToAllEstimates.Image = My.Resources.ShowAllColumnsImage
			ButtonItemPrintingOptions_GroupByMediaTypes.Image = My.Resources.MediaImage

			If _MediaPlanMasterPlanID > 0 Then

				ButtonItemActions_Add.Visible = False
				ButtonItemActions_Save.Visible = True

			Else

				ButtonItemActions_Add.Visible = True
				ButtonItemActions_Save.Visible = False

			End If

			If MediaPlanMasterPlanForm_MasterPlan.LoadControl(_MediaPlanMasterPlanID) = False Then

				AdvantageFramework.WinForm.MessageBox.Show("The master plan you are trying to edit does not exist anymore.")
				Me.Close()

			Else

				EnableOrDisableActions()

			End If

		End Sub
		Private Sub MediaPlanMasterPlanEditDialog_ClearChangedEvent() Handles Me.ClearChangedEvent

			ButtonItemActions_Save.Enabled = Me.UserEntryChanged
			_MediaPlanMasterPlanChanged = False

		End Sub
		Private Sub MediaPlanMasterPlanEditDialog_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

			ButtonItemActions_Save.Enabled = Me.UserEntryChanged
			_MediaPlanMasterPlanChanged = True

		End Sub
		Private Sub MediaPlanMasterPlanEditDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

			If Me.IsFormClosing = False Then

				MediaPlanMasterPlanForm_MasterPlan.TextBoxTopSection_Description.Focus()

			End If

		End Sub

#End Region

#Region "  Control Event Handlers "

		Private Sub ButtonItemActions_Add_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Add.Click

            'objects
            Dim MediaPlanMasterPlan As AdvantageFramework.Database.Entities.MediaPlanMasterPlan = Nothing
			Dim ErrorMessage As String = Nothing

			If Me.Validator Then

				MediaPlanMasterPlanForm_MasterPlan.TextBoxTopSection_Comment.CheckSpelling()

				Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Adding
				Me.ShowWaitForm()
				Me.ShowWaitForm("Adding...")

				Try

					MediaPlanMasterPlanForm_MasterPlan.Insert(_MediaPlanMasterPlanID)

					Me.ClearChanged()

					Me.DialogResult = Windows.Forms.DialogResult.OK
					Me.Close()

				Catch ex As Exception
					AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
				End Try

				Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None
				Me.CloseWaitForm()

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

			If Me.Validator Then

				MediaPlanMasterPlanForm_MasterPlan.TextBoxTopSection_Comment.CheckSpelling()

				Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Saving
				Me.ShowWaitForm()
				Me.ShowWaitForm("Saving...")

				Try

					MediaPlanMasterPlanForm_MasterPlan.Save()

					Me.ClearChanged()

				Catch ex As Exception
					AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
				End Try

				Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None
				Me.CloseWaitForm()

			Else

				For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

					ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

				Next

				AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

			End If

		End Sub
		Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Cancel.Click

			MediaPlanMasterPlanForm_MasterPlan.ClearControl()

			MediaPlanMasterPlanForm_MasterPlan.LoadControl(_MediaPlanMasterPlanID)

			EnableOrDisableActions()

			Me.ClearChanged()

		End Sub
		Private Sub ButtonItemSystem_Close_Click(sender As Object, e As EventArgs) Handles ButtonItemSystem_Close.Click

			Me.DialogResult = Windows.Forms.DialogResult.OK
			Me.Close()

		End Sub
		Private Sub ButtonItemActions_Print_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Print.Click

			'objects
			Dim AddColumnsHeadersToAllEstimates As Boolean = False

			If _MediaPlanMasterPlanID <> 0 Then

				If ButtonItemPrintingOptions_AddColumnsHeadersToAllEstimates.Enabled = False Then

					AddColumnsHeadersToAllEstimates = True

				Else

					AddColumnsHeadersToAllEstimates = ButtonItemPrintingOptions_AddColumnsHeadersToAllEstimates.Checked

				End If

				AdvantageFramework.Media.Presentation.PrintMasterPlan(Me.DefaultLookAndFeel.LookAndFeel, Me.Session, _MediaPlanMasterPlanID, ButtonItemPrintingOptions_ShowHiatusDates.Checked, AddColumnsHeadersToAllEstimates, ButtonItemPrintingOptions_GroupByMediaTypes.Checked)

			End If

		End Sub
		Private Sub ButtonItemDashboard_Edit_Click(sender As Object, e As EventArgs) Handles ButtonItemDashboard_Edit.Click

			MediaPlanMasterPlanForm_MasterPlan.EditDashboard()

		End Sub
		Private Sub MediaPlanMasterPlanRightSide_MasterPlan_EnableOrDisableActionsEvent() Handles MediaPlanMasterPlanForm_MasterPlan.EnableOrDisableActionsEvent

			EnableOrDisableActions()

		End Sub
		Private Sub MediaPlanMasterPlanRightSide_MasterPlan_EnableOrDisableAddColumnHeadersEvent() Handles MediaPlanMasterPlanForm_MasterPlan.EnableOrDisableAddColumnHeadersEvent

			ButtonItemPrintingOptions_AddColumnsHeadersToAllEstimates.Enabled = MediaPlanMasterPlanForm_MasterPlan.AddColumnsHeadersToAllEstimatesEnabled

			If ButtonItemPrintingOptions_AddColumnsHeadersToAllEstimates.Enabled = False Then

				ButtonItemPrintingOptions_AddColumnsHeadersToAllEstimates.Checked = False

			End If

		End Sub
		Private Sub MediaPlanMasterPlanForm_MasterPlan_MediaPlanMasterPlanChangedEvent() Handles MediaPlanMasterPlanForm_MasterPlan.MediaPlanMasterPlanChangedEvent

			_MediaPlanMasterPlanChanged = True

		End Sub

#End Region

#End Region

	End Class

End Namespace
