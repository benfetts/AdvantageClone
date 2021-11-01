Namespace Media.Presentation

	Public Class MediaPlanDetailLevelLineDataUpdate4WeekStartDateDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

		Private _MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan = Nothing
		Private _MediaPlanDetailLevelLineDatas As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData) = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

		Private Sub New(MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan, MediaPlanDetailLevelLineDatas As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData))

			' This call is required by the designer.
			InitializeComponent()

			_MediaPlan = MediaPlan
			_MediaPlanDetailLevelLineDatas = MediaPlanDetailLevelLineDatas

		End Sub
		Private Function GetEndDateForRow(RowIndex As Integer) As Date

			'objects
			Dim EndDate As Date = Date.MinValue

			For Each MediaPlanDetailLevel In _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.TagType = AdvantageFramework.MediaPlanning.TagTypes.EndDate)

				For Each MediaPlanDetailLevelLine In MediaPlanDetailLevel.MediaPlanDetailLevelLines.Where(Function(Entity) Entity.RowIndex = RowIndex).ToList

					Try

						If MediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags.SingleOrDefault IsNot Nothing Then

							EndDate = MediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags.SingleOrDefault.EndDate.GetValueOrDefault(Date.MinValue)

						End If

					Catch ex As Exception
						EndDate = Date.MinValue
					End Try

					If EndDate <> Date.MinValue Then

						Exit For

					End If

				Next

				If EndDate <> Date.MinValue Then

					Exit For

				End If

			Next

			GetEndDateForRow = EndDate

		End Function
		Private Function GetStartDateForRow(RowIndex As Integer) As Date

			'objects
			Dim StartDate As Date = Date.MinValue

			For Each MediaPlanDetailLevel In _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.TagType = AdvantageFramework.MediaPlanning.TagTypes.StartDate)

				For Each MediaPlanDetailLevelLine In MediaPlanDetailLevel.MediaPlanDetailLevelLines.Where(Function(Entity) Entity.RowIndex = RowIndex).ToList

					Try

						If MediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags.SingleOrDefault IsNot Nothing Then

							StartDate = MediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags.SingleOrDefault.StartDate.GetValueOrDefault(Date.MinValue)

						End If

					Catch ex As Exception
						StartDate = Date.MinValue
					End Try

					If StartDate <> Date.MinValue Then

						Exit For

					End If

				Next

				If StartDate <> Date.MinValue Then

					Exit For

				End If

			Next

			GetStartDateForRow = StartDate

		End Function

#Region "  Show Form Methods "

		Public Shared Function ShowFormDialog(MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan, MediaPlanDetailLevelLineDatas As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData)) As System.Windows.Forms.DialogResult

			'objects
			Dim MediaPlanDetailLevelLineDataUpdate4WeekStartDateDialog As AdvantageFramework.Media.Presentation.MediaPlanDetailLevelLineDataUpdate4WeekStartDateDialog = Nothing

			MediaPlanDetailLevelLineDataUpdate4WeekStartDateDialog = New AdvantageFramework.Media.Presentation.MediaPlanDetailLevelLineDataUpdate4WeekStartDateDialog(MediaPlan, MediaPlanDetailLevelLineDatas)

			ShowFormDialog = MediaPlanDetailLevelLineDataUpdate4WeekStartDateDialog.ShowDialog()

		End Function

#End Region

#Region "  Form Event Handlers "

		Private Sub MediaPlanDetailLevelLineDataUpdate4WeekStartDateDialog_Load(sender As Object, e As System.EventArgs) Handles Me.Load

			'objects
			Dim RowStartDate As Date = Date.MinValue
			Dim RowEndDate As Date = Date.MinValue

			Me.ByPassUserEntryChanged = True
			Me.ShowUnsavedChangesOnFormClosing = False

			DateEditForm_StartDate.ByPassUserEntryChanged = True
			DateEditForm_StartDate.SetRequired(True)

			RowStartDate = GetStartDateForRow(_MediaPlanDetailLevelLineDatas(0).RowIndex)
			RowEndDate = GetEndDateForRow(_MediaPlanDetailLevelLineDatas(0).RowIndex)

			If RowStartDate <> Date.MinValue AndAlso RowEndDate <> Date.MinValue Then

				DateEditForm_StartDate.Properties.MinValue = RowStartDate
				DateEditForm_StartDate.Properties.MaxValue = RowEndDate

			Else

				DateEditForm_StartDate.Properties.MinValue = _MediaPlan.StartDate
				DateEditForm_StartDate.Properties.MaxValue = _MediaPlan.EndDate

			End If

			DateEditForm_StartDate.EditValue = _MediaPlanDetailLevelLineDatas.Select(Function(Entity) Entity.StartDate).Min

		End Sub

#End Region

#Region "  Control Event Handlers "

		Private Sub ButtonForm_OK_Click(sender As Object, e As EventArgs) Handles ButtonForm_OK.Click

			'objects
			Dim ErrorMessage As String = String.Empty
			Dim StartDate As Date = Date.MinValue
			Dim LevelLineColor As Integer = 0

			If Me.Validator() Then

				StartDate = DateEditForm_StartDate.GetValue

				For MPDLLDIndex As Integer = 0 To _MediaPlanDetailLevelLineDatas.Count - 1

					Do Until _MediaPlan.MediaPlanEstimate.IsOnHiatusDate(StartDate) = False

						StartDate = StartDate.AddDays(1)

					Loop

					StartDate = StartDate.AddDays(28)

				Next

				StartDate = StartDate.AddDays(-1)

				If StartDate <= DateEditForm_StartDate.Properties.MaxValue Then

					LevelLineColor = _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.OfType(Of System.Data.DataRow).Where(Function(DR) _MediaPlanDetailLevelLineDatas(0).RowIndex = DR(AdvantageFramework.MediaPlanning.LevelLineColumns.RowIndex.ToString) AndAlso
																																				 DR(AdvantageFramework.MediaPlanning.LevelLineColumns.Color.ToString) <> 0).Select(Function(DR) DR(AdvantageFramework.MediaPlanning.LevelLineColumns.Color.ToString)).Max

					StartDate = DateEditForm_StartDate.GetValue

					For Each MediaPlanDetailLevelLineData In _MediaPlanDetailLevelLineDatas.OrderBy(Function(Entity) Entity.StartDate)

						_MediaPlan.MediaPlanEstimate.ClearMediaPlanDetailLevelLineDataFromEstimateDataTable(MediaPlanDetailLevelLineData.StartDate, MediaPlanDetailLevelLineData.RowIndex)
						_MediaPlan.MediaPlanEstimate.UpdateMediaPlanDetailLevelLineDataColor(MediaPlanDetailLevelLineData.StartDate, MediaPlanDetailLevelLineData.EndDate, MediaPlanDetailLevelLineData.RowIndex, 0)

						Do Until _MediaPlan.MediaPlanEstimate.IsOnHiatusDate(StartDate) = False

							StartDate = StartDate.AddDays(1)

						Loop

						MediaPlanDetailLevelLineData.StartDate = StartDate
						MediaPlanDetailLevelLineData.EndDate = StartDate.AddDays(27)

						If _MediaPlan.MediaPlanEstimate.DoesMediaPlanDetailLevelLineDataHaveData(MediaPlanDetailLevelLineData) Then

							If LevelLineColor <> 0 Then

								MediaPlanDetailLevelLineData.Color = LevelLineColor

							ElseIf _MediaPlan.MediaPlanEstimate.Color <> 0 Then

								MediaPlanDetailLevelLineData.Color = _MediaPlan.MediaPlanEstimate.Color

							Else

								MediaPlanDetailLevelLineData.Color = 0

							End If

						Else

							MediaPlanDetailLevelLineData.Color = 0

						End If

                        _MediaPlan.MediaPlanEstimate.UpdateMediaPlanDetailLevelLineData(MediaPlanDetailLevelLineData, MediaPlanning.DataColumns.Color)

                        StartDate = StartDate.AddDays(28)

					Next

					Me.DialogResult = Windows.Forms.DialogResult.OK
					Me.Close()

				Else

					AdvantageFramework.WinForm.MessageBox.Show("Please select a start date that can accommodate every date.")

				End If

			Else

				For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

					ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

				Next

				AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

			End If

		End Sub
		Private Sub ButtonForm_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonForm_Cancel.Click

			Me.DialogResult = Windows.Forms.DialogResult.Cancel
			Me.Close()

		End Sub

#End Region

#End Region

	End Class

End Namespace
