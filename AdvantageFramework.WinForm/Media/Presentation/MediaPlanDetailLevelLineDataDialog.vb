Namespace Media.Presentation

	Public Class MediaPlanDetailLevelLineDataDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

		Private _MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan = Nothing
		Private _RowIndexes As Generic.List(Of Integer) = Nothing
		Private _MediaPlanDetailLevelLineDatas As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData) = Nothing
		Private _StartDate As Date = Nothing
		Private _EndDate As Date = Nothing
		Private _DataColumn As AdvantageFramework.MediaPlanning.DataColumns = MediaPlanning.DataColumns.ID
		Private _LoadingDateTime As Boolean = False

#End Region

#Region " Properties "



#End Region

#Region " Methods "

		Private Sub New(ByVal MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan, ByVal RowIndexes As Generic.List(Of Integer), ByVal StartDate As Date, ByVal EndDate As Date, ByVal DataColumn As AdvantageFramework.MediaPlanning.DataColumns)

			' This call is required by the designer.
			InitializeComponent()

			' Add any initialization after the InitializeComponent() call.
			_MediaPlan = MediaPlan
			_RowIndexes = RowIndexes
			_StartDate = StartDate
			_EndDate = EndDate
			_DataColumn = DataColumn

		End Sub
		Private Sub LoadGrid()

			DataGridViewForm_LevelLineData.DataSource = _MediaPlanDetailLevelLineDatas

			SetupGridColumns()

			DataGridViewForm_LevelLineData.CurrentView.BestFitColumns()

		End Sub
		Private Sub LoadLineAndLevelDetails()

			'objects
			Dim MediaPlanDetailLevelLine As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine = Nothing
			Dim RowIndex As Integer = 0

			DateTimePickerForm_From.Value = _StartDate
			DateTimePickerForm_To.Value = _EndDate

			If _RowIndexes.Count > 1 Then

				LabelForm_LineData.Text = "Multiple Lines"

			ElseIf _RowIndexes.Count = 1 Then

				For Each MediaPlanDetailLevel In _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.OrderBy(Function(Entity) Entity.OrderNumber).ToList

					Try

						MediaPlanDetailLevelLine = MediaPlanDetailLevel.MediaPlanDetailLevelLines.SingleOrDefault(Function(Entity) Entity.RowIndex = _RowIndexes(0))

					Catch ex As Exception
						MediaPlanDetailLevelLine = Nothing
					End Try

					If MediaPlanDetailLevelLine IsNot Nothing Then

						LabelForm_LineData.Text = If(LabelForm_LineData.Text = "", MediaPlanDetailLevelLine.Description, LabelForm_LineData.Text & " | " & MediaPlanDetailLevelLine.Description)

					End If

				Next

			End If

		End Sub
		Private Sub SetupGridColumns()

			'objects
			Dim MediaPlanDetailField As AdvantageFramework.Database.Entities.MediaPlanDetailField = Nothing
			Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
			Dim SubItemDateInput As AdvantageFramework.WinForm.Presentation.Controls.SubItemDateInput = Nothing

            If _MediaPlan.MediaPlanEstimate.PeriodType = MediaPlanning.Methods.PeriodTypes.None Then

                If _MediaPlan.MediaPlanEstimate.SalesClassType = "O" AndAlso
                        (_DataColumn = MediaPlanning.Methods.DataColumns.Month OrElse
                         _DataColumn = MediaPlanning.Methods.DataColumns.MonthName OrElse
                         _DataColumn = MediaPlanning.Methods.DataColumns.Quarter OrElse
                         _DataColumn = MediaPlanning.Methods.DataColumns.Year) Then

                    If DataGridViewForm_LevelLineData.Columns.ColumnByFieldName("Is4WeekAllocation") Is Nothing Then

                        GridColumn = DataGridViewForm_LevelLineData.CurrentView.Columns.Add()

                        GridColumn.AppearanceHeader.Font = New System.Drawing.Font("Arial", 8, Drawing.FontStyle.Bold)

                        GridColumn.Caption = "4 Week"
                        GridColumn.FieldName = "Is4WeekAllocation"
                        GridColumn.Name = "GridColumnIs4WeekAllocation"
                        GridColumn.UnboundType = DevExpress.Data.UnboundColumnType.Boolean

                    End If

                End If

            End If

            For Each GridColumn In DataGridViewForm_LevelLineData.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

				GridColumn.Visible = False

			Next

			If _RowIndexes.Count > 1 Then

				Try

					GridColumn = DataGridViewForm_LevelLineData.Columns(AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString)

				Catch ex As Exception
					GridColumn = Nothing
				End Try

				If GridColumn IsNot Nothing Then

					GridColumn.Caption = "Line Number"
					GridColumn.Visible = True
					GridColumn.OptionsColumn.ReadOnly = True

				End If

			End If

			If DataGridViewForm_LevelLineData.Columns(AdvantageFramework.MediaPlanning.DataColumns.StartDate.ToString) IsNot Nothing Then

				DataGridViewForm_LevelLineData.Columns(AdvantageFramework.MediaPlanning.DataColumns.StartDate.ToString).Caption = "Start Date"
				DataGridViewForm_LevelLineData.Columns(AdvantageFramework.MediaPlanning.DataColumns.StartDate.ToString).VisibleIndex = DataGridViewForm_LevelLineData.CurrentView.VisibleColumns.Count
				DataGridViewForm_LevelLineData.Columns(AdvantageFramework.MediaPlanning.DataColumns.StartDate.ToString).Visible = True

				SubItemDateInput = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemDateEdit()

				SubItemDateInput.MinValue = _StartDate
                SubItemDateInput.MaxValue = _MediaPlan.EndDate
                SubItemDateInput.DisplayFormat.FormatString = "d"
				SubItemDateInput.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
				SubItemDateInput.EditFormat.FormatString = "d"
				SubItemDateInput.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime

				SubItemDateInput.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None
				SubItemDateInput.EditMask = ""
				SubItemDateInput.Mask.UseMaskAsDisplayFormat = False

				SubItemDateInput.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard

				If _MediaPlan.MediaPlanEstimate.IsCalendarMonth = False Then

					SubItemDateInput.FirstDayOfWeek = DayOfWeek.Monday

				End If

				DataGridViewForm_LevelLineData.GridControl.RepositoryItems.Add(SubItemDateInput)

				DataGridViewForm_LevelLineData.Columns(AdvantageFramework.MediaPlanning.DataColumns.StartDate.ToString).ColumnEdit = SubItemDateInput

                AddHandler SubItemDateInput.DisableCalendarDate, AddressOf SubItemDateInput_StartDateDisableCalendarDate
                AddHandler SubItemDateInput.EditValueChanging, AddressOf SubItemDateInput_StartDateEditValueChanging
                AddHandler SubItemDateInput.Popup, AddressOf SubItemDateInput_StartDatePopup
                AddHandler SubItemDateInput.DrawItem, AddressOf SubItemDateInput_StartDateDrawItem

            End If

            If (_MediaPlan.MediaPlanEstimate.SalesClassType = "I" OrElse _MediaPlan.MediaPlanEstimate.SalesClassType = "M" OrElse
                    _MediaPlan.MediaPlanEstimate.SalesClassType = "N" OrElse _MediaPlan.MediaPlanEstimate.SalesClassType = "O") AndAlso
                    (_MediaPlan.MediaPlanEstimate.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.Week OrElse _MediaPlan.MediaPlanEstimate.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.Month OrElse
                     _MediaPlan.MediaPlanEstimate.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.OOH4Week) Then

                If DataGridViewForm_LevelLineData.Columns(AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData.Properties.EndDate.ToString) IsNot Nothing Then

                    DataGridViewForm_LevelLineData.Columns(AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData.Properties.EndDate.ToString).Caption = "End Date"
                    DataGridViewForm_LevelLineData.Columns(AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData.Properties.EndDate.ToString).VisibleIndex = DataGridViewForm_LevelLineData.CurrentView.VisibleColumns.Count
                    DataGridViewForm_LevelLineData.Columns(AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData.Properties.EndDate.ToString).Visible = True

                    SubItemDateInput = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemDateEdit()

                    SubItemDateInput.MinValue = _StartDate
                    SubItemDateInput.MaxValue = _EndDate
                    SubItemDateInput.DisplayFormat.FormatString = "d"
                    SubItemDateInput.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                    SubItemDateInput.EditFormat.FormatString = "d"
                    SubItemDateInput.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime

                    SubItemDateInput.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None
                    SubItemDateInput.EditMask = ""
                    SubItemDateInput.Mask.UseMaskAsDisplayFormat = False

                    SubItemDateInput.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard

                    If _MediaPlan.MediaPlanEstimate.IsCalendarMonth = False Then

                        SubItemDateInput.FirstDayOfWeek = DayOfWeek.Monday

                    End If

                    DataGridViewForm_LevelLineData.GridControl.RepositoryItems.Add(SubItemDateInput)

                    DataGridViewForm_LevelLineData.Columns(AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData.Properties.EndDate.ToString).ColumnEdit = SubItemDateInput

                    AddHandler SubItemDateInput.DisableCalendarDate, AddressOf SubItemDateInput_EndDateDisableCalendarDate
                    AddHandler SubItemDateInput.EditValueChanging, AddressOf SubItemDateInput_EndDateEditValueChanging
                    AddHandler SubItemDateInput.Popup, AddressOf SubItemDateInput_EndDatePopup
                    AddHandler SubItemDateInput.DrawItem, AddressOf SubItemDateInput_EndDateDrawItem

                End If

            End If

            For Each MediaPlanDetailField In _MediaPlan.MediaPlanEstimate.MediaPlanDetailFields.Where(Function(Entity) Entity.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea).OrderBy(Function(Entity) Entity.AreaIndex).ToList

                Try

                    GridColumn = DataGridViewForm_LevelLineData.Columns(MediaPlanDetailField.FieldID)

                Catch ex As Exception
                    GridColumn = Nothing
                End Try

                If GridColumn IsNot Nothing Then

                    If MediaPlanDetailField.IsVisible Then

                        GridColumn.VisibleIndex = DataGridViewForm_LevelLineData.CurrentView.VisibleColumns.Count
                        GridColumn.Visible = MediaPlanDetailField.IsVisible
                        GridColumn.Caption = MediaPlanDetailField.Caption

                    End If

                    If GridColumn.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Demo1.ToString Then

                        GridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        GridColumn.DisplayFormat.FormatString = "n1"
                        'GridColumn.Caption = AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.MediaPlanning.DataColumns.Demo1.ToString)

                        If TypeOf GridColumn.ColumnEdit Is AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput Then

                            CType(GridColumn.ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).AllowNullInput = DevExpress.Utils.DefaultBoolean.False

                            If (_MediaPlan.MediaPlanEstimate.SalesClassType = "R" OrElse _MediaPlan.MediaPlanEstimate.SalesClassType = "T") Then

                                CType(GridColumn.ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).MaxValue = 999999
                                CType(GridColumn.ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).MaxLength = 6

                            Else

                                CType(GridColumn.ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).MaxValue = Integer.MaxValue
                                CType(GridColumn.ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).MaxLength = 10

                            End If

                        End If

                    ElseIf GridColumn.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Demo2.ToString Then

                        GridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        GridColumn.DisplayFormat.FormatString = "n1"
                        'GridColumn.Caption = AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.MediaPlanning.DataColumns.Demo2.ToString)

                        If TypeOf GridColumn.ColumnEdit Is AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput Then

                            CType(GridColumn.ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).AllowNullInput = DevExpress.Utils.DefaultBoolean.False

                            If (_MediaPlan.MediaPlanEstimate.SalesClassType = "R" OrElse _MediaPlan.MediaPlanEstimate.SalesClassType = "T") Then

                                CType(GridColumn.ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).MaxValue = 999999
                                CType(GridColumn.ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).MaxLength = 6

                            Else

                                CType(GridColumn.ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).MaxValue = Integer.MaxValue
                                CType(GridColumn.ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).MaxLength = 10

                            End If

                        End If

                    ElseIf GridColumn.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Units.ToString Then

                        GridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        GridColumn.DisplayFormat.FormatString = "n0"

                        If TypeOf GridColumn.ColumnEdit Is AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput Then

                            CType(GridColumn.ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).AllowNullInput = DevExpress.Utils.DefaultBoolean.False

                            If (_MediaPlan.MediaPlanEstimate.SalesClassType = "R" OrElse _MediaPlan.MediaPlanEstimate.SalesClassType = "T") Then

                                CType(GridColumn.ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).MaxValue = 999999
                                CType(GridColumn.ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).MaxLength = 6

                            Else

                                CType(GridColumn.ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).MaxValue = Integer.MaxValue
                                CType(GridColumn.ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).MaxLength = 10

                            End If

                        End If

                    ElseIf GridColumn.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Impressions.ToString Then

                        GridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        GridColumn.DisplayFormat.FormatString = "n0"

                        If TypeOf GridColumn.ColumnEdit Is AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput Then

                            CType(GridColumn.ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).AllowNullInput = DevExpress.Utils.DefaultBoolean.False

                            If (_MediaPlan.MediaPlanEstimate.SalesClassType = "R" OrElse _MediaPlan.MediaPlanEstimate.SalesClassType = "T") Then

                                CType(GridColumn.ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).MaxValue = 999999
                                CType(GridColumn.ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).MaxLength = 6

                            Else

                                CType(GridColumn.ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).MaxValue = Integer.MaxValue
                                CType(GridColumn.ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).MaxLength = 10

                            End If

                        End If

                    ElseIf GridColumn.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Clicks.ToString Then

                        GridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        GridColumn.DisplayFormat.FormatString = "n0"

                        If TypeOf GridColumn.ColumnEdit Is AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput Then

                            CType(GridColumn.ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).AllowNullInput = DevExpress.Utils.DefaultBoolean.False

                            If (_MediaPlan.MediaPlanEstimate.SalesClassType = "R" OrElse _MediaPlan.MediaPlanEstimate.SalesClassType = "T") Then

                                CType(GridColumn.ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).MaxValue = 999999
                                CType(GridColumn.ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).MaxLength = 6

                            Else

                                CType(GridColumn.ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).MaxValue = Integer.MaxValue
                                CType(GridColumn.ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).MaxLength = 10

                            End If

                        End If

                    ElseIf GridColumn.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Columns.ToString Then

                        GridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        GridColumn.DisplayFormat.FormatString = "n2"

                        If TypeOf GridColumn.ColumnEdit Is AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput Then

                            CType(GridColumn.ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).AllowNullInput = DevExpress.Utils.DefaultBoolean.False

                        End If

                    ElseIf GridColumn.FieldName = AdvantageFramework.MediaPlanning.DataColumns.InchesLines.ToString Then

                        GridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        GridColumn.DisplayFormat.FormatString = "n2"

                        If TypeOf GridColumn.ColumnEdit Is AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput Then

                            CType(GridColumn.ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).AllowNullInput = DevExpress.Utils.DefaultBoolean.False

                        End If

                    ElseIf GridColumn.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Rate.ToString Then

                        GridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        GridColumn.DisplayFormat.FormatString = "c2"

                        If TypeOf GridColumn.ColumnEdit Is AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput Then

                            CType(GridColumn.ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).AllowNullInput = DevExpress.Utils.DefaultBoolean.False

                        End If

                    ElseIf GridColumn.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Dollars.ToString Then

                        GridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        GridColumn.DisplayFormat.FormatString = "c2"
                        'GridColumn.OptionsColumn.ReadOnly = _MediaPlan.MediaPlanEstimate.CalculateDollars

                        If TypeOf GridColumn.ColumnEdit Is AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput Then

                            CType(GridColumn.ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).AllowNullInput = DevExpress.Utils.DefaultBoolean.False

                        End If

                    ElseIf GridColumn.FieldName = AdvantageFramework.MediaPlanning.DataColumns.NetCharge.ToString Then

                        GridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        GridColumn.DisplayFormat.FormatString = "c2"

                        If TypeOf GridColumn.ColumnEdit Is AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput Then

                            CType(GridColumn.ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).AllowNullInput = DevExpress.Utils.DefaultBoolean.False

                        End If

                    ElseIf GridColumn.FieldName = AdvantageFramework.MediaPlanning.DataColumns.AgencyFee.ToString Then

                        GridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        GridColumn.DisplayFormat.FormatString = "c2"
                        'GridColumn.Caption = AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.MediaPlanning.DataColumns.AgencyFee.ToString)

                        If TypeOf GridColumn.ColumnEdit Is AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput Then

                            CType(GridColumn.ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).AllowNullInput = DevExpress.Utils.DefaultBoolean.False

                        End If

                    ElseIf GridColumn.FieldName = AdvantageFramework.MediaPlanning.DataColumns.BillAmount.ToString Then

                        GridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        GridColumn.DisplayFormat.FormatString = "c2"
                        GridColumn.OptionsColumn.ReadOnly = True
                        'GridColumn.Caption = AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.MediaPlanning.DataColumns.BillAmount.ToString)

                        If TypeOf GridColumn.ColumnEdit Is AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput Then

                            CType(GridColumn.ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).AllowNullInput = DevExpress.Utils.DefaultBoolean.False

                        End If

                    ElseIf GridColumn.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Note.ToString Then

                        GridColumn.VisibleIndex = DataGridViewForm_LevelLineData.CurrentView.VisibleColumns.Count
                        GridColumn.Visible = True

                    End If

                End If

            Next

            If _DataColumn = MediaPlanning.DataColumns.Week Then

				If _MediaPlan.MediaPlanEstimate.IsCalendarMonth Then

					DataGridViewForm_LevelLineData.MakeColumnVisible(AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData.Properties.Sunday.ToString)
					DataGridViewForm_LevelLineData.MakeColumnVisible(AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData.Properties.Monday.ToString)
					DataGridViewForm_LevelLineData.MakeColumnVisible(AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData.Properties.Tuesday.ToString)
					DataGridViewForm_LevelLineData.MakeColumnVisible(AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData.Properties.Wednesday.ToString)
					DataGridViewForm_LevelLineData.MakeColumnVisible(AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData.Properties.Thursday.ToString)
					DataGridViewForm_LevelLineData.MakeColumnVisible(AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData.Properties.Friday.ToString)
					DataGridViewForm_LevelLineData.MakeColumnVisible(AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData.Properties.Saturday.ToString)

				Else

					DataGridViewForm_LevelLineData.MakeColumnVisible(AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData.Properties.Monday.ToString)
					DataGridViewForm_LevelLineData.MakeColumnVisible(AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData.Properties.Tuesday.ToString)
					DataGridViewForm_LevelLineData.MakeColumnVisible(AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData.Properties.Wednesday.ToString)
					DataGridViewForm_LevelLineData.MakeColumnVisible(AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData.Properties.Thursday.ToString)
					DataGridViewForm_LevelLineData.MakeColumnVisible(AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData.Properties.Friday.ToString)
					DataGridViewForm_LevelLineData.MakeColumnVisible(AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData.Properties.Saturday.ToString)
					DataGridViewForm_LevelLineData.MakeColumnVisible(AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData.Properties.Sunday.ToString)

				End If

			End If

			For Each GridColumn In DataGridViewForm_LevelLineData.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                'GridColumn.OptionsColumn.ReadOnly = False ' _MediaPlan.IsApproved

                If GridColumn.FieldName = AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData.Properties.OrderNumber.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData.Properties.OrderLineNumber.ToString Then

                    GridColumn.OptionsColumn.ReadOnly = True
                    GridColumn.VisibleIndex = DataGridViewForm_LevelLineData.CurrentView.VisibleColumns.Count
                    GridColumn.Visible = True

                End If

            Next

			If DataGridViewForm_LevelLineData.Columns.ColumnByFieldName("Is4WeekAllocation") IsNot Nothing Then

				GridColumn = DataGridViewForm_LevelLineData.Columns.ColumnByFieldName("Is4WeekAllocation")

				GridColumn.VisibleIndex = 0
				GridColumn.Visible = True

			End If

		End Sub
        Private Sub SubItemDateInput_StartDateDrawItem(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Calendar.CustomDrawDayNumberCellEventArgs)

            'objects
            Dim Brush As System.Drawing.Brush = Nothing
            Dim StringFormat As System.Drawing.StringFormat = Nothing
            Dim PopupControl As DevExpress.Utils.Win.IPopupControl = Nothing
            Dim PopupDateEditForm As DevExpress.XtraEditors.Popup.PopupDateEditForm = Nothing
            Dim CalendarControl As DevExpress.XtraEditors.Controls.CalendarControl = Nothing
            Dim DateTimeFormatInfo As System.Globalization.DateTimeFormatInfo = Nothing

            If e IsNot Nothing AndAlso e.View = DevExpress.XtraEditors.Controls.DateEditCalendarViewType.MonthInfo Then

                If _MediaPlan.MediaPlanEstimate IsNot Nothing AndAlso _MediaPlan.MediaPlanEstimate.IsCalendarMonth = False Then

                    PopupControl = CType(sender, DevExpress.Utils.Win.IPopupControl)
                    PopupDateEditForm = TryCast(PopupControl.PopupWindow, DevExpress.XtraEditors.Popup.PopupDateEditForm)

                    If PopupDateEditForm IsNot Nothing Then

                        CalendarControl = PopupDateEditForm.Controls.OfType(Of DevExpress.XtraEditors.Controls.CalendarControl)().FirstOrDefault()

                        If CalendarControl IsNot Nothing Then

                            If IsInBroadcastMonth(e.Date, CalendarControl.DateTime.Month) Then

                                If IsValidEntryDate(e.Date) Then

                                    Brush = Drawing.Brushes.Black

                                    StringFormat = New System.Drawing.StringFormat
                                    StringFormat.Alignment = System.Drawing.StringAlignment.Center
                                    StringFormat.LineAlignment = System.Drawing.StringAlignment.Center

                                    e.Graphics.DrawString(e.Date.Day.ToString(), e.Style.Font, Brush, e.Bounds, StringFormat)

                                    If CalendarControl.DateTime = e.Date Then

                                        e.State = DevExpress.Utils.Drawing.ObjectState.Selected

                                    Else

                                        e.State = DevExpress.Utils.Drawing.ObjectState.Normal

                                    End If

                                    e.Handled = True

                                Else

                                    Brush = Drawing.Brushes.Gray

                                    StringFormat = New System.Drawing.StringFormat
                                    StringFormat.Alignment = System.Drawing.StringAlignment.Center
                                    StringFormat.LineAlignment = System.Drawing.StringAlignment.Center
                                    e.Style.Font = New System.Drawing.Font(e.Style.Font.FontFamily.Name, e.Style.Font.Size, Drawing.FontStyle.Strikeout)

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

                                e.State = DevExpress.Utils.Drawing.ObjectState.Disabled

                                e.Handled = True

                            End If

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub SubItemDateInput_StartDatePopup(ByVal sender As Object, ByVal e As System.EventArgs)

            'objects
            Dim PopupControl As DevExpress.Utils.Win.IPopupControl = Nothing
            Dim PopupDateEditForm As DevExpress.XtraEditors.Popup.PopupDateEditForm = Nothing
            Dim CalendarControl As DevExpress.XtraEditors.Controls.CalendarControl = Nothing
            Dim DateTimeFormatInfo As System.Globalization.DateTimeFormatInfo = Nothing

            If _MediaPlan.MediaPlanEstimate IsNot Nothing AndAlso _MediaPlan.MediaPlanEstimate.IsCalendarMonth = False Then

                PopupControl = CType(sender, DevExpress.Utils.Win.IPopupControl)
                PopupDateEditForm = TryCast(PopupControl.PopupWindow, DevExpress.XtraEditors.Popup.PopupDateEditForm)

                If PopupDateEditForm IsNot Nothing Then

                    If _MediaPlan.MediaPlanEstimate.IsCalendarMonth = False Then

                        For Each CalendarControl In PopupDateEditForm.Controls.OfType(Of DevExpress.XtraEditors.Controls.CalendarControl)().ToList

                            _LoadingDateTime = True

                            Try

                                If CDate(sender.EditValue).Day = 1 Then

                                    CalendarControl.DateTime = CDate(_MediaPlan.MediaPlanEstimate.GetMonth(sender.EditValue) & "/01/" & _MediaPlan.MediaPlanEstimate.GetYear(sender.EditValue))

                                Else

                                    CalendarControl.DateTime = CDate(_MediaPlan.MediaPlanEstimate.GetMonth(sender.EditValue) & "/02/" & _MediaPlan.MediaPlanEstimate.GetYear(sender.EditValue))

                                End If

                            Catch ex As Exception

                            End Try

                            _LoadingDateTime = False

                        Next

                    Else

                        For Each CalendarControl In PopupDateEditForm.Controls.OfType(Of DevExpress.XtraEditors.Controls.CalendarControl)().ToList

                            Try

                                CalendarControl.DateTime = sender.EditValue

                            Catch ex As Exception

                            End Try

                        Next

                    End If

                End If

            End If

        End Sub
        Private Sub SubItemDateInput_StartDateEditValueChanging(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ChangingEventArgs)

            'objects
            Dim MediaPlanDetailLevelLineData As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData = Nothing

            If IsDate(e.OldValue) Then

                Try

                    MediaPlanDetailLevelLineData = DataGridViewForm_LevelLineData.GetFirstSelectedRowDataBoundItem

                Catch ex As Exception
                    MediaPlanDetailLevelLineData = Nothing
                End Try

                If MediaPlanDetailLevelLineData IsNot Nothing Then

                    _MediaPlan.MediaPlanEstimate.ClearMediaPlanDetailLevelLineDataFromEstimateDataTable(e.OldValue, MediaPlanDetailLevelLineData.RowIndex)

                    If IsDate(e.NewValue) Then

                        MediaPlanDetailLevelLineData.EndDate = e.NewValue

                    End If

                End If

            End If

        End Sub
        Private Sub SubItemDateInput_StartDateDisableCalendarDate(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Calendar.DisableCalendarDateEventArgs)

            If e.View = DevExpress.XtraEditors.Controls.DateEditCalendarViewType.MonthInfo AndAlso IsValidEntryDate(e.Date) = False Then

                e.IsDisabled = True

            End If

        End Sub
        Private Sub SubItemDateInput_EndDateDrawItem(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Calendar.CustomDrawDayNumberCellEventArgs)

            'objects
            Dim Brush As System.Drawing.Brush = Nothing
            Dim StringFormat As System.Drawing.StringFormat = Nothing
            Dim PopupControl As DevExpress.Utils.Win.IPopupControl = Nothing
            Dim PopupDateEditForm As DevExpress.XtraEditors.Popup.PopupDateEditForm = Nothing
            Dim CalendarControl As DevExpress.XtraEditors.Controls.CalendarControl = Nothing
            Dim DateTimeFormatInfo As System.Globalization.DateTimeFormatInfo = Nothing
            Dim MediaPlanDetailLevelLineData As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData = Nothing

            If e IsNot Nothing AndAlso e.View = DevExpress.XtraEditors.Controls.DateEditCalendarViewType.MonthInfo Then

                If _MediaPlan.MediaPlanEstimate IsNot Nothing AndAlso _MediaPlan.MediaPlanEstimate.IsCalendarMonth = False Then

                    Try

                        MediaPlanDetailLevelLineData = DataGridViewForm_LevelLineData.GetFirstSelectedRowDataBoundItem

                    Catch ex As Exception
                        MediaPlanDetailLevelLineData = Nothing
                    End Try

                    If MediaPlanDetailLevelLineData IsNot Nothing Then

                        PopupControl = CType(sender, DevExpress.Utils.Win.IPopupControl)
                        PopupDateEditForm = TryCast(PopupControl.PopupWindow, DevExpress.XtraEditors.Popup.PopupDateEditForm)

                        If PopupDateEditForm IsNot Nothing Then

                            CalendarControl = PopupDateEditForm.Controls.OfType(Of DevExpress.XtraEditors.Controls.CalendarControl)().FirstOrDefault()

                            If CalendarControl IsNot Nothing Then

                                If IsInBroadcastMonth(e.Date, CalendarControl.DateTime.Month) Then

                                    If IsValidEndDate(MediaPlanDetailLevelLineData.StartDate, e.Date) Then

                                        Brush = Drawing.Brushes.Black

                                        StringFormat = New System.Drawing.StringFormat
                                        StringFormat.Alignment = System.Drawing.StringAlignment.Center
                                        StringFormat.LineAlignment = System.Drawing.StringAlignment.Center

                                        e.Graphics.DrawString(e.Date.Day.ToString(), e.Style.Font, Brush, e.Bounds, StringFormat)

                                        If CalendarControl.DateTime = e.Date Then

                                            e.State = DevExpress.Utils.Drawing.ObjectState.Selected

                                        Else

                                            e.State = DevExpress.Utils.Drawing.ObjectState.Normal

                                        End If

                                        e.Handled = True

                                    Else

                                        Brush = Drawing.Brushes.Gray

                                        StringFormat = New System.Drawing.StringFormat
                                        StringFormat.Alignment = System.Drawing.StringAlignment.Center
                                        StringFormat.LineAlignment = System.Drawing.StringAlignment.Center
                                        e.Style.Font = New System.Drawing.Font(e.Style.Font.FontFamily.Name, e.Style.Font.Size, Drawing.FontStyle.Strikeout)

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

                                    e.State = DevExpress.Utils.Drawing.ObjectState.Disabled

                                    e.Handled = True

                                End If

                            End If

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub SubItemDateInput_EndDatePopup(ByVal sender As Object, ByVal e As System.EventArgs)

            'objects
            Dim PopupControl As DevExpress.Utils.Win.IPopupControl = Nothing
            Dim PopupDateEditForm As DevExpress.XtraEditors.Popup.PopupDateEditForm = Nothing
            Dim CalendarControl As DevExpress.XtraEditors.Controls.CalendarControl = Nothing
            Dim DateTimeFormatInfo As System.Globalization.DateTimeFormatInfo = Nothing

            If _MediaPlan.MediaPlanEstimate IsNot Nothing AndAlso _MediaPlan.MediaPlanEstimate.IsCalendarMonth = False Then

                PopupControl = CType(sender, DevExpress.Utils.Win.IPopupControl)
                PopupDateEditForm = TryCast(PopupControl.PopupWindow, DevExpress.XtraEditors.Popup.PopupDateEditForm)

                If PopupDateEditForm IsNot Nothing Then

                    If _MediaPlan.MediaPlanEstimate.IsCalendarMonth = False Then

                        For Each CalendarControl In PopupDateEditForm.Controls.OfType(Of DevExpress.XtraEditors.Controls.CalendarControl)().ToList

                            _LoadingDateTime = True

                            Try

                                If CDate(sender.EditValue).Day = 1 Then

                                    CalendarControl.DateTime = CDate(_MediaPlan.MediaPlanEstimate.GetMonth(sender.EditValue) & "/01/" & _MediaPlan.MediaPlanEstimate.GetYear(sender.EditValue))

                                Else

                                    CalendarControl.DateTime = CDate(_MediaPlan.MediaPlanEstimate.GetMonth(sender.EditValue) & "/02/" & _MediaPlan.MediaPlanEstimate.GetYear(sender.EditValue))

                                End If

                            Catch ex As Exception

                            End Try

                            _LoadingDateTime = False

                        Next

                    Else

                        For Each CalendarControl In PopupDateEditForm.Controls.OfType(Of DevExpress.XtraEditors.Controls.CalendarControl)().ToList

                            Try

                                CalendarControl.DateTime = sender.EditValue

                            Catch ex As Exception

                            End Try

                        Next

                    End If

                End If

            End If

        End Sub
        Private Sub SubItemDateInput_EndDateEditValueChanging(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ChangingEventArgs)

            'objects
            'Dim MediaPlanDetailLevelLineData As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData = Nothing

            'If IsDate(e.OldValue) Then

            '    Try

            '        MediaPlanDetailLevelLineData = DataGridViewForm_LevelLineData.GetFirstSelectedRowDataBoundItem

            '    Catch ex As Exception
            '        MediaPlanDetailLevelLineData = Nothing
            '    End Try

            '    If MediaPlanDetailLevelLineData IsNot Nothing Then

            '        _MediaPlan.MediaPlanEstimate.ClearMediaPlanDetailLevelLineDataFromEstimateDataTable(e.OldValue, MediaPlanDetailLevelLineData.RowIndex)

            '    End If

            'End If

        End Sub
        Private Sub SubItemDateInput_EndDateDisableCalendarDate(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Calendar.DisableCalendarDateEventArgs)

            'objects
            Dim MediaPlanDetailLevelLineData As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData = Nothing

            Try

                MediaPlanDetailLevelLineData = DataGridViewForm_LevelLineData.GetFirstSelectedRowDataBoundItem

            Catch ex As Exception
                MediaPlanDetailLevelLineData = Nothing
            End Try

            If MediaPlanDetailLevelLineData IsNot Nothing Then

                If e.View = DevExpress.XtraEditors.Controls.DateEditCalendarViewType.MonthInfo AndAlso IsValidEndDate(MediaPlanDetailLevelLineData.StartDate, e.Date) = False Then

                    e.IsDisabled = True

                End If

            Else
                e.IsDisabled = True

            End If

        End Sub
        Private Function ValidateMediaPlanDetailLevelLineData(MediaPlanDetailLevelLineData As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData, RowHandle As Integer, ByRef ErrorText As String) As Boolean

			'objects
			Dim IsValid As Boolean = True
			Dim RowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing
			Dim MPDLLD As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData = Nothing

			If MediaPlanDetailLevelLineData IsNot Nothing Then

				If MediaPlanDetailLevelLineData.StartDate >= _StartDate AndAlso MediaPlanDetailLevelLineData.StartDate <= _EndDate Then

					Try

						RowHandlesAndDataBoundItems = DataGridViewForm_LevelLineData.GetAllRowsRowHandlesAndDataBoundItems

					Catch ex As Exception
						RowHandlesAndDataBoundItems = Nothing
					End Try

					If RowHandlesAndDataBoundItems IsNot Nothing Then

						For Each RowHandleAndDataBoundItem In RowHandlesAndDataBoundItems

							If RowHandleAndDataBoundItem.Key <> RowHandle Then

								Try

									If TypeOf RowHandleAndDataBoundItem.Value Is AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData Then

										MPDLLD = RowHandleAndDataBoundItem.Value

									End If

								Catch ex As Exception
									MPDLLD = Nothing
								End Try

								If MPDLLD IsNot Nothing AndAlso MPDLLD.StartDate = MediaPlanDetailLevelLineData.StartDate AndAlso MPDLLD.RowIndex = MediaPlanDetailLevelLineData.RowIndex Then

									ErrorText = "Cannot have multiple entries for the same date " & MediaPlanDetailLevelLineData.StartDate.ToShortDateString & " and on the same line."
									IsValid = False

									Exit For

								End If

							End If

						Next

					End If

				Else

					ErrorText = "Please select a date between " & _StartDate.ToShortDateString & " and " & _EndDate.ToShortDateString & "."
					IsValid = False

				End If

			End If

			ValidateMediaPlanDetailLevelLineData = IsValid

		End Function
		Private Function IsInBroadcastMonth(ByVal EntryDate As Date, ByVal Month As Integer) As Boolean

			'objects
			Dim IsValid As Boolean = False
			Dim Year As Integer = 0
			Dim EntryDateMonth As Integer = 0

			EntryDateMonth = AdvantageFramework.MediaPlanning.GetMonthForEstimate(EntryDate, _MediaPlan.MediaPlanEstimate.IsCalendarMonth, _MediaPlan.BroadcastCalendarWeeks, Year)

			If EntryDateMonth = Month Then

				IsValid = True

			End If

			IsInBroadcastMonth = IsValid

		End Function
        Private Function IsValidEntryDate(ByVal EntryDate As Date) As Boolean

            'objects
            Dim IsValid As Boolean = False

            If _MediaPlanDetailLevelLineDatas.Any(Function(Entity) Entity.StartDate = EntryDate) = False Then

                IsValid = (_MediaPlan.MediaPlanEstimate.IsOnHiatusDate(EntryDate) = False)

            End If

            IsValidEntryDate = IsValid

        End Function
        Private Function IsValidEndDate(StartDate As Date, EndDate As Date) As Boolean

            'objects
            Dim IsValid As Boolean = False

            If EndDate >= StartDate Then

                IsValid = True

            End If

            IsValidEndDate = IsValid

        End Function
        Private Sub SelectDeselectAllDay(ByVal Day As AdvantageFramework.DateUtilities.Days, ByVal Selected As Boolean)

			For Each MediaPlanDetailLevelLineData In DataGridViewForm_LevelLineData.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData).ToList

				Select Case Day

					Case DateUtilities.Days.Sunday

						MediaPlanDetailLevelLineData.Sunday = Selected

					Case DateUtilities.Days.Monday

						MediaPlanDetailLevelLineData.Monday = Selected

					Case DateUtilities.Days.Tuesday

						MediaPlanDetailLevelLineData.Tuesday = Selected

					Case DateUtilities.Days.Wednesday

						MediaPlanDetailLevelLineData.Wednesday = Selected

					Case DateUtilities.Days.Thursday

						MediaPlanDetailLevelLineData.Thursday = Selected

					Case DateUtilities.Days.Friday

						MediaPlanDetailLevelLineData.Friday = Selected

					Case DateUtilities.Days.Saturday

						MediaPlanDetailLevelLineData.Saturday = Selected

				End Select

			Next

			_MediaPlan.EstimateChangedEvent()

		End Sub
		Private Sub EnableOrDisableActions()

            'objects
            Dim MediaPlanDetailLevelLineData As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData = Nothing
            Dim DBMediaPlanDetailLevelLineData As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData = Nothing

            ButtonItemAllocate_AllRows.Enabled = DataGridViewForm_LevelLineData.HasRows 'AndAlso _MediaPlan.IsApproved = False)
			ButtonItemAllocate_SelectedRows.Enabled = DataGridViewForm_LevelLineData.HasASelectedRow 'AndAlso _MediaPlan.IsApproved = False)

			ButtonItemUpdate_AllRows.Enabled = DataGridViewForm_LevelLineData.HasRows 'AndAlso _MediaPlan.IsApproved = False)
			ButtonItemUpdate_SelectedRows.Enabled = DataGridViewForm_LevelLineData.HasASelectedRow 'AndAlso _MediaPlan.IsApproved = False)

			ButtonForm_Allocate.Enabled = DataGridViewForm_LevelLineData.HasRows ' AndAlso _MediaPlan.IsApproved = False)
			ButtonForm_Update.Enabled = DataGridViewForm_LevelLineData.HasRows 'AndAlso _MediaPlan.IsApproved = False)

			ButtonForm_Copy.Enabled = DataGridViewForm_LevelLineData.HasASelectedRow

			ButtonForm_SelectAll.Enabled = DataGridViewForm_LevelLineData.HasRows
			ButtonForm_DeselectAll.Enabled = DataGridViewForm_LevelLineData.HasRows

			If _RowIndexes.Count = 1 Then

				ButtonForm_Update4WeekStartDate.Enabled = DataGridViewForm_LevelLineData.HasMultipleSelectedRows

			Else

				ButtonForm_Update4WeekStartDate.Enabled = DataGridViewForm_LevelLineData.HasMultipleSelectedRows AndAlso
														  (DataGridViewForm_LevelLineData.GetAllSelectedRowsCellValues(AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData.Properties.RowIndex.ToString).
																						  OfType(Of Integer).Distinct.Count = 1)

			End If

			If DataGridViewForm_LevelLineData.CustomDeleteButton IsNot Nothing Then

				If DataGridViewForm_LevelLineData.HasASelectedRow Then

					DataGridViewForm_LevelLineData.CustomDeleteButton.Visible = True

                    Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        DbContext.Database.Connection.Open()

                        For Each MediaPlanDetailLevelLineData In DataGridViewForm_LevelLineData.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData)

                            If MediaPlanDetailLevelLineData IsNot Nothing AndAlso MediaPlanDetailLevelLineData.ID > 0 Then

                                DBMediaPlanDetailLevelLineData = AdvantageFramework.Database.Procedures.MediaPlanDetailLevelLineData.LoadByMediaPlanDetailLevelLineDataID(DbContext, MediaPlanDetailLevelLineData.ID)

                                If DBMediaPlanDetailLevelLineData IsNot Nothing AndAlso (DBMediaPlanDetailLevelLineData.OrderNumber IsNot Nothing OrElse DBMediaPlanDetailLevelLineData.HasPendingOrders = True) Then

                                    DataGridViewForm_LevelLineData.CustomDeleteButton.Visible = False

                                    Exit For

                                End If

                            End If

                        Next

                    End Using

                Else

					DataGridViewForm_LevelLineData.CustomDeleteButton.Visible = False

				End If

			End If

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

			If EndDate = Date.MinValue Then

				EndDate = _MediaPlan.EndDate

			End If

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

			If StartDate = Date.MinValue Then

				StartDate = _MediaPlan.StartDate

			End If

			GetStartDateForRow = StartDate

		End Function

#Region "  Show Form Methods "

		Public Shared Function ShowFormDialog(ByVal MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan, ByVal RowIndexes As Generic.List(Of Integer), ByVal StartDate As Date, ByVal EndDate As Date, ByVal DataColumn As AdvantageFramework.MediaPlanning.DataColumns) As System.Windows.Forms.DialogResult

			'objects
			Dim MediaPlanDetailLevelLineDataDialog As AdvantageFramework.Media.Presentation.MediaPlanDetailLevelLineDataDialog = Nothing

			MediaPlanDetailLevelLineDataDialog = New AdvantageFramework.Media.Presentation.MediaPlanDetailLevelLineDataDialog(MediaPlan, RowIndexes, StartDate, EndDate, DataColumn)

			ShowFormDialog = MediaPlanDetailLevelLineDataDialog.ShowDialog()

		End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaPlanDetailLevelLineDataDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim KeepLoading As Boolean = False

            Me.ControlBox = False
            Me.ShowUnsavedChangesOnFormClosing = False

            DataGridViewForm_LevelLineData.OptionsView.ShowFooter = False
            DataGridViewForm_LevelLineData.UseEmbeddedNavigator = True

            DataGridViewForm_LevelLineData.CustomCancelEditButton.Visible = False
            'DataGridViewForm_LevelLineData.RunStandardValidation = False

            DateTimePickerForm_From.ReadOnly = True
            DateTimePickerForm_To.ReadOnly = True

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            ButtonItemSelectAll_Sunday.Tag = AdvantageFramework.DateUtilities.Days.Sunday
            ButtonItemSelectAll_Monday.Tag = AdvantageFramework.DateUtilities.Days.Monday
            ButtonItemSelectAll_Tuesday.Tag = AdvantageFramework.DateUtilities.Days.Tuesday
            ButtonItemSelectAll_Wednesday.Tag = AdvantageFramework.DateUtilities.Days.Wednesday
            ButtonItemSelectAll_Thursday.Tag = AdvantageFramework.DateUtilities.Days.Thursday
            ButtonItemSelectAll_Friday.Tag = AdvantageFramework.DateUtilities.Days.Friday
            ButtonItemSelectAll_Saturday.Tag = AdvantageFramework.DateUtilities.Days.Saturday

            ButtonItemDeselectAll_Sunday.Tag = AdvantageFramework.DateUtilities.Days.Sunday
            ButtonItemDeselectAll_Monday.Tag = AdvantageFramework.DateUtilities.Days.Monday
            ButtonItemDeselectAll_Tuesday.Tag = AdvantageFramework.DateUtilities.Days.Tuesday
            ButtonItemDeselectAll_Wednesday.Tag = AdvantageFramework.DateUtilities.Days.Wednesday
            ButtonItemDeselectAll_Thursday.Tag = AdvantageFramework.DateUtilities.Days.Thursday
            ButtonItemDeselectAll_Friday.Tag = AdvantageFramework.DateUtilities.Days.Friday
            ButtonItemDeselectAll_Saturday.Tag = AdvantageFramework.DateUtilities.Days.Saturday

            Try

                If _MediaPlan IsNot Nothing Then

                    KeepLoading = True

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("The media plan you are trying to edit does not exist anymore.")
                    Me.Close()

                End If

            Catch ex As Exception

            End Try

            If KeepLoading Then

                If _MediaPlan.MediaPlanEstimate.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.None Then

                    LabelForm_PeriodType.Visible = False

                Else

                    LabelForm_PeriodType.Text = String.Format(LabelForm_PeriodType.Text, AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.MediaPlanning.PeriodTypes), CInt(_MediaPlan.MediaPlanEstimate.PeriodType).ToString))
                    LabelForm_PeriodType.Visible = True

                End If

                Try

                    _MediaPlanDetailLevelLineDatas = _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevelLineDatas.Where(Function(Entity) _RowIndexes.Contains(Entity.RowIndex) = True AndAlso ((Entity.StartDate >= _StartDate AndAlso Entity.StartDate <= _EndDate) OrElse Entity.StartDate = Nothing)).OrderBy(Function(Entity) Entity.RowIndex).ThenBy(Function(Entity) Entity.StartDate).ToList

                Catch ex As Exception
                    _MediaPlanDetailLevelLineDatas = New Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData)
                End Try

                LoadLineAndLevelDetails()

                LoadGrid()

            End If

            If CDate(_StartDate.ToShortDateString) = CDate(_EndDate.ToShortDateString) Then

                ButtonForm_Copy.SecurityEnabled = False

            End If

            If _DataColumn = MediaPlanning.DataColumns.Week Then

                ButtonForm_SelectAll.Visible = True
                ButtonForm_DeselectAll.Visible = True

            Else

                ButtonForm_SelectAll.Visible = False
                ButtonForm_DeselectAll.Visible = False

            End If

            If _MediaPlan.MediaPlanEstimate.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.None Then

                If _MediaPlan.MediaPlanEstimate.SalesClassType = "O" AndAlso
                        (_DataColumn = MediaPlanning.Methods.DataColumns.Month OrElse
                         _DataColumn = MediaPlanning.Methods.DataColumns.MonthName OrElse
                         _DataColumn = MediaPlanning.Methods.DataColumns.Quarter OrElse
                         _DataColumn = MediaPlanning.Methods.DataColumns.Year) Then

                    ButtonForm_Update4WeekStartDate.Visible = True

                Else

                    ButtonForm_Update4WeekStartDate.Visible = False

                End If

            Else

                If _MediaPlan.MediaPlanEstimate.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.OOH4Week Then

                    ButtonForm_Update4WeekStartDate.Visible = True

                Else

                    ButtonForm_Update4WeekStartDate.Visible = False

                End If

            End If

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

        End Sub
        Private Sub MediaPlanDetailLevelLineDataDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

			EnableOrDisableActions()

			If DataGridViewForm_LevelLineData.HasASelectedRow Then

				DataGridViewForm_LevelLineData.CurrentView.FocusedColumn = DataGridViewForm_LevelLineData.Columns(AdvantageFramework.MediaPlanning.DataColumns.StartDate.ToString)

				DataGridViewForm_LevelLineData.CurrentView.ShowEditor()

				If TypeOf DataGridViewForm_LevelLineData.CurrentView.ActiveEditor Is DevExpress.XtraEditors.DateEdit Then

					CType(DataGridViewForm_LevelLineData.CurrentView.ActiveEditor, DevExpress.XtraEditors.DateEdit).ShowPopup()
					CType(DataGridViewForm_LevelLineData.CurrentView.ActiveEditor, DevExpress.XtraEditors.DateEdit).ClosePopup()

					Do Until DataGridViewForm_LevelLineData.CurrentView.ActiveEditor Is Nothing OrElse CType(DataGridViewForm_LevelLineData.CurrentView.ActiveEditor, DevExpress.XtraEditors.DateEdit).IsPopupOpen = False

						DataGridViewForm_LevelLineData.CurrentView.CloseEditor()

					Loop

				End If

			End If

		End Sub

#End Region

#Region "  Control Event Handlers "

		Private Sub DataGridViewForm_LevelLineData_CellValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_LevelLineData.CellValueChangedEvent

			'objects
			Dim MediaPlanDetailLevelLineData As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData = Nothing
			Dim LevelLineColor As Integer = 0

			Try

				MediaPlanDetailLevelLineData = DataGridViewForm_LevelLineData.GetFirstSelectedRowDataBoundItem

			Catch ex As Exception
				MediaPlanDetailLevelLineData = Nothing
			End Try

			If MediaPlanDetailLevelLineData IsNot Nothing Then

				LevelLineColor = _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.OfType(Of System.Data.DataRow).Where(Function(DR) MediaPlanDetailLevelLineData.RowIndex = DR(AdvantageFramework.MediaPlanning.LevelLineColumns.RowIndex.ToString) AndAlso
																																			 DR(AdvantageFramework.MediaPlanning.LevelLineColumns.Color.ToString) <> 0).Select(Function(DR) DR(AdvantageFramework.MediaPlanning.LevelLineColumns.Color.ToString)).Max

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

				If e.Column.FieldName = AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData.Properties.StartDate.ToString Then

                    If _MediaPlan.MediaPlanEstimate.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.None Then

                        If DataGridViewForm_LevelLineData.CurrentView.ActiveEditor.OldEditValue <> MediaPlanDetailLevelLineData.EndDate Then

                            _MediaPlan.MediaPlanEstimate.UpdateMediaPlanDetailLevelLineDataColor(DataGridViewForm_LevelLineData.CurrentView.ActiveEditor.OldEditValue, MediaPlanDetailLevelLineData.EndDate, MediaPlanDetailLevelLineData.RowIndex, 0)

                            MediaPlanDetailLevelLineData.EndDate = DateAdd(DateInterval.Day, 27, e.Value)

                        Else

                            MediaPlanDetailLevelLineData.EndDate = e.Value

                        End If

                    Else


                        If _MediaPlan.MediaPlanEstimate.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.Week Then

                            MediaPlanDetailLevelLineData.EndDate = _MediaPlan.MediaPlanEstimate.GetLastDayOfWeek(e.Value)

                        ElseIf _MediaPlan.MediaPlanEstimate.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.Month Then

                            MediaPlanDetailLevelLineData.EndDate = _MediaPlan.MediaPlanEstimate.GetLastDayOfMonth(e.Value)

                        ElseIf _MediaPlan.MediaPlanEstimate.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.OOH4Week Then

                            MediaPlanDetailLevelLineData.EndDate = DateAdd(DateInterval.Day, 27, e.Value)

                        Else

                            MediaPlanDetailLevelLineData.EndDate = e.Value

                        End If

                    End If

					DataGridViewForm_LevelLineData.ValidateAllRows()

				End If

                'If MediaPlanDetailLevelLineData.MediaPlanID <> 0 Then

                If e.Column.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Dollars.ToString Then

                    _MediaPlan.MediaPlanEstimate.UpdateMediaPlanDetailLevelLineData(MediaPlanDetailLevelLineData, MediaPlanning.DataColumns.Dollars)

                Else

                    _MediaPlan.MediaPlanEstimate.UpdateMediaPlanDetailLevelLineData(MediaPlanDetailLevelLineData, MediaPlanning.DataColumns.Color)

                End If

                'End If

                DataGridViewForm_LevelLineData.CurrentView.RefreshData()

			End If

		End Sub
		Private Sub DataGridViewForm_LevelLineData_CustomUnboundColumnDataEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles DataGridViewForm_LevelLineData.CustomUnboundColumnDataEvent

			'objects
			Dim MediaPlanDetailLevelLineData As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData = Nothing

			If e.Column.FieldName = "Is4WeekAllocation" Then

				If TypeOf e.Row Is AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData Then

					Try

						MediaPlanDetailLevelLineData = e.Row

					Catch ex As Exception
						MediaPlanDetailLevelLineData = Nothing
					End Try

					If MediaPlanDetailLevelLineData IsNot Nothing Then

						If e.IsGetData Then

							e.Value = (MediaPlanDetailLevelLineData.StartDate <> MediaPlanDetailLevelLineData.EndDate)

						ElseIf e.IsSetData Then

							If e.Value Then

								MediaPlanDetailLevelLineData.EndDate = DateAdd(DateInterval.Day, 27, MediaPlanDetailLevelLineData.StartDate)

								If MediaPlanDetailLevelLineData.EndDate > _MediaPlan.EndDate Then

									MediaPlanDetailLevelLineData.EndDate = MediaPlanDetailLevelLineData.StartDate
									AdvantageFramework.WinForm.MessageBox.Show("End date cannot exceed plan end date.")

								ElseIf MediaPlanDetailLevelLineData.EndDate > GetEndDateForRow(MediaPlanDetailLevelLineData.RowIndex) Then

									MediaPlanDetailLevelLineData.EndDate = MediaPlanDetailLevelLineData.StartDate
									AdvantageFramework.WinForm.MessageBox.Show("End date cannot exceed row end date.")

								End If

							Else

								MediaPlanDetailLevelLineData.EndDate = MediaPlanDetailLevelLineData.StartDate

							End If

						End If

					End If

				End If

			End If

		End Sub
		Private Sub DataGridViewForm_LevelLineData_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_LevelLineData.SelectionChangedEvent

			If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

				EnableOrDisableActions()

			End If

		End Sub
		Private Sub DataGridViewForm_LevelLineData_ShowingEditorEvent(sender As Object, e As ComponentModel.CancelEventArgs) Handles DataGridViewForm_LevelLineData.ShowingEditorEvent

			If DataGridViewForm_LevelLineData.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData.Properties.OrderID.ToString OrElse
					DataGridViewForm_LevelLineData.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData.Properties.OrderLineID.ToString OrElse
					DataGridViewForm_LevelLineData.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData.Properties.OrderLineNumber.ToString OrElse
					DataGridViewForm_LevelLineData.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData.Properties.OrderNumber.ToString Then

				e.Cancel = True

			End If

		End Sub
		Private Sub DataGridViewForm_LevelLineData_ShownEditorEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_LevelLineData.ShownEditorEvent

			'objects
			Dim MediaPlanDetailLevelLineData As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData = Nothing

			If DataGridViewForm_LevelLineData.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData.Properties.StartDate.ToString Then

				If TypeOf DataGridViewForm_LevelLineData.CurrentView.ActiveEditor Is DevExpress.XtraEditors.DateEdit Then

					CType(DataGridViewForm_LevelLineData.CurrentView.ActiveEditor, DevExpress.XtraEditors.DateEdit).Properties.MaxValue = _EndDate
					CType(DataGridViewForm_LevelLineData.CurrentView.ActiveEditor, DevExpress.XtraEditors.DateEdit).Properties.MinValue = _StartDate

				End If

			ElseIf DataGridViewForm_LevelLineData.CurrentView.FocusedColumn.FieldName = "Is4WeekAllocation" Then

				Try

					MediaPlanDetailLevelLineData = DataGridViewForm_LevelLineData.GetFirstSelectedRowDataBoundItem

				Catch ex As Exception
					MediaPlanDetailLevelLineData = Nothing
				End Try

				If MediaPlanDetailLevelLineData IsNot Nothing AndAlso TypeOf DataGridViewForm_LevelLineData.CurrentView.ActiveEditor Is DevExpress.XtraEditors.CheckEdit Then

					If MediaPlanDetailLevelLineData.OrderID.GetValueOrDefault(0) > 0 OrElse MediaPlanDetailLevelLineData.HasPendingOrders Then

						CType(DataGridViewForm_LevelLineData.CurrentView.ActiveEditor, DevExpress.XtraEditors.CheckEdit).Enabled = False

					Else

						CType(DataGridViewForm_LevelLineData.CurrentView.ActiveEditor, DevExpress.XtraEditors.CheckEdit).Enabled = True

					End If

				End If

			End If

		End Sub
		Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

			DataGridViewForm_LevelLineData.ValidateAllRows()

			If Me.Validator AndAlso DataGridViewForm_LevelLineData.HasAnyInvalidRows = False Then

				If _MediaPlanDetailLevelLineDatas IsNot Nothing Then

					For Each MPDLLD In _MediaPlanDetailLevelLineDatas.Where(Function(Entity) Entity.MediaPlanID = 0).ToList

						_MediaPlan.MediaPlanEstimate.AddMediaPlanDetailLevelLineData(MPDLLD, MPDLLD.StartDate, MPDLLD.RowIndex)

                        _MediaPlan.MediaPlanEstimate.UpdateMediaPlanDetailLevelLineData(MPDLLD, MediaPlanning.DataColumns.Color)

                    Next

				End If

				Me.ClearChanged()

				Me.DialogResult = Windows.Forms.DialogResult.OK
				Me.Close()

			Else

				AdvantageFramework.WinForm.MessageBox.Show("Please correct errors before continuing.")

			End If

		End Sub
		Private Sub DataGridViewForm_LevelLineData_CustomColumnDisplayTextEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles DataGridViewForm_LevelLineData.CustomColumnDisplayTextEvent

			'objects
			Dim RowIndex As Integer = 0

			If e.Column.FieldName = AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString Then

				If IsNothing(e.Value) = False AndAlso IsNumeric(e.Value) Then

					If Integer.TryParse(e.Value, RowIndex) Then

						e.DisplayText = RowIndex + 1

					End If

				End If

			End If

		End Sub
		Private Sub DataGridViewForm_LevelLineData_EmbeddedNavigatorButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs) Handles DataGridViewForm_LevelLineData.EmbeddedNavigatorButtonClick

			'objects
			Dim MediaPlanDetailLevelLineData As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData = Nothing
			Dim RowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing

			If Not e.Handled Then

				Select Case CType(e.Button.Tag, DevExpress.XtraEditors.NavigatorButtonType)

					Case DevExpress.XtraEditors.NavigatorButtonType.Remove

						DataGridViewForm_LevelLineData.CurrentView.CloseEditorForUpdating()

						If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete the activity in the selected rows?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

							Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Deleting
							Me.ShowWaitForm()
							Me.ShowWaitForm("Deleting...")

							Try

								RowHandlesAndDataBoundItems = DataGridViewForm_LevelLineData.GetAllSelectedRowsRowHandlesAndDataBoundItems

								For Each RowHandleAndDataBoundItem In RowHandlesAndDataBoundItems.ToList

									Try

										MediaPlanDetailLevelLineData = RowHandleAndDataBoundItem.Value

									Catch ex As Exception
										MediaPlanDetailLevelLineData = Nothing
									End Try

									If MediaPlanDetailLevelLineData IsNot Nothing Then

										_MediaPlan.MediaPlanEstimate.RemoveMediaPlanDetailLevelLineData(MediaPlanDetailLevelLineData)

										DataGridViewForm_LevelLineData.CurrentView.DeleteFromDataSource(RowHandleAndDataBoundItem.Value)

									End If

								Next

							Catch ex As Exception

							End Try

							Me.FormAction = WinForm.Presentation.FormActions.None
							Me.CloseWaitForm()

						End If

						e.Handled = True

				End Select

			End If

		End Sub
		Private Sub ButtonItemAllocate_AllRows_Click(sender As Object, e As EventArgs) Handles ButtonItemAllocate_AllRows.Click

			'objects
			Dim DataEntryMediaPlanDetailLevelLineData As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData = Nothing
			Dim RowCount As Integer = 0

			If DataGridViewForm_LevelLineData.HasRows Then

				If AdvantageFramework.Media.Presentation.MediaPlanDetailLevelLineDataFillDialog.ShowFormDialog(_MediaPlan, DataEntryMediaPlanDetailLevelLineData) = Windows.Forms.DialogResult.OK Then

					RowCount = DataGridViewForm_LevelLineData.CurrentView.RowCount

					For Each MediaPlanDetailLevelLineData In DataGridViewForm_LevelLineData.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData).ToList

						AdvantageFramework.MediaPlanning.AllocateDataOnMediaPlanDetailLevelLineData(_MediaPlan, MediaPlanDetailLevelLineData, DataEntryMediaPlanDetailLevelLineData, RowCount)

					Next

					DataGridViewForm_LevelLineData.CurrentView.RefreshData()

				End If

			End If

		End Sub
		Private Sub ButtonItemAllocate_SelectedRows_Click(sender As Object, e As EventArgs) Handles ButtonItemAllocate_SelectedRows.Click

			'objects
			Dim DataEntryMediaPlanDetailLevelLineData As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData = Nothing
			Dim RowCount As Integer = 0

			If DataGridViewForm_LevelLineData.HasRows Then

				If AdvantageFramework.Media.Presentation.MediaPlanDetailLevelLineDataFillDialog.ShowFormDialog(_MediaPlan, DataEntryMediaPlanDetailLevelLineData) = Windows.Forms.DialogResult.OK Then

					RowCount = DataGridViewForm_LevelLineData.CurrentView.SelectedRowsCount

					For Each MediaPlanDetailLevelLineData In DataGridViewForm_LevelLineData.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData).ToList

						AdvantageFramework.MediaPlanning.AllocateDataOnMediaPlanDetailLevelLineData(_MediaPlan, MediaPlanDetailLevelLineData, DataEntryMediaPlanDetailLevelLineData, RowCount)

					Next

					DataGridViewForm_LevelLineData.CurrentView.RefreshData()

				End If

			End If

		End Sub
		Private Sub ButtonItemUpdate_AllRows_Click(sender As Object, e As EventArgs) Handles ButtonItemUpdate_AllRows.Click

			'objects
			Dim DataEntryMediaPlanDetailLevelLineData As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData = Nothing

			If DataGridViewForm_LevelLineData.HasRows Then

				If AdvantageFramework.Media.Presentation.MediaPlanDetailLevelLineDataFillDialog.ShowFormDialog(_MediaPlan, DataEntryMediaPlanDetailLevelLineData) = Windows.Forms.DialogResult.OK Then

					For Each MediaPlanDetailLevelLineData In DataGridViewForm_LevelLineData.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData).ToList

						AdvantageFramework.MediaPlanning.UpdateDataOnMediaPlanDetailLevelLineData(_MediaPlan, MediaPlanDetailLevelLineData, DataEntryMediaPlanDetailLevelLineData)

					Next

					DataGridViewForm_LevelLineData.CurrentView.RefreshData()

				End If

			End If

		End Sub
		Private Sub ButtonItemUpdate_SelectedRows_Click(sender As Object, e As EventArgs) Handles ButtonItemUpdate_SelectedRows.Click

			'objects
			Dim DataEntryMediaPlanDetailLevelLineData As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData = Nothing

			If DataGridViewForm_LevelLineData.HasRows Then

				If AdvantageFramework.Media.Presentation.MediaPlanDetailLevelLineDataFillDialog.ShowFormDialog(_MediaPlan, DataEntryMediaPlanDetailLevelLineData) = Windows.Forms.DialogResult.OK Then

					For Each MediaPlanDetailLevelLineData In DataGridViewForm_LevelLineData.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData).ToList

						AdvantageFramework.MediaPlanning.UpdateDataOnMediaPlanDetailLevelLineData(_MediaPlan, MediaPlanDetailLevelLineData, DataEntryMediaPlanDetailLevelLineData)

					Next

					DataGridViewForm_LevelLineData.CurrentView.RefreshData()

				End If

			End If

		End Sub
		Private Sub ButtonForm_Copy_Click(sender As Object, e As EventArgs) Handles ButtonForm_Copy.Click

			'objects
			Dim NewMediaPlanDetailLevelLineData As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData = Nothing
			Dim MediaPlanDetailLevelLineData As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData = Nothing
			Dim EntryDate As Date = Nothing
			Dim FirstEntryDate As Date = Nothing
			Dim Copied As Boolean = False
			Dim DontHaveEnoughDates As Boolean = False
			Dim StartDate As Date = Nothing
			Dim HasADate As Boolean = True
			Dim HasLoopStartedOver As Boolean = False

			If DataGridViewForm_LevelLineData.HasASelectedRow AndAlso _MediaPlanDetailLevelLineDatas IsNot Nothing Then

				Try

					MediaPlanDetailLevelLineData = DataGridViewForm_LevelLineData.GetFirstSelectedRowDataBoundItem

				Catch ex As Exception
					MediaPlanDetailLevelLineData = Nothing
				End Try

				If MediaPlanDetailLevelLineData IsNot Nothing Then

					StartDate = MediaPlanDetailLevelLineData.StartDate

				Else

					StartDate = _StartDate

				End If

				StartDate = StartDate.AddDays(1)

				For Each MediaPlanDetailLevelLineData In DataGridViewForm_LevelLineData.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData).ToList

					EntryDate = StartDate
					HasADate = True
					HasLoopStartedOver = False

					Do Until IsValidEntryDate(EntryDate) AndAlso EntryDate >= _StartDate AndAlso EntryDate <= _EndDate

						If EntryDate > _EndDate AndAlso HasLoopStartedOver = False Then

							EntryDate = _StartDate
							HasLoopStartedOver = True

						ElseIf EntryDate = StartDate AndAlso HasLoopStartedOver Then

							HasADate = False
							Exit Do

						Else

							EntryDate = EntryDate.AddDays(1)

						End If

					Loop

					If HasADate AndAlso _MediaPlanDetailLevelLineDatas.Any(Function(Entity) Entity.StartDate = EntryDate AndAlso Entity.RowIndex = MediaPlanDetailLevelLineData.RowIndex) = False Then

						If FirstEntryDate = Nothing Then

							FirstEntryDate = EntryDate

						End If

						NewMediaPlanDetailLevelLineData = New AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData

						NewMediaPlanDetailLevelLineData.MediaPlanID = _MediaPlan.ID
						NewMediaPlanDetailLevelLineData.MediaPlanDetailID = _MediaPlan.MediaPlanEstimate.ID

						NewMediaPlanDetailLevelLineData.StartDate = EntryDate
						NewMediaPlanDetailLevelLineData.EndDate = EntryDate
						NewMediaPlanDetailLevelLineData.RowIndex = MediaPlanDetailLevelLineData.RowIndex

						_MediaPlan.MediaPlanEstimate.AddMediaPlanDetailLevelLineData(NewMediaPlanDetailLevelLineData, EntryDate, MediaPlanDetailLevelLineData.RowIndex)

						NewMediaPlanDetailLevelLineData.Demo1 = MediaPlanDetailLevelLineData.Demo1
						NewMediaPlanDetailLevelLineData.Demo2 = MediaPlanDetailLevelLineData.Demo2
						NewMediaPlanDetailLevelLineData.Dollars = MediaPlanDetailLevelLineData.Dollars
						NewMediaPlanDetailLevelLineData.Units = MediaPlanDetailLevelLineData.Units
						NewMediaPlanDetailLevelLineData.Rate = MediaPlanDetailLevelLineData.Rate
						NewMediaPlanDetailLevelLineData.Note = MediaPlanDetailLevelLineData.Note
						NewMediaPlanDetailLevelLineData.Color = MediaPlanDetailLevelLineData.Color
						NewMediaPlanDetailLevelLineData.Impressions = MediaPlanDetailLevelLineData.Impressions
						NewMediaPlanDetailLevelLineData.Clicks = MediaPlanDetailLevelLineData.Clicks
						NewMediaPlanDetailLevelLineData.AgencyFee = MediaPlanDetailLevelLineData.AgencyFee
                        NewMediaPlanDetailLevelLineData.BillAmount = MediaPlanDetailLevelLineData.BillAmount
                        NewMediaPlanDetailLevelLineData.NetCharge = MediaPlanDetailLevelLineData.NetCharge
                        NewMediaPlanDetailLevelLineData.Columns = MediaPlanDetailLevelLineData.Columns
                        NewMediaPlanDetailLevelLineData.InchesLines = MediaPlanDetailLevelLineData.InchesLines
                        NewMediaPlanDetailLevelLineData.IsActualized = False

                        NewMediaPlanDetailLevelLineData.Sunday = MediaPlanDetailLevelLineData.Sunday
						NewMediaPlanDetailLevelLineData.Monday = MediaPlanDetailLevelLineData.Monday
						NewMediaPlanDetailLevelLineData.Tuesday = MediaPlanDetailLevelLineData.Tuesday
						NewMediaPlanDetailLevelLineData.Wednesday = MediaPlanDetailLevelLineData.Wednesday
						NewMediaPlanDetailLevelLineData.Thursday = MediaPlanDetailLevelLineData.Thursday
						NewMediaPlanDetailLevelLineData.Friday = MediaPlanDetailLevelLineData.Friday
						NewMediaPlanDetailLevelLineData.Saturday = MediaPlanDetailLevelLineData.Saturday

						NewMediaPlanDetailLevelLineData.CreatedByUserCode = Session.UserCode
						NewMediaPlanDetailLevelLineData.CreatedDate = Now
						NewMediaPlanDetailLevelLineData.ModifiedByUserCode = Nothing
						NewMediaPlanDetailLevelLineData.ModifiedDate = Nothing

						_MediaPlanDetailLevelLineDatas.Add(NewMediaPlanDetailLevelLineData)

                        _MediaPlan.MediaPlanEstimate.UpdateMediaPlanDetailLevelLineData(NewMediaPlanDetailLevelLineData, MediaPlanning.DataColumns.Color)

                        Copied = True

					Else

						DontHaveEnoughDates = True
						Exit For

					End If

				Next

				If Copied Then

					If DontHaveEnoughDates Then

						AdvantageFramework.WinForm.MessageBox.Show("There are enough dates to available to copy all row(s).")

					End If

					_MediaPlanDetailLevelLineDatas = _MediaPlanDetailLevelLineDatas.OrderBy(Function(Entity) Entity.RowIndex).ThenBy(Function(Entity) Entity.StartDate).ToList

					LoadGrid()

					DataGridViewForm_LevelLineData.ValidateAllRows()

					DataGridViewForm_LevelLineData.SelectRow(3, FirstEntryDate)

				Else

					AdvantageFramework.WinForm.MessageBox.Show("There are not no more available dates left.")

				End If

			End If

		End Sub
		Private Sub DataGridViewForm_LevelLineData_ValidateRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles DataGridViewForm_LevelLineData.ValidateRowEvent

			'objects
			Dim MediaPlanDetailLevelLineData As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData = Nothing
			Dim ErrorText As String = ""

			If TypeOf e.Row Is AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData Then

				Try

					MediaPlanDetailLevelLineData = e.Row

				Catch ex As Exception
					MediaPlanDetailLevelLineData = Nothing
				End Try

				If MediaPlanDetailLevelLineData IsNot Nothing Then

					ValidateMediaPlanDetailLevelLineData(MediaPlanDetailLevelLineData, e.RowHandle, ErrorText)

					If MediaPlanDetailLevelLineData.EntityError <> ErrorText Then

						MediaPlanDetailLevelLineData.EntityError = ErrorText

					End If

					e.Valid = True

				End If

			End If

		End Sub
		Private Sub DataGridViewForm_LevelLineData_ValidatingEditorEvent(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles DataGridViewForm_LevelLineData.ValidatingEditorEvent

			'objects
			Dim MediaPlanDetailLevelLineData As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData = Nothing
			Dim ErrorText As String = ""

			If DataGridViewForm_LevelLineData.CurrentView.FocusedColumn IsNot Nothing Then

				If DataGridViewForm_LevelLineData.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData.Properties.StartDate.ToString Then

					Try

						MediaPlanDetailLevelLineData = DataGridViewForm_LevelLineData.CurrentView.GetFocusedRow

					Catch ex As Exception
						MediaPlanDetailLevelLineData = Nothing
					End Try

					If MediaPlanDetailLevelLineData IsNot Nothing Then

						ValidateMediaPlanDetailLevelLineData(MediaPlanDetailLevelLineData, DataGridViewForm_LevelLineData.CurrentView.FocusedRowHandle, ErrorText)

						If MediaPlanDetailLevelLineData.EntityError <> ErrorText Then

							MediaPlanDetailLevelLineData.EntityError = ErrorText

						End If

						e.Valid = True

					End If

					'ElseIf DataGridViewForm_LevelLineData.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData.Properties.Rate.ToString Then

					'    If e.Value = 0 Then

					'        Try

					'            MediaPlanDetailLevelLineData = DataGridViewForm_LevelLineData.CurrentView.GetFocusedRow

					'        Catch ex As Exception
					'            MediaPlanDetailLevelLineData = Nothing
					'        End Try

					'        If MediaPlanDetailLevelLineData IsNot Nothing Then

					'            If MediaPlanDetailLevelLineData.OrderNumber IsNot Nothing OrElse MediaPlanDetailLevelLineData.HasPendingOrders = True Then

					'                e.Valid = False

					'            End If

					'        End If

					'    End If

				End If

			End If

		End Sub
		Private Sub ButtonItemDeselectAllDay_Click(sender As Object, e As EventArgs) Handles ButtonItemDeselectAll_Sunday.Click, ButtonItemDeselectAll_Monday.Click, ButtonItemDeselectAll_Tuesday.Click,
																							 ButtonItemDeselectAll_Wednesday.Click, ButtonItemDeselectAll_Thursday.Click, ButtonItemDeselectAll_Friday.Click,
																							 ButtonItemDeselectAll_Saturday.Click

			SelectDeselectAllDay(sender.Tag, False)

			DataGridViewForm_LevelLineData.CurrentView.RefreshData()

		End Sub
		Private Sub ButtonItemSelectAllDay_Click(sender As Object, e As EventArgs) Handles ButtonItemSelectAll_Sunday.Click, ButtonItemSelectAll_Monday.Click, ButtonItemSelectAll_Tuesday.Click,
																						   ButtonItemSelectAll_Wednesday.Click, ButtonItemSelectAll_Thursday.Click, ButtonItemSelectAll_Friday.Click,
																						   ButtonItemSelectAll_Saturday.Click

			SelectDeselectAllDay(sender.Tag, True)

			DataGridViewForm_LevelLineData.CurrentView.RefreshData()

		End Sub
		Private Sub ButtonForm_SelectAll_Click(sender As Object, e As EventArgs) Handles ButtonForm_SelectAll.Click

			SelectDeselectAllDay(DateUtilities.Days.Sunday, True)
			SelectDeselectAllDay(DateUtilities.Days.Monday, True)
			SelectDeselectAllDay(DateUtilities.Days.Tuesday, True)
			SelectDeselectAllDay(DateUtilities.Days.Wednesday, True)
			SelectDeselectAllDay(DateUtilities.Days.Thursday, True)
			SelectDeselectAllDay(DateUtilities.Days.Friday, True)
			SelectDeselectAllDay(DateUtilities.Days.Saturday, True)

			DataGridViewForm_LevelLineData.CurrentView.RefreshData()

		End Sub
		Private Sub ButtonForm_DeselectAll_Click(sender As Object, e As EventArgs) Handles ButtonForm_DeselectAll.Click

			SelectDeselectAllDay(DateUtilities.Days.Sunday, False)
			SelectDeselectAllDay(DateUtilities.Days.Monday, False)
			SelectDeselectAllDay(DateUtilities.Days.Tuesday, False)
			SelectDeselectAllDay(DateUtilities.Days.Wednesday, False)
			SelectDeselectAllDay(DateUtilities.Days.Thursday, False)
			SelectDeselectAllDay(DateUtilities.Days.Friday, False)
			SelectDeselectAllDay(DateUtilities.Days.Saturday, False)

			DataGridViewForm_LevelLineData.CurrentView.RefreshData()

		End Sub
		Private Sub ButtonForm_Update4WeekStartDate_Click(sender As Object, e As EventArgs) Handles ButtonForm_Update4WeekStartDate.Click

			If DataGridViewForm_LevelLineData.HasMultipleSelectedRows AndAlso
					(DataGridViewForm_LevelLineData.GetAllSelectedRowsCellValues(AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData.Properties.RowIndex.ToString).
													OfType(Of Integer).Distinct.Count = 1) Then

				If AdvantageFramework.Media.Presentation.MediaPlanDetailLevelLineDataUpdate4WeekStartDateDialog.ShowFormDialog(_MediaPlan, DataGridViewForm_LevelLineData.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData).ToList) = Windows.Forms.DialogResult.OK Then

					DataGridViewForm_LevelLineData.CurrentView.RefreshData()

				End If

			End If

		End Sub
		Private Sub ButtonForm_AddRow_Click(sender As Object, e As EventArgs) Handles ButtonForm_AddRow.Click

			'objects
			Dim NewMediaPlanDetailLevelLineData As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData = Nothing
			Dim MediaPlanDetailLevelLineData As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData = Nothing
			Dim EntryDate As Date = Nothing
			Dim FirstEntryDate As Date = Nothing
			Dim Added As Boolean = False
			Dim StartDate As Date = Nothing
			Dim HasADate As Boolean = True
			Dim HasLoopStartedOver As Boolean = False

			If _MediaPlanDetailLevelLineDatas IsNot Nothing Then

				If _MediaPlanDetailLevelLineDatas.Count > 0 Then

					Try

						MediaPlanDetailLevelLineData = _MediaPlanDetailLevelLineDatas.OrderByDescending(Function(Entity) Entity.StartDate).FirstOrDefault

					Catch ex As Exception
						MediaPlanDetailLevelLineData = Nothing
					End Try

				End If

                If _MediaPlan.MediaPlanEstimate.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.None Then

                    If MediaPlanDetailLevelLineData IsNot Nothing Then

                        StartDate = MediaPlanDetailLevelLineData.StartDate

                    Else

                        StartDate = _StartDate

                    End If

                Else

                    If MediaPlanDetailLevelLineData IsNot Nothing Then

                        StartDate = MediaPlanDetailLevelLineData.EndDate.AddDays(1)

                    Else

                        StartDate = _StartDate

                    End If

                End If

                EntryDate = StartDate
				HasADate = True
				HasLoopStartedOver = False

				Do Until IsValidEntryDate(EntryDate) AndAlso EntryDate >= _StartDate AndAlso EntryDate <= _EndDate

					If EntryDate > _EndDate AndAlso HasLoopStartedOver = False Then

						EntryDate = _StartDate
						HasLoopStartedOver = True

					ElseIf EntryDate = StartDate AndAlso HasLoopStartedOver Then

						HasADate = False
						Exit Do

					Else

						EntryDate = EntryDate.AddDays(1)

					End If

				Loop

				If HasADate AndAlso _MediaPlanDetailLevelLineDatas.Any(Function(Entity) Entity.StartDate = EntryDate AndAlso Entity.RowIndex = MediaPlanDetailLevelLineData.RowIndex) = False Then

					If FirstEntryDate = Nothing Then

						FirstEntryDate = EntryDate

					End If

					NewMediaPlanDetailLevelLineData = New AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData

					NewMediaPlanDetailLevelLineData.MediaPlanID = _MediaPlan.ID
					NewMediaPlanDetailLevelLineData.MediaPlanDetailID = _MediaPlan.MediaPlanEstimate.ID

					NewMediaPlanDetailLevelLineData.StartDate = EntryDate
					NewMediaPlanDetailLevelLineData.EndDate = EntryDate
					NewMediaPlanDetailLevelLineData.RowIndex = _RowIndexes(0)

					_MediaPlan.MediaPlanEstimate.AddMediaPlanDetailLevelLineData(NewMediaPlanDetailLevelLineData, EntryDate, _RowIndexes(0))

                    If _MediaPlan.MediaPlanEstimate.PeriodType <> AdvantageFramework.MediaPlanning.PeriodTypes.None Then

                        If _MediaPlan.MediaPlanEstimate.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.Week Then

                            NewMediaPlanDetailLevelLineData.EndDate = EntryDate.AddDays(6)

                        ElseIf _MediaPlan.MediaPlanEstimate.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.Month Then

                            If EntryDate.Day = 1 Then

                                NewMediaPlanDetailLevelLineData.EndDate = _MediaPlan.MediaPlanEstimate.GetLastDayOfMonth(EntryDate)

                            Else

                                NewMediaPlanDetailLevelLineData.EndDate = EntryDate.AddDays(30)

                            End If

                        ElseIf _MediaPlan.MediaPlanEstimate.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.OOH4Week Then

                            NewMediaPlanDetailLevelLineData.EndDate = EntryDate.AddDays(27)

                        End If

                        If NewMediaPlanDetailLevelLineData.EndDate > _MediaPlan.EndDate Then

                            NewMediaPlanDetailLevelLineData.EndDate = _MediaPlan.EndDate

                        End If

                    End If

                    NewMediaPlanDetailLevelLineData.CreatedByUserCode = Session.UserCode
					NewMediaPlanDetailLevelLineData.CreatedDate = Now
					NewMediaPlanDetailLevelLineData.ModifiedByUserCode = Nothing
					NewMediaPlanDetailLevelLineData.ModifiedDate = Nothing

					_MediaPlanDetailLevelLineDatas.Add(NewMediaPlanDetailLevelLineData)

                    _MediaPlan.MediaPlanEstimate.UpdateMediaPlanDetailLevelLineData(NewMediaPlanDetailLevelLineData, MediaPlanning.DataColumns.Color)

                    Added = True

				End If

				If Added Then

					_MediaPlanDetailLevelLineDatas = _MediaPlanDetailLevelLineDatas.OrderBy(Function(Entity) Entity.RowIndex).ThenBy(Function(Entity) Entity.StartDate).ToList

					LoadGrid()

					DataGridViewForm_LevelLineData.ValidateAllRows()

					DataGridViewForm_LevelLineData.SelectRow(3, FirstEntryDate)

				Else

                    AdvantageFramework.WinForm.MessageBox.Show("There are no more available dates left.")

                End If

			End If

		End Sub

#End Region

#End Region

	End Class

End Namespace
