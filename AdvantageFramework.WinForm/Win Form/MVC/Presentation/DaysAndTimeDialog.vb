Namespace WinForm.MVC.Presentation

	Public Class DaysAndTimeDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

		Protected _ViewModel As AdvantageFramework.ViewModels.DaysAndTimeViewModel = Nothing
		Protected _Controller As AdvantageFramework.Controller.DaysAndTimeController = Nothing
		Protected _DaysAndTime As AdvantageFramework.DTO.DaysAndTime = Nothing

#End Region

#Region " Properties "

		Private ReadOnly Property DaysAndTime As AdvantageFramework.DTO.DaysAndTime
			Get
				DaysAndTime = _DaysAndTime
			End Get
		End Property

#End Region

#Region " Methods "

		Private Sub New(DaysAndTime As AdvantageFramework.DTO.DaysAndTime)

			' This call is required by the Windows Form Designer.
			InitializeComponent()

			' Add any initialization after the InitializeComponent() call.
			_DaysAndTime = DaysAndTime

		End Sub
		Private Sub LoadViewModel()

			_ViewModel = _Controller.Load(_DaysAndTime)

		End Sub
		Private Sub SaveViewModel()

			_ViewModel.DaysAndTime.Sunday = CheckBoxDays_Sunday.Checked
			_ViewModel.DaysAndTime.Monday = CheckBoxDays_Monday.Checked
			_ViewModel.DaysAndTime.Tuesday = CheckBoxDays_Tuesday.Checked
			_ViewModel.DaysAndTime.Wednesday = CheckBoxDays_Wednesday.Checked
			_ViewModel.DaysAndTime.Thursday = CheckBoxDays_Thursday.Checked
			_ViewModel.DaysAndTime.Friday = CheckBoxDays_Friday.Checked
			_ViewModel.DaysAndTime.Saturday = CheckBoxDays_Saturday.Checked

			_ViewModel.DaysAndTime.Days = TextBoxForm_Days.Text

			_ViewModel.DaysAndTime.StartTime = CDate(TimeEditForm_StartTime.EditValue).ToString("hh:mm tt")
			_ViewModel.DaysAndTime.EndTime = CDate(TimeEditForm_EndTime.EditValue).ToString("hh:mm tt")

		End Sub
		Private Sub RefreshViewModel()

			CheckBoxDays_Sunday.Checked = _ViewModel.DaysAndTime.Sunday
			CheckBoxDays_Monday.Checked = _ViewModel.DaysAndTime.Monday
			CheckBoxDays_Tuesday.Checked = _ViewModel.DaysAndTime.Tuesday
			CheckBoxDays_Wednesday.Checked = _ViewModel.DaysAndTime.Wednesday
			CheckBoxDays_Thursday.Checked = _ViewModel.DaysAndTime.Thursday
			CheckBoxDays_Friday.Checked = _ViewModel.DaysAndTime.Friday
			CheckBoxDays_Saturday.Checked = _ViewModel.DaysAndTime.Saturday

			TextBoxForm_Days.Text = _ViewModel.DaysAndTime.Days

			TimeEditForm_StartTime.EditValue = Now.Add(DateTime.ParseExact(_ViewModel.DaysAndTime.StartTime, "hh:mm tt", System.Globalization.CultureInfo.InvariantCulture).TimeOfDay)
			TimeEditForm_EndTime.EditValue = Now.Add(DateTime.ParseExact(_ViewModel.DaysAndTime.EndTime, "hh:mm tt", System.Globalization.CultureInfo.InvariantCulture).TimeOfDay)

		End Sub
		Private Sub SetControlPropertySettings()

			TimeEditForm_StartTime.ControlType = Presentation.Controls.TimeEdit.Type.Default
			TimeEditForm_EndTime.ControlType = Presentation.Controls.TimeEdit.Type.Default

		End Sub

#Region "  Show Form Methods "

		Public Shared Function ShowFormDialog(ByRef DaysAndTime As AdvantageFramework.DTO.DaysAndTime) As Windows.Forms.DialogResult

			'objects
			Dim DaysAndTimeDialog As AdvantageFramework.WinForm.MVC.Presentation.DaysAndTimeDialog = Nothing

			DaysAndTimeDialog = New AdvantageFramework.WinForm.MVC.Presentation.DaysAndTimeDialog(DaysAndTime)

			ShowFormDialog = DaysAndTimeDialog.ShowDialog()

			If ShowFormDialog = Windows.Forms.DialogResult.OK Then

				DaysAndTime = DaysAndTimeDialog.DaysAndTime

			End If

		End Function

#End Region

#Region "  Form Event Handlers "

		Private Sub DaysAndTimeDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

			_Controller = New AdvantageFramework.Controller.DaysAndTimeController(Me.Session)

			SetControlPropertySettings()

		End Sub

		Private Sub DaysAndTimeDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

			Me.SetFormActionAndShowWaitForm(WinForm.Presentation.Methods.FormActions.Loading)

			LoadViewModel()

			RefreshViewModel()

			Me.ClearChanged()

			Me.FormAction = WinForm.Presentation.FormActions.None

			Me.CloseWaitForm()

		End Sub

#End Region

#Region "  Control Event Handlers "

		Private Sub ButtonForm_OK_Click(sender As Object, e As EventArgs) Handles ButtonForm_OK.Click

			'objects
			Dim ErrorMessage As String = String.Empty

			If Me.Validator Then

				SaveViewModel()

				_DaysAndTime = _ViewModel.DaysAndTime

				If String.IsNullOrWhiteSpace(ErrorMessage) Then

					Me.DialogResult = Windows.Forms.DialogResult.OK
					Me.Close()

				Else

					AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

				End If

			Else

				For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

					ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

				Next

				AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

			End If

			Me.DialogResult = Windows.Forms.DialogResult.OK
			Me.Close()

		End Sub
		Private Sub ButtonForm_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonForm_Cancel.Click

			Me.DialogResult = Windows.Forms.DialogResult.Cancel
			Me.Close()

		End Sub

#End Region

#End Region

	End Class

End Namespace
