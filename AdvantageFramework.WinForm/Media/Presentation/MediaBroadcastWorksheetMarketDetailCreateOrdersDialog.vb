Namespace Media.Presentation

	Public Class MediaBroadcastWorksheetMarketDetailCreateOrdersDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

		Protected _ViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketCreateOrdersViewModel = Nothing
		Protected _Controller As AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController = Nothing
        Protected _MediaBroadcastWorksheetMarketDetailsViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketDetailsViewModel = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property MediaBroadcastWorksheetMarketCreateOrdersViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketCreateOrdersViewModel
			Get
				MediaBroadcastWorksheetMarketCreateOrdersViewModel = _ViewModel
			End Get
		End Property

#End Region

#Region " Methods "

		Private Sub New(ByRef MediaBroadcastWorksheetMarketDetailsViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketDetailsViewModel)

			' This call is required by the designer.
			InitializeComponent()

			_MediaBroadcastWorksheetMarketDetailsViewModel = MediaBroadcastWorksheetMarketDetailsViewModel

		End Sub
		Private Sub LoadViewModel()

			_ViewModel = _Controller.MarketCreateOrders_Load(_MediaBroadcastWorksheetMarketDetailsViewModel)

		End Sub
		Private Sub FormatControls()

			DateEditForm_StartDate.Properties.MinValue = _ViewModel.WorksheetStartDates.Min
			DateEditForm_StartDate.Properties.MaxValue = _ViewModel.WorksheetEndDates.Max

            DateEditForm_EndDate.Properties.MinValue = _ViewModel.MinEndDateAllowed
            DateEditForm_EndDate.Properties.MaxValue = _ViewModel.WorksheetEndDates.Max

			If _ViewModel.Worksheet.MediaCalendarTypeID = AdvantageFramework.DTO.Media.CalendarTypes.Broadcast Then

				DateEditForm_StartDate.Properties.FirstDayOfWeek = DayOfWeek.Monday
				DateEditForm_EndDate.Properties.FirstDayOfWeek = DayOfWeek.Monday

			End If

            CheckBoxForm_CreateOrdersByWeek.SecurityEnabled = _ViewModel.CreateOrdersByWeekEnabled

        End Sub
		Private Sub SaveViewModel()

			_ViewModel.StartDate = DateEditForm_StartDate.EditValue
            _ViewModel.EndDate = DateEditForm_EndDate.EditValue
            _ViewModel.CreateOrdersByWeek = CheckBoxForm_CreateOrdersByWeek.Checked

        End Sub
		Private Sub RefreshViewModel()

			DateEditForm_StartDate.EditValue = _ViewModel.StartDate
			DateEditForm_EndDate.EditValue = _ViewModel.EndDate
            CheckBoxForm_CreateOrdersByWeek.Checked = _ViewModel.CreateOrdersByWeek

        End Sub
		Private Sub SetControlPropertySettings()

			Me.ByPassUserEntryChanged = True
			Me.ShowUnsavedChangesOnFormClosing = False

            DateEditForm_StartDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False
            DateEditForm_StartDate.SetRequired(True)
            'DateEditForm_StartDate.SecurityEnabled = False

            DateEditForm_EndDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False
			DateEditForm_EndDate.SetRequired(True)

		End Sub

#Region "  Show Form Methods "

		Public Shared Function ShowFormDialog(ByRef MediaBroadcastWorksheetMarketDetailsViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketDetailsViewModel,
											  ByRef MediaBroadcastWorksheetMarketCreateOrdersViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketCreateOrdersViewModel) As System.Windows.Forms.DialogResult

			'objects
			Dim MediaBroadcastWorksheetMarketDetailCreateOrdersDialog As MediaBroadcastWorksheetMarketDetailCreateOrdersDialog = Nothing

			MediaBroadcastWorksheetMarketDetailCreateOrdersDialog = New MediaBroadcastWorksheetMarketDetailCreateOrdersDialog(MediaBroadcastWorksheetMarketDetailsViewModel)

			ShowFormDialog = MediaBroadcastWorksheetMarketDetailCreateOrdersDialog.ShowDialog()

			If ShowFormDialog = System.Windows.Forms.DialogResult.OK Then

				MediaBroadcastWorksheetMarketCreateOrdersViewModel = MediaBroadcastWorksheetMarketDetailCreateOrdersDialog.MediaBroadcastWorksheetMarketCreateOrdersViewModel

			End If

		End Function

#End Region

#Region "  Form Event Handlers "

		Private Sub MediaBroadcastWorksheetMarketDetailCreateOrdersDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

			_Controller = New AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController(Me.Session)

			SetControlPropertySettings()

		End Sub
		Private Sub MediaBroadcastWorksheetMarketDetailCreateOrdersDialog_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

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

			'objects
			Dim ErrorMessage As String = String.Empty

			Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Modifying)

			SaveViewModel()

			If _Controller.MarketCreateOrders_Validate(_ViewModel, ErrorMessage) Then

				Me.DialogResult = Windows.Forms.DialogResult.OK
				Me.Close()

			Else

				AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

			End If

			Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

		End Sub
		Private Sub ButtonForm_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonForm_Cancel.Click

			Me.DialogResult = Windows.Forms.DialogResult.Cancel
			Me.Close()

		End Sub
		Private Sub DateEditForm_StartDate_DisableCalendarDate(sender As Object, e As DevExpress.XtraEditors.Calendar.DisableCalendarDateEventArgs) Handles DateEditForm_StartDate.DisableCalendarDate

			If _ViewModel.WorksheetStartDates.Contains(e.Date) = False Then

				e.IsDisabled = True

			Else

				e.IsDisabled = False

			End If

		End Sub
		Private Sub DateEditForm_StartDate_DrawItem(sender As Object, e As DevExpress.XtraEditors.Calendar.CustomDrawDayNumberCellEventArgs) Handles DateEditForm_StartDate.DrawItem

			'objects
			Dim Brush As System.Drawing.Brush = Nothing
			Dim StringFormat As System.Drawing.StringFormat = Nothing
			Dim PopupControl As DevExpress.Utils.Win.IPopupControl = Nothing
			Dim PopupDateEditForm As DevExpress.XtraEditors.Popup.PopupDateEditForm = Nothing
			Dim CalendarControl As DevExpress.XtraEditors.Controls.CalendarControl = Nothing

			If _ViewModel.Worksheet.MediaCalendarTypeID = AdvantageFramework.DTO.Media.CalendarTypes.Broadcast Then

				PopupControl = CType(sender, DevExpress.Utils.Win.IPopupControl)
				PopupDateEditForm = TryCast(PopupControl.PopupWindow, DevExpress.XtraEditors.Popup.PopupDateEditForm)

				If PopupDateEditForm IsNot Nothing Then

					CalendarControl = PopupDateEditForm.Controls.OfType(Of DevExpress.XtraEditors.Controls.CalendarControl)().FirstOrDefault()

                    If CalendarControl IsNot Nothing AndAlso CalendarControl.View = DevExpress.XtraEditors.Controls.DateEditCalendarViewType.MonthInfo Then

                        If _Controller.MarketCreateOrders_IsInMonth(_ViewModel, e.Date, CalendarControl.DateTime.Month) Then

                            If e.Disabled = False Then

                                Brush = Drawing.Brushes.Black

                                StringFormat = New System.Drawing.StringFormat
                                StringFormat.Alignment = System.Drawing.StringAlignment.Center
                                StringFormat.LineAlignment = System.Drawing.StringAlignment.Center

                                e.Graphics.DrawString(e.Date.Day.ToString(), e.Style.Font, Brush, e.Bounds, StringFormat)

                                e.Handled = True

                            Else

                                Brush = Drawing.Brushes.Gray

                                StringFormat = New System.Drawing.StringFormat
                                StringFormat.Alignment = System.Drawing.StringAlignment.Center
                                StringFormat.LineAlignment = System.Drawing.StringAlignment.Center

                                e.Graphics.DrawString(e.Date.Day.ToString(), e.Style.Font, Brush, e.Bounds, StringFormat)

                                e.State = DevExpress.Utils.Drawing.ObjectState.Disabled

                                e.Handled = True

                            End If

                        Else

                            Brush = Drawing.Brushes.White

                            StringFormat = New System.Drawing.StringFormat
                            StringFormat.Alignment = System.Drawing.StringAlignment.Center
                            StringFormat.LineAlignment = System.Drawing.StringAlignment.Center

                            e.Graphics.DrawString(e.Date.Day.ToString(), e.Style.Font, Brush, e.Bounds, StringFormat)

                            e.Handled = True

                        End If

                    End If

                End If

			ElseIf _ViewModel.Worksheet.MediaCalendarTypeID = AdvantageFramework.DTO.Media.CalendarTypes.Calendar Then

				PopupControl = CType(sender, DevExpress.Utils.Win.IPopupControl)
				PopupDateEditForm = TryCast(PopupControl.PopupWindow, DevExpress.XtraEditors.Popup.PopupDateEditForm)

				If PopupDateEditForm IsNot Nothing Then

					CalendarControl = PopupDateEditForm.Controls.OfType(Of DevExpress.XtraEditors.Controls.CalendarControl)().FirstOrDefault()

					If CalendarControl IsNot Nothing Then

						If _Controller.MarketCreateOrders_IsInMonth(_ViewModel, e.Date, CalendarControl.DateTime.Month) Then

							If e.Disabled = False Then

								Brush = Drawing.Brushes.Black

								StringFormat = New System.Drawing.StringFormat
								StringFormat.Alignment = System.Drawing.StringAlignment.Center
								StringFormat.LineAlignment = System.Drawing.StringAlignment.Center

								e.Graphics.DrawString(e.Date.Day.ToString(), e.Style.Font, Brush, e.Bounds, StringFormat)

								e.Handled = True

							Else

								Brush = Drawing.Brushes.Gray

								StringFormat = New System.Drawing.StringFormat
								StringFormat.Alignment = System.Drawing.StringAlignment.Center
								StringFormat.LineAlignment = System.Drawing.StringAlignment.Center

								e.Graphics.DrawString(e.Date.Day.ToString(), e.Style.Font, Brush, e.Bounds, StringFormat)

								e.State = DevExpress.Utils.Drawing.ObjectState.Disabled

								e.Handled = True

							End If

						Else

							Brush = Drawing.Brushes.White

							StringFormat = New System.Drawing.StringFormat
							StringFormat.Alignment = System.Drawing.StringAlignment.Center
							StringFormat.LineAlignment = System.Drawing.StringAlignment.Center

							e.Graphics.DrawString(e.Date.Day.ToString(), e.Style.Font, Brush, e.Bounds, StringFormat)

							e.Handled = True

						End If

					End If

				End If

			End If

		End Sub
		Private Sub DateEditForm_StartDate_Popup(sender As Object, e As EventArgs) Handles DateEditForm_StartDate.Popup

			'objects
			Dim PopupControl As DevExpress.Utils.Win.IPopupControl = Nothing
			Dim PopupDateEditForm As DevExpress.XtraEditors.Popup.PopupDateEditForm = Nothing
			Dim CalendarControl As DevExpress.XtraEditors.Controls.CalendarControl = Nothing
			Dim DateTimeFormatInfo As System.Globalization.DateTimeFormatInfo = Nothing

			If _ViewModel.Worksheet.MediaCalendarTypeID = AdvantageFramework.DTO.Media.CalendarTypes.Broadcast Then

				PopupControl = CType(sender, DevExpress.Utils.Win.IPopupControl)
				PopupDateEditForm = TryCast(PopupControl.PopupWindow, DevExpress.XtraEditors.Popup.PopupDateEditForm)

				If PopupDateEditForm IsNot Nothing Then

					For Each CalendarControl In PopupDateEditForm.Controls.OfType(Of DevExpress.XtraEditors.Controls.CalendarControl)().ToList

						DateTimeFormatInfo = CType(CalendarControl.DateFormat.Clone(), System.Globalization.DateTimeFormatInfo)
						DateTimeFormatInfo.FirstDayOfWeek = DayOfWeek.Monday
						CalendarControl.DateFormat = DateTimeFormatInfo

						Try

							If DateEditForm_StartDate.EditValue <> Nothing Then

								If DateEditForm_StartDate.DateTime.Day = 1 Then

									CalendarControl.DateTime = CDate(_Controller.MarketCreateOrders_GetMonth(_ViewModel, DateEditForm_StartDate.EditValue) & "/01/" & _Controller.MarketCreateOrders_GetYear(_ViewModel, DateEditForm_StartDate.EditValue))

								Else

									CalendarControl.DateTime = CDate(_Controller.MarketCreateOrders_GetMonth(_ViewModel, DateEditForm_StartDate.EditValue) & "/02/" & _Controller.MarketCreateOrders_GetYear(_ViewModel, DateEditForm_StartDate.EditValue))

								End If

							End If

						Catch ex As Exception

						End Try

					Next

				End If

			End If

		End Sub
		Private Sub DateEditForm_EndDate_DisableCalendarDate(sender As Object, e As DevExpress.XtraEditors.Calendar.DisableCalendarDateEventArgs) Handles DateEditForm_EndDate.DisableCalendarDate

            'objects
            Dim PopupControl As DevExpress.Utils.Win.IPopupControl = Nothing
            Dim PopupDateEditForm As DevExpress.XtraEditors.Popup.PopupDateEditForm = Nothing
            Dim CalendarControl As DevExpress.XtraEditors.Controls.CalendarControl = Nothing

            If _ViewModel.Worksheet.MediaCalendarTypeID = AdvantageFramework.DTO.Media.CalendarTypes.Broadcast Then

                PopupControl = CType(sender, DevExpress.Utils.Win.IPopupControl)
                PopupDateEditForm = TryCast(PopupControl.PopupWindow, DevExpress.XtraEditors.Popup.PopupDateEditForm)

                If PopupDateEditForm IsNot Nothing Then

                    CalendarControl = PopupDateEditForm.Controls.OfType(Of DevExpress.XtraEditors.Controls.CalendarControl)().FirstOrDefault()

                    If CalendarControl IsNot Nothing AndAlso CalendarControl.View = DevExpress.XtraEditors.Controls.DateEditCalendarViewType.MonthInfo Then

                        If _ViewModel.WorksheetEndDates.Contains(e.Date) = False Then

                            e.IsDisabled = True

                        Else

                            e.IsDisabled = False

                        End If

                    Else

                        e.IsDisabled = False

                    End If

                Else

                    e.IsDisabled = False

                End If

            Else

                If _ViewModel.WorksheetEndDates.Contains(e.Date) = False Then

                    e.IsDisabled = True

                Else

                    e.IsDisabled = False

                End If

            End If

        End Sub
		Private Sub DateEditForm_EndDate_DrawItem(sender As Object, e As DevExpress.XtraEditors.Calendar.CustomDrawDayNumberCellEventArgs) Handles DateEditForm_EndDate.DrawItem

			'objects
			Dim Brush As System.Drawing.Brush = Nothing
			Dim StringFormat As System.Drawing.StringFormat = Nothing
			Dim PopupControl As DevExpress.Utils.Win.IPopupControl = Nothing
			Dim PopupDateEditForm As DevExpress.XtraEditors.Popup.PopupDateEditForm = Nothing
			Dim CalendarControl As DevExpress.XtraEditors.Controls.CalendarControl = Nothing

			If _ViewModel.Worksheet.MediaCalendarTypeID = AdvantageFramework.DTO.Media.CalendarTypes.Broadcast Then

				PopupControl = CType(sender, DevExpress.Utils.Win.IPopupControl)
				PopupDateEditForm = TryCast(PopupControl.PopupWindow, DevExpress.XtraEditors.Popup.PopupDateEditForm)

				If PopupDateEditForm IsNot Nothing Then

					CalendarControl = PopupDateEditForm.Controls.OfType(Of DevExpress.XtraEditors.Controls.CalendarControl)().FirstOrDefault()

                    If CalendarControl IsNot Nothing AndAlso CalendarControl.View = DevExpress.XtraEditors.Controls.DateEditCalendarViewType.MonthInfo Then

                        If _Controller.MarketCreateOrders_IsInMonth(_ViewModel, e.Date, CalendarControl.DateTime.Month) Then

							If e.Disabled = False Then

								Brush = Drawing.Brushes.Black

								StringFormat = New System.Drawing.StringFormat
								StringFormat.Alignment = System.Drawing.StringAlignment.Center
								StringFormat.LineAlignment = System.Drawing.StringAlignment.Center

								e.Graphics.DrawString(e.Date.Day.ToString(), e.Style.Font, Brush, e.Bounds, StringFormat)

								e.Handled = True

							Else

								Brush = Drawing.Brushes.Gray

								StringFormat = New System.Drawing.StringFormat
								StringFormat.Alignment = System.Drawing.StringAlignment.Center
								StringFormat.LineAlignment = System.Drawing.StringAlignment.Center

								e.Graphics.DrawString(e.Date.Day.ToString(), e.Style.Font, Brush, e.Bounds, StringFormat)

								e.State = DevExpress.Utils.Drawing.ObjectState.Disabled

								e.Handled = True

							End If

						Else

							Brush = Drawing.Brushes.White

							StringFormat = New System.Drawing.StringFormat
							StringFormat.Alignment = System.Drawing.StringAlignment.Center
							StringFormat.LineAlignment = System.Drawing.StringAlignment.Center

							e.Graphics.DrawString(e.Date.Day.ToString(), e.Style.Font, Brush, e.Bounds, StringFormat)

							e.Handled = True

						End If

					End If

				End If

			ElseIf _ViewModel.Worksheet.MediaCalendarTypeID = AdvantageFramework.DTO.Media.CalendarTypes.Calendar Then

				PopupControl = CType(sender, DevExpress.Utils.Win.IPopupControl)
				PopupDateEditForm = TryCast(PopupControl.PopupWindow, DevExpress.XtraEditors.Popup.PopupDateEditForm)

				If PopupDateEditForm IsNot Nothing Then

					CalendarControl = PopupDateEditForm.Controls.OfType(Of DevExpress.XtraEditors.Controls.CalendarControl)().FirstOrDefault()

					If CalendarControl IsNot Nothing Then

						If _Controller.MarketCreateOrders_IsInMonth(_ViewModel, e.Date, CalendarControl.DateTime.Month) Then

							If e.Disabled = False Then

								Brush = Drawing.Brushes.Black

								StringFormat = New System.Drawing.StringFormat
								StringFormat.Alignment = System.Drawing.StringAlignment.Center
								StringFormat.LineAlignment = System.Drawing.StringAlignment.Center

								e.Graphics.DrawString(e.Date.Day.ToString(), e.Style.Font, Brush, e.Bounds, StringFormat)

								e.Handled = True

							Else

								Brush = Drawing.Brushes.Gray

								StringFormat = New System.Drawing.StringFormat
								StringFormat.Alignment = System.Drawing.StringAlignment.Center
								StringFormat.LineAlignment = System.Drawing.StringAlignment.Center

								e.Graphics.DrawString(e.Date.Day.ToString(), e.Style.Font, Brush, e.Bounds, StringFormat)

								e.State = DevExpress.Utils.Drawing.ObjectState.Disabled

								e.Handled = True

							End If

						Else

							Brush = Drawing.Brushes.White

							StringFormat = New System.Drawing.StringFormat
							StringFormat.Alignment = System.Drawing.StringAlignment.Center
							StringFormat.LineAlignment = System.Drawing.StringAlignment.Center

							e.Graphics.DrawString(e.Date.Day.ToString(), e.Style.Font, Brush, e.Bounds, StringFormat)

							e.Handled = True

						End If

					End If

				End If

			End If

		End Sub
		Private Sub DateEditForm_EndDate_Popup(sender As Object, e As EventArgs) Handles DateEditForm_EndDate.Popup

			'objects
			Dim PopupControl As DevExpress.Utils.Win.IPopupControl = Nothing
			Dim PopupDateEditForm As DevExpress.XtraEditors.Popup.PopupDateEditForm = Nothing
			Dim CalendarControl As DevExpress.XtraEditors.Controls.CalendarControl = Nothing
			Dim DateTimeFormatInfo As System.Globalization.DateTimeFormatInfo = Nothing

			If _ViewModel.Worksheet.MediaCalendarTypeID = AdvantageFramework.DTO.Media.CalendarTypes.Broadcast Then

				PopupControl = CType(sender, DevExpress.Utils.Win.IPopupControl)
				PopupDateEditForm = TryCast(PopupControl.PopupWindow, DevExpress.XtraEditors.Popup.PopupDateEditForm)

				If PopupDateEditForm IsNot Nothing Then

					For Each CalendarControl In PopupDateEditForm.Controls.OfType(Of DevExpress.XtraEditors.Controls.CalendarControl)().ToList

						DateTimeFormatInfo = CType(CalendarControl.DateFormat.Clone(), System.Globalization.DateTimeFormatInfo)
						DateTimeFormatInfo.FirstDayOfWeek = DayOfWeek.Monday
						CalendarControl.DateFormat = DateTimeFormatInfo

						Try

							If DateEditForm_EndDate.EditValue <> Nothing Then

								If DateEditForm_EndDate.DateTime.Day = 1 Then

									CalendarControl.DateTime = CDate(_Controller.MarketCreateOrders_GetMonth(_ViewModel, DateEditForm_EndDate.EditValue) & "/01/" & _Controller.MarketCreateOrders_GetYear(_ViewModel, DateEditForm_EndDate.EditValue))

								Else

									CalendarControl.DateTime = CDate(_Controller.MarketCreateOrders_GetMonth(_ViewModel, DateEditForm_EndDate.EditValue) & "/02/" & _Controller.MarketCreateOrders_GetYear(_ViewModel, DateEditForm_EndDate.EditValue))

								End If

							End If

						Catch ex As Exception

						End Try

					Next

				End If

			End If

		End Sub

#End Region

#End Region

	End Class

End Namespace
