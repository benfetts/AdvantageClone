Namespace Media.Presentation

    Public Class MediaPlanDetailAllocateDataDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan = Nothing
        Private _RowIndex As Integer = 0
        Private _StartDate As Date = Nothing
        Private _EndDate As Date = Nothing
        Private _PresetStartDate As Date = Nothing
        Private _PresetEndDate As Date = Nothing
        Private _DataColumn As AdvantageFramework.MediaPlanning.DataColumns = MediaPlanning.DataColumns.ID
		Private _MediaPlanDetailLevelLineData As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData = Nothing
		Private _LoadingDateTime As Boolean = False

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByVal MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan, ByVal RowIndex As Integer, ByVal PresetStartDate As Date, ByVal PresetEndDate As Date, ByVal StartDate As Date, ByVal EndDate As Date, ByVal DataColumn As AdvantageFramework.MediaPlanning.DataColumns)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _MediaPlan = MediaPlan
            _RowIndex = RowIndex
            _PresetStartDate = PresetStartDate
            _PresetEndDate = PresetEndDate
            _StartDate = StartDate
            _EndDate = EndDate
            _DataColumn = DataColumn

        End Sub
        Private Sub LoadGrid()

            'objects
            Dim MediaPlanDetailLevelLineData As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData = Nothing
            Dim MediaPlanDetailLevelLineDataList As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData) = Nothing

            MediaPlanDetailLevelLineDataList = New Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData)

            MediaPlanDetailLevelLineData = New AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData

            MediaPlanDetailLevelLineData.MediaPlanID = _MediaPlan.ID
            MediaPlanDetailLevelLineData.MediaPlanDetailID = _MediaPlan.MediaPlanEstimate.ID
            MediaPlanDetailLevelLineData.RowIndex = _RowIndex

            MediaPlanDetailLevelLineDataList.Add(MediaPlanDetailLevelLineData)

            DataGridViewForm_LevelLineData.DataSource = MediaPlanDetailLevelLineDataList

            SetupGridColumns()

            DataGridViewForm_LevelLineData.OptionsView.ShowIndicator = False

            DataGridViewForm_LevelLineData.CurrentView.BestFitColumns()

        End Sub
        Private Sub SetupGridColumns()

            'objects
            Dim MediaPlanDetailField As AdvantageFramework.Database.Entities.MediaPlanDetailField = Nothing
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            For Each GridColumn In DataGridViewForm_LevelLineData.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                GridColumn.Visible = False

            Next

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

                        If (_MediaPlan.MediaPlanEstimate.SalesClassType = "R" OrElse _MediaPlan.MediaPlanEstimate.SalesClassType = "T") Then

                            CType(GridColumn.ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).MaxValue = 999999
                            CType(GridColumn.ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).MaxLength = 6

                        Else

                            CType(GridColumn.ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).MaxValue = Integer.MaxValue
                            CType(GridColumn.ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).MaxLength = 10

                        End If

                    ElseIf GridColumn.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Demo2.ToString Then

                        GridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        GridColumn.DisplayFormat.FormatString = "n1"

                        If (_MediaPlan.MediaPlanEstimate.SalesClassType = "R" OrElse _MediaPlan.MediaPlanEstimate.SalesClassType = "T") Then

                            CType(GridColumn.ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).MaxValue = 999999
                            CType(GridColumn.ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).MaxLength = 6

                        Else

                            CType(GridColumn.ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).MaxValue = Integer.MaxValue
                            CType(GridColumn.ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).MaxLength = 10

                        End If

                    ElseIf GridColumn.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Units.ToString Then

                        GridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        GridColumn.DisplayFormat.FormatString = "n0"

                        If (_MediaPlan.MediaPlanEstimate.SalesClassType = "R" OrElse _MediaPlan.MediaPlanEstimate.SalesClassType = "T") Then

                            CType(GridColumn.ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).MaxValue = 999999
                            CType(GridColumn.ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).MaxLength = 6

                        Else

                            CType(GridColumn.ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).MaxValue = Integer.MaxValue
                            CType(GridColumn.ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).MaxLength = 10

                        End If

                    ElseIf GridColumn.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Impressions.ToString Then

                        GridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        GridColumn.DisplayFormat.FormatString = "n0"

                        If (_MediaPlan.MediaPlanEstimate.SalesClassType = "R" OrElse _MediaPlan.MediaPlanEstimate.SalesClassType = "T") Then

                            CType(GridColumn.ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).MaxValue = 999999
                            CType(GridColumn.ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).MaxLength = 6

                        Else

                            CType(GridColumn.ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).MaxValue = Integer.MaxValue
                            CType(GridColumn.ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).MaxLength = 10

                        End If

                    ElseIf GridColumn.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Clicks.ToString Then

                        GridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        GridColumn.DisplayFormat.FormatString = "n0"

                        If (_MediaPlan.MediaPlanEstimate.SalesClassType = "R" OrElse _MediaPlan.MediaPlanEstimate.SalesClassType = "T") Then

                            CType(GridColumn.ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).MaxValue = 999999
                            CType(GridColumn.ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).MaxLength = 6

                        Else

                            CType(GridColumn.ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).MaxValue = Integer.MaxValue
                            CType(GridColumn.ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).MaxLength = 10

                        End If

                    ElseIf GridColumn.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Columns.ToString Then

                        GridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        GridColumn.DisplayFormat.FormatString = "n2"

                    ElseIf GridColumn.FieldName = AdvantageFramework.MediaPlanning.DataColumns.InchesLines.ToString Then

                        GridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        GridColumn.DisplayFormat.FormatString = "n2"

                    ElseIf GridColumn.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Rate.ToString Then

                        GridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        GridColumn.DisplayFormat.FormatString = "c2"

                    ElseIf GridColumn.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Dollars.ToString Then

                        GridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        GridColumn.DisplayFormat.FormatString = "c2"
                        'GridColumn.OptionsColumn.ReadOnly = _MediaPlan.MediaPlanEstimate.CalculateDollars

                    ElseIf GridColumn.FieldName = AdvantageFramework.MediaPlanning.DataColumns.NetCharge.ToString Then

                        GridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        GridColumn.DisplayFormat.FormatString = "c2"

                    ElseIf GridColumn.FieldName = AdvantageFramework.MediaPlanning.DataColumns.AgencyFee.ToString Then

                        GridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        GridColumn.DisplayFormat.FormatString = "c2"

                    ElseIf GridColumn.FieldName = AdvantageFramework.MediaPlanning.DataColumns.BillAmount.ToString Then

                        GridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        GridColumn.DisplayFormat.FormatString = "c2"
                        GridColumn.OptionsColumn.ReadOnly = True

                    ElseIf GridColumn.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Note.ToString Then

                        GridColumn.VisibleIndex = DataGridViewForm_LevelLineData.CurrentView.VisibleColumns.Count
                        GridColumn.Visible = True

                    ElseIf GridColumn.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Color.ToString Then

                        GridColumn.Visible = False

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

        End Sub
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
		Private Sub EnableOrDisableActions()



        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan, ByVal RowIndex As Integer, ByVal PresetStartDate As Date, ByVal PresetEndDate As Date, ByVal StartDate As Date, ByVal EndDate As Date, ByVal DataColumn As AdvantageFramework.MediaPlanning.DataColumns) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaPlanDetailAllocateDataDialog As AdvantageFramework.Media.Presentation.MediaPlanDetailAllocateDataDialog = Nothing

            MediaPlanDetailAllocateDataDialog = New AdvantageFramework.Media.Presentation.MediaPlanDetailAllocateDataDialog(MediaPlan, RowIndex, PresetStartDate, PresetEndDate, StartDate, EndDate, DataColumn)

            ShowFormDialog = MediaPlanDetailAllocateDataDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaPlanDetailAllocateDataDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim KeepLoadingGrid As Boolean = False

            DataGridViewForm_LevelLineData.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            DataGridViewForm_LevelLineData.OptionsView.ShowFooter = False
            DataGridViewForm_LevelLineData.OptionsView.ShowViewCaption = False

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            Try

                If _MediaPlan IsNot Nothing Then

                    If _MediaPlan.MediaPlanEstimate.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.None Then

                        LabelForm_ByDateType.Text = String.Format(LabelForm_ByDateType.Text, AdvantageFramework.StringUtilities.GetNameAsWords(_DataColumn.ToString))

                    Else

                        LabelForm_ByDateType.Text = String.Format(LabelForm_ByDateType.Text, AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.MediaPlanning.PeriodTypes), CInt(_MediaPlan.MediaPlanEstimate.PeriodType).ToString))

                    End If

                    DateEditForm_From.Properties.MinValue = _StartDate
                    DateEditForm_From.Properties.MaxValue = _EndDate

                    DateEditForm_To.Properties.MinValue = _StartDate
                    DateEditForm_To.Properties.MaxValue = _EndDate

                    DateEditForm_From.EditValue = _PresetStartDate
                    DateEditForm_To.EditValue = _PresetEndDate

                    If _MediaPlan.MediaPlanEstimate.IsCalendarMonth = False Then

                        DateEditForm_From.Properties.FirstDayOfWeek = DayOfWeek.Monday
                        DateEditForm_To.Properties.FirstDayOfWeek = DayOfWeek.Monday

                    End If

                    Try

                        _MediaPlanDetailLevelLineData = _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevelLineDatas.FirstOrDefault(Function(Entity) Entity.RowIndex = _RowIndex)

                    Catch ex As Exception
                        _MediaPlanDetailLevelLineData = Nothing
                    End Try

                    If _MediaPlan.MediaPlanEstimate.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.None Then

                        If _MediaPlan.MediaPlanEstimate.SalesClassType = "O" AndAlso
                                (_DataColumn = AdvantageFramework.MediaPlanning.DataColumns.Month OrElse
                                 _DataColumn = AdvantageFramework.MediaPlanning.DataColumns.MonthName OrElse
                                 _DataColumn = AdvantageFramework.MediaPlanning.DataColumns.Quarter OrElse
                                 _DataColumn = AdvantageFramework.MediaPlanning.DataColumns.Year) Then

                            CheckBoxForm_4WeekPeriodAllocation.Visible = True

                        End If

                    Else

                        If _MediaPlan.MediaPlanEstimate.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.Day Then

                            _DataColumn = AdvantageFramework.MediaPlanning.DataColumns.Day

                        ElseIf _MediaPlan.MediaPlanEstimate.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.Week Then

                            _DataColumn = AdvantageFramework.MediaPlanning.DataColumns.Week

                        ElseIf _MediaPlan.MediaPlanEstimate.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.Month Then

                            _DataColumn = AdvantageFramework.MediaPlanning.DataColumns.Month

                        ElseIf _MediaPlan.MediaPlanEstimate.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.OOH4Week Then

                            CheckBoxForm_4WeekPeriodAllocation.Checked = True

                        End If

                    End If

                    KeepLoadingGrid = True

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("The media plan you are trying to edit does not exist anymore.")
                    Me.Close()

                End If

            Catch ex As Exception

            End Try

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            If KeepLoadingGrid Then

                LoadGrid()

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            'objects
            Dim ErrorMessage As String = Nothing
            Dim DateDifferenceCount As Integer = 0
            Dim DataEntryMediaPlanDetailLevelLineData As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData = Nothing
            Dim MediaPlanDetailLevelLineData As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData = Nothing
            Dim StartDate As Date = Date.MinValue
            Dim FromDate As Date = Date.MinValue
            Dim ToDate As Date = Date.MinValue
            Dim StartDatesList As Generic.List(Of Date) = Nothing
            Dim Saved As Boolean = False
            Dim Color As Integer = 0
            Dim NumberOfPeriods As Integer = 0
            Dim NewStartDate As Date = Date.MinValue
            Dim FromDateDay As Integer = 1
            Dim FromDateMonth As Integer = 1
            Dim FromDateYear As Integer = 1

            If Me.Validator Then

                If CDate(DateEditForm_From.EditValue) >= _StartDate AndAlso CDate(DateEditForm_From.EditValue) <= _EndDate Then

                    If CDate(DateEditForm_To.EditValue) <= _EndDate AndAlso CDate(DateEditForm_To.EditValue) >= _StartDate Then

                        If CDate(DateEditForm_From.EditValue) <= CDate(DateEditForm_To.EditValue) Then

                            Try

                                DataEntryMediaPlanDetailLevelLineData = DataGridViewForm_LevelLineData.GetFirstSelectedRowDataBoundItem

                            Catch ex As Exception
                                DataEntryMediaPlanDetailLevelLineData = Nothing
                            End Try

                            If DataEntryMediaPlanDetailLevelLineData IsNot Nothing Then

                                Try

                                    If CheckBoxForm_4WeekPeriodAllocation.Checked = False Then

                                        Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Adding
                                        Me.ShowWaitForm()
                                        Me.ShowWaitForm("Adding...")

                                        Try

                                            Color = _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).Where(Function(Entity) Entity.RowIndex = _RowIndex).Select(Function(Entity) Entity.Color).Max

                                        Catch ex As Exception
                                            Color = 0
                                        End Try

                                        StartDatesList = New Generic.List(Of Date)

                                        FromDate = CDate(DateEditForm_From.EditValue.ToShortDateString)
                                        ToDate = CDate(DateEditForm_To.EditValue.ToShortDateString)

                                        FromDateDay = FromDate.Day

                                        If (_MediaPlan.MediaPlanEstimate.SalesClassType <> "R" AndAlso _MediaPlan.MediaPlanEstimate.SalesClassType <> "T") AndAlso
                                                _MediaPlan.MediaPlanEstimate.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.Month AndAlso
                                                FromDate.Day <> 1 Then

                                            Do Until FromDate >= ToDate

                                                If _MediaPlan.MediaPlanEstimate.IsOnHiatusDate(FromDate) = False Then

                                                    StartDatesList.Add(FromDate)

                                                End If

                                                If FromDate.Month = 12 Then

                                                    FromDateMonth = 1
                                                    FromDateYear = FromDate.Year + 1

                                                Else

                                                    FromDateMonth = FromDate.Month + 1
                                                    FromDateYear = FromDate.Year

                                                End If

                                                If Date.DaysInMonth(FromDateYear, FromDateMonth) < FromDateDay Then

                                                    FromDate = New Date(FromDateYear, FromDateMonth, Date.DaysInMonth(FromDateYear, FromDateMonth))

                                                Else

                                                    FromDate = New Date(FromDateYear, FromDateMonth, FromDateDay)

                                                End If

                                            Loop

                                        Else

                                            If _MediaPlan.MediaPlanEstimate.IsOnHiatusDate(FromDate) = False Then

                                                StartDatesList.Add(FromDate)

                                            End If

                                            FromDate = FromDate.AddDays(1)

                                            Do While FromDate < ToDate.AddDays(1)

                                                If _DataColumn = AdvantageFramework.MediaPlanning.DataColumns.Year Then

                                                    If _MediaPlan.MediaPlanEstimate.GetYear(FromDate.AddDays(-1)) <> _MediaPlan.MediaPlanEstimate.GetYear(FromDate) Then

                                                        If _MediaPlan.MediaPlanEstimate.IsOnHiatusDate(FromDate) = False Then

                                                            StartDatesList.Add(FromDate)

                                                        End If

                                                    End If

                                                ElseIf _DataColumn = AdvantageFramework.MediaPlanning.DataColumns.Quarter Then

                                                    If _MediaPlan.MediaPlanEstimate.GetQuarter(FromDate.AddDays(-1)) <> _MediaPlan.MediaPlanEstimate.GetQuarter(FromDate) Then

                                                        If _MediaPlan.MediaPlanEstimate.IsOnHiatusDate(FromDate) = False Then

                                                            StartDatesList.Add(FromDate)

                                                        End If

                                                    End If

                                                ElseIf _DataColumn = AdvantageFramework.MediaPlanning.DataColumns.Month OrElse
                                                    _DataColumn = AdvantageFramework.MediaPlanning.DataColumns.MonthName Then

                                                    If _MediaPlan.MediaPlanEstimate.GetMonth(FromDate.AddDays(-1)) <> _MediaPlan.MediaPlanEstimate.GetMonth(FromDate) Then

                                                        If _MediaPlan.MediaPlanEstimate.IsOnHiatusDate(FromDate) = False Then

                                                            StartDatesList.Add(FromDate)

                                                        End If

                                                    End If

                                                ElseIf _DataColumn = AdvantageFramework.MediaPlanning.DataColumns.Week Then

                                                    If _MediaPlan.MediaPlanEstimate.GetWeek(FromDate.AddDays(-1)) <> _MediaPlan.MediaPlanEstimate.GetWeek(FromDate) Then

                                                        If _MediaPlan.MediaPlanEstimate.IsOnHiatusDate(FromDate) = False Then

                                                            StartDatesList.Add(FromDate)

                                                        End If

                                                    End If

                                                ElseIf _DataColumn = AdvantageFramework.MediaPlanning.DataColumns.Day OrElse _DataColumn = AdvantageFramework.MediaPlanning.DataColumns.Date Then

                                                    If FromDate.AddDays(-1).Day <> FromDate.Day Then

                                                        If _MediaPlan.MediaPlanEstimate.IsOnHiatusDate(FromDate) = False Then

                                                            StartDatesList.Add(FromDate)

                                                        End If

                                                    End If

                                                End If

                                                FromDate = FromDate.AddDays(1)

                                            Loop

                                        End If

                                        _MediaPlan.MediaPlanEstimate.SaveHiatusMonths()
                                        _MediaPlan.MediaPlanEstimate.SaveHiatusWeeks()

                                        DateDifferenceCount = StartDatesList.Count

                                        For Each StartDate In StartDatesList

                                            Try

                                                MediaPlanDetailLevelLineData = _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevelLineDatas.SingleOrDefault(Function(Entity) Entity.RowIndex = _RowIndex AndAlso Entity.StartDate = StartDate)

                                            Catch ex As Exception
                                                MediaPlanDetailLevelLineData = Nothing
                                            End Try

                                            If MediaPlanDetailLevelLineData Is Nothing Then

                                                MediaPlanDetailLevelLineData = New AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData

                                                _MediaPlan.MediaPlanEstimate.AddMediaPlanDetailLevelLineData(MediaPlanDetailLevelLineData, StartDate, _RowIndex)

                                                If _MediaPlan.MediaPlanEstimate.PeriodType <> AdvantageFramework.MediaPlanning.PeriodTypes.None Then

                                                    If _MediaPlan.MediaPlanEstimate.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.Week Then

                                                        MediaPlanDetailLevelLineData.EndDate = StartDate.AddDays(6)

                                                    ElseIf _MediaPlan.MediaPlanEstimate.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.Month Then

                                                        If FromDateDay = 1 Then

                                                            MediaPlanDetailLevelLineData.EndDate = _MediaPlan.MediaPlanEstimate.GetLastDayOfMonth(StartDate)

                                                        Else

                                                            If StartDate.Month = 12 Then

                                                                FromDateMonth = 1
                                                                FromDateYear = StartDate.Year + 1

                                                            Else

                                                                FromDateMonth = StartDate.Month + 1
                                                                FromDateYear = StartDate.Year

                                                            End If

                                                            If Date.DaysInMonth(FromDateYear, FromDateMonth) < FromDateDay Then

                                                                MediaPlanDetailLevelLineData.EndDate = New Date(FromDateYear, FromDateMonth, Date.DaysInMonth(FromDateYear, FromDateMonth) - 1)

                                                            Else

                                                                MediaPlanDetailLevelLineData.EndDate = New Date(FromDateYear, FromDateMonth, FromDateDay - 1)

                                                            End If

                                                        End If

                                                    ElseIf _MediaPlan.MediaPlanEstimate.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.OOH4Week Then

                                                        MediaPlanDetailLevelLineData.EndDate = StartDate.AddDays(27)

                                                    End If

                                                    If MediaPlanDetailLevelLineData.EndDate > _MediaPlan.EndDate Then

                                                        MediaPlanDetailLevelLineData.EndDate = _MediaPlan.EndDate

                                                    End If

                                                End If

                                                _MediaPlan.MediaPlanEstimate.UpdateMediaPlanDetailLevelLineData(MediaPlanDetailLevelLineData, MediaPlanning.DataColumns.Dollars)

                                            End If

                                            MediaPlanDetailLevelLineData.Sunday = DataEntryMediaPlanDetailLevelLineData.Sunday
                                            MediaPlanDetailLevelLineData.Monday = DataEntryMediaPlanDetailLevelLineData.Monday
                                            MediaPlanDetailLevelLineData.Tuesday = DataEntryMediaPlanDetailLevelLineData.Tuesday
                                            MediaPlanDetailLevelLineData.Wednesday = DataEntryMediaPlanDetailLevelLineData.Wednesday
                                            MediaPlanDetailLevelLineData.Thursday = DataEntryMediaPlanDetailLevelLineData.Thursday
                                            MediaPlanDetailLevelLineData.Friday = DataEntryMediaPlanDetailLevelLineData.Friday
                                            MediaPlanDetailLevelLineData.Saturday = DataEntryMediaPlanDetailLevelLineData.Saturday

                                            If Color = 0 Then

                                                Color = _MediaPlan.MediaPlanEstimate.Color

                                            End If

                                            MediaPlanDetailLevelLineData.Color = Color

                                            If RadioButtonForm_Allocate.Checked Then

                                                AdvantageFramework.MediaPlanning.AllocateDataOnMediaPlanDetailLevelLineData(_MediaPlan, MediaPlanDetailLevelLineData, DataEntryMediaPlanDetailLevelLineData, DateDifferenceCount)

                                            Else

                                                AdvantageFramework.MediaPlanning.UpdateDataOnMediaPlanDetailLevelLineData(_MediaPlan, MediaPlanDetailLevelLineData, DataEntryMediaPlanDetailLevelLineData)

                                            End If

                                        Next

                                        Saved = True

                                        Me.CloseWaitForm()

                                        Me.ClearChanged()

                                        If Saved Then

                                            Me.DialogResult = Windows.Forms.DialogResult.OK
                                            Me.Close()

                                        End If

                                    Else

                                        If AdvantageFramework.WinForm.Presentation.NumericInputDialog.ShowFormDialog("4 Week Period Allocation", "Enter number of periods", 1, NumberOfPeriods, Nothing,
                                                                                                                 AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.Integer, True, 1) = Windows.Forms.DialogResult.OK Then

                                            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Adding
                                            Me.ShowWaitForm()
                                            Me.ShowWaitForm("Adding...")

                                            Try

                                                Color = _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).Where(Function(Entity) Entity.RowIndex = _RowIndex).Select(Function(Entity) Entity.Color).Max

                                            Catch ex As Exception
                                                Color = 0
                                            End Try

                                            StartDatesList = New Generic.List(Of Date)

                                            FromDate = CDate(DateEditForm_From.EditValue.ToShortDateString)
                                            ToDate = CDate(DateEditForm_To.EditValue.ToShortDateString)

                                            For Period As Integer = 1 To NumberOfPeriods Step 1

                                                Do Until _MediaPlan.MediaPlanEstimate.IsOnHiatusDate(FromDate) = False

                                                    FromDate = FromDate.AddDays(1)

                                                Loop

                                                StartDatesList.Add(FromDate)

                                                FromDate = FromDate.AddDays(28)

                                            Next

                                            For Each StartDate In StartDatesList

                                                If StartDate.AddDays(27) > ToDate Then

                                                    Throw New Exception("Period (" & StartDate.ToShortDateString & " - " & StartDate.AddDays(27).ToShortDateString & ") exceeds the allocation date and cannot be created.")

                                                End If

                                            Next

                                            For Each StartDate In StartDatesList

                                                If StartDate.AddDays(27) <= ToDate Then

                                                    Try

                                                        MediaPlanDetailLevelLineData = _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevelLineDatas.SingleOrDefault(Function(Entity) Entity.RowIndex = _RowIndex AndAlso Entity.StartDate = StartDate)

                                                    Catch ex As Exception
                                                        MediaPlanDetailLevelLineData = Nothing
                                                    End Try

                                                    If MediaPlanDetailLevelLineData Is Nothing Then

                                                        MediaPlanDetailLevelLineData = New AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData

                                                        _MediaPlan.MediaPlanEstimate.AddMediaPlanDetailLevelLineData(MediaPlanDetailLevelLineData, StartDate, _RowIndex)

                                                        _MediaPlan.MediaPlanEstimate.UpdateMediaPlanDetailLevelLineData(MediaPlanDetailLevelLineData, MediaPlanning.DataColumns.Dollars)

                                                        MediaPlanDetailLevelLineData.EndDate = StartDate.AddDays(27)

                                                    End If

                                                    MediaPlanDetailLevelLineData.Sunday = DataEntryMediaPlanDetailLevelLineData.Sunday
                                                    MediaPlanDetailLevelLineData.Monday = DataEntryMediaPlanDetailLevelLineData.Monday
                                                    MediaPlanDetailLevelLineData.Tuesday = DataEntryMediaPlanDetailLevelLineData.Tuesday
                                                    MediaPlanDetailLevelLineData.Wednesday = DataEntryMediaPlanDetailLevelLineData.Wednesday
                                                    MediaPlanDetailLevelLineData.Thursday = DataEntryMediaPlanDetailLevelLineData.Thursday
                                                    MediaPlanDetailLevelLineData.Friday = DataEntryMediaPlanDetailLevelLineData.Friday
                                                    MediaPlanDetailLevelLineData.Saturday = DataEntryMediaPlanDetailLevelLineData.Saturday

                                                    If Color = 0 Then

                                                        Color = _MediaPlan.MediaPlanEstimate.Color

                                                    End If

                                                    MediaPlanDetailLevelLineData.Color = Color

                                                    _MediaPlan.MediaPlanEstimate.UpdateMediaPlanDetailLevelLineDataColor(MediaPlanDetailLevelLineData)

                                                    If RadioButtonForm_Allocate.Checked Then

                                                        AdvantageFramework.MediaPlanning.AllocateDataOnMediaPlanDetailLevelLineData(_MediaPlan, MediaPlanDetailLevelLineData, DataEntryMediaPlanDetailLevelLineData, NumberOfPeriods)

                                                    Else

                                                        AdvantageFramework.MediaPlanning.UpdateDataOnMediaPlanDetailLevelLineData(_MediaPlan, MediaPlanDetailLevelLineData, DataEntryMediaPlanDetailLevelLineData)

                                                    End If

                                                End If

                                            Next

                                            Saved = True

                                        End If

                                        Me.CloseWaitForm()

                                        Me.ClearChanged()

                                        If Saved Then

                                            Me.DialogResult = Windows.Forms.DialogResult.OK
                                            Me.Close()

                                        End If

                                    End If

                                Catch ex As Exception
                                    AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                                End Try

                                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                                If Saved = False Then

                                    Me.CloseWaitForm()

                                End If

                            Else

                                AdvantageFramework.WinForm.MessageBox.Show("Data entry failed. Please contact Software Support.")

                            End If

                        Else

                            AdvantageFramework.WinForm.MessageBox.Show("Please select a from date on or before the to date.")

                        End If

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show("Please pick a date between '" & _StartDate.ToShortDateString & "' and '" & _EndDate.ToShortDateString & "'.")

                    End If

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Please pick a date between '" & _StartDate.ToShortDateString & "' and '" & _EndDate.ToShortDateString & "'.")

                End If

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub DateEditForm_From_DrawItem(sender As Object, e As DevExpress.XtraEditors.Calendar.CustomDrawDayNumberCellEventArgs) Handles DateEditForm_From.DrawItem

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

								Brush = Drawing.Brushes.Black

								StringFormat = New System.Drawing.StringFormat
								StringFormat.Alignment = System.Drawing.StringAlignment.Center
								StringFormat.LineAlignment = System.Drawing.StringAlignment.Center

								e.Graphics.DrawString(e.Date.Day.ToString(), e.Style.Font, Brush, e.Bounds, StringFormat)

								e.Handled = True

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

			End If

		End Sub
		Private Sub DateEditForm_To_DrawItem(sender As Object, e As DevExpress.XtraEditors.Calendar.CustomDrawDayNumberCellEventArgs) Handles DateEditForm_To.DrawItem

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

								Brush = Drawing.Brushes.Black

								StringFormat = New System.Drawing.StringFormat
								StringFormat.Alignment = System.Drawing.StringAlignment.Center
								StringFormat.LineAlignment = System.Drawing.StringAlignment.Center

								e.Graphics.DrawString(e.Date.Day.ToString(), e.Style.Font, Brush, e.Bounds, StringFormat)

								e.Handled = True

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

			End If

		End Sub
		Private Sub DateEditForm_To_Popup(sender As Object, e As EventArgs) Handles DateEditForm_To.Popup

			'objects
			Dim PopupControl As DevExpress.Utils.Win.IPopupControl = Nothing
			Dim PopupDateEditForm As DevExpress.XtraEditors.Popup.PopupDateEditForm = Nothing
			Dim CalendarControl As DevExpress.XtraEditors.Controls.CalendarControl = Nothing
			Dim DateTimeFormatInfo As System.Globalization.DateTimeFormatInfo = Nothing

			If _MediaPlan.MediaPlanEstimate IsNot Nothing AndAlso _MediaPlan.MediaPlanEstimate.IsCalendarMonth = False Then

				PopupControl = CType(sender, DevExpress.Utils.Win.IPopupControl)
				PopupDateEditForm = TryCast(PopupControl.PopupWindow, DevExpress.XtraEditors.Popup.PopupDateEditForm)

				If PopupDateEditForm IsNot Nothing Then

					For Each CalendarControl In PopupDateEditForm.Controls.OfType(Of DevExpress.XtraEditors.Controls.CalendarControl)().ToList

						DateTimeFormatInfo = CType(CalendarControl.DateFormat.Clone(), System.Globalization.DateTimeFormatInfo)
						DateTimeFormatInfo.FirstDayOfWeek = DayOfWeek.Monday
						CalendarControl.DateFormat = DateTimeFormatInfo

						_LoadingDateTime = True

						Try

							If DateEditForm_To.EditValue <> Nothing Then

								If DateEditForm_To.DateTime.Day = 1 Then

									CalendarControl.DateTime = CDate(_MediaPlan.MediaPlanEstimate.GetMonth(DateEditForm_To.EditValue) & "/01/" & _MediaPlan.MediaPlanEstimate.GetYear(DateEditForm_To.EditValue))

								Else

									CalendarControl.DateTime = CDate(_MediaPlan.MediaPlanEstimate.GetMonth(DateEditForm_To.EditValue) & "/02/" & _MediaPlan.MediaPlanEstimate.GetYear(DateEditForm_To.EditValue))

								End If

							End If

						Catch ex As Exception

						End Try

						_LoadingDateTime = False

					Next

				End If

			End If

		End Sub
		Private Sub DateEditForm_From_Popup(sender As Object, e As EventArgs) Handles DateEditForm_From.Popup

			'objects
			Dim PopupControl As DevExpress.Utils.Win.IPopupControl = Nothing
			Dim PopupDateEditForm As DevExpress.XtraEditors.Popup.PopupDateEditForm = Nothing
			Dim CalendarControl As DevExpress.XtraEditors.Controls.CalendarControl = Nothing
			Dim DateTimeFormatInfo As System.Globalization.DateTimeFormatInfo = Nothing

			If _MediaPlan.MediaPlanEstimate IsNot Nothing AndAlso _MediaPlan.MediaPlanEstimate.IsCalendarMonth = False Then

				PopupControl = CType(sender, DevExpress.Utils.Win.IPopupControl)
				PopupDateEditForm = TryCast(PopupControl.PopupWindow, DevExpress.XtraEditors.Popup.PopupDateEditForm)

				If PopupDateEditForm IsNot Nothing Then

					For Each CalendarControl In PopupDateEditForm.Controls.OfType(Of DevExpress.XtraEditors.Controls.CalendarControl)().ToList

						DateTimeFormatInfo = CType(CalendarControl.DateFormat.Clone(), System.Globalization.DateTimeFormatInfo)
						DateTimeFormatInfo.FirstDayOfWeek = DayOfWeek.Monday
						CalendarControl.DateFormat = DateTimeFormatInfo

						_LoadingDateTime = True

						Try

							If DateEditForm_From.EditValue <> Nothing Then

								If DateEditForm_From.DateTime.Day = 1 Then

									CalendarControl.DateTime = CDate(_MediaPlan.MediaPlanEstimate.GetMonth(DateEditForm_From.EditValue) & "/01/" & _MediaPlan.MediaPlanEstimate.GetYear(DateEditForm_From.EditValue))

								Else

									CalendarControl.DateTime = CDate(_MediaPlan.MediaPlanEstimate.GetMonth(DateEditForm_From.EditValue) & "/02/" & _MediaPlan.MediaPlanEstimate.GetYear(DateEditForm_From.EditValue))

								End If

							End If

						Catch ex As Exception

						End Try

						_LoadingDateTime = False

					Next

				End If

            End If

        End Sub
        Private Sub DataGridViewForm_LevelLineData_CustomDrawRowIndicatorEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles DataGridViewForm_LevelLineData.CustomDrawRowIndicatorEvent

            If e.Info.IsRowIndicator AndAlso e.RowHandle >= 0 Then

                e.Info.ImageIndex = -1
                e.Handled = True

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
