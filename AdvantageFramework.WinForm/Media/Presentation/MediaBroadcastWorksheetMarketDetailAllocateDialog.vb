Namespace Media.Presentation

	Public Class MediaBroadcastWorksheetMarketDetailAllocateDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

		Protected _ViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketDetailsAllocateViewModel = Nothing
		Protected _Controller As AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController = Nothing
		Protected _MediaBroadcastWorksheetMarketDetailsViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketDetailsViewModel = Nothing
		Protected _RowIndex As Integer = -1

#End Region

#Region " Properties "



#End Region

#Region " Methods "

		Private Sub New(ByRef MediaBroadcastWorksheetMarketDetailsAllocateViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketDetailsAllocateViewModel,
						ByRef MediaBroadcastWorksheetMarketDetailsViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketDetailsViewModel,
						RowIndex As Integer)

			' This call is required by the designer.
			InitializeComponent()

			_ViewModel = MediaBroadcastWorksheetMarketDetailsAllocateViewModel
			_MediaBroadcastWorksheetMarketDetailsViewModel = MediaBroadcastWorksheetMarketDetailsViewModel
			_RowIndex = RowIndex

		End Sub
		Private Sub LoadViewModel()

			_Controller.MarketDetailsAllocate_LoadBookend(_ViewModel, _MediaBroadcastWorksheetMarketDetailsViewModel, _RowIndex)

		End Sub
		Private Sub FormatControls()

			DateEditForm_StartDate.Properties.MinValue = _ViewModel.WorksheetDates.Min
			DateEditForm_StartDate.Properties.MaxValue = _ViewModel.WorksheetDates.Max

			If _ViewModel.Worksheet.MediaCalendarTypeID = AdvantageFramework.DTO.Media.CalendarTypes.Broadcast Then

				DateEditForm_StartDate.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.DateEdit.Type.Broadcast

			Else
				DateEditForm_StartDate.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.DateEdit.Type.Default

			End If

		End Sub
		Private Sub SaveViewModel()

			_ViewModel.StartDate = DateEditForm_StartDate.EditValue
			_ViewModel.Spots = NumericInputForm_Spots.EditValue

			_ViewModel.EveryDate = RadioButtonForm_EveryDate.Checked
			_ViewModel.EveryOtherDate = RadioButtonForm_EveryOtherDate.Checked
			_ViewModel.Every3rdDate = RadioButtonForm_Every3rdDate.Checked
			_ViewModel.Every4thDate = RadioButtonForm_Every4thDate.Checked

		End Sub
		Private Sub RefreshViewModel()

			DateEditForm_StartDate.EditValue = _ViewModel.StartDate
			NumericInputForm_Spots.EditValue = _ViewModel.Spots

			RadioButtonForm_EveryDate.Checked = _ViewModel.EveryDate
			RadioButtonForm_EveryOtherDate.Checked = _ViewModel.EveryOtherDate
			RadioButtonForm_Every3rdDate.Checked = _ViewModel.Every3rdDate
			RadioButtonForm_Every4thDate.Checked = _ViewModel.Every4thDate

		End Sub
		Private Sub SetControlPropertySettings()

			Me.ByPassUserEntryChanged = True
			Me.ShowUnsavedChangesOnFormClosing = False

			NumericInputForm_Spots.Properties.MinValue = 0
			NumericInputForm_Spots.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False
			NumericInputForm_Spots.SetRequired(True)

			DateEditForm_StartDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False
			DateEditForm_StartDate.SetRequired(True)

		End Sub

#Region "  Show Form Methods "

		Public Shared Function ShowFormDialog(ByRef MediaBroadcastWorksheetMarketDetailsAllocateViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketDetailsAllocateViewModel,
											  ByRef MediaBroadcastWorksheetMarketDetailsViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketDetailsViewModel,
											  RowIndex As Integer) As System.Windows.Forms.DialogResult

			'objects
			Dim MediaBroadcastWorksheetMarketDetailAllocateDialog As MediaBroadcastWorksheetMarketDetailAllocateDialog = Nothing

			MediaBroadcastWorksheetMarketDetailAllocateDialog = New MediaBroadcastWorksheetMarketDetailAllocateDialog(MediaBroadcastWorksheetMarketDetailsAllocateViewModel, MediaBroadcastWorksheetMarketDetailsViewModel, RowIndex)

			ShowFormDialog = MediaBroadcastWorksheetMarketDetailAllocateDialog.ShowDialog()

		End Function

#End Region

#Region "  Form Event Handlers "

		Private Sub MediaBroadcastWorksheetMarketDetailAllocateDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

			_Controller = New AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController(Me.Session)

			SetControlPropertySettings()

		End Sub
		Private Sub MediaBroadcastWorksheetMarketDetailAllocateDialog_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

			Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

			LoadViewModel()

			FormatControls()

			RefreshViewModel()

			Me.ClearChanged()

			Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

		End Sub

#End Region

#Region "  Control Event Handlers "

		Private Sub ButtonForm_OK_Click(sender As Object, e As EventArgs) Handles ButtonForm_OK.Click

			Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Modifying)

			SaveViewModel()

			Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

			Me.DialogResult = Windows.Forms.DialogResult.OK
			Me.Close()

		End Sub
		Private Sub ButtonForm_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonForm_Cancel.Click

			Me.DialogResult = Windows.Forms.DialogResult.Cancel
			Me.Close()

		End Sub
		Private Sub DateEditForm_StartDate_DisableCalendarDate(sender As Object, e As DevExpress.XtraEditors.Calendar.DisableCalendarDateEventArgs) Handles DateEditForm_StartDate.DisableCalendarDate

			If _ViewModel.WorksheetDates.Contains(e.Date) = False OrElse _MediaBroadcastWorksheetMarketDetailsViewModel.HiatusDataTable.Rows(0)(_MediaBroadcastWorksheetMarketDetailsViewModel.DetailDates(e.Date)) = True Then

				e.IsDisabled = True

			Else

				e.IsDisabled = False

			End If

		End Sub
		Private Sub DateEditForm_StartDate_DrawItem(sender As Object, e As DevExpress.XtraEditors.Calendar.CustomDrawDayNumberCellEventArgs) Handles DateEditForm_StartDate.DrawItem

			'objects
			Dim Brush As System.Drawing.Brush = Nothing
			Dim StringFormat As System.Drawing.StringFormat = Nothing

			If e.Disabled Then

				Brush = Drawing.Brushes.Gray

				StringFormat = New System.Drawing.StringFormat
				StringFormat.Alignment = System.Drawing.StringAlignment.Center
				StringFormat.LineAlignment = System.Drawing.StringAlignment.Center

				e.Graphics.DrawString(e.Date.Day.ToString(), e.Style.Font, Brush, e.Bounds, StringFormat)

				e.State = DevExpress.Utils.Drawing.ObjectState.Disabled

				e.Handled = True

			Else

				Brush = Drawing.Brushes.Black

				StringFormat = New System.Drawing.StringFormat
				StringFormat.Alignment = System.Drawing.StringAlignment.Center
				StringFormat.LineAlignment = System.Drawing.StringAlignment.Center

				e.Graphics.DrawString(e.Date.Day.ToString(), e.Style.Font, Brush, e.Bounds, StringFormat)

				e.Handled = True

			End If

		End Sub
		Private Sub NumericInputForm_Spots_EditValueChanged(sender As Object, e As EventArgs) Handles NumericInputForm_Spots.EditValueChanged

			'objects
			Dim WarnUser As Boolean = False

			If _ViewModel IsNot Nothing AndAlso _ViewModel.IsBookend Then

				_Controller.MarketDetailsAllocate_SpotsChanging(_ViewModel, NumericInputForm_Spots.EditValue, WarnUser)

				If WarnUser Then

					AdvantageFramework.WinForm.MessageBox.Show("WARNING: Bookends must be an even number of spots.")

					NumericInputForm_Spots.EditValue = NumericInputForm_Spots.OldEditValue

				End If

			End If

		End Sub

#End Region

#End Region

	End Class

End Namespace
